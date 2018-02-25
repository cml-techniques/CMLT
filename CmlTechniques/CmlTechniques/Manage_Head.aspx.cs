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
    public partial class Manage_Head : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             _ReadCookies();
             if ((string)Session["uid"] != null)
             {
                 string _prm = Request.QueryString[0].ToString();
                 lblmode.Text = _prm;
                 Load_Action(_prm);
                 Load_Project(_prm);
             }
             else
                 ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.menu_click('1');", true);
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
        private void Load_Action(string _mod)
        {
            if (_mod == "DMS")
            {
                draction.Items.Add("<< Select Action >>");
                draction.Items.Add("Document Uploading");
                draction.Items.Add("Scheduling");
                draction.Items.Add("Manage Tree Folder");
                draction.Items.Add("User Permission");
                draction.Items.Add("Comments");
                draction.Items.Add("T&C Documentation");
            }
            else if (_mod == "CMS")
            {
                draction.Items.Add("<< Select Action >>");
                draction.Items.Add("Uploads");
                draction.Items.Add("Create Packages");
                draction.Items.Add("Create Panels");
                draction.Items.Add("Configure Training Folder");
                draction.Items.Add("Configure MS Folder");
                draction.Items.Add("Configure Method Statements");
                draction.Items.Add("Configure Minutes");
            }
        }
        private void Load_Project(string _mod)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = (string)Session["uid"];
            if (_mod == "CMS")
            {
                drproject.DataSource = _objbll.Load_User_CMS_Projects(_objcls, _objdb);
                drproject.DataValueField = "prj_code";
                drproject.DataTextField = "prj_name";
                drproject.DataBind();
            }
            else if (_mod == "DMS")
            {
                drproject.DataSource = _objbll.Load_User_DMS_Projects(_objcls, _objdb);
                drproject.DataValueField = "prj_code";
                drproject.DataTextField = "prj_name";
                drproject.DataBind();
            }
           // drproject.Items.Insert(0, "<< Select Project >>");

        }
        protected void btngo_Click(object sender, EventArgs e)
        {
            //if (drproject.SelectedItem.Text == "<< Select Project >>") { ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Project!');", true); return; }
            //if (draction.SelectedItem.Text == "<< Select Action >>") { ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Action!');", true); return; }
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + drproject.Text + "');", true);
            Session["project"] = drproject.SelectedValue;
            Session["projectname"] = drproject.SelectedItem.Text;
            if (lblmode.Text == "DMS")
            {
                string _url = null;
                switch (draction.SelectedValue)
                {
                    case "Document Uploading": _url = "UploadTree.aspx"; break;
                    case "Scheduling": _url = "scheduling.aspx"; break;
                    case "Manage Tree Folder": _url = "managetree.aspx"; break;
                    case "User Permission": _url = "userpermission.aspx"; break;
                    case "Comments": _url = "projectsettings.aspx"; break;
                    case "T&C Documentation": _url = "TC_Doc_Home.aspx?id=" + drproject.SelectedValue; break;
                }
                //myframe.Attributes.Add("src", _url);
            }

        }

        protected void drproject_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + drproject.SelectedItem.Text + "');", true);
        }
    }
}
