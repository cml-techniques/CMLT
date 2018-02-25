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
    public partial class pcdComparison : System.Web.UI.Page     
    {
     
        public static DataTable _dtresult;
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }
        ReportDocument cryRpt = new ReportDocument();
        protected void Page_Unload(object sender, EventArgs e)
        {
                //cryRpt.Dispose();
                //cryRpt.Close();
        }
        private void GenerateReport()
        {

            DataSet _ds = new DataSet();
            //_ds.WriteXmlSchema(Server.MapPath("") + "\\bsummary.xml");
            

            _ds = GetRptData();


            if (lblsch.Text == "10" || lblsch.Text == "20")
            {
                cryRpt.Load(Server.MapPath("pcd_comparison1.rpt"));

            }
            else
                cryRpt.Load(Server.MapPath("pcd_comparison.rpt"));

              
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.Database.Tables[1].SetDataSource(_ds.Tables[1]);
                cryRpt.SetParameterValue("id", lblsch.Text);
           

            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.DataBind();
            Session["Report"] = cryRpt;
            ////cryRpt.Dispose();
        }

        private void Load_Filtering_Elements()
        {
            drbuilding.Items.Clear();
            drcategory.Items.Clear();
            drflevel.Items.Clear();
            drfed.Items.Clear();
            drloc.Items.Clear();
            //drprogress.Items.Clear();
            var _bzone = (from DataRow dRow in _dtresult.Rows
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
            var _fedf = (from DataRow dRow in _dtresult.Rows
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
            var _cate = (from DataRow dRow in _dtresult.Rows
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
            var _flvl = (from DataRow dRow in _dtresult.Rows
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
            var _loc = (from DataRow dRow in _dtresult.Rows
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
            var _pro = (from DataRow dRow in _dtresult.Rows
                        orderby dRow["per_com1"]
                        select new { col1 = dRow["per_com1"] }).Distinct();
            foreach (var row in _pro)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                //drprogress.Items.Add(_itm);
            }
            //drprogress.DataBind();
            drbuilding.Items.Insert(0, "All");
            drcategory.Items.Insert(0, "All");
            drflevel.Items.Insert(0, "All");
            drfed.Items.Insert(0, "All");
            drloc.Items.Insert(0, "All");
            //drprogress.Items.Insert(0, "All");

            drbuilding.SelectedValue = (string)Session["b_zone"];
            drcategory.SelectedValue = (string)Session["cate"];
            drflevel.SelectedValue = (string)Session["f_level"];
            drfed.SelectedValue = (string)Session["fed_from"];
            drloc.SelectedValue = (string)Session["loca"];
            //drprogress.SelectedValue = (string)Session["pro"];
        }
        private void Load_Master()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.prj_code = lblprj.Text;
            _objcas.sch = Convert.ToInt32(lblsch.Text);
                _objcas.sys = 0;
            _dtresult = _objbll.Load_casMain_Edit(_objcas, _objdb);
        }
        private void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblprj.Text = Request.QueryString[0].ToString();
                lblsch.Text = Request.QueryString["sch"].ToString();
                    string _sch = Request.QueryString["sch"].ToString();

                    Session["b_zone"]="All";
                    Session["cate"] = "All";
                    Session["f_level"] = "All";
                    Session["fed_from"] = "All";
                    Session["loca"] = "All";

                    Load_Master();
                    Load_Filtering_Elements();

                    GenerateReport();
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
        private DataTable loadSummary()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();

            _objcls.c_s_id = Convert.ToInt32(lblsch.Text);
            _objcls.build_id = Convert.ToInt32(lbldiv.Text);

            return _objbll.Generate_Package_Summary(_objcls, _objdb);

            // _ds.WriteXmlSchema(Server.MapPath("") + "\\barea1.xml");


        }
        private DataSet GetRptData()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_" + lblprj.Text;
  _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32(lblsch.Text);
                _objcas.b_zone = Session["b_zone"].ToString();
                _objcas.cate = Session["cate"].ToString();
                _objcas.f_level = Session["f_level"].ToString();
                _objcas.fed_from = Session["fed_from"].ToString();
                _objcas.loca = Session["loca"].ToString();

                var todaysDate = DateTime.Today;
                if (!string.IsNullOrEmpty(hdnpcd.Value))
                {
                    todaysDate = DateTime.ParseExact(hdnpcd.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                }
                _objcas.date = todaysDate;
                return _objbll.Generate_ProgressComparison_Graph(_objcas, _objdb);
            }
         
        protected void btngenerate_Click(object sender, EventArgs e)    
        {
            if (!string.IsNullOrEmpty(drbuilding.SelectedItem.Text))  Session["b_zone"] = drbuilding.SelectedItem.Text;
            if (!string.IsNullOrEmpty(drcategory.SelectedItem.Text)) Session["cate"] = drcategory.SelectedItem.Text;
            if (!string.IsNullOrEmpty(drflevel.SelectedItem.Text)) Session["f_level"] = drflevel.SelectedItem.Text;
            if (!string.IsNullOrEmpty(drfed.SelectedItem.Text)) Session["fed_from"] = drfed.SelectedItem.Text;
            if (!string.IsNullOrEmpty(drloc.SelectedItem.Text)) Session["loca"] = drloc.SelectedItem.Text;
            GenerateReport();
        }
        protected void btnback_Click(object sender, EventArgs e)    
        {
        }
    }
}
