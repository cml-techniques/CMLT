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

namespace CmlTechniques
{
    public partial class Cassheet_Dataentry1 : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtresult;
        public static bool _exp;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _prm + "');", true);
                lblprj.Text = _prm.Substring(0, _prm.IndexOf("_S"));
                lblsch.Text = _prm.Substring(_prm.IndexOf("_S") + 2);
                Setting();
                load_cas_sys();
                Load_Master();
                Session["filter"] = "no";
                Session["zone"] = "All";
                Session["flvl"] = "All";
                Session["cat"] = "All";
                Session["fed"] = "All";
                Session["loc"] = "All";
                Load_InitialData();
                //Load_Filtering_Elements();
                _exp = false;
            }
        }
        private void Setting()
        {
            if (lblsch.Text == "33")
            {
                lbl1.Text = "ENGINEER REF."; lbl2.Text = "SYSTEM 1"; lbl3.Text = "SYSTEM 2"; lbl4.Text = "NO. OF INTERFACES";
                lblhead.Text = "System Integration Tests Commissioning Activity Schedule";
            }
            else if (lblsch.Text == "34")
            {
                lbl1.Text = "BUILDING/AREA"; lbl4.Text = "NO. OF TESTS"; op1.Visible = false; op1_1.Visible = false; op1_3.Visible = false; op2.Visible = false; op2_1.Visible = false; op2_3.Visible = false; tbl.Width = "675px"; _div.Style.Add("Width", "740px"); mydetails.Width = 675; op3.Visible = false; op4.Visible = false; op3_1.Visible = false; op3_3.Visible = false; op4_1.Visible = false; op4_3.Visible = false;
                lblhead.Text = "Power Failure Tests Commissioning Activity Schedule";
            }
            else if (lblsch.Text == "35")
            {
                lbl1.Text = "BUILDING/AREA"; lbl4.Text = "NO. OF TESTS"; op1.Visible = false; op1_1.Visible = false; op1_3.Visible = false; op2.Visible = false; op2_1.Visible = false; op2_3.Visible = false; tbl.Width = "675px"; _div.Style.Add("Width", "745px"); mydetails.Width = 675; op3.Visible = false; op4.Visible = false; op3_1.Visible = false; op3_3.Visible = false; op4_1.Visible = false; op4_3.Visible = false;
                lblhead.Text = "Fire Alarm Cause and Effects Commissioning Activity Schedule";
            }
        }
        protected void load_cas_sys()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();
            _objcls.sch = Convert.ToInt32(lblsch.Text);
            DataTable _dt0 = _objbll.Load_cas_sys(_objcls, _objdb);
            DataTable _dt1 = new DataTable();
            _dt1.Columns.Add("_id");
            _dt1.Columns.Add("_name");
            var _List = from o in _dt0.AsEnumerable()
                        where o.Field<string>(3) == (string)Session["project"]
                        select o;

            foreach (var row in _List)
            {
                DataRow _myrow = _dt1.NewRow();
                _myrow[0] = row[0].ToString() + "_C" + row[2].ToString();
                _myrow[1] = row[1].ToString();
                _dt1.Rows.Add(_myrow);
            }
            drpackage.DataSource = _dt1;
            drpackage.DataTextField = "_name";
            drpackage.DataValueField = "_id";
            drpackage.DataBind();
            drpackage.Items.Insert(0, "--Package--");
        }
        
        void _ReadCookies()
        {
            if (Request.Browser.Cookies)
            {
                if (Request.Cookies["uid"] != null)
                {
                    Session["uid"] = Server.HtmlEncode(Request.Cookies["uid"].Value);
                }
                //if (Request.Cookies["project"] != null)
                //{
                //    Session["project"] = Server.HtmlEncode(Request.Cookies["project"].Value);
                //}
                //if (Request.Cookies["sch"] != null)
                //{
                //    Session["sch"] = Server.HtmlEncode(Request.Cookies["sch"].Value);
                //}
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
                _CookieSch.Value = (string)Session["sch"];
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
            _dtMaster = new DataTable();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32(lblsch.Text);
            _objcas.prj_code = lblprj.Text;
            _dtMaster = _objbll.Load_casMain_SP(_objcas, _objdb);
            _dtresult = _dtMaster;
            mydetails.DataSource = _dtMaster;
            mydetails.DataBind();
        }
        private void Load_InitialData()
        {
            //DataTable _dtable = new DataTable();
            //_dtable.Columns.Add("sys_id", typeof(string));
            //_dtable.Columns.Add("sys_name", typeof(string));
            //var distinctRows = (from DataRow dRow in _dtresult.Rows
            //                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"] }).Distinct();
            //foreach (var row in distinctRows)
            //{
            //    DataRow _row = _dtable.NewRow();
            //    _row[0] = row.col1.ToString();
            //    _row[1] = row.col2.ToString();
            //    _dtable.Rows.Add(_row);
            //}
            //mydetails.DataSource = _dtable;
            //mydetails.DataBind();

        }
        protected void mymaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Label _sys_id = (Label)e.Row.FindControl("lbSys_Id");
            //    DataTable _dtdetails = new DataTable();
            //    _dtdetails.Columns.Add("e_b_ref", typeof(string));
            //    _dtdetails.Columns.Add("B_Z", typeof(string));
            //    _dtdetails.Columns.Add("Cat", typeof(string));
            //    _dtdetails.Columns.Add("F_lvl", typeof(string));
            //    _dtdetails.Columns.Add("Seq_No", typeof(string));
            //    _dtdetails.Columns.Add("Loc", typeof(string));
            //    _dtdetails.Columns.Add("P_P_to", typeof(string));
            //    _dtdetails.Columns.Add("F_from", typeof(string));
            //    _dtdetails.Columns.Add("Substation", typeof(string));
            //    _dtdetails.Columns.Add("devices1", typeof(string));
            //    _dtdetails.Columns.Add("C_id", typeof(int));
            //    _dtdetails.Columns.Add("Sys_name", typeof(string));
            //    _dtdetails.Columns.Add("Sys_id", typeof(int));
            //    _dtdetails.Columns.Add("Des", typeof(string));
            //    var _details = from _data in _dtresult.AsEnumerable()
            //                   where _data.Field<int>("Sys_Id") == Convert.ToInt32(_sys_id.Text)
            //                   select _data;
            //    foreach (var row in _details)
            //    {
            //        DataRow _row = _dtdetails.NewRow();
            //        _row[0] = row["e_b_ref"].ToString();
            //        _row[1] = row["B_Z"].ToString();
            //        _row[2] = row["Cat"].ToString();
            //        _row[3] = row["F_lvl"].ToString();
            //        _row[4] = row["Seq_No"].ToString();
            //        _row[5] = row["Loc"].ToString();
            //        _row[6] = row["p_p_to"].ToString();
            //        _row[7] = row["F_from"].ToString();
            //        _row[8] = row["Substation"].ToString();
            //        _row[9] = row["devices1"].ToString();
            //        _row[10] = row["C_id"].ToString();
            //        _row[11] = row["Sys_name"].ToString();
            //        _row[12] = row["Sys_id"].ToString();
            //        _row[13] = row["Des"].ToString();
            //        _dtdetails.Rows.Add(_row);
            //    }
            //    GridView _mydetails = (GridView)e.Row.FindControl("mydetails");
            //    _mydetails.DataSource = _dtdetails;
            //    _mydetails.DataBind();
            //    Button _btn = (Button)e.Row.FindControl("Button1");
            //    _btn.Text = "+";
            //    _mydetails.Visible = false;
            //}
        }
        //private void Hide_Details()
        //{
        //    for (int i = 0; i <= mydetails.Rows.Count - 1; i++)
        //    {
        //        GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
        //        Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
        //        _mydetails.Visible = false;
        //        _btn.Text = "+";
        //    }
        //}
        //private void Open_Details(int mode)
        //{
        //    string sys = "";
        //    if (mode == 1)
        //        sys = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));
        //    else
        //        sys = (string)Session["Sys"];
        //    for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
        //    {
        //        Label _sys_id = (Label)mymaster.Rows[i].FindControl("lbSys_Id");
        //        if (_sys_id.Text == sys)
        //        {
        //            GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
        //            Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
        //            _mydetails.Visible = true;
        //            _btn.Text = "-";
        //        }
        //    }
        //}
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
            int _idx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mydetails.Rows[_idx];
            TableCell _item1 = _srow.Cells[8];
            Load_Cas_Details();
            Session["casid"] = _item1.Text;
            Session["idx"] = _idx.ToString();
            btnDummy_ModalPopupExtender.Show();

        }
        
        protected void mydetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[10].Visible = false;
            if (lblsch.Text == "34" || lblsch.Text == "35")
            {
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[8].Visible = false;
            }
            //e.Row.Cells[14].Visible = false;

            //e.Row.Cells[0].Enabled = false;
            //if (e.Row.Cells[1].Text != "") return;
            //if (e.Row.Cells[0].Text != "")
            //    e.Row.Cells[0].Text = "hai" + e.Row.Cells[0].Text;
            e.Row.Cells[1].Text = (e.Row.DataItemIndex + 1).ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[3].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[4].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
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
            DataTable _dtfilter = _dtMaster;
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
            _dtresult.Columns.Add("Des", typeof(string));
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
            foreach (var row in _filter)
            {
                DataRow _row = _dtresult.NewRow();
                _row[0] = row["e_b_ref"].ToString();
                _row[1] = row["B_Z"].ToString();
                _row[2] = row["Cat"].ToString();
                _row[3] = row["F_lvl"].ToString();
                _row[4] = row["Seq_No"].ToString();
                _row[5] = row["Loc"].ToString();
                _row[6] = row["p_p_to"].ToString();
                _row[7] = row["F_from"].ToString();
                _row[8] = row["Substation"].ToString();
                _row[9] = row["devices1"].ToString();
                _row[10] = row["C_id"].ToString();
                _row[11] = row["Sys_name"].ToString();
                _row[12] = row["Sys_id"].ToString();
                _row[13] = row["Des"].ToString();
                _dtresult.Rows.Add(_row);
            }
            //m.DataSource = _dtresult;
            //mygrid.DataBind();
            Load_InitialData();

        }
       
        private void Get_Position()
        {
            //string Sys_Id = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_clscassheet _objcls = new _clscassheet();
            //_objdb.DBName = "DB_" + (string)Session["project"];
            //_objcls.sys = Convert.ToInt32(Sys_Id);
            //txtitmno.Text = _objbll.Get_Position(_objcls, _objdb).ToString();
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {

            if (IfExistRef(txtengref.Text) == true) return;
            //string _sys = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));
            //if (txtnoof.Text.Length <= 0) txtnoof.Text = "0";
            //int no = 0;
            //string dev_vol = "";
            //if ((string)Session["sch"] == "1" || (string)Session["sch"] == "2" || (string)Session["sch"] == "3")
            //    dev_vol = txtnoof.Text;
            //else
            //    no = Convert.ToInt32(txtnoof.Text);
            add_initial_data();
            Load_Master();
            Load_InitialData();
        }
       
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if (string.Compare(up_reff.Text, lblref.Text) != 0)
            {
                if (IfExistRef(up_reff.Text) == true) return;
            }
            Edit_Inidata();
            Load_Master();
            Load_InitialData();
            btnDummy_ModalPopupExtender.Hide();
        }
        private void Edit_Inidata()
        {

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.c_s_id = 0;
            _objcas.prj_code = lblprj.Text;
            _objcas.uid = (string)Session["uid"];
            if (lblsch.Text == "33")
                _objcas.sys = 115;
            else if (lblsch.Text == "34")
                _objcas.sys = 116;
            else if (lblsch.Text == "35")
                _objcas.sys = 117;
            _objcas.reff = up_reff.Text;
            _objcas.b_zone = uplb2.Text;
            _objcas.cate = uplb3.Text;
            _objcas.f_level = "";
            _objcas.seq_no = 0;
            _objcas.desc = txt_icomp.Text;
            _objcas.loca = txt_isoff.Text;
            _objcas.p_power_to = "";
            _objcas.fed_from = "";
            _objcas.sub_st = "";
            _objcas.s_c_m = "";
            _objcas.dev1 = uplb4.Text;
            _objcas.dev2 = "";
            _objcas.dev3 = "0";
            _objcas.mode = 0;
            _objcas.cas_id = Convert.ToInt32((string)Session["casid"]);
            _objbll.Cassheet_Master(_objcas, _objdb);
            Update();
        }
        private void Delete_Inidata()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DB_" + (string)Session["project"];
            //_clscassheet _objcas = new _clscassheet();
            //_objcas.c_s_id = 0;
            //_objcas.prj_code = (string)Session["project"];
            //_objcas.uid = (string)Session["uid"];
            //_objcas.sys = Convert.ToInt32((string)Session["Sys"]);
            //_objcas.reff = "";
            //_objcas.b_zone = "";
            //_objcas.cate = "";
            //_objcas.f_level = "";
            //_objcas.seq_no = 0;
            //_objcas.desc = "";
            //_objcas.loca = "";
            //_objcas.p_power_to = "";
            //_objcas.fed_from = "";
            //_objcas.sub_st = "";
            //_objcas.s_c_m = "";
            //_objcas.dev1 = "";
            //_objcas.dev2 = "0";
            //_objcas.dev3 = "0";
            //_objcas.mode = 2;
            //_objcas.cas_id = Convert.ToInt32((string)Session["casid"]);
            //_objbll.Cassheet_Master(_objcas, _objdb);
        }
        protected void btndelete_Click(object sender, EventArgs e)
        {
            Delete_Inidata();
            Load_Master();
            Load_InitialData();
            btnDummy_ModalPopupExtender.Hide();
        }
        private void Update()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();
            _objcls.cas_id = Convert.ToInt32((string)Session["casid"]);
            _objcls.test1 = txt_dtc.Text;
            _objcls.test2 = txt_sof.Text;
            _objcls.test3 = txt_icomp.Text;
            _objcls.test4 = txt_isoff.Text;
            _objcls.test5 = "";
            _objcls.test6 = "";
            _objcls.test7 = "";
            _objcls.test11 = "";
            _objcls.test12 = "";
            _objcls.test13 = "";
            _objcls.test14 = "";
            _objcls.test15 = "";
            _objcls.tested1 = "";
            _objcls.test8 = "";
            _objcls.tested2 = "";
            _objcls.test9 = "";
            _objcls.comm = "";
            _objcls.act_by = "";
            _objcls.act_date = "";
            _objcls.compl = "";
            _objcls.test10 = "";
            _objcls.per_com1 = 0;
            _objcls.per_com2 = 0;
            _objcls.per_com3 = 0;
            _objcls.per_com4 = 0;
            _objcls.power_on = "";
            _objcls.dev1 = "";
            _objcls.accept1 = "";
            _objcls.accept2 = "";
            _objcls.filed1 = "";
            _objcls.filed2 = "";
            _objcls.per_com5 = 0;
            _objcls.per_com6 = 0;
            _objcls.per_com7 = 0;
            _objcls.per_com8 = 0;
            _objcls.per_com9 = 0;
            _objcls.per_com10 = 0;
            _objbll.Cassheet_update(_objcls, _objdb);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender.Hide();
        }
        protected void add_initial_data()
        {

            //string _sys = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.c_s_id = Convert.ToInt32(lblsch.Text);
            _objcas.prj_code = lblprj.Text;
            _objcas.uid = (string)Session["uid"];
            if(lblsch.Text=="33")
                _objcas.sys = 115;
            else if (lblsch.Text == "34")
                _objcas.sys = 116;
            else if (lblsch.Text == "35")
                _objcas.sys = 117;
            _objcas.reff = txtengref.Text;
            _objcas.b_zone = txt1.Text;
            _objcas.cate = txt2.Text;
            _objcas.f_level = "";
            _objcas.seq_no = 1;
            _objcas.desc = "";
            _objcas.loca = "";
            _objcas.p_power_to = "";
            _objcas.fed_from = "";
            _objcas.sub_st = "";
            _objcas.s_c_m = "";
            _objcas.dev1 = txt_no.Text;
            _objcas.dev2 = "";
            _objcas.dev3 = "";
            _objcas.mode = 1;
            _objcas.cas_id = 0;
            _objcas.Position = mydetails.Rows.Count + 1;
            _objbll.Cassheet_Master(_objcas, _objdb);

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
        private bool IfExistRef(string _ref)
        {
            //var _result = from _data in _dtMaster.AsEnumerable()
            //              where _data.Field<string>("E_b_ref").ToUpper().Trim() == txtengref.Text.ToUpper().Trim()
            //              select _data;
            //foreach (var row in _result)
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Engineer Ref. Already Exist!');", true);
            //    return true;
            //}
            //return false;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcls = new _clscassheet();
            _objcls.reff = _ref;
            _objcls.sch = Convert.ToInt32(lblsch.Text);
            if (_objbll.Check_EngRef(_objcls, _objdb) != 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Engineer Ref. Already Exist!');", true);
                return true;
            }
            return false;

        }
       
       
       

        protected void btnexpand_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            //{
            //    GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
            //    Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
            //    _mydetails.Visible = true;
            //    _btn.Text = "-";
            //}
        }

        protected void btncollapse_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            //{
            //    GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
            //    Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
            //    _mydetails.Visible = false;
            //    _btn.Text = "+";
            //}
        }

        protected void chkrow_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            GridViewRow row = (GridViewRow)checkbox.NamingContainer;
            if (checkbox.Checked == true)
                row.BackColor = System.Drawing.Color.Gainsboro;
            else
                row.BackColor = System.Drawing.Color.White;
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i <= mydetails.Rows.Count - 1; i++)
            {
                CheckBox checkbox = (CheckBox)mydetails.Rows[i].FindControl("chkrow");
                if (checkbox.Checked == true)
                {
                    count += 1;
                    Session["casid"] = mydetails.Rows[i].Cells[10].Text;
                    //Session["Sys"] = mydetails.Rows[i].Cells[14].Text;
                    Session["idx"] = i.ToString();
                }

            }
            if (count == 0) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');", true);
            else if (count > 1) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('You can select only one Row at a time to Edit');", true);
            else if (count == 1)
            {
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["casid"] + "');", true);
                Load_Cas_Details();
                btnDummy_ModalPopupExtender.Show();
            }
        }
        private void Load_Cas_Details()
        {
            Load_Master();
            var _result = from _data in _dtMaster.AsEnumerable()
                          where _data.Field<int>(0) == Convert.ToInt32((string)Session["casid"])
                          select _data;
            foreach (var row in _result)
            {
                up_reff.Text = row["e_b_ref"].ToString();
                lblref.Text = row["e_b_ref"].ToString();
                uplb2.Text = row["B_Z"].ToString();
                uplb3.Text = row["cat"].ToString();
                uplb4.Text = row["devices1"].ToString();
                txt_dtc.Text = row["test1"].ToString();
                txt_sof.Text = row["test2"].ToString();
            }
            if (lblsch.Text == "33")
            {
                lb1.Text = lbl1.Text;
                lb2.Text = lbl2.Text;
                lb3.Text = lbl3.Text;
                lb4.Text = lbl4.Text;
            }
            else if (lblsch.Text == "34" || lblsch.Text == "35")
            {
                lb1.Text = lbl1.Text;
                lb4.Text = lbl4.Text;
                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
            }
        }
        protected void btndelete1_Click(object sender, EventArgs e)
        {
            //int count = 0;
            //for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            //{
            //    GridView _details = (GridView)mymaster.Rows[i].FindControl("mydetails");
            //    for (int j = 0; j <= _details.Rows.Count - 1; j++)
            //    {
            //        CheckBox checkbox = (CheckBox)_details.Rows[j].FindControl("chkrow");
            //        if (checkbox.Checked == true)
            //        {
            //            count += 1;
            //            Session["casid"] = _details.Rows[j].Cells[13].Text;
            //            Session["Sys"] = _details.Rows[j].Cells[14].Text;
            //            Delete_Inidata();
            //        }
            //    }

            //}
            //if (count == 0) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');", true);
            //else
            //{
            //    string _msg = count.ToString() + " Row(s) Deleted";
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _msg + "');", true);
            //    Load_Master();
            //    Load_InitialData();
            //    Open_Details(0);
            //}
        }
        protected void chkrow1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            GridViewRow row = (GridViewRow)checkbox.NamingContainer;
            GridView _details = (GridView)row.FindControl("mydetails");

            if (checkbox.Checked == true)
            {
                for (int j = 0; j <= _details.Rows.Count - 1; j++)
                {
                    CheckBox check = (CheckBox)_details.Rows[j].FindControl("chkrow");
                    check.Checked = true;
                    _details.Rows[j].BackColor = System.Drawing.Color.Gainsboro;
                }
            }
            else
            {
                for (int j = 0; j <= _details.Rows.Count - 1; j++)
                {
                    CheckBox check = (CheckBox)_details.Rows[j].FindControl("chkrow");
                    check.Checked = false;
                    _details.Rows[j].BackColor = System.Drawing.Color.White;
                }
            }
        }

        private void FnSearch()
        {
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
            _dtresult.Columns.Add("Des", typeof(string));
            var _result = from _data in _dtMaster.AsEnumerable()
                          where _data.Field<string>("E_b_ref").ToUpper().IndexOf(txtsearch.Text.ToUpper()) >= 0
                          select _data;

            foreach (var row in _result)
            {
                DataRow _row = _dtresult.NewRow();
                _row[0] = row["e_b_ref"].ToString();
                _row[1] = row["B_Z"].ToString();
                _row[2] = row["Cat"].ToString();
                _row[3] = row["F_lvl"].ToString();
                _row[4] = row["Seq_No"].ToString();
                _row[5] = row["Loc"].ToString();
                _row[6] = row["p_p_to"].ToString();
                _row[7] = row["F_from"].ToString();
                _row[8] = row["Substation"].ToString();
                _row[9] = row["devices1"].ToString();
                _row[10] = row["C_id"].ToString();
                _row[11] = row["Sys_name"].ToString();
                _row[12] = row["Sys_id"].ToString();
                _row[13] = row["Des"].ToString();
                _dtresult.Rows.Add(_row);
            }
            Load_InitialData();

        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            //if (btnsearch.Text == "Search")
            //{
            //    FnSearch();
            //    for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            //    {
            //        GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
            //        Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
            //        _mydetails.Visible = true;
            //        _btn.Text = "-";
            //    }
            //    btnsearch.Text = "Reset";
            //}
            //else
            //{
            //    txtsearch.Text = String.Empty;
            //    FnSearch();
            //    for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            //    {
            //        GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
            //        Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
            //        _mydetails.Visible = false;
            //        _btn.Text = "+";
            //    }
            //    btnsearch.Text = "Search";
            //}
        }

        protected void btnimport_Click(object sender, EventArgs e)
        {
            string _url = "CMS/Import.aspx?id=" + (string)Session["sch"] + "_" + (string)Session["project"];
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _url + "','','left=300,top=200,width=500,height=400,menubar=0,toolbar=0,scrollbars=1,status=0,resizable=0');", true);
        }

        protected void btnrefresh_Click(object sender, ImageClickEventArgs e)
        {
            Load_Master();
            Load_InitialData();
        }

        protected void drpackage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
