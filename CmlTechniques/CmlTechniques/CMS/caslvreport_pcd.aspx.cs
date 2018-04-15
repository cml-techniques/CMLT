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

namespace CmlTechniques.CMS
{   
    public partial class caslvreport_pcd : System.Web.UI.Page
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


                weighting.Visible = false;
                Generate_Summary();

                Head_Merging();
                _exp = false;

                if (lblprj.Text == "AFV") Set_Title();

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
        private void Load_Master()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = 5;
            _objcas.prj_code = lblprj.Text;
            if (lblprj.Text == "AFV")
                _objcas.sys = Convert.ToInt32(Request.QueryString["div"].ToString());
            else
                _objcas.sys = 0;
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
                _dtresult = _dtMaster;
            _summary = _dtresult;
            _dtfilter = _dtresult;
        }
        private void Set_Title()
        {
            string _buildingName = "";
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.sch = Convert.ToInt32(Request.QueryString["div"].ToString());
            _buildingName = _objbll.Get_Building_Name(_objcls, _objdb);

            lblhead.Text = _buildingName + " - " + lblhead.Text;

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

        }
        private void Head_Merging()
        {
            info1.AddMergedColumns(new int[] { 3, 4, 5 }, "Panel  Testing");
            info1.AddMergedColumns(new int[] { 6, 7,8 }, "Cold Cable Testing");
            info1.AddMergedColumns(new int[] { 9, 10,11 }, "Live Cable Testing");
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
                        output.Write(string.Format("<th align='center' style='font-weight:normal' colspan='{0}'>{2}</th>",
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



        decimal _qtyp = 0;
        decimal _qtyp1 = 0;
        decimal _qtyp2 = 0;



        decimal _tested = 0;
        decimal _tested1 = 0;
        decimal _tested2 = 0;

        decimal _count = 0;
        int _q1 = 0; int _q2 = 0; int _q3 = 0;

        decimal _calc = 0;
        decimal _calcPer = 0;
        protected void mygridsumm_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[16].Visible = false;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
                _qty += Convert.ToDecimal(e.Row.Cells[2].Text);

                if (e.Row.Cells[5].Text != "-1")
                {
                    _qtyp += Convert.ToDecimal(e.Row.Cells[3].Text);
                    _tested += Convert.ToDecimal(e.Row.Cells[5].Text);

                    e.Row.Cells[4].Text = e.Row.Cells[4].Text + "%";
                    e.Row.Cells[5].Text = e.Row.Cells[5].Text + "%";

                    _qty1 += Convert.ToDecimal(e.Row.Cells[2].Text);
                }
                else
                {
                    e.Row.Cells[3].Text="N/A";
                    e.Row.Cells[4].Text = "N/A";
                    e.Row.Cells[5].Text = "N/A";
                    _q1 += 1;
                }

                if (e.Row.Cells[8].Text != "-1")
                {

                    _qtyp1 += Convert.ToDecimal(e.Row.Cells[6].Text);
                    _tested1 += Convert.ToDecimal(e.Row.Cells[8].Text);

                    e.Row.Cells[7].Text = e.Row.Cells[7].Text + "%";
                    e.Row.Cells[8].Text = e.Row.Cells[8].Text + "%";

                    _qty2 += Convert.ToDecimal(e.Row.Cells[16].Text);

                }
                else
                {
                    e.Row.Cells[6].Text = "N/A";
                    e.Row.Cells[7].Text = "N/A";
                    e.Row.Cells[8].Text = "N/A";
                    _q2 += 1;
                }

                if (e.Row.Cells[11].Text != "-1")
                {

                    _qtyp2 += Convert.ToDecimal(e.Row.Cells[9].Text);
                    _tested2 += Convert.ToDecimal(e.Row.Cells[11].Text);

                    e.Row.Cells[10].Text = e.Row.Cells[10].Text + "%";
                    e.Row.Cells[11].Text = e.Row.Cells[11].Text + "%";

                    _qty3 += Convert.ToDecimal(e.Row.Cells[16].Text);
                }
                else
                {
                    e.Row.Cells[9].Text = "N/A";
                    e.Row.Cells[10].Text = "N/A";
                    e.Row.Cells[11].Text = "N/A";
                    _q3 += 1;
                }



                _calcPer += ((Convert.ToDecimal(e.Row.Cells[2].Text) * Convert.ToDecimal(e.Row.Cells[14].Text)) / 100);
                _calc += ((Convert.ToDecimal(e.Row.Cells[2].Text) * Convert.ToDecimal(e.Row.Cells[15].Text))/100);
              
              
                e.Row.Cells[12].Text = ((Convert.ToDecimal(e.Row.Cells[2].Text) * Convert.ToDecimal(e.Row.Cells[14].Text))/100).ToString();
                e.Row.Cells[13].Text = ((Convert.ToDecimal(e.Row.Cells[2].Text) * Convert.ToDecimal(e.Row.Cells[15].Text))/100).ToString();

                e.Row.Cells[14].Text = e.Row.Cells[14].Text + "%";
                e.Row.Cells[15].Text = e.Row.Cells[15].Text + "%";

                _count += 1;

              
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                decimal _p1 = 0;decimal _p2 = 0;  decimal _p3 = 0; decimal _p_p1 = 0; decimal _p_p2 = 0; decimal _p_p3 = 0;
                decimal _percom1 = 0; decimal _percom2 = 0;decimal _percom3 = 0; decimal _p_percom1 = 0; decimal _p_percom2 = 0; decimal _p_percom3 = 0;
                decimal _count1 = 0;  decimal _count2 = 0;decimal _count3 = 0;

                DateTime defaultvalue = DateTime.ParseExact("01/01/2099", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var row in _result)
                {
                    var todaysDate = DateTime.Today;
                    if (!string.IsNullOrEmpty(hdnpcd.Value))
                    {
                        todaysDate = DateTime.ParseExact(hdnpcd.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                    }

                    if (Convert.ToDecimal(row["per_com1"].ToString()) != -1)
                    {
                        _p1 += Convert.ToDecimal(row["per_com1"].ToString());
                        _count1 += 1;
                    }
                    if (Convert.ToDecimal(row["per_com2"].ToString()) != -1)
                    {
                        _p2 += Convert.ToDecimal(row["per_com2"].ToString());


                        if (IsNumeric(row["devices1"].ToString()) == true)
                            _count2 += Convert.ToInt32(row["devices1"].ToString());

                    }

                    if (Convert.ToDecimal(row["per_com3"].ToString()) != -1)
                    {
                        _p3 += Convert.ToDecimal(row["per_com3"].ToString());


                        if (IsNumeric(row["devices1"].ToString()) == true)
                            _count3 += Convert.ToInt32(row["devices1"].ToString());

                    }

                    if (row["pcdate"] != null && row["pcdate"].ToString() != "")
                    {
                        var pcdate = DateTime.ParseExact(row["pcdate"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                        if (pcdate <= todaysDate) _p_p1 += 1;
                        pcdate = defaultvalue;
                    }
                    if (row["pcdate1"] != null && row["pcdate1"].ToString() != "")
                    {
                        var pcdate1 = DateTime.ParseExact(row["pcdate1"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        if (pcdate1 <= todaysDate) _p_p2 += Convert.ToDecimal(row["devices1"]);
                        pcdate1 = defaultvalue;
                    }
                    if (row["pcdate2"] != null && row["pcdate2"].ToString() != "")
                    {
                        var pcdate2 = DateTime.ParseExact(row["pcdate2"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        if (pcdate2 <= todaysDate) _p_p3 += Convert.ToDecimal(row["devices1"]);
                        pcdate2 = defaultvalue;

                    }


                }
                if (_count1 > 0)
                {
                    _percom1 = Decimal.Round((_p1 / _count1), MidpointRounding.AwayFromZero);
                    _p_percom1 = Decimal.Round(((_p_p1 / _count1)*100), MidpointRounding.AwayFromZero);
                }
                if (_count2 > 0)
                {
                    _percom2 = Decimal.Round((_p2 / _count2) * 100, MidpointRounding.AwayFromZero);
                    _p_percom2 = Decimal.Round((_p_p2 / _count2) * 100, MidpointRounding.AwayFromZero);
                }
                if (_count3 > 0)
                {
                    _percom3 = Decimal.Round((_p3 / _count3) * 100, MidpointRounding.AwayFromZero);
                    _p_percom3 = Decimal.Round((_p_p3 / _count3) * 100, MidpointRounding.AwayFromZero);
                }


                e.Row.Cells[1].Text = "TOTALS";
                e.Row.Cells[2].Text = _qty.ToString();


                e.Row.Cells[3].Text = _qtyp.ToString();
                e.Row.Cells[4].Text = Decimal.Round(_p_percom1, 0, MidpointRounding.AwayFromZero).ToString() + '%';
                e.Row.Cells[5].Text = Decimal.Round(_percom1, 0, MidpointRounding.AwayFromZero).ToString() + '%';

                e.Row.Cells[6].Text = _qtyp1.ToString();
                e.Row.Cells[7].Text = Decimal.Round(_p_percom2, 0, MidpointRounding.AwayFromZero).ToString() + '%';
                e.Row.Cells[8].Text = Decimal.Round(_percom2, 0, MidpointRounding.AwayFromZero).ToString() + '%';


                e.Row.Cells[9].Text = _qtyp2.ToString();
                e.Row.Cells[10].Text = Decimal.Round(_p_percom3, 0, MidpointRounding.AwayFromZero).ToString() + '%';
                e.Row.Cells[11].Text = Decimal.Round(_percom3, 0, MidpointRounding.AwayFromZero).ToString() + '%';


                e.Row.Cells[12].Text = _calcPer.ToString();
                e.Row.Cells[13].Text = _calc.ToString();

                if(_qty > 0)
                {
                    e.Row.Cells[14].Text = Decimal.Round((_calcPer / _qty) * 100, MidpointRounding.AwayFromZero).ToString() + "%";
                    e.Row.Cells[15].Text = Decimal.Round((_calc / _qty) * 100, MidpointRounding.AwayFromZero).ToString() + "%";
                }
                else
                {
                    e.Row.Cells[14].Text = "0%";
                    e.Row.Cells[15].Text = "0%";
                }


                Session["Sum_QtyPlanned1"] = _qtyp.ToString();
                Session["Sum_QtyPlanned2"] = _qtyp1.ToString();
                Session["Sum_QtyPlanned3"] = _qtyp2.ToString();

                Session["Sum_PerPlanned1"] = _p_percom1.ToString() +'%';
                Session["Sum_PerPlanned2"] = _p_percom2.ToString() + '%';
                Session["Sum_PerPlanned3"] = _p_percom3.ToString() + '%';

                Session["Sum_Percom1"] = _percom1.ToString() + '%';
                Session["Sum_Percom2"] = _percom2.ToString() +'%';
                Session["Sum_Percom3"] = _percom3.ToString() +'%';

                Session["Sum_Poverall"] =  e.Row.Cells[14].Text;
                Session["Sum_Overall"] = e.Row.Cells[15].Text;

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
            //Session["zone"] = drbuilding.SelectedItem.Value;
            //Session["flvl"] = drflevel.SelectedItem.Value;
            //Session["cat"] = drcategory.SelectedItem.Value;
            //Session["fed"] = drfed.SelectedItem.Value;
            Insert_Summary();
            //string _path = "Cas_Report.aspx?id=5_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value + "_Z" + (string)Session["zero"];
            string _path = "Cas_Report.aspx?id=5_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value + "_Z" + (string)Session["zero"] + "&Div=" + lbldiv.Text;
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
        }
        protected void mydetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
            e.Row.Cells[5].Text = SeqNo(e.Row.Cells[5].Text);

            e.Row.Cells[32].Visible=false;
            e.Row.Cells[33].Visible = false;
            e.Row.Cells[34].Visible = false;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Cells[7].Attributes.Add("style", "word-wrap:break-word;word-break:break-all");
                e.Row.Cells[8].Attributes.Add("style", "word-wrap:break-word;word-break:break-all");
                e.Row.Cells[9].Attributes.Add("style", "word-wrap:break-word;word-break:break-all");
                e.Row.Cells[10].Attributes.Add("style", "word-wrap:break-word;word-break:break-all");
                Label _lbl = (Label)e.Row.FindControl("Label1");
                if (_lbl.Text == "0.00%")
                    _lbl.Text = "";
                else if (_lbl.Text == "-1%")
                    _lbl.Text = "N/A";

                if (e.Row.Cells[32].Text == "-1") { e.Row.Cells[10].Text = "N/A"; }
                if (e.Row.Cells[33].Text == "-1") { e.Row.Cells[21].Text = "N/A"; }
                if (e.Row.Cells[34].Text == "-1") { e.Row.Cells[24].Text = "N/A"; }
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

            Generate_Summary();
        }
        private void Filtering_zero()
        {
            Load_Master();
            var _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<decimal>("per_com1") == 0 && o.Field<string>("tested1") == "0" && o.Field<string>("tested2") == "0"
                          select o;
            _dtresult = _filter.Any() ? _filter.CopyToDataTable() : _dtMaster.Clone();
            Load_Details();
            Generate_Summary();
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
                _dtsummary.Columns.Add("PANEL", typeof(string));
                _dtsummary.Columns.Add("TotalNos", typeof(string));


                var todaysDate = DateTime.Today;
                if (!string.IsNullOrEmpty(hdnpcd.Value))
                {
                    todaysDate = DateTime.ParseExact(hdnpcd.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                }


                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    orderby dRow["possition"]
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    decimal _Ptotal = 0;
                    int count = 0;
                    int _na1 = 0;
                    int _na2 = 0;

                    decimal _p_p_qty = 0;
                    decimal _p1_p_qty = 0;
                    decimal _p2_p_qty = 0;      


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
                        //else If (_row["tested1"]="N/A"

                        if (_row["tested2"] != null && _row["tested2"].ToString() != "" && IsNumeric(_row["tested2"].ToString()))
                        {
                            liveTestCount += Convert.ToInt32(_row["tested2"]);
                        }

                        if (_row["devices1"] != null && _row["devices1"].ToString() != "")
                        {
                            circuitCount += Convert.ToInt32(_row["devices1"]);
                        }
                        //END

                         
                       if (_row["pcdate"] != null && _row["pcdate"].ToString() != "")
                        {
                            var pcdate = DateTime.ParseExact(_row["pcdate"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                            if (pcdate <= todaysDate) _p_p_qty += 1;
                        }
                       if (_row["pcdate1"] != null && _row["pcdate1"].ToString() != "")
                        {
                            var pcdate1 = DateTime.ParseExact(_row["pcdate1"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            if (pcdate1 <= todaysDate) _p1_p_qty += Convert.ToDecimal(_row["devices1"]);
                        }
                       if (_row["pcdate2"] != null && _row["pcdate2"].ToString() != "")
                        {
                            var pcdate2 = DateTime.ParseExact(_row["pcdate2"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            if (pcdate2 <= todaysDate) _p2_p_qty += Convert.ToDecimal(_row["devices1"]);
                        }



                    }
                    if (_na1 == count)
                        _na1 = -1;
                    if (_na2 == count)
                        _na2 = -1;


                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;

                    if (count != 0)
                    {
                        _per1 = (_p1 / Convert.ToDecimal(count));

                        if (_na1 == -1)
                            _per2 = -1;
                        else
                            if (coldTestCount != 0 && circuitCount != 0){ _per2 = ((coldTestCount * 100) / Convert.ToDecimal(circuitCount)); }

                        if (_na2 == -1)
                            _per3 = -1;
                        else
                            if (liveTestCount != 0 && circuitCount != 0){_per3 = ((liveTestCount * 100) / Convert.ToDecimal(circuitCount));}
                    }



                    decimal _PlannedPer1 = 0;
                    if ((_per1 != -1 )&& (count>0)) _PlannedPer1 = decimal.Round((_p_p_qty / count) * 100, MidpointRounding.AwayFromZero);
                    decimal _PlannedPer2 = 0;
                    if ((_per2 != -1) && (circuitCount > 0)) _PlannedPer2 = decimal.Round((_p1_p_qty / circuitCount) * 100, MidpointRounding.AwayFromZero);
                    decimal _PlannedPer3 = 0;
                    if ((_per3 != -1) && (circuitCount > 0)) _PlannedPer3 = decimal.Round((_p2_p_qty / circuitCount) * 100, MidpointRounding.AwayFromZero);

                        _total = 0;


                        if (_per1 != -1 && _per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(_per1 , MidpointRounding.AwayFromZero);
                            _Ptotal = Decimal.Round(_PlannedPer1, MidpointRounding.AwayFromZero);
                        }
                        else if (_per1 == -1 && _per2 != -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(_per2, MidpointRounding.AwayFromZero);
                            _Ptotal = Decimal.Round(_PlannedPer2, MidpointRounding.AwayFromZero);
                        }
                        else if (_per1 == -1 && _per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(_per3, MidpointRounding.AwayFromZero);
                            _Ptotal = Decimal.Round(_PlannedPer3, MidpointRounding.AwayFromZero);
                        }

                    if (lblprj.Text != "ARSD")
                    {
                        if (_per1 != -1 && _per2 != -1 && _per3 == -1)
                        {
                            _total = Decimal.Round((_per1 * 0.8m) + (_per2 * 0.2m), MidpointRounding.AwayFromZero);
                            _Ptotal = Decimal.Round((_PlannedPer1 * 0.8m) + (_PlannedPer2 * 0.2m), MidpointRounding.AwayFromZero);
                        }
                        else if (_per1 != -1 && _per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round((_per1 * 0.8m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                            _Ptotal = Decimal.Round((_PlannedPer1 * 0.8m) + (_PlannedPer3 * 0.2m), MidpointRounding.AwayFromZero);
                        }
                        else if (_per1 == -1 && _per2 != -1 && _per3 != -1)
                        {
                            _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                            _Ptotal = Decimal.Round((_PlannedPer2 * 0.6m) + (_PlannedPer3 * 0.4m), MidpointRounding.AwayFromZero);
                        }
                        else if (_per1 != -1 && _per2 != -1 && _per3 != -1)
                        {
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                            _Ptotal = Decimal.Round((_PlannedPer1 * 0.5m) + (_PlannedPer2 * 0.3m) + (_PlannedPer3 * 0.2m), MidpointRounding.AwayFromZero);
                        }
                    }
                    else
                    {
                        if (_per1 != -1 && _per2 != -1 && _per3 == -1)
                        {
                            _total = Decimal.Round((_per1 * 0.40m) + (_per2 * 0.60m), MidpointRounding.AwayFromZero);
                            _Ptotal = Decimal.Round((_PlannedPer1 * 0.40m) + (_PlannedPer2 * 0.60m), MidpointRounding.AwayFromZero);
                        }
                        else if (_per1 != -1 && _per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round((_per1 * 0.35m) + (_per3 * 0.65m), MidpointRounding.AwayFromZero);
                            _Ptotal = Decimal.Round((_PlannedPer1 * 0.35m) + (_PlannedPer3 * 0.65m), MidpointRounding.AwayFromZero);
                        }
                        else if (_per1 == -1 && _per2 != -1 && _per3 != -1)
                        {
                            _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                            _Ptotal = Decimal.Round((_PlannedPer2 * 0.6m) + (_PlannedPer3 * 0.4m), MidpointRounding.AwayFromZero);
                        }
                        else if (_per1 != -1 && _per2 != -1 && _per3 != -1)
                        {
                            _total = Decimal.Round((_per1 * 0.20m) + (_per2 * 0.45m) + (_per3 * 0.35m), MidpointRounding.AwayFromZero);
                            _Ptotal = Decimal.Round((_PlannedPer1 * 0.20m) + (_PlannedPer2 * 0.45m) + (_PlannedPer3 * 0.35m), MidpointRounding.AwayFromZero);
                        }

                    }


                  
                    if (_total < 0) _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow["SYS_NAME"] = row.col2.ToString();
                    _drow["QTY"] = count.ToString();
                    _drow["QTY_PER_COMPLETED"] = _p_p_qty.ToString();
                    _drow["PPERCENTAGE_PER_COMPLETED"] = decimal.Round(_PlannedPer1, MidpointRounding.AwayFromZero).ToString();
                    _drow["PER_COMPLETED"] = decimal.Round(_per1, MidpointRounding.AwayFromZero).ToString();
                    _drow["QTY_PER_COMPLETED1"] = _p1_p_qty.ToString();
                    _drow["PPERCENTAGE_PER_COMPLETED1"] = decimal.Round(_PlannedPer2, MidpointRounding.AwayFromZero).ToString();
                    _drow["PER_COMPLETED1"] = decimal.Round(_per2, MidpointRounding.AwayFromZero).ToString();
                    _drow["QTY_PER_COMPLETED2"] = _p2_p_qty.ToString();
                    _drow["PPERCENTAGE_PER_COMPLETED2"] = decimal.Round(_PlannedPer3, MidpointRounding.AwayFromZero).ToString();
                    _drow["PER_COMPLETED2"] = decimal.Round(_per3, MidpointRounding.AwayFromZero).ToString();
                    _drow["TOTAL"] = _total.ToString();
                    _drow["PLANNED_TOTAL"] = _Ptotal.ToString();
                    
                    _drow["CODE"] = row.col3.ToString();
                    _drow["PANEL"] = "0";

                    _drow["TotalNos"] = circuitCount.ToString();

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
                _objcls.quantity = Convert.ToInt32(row["QTY"].ToString());

                _objcls.qty = row["PPERCENTAGE_PER_COMPLETED"].ToString();
                _objcls.cate = row["PPERCENTAGE_PER_COMPLETED1"].ToString();
                _objcls.compl4 = Convert.ToInt32(row["QTY_PER_COMPLETED2"].ToString());

                _objcls.compl1 = Convert.ToInt32(row["QTY_PER_COMPLETED"].ToString());
                _objcls.compl2 = Convert.ToInt32(row["QTY_PER_COMPLETED1"].ToString());
                _objcls.compl3 = Convert.ToInt32(row["QTY_PER_COMPLETED2"].ToString());

                _objcls.per_com1 = Convert.ToDecimal(row["PER_COMPLETED"].ToString());
                _objcls.per_com2 = Convert.ToDecimal(row["PER_COMPLETED1"].ToString());
                _objcls.per_com3 = Convert.ToDecimal(row["PER_COMPLETED2"].ToString());

                _objcls.per_com4 = Convert.ToDecimal(row["PLANNED_TOTAL"].ToString());
                _objcls.total = Convert.ToDecimal(row["TOTAL"].ToString());


                _objbll.Generate_CASSummary_PKG_RPT_ASAO(_objcls, _objdb);



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
            drbuilding.SelectedValue = (string)Session["zone"];
            drcategory.SelectedValue = (string)Session["cat"];
            drflevel.SelectedValue = (string)Session["flvl"];
            drfed.SelectedValue = (string)Session["fed"];
            drloc.SelectedValue = (string)Session["loc"];
            drprogress.SelectedValue = (string)Session["pro"];
            Hide_Details();
            Generate_Summary();
        }

        protected void genPcd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdnpcd.Value))Generate_Summary();
                     
        }
    }
}
