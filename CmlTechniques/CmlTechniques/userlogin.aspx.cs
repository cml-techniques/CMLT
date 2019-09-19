using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Xml;
using System.Net;
using Newtonsoft.Json;
using System.Globalization;

namespace CmlTechniques
{
    public partial class userlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                //if (Request.QueryString["id"].ToString() != )
                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    string _prm = Request.QueryString[0].ToString();
                    Session["prm"] = _prm;
                    //lblprm.Text = _prm;
                    //if (_prm == "1")
                    //    Response.Redirect("../userlogin.aspx?id=" + _prm);
                }
                else
                    Session["prm"] = "";
                lblnpwd.Visible = false;
                lblcpwd.Visible = false;
                _pwdc.Visible = false;
                _pwdn.Visible = false;
                //_toDeleteCookies();
                _uid.Text = (string)Session["id_rem"];
                _pwd.Attributes.Add("value", (string)Session["pwd_rem"]);
                //if ((string)Session["id_rem"] != "")
                //{
                //_uid.Text = "ttt" ;
                //    _pwd.Text = "333";
                //}
            }
        }
     
        private void _ReadCookies()
        {
            if (Request.Browser.Cookies)
            {
                if (Request.Cookies["uid"] != null)
                {
                    Session["uid"] = Server.HtmlEncode(Request.Cookies["uid"].Value);
                }
                if (Request.Cookies["pwd"] != null)
                {
                    Session["pwd"] = Server.HtmlEncode(Request.Cookies["pwd"].Value);
                }
                if (Request.Cookies["chk"] != null)
                {
                    Session["chk"] = Server.HtmlEncode(Request.Cookies["chk"].Value);
                }
                if (Request.Cookies["id_rem"] != null)
                {
                    Session["id_rem"] = Server.HtmlEncode(Request.Cookies["id_rem"].Value);
                }
                if (Request.Cookies["pwd_rem"] != null)
                {
                    Session["pwd_rem"] = Server.HtmlEncode(Request.Cookies["pwd_rem"].Value);
                }
            }
        }
        void _Create_Cookies()
        {
            if (Request.Browser.Cookies)
            {
                HttpCookie _CookieUid = new HttpCookie("uid");
                _CookieUid.Value = (string)Session["uid"];
                _CookieUid.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(_CookieUid);
                HttpCookie _CookiePwd = new HttpCookie("pwd");
                _CookiePwd.Value = (string)Session["pwd"];
                _CookiePwd.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(_CookiePwd);
                HttpCookie _CookieChk = new HttpCookie("chk");
                _CookieChk.Value = (string)Session["chk"];
                _CookieChk.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(_CookieChk);
                HttpCookie _CookieUaccess = new HttpCookie("access");
                _CookieUaccess.Value = (string)Session["access"];
                _CookieUaccess.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(_CookieUaccess);
                HttpCookie _CookieUgroup = new HttpCookie("group");
                _CookieUgroup.Value = (string)Session["group"];
                _CookieUgroup.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(_CookieUgroup);
                HttpCookie _Cookieidrem = new HttpCookie("id_rem");
                _Cookieidrem.Value = (string)Session["id_rem"];
                _Cookieidrem.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(_Cookieidrem);
                HttpCookie _Cookiepwdrem = new HttpCookie("pwd_rem");
                _Cookiepwdrem.Value = (string)Session["pwd_rem"];
                _Cookiepwdrem.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(_Cookiepwdrem);
            }
            else
                return;
        }
        void _toDeleteCookies()
        {
            if (Request.Browser.Cookies)
            {
                string[] _cookies = Request.Cookies.AllKeys;
                foreach (string cookie in _cookies)
                {
                    Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-10);
                }
            }
        }
        void User_Log()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clslog _objcls = new _clslog();
            _objcls.uid = (string)Session["uid"];         
            string _login = Request.Form["_login"].ToString();
            _objcls.ipaddr = Request.Form["_ip"].ToString();
            List<string> _result = LoadIPLocation(_objcls.ipaddr);
            _objcls.Country = _result[0];
            _objcls.Region = _result[1];
            _objcls.location = _result[2];
            _objcls.module = "CMS";
            _objcls.login = _login;
            _objbll.UpdateUserLog(_objcls,_objdb);
        }

       
        private List<string> LoadIPLocation(string ipAddress)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                if (!string.IsNullOrEmpty(ipAddress))
                {
                    string info = new WebClient().DownloadString("http://ipinfo.io/" + ipAddress);
                    ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                    RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
                    ipInfo.Country = myRI1.EnglishName;

                }

            }
            catch
            {

            }
            finally
            {

            }
            List<string> locationdetails = new List<string>();
            locationdetails.Add(ipInfo.Country);
            locationdetails.Add(ipInfo.Region);
            locationdetails.Add(ipInfo.City);
            return locationdetails;
        }
        protected void cmdlogin_Click(object sender, EventArgs e)
        {
            //_msg.Text = "";
            if (cmdlogin.Text == "Login")
            {
                BLL_Dml _obj = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "dbCML";
                _clsuser _clsobj = new _clsuser();
                _clsobj.uid = _uid.Text;
                _clsobj.pwd = _pwd.Text;
                string _LoginInfo=_obj.ChkUserLoggedIN(_clsobj,_objdb);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _LoginInfo + "');", true);
                //if (_LoginInfo != "NotExist")
                //{
                //    string _ip = _LoginInfo.Substring(0, _LoginInfo.IndexOf("_L"));
                //    string _login = _LoginInfo.Substring(_LoginInfo.IndexOf("_L") + 2);
                //    string _msg = _uid.Text + " is already LOGGED IN with IP Address: " + _ip + " and Login time: " + _login;
                //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _msg + "');", true);
                //    return;
                //    //http://www.erichynds.com/jquery/a-new-and-improved-jquery-idle-timeout-plugin/
                //}
                //else
                //{
                if (_obj._validUser(_clsobj, _objdb) == false)
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid UserID/Password');", true);
                else
                {


                    //Session["id_rem"] = _uid.Text;
                    //Session["pwd_rem"] = _pwd.Text;
                    Session["uid"] = _uid.Text;
                    BLL_Dml _objbll = new BLL_Dml();
                    Session["group"] = _objbll.getUserGroup(_clsobj, _objdb);
                    if (chkremind.Checked == true)
                    {
                        Session["id_rem"] = _uid.Text;
                        Session["pwd_rem"] = _pwd.Text;
                        Session["chk"] = "yes";
                        //_uid.Text = String.Empty;
                        //_pwd.Text = String.Empty;
                    }
                    else
                    {
                        Session["id_rem"] = "";
                        Session["pwd_rem"] = "";
                        Session["chk"] = "no";
                    }
                    _Create_Cookies();
                    User_Log();
                    if ((string)Session["prm"] != "")
                        LoginFromEmail((string)Session["prm"]);
                    else
                        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.call();", true);

                }
                //}
            }
            else if(cmdlogin.Text=="Change Password")
            {
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "dbCML";
                _clsuser _objcls = new _clsuser();
                _objcls.uid = _uid.Text;
                _objcls.pwd = _pwd.Text;
                if (_objbll._validUser(_objcls,_objdb) == true)
                {
                    if (string.Compare(_pwdn.Text, _pwdc.Text) != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Confirm Password is not matching!');", true);
                        return;
                    }
                    _objcls.pwd = _pwdn.Text;
                    _objbll._chngPwd(_objcls,_objdb);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Your Password has been changed!');", true);
                    Session["uid"] = _uid.Text;
                    Session["group"] = _objbll.getUserGroup(_objcls,_objdb);
                    _Create_Cookies();
                   // Response.Redirect("cmlhome.aspx", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid UserID/Password');", true);
            }
            else if (cmdlogin.Text == "Email Password")
            {
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "dbCML";
                _clsuser _objcls = new _clsuser();
                _objcls.uid = _uid.Text;
                string _pwd = _objbll.GetAutoPassword(_objcls,_objdb);
                if (_pwd != "0")
                {
                    Send_Mail(_pwd);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Your Password has been sent!');", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid UserID!');", true);

            }
        }
        void Send_Mail(string _pwd)
        {
            publicCls.publicCls _objcls = new publicCls.publicCls();
            string Body = "CML Techniques Access :" + "\n\n\n" + "Your User Id is : " + _uid.Text + "\n" + "Your Password is : " + _pwd + "\n\n\n" + "https://cmltechniques.com";
            string _sub = "CML Techniques Access";
            _objcls.Send_Email(_uid.Text, _sub, Body);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //loginpanel.Style.Add("Visibility", "hidden");
            //myframe.Visible = true;
            //myframe.Attributes.Add("src","changepassword.aspx");
        }
        protected void pwdchange_Click(object sender, EventArgs e)
        {
            //if (pwdchange.Text == "Change My Password")
            //{
            //    myframe.Attributes["src"] = "chgpwd.aspx";
            //    pwdchange.Text = "Back to Login";
            //    pwdemail.Visible = false;
            //}
            //else
            //{
            //    myframe.Attributes["src"] = "loginpage.aspx";
            //    pwdchange.Text = "Change My Password";
            //    pwdemail.Visible = true ;
            //}
        }
        protected void pwdemail_Click(object sender, EventArgs e)
        {
            //myframe.Attributes["src"] = "pwdemail.aspx";
            //pwdchange.Text = "Back to Login";
            //pwdemail.Visible = false;
        }

        protected void btnchg_Click(object sender, EventArgs e)
        {
            if (btnchg.Text == "Change Password") 
            {
                lblnpwd.Visible = true;
                lblcpwd.Visible = true;
                _pwdn.Visible = true;
                _pwdc.Visible = true;
                _pwdn.Text = "";
                _pwdc.Text = "";
                chkremind.Visible = false;
                cmdlogin.Text = "Change Password";
                btnchg.Text = "Back To Login";
                btnemail.Visible = false;
            }
            else
            {
                lblnpwd.Visible = false;
                lblcpwd.Visible = false;
                _pwdn.Visible = false;
                _pwdc.Visible = false;
                chkremind.Visible = true;
                cmdlogin.Text = "Login";
                btnchg.Text = "Change Password";
                btnemail.Visible = true;
            }
        }
        protected void btnemail_Click(object sender, EventArgs e)
        {
            if (btnemail.Text == "Email Password")
            {
                lblnpwd.Visible = false;
                lblcpwd.Visible = false;
                _pwdn.Visible = false;
                _pwdc.Visible = false;
                chkremind.Visible = false;
                cmdlogin.Text = "Email Password";
                btnemail.Text = "Back To Login";
                lblpwd.Visible = false;
                _pwd.Visible = false;
                btnchg.Visible = false;
            }
            else
            {
                chkremind.Visible = true;
                lblpwd.Visible = true;
                _pwd.Visible = true;
                cmdlogin.Text = "Login";
                btnemail.Text = "Email Password";
                btnchg.Visible = true;
            }
        }

        private void LoginFromEmail(string _prm)
        {
            string _project = _prm.Substring(3, _prm.IndexOf("M_") - 3);
            string _module = _prm.Substring(_prm.IndexOf("M_") + 2);
            Session["project"] = _project;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = _project;
            string _projectName = _objbll.Get_ProjectName(_objcls, _objdb);
            Session["projectname"] = _projectName;
            if (_project == "HMIM")
            {
                Response.Redirect("CMS/CMS2.aspx?" + Request.QueryString.ToString().Replace("&", "<>"));
            }
            else
            {
                Response.Redirect("CMS/CMS.aspx?id=" + _prm);
            }
        }
    }
    public class IpInfo
    {

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("loc")]
        public string Loc { get; set; }

        [JsonProperty("org")]
        public string Org { get; set; }

        [JsonProperty("postal")]
        public string Postal { get; set; }
    }
}
