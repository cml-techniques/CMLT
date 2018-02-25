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

namespace CmlTechniques.CAS
{
    public partial class Cas_Entry : System.Web.UI.Page
    {

        public static DataTable _dtMaster;
        //public static DataTable _dtfilter;
        public static DataTable _dtresult;
        public static bool _exp;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                //string _prm = Request.QueryString[0].ToString();
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _prm + "');", true);
                //Session["project"] = _prm.Substring(0, _prm.IndexOf("_S"));
                //Session["sch"] = _prm.Substring(_prm.IndexOf("_S") + 2);
                string _prm = Request.QueryString[0].ToString();
                lblprj.Text = _prm.Substring(0, _prm.IndexOf("_S"));
                lblsch.Text = _prm.Substring(_prm.IndexOf("_S") + 2);
                Session["project"] = lblprj.Text;
                Session["sch"] = lblsch.Text;
                settings();
                Load_Panels();
                load_cas_sys();
                Load_Master();
                Session["filter"] = "no";
                Session["zone"] = "All";
                Session["flvl"] = "All";
                Session["cat"] = "All";
                Session["fed"] = "All";
                Session["loc"] = "All";
                Session["des"] = "All";
                Load_InitialData();
                //Load_Filtering_Elements();
                Load_Flvl();
                Hide_Details();

                _exp = false;
            }
        }
        private void Load_Panels()
        {
            drpanel.Items.Clear();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();
            _objcls.sch = Convert.ToInt32(lblsch.Text);
            drpanel.DataSource = _objbll.load_cas_panel(_objcls, _objdb);
            drpanel.DataTextField = "Panel_ref";
            drpanel.DataValueField = "Panel_id";
            drpanel.DataBind();
            drpanel.Items.Insert(0, "-- Select --");
        }
        protected void load_cas_sys()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcls = new _clscassheet();
            _objcls.sch = Convert.ToInt32((string)Session["sch"]);
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
        protected void settings()
        {
            if ((string)Session["sch"] == "5" || (string)Session["sch"] == "1")
            {
                lbnum.Text = "NO.OF CIRCUITS";
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "CAS 1D LV Electrical Services Commissioning Activity Schedule";
                    lbl2.Text = "SUBSTATION NUMBER";
                    td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                }
                else
                {
                    lblhead.Text = "CAS E4 Electrical Services. LV Commissioning Activity Schedule";
                    td_2.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                }

            }
            else if ((string)Session["sch"] == "2")
            {
                //lbnum.Text = "";
                //lbnum.Enabled = false;
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "SUBSTATION";
                lbl3.Text = "FED FROM";
                txtnoof.Visible = false;
                if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "CAS 1A MV Electrical Services Commissioning Activity Schedule";
                    td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                    txtnoof.Visible = true;
                    lbl2.Text = "SUBSTATION NUMBER";
                    lbnum.Text = "TOTAL NO.OF CIRCUITS";
                }
                else
                {
                    lblhead.Text = "CAS E1 Electrical Services. HV-MV Switchgear & RMU Commissioning Activity Schedule";
                    td_3.Visible = false; td_lbnum.Visible = false; td_txtnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                }
            }
            else if ((string)Session["sch"] == "3")
            {
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "AREA";
                lbl3.Text = "FED FROM";

                if ((string)Session["project"] == "CCAD")
                {
                    lbl2.Text = "SUB STATION NUMBER";
                    lblhead.Text = "CAS 1C TX Electrical Services Commissioning Activity Schedule";
                    lbnum.Text = "QUANTITY";
                }
                else
                {
                    lblhead.Text = "CAS E2 Electrical Services. HV & MV Transformers Commissioning Activity Schedule";
                    txtnoof.Visible = false;
                    td_3.Visible = false; td_lbnum.Visible = false; td_txtnum.Visible = false;
                }
                td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
            }
            else if ((string)Session["sch"] == "4")
            {
                lbnum.Text = "";
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                td_2.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_lbnum.Visible = false; td_txtdes.Visible = false; td_txtnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                if ((string)Session["project"] == "CCAD")
                    lblhead.Text = "CAS 1B Generator Commissioning Activity Schedule";
                else
                    lblhead.Text = "CAS E5 Electrical Services. Generator Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "6")
            {
                lbnum.Text = "";
                lbl1.Text = "PROVIDES EARTHING/LIGHTNING PROTECTION TO";
                lbl2.Text = "";
                lbl3.Text = "";
                txtfedfr.Visible = false;
                txtdesc.Visible = false;
                txtnoof.Visible = false;
                drfed.Style.Add("display", "none");
                if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "CAS 1F Earthing & Lightning Protection Commissioning Activity Schedule";
                    lbl1.Text = "PROVIDES EARTHING TO";
                }
                else
                    lblhead.Text = "CAS E3 Electrical Services. Earthing & Lightning Protection Commissioning Activity Schedule";
                td_2.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_lbnum.Visible = false; td_txtdes.Visible = false; td_txtnum.Visible = false; td_1.Visible = false; td_txtfed.Visible = false; td_lbl3.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
            }
            else if ((string)Session["sch"] == "7")
            {
                lbnum.Text = "NO.OF EMERGENCY LIGHTS";
                lbl1.Text = "";
                lbl3.Text = "";
                lbl2.Text = "";

                if ((string)Session["project"] == "CCAD")
                {
                    lbl1.Text = "PROVIDES POWER TO";
                    lbl3.Text = "FED FROM";
                    lbnum.Text = "NO.OF LAMPS";
                    lbl2.Text = "TOTAL NO.OF CIRCUITS";
                    lblhead.Text = "CAS 1E Central Battery System Commissioning Activity Schedule";
                    td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                }
                else
                {
                    drfed.Style.Add("display", "none");
                    lblhead.Text = "CAS E6 Electrical Services. Emergency Lighting Commissioning Activity Schedule";
                    td_2.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_1.Visible = false; td_txtfed.Visible = false; td_lbl3.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                }
            }
            else if ((string)Session["sch"] == "8")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                txtpprovideto.Visible = false;
                txtnoof.Visible = false;
                if ((string)Session["project"] == "ASAO")
                {
                    lblhead.Text = "CAS M9 Fuel Systems Commissioning Activity Schedule";
                    td_0.Visible = false; td_txtnum.Visible = false; td_lbnum.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                }
                else if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "CAS 2B Mechanical Services Commissioning Activity Schedule";
                    td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                    lbnum.Text = "Design Volume (l/s)";
                    txtnoof.Visible = true;
                }
                else
                {
                    lblhead.Text = "CAS M1 Mechanical Services Commissioning Activity Schedule";
                    td_0.Visible = false; td_txtnum.Visible = false; td_lbnum.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                }


            }
            else if ((string)Session["sch"] == "24")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";

                if ((string)Session["project"] == "ASAO")
                {
                    lblhead.Text = "CAS MISC3 - Kitchen Equipments Commissioning Activity Schedule";
                    td_0.Visible = false; td_txtnum.Visible = false; td_lbnum.Visible = false; txtnoof.Visible = false;

                }
                else if ((string)Session["project"] == "CCAD")
                {
                    lbl3.Text = "AREA COVERED";
                    lbnum.Text = "NO.OF PANEL";
                    lblhead.Text = "CAS 3K - ELV - Nurse Call(NC) System Commissioning Activity Schedule";
                    td_txtdescr.Visible = false; td_lbldes.Visible = false; tddes.Visible = false;
                }
                else
                {
                    lblhead.Text = "CAS MISC2 - Kitchen & Laundry Equipments Commissioning Activity Schedule";
                    td_0.Visible = false; td_txtnum.Visible = false; td_lbnum.Visible = false; txtnoof.Visible = false;

                }
                td_lbl1.Visible = false; td_txtppt.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "25")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                txtpprovideto.Visible = false;
                if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "CAS 3L - ELV - Clock System Commissioning Activity Schedule";
                    lbnum.Text = "NO.OF CODE BLUE/ ELAPSED TIMERS";
                    td_txtdescr.Visible = false; td_lbldes.Visible = false; tddes.Visible = false; td_lbl3.Visible = false; td_txtfed.Visible = false; td_1.Visible = false;
                }
                else
                {
                    lblhead.Text = "CAS M2 Air Conditioned System Commissioning Activity Schedule";
                    td_0.Visible = false; td_txtnum.Visible = false; td_lbnum.Visible = false; txtnoof.Visible = false;

                }
                td_lbl1.Visible = false; td_txtppt.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "17")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                txtpprovideto.Visible = false;
                if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "CAS 4A - Plumbing and Public Health Services Commissioning Activity Schedule";
                    lbnum.Text = "DESIGN VOLUME l/s";
                }
                else
                {
                    lblhead.Text = "CAS PH1 Public Health Services Commissioning Activity Schedule";
                    td_txtnum.Visible = false; td_lbnum.Visible = false; td_3.Visible = false;
                }

                td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "27")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                txtpprovideto.Visible = false;
                if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "CAS 5A - Miscelleaneous System Commissioning Activity Schedule";
                    lbnum.Text = "NO.OF POINTS";
                    td_lbl3.Visible = false; td_txtfed.Visible = false; td_1.Visible = false;
                }
                else
                {
                    lblhead.Text = "CAS M6 Fire Fighting Pumps Commissioning Activity Schedule";
                    td_0.Visible = false; td_txtnum.Visible = false; td_lbnum.Visible = false;
                }

                td_lbl1.Visible = false; td_txtppt.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "9")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "";

                if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "CAS 2B Motorised Fire and Smoke Damper Testing Commissioning Activity Schedule";
                    td_txtnum.Visible = false; td_lbnum.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                    lbdes.Text = "DESCRIPTION/ SIZE";
                    lbloc.Text = "LOCATION AREA";
                    lbl3.Text = "PLANT/ SYSTEM REFERENCE";
                    lbl1.Text = "PLANT/ SYSTEM DESCRIPTION";
                    //lbnum.Text = "Design Volume (l/s)";
                    //txtnoof.Visible = true;
                }
                else
                {
                    drfed.Style.Add("display", "none");
                    lblhead.Text = "CAS M3 Fusible Link Fire Dampers & MSFD Commissioning Activity Schedule";
                    td_0.Visible = false; td_txtnum.Visible = false; td_lbnum.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_3.Visible = false; td_txtfed.Visible = false; td_lbl3.Visible = false; td_1.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                }
            }
            else if ((string)Session["sch"] == "10")
            {
                lbl1.Text = "";
                lbl2.Text = "NO.OF DEVICES";
                lbl3.Text = "";
                lbnum.Text = "NO.OF INTERFACES";
                drfed.Style.Add("display", "none");
                if ((string)Session["project"] == "CCAD" || (string)Session["project"] == "trial")
                {
                    lblhead.Text = "6.2.1 - Fire Alarm and Fire Telephone Comunication Systems Commissioning Activity Schedule";
                    lbl1.Text = "LOOP CIRCUIT NO.";
                }
                else
                {
                    lblhead.Text = "CAS ELV1 Fire Alarm & Voice Evacuation Commissioning Activity Schedule";
                    td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false;
                }
                td_lbl3.Visible = false; td_txtfed.Visible = false; td_1.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false; td_lbldes.Visible = false;
            }
            else if ((string)Session["sch"] == "31")
            {
                lbl1.Text = "";
                lbl2.Text = "NO.OF DEVICES";
                lbl3.Text = "";
                lbnum.Text = "NO.OF INTERFACES";
                drfed.Style.Add("display", "none");
                lblhead.Text = "CAS ELV1 PABGM Commissioning Activity Schedule";
                td_lbl3.Visible = false; td_txtfed.Visible = false; td_1.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
            }
            else if ((string)Session["sch"] == "11")
            {
                lbloc.Text = "AREA SERVED";
                lbl2.Text = "NO.OF CIRCUITS";
                lbnum.Text = "NO.OF LIGHTING SCENES";
                drfed.Style.Add("display", "none");
                if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "6.2.10 - Public Address and Mass Notification System Commissioning Activity Schedule";
                    lbloc.Text = "LOCATION";
                    lbnum.Text = "NO.OF DEVICES PER CIRCUIT";
                    td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                }
                else
                    lblhead.Text = "CAS ELV5 Lighting Control System Commissioning Activity Schedule";
                td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                td_lbl3.Visible = false;
                td_txtfed.Visible = false;
                td_1.Visible = false;
                td_lbl1.Visible = false;
                td_txtppt.Visible = false;
                td_0.Visible = false;
            }
            else if ((string)Session["sch"] == "12")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "CONNECTED FROM";
                lbnum.Text = "NO.OF POINTS";
                if ((string)Session["project"] == "ASAO")
                    lblhead.Text = "CAS ELV6 Passive Data Network Commissioning Activity Schedule";
                else if ((string)Session["project"] == "CCAD")
                    lblhead.Text = "CAS 3F - ELV - Structured Cabling Network(SCN) Commissioning Activity Schedule";
                else
                    lblhead.Text = "CAS ELV6 Structured Cabling Network Commissioning Activity Schedule";
                td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                td_lbl1.Visible = false;
                td_txtppt.Visible = false;
                td_0.Visible = false;
                td_lbl2.Visible = false;
                td_txtdes.Visible = false;
                td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "13")
            {


                drfed.Style.Add("display", "none");
                if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "CAS 3H - ELV - Closed Circuit Television(CCTV) System Commissioning Activity Schedule";
                    lbl3.Text = "AREA MONITORED";
                    lbnum.Text = "NO.OF POINTS/ CAMERAS";
                }
                else
                {
                    lblhead.Text = "CAS ELV3 Closed Circuit Television Commissioning Activity Schedule";
                    lbloc.Text = "SYSTEMS MONITORED";
                    td_lbl3.Visible = false;
                    td_txtfed.Visible = false;
                    td_1.Visible = false;
                    lbnum.Text = "NO.OF CAMERAS";
                }
                td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                td_lbl1.Visible = false;
                td_txtppt.Visible = false;
                td_0.Visible = false;
                td_lbl2.Visible = false;
                td_txtdes.Visible = false;
                td_2.Visible = false;

            }
            else if ((string)Session["sch"] == "14")
            {

                drfed.Style.Add("display", "none");

                if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "CAS 3J - ELV - Audio Visual(AV) System Commissioning Activity Schedule";
                    lbnum.Text = "NO.OF CIRCUITS";
                }
                else
                {
                    lblhead.Text = "CAS ELV8 Audio-Visual Intercom Commissioning Activity Schedule";
                    lbnum.Text = "NO.OF PANELS"; drloc.Style.Add("display", "none");
                    td_lbl0.Visible = false;
                    td_txtloc.Visible = false;
                    td0.Visible = false;
                }
                td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                td_lbl3.Visible = false;
                td_txtfed.Visible = false;
                td_1.Visible = false;
                td_lbl1.Visible = false;
                td_txtppt.Visible = false;
                td_0.Visible = false;
                td_lbl2.Visible = false;
                td_txtdes.Visible = false;
                td_2.Visible = false;


            }
            else if ((string)Session["sch"] == "15")
            {
                lbnum.Text = "NO.OF PANELS";
                drfed.Style.Add("display", "none");
                drloc.Style.Add("display", "none");
                if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "CAS 3G - ELV - Satellite Master Antenna Television(SMATV) System Commissioning Activity Schedule";
                    lbnum.Text = "NO.OF POINTS PER OUTLET";
                    lbl1.Text = "AREA COVERED";
                    lbl3.Text = "FED FROM";
                }
                else
                {
                    lblhead.Text = "CAS ELV7 Guest Room Management System Commissioning Activity Schedule";
                    td_lbl1.Visible = false;
                    td_txtppt.Visible = false;
                    td_0.Visible = false;
                    td_lbl3.Visible = false;
                    td_txtfed.Visible = false;
                    td_1.Visible = false;
                    td_lbl0.Visible = false;
                    td_txtloc.Visible = false;
                    td0.Visible = false;
                }
                td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                td_lbl2.Visible = false;
                td_txtdes.Visible = false;
                td_2.Visible = false;


            }
            else if ((string)Session["sch"] == "16")
            {
                lbl3.Text = "FED FROM";
                if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "CAS 3I - ELV - Video Intercom(VI) System Commissioning Activity Schedule";
                    lbl1.Text = "AREA COVERED";
                    lbnum.Text = "NO.OF VIDEO STATION";
                    td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                }
                else
                {
                    lblhead.Text = "CAS ELV9 - Commissioning Activity Schedule";
                    lbnum.Text = "NO.OF DEVICES REQ'D CALIBRATION";
                    lbl1.Text = "SYSTEM CONTROLLED/ MONITORED";
                    lbl2.Text = "NO.OF POINTS";
                }
                td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
            }
            else if ((string)Session["sch"] == "18" || (string)Session["sch"] == "29")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "";
                lbnum.Text = "QUANTITY";
                drfed.Style.Add("display", "none");
                if ((string)Session["sch"] == "18")
                    lblhead.Text = "CAS PH2 Fire Protection Services  Commissioning Activity Schedule";
                else
                    lblhead.Text = "CAS M8 Fire Protection Services  Commissioning Activity Schedule";
                td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_txtfed.Visible = false; td_lbl3.Visible = false; td_1.Visible = false; td0.Visible = false; td_txtloc.Visible = false; td_lbl0.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "19")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";

                if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "CAS 4C Fire Protection Distribution Systems Commissioning Activity Schedule";
                    td_lbl0.Visible = false; td0.Visible = false; td_txtloc.Visible = false; drloc.Visible = false; td_lbl3.Visible = false; td_1.Visible = false; td_txtfed.Visible = false;
                    lbnum.Text = "QUANTITY";
                }
                else
                {
                    lblhead.Text = "CAS PH3 Fire Extinguishing Systems Commissioning Activity Schedule";
                    td_3.Visible = false; td_lbnum.Visible = false; td_txtnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;

                }
                td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_lbl2.Visible = false; td_2.Visible = false; td_txtdes.Visible = false;
            }
            else if ((string)Session["sch"] == "28")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                lbnum.Text = "";
                if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "CAS 5B Miscellaneous Systems (Pneumatic Tube System) Commissioning Activity Schedule";
                    td_txtnum.Visible = false; td_lbnum.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                    lbdes.Text = "DESCRIPTION";
                    lbloc.Text = "LOCATION";
                    lbl3.Text = "FED FROM (System Component)";
                    lbl1.Text = "FED FROM (Electrical)";
                }
                else
                {
                    lblhead.Text = "CAS M7 Fire Extinguishing Systems Commissioning Activity Schedule";
                    td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_lbl2.Visible = false; td_2.Visible = false; td_3.Visible = false; td_lbnum.Visible = false; td_txtnum.Visible = false; td_txtdes.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                }

            }
            else if ((string)Session["sch"] == "20")
            {
                lbl1.Text = "NO.OF POINTS";
                lbl2.Text = "NO.OF DEVICES REQUIRED CALIBRATION";
                lbl3.Text = "SYSTEM CONTROLLED/ MONITORED BY DDC";
                lbnum.Text = "NO.OF SYSTEM REQUIRED LOOP TUNING";
                drfed.Style.Add("display", "none");
                if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "CAS 3A - ELV - Energy Management Control System(EMCS) Commissioning Activity Schedule";
                    lbnum.Text = "NO.OF POINTS";
                    lbl3.Text = "SYSTEM CONTROLLED/ MONITORED";
                    td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                }
                else
                {
                    lblhead.Text = "CAS ELV2 Building Management System Commissioning Activity Schedule";
                }
                td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
            }
            else if ((string)Session["sch"] == "32")
            {
                lbl1.Text = "NO.OF POINTS";
                lbl2.Text = "NO.OF DEVICES REQUIRED CALIBRATION";
                lbl3.Text = "SYSTEM CONTROLLED/ MONITORED BY DDC";
                lbnum.Text = "NO.OF SYSTEM REQUIRED LOOP TUNING";
                drfed.Style.Add("display", "none");
                lblhead.Text = "CAS ELV2 SCADA Commissioning Activity Schedule";
                td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
            }
            else if ((string)Session["sch"] == "21")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "";
                lbnum.Text = "FLUSHING STAGE";
                txtpprovideto.Visible = false;
                if ((string)Session["project"] == "ASAO")
                    lblhead.Text = "CAS M4 Flushing Commissioning Activity Schedule";
                else
                    lblhead.Text = "CAS M2 Flushing Commissioning Activity Schedule";
                td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_lbl3.Visible = false; td_txtfed.Visible = false; td_1.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "22")
            {
                if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "CAS 3E - ELV - Access Control and Intruder Detection(ACID)System Commissioning Activity Schedule";
                    lbnum.Text = "NO.OF POINTS";
                    lbl3.Text = "AREA COVERED";
                }
                else
                {
                    lblhead.Text = "CAS ELV4 Access Control System Commissioning Activity Schedule";
                    lbloc.Text = "SYSTEMS MONITORED";
                    lbnum.Text = "NO.OF ACCESS CONTROLLED DOORS";
                    td_lbl3.Visible = false;
                    td_txtfed.Visible = false;
                    td_1.Visible = false;
                    drfed.Style.Add("display", "none");
                }
                td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                td_lbl1.Visible = false;
                td_txtppt.Visible = false;
                td_0.Visible = false;
                td_lbl2.Visible = false;
                td_txtdes.Visible = false;
                td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "23")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                lbnum.Text = "";
                if ((string)Session["project"] == "ASAO")
                {
                    lblhead.Text = "CAS MISC2 Conveying Systems Commissioning Activity Schedule";
                    td_3.Visible = false; td_lbnum.Visible = false; td_txtnum.Visible = false;
                    td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false;
                }
                else if ((string)Session["project"] == "CCAD")
                {
                    lbl3.Text = "GATEWAY/ LOOP";
                    lbl1.Text = "SYSTEM MONITORED";
                    lbnum.Text = "NO.OF IED DEVICE";
                    lblhead.Text = "CAS 3B - ELV - Power Monitoring Control System(PMCS) Commissioning Activity Schedule";
                }
                else
                {
                    lblhead.Text = "CAS ELV9 Lifts & Escalators Commissioning Activity Schedule";
                    td_3.Visible = false; td_lbnum.Visible = false; td_txtnum.Visible = false;
                    td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false;
                }

                td_lbl2.Visible = false; td_2.Visible = false; td_txtdes.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
            }
            else if ((string)Session["sch"] == "34" || (string)Session["sch"] == "35" || (string)Session["sch"] == "36")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                lbnum.Text = "";
                if ((string)Session["sch"] == "34")
                    lblhead.Text = "CAS MISC4 Power Failure Scenarios Commissioning Activity Schedule";
                else if ((string)Session["sch"] == "35")
                    lblhead.Text = "CAS MISC5 Vibration & Sound Level Commissioning Activity Schedule";
                else if ((string)Session["sch"] == "36")
                    lblhead.Text = "CAS MISC6 EOT Crane Commissioning Activity Schedule";
                td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_lbl2.Visible = false; td_2.Visible = false; td_3.Visible = false; td_lbnum.Visible = false; td_txtnum.Visible = false; td_txtdes.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
            }
            else if ((string)Session["sch"] == "30")
            {
                lbl1.Text = "NO.GRILLES";
                lbl2.Text = "NO.VAV";
                lbl3.Text = "FED FROM";
                lbnum.Text = "NO.CAV'S";
                lblhead.Text = "CAS M1 Ducted Fan Systems Commissioning Activity Schedule";

            }
            else if ((string)Session["sch"] == "26")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                lbnum.Text = "NO.OF VALVE SETS";
                if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "CAS 3M - ELV - Intercom & Healthcare Communications and Monitoring(IHCM) System Commissioning Activity Schedule";
                    td_lbnum.Visible = false; td_txtnum.Visible = false; td_3.Visible = false; td_lbl3.Visible = false; td_txtfed.Visible = false; td_1.Visible = false; td_txtdescr.Visible = false; td_lbldes.Visible = false; tddes.Visible = false;
                }
                else
                {
                    lblhead.Text = "CAS M5 Chilled & Condenser Systems Commissioning Activity Schedule";
                }
                td_lbl1.Visible = false;
                td_txtppt.Visible = false;
                td_0.Visible = false;
                td_lbl2.Visible = false;
                td_txtdes.Visible = false;
                td_2.Visible = false;
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
            //var _dv = (DataView)ObjectDataSource1.Select();
            //_dtMaster = _dv.ToTable();
            //_dtresult = _dtMaster;
            //Load_InitialData();
            _dtMaster = new DataTable();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32((string)Session["sch"]);
            _objcas.prj_code = lblprj.Text;
            _dtMaster = _objbll.Load_cassheet_data(_objcas, _objdb);
            _dtresult = _dtMaster;
        }
        private void Load_InitialData()
        {
            DataTable _dtable = new DataTable();
            _dtable.Columns.Add("Panel_Id", typeof(string));
            _dtable.Columns.Add("Panel_Ref", typeof(string));
            var distinctRows = (from DataRow dRow in _dtresult.Rows
                                where dRow["Panel_Parent"].ToString() == "0"
                                select new { col1 = dRow["Panel_Id"], col2 = dRow["Panel_Ref"] }).Distinct();
            foreach (var row in distinctRows)
            {
                DataRow _row = _dtable.NewRow();
                _row[0] = row.col1.ToString();
                _row[1] = row.col2.ToString();
                _dtable.Rows.Add(_row);
            }
            reptr_main.DataSource = _dtable;
            reptr_main.DataBind();
            //mymaster.DataSource = _dtable;
            //mymaster.DataBind();
           // Load_Filtering_Elements();

        }
        protected void mymaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _sys_id = (Label)e.Row.FindControl("lbSys_Id");
                DataTable _dtdetails = new DataTable();
                _dtdetails.Columns.Add("e_b_ref", typeof(string));
                _dtdetails.Columns.Add("B_Z", typeof(string));
                _dtdetails.Columns.Add("Cat", typeof(string));
                _dtdetails.Columns.Add("F_lvl", typeof(string));
                _dtdetails.Columns.Add("Seq_No", typeof(string));
                _dtdetails.Columns.Add("Loc", typeof(string));
                _dtdetails.Columns.Add("P_P_to", typeof(string));
                _dtdetails.Columns.Add("F_from", typeof(string));
                _dtdetails.Columns.Add("Substation", typeof(string));
                _dtdetails.Columns.Add("devices1", typeof(string));
                _dtdetails.Columns.Add("C_id", typeof(int));
                _dtdetails.Columns.Add("Sys_name", typeof(string));
                _dtdetails.Columns.Add("Sys_id", typeof(int));
                _dtdetails.Columns.Add("Des", typeof(string));
                var _details = from _data in _dtresult.AsEnumerable()
                               where _data.Field<int>("Sys_Id") == Convert.ToInt32(_sys_id.Text)
                               select _data;
                foreach (var row in _details)
                {
                    DataRow _row = _dtdetails.NewRow();
                    _row[0] = row["e_b_ref"].ToString();
                    _row[1] = row["B_Z"].ToString();
                    _row[2] = row["Cat"].ToString();
                    _row[3] = row["F_lvl"].ToString();
                    _row[4] = SeqNo(row["Seq_No"].ToString());
                    _row[5] = row["Loc"].ToString();
                    _row[6] = row["p_p_to"].ToString();
                    _row[7] = row["F_from"].ToString();
                    _row[8] = row["Substation"].ToString();
                    _row[9] = row["devices1"].ToString();
                    _row[10] = row["C_id"].ToString();
                    _row[11] = row["Sys_name"].ToString();
                    _row[12] = row["Sys_id"].ToString();
                    _row[13] = row["Des"].ToString();
                    _dtdetails.Rows.Add(_row);
                }
                GridView _mydetails = (GridView)e.Row.FindControl("mydetails");
                _mydetails.DataSource = _dtdetails;
                _mydetails.DataBind();
                //Button _btn = (Button)e.Row.FindControl("Button1");
                //_btn.Text = "+";
                //_mydetails.Visible = false;
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
            for (int i = 0; i <= reptr_main.Items.Count - 1; i++)
            {
                GridView _details = (GridView)reptr_main.Items[i].FindControl("details");
                _details.Visible = false;
            }
        }
        private void Open_Details(int mode)
        {
            //string sys = "";
            //if (mode == 1)
            //    sys = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));
            //else
            //    sys = (string)Session["Sys"];
            //for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            //{
            //    Label _sys_id = (Label)mymaster.Rows[i].FindControl("lbSys_Id");
            //    if (_sys_id.Text == sys)
            //    {
            //        GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
            //        Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
            //        _mydetails.Visible = true;
            //        _btn.Text = "-";
            //    }
            //}
        }
        protected void btnexpd_Click(object sender, EventArgs e)
        {
            Button _expnd = sender as Button;
            int repeaterItemIndex = ((RepeaterItem)_expnd.NamingContainer).ItemIndex;
            RepeaterItem _Pcontainer = (RepeaterItem)_expnd.NamingContainer;
            //int index = gvRow.;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + index.ToString() + "');", true);
            GridView _mydetails = (GridView)_Pcontainer.FindControl("details");
            Button _btn = (Button)_Pcontainer.FindControl("btnexpd");
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
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView _mydetails = (GridView)gvRow.FindControl("mydetails");
            int _idx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = _mydetails.Rows[_idx];
            // _mydetails.Rows[_idx].Style.Add("background-color", "yellow");
            //int index = gvRow.RowIndex;
            TableCell _item1 = _srow.Cells[13];
            TableCell _item2 = _srow.Cells[14];
            // TableCell _item3 = _srow.Cells[2];
            //string _file = _item.Text;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _file + "');", true);
            Session["casid"] = _item1.Text;
            Session["Sys"] = _item2.Text;
            Session["idx"] = _idx.ToString();
            //btnDummy_ModalPopupExtender.Show();
            arrange_edit();

        }
        protected void arrange_edit()
        {
            //int _idx = Convert.ToInt32((string)Session["idx"]);
            //GridViewRow _myrow = mymaster.SelectedRow;
            //GridView _mydetails = (GridView)_myrow.FindControl("mydetails");
            //if (_mydetails.Rows[_idx].Cells[2].Text.Trim() != "&nbsp;") upreff.Text = _mydetails.Rows[_idx].Cells[2].Text;
            //if (_mydetails.Rows[_idx].Cells[3].Text.Trim() != "&nbsp;") upzone.Text = _mydetails.Rows[_idx].Cells[3].Text;
            //if (_mydetails.Rows[_idx].Cells[4].Text.Trim() != "&nbsp;") upcate.Text = _mydetails.Rows[_idx].Cells[4].Text;
            //if (_mydetails.Rows[_idx].Cells[5].Text.Trim() != "&nbsp;") upfloor.Text = _mydetails.Rows[_idx].Cells[5].Text;
            //if (_mydetails.Rows[_idx].Cells[6].Text.Trim() != "&nbsp;") upseq.Text = _mydetails.Rows[_idx].Cells[6].Text;
            //if (_mydetails.Rows[_idx].Cells[7].Text.Trim() != "&nbsp;") uploc.Text = _mydetails.Rows[_idx].Cells[7].Text;
            //if (_mydetails.Rows[_idx].Cells[8].Text.Trim() != "&nbsp;") uplb1.Text = _mydetails.Rows[_idx].Cells[8].Text;
            //if (_mydetails.Rows[_idx].Cells[10].Text.Trim() != "&nbsp;") uplb2.Text = _mydetails.Rows[_idx].Cells[10].Text;
            //if (_mydetails.Rows[_idx].Cells[9].Text.Trim() != "&nbsp;") uplb3.Text = _mydetails.Rows[_idx].Cells[9].Text;
            //if (_mydetails.Rows[_idx].Cells[11].Text.Trim() != "&nbsp;") uplb4.Text = _mydetails.Rows[_idx].Cells[11].Text;
            //upreff.Text = upreff.Text.Replace("&amp;", "&"); upzone.Text = upzone.Text.Replace("&amp;", "&"); upfloor.Text = upfloor.Text.Replace("&amp;", "&"); uploc.Text = uploc.Text.Replace("&amp;", "&"); uplb1.Text = uplb1.Text.Replace("&amp;", "&"); uplb2.Text = uplb2.Text.Replace("&amp;", "&"); uplb3.Text = uplb3.Text.Replace("&amp;", "&"); uplb4.Text = uplb4.Text.Replace("&amp;", "&");
            Load_Master();
            var _result = from _data in _dtMaster.AsEnumerable()
                          where _data.Field<int>(0) == Convert.ToInt32((string)Session["casid"])
                          select _data;
            foreach (var row in _result)
            {
                upreff.Text = row[4].ToString();
                upzone.Text = row[5].ToString();
                upcate.Text = row[6].ToString();
                upfloor.Text = row[7].ToString();
                upseq.Text = row[48].ToString();
                uploc.Text = row[10].ToString();
                uplb1.Text = row[11].ToString();
                uplb2.Text = row[13].ToString();
                uplb3.Text = row[12].ToString();
                updescr.Text = row["Des"].ToString();
                uplb4.Text = row[21].ToString();
            }

            //if ((string)Session["sch"] == "1" || (string)Session["sch"] == "5")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb2.Text = lbl2.Text;
            //    }
            //    else
            //    {
            //        lb2.Visible = false;
            //        uplb2.Visible = false;
            //    }
            //    lb1.Text = lbl1.Text;
            //    lb3.Text = lbl3.Text;
            //    lb4.Text = lbnum.Text;
            //    tr0.Visible = false;
            //}
            //else if ((string)Session["sch"] == "2")
            //{
            //    //lb1.Text = lbl1.Text;
            //    //lb3.Text = lbl3.Text;
            //    //uplb4.Visible = false;
            //    //uplb2.Visible = false;
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb1.Text = lbl1.Text;
            //        lb2.Text = lbl2.Text;
            //        lb3.Text = lbl3.Text;
            //        lb4.Text = lbnum.Text;
            //        tr0.Visible = false;
            //    }
            //    else
            //    {
            //        lb1.Text = lbl1.Text;
            //        lb2.Text = lbl2.Text;
            //        lb3.Text = lbl3.Text;
            //        lb4.Visible = false; uplb4.Visible = false; tr0.Visible = false;
            //    }
            //}
            //else if ((string)Session["sch"] == "3")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb4.Text = lbnum.Text;
            //    }
            //    else
            //    {
            //        lb4.Visible = false; uplb4.Visible = false;
            //    }
            //    lb1.Text = lbl1.Text;
            //    lb2.Text = lbl2.Text;
            //    lb3.Text = lbl3.Text;
            //    tr0.Visible = false;

            //}
            //else if ((string)Session["sch"] == "4")
            //{
            //    lb1.Text = lbl1.Text;
            //    lb3.Text = lbl3.Text;
            //    lb4.Visible = false;
            //    uplb4.Visible = false;
            //    lb2.Visible = false;
            //    uplb2.Visible = false; tr0.Visible = false;

            //}
            //else if ((string)Session["sch"] == "6")
            //{
            //    lb1.Text = lbl1.Text;
            //    uplb2.Visible = false; uplb3.Visible = false;
            //    uplb4.Visible = false; tr0.Visible = false;

            //}
            //else if ((string)Session["sch"] == "7")
            //{
            //    lb4.Text = lbnum.Text;
            //    lb1.Visible = false; uplb1.Visible = false; lb2.Visible = false; uplb2.Visible = false; lb3.Visible = false; uplb3.Visible = false;
            //    tr0.Visible = false;
            //}
            //else if ((string)Session["sch"] == "8")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb4.Text = lbnum.Text; tr3.Visible = false; tr4.Visible = false; lb3.Text = lbl3.Text;
            //    }
            //    else
            //    {
            //        lb3.Text = lbl3.Text; tr3.Visible = false; tr4.Visible = false; tr5.Visible = false;
            //    }
            //}
            //else if ((string)Session["sch"] == "24")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb4.Text = lbnum.Text; tr0.Visible = false;
            //    }
            //    else
            //    {
            //        tr5.Visible = false;
            //    }
            //    lb3.Text = lbl3.Text;
            //    tr3.Visible = false; tr4.Visible = false;
            //}
            //else if ((string)Session["sch"] == "25")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb4.Text = lbnum.Text; tr0.Visible = false; tr2.Visible = false;
            //    }
            //    else
            //    {
            //        tr5.Visible = false;
            //    }
            //    lb3.Text = lbl3.Text;
            //    tr3.Visible = false; tr4.Visible = false;
            //}
            //else if ((string)Session["sch"] == "17")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb4.Text = lbnum.Text;
            //    }
            //    else
            //    {
            //        tr5.Visible = false;
            //    }
            //    lb3.Text = lbl3.Text;
            //    tr3.Visible = false; tr4.Visible = false;
            //}
            //else if ((string)Session["sch"] == "27")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb4.Text = lbnum.Text;
            //        tr2.Visible = false;
            //    }
            //    else
            //    {
            //        tr5.Visible = false;
            //    }
            //    lb3.Text = lbl3.Text;
            //    tr3.Visible = false; tr4.Visible = false;
            //}
            //else if ((string)Session["sch"] == "9")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lbldes.Text = lbdes.Text; lblloc.Text = lbloc.Text;
            //        lb3.Text = lbl3.Text; lb1.Text = lbl1.Text; tr4.Visible = false; tr5.Visible = false;
            //    }
            //    else
            //    {
            //        tr2.Visible = false; tr3.Visible = false; tr4.Visible = false; tr5.Visible = false;
            //    }
            //}
            if ((string)Session["sch"] == "10")
            {
                if ((string)Session["project"] == "CCAD")
                {
                    lb1.Text = lbl1.Text;
                }
                else
                    tr3.Visible = false;
                lb4.Text = lbnum.Text;
                lb2.Text = "NO.OF DEVICES";
                tr2.Visible = false; tr0.Visible = false;

            }
            //else if ((string)Session["sch"] == "31")
            //{
            //    lb4.Text = lbnum.Text;
            //    lb2.Text = "NO.OF DEVICES";
            //    tr2.Visible = false; tr3.Visible = false; tr0.Visible = false;

            //}
            //else if ((string)Session["sch"] == "15")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb1.Text = lbl1.Text;
            //        lb3.Text = lbl3.Text;
            //    }
            //    else
            //    {
            //        tr3.Visible = false; tr1.Visible = false; tr2.Visible = false;
            //    }
            //    tr4.Visible = false;
            //    lb4.Text = lbnum.Text;
            //    tr0.Visible = false;

            //}
            //else if ((string)Session["sch"] == "14")
            //{
            //    lb4.Text = lbnum.Text;
            //    tr2.Visible = false; tr3.Visible = false; tr0.Visible = false; tr4.Visible = false;
            //    if ((string)Session["project"] != "CCAD")
            //    {
            //        tr1.Visible = false;
            //    }
            //}

            //else if ((string)Session["sch"] == "16")
            //{
            //    lb4.Text = lbnum.Text;
            //    lb2.Text = lbl2.Text;
            //    lb3.Text = lbl3.Text;
            //    lb1.Text = lbl1.Text;
            //    tr0.Visible = false;
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        tr4.Visible = false;
            //    }
            //    //lb1.Visible = false; uplb1.Visible = false;
            //}
            //else if ((string)Session["sch"] == "18" || (string)Session["sch"] == "29")
            //{
            //    lb4.Text = lbnum.Text;
            //    tr1.Visible = false; tr2.Visible = false; tr3.Visible = false; tr4.Visible = false;
            //}
            //else if ((string)Session["sch"] == "23")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb4.Text = lbnum.Text;
            //        lb1.Text = lbl1.Text;
            //    }
            //    else
            //    {
            //        tr5.Visible = false;
            //        tr3.Visible = false;
            //    }
            //    lb3.Text = lbl3.Text;
            //    tr4.Visible = false; tr0.Visible = false;
            //}
            //else if ((string)Session["sch"] == "19")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb4.Text = lbnum.Text;
            //        tr1.Visible = false; tr2.Visible = false;
            //    }
            //    else
            //    {
            //        tr5.Visible = false; tr0.Visible = false; lb3.Text = lbl3.Text;
            //    }

            //    tr3.Visible = false; tr4.Visible = false;
            //}
            //else if ((string)Session["sch"] == "28" || (string)Session["sch"] == "34" || (string)Session["sch"] == "35" || (string)Session["sch"] == "36")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lbldes.Text = lbdes.Text; lblloc.Text = lbloc.Text;
            //        lb3.Text = lbl3.Text; lb1.Text = lbl1.Text; tr4.Visible = false; tr5.Visible = false;
            //    }
            //    else
            //    {
            //        lb3.Text = lbl3.Text;
            //        tr3.Visible = false; tr4.Visible = false; tr5.Visible = false; tr0.Visible = false;
            //    }
            //}
            //else if ((string)Session["sch"] == "21")
            //{
            //    lb4.Text = lbnum.Text;
            //    tr2.Visible = false; tr3.Visible = false; tr4.Visible = false;

            //}
            //else if ((string)Session["sch"] == "13")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb3.Text = lbl3.Text;
            //    }
            //    else
            //    {
            //        tr2.Visible = false;
            //    }
            //    lblloc.Text = lbloc.Text;
            //    lb4.Text = lbnum.Text;
            //    tr3.Visible = false; tr4.Visible = false; tr0.Visible = false;

            //}
            //else if ((string)Session["sch"] == "22")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb3.Text = lbl3.Text;
            //    }
            //    else
            //    {
            //        tr2.Visible = false;
            //    }
            //    lblloc.Text = lbloc.Text;
            //    lb4.Text = lbnum.Text;
            //    tr3.Visible = false; tr4.Visible = false; tr0.Visible = false;

            //}
            else if ((string)Session["sch"] == "11")
            {
                lblloc.Text = lbloc.Text;
                lb4.Text = lbnum.Text;
                lb2.Text = lbl2.Text;
                tr2.Visible = false; tr3.Visible = false; tr0.Visible = false;
                if ((string)Session["project"] == "CCAD")
                {
                    tr4.Visible = false;
                }

            }
            //else if ((string)Session["sch"] == "20")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        tr3.Visible = false;
            //        tr4.Visible = false;
            //    }
            //    else
            //    {
            //        lb1.Text = lbl1.Text;
            //        lb2.Text = lbl2.Text;

            //    }
            //    lb3.Text = lbl3.Text;
            //    lb4.Text = lbnum.Text;
            //    tr0.Visible = false;

            //}
            //else if ((string)Session["sch"] == "32")
            //{
            //    lb1.Text = lbl1.Text;
            //    lb3.Text = lbl3.Text;
            //    lb2.Text = lbl2.Text;
            //    lb4.Text = lbnum.Text;
            //    tr0.Visible = false;
            //}
            //else if ((string)Session["sch"] == "12")
            //{
            //    lb4.Text = lbnum.Text;
            //    lb3.Text = lbl3.Text;
            //    tr4.Visible = false; tr3.Visible = false; tr0.Visible = false;

            //}
            //else if ((string)Session["sch"] == "30")
            //{
            //    lb1.Text = lbl1.Text;
            //    lb3.Text = lbl3.Text;
            //    lb2.Text = lbl2.Text;
            //    lb4.Text = lbnum.Text;
            //}
            //else if ((string)Session["sch"] == "26")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        tr0.Visible = false;
            //        tr2.Visible = false;
            //        tr5.Visible = false;
            //    }
            //    lb3.Text = lbl3.Text;
            //    lb4.Text = lbnum.Text;
            //    tr3.Visible = false; tr4.Visible = false;
            //}

        }
        protected void mydetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[1].Text = (e.Row.DataItemIndex + 1).ToString();
            if ((string)Session["sch"] == "1" || (string)Session["sch"] == "5")
            {
                if ((string)Session["project"] == "CCAD")
                    e.Row.Cells[7].Visible = false;
                else
                {
                    e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
                }
            }
            else if ((string)Session["sch"] == "4")
            {
                e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "2")
            {
                if ((string)Session["project"] == "CCAD")
                    e.Row.Cells[7].Visible = false;
                else
                {
                    e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
                }
            }
            else if ((string)Session["sch"] == "3")
            {
                if ((string)Session["project"] != "CCAD")
                    e.Row.Cells[12].Visible = false;
                e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "6")
            {
                e.Row.Cells[9].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "7")
            {
                if ((string)Session["project"] != "CCAD")
                {
                    e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
                }
                e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "8")
            {
                if ((string)Session["project"] == "CCAD")
                { e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false; }
                else
                {
                    e.Row.Cells[10].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[11].Visible = false;
                }
            }
            else if ((string)Session["sch"] == "24")
            {
                if ((string)Session["project"] == "CCAD")
                {
                    e.Row.Cells[7].Visible = false;
                }
                else
                {
                    e.Row.Cells[12].Visible = false;
                }
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "25")
            {
                if ((string)Session["project"] == "CCAD")
                {
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[9].Visible = false;
                }
                else
                {
                    e.Row.Cells[12].Visible = false;
                }
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "17")
            {
                if ((string)Session["project"] != "CCAD")
                    e.Row.Cells[12].Visible = false;
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "27")
            {
                if ((string)Session["project"] == "CCAD")
                    e.Row.Cells[9].Visible = false;
                else
                    e.Row.Cells[12].Visible = false;
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "9")
            {
                if ((string)Session["project"] == "CCAD")
                { e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; }
                else
                {
                    e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false;
                }
            }
            else if ((string)Session["sch"] == "18" || (string)Session["sch"] == "29")
            {
                e.Row.Cells[8].Visible = false; e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "23")
            {
                if ((string)Session["project"] != "CCAD")
                {
                    e.Row.Cells[12].Visible = false; e.Row.Cells[10].Visible = false;
                }
                e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "19")
            {
                if ((string)Session["project"] == "CCAD")
                {
                    e.Row.Cells[8].Visible = false; e.Row.Cells[9].Visible = false;
                }
                else
                {
                    e.Row.Cells[7].Visible = false; e.Row.Cells[12].Visible = false;
                }
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "28" || (string)Session["sch"] == "34" || (string)Session["sch"] == "35" || (string)Session["sch"] == "36")
            {
                if ((string)Session["project"] == "CCAD")
                { e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; }
                else
                {
                    e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
                }
            }
            else if ((string)Session["sch"] == "21")
            {
                e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "10")
            {
                if ((string)Session["project"] != "CCAD" && (string)Session["project"] != "trial")
                    e.Row.Cells[10].Visible = false;
                e.Row.Cells[9].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "31")
            {
                e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false;
            }

            else if ((string)Session["sch"] == "20")
            {
                e.Row.Cells[7].Visible = false;
                if ((string)Session["project"] == "CCAD")
                {
                    e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
                }
            }
            else if ((string)Session["sch"] == "32")
            {
                e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "13")
            {
                if ((string)Session["project"] != "CCAD")
                {
                    e.Row.Cells[9].Visible = false;
                }
                e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "22")
            {
                if ((string)Session["project"] != "CCAD")
                {
                    e.Row.Cells[9].Visible = false;
                }
                e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "11")
            {
                if ((string)Session["project"] == "CCAD")
                {
                    e.Row.Cells[11].Visible = false;
                }
                e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "12")
            {
                e.Row.Cells[11].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "15")
            {
                if ((string)Session["project"] != "CCAD")
                {
                    e.Row.Cells[8].Visible = false; e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false;
                }
                e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "14")
            {
                if ((string)Session["project"] != "CCAD")
                {
                    e.Row.Cells[8].Visible = false;
                }
                e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "16")
            {
                if ((string)Session["project"] == "CCAD")
                    e.Row.Cells[11].Visible = false;
                e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "26")
            {
                if ((string)Session["project"] == "CCAD")
                {
                    e.Row.Cells[7].Visible = false; e.Row.Cells[9].Visible = false; e.Row.Cells[12].Visible = false;
                }

                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }

        }
        private void Filtering(string _el1, string _el2, string _el3, string _el4, string _el5, string _el6)
        {
            if (_el1 == "") _el1 = "All";
            if (_el2 == "") _el2 = "All";
            if (_el3 == "") _el3 = "All";
            if (_el4 == "") _el4 = "All";
            if (_el5 == "") _el5 = "All";
            if (_el6 == "") _el6 = "All";
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
            if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 == "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("Loc") == _el5 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("Loc") == _el5 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 != "All" && _el6 != "All")
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
        protected void drbuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["zone"] = drbuilding.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drdes.SelectedItem.Text);
        }
        protected void drcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["cat"] = drcategory.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drdes.SelectedItem.Text);
        }
        protected void drflevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["flvl"] = drflevel.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drdes.SelectedItem.Text);
        }
        protected void drfed_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["fed"] = drfed.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drdes.SelectedItem.Text);
        }
        protected void drpackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpackage.SelectedItem.Text != "--Package--")
            {
                txtcate.Text = drpackage.SelectedItem.Value.Substring(drpackage.SelectedItem.Value.IndexOf("_C") + 2);
                Get_Position();
                Load_Flvl();
            }
        }
        private void Get_Position()
        {
            string Sys_Id = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _objcls.sys = Convert.ToInt32(Sys_Id);
            txtitmno.Text = _objbll.Get_Position(_objcls, _objdb).ToString();
        }
        private void Get_SeqNo()
        {
            string Sys_Id = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _objcls.sys = Convert.ToInt32(Sys_Id);
            _objcls.f_level = drflevel_.SelectedItem.Text;
            _objcls.b_zone = txtzone.Text;
            if (txtitmno.Text.Length <= 0)
            {
                txtitmno.Text = "0";
            }
            _objcls.Position = Convert.ToInt32(txtitmno.Text);
            txtseq.Text = _objbll.Get_Seq(_objcls, _objdb).ToString();
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            if (drpackage.SelectedItem.Text == "--Package--")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Package');", true);
                return;
            }
            else if (txtengref.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Enter Eng.Ref');", true);
                return;
            }
            else if (drflevel_.SelectedItem.Text == "- - -")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Floor Level');", true);
                return;
            }
            if ((string)Session["sch"] == "1" || (string)Session["sch"] == "5" || (string)Session["sch"] == "7" || (string)Session["sch"] == "18" || (string)Session["sch"] == "21" || (string)Session["sch"] == "13" || (string)Session["sch"] == "22" || (string)Session["sch"] == "12" || (string)Session["sch"] == "15" || (string)Session["sch"] == "14")
            {
                if (IsNumeric(txtnoof.Text) == false)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lbnum.Text + "');", true);
                    return;
                }
            }
            else if ((string)Session["sch"] == "11")
            {
                if (IsNumeric(txtnoof.Text) == false)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lbnum.Text + "');", true);
                    return;
                }
                else if (IsNumeric(txtdesc.Text) == false)
                {
                    if ((string)Session["project"] != "CCAD")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lbl2.Text + "');", true);
                        return;
                    }
                }
            }
            else if ((string)Session["sch"] == "20")
            {
                if ((string)Session["project"] != "CCAD")
                {
                    if (IsNumeric(txtpprovideto.Text) == false)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lbl1.Text + "');", true);
                        return;
                    }
                    else if (IsNumeric(txtdesc.Text) == false)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lbl2.Text + "');", true);
                        return;
                    }
                }

                if (IsNumeric(txtnoof.Text) == false)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lbnum.Text + "');", true);
                    return;
                }
            }
            //if (IfExistRef() == true) return;
            string _sys = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));
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
            Open_Details(1);
            Load_Flvl();
        }
        private void Load_Filtering_Elements()
        {
            drbuilding.Items.Clear();
            drcategory.Items.Clear();
            drflevel.Items.Clear();
            drfed.Items.Clear();
            drloc.Items.Clear();
            drdes.Items.Clear();
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
            var _des = (from DataRow dRow in _dtresult.Rows
                        orderby dRow["Des"]
                        select new { col1 = dRow["Des"] }).Distinct();
            foreach (var row in _des)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drdes.Items.Add(_itm);
            }
            drdes.DataBind();
            drbuilding.Items.Insert(0, "All");
            drcategory.Items.Insert(0, "All");
            drflevel.Items.Insert(0, "All");
            drfed.Items.Insert(0, "All");
            drloc.Items.Insert(0, "All");
            drdes.Items.Insert(0, "All");
            drbuilding.SelectedValue = (string)Session["zone"];
            drcategory.SelectedValue = (string)Session["cat"];
            drflevel.SelectedValue = (string)Session["flvl"];
            drfed.SelectedValue = (string)Session["fed"];
            drloc.SelectedValue = (string)Session["loc"];
            drdes.SelectedValue = (string)Session["des"];
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            //if ((string)Session["sch"] == "1" || (string)Session["sch"] == "5" || (string)Session["sch"] == "7" || (string)Session["sch"] == "18" || (string)Session["sch"] == "21" || (string)Session["sch"] == "20" || (string)Session["sch"] == "13" || (string)Session["sch"] == "22" || (string)Session["sch"] == "11" || (string)Session["sch"] == "12" || (string)Session["sch"] == "15" || (string)Session["sch"] == "14")
            //{
            //    if (IsNumeric(uplb4.Text) == false)
            //    {
            //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lbnum.Text + "');", true);
            //        return;
            //    }
            //}
            //if ((string)Session["sch"] == "20")
            //{
            //    if ((string)Session["project"] != "CCAD")
            //    {
            //        if (IsNumeric(uplb1.Text) == false)
            //        {
            //            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lb1.Text + "');", true);
            //            return;
            //        }

            //        else if (IsNumeric(uplb2.Text) == false)
            //        {
            //            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lb2.Text + "');", true);
            //            return;
            //        }
            //    }
            //    if (IsNumeric(uplb4.Text) == false)
            //    {
            //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lb4.Text + "');", true);
            //        return;
            //    }
            //}
            //else if ((string)Session["sch"] == "11")
            //{
            //    if (IsNumeric(uplb2.Text) == false)
            //    {
            //        if ((string)Session["project"] != "CCAD")
            //        {
            //            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lb2.Text + "');", true);
            //            return;
            //        }
            //    }
            //    else if (IsNumeric(uplb4.Text) == false)
            //    {
            //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lb4.Text + "');", true);
            //        return;
            //    }
            //}
            Edit_Inidata();
            Load_Master();
            Load_InitialData();
            //Open_Details(0);
            btnDummy_ModalPopupExtender.Hide();
        }
        private void Edit_Inidata()
        {
            if ((string)Session["sch"] == "21" || (string)Session["sch"] == "9" || (string)Session["sch"] == "17" || (string)Session["sch"] == "18" || (string)Session["sch"] == "24")
            {
                uplb2.Text = updescr.Text;
            }
            if ((string)Session["sch"] == "8")
                if ((string)Session["project"] != "CCAD")
                    uplb2.Text = updescr.Text;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.c_s_id = 0;
            _objcas.prj_code = (string)Session["project"];
            _objcas.uid = (string)Session["uid"];
            _objcas.sys = Convert.ToInt32((string)Session["Sys"]);
            _objcas.reff = upreff.Text;
            _objcas.b_zone = upzone.Text;
            _objcas.cate = upcate.Text;
            _objcas.f_level = upfloor.Text;
            _objcas.seq_no = Convert.ToInt32(upseq.Text);
            _objcas.desc = updescr.Text;
            _objcas.loca = uploc.Text;
            _objcas.p_power_to = uplb1.Text;
            _objcas.fed_from = uplb3.Text;
            _objcas.sub_st = uplb2.Text;
            _objcas.s_c_m = uplb2.Text;
            _objcas.dev1 = uplb4.Text;
            _objcas.dev2 = uplb2.Text;
            _objcas.dev3 = "0";
            if ((string)Session["sch"] == "20")
            {
                _objcas.dev2 = uplb2.Text;
                _objcas.dev3 = uplb1.Text;
            }
            if ((string)Session["sch"] == "11" || (string)Session["sch"] == "10")
            {
                _objcas.dev2 = uplb2.Text;
            }
            _objcas.mode = 0;
            _objcas.cas_id = Convert.ToInt32((string)Session["casid"]);
            _objbll.Cassheet_Master(_objcas, _objdb);
        }
        private void Delete_Inidata()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.c_s_id = 0;
            _objcas.prj_code = (string)Session["project"];
            _objcas.uid = (string)Session["uid"];
            _objcas.sys = Convert.ToInt32((string)Session["Sys"]);
            _objcas.reff = "";
            _objcas.b_zone = "";
            _objcas.cate = "";
            _objcas.f_level = "";
            _objcas.seq_no = 0;
            _objcas.desc = "";
            _objcas.loca = "";
            _objcas.p_power_to = "";
            _objcas.fed_from = "";
            _objcas.sub_st = "";
            _objcas.s_c_m = "";
            _objcas.dev1 = "";
            _objcas.dev2 = "0";
            _objcas.dev3 = "0";
            _objcas.mode = 2;
            _objcas.cas_id = Convert.ToInt32((string)Session["casid"]);
            _objbll.Cassheet_Master(_objcas, _objdb);
        }
        protected void btndelete_Click(object sender, EventArgs e)
        {
            //int count = 0;
            //for (int i = 0; i <= reptr_main.Items.Count - 1; i++)
            //{
            //    GridView _details = (GridView)reptr_main.Items[i].FindControl("details");
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
        protected void btncancel_Click(object sender, EventArgs e)
        {
           btnDummy_ModalPopupExtender.Hide();
        }
        protected void add_initial_data()
        {
            //if (IsNullvalidation() == true) return;
            if ((string)Session["sch"] == "21" || (string)Session["sch"] == "9" || (string)Session["sch"] == "17" || (string)Session["sch"] == "18" || (string)Session["sch"] == "24")
            {
                txtdesc.Text = txtdes.Text;
            }
            if ((string)Session["sch"] == "8")
                if ((string)Session["project"] != "CCAD")
                    txtdesc.Text = txtdes.Text;
            string _sys = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.c_s_id = Convert.ToInt32((string)Session["sch"]);
            _objcas.prj_code = (string)Session["project"];
            _objcas.uid = (string)Session["uid"];
            _objcas.sys = Convert.ToInt32(_sys);
            _objcas.reff = txtengref.Text;
            _objcas.b_zone = txtzone.Text;
            _objcas.cate = txtcate.Text;
            _objcas.f_level = drflevel_.SelectedItem.Text;
            _objcas.seq_no = Convert.ToInt32(txtseq.Text);
            _objcas.desc = txtdes.Text;
            _objcas.loca = txtloca.Text;
            _objcas.p_power_to = txtpprovideto.Text;
            _objcas.fed_from = txtfedfr.Text;
            _objcas.sub_st = txtdesc.Text;
            _objcas.s_c_m = txtdesc.Text;
            _objcas.dev1 = txtnoof.Text;
            //if ((string)Session["sch"] == "10" || (string)Session["sch"] == "16" || (string)Session["sch"] == "20")
            //    _objcas.dev2 = txtdesc.Text;
            //else
            //    _objcas.dev2 = "0";
            //if ((string)Session["sch"] == "20")
            //    _objcas.dev3 = txtpprovideto.Text;
            //else
            //    _objcas.dev3 = "0";
            _objcas.dev2 = txtdesc.Text;
            _objcas.dev3 = txtpprovideto.Text;
            if ((string)Session["sch"] == "20")
            {
                _objcas.dev2 = txtdesc.Text;
                _objcas.dev3 = txtpprovideto.Text;
            }
            if ((string)Session["sch"] == "11" || (string)Session["sch"] == "10")
                _objcas.dev2 = txtdesc.Text;
            _objcas.mode = 1;
            _objcas.cas_id = 0;
            _objcas.Position = Convert.ToInt32(txtitmno.Text);
            _objcas.panel_id = Convert.ToInt32(drpanel.SelectedItem.Value);
            _objbll.Cassheet_Master(_objcas, _objdb);
            Get_Position();
            Get_SeqNo();

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
        private bool IfExistRef()
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
            _objcls.reff = txtengref.Text;
            if (_objbll.Check_EngRef(_objcls, _objdb) != 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Engineer Ref. Already Exist!');", true);
                return true;
            }
            return false;

        }
        protected void drloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["loc"] = drloc.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drdes.SelectedItem.Text);
        }
        protected void btnnewflevel_Click(object sender, EventArgs e)
        {
            //txtflvl.Text = String.Empty;
            //btnDummy_ModalPopupExtender1.Show();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            //if (txtflvl.Text.Length <= 0) return;
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DB_" + (string)Session["project"];
            //_clscassheet _objcas = new _clscassheet();
            //_objcas.f_level = txtflvl.Text;
            //_objbll.Create_FLevel(_objcas, _objdb);
            //Load_Flvl();
            //btnDummy_ModalPopupExtender1.Hide();
        }
        private void Load_Flvl()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            drflevel_.DataSource = _objbll.Load_Flvl(_objdb);
            drflevel_.DataTextField = "F_Level";
            drflevel_.DataValueField = "F_Level";
            drflevel_.DataBind();
            drflevel_.Items.Insert(0, "- - -");
        }
        protected void btncancel1_Click(object sender, EventArgs e)
        {
            //btnDummy_ModalPopupExtender1.Hide();
        }
        protected void drflevel__SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpackage.SelectedItem.Text == "--Package--") return;
            Get_SeqNo();
        }

        protected void btnexpand_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= reptr_main.Items.Count - 1; i++)
            {
                GridView _mydetails = (GridView)reptr_main.Items[i].FindControl("details");
                Button _btn = (Button)reptr_main.Items[i].FindControl("btnexpd");
                _mydetails.Visible = true;
                _btn.Text = "-";
            }
        }

        protected void btncollapse_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= reptr_main.Items.Count - 1; i++)
            {
                GridView _mydetails = (GridView)reptr_main.Items[i].FindControl("details");
                Button _btn = (Button)reptr_main.Items[i].FindControl("btnexpd");
                _mydetails.Visible = false;
                _btn.Text = "+";
            }
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
            for (int i = 0; i <= reptr_main.Items.Count - 1; i++)
            {
               
                GridView _details = (GridView)reptr_main.Items[i].FindControl("details");
                foreach(GridViewRow _drow in _details.Rows)
                {
                    GridView _inner_main = (GridView)_drow.FindControl("inner1");
                    foreach (GridViewRow _drow1 in _inner_main.Rows)
                    {
                        CheckBox checkbox = (CheckBox)_drow1.FindControl("chkrow");
                        if (checkbox.Checked == true)
                        {
                            count += 1;
                            Session["casid"] = _drow1.Cells[13].Text;
                            Session["Sys"] = _drow1.Cells[14].Text;
                        }
                    }
                    GridView _inner_sub = (GridView)_drow.FindControl("inner_sub");
                    foreach (GridViewRow _drow2 in _inner_sub.Rows)
                    {
                        GridView _inner_sub1 = (GridView)_drow2.FindControl("inner2");
                        foreach (GridViewRow _drow3 in _inner_sub1.Rows)
                        {
                            CheckBox checkbox = (CheckBox)_drow3.FindControl("chkrow");
                            if (checkbox.Checked == true)
                            {
                                count += 1;
                                Session["casid"] = _drow3.Cells[13].Text;
                                Session["Sys"] = _drow3.Cells[14].Text;
                            }
                        }
                    }
                }



            }
            if (count == 0) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');", true);
            else if (count > 1) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('You can select only one Row at a time to Edit');", true);
            else if (count == 1)
            {
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["MemberId"] + "',7);", true);

               btnDummy_ModalPopupExtender.Show();
                arrange_edit();
            }
        }

        protected void btndelete1_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i <= reptr_main.Items.Count - 1; i++)
            {

                GridView _details = (GridView)reptr_main.Items[i].FindControl("details");
                foreach (GridViewRow _drow in _details.Rows)
                {
                    GridView _inner_main = (GridView)_drow.FindControl("inner1");
                    foreach (GridViewRow _drow1 in _inner_main.Rows)
                    {
                        CheckBox checkbox = (CheckBox)_drow1.FindControl("chkrow");
                        if (checkbox.Checked == true)
                        {
                            count += 1;
                            Session["casid"] = _drow1.Cells[13].Text;
                            Session["Sys"] = _drow1.Cells[14].Text;
                            Delete_Inidata();
                        }
                    }
                    GridView _inner_sub = (GridView)_drow.FindControl("inner_sub");
                    foreach (GridViewRow _drow2 in _inner_sub.Rows)
                    {
                        GridView _inner_sub1 = (GridView)_drow2.FindControl("inner2");
                        foreach (GridViewRow _drow3 in _inner_sub1.Rows)
                        {
                            CheckBox checkbox = (CheckBox)_drow3.FindControl("chkrow");
                            if (checkbox.Checked == true)
                            {
                                count += 1;
                                Session["casid"] = _drow3.Cells[13].Text;
                                Session["Sys"] = _drow3.Cells[14].Text;
                                Delete_Inidata();
                            }
                        }
                    }
                }
            }
            if (count == 0) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');", true);
            else
            {
                string _msg = count.ToString() + " Row(s) Deleted";
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _msg + "');", true);
                Load_Master();
                Load_InitialData();
                Open_Details(0);
            }
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
                          where _data.Field<string>("E_b_ref").ToUpper().IndexOf("string") >= 0
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
            string _url = "../CMS/Import.aspx?id=" + (string)Session["sch"] + "_" + (string)Session["project"];
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _url + "','','left=300,top=200,width=500,height=400,menubar=0,toolbar=0,scrollbars=1,status=0,resizable=0');", true);
        }
        protected void btnrefresh_Click(object sender, ImageClickEventArgs e)
        {
            Load_Master();
            Load_InitialData();
        }

        protected void drdes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["des"] = drdes.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drdes.SelectedItem.Text);
        }

        protected void drflevel__SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (drpackage.SelectedItem.Text == "--Package--") return;
            Get_SeqNo();
        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            string _prm = Request.QueryString[0].ToString();
            lblprj.Text = _prm.Substring(0, _prm.IndexOf("_S"));
            lblsch.Text = _prm.Substring(_prm.IndexOf("_S") + 2);
            e.InputParameters["sch_id"] = Convert.ToInt32(lblsch.Text);
            e.InputParameters["prj_code"] = "CCAD";
        }

        protected void reptr_main_ItemDataBound(object sender,System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
            {

                Label _panel_id = (Label)e.Item.FindControl("lbl_panelPid");
                DataTable _dtable = new DataTable();
                _dtable.Columns.Add("Panel_Id", typeof(string));
                _dtable.Columns.Add("Panel_Ref", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    where dRow["Panel_Id"].ToString() == _panel_id.Text
                                    select new { col1 = dRow["Panel_Id"], col2 = dRow["Panel_Ref"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    DataRow _row = _dtable.NewRow();
                    _row[0] = row.col1.ToString();
                    _row[1] = row.col2.ToString();
                    _dtable.Rows.Add(_row);
                }
                GridView _mydetails = (GridView)e.Item.FindControl("details");
                _mydetails.DataSource = _dtable;
                _mydetails.DataBind();
                //Button _btn = (Button)e.Row.FindControl("Button1");
                //_btn.Text = "+";
               // _mydetails.Visible = false;
            }
          
        }

        protected DataTable Getinner1(int panel_id)
        {
            //Label _lb = (Label)reptr_main.FindControl("lbl_panelPid");
            DataTable _dtdetails = new DataTable();
            _dtdetails.Columns.Add("e_b_ref", typeof(string));
            _dtdetails.Columns.Add("B_Z", typeof(string));
            _dtdetails.Columns.Add("Cat", typeof(string));
            _dtdetails.Columns.Add("F_lvl", typeof(string));
            _dtdetails.Columns.Add("Seq_No", typeof(string));
            _dtdetails.Columns.Add("Loc", typeof(string));
            _dtdetails.Columns.Add("P_P_to", typeof(string));
            _dtdetails.Columns.Add("F_from", typeof(string));
            _dtdetails.Columns.Add("Substation", typeof(string));
            _dtdetails.Columns.Add("devices1", typeof(string));
            _dtdetails.Columns.Add("C_id", typeof(int));
            _dtdetails.Columns.Add("Sys_name", typeof(string));
            _dtdetails.Columns.Add("Sys_id", typeof(int));
            _dtdetails.Columns.Add("Des", typeof(string));
            var _details = from _data in _dtresult.AsEnumerable()
                           where _data.Field<int>("Panel_Id") == panel_id
                           select _data;
            foreach (var row in _details)
            {
                DataRow _row = _dtdetails.NewRow();
                _row[0] = row["e_b_ref"].ToString();
                _row[1] = row["B_Z"].ToString();
                _row[2] = row["Cat"].ToString();
                _row[3] = row["F_lvl"].ToString();
                _row[4] = SeqNo(row["Seq_No"].ToString());
                _row[5] = row["Loc"].ToString();
                _row[6] = row["p_p_to"].ToString();
                _row[7] = row["F_from"].ToString();
                _row[8] = row["Substation"].ToString();
                _row[9] = row["devices1"].ToString();
                _row[10] = row["C_id"].ToString();
                _row[11] = row["Sys_name"].ToString();
                _row[12] = row["Sys_id"].ToString();
                _row[13] = row["Des"].ToString();
                _dtdetails.Rows.Add(_row);
            }
            return _dtdetails;
        }

        protected void reptr_main_DataBinding(object sender, EventArgs e)
        {
            
        }
        protected void details_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _panel_id = (Label)e.Row.FindControl("lblpanel");
                DataTable _dtdetails = new DataTable();
                //_dtdetails.Columns.Add("e_b_ref", typeof(string));
                //_dtdetails.Columns.Add("B_Z", typeof(string));
                //_dtdetails.Columns.Add("Cat", typeof(string));
                //_dtdetails.Columns.Add("F_lvl", typeof(string));
                //_dtdetails.Columns.Add("Seq_No", typeof(string));
                //_dtdetails.Columns.Add("Loc", typeof(string));
                //_dtdetails.Columns.Add("P_P_to", typeof(string));
                //_dtdetails.Columns.Add("F_from", typeof(string));
                //_dtdetails.Columns.Add("Substation", typeof(string));
                //_dtdetails.Columns.Add("devices1", typeof(string));
                //_dtdetails.Columns.Add("C_id", typeof(int));
                //_dtdetails.Columns.Add("Sys_name", typeof(string));
                //_dtdetails.Columns.Add("Sys_id", typeof(int));
                //_dtdetails.Columns.Add("Des", typeof(string));
                //_dtdetails.Columns.Add("Panel_Ref", typeof(string));
                //var _details = from _data in _dtresult.AsEnumerable()
                //               where _data.Field<int>("Panel_Parent") == Convert.ToInt32(_panel_id.Text)
                //               select _data;
                //foreach (var row in _details)
                //{
                //    DataRow _row = _dtdetails.NewRow();
                //    _row[0] = row["e_b_ref"].ToString();
                //    _row[1] = row["B_Z"].ToString();
                //    _row[2] = row["Cat"].ToString();
                //    _row[3] = row["F_lvl"].ToString();
                //    _row[4] = SeqNo(row["Seq_No"].ToString());
                //    _row[5] = row["Loc"].ToString();
                //    _row[6] = row["p_p_to"].ToString();
                //    _row[7] = row["F_from"].ToString();
                //    _row[8] = row["Substation"].ToString();
                //    _row[9] = row["devices1"].ToString();
                //    _row[10] = row["C_id"].ToString();
                //    _row[11] = row["Sys_name"].ToString();
                //    _row[12] = row["Sys_id"].ToString();
                //    _row[13] = row["Des"].ToString();
                //    _row[14] = row["Panel_Ref"].ToString();
                //    _dtdetails.Rows.Add(_row);
                //}
                //GridView _mydetails = (GridView)e.Row.FindControl("inner2");
                //_mydetails.DataSource = _dtdetails;
                //_mydetails.DataBind();
                _dtdetails.Columns.Add("e_b_ref", typeof(string));
                _dtdetails.Columns.Add("B_Z", typeof(string));
                _dtdetails.Columns.Add("Cat", typeof(string));
                _dtdetails.Columns.Add("F_lvl", typeof(string));
                _dtdetails.Columns.Add("Seq_No", typeof(string));
                _dtdetails.Columns.Add("Loc", typeof(string));
                _dtdetails.Columns.Add("P_P_to", typeof(string));
                _dtdetails.Columns.Add("F_from", typeof(string));
                _dtdetails.Columns.Add("Substation", typeof(string));
                _dtdetails.Columns.Add("devices1", typeof(string));
                _dtdetails.Columns.Add("C_id", typeof(int));
                _dtdetails.Columns.Add("Sys_name", typeof(string));
                _dtdetails.Columns.Add("Sys_id", typeof(int));
                _dtdetails.Columns.Add("Des", typeof(string));
                var _details1 = from _data in _dtresult.AsEnumerable()
                                where _data.Field<int>("Panel_Id") == Convert.ToInt32(_panel_id.Text)
                                select _data;
                foreach (var row in _details1)
                {
                    DataRow _row = _dtdetails.NewRow();
                    _row[0] = row["e_b_ref"].ToString();
                    _row[1] = row["B_Z"].ToString();
                    _row[2] = row["Cat"].ToString();
                    _row[3] = row["F_lvl"].ToString();
                    _row[4] = SeqNo(row["Seq_No"].ToString());
                    _row[5] = row["Loc"].ToString();
                    _row[6] = row["p_p_to"].ToString();
                    _row[7] = row["F_from"].ToString();
                    _row[8] = row["Substation"].ToString();
                    _row[9] = row["devices1"].ToString();
                    _row[10] = row["C_id"].ToString();
                    _row[11] = row["Sys_name"].ToString();
                    _row[12] = row["Sys_id"].ToString();
                    _row[13] = row["Des"].ToString();
                    _dtdetails.Rows.Add(_row);
                }
                GridView _mydetails1 = (GridView)e.Row.FindControl("inner1");
                _mydetails1.DataSource = _dtdetails;
                _mydetails1.DataBind();
                //Button _btn = (Button)e.Row.FindControl("Button1");
                //_btn.Text = "+";
                //_mydetails.Visible = false;
                DataTable _dtable = new DataTable();
                _dtable.Columns.Add("Panel_Id", typeof(string));
                _dtable.Columns.Add("Panel_Ref", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    where dRow["Panel_Parent"].ToString() == _panel_id.Text
                                    select new { col1 = dRow["Panel_Id"], col2 = dRow["Panel_Ref"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    DataRow _row = _dtable.NewRow();
                    _row[0] = row.col1.ToString();
                    _row[1] = row.col2.ToString();
                    _dtable.Rows.Add(_row);
                }
                GridView _mydetails2 = (GridView)e.Row.FindControl("inner_sub");
                _mydetails2.DataSource = _dtable;
                _mydetails2.DataBind();
            }
        }
        protected void inner_sub_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _panel_id = (Label)e.Row.FindControl("lbl_panelCid");
                DataTable _dtdetails = new DataTable();
             _dtdetails.Columns.Add("e_b_ref", typeof(string));
                _dtdetails.Columns.Add("B_Z", typeof(string));
                _dtdetails.Columns.Add("Cat", typeof(string));
                _dtdetails.Columns.Add("F_lvl", typeof(string));
                _dtdetails.Columns.Add("Seq_No", typeof(string));
                _dtdetails.Columns.Add("Loc", typeof(string));
                _dtdetails.Columns.Add("P_P_to", typeof(string));
                _dtdetails.Columns.Add("F_from", typeof(string));
                _dtdetails.Columns.Add("Substation", typeof(string));
                _dtdetails.Columns.Add("devices1", typeof(string));
                _dtdetails.Columns.Add("C_id", typeof(int));
                _dtdetails.Columns.Add("Sys_name", typeof(string));
                _dtdetails.Columns.Add("Sys_id", typeof(int));
                _dtdetails.Columns.Add("Des", typeof(string));
                var _details1 = from _data in _dtresult.AsEnumerable()
                                where _data.Field<int>("Panel_Id") == Convert.ToInt32(_panel_id.Text)
                                select _data;
                foreach (var row in _details1)
                {
                    DataRow _row = _dtdetails.NewRow();
                    _row[0] = row["e_b_ref"].ToString();
                    _row[1] = row["B_Z"].ToString();
                    _row[2] = row["Cat"].ToString();
                    _row[3] = row["F_lvl"].ToString();
                    _row[4] = SeqNo(row["Seq_No"].ToString());
                    _row[5] = row["Loc"].ToString();
                    _row[6] = row["p_p_to"].ToString();
                    _row[7] = row["F_from"].ToString();
                    _row[8] = row["Substation"].ToString();
                    _row[9] = row["devices1"].ToString();
                    _row[10] = row["C_id"].ToString();
                    _row[11] = row["Sys_name"].ToString();
                    _row[12] = row["Sys_id"].ToString();
                    _row[13] = row["Des"].ToString();
                    _dtdetails.Rows.Add(_row);
                }
                GridView _mydetails1 = (GridView)e.Row.FindControl("inner2");
                _mydetails1.DataSource = _dtdetails;
                _mydetails1.DataBind();
                
            }
        }

        protected void btnedit_Click1(object sender, EventArgs e)
        {

        }

        
    }
}
