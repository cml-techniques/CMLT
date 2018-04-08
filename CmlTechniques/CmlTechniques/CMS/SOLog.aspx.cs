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
using Telerik.Web.UI;
using BusinessLogic;
using App_Properties;
using System.Drawing;
using Constants;

namespace CmlTechniques.CMS
{
    public partial class SOLog : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtresult;
        public bool isNewProject;  
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString["PRJ"].ToString();
                lblprj.Text = _prm;
                lblid.Text = (string)Session["uid"];
                GetAccess();
                SetAuthorizedControls();
                if(tblAdd.Visible)
                load_users(_prm);

                if (lblprj.Text == "14211" || lblprj.Text == "ARSD")
                {
                    load_services_14211(lblprj.Text);
                }
                else
                {
                    load_services(lblprj.Text);
                }               

                

                if (lblNewProject.Text == "1")    
                   LoadBuildingNames();
                
                if (Request.QueryString["ACN"].ToString() == "1")
                {
                    grdSOLog.MasterTableView.GetColumn("package").CurrentFilterValue = Request.QueryString["SER"].ToString();
                    grdSOLog.MasterTableView.GetColumn("userid").CurrentFilterValue = Request.QueryString["RVW"].ToString();
                    grdSOLog.MasterTableView.GetColumn("issued").CurrentFilterValue = Request.QueryString["ISS"].ToString();
                    grdSOLog.MasterTableView.GetColumn("drstatus").CurrentFilterValue = Request.QueryString["STA"].ToString();
                    if (lblNewProject.Text == "1")
                    {
                        grdSOLog.MasterTableView.GetColumn("building").CurrentFilterValue = Request.QueryString["building"].ToString();
                        RadComboBoxBuilding.SelectedValue = Request.QueryString["building"].ToString();
                    }

                    if (Request.QueryString["filter"] != null)
                        grdSOLog.MasterTableView.FilterExpression = Request.QueryString["filter"].ToString();

                    RadComboBoxService.SelectedValue = Request.QueryString["SER"].ToString();
                    RadComboBoxRecordedBy.SelectedValue = Request.QueryString["RVW"].ToString();
                    RadComboBoxIssuedTo.SelectedValue = Request.QueryString["ISS"].ToString();
                    RadComboBoxStatus.SelectedValue = Request.QueryString["STA"].ToString();
                    
                }

                load_so_dir(_prm);
                Load_SO_Details();

                
            
                if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                {
                    Get_ProjectName();  
                    dvGrid.Style["top"] = "111px";
                }
                else
                {
                    dvfixedhead.Visible = false;
                    dvGrid.Style["top"] = "81px";
                }           
            }
            else
            {
                load_so_dir();
            }

            isNewProject = (Array.IndexOf(Constants.CMLTConstants.recentProjects, lblprj.Text) > -1) ? true : false;
        }

        protected void load_so_dir()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            grdSOLog.DataSource = _objbll.Load_so_dir(_objcls, _objdb); ;
            grdSOLog.DataBind();
        }

        protected void grdSOLog_ItemDataBound(object sender, GridItemEventArgs e)
        {
           if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
               
                Label lbl = (Label) e.Item.FindControl("lblSubject");
                lbl.Text = lbl.Text.Replace("\n", " <br /> "); 
                //item["doc_name"].Text = Server.HtmlDecode(item["doc_name"].Text);

                if (item["drstatus"].Text == "OPEN")
                {
                    if (lblNewProject.Text == "1")
                    item["Closeout_Date"].Text = "-";                    
                    
                    if (item["due"] != null && (Server.HtmlDecode(item["due"].Text).Trim()!= string.Empty))
                    {
                        item["due"].ForeColor = System.Drawing.Color.Red;
                        item["due"].Text = item["due"].Text + "d";
                    }
                    else
                        item["due"].Text = "-";                
                }
                else
                {
                    if (lblNewProject.Text == "1")
                    {
                        DateTime temp;
                        if (DateTime.TryParse(item["Closeout_Date"].Text, out temp))
                        {
                            item["Closeout_Date"].Text = DateTime.Parse(item["Closeout_Date"].Text).ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            item["Closeout_Date"].Text = item["Closeout_Date"].Text;
                        }
                    }
                    item["due"].Text = "-";
                    item["due"].ForeColor = System.Drawing.Color.Black;
                }
            }

           if(e.Item.ItemType == GridItemType.Footer)
           {              
                   DataTable dtFilters = new DataTable();
                   dtFilters.Columns.Add("package");
                   dtFilters.Columns.Add("building");
                   dtFilters.Columns.Add("userid");
                   dtFilters.Columns.Add("issued");
                   dtFilters.Columns.Add("drstatus");
                   DataRow dr;

                   RadComboBoxService.Items.Clear();
                   RadComboBoxBuilding.Items.Clear();
                   RadComboBoxRecordedBy.Items.Clear();
                   RadComboBoxIssuedTo.Items.Clear();
                   RadComboBoxStatus.Items.Clear();

                   RadComboBoxItem cbDefaultServiceItem = new RadComboBoxItem();
                   cbDefaultServiceItem.Text = "All";
                   cbDefaultServiceItem.Value = "";
                   RadComboBoxService.Items.Add(cbDefaultServiceItem);                   

                   RadComboBoxItem cbDefaultUserItem = new RadComboBoxItem();
                   cbDefaultUserItem.Text = "All";
                   cbDefaultUserItem.Value = "";
                   RadComboBoxRecordedBy.Items.Add(cbDefaultUserItem);

                   RadComboBoxItem cbDefaultIssuedItem = new RadComboBoxItem();
                   cbDefaultIssuedItem.Text = "All";
                   cbDefaultIssuedItem.Value = "";
                   RadComboBoxIssuedTo.Items.Add(cbDefaultIssuedItem);

                   RadComboBoxItem cbDefaultStatusItem = new RadComboBoxItem();
                   cbDefaultStatusItem.Text = "All";
                   cbDefaultStatusItem.Value = "";
                   RadComboBoxStatus.Items.Add(cbDefaultStatusItem);

                   if (lblNewProject.Text == "1")
                   {
                       RadComboBoxItem cbDefaultBuildingItem = new RadComboBoxItem();
                       cbDefaultBuildingItem.Text = "All";
                       cbDefaultBuildingItem.Value = "";
                       RadComboBoxBuilding.Items.Add(cbDefaultBuildingItem);
                   }

                   foreach (GridDataItem item in grdSOLog.MasterTableView.Items)
                   {
                       dr = dtFilters.NewRow();
                       dr["package"] = item["package"].Text;
                       dr["building"] = item["Building"].Text;
                       dr["userid"] = item["userid"].Text;
                       dr["issued"] = item["issued"].Text;
                       dr["drstatus"] = item["drstatus"].Text;
                       dtFilters.Rows.Add(dr);
                   }
                   if (dtFilters.Rows.Count > 0)
                   {
                       var _service = (from DataRow dRow in dtFilters.Rows
                                       orderby dRow["package"]
                                       select new { col1 = dRow["package"] }).Distinct();

                       foreach (var row in _service)
                       {
                           RadComboBoxItem cbcbServiceItem = new RadComboBoxItem();
                           cbcbServiceItem.Text = row.col1.ToString();
                           cbcbServiceItem.Value = row.col1.ToString();
                           RadComboBoxService.Items.Add(cbcbServiceItem);
                       }

                       RadComboBoxService.DataBind();

                       if (lblNewProject.Text == "1")
                       {                     

                           var _building = (from DataRow dRow in dtFilters.Rows
                                            where (Server.HtmlDecode(dRow["building"].ToString()).Trim()) != string.Empty
                                            orderby dRow["building"]
                                            select new { col1 = dRow["building"] }).Distinct();

                           foreach (var row in _building)
                           {
                               RadComboBoxItem cbBuildingItem = new RadComboBoxItem();
                               cbBuildingItem.Text = row.col1.ToString();
                               cbBuildingItem.Value = row.col1.ToString();
                               RadComboBoxBuilding.Items.Add(cbBuildingItem);
                           }

                           RadComboBoxBuilding.DataBind();
                       }

                       var _reviewed = (from DataRow dRow in dtFilters.Rows
                                        orderby dRow["userid"]
                                        select new { col1 = dRow["userid"] }).Distinct();
                       foreach (var row in _reviewed)
                       {
                           RadComboBoxItem cbRecordedByItem = new RadComboBoxItem();
                           cbRecordedByItem.Text = row.col1.ToString();
                           cbRecordedByItem.Value = row.col1.ToString();
                           RadComboBoxRecordedBy.Items.Add(cbRecordedByItem);
                       }
                       RadComboBoxRecordedBy.DataBind();

                       var _issued = (from DataRow dRow in dtFilters.Rows
                                      orderby dRow["issued"]
                                      select new { col1 = dRow["issued"] }).Distinct();
                       foreach (var row in _issued)
                       {
                           RadComboBoxItem cbIssuedToItem = new RadComboBoxItem();
                           cbIssuedToItem.Text = row.col1.ToString();
                           cbIssuedToItem.Value = row.col1.ToString();
                           RadComboBoxIssuedTo.Items.Add(cbIssuedToItem);
                       }
                       RadComboBoxIssuedTo.DataBind();

                       var _status = (from DataRow dRow in dtFilters.Rows
                                      orderby dRow["drstatus"]
                                      select new { col1 = dRow["drstatus"] }).Distinct();
                       foreach (var row in _status)
                       {
                           RadComboBoxItem cbStatusItem = new RadComboBoxItem();
                           cbStatusItem.Text = row.col1.ToString();
                           cbStatusItem.Value = row.col1.ToString();
                           RadComboBoxStatus.Items.Add(cbStatusItem);
                       }
                       RadComboBoxStatus.DataBind();
                   }
                   if (grdSOLog.MasterTableView.FilterExpression != string.Empty)
                   {
                       if (RadComboBoxService.Items.Count == 1)
                       {
                           RadComboBoxItem cbService = new RadComboBoxItem();
                           cbService.Text = grdSOLog.MasterTableView.GetColumn("package").CurrentFilterValue;
                           cbService.Value = grdSOLog.MasterTableView.GetColumn("package").CurrentFilterValue;
                           RadComboBoxService.Items.Add(cbService);

                           RadComboBoxItem cbUser = new RadComboBoxItem();
                           cbUser.Text = grdSOLog.MasterTableView.GetColumn("userid").CurrentFilterValue;
                           cbUser.Value = grdSOLog.MasterTableView.GetColumn("userid").CurrentFilterValue;
                           RadComboBoxRecordedBy.Items.Add(cbUser);

                           RadComboBoxItem cbIssued = new RadComboBoxItem();
                           cbIssued.Text = grdSOLog.MasterTableView.GetColumn("issued").CurrentFilterValue;
                           cbIssued.Value = grdSOLog.MasterTableView.GetColumn("issued").CurrentFilterValue;
                           RadComboBoxIssuedTo.Items.Add(cbIssued);

                           RadComboBoxItem cbStatus = new RadComboBoxItem();
                           cbStatus.Text = grdSOLog.MasterTableView.GetColumn("drstatus").CurrentFilterValue;
                           cbStatus.Value = grdSOLog.MasterTableView.GetColumn("drstatus").CurrentFilterValue;
                           RadComboBoxStatus.Items.Add(cbStatus);

                           if (lblNewProject.Text == "1")
                           {
                               RadComboBoxItem cbBuilding = new RadComboBoxItem();
                               cbBuilding.Text = grdSOLog.MasterTableView.GetColumn("building").CurrentFilterValue;
                               cbBuilding.Value = grdSOLog.MasterTableView.GetColumn("building").CurrentFilterValue;
                               RadComboBoxBuilding.Items.Add(cbBuilding);
                           }
                       }                     
                   }              
           }

           if (e.Item.ItemType == GridItemType.FilteringItem)
           {
               RadComboBoxService.SelectedValue = ((grdSOLog.MasterTableView.GetColumn("package").CurrentFilterValue) != string.Empty) ? (grdSOLog.MasterTableView.GetColumn("package").CurrentFilterValue) :"";
               RadComboBoxRecordedBy.SelectedValue = ((grdSOLog.MasterTableView.GetColumn("userid").CurrentFilterValue) != string.Empty) ? (grdSOLog.MasterTableView.GetColumn("userid").CurrentFilterValue) : "";
               RadComboBoxIssuedTo.SelectedValue = ((grdSOLog.MasterTableView.GetColumn("issued").CurrentFilterValue) != string.Empty) ? (grdSOLog.MasterTableView.GetColumn("issued").CurrentFilterValue) : "";
               RadComboBoxStatus.SelectedValue = ((grdSOLog.MasterTableView.GetColumn("drstatus").CurrentFilterValue) != string.Empty) ? (grdSOLog.MasterTableView.GetColumn("drstatus").CurrentFilterValue) : "";
               if (lblNewProject.Text == "1")
                   RadComboBoxBuilding.SelectedValue = ((grdSOLog.MasterTableView.GetColumn("building").CurrentFilterValue) != string.Empty) ? (grdSOLog.MasterTableView.GetColumn("building").CurrentFilterValue) : "";
           }

        }

        protected void grdSOLog_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.Item.ItemType != GridItemType.FilteringItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                LinkButton lnk = (LinkButton)item["so_no"].Controls[0];

                if (e.CommandName == "StatusEdit")
                {
                    string _sono = lnk.Text;
                    txt_subject.Attributes.Add("so_id", DataBinder.Eval(e.Item.DataItem, "so_id").ToString());
                    Label lbl = (Label)e.Item.FindControl("lblSubject");
                    txt_subject.Text = lbl.Text.Replace(" <br /> ", "\n"); 

                    if (rcbService_Edit.Items.Count > 0) rcbService_Edit.SelectedValue = rcbService_Edit.Items.FindItemByText(item["package"].Text).Value;
                    if (sostatus1.Items.Count > 0) sostatus1.SelectedValue = sostatus1.Items.FindItemByText(item["drstatus"].Text).Value;

                    if (lblNewProject.Text == "1")
                    {
                        if (item["drstatus"].Text == "OPEN")
                        {
                            RadDatePicker_CloseDate.Clear();
                            RadDatePicker_CloseDate.Enabled = false;
                        }
                        else
                        {
                            if (item["Closeout_Date"].Text != null && (Server.HtmlDecode(item["Closeout_Date"].Text).Trim() != string.Empty) && item["Closeout_Date"].Text != "-")
                                RadDatePicker_CloseDate.SelectedDate = DateTime.ParseExact(item["Closeout_Date"].Text, "dd/MM/yyyy", null);
                        }

                        string building = (item["Building"] == null) ? string.Empty : (Server.HtmlDecode(item["Building"].Text).Trim());
                        if (building != string.Empty)
                            rcbBuilding_Edit.Items.FindItemByText(building).Selected = true;
                        else
                            rcbBuilding_Edit.ClearSelection();
                    }
                    else
                    {
                        RadDatePicker_CloseDate.Visible = false;
                        trcdate.Visible = false;
                    }

                    string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);$find(\"" + RadWindow1.ClientID + "\").set_title('SO Details - " + _sono + " '); ";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
                }
                else if (e.CommandName == "SOEdit")
                {
                    string _service = grdSOLog.MasterTableView.GetColumn("package").CurrentFilterValue;
                    string _recordedby = grdSOLog.MasterTableView.GetColumn("userid").CurrentFilterValue;
                    string _issuedto = grdSOLog.MasterTableView.GetColumn("issued").CurrentFilterValue;
                    string _status = grdSOLog.MasterTableView.GetColumn("drstatus").CurrentFilterValue;
                    string _fil = "&filter=" + grdSOLog.MasterTableView.FilterExpression.ToString();
                    string _filter = "&SER=" + _service + "&RVW=" + _recordedby + "&ISS=" + _issuedto + "&STA=" + _status + "&ACN=1" + _fil;

                    string _prm = "id=" + DataBinder.Eval(e.Item.DataItem, "so_id").ToString() + "&PRJ=" + lblprj.Text + _filter;

                    if (lblNewProject.Text == "1")
                    {
                        string _building = grdSOLog.MasterTableView.GetColumn("building").CurrentFilterValue;
                        _prm = _prm + "&building=" + _building;
                    }

                 if (isNewProject)
                    //if (lblprj.Text == "123" || lblprj.Text == "Traini" || lblprj.Text == "demo" || lblprj.Text == "HMIM" || lblprj.Text == "HMHS" || lblprj.Text == "MOE" || lblprj.Text == "11784" || lblprj.Text == "AZC" || lblprj.Text == "NCP")
                        Response.Redirect("sodetails_new.aspx?" + _prm);
                    else
                    {
                        Response.Redirect("sodetails.aspx?" + _prm);
                    }
                }
            }
        }

        protected void btnResetFilters_Click(object sender, EventArgs e)
        {
            load_so_dir(lblprj.Text);
            Load_SO_Details();
            grdSOLog.MasterTableView.FilterExpression = string.Empty;

            foreach (GridColumn column in grdSOLog.MasterTableView.RenderColumns)
            {
                if (column is GridBoundColumn)
                {
                    GridBoundColumn boundColumn = column as GridBoundColumn;
                    boundColumn.CurrentFilterValue = string.Empty;
                }
            }
            grdSOLog.MasterTableView.Rebind();
            RadComboBoxService.SelectedValue = "";
            RadComboBoxRecordedBy.SelectedValue = "";
            RadComboBoxIssuedTo.SelectedValue = "";
            RadComboBoxStatus.SelectedValue = "";
           
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {           
            Session["fsrv"] = RadComboBoxService.SelectedItem.Text;
            Session["frev"] = (RadComboBoxRecordedBy.SelectedItem.Text).Trim(); ;
            Session["fiss"] = (RadComboBoxIssuedTo.SelectedItem.Text).Trim();
            Session["fsts"] = RadComboBoxStatus.SelectedItem.Text;
            if (lblNewProject.Text == "1")
                Session["fbui"] = RadComboBoxBuilding.SelectedItem.Text;
            else
                Session["fbui"] = "All";

            string _prm = "Reports.aspx?id=som1&idx=0&prj=" + lblprj.Text;
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _prm + "','','left=200,top=50,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {

            if (Validation_AddNew() == true) return;
            Session["issued"] = rcbIssued.SelectedItem.Text;
            Session["service"] = rcbPackage.SelectedItem.Text;
            Session["doc"] = rtxtSubject.Text;

            string _service = grdSOLog.MasterTableView.GetColumn("package").CurrentFilterValue;            
            string _recordedby = grdSOLog.MasterTableView.GetColumn("userid").CurrentFilterValue;
            string _issuedto = grdSOLog.MasterTableView.GetColumn("issued").CurrentFilterValue;
            string _status = grdSOLog.MasterTableView.GetColumn("drstatus").CurrentFilterValue;
            string _fil = "&filter="+ grdSOLog.MasterTableView.FilterExpression.ToString();
            string _filter = "&SER=" + _service + "&RVW=" + _recordedby + "&ISS=" + _issuedto + "&STA=" + _status + "&ACN=1" + _fil ;

            if (lblNewProject.Text == "1")
            {
                string _building = grdSOLog.MasterTableView.GetColumn("building").CurrentFilterValue;
                _filter = _filter + "&building=" + _building + "&buildid=" + rcbBuilding.SelectedValue + "&build=" + rcbBuilding.SelectedItem.Text;

            }
            string _prm = "soadd.aspx?id=0" + "&PRJ=" + lblprj.Text + _filter;
            _Create_Cookies();
            Response.Redirect(_prm);
        }

        private bool Validation_AddNew()
        {
            if (rcbPackage.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Service');", true);
                return true;
            }
            else if (rcbBuilding.Visible && rcbBuilding.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Building');", true);
                return true;
            }
            else if (rtxtSubject.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Enter Subject');", true);
                return true;
            }
            else if (rcbIssued.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Issued To');", true);
                return true;
            }
            return false;
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

        protected void load_users(string Project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            _objcls.mode = 6;
            DataTable dtIssuedTo = _objbll.Load_CMS_Users(_objcls, _objdb);

            foreach (DataRow dataRow in dtIssuedTo.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();

                item.Text = (string)dataRow["uid"];
                item.Value = dataRow["uid"].ToString();
                rcbIssued.Items.Add(item);
                item.DataBind();
            }
        }
       
        protected void load_services(string Project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + Project;
            DataTable _soservice = _objbll.Load_Cas_service(_objdb);

            if (tblAdd.Visible)
            {
                foreach (DataRow dataRow in _soservice.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem();

                    item.Text = (string)dataRow["PRJ_SER_NAME"];
                    item.Value = dataRow["SYS_SER_ID"].ToString();
                    rcbPackage.Items.Add(item);
                }

                if (lblprj.Text == "HPOB")
                {
                    RadComboBoxItem mepItem = new RadComboBoxItem();
                    mepItem.Text = "MEP";
                    mepItem.Value = "MEP";
                    rcbPackage.Items.Add(mepItem);
                }
                rcbPackage.DataBind();
            }

            foreach (DataRow dataRow in _soservice.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();

                item.Text = (string)dataRow["PRJ_SER_NAME"];
                item.Value = dataRow["SYS_SER_ID"].ToString();
                rcbService_Edit.Items.Add(item);
            }
            rcbService_Edit.DataBind();
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

        protected void load_so_dir(string Project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + Project;
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = Project;
            _dtMaster = _objbll.Load_so_dir(_objcls, _objdb);
            _dtresult = _dtMaster;
        }

        private void Load_SO_Details()
        {
            grdSOLog.DataSource = _dtresult;
            grdSOLog.DataBind();
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

        protected void load_services_14211(string Project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + Project;
            DataTable _soservice = _objbll.Load_Cas_service_drso(_objdb);

            foreach (DataRow dataRow in _soservice.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();

                item.Text = (string)dataRow["PRJ_SER_NAME"];
                item.Value = dataRow["PRJ_SER_ID"].ToString();
                rcbPackage.Items.Add(item);
            }          
            rcbPackage.DataBind();

            foreach (DataRow dataRow in _soservice.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();

                item.Text = (string)dataRow["PRJ_SER_NAME"];
                item.Value = dataRow["PRJ_SER_ID"].ToString();
                rcbService_Edit.Items.Add(item);
            }
            rcbService_Edit.DataBind();
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

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsSO _objcls = new _clsSO();
            _objcls.so_id = Convert.ToInt32(txt_subject.Attributes["so_id"].ToString());
            if (sostatus1.SelectedItem.Text == "OPEN")
                _objcls.status = true;
            else
            {
                _objcls.status = false;
                if (lblNewProject.Text == "1")
                {
                    if (RadDatePicker_CloseDate.SelectedDate.ToString() == string.Empty)
                        RadDatePicker_CloseDate.SelectedDate = DateTime.Now;
                    _objcls.cdate = Convert.ToDateTime(RadDatePicker_CloseDate.SelectedDate).ToShortDateString();
                    _objcls.cdate = DateTime.Parse(_objcls.cdate.ToString()).ToString("dd/MM/yyyy");
                }
            }
            _objcls.mode = 0;
            _objcls.package = rcbService_Edit.SelectedItem.Text;
            _objcls.doc_name = txt_subject.Text;
            _objcls.so_date = DateTime.Now;
            _objcls.issued_to = "";
            _objcls.issued_date = DateTime.Now;
            _objcls.remarks = "";
            _objcls.project_code = "";
            _objcls.uid = "";
            if (lblNewProject.Text == "1")
                _objcls.so_building = (rcbBuilding_Edit.SelectedValue != string.Empty) ? Convert.ToInt32(rcbBuilding_Edit.SelectedValue) : _objcls.so_building;

            _objbll.SO_Dir(_objcls, _objdb);
           
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);

            load_so_dir(lblprj.Text);
            Load_SO_Details();

            grdSOLog.DataSource = _dtresult;
            grdSOLog.Rebind();
        }

        protected void btncancel1_Click(object sender, EventArgs e)
        {
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
        }

        protected void LoadBuildingNames()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = (string)lblprj.Text; ;
            _objdb.DBName = "DB_" + lblprj.Text;
            DataTable dtBuildings = _objbll.Load_Buildings(_objcls, _objdb);

            if (tblAdd.Visible)
            {
                foreach (DataRow dr in dtBuildings.Rows)
                {
                    RadComboBoxItem cbBuildingItem = new RadComboBoxItem();
                    cbBuildingItem.Text = dr["Build_Name"].ToString();
                    cbBuildingItem.Value = dr["Build_id"].ToString();
                    rcbBuilding.Items.Add(cbBuildingItem);
                }
                rcbBuilding.DataBind();
            }

            foreach (DataRow dr in dtBuildings.Rows)
            {
                RadComboBoxItem cbBuildingItem = new RadComboBoxItem();
                cbBuildingItem.Text = dr["Build_Name"].ToString();
                cbBuildingItem.Value = dr["Build_id"].ToString();
                rcbBuilding_Edit.Items.Add(cbBuildingItem);
            }
            rcbBuilding_Edit.DataBind();
        }

        private void SetAuthorizedControls()
        {           
                tblAdd.Visible = (lblaccess.Text == "ADMIN GROUP" || lblaccess.Text == "SYS.ADMIN GROUP");
                //lblNewProject.Text = (lblprj.Text == "HMIM" || lblprj.Text == "HMHS" || lblprj.Text == "AZC" ||  lblprj.Text == "123" || lblprj.Text == "demo") ? "1" : "0";
                //bool isNewProject = (lblNewProject.Text == "0") ? false : true;

                tdCloseDateHeader.Visible = isNewProject;
                tdCloseDateFilter.Visible = isNewProject;
                tdBuildingHeader.Visible = isNewProject;
                tdBuildingFilter.Visible = isNewProject;
                tdEditSOHeader.Visible = tblAdd.Visible;
                tdEditSOFilter.Visible = tblAdd.Visible;
                grdSOLog.MasterTableView.GetColumn("Closeout_Date").Visible = isNewProject;
                grdSOLog.MasterTableView.GetColumn("Building").Visible = isNewProject;
                grdSOLog.MasterTableView.GetColumn("so_id").Visible = tblAdd.Visible;
                trcdate.Visible = isNewProject;
                trBuildingEdit.Visible = isNewProject;
                tdBuildingAdd.Visible = isNewProject;

            if (lblprj.Text == "ABS" &&  ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP"))
            {
                publicCls.publicCls _obj = new publicCls.publicCls();
                tblAdd.Visible = _obj.Load_User_Module_Permission(lblprj.Text, (string)Session["uid"], 7);
            }

        }
   
    }
}
