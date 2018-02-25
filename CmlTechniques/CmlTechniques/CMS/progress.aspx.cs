using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using BusinessLogic;
using App_Properties;
namespace CmlTechniques.CMS
{
    public partial class progress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        ReportDocument cryRpt = new ReportDocument();
        protected void Page_Unload(object sender, EventArgs e)
        {
                //cryRpt.Dispose();
                //cryRpt.Close();
        }
        private void GenerateReport()
        {

            DataSet _ds = new DataSet();
            DataTable _dt = GetRptData(9);
            _ds.Tables.Add(_dt);
            //_ds.WriteXmlSchema(Server.MapPath("") + "\\commsummary1.xml");
            
            cryRpt.Load(Server.MapPath("commprogresssummary.rpt"));
            cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
            //cryRpt.SetParameterValue(0, "6");
            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.DataBind();
            Session["Report"] = cryRpt;
            cryRpt.Dispose();
        }
        private void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblprj.Text = Request.QueryString[0].ToString();
                //lblbz.Text = Request.QueryString[1].ToString();
                GenerateReport();
                Session["Report"] = null;
            }
            else
            {
                if (Session["Report"] != null)
                {
                    CrystalReportViewer1.ReportSource = (ReportDocument)Session["Report"];
                    CrystalReportViewer1.DataBind();
                }
            }
        }
        private DataTable GetRptData(int sch)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
              _objdb.DBName = "DB_" + lblprj.Text;
            //_objdb.DBName = "DB_OPH";
            _objcls.sch = sch;
            return _objbll.Generate_Commissioning_Summary(_objcls, _objdb);
        }
    }
}
