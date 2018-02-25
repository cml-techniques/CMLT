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
    public partial class CXIR_Master : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                lblprj.Text = _prm.Substring(_prm.IndexOf("_P") + 2);
                lblid.Text = _prm.Substring(0, _prm.IndexOf("_P"));
                if (lblid.Text == "0")
                {
                    btndelete.Visible = false;
                    lbltitle.Text = "CX_IR Record Schedule - Create New";
                }
                else
                {
                    btnsave.Text = "Update";
                    lbltitle.Text = "CX_IR Record Schedule - Update";
                    Load_CXIR_Details();
                }
            }
        }
        private void Load_CXIR_Details()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.c_s_id = Convert.ToInt32(lblid.Text);
            DataTable _dt = _objbll.Load_CXIR_Schedule_Details(_objcls, _objdb);
            foreach (DataRow _drow in _dt.Rows)
            {
                txt_ref.Text = _drow["ir_ref"].ToString();
                txt_rev.Text = _drow["ir_rev"].ToString();
                txt_dtrecv.Text = _drow["dt_recv"].ToString();
                txt_dtprop.Text = _drow["dt_prop"].ToString();
                drampm.ClearSelection();
                drampm.Items.FindByText(_drow["am_pm"].ToString()).Selected = true;
                txt_type.Text = _drow["test_type"].ToString();
                drservice.ClearSelection();
                drservice.Items.FindByText(_drow["discipline"].ToString()).Selected = true;
                txt_sys.Text = _drow["system"].ToString();
                txt_details.Text = _drow["details"].ToString();
                txt_bldg.Text = _drow["building"].ToString();
                txt_lvl.Text = _drow["flevel"].ToString();
                drloc.ClearSelection();
                drloc.Items.FindByText(_drow["location"].ToString()).Selected = true;
                txt_irchk.Text = _drow["ir_checked"].ToString();
                txt_adv.Text = _drow["advise"].ToString();
                txt_dtpstart.Text = _drow["prop_start"].ToString();
                txt_dtastart.Text = _drow["actual_start"].ToString();
                txt_delay.Text = _drow["dtdelay"].ToString();
                txt_dtcomp.Text = _drow["dt_compl"].ToString();
                txt_vist.Text = _drow["visit"].ToString();
                txt_witness.Text = _drow["witness"].ToString();
                txt_status.Text = _drow["ir_status"].ToString();
                txt_docstatus.Text = _drow["doc_status"].ToString();
                txt_svrno.Text = _drow["svr_no"].ToString();
                txt_notes.Text = _drow["notes"].ToString();
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (NullValidation() == true) return;
            if (btnsave.Text == "Save")
            {
                Insert_CXIR();
                //Reset();
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('New CX IR Record is Added');", true);
            }
            else
            {
                Update_CXIR();
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('CX IR Record is Updated');", true);
            }
            Response.Redirect("CXIR_Schedule.aspx?id=" + lblprj.Text);
        }
        private void Reset()
        {
            txt_ref.Text = "";
            txt_rev.Text = "";
            txt_dtrecv.Text = "";
            txt_dtprop.Text = "";
            txt_type.Text = "";
            drservice.ClearSelection();
            drservice.Items.FindByValue("0").Selected = true;
            txt_sys.Text = "";
            txt_details.Text = "";
            txt_bldg.Text = "";
            txt_lvl.Text = "";
            drloc.ClearSelection();
            drloc.Items.FindByValue("0").Selected = true;
            txt_irchk.Text = "";
            txt_adv.Text = "";
            txt_dtpstart.Text = "";
            txt_dtastart.Text = "";
            txt_delay.Text = "";
            txt_dtcomp.Text = "";
            txt_vist.Text = "";
            txt_witness.Text = "";
            txt_status.Text = "";
            txt_docstatus.Text = "";
            txt_svrno.Text = "";
            txt_notes.Text = "";
            btnsave.Text = "Save";
        }
        private bool DateValidation(string dateString)
        {
            DateTime dateValue;
            string[] format = new string[] { "dd/MM/yyyy" };
            if (DateTime.TryParseExact(dateString, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out dateValue))
                return true;
            else
                return false;

        }
        private bool NullValidation()
        {
            if (txt_ref.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Please Enter IR Reference');", true);
                txt_ref.Focus();
                return true;
            }
            else if (DateValidation(txt_dtrecv.Text) == false)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Received Date');", true);
                txt_dtrecv.Focus();
                return true;
            }
            else if (DateValidation(txt_dtprop.Text) == false)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Proposed Date');", true);
                txt_dtprop.Focus();
                return true;
            }
            else if (drservice.SelectedItem.Text == "Select Discipline")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Please Select Discipline');", true);
                drservice.Focus();
                return true;
            }
            else if (drloc.SelectedItem.Text == "Select Location")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Please Select Location');", true);
                drloc.Focus();
                return true;
            }
            else if (DateValidation(txt_dtpstart.Text) == false)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Proposed Start Date');", true);
                txt_dtpstart.Focus();
                return true;
            }
            else if (DateValidation(txt_dtastart.Text) == false)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Actual Start Date');", true);
                txt_dtastart.Focus();
                return true;
            }
            return false;
        }
        static bool IsNumeric(object Expression)
        {
            // Variable to collect the Return value of the TryParse method.
            bool isNum;

            // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
            double retNum;

            // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
            // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void Insert_CXIR()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.c_s_id = Convert.ToInt32(lblid.Text);
            _objcls.reff = txt_ref.Text;
            if (IsNumeric(txt_rev.Text) == false) txt_rev.Text = "0";
            _objcls.ir_rev = Convert.ToInt32(txt_rev.Text);
            _objcls.dt_rep = txt_dtrecv.Text;
            _objcls.dt_tc = txt_dtprop.Text;
            _objcls.am_pm = drampm.SelectedItem.Text;
            _objcls.type = txt_type.Text;
            _objcls.sch_name = drservice.SelectedItem.Text;
            _objcls.sys_name = txt_sys.Text;
            _objcls.desc = txt_details.Text;
            _objcls.build_name = txt_bldg.Text;
            if (IsNumeric(txt_lvl.Text) == false) txt_lvl.Text = "0";
            _objcls.flevel = Convert.ToInt32(txt_lvl.Text);
            _objcls.loca = drloc.SelectedItem.Text;
            _objcls.ir_chkd = txt_irchk.Text;
            _objcls.advise = txt_adv.Text;
            _objcls.dtpstart = Convert.ToDateTime(txt_dtpstart.Text);
            _objcls.dtastart = Convert.ToDateTime(txt_dtastart.Text);
            _objcls.dtcomp = txt_dtcomp.Text;
            if (IsNumeric(txt_vist.Text) == false) txt_vist.Text = "0";
            _objcls.visit = Convert.ToInt32(txt_vist.Text);
            _objcls.witness = txt_witness.Text;
            _objcls.ir_status = txt_status.Text;
            _objcls.doc_status = txt_docstatus.Text;
            _objcls.svr_no = txt_svrno.Text;
            _objcls.comm = txt_notes.Text;
            _objcls.mode = 1;
            _objbll.Dml_CXIR_Schedule(_objcls, _objdb);

        }
        private void Update_CXIR()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.c_s_id = Convert.ToInt32(lblid.Text);
            _objcls.reff = txt_ref.Text;
            if (IsNumeric(txt_rev.Text) == false) txt_rev.Text = "0";
            _objcls.ir_rev = Convert.ToInt32(txt_rev.Text);
            _objcls.dt_rep = txt_dtrecv.Text;
            _objcls.dt_tc = txt_dtprop.Text;
            _objcls.am_pm = drampm.SelectedItem.Text;
            _objcls.type = txt_type.Text;
            _objcls.sch_name = drservice.SelectedItem.Text;
            _objcls.sys_name = txt_sys.Text;
            _objcls.desc = txt_details.Text;
            _objcls.build_name = txt_bldg.Text;
            if (IsNumeric(txt_lvl.Text) == false) txt_lvl.Text = "0";
            _objcls.flevel = Convert.ToInt32(txt_lvl.Text);
            _objcls.loca = drloc.SelectedItem.Text;
            _objcls.ir_chkd = txt_irchk.Text;
            _objcls.advise = txt_adv.Text;
            _objcls.dtpstart = Convert.ToDateTime(txt_dtpstart.Text);
            _objcls.dtastart = Convert.ToDateTime(txt_dtastart.Text);
            _objcls.dtcomp = txt_dtcomp.Text;
            if (IsNumeric(txt_vist.Text) == false) txt_vist.Text = "0";
            _objcls.visit = Convert.ToInt32(txt_vist.Text);
            _objcls.witness = txt_witness.Text;
            _objcls.ir_status = txt_status.Text;
            _objcls.doc_status = txt_docstatus.Text;
            _objcls.svr_no = txt_svrno.Text;
            _objcls.comm = txt_notes.Text;
            _objcls.mode = 2;
            _objbll.Dml_CXIR_Schedule(_objcls, _objdb);

        }
        private void Delete_CXIR()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.c_s_id = Convert.ToInt32(lblid.Text);
            _objcls.reff = "";
            _objcls.ir_rev = 0;
            _objcls.dt_rep = "";
            _objcls.dt_tc = "";
            _objcls.am_pm = drampm.SelectedItem.Text;
            _objcls.type = "";
            _objcls.sch_name = drservice.SelectedItem.Text;
            _objcls.sys_name = "";
            _objcls.desc = "";
            _objcls.build_name = "";
            _objcls.flevel = 0;
            _objcls.loca = drloc.SelectedItem.Text;
            _objcls.ir_chkd = "";
            _objcls.advise = "";
            _objcls.dtpstart = DateTime.Now;
            _objcls.dtastart = DateTime.Now;
            _objcls.dtcomp = "";
            _objcls.visit = 0;
            _objcls.witness = "";
            _objcls.ir_status = "";
            _objcls.doc_status = "";
            _objcls.svr_no = "";
            _objcls.comm = "";
            _objcls.mode = 3;
            _objbll.Dml_CXIR_Schedule(_objcls, _objdb);
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            //Reset();
            Response.Redirect("CXIR_Schedule.aspx?id=" + lblprj.Text);
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            Delete_CXIR();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('CX IR Record is Deleted');", true);
            Response.Redirect("CXIR_Schedule.aspx?id=" + lblprj.Text);
        }
    }
}
