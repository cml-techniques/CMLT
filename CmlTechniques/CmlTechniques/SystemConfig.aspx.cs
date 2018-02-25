using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Data;

namespace CmlTechniques
{
    public partial class SystemConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                LOAD_CMS_SYS_MODULES();
                LOAD_SYS_SERVICE();
                Load_Project();
                //Load_DocReviewPeriod();
                TabContainer1.Enabled = false;
               // LOAD_CAS_SERVICE();
                //LOAD_SYS_CASSHEET();

            }
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
        void _Create_Cookies()
        {
            if (Request.Browser.Cookies)
            {
                HttpCookie _CookiePrjCode = new HttpCookie("project");
                _CookiePrjCode.Value = (string)Session["project"];
                _CookiePrjCode.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_CookiePrjCode);
                HttpCookie _CookiePrjname = new HttpCookie("projectname");
                _CookiePrjname.Value = (string)Session["projectname"];
                _CookiePrjname.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_CookiePrjname);
                

            }
            else
                return;
        }
        protected void LOAD_CMS_SYS_MODULES()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "dbCML";
            //chkcmsmodule.DataSource = _objbll.LOAD_SYS_CMS_MODULES(_objdb);
            //chkcmsmodule.DataTextField = "MODULE";
            //chkcmsmodule.DataValueField = "MOD_ID";
            //chkcmsmodule.DataBind();        
        }
        protected void LOAD_SYS_SERVICE()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            chkcasservice.DataSource = _objbll.LOAD_SYS_SERVICE(_objdb);
            chkcasservice.DataTextField = "SERVICE_NAME";
            chkcasservice.DataValueField = "SER_ID";
            chkcasservice.DataBind();
            drmsservice.DataSource = _objbll.LOAD_SYS_SERVICE(_objdb);
            drmsservice.DataTextField = "SERVICE_NAME";
            drmsservice.DataValueField = "SER_ID";
            drmsservice.DataBind();
            drcasservice.DataSource = _objbll.LOAD_SYS_SERVICE(_objdb);
            drcasservice.DataTextField = "SERVICE_NAME";
            drcasservice.DataValueField = "SER_ID";
            drcasservice.DataBind();
            drserv.DataSource = _objbll.LOAD_SYS_SERVICE(_objdb);
            drserv.DataTextField = "SERVICE_NAME";
            drserv.DataValueField = "SER_ID";
            drserv.DataBind();
            Load_MS_Systems();
            LOAD_CASSHEET();
        }
        protected void LOAD_CAS_SERVICE()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            DataTable _dtable = _objbll.Load_Project_CMSFolder(_objdb);
            var _id = from o in _dtable.AsEnumerable()
                      where o.Field<string>(1) == "Cas Sheet"
                      select o;
            foreach (var row in _id)
            {
                var _ser = from o in _dtable.AsEnumerable()
                           where o.Field<int>(3) == Convert.ToInt32(row[0].ToString())
                           select o;
                foreach (var row1 in _ser)
                {
                    ListItem _lst = new ListItem();
                    _lst.Text = row1[1].ToString();
                    _lst.Value = row1[0].ToString() + "M_" + row1[4].ToString();
                    drcasservice.Items.Add(_lst);
                }
            }
            LOAD_CASSHEET();

        }
        protected void LOAD_CASSHEET()
        {
            chkcassheet.Items.Clear();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            DataTable _dtable = _objbll.LOAD_SYS_CMS_CASSHEET(_objdb);
            //string _masterid = drcasservice.SelectedItem.Value.Substring(drcasservice.SelectedItem.Value.IndexOf("M_") + 2);
            var _id = from o in _dtable.AsEnumerable()
                      where o.Field<int>(2) == Convert.ToInt32(drcasservice.SelectedItem.Value)
                      select o;
            foreach (var row in _id)
            {
                ListItem _lst = new ListItem();
                _lst.Text = row[1].ToString();
                _lst.Value = row[0].ToString();
                chkcassheet.Items.Add(_lst);
            }
        }
        private void Load_Prj_Cassheet()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsFolderTree _objcls = new _clsFolderTree();
            _objcls.Parent_folder = Convert.ToInt32(drserv.SelectedItem.Value);
            drcas.DataSource = _objbll.Load_SubFolder(_objcls, _objdb);
            drcas.DataTextField = "PRJ_CAS_NAME";
            drcas.DataValueField = "PRJ_CAS_ID";
            drcas.DataBind();
        }
        protected void Save_CMS_Modules()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "dbCML";
            //_clsFolderTree _objcls = new _clsFolderTree();
            //for (int i = 0; i <= chkcmsmodule.Items.Count - 1; i++)
            //{
            //    _objcls.Folder_description = chkcmsmodule.Items[i].Text;
            //    _objcls.master_id=Convert.ToInt32(chkcmsmodule.Items[i].Value);
            //    _objcls.Folder_possition = 0;
            //    _objcls.Folder_type = 0;
            //    _objcls.Parent_folder = 0;
            //    _objcls.Project_code = (string)Session["project"];
            //    _objcls.type = 0;
            //    if (chkcmsmodule.Items[i].Selected == true)
            //        _objcls.Enabled = true;
            //    else
            //        _objcls.Enabled = false;                
            //    _objbll.Config_CMSFolderTree(_objcls,_objdb);
            //}
        }
        protected void btn1save_Click(object sender, EventArgs e)
        {
            //bool _selected = false;
            //for (int i = 0; i <= chkcmsmodule.Items.Count - 1; i++)
            //    if (chkcmsmodule.Items[i].Selected == true)
            //        _selected = true;
            //if (_selected == false)
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('SELECT MODULE');", true);
            //else
            //{
            //    Save_CMS_Modules();
            //    string _msg = "CMS Modules Created for " + (string)Session["projectname"];
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('"+ _msg +"');", true);
            //}
        }
        protected void btn2save_Click(object sender, EventArgs e)
        {
            bool _selected = false;
            for (int i = 0; i <= chkcasservice.Items.Count - 1; i++)
                if (chkcasservice.Items[i].Selected == true)
                    _selected = true;
            if (_selected == false)
                ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('SELECT SERVICE');", true);
            else
            {
                //Save_Service();
                Save_Project_Services();
                string _msg = "CMS Services Created for " + (string)Session["projectname"];
                ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('" + _msg + "');", true);
            }
        }
        protected void Save_Project_Services()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _sysconfig _objcls = new _sysconfig();
            for (int i = 0; i <= chkcasservice.Items.Count - 1; i++)
            {
                _objcls.ser_name = chkcasservice.Items[i].Text;
                _objcls.ser_id = Convert.ToInt32(chkcasservice.Items[i].Value);
                if (chkcasservice.Items[i].Selected == true)
                    _objcls.enabled = true;
                else
                    _objcls.enabled = false;
                if (rdsrv.SelectedItem.Value == "1")
                    _objbll.Config_Prj_Service(_objcls, _objdb);
                else if (rdsrv.SelectedItem.Value == "2")
                    _objbll.Config_Prj_Service_MS(_objcls, _objdb);
            }
        }
        protected void Save_Service()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsFolderTree _objcls = new _clsFolderTree();
            for (int i = 0; i <= chkcasservice.Items.Count - 1; i++)
            {
                _objcls.Folder_description = chkcasservice.Items[i].Text;
                _objcls.master_id = Convert.ToInt32(chkcasservice.Items[i].Value);
                _objcls.Folder_possition = 0;
                _objcls.Folder_type = 1;
                _objcls.Parent_folder = 0;
                _objcls.type = 1;
                _objcls.Project_code = (string)Session["project"];
                if (chkcasservice.Items[i].Selected == true)
                    _objcls.Enabled = true;
                else
                    _objcls.Enabled = false;
                _objbll.Config_CMSFolderTree(_objcls,_objdb);
            }
            for (int i = 0; i <= chkcasservice.Items.Count - 1; i++)
            {
                _objcls.Folder_description = chkcasservice.Items[i].Text;
                _objcls.master_id = Convert.ToInt32(chkcasservice.Items[i].Value);
                _objcls.Folder_possition = 0;
                _objcls.Folder_type = 1;
                _objcls.Parent_folder = 0;
                _objcls.type = 2;
                _objcls.Project_code = (string)Session["project"];
                if (chkcasservice.Items[i].Selected == true)
                    _objcls.Enabled = true;
                else
                    _objcls.Enabled = false;
                _objbll.Config_CMSFolderTree(_objcls,_objdb);
            }

        }
        protected void Save_Project_CasSheets()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _sysconfig _objcls = new _sysconfig();
            for (int i = 0; i <= chkcassheet.Items.Count - 1; i++)
            {
                _objcls.cas_name = chkcassheet.Items[i].Text;
                _objcls.cas_id = Convert.ToInt32(chkcassheet.Items[i].Value);
                _objcls.ser_id = Convert.ToInt32(drcasservice.SelectedItem.Value);
                if (chkcassheet.Items[i].Selected == true)
                    _objcls.enabled = true;
                else
                    _objcls.enabled = false;
                _objbll.Config_Prj_Cassheet(_objcls, _objdb);
            }
        }
        protected void Save_CasSheet()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsFolderTree _objcls = new _clsFolderTree();
            string _id = drcasservice.SelectedItem.Value.Substring(0,drcasservice.SelectedItem.Value.IndexOf("M_"));
            for (int i = 0; i <= chkcassheet.Items.Count - 1; i++)
            {
                _objcls.Folder_description = chkcassheet.Items[i].Text;
                _objcls.master_id = Convert.ToInt32(chkcassheet.Items[i].Value);
                _objcls.Folder_possition = 0;
                _objcls.Folder_type = 2;
                _objcls.Parent_folder =Convert.ToInt32(_id);
                _objcls.Project_code = (string)Session["project"];
                _objcls.type = 0;
                if (chkcassheet.Items[i].Selected == true)
                    _objcls.Enabled = true;
                else
                    _objcls.Enabled = false;
                _objbll.Config_CMSFolderTree(_objcls,_objdb);
            }
        }
        protected void drcasservice_SelectedIndexChanged(object sender, EventArgs e)
        {
            LOAD_CASSHEET();
        }
        protected void btn3save_Click(object sender, EventArgs e)
        {
            bool _selected = false;
            for (int i = 0; i <= chkcassheet.Items.Count - 1; i++)
                if (chkcassheet.Items[i].Selected == true)
                    _selected = true;
            if (_selected == false)
                ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('SELECT SERVICE');", true);
            else
            {
                Save_Project_CasSheets();
                string _msg = "CMS Cas Sheet Created for " + (string)Session["projectname"];
                ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('" + _msg + "');", true);
            }
        }
        protected void drmsservice_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_MS_Systems();            
        }
        protected void drserv_SelectedIndexChanged(object sender, EventArgs e)
        {
            LOAD_CASSHEET();
        }
        protected void Load_MS_Systems()
        {
            chkmssystem.Items.Clear();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsMaster _objcls = new _clsMaster();
            _objdb.DBName = "dbCML";
            _objcls.ser_id = Convert.ToInt32(drmsservice.SelectedItem.Value);
            chkmssystem.DataSource = _objbll.Load_Ms_Systems(_objcls, _objdb);
            DataTable _dtable = _objbll.Load_Ms_Systems(_objcls, _objdb);
            var _result = from o in _dtable.AsEnumerable()
                          select o;
            foreach (var row in _result)
            {
                ListItem _lst = new ListItem();
                _lst.Text = row[2].ToString();
                _lst.Value = row[0].ToString() + "_R" + row[1].ToString();
                chkmssystem.Items.Add(_lst);
            }
            
        }
        protected void Save_Project_MsSystems()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _sysconfig _objcls = new _sysconfig();
            for (int i = 0; i <= chkmssystem.Items.Count - 1; i++)
            {
                if (chkmssystem.Items[i].Selected == true)
                    _objcls.enabled = true;
                else
                    _objcls.enabled = false;
                string _value=chkmssystem.Items[i].Value;
                _objcls.sys_reff = _value.Substring(_value.IndexOf("_R") + 2);
                _objcls.sys_name = chkmssystem.Items[i].Text;
                _objcls.ser_id = Convert.ToInt32(drmsservice.SelectedItem.Value);
                _objcls.sys_id = Convert.ToInt32(_value.Substring(0, _value.IndexOf("_R")));
                _objbll.Config_Prj_MsSystem(_objcls, _objdb);
            }

        }
        //protected void Config_Ms_Schedule(int ser_id,bool enabled)
        //{
        //    BLL_Dml _objbll = new BLL_Dml();
        //    _database _objdb = new _database();
        //    _clsMaster _objcls = new _clsMaster();
        //    _objdb.DBName = "dbCML";
        //    _objcls.ser_id = ser_id;
        //    _objcls.sys_id = 0;
        //    _objcls.enabled = enabled;
            
        //}
        protected void add_ms_type(string _type)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsMaster _objcls = new _clsMaster();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _objcls.ser_id = Convert.ToInt32(drmsservice.SelectedItem.Value);
            for (int i = 0; i <= chkmssystem.Items.Count - 1; i++)
            {
                if (chkmssystem.Items[i].Selected == true)
                    _objcls.enabled = true;
                else
                    _objcls.enabled = false;
                _objcls.sys_id = Convert.ToInt32(chkmssystem.Items[i].Value);
                _objbll.Config_Ms_Schedule(_objcls, _objdb);
            }
        }
        protected void btn4save_Click(object sender, EventArgs e)
        {
            bool _selected = false;
            for (int i = 0; i <= chkmssystem.Items.Count - 1; i++)
                if (chkmssystem.Items[i].Selected == true)
                    _selected = true;
            if (_selected == false)
                ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('SELECT SYSTEMS');", true);
            else
            {
                //Config_Ms_Schedule();
                Save_Project_MsSystems();
                string _msg = "MS Schedule Created for " + (string)Session["projectname"];
                ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('" + _msg + "');", true);
            }
        }

        protected void btngo_Click(object sender, EventArgs e)
        {
            if (drproject.SelectedItem.Text == "--Select Project--") return;
            TabContainer1.Enabled = true;
            Session["project"] = drproject.SelectedItem.Value;
            Session["projectname"] = drproject.SelectedItem.Text;
            _Create_Cookies();
            Load_DocReviewPeriod();

        }
        protected void Load_Project()
        {
            BLL_Dml _objbal = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            DataTable _dtable = _objbal.load_project(_objdb);
            var _result = from o in _dtable.AsEnumerable()
                          where o.Field<string>(5) == "YES"
                          select o;
            foreach (var row in _result)
            {
                ListItem _lst = new ListItem();
                _lst.Text = row[1].ToString();
                _lst.Value = row[0].ToString();
                drproject.Items.Add(_lst);
            }
            drproject.DataBind();
            drproject.Items.Insert(0, "--Select Project--");
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (drdocument.SelectedItem.Text == "-- Select --") return;
            else if (txtdays.Text.Length <= 0) return;
            Save();
        }
        private void Save()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.doc_name = drdocument.SelectedItem.Text;
            _objcls.Review_Days = Convert.ToInt32(txtdays.Text);
            _objbll.Add_ReviewSettings(_objcls, _objdb);
            Load_DocReviewPeriod();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Saved!');", true);
        }
        private void Load_DocReviewPeriod()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            mygrid.DataSource = _objbll.Load_DocumentReviewPeriod(_objdb);
            mygrid.DataBind();
        }
    }
}
