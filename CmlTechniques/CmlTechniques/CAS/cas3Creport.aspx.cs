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
using System.Collections.Generic;

namespace CmlTechniques.CAS
{
    public partial class cas3Creport : System.Web.UI.Page
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
        public static DataTable _dtnames;
        public bool _exp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "CreateGridHeader", "<script>CreateGridHeader('DataDiv', 'mymaster','HeaderDiv');</script>");
                string _prm = Request.QueryString[0].ToString();
                lblprj.Text = _prm;
                //Populate_view();
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
                Load_TestNames();

                Generate_Summary();
                //if (lblprj.Text == "12710")
                //{
                //    w2.Visible = true;
                //    w1.Visible = false;
                //}
                //else
                //{
                //    w1.Visible = true;
                //    w2.Visible = false;
                //}
                Head_Merging();
                //Load_Summary();
                _exp = false;
                drfed.Visible = false;
                drprogress.Visible = false;
            }
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
        private void Load_TestNames()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = 10;
            _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
        }
        private void Load_Master()
        {
            //var _dv = (DataView)ObjectDataSource1.Select();
            //_dtMaster = _dv.ToTable();
            //_dtresult = _dtMaster;
            _dtMaster = new DataTable();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32((string)Session["sch"]);
            _objcas.prj_code = lblprj.Text;
            _dtMaster = _objbll.Load_cassheet_data(_objcas, _objdb);
            _dtresult = _dtMaster;
        }
        private void Load_Details()
        {
            DataTable _dtable = new DataTable();
            _dtable.Columns.Add("Panel_Id", typeof(string));
            _dtable.Columns.Add("Panel_Ref", typeof(string));
            var distinctRows = (from DataRow dRow in _dtresult.Rows
                                where dRow["Panel_Parent"].ToString() == "0"
                                select new { col1 = dRow["Panel_Id"], col2 = dRow["Panel_Ref"] }).Distinct();
            foreach (var row in distinctRows)
            {
                DataRow _row = _dtable.NewRow();
                _row[0] = row.col1.ToString();
                _row[1] = row.col2.ToString();
                _dtable.Rows.Add(_row);
            }
            reptr_main.DataSource = _dtable;
            reptr_main.DataBind();
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
            info1.AddMergedColumns(new int[] { 2, 3 }, "CUP");
            info1.AddMergedColumns(new int[] { 4, 5 }, "SOUTH GALLERY");
            info1.AddMergedColumns(new int[] { 6, 7 }, "CLINIC");
            info1.AddMergedColumns(new int[] { 8, 9 }, "D&T, ICU, SWING, PATIENT");
            info1.AddMergedColumns(new int[] { 10, 11 }, "TOTAL");
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
            //string html = hdnInnerHtml.Value;
            //Response.Cache.SetExpires(DateTime.Now.AddSeconds(1));
            //Response.Clear();
            //Response.AppendHeader("content-disposition", "attachment;filename=FileName.xls");
            //Response.Charset = "";
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.ContentType = "application/vnd.ms-excel";
            //this.EnableViewState = false;
            //Response.Write("\r\n");
            //Response.Write(html);
            //Response.End();

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
        decimal _qty1 = 0;
        decimal _qty2 = 0;
        decimal _qty3 = 0;
        decimal _qty4 = 0;
        decimal _tested1 = 0;
        decimal _tested2 = 0;
        decimal _tested3 = 0;
        decimal _tested4 = 0;
        decimal _total = 0;
        decimal _tested = 0;
        protected void mygridsumm_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[16].Visible = false;
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
            //    _qty += Convert.ToDecimal(e.Row.Cells[2].Text);
            //    _panel += Convert.ToDecimal(e.Row.Cells[14].Text);
            //    _cold += Convert.ToDecimal(e.Row.Cells[15].Text);
            //    _live += Convert.ToDecimal(e.Row.Cells[16].Text);
            //    _total += Convert.ToDecimal(e.Row.Cells[17].Text);
            //    _pft += Convert.ToDecimal(e.Row.Cells[7].Text);
            //    _pwron += Convert.ToDecimal(e.Row.Cells[8].Text);
            //    _fpt += Convert.ToDecimal(e.Row.Cells[9].Text);
            //    _arm += Convert.ToDecimal(e.Row.Cells[10].Text);
            //    _count += 1;
            //}
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    e.Row.Cells[1].Text = "TOTALS";
            //    e.Row.Cells[2].Text = _qty.ToString();
            //    e.Row.Cells[3].Text = (Decimal.Round((_panel / _count))).ToString() + '%';
            //    e.Row.Cells[4].Text = (Decimal.Round((_cold / _count))).ToString() + '%';
            //    e.Row.Cells[5].Text = (Decimal.Round((_live / _count))).ToString() + '%';
            //    e.Row.Cells[6].Text = (Decimal.Round((_total / _count))).ToString() + '%';
            //    e.Row.Cells[7].Text = _pft.ToString();
            //    e.Row.Cells[8].Text = _pwron.ToString();
            //    e.Row.Cells[9].Text = _fpt.ToString();
            //    e.Row.Cells[10].Text = _arm.ToString();
            //    decimal _total1 = (Decimal.Round(((_fpt * 0.25m + _arm * 0.25m + _pwron * 0.25m + _pft * 0.25m) / _qty) * 100));
            //    e.Row.Cells[11].Text = _total1.ToString() + '%';
            //    e.Row.Cells[12].Text = (Decimal.Round(((_total / _count) * 0.8m + _total1 * 0.2m))).ToString() + '%';
            //}
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
                _qty1 += Convert.ToDecimal(e.Row.Cells[2].Text);
                _tested1 += Convert.ToDecimal(e.Row.Cells[13].Text);
                _qty2 += Convert.ToDecimal(e.Row.Cells[4].Text);
                _tested2 += Convert.ToDecimal(e.Row.Cells[14].Text);
                _qty3 += Convert.ToDecimal(e.Row.Cells[6].Text);
                _tested3 += Convert.ToDecimal(e.Row.Cells[15].Text);
                _qty4 += Convert.ToDecimal(e.Row.Cells[8].Text);
                _tested4 += Convert.ToDecimal(e.Row.Cells[16].Text);
                _qty += Convert.ToDecimal(e.Row.Cells[10].Text);
                _tested += Convert.ToDecimal(e.Row.Cells[11].Text);

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "TOTAL";
                e.Row.Cells[2].Text = _qty1.ToString();
                if (_qty1 != 0)
                    e.Row.Cells[3].Text = (Decimal.Round((_tested1 / _qty1) * 100)).ToString() + '%';
                else
                    e.Row.Cells[3].Text = _qty1.ToString() + '%';
                e.Row.Cells[4].Text = _qty2.ToString();
                if (_qty2 != 0)
                    e.Row.Cells[5].Text = (Decimal.Round((_tested2 / _qty2) * 100)).ToString() + '%';
                else
                    e.Row.Cells[5].Text = _qty2.ToString() + '%';
                e.Row.Cells[6].Text = _qty3.ToString();
                if (_qty3 != 0)
                    e.Row.Cells[7].Text = (Decimal.Round((_tested3 / _qty3) * 100)).ToString() + '%';
                else
                    e.Row.Cells[7].Text = _qty3.ToString() + '%';
                e.Row.Cells[8].Text = _qty4.ToString();
                if (_qty4 != 0)
                    e.Row.Cells[9].Text = (Decimal.Round((_tested4 / _qty4) * 100)).ToString() + '%';
                else
                    e.Row.Cells[9].Text = _qty4.ToString() + '%';
                e.Row.Cells[10].Text = _qty.ToString();
                e.Row.Cells[11].Text = _tested.ToString();
                if (_qty != 0)
                    e.Row.Cells[12].Text = (Decimal.Round((_tested / _qty) * 100)).ToString() + '%';
                else
                    e.Row.Cells[12].Text = _qty.ToString() + '%';
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
            Insert_Summary();
            string _path = "../CMS/Cas_Report.aspx?id=101_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value + "_Z" + (string)Session["zero"];
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
                _dtdetails.Columns.Add("P_P_to", typeof(string));
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
                _dtdetails.Columns.Add("test10", typeof(string));
                _dtdetails.Columns.Add("test11", typeof(string));
                _dtdetails.Columns.Add("Accept1", typeof(string));
                _dtdetails.Columns.Add("filed1", typeof(string));
                _dtdetails.Columns.Add("Accept2", typeof(string));
                _dtdetails.Columns.Add("test7", typeof(string));
                _dtdetails.Columns.Add("Comm", typeof(string));
                _dtdetails.Columns.Add("Act_by", typeof(string));
                _dtdetails.Columns.Add("Act_date", typeof(string));
                _dtdetails.Columns.Add("filed2", typeof(string));
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
                    _row[6] = row["p_p_to"].ToString();
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
                    _row[20] = row["test10"].ToString();
                    _row[21] = row["test11"].ToString();
                    _row[22] = row["accept1"].ToString();
                    _row[23] = row["filed1"].ToString();
                    _row[24] = row["accept2"].ToString();
                    _row[25] = row["test7"].ToString();
                    _row[26] = row["Comm"].ToString();
                    _row[27] = row["Act_by"].ToString();
                    _row[28] = row["Act_date"].ToString();
                    _row[29] = row["filed2"].ToString();
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
            //for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            //{
            //    GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
            //    Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
            //    _mydetails.Visible = false;
            //    _btn.Text = "+";
            //}
        }
        protected void btnexpd_Click(object sender, EventArgs e)
        {
            Button _expnd = sender as Button;
            int repeaterItemIndex = ((RepeaterItem)_expnd.NamingContainer).ItemIndex;
            RepeaterItem _Pcontainer = (RepeaterItem)_expnd.NamingContainer;
            //int index = gvRow.;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + index.ToString() + "');", true);
            GridView _mydetails = (GridView)_Pcontainer.FindControl("details");
            Button _btn = (Button)_Pcontainer.FindControl("btnexpd");
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
                e.Row.Cells[7].Attributes.Add("style", "word-wrap:break-word;word-break:break-all");
                e.Row.Cells[8].Attributes.Add("style", "word-wrap:break-word;word-break:break-all");
                e.Row.Cells[9].Attributes.Add("style", "word-wrap:break-word;word-break:break-all");
                e.Row.Cells[10].Attributes.Add("style", "word-wrap:break-word;word-break:break-all");

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
            _dtresult.Columns.Add("P_P_to", typeof(string));
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
            _dtresult.Columns.Add("test10", typeof(string));
            _dtresult.Columns.Add("test11", typeof(string));
            _dtresult.Columns.Add("Per_com1", typeof(string));
            _dtresult.Columns.Add("Accept1", typeof(string));
            _dtresult.Columns.Add("filed1", typeof(string));
            _dtresult.Columns.Add("Accept2", typeof(string));
            _dtresult.Columns.Add("test7", typeof(string));
            _dtresult.Columns.Add("Comm", typeof(string));
            _dtresult.Columns.Add("Act_by", typeof(string));
            _dtresult.Columns.Add("Act_date", typeof(string));
            _dtresult.Columns.Add("Per_com2", typeof(string));
            _dtresult.Columns.Add("Per_com3", typeof(string));
            _dtresult.Columns.Add("Per_com4", typeof(string));
            _dtresult.Columns.Add("Per_com5", typeof(string));
            _dtresult.Columns.Add("Per_com6", typeof(string));
            _dtresult.Columns.Add("filed2", typeof(string));
            _dtresult.Columns.Add("devices2", typeof(string));
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
            foreach (var row in _filter)
            {
                DataRow _row = _dtresult.NewRow();
                _row[0] = row["e_b_ref"].ToString();
                _row[1] = row["B_Z"].ToString();
                _row[2] = row["Cat"].ToString();
                _row[3] = row["F_lvl"].ToString();
                _row[4] = SeqNo(row["Seq_No"].ToString());
                _row[5] = row["Loc"].ToString();
                _row[6] = row["p_p_to"].ToString();
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
                _row[20] = row["test10"].ToString();
                _row[21] = row["test11"].ToString();
                _row[22] = row["Per_com1"].ToString();
                _row[23] = row["accept1"].ToString();
                _row[24] = row["filed1"].ToString();
                _row[25] = row["accept2"].ToString();
                _row[26] = row["test7"].ToString();
                _row[27] = row["Comm"].ToString();
                _row[28] = row["Act_by"].ToString();
                _row[29] = row["Act_date"].ToString();
                _row[30] = row["Per_com2"].ToString();
                _row[31] = row["Per_com3"].ToString();
                _row[32] = row["Per_com4"].ToString();
                _row[33] = row["Per_com5"].ToString();
                _row[34] = row["Per_com6"].ToString();
                _row[35] = row["filed2"].ToString();
                _row[36] = row["devices2"].ToString();
                _dtresult.Rows.Add(_row);
            }
            //m.DataSource = _dtresult;
            //mygrid.DataBind();
            Load_Details();
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
            _dtresult.Columns.Add("P_P_to", typeof(string));
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
            _dtresult.Columns.Add("test8", typeof(string));
            _dtresult.Columns.Add("test9", typeof(string));
            _dtresult.Columns.Add("tested1", typeof(string));
            _dtresult.Columns.Add("tested2", typeof(string));
            _dtresult.Columns.Add("Per_com1", typeof(string));
            _dtresult.Columns.Add("Accept1", typeof(string));
            _dtresult.Columns.Add("filed1", typeof(string));
            _dtresult.Columns.Add("Accept2", typeof(string));
            _dtresult.Columns.Add("test7", typeof(string));
            _dtresult.Columns.Add("Comm", typeof(string));
            _dtresult.Columns.Add("Act_by", typeof(string));
            _dtresult.Columns.Add("Act_date", typeof(string));
            _dtresult.Columns.Add("Per_com2", typeof(string));
            _dtresult.Columns.Add("Per_com3", typeof(string));
            _dtresult.Columns.Add("Per_com4", typeof(string));
            _dtresult.Columns.Add("Per_com5", typeof(string));
            _dtresult.Columns.Add("Per_com6", typeof(string));
            _dtresult.Columns.Add("Per_com7", typeof(string));
            var _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<decimal>("per_com1") == 0
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
                _row[6] = row["p_p_to"].ToString();
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
                _row[20] = row["test8"].ToString();
                _row[21] = row["test9"].ToString();
                _row[22] = row["tested1"].ToString();
                _row[23] = row["tested2"].ToString();
                _row[24] = row["Per_com1"].ToString();
                _row[25] = row["accept1"].ToString();
                _row[26] = row["filed1"].ToString();
                _row[27] = row["accept2"].ToString();
                _row[28] = row["test7"].ToString();
                _row[29] = row["Comm"].ToString();
                _row[30] = row["Act_by"].ToString();
                _row[31] = row["Act_date"].ToString();
                _row[32] = row["Per_com2"].ToString();
                _row[33] = row["Per_com3"].ToString();
                _row[34] = row["Per_com4"].ToString();
                _row[35] = row["Per_com5"].ToString();
                _row[36] = row["Per_com6"].ToString();
                _row[37] = row["Per_com7"].ToString();
                _dtresult.Rows.Add(_row);
            }
            //m.DataSource = _dtresult;
            //mygrid.DataBind();
            Load_Details();
            Generate_Summary();
        }
        static bool IsNumeric(object Expression)
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
                _dtsummary.Columns.Add("QTY1", typeof(string));
                _dtsummary.Columns.Add("TESTED1", typeof(string));
                _dtsummary.Columns.Add("QTY2", typeof(string));
                _dtsummary.Columns.Add("TESTED2", typeof(string));
                _dtsummary.Columns.Add("QTY3", typeof(string));
                _dtsummary.Columns.Add("TESTED3", typeof(string));
                _dtsummary.Columns.Add("QTY4", typeof(string));
                _dtsummary.Columns.Add("TESTED4", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("TESTED", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("T1", typeof(string));
                _dtsummary.Columns.Add("T2", typeof(string));
                _dtsummary.Columns.Add("T3", typeof(string));
                _dtsummary.Columns.Add("T4", typeof(string));
                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _p2 = 0;
                decimal _devices1 = 0;
                decimal _p3 = 0;
                decimal _devices2 = 0;
                decimal _p4 = 0;
                decimal _devices3 = 0;
                decimal _qty = 0;
                decimal _tested = 0;
                decimal _total = 0;
                decimal _count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                //var _result = "";
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _devices = 0;
                    _p1 = 0;
                    _devices1 = 0;
                    _p2 = 0;
                    _devices2 = 0;
                    _p3 = 0;
                    _devices3 = 0;
                    _p4 = 0;
                    _qty = 0;
                    _tested = 0;
                    int idx = 0;

                    if (row[0].ToString() == "Circuit IR / Continuity Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAD" || _data.Field<string>("Cat") == "FAM" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[12] = Decimal.Round(_p1).ToString();
                        if (_devices != 0)
                            _drow[2] = Decimal.Round((_p1 / _devices) * 100).ToString();
                        else
                            _drow[2] = 0;
                        _drow[3] = Decimal.Round(_devices1).ToString();
                        _drow[13] = Decimal.Round(_p2).ToString();
                        if (_devices1 != 0)
                            _drow[4] = Decimal.Round((_p2 / _devices1) * 100).ToString();
                        else
                            _drow[4] = 0;
                        _drow[5] = Decimal.Round(_devices2).ToString();
                        _drow[14] = Decimal.Round(_p3).ToString();
                        if (_devices2 != 0)
                            _drow[6] = Decimal.Round((_p3 / _devices2) * 100).ToString();
                        else
                            _drow[6] = 0;
                        _drow[7] = Decimal.Round(_devices3).ToString();
                        _drow[15] = Decimal.Round(_p4).ToString();
                        if (_devices3 != 0)
                            _drow[8] = Decimal.Round((_p4 / _devices3) * 100).ToString();
                        else
                            _drow[8] = 0;
                        _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;
                        _drow[9] = Decimal.Round(_qty).ToString();
                        _drow[10] = Decimal.Round(_tested).ToString();
                        //if (_qty != 0)
                        //    _drow[10] = Decimal.Round((_tested / _qty) * 100).ToString();
                        //else
                        //    _drow[10] = 0;
                    }
                    else if (row[0].ToString() == "FA Device Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAD"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[12] = Decimal.Round(_p1).ToString();
                        if (_devices != 0)
                            _drow[2] = Decimal.Round((_p1 / _devices) * 100).ToString();
                        else
                            _drow[2] = 0;
                        _drow[3] = Decimal.Round(_devices1).ToString();
                        _drow[13] = Decimal.Round(_p2).ToString();
                        if (_devices1 != 0)
                            _drow[4] = Decimal.Round((_p2 / _devices1) * 100).ToString();
                        else
                            _drow[4] = 0;
                        _drow[5] = Decimal.Round(_devices2).ToString();
                        _drow[14] = Decimal.Round(_p3).ToString();
                        if (_devices2 != 0)
                            _drow[6] = Decimal.Round((_p3 / _devices2) * 100).ToString();
                        else
                            _drow[6] = 0;
                        _drow[7] = Decimal.Round(_devices3).ToString();
                        _drow[15] = Decimal.Round(_p4).ToString();
                        if (_devices3 != 0)
                            _drow[8] = Decimal.Round((_p4 / _devices3) * 100).ToString();
                        else
                            _drow[8] = 0;
                        _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;
                        _drow[9] = Decimal.Round(_qty).ToString();
                        _drow[10] = Decimal.Round(_tested).ToString();
                    }
                    else if (row[0].ToString() == "FA Interface Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAM"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices1"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices1"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices1"].ToString());
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[12] = Decimal.Round(_p1).ToString();
                        if (_devices != 0)
                            _drow[2] = Decimal.Round((_p1 / _devices) * 100).ToString();
                        else
                            _drow[2] = 0;
                        _drow[3] = Decimal.Round(_devices1).ToString();
                        _drow[13] = Decimal.Round(_p2).ToString();
                        if (_devices1 != 0)
                            _drow[4] = Decimal.Round((_p2 / _devices1) * 100).ToString();
                        else
                            _drow[4] = 0;
                        _drow[5] = Decimal.Round(_devices2).ToString();
                        _drow[14] = Decimal.Round(_p3).ToString();
                        if (_devices2 != 0)
                            _drow[6] = Decimal.Round((_p3 / _devices2) * 100).ToString();
                        else
                            _drow[6] = 0;
                        _drow[7] = Decimal.Round(_devices3).ToString();
                        _drow[15] = Decimal.Round(_p4).ToString();
                        if (_devices3 != 0)
                            _drow[8] = Decimal.Round((_p4 / _devices3) * 100).ToString();
                        else
                            _drow[8] = 0;
                        _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;
                        _drow[9] = Decimal.Round(_qty).ToString();
                        _drow[10] = Decimal.Round(_tested).ToString();
                    }
                    else if (row[0].ToString() == "Voice Evac Speaker Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "ANN" || _data.Field<string>("Cat") == "FSC"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[12] = Decimal.Round(_p1).ToString();
                        if (_devices != 0)
                            _drow[2] = Decimal.Round((_p1 / _devices) * 100).ToString();
                        else
                            _drow[2] = 0;
                        _drow[3] = Decimal.Round(_devices1).ToString();
                        _drow[13] = Decimal.Round(_p2).ToString();
                        if (_devices1 != 0)
                            _drow[4] = Decimal.Round((_p2 / _devices1) * 100).ToString();
                        else
                            _drow[4] = 0;
                        _drow[5] = Decimal.Round(_devices2).ToString();
                        _drow[14] = Decimal.Round(_p3).ToString();
                        if (_devices2 != 0)
                            _drow[6] = Decimal.Round((_p3 / _devices2) * 100).ToString();
                        else
                            _drow[6] = 0;
                        _drow[7] = Decimal.Round(_devices3).ToString();
                        _drow[15] = Decimal.Round(_p4).ToString();
                        if (_devices3 != 0)
                            _drow[8] = Decimal.Round((_p4 / _devices3) * 100).ToString();
                        else
                            _drow[8] = 0;
                        _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;
                        _drow[9] = Decimal.Round(_qty).ToString();
                        _drow[10] = Decimal.Round(_tested).ToString();
                    }
                    else if (row[0].ToString() == "Fire Telephone Device Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FTL"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[12] = Decimal.Round(_p1).ToString();
                        if (_devices != 0)
                            _drow[2] = Decimal.Round((_p1 / _devices) * 100).ToString();
                        else
                            _drow[2] = 0;
                        _drow[3] = Decimal.Round(_devices1).ToString();
                        _drow[13] = Decimal.Round(_p2).ToString();
                        if (_devices1 != 0)
                            _drow[4] = Decimal.Round((_p2 / _devices1) * 100).ToString();
                        else
                            _drow[4] = 0;
                        _drow[5] = Decimal.Round(_devices2).ToString();
                        _drow[14] = Decimal.Round(_p3).ToString();
                        if (_devices2 != 0)
                            _drow[6] = Decimal.Round((_p3 / _devices2) * 100).ToString();
                        else
                            _drow[6] = 0;
                        _drow[7] = Decimal.Round(_devices3).ToString();
                        _drow[15] = Decimal.Round(_p4).ToString();
                        if (_devices3 != 0)
                            _drow[8] = Decimal.Round((_p4 / _devices3) * 100).ToString();
                        else
                            _drow[8] = 0;
                        _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;
                        _drow[9] = Decimal.Round(_qty).ToString();
                        _drow[10] = Decimal.Round(_tested).ToString();

                    }
                    else if (row[0].ToString() == "Battery Autonomy Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAD" || _data.Field<string>("Cat") == "FAM" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[12] = Decimal.Round(_p1).ToString();
                        if (_devices != 0)
                            _drow[2] = Decimal.Round((_p1 / _devices) * 100).ToString();
                        else
                            _drow[2] = 0;
                        _drow[3] = Decimal.Round(_devices1).ToString();
                        _drow[13] = Decimal.Round(_p2).ToString();
                        if (_devices1 != 0)
                            _drow[4] = Decimal.Round((_p2 / _devices1) * 100).ToString();
                        else
                            _drow[4] = 0;
                        _drow[5] = Decimal.Round(_devices2).ToString();
                        _drow[14] = Decimal.Round(_p3).ToString();
                        if (_devices2 != 0)
                            _drow[6] = Decimal.Round((_p3 / _devices2) * 100).ToString();
                        else
                            _drow[6] = 0;
                        _drow[7] = Decimal.Round(_devices3).ToString();
                        _drow[15] = Decimal.Round(_p4).ToString();
                        if (_devices3 != 0)
                            _drow[8] = Decimal.Round((_p4 / _devices3) * 100).ToString();
                        else
                            _drow[8] = 0;
                        _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;
                        _drow[9] = Decimal.Round(_qty).ToString();
                        _drow[10] = Decimal.Round(_tested).ToString();

                    }
                    else if (row[0].ToString() == "Graphic/ Head End Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAD"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com5"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com5"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com5"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[12] = Decimal.Round(_p1).ToString();
                        if (_devices != 0)
                            _drow[2] = Decimal.Round((_p1 / _devices) * 100).ToString();
                        else
                            _drow[2] = 0;
                        _drow[3] = Decimal.Round(_devices1).ToString();
                        _drow[13] = Decimal.Round(_p2).ToString();
                        if (_devices1 != 0)
                            _drow[4] = Decimal.Round((_p2 / _devices1) * 100).ToString();
                        else
                            _drow[4] = 0;
                        _drow[5] = Decimal.Round(_devices2).ToString();
                        _drow[14] = Decimal.Round(_p3).ToString();
                        if (_devices2 != 0)
                            _drow[6] = Decimal.Round((_p3 / _devices2) * 100).ToString();
                        else
                            _drow[6] = 0;
                        _drow[7] = Decimal.Round(_devices3).ToString();
                        _drow[15] = Decimal.Round(_p4).ToString();
                        if (_devices3 != 0)
                            _drow[8] = Decimal.Round((_p4 / _devices3) * 100).ToString();
                        else
                            _drow[8] = 0;
                        _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;
                        _drow[9] = Decimal.Round(_qty).ToString();
                        _drow[10] = Decimal.Round(_tested).ToString();
                    }
                    else
                    {
                        _drow[1] = "0";
                        _drow[2] = "0";
                        _drow[3] = "0";
                        _drow[4] = "0";
                        _drow[5] = "0";
                        _drow[6] = "0";
                        _drow[7] = "0";
                        _drow[8] = "0";
                        _drow[9] = "0";
                        _drow[10] = "0";
                    }
                    if (_qty != 0)
                    {
                        _total = Decimal.Round((_tested / _qty) * 100);
                    }
                    else
                        _total = 0;

                    _drow[11] = _total.ToString();
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
        private void Generate_Summary_()
        {
            try
            {
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PANEL", typeof(string));
                _dtsummary.Columns.Add("COLD", typeof(string));
                _dtsummary.Columns.Add("LIVE", typeof(string));
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
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pft
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//pwron
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//fpt
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());//arm
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
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    _total = Decimal.Round(((_per1 * 0.3m) + (_per2 * 0.5m) + (_per3 * 0.2m)), 2);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    if (_p7 != 0)
                        _per7 = Decimal.Round((_p7 / Convert.ToDecimal(count)), 2);
                    _total1 = Decimal.Round((((_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per7 * 0.25m)) * 100), 2);
                    decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_per1).ToString();
                    _drow[3] = Decimal.Round(_per2).ToString();
                    _drow[4] = Decimal.Round(_per3).ToString();
                    _drow[5] = Decimal.Round(_total).ToString();
                    _drow[6] = Decimal.Round(_p4).ToString();
                    _drow[7] = Decimal.Round(_p5).ToString();
                    _drow[8] = Decimal.Round(_p6).ToString();
                    _drow[9] = Decimal.Round(_p7).ToString();
                    _drow[10] = Decimal.Round(_total1).ToString();
                    _drow[11] = _overall.ToString();
                    _drow[12] = row.col3.ToString();
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
                _objcls.qty1 = Convert.ToDecimal(row["QTY1"].ToString());
                _objcls.testd1 = Convert.ToDecimal(row["T1"].ToString());
                _objcls.qty2 = Convert.ToDecimal(row["QTY2"].ToString());
                _objcls.testd2 = Convert.ToDecimal(row["T2"].ToString());
                _objcls.qty3 = Convert.ToDecimal(row["QTY3"].ToString());
                _objcls.testd3 = Convert.ToDecimal(row["T3"].ToString());
                _objcls.qty4 = Convert.ToInt32(row["QTY4"].ToString());
                _objcls.testd4 = Convert.ToInt32(row["T4"].ToString());
                _objcls.quaty = Convert.ToInt32(row["QTY"].ToString());
                _objcls.testd = Convert.ToInt32(row["TESTED"].ToString());
                _objcls.total = Convert.ToDecimal(row["TOTAL"].ToString());
                _objbll.Generate_CASSummary_PKG_RPT_CCAD_FAS(_objcls, _objdb);
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
            for (int i = 0; i <= reptr_main.Items.Count - 1; i++)
            {
                GridView _mydetails = (GridView)reptr_main.Items[i].FindControl("details");
                Button _btn = (Button)reptr_main.Items[i].FindControl("btnexpd");
                _mydetails.Visible = true;
                _btn.Text = "-";
            }
        }

        protected void btncollapse_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= reptr_main.Items.Count - 1; i++)
            {
                GridView _mydetails = (GridView)reptr_main.Items[i].FindControl("details");
                Button _btn = (Button)reptr_main.Items[i].FindControl("btnexpd");
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
        }
        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["sch_id"] = 10;
            e.InputParameters["prj_code"] = lblprj.Text;
        }

        protected void reptr_main_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Label _panel_id = (Label)e.Item.FindControl("lbl_panelPid");
                DataTable _dtable = new DataTable();
                _dtable.Columns.Add("Panel_Id", typeof(string));
                _dtable.Columns.Add("Panel_Ref", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    where dRow["Panel_Id"].ToString() == _panel_id.Text
                                    select new { col1 = dRow["Panel_Id"], col2 = dRow["Panel_Ref"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    DataRow _row = _dtable.NewRow();
                    _row[0] = row.col1.ToString();
                    _row[1] = row.col2.ToString();
                    _dtable.Rows.Add(_row);
                }
                GridView _mydetails = (GridView)e.Item.FindControl("details");
                _mydetails.DataSource = _dtable;
                _mydetails.DataBind();
                //Button _btn = (Button)e.Row.FindControl("Button1");
                //_btn.Text = "+";
                _mydetails.Visible = false;
            }

        }

        protected DataTable Getinner1(int panel_id)
        {
            //Label _lb = (Label)reptr_main.FindControl("lbl_panelPid");
            DataTable _dtdetails = new DataTable();
            _dtdetails.Columns.Add("e_b_ref", typeof(string));
            _dtdetails.Columns.Add("B_Z", typeof(string));
            _dtdetails.Columns.Add("Cat", typeof(string));
            _dtdetails.Columns.Add("F_lvl", typeof(string));
            _dtdetails.Columns.Add("Seq_No", typeof(string));
            _dtdetails.Columns.Add("Loc", typeof(string));
            _dtdetails.Columns.Add("P_P_to", typeof(string));
            _dtdetails.Columns.Add("F_from", typeof(string));
            _dtdetails.Columns.Add("Substation", typeof(string));
            _dtdetails.Columns.Add("devices1", typeof(string));
            _dtdetails.Columns.Add("C_id", typeof(int));
            _dtdetails.Columns.Add("Sys_name", typeof(string));
            _dtdetails.Columns.Add("Sys_id", typeof(int));
            _dtdetails.Columns.Add("Des", typeof(string));
            var _details = from _data in _dtresult.AsEnumerable()
                           where _data.Field<int>("Panel_Id") == panel_id
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
                _row[6] = row["p_p_to"].ToString();
                _row[7] = row["F_from"].ToString();
                _row[8] = row["Substation"].ToString();
                _row[9] = row["devices1"].ToString();
                _row[10] = row["C_id"].ToString();
                _row[11] = row["Sys_name"].ToString();
                _row[12] = row["Sys_id"].ToString();
                _row[13] = row["Des"].ToString();
                _dtdetails.Rows.Add(_row);
            }
            return _dtdetails;
        }

        protected void reptr_main_DataBinding(object sender, EventArgs e)
        {

        }
        protected void details_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _panel_id = (Label)e.Row.FindControl("lblpanel");
                DataTable _dtdetails = new DataTable();
                _dtdetails.Columns.Add("e_b_ref", typeof(string));
                _dtdetails.Columns.Add("B_Z", typeof(string));
                _dtdetails.Columns.Add("Cat", typeof(string));
                _dtdetails.Columns.Add("F_lvl", typeof(string));
                _dtdetails.Columns.Add("Seq_No", typeof(string));
                _dtdetails.Columns.Add("Loc", typeof(string));
                _dtdetails.Columns.Add("P_P_to", typeof(string));
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
                _dtdetails.Columns.Add("test10", typeof(string));
                _dtdetails.Columns.Add("test11", typeof(string));
                _dtdetails.Columns.Add("Per_com1", typeof(string));
                _dtdetails.Columns.Add("Accept1", typeof(string));
                _dtdetails.Columns.Add("filed1", typeof(string));
                _dtdetails.Columns.Add("Accept2", typeof(string));
                _dtdetails.Columns.Add("test7", typeof(string));
                _dtdetails.Columns.Add("Comm", typeof(string));
                _dtdetails.Columns.Add("Act_by", typeof(string));
                _dtdetails.Columns.Add("Act_date", typeof(string));
                _dtdetails.Columns.Add("Per_com2", typeof(string));
                _dtdetails.Columns.Add("Per_com3", typeof(string));
                _dtdetails.Columns.Add("Per_com4", typeof(string));
                _dtdetails.Columns.Add("Per_com5", typeof(string));
                _dtdetails.Columns.Add("Per_com6", typeof(string));
                _dtdetails.Columns.Add("filed2", typeof(string));
                _dtdetails.Columns.Add("devices2", typeof(string));
                var _details1 = from _data in _dtresult.AsEnumerable()
                                where _data.Field<int>("Panel_Id") == Convert.ToInt32(_panel_id.Text)
                                select _data;
                foreach (var row in _details1)
                {
                    DataRow _row = _dtdetails.NewRow();
                    _row[0] = row["e_b_ref"].ToString();
                    _row[1] = row["B_Z"].ToString();
                    _row[2] = row["Cat"].ToString();
                    _row[3] = row["F_lvl"].ToString();
                    _row[4] = SeqNo(row["Seq_No"].ToString());
                    _row[5] = row["Loc"].ToString();
                    _row[6] = row["p_p_to"].ToString();
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
                    _row[20] = row["test10"].ToString();
                    _row[21] = row["test11"].ToString();
                    _row[22] = row["Per_com1"].ToString();
                    _row[23] = row["accept1"].ToString();
                    _row[24] = row["filed1"].ToString();
                    _row[25] = row["accept2"].ToString();
                    _row[26] = row["test7"].ToString();
                    _row[27] = row["Comm"].ToString();
                    _row[28] = row["Act_by"].ToString();
                    _row[29] = row["Act_date"].ToString();
                    _row[30] = row["Per_com2"].ToString();
                    _row[31] = row["Per_com3"].ToString();
                    _row[32] = row["Per_com4"].ToString();
                    _row[33] = row["Per_com5"].ToString();
                    _row[34] = row["Per_com6"].ToString();
                    _row[35] = row["filed2"].ToString();
                    _row[36] = row["devices2"].ToString();
                    _dtdetails.Rows.Add(_row);
                }
                GridView _mydetails1 = (GridView)e.Row.FindControl("inner1");
                _mydetails1.DataSource = _dtdetails;
                _mydetails1.DataBind();
                //Button _btn = (Button)e.Row.FindControl("Button1");
                //_btn.Text = "+";
                //_mydetails.Visible = false;
                DataTable _dtable = new DataTable();
                _dtable.Columns.Add("Panel_Id", typeof(string));
                _dtable.Columns.Add("Panel_Ref", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    where dRow["Panel_Parent"].ToString() == _panel_id.Text
                                    select new { col1 = dRow["Panel_Id"], col2 = dRow["Panel_Ref"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    DataRow _row = _dtable.NewRow();
                    _row[0] = row.col1.ToString();
                    _row[1] = row.col2.ToString();
                    _dtable.Rows.Add(_row);
                }
                GridView _mydetails2 = (GridView)e.Row.FindControl("inner_sub");
                _mydetails2.DataSource = _dtable;
                _mydetails2.DataBind();
            }
        }
        protected void inner_sub_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _panel_id = (Label)e.Row.FindControl("lbl_panelCid");
                DataTable _dtdetails = new DataTable();
                _dtdetails.Columns.Add("e_b_ref", typeof(string));
                _dtdetails.Columns.Add("B_Z", typeof(string));
                _dtdetails.Columns.Add("Cat", typeof(string));
                _dtdetails.Columns.Add("F_lvl", typeof(string));
                _dtdetails.Columns.Add("Seq_No", typeof(string));
                _dtdetails.Columns.Add("Loc", typeof(string));
                _dtdetails.Columns.Add("P_P_to", typeof(string));
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
                _dtdetails.Columns.Add("test10", typeof(string));
                _dtdetails.Columns.Add("test11", typeof(string));
                _dtdetails.Columns.Add("Per_com1", typeof(string));
                _dtdetails.Columns.Add("Accept1", typeof(string));
                _dtdetails.Columns.Add("filed1", typeof(string));
                _dtdetails.Columns.Add("Accept2", typeof(string));
                _dtdetails.Columns.Add("test7", typeof(string));
                _dtdetails.Columns.Add("Comm", typeof(string));
                _dtdetails.Columns.Add("Act_by", typeof(string));
                _dtdetails.Columns.Add("Act_date", typeof(string));
                _dtdetails.Columns.Add("Per_com2", typeof(string));
                _dtdetails.Columns.Add("Per_com3", typeof(string));
                _dtdetails.Columns.Add("Per_com4", typeof(string));
                _dtdetails.Columns.Add("Per_com5", typeof(string));
                _dtdetails.Columns.Add("Per_com6", typeof(string));
                _dtdetails.Columns.Add("filed2", typeof(string));
                _dtdetails.Columns.Add("devices2", typeof(string));
                var _details1 = from _data in _dtresult.AsEnumerable()
                                where _data.Field<int>("Panel_Id") == Convert.ToInt32(_panel_id.Text)
                                select _data;
                foreach (var row in _details1)
                {
                    DataRow _row = _dtdetails.NewRow();
                    _row[0] = row["e_b_ref"].ToString();
                    _row[1] = row["B_Z"].ToString();
                    _row[2] = row["Cat"].ToString();
                    _row[3] = row["F_lvl"].ToString();
                    _row[4] = SeqNo(row["Seq_No"].ToString());
                    _row[5] = row["Loc"].ToString();
                    _row[6] = row["p_p_to"].ToString();
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
                    _row[20] = row["test10"].ToString();
                    _row[21] = row["test11"].ToString();
                    _row[22] = row["Per_com1"].ToString();
                    _row[23] = row["accept1"].ToString();
                    _row[24] = row["filed1"].ToString();
                    _row[25] = row["accept2"].ToString();
                    _row[26] = row["test7"].ToString();
                    _row[27] = row["Comm"].ToString();
                    _row[28] = row["Act_by"].ToString();
                    _row[29] = row["Act_date"].ToString();
                    _row[30] = row["Per_com2"].ToString();
                    _row[31] = row["Per_com3"].ToString();
                    _row[32] = row["Per_com4"].ToString();
                    _row[33] = row["Per_com5"].ToString();
                    _row[34] = row["Per_com6"].ToString();
                    _row[35] = row["filed2"].ToString();
                    _row[36] = row["devices2"].ToString();
                    _dtdetails.Rows.Add(_row);
                }
                GridView _mydetails1 = (GridView)e.Row.FindControl("inner2");
                _mydetails1.DataSource = _dtdetails;
                _mydetails1.DataBind();

            }
        }

       

    }
}
