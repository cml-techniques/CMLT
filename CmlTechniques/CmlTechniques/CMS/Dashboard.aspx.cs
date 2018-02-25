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
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace CmlTechniques.CMS
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void _ReadCookies()
        {
            if (Request.Browser.Cookies)
            {
                if (Request.Cookies["uid"] != null)
                {
                    Session["uid"] = Server.HtmlEncode(Request.Cookies["uid"].Value);
                }
                if (Request.Cookies["project"] != null)
                {
                    Session["project"] = Server.HtmlEncode(Request.Cookies["project"].Value);
                }
                if (Request.Cookies["projectname"] != null)
                {
                    Session["projectname"] = Server.HtmlEncode(Request.Cookies["projectname"].Value);
                }
                if (Request.Cookies["sch"] != null)
                {
                    Session["sch"] = Server.HtmlEncode(Request.Cookies["sch"].Value);
                }
                if (Request.Cookies["srv"] != null)
                {
                    Session["srv"] = Server.HtmlEncode(Request.Cookies["srv"].Value);
                }
            }
        }
        private void Page_Init(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack) {
                string _prm = Request.QueryString[0].ToString();
                lblprj.Text = _prm;
                Generate_Project_Summary_New();
              

                Generate_Reports("All","All","0");
            }            
        }
        private void Generate_Project_Summary_New()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;

            _clscassheet _objcls = new _clscassheet();
            _objcls.b_zone = "All";
            _objcls.f_level = "All";
            _objbll.Generate_Prj_summary_Overall(_objcls, _objdb);

        }
        ReportDocument cryRpt = new ReportDocument();
        protected void Page_Unload(object sender, EventArgs e)
        {
                //cryRpt.Dispose();
                //cryRpt.Close();
        }
        private void Generate_Reports(string _bz, string _fl, string mode)
        {
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            if (lblprj.Text == "14211")
            {
                cryRpt.Load(Server.MapPath("ServiceSummary_KAIA.rpt"));
               // string _bldg = Get_Facility_Name();
               // cryRpt.SetParameterValue("bldg", _bldg);
            }
            else if (lblprj.Text == "HMIM")
            {
                cryRpt.Load(Server.MapPath("ServiceSummary_HMIM.rpt"));
                string _bldg = "";
                if (lbldiv.Text == "1") _bldg = "CENTRAL UTILITY CENTRE";
                else if (lbldiv.Text == "2") _bldg = "PIAZZA";
                else if (lbldiv.Text == "3") _bldg = "SERVICE BUILDING";
                else if (lbldiv.Text == "4") _bldg = "HARAM";
                cryRpt.SetParameterValue("bldg", _bldg);
            }
            else if (lblprj.Text == "PCD" && mode == "2")
            {
                cryRpt.Load(Server.MapPath("ProjectSummary_Pcd.rpt"));
            }
            else
                cryRpt.Load(Server.MapPath("ServiceSummary.rpt"));

            //crConnectionInfo.ServerName = "213.171.197.149,49296";
            //crConnectionInfo.DatabaseName = "DBCML";
            //crConnectionInfo.UserID = "CMLT";
            //crConnectionInfo.Password = "C!m@l#S$q%l";
            crConnectionInfo.ServerName = Constants.CMLTConstants.serverName;
            crConnectionInfo.DatabaseName = Constants.CMLTConstants.dbName;
            crConnectionInfo.UserID = Constants.CMLTConstants.dbUserName;
            crConnectionInfo.Password = Constants.CMLTConstants.dbPassword;
            CrTables = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
            //string _s = "MEP";
            //string selectionformula = "{CAS_RPT.BZONE}='" + _s + "' and {CAS_RPT.CATE}=\"DB\"";
            //SelectionFormula(cryRpt, (string)Session["zone"], (string)Session["cat"], (string)Session["flvl"], (string)Session["fed"]);
            //if((string)Session["srv"]=="0")
            //    cryRpt.SetParameterValue("srv","P");
            //else
            //cryRpt.Refresh();
            //if ((string)Session["bz"] == null) Session["bz"] = "All";
            //if ((string)Session["fl"] == null) Session["fl"] = "All";
            CrystalReportViewer2.ReportSource = null;
            cryRpt.SetParameterValue("srv", lblsrv.Text);
            cryRpt.SetParameterValue("project", (string)Session["projectname"]);
            cryRpt.SetParameterValue("BZ", _bz);
            cryRpt.SetParameterValue("FL", _fl);
            CrystalReportViewer2.ReportSource = cryRpt;
            CrystalReportViewer2.DataBind();
            Session["Report"] = cryRpt;
        }

    }
}
