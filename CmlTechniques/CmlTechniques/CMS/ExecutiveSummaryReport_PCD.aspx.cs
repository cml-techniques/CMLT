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

namespace CmlTechniques
{
    public partial class ExecutiveSummaryReport_PCD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{

            //    _ReadCookies();
            //    lblprj.Text = Request.QueryString["prj"].ToString();
            //    LoadServiceType();

            //    txtdatefrom.Text = (DateTime.Today.AddMonths(-3)).ToString("dd/MM/yyyy");
            //    txtdateto.Text = (DateTime.Today.AddMonths(2)).ToString("dd/MM/yyyy");

            //    hdnpcdfrom.Value = txtdatefrom.Text;
            //    hdnpcdto.Value = txtdateto.Text;

            //    Generate_Project_Summary_Overall_Pcd();

            //    Generate_Reports();
            //}

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
        protected void btnback_Click(object sender, EventArgs e)
        {
            string _url = "cmsreports.aspx?idx=1&prj=" + lblprj.Text;
            Response.Redirect(_url);
        }
        protected void btngenerate_Click(object sender, EventArgs e)
        {
            Generate_Project_Summary_Overall_Pcd();
            Generate_Reports();
        }
        private void Generate_Project_Summary_Overall_Pcd()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;

            _clscassheet _objcls = new _clscassheet();
            _clsManageTree _objcls1 = new _clsManageTree();

            _objcls.mode = Convert.ToInt32(ddltype.SelectedValue);


            var todaysDate = DateTime.Today;
            if (!string.IsNullOrEmpty(hdnpcdfrom.Value))
            {
                todaysDate = DateTime.ParseExact(hdnpcdfrom.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            var todaysDate1 = DateTime.Today;
            if (!string.IsNullOrEmpty(hdnpcdto.Value))
            {
                todaysDate1 = DateTime.ParseExact(hdnpcdto.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            _objcls.dtastart = todaysDate;
            _objcls.dtpstart = todaysDate1;
            _objcls.cate = ddlService.SelectedValue;
            //_objbll.Get_Executive_Summary_pcd(_objcls, _objdb);
            _objbll.Get_Total_Executive_Summary(_objcls, _objdb);

        }
        ReportDocument cryRpt = new ReportDocument();
        protected void Page_Unload(object sender, EventArgs e)
        {
                //cryRpt.Dispose();
                //cryRpt.Close();
        }
        private void Generate_Reports()
        {
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;


                var todaysDate = DateTime.Today;
                if (!string.IsNullOrEmpty(hdnpcdfrom.Value))
                {
                    todaysDate = DateTime.ParseExact(hdnpcdfrom.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                var todaysDate1 = DateTime.Today;
                if (!string.IsNullOrEmpty(hdnpcdto.Value))
                {
                    todaysDate1 = DateTime.ParseExact(hdnpcdto.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }

                cryRpt.Load(Server.MapPath("Executive_Sumary_PCD.rpt"));
                //C:\Users\Joseph\Documents\Visual Studio 2008\Projects\TestCML\Techniques\TestTechniques\ProjectSummary_testing.rpt
                             
            crConnectionInfo.ServerName = Constants.CMLTConstants.serverName;
            crConnectionInfo.DatabaseName = Constants.CMLTConstants.dbName;
            crConnectionInfo.UserID = Constants.CMLTConstants.dbUserName;
            crConnectionInfo.Password = Constants.CMLTConstants.dbPassword;
            cryRpt.SetDatabaseLogon(crConnectionInfo.UserID, crConnectionInfo.Password, crConnectionInfo.ServerName, crConnectionInfo.DatabaseName);
            cryRpt.VerifyDatabase();            
            CrTables = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
            CrystalReportViewer2.ReportSource = null;           
            cryRpt.SetParameterValue("project", (string)Session["projectname"]);
            cryRpt.SetParameterValue("DateFrom", todaysDate);
            cryRpt.SetParameterValue("DateTo", todaysDate1);
            cryRpt.SetParameterValue("ServiceType", ddlService.SelectedValue);
            CrystalReportViewer2.ReportSource = cryRpt;
            CrystalReportViewer2.DataBind();
            Session["Report"] = cryRpt;
        }
        private void LoadServiceType()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            ddlService.DataSource = _objbll.Load_Prj_Service(_objdb);
            ddlService.DataTextField = "PRJ_SER_NAME";
            ddlService.DataValueField = "PRJ_SER_NAME";
            ddlService.DataBind();
            ddlService.Items.Insert(0,"Overall");
            ddlService.Items.FindByValue("Overall").Selected = true;
        }
        protected void ddltype_SelectedIndexChanged(Object sender, EventArgs e)
        { 
            if (ddltype.SelectedItem.Value == "2")
            {
                txtdatefrom.Text = (DateTime.Today.AddMonths(-6)).ToString("dd/MM/yyyy");
                txtdateto.Text = (DateTime.Today.AddMonths(6)).ToString("dd/MM/yyyy");
            }
            else if (ddltype.SelectedItem.Value == "3")
            {
                txtdatefrom.Text = (DateTime.Today.AddYears(-2)).ToString("dd/MM/yyyy");
                txtdateto.Text = (DateTime.Today.AddYears(2)).ToString("dd/MM/yyyy");
            }
            else if (ddltype.SelectedItem.Value == "1")
            {
                txtdatefrom.Text = (DateTime.Today.AddMonths(-3)).ToString("dd/MM/yyyy");
                txtdateto.Text = (DateTime.Today.AddMonths(2)).ToString("dd/MM/yyyy");            
            }
            hdnpcdfrom.Value = txtdatefrom.Text;
            hdnpcdto.Value = txtdateto.Text;

            Generate_Project_Summary_Overall_Pcd();

            Generate_Reports();
        }
        private void Page_Init(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!Page.IsPostBack)
            {

                _ReadCookies();
                lblprj.Text = Request.QueryString["prj"].ToString();
                LoadServiceType();

                txtdatefrom.Text = (DateTime.Today.AddMonths(-3)).ToString("dd/MM/yyyy");
                txtdateto.Text = (DateTime.Today.AddMonths(2)).ToString("dd/MM/yyyy");

                hdnpcdfrom.Value = txtdatefrom.Text;
                hdnpcdto.Value = txtdateto.Text;

                Generate_Project_Summary_Overall_Pcd();

                Generate_Reports();
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
