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
    public partial class CasSheet_Summary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                lblsch.Text = _prm.Substring(0, _prm.IndexOf("_P"));
                lblprj.Text = _prm.Substring(_prm.IndexOf("_P") + 2);
                if (lblprj.Text != "CCAD")
                    filterdiv.Visible = false;
                Load_FilteringElements();
            }
        }
        private void Load_FilteringElements()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            drflvl.DataSource = _objbll.Load_Project_FloorLevel(_objdb);
            drflvl.DataTextField = "F_lvl";
            drflvl.DataValueField = "F_lvl";
            drflvl.DataBind();
            drflvl.Items.Insert(0, "ALL");
            drbzone.DataSource = _objbll.Load_Project_BZone(_objdb);
            drbzone.DataTextField = "B_Z";
            drbzone.DataValueField = "B_Z";
            drbzone.DataBind();
            drbzone.Items.Insert(0, "ALL");
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
        private void GENERATE_SUMMARY(int srv_id,string _bzone,string _flvl)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsproject _objcls1 = new _clsproject();
            _objcls1.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls1, _objdb);
            _clscassheet _objcls = new _clscassheet();
            _objcls.srv = srv_id;
            _objcls.f_level = _flvl;
            _objcls.b_zone = _bzone;
            _objdb.DBName = "DB_" + lblprj.Text;
            _objbll.GENERATE_SERVICE_SUMMARY(_objcls,_objdb);
        }
        ReportDocument cryRpt = new ReportDocument();
        protected void Page_Unload(object sender, EventArgs e)
        {
                //cryRpt.Dispose();
                //cryRpt.Close();
        }
        private void Generate_Reports(string _srv)
        {
            
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            cryRpt.Load(Server.MapPath("CasSummary.rpt"));
            //crConnectionInfo.ServerName = "213.171.197.149,49296";
            //crConnectionInfo.DatabaseName = "DBCML";
            //crConnectionInfo.UserID = "CT_User";
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
            cryRpt.SetParameterValue("srv", _srv);
            cryRpt.SetParameterValue("prj", lblprj.Text);
            cryRpt.SetParameterValue("BZONE", drbzone.SelectedItem.Text);
            cryRpt.SetParameterValue("FLVL", drflvl.SelectedItem.Text);
            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.DataBind();
            Session["Report"] = cryRpt;
        }
        protected void TimerTick(object sender, EventArgs e)
        {
            GENERATE_SUMMARY(Convert.ToInt32(lblsch.Text),"ALL","ALL");
            Generate_Reports(lblsch.Text);
            Timer1.Enabled = false;
            //imgLoader.Visible = false;
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            GENERATE_SUMMARY(Convert.ToInt32(lblsch.Text), drbzone.SelectedItem.Text,drflvl.SelectedItem.Text);
            Generate_Reports(lblsch.Text);
        }
    }
}
