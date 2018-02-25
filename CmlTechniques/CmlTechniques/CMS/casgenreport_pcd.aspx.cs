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
    public partial class casgenreport_pcd : System.Web.UI.Page  
    {
        [Serializable]
        private class minfo_
        {
            // indexes of merged columns
            public System.Collections.Generic.List<int> MergedColumns = new System.Collections.Generic.List<int>();
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
                if (_prm.Contains("_D") == true)
                {
                    lblprj.Text = _prm.Substring(0, _prm.IndexOf("_D"));
                    lbldiv.Text = _prm.Substring(_prm.IndexOf("_D") + 2);
                }
                else
                    lblprj.Text = _prm;
                Load_Master();
                Session["filter"] = "no";
                Session["zone"] = "All";
                Session["flvl"] = "All";
                Session["cat"] = "All";
                Session["fed"] = "All";
                Session["loc"] = "All";
                Session["zero"] = "1";
                Load_Details();
                Hide_Details();

                Generate_Summary();
                Head_Merging();

                btnzero.Style.Add("display", "none");

                //Load_Summary();
            }
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
            _objcas.sch = 4;
            _objcas.prj_code = lblprj.Text;
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
            _dtresult = _dtMaster;
            _summary = _dtresult;
            _dtfilter = _dtresult;
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
        private void Head_Merging()
        {
            info1.AddMergedColumns(new int[] { 3, 4, 5 }, "Stand Alone Test progress");
            info1.AddMergedColumns(new int[] { 6, 7, 8 }, "Outgoing Circuit Test progress");
            info1.AddMergedColumns(new int[] { 9, 10, 11 }, "Site Operation & Load Test progress");
        }
        private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == "sys_name")
            {
                row.BackColor = System.Drawing.Color.LightGray;
                row.Cells[0].Text = "&nbsp;&nbsp;" + row.Cells[0].Text;
            }

        }
        private void helper_GroupHeader1(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == "F_lvl")
            {
                row.BackColor = System.Drawing.Color.LightGray;
                row.Cells[1].Text = "&nbsp;&nbsp;" + row.Cells[1].Text;
            }

        }
        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }

            return newSortDirection;
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
                        output.Write(string.Format("<th align='center' colspan='{0}'>{1}</th>",
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
        decimal _qty = 0;
        decimal _test1 = 0;
        decimal _test2 = 0;
        decimal _test3 = 0;
        decimal _count = 0;
        decimal _t1qty = 0;
        decimal _t2qty = 0;
        decimal _t3qty = 0;
        decimal _plqty = 0;
        decimal _pl1qty = 0;
        decimal _pl2qty = 0;
        decimal _ppl = 0;
        decimal _ppl1 = 0;
        decimal _ppl2 = 0;
        protected void mygridsumm_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[16].Visible = false;
            e.Row.Cells[17].Visible = false;
            e.Row.Cells[18].Visible = false;
            e.Row.Cells[19].Visible = false;
            e.Row.Cells[20].Visible = false;
            e.Row.Cells[21].Visible = false;
            e.Row.Cells[22].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();

                _qty += Convert.ToDecimal(e.Row.Cells[2].Text);
                _test1 += Convert.ToDecimal(e.Row.Cells[17].Text);
                _test2 += Convert.ToDecimal(e.Row.Cells[18].Text);
                _test3 += Convert.ToDecimal(e.Row.Cells[19].Text);
                _t1qty += Convert.ToDecimal(e.Row.Cells[14].Text);
                _t2qty += Convert.ToDecimal(e.Row.Cells[15].Text);
                _t3qty += Convert.ToDecimal(e.Row.Cells[16].Text);
                _plqty += (e.Row.Cells[3].Text == "N/A") ? -1:Convert.ToDecimal(e.Row.Cells[3].Text);
                _pl1qty += (e.Row.Cells[6].Text == "N/A") ? -1 :Convert.ToDecimal(e.Row.Cells[6].Text);
                _pl2qty += (e.Row.Cells[9].Text == "N/A") ? -1 :Convert.ToDecimal(e.Row.Cells[9].Text);
                _ppl += Convert.ToDecimal(e.Row.Cells[20].Text);    
                _ppl1 += Convert.ToDecimal(e.Row.Cells[21].Text);
                _ppl2 += Convert.ToDecimal(e.Row.Cells[22].Text);
                _count += 1;
                if (e.Row.Cells[4].Text != "N/A")
                    e.Row.Cells[4].Text = e.Row.Cells[4].Text + "%";
                if (e.Row.Cells[5].Text != "N/A")
                    e.Row.Cells[5].Text = e.Row.Cells[5].Text + "%";
                if (e.Row.Cells[6].Text != "N/A")
                    e.Row.Cells[6].Text = e.Row.Cells[6].Text + "%";
                if (e.Row.Cells[7].Text != "N/A")
                    e.Row.Cells[7].Text = e.Row.Cells[7].Text + "%";
                if (e.Row.Cells[8].Text != "N/A")
                    e.Row.Cells[8].Text = e.Row.Cells[8].Text + "%";
                if (e.Row.Cells[10].Text != "N/A")
                    e.Row.Cells[10].Text = e.Row.Cells[10].Text + "%";
                if (e.Row.Cells[11].Text != "N/A")
                    e.Row.Cells[11].Text = e.Row.Cells[11].Text + "%";
                if (e.Row.Cells[12].Text != "N/A")
                    e.Row.Cells[12].Text = e.Row.Cells[12].Text + "%";
                if (e.Row.Cells[13].Text != "N/A")
                    e.Row.Cells[13].Text = e.Row.Cells[13].Text + "%";
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                decimal r1 = 0, r2 = 0, r3 = 0, r1p = 0, r2p = 0, r3p = 0;

                e.Row.Cells[1].Text = "SUMMARY";
                e.Row.Cells[2].Text = _qty.ToString();
                if(_ppl > 0)
                {
                    r1p = decimal.Round((_plqty / _ppl)*100, MidpointRounding.AwayFromZero);
                    e.Row.Cells[3].Text = _plqty.ToString();                    
                    e.Row.Cells[4].Text = r1p + "%";
                }
                else
                {
                    r1p = -1;
                    e.Row.Cells[3].Text = "N/A";
                    e.Row.Cells[4].Text = "N/A";
                }
                if(_t1qty > 0)
                {
                    r1 = decimal.Round((_test1 / _t1qty), MidpointRounding.AwayFromZero);
                    e.Row.Cells[5].Text = r1 + "%";
                }
                else
                {
                    r1 = -1;
                    e.Row.Cells[5].Text = "N/A";
                }                
                if (_ppl1 > 0)
                {
                    r2p = decimal.Round((_pl1qty / _ppl1)*100, MidpointRounding.AwayFromZero);
                    e.Row.Cells[6].Text = _pl1qty.ToString();
                    e.Row.Cells[7].Text = r2p + "%";
                }
                else
                {
                    r2p = -1;
                    e.Row.Cells[6].Text = "N/A";
                    e.Row.Cells[7].Text = "N/A";
                }
                if (_t2qty > 0)
                {
                    r2 = decimal.Round((_test2 / _t2qty), MidpointRounding.AwayFromZero);
                    e.Row.Cells[8].Text = r2 + "%";
                }
                else
                {
                    r2 = -1;
                    e.Row.Cells[8].Text = "N/A";
                }                    
                if (_ppl2 > 0)
                {
                    r3p = decimal.Round((_pl2qty / _ppl2)*100, MidpointRounding.AwayFromZero);
                    e.Row.Cells[9].Text = _pl2qty.ToString();
                    e.Row.Cells[10].Text = r3p + "%";
                }
                else
                {
                    r3p = -1;
                    e.Row.Cells[9].Text = "N/A";
                    e.Row.Cells[10].Text = "N/A";
                }
                if (_t3qty > 0)
                {
                    r3 = decimal.Round((_test3 / _t3qty), MidpointRounding.AwayFromZero);
                    e.Row.Cells[11].Text = r3 + "%";
                }
                else
                {
                    r3 = -1;
                    e.Row.Cells[11].Text = "N/A";
                }
                //Actual progress calc
                if (r1 == -1 && r2 == -1 && r3 == -1)
                    e.Row.Cells[13].Text = "N/A";
                else if (r1 != -1 && r2 == -1 && r3 == -1)
                    e.Row.Cells[13].Text = Decimal.Round(r1, MidpointRounding.AwayFromZero) + "%";
                else if (r1 == -1 && r2 != -1 && r3 == -1)
                    e.Row.Cells[13].Text = Decimal.Round(r2, MidpointRounding.AwayFromZero) + "%";
                else if (r1 == -1 && r2 == -1 && r3 != -1)
                    e.Row.Cells[13].Text = Decimal.Round(r3, MidpointRounding.AwayFromZero) + "%";
                else if (r1 != -1 && r2 != -1 && r3 == -1)
                    e.Row.Cells[13].Text = Decimal.Round(((r1 * 0.85m) + (r2 * 0.15m)), MidpointRounding.AwayFromZero) + "%";
                else if (r1 != -1 && r2 == -1 && r3 != -1)
                {
                    if (lblprj.Text == "ARSD") e.Row.Cells[13].Text = Decimal.Round(((r1 * 0.80m) + (r3 * 0.20m)), MidpointRounding.AwayFromZero) + "%";
                    else e.Row.Cells[13].Text = Decimal.Round(((r1 * 0.70m) + (r3 * 0.30m)), MidpointRounding.AwayFromZero) + "%";
                }
                else if (r1 == -1 && r2 != -1 && r3 != -1)
                    e.Row.Cells[13].Text = Decimal.Round(((r1 * 0.25m) + (r3 * 0.75m)), MidpointRounding.AwayFromZero) + "%";
                else
                    e.Row.Cells[13].Text = Decimal.Round(((r1 * 0.6m) + (r2 * 0.1m) + (r3 * 0.3m)), MidpointRounding.AwayFromZero) + "%";

                //Planned progress calc
                if (r1p != -1 && r2p == -1 && r3p == -1)
                    e.Row.Cells[12].Text = Decimal.Round((r1p), MidpointRounding.AwayFromZero) + "%";
                else if (r1p == -1 && r2p != -1 && r3p == -1)
                    e.Row.Cells[12].Text = Decimal.Round((r2p), MidpointRounding.AwayFromZero) + "%";
                else if (r1p == -1 && r2p == -1 && r3p != -1)
                    e.Row.Cells[12].Text = Decimal.Round((r3p), MidpointRounding.AwayFromZero) + "%";
                else if (r1p == -1 && r2p != -1 && r3p != -1)
                    e.Row.Cells[12].Text = Decimal.Round((r2p * 0.25m) + (r3p * 0.75m), MidpointRounding.AwayFromZero) + "%";
                else if (r1p != -1 && r2p != -1 && r3p == -1)
                    e.Row.Cells[12].Text = Decimal.Round((r1p * 0.85m) + (r2p * .15m), MidpointRounding.AwayFromZero) + "%";
                else if (r1p != -1 && r2p == -1 && r3p != -1)
                {
                    if (lblprj.Text == "ARSD") e.Row.Cells[12].Text = Decimal.Round((r1p * 0.80m) + (r3p * .20m), MidpointRounding.AwayFromZero) + "%";
                    else e.Row.Cells[12].Text = Decimal.Round((r1p * 0.70m) + (r3p * .30m), MidpointRounding.AwayFromZero) + "%";
                }
                else if (r1p == -1 && r2p == -1 && r3p == -1)
                    e.Row.Cells[12].Text = "N/A";
                else
                    e.Row.Cells[12].Text = Decimal.Round((r1p * 0.6m) + (r2p * 0.1m) + (r3p * 0.3m), MidpointRounding.AwayFromZero) + "%";



                Session["Sum_QtyPlanned1"] = e.Row.Cells[3].Text;
                Session["Sum_QtyPlanned2"] = e.Row.Cells[6].Text;
                Session["Sum_QtyPlanned3"] = e.Row.Cells[9].Text;

                Session["Sum_PerPlanned1"] = e.Row.Cells[4].Text;
                Session["Sum_PerPlanned2"] = e.Row.Cells[7].Text;
                Session["Sum_PerPlanned3"] = e.Row.Cells[10].Text;

                Session["Sum_Percom1"] = e.Row.Cells[5].Text;
                Session["Sum_Percom2"] = e.Row.Cells[8].Text;
                Session["Sum_Percom3"] = e.Row.Cells[11].Text;

                Session["Sum_Poverall"] = e.Row.Cells[12].Text;
                Session["Sum_Overall"] = e.Row.Cells[13].Text;

            }
        }

        protected void mygridsumm_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.SetRenderMethodDelegate(RenderHeader1);
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

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _lbl = (Label)e.Row.FindControl("Label1");
                if (_lbl.Text == "0.00%")
                    _lbl.Text = "";
                else if (_lbl.Text == "-1%")
                    _lbl.Text = "N/A";



                if (e.Row.Cells[10].Text == "N/A" && e.Row.Cells[11].Text == "N/A" && e.Row.Cells[12].Text == "N/A") e.Row.Cells[9].Text = "N/A";

                if (e.Row.Cells[17].Text == "N/A") e.Row.Cells[16].Text = "N/A";
                if (e.Row.Cells[21].Text == "N/A") e.Row.Cells[20].Text = "N/A";



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
                _dtsummary.Columns.Add("QTY_PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PPERCENTAGE_PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("QTY_PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PPERCENTAGE_PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("QTY_PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("PPERCENTAGE_PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("PLANNED_TOTAL", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                _dtsummary.Columns.Add("count1", typeof(string));
                _dtsummary.Columns.Add("count2", typeof(string));
                _dtsummary.Columns.Add("count3", typeof(string));
                _dtsummary.Columns.Add("_p1", typeof(string));
                _dtsummary.Columns.Add("_p2", typeof(string));
                _dtsummary.Columns.Add("_p3", typeof(string));
                _dtsummary.Columns.Add("_pl1", typeof(string));
                _dtsummary.Columns.Add("_pl2", typeof(string));
                _dtsummary.Columns.Add("_pl3", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    decimal _ptotal = 0;
                    int count = 0;
                    int count1 = 0;
                    int count2 = 0;
                    int count3 = 0;
                    decimal _p_p_qty = 0;
                    decimal _p1_p_qty = 0;
                    decimal _p2_p_qty = 0;
                    decimal _pl1 = 0;
                    decimal _pl2 = 0;
                    decimal _pl3 = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"]) != -1)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"]);
                            count1 += 1;
                        }
                        if (Convert.ToDecimal(_row["per_com2"]) != -1)
                        {
                            _p2 += Convert.ToDecimal(_row["per_com2"]);
                            count2 += 1;
                        }
                        if (Convert.ToDecimal(_row["per_com3"]) != -1)
                        {
                            _p3 += Convert.ToDecimal(_row["per_com3"]);
                            count3 += 1;
                        }
                        var todaysDate = DateTime.Today;
                        if (!string.IsNullOrEmpty(hdnpcd.Value))
                        {
                            todaysDate = DateTime.ParseExact(hdnpcd.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        }

                        if (_row["pcdate"] != null && _row["pcdate"].ToString() != "")
                        {
                            var pcdate = DateTime.ParseExact(_row["pcdate"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                            if (pcdate <= todaysDate) _p_p_qty += 1;
                        }
                        if (_row["pcdate1"] != null && _row["pcdate1"].ToString() != "")
                        {
                            var pcdate1 = DateTime.ParseExact(_row["pcdate1"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            if (pcdate1 <= todaysDate) _p1_p_qty += 1;
                        }
                        if (_row["pcdate2"] != null && _row["pcdate2"].ToString() != "")
                        {
                            var pcdate2 = DateTime.ParseExact(_row["pcdate2"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            if (pcdate2 <= todaysDate) _p2_p_qty += 1;
                        }
                        if (Convert.ToDecimal(_row["per_com4"]) != -1)
                            _pl1 += 1;
                        if (Convert.ToDecimal(_row["per_com5"]) != -1)
                            _pl2 += 1;
                        if (Convert.ToDecimal(_row["per_com6"]) != -1)
                            _pl3 += 1;
                        count += 1;
                    }

                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _PlannedPer1 = 0;
                    decimal _PlannedPer2 = 0;
                    decimal _PlannedPer3 = 0;
                    if (_pl1 > 0)
                        _PlannedPer1 = decimal.Round((_p_p_qty / _pl1) * 100, MidpointRounding.AwayFromZero);
                    if (_pl2 > 0)
                        _PlannedPer2 = decimal.Round((_p1_p_qty / _pl2) * 100, MidpointRounding.AwayFromZero);
                    if (_pl3 > 0)
                        _PlannedPer3 = decimal.Round((_p2_p_qty / _pl3) * 100, MidpointRounding.AwayFromZero);

                    if (count1 != 0)
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count1));

                    if (count2 != 0)
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count2));

                    if (count3 != 0)
                        _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count3));

                    if (count1 == 0) _per1 = -1;
                    if (count2 == 0) _per2 = -1;
                    if (count3 == 0) _per3 = -1;

                    if (_per1 != -1 && _per2 == -1 && _per3 == -1)
                        _total = Decimal.Round((_per1), MidpointRounding.AwayFromZero);

                    else if (_per1 == -1 && _per2 != -1 && _per3 == -1)
                    {
                        _total = Decimal.Round((_per2), MidpointRounding.AwayFromZero);
                    }
                    else if (_per1 == -1 && _per2 == -1 && _per3 != -1)
                    {
                        _total = Decimal.Round((_per3), MidpointRounding.AwayFromZero);
                    }
                    else if (_per1 == -1 && _per2 != -1 && _per3 != -1)
                    {
                        _total = Decimal.Round(((_per2 * 0.25m) + (_per3 * 0.75m)), MidpointRounding.AwayFromZero);
                    }
                    else if (_per1 != -1 && _per2 != -1 && _per3 == -1)
                    {
                        _total = Decimal.Round(((_per1 * 0.85m) + (_per2 * 0.15m)), MidpointRounding.AwayFromZero);
                    }
                    else if (_per1 != -1 && _per2 == -1 && _per3 != -1)
                    {
                        if (lblprj.Text == "ARSD") _total = Decimal.Round(((_per1 * 0.80m) + (_per3 * 0.20m)), MidpointRounding.AwayFromZero);
                        else _total = Decimal.Round(((_per1 * 0.70m) + (_per3 * 0.30m)), MidpointRounding.AwayFromZero);
                    } 


                    else if (_per1 == -1 && _per2 == -1 && _per3 == -1)
                        _total = -1;
                    else
                    {
                        _total = Decimal.Round(((_per1 * 0.6m) + (_per2 * 0.1m) + (_per3 * 0.3m)), MidpointRounding.AwayFromZero);                       
                    }

                    if (_pl1 != 0 && _pl2 == 0 && _pl3 == 0)
                        _ptotal = Decimal.Round((_PlannedPer1), MidpointRounding.AwayFromZero);
                    else if (_pl1 == 0 && _pl2 != 0 && _pl3 == 0)
                        _ptotal = Decimal.Round((_PlannedPer2), MidpointRounding.AwayFromZero);
                    else if (_pl1 == 0 && _pl2 == 0 && _pl3 != 0)
                        _ptotal = Decimal.Round((_PlannedPer3), MidpointRounding.AwayFromZero);
                    else if (_pl1 == 0 && _pl2 != 0 && _pl3 != 0)
                        _ptotal = Decimal.Round((_PlannedPer2 * 0.25m) + (_PlannedPer3 * 0.75m), MidpointRounding.AwayFromZero);
                    else if (_pl1 != 0 && _pl2 != 0 && _pl3 == 0)
                        _ptotal = Decimal.Round((_PlannedPer1 * 0.85m) + (_PlannedPer2 * .15m), MidpointRounding.AwayFromZero);
                    else if (_pl1 != 0 && _pl2 == 0 && _pl3 != 0)
                    {
                        if (lblprj.Text == "ARSD") _ptotal = Decimal.Round((_PlannedPer1 * 0.80m) + (_PlannedPer3 * .20m), MidpointRounding.AwayFromZero);
                        else _ptotal = Decimal.Round((_PlannedPer1 * 0.70m) + (_PlannedPer3 * .30m), MidpointRounding.AwayFromZero);
                    }
                    else if (_pl1 == 0 && _pl2 == 0 && _pl3 == 0)
                        _ptotal = -1;
                    else
                        _ptotal = Decimal.Round((_PlannedPer1 * 0.6m) + (_PlannedPer2 * 0.1m) + (_PlannedPer3 * 0.3m), MidpointRounding.AwayFromZero);

                    DataRow _drow = _dtsummary.NewRow();
                    _drow["SYS_NAME"] = row.col2.ToString();
                    _drow["QTY"] = count.ToString();
                    _drow["QTY_PER_COMPLETED"] = (_pl1 == 0)? "N/A": _p_p_qty.ToString();
                    _drow["PPERCENTAGE_PER_COMPLETED"] = (_pl1 == 0)? "N/A":decimal.Round(_PlannedPer1, MidpointRounding.AwayFromZero).ToString();
                    _drow["PER_COMPLETED"] = (_per1 == -1)? "N/A":decimal.Round(_per1, MidpointRounding.AwayFromZero).ToString();
                    _drow["QTY_PER_COMPLETED1"] = (_pl2 == 0)? "N/A":_p1_p_qty.ToString();
                    _drow["PPERCENTAGE_PER_COMPLETED1"] = (_pl2 == 0)? "N/A":decimal.Round(_PlannedPer2, MidpointRounding.AwayFromZero).ToString();
                    _drow["PER_COMPLETED1"] = (_per2 == -1)? "N/A":decimal.Round(_per2, MidpointRounding.AwayFromZero).ToString();
                    _drow["QTY_PER_COMPLETED2"] = (_pl3 == 0)? "N/A":_p2_p_qty.ToString();
                    _drow["PPERCENTAGE_PER_COMPLETED2"] = (_pl3 == 0) ? "N/A":decimal.Round(_PlannedPer3, MidpointRounding.AwayFromZero).ToString();
                    _drow["PER_COMPLETED2"] = (_per3 == -1)? "N/A":decimal.Round(_per3, MidpointRounding.AwayFromZero).ToString();
                    _drow["TOTAL"] = (_total == -1)? "N/A":_total.ToString();
                    _drow["PLANNED_TOTAL"] = (_ptotal == -1)? "N/A":decimal.Round(_ptotal, MidpointRounding.AwayFromZero).ToString();
                    _drow["CODE"] = row.col3.ToString();
                    _drow["count1"] = count1.ToString();
                    _drow["count2"] = count2.ToString();
                    _drow["count3"] = count3.ToString();
                    _drow["_p1"] = _p1.ToString();
                    _drow["_p2"] = _p2.ToString();
                    _drow["_p3"] = _p3.ToString();
                    _drow["_pl1"] = _pl1.ToString();
                    _drow["_pl2"] = _pl2.ToString();
                    _drow["_pl3"] = _pl3.ToString();
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

        protected void print_Click(object sender, EventArgs e)
        {
            //Session["zone"] = drbuilding.SelectedItem.Value;
            //Session["flvl"] = drflevel.SelectedItem.Value;
            //Session["cat"] = drcategory.SelectedItem.Value;
            //Session["fed"] = drfed.SelectedItem.Value;
            Insert_Summary();
            string _path = "Cas_Report.aspx?id=4_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value + "_Z" + (string)Session["zero"];

            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.open('" + _path + "');", true);
            //Generate_Summary();
        }

        protected void drloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["loc"] = drloc.SelectedItem.Value;
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

                _objcls.per_com1 = Convert.ToDecimal(row["PER_COMPLETED"].ToString());
                _objcls.per_com2 = Convert.ToDecimal(row["PER_COMPLETED1"].ToString());
                _objcls.per_com3 = Convert.ToDecimal(row["PER_COMPLETED2"].ToString());
                _objcls.total = Convert.ToDecimal(row["TOTAL"].ToString());
                _objcls.cate = row["CODE"].ToString();
                _objcls.quantity = Convert.ToInt32(row["QTY"].ToString());
                _objcls.compl1 = Convert.ToInt32(row["QTY_PER_COMPLETED"].ToString());
                _objcls.compl2 = Convert.ToInt32(row["QTY_PER_COMPLETED1"].ToString());
                _objcls.compl3 = Convert.ToInt32(row["QTY_PER_COMPLETED2"].ToString());


                _objbll.Generate_CASSummary_PKG_RPT_ASAO(_objcls, _objdb);
                //count += 1;
            }
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + count.ToString() + "');", true);
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
            Generate_Summary();
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
            Generate_Summary();
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

            drbuilding.SelectedValue = (string)Session["zone"];
            drcategory.SelectedValue = (string)Session["cat"];
            drflevel.SelectedValue = (string)Session["flvl"];
            drfed.SelectedValue = (string)Session["fed"];
            drloc.SelectedValue = (string)Session["loc"];

            Generate_Summary();
        }
        private void Filtering_zero()
        {
            Load_Master();
            var _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("test1") == null && o.Field<string>("test2") == null && o.Field<string>("test3") == null && o.Field<string>("test6") == null && o.Field<string>("test7") == null
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