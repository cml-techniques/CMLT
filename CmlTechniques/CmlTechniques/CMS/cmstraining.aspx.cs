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
    public partial class cmstraining : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _prm = Request.QueryString[0].ToString();
            if (_prm != "0")
            {
                Session["Fold_cms"] = _prm.Substring(0, _prm.IndexOf("_M"));
                Session["M_id_cms"] = _prm.Substring(_prm.IndexOf("_M") + 2, _prm.IndexOf("_N") - (_prm.IndexOf("_M") + 2));
                Session["M_na_cms"] = _prm.Substring(_prm.IndexOf("_N") + 2);
                //Session["reff_no"] = (string)Session["Fold_cms"] + "/" + (string)Session["M_id_cms"];
                //head.Text = (string)Session["M_na_cms"].ToString().Replace("^", "&");
                string _path = (string)Session["M_na_cms"];
                Session["mod"] = _path.Substring(0, _path.IndexOf(" >"));
                Session["reff_no"] = (string)Session["Fold_cms"] + "/" + (string)Session["M_id_cms"] + "/" + (string)Session["mod"];
                phead.Text = (string)Session["M_na_cms"].ToString().Replace("^", "&");
                Load_doc();
            }
        }
        protected void Load_doc()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.reff_no = (string)Session["reff_no"];
            _objcls.project_code = (string)Session["project"];
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
            //string _path = "http://www.cmldubai.com/CMS_DOCS/" + (string)Session["project"] + "/" + (string)Session["file"];
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _path + "','10');", true);
            if (e.CommandName == "view")
            {
                    Session["viewmode"] = "TR";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('','5');", true);
            }
            else if (e.CommandName == "view1")
            {
                string _prm = Session["docid"] + "_MTraining_T1";
                string _url = "ViewComments.aspx?id=" + _prm;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _url + "' ,'','left=210,top=100,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
            }
            else if (e.CommandName == "view2")
            {
                string _prm = Session["docid"] + "_MTraining_T2";
                string _url = "ViewComments.aspx?id=" + _prm;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _url + "' ,'','left=210,top=100,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
            }
        }

        protected void myhistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = myhistory.Rows[_rowidx];
            TableCell _item = _srow.Cells[1];
            string _file = _item.Text;
            string fpath = "http://www.cmldubai.com/CMS_DOCS/" + (string)Session["project"] + "/" + _file;
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
