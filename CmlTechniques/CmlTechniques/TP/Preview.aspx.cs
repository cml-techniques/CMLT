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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace CmlTechniques.TP
{
    public partial class Preview : System.Web.UI.Page
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
        private void Generate_Reports(string _rpt, int _id)
        {
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            //_objbll.CAS_PKG_SUM_RPT(_objdb);
            if (_rpt == "1")
            {
                cryRpt.Load(Server.MapPath("com_certificate.rpt"));
            }
            else if (_rpt == "2")
            {
                cryRpt.Load(Server.MapPath("precom_checklist.rpt"));
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Not Available');", true);
                return;
            }
            crConnectionInfo.ServerName = "173.83.250.253";
            crConnectionInfo.DatabaseName = "DBCML";
            crConnectionInfo.UserID = "sa";
            crConnectionInfo.Password = "vCr6wgu3";
            CrTables = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
            //string _s = "MEP";
            //string selectionformula = "{CAS_RPT.BZONE}='" + _s + "' and {CAS_RPT.CATE}=\"DB\"";
            cryRpt.SetParameterValue("id", _id);
            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.DataBind();
            Session["Report"] = cryRpt;
        }
      

        //private string Get_ProjectName(string _prj)
        //{
        //    BLL_Dml _objbll = new BLL_Dml();
        //    _database _objdb = new _database();
        //    _clsuser _objcls = new _clsuser();
        //    _objcls.project_code = lblprj.Text;
        //    _objdb.DBName = "DBCML";
        //    return _objbll.Get_ProjectName(_objcls, _objdb);
        //}
        private void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                string _id = _prm.Substring(0, _prm.IndexOf("_R"));
                string _rpt = _prm.Substring(_prm.IndexOf("_R") + 2);
                Generate_Reports(_rpt, Convert.ToInt32(_id));
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
       
    }
}
