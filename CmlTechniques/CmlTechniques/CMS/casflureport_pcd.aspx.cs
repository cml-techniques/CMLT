using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using App_Properties;

namespace CmlTechniques.CMS
{
    public partial class casflureport_pcd : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtfilter;
        public static DataTable _dtresult;
        public static DataTable _summary;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "CreateGridHeader", "<script>CreateGridHeader('DataDiv', 'mymaster','HeaderDiv');</script>");
                string _prm = Request.QueryString[0].ToString();
                lblprj.Text = _prm;
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

                Generate_Summary();
                //Head_Merging();
                drfed.Style.Add("display", "none");

            }
        }
       
        private void Load_Filtering_Elements()
        {
            drbuilding.Items.Clear();
            drcategory.Items.Clear();
            drfed.Items.Clear();
            drflevel.Items.Clear();
            drloc.Items.Clear();
            drprogress.Items.Clear();
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
            var _fedf = (from DataRow dRow in _dtresult.Rows
                         orderby dRow["F_from"]
                         select new { col1 = dRow["F_from"] }).Distinct();
            foreach (var row in _fedf)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drfed.Items.Add(_itm);
            }
            drfed.DataBind();
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
            var _loc = (from DataRow dRow in _dtresult.Rows
                        orderby dRow["Loc"]
                        select new { col1 = dRow["Loc"] }).Distinct();
            foreach (var row in _loc)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drloc.Items.Add(_itm);
            }
            drloc.DataBind();
            var _pro = (from DataRow dRow in _dtresult.Rows
                        orderby dRow["per_com1"]
                        select new { col1 = dRow["per_com1"] }).Distinct();
            foreach (var row in _pro)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drprogress.Items.Add(_itm);
            }
            drprogress.DataBind();
            drbuilding.Items.Insert(0, "All");
            drcategory.Items.Insert(0, "All");
            drflevel.Items.Insert(0, "All");
            drfed.Items.Insert(0, "All");
            drloc.Items.Insert(0, "All");
            drprogress.Items.Insert(0, "All");
            drbuilding.SelectedValue = (string)Session["zone"];
            drcategory.SelectedValue = (string)Session["cat"];
            drflevel.SelectedValue = (string)Session["flvl"];
            drfed.SelectedValue = (string)Session["fed"];
            drloc.SelectedValue = (string)Session["loc"];
            drprogress.SelectedValue = (string)Session["pro"];
        }
        private void Load_Master()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = 21;
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
        decimal _qty = 0;
        decimal _pf = 0;
        decimal _fvr = 0;
        decimal _cc = 0;
        decimal _fac = 0;
        decimal _bf = 0;
        decimal _ct = 0;
        decimal _pftotal = 0;
        decimal _fvrtotal = 0;
        decimal _cctotal = 0;
        decimal _factotal = 0;
        decimal _bftotal = 0;
        decimal _cttotal = 0;
        decimal _planned = 0;
        decimal _completed = 0;
        decimal _totalapp = 0;
        decimal _totalplanned = 0;
        /*Summary Footer parameters*/
        static string pfsum = "";
        static string fvrsum = "";
        static string ccsum = "";
        static string facsum = "";
        static string bfsum = "";
        static string ctsum = "";
        string planned = "";
        string completed = "";
        protected void mygridsumm_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[16].Visible = false;
            e.Row.Cells[17].Visible = false;
            e.Row.Cells[18].Visible = false;
            e.Row.Cells[19].Visible = false;
            e.Row.Cells[20].Visible = false;
            e.Row.Cells[21].Visible = false;
            e.Row.Cells[22].Visible = false;
            e.Row.Cells[23].Visible = false;
            e.Row.Cells[24].Visible = false;
            e.Row.Cells[25].Visible = false;
            e.Row.Cells[26].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
                _qty += Convert.ToDecimal(e.Row.Cells[2].Text);
                _pf += Convert.ToDecimal(e.Row.Cells[17].Text);
                _fvr+= Convert.ToDecimal(e.Row.Cells[18].Text);
                _cc += Convert.ToDecimal(e.Row.Cells[19].Text);
                _fac += Convert.ToDecimal(e.Row.Cells[20].Text);
                _bf += Convert.ToDecimal(e.Row.Cells[21].Text);
                _ct += Convert.ToDecimal(e.Row.Cells[22].Text);
                _pftotal += Convert.ToDecimal(e.Row.Cells[11].Text);
                _fvrtotal += Convert.ToDecimal(e.Row.Cells[12].Text);
                _cctotal += Convert.ToDecimal(e.Row.Cells[13].Text);
                _factotal += Convert.ToDecimal(e.Row.Cells[14].Text);
                _bftotal += Convert.ToDecimal(e.Row.Cells[15].Text);
                _cttotal += Convert.ToDecimal(e.Row.Cells[16].Text);
                _planned += Convert.ToDecimal(e.Row.Cells[23].Text);
                _totalapp += Convert.ToDecimal(e.Row.Cells[24].Text);
                _totalplanned += Convert.ToDecimal(e.Row.Cells[25].Text);
                _completed += Convert.ToDecimal(e.Row.Cells[26].Text);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
               
               Session["pfsum"] = (_pftotal > 0) ? Decimal.Round((_pf / _pftotal) * 100, MidpointRounding.AwayFromZero).ToString() + "%" : Convert.ToString(0) + "%";
               Session["fvrsum"] = (_fvrtotal > 0) ? Decimal.Round((_fvr / _fvrtotal) * 100, MidpointRounding.AwayFromZero).ToString() + "%" : Convert.ToString(0) + "%";
               Session["ccsum"] = (_cctotal > 0) ? Decimal.Round((_cc / _cctotal) * 100, MidpointRounding.AwayFromZero).ToString() + "%" : Convert.ToString(0) + "%";
               Session["facsum"] = (_factotal > 0) ? Decimal.Round((_fac / _factotal) * 100, MidpointRounding.AwayFromZero).ToString() + "%" : Convert.ToString(0) + "%";
               Session["bfsum"] = (_bftotal > 0) ? Decimal.Round((_bf / _bftotal) * 100, MidpointRounding.AwayFromZero).ToString() + "%" : Convert.ToString(0) + "%";
               Session["ctsum"] = (_cttotal > 0) ? Decimal.Round((_ct / _cttotal) * 100, MidpointRounding.AwayFromZero).ToString() + "%" : Convert.ToString(0) + "%";
               Session["planned"] = (_totalplanned > 0) ? Decimal.Round((_planned / _totalplanned) * 100, MidpointRounding.AwayFromZero).ToString() + "%" : Convert.ToString(0) + "%";
               Session["completed"] = (_totalapp > 0) ? Decimal.Round((_completed / _totalapp), MidpointRounding.AwayFromZero).ToString() + "%" : Convert.ToString(0) + "%";
                e.Row.Cells[1].Text = "SUMMARY";
                e.Row.Cells[2].Text = _qty.ToString();
                e.Row.Cells[3].Text = (_pftotal > 0)?Decimal.Round((_pf/_pftotal)* 100,MidpointRounding.AwayFromZero).ToString()+ "%": Convert.ToString(0)+ "%";
                e.Row.Cells[4].Text = (_fvrtotal > 0)?Decimal.Round((_fvr / _fvrtotal) * 100, MidpointRounding.AwayFromZero).ToString()+ "%": Convert.ToString(0) + "%";
                e.Row.Cells[5].Text = (_cctotal > 0) ? Decimal.Round((_cc / _cctotal) * 100, MidpointRounding.AwayFromZero).ToString() + "%" : Convert.ToString(0) + "%";
                e.Row.Cells[6].Text = (_factotal > 0) ? Decimal.Round((_fac / _factotal) * 100, MidpointRounding.AwayFromZero).ToString() + "%" : Convert.ToString(0) + "%";
                e.Row.Cells[7].Text = (_bftotal > 0) ? Decimal.Round((_bf / _bftotal) * 100, MidpointRounding.AwayFromZero).ToString() + "%" : Convert.ToString(0) + "%";
                e.Row.Cells[8].Text = (_cttotal > 0) ? Decimal.Round((_ct / _cttotal) * 100, MidpointRounding.AwayFromZero).ToString() + "%" : Convert.ToString(0) + "%";
                e.Row.Cells[9].Text = (_totalplanned > 0) ? Decimal.Round((_planned / _totalplanned) * 100, MidpointRounding.AwayFromZero).ToString() + "%" : Convert.ToString(0) + "%";
                e.Row.Cells[10].Text = (_totalapp > 0) ? Decimal.Round((_completed / _totalapp), MidpointRounding.AwayFromZero).ToString() + "%" : Convert.ToString(0) + "%";
               
            }
        }
        protected void print_Click(object sender, EventArgs e)
        {
            //Session["zone"] = drbuilding.SelectedItem.Value;
            //Session["flvl"] = drflevel.SelectedItem.Value;
            //Session["cat"] = drcategory.SelectedItem.Value;
            //Session["fed"] = drfed.SelectedItem.Value;
            Insert_Summary();
            if (Session["uid"] != null) 
            {
                string _path = "Cas_Report.aspx?id=21_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value + "_Z" + (string)Session["zero"] + "&pf=" + (string)Session["pfsum"] + "&fvr=" + (string)Session["fvrsum"] + "&cc=" + (string)Session["ccsum"] + "&fac=" + (string)Session["facsum"] + "&bf=" + (string)Session["bfsum"] + "&ct=" + (string)Session["ctsum"] + "&planned=" + (string)Session["planned"] + "&completed=" + (string)Session["completed"];
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.open('" + _path + "');", true);
            } 
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
            e.Row.Cells[5].Text = SeqNo(e.Row.Cells[5].Text);
        }
        private void Filtering(string _el1, string _el2, string _el3, string _el4, string _el5, string _el6)
        {
            if (_el1 == "") _el1 = "All";
            if (_el2 == "") _el2 = "All";
            if (_el3 == "") _el3 = "All";
            if (_el4 == "") _el4 = "All";
            if (_el5 == "") _el5 = "All";
            if (_el6 == "") _el6 = "All";
            Load_Master();
            
            var _filter = from o in _dtfilter.AsEnumerable()
                          select o;
            if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<decimal>("per_com1") == Convert.ToDecimal(_el6)
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<decimal>("per_com1") == Convert.ToDecimal(_el6)
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<decimal>("per_com1") == Convert.ToDecimal(_el6)
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<decimal>("per_com1") == Convert.ToDecimal(_el6)
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<decimal>("per_com1") == Convert.ToDecimal(_el6)
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<decimal>("per_com1") == Convert.ToDecimal(_el6)
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<decimal>("per_com1") == Convert.ToDecimal(_el6)
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Loc") == _el5 && o.Field<decimal>("per_com1") == Convert.ToDecimal(_el6)
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<decimal>("per_com1") == Convert.ToDecimal(_el6)
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("Loc") == _el5 && o.Field<decimal>("per_com1") == Convert.ToDecimal(_el6)
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<decimal>("per_com1") == Convert.ToDecimal(_el6)
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 == "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<decimal>("per_com1") == Convert.ToDecimal(_el6)
                          select o;
            }
            _dtresult = _filter.Any() ? _filter.CopyToDataTable() : _dtresult.Clone();
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
                _dtsummary.Columns.Add("PLAIN_FLUSH", typeof(string));
                _dtsummary.Columns.Add("FLUSH_VELOCITY", typeof(string));
                _dtsummary.Columns.Add("CHEMICAL_CLEAN", typeof(string));
                _dtsummary.Columns.Add("FLUSH_AFTERCHEM", typeof(string));
                _dtsummary.Columns.Add("BACK_FLUSH", typeof(string));
                _dtsummary.Columns.Add("CHEMICAL_TREATMENT", typeof(string));
                _dtsummary.Columns.Add("PLANNED_PROGRESS", typeof(string));
                _dtsummary.Columns.Add("ACTUAL_PROGRESS", typeof(string));
                _dtsummary.Columns.Add("PFTOT", typeof(string));
                _dtsummary.Columns.Add("FVRTOT", typeof(string));
                _dtsummary.Columns.Add("CCTOT", typeof(string));
                _dtsummary.Columns.Add("FACTOT", typeof(string));
                _dtsummary.Columns.Add("BFTOT", typeof(string));
                _dtsummary.Columns.Add("CTTOT", typeof(string));
                _dtsummary.Columns.Add("PF", typeof(string));
                _dtsummary.Columns.Add("FVR", typeof(string));
                _dtsummary.Columns.Add("CC", typeof(string));
                _dtsummary.Columns.Add("FAC", typeof(string));
                _dtsummary.Columns.Add("BF", typeof(string));
                _dtsummary.Columns.Add("CT", typeof(string));
                _dtsummary.Columns.Add("PLANNED", typeof(string));
                _dtsummary.Columns.Add("TOTALAPP", typeof(string));
                _dtsummary.Columns.Add("TOTPLAN", typeof(string));
                _dtsummary.Columns.Add("COMPLETED", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _pf = 0;
                    decimal _pftotal =0;
                    decimal _pfna = 0;
                    decimal _fvr = 0;
                    decimal _fvrtotal = 0;
                    decimal _fvrna = 0;
                    decimal _cc = 0;
                    decimal _cctotal = 0;
                    decimal _ccna =0;
                    decimal _facc = 0;
                    decimal _facctotal = 0;
                    decimal _faccna =0;
                    decimal _bfc = 0;
                    decimal _bfctotal = 0;
                    decimal _bfcna =0;
                    decimal _fct = 0;
                    decimal _fcttotal = 0;
                    decimal _fctna = 0;
                    decimal _pcdate = 0;
                    decimal _totalApplicable = 0;
                    decimal _totalplanned = 0;
                    decimal _percomplete = 0;                   
                    decimal count = 0;
                    decimal _NA = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        DateTime dt;
                        if (DateTime.TryParseExact(_row["test1"].ToString(), "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                            _pf += 1;
                        if (_row["test1"].ToString() == "" || _row["test1"] == null || DateTime.TryParseExact(_row["test1"].ToString(), "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                            _pftotal += 1;
                        else if (_row["test1"].ToString() == "N/A")
                            _pfna += 1;

                        if (DateTime.TryParseExact(_row["test2"].ToString(), "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                            _fvr += 1;
                        if (_row["test2"].ToString() == "" || _row["test2"] == null || DateTime.TryParseExact(_row["test2"].ToString(), "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                            _fvrtotal += 1;
                        else if (_row["test2"].ToString() == "N/A")
                            _fvrna += 1;

                        if (DateTime.TryParseExact(_row["test3"].ToString(), "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                            _cc += 1;
                        if (_row["test3"].ToString() == "" || _row["test3"] == null || DateTime.TryParseExact(_row["test3"].ToString(), "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                            _cctotal += 1;
                        else if (_row["test3"].ToString() == "N/A")
                            _ccna += 1;

                        if (DateTime.TryParseExact(_row["test4"].ToString(), "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                            _facc += 1;
                        if (_row["test4"].ToString() == "" || _row["test4"] == null || DateTime.TryParseExact(_row["test4"].ToString(), "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                            _facctotal += 1;
                        else if (_row["test4"].ToString() == "N/A")
                            _faccna += 1;

                        if (DateTime.TryParseExact(_row["test5"].ToString(), "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                            _bfc += 1;
                        if (_row["test5"].ToString() == "" || _row["test5"] == null || DateTime.TryParseExact(_row["test5"].ToString(), "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                            _bfctotal += 1;
                        else if (_row["test5"].ToString() == "N/A")
                            _bfcna += 1;

                        if (DateTime.TryParseExact(_row["test6"].ToString(), "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                            _fct += 1;
                        if (_row["test6"].ToString() == "" || _row["test6"] == null || DateTime.TryParseExact(_row["test6"].ToString(), "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                            _fcttotal += 1;
                        else if (_row["test6"].ToString() == "N/A")
                            _fctna += 1;

                       DateTime currentdate = DateTime.Today;
                        if (!string.IsNullOrEmpty(hdnpcd.Value))
                        {
                            currentdate = DateTime.ParseExact(hdnpcd.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (_row["PCdate"].ToString()!= "" && _row["PCdate"] != null)
                        {
                            DateTime pcdate = DateTime.ParseExact(_row["PCdate"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            if (pcdate <= currentdate) _pcdate += 1;
                        }
                        if (Convert.ToDecimal(_row["per_com1"]) != -1)
                        {
                            _percomplete += Convert.ToDecimal(_row["per_com1"]);
                            _totalApplicable += 1;
                        }
                        if (Convert.ToDecimal(_row["per_com2"]) != -1)
                        {
                            _totalplanned += 1;
                        }
                        else if (Convert.ToDecimal(_row["per_com1"]) == -1)
                            _NA += 1;
                        count += 1;
                     } 
              
                    DataRow _drow = _dtsummary.NewRow();
                    _drow["SYS_NAME"] = row.col2.ToString();
                    _drow["QTY"] = count.ToString();
                    _drow["PLAIN_FLUSH"] = (count == _pfna)?"N/A":(_pftotal > 0) ? Decimal.Round((_pf / _pftotal) * 100, MidpointRounding.AwayFromZero).ToString() : Convert.ToString(0);
                    _drow["FLUSH_VELOCITY"] = (count == _fvrna)?"N/A":(_fvrtotal>0)?Decimal.Round((_fvr / _fvrtotal) * 100, MidpointRounding.AwayFromZero).ToString():Convert.ToString(0);
                    _drow["CHEMICAL_CLEAN"] = (count == _ccna)?"N/A":(_cctotal > 0) ? Decimal.Round((_cc / _cctotal) * 100, MidpointRounding.AwayFromZero).ToString() : Convert.ToString(0);
                    _drow["FLUSH_AFTERCHEM"] = (count == _faccna)?"N/A":(_facctotal > 0) ? Decimal.Round((_facc / _facctotal) * 100, MidpointRounding.AwayFromZero).ToString() : Convert.ToString(0);
                    _drow["BACK_FLUSH"] = (count == _bfcna)?"N/A":(_bfctotal > 0) ? Decimal.Round((_bfc / _bfctotal) * 100, MidpointRounding.AwayFromZero).ToString() : Convert.ToString(0);
                    _drow["CHEMICAL_TREATMENT"] = (count == _fctna)?"N/A":(_fcttotal > 0) ? Decimal.Round((_fct / _fcttotal) * 100, MidpointRounding.AwayFromZero).ToString() : Convert.ToString(0);
                    _drow["PLANNED_PROGRESS"] = (count == _NA) ? "N/A" : (_totalplanned > 0) ? Decimal.Round((_pcdate / _totalplanned) * 100, MidpointRounding.AwayFromZero).ToString() : Convert.ToString(0);
                    _drow["ACTUAL_PROGRESS"] = (count == _NA)?"N/A":(_totalApplicable > 0) ? Decimal.Round((_percomplete / _totalApplicable), MidpointRounding.AwayFromZero).ToString() : Convert.ToString(0);
                    _drow["PFTOT"] = _pftotal;
                    _drow["FVRTOT"] = _fvrtotal;
                    _drow["CCTOT"] = _cctotal;
                    _drow["FACTOT"]= _facctotal;
                    _drow["BFTOT"] = _bfctotal;
                    _drow["CTTOT"] = _fcttotal;
                    _drow["PF"] = _pf;
                    _drow["FVR"] = _fvr;
                    _drow["CC"] = _cc;
                    _drow["FAC"] = _facc;
                    _drow["BF"] = _bfc;
                    _drow["CT"] = _fct;
                    _drow["PLANNED"] = _pcdate;
                    _drow["TOTALAPP"] = _totalApplicable;
                    _drow["TOTPLAN"] = _totalplanned;
                    _drow["COMPLETED"] = _percomplete;
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
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drprogress.SelectedItem.Text);
        }
        protected void drcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["cat"] = drcategory.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drprogress.SelectedItem.Text);
            //Generate_Summary();
        }
        protected void drflevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["flvl"] = drflevel.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drprogress.SelectedItem.Text);
        }
        protected void drfed_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["fed"] = drfed.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drprogress.SelectedItem.Text);
        }
        private void Insert_Summary()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clscassheet _objcls = new _clscassheet();
            _objbll.Clear_CassummaryRpt1(_objdb);
            var _result = from _data in _summary.AsEnumerable()
                          select _data;
            //int count = 0;
            foreach (var row in _result)
            {
                _objcls.sys_name = row["SYS_NAME"].ToString();
                _objcls.testd1 = (row["PLAIN_FLUSH"].ToString() == "N/A") ? -1 : Convert.ToDecimal(row["PLAIN_FLUSH"]);
                _objcls.testd2 = (row["FLUSH_VELOCITY"].ToString() == "N/A") ? -1 : Convert.ToDecimal(row["FLUSH_VELOCITY"]);
                _objcls.testd3 = (row["CHEMICAL_CLEAN"].ToString() == "N/A") ? -1 : Convert.ToDecimal(row["CHEMICAL_CLEAN"]);
                _objcls.testd4 = (row["FLUSH_AFTERCHEM"].ToString() == "N/A") ? -1 : Convert.ToDecimal(row["FLUSH_AFTERCHEM"]);
                _objcls.qty1 = (row["BACK_FLUSH"].ToString() == "N/A") ? -1 : Convert.ToDecimal(row["BACK_FLUSH"]);
                _objcls.qty2 = (row["CHEMICAL_TREATMENT"].ToString() == "N/A") ? -1 : Convert.ToDecimal(row["CHEMICAL_TREATMENT"]);
                _objcls.testd = (row["PLANNED_PROGRESS"].ToString() == "N/A") ? -1 : Convert.ToDecimal(row["PLANNED_PROGRESS"]);
                _objcls.total = (row["ACTUAL_PROGRESS"].ToString() == "N/A") ? -1 : Convert.ToDecimal(row["ACTUAL_PROGRESS"]);
                _objcls.qty3 = 0;
                _objcls.qty4 = 0;
                _objcls.quaty = Convert.ToDecimal(row["QTY"].ToString());
                _objbll.Generate_CASSummary_PKG_RPT_CCAD_FAS(_objcls, _objdb);
                //count += 1;
            }
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + count.ToString() + "');", true);
        }

        protected void drloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["loc"] = drloc.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drprogress.SelectedItem.Text);
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

        protected void drprogress_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["pro"] = drprogress.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drprogress.SelectedItem.Text);
        }

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
            drbuilding.SelectedValue = (string)Session["zone"];
            drcategory.SelectedValue = (string)Session["cat"];
            drflevel.SelectedValue = (string)Session["flvl"];
            drfed.SelectedValue = (string)Session["fed"];
            drloc.SelectedValue = (string)Session["loc"];
            drprogress.SelectedValue = (string)Session["pro"];
        }
        private void Filtering_zero()
        {
            Load_Master();
            _dtfilter = _dtresult;
            var _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<decimal>("per_com1") == 0
                          select o;
            _dtresult = _filter.Any() ? _filter.CopyToDataTable() : _dtresult.Clone();
            Load_Details();
            Generate_Summary();
        }
        protected void genPcd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdnpcd.Value)) Generate_Summary();

        }
    }
}
