using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Data;

namespace CmlTechniques
{
    public partial class usercreation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_project();
                Load_user();
                load_Company();
                access.Visible = false;
                access1.Visible = false;
            }
        }
        private void load_project()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            chkproject.DataSource = _objbll.load_project(_objdb);
            chkproject.DataTextField = "prj_name";
            chkproject.DataValueField = "prj_code";
            chkproject.DataBind();
            chkproject1.DataSource = _objbll.load_project(_objdb);
            chkproject1.DataTextField = "prj_name";
            chkproject1.DataValueField = "prj_code";
            chkproject1.DataBind();
            
        }
        protected void Load_user()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            druserid.DataSource = _objbll.Load_ALLUsers(_objdb);
            druserid.DataTextField = "userid";
            druserid.DataValueField = "userid";
            druserid.DataBind();
            druserid.Items.Insert(0, "<<Select User>>");
            druserid.Items[0].Value = "0";
        }
        protected void drusergroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drusergroup.SelectedItem.Value == "1")
            {
                access.Visible = true;
                for (int i = 0; i <= chkmodule.Items.Count - 1; i++)
                {
                    chkmodule.Items[i].Selected = false;
                }
                for (int i = 0; i <= chkproject.Items.Count - 1; i++)
                {
                    chkproject.Items[i].Selected = false;
                }
                for (int i = 0; i <= chkadminaccess.Items.Count - 1; i++)
                {
                    chkadminaccess.Items[i].Selected = false;
                }
            }
            else if (drusergroup.SelectedItem.Value == "2")
            {
                access.Visible = true;
                for (int i = 0; i <= chkmodule.Items.Count - 1; i++)
                {
                    chkmodule.Items[i].Selected = true;
                }
                for (int i = 0; i <= chkproject.Items.Count - 1; i++)
                {
                    chkproject.Items[i].Selected = true;
                }
                for (int i = 0; i <= chkadminaccess.Items.Count - 1; i++)
                {
                    chkadminaccess.Items[i].Selected = true;
                }

            }
            else
            {
                access.Visible = false;
                for (int i = 0; i <= chkmodule.Items.Count - 1; i++)
                {
                    chkmodule.Items[i].Selected = false;
                }
                for (int i = 0; i <= chkproject.Items.Count - 1; i++)
                {
                    chkproject.Items[i].Selected = false;
                }
                for (int i = 0; i <= chkadminaccess.Items.Count - 1; i++)
                {
                    chkadminaccess.Items[i].Selected = false ;
                }
            }


        }
        protected void txtuid1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void Load_UserDetails()
        {
            BLL_Dml _objbll=new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            DataTable _dtable = _objbll.Load_ALLUsers(_objdb);
            var _result = from o in _dtable.AsEnumerable()
                          where o.Field<string>(0) == druserid.SelectedItem.Text
                          select o;
            foreach (var row in _result)
            {
                txtuname1.Text = row[1].ToString();
                drusergroup1.SelectedValue = row[2].ToString();
                if (row[2].ToString() == "ADMIN GROUP" || row[2].ToString() == "SYS.ADMIN GROUP")
                {
                    access1.Visible = true;
                }
                else
                    access1.Visible = false;
                if (row[6].ToString() == "True") chkadminaccess1.Items[0].Selected = true;
                else chkadminaccess1.Items[0].Selected = false;
                if (row[7].ToString() == "True") chkadminaccess1.Items[1].Selected = true;
                else chkadminaccess1.Items[1].Selected = false;
                if (row[8].ToString() == "True") chkadminaccess1.Items[2].Selected = true;
                else chkadminaccess1.Items[2].Selected = false;
                if (row[3].ToString() == "True") chkmodule1.Items[0].Selected = true;
                else chkmodule1.Items[0].Selected = false;
                if (row[4].ToString() == "True") chkmodule1.Items[1].Selected = true;
                else chkmodule1.Items[1].Selected = false;
                if (row[5].ToString() == "True") chkmodule1.Items[2].Selected = true;
                else chkmodule1.Items[2].Selected = false;
                ListItem li = drcompany1.Items.FindByText(row["Company"].ToString());
                drcompany1.ClearSelection();
                if (li != null)
                    drcompany1.Items.FindByText(row["Company"].ToString()).Selected = true;

            }
            load_auth_projects();
        }

        protected void druserid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (druserid.SelectedItem.Text == "<<Select User>>") return;
            //Clear();
            Load_UserDetails();
        }
        protected void load_auth_projects()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = druserid.SelectedItem.Text;
            DataTable _dtable = _objbll.load_projecthome(_objcls,_objdb);
            foreach (DataRow _item in _dtable.Rows)
            {
                for (int i = 0; i < chkproject1.Items.Count; i++)
                {
                    if (chkproject1.Items[i].Text == _item[1].ToString())
                    {
                        chkproject1.Items[i].Selected = true;
                        //chkproject1.Items[i].Attributes.Add("Style", "background-color: blue;");
                    }
                    

                }
            }
        }
        protected void Clear()
        {
            txtuname1.Text = "";
            druserid.SelectedValue = "0";
            //drusergroup1.SelectedValue = "USER GROUP";
            for (int i = 0; i < chkproject1.Items.Count; i++)
                chkproject1.Items[i].Selected = false;
            for (int i = 0; i < chkmodule1.Items.Count; i++)
                chkmodule1.Items[i].Selected = false;
            for (int i = 0; i < chkadminaccess1.Items.Count; i++)
                chkadminaccess1.Items[i].Selected = false;
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            Edit_User();
        }
        private bool IsnullValidation()
        {
            if (txtuid.Text.Trim().Length <= 0) { ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('User Name Required!');", true); return true; }
            return false;
        }
        protected void Edit_User()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = druserid.SelectedItem.Text.Trim();
            _objcls.pwd = "";
            _objcls.uname = txtuname1.Text;
            _objcls.user_group = drusergroup1.SelectedItem.Text;
            if (chkmodule1.Items[0].Selected == true) _objcls.CMS = true;
            else _objcls.CMS = false;
            if (chkmodule1.Items[1].Selected == true) _objcls.DMS = true;
            else _objcls.DMS = false;
            if (chkmodule1.Items[2].Selected == true) _objcls.TMS = true;
            else _objcls.TMS = false;
            if (chkadminaccess1.Items[0].Selected == true) _objcls.CU = true;
            else _objcls.CU = false;
            if (chkadminaccess1.Items[1].Selected == true) _objcls.CP = true;
            else _objcls.CP = false;
            if (chkadminaccess1.Items[2].Selected == true) _objcls.PM = true;
            else _objcls.PM = false;
            _objcls.mode = 0;
            _objcls.company = drcompany1.SelectedItem.Text;
            _objbll.Create_user(_objcls,_objdb);
            Set_Project1();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('User account has been updated');", true);
            Clear();

        }
        protected void Add_User()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = txtuid.Text;
            Generate_Autopassword();
            _objcls.pwd = (string)Session["Autopassword"];
            _objcls.uname = txtuname.Text;
            _objcls.user_group = drusergroup.SelectedItem.Text;
            if (chkmodule.Items[0].Selected == true) _objcls.CMS = true;
            else _objcls.CMS = false;
            if (chkmodule.Items[1].Selected == true) _objcls.DMS = true;
            else _objcls.DMS = false;
            if (chkmodule.Items[2].Selected == true) _objcls.TMS = true;
            else _objcls.TMS = false;
            if (chkadminaccess.Items[0].Selected == true) _objcls.CU = true;
            else _objcls.CU = false;
            if (chkadminaccess.Items[1].Selected == true) _objcls.CP = true;
            else _objcls.CP = false;
            if (chkadminaccess.Items[2].Selected == true) _objcls.PM = true;
            else _objcls.PM = false;
            _objcls.mode = 1;
            _objcls.company = drcompany.SelectedItem.Text;
            _objbll.Create_user(_objcls,_objdb);
            Set_Project();
            Send_Password_toUser();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('User account has been created');", true);
            Clear_add();
        }
        protected void Clear_add()
        {
            txtuid.Text = "";
            txtuname.Text = "";
            //drusergroup.SelectedValue = "USER GROUP";
            for (int i = 0; i < chkproject.Items.Count; i++)
                chkproject.Items[i].Selected = false;
            for (int i = 0; i < chkmodule.Items.Count; i++)
                chkmodule.Items[i].Selected = false;
            for (int i = 0; i < chkadminaccess.Items.Count; i++)
                chkadminaccess.Items[i].Selected = false;
        }
        protected void Send_Password_toUser()
        {
            //string _Message="Dear Sir," + "\n" + "Your user account for CML Interactive has been created." +"\n\n" + "LOGIN INFORMATION:" + "\n" + "User Name :" + userid.Text + "\n" + "Password :" +  (string)Session["Autopassword"];
            string _Message = "";
            //if (chkmodule1.Items[0].Selected == true && chkmodule1.Items[1].Selected == false)
            //{
            //    _Message = "This email has been sent to you from CML Techniques" + "\n\n" + "It is an automatic message that is generated directly from our CML interactive online documentation system." + "\n\n" + "You now have access to the " + "" + " online documents." + "\n\n\n" + "User Name : " + txtuid.Text + "\n" + "Password : " + (string)Session["Autopassword"] + "\n\n\n" + "Please follow the link below to login : " + "\n" + "https://cmltechniques.com" + "\n\n\n" + "if you encounter any problems then email our system administrator at admin@cmlinternational.net" + "\n\n" + "Kind regards," + "\n" + "CML Techniques";
            //}
            //else if (chkmodule1.Items[0].Selected == false && chkmodule1.Items[1].Selected == true)
            //{
                _Message = "This email has been sent to you from CML Techniques" + "\n\n" + "It is an automatic message that is generated directly from our CML interactive online documentation system." + "\n\n" + "You now have access to the " + "" + " online documents." + "\n\n\n" + "User Name : " + txtuid.Text + "\n" + "Password : " + (string)Session["Autopassword"] + "\n\n\n" + "Please follow the link below to login : " + "\n" + "https://dms.cmltechniques.com" + "\n\n\n" + "if you encounter any problems then email our system administrator at admin@cmlinternational.net" + "\n\n" + "Kind regards," + "\n" + "CML Techniques";
            //}
            //else
            //{
            //    _Message = "This email has been sent to you from CML Techniques" + "\n\n" + "It is an automatic message that is generated directly from our CML interactive online documentation system." + "\n\n" + "You now have access to the " + "" + " online documents." + "\n\n\n" + "User Name : " + txtuid.Text + "\n" + "Password : " + (string)Session["Autopassword"] + "\n\n\n" + "Please follow the link below to login : " + "\n" + "CMS Access : https://dms.cmltechniques.com, DMS Access : https://dms.cmltechniques.com" + "\n\n\n" + "if you encounter any problems then email our system administrator at admin@cmlinternational.net" + "\n\n" + "Kind regards," + "\n" + "CML Techniques";
            //}
                if ((chkmodule.Items[0].Selected == true) && (chkmodule.Items[1].Selected == true))
                {
                    _Message = "This email has been sent to you from CML Techniques" + "\n\n" + "It is an automatic message that is generated directly from our CML interactive online documentation system." + "\n\n" + "You now have access to the " + "" + " online documents." + "\n\n\n" + "User Name : " + txtuid.Text + "\n" + "Password : " + (string)Session["Autopassword"] + "\n\n\n" + "Please follow the link below to login : " + "\n" + "CMS Access : https://cmltechniques.com, DMS Access : https://dms.cmltechniques.com" + "\n\n\n" + "if you encounter any problems then email our system administrator at admin@cmlinternational.net" + "\n\n" + "Kind regards," + "\n" + "CML Techniques";
                }
                else if (chkmodule.Items[1].Selected == true)
                {
                    _Message = "This email has been sent to you from CML Techniques" + "\n\n" + "It is an automatic message that is generated directly from our CML interactive online documentation system." + "\n\n" + "You now have access to the " + "" + " online documents." + "\n\n\n" + "User Name : " + txtuid.Text + "\n" + "Password : " + (string)Session["Autopassword"] + "\n\n\n" + "Please follow the link below to login : " + "\n" + "https://dms.cmltechniques.com" + "\n\n\n" + "if you encounter any problems then email our system administrator at admin@cmlinternational.net" + "\n\n" + "Kind regards," + "\n" + "CML Techniques";
                }
                else 
                {
                    _Message = "This email has been sent to you from CML Techniques" + "\n\n" + "It is an automatic message that is generated directly from our CML interactive online documentation system." + "\n\n" + "You now have access to the " + "" + " online documents." + "\n\n\n" + "User Name : " + txtuid.Text + "\n" + "Password : " + (string)Session["Autopassword"] + "\n\n\n" + "Please follow the link below to login : " + "\n" + "https://cmltechniques.com" + "\n\n\n" + "if you encounter any problems then email our system administrator at admin@cmlinternational.net" + "\n\n" + "Kind regards," + "\n" + "CML Techniques";
                }

            publicCls.publicCls _objcls = new publicCls.publicCls();
            _objcls.Send_Email(txtuid.Text, "CML Techniques User Access..", _Message);

        }
        protected void Generate_Autopassword()
        {
            string _id = txtuid.Text.Substring(0, txtuid.Text.IndexOf("@"));
            string _id1 = "";
            //msg.Text = _id.Length.ToString();
            try
            {
                for (int i = _id.Length; i > 0; i--)
                {
                    _id1 = _id1 + DateTime.Now.ToLocalTime().Minute.ToString();
                    _id1 = _id1 + _id.Substring(i - 1, 1);
                    _id1 = _id1 + DateTime.Now.ToLocalTime().Second.ToString();
                }
                _id1 = System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(_id1.Substring(3)));
                Session["Autopassword"] = _id1.Substring(0, 10);

            }
            catch (Exception ex)
            {
               // msg.Text = ex.ToString();
            }
            //string pwd = System.Convert.ToBase64String( System.Text.Encoding.Unicode.GetBytes(_id + _id.Length.ToString() ));
            //msg.Text = pwd.Substring(0,3) + pwd.Substring(pwd.Length-3,3) + pwd.Substring(pwd.Length/2-1,3);
        }
        void Set_Project()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = txtuid.Text;
            for (int i = 0; i <= chkproject.Items.Count - 1; i++)
            {
                if (chkproject.Items[i].Selected == true)
                {
                    _objcls.project_code = chkproject.Items[i].Value.ToString();
                    _objbll.Insert_UserPrj(_objcls,_objdb);
                }
            }
        }
        void Set_Project1()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = druserid.SelectedItem.Text;
            for (int i = 0; i <= chkproject1.Items.Count - 1; i++)
            {
                if (chkproject1.Items[i].Selected == true)
                {
                    _objcls.project_code = chkproject1.Items[i].Value.ToString();
                    _objbll.Insert_UserPrj(_objcls,_objdb);
                }
            }
        }

        protected void btncancel1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Clear_add();
        }

        protected void btncreate_Click(object sender, EventArgs e)
        {
            Add_User();
        }
        private void load_Company()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            drcompany.DataSource = _objbll.Load_Company_Master(_objdb);
            drcompany.DataTextField = "Com_name";
            drcompany.DataValueField = "Com_id";
            drcompany.DataBind();
            drcompany.Items.Insert(0, "-- Select --");
            drcompany1.DataSource = _objbll.Load_Company_Master(_objdb);
            drcompany1.DataTextField = "Com_name";
            drcompany1.DataValueField = "Com_id";
            drcompany1.DataBind();
            drcompany1.Items.Insert(0, "-- Select --");
        }

    }
}
