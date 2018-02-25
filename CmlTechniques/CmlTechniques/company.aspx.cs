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
    public partial class company : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                load_project();
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            if (txtname.Text.Length <= 0) return;
            BLL_Dml _objbll = new BLL_Dml();
            _clsproject _objcls = new _clsproject();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _objcls.company = txtname.Text;
            _objcls.prjcode = drproject.SelectedItem.Value;
            _objbll.Create_Company(_objcls, _objdb);
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Company Created');", true);
            txtname.Text = String.Empty;
            
        }
        void load_project()
        {
            BLL_Dml _objbal = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            drproject.DataSource = _objbal.load_project(_objdb);
            drproject.DataTextField = "prj_name";
            drproject.DataValueField = "prj_code";
            drproject.DataBind();
        }
    }
}
