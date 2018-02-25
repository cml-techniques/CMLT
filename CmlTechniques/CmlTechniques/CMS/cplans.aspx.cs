using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BusinessLogic;
using App_Properties;
using System.Data;

namespace CmlTechniques.CMS
{
    public partial class cplans : System.Web.UI.Page
    {
        public static DataTable _dtmaster;
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
                lblprj.Text = (string)Session["project"];
                phead.Text = (string)Session["M_na_cms"].ToString().Replace("^", "&");
                //Load_doc(lblprj.Text);
                lbltitle.Text = "Latest Version of the " + phead.Text;
                _ReadCookies();

                //if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
                //{
                //    tdDelete.Visible = false;
                //    tdHistory.Visible = false;

                //}
                //lblprj.Text = Request.QueryString["prj"].ToString();
                //lbluser.Text = Request.QueryString["auh"].ToString();
                prj.Text = Get_ProjectName();
                pagetitle.Visible = false;
                doc_list.Visible = false;
                Setup();
            }
        }
        private string Get_ProjectName()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            return _objbll.Get_ProjectName(_objcls, _objdb);
        }
        private void Setup()
        {
            Load_Packages(lblprj.Text);
            if (lblprj.Text == "14211")
            {
                rd_facility.Enabled = false;
                btnenter.Enabled = false;
                string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
            }
            else
            {
                //btnenter1.Enabled = false;
                //string script = "function f(){$find(\"" + RadWindow2.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
                pagetitle.Visible = true;
                doc_list.Visible = true;
                Load_doc(lblprj.Text);
            }
        }
        private void Load_Packages(string _prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + _prj;
            DataTable _dtpkg = _objbll.Load_fclty_Package(_objdb);
            rd_package.DataSource = _dtpkg;
            rd_package.DataTextField = "PKG_NAME";
            rd_package.DataValueField = "PKG_ID";
            rd_package.DataBind();
            _dtmaster = _objbll.Load_Facility(_objdb);
        }

        protected void rd_package_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            Load_Facility(Convert.ToInt32(rd_package.SelectedValue));
        }
        protected void rd_facility_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            btnenter.Enabled = true;
        }
        private void Load_Facility(int _pkg_id)
        {
            var _result = _dtmaster.Select("PKG_ID =" + _pkg_id);
            DataTable _dtresult = _result.Any() ? _result.CopyToDataTable() : _dtmaster.Clone();
            rd_facility.Enabled = true;
            rd_facility.Items.Clear();
            rd_facility.DataSource = _dtresult;
            rd_facility.DataTextField = "FCLTY";
            rd_facility.DataValueField = "FCLTY_ID";
            rd_facility.DataBind();
        }
        protected void btnenter_Click(object sender, EventArgs e)
        {
            facid.Text = rd_facility.SelectedValue;
            package.Text = "FACILITY : " + rd_package.SelectedItem.Text + " - " + rd_facility.SelectedItem.Text;
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
            pagetitle.Visible = true;
            doc_list.Visible = true;
            Load_doc(lblprj.Text);
            //string _prm = lblprj.Text + "_S" + lblsch.Text;
            //myframe1.Attributes.Add("src", "../Cassheet_DataEntry.aspx?id=" + _prm);
            //menu.Visible = true;
        }
        protected void btnenter1_Click(object sender, EventArgs e)
        {
            facid.Text = rdbuilding.SelectedValue;
            package.Text = "BUILDING : " + rdbuilding.SelectedItem.Text;
            string script = "function f(){$find(\"" + RadWindow2.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
            pagetitle.Visible = true;
            doc_list.Visible = true;
            Load_doc(lblprj.Text);
            //string _prm = lblprj.Text + "_S" + lblsch.Text;
            //myframe1.Attributes.Add("src", "../Cassheet_DataEntry.aspx?id=" + _prm);
            //menu.Visible = true;
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
            //if (Convert.ToInt16(Session["CommTot"].ToString()) > 0)
            //{
            //    lblqns.Text = "Comments exists , Do you want to delete this record?";
            //}
            //else lblqns.Text = "Do you want to delete this record?";
            //ModalPopupExtender1.Show();
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
            //_objcls.doc_id = Convert.ToInt32(lblitmid.Text);
            //_objbll.Delete_CMS_Doc(_objcls, _objdb);
            //Load_doc(lblprj.Text);
            //lblitmid.Text = "0";
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
                //Label _cmnt = (Label)e.Item.FindControl("lblcmnt");
                //Label _id = (Label)e.Item.FindControl("lbldocid");
                //lblitmid.Text = _id.Text;
                //if (Convert.ToInt16(_cmnt.Text) > 0)
                //{
                //    lblqns.Text = "Comments exists , Do you want to delete this record?";
                //}
                //else lblqns.Text = "Do you want to delete this record?";
                //ModalPopupExtender1.Show();
            }
        }
        protected void rpt_latest_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //if (e.CommandName == "delete1")
            //{
            //    Label _cmnt = (Label)e.Item.FindControl("lblcmnt");
            //    Label _id = (Label)e.Item.FindControl("lbldocid");
            //    lblitmid.Text = _id.Text;
            //    if (Convert.ToInt16(_cmnt.Text) > 0)
            //    {
            //        lblqns.Text = "Comments exists , Do you want to delete this record?";
            //    }
            //    else lblqns.Text = "Do you want to delete this record?";
            //    ModalPopupExtender1.Show();
            //}
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

        protected void rdbuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnenter1.Enabled = true;
        }
    }
}
