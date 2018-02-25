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
    public partial class MonthlyReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                lblprj.Text = Request.QueryString["prj"].ToString();
                lblid.Text = Request.QueryString["id"].ToString();
                lblmod.Text = Request.QueryString["mod"].ToString();
                prj.Text = Get_ProjectName();
                Load_doc();
                if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
                {
                    btnuploadnew.Visible = false;
                }
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
            _objcls.reff_no = lblmod.Text + "/" + lblid.Text;
            _objcls.project_code = lblprj.Text;
            _objcls.status = true;
            rpt_latest.DataSource = _objbll.Load_CMS_Document_All(_objcls, _objdb);
            rpt_latest.DataBind();
        }
        protected void rpt_latest_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label _id = (Label)e.Item.FindControl("lbldocid");
            Session["docid"] = _id.Text;
            if (e.CommandName == "delete1")
            {
                lblqns.Text = "Do you want to delete this record?";

                ModalPopupExtender1.Show();
            }

            else if (e.CommandName == "view")
            {

                Label lbldocname = (Label)e.Item.FindControl("lbldocname");
                Session["file"] = lbldocname.Text;

                string _prm = "prj=" + lblprj.Text + "&doc=" + lblid.Text + "&mod=" + lblmod.Text;
                //string _url = "DocPdfView.aspx?id=" + _prm;
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _url + "' ,'','left=210,top=100,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _prm + "','36');", true);
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
        protected void Delete_Click(object sender, EventArgs e)
        {
            Delete_doc((string)Session["project"]);

            Response.Redirect("MonthlyReport.aspx?" + Request.QueryString.ToString());

        }

        protected void btnuploadnew_Click(object sender, EventArgs e)
        {
            //string _prm = (string)Session["docid"];
            string _prm = "&prj=" + lblprj.Text + "&id=" + lblid.Text + "&mod=" + lblmod.Text;
            string _url = "MonthlyReportEntry.aspx?" + _prm;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _url + "' ,'','left=210,top=100,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _url + "','37');", true);
            Response.Redirect(_url);
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


            Load_doc();
            // Load_doc_pre();


        }


    }
}
