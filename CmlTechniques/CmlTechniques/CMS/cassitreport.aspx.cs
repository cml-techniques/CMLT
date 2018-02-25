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

namespace CmlTechniques.CMS
{
    public partial class cassitreport : System.Web.UI.Page
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
                Load_Master();
                //Session["filter"] = "no";
                //Session["zone"] = "All";
                //Session["flvl"] = "All";
                //Session["cat"] = "All";
                //Session["fed"] = "All";
                //Session["loc"] = "All";
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
                lbl1.Text = "BUILDING/AREA"; lbl4.Text = "NO. OF TESTS"; op1.Visible = false; op1_3.Visible = false; op2.Visible = false; op2_3.Visible = false; tbl.Width = "675px"; _div.Style.Add("Width", "740px"); mydetails.Width = 675; op3.Visible = false; op3_3.Visible = false; op4.Visible = false; op4_3.Visible = false;
                lblhead.Text = "Power Failure Tests Commissioning Activity Schedule";
            }
            else if (lblsch.Text == "35")
            {
                lbl1.Text = "BUILDING/AREA"; lbl4.Text = "NO. OF TESTS"; op1.Visible = false; op1_3.Visible = false; op2.Visible = false; op2_3.Visible = false; tbl.Width = "675px"; _div.Style.Add("Width", "745px"); mydetails.Width = 675; op3.Visible = false; op3_3.Visible = false; op4.Visible = false; op4_3.Visible = false;
                lblhead.Text = "Fire Alarm Cause and Effects Commissioning Activity Schedule";
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
        int _rowcount = 0;
        decimal _interface = 0;
        decimal _dcompl = 0;
        decimal _signoff = 0;
        decimal _icom = 0;
        decimal _isoff = 0;
        protected void mydetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[7].Visible = false;
            if (lblsch.Text == "34" || lblsch.Text == "35")
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[7].Visible = false;
            }
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
                e.Row.Cells[2].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[3].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[4].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                _rowcount += 1;
                if (IsNumeric(e.Row.Cells[4].Text) == true)
                    _interface += Convert.ToDecimal(e.Row.Cells[4].Text);
                if (IsNumeric(e.Row.Cells[5].Text) == true)
                    _icom += Convert.ToDecimal(e.Row.Cells[5].Text);
                if (IsNumeric(e.Row.Cells[7].Text) == true)
                    _isoff += Convert.ToDecimal(e.Row.Cells[7].Text);
                if (DateValidation(e.Row.Cells[6].Text) == true)
                {
                    if (IsNumeric(e.Row.Cells[4].Text) == true)
                    {
                        _dcompl += Convert.ToDecimal(e.Row.Cells[4].Text);
                        e.Row.Cells[9].Text = "100%";
                    }
                }
                else
                    e.Row.Cells[9].Text = "0%";
                if (DateValidation(e.Row.Cells[7].Text) == true)
                {
                    if (IsNumeric(e.Row.Cells[4].Text) == true)
                        _signoff += Convert.ToDecimal(e.Row.Cells[4].Text);
                }
                
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "SUMMARY";
                e.Row.Cells[1].Text = _rowcount.ToString();
                e.Row.Cells[4].Text = _interface.ToString();
                e.Row.Cells[6].Text = _dcompl.ToString();
                e.Row.Cells[8].Text = _signoff.ToString();
                e.Row.Cells[5].Text = _icom.ToString();
                e.Row.Cells[7].Text = _isoff.ToString();
                decimal _ovrall = 0;
                if (_interface != 0)
                    _ovrall = (_dcompl / _interface) * 100;
                e.Row.Cells[9].Text = decimal.Round(_ovrall,0,MidpointRounding.AwayFromZero).ToString() + "%";
            }


        }
        private bool DateValidation(string dateString)
        {
            DateTime dateValue;
            string[] format = new string[] { "dd/MM/yyyy" };
            if (DateTime.TryParseExact(dateString, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out dateValue))
                return true;
            else
                return false;

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

        

       

      
       

       
       

    }
}
