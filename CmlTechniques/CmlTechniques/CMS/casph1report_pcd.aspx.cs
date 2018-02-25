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
    public partial class casph1report_pcd : System.Web.UI.Page
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
                lblprj.Text = Request.QueryString[0].ToString();
                
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
            _objcas.sch = 17;
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
            info1.AddMergedColumns(new int[] { 3, 4, 5, 6 }, "Pre-Commissioning");
            info1.AddMergedColumns(new int[] { 7, 8, 9, 10 }, "Commissioning");
        }
        protected void Load_Summary()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32((string)Session["sch"]);
            //mygridsumm.DataSource = _objbll.LOAD_CAS_PKG_SUMMARY(_objcas, _objdb);
            //mygridsumm.DataBind();
        }
        int _qty = 0;
        decimal _tested1 = 0;
        decimal _tested2 = 0;
        decimal _tested3 = 0;
        decimal _tested4 = 0;
        decimal _tested5 = 0;
        decimal _total = 0;
        int _pcommNA = 0;
        int _commNA = 0;
        int _percomm = 0;
        int _comm = 0;

        protected void mygridsumm_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.SetRenderMethodDelegate(RenderHeader1);
        }
        protected void mygridsumm_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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
            e.Row.Cells[27].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
                _qty += Convert.ToInt32(e.Row.Cells[2].Text);
                _tested4 += (e.Row.Cells[14].Text == "N/A") ? 0 : Convert.ToDecimal(e.Row.Cells[14].Text);
                _percomm += Convert.ToInt32(e.Row.Cells[26].Text);
                _tested1 += (e.Row.Cells[16].Text == "N/A") ? 0 : Convert.ToDecimal(e.Row.Cells[16].Text);
                _comm += Convert.ToInt32(e.Row.Cells[27].Text);
                _tested5 += (e.Row.Cells[18].Text == "N/A") ? 0 : Convert.ToDecimal(e.Row.Cells[18].Text);
                _tested2 += (e.Row.Cells[20].Text == "N/A") ? 0 : Convert.ToDecimal(e.Row.Cells[20].Text);
                _pcommNA += Convert.ToInt32(e.Row.Cells[24].Text);
                _commNA += Convert.ToInt32(e.Row.Cells[25].Text);


            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "SUMMARY";
                e.Row.Cells[2].Text = _qty.ToString();
                e.Row.Cells[3].Text = _tested4.ToString();
                e.Row.Cells[4].Text = ((_percomm > 0) ? Decimal.Round((_tested4 / _percomm) * 100, MidpointRounding.AwayFromZero).ToString() : Convert.ToString(0)) + "%";
                e.Row.Cells[5].Text = _tested1.ToString();
                e.Row.Cells[6].Text = ((_percomm > 0) ? Decimal.Round((_tested1 / _percomm) * 100, MidpointRounding.AwayFromZero).ToString() : Convert.ToString(0)) + "%";
                e.Row.Cells[7].Text = _tested5.ToString();
                e.Row.Cells[8].Text = ((_comm > 0) ? Decimal.Round((_tested5 / _comm) * 100, MidpointRounding.AwayFromZero).ToString() : Convert.ToString(0)) + "%";
                e.Row.Cells[9].Text = _tested2.ToString();
                e.Row.Cells[10].Text = ((_comm > 0) ? Decimal.Round((_tested2 / _comm) * 100, MidpointRounding.AwayFromZero).ToString() : Convert.ToString(0)) + "%";
                e.Row.Cells[11].Text = (Decimal.Round((((_percomm > 0) ? (_tested4 * 0.2m) / (_percomm) : 0) + ((_comm > 0) ? (_tested5 * 0.8m) / (_comm) : 0)) * 100, MidpointRounding.AwayFromZero)).ToString() + "%";
                e.Row.Cells[12].Text = (Decimal.Round((((_percomm > 0) ? (_tested1 * 0.2m) / (_percomm) : 0) + ((_comm > 0) ? (_tested2 * 0.8m) / (_comm) : 0)) * 100, MidpointRounding.AwayFromZero)).ToString() + "%";
                hdnPLpcom.Value = e.Row.Cells[3].Text;
                hdnPLpcomper.Value = e.Row.Cells[4].Text;
                hdnACpcom.Value = e.Row.Cells[5].Text;
                hdnACpcomper.Value = e.Row.Cells[6].Text;
                hdnPLcom.Value = e.Row.Cells[7].Text;
                hdnPLcomper.Value = e.Row.Cells[8].Text;
                hdnACcom.Value = e.Row.Cells[9].Text;
                hdnACcomper.Value = e.Row.Cells[10].Text;
                hdnPLOverall.Value = e.Row.Cells[11].Text;
                hdnACOverall.Value = e.Row.Cells[12].Text;            
            }

        }
        protected void print_Click(object sender, EventArgs e)
        {
            //Session["zone"] = drbuilding.SelectedItem.Value;
            //Session["flvl"] = drflevel.SelectedItem.Value;
            //Session["cat"] = drcategory.SelectedItem.Value;
            //Session["fed"] = drfed.SelectedItem.Value;
            Insert_Summary();
            string _path = "Cas_Report.aspx?id=17_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value + "_Z" + (string)Session["zero"] + "&Div=" + lbldiv.Text + "&PLpcom=" + hdnPLpcom.Value + "&PLpcomper=" + hdnPLpcomper.Value + "&ACpcom=" + hdnACpcom.Value + "&ACpcomper=" + hdnACpcomper.Value + "&PLcom=" + hdnPLcom.Value + "&PLcomper=" + hdnPLcomper.Value + "&ACcom=" + hdnACcom.Value + "&ACcomper=" + hdnACcomper.Value + "&PLOverall=" + hdnPLOverall.Value + "&ACOverall=" + hdnACOverall.Value;
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
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Label _lbl = (Label)e.Row.FindControl("Label1");
            //    if (_lbl.Text == "0.00%")
            //        _lbl.Text = "";
            //}
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
                _dtsummary.Columns.Add("PER_COMPLETED3", typeof(string));
                _dtsummary.Columns.Add("PLANNED_PER_PCOM", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("ACTUAL_PER_PCOM", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED4", typeof(string));
                _dtsummary.Columns.Add("PLANNED_PER_COM", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("ACTUAL_PER_COM", typeof(string));
                _dtsummary.Columns.Add("TOTAL1", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                _dtsummary.Columns.Add("PCOMM_NA", typeof(string));
                _dtsummary.Columns.Add("COMM_NA", typeof(string));
                _dtsummary.Columns.Add("PCOMM", typeof(string));
                _dtsummary.Columns.Add("COMM", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();

                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p1NA = 0;
                    decimal _pcom = 0;
                    decimal _com = 0;
                    decimal _p2 = 0;
                    decimal _p2NA = 0;
                    decimal _p_p1 = 0;
                    decimal _p_p2 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
                    int count = 0;
                    int _pcNAqty = 0;
                    int _cNAqty = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"]) == -1)
                            _p1NA += Convert.ToDecimal(_row["per_com1"]);
                        else if (Convert.ToDecimal(_row["per_com1"]) == 1)
                            _pcom += 1;

                        if (Convert.ToDecimal(_row["per_com1"]) != -1)
                            _p1 += 1;

                        if (Convert.ToDecimal(_row["per_com2"]) == -1)
                            _p2NA += Convert.ToDecimal(_row["per_com2"]);
                        else if (Convert.ToDecimal(_row["per_com2"]) == 1)
                            _com += 1;

                        if (Convert.ToDecimal(_row["per_com2"]) != -1)
                            _p2 += 1;

                        var todaysDate = DateTime.Today;
                        if (!string.IsNullOrEmpty(hdnpcd.Value))
                        {
                            todaysDate = DateTime.ParseExact(hdnpcd.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (_row["pcdate"] != null && _row["pcdate"].ToString() != "")
                        {
                            DateTime pcdate = DateTime.ParseExact(_row["pcdate"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            if (pcdate <= todaysDate) _p_p1 += 1;
                        }
                        if (_row["pcdate1"] != null && _row["pcdate1"].ToString() != "")
                        {
                            DateTime pcdate1 = DateTime.ParseExact(_row["pcdate1"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            if (pcdate1 <= todaysDate) _p_p2 += 1;
                        }
                        count += 1;
                    }
                    decimal _NA1 = 0;
                    decimal _NA2 = 0;
                    decimal _plannedPer = 0;
                    decimal _plannedPer1 = 0;
                    decimal _plannedPCom = 0;
                    decimal _ActualPCom = 0;
                    decimal _plannedCom = 0;
                    decimal _ActualCom = 0;
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    _plannedPCom = (_p1 > 0) ? (_p_p1 / _p1) : 0;
                    _ActualPCom = (_p1 > 0) ? (_pcom / _p1) : 0;
                    _plannedCom = (_p2 > 0) ? (_p_p2 / _p2) : 0;
                    _ActualCom = (_p2 > 0) ? (_com / _p2) : 0;
                    _NA1 = _p1NA / count;
                    _NA2 = _p2NA / count;
                    if (_NA1 == -1)
                        _pcNAqty = count;
                    if (_NA2 == -1)
                        _cNAqty = count;
                    if (_NA1 != -1 && _NA2 == -1)
                    {
                        _total = Decimal.Round((_ActualPCom * 100), MidpointRounding.AwayFromZero);
                        _total1 = Decimal.Round((_plannedPCom * 100), MidpointRounding.AwayFromZero);
                    }
                    else if (_NA2 != -1 && _NA1 == -1)
                    {
                        _total = Decimal.Round((_ActualCom * 100), MidpointRounding.AwayFromZero);
                        _total1 = Decimal.Round((_plannedCom * 100), MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        _total = Decimal.Round((((_ActualPCom * 0.2m) + (_ActualCom * 0.8m)) * 100), MidpointRounding.AwayFromZero);
                        _total1 = Decimal.Round((((_plannedPCom * 0.2m) + (_plannedCom * 0.8m)) * 100), MidpointRounding.AwayFromZero);
                    }
                    DataRow _drow = _dtsummary.NewRow();
                    _drow["SYS_NAME"] = row.col2.ToString();
                    _drow["QTY"] = count.ToString();
                    _drow["PER_COMPLETED3"] = (_NA1 == -1) ? "N/A" : _p_p1.ToString();
                    _drow["PLANNED_PER_PCOM"] = (_NA1 == -1) ? "N/A" : Decimal.Round((_plannedPCom * 100), MidpointRounding.AwayFromZero).ToString();
                    _drow["PER_COMPLETED"] = (_NA1 == -1) ? "N/A" : _pcom.ToString();
                    _drow["ACTUAL_PER_PCOM"] = (_NA1 == -1) ? "N/A" : Decimal.Round((_ActualPCom * 100), MidpointRounding.AwayFromZero).ToString();
                    _drow["PER_COMPLETED4"] = (_NA2 == -1) ? "N/A" : _p_p2.ToString();
                    _drow["PLANNED_PER_COM"] = (_NA2 == -1) ? "N/A" : Decimal.Round((_plannedCom * 100), MidpointRounding.AwayFromZero).ToString();
                    _drow["PER_COMPLETED1"] = (_NA2 == -1) ? "N/A" : _com.ToString();
                    _drow["ACTUAL_PER_COM"] = (_NA2 == -1) ? "N/A" : Decimal.Round((_ActualCom * 100), MidpointRounding.AwayFromZero).ToString();
                    _drow["TOTAL1"] = (_NA1 == -1 && _NA2 == -1) ? "N/A" : _total1.ToString();
                    _drow["TOTAL"] = (_NA1 == -1 && _NA2 == -1) ? "N/A" : _total.ToString();
                    _drow["CODE"] = row.col3.ToString();
                    _drow["PCOMM_NA"] = _pcNAqty.ToString();
                    _drow["COMM_NA"] = _cNAqty.ToString();
                    _drow["PCOMM"] = _p1.ToString();
                    _drow["COMM"] = _p2.ToString();
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
            _objbll.Clear_CassummaryRpt1(_objdb);
            var _result = from _data in _summary.AsEnumerable()
                          select _data;
            //int count = 0;
            foreach (var row in _result)
            {
                _objcls.sys_name = row["SYS_NAME"].ToString();
                _objcls.quaty = Convert.ToDecimal(row["QTY"]);
                _objcls.testd1 = (row["PER_COMPLETED3"].ToString() == "N/A") ? -1 : Convert.ToDecimal(row["PER_COMPLETED3"]);
                _objcls.testd2 = (row["PLANNED_PER_PCOM"].ToString() == "N/A") ? -1 : Convert.ToDecimal(row["PLANNED_PER_PCOM"]);
                _objcls.testd3 = (row["PER_COMPLETED"].ToString() == "N/A") ? -1 : Convert.ToDecimal(row["PER_COMPLETED"]);
                _objcls.testd4 = (row["ACTUAL_PER_PCOM"].ToString() == "N/A") ? -1 : Convert.ToDecimal(row["ACTUAL_PER_PCOM"]);
                _objcls.qty1 = (row["PER_COMPLETED4"].ToString() == "N/A") ? -1 : Convert.ToDecimal(row["PER_COMPLETED4"]);
                _objcls.qty2 = (row["PLANNED_PER_COM"].ToString() == "N/A") ? -1 : Convert.ToDecimal(row["PLANNED_PER_COM"]);
                _objcls.testd = (row["PER_COMPLETED1"].ToString() == "N/A") ? -1 : Convert.ToDecimal(row["PER_COMPLETED1"]);
                _objcls.qty3 = (row["ACTUAL_PER_COM"].ToString() == "N/A") ? -1 : Convert.ToDecimal(row["ACTUAL_PER_COM"]);
                _objcls.qty4 = (row["TOTAL1"].ToString() == "N/A") ? -1 : Convert.ToDecimal(row["TOTAL1"]);
                _objcls.total = (row["TOTAL"].ToString() == "N/A") ? -1 : Convert.ToDecimal(row["TOTAL"]);
                _objbll.Generate_CASSummary_PKG_RPT_CCAD_FAS(_objcls, _objdb);
            }
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + count.ToString() + "');", true);
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
            Hide_Details();
            Generate_Summary();
        }
        private void Filtering_zero()
        {
            Load_Master();
            var _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("test1") == null && o.Field<string>("test2") == null && o.Field<string>("test3") == null
                          select o;
            _dtresult = _filter.Any() ? _filter.CopyToDataTable() : _dtMaster.Clone();
            Load_Details();
            Generate_Summary();
        }
        protected void genPcd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdnpcd.Value)) Generate_Summary();

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
    }
}
