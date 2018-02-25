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
    public partial class CXIssues_Basic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                lbl_prj.Text = "CCAD";
                if (_prm == "0")
                {
                    TabContainer1.Tabs[1].Enabled = false;
                    TabContainer1.Tabs[2].Enabled = false;
                }
                else
                {
                    lblid.Text = _prm;
                    Load_Cx_Issues();
                }
            }
        }
        private void Load_Cx_Issues()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lbl_prj.Text;
            _clscassheet _objcls = new _clscassheet();
            _objcls.c_s_id = Convert.ToInt32(lblid.Text);
            DataTable _dtbasic = _objbll.load_cx_issues_basic(_objcls, _objdb);
            foreach (DataRow _drow in _dtbasic.Rows)
            {
                drsdoc.ClearSelection();
                drservice.ClearSelection();
                drtype.ClearSelection();
                drloc.ClearSelection();
                if (Check_ExistList(drsdoc, _drow["source_doc"].ToString()) == true)
                    drsdoc.Items.FindByText(_drow["source_doc"].ToString()).Selected = true;
                txt_sdocref.Text = _drow["source_doc_ref"].ToString();
                txt_cx_issue.Text = _drow["zutec_cx_issue"].ToString();
                txt_system.Text = _drow["system"].ToString();
                if (Check_ExistList(drservice, _drow["discipline"].ToString()) == true)
                    drservice.Items.FindByText(_drow["discipline"].ToString()).Selected = true;
                if (Check_ExistList(drtype, _drow["issue_type"].ToString()) == true)
                    drtype.Items.FindByText(_drow["issue_type"].ToString()).Selected = true;
                if (Check_ExistList(drloc, _drow["location"].ToString()) == true)
                    drloc.Items.FindByText(_drow["location"].ToString()).Selected = true;
                txt_desc.Text = _drow["description"].ToString();
                txt_resp.Text = _drow["responsible"].ToString();
                txt_dtrep.Text = _drow["date_rep"].ToString();
                txt_dttclosure.Text = _drow["date_tc"].ToString();
                txt_dtlu.Text = _drow["last_update"].ToString();
                txt_dtclsd.Text = _drow["date_clsd"].ToString();
            }
            DataTable _dtasmnt = _objbll.load_cx_issues_assessment(_objcls, _objdb);
            foreach (DataRow _drow1 in _dtasmnt.Rows)
            {
                drimpact.ClearSelection();
                if (Check_ExistList(drimpact, _drow1["impact"].ToString()) == true)
                    drimpact.Items.FindByText(_drow1["impact"].ToString()).Selected = true;
                txt_ides.Text = _drow1["description"].ToString();
                drprob.ClearSelection();
                if (Check_ExistList(drprob, _drow1["probability"].ToString()) == true)
                    drprob.Items.FindByText(_drow1["probability"].ToString()).Selected = true;
                drtimeline.ClearSelection();
                if (Check_ExistList(drtimeline, _drow1["timeline"].ToString()) == true)
                    drtimeline.Items.FindByText(_drow1["timeline"].ToString()).Selected = true;
                drsres.ClearSelection();
                if (Check_ExistList(drsres, _drow1["resp_status"].ToString()) == true)
                    drsres.Items.FindByText(_drow1["resp_status"].ToString()).Selected = true;
            }
            DataTable _dtmgtn = _objbll.load_cx_issues_mitigation(_objcls, _objdb);
            foreach (DataRow _drow2 in _dtmgtn.Rows)
            {
                txt_caction.Text = _drow2["c_action"].ToString();
                txt_faction.Text = _drow2["f_action"].ToString();
                drrstatus.ClearSelection();
                if (Check_ExistList(drrstatus, _drow2["r_status"].ToString()) == true)
                    drrstatus.Items.FindByText(_drow2["r_status"].ToString()).Selected = true;
            }
            btnsave.Text = "Update";
        }
        private bool Check_ExistList(DropDownList _lst, string _item)
        {
            foreach (ListItem _lstitm in _lst.Items)
            {
                if (String.Compare(_lstitm.Text, _item) == 0)
                    return true;
            }
            return false;
        }
        protected void load_services(string Project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + Project;
            drservice.DataSource = _objbll.Load_Cas_service(_objdb);
            drservice.DataTextField = "PRJ_SER_NAME";
            drservice.DataValueField = "SYS_SER_ID";
            drservice.DataBind();
            drservice.Items.Insert(0, "-- Select Service --");
        }
        private void Add_CX_Issue_Log()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lbl_prj.Text;
            _clscassheet _objcls = new _clscassheet();
            _objcls.c_s_id = 0;
            _objcls.doc = drsdoc.SelectedItem.Text;
            _objcls.reff = txt_sdocref.Text;
            _objcls.cx_issue = txt_cx_issue.Text;
            _objcls.srv = 0;
            _objcls.sch_name = txt_system.Text;
            _objcls.type = drtype.SelectedItem.Text;
            _objcls.loca = drloc.SelectedItem.Text;
            _objcls.desc = txt_desc.Text;
            _objcls.responsible = txt_resp.Text;
            _objcls.dt_rep = txt_dtrep.Text;
            _objcls.dt_tc = txt_dttclosure.Text;
            _objcls.last_update = txt_dtlu.Text;
            _objcls.dt_closed = txt_dtclsd.Text;
            _objcls.dt_closure = "";
            _objcls.resol_status = "";
            _objcls.disci = drservice.SelectedItem.Text;
            _objcls.action = 1;
            int _id = _objbll.dml_cx_issues_log(_objcls, _objdb);
            lblid.Text = _id.ToString();
            if (_id > 0)
            {
                TabContainer1.Tabs[1].Enabled = true;
                TabContainer1.Tabs[2].Enabled = true;
            }
        }
        private void Update_CX_Issue_Log()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lbl_prj.Text;
            _clscassheet _objcls = new _clscassheet();
            _objcls.c_s_id = Convert.ToInt32(lblid.Text);
            _objcls.doc = drsdoc.SelectedItem.Text;
            _objcls.reff = txt_sdocref.Text;
            _objcls.cx_issue = txt_cx_issue.Text;
            _objcls.srv = 0;
            _objcls.sch_name = txt_system.Text;
            _objcls.type = drtype.SelectedItem.Text;
            _objcls.loca = drloc.SelectedItem.Text;
            _objcls.desc = txt_desc.Text;
            _objcls.responsible = txt_resp.Text;
            _objcls.dt_rep = txt_dtrep.Text;
            _objcls.dt_tc = txt_dttclosure.Text;
            _objcls.last_update = txt_dtlu.Text;
            _objcls.dt_closed = txt_dtclsd.Text;
            _objcls.dt_closure = "";
            _objcls.resol_status = "";
            _objcls.disci = drservice.SelectedItem.Text;
            _objcls.action = 2;
            int _id = _objbll.dml_cx_issues_log(_objcls, _objdb);
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
                Add_CX_Issue_Log();
            else
                Update_CX_Issue_Log();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('CX Issues Log Basic Information Updated');", true);
        }

        private void Update_Cx_Risk_Assessment()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lbl_prj.Text;
            _clscassheet _objcls = new _clscassheet();
            _objcls.c_s_id = Convert.ToInt32(lblid.Text);
            _objcls.impact = drimpact.SelectedItem.Text;
            _objcls.desc = txt_ides.Text;
            _objcls.prob = drprob.SelectedItem.Text;
            _objcls.timeline = drtimeline.SelectedItem.Text;
            _objcls.rstatus = drsres.SelectedItem.Text;
            _objbll.update_cx_risk_assessment(_objcls, _objdb);
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('CX Issues Log Risk Assessment Updated');", true);
        }
        private void Update_Cx_Mitigation()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lbl_prj.Text;
            _clscassheet _objcls = new _clscassheet();
            _objcls.c_s_id = Convert.ToInt32(lblid.Text);
            _objcls.caction = txt_caction.Text;
            _objcls.faction = txt_faction.Text;
            _objcls.rstatus = drrstatus.SelectedItem.Text;
            _objbll.update_cx_mitigation(_objcls, _objdb);
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('CX Issues Log Risk Mitigation Updated');", true);
        }
        protected void btnsave1_Click(object sender, EventArgs e)
        {
            Update_Cx_Risk_Assessment();
        }

        protected void btnsave2_Click(object sender, EventArgs e)
        {
            Update_Cx_Mitigation();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("GridSample.aspx?id=" + lbl_prj.Text);
        }
    }
}
