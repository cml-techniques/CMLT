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
using BusinessLogic;
using App_Properties;

namespace CmlTechniques.CMS
{
    public partial class Doc_Summary : System.Web.UI.Page
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
        private void Generate_Reports()
        {
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
          

            if (lblprj.Text == "HMIM" || lblprj.Text == "ABS")
            {
                cryRpt.Load(Server.MapPath("ms_summary1.rpt"));
                cryRpt.SetParameterValue("bldng", "BUILDING : " + (string)Session["building"]);
            }
            else
                cryRpt.Load(Server.MapPath("ms_summary.rpt"));

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
            //string _parm = Request.QueryString[0].ToString();
            //string _nos = _parm.Substring(3);
            //string _type = _parm.Substring(0,2);



            cryRpt.SetParameterValue("srv", (string)Session["srv"]);
            cryRpt.SetParameterValue("project", (string)Session["projectname"]);
            cryRpt.SetParameterValue("total", lbltotal.Text);
            cryRpt.SetParameterValue("type", lbltype.Text);
            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.DataBind();
            Session["Report"] = cryRpt;
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

            }
        }
        private void Page_Init(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                lblprj.Text = (string)Session["project"];
                lblindex.Text = Request.QueryString["idx"].ToString();

                string _parm = Request.QueryString[0].ToString();
                lbltotal.Text = _parm.Substring(3);
               lbltype.Text= _parm.Substring(0, 2);


                Generate_Reports();



                if (lblprj.Text=="HMIM" || lblprj.Text == "ABS")
                {
                    lbltdservice.Visible = true;
                   ddtdservice.Visible = true;
                   btntdview.Visible = true;

                   Load_Service(lblprj.Text);

                }

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

        protected void btnback_Click(object sender, EventArgs e)
        {
            string _url = "cmsreports.aspx?idx=" + lblindex.Text + "&prj=" + lblprj.Text;
            Response.Redirect(_url);
        }
        void Ms_summaryAll()
        {
            Session["srv"] = "ALL";

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsdocument _objcls = new _clsdocument();
            _objdb.DBName = "DBCML";
            _clsproject _objcls1 = new _clsproject();
            _objcls1.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls1, _objdb);
            _objbll.Clear_MSSummary(_objdb);
            _objdb.DBName = "DB_" + lblprj.Text;
            DataTable _dtable = _objbll.Load_MSStatus(_objdb);
            var _status = from _data in _dtable.AsEnumerable()
                          select _data;
            foreach (var row in _status)
            {
                _objcls.status = row[0].ToString();
                //_objcls.schid = Convert.ToInt32(rd_Building.SelectedItem.Value);
                _objcls.schid = Convert.ToInt32(Request.QueryString["Div"].ToString());
                _objbll.Generate_MS_Summary_ALL_Div(_objcls, _objdb);
            }

            _objcls.status = "1";
            //_objcls.schid = Convert.ToInt32(rd_Building.SelectedItem.Value);
            _objcls.schid = Convert.ToInt32(Request.QueryString["Div"].ToString());
            _objbll.Generate_MS_Summary_ALL_Div(_objcls, _objdb);
        }
            protected void btnmsdview_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(drservices.SelectedItem.Value) == 0 || drservices.SelectedItem.Text == "All")
            {
                Ms_summaryAll();

            }
            else
            {

                Session["srv"] = drservices.SelectedItem.Text;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _clsdocument _objcls = new _clsdocument();
                _objdb.DBName = "DBCML";
                _clsproject _objcls1 = new _clsproject();
                _objcls1.prjcode = lblprj.Text;
                _objbll.Update_RPTLogo(_objcls1, _objdb);
                _objbll.Clear_MSSummary(_objdb);
                _objdb.DBName = "DB_" + lblprj.Text;
                DataTable _dtable = _objbll.Load_MSStatus(_objdb);
                var _status = from _data in _dtable.AsEnumerable()
                              select _data;
                foreach (var row in _status)
                {
                    _objcls.doc_id = Convert.ToInt32(drservices.SelectedItem.Value);
                    _objcls.status = row[0].ToString();

                    if (lblprj.Text == "HMIM" || lblprj.Text == "ABS")
                    {
                        _objcls.schid = Convert.ToInt32(Request.QueryString["Div"].ToString());
                        _objbll.Generate_MS_Summary_Div(_objcls, _objdb);

                        lbltotal.Text = GetDocNo_All();

                    }
                    else
                        _objbll.Generate_MS_Summary(_objcls, _objdb);
                }
                _objcls.doc_id = Convert.ToInt32(drservices.SelectedItem.Value);
                //if (lblprj.Text == "12761")
                //{
                //    _objcls.status = "-1";
                //    _objbll.Generate_MS_Summary(_objcls, _objdb);
                //}

                _objcls.status = "1";

                if (lblprj.Text == "HMIM" || lblprj.Text == "ABS")
                {
                    _objbll.Generate_MS_Summary_ALL_Div(_objcls, _objdb);
                }
                else
                    _objbll.Generate_MS_Summary(_objcls, _objdb);


            }


            Generate_Reports();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + dr_msservice.SelectedItem.Value + "');", true);
        }
        private void Load_Service(string _prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + _prj;
            DataTable _dtserMs = _objbll.Load_Prj_Service_MS(_objdb);

            drservices.DataSource = _dtserMs;
            drservices.DataTextField = "PRJ_SER_NAME";
            drservices.DataValueField = "PRJ_SER_ID";
            drservices.DataBind();

            ListItem lst = new ListItem("All", "0");

            drservices.Items.Insert(0,lst);

        }
        private string GetDocNo_All()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _clscassheet _objcls = new _clscassheet();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.srv = Convert.ToInt32(drservices.SelectedItem.Value);
            _objcls.build_id = Convert.ToInt32(Request.QueryString["Div"].ToString());
            return _objbll.Get_Get_MsDoc_No_ALL_Div(_objcls, _objdb).ToString();
        }
      
    }
}
