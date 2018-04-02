using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Data;

namespace CmlTechniques.CMS
{
    public partial class docview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                lblprjid.Text = Request.QueryString["prj"].ToString();
                lblvmode.Text = Request.QueryString["mode"].ToString();
                lblid.Text = Request.QueryString["doc"].ToString();
                cmdsave.Enabled = false;
                load_document(lblvmode.Text);
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
                if (Request.Cookies["cfile"] != null)
                {
                    Session["cfile"] = Server.HtmlEncode(Request.Cookies["cfile"].Value);
                }
                if (Request.Cookies["file"] != null)
                {
                    Session["file"] = Server.HtmlEncode(Request.Cookies["file"].Value);
                }
                if (Request.Cookies["access"] != null)
                {
                    Session["access"] = Server.HtmlEncode(Request.Cookies["access"].Value);
                }
                if (Request.Cookies["id"] != null)
                {
                    Session["id"] = Server.HtmlEncode(Request.Cookies["id"].Value);
                }



            }
        }
        private string Get_file()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "db_" + lblprjid.Text;
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.Doc_Id = Convert.ToInt32(lblid.Text);
            return _objbll.Get_file(_objcls, _objdb);
        }
        private string Get_Status()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "db_" + lblprjid.Text;
            _clsdocument _objcls = new _clsdocument();
            _objcls.doc_id = Convert.ToInt32(lblid.Text);
            return _objbll.Get_DocStatus(_objcls, _objdb);
        }

        private void HideComment(int mode)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = (string)Session["uid"];
            _objcls.project_code = lblprjid.Text;
            _objcls.mode = mode;
            string _access = _objbll.Get_CMSAccess(_objcls, _objdb);
            string _user = (string)Session["uid"];
            if (_user.Contains("cmlgroup") != true)
            {
                if (_access != "Review/Comments")
                {
                    mydiv.Visible = false;
                    cmdsave.Visible = false;
                }
                else
                {
                    mydiv.Visible = true;
                    cmdsave.Visible = true;
                }

            }
            else
            {
                mydiv.Visible = true;
                cmdsave.Visible = true;
            }
        }

        private void load_document(string _mode)
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["file"] + "');", true);
            string _file = Get_file();
            Session["cfile"] = (string)Session["file"];
            lbstatus.Text = "Document Name: " + _file;
            if (_mode == "MS")
            {

                HideComment(1);

                if (Get_Status() != "REVIEW")
                {
                    mydiv.Visible = false;
                    cmdsave.Visible = false;
                    cmdadd1.Text = "Exit";
                }
                lblhead.Text = "Method Statement";
                Session["type"] = "2";
                btnlink.Visible = true;
                
            }
            else if (_mode == "CP")
            {
                HideComment(1);

                lblhead.Text = "Commissioning Plan";
                Session["type"] = "3";
                btnlink.Visible = false;
                mydiv1.Visible = false;
                if (Get_Status() != "REVIEW")
                {
                    mydiv.Visible = false;
                    cmdsave.Visible = false;
                    cmdadd1.Text = "Exit";
                }
            }
            else if (_mode == "CR")
            {
                lblhead.Text = "Commissioning Report";
                Session["type"] = "3";
                btnlink.Visible = false;
                mydiv1.Visible = false;
            }
            else if (_mode == "TR")
            {
                lblhead.Text = "TRAINING";
                Session["type"] = "4";
                btnlink.Visible = false;
            }
            else if (_mode == "SO")
            {
                lblhead.Text = "Site Observation";
                Session["type"] = "5";
                btnlink.Visible = false;
            }
            load_Basket();
            Session["module"] = "CMS";
            string file = "https://cmltechniques.com/CMS_DOCS/" + lblprjid.Text + "/" + _file;
            myframe.Attributes.Add("src", file);
           

        }
        protected void btnNo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CMS.aspx");
        }
        protected void cmdadd_Click(object sender, EventArgs e)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprjid.Text;
            _clscomment _objcls = new _clscomment();
            _objcls.page_no = txtpno.Text;
            _objcls.sec_no = txtsno.Text;
            _objcls.comment = txtcmnt.Text;
            _objcls.user_id = (string)Session["uid"];
            _objcls.prj_code = lblprjid.Text;
            _objcls.module = "CMS";
            if (lblvmode.Text == "MS")
            {
                _objcls.type = 2;//for MS
            }
            else if(lblvmode.Text == "CP")
            {
                _objcls.type = 3;//for CP
            }
            else if (lblvmode.Text == "TR")
            {
                _objcls.type = 4;//for CP
            }
            _objcls.doc_id = Convert.ToInt32(lblid.Text);
            _objbll.addtobasket(_objcls,_objdb);
            load_Basket();
            txtpno.Text = "";
            txtsno.Text = "";
            txtcmnt.Text = "";
        }
        void load_Basket()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprjid.Text;
            _clscomment _objcls = new _clscomment();
            _objcls.user_id = (string)Session["uid"];
            _objcls.prj_code = lblprjid.Text;
            _objcls.module = "CMS";
            _objcls.type = Convert.ToInt32((string)Session["type"]);
            _objcls.doc_id = Convert.ToInt32(lblid.Text);
            mybasket.DataSource = _objbll.load_commentbasket(_objcls,_objdb);
            mybasket.DataBind();
            if (mybasket.Rows.Count > 0)
                cmdsave.Enabled = true;
            else
                cmdsave.Enabled = false;
        }
        private void Save_Comments()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprjid.Text;
            _clscmscomment _objcls = new _clscmscomment();
            bool _cmt = false;
            for (int i = 0; i <= mybasket.Rows.Count - 1; i++)
            {
                _objcls.com_date = DateTime.Now;
                _objcls.comment = mybasket.Rows[i].Cells[2].Text;
                _objcls.doc_id = Convert.ToInt32((lblid.Text));
                _objcls.uid = (string)Session["uid"];
                _objcls.project = lblprjid.Text;
                _objcls.module = lblvmode.Text;
                _objcls.sec = mybasket.Rows[i].Cells[1].Text;
                _objcls.page = mybasket.Rows[i].Cells[0].Text;
                _objbll.Add_CMS_Comments(_objcls, _objdb);
                _cmt = true;
            }
            if (_cmt == true)
                Send_Email();
        }
        private void Change_DocStatus()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _clsdocument _objcls = new _clsdocument();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprjid.Text;
            _objcls.doc_id = Convert.ToInt32(lblid.Text);
            _objcls.status = drstatus.SelectedItem.Text;
            _objbll.Update_CMSDoc_Status(_objcls, _objdb);
        }
        protected void cmdsave_Click(object sender, EventArgs e)
        {
            Save_Comments();
           
            if (drstatus.SelectedItem.Value != "0")
            {
                Change_DocStatus();
            }
            //Response.Redirect("CMS.aspx?PRJ=" + lblprjid.Text);
            Redirect();
        }
        void Redirect()
        {
            string PRJ = "";

            if (lblvmode.Text != "MS" && lblvmode.Text != "CP")
            {
                PRJ = lblprjid.Text;
            }
            if (lblvmode.Text == "MS" && lblprjid.Text=="HMIM")
            {
                string url = "CMS2.aspx?mod=MS&PRJ="+  lblprjid.Text +"&id=" + Request.QueryString["id"].ToString() + "&Div=" + Request.QueryString["Div"].ToString(); 
                Response.Redirect("CMS2.aspx?"+url);
                return;
            }
           else if (lblvmode.Text == "MS" && lblprjid.Text == "ABS")
            {
                string url = "CMS.aspx?mod=MS&PRJ=" + lblprjid.Text + "&id=" + Request.QueryString["id"].ToString() + "&Div=" + Request.QueryString["Div"].ToString();
                Response.Redirect("CMS.aspx?" + url);
                return;
            }
            else if (lblvmode.Text == "CR" && lblprj.Text == "ABS")
            {
                string url = "CMS.aspx?mod=CR&PRJ=" + lblprjid.Text;
                Response.Redirect("CMS.aspx?" + url);
                return;
            }
            else
                PRJ = lblvmode.Text;

            Response.Redirect("CMS.aspx?PRJ=" + PRJ);
        }
        protected void cmdadd1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("CMS.aspx?PRJ=" + lblprjid.Text);
            Redirect();
        }

        protected void mybasket_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mybasket.Rows[_rowidx];
            TableCell _id = _srow.Cells[4];
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprjid.Text;
            _clscomment _objcls = new _clscomment();
            _objcls.comm_id = Convert.ToInt32(_id.Text);
            _objbll.Remove_basket(_objcls,_objdb);
            load_Basket();
        }

        protected void mybasket_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Cells[2].Attributes.Add("style", "word-wrap:break-word");
            e.Row.Cells[4].Visible = false;
        }
        protected void Send_Email()
        {
            BLL_Dml _oblbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprjid.Text;
            DataTable _dtable;
            //string Body = "Ref. " + (string)Session["projectname"] + "/" + lbstatus.Text + "\n\n" + "This is an automatically generated email to advise you that the " + (string)Session["mod_name"] + "  noted above has been uploaded to CML web site and is available for review." + "\n\n" + "Could you please find time to review the document and make any comments using the comment screen." + "\n\n" + "If you review and have no comments on the manual, please confirm with 'No comments' on exit from the website." + "\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "http://www.cmldubai.com";
             string Body = "Ref. " + (string)Session["projectname"] + " - " + lblhead.Text + "/" + lbstatus.Text + "\n\n" + "A comment(s) has been made on the above " + lblhead.Text + " by " + (string)Session["uid"] + "\n\n" + "Please consider the comment(s) and revise the " + lblhead.Text + " appropriate." + "\n\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
            string _sub = "Ref. " + (string)Session["projectname"] + "/" + lblhead.Text + "/" + lbstatus.Text;
            publicCls.publicCls _obj = new publicCls.publicCls();
            if (lblvmode.Text == "MS")
            {
                //_dtable = _oblbll.Load_CMSUsers(_objcls, _objdb);
                //var _result = from o in _dtable.AsEnumerable()
                //              select o;
                //foreach (var _uid in _result)
                //{
                //    _obj.Send_Email(_uid[0].ToString(), _sub, Body);
                //}
                //_clsproject _objprj = new _clsproject();
                //for (int i = 0; i <= chk_company.Items.Count - 1; i++)
                //{
                //    if (chk_company.Items[i].Selected == true)
                //    {
                //        _objprj.com_id = Convert.ToInt32(chk_company.Items[i].Value);
                //        DataTable _dt = _oblbll.Load_UsersCompany(_objprj, _objdb);
                //        var _result = from o in _dt.AsEnumerable()
                //                      select o;
                //        foreach (var _uid in _result)
                //        {
                //            _obj.Send_Email(_uid[0].ToString(), _sub, Body);
                //        }
                //    }
                //}
            }
            else if (lblvmode.Text == "CP")
            {
                _objcls.mode = 2;
                _dtable = _oblbll.Load_CMS_Users(_objcls, _objdb);
                var _result = from o in _dtable.AsEnumerable()
                              select o;
                foreach (var _uid in _result)
                {
                    //_sub = _uid[0].ToString();
                    //_obj.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
                    _obj.Send_Email(_uid[0].ToString(), _sub, Body);
                }
            }
            //_obj.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
        }

        protected void drstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drstatus.SelectedValue != "0")
                cmdsave.Enabled = true;
            else
                cmdsave.Enabled = false;
        }
    }
}
