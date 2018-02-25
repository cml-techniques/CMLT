using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Data;

namespace CmlTechniques.CMS
{
    public partial class so : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtresult;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString["PRJ"].ToString();
                lblprj.Text = _prm;
                lblid.Text = (string)Session["uid"];
                GetAccess();
                load_users(_prm);
                if (lblprj.Text == "14211")
                    load_services_14211(lblprj.Text);
                else
                    load_services(lblprj.Text);
                
                Session["ser"] = "All";
                Session["rew"] = "All";
                Session["iss"] = "All";
                Session["sta"] = "All";

                if (Request.QueryString["ACN"].ToString() == "1")
                {

                    Session["ser"] = Request.QueryString["SER"].ToString();
                    Session["rew"] = Request.QueryString["RVW"].ToString();
                    Session["iss"] = Request.QueryString["ISS"].ToString();
                    Session["sta"] = Request.QueryString["STA"].ToString();
                    Filtering((string)Session["ser"], (string)Session["rew"], (string)Session["iss"], (string)Session["sta"]);
                }
                else
                {
                    load_so_dir(_prm);
                    Load_SO_Details();

                }
                if (lblaccess.Text != "ADMIN GROUP" && lblaccess.Text != "SYS.ADMIN GROUP")
                {
                    btnadd.Enabled = false;
                }
                if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                {
                    Get_ProjectName();
                }
                else
                {
                    trcdate.Visible = false;
                    dvfixedhead.Visible = false;
                    dvfixedcontent.Style.Add("Top", "0px");
                }
                
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
        protected void load_services_14211(string Project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + Project;
            DataTable _dt = _objbll.Load_Cas_service_drso(_objdb);
            drpackage.DataSource = _dt;
            drpackage.DataTextField = "PRJ_SER_NAME";
            drpackage.DataValueField = "PRJ_SER_ID";
            drpackage.DataBind();

            sopackage_edit.DataSource = _dt;
            sopackage_edit.DataTextField = "PRJ_SER_NAME";
            sopackage_edit.DataValueField = "PRJ_SER_ID";
            sopackage_edit.DataBind();

        }
        private void GetAccess()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = lblid.Text;
            lblaccess.Text = _objbll.GetUserAccess(_objcls, _objdb);
        }
        private bool Validation_AddNew()
        {
            if (drpackage.SelectedItem.Text == "-- Select Service --")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Service');", true);
                return true;
            }
            else if (txtdoc.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Enter Subject');", true);
                return true;
            }
            else if (drissued.SelectedItem.Text == "--Select User--")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Issued To');", true);
                return true;
            }
            return false;
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            //insert_so();
            if (Validation_AddNew() == true) return;
            //int _max = mygrid_dr.Rows.Count - 1;
            //Session["soid"] = mygrid_dr.Rows[_max].Cells[12].Text;
            //Session["sono"] = mygrid_dr.Rows[_max].Cells[11].Text;
            Session["issued"] = drissued.SelectedItem.Text;
            Session["service"] = drpackage.SelectedItem.Text;
            Session["doc"] = txtdoc.Text;
            _Create_Cookies();
            //Send_Mail();
            //btnDummy_ModalPopupExtender.Hide();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('soadd.aspx','','left=210,top=100,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
            //if (chkuversion.Checked == true)
            //    Response.Redirect("soadd1.aspx?id=0" + lblprj.Text);
            //else
            DropDownList _drservice = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("dr_service");
            DropDownList _drreview = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drreview");
            DropDownList _drissued = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drissue");
            DropDownList _drstatus = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drstatus");
            string _filter = "&SER=" + _drservice.Text + "&RVW=" + _drreview.Text + "&ISS=" + _drissued.Text + "&STA=" + _drstatus.Text + "&ACN=1";
            string _prm = "soadd.aspx?id=0" + "&PRJ=" + lblprj.Text + _filter;
            Response.Redirect(_prm);
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
        protected void load_so_dir( string Project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + Project;
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = Project;
            //mydirview.DataSource = _objbll.Load_so_dir(_objcls,_objdb);
            //mydirview.DataBind();
            _dtMaster = _objbll.Load_so_dir(_objcls, _objdb);
            _dtresult = _dtMaster;
        }
        private void Load_SO_Details()
        {
            //mygrid_dr.DataSource = _dtresult;
            //mygrid_dr.DataBind();
            Rptlist.DataSource = _dtresult;
            Rptlist.DataBind();
            Load_Filtering_Elements();
        }
        private void Load_Filtering_Elements()
        {
            DropDownList _drservice = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("dr_service");
            DropDownList _drreview = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drreview");
            DropDownList _drissued = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drissue");
            DropDownList _drstatus = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drstatus");
            _drservice.Items.Clear();
            _drreview.Items.Clear();
            _drissued.Items.Clear();
            _drstatus.Items.Clear();
            var _service = (from DataRow dRow in _dtresult.Rows
                            orderby dRow["package"]
                            select new { col1 = dRow["package"] }).Distinct();
            foreach (var row in _service)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                _drservice.Items.Add(_itm);
            }
            _drservice.DataBind();
            var _reviewed = (from DataRow dRow in _dtresult.Rows
                             orderby dRow["userid"]
                             select new { col1 = dRow["userid"] }).Distinct();
            foreach (var row in _reviewed)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                _drreview.Items.Add(_itm);
            }
            _drreview.DataBind();
            var _issued = (from DataRow dRow in _dtresult.Rows
                           orderby dRow["issued"]
                           select new { col1 = dRow["issued"] }).Distinct();
            foreach (var row in _issued)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                _drissued.Items.Add(_itm);
            }
            _drissued.DataBind();

            var _status = (from DataRow dRow in _dtresult.Rows
                           orderby dRow["drstatus"]
                           select new { col1 = dRow["drstatus"] }).Distinct();
            foreach (var row in _status)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                _drstatus.Items.Add(_itm);
            }
            _drstatus.DataBind();
            _drservice.Items.Insert(0, "All");
            _drreview.Items.Insert(0, "All");
            _drissued.Items.Insert(0, "All");
            _drstatus.Items.Insert(0, "All");
            _drservice.SelectedValue = (string)Session["ser"];
            _drreview.SelectedValue = (string)Session["rew"];
            _drissued.SelectedValue = (string)Session["iss"];
            _drstatus.SelectedValue = (string)Session["sta"];
        }
        protected void load_users(string Project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = Project;
            _objcls.mode = 6;
            drissued.DataSource = _objbll.Load_CMS_Users(_objcls, _objdb);
            drissued.DataTextField = "uid";
            drissued.DataValueField = "uid";
            drissued.DataBind();
            drissued.Items.Insert(0, "--Select User--");
        }
        protected void load_services(string Project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + Project;
            DataTable _soservice;

            _soservice = _objbll.Load_Cas_service(_objdb);

            drpackage.DataSource = _soservice;
            drpackage.DataTextField = "PRJ_SER_NAME";
            drpackage.DataValueField = "SYS_SER_ID";
            drpackage.DataBind();

            sopackage_edit.DataSource = _soservice;
            sopackage_edit.DataTextField = "PRJ_SER_NAME";
            sopackage_edit.DataValueField = "SYS_SER_ID";
            sopackage_edit.DataBind();



            int count = drpackage.Items.Count;
            if (lblprj.Text == "HPOB")
            {
                drpackage.Items.Insert(count, new ListItem("MEP", "MEP"));
                drpackage.Items.Insert(0, "-- Select Service --");

                sopackage_edit.Items.Insert(count, new ListItem("MEP", "MEP"));
            }
        }

        protected void set_status()
        {
            //DropDownList _drs = (DropDownList)mydirview.EditItem.FindControl("drstatus");
            //_drs.Items.Add("OPEN");
            //_drs.Items.Add("CLOSE");
            //Label _st = (Label)mydirview.EditItem.FindControl("statusLabel");
            //if (_st.Text == "OPEN")
            //    _drs.Items[0].Selected = true;
            //else
            //    _drs.Items[1].Selected = true;
        }

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }

        protected void btnadddetails_Click(object sender, EventArgs e)
        {
            add_details();
            Load_SO_Details();
        }
        protected void add_details()
        {
            //HttpFileCollection hfc = Request.Files;
            //BLL_Dml _objbll = new BLL_Dml();
            //_clsSO _objcls = new _clsSO();
            //_objcls.so_id = Convert.ToInt32((string)Session["soid"]);
            //_objcls.details = txtdetails.Text;
            //_objcls.response = "";
            //_objcls.so_date = DateTime.Now;
            //_objcls.uid = (string)Session["uid"];
            //_objcls.so_itm_id = 0;
            //_objcls.mode = 1;
            //_objbll.SO_Details(_objcls);
            //string[] itm = new string[3];
            //for (int i = 0; i < hfc.Count; i++)
            //{
            //    HttpPostedFile hpf = hfc[i];
            //    string _fileName = System.IO.Path.GetFileName(hpf.FileName);
            //    FileInfo _Ffile = new FileInfo(Server.MapPath("..\\SOIMG") + "\\" + System.IO.Path.GetFileName(hpf.FileName));
            //    if (_Ffile.Exists == true)
            //        _Ffile.Delete();
            //    if (hpf.ContentLength > 0)
            //    {
            //        hpf.SaveAs(Server.MapPath("..\\SOIMG") + "\\" + System.IO.Path.GetFileName(hpf.FileName));
            //        _objcls.photo="../SOIMG/" + System.IO.Path.GetFileName(hpf.FileName);
            //        _objbll.SO_Photo(_objcls);
            //    }


            //}
            
        }

        protected void mygrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int _rowidx = Convert.ToInt32(e.CommandArgument);
            //GridViewRow _srow = mygrid.Rows[_rowidx];
            //TableCell _id = _srow.Cells[0];
            ////TableCell _no = _srow.Cells[1];
            //Session["soid"] = _id.Text;
            ////Session["dr_no"] = _no.Text;
            //mydiv.Visible = true;
            //load_so_details();
        }

        protected void mydetails_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label _id = (Label)e.Item.FindControl("so_itm_idLabel");
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsSO _objcls = new _clsSO();
            _objcls.so_id = Convert.ToInt32(_id.Text);
            GridView _myphoto = (GridView)e.Item.FindControl("myphoto");
            _myphoto.DataSource = _objbll.Load_SO_Photo(_objcls,_objdb);
            _myphoto.DataBind();
            
        }

        protected void Load_users_CC()
        {
            chkuser.Items.Clear();
            for (int i = 0; i <= drissued.Items.Count - 1; i++)
            {
                if (drissued.Items[i].Text != drissued.SelectedItem.Text && drissued.Items[i].Text != "--Select User--")
                {
                    ListItem lst = new ListItem();
                    lst.Text = drissued.Items[i].Text;
                    lst.Value = drissued.Items[i].Value;
                    chkuser.Items.Add(lst);
                }

            }
        }
        private bool Isnullvalidation()
        {
            if (drpackage.SelectedItem.Text == "-- Select Service --")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Service Selection');", true);
                return true;
            }
            else if (drissued.SelectedItem.Text == "-- Select User --")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Issued to Selection');", true);
                return true;
            }
            return false;
        }
        private void insert_so()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsSO _objcls = new _clsSO();
            _objcls.package = drpackage.SelectedItem.Text;
            _objcls.doc_name = txtdoc.Text;
            _objcls.so_date = DateTime.Now;
            _objcls.issued_to = drissued.SelectedItem.Text;
            _objcls.issued_date = DateTime.Now;
            _objcls.remarks = "";
            _objcls.project_code = (string)Session["project"];
            _objcls.uid = (string)Session["uid"];
            _objcls.mode = 1;
            _objcls.so_id = 0;
            _objbll.SO_Dir(_objcls, _objdb);
            load_so_dir((string)Session["project"]);
            Load_SO_Details();
        }

        protected void btnCont_Click(object sender, EventArgs e)
        {
            insert_so();
            //int _max = mygrid_dr.Rows.Count - 1;
            //Session["soid"] = mygrid_dr.Rows[_max].Cells[12].Text;
            //Session["sono"] = mygrid_dr.Rows[_max].Cells[11].Text;
            Session["issued"] = drissued.SelectedItem.Text;
            Session["service"] = drpackage.SelectedItem.Text;
            Session["doc"] = txtdoc.Text;
            //Send_Mail();
            //btnDummy_ModalPopupExtender.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('soadd.aspx','','left=210,top=100,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender.Hide();
        }
        protected void mydirview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                Button _btn = (Button)e.Item.FindControl("btndr_no");
                Label _lbl = (Label)e.Item.FindControl("so_idLabel");
                Label _issued = (Label)e.Item.FindControl("issued_toLabel");
                Label _create = (Label)e.Item.FindControl("uidLabel");
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _btn.Text + "');", true);
                Session["soid"] = _lbl.Text;
                Session["sono"] = _btn.Text;
                //lbldrno.Text = _btn.Text;
               // load_so_details();
                Session["issued"] = _issued.Text;
                Session["created"] = _create.Text;
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('sodetails.aspx','','left=210,top=100,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=0');", true);
                if (lblprj.Text == "123")
                    Response.Redirect("sodetails_new.aspx?PRJ=" + lblprj.Text + "&id=" + _lbl.Text);
                else
                    Response.Redirect("sodetails.aspx");

                //_prm = "cmsdocreview_details.aspx?id=" + _lbl.Text + "&PRJ=" + lblprj.Text + "&SER=" + dr_service.Text + "&RVW=" + drreview.Text + "&ISS=" + drissue.Text + "&STA=" + drstatus.Text + "&ACN=1";

            }
            else if (e.CommandName == "Update")
            {
                Label _id = (Label)e.Item.FindControl("so_idLabel");
                DropDownList _drs = (DropDownList)e.Item.FindControl("drstatus");
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + (string)Session["project"];
                _clsSO _objcls = new _clsSO();
                _objcls.so_id = Convert.ToInt32(_id.Text);
                if (_drs.SelectedItem.Text == "OPEN")
                    _objcls.status = true;
                else
                    _objcls.status = false;
                _objcls.mode = 0;
                _objcls.package = "";
                _objcls.doc_name = "";
                _objcls.so_date = DateTime.Now;
                _objcls.issued_to = "";
                _objcls.issued_date = DateTime.Now;
                _objcls.remarks = "";
                _objcls.project_code = "";
                _objcls.uid = "";
                _objbll.SO_Dir(_objcls,_objdb);
                               
            }
        }

        protected void mydirview_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }

        protected void mydirview_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            //mydirview.EditIndex = e.NewEditIndex;
            //load_so_dir();
            //set_status();
        }

        protected void mydirview_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            //mydirview.EditIndex = -1;
            //load_so_dir();
        }

        protected void mydetails_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            //mydetails.EditIndex = e.NewEditIndex;
            //load_so_details();
        }

        protected void mydetails_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            //mydetails.EditIndex = -1;
            //load_so_details();
        }

        protected void mydetails_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                Label _id = (Label)e.Item.FindControl("so_itm_idLabel");
                TextBox _resp = (TextBox)e.Item.FindControl("responseTextBox");
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + (string)Session["project"];
                _clsSO _objcls = new _clsSO();
                _objcls.so_id = 0;
                _objcls.details = "";
                _objcls.response = _resp.Text;
                _objcls.so_date = DateTime.Now;
                _objcls.so_itm_id = Convert.ToInt32(_id.Text);
                _objcls.mode = 0;
                _objcls.uid = "";
                _objbll.SO_Details(_objcls,_objdb);
            }
        }

        protected void mydirview_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label _st = (Label)e.Item.FindControl("statusLabel");
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
            //if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")

            if (lblaccess.Text != "ADMIN GROUP" && lblaccess.Text != "SYS.ADMIN GROUP")
            {
                _edit.Visible = false;
            }
        }
        private void Change_RowClr(ListViewItemEventArgs e)
        {
            HtmlTableRow _tr = (HtmlTableRow)e.Item.FindControl("itm_tr");
            _tr.Style.Add("color", "Red");
        }
        protected void mydirview_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            //mydirview.EditIndex = -1;
            //load_so_dir(); 
        }
        protected void mydetails_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            //mydetails.EditIndex = -1;
            //load_so_details();
        }
        void Send_Mail()
        {
            publicCls.publicCls _objcls = new publicCls.publicCls();
            string Body = "";
            Body = "Ref. " + (string)Session["projectname"] + "/" + drpackage.SelectedItem.Text + "/" + (string)Session["sono"] + "/" + txtdoc.Text + "\n\n" + "This is an automatically generated email to advise you that the above document has been issued to you." + "\n\n" + "Could you please find time to review the documents  and make comments within the next 15 days" + "\n\n" + "If you review and have no comments on the document, please confirm with 'No comments' in the Response Column." + "\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";

            string _sub = "Site Observation - Ref. " + (string)Session["projectname"] + "/" + drpackage.SelectedItem.Text + "/" + (string)Session["sono"] + "/" + txtdoc.Text;
            _objcls.Send_Email(drissued.SelectedItem.Text, _sub, Body);
            //_objcls.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
            Body = "Ref. " + (string)Session["projectname"] + "/" + drpackage.SelectedItem.Text + "/" + (string)Session["sono"] + "/" + txtdoc.Text + "\n\n" + "This is an automatically generated email to advise you that the above document has been issued to " + drissued.SelectedItem.Text + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";

            for (int i = 0; i <= chkuser.Items.Count - 1; i++)
            {
                if (chkuser.Items[i].Selected == true)
                    _objcls.Send_Email(chkuser.Items[i].Text, _sub, Body);
            }
            // _objcls.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
        }
        private void Filtering(string _el1, string _el2, string _el3, string _el4)
        {
            if (_el1 == "") _el1 = "All";
            if (_el2 == "") _el2 = "All";
            if (_el3 == "") _el3 = "All";
            if (_el4 == "") _el4 = "All";
            load_so_dir(lblprj.Text);
            //bool _status;
            //if (_el4 == "OPEN")
            //    _status = true;
            //else if (_el4 == "CLOSED")
            //    _status = false;
            DataTable _dtfilter = _dtMaster;
            //DataTable _dtresult1 = new DataTable();
            //_dtresult1.Columns.Add("so_no", typeof(string));
            //_dtresult1.Columns.Add("so_id", typeof(string));
            //_dtresult1.Columns.Add("package", typeof(string));
            //_dtresult1.Columns.Add("doc_name", typeof(string));
            //_dtresult1.Columns.Add("issued_date", typeof(string));
            //_dtresult1.Columns.Add("uid", typeof(string));
            //_dtresult1.Columns.Add("issued_to", typeof(string));
            //_dtresult1.Columns.Add("comment", typeof(string));
            //_dtresult1.Columns.Add("response", typeof(string));
            //_dtresult1.Columns.Add("drstatus", typeof(string));
            //_dtresult1.Columns.Add("due", typeof(string));
            //_dtresult1.Columns.Add("issued", typeof(string));
            //_dtresult1.Columns.Add("userid", typeof(string));
            //_dtresult1.Columns.Add("closed", typeof(string));
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
                          where o.Field<string>("package") == _el1
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("package") == _el1 && o.Field<string>("userid") == _el2
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("package") == _el1 && o.Field<string>("userid") == _el2 && o.Field<string>("issued") == _el3
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("package") == _el1 && o.Field<string>("userid") == _el2 && o.Field<string>("issued") == _el3 && o.Field<string>("drstatus") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("userid") == _el2
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("userid") == _el2 && o.Field<string>("issued") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("userid") == _el2 && o.Field<string>("issued") == _el3 && o.Field<string>("drstatus") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("issued") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("issued") == _el3 && o.Field<string>("drstatus") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("drstatus") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("package") == _el1 && o.Field<string>("issued") == _el3
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("package") == _el1 && o.Field<string>("issued") == _el3 && o.Field<string>("drstatus") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("package") == _el1 && o.Field<string>("drstatus") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("userid") == _el2 && o.Field<string>("drstatus") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("package") == _el1 && o.Field<string>("userid") == _el2 && o.Field<string>("drstatus") == _el4
                          select o;
            }

            //foreach (var row in _filter)
            //{
            //    DataRow _row = _dtresult1.NewRow();
            //    _row[0] = row["so_no"].ToString();
            //    _row[1] = row["so_id"].ToString();
            //    _row[2] = row["package"].ToString();
            //    _row[3] = row["doc_name"].ToString();
            //    _row[4] = row["issued_date"].ToString();
            //    _row[5] = row["uid"].ToString();
            //    _row[6] = row["issued_to"].ToString();
            //    _row[7] = row["comment"].ToString();
            //    _row[8] = row["response"].ToString();
            //    _row[9] = row["drstatus"].ToString();
            //    _row[10] = row["due"].ToString();
            //    _row[11] = row["issued"].ToString();
            //    _row[12] = row["userid"].ToString();
            //    _row[13] = row["closed"].ToString();
            //    _dtresult1.Rows.Add(_row);
            //}
            //m.DataSource = _dtresult;
            //mygrid.DataBind();
            _dtresult = _filter.Any() ? _filter.CopyToDataTable() : _dtMaster.Clone();
            Load_SO_Details();

        }
        protected void dr_service_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dr_service = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("dr_service");
            DropDownList drreview = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drreview");
            DropDownList drissue = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drissue");
            DropDownList drstatus = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drstatus");
            Session["ser"] = dr_service.SelectedItem.Text;
            Filtering(dr_service.SelectedItem.Text, drreview.SelectedItem.Text, drissue.SelectedItem.Text, drstatus.SelectedItem.Text);
        }
        protected void drreview_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dr_service = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("dr_service");
            DropDownList drreview = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drreview");
            DropDownList drissue = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drissue");
            DropDownList drstatus = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drstatus");
            Session["rew"] = drreview.SelectedItem.Value;
            Filtering(dr_service.SelectedItem.Text, drreview.SelectedItem.Text, drissue.SelectedItem.Text, drstatus.SelectedItem.Text);
        }
        protected void drissue_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dr_service = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("dr_service");
            DropDownList drreview = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drreview");
            DropDownList drissue = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drissue");
            DropDownList drstatus = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drstatus");
            Session["iss"] = drissue.SelectedItem.Value;
            Filtering(dr_service.SelectedItem.Text, drreview.SelectedItem.Text, drissue.SelectedItem.Text, drstatus.SelectedItem.Text);
        }
        protected void drstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dr_service = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("dr_service");
            DropDownList drreview = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drreview");
            DropDownList drissue = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drissue");
            DropDownList drstatus = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drstatus");
            Session["sta"] = drstatus.SelectedItem.Value;
            Filtering(dr_service.SelectedItem.Text, drreview.SelectedItem.Text, drissue.SelectedItem.Text, drstatus.SelectedItem.Text);
        }

       
        //void _Create_Cookies()
        //{
        //    if (Request.Browser.Cookies)
        //    {
        //        HttpCookie _CookieIssued = new HttpCookie("issued");
        //        _CookieIssued.Value = (string)Session["issued"];
        //        _CookieIssued.Expires = DateTime.Now.AddDays(10);
        //        Response.Cookies.Add(_CookieIssued);
        //    }
        //    else
        //        return;
        //}

        

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsSO _objcls = new _clsSO();
            _objcls.so_id = Convert.ToInt32((string)Session["soid"]);
            if (sostatus1.SelectedItem.Text == "OPEN")
                _objcls.status = true;
            else
                _objcls.status = false;
            _objcls.mode = 0;
            _objcls.package = sopackage_edit.SelectedItem.Text;
            _objcls.doc_name = txt_subject.Text;
            _objcls.so_date = DateTime.Now;
            _objcls.issued_to = "";
            _objcls.issued_date = DateTime.Now;
            _objcls.remarks = "";
            _objcls.project_code = "";
            _objcls.uid = "";
            _objcls.cdate = txt_closeout.Text;
            _objbll.SO_Dir(_objcls, _objdb);
            load_so_dir((string)Session["project"]);
            Load_SO_Details();
            btnDummy_ModalPopupExtender1.Hide();
        }

        protected void btncancel1_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender1.Hide();
        }


        protected void btnprint_Click(object sender, EventArgs e)
        {
            DropDownList drservice = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("dr_service");
            DropDownList drreview = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drreview");
            DropDownList drissued = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drissue");
            DropDownList drstatus = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drstatus");
            Session["fsrv"] = drservice.SelectedItem.Text;
            Session["frev"] = drreview.SelectedItem.Text;
            Session["fiss"] = drissued.SelectedItem.Text;
            Session["fsts"] = drstatus.SelectedItem.Text;
            string _prm = "Reports.aspx?id=som1&idx=0&prj=" + lblprj.Text;
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _prm + "','','left=200,top=50,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
        }

        protected void Rptlist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //int _idx = Convert.ToInt32(e.CommandArgument);
            //GridViewRow _srow = mygrid_dr.Rows[_idx];
            ////TableCell _drid = _srow.Cells[12];
            ////TableCell _drno = _srow.Cells[11];
            ////TableCell _created = _srow.Cells[14];
            ////TableCell _issued = _srow.Cells[13];
            ////TableCell _pkg = _srow.Cells[1];
            ////TableCell _doc = _srow.Cells[2];
            Label _soid = (Label)e.Item.FindControl("lblsoid");
            Label _sono = (Label)e.Item.FindControl("lblsono");
            Label _created = (Label)e.Item.FindControl("lblcreated");
            Label _issued = (Label)e.Item.FindControl("lblissued");
            Label _pkg = (Label)e.Item.FindControl("lblpkg");
            Label _doc = (Label)e.Item.FindControl("lbldoc");
            Label _stat = (Label)e.Item.FindControl("lblstatus");
            Label _cdate = (Label)e.Item.FindControl("lblcloseoutdate");
            Session["soid"] = _soid.Text;
            Session["sono"] = _sono.Text;
            Session["created"] = _created.Text;
            Session["issued"] = _issued.Text;
            Session["package"] = _pkg.Text;
            Session["doc"] = _doc.Text;
            _Create_Cookies();

           

            if (e.CommandName == "get")
            {

                DropDownList drservice = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("dr_service");
                DropDownList drreview = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drreview");
                DropDownList drissued = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drissue");
                DropDownList drstatus = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drstatus");

                DropDownList _drstatus = (DropDownList)Rptlist.Controls[0].Controls[0].FindControl("drstatus");


                // lbldrno.Text = _btn.Text;
                //mydiv.Visible = true;
                //load_doc_review_details();
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('sodetails.aspx','','left=210,top=100,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=0');", true);
                //string _prm = "sodetails.aspx?id=" + _soid.Text + "_P" + lblprj.Text;
                
                //string _prm = "sodetails.aspx?id=" + _soid.Text + "&PRJ=" + lblprj.Text + "&SER=" + (Session["ser"].ToString() == "" ? "All" : Session["ser"].ToString()) + "&RVW=" + (Session["rew"].ToString() == "" ? "All" : Session["rew"].ToString()) + "&ISS=" + (Session["iss"].ToString() == "" ? "All" : Session["iss"].ToString()) + "&STA=" + (Session["sta"].ToString() == "" ? "All" : Session["sta"].ToString()) + "&ACN=1";  
                string _prm = "";
                if(lblprj.Text=="123")
                    _prm = "sodetails_new.aspx?id=" + _soid.Text + "&PRJ=" + lblprj.Text + "&SER=" + drservice.Text + "&RVW=" + drreview.Text + "&ISS=" + drissued.Text + "&STA=" + drstatus.SelectedItem.ToString() + "&ACN=1";
                else
                    _prm = "sodetails.aspx?id=" + _soid.Text + "&PRJ=" + lblprj.Text + "&SER=" + drservice.Text + "&RVW=" + drreview.Text + "&ISS=" + drissued.Text + "&STA=" + drstatus.SelectedItem.ToString() + "&ACN=1";

                Response.Redirect(_prm);
            }
            else if (e.CommandName == "status")
            {
                string _status = _stat.Text;
                //sostatus1.ClearSelection();
               // sostatus1.Items.FindByText(_status).Selected = true;

                txt_subject.Text = _doc.Text;
                lblheadtitle.Text = "SO Details - " + _sono.Text;
                if (sopackage_edit.Items.Count>0)sopackage_edit.SelectedValue = sopackage_edit.Items.FindByText(_pkg.Text).Value;
                if (sostatus1.Items.Count > 0) sostatus1.SelectedValue = sostatus1.Items.FindByText(_stat.Text).Value;
                txt_closeout.Text = _cdate.Text;
                if (_stat.Text == "OPEN")
                {
                    txt_closeout.Enabled = false;
                    calendar_popup.Disabled = true;
                    CalendarExtender13.PopupButtonID = null;
                }
                else
                {
                    txt_closeout.Enabled = true;
                    calendar_popup.Disabled = false;
                    CalendarExtender13.PopupButtonID = "calendar_popup";
                }
                btnDummy_ModalPopupExtender1.Show();
            }
        }

        protected void Rptlist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label _status = (Label)e.Item.FindControl("lblstatus");
                Label _due = (Label)e.Item.FindControl("lbldue");
                string _sta = _status.Text;
                HtmlTableRow _tr = new HtmlTableRow();
                _tr = (HtmlTableRow)e.Item.FindControl("trow");
                if (Convert.ToInt32(_due.Text) > 0 && _status.Text == "OPEN")
                    _tr.Style.Add("color", "red");
                else
                    _due.Text = "";
                HtmlTableCell _td3 = (HtmlTableCell)e.Item.FindControl("td3");
                HtmlTableCell _td_3 = (HtmlTableCell)e.Item.FindControl("td_3");
                if (lblprj.Text != "11736")
                    _td3.Visible = false;
                if (lblprj.Text != "HMIM" && lblprj.Text != "HMHS")
                    _td_3.Visible = false;
                if (lblaccess.Text != "ADMIN GROUP" && lblaccess.Text != "SYS.ADMIN GROUP")
                {
                    HtmlTableCell _td4 = (HtmlTableCell)e.Item.FindControl("td4");
                    Button _btn = (Button)_td4.FindControl("Button1");
                    _btn.Enabled = false;
                }

            }
            else if (e.Item.ItemType == ListItemType.Header)
            {
                HtmlTableCell _td1 = (HtmlTableCell)e.Item.FindControl("td1");
                HtmlTableCell _td2 = (HtmlTableCell)e.Item.FindControl("td2");
                HtmlTableCell _td_1 = (HtmlTableCell)e.Item.FindControl("td_1");
                HtmlTableCell _td_2 = (HtmlTableCell)e.Item.FindControl("td_2");
                if (lblprj.Text != "11736")
                {
                    _td1.Visible = false;
                    _td2.Visible = false;
                }
                if (lblprj.Text != "HMIM" && lblprj.Text != "HMHS")
                {
                    _td_1.Visible = false;
                    _td_2.Visible = false;
                }


            }
            //if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
            //    e.Row.Cells[10].Enabled = false;
        }

        protected void mygrid_dr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void sostatus1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sostatus1.SelectedValue == "OPEN")
            {
                txt_closeout.Text = "";
                txt_closeout.Enabled = false;
                calendar_popup.Disabled = true;
                CalendarExtender13.PopupButtonID = null;

            }
            else
            {
                txt_closeout.Enabled = true;
                calendar_popup.Disabled = false;
                CalendarExtender13.PopupButtonID = "calendar_popup";
                txt_closeout.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

    }
}
