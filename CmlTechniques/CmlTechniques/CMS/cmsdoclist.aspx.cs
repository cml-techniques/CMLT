using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Web.UI.HtmlControls;

namespace CmlTechniques.CMS
{
    public partial class cmsdoclist : System.Web.UI.Page
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

                if (Session["M_na_cms"].ToString().IndexOf(" >") > 0)
                {
                    Session["mod"] = Session["M_na_cms"].ToString().Substring(0, Session["M_na_cms"].ToString().IndexOf(" >"));
                    Session["reff_no"] = (string)Session["Fold_cms"] + "/" + (string)Session["M_id_cms"] + "/" + (string)Session["mod"];
                }
                else
                {
                    Session["reff_no"] = (string)Session["Fold_cms"] + "/" + (string)Session["M_id_cms"] + "/" + (string)Session["M_na_cms"];
                }
               
                lblprj.Text = (string)Session["project"];
                phead.Text = (string)Session["M_na_cms"].ToString().Replace("^", "&");
                Load_doc(lblprj.Text);
                lbltitle.Text = "Latest Version of the " + phead.Text;
                _ReadCookies();

                //if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")               
                //{
                //    tdDelete.Visible = false;
                //    tdHistory.Visible = false;

                //}
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
        void _ReadCookies()
        {
            if (Request.Browser.Cookies)
            {
                if (Request.Cookies["uid"] != null)
                {
                    Session["uid"] = Server.HtmlEncode(Request.Cookies["uid"].Value);
                }
                if (Request.Cookies["project"] != null)
                {
                    Session["project"] = Server.HtmlEncode(Request.Cookies["project"].Value);
                }
                if (Request.Cookies["projectname"] != null)
                {
                    Session["projectname"] = Server.HtmlEncode(Request.Cookies["projectname"].Value);
                }
                if (Request.Cookies["issued"] != null)
                {
                    Session["issued"] = Server.HtmlEncode(Request.Cookies["issued"].Value);
                }
                if (Request.Cookies["group"] != null)
                {
                    Session["group"] = Server.HtmlEncode(Request.Cookies["group"].Value);
                }
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
            //mygrid.DataSource = _objbll.Load_CMS_Document(_objcls, _objdb);
            //mygrid.DataBind();
            rpt_latest.DataSource = _objbll.Load_CMS_Document(_objcls, _objdb);
            rpt_latest.DataBind();
            _objcls.status = false;
            //myhistory.DataSource = _objbll.Load_CMS_Document(_objcls, _objdb);
            //myhistory.DataBind();
            rpt_history.DataSource = _objbll.Load_CMS_Document(_objcls, _objdb);
            rpt_history.DataBind();
        }

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[9].Visible = false;
            if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
            {
                //tdDelete.Visible = false;
                e.Row.Cells[8].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].Text = "0" + e.Row.Cells[4].Text;
            }

        }

        protected void mygrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int _rowidx = Convert.ToInt32(e.CommandArgument);
            //GridViewRow _srow = mygrid.Rows[_rowidx];
            //TableCell _item = _srow.Cells[1];
            //TableCell _id = _srow.Cells[0];
            //TableCell commTotal = _srow.Cells[9];
            //string _file = _item.Text;
            //Session["file"] = _item.Text;
            //Session["docid"] = _id.Text;
            //Session["head"] = phead.Text + " :- " + _item.Text;
            //Session["CommTot"] = commTotal.Text;
            //if (e.CommandName == "view")
            //{
            //    string _prm = "";
            //    if (phead.Text == "Commissioning Plan")
            //    {
            //        _prm = "prj=" + lblprj.Text + "&mode=CP&doc=" + _id.Text;
            //        Session["viewmode"] = "CP";
            //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _prm + "','5');", true);
            //    }
            //    else if (phead.Text == "Commissioning Report")
            //    {
            //        _prm = "prj=" + lblprj.Text + "&mode=CR&doc=" + _id.Text;
            //        Session["viewmode"] = "CR";
            //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _prm + "','5');", true);
            //    }
            //}
            //else if (e.CommandName == "view1")
            //{
            //    //string _prm = Session["docid"] + "_MCommissioning Plan_T1";
            //    string _prm = Session["docid"] + "_M" + phead.Text + "_T1";
            //    string _url = "ViewComments.aspx?id=" + _prm;
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _url + "' ,'','left=50,top=100,width=1200,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
            //}
            //else if (e.CommandName == "view2")
            //{
            //    //string _prm = Session["docid"] + "_MCommissioning Plan_T2";
            //    string _prm = Session["docid"] + "_M" + phead.Text + "_T2";
            //    string _url = "ViewComments.aspx?id=" + _prm;
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _url + "' ,'','left=50,top=100,width=1200,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
            //}
            //else if (e.CommandName == "delete1")
            //{
            //    Confirmdelete();
            //}

        }
        void Confirmdelete()
        {
            if (Convert.ToInt16(Session["CommTot"].ToString()) > 0)
            {
                lblqns.Text = "Comments exists , Do you want to delete this record?";
            }
            else lblqns.Text = "Do you want to delete this record?";
            ModalPopupExtender1.Show();
        }

        protected void myhistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int _rowidx = Convert.ToInt32(e.CommandArgument);
            //GridViewRow _srow = myhistory.Rows[_rowidx];
            //TableCell _item = _srow.Cells[1];
            //TableCell _id = _srow.Cells[0];
            //TableCell commTotal = _srow.Cells[9];
            //string _file = _item.Text;
            //Session["docid"] = _id.Text;
            //Session["CommTot"] = commTotal.Text;

            //string fpath = "http://www.cmltechniques.com/CMS_DOCS/" + (string)Session["project"] + "/" + _file;
            //if (e.CommandName == "view")
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + fpath + "','10');", true);
            //else if (e.CommandName == "view1")
            //{
            //    string _prm = Session["docid"] + "_MCommissioning Plan_T1";
            //    string _url = "ViewComments.aspx?id=" + _prm;
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _url + "' ,'','left=50,top=100,width=1200,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
            //}
            //else if (e.CommandName == "delete1")
            //{
            //    Confirmdelete();
            //}
        }

        protected void myhistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[9].Visible = false;
            if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
            {
                //tdHistory.Visible = false;
                e.Row.Cells[8].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].Text = "0" + e.Row.Cells[4].Text;
            }
        }

        protected void myhistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Delete_doc(string Project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + Project;
            _clsdocument _objcls = new _clsdocument();
            //_clscmsdocument _objcls = new _clscmsdocument();
            _objcls.doc_id = Convert.ToInt32(lblitmid.Text);
            _objbll.Delete_CMS_Doc(_objcls, _objdb);
            Load_doc(lblprj.Text);
            lblitmid.Text = "0";
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            Delete_doc((string)Session["project"]);

        }

        protected void mygrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rpt_history_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "delete1")
            {
                Label _cmnt = (Label)e.Item.FindControl("lblcmnt");
                Label _id = (Label)e.Item.FindControl("lbldocid");
                lblitmid.Text = _id.Text;
                if (Convert.ToInt16(_cmnt.Text) > 0)
                {
                    lblqns.Text = "Comments exists , Do you want to delete this record?";
                }
                else lblqns.Text = "Do you want to delete this record?";
                ModalPopupExtender1.Show();
            }
        }
        protected void rpt_latest_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "delete1")
            {
                Label _cmnt = (Label)e.Item.FindControl("lblcmnt");
                Label _id = (Label)e.Item.FindControl("lbldocid");
                lblitmid.Text = _id.Text;
                if (Convert.ToInt16(_cmnt.Text) > 0)
                {
                    lblqns.Text = "Comments exists , Do you want to delete this record?";
                }
                else lblqns.Text = "Do you want to delete this record?";
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
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label _cmnt = (Label)e.Item.FindControl("lblversion");
                if (_cmnt.Text.Length == 1)
                    _cmnt.Text = "0" + _cmnt.Text;
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
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label _cmnt = (Label)e.Item.FindControl("lblversion");
                if (_cmnt.Text.Length == 1)
                    _cmnt.Text = "0" + _cmnt.Text;
            }
        }

        protected void btnuploadnew_Click(object sender, EventArgs e) 
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + Request.QueryString.ToString() + "'," + (lblprj.Text == "HMIM" || lblprj.Text == "HMHS" ? 38 : 39) + ");", true);
        }
    }

}
