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
    public partial class Manage_MSFolder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _parm = Request.QueryString[0].ToString();
                Session["folder_id"] = _parm.Substring(0, _parm.IndexOf("_T"));
                Session["folder_name"] = _parm.Substring(_parm.IndexOf("_T") + 2, _parm.IndexOf("_S") - (_parm.IndexOf("_T") + 2));
                Session["svr_id"] = _parm.Substring(_parm.IndexOf("_S") + 2);
                btndelete.Enabled = false;
                txtfolder.Enabled = false;
                btncreate.Enabled = false;
                Session["mspos"] = "";
                if ((string)Session["folder_id"] == "0")
                {
                    Set_Actions();
                    lbfolder.Text = "New";
                }
                else
                    lbfolder.Text = (string)Session["folder_name"].ToString().Replace("^", "&");

                if ((string)Session["project"] == "HMIM")  
                    Load_MSDeatils();
                else
                    trbuilding.Visible = false;
            }
        }
        private void Set_Actions()
        {
            draction.Items.Clear();
            ListItem lst = new ListItem();
            lst.Text = "Create System";
            lst.Value = "1";
            draction.Items.Add(lst);
            draction.Items.Insert(0, "-- Select Action --");

        }
        protected void draction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)Session["project"] == "HMIM")
            {
                chkcuc.Enabled = true;
                chkservice.Enabled = true;
                chkharam.Enabled = true;

            }
            if (draction.SelectedItem.Value == "1")
            {
                txtfolder.Text = String.Empty;
                btndelete.Enabled = false;
                btncreate.Text = "Save";
                btncreate.Enabled = true;
                txtfolder.Enabled = true;


            }
            else if (draction.SelectedItem.Value == "2")
            {
                txtfolder.Text = lbfolder.Text;
                btndelete.Enabled = true;
                btncreate.Text = "Update";
                btncreate.Enabled = true;
                txtfolder.Enabled = true;


                //if ((string)Session["project"] == "HMIM") Load_MSDeatils();

            }
            else if (draction.SelectedItem.Value == "3")
            {
                btndelete.Enabled = false;
                btncreate.Text = "Change Possition";
                btncreate.Enabled = true;
                txtfolder.Enabled = true;
                Label1.Text = "POSSITION";
                txtfolder.Text =(string)Session["mspos"];

                if ((string)Session["project"] == "HMIM")
                {
                    chkcuc.Enabled = false;
                    chkservice.Enabled = false;
                    chkharam.Enabled = false;
                }
            }
        }
        protected void Create_MsSystems()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.mssys_id = 0;
            _objcls.mssys_name = txtfolder.Text;
            _objcls.srv_id = Convert.ToInt32((string)Session["svr_id"]);
            _objcls.pos = 0;
            _objcls.action = 1;

            if ((string)Session["project"] == "HMIM")
            {
                _objcls.Build1 = chkharam.Checked;
                _objcls.Build2 = chkservice.Checked;
                _objcls.Build3 = chkcuc.Checked;
                _objbll.Manage_MsFolder_Div(_objcls, _objdb);
            }
            else
                _objbll.Manage_MsFolder(_objcls, _objdb);
                 
          
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Folder Created');", true);
        }
        protected void Update_MsSystems()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.mssys_id = Convert.ToInt32((string)Session["folder_id"]);
            _objcls.mssys_name = txtfolder.Text;
            _objcls.srv_id = 0;
            _objcls.pos = 0;
            _objcls.action = 2;

            if ((string)Session["project"] == "HMIM")
            {
                _objcls.Build1 = chkharam.Checked;
                _objcls.Build2 = chkservice.Checked;
                _objcls.Build3 = chkcuc.Checked;
                _objbll.Manage_MsFolder_Div(_objcls, _objdb);
            }
            else
            _objbll.Manage_MsFolder(_objcls, _objdb);

            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Folder Updated');", true);
        }
        protected void Delete_MsSystems()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.mssys_id = Convert.ToInt32((string)Session["folder_id"]);
            _objcls.mssys_name = txtfolder.Text;
            _objcls.srv_id = 0;
            _objcls.pos = 0;
            _objcls.action = 3;
            if ((string)Session["project"] == "HMIM")
            {
                _objcls.Build1 = chkharam.Checked;
                _objcls.Build2 = chkservice.Checked;
                _objcls.Build3 = chkcuc.Checked;
                _objbll.Manage_MsFolder_Div(_objcls, _objdb);
            }
            else
            _objbll.Manage_MsFolder(_objcls, _objdb);
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Folder Deleted');", true);
        }
        protected void Possition_MsSystems()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.mssys_id = Convert.ToInt32((string)Session["folder_id"]);
            _objcls.mssys_name = txtfolder.Text;
            _objcls.srv_id = Convert.ToInt32((string)Session["svr_id"]);
            if (txtfolder.Text.Length <= 0)
                txtfolder.Text = "0";
            _objcls.pos = Convert.ToInt32(txtfolder.Text);
            _objcls.action = 4;
            if ((string)Session["project"] == "HMIM")
            {
                _objcls.Build1 = chkharam.Checked;
                _objcls.Build2 = chkservice.Checked;
                _objcls.Build3 = chkcuc.Checked;
                _objbll.Manage_MsFolder_Div(_objcls, _objdb);
            }
            else
            _objbll.Manage_MsFolder(_objcls, _objdb);
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Folder Updated');", true);
        }
        protected void btncreate_Click(object sender, EventArgs e)
        {
            if (btncreate.Text == "Save")
                Create_MsSystems();
            else if (btncreate.Text == "Update")
                Update_MsSystems();
            else if (btncreate.Text == "Change Possition")
                Possition_MsSystems();

        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            Delete_MsSystems();
        }
        protected void Load_MSDeatils()
        {
            DataTable dtms;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcls = new _clscassheet();
            _objcls.sch = Convert.ToInt32((string)Session["folder_id"]);

            dtms = _objbll.Load_MSSYSTEM(_objcls, _objdb);

            if( dtms.Rows.Count>0)
            {
                chkharam.Checked=Convert.ToBoolean (dtms.Rows[0]["HARAM_PIAZZA"].ToString());
                chkservice.Checked=Convert.ToBoolean(dtms.Rows[0]["SERVICE_BLDNG"].ToString());
                chkcuc.Checked=Convert.ToBoolean(dtms.Rows[0]["CUC_T4"].ToString());

                Session["mspos"]=dtms.Rows[0]["POSSITION"].ToString();

            }
        }
    }
}
