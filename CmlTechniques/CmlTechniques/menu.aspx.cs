using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;

namespace CmlTechniques
{
    public partial class menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
                    manage.Visible = false;
                //if ((string)Session["group"] != "SYS.ADMIN GROUP")
                    admin.Visible = false;
            }

        }
        private void _ReadCookies()
        {
            if (Request.Browser.Cookies)
            {
                if (Request.Cookies["group"] != null)
                {
                    Session["group"] = Server.HtmlEncode(Request.Cookies["group"].Value);
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Log_off();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.menu_click('1');", true);
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
