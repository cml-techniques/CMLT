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
    public partial class CAS_Commissioning11 : System.Web.UI.Page
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
                lblprj.Text = Request.QueryString["prj"].ToString();
                lblsch.Text = Request.QueryString["sch"].ToString();
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
            if (lblsch.Text == "5" || lblsch.Text == "1")
            {
                lbnum.Text = "NO.OF CIRCUITS";
                lbl1.Text = "PROVIDES POWER TO";
                lbl3.Text = "FED FROM";
                lblhead.Text = "CAS E4 Electrical Services. LV Commissioning Activity Schedule";
                td_2.Visible = false; td_lbl2.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "8")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                lblppon.Text = "PLANNED POWER ON";
                lblhead.Text = "CAS M1 Mechanical Services Commissioning Activity Schedule";
                td_0.Visible = false; td_lbnum.Visible = false; td_lbl1.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;

            }
            else if (lblsch.Text == "17")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                lblhead.Text = "CAS PH1 Public Health Services Commissioning Activity Schedule";
                td_lbl2.Visible = false; td_2.Visible = false;
                td_0.Visible = false; td_lbl1.Visible = false; td_lbnum.Visible = false; td_3.Visible = false;
            }
            else if (lblsch.Text == "10")
            {
                lbl1.Text = "";
                lbl2.Text = "NO.OF DEVICES";
                lbl3.Text = "";
                lbnum.Text = "NO.OF INTERFACES";
                drfed.Style.Add("display", "none");
                lblhead.Text = "CAS ELV1 Fire Alarm & Voice Evacuation Commissioning Activity Schedule";
                td_lbl3.Visible = false; td_1.Visible = false; td_lbl1.Visible = false; td_0.Visible = false; td_lbl3.Visible = false; td_1.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;


            }
            else if (lblsch.Text == "6")
            {
                lbnum.Text = "";
                lbl1.Text = "PROVIDES EARTHING/LIGHTNING PROTECTION TO";
                lbl2.Text = "";
                lbl3.Text = "";
                drfed.Style.Add("display", "none");
                lblhead.Text = "CAS E3 Electrical Services. Earthing & Lightning Protection Commissioning Activity Schedule";
                td_2.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_lbnum.Visible = false; td_1.Visible = false; td_lbl3.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "21")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "";
                lbnum.Text = "FLUSHING STAGE";
                lblhead.Text = "CAS M2 Flushing Commissioning Activity Schedule";
                td_0.Visible = false; td_lbl1.Visible = false; td_lbl3.Visible = false; td_1.Visible = false; td_2.Visible = false; td_lbl2.Visible = false;
            }
            else if (lblsch.Text == "4")
            {
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "SUBSTATION";
                lbl3.Text = "FED FROM";
                td_2.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_lbnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
                lblhead.Text = "CAS E5 Electrical Services. Generator Commissioning Activity Schedule";
            }
            else if (lblsch.Text == "7")
            {
                lbnum.Text = "NO.OF EMERGENCY LIGHTS";
                lbl1.Text = "";
                lbl3.Text = "";
                lbl2.Text = "NO.OF CIRCUITS";
                drfed.Style.Add("display", "none");
                lblhead.Text = "CAS E6 Electrical Services. Emergency Lighting Commissioning Activity Schedule";
                td_2.Visible = false; td_lbl2.Visible = false; td_1.Visible = false; td_lbl3.Visible = false; td_lbl1.Visible = false; td_0.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "18")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "";
                lbnum.Text = "QUANTITY";
                drfed.Style.Add("display", "none");
                    lblhead.Text = "CAS PH2 Fire Protection Services  Commissioning Activity Schedule";
                td_0.Visible = false; td_lbl1.Visible = false; td_lbl3.Visible = false; td_1.Visible = false; td0.Visible = false; td_lbl0.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
            }
            else if (lblsch.Text == "19")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                lbnum.Text = "";
                lblhead.Text = "CAS PH3 Fire Extinguishing Systems Commissioning Activity Schedule";
                td_0.Visible = false; td_lbl1.Visible = false; td_lbl2.Visible = false; td_2.Visible = false; td_3.Visible = false; td_lbnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "20")
            {
                lbl1.Text = "NO.OF POINTS";
                lbl2.Text = "NO.OF DEVICES REQUIRED CALIBRATION";
                lbl3.Text = "SYSTEM CONTROLLED/ MONITORED BY DDC";
                lbnum.Text = "NO.OF SYSTEM REQUIRED LOOP TUNING";
                drfed.Style.Add("display", "none");
                lblhead.Text = "CAS ELV2 Building Management System Commissioning Activity Schedule";
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "15")
            {

                lblhead.Text = "CAS ELV1a VESDA System Commissioning Activity Schedule";
                td_lbl1.Visible = false; ; td_0.Visible = false;
                lbl2.Text = "NO.OF DEVICES";
                lbnum.Text = "NO.OF INTERFACES";
                td_lbl1.Visible = false;
                td_lbl3.Visible = false;
                td_1.Visible = false;

                td_lbldes.Visible = false; td_txtdescr.Visible = false;


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
            if (lblprj.Text == "HMIM" || lblprj.Text == "14211")
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
            Load_cassheet_details(Convert.ToInt32(_item1.Text));
            if (lblsch.Text == "5") { btnDummy_ModalPopupExtender4.Show(); _5lbl.Text = _title; }
            else if (lblsch.Text == "8") { btnDummy_ModalPopupExtender7.Show(); _8lbl.Text = _title; }
            else if (lblsch.Text == "17") { btnDummy_ModalPopupExtender10.Show(); _17lbl.Text = _title; }
            else if (lblsch.Text == "10") { btnDummy_ModalPopupExtender13.Show(); _10lbl.Text = _title; }
            else if (lblsch.Text == "6")
            {
                _6lbl.Text = _title;
                if ((string)Session["cat"] == "LP")
                {
                    chk_6ep.Checked = true; chk_6accept1.Checked = true; chk_6filed1.Checked = true; chk_6be.Checked = true; chk_6accept2.Checked = true; chk_6filed2.Checked = true;
                    _6lp.Enabled = true; _6accept3.Enabled = true; _6filed3.Enabled = true; _6br.Enabled = true; _6accept4.Enabled = true; _6filed4.Enabled = true;
                    _6ep.Text = "N/A"; _6accept1.Text = "N/A"; _6filed1.Text = "N/A"; _6be.Text = "N/A"; _6accept2.Text = "N/A"; _6filed2.Text = "N/A";
                    _6ep.Enabled = false; _6accept1.Enabled = false; _6filed1.Enabled = false; _6be.Enabled = false; _6accept2.Enabled = false; _6filed2.Enabled = false;
                    _6ebp.Enabled = false; _6epp.Enabled = false; _6lpp.Enabled = true; _6brp.Enabled = true;
                }
                else
                {
                    chk_6lp.Checked = true; chk_6accept3.Checked = true; chk_6filed3.Checked = true; chk_6br.Checked = true; chk_6accept4.Checked = true; chk_6filed4.Checked = true;
                    _6ep.Enabled = true; _6accept1.Enabled = true; _6filed1.Enabled = true; _6be.Enabled = true; _6accept2.Enabled = true; _6filed2.Enabled = true;
                    _6lp.Text = "N/A"; _6accept3.Text = "N/A"; _6filed3.Text = "N/A"; _6br.Text = "N/A"; _6accept4.Text = "N/A"; _6filed4.Text = "N/A";
                    _6lp.Enabled = false; _6accept3.Enabled = false; _6filed3.Enabled = false; _6br.Enabled = false; _6accept4.Enabled = false; _6filed4.Enabled = false;
                    _6ebp.Enabled = true; _6epp.Enabled = true; _6lpp.Enabled = false; _6brp.Enabled = false;
                }

                btnDummy_ModalPopupExtender3.Show();
            }
            else if (lblsch.Text == "21") { btnDummy_ModalPopupExtender8.Show(); _21lbl.Text = _title; }
            else if (lblsch.Text == "4") { btnDummy_ModalPopupExtender5.Show(); _4lbl.Text = _title; }
            else if (lblsch.Text == "7") { btnDummy_ModalPopupExtender6.Show(); _7lbl.Text = _title; }
            else if (lblsch.Text == "18") { btnDummy_ModalPopupExtender11.Show(); _18lbl.Text = _title; }
            else if (lblsch.Text == "19") { btnDummy_ModalPopupExtender12.Show(); _19lbl.Text = _title; }
            else if (lblsch.Text == "20") { btnDummy_ModalPopupExtender14.Show(); _20lbl.Text = _title; }
            else if (lblsch.Text == "15") { btnDummy_ModalPopupExtender15a.Show(); _15albl.Text = _title; }

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
            e.Row.Cells[6].Text = SeqNo(e.Row.Cells[6].Text);
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
            if (lblsch.Text == "1" || lblsch.Text == "5")
            {
                e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "6")
            {
                e.Row.Cells[9].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "8")
            {

                e.Row.Cells[10].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if (lblsch.Text == "17")
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if (lblsch.Text == "10")
            {
                e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "21")
            {
                e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if (lblsch.Text == "4")
            {
                e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "7")
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[9].Visible = false;
                e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if (lblsch.Text == "18")
            {
                e.Row.Cells[8].Visible = false; e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if (lblsch.Text == "19")
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "20")
            {
                e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "15")
            {
                e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false;
            }
            //e.Row.Cells[9].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
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
        private void Update(string pwron, string test1, string test2, string test3, string test4, string test5, string test6, string test7, string test8, string test9, string test10, string test11, string test12, string tested1, string tested2, string compld1, string compld2, string dvce, string accept1, string accept2, string filed1, string filed2, string comts, string actby, string actdt, string planned1, string planned2, string planned3, string planned4, string planned5)
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
            _objcls.test15 = "";
            _objcls.tested1 = tested1;
            _objcls.test8 = compld1;
            _objcls.tested2 = tested2;
            _objcls.test9 = compld2;
            _objcls.comm = comts;
            _objcls.act_by = actby;
            _objcls.act_date = actdt;
            _objcls.compl = "";//testing planned completion date
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
            _objcls.per_com9 = 0;
            _objcls.per_com10 = 0;
            _objcls.planned1 = planned1;
            _objcls.planned2 = planned2;
            _objcls.planned3 = planned3;
            _objcls.planned4 = planned4;
            _objcls.planned5 = planned5;
            _objbll.Cassheet_update1(_objcls, _objdb);
        }
        protected decimal per_com1()
        {

            decimal _percentage = 0;
            int count = 0;
            if (lblsch.Text == "5")
            {
                decimal _nos = 0;
                if (DateValidation(_5tor.Text) == true)
                    count += 1;
                if (DateValidation(_5ir.Text) == true)
                    count += 1;
                if (DateValidation(_5pr.Text) == true)
                    count += 1;
                if (DateValidation(_5si.Text) == true)
                    count += 1;
                if (DateValidation(_5cr.Text) == true)
                    count += 1;
                if (DateValidation(_5fn.Text) == true)
                    count += 1;
                if (DateValidation(_5tor.Text) == true || _5tor.Text == "")
                    _nos += 1;
                if (DateValidation(_5ir.Text) == true || _5ir.Text == "")
                    _nos += 1;
                if (DateValidation(_5pr.Text) == true || _5pr.Text == "")
                    _nos += 1;
                if (DateValidation(_5si.Text) == true || _5si.Text == "")
                    _nos += 1;
                if (DateValidation(_5cr.Text) == true || _5cr.Text == "")
                    _nos += 1;
                if (DateValidation(_5fn.Text) == true || _5fn.Text == "")
                    _nos += 1;
                if (_nos > 0) _percentage = (Convert.ToDecimal(count) / _nos) * 100;
                else _percentage = -1;
            }
            else if (lblsch.Text == "8")
            {
                if (DateValidation(_8pc1.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "17")
            {
                if (DateValidation(_17pc1.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "10")
            {
                if (DateValidation(_10ccit.Text) == true)
                    _percentage = 1;
                else if (_10ccit.Text == "N/A")
                    _percentage = -1;

            }
            else if (lblsch.Text == "6")
            {
                if (DateValidation(_6ep.Text) == true)
                    _percentage = 100;
                else if (_6ep.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "21")
            {
                if (DateValidation(_21pf.Text)==true)
                    count += 1;
                if (DateValidation(_21fvr.Text)==true)
                    count += 1;
                if (DateValidation(_21cc.Text)==true)
                    count += 1;
                if (DateValidation(_21facc.Text)==true)
                    count += 1;
                if (DateValidation(_21bfc.Text)==true)
                    count += 1;
                if (DateValidation(_21fct.Text)==true)
                    count += 1;
                decimal _nos = 0;
                if (DateValidation(_21pf.Text) == true || _21pf.Text == "")
                    _nos += 1;
                if (DateValidation(_21fvr.Text) == true || _21fvr.Text == "")
                    _nos += 1;
                if (DateValidation(_21cc.Text) == true || _21cc.Text == "")
                    _nos += 1;
                if (DateValidation(_21facc.Text) == true || _21facc.Text == "")
                    _nos += 1;
                if (DateValidation(_21bfc.Text) == true || _21bfc.Text == "")
                    _nos += 1;
                if (DateValidation(_21fct.Text) == true || _21fct.Text == "")
                    _nos += 1;
                if (_nos > 0)
                    _percentage = (Convert.ToDecimal(count) / _nos) * 100;
                else
                    _percentage = -1;
            }
            else if (lblsch.Text == "4")
            {
                int _no = 0;
                if (DateValidation(_4pc.Text) == true)
                    count += 1;
                if (DateValidation(_4as.Text) == true)
                    count += 1;
                if (DateValidation(_4lb.Text) == true)
                    count += 1;

                if (_4pc.Text != "N/A")
                    _no += 1;
                if (_4as.Text != "N/A")
                    _no += 1;
                if (_4lb.Text != "N/A")
                    _no += 1;

                _percentage = (Convert.ToDecimal(count) / _no) * 100;
            }
            else if (lblsch.Text == "7")
            {
                if (IsNumeric(_7cir.Text) == true)
                    _percentage = Convert.ToDecimal(_7cir.Text);
                else if (_7cir.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "18")
            {
                if (IsNumeric(_18qt.Text))
                    _percentage = Convert.ToDecimal(_18qt.Text);
            }
            else if (lblsch.Text == "19")
            {
                if (_19rsit.Text != "")
                    count += 1;
                if (_19sac.Text != "")
                    count += 1;
                if (_19fbit.Text != "")
                    count += 1;
                _percentage = (Convert.ToDecimal(count) / 3) * 100;

            }
            else if (lblsch.Text == "20")
            {
                if (IsNumeric(_20cit.Text))
                    _percentage = Convert.ToDecimal(_20cit.Text);
                else if (_20cit.Text == "N/A")
                    _percentage = -1;

            }
            else if (lblsch.Text == "15")
            {
                if (IsNumeric(_15acit.Text))
                    _percentage = Convert.ToDecimal(_15acit.Text);
                else if (_15acit.Text == "N/A")
                    _percentage = -1;

            }
            return _percentage;
        }
        protected decimal per_com2()
        {

            decimal _percentage = 0;
            if (lblsch.Text == "5")
            {
                if (IsNumeric(_5tc.Text) == true)
                {
                    _percentage = Convert.ToDecimal(_5tc.Text);
                }
            }
            else if (lblsch.Text == "8")
            {
                if (DateValidation(_8co1.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "17")
            {
                if (DateValidation(_17co1.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "10")
            {
                //if (IsNumeric(_10ndt.Text) == true)
                //    _percentage = Convert.ToDecimal(_10ndt.Text);
                //else if (_10ndt.Text == "N/A")
                //    _percentage = -1;
                if (DateValidation(_10dtc.Text) == true)
                    _percentage = 1;
                else if (_10dtc.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "6")
            {
                if (DateValidation(_6be.Text) == true)
                    _percentage = 100;
                else if (_6be.Text == "N/A")
                    _percentage = -1;

            }
            else if (lblsch.Text == "4")
            {
                if (DateValidation(_4cable.Text) == true)
                    _percentage = 100;
                else if (_4cable.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "7")
            {
                if (IsNumeric(_7add.Text) == true)
                    _percentage = Convert.ToDecimal(_7add.Text);
                else if (_7add.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "20")
            {
                if (IsNumeric(_20ppt.Text) == true)
                    _percentage = Convert.ToDecimal(_20ppt.Text);
                else if (_20ppt.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "15")
            {
                if (IsNumeric(_15atht.Text) == true)
                    _percentage = Convert.ToDecimal(_15atht.Text);
                else if (_15atht.Text == "N/A")
                    _percentage = -1;

            }
            return _percentage;
        }
        protected decimal per_com3()
        {

            decimal _percentage = 0;
            if (lblsch.Text == "5")
            {
                if (IsNumeric(_5tl.Text) == true)
                {
                    _percentage = Convert.ToDecimal(_5tl.Text);
                }
            }
            else if (lblsch.Text == "8")
            {
                if (DateValidation(_8wd1.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "17")
            {
                if (DateValidation(_17wd1.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "10")
            {
                if (DateValidation(_10fait.Text) == true)
                    _percentage = 1;
                else if (_10fait.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "6")
            {
                if (DateValidation(_6lp.Text) == true)
                    _percentage = 100;
                else if (_6lp.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "4")
            {
                if (DateValidation(_4sol.Text) == true)
                    _percentage = 100;
                else if (_4sol.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "7")
            {
                if (IsNumeric(_7ft.Text) == true)
                    _percentage = Convert.ToDecimal(_7ft.Text);
                else if (_7ft.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "20")
            {
                if (IsNumeric(_20cft.Text) == true)
                    _percentage = Convert.ToDecimal(_20cft.Text);
                else if (_20cft.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "15")
            {
                if (IsNumeric(_15athtc.Text) == true)
                    _percentage = Convert.ToDecimal(_15athtc.Text);
                else if (_15athtc.Text == "N/A")
                    _percentage = -1;

            }
            return _percentage;
        }
        protected decimal per_com4()
        {

            decimal _percentage = 0;
            if (lblsch.Text == "5")
            {
                if (_5accept1.Text.ToUpper() != "N/A" && _5accept2.Text.ToUpper() == "N/A")
                {
                    if (DateValidation(_5accept1.Text) == true)
                        _percentage = 1;
                }
                else if (_5accept1.Text.ToUpper() == "N/A" && _5accept2.Text.ToUpper() != "N/A")
                {
                    if (DateValidation(_5accept2.Text) == true)
                        _percentage = 1;
                }
                else
                {
                    if (DateValidation(_5accept1.Text) == true && DateValidation(_5accept2.Text) == true)
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "8")
            {
                if (IsNumeric(_8duty.Text) == true)
                    _percentage = Convert.ToDecimal(_8duty.Text);
            }
            else if (lblsch.Text == "17")
            {
                decimal _total = per_com1() + per_com2();
                _percentage = (_total / 2) * 100;
            }
            else if (lblsch.Text == "10")
            {
                if (DateValidation(_10slt.Text) == true)
                    _percentage = 1;
                else if (_10slt.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "6")
            {
                if (DateValidation(_6br.Text) == true)
                    _percentage = 100;
                else if (_6br.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "7")
            {
                if (IsNumeric(_7co.Text) == true)
                    _percentage = Convert.ToDecimal(_7co.Text);
                else if (_7co.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "20")
            {
                if (IsNumeric(_20sot.Text) == true)
                    _percentage = Convert.ToDecimal(_20sot.Text);
                else if (_20sot.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "15")
            {
                if (IsNumeric(_15afit.Text) == true)
                    _percentage = Convert.ToDecimal(_15afit.Text);
                else if (_15afit.Text == "N/A")
                    _percentage = -1;
            }
            return _percentage;
        }
        protected decimal per_com5()
        {

            decimal _percentage = 0;
            if (lblsch.Text == "10")
            {
                if (DateValidation(_10bat.Text) == true)
                    _percentage = 1;
                else if (_10bat.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "6")
            {
                if ((string)Session["cat"] == "LP")
                {
                    if (DateValidation(_6accept3.Text) == true && DateValidation(_6accept4.Text) == true)
                        _percentage = 1;
                }
                else
                {
                    if (DateValidation(_6accept1.Text) == true && DateValidation(_6accept2.Text) == true)
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "7")
            {
                if (IsNumeric(_7ll.Text) == true)
                    _percentage = Convert.ToDecimal(_7ll.Text);
                else if (_7ll.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "20")
            {
                if (IsNumeric(_20ght.Text) == true)
                    _percentage = Convert.ToDecimal(_20ght.Text);
                else if (_20ght.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "15")
            {
                if (IsNumeric(_15athtc.Text) == true)
                    _percentage = Convert.ToDecimal(_15athtc.Text);
                else if (_15athtc.Text == "N/A")
                    _percentage = -1;

            }
            return _percentage;
        }
        protected decimal per_com6()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "10")
            {
                if (DateValidation(_10ghet.Text) == true)
                    _percentage = 1;
                else if (_10ghet.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "7")
            {
                if (IsNumeric(_7du.Text) == true)
                    _percentage = Convert.ToDecimal(_7du.Text);
                else if (_7du.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "20")
            {
                if (IsNumeric(_20lt.Text) == true)
                    _percentage = Convert.ToDecimal(_20lt.Text);
                else if (_20lt.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "15")
            {
                if (IsNumeric(_15abat.Text) == true)
                    _percentage = Convert.ToDecimal(_15abat.Text);
                else if (_15abat.Text == "N/A")
                    _percentage = -1;


            }
            return _percentage;
        }
        protected decimal per_com7()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "10")
            {
                if (DateValidation(_10cet.Text) == true)
                    _percentage = 1;
                else if (_10cet.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "7")
            {
                if (IsNumeric(_7pch.Text) == true)
                    _percentage = Convert.ToDecimal(_7pch.Text);
                else if (_7pch.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "15")
            {
                if (IsNumeric(_15acet.Text) == true)
                    _percentage = Convert.ToDecimal(_15acet.Text);
                else if (_15acet.Text == "N/A")
                    _percentage = -1;

            }
            return _percentage;
        }
        protected decimal per_com8()
        {
            decimal _percentage = 0;
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

        private void Load_cassheet_details(int cas_id)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            //_objcas.sch = Convert.ToInt32(lblsch.Text);
            //_objcas.prj_code = lblprj.Text;
            //DataTable _dt = _objbll.Load_casMain_Edit(_objcas, _objdb);
            _objcas.cas_id = cas_id;
            DataTable _dt = _objbll.Load_CAS_Details(_objcas, _objdb);
            //var result = from o in _dt.AsEnumerable
            //             where o.Field<int>(0) == Convert.ToInt32((string)Session["casid"])
            //             select o;
            //foreach (var row in result)
            //{
            foreach (DataRow row in _dt.Rows)
            {
                if (lblsch.Text == "1" || lblsch.Text == "5")
                {
                    _5pwron.Text = row[14].ToString();
                    _5tor.Text = row[24].ToString();
                    _5ir.Text = row[25].ToString();
                    _5pr.Text = row[26].ToString();
                    _5si.Text = row[27].ToString();
                    _5cr.Text = row[28].ToString();
                    _5fn.Text = row[29].ToString();
                    if (row[21].ToString() != "0")
                        _5total.Text = row[21].ToString();
                    else
                        _5total.Text = "";
                    _5accept1.Text = row["accept1"].ToString();
                    _5filed1.Text = row["filed1"].ToString();
                    _5accept2.Text = row["accept2"].ToString();
                    _5filed2.Text = row["filed2"].ToString();
                    _5commts.Text = row[18].ToString();
                    _5actby.Text = row[19].ToString();
                    _5actdt.Text = row[20].ToString();
                    _5tc.Text = row["tested1"].ToString();
                    _5cc.Text = row[31].ToString();
                    _5tl.Text = row["tested2"].ToString();
                    _5lc.Text = row[32].ToString();
                    _5ptp.Text = row["PCdate"].ToString();
                    _5ctp.Text = row["PCdate1"].ToString();
                    _5ltp.Text = row["PCdate2"].ToString();

                    SetCheckedBoxChecked(_5tor, chk_5tor);
                    SetCheckedBoxChecked(_5ir, chk_5ir);
                    SetCheckedBoxChecked(_5pr, chk_5pr);
                    SetCheckedBoxChecked(_5si, chk_5si);
                    SetCheckedBoxChecked(_5cr, chk_5cr);
                    SetCheckedBoxChecked(_5fn, chk_5fn);
                    //SetCheckedBoxChecked(_5total, chk_5total);
                    SetCheckedBoxChecked(_5accept1, chk_5accept1);
                    SetCheckedBoxChecked(_5filed1, chk_5filed1);
                    SetCheckedBoxChecked(_5accept2, chk_5accept2);
                    SetCheckedBoxChecked(_5filed2, chk_5filed2);
                    SetCheckedBoxChecked(_5tc, chk_5tc);
                    SetCheckedBoxChecked(_5cc, chk_5cc);
                    SetCheckedBoxChecked(_5tl, chk_5tl);
                    SetCheckedBoxChecked(_5lc, chk_5lc);

                    SetCheckedBoxChecked(_5actby, chk_5actby);
                    SetCheckedBoxChecked(_5actdt, chk_5actdt);


                }
                else if (lblsch.Text == "8")
                {
                    _8pwron.Text = row[14].ToString();
                    _8pc1.Text = row[24].ToString();
                    _8co1.Text = row[25].ToString();
                    _8wd1.Text = row[26].ToString();
                    _8pc2.Text = row[27].ToString();
                    _8co2.Text = row[28].ToString();
                    _8wd2.Text = row[29].ToString();
                    _8duty.Text = row["per_com4"].ToString();
                    _8accept1.Text = row["accept1"].ToString();
                    _8filed1.Text = row["filed1"].ToString();
                    _8commts.Text = row[18].ToString();
                    _8actby.Text = row[19].ToString();
                    _8actdt.Text = row[20].ToString();
                    _8pcp.Text = row["PCdate"].ToString();
                    _8cp.Text = row["PCdate1"].ToString();
                    SetCheckedBoxChecked(_8pc1, chk_8pc1);
                    SetCheckedBoxChecked(_8co1, chk_8co1);
                    SetCheckedBoxChecked(_8wd1, chk_8wd1);
                    SetCheckedBoxChecked(_8pc2, chk_8pc2);
                    SetCheckedBoxChecked(_8co2, chk_8co2);

                    SetCheckedBoxChecked(_8accept1, chk_8accept1);
                    SetCheckedBoxChecked(_8filed1, chk_8filed1);
                    SetCheckedBoxChecked(_8wd2, chk_8wd2);

                    //SetCheckedBoxChecked(_8commts, chk_8commts);
                    SetCheckedBoxChecked(_8actby, chk_8actby);
                    SetCheckedBoxChecked(_8actdt, chk_8actdt);


                }
                else if (lblsch.Text == "17")
                {
                    _17pwron.Text = row[14].ToString();
                    _17pc1.Text = row[24].ToString();
                    _17co1.Text = row[25].ToString();
                    _17wd1.Text = row[26].ToString();
                    _17pc2.Text = row[27].ToString();
                    _17co2.Text = row[28].ToString();
                    _17wd2.Text = row[29].ToString();
                    _17accept1.Text = row["accept1"].ToString();
                    _17filed1.Text = row["filed1"].ToString();
                    _17commts.Text = row[18].ToString();
                    _17actby.Text = row[19].ToString();
                    _17actdt.Text = row[20].ToString();
                    _17pcp.Text = row["PCdate"].ToString();
                    _17cp.Text = row["PCdate1"].ToString();
                    SetCheckedBoxChecked(_17pwron, chk_17pwron);
                    SetCheckedBoxChecked(_17pc1, chk_17pc1);
                    SetCheckedBoxChecked(_17co1, chk_17co1);
                    SetCheckedBoxChecked(_17wd1, chk_17wd1);
                    SetCheckedBoxChecked(_17pc2, chk_17pc2);
                    SetCheckedBoxChecked(_17co2, chk_17co2);
                    SetCheckedBoxChecked(_17wd2, chk_17wd2);
                    SetCheckedBoxChecked(_17accept1, chk_17accept1);
                    SetCheckedBoxChecked(_17filed1, chk_17filed1);

                    SetCheckedBoxChecked(_17actby, chk_17actby);
                    SetCheckedBoxChecked(_17actdt, chk_17actdt);
                    //SetCheckedBoxChecked(_17commts, chk_17commts);



                }
                else if (lblsch.Text == "10")
                {
                    _10ccit.Text = row[24].ToString();
                    _10ndt.Text = row[25].ToString();
                    _10dtc.Text = row[26].ToString();
                    _10fait.Text = row[27].ToString();
                    _10ltc.Text = row[28].ToString();
                    _10slt.Text = row[29].ToString();
                    _10bat.Text = row[30].ToString();
                    _10ghet.Text = row["test11"].ToString();
                    _10cet.Text = row["test10"].ToString();
                    _10accept1.Text = row["accept1"].ToString();
                    _10filed1.Text = row["filed1"].ToString();
                    _10accept2.Text = row["accept2"].ToString();
                    _10filed2.Text = row["filed2"].ToString();
                    _10commts.Text = row[18].ToString();
                    _10actby.Text = row[19].ToString();
                    _10actdt.Text = row[20].ToString();
                    _10devices.Text = row["devices2"].ToString();
                    _10interface.Text = row["devices1"].ToString();
                    //_10iet.Text = row["test12"].ToString();

                    _10ccitp.Text = row["PCdate"].ToString();
                    _10dtp.Text = row["PCdate1"].ToString();
                    _10itp.Text = row["PCdate2"].ToString();
                    //SetCheckedBoxChecked(_10commts, chk_10commts);
                    SetCheckedBoxChecked(_10actby, chk_10actby);
                    SetCheckedBoxChecked(_10actdt, chk_10actdt);
                    // SetCheckedBoxChecked(_10devices, chk_10devices);
                    //SetCheckedBoxChecked(_10interface, chk_10interface);


                    SetCheckedBoxChecked(_10ccit, chk_10ccit);
                    SetCheckedBoxChecked(_10ndt, chk_10ndt);
                    SetCheckedBoxChecked(_10dtc, chk_10dtc);
                    SetCheckedBoxChecked(_10fait, chk_10fait);
                    SetCheckedBoxChecked(_10ltc, chk_10ltc);
                    SetCheckedBoxChecked(_10slt, chk_10slt);
                    SetCheckedBoxChecked(_10bat, chk_10bat);
                    SetCheckedBoxChecked(_10ghet, chk_10ghet);
                    SetCheckedBoxChecked(_10cet, chk_10cet);
                    SetCheckedBoxChecked(_10accept1, chk_10accept1);
                    SetCheckedBoxChecked(_10filed1, chk_10filed1);
                    //SetCheckedBoxChecked(_10iet, chk_10iet);

                }
                else if (lblsch.Text == "6")
                {
                    _6ep.Text = row[24].ToString();
                    _6accept1.Text = row[25].ToString();
                    _6filed1.Text = row[26].ToString();
                    _6be.Text = row[29].ToString();
                    _6br.Text = row["test10"].ToString();
                    _6lp.Text = row["test9"].ToString();
                    _6accept2.Text = row["accept1"].ToString();
                    _6filed2.Text = row["filed1"].ToString();
                    _6accept3.Text = row["tested1"].ToString();
                    _6filed3.Text = row[31].ToString();
                    _6accept4.Text = row["accept2"].ToString();
                    _6filed4.Text = row["filed2"].ToString();
                    _6commts.Text = row[18].ToString();
                    _6actby.Text = row[19].ToString();
                    _6actdt.Text = row[20].ToString();

                    if ((string)Session["cat"] == "LP")
                    {
                        _6lpp.Text = row["PCdate"].ToString();
                        _6brp.Text = row["PCdate1"].ToString();
                        _6epp.Text = "";
                        _6ebp.Text = "";
                    }
                    else
                    {
                        _6epp.Text = row["PCdate"].ToString();
                        _6ebp.Text = row["PCdate1"].ToString();
                        _6lpp.Text = "";
                        _6brp.Text = "";
                    }
                    SetCheckedBoxChecked(_6ep, chk_6ep);
                    SetCheckedBoxChecked(_6accept1, chk_6accept1);
                    SetCheckedBoxChecked(_6filed1, chk_6filed1);
                    SetCheckedBoxChecked(_6accept2, chk_6accept2);
                    SetCheckedBoxChecked(_6filed2, chk_6filed2);
                    SetCheckedBoxChecked(_6accept3, chk_6accept3);
                    SetCheckedBoxChecked(_6filed3, chk_6filed3);
                    SetCheckedBoxChecked(_6accept4, chk_6accept4);
                    SetCheckedBoxChecked(_6filed4, chk_6filed4);
                    SetCheckedBoxChecked(_6be, chk_6be);
                    SetCheckedBoxChecked(_6br, chk_6br);
                    SetCheckedBoxChecked(_6lp, chk_6lp);

                    SetCheckedBoxChecked(_6actby, chk_6actby);
                    SetCheckedBoxChecked(_6actdt, chk_6actdt);

                }
                else if (lblsch.Text == "21")
                {
                    _21pwron.Text = row[14].ToString();
                    _21pf.Text = row[24].ToString();
                    _21fvr.Text = row[25].ToString();
                    _21cc.Text = row[26].ToString();
                    _21facc.Text = row[27].ToString();
                    _21bfc.Text = row[28].ToString();
                    _21fct.Text = row[29].ToString();
                    _21accept1.Text = row["accept1"].ToString();
                    _21filed1.Text = row["filed1"].ToString();
                    _21commts.Text = row[18].ToString();
                    _21actby.Text = row[19].ToString();
                    _21actdt.Text = row[20].ToString();

                    _21pcd.Text = row["PCdate"].ToString();
                    SetCheckedBoxChecked(_21pwron, chk_21pwron);
                    SetCheckedBoxChecked(_21pf, chk_21pf);
                    SetCheckedBoxChecked(_21cc, chk_21fvr);
                    SetCheckedBoxChecked(_21cc, chk_21cc);
                    //SetCheckedBoxChecked(_21facc, chk__21facc);
                    SetCheckedBoxChecked(_21bfc, chk_21bfc);
                    SetCheckedBoxChecked(_21fct, chk_21fct);
                    SetCheckedBoxChecked(_21accept1, chk_21accept1);
                    SetCheckedBoxChecked(_21filed1, chk_21filed1);

                    //SetCheckedBoxChecked(_21commts, chk_21commts);
                    SetCheckedBoxChecked(_21actby, chk_21actby);
                    SetCheckedBoxChecked(_21actdt, chk_21actdt);
                    SetCheckedBoxChecked(_21fvr, chk_21fvr);


                }
                else if (lblsch.Text == "4")
                {
                    _4pc.Text = row[24].ToString();
                    _4as.Text = row[25].ToString();
                    _4lb.Text = row[26].ToString();
                    _4accept1.Text = row[27].ToString();
                    _4filed1.Text = row[28].ToString();
                    _4cable.Text = row[29].ToString();
                    _4sol.Text = row[30].ToString();
                    _4accept2.Text = row["accept1"].ToString();
                    _4filed2.Text = row["filed1"].ToString();
                    _4accept3.Text = row["accept2"].ToString();
                    _4filed3.Text = row["filed2"].ToString();
                    _4commts.Text = row[18].ToString();
                    _4actby.Text = row[19].ToString();
                    _4actdt.Text = row[20].ToString();

                    _4pcd.Text = row["PCdate"].ToString();
                    _4cablep.Text = row["PCdate1"].ToString();
                    _4solp.Text = row["PCdate2"].ToString();


                    SetCheckedBoxChecked(_4pc, chk_4pc);
                    SetCheckedBoxChecked(_4as, chk_4as);
                    SetCheckedBoxChecked(_4lb, chk_4lb);
                    SetCheckedBoxChecked(_4accept1, chk_4accept1);
                    SetCheckedBoxChecked(_4filed1, chk_4filed1);
                    SetCheckedBoxChecked(_4filed2, chk_4filed2);
                    SetCheckedBoxChecked(_4filed3, chk_4filed3);
                    SetCheckedBoxChecked(_4cable, chk_4cable);
                    SetCheckedBoxChecked(_4sol, chk_4sol);
                    SetCheckedBoxChecked(_4accept2, chk_4accept2);
                    SetCheckedBoxChecked(_4accept3, chk_4accept3);

                    SetCheckedBoxChecked(_4actby, chk_4actby);
                    SetCheckedBoxChecked(_4actdt, chk_4actdt);




                }
                else if (lblsch.Text == "7")
                {

                    _7cir.Text = row[24].ToString();
                    _7add.Text = row[25].ToString();
                    _7ft.Text = row[26].ToString();
                    _7co.Text = row[27].ToString();
                    _7ll.Text = row[28].ToString();
                    _7du.Text = row[29].ToString();
                    _7pch.Text = row[30].ToString();
                    _7accept1.Text = row["accept1"].ToString();
                    _7filed1.Text = row["filed1"].ToString();
                    _7commts.Text = row[18].ToString();
                    _7actby.Text = row[19].ToString();
                    _7actdt.Text = row[20].ToString();
                    _7noof.Text = row[21].ToString();
                    _7nocir.Text = row[22].ToString();

                    _7pc.Text = row["PCdate"].ToString();

                    SetCheckedBoxChecked(_7accept1, chk_7accept1);
                    SetCheckedBoxChecked(_7filed1, chk_7filed1);
                    SetCheckedBoxChecked(_7cir, chk_7cir);

                    SetCheckedBoxChecked(_7add, chk_7add);
                    SetCheckedBoxChecked(_7ft, chk_7ft);
                    SetCheckedBoxChecked(_7co, chk_7co);
                    SetCheckedBoxChecked(_7ll, chk_7ll);
                    SetCheckedBoxChecked(_7du, chk_7du);
                    SetCheckedBoxChecked(_7pch, chk_7pch);

                    SetCheckedBoxChecked(_7actby, chk_7actby);
                    SetCheckedBoxChecked(_7actdt, chk_7actdt);
                    //SetCheckedBoxChecked(_7commts, chk_7commts);



                }
                else if (lblsch.Text == "18")
                {
                    if ((string)Session["cat"] == "FHR") _18qt.Text = row[24].ToString();
                    else if ((string)Session["cat"] == "ZCV") _18qt.Text = row[25].ToString();
                    else if ((string)Session["cat"] == "MOV") _18qt.Text = row[26].ToString();
                    else if ((string)Session["cat"] == "PRS") _18qt.Text = row[27].ToString();
                    else if ((string)Session["cat"] == "LGV") _18qt.Text = row[28].ToString();
                    else if ((string)Session["cat"] == "CSC") _18qt.Text = row[29].ToString();
                    _18wt.Text = row[30].ToString();
                    _18accept1.Text = row["accept1"].ToString();
                    _18filed1.Text = row["filed1"].ToString();
                    _18commts.Text = row[18].ToString();
                    _18actby.Text = row[19].ToString();
                    _18actdt.Text = row[20].ToString();
                    _18noof.Text = row[21].ToString();

                    _18pcd.Text = row["PCdate"].ToString();

                    SetCheckedBoxChecked(_18qt, chk_18qt);
                    SetCheckedBoxChecked(_18wt, chk_18wt);
                    SetCheckedBoxChecked(_18accept1, chk_18accept1);
                    SetCheckedBoxChecked(_18filed1, chk_18filed1);


                    //SetCheckedBoxChecked(_18commts, chk_18commts);
                    SetCheckedBoxChecked(_18actby, chk_18actby);
                    SetCheckedBoxChecked(_18actdt, chk_18actdt);
                    //SetCheckedBoxChecked(_18noof, chk_18noof);
                }
                else if (lblsch.Text == "19")
                {
                    _19rsit.Text = row[24].ToString();
                    _19sac.Text = row[25].ToString();
                    _19fbit.Text = row[26].ToString();
                    _19wt.Text = row[27].ToString();
                    _19accept1.Text = row["accept1"].ToString();
                    _19filed1.Text = row["filed1"].ToString();
                    _19commts.Text = row[18].ToString();
                    _19actby.Text = row[19].ToString();
                    _19actdt.Text = row[20].ToString();

                    SetCheckedBoxChecked(_19rsit, chk_19rsit);
                    SetCheckedBoxChecked(_19sac, chk_19sac);
                    SetCheckedBoxChecked(_19fbit, chk_19fbit);
                    SetCheckedBoxChecked(_19wt, chk_19wt);
                    SetCheckedBoxChecked(_19accept1, chk_19accept1);
                    SetCheckedBoxChecked(_19filed1, chk_19filed1);

                    //SetCheckedBoxChecked(_19commts, chk_19commts);
                    SetCheckedBoxChecked(_19actby, chk_19actby);
                    SetCheckedBoxChecked(_19actdt, chk_19actdt);

                    _19pcd.Text = row["PCdate"].ToString();

                }
                else if (lblsch.Text == "20")
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

                    //SetCheckedBoxChecked(_20commts, chk_20commts);
                    SetCheckedBoxChecked(_20actby, chk_20actby);
                    // SetCheckedBoxChecked(_20actdt, chk_20actdt);
                    SetCheckedBoxChecked(_20filed3, chk_20filed3);

                    _20pptp.Text = row["PCdate"].ToString();
                    _20cftp.Text = row["PCdate1"].ToString();
                    _20ghtp.Text = row["PCdate2"].ToString();


                }
                else if (lblsch.Text == "15")
                {

                    _15acit.Text = row["test1"].ToString();
                    _15atht.Text = row["test2"].ToString();
                    _15athtc.Text = row["test3"].ToString();
                    _15afit.Text = row["test4"].ToString();
                    _15afitc.Text = row["test5"].ToString();
                    _15abat.Text = row["test6"].ToString();
                    _15acet.Text = row["test7"].ToString();
                    _15aaccept1.Text = row["accept1"].ToString();
                    _15aaccept2.Text = row["accept2"].ToString();
                    _15afiled1.Text = row["filed1"].ToString();
                    _15afiled2.Text = row["filed2"].ToString();

                    _15acommts.Text = row[18].ToString();
                    _15aactby.Text = row[19].ToString();
                    _15aactdt.Text = row[20].ToString();

                    _15acitp.Text = row["PCdate"].ToString();
                    _15athtcp.Text = row["PCdate1"].ToString();
                    _15afitcp.Text = row["PCdate2"].ToString();
                    _15acetp.Text = row["PCdate3"].ToString();

                    SetCheckedBoxChecked(_15acit, chk_15acit);
                    SetCheckedBoxChecked(_15atht, chk_15atht);
                    SetCheckedBoxChecked(_15athtc, chk_15athtc);
                    SetCheckedBoxChecked(_15afit, chk_15afit);
                    SetCheckedBoxChecked(_15afitc, chk_15afitc);
                    SetCheckedBoxChecked(_15abat, chk_15abat);
                    SetCheckedBoxChecked(_15acet, chk_15acet);
                    SetCheckedBoxChecked(_15aaccept1, chk_15aaccept1);
                    SetCheckedBoxChecked(_15aaccept2, chk_15aaccept2);
                    SetCheckedBoxChecked(_15afiled1, chk_15afiled1);
                    SetCheckedBoxChecked(_15afiled2, chk_15afiled2);

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
        protected void _5btnupdate_Click(object sender, EventArgs e)
        {
            Update(_5pwron.Text, _5tor.Text, _5ir.Text, _5pr.Text, _5si.Text, _5cr.Text, _5fn.Text, "", "", "", "", "", "", _5tc.Text, _5tl.Text, _5cc.Text, _5lc.Text, _5total.Text, _5accept1.Text, _5accept2.Text, _5filed1.Text, _5filed2.Text, _5commts.Text, _5actby.Text, _5actdt.Text, _5ptp.Text, _5ctp.Text, _5ltp.Text, "", "");
            btnDummy_ModalPopupExtender4.Hide();
        }
        protected void _5btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender4.Hide();
        }

        protected void _8btnupdate_Click(object sender, EventArgs e)
        {
            Update(_8pwron.Text, _8pc1.Text, _8co1.Text, _8wd1.Text, _8pc2.Text, _8co2.Text, _8wd2.Text, "", "", "", "", "", "", "", "", "", "", "", _8accept1.Text, "", _8filed1.Text, "", _8commts.Text, _8actby.Text, _8actdt.Text,_8pcp.Text,_8cp.Text,"","","");
            btnDummy_ModalPopupExtender7.Hide();
        }

        protected void _8btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender7.Hide();
        }

        protected void _17btnupdate_Click(object sender, EventArgs e)
        {
            Update(_17pwron.Text, _17pc1.Text, _17co1.Text, _17wd1.Text, _17pc2.Text, _17co2.Text, _17wd2.Text, "", "", "", "", "", "", "", "", "", "", "", _17accept1.Text, "", _17filed1.Text, "", _17commts.Text, _17actby.Text, _17actdt.Text,_17pcp.Text,_17cp.Text,"","","");
            btnDummy_ModalPopupExtender10.Hide();
        }

        protected void _17btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender10.Hide();
        }

        protected void _10btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _10ccit.Text, _10ndt.Text, _10dtc.Text, _10fait.Text, _10ltc.Text, _10slt.Text, _10bat.Text, _10ghet.Text, _10cet.Text, "", "", "", "", "", "", "", _10interface.Text, _10accept1.Text, _10accept2.Text, _10filed1.Text, _10filed2.Text, _10commts.Text, _10actby.Text, _10actdt.Text, _10ccitp.Text, _10dtp.Text, _10itp.Text, _10sltp.Text, _10cetp.Text);
            btnDummy_ModalPopupExtender13.Hide();
        }

        protected void _10btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender13.Hide();
        }

        protected void _6btnupdate_Click(object sender, EventArgs e)
        {
            string _pcdate = "";
            string _pcdate1 = "";
            if ((string)Session["cat"] == "LP")
            {
                _pcdate = _6lpp.Text;
                _pcdate1 = _6brp.Text;
            }
            else
            {
                _pcdate = _6epp.Text;
                _pcdate1 = _6ebp.Text;
            }
            Update("", _6ep.Text, _6accept1.Text, _6filed1.Text, "", "", _6be.Text, "", "", _6br.Text, "", "", "", _6accept3.Text, "", _6filed3.Text, _6lp.Text, "", _6accept2.Text, _6accept4.Text, _6filed2.Text, _6filed4.Text, _6commts.Text, _6actby.Text, _6actdt.Text, _pcdate, _pcdate1,"","","");
            btnDummy_ModalPopupExtender3.Hide();
        }

        protected void _6btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender3.Hide();
        }

        protected void _21btnupdate_Click(object sender, EventArgs e)
        {
            Update(_21pwron.Text, _21pf.Text, _21fvr.Text, _21cc.Text, _21facc.Text, _21bfc.Text, _21fct.Text, "", "", "", "", "", "", "", "", "", "", "", _21accept1.Text, "", _21filed1.Text, "", _21commts.Text, _21actby.Text, _21actdt.Text,_21pcd.Text,"","","","");
            btnDummy_ModalPopupExtender8.Hide();
        }

        protected void _21btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender8.Hide();
        }
        protected void _4btnupdate_Click(object sender, EventArgs e)
        {
            if (_4pc.Text == "N/A" && _4as.Text == "N/A" && _4lb.Text == "N/A") _4pcd.Text = "";
            if (_4cable.Text == "N/A") _4cablep.Text = "";
            if (_4sol.Text == "N/A") _4solp.Text = "";

            Update("", _4pc.Text, _4as.Text, _4lb.Text, _4accept1.Text, _4filed1.Text, _4cable.Text, _4sol.Text, "", "", "", "", "", "", "", "", "", "", _4accept2.Text, _4accept3.Text, _4filed2.Text, _4filed3.Text, _4commts.Text, _4actby.Text, _4actdt.Text, _4pcd.Text, _4cablep.Text, _4solp.Text, "", "");
            btnDummy_ModalPopupExtender5.Hide();

        }

        protected void _4btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender5.Hide();
        }
        protected void _7btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _7cir.Text, _7add.Text, _7ft.Text, _7co.Text, _7ll.Text, _7du.Text, _7pch.Text, "", "", "", "", "", "", "", "", "", _7noof.Text, _7accept1.Text, "", _7filed1.Text, "", _7commts.Text, _7actby.Text, _7actdt.Text, _7pc.Text, "", "","","");
            btnDummy_ModalPopupExtender6.Hide();
        }

        protected void _7btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender6.Hide();
        }
        protected void _18btnupdate_Click(object sender, EventArgs e)
        {
            if ((string)Session["cat"] == "FHR")
                Update(_18icom.Text, _18qt.Text, "N/A", "N/A", "N/A", "N/A", "N/A", _18wt.Text, "N/A", "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text, _18pcd.Text, "", "", "", "");
            else if ((string)Session["cat"] == "ZCV")
                Update(_18icom.Text, "N/A", _18qt.Text, "N/A", "N/A", "N/A", "N/A", _18wt.Text, "N/A", "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text, _18pcd.Text, "", "", "", "");
            else if ((string)Session["cat"] == "MOV")
                Update(_18icom.Text, "N/A", "N/A", _18qt.Text, "N/A", "N/A", "N/A", _18wt.Text, "N/A", "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text, _18pcd.Text, "", "", "", "");
            else if ((string)Session["cat"] == "PRS")
                Update(_18icom.Text, "N/A", "N/A", "N/A", _18qt.Text, "N/A", "N/A", _18wt.Text, "N/A", "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text, _18pcd.Text, "", "", "", "");
            else if ((string)Session["cat"] == "LGV")
                Update(_18icom.Text, "N/A", "N/A", "N/A", "N/A", _18qt.Text, "N/A", _18wt.Text, "N/A", "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text, _18pcd.Text, "", "", "", "");
            else if ((string)Session["cat"] == "CSC")
                Update(_18icom.Text, "N/A", "N/A", "N/A", "N/A", "N/A", _18qt.Text, _18wt.Text, "N/A", "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text, _18pcd.Text, "", "", "", "");
            else if (((string)Session["cat"] == "FHY") || (string)Session["cat"] == "FHS")
                Update(_18icom.Text, "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", _18wt.Text, _18qt.Text, "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text, _18pcd.Text, "", "", "", "");
            btnDummy_ModalPopupExtender11.Hide();
        }

        protected void _18btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender11.Hide();
        }
        protected void _19btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _19rsit.Text, _19sac.Text, _19fbit.Text, _19wt.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", _19accept1.Text, "", _19filed1.Text, "", _19commts.Text, _19actby.Text, _19actdt.Text, _19pcd.Text, "", "","","");
            btnDummy_ModalPopupExtender12.Hide();
        }

        protected void _19btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender12.Hide();
        }
        protected void _20btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _20cit.Text, _20ppt.Text, _20cft.Text, _20sot.Text, _20ght.Text, _20lt.Text, _20accept1.Text, _20filed1.Text, "", "", "", "", "", "", "", "", "", _20accept2.Text, _20accept3.Text, _20filed2.Text, _20filed3.Text, _20commts.Text, _20actby.Text, _20actdt.Text, _20pptp.Text, _20cftp.Text, _20ghtp.Text,"","");
            btnDummy_ModalPopupExtender14.Hide();
        }
        protected void _20btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender14.Hide();
        }
        protected void _15abtnupdate_Click(object sender, EventArgs e)
        {
            Update("", _15acit.Text, _15atht.Text, _15athtc.Text, _15afit.Text, _15afitc.Text, _15abat.Text, _15acet.Text, "", "", "", "", "", "", "", "", "", "", _15aaccept1.Text, _15aaccept2.Text, _15afiled1.Text, _15afiled2.Text, _15acommts.Text, _15aactby.Text, _15aactdt.Text, _15acitp.Text, _15athtcp.Text, _15afitcp.Text, _15acetp.Text,"");
            btnDummy_ModalPopupExtender15a.Hide();
        }

        protected void _15abtncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender15a.Hide();

        }
    }
}
