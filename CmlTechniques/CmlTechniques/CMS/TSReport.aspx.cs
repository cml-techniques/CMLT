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
using System.Globalization;

namespace CmlTechniques.CMS
{
    public partial class TSReport : System.Web.UI.Page
    {
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

            }
        }
        protected void LOAD_CAS_SERVICE()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            drservices.DataSource = _objbll.Load_Prj_Service(_objdb);
            drservices.DataTextField = "PRJ_SER_NAME";
            drservices.DataValueField = "PRJ_SER_ID";
            drservices.DataBind();
            drservices.Items.Insert(0, "All Services");

        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        ReportDocument cryRpt = new ReportDocument();
        protected void Page_Unload(object sender, EventArgs e)
        {
                //cryRpt.Dispose();
                //cryRpt.Close();
        }
        private void Generate_Reports()
        {
            Generate_Rpt_Data();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsproject _objcls = new _clsproject();
            _objcls.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls, _objdb);
            
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            cryRpt.Load(Server.MapPath("Cas_TS.rpt"));
            crConnectionInfo.ServerName = "37.61.235.103";
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
            cryRpt.SetParameterValue("projectname", (string)Session["projectname"]);
            cryRpt.SetParameterValue("service",lblsrv.Text);
            cryRpt.SetParameterValue("estdate", Get_EstDate());
            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.DataBind();
            Session["Report"] = cryRpt;
        }
        private string Get_EstDate()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();
            if (drservices.SelectedItem.Text == "All Services")
                _objcls.srv = 0;
            else
                _objcls.srv = Convert.ToInt32(drservices.SelectedItem.Value);
            return _objbll.Get_Est_TSCompl_date(_objcls, _objdb);
        }
        private void Page_Init(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                lblprj.Text = Request.QueryString[0].ToString();
               lblindex.Text = Request.QueryString["idx"].ToString();

                txt_from.Text = DateTime.Now.AddMonths(-6).ToString("dd/MM/yyyy");
                LOAD_CAS_SERVICE();
                lblsrv.Text = "All Services";
                Generate_Reports();
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
        protected void btngenerate_Click(object sender, EventArgs e)
        {
            lblsrv.Text = drservices.SelectedItem.Text;
            //Generate_Rpt_Data();
            Generate_Reports();
        }
        private void Generate_Rpt_Data()
        {
            if (ValidateDate(txt_from.Text) == false)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Date')", true);
                return;
            }
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();
            //if (txt_from.Text.Length <= 0)
            //    _objcls.act_date = DateTime.Now.ToShortDateString();
            //else
            string  date= txt_from.Text.Substring(3, 2) + "/" + txt_from.Text.Substring(0, 2) + "/" + txt_from.Text.Substring(6, 4);
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ date +"')", true);
            _objcls.act_date = date;
            if (drservices.SelectedItem.Text == "All Services")
                _objcls.srv = 0;
            else
                _objcls.srv = Convert.ToInt32(drservices.SelectedItem.Value);
            _objbll.Generate_TS_Upload_Rpt(_objcls, _objdb);
        }
        private bool ValidateDate(string stringDateValue)
        {
            try
            {
                CultureInfo CultureInfoDateCulture = new CultureInfo("fr-FR");
                DateTime d = DateTime.ParseExact(stringDateValue, "dd/MM/yyyy", CultureInfoDateCulture);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
