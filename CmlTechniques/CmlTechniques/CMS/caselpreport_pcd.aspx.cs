using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using BusinessLogic;
using App_Properties;
using System.Data;

namespace CmlTechniques.CMS
{
    public partial class caselpreport_pcd : System.Web.UI.Page  
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
                Session["zero"] = "1";
                Load_Details();
                Hide_Details();

                Head_Merging();

                if (lblprj.Text == "ARSD") Generate_Summary(0.3m, 0.7m);
                else Generate_Summary(0.5m, 0.5m);

                _exp = false;

                if (lblprj.Text == "AFV") Set_Title();
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
                         orderby dRow["P_P_to"]
                         select new { col1 = dRow["P_P_to"] }).Distinct();
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
            _objcas.sch = 6;
            _objcas.prj_code = lblprj.Text;
            if (lblprj.Text == "AFV")
                _objcas.sys = Convert.ToInt32(Request.QueryString["div"].ToString());
            else
                _objcas.sys = 0;
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);

            _dtresult = _dtMaster;
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

            lbltitle.Text = _buildingName + " - " + lbltitle.Text;

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
        protected void Populate_view()
        {

        }
        protected void Load_Summary()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            //info1.AddMergedColumns(new int[] { 1, 2 }, "Panel/Equipment Test");
            //info1.AddMergedColumns(new int[] { 3, 4 }, "Outgoing Circuit Test");
            _objcas.sch = 13;
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

        protected void mygrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }

        protected void mygrid_Sorting(object sender, GridViewSortEventArgs e)
        {

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
        decimal _pqty1 = 0;
        decimal _pqty2 = 0; 
        decimal _tested1 = 0;
        decimal _tested2 = 0;
        decimal _ptested1 = 0;
        decimal _ptested2 = 0;  

        decimal _acce = 0;
        decimal _total = 0;
        decimal _ptotal = 0;    
        decimal _count = 0;
        decimal _sumry = 0;

        decimal _q1 = 0;
        decimal _q2 = 0;


        protected void mygridsumm_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
                _qty += Convert.ToDecimal(e.Row.Cells[2].Text);

                _ptotal += Convert.ToDecimal(e.Row.Cells[9].Text);
                _total += Convert.ToDecimal(e.Row.Cells[10].Text);


                if (e.Row.Cells[3].Text != "-1")
                {
                    _pqty1 += Convert.ToDecimal(e.Row.Cells[3].Text);
                    _ptested1 += Convert.ToDecimal(e.Row.Cells[4].Text);

                    e.Row.Cells[4].Text = e.Row.Cells[4].Text + "%";
                }
                else
                {
                    e.Row.Cells[4].Text = "N/A";
                    e.Row.Cells[3].Text = "N/A";
                }


                if (e.Row.Cells[5].Text != "-1") { _tested1 += Convert.ToDecimal(e.Row.Cells[5].Text); e.Row.Cells[5].Text = e.Row.Cells[5].Text + "%"; }
                else { e.Row.Cells[5].Text = "N/A"; _q1 += 1; }


                if (e.Row.Cells[6].Text != "-1")
                {
                    _pqty2 += Convert.ToDecimal(e.Row.Cells[6].Text);
                    _ptested2 += Convert.ToDecimal(e.Row.Cells[7].Text);

                    e.Row.Cells[7].Text = e.Row.Cells[7].Text + "%";
                }
                else
                {
                    e.Row.Cells[6].Text = "N/A";
                    e.Row.Cells[7].Text = "N/A";
                }


                if (e.Row.Cells[8].Text != "-1") { _tested2 += Convert.ToDecimal(e.Row.Cells[8].Text); e.Row.Cells[8].Text = e.Row.Cells[8].Text + "%"; }
                else { e.Row.Cells[8].Text = "N/A"; _q2 += 1; }


                if (e.Row.Cells[9].Text != "-1") e.Row.Cells[9].Text = e.Row.Cells[9].Text + "%";
                else e.Row.Cells[9].Text = "N/A";


                if (e.Row.Cells[10].Text != "-1") e.Row.Cells[10].Text = e.Row.Cells[10].Text + "%";
                else e.Row.Cells[10].Text = "N/A";




                _count += 1;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                decimal earchWght = 0.5m;
                decimal bondingWght = 0.5m;

                if (lblprj.Text == "ARSD") {earchWght = 0.3m; bondingWght = 0.7m; }

                try
                {



                    decimal _p1 = 0;
                        decimal _p2 = 0;
                        decimal _p3 = 0;
                        decimal _p4 = 0;
                        decimal _total = 0;
                        decimal _ptotal = 0;
                        int count = 0;
                        int count1 = 0;
                        int count2 = 0;
                        int count3 = 0;
                        int count4 = 0;

                        int pcount1 = 0;
                        int pcount2 = 0;
                        int pcount3 = 0;
                        int pcount4 = 0;

                        string _s = "";

                        decimal _qtyplanned1 = 0;
                        decimal _qtyplanned2 = 0;
                        decimal _qtyplanned3 = 0;
                        decimal _qtyplanned4 = 0;


                        int Na_count1 = 0;
                        int Na_count2 = 0;
                        int Na_count3 = 0;
                        int Na_count4 = 0;

                        int pNa_count1 = 0;
                        int pNa_count2 = 0;
                        int pNa_count3 = 0;
                        int pNa_count4 = 0;


                        var todaysDate = DateTime.Today;

                        DateTime defaultvalue = DateTime.ParseExact("01/01/2099", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                        var pcdate = defaultvalue;
                        if (!string.IsNullOrEmpty(hdnpcd.Value))
                        {
                            todaysDate = DateTime.ParseExact(hdnpcd.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                        }


                        var _result = from _data in _dtresult.AsEnumerable()
                                      select _data;
                        foreach (var _row in _result)
                        {

                            pcdate = defaultvalue;
                            count += 1;


                            if (Convert.ToDecimal(_row["per_com1"].ToString()) >= 0)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                count1 += 1;

                            }
                            else
                                Na_count1 += 1;


                            if (Convert.ToDecimal(_row["per_com2"].ToString()) >= 0)
                            {
                                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                                count2 += 1;

                            }
                            else
                                Na_count2 += 1;


                            if (Convert.ToDecimal(_row["per_com3"].ToString()) >= 0)
                            {
                                _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                                count3 += 1;

                            }
                            else
                                Na_count3 += 1;


                            if (Convert.ToDecimal(_row["per_com4"].ToString()) >= 0)
                            {
                                _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                                count4 += 1;

                            }
                            else
                                Na_count4 += 1;



                            if (Convert.ToDecimal(_row["per_com5"].ToString()) != -1)
                            {
                                pcount1 += 1;

                                if (_row["pcdate"] != null && _row["pcdate"].ToString() != "")
                                {
                                    pcdate = DateTime.ParseExact(_row["pcdate"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                    if (pcdate <= todaysDate) _qtyplanned1 += 1;
                                }
                            }
                            else
                                pNa_count1 += 1;

                            if (Convert.ToDecimal(_row["per_com6"].ToString()) >= 0)
                            {
                                pcount2 += 1;

                                if (_row["pcdate1"] != null && _row["pcdate1"].ToString() != "")
                                {
                                    pcdate = DateTime.ParseExact(_row["pcdate1"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                    if (pcdate <= todaysDate) _qtyplanned2 += 1;
                                }

                            }
                            else
                                pNa_count2 += 1;

                            if (Convert.ToDecimal(_row["per_com7"].ToString()) >= 0)
                            {
                                pcount3 += 1;
                                if (_row["pcdate2"] != null && _row["pcdate2"].ToString() != "")
                                {
                                    pcdate = DateTime.ParseExact(_row["pcdate2"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                    if (pcdate <= todaysDate) _qtyplanned3 += 1;
                                }
                            }
                            else
                                pNa_count3 += 1;


                            if (Convert.ToDecimal(_row["per_com8"].ToString()) >= 0)
                            {
                                pcount4 += 1;
                                if (_row["pcdate3"] != null && _row["pcdate3"].ToString() != "")
                                {
                                    pcdate = DateTime.ParseExact(_row["pcdate3"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                    if (pcdate <= todaysDate) _qtyplanned4 += 1;
                                }

                            }
                            else
                                pNa_count4 += 1;

                        }
                        decimal _per1 = 0;
                        decimal _per2 = 0;


                        decimal _pper1 = 0;
                    decimal _pper2 = 0;

                    decimal _pqty1 = 0;
                    decimal _pqty2 = 0;




                    _p1 = (_p1 != -1 ? _p1 : 0) + (_p3 != -1 ? _p3 : 0);
                    count1 = (count1 != -1 ? count1 : 0) + (count3 != -1 ? count3 : 0);


                    _pqty1 = (_qtyplanned1!=-1? _qtyplanned1:0) + (_qtyplanned3 != -1 ? _qtyplanned3 : 0);
                    pcount1 = (pcount1 != -1 ? pcount1 : 0) + (pcount3 != -1 ? pcount3 : 0);

                    _p2 = (_p2 != -1 ? _p2 : 0) + (_p4 != -1 ? _p4 : 0);
                    count2 = (count2 != -1 ? count2 : 0) + (count4 != -1 ? count4 : 0);

                    _pqty2 = (_qtyplanned2 != -1 ? _qtyplanned2 : 0) + (_qtyplanned4 != -1 ? _qtyplanned4 : 0);
                    pcount2 = (pcount2 != -1 ? pcount2 : 0) + (pcount4 != -1 ? pcount4 : 0);






                    if (count1 > 0) { _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count1), 0, MidpointRounding.AwayFromZero); }
                    if (count2 > 0) { _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count2), 0, MidpointRounding.AwayFromZero); }

                    if (pcount1 > 0) { _pper1 = Decimal.Round((_pqty1 / Convert.ToDecimal(pcount1)) * 100, 0, MidpointRounding.AwayFromZero); }
                    if (pcount2 > 0) { _pper2 = Decimal.Round((_pqty2 / Convert.ToDecimal(pcount2)) * 100, 0, MidpointRounding.AwayFromZero); }


                    if (Na_count1 == count) { _p1 = -1; }
                    if (Na_count2 == count) { _p2 = -1; }
                    if (Na_count3 == count) { _p3 = -1; }
                    if (Na_count4 == count) { _p4 = -1; }


                    if (pNa_count1 == count) { _qtyplanned1 = -1; }
                    if (pNa_count2 == count) { _qtyplanned2 = -1; }
                    if (pNa_count3 == count) { _qtyplanned3 = -1; }
                    if (pNa_count4 == count) { _qtyplanned4 = -1; }


                    if (_p1 == -1 && _p3 == -1) { _per1 = -1; }
                    if (_p2 == -1 && _p4 == -1) { _per2 = -1; }

                    if (_qtyplanned1 == -1 && _qtyplanned3 == -1) { _pqty1 = -1; _pper1 = -1; }
                    if (_qtyplanned2 == -1 && _qtyplanned4 == -1) { _pqty2 = -1; _pper2 = -1; }



                    if (_per1 != -1 && _per2 == -1) { _total = Decimal.Round(_per1); }
                    else if (_per1 == -1 && _per2 != -1) { _total = Decimal.Round(_per2); }
                    else if (_per1 != -1 && _per2 != -1) { _total = Decimal.Round((_per1 * earchWght) + (_per2 * bondingWght), 0, MidpointRounding.AwayFromZero); }
                    else _total = -1;

                    if (_pper1 != -1 && _pper2 == -1) { _ptotal = Decimal.Round(_pper1); }
                    else if (_pper1 == -1 && _pper2 != -1) { _ptotal = Decimal.Round(_pper2); }
                    else if (_pper1 != -1 && _pper2 != -1) { _ptotal = Decimal.Round((_pper1 * earchWght) + (_pper2 * bondingWght), 0, MidpointRounding.AwayFromZero); }
                    else _ptotal = -1;



                    e.Row.Cells[1].Text = "TOTALS";
                    e.Row.Cells[2].Text = count.ToString();


                    if (_pqty1 != -1) e.Row.Cells[3].Text = _pqty1.ToString();
                    else e.Row.Cells[3].Text = "N/A";

                    if (_pper1 != -1) e.Row.Cells[4].Text = _pper1.ToString() + '%';
                    else e.Row.Cells[4].Text = "N/A";

                    if (_per1 != -1) e.Row.Cells[5].Text = _per1.ToString() + '%';
                    else e.Row.Cells[5].Text = "N/A";

                    if (_pqty2 != -1) e.Row.Cells[6].Text = _pqty2.ToString();
                    else e.Row.Cells[6].Text = "N/A";

                    if (_pper2 != -1) e.Row.Cells[7].Text = _pper2.ToString() + '%';
                    else e.Row.Cells[7].Text = "N/A";

                    if (_per2 != -1) e.Row.Cells[8].Text = _per2.ToString() + '%';
                    else e.Row.Cells[8].Text = "N/A";

                    if (_ptotal != -1) e.Row.Cells[9].Text = _ptotal.ToString() + '%';
                    else e.Row.Cells[9].Text = "N/A";

                    if (_total != -1) e.Row.Cells[10].Text = _total.ToString() + '%';
                    else e.Row.Cells[10].Text = "N/A";


                    Session["Sum_QtyPlanned1"] = _pqty1.ToString();
                    Session["Sum_QtyPlanned2"] = _pqty2.ToString();

                    Session["Sum_PerPlanned1"] = _pper1.ToString();
                    Session["Sum_PerPlanned2"] = _pper2.ToString();

                    Session["Sum_Percom1"] = _per1.ToString();
                    Session["Sum_Percom2"] = _per2.ToString();

                    Session["Sum_Poverall"] = _ptotal.ToString();
                    Session["Sum_Overall"] = _total.ToString();


                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
                }




            }

               
            
        }

        protected void mygridsumm_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.SetRenderMethodDelegate(RenderHeader1);
        }

        protected void print_Click(object sender, EventArgs e)
        {
            //Session["zone"] = drbuilding.SelectedItem.Value;
            //Session["flvl"] = drflevel.SelectedItem.Value;
            //Session["cat"] = drcategory.SelectedItem.Value;
            //Session["fed"] = drfed.SelectedItem.Value;
            Insert_Summary();
            string _path = "Cas_Report.aspx?id=6_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value + "_Z" + (string)Session["zero"];
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.open('" + _path + "');", true);
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

                _objcls.sys_mon = row["SYS_NAME"].ToString();
                _objcls.qty = row["QTY"].ToString();
                _objcls.per_com1 = Convert.ToDecimal(row["PER_COMPLETED"].ToString());
                _objcls.per_com2 = Convert.ToDecimal(row["PER_COMPLETED1"].ToString());
                _objcls.total = Convert.ToDecimal(row["TOTAL"].ToString());
                _objcls.cate = row["CODE"].ToString();
                _objcls.quantity = Convert.ToInt32(row["QTY"].ToString());

                _objcls.compl1 = Convert.ToInt32(row["QTY_PER_COMPLETED"].ToString());
                _objcls.compl2 = Convert.ToInt32(row["P_PER_COMPLETED"].ToString());

                _objcls.compl3 = Convert.ToInt32(row["QTY_PER_COMPLETED1"].ToString());
                _objcls.compl4 = Convert.ToInt32(row["P_PER_COMPLETED1"].ToString());

                _objcls.per_com3 = Convert.ToDecimal(row["PLANNED_TOTAL"].ToString());



                _objbll.Generate_CASSummary_PKG_RPT_ASAO(_objcls, _objdb);
                //count += 1;
            }
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + count.ToString() + "');", true);
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
            e.Row.Cells[5].Text = SeqNo(e.Row.Cells[5].Text);

            e.Row.Cells[27].Visible = false;
            e.Row.Cells[28].Visible = false;
            e.Row.Cells[29].Visible = false;
            e.Row.Cells[30].Visible = false;


            if (e.Row.Cells[3].Text == "LP")
            {
                e.Row.Cells[8].Text = "N/A";
                e.Row.Cells[12].Text = "N/A";
            }
            else
            {
                e.Row.Cells[16].Text = "N/A";
                e.Row.Cells[20].Text = "N/A";
            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[27].Text == "-1") { e.Row.Cells[8].Text = "N/A"; }
                if (e.Row.Cells[28].Text == "-1") { e.Row.Cells[12].Text = "N/A"; }
                if (e.Row.Cells[29].Text == "-1") { e.Row.Cells[16].Text = "N/A"; }
                if (e.Row.Cells[30].Text == "-1") { e.Row.Cells[20].Text = "N/A"; }

            }

        }



            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Cells[2].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            //    e.Row.Cells[3].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            //    e.Row.Cells[4].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            //    e.Row.Cells[7].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            //    e.Row.Cells[8].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            //    e.Row.Cells[9].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");

                //}
                //if ((string)Session["sch"] == "2")
                //{
                //    e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
                //}
                //else if ((string)Session["sch"] == "3")
                //{
                //    e.Row.Cells[11].Visible = false;
                //}
                //else if ((string)Session["sch"] == "6")
                //{
                //    e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
                //}
                //else if ((string)Session["sch"] == "7")
                //{
                //    e.Row.Cells[8].Visible = false; e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false;
                //}
                //else if ((string)Session["sch"] == "8" || (string)Session["sch"] == "9" || (string)Session["sch"] == "17")
                //{
                //    e.Row.Cells[8].Visible = false; e.Row.Cells[11].Visible = false;
                //}
                //else if ((string)Session["sch"] == "21")
                //{
                //    e.Row.Cells[8].Visible = false; e.Row.Cells[9].Visible = false;
                //}

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
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("P_P_to") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("P_P_to") == _el4 && o.Field<string>("Loc") == _el5
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
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("P_P_to") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("P_P_to") == _el4 && o.Field<string>("Loc") == _el5
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
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("P_P_to") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("P_P_to") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("P_P_to") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("P_P_to") == _el4 && o.Field<string>("Loc") == _el5
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
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("P_P_to") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("P_P_to") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("P_P_to") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("P_P_to") == _el4 && o.Field<string>("Loc") == _el5
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
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("P_P_to") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("P_P_to") == _el4 && o.Field<string>("Loc") == _el5
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
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("P_P_to") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("P_P_to") == _el4 && o.Field<string>("Loc") == _el5
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
            _dtresult = _filter.Any() ? _filter.CopyToDataTable() : _dtresult.Clone();
            Load_Details();

            if (lblprj.Text == "ARSD") Generate_Summary(0.3m, 0.7m);
            else Generate_Summary(0.5m, 0.5m);

        }
        private void Generate_Summary(decimal earchWght, decimal bondingWght)
        {
            try
            {
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("QTY_PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("P_PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("QTY_PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("P_PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PLANNED_TOTAL", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _total = 0;
                    decimal _ptotal = 0;    
                    int count = 0;
                    int count1 = 0;
                    int count2 = 0;
                    int count3 = 0;
                    int count4 = 0;

                    int pcount1 = 0;
                    int pcount2 = 0;
                    int pcount3 = 0;
                    int pcount4 = 0;

                    string _s = "";

                    decimal _qtyplanned1 = 0;
                    decimal _qtyplanned2 = 0;
                    decimal _qtyplanned3 = 0;
                    decimal _qtyplanned4 = 0;


                    int Na_count1 = 0;
                    int Na_count2 = 0;
                    int Na_count3 = 0;
                    int Na_count4 = 0;

                    int pNa_count1 = 0;
                    int pNa_count2 = 0;
                    int pNa_count3 = 0;
                    int pNa_count4 = 0; 


                    var todaysDate = DateTime.Today;

                    DateTime defaultvalue = DateTime.ParseExact("01/01/2099", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                    var pcdate = defaultvalue;
                    if (!string.IsNullOrEmpty(hdnpcd.Value))
                    {
                        todaysDate = DateTime.ParseExact(hdnpcd.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                    }


                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {

                        pcdate = defaultvalue;
                        count += 1;


                        if (Convert.ToDecimal(_row["per_com1"].ToString()) >= 0)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        count1 += 1;

                        }
                        else
                            Na_count1 += 1;


                        if (Convert.ToDecimal(_row["per_com2"].ToString()) >= 0)
                        {
                            _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                            count2 += 1;

                        }
                        else
                            Na_count2 += 1;


                        if (Convert.ToDecimal(_row["per_com3"].ToString()) >= 0)
                        {
                            _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                            count3 += 1;

                        }
                        else
                            Na_count3 += 1;


                        if (Convert.ToDecimal(_row["per_com4"].ToString()) >= 0)
                        {
                            _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                            count4 += 1;

                        }
                        else
                            Na_count4 += 1;



                        if (Convert.ToDecimal(_row["per_com5"].ToString()) != -1)
                        {
                            pcount1 += 1;

                            if (_row["pcdate"] != null && _row["pcdate"].ToString() != "")
                            {
                                pcdate = DateTime.ParseExact(_row["pcdate"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                if (pcdate <= todaysDate) _qtyplanned1 += 1;
                            }
                        }
                        else
                            pNa_count1 += 1;

                        if (Convert.ToDecimal(_row["per_com6"].ToString()) >= 0)
                            {
                                pcount2 += 1;

                                if (_row["pcdate1"] != null && _row["pcdate1"].ToString() != "")
                            {
                                pcdate = DateTime.ParseExact(_row["pcdate1"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                if (pcdate <= todaysDate) _qtyplanned2 += 1;
                            }

                            }
                            else
                                pNa_count2 += 1;

                            if (Convert.ToDecimal(_row["per_com7"].ToString()) >= 0)
                            {
                                pcount3 += 1;
                                if (_row["pcdate2"] != null && _row["pcdate2"].ToString() != "")
                            {
                                pcdate = DateTime.ParseExact(_row["pcdate2"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                if (pcdate <= todaysDate) _qtyplanned3 += 1;
                            }
                        }
                            else
                                pNa_count3 += 1;


                            if (Convert.ToDecimal(_row["per_com8"].ToString()) >= 0)
                            {
                                pcount4 += 1;
                                if (_row["pcdate3"] != null && _row["pcdate3"].ToString() != "")
                            {
                                pcdate = DateTime.ParseExact(_row["pcdate3"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                if (pcdate <= todaysDate) _qtyplanned4 += 1;
                            }

                        }
                            else
                                pNa_count4 += 1;

                            _s = _row[0].ToString();
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;

                    decimal _pper1 = 0;
                    decimal _pper2 = 0;
                    decimal _pper3 = 0; 
                    decimal _pper4 = 0;

                    if (count1 > 0) {_per1 = Decimal.Round(_p1 / Convert.ToDecimal(count1), 0, MidpointRounding.AwayFromZero);}
                    if (count2 > 0) { _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count2), 0, MidpointRounding.AwayFromZero); }
                    if (count3 > 0) { _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count3), 0, MidpointRounding.AwayFromZero); }
                    if (count4 > 0) { _per4 = Decimal.Round(_p4 / Convert.ToDecimal(count4), 0, MidpointRounding.AwayFromZero); }

                    if (pcount1 > 0) {_pper1 = Decimal.Round((_qtyplanned1 / Convert.ToDecimal(pcount1)) * 100, 0, MidpointRounding.AwayFromZero);}
                    if (pcount2 > 0) { _pper2 = Decimal.Round((_qtyplanned2 / Convert.ToDecimal(pcount2)) * 100, 0, MidpointRounding.AwayFromZero); }
                    if (pcount3 > 0) { _pper3 = Decimal.Round((_qtyplanned3 / Convert.ToDecimal(pcount3)) * 100, 0, MidpointRounding.AwayFromZero); }
                    if (pcount4 > 0) { _pper4 = Decimal.Round((_qtyplanned4 / Convert.ToDecimal(pcount4)) * 100, 0, MidpointRounding.AwayFromZero); }


                        if (Na_count1 == count) _per1 = -1;
                        if (Na_count2 == count) _per2 = -1;
                        if (Na_count3 == count) _per3 = -1;
                        if (Na_count4 == count) _per4 = -1;

                        if (pNa_count1 == count) { _pper1 = -1; _qtyplanned1 = -1; }
                        if (pNa_count2 == count) { _pper2 = -1; _qtyplanned2 = -1; }
                        if (pNa_count3 == count) { _pper3 = -1; _qtyplanned3 = -1; }
                        if (pNa_count4 == count) { _pper4 = -1; _qtyplanned4 = -1; }


                        //decimal _PlannedPer = 0;
                        //decimal _PlannedPer1 = 0;

                        DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();

                    if (row.col3.ToString() == "LP")
                    {

                        _drow[2] = _qtyplanned3.ToString();
                        _drow[3] = _pper3.ToString();
                        _drow[4] = _per3.ToString();

                        _drow[5] = _qtyplanned4.ToString();
                        _drow[6] = _pper4.ToString();
                        _drow[7] = _per4.ToString();


                        if (_per3 != -1 && _per4 == -1) { _total = Decimal.Round(_per3); }
                        else if (_per3 == -1 && _per3 != -1) { _total = Decimal.Round(_per4); }
                        else if (_per3 != -1 && _per4 != -1) { _total = Decimal.Round((_per3 * earchWght) + (_per4 * bondingWght), 0, MidpointRounding.AwayFromZero); }
                        else  _total = -1;

                        if (_pper3 != -1 && _pper4 == -1) { _ptotal = Decimal.Round(_pper3); }
                        else if (_pper3 == -1 && _pper3 != -1) { _ptotal = Decimal.Round(_pper4); }
                        else if (_pper3 != -1 && _pper4 != -1) { _ptotal = Decimal.Round((_pper3 * earchWght) + (_pper4 * bondingWght), 0, MidpointRounding.AwayFromZero); }
                        else _ptotal = -1;

                    }
                    else
                    {


                        _drow[2] = _qtyplanned1.ToString();
                        _drow[3] = _pper1.ToString();
                        _drow[4] = _per1.ToString();

                        _drow[5] = _qtyplanned2.ToString();
                        _drow[6] = _pper2.ToString();
                        _drow[7] = _per2.ToString();


                        if (_per1 != -1 && _per2 == -1) { _total = Decimal.Round(_per1); }
                        else if (_per1 == -1 && _per2 != -1) { _total = Decimal.Round(_per2); }
                        else if (_per1 != -1 && _per2 != -1) { _total = Decimal.Round((_per1 * earchWght) + (_per2 * bondingWght), 0, MidpointRounding.AwayFromZero); }
                        else _total = -1;


                        if (_pper1 != -1 && _pper2 == -1) { _ptotal = Decimal.Round(_pper1); }
                        else if (_pper1 == -1 && _pper2 != -1) { _ptotal = Decimal.Round(_pper2); }
                        else if (_pper1 != -1 && _pper2 != -1) { _ptotal = Decimal.Round((_pper1 * earchWght) + (_pper2 * bondingWght), 0, MidpointRounding.AwayFromZero); }
                        else _ptotal = -1;

                    }

                  

                    _drow[8] = _ptotal.ToString();
                    _drow[9] = _total.ToString();
                    _drow[10] = row.col3.ToString();

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
        }

        protected void drflevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["flvl"] = drflevel.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text);
        }

        protected void drfed_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["fed"] = drfed.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text,  drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text);
        }

        protected void drloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["loc"] = drloc.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text);
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

        protected void btnzero_Click(object sender, EventArgs e)
        {
            Session["zero"] = "0";
            //Filtering_zero();
        }

        private void Head_Merging()
        {
            info1.AddMergedColumns(new int[] { 3, 4,5 }, "EARTH PIT TESTS");
            info1.AddMergedColumns(new int[] { 6, 7,8 }, "BONDING TESTS");
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
            Hide_Details();
            if (lblprj.Text == "ARSD" ) Generate_Summary(0.3m,0.7m);
            else Generate_Summary(0.5m, 0.5m);
        }
        //private void Filtering_zero()
        //{
        //    Load_Master();
        //    _dtfilter = _dtresult;
        //    _dtresult = new DataTable();
        //    _dtresult.Columns.Add("e_b_ref", typeof(string));
        //    _dtresult.Columns.Add("B_Z", typeof(string));
        //    _dtresult.Columns.Add("Cat", typeof(string));
        //    _dtresult.Columns.Add("F_lvl", typeof(string));
        //    _dtresult.Columns.Add("Seq_No", typeof(string));
        //    _dtresult.Columns.Add("Loc", typeof(string));
        //    _dtresult.Columns.Add("P_P_to", typeof(string));
        //    _dtresult.Columns.Add("F_from", typeof(string));
        //    _dtresult.Columns.Add("Substation", typeof(string));
        //    _dtresult.Columns.Add("devices1", typeof(string));
        //    _dtresult.Columns.Add("C_id", typeof(int));
        //    _dtresult.Columns.Add("Sys_name", typeof(string));
        //    _dtresult.Columns.Add("Sys_id", typeof(int));
        //    _dtresult.Columns.Add("Pwr_on", typeof(string));
        //    _dtresult.Columns.Add("test1", typeof(string));
        //    _dtresult.Columns.Add("test2", typeof(string));
        //    _dtresult.Columns.Add("test3", typeof(string));
        //    _dtresult.Columns.Add("test4", typeof(string));
        //    _dtresult.Columns.Add("test5", typeof(string));
        //    _dtresult.Columns.Add("test6", typeof(string));
        //    _dtresult.Columns.Add("test7", typeof(string));
        //    _dtresult.Columns.Add("test8", typeof(string));
        //    _dtresult.Columns.Add("test10", typeof(string));
        //    _dtresult.Columns.Add("test9", typeof(string));
        //    _dtresult.Columns.Add("Per_com1", typeof(string));
        //    _dtresult.Columns.Add("Accept1", typeof(string));
        //    _dtresult.Columns.Add("filed1", typeof(string));
        //    _dtresult.Columns.Add("Accept2", typeof(string));
        //    _dtresult.Columns.Add("filed2", typeof(string));
        //    _dtresult.Columns.Add("Comm", typeof(string));
        //    _dtresult.Columns.Add("Act_by", typeof(string));
        //    _dtresult.Columns.Add("Act_date", typeof(string));
        //    _dtresult.Columns.Add("tested1", typeof(string));
        //    _dtresult.Columns.Add("Per_com2", typeof(string));
        //    _dtresult.Columns.Add("Per_com3", typeof(string));
        //    _dtresult.Columns.Add("Per_com4", typeof(string));
        //    var _filter = from o in _dtfilter.AsEnumerable()
        //                  where o.Field<string>("test1") == null && o.Field<string>("test6") == null && o.Field<string>("test9") == null && o.Field<string>("test10") == null
        //                  select o;
        //    foreach (var row in _filter)
        //    {
        //        DataRow _row = _dtresult.NewRow();
        //        _row[0] = row["e_b_ref"].ToString();
        //        _row[1] = row["B_Z"].ToString();
        //        _row[2] = row["Cat"].ToString();
        //        _row[3] = row["F_lvl"].ToString();
        //        _row[4] = SeqNo(row["Seq_No"].ToString());
        //        _row[5] = row["Loc"].ToString();
        //        _row[6] = row["p_p_to"].ToString();
        //        _row[7] = row["F_from"].ToString();
        //        _row[8] = row["Substation"].ToString();
        //        _row[9] = row["devices1"].ToString();
        //        _row[10] = row["C_id"].ToString();
        //        _row[11] = row["Sys_name"].ToString();
        //        _row[12] = row["Sys_id"].ToString();
        //        _row[13] = row["Pwr_on"].ToString();
        //        _row[14] = row["test1"].ToString();
        //        _row[15] = row["test2"].ToString();
        //        _row[16] = row["test3"].ToString();
        //        _row[17] = row["test4"].ToString();
        //        _row[18] = row["test5"].ToString();
        //        _row[19] = row["test6"].ToString();
        //        _row[20] = row["test7"].ToString();
        //        _row[21] = row["test8"].ToString();
        //        _row[22] = row["test10"].ToString();
        //        _row[23] = row["test9"].ToString();
        //        _row[24] = row["Per_com1"].ToString();
        //        _row[25] = row["accept1"].ToString();
        //        _row[26] = row["filed1"].ToString();
        //        _row[27] = row["accept2"].ToString();
        //        _row[28] = row["filed2"].ToString();
        //        _row[29] = row["Comm"].ToString();
        //        _row[30] = row["Act_by"].ToString();
        //        _row[31] = row["Act_date"].ToString();
        //        _row[32] = row["tested1"].ToString();
        //        _row[33] = row["Per_com2"].ToString();
        //        _row[34] = row["Per_com3"].ToString();
        //        _row[35] = row["Per_com4"].ToString();
        //        _dtresult.Rows.Add(_row);
        //    }
        //    Load_Details();
        //    if (lblprj.Text == "ARSD") Generate_Summary(0.3m, 0.7m);
        //    else Generate_Summary(0.5m, 0.5m);
        //}
        protected void genPcd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdnpcd.Value))
            {
                if (lblprj.Text == "ARSD") Generate_Summary(0.3m, 0.7m);
                else Generate_Summary(0.5m, 0.5m);
            }

        }

    }
}
