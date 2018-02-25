using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Web.UI.HtmlControls;

namespace CmlTechniques
{
    public partial class cmsminutes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                _prm = _prm.Replace("<>", "&");
                Session["Fold_cms"] = _prm.Substring(0, _prm.IndexOf("_M"));
                Session["M_id_cms"] = _prm.Substring(_prm.IndexOf("_M") + 2, _prm.IndexOf("_N") - (_prm.IndexOf("_M") + 2));
                Session["M_na_cms"] = _prm.Substring(_prm.IndexOf("_N") + 2, _prm.IndexOf("_P") - (_prm.IndexOf("_N") + 2));
                lblprj.Text= _prm.Substring(_prm.IndexOf("_P") + 2);
                string _path = (string)Session["M_na_cms"];
                Session["mod"] = _path.Substring(0, _path.IndexOf(" >"));
                Session["reff_no"] = (string)Session["Fold_cms"] + "/" + (string)Session["M_id_cms"] + "/" + (string)Session["mod"];
                //phead.Text = (string)Session["M_na_cms"].ToString().Replace("^", "&");
                phead.Text = _prm.Substring(_prm.IndexOf("_N") + 2, _prm.IndexOf("_P") - (_prm.IndexOf("_N") + 2));
                Load_Documents();
                if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                {
                    Get_ProjectName();
                }
                else
                {
                    dvfixedhead.Visible = false;
                    dvfixedcontent.Style.Add("Top", "0px");
                }
                Permission();
            }
        }

        private void Permission()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();
            _objdb.DBName = "dbCML";
            _objcls.uid = (string)Session["uid"];
            _objcls.project_code = lblprj.Text;
            string _access = _objbll.Get_User_cmsAccess(_objcls, _objdb);
            if (_access != "Admin")
            {
                btnuploadnew.Enabled = false;
            }
        }
        private void Get_ProjectName()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            prj.Text = _objbll.Get_ProjectName(_objcls, _objdb);
        }
        private void Load_Documents()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.reff_no = (string)Session["reff_no"];
            _objcls.project_code = lblprj.Text;
            _objcls.status = true;
            rpt_latest.DataSource = _objbll.Load_CMS_Document(_objcls,_objdb);
            rpt_latest.DataBind();
            _objcls.status = false;
            rpt_history.DataSource = _objbll.Load_CMS_Document(_objcls, _objdb);
            rpt_history.DataBind();
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

       
        protected void Delete_doc(string Project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + Project;
            //_objdb.DBName = "db_123";
            _clsdocument _objcls = new _clsdocument();
            //_clscmsdocument _objcls = new _clscmsdocument();
            //_objcls.doc_id = 111;
            _objcls.doc_id = Convert.ToInt32(lblitmid.Text);
            _objbll.Delete_CMS_Doc(_objcls, _objdb);
            Load_Documents();
            lblitmid.Text = "0";
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

       
        protected void Delete_Click(object sender, EventArgs e)
        {
            Delete_doc(lblprj.Text);

        }
        protected void rpt_history_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "delete1")
            {
                Label _id = (Label)e.Item.FindControl("lbldocid");
                lblitmid.Text = _id.Text;
                ModalPopupExtender1.Show();
            }
        }
        protected void rpt_latest_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "delete1")
            {
                Label _id = (Label)e.Item.FindControl("lbldocid");
                lblitmid.Text = _id.Text;
                ModalPopupExtender1.Show();
            }
        }

        protected void rpt_latest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
            {
                if (e.Item.ItemType == ListItemType.Header || e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HtmlTableCell _td = (HtmlTableCell)e.Item.FindControl("tdHistory");
                    _td.Visible = false;
                }
            }
        }
        protected void rpt_history_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
            {
                if (e.Item.ItemType == ListItemType.Header || e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HtmlTableCell _td = (HtmlTableCell)e.Item.FindControl("tdHistory");
                    _td.Visible = false;
                }
            }
        }

        protected void btnuploadnew_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + Request.QueryString.ToString() + "'," + (lblprj.Text == "HMIM" || lblprj.Text == "HMHS" ? 38 : 39) + ");", true);
        }
      }
}
