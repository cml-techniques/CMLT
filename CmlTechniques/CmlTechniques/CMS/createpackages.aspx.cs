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
    public partial class createpackages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                lblprj.Text = _prm;
                Load_services();
            }
        }
        protected void Load_services()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            //_objdb.DBName = "DBCML";
            drservice.DataSource = _objbll.Load_Cas_service(_objdb);
            drservice.DataTextField = "PRJ_SER_NAME";
            drservice.DataValueField = "SYS_SER_ID";
            drservice.DataBind();
            Load_SubFolder();    
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (Isnullvalidation() == true) return;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clspackage _objcls = new _clspackage();
            _objcls.package = txtpackage.Text;
            _objcls.category = txtcode.Text;
            _objcls.sch_id = Convert.ToInt32(drsub.SelectedItem.Value);
            _objcls.project = lblprj.Text;
            //_objcls.record_sheet = Convert.ToInt32(drrdsheet.SelectedItem.Value);
            _objcls.record_sheet = 0;
            _objcls.sys_id = 0;
            _objcls.mode = 1;
            _objbll.create_package(_objcls, _objdb);

            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DBCML";
            //_clspackage _objcls = new _clspackage();
            //_objcls.package = txtpackage.Text;
            //_objcls.category = txtcode.Text;
            //_objcls.sch_id = Convert.ToInt32(drsub.SelectedItem.Value);
            //_objbll.CREATE_SYSCASPKG(_objcls, _objdb);
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Package Created');", true);
            txtpackage.Text = "";
            txtcode.Text = "";
        }
        private bool Isnullvalidation()
        {
            if (drsub.SelectedItem.Text == "-- Select --")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Package');", true);
                return true;
            }
            return false;
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

        protected void drservice_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_SubFolder();
        }
        protected void Load_SubFolder()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            //_objdb.DBName = "DBCML";
            _clsFolderTree _objcls = new _clsFolderTree();
            _objcls.Parent_folder = Convert.ToInt32(drservice.SelectedItem.Value);
            drsub.DataSource = _objbll.Load_SubFolder(_objcls,_objdb);
            drsub.DataTextField = "PRJ_CAS_NAME";
            drsub.DataValueField = "PRJ_CAS_ID";
            drsub.DataBind();
            drsub.Items.Insert(0, "-- Select --");
            //Load_RecordSheet();
            //load_cas_sys();
        }
        protected void Load_RecordSheet()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DB_" + (string)Session["project"];
            //_clsFolderTree _objcls = new _clsFolderTree();
            //_objcls.Parent_folder = Convert.ToInt32(drsub.SelectedItem.Value);
            //drrdsheet.DataSource = _objbll.Load_RecordSheet_Master(_objcls, _objdb);
            //drrdsheet.DataTextField = "rs_name";
            //drrdsheet.DataValueField = "rs_id";
            //drrdsheet.DataBind();
            //drrdsheet1.DataSource = _objbll.Load_RecordSheet_Master(_objcls, _objdb);
            //drrdsheet1.DataTextField = "rs_name";
            //drrdsheet1.DataValueField = "rs_id";
            //drrdsheet1.DataBind();
        }
        protected void drsub_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Load_RecordSheet();
            if (drsub.SelectedItem.Text == "-- Select --") return;
            load_cas_sys();
        }
        protected void load_cas_sys()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();
            _objcls.sch = Convert.ToInt32(drsub.SelectedItem.Value);
            drpkg.DataSource = _objbll.Load_cas_sys(_objcls, _objdb);
            drpkg.DataTextField = "sys_name";
            drpkg.DataValueField = "sys_id";
            drpkg.DataBind();
            drpkg.Items.Insert(0, "-- Select --");
            txtcode1.Text = String.Empty;
            //load_cas_sys_info();
        }
        private void Update_Package()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clspackage _objcls = new _clspackage();
            _objcls.package = "";
            _objcls.category = txtcode1.Text;
            _objcls.sch_id = 0;
            _objcls.project = lblprj.Text;
            //_objcls.record_sheet = Convert.ToInt32(drrdsheet.SelectedItem.Value);
            _objcls.record_sheet = 0;
            _objcls.sys_id = Convert.ToInt32(drpkg.SelectedItem.Value);
            _objcls.mode = 0;
            _objbll.create_package(_objcls, _objdb);
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Package Updated');", true);
            txtpackage.Text = "";
            txtcode.Text = "";
        }
        protected void load_cas_sys_info()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();
            _objcls.sch = Convert.ToInt32(drpkg.SelectedItem.Value);
            DataTable _dt=_objbll.Load_cas_sys_info(_objcls, _objdb);
            var result = from o in _dt.AsEnumerable()
                         select o;
            foreach (var row in result)
            {
                txtcode1.Text = row[0].ToString();
                //if(row[1].ToString()!= "")
                //    drrdsheet1.SelectedValue = row[1].ToString();
            }
        }
        protected void drpkg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpkg.SelectedItem.Text == "-- Select --") return;
            load_cas_sys_info();
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtcode1.Text.Length <= 0) return;
            Update_Package();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            if (txtcode1.Text.Length <= 0) return;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clspackage _objcls = new _clspackage();
            _objcls.package = "";
            _objcls.category = txtcode1.Text;
            _objcls.sch_id = 0;
            _objcls.project = lblprj.Text;
            //_objcls.record_sheet = Convert.ToInt32(drrdsheet.SelectedItem.Value);
            _objcls.record_sheet = 0;
            _objcls.sys_id = Convert.ToInt32(drpkg.SelectedItem.Value);
            _objcls.mode = 2;
            _objbll.create_package(_objcls, _objdb);
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Package Deleted');", true);
            txtcode1.Text = String.Empty;
        }
    }
}
