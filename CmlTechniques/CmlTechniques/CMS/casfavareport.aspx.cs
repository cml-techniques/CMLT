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
    public partial class casfavareport : System.Web.UI.Page
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
                string _prm = Request.QueryString[0].ToString();
                if (_prm.Contains("_D") == true)
                {
                    lblsch.Text = _prm.Substring(0, _prm.IndexOf("_P"));
                    lblprj.Text = _prm.Substring(_prm.IndexOf("_P") + 2, _prm.IndexOf("_D") - (_prm.IndexOf("_P") + 2));
                    lbldiv.Text = _prm.Substring(_prm.IndexOf("_D") + 2);
                    
                }
                else
                {
                    lblsch.Text = _prm.Substring(0, _prm.IndexOf("_P"));
                    lblprj.Text = _prm.Substring(_prm.IndexOf("_P") + 2);
                }

                //Populate_view();
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
                
                Load_TestNames();
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (lblsch.Text == "31")
                        Summary31();
                    else
                        Generate_Summary_ASAO();
                }
                else if (lblprj.Text == "11736")
                    Generate_Summary2();
                else
                    Generate_Summary();
                drfed.Style.Add("display", "none");
                if (lblsch.Text == "10")
                {
                    lblhead.Text = "CAS ELV1 Fire Alarm & Voice Evacuation Commissioning Activity Schedule";
                    Set_Title();
                }
                else if (lblsch.Text == "28")
                {
                    lblhead.Text = "CAS ELV10 Public Address System Commissioning Activity Schedule";
                    Set_Title();
                }
                //Load_Summary();
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
        private void Load_TestNames()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = 10;
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
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
            if (lblprj.Text == "11736")
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
                else
                    _dtresult = _dtMaster;

            }
            else
                _dtresult = _dtMaster;
            _dtfilter = _dtresult;
            //_summary = _dtMaster;
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
            string _path = "";
            //Session["zone"] = drbuilding.SelectedItem.Value;
            //Session["flvl"] = drflevel.SelectedItem.Value;
            //Session["cat"] = drcategory.SelectedItem.Value;
            //Session["fed"] = drfed.SelectedItem.Value;
            Insert_Summary();
            if (lblprj.Text == "11784" && (lblsch.Text != null))
            {
                _path = "Cas_Report.aspx?id=" + lblsch.Text+ "_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value + "_Z" + (string)Session["zero"] + "&Div=" + lbldiv.Text;
            }
            else
             _path = "Cas_Report.aspx?id=10_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value + "_Z" + (string)Session["zero"];
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
           if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
           {
               if (lblsch.Text == "31")
                   Summary31();
               else
                   Generate_Summary_ASAO();
           }
           else if (lblprj.Text == "11736")
               Generate_Summary2();
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
                decimal _devices = 0;
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
                    int idx = 0;
                    decimal _qty = 0;
                    if ((string)Session["project"] != "12710")
                    {
                        if (row[0].ToString() == "Circuit IR Test")
                        {

                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC"
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                        }
                        else if (row[0].ToString() == "Device/Address Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA"
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                        }
                        else if (row[0].ToString() == "Sound Level Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC"
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                        }
                        else if (row[0].ToString() == "Interface Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA"
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Fire Telephone Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "FTP"
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Battery Autonomy Test")
                        {
                            if (lblprj.Text == "BCC1")
                            {
                                _result = from _data in _dtresult.AsEnumerable()
                                          where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP"
                                          select _data;
                            }
                            else if (lblprj.Text == "11736")
                            {
                                _result = from _data in _dtresult.AsEnumerable()
                                          where _data.Field<string>("Cat") == "FACP"
                                          select _data;
                            }
                            else
                            {
                                _result = from _data in _dtresult.AsEnumerable()
                                          where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA"
                                          select _data;
                            }
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                _qty += 1;
                            }
                            if(lblprj.Text=="BCC1" || lblprj.Text=="11736")
                                _drow[1] = Decimal.Round(_qty).ToString();
                            else
                                _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Graphic Test")
                        {
                            if (lblprj.Text == "BCC1")
                            {
                                _result = from _data in _dtresult.AsEnumerable()
                                          where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "PAVA"
                                          select _data;
                            }
                            else
                            {
                                _result = from _data in _dtresult.AsEnumerable()
                                          where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA"
                                          select _data;
                            }
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                _qty += 1;
                            }
                            if (lblprj.Text == "BCC1")
                                _drow[1] = Decimal.Round(_qty).ToString();
                            else
                                _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Cause Effect Test")
                        {
                            if (lblprj.Text == "BCC1")
                            {
                                _result = from _data in _dtresult.AsEnumerable()
                                          where _data.Field<string>("Cat") == "CE"
                                          select _data;
                            }
                            else
                            {
                                _result = from _data in _dtresult.AsEnumerable()
                                          where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA"
                                          select _data;
                            }
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                _qty += 1;

                            }
                            if (lblprj.Text == "BCC1")
                                _drow[1] = Decimal.Round(_qty).ToString();
                            else
                                _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                            //_drow[1] = "0";
                            //_drow[2] = "0";

                        }
                        else
                        {
                            _drow[1] = "0";
                            _drow[2] = "0";
                        }
                        if (_drow[1].ToString() != "0")
                        {

                            _total = (Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100);
                            if (_total >= 99.5m && _total < 100m) _total = 99;

                        }
                        else
                            _total = 0;
                    }
                    else
                    {
                        if (row[0].ToString() == "Circuit IR Test")
                        {

                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                        }
                        else if (row[0].ToString() == "Device/Address Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                        }
                        else if (row[0].ToString() == "Sound Level Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                        }
                        else if (row[0].ToString() == "Interface Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Fire Telephone Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "FTP"
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Battery Autonomy Test")
                        {
                           
                                _result = from _data in _dtresult.AsEnumerable()
                                          where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                          select _data;
                           
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                //_count += 1;
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Graphic Test")
                        {

                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                      select _data;

                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Cause Effect Test")
                        {

                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                      select _data;

                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());

                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                            //_drow[1] = "0";
                            //_drow[2] = "0";

                        }
                        else
                        {
                            _drow[1] = "0";
                            _drow[2] = "0";
                        }
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                    }


                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = Decimal.Round(_total).ToString();
                    _drow[6] = "";
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
                //decimal _p1 = 0;
                //decimal _p2 = 0;
                //decimal _p3 = 0;
                //decimal _p4 = 0;
                //decimal _p5 = 0;
                //decimal _p6 = 0;
                //decimal _p7 = 0;
                //decimal _total = 0;

                decimal _devices = 0;
                decimal _device_tested=0;
                decimal _tested = 0;
                decimal _interface = 0;
                decimal _interface_tested = 0;
                decimal _total = 0;
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
                    int count = 0;
                    decimal _qty = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        count += Convert.ToInt32(_row["devices2"].ToString());
                        _qty += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    //if (_p1 != 0)
                    //{
                    //    if (row.col3.ToString() == "FAL")
                    //        _per1 = (_p1 / Convert.ToDecimal(count)) * 100;
                    //    else
                    //        _per1 = (_p1 / Convert.ToDecimal(_qty)) * 100;
                    //}
                    //if (_p2 != 0)
                    //{
                    //    if (row.col3.ToString() == "FAL")
                    //        _per2 = (_p2 / Convert.ToDecimal(count)) * 100;
                    //    else
                    //        _per2 = (_p2 / Convert.ToDecimal(_qty)) * 100;
                    //}
                    if (_qty > 0)
                    {
                        _per1 = (_p1 / Convert.ToDecimal(_qty)) * 100;
                        _per2 = (_p2 / Convert.ToDecimal(_qty)) * 100;
                    }
                    _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)));
                    _devices += count;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    //if (row.col3.ToString() == "FAL")
                    //    _drow[1] = count.ToString();
                    //else
                    _drow[1] = _qty.ToString();
                    _drow[2] = decimal.Round(_p1).ToString();
                    _drow[3] = decimal.Round(_p2).ToString();
                    _drow[4] = decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                
                //DataRow _drow1 = _dtsummary.NewRow();
                //if (lblsch.Text == "31")
                //{
                //    _drow1[0] = "Voice Alarm Devices";
                //    if (_devices != 0)
                //        _total = decimal.Round((_tested / _devices) * 100);
                //    _drow1[2] = decimal.Round(_tested).ToString();
                //}
                //else
                //{
                //    _drow1[0] = "No. of Devices";
                //    if (_devices != 0)
                //        _total = decimal.Round((_device_tested / _devices) * 100);
                //    _drow1[2] = decimal.Round(_device_tested).ToString();
                //}
                //_drow1[1] = decimal.Round(_devices).ToString();
               
                //_drow1[3] = _total.ToString();
                //_dtsummary.Rows.Add(_drow1);
                //DataRow _drow2 = _dtsummary.NewRow();
                //if (lblsch.Text == "10")
                //{
                //    _drow2[0] = "No. of Interfaces";
                //    if (_interface != 0)
                //        _total = decimal.Round((_interface_tested / _interface) * 100);
                //    _drow2[1] = decimal.Round(_interface).ToString();
                //    _drow2[2] = decimal.Round(_interface_tested).ToString();
                //    _drow2[3] = _total.ToString();
                //    _dtsummary.Rows.Add(_drow2);
                //}
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
                decimal _p1 = 0;
                decimal _devices = 0;
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
                    int idx = 0;
                    decimal _qty = 0;
                    
                        if (row[0].ToString() == "Circuit IR Test")
                        {

                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "DRS" || _data.Field<string>("Cat") == "FARP" 
                                      select _data;
                            decimal _intrface = 0;
                            decimal _panel = 0;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                if (_row["Cat"].ToString() == "FAL")
                                {
                                    if (IsNumeric(_row["devices1"].ToString()) == true)
                                        _intrface += Convert.ToInt32(_row["devices1"].ToString());
                                }
                                else if (_row["Cat"].ToString() == "FARP")
                                    _panel += 1;
                            }
                            _devices = _devices + _intrface + _panel;
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                        }
                        else if (row[0].ToString() == "Device/Address Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FAL" 
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                        }
                        else if (row[0].ToString() == "Sound Level Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "PAVA"
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                        }
                        else if (row[0].ToString() == "Interface Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FAL"
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Fire Telephone Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FTP"
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Disabled Refuge")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "DRS"
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Fire Alarm Repeater Panel")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FARP"
                                      select _data;
                            int _panel = 0;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                //if (IsNumeric(_row["devices2"].ToString()) == true)
                                //    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                _panel += 1;
                            }
                            _drow[1] = Decimal.Round(_panel).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Battery Autonomy Test")
                        {

                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FAVP" || _data.Field<string>("Cat") == "DRS" || _data.Field<string>("Cat") == "FTP" 
                                      select _data;
                            int _panel = 0;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                _panel += 1;
                            }
                            _drow[1] = Decimal.Round(_panel).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Graphic Test")
                        {

                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FAVP" || _data.Field<string>("Cat") == "FTP"
                                      select _data;
                            int _panel = 0;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                _panel += 1;
                                   
                            }
                            _drow[1] = Decimal.Round(_panel).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Cause Effect Test")
                        {

                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FAVP" 
                                      select _data;
                            int _panel = 0;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                _panel += 1;
                            }
                            _drow[1] = Decimal.Round(_panel).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                            //_drow[1] = "0";
                            //_drow[2] = "0";

                        }
                        else
                        {
                            _drow[1] = "0";
                            _drow[2] = "0";
                        }
                        if (_drow[1].ToString() != "0")
                        {
                            _total =(Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100);
                            if (_total >= 99.5m && _total < 100m) _total = 99;
                        }
                        else
                            _total = 0;
                   

                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] =  Decimal.Round(_total).ToString();
                    _drow[6] = "";
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
        private void Generate_Summary_ASAO()
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
                decimal _devices = 0;
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
                    int idx = 0;
                    decimal _qty = 0;
                    decimal _weighting = 0;
                    if (row[0].ToString() == "Circuit IR Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTC"
                                  select _data;
                        decimal _intrface = 0;
                        decimal _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.15m;
                    }
                    else if (row[0].ToString() == "Device/Address Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTC"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.6m;
                    }
                    else if (row[0].ToString() == "Sound Level Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "NAC"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.02m;
                    }
                    else if (row[0].ToString() == "Interface Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAL"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                            if (IsNumeric(_row["devices1"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices1"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.13m;
                    }
                    
                    else if (row[0].ToString() == "Battery Autonomy Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                            _panel += 1;
                        }
                        _drow[1] = Decimal.Round(_panel).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.03m;

                    }
                    else if (row[0].ToString() == "Graphic Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                            _panel += 1;

                        }
                        _drow[1] = Decimal.Round(_panel).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.02m;
                    }
                    else if (row[0].ToString() == "Cause Effect Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                            _panel += 1;
                        }
                        _drow[1] = Decimal.Round(_panel).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.05m;

                    }
                    else
                    {
                        _drow[1] = "0";
                        _drow[2] = "0";
                    }
                    
                    _drow[3] = "0";
                    _drow[4] = decimal.Round(_weighting, 0).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = "";
                    if (Convert.ToDecimal(_drow[1].ToString()) > 0)
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
        private void Summary31()
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
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
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
                    int count = 0;
                    decimal _qty = 0;
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        //_p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        //_p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        //_p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        //_p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                        count += Convert.ToInt32(_row["devices2"].ToString());
                        //_interface += Convert.ToInt32(_row["devices1"].ToString());
                        //if (IsNumeric(_row["test2"].ToString()) == true)
                        //    _device_tested += Convert.ToDecimal(_row["test2"].ToString());
                        //if (IsNumeric(_row["test4"].ToString()) == true)
                        //    _interface_tested += Convert.ToDecimal(_row["test4"].ToString());
                        _qty += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    if (_p1 != 0)
                    {
                        if (row.col3.ToString() == "VAC")
                            _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
                        else
                            _per1 = Decimal.Round(_p1 / Convert.ToDecimal(_qty), 2);
                    }
                    if (_p2 != 0)
                    {
                        if (row.col3.ToString() == "VAC")
                            _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
                        else
                            _per2 = Decimal.Round(_p2 / Convert.ToDecimal(_qty), 2);
                    }
                    _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    if (row.col3.ToString() == "VAC")
                        _drow[1] = count.ToString();
                    else
                        _drow[1] = _qty.ToString();
                    _drow[2] = decimal.Round(_p1).ToString();
                    _drow[3] = decimal.Round(_p2).ToString();
                    _drow[4] = decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();

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
                _objcls.per_com1 = Convert.ToDecimal(row["PER_COMPLETED"].ToString());
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
        decimal _tested1 = 0;
        decimal _tested2 = 0;
        decimal _rows = 0;
        decimal _overall = 0;
        decimal _sumry = 0;
        decimal _sumryqty = 0;
        protected void mygridsumm_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            if (lblprj.Text == "ASAO" && lblsch.Text == "31")
            {
                e.Row.Cells[4].Visible = true;
                e.Row.Cells[5].Visible = true;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
                _qty += Convert.ToDecimal(e.Row.Cells[2].Text);
                _tested += Convert.ToDecimal(e.Row.Cells[3].Text);
                
                _rows += 1;
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (lblsch.Text == "31")
                    {
                        _sumry += Convert.ToDecimal(e.Row.Cells[7].Text) * Convert.ToDecimal(e.Row.Cells[2].Text);
                        _sumryqty += Convert.ToDecimal(e.Row.Cells[2].Text);
                    }
                    else
                    {
                        _overall += Convert.ToDecimal(e.Row.Cells[5].Text);
                    }
                }
                else
                    _overall += Convert.ToDecimal(e.Row.Cells[7].Text);
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (lblprj.Text == "ASAO" && lblsch.Text == "31")
                {
                    e.Row.Cells[3].Text = "TOTAL PRE-COMMISSIONED";
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "TOTAL";
                e.Row.Cells[2].Text = _qty.ToString();
                e.Row.Cells[3].Text = _tested.ToString();
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (lblsch.Text == "31")
                    {
                        e.Row.Cells[4].Text = _tested1.ToString();
                        e.Row.Cells[5].Text = _tested2.ToString();
                       // decimal _total = Decimal.Round((((_tested * 0.2m) + (_tested1 * 0.8m)) / _qty) * 100);
                        e.Row.Cells[6].Text = Decimal.Round(_sumry/_sumryqty).ToString() + '%';
                    }
                    else
                    {
                        ////
                        //
                        //if(_rows>0)
                        e.Row.Cells[6].Text = Decimal.Round(_overall).ToString() + '%';
                        //else
                        //    e.Row.Cells[6].Text = _qty.ToString() + '%';
                    }
                }
                else
                {
                    if (_qty != 0)
                    {
                       _tested= (_tested / _qty) * 100;
                       if (_tested >= 99.5m && _tested < 100m) _tested = 99;
                        e.Row.Cells[6].Text = Decimal.Round(_tested).ToString() + '%';
                    }
                    else
                        e.Row.Cells[6].Text = _qty.ToString() + '%';
                }
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
            {
                if (lblsch.Text == "31")
                    Summary31();
                else
                    Generate_Summary_ASAO();
            }
            else if (lblprj.Text == "11736")
                Generate_Summary2();
            else
                Generate_Summary();
        }
        private void Filtering_zero()
        {
            Load_Master();
            var _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("test1") == null && o.Field<string>("test2") == null && o.Field<string>("test3") == null && o.Field<string>("test4") == null && o.Field<string>("test5") == null && o.Field<string>("test6") == null && o.Field<string>("test7") == null && o.Field<string>("test8") == null && o.Field<string>("test9") == null 
                          select o;
            _dtresult = _filter.Any() ? _filter.CopyToDataTable() : _dtMaster.Clone();
           Load_Details();
           if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
           {
               if (lblsch.Text == "31")
                   Summary31();
               else
                   Generate_Summary_ASAO();
           }
           else if (lblprj.Text == "11736")
               Generate_Summary2();
           else
               Generate_Summary();
        }
        public static bool IsNumeric(object Expression)
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
    }
}
