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
    public partial class ConfigMinutes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                lblprj.Text = _prm;
                Load_ProjectUsers(_prm);
            }
        }
        private void Load_ProjectUsers(string _project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = _project;
            mygrid.DataSource = _objbll.load_User(_objcls, _objdb);
            mygrid.DataBind();
        }

        protected void mygrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mygrid.Rows[_rowidx];
            TableCell _id = _srow.Cells[0];
            Session["user"] = _id.Text;
            btnDummy_ModalPopupExtender1.Show();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            Set_MSPermission();
        }
        private void Set_MSPermission()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = (string)Session["user"];
            _objcls.project_code = lblprj.Text;
            _objcls.access = draccess.SelectedItem.Text;
            _objcls.mode = 2;
            _objbll.Set_CMSAccess(_objcls, _objdb);
            btnDummy_ModalPopupExtender1.Hide();
            Load_ProjectUsers(lblprj.Text);

        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender1.Hide();
        }
    }
}
