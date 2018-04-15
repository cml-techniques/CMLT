using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Collections;
using System.Data;

namespace CmlTechniques.CMS
{
    public partial class casemgreport_pcd : System.Web.UI.Page  
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
                Load_TestNames();
                Hide_Details();

                Generate_Summary();
                drfed.Style.Add("display", "none");
                btnzero.Style.Add("display", "none");

                if (lblprj.Text == "AFV") Set_Title();
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
            _objcas.sch = 7;
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
        private void Load_TestNames()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = 7;
            _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
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



        protected void export_Click(object sender, EventArgs e)
        {
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



        decimal _qty = 0;
         decimal _pqty = 0; 
        decimal _tested1 = 0;
        decimal _total = 0;
        decimal _ptotal = 0;
        decimal _count = 0;

        decimal _qtyNa = 0;
        decimal _pqtyNa = 0;
        decimal _tested1Na = 0;
        decimal _totalNa = 0;
        decimal _ptotalNa = 0;  

        protected void mygridsumm_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();



                _qty += Convert.ToDecimal(e.Row.Cells[2].Text);
                _pqty += Convert.ToDecimal(e.Row.Cells[3].Text);
                _tested1 += Convert.ToDecimal(e.Row.Cells[4].Text);
                _total += Convert.ToDecimal(e.Row.Cells[6].Text);
                _ptotal += Convert.ToDecimal(e.Row.Cells[5].Text);


                if (e.Row.Cells[2].Text != "-1") e.Row.Cells[2].Text = e.Row.Cells[2].Text;
                else { e.Row.Cells[2].Text = "N/A"; _qtyNa += 1; }

                if (e.Row.Cells[3].Text != "-1") e.Row.Cells[3].Text = e.Row.Cells[3].Text;
                else { e.Row.Cells[3].Text = "N/A"; _pqtyNa += 1; }

                if (e.Row.Cells[4].Text != "-1") e.Row.Cells[4].Text = e.Row.Cells[4].Text;
                else { e.Row.Cells[4].Text = "N/A"; _tested1Na += 1; }

                if (e.Row.Cells[5].Text != "-1") e.Row.Cells[5].Text = e.Row.Cells[5].Text + "%";
                else { e.Row.Cells[5].Text = "N/A"; _ptotalNa += 1; }

                if (e.Row.Cells[6].Text != "-1") e.Row.Cells[6].Text = e.Row.Cells[6].Text + "%";
                else { e.Row.Cells[6].Text = "N/A"; _totalNa += 1; }

  

                 _count += 1;
 
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                if (_count == _qtyNa) _qty = -1;
                if (_count == _pqtyNa) _pqty = -1;  
                if (_count == _tested1Na) _tested1 = -1;
                if (_count == _ptotalNa) _ptotal = -1;
                if (_count == _totalNa) _total = -1;


                if (_qty != -1) e.Row.Cells[2].Text = _qty.ToString();
                else e.Row.Cells[2].Text = "N/A";


                if (_pqty != -1) e.Row.Cells[3].Text = _pqty.ToString();
                else e.Row.Cells[3].Text = "N/A";


                if (_tested1 != -1) e.Row.Cells[4].Text = _tested1.ToString();
                else e.Row.Cells[4].Text = "N/A";


                if (_pqty != -1) _ptotal = Decimal.Round((_pqty / _qty)*100,MidpointRounding.AwayFromZero);
                else _ptotal = -1;

                if (_tested1 != -1) _total = Decimal.Round((_tested1 / _qty)*100,MidpointRounding.AwayFromZero);
                else _total = -1;

               
                if (_ptotal != -1) e.Row.Cells[5].Text = _ptotal.ToString() + '%';
                else e.Row.Cells[5].Text = "N/A";

                if (_total != -1) e.Row.Cells[6].Text = _total.ToString() + '%';
                else e.Row.Cells[6].Text = "N/A";


                Session["Sum_Qty"] = _qty.ToString();
                Session["Sum_QtyPlanned1"] = _pqty.ToString();
                Session["Sum_Percom1"] = _tested1.ToString();

                Session["Sum_Poverall"] = _ptotal.ToString();
                Session["Sum_Overall"] = _total.ToString();



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
            e.Row.Cells[21].Visible = false;


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[21].Text == "-1") { e.Row.Cells[8].Text = "N/A"; }
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
                _dtsummary.Columns.Add("CODE", typeof(string));

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
                decimal _total = 0;
                decimal _Ptotal = 0;    
                int count1 = 0;
                int count2 = 0;
                int count3 = 0;
                int count4 = 0;
                int count5 = 0;
                int count6 = 0;
                int count7 = 0;
                //int _countNA = 0;

                int _qtyplanned1 = 0;
                int _qtyplanned2 = 0;
                int _qtyplanned3 = 0;
                int _qtyplanned4 = 0;
                int _qtyplanned5 = 0;
                int _qtyplanned6 = 0;
                int _qtyplanned7 = 0;        

                int count = 0;
                int Pna = 0;
                int Na_count1 = 0;
                int Na_count2 = 0;
                int Na_count3 = 0;
                int Na_count4 = 0;
                int Na_count5 = 0;
                int Na_count6 = 0;
                int Na_count7 = 0;



                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    pcdate = defaultvalue;

                    if (Convert.ToDecimal(_row["per_com8"].ToString()) != -1)
                    {
                        if (_row["pcdate"] != null && _row["pcdate"].ToString() != "")
                        {
                            pcdate = DateTime.ParseExact(_row["pcdate"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        }
                    }
                    else
                        Pna = -1;

                    if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        count1 += Convert.ToInt32(_row["devices1"].ToString());

                            if (pcdate <= todaysDate) _qtyplanned1 += 1;

                    }
                    else
                        Na_count1 += 1;

                    if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                    {
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        count2 += Convert.ToInt32(_row["devices1"].ToString());

                          if (pcdate <= todaysDate) _qtyplanned2 += 1;
                    }
                    else
                        Na_count2 += 1;

                    if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                    {
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        count3 += Convert.ToInt32(_row["devices1"].ToString());

                          if (pcdate <= todaysDate) _qtyplanned3 += 1;
                    }
                    else
                        Na_count3 += 1;

                    if (Convert.ToDecimal(_row["per_com4"].ToString()) != -1)
                    {
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        count4 += Convert.ToInt32(_row["devices1"].ToString());

                          if (pcdate <= todaysDate) _qtyplanned4 += 1;
                    }
                    else
                        Na_count4 += 1;

                    if (Convert.ToDecimal(_row["per_com5"].ToString()) != -1)
                    {
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        count5 += Convert.ToInt32(_row["devices1"].ToString());

                          if (pcdate <= todaysDate) _qtyplanned5 += 1;
                    }
                    else
                        Na_count5 += 1;

                    if (Convert.ToDecimal(_row["per_com6"].ToString()) != -1)
                    {
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        count6 += Convert.ToInt32(_row["devices1"].ToString());

                          if (pcdate <= todaysDate) _qtyplanned6 += 1;
                    }
                    else
                        Na_count6 += 1;

                    if (Convert.ToDecimal(_row["per_com7"].ToString()) != -1)
                    {
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                        count7 += Convert.ToInt32(_row["devices1"].ToString());

                          if (pcdate <= todaysDate) _qtyplanned7 += 1;
                    }
                    else
                        Na_count7 += 1;


                    count += 1;

                }


                if (Na_count1 == count) { _p1 = -1; count1 = -1; _qtyplanned1 = -1; }
                if (Na_count2 == count) { _p2 = -1; count2= -1; _qtyplanned2 = -1; }
                if (Na_count3 == count) { _p3 = -1; count3 = -1; _qtyplanned3 = -1; }
                if (Na_count4 == count) { _p4 = -1; count4 = -1; _qtyplanned4 = -1; }
                if (Na_count5 == count) { _p5 = -1; count5 = -1; _qtyplanned5 = -1; }
                if (Na_count6 == count) { _p6 = -1; count6 = -1; _qtyplanned6 = -1; }
                if (Na_count7 == count) { _p7 = -1; count7 = -1; _qtyplanned7 = -1; }

                if (Pna == count) { _qtyplanned1 = -1; _qtyplanned2 = -1; _qtyplanned3 = -1; _qtyplanned4 = -1; _qtyplanned4 = -1; _qtyplanned5 = -1; _qtyplanned6 = -1; _qtyplanned7 = -1; }

                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                   


                    if (row[0].ToString() == "Continuity/IR Test Complete")
                    {
                        _drow[3] = decimal.Round(_p1).ToString();
                        _drow[1] = count1.ToString();
                        _drow["QTY_PLANNED"] = _qtyplanned1.ToString();
                        if (count1 > 0)
                        {
                            _total = decimal.Round((Convert.ToDecimal(_drow[3].ToString()) / count1) * 100);
                            _Ptotal = decimal.Round(((Convert.ToDecimal(_qtyplanned1) / Convert.ToDecimal(_drow[1].ToString())) * 100), MidpointRounding.AwayFromZero);
                        }
                        if (_p1 == -1) _total = -1;
                        if (_qtyplanned1 == -1) _Ptotal = -1;

                    }
                    else if (row[0].ToString() == "Addressing")
                    {
                        _drow[3] = decimal.Round(_p2).ToString();
                        _drow[1] = count2.ToString();
                        _drow["QTY_PLANNED"] = _qtyplanned2.ToString();
                        if (count2 > 0)
                        {
                            _total = decimal.Round((Convert.ToDecimal(_drow[3].ToString()) / count2) * 100);
                            _Ptotal = decimal.Round(((Convert.ToDecimal(_qtyplanned2) / Convert.ToDecimal(_drow[1].ToString())) * 100), MidpointRounding.AwayFromZero);
                        }
                        if (_p2 == -1) _total = -1;
                        if (_qtyplanned2 == -1) _Ptotal = -1;
                    }
                    else if (row[0].ToString() == "Fault Testing")
                    {
                        _drow[3] = decimal.Round(_p3).ToString();
                        _drow[1] = count3.ToString();
                        _drow["QTY_PLANNED"] = _qtyplanned3.ToString();
                        if (count3 > 0)
                        {
                            _total = decimal.Round((Convert.ToDecimal(_drow[3].ToString()) / count3) * 100);
                            _Ptotal = decimal.Round(((Convert.ToDecimal(_qtyplanned3) / Convert.ToDecimal(_drow[1].ToString())) * 100), MidpointRounding.AwayFromZero);
                        }
                        if (_p3 == -1) _total = -1;
                        if (_qtyplanned3 == -1) _Ptotal = -1;
                    }
                    else if (row[0].ToString() == "Change Over Test")
                    {
                        _drow[3] = decimal.Round(_p4).ToString();
                        _drow[1] = count4.ToString();
                        _drow["QTY_PLANNED"] = _qtyplanned4.ToString();
                        if (count4 > 0)
                        {
                            _total = decimal.Round((Convert.ToDecimal(_drow[3].ToString()) / count4) * 100);
                            _Ptotal = decimal.Round(((Convert.ToDecimal(_qtyplanned4) / Convert.ToDecimal(_drow[1].ToString())) * 100), MidpointRounding.AwayFromZero);
                        }
                        if (_p4 == -1) _total = -1;
                        if (_qtyplanned4 == -1) _Ptotal = -1;
                    }

                    else if (row[0].ToString() == "Lux Level Test")
                    {
                        _drow[3] = decimal.Round(_p5).ToString();
                        _drow[1] = count5.ToString();
                        _drow["QTY_PLANNED"] = _qtyplanned5.ToString();
                        if (count5 > 0)
                        {
                            _total = decimal.Round((Convert.ToDecimal(_drow[3].ToString()) / count5) * 100);
                            _Ptotal = decimal.Round(((Convert.ToDecimal(_qtyplanned5) / Convert.ToDecimal(_drow[1].ToString())) * 100), MidpointRounding.AwayFromZero);
                        }
                        if (_p5 == -1) _total = -1;
                        if (_qtyplanned5 == -1) _Ptotal = -1;
                    }
                    else if (row[0].ToString() == "Duration Test")
                    {
                        _drow[3] = decimal.Round(_p6).ToString();
                        _drow[1] = count6.ToString();
                        _drow["QTY_PLANNED"] = _qtyplanned6.ToString();
                        if (count6 > 0)
                        {
                            _total = decimal.Round((Convert.ToDecimal(_drow[3].ToString()) / count6) * 100);
                            _Ptotal = decimal.Round(((Convert.ToDecimal(_qtyplanned6) / Convert.ToDecimal(_drow[1].ToString())) * 100), MidpointRounding.AwayFromZero);
                        }
                        if (_p6 == -1) _total = -1;
                        if (_qtyplanned1 == -1) _Ptotal = -1;
                    }
                    else if (row[0].ToString() == "PC Head End Test")
                    {
                        _drow[3] = decimal.Round(_p7).ToString();
                        _drow[1] = count7.ToString();
                        _drow["QTY_PLANNED"] = _qtyplanned7.ToString();
                        if (count7 > 0)
                        {
                            _total = decimal.Round((Convert.ToDecimal(_drow[3].ToString()) / count7) * 100);
                            _Ptotal = decimal.Round(((Convert.ToDecimal(_qtyplanned7) / Convert.ToDecimal(_drow[1].ToString())) * 100), MidpointRounding.AwayFromZero);
                        }
                        if (_p7 == -1) _total = -1;
                        if (_qtyplanned7 == -1) _Ptotal = -1;
                    }

                   

                    _drow["SYS_NAME"] = row[0].ToString();                 
                    _drow["TOTAL_PLANNED"] = _Ptotal.ToString();
                    _drow["TOTAL"] = _total.ToString();
                    _drow["CODE"] = row[0].ToString();


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
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text);
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
                _objcls.per_com2 = Convert.ToDecimal(row["TOTAL_PLANNED"].ToString());

                _objcls.total = Convert.ToDecimal(row["TOTAL"].ToString());

                _objcls.cate = row["CODE"].ToString();
                _objcls.quantity = Convert.ToInt32(row["QTY"].ToString());
                _objcls.compl1 = Convert.ToInt32(row["QTY_PLANNED"].ToString());


                _objbll.Generate_CASSummary_PKG_RPT_ASAO(_objcls, _objdb);
            }
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + count.ToString() + "');", true);
        }

        protected void print_Click(object sender, EventArgs e)
        {
            //Session["zone"] = drbuilding.SelectedItem.Value;
            //Session["flvl"] = drflevel.SelectedItem.Value;
            //Session["cat"] = drcategory.SelectedItem.Value;
            //Session["fed"] = drfed.SelectedItem.Value;
            Insert_Summary();
            //string _path ="Cas_Report.aspx?id=7_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value + "_Z" + (string)Session["zero"];
            string _path = "Cas_Report.aspx?id=7_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value + "_Z" + (string)Session["zero"] + "&Div=" + lbldiv.Text;


            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.open('" + _path + "');", true);
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
                          where o.Field<string>("test1") == null && o.Field<string>("test2") == null && o.Field<string>("test3") == null && o.Field<string>("test4") == null && o.Field<string>("test5") == null && o.Field<string>("test6") == null && o.Field<string>("test7") == null
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
