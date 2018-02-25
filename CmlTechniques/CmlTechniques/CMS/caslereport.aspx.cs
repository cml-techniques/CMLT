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
    public partial class caslereport : System.Web.UI.Page
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
                string _prm = Request.QueryString["prj"].ToString();
                lblsch.Text = Request.QueryString["id"].ToString();
                lblprj.Text = _prm;
                //Populate_view();
                Load_Master();
                Session["filter"] = "no";
                Session["zone"] = "All";
                Session["flvl"] = "All";
                Session["cat"] = "All";
                Session["fed"] = "All";
                Session["loc"] = "All";
                Load_Details();
                
                Hide_Details();
                
                Load_TestNames();

                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    Generate_Summary_asao();
                    lblhead.Text = "CAS MISC2 Conveying Systems Commissioning Activity Schedule";
                }
                else if (lblprj.Text == "12761")
                {
                    Generate_Summary1();
                    lblhead.Text = "CAS Conveying Systems Commissioning Activity Schedule";
                }
                else if(lblprj.Text == "11784")
                {
                    if (Request.QueryString["sch"].ToString() == "44")
                    { lblhead.Text = "CAS MISC1 Lifts & Escalators Commissioning Activity Schedule  - Marketing Suite "; }
                    else
                    lblhead.Text = "CAS MISC1 Lift & Conveying Systems Commissioning Activity Schedule";
                    Generate_Summary();
                      
                }
                else if (lblprj.Text == "MOE")
                {
                    Generate_Summary1();
                    lblhead.Text = "CAS MISC1 - Horizontal & Vertical Transportation Systems Commissioning Activity Schedule";
                }
                else
                {
                    lblhead.Text = "CAS MISC1 Lifts & Escalators Commissioning Activity Schedule";
                    Generate_Summary();
                }
                    
                }
            }
        private void Load_TestNames()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32(lblsch.Text);
            _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
        }
        private void Load_Filtering_Elements()
        {
            drbuilding.Items.Clear();
            drcategory.Items.Clear();
            drfed.Items.Clear();
            drflevel.Items.Clear();
            drloc.Items.Clear();
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
            drbuilding.Items.Insert(0, "All");
            drcategory.Items.Insert(0, "All");
            drflevel.Items.Insert(0, "All");
            drfed.Items.Insert(0, "All");
            drloc.Items.Insert(0, "All");
            drbuilding.SelectedValue = (string)Session["zone"];
            drcategory.SelectedValue = (string)Session["cat"];
            drflevel.SelectedValue = (string)Session["flvl"];
            drfed.SelectedValue = (string)Session["fed"];
            drloc.SelectedValue = (string)Session["loc"];
        }
        private void Load_Master()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32(lblsch.Text);
            _objcas.prj_code = lblprj.Text;

            if (lblprj.Text == "HMIM" || lblprj.Text == "14211" || lblprj.Text == "HMHS")
            {
                if(Request.QueryString["fcl"] != null)
                    _objcas.sys = Convert.ToInt32(Request.QueryString["fcl"]);
            }
            else
                _objcas.sys = 0;
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
            _dtresult = _dtMaster;
            _dtfilter = _dtresult;
            _summary = _dtresult;

            if (lblprj.Text == "11784" && (lblsch.Text == "44")) { lblhead.Text = lblhead.Text + " - Marketing Suite"; }
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
             string _path ="";
            //Session["zone"] = drbuilding.SelectedItem.Value;
            //Session["flvl"] = drflevel.SelectedItem.Value;
            //Session["cat"] = drcategory.SelectedItem.Value;
            //Session["fed"] = drfed.SelectedItem.Value;
            Insert_Summary();
            string _fcltyID = (Request.QueryString["fcl"] != null) ? Request.QueryString["fcl"].ToString() : "";
            
             if (lblprj.Text == "11784" && !string.IsNullOrEmpty(lblsch.Text))
            {

                _path = "Cas_Report.aspx?id="+lblsch.Text+"_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value + "_Z1" + "&Div=" + _fcltyID;
            }
            else 
             _path = "Cas_Report.aspx?id=23_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value + "_Z1" + "&Div=" + _fcltyID;
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
                //Label _sys_id = (Label)e.Row.FindControl("lbSys_Id");
                //DataTable _dtdetails = new DataTable();
                //_dtdetails.Columns.Add("e_b_ref", typeof(string));
                //_dtdetails.Columns.Add("B_Z", typeof(string));
                //_dtdetails.Columns.Add("Cat", typeof(string));
                //_dtdetails.Columns.Add("F_lvl", typeof(string));
                //_dtdetails.Columns.Add("Seq_No", typeof(string));
                //_dtdetails.Columns.Add("Loc", typeof(string));
                //_dtdetails.Columns.Add("F_from", typeof(string));
                //_dtdetails.Columns.Add("C_id", typeof(int));
                //_dtdetails.Columns.Add("Sys_name", typeof(string));
                //_dtdetails.Columns.Add("Sys_id", typeof(int));
                //_dtdetails.Columns.Add("test1", typeof(string));
                //_dtdetails.Columns.Add("test2", typeof(string));
                //_dtdetails.Columns.Add("test3", typeof(string));
                //_dtdetails.Columns.Add("test4", typeof(string));
                //_dtdetails.Columns.Add("test5", typeof(string));
                //_dtdetails.Columns.Add("test6", typeof(string));
                //_dtdetails.Columns.Add("test7", typeof(string));
                //_dtdetails.Columns.Add("Per_com", typeof(string));
                //_dtdetails.Columns.Add("Accept1", typeof(string));
                //_dtdetails.Columns.Add("filed1", typeof(string));
                //_dtdetails.Columns.Add("Comm", typeof(string));
                //_dtdetails.Columns.Add("Act_by", typeof(string));
                //_dtdetails.Columns.Add("Act_date", typeof(string));
                //var _details = from _data in _dtresult.AsEnumerable()
                //               where _data.Field<int>("Sys_Id") == Convert.ToInt32(_sys_id.Text)
                //               select _data;
                //foreach (var row in _details)
                //{
                //    DataRow _row = _dtdetails.NewRow();
                //    _row[0] = row["e_b_ref"].ToString();
                //    _row[1] = row["B_Z"].ToString();
                //    _row[2] = row["Cat"].ToString();
                //    _row[3] = row["F_lvl"].ToString();
                //    _row[4] = SeqNo(row["Seq_No"].ToString());
                //    _row[5] = row["Loc"].ToString();
                //    _row[6] = row["F_from"].ToString();
                //    _row[7] = row["C_id"].ToString();
                //    _row[8] = row["Sys_name"].ToString();
                //    _row[9] = row["Sys_id"].ToString();
                //    _row[10] = row["test1"].ToString();
                //    _row[11] = row["test2"].ToString();
                //    _row[12] = row["test3"].ToString();
                //    _row[13] = row["test4"].ToString();
                //    _row[14] = row["test5"].ToString();
                //    _row[15] = row["test6"].ToString();
                //    _row[16] = row["test7"].ToString();
                //    if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                //        _row[17] = row["Per_com1"].ToString();
                //    else
                //        _row[17] = row["Per_com8"].ToString();
                //    _row[18] = row["accept1"].ToString();
                //    _row[19] = row["filed1"].ToString();
                //    _row[20] = row["Comm"].ToString();
                //    _row[21] = row["Act_by"].ToString();
                //    _row[22] = row["Act_date"].ToString();
                //    _dtdetails.Rows.Add(_row);
                //}
                //GridView _mydetails = (GridView)e.Row.FindControl("mydetails");
                //_mydetails.DataSource = _dtdetails;
                //_mydetails.DataBind();
                //Generate_Summary();

                //if (_exp == false)
                //{
                //    _mydetails.Visible = false;
                //    _btn.Text = "+";
                //}
                //else
                //{
                //    _mydetails.Visible = true;
                //    _btn.Text = "-";
                //}
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
            //if (lblprj.Text == "12761")
                //e.Row.Cells[15].Visible = false;
            //else
                e.Row.Cells[16].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _lbl = (Label)e.Row.FindControl("Label1");
                Label _lbl1 = (Label)e.Row.FindControl("Label2");
                if (_lbl.Text == "0.00%")
                    _lbl.Text = "";
                if (_lbl1.Text == "0.00%")
                    _lbl1.Text = "";
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
            //_dtfilter = _dtMaster;
            var _filter = from o in _dtfilter.AsEnumerable()
                          select o;

            _filter = from o in _dtfilter.AsEnumerable()
                      where (_el1 == "All" || o.Field<string>("B_Z") == _el1) && (_el2 == "All" || o.Field<string>("Cat") == _el2) && (_el3 == "All" || o.Field<string>("F_lvl") == _el3) && (_el4 == "All" || o.Field<string>("F_from") == _el4) && (_el5 == "All" || o.Field<string>("Loc") == _el5)
                      select o;

            
            _dtresult = _filter.Any() ? _filter.CopyToDataTable() : _dtMaster.Clone();
            Load_Details();
            if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                Generate_Summary_asao();
            else if (lblprj.Text == "12761")
                Generate_Summary1();
            else
                Generate_Summary();
        }
        private void Generate_Summary()
        {
            try
            {
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("TESTED", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;
                decimal _total = 0;
                decimal _count1 = 0;
                decimal _count2 = 0;
                decimal _LiftCount = 0;
                decimal _EscCount = 0;
                decimal _travelCount = 0;
                decimal _BMUCount = 0;
                decimal _LiftTested = 0;
                decimal _EscTested = 0;
                decimal _travelTested = 0;
                decimal _BMUTested = 0; 

                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com8"].ToString());
                    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                    
                    if (_row["Cat"].ToString() == "LIFT")
                        _count2 += 1;
                    _count1 += 1;

                    if (_row["Cat"].ToString() == "LIFT")
                    {
                        _LiftCount += 1;
                        if(_row["per_com1"].ToString() == "100" || _row["per_com1"].ToString() == "100.00")
                        _LiftTested += 1;
                    }
                    else if (_row["Cat"].ToString() == "TRV")
                    {
                        _travelCount += 1;
                        if (_row["per_com1"].ToString() == "100" || _row["per_com1"].ToString() == "100.00")
                            _travelTested += 1;
                    }
                    else if (_row["Cat"].ToString() == "ESC")
                    {
                        _EscCount += 1;
                        if (_row["per_com1"].ToString() == "100" || _row["per_com1"].ToString() == "100.00")
                            _EscTested += 1;
                    }
                    else if (_row["Cat"].ToString() == "BMU")
                    {
                        _BMUCount += 1;
                        if (_row["per_com1"].ToString() == "100" || _row["per_com1"].ToString() == "100.00")
                            _BMUTested += 1;
                    }
                }
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    if (row[0].ToString() == "Tested & Comm.") { _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = Decimal.Round(_count1); }
                    else if (row[0].ToString() == "3rd Party Inspected") { _drow[2] = Decimal.Round(_p2).ToString(); _drow[1] = Decimal.Round(_count1); }
                    else if (row[0].ToString() == "Emergency Lighting") { _drow[2] = Decimal.Round(_p3).ToString(); _drow[1] = Decimal.Round(_count2); }
                    else if (row[0].ToString() == "Power Failure Mode") { _drow[2] = Decimal.Round(_p4).ToString(); _drow[1] = Decimal.Round(_count1); }
                    else if (row[0].ToString() == "Lift Monitoring System") { _drow[2] = Decimal.Round(_p5).ToString(); _drow[1] = Decimal.Round(_count2); }
                    else if (row[0].ToString() == "Intercom") { _drow[2] = Decimal.Round(_p6).ToString(); _drow[1] = Decimal.Round(_count2); }
                    else if (row[0].ToString() == "BMS/ Fire Alarm Interface") { _drow[2] = Decimal.Round(_p7).ToString(); _drow[1] = Decimal.Round(_count1); }
                    else if (row[0].ToString() == "Lifts / Elevators") { _drow[2] = Decimal.Round(_LiftTested).ToString(); _drow[1] = Decimal.Round(_LiftCount); }
                    else if (row[0].ToString() == "Escalators") { _drow[2] = Decimal.Round(_EscTested).ToString(); _drow[1] = Decimal.Round(_EscCount); }
                    else if (row[0].ToString() == "Travelators") { _drow[2] = Decimal.Round(_travelTested).ToString(); _drow[1] = Decimal.Round(_travelCount); }
                    else if (row[0].ToString() == "BMUs") { _drow[2] = Decimal.Round(_BMUTested).ToString(); _drow[1] = Decimal.Round(_BMUCount); }

                    if (_drow[2].ToString() != "0" && _drow[1].ToString() != string.Empty &&_drow[2].ToString() != string.Empty)
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = _total.ToString();
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
        private void Generate_Summary_asao()
        {
            try
            {
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("TESTED", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;
                decimal _total = 0;
                decimal _count1 = 0;
                decimal _count2 = 0;
                int _qty1 = 0;
                int _qty2 = 0;
                int _qty3 = 0;
                int _qty4 = 0;
                int _qty5 = 0;
                int _qty6 = 0;
                int _qty7 = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com8"].ToString());
                    
                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    
                    _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                    if (_row["test1"].ToString().ToUpper() != "N/A") _qty1 += 1;
                    if (_row["Cat"].ToString() == "LIFT")
                    {
                        if (_row["test3"].ToString().ToUpper() != "N/A") _qty3 += 1;
                        if (_row["test5"].ToString().ToUpper() != "N/A") _qty5 += 1;
                        if (_row["test6"].ToString().ToUpper() != "N/A") _qty6 += 1;
                        if (_row["test7"].ToString().ToUpper() != "N/A") _qty7 += 1;
                        if (_row["test4"].ToString().ToUpper() != "N/A") _qty4 += 1;
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    }
                    else if (_row["Cat"].ToString() == "ESC")
                    {
                        if (_row["test3"].ToString().ToUpper() != "N/A") _qty3 += 1;
                        if (_row["test5"].ToString().ToUpper() != "N/A") _qty5 += 1;
                        if (_row["test6"].ToString().ToUpper() != "N/A") _qty6 += 1;
                        if (_row["test7"].ToString().ToUpper() != "N/A") _qty7 += 1;
                    }
                    else if (_row["Cat"].ToString() == "BMU")
                    {
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        if (_row["test2"].ToString().ToUpper() != "N/A") _qty2 += 1;
                        if (_row["test4"].ToString().ToUpper() != "N/A") _qty4 += 1;
                    }
                    
                    //if (_row["Cat"].ToString() == "LIFT")
                    //    _count2 += 1;
                    //_count1 += 1;
                }
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    if (row[0].ToString() == "Tested & Comm.") { _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = Decimal.Round(_qty1); }
                    else if (row[0].ToString() == "3rd Party Inspected") { _drow[2] = Decimal.Round(_p2).ToString(); _drow[1] = Decimal.Round(_qty2); }
                    else if (row[0].ToString() == "Emergency Lighting") { _drow[2] = Decimal.Round(_p3).ToString(); _drow[1] = Decimal.Round(_qty3); }
                    else if (row[0].ToString() == "Power Failure Mode") { _drow[2] = Decimal.Round(_p4).ToString(); _drow[1] = Decimal.Round(_qty4); }
                    else if (row[0].ToString() == "Lift Monitoring System") { _drow[2] = Decimal.Round(_p5).ToString(); _drow[1] = Decimal.Round(_qty5); }
                    else if (row[0].ToString() == "Intercom") { _drow[2] = Decimal.Round(_p6).ToString(); _drow[1] = Decimal.Round(_qty6); }
                    else if (row[0].ToString() == "BMS/ Fire Alarm Interface") { _drow[2] = Decimal.Round(_p7).ToString(); _drow[1] = Decimal.Round(_qty7); }
                    if (_drow[1].ToString() != "0")
                    {
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                        _drow[3] = _total.ToString();
                        _dtsummary.Rows.Add(_drow);
                    }
                }
                mygridsumm.DataSource = _dtsummary;
                mygridsumm.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Generate_Summary1()
        {
            try
            {
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("TESTED", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));

                int count = 0;
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _total = 0;
                    decimal _qty = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        if (_row["per_com1"].ToString() == "100")
                            _p2 += 1;
                        //_p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        //_p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        //_p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        //_p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        //_p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        //_p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                        //count += Convert.ToInt32(_row["devices1"].ToString());
                        _qty += 1;
                    }
                    decimal _per1 = 0;
                   // _per1 = (_p1 + _p2 + _p3 + _p4 + _p5 + _p6 + _p7) / 7;
                    _per1 = _p2;
                    if (_qty != 0)
                        _total = decimal.Round((_per1 / _qty) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = _qty.ToString();
                    _drow[2] = decimal.Round(_p2).ToString();
                    _drow[3] = _total.ToString();
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
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text);
        }
        protected void drcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["cat"] = drcategory.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text);
            //Generate_Summary();
        }
        protected void drflevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["flvl"] = drflevel.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text);
        }
        protected void drfed_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["fed"] = drfed.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text);
        }
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
                _objcls.per_com1 = Convert.ToDecimal(row["TESTED"].ToString());
                _objcls.per_com2 = 0;
                _objcls.per_com3 = 0;
                _objcls.total = Convert.ToDecimal(row["TOTAL"].ToString());
                _objcls.cate = row["SYS_NAME"].ToString();
                _objcls.quantity = Convert.ToInt32(row["QTY"].ToString());
                _objbll.Generate_CASSummary_PKG_RPT(_objcls, _objdb);
                //count += 1;
            }
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + count.ToString() + "');", true);
        }

        protected void drloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["loc"] = drloc.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text);
        }

        decimal _qty = 0;
        decimal _tested = 0;
        decimal _rows = 0;
        decimal _overall = 0;
        decimal _sumry = 0;
        protected void mygridsumm_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[5].Visible = false;
            if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                e.Row.Cells[3].Visible = false;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                    e.Row.Cells[1].Text = "EQUIPMENT";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
                _qty += Convert.ToDecimal(e.Row.Cells[2].Text);
                _tested += Convert.ToDecimal(e.Row.Cells[3].Text);
                _overall += Convert.ToDecimal(e.Row.Cells[5].Text);
                
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    //decimal _weight = 0;
                    //if (e.Row.Cells[1].Text == "Tested &amp; Comm.")
                    //{
                    //    if (drcategory.SelectedItem.Text == "LIFT") _weight = 0.24m;
                    //    else if (drcategory.SelectedItem.Text == "ESC") _weight = 0.90m;
                    //    else if (drcategory.SelectedItem.Text == "BMU") _weight = 0.50m;
                    //}
                    //else if (e.Row.Cells[1].Text == "3rd Party Inspected") { _weight = 0.5m; }
                    //else if (e.Row.Cells[1].Text == "Emergency Lighting") { _weight = 0.22m; }
                    //else if (e.Row.Cells[1].Text == "Power Failure Mode") { _weight = 0.22m; }
                    ////else if (e.Row.Cells[1].Text == "Lift Monitoring System") { _drow[2] = Decimal.Round(_p5).ToString(); _drow[1] = Decimal.Round(_qty5); }
                    //else if (e.Row.Cells[1].Text == "Intercom") { _weight = 0.22m; }
                    //else if (e.Row.Cells[1].Text == "BMS/ Fire Alarm Interface") { _weight = 0.1m; }
                    //_sumry += (Convert.ToDecimal(e.Row.Cells[5].Text) * _weight);
                    _sumry += (Convert.ToDecimal(e.Row.Cells[5].Text) * Convert.ToDecimal(e.Row.Cells[2].Text));
                }
                _rows += 1;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "SUMMARY";
                e.Row.Cells[2].Text = _qty.ToString();
                e.Row.Cells[3].Text = _tested.ToString();
                string _total = "0";
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                    _total = Decimal.Round(_sumry/_qty).ToString() + '%';
                //else if (lblprj.Text == "MOE" || lblprj.Text == "MOE1")
                //    _total = Decimal.Round(_overall / _rows).ToString() + '%';
                else
                {
                    if (_qty != 0)
                        _total = (Decimal.Round((_tested / _qty) * 100,MidpointRounding.AwayFromZero)).ToString() + '%';
                }
                e.Row.Cells[4].Text = _total;
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
    }
}
