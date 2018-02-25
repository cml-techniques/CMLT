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
    public partial class methodstatements1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                if (_prm != "0")
                {
                   lblTreepath.Text= _prm.Substring(_prm.IndexOf("_V") + 2);
                   lblFold_cms.Text = _prm.Substring(0, _prm.IndexOf("_M"));
                    lblM_id_cms.Text=  _prm.Substring(_prm.IndexOf("_M") + 2, _prm.IndexOf("_N") - (_prm.IndexOf("_M") + 2));
                    lblM_na_cms.Text= _prm.Substring(_prm.IndexOf("_N") + 2, _prm.IndexOf("_P") - _prm.IndexOf("_N") - 2);
                    //Session["reff_no"] = (string)Session["Fold_cms"] + "/" + (string)Session["M_id_cms"];
                    //head.Text = (string)Session["M_na_cms"].ToString().Replace("^", "&");
                    lblprj.Text = (string)Session["project"];
                    string _path = (string)lblM_na_cms.Text;
                   lblmod.Text= _path.Substring(0, _path.IndexOf(" >"));
                   lblreff_no.Text = lblFold_cms.Text + "/" + lblM_id_cms.Text + "/" + lblmod.Text;
                    phead.Text = lblM_na_cms.Text.Replace("^", "&");
                  lblfpath.Text= _path.Replace(">", "#");
                    _Create_Cookies();
                }
                else
                {
                    phead.Text = "Method Statement Schedule History";

                }
                lblprj.Text = (string)Session["project"];

                lbldiv.Text = Request.QueryString[1].ToString();


                Load_doc();
                Load_doc_pre();

                if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
                {
                    btnuploadnew.Visible = false;

                    if (lblprj.Text == "ABS")
                    {
                        publicCls.publicCls _obj = new publicCls.publicCls();
                        btnuploadnew.Visible = _obj.Load_User_Module_Permission(lblprj.Text, (string)Session["uid"], 4);
                    }
                }
                if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS" || lblprj.Text == "ABS")
                {
                    Get_ProjectName();
                }
                else
                {
                    dvfixedhead.Visible = false;
                    dvfixedcontent.Style.Add("Top", "0px");
                }
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
        void _Create_Cookies()
        {
            if (Request.Browser.Cookies)
            {
                HttpCookie _CookiefPath = new HttpCookie("fpath");
                _CookiefPath.Value = lblfpath.Text;
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
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.reff_no = lblreff_no.Text;
            _objcls.project_code = lblprj.Text;
            _objcls.status = true;
            _objcls.folder = Convert.ToInt32(lbldiv.Text);
            rpt_latest.DataSource = _objbll.Load_CMS_Document_Div(_objcls, _objdb);
            rpt_latest.DataBind();
        }
        protected void Load_doc_pre()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.reff_no = lblreff_no.Text;
            _objcls.project_code = lblprj.Text;
            _objcls.folder = Convert.ToInt32(lbldiv.Text);
            _objcls.status = false;
            rpt_history.DataSource = _objbll.Load_CMS_Document_Div(_objcls, _objdb);
            rpt_history.DataBind();
        }

        protected void mygrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int _rowidx = Convert.ToInt32(e.CommandArgument);
            //GridViewRow _srow = mygrid.Rows[_rowidx];
            //TableCell _item = _srow.Cells[1];
            //TableCell _id = _srow.Cells[0];
            //TableCell _commTotal = _srow.Cells[10];
            //string _file = _item.Text;
            //Session["docid"] = _id.Text;
            //Session["file"] = _item.Text;
            //Session["head"] = phead.Text + " :- " + _item.Text;
            ////Session["CommTotal"] = _commTotal.Text;
            //if (e.CommandName == "view")
            //{
            //    string _prm = "prj=" + lblprj.Text + "&mode=MS&doc=" + _id.Text;
            //    Session["viewmode"] = "MS";
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('"+ _prm +"','5');", true);
            //}
            //else if (e.CommandName == "view1")
            //{
            //    string _prm = Session["docid"] + "_MMethod Statement_T1";
            //    string _url = "ViewComments.aspx?id=" + _prm;
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _url + "' ,'','left=50,top=100,width=1200,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
            //    //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ (string)Session["docid"] +"')", true);
            //}
            //else if (e.CommandName == "view2")
            //{
            //    string _prm = Session["docid"] + "_MMethod Statement_T2";
            //    string _url = "ViewComments.aspx?id=" + _prm;
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _url + "' ,'','left=50,top=100,width=1200,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
            //}
            //else if (e.CommandName == "delete1")
            //{

            //    Confirmdelete();
            //}

        }

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[10].Visible = false;
            if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
            {
                //tdDelete.Visible = false;
                e.Row.Cells[9].Visible = false;
            }
        }

        protected void mygrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if(e.Row.RowType!=DataControlRowType.Header)
            //    e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[10].Visible = false;
            if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
            {
                //tdgrid1.Visible = false;
                e.Row.Cells[9].Visible = false;
            }
        }

        protected void mygrid1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int _rowidx = Convert.ToInt32(e.CommandArgument);
            //GridViewRow _srow = mygrid1.Rows[_rowidx];
            //TableCell _id = _srow.Cells[0];
            //TableCell _item = _srow.Cells[1];
            //TableCell _commTotal = _srow.Cells[10];
            //Session["docid"] = _id.Text;
            ////Session["CommTotal"] = _commTotal.Text;
            //string fpath = "http://www.cmltechniques.com/CMS_DOCS/" + (string)Session["project"] + "/" + _item.Text;
            //if (e.CommandName == "view")
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + fpath + "','10');", true);
            //else if (e.CommandName == "view1")
            //{
            //    string _prm = Session["docid"] + "_MMethod Statement_T1";
            //    string _url = "ViewComments.aspx?id=" + _prm;
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _url + "' ,'','left=50,top=100,width=1200,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
            //    //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ (string)Session["docid"] +"')", true);
            //}
            //else if (e.CommandName == "delete1")

            //{
            //    Confirmdelete();

            //}
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
            lblitmid.Text = "0";
            //Load_doc((string)Session["project"]);

            Load_doc();
            Load_doc_pre();



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

        void Confirmdelete()
        {
            if (Convert.ToInt16(Session["CommTotal"].ToString()) > 0)
            {
                lblqns.Text = "Comments exists , Do you want to delete this record?";
            }
            else lblqns.Text = "Do you want to delete this record?";

            ModalPopupExtender1.Enabled = true;
            ModalPopupExtender1.Show();
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            Delete_doc(lblprj.Text);

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
