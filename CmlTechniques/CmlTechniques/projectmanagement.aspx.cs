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

namespace CmlTechniques
{
    public partial class projectmanagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                //myframe.Attributes.Add("src", "fileupload.aspx");
                load_project();
            }
        }
        
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            //if (Menu1.SelectedValue == "0")
            //    myframe.Attributes.Add("src", "fileupload.aspx");
            //else if (Menu1.SelectedValue == "1")
            //    myframe.Attributes.Add("src", "scheduling.aspx");
            //else if (Menu1.SelectedValue == "2")
            //    myframe.Attributes.Add("src", "managetree.aspx");
            //else if (Menu1.SelectedValue == "3")
            //    myframe.Attributes.Add("src", "createuser.aspx");
            //else if (Menu1.SelectedValue == "4")
            //    myframe.Attributes.Add("src", "#");


        }

        protected void cmdgo_Click(object sender, EventArgs e)
        {
            if (drproject.SelectedItem.Text == "--Select Project--") { ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Project!');", true); return; }
            if (draction.SelectedItem.Text == "--Select Action--") { ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Action!');", true); return; }
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + drproject.SelectedItem.Text + "');", true);
            Session["project"] = drproject.SelectedValue;
            Session["projectname"] = drproject.SelectedItem.Text;
            _Create_Cookies();
            myframe.Visible = true;
            Select_Action();
            title.Text = "Project >> " + drproject.SelectedItem.Text + " >> " + draction.SelectedItem.Text;
        }
        void Select_Action()
        {
           // ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + draction.SelectedItem.Value  + "');", true);
            string _url = null;
            switch (draction.SelectedValue)
            {
                //case "<Select Action>": ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Action');", true); break;
                //case "Document Uploading": _url = "fileupload.aspx"; break;
                case "Document Uploading": _url = "UploadTree.aspx"; break;
                case "Scheduling": _url = "scheduling.aspx"; break;
                case "Manage Tree Folder": _url = "managetree.aspx"; break;
                case "User Permission": _url = "userpermission.aspx"; break;
                case "Comments": _url = "projectsettings.aspx"; break;
                case "T&C Documentation": _url = "TC_Doc_Home.aspx?id=" + drproject.SelectedValue; break;
            }
            myframe.Attributes.Add("src", _url);
        }
        void load_project()
        {
            myframe.Visible = false;
            //Menu1.Enabled = false;
            BLL_Dml _objbal=new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            drproject.DataSource = _objbal.load_project(_objdb);
            drproject.DataTextField = "prj_name";
            drproject.DataValueField = "prj_code";
            drproject.DataBind();
            drproject.Items.Insert(0, "--Select Project--");

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

        
    }
}
