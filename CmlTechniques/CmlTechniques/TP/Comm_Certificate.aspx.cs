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

namespace CmlTechniques.TP
{
    public partial class Comm_Certificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                lbl_casid.Text = _prm.Substring(0, _prm.IndexOf("_P"));
                lblprj.Text = _prm.Substring(_prm.IndexOf("_P") + 2);
                Get_ProjectName();
                Get_Assetcode();
                Load_Comm_Certificate();
            }
        }
        private void Get_ProjectName()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsuser _objcls=new _clsuser();
            _objcls.project_code=lblprj.Text;
            txt_project.Text = _objbll.Get_ProjectName(_objcls, _objdb);
        }
        private void Get_Assetcode()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clstestpack _objcls = new _clstestpack();
            _objcls.cas_id = Convert.ToInt32(lbl_casid.Text);
            txt_asset_code.Text = _objbll.Get_Assetcode(_objcls, _objdb);
        }
        private void Load_Comm_Certificate()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clstestpack _objcls = new _clstestpack();
            _objcls.cas_id = Convert.ToInt32(lbl_casid.Text);
            DataTable _dt = _objbll.Load_Comm_Certificate(_objcls, _objdb);
            foreach (DataRow _drow in _dt.Rows)
            {
                txt_system.Text = _drow["system"].ToString();
                txt_sheet_ref.Text = _drow["sheet_ref"].ToString();
                txt_asset_code.Text = _drow["asset_code"].ToString();
                txt_type_work.Text = _drow["type_work"].ToString();
                txt_location.Text = _drow["location"].ToString();
                txt_test_type.Text = _drow["test_type"].ToString();
                txt_comments.Text = _drow["comments"].ToString();
                txt_tested_by.Text = _drow["tested_by"].ToString();
                txt_dttest.Text = _drow["tested_date"].ToString();
                txt_witnessed.Text = _drow["witnessed_by"].ToString();
                txt_dtwitness.Text = _drow["wit_date"].ToString();
                txt_accepted.Text = _drow["accepted_by"].ToString();
                txt_dtaccept.Text = _drow["acce_date"].ToString();
                txt_instr_used.Text = _drow["instru_used"].ToString();
            }

        }
        

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            Submit_Certificate();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Certificate Submitted');", true);
        }
        private void Submit_Certificate()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clstestpack _objcls = new _clstestpack();
            _objcls.cas_id = Convert.ToInt32(lbl_casid.Text);
            _objcls.system = txt_system.Text;
            _objcls.sheet_ref = txt_sheet_ref.Text;
            _objcls.asset_code = txt_asset_code.Text;
            _objcls.type_work = txt_type_work.Text;
            _objcls.location = txt_location.Text;
            _objcls.test_type = txt_test_type.Text;
            _objcls.comments = txt_comments.Text;
            _objcls.tested_by = txt_tested_by.Text;
            _objcls.tested_date = txt_dttest.Text;
            _objcls.witnessed_by = txt_witnessed.Text;
            _objcls.wit_date = txt_dtwitness.Text;
            _objcls.accepted_by = txt_accepted.Text;
            _objcls.acce_date = txt_dtaccept.Text;
            _objcls.instru_used = txt_instr_used.Text;
            _objcls.action = 1;
            _objbll.dml_com_certificate(_objcls, _objdb);                
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            string _prm = lbl_casid.Text + "_P" + lblprj.Text;
            Response.Redirect("Comm_Checklist.aspx?id=" + _prm);
        }

        protected void btnpreview_Click(object sender, EventArgs e)
        {
            string _prm = "Preview.aspx?id=" + lbl_casid.Text + "_R1";
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _prm + "','','left=210,top=100,width=800,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=0');", true);
        }
    }
}
