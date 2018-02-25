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
    public partial class MsEntryHMHS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                lblprj.Text = Request.QueryString["prj"].ToString();
                //lbluser.Text = Request.QueryString["auh"].ToString();
                lbluser.Text = (string)Session["uid"];

                //prj.Text = Get_ProjectName();


                string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);

                Load_Service(lblprj.Text);

                rd_Service.Enabled = false; ;
                rd_ms.Enabled = false;

            }

        }
        private string Get_ProjectName()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            return _objbll.Get_ProjectName(_objcls, _objdb);
        }
        protected void rd_Building_SelectedIndexChanged(object sender, EventArgs e)
        {
            rd_Service.Enabled = true;

            if (rd_Service.SelectedIndex >= 0) load_MsFolder(lblprj.Text);

        }
        protected void rd_Service_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_MsFolder(lblprj.Text);
            rd_ms.Enabled = true;
        }
        protected void btnenter_Click(object sender, EventArgs e)
        {
            if (rd_Building.SelectedValue == "") return;
            if (rd_Service.SelectedValue == "") return;
            if (rd_ms.SelectedValue == "") return;

            string path = "1_M" + rd_ms.SelectedItem.Value.ToString() + "_NMethod Statement > " + rd_Service.SelectedItem.Text + " > " + rd_ms.SelectedItem.Text + " > MS_P+ " + lblprj.Text + "_V4/1/" + rd_Service.SelectedItem.Value.ToString() + "&Div=" + rd_Building.SelectedItem.Value.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "loadms('" + path + "');", true);
        }
        private void Load_Service(string _prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + _prj;
            DataTable _dtserMs = _objbll.Load_Prj_Service_MS(_objdb);

            rd_Service.DataSource = _dtserMs;
            rd_Service.DataTextField = "PRJ_SER_NAME";
            rd_Service.DataValueField = "PRJ_SER_ID";
            rd_Service.DataBind();

        }
        private void load_MsFolder(string _prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + _prj;

            DataTable _dtsys = _objbll.Load_Prj_MsSystem(_objdb);

            string query = "";


            if (rd_Building.SelectedValue == "1")
                query = "HARAM_PIAZZA=1";
            else if (rd_Building.SelectedValue == "2")
                query = "SERVICE_BLDNG=1";
            else
                query = "CUC_T4=1";

            var _result = _dtsys.Select("SYS_SER_ID =" + rd_Service.SelectedItem.Value.ToString() + " AND " + query);
            DataTable _dtresult = _result.Any() ? _result.CopyToDataTable() : _dtsys.Clone();

            rd_ms.DataSource = _dtresult;
            rd_ms.DataTextField = "PRJ_MSSYS_NAME";
            rd_ms.DataValueField = "PRJ_MSSYS_ID";
            rd_ms.DataBind();
        }
    }
}
