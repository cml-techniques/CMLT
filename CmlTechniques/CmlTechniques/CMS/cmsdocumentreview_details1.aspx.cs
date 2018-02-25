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
    public partial class cmsdocumentreview_details1 : System.Web.UI.Page
    {
        bool _photo = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                string _id = _prm.Substring(0, _prm.IndexOf("_P"));
                string _prj = _prm.Substring(_prm.IndexOf("_P") + 2);
                lblid.Text = _id;
                lblprjcode.Text = _prj;
                Load_DocReview_Info(Convert.ToInt32(_id));
                load_doc_review_details(Convert.ToInt32(_id));
                if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP" && (string)Session["uid"].ToString().ToLower() != lbluid.Text.ToLower())
                {
                    btnedit.Enabled = false;
                    btndelete.Enabled = false;
                    btn.Visible = false;
                    btnreissue.Enabled = false;
                }
                CheckPhoto();
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
        private void CheckPhoto()
        {
            if (_photo == false)
            {
                mygrid_details.Columns[4].Visible = false;
                //int colWidth = Int16.Parse(Server.HtmlEncode("25%"));
                //mygrid_details.Columns[5].ItemStyle.Width = colWidth;
                //mygrid_details.Columns[6].ItemStyle.Width = colWidth;
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
        private void Load_DocReview_Info(int dr_id)
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
            }

        }
        protected void mygrid_details_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((string)Session["uid"] != lblissued.Text)
                {
                    Button _btn = (Button)e.Row.FindControl("btnresp");
                    _btn.Enabled = false;
                }
                if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
                {
                    Button _btn = (Button)e.Row.FindControl("btncml");
                    _btn.Enabled = false;
                }
                Label _id = (Label)e.Row.FindControl("lblid");
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + (string)Session["project"];
                _clsdocreview _objcls = new _clsdocreview();
                _objcls.dr_id = Convert.ToInt32(_id.Text);
                GridView _myphoto = (GridView)e.Row.FindControl("myphoto");
                _myphoto.DataSource = _objbll.Load_DR_Image(_objcls, _objdb);
                _myphoto.DataBind();
                if (_myphoto.Rows.Count > 0)
                    _photo = true;
                e.Row.Cells[1].Text = (e.Row.RowIndex + 1).ToString();
                int count = 1;
                int count1 = 1;
                int ent1 = 0;
                int ent2 = 0;
                TextBox txt = (TextBox)e.Row.FindControl("txtdesc");
                TextBox txt1 = (TextBox)e.Row.FindControl("txtdetails");
                // if (txt1.Text.Length >= 30)
                //     count1 = (txt1.Text.Length / 30);
                // else
                //     count1 = 1;
                // if (txt.Text.Length >= 30)
                //     count = (txt.Text.Length / 30);
                // else
                //     count = 1;

                // if (count1 > count)
                //     count = count1;
                // else
                //     count1 = count;
                //txt.Height = Unit.Pixel(count * 30);
                // txt1.Height = Unit.Pixel(count1 * 30);
                foreach (Char chr in txt.Text)
                {
                    if (chr.ToString() == "\n")
                        ent1 += 1;
                }
                foreach (Char chr in txt1.Text)
                {
                    if (chr.ToString() == "\n")
                        ent2 += 1;
                }
                if (txt1.Text.Length >= 25)
                    count1 = (txt1.Text.Length / 25);

                if (txt.Text.Length >= 25)
                    count = (txt.Text.Length / 25);

                count += ent1;
                count1 += ent2;
                if (count1 > count)
                    count = count1;
                else
                    count1 = count;
                //txt.Height = Unit.Pixel(count * 30);
                //txt1.Height = Unit.Pixel(count1 * 30);
                txt.Rows = count + 2;
                txt1.Rows = count1 + 2;
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
                txtresp.Text = String.Empty;
                btnDummy_ModalPopupExtender1.Show();
            }
            else if (e.CommandName == "comm")
            {
                txtcomments.Text = String.Empty;
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ (string)Session["id"] + "');", true);
                btnDummy_ModalPopupExtender.Show();

            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string _prm = "DRAdd.aspx?id=1" + lblprjcode.Text + "_T" + lblid.Text;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _prm + "','','left=210,top=100,width=1110,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=0');", true);
            Response.Redirect(_prm);
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
            if (count == 0) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');", true);
            else if (count > 1)
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select One Row');", true);
            else if (count == 1)
            {
                txt_doc.Text = lbdoc.Text;
                Load_Dr_Items();
                btnDummy_ModalPopupExtender3.Show();
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
            _objcls.mode = 2;
            _objbll.Edit_DR(_objcls, _objdb);
        }
        protected void btndelete_itm_Click(object sender, EventArgs e)
        {
            Delete_Dr_Item();
            load_doc_review_details(Convert.ToInt32(lblid.Text));
            btnDummy_ModalPopupExtender3.Hide();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            Delete_Dr();
            Response.Redirect("cmsdocreview.aspx?PRJ=" + lblprjcode.Text);
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
        protected void btnreissue_Click(object sender, EventArgs e)
        {
            load_users();
            btnDummy_ModalPopupExtender2.Show();
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            string _prm = "Reports.aspx?id=dr" + lblid.Text + "&idx=0&prj=" + lblprjcode.Text;
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _prm + "','','left=210,top=100,width=1110,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=0');", true);
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
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender.Hide();
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
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender1.Hide();
        }
        void Send_Mail()
        {
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
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (drissuedto.SelectedItem.Text == "--Select User--") return;
            Update_DrIssue();
            Send_ReMail();
            btnDummy_ModalPopupExtender2.Hide();
            Response.Redirect("cmsdocreview.aspx?PRJ=" + lblprjcode.Text);
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
            Body = "Ref. " + ProjectName + "/" + lbpkg.Text + "/" + lbldrno.Text + "/" + lbdoc.Text + "\n\n" + "This is an automatically generated email to advise you that the above document has been issued to you." + "\n\n" + "Could you please find time to review the documents  and make comments within the next " + _period + " days" + "\n\n" + "If you review and have no comments on the document, please confirm with 'No comments' in the Response Column." + "\n\n\n" + "Using the link below will direct to the " + ProjectName + " Document Review Page,upon login to CML Techniques." + "\n\n" + "Document Link :" + _Link + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "http://www.cmldubai.com";

            string _sub = "Document Review - Ref. " + ProjectName + "/" + lbpkg.Text + "/" + lbldrno.Text + "/" + lbdoc.Text;
            _obj.Send_Email(drissuedto.SelectedItem.Text, _sub, Body);
            //_objcls.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);

        }
        protected void btncancel1_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender2.Hide();
        }

        protected void btnupdatedr_Click(object sender, EventArgs e)
        {
            Edit_Dr();
            load_doc_review_details(Convert.ToInt32(lblid.Text));
            btnDummy_ModalPopupExtender3.Hide();
        }

        protected void btncancel_edit_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender3.Hide();
        }
    }
}
