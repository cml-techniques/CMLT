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
    public partial class cmsmenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                lblprj.Text = Request.QueryString["prj"].ToString();
                GetStatus();
                //HtmlGenericControl listItem = this.dbmenu as HtmlGenericControl;
                //if (lblprj.Text == "PCD" && listItem != null)
                //{
                //    this.dbmenu.Visible = true;
                //}
                //else
                //    this.dbmenu.Style.Add("display", "none");
            }
        }
        private void GetStatus()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = (string)Session["uid"];
            _objcls.project_code = lblprj.Text;
            string _access = _objbll.Get_User_cmsAccess(_objcls, _objdb);
            //if(_access=="Read Only")
            //    rptmenu.Visible = false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Log_off();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.MenuClick('2');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.CallReport('"+ lblprj.Text +"');", true);
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
