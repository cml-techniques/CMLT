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
    public partial class MonthlyReports : System.Web.UI.Page
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
                Load_Documents();
            }
        }
        private void Load_Documents()
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

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
            {
                e.Row.Cells[4].Visible = false;
            }
        }

        protected void mygrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ e.CommandName.ToString() +"');", true);
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mygrid.Rows[_rowidx];
            TableCell _item = _srow.Cells[1];
            TableCell _id = _srow.Cells[0];
            Session["docid"] = _id.Text;
            string _file = _item.Text;
            string fpath = "https://cmltechniques.com/CMS_DOCS/" + (string)Session["project"] + "/" + _file;
            if (e.CommandName == "view")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + fpath + "','10');", true);
                //myframe.Attributes.Add("src", fpath);
                //else
                //    _download(fpath);
            }
            else if (e.CommandName == "delete1")
            {
                ModalPopupExtender1.Enabled = true;
                ModalPopupExtender1.Show();

            }

        }
        void _download(string FileName)
        {
            string path = Server.MapPath(FileName);
            System.IO.FileInfo _finfo = new System.IO.FileInfo(path);
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + _finfo.Name);
            Response.AddHeader("Content-Length", _finfo.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(_finfo.FullName);
            Response.End();
        }

        

        protected void myhistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
            {
                e.Row.Cells[4].Visible = false;
            }
        }
        protected void Delete_doc(string Project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + Project;
            //_objdb.DBName = "db_123";
            _clsdocument _objcls = new _clsdocument();
            //_clscmsdocument _objcls = new _clscmsdocument();
            //_objcls.doc_id = 111;
            _objcls.doc_id = Convert.ToInt32((string)Session["docid"]);
            _objbll.Delete_CMS_Doc(_objcls, _objdb);
            Load_Documents();

        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            Delete_doc((string)Session["project"]);

        }
    }
}
