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
using System.IO;

namespace CmlTechniques
{
    public partial class userpermission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                load_user();
                load_services();
                load_accesslevel();
               Panel1.Visible = false;
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
                
            }
        }
        void load_user()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser  _objcls=new _clsuser ();
            //_objcls.project_code=publicCls.publicCls._project;
            _objcls.project_code = (string)Session["project"];
            mygriduser.DataSource = _objbll.load_User(_objcls,_objdb);
            mygriduser.DataBind();
        }
        void load_services()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser  _objcls = new _clsuser ();
            //_objcls.project_code = publicCls.publicCls._project;
            _objcls.project_code = (string)Session["project"];
            _objcls.uid = "nothing";
            chkservice.DataSource = _objbll.load_service(_objcls,_objdb);
            chkservice.DataTextField = "Folder_description";
            chkservice.DataValueField = "Folder_id";
            chkservice.DataBind();
        }

        protected void mygriduser_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Panel1.Visible = true;
            Session["user"] = mygriduser.Rows[e.NewEditIndex].Cells[0].Text;
            mygriduser.Rows[e.NewEditIndex].BackColor = System.Drawing.Color.LightBlue;
            //.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["user"] + "');", true);
            //Label1.Text = mygriduser.Rows[e.NewEditIndex].Cells[0].Text + publicCls.publicCls._project ;
        }
        private void load_accesslevel()
        {
            draccess.Items.Insert(0, "---- Select Access Level ----");
            draccess.Items.Add("Super Admin");
            draccess.Items.Add("Admin");
            draccess.Items.Add("Review/Comment");
            draccess.Items.Add("Review/Comment/Status");
        }
        void Edit_user()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser  _objcls = new _clsuser();
            _objcls.project_code = (string)Session["project"];
            _objcls.access = draccess.SelectedItem.Text;
            _objcls.uid = (string)Session["user"];
            _objbll.Edit_Access(_objcls,_objdb);
            Set_service();
            Panel1.Visible = false;

        }
        void Set_service()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = (string)Session["project"];
            _objcls.uid = (string)Session["user"];
            foreach (ListItem _lst in chkservice.Items)
            {
                if (_lst.Selected == true)
                {
                    _objcls.service = _lst.Value;
                    _objbll.Insert_UserService(_objcls,_objdb);
                }

            }            
            //Panel1.Visible = false;
        }
       

        

        protected void cmdsubmit_Click(object sender, EventArgs e)
        {
            Edit_user();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ draccess.SelectedItem.Text +"');", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('hai');", true);
        }

        

        
    }
}
