using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Data;


namespace CmlTechniques.CMS
{
    public partial class cmsreports : System.Web.UI.Page
    {
        public static DataTable _dtmaster;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                lblprj.Text = Request.QueryString["prj"].ToString();
                LOAD_CAS_SERVICE();
                dr.Visible = false;
                so.Visible=false;
                mytable.Visible = false;
                mytable1.Visible = false;
                tbl_msd.Visible = false;
                tbl_tr.Visible = false;
                //asao_tr1.Visible = false;
                //asao_tr2.Visible = false;
                _11736_tr1.Visible = false;
                _11736_tr2.Visible = false;
                asao_tr1.Visible = false;
                asao_tr2.Visible = false;
                progress_div.Visible = false;
                TabPanel9.Visible = false;
                bdiv.Visible = false;
                if (!String.IsNullOrEmpty(Request.QueryString["idx"]))
                {
                    TabContainer1.ActiveTabIndex = Convert.ToInt16(Request.QueryString["idx"]);
                }
                if (lblprj.Text == "MIST1B")
                {
                    TabPanel3.Visible = false;
                }
                else
                    TabPanel3.Visible = true;


                if (lblprj.Text == "123" || lblprj.Text == "BCC1" || lblprj.Text == "ASAO" || lblprj.Text == "ASAO1" || lblprj.Text == "BNGA" || lblprj.Text == "KAWC" || lblprj.Text == "MIST1B" || lblprj.Text == "PSSO" || lblprj.Text == "QFHQ" || lblprj.Text == "QAIA" || lblprj.Text == "Trial")
                {
                    TabPanel7.Visible = true;
                }
                else
                    TabPanel7.Visible = false;
                if (lblprj.Text == "ASAO" || lblprj.Text=="ASAO1")
                {
                    asao_tr1.Visible = true;
                    asao_tr2.Visible = true;
                    _11736_tr1.Visible = false;
                    TabPanel2.Visible = false;
                    TabPanel3.Visible = false;
                    TabPanel4.Visible = false;
                    TabPanel5.Visible = false;
                    TabPanel9.Visible = true;
                }
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini")
                {
                    _11736_tr1.Visible = true;
                    _11736_tr2.Visible = true;
                    progress_div.Visible = true;
                }
                else if (lblprj.Text == "demo")
                {
                    TabPanel2.Visible = false;
                    TabPanel3.Visible = false;
                    TabPanel6.Visible = false;
                    TabPanel7.Visible = false;
                    TabPanel8.Visible = false;
                    TabPanel9.Visible = false;
                    TabPanel5.Visible = false;
                }

                if (lblprj.Text == "HMIM") { 
                    btnmsd.Visible = false;
                    trcomment.Visible = false;
                    btncasrpt.Visible = true;
                    btncasrpt.Text = "Project Building Summary";
                }

                Session["Div"] = "1";

                if (lblprj.Text == "14211")
                {
                    Load_Packages(lblprj.Text);
                    DisableFields_14211();



                }
                if (lblprj.Text != "PCD" && lblprj.Text != "ARSD") {
                    
                    _Pcd_tr1.Visible = false;
                    btndrcommentlog.Visible = false;
                    _Pcd_tr2.Visible = false;
                }

                btnsocommentlog.Visible = false;
                TabPanel8.Visible = false;
                

                if (lblprj.Text == "ABS")
                {
                    btnmsd.Visible = false;
                    trcomment.Visible = false;
                }
            }
        }
        private void  DisableFields_14211()   
        {
            
                    rd_facility.Enabled = false;
                    rd_facility1.Enabled = false;
                    rd_facility2.Enabled = false;

                    rd_service.Enabled = false;
                    rd_service1.Enabled = false;

                    rd_cassheet.Enabled = false;
        }
        private void Load_Packages(string _prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + _prj;
            DataTable _dtpkg = _objbll.Load_fclty_Package(_objdb);
            rd_package.DataSource = _dtpkg;
            rd_package.DataTextField = "PKG_NAME";
            rd_package.DataValueField = "PKG_ID";
            rd_package.DataBind();

            rd_package.Items.Insert(0, "--Select Package--");



            rd_package1.DataSource = _dtpkg;
            rd_package1.DataTextField = "PKG_NAME";
            rd_package1.DataValueField = "PKG_ID";
            rd_package1.DataBind();
            rd_package1.Items.Insert(0, "--Select Package--");

            rd_package2.DataSource = _dtpkg;
            rd_package2.DataTextField = "PKG_NAME";
            rd_package2.DataValueField = "PKG_ID";
            rd_package2.DataBind();
            rd_package2.Items.Insert(0, "--Select Package--");




            _dtmaster = _objbll.Load_Facility(_objdb);
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
                
            }
        }
        protected void btnmsshcdule_Click(object sender, EventArgs e)
        {
        }
        protected void LOAD_CAS_SERVICE()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
           // DataTable _dtable = _objbll.Load_Project_CMSFolder(_objdb);
            //DataTable _dtable = _objbll.Load_Prj_Service(_objdb);
            //var _id = from o in _dtable.AsEnumerable()
            //          where o.Field<string>(1) == "Cas Sheet"
            //          select o;
            //foreach (var row in _id)
            //{
            //    var _ser = from o in _dtable.AsEnumerable()
            //               where o.Field<int>(3) == Convert.ToInt32(row[0].ToString())
            //               select o;
            //    foreach (var row1 in _ser)
            //    {
            //        ListItem _lst = new ListItem();
            //        _lst.Text = row1[1].ToString();
            //        _lst.Value = row1[0].ToString() + "M_" + row1[4].ToString();
            //        drservice.Items.Add(_lst);
            //    }
            //}
            DataTable _dt = _objbll.Load_Prj_Service(_objdb);
            drservice.DataSource = _dt;
            drservice.DataTextField = "PRJ_SER_NAME";
            drservice.DataValueField = "PRJ_SER_ID";
            drservice.DataBind();

            DataTable _dt1 = _objbll.Load_Prj_Service_MS(_objdb);  
            dr_msservice.DataSource = _dt1; 
            dr_msservice.DataTextField = "PRJ_SER_NAME";
            dr_msservice.DataValueField = "PRJ_SER_ID";
            dr_msservice.DataBind();

            dr_trservice.DataSource = _dt;
            dr_trservice.DataTextField = "PRJ_SER_NAME";
            dr_trservice.DataValueField = "PRJ_SER_ID";
            dr_trservice.DataBind();

            drsrv.DataSource = _dt;
            drsrv.DataTextField = "PRJ_SER_NAME";
            drsrv.DataValueField = "PRJ_SER_ID";
            drsrv.DataBind();
            if (lblprj.Text == "HMIM")
            {
                drservice_.DataSource = _dt;
                drservice_.DataTextField = "PRJ_SER_NAME";
                drservice_.DataValueField = "PRJ_SER_ID";
                drservice_.DataBind();
                dr_services.DataSource = _dt;
                dr_services.DataTextField = "PRJ_SER_NAME";
                dr_services.DataValueField = "PRJ_SER_ID";
                dr_services.DataBind();
                dr_services.Items.Insert(0, "--Select Service--");
            }
            else if (lblprj.Text == "14211")
            {
                rd_service.DataSource = _dt;
                rd_service.DataTextField = "PRJ_SER_NAME";
                rd_service.DataValueField = "PRJ_SER_ID";
                rd_service.DataBind();

                rd_service.Items.Insert(0, "--Select Service--");

                rd_service1.DataSource = _dt;
                rd_service1.DataTextField = "PRJ_SER_NAME";
                rd_service1.DataValueField = "PRJ_SER_ID";
                rd_service1.DataBind();
                rd_service1.Items.Insert(0, "--Select Service--");

            }
            LOAD_CASSHEET();


        }
        protected void LOAD_CASSHEET()
        {
            drcassheet.Items.Clear();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            DataTable _dtable;
            if (lblprj.Text == "12761")
                _dtable = _objbll.Load_Prj_Cassheet_12761(_objdb);
            else
                _dtable = _objbll.Load_Prj_Cassheet(_objdb);
            string _masterid = drservice.SelectedItem.Value;
            var _id = from o in _dtable.AsEnumerable()
                      where o.Field<int>(2) == Convert.ToInt32(_masterid)
                      select o;
            foreach (var row in _id)
            {
                ListItem _lst = new ListItem();
                _lst.Text = row[1].ToString();
                _lst.Value = row[0].ToString();
                drcassheet.Items.Add(_lst);
            }
            //drcassheet.DataSource = _objbll.Load_Prj_Cassheet(_objdb);
            drcassheet.DataBind();
        }

        protected void drservice_SelectedIndexChanged(object sender, EventArgs e)
        {
            LOAD_CASSHEET();
        }

        protected void btnview_Click(object sender, EventArgs e)
        {

            string _prm = drservice.SelectedItem.Value + "_P" + lblprj.Text;
            if ((string)Session["type"] == "0")
            {
                //Session["sch_id"] = drcassheet.SelectedItem.Value;
                Load_FullSchedule(drcassheet.SelectedItem.Value);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["sch_id"] + "')", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('cas','16');", true);
            }
            else if ((string)Session["type"] == "2")
            {
                //Session["srv_id"] = drservice.SelectedItem.Value.Substring(drservice.SelectedItem.Value.IndexOf("M_") + 2);
                if (lblprj.Text == "CCAD"  || lblprj.Text == "ASAO" || lblprj.Text == "ASAO1" )
                {
                    _prm = drservice.SelectedItem.Value + "_P" + lblprj.Text;
                    Response.Redirect("../CasSheet/CasSheet_Summary.aspx?id=" + _prm);
                }
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini")
                {
                    _prm = "ReportsNew.aspx?prj=" + lblprj.Text + "&div=" + drservice.SelectedItem.Value + "&type=5&sch=0";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _prm + "','32');", true);
                }
                else
                {
                    if (chk.Checked == true)
                    {
                        _prm = _prm + "_T0";
                        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _prm + "','25');", true);
                    }
                    else
                    {
                        Session["srv"] = drservice.SelectedItem.Value;
                        Session["srv_name"] = drservice.SelectedItem.Text;

                        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _prm + "','18');", true);
                    }
                }
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ (string)Session["srv"] +"')", true);
            }
            else if ((string)Session["type"] == "3")
            {
                if (lblprj.Text == "CCAD"  || lblprj.Text=="ASAO" || lblprj.Text=="ASAO1")
                {
                    _prm = drcassheet.SelectedItem.Value + "_P" + lblprj.Text;
                    Response.Redirect("../CasSheet/Package_Summary.aspx?id=" + _prm);
                }
                else
                {
                    Session["sch"] = drcassheet.SelectedItem.Value;
                    _Create_Cookies();

                    if (lblprj.Text == "PCD" || lblprj.Text == "ARSD")
                    {
                        Response.Redirect("Summary_New.aspx?Id=" + drcassheet.SelectedItem.Value + "&Prj=" + lblprj.Text + "&Type=1");
                        //myframe1.Attributes.Add("src", "Summary_New.aspx?Id=" + lblsch.Text + "&Prj=" + lblprj.Text + "&Type=0");
                    }
                    else
                    {
                        _prm = drcassheet.SelectedItem.Value + "_P" + lblprj.Text;

                        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _prm + "','17');", true);
                    }
                }
            }
        }
        private void Load_FullSchedule( string sch)
        {
            if (sch == "5" || sch == "1")
                Response.Redirect("caslvreport.aspx?id=" + lblprj.Text);
            else if (sch == "2")
                Response.Redirect("casmvreport.aspx?id=" + lblprj.Text);
            else if (sch == "3")
                Response.Redirect("castransreport.aspx?id=" + lblprj.Text);
            else if (sch == "4")
                Response.Redirect("casgenreport.aspx?id=" + lblprj.Text);
            else if (sch == "6")
                Response.Redirect("caselpreport.aspx?id=" + lblprj.Text);
            else if (sch == "7")
                Response.Redirect("casemgreport.aspx?id=" + lblprj.Text);
            else if (sch == "8")
            {
                if(lblprj.Text=="CCAD")
                    Response.Redirect("casme1report.aspx?id=" + lblprj.Text);
                else
                    Response.Redirect("casmereport.aspx?id=" + lblprj.Text);
            }
            else if (sch == "9")
                Response.Redirect("casfdreport.aspx?id=" + lblprj.Text);
            else if (sch == "10")
                Response.Redirect("casfavareport.aspx?id=10_P" + lblprj.Text);
            else if (sch == "11")
                Response.Redirect("caslcsreport.aspx?id=" + lblprj.Text);
            else if (sch == "12")
                Response.Redirect("casscnreport.aspx?id=" + lblprj.Text);
            else if (sch == "13")
                Response.Redirect("cascctvreport.aspx?id=" + lblprj.Text);
            else if (sch == "17")
                Response.Redirect("casph1report.aspx?id=" + lblprj.Text);
            else if (sch == "18")
                Response.Redirect("casph2report.aspx?id=" + lblprj.Text);
            else if (sch == "19")
                Response.Redirect("casph3report.aspx?id=" + lblprj.Text);
            else if (sch == "20")
                Response.Redirect("casbmsreport.aspx?id=20_P" + lblprj.Text);
            else if (sch == "21")
                Response.Redirect("casflureport.aspx?id=" + lblprj.Text);
            else if (sch == "22")
                Response.Redirect("casacsreport.aspx?id=" + lblprj.Text);
            else if (sch == "15")
                Response.Redirect("casgrmsreport.aspx?id=" + lblprj.Text);
            else if (sch == "14")
                Response.Redirect("casavireport.aspx?id=" + lblprj.Text);
            else if (sch == "23")
                Response.Redirect("caslereport.aspx?id=" + lblprj.Text);
            else if (sch == "16")
                Response.Redirect("caselvreport.aspx?id=" + lblprj.Text);
            else if (sch == "24")
                Response.Redirect("casklereport.aspx?id=" + lblprj.Text);
            else if (sch == "30")
                Response.Redirect("casdfsreport.aspx?id=" + lblprj.Text);
            else if (sch == "25")
                Response.Redirect("casacmreport.aspx?id=25_P" + lblprj.Text);
            else if (sch == "27")
                Response.Redirect("casacmreport.aspx?id=27_P" + lblprj.Text);
            else if (sch == "26")
                Response.Redirect("casccsreport.aspx?id=" + lblprj.Text);
            else if (sch == "28")
                Response.Redirect("casfesreport.aspx?id=" + lblprj.Text);
            else if (sch == "29")
                Response.Redirect("casfpsreport.aspx?id=" + lblprj.Text);
            else if (sch == "34")
                Response.Redirect("caspfsreport.aspx?id=" + lblprj.Text);
            else if (sch == "35")
                Response.Redirect("casvslreport.aspx?id=" + lblprj.Text);
            else if (sch == "36")
                Response.Redirect("caseotreport.aspx?id=" + lblprj.Text);
            else if (sch == "33")
                Response.Redirect("cassitreport.aspx?id=" + lblprj.Text);
        }
        void _Create_Cookies()
        {
            if (Request.Browser.Cookies)
            {
                HttpCookie _CookieSch = new HttpCookie("sch");
                _CookieSch.Value = (string)Session["sch"];
                _CookieSch.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_CookieSch);

            }
            else
                return;
        }
        protected void btnpr_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('id=pr&idx="+ TabContainer1.ActiveTabIndex.ToString()+"','16');", true);
            string _prm = "Reports.aspx?id=pr&idx=" + TabContainer1.ActiveTabIndex.ToString() + "&prj=" + lblprj.Text;
            Response.Redirect(_prm);
        }

        protected void btndrl_Click(object sender, EventArgs e)
        {
            //dr.Visible = false;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('id=dlog1&idx="+ TabContainer1.ActiveTabIndex.ToString()+"','16');", true);
            string _prm = "Reports.aspx?id=dlog1&idx=" + TabContainer1.ActiveTabIndex.ToString() + "&prj=" + lblprj.Text;
            Response.Redirect(_prm);
        }

        protected void btndrd_Click(object sender, EventArgs e)
        {
            dr.Visible = true;
            load_dr_no();
        }

        protected void btnsod_Click(object sender, EventArgs e)
        {
            so.Visible = true;
            load_so_no();
        }
        private void load_so_no()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            drsono.DataSource = _objbll.Load_so_dir(_objcls, _objdb);
            drsono.DataTextField = "so_no";
            drsono.DataValueField = "so_id";
            drsono.DataBind();
            drsono.Items.Insert(0, "-- Select SO.No --");
        }
        protected void btnsol_Click(object sender, EventArgs e)
        {
            //so.Visible = false;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('id=som&idx="+ TabContainer1.ActiveTabIndex.ToString()+"','16');", true);
            string _prm = "Reports.aspx?id=som&idx=" + TabContainer1.ActiveTabIndex.ToString() + "&prj=" + lblprj.Text;
            Response.Redirect(_prm);
        }

        protected void btnmss_Click(object sender, EventArgs e)
        {
            tbl_msd.Visible = false;
             string _prm = "";

            if (lblprj.Text == "12761")
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('id=mss&idx=" + TabContainer1.ActiveTabIndex.ToString() + "' ,'201');", true);
            else if (lblprj.Text == "HMIM" || lblprj.Text == "ABS")
                 {
                _prm="ms_schedule1.aspx?id=mss&idx=" + TabContainer1.ActiveTabIndex.ToString() + "&prj=" + lblprj.Text;
                Response.Redirect(_prm);
                 }
            else
            {
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;

                _objbll.Gen_MS_Schedule_Summary(_objdb);

                 _prm="ms_schedule.aspx?id=mss&idx=" + TabContainer1.ActiveTabIndex.ToString() + "&prj=" + lblprj.Text;

                Response.Redirect(_prm);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('id=mss&idx=" + TabContainer1.ActiveTabIndex.ToString() + "' ,'20');", true);
            }

        }
        private void load_dr_no()
        {
            drdrno.Items.Clear();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            _objcls.service = "All";
            drdrno.DataSource = _objbll.Load_Doc_review_log(_objcls, _objdb);
            drdrno.DataTextField = "dr_no";
            drdrno.DataValueField = "dr_id";
            drdrno.DataBind();
            drdrno.Items.Insert(0, "-- Select DR.No --");
        }

        protected void btndrview_Click(object sender, EventArgs e)
        {
            if (drdrno.SelectedItem.Text == "-- Select DR.No --") return;
            Session["dr_no"] = drdrno.SelectedItem.Text;
            //string _prm = "id=dr" + drdrno.SelectedValue.ToString() + "&idx=" + TabContainer1.ActiveTabIndex.ToString();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('"+ _prm + "','16');", true);
            string _prm = "Reports.aspx?id=dr"+ drdrno.SelectedValue.ToString() + "&idx=" + TabContainer1.ActiveTabIndex.ToString() + "&prj=" + lblprj.Text;
            Response.Redirect(_prm);
        }

        protected void btnsoview_Click(object sender, EventArgs e)
        {
            if (drsono.SelectedItem.Text == "-- Select SO.No --") return;
            Session["sono"] = drsono.SelectedItem.Text;
            //string _prm = "id=so0" + drsono.SelectedValue.ToString() + "&idx=" + TabContainer1.ActiveTabIndex.ToString();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _prm + "','16');", true);
            string _prm = "Reports.aspx?id=so0" + drsono.SelectedValue.ToString() + "&idx=" + TabContainer1.ActiveTabIndex.ToString() + "&prj=" + lblprj.Text;
            Response.Redirect(_prm);
        }

        protected void btncp_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('id=cp&idx=" + TabContainer1.ActiveTabIndex.ToString() + "','16');", true);
            string _prm = "Reports.aspx?id=cp&idx=" + TabContainer1.ActiveTabIndex.ToString() + "&prj=" + lblprj.Text;
            Response.Redirect(_prm);
        }

        protected void btnms_Click(object sender, EventArgs e)
        {
            tbl_msd.Visible = false;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('id=msc&idx=" + TabContainer1.ActiveTabIndex.ToString() + "','16');", true);
            string _prm = "";
            
            if (lblprj.Text == "HMIM")
            {
                _prm = "MsEntryHMIMrpt.aspx?prj=" + lblprj.Text + "&Id=0";
            }
            else
            _prm="Reports.aspx?id=msc&idx=" + TabContainer1.ActiveTabIndex.ToString() + "&prj=" + lblprj.Text;
            Response.Redirect(_prm);
        }

        protected void btncasrpt_Click(object sender, EventArgs e)
        {
            string _prm = "";
            if (lblprj.Text == "HMIM")
                _prm = "ReportsNew.aspx?prj=" + lblprj.Text + "&div=0&type=25&sch=0";
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _prm + "','32');", true);
        }

        protected void btnprjsum_Click(object sender, EventArgs e)
        {
            if (lblprj.Text == "CCAD"  || lblprj.Text == "ASAO" || lblprj.Text=="ASAO1")
                Response.Redirect("../CasSheet/Service_Summary.aspx?id=" + lblprj.Text);
            else if (lblprj.Text == "11736" || lblprj.Text == "Traini")
            {
                string _prm = "ReportsNew.aspx?prj=" + lblprj.Text + "&div=0&type=4&sch=0";
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _prm + "','32');", true);
            }
            else if (lblprj.Text == "HMIM")
            {
                ModalPopupExtender1.Show();
               
            }
            else if (lblprj.Text == "14211")
            {
                ModalPopupExtender3.Show();
              
            }
            else
            {
                Session["srv"] = "project";
                string _prm = "0_P" + lblprj.Text;
                Response.Redirect("Service_Summary.aspx?id=" + _prm);
                Session["type"] = "1";
            }
        }
        
        protected void btncassum_Click(object sender, EventArgs e)
        {
            if (lblprj.Text == "HMIM")
                ModalPopupExtender2.Show();
            else if (lblprj.Text == "14211")
                ModalPopupExtender4.Show(); 
            else
            {
                mytable.Visible = true;
                mytable1.Visible = false;
                drcassheet.Enabled = false;
                Session["type"] = "2";
            }
        }

        protected void btnpkgsum_Click(object sender, EventArgs e)
        {
            if (lblprj.Text == "HMIM")
                btnDummy_ModalPopupExtendersummary.Show();
            else if (lblprj.Text == "14211")
                ModalPopupExtender5.Show();
            else
            {
                mytable.Visible = true;
                drcassheet.Enabled = true;
                Session["type"] = "3";
            }
        }

        protected void btnmsd_Click(object sender, EventArgs e)
        {
            tbl_msd.Visible = true;
        }

        protected void btnmsdview_Click(object sender, EventArgs e)
        {

            if (lblprj.Text == "HMIM") return;
               

            Session["srv"] = dr_msservice.SelectedItem.Text;
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
                _objcls.doc_id = Convert.ToInt32(dr_msservice.SelectedItem.Value);
                _objcls.status = row[0].ToString();

                _objbll.Generate_MS_Summary(_objcls, _objdb);
            }
            _objcls.doc_id = Convert.ToInt32(dr_msservice.SelectedItem.Value);
            if (lblprj.Text == "12761")
            {
                _objcls.status = "-1";
                _objbll.Generate_MS_Summary(_objcls, _objdb);
            }
            _objcls.status = "1";
            _objbll.Generate_MS_Summary(_objcls, _objdb);
            string _parm = "id=ms_" + GetDocNo() + "&idx=" + TabContainer1.ActiveTabIndex.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _parm + "','19');", true);
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + dr_msservice.SelectedItem.Value + "');", true);
        }
        private string GetDocNo()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsdocument _objcls = new _clsdocument();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.doc_id = Convert.ToInt32(dr_msservice.SelectedItem.Value);
            return _objbll.Get_MsDoc_No(_objcls, _objdb);
        }
        private string GetDocNo_All()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            return _objbll.Get_MsDoc_No_All(_objdb);
        }
        private string GetTrDocNo()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsdocument _objcls = new _clsdocument();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.doc_id = Convert.ToInt32(dr_trservice.SelectedItem.Value);
            return _objbll.Get_TrDoc_No(_objcls, _objdb);
        }
        private string GetTrDocNo_All()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            return _objbll.Get_TrDoc_No_All(_objdb);
        }
        protected void btntrsummary_Click(object sender, EventArgs e)
        {
            tbl_tr.Visible = true;
        }

        protected void btntrview_Click(object sender, EventArgs e)
        {
            Session["srv"] = dr_trservice.SelectedItem.Text;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsdocument _objcls = new _clsdocument();
            _objdb.DBName = "DBCML";
            _objbll.Clear_MSSummary(_objdb);
            _objdb.DBName = "DB_" + lblprj.Text;
            DataTable _dtable = _objbll.Load_MSStatus(_objdb);
            var _status = from _data in _dtable.AsEnumerable()
                          select _data;
            foreach (var row in _status)
            {
                _objcls.doc_id = Convert.ToInt32(dr_trservice.SelectedItem.Value);
                _objcls.status = row[0].ToString();
                _objbll.Generate_TR_Summary(_objcls, _objdb);
            }
            _objcls.doc_id = Convert.ToInt32(dr_trservice.SelectedItem.Value);
            _objcls.status = "1";
            _objbll.Generate_TR_Summary(_objcls, _objdb);
            string _parm = "id=tr_" + GetTrDocNo()+ "&idx=" + TabContainer1.ActiveTabIndex.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _parm + "','19');", true);
        }

        protected void btnmsall_Click(object sender, EventArgs e)
        {
            Session["srv"] = "ALL";
            
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _clsdocument _objcls = new _clsdocument();
                _objdb.DBName = "DBCML";
                _clsproject _objcls1 = new _clsproject();
                _objcls1.prjcode = lblprj.Text;
                _objbll.Update_RPTLogo(_objcls1, _objdb);

                if (lblprj.Text == "HMIM" || lblprj.Text == "ABS")
                {
                    string _prm = "MsEntryHMIMrpt.aspx?prj=" + lblprj.Text+"&Id="+TabContainer1.ActiveTabIndex.ToString();
                    Response.Redirect(_prm);
                    return;

                }

                if (lblprj.Text != "12761")
                {
                    _objbll.Clear_MSSummary(_objdb);
                    _objdb.DBName = "DB_" + lblprj.Text;
                    DataTable _dtable = _objbll.Load_MSStatus(_objdb);
                    var _status = from _data in _dtable.AsEnumerable()
                                  select _data;
                    foreach (var row in _status)
                    {
                        _objcls.status = row[0].ToString();
                        _objbll.Generate_MS_Summary_ALL(_objcls, _objdb);
                    }
                    //if (lblprj.Text == "12761")
                    //{
                    //    _objcls.status = "-1";
                    //    _objbll.Generate_MS_Summary_ALL(_objcls, _objdb);
                    //}
                    _objcls.status = "1";
                    _objbll.Generate_MS_Summary_ALL(_objcls, _objdb);
                }
                else
                {
                    _objdb.DBName = "DB_" + lblprj.Text;
                    _objbll.Gen_MSSchedule_Graph(_objdb);
                }

            string _parm = "id=ms_" + GetDocNo_All()+"&idx=" + TabContainer1.ActiveTabIndex.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _parm + "','19');", true);
        }

        protected void btntrsumall_Click(object sender, EventArgs e)
        {
            Session["srv"] = "ALL";
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsdocument _objcls = new _clsdocument();
            _objdb.DBName = "DBCML";
            _objbll.Clear_MSSummary(_objdb);
            _objdb.DBName = "DB_" + lblprj.Text;
            DataTable _dtable = _objbll.Load_MSStatus(_objdb);
            var _status = from _data in _dtable.AsEnumerable()
                          select _data;
            foreach (var row in _status)
            {
                _objcls.status = row[0].ToString();
                _objbll.Generate_TR_Summary_ALL(_objcls, _objdb);
            }
            _objcls.status = "1";
            _objbll.Generate_TR_Summary_ALL(_objcls, _objdb);
            string _parm = "id=tr_" + GetTrDocNo_All() + "&idx=" + TabContainer1.ActiveTabIndex.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _parm + "','19');", true);
        }

        protected void btn_tsview_Click(object sender, EventArgs e)
        {
            Response.Redirect("TSReport.aspx?Id=" + lblprj.Text + "&idx=" + TabContainer1.ActiveTabIndex.ToString());
        }

        protected void btnsrvsum1_Click(object sender, EventArgs e)
        {

        }

        protected void btnsrvsum_Click(object sender, EventArgs e)
        {
            string _prm = drservice.SelectedItem.Value + "_P" + lblprj.Text + "_T1";
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _prm + "','25');", true);
        }

        protected void btnallsrvsum_Click(object sender, EventArgs e)
        {
            string _prm = drservice.SelectedItem.Value + "_P" + lblprj.Text + "_T2";
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _prm + "','25');", true);
        }

        protected void btnpackagebu_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CAS/package_breakup.aspx");
        }

        protected void btnprjsum__Click(object sender, EventArgs e)
        {
            string _prm="";
            if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                _prm = "../CasSheet/BuildingSummary.aspx?prj=" + lblprj.Text;
            else if (lblprj.Text == "HMIM")
                _prm = "ReportsNew.aspx?prj=" + lblprj.Text + "&div=0&type=25&sch=0";
            else
                _prm = "ReportsNew.aspx?prj=" + lblprj.Text + "&div=0&type=1&sch=0";
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _prm + "','32');", true);
        }

        protected void btnsersum__Click(object sender, EventArgs e)
        {
            mytable.Visible = false;
            mytable1.Visible = true;
        }

        protected void btnview1_Click(object sender, EventArgs e)
        {
            string _prm = "ReportsNew.aspx?prj=" + lblprj.Text + "&div=" + drbarea.SelectedItem.Value + "&type=2&sch=0";
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _prm + "','32');", true);
        }

        protected void btnview2_Click(object sender, EventArgs e)
        {
            string _prm = "ReportsNew.aspx?prj=" + lblprj.Text + "&div=" + drdiv.SelectedItem.Value + "&type=8&sch=" + drsrv.SelectedItem.Value;
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _prm + "','32');", true);
        }

        protected void btnbs_main_Click(object sender, EventArgs e)
        {
            string _prm = "../CasSheet/BuildingSummary.aspx?prj=" + lblprj.Text + "&bz=0";
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _prm + "','32');", true);
        }
        private void Load_CasBuildings()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_ASAO";
            blist.DataSource=  _objbll.Load_CasBuildings(_objdb);
            blist.DataTextField = "B_Z";
            blist.DataValueField = "B_Z";
            blist.DataBind();
        }

        protected void btndss_Click(object sender, EventArgs e)
        {
            bdiv.Visible = true;
            Load_CasBuildings();
        }

        protected void cmdbview_Click(object sender, EventArgs e)
        {
            string _bz = getselected();
            string _prm = "../CasSheet/BuildingSummary.aspx?prj=" + lblprj.Text + "&bz=" + _bz;
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _prm + "','32');", true);
        }
        private string getselected()
        {
            string _bz="";
            foreach (ListItem _lst in blist.Items)
            {
                if (_lst.Selected == true)
                    _bz = _bz + "," + _lst.Text;
            }
            return _bz;
        }
        private string Get_BuildingPermission()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsuser _objcls = new _clsuser();
            _objcls.uid = (string)Session["uid"];
            _objcls.mode = 1;
            return _objbll.Get_Buiding_Permission(_objcls, _objdb);
        }
        protected void btnenter1_Click(object sender, EventArgs e)
        {
            string _permission = Get_BuildingPermission();
            if (_permission.Substring(Convert.ToInt32(rdbuilding.SelectedValue) - 1, 1) != "1")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('You have no permission to access this building!');", true);
                return;
            }
            ModalPopupExtender1.Hide();
            string _div = rdbuilding.SelectedValue;
            Session["srv"] = "project";
            string _prm = "0_P" + lblprj.Text;
            Response.Redirect("Service_Summary.aspx?id=" + _prm + "&div=" + _div);
            Session["type"] = "1";
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }
        protected void btnenter2_Click(object sender, EventArgs e)
        {
            string _permission = Get_BuildingPermission();
            if (_permission.Substring(Convert.ToInt32(rdbuilding_.SelectedValue) - 1, 1) != "1")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('You have no permission to access this building!');", true);
                return;
            }
            ModalPopupExtender2.Hide();
            string _prm = drservice_.SelectedItem.Value + "_P" + lblprj.Text;
            string _div = rdbuilding_.SelectedValue;
            Session["srv"] = drservice_.SelectedItem.Value;
            Session["srv_name"] = drservice_.SelectedItem.Text;
            Response.Redirect("Service_Summary.aspx?id=" + _prm + "&div=" + _div);
            Session["type"] = "2";
        }
        protected void btncancel1_Click(object sender, EventArgs e)
        {
            ModalPopupExtender2.Hide();
        }
        protected void btncancel3_Click(object sender, EventArgs e)
        {

            btnDummy_ModalPopupExtendersummary.Hide();
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if (dr_services.SelectedValue == "") return;
            if (drcst.SelectedValue == "") return;
            if (rdbuilding_1.SelectedValue == "") return;
            string _permission = Get_BuildingPermission();
            if (_permission.Substring(Convert.ToInt32(rdbuilding_1.SelectedValue) - 1, 1) != "1")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('You have no permission to access this building!');", true);
                return;
            }
            Session["ser_name"] = dr_services.SelectedValue;
            Session["sch"] = drcst.SelectedItem.Value;
            string _prm = "";

            _prm = drcst.SelectedItem.Value + "_P" + lblprj.Text + "_D" + rdbuilding.SelectedValue.ToString();
            Response.Redirect("Summary.aspx?id=1" + _prm);

        }
        protected void LOAD_CASSHEET_SUMMARY()
        {
            if (dr_services.SelectedItem.Text == "--Select Service--")
                return;
            drcst.Items.Clear();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            DataTable _dtable;
            if (lblprj.Text == "HMIM")
            {
                _clstis _objcls = new _clstis();
                _objcls.bldg_id = Convert.ToInt32(rdbuilding_1.SelectedValue.ToString());
                _dtable = _objbll.Load_Prj_Cassheet_Bldng(_objcls, _objdb);
            }
            else
                _dtable = _objbll.Load_Prj_Cassheet(_objdb);
            string _masterid = dr_services.SelectedItem.Value;
            var _id = from o in _dtable.AsEnumerable()
                      where o.Field<int>(2) == Convert.ToInt32(_masterid)
                      select o;
            foreach (var row in _id)
            {
                ListItem _lst = new ListItem();
                _lst.Text = row[1].ToString();
                _lst.Value = row[0].ToString();
                drcst.Items.Add(_lst);
            }
            drcst.Items.Insert(0, "--Select Cas Sheet--");
            //drcassheet.DataSource = _objbll.Load_Prj_Cassheet(_objdb);
            drcst.DataBind();
        }
        protected void dr_services_SelectedIndexChanged(object sender, EventArgs e)
        {
            LOAD_CASSHEET_SUMMARY();
            drcst.ClearSelection();

        }
        protected void rd_package_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Facility(Convert.ToInt32(rd_package.SelectedValue));
            rd_facility.Enabled = true;
            
        }
        protected void rd_package1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Facility(Convert.ToInt32(rd_package1.SelectedValue));
            rd_facility1.Enabled = true;

        }
        protected void rd_package2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Facility(Convert.ToInt32(rd_package2.SelectedValue));
            rd_facility2.Enabled = true;
        }
        protected void rd_facility_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }
        protected void rd_facility1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rd_service.Enabled = true;

        }
        protected void rd_facility2_SelectedIndexChanged(object sender, EventArgs e)
        {
            rd_service1.Enabled = true;
        }

        protected void rd_service1_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_Casheet(Convert.ToInt32(rd_service1.SelectedItem.Value.ToString()));
            rd_cassheet.Enabled = true;

        }
        private void load_Casheet(int _pkg_id)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            DataTable _dtcasheet = _objbll.Load_Prj_Cassheet(_objdb);


            var _result = _dtcasheet.Select("SYS_SER_ID =" + _pkg_id);
            DataTable _dtresult = _result.Any() ? _result.CopyToDataTable() : _dtcasheet.Clone();

            rd_cassheet.DataSource = _dtresult;
            rd_cassheet.DataTextField = "PRJ_CAS_NAME";
            rd_cassheet.DataValueField = "PRJ_CAS_ID";
            rd_cassheet.DataBind();
            rd_cassheet.Items.Insert(0, "--Select Cas Sheet--");





        }
        private void Load_Facility(int _pkg_id)
        {
            var _result = _dtmaster.Select("PKG_ID =" + _pkg_id);
            DataTable _dtresult = _result.Any() ? _result.CopyToDataTable() : _dtmaster.Clone();
            rd_facility.Enabled = true;
            rd_facility.Items.Clear();
            rd_facility.DataSource = _dtresult;
            rd_facility.DataTextField = "FCLTY";
            rd_facility.DataValueField = "FCLTY_ID";
            rd_facility.DataBind();
            rd_facility.Items.Insert(0, "--Select Facility--");

            rd_facility1.Enabled = true;
            rd_facility1.Items.Clear();
            rd_facility1.DataSource = _dtresult;
            rd_facility1.DataTextField = "FCLTY";
            rd_facility1.DataValueField = "FCLTY_ID";
            rd_facility1.DataBind();
            rd_facility1.Items.Insert(0, "--Select Facility--");

            rd_facility2.Enabled = true;
            rd_facility2.Items.Clear();
            rd_facility2.DataSource = _dtresult;
            rd_facility2.DataTextField = "FCLTY";
            rd_facility2.DataValueField = "FCLTY_ID";
            rd_facility2.DataBind();
            rd_facility2.Items.Insert(0, "--Select Facility--");

        }

        protected void btnenter3_Click(object sender, EventArgs e)
        {

            if (rd_package.SelectedItem.Text == "--Select Package--" || rd_package.SelectedValue == "") return;
            if (rd_facility.SelectedItem.Text == "--Select Facility--" || rd_facility.SelectedValue == "") return;

            //if (rd_facility.SelectedValue == "") return;
            //if (rd_package.SelectedValue == "") return;

            //string _permission = Get_BuildingPermission();
            //if (_permission.Substring(Convert.ToInt32(rdbuilding.SelectedValue) - 1, 1) != "1")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('You have no permission to access this building!');", true);
            //    return;
            //}
            ModalPopupExtender3.Hide();
            string _div = rd_facility.SelectedValue;
            Session["srv"] = "project";
            string _prm = "0_P" + lblprj.Text;
            Response.Redirect("Service_Summary.aspx?id=" + _prm + "&div=" + _div);
            Session["type"] = "1";
            DisableFields_14211();

        }
        protected void btnenter4_Click(object sender, EventArgs e)
        {

            if (rd_package1.SelectedItem.Text == "--Select Package--" || rd_package1.SelectedValue == "") return;
            if (rd_facility1.SelectedItem.Text == "--Select Facility--" || rd_facility1.SelectedValue == "") return;
            if (rd_service.SelectedItem.Text == "--Select Service--" || rd_service.SelectedValue == "") return;
          
            //if (rd_service.SelectedValue == "") return;
            //if (rd_facility1.SelectedValue == "") return;
            //if (rd_package1.SelectedValue == "") return;

            //string _permission = Get_BuildingPermission();
            //if (_permission.Substring(Convert.ToInt32(rdbuilding_.SelectedValue) - 1, 1) != "1")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('You have no permission to access this building!');", true);
            //    return;
            //}
            ModalPopupExtender4.Hide();
            string _prm = rd_service.SelectedItem.Value + "_P" + lblprj.Text;
            string _div = rd_facility1.SelectedValue;
            Session["srv"] = rd_service.SelectedItem.Value;
            Session["srv_name"] = rd_service.SelectedItem.Text;
            Response.Redirect("Service_Summary.aspx?id=" + _prm + "&div=" + _div);
            Session["type"] = "2";
            DisableFields_14211();

        }
        protected void btnenter5_Click(object sender, EventArgs e)
        {
            if (rd_package2.SelectedItem.Text == "--Select Package--" || rd_package2.SelectedValue == "") return;
            if (rd_facility2.SelectedItem.Text == "--Select Facility--" || rd_facility2.SelectedValue == "") return;
            if (rd_service1.SelectedItem.Text == "--Select Service--" || rd_service1.SelectedValue == "") return;
            if (rd_cassheet.SelectedItem.Text == "--Select Cas Sheet--" || rd_cassheet.SelectedValue == "") return;
            //if (rd_service1.SelectedValue == "") return;
            //if (rd_cassheet.SelectedValue == "") return;
            //if (rd_facility2.SelectedValue == "") return;
            //if (rd_package2.SelectedValue == "") return;
            //string _permission = Get_BuildingPermission();
            //if (_permission.Substring(Convert.ToInt32(rdbuilding_1.SelectedValue) - 1, 1) != "1")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('You have no permission to access this building!');", true);
            //    return;
            //}
            ModalPopupExtender5.Show();
            Session["ser_name"] = rd_service1.SelectedValue;
            Session["sch"] = rd_cassheet.SelectedItem.Value;
            string _prm = "";

            _prm = rd_cassheet.SelectedItem.Value + "_P" + lblprj.Text + "_D" + rd_facility2.SelectedValue.ToString();
            Response.Redirect("Summary.aspx?id=1" + _prm);
            DisableFields_14211();

        }
        protected void btncancelc3_Click(object sender, EventArgs e)
        {
            ModalPopupExtender3.Hide();
            DisableFields_14211();
        }
        protected void btncancel4_Click(object sender, EventArgs e)
        {
            ModalPopupExtender4.Hide();
            DisableFields_14211();
        }
        protected void btncancel5_Click(object sender, EventArgs e)
        {
            ModalPopupExtender5.Hide();
            DisableFields_14211();
        }
        protected void btnsocommentlog_Click(object sender, EventArgs e)
        {
            string _path = "Reports.aspx?id=socmtlog&idx=" + TabContainer1.ActiveTabIndex.ToString() + "&prj=" + lblprj.Text;
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.open('" + _path + "');", true);
        }
        protected void btndrcommentlog_Click(object sender, EventArgs e)
        {
            string _path = "Reports.aspx?id=cmtlogdr&idx=" + TabContainer1.ActiveTabIndex.ToString() + "&prj=" + lblprj.Text;
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.open('" + _path + "');", true);
        }
        protected void btnprjsum_planned_Click(object sender, EventArgs e)  
        {
            Session["srv"] = "project";
            string _prm = "9_P" + lblprj.Text;
            Response.Redirect("Service_Summary.aspx?id=" + _prm);
            Session["type"] = "9";
        }
         protected void btnexecutivesum_Click(object sender, EventArgs e)   
        {
            Response.Redirect("ExecutiveSummaryReport_PCD.aspx?prj=" + lblprj.Text);
             
         }
       
    }
}
