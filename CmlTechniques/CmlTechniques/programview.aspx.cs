using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;

namespace CmlTechniques
{
    public partial class programview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                lblprj.Text = Request.QueryString["prj"].ToString();
                lblid.Text = Request.QueryString["doc"].ToString();
                string _file = Get_file();
                string _filepath = "https://cmltechniques.com/CMS_DOCS/" + lblprj.Text + "/" + _file;
                myframe.Attributes.Add("src", _filepath);
                load_Basket();
                load_comments();
            }
        }
        private string Get_file()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "db_" + lblprj.Text;
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.Doc_Id = Convert.ToInt32(lblid.Text);
            return _objbll.Get_file(_objcls, _objdb);
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
                
            }
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            if (txtcomments.Text.Length <= 0) return;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscomment _objcls = new _clscomment();
            _objcls.page_no = "";
            _objcls.sec_no = txtno.Text;
            _objcls.comment = txtcomments.Text;
            _objcls.user_id = (string)Session["uid"];
            _objcls.prj_code = lblprj.Text;
            _objcls.module = "CMS";
            _objcls.type = 4;//for Programs
            _objcls.doc_id = Convert.ToInt32(lblid.Text);
            _objbll.addtobasket(_objcls,_objdb);
            load_Basket();
            txtno.Text = String.Empty;
            txtcomments.Text = String.Empty;
        }
        void load_Basket()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscomment _objcls = new _clscomment();
            _objcls.user_id = (string)Session["uid"];
            _objcls.prj_code = lblprj.Text;
            _objcls.module = "CMS";
            _objcls.type = 4;
            _objcls.doc_id = Convert.ToInt32(lblid.Text);
            mygridcomm_.DataSource = _objbll.load_commentbasket(_objcls,_objdb);
            mygridcomm_.DataBind();
            
        }

        protected void mygridcomm__RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mygridcomm_.Rows[_rowidx];
            TableCell _id = _srow.Cells[3];
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscomment _objcls = new _clscomment();
            _objcls.comm_id = Convert.ToInt32(_id.Text);
            _objbll.Remove_basket(_objcls,_objdb);
            load_Basket();
        }

        protected void mygridcomm__RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[3].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Cells[2].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            save_comments();
        }
        protected void save_comments()
        {
            if (mygridcomm_.Rows.Count <= 0) return;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscmscomment _objcls = new _clscmscomment();
            for (int i = 0; i <= mygridcomm_.Rows.Count - 1; i++)
            {
                _objcls.com_date = DateTime.Now;
                _objcls.comment = mygridcomm_.Rows[i].Cells[2].Text;
                _objcls.doc_id = Convert.ToInt32(lblid.Text);
                _objcls.uid = (string)Session["uid"];
                _objcls.project = lblprj.Text;
                _objcls.module = "PROGRAMS";
                _objcls.sec = mygridcomm_.Rows[i].Cells[1].Text;
                _objcls.page = "0";
                _objbll.Add_CMS_Comments(_objcls,_objdb);
            }
            
            ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('Comment Saved!');", true);
            //Response.Redirect("CMS/CMS.aspx?PRJ=" + lblprj.Text);
            Response.Redirect("CMS/CMS.aspx?PRJ=PV");
            load_comments();
            mygridcomm_.DataSource = "";
            mygridcomm_.DataBind();
        }
        protected void load_comments()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_clscmscomment _objcls = new _clscmscomment();
            //_objcls.doc_id = Convert.ToInt32((string)Session["pid"]);
            //mygrid.DataSource = _objbll.Load_CMS_Comments(_objcls);
            //mygrid.DataBind();               

        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            //Response.Redirect("CMS/CMS.aspx?PRJ=" + lblprj.Text);
            Response.Redirect("CMS/CMS.aspx?PRJ=PV");
        }

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType!=DataControlRowType.Header)
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
        }
    }
}
