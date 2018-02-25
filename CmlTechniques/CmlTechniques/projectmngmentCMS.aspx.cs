using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;

namespace CmlTechniques
{
    public partial class projectmngmentCMS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                load_project();
        }

        protected void cmdgo_Click(object sender, EventArgs e)
        {
            if (draction.SelectedItem.Text == "Uploads")
            {
                Session["project"] = drproject.SelectedItem.Value;
                Session["module"] = drmodules.SelectedItem.Value;
                //Response.Redirect("cmsuploads.aspx");
                myframe.Attributes.Add("src", "cmsuploads.aspx");
            }
        }
        void load_project()
        {
            BLL_Dml _objbal = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            drproject.DataSource = _objbal.load_project(_objdb);
            drproject.DataTextField = "prj_name";
            drproject.DataValueField = "prj_code";
            drproject.DataBind();
            drproject.Items.Insert(0, "--Select Project--");

        }
    }
}
