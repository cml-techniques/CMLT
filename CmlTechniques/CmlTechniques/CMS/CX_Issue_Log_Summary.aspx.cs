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
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Collections.Generic;

namespace CmlTechniques.CMS
{
    public partial class CX_Issue_Log_Summary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                if (_prm == "1")
                {
                    Generate_Summary();
                }
                Generate_Reports(_prm);
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
        private void Generate_Summary()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsproject _objcls = new _clsproject();
            _objcls.prjcode = "CCAD";
            _objbll.Generate_CX_Log_Rpt(_objdb);
        }
        private void Generate_Logo()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsproject _objcls = new _clsproject();
            _objcls.prjcode = "CCAD";
            _objbll.Update_RPTLogo(_objcls, _objdb);
        }
        ReportDocument cryRpt = new ReportDocument();
        protected void Page_Unload(object sender, EventArgs e)
        {
                //cryRpt.Dispose();
                //cryRpt.Close();
        }
        private void Generate_Reports(string _prm)
        {
            Generate_Logo();
            
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            if(_prm=="1")
                cryRpt.Load(Server.MapPath("CX_Log_Summary.rpt"));
            else if(_prm=="2")
                cryRpt.Load(Server.MapPath("CXIssuesLog_R.rpt"));
            else if(_prm=="3")
                cryRpt.Load(Server.MapPath("CX_RO_Summary_.rpt"));
            else if (_prm == "4")
                cryRpt.Load(Server.MapPath("CXIR_Schedule_R.rpt"));
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
            //cryRpt.SetParameterValue("sch", lblsch.Text);
            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.DataBind();
            Session["Report"] = cryRpt;
        }
    }
}
