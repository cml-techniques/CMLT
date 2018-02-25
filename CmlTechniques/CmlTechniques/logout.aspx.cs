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
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "gettime();", true);
                
        }
        void _toDeleteCookies()
        {
            if (Request.Browser.Cookies)
            {
                string[] _cookies = Request.Cookies.AllKeys;
                foreach (string cookie in _cookies)
                {
                    Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
                }
            }
        }
        void Log_off()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clslog _objcls=new _clslog();
            _objcls.uid=(string)Session["uid"];
            string _logout = Request.Form["_logout"].ToString();
            _objcls.logout = _logout;
            _objbll.LOG_OUT(_objcls,_objdb);
            _toDeleteCookies();
            //Response.Redirect("Default.aspx");
            
        }

        protected void _btnlogout_Click(object sender, ImageClickEventArgs e)
        {
            if ((string)Session["uid"] != null)
            {
                Log_off();
            }
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.close();", true);
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }
    }
}
