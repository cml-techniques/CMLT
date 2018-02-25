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
    public partial class adminpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            //if ((string)Session["uid"] != null)
            //    userinfo.Text = "Login as : " + (string)Session["uid"] + " , ";
            //else
            //    Response.Redirect("Default.aspx");
            if (!IsPostBack)
            {
                string PName = "";
                if (Request.UrlReferrer != null)
                {
                    PName = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
                }

                if (PName == "")
                {
                    Response.Redirect("https://cmltechniques.com");
                }
                myframe.Attributes.Add("src", "administration.aspx");
                //Populate_myprojectGrid();
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
            }
        }
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            //if (Menu1.SelectedValue == "0")
            //    myframe.Attributes.Add("src", "projectmaster.aspx");
            //else if (Menu1.SelectedValue == "1")
            //    myframe.Attributes.Add("src", "schedule.aspx");
            //else if (Menu1.SelectedValue == "2")
            //    myframe.Attributes.Add("src", "fileupload.aspx");
        }
        void Populate_myprojectGrid()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //mygrid.DataSource = _objbll.load_project();
            //mygrid.DataBind();
        }
        protected void mygrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //myframe.Attributes.Add("src", "projecthome.aspx");
            //myframe.Attributes.Add("width", "100%");
            //myframe.Attributes.Add("height", "100%");
            //mygrid.Visible = false;
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //myframe.Visible = false;
            //mygrid.Visible = true;
        }
        protected void btnprjmngment_Click(object sender, EventArgs e)
        {
            //mydiv.Visible = false;
            myframe.Visible = true;
            myframe.Attributes.Add("src", "projectmanagement.aspx");
        }
        protected void btnprjcreation_Click(object sender, EventArgs e)
        {
            //mydiv.Visible = false;
            myframe.Visible = true;
            myframe.Attributes.Add("src", "projectmaster.aspx");
        }
        protected void btnusercreation_Click(object sender, EventArgs e)
        {
            //mydiv.Visible = false;
            myframe.Visible = true;
            myframe.Attributes.Add("src", "createuser.aspx");
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //mydiv.Visible = false;
            myframe.Visible = true;
            myframe.Attributes.Add("src", "projectmanagement.aspx");
        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
           // mydiv.Visible = false;
            myframe.Visible = true;
            myframe.Attributes.Add("src", "projectmaster.aspx");
        }
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            //mydiv.Visible = false;
            myframe.Visible = true;
            myframe.Attributes.Add("src", "createuser.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Log_off();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "logoff();", true);
        }
        void _toDeleteCookies()
        {
            //if (Request.Browser.Cookies)
            //{
            //    string[] _cookies = Request.Cookies.AllKeys;
            //    foreach (string cookie in _cookies)
            //    {
            //        Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-10);
            //    }
            //}

            if (Request.Cookies["uid"] != null)
            {
                HttpCookie _CookieUid = new HttpCookie("uid");
                _CookieUid.Expires = DateTime.Now.AddDays(-10);
                Response.Cookies.Add(_CookieUid);
            }
            if (Request.Cookies["pwd"] != null)
            {
                HttpCookie _CookiePwd = new HttpCookie("pwd");
                _CookiePwd.Expires = DateTime.Now.AddDays(-10);
                Response.Cookies.Add(_CookiePwd);
            }
            if (Request.Cookies["chk"] != null)
            {
                HttpCookie _CookieChk = new HttpCookie("chk");
                _CookieChk.Expires = DateTime.Now.AddDays(-10);
                Response.Cookies.Add(_CookieChk);
            }
            if (Request.Cookies["access"] != null)
            {
                HttpCookie _CookieUaccess = new HttpCookie("access");
                _CookieUaccess.Expires = DateTime.Now.AddDays(-10);
                Response.Cookies.Add(_CookieUaccess);
            }
            if (Request.Cookies["group"] != null)
            {
                HttpCookie _CookieUgroup = new HttpCookie("group");
                _CookieUgroup.Expires = DateTime.Now.AddDays(-10);
                Response.Cookies.Add(_CookieUgroup);
            }
        }
        void Log_off()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clslog _objcls = new _clslog();
            _objcls.uid = (string)Session["uid"];
            string _logout = Request.Form["_logout"].ToString();
            _objcls.logout = _logout;
            _objbll.LOG_OUT(_objcls, _objdb);
            _toDeleteCookies();
        }
    }

}
