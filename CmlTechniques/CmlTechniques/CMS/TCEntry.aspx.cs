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
using System.IO;

namespace CmlTechniques.CMS
{
    public partial class TCEntry : System.Web.UI.Page
    {
        static DataTable _dtmaster;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                string _query = Request.QueryString[0].ToString();
                lblsch.Text = _query.Substring(0, _query.IndexOf("_P"));
                lblprj.Text = _query.Substring(_query.IndexOf("_P") + 2); ;

                Session["sch"] = lblsch.Text;
                Session["project"] = lblprj.Text;

                if (lblprj.Text == "HMIM")
                {
                    string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
                }
                else if (lblprj.Text == "HMHS")
                {
                    string script = "function f(){$find(\"" + RadWindow2.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
                }
                else
                {
                       Load_Packages(lblprj.Text);
                        Load_Service(lblprj.Text);

                        rd_facility.Enabled = false;
                        rd_service.Enabled = false;
                        rd_Casheet.Enabled = false;


                    string script = "function f(){$find(\"" + RadWindow3.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
                }


            }

        }
        private void Load_Service(string _prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + _prj;
            DataTable _dtser = _objbll.Load_Prj_Service(_objdb);

            rd_service.DataSource = _dtser;
            rd_service.DataTextField = "PRJ_SER_NAME";
            rd_service.DataValueField = "PRJ_SER_ID";
            rd_service.DataBind();

        }


        protected void btnenter_Click(object sender, EventArgs e)
        {
            if (rdbuilding.SelectedValue == "") return;
            string path = Request.QueryString.ToString() + "_D" + rdbuilding.SelectedValue.ToString();
            Session["TCHeading"] = "BUILDING : " + rdbuilding.SelectedItem.Text;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "loadtc('" + path + "');", true);
        }
        protected void btnenter2_Click(object sender, EventArgs e)
        {
            if (rdbuilding2.SelectedValue == "") return;
            string path = Request.QueryString.ToString() + "_D" + rdbuilding2.SelectedValue.ToString();

            Session["TCHeading"] = "BUILDING : " + rdbuilding2.SelectedItem.Text;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "loadtc('" + path + "');", true);
        }
        protected void rd_package_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            Load_Facility(Convert.ToInt32(rd_package.SelectedValue));
            rd_service.Enabled = true;

        }
        protected void rd_facility_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            //btnenter.Visible = true;
        }
        private void Load_Facility(int _pkg_id)
        {
            var _result = _dtmaster.Select("PKG_ID =" + _pkg_id);
            DataTable _dtresult = _result.Any() ? _result.CopyToDataTable() : _dtmaster.Clone();
            rd_facility.Enabled = true;
            rd_facility.Items.Clear();
            rd_facility.DataSource = _dtresult;
            rd_facility.DataTextField = "FCLTY";
            rd_facility.DataValueField = "FCLTY_ID";
            rd_facility.DataBind();
        }
        protected void btnenter3_Click(object sender, EventArgs e)
        {
            if (rdbuilding2.SelectedValue == "") return;
            if (rd_package.SelectedValue == "") return;
            if (rd_Casheet.SelectedValue == "") return;

            Session["TCHeading"] = "FACILITY : " + rd_package.SelectedItem.Text + " - " + rdbuilding2.SelectedItem.Text;
            //Session["TCHeading"] = "BUILDING :" + rdbuilding1.SelectedItem.Text;
           
            string path = rd_Casheet.SelectedValue.ToString() + "_P" + lblprj.Text + "_D" + rdbuilding.SelectedValue.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "loadtc('" + path + "');", true);


        }
        private void Permission()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();
            _objdb.DBName = "dbCML";
            _objcls.uid = lbluser.Text;
            _objcls.project_code = lblprj.Text;
            //string _access = _objbll.Get_User_cmsAccess(_objcls, _objdb);
            lblpermission.Text = _objbll.Get_User_cmsAccess(_objcls, _objdb);

            if (lblpermission.Text != "Admin")
            {

            }
            else
            {

            }
        }
        protected void rd_service_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_Casheet(Convert.ToInt32(rd_service.SelectedItem.Value.ToString()));
            rd_Casheet.Enabled = true;
        }
        protected void rd_Casheet_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void Load_Packages(string _prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + _prj;
            DataTable _dtpkg = _objbll.Load_fclty_Package(_objdb);
            rd_package.DataSource = _dtpkg;
            rd_package.DataTextField = "PKG_NAME";
            rd_package.DataValueField = "PKG_ID";
            rd_package.DataBind();
            _dtmaster = _objbll.Load_Facility(_objdb);
        }
        private void load_Casheet(int _pkg_id)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            DataTable _dtcasheet = _objbll.Load_Prj_Cassheet(_objdb);


            var _result = _dtcasheet.Select("SYS_SER_ID =" + _pkg_id);
            DataTable _dtresult = _result.Any() ? _result.CopyToDataTable() : _dtcasheet.Clone();

            rd_Casheet.DataSource = _dtresult;
            rd_Casheet.DataTextField = "PRJ_CAS_NAME";
            rd_Casheet.DataValueField = "PRJ_CAS_ID";
            rd_Casheet.DataBind();
        }

    }
}