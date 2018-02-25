﻿using System;
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
    public partial class casgrmsreport_PCD : System.Web.UI.Page 
    {
        public static DataTable _dtMaster;
        public static DataTable _dtfilter;
        public static DataTable _dtresult;
        public static DataTable _summary;
        public static DataTable _dtnames;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "CreateGridHeader", "<script>CreateGridHeader('DataDiv', 'mymaster','HeaderDiv');</script>");
                //Populate_view();
                lblprj.Text = Request.QueryString[0].ToString();
                Load_Master();
                Session["filter"] = "no";
                Session["zone"] = "All";
                Session["flvl"] = "All";
                Session["cat"] = "All";
                Session["fed"] = "All";
                Session["loc"] = "All";
                Session["pro"] = "All";
                Session["zero"] = "1";
                Load_Details();
                Hide_Details();
                Load_TestNames();

                Generate_Summary();
                //drfed.Style.Add("display", "none");
                //Load_Summary();
                btnzero.Visible = false;
            }
        }
        private void Load_TestNames()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = 15;
            _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
        }
        private void Load_Filtering_Elements()
        {
            drbuilding.Items.Clear();
            drcategory.Items.Clear();
            //drfed.Items.Clear();
            drflevel.Items.Clear();
            //drloc.Items.Clear();
            //drprogress.Items.Clear();
            var _bzone = (from DataRow dRow in _dtresult.Rows
                          orderby dRow["B_Z"]
                          select new { col1 = dRow["B_Z"] }).Distinct();
            foreach (var row in _bzone)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drbuilding.Items.Add(_itm);
            }
            drbuilding.DataBind();
            //var _fedf = (from DataRow dRow in _dtresult.Rows
            //             orderby dRow["F_from"]
            //             select new { col1 = dRow["F_from"] }).Distinct();
            //foreach (var row in _fedf)
            //{
            //    ListItem _itm = new ListItem();
            //    _itm.Text = row.col1.ToString();
            //    _itm.Value = row.col1.ToString();
            //    drfed.Items.Add(_itm);
            //}
            //drfed.DataBind();
            var _cate = (from DataRow dRow in _dtresult.Rows
                         orderby dRow["Cat"]
                         select new { col1 = dRow["Cat"] }).Distinct();
            foreach (var row in _cate)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drcategory.Items.Add(_itm);
            }
            drcategory.DataBind();
            var _flvl = (from DataRow dRow in _dtresult.Rows
                         orderby dRow["F_lvl"]
                         select new { col1 = dRow["F_lvl"] }).Distinct();
            foreach (var row in _flvl)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drflevel.Items.Add(_itm);
            }
            drflevel.DataBind();
            //var _loc = (from DataRow dRow in _dtresult.Rows
            //            orderby dRow["Loc"]
            //            select new { col1 = dRow["Loc"] }).Distinct();
            //foreach (var row in _loc)
            //{
            //    ListItem _itm = new ListItem();
            //    _itm.Text = row.col1.ToString();
            //    _itm.Value = row.col1.ToString();
            //    drloc.Items.Add(_itm);
            //}
            //drloc.DataBind();
            var _pro = (from DataRow dRow in _dtresult.Rows
                        orderby dRow["per_com8"]
                        select new { col1 = dRow["per_com8"] }).Distinct();
            //foreach (var row in _pro)
            //{
            //    ListItem _itm = new ListItem();
            //    _itm.Text = row.col1.ToString();
            //    _itm.Value = row.col1.ToString();
            //    drprogress.Items.Add(_itm);
            //}
            //drprogress.DataBind();
            drbuilding.Items.Insert(0, "All");
            drcategory.Items.Insert(0, "All");
            drflevel.Items.Insert(0, "All");
            //drfed.Items.Insert(0, "All");
            //drloc.Items.Insert(0, "All");
            //drprogress.Items.Insert(0, "All");
            drbuilding.SelectedValue = (string)Session["zone"];
            drcategory.SelectedValue = (string)Session["cat"];
            drflevel.SelectedValue = (string)Session["flvl"];
            //drfed.SelectedValue = (string)Session["fed"];
            //drloc.SelectedValue = (string)Session["loc"];
            //drprogress.SelectedValue = (string)Session["pro"];
        }
        private void Load_Master()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = 15;
            _objcas.prj_code = lblprj.Text;
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
            _dtresult = _dtMaster;
            _dtfilter = _dtresult;
            _summary = _dtresult;
        }
        private void Load_Details()
        {
            DataTable _dtable = new DataTable();
            _dtable.Columns.Add("sys_id", typeof(string));
            _dtable.Columns.Add("sys_name", typeof(string));
            var distinctRows = (from DataRow dRow in _dtresult.Rows
                                select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"] }).Distinct();
            foreach (var row in distinctRows)
            {
                DataRow _row = _dtable.NewRow();
                _row[0] = row.col1.ToString();
                _row[1] = row.col2.ToString();
                _dtable.Rows.Add(_row);
            }
            mymaster.DataSource = _dtable;
            mymaster.DataBind();
            Load_Filtering_Elements();
        }
        protected void print_Click(object sender, EventArgs e)
        {
            //Session["zone"] = drbuilding.SelectedItem.Value;
            //Session["flvl"] = drflevel.SelectedItem.Value;
            //Session["cat"] = drcategory.SelectedItem.Value;
            //Session["fed"] = drfed.SelectedItem.Value;
            Insert_Summary();
            string _path = "Cas_Report.aspx?id=15_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" +"" + "_Z" + (string)Session["zero"];
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.open('" + _path + "');", true);
        }
        protected void mymaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _sys_id = (Label)e.Row.FindControl("lbSys_Id");
                DataTable _dtdetails = new DataTable();
                var _details = from _data in _dtresult.AsEnumerable()
                               where _data.Field<int>("Sys_Id") == Convert.ToInt32(_sys_id.Text)
                               select _data;
                _dtdetails = _details.Any() ? _details.CopyToDataTable() : _dtMaster.Clone();
                GridView _mydetails = (GridView)e.Row.FindControl("mydetails");
                _mydetails.DataSource = _dtdetails;
                _mydetails.DataBind();
            }
        }
        private string SeqNo(string No)
        {
            string _nNo = No;
            if (No.Length > 3)
                _nNo = No.Substring(0, 3);
            else
            {
                for (int i = 0; i < (3 - No.Length); i++)
                {
                    _nNo = "0" + _nNo;
                }
            }
            return _nNo;
        }
        private void Hide_Details()
        {
            for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            {
                GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
                Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
                _mydetails.Visible = false;
                _btn.Text = "+";
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gvRow.RowIndex;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + index.ToString() + "');", true);
            GridView _mydetails = (GridView)gvRow.FindControl("mydetails");
            Button _btn = (Button)gvRow.FindControl("Button1");
            if (_btn.Text == "+")
            {
                _mydetails.Visible = true;
                _btn.Text = "-";
            }
            else if (_btn.Text == "-")
            {
                _mydetails.Visible = false;
                _btn.Text = "+";
            }

        }
        protected void mydetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            //GridView _mydetails = (GridView)gvRow.FindControl("mydetails");
            //int _idx = Convert.ToInt32(e.CommandArgument);
            //GridViewRow _srow = _mydetails.Rows[_idx];
            ////int index = gvRow.RowIndex;
            //TableCell _item1 = _srow.Cells[12];
            //TableCell _item2 = _srow.Cells[12];
            //// TableCell _item3 = _srow.Cells[2];
            ////string _file = _item.Text;
            ////ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _file + "');", true);
            //Session["casid"] = _item1.Text;
            //Session["idx"] = _idx.ToString();
            //// ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('I'm Here!');", true);
            //Load_cassheet_details();
            //Config_TestLabel();
            //btnDummy_ModalPopupExtender.Show();
        }
        protected void mydetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();

            e.Row.Cells[23].Visible = false;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _lbl = (Label)e.Row.FindControl("Label1");
                if (_lbl.Text == "0.00%")
                    _lbl.Text = "";

                if (e.Row.Cells[23].Text == "-1") { e.Row.Cells[7].Text = "N/A"; }
            }
        }
        private void Filtering(string _el1, string _el2, string _el3, string _el4, string _el5)
        {
            if (_el1 == "") _el1 = "All";
            if (_el2 == "") _el2 = "All";
            if (_el3 == "") _el3 = "All";
            if (_el4 == "") _el4 = "All";
            if (_el5 == "") _el5 = "All";
            Load_Master();
            var _filter = from o in _dtfilter.AsEnumerable()
                          select o;
            if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("Loc") == _el5
                          select o;
            }
            _dtresult = _filter.Any() ? _filter.CopyToDataTable() : _dtMaster.Clone();
            Load_Details();
            Generate_Summary();
        }
        private void Generate_Summary()
        {
            try
            {
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("QTY_PLANNED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("TOTAL_PLANNED", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));


                var todaysDate = DateTime.Today;

                DateTime defaultvalue = DateTime.ParseExact("01/01/2099", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                var pcdate = defaultvalue;
                if (!string.IsNullOrEmpty(hdnpcd.Value))
                {
                    todaysDate = DateTime.ParseExact(hdnpcd.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                }

                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;
                decimal _p8 = 0;
                decimal _p9 = 0;
                decimal _count1 = 0;
                decimal _count2 = 0;
                decimal _count3 = 0;
                decimal _count4 = 0;
                decimal _count5 = 0;
                decimal _count6 = 0;
                decimal _count7 = 0;
                decimal _count8 = 0;
                decimal _count9 = 0;

                decimal _total = 0;
                decimal _Ptotal = 0;

                int _qtyplanned1 = 0;
                int _qtyplanned2 = 0;
                int _qtyplanned3 = 0;
                int _qtyplanned4 = 0;
                int _qtyplanned5 = 0;
                int _qtyplanned6 = 0;
                int _qtyplanned7 = 0;
                int _qtyplanned8 = 0;
                int _qtyplanned9 = 0;

                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    pcdate = defaultvalue;

                    if (_row["pcdate"] != null && _row["pcdate"].ToString() != "")
                    {
                        pcdate = DateTime.ParseExact(_row["pcdate"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    }

                    if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                    {

                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _count1 += Convert.ToInt32(_row["devices1"].ToString());

                        if (pcdate <= todaysDate) _qtyplanned1 += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                    {
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _count2 += Convert.ToInt32(_row["devices1"].ToString());

                        if (pcdate <= todaysDate) _qtyplanned2 += Convert.ToInt32(_row["devices1"].ToString());
                    }


                    if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                    {
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _count3 += Convert.ToInt32(_row["devices1"].ToString());

                        if (pcdate <= todaysDate) _qtyplanned3 += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com4"].ToString()) != -1)
                    {
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _count4 += Convert.ToInt32(_row["devices1"].ToString());

                        if (pcdate <= todaysDate) _qtyplanned4 += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com5"].ToString()) != -1)
                    {
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _count5 += Convert.ToInt32(_row["devices1"].ToString());

                        if (pcdate <= todaysDate) _qtyplanned5 += Convert.ToInt32(_row["devices1"].ToString());
                    }

                    if (Convert.ToDecimal(_row["per_com6"].ToString()) != -1)
                    {
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        _count6 += Convert.ToInt32(_row["devices1"].ToString());

                        if (pcdate <= todaysDate) _qtyplanned6 += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com7"].ToString()) != -1)
                    {
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                        _count7 += Convert.ToInt32(_row["devices1"].ToString());

                        if (pcdate <= todaysDate) _qtyplanned7 += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com8"].ToString()) != -1)
                    {
                        _p8 += Convert.ToDecimal(_row["per_com8"].ToString());
                        _count8 += Convert.ToInt32(_row["devices1"].ToString());

                        if (pcdate <= todaysDate) _qtyplanned8 += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com9"].ToString()) != -1)
                    {
                        _p9 += Convert.ToDecimal(_row["per_com9"].ToString());
                        _count9 += Convert.ToInt32(_row["devices1"].ToString());

                        if (pcdate <= todaysDate) _qtyplanned9 += Convert.ToInt32(_row["devices1"].ToString()); 
                    }

                }
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();

                    if (row[0].ToString() == "Continuity/IR Test")
                    {
                        //_drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = _count1.ToString(); 

                        _drow["PER_COMPLETED"] = Decimal.Round(_p1).ToString(); _drow["QTY"] = _count1.ToString();
                        _drow["QTY_PLANNED"] = _qtyplanned1.ToString();
                        if (_count1 > 0)
                        {
                            _total = decimal.Round((Convert.ToDecimal(_drow["PER_COMPLETED"].ToString()) / _count1) * 100);
                            _Ptotal = decimal.Round(((Convert.ToDecimal(_qtyplanned1) / Convert.ToDecimal(_count1)) * 100), MidpointRounding.AwayFromZero);
                        }
                    }
                    else if (row[0].ToString() == "Key Card Activated")
                    {
                        //_drow[2] = Decimal.Round(_p2).ToString(); _drow[1] = _count2.ToString(); 

                        _drow["PER_COMPLETED"] = Decimal.Round(_p2).ToString(); _drow["QTY"] = _count2.ToString();
                        _drow["QTY_PLANNED"] = _qtyplanned2.ToString();
                        if (_count2 > 0)
                        {
                            _total = decimal.Round((Convert.ToDecimal(_drow["PER_COMPLETED"].ToString()) / _count2) * 100);
                            _Ptotal = decimal.Round(((Convert.ToDecimal(_qtyplanned2) / Convert.ToDecimal(_count2)) * 100), MidpointRounding.AwayFromZero);
                        }
                    }
                    else if (row[0].ToString() == "Do Not Disturb(DND)/Doorbell")
                    {
                        //_drow[2] = Decimal.Round(_p3).ToString(); _drow[1] = _count3.ToString(); 

                        _drow["PER_COMPLETED"] = Decimal.Round(_p3).ToString(); _drow["QTY"] = _count3.ToString();
                        _drow["QTY_PLANNED"] = _qtyplanned3.ToString();
                        if (_count3 > 0)
                        {
                            _total = decimal.Round((Convert.ToDecimal(_drow["PER_COMPLETED"].ToString()) / _count3) * 100);
                            _Ptotal = decimal.Round(((Convert.ToDecimal(_qtyplanned3) / Convert.ToDecimal(_count3)) * 100), MidpointRounding.AwayFromZero);
                        }
                    }
                    else if (row[0].ToString() == "Make Up Room(MUR)")
                    {
                        //_drow[2] = Decimal.Round(_p4).ToString(); _drow[1] = _count4.ToString(); 

                        _drow["PER_COMPLETED"] = Decimal.Round(_p4).ToString(); _drow["QTY"] = _count4.ToString();
                        _drow["QTY_PLANNED"] = _qtyplanned4.ToString();
                        if (_count4 > 0)
                        {
                            _total = decimal.Round((Convert.ToDecimal(_drow["PER_COMPLETED"].ToString()) / _count4) * 100);
                            _Ptotal = decimal.Round(((Convert.ToDecimal(_qtyplanned4) / Convert.ToDecimal(_count4)) * 100), MidpointRounding.AwayFromZero);
                        }

                    }
                    else if (row[0].ToString() == "FCU/Temp Control")
                    {
                        //_drow[2] = Decimal.Round(_p5).ToString(); _drow[1] = _count5.ToString(); 

                        _drow["PER_COMPLETED"] = Decimal.Round(_p5).ToString(); _drow["QTY"] = _count5.ToString();
                        _drow["QTY_PLANNED"] = _qtyplanned5.ToString();
                        if (_count5 > 0)
                        {
                            _total = decimal.Round((Convert.ToDecimal(_drow["PER_COMPLETED"].ToString()) / _count5) * 100);
                            _Ptotal = decimal.Round(((Convert.ToDecimal(_qtyplanned5) / Convert.ToDecimal(_count5)) * 100), MidpointRounding.AwayFromZero);
                        }
                    }
                    else if (row[0].ToString() == "Energy Management System")
                    {
                        //_drow[2] = decimal.Round(_p6).ToString(); _drow[1] = _count6.ToString();

                        _drow["PER_COMPLETED"] = Decimal.Round(_p6).ToString(); _drow["QTY"] = _count6.ToString();
                        _drow["QTY_PLANNED"] = _qtyplanned6.ToString();
                        if (_count6 > 0)
                        {
                            _total = decimal.Round((Convert.ToDecimal(_drow["PER_COMPLETED"].ToString()) / _count6) * 100);
                            _Ptotal = decimal.Round(((Convert.ToDecimal(_qtyplanned6) / Convert.ToDecimal(_count6)) * 100), MidpointRounding.AwayFromZero);
                        }
                    }
                    else if (row[0].ToString() == "Lighting Scene Control")
                    {
                        //_drow[2] = decimal.Round(_p7).ToString(); _drow[1] = _count7.ToString();

                        _drow["PER_COMPLETED"] = Decimal.Round(_p7).ToString(); _drow["QTY"] = _count7.ToString();
                        _drow["QTY_PLANNED"] = _qtyplanned7.ToString();
                        if (_count7 > 0)
                        {
                            _total = decimal.Round((Convert.ToDecimal(_drow["PER_COMPLETED"].ToString()) / _count7) * 100);
                            _Ptotal = decimal.Round(((Convert.ToDecimal(_qtyplanned7) / Convert.ToDecimal(_count7)) * 100), MidpointRounding.AwayFromZero);
                        }
                    }
                    else if (row[0].ToString() == "Blinds Control Interface")
                    {
                        //_drow[2] = decimal.Round(_p7).ToString(); _drow[1] = _count7.ToString();

                        _drow["PER_COMPLETED"] = Decimal.Round(_p8).ToString(); _drow["QTY"] = _count8.ToString();
                        _drow["QTY_PLANNED"] = _qtyplanned8.ToString();
                        if (_count7 > 0)
                        {
                            _total = decimal.Round((Convert.ToDecimal(_drow["PER_COMPLETED"].ToString()) / _count8) * 100);
                            _Ptotal = decimal.Round(((Convert.ToDecimal(_qtyplanned7) / Convert.ToDecimal(_count8)) * 100), MidpointRounding.AwayFromZero);
                        }
                    }
                    else if (row[0].ToString() == "Monitoring Interface(Future)")
                    {
                        //_drow[2] = decimal.Round(_p7).ToString(); _drow[1] = _count7.ToString();

                        _drow["PER_COMPLETED"] = Decimal.Round(_p9).ToString(); _drow["QTY"] = _count9.ToString();
                        _drow["QTY_PLANNED"] = _qtyplanned9.ToString();
                        if (_count7 > 0)
                        {
                            _total = decimal.Round((Convert.ToDecimal(_drow["PER_COMPLETED"].ToString()) / _count9) * 100);
                            _Ptotal = decimal.Round(((Convert.ToDecimal(_qtyplanned7) / Convert.ToDecimal(_count9)) * 100), MidpointRounding.AwayFromZero);
                        }
                    }

                    _drow["SYS_NAME"] = row[0].ToString();
                    _drow["TOTAL_PLANNED"] = _Ptotal.ToString();
                    _drow["TOTAL"] = _total.ToString();

                    _dtsummary.Rows.Add(_drow);
                }
                mygridsumm.DataSource = _dtsummary;
                mygridsumm.DataBind();
                _summary = _dtsummary;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        protected void drbuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["zone"] = drbuilding.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text,"","");
        }
        protected void drcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["cat"] = drcategory.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, "",  "");
            //Generate_Summary();
        }
        protected void drflevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["flvl"] = drflevel.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, "", "");
        }
        //protected void drfed_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["fed"] = drfed.SelectedItem.Value;
        //    Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drprogress.SelectedItem.Text);
        //}
        private void Insert_Summary()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clscassheet _objcls = new _clscassheet();
            _objbll.Clear_CassummaryRpt(_objdb);
            var _result = from _data in _summary.AsEnumerable()
                          select _data;
            //int count = 0;
            foreach (var row in _result)
            {
                _objcls.sys_mon = row["SYS_NAME"].ToString();
                _objcls.qty = row["QTY"].ToString();
                _objcls.per_com1 = Convert.ToDecimal(row["PER_COMPLETED"].ToString());
                _objcls.total = Convert.ToDecimal(row["TOTAL"].ToString());
                _objcls.cate = row["SYS_NAME"].ToString();
                _objcls.quantity = Convert.ToInt32(row["QTY"].ToString());
                _objcls.compl1 = Convert.ToInt32(row["QTY_PLANNED"].ToString());


                _objbll.Generate_CASSummary_PKG_RPT_ASAO(_objcls, _objdb);
            }
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + count.ToString() + "');", true);
        }

        //protected void drloc_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["loc"] = drloc.SelectedItem.Value;
        //    Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drprogress.SelectedItem.Text);
        //}
        decimal _qty = 0;
        decimal _pqty = 0;
        decimal _tested = 0;
        protected void mygridsumm_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
                _qty += Convert.ToDecimal(e.Row.Cells[2].Text);
                _pqty += Convert.ToDecimal(e.Row.Cells[3].Text);
                _tested += Convert.ToDecimal(e.Row.Cells[4].Text);

                e.Row.Cells[5].Text = e.Row.Cells[5].Text + "%";
                e.Row.Cells[6].Text = e.Row.Cells[6].Text + "%";


            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "SUMMARY OF GRMS";
                e.Row.Cells[2].Text = _qty.ToString();
                e.Row.Cells[3].Text = _pqty.ToString();
                e.Row.Cells[4].Text = _tested.ToString();
                e.Row.Cells[5].Text = Decimal.Round(((_pqty / _qty) * 100), MidpointRounding.AwayFromZero).ToString() + '%';
                e.Row.Cells[6].Text = Decimal.Round(((_tested / _qty) * 100), MidpointRounding.AwayFromZero).ToString() + '%';
            }

        }
        protected void btnexpand_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            {
                GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
                Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
                _mydetails.Visible = true;
                _btn.Text = "-";
            }
        }

        protected void btncollapse_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            {
                GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
                Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
                _mydetails.Visible = false;
                _btn.Text = "+";
            }
        }

        //protected void drprogress_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["pro"] = drprogress.SelectedItem.Value;
        //    Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, "",  "", drprogress.SelectedItem.Text);
        //}

        protected void btnzero_Click(object sender, EventArgs e)
        {
            Session["zero"] = "0";
            Filtering_zero();
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            Load_Master();
            Load_Details();
            Session["filter"] = "no";
            Session["zone"] = "All";
            Session["flvl"] = "All";
            Session["cat"] = "All";
            Session["fed"] = "All";
            Session["loc"] = "All";
            Session["pro"] = "All";
            Session["zero"] = "1";
            Hide_Details();
            Generate_Summary();
        }
        private void Filtering_zero()
        {
            Load_Master();
            _dtfilter = _dtMaster;
            var _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<decimal>("per_com8") == 0
                          select o;
            _dtresult = _filter.Any() ? _filter.CopyToDataTable() : _dtMaster.Clone();

            Load_Details();
            Generate_Summary();
        }
        protected void genPcd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdnpcd.Value)) Generate_Summary();

        }
    }
}
