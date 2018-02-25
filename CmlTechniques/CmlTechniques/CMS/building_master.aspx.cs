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
    public partial class building_master : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Buildings();
            }
        }
        private void Load_Buildings()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _objcls.project_code = (string)Session["project"];
            my_view.DataSource = _objbll.Load_Buildings(_objcls, _objdb);
            my_view.DataBind();
        }

        protected void my_view_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                TextBox _txtbuilding = (TextBox)e.Item.FindControl("txtbuilding");
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _clscassheet _objcls = new _clscassheet();
                _objdb.DBName = "DB_" + (string)Session["project"];
                _objcls.build_id = 0;
                _objcls.build_name = _txtbuilding.Text;
                _objcls.mode = 0;
                _objcls.prj_code = (string)Session["project"];
                _objbll.Create_Building(_objcls, _objdb);
            }
            else if (e.CommandName == "Update")
            {
                TextBox _txtbuilding = (TextBox)e.Item.FindControl("txtbuilding");
                Label _id = (Label)e.Item.FindControl("lbid");
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _clscassheet _objcls = new _clscassheet();
                _objdb.DBName = "DB_" + (string)Session["project"];
                _objcls.build_id = 0;
                _objcls.build_name = _txtbuilding.Text;
                _objcls.mode = 0;
                _objcls.prj_code = (string)Session["project"];
                _objbll.Create_Building(_objcls, _objdb);
            }
        }

        protected void my_view_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            Load_Buildings();
        }

        protected void my_view_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            my_view.EditIndex = -1; 
            Load_Buildings();
        }

        protected void my_view_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            my_view.EditIndex = e.NewEditIndex;
            Load_Buildings();
        }

        protected void my_view_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

        }
    }
}
