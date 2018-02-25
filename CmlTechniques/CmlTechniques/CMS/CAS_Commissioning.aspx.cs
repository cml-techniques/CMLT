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
    public partial class CAS_Commissioning : System.Web.UI.Page
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
                if (lblprj.Text == "HMIM" || lblprj.Text == "14211")
                {
                    lblsch.Text = _prm.Substring(_prm.IndexOf("_S") + 2, _prm.IndexOf("_F") - (_prm.IndexOf("_S") + 2));
                    lbldiv.Text = _prm.Substring(_prm.IndexOf("_F") + 2);
                    //CalendarExtender236.PopupButtonID = "_10ccit";
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
            if (lblsch.Text == "5" || lblsch.Text == "1")
            {
                lbnum.Text = "NO.OF CIRCUITS";
                lbl1.Text = "PROVIDES POWER TO";
                lbl3.Text = "FED FROM";
                lblhead.Text = "CAS E4 Electrical Services. LV Commissioning Activity Schedule";
                td_2.Visible = false; td_lbl2.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "2")
            {
                //lbnum.Text = "";
                //lbnum.Enabled = false;
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "SUBSTATION";
                lbl3.Text = "FED FROM";
                lblhead.Text = "CAS E1 Electrical Services. HV-MV Switchgear & RMU Commissioning Activity Schedule";
                td_3.Visible = false; td_lbnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "3")
            {
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "AREA";
                lbl3.Text = "FED FROM";
                lblhead.Text = "CAS E2 Electrical Services. HV & MV Transformers Commissioning Activity Schedule";
                td_3.Visible = false; td_lbnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "4")
            {
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "SUBSTATION";
                lbl3.Text = "FED FROM";
                td_2.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_lbnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
                lblhead.Text = "CAS E5 Electrical Services. Generator Commissioning Activity Schedule";
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
            else if (lblsch.Text == "30")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "";
                lblhead.Text = "CAS ELV7 - Voice Communication System Commissioning Activity Schedule";
                td_lbl2.Visible = false; td_2.Visible = false;
                td_lbl1.Visible = false; td_0.Visible = false;
                lbldes.Text = "ROON NO.";
                lbloc.Text = "LOCATION";
                lbl3.Text = "CONNECTED FROM";
                lbnum.Text = "NO.OF EQUIPMENTS";
            }
            else if (lblsch.Text == "11")
            {
                lbloc.Text = "AREA SERVED";
                lbl2.Text = "NO.OF CIRCUITS";
                lbnum.Text = "NO.OF LIGHTING SCENES";
                drfed.Style.Add("display", "none");
                lblhead.Text = "CAS ELV5 Lighting Control System Commissioning Activity Schedule";
                td_lbldes.Visible = false; td_txtdescr.Visible = false; td_0.Visible = false; td_lbl1.Visible = false;
                lbl3.Text = "FED FROM";
                lbl1.Text = "";
                td_3.Visible = true;

            }
            else if (lblsch.Text == "12")
            {
                lbl2.Text = "";
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
                td_lbl2.Visible = false; td_2.Visible = false;
                lbl1.Text = "FED FROM";
                lbloc.Text = "LOCATION";

                lbnum.Text = "NO.OF POINTS";

                if (lblprj.Text == "14211")
                {
                    lbl3.Text = "CONNECTED TO";
                    lblhead.Text = "CAS ELV8 - Information and Communication Technology (ICT) Commissioning Activity Schedule";
                }
                else
                {
                    lblhead.Text = "CAS ELV 6 - Structured Cabling Network Commissioning Activity Schedule";
                    lbl3.Text = "CONNECTED FROM";
                }


            }
            else if (lblsch.Text == "13")
            {
                lbloc.Text = "SYSTEMS MONITORED";
                lbnum.Text = "NO.OF CAMERAS";
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
                td_lbl1.Visible = false;
                td_0.Visible = false;
                td_lbl2.Visible = false;
                td_2.Visible = false;
                lbl3.Text = "FED FROM";
                lbl1.Text = "";

                if (lblprj.Text == "14211")
                    lblhead.Text = "CAS ELV3 - Visual Security Systems Commissioning Activity Schedule";
                else
                    lblhead.Text = "CAS ELV 3 - CCTV Commissioning Activity Schedule";

            }
            else if (lblsch.Text == "22")
            {
                lbnum.Text = "NO.OF ACCESS CONTROLLED DOORS";
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
                td_lbl1.Visible = false;
                td_0.Visible = false;
                td_lbl2.Visible = false;
                td_2.Visible = false;
                lbl3.Text = "FED FROM";
                drfed.Style.Add("display", "block");
                lblhead.Text = "CAS ELV4 - Security & Access Control Systems Commissioning Activity Schedule";
                lbloc.Text = "DOORS MONITORED / CONTROLLED";
            }
            else if (lblsch.Text == "32")
            {
                lbnum.Text = "NO.OF POINTS";
                lbl1.Text = "";
                lbl3.Text = "";
                lbl2.Text = "";
                drfed.Style.Add("display", "none");
                lblhead.Text = "CAS ELV10 - GSM & TETRA Commissioning Activity Schedule";
                td_2.Visible = false; td_lbl2.Visible = false; td_1.Visible = false; td_lbl3.Visible = false; td_lbl1.Visible = false; td_0.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "31")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "";
                lblhead.Text = "CAS ELV12 - Computing & Data Storage Systems Commissioning Activity Schedule";
                td_lbl2.Visible = false; td_2.Visible = false;
                td_lbl1.Visible = false; td_0.Visible = false;
                lbldes.Text = "ROON NO.";
                lbloc.Text = "LOCATION";
                lbl3.Text = "CONNECTED FROM";
                lbnum.Text = "NO.OF EQUIPMENTS";
            }
            else if (lblsch.Text == "33")
            {
                lbnum.Text = "NO.OF POINTS";
                lbloc.Text = "LOCATION";
                lbl1.Text = "CONNECTED TO";
                lbl3.Text = "FED FROM";
                lbl2.Text = "";

                lblhead.Text = "CAS ELV11- Master Clock System Commissioning Activity Schedule";
                td_2.Visible = false; td_lbl2.Visible = false;


                td_lbldes.Visible = false; td_txtdescr.Visible = false;

            }
            else if (lblsch.Text == "29")
            {
                lbnum.Text = "NO.OF EQUIPMENTS";
                lbl1.Text = "";
                lbl3.Text = "";
                lbl2.Text = "";
                drfed.Style.Add("display", "none");
                lblhead.Text = "CAS ELV9- IPTV System Commissioning Activity Schedule";

                td_2.Visible = false; td_lbl2.Visible = false; td_1.Visible = false; td_lbl3.Visible = false; td_lbl1.Visible = false; td_0.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "28")
            {
                if (lblprj.Text == "14211")
                {
                    lbnum.Text = "NO.OF EQUIPMENTS";
                    lbl3.Text = "";
                    drfed.Style.Add("display", "none");

                    lblhead.Text = "CAS ELV8 Audio Visual System Commissioning Activity Schedule";
                    td_0.Visible = false; td_lbl1.Visible = false; td_lbl2.Visible = false;
                    td_2.Visible = false;
                    //td_3.Visible = false;
                    //td_lbnum.Visible = false; td_txtnum.Visible = false;
                    td_lbldes.Visible = false; td_txtdescr.Visible = false;
                    td_lbl3.Visible = false; td_1.Visible = false;
                }
                else
                {
                    lbl3.Text = "FED FROM";
                    if (lblprj.Text == "HMIM")
                        lblhead.Text = "CAS ELV 10  - Public Address System Commissioning Activity Schedule";
                    lbl1.Text = "LOOP CIRCUIT NO.";
                    drfed.Style.Add("display", "block");
                    td_txtdescr.Visible = false; td_lbldes.Visible = false; td_lbl1.Visible = false;
                    td_0.Visible = false; td_3.Visible = true;

                }
            }
            else if (lblsch.Text == "39")
            {
                lbnum.Text = "NO. DEVICES";
                lbloc.Text = "LOCATION";
                lbl1.Text = "DEVICE TYPE";
                lbl3.Text = "ROOM NO";
                lbl2.Text = "FED FROM";

                lblhead.Text = "CAS ELV 13- Car Park Management System Commissioning Activity Schedule";

                td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "34")
            {
                lbloc.Text = "LOCATION";
                lbl3.Text = "FED FROM";
                lbl1.Text = "PROVIDES POWER TO";

                lblhead.Text = "CAS E7 Electrical Services.  UPS & CHARGER Commissioning Activity Schedule";

                td_lbl2.Visible = false; td_2.Visible = false; td_3.Visible = false;
                td_lbnum.Visible = false;
                td_lbldes.Visible = false; td_txtdescr.Visible = false;



            }
            else if (lblsch.Text == "37")
            {
                lbnum.Text = "NO. DEVICES TESTED";
                lbloc.Text = "LOCATION";
                lbl1.Text = "DEVICE TYPE";
                lbl3.Text = "ROOM NO";
                lbl2.Text = "FED FROM";

                lblhead.Text = "CAS SAS 1 - Special Airport System Commissioning Activity Schedule";

                td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "35")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                ;

                lblhead.Text = "CAS Fuel System Services Commissioning Activity Schedule";
                td_0.Visible = false; td_lbnum.Visible = false; td_lbl1.Visible = false;
                td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
            }
            else if (lblsch.Text == "15")
            {
                lblhead.Text = " CAS ELV 7 - Guest Room Management System Commissioning Activity Schedule";
                lbl3.Text = "FED FROM";
                lbnum.Text = "NO.OF PANELS";
                td_lbl1.Visible = false;
                td_0.Visible = false;
                td_lbl0.Visible = false;
                td0.Visible = false;
                td_lbl2.Visible = false;
                td_2.Visible = false;
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "14")
            {
                lblhead.Text = "CAS ELV8 - Audio-Visual Intercom Commissioning Activity Schedule";
                lbl3.Text = "FED FROM";
                lbnum.Text = "NO.OF PANELS";
                td_lbl1.Visible = false;
                td_0.Visible = false;
                td_lbl0.Visible = false;
                td0.Visible = false;
                td_lbl2.Visible = false;
                td_2.Visible = false;
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "9")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lblhead.Text = "CAS M3 Fusible Link Fire Dampers & MSFD Commissioning Activity Schedule";

                lbl3.Text = "FED FROM";

                td_0.Visible = false; td_lbnum.Visible = false; td_lbl1.Visible = false;
                td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;

            }
            else if (lblsch.Text == "10")
            {
                lbl3.Text = "FED FROM";
                if (lblprj.Text == "HMIM")
                    lblhead.Text = "6.2.1 -Fire Alarm and Fire Telephone Communication System Commissioning Activity Schedule";
                else
                    lblhead.Text = "CAS ELV1 - Fire Alarm & Voice Evacuation Commissioning Activity Schedule";
                lbl1.Text = "LOOP CIRCUIT NO.";
                drfed.Style.Add("display", "block");
                td_txtdescr.Visible = false; td_lbldes.Visible = false; td_lbl1.Visible = false;
                td_0.Visible = false; td_3.Visible = true;
            }
            else if (lblsch.Text == "27")
            {
                if (lblprj.Text == "HMIM" || lblprj.Text == "OCEC")
                {
                    lbl1.Text = "";
                    lbl2.Text = "DESCRIPTION";
                    lbl3.Text = "FED FROM";

                    lblhead.Text = "CAS MISC1 - Horizontal & Vertical Transportation Systems Commissioning Activity Schedule";
                    td_3.Visible = false; td_lbnum.Visible = false;
                    td_0.Visible = false; td_lbl1.Visible = false;
                    td_txtdescr.Visible = false; td_lbldes.Visible = false;

                    lbl2.Text = ""; lbl1.Text = ""; lbl2.Text = ""; lbnum.Text = "";

                    td_lbl1.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;

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
            Load_cassheet_details(Convert.ToInt32(_item1.Text));
            if (lblsch.Text == "30") { btnDummy_ModalPopupExtender7.Show(); _30lbl.Text = _title; }
            else if (lblsch.Text == "12" && lblprj.Text == "14211") { ModalPopupExtender1.Show(); _12lbl.Text = _title; }
            else if (lblsch.Text == "12" && lblprj.Text == "HMIM") { btnDummy_ModalPopupExtender18.Show(); _12albl.Text = _title; }
            else if (lblsch.Text == "13")
            {
                if (lblprj.Text == "HMIM") { lblvl.Text = "CCTV View Locally"; lblvh.Text = "CCTV View Locally"; }
                //if (lblprj.Text == "14211") { lblvl.Text = "VSS View Locally"; lblvh.Text = "VSS View Locally"; }
                btnDummy_ModalPopupExtender15.Show(); _13lbl.Text = _title;
            }
            else if (lblsch.Text == "32") { btnDummy_ModalPopupExtender39.Show(); _39lbl.Text = _title; }
            else if (lblsch.Text == "31") { btnDummy_ModalPopupExtender31.Show(); _31lbl.Text = _title; }
            else if (lblsch.Text == "33") { btnDummy_ModalPopupExtender33.Show(); _33lbl.Text = _title; }
            else if (lblsch.Text == "29") { btnDummy_ModalPopupExtender29.Show(); _29lbl.Text = _title; }
            else if (lblsch.Text == "22") { btnDummy_ModalPopupExtender16.Show(); _22lbl.Text = _title; }
            else if (lblsch.Text == "11") { btnDummy_ModalPopupExtender17.Show(); _11lbl.Text = _title; }
            else if (lblsch.Text == "28") {
                if (lblprj.Text=="14211") {btnDummy_ModalPopupExtender28.Show(); _28lbl.Text = _title;}
                else
                { btnDummy_ModalPopupExtender13.Show(); _10lbl.Text = _title; }
            }
            else if (lblsch.Text == "39") { btnDummy_ModalPopupExtender39a.Show(); _39albl.Text = _title; }
            else if (lblsch.Text == "34") { btnDummy_ModalPopupExtender34.Show(); _34lbl.Text = _title; }
            else if (lblsch.Text == "37") { btnDummy_ModalPopupExtender14.Show(); _37lbl.Text = _title; }
            else if (lblsch.Text == "35") { btnDummy_ModalPopupExtender35.Show(); _35lbl.Text = _title; }
            else if (lblsch.Text == "15")
            {
                btnDummy_ModalPopupExtender19.Show(); _15lbl.Text = _title;

            }
            else if (lblsch.Text == "14") { btnDummy_ModalPopupExtender20.Show(); _14lbl.Text = _title; }
            else if (lblsch.Text == "9")
            {
                //if (lblprj.Text != "ASAO")
                //{
                //    lblicom.Visible = false;
                //    _9icom.Visible = false;
                //}

                if ((string)Session["cat"] == "FD")
                {
                    chk_9moo.Checked = true; chk_9sro.Checked = true; chk_9est.Checked = true; chk_9psrt.Checked = true;
                    _9dtp.Enabled = true; _9rp.Enabled = true; _9aa.Enabled = true;
                    _9moo.Text = "N/A"; _9sro.Text = "N/A"; _9est.Text = "N/A"; _9psrt.Text = "N/A";
                    //_9moo.Enabled = false; _9sro.Enabled = false; _9est.Enabled = false; _9psrt.Enabled = false;
                }
                else if ((string)Session["cat"] == "MSFD")
                {
                    chk_9aa.Checked = true; chk_9dtp.Checked = true; chk_9rp.Checked = true;
                    _9aa.Text = "N/A"; _9dtp.Text = "N/A"; _9rp.Text = "N/A";
                    //_9aa.Enabled = false; _9dtp.Enabled = false; _9rp.Enabled = false;
                    _9moo.Enabled = true; _9sro.Enabled = true; _9est.Enabled = true; _9psrt.Enabled = true;
                }
                btnDummy_ModalPopupExtender9.Show();
                _9lbl.Text = _title;
            }
            else if (lblsch.Text == "10") { btnDummy_ModalPopupExtender13.Show(); _10lbl.Text = _title; }
            else if (lblsch.Text == "27")
            {
                if ((string)Session["cat"] == "ESC" || (string)Session["cat"] == "BMU" || (string)Session["cat"] == "TRV")
                {
                    _27eml.Text = "N/A"; _27int.Text = "N/A";
                    SetCheckedBoxChecked(_27eml, chk_27eml);
                    SetCheckedBoxChecked(_27int, chk_27int);

                }

                btnDummy_ModalPopupExtender27.Show();
                _27lbl.Text = _title;
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
            else if (lblsch.Text == "4" || lblsch.Text == "37")
            {
                if (lblprj.Text == "14211" && (string)Session["sch"] == "37")
                {
                    e.Row.Cells[7].Visible = false;
                }
                else
                {
                    e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
                }

            }
            else if (lblsch.Text == "2" || lblsch.Text == "3")
            {
                e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "30")
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if (lblsch.Text == "12")
            {
                e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if (lblsch.Text == "13" || lblsch.Text == "22")
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if (lblsch.Text == "11")
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "32")
            {
                e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
                e.Row.Cells[10].Visible = false; e.Row.Cells[9].Visible = false;
            }
            else if ((string)Session["sch"] == "31")
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "33")
            {
                e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "29")
            {
                e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
                e.Row.Cells[10].Visible = false; e.Row.Cells[9].Visible = false;
            }

            else if ((string)Session["sch"] == "28")
            {
                if ( lblprj.Text == "14211")
                {
                    e.Row.Cells[11].Visible = false;
                    e.Row.Cells[9].Visible = false;
                }
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[10].Visible = false;

            }
            else if ((string)Session["sch"] == "39")
            {
                e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "35")
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "34")
            {
                e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "15")
            {
                e.Row.Cells[8].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if (lblsch.Text == "14")
            {
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
            }

            else if (lblsch.Text == "9")
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false;
            }
            else if (lblsch.Text == "10")
            {
                e.Row.Cells[10].Visible = false;
                e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "27")
            {
                if (lblprj.Text == "HMIM" || lblprj.Text == "OCEC")
                {
                    e.Row.Cells[7].Visible = false; e.Row.Cells[12].Visible = false;
                    e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
                }
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
            _objbll.Cassheet_update(_objcls, _objdb);
        }
        protected decimal per_com1()
        {

            decimal _percentage = 0;
            if (lblsch.Text == "30")
            {
                if (IsNumeric(_30ct.Text) == true)
                    _percentage = Convert.ToDecimal(_30ct.Text);
            }
            else if (lblsch.Text == "12" && lblprj.Text == "14211")
            {

                if (IsNumeric(_12ct.Text) == true)
                    _percentage = Convert.ToDecimal(_12ct.Text);
            }
            else if (lblsch.Text == "12" && lblprj.Text == "HMIM")
            {

                if (IsNumeric(_12act.Text))
                    _percentage = Convert.ToDecimal(_12act.Text);
            }
            else if (lblsch.Text == "13")
            {
                if (IsNumeric(_13cit.Text))
                    _percentage = Convert.ToDecimal(_13cit.Text);
            }
            else if (lblsch.Text == "32")
            {
                if (IsNumeric(_39ct.Text) == true)
                    _percentage = Convert.ToDecimal(_39ct.Text);
                else if (_39ct.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "31")
            {
                if (IsNumeric(_31ct.Text) == true)
                    _percentage = Convert.ToDecimal(_31ct.Text);
                else if (_31ct.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "33")
            {
                if (IsNumeric(_33ct.Text) == true)
                    _percentage = Convert.ToDecimal(_33ct.Text);
                else if (_33ct.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "29")
            {
                if (IsNumeric(_29cct.Text) == true)
                    _percentage = Convert.ToDecimal(_29cct.Text);
                else if (_29cct.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "22")
            {
                if (IsNumeric(_22cit.Text))
                    _percentage = Convert.ToDecimal(_22cit.Text);
            }
            else if (lblsch.Text == "11")
            {
                if (IsNumeric(_11cit.Text))
                    _percentage = Convert.ToDecimal(_11cit.Text);
            }
            else if (lblsch.Text == "28")
            {
                if (lblprj.Text=="14211")
                {
                if (DateValidation(_28cit.Text) == true)
                    _percentage = 1;
                else if (_28cit.Text == "N/A")
                    _percentage = -1;
                }
                else
                {
                 if (DateValidation(_10ccit.Text) == true)
                _percentage = 1;
                else if (_10ccit.Text == "N/A")
                _percentage = -1;

                }
            }
            else if (lblsch.Text == "39")
            {
                if (IsNumeric(_39adt.Text) == true)
                    _percentage = Convert.ToDecimal(_39adt.Text);
                else if (_39adt.Text == "N/A")
                    _percentage = -1;
            }

            else if (lblsch.Text == "37")
            {
                if (IsNumeric(_37ct.Text))
                    _percentage = Convert.ToDecimal(_37ct.Text);
                else if (_37ct.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "35")
            {
                if (DateValidation(_35pc1.Text) == true)
                    _percentage = 1;
                else if (_35pc1.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "34")
            {
                int _no = 0;
                int count = 0;
                if (DateValidation(_34pc.Text) == true)
                    count += 1;
                if (DateValidation(_34lb.Text) == true)
                    count += 1;
                if (DateValidation(_34ucf.Text) == true)
                    count += 1;

                if (_34pc.Text != "N/A")
                    _no += 1;
                if (_34ucf.Text != "N/A")
                    _no += 1;
                if (_34lb.Text != "N/A")
                    _no += 1;

                if (_no > 0) _percentage = (Convert.ToDecimal(count) / _no) * 100;
                else _percentage = -1;
            }
            else if (lblsch.Text == "15")
            {
                if (IsNumeric(_15cit.Text))
                    _percentage = Convert.ToDecimal(_15cit.Text);
                else if (_15cit.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "14")
            {
                if (IsNumeric(_14cit.Text))
                    _percentage = Convert.ToDecimal(_14cit.Text);
                else if (_14cit.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "9")
            {
                int _no = 0;
                int count = 0;
                if (_9aa.Text != "N/A")
                {
                    chk_9aa.Checked = true;
                    //if (_9aa.Text != "" && _9dtp.Text != "" && _9rp.Text != "")
                    //    _percentage = 1;

                    if (_9aa.Text != "N/A")
                        _no += 1;
                    if (_9dtp.Text != "N/A")
                        _no += 1;
                    if (_9rp.Text != "N/A")
                        _no += 1;

                    if (DateValidation(_9aa.Text) == true)
                        count += 1;
                    if (DateValidation(_9dtp.Text) == true)
                        count += 1;
                    if (DateValidation(_9rp.Text) == true)
                        count += 1;

                    if (_no > 0) _percentage = (Convert.ToDecimal(count) / _no) ;


                }
                else if (_9moo.Text != "N/A")
                {
                    _no = 0;
                    count = 0;
                    chk_9moo.Checked = true;
                    //if (_9moo.Text != "" && _9sro.Text != "" && _9est.Text != "" && _9psrt.Text != "")
                    //    _percentage = 1;

                    if (_9moo.Text != "N/A")
                        _no += 1;
                    if (_9dtp.Text != "N/A")
                        _no += 1;
                    if (_9est.Text != "N/A")
                        _no += 1;
                    if (_9psrt.Text != "N/A")
                        _no += 1;

                    
                    if (DateValidation(_9moo.Text) == true)
                        count += 1;
                    if (DateValidation(_9sro.Text) == true)
                        count += 1;
                    if (DateValidation(_9est.Text) == true)
                        count += 1;
                    if (DateValidation(_9psrt.Text) == true)
                        count += 1;

                    if (_no > 0) _percentage = (Convert.ToDecimal(count) / _no);

                }
            }
            else if (lblsch.Text == "10")
            {
                if (DateValidation(_10ccit.Text) == true)
                    _percentage = 1;
                else if (_10ccit.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "27")
            {
                int _no = 0;
                int count = 0;

                //_27tc.Text = row[24].ToString();
                //_27tpi.Text = row[25].ToString();
                //_27eml.Text = row[26].ToString();
                //_27pfm.Text = row[27].ToString();
                //_27lms.Text = row[28].ToString();
                //_27int.Text = row[29].ToString();
                //_27bfa.Text = row[30].ToString();

                if (_27tc.Text != "N/A")
                    _no += 1;
                if (_27tpi.Text != "N/A")
                    _no += 1;
                if (_27eml.Text != "N/A")
                    _no += 1;
                if (_27pfm.Text != "N/A")
                    _no += 1;
                if (_27lms.Text != "N/A")
                    _no += 1;
                if (_27int.Text != "N/A")
                    _no += 1;
                if (_27bfa.Text != "N/A")
                    _no += 1;

                if (DateValidation(_27tc.Text) == true)
                    count += 1;
                if (DateValidation(_27tpi.Text) == true)
                    count += 1;
                if (DateValidation(_27eml.Text) == true)
                    count += 1;
                if (DateValidation(_27pfm.Text) == true)
                    count += 1;
                if (DateValidation(_27lms.Text) == true)
                    count += 1;
                if (DateValidation(_27int.Text) == true)
                    count += 1;
                if (DateValidation(_27bfa.Text) == true)
                    count += 1;

                if (_no > 0) _percentage = (Convert.ToDecimal(count) / _no) * 100;

            }


            return _percentage;
        }
        protected decimal per_com2()
        {

            decimal _percentage = 0;
            if (lblsch.Text == "30")
            {
                if (IsNumeric(_30ft.Text) == true)
                    _percentage = Convert.ToDecimal(_30ft.Text);
            }
            else if (lblsch.Text == "12" && lblprj.Text == "14211")
            {
                if (IsNumeric(_12ft.Text) == true)
                    _percentage = Convert.ToDecimal(_12ft.Text);
            }
            else if (lblsch.Text == "12" && lblprj.Text == "HMIM")
            {
                if (DateValidation(_12aaccept1.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "13")
            {
                if (IsNumeric(_13cvl.Text))
                    _percentage = Convert.ToDecimal(_13cvl.Text);
            }
            else if (lblsch.Text == "32")
            {
                if (IsNumeric(_39rft.Text) == true)
                    _percentage = Convert.ToDecimal(_39rft.Text);
                else if (_39rft.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "31")
            {
                if (IsNumeric(_31ft.Text) == true)
                    _percentage = Convert.ToDecimal(_31ft.Text);
                else if (_31ft.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "33")
            {
                if (IsNumeric(_33ft.Text) == true)
                    _percentage = Convert.ToDecimal(_33ft.Text);
                else if (_33ft.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "29")
            {
                if (IsNumeric(_29aft.Text) == true)
                    _percentage = Convert.ToDecimal(_29aft.Text);
                else if (_29aft.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "22")
            {
                if (IsNumeric(_22apt.Text) == true)
                    _percentage = Convert.ToDecimal(_22apt.Text);
            }
            else if (lblsch.Text == "11")
            {
                if (IsNumeric(_11lct.Text) == true)
                    _percentage = Convert.ToDecimal(_11lct.Text);
            }
            else if (lblsch.Text == "28")
            {
                if (lblprj.Text == "14211")
                {
                    if (DateValidation(_28ava.Text) == true)
                        _percentage = 1;
                    else if (_28ava.Text == "N/A")
                        _percentage = -1;
                }
                else
                {
                    if (IsNumeric(_10ndt.Text) == true)
                        _percentage = Convert.ToDecimal(_10ndt.Text);
                    else if (_10ndt.Text == "N/A")
                        _percentage = -1;

                }
            }
            else if (lblsch.Text == "39")
            {
                if (IsNumeric(_39aci.Text) == true)
                    _percentage = Convert.ToDecimal(_39aci.Text);
                else if (_39aci.Text == "N/A")
                    _percentage = -1;
            }

            else if (lblsch.Text == "37")
            {
                if (IsNumeric(_37ft.Text))
                    _percentage = Convert.ToDecimal(_37ft.Text);
                else if (_37ft.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "35")
            {
                if (DateValidation(_35co1.Text) == true)
                    _percentage = 1;
                else if (_35co1.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "34")
            {
                if (DateValidation(_34cable.Text) == true)
                    _percentage = 100;
                else if (_34cable.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "15")
            {
                if (IsNumeric(_15kca.Text))
                    _percentage = Convert.ToDecimal(_15kca.Text);
                else if (_15kca.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "14")
            {
                if (IsNumeric(_14diab.Text) == true)
                    _percentage = Convert.ToDecimal(_14diab.Text);
                else if (_14diab.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "9")
            {
                if (_9accept1.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "10")
            {
                if (IsNumeric(_10ndt.Text) == true)
                    _percentage = Convert.ToDecimal(_10ndt.Text);
                else if (_10ndt.Text == "N/A")
                    _percentage = -1;
            }
            return _percentage;
        }
        protected decimal per_com3()
        {

            decimal _percentage = 0;
            if (lblsch.Text == "13")
            {
                if (IsNumeric(_13cvh.Text))
                    _percentage = Convert.ToDecimal(_13cvh.Text);
            }
            else if (lblsch.Text == "32")
            {
                if (IsNumeric(_39aft.Text) == true)
                    _percentage = Convert.ToDecimal(_39aft.Text);
                else if (_39aft.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "29")
            {
                if (IsNumeric(_29vft.Text) == true)
                    _percentage = Convert.ToDecimal(_29vft.Text);
                else if (_29vft.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "22")
            {
                if (IsNumeric(_22fat.Text) == true)
                    _percentage = Convert.ToDecimal(_22fat.Text);
            }
            else if (lblsch.Text == "11")
            {
                if (IsNumeric(_11apt.Text) == true)
                    _percentage = Convert.ToDecimal(_11apt.Text);
            }
            else if (lblsch.Text == "28")
            {
                if (lblprj.Text == "14211")
                {
                    if (DateValidation(_28avv.Text) == true)
                        _percentage = 1;
                    else if (_28avv.Text == "N/A")
                        _percentage = -1;
                }
                else
                {
                    if (IsNumeric(_10fait.Text) == true)
                        _percentage = Convert.ToDecimal(_10fait.Text);
                    else if (_10fait.Text == "N/A")
                        _percentage = -1;
                }
            }
            else if (lblsch.Text == "39")
            {
                if (IsNumeric(_39acit.Text) == true)
                    _percentage = Convert.ToDecimal(_39acit.Text);
                else if (_39acit.Text == "N/A")
                    _percentage = -1;
            }

            else if (lblsch.Text == "37")
            {
                if (IsNumeric(_37it.Text))
                    _percentage = Convert.ToDecimal(_37it.Text);
                else if (_37it.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "35")
            {
                if (DateValidation(_35wd1.Text) == true)
                    _percentage = 1;
                else if (_35wd1.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "34")
            {
                if (DateValidation(_34sol.Text) == true)
                    _percentage = 100;
                else if (_34sol.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "15")
            {
                if (IsNumeric(_15dnd.Text) == true)
                    _percentage = Convert.ToDecimal(_15dnd.Text);
                else if (_15dnd.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "14")
            {
                if (IsNumeric(_14avt.Text) == true)
                    _percentage = Convert.ToDecimal(_14avt.Text);
                else if (_14avt.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "10")
            {
                if (IsNumeric(_10fait.Text) == true)
                    _percentage = Convert.ToDecimal(_10fait.Text);
                else if (_10fait.Text == "N/A")
                    _percentage = -1;
            }


            return _percentage;
        }
        protected decimal per_com4()
        {

            decimal _percentage = 0;
            if (lblsch.Text == "13")
            {
                if (IsNumeric(_13ast.Text))
                    _percentage = Convert.ToDecimal(_13ast.Text);
            }
            else if (lblsch.Text == "32")
            {
                if (IsNumeric(_39sft.Text) == true)
                    _percentage = Convert.ToDecimal(_39sft.Text);
                else if (_39sft.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "29")
            {
                decimal _total = 0;
                int _qty = 0;
                int _count = Convert.ToInt32(_29noof.Text);

                if (_29cct.Text != "N/A")
                    _qty += 1;

                if (_29aft.Text != "N/A")
                    _qty += 1;

                if (_29vft.Text != "N/A")
                    _qty += 1;


                if (IsNumeric(_29cct.Text) == true)
                {
                    _total += (Convert.ToDecimal(_29cct.Text) / _count) * 100;
                }


                if (IsNumeric(_29aft.Text) == true)
                {
                    _total += (Convert.ToDecimal(_29aft.Text) / _count) * 100;
                }


                if (IsNumeric(_29vft.Text) == true)
                {
                    _total += (Convert.ToDecimal(_29vft.Text) / _count) * 100;
                }

                if (_qty > 0)
                    _percentage = (_total / _qty);
                else
                    _percentage = 100;

            }
            else if (lblsch.Text == "22")
            {
                if (IsNumeric(_22acs.Text) == true)
                    _percentage = Convert.ToDecimal(_22acs.Text);
            }
            else if (lblsch.Text == "11")
            {
                if (IsNumeric(_11phgt.Text) == true)
                    _percentage = Convert.ToDecimal(_11phgt.Text);
            }
            else if (lblsch.Text == "39")
            {
                if (IsNumeric(_39afts.Text) == true)
                    _percentage = Convert.ToDecimal(_39afts.Text);
                else if (_39afts.Text == "N/A")
                    _percentage = -1;
            }
            //else if (lblsch.Text == "34")
            //{
            //    if (DateValidation(_34ctc.Text) == true)
            //        _percentage = 1;
            //    else if (_34ctc.Text == "N/A")
            //        _percentage = -1;
            //}
            else if (lblsch.Text == "37")
            {
                if (IsNumeric(_37sot.Text))
                    _percentage = Convert.ToDecimal(_37sot.Text);
                else if (_37sot.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "15")
            {
                if (IsNumeric(_15mur.Text) == true)
                    _percentage = Convert.ToDecimal(_15mur.Text);
                else if (_15mur.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "14")
            {
                if (IsNumeric(_14drt.Text) == true)
                    _percentage = Convert.ToDecimal(_14drt.Text);
                else if (_14drt.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "10" || (lblprj.Text == "HMIM" && lblsch.Text == "28"))
            {
                if (IsNumeric(_10slt.Text) == true)
                    _percentage = Convert.ToDecimal(_10slt.Text);
                else if (_10slt.Text == "N/A")
                    _percentage = -1;
            }
            return _percentage;
        }
        protected decimal per_com5()
        {

            decimal _percentage = 0;
            if (lblsch.Text == "13")
            {
                if (IsNumeric(_13rbst.Text))
                    _percentage = Convert.ToDecimal(_13rbst.Text);
            }
            else if (lblsch.Text == "32")
            {
                if (IsNumeric(_39cft.Text) == true)
                    _percentage = Convert.ToDecimal(_39cft.Text);
                else if (_39cft.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "22")
            {
                if (IsNumeric(_22pft.Text) == true)
                    _percentage = Convert.ToDecimal(_22pft.Text);
            }
            else if (lblsch.Text == "39")
            {
                if (IsNumeric(_39ait.Text) == true)
                    _percentage = Convert.ToDecimal(_39ait.Text);
                else if (_39ait.Text == "N/A")
                    _percentage = -1;
            }
            //else if (lblsch.Text == "34")
            //{
            //    if (DateValidation(_34cct.Text) == true)
            //        _percentage = 1;
            //    else if (_34cct.Text == "N/A")
            //        _percentage = -1;
            //}
            else if (lblsch.Text == "37")
            {
                if (IsNumeric(_37ght.Text))
                    _percentage = Convert.ToDecimal(_37ght.Text);
                else if (_37ght.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "15")
            {
                if (IsNumeric(_15ftc.Text) == true)
                    _percentage = Convert.ToDecimal(_15ftc.Text);
                else if (_15ftc.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "14")
            {
                decimal _total = per_com1() + per_com2() + per_com3() + per_com4();
                decimal _qty = Convert.ToDecimal(_14noof.Text);
                _percentage = (_total / (_qty * 4)) * 100;
            }
            else if (lblsch.Text == "10" || (lblsch.Text == "28" && lblprj.Text=="HMIM"))
            {
                if (IsNumeric(_10bat.Text) == true)
                    _percentage = Convert.ToDecimal(_10bat.Text);
                else if (_10bat.Text == "N/A")
                    _percentage = -1;
            }
            return _percentage;
        }
        protected decimal per_com6()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "13")
            {
                decimal _total = per_com1() + per_com2() + per_com3() + per_com4() + per_com5();
                decimal _qty = Convert.ToDecimal(_13noof.Text);
                decimal _na = 0;
                if (_13cit.Text == "N/A") _na += 1;
                if (_13cvl.Text == "N/A") _na += 1;
                if (_13cvh.Text == "N/A") _na += 1;
                if (_13ast.Text == "N/A") _na += 1;
                if (_13rbst.Text == "N/A") _na += 1;
                if (_na < 5)
                    _percentage = (_total / (_qty * (5 - _na))) * 100;
            }
            if (lblsch.Text == "28")
            {
                if (lblprj.Text == "14211")
                {
                    decimal _total = 0;
                    decimal _count = 0;
                    if (_28cit.Text != "N/A")
                    {
                        _total += per_com1();
                        _count += 1;
                    }
                    if (_28ava.Text != "N/A")
                    {
                        _total += per_com2();
                        _count += 1;
                    }
                    if (_28avv.Text != "N/A")
                    {
                        _total += per_com3();
                        _count += 1;
                    }
                    if (_count > 0)
                        _percentage = (_total / _count) * 100;
                }
                else
                {
                    if (IsNumeric(_10cet.Text) == true)
                        _percentage = Convert.ToDecimal(_10cet.Text);
                    else if (_10cet.Text == "N/A")
                        _percentage = -1;
                }

            }
            else if (lblsch.Text == "22")
            {
                if (IsNumeric(_22it.Text) == true)
                    _percentage = Convert.ToDecimal(_22it.Text);
            }
            else if (lblsch.Text == "39")
            {
                if (IsNumeric(_39asot.Text) == true)
                    _percentage = Convert.ToDecimal(_39asot.Text);
                else if (_39asot.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "15")
            {
                if (IsNumeric(_15ems.Text) == true)
                    _percentage = Convert.ToDecimal(_15ems.Text);
                else if (_15ems.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "10")
            {
                if (IsNumeric(_10cet.Text) == true)
                    _percentage = Convert.ToDecimal(_10cet.Text);
                else if (_10cet.Text == "N/A")
                    _percentage = -1;
            }
            return _percentage;
        }
        protected decimal per_com7()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "22")
            {
                if (IsNumeric(_22phgt.Text) == true)
                    _percentage = Convert.ToDecimal(_22phgt.Text);
            }
            else if (lblsch.Text == "39")
            {
                if (IsNumeric(_39aght.Text) == true)
                    _percentage = Convert.ToDecimal(_39aght.Text);
                else if (_39aght.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "15")
            {
                if (IsNumeric(_15lsc.Text) == true)
                    _percentage = Convert.ToDecimal(_15lsc.Text);
                else if (_15lsc.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "10" || (lblprj.Text=="HMIM" && lblsch.Text=="28"))
            {
                if (IsNumeric(_10iet.Text) == true)
                    _percentage = Convert.ToDecimal(_10iet.Text);
                else if (_10iet.Text == "N/A")
                    _percentage = -1;
            }
            return _percentage;
        }
        protected decimal per_com8()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "22")
            {
                decimal _total = per_com1() + per_com2() + per_com3() + per_com4() + per_com5() + per_com6() + per_com7();
                decimal _qty = Convert.ToDecimal(_22noof.Text);
                decimal _na = 0;
                if (_22cit.Text == "N/A") _na += 1;
                if (_22apt.Text == "N/A") _na += 1;
                if (_22fat.Text == "N/A") _na += 1;
                if (_22acs.Text == "N/A") _na += 1;
                if (_22pft.Text == "N/A") _na += 1;
                if (_22it.Text == "N/A") _na += 1;
                if (_22phgt.Text == "N/A") _na += 1;
                if (_na < 7)
                    _percentage = (_total / (_qty * (7 - _na))) * 100;
            }
            else if (lblsch.Text == "15")
            {
                if (IsNumeric(_15bci.Text) == true)
                    _percentage = Convert.ToDecimal(_15bci.Text);
                else if (_15bci.Text == "N/A")
                    _percentage = -1;
            }
            return _percentage;
        }
        protected decimal per_com9()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "15")
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
                if (lblsch.Text == "30")
                {
                    _30ct.Text = row[24].ToString();
                    _30ft.Text = row[25].ToString();
                    _30accept1.Text = row["accept1"].ToString();
                    _30filed1.Text = row["filed1"].ToString();
                    _30commts.Text = row[18].ToString();
                    _30actby.Text = row[19].ToString();
                    _30actdt.Text = row[20].ToString();
                    SetCheckedBoxChecked(_30ct, chk_30ct);
                    SetCheckedBoxChecked(_30ft, chk_30ft);
                }
                else if (lblsch.Text == "13")
                {
                    _13cit.Text = row[24].ToString();
                    _13cvl.Text = row[25].ToString();
                    _13cvh.Text = row[26].ToString();
                    _13ast.Text = row[27].ToString();
                    _13rbst.Text = row[28].ToString();
                    _13accept1.Text = row["accept1"].ToString();
                    _13filed1.Text = row["filed1"].ToString();
                    _13commts.Text = row[18].ToString();
                    _13actby.Text = row[19].ToString();
                    _13actdt.Text = row[20].ToString();
                    _13noof.Text = row[21].ToString();
                    SetCheckedBoxChecked(_13cit, chk_13cit);
                    SetCheckedBoxChecked(_13cvl, chk_13cvl);
                    SetCheckedBoxChecked(_13cvh, chk_13cvh);
                    SetCheckedBoxChecked(_13ast, chk_13ast);
                    SetCheckedBoxChecked(_13accept1, chk_13accept1);
                    SetCheckedBoxChecked(_13filed1, chk_13filed1);
                    SetCheckedBoxChecked(_13actby, chk_13actby);
                    SetCheckedBoxChecked(_13actdt, chk_13actdt);

                    SetCheckedBoxChecked(_13rbst, chk_13rbst);
                }
                else if (lblsch.Text == "12" && lblprj.Text == "14211")
                {
                    _12ct.Text = row[24].ToString();
                    _12ft.Text = row[25].ToString();
                    _12accept1.Text = row["accept1"].ToString();
                    _12filed1.Text = row["filed1"].ToString();
                    _12commts.Text = row[18].ToString();
                    _12actby.Text = row[19].ToString();
                    _12actdt.Text = row[20].ToString();

                    SetCheckedBoxChecked(_12ct, chk_12ct);
                    SetCheckedBoxChecked(_12ft, chk_12ft);
                }
                else if (lblsch.Text == "12" && lblprj.Text == "HMIM")
                {
                    _12act.Text = row[24].ToString();
                    _12aaccept1.Text = row["accept1"].ToString();
                    _12afiled1.Text = row["filed1"].ToString();
                    _12acommts.Text = row[18].ToString();
                    _12aactby.Text = row[19].ToString();
                    _12aactdt.Text = row[20].ToString();
                    _12anop.Text = row[21].ToString();

                    SetCheckedBoxChecked(_12aactdt, chk_12aactdt);
                    SetCheckedBoxChecked(_12aaccept1, chk_12aaccept1);
                    SetCheckedBoxChecked(_12afiled1, chk_12afiled1);

                    //SetCheckedBoxChecked(_12commts, chk_12commts);
                    SetCheckedBoxChecked(_12aactby, chk_12aactby);
                    SetCheckedBoxChecked(_12aactdt, chk_12aactdt);
                    // SetCheckedBoxChecked(_12nop, chk_12nop);
                }
                else if (lblsch.Text == "32")
                {

                    _39ct.Text = row[24].ToString();
                    _39rft.Text = row[25].ToString();
                    _39aft.Text = row[26].ToString();
                    _39sft.Text = row[27].ToString();
                    _39cft.Text = row[28].ToString();

                    _39accept1.Text = row["accept1"].ToString();
                    _39filed1.Text = row["filed1"].ToString();

                    _39commts.Text = row[18].ToString();
                    _39actby.Text = row[19].ToString();
                    _39actdt.Text = row[20].ToString();
                    _39noof.Text = row[21].ToString();

                    SetCheckedBoxChecked(_39accept1, chk_39accept1);
                    SetCheckedBoxChecked(_39filed1, chk_39filed1);

                    SetCheckedBoxChecked(_39ct, chk_39ct);
                    SetCheckedBoxChecked(_39rft, chk_39rft);
                    SetCheckedBoxChecked(_39aft, chk_39aft);
                    SetCheckedBoxChecked(_39sft, chk_39sft);
                    SetCheckedBoxChecked(_39cft, chk_39cft);


                    SetCheckedBoxChecked(_39actby, chk_39actby);
                    SetCheckedBoxChecked(_39actdt, chk_39actdt);


                }
                else if (lblsch.Text == "31")
                {

                    _31ct.Text = row[24].ToString();
                    _31ft.Text = row[25].ToString();


                    _31accept1.Text = row["accept1"].ToString();
                    _31filed1.Text = row["filed1"].ToString();

                    _31commts.Text = row[18].ToString();
                    _31actby.Text = row[19].ToString();
                    _31actdt.Text = row[20].ToString();
                    _31noof.Text = row[21].ToString();

                    SetCheckedBoxChecked(_31accept1, chk_31accept1);
                    SetCheckedBoxChecked(_31filed1, chk_31filed1);

                    SetCheckedBoxChecked(_31ct, chk_31ct);
                    SetCheckedBoxChecked(_31ft, chk_31ft);


                    SetCheckedBoxChecked(_31actby, chk_31actby);
                    SetCheckedBoxChecked(_31actdt, chk_31actdt);




                }
                else if (lblsch.Text == "33")
                {

                    _33ct.Text = row[24].ToString();
                    _33ft.Text = row[25].ToString();


                    _33accept1.Text = row["accept1"].ToString();
                    _33filed1.Text = row["filed1"].ToString();

                    _33commts.Text = row[18].ToString();
                    _33actby.Text = row[19].ToString();
                    _33actdt.Text = row[20].ToString();
                    _33noof.Text = row[21].ToString();

                    SetCheckedBoxChecked(_33accept1, chk_33accept1);
                    SetCheckedBoxChecked(_33filed1, chk_33filed1);

                    SetCheckedBoxChecked(_33ct, chk_33ct);
                    SetCheckedBoxChecked(_33ft, chk_33ft);


                    SetCheckedBoxChecked(_33actby, chk_33actby);
                    SetCheckedBoxChecked(_33actdt, chk_33actdt);




                }
                else if (lblsch.Text == "29")
                {

                    _29cct.Text = row[24].ToString();
                    _29aft.Text = row[25].ToString();
                    _29vft.Text = row[26].ToString();


                    _29accept1.Text = row["accept1"].ToString();
                    _29filed1.Text = row["filed1"].ToString();

                    _29commts.Text = row[18].ToString();
                    _29actby.Text = row[19].ToString();
                    _29actdt.Text = row[20].ToString();
                    _29noof.Text = row[21].ToString();

                    SetCheckedBoxChecked(_29accept1, chk_29accept1);
                    SetCheckedBoxChecked(_29filed1, chk_29filed1);

                    SetCheckedBoxChecked(_29cct, chk_29cct);
                    SetCheckedBoxChecked(_29aft, chk_29aft);
                    SetCheckedBoxChecked(_29vft, chk_29vft);



                    SetCheckedBoxChecked(_39actby, chk_39actby);
                    SetCheckedBoxChecked(_39actdt, chk_39actdt);


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
                    SetCheckedBoxChecked(_22fat, chk_22fat);
                    SetCheckedBoxChecked(_22pft, chk_22pft);
                    SetCheckedBoxChecked(_22it, chk_22it);
                    SetCheckedBoxChecked(_22phgt, chk_22phgt);
                    SetCheckedBoxChecked(_22accept1, chk_22accept1);
                    SetCheckedBoxChecked(_22filed1, chk_22filed1);
                    //SetCheckedBoxChecked(_13commts, chk_13commts);
                    SetCheckedBoxChecked(_22actby, chk_22actby);
                    SetCheckedBoxChecked(_22actdt, chk_22actdt);
                    //SetCheckedBoxChecked(_13noof, chk_13noof);
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
                else if (lblsch.Text == "28")
                {
                    _28cit.Text = row[24].ToString();
                    _28ava.Text = row[25].ToString();
                    _28avv.Text = row[26].ToString();

                    _28accept1.Text = row["accept1"].ToString();
                    _28filed1.Text = row["filed1"].ToString();
                    _28commts.Text = row[18].ToString();
                    _28actby.Text = row[19].ToString();
                    _28actdt.Text = row[20].ToString();
                    _28noof.Text = row[21].ToString();

                    SetCheckedBoxChecked(_28cit, chk_28cit);
                    SetCheckedBoxChecked(_28ava, chk_28ava);
                    SetCheckedBoxChecked(_28avv, chk_28avv);

                    SetCheckedBoxChecked(_28accept1, chk_28accept1);
                    SetCheckedBoxChecked(_28filed1, chk_28filed1);

                    //SetCheckedBoxChecked(_28commts, chk_28commts);
                    SetCheckedBoxChecked(_28actby, chk_28actby);
                    SetCheckedBoxChecked(_28actdt, chk_28actdt);
                }
                else if (lblsch.Text == "39")
                {
                    _39adt.Text = row[24].ToString();
                    _39aci.Text = row[25].ToString();
                    _39acit.Text = row[26].ToString();
                    _39afts.Text = row[27].ToString();
                    _39ait.Text = row[28].ToString();
                    _39asot.Text = row[29].ToString();
                    _39aght.Text = row[30].ToString();



                    _39aaccept1.Text = row["accept1"].ToString();
                    _39afiled1.Text = row["filed1"].ToString();
                    _39acommts.Text = row[18].ToString();
                    _39aactby.Text = row[19].ToString();
                    _39aactdt.Text = row[20].ToString();

                    _39aaccept2.Text = row["accept2"].ToString();
                    _39afiled2.Text = row["filed2"].ToString();




                    SetCheckedBoxChecked(_39adt, chk_39adt);
                    SetCheckedBoxChecked(_39acit, chk_39aci);
                    SetCheckedBoxChecked(_39acit, chk_39acit);
                    SetCheckedBoxChecked(_39afts, chk_39afts);
                    SetCheckedBoxChecked(_39ait, chk_39ait);
                    SetCheckedBoxChecked(_39asot, chk_39asot);
                    SetCheckedBoxChecked(_39aght, chk_39aght);


                    SetCheckedBoxChecked(_39aaccept1, chk_39aaccept1);
                    SetCheckedBoxChecked(_39afiled1, chk_39afiled1);

                    SetCheckedBoxChecked(_39aaccept2, chk_39aaccept2);
                    SetCheckedBoxChecked(_39afiled2, chk_39afiled2);


                }
                else if (lblsch.Text == "34")
                {
                    //_34pt.Text = row[24].ToString();
                    //_34lbt.Text = row[25].ToString();
                    //_34cft.Text = row[26].ToString();
                    //_34ctc.Text = row[27].ToString();
                    //_34cct.Text = row[28].ToString();
                    //_34sof.Text = row[29].ToString();
                    //;



                    //_34accept1.Text = row["accept1"].ToString();
                    //_34filed1.Text = row["filed1"].ToString();
                    //_34commts.Text = row[18].ToString();
                    //_34actby.Text = row[19].ToString();
                    //_34actdt.Text = row[20].ToString();

                    //_34accept2.Text = row["accept2"].ToString();
                    //_34filed2.Text = row["filed2"].ToString();


                    //_34accept3.Text = row["tested1"].ToString();
                    //_34filed3.Text = row["tested2"].ToString();



                    //SetCheckedBoxChecked(_34pt, chk_34pt);
                    //SetCheckedBoxChecked(_34lbt, chk_34lbt);
                    //SetCheckedBoxChecked(_34cft, chk_34cft);
                    //SetCheckedBoxChecked(_34ctc, chk_34ctc);
                    //SetCheckedBoxChecked(_34cct, chk_34cct);
                    //SetCheckedBoxChecked(_34sof, chk_34sof);
                    ////SetCheckedBoxChecked(_34aght, chk_34aght);


                    //SetCheckedBoxChecked(_34accept1, chk_34accept1);
                    //SetCheckedBoxChecked(_34filed1, chk_34filed1);

                    //SetCheckedBoxChecked(_34accept2, chk_34accept2);
                    //SetCheckedBoxChecked(_34filed2, chk_34filed2);

                    //SetCheckedBoxChecked(_34accept3, chk_34accept3);
                    //SetCheckedBoxChecked(_34filed3, chk_34filed3);


                    _34pc.Text = row[24].ToString();
                    _34lb.Text = row[25].ToString();
                    _34ucf.Text = row[26].ToString();

                    _34accept1.Text = row[27].ToString();
                    _34filed1.Text = row[28].ToString();
                    _34cable.Text = row[29].ToString();
                    _34sol.Text = row[30].ToString();
                    _34accept2.Text = row["accept1"].ToString();
                    _34filed2.Text = row["filed1"].ToString();
                    _34accept3.Text = row["accept2"].ToString();
                    _34filed3.Text = row["filed2"].ToString();
                    _34commts.Text = row[18].ToString();
                    _34actby.Text = row[19].ToString();
                    _34actdt.Text = row[20].ToString();


                    SetCheckedBoxChecked(_34pc, chk_34pc);
                    SetCheckedBoxChecked(_34ucf, chk_34ucf);
                    SetCheckedBoxChecked(_34lb, chk_34lb);
                    SetCheckedBoxChecked(_34accept1, chk_34accept1);
                    SetCheckedBoxChecked(_34filed1, chk_34filed1);
                    SetCheckedBoxChecked(_34filed2, chk_34filed2);
                    SetCheckedBoxChecked(_34filed3, chk_34filed3);
                    SetCheckedBoxChecked(_34cable, chk_34cable);
                    SetCheckedBoxChecked(_34sol, chk_34sol);
                    SetCheckedBoxChecked(_34accept2, chk_34accept2);
                    SetCheckedBoxChecked(_34accept3, chk_34accept3);

                    SetCheckedBoxChecked(_34actby, chk_34actby);
                    SetCheckedBoxChecked(_34actdt, chk_34actdt);

                }
                else if (lblsch.Text == "37")
                {
                    _37ct.Text = row[24].ToString();
                    _37ft.Text = row[25].ToString();
                    _37it.Text = row[26].ToString();
                    _37sot.Text = row[27].ToString();
                    _37ght.Text = row[28].ToString();


                    _37accept1.Text = row["accept1"].ToString();
                    _37filed1.Text = row["filed1"].ToString();
                    _37accept2.Text = row["accept2"].ToString();
                    _37filed2.Text = row["filed2"].ToString();
                    _37commts.Text = row[18].ToString();
                    _37actby.Text = row[19].ToString();
                    _37actdt.Text = row[20].ToString();

                    _37points.Text = row["devices3"].ToString();
                    _37devices.Text = row["devices2"].ToString();
                    _37system.Text = row["devices1"].ToString();

                    SetCheckedBoxChecked(_37ct, chk_37ct);
                    SetCheckedBoxChecked(_37ft, chk_37ft);
                    SetCheckedBoxChecked(_37it, chk_37it);
                    SetCheckedBoxChecked(_37sot, chk_37sot);
                    SetCheckedBoxChecked(_37ght, chk_37ght);

                    SetCheckedBoxChecked(_37accept1, chk_37accept1);
                    SetCheckedBoxChecked(_37accept2, chk_37accept2);

                    SetCheckedBoxChecked(_37filed1, chk_37filed1);
                    SetCheckedBoxChecked(_37filed2, chk_37filed2);


                    SetCheckedBoxChecked(_37actby, chk_37actby);



                }
                else if (lblsch.Text == "35")
                {
                    _35pwron.Text = row[14].ToString();
                    _35pc1.Text = row[24].ToString();
                    _35co1.Text = row[25].ToString();
                    _35wd1.Text = row[26].ToString();
                    _35pc2.Text = row[27].ToString();
                    _35co2.Text = row[28].ToString();
                    _35wd2.Text = row[29].ToString();

                    _35accept1.Text = row["accept1"].ToString();
                    _35filed1.Text = row["filed1"].ToString();
                    _35commts.Text = row[18].ToString();
                    _35actby.Text = row[19].ToString();
                    _35actdt.Text = row[20].ToString();

                    SetCheckedBoxChecked(_35pc1, chk_35pc1);
                    SetCheckedBoxChecked(_35co1, chk_35co1);
                    SetCheckedBoxChecked(_35wd1, chk_35wd1);
                    SetCheckedBoxChecked(_35pc2, chk_35pc2);
                    SetCheckedBoxChecked(_35co2, chk_35co2);


                    SetCheckedBoxChecked(_35accept1, chk_35accept1);
                    SetCheckedBoxChecked(_35filed1, chk_35filed1);
                    SetCheckedBoxChecked(_35wd2, chk_35wd2);

                    //SetCheckedBoxChecked(_35commts, chk_35commts);
                    SetCheckedBoxChecked(_35actby, chk_35actby);
                    SetCheckedBoxChecked(_35actdt, chk_35actdt);


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


                    SetCheckedBoxChecked(_14cit, chk_14cit);
                    SetCheckedBoxChecked(_14diab, chk_14diab);
                    SetCheckedBoxChecked(_14avt, chk_14avt);
                    SetCheckedBoxChecked(_14drt, chk_14drt);
                    SetCheckedBoxChecked(_14accept1, chk_14accept1);
                    SetCheckedBoxChecked(_14filed1, chk_14filed1);

                    //SetCheckedBoxChecked(_14commts, chk_14commts);
                    SetCheckedBoxChecked(_14actby, chk_14actby);
                    SetCheckedBoxChecked(_14actdt, chk_14actdt);
                    //SetCheckedBoxChecked(_14noof, chk_14noof);

                }
                else if (lblsch.Text == "9")
                {
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

                    SetCheckedBoxChecked(_9aa, chk_9aa);
                    SetCheckedBoxChecked(_9dtp, chk_9dtp);
                    SetCheckedBoxChecked(_9rp, chk_9rp);
                    SetCheckedBoxChecked(_9moo, chk_9moo);
                    SetCheckedBoxChecked(_9sro, chk_9sro);
                    SetCheckedBoxChecked(_9est, chk_9est);
                    SetCheckedBoxChecked(_9psrt, chk_9psrt);
                    SetCheckedBoxChecked(_9accept1, chk_9accept1);
                    SetCheckedBoxChecked(_9filed1, chk_9filed1);

                    //SetCheckedBoxChecked(_9commts, chk_9commts);
                    SetCheckedBoxChecked(_9actby, chk_9actby);
                    SetCheckedBoxChecked(_9actdt, chk_9actdt);



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
                    _10iet.Text = row["test12"].ToString();
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
                    SetCheckedBoxChecked(_10iet, chk_10iet);

                }
                else if (lblsch.Text == "27")
                {
                    _27tc.Text = row[24].ToString();
                    _27tpi.Text = row[25].ToString();
                    _27eml.Text = row[26].ToString();
                    _27pfm.Text = row[27].ToString();
                    _27lms.Text = row[28].ToString();
                    _27int.Text = row[29].ToString();
                    _27bfa.Text = row[30].ToString();
                    _27accept1.Text = row["accept1"].ToString();
                    _27filed1.Text = row["filed1"].ToString();
                    _27commts.Text = row[18].ToString();
                    _27actby.Text = row[19].ToString();
                    _27actdt.Text = row[20].ToString();

                    SetCheckedBoxChecked(_27tc, chk_27tc);
                    SetCheckedBoxChecked(_27tpi, chk_27tpi);
                    SetCheckedBoxChecked(_27eml, chk_27eml);
                    SetCheckedBoxChecked(_27pfm, chk_27pfm);
                    SetCheckedBoxChecked(_27lms, chk_27lms);
                    SetCheckedBoxChecked(_27int, chk_27int);
                    SetCheckedBoxChecked(_27bfa, chk_27bfa);

                    SetCheckedBoxChecked(_27accept1, chk_27accept1);
                    SetCheckedBoxChecked(_27filed1, chk_27filed1);

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

        protected void _30btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _30ct.Text, _30ft.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", _30accept1.Text, "", _30filed1.Text, "", _30commts.Text, _30actby.Text, _30actdt.Text);
            btnDummy_ModalPopupExtender7.Hide();
        }

        protected void _30btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender7.Hide();
        }
        protected void _12btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _12ct.Text, _12ft.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", _12accept1.Text, "", _12filed1.Text, "", _12commts.Text, _12actby.Text, _12actdt.Text);
            ModalPopupExtender1.Hide();
        }

        protected void _12btncancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }

        protected void _13btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _13cit.Text, _13cvl.Text, _13cvh.Text, _13ast.Text, _13rbst.Text, "", "", "", "", "", "", "", "", "", "", "", "", _13accept1.Text, "", _13filed1.Text, "", _13commts.Text, _13actby.Text, _13actdt.Text);
            btnDummy_ModalPopupExtender15.Hide();
        }

        protected void _13btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender15.Hide();
        }

        protected void _22btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _22cit.Text, _22apt.Text, _22fat.Text, _22acs.Text, _22pft.Text, _22it.Text, _22phgt.Text, "", "", "", "", "", "", "", "", "", _22noof.Text, _22accept1.Text, "", _22filed1.Text, "", _22commts.Text, _22actby.Text, _22actdt.Text);
            btnDummy_ModalPopupExtender16.Hide();
        }

        protected void _22btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender16.Hide();
        }
        protected void _39btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _39ct.Text, _39rft.Text, _39aft.Text, _39sft.Text, _39cft.Text, "", "", "", "", "", "", "", "", "", "", "", _39noof.Text, _39accept1.Text, "", _39filed1.Text, "", _39commts.Text, _39actby.Text, _39actdt.Text);
            btnDummy_ModalPopupExtender39.Hide();
        }

        protected void _39btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender39.Hide();
        }
        protected void _31btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _31ct.Text, _31ft.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", _31noof.Text, _31accept1.Text, "", _31filed1.Text, "", _31commts.Text, _31actby.Text, _31actdt.Text);
            btnDummy_ModalPopupExtender31.Hide();
        }

        protected void _31btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender31.Hide();
        }
        protected void _33btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _33ct.Text, _33ft.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", _33noof.Text, _33accept1.Text, "", _33filed1.Text, "", _33commts.Text, _33actby.Text, _33actdt.Text);
            btnDummy_ModalPopupExtender33.Hide();
        }

        protected void _33btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender33.Hide();
        }
        protected void _29btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _29cct.Text, _29aft.Text, _29vft.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", _29noof.Text, _29accept1.Text, "", _29filed1.Text, "", _29commts.Text, _29actby.Text, _29actdt.Text);
            btnDummy_ModalPopupExtender29.Hide();
        }

        protected void _29btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender29.Hide();
        }

        protected void _11btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _11cit.Text, _11lct.Text, _11apt.Text, _11phgt.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", _11accept1.Text, "", _11filed1.Text, "", _11commts.Text, _11actby.Text, _11actdt.Text);
            btnDummy_ModalPopupExtender17.Hide();
        }

        protected void _11btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender17.Hide();
        }
        protected void _28btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _28cit.Text, _28ava.Text, _28avv.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", _28noof.Text, _28accept1.Text, "", _28filed1.Text, "", _28commts.Text, _28actby.Text, _28actdt.Text);
            btnDummy_ModalPopupExtender28.Hide();
        }

        protected void _28btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender28.Hide();
        }
        protected void _39abtnupdate_Click(object sender, EventArgs e)
        {
            Update("", _39adt.Text, _39aci.Text, _39acit.Text, _39afts.Text, _39ait.Text, _39asot.Text, _39aght.Text, "", "", "", "", "", "", "", "", "", "", _39aaccept1.Text, _39aaccept2.Text, _39afiled1.Text, _39afiled2.Text, _39acommts.Text, _39aactby.Text, _39aactdt.Text);
            btnDummy_ModalPopupExtender39a.Hide();
        }

        protected void _39abtncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender39a.Hide();
        }
        //protected void _34btnupdate_Click(object sender, EventArgs e)
        //{
        //    Update("", _34pt.Text, _34lbt.Text, _34cft.Text, _34ctc.Text, _34cct.Text, _34sof.Text, "", "", "", "", "", "", _34accept3.Text,_34filed3.Text, "", "", "", _34accept1.Text, _34accept2.Text, _34filed1.Text, _34filed2.Text, _34commts.Text, _34actby.Text, _34actdt.Text);
        //    btnDummy_ModalPopupExtender34.Hide();
        //}

        //protected void _34btncancel_Click(object sender, EventArgs e)
        //{
        //    btnDummy_ModalPopupExtender34.Hide();
        //}
        protected void _37btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _37ct.Text, _37ft.Text, _37it.Text, _37sot.Text, _37ght.Text, "", "", "", "", "", "", "", "", "", "", "", "", _37accept1.Text, _37accept2.Text, _37filed1.Text, _37filed2.Text, _37commts.Text, _37actby.Text, _37actdt.Text);
            btnDummy_ModalPopupExtender14.Hide();
        }
        protected void _37btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender14.Hide();
        }
        protected void _35btnupdate_Click(object sender, EventArgs e)
        {
            Update(_35pwron.Text, _35pc1.Text, _35co1.Text, _35wd1.Text, _35pc2.Text, _35co2.Text, _35wd2.Text, "", "", "", "", "", "", "", "", "", "", "", _35accept1.Text, "", _35filed1.Text, "", _35commts.Text, _35actby.Text, _35actdt.Text);
            btnDummy_ModalPopupExtender35.Hide();
        }

        protected void _35btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender35.Hide();
        }
        protected void _34btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _34pc.Text, _34lb.Text, _34ucf.Text, _34accept1.Text, _34filed1.Text, _34cable.Text, _34sol.Text, "", "", "", "", "", "", "", "", "", "", _34accept2.Text, _34accept3.Text, _34filed2.Text, _34filed3.Text, _34commts.Text, _34actby.Text, _34actdt.Text);
            btnDummy_ModalPopupExtender34.Hide();
        }

        protected void _34btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender34.Hide();
        }
        protected void _15btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _15cit.Text, _15kca.Text, _15dnd.Text, _15mur.Text, _15ftc.Text, _15ems.Text, _15lsc.Text, _15bci.Text, _15mif.Text, "", "", "", "", "", "", "", "", _15accept1.Text, "", _15filed1.Text, "", _15commts.Text, _15actby.Text, _15actdt.Text);
            btnDummy_ModalPopupExtender19.Hide();
        }
        protected void _15btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender19.Hide();
        }
        protected void _12abtnupdate_Click(object sender, EventArgs e)
        {
            Update("", _12act.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", _12anop.Text, _12aaccept1.Text, "", _12afiled1.Text, "", _12acommts.Text, _12aactby.Text, _12aactdt.Text);
            btnDummy_ModalPopupExtender18.Hide();
        }

        protected void _12abtncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender18.Hide();
        }
        protected void _14btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _14cit.Text, _14diab.Text, _14avt.Text, _14drt.Text, "", "", "", "", "", "", "", "", "", "", "", "", _14noof.Text, _14accept1.Text, "", _14filed1.Text, "", _14commts.Text, _14actby.Text, _14actdt.Text);
            btnDummy_ModalPopupExtender20.Hide();
        }
        protected void _14btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender20.Hide();


        }
        protected void _9btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _9aa.Text, _9dtp.Text, _9rp.Text, _9moo.Text, _9sro.Text, _9est.Text, _9psrt.Text, "", "", "", "", "", "", "", "", "", "", _9accept1.Text, "", _9filed1.Text, "", _9commts.Text, _9actby.Text, _9actdt.Text);
            btnDummy_ModalPopupExtender9.Hide();
        }
        protected void _9btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender9.Hide();
        }
        protected void _10btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _10ccit.Text, _10ndt.Text, _10dtc.Text, _10fait.Text, _10ltc.Text, _10slt.Text, _10bat.Text, _10ghet.Text, _10cet.Text, _10iet.Text, "", "", "", "", "", "", _10interface.Text, _10accept1.Text, _10accept2.Text, _10filed1.Text, _10filed2.Text, _10commts.Text, _10actby.Text, _10actdt.Text);
            btnDummy_ModalPopupExtender13.Hide();
        }

        protected void _10btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender13.Hide();
        }
        protected void _27btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _27tc.Text, _27tpi.Text, _27eml.Text, _27pfm.Text, _27lms.Text, _27int.Text, _27bfa.Text, "", "", "", "", "", "", "", "", "", "", _27accept1.Text, "", _27filed1.Text, "", _27commts.Text, _27actby.Text, _27actdt.Text);
            btnDummy_ModalPopupExtender27.Hide();
        }

        protected void _27btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender27.Hide();
        }


    }
}
