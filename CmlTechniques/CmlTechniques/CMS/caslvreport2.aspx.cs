using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Data;
using System.Collections;
using System.IO;
namespace CmlTechniques.CMS
{
    public partial class caslvreport2 : System.Web.UI.Page  
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
        public static DataTable _dtMaster;
        public static DataTable _dtfilter;
        public static DataTable _dtresult;
        public static DataTable _summary;
        public bool _exp;
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
                    Set_Title();
                }
                else if (_prm.Contains("_F") == true)
                {
                    lblprj.Text = _prm.Substring(0, _prm.IndexOf("_F"));
                    lbldiv.Text = _prm.Substring(_prm.IndexOf("_F") + 2);
                    //Set_Title();
                }
                else
                    lblprj.Text = _prm;

                if (Session["access"] == null || Session["access"].ToString() == "")
                {
                    if (Session["uid"].ToString().IndexOf("@cmlgroup.ae") == -1)
                    {
                        Session["access"] = "Read Only";
                    }
                    else
                    {
                        Session["access"] = "Review/Comment";
                    }
                }

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

                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    weighting.Visible = false;
                    Generate_Summary1();
                }
                //else if (lblprj.Text == "11736")
                //{
                //    Generate_Summary2();
                //    Head_Merging();
                //}
                else
                {
                    Generate_Summary2();
                    Head_Merging();
                }
                if (lblprj.Text == "12710")
                {
                    w2.Visible = true;
                    w1.Visible = false;
                }
                else
                {
                    w1.Visible = true;
                    w2.Visible = false;
                }

                //Load_Summary();
                _exp = false;

            }
        }
        private void Set_Title()
        {
            if (lbldiv.Text == "1")
                lblhead.Text = "Wings - " + lblhead.Text;
            else if (lbldiv.Text == "2")
                lblhead.Text = "Main - " + lblhead.Text;
            else if (lbldiv.Text == "3")
                lblhead.Text = "Technical - " + lblhead.Text;
        }
        private void Load_Filtering_Elements()
        {
            drbuilding.Items.Clear();
            drcategory.Items.Clear();
            drflevel.Items.Clear();
            drfed.Items.Clear();
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
                _objcas.sch = 5;
            _objcas.prj_code = lblprj.Text;
                _objcas.sys = 0;
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
                                orderby dRow["possition"]
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
        protected void Populate_view()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DB_" + (string)Session["project"];
            //_clscassheet _objcas = new _clscassheet();
            //_objcas.sch = Convert.ToInt32((string)Session["sch"]);
            //_objcas.prj_code = (string)Session["project"];
            //Head_Merging();
            //mygrid.DataSource = _objbll.Load_casMain_Edit(_objcas,_objdb);
            //mygrid.DataBind();
            //GridViewHelper _help = new GridViewHelper(mygrid);
            //_help.RegisterGroup("sys_name", true, true);
            //_help.GroupHeader += new GroupEvent(helper_GroupHeader);
            //_help.ApplyGroupSort();
            //Load_Summary();

        }
        private void Head_Merging()
        {
            //info.AddMergedColumns(new int[] { 2, 3, 4, 5 }, "ASSET CODE");
            //info.AddMergedColumns(new int[] { 10, 11, 12, 13, 14, 15 }, "PANNEL SITE TESTING");
            //info.AddMergedColumns(new int[] { 17, 18 }, "PANEL TEST SHEETS");
            //info.AddMergedColumns(new int[] { 19, 20, 21, 22, 23 }, "OUTGOING CIRCUIT TESTING");
            //info.AddMergedColumns(new int[] { 24, 25 }, "FINAL TEST SHEETS");
            info1.AddMergedColumns(new int[] { 2, 3 }, "PANEL/EQUIPMENT TEST");
            info1.AddMergedColumns(new int[] { 4, 5 }, "OUTGOING CIRCUIT TEST");
        }
        protected void Load_Summary()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            info1.AddMergedColumns(new int[] { 2, 3 }, "Panel/Equipment Test");
            info1.AddMergedColumns(new int[] { 4, 5 }, "Outgoing Circuit Test");
            _objcas.sch = Convert.ToInt32((string)Session["sch"]);
            //_objcas.prj_code = (string)Session["project"];
            //_objcas.sys = 1;
            //mygridsumm.DataSource = _objbll.Load_CasSummary(_objcas,_objdb);
            //mygridsumm.DataBind();
            mygridsumm.DataSource = _objbll.LOAD_CAS_PKG_SUMMARY(_objcas, _objdb);
            mygridsumm.DataBind();
        }
        private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == "sys_name")
            {
                row.BackColor = System.Drawing.Color.FromName("#b1dff6");
                row.Cells[0].Text = "&nbsp;&nbsp;" + row.Cells[0].Text;
                row.Height = 30;
            }

        }
        private void helper_GroupHeader1(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == "F_lvl")
            {
                row.BackColor = System.Drawing.Color.FromName("#b1dff6");
                row.Cells[1].Text = "&nbsp;&nbsp;" + row.Cells[1].Text;
                row.Height = 30;
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

        protected void mygrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //mygrid.PageIndex = e.NewPageIndex;
            //mygrid.DataBind();
        }

        protected void mygrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            //DataTable dataTable = mygrid.DataSource as DataTable;

            //if (dataTable != null)
            //{
            //    DataView dataView = new DataView(dataTable);
            //    dataView.Sort = "Sys_id" + " " + ConvertSortDirectionToSql(e.SortDirection);

            //    mygrid.DataSource = dataView;
            //    mygrid.DataBind();
            //}

        }

        protected void export_Click(object sender, EventArgs e)
        {
            //string html = HdnValue.Value;
            //ExportToExcel(ref html, "MyReport");
            string html = hdnInnerHtml.Value;
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(1));
            Response.Clear();
            Response.AppendHeader("content-disposition", "attachment;filename=FileName.xls");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            this.EnableViewState = false;
            Response.Write("\r\n");
            Response.Write(html);
            Response.End();

        }
        public void ExportToExcel(ref string html, string fileName)
        {
            html = html.Replace("&gt;", ">");
            html = html.Replace("&lt;", "<");
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName + "_" + DateTime.Now.ToString("M_dd_yyyy_H_M_s") + ".xls");
            HttpContext.Current.Response.ContentType = "application/xls";
            HttpContext.Current.Response.Write(html);
            HttpContext.Current.Response.End();
        }

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells[0].Text != "") return;
            e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
        }

        protected void mygrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.SetRenderMethodDelegate(RenderHeader);
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
        decimal _tested = 0;
        decimal _tested1 = 0;
        decimal _tested2 = 0;
        decimal _tested3 = 0;
        decimal _total = 0;
        decimal _count = 0;
        decimal _count1 = 0;
        decimal _calsum = 0;
        decimal _acce = 0;
        decimal _pnl = 0;
        decimal _sumry = 0;
        decimal _planned = 0;

        int _q1 = 0; int _q2 = 0; int _q3 = 0;
        protected void mygridsumm_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[16].Visible = false;
            e.Row.Cells[17].Visible = false;
            if (lblprj.Text == "demo" && Session["access"].ToString() == "Read Only")
            {
                e.Row.Cells[6].Visible = false;
            }

                e.Row.Cells[7].Visible = false;
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;

            decimal _calc = 0;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();

                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (e.Row.Cells[1].Text != "Distribution Board Circuits")
                    {
                        _qty += Convert.ToDecimal(e.Row.Cells[2].Text);
                        _sumry += Decimal.Round(Convert.ToDecimal(e.Row.Cells[2].Text) * Convert.ToDecimal(e.Row.Cells[16].Text), MidpointRounding.AwayFromZero);
                    }
                    if (e.Row.Cells[7].Text == "-1")
                        e.Row.Cells[7].Text = "N/A";
                    else
                        _tested += Convert.ToDecimal(e.Row.Cells[7].Text);
                    if (e.Row.Cells[8].Text == "-1")
                        e.Row.Cells[8].Text = "N/A";
                    else
                        _tested1 += Convert.ToDecimal(e.Row.Cells[8].Text);
                    if (e.Row.Cells[9].Text == "-1")
                        e.Row.Cells[9].Text = "N/A";
                    else
                        _tested2 += Convert.ToDecimal(e.Row.Cells[9].Text);
                    if (e.Row.Cells[10].Text == "-1")
                        e.Row.Cells[10].Text = "N/A";
                    else
                        _acce += Convert.ToDecimal(e.Row.Cells[10].Text);
                    if (e.Row.Cells[17].Text != "-1")
                        _pnl += Convert.ToDecimal(e.Row.Cells[17].Text);
                }
                else
                {
                    _qty += Convert.ToDecimal(e.Row.Cells[2].Text);
                    if (e.Row.Cells[13].Text != "-1")
                        _tested1 += Convert.ToDecimal(e.Row.Cells[13].Text);
                    else
                    {
                        Label _lbl = (Label)e.Row.Cells[3].FindControl("lbl1");
                        _lbl.Text = "N/A";
                        _q1 += 1;
                    }
                    if (e.Row.Cells[14].Text != "-1")
                        _tested2 += Convert.ToDecimal(e.Row.Cells[14].Text);
                    else
                    {
                        Label _lbl = (Label)e.Row.Cells[4].FindControl("lbl2");
                        _lbl.Text = "N/A";
                        _q2 += 1;
                    }
                    if (e.Row.Cells[15].Text != "-1")
                        _tested3 += Convert.ToDecimal(e.Row.Cells[15].Text);
                    else
                    {
                        Label _lbl = (Label)e.Row.Cells[5].FindControl("lbl3");
                        _lbl.Text = "N/A";
                        _q3 += 1;
                    }
                    _total += Convert.ToDecimal(e.Row.Cells[16].Text);

                    _count += 1;
                    //if (lblprj.Text == "ASAO" || lblprj.Text == "Trial")
                    //    _sumry += (Convert.ToDecimal(e.Row.Cells[2].Text) * Convert.ToDecimal(e.Row.Cells[15].Text));
                    _calc = (Convert.ToDecimal(e.Row.Cells[2].Text) * Convert.ToDecimal(e.Row.Cells[16].Text)) / 100;
                    //_calc = decimal.Round(_calc, 2);
                    _calsum += _calc;
                    e.Row.Cells[6].Text = _calc.ToString();

                     _planned += Convert.ToDecimal(e.Row.Cells[18].Text);


                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "TOTALS";
                e.Row.Cells[2].Text = _qty.ToString();
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    e.Row.Cells[7].Text = Decimal.Round(_tested).ToString();
                    e.Row.Cells[8].Text = Decimal.Round(_tested1).ToString();
                    e.Row.Cells[9].Text = Decimal.Round(_tested2).ToString();
                    e.Row.Cells[10].Text = Decimal.Round(_acce).ToString();
                    decimal _ovrl = _sumry / _qty;
                    if (_ovrl > 99 && _ovrl < 100)
                        _ovrl = 99;
                    else
                        _ovrl = Decimal.Round(_sumry / _qty, 1, MidpointRounding.AwayFromZero);
                    e.Row.Cells[11].Text = Decimal.Round(_ovrl).ToString() + '%';
                    //e.Row.Cells[10].Text = _sumry.ToString();
                }
                else
                {
                    if ((_count - _q1) > 0)
                        e.Row.Cells[3].Text = (Decimal.Round((_tested1 / (_count - _q1)), 0, MidpointRounding.AwayFromZero)).ToString() + '%';
                    else
                        e.Row.Cells[3].Text = "N/A";
                    if ((_count - _q2) > 0)
                        e.Row.Cells[4].Text = (Decimal.Round((_tested2 / (_count - _q2)), 0, MidpointRounding.AwayFromZero)).ToString() + '%';
                    else
                        e.Row.Cells[4].Text = "N/A";
                    if ((_count - _q3) > 0)
                        e.Row.Cells[5].Text = (Decimal.Round((_tested3 / (_count - _q3)), 0, MidpointRounding.AwayFromZero)).ToString() + '%';
                    else
                        e.Row.Cells[5].Text = "N/A";
                    //e.Row.Cells[5].Text = _count.ToString();
                    //decimal i = _count - 1;
                    //if (i > 1)
                    //{
                    //    e.Row.Cells[5].Text = (Decimal.Round((_tested3 / i))).ToString() + '%';
                    //}
                    e.Row.Cells[6].Text = (Decimal.Round(_calsum, 2)).ToString();
                    //e.Row.Cells[7].Text = (Decimal.Round((_total / _count))).ToString() + '%';
                    if (_qty > 0)
                        e.Row.Cells[11].Text = (Decimal.Round((_calsum / _qty) * 100, 0, MidpointRounding.AwayFromZero)).ToString() + '%';
                    e.Row.Cells[18].Text = _planned.ToString();
                    if (_qty > 0)
                        e.Row.Cells[19].Text = (Decimal.Round((_planned / _qty) * 100, 0, MidpointRounding.AwayFromZero)).ToString() + '%';
                }
            }
        }

        protected void mygridsumm_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.SetRenderMethodDelegate(RenderHeader1);
        }

        protected void mygrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void print_Click(object sender, EventArgs e)
        {
            string _path = "";
            //Session["zone"] = drbuilding.SelectedItem.Value;
            //Session["flvl"] = drflevel.SelectedItem.Value;
            //Session["cat"] = drcategory.SelectedItem.Value;
            //Session["fed"] = drfed.SelectedItem.Value;
            Insert_Summary();
            //string _path = "Cas_Report.aspx?id=5_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value + "_Z" + (string)Session["zero"];

                _path = "Cas_Report.aspx?id=5_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value + "_Z" + (string)Session["zero"] + "&Div=" + lbldiv.Text;
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
            _exp = true;

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
                e.Row.Cells[7].Attributes.Add("style", "word-wrap:break-word;");
                e.Row.Cells[8].Attributes.Add("style", "word-wrap:break-word;");
                e.Row.Cells[9].Attributes.Add("style", "word-wrap:break-word;");
                e.Row.Cells[10].Attributes.Add("style", "word-wrap:break-word;");
                Label _lbl = (Label)e.Row.FindControl("Label1");
                if (_lbl.Text == "0.00%")
                    _lbl.Text = "";
                else if (_lbl.Text == "-1%")
                    _lbl.Text = "N/A";
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
            _dtresult = _filter.Any() ? _filter.CopyToDataTable() : _dtMaster.Clone();
            Load_Details();
            if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                Generate_Summary1();
            //else if (lblprj.Text == "11736")
            //{
            //    Generate_Summary2();
            //}
            else
                Generate_Summary2();
        }
        private void Filtering_zero()
        {
            Load_Master();
            var _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<decimal>("per_com1") == 0 && o.Field<string>("tested1") == "0" && o.Field<string>("tested2") == "0"
                          select o;
            _dtresult = _filter.Any() ? _filter.CopyToDataTable() : _dtMaster.Clone();
            Load_Details();
            if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                Generate_Summary1();
            //else if (lblprj.Text == "11736")
            //{
            //    Generate_Summary2();
            //}
            else
                Generate_Summary2();
        }
        private bool IsNumeric(object Expression)
        {
            // Variable to collect the Return value of the TryParse method.
            bool isNum;

            // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
            double retNum;

            // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
            // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void Generate_Summary()
        {
            try
            {
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                _dtsummary.Columns.Add("PANEL", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    orderby dRow["possition"]
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
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
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 0, MidpointRounding.AwayFromZero);
                    if (_p2 != 0)
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 0, MidpointRounding.AwayFromZero);
                    if (_p3 != 0)
                        _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count), 0, MidpointRounding.AwayFromZero);
                    if (row.col3.ToString() == "MDB") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                    else if (row.col3.ToString() == "PFC")
                    {
                        if (lblprj.Text == "BCC1")
                        {
                            _total = Decimal.Round(_per1);
                            _per2 = -1;
                            _per3 = -1;
                        }
                        else
                        {
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), 0, MidpointRounding.AwayFromZero);
                        }
                    }

                    else if (row.col3.ToString() == "HCP") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), 0, MidpointRounding.AwayFromZero);
                    else if (row.col3.ToString() == "DB")
                    {
                        if (lblprj.Text == "12710")
                        {
                            _total = Decimal.Round((_per2 * 0.5m) + (_per3 * 0.5m), 0, MidpointRounding.AwayFromZero);
                        }
                        else
                            _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), 0, MidpointRounding.AwayFromZero);
                        _per1 = -1;
                    }
                    else if (row.col3.ToString() == "LCP")
                    {
                        if (lblprj.Text == "12710")
                        {
                            _total = Decimal.Round((_per2 * 0.5m) + (_per3 * 0.5m), 0, MidpointRounding.AwayFromZero);
                        }
                        else
                            _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), 0, MidpointRounding.AwayFromZero);
                        _per1 = -1;
                    }
                    else if (row.col3.ToString() == "UPS")
                    {
                        if (lblprj.Text == "12710")
                        {
                            _total = Decimal.Round((_per2 * 0.5m) + (_per3 * 0.5m), 0, MidpointRounding.AwayFromZero);
                        }
                        else
                            _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), 0, MidpointRounding.AwayFromZero);
                        _per1 = -1;
                    }
                    else if (row.col3.ToString() == "EFP")
                    {
                        if (lblprj.Text == "12710")
                        {
                            _total = Decimal.Round((_per2 * 0.5m) + (_per3 * 0.5m), 0, MidpointRounding.AwayFromZero);
                            _per1 = -1;
                        }
                        else
                            _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), 0, MidpointRounding.AwayFromZero);
                        _per1 = -1;
                    }
                    else if (row.col3.ToString() == "SMDB") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), 0, MidpointRounding.AwayFromZero);
                    else if (row.col3.ToString() == "MCC") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), 0, MidpointRounding.AwayFromZero);
                    else if (row.col3.ToString() == "ATS") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), 0, MidpointRounding.AwayFromZero);
                    else if (row.col3.ToString() == "BDT")
                    {
                        _per3 = -1;
                        _total = Decimal.Round((_per1 * 0.6m) + (_per2 * 0.4m), 0, MidpointRounding.AwayFromZero);
                    }
                    else _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), 0, MidpointRounding.AwayFromZero);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = _per1.ToString();
                    _drow[3] = _per2.ToString();
                    _drow[4] = _per3.ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _drow[7] = "0";
                    //_drow[0] = "";
                    //_drow[1] = count.ToString();
                    //_drow[2] = _per1.ToString();
                    //_drow[3] = _per2.ToString();
                    //_drow[4] = _per3.ToString();
                    //_drow[5] = _total.ToString();
                    //_drow[6] = "";
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
                decimal _circuits = 0;
                decimal _tlive = 0;
                decimal _tcold = 0;
                decimal _twit = 0;
                decimal _panel = 0;
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                _dtsummary.Columns.Add("PANEL", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    orderby dRow["possition"]
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
                    decimal _circuit = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    decimal _na1 = 0;
                    decimal _na2 = 0;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100)
                            _p1 += 1;
                        //if (Convert.ToDecimal(_row["per_com2"].ToString()) == 100)
                        //    _p2 += 1;
                        //_p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        //if (Convert.ToDecimal(_row["per_com3"].ToString()) == 100)
                        //    _p3 += 1;
                        //_p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        if (row.col3.ToString() == "DB")
                        {
                            _circuits += Convert.ToDecimal(_row["devices1"].ToString());
                            if (IsNumeric(_row["tested1"].ToString()) == true)
                                _tcold += Convert.ToInt32(_row["tested1"].ToString());
                            if (IsNumeric(_row["tested2"].ToString()) == true)
                                _tlive += Convert.ToInt32(_row["tested2"].ToString());
                            _twit += Convert.ToInt32(_row["per_com4"].ToString());
                        }
                        _circuit += Convert.ToDecimal(_row["devices1"].ToString());
                        decimal _device = 0;
                        _device = Convert.ToDecimal(_row["devices1"].ToString());
                        if (_row["tested1"].ToString().Length > 0 && IsNumeric(_row["tested1"].ToString()) == false) _na1 += _device;
                        if (_row["tested2"].ToString().Length > 0 && IsNumeric(_row["tested2"].ToString()) == false) _na2 += _device;
                        _p5 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;

                    if (count != 0)
                        _per1 = (_p5 / Convert.ToDecimal(count));
                    //if (_circuits != 0)
                    //{
                    if (_na1 >= _circuit)
                        _per2 = -1;
                    else
                    {
                        if (_circuit > 0)
                            _per2 = (_p2 / Convert.ToDecimal(_circuit - _na1)) * 100;
                    }
                    //}
                    //if (_circuits != 0)
                    //{
                    if (_na2 >= _circuit)
                        _per3 = -1;
                    else
                    {
                        if (_circuit > 0)
                            _per3 = (_p3 / Convert.ToDecimal(_circuit - _na2)) * 100;
                    }
                    //}
                    //_tlive += _p2;
                    //_tcold += _p3;
                    //_twit += _p4;
                    _panel += _p1;
                    if (row.col3.ToString() == "MDB")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m)), MidpointRounding.AwayFromZero);
                    }
                    else if (row.col3.ToString() == "PFC")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    else if (row.col3.ToString() == "HCP")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    else if (row.col3.ToString() == "DB")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                        {
                            _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                            _p1 = -1;
                        }
                    }
                    else if (row.col3.ToString() == "LCP")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                        {
                            _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                            _p1 = -1;
                        }
                    }
                    else if (row.col3.ToString() == "UPS")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                        {
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                        }
                    }
                    else if (row.col3.ToString() == "EFP")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                        {
                            _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                            _p1 = -1;
                        }
                    }
                    else if (row.col3.ToString() == "SMDB")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    else if (row.col3.ToString() == "MCC")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    else if (row.col3.ToString() == "ATS")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }

                    else if (row.col3.ToString() == "BDT")
                    {
                        //_p3 = -1;
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    else if (row.col3.ToString() == "GPU")
                    {
                        //_p3 = -1;
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.8m) + (_per3 * 0.2m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.8m) + (_per2 * 0.2m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.6m) + (_per2 * 0.4m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    if (_total < 0) _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = decimal.Round(_p2).ToString();
                    _drow[3] = decimal.Round(_p3).ToString();
                    _drow[4] = decimal.Round(_p4).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _drow[7] = decimal.Round(_p1).ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                if (_circuits > 0)
                {
                    decimal _totalcold = _tcold / _circuits * 100;
                    decimal _totallive = _tlive / _circuits * 100;
                    decimal _ocircuit = Decimal.Round((_totalcold * 0.6m) + (_totallive * 0.4m), MidpointRounding.AwayFromZero);
                    DataRow _drow1 = _dtsummary.NewRow();
                    _drow1[0] = "Distribution Board Circuits";
                    _drow1[1] = _circuits.ToString();
                    _drow1[2] = decimal.Round(_tcold).ToString();
                    _drow1[3] = decimal.Round(_tlive).ToString();
                    _drow1[4] = decimal.Round(_twit).ToString();
                    _drow1[5] = _ocircuit.ToString();
                    _drow1[6] = "Circuits";
                    _drow1[7] = "-1";
                    //_drow1[7] = decimal.Round(_acce).ToString();
                    _dtsummary.Rows.Add(_drow1);
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
        private void Generate_Summary2()
        {
            try
            {
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                _dtsummary.Columns.Add("PANEL", typeof(string));
                _dtsummary.Columns.Add("TOTAL_PLANNED", typeof(string));
                _dtsummary.Columns.Add("PLANNED_PER", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    orderby dRow["possition"]
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    decimal _planned = 0;
                    decimal _plannedper = 0;
                    int count = 0;
                    int _na1 = 0;
                    int _na2 = 0;

                    //25-05-2017-Jene : Changes made to change count value from item count to circuit count.
                    int circuitCount = 0;
                    int coldTestCount = 0;
                    int liveTestCount = 0;
                    //END

                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        if (_row["tested1"].ToString().Length > 0 && IsNumeric(_row["tested1"].ToString()) == false) _na1 += 1;
                        if (_row["tested2"].ToString().Length > 0 && IsNumeric(_row["tested2"].ToString()) == false) _na2 += 1;
                        count += 1;

                        //25-05-2017-Jene : Changes made to change count value from item count to circuit count.
                        if (_row["tested1"] != null && _row["tested1"].ToString() != "" && IsNumeric(_row["tested1"].ToString()))
                        {
                            coldTestCount += Convert.ToInt32(_row["tested1"]);
                        }
                        if (_row["tested2"] != null && _row["tested2"].ToString() != "" && IsNumeric(_row["tested2"].ToString()))
                        {
                            liveTestCount += Convert.ToInt32(_row["tested2"]);
                        }
                        if (_row["devices1"] != null && _row["devices1"].ToString() != "")
                        {
                            circuitCount += Convert.ToInt32(_row["devices1"]);
                        }
                        //END

                        if (_row["Plannedcompletion"] != null && _row["Plannedcompletion"].ToString() != "" && _row["Plannedcompletion"].ToString() != "N/A")
                        {
                            _planned = _planned += 1;
                        }

                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;

                    if (count != 0)
                        _per1 = (_p1 / Convert.ToDecimal(count));

                    //25-05-2017-Jene : Changes made to change count value from item count to circuit count.
                    //if (count != 0)
                    //{
                    //    if (_na1 == count)
                    //        _per2 = -1;
                    //    else
                    //        _per2 = (_p2 / Convert.ToDecimal(count - _na1));
                    //}
                    //if (count != 0)
                    //{
                    //    if (_na2 == count)
                    //        _per3 = -1;
                    //    else
                    //        _per3 = (_p3 / Convert.ToDecimal(count - _na2));
                    //}
                    if (coldTestCount != 0 && circuitCount != 0)
                    {
                        _per2 = ((coldTestCount * 100) / Convert.ToDecimal(circuitCount));
                    }
                    if (liveTestCount != 0 && circuitCount != 0)
                    {
                        _per3 = ((liveTestCount * 100) / Convert.ToDecimal(circuitCount));
                    }
                    //END

                    if ((string)Session["sch"] == "5" || ((string)Session["sch"] == "28" && lblprj.Text == "11784"))
                    {
                        _total = 0;
                        if (row.col3.ToString() == "MDB")
                        {
                            if (_per2 == -1 && _per3 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                            }
                            else if (_per3 == -1 && _per2 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p3 = -1;
                            }
                            else if (_per2 == -1 && _per3 == -1)
                            {
                                _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m)), MidpointRounding.AwayFromZero);
                        }
                        else if (row.col3.ToString() == "PFC")
                        {
                            if (_per2 == -1 && _per3 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                            }
                            else if (_per3 == -1 && _per2 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p3 = -1;
                            }
                            else if (_per2 == -1 && _per3 == -1)
                            {
                                _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                                _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                        }
                        else if (row.col3.ToString() == "HCP")
                        {
                            if (_per2 == -1 && _per3 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                            }
                            else if (_per3 == -1 && _per2 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p3 = -1;
                            }
                            else if (_per2 == -1 && _per3 == -1)
                            {
                                _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                                _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                        }
                        else if (row.col3.ToString() == "DB")
                        {
                            if (lblprj.Text == "demo")
                            {
                                _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                                _p1 = -1;
                                _per1 = -1;
                            }
                            else
                            {
                                if (_per2 == -1 && _per3 != -1)
                                {
                                    _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                    _p2 = -1;
                                }
                                else if (_per3 == -1 && _per2 != -1)
                                {
                                    _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                    _p3 = -1;
                                }
                                else if (_per2 == -1 && _per3 == -1)
                                {
                                    _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                    _p2 = -1;
                                    _p3 = -1;
                                }
                                else
                                {
                                    _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                                    _p1 = -1;
                                }
                            }
                        }
                        else if (row.col3.ToString() == "LCP")
                        {
                            if (_per2 == -1 && _per3 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                            }
                            else if (_per3 == -1 && _per2 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p3 = -1;
                            }
                            else if (_per2 == -1 && _per3 == -1)
                            {
                                _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                            {
                                _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                                _p1 = -1;
                            }
                        }
                        else if (row.col3.ToString() == "UPS")
                        {
                            if (_per2 == -1 && _per3 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                            }
                            else if (_per3 == -1 && _per2 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p3 = -1;
                            }
                            else if (_per2 == -1 && _per3 == -1)
                            {
                                _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                            {
                                _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                                _p1 = -1;
                            }
                        }
                        else if (row.col3.ToString() == "EFP")
                        {
                            if (_per2 == -1 && _per3 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                            }
                            else if (_per3 == -1 && _per2 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p3 = -1;
                            }
                            else if (_per2 == -1 && _per3 == -1)
                            {
                                _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                            {
                                _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                                _p1 = -1;
                            }
                        }
                        else if (row.col3.ToString() == "SMDB")
                        {
                            if (_per2 == -1 && _per3 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                            }
                            else if (_per3 == -1 && _per2 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p3 = -1;
                            }
                            else if (_per2 == -1 && _per3 == -1)
                            {
                                _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                                _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                        }
                        else if (row.col3.ToString() == "MCC")
                        {
                            if (_per2 == -1 && _per3 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                            }
                            else if (_per3 == -1 && _per2 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p3 = -1;
                            }
                            else if (_per2 == -1 && _per3 == -1)
                            {
                                _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                                _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                        }
                        else if (row.col3.ToString() == "ATS")
                        {
                            if (_per2 == -1 && _per3 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                            }
                            else if (_per3 == -1 && _per2 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p3 = -1;
                            }
                            else if (_per2 == -1 && _per3 == -1)
                            {
                                _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                                _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                        }

                        else if (row.col3.ToString() == "BDT")
                        {
                            //_p3 = -1;
                            if (_per2 == -1 && _per3 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                            }
                            else if (_per3 == -1 && _per2 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p3 = -1;
                            }
                            else if (_per2 == -1 && _per3 == -1)
                            {
                                _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                                _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            if (_per2 == -1 && _per3 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                            }
                            else if (_per3 == -1 && _per2 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p3 = -1;
                            }
                            else if (_per2 == -1 && _per3 == -1)
                            {
                                _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                                _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                        }
                    }
                    _plannedper = (_planned / count) * 100;

                    if (_total < 0) _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = decimal.Round(_per1, 0).ToString();
                    _drow[3] = decimal.Round(_per2, 0).ToString();
                    _drow[4] = decimal.Round(_per3, 0).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _drow[7] = "0";
                    _drow[8] = _planned;
                    _drow[9] = _plannedper;
                    //_drow[0] = "";
                    //_drow[1] = count.ToString();
                    //_drow[2] = _per1.ToString();
                    //_drow[3] = _per2.ToString();
                    //_drow[4] = _per3.ToString();
                    //_drow[5] = _total.ToString();
                    //_drow[6] = "";
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
                _objcls.compl1 = Convert.ToInt32(row["TOTAL_PLANNED"].ToString());
                _objcls.compl2 = Convert.ToInt32(row["PLANNED_PER"].ToString());

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
            if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                Generate_Summary1();
            //else if (lblprj.Text == "11736")
            //{
            //    Generate_Summary2();
            //}
            else
                Generate_Summary2();
        }
    }
}
