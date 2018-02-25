using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BusinessLogic;
using App_Properties;
using CrystalDecisions.CrystalReports.Engine;

namespace CmlTechniques.CasSheet
{
    public partial class BuildingSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                
            //}
        }
        
        protected void TimerTick(object sender, EventArgs e)
        {
            ////imgLoader.Visible = false;
            if(lblbz.Text=="0")
                GenerateReport("6");
            else
                GenerateReport("0");
            Timer1.Enabled = false;
            //imgLoader.Visible = false;
        }
        private DataTable GetRptData(string _type)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_" + lblprj.Text;
            try
            {
                if (_type == "6")
                {
                    //return _objbll.GENERATE_OVERALL_SUMMARY_BLDG(_objdb);
                    _objcls.b_zone = "all";
                    return _objbll.Load_Building_Summary_ASAO(_objcls,_objdb);
                }
                else if (_type == "6_1")
                {
                    return _objbll.GENERATE_OVERALL_SUMMARY_BLDG1(_objdb);
                }
                else if (_type == "6_2")
                {
                    return _objbll.GENERATE_OVERALL_SUMMARY_BLDG2(_objdb);
                }
                else if (_type == "6_3")
                {
                    return _objbll.GENERATE_OVERALL_SUMMARY_BLDG3(_objdb);
                }
                else if (_type == "6_4")
                {
                    return _objbll.GENERATE_OVERALL_SUMMARY_BLDG4(_objdb);
                }
                else if (_type == "0")
                {
                    _objcls.b_zone = lblbz.Text;
                    //return _objbll.GENERATE_DIV_SUMMARY_SELECT(_objcls, _objdb);
                    return _objbll.Load_Building_Summary_ASAO(_objcls, _objdb);
                }
                return null;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.ToString() + "');", true);
            }
            return null;
        }
        ReportDocument cryRpt = new ReportDocument();
        protected void Page_Unload(object sender, EventArgs e)
        {
                //cryRpt.Dispose();
                //cryRpt.Close();
        }
        private void GenerateReport(string _type)
        {

            DataSet _ds = new DataSet();
            DataTable _dt = GetRptData(_type);
            //_ds.WriteXmlSchema(Server.MapPath("") + "\\bsummary.xml");
            
            if (_type == "6")
            {
                //DataTable _dmain = new DataTable();
                //_dmain.Merge(_dt, true);
                //_dt = GetRptData("6_1");
                //_dmain.Merge(_dt, true);
                //_dt = GetRptData("6_2");
                //_dmain.Merge(_dt, true);
                //_dt = GetRptData("6_3");
                //_dmain.Merge(_dt, true);
                //_dt = GetRptData("6_4");
                //_dmain.Merge(_dt, true);
                //_ds.Tables.Add(_dmain);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("BldgSummaryASAO_.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                //cryRpt.Subreports[0].Database.Tables[0].SetDataSource(_ds.Tables[0]);
                //cryRpt.Subreports[1].Database.Tables[0].SetDataSource(_ds.Tables[1]);
                //cryRpt.Subreports[2].Database.Tables[0].SetDataSource(_ds.Tables[2]);
                //cryRpt.Subreports[3].Database.Tables[0].SetDataSource(_ds.Tables[3]);
                //cryRpt.Subreports[4].Database.Tables[0].SetDataSource(_ds.Tables[4]);
            }
            else if (_type == "0")
            {
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("BldgSummaryASAO_.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
            }
            //cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
            cryRpt.SetParameterValue(0,"6");
            CrystalReportViewer2.ReportSource = cryRpt;
            CrystalReportViewer2.DataBind();
            Session["Report"] = cryRpt;
            ////cryRpt.Dispose();
        }
        private void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblprj.Text = Request.QueryString[0].ToString();
                lblbz.Text = Request.QueryString[1].ToString();
                Session["Report"] = null;
            }
            else
            {
                if (Session["Report"] != null)
                {
                    CrystalReportViewer2.ReportSource = (ReportDocument)Session["Report"];
                    CrystalReportViewer2.DataBind();
                }
            }
        }
       
       
    }
}
