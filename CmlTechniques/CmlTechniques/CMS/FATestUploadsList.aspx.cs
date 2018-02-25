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
    public partial class FATestUploadsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {


                lblprj.Text = Request.QueryString["prj"].ToString();
                lblid.Text = Request.QueryString["id"].ToString();
                lblmod.Text = Request.QueryString["mod"].ToString();



                
                //Session["mod_name"] = "Factory Acceptance Test Uploads";
                //Session["reff_no"] = (string)Session["project"] + "/" + Request.QueryString[1].ToString();
                //_Create_Cookies();
                //lblprj.Text = (string)Session["project"];
                Get_Title();
                Load_doc();
                Load_doc_pre();

                if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
                {
                    tdDelete.Visible = false;
                    tdgrid1.Visible = false;
                }
            }
        }
        private void Get_Title()
        {
            if (lblmod.Text == "FAT")
                lbltitle.Text = "Factory Acceptance Test Uploads";

            if (!String.IsNullOrEmpty(Request.QueryString["Head"]))
            {
                lbltitle.Text = lbltitle.Text  + " - " + Request.QueryString["Head"].ToString();

            }
           
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
            mygrid.DataSource = _objbll.Load_CMS_Document(_objcls, _objdb);
            mygrid.DataBind();
        }
        protected void Load_doc_pre()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.reff_no = lblmod.Text + "/" + lblid.Text;
            _objcls.project_code = lblprj.Text;
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
            string _file = _item.Text;
            Session["docid"] = _id.Text;
            Session["file"] = _item.Text;

            if (e.CommandName == "view")
            {
                string _prm = "prj=" + lblprj.Text + "&doc=" + lblid.Text + "&mod=" + lblmod.Text;
                //string _url = "DocPdfView.aspx?id=" + _prm;
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _url + "' ,'','left=210,top=100,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _prm + "','36');", true);
            }
           
            else if (e.CommandName == "delete1")
            {

                Confirmdelete();
            }

        }

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
            {
                tdDelete.Visible = false;
                e.Row.Cells[7].Visible = false;
            }
        }

        protected void mygrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if(e.Row.RowType!=DataControlRowType.Header)
            //    e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
            {
                tdgrid1.Visible = false;
                e.Row.Cells[7].Visible = false;
            }
        }

        protected void mygrid1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mygrid1.Rows[_rowidx];
            TableCell _id = _srow.Cells[0];
            TableCell _item = _srow.Cells[1];
            //TableCell _commTotal = _srow.Cells[5];
            Session["docid"] = _id.Text;

             Session["file"] = _item.Text;

            if (e.CommandName == "view")
            {
                string _prm = "prj=" + lblprj.Text + "&doc=" + lblid.Text + "&mod=" + lblmod.Text;
                string _url = "DocPdfView.aspx?" + _prm;

                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _prm + "','36');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + fpath + "' ,'','');", true);
            }
            else if (e.CommandName == "delete1")
            {
                Confirmdelete();

            }
        }
        protected void Delete_doc()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            //_objdb.DBName = "db_123";
            _clsdocument _objcls = new _clsdocument();
            //_clscmsdocument _objcls = new _clscmsdocument();
            //_objcls.doc_id = 111;
            _objcls.doc_id = Convert.ToInt32((string)Session["docid"]);
            _objbll.Delete_CMS_Doc(_objcls, _objdb);


            Load_doc();
            Load_doc_pre();


        }
        protected void Update_doc_status()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocument _objcls = new _clsdocument();
            _objcls.doc_id = Convert.ToInt32((string)Session["docid"]);
            _objcls.status = drstatus.SelectedItem.Text;
            _objbll.Update_CMSDoc_Status(_objcls, _objdb);
            Load_doc();
            Load_doc_pre();


        }
        void Confirmdelete()
        {
            ModalPopupExtender1.Show();
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            Delete_doc();

            ModalPopupExtender1.Hide();

        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if (drstatus.SelectedItem.Text == "-- Select --")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Status')", true);
                return;
            }
            Update_doc_status();
            ModalPopupExtender1.Hide();

        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }
        protected void btnuploadnew_Click(object sender, EventArgs e)
        {
            //string _prm = (string)Session["docid"];
            string _prm = "&prj=" + lblprj.Text + "&id=" + lblid.Text + "&mod=" + lblmod.Text+ "&Head="+Request.QueryString["Head"].ToString();
            string _url = "FATestUploadsEntry.aspx?" + _prm;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _url + "' ,'','left=210,top=100,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _url + "','37');", true);
            Response.Redirect(_url);
        }

    }
}
