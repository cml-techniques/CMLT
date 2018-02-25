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
using System.IO;
namespace CmlTechniques.CMS
{
    public partial class cmsdocreview1 : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtresult;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString["PRJ"].ToString();
                lblprj.Text = _prm;
                Session["ModuleAccess"] = "0";

                if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
                {
                    btnadd.Enabled = false;

                    if (lblprj.Text == "ABS")
                    {
                        publicCls.publicCls _obj = new publicCls.publicCls();
                        if (_obj.Load_User_Module_Permission(lblprj.Text, (string)Session["uid"], 3)) { btnadd.Enabled = true; Session["ModuleAccess"] = "1"; }
                    }
                }


                load_users(lblprj.Text);
                load_services(lblprj.Text);
                load_doc_review_log(lblprj.Text);
                Load_DocReview();
                Load_Filtering_Elements();
                Session["ser"] = "";
                Session["rew"] = "";
                Session["iss"] = "";
                Session["sta"] = "";
               

               
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

            }
        }
        protected void load_users(string Project)
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "dbCML";
            //_clsuser _objcls = new _clsuser();
            //_objcls.project_code = Project;
            //_objcls.mode = 2;
            //drissuedto.DataSource = _objbll.Load_CMS_Users(_objcls, _objdb);
            //drissuedto.DataTextField = "uid";
            //drissuedto.DataValueField = "uid";
            //drissuedto.DataBind();
            //drissuedto.Items.Insert(0, "--Select User--");

        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            lblmode.Text = "0";
            lblfile.Text = "";
            btnupload.Text = "Upload";
            btndummy_ModalPopupExtender.Show();
        }
        protected void load_services(string Project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + Project;
            drservice.DataSource = _objbll.Load_Cas_service(_objdb);
            drservice.DataTextField = "PRJ_SER_NAME";
            drservice.DataValueField = "SYS_SER_ID";
            drservice.DataBind();
            int count = drservice.Items.Count;
        }
        protected void Insert_Doc_review_log()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DB_" + lblprj.Text;
            //_clsdocreview _objcls = new _clsdocreview();
            //_objcls.dr_reviewed = txtreviewed.Text;
            //_objcls.issued_date = DateTime.Now;
            //_objcls.issued_to = drissuedto.SelectedItem.Text;
            //_objcls.dr_status = true;//open
            //_objcls.project_code = lblprj.Text;
            //_objcls.uid = (string)Session["uid"];
            //_objcls.mode = 1;
            //_objcls.service = drservice.SelectedItem.Text;
            //_objbll.Document_Review_Log(_objcls, _objdb);
            //load_doc_review_log(lblprj.Text);
            //Load_DocReview();
        }
        private void load_doc_review_log(string Project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + Project;
            _clsuser _objcls = new _clsuser();
            _dtMaster = _objbll.Load_dr_pdf(_objdb);
            _dtresult = _dtMaster;

        }
        private void Load_Filtering_Elements()
        {
            var _service = (from DataRow dRow in _dtMaster.Rows
                            orderby dRow["service"]
                            select new { col1 = dRow["service"] }).Distinct();
            foreach (var row in _service)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                dr_service.Items.Add(_itm);
            }
            dr_service.DataBind();
            var _reviewed = (from DataRow dRow in _dtMaster.Rows
                             orderby dRow["created_By"]
                             select new { col1 = dRow["created_By"] }).Distinct();
            foreach (var row in _reviewed)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drreview.Items.Add(_itm);
            }
            drreview.DataBind();
            var _issued = (from DataRow dRow in _dtMaster.Rows
                           orderby dRow["Issue_To"]
                           select new { col1 = dRow["Issue_To"] }).Distinct();
            foreach (var row in _issued)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drissue.Items.Add(_itm);
            }
            drissue.DataBind();
            dr_service.Items.Insert(0, "All");
            drreview.Items.Insert(0, "All");
            drissue.Items.Insert(0, "All");
            dr_service.SelectedValue = (string)Session["ser"];
            drreview.SelectedValue = (string)Session["rew"];
            drissue.SelectedValue = (string)Session["iss"];
            drstatus.SelectedValue = (string)Session["sta"];
        }
        private void Load_DocReview()
        {
            //myview.DataSource = _dtresult;
            //myview.DataBind();
            mygrid_dr.DataSource = _dtresult;
            mygrid_dr.DataBind();
        }

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[8].Visible = false;
        }

        protected void mygrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int _rowidx = Convert.ToInt32(e.CommandArgument);
            //GridViewRow _srow = mygrid.Rows[_rowidx];
            //TableCell _id = _srow.Cells[9];
            //TableCell _no = _srow.Cells[0];
            //Session["dr_id"] = _id.Text;
            //Session["dr_no"] = _no.Text;
            //lbldrno.Text = _no.Text;
            //mydiv.Visible = true;
            //load_doc_review_details();
            // ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('','sub');", true);
        }

        protected void btnaddtr_Click(object sender, EventArgs e)
        {
            Insert_Doc_review_details();
        }
        protected void Insert_Doc_review_details()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_clsdocreview _objcls = new _clsdocreview();
            //_objcls.dr_id = Convert.ToInt32((string)Session["dr_id"]);
            //_objcls.details = txtdetails.Text;
            //_objcls.response = "";
            //_objcls.issued_date = DateTime.Now;
            //_objcls.uid = (string)Session["uid"];
            //_objcls.dr_itm_id = 0;
            //_objcls.mode = 1;
            //_objbll.Document_Review_Details(_objcls);
            //load_doc_review_details();
        }
        protected void load_doc_review_details()
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ (string)Session["dr_id"] +"');", true);

            //BLL_Dml _objbll = new BLL_Dml();
            //_clsdocreview _objcls = new _clsdocreview();
            //_objcls.dr_id = Convert.ToInt32((string)Session["dr_id"]);
            ////mygrid1.DataSource = _objbll.Load_Document_Review_Details(_objcls);
            ////mygrid1.DataBind();
            //mydetailsview.DataSource = _objbll.Load_Document_Review_Details(_objcls);
            //mydetailsview.DataBind();
            //lbldrno.Text = (string)Session["dr_no"];
        }

        protected void mygrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells[0].Text == "")
            {
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
            }
        }
        protected void Load_users_CC()
        {
            //chkuser.Items.Clear();
            //for (int i = 0; i <= drissuedto.Items.Count - 1; i++)
            //{
            //    if (drissuedto.Items[i].Text != drissuedto.SelectedItem.Text && drissuedto.Items[i].Text != "--Select User--")
            //    {
            //        ListItem lst = new ListItem();
            //        lst.Text = drissuedto.Items[i].Text;
            //        lst.Value = drissuedto.Items[i].Value;
            //        chkuser.Items.Add(lst);
            //    }

            //}
        }
        protected void myview_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            //myview.EditIndex = e.NewEditIndex;
            //load_doc_review_log();
            //set_status();
        }

        protected void myview_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            // myview.EditIndex = -1; 
            //load_doc_review_log();
        }
        void _Create_Cookies()
        {
            if (Request.Browser.Cookies)
            {
                HttpCookie _CookieIssued = new HttpCookie("issued");
                _CookieIssued.Value = (string)Session["issued"];
                _CookieIssued.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_CookieIssued);
                HttpCookie _Cookiesrv = new HttpCookie("service");
                _Cookiesrv.Value = (string)Session["service"];
                _Cookiesrv.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_Cookiesrv);
            }
            else
                return;
        }
        protected void myview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                Button _btn = (Button)e.Item.FindControl("btndr_no");
                Label _lbl = (Label)e.Item.FindControl("dr_idLabel");
                Label _lblcr = (Label)e.Item.FindControl("uidLabel");
                Label _lblis = (Label)e.Item.FindControl("issued_toLabel");
                Label _lblsrv = (Label)e.Item.FindControl("lbsrv");
                Label _lbldoc = (Label)e.Item.FindControl("dr_reviewedLabel");
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ _btn.Text +"');", true);
                //Session["dr_id"] = _lbl.Text;
                //Session["dr_no"] = _btn.Text;
                Session["created"] = _lblcr.Text;
                //Session["issued"] = _lblis.Text;
                //Session["service"] = _lblsrv.Text;
                //Session["doc"] = _lbldoc.Text;
                _Create_Cookies();
                string _prm = "";
                if (lblprj.Text == "HPOB")
                    _prm = "cmsdocreview_details1.aspx?id=" + _lbl.Text + "_P" + lblprj.Text;
                else
                    _prm = "cmsdocreview_details.aspx?id=" + _lbl.Text + "_P" + lblprj.Text;
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open(''" + _prm + "' ,'','left=50,top=50,width=1300,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
                Response.Redirect(_prm);
            }
            else if (e.CommandName == "Update")
            {
                Label _id = (Label)e.Item.FindControl("dr_idLabel");
                DropDownList _drs = (DropDownList)e.Item.FindControl("drstatus");
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clsdocreview _objcls = new _clsdocreview();
                _objcls.dr_reviewed = "";
                _objcls.issued_date = DateTime.Now;
                _objcls.issued_to = "";
                _objcls.project_code = "";
                _objcls.uid = "";
                _objcls.mode = 0;
                _objcls.dr_id = Convert.ToInt32(_id.Text);
                _objcls.service = "";
                if (_drs.SelectedItem.Text == "OPEN")
                    _objcls.dr_status = true;
                else
                    _objcls.dr_status = false;
                _objbll.Document_Review_Log(_objcls, _objdb);
            }
        }
        protected void myview_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }
        protected void btnCont_Click(object sender, EventArgs e)
        {
            ////ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('yes');", true);
            //Insert_Doc_review_log();

            //int _max = mygrid_dr.Rows.Count - 1;
            ////Session["dr_id"] = mygrid.Rows[_max].Cells[8].Text;
            ////Label _lbl = (Label)myview.Items[_max].FindControl("dr_idLabel");
            ////Button _btn = (Button)myview.Items[_max].FindControl("btndr_no");
            //Session["dr_id"] = mygrid_dr.Rows[_max].Cells[12].Text;
            //Session["dr_no"] = mygrid_dr.Rows[_max].Cells[11].Text;

            ////Send_Mail();
            //btnDummy_ModalPopupExtender.Hide();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('../cmsdocreviewadd.aspx','','left=210,top=100,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            //btnDummy_ModalPopupExtender.Hide();
        }


        protected void set_status()
        {
            //DropDownList _drs = (DropDownList)myview.EditItem.FindControl("drstatus");
            //_drs.Items.Add("OPEN");
            //_drs.Items.Add("CLOSE");
            //Label _st = (Label)myview.EditItem.FindControl("dr_statusLabel");
            //if (_st.Text == "OPEN")
            //    _drs.Items[0].Selected = true;
            //else
            //    _drs.Items[1].Selected = true;
        }
        protected void myview_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            //myview.EditIndex = -1;
            //load_doc_review_log();
        }

        protected void myview_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label _st = (Label)e.Item.FindControl("dr_statusLabel");
            Label _isdate = (Label)e.Item.FindControl("lbdate");
            Label _due = (Label)e.Item.FindControl("lbdue");
            if (_st.Text == "True")
                _st.Text = "OPEN";
            else
                _st.Text = "CLOSE";
            if (_st.Text == "OPEN")
            {
                int due = 15;
                if (_isdate.Text != "")
                {
                    TimeSpan _days = DateTime.Now.Subtract(Convert.ToDateTime(_isdate.Text));
                    due = 15 - _days.Days;
                    //_due.Text = due.ToString();
                }
                if (due < 0)
                {
                    due *= -1;
                    Change_RowClr(e);
                    _due.Text = due.ToString();
                }
            }
            Button _edit = (Button)e.Item.FindControl("EditButton");
            if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
            {
            _edit.Visible = false;
                if (lblprj.Text == "ABS") { if (Session["ModuleAccess"].ToString() == "1") _edit.Visible = true; }
            }
                
        }
        private void Change_RowClr(ListViewItemEventArgs e)
        {
            //Button _drno = (Button)e.Item.FindControl("btndr_no");
            //Label _serv = (Label)e.Item.FindControl("lbsrv");
            //Label _rew = (Label)e.Item.FindControl("dr_reviewedLabel");
            //Label _isd = (Label)e.Item.FindControl("issue_dateLabel");
            //Label _uid = (Label)e.Item.FindControl("uidLabel");
            //Label _iss = (Label)e.Item.FindControl("issued_toLabel");
            //Label _com = (Label)e.Item.FindControl("commentsLabel");
            //Label _res = (Label)e.Item.FindControl("responseLabel");
            //Label _sts = (Label)e.Item.FindControl("dr_statusLabel");
            //Label _due = (Label)e.Item.FindControl("lbdue");
            //_drno.ForeColor = System.Drawing.Color.Red;
            //_serv.ForeColor = System.Drawing.Color.Red;
            //_rew.ForeColor = System.Drawing.Color.Red;
            //_isd.ForeColor = System.Drawing.Color.Red;
            //_uid.ForeColor = System.Drawing.Color.Red;
            //_iss.ForeColor = System.Drawing.Color.Red;
            //_com.ForeColor = System.Drawing.Color.Red;
            //_res.ForeColor = System.Drawing.Color.Red;
            //_sts.ForeColor = System.Drawing.Color.Red;
            //_due.ForeColor = System.Drawing.Color.Red;
            HtmlTableRow _tr = (HtmlTableRow)e.Item.FindControl("itm_tr");
            _tr.Style.Add("color", "Red");

        }

        void Send_Mail()
        {
            //publicCls.publicCls _objcls = new publicCls.publicCls();
            //string Body = "";
            //Body = "Ref. " + (string)Session["projectname"] + "/" + drservice.SelectedItem.Text + "/" + (string)Session["dr_no"] + "/" + txtreviewed.Text + "\n\n" + "This is an automatically generated email to advise you that the above document has been issued to you." + "\n\n" + "Could you please find time to review the documents  and make comments within the next 15 days" + "\n\n" + "If you review and have no comments on the document, please confirm with 'No comments' in the Response Column." + "\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "http://www.cmltechniques.com";

            //string _sub = "Document Review - Ref. " + (string)Session["projectname"] + "/" + drservice.SelectedItem.Text + "/" + (string)Session["dr_no"] + "/" + txtreviewed.Text;
            //_objcls.Send_Email(drissuedto.SelectedItem.Text, _sub, Body);
            ////_objcls.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
            //Body = "Ref. " + (string)Session["projectname"] + "/" + drservice.SelectedItem.Text + "/" + (string)Session["dr_no"] + "/" + txtreviewed.Text + "\n\n" + "This is an automatically generated email to advise you that the above document has been issued to " + drissuedto.SelectedItem.Text + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "http://www.cmltechniques.com";

            //for (int i = 0; i <= chkuser.Items.Count - 1; i++)
            //{
            //    if (chkuser.Items[i].Selected == true)
            //        _objcls.Send_Email(chkuser.Items[i].Text, _sub, Body);
            //}
            // _objcls.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
        }
        private void Filtering(string _el1, string _el2, string _el3, string _el4)
        {
            if (_el1 == "") _el1 = "All";

            if (_el2 == "") _el2 = "All";

            if (_el3 == "") _el3 = "All";

            if (_el4 == "") _el4 = "All";

            //bool _status;

            //if (_el4 == "OPEN")

            //    _status = true;

            //else if (_el4 == "CLOSED")

            //    _status = false;

            load_doc_review_log(lblprj.Text);

            DataTable _dtfilter = _dtMaster;

            _dtresult = new DataTable();

            _dtresult.Columns.Add("dr_no", typeof(string));

            _dtresult.Columns.Add("dr_id", typeof(string));

            _dtresult.Columns.Add("service", typeof(string));

            _dtresult.Columns.Add("Subject", typeof(string));

            _dtresult.Columns.Add("created_By", typeof(string));

            _dtresult.Columns.Add("issue_date", typeof(string));

            _dtresult.Columns.Add("Issue_To", typeof(string));

            _dtresult.Columns.Add("comments", typeof(string));

            _dtresult.Columns.Add("response", typeof(string));

            _dtresult.Columns.Add("status", typeof(string));

            _dtresult.Columns.Add("File_Name", typeof(string));

            var _filter = from o in _dtfilter.AsEnumerable()

                          select o;

            if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All")
            {

                _filter = from o in _dtfilter.AsEnumerable()

                          select o;

            }

            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All")
            {

                _filter = from o in _dtfilter.AsEnumerable()

                          where o.Field<string>("service") == _el1

                          select o;

            }

            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All")
            {

                _filter = from o in _dtfilter.AsEnumerable()

                          where o.Field<string>("service") == _el1 && o.Field<string>("created_By") == _el2

                          select o;

            }

            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 == "All")
            {

                _filter = from o in _dtfilter.AsEnumerable()

                          where o.Field<string>("service") == _el1 && o.Field<string>("created_By") == _el2 && o.Field<string>("Issue_To") == _el3

                          select o;

            }

            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All")
            {

                _filter = from o in _dtfilter.AsEnumerable()

                          where o.Field<string>("service") == _el1 && o.Field<string>("created_By") == _el2 && o.Field<string>("Issue_To") == _el3 && o.Field<string>("status") == _el4

                          select o;

            }

            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All")
            {

                _filter = from o in _dtfilter.AsEnumerable()

                          where o.Field<string>("created_By") == _el2

                          select o;

            }

            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 == "All")
            {

                _filter = from o in _dtfilter.AsEnumerable()

                          where o.Field<string>("created_By") == _el2 && o.Field<string>("Issue_To") == _el3

                          select o;

            }

            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All")
            {

                _filter = from o in _dtfilter.AsEnumerable()

                          where o.Field<string>("created_By") == _el2 && o.Field<string>("Issue_To") == _el3 && o.Field<string>("status") == _el4

                          select o;

            }

            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All")
            {

                _filter = from o in _dtfilter.AsEnumerable()

                          where o.Field<string>("Issue_To") == _el3

                          select o;

            }

            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All")
            {

                _filter = from o in _dtfilter.AsEnumerable()

                          where o.Field<string>("Issue_To") == _el3 && o.Field<string>("status") == _el4

                          select o;

            }

            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All")
            {

                _filter = from o in _dtfilter.AsEnumerable()

                          where o.Field<string>("status") == _el4

                          select o;

            }

            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 == "All")
            {

                _filter = from o in _dtfilter.AsEnumerable()

                          where o.Field<string>("service") == _el1 && o.Field<string>("Issue_To") == _el3

                          select o;

            }

            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All")
            {

                _filter = from o in _dtfilter.AsEnumerable()

                          where o.Field<string>("service") == _el1 && o.Field<string>("Issue_To") == _el3 && o.Field<string>("status") == _el4

                          select o;

            }

            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All")
            {

                _filter = from o in _dtfilter.AsEnumerable()

                          where o.Field<string>("service") == _el1 && o.Field<string>("status") == _el4

                          select o;

            }

            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All")
            {

                _filter = from o in _dtfilter.AsEnumerable()

                          where o.Field<string>("created_By") == _el2 && o.Field<string>("status") == _el4

                          select o;

            }

            foreach (var row in _filter)
            {

                DataRow _row = _dtresult.NewRow();

                _row[0] = row["dr_no"].ToString();

                _row[1] = row["dr_id"].ToString();

                _row[2] = row["service"].ToString();

                _row[3] = row["Subject"].ToString();

                _row[4] = row["created_By"].ToString();

                _row[5] = row["issue_date"].ToString();

                _row[6] = row["Issue_To"].ToString();

                _row[7] = row["comments"].ToString();

                _row[8] = row["response"].ToString();

                _row[9] = row["status"].ToString();

                _row[10] = row["File_Name"].ToString();

                _dtresult.Rows.Add(_row);

            }

            //m.DataSource = _dtresult;

            //mygrid.DataBind();

            Load_DocReview();


        }
        protected void dr_service_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ser"] = dr_service.SelectedItem.Value;
            Filtering(dr_service.SelectedItem.Text, drreview.SelectedItem.Text, drissue.SelectedItem.Text, drstatus.SelectedItem.Text);
        }
        protected void drreview_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["rew"] = drreview.SelectedItem.Value;
            Filtering(dr_service.SelectedItem.Text, drreview.SelectedItem.Text, drissue.SelectedItem.Text, drstatus.SelectedItem.Text);
        }
        protected void drissue_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["iss"] = drissue.SelectedItem.Value;
            Filtering(dr_service.SelectedItem.Text, drreview.SelectedItem.Text, drissue.SelectedItem.Text, drstatus.SelectedItem.Text);
        }
        protected void drstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["sta"] = drstatus.SelectedItem.Value;
            Filtering(dr_service.SelectedItem.Text, drreview.SelectedItem.Text, drissue.SelectedItem.Text, drstatus.SelectedItem.Text);
        }

        protected void mygrid_dr_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[12].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                ////if (e.Row.Cells[8].Text == "CLOSED")
                ////    e.Row.Cells[9].Text = "";
                ////else
                ////    if (Convert.ToInt32(e.Row.Cells[9].Text) > 0 && e.Row.Cells[8].Text == "OPEN")
                ////        e.Row.Style.Add("color", "red");
                ////    else
                ////        e.Row.Cells[9].Text = "";



                if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
                {
                    e.Row.Cells[9].Enabled = false;
                    if (lblprj.Text == "ABS") { if (Session["ModuleAccess"].ToString() == "1") e.Row.Cells[9].Enabled = true; }
                   
                }
                    
            }
        }

        protected void mygrid_dr_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _idx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mygrid_dr.Rows[_idx];
            TableCell _drid = _srow.Cells[11];
            TableCell _drno = _srow.Cells[10];
            TableCell _created = _srow.Cells[13];
            TableCell _issued = _srow.Cells[12];
            TableCell _ser = _srow.Cells[1];
            TableCell _doc = _srow.Cells[2];
            //Session["dr_id"] = _drid.Text;
            //Session["dr_no"] = _drno.Text;
            //Session["created"] = _created.Text;
            //Session["issued"] = _issued.Text;
            //Session["service"] = _ser.Text;
            //Session["doc"] = _doc.Text;
            //_Create_Cookies();
            Label2.Text = _drid.Text;
            if (e.CommandName == "get")
            {

                string _prm = "http://cmltechniques.com/CMS_DOCS/" + lblprj.Text + "/" + _created.Text;
                string path = String.Format("{0}?dt={1}", _prm, DateTime.Now.Ticks.ToString()); 
                //Response.Redirect(_prm);
                ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + path + "','','left=210,top=100,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "Load_doc('" + _prm + "');", true);
            }
            else if (e.CommandName == "status")
            {
                //btnDummy_ModalPopupExtender.Show();
                lblmode.Text = "1";
                lblfile.Text = "";                
                btnupload.Text = "Save";                
                Load_SO_Pdf_Details();
                btndummy_ModalPopupExtender.Show();
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + Label2.Text + "');", true);
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_reviewed = "";
            _objcls.issued_date = DateTime.Now;
            _objcls.issued_to = "";
            _objcls.project_code = "";
            _objcls.uid = "";
            _objcls.mode = 0;
            _objcls.dr_id = Convert.ToInt32(Label2.Text);
            _objcls.service = "";
            if (drstatus1.SelectedItem.Text == "OPEN")
                _objcls.dr_status = true;
            else
                _objcls.dr_status = false;
            _objcls.Notes = "";
            string id = _objbll.Document_Review_Log(_objcls, _objdb);
            load_doc_review_log(lblprj.Text);
            Load_DocReview();
            btnDummy_ModalPopupExtender1.Hide();
        }

        protected void btncancel1_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender1.Hide();
        }


        protected void btnprint_Click(object sender, EventArgs e)
        {
            Session["fsrv"] = dr_service.SelectedItem.Text;
            Session["frev"] = drreview.SelectedItem.Text;
            Session["fiss"] = drissue.SelectedItem.Text;
            Session["fsts"] = drstatus.SelectedItem.Text;
            //string _prm = "Reports.aspx?id=dlog0" + drservice.SelectedItem.Text + "&idx=0&prj=" + lblprj.Text;
            string _prm = "Reports.aspx?id=SODR_PDF" + "&idx=0&prj=" + lblprj.Text + "&dtype=0";
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _prm + "','','left=200,top=50,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
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
        protected void btnupload_Click(object sender, EventArgs e)
        {          
            if (IsNullValidation() == true) return;
            uploadFiles();
            load_doc_review_log(lblprj.Text);
            Load_DocReview();
            //Load_Filtering_Elements();
        }
        private bool IsNullValidation()
        {
            if (txt_issuedto.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Enter Issued To');", true);
                return true;
            }
            else if (txt_drno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Enter DR Number');", true);
                return true;
            }
            else if (DateValidation(txt_issuedate.Text) == false)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Date');", true);
                return true;
            }
            return false;
        }
        private void uploadFiles()
        {
            HttpFileCollection hfc = Request.Files;
            
            string _dir = (string)Session["project"];
            if (Directory.Exists(Server.MapPath("../CMS_DOCS") + "\\" + _dir) == false)
                Directory.CreateDirectory(Server.MapPath("../CMS_DOCS") + "\\" + _dir);


            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                string _fileName = System.IO.Path.GetFileName(hpf.FileName);
                FileInfo _Ffile = new FileInfo(Server.MapPath("../CMS_DOCS") + "\\" + _dir + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                if (_Ffile.Exists == true)
                    _Ffile.Delete();
                if (hpf.ContentLength > 0)
                {
                    lblfile.Text = _fileName;
                    hpf.SaveAs(Server.MapPath("../CMS_DOCS") + "\\" + _dir + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                    
                }
            }
            if (lblmode.Text == "0")
            {
                Insert_Document();
            }
            else
                Update_Document();
        }
        private void Insert_Document()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_id = 0;
            _objcls.dr_no = txt_drno.Text;
            _objcls.ddate = txt_issuedate.Text;
            _objcls.issued_to = txt_issuedto.Text;
            _objcls.service = drservice.SelectedItem.Text;
            _objcls.dr_reviewed = txt_subject.Text;
            _objcls.uid = txt_review.Text;
            _objcls.details = lblfile.Text;
            _objcls.desc = txt_cmts.Text;
            _objcls.response = txt_resp.Text;
            if (dr_status.SelectedValue == "1")
                _objcls.dr_status = true;
            else
                _objcls.dr_status = false;
            _objcls.mode = 1;
            _objbll.dml_dr_pdf(_objcls, _objdb);
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('DR Document Uploaded!');", true);
            btndummy_ModalPopupExtender.Hide();
        }
        private void Update_Document()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_id = Convert.ToInt32(Label2.Text);
            _objcls.dr_no = txt_drno.Text;
            _objcls.ddate = txt_issuedate.Text;
            _objcls.issued_to = txt_issuedto.Text;
            _objcls.service = drservice.SelectedItem.Text;
            _objcls.dr_reviewed = txt_subject.Text;
            _objcls.uid = txt_review.Text;
            _objcls.details = lblfile.Text;
            _objcls.desc = txt_cmts.Text;
            _objcls.response = txt_resp.Text;
            if (dr_status.SelectedValue == "1")
                _objcls.dr_status = true;
            else
                _objcls.dr_status = false;
            _objcls.mode = 2;
            _objbll.dml_dr_pdf(_objcls, _objdb);
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('DR Details Updated');", true);
            btndummy_ModalPopupExtender.Hide();
        }
        protected void mygrid_dr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Load_SO_Pdf_Details()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_id = Convert.ToInt32(Label2.Text);
            DataTable _dt = _objbll.Load_dr_pdf_details(_objcls, _objdb);
            txt_drno.Text=_dt.Rows[0]["Dr_No"].ToString();
            txt_subject.Text = _dt.Rows[0]["Subject"].ToString();
            txt_review.Text = _dt.Rows[0]["created_By"].ToString();
            txt_issuedto.Text = _dt.Rows[0]["Issue_To"].ToString();
            txt_issuedate.Text = _dt.Rows[0]["Issue_Date"].ToString();
            txt_cmts.Text = _dt.Rows[0]["Comments"].ToString();
            txt_resp.Text = _dt.Rows[0]["Response"].ToString();
            lblfile.Text = _dt.Rows[0]["File_Name"].ToString();
            lblfilename.Text = lblfile.Text;
            dr_status.ClearSelection();
            if (_dt.Rows[0]["Status"].ToString() == "True")
                dr_status.Items.FindByText("OPEN").Selected = true;
            else
                dr_status.Items.FindByText("CLOSED").Selected = true;
        }

        protected void btncancel_Click1(object sender, EventArgs e)
        {
            btndummy_ModalPopupExtender.Hide();
        }

        protected void drstaus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
