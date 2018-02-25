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
    public partial class pwdemail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdlogin_Click(object sender, EventArgs e)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = _uid.Text;
            string _pwd = _objbll.GetAutoPassword(_objcls,_objdb);
            if (_pwd != "")
            {
                Send_Mail(_pwd);
            }
        }
        void Send_Mail(string _pwd)
        {
            publicCls.publicCls _objcls = new publicCls.publicCls();
            string Body = "Your Password is :" + _pwd + "\n\n\n" + "http://www.cmlinternational.net/aspnet/default.aspx";
            string _sub = "Password Recovery";
            _objcls.Send_Email(_uid.Text, _sub, Body);
        }
    }
}
