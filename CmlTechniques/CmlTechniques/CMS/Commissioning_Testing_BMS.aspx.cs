using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Data;

namespace CmlTechniques.CMS
{
    public partial class Commissioning_Testing_BMS : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtfilter;
        public static DataTable _dtresult;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                //Session["project"] = _prm.Substring(0, _prm.IndexOf("_S"));
                //Session["sch"] = _prm.Substring(_prm.IndexOf("_S") + 2);
                lbluid.Text = (string)Session["uid"];
                lblprj.Text = _prm.Substring(0, _prm.IndexOf("_S"));

                //tdiv.Visible = false; ddiv.Visible = false; odiv.Visible = false;
                //if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                //{
                //    lblsch.Text = _prm.Substring(_prm.IndexOf("_S") + 2, _prm.IndexOf("_D") - (_prm.IndexOf("_S") + 2));
                //    lbldiv.Text = _prm.Substring(_prm.IndexOf("_D") + 2);
                //    tdiv.Visible = true; ddiv.Visible = true; odiv.Visible = true;
                //}
                //else

                if (lblprj.Text == "14211" || lblprj.Text=="HMIM" || lblprj.Text=="HMHS")
                {
                    lblsch.Text = _prm.Substring(_prm.IndexOf("_S") + 2, _prm.IndexOf("_F") - (_prm.IndexOf("_S") + 2));
                    lbldiv.Text = _prm.Substring(_prm.IndexOf("_F") + 2);

                }
                else
                    lblsch.Text = _prm.Substring(_prm.IndexOf("_S") + 2);


                settings();
                Load_Master();
                Session["filter"] = "no";
                Session["zone"] = "All";
                Session["flvl"] = "All";
                Session["cat"] = "All";
                Session["fed"] = "All";
                Session["loc"] = "All";
                Load_InitialData();
                //Load_Filtering_Elements();
                Hide_Details();


                // _exp = false;
            }
        }
        protected void settings()
        {

            lblhead.Text = "CAS ELV2 Building Management System Commissioning Activity Schedule";

            lbl3.Text = "SYSTEM CONTROLLED/ MONITORED BY DDC";
            lbnum.Text = "NO.OF SYSTEM REQUIRED LOOP TUNING";

            if (lblprj.Text == "14211" || lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
            {
                lbl1.Text = "FED FROM ";
                lbl2.Text = "NO.OF POINTS";
                lbl4.Text = "NO.OF DEVICES REQUIRED CALIBRATION";

            }
            else
            {
                if (lblsch.Text == "20" || lblsch.Text == "32")
                {
                    lbl1.Text = "NO.OF POINTS";
                    lbl2.Text = "NO.OF DEVICES REQUIRED CALIBRATION";
                    lbl4.Text = "NO.OF SYSTEM FOR SEQ. OF OP.";
                }
            }
            

        }
        void _ReadCookies()
        {
            if (Request.Browser.Cookies)
            {
                if (Request.Cookies["uid"] != null)
                {
                    Session["uid"] = Server.HtmlEncode(Request.Cookies["uid"].Value);
                }
                if (Request.Cookies["project"] != null)
                {
                    Session["project"] = Server.HtmlEncode(Request.Cookies["project"].Value);
                }
                if (Request.Cookies["sch"] != null)
                {
                    Session["sch"] = Server.HtmlEncode(Request.Cookies["sch"].Value);
                }
                if (Request.Cookies["srv"] != null)
                {
                    Session["srv"] = Server.HtmlEncode(Request.Cookies["srv"].Value);
                }
            }
        }
        void _Create_Cookies()
        {
            if (Request.Browser.Cookies)
            {
                HttpCookie _CookieSch = new HttpCookie("sch");
                _CookieSch.Value = lblsch.Text;
                _CookieSch.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_CookieSch);
                HttpCookie _CookieSrv = new HttpCookie("srv");
                _CookieSrv.Value = (string)Session["srv"];
                _CookieSrv.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_CookieSrv);

            }
            else
                return;
        }
        private void Load_Master()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32(lblsch.Text);
            _objcas.prj_code = lblprj.Text;

            if (lblprj.Text == "HMIM" || lblprj.Text == "14211" || lblprj.Text=="HMHS")
                _objcas.sys = Convert.ToInt32(lbldiv.Text);
            else
                _objcas.sys = 0;

            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);

            _dtresult = _dtMaster;
            _dtfilter = _dtresult;
        }
        private void Load_InitialData()
        {
            if (_dtresult == null) return;
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
            //_exp = true;
        }
        void SetCheckedBoxChecked(TextBox txt, System.Web.UI.HtmlControls.HtmlInputCheckBox chk)
        {
            //if (txt.Text == "N/A") chk.Checked = true;
            chk.Checked = (txt.Text == "N/A" ? true : false);
            txt.Enabled = (chk.Checked ? false : true);
        }
        protected void mydetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView _mydetails = (GridView)gvRow.FindControl("mydetails");
            int _idx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = _mydetails.Rows[_idx];
            //int index = gvRow.RowIndex;
            TableCell _item1 = _srow.Cells[13];
            TableCell _cat = _srow.Cells[4];
            TableCell _sys_name = _srow.Cells[15];
            TableCell _eref = _srow.Cells[2];
            string _title = "PACKAGE NAME : " + _sys_name.Text + ", ENG.REF : " + _eref.Text;
            // TableCell _item3 = _srow.Cells[2];
            //string _file = _item.Text;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _file + "');", true);
            Session["casid"] = _item1.Text;
            Session["idx"] = _idx.ToString();
            Session["cat"] = _cat.Text;
            //arrange_testing();
            // ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('I'm Here!');", true);
            // Config_TestLabel();
            Load_cassheet_details();
            if (lblsch.Text == "20") {
                if (lblprj.Text == "14211" || lblprj.Text=="HMIM" || lblprj.Text=="HMHS")
                {
                    btnDummy_ModalPopupExtender20a.Show(); _20albl.Text = _title;
                }
                else                
                btnDummy_ModalPopupExtender14.Show(); _20lbl.Text = _title;
            }
        }
        protected void mydetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
            //e.Row.Cells[0].Enabled = false;
            //if (e.Row.Cells[1].Text != "") return;
            //if (e.Row.Cells[0].Text != "")
            //    e.Row.Cells[0].Text = "hai" + e.Row.Cells[0].Text;
            e.Row.Cells[1].Text = (e.Row.DataItemIndex + 1).ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[2].Attributes.Add("style", "word-wrap:break-word");
                //e.Row.Cells[3].Attributes.Add("style", "word-wrap:break-word");
                //e.Row.Cells[4].Attributes.Add("style", "word-wrap:break-word");
                //e.Row.Cells[7].Attributes.Add("style", "word-wrap:break-word");
                //e.Row.Cells[8].Attributes.Add("style", "word-wrap:break-word");
                //e.Row.Cells[9].Attributes.Add("style", "word-wrap:break-word");
                e.Row.Cells[7].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[8].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[9].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[10].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");

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
            Load_InitialData();

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
        private void Load_Filtering_Elements()
        {
            drbuilding.Items.Clear();
            drcategory.Items.Clear();
            drflevel.Items.Clear();
            drfed.Items.Clear();
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
        private void Update(string pwron, string test1, string test2, string test3, string test4, string test5, string test6, string test7, string test8, string test9, string test10, string test11, string test12, string tested1, string tested2, string compld1, string compld2, string dvce, string accept1, string accept2, string filed1, string filed2, string comts, string actby, string actdt)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();
            _objcls.cas_id = Convert.ToInt32((string)Session["casid"]);
            _objcls.test1 = test1;
            _objcls.test2 = test2;
            _objcls.test3 = test3;
            _objcls.test4 = test4;
            _objcls.test5 = test5;
            _objcls.test6 = test6;
            _objcls.test7 = test7;
            _objcls.test11 = test8;
            _objcls.test12 = test10;
            _objcls.test13 = test11;
            _objcls.test14 = test12;
            _objcls.test15 = tested1;
            _objcls.tested1 = "";
            _objcls.test8 = compld1;
            _objcls.tested2 = tested2;
            _objcls.test9 = compld2;
            _objcls.comm = comts;
            _objcls.act_by = actby;
            _objcls.act_date = actdt;
            _objcls.compl = "";
            _objcls.test10 = test9;
            _objcls.per_com1 = per_com1();
            _objcls.per_com2 = per_com2();
            _objcls.per_com3 = per_com3();
            _objcls.per_com4 = per_com4();
            _objcls.power_on = pwron;
            _objcls.dev1 = dvce;
            _objcls.accept1 = accept1;
            _objcls.accept2 = accept2;
            _objcls.filed1 = filed1;
            _objcls.filed2 = filed2;
            _objcls.per_com5 = per_com5();
            _objcls.per_com6 = per_com6();
            _objcls.per_com7 = per_com7();
            _objcls.per_com8 = per_com8();
            _objcls.per_com9 = per_com9();
            _objcls.per_com10 = per_com10();
            _objbll.Cassheet_update(_objcls, _objdb);
        }
        protected decimal per_com1()
        {

            decimal _percentage = 0;
            //if (lblsch.Text == "1")
            //{
            //    //int test = 0;
            //    //if(test1.Text!="" && test1.Text!)
            //}
            int count = 0;
            if (lblsch.Text == "20")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (IsNumeric(_20cit.Text)) _percentage = Convert.ToDecimal(_20cit.Text);
                }
                else
                if (IsNumeric(_20acit.Text)) _percentage = Convert.ToDecimal(_20acit.Text);
            }
            return _percentage;
        }
        private bool DateValidation(string dateString)
        {
            DateTime dateValue;
            string[] format = new string[] { "dd/MM/yyyy" };
            string[] format1 = new string[] { "dd/MM/yy" };
            if (DateTime.TryParseExact(dateString, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out dateValue))
                return true;
            else if (DateTime.TryParseExact(dateString, format1, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out dateValue))
                return true;
            else
                return false;

        }
        protected decimal per_com2()
        {

            decimal _percentage = 0;
            int count = 0;
            if (lblsch.Text == "20")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    
                    if (IsNumeric(_20ppt.Text) == true)
                        _percentage = Convert.ToDecimal(_20ppt.Text);
                }
                else
                    if (IsNumeric(_20appt.Text) == true)
                        _percentage = Convert.ToDecimal(_20appt.Text);
            }
            
            return _percentage;
        }
        protected decimal per_com3()
        {
            //if (dev1.Text == "") return 0;
            decimal _percentage = 0;
            if (lblsch.Text == "20")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (IsNumeric(_20cft.Text) == true)
                        _percentage = Convert.ToDecimal(_20cft.Text);
                }
                else
                {
                    if (IsNumeric(_20acft.Text) == true)
                        _percentage = Convert.ToDecimal(_20acft.Text);

                }

            }
            return _percentage;
        }
        protected decimal per_com4()
        {
            //    //if (dev1.Text == "") return 0;
            decimal _percentage = 0;
            if (lblsch.Text == "20")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (IsNumeric(_20sot.Text) == true)
                        _percentage = Convert.ToDecimal(_20sot.Text);
                }
                else
                {
                    if (IsNumeric(_20asot.Text) == true)
                        _percentage = Convert.ToDecimal(_20asot.Text);
                }
            }
            
            return _percentage;
        }
        protected decimal per_com5()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "20")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (IsNumeric(_20ght.Text) == true)
                        _percentage = Convert.ToDecimal(_20ght.Text);
                }
                else
                {
                    if (IsNumeric(_20aght.Text) == true)
                        _percentage = Convert.ToDecimal(_20aght.Text);
                }
            }
            
            return _percentage;
        }
        protected decimal per_com6()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "20")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (IsNumeric(_20lt.Text) == true)
                        _percentage = Convert.ToDecimal(_20lt.Text);
                }
                else
                {
                    if (IsNumeric(_20alt.Text) == true)
                        _percentage = Convert.ToDecimal(_20alt.Text);
                }
            }
            
            return _percentage;
        }
        protected decimal per_com7()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "20")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (DateValidation(_20accept1.Text) == true && DateValidation(_20accept2.Text) == true && DateValidation(_20accept3.Text) == true)
                        _percentage = 1;
                }
            }
            return _percentage;
        }
        protected decimal per_com8()
        {
            decimal _percentage = 0;
            
            return _percentage;
        }
        protected decimal per_com9()
        {
            decimal _percentage = 0;
            
            return _percentage;
        }
        protected decimal per_com10()
        {
            decimal _percentage = 0;
            
            return _percentage;
        }
        private void Load_cassheet_details()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32(lblsch.Text);
            _objcas.prj_code = lblprj.Text;

            if (lblprj.Text == "HMIM" || lblprj.Text == "14211" || lblprj.Text=="HMHS")
                _objcas.sys = Convert.ToInt32(lbldiv.Text);
            else
                _objcas.sys = 0;

            DataTable _dt = _objbll.Load_casMain_Edit(_objcas, _objdb);
            var result = from o in _dt.AsEnumerable()
                         where o.Field<int>(0) == Convert.ToInt32((string)Session["casid"])
                         select o;
            foreach (var row in result)
            {


                if (lblprj.Text == "14211" || lblprj.Text=="HMIM" || lblprj.Text=="HMHS")
                {
                    _20acit.Text = row[24].ToString();
                    _20appt.Text = row[25].ToString();
                    _20acft.Text = row[26].ToString();
                    _20asot.Text = row[27].ToString();
                    _20aght.Text = row[28].ToString();
                    _20alt.Text = row[29].ToString();
                    _20aaccept1.Text = row[30].ToString();
                    _20afiled1.Text = row["test11"].ToString();
                    _20aaccept2.Text = row["accept1"].ToString();
                    _20afiled2.Text = row["filed1"].ToString();
                    _20aaccept3.Text = row["accept2"].ToString();
                    _20afiled3.Text = row["filed2"].ToString();
                    _20acommts.Text = row[18].ToString();
                    _20aactby.Text = row[19].ToString();
                    _20aactdt.Text = row[20].ToString();

                    _20apoints.Text = row["devices3"].ToString();
                    _20adevices.Text = row["devices2"].ToString();
                    _20asystem.Text = row["devices1"].ToString();

                    SetCheckedBoxChecked(_20acit, chk_20acit);
                    SetCheckedBoxChecked(_20appt, chk_20appt);
                    SetCheckedBoxChecked(_20acft, chk_20acft);
                    SetCheckedBoxChecked(_20asot, chk_20asot);
                    SetCheckedBoxChecked(_20aght, chk_20aght);
                    SetCheckedBoxChecked(_20alt, chk_20alt);
                    SetCheckedBoxChecked(_20aaccept1, chk_20aaccept1);
                    SetCheckedBoxChecked(_20aaccept2, chk_20aaccept2);
                    SetCheckedBoxChecked(_20aaccept3, chk_20aaccept3);
                    SetCheckedBoxChecked(_20afiled1, chk_20afiled1);
                    SetCheckedBoxChecked(_20afiled2, chk_20afiled2);
                    SetCheckedBoxChecked(_20afiled3, chk_20afiled3);

                    SetCheckedBoxChecked(_20aactby, chk_20aactby);
                    // SetCheckedBoxChecked(_20aactdt, chk_20aactdt);
                    SetCheckedBoxChecked(_20afiled3, chk_20afiled3);

                }
                else
                {


                    if (lblsch.Text == "20" || lblsch.Text == "32")
                    {
                        _20cit.Text = row[24].ToString();
                        _20ppt.Text = row[25].ToString();
                        _20cft.Text = row[26].ToString();
                        _20sot.Text = row[27].ToString();
                        _20ght.Text = row[28].ToString();
                        _20lt.Text = row[29].ToString();
                        _20accept1.Text = row[30].ToString();
                        _20filed1.Text = row["test11"].ToString();
                        _20accept2.Text = row["accept1"].ToString();
                        _20filed2.Text = row["filed1"].ToString();
                        _20accept3.Text = row["accept2"].ToString();
                        _20filed3.Text = row["filed2"].ToString();
                        _20commts.Text = row[18].ToString();
                        _20actby.Text = row[19].ToString();
                        _20actdt.Text = row[20].ToString();

                        _20points.Text = row["devices3"].ToString();
                        _20devices.Text = row["devices2"].ToString();
                        _20system.Text = row["devices1"].ToString();

                        _20pptd.Text = row["test10"].ToString();
                        _20cftsd.Text = row["test12"].ToString();
                        _20sotd.Text = row["test13"].ToString();
                        _20ghtd.Text = row["test14"].ToString();
                        _20ltd.Text = row["test15"].ToString();

                        SetCheckedBoxChecked(_20cit, chk_20cit);
                        SetCheckedBoxChecked(_20ppt, chk_20ppt);
                        SetCheckedBoxChecked(_20cft, chk_20cft);
                        SetCheckedBoxChecked(_20sot, chk_20sot);
                        SetCheckedBoxChecked(_20ght, chk_20ght);
                        SetCheckedBoxChecked(_20lt, chk_20lt);
                        SetCheckedBoxChecked(_20accept1, chk_20accept1);
                        SetCheckedBoxChecked(_20accept2, chk_20accept2);
                        SetCheckedBoxChecked(_20accept3, chk_20accept3);
                        SetCheckedBoxChecked(_20filed1, chk_20filed1);
                        SetCheckedBoxChecked(_20filed2, chk_20filed2);
                        SetCheckedBoxChecked(_20filed3, chk_20filed3);
                        SetCheckedBoxChecked(_20pptd, chk_20pptsd);
                        SetCheckedBoxChecked(_20cftsd, chk_20cftsd);
                        SetCheckedBoxChecked(_20sotd, chk_20sotd);
                        SetCheckedBoxChecked(_20ghtd, chk_20ghtd);
                        SetCheckedBoxChecked(_20ltd, chk_20ltd);
                        //SetCheckedBoxChecked(_20commts, chk_20commts);
                        SetCheckedBoxChecked(_20actby, chk_20actby);
                        // SetCheckedBoxChecked(_20actdt, chk_20actdt);
                        SetCheckedBoxChecked(_20filed3, chk_20filed3);


                    }
                }
                
            }
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            //btnDummy_ModalPopupExtender2.Hide();
        }
        
        private void Update_AMSCheckDate()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DB_" + lblprj.Text;
            //_clsams _objcls = new _clsams();
            //_objcls.signoff = Convert.ToDateTime(_2accept2.Text);
            //_objcls.casId = Convert.ToInt32((string)Session["casid"]);
            //_objbll.Update_AMSCheckDates(_objcls, _objdb);
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


        protected void drloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["loc"] = drloc.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text);
        }

        protected void _20btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _20cit.Text, _20ppt.Text, _20cft.Text, _20sot.Text, _20ght.Text, _20lt.Text, _20accept1.Text, _20filed1.Text,_20pptd.Text,_20cftsd.Text,_20sotd.Text,_20ghtd.Text,_20ltd.Text, "", "", "", "", _20accept2.Text, _20accept3.Text, _20filed2.Text, _20filed3.Text, _20commts.Text, _20actby.Text, _20actdt.Text);
            btnDummy_ModalPopupExtender14.Hide();
        }
        protected void _20btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender14.Hide();
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
        protected void _20abtnupdate_Click(object sender, EventArgs e)
        {
            //Update("", _20acit.Text, _20ppt.Text, _20cft.Text, _20sot.Text, _20ght.Text, _20lt.Text, _20accept1.Text, _20filed1.Text, _20pptd.Text, _20cftsd.Text, _20sotd.Text, _20ghtd.Text, _20ltd.Text, "", "", "", "", _20accept2.Text, _20accept3.Text, _20filed2.Text, _20filed3.Text, _20commts.Text, _20actby.Text, _20actdt.Text);
            Update("", _20acit.Text, _20appt.Text, _20acft.Text, _20asot.Text, _20aght.Text, _20alt.Text, _20aaccept1.Text, _20afiled1.Text, "", "", "", "", "", "", "", "", "", _20aaccept2.Text, _20aaccept3.Text, _20afiled2.Text, _20afiled3.Text, _20acommts.Text, _20aactby.Text, _20aactdt.Text);
            btnDummy_ModalPopupExtender20a.Hide();
        }
        protected void _20abtncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender20a.Hide();
        }

    }
}
