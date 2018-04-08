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
using System.IO;
using System.Drawing;

namespace CmlTechniques.CMS
{
    public partial class Reports : System.Web.UI.Page
    {
        ReportDocument cryRpt = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
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
        private void Generate_Reports(string _rpt)
        {
            bool _isNewProject = (Array.IndexOf(Constants.CMLTConstants.recentProjects, lblprj.Text) > -1) ? true : false;
            bool _hasBuilding = (Array.IndexOf(Constants.CMLTConstants.hasBuilding, lblprj.Text) > -1) ? true : false;
            
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsproject _objcls1 = new _clsproject();
            _objcls1.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls1, _objdb);
            _objdb.DBName ="DB_" + lblprj.Text;
            if (_rpt == "dr")
            {
                //string _path = "../images/" + lblprj.Text + "logo.jpg";
                //FileStream fs = new FileStream(Server.MapPath(_path), FileMode.Open, FileAccess.Read);
                //BinaryReader br = new BinaryReader(fs);
                //byte[] _image = br.ReadBytes((int)fs.Length);
                //br.Close();
                //fs.Close();
                _clsdocreview _objcls = new _clsdocreview();
                _objcls.project_code = (string)Session["projectname"];
                _objcls.dr_id = Convert.ToInt32(lblid.Text);
                _objbll.Generate_DRReport(_objcls, _objdb);
                if(lblprj.Text=="14211")
                    cryRpt.Load(Server.MapPath("drreport_kaia.rpt"));
                if (lblprj.Text == "ARSD")
                        cryRpt.Load(Server.MapPath("drdetails_svd.rpt"));
                else if (_isNewProject)
                    cryRpt.Load(Server.MapPath("drView.rpt"));
                else
                    cryRpt.Load(Server.MapPath("drreport.rpt"));
            }
            else if (_rpt == "so")
            {
                _clsSO _objcls = new _clsSO();
                _objcls.project_code = (string)Session["projectname"];
                _objcls.so_id = Convert.ToInt32(lblid.Text);
                _objbll.Generate_SOReport(_objcls, _objdb);
                Generate_SOIMG();
                if (lblprj.Text == "14211")
                    cryRpt.Load(Server.MapPath("soreport_kaia.rpt"));
                else if (lblprj.Text == "ARSD")
                        cryRpt.Load(Server.MapPath("sodetails_svd.rpt"));
                else if (_isNewProject)
                    cryRpt.Load(Server.MapPath("soreport_new.rpt"));
                else
                    cryRpt.Load(Server.MapPath("soreport.rpt"));
            }
            else if (_rpt == "pr")
            {
                _objdb.DBName = "DBCML";
                _objdb.Dataname = "DB_" + lblprj.Text;
                _objdb.project = (string)Session["projectname"];
                _objbll.Generate_PRG_RPT( _objdb);
                cryRpt.Load(Server.MapPath("cpms_report.rpt"));
            }
            else if (_rpt == "dlog1")
            {
                _objdb.DBName = "DB_" + lblprj.Text;
                _objdb.rpt = 0;
                _objdb.Logname = "";
                _objbll.Generate_DR_SO_RPT(_objdb);
                if (lblprj.Text == "14211")
                    cryRpt.Load(Server.MapPath("drso_kaia.rpt"));
                else
                    cryRpt.Load(Server.MapPath("drso.rpt"));
                cryRpt.SetParameterValue("service", "All");
                cryRpt.SetParameterValue("rev", "All");
                cryRpt.SetParameterValue("iss", "All");
                cryRpt.SetParameterValue("sts", "All");
                cryRpt.SetParameterValue("project", (string)Session["projectname"]);
            }
            else if (_rpt == "dlog")
            {
                mydiv.Visible = false;
                _objdb.DBName = "DB_" + lblprj.Text;
                if (lblprj.Text == "BNGA")
                    _objdb.rpt = 2;
                else
                    _objdb.rpt = 0;
                _objdb.Logname = lblid.Text;
                _objbll.Generate_DR_SO_RPT(_objdb);
                if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("drso_kaia.rpt"));
                    SelectionFormula(cryRpt, (string)Session["fsrv"], (string)Session["frev"], (string)Session["fiss"], (string)Session["fsts"]);
                }
                else if (_isNewProject)
                {
                    cryRpt.Load(Server.MapPath("drLog_New.rpt"));
                    cryRpt.SetParameterValue("building", (string)Session["fbui"]);
                    SelectFormulaWithBuilding(cryRpt, (string)Session["fsrv"], (string)Session["frev"], (string)Session["fiss"], (string)Session["fsts"], (string)Session["fbui"]);
                }
                else if (lblprj.Text == "ARSD")
                {
                    cryRpt.Load(Server.MapPath("drsolog_svd.rpt"));
                    SelectionFormula(cryRpt, (string)Session["fsrv"], (string)Session["frev"], (string)Session["fiss"], (string)Session["fsts"]);
                }
                else
                {
                    cryRpt.Load(Server.MapPath("drso.rpt"));
                    SelectionFormula(cryRpt, (string)Session["fsrv"], (string)Session["frev"], (string)Session["fiss"], (string)Session["fsts"]);
                }
                cryRpt.SetParameterValue("service", (string)Session["fsrv"]);
                cryRpt.SetParameterValue("rev", (string)Session["frev"]);
                cryRpt.SetParameterValue("iss", (string)Session["fiss"]);
                cryRpt.SetParameterValue("sts", (string)Session["fsts"]);
                cryRpt.SetParameterValue("project", (string)Session["projectname"]);
                
            }
            else if (_rpt == "som")
            {
                _objdb.DBName = "DB_" + lblprj.Text;
                _objdb.rpt = 1;
                _objdb.Logname = "";
                _objbll.Generate_DR_SO_RPT(_objdb);
                cryRpt.Load(Server.MapPath("drso.rpt"));
                cryRpt.SetParameterValue("service", "All");
                cryRpt.SetParameterValue("rev", "All");
                cryRpt.SetParameterValue("iss", "All");
                cryRpt.SetParameterValue("sts", "All");
                cryRpt.SetParameterValue("project", (string)Session["projectname"]);
            }
            else if (_rpt == "cmtlogdr")
            {
                mydiv.Visible = false;

                _clsSO _objcls = new _clsSO();
                _objcls.mode = 0;
                DataSet ds = new DataSet();
                ds = _objbll.Load_DR_SO_CommentLog(_objcls, _objdb);
                cryRpt.Load(Server.MapPath("drCommentLog.rpt"));

                cryRpt.Database.Tables["DR_CMMNT_RPT"].SetDataSource(ds.Tables[0]);

                cryRpt.Subreports[0].Database.Tables[0].SetDataSource(ds.Tables[1]);

                cryRpt.SetParameterValue("project", (string)Session["projectname"]);



            }

            else if (_rpt == "socmtlog")
            {
                mydiv.Visible = false;

                _clsSO _objcls = new _clsSO();
                _objcls.mode = (_rpt == "socmtlog" ? 1 : 0);
                DataSet ds = new DataSet();
                ds = _objbll.Load_DR_SO_CommentLog(_objcls, _objdb);


                ds.Tables[1].Columns.Add("Image", typeof(byte[]));
                FileStream fs;
                BinaryReader br;
                byte[] _image;

                //int ins=0;
                for (int ins = 0; ins <= ds.Tables[1].Rows.Count - 1; ins += 1)
                {
                    string _path = ds.Tables[1].Rows[ins]["Photo"].ToString();

                    if (string.IsNullOrEmpty(_path)) continue;
                    fs = new FileStream(Server.MapPath(_path), FileMode.Open, FileAccess.Read);
                    br = new BinaryReader(fs);
                    _image = br.ReadBytes((int)fs.Length);

                    ds.Tables[1].Rows[ins]["Image"] = _image;

                    ds.Tables[1].AcceptChanges();

                }


                cryRpt.Load(Server.MapPath("SoCommentLog.rpt"));

                cryRpt.Database.Tables["SO_CMMNT_RPT"].SetDataSource(ds.Tables[0]);

                cryRpt.Subreports[0].Database.Tables[0].SetDataSource(ds.Tables[1]);
                //cryRpt.Subreports[1].Database.Tables[0].SetDataSource(ds.Tables[2]);
                cryRpt.SetParameterValue("project", (string)Session["projectname"]);
            }
            else if (_rpt == "som1")
            {
                mydiv.Visible = false;
                _objdb.DBName = "DB_" + lblprj.Text;
                _objdb.rpt = 1;
                _objdb.Logname = "";
                _objbll.Generate_DR_SO_RPT(_objdb);
                if (lblprj.Text == "14211")
                    cryRpt.Load(Server.MapPath("drso_kaia.rpt"));
                else if (_isNewProject && _hasBuilding)
                {
                    DataSet _ds = new DataSet();
                    DataTable _dt = GetData();
                    _ds.Tables.Add(_dt);
                    //_ds.WriteXmlSchema(Server.MapPath("") + "\\soreport.xml");
                    cryRpt.Load(Server.MapPath("SO_New.rpt"));
                    cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                    cryRpt.SetParameterValue("building", (string)Session["fbui"]);
                }
                else if (lblprj.Text == "ARSD")
                        cryRpt.Load(Server.MapPath("drsolog_svd.rpt"));
                else
                    cryRpt.Load(Server.MapPath("drso.rpt"));
                cryRpt.SetParameterValue("service", (string)Session["fsrv"]);
                cryRpt.SetParameterValue("rev", (string)Session["frev"]);
                cryRpt.SetParameterValue("iss", (string)Session["fiss"]);
                cryRpt.SetParameterValue("sts", (string)Session["fsts"]);
                cryRpt.SetParameterValue("project", (string)Session["projectname"]);

                if (_isNewProject && _hasBuilding)
                {
                    SelectionFormula_New(cryRpt, (string)Session["fsrv"], (string)Session["frev"], (string)Session["fiss"], (string)Session["fsts"], (string)Session["fbui"]);
                }
                else
                    SelectionFormula(cryRpt, (string)Session["fsrv"], (string)Session["frev"], (string)Session["fiss"], (string)Session["fsts"]);
            }
            else if (_rpt == "uso")
            {
                mydiv.Visible = false;
                _objdb.DBName = "DB_" + lblprj.Text;
                _objdb.rpt = 1;
                _objbll.Generate_DR_SO_RPT(_objdb);
                cryRpt.Load(Server.MapPath("uso_log.rpt"));
            }
            else if (_rpt == "cp")
            {
                _objdb.DBName = "DBCML";
                _objdb.Dataname = "DB_" + lblprj.Text;
                _objdb.project = (string)Session["projectname"];
                _objbll.Generate_CP_RPT(_objdb);
                cryRpt.Load(Server.MapPath("cpms_report.rpt"));
                //cryRpt.Load(Server.MapPath("comment_rpt.rpt"));
                //cryRpt.SetParameterValue("project", (string)Session["projectname"]);
            }
            else if (_rpt == "msc")
            {
                _objdb.DBName = "DB_" + lblprj.Text;
                if (lblprj.Text == "HMIM")
                {
                    _clscassheet _objcls = new _clscassheet();
                    _objcls.build_id = Convert.ToInt32(Session["building_id"].ToString());
                    _objbll.Gen_MSComment_Rpt(_objcls, _objdb);
                    cryRpt.Load(Server.MapPath("ms_comments_rpt 1.rpt"));
                    cryRpt.SetParameterValue("bldng", "BUILDING : " + (string)Session["building"]);
                }
                else
                {
                    _objbll.Gen_MSComment_Rpt(_objdb);
                    cryRpt.Load(Server.MapPath("ms_comments_rpt.rpt"));
                }
                cryRpt.SetParameterValue("project", (string)Session["projectname"]);
                cryRpt.SetParameterValue("ser", drservices.SelectedItem.Text);
                cryRpt.SetParameterValue("sys", drpackages.SelectedItem.Text);
                cryRpt.SetParameterValue("typ", drtype.SelectedItem.Text);
                MSC_SelectionFormula(cryRpt, drservices.SelectedItem.Text, drpackages.SelectedItem.Text, drtype.SelectedItem.Text);
            }
            else if (_rpt == "msr")
            {
                mydiv.Visible = false;
                //if (lblprj.Text == "12761")
                //    cryRpt.Load(Server.MapPath("ms_schedule_summary1.rpt"));
                //else
                    cryRpt.Load(Server.MapPath("ms_schedule_summary2.rpt"));
                cryRpt.SetParameterValue("project", (string)Session["projectname"]);
                cryRpt.SetParameterValue("srv", (string)Session["srv"]);
                cryRpt.SetParameterValue("sys", (string)Session["sys"]);
                cryRpt.SetParameterValue("typ", (string)Session["typ"]);
                cryRpt.SetParameterValue("sts", (string)Session["sts"]);
                
                
            }
            else if (_rpt == "mss")
            {
                //_objdb.DBName = "DB_" + lblprj.Text;
                //_objbll.Gen_MS_Schedule_Summary(_objdb);
                mydiv.Visible = false;
                if (lblprj.Text == "12761")
                    cryRpt.Load(Server.MapPath("ms_schedule_summary1.rpt"));

                else if (lblprj.Text == "HMIM" || lblprj.Text == "ABS")
                {
                    cryRpt.Load(Server.MapPath("ms_schedule_summary3.rpt"));
                    cryRpt.SetParameterValue("bldng", (string)Session["building"]);
                }
                else
                    cryRpt.Load(Server.MapPath("ms_schedule_summary.rpt"));
                cryRpt.SetParameterValue("project", (string)Session["projectname"]);
                cryRpt.SetParameterValue("srv", (string)Session["srv"]);
                cryRpt.SetParameterValue("sys", (string)Session["sys"]);
                cryRpt.SetParameterValue("typ", (string)Session["typ"]);
                cryRpt.SetParameterValue("sts", (string)Session["sts"]);
                MSS_SelectionFormula(cryRpt, (string)Session["srv"], (string)Session["sys"], (string)Session["typ"], (string)Session["sts"]);
            }
            else if (_rpt == "doc_comm")
            {
                mydiv.Visible = false;
                cryRpt.Load(Server.MapPath("comment_rpt.rpt"));
                cryRpt.SetParameterValue("project", (string)Session["projectname"]);
            }
            else if (_rpt == "cas")
            {
                _objdb.DBName = "DBCML";
                _objdb.Dataname = "DB_" + lblprj.Text;
                _objdb.photo_rpt = null;
                _objdb.project = (string)Session["projectname"];
                _objdb.Datapath = lblprj.Text;
                _objdb.rpt = Convert.ToInt32((string)Session["sch_id"]);
                _objdb.cas = (string)Session["sch_id"];
                _objbll.Generate_CAS_RPT(_objdb);
               // _objbll.CAS_PKG_SUM_RPT(_objdb);
                if((string)Session["sch_id"]=="1" || (string)Session["sch_id"]=="5")
                    cryRpt.Load(Server.MapPath("cas_lv.rpt"));
                else if((string)Session["sch_id"]=="2")
                    cryRpt.Load(Server.MapPath("cas_mv.rpt"));
                else if ((string)Session["sch_id"] == "3")
                    cryRpt.Load(Server.MapPath("cas_tx.rpt"));
                else if((string)Session["sch_id"]=="6")
                    cryRpt.Load(Server.MapPath("cas_e_l.rpt"));
                else if ((string)Session["sch_id"] == "8")
                    cryRpt.Load(Server.MapPath("cas_mec.rpt"));
                else if ((string)Session["sch_id"] == "17")
                    cryRpt.Load(Server.MapPath("cas_ph1.rpt"));
                else if ((string)Session["sch_id"] == "18")
                    cryRpt.Load(Server.MapPath("cas_ph2.rpt"));
                else if ((string)Session["sch_id"] == "19")
                    cryRpt.Load(Server.MapPath("cas_ph3.rpt"));
                else if ((string)Session["sch_id"] == "20")
                    cryRpt.Load(Server.MapPath("cas_bms.rpt"));
                cryRpt.SetParameterValue("bz", "All");
                cryRpt.SetParameterValue("cat", "All");
                cryRpt.SetParameterValue("fl", "All");
                cryRpt.SetParameterValue("ff", "All");
            }
            else if (_rpt == "ams")
            {
                cryRpt.Load(Server.MapPath("../AMS/tasklist.rpt"));
               
            }
            else if (_rpt == "SODR_PDF")
            {
                mydiv.Visible = false;
                _objdb.DBName = "DB_" + lblprj.Text;

                if (!String.IsNullOrEmpty(Request.QueryString["dtype"]))
                {
                     _objdb.rpt  = Convert.ToInt16(Request.QueryString["dtype"].ToString());
                }                 
                _objdb.Logname = lblid.Text;
                _objbll.Generate_DR_SO_RPT_PDF(_objdb);

                cryRpt.Load(Server.MapPath("drso_pdf.rpt"));
                 SelectionFormula(cryRpt, (string)Session["fsrv"], (string)Session["frev"], (string)Session["fiss"], (string)Session["fsts"]);

                cryRpt.SetParameterValue("service", (string)Session["fsrv"]);
                cryRpt.SetParameterValue("rev", (string)Session["frev"]);
                cryRpt.SetParameterValue("iss", (string)Session["fiss"]);
                cryRpt.SetParameterValue("sts", (string)Session["fsts"]);
                cryRpt.SetParameterValue("project", (string)Session["projectname"]);

            }
           

            if (_rpt != "som1" || lblprj.Text != "HMIM")
            {

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
            }

            //CrystalReportViewer1.ParameterFieldInfo = paramFields; 
            
         
            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.DataBind();

          

            //CrystalReportViewer1.RefreshReport();
            //CrystalReportViewer1.PageZoomFactor = 200;
            Session["Report"] = cryRpt;

            _clsuser _cls = new _clsuser();
            _cls.uid = (string)Session["uid"];
            _cls.project_code = lblprj.Text;
            _cls.mode = 2;
            _objdb.DBName = "DBCML";
            string _access = _objbll.Get_CMSAccess(_cls, _objdb);

            if (_access == "Read Only")
            { CrystalReportViewer1.HasExportButton = false; }

        }
        private DataTable GetData()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            return _objbll.Load_SO_Report(_objdb);
        }
        private void Generate_Reports1(string _rpt) 
        {
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsproject _objcls1 = new _clsproject();
            _objcls1.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls1, _objdb);
            
           
             if (_rpt == "msr")
            {
                mydiv.Visible = false;
                //if (lblprj.Text == "12761")
                //    cryRpt.Load(Server.MapPath("ms_schedule_summary1.rpt"));
                //else
                cryRpt.Load(Server.MapPath("ms_schedule_summary2.rpt"));
                cryRpt.SetParameterValue("project", (string)Session["projectname"]);
                cryRpt.SetParameterValue("srv", (string)Session["srv"]);
                cryRpt.SetParameterValue("sys", (string)Session["sys"]);
                cryRpt.SetParameterValue("sts", (string)Session["sts"]);
            }
            
            crConnectionInfo.ServerName = "37.61.235.103";
            crConnectionInfo.DatabaseName = "DB_" + lblprj.Text;
            crConnectionInfo.UserID = "sa";
            crConnectionInfo.Password = "vCr6wgu3";
            CrTables = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            //CrystalReportViewer1.ParameterFieldInfo = paramFields; 
            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.DataBind();
            //CrystalReportViewer1.RefreshReport();
            //CrystalReportViewer1.PageZoomFactor = 200;
            Session["Report"] = cryRpt;
        }
        private void Page_Init(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                lblprj.Text = Request.QueryString["prj"].ToString();
                string _prm = Request.QueryString[0].ToString();
                if (!String.IsNullOrEmpty(Request.QueryString["idx"]))
                {
                    lblindex.Text = Request.QueryString["idx"].ToString();
                }
                else
                    lblindex.Text = "0";
                
                string _rpt="";
                if (_prm.Substring(0, 2) == "IL")
                {
                    _rpt = "IL";
                    lblid.Text = "1";
                }
                else if (_prm.Substring(0, 2) == "dr")
                {
                    _rpt = _prm.Substring(0, 2);
                    lblid.Text = _prm.Substring(2);
                }
                else  if (_prm.Substring(0, 2) == "cp" || _prm.Substring(0, 2) == "pr")
                {
                    _rpt = _prm;
                }
                else if (_prm.Substring(0, 3) == "so0")
                {
                    _rpt = _prm.Substring(0, 2);
                    lblid.Text = _prm.Substring(3);
                }
                else if (_prm.Substring(0, 3) == "som" || _prm.Substring(0, 3) == "msc")
                {
                    _rpt = _prm;
                }
                else if (_prm.Length >= 5)
                {
                    if (_prm.Substring(0, 5) == "dlog0")
                    {
                        _rpt = _prm.Substring(0, 4);
                        lblid.Text = _prm.Substring(5);
                    }
                    else
                        _rpt = _prm;
                }
                else
                    _rpt = _prm;

                if (_rpt == "msc")
                    Load_MSService();
                else
                {
                    filter_tbl.Visible = false;
                    btngenerate.Visible = false;
                }

                if (_rpt == "msr")
                {
                    Generate_Reports1(_rpt);
                }
                else
                {

                    Generate_Reports(_rpt);
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
       
        private void Generate_SOIMG()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsSO _objcls = new _clsSO();
            _objcls.so_id = Convert.ToInt32(lblid.Text);
            DataTable _dtmain = _objbll.Load_SO_Details(_objcls, _objdb);
            var _result = from o in _dtmain.AsEnumerable()
                          select o;
            foreach (var row in _result)
            {
                _objcls.so_id = Convert.ToInt32(row["so_itm_id"].ToString());
                _objcls.so_itm_id = Convert.ToInt32(row["so_itm_id"].ToString());
                DataTable _dtsub= _objbll.Load_SO_Photo(_objcls, _objdb);
                var _sub = from o in _dtsub.AsEnumerable()
                           select o;
                foreach (var row1 in _sub)
                {
                    byte[] _image = new byte[1000];
                    string _path = row1["photo"].ToString();
                    if (File.Exists(Server.MapPath(_path)))
                    {
                        FileStream fs = new FileStream(Server.MapPath(_path), FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        _image = br.ReadBytes((int)fs.Length);
                        br.Close();
                        fs.Close();
                    }
                    _objcls.logo = _image;
                    _objbll.Generate_SOIMG(_objcls, _objdb);
                }
            }
          
        }
        private void SelectionFormula(ReportDocument rptDoc, string _el1, string _el2, string _el3, string _el4)
        {
            string _selectionFormula = "";
            if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All")
            {
                return;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All")
            {
                _selectionFormula = "{DR_SO_RPT.SERVICE}='" + _el1 + "'";
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All")
            {
                _selectionFormula = "{DR_SO_RPT.SERVICE}='" + _el1 + "' AND  {DR_SO_RPT.ISSUED_BY}='" + _el2 + "'";
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 == "All")
            {
                _selectionFormula = "{DR_SO_RPT.SERVICE}='" + _el1 + "' AND  {DR_SO_RPT.ISSUED_BY}='" + _el2 + "' AND  {DR_SO_RPT.ISSUED_TO}='" + _el3 + "'";
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All")
            {
                _selectionFormula = "{DR_SO_RPT.SERVICE}='" + _el1 + "' AND  {DR_SO_RPT.ISSUED_BY}='" + _el2 + "' AND  {DR_SO_RPT.ISSUED_TO}='" + _el3 + "' AND  {DR_SO_RPT.STATUS}='" + _el4 + "'";
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 == "All")
            {
                _selectionFormula = "{DR_SO_RPT.SERVICE}='" + _el1 + "' AND  {DR_SO_RPT.ISSUED_TO}='" + _el3 + "'";
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All")
            {
                _selectionFormula = "{DR_SO_RPT.SERVICE}='" + _el1 + "' AND  {DR_SO_RPT.ISSUED_TO}='" + _el3 + "' AND  {DR_SO_RPT.STATUS}='" + _el4 + "'";
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All")
            {
                _selectionFormula = "{DR_SO_RPT.SERVICE}='" + _el1 + "' AND  {DR_SO_RPT.STATUS}='" + _el4 + "'";
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All")
            {
                _selectionFormula = "{DR_SO_RPT.ISSUED_BY}='" + _el2 + "'";
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 == "All")
            {
                _selectionFormula = "{DR_SO_RPT.ISSUED_BY}='" + _el2 + "' AND  {DR_SO_RPT.ISSUED_TO}='" + _el3 + "'";
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All")
            {
                _selectionFormula = "{DR_SO_RPT.ISSUED_BY}='" + _el2 + "' AND  {DR_SO_RPT.STATUS}='" + _el4 + "'";
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All")
            {
                _selectionFormula = "{DR_SO_RPT.ISSUED_BY}='" + _el2 + "' AND  {DR_SO_RPT.ISSUED_TO}='" + _el3 + "' AND  {DR_SO_RPT.STATUS}='" + _el4 + "'";
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All")
            {
                _selectionFormula = "{DR_SO_RPT.ISSUED_TO}='" + _el3 + "'";
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All")
            {
                _selectionFormula = "{DR_SO_RPT.ISSUED_TO}='" + _el3 + "' AND  {DR_SO_RPT.STATUS}='" + _el4 + "'";
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All")
            {
                _selectionFormula = "{DR_SO_RPT.STATUS}='" + _el4 + "'";
            }
            rptDoc.RecordSelectionFormula = _selectionFormula;
        }

      

        private void SelectFormulaWithBuilding(ReportDocument rptDoc, string _el1, string _el2, string _el3, string _el4, string _el5)
        {
            string _selectionFormula = string.Empty;
            if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 == "All")
            {
                return;
            }
            if (_el1 != "All")
                _selectionFormula = "{DR_SO_RPT.SERVICE}='" + _el1 + "'";
            if (_el2 != "All")
            {
                if (_selectionFormula == string.Empty)
                    _selectionFormula = "{DR_SO_RPT.ISSUED_BY}='" + _el2 + "'";
                else
                    _selectionFormula = _selectionFormula + " AND {DR_SO_RPT.ISSUED_BY}='" + _el2 + "'";
            }
            if (_el3 != "All")
            {
                if (_selectionFormula == string.Empty)
                    _selectionFormula = "{DR_SO_RPT.ISSUED_TO}='" + _el3 + "'";
                else
                    _selectionFormula = _selectionFormula + " AND {DR_SO_RPT.ISSUED_TO}='" + _el3 + "'";
            }
            if (_el4 != "All")
            {
                if (_selectionFormula == string.Empty)
                    _selectionFormula = "{DR_SO_RPT.STATUS}='" + _el4 + "'";
                else
                    _selectionFormula = _selectionFormula + " AND {DR_SO_RPT.STATUS}='" + _el4 + "'";
            }
            if (_el5 != "All")
            {
                if (_selectionFormula == string.Empty)
                    _selectionFormula = "{DR_SO_RPT.BUILDING}='" + _el5 + "'";
                else
                    _selectionFormula = _selectionFormula + " AND {DR_SO_RPT.BUILDING}='" + _el5 + "'";
            }
            rptDoc.RecordSelectionFormula = _selectionFormula;
        }

        private void SelectionFormula_HMIM(ReportDocument rptDoc, string _el1, string _el2, string _el3, string _el4, string _el5)
        {
              string _selectionFormula = string.Empty;
            if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All")
            {
                return;
            }
            if (_el1 != "All")
                _selectionFormula = "{Table1.package}='" + _el1 + "'";
            if (_el2 != "All")
            {
                if (_selectionFormula == string.Empty)
                    _selectionFormula = "{Table1.ISSUED_BY}='" + _el2 + "'";
                else
                    _selectionFormula = _selectionFormula + " AND {Table1.ISSUED_BY}='" + _el2 + "'";
            }
            if (_el3 != "All")
            {
                if (_selectionFormula == string.Empty)
                    _selectionFormula = "{Table1.ISSUED_TO}='" + _el3 + "'";
                else
                    _selectionFormula = _selectionFormula + " AND {Table1.ISSUED_TO}='" + _el3 + "'";
            }
            if (_el4 != "All")
            {
                if (_selectionFormula == string.Empty)
                    _selectionFormula = "{Table1.drstatus}='" + _el4 + "'";
                else
                    _selectionFormula = _selectionFormula + " AND {Table1.drstatus}='" + _el4 + "'";
            }
            rptDoc.RecordSelectionFormula = _selectionFormula;
       
        }

        private void Load_MSService()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            //drservices.DataSource = _objbll.Load_Prj_Service(_objdb);
            drservices.DataSource = _objbll.Load_Prj_Service_MS(_objdb);
            drservices.DataTextField = "PRJ_SER_NAME";
            drservices.DataValueField = "PRJ_SER_ID";
            drservices.DataBind();
            drservices.Items.Insert(0, "All");
            //DataTable _dtcas = _objbll.Load_Prj_Cassheet(_objdb);
            //DataTable _dtsys = _objbll.Load_Prj_MsSystem(_objdb);
            //DataTable _dttype = _objbll.Load_Prj_MsType(_objdb);
            //DataTable _dtrtype = _objbll.Load_Prj_TrType(_objdb);
        }

        protected void drservices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drservices.SelectedItem.Text == "All") return;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            DataTable _dtsys = _objbll.Load_Prj_MsSystem(_objdb);
            var _systems = from o in _dtsys.AsEnumerable()
                           where o.Field<int>(3) == Convert.ToInt32(drservices.SelectedItem.Value)
                           select o;
            drpackages.Items.Clear();
            foreach (var row in _systems)
            {
                ListItem _lst = new ListItem();
                _lst.Text = row[2].ToString();
                _lst.Value = row[0].ToString();
                drpackages.Items.Add(_lst);
            }
            drpackages.Items.Insert(0, "All");
            drtype.DataSource = _objbll.Load_Prj_MsType(_objdb);
            drtype.DataTextField = "PRJ_MSTYPE_NAME";
            drtype.DataValueField = "PRJ_MSTYPE_ID";
            drtype.DataBind();
            drtype.Items.Insert(0, "All");
        }

        protected void btngenerate_Click(object sender, EventArgs e)
        {
            Generate_Reports("msc");
        }

        private void MSC_SelectionFormula(ReportDocument rptDoc, string _el1, string _el2, string _el3)
        {
            string _selectionFormula = "";
            if (_el1 == "All" && _el2 == "All" && _el3 == "All")
            {
                return;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All")
            {
                _selectionFormula = "{MS_COMMENTS_RPT.SERVICE}='" + _el1 + "'";
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All")
            {
                _selectionFormula = "{MS_COMMENTS_RPT.SERVICE}='" + _el1 + "' AND  {MS_COMMENTS_RPT.SYSTEM}='" + _el2 + "'";
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All")
            {
                _selectionFormula = "{MS_COMMENTS_RPT.SERVICE}='" + _el1 + "' AND  {MS_COMMENTS_RPT.SYSTEM}='" + _el2 + "' AND  {MS_COMMENTS_RPT.TYPE}='" + _el3 + "'";
            }
           else if (_el1 != "All" && _el2 == "All" && _el3 != "All")
            {
                _selectionFormula = "{MS_COMMENTS_RPT.SERVICE}='" + _el1 + "' AND  {MS_COMMENTS_RPT.TYPE}='" + _el3 + "'";
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" )
            {
                _selectionFormula = "{MS_COMMENTS_RPT.SYSTEM}='" + _el2 + "'";
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" )
            {
                _selectionFormula = "{MS_COMMENTS_RPT.SYSTEM}='" + _el2 + "' AND  {MS_COMMENTS_RPT.TYPE}='" + _el3 + "'";
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" )
            {
                _selectionFormula = "{MS_COMMENTS_RPT.TYPE}='" + _el3 + "'";
            }
            rptDoc.RecordSelectionFormula = _selectionFormula;
        }
        private void MSS_SelectionFormula(ReportDocument rptDoc, string _el1, string _el2, string _el3, string _el4)
        {
            string _selectionFormula = "";
            if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All")
            {
                return;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All")
            {
                _selectionFormula = "{MS_SCHEDULE_SUMMARY.SERVICE}='" + _el1 + "'";
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All")
            {
                _selectionFormula = "{MS_SCHEDULE_SUMMARY.SERVICE}='" + _el1 + "' AND  {MS_SCHEDULE_SUMMARY.SYSTEMS}='" + _el2 + "'";
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 == "All")
            {
                _selectionFormula = "{MS_SCHEDULE_SUMMARY.SERVICE}='" + _el1 + "' AND  {MS_SCHEDULE_SUMMARY.SYSTEMS}='" + _el2 + "' AND  {MS_SCHEDULE_SUMMARY.TYPE}='" + _el3 + "'";
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All")
            {
                _selectionFormula = "{MS_SCHEDULE_SUMMARY.SERVICE}='" + _el1 + "' AND  {MS_SCHEDULE_SUMMARY.SYSTEMS}='" + _el2 + "' AND  {MS_SCHEDULE_SUMMARY.TYPE}='" + _el3 + "' AND  {MS_SCHEDULE_SUMMARY.STATUS}='" + _el4 + "'";
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 == "All")
            {
                _selectionFormula = "{MS_SCHEDULE_SUMMARY.SERVICE}='" + _el1 + "' AND  {MS_SCHEDULE_SUMMARY.TYPE}='" + _el3 + "'";
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All")
            {
                _selectionFormula = "{MS_SCHEDULE_SUMMARY.SERVICE}='" + _el1 + "' AND  {MS_SCHEDULE_SUMMARY.TYPE}='" + _el3 + "' AND  {MS_SCHEDULE_SUMMARY.STATUS}='" + _el4 + "'";
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All")
            {
                _selectionFormula = "{MS_SCHEDULE_SUMMARY.SERVICE}='" + _el1 + "' AND  {MS_SCHEDULE_SUMMARY.STATUS}='" + _el4 + "'";
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All")
            {
                _selectionFormula = "{MS_SCHEDULE_SUMMARY.SYSTEMS}='" + _el2 + "'";
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 == "All")
            {
                _selectionFormula = "{MS_SCHEDULE_SUMMARY.SYSTEMS}='" + _el2 + "' AND  {MS_SCHEDULE_SUMMARY.TYPE}='" + _el3 + "'";
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All")
            {
                _selectionFormula = "{MS_SCHEDULE_SUMMARY.SYSTEMS}='" + _el2 + "' AND  {MS_SCHEDULE_SUMMARY.STATUS}='" + _el4 + "'";
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All")
            {
                _selectionFormula = "{MS_SCHEDULE_SUMMARY.SYSTEMS}='" + _el2 + "' AND  {MS_SCHEDULE_SUMMARY.TYPE}='" + _el3 + "' AND  {MS_SCHEDULE_SUMMARY.STATUS}='" + _el4 + "'";
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All")
            {
                _selectionFormula = "{MS_SCHEDULE_SUMMARY.TYPE}='" + _el3 + "'";
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All")
            {
                _selectionFormula = "{MS_SCHEDULE_SUMMARY.TYPE}='" + _el3 + "' AND  {MS_SCHEDULE_SUMMARY.STATUS}='" + _el4 + "'";
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All")
            {
                _selectionFormula = "{MS_SCHEDULE_SUMMARY.STATUS}='" + _el4 + "'";
            }
            rptDoc.RecordSelectionFormula = _selectionFormula;
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            string _url = "cmsreports.aspx?idx=" + lblindex.Text + "&prj=" + lblprj.Text;
            Response.Redirect(_url);
        }

        private void SelectionFormula_New(ReportDocument rptDoc, string _el1, string _el2, string _el3, string _el4, string _el5)
        {
            string _selectionFormula = string.Empty;
            if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 == "All")
            {
                return;
            }
            if (_el1 != "All")
                _selectionFormula = "{Table1.package}='" + _el1 + "'";
            if (_el2 != "All")
            {
                if (_selectionFormula == string.Empty)
                    _selectionFormula = "{Table1.ISSUED_BY}='" + _el2 + "'";
                else
                    _selectionFormula = _selectionFormula + " AND {Table1.ISSUED_BY}='" + _el2 + "'";
            }
            if (_el3 != "All")
            {
                if (_selectionFormula == string.Empty)
                    _selectionFormula = "{Table1.ISSUED_TO}='" + _el3 + "'";
                else
                    _selectionFormula = _selectionFormula + " AND {Table1.ISSUED_TO}='" + _el3 + "'";
            }
            if (_el4 != "All")
            {
                if (_selectionFormula == string.Empty)
                    _selectionFormula = "{Table1.drstatus}='" + _el4 + "'";
                else
                    _selectionFormula = _selectionFormula + " AND {Table1.drstatus}='" + _el4 + "'";
            }
            if (_el5 != "All")
            {
                if (_selectionFormula == string.Empty)
                    _selectionFormula = "{Table1.Building}='" + _el5 + "'";
                else
                    _selectionFormula = _selectionFormula + " AND {Table1.Building}='" + _el5 + "'";
            }
            rptDoc.RecordSelectionFormula = _selectionFormula;
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
                //cryRpt.Dispose();
                //cryRpt.Close();
        }
    }
}
