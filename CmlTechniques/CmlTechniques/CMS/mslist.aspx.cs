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
    public partial class mslist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
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
                        Session["fpath"] = _path.Replace(">", "#");
                        _Create_Cookies();
                    }
                    else
                    {
                        phead.Text = "Method Statement Schedule History";
                    }
                    Load_doc();
                    Load_doc_pre();
                }
            }
        }
        void _Create_Cookies()
        {
            if (Request.Browser.Cookies)
            {
                HttpCookie _CookiefPath = new HttpCookie("fpath");
                _CookiefPath.Value = (string)Session["fpath"];
                _CookiefPath.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_CookiefPath);
            }
            else
                return;
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
        }
        protected void Load_doc_pre()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.reff_no = (string)Session["reff_no"];
            _objcls.project_code = (string)Session["project"];
            _objcls.status = false;
            mygrid1.DataSource = _objbll.Load_CMS_Document(_objcls, _objdb);
            mygrid1.DataBind();
        }

        protected void mygrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mygrid.Rows[_rowidx];
            TableCell _item = _srow.Cells[1];
            TableCell _id = _srow.Cells[0];
            Session["file"] = _item.Text;
            string _file = "https://cmltechniques.com/CMS_DOCS/" + (string)Session["project"] + "/" + (string)Session["file"];
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('"+ _file +"','1');", true);
        }

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
        }

        protected void mygrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header)
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
        }
    }
}
