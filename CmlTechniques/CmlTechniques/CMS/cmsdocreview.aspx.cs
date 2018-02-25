using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Data;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

namespace CmlTechniques.CMS
{
    public partial class cmsdocreview : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtresult;
      
        protected void page_intial()
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();

            if (!IsPostBack)
            {
                string _prm = Request.QueryString["PRJ"].ToString();
                lblid.Text = (string)Session["uid"];
                lblprj.Text = _prm;
                GetAccess();
                SetAuthorizedControls();
                load_users(lblprj.Text);



                if (lblprj.Text == "14211" || lblprj.Text == "ARSD")
                    load_services_14211(lblprj.Text);
                else
                    load_services(lblprj.Text);
                //load_doc_review_log(lblprj.Text);
                //Load_Filtering_Elements();
                Session["ser"] = "All";
                Session["rew"] = "All";
                Session["iss"] = "All";
                Session["sta"] = "All";
                Session["bui"] = "All";

                if (Request.QueryString["ACN"].ToString() == "1")
                {
                    Session["ser"] = Request.QueryString["SER"].ToString();
                    Session["rew"] = Request.QueryString["RVW"].ToString();
                    Session["iss"] = Request.QueryString["ISS"].ToString();
                    Session["sta"] = Request.QueryString["STA"].ToString();
                    Session["bui"] = Request.QueryString["BUI"].ToString();
                    Filtering((string)Session["ser"], (string)Session["rew"], (string)Session["iss"], (string)Session["sta"], (string)Session["bui"]);
                }
                else
                {
                    load_doc_review_log(lblprj.Text);
                    Load_DocReview();
                }
               
                if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                {
                    Get_ProjectName();
                }
                else
                {
                    dvfixedhead.Visible = false;
                    dvfixedcontent.Style.Add("Top", "0px");
                }   
                if (lblNewProject.Text == "1")
                    LoadBuildingNames();
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

            if (tblAddDR.Visible)
            {
                foreach (DataRow dataRow in _dt.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem();

                    item.Text = (string)dataRow["PRJ_SER_NAME"];
                    item.Value = dataRow["PRJ_SER_ID"].ToString();
                    rcbPackage.Items.Add(item);
                }
                rcbPackage.DataBind();
            }

            foreach (DataRow dataRow in _dt.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();

                item.Text = (string)dataRow["PRJ_SER_NAME"];
                item.Value = dataRow["PRJ_SER_ID"].ToString();
                rcbService_Edit.Items.Add(item);
            }
            rcbService_Edit.DataBind();
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
            if (rcbPackage.SelectedItem == null)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Service');", true);
                return true;
            }
            else if (rcbBuilding.Visible && rcbBuilding.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Building');", true);
                return true;
            }
            else if (rtxtDocuments.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Enter Document(s)');", true);
                return true;
            }
            else if (rcbIssued.SelectedItem == null)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Issued To');", true);
                return true;
            }
            return false;
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
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = Project;
            _objcls.mode = 2;
          
            DataTable dtIssuedTo = _objbll.Load_CMS_Users(_objcls, _objdb);

            foreach (DataRow dataRow in dtIssuedTo.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();

                item.Text = (string)dataRow["uid"];
                item.Value = dataRow["uid"].ToString();
                rcbIssued.Items.Add(item);               
            }
            rcbIssued.DataBind();
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            if (Validation_AddNew() == true) return;
           
            int _max = mygrid_dr.Rows.Count - 1;
         
            Session["issued"] = rcbIssued.SelectedItem.Text;
            Session["service"] = rcbPackage.SelectedItem.Text;
            Session["doc"] = rtxtDocuments.Text;
            if (lblNewProject.Text == "1")
            {
                Session["bui"] = rcbBuilding.SelectedItem.Text;
                Session["buildingid"] = rcbBuilding.SelectedValue;
            }
            _Create_Cookies();
            if (lblprj.Text == "HPOB")
                Response.Redirect("DRAdd.aspx?id=0" + lblprj.Text);
            else
                Response.Redirect("../cmsdocreviewadd.aspx?type=0&id=0&PRJ=" + lblprj.Text + "&SER=" + dr_service.Text + "&RVW=" + drreview.Text + "&ISS=" + drissue.Text + "&STA=" + drstatus.Text + "&ACN=1&BUI=" + drbuilding.SelectedItem.Text);
        }
        protected void load_services(string Project)
        {
            DataTable _dtservice;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + Project;
            _dtservice = _objbll.Load_Cas_service(_objdb);

            if (tblAddDR.Visible)
            {
                foreach (DataRow dataRow in _dtservice.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem();

                    item.Text = (string)dataRow["PRJ_SER_NAME"];
                    item.Value = dataRow["PRJ_SER_ID"].ToString();
                    rcbPackage.Items.Add(item);
                }
                rcbPackage.DataBind();
            }

            foreach (DataRow dataRow in _dtservice.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();

                item.Text = (string)dataRow["PRJ_SER_NAME"];
                item.Value = dataRow["PRJ_SER_ID"].ToString();
                rcbService_Edit.Items.Add(item);
            }
            rcbService_Edit.DataBind();

            if (lblprj.Text == "HPOB")
            {
                RadComboBoxItem item = new RadComboBoxItem();
                item.Text = "MEP";
                item.Value = "MEP";
                rcbService_Edit.Items.Add(item);

                if (tblAddDR.Visible)
                {
                    RadComboBoxItem mepItem = new RadComboBoxItem();
                    mepItem.Text = "MEP";
                    mepItem.Value = "MEP";
                    rcbPackage.Items.Add(mepItem);
                    rcbPackage.DataBind();
                }
            }
            
        }
        protected void Insert_Doc_review_log()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_reviewed = rtxtDocuments.Text;
            _objcls.issued_date = DateTime.Now;
            if (rcbIssued.SelectedItem == null)
                _objcls.issued_to = "";
            else
                _objcls.issued_to = rcbIssued.SelectedItem.Text;
            _objcls.dr_status = true;//open
            _objcls.project_code = lblprj.Text;
            _objcls.uid = (string)Session["uid"];
            _objcls.mode = 1;
            if (rcbPackage.SelectedItem == null)
                _objcls.service = string.Empty;
            else
                _objcls.service = rcbPackage.SelectedItem.Text;
            _objbll.Document_Review_Log(_objcls, _objdb);
            load_doc_review_log(lblprj.Text);
            Load_DocReview();
        }
        private void load_doc_review_log(string Project)
        {
            ////DataTable _dtmaster = new DataTable();
            ////_dtmaster.Columns.Add(
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + Project;
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = Project;
            //if (rcbPackage.SelectedItem == null)
                _objcls.service = string.Empty;
            //else
            //    _objcls.service = rcbPackage.SelectedItem.Text;
            _dtMaster = _objbll.Load_Doc_review_log(_objcls, _objdb);

            //if(!_dtMaster.Columns.Contains("Closeout_Date"))
            // _dtMaster.Columns.Add("Closeout_Date");

            _dtresult = _dtMaster;

        }
        private void Load_Filtering_Elements()
        {
            dr_service.Items.Clear();
            drreview.Items.Clear();
            drissue.Items.Clear();
            drstatus.Items.Clear();
            drbuilding.Items.Clear();

            var _service = (from DataRow dRow in _dtresult.Rows
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
            var _reviewed = (from DataRow dRow in _dtresult.Rows
                             orderby dRow["userid"]
                             select new { col1 = dRow["userid"].ToString() }).Distinct();
            foreach (var row in _reviewed)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drreview.Items.Add(_itm);
            }
            drreview.DataBind();
            var _issued = (from DataRow dRow in _dtresult.Rows
                           orderby dRow["issued"]
                           select new { col1 = dRow["issued"] }).Distinct();
            foreach (var row in _issued)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drissue.Items.Add(_itm);
            }
            drissue.DataBind();
            var _status = (from DataRow dRow in _dtresult.Rows
                           orderby dRow["drstatus"]
                           select new { col1 = dRow["drstatus"] }).Distinct();
            foreach (var row in _status)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drstatus.Items.Add(_itm);
            }
            drstatus.DataBind();
            var _building = (from DataRow dRow in _dtresult.Rows
                             where (Server.HtmlDecode(dRow["building"].ToString()).Trim()) != string.Empty
                           orderby dRow["building"]
                           select new { col1 = dRow["building"] }).Distinct();
            foreach (var row in _building)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drbuilding.Items.Add(_itm);
            }
            drbuilding.DataBind();           

            dr_service.Items.Insert(0, "All");
            drreview.Items.Insert(0, "All");
            drissue.Items.Insert(0, "All");
            drstatus.Items.Insert(0, "All");
            drbuilding.Items.Insert(0, "All");

            if (dr_service.Items.Count == 1)
            {
                dr_service.Items.Insert(1, (string)Session["ser"]);
                drreview.Items.Insert(1, (string)Session["rew"]);
                drissue.Items.Insert(1, (string)Session["iss"]);
                drstatus.Items.Insert(1, (string)Session["sta"]);
                drbuilding.Items.Insert(1, (string)Session["bui"]);
            }

            dr_service.SelectedValue = (string)Session["ser"];
            drreview.SelectedValue = (string)Session["rew"];
            drissue.SelectedValue = (string)Session["iss"];
            drstatus.SelectedValue = (string)Session["sta"];
            drbuilding.SelectedValue = (string)Session["bui"];
        }
        private void Load_DocReview()
        {
            //myview.DataSource = _dtresult;
            //myview.DataBind();
            mygrid_dr.DataSource = _dtresult;
            mygrid_dr.DataBind();
            Load_Filtering_Elements();
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
                    //_prm = "cmsdocreview_details.aspx?id=" + _lbl.Text + "_P" + lblprj.Text;
                    _prm = "cmsdocreview_details.aspx?id=" + _lbl.Text + "&PRJ=" + lblprj.Text + "&SER=" + dr_service.Text + "&RVW=" + drreview.Text + "&ISS=" + drissue.Text + "&STA=" + drstatus.Text + "&ACN=1&BUI=" + drbuilding.SelectedItem.Text;
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
      
        private void Filtering(string _el1, string _el2, string _el3, string _el4, string _el5)
        {
            if (_el1 == "") _el1 = "All";
            if (_el2 == "") _el2 = "All";
            if (_el3 == "") _el3 = "All";
            if (_el4 == "") _el4 = "All";
            if (_el5 == "") _el5 = "All";
          
            load_doc_review_log(lblprj.Text);
            DataTable _dtfilter = _dtMaster;
            DataTable _dtresult1 = new DataTable();
            _dtresult1.Columns.Add("dr_no", typeof(string));
            _dtresult1.Columns.Add("dr_id", typeof(string));
            _dtresult1.Columns.Add("service", typeof(string));
            _dtresult1.Columns.Add("building", typeof(string));
            _dtresult1.Columns.Add("dr_reviewed", typeof(string));
            _dtresult1.Columns.Add("issue_date", typeof(string));
            _dtresult1.Columns.Add("uid", typeof(string));
            _dtresult1.Columns.Add("issued_to", typeof(string));
            _dtresult1.Columns.Add("comments", typeof(string));
            _dtresult1.Columns.Add("response", typeof(string));
            _dtresult1.Columns.Add("drstatus", typeof(string));
            _dtresult1.Columns.Add("Closeout_Date", typeof(string));
            _dtresult1.Columns.Add("due", typeof(string));
            _dtresult1.Columns.Add("issued", typeof(string));
            _dtresult1.Columns.Add("userid", typeof(string));

            var _filter = from o in _dtfilter.AsEnumerable()
                          select o;

            if (_el1 != "All")
            {
                _filter = from o in _filter
                          where o.Field<string>("service") == _el1
                          select o;
            }
            if (_el2 != "All")
            {
                _filter = from o in _filter
                          where o.Field<string>("userid") == _el2
                          select o;
            }
            if (_el3 != "All")
            {
                _filter = from o in _filter
                          where o.Field<string>("issued") == _el3
                          select o;
            }
            if (_el4 != "All")
            {
                _filter = from o in _filter
                          where o.Field<string>("drstatus") == _el4
                          select o;
            }
            if (_el5 != "All")
            {
                _filter = from o in _filter
                          where o.Field<string>("building") == _el5
                          select o;
            }            

            foreach (var row in _filter)
            {
                DataRow _row = _dtresult1.NewRow();
                _row[0] = row["dr_no"].ToString();
                _row[1] = row["dr_id"].ToString();
                _row[2] = row["service"].ToString();
                _row[3] = row["building"].ToString();
                _row[4] = row["dr_reviewed"].ToString();
                _row[5] = row["issue_date"].ToString();
                _row[6] = row["uid"].ToString();
                _row[7] = row["issued_to"].ToString();
                _row[8] = row["comments"].ToString();
                _row[9] = row["response"].ToString();
                _row[10] = row["drstatus"].ToString();
                _row[11] = row["Closeout_Date"].ToString();
                _row[12] = row["due"].ToString();
                _row[13] = row["issued"].ToString();
                _row[14] = row["userid"].ToString();
                _dtresult1.Rows.Add(_row);
            }
            //m.DataSource = _dtresult;
            //mygrid.DataBind();
            _dtresult = _dtresult1;
            Load_DocReview();

        }
        protected void dr_service_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ser"] = dr_service.SelectedItem.Value;
            Filtering(dr_service.SelectedItem.Text, drreview.SelectedItem.Text, drissue.SelectedItem.Text, drstatus.SelectedItem.Text, drbuilding.SelectedItem.Text);
        }
        protected void drbuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["bui"] = drbuilding.SelectedItem.Value;
            Filtering(dr_service.SelectedItem.Text, drreview.SelectedItem.Text, drissue.SelectedItem.Text, drstatus.SelectedItem.Text, drbuilding.SelectedItem.Text);
        }
        protected void drreview_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["rew"] = drreview.SelectedItem.Value;
            Filtering(dr_service.SelectedItem.Text, drreview.SelectedItem.Text, drissue.SelectedItem.Text, drstatus.SelectedItem.Text, drbuilding.SelectedItem.Text);
        }
        protected void drissue_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["iss"] = drissue.SelectedItem.Value;
            Filtering(dr_service.SelectedItem.Text, drreview.SelectedItem.Text, drissue.SelectedItem.Text, drstatus.SelectedItem.Text, drbuilding.SelectedItem.Text);
        }
        protected void drstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["sta"] = drstatus.SelectedItem.Value;
            Filtering(dr_service.SelectedItem.Text, drreview.SelectedItem.Text, drissue.SelectedItem.Text, drstatus.SelectedItem.Text, drbuilding.SelectedItem.Text);
        }

        protected void mygrid_dr_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[16].Visible = false;
                e.Row.Cells[14].Visible = false;
                e.Row.Cells[13].Visible = false;
                e.Row.Cells[15].Visible = false;
                e.Row.Cells[2].Visible = (lblNewProject.Text == "1")?true:false;
                e.Row.Cells[12].Visible = tblAddDR.Visible;

                e.Row.Cells[3].Text = Server.HtmlDecode(e.Row.Cells[3].Text);

                DateTime dt;
                if (DateTime.TryParse(e.Row.Cells[4].Text, out dt))
                {
                    e.Row.Cells[4].Text = DateTime.Parse(e.Row.Cells[4].Text).ToString("dd/MM/yyyy");
                }

                if (e.Row.Cells[9].Text == "OPEN")
                {
                    if (e.Row.Cells[11] != null && (Server.HtmlDecode(e.Row.Cells[11].Text).Trim() != string.Empty))
                    {
                        e.Row.Cells[11].Style.Add("color", "red");
                        e.Row.Cells[11].Text = e.Row.Cells[11].Text + "d";
                    }
                    else
                        e.Row.Cells[11].Text = "-";
                }
                else
                    e.Row.Cells[11].Text = "-";

                if (lblaccess.Text != "ADMIN GROUP" && lblaccess.Text != "SYS.ADMIN GROUP")
                    e.Row.Cells[12].Enabled = false;
                else
                {
                    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("btnEditStatus");
                    lnkEdit.CommandArgument = e.Row.RowIndex.ToString();
                }

                if (lblNewProject.Text == "1")
                {
                    if (e.Row.Cells[10] == null || (Server.HtmlDecode(e.Row.Cells[10].Text)).Trim() == string.Empty)
                    {
                        e.Row.Cells[10].Text = "-";
                    }
                }
                else
                {
                    e.Row.Cells[10].Visible = false;
                }                
            }            
        }

        protected void mygrid_dr_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _idx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mygrid_dr.Rows[_idx];
            TableCell _drid = _srow.Cells[14];
            TableCell _drno = _srow.Cells[13];
            TableCell _ser = _srow.Cells[1];
            TableCell _doc = _srow.Cells[3];
            TableCell _stat = _srow.Cells[9];
            TableCell _issueDate = _srow.Cells[4];
            Label2.Text = _drid.Text;
            if (e.CommandName == "get")
            {

                // lbldrno.Text = _btn.Text;
                //mydiv.Visible = true;
                //load_doc_review_details();
                string _prm = "";
                if (lblprj.Text == "HPOB")
                    _prm = "cmsdocumentreview_details1.aspx?id=" + _drid.Text + "_P" + lblprj.Text;
                else
                    // _prm = "cmsdocreview_details.aspx?id=" + _drid.Text + "_P" + lblprj.Text;
                    _prm = "cmsdocreview_details.aspx?id=" + _drid.Text + "&PRJ=" + lblprj.Text + "&SER=" + dr_service.Text + "&RVW=" + drreview.Text + "&ISS=" + drissue.Text + "&STA=" + drstatus.Text + "&ACN=1&BUI=" + drbuilding.SelectedItem.Text;

                //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _prm + "','','left=50,top=50,width=1300,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
                Response.Redirect(_prm);
            }
            else if (e.CommandName == "status")
            {
                txt_subject.Text = _doc.Text;
                if (_srow.Cells[9].Text == "OPEN")
                {
                    RadDatePicker_CloseDate.Clear();
                    RadDatePicker_CloseDate.Enabled = false;
                }
                else
                {
                    if (lblNewProject.Text == "1")
                    {
                        RadDatePicker_CloseDate.Enabled = true;
                        if (_srow.Cells[10] != null && _srow.Cells[10].Text != string.Empty && _srow.Cells[10].Text != "-")
                            RadDatePicker_CloseDate.SelectedDate = DateTime.ParseExact(_srow.Cells[10].Text, "dd/MM/yyyy", null);
                        else
                            RadDatePicker_CloseDate.Clear();
                    }
                    else
                    {
                        trCloseDate.Visible = false;
                    }                  
                }

                if (lblNewProject.Text == "1")
                {
                    string building = (_srow.Cells[2] == null) ? string.Empty : (Server.HtmlDecode(_srow.Cells[2].Text).Trim());
                    if (building != string.Empty)
                        rcbBuilding_Edit.Items.FindItemByText(building).Selected = true;
                    else
                        rcbBuilding_Edit.ClearSelection();
                }

                if (rcbService_Edit.Items.Count > 0) rcbService_Edit.SelectedValue = rcbService_Edit.Items.FindItemByText(_ser.Text).Value;
                if (sostatus1.Items.Count > 0) sostatus1.SelectedValue = sostatus1.Items.FindItemByText(_stat.Text).Value;
                string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);$find(\"" + RadWindow1.ClientID + "\").set_title('DR Details - " + _drno.Text + " '); ";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            ////ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + Label2.Text + "');", true);
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_reviewed = txt_subject.Text;
            _objcls.issued_date = DateTime.Now;//Convert.ToDateTime(txt_issuedate.Text);
            _objcls.issued_to = "";
            _objcls.project_code = "";
            _objcls.uid = "";
            _objcls.mode = 0;
            _objcls.dr_id = Convert.ToInt32(Label2.Text);
            _objcls.service = rcbService_Edit.SelectedItem.Text;           
            _objcls.Notes = "";


            if (sostatus1.SelectedItem.Text == "OPEN")
            {
                _objcls.dr_status = true;
                _objcls.closeout_date = "";
            }
            else
            {
                _objcls.dr_status = false;
                if (lblNewProject.Text == "1")
                {
                    if (RadDatePicker_CloseDate.SelectedDate.ToString() == string.Empty)
                        RadDatePicker_CloseDate.SelectedDate = DateTime.Now;
                    _objcls.closeout_date = Convert.ToDateTime(RadDatePicker_CloseDate.SelectedDate).ToShortDateString();
                    _objcls.closeout_date = DateTime.Parse(_objcls.closeout_date.ToString()).ToString("dd/MM/yyyy");
                }
                else
                    _objcls.closeout_date = string.Empty;
            }

            if (lblNewProject.Text == "1")
                _objcls.building = (rcbBuilding_Edit.SelectedValue != string.Empty) ? Convert.ToInt32(rcbBuilding_Edit.SelectedValue) : _objcls.building;

            string id = _objbll.Document_Review_Log(_objcls, _objdb);
            load_doc_review_log(lblprj.Text);
            //Load_DocReview();
            Filtering((string)Session["ser"], (string)Session["rew"], (string)Session["iss"], (string)Session["sta"], (string)Session["bui"]);

            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);


        }

        protected void btncancel1_Click(object sender, EventArgs e)
        {
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
        }


        protected void btnprint_Click(object sender, EventArgs e)
        {            
            Session["fsrv"] = dr_service.SelectedItem.Text;
            Session["frev"] = drreview.SelectedItem.Text;
            Session["fiss"] = drissue.SelectedItem.Text;
            Session["fsts"] = drstatus.SelectedItem.Text;
            Session["fbui"] = drbuilding.SelectedItem.Text;
            string _prm = "Reports.aspx?id=dlog0&idx=0&prj=" + lblprj.Text;
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _prm + "','','left=200,top=50,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
        }      

        protected void btnResetFilters_Click(object sender, EventArgs e)
        {
            load_doc_review_log(lblprj.Text);
            Session["ser"] = "All";
            Session["rew"] = "All";
            Session["iss"] = "All";
            Session["sta"] = "All";
            Session["bui"] = "All";
            Load_DocReview();
        }

        protected void drstatus1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sostatus1.SelectedValue == "OPEN")
            {
                RadDatePicker_CloseDate.Clear();
                RadDatePicker_CloseDate.Enabled = false;
            }
            else
            {
                RadDatePicker_CloseDate.SelectedDate = DateTime.Now;
                RadDatePicker_CloseDate.Enabled = true;
            }
        }

        protected void LoadBuildingNames()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = (string)Session["project"];
            _objdb.DBName = "DB_" + Session["project"].ToString(); ;
            DataTable dtBuildings = _objbll.Load_Buildings(_objcls, _objdb);


            foreach (DataRow dr in dtBuildings.Rows)
            {
                RadComboBoxItem cbBuildingItem = new RadComboBoxItem();
                cbBuildingItem.Text = dr["Build_Name"].ToString();
                cbBuildingItem.Value = dr["Build_id"].ToString();
                rcbBuilding.Items.Add(cbBuildingItem);
            }
            rcbBuilding.DataBind();

            foreach (DataRow dr in dtBuildings.Rows)
            {
                RadComboBoxItem cbBuildingItem = new RadComboBoxItem();
                cbBuildingItem.Text = dr["Build_Name"].ToString();
                cbBuildingItem.Value = dr["Build_id"].ToString();
                rcbBuilding_Edit.Items.Add(cbBuildingItem);
            }
            rcbBuilding_Edit.DataBind();
        }

        protected void sostatus1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sostatus1.SelectedValue == "OPEN")
            {
                RadDatePicker_CloseDate.Clear();
                RadDatePicker_CloseDate.Enabled = false;
            }
            else
            {
                RadDatePicker_CloseDate.SelectedDate = DateTime.Now;
                RadDatePicker_CloseDate.Enabled = true;
            }
        }

        private void SetAuthorizedControls()
        {
            tblAddDR.Visible = (lblaccess.Text == "ADMIN GROUP" || lblaccess.Text == "SYS.ADMIN GROUP");
            lblNewProject.Text = (lblprj.Text == "HMIM" || lblprj.Text == "HMHS" || lblprj.Text == "AZC" || lblprj.Text == "123" || lblprj.Text == "demo") ? "1" : "0";
            bool isNewProject = (lblNewProject.Text == "0") ? false : true;

            tdCloseDateHeader.Visible = isNewProject;
            tdBuildingHeader.Visible = isNewProject;
            tdCloseDateFilter.Visible = isNewProject;
            tdBuildingFilter.Visible = isNewProject;
            trCloseDate.Visible = isNewProject;
            tdBuildingAdd.Visible = isNewProject;
            trBuildingEdit.Visible = isNewProject;

            tdEditDRHeader.Visible = tblAddDR.Visible;
            tdEditDRFilter.Visible = tblAddDR.Visible;
        }
    }
}
