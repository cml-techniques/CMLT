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

namespace CmlTechniques.CMS
{
    public partial class Summary_New : System.Web.UI.Page   
    {
        public static DataTable _dtMaster;
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
        private void Load_Master()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32(lblsch.Text);
            _objcas.prj_code = lblprj.Text;
            if (lblprj.Text == "AFV")
                _objcas.sys = Convert.ToInt32(lbldiv.Text);
            else
            _objcas.sys = 0;
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
        }

        protected void btngenerate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(drbuilding.SelectedItem.Text)) Session["zone"] = drbuilding.SelectedItem.Text;
            if (!string.IsNullOrEmpty(drcategory.SelectedItem.Text)) Session["cat"] = drcategory.SelectedItem.Text;
            if (!string.IsNullOrEmpty(drflevel.SelectedItem.Text)) Session["flvl"] = drflevel.SelectedItem.Text;
            if (!string.IsNullOrEmpty(drfed.SelectedItem.Text)) Session["fed"] = drfed.SelectedItem.Text;
            if (!string.IsNullOrEmpty(drloc.SelectedItem.Text)) Session["loc"] = drloc.SelectedItem.Text;

                if (drtype.SelectedItem.Value == "1") 
                { Generate_Graph_Summary_New(lblsch.Text, "1"); }
                else
                    Building_Summary(lblsch.Text); 

            Generate_Reports();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Clicked');", true);
        }
        private string get_project()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _clsuser _objcls = new _clsuser();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _objcls.project_code = lblprj.Text;
            return _objbll.Get_ProjectName(_objcls, _objdb);
        }
        void Generate_Graph_Summary_New(string sch_id, string mode)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.sch = Convert.ToInt32(sch_id);

            _objcls.b_zone = Session["zone"].ToString();
            _objcls.cate = Session["cat"].ToString();
            _objcls.f_level = Session["flvl"].ToString();
            _objcls.fed_from = Session["fed"].ToString();
            _objcls.loca = Session["loc"].ToString();

            _objcls.build_id = Convert.ToInt32(lbldiv.Text);
            _objcls.mode = Convert.ToInt32(mode);
            _objbll.Generate_CAS_Graph_Summary(_objcls, _objdb);
        }
        ReportDocument cryRpt = new ReportDocument();
        private void Generate_Reports()
        {
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;

                cryRpt.Load(Server.MapPath("Graph.rpt"));
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
            string _graph = "";

                _graph = "Summary - " + drtype.SelectedItem.Text;

            if ((string)Session["zone"] == null) Session["zone"] = "All";
            if ((string)Session["flvl"] == null) Session["flvl"] = "All";
            if ((string)Session["cat"] == null) Session["cat"] = "All";
            if ((string)Session["fed"] == null) Session["fed"] = "All";
            if ((string)Session["loc"] == null) Session["loc"] = "All";
            string _name = lblsch.Text;


            if (lblprj.Text == "SRH" && (lblsch.Text == "25" || lblsch.Text == "26"))
            {
                _name = lblsch.Text + "_" + lblprj.Text;
            }


            cryRpt.SetParameterValue("name", _name);
            cryRpt.SetParameterValue("project", get_project());
            cryRpt.SetParameterValue("data_title", Get_Title());
            cryRpt.SetParameterValue("graph", _graph);
            cryRpt.SetParameterValue("bz", (string)Session["zone"]);
            cryRpt.SetParameterValue("cat", (string)Session["cat"]);
            cryRpt.SetParameterValue("fl", (string)Session["flvl"]);
            cryRpt.SetParameterValue("ff", (string)Session["fed"]);
            cryRpt.SetParameterValue("lo", (string)Session["loc"]);
            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.DataBind();
            Session["Report"] = cryRpt;
        }
        private void Page_Init(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                lblsch.Text = Request.QueryString["Id"].ToString();
                lblprj.Text = Request.QueryString["Prj"].ToString();
                lbldiv.Text = "0";

                if ((Request.QueryString["div"] != null)){
                    lbldiv.Text = Request.QueryString["div"].ToString();
                }

                lblsch1.Text = lblsch.Text;
  
                Load_Master();
                Session["filter"] = "no";
                Session["zone"] = "All";
                Session["flvl"] = "All";
                Session["cat"] = "All";
                Session["fed"] = "All";
                Session["loc"] = "All";

                Load_Filtering_Elements();


               Generate_Graph_Summary_New(lblsch.Text, "1");
                Generate_Reports();
                //if (lbldiv.Text == "0") tdback.Visible = false;

              if( Request.QueryString["Type"].ToString()=="0") tdback.Visible = false;

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
        private void Load_Filtering_Elements()
        {
            var _bzone = (from DataRow dRow in _dtMaster.Rows
                          orderby dRow["B_Z"]
                          select new { col1 = dRow["B_Z"] }).Distinct();
            foreach (var row in _bzone)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drbuilding.Items.Add(_itm);
            }
            drbuilding.DataBind();
            var _fedf = (from DataRow dRow in _dtMaster.Rows
                         orderby dRow["F_from"]
                         select new { col1 = dRow["F_from"] }).Distinct();
            foreach (var row in _fedf)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drfed.Items.Add(_itm);
            }
            drfed.DataBind();
            var _cate = (from DataRow dRow in _dtMaster.Rows
                         orderby dRow["Cat"]
                         select new { col1 = dRow["Cat"] }).Distinct();
            foreach (var row in _cate)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drcategory.Items.Add(_itm);
            }
            drcategory.DataBind();
            var _flvl = (from DataRow dRow in _dtMaster.Rows
                         orderby dRow["F_lvl"]
                         select new { col1 = dRow["F_lvl"] }).Distinct();
            foreach (var row in _flvl)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drflevel.Items.Add(_itm);
            }
            drflevel.DataBind();
            var _loc = (from DataRow dRow in _dtMaster.Rows
                        orderby dRow["Loc"]
                        select new { col1 = dRow["Loc"] }).Distinct();
            foreach (var row in _loc)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drloc.Items.Add(_itm);
            }
            drloc.DataBind();
            drbuilding.Items.Insert(0, "All");
            drcategory.Items.Insert(0, "All");
            drflevel.Items.Insert(0, "All");
            drfed.Items.Insert(0, "All");
            drloc.Items.Insert(0, "All");
            drbuilding.SelectedValue = (string)Session["zone"];
            drcategory.SelectedValue = (string)Session["cat"];
            drflevel.SelectedValue = (string)Session["flvl"];
            drfed.SelectedValue = (string)Session["fed"];
            drloc.SelectedValue = (string)Session["loc"];
        }
        
        protected void TimerTick(object sender, EventArgs e)
        {
        }

        private string Get_Title()
        {
            if (drtype.SelectedItem.Value == "2")
                return "BUILDINGS";
            else
            {
                    if (lblsch1.Text == "1" || lblsch1.Text == "2" || lblsch1.Text == "3" || (string)Session["sch"] == "4" || lblsch1.Text == "5" || lblsch1.Text == "6" || lblsch1.Text == "8" || lblsch1.Text == "9" || lblsch1.Text == "21" || (string)Session["sch"] == "17" || lblsch1.Text == "18" || lblsch1.Text == "19")
                        return "SYSTEMS";
                    else
                        return "TESTS";
                }
        }

        private bool IsNumeric(object Expression)
        {
            // Variable to collect the Return value of the TryParse method.
            bool isNum;

            // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
            double retNum;

            // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
            // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }


        private void Building_Summary(string sch_id)
        {
            try
            {
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _clscassheet _objcls = new _clscassheet();
                _objdb.DBName = "DB_" + lblprj.Text;
                _objcls.sch = Convert.ToInt32(sch_id);
                _objcls.b_zone = drbuilding.SelectedItem.Text;
                _objcls.cate = drcategory.SelectedItem.Text;
                _objcls.f_level = drflevel.SelectedItem.Text;
                _objcls.fed_from = drfed.SelectedItem.Text;
                _objcls.loca = drloc.SelectedItem.Text;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                DataTable _dt = _objbll.Generate_Bldg_Rpt(_objcls, _objdb);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("cmsreports.aspx?idx=1&prj=" + lblprj.Text);
        }
      
    }
}
