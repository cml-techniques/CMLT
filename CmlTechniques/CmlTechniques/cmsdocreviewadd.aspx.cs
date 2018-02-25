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
    public partial class cmsdocreviewadd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                lblid.Text = Request.QueryString["id"].ToString();
                lblprj.Text = Request.QueryString["Prj"].ToString();
                if (_prm.Substring(0, 1) == "1") Setting(1);
                else Setting(0);
                comment_basket _objbasket = new comment_basket();
                _objbasket.clear();
                if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                {
                    Get_ProjectName();
                }
                else
                {
                    dvfixedhead.Visible = false;
                    dvfixedcontent.Style.Add("Top", "0px");
                }
                trBuilding.Visible = (lblprj.Text == "HMIM" || lblprj.Text == "HMHS" || lblprj.Text == "AZC" || lblprj.Text == "123" || lblprj.Text == "demo") ? true : false;
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
        private void Setting(int type)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();
            _objdb.DBName = "DBCML";
            _objcls.project_code = lblprj.Text;
            string ProjectName = _objbll.Get_ProjectName(_objcls, _objdb);
            lbltitle.Text = ProjectName + " - Document Review Creation";
            if (type == 0)
            {
                lblpackage.Text = (string)Session["service"];
                lblsubject.Text = (string)Session["doc"];
                lblrecordby.Text = (string)Session["uid"];
                lblsubmitted.Text = (string)Session["issued"];
                lblBuilding.Text = (string)Session["bui"];
                lblissuedto.Text = lblsubmitted.Text;

            }
            else
            {
                Load_DocReview_Info();
                Session["service"] = lblpackage.Text;
                Session["doc"] = lblsubject.Text;
            }
        }
        private void Load_DocReview_Info()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_id = Convert.ToInt32(lblid.Text);
            DataTable _dt = _objbll.Load_Document_Review_INFO(_objcls, _objdb);
            foreach (DataRow _drow in _dt.Rows)
            {
                lblpackage.Text = _drow["service"].ToString();
                lblrecordby.Text = _drow["userid"].ToString();
                lbldrno.Text = _drow["dr_no"].ToString();
                lblsubmitted.Text = _drow["issued"].ToString();
                lbldrno.Text = _drow["dr_no"].ToString();
                lblsubject.Text = _drow["dr_reviewed"].ToString();
                lblsrvid.Text = _drow["srv_id"].ToString();
                lblissuedto.Text = _drow["issued_to"].ToString();
                lblBuilding.Text = _drow["building"].ToString();

                txtnote.Text = _drow["Note"].ToString();
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
                if (Request.Cookies["service"] != null)
                {
                    Session["service"] = Server.HtmlEncode(Request.Cookies["service"].Value);
                }

            }
        }
        protected void load_doc_review_details()
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ (string)Session["dr_id"] +"');", true);
            //Session["dr_id1"] = (string)Session["dr_id"];
            //Session["dr_no1"] = (string)Session["dr_no"];
            //lbldrno.Text = (string)Session["dr_no1"];

        }
        protected void btnaddtr_Click(object sender, EventArgs e)
        {
            //comment_basket _objbasket = new comment_basket();
            //_objbasket.Insert(txtdetails.Text, txtdesc.Text);
            //myschedule_basket.DataBind();
            Add_ToTemp();
            Load_DRTemp();
            txtdetails.Text = String.Empty;
            txtdesc.Text = String.Empty;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + txtdesc.Text.Length.ToString() + "');", true);
        }
        private void Add_ToTemp()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.details = txtdetails.Text;
            _objcls.descr = txtdesc.Text;
            _objcls.uid = lblrecordby.Text;
            _objcls.dr_reviewed = lblsubject.Text;
            _objcls.service = lblpackage.Text;
            if (trBuilding.Visible)
                _objcls.building = Convert.ToInt32(Session["buildingid"]);
            _objbll.Insert_DRTemp(_objcls, _objdb);
        }
        private void Load_DRTemp()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.uid = lblrecordby.Text;
            _objcls.dr_reviewed = lblsubject.Text;
            _objcls.service = lblpackage.Text;
            myschedule_basket.DataSource = _objbll.Load_DRTemp(_objcls, _objdb);
            myschedule_basket.DataBind();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (myschedule_basket.Rows.Count <= 0) return;
            //Insert_Doc_review_log();
            //Insert_Doc_review_details();
            load_users();
            btnDummy_ModalPopupExtender.Show();
        }
        private void Delete_DrTemp()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.uid = lblrecordby.Text;
            _objcls.dr_reviewed = lblsubject.Text;
            _objcls.service = lblpackage.Text;
            _objbll.Delete_DRTemp(_objcls, _objdb);
        }
        //private void Load_users_CC()
        //{
        //    chkuser.Items.Clear();
        //    for (int i = 0; i <= drissuedto.Items.Count - 1; i++)
        //    {
        //        if (drissuedto.Items[i].Text != drissuedto.SelectedItem.Text && drissuedto.Items[i].Text != "--Select User--")
        //        {
        //            ListItem lst = new ListItem();
        //            lst.Text = drissuedto.Items[i].Text;
        //            lst.Value = drissuedto.Items[i].Value;
        //            chkuser.Items.Add(lst);
        //        }

        //    }
        //}
        protected void load_users()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            _objcls.mode = 2;
            chkuser.DataSource = _objbll.Load_CMS_Users_Email(_objcls, _objdb);
            chkuser.DataTextField = "uid";
            chkuser.DataValueField = "uid";
            chkuser.DataBind();
        }
        protected void Insert_Doc_review_log()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_reviewed = lblsubject.Text;
            _objcls.issued_date = DateTime.Now;
            _objcls.issued_to = lblissuedto.Text;
            _objcls.dr_status = true;//open
            _objcls.project_code = lblprj.Text;
            _objcls.uid = lblrecordby.Text;
            _objcls.mode = 1;
            _objcls.service = lblpackage.Text;
            _objcls.Notes = txtnote.Text;
            _objcls.closeout_date = "";
            if (trBuilding.Visible)
                _objcls.building = Convert.ToInt32(Session["buildingid"]);
            lbldrno.Text = _objbll.Document_Review_Log(_objcls, _objdb);
        }
        protected void Insert_Doc_review_details()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_id = 0;
            _objcls.response = "";
            _objcls.issued_date = DateTime.Now;
            _objcls.uid = lblrecordby.Text;
            _objcls.dr_itm_id = 0;
            _objcls.mode = 1;
            for (int i = 0; i <= myschedule_basket.Rows.Count - 1; i++)
            {
                TextBox _details = (TextBox)myschedule_basket.Rows[i].FindControl("txtdetails");
                TextBox _desc = (TextBox)myschedule_basket.Rows[i].FindControl("txtdesc");
                _objcls.details = _details.Text;
                _objcls.desc = _desc.Text;
                _objbll.Document_Review_Details(_objcls, _objdb);
            }
        }
        protected void Add_Doc_review_details()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_id = Convert.ToInt32(lblid.Text);
            _objcls.response = "";
            _objcls.issued_date = DateTime.Now;
            _objcls.uid = lblrecordby.Text;
            _objcls.dr_itm_id = 0;
            _objcls.mode = 3;
            for (int i = 0; i <= myschedule_basket.Rows.Count - 1; i++)
            {
                TextBox _details = (TextBox)myschedule_basket.Rows[i].FindControl("txtdetails");
                TextBox _desc = (TextBox)myschedule_basket.Rows[i].FindControl("txtdesc");
                _objcls.details = _details.Text;
                _objcls.desc = _desc.Text;
                _objbll.Document_Review_Details(_objcls, _objdb);
            }
        }
        void Update_DRNotes()
        {

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_reviewed = "";
            _objcls.issued_date = DateTime.Now;
            _objcls.issued_to = "";
            _objcls.project_code = "";
            _objcls.uid = "";
            _objcls.mode = 2;
            _objcls.dr_id = Convert.ToInt32(lblid.Text);
            _objcls.service = "";
            _objcls.Notes = txtnote.Text;
            _objcls.dr_status = true;
            _objcls.closeout_date = "";
            string id = _objbll.Document_Review_Log(_objcls, _objdb);
        }
        protected void btnCont_Click(object sender, EventArgs e)
        {
            if (lblid.Text == "0")
            {
                Insert_Doc_review_log();
                Insert_Doc_review_details();
            }
            else
            {
                Update_DRNotes();
                Add_Doc_review_details();
            }
            Delete_DrTemp();
            Send_Mail();
            btnDummy_ModalPopupExtender.Hide();
            Response.Redirect("CMS/cmsdocreview.aspx?" + Request.QueryString.ToString());
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.close();", true);
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender.Hide();
        }
        void Send_Mail()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();
            _objdb.DBName = "DBCML";
            _objcls.project_code = lblprj.Text;
            string ProjectName = _objbll.Get_ProjectName(_objcls, _objdb);
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscmsdocument _objcls1 = new _clscmsdocument();
            _objcls1.doc_name = "Document Review";

            int _period = _objbll.Get_ReviewPeriod(_objcls1, _objdb);
            publicCls.publicCls _obj = new publicCls.publicCls();
            string _Link = "https://cmltechniques.com/Default.aspx?Id=1P_" + (string)Session["project"] + "M_DR";
            string Body = "";
            Body = "Ref. " + ProjectName + "/" + (string)Session["service"] + "/" + lbldrno.Text + "/" + (string)Session["doc"] + "\n\n" + "This is an automatically generated email to advise you that the above document has been issued to you." + "\n\n" + "Could you please find time to review the documents  and make comments within the next " + _period + " days" + "\n\n" + "If you review and have no comments on the document, please confirm with 'No comments' in the Response Column." + "\n\n\n" + "Using the link below will direct to the " + ProjectName + " Document Review Page,upon login to CML Techniques." + "\n\n" + "Document Link :" + _Link + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";

            string _sub = "Document Review - Ref. " + ProjectName + "/" + (string)Session["service"] + "/" + lbldrno.Text + "/" + (string)Session["doc"];
            _objdb.DBName = "DBCML";
            _objcls.uid = lblissuedto.Text;
            _objcls.project_code = lblprj.Text;
            if (_objbll.GetEmailNotify(_objcls, _objdb) == true)
                _obj.Send_Email(lblissuedto.Text, _sub, Body);
            //_objcls.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
            Body = "Ref. " + ProjectName + "/" + (string)Session["service"] + "/" + lbldrno.Text + "/" + (string)Session["doc"] + "\n\n" + "This is an automatically generated email to advise you that the above document has been issued to " + lblissuedto.Text + "\n\n\n" + "Using the link below will direct to the " + ProjectName + " Document Review Page,upon login to CML Techniques." + "\n\n" + "Document Link :" + _Link + "\n\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";

            for (int i = 0; i <= chkuser.Items.Count - 1; i++)
            {
                if (chkuser.Items[i].Selected == true)
                    _obj.Send_Email(chkuser.Items[i].Text, _sub, Body);
            }
            //_objcls.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Delete_DrTemp();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.close();", true);
            Response.Redirect("CMS/cmsdocreview.aspx?" + Request.QueryString.ToString());
        }

        protected void myschedule_basket_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // txt = CType(e.Row.FindControl("TextBox2"), TextBox) 
            //For Each chr As Char In txt.Text 
            //    txtValue = Strings.Asc(chr) 
            //    txtValue = Conversion.Hex(txtValue) 
            //    If txtValue = "D" And e.Row.Cells(1).Text <> "SERVO" Then 
            //        carraigeReturns = carraigeReturns + 1 
            //    ElseIf e.Row.Cells(1).Text = "SERVO" Then 
            //        txt.Height = 100 
            //        skip = True 
            //    End If 
            //    If skip = False Then txt.Height = carraigeReturns * 25 
            //Next 
            e.Row.Cells[4].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //int count=1;
                //int count1 = 1;
                //TextBox txt = (TextBox)e.Row.FindControl("txtdesc");
                //TextBox txt1 = (TextBox)e.Row.FindControl("txtdetails");
                //foreach (Char chr in txt.Text)
                //{
                //    if (chr.ToString() == "\n")
                //        count += 1;
                //}
                //foreach (Char chr in txt1.Text)
                //{
                //    if (chr.ToString() == "\n")
                //        count1 += 1;
                //}
                //if (count == 1)
                //    count = (txt.Text.Length / 30);
                //if (count1 == 1)
                //    count1 = (txt1.Text.Length / 30);
                //txt.Height = (count * 25);
                //txt1.Height = (count1 * 25);
                int count = 1;
                int count1 = 1;
                int ent1 = 0;
                int ent2 = 0;
                TextBox txt = (TextBox)e.Row.FindControl("txtdesc");
                TextBox txt1 = (TextBox)e.Row.FindControl("txtdetails");
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
                if (txt1.Text.Length >= 45)
                    count1 = (txt1.Text.Length / 45);

                if (txt.Text.Length >= 45)
                    count = (txt.Text.Length / 45);

                count += ent1;
                count1 += ent2;
                if (count1 > count)
                    count = count1;
                else
                    count1 = count;
                //txt.Height = Unit.Pixel(count * 30);
                //txt1.Height = Unit.Pixel(count1 * 30);
                txt.Rows = count + 1;
                txt1.Rows = count1 + 1;
                e.Row.Cells[1].Text = (e.Row.RowIndex + 1).ToString();
            }

        }

        protected void myschedule_basket_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = myschedule_basket.Rows[_rowidx];
            TableCell _id = _srow.Cells[4];
            if (e.CommandName == "remove")
            {
                Remove_DrTemp(Convert.ToInt32(_id.Text));
                Load_DRTemp();
            }
        }
        private void Remove_DrTemp(int id)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_id = id;
            _objbll.Remove_DRTemp(_objcls, _objdb);
        }

    }
}
