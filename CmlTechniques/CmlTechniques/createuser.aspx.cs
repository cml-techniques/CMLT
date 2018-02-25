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
    public partial class createuser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_category();
                load_project();
                //load_services();
            }
        }

        protected void cmdcreate_Click(object sender, EventArgs e)
        {
            if (IsnullValidation() == true) return;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = userid.Text.Trim();
            Generate_Autopassword();
            set_services();
            _objcls.pwd = (string)Session["Autopassword"];
            _objcls.uname = username.Text;
            _objcls.project_code = "";
            _objcls.access = "";
            _objcls.user_group = "";
            _objcls.CMS = false;
            _objcls.DMS = false;
            _objcls.TMS = false;
            _objcls.CU = false;
            _objcls.CP = false;
            _objcls.PM = false;        
            //_objcls.service = "";
            try
            {
                string _msg = "";
                if (cmdcreate.Text == "Create User")
                {
                    //_objcls.edit = false;
                    _objcls.mode = 0;
                    Send_Password_toUser();
                    _msg = "User Account has been created!" ;
                }
                else
                {
                    //_objcls.edit = true;
                    _objcls.mode = 1;
                    _msg = "User Account has been Changed!";

                }
                _objbll.Create_user(_objcls,_objdb);
                Set_Project();
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ _msg  +"');", true); 
                clear();
            }
            catch (Exception ex)
            {
                msg.Text = ex.ToString();
            }
        }
        private bool IsnullValidation()
        {
            if (username.Text.Trim().Length <= 0) { ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('User Name Required!');", true); return true; }
            else if (userid.Text.Trim().Length <= 0) { ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('User ID Required!');", true); return true; }
            return false;
        }
        void Set_Project()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = userid.Text;
            for (int i = 0; i <= chkprj.Items.Count - 1; i++)
            {
                if (chkprj.Items[i].Selected == true)
                {
                    _objcls.project_code = chkprj.Items[i].Value.ToString();
                    _objbll.Insert_UserPrj(_objcls,_objdb);
                }
            }
        }
        void Send_Password_toUser()
        {
            //string _Message="Dear Sir," + "\n" + "Your user account for CML Interactive has been created." +"\n\n" + "LOGIN INFORMATION:" + "\n" + "User Name :" + userid.Text + "\n" + "Password :" +  (string)Session["Autopassword"];

            string _Message = "This email has been sent to you from CML Techniques" + "\n\n" + "It is an automatic message that is generated directly from our CML interactive online documentation system." + "\n\n" + "You now have access to the " + "" + " online documents." + "\n\n\n" + "User Name : " + userid.Text + "\n" + "Password : " + (string)Session["Autopassword"] + "\n\n\n" + "Please follow the link below to login : " + "\n" + "http://www.cmldubai.com" + "\n\n\n" + "if you encounter any problems then email our system administrator at admin@cmlinternational.net" + "\n\n" + "Kind regards," + "\n" + "CML Techniques";
            publicCls.publicCls _objcls = new publicCls.publicCls();
           _objcls.Send_Email(userid.Text, "CML Techniques User Access..",_Message );

        }
        private void load_category()
        {
            //categorydrlst.Items.Insert(0, "---- Select Access Level ----");
            //categorydrlst.Items.Add("Super Admin");
            //categorydrlst.Items.Add("Admin");
            //categorydrlst.Items.Add("Review/Comment");
            //categorydrlst.Items.Add("Review/Comment/Status");
        }
        private void load_project()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            chkprj.DataSource = _objbll.load_project(_objdb);
            chkprj.DataTextField = "prj_name";
            chkprj.DataValueField = "prj_code";
            chkprj.DataBind();
        }
        void clear()
        {
            userid.Text = "";
            username.Text = "";
            for (int _idx = 0; _idx <= chkprj.Items.Count - 1; _idx++)
            {
                if (chkprj.Items[_idx].Selected == true)
                    chkprj.Items[_idx].Selected = false;
            }

        }
        void Generate_Autopassword()
        {
            string _id = userid.Text.Substring(0,userid.Text.IndexOf("@"));
            string _id1 = "";
            //msg.Text = _id.Length.ToString();
            try
            {
                for (int i = _id.Length; i > 0; i--)
                {
                    _id1 = _id1+ DateTime.Now.ToLocalTime().Minute.ToString();
                    _id1 = _id1 + _id.Substring(i - 1, 1);
                    _id1 = _id1 + DateTime.Now.ToLocalTime().Second.ToString();
                }
                _id1=System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(_id1.Substring(3)));
                Session["Autopassword"] = _id1.Substring(0, 10);

            }
            catch (Exception ex)
            {
                msg.Text = ex.ToString();
            }
            //string pwd = System.Convert.ToBase64String( System.Text.Encoding.Unicode.GetBytes(_id + _id.Length.ToString() ));
            //msg.Text = pwd.Substring(0,3) + pwd.Substring(pwd.Length-3,3) + pwd.Substring(pwd.Length/2-1,3);
        }
        void load_services()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _clsmanufacture _objcls = new _clsmanufacture();
            _objcls.project_code = (string)Session["project"];
            //chkservice.DataSource = _objbll.load_service(_objcls);
            //chkservice.DataTextField = "Folder_description";
            //chkservice.DataValueField = "Folder_id";
            //chkservice.DataBind();
        }
        void set_services()
        {
            string _service = "";
            //for (int _idx = 0; _idx <= chkservice.Items.Count - 1; _idx++)
            //{
            //    if (chkservice.Items[_idx].Selected == true)
            //        _service = _service + chkservice.Items[_idx].Value.ToString() + " <" + (_idx + 1)+ ">";
            //    else
            //        _service = _service + "0" + " <" + (_idx + 1) + ">";

            //}
            Session["service"] = _service;
        }

        protected void cmdedit_Click(object sender, EventArgs e)
        {
            cmdcreate.Text = "Update user";
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = userid.Text;
            DataTable _dtable = _objbll.load_projecthome(_objcls,_objdb);
            foreach (DataRow _item in _dtable.Rows)
            {
                for (int i = 0; i <= chkprj.Items.Count - 1; i++)
                {
                    if (chkprj.Items[i].Text == _item[1].ToString())
                    {
                        chkprj.Items[i].Selected = true;
                        chkprj.Items[i].Attributes.Add("Style", "background-color: blue;");
                    }
                    
                }
                username.Text = _item[4].ToString();
            }

        }
    }
}
