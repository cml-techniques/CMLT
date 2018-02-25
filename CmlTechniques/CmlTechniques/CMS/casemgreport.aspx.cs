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
    public partial class casemgreport : System.Web.UI.Page
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

                if (lblprj.Text == "11736" || lblprj.Text == "Traini")
                    lblnotitle.Text = "NO. OF CIRCUITS";

                if (lblprj.Text == "ASAO" || lblprj.Text=="ASAO1")
                    Generate_Summary1();
                else
                    Generate_Summary();
                drfed.Style.Add("display", "none");
                //Load_Summary();
            }
        }
        private void Set_Title()
        {
            if (lbldiv.Text == "1")
                lbltitle.Text = "Wings - " + lbltitle.Text;
            else if (lbldiv.Text == "2")
                lbltitle.Text = "Main - " + lbltitle.Text;
            else if (lbldiv.Text == "3")
                lbltitle.Text = "Technical - " + lbltitle.Text;
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

            ListItem item;
            item = drbuilding.Items.FindByText((string)Session["zone"]);
            if (item == null) drbuilding.Items.Insert(0, (string)Session["zone"]);

            item = drcategory.Items.FindByText((string)Session["cat"]);
            if (item == null) drcategory.Items.Insert(0, (string)Session["cat"]);

            item = drflevel.Items.FindByText((string)Session["flvl"]);
            if (item == null) drflevel.Items.Insert(0, (string)Session["flvl"]);


            item = drfed.Items.FindByText((string)Session["fed"]);
            if (item == null) drfed.Items.Insert(0, (string)Session["fed"]);

            item = drloc.Items.FindByText((string)Session["loc"]);
            if (item == null) drloc.Items.Insert(0, (string)Session["loc"]);


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

            if (lblprj.Text == "11784" && (Request.QueryString["sch"] != null))
            {
                _objcas.sch = Convert.ToInt32(Request.QueryString["sch"].ToString());

                if (Request.QueryString["sch"].ToString() == "30")
                {
                    lbltitle.Text = lbltitle.Text + " - Marketing Suite";
                }
            }
            else
            _objcas.sch = 7;
            _objcas.prj_code = lblprj.Text;
            if (lblprj.Text == "HMIM" || lblprj.Text=="14211")
                _objcas.sys = Convert.ToInt32(lbldiv.Text);
            else
                _objcas.sys = 0;

            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
            if (lblprj.Text == "11736" || lblprj.Text == "Traini")
            {
                if (lbldiv.Text == "1")
                {
                    var _result = _dtMaster.Select("b_z ='PMCW' OR b_z ='PMPW' OR b_z ='PMVW'");
                    _dtresult = _result.Any() ? _result.CopyToDataTable() : _dtMaster.Clone();
                }
                else if (lbldiv.Text == "2")
                {
                    var _result = _dtMaster.Select("b_z LIKE 'PMMB%' OR b_z='PMMV' OR b_z='PMST' OR b_z='PPP3' OR b_z='PPP4' OR b_z='PMMU' OR b_z='PMDW' ");
                    _dtresult = _result.Any() ? _result.CopyToDataTable() : _dtMaster.Clone();
                }
                else if (lbldiv.Text == "3")
                {
                    var _result = _dtMaster.Select("b_z ='PSEC' OR b_z='PMWT' OR b_z='PSWB' OR b_z='PSGC' OR b_z='Energy Centre' OR b_z='PSGS'");
                    _dtresult = _result.Any() ? _result.CopyToDataTable() : _dtMaster.Clone();
                }
                else if (lbldiv.Text == "4")
                    _dtresult = null;

            }
            else
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
            if (lblprj.Text == "11784" && (Request.QueryString["sch"] != null))
            {
                _objcas.sch = Convert.ToInt32(Request.QueryString["sch"].ToString());
            }
            else
            _objcas.sch = 7;
            _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
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
        decimal _tested1 = 0;
        decimal _tested2 = 0;
        decimal _tested3 = 0;
        decimal _total = 0;
        decimal _count = 0;
        decimal _sumry = 0;
        decimal _sumryqty = 0;
        protected void mygridsumm_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[7].Visible = false;
            if (lblprj.Text != "ASAO" && lblprj.Text != "Trial")
            {
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
                //if (e.Row.Cells[1].Text != "Total No. of Emergency Lights")
                //{
                //    _qty += Convert.ToDecimal(e.Row.Cells[2].Text);
                //    _total += Convert.ToDecimal(e.Row.Cells[5].Text);
                //    _tested1 += Convert.ToDecimal(e.Row.Cells[3].Text);
                //    _count += 1;
                //}
                _qty += Convert.ToDecimal(e.Row.Cells[2].Text);
                _total += Convert.ToDecimal(e.Row.Cells[7].Text);
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (e.Row.Cells[1].Text != "Emergency Lighting Central Battery Panel")
                    {
                        _sumry += (Convert.ToDecimal(e.Row.Cells[7].Text) * Convert.ToDecimal(e.Row.Cells[2].Text));
                        _sumryqty += Convert.ToDecimal(e.Row.Cells[2].Text);
                    }
                }
                _tested1 += Convert.ToDecimal(e.Row.Cells[3].Text);
                _tested2 += Convert.ToDecimal(e.Row.Cells[4].Text);
                _tested3 += Convert.ToDecimal(e.Row.Cells[5].Text);
                _count += 1;
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    e.Row.Cells[1].Text = "EQUIPMENT";
                    e.Row.Cells[3].Text = "PRE-COMM";
                    e.Row.Cells[4].Text = "COMM";
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "TOTAL";
                e.Row.Cells[2].Text = _qty.ToString();
                e.Row.Cells[3].Text = (Decimal.Round(_tested1)).ToString();
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    //_total = decimal.Round((_tested1 * 0.2m + _tested2 * 0.8m) * 100);
                    e.Row.Cells[4].Text = (Decimal.Round(_tested2)).ToString();
                    e.Row.Cells[5].Text = (Decimal.Round(_tested3)).ToString();
                    if (_sumryqty > 0)
                        e.Row.Cells[6].Text = Decimal.Round((_sumry / _sumryqty)).ToString() + '%';
                    else
                        e.Row.Cells[6].Text = "0%";
                }
                else
                {
                    _total = (_total / _count);
                    if (_total >= 99.5m && _total < 100m) _total = 99;
                    e.Row.Cells[6].Text = Decimal.Round(_total).ToString() + '%';
                }
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
        }
        private void Filtering(string _el1, string _el2, string _el3, string _el4,string _el5)
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
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 == "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where  o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 == "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 &&  o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("Loc") == _el5
                          select o;
            }
            _dtresult = _filter.Any() ? _filter.CopyToDataTable() : _dtMaster.Clone();
            Load_Details();
            if (lblprj.Text == "ASAO" || lblprj.Text=="ASAO1")
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
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;
                decimal _total = 0;
                int count = 0;
                int count_COT = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    _p7 += Convert.ToDecimal(_row["per_com7"].ToString());

                    //if (lblprj.Text == "11736" || lblprj.Text == "Traini")
                    //{
                    //    if (_row["cat"].ToString() == "ELBP" || _row["cat"].ToString() == "SIBP")
                    //    {
                    //        count_COT += 1;
                    //        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    //    }
                    //    else
                    //    {
                    //        count += Convert.ToInt32(_row["devices1"].ToString());

                    //    }
                    //}
                    //else
                    //{
                    //    count += Convert.ToInt32(_row["devices1"].ToString());
                    //    _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    //}
                    count_COT += 1;
                    count += Convert.ToInt32(_row["devices1"].ToString());
                    _p4 += Convert.ToDecimal(_row["per_com4"].ToString());

                }
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _drow[1] = count.ToString();
                    
                    if (row[0].ToString() == "Continuity/IR Test Complete")
                    {
                        _drow[2] = decimal.Round(_p1).ToString();
                        if (count > 0)
                            _total = (Convert.ToDecimal(_drow[2].ToString()) / count) * 100;
                    }
                    else if (row[0].ToString() == "Addressing")
                    {
                        _drow[2] = decimal.Round(_p2).ToString();
                        if (count > 0)
                            _total = (Convert.ToDecimal(_drow[2].ToString()) / count) * 100;
                    }
                    else if (row[0].ToString() == "Fault Testing")
                    {
                        _drow[2] = decimal.Round(_p3).ToString();
                        if (count > 0)
                            _total =(Convert.ToDecimal(_drow[2].ToString()) / count) * 100;
                    }
                    else if (row[0].ToString() == "Change Over Test")
                    { 
                        _drow[2] = decimal.Round(_p4).ToString();
                        if (lblprj.Text == "11736" || lblprj.Text == "Traini")
                        {
                            _drow[1] = count_COT.ToString();
                            if (count_COT > 0)
                                _total = (Convert.ToDecimal(_drow[2].ToString()) / count_COT) * 100;
                        }
                        else
                        {
                            if (count > 0)
                                _total = (Convert.ToDecimal(_drow[2].ToString()) / count) * 100;
                        }
                    }
                    else if (row[0].ToString() == "Lux Level Test")
                    {
                        _drow[2] = decimal.Round(_p5).ToString();
                        if (count > 0)
                            _total = (Convert.ToDecimal(_drow[2].ToString()) / count) * 100;
                    }
                    else if (row[0].ToString() == "Duration Test")
                    {
                        _drow[2] = decimal.Round(_p6).ToString();
                        if (lblprj.Text == "11736" || lblprj.Text == "Traini")
                        {
                            _drow[1] = count_COT.ToString();
                            if (count_COT > 0)
                                _total = (Convert.ToDecimal(_drow[2].ToString()) / count_COT) * 100;
                        }
                        else
                        {
                            if (count > 0)
                                _total = (Convert.ToDecimal(_drow[2].ToString()) / count) * 100;
                        }
                    }
                    else if (row[0].ToString() == "Pc Head End Test")
                    {
                        _drow[2] = decimal.Round(_p7).ToString();
                        if (count > 0)
                            _total = (Convert.ToDecimal(_drow[2].ToString()) / count) * 100;
                    }
                    if (_total >= 99.5m && _total < 100m) _total = 99;
                   
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = decimal.Round(_total).ToString();
                    _drow[6] = row[0].ToString();
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
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                
                decimal _total = 0;
                decimal _tested = 0;
                decimal _emg = 0;
                
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _qty = 0;
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _p8 = 0;
                    int count = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        //_p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        //_p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        //_p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        //_p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        //_p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                        _p8 += Convert.ToDecimal(_row["per_com8"].ToString());
                        count += Convert.ToInt32(_row["devices1"].ToString());
                        _qty += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    _per1 = _p1 / _qty;
                    //_per2 = (_p2 + _p3 + _p4 + _p5 + _p6 + _p7) / 6;
                    _per2 = _p2 / _qty;
                 //   _per3 = _per2 / _qty;
                    _tested += _per1;
                    _total = decimal.Round((_per1 * 0.2m + _per2 * 0.8m));
                    _emg += count;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = _qty.ToString();
                    _drow[2] = decimal.Round(_p1/100).ToString();
                    _drow[3] = decimal.Round(_p2/100).ToString();
                    _drow[4] = decimal.Round(_p8).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                //if (_emg != 0)
                //    _total = decimal.Round((_tested / _emg) * 100);
                //DataRow _drow1 = _dtsummary.NewRow();
                //_drow1[0] = "Total No. of Emergency Lights";
                //_drow1[1] = decimal.Round(_emg).ToString();
                //_drow1[2] = decimal.Round(_tested).ToString();
                //_drow1[3] = "0";
                //_drow1[4] = "0";
                //_drow1[5] = _total.ToString();
                //_drow1[6] = "";
                //_dtsummary.Rows.Add(_drow1);
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
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text,drloc.SelectedItem.Text);
        }
        protected void drcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["cat"] = drcategory.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text,drloc.SelectedItem.Text);
        }
        protected void drflevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["flvl"] = drflevel.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text,drloc.SelectedItem.Text);
        }
        protected void drfed_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["fed"] = drfed.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text,drloc.SelectedItem.Text);
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
                _objbll.Generate_CASSummary_PKG_RPT(_objcls, _objdb);
                //count += 1;
            }
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + count.ToString() + "');", true);
        }

        protected void print_Click(object sender, EventArgs e)
        {
            string _path = "";
            //Session["zone"] = drbuilding.SelectedItem.Value;
            //Session["flvl"] = drflevel.SelectedItem.Value;
            //Session["cat"] = drcategory.SelectedItem.Value;
            //Session["fed"] = drfed.SelectedItem.Value;
            Insert_Summary();
            //string _path ="Cas_Report.aspx?id=7_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value + "_Z" + (string)Session["zero"];
            if (lblprj.Text == "11784" && (Request.QueryString["sch"] != null))
            {

                _path = "Cas_Report.aspx?id=" + Request.QueryString["sch"].ToString() + "_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value +"_Z" + (string)Session["zero"] +"&Div=" + lbldiv.Text;
            }
            else  
            _path = "Cas_Report.aspx?id=7_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value + "_Z" + (string)Session["zero"] + "&Div=" + lbldiv.Text;


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
            Hide_Details();
            if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                Generate_Summary1();
            else
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
            if (lblprj.Text == "ASAO" || lblprj.Text=="ASAO1")
                Generate_Summary1();
            else
                Generate_Summary();
        }
        
    }
}
