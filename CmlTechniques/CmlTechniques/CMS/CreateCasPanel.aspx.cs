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
    public partial class CreateCasPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                lblprj.Text = _prm;
                Load_services();
            }
        }
        private void Load_services()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            dr_service.DataSource = _objbll.Load_Cas_service(_objdb);
            dr_service.DataTextField = "PRJ_SER_NAME";
            dr_service.DataValueField = "SYS_SER_ID";
            dr_service.DataBind();
            dr_service.Items.Insert(0, "-- Select --");
            //Load_SubFolder();
        }
        private void Load_SubFolder()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsFolderTree _objcls = new _clsFolderTree();
            _objcls.Parent_folder = Convert.ToInt32(dr_service.SelectedItem.Value);
            dr_cas.DataSource = _objbll.Load_SubFolder(_objcls, _objdb);
            dr_cas.DataTextField = "PRJ_CAS_NAME";
            dr_cas.DataValueField = "PRJ_CAS_ID";
            dr_cas.DataBind();
            dr_cas.Items.Insert(0, "-- Select --");
        }
        private void Load_Panels()
        {
            dr_parent.Items.Clear();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();
            _objcls.sch = Convert.ToInt32(dr_cas.SelectedItem.Value);
            dr_parent.DataSource = _objbll.load_cas_panel(_objcls, _objdb);
            dr_parent.DataTextField = "Panel_ref";
            dr_parent.DataValueField = "Panel_id";
            dr_parent.DataBind();
            dr_parent.Items.Insert(0, "-- Select --");
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            Insert_CasPanel();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Panel Created');", true);
        }
        private void Reset()
        {
            txt_name.Text = String.Empty;
            Load_Panels();
        }
        private void Insert_CasPanel()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();
            _objcls.panel_id = 0;
            _objcls.panel_ref = txt_name.Text;
            _objcls.sys = 0;//not required this field
            _objcls.sch = Convert.ToInt32(dr_cas.SelectedItem.Value);
            if (chkparent.Checked == true)
                _objcls.parent = 0;
            else
                _objcls.parent = Convert.ToInt32(dr_parent.SelectedItem.Value);
            _objcls.action = 1;
            _objbll.dml_cas_panel(_objcls, _objdb);

        }
        protected void dr_service_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dr_service.SelectedItem.Text == "-- Select --") return;
            Load_SubFolder();
        }
        private void load_cas_sys()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DB_" + lblprj.Text;
            //_clscassheet _objcls = new _clscassheet();
            //_objcls.sch = Convert.ToInt32(dr_cas.SelectedItem.Value);
            //dr_pkg.DataSource = _objbll.Load_cas_sys(_objcls, _objdb);
            //dr_pkg.DataTextField = "sys_name";
            //dr_pkg.DataValueField = "sys_id";
            //dr_pkg.DataBind();
            //dr_pkg.Items.Insert(0, "-- Select --");
        }

        protected void dr_cas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dr_cas.SelectedItem.Text == "-- Select --") return;
            Load_Panels();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {

        }
    }
}
