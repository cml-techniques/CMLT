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
    public partial class CAS_Commissioning1 : System.Web.UI.Page
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

                if (lblprj.Text == "AFV") Set_Title();


                // _exp = false;
            }
        }
        protected void settings()
        {
            if (lblsch.Text == "2" )
            {
                //lbnum.Text = "";
                //lbnum.Enabled = false;
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "SUBSTATION";
                lbl3.Text = "FED FROM";

                lblhead.Text = "CAS E1 Electrical Services. HV-MV Switchgear & RMU Commissioning Activity Schedule";

                td_3.Visible = false; td_lbnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "3" )
            {
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "AREA";
                lbl3.Text = "FED FROM";
                lblhead.Text = "CAS E2 Electrical Services. HV & MV Transformers Commissioning Activity Schedule";
                td_3.Visible = false; td_lbnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
                  else if (lblsch.Text == "5" || lblsch.Text == "1")
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
            else if (lblsch.Text == "18" || lblsch.Text == "29")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "";
                lbnum.Text = "QUANTITY";
                drfed.Style.Add("display", "none");
                if (lblsch.Text == "18")
                    lblhead.Text = "CAS PH2 Fire Protection Services  Commissioning Activity Schedule";
                else
                    lblhead.Text = "CAS M8 Fire Protection Services  Commissioning Activity Schedule";
                td_0.Visible = false; td_lbl1.Visible = false; td_lbl3.Visible = false; td_1.Visible = false; td0.Visible = false; td_lbl0.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;

            }
            else if (lblsch.Text == "19" || lblsch.Text == "28")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                lbnum.Text = "";

                if (lblsch.Text == "19")
                {
                    lblhead.Text = "CAS PH3 Fire Extinguishing Systems Commissioning Activity Schedule";
                    td_0.Visible = false; td_lbl1.Visible = false; td_lbl2.Visible = false; td_2.Visible = false; td_3.Visible = false; td_lbnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
                }
                else if (lblsch.Text == "28")
                {

                    lblhead.Text = "CAS MISC1 - Horizontal & Vertical Transportation Systems Commissioning Activity Schedule";
                    td_0.Visible = false; td_lbl1.Visible = false; td_lbl2.Visible = false;
                    td_2.Visible = false; td_3.Visible = false; td_lbnum.Visible = false;
                    td_lbldes.Visible = false; td_txtdescr.Visible = false;
                }
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
            else if (lblsch.Text == "21")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "";
                lbnum.Text = "FLUSHING STAGE";
                lblhead.Text = "CAS M2 Flushing Commissioning Activity Schedule";
                td_0.Visible = false; td_lbl1.Visible = false; td_lbl3.Visible = false; td_1.Visible = false; td_2.Visible = false; td_lbl2.Visible = false;
            }
            else if (lblsch.Text == "9" )
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "";
                drfed.Style.Add("display", "none");
             lblhead.Text = "CAS M3 Fusible Link Fire Dampers & MSFD Commissioning Activity Schedule";
                td_0.Visible = false; td_lbnum.Visible = false; td_lbl1.Visible = false; td_3.Visible = false; td_lbl3.Visible = false; td_1.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
            }
            else if (lblsch.Text == "15")
            {

                lbnum.Text = "NO.OF PANELS";

                lblhead.Text = "CAS ELV7 Guest Room Management System Commissioning Activity Schedule";
                td_lbl1.Visible = false;
                td_0.Visible = false;
                td_lbl3.Visible = false;
                td_1.Visible = false;
                td_lbl0.Visible = false;
                td0.Visible = false;
                td_lbl2.Visible = false;
                td_2.Visible = false;
                drloc.Style.Add("display", "none");

                td_lbldes.Visible = false; td_txtdescr.Visible = false;


            }
            else if (lblsch.Text == "13")
            {
                lbloc.Text = "SYSTEMS MONITORED";
                lbnum.Text = "NO.OF CAMERAS";

                lblhead.Text = "CAS ELV3 Closed Circuit Television Commissioning Activity Schedule";
                td_lbldes.Visible = false; td_txtdescr.Visible = false;

                td_lbl1.Visible = false;
                td_0.Visible = false;
                td_lbl2.Visible = false;
                td_2.Visible = false;
                drfed.Style.Add("display", "none");
                td_lbl3.Visible = false;
                td_1.Visible = false;
            }
            else if (lblsch.Text == "11")
            {
                lbloc.Text = "AREA SERVED";
                lbl2.Text = "NO.OF CIRCUITS";
                lbnum.Text = "NO.OF LIGHTING SCENES";
                drfed.Style.Add("display", "none");
                lblhead.Text = "CAS ELV5 Lighting Control System Commissioning Activity Schedule";

                td_lbldes.Visible = false; td_txtdescr.Visible = false; td_0.Visible = false; td_lbl1.Visible = false;
                td_lbl3.Visible = false;
                td_1.Visible = false;
            }
            else if (lblsch.Text == "12")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "CONNECTED FROM";
                lbnum.Text = "NO.OF POINTS";
                lblhead.Text = "CAS ELV6 Structured Cabling Network Commissioning Activity Schedule";
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
                td_lbl2.Visible = false; td_2.Visible = false;
                td_lbl1.Visible = false; td_0.Visible = false;
            }
            else if (lblsch.Text == "26")
            {
                lblhead.Text = "CAS ELV7 - Leak Detection System Commissioning Activity Schedule";
                lbnum.Text = "NO OF POINTS/ DETECTION";
                lbl3.Text = "CONNECTED FROM";
                td_txtdescr.Visible = false; td_lbldes.Visible = false;
                td_lbl2.Visible = false; td_2.Visible = false;
                td_0.Visible = false; td_lbl1.Visible = false;
            }
            else if (lblsch.Text == "22")
            {
                lbl2.Text = "FED FROM";
                lbloc.Text = "SYSTEMS MONITORED";
                lbnum.Text = "NO.OF ACCESS CONTROLLED DOORS";
                //drfed.Style.Add("display", "none");
                lblhead.Text = "CAS ELV4 Access Control System Commissioning Activity Schedule";
                td_lbldes.Visible = false; td_txtdescr.Visible = false;

                td_lbl1.Visible = false;
                td_0.Visible = false;
                //td_lbl2.Visible = false;
                //td_2.Visible = false;

                td_lbl3.Visible = false;
                td_1.Visible = false;

            }
            else if (lblsch.Text == "27")
            {
                lblhead.Text = "CAS ELV8 PAVA System Commissioning Activity Schedule";
                td_lbl1.Visible = false; td_0.Visible = false;
                td_0.Visible = false;
                td_txtdescr.Visible = false; td_lbldes.Visible = false;
                lbloc.Text = "AREA COVERED";
                lbl3.Text = "FED FROM";
                td_lbnum.Visible = false; td_3.Visible = false;

                td_lbl1.Visible = false; td_3.Visible = false;
                td_lbl2.Visible = false; td_2.Visible = false;

            }
            else if (lblsch.Text == "25")
            {

                lblhead.Text = "CAS E7 Integrated System Testing Commissioning Activity Schedule";
                td_0.Visible = false; td_lbnum.Visible = false; td_txtdescr.Visible = false; td_lbldes.Visible = false; td_lbl3.Visible = false; td_1.Visible = false;
                td_lbnum.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false; td_lbl1.Visible = false;
            }
            else if (lblsch.Text == "16")
            {
                lbl1.Text = "SYS.CONTROLLED/ MONITORED";
                lbl2.Text = "NO.OF POINTS";
                lbl3.Text = "FED FROM";
                lbnum.Text = "NO.OF DEVICES REQ'D CALIBRATION";
                lblhead.Text = "CAS ELV9 ELV Services | Car Park Management Commissioning Activity Schedule";
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "24")
            {

                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";

                lblhead.Text = "CAS MISC2 - Kitchen & Laundry Equipments Commissioning Activity Schedule";
                td_lbnum.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
                td_0.Visible = false; td_lbl1.Visible = false;
            }
            else if (lblsch.Text == "14" )
            {
                lbnum.Text = "NO.OF PANELS";
                drfed.Style.Add("display", "none");
                drloc.Style.Add("display", "none");
                    lblhead.Text = "CAS ELV8 Audio-Visual Intercom Commissioning Activity Schedule";
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
                td_lbl3.Visible = false;
                td_1.Visible = false;
                td_lbl1.Visible = false;
                td_0.Visible = false;
                td_lbl2.Visible = false;
                td_2.Visible = false;
                td_lbl0.Visible = false;
                td0.Visible = false;

            }
            if (lblprj.Text == "AFV")
            {
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcls = new _clscassheet();
                _objcls.sch = Convert.ToInt32((string)Session["sch"]);
                lblhead.Text = _objbll.LoadCASHeader(_objcls, _objdb);
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
            if (lblprj.Text=="AFV")
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

            lblhead.Text = _buildingName + " - " + lblhead.Text;

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
            //typehdn.Value = Session["cat"].ToString();
            typehdn.Value = _srow.Cells[16].Text;
            //arrange_testing();
            // ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('I'm Here!');", true);

            // Config_TestLabel();
            Load_cassheet_details(Convert.ToInt32(_item1.Text));
            if (lblsch.Text == "2") { btnDummy_ModalPopupExtender2_hvmv.Show(); _2lbl.Text = _title; }
            else if (lblsch.Text == "3") { btnDummy_ModalPopupExtender3_trans.Show(); _3lbl.Text = _title; }
            else if (lblsch.Text == "5") { btnDummy_ModalPopupExtender4.Show(); _5lbl.Text = _title; }
            else if (lblsch.Text == "4") { btnDummy_ModalPopupExtender5.Show(); _4lbl.Text = _title; }
            else if (lblsch.Text == "8") { btnDummy_ModalPopupExtender7.Show(); _8lbl.Text = _title; }
            else if (lblsch.Text == "17") { btnDummy_ModalPopupExtender10.Show(); _17lbl.Text = _title; }
            else if (lblsch.Text == "10") { btnDummy_ModalPopupExtender13.Show(); _10lbl.Text = _title; }
            else if (lblsch.Text == "7") { btnDummy_ModalPopupExtender6.Show(); _7lbl.Text = _title; }
            else if (lblsch.Text == "18") { btnDummy_ModalPopupExtender11.Show(); _18lbl.Text = _title; }
            else if (lblsch.Text == "19") { btnDummy_ModalPopupExtender12.Show(); _19lbl.Text = _title; }
            else if (lblsch.Text == "20") { btnDummy_ModalPopupExtender14.Show(); _20lbl.Text = _title; }
            else if (lblsch.Text == "15") { btnDummy_ModalPopupExtender19.Show(); _15lbl.Text = _title; }
            else if (lblsch.Text == "21") { btnDummy_ModalPopupExtender8.Show(); _21lbl.Text = _title; }
            else if (lblsch.Text == "6")
           {
               _6lbl.Text = _title;
               if ((string)Session["cat"] == "LP")
               {
                   chk_6ep.Checked = true; chk_6accept1.Checked = true; chk_6filed1.Checked = true; chk_6be.Checked = true; chk_6accept2.Checked = true; chk_6filed2.Checked = true;
                   _6lp.Enabled = true; _6accept3.Enabled = true; _6filed3.Enabled = true; _6br.Enabled = true; _6accept4.Enabled = true; _6filed4.Enabled = true;
                   _6ep.Text = "N/A"; _6accept1.Text = "N/A"; _6filed1.Text = "N/A"; _6be.Text = "N/A"; _6accept2.Text = "N/A"; _6filed2.Text = "N/A";
                   _6ep.Enabled = false; _6accept1.Enabled = false; _6filed1.Enabled = false; _6be.Enabled = false; _6accept2.Enabled = false; _6filed2.Enabled = false;
                   _6ebp.Enabled = false; _6epp.Enabled = false; 

                   _6ebp.Text = "N/A"; chk_6ebp.Checked = true; _6be.Text = "N/A"; chk_6be.Checked = true; chk_6epp.Checked = true; _6epp.Text = "N/A";


               }
               else
               {
                   chk_6lp.Checked = true; chk_6accept3.Checked = true; chk_6filed3.Checked = true; chk_6br.Checked = true; chk_6accept4.Checked = true; chk_6filed4.Checked = true;
                   _6ep.Enabled = true; _6accept1.Enabled = true; _6filed1.Enabled = true; _6be.Enabled = true; _6accept2.Enabled = true; _6filed2.Enabled = true;
                   _6lp.Text = "N/A"; _6accept3.Text = "N/A"; _6filed3.Text = "N/A"; _6br.Text = "N/A"; _6accept4.Text = "N/A"; _6filed4.Text = "N/A";
                   _6lp.Enabled = false; _6accept3.Enabled = false; _6filed3.Enabled = false; _6br.Enabled = false; _6accept4.Enabled = false; _6filed4.Enabled = false;
                    _6lpp.Enabled = false; _6brp.Enabled = false;

                 chk_6be.Checked = false;_6lpp.Text = "N/A"; chk_6lpp.Checked = true;_6lp.Text = "N/A"; chk_6lpp.Checked = true;

                   chk_6brp.Checked = true; _6brp.Text = "N/A";

               }

                btnDummy_ModalPopupExtender3.Show();
            }
            else if (lblsch.Text == "13") { btnDummy_ModalPopupExtender15.Show(); _13lbl.Text = _title; }
            else if (lblsch.Text == "11") { btnDummy_ModalPopupExtender17.Show(); _11lbl.Text = _title; }
            else if (lblsch.Text == "12") { btnDummy_ModalPopupExtender18.Show(); _12lbl.Text = _title; }
            else if (lblsch.Text == "26")
            {
                btnDummy_ModalPopupExtender26a.Show();
                _26lbl.Text = _title;
            }
            else if (lblsch.Text == "22") { btnDummy_ModalPopupExtender16.Show(); _22lbl.Text = _title; }
            else if (lblsch.Text == "27") { btnDummy_ModalPopupExtender27.Show(); _27lbl.Text = _title; }
            else if (lblsch.Text == "25")
            {
                btnDummy_ModalPopupExtender25a.Show();
                _25albl.Text = _title;
            }
            else if (lblsch.Text == "14") 
            {
                btnDummy_ModalPopupExtender20.Show(); _14lbl.Text = _title; 
            }
            else if (lblsch.Text == "16")
            {
                btnDummy_ModalPopupExtender16a.Show();
                _16lbl.Text = _title;
            }
            else if (lblsch.Text == "24") { btnDummy_ModalPopupExtender23.Show(); _24lbl.Text = _title; }
            else if (lblsch.Text == "28") { btnDummy_ModalPopupExtender26.Show(); _28lbl.Text = _title; }
            else if (lblsch.Text == "9")
            {
                if (typehdn.Value == "fusible")
                {

                    chk_9moo.Checked = true; chk_9sro.Checked = true; chk_9est.Checked = true; chk_9psrt.Checked = true;
                    _9moo.Text = "N/A"; _9sro.Text = "N/A"; _9est.Text = "N/A"; _9psrt.Text = "N/A";
                    _9moo.Enabled = false; _9sro.Enabled = false; _9est.Enabled = false; _9psrt.Enabled = false;

                    chk_9icom.Checked = true; _9icom.Text = "N/A"; _9icom.Enabled = false;
                }

                else
                {

                chk_9aa.Checked = true; chk_9dtp.Checked = true; chk_9rp.Checked = true;
                _9aa.Text = "N/A"; _9dtp.Text = "N/A"; _9rp.Text = "N/A";
                _9aa.Enabled = false; _9dtp.Enabled = false; _9rp.Enabled = false;

                 chk_9icom.Checked = false; _9icom.Enabled = true; _9icom.Text = "";

                }

            btnDummy_ModalPopupExtender9.Show();
                _9lbl.Text = _title;               
            }
        }
        protected void mydetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[16].Visible = false;
            //e.Row.Cells[0].Enabled = false;
            //if (e.Row.Cells[1].Text != "") return;
            //if (e.Row.Cells[0].Text != "")
            //    e.Row.Cells[0].Text = "hai" + e.Row.Cells[0].Text;
            e.Row.Cells[1].Text = (e.Row.DataItemIndex + 1).ToString();
            e.Row.Cells[6].Text = SeqNo(e.Row.Cells[6].Text);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[7].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[8].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[9].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[10].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");

            }
             if (lblsch.Text == "2" || lblsch.Text == "3" )
            {
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[12].Visible = false;
            }
             else if (lblsch.Text == "1" || lblsch.Text == "5")
            {
                e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if ((string)lblsch.Text == "6" || (lblprj.Text == "11784" && lblsch.Text == "29"))
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
            else if (lblsch.Text == "4" || lblsch.Text == "37")
            {
                e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "7")
            {                
                e.Row.Cells[10].Visible = false; e.Row.Cells[9].Visible = false;
                e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if (lblsch.Text == "18" || lblsch.Text == "29")
            {
                e.Row.Cells[8].Visible = false; e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if (lblsch.Text == "19" )
            {
                    e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
                }
            else if (lblsch.Text == "20" || lblsch.Text == "32")
            {
                e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "21")
            {
                e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if (lblsch.Text == "15")
            {
                if (lblprj.Text == "OPH") { e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false; }
                else
                    e.Row.Cells[7].Visible = false; e.Row.Cells[8].Visible = false; e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if (lblsch.Text == "13")
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[9].Visible = false;
            }
            else if (lblsch.Text == "11")
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false;e.Row.Cells[9].Visible = false;                   
            }
            else if (lblsch.Text == "12")
            {
                e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;e.Row.Cells[10].Visible = false;
            }
            else if (lblsch.Text == "26")
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "22")
            {
                e.Row.Cells[10].Visible = false;
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[11].Visible = false;
            }
            else if (lblsch.Text == "27")
            {
                e.Row.Cells[7].Visible = false; e.Row.Cells[12].Visible = false;
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if (lblsch.Text == "25")
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[11].Visible = false;
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[9].Visible = false;
            }
            else if (lblsch.Text == "16")
            {
                e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "24")
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if (lblsch.Text == "28")
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
            }
             else if (lblsch.Text == "9")
             {
                 e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false;
             }
             else if (lblsch.Text == "14" )
             {
                     e.Row.Cells[8].Visible = false; e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
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
            _objcls.per_com9 = per_com9();
            _objcls.per_com10 = per_com10();
            _objcls.planned1 = (planned1 != "N/A" ? planned1 : "");
            _objcls.planned2 = (planned2 != "N/A" ? planned2 : "");
            _objcls.planned3 = (planned3 != "N/A" ? planned3 : "");
            _objcls.planned4 = (planned4 != "N/A" ? planned4 : "");
            _objcls.planned5 = (planned5 != "N/A" ? planned5 : "");
            _objbll.Cassheet_update1(_objcls, _objdb);
        }
        private void Update(string pwron, string test1, string test2, string test3, string test4, string test5, string test6, string test7, string test8, string test9, string test10, string test11, string test12, string tested1, string tested2, string compld1, string compld2, string dvce, string accept1, string accept2, string filed1, string filed2, string comts, string actby, string actdt, string planned1, string planned2, string planned3, string planned4, string planned5, string planned6, string planned7, string planned8)   
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
            _objcls.per_com9 = per_com9();
            _objcls.per_com10 = 0;
            _objcls.planned1 = (planned1 != "N/A" ? planned1 : "");
            _objcls.planned2 = (planned2 != "N/A" ? planned2 : "");
            _objcls.planned3 = (planned3 != "N/A" ? planned3 : "");
            _objcls.planned4 = (planned4 != "N/A" ? planned4 : "");
            _objcls.planned5 = (planned5 != "N/A" ? planned5 : "");
            _objcls.planned6 = (planned6 != "N/A" ? planned6 : "");
            _objcls.planned7 = (planned7 != "N/A" ? planned7 : "");
            _objcls.planned8 = (planned8 != "N/A" ? planned8 : ""); 
            _objbll.Cassheet_update1(_objcls, _objdb);
        }
        protected decimal per_com1()
        {

            decimal _percentage = 0;
            int count = 0;
            if (lblsch.Text == "2")
            {
                    int _no = 0;
                    if (DateValidation(_2tor.Text) == true)
                        count += 1;
                    if (DateValidation(_2ir.Text) == true)
                        count += 1;
                    if (DateValidation(_2hi.Text) == true)
                        count += 1;
                    if (DateValidation(_2vt.Text) == true)
                        count += 1;
                    if (DateValidation(_2ct.Text) == true)
                        count += 1;
                    if (DateValidation(_2pi.Text) == true)
                        count += 1;
                    if (DateValidation(_2si.Text) == true)
                        count += 1;
                    if (DateValidation(_2cr.Text) == true)
                        count += 1;
                    if (DateValidation(_2fn.Text) == true)
                        count += 1;
                    if (DateValidation(_2pr.Text) == true)
                        count += 1;

                    if (_2tor.Text != "N/A")
                        _no += 1;
                    if (_2ir.Text != "N/A")
                        _no += 1;
                    if (_2hi.Text != "N/A")
                        _no += 1;
                    if (_2vt.Text != "N/A")
                        _no += 1;
                    if (_2ct.Text != "N/A")
                        _no += 1;
                    if (_2pi.Text != "N/A")
                        _no += 1;
                    if (_2si.Text != "N/A")
                        _no += 1;
                    if (_2cr.Text != "N/A")
                        _no += 1;
                    if (_2fn.Text != "N/A")
                        _no += 1;
                    if (_2pr.Text != "N/A")
                        _no += 1;
                    if (_no == 0)
                        _percentage = -1;
                    else
                        _percentage = (Convert.ToDecimal(count) / _no) * 100;
                }
            else if (lblsch.Text == "3" )
            {
                int _no = 0;
                if (DateValidation(_3ir.Text) == true)
                    count += 1;
                if (DateValidation(_3rt.Text) == true)
                    count += 1;
                if (DateValidation(_3wr.Text) == true)
                    count += 1;
                if (DateValidation(_3vg.Text) == true)
                    count += 1;
                if (DateValidation(_3trf.Text) == true)
                    count += 1;

                if (_3ir.Text != "N/A")
                    _no += 1;
                if (_3rt.Text != "N/A")
                    _no += 1;
                if (_3wr.Text != "N/A")
                    _no += 1;
                if (_3vg.Text != "N/A")
                    _no += 1;
                if (_3trf.Text != "N/A")
                    _no += 1;

                if (_no == 0)
                    _percentage = -1;
                else
                    _percentage = (Convert.ToDecimal(count) / _no) * 100;
            }
            else if (lblsch.Text == "5")
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
                else if (_8pc1.Text == "N/A")
                    _percentage = -1;
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
                if (DateValidation(_21pf.Text) == true)
                    count += 1;
                if (DateValidation(_21fvr.Text) == true)
                    count += 1;
                if (DateValidation(_21cc.Text) == true)
                    count += 1;
                if (DateValidation(_21facc.Text) == true)
                    count += 1;
                if (DateValidation(_21bfc.Text) == true)
                    count += 1;
                if (DateValidation(_21fct.Text) == true)
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

                if (_no > 0) _percentage = (Convert.ToDecimal(count) / _no) * 100;
                else _percentage = -1;
            }
            else if (lblsch.Text == "7")
            {
                if (IsNumeric(_7cir.Text) == true)
                    _percentage = Convert.ToDecimal(_7cir.Text);
                else if (_7cir.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "18" || lblsch.Text == "29")
            {
                if (IsNumeric(_18qt.Text))
                    _percentage = Convert.ToDecimal(_18qt.Text);
                else if (_18qt.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "19")
            {
                int _no = 0;
                if (DateValidation(_19rsit.Text) == true)
                    count += 1;
                if (DateValidation(_19sac.Text) == true)
                    count += 1;
                if (DateValidation(_19fbit.Text) == true)
                    count += 1;

                if (_19rsit.Text != "N/A")
                    _no += 1;
                if (_19sac.Text != "N/A")
                    _no += 1;
                if (_19fbit.Text != "N/A")
                    _no += 1;

                if (_no > 0) _percentage = (Convert.ToDecimal(count) / _no) * 100;
                else _percentage = -1;
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
                if (IsNumeric(_15cit.Text))
                    _percentage = Convert.ToDecimal(_15cit.Text);
                else if (_15cit.Text == "N/A")
                    _percentage = -1;

            }
            else if (lblsch.Text == "13")
            {
                if (IsNumeric(_13cit.Text))
                    _percentage = Convert.ToDecimal(_13cit.Text);
                else if (_13cit.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "11")
            {
                if (IsNumeric(_11cit.Text))
                    _percentage = Convert.ToDecimal(_11cit.Text);
                else if (_11cit.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "12")
            {
                if (IsNumeric(_12ct.Text))
                    _percentage = Convert.ToDecimal(_12ct.Text);
                else if (_12ct.Text == "N/A")
                    _percentage = -1;

            }
            else if (lblsch.Text == "26")
            {
                if (IsNumeric(_26ct.Text))
                    _percentage = Convert.ToDecimal(_26ct.Text);
                else if (_26ct.Text == "N/A")
                    _percentage = -1;

            }
            else if (lblsch.Text == "22")
            {
                if (IsNumeric(_22cit.Text))
                    _percentage = Convert.ToDecimal(_22cit.Text);
                else if (_22cit.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "27")
            {
                if (IsNumeric(_27cit.Text))
                    _percentage = Convert.ToDecimal(_27cit.Text);
                else if (_27cit.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "25")
            {
                if (DateValidation(_25apfec.Text) == true)
                    _percentage = 1;
                else if (_25apfec.Text == "N/A")
                    _percentage = -1;

            }
            else if (lblsch.Text == "16")
            {
                if (IsNumeric(_16ir.Text))
                    _percentage = Convert.ToDecimal(_16ir.Text);
                else if (_16ir.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "24")
            {
                int _no = 0;

                if (DateValidation(_24ir.Text) == true)
                    count += 1;
                if (DateValidation(_24ft.Text) == true)
                    count += 1;
                if (DateValidation(_24it.Text) == true)
                    count += 1;

                if (_24ir.Text != "N/A")  _no += 1;
                if (_24ft.Text != "N/A") _no += 1;
                if (_24it.Text != "N/A") _no += 1;

                if (_no > 0) _percentage = (Convert.ToDecimal(count) / _no) * 100;
                else
                    _percentage = -1;

            }
            else if (lblsch.Text == "9")
            {
                //please refer FD cassheet for PCD project (N/A items are considered in calculation)
                if (typehdn.Value == "fusible")
                {
                    if (chk_9aa.Checked)
                    {
                        if (chk_9dtp.Checked)
                        {
                            if (chk_9rp.Checked)
                                _percentage = -1;
                            else if (DateValidation(_9rp.Text))
                                _percentage = 1;
                        }
                        else if (DateValidation(_9dtp.Text))
                        {
                            if (chk_9rp.Checked || DateValidation(_9rp.Text))
                                _percentage = 1;
                            else
                                _percentage = 0;
                        }
                    }
                    else if (DateValidation(_9aa.Text))
                    {
                        if (chk_9dtp.Checked || DateValidation(_9dtp.Text))
                        {
                            if (chk_9rp.Checked || DateValidation(_9rp.Text))
                                _percentage = 1;
                            else
                                _percentage = 0;
                        }
                        else
                            _percentage = 0;
                    }
                    else
                        _percentage = 0;
                }
                else if (typehdn.Value == "motorised")
                {
                    if (chk_9moo.Checked)
                    {
                        if (chk_9sro.Checked)
                        {
                            if (chk_9est.Checked)
                            {
                                if (chk_9psrt.Checked)
                                    _percentage = -1;
                                else if (DateValidation(_9psrt.Text))
                                    _percentage = 1;
                            }
                            else if (DateValidation(_9est.Text))
                            {
                                if (chk_9psrt.Checked || DateValidation(_9psrt.Text))
                                    _percentage = 1;
                                else
                                    _percentage = 0;
                            }
                        }
                        else if (DateValidation(_9sro.Text))
                        {
                            if (chk_9est.Checked || DateValidation(_9est.Text))
                            {
                                if (chk_9psrt.Checked || DateValidation(_9psrt.Text))
                                    _percentage = 1;
                                else
                                    _percentage = 0;
                            }
                            else
                                _percentage = 0;
                        }
                        else
                            _percentage = 0;
                    }
                    else if (DateValidation(_9moo.Text))
                    {
                        if (chk_9sro.Checked || DateValidation(_9sro.Text))
                        {
                            if (chk_9est.Checked || DateValidation(_9est.Text))
                            {
                                if (chk_9psrt.Checked || DateValidation(_9psrt.Text))
                                    _percentage = 1;
                                else
                                    _percentage = 0;
                            }
                            else
                                _percentage = 0;
                        }
                        else
                            _percentage = 0;
                    }
                    else
                        _percentage = 0;

                }
            }
            else if (lblsch.Text == "28")
            {
                decimal _no = 0;
                if (_28tcom.Text != "N/A")
                    _no += 1;
                if (_28tpi.Text != "N/A")
                    _no += 1;
                if (_28el.Text != "N/A")
                    _no += 1;
                if (_28pfm.Text != "N/A")
                    _no += 1;
                if (_28ms.Text != "N/A")
                    _no += 1;
                if (_28icom.Text != "N/A")
                    _no += 1;
                if (_28fai.Text != "N/A")
                    _no += 1;

                if (DateValidation(_28tcom.Text) == true)
                    count += 1;
                if (DateValidation(_28tpi.Text) == true)
                    count += 1;
                if (DateValidation(_28el.Text) == true)
                    count += 1;
                if (DateValidation(_28pfm.Text) == true)
                    count += 1;
                if (DateValidation(_28ms.Text) == true)
                    count += 1;
                if (DateValidation(_28icom.Text) == true)
                    count += 1;
                if (DateValidation(_28fai.Text) == true)
                    count += 1;

                if (_no > 0) _percentage = (Convert.ToDecimal(count) / _no) * 100;
                else _percentage = -1;
            }
            else if (lblsch.Text == "14")
            {
                if (IsNumeric(_14cit.Text))
                    _percentage = Convert.ToDecimal(_14cit.Text);
                else if (_14cit.Text == "N/A")
                    _percentage = -1;
            }
            return _percentage;
        }
        protected decimal per_com2()
        {

            decimal _percentage = 0;
            if (lblsch.Text == "2")
            {
                decimal _cable = 0;
                decimal _noc = 0;

                if (_2cable.Text != "N/A" && _2noc.Text != "N/A")
                {
                    if (IsNumeric(_2cable.Text))
                        _cable += Convert.ToDecimal(_2cable.Text);

                    if (IsNumeric(_2noc.Text))
                        _noc += Convert.ToDecimal(_2noc.Text);
                }
                if (_2ttt.Text != "N/A" && _2noc.Text != "N/A")
                {
                    if (IsNumeric(_2ttt.Text))
                        _cable += Convert.ToDecimal(_2ttt.Text);
                    if (IsNumeric(_2noc.Text))
                        _noc += Convert.ToDecimal(_2noc.Text);
                }

                if (_noc > 0)
                    _percentage = (_cable / _noc) * 100;
                if (_2cable.Text == "N/A" && _2ttt.Text == "N/A") _percentage = -1;

                //if (DateValidation(_2cable.Text) == true)
                //    _percentage = 100;
                //else if (_2cable.Text == "N/A")
                //    _percentage = -1;
            }
            else if (lblsch.Text == "3")
            {
                if (DateValidation(_3cable.Text) == true)
                    _percentage = 100;
                else if (_3cable.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "5")
            {
                if (IsNumeric(_5tc.Text) == true)
                {
                    _percentage = Convert.ToDecimal(_5tc.Text);
                }
                else if (_5tc.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "8")
            {
                if (DateValidation(_8co1.Text) == true)
                    _percentage = 1;
                else if (_8co1.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "17")
            {
                if (DateValidation(_17co1.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "10")
            {
                if (IsNumeric(_10ndt.Text) == true)
                    _percentage = Convert.ToDecimal(_10ndt.Text);
                else if (_10ndt.Text == "N/A")
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
                if (IsNumeric(_15kca.Text))
                    _percentage = Convert.ToDecimal(_15kca.Text);
                else if (_15kca.Text == "N/A")
                    _percentage = -1;

            }
            else if (lblsch.Text == "13")
            {
                if (IsNumeric(_13cvl.Text) == true)
                    _percentage = Convert.ToDecimal(_13cvl.Text);
                else if (_13cvl.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "11")
            {
                if (IsNumeric(_11lct.Text) == true)
                    _percentage = Convert.ToDecimal(_11lct.Text);
                else if (_11lct.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "26")
            {
                if (IsNumeric(_26pct.Text) == true)
                    _percentage = Convert.ToDecimal(_26pct.Text);
                else if (_26pct.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "22")
            {
                if (IsNumeric(_22apt.Text) == true)
                    _percentage = Convert.ToDecimal(_22apt.Text);
                else if (_22apt.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "27")
            {
                if (IsNumeric(_27dl.Text) == true)
                    _percentage = Convert.ToDecimal(_27dl.Text);
                else if (_27dl.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "25")
            {
                if (DateValidation(_25amp.Text) == true)
                    _percentage = 1;
                else if (_25amp.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "16")
            {
                if (IsNumeric(_16ppt.Text) == true)
                    _percentage = Convert.ToDecimal(_16ppt.Text);
                else if (_16ppt.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "24")
            {
                if (per_com1() == 100)
                    _percentage = 1;
            }
            else if (lblsch.Text == "9")
            {
                if (DateValidation(_9accept1.Text) == true)
                    _percentage = 1;
                else if (_9accept1.Text == "N/A")
                    _percentage = -1;
            }

            else if (lblsch.Text == "28")
            {
                if (per_com1() == 100)
                    _percentage = 1;
            }
            else if (lblsch.Text == "18")
            {
                if (per_com1() == -1 ||(per_com1() != -1 && _18pcd.Text == "N/A"))
                    _percentage = -1;
                else if (DateValidation(_18pcd.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "19")
            {
                if (per_com1() == -1 || (per_com1() != -1 && _19pcd.Text == "N/A"))
                    _percentage = -1;
                else if (DateValidation(_19pcd.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "14")
            {
                if (IsNumeric(_14diab.Text) == true)
                    _percentage = Convert.ToDecimal(_14diab.Text);
                else if (_14diab.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "21")
            {
                if (per_com1() == -1 || (per_com1() != -1 && _21pcd.Text == "N/A"))
                    _percentage = -1;
            }
            return _percentage;
        }
        protected decimal per_com3()
        {

            decimal _percentage = 0;

            if (lblsch.Text == "2")
            {
                if ((per_com1() == -1) || (txtpanelplanned.Text == "N/A")) { _percentage = -1; }

            }

            if (lblsch.Text == "3") 
            {
                if ((per_com1() == -1) || (per_com1() != -1 && _3transformerplanned.Text == "N/A"))
                {
                    _percentage = -1;
                }
              
            }
            if (lblsch.Text == "5")
            {
                if (IsNumeric(_5tl.Text) == true)
                {
                    _percentage = Convert.ToDecimal(_5tl.Text);
                }
                else if (_5tl.Text == "N/A")
                    _percentage = -1;
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
                if (IsNumeric(_15dnd.Text) == true)
                    _percentage = Convert.ToDecimal(_15dnd.Text);
                else if (_15dnd.Text == "N/A")
                    _percentage = -1;

            }
            else if (lblsch.Text == "13")
            {
                if (IsNumeric(_13cvh.Text) == true)
                    _percentage = Convert.ToDecimal(_13cvh.Text);
                else if (_13cvh.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "11")
            {
                if (IsNumeric(_11apt.Text) == true)
                    _percentage = Convert.ToDecimal(_11apt.Text);
                else if (_11apt.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "26")
            {
                if (IsNumeric(_26comm.Text) == true)
                    _percentage = Convert.ToDecimal(_26comm.Text);
                else if (_26comm.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "22")
            {
                if (IsNumeric(_22fat.Text) == true)
                    _percentage = Convert.ToDecimal(_22fat.Text);
                else if (_22fat.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "27")
            {
                if (IsNumeric(_27pm.Text) == true)
                    _percentage = Convert.ToDecimal(_27pm.Text);
                else if (_27pm.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "25")
            {
                if (DateValidation(_25aebt.Text) == true)
                    _percentage = 1;
                else if (_25aebt.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "16")
            {
                if (IsNumeric(_16cft.Text) == true)
                    _percentage = Convert.ToDecimal(_16cft.Text);
                else if (_16cft.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "14")
            {
                if (IsNumeric(_14avt.Text) == true)
                    _percentage = Convert.ToDecimal(_14avt.Text);
                else if (_14avt.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "9")
            {
                if (DateValidation(_9pcd.Text) == true)
                    _percentage = 1;
                else if (per_com1() == -1 || (per_com1() != -1 && _9pcd.Text == "N/A"))
                    _percentage = -1;
            }
            else if (lblsch.Text == "24")
            {
             if ((per_com1() == -1 || _24pcd.Text == "N/A"))
                    _percentage = -1;
            }
            else if (lblsch.Text == "28")
            {
                if ((per_com1() == -1 || _28pcd.Text == "N/A"))
                    _percentage = -1;
            }
            return _percentage;
        }
        protected decimal per_com4()
        {

            decimal _percentage = 0;

            if (lblsch.Text == "2")
            {
                if ((per_com2() == -1) || (txtcableplanned.Text == "N/A")) { _percentage = -1; }

            }

            if (lblsch.Text == "4")
            {
                if ((per_com1() == -1) || (per_com1() != -1 && _4pcd.Text == "N/A"))
                {
                    _percentage = -1;
                }
            }
            if (lblsch.Text == "3")
            {
                if ((per_com2() == -1) || (per_com2() != -1 && _3cableplanned.Text == "N/A"))
                {
                    _percentage = -1;
                }

            }
            if (lblsch.Text == "5")
            {
                if ((per_com1() == -1) || (_5ptp.Text == "N/A")) { _percentage = -1; }
                //if (_5accept1.Text.ToUpper() != "N/A" && _5accept2.Text.ToUpper() == "N/A")
                //{
                //    if (DateValidation(_5accept1.Text) == true)
                //        _percentage = 1;
                //}
                //else if (_5accept1.Text.ToUpper() == "N/A" && _5accept2.Text.ToUpper() != "N/A")
                //{
                //    if (DateValidation(_5accept2.Text) == true)
                //        _percentage = 1;
                //}
                //else
                //{
                //    if (DateValidation(_5accept1.Text) == true && DateValidation(_5accept2.Text) == true)
                //        _percentage = 1;
                //}
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
                if (IsNumeric(_15mur.Text) == true)
                    _percentage = Convert.ToDecimal(_15mur.Text);
                else if (_15mur.Text == "N/A")
                    _percentage = -1;

            }
            else if (lblsch.Text == "13")
            {
                if (IsNumeric(_13ast.Text) == true)
                    _percentage = Convert.ToDecimal(_13ast.Text);
                else if (_13ast.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "11")
            {
                if (IsNumeric(_11phgt.Text) == true)
                    _percentage = Convert.ToDecimal(_11phgt.Text);
                else if (_11phgt.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "22")
            {
                if (IsNumeric(_22acs.Text) == true)
                    _percentage = Convert.ToDecimal(_22acs.Text);
                else if (_22acs.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "27")
            {
                if (IsNumeric(_27ast.Text) == true)
                    _percentage = Convert.ToDecimal(_27ast.Text);
                else if (_27ast.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "16")
            {
                if (IsNumeric(_16sop.Text) == true)
                    _percentage = Convert.ToDecimal(_16sop.Text);
                else if (_16sop.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "14")
            {
                if (IsNumeric(_14drt.Text) == true)
                    _percentage = Convert.ToDecimal(_14drt.Text);
                else if (_14drt.Text == "N/A")
                    _percentage = -1;
            }
            return _percentage;
        }
        protected decimal per_com5()
        {

            decimal _percentage = 0;
            if (lblsch.Text == "15")
            {
                if (IsNumeric(_15ftc.Text) == true)
                    _percentage = Convert.ToDecimal(_15ftc.Text);
                else if (_15ftc.Text == "N/A")
                    _percentage = -1;

            }
            else if (lblsch.Text == "4")
            {
                if ((per_com2() == -1) || (per_com2() != -1 && _4cablep.Text == "N/A"))
                {
                    _percentage = -1;
                }
            }
            else if (lblsch.Text == "5")
            {
                if ((per_com2() == -1) || (_5ctp.Text == "N/A")) { _percentage = -1; }

            }
            else if (lblsch.Text == "10")
            {
                if (DateValidation(_10bat.Text) == true)
                    _percentage = 1;
                else if (_10bat.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "6")
            {
                if ((per_com1() == -1) || (_6epp.Text == "N/A")) { _percentage = -1; }

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
            else if (lblsch.Text == "16")
                {
                    if ((per_com1() == -1 && per_com2() == -1 && per_com3() == -1 && per_com4() == -1) || _16pcd.Text == "N/A") _percentage = -1;
                }

            else if (lblsch.Text == "13")
            {
                if (IsNumeric(_13rbst.Text) == true)
                    _percentage = Convert.ToDecimal(_13rbst.Text);
                else if (_13rbst.Text == "N/A")
                    _percentage = -1;
                    
            }
            else if (lblsch.Text == "22")
            {
                if (IsNumeric(_22pft.Text) == true)
                    _percentage = Convert.ToDecimal(_22pft.Text);
                else if (_22pft.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "27")
            {
                decimal _total = 0;
                int _no = 0;
                if (_27cit.Text != "N/A")
                {
                    _no += 1; _total += per_com1();
                }
                if (_27dl.Text != "N/A")
                {
                    _no += 1; _total += per_com2();
                }
                if (_27pm.Text != "N/A")
                {
                    _no += 1; _total += per_com3();
                }
                if (_27ast.Text != "N/A")
                {
                    _no += 1; _total += per_com4();
                }

                if (_no > 0) _percentage = (_total / _no) * 100;

            }

            else if (lblsch.Text == "14")
            {           
                decimal _total = 0;
               
                decimal _qty = Convert.ToDecimal(_14noof.Text);

                if (_qty > 0)
                {
                    if (per_com1() == -1 && per_com2() == -1 && per_com3() == -1)
                    {
                        _total = per_com4();
                        _percentage = (_total / _qty) * 100;
                    }
                    else if (per_com1() == -1 && per_com2() == -1 && per_com4() == -1)
                    {
                        _total = per_com3();
                        _percentage = (_total / _qty) * 100;
                    }
                    else if (per_com1() == -1 && per_com3() == -1 && per_com4() == -1)
                    {
                        _total = per_com2();
                        _percentage = (_total / _qty) * 100;
                    }
                    else if (per_com2() == -1 && per_com3() == -1 && per_com4() == -1)
                    {
                        _total = per_com1();
                        _percentage = (_total / _qty) * 100;
                    }
                    else if (per_com1() == -1 && per_com2() == -1)
                    {
                        _total = per_com3() + per_com4();
                        _percentage = (_total / (_qty * 2)) * 100;
                    }
                    else if (per_com3() == -1 && per_com4() == -1)
                    {
                        _total = per_com1() + per_com2();
                        _percentage = (_total / (_qty * 2)) * 100;
                    }
                    else if (per_com1() == -1 && per_com3() == -1)
                    {
                        _total = per_com2() + per_com4();
                        _percentage = (_total / (_qty * 2)) * 100;
                    }
                    else if (per_com1() == -1 && per_com4() == -1)
                    {
                        _total = per_com2() + per_com3();
                        _percentage = (_total / (_qty * 2)) * 100;
                    }
                    else if (per_com3() == -1 && per_com2() == -1)
                    {
                        _total = per_com1() + per_com4();
                        _percentage = (_total / (_qty * 2)) * 100;
                    }
                    else if (per_com2() == -1 && per_com4() == -1)
                    {
                        _total = per_com1() + per_com3();
                        _percentage = (_total / (_qty * 2)) * 100;
                    }
                    else if (per_com1() == -1)
                    {
                        _total = per_com2() + per_com3() + per_com4();
                        _percentage = (_total / (_qty * 3)) * 100;
                    }
                    else if (per_com2() == -1)
                    {
                        _total = per_com1() + per_com3() + per_com4();
                        _percentage = (_total / (_qty * 3)) * 100;
                    }
                    else if (per_com3() == -1)
                    {
                        _total = per_com1() + per_com2() + per_com4();
                        _percentage = (_total / (_qty * 3)) * 100;
                    }
                    else if (per_com4() == -1)
                    {
                        _total = per_com1() + per_com3() + per_com2();
                        _percentage = (_total / (_qty * 3)) * 100;
                    }
                    else if (per_com1() != -1 && per_com3() != -1 && per_com4() != -1 && per_com2() != -1)
                    {
                        _total = per_com1() + per_com3() + per_com2() + per_com4();
                        _percentage = (_total / (_qty * 4)) * 100;
                    }
                    else if (per_com1() == -1 && per_com3() == -1 && per_com4() == -1 && per_com2() == -1)
                    {
                        _percentage = -1;
                    }
                }
                else
                    _percentage = 0;
            }
            return _percentage;
        }
        protected decimal per_com6()
        {
            decimal _percentage = 0;

              if (lblsch.Text == "4")
            {
                if ((per_com3() == -1) || (per_com3() != -1 && _4solp.Text == "N/A"))
                {
                    _percentage = -1;
                }
            }
            else if (lblsch.Text == "5")
            {
                if ((per_com3() == -1) || (_5ltp.Text == "N/A")) { _percentage = -1; }

            }
            if (lblsch.Text == "6")
            {
                if ((per_com2() == -1) || (_6ebp.Text == "N/A")) { _percentage = -1; }
            }

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
                if (IsNumeric(_15ems.Text) == true)
                    _percentage = Convert.ToDecimal(_15ems.Text);
                else if (_15ems.Text == "N/A")
                    _percentage = -1;

            }
            else if (lblsch.Text == "13")
            {
                decimal _total=0;
                int _num=0;
                if (per_com1() >= 0)
                {
                    _total += per_com1();
                    _num += 1;
                }
                if (per_com2() >= 0)
                {
                    _total += per_com2();
                    _num += 1;
                }
                if (per_com3() >= 0)
                {
                    _total += per_com3();
                    _num += 1;
                }
                if (per_com4() >= 0)
                {
                    _total += per_com4();
                    _num += 1;
                }
                if(per_com5()>=0)
                {
                    _total += per_com5();
                    _num += 1;
                }
                decimal _qty = Convert.ToDecimal(_13noof.Text);
                if (_num > 0)
                    _percentage = (_total / (_qty * _num)) * 100;
                else
                    _percentage = -1;
            }
            else if (lblsch.Text == "22")
            {
                if (IsNumeric(_22it.Text) == true)
                    _percentage = Convert.ToDecimal(_22it.Text);
                else if (_22it.Text == "N/A")
                    _percentage = -1;
            }
            return _percentage;
        }
        protected decimal per_com7()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "13")
            {
                if (((per_com1() == -1) && (per_com2() == -1) && (per_com3() == -1) && (per_com4() == -1) && (per_com5() == -1))) { _percentage = -1; }
            }
            if (lblsch.Text == "6")
            {
                if ((per_com3() == -1) || (_6lpp.Text == "N/A")) { _percentage = -1; }

            }
            if (lblsch.Text == "10")
            {
                if (DateValidation(_10cet.Text) == true)
                    _percentage = 1;
                else if (_10cet.Text == "N/A")
                    _percentage = -1;
            }
            if (lblsch.Text == "7")
            {
                if (IsNumeric(_7pch.Text) == true)
                    _percentage = Convert.ToDecimal(_7pch.Text);
                else if (_7pch.Text == "N/A")
                    _percentage = -1;
            }
           else if (lblsch.Text == "15")
            {
                if (IsNumeric(_15lsc.Text) == true)
                    _percentage = Convert.ToDecimal(_15lsc.Text);
                else if (_15lsc.Text == "N/A")
                    _percentage = -1;

            }
            else if (lblsch.Text == "22")
            {
                if (IsNumeric(_22phgt.Text) == true)
                    _percentage = Convert.ToDecimal(_22phgt.Text);
                else if (_22phgt.Text == "N/A")
                    _percentage = -1;
            }
            return _percentage;
        }
        protected decimal per_com8()
        {
            decimal _percentage = 0;
            int _no = 0;
            if (lblsch.Text == "6")
            {
                if ((per_com4() == -1) || (_6brp.Text == "N/A")) { _percentage = -1; }

            }
            if (lblsch.Text == "7")
            {

                if (((per_com1() == -1) && (per_com2() == -1) && (per_com3() == -1) && (per_com4() == -1) && (per_com5() == -1) && (per_com6() == -1) && (per_com7() == -1)) || (_7pc.Text == "N/A")) { _percentage = -1; }

            }
            else if (lblsch.Text == "15")
            {
                if (IsNumeric(_15bci.Text) == true)
                    _percentage = Convert.ToDecimal(_15bci.Text);
                else if (_15bci.Text == "N/A")
                    _percentage = -1;
            }
            if (lblsch.Text == "22")
            {
                decimal _total = 0;
                if (_22cit.Text != "N/A")
                {
                    _no += 1; _total += per_com1();
                }
                if (_22apt.Text != "N/A")
                {
                    _no += 1; _total += per_com2();
                }
                if (_22fat.Text != "N/A")
                {
                    _no += 1; _total += per_com3();
                }
                if (_22acs.Text != "N/A")
                {
                    _no += 1; _total += per_com4();
                }
                if (_22pft.Text != "N/A")
                {
                    _no += 1; _total += per_com5();
                }
                if (_22it.Text != "N/A")
                {
                    _no += 1; _total += per_com6();
                }
                if (_22phgt.Text != "N/A")
                {
                    _no += 1; _total += per_com7();
                }
                decimal _qty = Convert.ToDecimal(_22noof.Text);
                if (_qty > 0) _percentage = (_total / (_qty * _no)) * 100;

            }
            else if (lblsch.Text == "10")
            {
                if ((_10ccit.Text == "N/A") || (chk_10ccitp.Checked == true))
                    _percentage = -1;
                else if (DateValidation(_10ccitp.Text) == true)
                    _percentage = 1;                
            }
            return _percentage;
        }
        protected decimal per_com9()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "10")
            { 
               if((_10ndt.Text == "N/A")|| (chk_10dtp.Checked == true))
                _percentage = -1;             

            }
            else if (lblsch.Text == "15")
            {
                if (IsNumeric(_15mif.Text) == true)
                    _percentage = Convert.ToDecimal(_15mif.Text);
                else if (_15mif.Text == "N/A")
                    _percentage = -1;
            }
            return _percentage;
        }
        protected decimal per_com10()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "15")
            {
                decimal _total = per_com1() + per_com2() + per_com3() + per_com4() + per_com5() + per_com6() + per_com7() + per_com8() + per_com9();
                decimal _qty = Convert.ToDecimal(_15noof.Text);
                _percentage = (_total / (_qty * 9)) * 100;
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
                if (lblsch.Text == "2")
                {


                    _2pwron.Text = row[14].ToString();
                    _2tor.Text = row["test1"].ToString();
                    _2ir.Text = row["test2"].ToString();
                    _2hi.Text = row["test3"].ToString();
                    _2vt.Text = row["test4"].ToString();
                    _2ct.Text = row["test5"].ToString();
                    _2pi.Text = row["test6"].ToString();
                    _2si.Text = row["test7"].ToString();
                    _2cr.Text = row["test11"].ToString();
                    _2fn.Text = row["test10"].ToString();
                    _2pr.Text = row["test12"].ToString();
                    _2cable.Text = row["test13"].ToString();

                    _2noc.Text = row["devices1"].ToString();
                    _2ttt.Text = row["test8"].ToString();
                    _2cte.Text = row["test9"].ToString();

                    _2accept1.Text = row["accept1"].ToString();
                    _2accept2.Text = row["accept2"].ToString();
                    _2filed1.Text = row["filed1"].ToString();
                    _2filed2.Text = row["filed2"].ToString();
                    _2commts.Text = row[18].ToString();
                    _2actby.Text = row[19].ToString();
                    _2actdt.Text = row[20].ToString();

                    if (row["per_com3"].ToString() != "-1")
                    {
                        txtpanelplanned.Text = row["PCdate"].ToString();

                    }
                    else
                        txtpanelplanned.Text = "N/A";

                    if (row["per_com4"].ToString() != "-1")
                    {
                        txtcableplanned.Text = row["PCdate1"].ToString();

                    }
                    else
                        txtcableplanned.Text = "N/A";


                    SetCheckedBoxChecked(txtpanelplanned, chk_2pt);
                    SetCheckedBoxChecked(txtcableplanned, chk_2cp);




                    SetCheckedBoxChecked(_2pwron, chk_2pwron);
                    SetCheckedBoxChecked(_2tor, chk_2tor);
                    SetCheckedBoxChecked(_2ir, chk_2ir);
                    SetCheckedBoxChecked(_2hi, chk_2hi);
                    SetCheckedBoxChecked(_2vt, chk_2vt);
                    SetCheckedBoxChecked(_2ct, chk_2ct);
                    SetCheckedBoxChecked(_2pi, chk_2pi);
                    SetCheckedBoxChecked(_2si, chk_2si);
                    SetCheckedBoxChecked(_2cr, chk_2cr);
                    SetCheckedBoxChecked(_2fn, chk_2fn);
                    SetCheckedBoxChecked(_2pr, chk_2pr);
                    SetCheckedBoxChecked(_2cable, chk_2cable);
                    SetCheckedBoxChecked(_2accept1, chk_2accept1);
                    SetCheckedBoxChecked(_2accept2, chk_2accept2);
                    SetCheckedBoxChecked(_2filed1, chk_2filed1);
                    SetCheckedBoxChecked(_2filed2, chk_2filed2);

                    SetCheckedBoxChecked(_2noc, chk_2noc);
                    SetCheckedBoxChecked(_2ttt, chk_2ttt);
                    SetCheckedBoxChecked(_2cte, chk_2cte);

                    hvmv_plannedNA();

                }
                else if (lblsch.Text == "3")
                {
                    decimal ind0 = 0;
                    decimal ind1 = 0;
                    _3pwron.Text = row[14].ToString();
                    _3ir.Text = row["test1"].ToString();
                    _3rt.Text = row["test2"].ToString();
                    _3wr.Text = row["test3"].ToString();
                    _3vg.Text = row["test4"].ToString();
                    _3trf.Text = row["test5"].ToString();
                    _3cable.Text = row["test6"].ToString();
                    _3accept1.Text = row["accept1"].ToString();
                    _3filed1.Text = row["filed1"].ToString();
                    _3accept2.Text = row["accept2"].ToString();
                    _3filed2.Text = row["filed2"].ToString();
                    _3commts.Text = row[18].ToString();
                    _3actby.Text = row[19].ToString();
                    _3actdt.Text = row[20].ToString();

                    _3transformerplanned.Text = row["PCdate"].ToString();
                    _3cableplanned.Text = row["PCdate1"].ToString();
                    ind0 = Convert.ToDecimal(row["per_com3"]);
                    ind1 = Convert.ToDecimal(row["per_com4"]);
                    SetCheckedBoxChecked(_3pwron, chk_3pwron);
                    SetCheckedBoxChecked(_3ir, chk_3ir);
                    SetCheckedBoxChecked(_3rt, chk_3rt);
                    SetCheckedBoxChecked(_3wr, chk_3wr);
                    SetCheckedBoxChecked(_3vg, chk_3vg);
                    SetCheckedBoxChecked(_3trf, chk_3trf);

                    SetCheckedBoxChecked(_3accept1, chk_3accept1);
                    SetCheckedBoxChecked(_3filed1, chk_3filed1);

                    SetCheckedBoxChecked(_3cable, chk_3cable);
                    SetCheckedBoxChecked(_3accept2, chk_3accept2);
                    SetCheckedBoxChecked(_3filed2, chk_3filed2);
                    SetCheckedBoxChecked(_3actby, chk_3actby);
                    SetCheckedBoxChecked(_3actdt, chk_3actdt);


                    Transformer_plannedNA(ind0,ind1);
                }
                else if ( lblsch.Text == "5")
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


                    if (row["per_com4"].ToString() != "-1")
                    {
                        _5ptp.Text = row["PCdate"].ToString();

                    }
                    else
                        _5ptp.Text = "N/A";

                    if (row["per_com5"].ToString() != "-1")
                    {
                        _5ctp.Text = row["PCdate1"].ToString();

                    }
                    else
                        _5ctp.Text = "N/A";

                    if (row["per_com6"].ToString() != "-1")
                    {
                        _5ltp.Text = row["PCdate2"].ToString();

                    }
                    else
                        _5ltp.Text = "N/A";

                    SetCheckedBoxChecked(_5ptp, chk_5ptp);
                    SetCheckedBoxChecked(_5ctp, chk_5ctp);
                    SetCheckedBoxChecked(_5ltp, chk_5ltp);

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

                    Lv_PlannedNA();

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


                    SetTextBoxNA(_8pcp, chk_8pc1);
                    SetTextBoxNA(_8cp, chk_8co1);


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
                    SetTextBoxNA(_17pcp, chk_17pc1);
                    SetTextBoxNA(_17cp, chk_17co1);

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

                    _10sltp.Text = row["PCdate3"].ToString();
                    _10cetp.Text = row["PCdate4"].ToString();

                    _10batp.Text = row["PCdate5"].ToString();
                    _10ghetp.Text = row["PCdate6"].ToString();



                    //SetCheckedBoxChecked(_10commts, chk_10commts);
                    SetCheckedBoxChecked(_10actby, chk_10actby);
                    SetCheckedBoxChecked(_10actdt, chk_10actdt);
                    // SetCheckedBoxChecked(_10devices, chk_10devices);
                    //SetCheckedBoxChecked(_10interface, chk_10interface);


                    SetCheckedBoxChecked(_10ccit, chk_10ccit);

                    SetTextBoxNA(_10ccitp, chk_10ccit);
                    SetTextBoxNA(_10ccitp, chk_10ccitp);


                    SetCheckedBoxChecked(_10ndt, chk_10ndt);
                    SetTextBoxNA(_10dtp, chk_10ndt);
                    SetTextBoxNA(_10dtc,chk_10ndt);

                    SetCheckedBoxChecked(_10dtc, chk_10dtc);

                    SetCheckedBoxChecked(_10fait, chk_10fait);
                    SetTextBoxNA(_10itp, chk_10fait);
                    SetTextBoxNA(_10itp, chk_10itp);

                    SetCheckedBoxChecked(_10ltc, chk_10ltc);

                    SetCheckedBoxChecked(_10slt, chk_10slt);
                    SetTextBoxNA(_10sltp, chk_10slt);

                    SetCheckedBoxChecked(_10bat, chk_10bat);
                    SetTextBoxNA(_10batp, chk_10bat);

                    SetCheckedBoxChecked(_10ghet, chk_10ghet);
                    SetTextBoxNA(_10ghetp, chk_10ghet); 

                    SetCheckedBoxChecked(_10cet, chk_10cet);
                    SetTextBoxNA(_10cetp, chk_10cet);   

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

                    // _6lpp.Text = row["PCdate2"].ToString();
                    // _6brp.Text = row["PCdate3"].ToString();

                    //_6epp.Text = row["PCdate"].ToString();
                    // _6ebp.Text = row["PCdate1"].ToString();



                    if (row["per_com5"].ToString() != "-1")
                    {
                        _6epp.Text = row["PCdate"].ToString();

                    }
                    else
                        _6epp.Text = "N/A";

                    if (row["per_com6"].ToString() != "-1")
                    {
                        _6ebp.Text = row["PCdate1"].ToString();

                    }
                    else
                        _6ebp.Text = "N/A";

                    if (row["per_com7"].ToString() != "-1")
                    {
                        _6lpp.Text = row["PCdate2"].ToString();

                    }
                    else
                        _6lpp.Text = "N/A";


                    if (row["per_com8"].ToString() != "-1")
                    {
                        _6brp.Text = row["PCdate3"].ToString();

                    }
                    else
                        _6brp.Text = "N/A";


                    SetCheckedBoxChecked(_6epp, chk_6epp);
                    SetCheckedBoxChecked(_6ebp, chk_6ebp);
                    SetCheckedBoxChecked(_6lpp, chk_6lpp);
                    SetCheckedBoxChecked(_6brp, chk_6brp);



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
                    decimal _21pcdind = 0;
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
                    _21pcdind = Convert.ToDecimal(row["per_com2"]);
                    _21pcd.Text = row["PCdate"].ToString();
                    SetCheckedBoxChecked(_21pwron, chk_21pwron);
                    SetCheckedBoxChecked(_21pf, chk_21pf);
                    SetCheckedBoxChecked(_21fvr, chk_21fvr);
                    SetCheckedBoxChecked(_21cc, chk_21cc);
                    SetCheckedBoxChecked(_21facc, chk_21facc);
                    SetCheckedBoxChecked(_21bfc, chk_21bfc);
                    SetCheckedBoxChecked(_21fct, chk_21fct);
                    SetCheckedBoxChecked(_21accept1, chk_21accept1);
                    SetCheckedBoxChecked(_21filed1, chk_21filed1);

                    //SetCheckedBoxChecked(_21commts, chk_21commts);
                    SetCheckedBoxChecked(_21actby, chk_21actby);
                    SetCheckedBoxChecked(_21actdt, chk_21actdt);
                    _21PlannedNA(_21pcdind);                     
                                             
                   }
                else if (lblsch.Text == "4")
                {
                    decimal ind0 = 0;
                    decimal ind1 = 0;
                    decimal ind2 = 0;
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
                    ind0 = Convert.ToDecimal(row["per_com4"]);
                    ind1 = Convert.ToDecimal(row["per_com5"]);
                    ind2 = Convert.ToDecimal(row["per_com6"]);
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

                    SetCheckedBoxChecked(_4cablep, chk_4actdt);
                    SetCheckedBoxChecked(_4solp, chk_4actdt);


                    GenPlannedNA(ind0, ind1, ind2);
                    _cleared(_4cablep, chk_4cable);
                    _cleared(_4solp, chk_4sol);

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

                
                    if (row["per_com8"].ToString() != "-1")
                    {
                        _7pc.Text = row["PCdate"].ToString();

                    }
                    else
                        _7pc.Text = "N/A";

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

                


                    ECBSPlannaedNA();

                    SetCheckedBoxChecked(_7pc, chk_7pc);



                }
                else if (lblsch.Text == "18")
                {
                    decimal ind = 0;
                    ind = Convert.ToDecimal(row["per_com2"]);
                    if ((string)Session["cat"] == "FHR") _18qt.Text = row[24].ToString();
                    else if ((string)Session["cat"] == "ZCV") _18qt.Text = row[25].ToString();
                    else if ((string)Session["cat"] == "MOV") _18qt.Text = row[26].ToString();
                    else if ((string)Session["cat"] == "PRS") _18qt.Text = row[27].ToString();
                    else if ((string)Session["cat"] == "LGV") _18qt.Text = row[28].ToString();
                    else if ((string)Session["cat"] == "CSC") _18qt.Text = row[29].ToString();
                    else if ((string)Session["cat"] == "FHS") _18qt.Text = row["test11"].ToString();
                    _18wt.Text = row[30].ToString();
                    _18accept1.Text = row["accept1"].ToString();
                    _18filed1.Text = row["filed1"].ToString();
                    _18commts.Text = row[18].ToString();
                    _18actby.Text = row[19].ToString();
                    _18actdt.Text = row[20].ToString();
                    _18noof.Text = row[21].ToString();

                    _18pcd.Text = (ind == -1)?"N/A" : row["PCdate"].ToString();


                    SetCheckedBoxChecked(_18qt, chk_18qt);
                    SetCheckedBoxChecked(_18wt, chk_18wt);
                    SetCheckedBoxChecked(_18accept1, chk_18accept1);
                    SetCheckedBoxChecked(_18filed1, chk_18filed1);
                    //SetCheckedBoxChecked(_18pcd, chk_18pcd);


                    //SetCheckedBoxChecked(_18commts, chk_18commts);
                    SetCheckedBoxChecked(_18actby, chk_18actby);
                    SetCheckedBoxChecked(_18actdt, chk_18actdt);
                    //SetCheckedBoxChecked(_18noof, chk_18noof);
                    //SetTextBoxNA(_18pcd, chk_18pcd);
                    Ph2PlannedNA(ind);
                }
                else if (lblsch.Text == "19")
                {
                    decimal ind = 0;
                    _19rsit.Text = row[24].ToString();
                    _19sac.Text = row[25].ToString();
                    _19fbit.Text = row[26].ToString();
                    _19wt.Text = row[27].ToString();
                    _19accept1.Text = row["accept1"].ToString();
                    _19filed1.Text = row["filed1"].ToString();
                    _19commts.Text = row[18].ToString();
                    _19actby.Text = row[19].ToString();
                    _19actdt.Text = row[20].ToString();
                    ind = Convert.ToDecimal(row["per_com2"]);
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

                    SetTextBoxNA(_19pcd, chk_19pcd);
                    PH3PlannedNA(ind);
                }
                else if (lblsch.Text == "20")
                {
                    _20cit.Text = row["test1"].ToString();
                    _20ppt.Text = row["test2"].ToString();
                    _20cft.Text = row["test3"].ToString();
                    _20sot.Text = row["test4"].ToString();
                    _20ght.Text = row["test5"].ToString();
                    _20lt.Text = row["test6"].ToString();
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

                    _20citp.Text = row["PCdate"].ToString();
                    _20pptp.Text = row["PCdate1"].ToString();
                    _20cftp.Text = row["PCdate2"].ToString();

                    _20sotp.Text = row["PCdate3"].ToString();
                    _20ghtp.Text = row["PCdate4"].ToString();
                    _20ltp.Text = row["PCdate5"].ToString();    



                    SetTextBoxNA(_20citp, chk_20cit);
                    SetTextBoxNA(_20pptp, chk_20ppt);
                    SetTextBoxNA(_20cftp, chk_20cft);

                    SetTextBoxNA(_20sotp, chk_20sot);
                    SetTextBoxNA(_20ghtp, chk_20ght);
                    SetTextBoxNA(_20ltp, chk_20lt);





                }
                else if (lblsch.Text == "15")
                {

                    _15cit.Text = row[24].ToString();
                    _15kca.Text = row[25].ToString();
                    _15dnd.Text = row[26].ToString();
                    _15mur.Text = row[27].ToString();
                    _15ftc.Text = row[28].ToString();
                    _15ems.Text = row[29].ToString();
                    _15lsc.Text = row[30].ToString();
                    _15bci.Text = row["test11"].ToString();
                    _15mif.Text = row["test10"].ToString();
                    _15accept1.Text = row["accept1"].ToString();
                    _15filed1.Text = row["filed1"].ToString();
                    _15commts.Text = row[18].ToString();
                    _15actby.Text = row[19].ToString();
                    _15actdt.Text = row[20].ToString();
                    _15noof.Text = row[21].ToString();


                    SetCheckedBoxChecked(_15cit, chk_15cit);
                    SetCheckedBoxChecked(_15kca, chk_15kca);
                    SetCheckedBoxChecked(_15dnd, chk_15dnd);
                    SetCheckedBoxChecked(_15mur, chk_15mur);
                    SetCheckedBoxChecked(_15ftc, chk_15ftc);
                    SetCheckedBoxChecked(_15ems, chk_15ems);
                    SetCheckedBoxChecked(_15lsc, chk_15lsc);
                    SetCheckedBoxChecked(_15bci, chk_15bci);
                    SetCheckedBoxChecked(_15mif, chk_15mif);

                    if (row["tested1"].ToString() != "-1")
                    {
                        _15pcd.Text = row["PCdate"].ToString();

                    }
                    else _15pcd.Text = "N/A";

                    SetCheckedBoxChecked(_15pcd, chk_15pcd);
                }
                else if (lblsch.Text == "13")
                {
                    decimal _13pcdind = 0;
                    _13cit.Text = row[24].ToString();
                    _13cvl.Text = row[25].ToString();
                    _13cvh.Text = row[26].ToString();
                    _13ast.Text = row[27].ToString();
                    _13rbst.Text = row[28].ToString();
                    _13accept1.Text = row["accept1"].ToString();
                    _13filed1.Text = row["filed1"].ToString();
                    _13pcd.Text = row["PCDate"].ToString();
                    _13pcdind = Convert.ToDecimal(row["per_com7"]);
                    _13commts.Text = row[18].ToString();
                    _13actby.Text = row[19].ToString();
                    _13actdt.Text = row[20].ToString();
                    _13noof.Text = row[21].ToString();

                    SetCheckedBoxChecked(_13cit, chk_13cit);
                    SetCheckedBoxChecked(_13cvl, chk_13cvl);
                    SetCheckedBoxChecked(_13cvh, chk_13cvh);
                    SetCheckedBoxChecked(_13ast, chk_13ast);
                    SetCheckedBoxChecked(_13rbst, chk_13rbst);
                    SetCheckedBoxChecked(_13accept1, chk_13accept1);
                    SetCheckedBoxChecked(_13filed1, chk_13filed1);

                    //SetCheckedBoxChecked(_13commts, chk_13commts);
                    SetCheckedBoxChecked(_13actby, chk_13actby);
                    SetCheckedBoxChecked(_13actdt, chk_13actdt);
                    //SetCheckedBoxChecked(_13noof, chk_13noof);
                    _13PlannedNA(_13pcdind);

                }
                else if (lblsch.Text == "11")
                {
                    _11cit.Text = row[24].ToString();
                    _11lct.Text = row[25].ToString();
                    _11apt.Text = row[26].ToString();
                    _11phgt.Text = row[27].ToString();
                    _11accept1.Text = row["accept1"].ToString();
                    _11filed1.Text = row["filed1"].ToString();
                    _11commts.Text = row[18].ToString();
                    _11actby.Text = row[19].ToString();
                    _11actdt.Text = row[20].ToString();
                    _11pcd.Text = row["PCDate"].ToString();

                    SetCheckedBoxChecked(_11cit, chk_11cit);
                    SetCheckedBoxChecked(_11lct, chk_11lct);
                    SetCheckedBoxChecked(_11apt, chk_11apt);
                    SetCheckedBoxChecked(_11phgt, chk_11phgt);
                    SetCheckedBoxChecked(_11accept1, chk_11accept1);
                    SetCheckedBoxChecked(_11filed1, chk_11filed1);

                    //SetCheckedBoxChecked(_11commts, chk_11commts);
                    SetCheckedBoxChecked(_11actby, chk_11actby);
                    SetCheckedBoxChecked(_11actdt, chk_11actdt);

                }
                else if (lblsch.Text == "12")
                {
                    _12ct.Text = row[24].ToString();
                    _12accept1.Text = row["accept1"].ToString();
                    _12filed1.Text = row["filed1"].ToString();
                    _12commts.Text = row[18].ToString();
                    _12actby.Text = row[19].ToString();
                    _12actdt.Text = row[20].ToString();
                    _12nop.Text = row[21].ToString();
                    _12pcd.Text = row["PCDate"].ToString();
                    SetCheckedBoxChecked(_12ct, chk_12ct);
                    SetCheckedBoxChecked(_12accept1, chk_12accept1);
                    SetCheckedBoxChecked(_12filed1, chk_12filed1);

                    //SetCheckedBoxChecked(_12commts, chk_12commts);
                    SetCheckedBoxChecked(_12actby, chk_12actby);
                    SetCheckedBoxChecked(_12actdt, chk_12actdt);
                    // SetCheckedBoxChecked(_12nop, chk_12nop);
                }
                else if (lblsch.Text == "26")
                {
                    _26ct.Text = row[24].ToString();
                    _26pct.Text = row[25].ToString();
                    _26comm.Text = row[26].ToString();
                    _26pcd.Text = row["PCDate"].ToString();
                    _26accept1.Text = row["accept1"].ToString();
                    _26filed1.Text = row["filed1"].ToString();
                    _26commts.Text = row[18].ToString();
                    _26actby.Text = row[19].ToString();
                    _26actdt.Text = row[20].ToString();
                    SetCheckedBoxChecked(_26ct, chk_26ct);
                    SetCheckedBoxChecked(_26pct, chk_26pct);
                    SetCheckedBoxChecked(_26comm, chk_26comm);
                }
                else if (lblsch.Text == "22")
                {
                    _22cit.Text = row[24].ToString();
                    _22apt.Text = row[25].ToString();
                    _22fat.Text = row[26].ToString();
                    _22acs.Text = row[27].ToString();
                    _22pft.Text = row[28].ToString();
                    _22it.Text = row[29].ToString();
                    _22phgt.Text = row[30].ToString();
                    _22accept1.Text = row["accept1"].ToString();
                    _22filed1.Text = row["filed1"].ToString();
                    _22commts.Text = row[18].ToString();
                    _22actby.Text = row[19].ToString();
                    _22actdt.Text = row[20].ToString();
                    _22noof.Text = row[21].ToString();

                    SetCheckedBoxChecked(_22cit, chk_22cit);
                    SetCheckedBoxChecked(_22apt, chk_22apt);
                    SetCheckedBoxChecked(_22acs, chk_22acs);
                    SetCheckedBoxChecked(_22pft, chk_22pft);
                    SetCheckedBoxChecked(_22it, chk_22it);
                    SetCheckedBoxChecked(_22phgt, chk_22phgt);


                    _22pcd.Text = row["PCdate"].ToString();

                    ACSPlannedNA();

                }
                else if (lblsch.Text == "27")
                {
                    _27cit.Text = row[24].ToString();
                    _27dl.Text = row[25].ToString();
                    _27pm.Text = row[26].ToString();
                    _27ast.Text = row[27].ToString();

                    _27accept1.Text = row["accept1"].ToString();
                    _27filed1.Text = row["filed1"].ToString();
                    _27commts.Text = row[18].ToString();

                    _27actby.Text = row[19].ToString();
                    _27actdt.Text = row[20].ToString();

                    SetCheckedBoxChecked(_27cit, chk_27cit);
                    SetCheckedBoxChecked(_27dl, chk_27dl);
                    SetCheckedBoxChecked(_27pm, chk_27pm);
                    SetCheckedBoxChecked(_27ast, chk_27ast);

                    _27pcd.Text = row["PCdate"].ToString();

                    PAVAPlannedNA();
                }
                else if (lblsch.Text == "25")
                {
                    _25apfec.Text = row[24].ToString();
                    _25amp.Text = row[25].ToString();
                    _25aebt.Text = row[26].ToString();
                    _25pcd.Text = row["PCdate"].ToString();
                    _25afiled1.Text = row["filed1"].ToString();
                    _25acommts.Text = row[18].ToString();
                    _25aactby.Text = row[19].ToString();
                    _25aactdt.Text = row[20].ToString();
                    SetCheckedBoxChecked(_25apfec, chk_25apfec);
                    SetCheckedBoxChecked(_25amp, chk_25amp);
                    SetCheckedBoxChecked(_25aebt, chk_25aebt);
                }
                else if (lblsch.Text == "16")
                {
                    decimal ind = 0;
                    _16ir.Text = row[24].ToString();
                    _16ppt.Text = row[25].ToString();
                    _16cft.Text = row[26].ToString();
                    _16sop.Text = row[27].ToString();
                    _16accept1.Text = row["accept1"].ToString();
                    _16filed1.Text = row["filed1"].ToString();
                    _16commts.Text = row[18].ToString();
                    _16actby.Text = row[19].ToString();
                    _16actdt.Text = row[20].ToString();
                    //ind = Convert.ToDecimal(row["per_com6"]);
                    SetCheckedBoxChecked(_16ir, chk_16ir);
                    SetCheckedBoxChecked(_16ppt, chk_16ppt);
                    SetCheckedBoxChecked(_16cft, chk_16cft);
                    SetCheckedBoxChecked(_16sop, chk_16sop);
                    SetCheckedBoxChecked(_16accept1, chk_16accept1);
                    SetCheckedBoxChecked(_16filed1, chk_16filed1);

                    //SetCheckedBoxChecked(_16commts, chk_16commts);
                    SetCheckedBoxChecked(_16actby, chk_16actby);
                    SetCheckedBoxChecked(_16actdt, chk_16actdt);

                    if (row["per_com5"].ToString() != "-1")
                    {
                        _16pcd.Text = row["PCdate"].ToString();

                    }
                    else _16pcd.Text = "N/A";

                    SetCheckedBoxChecked(_16pcd, chk_16pcd);


                    //ELVPlannedNA(ind);

                }
                else if (lblsch.Text == "24")
                {
                    _24pwron.Text = row[14].ToString();
                    _24ir.Text = row[24].ToString();
                    _24ft.Text = row[25].ToString();
                    _24it.Text = row[26].ToString();
                    _24accept1.Text = row["accept1"].ToString();
                    _24filed1.Text = row["filed1"].ToString();
                    _24commts.Text = row[18].ToString();
                    _24actby.Text = row[19].ToString();
                    _24actdt.Text = row[20].ToString();

                    SetCheckedBoxChecked(_24ir, chk_24ir);
                    SetCheckedBoxChecked(_24ft, chk_24ft);
                    SetCheckedBoxChecked(_24it, chk_24it);

                    _24pcd.Text = row["PCdate"].ToString();

                    KichenPlannedNA();


                }
                else if (lblsch.Text == "9")
                {
                    decimal ind = 0;
                    _9aa.Text = row[24].ToString();
                    _9dtp.Text = row[25].ToString();
                    _9rp.Text = row[26].ToString();
                    _9moo.Text = row[27].ToString();
                    _9sro.Text = row[28].ToString();
                    _9est.Text = row[29].ToString();
                    _9psrt.Text = row[30].ToString();
                    _9accept1.Text = row["accept1"].ToString();
                    _9filed1.Text = row["filed1"].ToString();


                    _9commts.Text = row[18].ToString();
                    _9actby.Text = row[19].ToString();
                    _9actdt.Text = row[20].ToString();
                    _9pcd.Text = (Convert.ToDecimal(row["per_com3"]) == -1) ? "N/A" : row["PCdate"].ToString();
                    ind = Convert.ToDecimal(row["per_com3"]);
                    SetCheckedBoxChecked(_9aa, chk_9aa);
                    SetCheckedBoxChecked(_9dtp, chk_9dtp);
                    SetCheckedBoxChecked(_9rp, chk_9rp);
                    SetCheckedBoxChecked(_9moo, chk_9moo);
                    SetCheckedBoxChecked(_9sro, chk_9sro);
                    SetCheckedBoxChecked(_9est, chk_9est);
                    SetCheckedBoxChecked(_9psrt, chk_9psrt);
                    SetCheckedBoxChecked(_9accept1, chk_9accept1);
                    SetCheckedBoxChecked(_9filed1, chk_9filed1);
                    //SetCheckedBoxChecked(_9pcd, chk_9pcd);

                    //SetCheckedBoxChecked(_9commts, chk_9commts);
                    SetCheckedBoxChecked(_9actby, chk_9actby);
                    SetCheckedBoxChecked(_9actdt, chk_9actdt);
                    //SetTextBoxNA(_9pcd, chk_9pcd);
                    FDPlannedNA(ind);                 
                }
                else if (lblsch.Text == "28")
                {
                    _28tcom.Text = row[24].ToString();
                    _28tpi.Text = row[25].ToString();
                    _28el.Text = row[26].ToString();
                    _28pfm.Text = row[27].ToString();
                    _28ms.Text = row[28].ToString();
                    _28icom.Text = row[29].ToString();
                    _28fai.Text = row[30].ToString();


                    _28accept1.Text = row["accept1"].ToString();
                    _28filed1.Text = row["filed1"].ToString();
                    _28commts.Text = row[18].ToString();
                    _28actby.Text = row[19].ToString();
                    _28actdt.Text = row[20].ToString();

                    SetCheckedBoxChecked(_28tcom, chk_28tcom);
                    SetCheckedBoxChecked(_28tpi, chk_28tpi);
                    SetCheckedBoxChecked(_28el, chk_28el);
                    SetCheckedBoxChecked(_28pfm, chk_28pfm);
                    SetCheckedBoxChecked(_28ms, chk_28ms);
                    SetCheckedBoxChecked(_28icom, chk_28icom);
                    SetCheckedBoxChecked(_28fai, chk_28fai);

                    _28pcd.Text = row["PCdate"].ToString();

                    MVTPlannedNA();

                }
                else if (lblsch.Text == "14")
                {
                    _14cit.Text = row[24].ToString();
                    _14diab.Text = row[25].ToString();
                    _14avt.Text = row[26].ToString();
                    _14drt.Text = row[27].ToString();
                    _14accept1.Text = row["accept1"].ToString();
                    _14filed1.Text = row["filed1"].ToString();
                    _14commts.Text = row[18].ToString();
                    _14actby.Text = row[19].ToString();
                    _14actdt.Text = row[20].ToString();
                    _14noof.Text = row[21].ToString();

                    _14pcd.Text = row["PCdate"].ToString();


                    SetCheckedBoxChecked(_14cit, chk_14cit);
                    SetCheckedBoxChecked(_14diab, chk_14diab);
                    SetCheckedBoxChecked(_14avt, chk_14avt);
                    SetCheckedBoxChecked(_14drt, chk_14drt);
                    SetCheckedBoxChecked(_14accept1, chk_14accept1);
                    SetCheckedBoxChecked(_14filed1, chk_14filed1);

                    SetCheckedBoxChecked(_14actby, chk_14actby);
                    SetCheckedBoxChecked(_14actdt, chk_14actdt);

                    AVIPlannedNA();

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
            Update(_5pwron.Text, _5tor.Text, _5ir.Text, _5pr.Text, _5si.Text, _5cr.Text, _5fn.Text, "", "", "", "", "", "", _5tc.Text, _5tl.Text, _5cc.Text, _5lc.Text, _5total.Text, _5accept1.Text, _5accept2.Text, _5filed1.Text, _5filed2.Text, _5commts.Text, _5actby.Text, _5actdt.Text,_5ptp.Text,_5ctp.Text,_5ltp.Text,"","");
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
            Update("", _10ccit.Text, _10ndt.Text, _10dtc.Text, _10fait.Text, _10ltc.Text, _10slt.Text, _10bat.Text, _10ghet.Text, _10cet.Text, "", "", "", "", "", "", "", _10interface.Text, _10accept1.Text, _10accept2.Text, _10filed1.Text, _10filed2.Text, _10commts.Text, _10actby.Text, _10actdt.Text, _10ccitp.Text, _10dtp.Text, _10itp.Text, _10sltp.Text, _10cetp.Text, _10batp.Text, _10ghetp.Text,"");
            btnDummy_ModalPopupExtender13.Hide();
        }

        protected void _10btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender13.Hide();
        }

        protected void _6btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _6ep.Text, _6accept1.Text, _6filed1.Text, "", "", _6be.Text, "", "", _6br.Text, "", "", "", _6accept3.Text, "", _6filed3.Text, _6lp.Text, "", _6accept2.Text, _6accept4.Text, _6filed2.Text, _6filed4.Text, _6commts.Text, _6actby.Text, _6actdt.Text,_6epp.Text, _6ebp.Text,_6lpp.Text, _6brp.Text,"");
            btnDummy_ModalPopupExtender3.Hide();
        }

        protected void _6btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender3.Hide();
        }
        protected void _4btnupdate_Click(object sender, EventArgs e)
        {
            if (_4pc.Text=="N/A" &&_4as.Text=="N/A" && _4lb.Text=="N/A" )_4pcd.Text="";
            if (_4cable.Text == "N/A") _4cablep.Text = "";
            if (_4sol.Text == "N/A") _4solp.Text = "";

            Update("", _4pc.Text, _4as.Text, _4lb.Text, _4accept1.Text, _4filed1.Text, _4cable.Text, _4sol.Text, "", "", "", "", "", "", "", "", "", "", _4accept2.Text, _4accept3.Text, _4filed2.Text, _4filed3.Text, _4commts.Text, _4actby.Text, _4actdt.Text,_4pcd.Text,_4cablep.Text,_4solp.Text,"","");
            btnDummy_ModalPopupExtender5.Hide();
        }

        protected void _4btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender5.Hide();
        }
        protected void _7btnupdate_Click(object sender, EventArgs e)
        {
            //if (_7cir.Text == "N/A" && _7add.Text == "N/A" && _7ft.Text == "N/A" && _7co.Text == "N/A" && _7ll.Text == "N/A" && _7du.Text == "N/A" && _7pch.Text == "N/A") _7pc.Text = "";
            Update("", _7cir.Text, _7add.Text, _7ft.Text, _7co.Text, _7ll.Text, _7du.Text, _7pch.Text, "", "", "", "", "", "", "", "", "", _7noof.Text, _7accept1.Text, "", _7filed1.Text, "", _7commts.Text, _7actby.Text, _7actdt.Text,_7pc.Text,"","","","");
            btnDummy_ModalPopupExtender6.Hide();
        }

        protected void _7btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender6.Hide();
        }
        protected void _18btnupdate_Click(object sender, EventArgs e)
        {
            if (lblsch.Text == "18" && _18qt.Text != "" && _18qt.Text != "N/A")
            {
                bool _res = ValidateDevice(_18noof.Text);
                if (_res == false)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Quantity tested must be less than or equal to Quantity');", true);
                    return;
                }
            }
            if ((string)Session["cat"] == "FHR")
                Update(_18icom.Text, _18qt.Text, "N/A", "N/A", "N/A", "N/A", "N/A", _18wt.Text, "N/A", "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text,_18pcd.Text,"","","","");
            else if ((string)Session["cat"] == "ZCV")
                Update(_18icom.Text, "N/A", _18qt.Text, "N/A", "N/A", "N/A", "N/A", _18wt.Text, "N/A", "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text, _18pcd.Text, "", "","","");
            else if ((string)Session["cat"] == "MOV")
                Update(_18icom.Text, "N/A", "N/A", _18qt.Text, "N/A", "N/A", "N/A", _18wt.Text, "N/A", "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text, _18pcd.Text, "", "","","");
            else if ((string)Session["cat"] == "PRS")
                Update(_18icom.Text, "N/A", "N/A", "N/A", _18qt.Text, "N/A", "N/A", _18wt.Text, "N/A", "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text, _18pcd.Text, "", "","","");
            else if ((string)Session["cat"] == "LGV")
                Update(_18icom.Text, "N/A", "N/A", "N/A", "N/A", _18qt.Text, "N/A", _18wt.Text, "N/A", "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text, _18pcd.Text, "", "","","");
            else if ((string)Session["cat"] == "CSC")
                Update(_18icom.Text, "N/A", "N/A", "N/A", "N/A", "N/A", _18qt.Text, _18wt.Text, "N/A", "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text, _18pcd.Text, "", "","","");
            else if (((string)Session["cat"] == "FHY")|| (string)Session["cat"] == "FHS")
                Update(_18icom.Text, "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", _18wt.Text, _18qt.Text, "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text, _18pcd.Text, "", "","","");
            btnDummy_ModalPopupExtender11.Hide();
        }

        protected void _18btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender11.Hide();
        }
        protected void _19btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _19rsit.Text, _19sac.Text, _19fbit.Text, _19wt.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", _19accept1.Text, "", _19filed1.Text, "", _19commts.Text, _19actby.Text, _19actdt.Text,_19pcd.Text,"","","","");
            btnDummy_ModalPopupExtender12.Hide();
        }

        protected void _19btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender12.Hide();
        }
        protected void _20btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _20cit.Text, _20ppt.Text, _20cft.Text, _20sot.Text, _20ght.Text, _20lt.Text, _20accept1.Text, _20filed1.Text, "", "", "", "", "", "", "", "", "", _20accept2.Text, _20accept3.Text, _20filed2.Text, _20filed3.Text, _20commts.Text, _20actby.Text, _20actdt.Text,_20citp.Text, _20pptp.Text,_20cftp.Text,_20sotp.Text ,_20ghtp.Text,_20ltp.Text,"","");
            btnDummy_ModalPopupExtender14.Hide();
        }
        protected void _20btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender14.Hide();
        }
        protected void _15btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _15cit.Text, _15kca.Text, _15dnd.Text, _15mur.Text, _15ftc.Text, _15ems.Text, _15lsc.Text, _15bci.Text, _15mif.Text, "", "", "", per_com11().ToString(), "", "", "", "", _15accept1.Text, "", _15filed1.Text, "", _15commts.Text, _15actby.Text, _15actdt.Text, _15pcd.Text, "", "", "", "");
            btnDummy_ModalPopupExtender19.Hide();
        }
        protected void _15btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender19.Hide();
        }
        void ECBSPlannaedNA()
        {

            if (chk_7cir.Checked && chk_7add.Checked && chk_7ft.Checked && chk_7co.Checked && chk_7ll.Checked && chk_7du.Checked && chk_7pch.Checked)
            {
                _7pc.Enabled = false;
                chk_7pc.Checked = true;
   
            }

        }
        void _cleared(TextBox txt, System.Web.UI.HtmlControls.HtmlInputCheckBox chk)
        {
            txt.Enabled = (chk.Checked ? false : true);
            txt.Text = (chk.Checked ? "N/A" : txt.Text);

        }
        void GenPlannedNA(decimal ind0,decimal ind1,decimal ind2)
        {
            //if (chk_4pc.Checked && chk_4as.Checked && chk_4lb.Checked)
            //{
            //    _4pcd.Enabled = false;
            //    _4pcd.Text = "N/A";
            //}
            //else _4pcd.Enabled = true;
            if (ind0 == -1)
            {
                _4pcd.Enabled = false;
                _4pcd.Text = "N/A";
            }
            else
            {
                SetCheckedBoxChecked(_4pcd,chk_4pcd);
            }
            if (ind1 == -1)
            {
                _4cablep.Enabled = false;
                _4cablep.Text = "N/A";
                // SetCheckedBoxChecked(_3cableplanned, chk_3cableplanned);                
            }
            else
            {
                //_3cableplanned.Text = "";
                SetCheckedBoxChecked(_4cablep,chk_4cablep);
            }
            if (ind2 == -1)
            {
                _4solp.Enabled = false;
                _4solp.Text = "N/A";
                // SetCheckedBoxChecked(_3cableplanned, chk_3cableplanned);                
            }
            else
            {
                //_3cableplanned.Text = "";
                SetCheckedBoxChecked(_4solp,chk_4solp);
            }
        }
        void Lv_PlannedNA()     
        {
            if (chk_5tor.Checked && chk_5ir.Checked && chk_5pr.Checked && chk_5si.Checked && chk_5cr.Checked && chk_5fn.Checked)
            { 
                _5ptp.Enabled = false;
                _5ptp.Text = "N/A";
            }

            if (chk_5tc.Checked && chk_5cc.Checked)
            {
                _5ctp.Enabled = false;
                _5ctp.Text = "N/A";
            }

            if (chk_5tl.Checked && chk_5lc.Checked)
            {
                _5ltp.Enabled = false;
                _5ltp.Text = "N/A";
            }

        }
        void hvmv_plannedNA()
        {
            if (chk_2tor.Checked && chk_2ir.Checked && chk_2hi.Checked && chk_2vt.Checked && chk_2ct.Checked && chk_2pi.Checked && chk_2si.Checked && chk_2cr.Checked && chk_2fn.Checked && chk_2pr.Checked && chk_2pi.Checked)
            {
                txtpanelplanned.Enabled = false;
                txtpanelplanned.Text = "N/A";
            }

            if (_2cable.Text == "N/A") { txtcableplanned.Text = "N/A"; txtcableplanned.Enabled = false; }


        }

        //void hvmv_plannedNA()
        //{
        //    if (chk_2tor.Checked && chk_2ir.Checked && chk_2hi.Checked && chk_2vt.Checked && chk_2ct.Checked && chk_2pi.Checked && chk_2si.Checked && chk_2cr.Checked && chk_2fn.Checked && chk_2pr.Checked && chk_2pi.Checked)
        //    {
        //        txtpanelplanned.Enabled = false;
        //        txtpanelplanned.Text = "N/A";
        //    }
        //    else txtpanelplanned.Enabled = true;

        //    if (_2cable.Text == "N/A") { txtcableplanned.Text = "N/A"; txtcableplanned.Enabled = false; }
        //    else txtcableplanned.Enabled = true;


        //}
        void Transformer_plannedNA(decimal ind0, decimal ind1)    
        {
            //if (chk_3ir.Checked && chk_3rt.Checked && chk_3wr.Checked && chk_3vg.Checked && chk_3trf.Checked )
            //{
            //    _3transformerplanned.Enabled = false;
            //    _3transformerplanned.Text = "N/A";
            //}
            //else _3transformerplanned.Enabled = true;

            //if (_3cable.Text == "N/A") { _3cableplanned.Text = "N/A"; _3cableplanned.Enabled = false; }
            //else txtcableplanned.Enabled = true;
            if (ind0 == -1)
            {
                _3transformerplanned.Enabled = false;
                _3transformerplanned.Text = "N/A";
               // SetCheckedBoxChecked(_3transformerplanned, chk_3txp);
            }
            else
            {
                //_3transformerplanned.Text = "";
                SetCheckedBoxChecked(_3transformerplanned, chk_3txp);
            }
            if (ind1 == -1)
            {
                _3cableplanned.Enabled = false;
                _3cableplanned.Text = "N/A";
               // SetCheckedBoxChecked(_3cableplanned, chk_3cableplanned);                
            }
            else 
            {
                //_3cableplanned.Text = "";
                SetCheckedBoxChecked(_3cableplanned, chk_3cableplanned);
            }


        }

        protected void _21btnupdate_Click(object sender, EventArgs e)
        {
            Update(_21pwron.Text, _21pf.Text, _21fvr.Text, _21cc.Text, _21facc.Text, _21bfc.Text, _21fct.Text, "", "", "", "", "", "", "", "", "", "", "", _21accept1.Text, "", _21filed1.Text, "", _21commts.Text, _21actby.Text, _21actdt.Text, _21pcd.Text, "", "", "", "");
            btnDummy_ModalPopupExtender8.Hide();
        }

        protected void _21btncancel_Click(object sender, EventArgs e)
        {           
            btnDummy_ModalPopupExtender8.Hide();           
        }
        protected void _13btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _13cit.Text, _13cvl.Text, _13cvh.Text, _13ast.Text, _13rbst.Text, "", "", "", "", "", "", "", "", "", "", "", "", _13accept1.Text, "", _13filed1.Text, "", _13commts.Text, _13actby.Text, _13actdt.Text,_13pcd.Text,"","","","");
            btnDummy_ModalPopupExtender15.Hide();
        }

        protected void _13btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender15.Hide();
        }
        protected void _11btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _11cit.Text, _11lct.Text, _11apt.Text, _11phgt.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", _11accept1.Text, "", _11filed1.Text, "", _11commts.Text, _11actby.Text, _11actdt.Text,_11pcd.Text,"","","","");
            btnDummy_ModalPopupExtender17.Hide();
        }
        protected void _11btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender17.Hide();
        }
        protected void _12btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _12ct.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", _12nop.Text, _12accept1.Text, "", _12filed1.Text, "", _12commts.Text, _12actby.Text, _12actdt.Text,_12pcd.Text,"","","","");
            btnDummy_ModalPopupExtender18.Hide();
        }

        protected void _12btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender18.Hide();
        }
        protected void _26btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _26ct.Text, _26pct.Text, _26comm.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", _26accept1.Text, "", _26filed1.Text, "", _26commts.Text, _26actby.Text, _26actdt.Text,_26pcd.Text,"","","","");
            btnDummy_ModalPopupExtender26a.Hide();

        }

        protected void _26btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender26a.Hide();

        }
        protected void _22btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _22cit.Text, _22apt.Text, _22fat.Text, _22acs.Text, _22pft.Text, _22it.Text, _22phgt.Text, "", "", "", "", "", "", "", "", "", _22noof.Text, _22accept1.Text, "", _22filed1.Text, "", _22commts.Text, _22actby.Text, _22actdt.Text, _22pcd.Text, "", "", "", "");
            btnDummy_ModalPopupExtender16.Hide();
        }

        protected void _22btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender16.Hide();
        }
        protected void _27btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _27cit.Text, _27dl.Text, _27pm.Text, _27ast.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", _27accept1.Text, "", _27filed1.Text, "", _27commts.Text, _27actby.Text, _27actdt.Text, _27pcd.Text, "", "", "", "");
            btnDummy_ModalPopupExtender27.Hide();

        }

        protected void _27btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender27.Hide();

        }
        void ACSPlannedNA()
        {
            if (chk_22cit.Checked && chk_22apt.Checked && chk_22fat.Checked && chk_22acs.Checked && chk_22pft.Checked && chk_22it.Checked && chk_22phgt.Checked)
            {
                _22pcd.Enabled = false;
            }
            else _22pcd.Enabled = true;
        }
        void PAVAPlannedNA()
        {
            if (chk_27cit.Checked && chk_27dl.Checked && chk_27pm.Checked && chk_27ast.Checked)
            {
                _27pcd.Enabled = false;
            }
            else _27pcd.Enabled = true;
        }
        protected void _25abtnupdate_Click(object sender, EventArgs e)
        {
            Update("", _25apfec.Text, _25amp.Text, _25aebt.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", _25afiled1.Text, "", _25acommts.Text, _25aactby.Text, _25aactdt.Text,_25pcd.Text,"","","","");
            btnDummy_ModalPopupExtender25a.Hide();
        }

        protected void _25abtncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender25a.Hide();
        }
        protected void _16btnupdate_Click(object sender, EventArgs e)
        {
           
            Update("", _16ir.Text, _16ppt.Text, _16cft.Text, _16sop.Text,"", "", "", "", "", "", "", "", "", "", "", "", "", _16accept1.Text, "", _16filed1.Text, "", _16commts.Text, _16actby.Text, _16actdt.Text, _16pcd.Text, "", "", "", "");
            btnDummy_ModalPopupExtender16a.Hide();
        }

        protected void _16btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender16a.Hide();
        }
        void ELVPlannedNA(decimal ind)
        {
            if (ind == -1)
            {
                _16pcd.Enabled = false;
                _16pcd.Text = "N/A";
                SetCheckedBoxChecked(_16pcd, chk_16pcd);
            }
            else
            {
               // _16pcd.Text = "";
                SetCheckedBoxChecked(_16pcd, chk_16pcd);
            }            
        }
        void KichenPlannedNA()
        {
            if (chk_24ir.Checked && chk_24ft.Checked && chk_24it.Checked)
            {
                _24pcd.Enabled = false;
            }
            else _24pcd.Enabled = true;
        }
        protected void _24btnupdate_Click(object sender, EventArgs e)
        {
            Update(_24pwron.Text, _24ir.Text, _24ft.Text, _24it.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", _24accept1.Text, "", _24filed1.Text, "", _24commts.Text, _24actby.Text, _24actdt.Text, _24pcd.Text, "", "", "", "");
            btnDummy_ModalPopupExtender23.Hide();
        }

        protected void _24btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender23.Hide();
        }
        void MVTPlannedNA()
        {
            if (chk_28tcom.Checked && chk_28tpi.Checked && chk_28el.Checked && chk_28pfm.Checked && chk_28ms.Checked && chk_28icom.Checked && chk_28fai.Checked)
            {
                _28pcd.Enabled = false;
            }
            else _28pcd.Enabled = true;
        }
        void AVIPlannedNA()     
        {
            if (chk_14cit.Checked && chk_14diab.Checked && chk_14avt.Checked && chk_14drt.Checked  )  {
                _14pcd.Enabled = false;
                _14pcd.Text = "N/A";
            }
            else _14pcd.Enabled = true;
        }
        protected void _28btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _28tcom.Text, _28tpi.Text, _28el.Text, _28pfm.Text, _28ms.Text, _28icom.Text, _28fai.Text, "", "", "", "", "", "", "", "", "", "", _28accept1.Text, "", _28filed1.Text, "", _28commts.Text, _28actby.Text, _28actdt.Text, _28pcd.Text, "", "", "", "");
            btnDummy_ModalPopupExtender26.Hide();
        }

        protected void _9btnupdate_Click(object sender, EventArgs e)
        {
            Update(_9icom.Text, _9aa.Text, _9dtp.Text, _9rp.Text, _9moo.Text, _9sro.Text, _9est.Text, _9psrt.Text, "", "", "", "", "", "", "", "", "", "", _9accept1.Text, "", _9filed1.Text, "", _9commts.Text, _9actby.Text, _9actdt.Text, _9pcd.Text,"","","","");
            btnDummy_ModalPopupExtender9.Hide();
        }
        protected void _9btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender9.Hide();
        }
        protected void _28btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender26.Hide();
        }

        protected void _2btnupdate_Click(object sender, EventArgs e)
        {

            Update(_2pwron.Text, _2tor.Text, _2ir.Text, _2hi.Text, _2vt.Text, _2ct.Text, _2pi.Text, _2si.Text, _2cr.Text, _2fn.Text, _2pr.Text, _2cable.Text, "", "", "", _2ttt.Text, _2cte.Text, _2noc.Text, _2accept1.Text, _2accept2.Text, _2filed1.Text, _2filed2.Text, _2commts.Text, _2actby.Text, _2actdt.Text, txtpanelplanned.Text, txtcableplanned.Text, "", "", "");
            btnDummy_ModalPopupExtender2_hvmv.Hide();
        }
        protected void _2btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender2_hvmv.Hide();
        }
        void SetTextBoxNA(TextBox txt, System.Web.UI.HtmlControls.HtmlInputCheckBox chk)
        {
            txt.Text = (chk.Checked ? "N/A" : txt.Text);
            txt.Enabled = (chk.Checked ? false : true);
        }
        protected void _3btnupdate_Click(object sender, EventArgs e)
        {
            Update(_3pwron.Text, _3ir.Text, _3rt.Text, _3wr.Text, _3vg.Text, _3trf.Text, _3cable.Text, "", "", "", "", "", "", "", "", "", "", "", _3accept1.Text, _3accept2.Text, _3filed1.Text, _3filed2.Text, _3commts.Text, _3actby.Text, _3actdt.Text,_3transformerplanned.Text,_3cableplanned.Text,"","","");
            //_3pwron.Text = ""; _3ir.Text = ""; _3rt.Text = ""; _3wr.Text = ""; _3vg.Text = ""; _3trf.Text = ""; _3cable.Text = ""; _3accept1.Text = ""; _3filed1.Text = ""; _3accept2.Text = ""; _3filed2.Text = ""; _3commts.Text = ""; _3actby.Text = ""; _3actdt.Text = "";
            btnDummy_ModalPopupExtender3_trans.Hide();
        }

        protected void _3btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender3_trans.Hide();
        }
        protected void _14btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _14cit.Text, _14diab.Text, _14avt.Text, _14drt.Text, "", "", "", "", "", "", "", "", "", "", "", "", _14noof.Text, _14accept1.Text, "", _14filed1.Text, "", _14commts.Text, _14actby.Text, _14actdt.Text,_14pcd.Text,"","","","");
            btnDummy_ModalPopupExtender20.Hide();
        }
        protected void _14btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender20.Hide();
        }
        private bool ValidateDevice(string dvce)
        {
            bool res = false;
            if (IsNumeric(_18qt.Text))
            {
                if ((Convert.ToInt32(_18qt.Text) <= Convert.ToInt32(dvce)) && (Convert.ToInt32(_18qt.Text)) >= 0)
                    res = true;
            }
            else
                res = false;
            return res;
        }
        void FDPlannedNA(decimal ind)
        {
            if ((string)Session["cat"] == "FD")
            {
                if (ind == -1)
                {
                    _9pcd.Enabled = false;
                    _9pcd.Text = "N/A";
                    SetCheckedBoxChecked(_9pcd, chk_9pcd);
                }
                //else if (ind == -1 chk_9aa.Checked && chk_9dtp.Checked && chk_9rp.Checked)
                //{
                //    _9pcd.Text = "N/A";
                //    _9pcd.Enabled = false;
                //    chk_9pcd.Checked = true;
                //}
                //else
                //{
                //    _9pcd.Text = "";
                //    SetCheckedBoxChecked(_9pcd, chk_9pcd);
                //}                   
            }
            else if ((string)Session["cat"] == "MD" || (string)Session["cat"] == "MSFD")
            {
                //if (chk_9moo.Checked && chk_9sro.Checked && chk_9est.Checked && chk_9psrt.Checked)
                //{
                //    _9pcd.Enabled = false;
                //    _9pcd.Text = "N/A";
                //    chk_9pcd.Checked = false;                   
                //}
                if (ind == -1)
                {
                    _9pcd.Text = "N/A";
                    _9pcd.Enabled = false;
                    //SetCheckedBoxChecked(_9pcd, chk_9pcd);
                }
                else
                {
                   _9pcd.Text = "";
                   SetCheckedBoxChecked(_9pcd, chk_9pcd);
                }                             
            }
        }
        void Ph2PlannedNA(decimal ind)
        {
            if (ind == -1)
            {
                _18pcd.Enabled = false;
                _18pcd.Text = "N/A";
                chk_18pcd.Checked = true;
            }
            else
                SetCheckedBoxChecked(_18pcd, chk_18pcd);
        }
        void _21PlannedNA(decimal ind) 
        {
            if ((chk_21pf.Checked && chk_21fvr.Checked && chk_21cc.Checked && chk_21facc.Checked && chk_21bfc.Checked && chk_21fct.Checked))
            {
                _21pcd.Text = "N/A";
                _21pcd.Enabled = false;
                chk_21pcd.Checked = false;

            }
            else if(ind == -1)
            {
                _21pcd.Text = "N/A";
                _21pcd.Enabled = false;
                chk_21pcd.Checked = true;              
            }  
            else
                SetCheckedBoxChecked(_21pcd, chk_21pcd);
        }
        protected decimal per_com11()
        {
            decimal _percentage = 0;

            if ((per_com1() == -1 && per_com2() == -1 && per_com3() == -1 && per_com4() == -1 && per_com5() == -1 && per_com6() == -1 && per_com7() == -1 && per_com8() == -1 && per_com9() == -1) || _15pcd.Text == "N/A")
            {
                _percentage = -1;
            }
            return _percentage;
        }
        void _13PlannedNA(decimal ind)
        {
            if ((chk_13cit.Checked && chk_13cvl.Checked && chk_13cvh.Checked && chk_13ast.Checked && chk_13rbst.Checked) || ind == -1)
            {
                _13pcd.Text = "N/A";
                _13pcd.Enabled = false;
            }
            else
                SetCheckedBoxChecked(_13pcd, chk_13pcd);
        }
        void PH3PlannedNA(decimal ind) 
        {
            if (ind == -1)
            {
                _19pcd.Enabled = false;
                _19pcd.Text = "N/A";
                chk_19pcd.Checked = true;
            }
            else
                SetCheckedBoxChecked(_18pcd, chk_18pcd);
        }
    }
}
