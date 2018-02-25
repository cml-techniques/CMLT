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
using System.Collections.Generic;

namespace CmlTechniques.CMS
{
    public partial class casme1report : System.Web.UI.Page
    {
        [Serializable]
        private class minfo_
        {
            // indexes of merged columns
            public List<int> MergedColumns = new List<int>();
            // key-value pairs: key = the first column index, value = number of the merged columns
            public Hashtable StartColumns = new Hashtable();
            // key-value pairs: key = the first column index, value = common title of the merged columns 
            public Hashtable Titles = new Hashtable();

            //parameters: the merged columns indexes, common title of the merged columns 
            public void AddMergedColumns(int[] columnsIndexes, string title)
            {
                MergedColumns.AddRange(columnsIndexes);
                StartColumns.Add(columnsIndexes[0], columnsIndexes.Length);
                Titles.Add(columnsIndexes[0], title);
            }
        }
        private minfo_ info
        {
            get
            {
                if (ViewState["info"] == null)
                    ViewState["info"] = new minfo_();
                return (minfo_)ViewState["info"];
            }
        }
        private minfo_ info1
        {
            get
            {
                if (ViewState["info1"] == null)
                    ViewState["info1"] = new minfo_();
                return (minfo_)ViewState["info1"];
            }
        }
        private void RenderHeader(HtmlTextWriter output, Control container)
        {
            for (int i = 0; i < container.Controls.Count; i++)
            {
                TableCell cell = (TableCell)container.Controls[i];
                //stretch non merged columns for two rows
                if (!info.MergedColumns.Contains(i))
                {
                    cell.Attributes["rowspan"] = "2";
                    cell.RenderControl(output);
                }
                else //render merged columns common title
                    if (info.StartColumns.Contains(i))
                    {
                        output.Write(string.Format("<th align='center' style='font-weight:normal' colspan='{0}'>{1}</th>",
                                 info.StartColumns[i], info.Titles[i]));
                    }
            }

            //close the first row	
            output.RenderEndTag();
            //set attributes for the second row
            //mygrid.HeaderStyle.AddAttributesToRender(output);
            //start the second row
            output.RenderBeginTag("tr");

            //render the second row (only the merged columns)
            for (int i = 0; i < info.MergedColumns.Count; i++)
            {
                TableCell cell = (TableCell)container.Controls[info.MergedColumns[i]];
                cell.RenderControl(output);
            }
        }
        public static DataTable _dtMaster;
        public static DataTable _dtfilter;
        public static DataTable _dtresult;
        public static DataTable _summary;
        public static DataTable _dtMaster1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "CreateGridHeader", "<script>CreateGridHeader('DataDiv', 'mymaster','HeaderDiv');</script>");
                string _prm = Request.QueryString[0].ToString();
                lblsch.Text = _prm.Substring(0, _prm.IndexOf("_P"));
                lblprj.Text = _prm.Substring(_prm.IndexOf("_P") + 2);
                //Load_Master();
                //Load_Details();
                //Session["filter"] = "no";
                //Session["zone"] = "All";
                //Session["flvl"] = "All";
                //Session["cat"] = "All";
                //Session["fed"] = "All";
                //Session["loc"] = "All";
                //Session["pro"] = "All";
                //Session["zero"] = "1";
                //Hide_Details();
                //if (lblsch.Text == "55")
                //    Generate_Summary1();
                //else
                //    Generate_Summary();
                if (lblsch.Text == "8")
                    lblhead.Text = "6.3.1 - Chilled Water System Commissioning Activity Schedule";
                else if (lblsch.Text == "51")
                    lblhead.Text = "6.3.2 - Hot Water System (MTHW) Commissioning Activity Schedule";
                else if (lblsch.Text == "52")
                    lblhead.Text = "6.3.3 - Heat Recovery and Terminal Reheat Systems Commissioning Activity Schedule";
                else if (lblsch.Text == "53")
                    lblhead.Text = "6.3.4 - Generator Cooling Radiator System Commissioning Activity Schedule";
                else if (lblsch.Text == "54")
                    lblhead.Text = "6.3.5 - Steam System Commissioning Activity Schedule";
                else if (lblsch.Text == "55")
                    lblhead.Text = "6.3.6 - Air Handling Systems Commissioning Activity Schedule";
                else if (lblsch.Text == "56")
                    lblhead.Text = "6.3.7 - Ventilation Systems Commissioning Activity Schedule";
                else if (lblsch.Text == "57")
                    lblhead.Text = "6.3.8 - Fan Coil Units Commissioning Activity Schedule";
                else if (lblsch.Text == "58")
                    lblhead.Text = "6.3.9 - Close Control Air Condition Units Commissioning Activity Schedule";
                else if (lblsch.Text == "59")
                    lblhead.Text = "6.3.10 - Life Safety Ventilation Systems Commissioning Activity Schedule";
                else if (lblsch.Text == "60")
                    lblhead.Text = "6.3.11 - Clean Room Systems Commissioning Activity Schedule";
                else if (lblsch.Text == "61")
                    lblhead.Text = "6.3.6.1 - VAV Commissioning Activity Schedule";
                else if (lblsch.Text == "62")
                    lblhead.Text = "6.3.6.2 - ECV Commissioning Activity Schedule";
                else if (lblsch.Text == "63")
                    lblhead.Text = "6.3.6.1.1 - CUP - HVAC Systems 1-14 Commissioning Activity Schedule";
                else if (lblsch.Text == "64")
                    lblhead.Text = "6.3.6.1.2 - CLINIC - HVAC Systems 15 Commissioning Activity Schedule";
                else if (lblsch.Text == "65")
                    lblhead.Text = "6.3.6.1.3 - D&T - HVAC Systems 16&17 Commissioning Activity Schedule";
                else if (lblsch.Text == "66")
                    lblhead.Text = "6.3.6.1.4 - D&T - HVAC Systems 17&18 Commissioning Activity Schedule";
                else if (lblsch.Text == "67")
                    lblhead.Text = "6.3.6.1.5 - ICU - HVAC Systems 20 Commissioning Activity Schedule";
                else if (lblsch.Text == "68")
                    lblhead.Text = "6.3.6.1.6 - SWING WING - HVAC Systems 21 Commissioning Activity Schedule";
                else if (lblsch.Text == "69")
                    lblhead.Text = "6.3.6.1.7 - PATIENT TOWER - HVAC Systems 22 Commissioning Activity Schedule";
                else if (lblsch.Text == "70")
                    lblhead.Text = "6.3.6.1.8 - PATIENT TOWER - HVAC Systems 23 Commissioning Activity Schedule";
                else if (lblsch.Text == "71")
                    lblhead.Text = "6.3.6.1.9 - PATIENT TOWER - HVAC Systems 26&27 Commissioning Activity Schedule";
                else if (lblsch.Text == "72")
                    lblhead.Text = "6.3.6.1.10 - CAR PARK Commissioning Activity Schedule";
                else if (lblsch.Text == "73")
                    lblhead.Text = "6.3.6.1.11 - MISC Commissioning Activity Schedule";
                else if (lblsch.Text == "74")
                    lblhead.Text = "6.3.6.2.1 - CUP - HVAC Systems 1-14 Commissioning Activity Schedule";
                else if (lblsch.Text == "75")
                    lblhead.Text = "6.3.6.2.2 - CLINIC - HVAC Systems 15 Commissioning Activity Schedule";
                else if (lblsch.Text == "76")
                    lblhead.Text = "6.3.6.2.3 - D&T - HVAC Systems 16&17 Commissioning Activity Schedule";
                else if (lblsch.Text == "77")
                    lblhead.Text = "6.3.6.2.4 - D&T - HVAC Systems 17&18 Commissioning Activity Schedule";
                else if (lblsch.Text == "78")
                    lblhead.Text = "6.3.6.2.5 - ICU - HVAC Systems 20 Commissioning Activity Schedule";
                else if (lblsch.Text == "79")
                    lblhead.Text = "6.3.6.2.6 - SWING WING - HVAC Systems 21 Commissioning Activity Schedule";
                else if (lblsch.Text == "80")
                    lblhead.Text = "6.3.6.2.7 - PATIENT TOWER - HVAC Systems 22 Commissioning Activity Schedule";
                else if (lblsch.Text == "81")
                    lblhead.Text = "6.3.6.2.8 - PATIENT TOWER - HVAC Systems 23 Commissioning Activity Schedule";
                else if (lblsch.Text == "82")
                    lblhead.Text = "6.3.6.2.9 - PATIENT TOWER - HVAC Systems 26&27 Commissioning Activity Schedule";
                else if (lblsch.Text == "83")
                    lblhead.Text = "6.3.6.2.10 - CAR PARK Commissioning Activity Schedule";
                else if (lblsch.Text == "84")
                    lblhead.Text = "6.3.6.2.11 - MISC Commissioning Activity Schedule";
                //Head_Merging();
            }
        }
        private void Loading()
        {
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
            if (lblsch.Text == "55")
                Generate_Summary1();
            else
                Generate_Summary();
            Head_Merging();
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
                        orderby dRow["per_com4"]
                        select new { col1 = dRow["per_com4"] }).Distinct();
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
            _objcas.sch = Convert.ToInt32(lblsch.Text);
            _objcas.prj_code = lblprj.Text;
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
            _dtresult = _dtMaster;
            _summary = _dtMaster;
            //CAS.Class1._OBJ_DATA_CAS.EnableCaching = true;
            //Class1._OBJ_DATA_CAS.EnableCaching = true;
            //var _dv = (DataView)Class1._OBJ_DATA_CAS.Select();
            //DataTable _dtemp = _dv.ToTable();
            //IEnumerable<DataRow> _result = from _data in _dtemp.AsEnumerable()
            //                               where _data.Field<int>("Cas_Schedule") == Convert.ToInt32(lblsch.Text)
            //                               select _data;
            //_dtMaster = _result.CopyToDataTable<DataRow>();
            //_dtresult = _dtMaster;
            //_summary = _dtMaster;
        }
        private void Load_Master1(int sch)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = sch;
            _objcas.prj_code = lblprj.Text;
            _dtMaster1 = _objbll.Load_casMain_Edit(_objcas, _objdb);
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
        decimal _pre_qty = 0;
        decimal _comm_qty = 0;
        decimal _pft = 0;
        decimal _pwron = 0;
        decimal _fpt = 0;
        decimal _arm = 0;
        decimal _count = 0;
        protected void mygridsumm_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[14].Visible = false;
            //e.Row.Cells[8].Visible = false;
            //e.Row.Cells[9].Visible = false;
            //e.Row.Cells[10].Visible = false;
            //e.Row.Cells[11].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
                _qty += Convert.ToDecimal(e.Row.Cells[2].Text);
                _pre_qty += Convert.ToDecimal(e.Row.Cells[3].Text);
                _comm_qty += Convert.ToDecimal(e.Row.Cells[5].Text);
                _pft += Convert.ToDecimal(e.Row.Cells[8].Text);
                _pwron += Convert.ToDecimal(e.Row.Cells[9].Text);
                _fpt += Convert.ToDecimal(e.Row.Cells[10].Text);
                _arm += Convert.ToDecimal(e.Row.Cells[11].Text);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "SUMMARY";
                e.Row.Cells[2].Text = _qty.ToString();
                e.Row.Cells[3].Text = _pre_qty.ToString();
                e.Row.Cells[4].Text = Decimal.Round((_pre_qty / _qty) * 100).ToString() + "%";
                e.Row.Cells[5].Text = _comm_qty.ToString();
                e.Row.Cells[6].Text = Decimal.Round((_comm_qty / _qty) * 100).ToString() + "%";
                decimal _total1 = Decimal.Round(((_pre_qty * 0.1m + _comm_qty * 0.9m) / _qty) * 100, 0, MidpointRounding.AwayFromZero);
                e.Row.Cells[7].Text = _total1.ToString() + '%';
                e.Row.Cells[8].Text = (Decimal.Round(_pft)).ToString();
                e.Row.Cells[9].Text = (Decimal.Round(_pwron)).ToString();
                e.Row.Cells[10].Text = (Decimal.Round(_fpt)).ToString();
                e.Row.Cells[11].Text = (Decimal.Round(_arm)).ToString();
                decimal _total2=Decimal.Round(((_fpt * 0.25m + _arm * 0.25m + _pft * 0.25m + _pwron * 0.25m) / _qty) * 100,0,MidpointRounding.AwayFromZero);
                e.Row.Cells[12].Text = _total2.ToString() + '%';
                e.Row.Cells[13].Text = (Decimal.Round(_total1 * 0.8m + _total2 * 0.2m)).ToString() + '%';
            }
        }
        protected void print_Click(object sender, EventArgs e)
        {
            //Session["zone"] = drbuilding.SelectedItem.Value;
            //Session["flvl"] = drflevel.SelectedItem.Value;
            //Session["cat"] = drcategory.SelectedItem.Value;
            //Session["fed"] = drfed.SelectedItem.Value;
            Insert_Summary();
            string _path = "Cas_Report.aspx?id=" + lblsch.Text + "1_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value + "_Z" + (string)Session["zero"];
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.open('" + _path + "');", true);
        }
        protected void mymaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _sys_id = (Label)e.Row.FindControl("lbSys_Id");
                DataTable _dtdetails = new DataTable();
                _dtdetails.Columns.Add("e_b_ref", typeof(string));
                _dtdetails.Columns.Add("B_Z", typeof(string));
                _dtdetails.Columns.Add("Cat", typeof(string));
                _dtdetails.Columns.Add("F_lvl", typeof(string));
                _dtdetails.Columns.Add("Seq_No", typeof(string));
                _dtdetails.Columns.Add("Loc", typeof(string));
                _dtdetails.Columns.Add("Des", typeof(string));
                _dtdetails.Columns.Add("F_from", typeof(string));
                _dtdetails.Columns.Add("Substation", typeof(string));
                _dtdetails.Columns.Add("devices1", typeof(string));
                _dtdetails.Columns.Add("C_id", typeof(int));
                _dtdetails.Columns.Add("Sys_name", typeof(string));
                _dtdetails.Columns.Add("Sys_id", typeof(int));

                _dtdetails.Columns.Add("Pwr_on", typeof(string));
                _dtdetails.Columns.Add("test1", typeof(string));
                _dtdetails.Columns.Add("test2", typeof(string));
                _dtdetails.Columns.Add("test3", typeof(string));
                _dtdetails.Columns.Add("test4", typeof(string));
                _dtdetails.Columns.Add("test5", typeof(string));
                _dtdetails.Columns.Add("test6", typeof(string));
                _dtdetails.Columns.Add("Per_com4", typeof(string));
                _dtdetails.Columns.Add("Accept1", typeof(string));
                _dtdetails.Columns.Add("filed1", typeof(string));
                _dtdetails.Columns.Add("Comm", typeof(string));
                _dtdetails.Columns.Add("Act_by", typeof(string));
                _dtdetails.Columns.Add("Act_date", typeof(string));
                _dtdetails.Columns.Add("tested1", typeof(string));
                _dtdetails.Columns.Add("test7", typeof(string));
                _dtdetails.Columns.Add("test11", typeof(string));
                _dtdetails.Columns.Add("test10", typeof(string));
                var _details = from _data in _dtresult.AsEnumerable()
                               where _data.Field<int>("Sys_Id") == Convert.ToInt32(_sys_id.Text)
                               select _data;
                foreach (var row in _details)
                {
                    DataRow _row = _dtdetails.NewRow();
                    _row[0] = row["e_b_ref"].ToString();
                    _row[1] = row["B_Z"].ToString();
                    _row[2] = row["Cat"].ToString();
                    _row[3] = row["F_lvl"].ToString();
                    _row[4] = SeqNo(row["Seq_No"].ToString());
                    _row[5] = row["Loc"].ToString();
                    _row[6] = row["Des"].ToString();
                    _row[7] = row["F_from"].ToString();
                    _row[8] = row["Substation"].ToString();
                    _row[9] = row["devices1"].ToString();
                    _row[10] = row["C_id"].ToString();
                    _row[11] = row["Sys_name"].ToString();
                    _row[12] = row["Sys_id"].ToString();
                    _row[13] = row["Pwr_on"].ToString();
                    _row[14] = row["test1"].ToString();
                    _row[15] = row["test2"].ToString();
                    _row[16] = row["test3"].ToString();
                    _row[17] = row["test4"].ToString();
                    _row[18] = row["test5"].ToString();
                    _row[19] = row["test6"].ToString();
                    _row[20] = row["Per_com4"].ToString();
                    _row[21] = row["accept1"].ToString();
                    _row[22] = row["filed1"].ToString();
                    _row[23] = row["Comm"].ToString();
                    _row[24] = row["Act_by"].ToString();
                    _row[25] = row["Act_date"].ToString();
                    _row[26] = row["tested1"].ToString();
                    _row[27] = row["test7"].ToString();
                    _row[28] = row["test11"].ToString();
                    _row[29] = row["test10"].ToString();
                    _dtdetails.Rows.Add(_row);
                }
                GridView _mydetails = (GridView)e.Row.FindControl("mydetails");
                _mydetails.DataSource = _dtdetails;
                _mydetails.DataBind();
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _lbl = (Label)e.Row.FindControl("Label1");
                if (_lbl.Text == "0.00%")
                    _lbl.Text = "";
            }
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
            _dtfilter = _dtMaster;
            _dtresult = new DataTable();
            _dtresult.Columns.Add("e_b_ref", typeof(string));
            _dtresult.Columns.Add("B_Z", typeof(string));
            _dtresult.Columns.Add("Cat", typeof(string));
            _dtresult.Columns.Add("F_lvl", typeof(string));
            _dtresult.Columns.Add("Seq_No", typeof(string));
            _dtresult.Columns.Add("Loc", typeof(string));
            _dtresult.Columns.Add("Des", typeof(string));
            _dtresult.Columns.Add("F_from", typeof(string));
            _dtresult.Columns.Add("Substation", typeof(string));
            _dtresult.Columns.Add("devices1", typeof(string));
            _dtresult.Columns.Add("C_id", typeof(int));
            _dtresult.Columns.Add("Sys_name", typeof(string));
            _dtresult.Columns.Add("Sys_id", typeof(int));

            _dtresult.Columns.Add("Pwr_on", typeof(string));
            _dtresult.Columns.Add("test1", typeof(string));
            _dtresult.Columns.Add("test2", typeof(string));
            _dtresult.Columns.Add("test3", typeof(string));
            _dtresult.Columns.Add("test4", typeof(string));
            _dtresult.Columns.Add("test5", typeof(string));
            _dtresult.Columns.Add("test6", typeof(string));
            _dtresult.Columns.Add("Per_com4", typeof(string));
            _dtresult.Columns.Add("Accept1", typeof(string));
            _dtresult.Columns.Add("filed1", typeof(string));
            _dtresult.Columns.Add("Comm", typeof(string));
            _dtresult.Columns.Add("Act_by", typeof(string));
            _dtresult.Columns.Add("Act_date", typeof(string));
            _dtresult.Columns.Add("Per_com1", typeof(string));
            _dtresult.Columns.Add("Per_com2", typeof(string));
            _dtresult.Columns.Add("Per_com3", typeof(string));
            _dtresult.Columns.Add("tested1", typeof(string));
            _dtresult.Columns.Add("test7", typeof(string));
            _dtresult.Columns.Add("test11", typeof(string));
            _dtresult.Columns.Add("test10", typeof(string));
            _dtresult.Columns.Add("Per_com5", typeof(string));
            _dtresult.Columns.Add("Per_com6", typeof(string));
            _dtresult.Columns.Add("Per_com7", typeof(string));
            _dtresult.Columns.Add("Per_com8", typeof(string));
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
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<decimal>("per_com4") == Convert.ToDecimal(_el6)
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
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<decimal>("per_com4") == Convert.ToDecimal(_el6)
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
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<decimal>("per_com4") == Convert.ToDecimal(_el6)
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
                          where o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<decimal>("per_com4") == Convert.ToDecimal(_el6)
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
                          where o.Field<decimal>("per_com4") == Convert.ToDecimal(_el6)
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
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<decimal>("per_com4") == Convert.ToDecimal(_el6)
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
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<decimal>("per_com4") == Convert.ToDecimal(_el6)
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
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Loc") == _el5 && o.Field<decimal>("per_com4") == Convert.ToDecimal(_el6)
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
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<decimal>("per_com4") == Convert.ToDecimal(_el6)
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
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("Loc") == _el5 && o.Field<decimal>("per_com4") == Convert.ToDecimal(_el6)
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<decimal>("per_com4") == Convert.ToDecimal(_el6)
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
                          where o.Field<string>("F_lvl") == _el3 && o.Field<decimal>("per_com4") == Convert.ToDecimal(_el6)
                          select o;
            }
            foreach (var row in _filter)
            {
                DataRow _row = _dtresult.NewRow();
                _row[0] = row["e_b_ref"].ToString();
                _row[1] = row["B_Z"].ToString();
                _row[2] = row["Cat"].ToString();
                _row[3] = row["F_lvl"].ToString();
                _row[4] = SeqNo(row["Seq_No"].ToString());
                _row[5] = row["Loc"].ToString();
                _row[6] = row["Des"].ToString();
                _row[7] = row["F_from"].ToString();
                _row[8] = row["Substation"].ToString();
                _row[9] = row["devices1"].ToString();
                _row[10] = row["C_id"].ToString();
                _row[11] = row["Sys_name"].ToString();
                _row[12] = row["Sys_id"].ToString();
                _row[13] = row["Pwr_on"].ToString();
                _row[14] = row["test1"].ToString();
                _row[15] = row["test2"].ToString();
                _row[16] = row["test3"].ToString();
                _row[17] = row["test4"].ToString();
                _row[18] = row["test5"].ToString();
                _row[19] = row["test6"].ToString();
                _row[20] = row["Per_com4"].ToString();
                _row[21] = row["accept1"].ToString();
                _row[22] = row["filed1"].ToString();
                _row[23] = row["Comm"].ToString();
                _row[24] = row["Act_by"].ToString();
                _row[25] = row["Act_date"].ToString();
                _row[26] = row["Per_com1"].ToString();
                _row[27] = row["Per_com2"].ToString();
                _row[28] = row["Per_com3"].ToString();
                _row[29] = row["tested1"].ToString();
                _row[30] = row["test7"].ToString();
                _row[31] = row["test11"].ToString();
                _row[32] = row["test10"].ToString();
                _row[33] = row["Per_com5"].ToString();
                _row[34] = row["Per_com6"].ToString();
                _row[35] = row["Per_com7"].ToString();
                _row[36] = row["Per_com8"].ToString();
                _dtresult.Rows.Add(_row);
            }
            //m.DataSource = _dtresult;
            //mygrid.DataBind();
            Load_Details();
            if (lblsch.Text == "55")
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
                _dtsummary.Columns.Add("PRE_COMM_QTY", typeof(string));
                _dtsummary.Columns.Add("PRE_COMM_PER", typeof(string));
                _dtsummary.Columns.Add("COMM_QTY", typeof(string));
                _dtsummary.Columns.Add("COMM_PER", typeof(string));
                _dtsummary.Columns.Add("COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PFT_TOTAL", typeof(string));
                _dtsummary.Columns.Add("PWRON_TOTAL", typeof(string));
                _dtsummary.Columns.Add("FPT_TOTAL", typeof(string));
                _dtsummary.Columns.Add("ARM_TOTAL", typeof(string));
                _dtsummary.Columns.Add("COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
                    decimal _overall = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com5"].ToString());//pft
                        _p5 += Convert.ToDecimal(_row["per_com6"].ToString());//pwron
                        _p6 += Convert.ToDecimal(_row["per_com7"].ToString());//fpt
                        _p7 += Convert.ToDecimal(_row["per_com8"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    decimal _per7 = 0;
                    decimal _com1 = 0;
                    decimal _com2 = 0;
                    if (_p1 != 0)
                    {
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
                        _com1 = _per1 * 100;
                    }
                    if (_p2 != 0)
                    {
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
                        _com2 = _per2 * 100;
                    }
                    if (_p3 != 0)
                        _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count), 2);
                    _total = Decimal.Round(((_com1 * 0.1m) + (_com2 * 0.9m)));
                    if (_p4 != 0)
                        _per4 = Decimal.Round(_p4 / Convert.ToDecimal(count), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round(_p5 / Convert.ToDecimal(count), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round(_p6 / Convert.ToDecimal(count), 2);
                    if (_p7 != 0)
                        _per7 = Decimal.Round(_p7 / Convert.ToDecimal(count), 2);
                    _total1 = Decimal.Round(((_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per7 * 0.25m)) * 100);
                    _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = Decimal.Round(_com1).ToString();
                    _drow[4] = Decimal.Round(_p2).ToString();
                    _drow[5] = Decimal.Round(_com2).ToString();
                    _drow[6] = _total.ToString();
                    _drow[7] = Decimal.Round(_p4).ToString();
                    _drow[8] = Decimal.Round(_p5).ToString();
                    _drow[9] = Decimal.Round(_p6).ToString();
                    _drow[10] = Decimal.Round(_p7).ToString();
                    _drow[11] = _total1.ToString();
                    _drow[12] = _overall.ToString();
                    _drow[13] = row.col3.ToString();
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
        private void Generate_Summary1()
        {
            try
            {
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PRE_COMM_QTY", typeof(string));
                _dtsummary.Columns.Add("PRE_COMM_PER", typeof(string));
                _dtsummary.Columns.Add("COMM_QTY", typeof(string));
                _dtsummary.Columns.Add("COMM_PER", typeof(string));
                _dtsummary.Columns.Add("COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PFT_TOTAL", typeof(string));
                _dtsummary.Columns.Add("PWRON_TOTAL", typeof(string));
                _dtsummary.Columns.Add("FPT_TOTAL", typeof(string));
                _dtsummary.Columns.Add("ARM_TOTAL", typeof(string));
                _dtsummary.Columns.Add("COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
                    decimal _overall = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com5"].ToString());//pft
                        _p5 += Convert.ToDecimal(_row["per_com6"].ToString());//pwron
                        _p6 += Convert.ToDecimal(_row["per_com7"].ToString());//fpt
                        _p7 += Convert.ToDecimal(_row["per_com8"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    decimal _per7 = 0;
                    decimal _com1 = 0;
                    decimal _com2 = 0;
                    if (_p1 != 0)
                    {
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
                        _com1 = _per1 * 100;
                    }
                    if (_p2 != 0)
                    {
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
                        _com2 = _per2 * 100;
                    }
                    if (_p3 != 0)
                        _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count), 2);
                    _total = Decimal.Round(((_com1 * 0.1m) + (_com2 * 0.9m)));
                    if (_p4 != 0)
                        _per4 = Decimal.Round(_p4 / Convert.ToDecimal(count), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round(_p5 / Convert.ToDecimal(count), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round(_p6 / Convert.ToDecimal(count), 2);
                    if (_p7 != 0)
                        _per7 = Decimal.Round(_p7 / Convert.ToDecimal(count), 2);
                    _total1 = Decimal.Round(((_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per7 * 0.25m)) * 100);
                    _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = Decimal.Round(_com1).ToString();
                    _drow[4] = Decimal.Round(_p2).ToString();
                    _drow[5] = Decimal.Round(_com2).ToString();
                    _drow[6] = _total.ToString();
                    _drow[7] = Decimal.Round(_p4).ToString();
                    _drow[8] = Decimal.Round(_p5).ToString();
                    _drow[9] = Decimal.Round(_p6).ToString();
                    _drow[10] = Decimal.Round(_p7).ToString();
                    _drow[11] = _total1.ToString();
                    _drow[12] = _overall.ToString();
                    _drow[13] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                decimal _vav_count = 0;
                decimal _vav_comp1 = 0;
                decimal _vav_p1 = 0;
                decimal _vav_comp2 = 0;
                decimal _vav_p2 = 0;
                decimal _vav_p3 = 0;
                decimal _vav_p4 = 0;
                decimal _vav_p5 = 0;
                decimal _vav_p6 = 0;
                decimal _vav_p7 = 0;
                decimal _vav_ovr = 0;
                decimal _vav_total1 = 0;
                decimal _vav_total2 = 0;
                for(int i=63;i<=73;i++)
                {
                    Load_Master1(i);
                    var distinctRows1 = (from DataRow dRow in _dtMaster1.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                    foreach (var row in distinctRows1)
                    {
                        //_row[0] = row.col1.ToString();
                        //_row[1] = row.col2.ToString();
                        decimal _p1 = 0;
                        decimal _p2 = 0;
                        decimal _p3 = 0;
                        decimal _p4 = 0;
                        decimal _p5 = 0;
                        decimal _p6 = 0;
                        decimal _p7 = 0;
                        decimal _total = 0;
                        decimal _total1 = 0;
                        decimal _overall = 0;
                        int count = 0;
                        string _s = "";
                        var _result = from _data in _dtMaster1.AsEnumerable()
                                      where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                      select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                            _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                            _p4 += Convert.ToDecimal(_row["per_com5"].ToString());//pft
                            _p5 += Convert.ToDecimal(_row["per_com6"].ToString());//pwron
                            _p6 += Convert.ToDecimal(_row["per_com7"].ToString());//fpt
                            _p7 += Convert.ToDecimal(_row["per_com8"].ToString());//arm
                            _s = _row[0].ToString();
                            count += 1;
                        }
                        _vav_count += count;
                        _vav_p1 += _p1;
                        _vav_p2 += _p2;
                        _vav_p3 += _p3;
                        _vav_p4 += _p4;
                        _vav_p5 += _p5;
                        _vav_p6 += _p6;
                        _vav_p7 += _p7;
                        _vav_total1 += _total;
                        _vav_total2 += _total1;
                        _vav_ovr += _overall;
                    }
                }
                DataRow _drow1 = _dtsummary.NewRow();
                _drow1[0] = "VAV";
                _drow1[1] = _vav_count.ToString();
                _drow1[2] = Decimal.Round(_vav_p1).ToString();
                _vav_comp1 = Decimal.Round((_vav_p1 / _vav_count) * 100, 0, MidpointRounding.AwayFromZero);
                _drow1[3] = _vav_comp1.ToString();
                _drow1[4] = Decimal.Round(_vav_p2).ToString();
                _vav_comp2 = Decimal.Round((_vav_p2 / _vav_count) * 100, 0, MidpointRounding.AwayFromZero);
                _drow1[5] =_vav_comp2.ToString();
                _vav_total1 = Decimal.Round((_vav_comp1 * 0.1m + _vav_comp2 * 0.9m), 0, MidpointRounding.AwayFromZero);
                _drow1[6] = _vav_total1.ToString();
                _drow1[7] = Decimal.Round(_vav_p4).ToString();
                _drow1[8] = Decimal.Round(_vav_p5).ToString();
                _drow1[9] = Decimal.Round(_vav_p6).ToString();
                _drow1[10] = Decimal.Round(_vav_p7).ToString();
                _vav_total2 = Decimal.Round(((_vav_p4 * 0.25m + _vav_p5 * 0.25m + _vav_p6 * 0.25m + _vav_p7 * 0.25m) / _vav_count) * 100, 0, MidpointRounding.AwayFromZero);
                _drow1[11] = _vav_total2.ToString();
                _vav_ovr = _vav_total1 * 0.8m + _vav_total2 * 0.2m;
                _drow1[12] = Decimal.Round(_vav_ovr, 0, MidpointRounding.AwayFromZero).ToString();
                _drow1[13] = "VAV";
                _dtsummary.Rows.Add(_drow1);

                decimal _ecv_count = 0;
                decimal _ecv_comp1 = 0;
                decimal _ecv_p1 = 0;
                decimal _ecv_comp2 = 0;
                decimal _ecv_p2 = 0;
                decimal _ecv_p3 = 0;
                decimal _ecv_p4 = 0;
                decimal _ecv_p5 = 0;
                decimal _ecv_p6 = 0;
                decimal _ecv_p7 = 0;
                decimal _ecv_ovr = 0;
                decimal _ecv_total1 = 0;
                decimal _ecv_total2 = 0;
                for (int i = 74; i <= 84; i++)
                {
                    Load_Master1(i);
                    var distinctRows1 = (from DataRow dRow in _dtMaster1.Rows
                                         select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                    foreach (var row in distinctRows1)
                    {
                        //_row[0] = row.col1.ToString();
                        //_row[1] = row.col2.ToString();
                        decimal _p1 = 0;
                        decimal _p2 = 0;
                        decimal _p3 = 0;
                        decimal _p4 = 0;
                        decimal _p5 = 0;
                        decimal _p6 = 0;
                        decimal _p7 = 0;
                        decimal _total = 0;
                        decimal _total1 = 0;
                        decimal _overall = 0;
                        int count = 0;
                        string _s = "";
                        var _result = from _data in _dtMaster1.AsEnumerable()
                                      where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                      select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                            _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                            _p4 += Convert.ToDecimal(_row["per_com5"].ToString());//pft
                            _p5 += Convert.ToDecimal(_row["per_com6"].ToString());//pwron
                            _p6 += Convert.ToDecimal(_row["per_com7"].ToString());//fpt
                            _p7 += Convert.ToDecimal(_row["per_com8"].ToString());//arm
                            _s = _row[0].ToString();
                            count += 1;
                        }
                       _ecv_count += count;
                        _ecv_p1 += _p1;
                        _ecv_p2 += _p2;
                        _ecv_p3 += _p3;
                        _ecv_p4 += _p4;
                        _ecv_p5 += _p5;
                        _ecv_p6 += _p6;
                        _ecv_p7 += _p7;
                    }
                }
                DataRow _drow2 = _dtsummary.NewRow();
                _drow2[0] = "ECV";
                _drow2[1] = _ecv_count.ToString();
                _drow2[2] = Decimal.Round(_ecv_p1).ToString();
                _ecv_comp1 = Decimal.Round((_ecv_p1 / _ecv_count) * 100, 0, MidpointRounding.AwayFromZero);
                _drow2[3] = Decimal.Round(_ecv_comp1).ToString();
                _drow2[4] = Decimal.Round(_ecv_p2).ToString();
                _ecv_comp2 = Decimal.Round((_ecv_p2 / _ecv_count) * 100, 0, MidpointRounding.AwayFromZero);
                _drow2[5] = Decimal.Round(_ecv_comp2).ToString();
                _ecv_total1 = Decimal.Round(_ecv_comp1 * 0.1m + _ecv_comp2 * 0.9m, 0, MidpointRounding.AwayFromZero);
                _drow2[6] = _ecv_total1.ToString();
                _drow2[7] = Decimal.Round(_ecv_p4).ToString();
                _drow2[8] = Decimal.Round(_ecv_p5).ToString();
                _drow2[9] = Decimal.Round(_ecv_p6).ToString();
                _drow2[10] = Decimal.Round(_ecv_p7).ToString();
                _ecv_total2 = Decimal.Round(((_ecv_p4 * 0.25m + _ecv_p5 * 0.25m + _ecv_p6 * 0.25m + _ecv_p7 * 0.25m) / _ecv_count) * 100, 0, MidpointRounding.AwayFromZero);
                _drow2[11] = _ecv_total2.ToString();
                _ecv_ovr = _ecv_total1 * 0.8m + _ecv_total2 * 0.2m;
                _drow2[12] = Decimal.Round(_ecv_ovr, 0, MidpointRounding.AwayFromZero).ToString();
                _drow2[13] = "ECV";
                _dtsummary.Rows.Add(_drow2);

                decimal _mfsd_count = 0;
                decimal _mfsd_comp1 = 0;
                decimal _mfsd_p1 = 0;
                decimal _mfsd_comp2 = 0;
                decimal _mfsd_p2 = 0;
                decimal _mfsd_p3 = 0;
                decimal _mfsd_p4 = 0;
                decimal _mfsd_p5 = 0;
                decimal _mfsd_p6 = 0;
                decimal _mfsd_p7 = 0;
                decimal _mfsd_ovr = 0;
                decimal _mfsd_total1 = 0;
                decimal _mfsd_total2 = 0;
                for (int i = 30; i <= 40; i++)
                {
                    Load_Master1(i);
                    var distinctRows2 = (from DataRow dRow in _dtMaster1.Rows
                                         select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                    foreach (var row in distinctRows2)
                    {
                        //_row[0] = row.col1.ToString();
                        //_row[1] = row.col2.ToString();
                        decimal _p1 = 0;
                        decimal _p2 = 0;
                        decimal _p3 = 0;
                        decimal _p4 = 0;
                        decimal _p5 = 0;
                        decimal _p6 = 0;
                        decimal _p7 = 0;
                        decimal _p8 = 0;
                        decimal _total = 0;
                        decimal _total1 = 0;
                        decimal _overall = 0;
                        int count = 0;
                        string _s = "";
                        var _result = from _data in _dtMaster1.AsEnumerable()
                                      where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                      select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                            _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                            _p4 += Convert.ToDecimal(_row["per_com5"].ToString());//pft
                            _p5 += Convert.ToDecimal(_row["per_com6"].ToString());//pwron
                            _p6 += Convert.ToDecimal(_row["per_com7"].ToString());//fpt
                            _p7 += Convert.ToDecimal(_row["per_com8"].ToString());//arm
                            _p8 += Convert.ToDecimal(_row["per_com4"].ToString());//ins
                            _s = _row[0].ToString();
                            count += 1;
                        }
                        _mfsd_count += count;
                        _mfsd_p1 += _p1;
                        _mfsd_p2 += _p2;
                        _mfsd_p3 += _p3;
                        _mfsd_p4 += _p4;
                        _mfsd_p5 += _p8;
                        _mfsd_p6 += _p6;
                        _mfsd_p7 += _p7;
                    }
                }
                DataRow _drow3 = _dtsummary.NewRow();
                _drow3[0] = "MFSD";
                _drow3[1] = _mfsd_count.ToString();
                _drow3[2] = Decimal.Round(_mfsd_p1).ToString();
                _mfsd_comp1 = Decimal.Round((_mfsd_p1 / _mfsd_count) * 100, 0, MidpointRounding.AwayFromZero);
                _drow3[3] = _mfsd_comp1.ToString();
                _drow3[4] = Decimal.Round(_mfsd_p2).ToString();
                _mfsd_comp2 = Decimal.Round((_mfsd_p2 / _mfsd_count) * 100, 0, MidpointRounding.AwayFromZero);
                _drow3[5] = _mfsd_comp2.ToString();
                _mfsd_total1 = Decimal.Round((_mfsd_comp1 * 0.1m + _mfsd_comp2 * 0.9m), 0, MidpointRounding.AwayFromZero);
                _drow3[6] = _mfsd_total1.ToString();
                _drow3[7] = Decimal.Round(_mfsd_p4).ToString();
                _drow3[8] = Decimal.Round(_mfsd_p5).ToString();
                _drow3[9] = Decimal.Round(_mfsd_p6).ToString();
                _drow3[10] = Decimal.Round(_mfsd_p7).ToString();
                _mfsd_total2 = Decimal.Round(((_mfsd_p4 * 0.25m + _mfsd_p5 * 0.25m + _mfsd_p6 * 0.25m + _mfsd_p7 * 0.25m) / _mfsd_count) * 100, 0, MidpointRounding.AwayFromZero);
                _drow3[11] = _mfsd_total2.ToString();
                _mfsd_ovr = _mfsd_total1 * 0.8m + _mfsd_total2 * 0.2m;
                _drow3[12] = Decimal.Round(_mfsd_ovr, 0, MidpointRounding.AwayFromZero).ToString();
                _drow3[13] = "MFSD";
                _dtsummary.Rows.Add(_drow3);
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
            _objbll.Clear_CassummaryRpt(_objdb);
            var _result = from _data in _summary.AsEnumerable()
                          select _data;
            //int count = 0;
            foreach (var row in _result)
            {
                _objcls.sys_mon = row["SYS_NAME"].ToString();
                _objcls.qty = row["QTY"].ToString();
                _objcls.per_com1 = Convert.ToDecimal(row["PRE_COMM_QTY"].ToString());
                _objcls.per_com2 = Convert.ToDecimal(row["COMM_QTY"].ToString());
                _objcls.per_com3 = Convert.ToDecimal(row["FPT_TOTAL"].ToString());
                _objcls.total = Convert.ToDecimal(row["ARM_TOTAL"].ToString());
                _objcls.cate = row["CODE"].ToString();
                _objcls.quantity = Convert.ToInt32(row["QTY"].ToString());
                _objcls.compl1 = Convert.ToInt32(row["PFT_TOTAL"].ToString()); ;
                _objcls.compl2 = Convert.ToInt32(row["PWRON_TOTAL"].ToString()); ;
                _objbll.Generate_CASSummary_PKG_RPT_ASAO(_objcls, _objdb);
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
            if (lblsch.Text == "55")
                Generate_Summary1();
            else
                Generate_Summary();
        }
        private void Filtering_zero()
        {
            Load_Master();
            _dtfilter = _dtMaster;
            _dtresult = new DataTable();
            _dtresult.Columns.Add("e_b_ref", typeof(string));
            _dtresult.Columns.Add("B_Z", typeof(string));
            _dtresult.Columns.Add("Cat", typeof(string));
            _dtresult.Columns.Add("F_lvl", typeof(string));
            _dtresult.Columns.Add("Seq_No", typeof(string));
            _dtresult.Columns.Add("Loc", typeof(string));
            _dtresult.Columns.Add("Des", typeof(string));
            _dtresult.Columns.Add("F_from", typeof(string));
            _dtresult.Columns.Add("Substation", typeof(string));
            _dtresult.Columns.Add("devices1", typeof(string));
            _dtresult.Columns.Add("C_id", typeof(int));
            _dtresult.Columns.Add("Sys_name", typeof(string));
            _dtresult.Columns.Add("Sys_id", typeof(int));
            _dtresult.Columns.Add("Pwr_on", typeof(string));
            _dtresult.Columns.Add("test1", typeof(string));
            _dtresult.Columns.Add("test2", typeof(string));
            _dtresult.Columns.Add("test3", typeof(string));
            _dtresult.Columns.Add("test4", typeof(string));
            _dtresult.Columns.Add("test5", typeof(string));
            _dtresult.Columns.Add("test6", typeof(string));
            _dtresult.Columns.Add("Per_com4", typeof(string));
            _dtresult.Columns.Add("Accept1", typeof(string));
            _dtresult.Columns.Add("filed1", typeof(string));
            _dtresult.Columns.Add("Comm", typeof(string));
            _dtresult.Columns.Add("Act_by", typeof(string));
            _dtresult.Columns.Add("Act_date", typeof(string));
            _dtresult.Columns.Add("Per_com1", typeof(string));
            _dtresult.Columns.Add("Per_com2", typeof(string));
            _dtresult.Columns.Add("Per_com3", typeof(string));
            _dtresult.Columns.Add("tested1", typeof(string));
            _dtresult.Columns.Add("test7", typeof(string));
            _dtresult.Columns.Add("test11", typeof(string));
            _dtresult.Columns.Add("test10", typeof(string));
            _dtresult.Columns.Add("Per_com5", typeof(string));
            _dtresult.Columns.Add("Per_com6", typeof(string));
            _dtresult.Columns.Add("Per_com7", typeof(string));
            _dtresult.Columns.Add("Per_com8", typeof(string));
            var _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("test1") == null && o.Field<string>("test2") == null && o.Field<string>("test3") == null
                          select o;
            foreach (var row in _filter)
            {
                DataRow _row = _dtresult.NewRow();
                _row[0] = row["e_b_ref"].ToString();
                _row[1] = row["B_Z"].ToString();
                _row[2] = row["Cat"].ToString();
                _row[3] = row["F_lvl"].ToString();
                _row[4] = SeqNo(row["Seq_No"].ToString());
                _row[5] = row["Loc"].ToString();
                _row[6] = row["Des"].ToString();
                _row[7] = row["F_from"].ToString();
                _row[8] = row["Substation"].ToString();
                _row[9] = row["devices1"].ToString();
                _row[10] = row["C_id"].ToString();
                _row[11] = row["Sys_name"].ToString();
                _row[12] = row["Sys_id"].ToString();
                _row[13] = row["Pwr_on"].ToString();
                _row[14] = row["test1"].ToString();
                _row[15] = row["test2"].ToString();
                _row[16] = row["test3"].ToString();
                _row[17] = row["test4"].ToString();
                _row[18] = row["test5"].ToString();
                _row[19] = row["test6"].ToString();
                _row[20] = row["Per_com4"].ToString();
                _row[21] = row["accept1"].ToString();
                _row[22] = row["filed1"].ToString();
                _row[23] = row["Comm"].ToString();
                _row[24] = row["Act_by"].ToString();
                _row[25] = row["Act_date"].ToString();
                _row[26] = row["Per_com1"].ToString();
                _row[27] = row["Per_com2"].ToString();
                _row[28] = row["Per_com3"].ToString();
                _row[29] = row["tested1"].ToString();
                _row[30] = row["test7"].ToString();
                _row[31] = row["test11"].ToString();
                _row[32] = row["test10"].ToString();
                _row[33] = row["Per_com5"].ToString();
                _row[34] = row["Per_com6"].ToString();
                _row[35] = row["Per_com7"].ToString();
                _row[36] = row["Per_com8"].ToString();
                _dtresult.Rows.Add(_row);
            }
            //m.DataSource = _dtresult;
            //mygrid.DataBind();
            Load_Details();
            if (lblsch.Text == "55")
                Generate_Summary1();
            else
                Generate_Summary();
        }

        protected void mygridsumm_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.SetRenderMethodDelegate(RenderHeader1);
        }
        private void Head_Merging()
        {
            info1.AddMergedColumns(new int[] { 3, 4}, "PRE-COMMISSIONED (10%)");
            info1.AddMergedColumns(new int[] { 5, 6 }, "COMMISSIONED (90%)");
        }
        private void RenderHeader1(HtmlTextWriter output, Control container)
        {
            for (int i = 0; i < container.Controls.Count; i++)
            {
                TableCell cell = (TableCell)container.Controls[i];
                //stretch non merged columns for two rows
                if (!info1.MergedColumns.Contains(i))
                {
                    cell.Attributes["rowspan"] = "2";
                    cell.RenderControl(output);
                }
                else //render merged columns common title
                    if (info1.StartColumns.Contains(i))
                    {
                        output.Write(string.Format("<th align='center' style='font-weight:normal' colspan='{0}'>{1}</th>",
                                info1.StartColumns[i], info1.Titles[i]));
                    }
            }

            //close the first row	
            output.RenderEndTag();
            //set attributes for the second row
            mygridsumm.HeaderStyle.AddAttributesToRender(output);
            //start the second row
            output.RenderBeginTag("tr");

            //render the second row (only the merged columns)
            for (int i = 0; i < info1.MergedColumns.Count; i++)
            {
                TableCell cell = (TableCell)container.Controls[info1.MergedColumns[i]];
                cell.RenderControl(output);
            }
        }
        protected void TimerTick(object sender, EventArgs e)
        {
            Loading();
            Timer1.Enabled = false;
            imgLoader.Visible = false;
            lblsummary_title.Visible = true;
        }
    }
}
