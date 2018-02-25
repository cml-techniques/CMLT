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
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using BusinessLogic;
using App_Properties;

namespace CmlTechniques.CasSheet
{
    public partial class Package_Summary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                lblprj.Text = _prm.Substring(_prm.IndexOf("_P") + 2);
            }
        }
        protected void TimerTick(object sender, EventArgs e)
        {
            string _prm = Request.QueryString[0].ToString();
            string _sch = _prm.Substring(0, _prm.IndexOf("_P"));
            GENERATE_SUMMARY(Convert.ToInt32(_sch));
            Generate_Reports(_sch);
            Timer1.Enabled = false;
            imgLoader.Visible = false;
        }
        private void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
        private void GENERATE_SUMMARY(int sch_id)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsproject _objcls1 = new _clsproject();
            _objcls1.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls1, _objdb);
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.sch = sch_id;
            _objbll.GENERATE_PACKAGE_SUMMARY(_objcls, _objdb);
        }
        ReportDocument cryRpt = new ReportDocument();
        protected void Page_Unload(object sender, EventArgs e)
        {
                //cryRpt.Dispose();
                //cryRpt.Close();
        }
        private void Generate_Reports(string _sch)
        {

            
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            cryRpt.Load(Server.MapPath("PackageSummary.rpt"));
            //crConnectionInfo.ServerName = "213.171.197.149,49296";
            //crConnectionInfo.DatabaseName = "DBCML";
            //crConnectionInfo.UserID = "CT_user";
            //crConnectionInfo.Password = "CTplus#2016";
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
            cryRpt.SetParameterValue("srv", _sch);
            cryRpt.SetParameterValue("prj", lblprj.Text);
            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.DataBind();
            Session["Report"] = cryRpt;
        }
    }
}
