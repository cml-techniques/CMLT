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
    public partial class cmsdocreview_details : System.Web.UI.Page
    {
        //public string 

        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                lbluser.Text = (string)Session["uid"];
                string _id = Request.QueryString["id"].ToString();
                string _prj = Request.QueryString["PRJ"].ToString();


                lblid.Text = _id;
                lblprjcode.Text = _prj;
                if (lblprjcode.Text == "HMIM" || lblprjcode.Text == "HMHS")
                {
                    Load_SO_Admin_Response();
                    Get_ProjectName();
                }
                else
                {
                    dvfixedhead.Visible = false;
                    dvfixedcontent.Style.Add("Top", "0px");
                }
                Load_DocReview_Info(Convert.ToInt32(_id));
                load_doc_review_details(Convert.ToInt32(_id));
                if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP" && (string)Session["uid"].ToString().ToLower() != lbluid.Text.ToLower())
                {
                    btnedit.Enabled = false;
                    btndelete.Enabled = false;
                    btn.Visible = false;
                    btnreissue.Enabled = false;
                }
                if (lblprjcode.Text == "HMIM" || lblprjcode.Text == "AZC" || lblprjcode.Text == "HMHS" || lblprjcode.Text == "123" || lblprjcode.Text == "demo")
                {
                    tdBuildingLabel.Visible = true;
                    tdBuildingText.Visible = true;
                }
                else
                {
                    tdBuildingLabel.Visible = false;
                    tdBuildingText.Visible = false;
                }
                //lbpkg.Text = (string)Session["service"];
                //lbcreated.Text = (string)Session["created"];
                //lbno.Text = (string)Session["dr_no"];
                //lbissued.Text = (string)Session["issued"];
                //lbdoc.Text = (string)Session["doc"];
                
                //BLL_Dml _objbll = new BLL_Dml();
                //_database _objdb = new _database();
                //_objdb.DBName = "DBCML";
                //_clsuser _objcls = new _clsuser();
                //_objcls.project_code = _prj;
                //lbprj.Text = _objbll.Get_ProjectName(_objcls, _objdb);
                //prjlogo.Src = "../images/" + _prj + "logo.jpg";
                
            }

        }
        protected void Load_SO_Admin_Response()
        {
            lblPermission.Text = "0";
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();

            _objdb.DBName = "DB_" + lblprjcode.Text;
            _objcls.uid = Session["uid"].ToString();
            _objcls.project_code = lblprjcode.Text;


            if (_objbll.Load_SO_Admin_Response(_objcls, _objdb).Rows.Count > 0) lblPermission.Text = "1";

        }
        private void Get_ProjectName()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprjcode.Text;
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
        private void Load_DocReview_Info( int dr_id)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_id = dr_id;
            DataTable _dt = _objbll.Load_Document_Review_INFO(_objcls, _objdb);
            foreach (DataRow _drow in _dt.Rows)
            {
                lbpkg.Text = _drow["service"].ToString();
                lbcreated.Text = _drow["userid"].ToString();
                lbno.Text = _drow["dr_no"].ToString();
                lbissued.Text = _drow["issued"].ToString();
                lbdoc.Text = _drow["dr_reviewed"].ToString();
                lbldrno.Text = _drow["dr_no"].ToString();
                lblnote.Text = _drow["Note"].ToString();
                lbluid.Text = _drow["uid"].ToString();
                lblissued.Text = _drow["issued_to"].ToString();
                lblsrvid.Text = _drow["srv_id"].ToString();
                lblBuilding.Text = _drow["building"].ToString();
            }

        }
        protected void load_doc_review_details(int dr_id)
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ (string)Session["dr_id"] +"');", true);
            //Session["dr_id1"] = (string)Session["dr_id"];
            //Session["dr_no1"]=(string)Session["dr_no"];
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_id = dr_id;
            //mygrid1.DataSource = _objbll.Load_Document_Review_Details(_objcls);
            //mygrid1.DataBind();
            //mydetailsview.DataSource = _objbll.Load_Document_Review_Details(_objcls,_objdb);
            //mydetailsview.DataBind();
            mygrid_details.DataSource = _objbll.Load_Document_Review_Details(_objcls, _objdb);
            mygrid_details.DataBind();
            
           
        }

        //protected void btnaddtr_Click(object sender, EventArgs e)
        //{
        //    Insert_Doc_review_details();
        //}
        protected void Insert_Doc_review_details()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_id = Convert.ToInt32((string)Session["dr_id1"]);
            //_objcls.details = txtdetails.Text;
            _objcls.response = "";
            _objcls.issued_date = DateTime.Now;
            _objcls.uid = (string)Session["uid"];
            _objcls.dr_itm_id = 0;
            _objcls.mode = 1;
            _objbll.Document_Review_Details(_objcls,_objdb);
           // load_doc_review_details();
        }

        protected void mydetailsview_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            //mydetailsview.EditIndex = -1;
            //load_doc_review_details();
        }

        protected void mydetailsview_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            //mydetailsview.EditIndex = e.NewEditIndex;
            //load_doc_review_details();
        }

        protected void mydetailsview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                Label _id = (Label)e.Item.FindControl("lbid");
                TextBox _resp = (TextBox)e.Item.FindControl("responseTextBox");
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprjcode.Text;
                _clsdocreview _objcls = new _clsdocreview();
                _objcls.dr_id = 0;
                _objcls.details = "";
                _objcls.desc = "";
                _objcls.response = _resp.Text;
                _objcls.issued_date = DateTime.Now;
                _objcls.uid = "";
                _objcls.dr_itm_id = Convert.ToInt32(_id.Text);
                _objcls.mode = 0;
                _objbll.Document_Review_Details(_objcls,_objdb);
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.close();", true);
                
            }
            else if (e.CommandName == "Cancel")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.close();", true);

            }
            else if (e.CommandName == "Select")
            {
                Label _id = (Label)e.Item.FindControl("lbid");
                Session["id"] = _id.Text;
                txtcomments.Text = String.Empty;
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ (string)Session["id"] + "');", true);
                btnDummy_ModalPopupExtender.Show();
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
            }
        }

        protected void mydetailsview_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            //mydetailsview.EditIndex = -1;
            //load_doc_review_details();
        }
        int itm = 0;
        protected void mydetailsview_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Button _edit = (Button)e.Item.FindControl("EditButton");
            if ((string)Session["uid"].ToString().ToLower() != lbissued.Text.ToLower())
                _edit.Visible = false;
            Label _des = (Label)e.Item.FindControl("lbdes");
            //Label _det = (Label)e.Item.FindControl("lbdet");
            //Label _res = (Label)e.Item.FindControl("lbres");
            _des.Attributes.Add("style", "word-wrap:break-word");
            //_det.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            //_res.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            Label _itm = (Label)e.Item.FindControl("lbitm");
            _itm.Text = (itm + 1).ToString();
            itm += 1;
            Button _select = (Button)e.Item.FindControl("btncomt");
            if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
                _select.Visible = false;
           
        }

        protected void btnexp_Click(object sender, EventArgs e)
        {
            string html = hdnInnerHtml.Value;
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(1));
            Response.Clear();
            Response.AppendHeader("content-disposition", "attachment;filename=FileName.xls");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            this.EnableViewState = false;
            Response.Write("\r\n");
            Response.Write(html);
            Response.End();
        }

        protected void mydetailsview_ItemCreated(object sender, ListViewItemEventArgs e)
        {
          
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            string _prm = "Reports.aspx?id=dr" + lblid.Text + "&idx=0&prj=" + lblprjcode.Text;
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('"+ _prm +"','','left=210,top=100,width=1110,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=0');", true);
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string _prm = "../cmsdocreviewadd.aspx?type=1&" + Request.QueryString.ToString();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _prm + "','','left=210,top=100,width=1110,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=0');", true);
            Response.Redirect(_prm);
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_itm_id = Convert.ToInt32((string)Session["id"]);
            _objcls.response = txtcomments.Text;
            _objbll.dr_cml_comment(_objcls, _objdb);
            load_doc_review_details(Convert.ToInt32(lblid.Text));
            btnDummy_ModalPopupExtender.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }

        protected void mydetailsview_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }

        protected void mygrid_details_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            //string _uid = lbluser.Text;
            if (lbluser.Text.Trim().ToUpper() != lblissued.Text.Trim().ToUpper())
            {
                e.Row.Cells[6].Enabled = false;
            }
            if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
            {
                    e.Row.Cells[7].Enabled = false;
            }
            if (lblPermission.Text == "1")
            {
                e.Row.Cells[6].Enabled = true;
                e.Row.Cells[7].Enabled = true;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = (e.Row.RowIndex + 1).ToString();
                TextBox txtDet = (TextBox)e.Row.FindControl("txtdetails");
                int countRes = txtDet.Text.Length - txtDet.Text.Replace("\n", "").Length + 1;
                txtDet.Rows = (txtDet.Text.Length / 35) + countRes + 1;               
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                if (lblprjcode.Text == "14211")
                    e.Row.Cells[5].Text = "CXC COMMENTS";
            }
        }

        protected void mygrid_details_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _idx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mygrid_details.Rows[_idx];
            TableCell _dritmid = _srow.Cells[8];
            Session["id"] = _dritmid.Text;           
           
            if (e.CommandName == "resp")
            {
                txtresp.Text = (_srow.FindControl("txtResponse") as TextBox).Text;
                btnDummy_ModalPopupExtender1.Show();
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
            }
            else if (e.CommandName == "comm")
            {
                txtcomments.Text = (_srow.FindControl("txtComment") as TextBox).Text;
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ (string)Session["id"] + "');", true);
                btnDummy_ModalPopupExtender.Show();
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);

            }

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_id = 0;
            _objcls.details = "";
            _objcls.desc = "";
            _objcls.response = txtresp.Text;
            _objcls.issued_date = DateTime.Now;
            _objcls.uid = "";
            _objcls.dr_itm_id = Convert.ToInt32((string)Session["id"]);
            _objcls.mode = 0;
            _objbll.Document_Review_Details(_objcls, _objdb);
            load_doc_review_details(Convert.ToInt32(lblid.Text));
            Send_Mail();
            btnDummy_ModalPopupExtender1.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender1.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }
        void Send_Mail()
        {
            if (lblprjcode.Text == "OPH" || lblprjcode.Text == "PCD") return;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsuser _objcls1 = new _clsuser();
            _objcls1.project_code = lblprjcode.Text;
            string _prj = _objbll.Get_ProjectName(_objcls1, _objdb);
            publicCls.publicCls _objcls = new publicCls.publicCls();
            string Body = "";
            Body = "Ref. " + _prj + "/" + lbpkg.Text + "/" + lbldrno.Text + "\n\n" + "This is an automatically generated email to inform you that " + lbissued.Text + " responded the above document" + "\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";

            string _sub = "Document Review Response - Ref. " + _prj + "/" + lbpkg.Text + "/" + lbldrno.Text;
            _objcls.Send_Email(lbluid.Text, _sub, Body);
            //_objcls.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
        }

        protected void btnreissue_Click(object sender, EventArgs e)
        {
            load_users();
            btnDummy_ModalPopupExtender2.Show();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (drissuedto.SelectedItem.Text == "--Select User--") return;
            Update_DrIssue();
            Send_ReMail();
            btnDummy_ModalPopupExtender2.Hide();
            Response.Redirect("cmsdocreview.aspx?" + Request.QueryString.ToString());
        }
        private void Update_DrIssue()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsdocreview _objcls = new _clsdocreview();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _objcls.dr_id = Convert.ToInt32(lblid.Text);
            _objcls.issued_to = drissuedto.SelectedItem.Text;
            _objcls.issued_date = DateTime.Now;
            _objbll.Update_DrIssueTo(_objcls, _objdb);
        }
        void Send_ReMail()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();
            _objdb.DBName = "DBCML";
            _objcls.project_code = lblprjcode.Text;
            string ProjectName = _objbll.Get_ProjectName(_objcls, _objdb);
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _clscmsdocument _objcls1 = new _clscmsdocument();
            _objcls1.doc_name = "Document Review";
            int _period = _objbll.Get_ReviewPeriod(_objcls1, _objdb);
            publicCls.publicCls _obj = new publicCls.publicCls();
            string _Link = "https://cmltechniques.com/Default.aspx?Id=1P_" + lblprjcode.Text + "M_DR";
            string Body = "";
            Body = "Ref. " + ProjectName + "/" + lbpkg.Text + "/" + lbldrno.Text + "/" + lbdoc.Text + "\n\n" + "This is an automatically generated email to advise you that the above document has been issued to you." + "\n\n" + "Could you please find time to review the documents  and make comments within the next " + _period + " days" + "\n\n" + "If you review and have no comments on the document, please confirm with 'No comments' in the Response Column." + "\n\n\n" + "Using the link below will direct to the " + ProjectName + " Document Review Page,upon login to CML Techniques." + "\n\n" + "Document Link :" + _Link + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";

            string _sub = "Document Review - Ref. " + ProjectName + "/" + lbpkg.Text + "/" + lbldrno.Text + "/" + lbdoc.Text;
            _objdb.DBName = "DBCML";
            _objcls.uid = drissuedto.SelectedItem.Text;
            _objcls.project_code = lblprjcode.Text;
            if (_objbll.GetEmailNotify(_objcls, _objdb) == true)
                _obj.Send_Email(drissuedto.SelectedItem.Text, _sub, Body);
            //_objcls.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
            
        }
        protected void load_users()
        {
            drissuedto.Items.Clear();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprjcode.Text;
            _objcls.mode = 2;
            drissuedto.DataSource = _objbll.Load_CMS_Users(_objcls, _objdb);
            drissuedto.DataTextField = "uid";
            drissuedto.DataValueField = "uid";
            drissuedto.DataBind();
            drissuedto.Items.Insert(0, "--Select User--");

        }

        protected void btncancel1_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender2.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }

        protected void btnupdatedr_Click(object sender, EventArgs e)
        {
            Edit_Dr();
            load_doc_review_details(Convert.ToInt32(lblid.Text));
            btnDummy_ModalPopupExtender3.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }

        protected void btncancel_edit_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender3.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i <= mygrid_details.Rows.Count - 1; i++)
            {
                CheckBox checkbox = (CheckBox)mygrid_details.Rows[i].FindControl("chkselect");
                if (checkbox.Checked == true)
                {
                    count += 1;
                    lbldrdid.Text = mygrid_details.Rows[i].Cells[8].Text;
                }

            }
            if (count == 0) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');CallAutoSize();", true);
            else if (count > 1)
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select One Row');CallAutoSize();", true);
            else if (count == 1)
            {
                txt_doc.Text = lbdoc.Text;
                Load_Dr_Items();
                btnDummy_ModalPopupExtender3.Show();
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
            }
        }
        private void Load_Dr_Items()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsdocreview _objcls = new _clsdocreview();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _objcls.dr_id = Convert.ToInt32(lbldrdid.Text);
            DataTable _dt = _objbll.Load_Document_Review_Items(_objcls, _objdb);
            foreach (DataRow _drow in _dt.Rows)
            {
                txt_details.Text = _drow["details"].ToString();
                txt_descr.Text = _drow["description"].ToString();
            }
        }
        private void Edit_Dr()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsdocreview _objcls = new _clsdocreview();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _objcls.dr_id = Convert.ToInt32(lblid.Text);
            _objcls.dr_itm_id = Convert.ToInt32(lbldrdid.Text);
            _objcls.reviewed_by = txt_doc.Text;
            _objcls.details = txt_details.Text;
            _objcls.descr = txt_descr.Text;
            _objcls.mode = 1;
            _objbll.Edit_DR(_objcls, _objdb);
        }
        private void Delete_Dr_Item()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsdocreview _objcls = new _clsdocreview();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _objcls.dr_id = Convert.ToInt32(lblid.Text);
            _objcls.dr_itm_id = Convert.ToInt32(lbldrdid.Text);
            _objcls.reviewed_by = "";
            _objcls.details = "";
            _objcls.descr = "";
            _objcls.mode = 3;
            _objbll.Edit_DR(_objcls, _objdb);
        }
        private void Delete_Dr()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsdocreview _objcls = new _clsdocreview();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _objcls.dr_id = Convert.ToInt32(lblid.Text);
            _objcls.dr_itm_id = 0;
            _objcls.reviewed_by = "";
            _objcls.details = "";
            _objcls.descr = "";
            _objcls.mode =2;
            _objbll.Edit_DR(_objcls, _objdb);
        }
        protected void btndelete_itm_Click(object sender, EventArgs e)
        {
            Delete_Dr_Item();
            load_doc_review_details(Convert.ToInt32(lblid.Text));
            btnDummy_ModalPopupExtender3.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            Delete_Dr();
            Response.Redirect("cmsdocreview.aspx?" + Request.QueryString.ToString());
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("cmsdocreview.aspx?" + Request.QueryString.ToString());

        }
    }
}
