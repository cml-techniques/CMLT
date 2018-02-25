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
    public partial class SiteObservation : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtresult;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString["PRJ"].ToString();
            
                lblprj.Text = _prm;
                //load_users(_prm);
                //load_services(_prm);
                load_so_dir(_prm);
                Load_SO_Details();
                Load_Filtering_Elements();
                Session["ser"] = "";
                Session["act"] = "";
                Session["bul"] = "";
                Session["sub"] = "";
                Session["com"] = "";
                //mydiv.Visible = false;
            }
        }
        //private bool Validation_AddNew()
        //{
        //    if (drpackage.SelectedItem.Text == "-- Select Service --")
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Service');", true);
        //        return true;
        //    }
        //    else if (txtdoc.Text.Length <= 0)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Enter Subject');", true);
        //        return true;
        //    }
        //    else if (drissued.SelectedItem.Text == "--Select User--")
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Issued To');", true);
        //        return true;
        //    }
        //    return false;
        //}
        protected void btnadd_Click(object sender, EventArgs e)
        {
            //insert_so();
            //if (Validation_AddNew() == true) return;
            int _max = mygrid_dr.Rows.Count - 1;
            //Session["soid"] = mygrid_dr.Rows[_max].Cells[12].Text;
            //Session["sono"] = mygrid_dr.Rows[_max].Cells[11].Text;
            //Session["issued"] = drissued.SelectedItem.Text;
            //Session["service"] = drpackage.SelectedItem.Text;
            //Session["doc"] = txtdoc.Text;
            _Create_Cookies();
            //Send_Mail();
            //btnDummy_ModalPopupExtender.Hide();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('soadd.aspx','','left=210,top=100,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
            //if (chkuversion.Checked == true)
            //    Response.Redirect("soadd1.aspx?id=0" + lblprj.Text);
            //else
            //Response.Redirect("soadd.aspx?id=0" + lblprj.Text);
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
        protected void load_so_dir(string Project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + Project;
            //_clsuser _objcls = new _clsuser();
            //_objcls.project_code = Project;
            ////mydirview.DataSource = _objbll.Load_so_dir(_objcls,_objdb);
            ////mydirview.DataBind();
            //_dtMaster = _objbll.Load_so_dir(_objcls, _objdb);
            //_dtresult = _dtMaster;
            _dtMaster = _objbll.Load_So_Uversion(_objdb);
            _dtresult = _dtMaster;
        }
        private void Load_SO_Details()
        {
            mygrid_dr.DataSource = _dtresult;
            mygrid_dr.DataBind();
        }
        private void Load_Filtering_Elements()
        {
            var _service = (from DataRow dRow in _dtMaster.Rows
                            orderby dRow["srv_name"]
                            select new { col1 = dRow["srv_name"] }).Distinct();
            foreach (var row in _service)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                dr_service.Items.Add(_itm);
            }
            dr_service.DataBind();
            var _action = (from DataRow dRow in _dtMaster.Rows
                             orderby dRow["issued_to"]
                           select new { col1 = dRow["issued_to"] }).Distinct();
            foreach (var row in _action)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                dr_action.Items.Add(_itm);
            }
            dr_action.DataBind();
            var _build = (from DataRow dRow in _dtMaster.Rows
                           orderby dRow["subject"]
                          select new { col1 = dRow["subject"] }).Distinct();
            foreach (var row in _build)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                dr_building.Items.Add(_itm);
            }
            dr_building.DataBind();
            var _dtsub = (from DataRow dRow in _dtMaster.Rows
                          orderby dRow["issue_date"]
                          select new { col1 = dRow["issue_date"] }).Distinct();
            foreach (var row in _dtsub)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                dr_dtsub.Items.Add(_itm);
            }
            dr_dtsub.DataBind();
            var _dtcompl = (from DataRow dRow in _dtMaster.Rows
                          orderby dRow["compl_date"]
                            select new { col1 = dRow["compl_date"] }).Distinct();
            foreach (var row in _dtcompl)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                dr_dtcom.Items.Add(_itm);
            }
            dr_dtcom.DataBind();
            dr_service.Items.Insert(0, "All");
            dr_action.Items.Insert(0, "All");
            dr_building.Items.Insert(0, "All");
            dr_dtsub.Items.Insert(0, "All");
            dr_dtcom.Items.Insert(0, "All");


            if (lblprj.Text == "ASAO")
            {
                if (Convert.ToInt16(dr_dtcom.Items.IndexOf(dr_dtcom.Items.FindByText(""))) >= 0)
                {
                    dr_dtcom.Items[dr_dtcom.Items.IndexOf(dr_dtcom.Items.FindByText(""))].Text = "Blank";
                }
            }




            dr_service.SelectedValue = (string)Session["ser"];
            dr_building.SelectedValue = (string)Session["bul"];
            dr_action.SelectedValue = (string)Session["act"];
            dr_dtsub.SelectedValue = (string)Session["sub"];
            dr_dtcom.SelectedValue = (string)Session["com"];
        }
        //protected void load_users(string Project)
        //{
        //    BLL_Dml _objbll = new BLL_Dml();
        //    _database _objdb = new _database();
        //    _objdb.DBName = "dbCML";
        //    _clsuser _objcls = new _clsuser();
        //    _objcls.project_code = Project;
        //    _objcls.mode = 6;
        //    drissued.DataSource = _objbll.Load_CMS_Users(_objcls, _objdb);
        //    drissued.DataTextField = "uid";
        //    drissued.DataValueField = "uid";
        //    drissued.DataBind();
        //    drissued.Items.Insert(0, "--Select User--");
        //}
        //protected void load_services(string Project)
        //{
        //    BLL_Dml _objbll = new BLL_Dml();
        //    _database _objdb = new _database();
        //    _objdb.DBName = "DB_" + Project;
        //    drpackage.DataSource = _objbll.Load_Cas_service(_objdb);
        //    drpackage.DataTextField = "PRJ_SER_NAME";
        //    drpackage.DataValueField = "SYS_SER_ID";
        //    drpackage.DataBind();
        //    drpackage.Items.Insert(0, "-- Select Service --");
        //}

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
            _myphoto.DataSource = _objbll.Load_SO_Photo(_objcls, _objdb);
            _myphoto.DataBind();

        }

        protected void Load_users_CC()
        {
            //chkuser.Items.Clear();
            //for (int i = 0; i <= drissued.Items.Count - 1; i++)
            //{
            //    if (drissued.Items[i].Text != drissued.SelectedItem.Text && drissued.Items[i].Text != "--Select User--")
            //    {
            //        ListItem lst = new ListItem();
            //        lst.Text = drissued.Items[i].Text;
            //        lst.Value = drissued.Items[i].Value;
            //        chkuser.Items.Add(lst);
            //    }

            //}
        }
        private bool Isnullvalidation()
        {
            //if (drpackage.SelectedItem.Text == "-- Select Service --")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Service Selection');", true);
            //    return true;
            //}
            //else if (drissued.SelectedItem.Text == "-- Select User --")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Issued to Selection');", true);
            //    return true;
            //}
            return false;
        }
        private void insert_so()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DB_" + (string)Session["project"];
            //_clsSO _objcls = new _clsSO();
            //_objcls.package = drpackage.SelectedItem.Text;
            //_objcls.doc_name = txtdoc.Text;
            //_objcls.so_date = DateTime.Now;
            //_objcls.issued_to = drissued.SelectedItem.Text;
            //_objcls.issued_date = DateTime.Now;
            //_objcls.remarks = "";
            //_objcls.project_code = (string)Session["project"];
            //_objcls.uid = (string)Session["uid"];
            //_objcls.mode = 1;
            //_objcls.so_id = 0;
            //_objbll.SO_Dir(_objcls, _objdb);
            //load_so_dir((string)Session["project"]);
            //Load_SO_Details();
        }

        protected void btnCont_Click(object sender, EventArgs e)
        {
            //insert_so();
            //int _max = mygrid_dr.Rows.Count - 1;
            //Session["soid"] = mygrid_dr.Rows[_max].Cells[12].Text;
            //Session["sono"] = mygrid_dr.Rows[_max].Cells[11].Text;
            //Session["issued"] = drissued.SelectedItem.Text;
            //Session["service"] = drpackage.SelectedItem.Text;
            //Session["doc"] = txtdoc.Text;
            ////Send_Mail();
            ////btnDummy_ModalPopupExtender.Hide();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('soadd.aspx','','left=210,top=100,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
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
                Response.Redirect("sodetails.aspx");
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
                _objbll.SO_Dir(_objcls, _objdb);

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
                _objbll.SO_Details(_objcls, _objdb);
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
            if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
                _edit.Visible = false;
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
        //void Send_Mail()
        //{
        //    publicCls.publicCls _objcls = new publicCls.publicCls();
        //    string Body = "";
        //    Body = "Ref. " + (string)Session["projectname"] + "/" + drpackage.SelectedItem.Text + "/" + (string)Session["sono"] + "/" + txtdoc.Text + "\n\n" + "This is an automatically generated email to advise you that the above document has been issued to you." + "\n\n" + "Could you please find time to review the documents  and make comments within the next 15 days" + "\n\n" + "If you review and have no comments on the document, please confirm with 'No comments' in the Response Column." + "\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "http://www.cmldubai.com";

        //    string _sub = "Site Observation - Ref. " + (string)Session["projectname"] + "/" + drpackage.SelectedItem.Text + "/" + (string)Session["sono"] + "/" + txtdoc.Text;
        //    _objcls.Send_Email(drissued.SelectedItem.Text, _sub, Body);
        //    //_objcls.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
        //    Body = "Ref. " + (string)Session["projectname"] + "/" + drpackage.SelectedItem.Text + "/" + (string)Session["sono"] + "/" + txtdoc.Text + "\n\n" + "This is an automatically generated email to advise you that the above document has been issued to " + drissued.SelectedItem.Text + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "http://www.cmldubai.com";

        //    for (int i = 0; i <= chkuser.Items.Count - 1; i++)
        //    {
        //        if (chkuser.Items[i].Selected == true)
        //            _objcls.Send_Email(chkuser.Items[i].Text, _sub, Body);
        //    }
        //    // _objcls.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
        //}
        private void Filtering(string _el1, string _el2, string _el3,string _el4,string _el5)
        {
            if (_el1 == "") _el1 = "All";
            if (_el2 == "") _el2 = "All";
            if (_el3 == "") _el3 = "All";
            if (_el4 == "") _el4 = "All";
            if (_el5 == "") _el5 = "All";
            //bool _status;
            //if (_el4 == "OPEN")
            //    _status = true;
            //else if (_el4 == "CLOSED")
            //    _status = false;
            DataTable _dtfilter = _dtMaster;
            _dtresult = new DataTable();
            _dtresult.Columns.Add("so_no", typeof(string));
            _dtresult.Columns.Add("so_id", typeof(string));
            _dtresult.Columns.Add("srv_name", typeof(string));
            _dtresult.Columns.Add("subject", typeof(string));
            _dtresult.Columns.Add("comments", typeof(string));
            _dtresult.Columns.Add("details", typeof(string));
            _dtresult.Columns.Add("issued_to", typeof(string));
            _dtresult.Columns.Add("issue_date", typeof(string));
            _dtresult.Columns.Add("compl_date", typeof(string));
            _dtresult.Columns.Add("doc_name", typeof(string));
            _dtresult.Columns.Add("uid", typeof(string));
            _dtresult.Columns.Add("response", typeof(string));
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
                          where o.Field<string>("srv_name") == _el1
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("srv_name") == _el1 && o.Field<string>("issued_to") == _el2
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("srv_name") == _el1 && o.Field<string>("issued_to") == _el2 && o.Field<string>("subject") == _el3
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("srv_name") == _el1 && o.Field<string>("issued_to") == _el2 && o.Field<string>("subject") == _el3 && o.Field<string>("issue_date") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("issued_to") == _el2
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("issued_to") == _el2 && o.Field<string>("subject") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("issued_to") == _el2 && o.Field<string>("subject") == _el3 && o.Field<string>("issue_date") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("subject") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("subject") == _el3 && o.Field<string>("issue_date") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("issue_date") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("srv_name") == _el1 && o.Field<string>("subject") == _el3
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("srv_name") == _el1 && o.Field<string>("subject") == _el3 && o.Field<string>("issue_date") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("srv_name") == _el1 && o.Field<string>("issue_date") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("issued_to") == _el2 && o.Field<string>("issue_date") == _el4
                          select o;
            }


            if (lblprj.Text == "ASAO")
            {
                DataTable _dtcdate = new DataTable();
                if (_filter.Count<DataRow>()>0)
                {

                    _dtcdate = _filter.CopyToDataTable<DataRow>();
                }
                if (dr_dtcom.Text == "Blank")
                {
                    _filter = from o in _dtcdate.AsEnumerable()
                              where o.Field<string>("compl_date") == ""
                              select o;
                }
                else if (dr_dtcom.Text != "All")
                {
                    _filter = from o in _dtcdate.AsEnumerable()
                              where o.Field<string>("compl_date") == dr_dtcom.Text
                              select o;

                }

            }



            foreach (var row in _filter)
            {
                DataRow _row = _dtresult.NewRow();
                _row[0] = row["so_no"].ToString();
                _row[1] = row["so_id"].ToString();
                _row[2] = row["srv_name"].ToString();
                _row[3] = row["subject"].ToString();
                _row[4] = row["comments"].ToString();
                _row[5] = row["details"].ToString();
                _row[6] = row["issued_to"].ToString();
                _row[7] = row["issue_date"].ToString();
                _row[8] = row["compl_date"].ToString();
                _row[9] = row["doc_name"].ToString();
                _row[10] = row["uid"].ToString();
                _row[11] = row["response"].ToString();
                _dtresult.Rows.Add(_row);
            }
            //m.DataSource = _dtresult;
            //mygrid.DataBind();
            Load_SO_Details();

        }
        protected void dr_service_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ser"] = dr_service.SelectedItem.Value;
            Filtering(dr_service.SelectedItem.Text, dr_action.SelectedItem.Text, dr_building.SelectedItem.Text, dr_dtsub.SelectedItem.Text, dr_dtcom.SelectedItem.Text);
        }
       
        protected void mygrid_dr_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _idx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mygrid_dr.Rows[_idx];
            TableCell _id = _srow.Cells[12];
            TableCell _file = _srow.Cells[13];
            TableCell _no = _srow.Cells[11];
            Session["docid"] = _id.Text;
            Session["file"] = _file.Text;
            Session["head"] = "Commissioning Snag" + " :- " + _no.Text;
            _Create_Cookies();
            if (e.CommandName == "get")
            {

                // lbldrno.Text = _btn.Text;
                //mydiv.Visible = true;
                //load_doc_review_details();
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('sodetails.aspx','','left=210,top=100,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=0');", true);
                //string _prm = "sodetails.aspx?id=" + _drid.Text + "_P" + lblprj.Text;
                //Response.Redirect(_prm);
                //riptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('','5');", true);
                _file.Text = _file.Text.Replace("&amp;", "&");
                string _path = "https://cmltechniques.com/CMS_DOCS/" + (string)Session["project"] + "/" + _file.Text;
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _path + "','10');", true);
                
                //Response.Redirect(_path);
            }
            else if (e.CommandName == "status")
            {
                string _prm = _id.Text + "_P" + lblprj.Text;
                Response.Redirect("soadd1.aspx?id=" + _prm);
            }
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

        protected void mygrid_dr_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
                e.Row.Cells[10].Enabled = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (Convert.ToInt32(e.Row.Cells[9].Text) > 0 && e.Row.Cells[8].Text == "OPEN")
                //    e.Row.Style.Add("color", "red");
                //else
                //    e.Row.Cells[9].Text = "";
                //if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
                //    e.Row.Cells[10].Enabled = false;
                e.Row.Cells[0].Text = (e.Row.RowIndex + 1).ToString();
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsSO _objcls = new _clsSO();
            _objcls.so_id = Convert.ToInt32((string)Session["soid"]);
            if (sostatus1.SelectedItem.Text == "OPEN")
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
            _objbll.SO_Dir(_objcls, _objdb);
            load_so_dir((string)Session["project"]);
            Load_SO_Details();
            btnDummy_ModalPopupExtender1.Hide();
        }

        protected void btncancel1_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender1.Hide();
        }

        protected void btnprint_Click(object sender, ImageClickEventArgs e)
        {
            //Session["fsrv"] = dr_service.SelectedItem.Text;
            //Session["frev"] = drreview.SelectedItem.Text;
            //Session["fiss"] = drissue.SelectedItem.Text;
            //Session["fsts"] = drstatus.SelectedItem.Text;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('Reports.aspx?id=som1','','left=200,top=50,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
        }

        protected void btnadd_Click1(object sender, EventArgs e)
        {
            Response.Redirect("soadd1.aspx?id=0_P" + lblprj.Text);
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {

        }

        protected void dr_building_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["bul"] = dr_building.SelectedItem.Value;
            Filtering(dr_service.SelectedItem.Text, dr_action.SelectedItem.Text, dr_building.SelectedItem.Text, dr_dtsub.SelectedItem.Text, dr_dtcom.SelectedItem.Text);
        }

        protected void dr_dtsub_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["sub"] = dr_dtsub.SelectedItem.Value;
            Filtering(dr_service.SelectedItem.Text, dr_action.SelectedItem.Text, dr_building.SelectedItem.Text, dr_dtsub.SelectedItem.Text, dr_dtcom.SelectedItem.Text);
        }

        protected void dr_action_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["act"] = dr_action.SelectedItem.Value;
            Filtering(dr_service.SelectedItem.Text, dr_action.SelectedItem.Text, dr_building.SelectedItem.Text, dr_dtsub.SelectedItem.Text, dr_dtcom.SelectedItem.Text);
        }

        protected void dr_dtcom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["com"] = dr_dtcom.SelectedItem.Value;
            Filtering(dr_service.SelectedItem.Text, dr_action.SelectedItem.Text, dr_building.SelectedItem.Text, dr_dtsub.SelectedItem.Text, dr_dtcom.SelectedItem.Text);
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            //Session["fsrv"] = dr_service.SelectedItem.Text;
            //Session["frev"] = drreview.SelectedItem.Text;
            //Session["fiss"] = drissue.SelectedItem.Text;
            //Session["fsts"] = drstatus.SelectedItem.Text;

            //string _url="Reports.aspx?id=uso&prj="+lblprj.Text;

           // _dtreport = _dtresult;

            //_dtresult.TableName = "Comm_snag";
            //_dtresult.WriteXml(Server.MapPath("Comm_snag.xml"), true);

            Session["dtsoreport"] = _dtresult;

            Session["Discipline"]=dr_service.SelectedItem.Text;
            Session["Building"]=dr_building.SelectedItem.Text;
            Session["SubmitDate"]=dr_dtsub.SelectedItem.Text;
            Session["ActionBy"]=dr_action.SelectedItem.Text;
            Session["CompDate"]=dr_dtcom.SelectedItem.Text;

            if (lblprj.Text=="ASAO")
            {

                ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('ReportsNew.aspx?prj="+lblprj.Text+"&div=0&id=uso&sch=0','','left=200,top=50,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
            }
            else
            {

            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('Reports.aspx?id=uso&prj="+ lblprj.Text+"','','left=200,top=50,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
            }
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open(" +_url +",'left=200,top=50,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
        }

    }
}
