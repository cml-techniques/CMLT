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
    public partial class Commissioning_Testing2 : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtresult;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                lblprj.Text = _prm.Substring(0, _prm.IndexOf("_S"));
                lblsch.Text = _prm.Substring(_prm.IndexOf("_S") + 2);
                lblsch1.Text = lblsch.Text;
                if (lblprj.Text == "CCAD")
                {
                    if (lblsch.Text == "30" || lblsch.Text == "31" || lblsch.Text == "32" || lblsch.Text == "33" || lblsch.Text == "34" || lblsch.Text == "35" || lblsch.Text == "36" || lblsch.Text == "37" || lblsch.Text == "38" || lblsch.Text == "39" || lblsch.Text == "40")
                        lblsch.Text = "9";
                    else if (lblsch.Text == "85" || lblsch.Text == "86" || lblsch.Text == "87" || lblsch.Text == "88" || lblsch.Text == "89" || lblsch.Text == "90" || lblsch.Text == "91" || lblsch.Text == "99" || lblsch.Text == "107" || lblsch.Text == "108" || lblsch.Text == "117")
                        lblsch.Text = "17";
                    else if (lblsch.Text == "101")
                        lblsch.Text = "18";
                    else if (lblsch.Text == "102")
                        lblsch.Text = "19";
                    else if (lblsch.Text == "100")
                        lblsch.Text = "28";
                    else if (lblsch.Text == "103" || lblsch.Text == "104" || lblsch.Text == "105" || lblsch.Text == "106" || lblsch.Text == "109" || lblsch.Text == "110" || lblsch.Text == "111")
                        lblsch.Text = "27";
                    else if (lblsch.Text == "112" || lblsch.Text == "113" || lblsch.Text == "114" || lblsch.Text == "115" || lblsch.Text == "116")
                        Session["sch"] = "112";
                }
                settings();
                Load_Master();
                Session["filter"] = "no";
                Session["zone"] = "All";
                Session["flvl"] = "All";
                Session["cat"] = "All";
                Session["fed"] = "All";
                Session["loc"] = "All";
                Load_InitialData();
                Hide_Details();
            }
        }
        protected void settings()
        {
            if (lblsch.Text == "8" || lblsch.Text == "51" || lblsch.Text == "52" || lblsch.Text == "53" || lblsch.Text == "54" || lblsch.Text == "55" || lblsch.Text == "56" || lblsch.Text == "57" || lblsch.Text == "58" || lblsch.Text == "59" || lblsch.Text == "60" || lblsch.Text == "62" || lblsch.Text == "61" || lblsch.Text == "63" || lblsch.Text == "64" || lblsch.Text == "65" || lblsch.Text == "66" || lblsch.Text == "67" || lblsch.Text == "68" || lblsch.Text == "69" || lblsch.Text == "70" || lblsch.Text == "71" || lblsch.Text == "72" || lblsch.Text == "73" || lblsch.Text == "74" || lblsch.Text == "75" || lblsch.Text == "76" ||lblsch.Text == "77" || lblsch.Text == "78" || lblsch.Text == "79" || lblsch.Text == "80" || lblsch.Text == "81" || lblsch.Text == "82" || lblsch.Text == "83" || lblsch.Text == "84")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                lbltest8.Text = "PRE-COMM";
                lblduty8.Text = "% DUTY";
                lblppon.Text = "PLANNED POWER ON";
                tradd1.Visible = false;
                tradd2.Visible = false;
                _8pft.Visible = false;
                if (lblprj.Text == "ASAO")
                {
                    lblhead.Text = "CAS M9 Fuel Systems Commissioning Activity Schedule";
                    td_0.Visible = false; td_lbnum.Visible = false; td_lbl1.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
                }
                else if (lblprj.Text == "CCAD")
                {
                    if (lblsch.Text == "8")
                        lblhead.Text = "6.3.1 - Chilled Water System Commissioning Activity Schedule";
                    else if (lblsch.Text == "51")
                        lblhead.Text = "6.3.2 - Hot Water System (MTHW) Commissioning Activity Schedule";
                    else if (lblsch.Text == "52")
                        lblhead.Text = "6.3.3 - Heat Recovery and Terminal Reheat Systems Commissioning Activity Schedule";
                    else if (lblsch.Text == "53")
                        lblhead.Text = "6.3.4 - Generator Cooling Radiator System Commissioning Activity Schedule";
                    else if (lblsch.Text == "54")
                        lblhead.Text = "6.3.5 - Steam System Commissioning Activity Schedule";
                    else if (lblsch.Text == "55")
                        lblhead.Text = "6.3.6 - Air Handling Systems Commissioning Activity Schedule";
                    else if (lblsch.Text == "56")
                        lblhead.Text = "6.3.7 - Ventilation Systems Commissioning Activity Schedule";
                    else if (lblsch.Text == "57")
                        lblhead.Text = "6.3.8 - Fan Coil Units Commissioning Activity Schedule";
                    else if (lblsch.Text == "58")
                        lblhead.Text = "6.3.9 - Close Control Air Condition Units Commissioning Activity Schedule";
                    else if (lblsch.Text == "59")
                        lblhead.Text = "6.3.10 - Life Safety Ventilation Systems Commissioning Activity Schedule";
                    else if (lblsch.Text == "60")
                        lblhead.Text = "6.3.11 - Clean Room Systems Commissioning Activity Schedule";
                    else if (lblsch.Text == "61")
                        lblhead.Text = "6.3.6.1 - VAV Commissioning Activity Schedule";
                    else if (lblsch.Text == "62")
                        lblhead.Text = "6.3.6.2 - ECV Commissioning Activity Schedule";
                    else if (lblsch.Text == "63")
                        lblhead.Text = "6.3.6.1.1 - CUP - HVAC Systems 1-14 Commissioning Activity Schedule";
                    else if (lblsch.Text == "64")
                        lblhead.Text = "6.3.6.1.2 - CLINIC - HVAC Systems 15 Commissioning Activity Schedule";
                    else if (lblsch.Text == "65")
                        lblhead.Text = "6.3.6.1.3 - D&T - HVAC Systems 16&17 Commissioning Activity Schedule";
                    else if (lblsch.Text == "66")
                        lblhead.Text = "6.3.6.1.4 - D&T - HVAC Systems 17&18 Commissioning Activity Schedule";
                    else if (lblsch.Text == "67")
                        lblhead.Text = "6.3.6.1.5 - ICU - HVAC Systems 20 Commissioning Activity Schedule";
                    else if (lblsch.Text == "68")
                        lblhead.Text = "6.3.6.1.6 - SWING WING - HVAC Systems 21 Commissioning Activity Schedule";
                    else if (lblsch.Text == "69")
                        lblhead.Text = "6.3.6.1.7 - PATIENT TOWER - HVAC Systems 22 Commissioning Activity Schedule";
                    else if (lblsch.Text == "70")
                        lblhead.Text = "6.3.6.1.8 - PATIENT TOWER - HVAC Systems 23 Commissioning Activity Schedule";
                    else if (lblsch.Text == "71")
                        lblhead.Text = "6.3.6.1.9 - PATIENT TOWER - HVAC Systems 26&27 Commissioning Activity Schedule";
                    else if (lblsch.Text == "72")
                        lblhead.Text = "6.3.6.1.10 - CAR PARK Commissioning Activity Schedule";
                    else if (lblsch.Text == "73")
                        lblhead.Text = "6.3.6.1.11 - MISC Commissioning Activity Schedule";
                    else if (lblsch.Text == "74")
                        lblhead.Text = "6.3.6.2.1 - CUP - HVAC Systems 1-14 Commissioning Activity Schedule";
                    else if (lblsch.Text == "75")
                        lblhead.Text = "6.3.6.2.2 - CLINIC - HVAC Systems 15 Commissioning Activity Schedule";
                    else if (lblsch.Text == "76")
                        lblhead.Text = "6.3.6.2.3 - D&T - HVAC Systems 16&17 Commissioning Activity Schedule";
                    else if (lblsch.Text == "77")
                        lblhead.Text = "6.3.6.2.4 - D&T - HVAC Systems 17&18 Commissioning Activity Schedule";
                    else if (lblsch.Text == "78")
                        lblhead.Text = "6.3.6.2.5 - ICU - HVAC Systems 20 Commissioning Activity Schedule";
                    else if (lblsch.Text == "79")
                        lblhead.Text = "6.3.6.2.6 - SWING WING - HVAC Systems 21 Commissioning Activity Schedule";
                    else if (lblsch.Text == "80")
                        lblhead.Text = "6.3.6.2.7 - PATIENT TOWER - HVAC Systems 22 Commissioning Activity Schedule";
                    else if (lblsch.Text == "81")
                        lblhead.Text = "6.3.6.2.8 - PATIENT TOWER - HVAC Systems 23 Commissioning Activity Schedule";
                    else if (lblsch.Text == "82")
                        lblhead.Text = "6.3.6.2.9 - PATIENT TOWER - HVAC Systems 26&27 Commissioning Activity Schedule";
                    else if (lblsch.Text == "83")
                        lblhead.Text = "6.3.6.2.10 - CAR PARK Commissioning Activity Schedule";
                    else if (lblsch.Text == "84")
                        lblhead.Text = "6.3.6.2.11 - MISC Commissioning Activity Schedule";
                    td_0.Visible = false; td_lbl1.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
                    lbnum.Text = "Design Volume (l/s)";
                    lblduty8.Text = "OBTAINED PERCENTAGE %";
                    lblppon.Text = "PLANT START UP COMPLETE";
                    tradd1.Visible = true;
                    tradd2.Visible = true;
                    _8pft.Visible = true;
                }
                else
                {
                    lblhead.Text = "CAS M1 Mechanical Services Commissioning Activity Schedule";
                    td_0.Visible = false; td_lbnum.Visible = false; td_lbl1.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
                }


            }
            else if (lblsch.Text == "9")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "";
                if ((string)Session["project"] == "CCAD")
                {
                    if(lblsch1.Text=="30")
                        lblhead.Text = "CAS 2B MFSD > CUP - HVAC Systems 1-14 Testing Commissioning Activity Schedule";
                    else if (lblsch1.Text == "31")
                        lblhead.Text = "CAS 2B MFSD > CLINIC - HVAC Systems 15 Testing Commissioning Activity Schedule";
                    else if (lblsch1.Text == "32")
                        lblhead.Text = "CAS 2B MFSD > CLINIC - HVAC Systems 16&17 Testing Commissioning Activity Schedule";
                    else if (lblsch1.Text == "33")
                        lblhead.Text = "CAS 2B MFSD > CLINIC - HVAC Systems 17&18 Testing Commissioning Activity Schedule";
                    else if (lblsch1.Text == "34")
                        lblhead.Text = "CAS 2B MFSD > ICU - HVAC Systems 20 Testing Commissioning Activity Schedule";
                    else if (lblsch1.Text == "35")
                        lblhead.Text = "CAS 2B MFSD > SWING WING - HVAC Systems 21 Testing Commissioning Activity Schedule";
                    else if (lblsch1.Text == "36")
                        lblhead.Text = "CAS 2B MFSD > PATIENT TOWER -  HVAC Systems 22 Testing Commissioning Activity Schedule";
                    else if (lblsch1.Text == "37")
                        lblhead.Text = "CAS 2B MFSD > PATIENT TOWER - HVAC Systems 23 Testing Commissioning Activity Schedule";
                    else if (lblsch1.Text == "38")
                        lblhead.Text = "CAS 2B MFSD > PATIENT TOWER - HVAC Systems 26&27 Testing Commissioning Activity Schedule";
                    else if (lblsch1.Text == "39")
                        lblhead.Text = "CAS 2B MFSD > CAR PARK Testing Commissioning Activity Schedule";
                    else if (lblsch1.Text == "40")
                        lblhead.Text = "CAS 2B MFSD > MISC Testing Commissioning Activity Schedule";
                    td_lbnum.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
                    lbdes.Text = "DESCRIPTION/ SIZE";
                    lbloc.Text = "LOCATION AREA";
                    lbl3.Text = "ROOM REFERENCE";
                    lbl1.Text = "PLANT/ SYSTEM DESCRIPTION";
                    //lbnum.Text = "Design Volume (l/s)";
                    //txtnoof.Visible = true;
                }
                else
                {
                    drfed.Style.Add("display", "none");
                    lblhead.Text = "CAS M3 Fusible Link Fire Dampers & MSFD Commissioning Activity Schedule";
                    td_0.Visible = false; td_lbnum.Visible = false; td_lbl1.Visible = false; td_3.Visible = false; td_lbl3.Visible = false; td_1.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
                }
            }
            else if (lblsch.Text == "2" || lblsch.Text == "121" || lblsch.Text == "119" || lblsch.Text == "118")
            {
                if ((string)Session["project"] == "CCAD")
                {
                    lbl1.Text = "PROVIDES POWER TO";
                    lbl2.Text = "SUBSTATION NUMBER";
                    lbl3.Text = "FED FROM";
                    lbnum.Text = "TOTAL NO.OF CIRCUITS";
                    if (lblsch.Text == "121")
                        lblhead.Text = "6.1.2.1 - Switchgear Commissioning Activity Schedule";
                    else if(lblsch.Text=="119")
                        lblhead.Text = "6.1.3.1 - Switchgear Commissioning Activity Schedule";
                    else if(lblsch.Text=="118")
                        lblhead.Text = "6.1.4.1 - Switchgear Commissioning Activity Schedule";
                    td_lbldes.Visible = false; td_txtdescr.Visible = false;
                }
            }
            else if (lblsch.Text == "5" || lblsch.Text=="44")
            {
                lbnum.Text = "NO.OF CIRCUITS";
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                if ((string)Session["project"] == "CCAD")
                {
                    if(lblsch.Text=="5")
                        lblhead.Text = "6.1.5 - LV Electrical Distribution (415V) Commissioning Activity Schedule";
                    else if(lblsch.Text=="44")
                        lblhead.Text = "6.1.7 - Un-interruptible Power Supplies/ Battery System Commissioning Activity Schedule";
                    lbl2.Text = "SUBSTATION NUMBER";
                    td_lbldes.Visible = false; td_txtdescr.Visible = false;
                }
                else
                {
                    lblhead.Text = "CAS E4 Electrical Services. LV Commissioning Activity Schedule";
                    td_2.Visible = false; td_lbl2.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
                }

            }
            else if (lblsch.Text == "4")
            {
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "SUBSTATION";
                lbl3.Text = "FED FROM";
                td_2.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_lbnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
                lblhead.Text = "6.1.4.2 - Generator Commissioning Activity Schedule";
            }
            else if (lblsch.Text == "6")
            {
                lbl1.Text = "PROVIDES EARTHING TO";
                lblhead.Text = "6.1.1 - Earthing and Lightning Protection Commissioning Activity Schedule";
                td_2.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_lbnum.Visible = false; td_1.Visible = false; td_lbl3.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if ((string)Session["sch"] == "3" || (string)Session["sch"]=="120")
            {
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "AREA";
                lbl3.Text = "FED FROM";
                lbl2.Text = "SUB STATION NUMBER";
                lbnum.Text = "QUANTITY";
                if((string)Session["sch"]=="3")
                    lblhead.Text = "6.1.3.2 - Transformer Commissioning Activity Schedule";
                else if ((string)Session["sch"] == "120")
                    lblhead.Text = "6.1.2.2 - Transformer Commissioning Activity Schedule";
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if ((string)Session["sch"] == "7")
            {
                lbnum.Text = "NO.OF EMERGENCY LIGHTS";
                lbl1.Text = "";
                lbl3.Text = "";
                lbl2.Text = "";
                lbl1.Text = "PROVIDES POWER TO";
                lbl3.Text = "FED FROM";
                lbnum.Text = "NO.OF LAMPS";
                lbl2.Text = "TOTAL NO.OF CIRCUITS";
                lblhead.Text = "6.1.6 - Central Battery Emergency Lighting Commissioning Activity Schedule";
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if ((string)Session["sch"] == "10")
            {
                lbl1.Text = "";
                lbl2.Text = "NO.OF DEVICES";
                lbl3.Text = "";
                lbnum.Text = "NO.OF INTERFACES";
                drfed.Style.Add("display", "none");
                lblhead.Text = "CAS 3C - ELV - Fire Detection and Alarm System(FDAS) Commissioning Activity Schedule";
                lbl1.Text = "LOOP CIRCUIT NO.";
                td_lbl3.Visible = false; td_1.Visible = false; td_txtdescr.Visible = false; td_lbldes.Visible = false;
            }
            else if ((string)Session["sch"] == "20")
            {
                drfed.Style.Add("display", "none");
                lblhead.Text = "6.2.2 - Energy Management and Control Systems (EMCS) Commissioning Activity Schedule";
                lbnum.Text = "NO.OF POINTS";
                lbl3.Text = "SYSTEM CONTROLLED/ MONITORED";
                td_lbl1.Visible = false; td_0.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if ((string)Session["sch"] == "23")
            {
                lbl1.Text = "SYSTEM MONITORED";
                lbl2.Text = "";
                lbl3.Text = "GATEWAY/ LOOP";
                lbnum.Text = "NO.OF IED DEVICE";
                lblhead.Text = "6.2.4 - Power Management and Control Systems (PMCS) Commissioning Activity Schedule";
                td_lbl2.Visible = false; td_2.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if ((string)Session["sch"] == "11")
            {
                drfed.Style.Add("display", "none");
                lblhead.Text = "CAS 3D - ELV - Public Address and Mass Notification(PAMN) System Commissioning Activity Schedule";
                lbloc.Text = "LOCATION";
                lbnum.Text = "NO.OF DEVICES PER CIRCUIT";
                td_lbl2.Visible = false; td_2.Visible = false;
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
                td_lbl3.Visible = false;
                td_1.Visible = false;
                td_lbl1.Visible = false;
                td_0.Visible = false;
            }
            else if ((string)Session["sch"] == "15")
            {
                lbnum.Text = "NO.OF PANELS";
                drfed.Style.Add("display", "none");
                drloc.Style.Add("display", "none");
                lblhead.Text = "6.2.14 - Master Antenna Television System (MATV) Commissioning Activity Schedule";
                lbnum.Text = "NO.OF POINTS PER OUTLET";
                lbl1.Text = "AREA COVERED";
                lbl3.Text = "FED FROM";
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
                td_lbl2.Visible = false;
                td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "13")
            {
                drfed.Style.Add("display", "none");
                lblhead.Text = "6.2.6 - Closed Circuit Television (CCTV) Commissioning Activity Schedule";
                lbl3.Text = "AREA MONITORED";
                lbnum.Text = "NO.OF POINTS/ CAMERAS";
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
                td_lbl1.Visible = false;
                td_0.Visible = false;
                td_lbl2.Visible = false;
                td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "16")
            {
                lbl3.Text = "FED FROM";
                lblhead.Text = "6.2.8 - Intercom Systems (Audio, Video and Healthcare) Commissioning Activity Schedule";
                lbl1.Text = "AREA COVERED";
                lbnum.Text = "NO.OF VIDEO STATION";
                td_lbl2.Visible = false; td_2.Visible = false;
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if ((string)Session["sch"] == "14")
            {
                drfed.Style.Add("display", "none");
                lblhead.Text = "6.2.15 - Audio Visual System (AV) Commissioning Activity Schedule";
                lbnum.Text = "NO.OF CIRCUITS";
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
                td_lbl3.Visible = false;
                td_1.Visible = false;
                td_lbl1.Visible = false;
                td_0.Visible = false;
                td_lbl2.Visible = false;
                td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "24")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                lbl3.Text = "AREA COVERED";
                lbnum.Text = "NO.OF PANEL";
                lblhead.Text = "6.2.11 - Nurse Call and Code Blue System Commissioning Activity Schedule";
                td_txtdescr.Visible = false; td_lbldes.Visible = false;
                td_lbl1.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "25")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                lblhead.Text = "6.2.13 - Master Clock System Commissioning Activity Schedule";
                lbnum.Text = "NO.OF CODE BLUE/ ELAPSED TIMERS";
                td_txtdescr.Visible = false; td_lbldes.Visible = false; td_lbl3.Visible = false; td_1.Visible = false;
                td_lbl1.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "26")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                lbnum.Text = "NO.OF VALVE SETS";
                lblhead.Text = "CAS 3M - ELV - Intercom & Healthcare Communications and Monitoring(IHCM) System Commissioning Activity Schedule";
                td_lbnum.Visible = false; td_3.Visible = false; td_lbl3.Visible = false; td_1.Visible = false; td_txtdescr.Visible = false; td_lbldes.Visible = false;
                td_lbl1.Visible = false;
                td_0.Visible = false;
                td_lbl2.Visible = false;
                td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "22")
            {
                lblhead.Text = "6.2.5 - Access Control Systems (ACS) Incorporating Intruder Detection System (IDS) Commissioning Activity Schedule";
                lbnum.Text = "NO.OF POINTS";
                lbl3.Text = "AREA COVERED";
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
                td_lbl1.Visible = false;
                td_0.Visible = false;
                td_lbl2.Visible = false;
                td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "17")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                if (lblsch.Text == "85")
                    lblhead.Text = "6.4.1 - Domestic Cold Water Service Commissioning Activity Schedule";
                else if (lblsch.Text == "86")
                    lblhead.Text = "6.4.2 - Domestic Hot Water Service Commissioning Activity Schedule";
                else if (lblsch.Text == "87")
                    lblhead.Text = "6.4.3 - Waste Water System Commissioning Activity Schedule";
                else if (lblsch.Text == "88")
                    lblhead.Text = "6.4.4 - Grey Water System Commissioning Activity Schedule";
                else if (lblsch.Text == "89")
                    lblhead.Text = "6.4.5 - Storm Water System Commissioning Activity Schedule";
                else if (lblsch.Text == "90")
                    lblhead.Text = "6.4.6 - Condensate Water Collection Commissioning Activity Schedule";
                else if (lblsch.Text == "91")
                    lblhead.Text = "6.4.7 - Soil (Black Water) System Commissioning Activity Schedule";
                else if (lblsch.Text == "99")
                    lblhead.Text = "6.4.15 - Fuel Tank System Commissioning Activity Schedule";
                else if (lblsch.Text == "107")
                    lblhead.Text = "6.5.5 - Water Features Commissioning Activity Schedule";
                else if (lblsch.Text == "99")
                    lblhead.Text = "6.5.6 - Irrigation System Commissioning Activity Schedule";
                else if (lblsch.Text == "117")
                    lblhead.Text = "6.7.1 - Solar Hot Water System Commissioning Activity Schedule";
                lbnum.Text = "DESIGN VOLUME l/s";
                td_0.Visible = false; td_lbl1.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "19")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";

                lblhead.Text = "6.4.10.2 - Fire Protection Distribution Systems Commissioning Activity Schedule";
                td_lbl0.Visible = false; td0.Visible = false; drloc.Visible = false; td_lbl3.Visible = false; td_1.Visible = false;
                lbnum.Text = "QUANTITY";
                td_0.Visible = false; td_lbl1.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "27")
            {
                
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                if (lblprj.Text == "12761")
                {
                    lblhead.Text = "Lifts & Escalators Commissioning Activity Schedule";
                }
                else
                {
                    if (lblsch.Text == "103")
                        lblhead.Text = "6.5.1 - Lifts Commissioning Activity Schedule";
                    else if (lblsch.Text == "104")
                        lblhead.Text = "6.5.2 - Escalators Commissioning Activity Schedule";
                    else if (lblsch.Text == "105")
                        lblhead.Text = "6.5.3 - Building Maintenance Units and Interfaces Commissioning Activity Schedule";
                    else if (lblsch.Text == "106")
                        lblhead.Text = "6.5.4 - Motorised and Roller Shutter Doors Commissioning Activity Schedule";
                    else if (lblsch.Text == "109")
                        lblhead.Text = "6.5.7 - Kitchen Equipment Commissioning Activity Schedule";
                    else if (lblsch.Text == "110")
                        lblhead.Text = "6.5.8 - Waste Management Equipment Commissioning Activity Schedule";
                    else if (lblsch.Text == "111")
                        lblhead.Text = "6.5.9 - Load Dock/ Good Handling Equipment Commissioning Activity Schedule";
                }
                lbnum.Text = "NO.OF POINTS";
                td_lbl3.Visible = false; td_1.Visible = false;
                td_lbl1.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "46")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                lblhead.Text = "6.2.12 - Car Park Management and Vehicle Intrusion Defence Commissioning Activity Schedule";
                lbnum.Text = "NO.OF POINTS";
                td_lbl3.Visible = false; td_1.Visible = false;
                td_lbl1.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "112")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                if (lblsch.Text == "112")
                    lblhead.Text = "6.6.1 - Medical Gases Commissioning Activity Schedule";
                else if (lblsch.Text == "113")
                    lblhead.Text = "6.6.2 - Waste Anaesthetic Gas Disposal Commissioning Activity Schedule";
                else if (lblsch.Text == "114")
                    lblhead.Text = "6.6.3 - Compress Air Commissioning Activity Schedule";
                else if (lblsch.Text == "115")
                    lblhead.Text = "6.6.4 - Vacuum Commissioning Activity Schedule";
                                    else if (lblsch.Text == "116")
                    lblhead.Text = "6.6.5 - Medical Equipment Interfacing Commissioning Activity Schedule";
                else if (lblsch.Text == "116")
                    lblhead.Text = "6.6.5 - Medical Equipment Interfacing Commissioning Activity Schedule";

                lbnum.Text = "";
                td_lbl3.Visible = true; td_1.Visible = true;
                td_lbl1.Visible = false;
                td_0.Visible = false;
                td_lbnum.Visible = false;
                td_3.Visible = false;

                td_lbl1.Visible = false;  td_lbl2.Visible = false; td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "28")
            {
                if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "6.4.16 - Pneumatic Tube System Commissioning Activity Schedule";
                    td_lbnum.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
                    lbdes.Text = "DESCRIPTION";
                    lbloc.Text = "LOCATION";
                    lbl3.Text = "FED FROM (System Component)";
                    lbl1.Text = "FED FROM (Electrical)";
                }

            }
            else if ((string)Session["sch"] == "29")
            {
                if ((string)Session["project"] == "CCAD")
                {
                    lblhead.Text = "6.2.7 - Lighting Control Systems Commissioning Activity Schedule";
                    lbnum.Text = "NO. OF CHANNELS/ MODULES";
                    lbl3.Text = "AREA COVERED";
                    td_lbl1.Visible = false; td_0.Visible = false; td_lbl2.Visible = false; td_2.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
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
            _objcas.sch = Convert.ToInt32(lblsch1.Text);
            _objcas.prj_code = lblprj.Text;
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
            _dtresult = _dtMaster;
        }
        private void Load_InitialData()
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
                //if(_exp==false)
                //    _mydetails.Visible = false;
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
            if (lblsch.Text == "8" || lblsch.Text == "51" || lblsch.Text == "52" || lblsch.Text == "53" || lblsch.Text == "54" || lblsch.Text == "55" || lblsch.Text == "56" || lblsch.Text == "57" || lblsch.Text == "58" || lblsch.Text == "59" || lblsch.Text == "60" || lblsch.Text == "62" || lblsch.Text == "63" || lblsch.Text == "64" || lblsch.Text == "65" || lblsch.Text == "66" || lblsch.Text == "67" || lblsch.Text == "68" || lblsch.Text == "69" || lblsch.Text == "70" || lblsch.Text == "71" || lblsch.Text == "72" || lblsch.Text == "73" || lblsch.Text == "74" || lblsch.Text == "75" || lblsch.Text == "76" || lblsch.Text == "77" || lblsch.Text == "78" || lblsch.Text == "79" || lblsch.Text == "80" || lblsch.Text == "81" || lblsch.Text == "82" || lblsch.Text == "83" || lblsch.Text == "84") { btnDummy_ModalPopupExtender7.Show(); _8lbl.Text = _title; }
            else if (lblsch.Text == "9")
            {
                btnDummy_ModalPopupExtender9.Show();
                _9lbl.Text = _title;
            }
            else if (lblsch.Text == "2" || lblsch.Text == "121" || lblsch.Text == "119" || lblsch.Text == "118")
            {
                btnDummy_ModalPopupExtender1.Show();
                _2lbl.Text = _title;
            }
            else if (lblsch.Text == "5" || lblsch.Text=="44")
            {
                btnDummy_ModalPopupExtender4.Show();
                _5lbl.Text = _title;
            }
            else if (lblsch.Text == "4")
            {
                btnDummy_ModalPopupExtender5.Show();
                _4lbl.Text = _title;
            }
            else if (lblsch.Text == "6")
            {
                btnDummy_ModalPopupExtender3.Show();
                _6lbl.Text = _title;
            }
            else if (lblsch.Text == "3" || lblsch.Text == "120")
            {
                btnDummy_ModalPopupExtender2.Show();
                _3lbl.Text = _title;
            }
            else if (lblsch.Text == "7")
            {
                btnDummy_ModalPopupExtender6.Show();
                _7lbl.Text = _title;
            }
            else if (lblsch.Text == "10")
            {
                btnDummy_ModalPopupExtender13.Show();
                _10lbl.Text = _title;
            }
            else if (lblsch.Text == "20")
            {
                btnDummy_ModalPopupExtender14.Show();
                _20lbl.Text = _title;
            }
            else if (lblsch.Text == "23")
            {
                btnDummy_ModalPopupExtender21.Show();
                _23lbl.Text = _title;
            }
            else if (lblsch.Text == "11")
            {
                btnDummy_ModalPopupExtender17.Show();
                _11lbl.Text = _title;
            }
            else if (lblsch.Text == "22")
            {
                btnDummy_ModalPopupExtender16.Show();
                _22lbl.Text = _title;
            }
            else if (lblsch.Text == "15")
            {
                btnDummy_ModalPopupExtender19.Show();
                _15lbl.Text = _title;
            }
            else if (lblsch.Text == "13")
            {
                btnDummy_ModalPopupExtender15.Show();
                _13lbl.Text = _title;
            }
            else if (lblsch.Text == "16")
            {
                btnDummy_ModalPopupExtender22.Show();
                _16lbl.Text = _title;
            }
            else if (lblsch.Text == "14")
            {
                btnDummy_ModalPopupExtender20.Show();
                _14lbl.Text = _title;
            }
            else if (lblsch.Text == "24")
            {
                btnDummy_ModalPopupExtender23.Show();
                _24lbl.Text = _title;
            }
            else if (lblsch.Text == "25")
            {
                btnDummy_ModalPopupExtender25.Show();
                _25lbl.Text = _title;
            }
            else if (lblsch.Text == "26")
            {
                btnDummy_ModalPopupExtender29.Show();
                _26lbl.Text = _title;
            }
            else if (lblsch.Text == "17" || lblsch.Text == "85" || lblsch.Text == "86" || lblsch.Text == "87" || lblsch.Text == "88" || lblsch.Text == "89" || lblsch.Text == "90" || lblsch.Text == "91" || lblsch.Text == "99" || lblsch.Text == "107" || lblsch.Text == "108" || lblsch.Text == "117")
            {
                btnDummy_ModalPopupExtender10.Show();
                _17lbl.Text = _title;
            }
            else if (lblsch.Text == "19")
            {
                btnDummy_ModalPopupExtender12.Show();
                _19lbl.Text = _title;
            }
            else if (lblsch.Text == "112" || lblsch.Text == "113" || lblsch.Text == "114" || lblsch.Text == "115" || lblsch.Text == "116")
            {
                btnDummy_ModalPopupExtender112.Show();
                _112lbl.Text = _title;
            }
            else if (lblsch.Text == "27" || lblsch.Text == "46")
            {
                btnDummy_ModalPopupExtender30.Show();
                _27lbl.Text = _title;
                _27pft.Text = "N/A";
                _27pc1.Text = "N/A";
                _27pc2.Text = "N/A";
                _27comm1.Text = "N/A";
            }
            else if (lblsch.Text == "28")
            {
                btnDummy_ModalPopupExtender26.Show();
                _28lbl.Text = _title;

            }
            else if (lblsch.Text == "29")
            {
                btnDummy_ModalPopupExtender27.Show();
                _29lbl.Text = _title;

            }
            //else if (lblsch.Text == "17") { btnDummy_ModalPopupExtender10.Show(); _17lbl.Text = _title; }
            //else if (lblsch.Text == "18") { btnDummy_ModalPopupExtender11.Show(); _18lbl.Text = _title; }
            //else if (lblsch.Text == "19") { btnDummy_ModalPopupExtender12.Show(); _19lbl.Text = _title; }
            //else if (lblsch.Text == "10") { btnDummy_ModalPopupExtender13.Show(); _10lbl.Text = _title; }
            //else if (lblsch.Text == "20") { btnDummy_ModalPopupExtender14.Show(); _20lbl.Text = _title; }
            //else if (lblsch.Text == "13") { btnDummy_ModalPopupExtender15.Show(); _13lbl.Text = _title; }
            //else if (lblsch.Text == "22") { btnDummy_ModalPopupExtender16.Show(); _22lbl.Text = _title; }
            //else if (lblsch.Text == "11") { btnDummy_ModalPopupExtender17.Show(); _11lbl.Text = _title; }
            //else if (lblsch.Text == "12") { btnDummy_ModalPopupExtender18.Show(); _12lbl.Text = _title; }
            //else if (lblsch.Text == "15") { btnDummy_ModalPopupExtender19.Show(); _15lbl.Text = _title; }
            //else if (lblsch.Text == "14") { btnDummy_ModalPopupExtender20.Show(); _14lbl.Text = _title; }
            //else if (lblsch.Text == "23")
            //{
            //    if ((string)Session["cat"] == "LIFT")
            //    {
            //        _23eml.Enabled = true; _23lms.Enabled = true; _23int.Enabled = true;
            //    }
            //    else if ((string)Session["cat"] == "ESC")
            //    {
            //        _23eml.Text = "N/A"; _23lms.Text = "N/A"; _23int.Text = "N/A"; _23eml.Enabled = false; _23lms.Enabled = false; _23int.Enabled = false;
            //    }
            //    btnDummy_ModalPopupExtender21.Show();
            //    _23lbl.Text = _title;
            //}
            //else if (lblsch.Text == "16") { btnDummy_ModalPopupExtender22.Show(); _16lbl.Text = _title; }
            //else if (lblsch.Text == "24") { btnDummy_ModalPopupExtender23.Show(); _24lbl.Text = _title; }
            //else if (lblsch.Text == "30") { btnDummy_ModalPopupExtender24.Show(); _30lbl.Text = _title; }
            //else if (lblsch.Text == "25") { btnDummy_ModalPopupExtender25.Show(); _25lbl.Text = _title; }
            //else if (lblsch.Text == "26") { btnDummy_ModalPopupExtender25.Show(); _25lbl.Text = _title; }
            //else if (lblsch.Text == "28") { btnDummy_ModalPopupExtender26.Show(); _28lbl.Text = _title; }
            //else if (lblsch.Text == "29") { btnDummy_ModalPopupExtender11.Show(); _18lbl.Text = _title; }
            //else if (lblsch.Text == "34") { btnDummy_ModalPopupExtender27.Show(); _34lbl.Text = _title; }
            //else if (lblsch.Text == "35") { btnDummy_ModalPopupExtender28.Show(); _35lbl.Text = _title; }
            //else if (lblsch.Text == "36") { btnDummy_ModalPopupExtender29.Show(); _36lbl.Text = _title; }
            //else if (lblsch.Text == "32") { btnDummy_ModalPopupExtender14.Show(); _20lbl.Text = _title; }
            //else if (lblsch.Text == "31") { btnDummy_ModalPopupExtender13.Show(); _10lbl.Text = _title; }

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
            if (lblsch.Text == "8" || lblsch.Text == "51" || lblsch.Text == "52" || lblsch.Text == "53" || lblsch.Text == "54" || lblsch.Text == "55" || lblsch.Text == "56" || lblsch.Text == "57" || lblsch.Text == "58" || lblsch.Text == "59" || lblsch.Text == "60" || lblsch.Text == "62" || lblsch.Text == "63" || lblsch.Text == "64" || lblsch.Text == "65" || lblsch.Text == "66" || lblsch.Text == "67" || lblsch.Text == "68" || lblsch.Text == "69" || lblsch.Text == "70" || lblsch.Text == "71" || lblsch.Text == "72" || lblsch.Text == "73" || lblsch.Text == "74" || lblsch.Text == "75" || lblsch.Text == "76" || lblsch.Text == "77" || lblsch.Text == "78" || lblsch.Text == "79" || lblsch.Text == "80" || lblsch.Text == "81" || lblsch.Text == "82" || lblsch.Text == "83" || lblsch.Text == "84")
            {
                if (lblprj.Text == "CCAD")
                { e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false; }
                else
                {
                    e.Row.Cells[10].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[11].Visible = false;
                }
            }
            else if (lblsch.Text == "9")
            {
                if ((string)Session["project"] == "CCAD")
                { e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; }
                else
                {
                    e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false;
                }
            }
            else if (lblsch.Text == "2" || lblsch.Text == "121" || lblsch.Text == "118" || lblsch.Text == "119")
            {
                if ((string)Session["project"] == "CCAD")
                { e.Row.Cells[7].Visible = false; }
                else
                {
                    e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
                }
            }
            else if ((string)Session["sch"] == "5")
            {
                if ((string)Session["project"] == "CCAD")
                    e.Row.Cells[7].Visible = false;
                else
                {
                    e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
                }
            }
            else if (lblsch.Text == "4")
            {
                e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "6")
            {
                e.Row.Cells[9].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "3" || lblsch.Text == "120")
            {
                e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "7")
            {
                e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "10")
            {
                e.Row.Cells[7].Visible = false; e.Row.Cells[9].Visible = false;
            }
            else if (lblsch.Text == "20")
            {
                e.Row.Cells[7].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "23")
            {
                e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "11")
            {
                e.Row.Cells[11].Visible = false;
                e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "15")
            {
                e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "13")
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "16")
            {
                e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "14")
            {
                e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "24")
            {
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "25")
            {
                e.Row.Cells[7].Visible = false; e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "26")
            {
                e.Row.Cells[7].Visible = false; e.Row.Cells[9].Visible = false; e.Row.Cells[12].Visible = false;
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "22")
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "112")
            {
                e.Row.Cells[10].Visible = false; 
                //e.Row.Cells[7].Visible = false; 
                e.Row.Cells[11].Visible = false;
               e.Row.Cells[12].Visible = false;
            }
            else if ((string)Session["sch"] == "17")
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "19")
            {
                e.Row.Cells[8].Visible = false; e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "27" || lblsch.Text == "46")
            {
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if (lblsch.Text == "28")
            {
                e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false;
            }
            else if ((string)Session["sch"] == "29")
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
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

            int count = 0;
            if (lblsch.Text == "8" || lblsch.Text == "51" || lblsch.Text == "52" || lblsch.Text == "53" || lblsch.Text == "54" || lblsch.Text == "55" || lblsch.Text == "56" || lblsch.Text == "57" || lblsch.Text == "58" || lblsch.Text == "59" || lblsch.Text == "60" || lblsch.Text == "62" || lblsch.Text == "63" || lblsch.Text == "64" || lblsch.Text == "65" || lblsch.Text == "66" || lblsch.Text == "67" || lblsch.Text == "68" || lblsch.Text == "69" || lblsch.Text == "70" || lblsch.Text == "71" || lblsch.Text == "72" || lblsch.Text == "73" || lblsch.Text == "74" || lblsch.Text == "75" || lblsch.Text == "76" || lblsch.Text == "77" || lblsch.Text == "78" || lblsch.Text == "79" || lblsch.Text == "80" || lblsch.Text == "81" || lblsch.Text == "82" || lblsch.Text == "83" || lblsch.Text == "84")
            {
                if (_8pc1.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "9")
            {
                if (DateValidation(_9pic.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "2" || lblsch.Text == "121" || lblsch.Text == "118" || lblsch.Text == "119")
            {
                if ((string)Session["cat"] == "RMU")
                {
                    if (_2tor.Text != "")
                        count += 1;
                    if (_2ir.Text != "")
                        count += 1;
                    if (_2hi.Text != "")
                        count += 1;
                    if (_2pi.Text != "")
                        count += 1;
                    if (_2cr.Text != "")
                        count += 1;
                    if (_2ct.Text != "")
                        count += 1;
                    if (_2rt.Text != "")
                        count += 1;
                    if (_2fn.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 8) * 100;
                }
                else
                {
                    if (_2tor.Text != "")
                        count += 1;
                    if (_2ir.Text != "")
                        count += 1;
                    if (_2hi.Text != "")
                        count += 1;
                    if (_2pi.Text != "")
                        count += 1;
                    if (_2cr.Text != "")
                        count += 1;
                    if (_2pt.Text != "")
                        count += 1;
                    if (_2ct.Text != "")
                        count += 1;
                    if (_2rt.Text != "")
                        count += 1;
                    if (_2fn.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 9) * 100;
                }
            }
            else if (lblsch.Text == "5" || lblsch.Text=="44")
            {
                if ((string)Session["cat"] == "PFC")
                {
                    if (_5ir.Text != "")
                        count += 1;
                    if (_5fn.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 2) * 100;
                }
                else if ((string)Session["cat"] == "BDT")
                {
                    if (_5tor.Text != "")
                        count += 1;
                    if (_5ir.Text != "")
                        count += 1;
                    if (_5cr.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 3) * 100;
                }
                else if ((string)Session["cat"] == "SMDB")
                {
                    if (_5ir.Text != "")
                        count += 1;
                    if (_5pi.Text != "")
                        count += 1;
                    if (_5cr.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 3) * 100;
                }
                else if ((string)Session["cat"] == "ATS" || (string)Session["cat"] == "VFD")
                {
                    if (_5fn.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 1) * 100;
                }
                else if ((string)Session["cat"] == "DB")
                {
                    _percentage = 0;
                }
                //else if ((string)Session["cat"] == "MCC")
                //{
                //    if (_5tor.Text != "")
                //        count += 1;
                //    if (_5ir.Text != "")
                //        count += 1;
                //    if (_5pr.Text != "")
                //        count += 1;
                //    if (_5pi.Text != "")
                //        count += 1;
                //    if (_5cr.Text != "")
                //        count += 1;
                //    if (_5fn.Text != "")
                //        count += 1;
                //    _percentage = (Convert.ToDecimal(count) / 6) * 100;
                //}
                else
                {
                    if (_5tor.Text != "")
                        count += 1;
                    if (_5ir.Text != "")
                        count += 1;
                    if (_5pr.Text != "")
                        count += 1;
                    if (_5pi.Text != "")
                        count += 1;
                    if (_5si.Text != "")
                        count += 1;
                    if (_5cr.Text != "")
                        count += 1;
                    if (_5fn.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 7) * 100;
                }
            }
            else if (lblsch.Text == "4")
            {

                if ((string)Session["cat"] == "GEN")
                {
                    if (_4pc.Text != "")
                        count += 1;
                    if (_4irt.Text != "")
                        count += 1;
                    if (_4lt.Text != "")
                        count += 1;
                    if (_4ft.Text != "")
                        count += 1;
                    if (_4frt.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 5) * 100;
                }
                else
                {
                    if (_4pc.Text != "")
                        count += 1;
                    if (_4cft.Text != "")
                        count += 1;
                    if (_4irt.Text != "")
                        count += 1;
                    if (_4lt.Text != "")
                        count += 1;
                    if (_4ft.Text != "")
                        count += 1;
                    if (_4frt.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 6) * 100;
                }
            }
            else if (lblsch.Text == "6")
            {

                if (_6ep.Text != "")
                    count += 1;
                if (_6ct.Text != "")
                    count += 1;
                if (_6bc.Text != "")
                    count += 1;
                _percentage = (Convert.ToDecimal(count) / 3) * 100;
            }
            else if (lblsch.Text == "3" || lblsch.Text == "120")
            {
                if ((string)Session["cat"] == "LTX")
                {
                    if (_3ir.Text != "")
                        count += 1;
                    if (_3rvm.Text != "")
                        count += 1;
                    if (_3mbt.Text != "")
                        count += 1;
                    if (_3wrt.Text != "")
                        count += 1;
                    if (_3sct.Text != "")
                        count += 1;
                    if (_3ctr.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 6) * 100;
                }
                else
                {
                    if (_3ir.Text != "")
                        count += 1;
                    if (_3tcc.Text != "")
                        count += 1;
                    if (_3rvm.Text != "")
                        count += 1;
                    if (_3mbt.Text != "")
                        count += 1;
                    if (_3wrt.Text != "")
                        count += 1;
                    if (_3sct.Text != "")
                        count += 1;
                    if (_3ctr.Text != "")
                        count += 1;
                    if (_3brt.Text != "")
                        count += 1;
                    if (_3tcw.Text != "")
                        count += 1;
                    if (_3toa.Text != "")
                        count += 1;
                    if (_3bct.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 11) * 100;
                }
            }
            else if (lblsch.Text == "7")
            {
                if (_7ir.Text != "")
                {
                    if ((string)Session["cat"] != "Graphics")
                    {
                        if (IsNumeric(_7total.Text) == true && IsNumeric(_7ir.Text) == true)
                        {
                            decimal _d1 = Convert.ToDecimal(_7ir.Text);
                            decimal _d2 = Convert.ToDecimal(_7total.Text);
                            decimal _per = (_d1 / _d2) * 100;
                            _percentage = _per;
                        }
                    }
                }
            }
            else if (lblsch.Text == "10")
            {
                if ((string)Session["cat"] != "FCC")
                {
                    if (IsNumeric(_10nct.Text) == true)
                    {
                        _percentage = Convert.ToDecimal(_10nct.Text);
                    }
                }
            }
            else if (lblsch.Text == "20")
            {
                if ((string)Session["cat"] == "GUI")
                {
                    if (_20prg.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 1) * 100;
                }
                else
                {
                    if (_20cct.Text != "")
                        count += 1;
                    if (_20prg.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 2) * 100;
                }
            }
            else if (lblsch.Text == "23")
            {
                decimal _test1 = 0;
                decimal _test2 = 0;
                if (IsNumeric(_23cct.Text) == true) _test1 = Convert.ToDecimal(_23cct.Text);
                if (IsNumeric(_23prg.Text) == true) _test2 = Convert.ToDecimal(_23prg.Text);
                if (IsNumeric(_23dvc.Text) == true)
                {
                    decimal _d1 = _test1 + _test2;
                    decimal _d2 = Convert.ToDecimal(_23dvc.Text);
                    decimal _per = (_d1 / (_d2 * 2)) * 100;
                    _percentage = _per;
                }
            }
            else if (lblsch.Text == "11")
            {
                if (IsNumeric(_11dvc.Text) == true && IsNumeric(_11cit.Text) == true)
                {
                    decimal _d1 = Convert.ToDecimal(_11cit.Text);
                    decimal _d2 = Convert.ToDecimal(_11dvc.Text);
                    decimal _per = (_d1 / _d2) * 100;
                    _percentage = _per;
                }
            }
            else if (lblsch.Text == "22")
            {
                decimal _test1 = 0;
                decimal _test2 = 0;
                if (IsNumeric(_22cit.Text) == true) _test1 = Convert.ToDecimal(_22cit.Text);
                if (IsNumeric(_22prg.Text) == true) _test2 = Convert.ToDecimal(_22prg.Text);
                if (IsNumeric(_22nop.Text) == true)
                {
                    if ((string)Session["cat"] == "SRV")
                    {
                        decimal _d1 = _test2;
                        decimal _d2 = Convert.ToDecimal(_22nop.Text);
                        decimal _per = (_d1 / _d2) * 100;
                        _percentage = _per;
                    }
                    else
                    {
                        decimal _d1 = _test1 + _test2;
                        decimal _d2 = Convert.ToDecimal(_22nop.Text);
                        decimal _per = (_d1 / (_d2 * 2)) * 100;
                        _percentage = _per;
                    }
                }
            }
            else if (lblsch.Text == "15")
            {
                if ((string)Session["cat"] != "SRV" && (string)Session["cat"] != "GUI")
                {
                    if (IsNumeric(_15nop.Text) == true && IsNumeric(_15cct.Text) == true && _15nop.Text != "0")
                    {
                        decimal _d1 = Convert.ToDecimal(_15cct.Text);
                        decimal _d2 = Convert.ToDecimal(_15nop.Text);
                        decimal _per = (_d1 / _d2) * 100;
                        _percentage = _per;
                    }
                }
            }
            else if (lblsch.Text == "13")
            {
                decimal _test1 = 0;
                decimal _test2 = 0;
                if (IsNumeric(_13cct.Text) == true) _test1 = Convert.ToDecimal(_13cct.Text);
                if (IsNumeric(_13prg.Text) == true) _test2 = Convert.ToDecimal(_13prg.Text);
                if (IsNumeric(_13nop.Text) == true && _13nop.Text!="0")
                {
                    decimal _d1 = _test2;//no continuity cable test
                    decimal _d2 = Convert.ToDecimal(_13nop.Text);
                    decimal _per = (_d1 / (_d2 * 2)) * 100;
                    _percentage = _per;
                }
            }
            else if (lblsch.Text == "16")
            {
                if (IsNumeric(_16nos.Text) == true && IsNumeric(_16cct.Text) == true)
                {
                    if ((string)Session["cat"] != "MVS" && (string)Session["cat"] != "VS")
                    {
                        decimal _d1 = Convert.ToDecimal(_16cct.Text);
                        decimal _d2 = Convert.ToDecimal(_16nos.Text);
                        decimal _per = (_d1 / _d2) * 100;
                        _percentage = _per;
                    }
                }
            }
            else if (lblsch.Text == "14")
            {
                //decimal _ptested1 = 0;
                //decimal _ptested2 = 0;
                if (IsNumeric(_14noc.Text) == true && IsNumeric(_14nct.Text) == true)
                {
                    decimal _d1 = Convert.ToDecimal(_14nct.Text);
                    decimal _d2 = Convert.ToDecimal(_14noc.Text);
                    _percentage = (_d1 / _d2) * 100;
                }
                //if (_14pcc.Text != "")
                //    count += 1;
                //_ptested2 = (Convert.ToDecimal(count)) * 100;
                //decimal _per = (_ptested1 * 0.5m + _ptested2 * 0.5m);
                //_percentage = _per;
            }
            else if (lblsch.Text == "24")
            {
                decimal _test1 = 0;
                decimal _test2 = 0;
                if (IsNumeric(_24cct.Text) == true) _test1 = Convert.ToDecimal(_24cct.Text);
                if (IsNumeric(_24prg.Text) == true) _test2 = Convert.ToDecimal(_24prg.Text);
                if (IsNumeric(_24nop.Text) == true && _24nop.Text != "0")
                {
                    if ((string)Session["cat"] != "SRV")
                    {
                        decimal _d1 = _test2;
                        decimal _d2 = Convert.ToDecimal(_24nop.Text);
                        decimal _per = (_d1 / (_d2 * 1)) * 100;
                        _percentage = _per;
                    }
                }
            }
            else if (lblsch.Text == "25")
            {
                decimal _ptested1 = 0;
                decimal _ptested2 = 0;
                if (IsNumeric(_25not.Text) == true && IsNumeric(_25ntt.Text) == true)
                {
                    decimal _d1 = Convert.ToDecimal(_25ntt.Text);
                    decimal _d2 = Convert.ToDecimal(_25not.Text);
                    _ptested1 = (_d1 / _d2) * 100;
                }
                if (_25cct.Text != "")
                    count += 1;
                if (_25pcom.Text != "")
                    count += 1;
                _ptested2 = (Convert.ToDecimal(count) / 2) * 100;
                decimal _per = (_ptested1 * 0.5m + _ptested2 * 0.5m);
                _percentage = _per;
            }
            else if (lblsch.Text == "26")
            {

                if (_26cbt.Text != "")
                    count += 1;
                //if (_26inc.Text != "")
                //    count += 1;
                _percentage = (Convert.ToDecimal(count) / 1) * 100;
            }
            else if (lblsch.Text == "17" || lblsch.Text == "85" || lblsch.Text == "86" || lblsch.Text == "87" || lblsch.Text == "88" || lblsch.Text == "89" || lblsch.Text == "90" || lblsch.Text == "91" || lblsch.Text == "99" || lblsch.Text == "107" || lblsch.Text == "108" || lblsch.Text == "117")
            {
                if ((string)Session["cat"] == "CP" || (string)Session["cat"] == "WBP" || (string)Session["cat"] == "SEP" || (string)Session["cat"] == "SP" || (string)Session["cat"] == "GWT" || (string)Session["cat"] == "GSP" || (string)Session["cat"] == "BST" || (string)Session["cat"] == "BP" || (string)Session["cat"] == "AMP" || (string)Session["cat"] == "WFP" || (string)Session["cat"] == "IP" || (string)Session["cat"] == "FODT" || (string)Session["cat"] == "FOST" || (string)Session["cat"] == "FOP")
                {
                    if (_17pc1.Text != "" && _17pc1.Text != "N/A")
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "19")
            {
                if (IsNumeric(_19qty.Text) == true && IsNumeric(_19qt.Text) == true)
                {
                    decimal _d1 = Convert.ToDecimal(_19qt.Text);
                    decimal _d2 = Convert.ToDecimal(_19qty.Text);
                    decimal _per = (_d1 / _d2) * 100;
                    _percentage = _per;
                }
            }
            else if (lblsch.Text == "28")
            {
                if (DateValidation(_28pcom.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "29")
            {
                decimal _test1 = 0;
                decimal _test2 = 0;
                if (IsNumeric(_29cct.Text) == true) _test1 = Convert.ToDecimal(_29cct.Text);
                if (IsNumeric(_29prg.Text) == true) _test2 = Convert.ToDecimal(_29prg.Text);
                if (IsNumeric(_29noc.Text) == true)
                {
                    if (_29noc.Text != "0")
                    {
                        decimal _d1 = _test1 + _test2;
                        decimal _d2 = Convert.ToDecimal(_29noc.Text);
                        decimal _per = (_d1 / (_d2 * 2)) * 100;
                        _percentage = _per;
                    }
                }
            }
            return _percentage;
        }
        protected decimal per_com2()
        {

            decimal _percentage = 0;
            int count = 0;
            if (lblsch.Text == "8" || lblsch.Text == "51" || lblsch.Text == "52" || lblsch.Text == "53" || lblsch.Text == "54" || lblsch.Text == "55" || lblsch.Text == "56" || lblsch.Text == "57" || lblsch.Text == "58" || lblsch.Text == "59" || lblsch.Text == "60" || lblsch.Text == "62" || lblsch.Text == "63" || lblsch.Text == "64" || lblsch.Text == "65" || lblsch.Text == "66" || lblsch.Text == "67" || lblsch.Text == "68" || lblsch.Text == "69" || lblsch.Text == "70" || lblsch.Text == "71" || lblsch.Text == "72" || lblsch.Text == "73" || lblsch.Text == "74" || lblsch.Text == "75" || lblsch.Text == "76" || lblsch.Text == "77" || lblsch.Text == "78" || lblsch.Text == "79" || lblsch.Text == "80" || lblsch.Text == "81" || lblsch.Text == "82" || lblsch.Text == "83" || lblsch.Text == "84")
            {
                if (_8co1.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "9")
            {
                if (DateValidation(_9mc.Text) == true && DateValidation(_9fc.Text) == true && DateValidation(_9fai.Text) == true && DateValidation(_9emcs.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "2" || lblsch.Text == "121" || lblsch.Text == "119" || lblsch.Text == "118")
            {
                if (_2pft.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "5" || lblsch.Text=="44")
            {
                if ((string)Session["cat"] == "PFC") return 0;
                if (_5tc.Text != "")
                {
                    if (IsNumeric(_5total.Text) == true && IsNumeric(_5tc.Text) == true)
                    {
                        decimal _d1 = Convert.ToDecimal(_5tc.Text);
                        decimal _d2 = Convert.ToDecimal(_5total.Text);
                        decimal _per = (_d1 / _d2) * 100;
                        _percentage = _per;
                    }
                }
            }
            else if (lblsch.Text == "4")
            {

                if (_4ct.Text != "")
                    count += 1;
                if (_4ir.Text != "")
                    count += 1;
                if (_4hp.Text != "")
                    count += 1;
                _percentage = (Convert.ToDecimal(count) / 3) * 100;
            }
            else if (lblsch.Text == "6")
            {
                if (_6ep.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "3" || lblsch.Text == "120")
            {
                if (_3ct.Text != "")
                {
                    if (IsNumeric(_3qty.Text) == true && IsNumeric(_3ct.Text) == true)
                    {
                        decimal _d1 = Convert.ToDecimal(_3ct.Text);
                        decimal _d2 = Convert.ToDecimal(_3qty.Text);
                        decimal _per = (_d1 / _d2) * 100;
                        _percentage = _per;
                    }
                }
            }
            else if (lblsch.Text == "7")
            {
                if ((string)Session["cat"] == "Graphics")
                {
                    if (_7sp.Text != "")
                        count += 1;
                    if (_7gt.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 2) * 100;
                }
                else if ((string)Session["cat"] == "CBS")
                {
                    if (_7pt.Text != "")
                        count += 1;
                    if (_7bdt.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 2) * 100;
                }
                else if ((string)Session["cat"] == "SCM")
                {
                    if (_7dat.Text != "")
                        count += 1;
                    if (_7lllt.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 2) * 100;
                }
            }
            else if (lblsch.Text == "10")
            {
                if ((string)Session["cat"] == "FAP" || (string)Session["cat"] == "FCC") return 0;
                if (IsNumeric(_10ndt.Text) == true)
                {
                    _percentage = Convert.ToDecimal(_10ndt.Text);
                }
            }
            else if (lblsch.Text == "20")
            {
                if ((string)Session["cat"] == "GUI" || (string)Session["cat"] == "MCC" || (string)Session["cat"] == "PMCS") return 0;
                decimal _ptested1 = 0;
                decimal _ptested2 = 0;
                if (IsNumeric(_20npnt.Text) == true && IsNumeric(_20npt.Text) == true)
                {
                    decimal _d1 = Convert.ToDecimal(_20npt.Text);
                    decimal _d2 = Convert.ToDecimal(_20npnt.Text);
                    _ptested1 = (_d1 / _d2) * 100;
                }
                if (_20sot.Text != "")
                    count += 1;
                if (_20grt.Text != "")
                    count += 1;
                _ptested2 = (Convert.ToDecimal(count) / 2) * 100;
                decimal _per = (_ptested1 * 0.5m + _ptested2 * 0.5m);
                _percentage = _per;

            }
            else if (lblsch.Text == "23")
            {
                decimal _test1 = 0;
                decimal _test2 = 0;
                decimal _test3 = 0;
                if (IsNumeric(_23npt.Text) == true) _test1 = Convert.ToDecimal(_23npt.Text);
                if (IsNumeric(_23sot.Text) == true) _test2 = Convert.ToDecimal(_23sot.Text);
                if (IsNumeric(_23grt.Text) == true) _test3 = Convert.ToDecimal(_23grt.Text);
                if (IsNumeric(_23dvc.Text) == true)
                {
                    decimal _d1 = _test1 + _test2 + _test3;
                    decimal _d2 = Convert.ToDecimal(_23dvc.Text);
                    decimal _per = (_d1 / (_d2 * 3)) * 100;
                    _percentage = _per;
                }
            }
            else if (lblsch.Text == "11")
            {
                decimal _ptested1 = 0;
                decimal _ptested2 = 0;
                if (IsNumeric(_11dvc.Text) == true && IsNumeric(_11ndt.Text) == true)
                {
                    decimal _d1 = Convert.ToDecimal(_11ndt.Text);
                    decimal _d2 = Convert.ToDecimal(_11dvc.Text);
                    _ptested1 = (_d1 / _d2) * 100;
                }
                if (_11ztb.Text != "")
                    count += 1;
                if (_11ztp.Text != "")
                    count += 1;
                if (_11zsl.Text != "")
                    count += 1;
                if (_11zeo.Text != "")
                    count += 1;
                if (_11zai.Text != "")
                    count += 1;
                if (_11bat.Text != "")
                    count += 1;
                if (_11grt.Text != "")
                    count += 1;
                if (_11iit.Text != "")
                    count += 1;
                _ptested2 = (Convert.ToDecimal(count) / 8) * 100;
                decimal _per = (_ptested1 * 0.5m + _ptested2 * 0.5m);
                _percentage = _per;
            }
            else if (lblsch.Text == "22")
            {
                decimal _test1 = 0;
                decimal _test2 = 0;
                decimal _test3 = 0;
                if (IsNumeric(_22npt.Text) == true) _test1 = Convert.ToDecimal(_22npt.Text);
                if (IsNumeric(_22sot.Text) == true) _test2 = Convert.ToDecimal(_22sot.Text);
                if (IsNumeric(_22grt.Text) == true) _test3 = Convert.ToDecimal(_22grt.Text);
                if (IsNumeric(_22nop.Text) == true)
                {
                    if ((string)Session["cat"] == "SRV")
                    {
                        decimal _d1 = _test1 + _test3;
                        decimal _d2 = Convert.ToDecimal(_22nop.Text);
                        decimal _per = (_d1 / (_d2 * 2)) * 100;
                        _percentage = _per;
                    }
                    else
                    {
                        decimal _d1 = _test1 + _test2 + _test3;
                        decimal _d2 = Convert.ToDecimal(_22nop.Text);
                        decimal _per = (_d1 / (_d2 * 3)) * 100;
                        _percentage = _per;
                    }
                }
            }
            else if (lblsch.Text == "15")
            {
                decimal _test1 = 0;
                decimal _test2 = 0;
                decimal _test3 = 0;
                if (IsNumeric(_15sft_tr.Text) == true) _test1 = Convert.ToDecimal(_15sft_tr.Text);
                if (IsNumeric(_15sft_out.Text) == true) _test2 = Convert.ToDecimal(_15sft_out.Text);
                if (IsNumeric(_15sft_he.Text) == true) _test3 = Convert.ToDecimal(_15sft_he.Text);
                if (IsNumeric(_15nop.Text) == true && _15nop.Text != "0")
                {
                    if ((string)Session["cat"] == "SRV")
                    {
                        decimal _d1 = _test3;
                        decimal _d2 = Convert.ToDecimal(_15nop.Text);
                        decimal _per = (_d1 / _d2) * 100;
                        _percentage = _per;
                    }
                    else
                    {
                        decimal _d1 = _test1 + _test2 + _test3;
                        decimal _d2 = Convert.ToDecimal(_15nop.Text);
                        decimal _per = (_d1 / (_d2 * 3)) * 100;
                        _percentage = _per;
                    }

                }
            }
            else if (lblsch.Text == "13")
            {
                decimal _test1 = 0;
                decimal _test2 = 0;
                decimal _test3 = 0;
                if (IsNumeric(_13cvl.Text) == true) _test1 = Convert.ToDecimal(_13cvl.Text);
                if (IsNumeric(_13htv.Text) == true) _test2 = Convert.ToDecimal(_13htv.Text);
                if (IsNumeric(_13htc.Text) == true) _test3 = Convert.ToDecimal(_13htc.Text);
                if (IsNumeric(_13nop.Text) == true && _13nop.Text!="0")
                {
                    if ((string)Session["cat"] == "SRV")
                    {
                        decimal _d1 = _test2 + _test3;
                        decimal _d2 = Convert.ToDecimal(_13nop.Text);
                        decimal _per = (_d1 / (_d2 * 2)) * 100;
                        _percentage = _per;
                    }
                    else
                    {
                        decimal _d1 = _test1 + _test2 + _test3;
                        decimal _d2 = Convert.ToDecimal(_13nop.Text);
                        decimal _per = (_d1 / (_d2 * 3)) * 100;
                        _percentage = _per;
                    }
                }
            }
            else if (lblsch.Text == "16")
            {
                decimal _test1 = 0;
                decimal _test2 = 0;
                if (IsNumeric(_16sft.Text) == true) _test1 = Convert.ToDecimal(_16sft.Text);
                if (IsNumeric(_16iit.Text) == true) _test2 = Convert.ToDecimal(_16iit.Text);
                if (IsNumeric(_16nos.Text) == true && _16nos.Text!="0")
                {
                    decimal _d1 = _test1 ;
                    decimal _d2 = Convert.ToDecimal(_16nos.Text);
                    decimal _per = (_d1 / (_d2 * 1)) * 100;
                    _percentage = _per;
                }
            }
            else if (lblsch.Text == "14")
            {

                if (_14acc.Text != "")
                    count += 1;
                if (_14vcc.Text != "")
                    count += 1;
                if (_14rst.Text != "")
                    count += 1;
                if (_14faa.Text != "")
                    count += 1;
                _percentage = (Convert.ToDecimal(count) / 4) * 100;
            }
            else if (lblsch.Text == "24")
            {
                decimal _test1 = 0;
                decimal _test2 = 0;
                decimal _test3 = 0;
                decimal _test4 = 0;
                decimal _test5 = 0;
                decimal _test6 = 0;
                decimal _test7 = 0;
                decimal _test8 = 0;
                if (IsNumeric(_24pbt.Text) == true) _test1 = Convert.ToDecimal(_24pbt.Text);
                if (IsNumeric(_24net.Text) == true) _test2 = Convert.ToDecimal(_24net.Text);
                if (IsNumeric(_24nct.Text) == true) _test3 = Convert.ToDecimal(_24nct.Text);
                if (IsNumeric(_24nat.Text) == true) _test4 = Convert.ToDecimal(_24nat.Text);
                if (IsNumeric(_24nst.Text) == true) _test5 = Convert.ToDecimal(_24nst.Text);
                if (IsNumeric(_24ntt.Text) == true) _test6 = Convert.ToDecimal(_24ntt.Text);
                if (IsNumeric(_24nmt.Text) == true) _test7 = Convert.ToDecimal(_24nmt.Text);
                if (IsNumeric(_24it.Text) == true) _test8 = Convert.ToDecimal(_24it.Text);
                if (IsNumeric(_24nop.Text) == true && _24nop.Text!="0")
                {
                    if ((string)Session["cat"] == "SRV")
                    {
                        decimal _d1 = _test1 + _test8;
                        decimal _d2 = Convert.ToDecimal(_24nop.Text);
                        decimal _per = (_d1 / (_d2 * 2)) * 100;
                        _percentage = _per;
                    }
                    else
                    {
                        decimal _d1 = _test1 + _test2 + _test3 + _test4 + _test5 + _test6 + _test7 + _test8;
                        decimal _d2 = Convert.ToDecimal(_24nop.Text);
                        decimal _per = (_d1 / (_d2 * 8)) * 100;
                        _percentage = _per;
                    }
                }
            }
            else if (lblsch.Text == "25")
            {
                if (_25com.Text != "")
                    _percentage = 100;
            }
            else if (lblsch.Text == "26")
            {

                if (_26fnt.Text != "")
                    count += 1;
                if (_26iit.Text != "")
                    count += 1;
                _percentage = (Convert.ToDecimal(count) / 2) * 100;
            }
            else if (lblsch.Text == "17" || lblsch.Text == "85" || lblsch.Text == "86" || lblsch.Text == "87" || lblsch.Text == "88" || lblsch.Text == "89" || lblsch.Text == "90" || lblsch.Text == "91" || lblsch.Text == "99" || lblsch.Text == "107" || lblsch.Text == "108" || lblsch.Text == "117")
            {
                if (_17co1.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "19")
            {
                decimal _test1 = 0;
                decimal _test2 = 0;
                decimal _test3 = 0;
                decimal _test4 = 0;
                if (IsNumeric(_19icom.Text) == true) _test1 = Convert.ToDecimal(_19icom.Text);
                if (IsNumeric(_19pft.Text) == true) _test2 = Convert.ToDecimal(_19pft.Text);
                if (IsNumeric(_19fpt.Text) == true) _test3 = Convert.ToDecimal(_19fpt.Text);
                if (IsNumeric(_19arm.Text) == true) _test4 = Convert.ToDecimal(_19arm.Text);
                if (IsNumeric(_19qty.Text) == true)
                {
                    decimal _d1 = _test1 + _test3 + _test4;
                    decimal _d2 = Convert.ToDecimal(_19qty.Text);
                    decimal _per = (_d1 / (_d2 * 3)) * 100;
                    _percentage = _per;
                }
            }
            else if (lblsch.Text == "27" || lblsch.Text == "46")
            {
                if (IsNumeric(_27nop.Text) == true && IsNumeric(_27comm.Text) == true && _27nop.Text != "0")
                {
                    decimal _d1 = Convert.ToDecimal(_27comm.Text);
                    decimal _d2 = Convert.ToDecimal(_27nop.Text);
                    decimal _per = (_d1 / _d2) * 100;
                    _percentage = _per;
                }
            }
            else if (lblsch.Text == "28")
            {
                if (DateValidation(_28com.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "29")
            {
                decimal _test1 = 0;
                decimal _test2 = 0;
                decimal _test3 = 0;
                if (IsNumeric(_29nmt.Text) == true) _test1 = Convert.ToDecimal(_29nmt.Text);
                if (IsNumeric(_29sop.Text) == true) _test2 = Convert.ToDecimal(_29sop.Text);
                if (IsNumeric(_29grt.Text) == true) _test3 = Convert.ToDecimal(_29grt.Text);
                if (IsNumeric(_29noc.Text) == true)
                {
                    if (_29noc.Text != "0")
                    {
                        decimal _d1 = _test1 + _test2 + _test3;
                        decimal _d2 = Convert.ToDecimal(_29noc.Text);
                        decimal _per = (_d1 / (_d2 * 3)) * 100;
                        _percentage = _per;
                    }
                }
            }
            return _percentage;
        }
        protected decimal per_com3()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "8" || lblsch.Text == "51" || lblsch.Text == "52" || lblsch.Text == "53" || lblsch.Text == "54" || lblsch.Text == "55" || lblsch.Text == "56" || lblsch.Text == "57" || lblsch.Text == "58" || lblsch.Text == "59" || lblsch.Text == "60" || lblsch.Text == "62" || lblsch.Text == "63" || lblsch.Text == "64" || lblsch.Text == "65" || lblsch.Text == "66" || lblsch.Text == "67" || lblsch.Text == "68" || lblsch.Text == "69" || lblsch.Text == "70" || lblsch.Text == "71" || lblsch.Text == "72" || lblsch.Text == "73" || lblsch.Text == "74" || lblsch.Text == "75" || lblsch.Text == "76" || lblsch.Text == "77" || lblsch.Text == "78" || lblsch.Text == "79" || lblsch.Text == "80" || lblsch.Text == "81" || lblsch.Text == "82" || lblsch.Text == "83" || lblsch.Text == "84")
            {
                if (_8wd1.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "9")
            {
                int _count = 0;
                if (DateValidation(_9mc.Text) == true)
                    _count += 1;
                if (DateValidation(_9fc.Text) == true)
                    _count += 1;
                if (DateValidation(_9fai.Text) == true)
                    _count += 1;
                if (DateValidation(_9emcs.Text) == true)
                    _count += 1;
                _percentage = (Convert.ToDecimal(_count) / 4) * 100;
            }
            else if (lblsch.Text == "2" || lblsch.Text == "121" || lblsch.Text == "119" || lblsch.Text == "118")
            {
                if (_2eng.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "5" || lblsch.Text=="44")
            {
                if ((string)Session["cat"] == "PFC" || (string)Session["cat"] == "VFD") return 0;
                if (_5tl.Text != "")
                {
                    if (IsNumeric(_5total.Text) == true && IsNumeric(_5tl.Text) == true)
                    {
                        decimal _d1 = Convert.ToDecimal(_5tl.Text);
                        decimal _d2 = Convert.ToDecimal(_5total.Text);
                        decimal _per = (_d1 / _d2) * 100;
                        _percentage = _per;
                    }
                }
            }
            else if (lblsch.Text == "4")
            {
                if (_4pft.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "6")
            {
                if (_6ct.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "3" || lblsch.Text == "120")
            {
                if (_3pft.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "7")
            {
                if (_7pft.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "10")
            {
                if ((string)Session["cat"] == "ANN" || (string)Session["cat"] == "FCC" || (string)Session["cat"] == "FSC" || (string)Session["cat"] == "FTL" || (string)Session["cat"] == "SPC") return 0;
                if (IsNumeric(_10fat.Text) == true)
                {
                    _percentage = Convert.ToDecimal(_10fat.Text);
                }
            }
            else if (lblsch.Text == "20")
            {
                if (_20icom.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "23")
            {
                if ((string)Session["cat"] != "RTU")
                {
                    if (_23icomp.Text != "")
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "11")
            {
                if (_11icom.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "22")
            {
                if (_22icom.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "15")
            {
                if (_15icom.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "13")
            {
                if (_13icom.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "16")
            {
                if (_16icom.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "14")
            {
                if (_14icom.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "24")
            {
                if (_24icom.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "25")
            {
                if (_25icom.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "26")
            {
                if (_26icom.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "17" || lblsch.Text == "85" || lblsch.Text == "86" || lblsch.Text == "87" || lblsch.Text == "88" || lblsch.Text == "89" || lblsch.Text == "90" || lblsch.Text == "91" || lblsch.Text == "99" || lblsch.Text == "107" || lblsch.Text == "108" || lblsch.Text == "117")
            {
                if (_17wd1.Text != "" && _17wd1.Text != "N/A")
                    _percentage = 1;
            }
            else if (lblsch.Text == "19")
            {
                if (IsNumeric(_19qt.Text) == true)
                {
                    _percentage = Convert.ToDecimal(_19qt.Text);
                }
            }
            else if (lblsch.Text == "27" || lblsch.Text == "46")
            {
                if (DateValidation(_27icom.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "28")
            {
                if (DateValidation(_28icom.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "29")
            {
                if (DateValidation(_29icom.Text) == true)
                    _percentage = 1;
            }
            return _percentage;
        }
        protected decimal per_com4()
        {
            decimal _percentage = 0;
            int count = 0;
            if (lblsch.Text == "8" || lblsch.Text == "51" || lblsch.Text == "52" || lblsch.Text == "53" || lblsch.Text == "54" || lblsch.Text == "55" || lblsch.Text == "56" || lblsch.Text == "57" || lblsch.Text == "58" || lblsch.Text == "59" || lblsch.Text == "60" || lblsch.Text == "62" || lblsch.Text == "63" || lblsch.Text == "64" || lblsch.Text == "65" || lblsch.Text == "66" || lblsch.Text == "67" || lblsch.Text == "68" || lblsch.Text == "69" || lblsch.Text == "70" || lblsch.Text == "71" || lblsch.Text == "72" || lblsch.Text == "73" || lblsch.Text == "74" || lblsch.Text == "75" || lblsch.Text == "76" || lblsch.Text == "77" || lblsch.Text == "78" || lblsch.Text == "79" || lblsch.Text == "80" || lblsch.Text == "81" || lblsch.Text == "82" || lblsch.Text == "83" || lblsch.Text == "84")
            {
                if (_8duty.Text != "")
                    _percentage = Convert.ToDecimal(_8duty.Text);
            }
            else if (lblsch.Text == "9")
            {
                if (_9ics.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "2" || lblsch.Text == "121" || lblsch.Text == "119" || lblsch.Text == "118")
            {
                if (_2fpt.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "5" || lblsch.Text=="44")
            {
                if (_5pft.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "4")
            {
                if (_4eng.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "6")
            {
                if (_6bc.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "3" || lblsch.Text == "120")
            {
                if (_3eng.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "7")
            {
                if (_7eng.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "10")
            {
                if ((string)Session["cat"] == "FAP")
                {
                    if (IsNumeric(_10bat.Text) == true)
                    {
                        _percentage = Convert.ToDecimal(_10bat.Text);
                    }
                }
            }
            else if (lblsch.Text == "20")
            {
                if ((string)Session["cat"] == "GUI" || (string)Session["cat"] == "VFD") return 0;
                if (_20pft.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "23")
            {
                if ((string)Session["cat"] != "DMA")
                {
                    if (_23pft.Text != "")
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "11")
            {
                if (_11pft.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "22")
            {
                if (_22pft.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "15")
            {
                if (_15pft.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "13")
            {
                if (_13pft.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "16")
            {
                if (_16pft.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "14")
            {
                //if (_14pft.Text != "")
                //    _percentage = 1;
            }
            else if (lblsch.Text == "24")
            {
                if (_24pft.Text != "" && _24pft.Text != "N/A")
                    _percentage = 1;
            }
            else if (lblsch.Text == "25")
            {
                if (_25pft.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "26")
            {
                if (_26pft.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "17" || lblsch.Text == "85" || lblsch.Text == "86" || lblsch.Text == "87" || lblsch.Text == "88" || lblsch.Text == "89" || lblsch.Text == "90" || lblsch.Text == "91" || lblsch.Text == "99" || lblsch.Text == "107" || lblsch.Text == "108" || lblsch.Text == "117")
            {
                if ((string)Session["cat"] != "FIL")
                {
                    if (_17icom.Text != "")
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "19")
            {
                if (IsNumeric(_19icom.Text) == true)
                {
                    _percentage = Convert.ToDecimal(_19icom.Text);
                }
            }
            else if (lblsch.Text == "27")
            {
                //if (DateValidation(_27pft.Text) == true)
                //    _percentage = 1;
            }
            else if (lblsch.Text == "28")
            {
                if (DateValidation(_28pft.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "29")
            {
                if (DateValidation(_29pft.Text) == true)
                    _percentage = 1;
            }
            return _percentage;
        }
        protected decimal per_com5()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "8" || lblsch.Text == "51" || lblsch.Text == "52" || lblsch.Text == "53" || lblsch.Text == "54" || lblsch.Text == "55" || lblsch.Text == "56" || lblsch.Text == "57" || lblsch.Text == "58" || lblsch.Text == "59" || lblsch.Text == "60" || lblsch.Text == "62" || lblsch.Text == "63" || lblsch.Text == "64" || lblsch.Text == "65" || lblsch.Text == "66" || lblsch.Text == "67" || lblsch.Text == "68" || lblsch.Text == "69" || lblsch.Text == "70" || lblsch.Text == "71" || lblsch.Text == "72" || lblsch.Text == "73" || lblsch.Text == "74" || lblsch.Text == "75" || lblsch.Text == "76" || lblsch.Text == "77" || lblsch.Text == "78" || lblsch.Text == "79" || lblsch.Text == "80" || lblsch.Text == "81" || lblsch.Text == "82" || lblsch.Text == "83" || lblsch.Text == "84")
            {
                if (lblprj.Text == "CCAD")
                {
                    if (_8pft.Text != "")
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "9")
            {
                if (_9pft.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "2" || lblsch.Text == "121" || lblsch.Text == "119" || lblsch.Text == "118")
            {
                if (_2accept.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "5" || lblsch.Text=="44")
            {
                if (_5ed.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "4")
            {
                if (_4fpt.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "6")
            {
                if (_6pft.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "3" || lblsch.Text == "120")
            {
                if (_3fpt.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "7")
            {
                if (_7fpt.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "10")
            {
                if ((string)Session["cat"] == "FAP" || (string)Session["cat"] == "FCC")
                {
                    if (IsNumeric(_10ghet.Text) == true)
                    {
                        _percentage = Convert.ToDecimal(_10ghet.Text);
                    }
                }
            }
            else if (lblsch.Text == "20")
            {
                if (_20eng.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "23")
            {
                if (_23eng.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "11")
            {
                if (_11eng.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "22")
            {
                if (_22eng.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "15")
            {
                if (_15eng.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "13")
            {
                if (_13eng.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "16")
            {
                if (_16eng.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "14")
            {
                //if (_14eng.Text != "")
                //    _percentage = 1;
            }
            else if (lblsch.Text == "24")
            {
                if (_24eng.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "25")
            {
                if (_25eng.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "26")
            {
                if (_26eng.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "17" || lblsch.Text == "85" || lblsch.Text == "86" || lblsch.Text == "87" || lblsch.Text == "88" || lblsch.Text == "89" || lblsch.Text == "90" || lblsch.Text == "91" || lblsch.Text == "99" || lblsch.Text == "107" || lblsch.Text == "108" || lblsch.Text == "117")
            {
                if ((string)Session["cat"] == "CP" || (string)Session["cat"] == "WBP" || (string)Session["cat"] == "SEP" || (string)Session["cat"] == "SP" || (string)Session["cat"] == "GWT" || (string)Session["cat"] == "GSP" || (string)Session["cat"] == "BST" || (string)Session["cat"] == "BP" || (string)Session["cat"] == "AMP" || (string)Session["cat"] == "WFP" || (string)Session["cat"] == "IP" || (string)Session["cat"] == "FODT" || (string)Session["cat"] == "FOST" || (string)Session["cat"] == "FOP")
                {
                    if (_17pft.Text != "")
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "19")
            {
                //if (IsNumeric(_19pft.Text) == true)
                //{
                //    _percentage = Convert.ToDecimal(_19pft.Text);
                //}
            }
            else if (lblsch.Text == "27" || lblsch.Text == "46")
            {
                if (DateValidation(_27eng.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "28")
            {
                if (DateValidation(_28psc.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "29")
            {
                if (DateValidation(_29eng.Text) == true)
                    _percentage = 1;
            }
            return _percentage;
        }
        protected decimal per_com6()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "8" || lblsch.Text == "51" || lblsch.Text == "52" || lblsch.Text == "53" || lblsch.Text == "54" || lblsch.Text == "55" || lblsch.Text == "56" || lblsch.Text == "57" || lblsch.Text == "58" || lblsch.Text == "59" || lblsch.Text == "60" || lblsch.Text == "62" || lblsch.Text == "63" || lblsch.Text == "64" || lblsch.Text == "65" || lblsch.Text == "66" || lblsch.Text == "67" || lblsch.Text == "68" || lblsch.Text == "69" || lblsch.Text == "70" || lblsch.Text == "71" || lblsch.Text == "72" || lblsch.Text == "73" || lblsch.Text == "74" || lblsch.Text == "75" || lblsch.Text == "76" || lblsch.Text == "77" || lblsch.Text == "78" || lblsch.Text == "79" || lblsch.Text == "80" || lblsch.Text == "81" || lblsch.Text == "82" || lblsch.Text == "83" || lblsch.Text == "84")
            {
                if (lblprj.Text == "CCAD")
                {
                    if (_8pwron.Text != "")
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "9")
            {
                if (_9pwr.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "2" || lblsch.Text == "121" || lblsch.Text == "119" || lblsch.Text == "118")
            {
                if (_2cih.Text != "")
                {
                    if (IsNumeric(_2dvc.Text) == true && IsNumeric(_2cih.Text) == true)
                    {
                        decimal _d1 = Convert.ToDecimal(_2cih.Text);
                        decimal _d2 = Convert.ToDecimal(_2dvc.Text);
                        decimal _per = (_d1 / _d2) * 100;
                        _percentage = _per;
                    }
                }
            }
            else if (lblsch.Text == "5" || lblsch.Text=="44")
            {
                if (_5fpt.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "4")
            {
                if (_4arm.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "6")
            {
                if (_6eng.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "3" || lblsch.Text == "120")
            {
                if (_3arm.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "7")
            {
                if (_7arm.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "20")
            {
                if (_20fpt.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "23")
            {
                if (_23fpt.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "11")
            {
                if (_11fpt.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "22")
            {
                if ((string)Session["cat"] != "SRV")
                {
                    if (_22fpt.Text != "")
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "15")
            {
                if (_15fpt.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "13")
            {
                if (_13fpt.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "16")
            {
                if (_16fpt.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "14")
            {
                if (_14fpt.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "24")
            {
                if (_24fpt.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "25")
            {
                if (_25fpt.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "26")
            {
                if (_26fpt.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "17" || lblsch.Text == "85" || lblsch.Text == "86" || lblsch.Text == "87" || lblsch.Text == "88" || lblsch.Text == "89" || lblsch.Text == "90" || lblsch.Text == "91" || lblsch.Text == "99" || lblsch.Text == "107" || lblsch.Text == "108" || lblsch.Text == "117")
            {
                if (_17eng.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "19")
            {
                if (IsNumeric(_19fpt.Text) == true)
                {
                    _percentage = Convert.ToDecimal(_19fpt.Text);
                }
            }
            else if (lblsch.Text == "27" || lblsch.Text == "46")
            {
                if (DateValidation(_27fpt.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "28")
            {
                if (DateValidation(_28fpt.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "29")
            {
                if (DateValidation(_29fpt.Text) == true)
                    _percentage = 1;
            }
            return _percentage;
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
        protected decimal per_com7()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "8" || lblsch.Text == "51" || lblsch.Text == "52" || lblsch.Text == "53" || lblsch.Text == "54" || lblsch.Text == "55" || lblsch.Text == "56" || lblsch.Text == "57" || lblsch.Text == "58" || lblsch.Text == "59" || lblsch.Text == "60" || lblsch.Text == "62" || lblsch.Text == "63" || lblsch.Text == "64" || lblsch.Text == "65" || lblsch.Text == "66" || lblsch.Text == "67" || lblsch.Text == "68" || lblsch.Text == "69" || lblsch.Text == "70" || lblsch.Text == "71" || lblsch.Text == "72" || lblsch.Text == "73" || lblsch.Text == "74" || lblsch.Text == "75" || lblsch.Text == "76" || lblsch.Text == "77" || lblsch.Text == "78" || lblsch.Text == "79" || lblsch.Text == "80" || lblsch.Text == "81" || lblsch.Text == "82" || lblsch.Text == "83" || lblsch.Text == "84")
            {
                if (lblprj.Text == "CCAD")
                {
                    if (_8fpt.Text != "")
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "9")
            {
                if (_9fpt.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "5" || lblsch.Text=="44")
            {
                if (_5arm.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "6")
            {
                if (_6fpt.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "20")
            {
                if (_20arm.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "23")
            {
                if (_23arm.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "11")
            {
                if (_11arm.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "22")
            {
                if (_22arm.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "15")
            {
                if (_15arm.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "13")
            {
                if (_13arm.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "16")
            {
                if (_16arm.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "14")
            {
                if (_14arm.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "24")
            {
                if (_24arm.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "25")
            {
                if (_25arm.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "26")
            {
                if (_26arm.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "17" || lblsch.Text == "85" || lblsch.Text == "86" || lblsch.Text == "87" || lblsch.Text == "88" || lblsch.Text == "89" || lblsch.Text == "90" || lblsch.Text == "91" || lblsch.Text == "99" || lblsch.Text == "107" || lblsch.Text == "108" || lblsch.Text == "117")
            {
                if (_17fpt.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "19")
            {
                if (IsNumeric(_19arm.Text) == true)
                {
                    _percentage = Convert.ToDecimal(_19arm.Text);
                }
            }
            else if (lblsch.Text == "27" || lblsch.Text == "46")
            {
                if (DateValidation(_27arm.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "28")
            {
                if (DateValidation(_28arm.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "29")
            {
                if (DateValidation(_29arm.Text) == true)
                    _percentage = 1;
            }
            return _percentage;
        }
        protected decimal per_com8()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "8" || lblsch.Text == "51" || lblsch.Text == "52" || lblsch.Text == "53" || lblsch.Text == "54" || lblsch.Text == "55" || lblsch.Text == "56" || lblsch.Text == "57" || lblsch.Text == "58" || lblsch.Text == "59" || lblsch.Text == "60" || lblsch.Text == "62" || lblsch.Text == "63" || lblsch.Text == "64" || lblsch.Text == "65" || lblsch.Text == "66" || lblsch.Text == "67" || lblsch.Text == "68" || lblsch.Text == "69" || lblsch.Text == "70" || lblsch.Text == "71" || lblsch.Text == "72" || lblsch.Text == "73" || lblsch.Text == "74" || lblsch.Text == "75" || lblsch.Text == "76" || lblsch.Text == "77" || lblsch.Text == "78" || lblsch.Text == "79" || lblsch.Text == "80" || lblsch.Text == "81" || lblsch.Text == "82" || lblsch.Text == "83" || lblsch.Text == "84")
            {
                if (lblprj.Text == "CCAD")
                {
                    if (_8arm.Text != "")
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "9")
            {
                if (_9accept.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "6")
            {
                if (_6arm.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "17" || lblsch.Text == "85" || lblsch.Text == "86" || lblsch.Text == "87" || lblsch.Text == "88" || lblsch.Text == "89" || lblsch.Text == "90" || lblsch.Text == "91" || lblsch.Text == "99" || lblsch.Text == "107" || lblsch.Text == "108" || lblsch.Text == "117")
            {
                if (_17arm.Text != "")
                    _percentage = 1;
            }
            return _percentage;
        }
        protected decimal per_com9()
        {
            decimal _percentage = 0;
        //    if (lblsch.Text == "15")
        //    {
        //        if (_15mif.Text != "")
        //            _percentage = Convert.ToDecimal(_15mif.Text);
        //    }
            return _percentage;
        }
       protected decimal per_com10()
       {
            decimal _percentage = 0;
        //    if (lblsch.Text == "15")
        //    {
        //        decimal _total = per_com1() + per_com2() + per_com3() + per_com4() + per_com5() + per_com6() + per_com7() + per_com8() + per_com9();
        //        decimal _qty = Convert.ToDecimal(_15noof.Text);
        //        _percentage = (_total / (_qty * 9)) * 100;
        //    }
            return _percentage;
        }
        private void Load_cassheet_details()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32(lblsch1.Text);
            _objcas.prj_code = lblprj.Text;
            DataTable _dt = _objbll.Load_casMain_Edit(_objcas, _objdb);
            var result = from o in _dt.AsEnumerable()
                         where o.Field<int>(0) == Convert.ToInt32((string)Session["casid"])
                         select o;
            foreach (var row in result)
            {
                if (lblsch.Text == "8" || lblsch.Text == "51" || lblsch.Text == "52" || lblsch.Text == "53" || lblsch.Text == "54" || lblsch.Text == "55" || lblsch.Text == "56" || lblsch.Text == "57" || lblsch.Text == "58" || lblsch.Text == "59" || lblsch.Text == "60" || lblsch.Text == "62" || lblsch.Text == "63" || lblsch.Text == "64" || lblsch.Text == "65" || lblsch.Text == "66" || lblsch.Text == "67" || lblsch.Text == "68" || lblsch.Text == "69" || lblsch.Text == "70" || lblsch.Text == "71" || lblsch.Text == "72" || lblsch.Text == "73" || lblsch.Text == "74" || lblsch.Text == "75" || lblsch.Text == "76" || lblsch.Text == "77" || lblsch.Text == "78" || lblsch.Text == "79" || lblsch.Text == "80" || lblsch.Text == "81" || lblsch.Text == "82" || lblsch.Text == "83" || lblsch.Text == "84")
                 {
                     _8pwron.Text = row[14].ToString();
                     _8pc1.Text = row[24].ToString();
                     _8co1.Text = row[25].ToString();
                     _8wd1.Text = row[26].ToString();
                     _8pc2.Text = row[27].ToString();
                     _8co2.Text = row[28].ToString();
                     _8wd2.Text = row[29].ToString();
                     _8dv.Text = row[21].ToString();
                     _8ov.Text = row["tested1"].ToString();
                     _8duty.Text = row["per_com4"].ToString();
                     _8fpt.Text = row["test7"].ToString();
                     _8arm.Text = row["test11"].ToString();
                     _8pft.Text = row["test10"].ToString();
                     _8accept1.Text = row["accept1"].ToString();
                     _8filed1.Text = row["filed1"].ToString();
                     _8commts.Text = row[18].ToString();
                     _8actby.Text = row[19].ToString();
                     _8actdt.Text = row[20].ToString();
                 }
                 else if (lblsch.Text == "9")
                 {
                     _9ics.Text = row[24].ToString();
                     _9pft.Text = row[25].ToString();
                     _9pwr.Text = row[14].ToString();
                     _9pic.Text = row[26].ToString();
                     _9mc.Text = row[27].ToString();
                     _9fc.Text = row[28].ToString();
                     _9fai.Text = row[29].ToString();
                     _9emcs.Text = row[30].ToString();
                     _9dcr.Text = row["test11"].ToString();
                     _9fpt.Text = row["accept1"].ToString();
                     _9dfiled.Text = row["filed1"].ToString();
                     _9accept.Text = row["accept2"].ToString();
                     _9commts.Text = row[18].ToString();
                     _9actby.Text = row[19].ToString();
                     _9actdt.Text = row[20].ToString();
                     if (CheckExist(draccess, row["test10"].ToString()) == true)
                         draccess.Items.FindByText(row["test10"].ToString()).Selected = true;
                     if (CheckExist(draccessability, row["test12"].ToString()) == true)
                         draccessability.Items.FindByText(row["test12"].ToString()).Selected = true;
                 }
                else if (lblsch.Text == "2" || lblsch.Text == "121" || lblsch.Text == "119" || lblsch.Text == "118")
                 {
                     _2eng.Text = row[14].ToString();
                     _2tor.Text = row[24].ToString();
                     _2ir.Text = row[25].ToString();
                     _2hi.Text = row[26].ToString();
                     _2pi.Text = row[27].ToString();
                     _2cr.Text = row[28].ToString();
                     _2pt.Text = row[29].ToString();
                     //if (row[21].ToString() != "0")
                     //    _2cable.Text = row[21].ToString();
                     //else
                     _2cih.Text = row["tested1"].ToString();
                     if (row["tested2"].ToString() != "0")
                         _2dt.Text = row["tested2"].ToString();
                     _2witness.Text = row["accept1"].ToString();
                     _2fpt.Text = row["filed1"].ToString();
                     _2pft.Text = row["accept2"].ToString();
                     _2accept.Text = row["filed2"].ToString();
                     _2commts.Text = row[18].ToString();
                     _2actby.Text = row[19].ToString();
                     _2actdt.Text = row[20].ToString();
                     _2ct.Text = row["test7"].ToString();
                     _2rt.Text = row["test11"].ToString();
                     _2fn.Text = row["test10"].ToString();
                     _2dvc.Text = row[21].ToString();
                 }
                 else if (lblsch.Text == "5" || lblsch.Text=="44")
                 {
                     _5ed.Text = row[14].ToString();
                     _5tor.Text = row[24].ToString();
                     _5ir.Text = row[25].ToString();
                     _5pr.Text = row[26].ToString();
                     _5pi.Text = row[27].ToString();
                     _5si.Text = row[28].ToString();
                     _5cr.Text = row[29].ToString();
                     _5fn.Text = row[30].ToString();
                     _5tc.Text = row["tested1"].ToString();
                     _5tl.Text = row["tested2"].ToString();
                     _5cc.Text = row["test11"].ToString();
                     _5lc.Text = row["test10"].ToString();
                     _5pft.Text = row["accept1"].ToString();
                     _5arm.Text = row["filed1"].ToString();
                     _5fpt.Text = row["accept2"].ToString();
                     _5commts.Text = row[18].ToString();
                     _5actby.Text = row[19].ToString();
                     _5actdt.Text = row[20].ToString();
                     _5total.Text = row[21].ToString();
                 }
                 else if (lblsch.Text == "4")
                 {
                     _4eng.Text = row[14].ToString();
                     _4pc.Text = row[24].ToString();
                     _4cft.Text = row[25].ToString();
                     _4irt.Text = row[26].ToString();
                     _4lt.Text = row[27].ToString();
                     _4ft.Text = row[28].ToString();
                     _4frt.Text = row[29].ToString();
                     _4ct.Text = row[30].ToString();
                     _4ctc.Text = row["test12"].ToString();
                     _4ir.Text = row["test11"].ToString();
                     _4hp.Text = row["test10"].ToString();
                     _4pft.Text = row["test13"].ToString();
                     _4arm.Text = row["filed2"].ToString();
                     _4fpt.Text = row["test14"].ToString();
                     _4accept1.Text = row["accept1"].ToString();
                     _4accept2.Text = row["accept2"].ToString();
                     _4filed1.Text = row["filed1"].ToString();
                     _4commts.Text = row[18].ToString();
                     _4actby.Text = row[19].ToString();
                     _4actdt.Text = row[20].ToString();
                 }
                 else if (lblsch.Text == "6")
                 {
                     _6eng.Text = row[14].ToString();
                     _6ep.Text = row[24].ToString();
                     _6ct.Text = row[25].ToString();
                     _6bc.Text = row[26].ToString();
                     _6pft.Text = row[27].ToString();
                     _6fpt.Text = row[28].ToString();
                     _6arm.Text = row[29].ToString();
                     _6accept1.Text = row["accept1"].ToString();
                     _6filed1.Text = row["filed1"].ToString();
                     _6commts.Text = row[18].ToString();
                     _6actby.Text = row[19].ToString();
                     _6actdt.Text = row[20].ToString();
                 }
                 else if (lblsch.Text == "7")
                 {
                     _7eng.Text = row[14].ToString();
                     _7ir.Text = row[24].ToString();
                     _7sp.Text = row[25].ToString();
                     _7pt.Text = row[26].ToString();
                     _7lllt.Text = row[27].ToString();
                     _7bdt.Text = row[28].ToString();
                     _7gt.Text = row[29].ToString();
                     _7dat.Text = row[30].ToString();
                     _7pft.Text = row["accept1"].ToString();
                     _7fpt.Text = row["accept2"].ToString();
                     _7arm.Text = row["filed1"].ToString();
                     _7commts.Text = row[18].ToString();
                     _7actby.Text = row[19].ToString();
                     _7actdt.Text = row[20].ToString();
                     _7total.Text = row["Substation"].ToString();
                 }
                else if (lblsch.Text == "3" || lblsch.Text == "120")
                 {
                     _3eng.Text = row[14].ToString();
                     _3ir.Text = row[24].ToString();
                     _3tcc.Text = row[25].ToString();
                     _3rvm.Text = row[26].ToString();
                     _3mbt.Text = row[27].ToString();
                     _3wrt.Text = row[28].ToString();
                     _3sct.Text = row[29].ToString();
                     _3ctr.Text = row[30].ToString();
                     _3brt.Text = row["test11"].ToString();
                     _3tcw.Text = row["test10"].ToString();
                     _3toa.Text = row["test12"].ToString();
                     _3bct.Text = row["test13"].ToString();
                     _3ct.Text = row["tested1"].ToString();
                     _3ctd.Text = row["tested2"].ToString();
                     _3pft.Text = row["accept1"].ToString();
                     _3fpt.Text = row["accept2"].ToString();
                     _3arm.Text = row["filed1"].ToString();
                     _3commts.Text = row[18].ToString();
                     _3actby.Text = row[19].ToString();
                     _3actdt.Text = row[20].ToString();
                     _3qty.Text = row[21].ToString();
                 }
                 else if (lblsch.Text == "10")
                 {
                     _10eng.Text = row[14].ToString();
                     _10nct.Text = row[24].ToString();
                     _10ctd.Text = row[25].ToString();
                     _10ndt.Text = row[26].ToString();
                     _10ddt.Text = row[27].ToString();
                     _10fat.Text = row[28].ToString();
                     _10bat.Text = row[29].ToString();
                     _10ghet.Text = row[30].ToString();
                     _10icom.Text = row["test11"].ToString();
                     _10pft.Text = row["test10"].ToString();
                     _10accept1.Text = row["accept1"].ToString();
                     _10filed1.Text = row["filed1"].ToString();
                     _10fpt.Text = row["accept2"].ToString();
                     _10arm.Text = row["filed2"].ToString();
                     _10commts.Text = row[18].ToString();
                     _10actby.Text = row[19].ToString();
                     _10actdt.Text = row[20].ToString();
                     _10dvc.Text = row["substation"].ToString();
                     _10itf.Text = row[21].ToString();
                 }
                 else if (lblsch.Text == "20")
                 {
                     _20eng.Text = row[14].ToString();
                     _20cct.Text = row[24].ToString();
                     _20prg.Text = row[25].ToString();
                     _20npt.Text = row[26].ToString();
                     _20ptc.Text = row[27].ToString();
                     _20sot.Text = row[28].ToString();
                     _20grt.Text = row[29].ToString();
                     _20sin.Text = row[30].ToString();
                     _20icom.Text = row["test11"].ToString();
                     _20pft.Text = row["test10"].ToString();
                     _20accept1.Text = row["accept1"].ToString();
                     _20filed1.Text = row["filed1"].ToString();
                     _20fpt.Text = row["accept2"].ToString();
                     _20arm.Text = row["filed2"].ToString();
                     _20commts.Text = row[18].ToString();
                     _20actby.Text = row[19].ToString();
                     _20actdt.Text = row[20].ToString();
                     _20npnt.Text = row[21].ToString();
                 }
                 else if (lblsch.Text == "23")
                 {
                     _23eng.Text = row[14].ToString();
                     _23cct.Text = row[24].ToString();
                     _23prg.Text = row[25].ToString();
                     _23npt.Text = row[26].ToString();
                     _23ptc.Text = row[27].ToString();
                     _23sot.Text = row[28].ToString();
                     _23grt.Text = row[29].ToString();
                     _23iit.Text = row[30].ToString();
                     _23icomp.Text = row["test11"].ToString();
                     _23pft.Text = row["test10"].ToString();
                     _23accept1.Text = row["accept1"].ToString();
                     _23filed1.Text = row["filed1"].ToString();
                     _23fpt.Text = row["accept2"].ToString();
                     _23arm.Text = row["filed2"].ToString();
                     _23commts.Text = row[18].ToString();
                     _23actby.Text = row[19].ToString();
                     _23actdt.Text = row[20].ToString();
                     _23dvc.Text = row[21].ToString();
                 }
                 else if (lblsch.Text == "11")
                 {
                     _11eng.Text = row[14].ToString();
                     _11cit.Text = row[24].ToString();
                     _11ndt.Text = row[25].ToString();
                     _11ztb.Text = row[26].ToString();
                     _11ztp.Text = row[27].ToString();
                     _11zsl.Text = row[28].ToString();
                     _11zeo.Text = row[29].ToString();
                     _11zai.Text = row[30].ToString();
                     _11bat.Text = row["test11"].ToString();
                     _11grt.Text = row["test10"].ToString();
                     _11iit.Text = row["test12"].ToString();
                     _11icom.Text = row["tested1"].ToString();
                     _11pft.Text = row["tested2"].ToString();
                     _11fpt.Text = row["accept2"].ToString();
                     _11accept1.Text = row["accept1"].ToString();
                     _11arm.Text = row["filed2"].ToString();
                     _11filed1.Text = row["filed1"].ToString();
                     _11commts.Text = row[18].ToString();
                     _11actby.Text = row[19].ToString();
                     _11actdt.Text = row[20].ToString();
                     _11dvc.Text = row[21].ToString();
                 }
                 else if (lblsch.Text == "22")
                 {
                     _22eng.Text = row[14].ToString();
                     _22cit.Text = row[24].ToString();
                     _22prg.Text = row[25].ToString();
                     _22npt.Text = row[26].ToString();
                     _22ptc.Text = row[27].ToString();
                     _22sot.Text = row[28].ToString();
                     _22ust.Text = row[29].ToString();
                     _22grt.Text = row[30].ToString();
                     _22iit.Text = row["test11"].ToString();
                     _22icom.Text = row["test10"].ToString();
                     _22pft.Text = row["test12"].ToString();
                     _22accept1.Text = row["accept1"].ToString();
                     _22filed1.Text = row["filed1"].ToString();
                     _22fpt.Text = row["accept2"].ToString();
                     _22arm.Text = row["filed2"].ToString();
                     _22commts.Text = row[18].ToString();
                     _22actby.Text = row[19].ToString();
                     _22actdt.Text = row[20].ToString();
                     _22nop.Text = row[21].ToString();
                 }
                 else if (lblsch.Text == "15")
                 {
                     _15eng.Text = row[14].ToString();
                     _15cct.Text = row[24].ToString();
                     _15sft_tr.Text = row[25].ToString();
                     _15sft_out.Text = row[26].ToString();
                     _15sft_he.Text = row[27].ToString();
                     _15iit.Text = row[28].ToString();
                     _15icom.Text = row[29].ToString();
                     _15pft.Text = row[30].ToString();
                     _15accept1.Text = row["accept1"].ToString();
                     _15filed1.Text = row["filed1"].ToString();
                     _15fpt.Text = row["accept2"].ToString();
                     _15arm.Text = row["filed2"].ToString();
                     _15commts.Text = row[18].ToString();
                     _15actby.Text = row[19].ToString();
                     _15actdt.Text = row[20].ToString();
                     _15nop.Text = row[21].ToString();
                 }
                 else if (lblsch.Text == "13")
                 {
                     _13eng.Text = row[14].ToString();
                     _13cct.Text = row[24].ToString();
                     _13prg.Text = row[25].ToString();
                     _13cvl.Text = row[26].ToString();
                     _13htv.Text = row[27].ToString();
                     _13htc.Text = row[28].ToString();
                     _13ubt.Text = row[29].ToString();
                     _13iit.Text = row[30].ToString();
                     _13icom.Text = row["test11"].ToString();
                     _13pft.Text = row["test10"].ToString();
                     _13accept1.Text = row["accept1"].ToString();
                     _13filed1.Text = row["filed1"].ToString();
                     _13fpt.Text = row["accept2"].ToString();
                     _13arm.Text = row["filed2"].ToString();
                     _13commts.Text = row[18].ToString();
                     _13actby.Text = row[19].ToString();
                     _13actdt.Text = row[20].ToString();
                     _13nop.Text = row[21].ToString();
                 }
                 else if (lblsch.Text == "16")
                 {
                     _16eng.Text = row[14].ToString();
                     _16cct.Text = row[24].ToString();
                     _16sft.Text = row[25].ToString();
                     _16iit.Text = row[26].ToString();
                     _16icom.Text = row[27].ToString();
                     _16pft.Text = row[28].ToString();
                     _16accept1.Text = row["accept1"].ToString();
                     _16filed1.Text = row["filed1"].ToString();
                     _16fpt.Text = row["accept2"].ToString();
                     _16arm.Text = row["filed2"].ToString();
                     _16commts.Text = row[18].ToString();
                     _16actby.Text = row[19].ToString();
                     _16actdt.Text = row[20].ToString();
                     _16nos.Text = row[21].ToString();
                 }
                 else if (lblsch.Text == "14")
                 {
                     _14eng.Text = row[14].ToString();
                     _14nct.Text = row[24].ToString();
                     _14pcc.Text = row[25].ToString();
                     _14acc.Text = row[26].ToString();
                     _14vcc.Text = row[27].ToString();
                     _14rst.Text = row[28].ToString();
                     _14faa.Text = row[29].ToString();
                     _14icom.Text = row[30].ToString();
                     _14pft.Text = row["test11"].ToString();
                     _14accept1.Text = row["accept1"].ToString();
                     _14filed1.Text = row["filed1"].ToString();
                     _14fpt.Text = row["accept2"].ToString();
                     _14arm.Text = row["filed2"].ToString();
                     _14commts.Text = row[18].ToString();
                     _14actby.Text = row[19].ToString();
                     _14actdt.Text = row[20].ToString();
                     _14noc.Text = row[21].ToString();
                 }
                 else if (lblsch.Text == "24")
                 {
                     _24eng.Text = row[14].ToString();
                     _24cct.Text = row[24].ToString();
                     _24prg.Text = row[25].ToString();
                     _24pbt.Text = row[26].ToString();
                     _24net.Text = row[27].ToString();
                     _24nct.Text = row[28].ToString();
                     _24nat.Text = row[29].ToString();
                     _24nst.Text = row[30].ToString();
                     _24ntt.Text = row["test11"].ToString();
                     _24nmt.Text = row["test10"].ToString();
                     _24it.Text = row["test12"].ToString();
                     _24icom.Text = row["tested1"].ToString();
                     _24pft.Text = row["tested2"].ToString();
                     _24accept1.Text = row["accept1"].ToString();
                     _24filed1.Text = row["filed1"].ToString();
                     _24fpt.Text = row["accept2"].ToString();
                     _24arm.Text = row["filed2"].ToString();
                     _24commts.Text = row[18].ToString();
                     _24actby.Text = row[19].ToString();
                     _24actdt.Text = row[20].ToString();
                     _24nop.Text = row[21].ToString();
                 }
                 else if (lblsch.Text == "25")
                 {
                     _25eng.Text = row[14].ToString();
                     _25cct.Text = row[24].ToString();
                     _25ntt.Text = row[25].ToString();
                     _25pcom.Text = row[26].ToString();
                     _25com.Text = row[27].ToString();
                     _25icom.Text = row[28].ToString();
                     _25pft.Text = row[29].ToString();
                     _25accept1.Text = row["accept1"].ToString();
                     _25filed1.Text = row["filed1"].ToString();
                     _25fpt.Text = row["accept2"].ToString();
                     _25arm.Text = row["filed2"].ToString();
                     _25commts.Text = row[18].ToString();
                     _25actby.Text = row[19].ToString();
                     _25actdt.Text = row[20].ToString();
                     _25not.Text = row[21].ToString();
                 }
                 else if (lblsch.Text == "26")
                 {
                     _26eng.Text = row[14].ToString();
                     _26cbt.Text = row[24].ToString();
                     _26inc.Text = row[25].ToString();
                     _26fnt.Text = row[26].ToString();
                     _26iit.Text = row[27].ToString();
                     _26icom.Text = row[28].ToString();
                     _26pft.Text = row[29].ToString();
                     _26accept1.Text = row["accept1"].ToString();
                     _26filed1.Text = row["filed1"].ToString();
                     _26fpt.Text = row["accept2"].ToString();
                     _26arm.Text = row["filed2"].ToString();
                     _26commts.Text = row[18].ToString();
                     _26actby.Text = row[19].ToString();
                     _26actdt.Text = row[20].ToString();
                 }
                else if (lblsch.Text == "17" || lblsch.Text == "85" || lblsch.Text == "86" || lblsch.Text == "87" || lblsch.Text == "88" || lblsch.Text == "89" || lblsch.Text == "90" || lblsch.Text == "91" || lblsch.Text == "99" || lblsch.Text == "107" || lblsch.Text == "108" || lblsch.Text == "117")
                 {
                     _17eng.Text = row[14].ToString();
                     _17pc1.Text = row[24].ToString();
                     _17co1.Text = row[25].ToString();
                     _17ov.Text = row[26].ToString();
                     _17ovp.Text = row[27].ToString();
                     _17wp.Text = row[28].ToString();
                     _17wd1.Text = row[29].ToString();
                     _17pc2.Text = row[30].ToString();
                     _17co2.Text = row["test11"].ToString();
                     _17icom.Text = row["accept1"].ToString();
                     _17fpt.Text = row["filed1"].ToString();
                     _17pft.Text = row["accept2"].ToString();
                     _17arm.Text = row["filed2"].ToString();
                     _17commts.Text = row[18].ToString();
                     _17actby.Text = row[19].ToString();
                     _17actdt.Text = row[20].ToString();
                 }
                 else if (lblsch.Text == "19")
                 {
                     _19qt.Text = row[24].ToString();
                     _19wd.Text = row[25].ToString();
                     _19icom.Text = row[26].ToString();
                     _19pft.Text = row[27].ToString();
                     _19fpt.Text = row[28].ToString();
                     _19arm.Text = row[29].ToString();
                     _19commts.Text = row[18].ToString();
                     _19actby.Text = row[19].ToString();
                     _19actdt.Text = row[20].ToString();
                     _19qty.Text = row[21].ToString();
                 }
                 else if (lblsch.Text == "27" || lblsch.Text == "46")
                 {
                     _27eng.Text = row[14].ToString();
                     _27pc1.Text = row[24].ToString();
                     _27comm.Text = row[25].ToString();
                     _27wit.Text = row[26].ToString();
                     _27pc2.Text = row[27].ToString();
                     _27comm1.Text = row[28].ToString();
                     _27icom.Text = row["accept1"].ToString();
                     _27pft.Text = row["filed1"].ToString();
                     _27fpt.Text = row["accept2"].ToString();
                     _27arm.Text = row["filed2"].ToString();
                     _27commts.Text = row[18].ToString();
                     _27actby.Text = row[19].ToString();
                     _27actdt.Text = row[20].ToString();
                     _27nop.Text = row[21].ToString();
                 }
                 else if (lblsch.Text == "28")
                 {
                     _28psc.Text = row[14].ToString();
                     _28pcom.Text = row[24].ToString();
                     _28com.Text = row[25].ToString();
                     _28wtd.Text = row[26].ToString();
                     _28opt.Text = row[27].ToString();
                     _28act.Text = row[28].ToString();
                     _28rlt.Text = row[29].ToString();
                     _28cat.Text = row[30].ToString();
                     _28ght.Text = row["test11"].ToString();
                     _283me.Text = row["test10"].ToString();
                     _286me.Text = row["test12"].ToString();
                     _28icom.Text = row["accept1"].ToString();
                     _28pft.Text = row["accept2"].ToString();
                     _28fpt.Text = row["filed1"].ToString();
                     _28arm.Text = row["filed2"].ToString();
                     _28commts.Text = row[18].ToString();
                     _28actby.Text = row[19].ToString();
                     _28actdt.Text = row[20].ToString();
                 }
                 else if (lblsch.Text == "29")
                 {
                     _29eng.Text = row[14].ToString();
                     _29cct.Text = row[24].ToString();
                     _29prg.Text = row[25].ToString();
                     _29nmt.Text = row[26].ToString();
                     _29ptc.Text = row[27].ToString();
                     _29sop.Text = row[28].ToString();
                     _29grt.Text = row[29].ToString();
                     _29iit.Text = row[30].ToString();
                     _29icom.Text = row["test11"].ToString();
                     _29pft.Text = row["test10"].ToString();
                     _29accept1.Text = row["accept1"].ToString();
                     _29fpt.Text = row["accept2"].ToString();
                     _29filed1.Text = row["filed1"].ToString();
                     _29arm.Text = row["filed2"].ToString();
                     _29commts.Text = row[18].ToString();
                     _29actby.Text = row[19].ToString();
                     _29actdt.Text = row[20].ToString();
                     _29noc.Text = row[21].ToString();
                 }
                else if (lblsch.Text == "112" || lblsch.Text == "113" || lblsch.Text == "114" || lblsch.Text == "115" || lblsch.Text == "116")
                {

                 _112icom.Text=row["test1"].ToString();
                _112pft.Text=row["test2"].ToString();
                _29prg.Text=row["test3"].ToString();
                _112sycc.Text=row["test4"].ToString();
                _112pftc.Text=row["test5"].ToString();
                _1123rd.Text=row["test6"].ToString();
                _112fpt.Text=row["test7"].ToString();
                _112arm.Text=row["test8"].ToString();
                _112commts.Text=row["Comm"].ToString();
                 _112actby.Text=row["Act_by"].ToString();
                 _112actdt.Text = row["Act_Date"].ToString();


                }
                //else if (lblsch.Text == "21")
                //{
                //    _21pwron.Text = row[14].ToString();
                //    _21pf.Text = row[24].ToString();
                //    _21fvr.Text = row[25].ToString();
                //    _21cc.Text = row[26].ToString();
                //    _21facc.Text = row[27].ToString();
                //    _21bfc.Text = row[28].ToString();
                //    _21fct.Text = row[29].ToString();
                //    _21accept1.Text = row["accept1"].ToString();
                //    _21filed1.Text = row["filed1"].ToString();
                //    _21commts.Text = row[18].ToString();
                //    _21actby.Text = row[19].ToString();
                //    _21actdt.Text = row[20].ToString();
                //}
                //else if (lblsch.Text == "17")
                //{
                //    _17pwron.Text = row[14].ToString();
                //    _17pc1.Text = row[24].ToString();
                //    _17co1.Text = row[25].ToString();
                //    _17wd1.Text = row[26].ToString();
                //    _17pc2.Text = row[27].ToString();
                //    _17co2.Text = row[28].ToString();
                //    _17wd2.Text = row[29].ToString();
                //    _17accept1.Text = row["accept1"].ToString();
                //    _17filed1.Text = row["filed1"].ToString();
                //    _17commts.Text = row[18].ToString();
                //    _17actby.Text = row[19].ToString();
                //    _17actdt.Text = row[20].ToString();
                //}
                //else if (lblsch.Text == "18")
                //{
                //    if ((string)Session["cat"] == "FHR") _18qt.Text = row[24].ToString();
                //    else if ((string)Session["cat"] == "ZCV") _18qt.Text = row[25].ToString();
                //    else if ((string)Session["cat"] == "MOV") _18qt.Text = row[26].ToString();
                //    else if ((string)Session["cat"] == "PRS") _18qt.Text = row[27].ToString();
                //    else if ((string)Session["cat"] == "LGV") _18qt.Text = row[28].ToString();
                //    else if ((string)Session["cat"] == "CSC") _18qt.Text = row[29].ToString();
                //    _18wt.Text = row[30].ToString();
                //    _18accept1.Text = row["accept1"].ToString();
                //    _18filed1.Text = row["filed1"].ToString();
                //    _18commts.Text = row[18].ToString();
                //    _18actby.Text = row[19].ToString();
                //    _18actdt.Text = row[20].ToString();
                //    _18noof.Text = row[21].ToString();
                //}
                //else if (lblsch.Text == "19")
                //{
                //    _19rsit.Text = row[24].ToString();
                //    _19sac.Text = row[25].ToString();
                //    _19fbit.Text = row[26].ToString();
                //    _19wt.Text = row[27].ToString();
                //    _19accept1.Text = row["accept1"].ToString();
                //    _19filed1.Text = row["filed1"].ToString();
                //    _19commts.Text = row[18].ToString();
                //    _19actby.Text = row[19].ToString();
                //    _19actdt.Text = row[20].ToString();
                //}
                //else if (lblsch.Text == "20")
                //{
                //    _20cit.Text = row[24].ToString();
                //    _20ppt.Text = row[25].ToString();
                //    _20cft.Text = row[26].ToString();
                //    _20sot.Text = row[27].ToString();
                //    _20ght.Text = row[28].ToString();
                //    _20lt.Text = row[29].ToString();
                //    _20accept1.Text = row[30].ToString();
                //    _20filed1.Text = row["test11"].ToString();
                //    _20accept2.Text = row["accept1"].ToString();
                //    _20filed2.Text = row["filed1"].ToString();
                //    _20accept3.Text = row["accept2"].ToString();
                //    _20filed3.Text = row["filed2"].ToString();
                //    _20commts.Text = row[18].ToString();
                //    _20actby.Text = row[19].ToString();
                //    _20actdt.Text = row[20].ToString();
                //}
                //else if (lblsch.Text == "13")
                //{
                //    _13cit.Text = row[24].ToString();
                //    _13cvl.Text = row[25].ToString();
                //    _13cvh.Text = row[26].ToString();
                //    _13ast.Text = row[27].ToString();
                //    _13rbst.Text = row[28].ToString();
                //    _13accept1.Text = row["accept1"].ToString();
                //    _13filed1.Text = row["filed1"].ToString();
                //    _13commts.Text = row[18].ToString();
                //    _13actby.Text = row[19].ToString();
                //    _13actdt.Text = row[20].ToString();
                //    _13noof.Text = row[21].ToString();
                //}
                //else if (lblsch.Text == "22")
                //{
                //    _22cit.Text = row[24].ToString();
                //    _22apt.Text = row[25].ToString();
                //    _22fat.Text = row[26].ToString();
                //    _22acs.Text = row[27].ToString();
                //    _22pft.Text = row[28].ToString();
                //    _22it.Text = row[29].ToString();
                //    _22phgt.Text = row[30].ToString();
                //    _22accept1.Text = row["accept1"].ToString();
                //    _22filed1.Text = row["filed1"].ToString();
                //    _22commts.Text = row[18].ToString();
                //    _22actby.Text = row[19].ToString();
                //    _22actdt.Text = row[20].ToString();
                //    _22noof.Text = row[21].ToString();
                //}
                //else if (lblsch.Text == "11")
                //{
                //    _11cit.Text = row[24].ToString();
                //    _11lct.Text = row[25].ToString();
                //    _11apt.Text = row[26].ToString();
                //    _11phgt.Text = row[27].ToString();
                //    _11accept1.Text = row["accept1"].ToString();
                //    _11filed1.Text = row["filed1"].ToString();
                //    _11commts.Text = row[18].ToString();
                //    _11actby.Text = row[19].ToString();
                //    _11actdt.Text = row[20].ToString();
                //}
                //else if (lblsch.Text == "12")
                //{
                //    _12ct.Text = row[24].ToString();
                //    _12accept1.Text = row["accept1"].ToString();
                //    _12filed1.Text = row["filed1"].ToString();
                //    _12commts.Text = row[18].ToString();
                //    _12actby.Text = row[19].ToString();
                //    _12actdt.Text = row[20].ToString();
                //    _12nop.Text = row[21].ToString();
                //}
                //else if (lblsch.Text == "15")
                //{
                //    _15cit.Text = row[24].ToString();
                //    _15kca.Text = row[25].ToString();
                //    _15dnd.Text = row[26].ToString();
                //    _15mur.Text = row[27].ToString();
                //    _15ftc.Text = row[28].ToString();
                //    _15ems.Text = row[29].ToString();
                //    _15lsc.Text = row[30].ToString();
                //    _15bci.Text = row["test11"].ToString();
                //    _15mif.Text = row["test10"].ToString();
                //    _15accept1.Text = row["accept1"].ToString();
                //    _15filed1.Text = row["filed1"].ToString();
                //    _15commts.Text = row[18].ToString();
                //    _15actby.Text = row[19].ToString();
                //    _15actdt.Text = row[20].ToString();
                //    _15noof.Text = row[21].ToString();
                //}
                //else if (lblsch.Text == "14")
                //{
                //    _14cit.Text = row[24].ToString();
                //    _14diab.Text = row[25].ToString();
                //    _14avt.Text = row[26].ToString();
                //    _14drt.Text = row[27].ToString();
                //    _14accept1.Text = row["accept1"].ToString();
                //    _14filed1.Text = row["filed1"].ToString();
                //    _14commts.Text = row[18].ToString();
                //    _14actby.Text = row[19].ToString();
                //    _14actdt.Text = row[20].ToString();
                //    _14noof.Text = row[21].ToString();
                //}
                //else if (lblsch.Text == "23")
                //{
                //    _23tc.Text = row[24].ToString();
                //    _23tpi.Text = row[25].ToString();
                //    _23eml.Text = row[26].ToString();
                //    _23pfm.Text = row[27].ToString();
                //    _23lms.Text = row[28].ToString();
                //    _23int.Text = row[29].ToString();
                //    _23bfa.Text = row[30].ToString();
                //    _23accept1.Text = row["accept1"].ToString();
                //    _23filed1.Text = row["filed1"].ToString();
                //    _23commts.Text = row[18].ToString();
                //    _23actby.Text = row[19].ToString();
                //    _23actdt.Text = row[20].ToString();
                //}
                //else if (lblsch.Text == "16")
                //{
                //    _16ir.Text = row[24].ToString();
                //    _16ppt.Text = row[25].ToString();
                //    _16cft.Text = row[26].ToString();
                //    _16sop.Text = row[27].ToString();
                //    _16ght.Text = row[28].ToString();
                //    _16accept1.Text = row["accept1"].ToString();
                //    _16filed1.Text = row["filed1"].ToString();
                //    _16accept2.Text = row["accept2"].ToString();
                //    _16filed2.Text = row["filed2"].ToString();
                //    _16commts.Text = row[18].ToString();
                //    _16actby.Text = row[19].ToString();
                //    _16actdt.Text = row[20].ToString();
                //}
                //else if (lblsch.Text == "24")
                //{
                //    _24pwron.Text = row[14].ToString();
                //    _24ir.Text = row[24].ToString();
                //    _24ft.Text = row[25].ToString();
                //    _24it.Text = row[26].ToString();
                //    _24accept1.Text = row["accept1"].ToString();
                //    _24filed1.Text = row["filed1"].ToString();
                //    _24commts.Text = row[18].ToString();
                //    _24actby.Text = row[19].ToString();
                //    _24actdt.Text = row[20].ToString();
                //}
                //else if (lblsch.Text == "30")
                //{
                //    _30pwron.Text = row[14].ToString();
                //    _30pc1.Text = row[24].ToString();
                //    _30co1.Text = row[25].ToString();
                //    _30wd1.Text = row[26].ToString();
                //    _30pc2.Text = row[27].ToString();
                //    _30co2.Text = row[28].ToString();
                //    _30wd2.Text = row[29].ToString();
                //    _30idc.Text = row["test7"].ToString();
                //    _30dlt.Text = row["test11"].ToString();
                //    _30accept1.Text = row["accept1"].ToString();
                //    _30filed1.Text = row["filed1"].ToString();
                //    _30commts.Text = row[18].ToString();
                //    _30actby.Text = row[19].ToString();
                //    _30actdt.Text = row[20].ToString();
                //}
                //else if (lblsch.Text == "25" || lblsch.Text == "26")
                //{
                //    _25pwron.Text = row[14].ToString();
                //    _25pc1.Text = row[24].ToString();
                //    _25co1.Text = row[25].ToString();
                //    _25wd1.Text = row[26].ToString();
                //    _25pc2.Text = row[27].ToString();
                //    _25co2.Text = row[28].ToString();
                //    _25wd2.Text = row[29].ToString();
                //    _25idc.Text = row["test7"].ToString();
                //    _25accept1.Text = row["accept1"].ToString();
                //    _25filed1.Text = row["filed1"].ToString();
                //    _25commts.Text = row[18].ToString();
                //    _25actby.Text = row[19].ToString();
                //    _25actdt.Text = row[20].ToString();
                //}
                //else if (lblsch.Text == "28")
                //{
                //    _28idc.Text = row[24].ToString();
                //    _28prc.Text = row[25].ToString();
                //    _28sac.Text = row[26].ToString();
                //    _28fit.Text = row[27].ToString();
                //    _28wts.Text = row[28].ToString();
                //    _28accept1.Text = row["accept1"].ToString();
                //    _28filed1.Text = row["filed1"].ToString();
                //    _28commts.Text = row[18].ToString();
                //    _28actby.Text = row[19].ToString();
                //    _28actdt.Text = row[20].ToString();
                //}
                //else if (lblsch.Text == "34")
                //{
                //    _34mec.Text = row[24].ToString();
                //    _34ele.Text = row[25].ToString();
                //    _34fbs.Text = row[26].ToString();
                //    _34bia.Text = row[27].ToString();
                //    _34pft.Text = row[28].ToString();
                //    _34epp.Text = row[29].ToString();
                //    _34fct.Text = row[30].ToString();
                //    _34prt.Text = row["test11"].ToString();
                //    _34accept1.Text = row["accept1"].ToString();
                //    _34filed1.Text = row["filed1"].ToString();
                //    _34commts.Text = row[18].ToString();
                //    _34actby.Text = row[19].ToString();
                //    _34actdt.Text = row[20].ToString();
                //}
                //else if (lblsch.Text == "35")
                //{
                //    _35mec.Text = row[24].ToString();
                //    _35ele.Text = row[25].ToString();
                //    _35fbs.Text = row[26].ToString();
                //    _35bia.Text = row[27].ToString();
                //    _35nlt.Text = row[28].ToString();
                //    _35vit.Text = row[29].ToString();
                //    _35aca.Text = row[30].ToString();
                //    _35accept1.Text = row["accept1"].ToString();
                //    _35filed1.Text = row["filed1"].ToString();
                //    _35commts.Text = row[18].ToString();
                //    _35actby.Text = row[19].ToString();
                //    _35actdt.Text = row[20].ToString();
                //}
                //else if (lblsch.Text == "36")
                //{
                //    _36cpc.Text = row[24].ToString();
                //    _36lpc.Text = row[25].ToString();
                //    _36cbr.Text = row[26].ToString();
                //    _36lbr.Text = row[27].ToString();
                //    _36wcl.Text = row[28].ToString();
                //    _36coa.Text = row[29].ToString();
                //    _36lot.Text = row[30].ToString();
                //    _36sls.Text = row["test11"].ToString();
                //    _36fle.Text = row["test10"].ToString();
                //    _36tsc.Text = row["test12"].ToString();
                //    _36tpi.Text = row["test13"].ToString();
                //    _36accept1.Text = row["accept1"].ToString();
                //    _36filed1.Text = row["filed1"].ToString();
                //    _36commts.Text = row[18].ToString();
                //    _36actby.Text = row[19].ToString();
                //    _36actdt.Text = row[20].ToString();
                //}
            }
        }
        private bool CheckExist(DropDownList _drlist, string _string)
        {
            foreach (ListItem _lst in _drlist.Items)
            {
                if (String.Compare(_lst.Text, _string) == 0)
                    return true;
            }
            return false;
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            //btnDummy_ModalPopupExtender2.Hide();
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

        protected void drloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["loc"] = drloc.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text);
        }

        protected void _8btnupdate_Click(object sender, EventArgs e)
        {
            Update(_8pwron.Text, _8pc1.Text, _8co1.Text, _8wd1.Text, _8pc2.Text, _8co2.Text, _8wd2.Text, _8fpt.Text, _8arm.Text, _8pft.Text, "", "", "", _8ov.Text, "", "", "", "", _8accept1.Text, "", _8filed1.Text, "", _8commts.Text, _8actby.Text, _8actdt.Text);
            btnDummy_ModalPopupExtender7.Hide();
        }
        protected void _8btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender7.Hide();
        }

        protected void _9btnupdate_Click(object sender, EventArgs e)
        {
            Update(_9pwr.Text, _9ics.Text, _9pft.Text, _9pic.Text, _9mc.Text, _9fc.Text, _9fai.Text, _9emcs.Text, _9dcr.Text,draccess.SelectedItem.Text,draccessability.SelectedItem.Text, "", "", "", "", "", "", "", _9fpt.Text, _9accept.Text, _9dfiled.Text, "", _9commts.Text, _9actby.Text, _9actdt.Text);
            btnDummy_ModalPopupExtender9.Hide();
        }

        protected void _9btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender9.Hide();
        }

        protected void _2btnupdate_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(_2dvc.Text) < Convert.ToInt32(_2cih.Text))
            {
                btnDummy_ModalPopupExtender_.Show();
                return;
            }
            Update(_2eng.Text, _2tor.Text, _2ir.Text, _2hi.Text, _2pi.Text, _2cr.Text, _2pt.Text, _2ct.Text, _2rt.Text, _2fn.Text, "", "", "", _2cih.Text, _2dt.Text, "", "", "", _2witness.Text, _2pft.Text, _2fpt.Text, _2accept.Text, _2commts.Text, _2actby.Text, _2actdt.Text);
            btnDummy_ModalPopupExtender1.Hide();
        }

        protected void _2btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender1.Hide();
        }
        protected void _5btnupdate_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(_5total.Text) < Convert.ToInt32(_5tc.Text) || Convert.ToInt32(_5total.Text) < Convert.ToInt32(_5tl.Text))
            {
                btnDummy_ModalPopupExtender_.Show();
                return;
            }
            Update(_5ed.Text, _5tor.Text, _5ir.Text, _5pr.Text, _5pi.Text, _5si.Text, _5cr.Text, _5fn.Text,_5cc.Text, _5lc.Text, "", "", "", _5tc.Text, _5tl.Text, "", "", "", _5pft.Text, _5fpt.Text, _5arm.Text, "", _5commts.Text, _5actby.Text, _5actdt.Text);
            btnDummy_ModalPopupExtender4.Hide();
        }
        protected void _5btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender4.Hide();
        }

        protected void _4btnupdate_Click(object sender, EventArgs e)
        {
            Update(_4eng.Text, _4pc.Text, _4cft.Text, _4irt.Text, _4lt.Text, _4ft.Text, _4frt.Text, _4ct.Text, _4ir.Text, _4hp.Text, _4ctc.Text, _4pft.Text, _4fpt.Text, "", "", "", "", "", _4accept1.Text, _4accept2.Text, _4filed1.Text, _4arm.Text, _4commts.Text, _4actby.Text, _4actdt.Text);
            btnDummy_ModalPopupExtender5.Hide();
        }

        protected void _4btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender5.Hide();
        }

        protected void _6btnupdate_Click(object sender, EventArgs e)
        {
            Update(_6eng.Text, _6ep.Text, _6ct.Text, _6bc.Text, _6pft.Text, _6fpt.Text, _6arm.Text, "", "", "", "", "", "", "", "", "", "", "", _6accept1.Text, "", _6filed1.Text, "", _6commts.Text, _6actby.Text, _6actdt.Text);
            btnDummy_ModalPopupExtender3.Hide();
        }

        protected void _6btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender3.Hide();
        }
        protected void _3btnupdate_Click(object sender, EventArgs e)
        {
            Update(_3eng.Text, _3ir.Text, _3tcc.Text, _3rvm.Text, _3mbt.Text, _3wrt.Text, _3sct.Text, _3ctr.Text, _3brt.Text,_3tcw.Text, _3toa.Text,_3bct .Text, "",_3ct.Text, _3ctd.Text, "", "", "", _3pft.Text, _3fpt.Text, _3arm.Text, "", _3commts.Text, _3actby.Text, _3actdt.Text);
            btnDummy_ModalPopupExtender2.Hide();
        }
        protected void _3btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender2.Hide();
        }

        protected void _7btnupdate_Click(object sender, EventArgs e)
        {
            Update(_7eng.Text, _7ir.Text, _7sp.Text, _7pt.Text, _7lllt.Text, _7bdt.Text, _7gt.Text, _7dat.Text, "", "", "", "", "", "", "", "", "", "", _7pft.Text, _7fpt.Text, _7arm.Text, "", _7commts.Text, _7actby.Text, _7actdt.Text);
            btnDummy_ModalPopupExtender6.Hide();
        }

        protected void _7btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender6.Hide();
        }

        protected void _10btnupdate_Click(object sender, EventArgs e)
        {
            Update(_10eng.Text, _10nct.Text, _10ctd.Text, _10ndt.Text, _10ddt.Text, _10fat.Text, _10bat.Text, _10ghet.Text, _10icom.Text, _10pft.Text, "", "", "", "", "", "", "", "", _10accept1.Text, _10fpt.Text, _10filed1.Text, _10arm.Text, _10commts.Text, _10actby.Text, _10actdt.Text);
            btnDummy_ModalPopupExtender13.Hide();
        }

        protected void _10btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender13.Hide();
        }

        protected void _20btnupdate_Click(object sender, EventArgs e)
        {
            Update(_20eng.Text, _20cct.Text, _20prg.Text, _20npt.Text, _20ptc.Text, _20sot.Text, _20grt.Text, _20sin.Text, _20icom.Text, _20pft.Text, "", "", "", "", "", "", "", "", _20accept1.Text, _20fpt.Text, _20filed1.Text, _20arm.Text, _20commts.Text, _20actby.Text, _20actdt.Text);
            btnDummy_ModalPopupExtender14.Hide();
        }

        protected void _20btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender14.Hide();
        }

        protected void _23btnupdate_Click(object sender, EventArgs e)
        {
            Update(_23eng.Text, _23cct.Text, _23prg.Text, _23npt.Text, _23ptc.Text, _23sot.Text, _23grt.Text, _23iit.Text, _23icomp.Text, _23pft.Text, "", "", "", "", "", "", "", "", _23accept1.Text, _23fpt.Text, _23filed1.Text, _23arm.Text, _23commts.Text, _23actby.Text, _23actdt.Text);
            btnDummy_ModalPopupExtender21.Hide();
        }

        protected void _23btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender21.Hide();
        }

        protected void _11btnupdate_Click(object sender, EventArgs e)
        {
            Update(_11eng.Text, _11cit.Text, _11ndt.Text, _11ztb.Text, _11ztp.Text, _11zsl.Text, _11zeo.Text, _11zai.Text, _11bat.Text, _11grt.Text, _11iit.Text, "", "", _11icom.Text, _11pft.Text, "", "", "", _11accept1.Text, _11fpt.Text, _11filed1.Text, _11arm.Text, _11commts.Text, _11actby.Text, _11actdt.Text);
            btnDummy_ModalPopupExtender17.Hide();
        }

        protected void _11btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender17.Hide();
        }

        protected void _22btnupdate_Click(object sender, EventArgs e)
        {
            Update(_22eng.Text, _22cit.Text, _22prg.Text, _22npt.Text, _22ptc.Text, _22sot.Text, _22ust.Text, _22grt.Text, _22iit.Text, _22icom.Text, _22pft.Text, "", "", "", "", "", "", "", _22accept1.Text, _22fpt.Text, _22filed1.Text, _22arm.Text, _22commts.Text, _22actby.Text, _22actdt.Text);
            btnDummy_ModalPopupExtender16.Hide();
        }

        protected void _22btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender16.Hide();
        }

        protected void _15btnupdate_Click(object sender, EventArgs e)
        {
            Update(_15eng.Text, _15cct.Text, _15sft_tr.Text, _15sft_out.Text, _15sft_he.Text, _15iit.Text, _15icom.Text, _15pft.Text, "", "", "", "", "", "", "", "", "", "", _15accept1.Text, _15fpt.Text, _15filed1.Text, _15arm.Text, _15commts.Text, _15actby.Text, _15actdt.Text);
            btnDummy_ModalPopupExtender19.Hide();
        }

        protected void _15btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender19.Hide();
        }

        protected void _13btnupdate_Click(object sender, EventArgs e)
        {
            Update(_13eng.Text, _13cct.Text, _13prg.Text, _13cvl.Text, _13htv.Text, _13htc.Text, _13ubt.Text, _13iit.Text, _13icom.Text, _13pft.Text, "", "", "", "", "", "", "", "", _13accept1.Text, _13fpt.Text, _13filed1.Text, _13arm.Text, _13commts.Text, _13actby.Text, _13actdt.Text);
            btnDummy_ModalPopupExtender15.Hide();
        }

        protected void _13btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender15.Hide();
        }

        protected void _16btnupdate_Click(object sender, EventArgs e)
        {
            Update(_16eng.Text, _16cct.Text, _16sft.Text, _16iit.Text, _16icom.Text, _16pft.Text, "", "", "", "", "", "", "", "", "", "", "", "", _16accept1.Text, _16fpt.Text, _16filed1.Text, _16arm.Text, _16commts.Text, _16actby.Text, _16actdt.Text);
            btnDummy_ModalPopupExtender22.Hide();
        }

        protected void _16btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender22.Hide();
        }

        protected void _14btnupdate_Click(object sender, EventArgs e)
        {
            Update(_14eng.Text, _14nct.Text, _14pcc.Text, _14acc.Text, _14vcc.Text, _14rst.Text, _14faa.Text, _14icom.Text, _14pft.Text, "", "", "", "", "", "", "", "", "", _14accept1.Text, _14fpt.Text, _14filed1.Text, _14arm.Text, _14commts.Text, _14actby.Text, _14actdt.Text);
            btnDummy_ModalPopupExtender20.Hide();
        }

        protected void _14btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender20.Hide();
        }

        protected void _24btnupdate_Click(object sender, EventArgs e)
        {
            Update(_24eng.Text, _24cct.Text, _24prg.Text, _24pbt.Text, _24net.Text, _24nct.Text, _24nat.Text, _24nst.Text, _24ntt.Text, _24nmt.Text, _24it.Text, "", "", _24icom.Text, _24pft.Text, "", "", "", _24accept1.Text, _24fpt.Text, _24filed1.Text, _24arm.Text, _24commts.Text, _24actby.Text, _24actdt.Text);
            btnDummy_ModalPopupExtender23.Hide();
        }

        protected void _24btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender23.Hide();
        }

        protected void _25btnupdate_Click(object sender, EventArgs e)
        {
            Update(_25eng.Text, _25cct.Text, _25ntt.Text, _25pcom.Text, _25com.Text, _25icom.Text, _25pft.Text, "", "", "", "", "", "", "", "", "", "", "", _25accept1.Text, _25fpt.Text, _25filed1.Text, _25arm.Text, _25commts.Text, _25actby.Text, _25actdt.Text);
            btnDummy_ModalPopupExtender25.Hide();
        }

        protected void _25btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender25.Hide();
        }

        protected void _26btnupdate_Click(object sender, EventArgs e)
        {
            Update(_26eng.Text, _26cbt.Text, _26inc.Text, _26fnt.Text, _26iit.Text, _26icom.Text, _26pft.Text, "", "", "", "", "", "", "", "", "", "", "", _26accept1.Text, _26fpt.Text, _26filed1.Text, _26arm.Text, _26commts.Text, _26actby.Text, _26actdt.Text);
            btnDummy_ModalPopupExtender29.Hide();
        }

        protected void _26btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender29.Hide();
        }

        protected void _17btnupdate_Click(object sender, EventArgs e)
        {
            Update(_17eng.Text, _17pc1.Text, _17co1.Text, _17ov.Text, _17ovp.Text, _17wp.Text, _17wd1.Text, _17pc2.Text, _17co2.Text, "", "", "", "", "", "", "", "", "", _17icom.Text, _17pft.Text, _17fpt.Text, _17arm.Text, _17commts.Text, _17actby.Text, _17actdt.Text);
            btnDummy_ModalPopupExtender10.Hide();
        }

        protected void _17btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender10.Hide();
        }

        protected void _19btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _19qt.Text, _19wd.Text, _19icom.Text, _19pft.Text, _19fpt.Text, _19arm.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", _19commts.Text, _19actby.Text, _19actdt.Text);
            btnDummy_ModalPopupExtender12.Hide();
        }

        protected void _19btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender12.Hide();
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

        protected void _27btnupdate_Click(object sender, EventArgs e)
        {
            Update(_27eng.Text, _27pc1.Text, _27comm.Text, _27wit.Text, _27pc2.Text, _27comm1.Text, "", "", "", "", "", "", "", "", "", "", "", "", _27icom.Text, _27pft.Text, _27fpt.Text, _27arm.Text, _27commts.Text, _27actby.Text, _27actdt.Text);
            btnDummy_ModalPopupExtender30.Hide();
        }

        protected void _27btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender30.Hide();
        }

        protected void _28btnupdate_Click(object sender, EventArgs e)
        {
            Update(_28psc.Text, _28pcom.Text, _28com.Text, _28wtd.Text, _28opt.Text, _28act.Text, _28rlt.Text, _28cat.Text, _28ght.Text, _283me.Text, _286me.Text, "", "", "", "", "", "", "", _28icom.Text, _28pft.Text, _28fpt.Text, _28arm.Text, _28commts.Text, _28actby.Text, _28actdt.Text);
            btnDummy_ModalPopupExtender26.Hide();
        }

        protected void _28btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender26.Hide();
        }

        protected void _29btnupdate_Click(object sender, EventArgs e)
        {
            Update(_29eng.Text, _29cct.Text, _29prg.Text, _29nmt.Text, _29ptc.Text, _29sop.Text, _29grt.Text, _29iit.Text, _29icom.Text, _29pft.Text, "", "", "", "", "", "", "", "", _29accept1.Text, _29fpt.Text, _29filed1.Text, _29arm.Text, _29commts.Text, _29actby.Text, _29actdt.Text);
            btnDummy_ModalPopupExtender27.Hide();
        }

        protected void _29btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender27.Hide();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (lblsch.Text == "5")
                Update_Circuits(_5total);
            else if (lblsch.Text == "2")
                Update_Circuits(_2dvc);
        }
        private void Update_Circuits(TextBox  _txt)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();
            _objcls.cas_id = Convert.ToInt32((string)Session["casid"]);
            _objcls.dev1 = txt_noofcircuit.Text;
            _objbll.Update_Circuit(_objcls, _objdb);
            _txt.Text = txt_noofcircuit.Text;
            btnDummy_ModalPopupExtender_.Hide();
        }
        protected void btncan_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender_.Hide();
        }

        protected void _112btnupdate_Click(object sender, EventArgs e)
        {
            Update("",_112icom.Text, _112pft.Text, _29prg.Text, _112sycc.Text, _112pftc.Text, _1123rd.Text, _112fpt.Text, _112arm.Text,"", "", "", "", "", "", "", "", "", "", "", "", "", _112commts.Text, _112actby.Text, _112actdt.Text);
            btnDummy_ModalPopupExtender112.Hide();

        }

        protected void _112btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender112.Hide();
        }
    }
}
