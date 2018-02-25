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
    public partial class MechReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                Session["Fold_cms"] = _prm.Substring(0, _prm.IndexOf("_M"));
                Session["M_id_cms"] = _prm.Substring(_prm.IndexOf("_M") + 2, _prm.IndexOf("_N") - (_prm.IndexOf("_M") + 2));
                Session["M_na_cms"] = _prm.Substring(_prm.IndexOf("_N") + 2, _prm.IndexOf("_P") - (_prm.IndexOf("_N") + 2));
                Session["project"] = _prm.Substring(_prm.IndexOf("_P") + 2);
                Session["reff_no"] = (string)Session["Fold_cms"] + "/" + (string)Session["M_id_cms"] + "/" + (string)Session["M_na_cms"];
                phead.Text = (string)Session["M_na_cms"].ToString().Replace("^", "&");
                Load_doc((string)Session["project"]);
                lbltitle.Text = "Latest Version of the " + phead.Text;
            }
        }
        protected void Load_doc(string Project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + Project;
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.reff_no = (string)Session["reff_no"];
            _objcls.project_code = Project;
            _objcls.status = true;
            mygrid.DataSource = _objbll.Load_CMS_Document(_objcls, _objdb);
            mygrid.DataBind();
            _objcls.status = false;
            myhistory.DataSource = _objbll.Load_CMS_Document(_objcls, _objdb);
            myhistory.DataBind();
        }
        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
        }

        protected void mygrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mygrid.Rows[_rowidx];
            TableCell _item = _srow.Cells[1];
            TableCell _id = _srow.Cells[0];
            string _file = _item.Text;
            Session["file"] = _item.Text;
            Session["docid"] = _id.Text;
            Session["head"] = phead.Text + " :- " + _item.Text;
            if (e.CommandName == "view")
            {
                string fpath = "https://cmltechniques.com/CMS_DOCS/" + (string)Session["project"] + "/" + _file;
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + fpath + "','10');", true);
            }
        }

        protected void myhistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = myhistory.Rows[_rowidx];
            TableCell _item = _srow.Cells[1];
            TableCell _id = _srow.Cells[0];
            string _file = _item.Text;
            Session["docid"] = _id.Text;
            string fpath = "https://cmltechniques.com/CMS_DOCS/" + (string)Session["project"] + "/" + _file;
            if (e.CommandName == "view")
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + fpath + "','10');", true);
 
        }

        protected void myhistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
        }

    }
}
