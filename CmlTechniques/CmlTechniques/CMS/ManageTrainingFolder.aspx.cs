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

namespace CmlTechniques.CMS
{
    public partial class ManageTrainingFolder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _parm = Request.QueryString[0].ToString();
                Session["folder_id"] = _parm.Substring(0, _parm.IndexOf("_P"));
                Session["parent_id"] = _parm.Substring(_parm.IndexOf("_P") + 2, _parm.IndexOf("_L") - (_parm.IndexOf("_P") + 2));
                Session["level"] = _parm.Substring(_parm.IndexOf("_L") + 2, _parm.IndexOf("_T") - (_parm.IndexOf("_L") + 2));
                Session["type"] = _parm.Substring(_parm.IndexOf("_T") + 2);
                btndelete.Enabled = false;
                txtfolder.Enabled = false;
                btncreate.Enabled = false;
                Get_Folder();
            }
        }
        private void Get_Folder()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsFolderTree _objcls = new _clsFolderTree();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _objcls.Folder_id = Convert.ToInt32(Session["folder_id"]);
            lbfolder.Text = _objbll.Get_FolderInfo(_objcls, _objdb);
        }
        protected void draction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (draction.SelectedItem.Value == "1" || draction.SelectedItem.Value == "3")
            {
                txtfolder.Text = String.Empty;
                btndelete.Enabled = false;
                btncreate.Text = "Save";
                btncreate.Enabled = true;
                txtfolder.Enabled = true;
            }
            else if (draction.SelectedItem.Value == "2" )
            {
                txtfolder.Text = lbfolder.Text;
                btndelete.Enabled = true;
                btncreate.Text = "Update";
                btncreate.Enabled = true;
                txtfolder.Enabled = true;
            }
        }

        protected void btncreate_Click(object sender, EventArgs e)
        {
            if (draction.SelectedItem.Text == "-- Select Action --") return;
            if (txtfolder.Text.Length <= 0) return;
            if (btncreate.Text == "Save")
                Create_Folder();
            else if (btncreate.Text == "Update")
                Edit_Folder();
        }
        private void Create_Folder()
        {
            int _type = Convert.ToInt32((string)Session["type"]);
            int _parent = Convert.ToInt32((string)Session["parent_id"]);
            if (draction.SelectedItem.Value == "3")
            {
                _parent = Convert.ToInt32((string)Session["folder_id"]);
                _type = _type + 1;
            }
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsFolderTree _objcls = new _clsFolderTree();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _objcls.Folder_id = 0;
            _objcls.Folder_description = txtfolder.Text;
            _objcls.Folder_type = _type;
            _objcls.Parent_folder = _parent;
            _objcls.mode = "1";
            _objbll.Manage_TrainingFolder(_objcls, _objdb);
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Folder Created');", true);
            
        }
        private void Edit_Folder()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsFolderTree _objcls = new _clsFolderTree();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _objcls.Folder_id = Convert.ToInt32((string)Session["folder_id"]);
            _objcls.Folder_description = txtfolder.Text;
            _objcls.Folder_type = Convert.ToInt32((string)Session["type"]);
            _objcls.Parent_folder = Convert.ToInt32((string)Session["parent_id"]);
            _objcls.mode = "2";
            _objbll.Manage_TrainingFolder(_objcls, _objdb);
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Folder Name Changed');", true);

        }
        private void Delete_Folder()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsFolderTree _objcls = new _clsFolderTree();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _objcls.Folder_id = Convert.ToInt32((string)Session["folder_id"]);
            _objcls.Folder_description = txtfolder.Text;
            _objcls.Folder_type = Convert.ToInt32((string)Session["type"]);
            _objcls.Parent_folder = Convert.ToInt32((string)Session["parent_id"]);
            _objcls.mode = "3";
            _objbll.Manage_TrainingFolder(_objcls, _objdb);
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Folder Deleted');", true);

        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            Delete_Folder();
        }

    }
}
