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
    public partial class ms_schedule12761 : System.Web.UI.Page
    {
        public static DataTable _dtmaster;
        public static DataTable _dtresult;
        public static DataTable _dtresult1; 
        public static DataTable _dtservice;
        public static DataTable _dtsystem;
        public static DataTable _dttype;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblindex.Text = Request.QueryString["idx"].ToString();
              
                Load_MsSchedule_Summary();
                Populate_Service();
                Load_MSService();
            }
        }

        private void Load_MsSchedule_Summary()
        {

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_12761";
            _dtmaster = _objbll.Gen_MS_Schedule_Summary_12761(_objdb);
            _dtresult = _dtmaster;

            Load_MsSchedule_Summary_Previous();

        }
        private void Load_MsSchedule_Summary_Previous() 
        {

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_12761";
            _dtresult1 = _objbll.Gen_MS_Schedule_Summary_12761_Previous(_objdb); ;
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
                _dtsystem = new DataTable();
                _dtsystem.Columns.Add("SYSTEM", typeof(string));
                _dtsystem.Columns.Add("SERVICE", typeof(string));
                var distinct_sys = (from DataRow dRow in _dtresult.Rows
                                    where dRow.Field<string>("SERVICE") == _service.Text
                                    select new { col1 = dRow["SYSTEM"], col2 = dRow["SERVICE"] }).Distinct();
                //var _System = from _data in _dtmaster.AsEnumerable()
                //              where _data.Field<string>("SERVICE") == _service.Text
                //              select _data;
                foreach (var sys_row in distinct_sys)
                {
                    DataRow _Sys_Drow = _dtsystem.NewRow();
                    _Sys_Drow[0] = sys_row.col1.ToString();
                    _Sys_Drow[1] = sys_row.col2.ToString();
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
                //Label _system = (Label)e.Row.FindControl("lbSys_Name");
                //int _count = 0;
                //_dttype = new DataTable();
                //_dttype.Columns.Add("TYPE", typeof(string));
                //_dttype.Columns.Add("SDATE", typeof(DateTime));
                //_dttype.Columns.Add("SBY", typeof(string));
                //_dttype.Columns.Add("VERSION", typeof(int));
                //_dttype.Columns.Add("DAYS_LR", typeof(int));
                //_dttype.Columns.Add("STATUS", typeof(string));
                //_dttype.Columns.Add("FILE_NAME", typeof(string));
                //_dttype.Columns.Add("ITM", typeof(int));
                //_dttype.Columns.Add("PS_DATE", typeof(string));
                //_dttype.Columns.Add("R_CML", typeof(string));
                ////var distinct_sys = (from DataRow dRow in _dtmaster.Rows
                ////                    where dRow.Field<string>("SERVICE") == _service.Text
                ////                    select new { col1 = dRow["SYSTEMS"], col2 = dRow["SERVICE"] }).Distinct();
                //var _System = from _data in _dtresult.AsEnumerable()
                //              where _data.Field<string>("SYSTEMS") == _system.Text
                //              select _data;
                //foreach (var sys_row in _System)
                //{
                //    _count += 1;
                //    DataRow _Type_Drow = _dttype.NewRow();
                //    _Type_Drow[0] = sys_row[2].ToString();
                //    _Type_Drow[1] = Convert.ToDateTime(sys_row[3].ToString());
                //    _Type_Drow[2] = sys_row[4].ToString();
                //    _Type_Drow[3] = Convert.ToInt32(sys_row[5].ToString());
                //    _Type_Drow[4] = Convert.ToInt32(sys_row[6].ToString());
                //    _Type_Drow[5] = sys_row[7].ToString();
                //    _Type_Drow[6] = sys_row[8].ToString();
                //    _Type_Drow[7] = _count;
                //    _Type_Drow[8] = sys_row[9].ToString();
                //    _Type_Drow[9] = sys_row[10].ToString();
                //    _dttype.Rows.Add(_Type_Drow);
                //}
                //GridView _mygrid = (GridView)e.Row.FindControl("mydetails");
                //_mygrid.DataSource = _dttype;
                //_mygrid.DataBind();
                Label _sys_id = (Label)e.Row.FindControl("lbSys_Name");
                DataTable _dtdetails = new DataTable();
                var _details = from _data in _dtresult.AsEnumerable()
                               where _data.Field<string>("SYSTEM") == _sys_id.Text
                               select _data;
                _dtdetails = _details.Any() ? _details.CopyToDataTable() : _dtmaster.Clone();
                GridView _mydetails = (GridView)e.Row.FindControl("mydetails");
                _mydetails.DataSource = _dtdetails;
                _mydetails.DataBind();
            }
        }
        protected void mydetails1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[11].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label lblitemno = (Label)e.Row.FindControl("lblitemno");
                e.Row.Cells[1].Text = (e.Row.RowIndex + 1).ToString();


                if (e.Row.Cells[10].Text == "NONE")
                {
                    e.Row.Cells[6].Text = "";
                    e.Row.Cells[8].Text = "";
                    e.Row.Cells[9].Text = "";
                    e.Row.Cells[2].Text = "";

                }


            }
        }
        protected void mydetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           // e.Row.Cells[11].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
              
                Label lblstatus = (Label)e.Row.FindControl("lblstatus");
                Label lblissued = (Label)e.Row.FindControl("lblissued");
                Label lbldateover = (Label)e.Row.FindControl("lbldateover");
                Label lblbhc = (Label)e.Row.FindControl("lblbhc");
                Label lblcomments = (Label)e.Row.FindControl("lblcomments");
                
                
                //e.Row.Cells[1].Text = (e.Row.RowIndex + 1).ToString();
                if (lblstatus.Text == "NONE")
                {
                    //e.Row.Cells[5].Text = "";
                    //lblstatus.Text = "";
                    lblissued.Text = "";
                    lbldateover.Text = "";
                    lblbhc.Text = "";
                    lblcomments.Text = "";
                }
                //else
                //{
                //    if (e.Row.Cells[3].Text.Length == 1)
                //        e.Row.Cells[3].Text = "0" + e.Row.Cells[3].Text;
                //}
                //if (e.Row.Cells[9].Text != "DRAFT")
                //{
                //    e.Row.Cells[7].Text = "";
                //}
                //else
                //{
                //    if (Convert.ToInt32(e.Row.Cells[7].Text) <= 0)
                //        e.Row.Cells[7].Text = "";
                //}


                Label _sys_id = (Label)e.Row.FindControl("lbSys_Name");
                DataTable _dtdetails = new DataTable();
                var _details = from _data in _dtresult1.AsEnumerable()
                               //where _data.Field<string>("SYSTEM") == "1.01 Pump alignment and setting to work"
                               where _data.Field<string>("SYSTEM") == _sys_id.Text
                               orderby _data.Field<Int32>("REVISION") descending
                               select _data;
                _dtdetails = _details.Any() ? _details.CopyToDataTable() : _dtmaster.Clone();
                GridView _mydetails1 = (GridView)e.Row.FindControl("mydetails1");

                
                _mydetails1.DataSource = _dtdetails;
                _mydetails1.DataBind();



            }
        }
        protected void mydetails1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView _mydetails1 = (GridView)gvRow.FindControl("mydetails1");

            int _idx = Convert.ToInt32(e.CommandArgument);
            //GridViewRow _srow = _mydetails.Rows[_idx];

            //Label lblfname = (Label)_mydetails1.Rows[_idx].FindControl("lblfname");
            //Label lblstatus = (Label)_mydetails1.Rows[_idx].FindControl("lblstatus");


            int index = gvRow.RowIndex;
            TableCell _file = _mydetails1.Rows[_idx].Cells[11];
            TableCell _status = _mydetails1.Rows[_idx].Cells[10];
            if (_status.Text != "NONE")
            {
                string _path = "https://cmltechniques.com/CMS_DOCS/" + (string)Session["project"] + "/" + _file.Text;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _path + "','','left=50,top=50,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Not Available');", true);
            }
        }
        protected void mydetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView _mydetails = (GridView)gvRow.FindControl("mydetails");
           
            int _idx = Convert.ToInt32(e.CommandArgument);
            //GridViewRow _srow = _mydetails.Rows[_idx];

            Label lblfname = (Label)_mydetails.Rows[_idx].FindControl("lblfname");
            Label lblstatus = (Label)_mydetails.Rows[_idx].FindControl("lblstatus");


            //int index = gvRow.RowIndex;
            //TableCell _file = _srow.Cells[11];
            //TableCell _status = _srow.Cells[10];
            if (lblstatus.Text != "NONE")
            {
                string _path = "https://cmltechniques.com/CMS_DOCS/" + (string)Session["project"] + "/" + lblfname.Text;
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
            _objdb.DBName = "DB_" + (string)Session["project"];
            drservices.DataSource = _objbll.Load_Prj_Service(_objdb);
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
            _objdb.DBName = "DB_" + (string)Session["project"];
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
            
        }

        protected void btngenerate_Click(object sender, EventArgs e)
        {
            Filtering(drservices.SelectedItem.Text, drpackages.SelectedItem.Text, drstatus.SelectedItem.Text);
        }
        private void Filtering(string _el1, string _el2,string _el4)
        {
            if (_el1 == "") _el1 = "All";
            if (_el2 == "") _el2 = "All";
            if (_el4 == "") _el4 = "All";
            string _el3 = "All";
            DataTable _dtfilter = _dtmaster;
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
                          where o.Field<string>("SERVICE") == _el1 && o.Field<string>("SYSTEM") == _el2
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("SERVICE") == _el1 && o.Field<string>("SYSTEM") == _el2 && o.Field<string>("TYPE") == _el3
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
            DataTable _dtdetails = _filter.Any() ? _filter.CopyToDataTable() : _dtmaster.Clone();
            _dtresult = _dtdetails;
            Populate_Service();

        }


        void insert_MS_Schedule_Report()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _clsMaster _objcls = new _clsMaster();
             _database _objdb = new _database();
             _objdb.DBName = "DB_12761";

             _objcls.ser_name = drservices.SelectedItem.Text;
             _objcls.sys_name = drpackages.SelectedItem.Text;
             _objcls.sys_type = drstatus.SelectedItem.Text;



            _objbll.insert_MS_Schedule_Report(_objcls,_objdb);

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            insert_MS_Schedule_Report();


            Session["srv"] = drservices.SelectedItem.Text;
            Session["sys"] = drpackages.SelectedItem.Text;
            Session["sts"] = drstatus.SelectedItem.Text;
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('Reports.aspx?id=msr&prj=12761','','left=200,top=50,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
        }
    }
}
