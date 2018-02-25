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
using System.Globalization;

namespace CmlTechniques.CMS
{
    public partial class ms12761 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                if (_prm != "0")
                {
                    Session["Treepath"] = _prm.Substring(_prm.IndexOf("_V") + 2);
                    Session["Fold_cms"] = _prm.Substring(0, _prm.IndexOf("_M"));
                    Session["M_id_cms"] = _prm.Substring(_prm.IndexOf("_M") + 2, _prm.IndexOf("_N") - (_prm.IndexOf("_M") + 2));
                    Session["M_na_cms"] = _prm.Substring(_prm.IndexOf("_N") + 2, _prm.IndexOf("_P") - _prm.IndexOf("_N") - 2);
                    //Session["reff_no"] = (string)Session["Fold_cms"] + "/" + (string)Session["M_id_cms"];
                    //head.Text = (string)Session["M_na_cms"].ToString().Replace("^", "&");
                    lblmsid.Text = (string)Session["M_id_cms"];
                    lblprj.Text = (string)Session["project"];
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
                lblprj.Text = (string)Session["project"];
                Load_doc();
                Load_doc_pre();

                //if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
                //{
                //    tdDelete.Visible = false;
                //    tdgrid1.Visible = false;
                //}
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
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.reff_no = (string)Session["reff_no"];
            _objcls.project_code = lblprj.Text;
            _objcls.status = true;
            rpt_latest.DataSource = _objbll.Load_CMS_Document(_objcls, _objdb);
            rpt_latest.DataBind();
            Get_MSInfo();
        }
        private void Get_MSInfo()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.reff_no = (string)Session["reff_no"];
            DataTable _dt = _objbll.Get_MsInfo(_objcls, _objdb);
            if (_dt.Rows.Count <= 0) return;
            drrevcml.ClearSelection();
            txt_sdate.Text = _dt.Rows[0][0].ToString();
            drrevcml.Items.FindByText(_dt.Rows[0][1].ToString()).Selected = true;
            lblinfo.Text = "Planned Submission Date : " + _dt.Rows[0][0].ToString() + " - Reviewed by CML : " + _dt.Rows[0][1].ToString();
        }
        protected void Load_doc_pre()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.reff_no = (string)Session["reff_no"];
            _objcls.project_code = lblprj.Text;
            _objcls.status = false;
            rpt_history.DataSource = _objbll.Load_CMS_Document(_objcls, _objdb);
            rpt_history.DataBind();
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
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            Update_Info();
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtender2.Hide();
        }
        private bool DateValidation(string dateString)
        {
            DateTime dateValue;
            string[] format = new string[] { "dd/MM/yyyy" };
            string[] format1 = new string[] { "dd/MM/yy" };
            if (DateTime.TryParseExact(dateString, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out dateValue))
                return true;
            else if (DateTime.TryParseExact(dateString, format1, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out dateValue))
                return true;
            else
                return false;

        }
        private void Update_Info()
        {
            if (DateValidation(txt_sdate.Text) == false)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid submission date!');", true);
                return;
            }
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.msid = Convert.ToInt32(lblmsid.Text);
            string subdate = null;
            string revbdate = null;
            //if (DateValidation(txt_sdate.Text) == true)
            //{
            //    subdate = DateTime.ParseExact(txt_sdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                
            //}
            _objcls.sbdate = txt_sdate.Text;
            //if (DateValidation(txt_rdate.Text) == true)
            //{
            //    revbdate = DateTime.ParseExact(txt_rdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
               
            //}
            _objcls.rvdate = txt_rdate.Text;
            if (drrevcml.SelectedValue == "1")
                _objcls.rev_cml = true;
            else
                _objcls.rev_cml = false;
            if (drissuedbhc.SelectedValue == "1")
                _objcls.status = true;
            else
                _objcls.status = false;
            _objbll.Update_msinfo(_objcls, _objdb);
            ModalPopupExtender2.Hide();
        }
    }

}
