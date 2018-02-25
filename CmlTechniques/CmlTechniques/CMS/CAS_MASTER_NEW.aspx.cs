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
    public partial class CAS_MASTER_NEW : System.Web.UI.Page
    {
        public static DataTable _dtmaster;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                menu.Visible = false;
                lblprj.Text = Request.QueryString["prj"].ToString();
                //lbluser.Text = Request.QueryString["auh"].ToString();
                lbluser.Text = (string)Session["uid"];
                lblsch.Text = Request.QueryString["sch"].ToString();
                prj.Text = Get_ProjectName();
                Setup();
                m1.Attributes.Add("class", "selected");
                if (lblprj.Text == "HMIM") BuildingPermission();
            }
        }
        private void BuildingPermission()
        {

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.sch = Convert.ToInt32(lblsch.Text);
            DataTable _dtpermission = _objbll.Get_CAS_BuildingPermission(_objcls, _objdb);

            foreach (DataRow dRow in _dtpermission.Rows)
            {
                //rdbuilding.Items[0].Enabled = Convert.ToBoolean(dRow["CUC"].ToString());
                //rdbuilding.Items[1].Enabled = Convert.ToBoolean(dRow["PIAZZA"].ToString());
                //rdbuilding.Items[2].Enabled = Convert.ToBoolean(dRow["SERVICE"].ToString());
                //rdbuilding.Items[3].Enabled = Convert.ToBoolean(dRow["HARAM"].ToString());
                if (!Convert.ToBoolean(dRow["CUC"].ToString())) { rdbuilding.Items[0].Enabled = false; rdbuilding.Items[0].Attributes.Add("style", "color:#cccccc"); }
                if (!Convert.ToBoolean(dRow["PIAZZA"].ToString())) { rdbuilding.Items[1].Enabled = false; rdbuilding.Items[1].Attributes.Add("style", "color:#cccccc"); }
                if (!Convert.ToBoolean(dRow["SERVICE"].ToString())) { rdbuilding.Items[2].Enabled = false; rdbuilding.Items[2].Attributes.Add("style", "color:#cccccc"); }
                if (!Convert.ToBoolean(dRow["HARAM"].ToString())) { rdbuilding.Items[3].Enabled = false; rdbuilding.Items[3].Attributes.Add("style", "color:#cccccc"); }
            }
        }
        void _ReadCookies()
        {
            if (Request.Browser.Cookies)
            {

                if (Request.Cookies["project"] != null)
                {
                    Session["project"] = Server.HtmlEncode(Request.Cookies["project"].Value);
                }
                if (Request.Cookies["uid"] != null)
                {
                    Session["uid"] = Server.HtmlEncode(Request.Cookies["uid"].Value);
                }

            }
        }
        private void Permission()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();
            _objdb.DBName = "dbCML";
            _objcls.uid = lbluser.Text;
            _objcls.project_code = lblprj.Text;
            //string _access = _objbll.Get_User_cmsAccess(_objcls, _objdb);
            lblpermission.Text = _objbll.Get_User_cmsAccess(_objcls, _objdb);

            if (lblpermission.Text != "Admin")
            {

                Load_FullSchedule();
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "Changemenu(1);", true);
                m1.Visible = false;
                m2.Visible = false;
            }
            else
            {

                string _prm = lblprj.Text + "_S" + lblsch.Text + "_F" + facid.Text;
                if (lblsch.Text=="20")
                    myframe1.Attributes.Add("src", "../Cassheet_DataEntry_BMS.aspx?id=" + _prm);
                else
                    myframe1.Attributes.Add("src", "../Cassheet_DataEntry.aspx?id=" + _prm);
                //myframe1.Attributes.Add("src", "../CasDataEntry_New.aspx?id=" + _prm);
            }
        }
        private string Get_ProjectName()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            return _objbll.Get_ProjectName(_objcls, _objdb);
        }
        private void Setup()
        {
            Load_Packages(lblprj.Text);
            if (lblprj.Text == "14211")
            {
                Load_Service(lblprj.Text);
            
                rd_facility.Enabled = false;
                rd_service.Enabled = false;
                rd_Casheet.Enabled = false;

                //btnenter.Enabled = false;
                string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
            }
            else if (lblprj.Text == "HMIM")
            {
                //btnenter1.Visible = false;
                string script = "function f(){$find(\"" + RadWindow2.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
            }
            else if (lblprj.Text == "HMHS")
            {
                //btnenter1.Visible = false;
                string script = "function f(){$find(\"" + RadWindow3.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
            }

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
            _dtmaster = _objbll.Load_Facility(_objdb);
        }
        private void Load_Service(string _prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + _prj;
            DataTable _dtser = _objbll.Load_Prj_Service(_objdb);

            rd_service.DataSource = _dtser;
            rd_service.DataTextField = "PRJ_SER_NAME";
            rd_service.DataValueField = "PRJ_SER_ID";
            rd_service.DataBind();

        }
        private void load_Casheet(int _pkg_id)
        {
           BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            DataTable _dtcasheet = _objbll.Load_Prj_Cassheet(_objdb);


            var _result = _dtcasheet.Select("SYS_SER_ID =" + _pkg_id);
            DataTable _dtresult = _result.Any() ? _result.CopyToDataTable() : _dtcasheet.Clone();

            rd_Casheet.DataSource = _dtresult;
            rd_Casheet.DataTextField = "PRJ_CAS_NAME";
            rd_Casheet.DataValueField = "PRJ_CAS_ID";
            rd_Casheet.DataBind();
        }

        protected void rd_package_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            Load_Facility(Convert.ToInt32(rd_package.SelectedValue));
            rd_service.Enabled = true;
           
        }
        protected void rd_facility_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            //btnenter.Visible = true;
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
        }
        protected void btnenter_Click(object sender, EventArgs e)
        {
            if (rd_facility.SelectedValue == "") return;
            if (rd_Casheet.SelectedValue == "") return;

            lblsch.Text = rd_Casheet.SelectedItem.Value.ToString();

            facid.Text = rd_facility.SelectedValue;
            package.Text ="FACILITY : " + rd_package.SelectedItem.Text + " - " + rd_facility.SelectedItem.Text;
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
            string _prm = "";
            if (lblprj.Text == "14211")
            {
                _prm = lblprj.Text + "_S" + rd_Casheet.SelectedItem.Value.ToString()+ "_F" + rd_facility.SelectedItem.Value.ToString();
            }
            else
                _prm=lblprj.Text + "_S" + lblsch.Text;

         

            if ((lblprj.Text == "14211" || lblprj.Text == "HMIM") && lblsch.Text=="20")
            {
                myframe1.Attributes.Add("src", "../Cassheet_DataEntry_BMS.aspx?id=" + _prm);
            }
            else
                myframe1.Attributes.Add("src", "../Cassheet_DataEntry.aspx?id=" + _prm);
            menu.Visible = true;
        }
        protected void btnaction_Click(object sender, EventArgs e)
        {
            string _url = "";
            m1.Attributes.Remove("class");
            m2.Attributes.Remove("class");
            m3.Attributes.Remove("class");
            m4.Attributes.Remove("class");
            if (lblprj.Text == "HMIM" || lblprj.Text=="HMHS")
                _url = lblprj.Text + "_S" + lblsch.Text + "_F" + facid.Text;
            else if (lblprj.Text == "14211")
                _url = lblprj.Text + "_S" + lblsch.Text + "_F" + rd_facility.SelectedItem.Value.ToString();
            else
                _url = lblprj.Text + "_S" + lblsch.Text;
            if (hiddenmode.Value == "1")
            {
                m1.Attributes.Add("class", "selected");
                if ((lblprj.Text == "14211"  ||lblprj.Text == "HMIM" || lblprj.Text == "HMHS")&& lblsch.Text == "20")
                {
                    myframe1.Attributes.Add("src", "../Cassheet_DataEntry_BMS.aspx?id=" + _url);
                }
                else
                myframe1.Attributes.Add("src", "../Cassheet_DataEntry.aspx?id=" + _url);
            }
            else if (hiddenmode.Value == "2")
            {
                m2.Attributes.Add("class", "selected");
                if (lblprj.Text == "14211" || lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                {
                    if (lblsch.Text == "20")
                        myframe1.Attributes.Add("src", "Commissioning_Testing_BMS.aspx?id=" + _url);
                    else if (lblsch.Text == "30" || lblsch.Text == "12" || lblsch.Text == "13" || lblsch.Text == "22" || lblsch.Text == "32" || lblsch.Text == "31" || lblsch.Text == "33" || lblsch.Text == "29" || lblsch.Text == "11" || lblsch.Text == "28" || lblsch.Text == "39" || lblsch.Text == "34" || lblsch.Text == "37" || lblsch.Text == "35" || lblsch.Text == "15" || lblsch.Text == "11" || lblsch.Text == "14" || lblsch.Text == "9" || lblsch.Text == "10" || lblsch.Text == "27")
                        myframe1.Attributes.Add("src", "CAS_Commissioning.aspx?id=" + _url);
                    else
                        myframe1.Attributes.Add("src", "Commissiong_Testing.aspx?id=" + _url);
                }
                else
                    myframe1.Attributes.Add("src", "Commissiong_Testing.aspx?id=" + _url);
            }
            else if (hiddenmode.Value == "3")
            {
                m3.Attributes.Add("class", "selected");
                Load_FullSchedule();
            }
            else if (hiddenmode.Value == "4")
            {
                m4.Attributes.Add("class", "selected");
                if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS" || lblprj.Text == "14211")
                    _url = lblsch.Text + "_P" + lblprj.Text + "_F" + facid.Text;
                else
                    _url = lblsch.Text + "_P" + lblprj.Text;
                myframe1.Attributes.Add("src", "Summary.aspx?id=0" + _url);
            }
        }
        private void Load_FullSchedule()
        {
            Session["sch_id"] = lblsch.Text;
            if (lblsch.Text == "5" || lblsch.Text == "1")
            {
                myframe1.Attributes.Add("src", "caslvreport.aspx?id=" + lblprj.Text + "_F" + facid.Text);
            }
            else if (lblsch.Text == "44")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "caslv1report.aspx?id=44_P" + lblprj.Text);
            }
            else if (lblsch.Text == "2")
            {
                if (lblprj.Text == "HMIM")
                {
                    myframe1.Attributes.Add("src", "casmvhvreport.aspx?id=" + lblprj.Text + "_F" + facid.Text);
                }
                else
                {
                    myframe1.Attributes.Add("src", "casmvreport.aspx?id=" + lblprj.Text + "_F" + facid.Text);
                }
            }
            else if (lblsch.Text == "121")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casmv1report.aspx?id=121_P" + lblprj.Text);
            }
            else if (lblsch.Text == "119")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casmv1report.aspx?id=119_P" + lblprj.Text);
            }
            else if (lblsch.Text == "118")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casmv1report.aspx?id=118_P" + lblprj.Text);
            }
            else if (lblsch.Text == "3" || lblsch.Text == "120")
            {
                myframe1.Attributes.Add("src", "castransreport.aspx?id=" + lblprj.Text + "_F" + facid.Text);
                //myframe1.Attributes.Add("src", "castransreport.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text);
            }
            else if (lblsch.Text == "4")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casgen1report.aspx?id=" + lblprj.Text);
                //else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                //    myframe1.Attributes.Add("src", "casgenreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else
                    myframe1.Attributes.Add("src", "casgenreport.aspx?id=" + lblprj.Text + "_F" + facid.Text);
            }
            else if (lblsch.Text == "6")
            {
                myframe1.Attributes.Add("src", "caselpreport.aspx?id=" + lblprj.Text + "_F" + facid.Text);
            }
            else if (lblsch.Text == "7")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casemg1report.aspx?id=" + lblprj.Text);
                if (lblprj.Text == "ASAO")
                    myframe1.Attributes.Add("src", "casemg2report.aspx?id=" + lblprj.Text);
                //else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                //    myframe1.Attributes.Add("src", "casemgreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else
                    myframe1.Attributes.Add("src", "casemgreport.aspx?id=" + lblprj.Text+ "_F" + facid.Text);
            }
            else if (lblsch.Text == "8")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=8_P" + lblprj.Text);
                //else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                //    myframe1.Attributes.Add("src", "casmereport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "14211" || lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                    myframe1.Attributes.Add("src", "casmereport.aspx?id=" + lblprj.Text + "_F" + facid.Text);
                else
                    myframe1.Attributes.Add("src", "casmereport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "51")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=51_P" + lblprj.Text);
            }
            else if (lblsch.Text == "52")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=52_P" + lblprj.Text);
            }
            else if (lblsch.Text == "53")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=53_P" + lblprj.Text);
            }
            else if (lblsch.Text == "54")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=54_P" + lblprj.Text);
            }
            else if (lblsch.Text == "55")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=55_P" + lblprj.Text);
            }
            else if (lblsch.Text == "56")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=56_P" + lblprj.Text);
            }
            else if (lblsch.Text == "57")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=57_P" + lblprj.Text);
            }
            else if (lblsch.Text == "58")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=58_P" + lblprj.Text);
            }
            else if (lblsch.Text == "59")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=59_P" + lblprj.Text);
            }
            else if (lblsch.Text == "60")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=60_P" + lblprj.Text);
            }
            else if (lblsch.Text == "61")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=61_P" + lblprj.Text);
            }
            else if (lblsch.Text == "62")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=62_P" + lblprj.Text);
            }
            else if (lblsch.Text == "63")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=63_P" + lblprj.Text);
            }
            else if (lblsch.Text == "64")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=64_P" + lblprj.Text);
            }
            else if (lblsch.Text == "65")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=65_P" + lblprj.Text);
            }
            else if (lblsch.Text == "66")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=66_P" + lblprj.Text);
            }
            else if (lblsch.Text == "67")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=67_P" + lblprj.Text);
            }
            else if (lblsch.Text == "68")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=68_P" + lblprj.Text);
            }
            else if (lblsch.Text == "69")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=69_P" + lblprj.Text);
            }
            else if (lblsch.Text == "70")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=70_P" + lblprj.Text);
            }
            else if (lblsch.Text == "71")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=71_P" + lblprj.Text);
            }
            else if (lblsch.Text == "72")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=72_P" + lblprj.Text);
            }
            else if (lblsch.Text == "73")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=73_P" + lblprj.Text);
            }
            else if (lblsch.Text == "74")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=74_P" + lblprj.Text);
            }
            else if (lblsch.Text == "75")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=75_P" + lblprj.Text);
            }
            else if (lblsch.Text == "76")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=76_P" + lblprj.Text);
            }
            else if (lblsch.Text == "77")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=77_P" + lblprj.Text);
            }
            else if (lblsch.Text == "78")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=78_P" + lblprj.Text);
            }
            else if (lblsch.Text == "79")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=79_P" + lblprj.Text);
            }
            else if (lblsch.Text == "80")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=80_P" + lblprj.Text);
            }
            else if (lblsch.Text == "81")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=81_P" + lblprj.Text);
            }
            else if (lblsch.Text == "82")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=82_P" + lblprj.Text);
            }
            else if (lblsch.Text == "83")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=83_P" + lblprj.Text);
            }
            else if (lblsch.Text == "84")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=84_P" + lblprj.Text);
            }
            else if (lblsch.Text == "9")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=" + lblprj.Text);
                //else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                //    myframe1.Attributes.Add("src", "casfdreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "14211" || lblprj.Text =="HMIM")
                     myframe1.Attributes.Add("src", "casfdreport_HMIM.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text);
                else
                    myframe1.Attributes.Add("src", "casfdreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "10")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "../CAS/cas3Creport.aspx?id=" + lblprj.Text);
                //else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                //    myframe1.Attributes.Add("src", "casfavareport2.aspx?id=10_P" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS" || lblprj.Text=="14211")
                    myframe1.Attributes.Add("src", "casfavareport3.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text + "&Sch=" + lblsch.Text);
                else
                    myframe1.Attributes.Add("src", "casfavareport.aspx?id=10_P" + lblprj.Text);
            }
            else if (lblsch.Text == "11")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "../CAS/cas3Dreport.aspx?id=" + lblprj.Text);
                //else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                //    myframe1.Attributes.Add("src", "caslcsreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "14211" || lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                    myframe1.Attributes.Add("src", "caslcsreport1.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text);
                else
                    myframe1.Attributes.Add("src", "caslcsreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "12")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3Freport.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "14211")
                    myframe1.Attributes.Add("src", "casictreport.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text);
                  else if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                    myframe1.Attributes.Add("src", "casscnreport_HMIM.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text);
                //else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                //    myframe1.Attributes.Add("src", "casscnreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else
                    myframe1.Attributes.Add("src", "casscnreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "13")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3Hreport.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "14211" || lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                    myframe1.Attributes.Add("src", "cascctvreport1.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text);
                else
                    myframe1.Attributes.Add("src", "cascctvreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "17" || lblsch.Text == "85" || lblsch.Text == "86" || lblsch.Text == "87" || lblsch.Text == "88" || lblsch.Text == "89" || lblsch.Text == "90" || lblsch.Text == "91" || lblsch.Text == "99" || lblsch.Text == "107" || lblsch.Text == "108" || lblsch.Text == "117")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas4Areport.aspx?id=" + lblsch.Text + "_P" + lblprj.Text);
                //else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                //    myframe1.Attributes.Add("src", "casph1report.aspx?prj=" + lblprj.Text + "&div=" + lbldiv.Text + "&sch=17");
                else if (lblprj.Text == "14211" || lblprj.Text=="HMIM")
                {
                    myframe1.Attributes.Add("src", "casph1report.aspx?prj=" + lblprj.Text + "&div=" + facid.Text + "&sch=" + lblsch.Text);
                }
                else
                    myframe1.Attributes.Add("src", "casph1report.aspx?prj=" + lblprj.Text + "&div=0&sch=17");
            }

            else if (lblsch.Text == "18" || lblsch.Text == "101" || lblsch.Text == "97" || lblsch.Text == "95")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas4Breport.aspx?id=" + lblsch.Text + "_P" + lblprj.Text);
                //else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                //    myframe1.Attributes.Add("src", "casph2report.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else
                    //myframe1.Attributes.Add("src", "casph2report.aspx?id=" + lblprj.Text + "_F" + facid.Text);
                    myframe1.Attributes.Add("src", "casph2report.aspx?prj=" + lblprj.Text + "&div=" + facid.Text);
            }
            else if (lblsch.Text == "19" || lblsch.Text == "102")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas4Creport.aspx?id=" + lblprj.Text);
                //else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                //    myframe1.Attributes.Add("src", "casph3report.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                //else if (lblprj.Text == "14211")
                //    myframe1.Attributes.Add("src", "casph3report.aspx?prj=" + lblprj.Text + "&div=" + facid.Text);
                else
                    myframe1.Attributes.Add("src", "casph3report.aspx?prj=" + lblprj.Text + "&div=" + facid.Text);
            }
            else if (lblsch.Text == "20")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casbms1report.aspx?id=" + lblprj.Text);
                //else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                //    myframe1.Attributes.Add("src", "casbmsreport.aspx?id=20_P" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "14211" || lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                {
                    myframe1.Attributes.Add("src", "casbmsreport2.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text);
                }
                else
                    myframe1.Attributes.Add("src", "casbmsreport.aspx?id=20_P" + lblprj.Text);
            }
            else if (lblsch.Text == "21")
                if (lblprj.Text == "14211" || lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                    myframe1.Attributes.Add("src", "casflureport.aspx?id=" + lblprj.Text + "_D" + facid.Text);
                else
                myframe1.Attributes.Add("src", "casflureport.aspx?id=" + lblprj.Text);
            else if (lblsch.Text == "22")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3Ereport.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "14211")
                    myframe1.Attributes.Add("src", "casacsreport1.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text);
                //else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                //    myframe1.Attributes.Add("src", "casacsreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else
                    myframe1.Attributes.Add("src", "casacsreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "15")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3Greport.aspx?id=" + lblprj.Text);
                else  if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                        myframe1.Attributes.Add("src", "casgrmsreport_HMIM.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text);
                else
                    myframe1.Attributes.Add("src", "casgrmsreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "14")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3jreport.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                      myframe1.Attributes.Add("src", "casavireport_HMIM.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text);
                else
                    myframe1.Attributes.Add("src", "casavireport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "23")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3Breport.aspx?id=" + lblprj.Text);
                //else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                //    myframe1.Attributes.Add("src", "casbatterychargesreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "12761")
                    myframe1.Attributes.Add("src", "CasFullScheduleReport23.aspx?id=" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "caslereport.aspx?id=23&prj=" + lblprj.Text + "&fcl=" + rd_facility.SelectedItem.Value.ToString());
            }
            else if (lblsch.Text == "16")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3Ireport.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                    myframe1.Attributes.Add("src", "caselvreport.aspx?id=" + lblprj.Text + "_F" + facid.Text);
                else
                    myframe1.Attributes.Add("src", "caselvreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "24")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3Kreport.aspx?id=" + lblprj.Text);
                //else if (lblprj.Text == "11736")
                //    myframe1.Attributes.Add("src", "casph1report.aspx?prj=" + lblprj.Text + "&div=" + lbldiv.Text + "&sch=24");
                else if (lblprj.Text == "12761")
                    myframe1.Attributes.Add("src", "CasFullScheduleReportCP.aspx?id=" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "casklereport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "30")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=30_P" + lblprj.Text);
                else if (lblprj.Text == "14211")
                    myframe1.Attributes.Add("src", "casvcsreport.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text);
                else
                    myframe1.Attributes.Add("src", "casdfsreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "25")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3Lreport.aspx?id=" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "casacmreport.aspx?id=25_P" + lblprj.Text);
            }
            else if (lblsch.Text == "27" || lblsch.Text == "103" || lblsch.Text == "104" || lblsch.Text == "105" || lblsch.Text == "106" || lblsch.Text == "109" || lblsch.Text == "110" || lblsch.Text == "111")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas5Areport.aspx?id=" + lblsch.Text + "_P" + lblprj.Text);
                else if (lblprj.Text == "12761")
                    myframe1.Attributes.Add("src", "caslereport.aspx?id=27&prj=" + lblprj.Text);
                else if (lblprj.Text == "HMIM")
                    myframe1.Attributes.Add("src", "casHvtreport.aspx?id=27&prj=" + lblprj.Text + "&FID=" + facid.Text);
                else
                    myframe1.Attributes.Add("src", "casacmreport.aspx?id=27_P" + lblprj.Text);
            }
            else if (lblsch.Text == "112" || lblsch.Text == "113" || lblsch.Text == "114" || lblsch.Text == "115" || lblsch.Text == "116")
            {
                myframe1.Attributes.Add("src", "cas5ReportNew.aspx?id=" + lblsch.Text + "_P" + lblprj.Text);
            }
            else if (lblsch.Text == "46")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas5Areport.aspx?id=46_P" + lblprj.Text);
            }
            else if (lblsch.Text == "26")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3Mreport.aspx?id=" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "casccsreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "28")
            {
                if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                myframe1.Attributes.Add("src", "casfavareport3.aspx?id=28&Prj=" + lblprj.Text + "&Fid=" + facid.Text + "&Sch=" + lblsch.Text);
                else  if (lblprj.Text == "14211")
                    myframe1.Attributes.Add("src", "casAVSreport.aspx?id=28&Prj=" + lblprj.Text + "&Fid=" + facid.Text);

            }
            else if (lblsch.Text == "29")
            {
                if (lblprj.Text == "14211")
                {
                   myframe1.Attributes.Add("src", "casIPTVreport.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text);
                   
                    

                }
            }
            else if (lblsch.Text == "34")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    string _prm = lblprj.Text + "_S" + lblsch.Text;
                    myframe1.Attributes.Add("src", "cassitreport.aspx?id=" + _prm);
                }
                else if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=34_P" + lblprj.Text);
                else if (lblprj.Text == "14211")
                    myframe1.Attributes.Add("src", "casUPSCreport.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text);
                else
                    myframe1.Attributes.Add("src", "caspfsreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "35")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    string _prm = lblprj.Text + "_S" + lblsch.Text;
                    myframe1.Attributes.Add("src", "cassitreport.aspx?id=" + _prm);
                }
                else if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=35_P" + lblprj.Text);
                else if (lblprj.Text == "14211")
                    myframe1.Attributes.Add("src", "casFUELreport.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text);
                else
                    myframe1.Attributes.Add("src", "casvslreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "36")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=36_P" + lblprj.Text);
                else if (lblprj.Text == "HMIM")
                    myframe1.Attributes.Add("src", "caseotreport.aspx?id=" + lblprj.Text + "&FID=" + facid.Text);
                else
                    myframe1.Attributes.Add("src", "caseotreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "33")
            {
                if (lblprj.Text == "14211")
                {
                    myframe1.Attributes.Add("src", "casMCSreport.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text);

                }
            }
            else if (lblsch.Text == "32")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=32_P" + lblprj.Text);
                if (lblprj.Text == "14211")
                {
                    myframe1.Attributes.Add("src", "casTetraeport.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text);

                }
                else
                    myframe1.Attributes.Add("src", "casbmsreport.aspx?id=32_P" + lblprj.Text);
            }
            else if (lblsch.Text == "31")
            {
                if (lblprj.Text == "14211")
                {
                    //myframe1.Attributes.Add("src", "casCSSreport.aspx?id=" + lblprj.Text + "_F" + facid.Text);
                    myframe1.Attributes.Add("src", "casCSSreport.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text);

                }
            }
            else if (lblsch.Text == "37")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=37_P" + lblprj.Text);
                else if (lblprj.Text == "14211")
                 myframe1.Attributes.Add("src", "casSASreport.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text);
                else
                    myframe1.Attributes.Add("src", "casbcreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "38")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=38_P" + lblprj.Text);
            }
            else if (lblsch.Text == "39")
            {
                if (lblprj.Text == "14211")
                {
                    //myframe1.Attributes.Add("src", "casTetraeport.aspx?id=" + lblprj.Text + "_F" + facid.Text);
                    myframe1.Attributes.Add("src", "casCPMreport.aspx?PRJ=" + lblprj.Text + "&FID=" + facid.Text);

                }
            }
            else if (lblsch.Text == "40")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=40_P" + lblprj.Text);
            }
            else
                myframe1.Attributes.Add("src", "");
            //if((string)Session["project"]=="BCC1")
            //    if (lblsch.Text == "1")
            //        myframe1.Attributes.Add("src", "caslvreport.aspx");
        }
        protected void rdbuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btnenter1.Visible = true;
        }
        protected void btnenter1_Click(object sender, EventArgs e)
        {
            facid.Text = rdbuilding.SelectedValue;
            package.Text = "BUILDING : " + rdbuilding.SelectedItem.Text;
            string script = "function f(){$find(\"" + RadWindow2.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
            
            Permission();
            //myframe1.Attributes.Add("src", "../Cassheet_DataEntry.aspx?id=" + _prm);
            menu.Visible = true;
        }
        protected void rd_service_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_Casheet(Convert.ToInt32(rd_service.SelectedItem.Value.ToString()));
            rd_Casheet.Enabled = true;
        }
        protected void rd_Casheet_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void btnenter2_Click(object sender, EventArgs e)
        {
            //string _permission = Get_BuildingPermission();
            //if (_permission.Substring(Convert.ToInt32(rdbuilding1.SelectedValue) - 1, 1) != "1")
            //{
            //    RadNotification1.Show();
            //    return;
            //}
            facid.Text = rdbuilding1.SelectedValue;
            package.Text = "BUILDING : " + rdbuilding1.SelectedItem.Text;
            string script = "function f(){$find(\"" + RadWindow3.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);

            Permission();
            //myframe1.Attributes.Add("src", "../Cassheet_DataEntry.aspx?id=" + _prm);
            menu.Visible = true;
        }
    }
}
