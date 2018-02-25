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
    public partial class ConfigureModulePermission : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string _prm = Request.QueryString[0].ToString();

               lblprj.Text = "ABS";
                Load_ProjectUsers();
                load_Modules();

                Session["user"] = ddlusers.SelectedItem.Value;
                Load_User_AllModule();



            }
        }
        void load_Modules()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clstreefolder _objcls = new _clstreefolder();
            _objcls.Folder_type = 0;
            ddlmodules.DataSource = _objbll.LOAD_PRJMAINMODULES(_objdb);

            ddlmodules.DataTextField = "Module";
            ddlmodules.DataValueField = "Mod_Id";
            ddlmodules.DataBind();

            //ddlmodules.Items.Add();

        }
        private void Load_ProjectUsers()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            ddlusers.DataSource = _objbll.load_User(_objcls, _objdb);


            ddlusers.DataTextField = "UserId";
            ddlusers.DataValueField = "UserId";
            ddlusers.DataBind();
        }
        private void Load_User_AllModule()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocument _objcls = new _clsdocument();
            _objcls.uid = ddlusers.SelectedItem.Value;
            mygrid.DataSource = _objbll.Load_User_AllModule(_objcls, _objdb);
            mygrid.DataBind();
        }
            

        protected void mygrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mygrid.Rows[_rowidx];
            TableCell _id = _srow.Cells[0];
            Session["Id"] = _id.Text;
            btnDummy_ModalPopupExtender7.Show();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            Update_User_ModulePermision();
        }
        private void Update_User_ModulePermision()  
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clstreefolder _objcls = new _clstreefolder();
            _objcls.Folder_id = Convert.ToInt32(Session["Id"].ToString());
            _objcls.Folder_possition = Convert.ToInt32(draccess.SelectedItem.Value);
            _objbll.Update_User_ModulePermision(_objcls, _objdb);
            btnDummy_ModalPopupExtender7.Hide();
            Load_User_AllModule();

        }
        void AddNew_Module_Permission()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsuser _objcls = new _clsuser();
            _objcls.uid = (string)Session["user"];
            _objcls.access = ddlmodules.SelectedItem.Value;
            _objcls.mode = Convert.ToInt32(ddlPerms.SelectedItem.Value);
            _objbll.Set_User_ModulePermission(_objcls, _objdb);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender7.Hide();
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            AddNew_Module_Permission();
            Load_User_AllModule();
        }

        protected void ddlusers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["user"] = ddlusers.SelectedItem.Value;
            Load_User_AllModule();
        }
    }
}
