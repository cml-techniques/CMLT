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
    public partial class Comm_Checklist : System.Web.UI.Page
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
                Get_PlantRef();
            }
        }
        private void Get_ProjectName()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
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
        private void Get_PlantRef()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clstestpack _objcls = new _clstestpack();
            _objcls.cas_id = Convert.ToInt32(lbl_casid.Text);
            txt_plantref.Text = _objbll.Get_PlantRef(_objcls, _objdb);
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            Insert_precom_checklist();
            Insert_precom_checklist_list();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Pre Commissioning Checklist Updated');", true);
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
        protected void btnpreview_Click(object sender, EventArgs e)
        {
            string _prm = "Preview.aspx?id=" + lbl_casid.Text + "_R2";
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _prm + "','','left=210,top=100,width=800,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=0');", true);
        }
        private void Insert_precom_checklist()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clstestpack _objcls = new _clstestpack();
            _objcls.cas_id = Convert.ToInt32(lbl_casid.Text);
            _objcls.sheet_ref = txt_sheet_ref.Text;
            _objcls.asset_code = txt_asset_code.Text;
            _objcls.system = txt_system.Text;
            _objcls.location = txt_location.Text;
            _objcls.plant_ref = txt_plantref.Text;
            if (IsNumeric(txt_rev.Text) == true)
                _objcls.rev = Convert.ToInt32(txt_rev.Text);
            else
                _objcls.rev = 1;
            _objcls.tested_by = txt_tested_by.Text;
            _objcls.witnessed_by = txt_witnessed.Text;
            _objcls.tested_date = txt_dttest.Text;
            _objcls.wit_date = txt_dtwitness.Text;
            _objcls.action = 1;
            _objbll.dml_precom_checklist(_objcls, _objdb);
           
        }
        private void Insert_precom_checklist_list()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clstestpack _objcls = new _clstestpack();
            _objcls.list_id = Convert.ToInt32(lbl_casid.Text);

            _objcls.chk_list = lbl_test1.Text;
            if (rd_status1.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status1.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status1.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt1.Text;
            _objcls.signature = txt_sig1.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test2.Text;
            if (rd_status2.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status2.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status2.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt2.Text;
            _objcls.signature = txt_sig2.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test3.Text;
            if (rd_status3.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status3.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status3.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt3.Text;
            _objcls.signature = txt_sig3.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test4.Text;
            if (rd_status4.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status4.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status4.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt4.Text;
            _objcls.signature = txt_sig4.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test5.Text;
            if (rd_status5.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status5.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status5.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt5.Text;
            _objcls.signature = txt_sig5.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test6.Text;
            if (rd_status6.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status6.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status6.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt6.Text;
            _objcls.signature = txt_sig6.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test7.Text;
            if (rd_status7.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status7.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status7.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt7.Text;
            _objcls.signature = txt_sig7.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test8.Text;
            if (rd_status8.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status8.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status8.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt8.Text;
            _objcls.signature = txt_sig8.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test9.Text;
            if (rd_status9.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status9.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status9.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt9.Text;
            _objcls.signature = txt_sig9.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test10.Text;
            if (rd_status10.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status10.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status10.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt10.Text;
            _objcls.signature = txt_sig10.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test11.Text;
            if (rd_status11.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status11.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status11.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt11.Text;
            _objcls.signature = txt_sig11.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test12.Text;
            if (rd_status12.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status12.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status12.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt12.Text;
            _objcls.signature = txt_sig12.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test13.Text;
            if (rd_status13.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status13.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status13.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt13.Text;
            _objcls.signature = txt_sig13.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test14.Text;
            if (rd_status14.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status14.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status14.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt14.Text;
            _objcls.signature = txt_sig14.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test15.Text;
            if (rd_status15.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status15.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status15.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt15.Text;
            _objcls.signature = txt_sig15.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test16.Text;
            if (rd_status16.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status16.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status16.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt16.Text;
            _objcls.signature = txt_sig16.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test17.Text;
            if (rd_status17.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status17.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status17.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt17.Text;
            _objcls.signature = txt_sig17.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test18.Text;
            if (rd_status18.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status18.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status18.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt18.Text;
            _objcls.signature = txt_sig18.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test19.Text;
            if (rd_status19.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status19.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status19.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt19.Text;
            _objcls.signature = txt_sig19.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test20.Text;
            if (rd_status20.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status20.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status20.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt20.Text;
            _objcls.signature = txt_sig20.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test21.Text;
            if (rd_status21.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status21.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status21.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt21.Text;
            _objcls.signature = txt_sig21.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);

            _objcls.chk_list = lbl_test22.Text;
            if (rd_status22.SelectedIndex == 0)
                _objcls.status = "satisfactory";
            else if (rd_status22.SelectedIndex == 1)
                _objcls.status = "unsatisfactory";
            else if (rd_status22.SelectedIndex == 2)
                _objcls.status = "not applicable";
            else
                _objcls.status = "";
            _objcls.tested_date = txt_statusdt22.Text;
            _objcls.signature = txt_sig22.Text;
            _objbll.insert_precom_checklist_list(_objcls, _objdb);
        }
    }
}
