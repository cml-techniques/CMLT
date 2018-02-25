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
    public partial class ms_schedule1 : System.Web.UI.Page
    {

        public static DataTable _dtmaster;
        public static DataTable _dtresult;
        public static DataTable _dtservice;
        public static DataTable _dtsystem;
        public static DataTable _dttype;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                lblprj.Text = Request.QueryString["prj"].ToString();
                lblindex.Text = Request.QueryString["idx"].ToString();


                loadBuilding();

                string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
            }
        }
        private void loadBuilding()
        {
            Telerik.Web.UI.DropDownListItem item;
            if (lblprj.Text == "HMIM")
            {

                item = new Telerik.Web.UI.DropDownListItem();
                item.Text = "Haram/Piazza";
                item.Value = "1";
                rd_Building.Items.Add(item);


                item = new Telerik.Web.UI.DropDownListItem();
                item.Text = "Service Building";
                item.Value = "2";
                rd_Building.Items.Add(item);

                item = new Telerik.Web.UI.DropDownListItem();
                item.Text = "CUC/T4";
                item.Value = "3";
                rd_Building.Items.Add(item);


            }
            else if (lblprj.Text == "ABS")
            {
                item = new Telerik.Web.UI.DropDownListItem();
                item.Text = "PK2";
                item.Value = "1";
                rd_Building.Items.Add(item);

                item = new Telerik.Web.UI.DropDownListItem();
                item.Text = "PK4";
                item.Value = "2";
                rd_Building.Items.Add(item);

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
        void InsertData()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;

            _clscassheet _obj = new _clscassheet();
            _obj.build_id = Convert.ToInt32(rd_Building.SelectedValue.ToString());

            _objbll.Gen_MS_Schedule_Summary(_obj,_objdb);
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
        private void Load_MsSchedule_Summary()
        {

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _dtmaster = _objbll.Load_MSSchedule_Summary(_objdb);
            _dtresult = _dtmaster;
        }
        private void Populate_Service()
        {
            _dtservice = new DataTable();
            _dtservice.Columns.Add("SERVICE", typeof(string));
            var distinctRows = (from DataRow dRow in _dtresult.Rows
                                select new { col1 = dRow["SERVICE"] }).Distinct();
            foreach (var _ser_row in distinctRows)
            {
                DataRow _serRow = _dtservice.NewRow();
                _serRow[0] = _ser_row.col1.ToString();
                _dtservice.Rows.Add(_serRow);
            }
            mymaster.DataSource = _dtservice;
            mymaster.DataBind();
        }

        protected void mymaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _service = (Label)e.Row.FindControl("lbSer_Name");
                int count = 0;
                _dtsystem = new DataTable();
                _dtsystem.Columns.Add("SYSTEM", typeof(string));
                _dtsystem.Columns.Add("SERVICE", typeof(string));
                _dtsystem.Columns.Add("SLNO", typeof(string));
                var distinct_sys = (from DataRow dRow in _dtresult.Rows
                                    where dRow.Field<string>("SERVICE") == _service.Text
                                    select new { col1 = dRow["SYSTEMS"], col2 = dRow["SERVICE"] }).Distinct();
                //var _System = from _data in _dtmaster.AsEnumerable()
                //              where _data.Field<string>("SERVICE") == _service.Text
                //              select _data;
                foreach (var sys_row in distinct_sys)
                {
                    count += 1;
                    DataRow _Sys_Drow = _dtsystem.NewRow();
                    _Sys_Drow[0] = sys_row.col1.ToString();
                    _Sys_Drow[1] = sys_row.col2.ToString();
                    _Sys_Drow[2] = count;
                    _dtsystem.Rows.Add(_Sys_Drow);
                }
                GridView _mygrid = (GridView)e.Row.FindControl("mysystem");
                _mygrid.DataSource = _dtsystem;
                _mygrid.DataBind();
            }
        }
        protected void mysystem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _system = (Label)e.Row.FindControl("lbSys_Name");
                Label _lbcount = (Label)e.Row.FindControl("lbslno");
                Label _service = (Label)e.Row.FindControl("lbSer_Name");    
                //int _count = 0;
                _dttype = new DataTable();
                _dttype.Columns.Add("TYPE", typeof(string));
                _dttype.Columns.Add("SDATE", typeof(DateTime));
                _dttype.Columns.Add("SBY", typeof(string));
                _dttype.Columns.Add("VERSION", typeof(int));
                _dttype.Columns.Add("DAYS_LR", typeof(int));
                _dttype.Columns.Add("STATUS", typeof(string));
                _dttype.Columns.Add("FILE_NAME", typeof(string));
                _dttype.Columns.Add("ITM", typeof(int));
                //var distinct_sys = (from DataRow dRow in _dtmaster.Rows
                //                    where dRow.Field<string>("SERVICE") == _service.Text
                //                    select new { col1 = dRow["SYSTEMS"], col2 = dRow["SERVICE"] }).Distinct();
                var _System = from _data in _dtresult.AsEnumerable()
                              where _data.Field<string>("SYSTEMS") == _system.Text && _data.Field<string>("SERVICE") == _service.Text 
                              select _data;
                foreach (var sys_row in _System)
                {
                    //_count += 1;
                    DataRow _Type_Drow = _dttype.NewRow();
                    _Type_Drow[0] = sys_row[2].ToString();
                    _Type_Drow[1] = Convert.ToDateTime(sys_row[3].ToString());
                    _Type_Drow[2] = sys_row[4].ToString();
                    _Type_Drow[3] = Convert.ToInt32(sys_row[5].ToString());
                    _Type_Drow[4] = Convert.ToInt32(sys_row[6].ToString());
                    _Type_Drow[5] = sys_row[7].ToString();
                    _Type_Drow[6] = sys_row[8].ToString();
                    _Type_Drow[7] = _lbcount.Text;
                    _dttype.Rows.Add(_Type_Drow);
                }
                GridView _mygrid = (GridView)e.Row.FindControl("mydetails");
                _mygrid.DataSource = _dttype;
                _mygrid.DataBind();
            }
        }
        protected void mydetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[8].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

              e.Row.Cells[2].Attributes.Add("Margin-left","20px");

                e.Row.Cells[2].Text = " Method Statement";

                e.Row.Cells[6].Text = "N/A";

                if (e.Row.Cells[7].Text == "DRAFT")
                {
                    e.Row.Cells[5].Text = "";
                    //e.Row.Cells[6].Text = "";
                    e.Row.Cells[3].Text = "";
                }
                else
                {
                    if (e.Row.Cells[3].Text.Length == 1)
                        e.Row.Cells[3].Text = "0" + e.Row.Cells[3].Text;
                }
            }
        }
        protected void mydetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView _mydetails = (GridView)gvRow.FindControl("mydetails");
            int _idx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = _mydetails.Rows[_idx];
            //int index = gvRow.RowIndex;
            TableCell _file = _srow.Cells[8];
            TableCell _status = _srow.Cells[7];
            if (_status.Text != "DRAFT")
            {
                string _path = "https://cmltechniques.com/CMS_DOCS/" + lblprj.Text + "/" + _file.Text;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _path + "','','left=50,top=50,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Not Available');", true);
            }
        }

        private void Load_MSService()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            drservices.DataSource = _objbll.Load_Prj_Service_MS(_objdb);
            drservices.DataTextField = "PRJ_SER_NAME";
            drservices.DataValueField = "PRJ_SER_ID";
            drservices.DataBind();
            drservices.Items.Insert(0, "All");

        }
        protected void drservices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drservices.SelectedItem.Text == "All") return;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            DataTable _dtsys = _objbll.Load_Prj_MsSystem(_objdb);
            var _systems = from o in _dtsys.AsEnumerable()
                           where o.Field<int>(3) == Convert.ToInt32(drservices.SelectedItem.Value)
                           select o;
            drpackages.Items.Clear();
            foreach (var row in _systems)
            {
                ListItem _lst = new ListItem();
                _lst.Text = row[2].ToString();
                _lst.Value = row[0].ToString();
                drpackages.Items.Add(_lst);
            }
            drpackages.Items.Insert(0, "All");
            drtype.DataSource = _objbll.Load_Prj_MsType(_objdb);
            drtype.DataTextField = "PRJ_MSTYPE_NAME";
            drtype.DataValueField = "PRJ_MSTYPE_ID";
            drtype.DataBind();
            drtype.Items.Insert(0, "All");
        }

        protected void btngenerate_Click(object sender, EventArgs e)
        {
            Filtering(drservices.SelectedItem.Text, drpackages.SelectedItem.Text, drtype.SelectedItem.Text, drstatus.SelectedItem.Text);
        }
        private void Filtering(string _el1, string _el2, string _el3, string _el4)
        {
            if (_el1 == "") _el1 = "All";
            if (_el2 == "") _el2 = "All";
            if (_el3 == "") _el3 = "All";
            if (_el4 == "") _el4 = "All";
            DataTable _dtfilter = _dtmaster;
            _dtresult = new DataTable();
            _dtresult.Columns.Add("SERVICE", typeof(string));
            _dtresult.Columns.Add("SYSTEMS", typeof(string));
            _dtresult.Columns.Add("TYPE", typeof(string));
            _dtresult.Columns.Add("SDATE", typeof(DateTime));
            _dtresult.Columns.Add("SBY", typeof(string));
            _dtresult.Columns.Add("VERSION", typeof(int));
            _dtresult.Columns.Add("DAYS_LR", typeof(int));
            _dtresult.Columns.Add("STATUS", typeof(string));
            _dtresult.Columns.Add("FILE_NAME", typeof(string));
            _dtresult.Columns.Add("ITM", typeof(int));
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
                          where o.Field<string>("SERVICE") == _el1
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("SERVICE") == _el1 && o.Field<string>("SYSTEMS") == _el2
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("SERVICE") == _el1 && o.Field<string>("SYSTEMS") == _el2 && o.Field<string>("TYPE") == _el3
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("SERVICE") == _el1 && o.Field<string>("SYSTEMS") == _el2 && o.Field<string>("TYPE") == _el3 && o.Field<string>("STATUS") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("SYSTEMS") == _el2
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("SYSTEMS") == _el2 && o.Field<string>("TYPE") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("SYSTEMS") == _el2 && o.Field<string>("TYPE") == _el3 && o.Field<string>("STATUS") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("TYPE") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("TYPE") == _el3 && o.Field<string>("STATUS") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("STATUS") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("SERVICE") == _el1 && o.Field<string>("TYPE") == _el3
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("SERVICE") == _el1 && o.Field<string>("TYPE") == _el3 && o.Field<string>("STATUS") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("SERVICE") == _el1 && o.Field<string>("STATUS") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("SYSTEMS") == _el2 && o.Field<string>("STATUS") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("SERVICE") == _el1 && o.Field<string>("SYSTEMS") == _el2 && o.Field<string>("STATUS") == _el4
                          select o;
            }
            int _count = 0;
            foreach (var row in _filter)
            {
                _count += 1;
                DataRow _row = _dtresult.NewRow();
                _row[0] = row["SERVICE"].ToString();
                _row[1] = row["SYSTEMS"].ToString();
                _row[2] = row["TYPE"].ToString();
                _row[3] = Convert.ToDateTime(row["SDATE"].ToString());
                _row[4] = row["SBY"].ToString();
                _row[5] = Convert.ToInt32(row["VERSION"].ToString());
                _row[6] = Convert.ToInt32(row["DAYS_LR"].ToString());
                _row[7] = row["STATUS"].ToString();
                _row[8] = row["FILE_NAME"].ToString();
                _row[9] = _count;
                _dtresult.Rows.Add(_row);
            }
            Populate_Service();

        }



        protected void btnprint_new_Click(object sender, EventArgs e)
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DB_" + lblprj.Text;
            //_objbll.Gen_MS_Schedule_Summary(_objdb);
            //Session["srv"] = drservices.SelectedItem.Text;
            //Session["sys"] = drpackages.SelectedItem.Text;
            //Session["typ"] = drtype.SelectedItem.Text;
            //Session["sts"] = drstatus.SelectedItem.Text;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('Reports.aspx?id=mss','','left=200,top=50,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
            BLL_Dml _objbll = new BLL_Dml();

            _database _objdb = new _database();

            _objdb.DBName = "DB_" + lblprj.Text;

            _clscassheet _obj = new _clscassheet();
            _obj.build_id = Convert.ToInt32(rd_Building.SelectedValue.ToString());

            _objbll.Gen_MS_Schedule_Summary(_obj,_objdb);

            Session["srv"] = drservices.SelectedItem.Text;

            Session["sys"] = drpackages.SelectedItem.Text;

            Session["typ"] = drtype.SelectedItem.Text;

            Session["sts"] = drstatus.SelectedItem.Text;

            string url = "Reports.aspx?id=mss&prj=" + lblprj.Text;
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + url + "','','left=200,top=50,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);

        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            string _url = "cmsreports.aspx?idx=" + lblindex.Text + "&prj=" + lblprj.Text;
            Response.Redirect(_url);
        }
        protected void btnenter_Click(object sender, EventArgs e)
        {
            if (rd_Building.SelectedValue == "") return;

            package.Text ="BUILDING : "+ rd_Building.SelectedText.ToString();
            Session["building"] = package.Text;

            InsertData();

            Load_MsSchedule_Summary();
            Populate_Service();
            Load_MSService();

            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);

            Get_ProjectName();
        }
        protected void rd_Building_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }

}
