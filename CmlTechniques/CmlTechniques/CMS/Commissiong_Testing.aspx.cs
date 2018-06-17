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
    public partial class Commissiong_Testing : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtfilter;
        public static DataTable _dtresult;
        public bool isElvdateProject;   
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
                tdiv.Visible = false; ddiv.Visible = false; odiv.Visible = false;

                isElvdateProject = (Array.IndexOf(Constants.CMLTConstants.ElvDateProjects, lblprj.Text) > -1) ? true : false;

                if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s" || lblprj.Text == "AFV")
                {
                    lblsch.Text = _prm.Substring(_prm.IndexOf("_S") + 2, _prm.IndexOf("_D") - (_prm.IndexOf("_S") + 2));
                    lbldiv.Text = _prm.Substring(_prm.IndexOf("_D") + 2);
                    tdiv.Visible = true; ddiv.Visible = true; odiv.Visible = true;
                }
                else if (lblprj.Text == "HMIM" || lblprj.Text == "14211" || lblprj.Text == "HMHS")
                {
                    lblsch.Text = _prm.Substring(_prm.IndexOf("_S") + 2, _prm.IndexOf("_F") - (_prm.IndexOf("_S") + 2));
                    lbldiv.Text = _prm.Substring(_prm.IndexOf("_F") + 2);
                    //CalendarExtender236.PopupButtonID = "_10ccit";
                }
                else
                {
                    lblsch.Text = _prm.Substring(_prm.IndexOf("_S") + 2);
                    //CalendarExtender236.Enabled = false;
                }

                if (!isElvdateProject) { CalendarExtender_10ccit.Enabled = false; }

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
            isElvdateProject = (Array.IndexOf(Constants.CMLTConstants.ElvDateProjects, lblprj.Text) > -1) ? true : false;
        }
        protected void settings()
        {

            if (lblsch.Text == "5" || lblsch.Text == "1" || (lblprj.Text == "11784" && lblsch.Text == "28"))
            {
                lbnum.Text = "NO.OF CIRCUITS";
                lbl1.Text = "PROVIDES POWER TO";
                lbl3.Text = "FED FROM";

                if (lblprj.Text == "11784" && (string)Session["sch"] == "28")
                {
                    lblhead.Text = "CAS E4 Electrical Services. LV Commissioning Activity Schedule - Marketing Suite";
                }
                else
                lblhead.Text = "CAS E4 Electrical Services. LV Commissioning Activity Schedule";
                td_2.Visible = false; td_lbl2.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "2" || (lblprj.Text == "11784" && lblsch.Text  == "25"))
            {
                //lbnum.Text = "";
                //lbnum.Enabled = false;
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "SUBSTATION";
                lbl3.Text = "FED FROM";

                if (lblprj.Text == "11784" && (string)Session["sch"] == "25")
                {
                    lblhead.Text = "CAS E1 Electrical Services. HV-MV Switchgear & RMU Commissioning Activity Schedule - Marketing Suite";
                }
                else
                lblhead.Text = "CAS E1 Electrical Services. HV-MV Switchgear & RMU Commissioning Activity Schedule";

                if (lblprj.Text == "HMIM")
                {
                    lbnum.Text="NO. OF CABLES";
                    td_lbldes.Visible = false; td_txtdescr.Visible = false;
                }
                else
                {
                    td_3.Visible = false; td_lbnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
                }
            }
            else if (lblsch.Text == "3" || (lblprj.Text == "11784" && lblsch.Text == "26"))
            {
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "AREA";
                lbl3.Text = "FED FROM";
                if (lblprj.Text == "11784" && (string)Session["sch"] == "26")
                {
                    lblhead.Text = "CAS E2 Electrical Services. HV & MV Transformers Commissioning Activity Schedule - Marketing Suite";
                }
                else
                lblhead.Text = "CAS E2 Electrical Services. HV & MV Transformers Commissioning Activity Schedule";
                td_3.Visible = false; td_lbnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "4" || (lblprj.Text == "11784" && lblsch.Text == "27"))
            {
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "SUBSTATION";
                lbl3.Text = "FED FROM";
                td_2.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_lbnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
                if (lblprj.Text == "11784" && (string)Session["sch"] == "27")
                {
                    lblhead.Text = "CAS E5 Electrical Services. Generator Commissioning Activity Schedule - Marketing Suite";
                }
                else
                lblhead.Text = "CAS E5 Electrical Services. Generator Commissioning Activity Schedule";
            }
            else if (lblsch.Text == "6" || (lblprj.Text == "11784" && lblsch.Text == "29"))
            {
                lbnum.Text = "";
                lbl1.Text = "PROVIDES EARTHING/LIGHTNING PROTECTION TO";
                lbl2.Text = "";
                lbl3.Text = "";
                drfed.Style.Add("display", "none");
                if (lblprj.Text == "11784" && lblsch.Text == "29")
                {
                    lblhead.Text = "CAS E3 Electrical Services. Earthing & Lightning Protection Commissioning Activity Schedule - Marketing Suite";
                }
                else
                lblhead.Text = "CAS E3 Electrical Services. Earthing & Lightning Protection Commissioning Activity Schedule";
                td_2.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_lbnum.Visible = false; td_1.Visible = false; td_lbl3.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "7" || (lblprj.Text == "11784" && lblsch.Text == "30"))
            {
                lbnum.Text = "NO.OF EMERGENCY LIGHTS";
                lbl1.Text = "";
                lbl3.Text = "";
                lbl2.Text = "NO.OF CIRCUITS";
                drfed.Style.Add("display", "none");
                if (lblprj.Text == "ASAO")
                {
                    lblhead.Text = "CAS E6 Electrical Services. Emergency Lighting Commissioning Activity Schedule";
                    td_1.Visible = false; td_lbl3.Visible = false; td_lbl1.Visible = false; td_0.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
                }
                else
                {
                    if (lblprj.Text == "11784" && (string)Session["sch"] == "30")
                    {
                        lblhead.Text = "CAS E6 Electrical Services. Emergency Lighting Commissioning Activity Schedule - Marketing Suite";
                    }
                    else
                    lblhead.Text = "CAS E6 Electrical Services. Emergency Lighting Commissioning Activity Schedule";
                    td_2.Visible = false; td_lbl2.Visible = false; td_1.Visible = false; td_lbl3.Visible = false; td_lbl1.Visible = false; td_0.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
                }
            }
            else if (lblsch.Text == "8" || (lblprj.Text == "11784" && lblsch.Text == "31"))
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
                lblpft.Visible = false;
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    lblhead.Text = "CAS M9 Fuel Systems Commissioning Activity Schedule";
                    td_0.Visible = false; td_lbnum.Visible = false; td_lbl1.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
                }
                else if (lblprj.Text == "CCAD")
                {
                    lblhead.Text = "CAS M1 Mechanical Services Commissioning Activity Schedule";
                    td_0.Visible = false; td_lbl1.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
                    lbnum.Text = "Design Volume (l/s)";
                    lblduty8.Text = "OBTAINED PERCENTAGE %";
                    lblppon.Text = "PLANT START UP COMPLETE";
                    tradd1.Visible = true;
                    tradd2.Visible = true;
                    _8pft.Visible = true;
                    lblpft.Visible = true;
                }
                else
                {
                    if (lblprj.Text == "11784" && lblsch.Text == "31")
                    {
                        lblhead.Text = "CAS M1 Mechanical Services Commissioning Activity Schedule - Marketing Suite";
                    }
                    else
                    lblhead.Text = "CAS M1 Mechanical Services Commissioning Activity Schedule";
                    td_0.Visible = false; td_lbnum.Visible = false; td_lbl1.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
                }


            }
            else if (lblsch.Text == "17" || lblsch.Text == "24" || lblsch.Text == "30" || (lblsch.Text == "25" && lblprj.Text != "SRH") || lblsch.Text == "26" || (lblsch.Text == "41" && lblprj.Text == "123") || (lblprj.Text == "11784" && (lblsch.Text == "38" || lblsch.Text == "45")) || (lblprj.Text == "MOE" && lblsch.Text == "32"))
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                if (lblsch.Text == "17" || (lblprj.Text == "11784" && lblsch.Text == "38"))
                {
                    if (lblprj.Text == "11784" && lblsch.Text == "38")
                    {
                        lblhead.Text = "CAS PH1 Public Health Services Commissioning Activity Schedule - Marketing Suite";
                    }
                    else if(lblprj.Text == "11784" && (string)Session["sch"] == "45")
                    {
                        lblhead.Text = "CAS PH1 Public Health Services Commissioning Activity Schedule - Marketing Suite";
                    }
                    else
                        lblhead.Text = "CAS PH1 Public Health Services Commissioning Activity Schedule";
                    td_lbl2.Visible = false; td_2.Visible = false; td_0.Visible = false; td_lbnum.Visible = false;
                    td_3.Visible = false; td_lbl1.Visible = false;  
                }
                else if (lblsch.Text == "24" || (lblsch.Text == "41" && lblprj.Text == "123") || (lblprj.Text == "11784" && lblsch.Text == "45") || (lblprj.Text == "MOE" && lblsch.Text == "32"))
                {
                    if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                    {
                        lblhead.Text = "CAS MISC3 - Kitchen Equipments Commissioning Activity Schedule";
                        td_lbnum.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
                    }
                    else if (lblprj.Text == "11736")
                    {
                        lblhead.Text = "CAS - Sump Pits Commissioning Activity Schedule";
                        td_lbnum.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
                    }
                    else
                    {
                        if (lblprj.Text == "11784" && lblsch.Text == "45")
                        {
                            lblhead.Text = "CAS MISC2 - Kitchen & Laundry Equipments Commissioning Activity Schedule - Marketing Suite";
                        }
                        else
                        lblhead.Text = "CAS MISC2 - Kitchen & Laundry Equipments Commissioning Activity Schedule";
                        td_lbnum.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
                    }

                }
                else if (lblsch.Text == "30")
                {
                    lblhead.Text = "CAS M1 Ducted Fan System Commissioning Activity Schedule";
                    td_lbl2.Visible = false; td_2.Visible = false;
                }
                else if (lblsch.Text == "25")
                {
                    if (lblprj.Text == "OPH")
                    {
                        lblhead.Text = "CAS E7 Integrated System Testing Commissioning Activity Schedule";
                        td_0.Visible = false; td_lbnum.Visible = false; td_txtdescr.Visible = false; td_lbldes.Visible = false; td_lbl3.Visible = false; td_1.Visible = false;

                    }
                    else
                    {
                        lblhead.Text = "CAS M2 Air Conditioned System Commissioning Activity Schedule";

                    }
                    td_lbnum.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
                }
                else if (lblsch.Text == "26")
                {
                    if (lblprj.Text == "OPH")
                    {
                        lblhead.Text = "CAS ELV7 - Leak Detection System Commissioning Activity Schedule";
                        lbnum.Text = "NO OF POINTS/ DETECTION";
                        lbl3.Text = "CONNECTED FROM";
                        td_txtdescr.Visible = false; td_lbldes.Visible = false;
                    }
                    else
                    {
                        lblhead.Text = "CAS M5 Chilled & Condenser Systems Commissioning Activity Schedule";
                        td_lbnum.Visible = false; td_3.Visible = false;
                    }
                    td_lbl2.Visible = false; td_2.Visible = false;
                }
                td_0.Visible = false; td_lbl1.Visible = false;
            }
            else if (lblsch.Text == "27" && lblprj.Text != "12761")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                if (lblprj.Text == "OPH")
                {
                    lblhead.Text = "CAS ELV8 PAVA System Commissioning Activity Schedule";
                    td_lbl1.Visible = false;td_0.Visible = false;
                    td_0.Visible = false;
                    td_txtdescr.Visible = false; td_lbldes.Visible = false;
                    lbloc.Text = "AREA COVERED";
                    td_lbnum.Visible = false;td_3.Visible = false;
                }
                else
                {
                    lblhead.Text = "CAS M6 Fire Fighting Pumps Commissioning Activity Schedule";
                }
                td_0.Visible = false; td_lbnum.Visible = false; td_lbl1.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
            }
            else if (lblsch.Text == "9" || (lblprj.Text == "11784" && lblsch.Text == "32"))
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "";
                drfed.Style.Add("display", "none");
                if (lblprj.Text == "11784" && (string)Session["sch"] == "32")
                {
                    lblhead.Text = "CAS M3 Fusible Link Fire Dampers & MSFD Commissioning Activity Schedule - Marketing Suite";
                }
                else
                lblhead.Text = "CAS M3 Fusible Link Fire Dampers & MSFD Commissioning Activity Schedule";
                td_0.Visible = false; td_lbnum.Visible = false; td_lbl1.Visible = false; td_3.Visible = false; td_lbl3.Visible = false; td_1.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
            }
            else if (lblsch.Text == "10" || (lblsch.Text == "31" && lblprj.Text != "MOE") || (lblprj.Text == "11784" && lblsch.Text == "33"))
            {
                lbl1.Text = "";
                lbl2.Text = "NO.OF DEVICES";
                lbl3.Text = "";
                lbnum.Text = "NO.OF INTERFACES";
                drfed.Style.Add("display", "none");
                if (lblsch.Text == "31")
                {
                    lblhead.Text = "CAS ELV1 PABGM Commissioning Activity Schedule";
                    td_lbl3.Visible = false; td_1.Visible = false; td_lbl1.Visible = false; td_0.Visible = false; td_lbl3.Visible = false; td_1.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
                }
                else if (lblsch.Text == "10" && (lblprj.Text == "HMIM" || lblprj.Text == "14211" || lblprj.Text == "HMHS"))
                {

                    lbl3.Text = "FED FROM";
                    if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                        lblhead.Text = "6.2.1 -Fire Alarm and Fire Telephone Communication System Commissioning Activity Schedule";
                    else
                        lblhead.Text = "CAS ELV1 - Fire Alarm & Voice Evacuation Commissioning Activity Schedule";
                    lbl1.Text = "LOOP CIRCUIT NO.";
                    drfed.Style.Add("display", "block");
                    td_txtdescr.Visible = false; td_lbldes.Visible = false; td_lbl1.Visible = false;
                    td_0.Visible = false;td_3.Visible = true;

                }
                else
                {
                    if  (lblprj.Text == "11784" && (string)Session["sch"] == "33")
                {
                    lblhead.Text = "CAS ELV1 Fire Alarm & Voice Evacuation Commissioning Activity Schedule - Marketing Suite";
                }
                else
                    lblhead.Text = "CAS ELV1 Fire Alarm & Voice Evacuation Commissioning Activity Schedule";
                    if (lblprj.Text != "BCC1")
                    {
                        cal_bat.Enabled = false;
                        cal_cet.Enabled = false;
                        cal_ghet.Enabled = false;
                    }
                    td_lbl3.Visible = false; td_1.Visible = false; td_lbl1.Visible = false; td_0.Visible = false; td_lbl3.Visible = false; td_1.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
                }
         
            }
            else if (lblsch.Text == "11" || (lblprj.Text == "11784" && lblsch.Text == "34"))
            {

                lbloc.Text = "AREA SERVED";
                lbl2.Text = "NO.OF CIRCUITS";
                lbnum.Text = "NO.OF LIGHTING SCENES";
                drfed.Style.Add("display", "none");
                if (lblprj.Text == "11784" && lblsch.Text == "34")
                {
                    lblhead.Text = "CAS ELV5 Lighting Control System Commissioning Activity Schedule - Marketing Suite";
                }
                else
                lblhead.Text = "CAS ELV5 Lighting Control System Commissioning Activity Schedule";

                td_lbldes.Visible = false; td_txtdescr.Visible = false; td_0.Visible = false; td_lbl1.Visible = false;

                if (lblprj.Text == "14211")
                {
                    lbl3.Text = "FED FROM";
                    lbl1.Text = "";
                    drfed.Style.Add("display", "block");
                    td_3.Visible = true;
                }
                else
                {
                    td_lbl3.Visible = false;
                    td_1.Visible = false;
                   
                }

            }
            else if (lblsch.Text == "12" || (lblprj.Text == "11784" && lblsch.Text == "35"))
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "CONNECTED FROM";
                lbnum.Text = "NO.OF POINTS";
                if (lblprj.Text == "ASAO")
                    lblhead.Text = "CAS ELV6 Passive Data Network Commissioning Activity Schedule";
                else if (lblprj.Text == "11784" && lblsch.Text == "35")
                    lblhead.Text = "CAS ELV6 Structured Cabling Network Commissioning Activity Schedule - Marketing Suite";
                else
                    lblhead.Text = "CAS ELV6 Structured Cabling Network Commissioning Activity Schedule";

                td_lbldes.Visible = false; td_txtdescr.Visible = false;
                td_lbl2.Visible = false;td_2.Visible = false;

                if (lblprj.Text == "14211")
                {

                    lbl1.Text = "FED_FROM";
                    lbl3.Text = "CONNECTED TO";
                    lblhead.Text = "CAS ELV7 - Information & Communication Technology (ICT) Commissioning Activity Schedule";

                }
                else
                {
                    td_lbl1.Visible = false; td_0.Visible = false; 

                }


            }
            else if (lblsch.Text == "13" ||(lblprj.Text == "11784" && lblsch.Text == "36"))
            {
                lbloc.Text = "SYSTEMS MONITORED";
                lbnum.Text = "NO.OF CAMERAS";
              
               if (lblprj.Text == "11784" && lblsch.Text == "36")
                {
                    lblhead.Text = "CAS ELV3 Closed Circuit Television Commissioning Activity Schedule - Marketing Suite";
                }
                else
                lblhead.Text = "CAS ELV3 Closed Circuit Television Commissioning Activity Schedule";
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
                
                td_lbl1.Visible = false;
                td_0.Visible = false;
                td_lbl2.Visible = false;
                td_2.Visible = false;


                //td_lbldes.Visible = false; td_txtdescr.Visible = false; td_0.Visible = false; td_lbl1.Visible = false;

                if (lblprj.Text == "14211")
                {
                     lbl3.Text = "FED FROM";
                    lbl1.Text = "";
                    lblhead.Text = "CAS ELV3 - Visual Security Systems Commissioning Activity Schedule";
                }
                else
                {
                    drfed.Style.Add("display", "none");
                    td_lbl3.Visible = false;
                    td_1.Visible = false;
                }


            }
            else if (lblsch.Text == "14" || (lblprj.Text == "11784" && lblsch.Text == "37"))
            {
                lbnum.Text = "NO.OF PANELS";
                drfed.Style.Add("display", "none");
                drloc.Style.Add("display", "none");
                if  (lblprj.Text == "11784" && (string)Session["sch"] == "37")
                {
                     lblhead.Text = "CAS ELV8 Audio-Visual Intercom Commissioning Activity Schedule - Marketing Suite";
                }
                else
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
            else if (lblsch.Text == "15")
            {
                if (lblprj.Text == "OPH")
                {
                    lblhead.Text = "CAS ELV1a VESDA System Commissioning Activity Schedule";
                    td_lbl1.Visible = false; td_0.Visible = false;
                    lbl2.Text = "NO.OF DEVICES";
                    lbnum.Text = "NO.OF INTERFACES";
                    td_lbl1.Visible = false;
                    td_0.Visible = false;
                    td_lbl3.Visible = false;
                    td_1.Visible = false;
                }
                else
                {
                    lbnum.Text = "NO.OF PANELS";
                    drfed.Style.Add("display", "none");
                    drloc.Style.Add("display", "none");
                    lblhead.Text = "CAS ELV7 Guest Room Management System Commissioning Activity Schedule";
                    td_lbl3.Visible = false;
                    td_1.Visible = false;
                    td_lbl1.Visible = false;
                    td_0.Visible = false;
                    td_lbl2.Visible = false;
                    td_2.Visible = false;
                    td_lbl0.Visible = false;
                    td0.Visible = false;
                }
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "16")
            {
                lbl1.Text = "SYS.CONTROLLED/ MONITORED";
                lbl2.Text = "NO.OF POINTS";
                lbl3.Text = "FED FROM";
                lbnum.Text = "NO.OF DEVICES REQ'D CALIBRATION";
                lblhead.Text = "CAS ELV - Commissioning Activity Schedule";
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "18" || lblsch.Text == "29" || (lblprj.Text == "11784" && lblsch.Text == "39"))
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "";
                lbnum.Text = "QUANTITY";
                drfed.Style.Add("display", "none");
                if (lblsch.Text == "18")
                    lblhead.Text = "CAS PH2 Fire Protection Services  Commissioning Activity Schedule";
                else if (lblprj.Text == "11784" && lblsch.Text == "39")
                    lblhead.Text = "CAS PH2 Fire Protection Services  Commissioning Activity Schedule - Marketing Suite";
                else
                    lblhead.Text = "CAS M8 Fire Protection Services  Commissioning Activity Schedule";
                td_0.Visible = false; td_lbl1.Visible = false; td_lbl3.Visible = false; td_1.Visible = false; td0.Visible = false; td_lbl0.Visible = false; td_lbl2.Visible = false; td_2.Visible = false;
            }
            else if (lblsch.Text == "19" || lblsch.Text == "28" || (lblprj.Text == "11784" && lblsch.Text == "40"))
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                lbnum.Text = "";
                if (lblsch.Text == "28" && (lblprj.Text == "HMIM" || lblprj.Text=="HMHS"))
                {

                    lbl2.Text = "NO.OF DEVICES";
                    //lbl3.Text = "";
                    lbnum.Text = "NO.OF INTERFACES";
                    //drfed.Style.Add("display", "none");
                    lblhead.Text = "CAS ELV10 Public Address System Commissioning Activity Schedule";
                    td_lbl1.Visible = false; 
                    //td_txtppt.Visible = false;
                    td_0.Visible = false;
                    //td_txtnum.Visible = true;
                    td_3.Visible = true;

                    td_txtdescr.Visible = false;
                    //tddes.Visible = false;
                    td_lbldes.Visible = false;


                }
                else
                {
                    if (lblsch.Text == "19")
                        lblhead.Text = "CAS PH3 Fire Extinguishing Systems Commissioning Activity Schedule";
                    else  if(lblprj.Text == "11784" && (string)Session["sch"] == "40")
                    {
                        lblhead.Text = "CAS PH3 Fire Extinguishing Systems Commissioning Activity Schedule - Marketing Suite";
                    }
                    else
                        lblhead.Text = "CAS M7 Fire Extinguishing Systems Commissioning Activity Schedule";
                    td_0.Visible = false; td_lbl1.Visible = false; td_lbl2.Visible = false; td_2.Visible = false; td_3.Visible = false; td_lbnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
                }
            }
            else if (lblsch.Text == "20" || lblsch.Text == "32" || (lblprj.Text == "11784" && lblsch.Text == "41"))
            {
                lbl1.Text = "NO.OF POINTS";
                lbl2.Text = "NO.OF DEVICES REQUIRED CALIBRATION";
                lbl3.Text = "SYSTEM CONTROLLED/ MONITORED BY DDC";
                lbnum.Text = "NO.OF SYSTEM REQUIRED LOOP TUNING";
                drfed.Style.Add("display", "none");
                if (lblsch.Text == "32")
                    lblhead.Text = "CAS ELV2 SCADA Commissioning Activity Schedule";
                else
                {
                    if (lblprj.Text == "11784" && (string)Session["sch"] == "41")
                    {
                        lblhead.Text = "CAS ELV2 Building Management System Commissioning Activity Schedule - Marketing Suite ";
                    }
                    else
                        lblhead.Text = "CAS ELV2 Building Management System Commissioning Activity Schedule";
                }
                td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "21" || (lblprj.Text == "11784" && (string)Session["sch"] == "42"))
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "";
                lbnum.Text = "FLUSHING STAGE";
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                    lblhead.Text = "CAS M4 Flushing Commissioning Activity Schedule";
                  else if (lblprj.Text == "11784" || lblsch.Text == "42")
                    lblhead.Text = "CAS M2 Flushing Commissioning Activity Schedule  - Marketing Suite";
                else
                    lblhead.Text = "CAS M2 Flushing Commissioning Activity Schedule";
                td_0.Visible = false; td_lbl1.Visible = false; td_lbl3.Visible = false; td_1.Visible = false; td_2.Visible = false; td_lbl2.Visible = false;
            }
            else if (lblsch.Text == "22" || (lblprj.Text == "11784" && lblsch.Text == "43") || (lblprj.Text == "SRH" && (string)Session["sch"] == "25"))
            {
                lbloc.Text = "SYSTEMS MONITORED";
                lbnum.Text = "NO.OF ACCESS CONTROLLED DOORS";
                drfed.Style.Add("display", "none");

                if (lblprj.Text == "11784" && lblsch.Text == "43")
                {
                    lblhead.Text = "CAS ELV4 Access Control System Commissioning Activity Schedule - Marketing Suite ";
                }
                else
                lblhead.Text = "CAS ELV4 Access Control System Commissioning Activity Schedule";
                td_lbldes.Visible = false; td_txtdescr.Visible = false;

                td_lbl1.Visible = false;
                td_0.Visible = false;
                td_lbl2.Visible = false;
                td_2.Visible = false;


                if (lblprj.Text == "14211")
                {
                    lbl3.Text = "FED FROM";
                    drfed.Style.Add("display", "block");
                    lblhead.Text = "CAS ELV4 - Security & Access Control Systems Commissioning Activity Schedule";
                    lbloc.Text = "DOORS MONITORED / CONTROLLED";
                }
                else if (lblprj.Text == "SRH")
                {
                    lbl3.Text = "FED FROM";
                    drfed.Style.Add("display", "block");

                    if  (lblsch.Text == "25") { lblhead.Text = "CAS E7 Integrated System Testing Commissioning Activity Schedule"; }

                }
                else
                {
                    td_lbl3.Visible = false;
                    td_1.Visible = false;
                }



            }
            else if (((lblsch.Text == "34" || lblsch.Text == "35" || lblsch.Text == "36") && lblprj.Text != "11784") || lblsch.Text == "23" || (lblprj.Text == "11784" && lblsch.Text == "44") || (lblprj.Text == "MOE" && lblsch.Text == "31"))
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                lbnum.Text = "";
                if (lblsch.Text == "23" || (lblprj.Text == "11784" && lblsch.Text == "44") || (lblprj.Text == "MOE" && lblsch.Text == "31"))
                {
                    if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                        lblhead.Text = "CAS MISC2 Conveying Systems Commissioning Activity Schedule";
                    else if (lblprj.Text == "11784" )
                    {
                       if (lblsch.Text == "44")
                       lblhead.Text = "CAS MISC1  Lift & Conveying Systems Commissioning Activity Schedule - Marketing Suit";                       
                       else
                           lblhead.Text = "CAS MISC1  Lift & Conveying Systems Commissioning Activity Schedule";
                    }
                    else if (lblsch.Text == "31")
                        lblhead.Text = "CAS MISC1 - Horizontal & Vertical Transportation Systems Commissioning Activity Schedule";
                }
                else if (lblsch.Text == "34")
                    lblhead.Text = "CAS MISC4 Power Failure Scenarios Commissioning Activity Schedule";
                else if (lblsch.Text == "35")
                    lblhead.Text = "CAS MISC5 Vibration & Sound Level Commissioning Activity Schedule";
                else if (lblsch.Text == "36")
                    lblhead.Text = "CAS MISC6 EOT Crane Commissioning Activity Schedule";
               
                td_0.Visible = false; td_lbl1.Visible = false; td_lbl2.Visible = false; td_2.Visible = false; td_3.Visible = false; td_lbnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "27" && lblprj.Text == "12761")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                lbnum.Text = "";
                lblhead.Text = "CAS Conveying Systems Commissioning Activity Schedule";
                td_0.Visible = false; td_lbl1.Visible = false; td_lbl2.Visible = false; td_2.Visible = false; td_3.Visible = false; td_lbnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
            }
            else if (lblsch.Text == "37" && lblprj.Text != "11784")
            {
                lbl1.Text = "PROVIDES POWER TO";
                lbl3.Text = "FED FROM";
                td_2.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_lbnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false;
                lblhead.Text = "CAS Electrical Services Commissioning Activity Schedule (Battery Charger)";
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
            if (lblprj.Text == "HMIM" || lblprj.Text == "14211" || lblprj.Text == "HMHS")
                _objcas.sys = Convert.ToInt32(lbldiv.Text);
            else
                _objcas.sys = 0;
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
            if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
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
                    var _result = _dtMaster.Select("b_z ='PSEC' OR b_z='PMWT' OR b_z='PSWB' OR b_z='PSGC' OR b_z='Energy Centre' OR b_z='PSGS' OR b_z='PPTB'");
                    _dtresult = _result.Any() ? _result.CopyToDataTable() : _dtMaster.Clone();
                }
                else if (lbldiv.Text == "4")
                    _dtresult = null;

            }
            else
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
            if (lblsch.Text == "1" || lblsch.Text == "5" || (lblprj.Text == "11784" && lblsch.Text == "28")) { btnDummy_ModalPopupExtender4.Show(); _5lbl.Text = _title; }
            else if (lblsch.Text == "2" || (lblprj.Text == "11784" && lblsch.Text == "25"))
            {                
                if (lblprj.Text == "HMIM")
                {
                    ModalPopupExtender_MVTestDataInput.Show();
                    lblHeader1.Text = _title;
                    lblNoOfCables.Text = _srow.Cells[12].Text;
                }
                else
                {
                    if (lblprj.Text == "ASAO" && (string)Session["cat"] == "MRMU")
                    {
                        _2tor.Text = "N/A";
                        _2vt.Text = "N/A";
                        chk_2tor.Checked = true;
                        chk_2vt.Checked = true;
                    }
                    else if (lblprj.Text == "ASAO1" && (string)Session["cat"] == "MRMU")
                    {
                        _2tor.Text = "N/A";
                        _2vt.Text = "N/A";
                        chk_2tor.Checked = true;
                        chk_2vt.Checked = true;
                    }
                    btnDummy_ModalPopupExtender1.Show(); 
                    _2lbl.Text = _title;
                }
            }
            else if (lblsch.Text == "3" || (lblprj.Text == "11784" && lblsch.Text == "26"))
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    btnDummy_ModalPopupExtender2_1.Show();
                    _3lbl_1.Text = _title;
                }
                else
                {
                    btnDummy_ModalPopupExtender2.Show();
                    _3lbl.Text = _title;
                    //if ((string)Session["cat"] == "MTX22")
                    //{
                    //    _3ir.Text = "N/A";
                    //    chk_3ir.Checked = true;
                    //    _3rt.Text = "N/A";
                    //    chk_3rt.Checked = true;
                    //    _3vg.Text = "N/A";
                    //    chk_3vg.Checked = true;
                    //    _3wr.Text = "N/A";
                    //    chk_3wr.Checked = true;
                    //    _3trf.Text = "N/A";
                    //    chk_3trf.Checked = true;
                    //}

                }
            }
            else if (lblsch.Text == "6" || (lblprj.Text == "11784" && lblsch.Text == "29"))
            {
                _6lbl.Text = _title;
                if ((string)Session["cat"] == "LP")
                {
                    chk_6ep.Checked = true; chk_6accept1.Checked = true; chk_6filed1.Checked = true; chk_6be.Checked = true; chk_6accept2.Checked = true; chk_6filed2.Checked = true;
                    _6lp.Enabled = true; _6accept3.Enabled = true; _6filed3.Enabled = true; _6br.Enabled = true; _6accept4.Enabled = true; _6filed4.Enabled = true;
                    _6ep.Text = "N/A"; _6accept1.Text = "N/A"; _6filed1.Text = "N/A"; _6be.Text = "N/A"; _6accept2.Text = "N/A"; _6filed2.Text = "N/A";
                    _6ep.Enabled = false; _6accept1.Enabled = false; _6filed1.Enabled = false; _6be.Enabled = false; _6accept2.Enabled = false; _6filed2.Enabled = false;
                }
                else
                {
                    chk_6lp.Checked = true; chk_6accept3.Checked = true; chk_6filed3.Checked = true; chk_6br.Checked = true; chk_6accept4.Checked = true; chk_6filed4.Checked = true;
                    _6ep.Enabled = true; _6accept1.Enabled = true; _6filed1.Enabled = true; _6be.Enabled = true; _6accept2.Enabled = true; _6filed2.Enabled = true;
                    _6lp.Text = "N/A"; _6accept3.Text = "N/A"; _6filed3.Text = "N/A"; _6br.Text = "N/A"; _6accept4.Text = "N/A"; _6filed4.Text = "N/A";
                    _6lp.Enabled = false; _6accept3.Enabled = false; _6filed3.Enabled = false; _6br.Enabled = false; _6accept4.Enabled = false; _6filed4.Enabled = false;
                }

                btnDummy_ModalPopupExtender3.Show();
            }
            else if (lblsch.Text == "4" || (lblprj.Text == "11784" && lblsch.Text == "27")) { btnDummy_ModalPopupExtender5.Show(); _4lbl.Text = _title; }
            else if (lblsch.Text == "7" || (lblprj.Text == "11784" && lblsch.Text == "30")) { btnDummy_ModalPopupExtender6.Show(); _7lbl.Text = _title; }
            else if (lblsch.Text == "8" || (lblprj.Text == "11784" && lblsch.Text == "31")) { btnDummy_ModalPopupExtender7.Show(); _8lbl.Text = _title; }
            else if (lblsch.Text == "21" || (lblprj.Text == "11784" && (string)Session["sch"] == "42")) { btnDummy_ModalPopupExtender8.Show(); _21lbl.Text = _title; }
            else if (lblsch.Text == "9" || (lblprj.Text == "11784" && lblsch.Text == "32"))
            {
                if (lblprj.Text != "ASAO")
                {
                    lblicom.Visible = false;
                    _9icom.Visible = false;
                }

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
            else if (lblsch.Text == "17" || (lblprj.Text == "11784" && lblsch.Text == "38")) { btnDummy_ModalPopupExtender10.Show(); _17lbl.Text = _title; }
            else if (lblsch.Text == "18" || (lblprj.Text == "11784" && lblsch.Text == "39")) { btnDummy_ModalPopupExtender11.Show(); _18lbl.Text = _title; }
            else if (lblsch.Text == "19" ||(lblprj.Text == "11784" && lblsch.Text == "40")) { btnDummy_ModalPopupExtender12.Show(); _19lbl.Text = _title; }
            else if (lblsch.Text == "10" || (lblprj.Text == "11784" && lblsch.Text == "33")) { btnDummy_ModalPopupExtender13.Show(); _10lbl.Text = _title; }
            else if (lblsch.Text == "20" || (lblprj.Text == "11784" && lblsch.Text == "41")) { btnDummy_ModalPopupExtender14.Show(); _20lbl.Text = _title; }
            else if (lblsch.Text == "13" || (lblprj.Text == "11784" && lblsch.Text == "36")) { btnDummy_ModalPopupExtender15.Show(); _13lbl.Text = _title; }
            else if (lblsch.Text == "22" || (lblprj.Text == "11784" && lblsch.Text == "43")) { btnDummy_ModalPopupExtender16.Show(); _22lbl.Text = _title; }
            else if (lblsch.Text == "11" || (lblprj.Text == "11784" && lblsch.Text == "34")) { btnDummy_ModalPopupExtender17.Show(); _11lbl.Text = _title; }
            else if (lblsch.Text == "12" || (lblprj.Text == "11784" && lblsch.Text == "35")) { btnDummy_ModalPopupExtender18.Show(); _12lbl.Text = _title; }
            else if (lblsch.Text == "15") {
                if (lblprj.Text == "OPH")
                {
                    btnDummy_ModalPopupExtender15a.Show(); _15albl.Text = _title;
                }
                else
                {

                    btnDummy_ModalPopupExtender19.Show(); _15lbl.Text = _title;
                }
            }
            else if (lblsch.Text == "14" || (lblprj.Text == "11784" && lblsch.Text == "37")) { btnDummy_ModalPopupExtender20.Show(); _14lbl.Text = _title; }
            else if (lblsch.Text == "23" || (lblprj.Text == "11784" && lblsch.Text == "44") || (lblprj.Text == "MOE" && lblsch.Text == "31"))
            {
                if ((string)Session["cat"] == "LIFT")
                {
                    if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                    {
                        _23tpi.Text = "N/A"; _23tpi.Enabled = false; _23lms.Text = "N/A";
                        _23eml.Enabled = true; _23lms.Enabled = false; _23int.Enabled = true; _23tc.Enabled = true; _23bfa.Enabled = true; _23pfm.Enabled = true;
                    }
                    else
                    {
                        _23eml.Enabled = true; _23lms.Enabled = true; _23int.Enabled = true;
                    }
                }
                else if ((string)Session["cat"] == "ESC")
                {
                    if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                    {
                        _23pfm.Text = "N/A"; _23tpi.Text = "N/A"; _23tpi.Enabled = false; _23pfm.Enabled = false; _23eml.Text = "N/A"; _23lms.Text = "N/A"; _23int.Text = "N/A";
                        _23eml.Enabled = false; _23lms.Enabled = false; _23int.Enabled = false; _23tc.Enabled = true; _23bfa.Enabled = true;
                    }
                    else
                    {
                        _23eml.Text = "N/A"; _23lms.Text = "N/A"; _23int.Text = "N/A";
                        //_23eml.Enabled = false; _23lms.Enabled = false; _23int.Enabled = false;
                    }
                }
                else if ((string)Session["cat"] == "BMU")
                {
                    if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                    {
                        _23tpi.Enabled = true; _23pfm.Enabled = false;
                        _23eml.Text = "N/A"; _23lms.Text = "N/A"; _23int.Text = "N/A"; _23bfa.Text = "N/A"; _23pfm.Text = "N/A";
                        _23eml.Enabled = false; _23lms.Enabled = false; _23int.Enabled = false; _23bfa.Enabled = false;
                    }
                    else
                    {
                        _23tpi.Enabled = true; _23pfm.Enabled = true;
                        _23eml.Text = "N/A"; _23lms.Text = "N/A"; _23int.Text = "N/A"; _23bfa.Text = "N/A";
                        _23eml.Enabled = false; _23lms.Enabled = false; _23int.Enabled = false; _23bfa.Enabled = false;
                    }
                }
                btnDummy_ModalPopupExtender21.Show();
                _23lbl.Text = _title;
            }
            else if (lblsch.Text == "27" && lblprj.Text == "12761")
            {
                if ((string)Session["cat"] == "LIFT")
                {
                    _23eml.Enabled = true; _23lms.Enabled = true; _23int.Enabled = true;
                }
                else if ((string)Session["cat"] == "ESC")
                {

                    _23eml.Text = "N/A"; _23lms.Text = "N/A"; _23int.Text = "N/A";
                    //_23eml.Enabled = false; _23lms.Enabled = false; _23int.Enabled = false;
                }
                btnDummy_ModalPopupExtender21.Show();
                _23lbl.Text = _title;
            }
            else if (lblsch.Text == "16") { btnDummy_ModalPopupExtender22.Show(); _16lbl.Text = _title; }
            else if (lblsch.Text == "24" || (lblsch.Text == "41" && lblprj.Text == "123") || (lblprj.Text == "11784" && lblsch.Text == "45") || (lblprj.Text == "MOE" && lblsch.Text == "32")) 
            {
                btnDummy_ModalPopupExtender23.Show(); _24lbl.Text = _title; 
            }
            else if (lblsch.Text == "30") { btnDummy_ModalPopupExtender24.Show(); _30lbl.Text = _title; }
            else if (lblsch.Text == "25")
            {
                if (lblprj.Text == "OPH")
                    btnDummy_ModalPopupExtender25a.Show();
                else if (lblprj.Text == "SRH") 
                {
                    ModalPopupExtender_25SRH.Show();
                    _25slbl.Text = _title;
                }
                else
                    btnDummy_ModalPopupExtender25.Show();

                _25albl.Text = _title;
                _25lbl.Text = _title; lbl_25duty.Visible = false; _26duty.Visible = false;



            }
            else if (lblsch.Text == "26")
            {
                if (lblprj.Text == "OPH")
                {
                    btnDummy_ModalPopupExtender26a.Show();
                    _26lbl.Text = _title;
                }
                else
                {
                    btnDummy_ModalPopupExtender25.Show();
                }
                _25lbl.Text = _title; lbl_25duty.Visible = true; _26duty.Visible = true;
            }
            else if (lblsch.Text == "27" && lblprj.Text != "12761") { btnDummy_ModalPopupExtender25.Show(); _25lbl.Text = _title; lbl_25duty.Visible = true; _26duty.Visible = true; }
            else if (lblsch.Text == "27" && lblprj.Text == "OPH")
            {
                btnDummy_ModalPopupExtender27a.Show();
                _27lbl.Text = _title;
            }
            else if (lblsch.Text == "28") 
            {
                if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                {
                    btnDummy_ModalPopupExtender13.Show(); _10lbl.Text = _title;
                }
                else
                {
                    btnDummy_ModalPopupExtender26.Show(); _28lbl.Text = _title;
                }
            }
            else if (lblsch.Text == "29") { btnDummy_ModalPopupExtender11.Show(); _18lbl.Text = _title; }
            else if (lblsch.Text == "34" && lblprj.Text!="11784") { btnDummy_ModalPopupExtender27.Show(); _34lbl.Text = _title; }
            else if (lblsch.Text == "35" && lblprj.Text != "11784") { btnDummy_ModalPopupExtender28.Show(); _35lbl.Text = _title; }
            else if (lblsch.Text == "36") { btnDummy_ModalPopupExtender29.Show(); _36lbl.Text = _title; }
            else if (lblsch.Text == "32" && lblprj.Text != "MOE") { btnDummy_ModalPopupExtender14.Show(); _20lbl.Text = _title; }
            else if (lblsch.Text == "31" && lblprj.Text != "MOE") { btnDummy_ModalPopupExtender13.Show(); _10lbl.Text = _title; }
            else if (lblsch.Text == "37" && lblprj.Text != "11784") { btnDummy_ModalPopupExtender30.Show(); _37lbl.Text = _title; }

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
                e.Row.Cells[6].Text = SeqNo(e.Row.Cells[6].Text);

            }
            if (lblsch.Text == "1" || lblsch.Text == "5" || (lblprj.Text == "11784" && lblsch.Text == "28"))
            {
                e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "4" || (lblsch.Text == "37"  && lblprj.Text != "11784" )|| (lblprj.Text == "11784" && lblsch.Text == "27"))
            {
                e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "2" || lblsch.Text == "3" || (lblprj.Text == "11784" && (lblsch.Text == "25" || lblsch.Text == "26")))
            {
                e.Row.Cells[7].Visible = false;
                if (lblprj.Text != "HMIM")
                {
                    e.Row.Cells[12].Visible = false; 
                }
            }
            else if (lblsch.Text == "6" || (lblprj.Text == "11784" && lblsch.Text == "29"))
            {
                e.Row.Cells[9].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "7" || (lblprj.Text == "11784" && lblsch.Text == "30"))
            {
                if (lblprj.Text != "CCAD")
                {
                    if (lblprj.Text != "ASAO")
                        e.Row.Cells[11].Visible = false;
                    e.Row.Cells[10].Visible = false; e.Row.Cells[9].Visible = false;
                }
                e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "8" || (lblprj.Text == "11784" && lblsch.Text == "31"))
            {
                if (lblprj.Text == "CCAD")
                { e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false; }
                else
                {
                    e.Row.Cells[10].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[11].Visible = false;
                }
            }
            else if (lblsch.Text == "17" || lblsch.Text == "24" || lblsch.Text == "30" || (lblsch.Text == "25" && lblprj.Text != "SRH")|| lblsch.Text == "26" || lblsch.Text == "27" || (lblsch.Text == "41" && lblprj.Text == "123") || (lblprj.Text == "11784" && (lblsch.Text == "38" || lblsch.Text == "45")) || (lblprj.Text == "MOE" && lblsch.Text == "32"))
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[11].Visible = false;
                if (lblsch.Text == "27" && lblprj.Text == "12761")
                    e.Row.Cells[7].Visible = false;
                else if (lblprj.Text == "OPH" && lblsch.Text == "25")
                {
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[9].Visible = false;
                }
                else if (lblprj.Text == "OPH" && lblsch.Text == "26")
                {
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[10].Visible = true;
                }
                else if (lblprj.Text == "OPH" && lblsch.Text == "27")
                { e.Row.Cells[7].Visible = false; }
            }
            else if (lblsch.Text == "9" || (lblprj.Text == "11784" && lblsch.Text == "32"))
            {
                e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false;
            }
            else if (lblsch.Text == "18" || lblsch.Text == "29" || (lblprj.Text == "11784" && lblsch.Text == "39"))
            {
                e.Row.Cells[8].Visible = false; e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if (((lblsch.Text == "28" || lblsch.Text == "34" || lblsch.Text == "35" || lblsch.Text == "36") && lblprj.Text != "11784") || lblsch.Text == "19" || lblsch.Text == "23" || (lblprj.Text == "11784" && (lblsch.Text == "40" || lblsch.Text == "44")) || (lblprj.Text == "MOE" && lblsch.Text == "31"))
            {
                if (lblsch.Text == "28" && (lblprj.Text == "HMIM" || lblprj.Text=="HMHS"))
                {
                    //e.Row.Cells[9].Visible = false;
                    e.Row.Cells[10].Visible = false; 
                    e.Row.Cells[7].Visible = false;
                }
                else
                {
                    e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
                }
            }
            else if (lblsch.Text == "21" || (lblprj.Text == "11784" && (string)Session["sch"] == "42"))
            {
                e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if (lblsch.Text == "10" || (lblsch.Text == "31" && lblprj.Text != "MOE") || (lblprj.Text == "11784" && lblsch.Text == "33"))
            {

                if (lblsch.Text == "10" && (lblprj.Text == "HMIM" || lblprj.Text == "14211" || lblprj.Text == "HMHS"))
                {
                   // e.Row.Cells[9].Visible = false;
                    e.Row.Cells[10].Visible = false;
                    e.Row.Cells[7].Visible = false;
                 }
                else
                     e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "20" || lblsch.Text == "32" || (lblprj.Text == "11784" && lblsch.Text == "41"))
            {
                e.Row.Cells[7].Visible = false;
            }
            else if (lblsch.Text == "13" || lblsch.Text == "22" ||(lblprj.Text == "11784" && (lblsch.Text == "36" || lblsch.Text=="43")) || (lblprj.Text == "SRH" && (string)Session["sch"] == "25"))
            {
                if (lblprj.Text!="14211" && lblprj.Text != "SRH") e.Row.Cells[9].Visible = false;

                 e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;


            }
            else if (lblsch.Text == "11" || (lblprj.Text == "11784" && lblsch.Text == "34"))
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false;
                if (lblprj.Text != "14211")
                     e.Row.Cells[9].Visible = false;                   

            }
            else if (lblsch.Text == "12" || (lblprj.Text == "11784" && lblsch.Text == "35"))
            {
                e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;

                if (lblprj.Text != "14211") e.Row.Cells[10].Visible = false; 
            }
            else if (lblsch.Text == "15" || lblsch.Text == "14" || (lblprj.Text == "11784" && lblsch.Text == "37"))
            {
                if (lblprj.Text == "OPH" && lblsch.Text == "15")
                {
                    e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false;
                }
                else
                {
                    e.Row.Cells[8].Visible = false; e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
                }
            }
            else if (lblsch.Text == "16")
            {
                e.Row.Cells[7].Visible = false;
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
                      where (_el1 == "All" || o.Field<string>("B_Z") == _el1) && (_el2 == "All" || o.Field<string>("Cat") == _el2) && (_el3 == "All" || o.Field<string>("F_lvl") == _el3) && (_el4 == "All" || o.Field<string>("F_from") == _el4) && (_el5 == "All" || o.Field<string>("Loc") == _el5)
                      select o;
            
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
            _objcls.compl = _9pcd.Text;//testing planned completion date
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
            if (lblprj.Text == "OPH")
            {
                _objcls.planned1 = _9pcd.Text;
                _objcls.planned2 = "";
                _objcls.planned3 = "";
                _objbll.Cassheet_update1(_objcls, _objdb);
            }
            else
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
            if (lblsch.Text == "1" || lblsch.Text == "5" || (lblprj.Text == "11784" && lblsch.Text == "28"))
            {
                if ((string)Session["cat"] == "BDT" && lblprj.Text == "BCC1")
                {
                    if (_5total.Text == "") return 0;
                    if (_5tor.Text != "")
                        count += 1;
                    if (_5ir.Text != "")
                        count += 1;
                    if (_5cr.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 3) * 100;
                }
                else if ((string)Session["cat"] == "SMDB" && lblprj.Text == "BCC1")
                {
                    if (_5total.Text == "") return 0;
                    if (_5tor.Text != "")
                        count += 1;
                    if (_5ir.Text != "")
                        count += 1;
                    if (_5fn.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 3) * 100;
                }
                else if ((string)Session["cat"] == "EMCC" && lblprj.Text == "BCC1")
                {
                    if (_5total.Text == "") return 0;
                    if (_5tor.Text != "")
                        count += 1;
                    if (_5ir.Text != "")
                        count += 1;
                    if (_5fn.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 3) * 100;
                }
                else
                {
                    //if (_5total.Text == "") return 0;
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
            }
            else if (lblsch.Text == "2" || (lblprj.Text == "11784" && lblsch.Text == "25"))
            {

                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                #region
                {
                    if ((string)Session["cat"] == "MRMU")
                    {
                        if (DateValidation(_2ir.Text) == true)
                            count += 1;
                        if (DateValidation(_2hi.Text) == true)
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
                        _percentage = (Convert.ToDecimal(count) / 8) * 100;
                    }
                    else if ((string)Session["cat"] == "PFC")
                    {
                        //if (DateValidation(_2tor.Text) == true)
                        //    count += 1;
                        if (DateValidation(_2ir.Text) == true)
                            count += 1;
                        //if (DateValidation(_2hi.Text) == true)
                        //    count += 1;
                        //if (DateValidation(_2vt.Text) == true)
                        //    count += 1;
                        if (DateValidation(_2ct.Text) == true)
                            count += 1;
                        //if (DateValidation(_2pi.Text) == true)
                        //    count += 1;
                        if (DateValidation(_2si.Text) == true)
                            count += 1;
                        if (DateValidation(_2cr.Text) == true)
                            count += 1;
                        if (DateValidation(_2fn.Text) == true)
                            count += 1;
                        //if (DateValidation(_2pr.Text) == true)
                        //    count += 1;
                        _percentage = (Convert.ToDecimal(count) / 5) * 100;
                    }
                    else
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
                }
                #endregion
                else if (lblprj.Text == "HMIM")
                {
                    {
                    int _no = 0;
                    if (txtTorqueTest.Text != "N/A")
                    {
                        _no += 1;
                        count = (DateValidation(txtTorqueTest.Text))?(count+1):count;    
                    }
                    if (txtIRTest.Text != "N/A")
                    {
                        _no += 1;
                        count = (DateValidation(txtIRTest.Text)) ? (count + 1) : count; 
                    }
                    if (txtHiPotTest.Text != "N/A")
                    {
                        _no += 1;
                        count = (DateValidation(txtHiPotTest.Text)) ? (count + 1) : count;
                    }
                    if (txtVTTest.Text != "N/A")
                    {
                        _no += 1;
                        count = (DateValidation(txtVTTest.Text)) ? (count + 1) : count;
                    }
                    if (txtCTTest.Text != "N/A")
                    {
                        _no += 1;
                        count = (DateValidation(txtCTTest.Text)) ? (count + 1) : count;
                    }
                    if (txtPrimInjTest.Text != "N/A")
                    {
                        _no += 1;
                        count = (DateValidation(txtPrimInjTest.Text)) ? (count + 1) : count;
                    }
                    if (txtSecInjTest.Text != "N/A")
                    {
                        _no += 1;
                        count = (DateValidation(txtSecInjTest.Text)) ? (count + 1) : count;
                    }
                    if (txtDuctorTest.Text != "N/A")
                    {
                        _no += 1;
                        count = (DateValidation(txtDuctorTest.Text)) ? (count + 1) : count;
                    }
                    if (txtFuncTest.Text != "N/A")
                    {
                        _no += 1;
                        count = (DateValidation(txtFuncTest.Text)) ? (count + 1) : count;
                    }
                    if (txtProtRelayTest.Text != "N/A")
                    {
                        _no += 1;
                        count = (DateValidation(txtProtRelayTest.Text)) ? (count + 1) : count;
                    }
                  
                   
                    if (_no == 0)
                        _percentage = -1;
                    else
                        _percentage = (Convert.ToDecimal(count) / _no) * 100;
                }
                }
                else
                #region
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
                #endregion
            }
            else if (lblsch.Text == "8" || (lblprj.Text == "11784" && lblsch.Text == "31"))
            {
                if (_8pc1.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "9" || (lblprj.Text == "11784" && lblsch.Text == "32"))
            {
                if (_9aa.Text != "N/A")
                {
                    chk_9aa.Checked = true;
                    if (_9aa.Text != "" && _9dtp.Text != "" && _9rp.Text != "")
                        _percentage = 1;
                }
                else if (_9moo.Text != "N/A")
                {
                    chk_9moo.Checked = true;
                    if (_9moo.Text != "" && _9sro.Text != "" && _9est.Text != "" && _9psrt.Text != "")
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "4" || (lblprj.Text == "11784" && lblsch.Text == "27"))
            {
                if (DateValidation(_4pc.Text) == true)
                    count += 1;
                if (DateValidation(_4as.Text) == true)
                    count += 1;
                if (DateValidation(_4lb.Text) == true)
                    count += 1;
                _percentage = (Convert.ToDecimal(count) / 3) * 100;
            }
            else if (lblsch.Text == "3" || (lblprj.Text == "11784" && (lblsch.Text== "26")))
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    int _no = 0;
                    if (DateValidation(_3ir_1.Text) == true)
                        count += 1;
                    if (DateValidation(_3rt_1.Text) == true)
                        count += 1;
                    if (DateValidation(_3mcbt.Text) == true)
                        count += 1;
                    if (DateValidation(_3vg_1.Text) == true)
                        count += 1;
                    if (DateValidation(_3trf_1.Text) == true)
                        count += 1;
                    if (DateValidation(_3mct.Text) == true)
                        count += 1;
                    if (_3ir_1.Text != "N/A")
                        _no += 1;
                    if (_3rt_1.Text != "N/A")
                        _no += 1;
                    if (_3mcbt.Text != "N/A")
                        _no += 1;
                    if (_3vg_1.Text != "N/A")
                        _no += 1;
                    if (_3trf_1.Text != "N/A")
                        _no += 1;
                    if (_3mct.Text != "N/A")
                        _no += 1;

                    if (_no == 0)
                        _percentage = -1;
                    else
                        _percentage = (Convert.ToDecimal(count) / _no) * 100;
                    //_percentage = (Convert.ToDecimal(count) / 6) * 100;
                }
                else
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
            }
            else if (lblsch.Text == "6" || (lblprj.Text == "11784" && lblsch.Text == "29"))
            {
                if (DateValidation(_6ep.Text) == true)
                    _percentage = 100;
                else if (_6ep.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "7" || (lblprj.Text == "11784" && lblsch.Text == "30"))
            {
                if (lblprj.Text == "ASAO")
                {
                    if (IsNumeric(_7cir.Text) == true)
                    {
                        if (IsNumeric(_7nocir.Text) == true)
                            _percentage = (Convert.ToDecimal(_7cir.Text) / Convert.ToDecimal(_7nocir.Text)) * 100;
                    }
                }
                else
                {
                    if (IsNumeric(_7cir.Text) == true)
                        _percentage = Convert.ToDecimal(_7cir.Text);
                }
            }
            else if (lblsch.Text == "17" || (lblprj.Text == "11784" && lblsch.Text == "38"))
            {
                if (_17pc1.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "18" || lblsch.Text == "29" || (lblprj.Text == "11784" && lblsch.Text == "39"))
            {
                if (IsNumeric(_18qt.Text))
                    _percentage = Convert.ToDecimal(_18qt.Text);
            }
            else if (lblsch.Text == "19" || (lblprj.Text == "11784" && lblsch.Text == "40"))
            {
                if (_19rsit.Text != "")
                    count += 1;
                if (_19sac.Text != "")
                    count += 1;
                if (_19fbit.Text != "")
                    count += 1;
                _percentage = (Convert.ToDecimal(count) / 3) * 100;

            }
            else if (lblsch.Text == "20" || (lblprj.Text == "11784" && lblsch.Text == "41"))
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    decimal _total = 0;
                    if (IsNumeric(_20cit.Text) == true)
                    {
                        _total += Convert.ToDecimal(_20cit.Text);
                        count += 1;
                    }
                    if (IsNumeric(_20ppt.Text) == true)
                    {
                        _total += Convert.ToDecimal(_20ppt.Text);
                        count += 1;
                    }
                    if (IsNumeric(_20cft.Text) == true)
                    {
                        _total += Convert.ToDecimal(_20cft.Text);
                        count += 1;
                    }
                    decimal _points = 0;
                    if (IsNumeric(_20points.Text) == true)
                        _points = Convert.ToDecimal(_20points.Text);
                    if (_points > 0)
                        _percentage = ((_total / count) / _points) * 100;
                    //if (IsNumeric(_20cit.Text) == true && IsNumeric(_20ppt.Text) == true && IsNumeric(_20cft.Text) == true)
                    //    _percentage = 1;
                }
                else
                {
                    if (IsNumeric(_20cit.Text)) _percentage = Convert.ToDecimal(_20cit.Text);

                }
            }
            else if (lblsch.Text == "32" && lblprj.Text!="MOE")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    decimal _total = 0;
                    if (IsNumeric(_20cit.Text) == true)
                    {
                        _total += Convert.ToDecimal(_20cit.Text);
                        count += 1;
                    }
                    if (IsNumeric(_20ppt.Text) == true)
                    {
                        _total += Convert.ToDecimal(_20ppt.Text);
                        count += 1;
                    }
                    if (IsNumeric(_20cft.Text) == true)
                    {
                        _total += Convert.ToDecimal(_20cft.Text);
                        count += 1;
                    }
                    decimal _points = 0;
                    if (IsNumeric(_20points.Text) == true)
                        _points = Convert.ToDecimal(_20points.Text);
                    if (_points > 0)
                        _percentage = ((_total / count) / _points) * 100;
                    //if (IsNumeric(_20cit.Text) == true && IsNumeric(_20ppt.Text) == true && IsNumeric(_20cft.Text) == true)
                    //    _percentage = 1;
                }
            }
            else if (lblsch.Text == "13" ||(lblprj.Text == "11784" && lblsch.Text == "36"))
            {
                if (IsNumeric(_13cit.Text))
                    _percentage = Convert.ToDecimal(_13cit.Text);
            }
            else if (lblsch.Text == "21" || (lblprj.Text == "11784" && (string)Session["sch"] == "42"))
            {
                if (_21pf.Text != "")
                    count += 1;
                if (_21fvr.Text != "")
                    count += 1;
                if (_21cc.Text != "")
                    count += 1;
                if (_21facc.Text != "")
                    count += 1;
                if (_21bfc.Text != "")
                    count += 1;
                if (_21fct.Text != "")
                    count += 1;
                _percentage = (Convert.ToDecimal(count) / 6) * 100;
            }
            else if (lblsch.Text == "10" || (lblprj.Text == "11784" && lblsch.Text == "33"))
            {
                if (isElvdateProject)
                {
                    if (DateValidation(_10ccit.Text) == true)_percentage = 1;
                }
                else
                {
                    if (IsNumeric(_10ccit.Text) == true)
                    {
                        ////if ((string)Session["cat"] == "FAL")
                        ////    _percentage = Convert.ToDecimal(_10ccit.Text);
                        ////else
                        ////{
                        //if (lblprj.Text == "ASAO")
                        //{
                        //    if (Convert.ToInt32(_10devices.Text) == Convert.ToInt32(_10ccit.Text))
                        //        _percentage = 1;
                        //}
                        //else
                        //{
                        if (lblprj.Text == "11736")
                        {
                            decimal _int = 0;
                            decimal _dvs = 0;
                            if (IsNumeric(_10interface.Text) == true)
                                _int = Convert.ToDecimal(_10interface.Text);
                            if (IsNumeric(_10devices.Text) == true)
                                _dvs = Convert.ToDecimal(_10devices.Text);
                            decimal _total = _int + _dvs;
                            if (Convert.ToDecimal(_10ccit.Text) <= _total)
                                _percentage = Convert.ToDecimal(_10ccit.Text);
                            else
                                _percentage = _total;
                        }
                        else
                            _percentage = Convert.ToDecimal(_10ccit.Text);
                        //}
                        //}
                    }
                }
            }
            else if (lblsch.Text == "31" && lblprj.Text != "MOE")
            {
                if (IsNumeric(_10ccit.Text) == true)
                {
                    if ((string)Session["cat"] == "VAC")
                    {
                        if (IsNumeric(_10ccit.Text)) _percentage = Convert.ToDecimal(_10ccit.Text);
                    }
                    else
                    {
                        if (Convert.ToInt32(_10devices.Text) == Convert.ToInt32(_10ccit.Text))
                            _percentage = 1;
                    }
                }
            }
            else if (lblsch.Text == "22" || (lblprj.Text == "11784" && lblsch.Text == "43"))
            {
                if (IsNumeric(_22cit.Text))
                    _percentage = Convert.ToDecimal(_22cit.Text);
            }
            else if (lblsch.Text == "11" || (lblprj.Text == "11784" && lblsch.Text == "34"))
            {
                if (IsNumeric(_11cit.Text))
                    _percentage = Convert.ToDecimal(_11cit.Text);
            }
            else if (lblsch.Text == "12" || (lblprj.Text == "11784" && lblsch.Text == "35"))
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (IsNumeric(_12ct.Text) && IsNumeric(_12nop.Text))
                    {
                        _percentage = Convert.ToDecimal(_12ct.Text) / Convert.ToDecimal(_12nop.Text) * 100;
                    }
                }
                else
                {
                    if (IsNumeric(_12ct.Text))
                        _percentage = Convert.ToDecimal(_12ct.Text);
                }
            }
            else if (lblsch.Text == "15")
            {
                if (lblprj.Text == "OPH")
                {
                    if (IsNumeric(_15acit.Text))
                        _percentage = Convert.ToDecimal(_15acit.Text);

                }
                else
                {
                    if (IsNumeric(_15cit.Text))
                        _percentage = Convert.ToDecimal(_15cit.Text);
                }
            }
            else if (lblsch.Text == "14" || (lblprj.Text == "11784" && lblsch.Text=="37" ))
            {
                if (IsNumeric(_14cit.Text))
                    _percentage = Convert.ToDecimal(_14cit.Text);
            }
            else if (lblsch.Text == "23" || (lblprj.Text == "11784" && lblsch.Text == "44") || (lblprj.Text == "MOE" && lblsch.Text == "31"))
            {
                //if (_23tc.Text != "")
                //    _percentage = 1;
                if (lblprj.Text == "ASAO")
                {
                    decimal _catc = 0;
                    if ((string)Session["cat"] == "LIFT")
                    {
                        if (DateValidation(_23tc.Text) == true)
                            _catc += 0.24m;
                        if (DateValidation(_23eml.Text) == true)
                            _catc += 0.22m;
                        if (DateValidation(_23pfm.Text) == true)
                            _catc += 0.22m;
                        if (DateValidation(_23int.Text) == true)
                            _catc += 0.22m;
                        if (DateValidation(_23bfa.Text) == true)
                            _catc += 0.1m;
                    }
                    else if ((string)Session["cat"] == "ESC")
                    {
                        if (DateValidation(_23tc.Text) == true)
                            _catc += 0.9m;
                        if (DateValidation(_23bfa.Text) == true)
                            _catc += 0.1m;
                    }
                    else if ((string)Session["cat"] == "BMU")
                    {
                        if (DateValidation(_23tc.Text) == true)
                            _catc += 0.5m;
                        if (DateValidation(_23tpi.Text) == true)
                            _catc += 0.5m;
                    }
                    _percentage = _catc * 100;
                }
                else
                {
                    if (DateValidation(_23tc.Text) == true)
                        count += 1;
                    if (DateValidation(_23tpi.Text) == true)
                        count += 1;
                    if (DateValidation(_23eml.Text) == true)
                        count += 1;
                    if (DateValidation(_23pfm.Text) == true)
                        count += 1;
                    if (DateValidation(_23lms.Text) == true)
                        count += 1;
                    if (DateValidation(_23int.Text) == true)
                        count += 1;
                    if (DateValidation(_23bfa.Text) == true)
                        count += 1;
                    int _no = 0;
                    if (_23tc.Text.ToUpper() != "N/A")
                        _no += 1;
                    if (_23tpi.Text.ToUpper() != "N/A")
                        _no += 1;
                    if (_23eml.Text.ToUpper() != "N/A")
                        _no += 1;
                    if (_23pfm.Text.ToUpper() != "N/A")
                        _no += 1;
                    if (_23lms.Text.ToUpper() != "N/A")
                        _no += 1;
                    if (_23int.Text.ToUpper() != "N/A")
                        _no += 1;
                    if (_23bfa.Text.ToUpper() != "N/A")
                        _no += 1;
                    if (_no > 0)
                        _percentage = Convert.ToDecimal(count) / _no * 100;
                    else
                        _percentage = 0;
                }
            }
            else if (lblsch.Text == "16")
            {
                if (IsNumeric(_16ir.Text))
                    _percentage = Convert.ToDecimal(_16ir.Text);
            }
            else if (lblsch.Text == "24" || (lblsch.Text == "41" && lblprj.Text == "123") || (lblprj.Text == "11784" && lblsch.Text == "45")|| (lblprj.Text == "MOE" && lblsch.Text == "32"))
            {
                if (DateValidation(_24ir.Text) == true)
                        count += 1;
                    if (DateValidation(_24ft.Text) == true)
                        count += 1;
                    if (DateValidation(_24it.Text) != true)
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 3) * 100;              
            }
            else if (lblsch.Text == "30")
            {
                if (_30pc1.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "25" || lblsch.Text == "26")
            {
                if (lblsch.Text == "25" && lblprj.Text == "OPH")
                {
                    if (DateValidation(_25apfec.Text) == true)
                        _percentage = 1;

                }
                if (lblsch.Text == "25" && lblprj.Text == "SRH")
                {
                    if (IsNumeric(_25scit.Text))
                        _percentage = Convert.ToDecimal(_25scit.Text);

                }
                else
                {
                    if (_25pc1.Text != "")
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "27" && lblprj.Text != "12761")
            {
                if (lblprj.Text == "OPH")
                {
                    if (IsNumeric(_27cit.Text)) _percentage = Convert.ToDecimal(_27cit.Text);

                }
                else
                {
                    if (_25pc1.Text != "")
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "27" && lblprj.Text == "12761")
            {
                if (DateValidation(_23tc.Text) == true)
                    count += 1;
                if (DateValidation(_23tpi.Text) == true)
                    count += 1;
                if (DateValidation(_23eml.Text) == true)
                    count += 1;
                if (DateValidation(_23pfm.Text) == true)
                    count += 1;
                if (DateValidation(_23lms.Text) == true)
                    count += 1;
                if (DateValidation(_23int.Text) == true)
                    count += 1;
                if (DateValidation(_23bfa.Text) == true)
                    count += 1;
                int _no = 0;
                if (_23tc.Text.ToUpper() != "N/A")
                    _no += 1;
                if (_23tpi.Text.ToUpper() != "N/A")
                    _no += 1;
                if (_23eml.Text.ToUpper() != "N/A")
                    _no += 1;
                if (_23pfm.Text.ToUpper() != "N/A")
                    _no += 1;
                if (_23lms.Text.ToUpper() != "N/A")
                    _no += 1;
                if (_23int.Text.ToUpper() != "N/A")
                    _no += 1;
                if (_23bfa.Text.ToUpper() != "N/A")
                    _no += 1;
                if (_no > 0)
                    _percentage = Convert.ToDecimal(count) / _no * 100;
                else
                    _percentage = 0;
            }
            else if (lblsch.Text == "28")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (DateValidation(_28prc.Text) == true)
                        _percentage = 100;

                }
                else if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                {
                    if (IsNumeric(_10ccit.Text) == true)
                    {
                        _percentage = Convert.ToDecimal(_10ccit.Text);
                    }
                }
                else
                {
                    if (_28idc.Text != "")
                        count += 1;
                    if (_28prc.Text != "")
                        count += 1;
                    if (_28sac.Text != "")
                        count += 1;
                    if (_28fit.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 4) * 100;
                }
            }
            else if (lblsch.Text == "34" && lblprj.Text != "11784")
            {
                if (_34mec.Text != "")
                    count += 1;
                if (_34ele.Text != "")
                    count += 1;
                if (_34fbs.Text != "")
                    count += 1;
                if (_34bia.Text != "")
                    count += 1;
                if (_34pft.Text != "")
                    count += 1;
                if (_34epp.Text != "")
                    count += 1;
                if (_34fct.Text != "")
                    count += 1;
                if (_34prt.Text != "")
                    count += 1;
                _percentage = (Convert.ToDecimal(count) / 8) * 100;
            }
            else if (lblsch.Text == "35" && lblprj.Text != "11784")
            {
                if (_35mec.Text != "")
                    count += 1;
                if (_35ele.Text != "")
                    count += 1;
                if (_35fbs.Text != "")
                    count += 1;
                if (_35bia.Text != "")
                    count += 1;
                if (_35nlt.Text != "")
                    count += 1;
                if (_35vit.Text != "")
                    count += 1;
                if (_35aca.Text != "")
                    count += 1;
                _percentage = (Convert.ToDecimal(count) / 7) * 100;
            }
            else if (lblsch.Text == "36")
            {
                if ((string)Session["cat"] == "EOT")
                {
                    if (DateValidation(_36coa.Text) == true)
                        count += 1;
                    if (DateValidation(_36lot.Text) == true)
                        count += 1;
                    if (DateValidation(_36sls.Text) == true)
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 3) * 100;
                }
                else
                {
                    if (_36cpc.Text != "")
                        count += 1;
                    if (_36lpc.Text != "")
                        count += 1;
                    if (_36cbr.Text != "")
                        count += 1;
                    if (_36lbr.Text != "")
                        count += 1;
                    if (_36wcl.Text != "")
                        count += 1;
                    if (_36coa.Text != "")
                        count += 1;
                    if (_36lot.Text != "")
                        count += 1;
                    if (_36sls.Text != "")
                        count += 1;
                    if (_36fle.Text != "")
                        count += 1;
                    if (_36tsc.Text != "")
                        count += 1;
                    if (_36tpi.Text != "")
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 11) * 100;
                }
            }
            else if (lblsch.Text == "37" && lblprj.Text != "11784")
            {
                if (DateValidation(_37bc.Text) == true)
                    count += 1;
                if (DateValidation(_37bd.Text) == true)
                    count += 1;
                if (DateValidation(_37br.Text) == true)
                    count += 1;
                if (DateValidation(_37fn.Text) == true)
                    count += 1;
                _percentage = (Convert.ToDecimal(count) / 4) * 100;
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
            bool v = lblsch.Text == "5";
            if (lblsch.Text == "1" || v || (lblprj.Text == "11784" && lblsch.Text == "28"))
            {
                   if (_5tc.Text == "N/A")
                    _percentage = -1;

                if ((IsNumeric(_5total.Text) == true) && (IsNumeric(_5tc.Text) == true))
                {
                    if (lblprj.Text == "ASAO")
                    {

                        _percentage = (Convert.ToDecimal(_5tc.Text));
                    }
                    else
                    {
                        if (Convert.ToDecimal(_5total.Text) > 0)
                            _percentage = (Convert.ToDecimal(_5tc.Text) / Convert.ToDecimal(_5total.Text)) * 100;
                    }
                }
            }
            else if (lblsch.Text == "8" || (lblprj.Text == "11784" && lblsch.Text == "31"))
            {
                if (_8co1.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "9" || (lblprj.Text == "11784" && lblsch.Text == "32"))
            {
                if (_9accept1.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "4" || (lblprj.Text == "11784" && lblsch.Text == "27"))
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (DateValidation(_4pc.Text) == true)
                        count += 1;
                    if (DateValidation(_4as.Text) == true)
                        count += 1;
                    if (DateValidation(_4cable.Text) == true)
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 3) * 100;
                }
                else
                {
                    if (DateValidation(_4cable.Text) == true)
                        _percentage = 100;
                }
            }
            else if (lblsch.Text == "2" || (lblprj.Text == "11784" && lblsch.Text == "25"))
            {
                if (lblprj.Text == "HMIM")
                {
                    decimal IRTestedCables = ((txtCableIR.Text == string.Empty) || (txtCableIR.Text == "N/A")) ? 0 : (Convert.ToDecimal(txtCableIR.Text));
                    decimal TerTorTestedCables = ((txtTerTorTest.Text == string.Empty) || (txtTerTorTest.Text == "N/A")) ? 0 : (Convert.ToDecimal(txtTerTorTest.Text));

                    int NoOfTestParams = 0;
                    if (txtCableIR.Text != "N/A") NoOfTestParams += 1;
                    if (txtTerTorTest.Text != "N/A") NoOfTestParams += 1;

                    if(NoOfTestParams != 0)
                    _percentage = (IRTestedCables + TerTorTestedCables) / (Convert.ToDecimal(lblNoOfCables.Text) * NoOfTestParams) * 100;
                }
                else
                {
                    if (DateValidation(_2cable.Text) == true)
                        _percentage = 100;
                }
            }
            else if (lblsch.Text == "3" || (lblprj.Text == "11784" && (lblsch.Text == "26")))
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (_3cable_1.Text == "") return 0;
                    _percentage = 100;
                }
                else
                {
                    if (_3cable.Text == "") return 0;
                    _percentage = 100;
                }
            }
            else if (lblsch.Text == "6" || (lblprj.Text == "11784" && lblsch.Text == "29"))
            {
                if (DateValidation(_6be.Text) == true)
                    _percentage = 100;
                else if (_6be.Text == "N/A")
                    _percentage = -1;

            }
            else if (lblsch.Text == "7" || (lblprj.Text == "11784" && lblsch.Text == "30"))
            {
                if (lblprj.Text == "ASAO")
                {
                    int _count = 0;
                    int _qty = 0;
                    if ((string)Session["cat"] == "CIR")
                    {
                        if (IsNumeric(_7add.Text) == true)
                            _percentage = Convert.ToDecimal(_7add.Text);
                    }
                    else
                    {
                        if (IsNumeric(_7add.Text) == true)
                        {
                            _count += Convert.ToInt32(_7add.Text);
                            _qty += 1;
                        }
                        if (IsNumeric(_7ft.Text) == true)
                        {
                            _count += Convert.ToInt32(_7ft.Text);
                            _qty += 1;
                        }
                        if (IsNumeric(_7co.Text) == true)
                        {
                            _count += Convert.ToInt32(_7co.Text);
                            _qty += 1;
                        }
                        if (IsNumeric(_7ll.Text) == true)
                        {
                            _count += Convert.ToInt32(_7ll.Text);
                            _qty += 1;
                        }
                        if (IsNumeric(_7du.Text) == true)
                        {
                            _count += Convert.ToInt32(_7du.Text);
                            _qty += 1;
                        }
                        if (IsNumeric(_7pch.Text) == true)
                        {
                            _count += Convert.ToInt32(_7pch.Text);
                            _qty += 1;
                        }
                        int _devices = 0;
                        if (IsNumeric(_7noof.Text) == true)
                            _devices = Convert.ToInt32(_7noof.Text);
                        if (_devices > 0)
                            _percentage = (((_count / _qty)) / _devices) * 100;
                        else
                            _percentage = 0;
                    }
                }
                else
                {
                    if (IsNumeric(_7add.Text) == true)
                        _percentage = Convert.ToDecimal(_7add.Text);
                }
            }
            else if (lblsch.Text == "17" || (lblprj.Text == "11784" && lblsch.Text == "38"))
            {
                if (_17co1.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "20" || (lblprj.Text == "11784" && lblsch.Text == "41"))
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    decimal _total = 0;
                    if (IsNumeric(_20sot.Text) == true)
                    {
                        _total += Convert.ToDecimal(_20sot.Text);
                        count += 1;
                    }
                    if (IsNumeric(_20ght.Text) == true)
                    {
                        _total += Convert.ToDecimal(_20ght.Text);
                        count += 1;
                    }
                    //if (IsNumeric(_20cft.Text) == true)
                    //{
                    //    _total += Convert.ToDecimal(_20cft.Text);
                    //    count += 1;
                    //}
                    decimal _points = 0;
                    if (IsNumeric(_20devices.Text) == true)
                        _points = Convert.ToDecimal(_20devices.Text);
                    if (_points > 0)
                        _percentage = ((_total / count) / _points) * 100;
                    //if (IsNumeric(_20sot.Text) == true && IsNumeric(_20ght.Text) == true)
                    //    _percentage = 1;
                }
                else
                {
                    if (IsNumeric(_20ppt.Text) == true)
                        _percentage = Convert.ToDecimal(_20ppt.Text);
                }
            }
            else if (lblsch.Text == "32" && lblprj.Text!="MOE")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    decimal _total = 0;
                    if (IsNumeric(_20sot.Text) == true)
                    {
                        _total += Convert.ToDecimal(_20sot.Text);
                        count += 1;
                    }
                    if (IsNumeric(_20ght.Text) == true)
                    {
                        _total += Convert.ToDecimal(_20ght.Text);
                        count += 1;
                    }
                    //if (IsNumeric(_20cft.Text) == true)
                    //{
                    //    _total += Convert.ToDecimal(_20cft.Text);
                    //    count += 1;
                    //}
                    decimal _points = 0;
                    if (IsNumeric(_20devices.Text) == true)
                        _points = Convert.ToDecimal(_20devices.Text);
                    if (_points > 0)
                        _percentage = ((_total / count) / _points) * 100;
                    //if (IsNumeric(_20sot.Text) == true && IsNumeric(_20ght.Text) == true)
                    //    _percentage = 1;

                       if (_20sot.Text == "N/A" &&_20ght.Text=="N/A" )
                       {
                           _percentage = -1;

                       }

                }
            }
            else if (lblsch.Text == "13" ||(lblprj.Text == "11784" && lblsch.Text == "36"))
            {
                if (_13cvl.Text != "")
                    _percentage = Convert.ToDecimal(_13cvl.Text);
            }
            else if (lblsch.Text == "22" || (lblprj.Text == "11784" && lblsch.Text == "43"))
            {
                if (_22apt.Text != "")
                    _percentage = Convert.ToDecimal(_22apt.Text);
            }
            else if (lblsch.Text == "11" || (lblprj.Text == "11784" && lblsch.Text == "34"))
            {
                if (IsNumeric(_11lct.Text) == true)
                    _percentage = Convert.ToDecimal(_11lct.Text);
            }
            else if (lblsch.Text == "15")
            {
                if (lblprj.Text == "OPH")
                {
                    if (IsNumeric(_15atht.Text) == true)
                        _percentage = Convert.ToDecimal(_15atht.Text);

                }
                else
                {
                    if (IsNumeric(_15kca.Text))
                        _percentage = Convert.ToDecimal(_15kca.Text);
                }
            }
            else if (lblsch.Text == "14" || (lblprj.Text == "11784" && lblsch.Text == "37"))
            {
                if (IsNumeric(_14diab.Text) == true)
                    _percentage = Convert.ToDecimal(_14diab.Text);
            }
            else if (lblsch.Text == "10" || (lblprj.Text == "11784" && lblsch.Text == "33"))
            {
                //if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                //{
                //    if ((string)Session["cat"] == "FAL")
                //    {
                //        if (IsNumeric(_10ndt.Text) == true)
                //        {
                //            if (Convert.ToInt32(_10devices.Text) == Convert.ToInt32(_10ndt.Text))
                //                _percentage = 1;
                //        }
                //        //if (IsNumeric(_10ndt.Text) == true)
                //        //    _percentage = Convert.ToDecimal(_10ndt.Text);
                //    }
                //    else
                //    {
                //        if (DateValidation(_10ltc.Text) == true)
                //            _percentage = 1;
                //    }
                //}
                //else
                //{
                    if (IsNumeric(_10ndt.Text) == true)
                        _percentage = Convert.ToDecimal(_10ndt.Text);
                //}
            }
            else if (lblsch.Text == "31" && lblprj.Text != "MOE")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if ((string)Session["cat"] == "VAC")
                    {
                        if (IsNumeric(_10ndt.Text) == true)
                            _percentage = Convert.ToDecimal(_10ndt.Text);
                    }
                    else
                    {
                        if (DateValidation(_10ltc.Text) == true)
                            _percentage = 1;
                    }
                }
                else
                {
                    if (IsNumeric(_10ndt.Text) == true)
                        _percentage = Convert.ToDecimal(_10ndt.Text);
                }
            }
            else if (lblsch.Text == "23" || (lblprj.Text == "11784" && lblsch.Text == "44") || (lblprj.Text == "MOE" && lblsch.Text == "31"))
            {
                if (DateValidation(_23tpi.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "27" && lblprj.Text == "12761")
            {
                if (_23tpi.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "16")
            {
                if (IsNumeric(_16ppt.Text) == true)
                    _percentage = Convert.ToDecimal(_16ppt.Text);
            }
            else if (lblsch.Text == "30")
            {
                if (_30co1.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "25" || lblsch.Text == "26")
            {
                if (lblsch.Text == "25" && lblprj.Text == "OPH")
                {
                    if (DateValidation(_25amp.Text) == true)
                        _percentage = 1;
                }
                else if (lblsch.Text == "25" && lblprj.Text == "SRH")
                {
                    if (IsNumeric(_25sapt.Text))
                        _percentage = Convert.ToDecimal(_25sapt.Text);

                }
                else
                {
                    if (_25co1.Text != "")
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "27" && lblprj.Text != "12761")
            {
                if (_25co1.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "24" || (lblprj.Text == "11784" && lblsch.Text == "45")|| (lblprj.Text == "MOE" && lblsch.Text == "32"))
            {
                if (per_com1() == 100)
                    _percentage = 1;
            }
            else if (lblsch.Text == "34" && lblprj.Text != "11784")
            {
                if (per_com1() == 100)
                    _percentage = 1;
            }
            else if (lblsch.Text == "35" && lblprj.Text != "11784")
            {
                if (per_com1() == 100)
                    _percentage = 1;
            }
            else if (lblsch.Text == "36")
            {
                if (per_com1() == 100)
                    _percentage = 1;
            }
            else if (lblsch.Text == "37" && lblprj.Text != "11784")
            {
                if (_37bc.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "28")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {

                    if (DateValidation(_28sac.Text) == true)
                        count += 1;
                    if (DateValidation(_28fit.Text) == true)
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 2) * 100;
                }
                else if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                {
                    if (IsNumeric(_10ndt.Text) == true)
                        _percentage = Convert.ToDecimal(_10ndt.Text);
                }
            }
            else if (lblsch.Text == "29")
            {
                if (DateValidation(_18accept1.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "12" || (lblprj.Text == "11784" && lblsch.Text == "35"))
            {
                if (DateValidation(_12accept1.Text) == true)
                    _percentage = 1;
            }
            return _percentage;
        }
        protected decimal per_com3()
        {
            //if (dev1.Text == "") return 0;
            decimal _percentage = 0;
            if (lblsch.Text == "2" || (lblprj.Text == "11784" && lblsch.Text == "25"))
            {
                if (_2accept1.Text.ToUpper() != "N/A" && _2accept2.Text.ToUpper() == "N/A")
                {
                    if (DateValidation(_2accept1.Text) == true)
                        _percentage = 1;
                }
                else if (_2accept1.Text.ToUpper() == "N/A" && _2accept2.Text.ToUpper() != "N/A")
                {
                    if (DateValidation(_2accept2.Text) == true)
                        _percentage = 1;
                }
                else
                {
                    if (DateValidation(_2accept1.Text) == true && DateValidation(_2accept2.Text) == true)
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "3" || (lblprj.Text == "11784" && lblsch.Text == "26"))
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (DateValidation(_3accept1_1.Text) == true && DateValidation(_3accept2_1.Text) == true)
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "6" || (lblprj.Text == "11784" && lblsch.Text == "29"))
            {
                if (DateValidation(_6lp.Text) == true)
                    _percentage = 100;
                else if (_6lp.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "1" || lblsch.Text == "5" || (lblprj.Text == "11784" && lblsch.Text == "28"))
            {
                if (_5tl.Text == "N/A")
                    _percentage = -1;

                if ((IsNumeric(_5total.Text) == true) && (IsNumeric(_5tl.Text) == true))
                {
                    if (lblprj.Text == "ASAO")
                    {
                        _percentage = (Convert.ToDecimal(_5tl.Text));
                    }
                    else
                    {
                        if (Convert.ToDecimal(_5total.Text) > 0)
                            _percentage = (Convert.ToDecimal(_5tl.Text) / Convert.ToDecimal(_5total.Text)) * 100;
                    }

                }
            }
            else if (lblsch.Text == "4" || (lblprj.Text == "11784" && lblsch.Text == "27"))
            {
                int count = 0;
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (DateValidation(_4lb.Text) == true)
                        count += 1;
                    if (DateValidation(_4sol.Text) == true)
                        count += 1;
                    _percentage = (Convert.ToDecimal(count) / 2) * 100;
                }
                else
                {
                    if (DateValidation(_4sol.Text) == true)
                        _percentage = 100;
                }
            }
            else if (lblsch.Text == "7" || (lblprj.Text == "11784" && lblsch.Text == "30"))
            {
                if (IsNumeric(_7ft.Text) == true)
                    _percentage = Convert.ToDecimal(_7ft.Text);
            }
            else if (lblsch.Text == "8" || (lblprj.Text == "11784" && lblsch.Text == "31"))
            {
                if (_8wd1.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "20" || (lblprj.Text == "11784" && lblsch.Text == "41"))
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (DateValidation(_20accept1.Text) == true && DateValidation(_20accept2.Text) == true && DateValidation(_20accept3.Text) == true)
                        _percentage = 1;
                }
                else
                {
                    if (IsNumeric(_20cft.Text) == true)
                        _percentage = Convert.ToDecimal(_20cft.Text);
                }
            }
            else if (lblsch.Text == "32")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (DateValidation(_20accept1.Text) == true && DateValidation(_20accept2.Text) == true && DateValidation(_20accept3.Text) == true)
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "17" || (lblprj.Text == "11784" && lblsch.Text == "38"))
            {
                if (_17wd1.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "13" ||(lblprj.Text == "11784" && lblsch.Text == "36"))
            {
                if (IsNumeric(_13cvh.Text) == true)
                    _percentage = Convert.ToDecimal(_13cvh.Text);
            }
            else if (lblsch.Text == "22" || (lblprj.Text == "11784" && lblsch.Text == "43"))
            {
                if (IsNumeric(_22fat.Text) == true)
                    _percentage = Convert.ToDecimal(_22fat.Text);
            }
            else if (lblsch.Text == "11" || (lblprj.Text == "11784" && lblsch.Text == "34"))
            {
                if (IsNumeric(_11apt.Text) == true)
                    _percentage = Convert.ToDecimal(_11apt.Text);
            }
            else if (lblsch.Text == "15")
            {
                if (lblprj.Text == "OPH")
                {
                    if (IsNumeric(_15athtc.Text) == true)
                        _percentage = Convert.ToDecimal(_15athtc.Text);

                }
                else
                {
                    if (IsNumeric(_15dnd.Text) == true)
                        _percentage = Convert.ToDecimal(_15dnd.Text);
                }
            }
            else if (lblsch.Text == "14" || (lblprj.Text == "11784" && lblsch.Text == "37"))
            {
                if (IsNumeric(_14avt.Text) == true)
                    _percentage = Convert.ToDecimal(_14avt.Text);
            }
            else if (lblsch.Text == "10" || (lblprj.Text == "11784" && lblsch.Text == "33"))
            {
                //if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                //{
                //    if (DateValidation(_10accept1.Text) == true && DateValidation(_10accept2.Text) == true)
                //        _percentage = 1;
                //}
                //else
                //{
                    if (IsNumeric(_10fait.Text) == true)
                        _percentage = Convert.ToDecimal(_10fait.Text);
                //}
            }
            else if (lblsch.Text == "31" && lblprj.Text != "MOE")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (DateValidation(_10accept1.Text) == true && DateValidation(_10accept2.Text) == true)
                        _percentage = 1;
                }
                else
                {
                    if (IsNumeric(_10fait.Text) == true)
                        _percentage = Convert.ToDecimal(_10fait.Text);
                }
            }
            else if (lblsch.Text == "23" || (lblprj.Text == "11784" && lblsch.Text == "44") || (lblprj.Text == "MOE" && lblsch.Text == "31"))
            {
                if (DateValidation(_23eml.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "27" && lblprj.Text == "12761")
            {
                if (_23eml.Text != "")
                    if (_23eml.Text != "N/A")
                        _percentage = 1;
            }
            else if (lblsch.Text == "16")
            {
                if (IsNumeric(_16cft.Text) == true)
                    _percentage = Convert.ToDecimal(_16cft.Text);
            }
            else if (lblsch.Text == "30")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (DateValidation(_30accept1.Text) == true)
                        _percentage = 1;
                }
                else if (_30wd1.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "25")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (DateValidation(_25accept1.Text) == true)
                        _percentage = 1;
                }
                else if (lblprj.Text == "OPH")
                {
                    if (DateValidation(_25aebt.Text) == true)
                        _percentage = 1;

                }
                else if (lblsch.Text == "25" && lblprj.Text == "SRH")
                {
                    if (IsNumeric(_25sfat.Text))
                        _percentage = Convert.ToDecimal(_25sfat.Text);

                }
                else
                {
                    if (_25wd1.Text != "")
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "26")
            {
                if (DateValidation(_25accept1.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "27" && lblprj.Text != "12761")
            {
                if (lblprj.Text == "OPH")
                {
                    if (IsNumeric(_27pm.Text) == true)
                        _percentage = Convert.ToDecimal(_27pm.Text);

                }
                else
                {
                    if (DateValidation(_25accept1.Text) == true)
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "37" && lblprj.Text != "11784")
            {
                if (_37bd.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "28")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (DateValidation(_28accept1.Text) == true)
                        _percentage = 1;
                }
                else if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                {
                    if (IsNumeric(_10fait.Text) == true)
                        _percentage = Convert.ToDecimal(_10fait.Text);
                }
            }
            else if (lblsch.Text == "36")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (DateValidation(_36accept1.Text) == true)
                        _percentage = 1;
                }
            }
            return _percentage;
        }
        protected decimal per_com4()
        {
            //    //if (dev1.Text == "") return 0;
            decimal _percentage = 0;
            int count = 0;
            if (lblsch.Text == "4" || (lblprj.Text == "11784" && lblsch.Text == "27"))
            {
                if (DateValidation(_4accept1.Text) == true && DateValidation(_4accept2.Text) == true && DateValidation(_4accept3.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "2" && lblprj.Text == "ASAO")
            {
                if (DateValidation(_2pwron.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "3" && lblprj.Text == "ASAO")
            {
                if (DateValidation(_3pwron_1.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "2" && lblprj.Text == "ASAO1")
            {
                if (DateValidation(_2pwron.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "3" && lblprj.Text == "ASAO1")
            {
                if (DateValidation(_3pwron_1.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "5" || (lblprj.Text == "11784" && lblsch.Text == "28"))
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
            else if (lblsch.Text == "6" || (lblprj.Text == "11784" && lblsch.Text == "29"))
            {
                if (DateValidation(_6br.Text) == true)
                    _percentage = 100;
                else if (_6br.Text == "N/A")
                    _percentage = -1;
            }
            else if (lblsch.Text == "7" || (lblprj.Text == "11784" && lblsch.Text == "30"))
            {
                if (IsNumeric(_7co.Text) == true)
                {
                    if (lblprj.Text == "11736")
                    {
                        if (IsNumeric(_7noof.Text) == true)
                        {
                            if (Convert.ToDecimal(_7co.Text) == Convert.ToDecimal(_7noof.Text))
                                _percentage = 1;
                        }
                    }
                    else
                        _percentage = Convert.ToDecimal(_7co.Text);
                }
            }

            else if (lblsch.Text == "8" || (lblprj.Text == "11784" && lblsch.Text == "31"))
            {
                if (IsNumeric(_8duty.Text) == true)
                    _percentage = Convert.ToDecimal(_8duty.Text);
            }
            else if (lblsch.Text == "17" || (lblprj.Text == "11784" && lblsch.Text == "38"))
            {
                decimal _total = per_com1() + per_com2();
                _percentage = (_total / 2) * 100;
            }
            else if (lblsch.Text == "20" || lblsch.Text == "32" || (lblprj.Text == "11784" && lblsch.Text == "41"))
            {
                if (IsNumeric(_20sot.Text) == true)
                    _percentage = Convert.ToDecimal(_20sot.Text);
            }
            else if (lblsch.Text == "13" || (lblprj.Text == "11784" && lblsch.Text == "36"))
            {
                if (IsNumeric(_13ast.Text) == true)
                    _percentage = Convert.ToDecimal(_13ast.Text);
            }
            else if (lblsch.Text == "22" || (lblprj.Text == "11784" && lblsch.Text == "43"))
            {
                if (IsNumeric(_22acs.Text) == true)
                    _percentage = Convert.ToDecimal(_22acs.Text);
            }
            else if (lblsch.Text == "11" || (lblprj.Text == "11784" && lblsch.Text == "34"))
            {
                if (IsNumeric(_11phgt.Text) == true)
                    _percentage = Convert.ToDecimal(_11phgt.Text);
            }
            else if (lblsch.Text == "15")
            {
                if (lblprj.Text == "OPH")
                {
                    if (IsNumeric(_15afit.Text) == true)
                        _percentage = Convert.ToDecimal(_15afit.Text);

                }
                else
                {
                    if (IsNumeric(_15mur.Text) == true)
                        _percentage = Convert.ToDecimal(_15mur.Text);
                }
            }
            else if (lblsch.Text == "14" || (lblprj.Text == "11784" && lblsch.Text == "37"))
            {
                if (IsNumeric(_14drt.Text) == true)
                    _percentage = Convert.ToDecimal(_14drt.Text);
            }
            else if (lblsch.Text == "10" || (lblprj.Text == "11784" && lblsch.Text == "33"))
            {
                if (IsNumeric(_10slt.Text) == true)
                    _percentage = Convert.ToDecimal(_10slt.Text);
            }
            else if (lblsch.Text == "23" || (lblprj.Text == "11784" && lblsch.Text == "44") || (lblprj.Text == "MOE" && lblsch.Text == "31"))
            {
                if (DateValidation(_23pfm.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "27" && lblprj.Text == "12761")
            {
                if (_23pfm.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "16")
            {
                if (_16sop.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "30")
            {
                decimal _total = per_com1() + per_com2();
                _percentage = (_total / 2) * 100;
            }
            else if (lblsch.Text == "25")
            {
                if (lblsch.Text == "25" && lblprj.Text == "SRH")
                {
                    if (IsNumeric(_25spft.Text))
                        _percentage = Convert.ToDecimal(_25spft.Text);

                }
                else
                { 
                decimal _total = per_com1() + per_com2();
                _percentage = (_total / 2) * 100;
            }
            }
            else if (lblsch.Text == "26")
            {
                if (IsNumeric(_26duty.Text) == true)
                    _percentage = Convert.ToDecimal(_26duty.Text);
            }
            else if (lblsch.Text == "27" && lblprj.Text != "12761")
            {
                if (lblprj.Text == "OPH")
                {
                    if (IsNumeric(_27ast.Text) == true)
                        _percentage = Convert.ToDecimal(_27ast.Text);

                }
                else
                {
                    if (IsNumeric(_26duty.Text) == true)
                        _percentage = Convert.ToDecimal(_26duty.Text);
                }
            }
            else if (lblsch.Text == "37" && lblprj.Text != "11784")
            {
                if (_37br.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "28" && (lblprj.Text == "HMIM" || lblprj.Text=="HMHS"))
            {
                if (IsNumeric(_10slt.Text) == true)
                    _percentage = Convert.ToDecimal(_10slt.Text);
            }
            return _percentage;
        }
        protected decimal per_com5()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "6" || (lblprj.Text == "11784" && lblsch.Text == "29"))
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
            else if (lblsch.Text == "7" || (lblprj.Text == "11784" && lblsch.Text == "30"))
            {
                if (IsNumeric(_7ll.Text) == true)
                    _percentage = Convert.ToDecimal(_7ll.Text);
            }
            else if (lblsch.Text == "8" || (lblprj.Text == "11784" && lblsch.Text == "31"))
            {
                if (lblprj.Text == "CCAD")
                {
                    if (_8pft.Text != "")
                        _percentage = 1;
                }
                else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    if (DateValidation(_8accept1.Text) == true)
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "20" || lblsch.Text == "32" || (lblprj.Text == "11784" && lblsch.Text == "41"))
            {
                if (IsNumeric(_20ght.Text) == true)
                    _percentage = Convert.ToDecimal(_20ght.Text);
            }
            else if (lblsch.Text == "13" ||(lblprj.Text == "11784" && lblsch.Text == "36"))
            {
                if (IsNumeric(_13rbst.Text) == true)
                    _percentage = Convert.ToDecimal(_13rbst.Text);
            }
            else if (lblsch.Text == "22" || (lblprj.Text == "11784" && lblsch.Text == "43"))
            {
                if (IsNumeric(_22pft.Text) == true)
                    _percentage = Convert.ToDecimal(_22pft.Text);
            }
            else if (lblsch.Text == "15")
            {
                if (lblprj.Text == "OPH")
                {
                    if (IsNumeric(_15athtc.Text) == true)
                        _percentage = Convert.ToDecimal(_15athtc.Text);

                }
                else
                {
                    if (IsNumeric(_15ftc.Text) == true)
                        _percentage = Convert.ToDecimal(_15ftc.Text);
                }
            }
            else if (lblsch.Text == "14" || (lblprj.Text == "11784" && lblsch.Text == "37"))
            {
                decimal _total = per_com1() + per_com2() + per_com3() + per_com4();
                decimal _qty = Convert.ToDecimal(_14noof.Text);
                _percentage = (_total / (_qty * 4)) * 100;
            }
            else if (lblsch.Text == "10" || (lblprj.Text == "11784" && lblsch.Text == "33"))
            {
                if (lblprj.Text == "BCC1")
                {
                    if ((string)Session["cat"] == "FACP" || (string)Session["cat"] == "FARP")
                    {
                        if (DateValidation(_10bat.Text) == true)
                            _percentage = 1;
                    }
                }
                else
                {
                    if (IsNumeric(_10bat.Text) == true)
                        _percentage = Convert.ToDecimal(_10bat.Text);
                }
            }
            else if (lblsch.Text == "23" || (lblprj.Text == "11784" && lblsch.Text == "44") || (lblprj.Text == "MOE" && lblsch.Text == "31"))
            {
                if (DateValidation(_23lms.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "27" && lblprj.Text == "12761")
            {
                if (_23lms.Text != "")
                    if (_23lms.Text != "N/A")
                        _percentage = 1;
            }
            else if (lblsch.Text == "16")
            {
                if (_16ght.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "30")
            {
                if (_30idc.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "25" || lblsch.Text == "26")
            {
                if (lblsch.Text == "25" && lblprj.Text == "SRH")
                {
                    if (IsNumeric(_25sit.Text))
                        _percentage = Convert.ToDecimal(_25sit.Text);

                }
                else
                {
                    if (_25idc.Text != "")
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "27" && lblprj.Text != "12761")
            {
                if (_25idc.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "37" && lblprj.Text != "11784")
            {
                if (_37fn.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "11" || (lblprj.Text == "11784" && lblsch.Text == "34"))
            {
                if (DateValidation(_11accept1.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "17" && lblprj.Text == "ASAO")
            {
                if (DateValidation(_17accept1.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "17" && lblprj.Text == "ASAO1")
            {
                if (DateValidation(_17accept1.Text) == true)
                    _percentage = 1;
            }
            else if ((lblprj.Text == "HMIM" || lblprj.Text == "HMHS") && lblsch.Text == "28")
            {
                if (IsNumeric(_10bat.Text) == true)
                    _percentage = Convert.ToDecimal(_10bat.Text);
            }
            return _percentage;
        }
        protected decimal per_com6()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "7" || (lblprj.Text == "11784" && lblsch.Text == "30"))
            {
                if (IsNumeric(_7du.Text) == true)
                {
                    if (lblprj.Text == "11736")
                    {
                        if (IsNumeric(_7noof.Text) == true)
                        {
                            if (Convert.ToDecimal(_7du.Text) == Convert.ToDecimal(_7noof.Text))
                                _percentage = 1;
                        }
                    }
                    _percentage = Convert.ToDecimal(_7du.Text);
                }
            }
            else if (lblsch.Text == "8" || (lblprj.Text == "11784" && lblsch.Text == "31"))
            {
                if (lblprj.Text == "CCAD")
                {
                    if (_8pwron.Text != "")
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "20" || lblsch.Text == "32" || (lblprj.Text == "11784" && lblsch.Text == "41"))
            {
                if (IsNumeric(_20lt.Text) == true)
                    _percentage = Convert.ToDecimal(_20lt.Text);
            }
            else if (lblsch.Text == "13" ||(lblprj.Text == "11784" && lblsch.Text == "36"))
            {
                decimal _total = per_com1() + per_com2() + per_com3() + per_com4() + per_com5();
                decimal _qty = Convert.ToDecimal(_13noof.Text);
                _percentage = (_total / (_qty * 5)) * 100;
            }
            else if (lblsch.Text == "22" || (lblprj.Text == "11784" && lblsch.Text == "43"))
            {
                if (IsNumeric(_22it.Text) == true)
                    _percentage = Convert.ToDecimal(_22it.Text);
            }
            else if (lblsch.Text == "15")
            {
                if (lblprj.Text == "OPH")
                {
                    if (IsNumeric(_15acet.Text) == true)
                        _percentage = Convert.ToDecimal(_15acet.Text);

                }
                else
                {
                    if (IsNumeric(_15ems.Text) == true)
                        _percentage = Convert.ToDecimal(_15ems.Text);
                }
            }
            else if (lblsch.Text == "10" || (lblprj.Text == "11784" && lblsch.Text == "33"))
            {
                if (lblprj.Text == "BCC1")
                {
                    if ((string)Session["cat"] == "FACP" || (string)Session["cat"] == "FARP" || (string)Session["cat"] == "PAVA")
                    {
                        if (DateValidation(_10ghet.Text) == true)
                            _percentage = 1;
                    }
                }
                else
                {
                    if (IsNumeric(_10ghet.Text) == true)

                        _percentage = Convert.ToDecimal(_10ghet.Text);
                }
            }
            else if (lblsch.Text == "23" || (lblprj.Text == "11784" && lblsch.Text == "44") || (lblprj.Text == "MOE" && lblsch.Text == "31"))
            {
                if (DateValidation(_23int.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "27" && lblprj.Text == "12761")
            {
                if (_23int.Text != "")
                    if (_23int.Text != "N/A")
                        _percentage = 1;
            }
            else if (lblsch.Text == "30")
            {
                if (_30dlt.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "37" && lblprj.Text != "11784")
            {
                if (_37iso.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "28" && (lblprj.Text == "HMIM" || lblprj.Text=="HMHS"))
            {
                if (IsNumeric(_10ghet.Text) == true)
                    _percentage = Convert.ToDecimal(_10ghet.Text);
            }
            else if (lblsch.Text == "25" && lblprj.Text == "SRH")
            {
                if (IsNumeric(_25sphgt.Text))
                    _percentage = Convert.ToDecimal(_25sphgt.Text);

            }
            return _percentage;
        }
        protected decimal per_com7()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "7" || (lblprj.Text == "11784" && lblsch.Text == "30"))
            {
                if (IsNumeric(_7pch.Text) == true)
                    _percentage = Convert.ToDecimal(_7pch.Text);
            }
            else if (lblsch.Text == "8" || (lblprj.Text == "11784" && lblsch.Text == "31"))
            {
                if (lblprj.Text == "CCAD")
                {
                    if (_8fpt.Text != "")
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "22" || (lblprj.Text == "11784" && lblsch.Text == "43"))
            {
                if (IsNumeric(_22phgt.Text) == true)
                    _percentage = Convert.ToDecimal(_22phgt.Text);
            }
            else if (lblsch.Text == "15")
            {
                if (lblprj.Text == "OPH")
                {
                    if (IsNumeric(_15acet.Text) == true)
                        _percentage = Convert.ToDecimal(_15acet.Text);

                }
                else
                {
                    if (IsNumeric(_15lsc.Text) == true)
                        _percentage = Convert.ToDecimal(_15lsc.Text);
                }
            }
            else if (lblsch.Text == "10" || (lblprj.Text == "11784" && lblsch.Text == "33"))
            {
                if (lblprj.Text == "BCC1")
                {
                    if ((string)Session["cat"] == "CE")
                    {
                        if (DateValidation(_10cet.Text) == true)
                            _percentage = 1;
                    }
                }
                else
                {
                    if (IsNumeric(_10cet.Text) == true)
                        _percentage = Convert.ToDecimal(_10cet.Text);
                }
            }
            else if (lblsch.Text == "23" || (lblprj.Text == "11784" && lblsch.Text == "44") || (lblprj.Text == "MOE" && lblsch.Text == "31"))
            {
                if (DateValidation(_23bfa.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "27" && lblprj.Text == "12761")
            {
                if (_23bfa.Text != "")
                    _percentage = 1;
            }
            else if (lblsch.Text == "37" && lblprj.Text != "11784")
            {
                if (DateValidation(_37accept.Text) == true)
                    _percentage = 1;
            }
            else if ((lblprj.Text == "HMIM" || lblprj.Text == "HMHS") && lblsch.Text == "28")
            {
                if (IsNumeric(_10cet.Text) == true)
                    _percentage = Convert.ToDecimal(_10cet.Text);
            }
            else if (lblsch.Text == "25" || lblprj.Text == "SRH")
            {
                decimal _total = per_com1() + per_com2() + per_com3() + per_com4() + per_com5() + per_com6();
                decimal _qty = Convert.ToDecimal(_25snoof.Text);
                _percentage = (_total / (_qty * 6)) * 100;
            }
            return _percentage;
        }
        protected decimal per_com8()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "22" || (lblprj.Text == "11784" && lblsch.Text == "43"))
            {
                decimal _total = per_com1() + per_com2() + per_com3() + per_com4() + per_com5() + per_com6() + per_com7();
                decimal _qty = Convert.ToDecimal(_22noof.Text);
                _percentage = (_total / (_qty * 7)) * 100;
            }
            else if (lblsch.Text == "8" || (lblprj.Text == "11784" && lblsch.Text == "31"))
            {
                if (lblprj.Text == "CCAD")
                {
                    if (_8arm.Text != "")
                        _percentage = 1;
                }
            }
            else if (lblsch.Text == "15" && lblprj.Text != "OPH")
            {
                if (IsNumeric(_15bci.Text) == true)
                    _percentage = Convert.ToDecimal(_15bci.Text);
            }
            else if (lblsch.Text == "23" || (lblprj.Text == "11784" && lblsch.Text == "44") || (lblprj.Text == "MOE" && lblsch.Text == "31"))
            {
                //if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                //{
                    if (DateValidation(_23tc.Text) == true)
                        _percentage = 1;
                //}
                //else
                //{
                //    decimal _total = per_com1() + per_com2() + per_com3() + per_com4() + per_com5() + per_com6() + per_com7();
                //    if ((string)Session["cat"] == "LIFT")
                //        _percentage = (_total / 7) * 100;
                //    else
                //        _percentage = (_total / 4) * 100;
                //}
            }
            else if (lblsch.Text == "27" && lblprj.Text == "12761")
            {
                if (DateValidation(_23tc.Text) == true)
                    _percentage = 1;
                //decimal _total = per_com1() + per_com2() + per_com3() + per_com4() + per_com5() + per_com6() + per_com7();
                //if ((string)Session["cat"] == "LIFT")
                //    _percentage = (_total / 7) * 100;
                //else
                //    _percentage = (_total / 4) * 100;
            }
            else if (lblsch.Text == "7" || (lblprj.Text == "11784" && lblsch.Text == "30"))
            {
                if (DateValidation(_7accept1.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "10" || (lblprj.Text == "11784" && lblsch.Text == "33"))
            {
                if (IsNumeric(_10iet.Text) == true)
                    _percentage = Convert.ToDecimal(_10iet.Text);

            }
            else if (lblsch.Text == "28" && (lblprj.Text == "HMIM" || lblprj.Text=="HMHS"))
            {
                if (IsNumeric(_10iet.Text) == true)
                    _percentage = Convert.ToDecimal(_10iet.Text);
            }
            return _percentage;
        }
        protected decimal per_com9()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "15" && lblprj.Text != "OPH")
            {
                if (IsNumeric(_15mif.Text) == true)
                    _percentage = Convert.ToDecimal(_15mif.Text);
            }
            else if (lblsch.Text == "23" || (lblprj.Text == "11784" && lblsch.Text == "44") || (lblprj.Text == "MOE" && lblsch.Text == "31"))
            {
                if (DateValidation(_23accept1.Text) == true)
                    _percentage = 1;
            }
            else if (lblsch.Text == "27" && lblprj.Text == "12761")
            {
                if (DateValidation(_23accept1.Text) == true)
                    _percentage = 1;
            }
            return _percentage;
        }
        protected decimal per_com10()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "15" && lblprj.Text != "OPH")
            {
                decimal _total = per_com1() + per_com2() + per_com3() + per_com4() + per_com5() + per_com6() + per_com7() + per_com8() + per_com9();
                decimal _qty = Convert.ToDecimal(_15noof.Text);
                _percentage = (_total / (_qty * 9)) * 100;
            }
            else if (lblsch.Text == "23" || (lblprj.Text == "11784" && lblsch.Text == "44") || (lblprj.Text == "MOE" && lblsch.Text == "31"))
            {
                if (per_com8() == 100)
                    _percentage = 1;
            }
            else if (lblsch.Text == "27" && lblprj.Text == "12761")
            {
                if (per_com8() == 100)
                    _percentage = 1;
            }
            return _percentage;
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
                if (lblsch.Text == "2" || (lblprj.Text == "11784" && lblsch.Text == "25"))
                {
                    if (lblprj.Text == "HMIM")
                    {
                        txtPowerOnDate.Text = row["Pwr_on"].ToString(); 
                        txtTorqueTest.Text = row["test1"].ToString(); 
                        txtIRTest.Text = row["test2"].ToString(); 
                        txtHiPotTest.Text = row["test3"].ToString(); 
                        txtVTTest.Text = row["test4"].ToString(); 
                        txtCTTest.Text = row["test5"].ToString() ; 
                        txtPrimInjTest.Text = row["test6"].ToString(); 
                        txtSecInjTest.Text = row["test7"].ToString(); 
                        txtDuctorTest.Text = row["test11"].ToString(); 
                        txtFuncTest.Text = row["test12"].ToString(); 
                        txtProtRelayTest.Text = row["test13"].ToString(); 
                        txtCableIR.Text = row["test14"].ToString(); 
                        txtTerTorTest.Text = row["tested1"].ToString(); 
                        txtCableTestComplete.Text = row["tested2"].ToString(); 
                        txtConsAccepted3.Text = row["test8"].ToString(); 
                        txtTestSheetFiled3.Text = row["test9"].ToString(); 
                        txtConsAccepted1.Text = row["accept1"].ToString(); 
                        txtConsAccepted2.Text = row["accept2"].ToString(); 
                        txtTestSheetFiled1.Text = row["filed1"].ToString(); 
                        txtTestSheetFiled2.Text = row["filed2"].ToString(); 
                        txtComments.Text = row["Comm"].ToString(); 
                        txtActionBy.Text = row["Act_by"].ToString();
                        txtActionDate.Text = row["Act_Date"].ToString();

                        SetCheckedBoxChecked(txtPowerOnDate, chkPowerOnDate);
                        SetCheckedBoxChecked(txtTorqueTest, chkTorqueTest);
                        SetCheckedBoxChecked(txtIRTest, chkIRTest);
                        SetCheckedBoxChecked(txtHiPotTest, chkHiPotTest);
                        SetCheckedBoxChecked(txtVTTest, chkVTTest);
                        SetCheckedBoxChecked(txtCTTest, chkCTTest);
                        SetCheckedBoxChecked(txtPrimInjTest, chkPrimInjTest);
                        SetCheckedBoxChecked(txtSecInjTest, chkSecInjTest);
                        SetCheckedBoxChecked(txtDuctorTest, chkDuctorTest);
                        SetCheckedBoxChecked(txtFuncTest, chkFuncTest);
                        SetCheckedBoxChecked(txtProtRelayTest, chkProtRelayTest);
                        SetCheckedBoxChecked(txtCableIR, chkCableIR);
                        SetCheckedBoxChecked(txtTerTorTest, chkTerTorTest);
                        SetCheckedBoxChecked(txtCableTestComplete, chkCableTestComplete);
                        SetCheckedBoxChecked(txtConsAccepted3, chkConsAccepted3);
                        SetCheckedBoxChecked(txtTestSheetFiled3, chkTestSheetFiled3);
                        SetCheckedBoxChecked(txtConsAccepted2, chkConsAccepted2);
                        SetCheckedBoxChecked(txtConsAccepted1, chkConsAccepted1);
                        SetCheckedBoxChecked(txtTestSheetFiled1, chkTestSheetFiled1);
                        SetCheckedBoxChecked(txtTestSheetFiled2, chkTestSheetFiled2);                       
                        SetCheckedBoxChecked(txtActionBy, chkActionBy);
                        SetCheckedBoxChecked(txtActionDate, chkActionDate);
                    }
                    else
                    {
                        _2pwron.Text = row[14].ToString();
                        _2tor.Text = row[24].ToString();
                        _2ir.Text = row[25].ToString();
                        _2hi.Text = row[26].ToString();
                        _2vt.Text = row[27].ToString();
                        _2ct.Text = row[28].ToString();
                        _2pi.Text = row[29].ToString();
                        //if (row[21].ToString() != "0")
                        //    _2cable.Text = row[21].ToString();
                        //else
                        _2cable.Text = row["test14"].ToString();
                        _2accept1.Text = row["accept1"].ToString();
                        _2filed1.Text = row["filed1"].ToString();
                        _2accept2.Text = row["accept2"].ToString();
                        _2filed2.Text = row["filed2"].ToString();
                        _2commts.Text = row[18].ToString();
                        _2actby.Text = row[19].ToString();
                        _2actdt.Text = row[20].ToString();
                        _2si.Text = row["test7"].ToString();
                        _2cr.Text = row["test11"].ToString();
                        _2fn.Text = row["test12"].ToString();
                        _2pr.Text = row["test13"].ToString();

                        SetCheckedBoxChecked(_2pwron, chk_2pwron);
                        SetCheckedBoxChecked(_2tor, chk_2tor);
                        SetCheckedBoxChecked(_2ir, chk_2ir);
                        SetCheckedBoxChecked(_2hi, chk_2hi);
                        SetCheckedBoxChecked(_2vt, chk_2vt);
                        SetCheckedBoxChecked(_2ct, chk_2ct);
                        SetCheckedBoxChecked(_2pi, chk_2pi);
                        SetCheckedBoxChecked(_2cable, chk_2cable);
                        SetCheckedBoxChecked(_2accept1, chk_2accept1);
                        SetCheckedBoxChecked(_2filed1, chk_2filed1);
                        SetCheckedBoxChecked(_2accept2, chk_2accept2);
                        SetCheckedBoxChecked(_2filed2, chk_2filed2);
                        SetCheckedBoxChecked(_2si, chk_2si);
                        SetCheckedBoxChecked(_2cr, chk_2cr);
                        SetCheckedBoxChecked(_2fn, chk_2fn);
                        SetCheckedBoxChecked(_2pr, chk_2pr);

                        SetCheckedBoxChecked(_2actby, chk_2actby);
                        SetCheckedBoxChecked(_2actdt, chk_2actdt);
                    }

                }
                else if (lblsch.Text == "3" || (lblprj.Text == "11784" && lblsch.Text == "26"))
                {
                    if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                    {
                        _3pwron_1.Text = row[14].ToString();
                        _3ir_1.Text = row[24].ToString();
                        _3rt_1.Text = row[25].ToString();
                        _3mcbt.Text = row[26].ToString();
                        _3vg_1.Text = row[27].ToString();
                        _3trf_1.Text = row[28].ToString();
                        _3cable_1.Text = row[29].ToString();
                        _3mct.Text = row[30].ToString();
                        _3accept1_1.Text = row["accept1"].ToString();
                        _3filed1_1.Text = row["filed1"].ToString();
                        _3accept2_1.Text = row["accept2"].ToString();
                        _3filed2_1.Text = row["filed2"].ToString();
                        _3commts_1.Text = row[18].ToString();
                        _3actby_1.Text = row[19].ToString();
                        _3actdt_1.Text = row[20].ToString();
                    }
                    else
                    {
                        _3pwron.Text = row[14].ToString();
                        _3ir.Text = row[24].ToString();
                        _3rt.Text = row[25].ToString();
                        _3wr.Text = row[26].ToString();
                        _3vg.Text = row[27].ToString();
                        _3trf.Text = row[28].ToString();
                        _3cable.Text = row[29].ToString();
                        _3accept1.Text = row["accept1"].ToString();
                        _3filed1.Text = row["filed1"].ToString();
                        _3accept2.Text = row["accept2"].ToString();
                        _3filed2.Text = row["filed2"].ToString();
                        _3commts.Text = row[18].ToString();
                        _3actby.Text = row[19].ToString();
                        _3actdt.Text = row[20].ToString();


                        //chk_3ir.Checked = true;
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
                        // SetCheckedBoxChecked(_3commts, chk_3commts);
                        SetCheckedBoxChecked(_3actby, chk_3actby);
                        SetCheckedBoxChecked(_3actdt, chk_3actdt);

                    }
                }
                else if (lblsch.Text == "6" || (lblprj.Text == "11784" && lblsch.Text == "29"))
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
                else if (lblsch.Text == "1" || lblsch.Text == "5" || (lblprj.Text == "11784" && lblsch.Text == "28"))
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
                else if (lblsch.Text == "4" || (lblprj.Text == "11784" && lblsch.Text == "27"))
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
                else if (lblsch.Text == "7" || (lblprj.Text == "11784" && lblsch.Text == "30"))
                {
                    //if (row[24].ToString() != "") _7cir.Text = row[24].ToString();
                    //if (row[25].ToString() != "") _7add.Text = row[25].ToString();
                    //if (row[26].ToString() != "") _7ft.Text = row[26].ToString();
                    //if (row[27].ToString() != "") _7co.Text = row[27].ToString();
                    //if (row[28].ToString() != "") _7ll.Text = row[28].ToString();
                    //if (row[29].ToString() != "") _7du.Text = row[29].ToString();
                    //if (row[30].ToString() != "") _7pch.Text = row[30].ToString();
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
                else if (lblsch.Text == "8" || (lblprj.Text == "11784" && lblsch.Text == "31"))
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

                    SetCheckedBoxChecked(_8pc1, chk_8pc1);
                    SetCheckedBoxChecked(_8co1, chk_8co1);
                    SetCheckedBoxChecked(_8wd1, chk_8wd1);
                    SetCheckedBoxChecked(_8pc2, chk_8pc2);
                    SetCheckedBoxChecked(_8co2, chk_8co2);
                    SetCheckedBoxChecked(_8dv, chk_8dv);
                    SetCheckedBoxChecked(_8ov, chk_8ov);

                    SetCheckedBoxChecked(_8accept1, chk_8accept1);
                    SetCheckedBoxChecked(_8filed1, chk_8filed1);
                    SetCheckedBoxChecked(_8wd2, chk_8wd2);

                    //SetCheckedBoxChecked(_8commts, chk_8commts);
                    SetCheckedBoxChecked(_8actby, chk_8actby);
                    SetCheckedBoxChecked(_8actdt, chk_8actdt);


                }
                else if (lblsch.Text == "9" || (lblprj.Text == "11784" && lblsch.Text == "32"))
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
                    if (lblprj.Text == "OPH")
                        _9pcd.Text = row["PCdate"].ToString();

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
                else if (lblsch.Text == "10" || (lblsch.Text == "31" && lblprj.Text != "MOE") || (lblprj.Text == "11784" && lblsch.Text == "33"))
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
                else if (lblsch.Text == "21" || (lblprj.Text == "11784" && (string)Session["sch"] == "42"))
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
                else if (lblsch.Text == "17" || (lblprj.Text == "11784" && lblsch.Text == "38"))
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
                else if (lblsch.Text == "18" || (lblprj.Text == "11784" && lblsch.Text == "39"))
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

                    SetCheckedBoxChecked(_18qt, chk_18qt);
                    SetCheckedBoxChecked(_18wt, chk_18wt);
                    SetCheckedBoxChecked(_18accept1, chk_18accept1);
                    SetCheckedBoxChecked(_18filed1, chk_18filed1);


                    //SetCheckedBoxChecked(_18commts, chk_18commts);
                    SetCheckedBoxChecked(_18actby, chk_18actby);
                    SetCheckedBoxChecked(_18actdt, chk_18actdt);
                    //SetCheckedBoxChecked(_18noof, chk_18noof);
                }
                else if (lblsch.Text == "29")
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

                    SetCheckedBoxChecked(_18qt, chk_18qt);
                    SetCheckedBoxChecked(_18wt, chk_18wt);
                    SetCheckedBoxChecked(_18accept1, chk_18accept1);
                    SetCheckedBoxChecked(_18filed1, chk_18filed1);


                    //SetCheckedBoxChecked(_18commts, chk_18commts);
                    SetCheckedBoxChecked(_18actby, chk_18actby);
                    SetCheckedBoxChecked(_18actdt, chk_18actdt);
                    //SetCheckedBoxChecked(_18noof, chk_18noof);
                }
                else if (lblsch.Text == "19" || (lblprj.Text == "11784" && lblsch.Text == "40"))
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

                }
                else if (lblsch.Text == "20" || (lblsch.Text == "32" && lblprj.Text!="MOE" )|| (lblprj.Text == "11784" && lblsch.Text == "41"))
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


                }
                else if (lblsch.Text == "13" ||(lblprj.Text == "11784" && lblsch.Text == "36"))
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

                    //SetCheckedBoxChecked(_13commts, chk_13commts);
                    SetCheckedBoxChecked(_13actby, chk_13actby);
                    SetCheckedBoxChecked(_13actdt, chk_13actdt);
                    //SetCheckedBoxChecked(_13noof, chk_13noof);


                }
                else if (lblsch.Text == "22" || (lblprj.Text == "11784" && lblsch.Text == "43"))
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
                    
                    //SetCheckedBoxChecked(_22cit, chk_22cit);
                    //SetCheckedBoxChecked(_22apt, chk_22);
                    //SetCheckedBoxChecked(_13cvh, chk_13cvh);
                    //SetCheckedBoxChecked(_13ast, chk_13ast);
                    //SetCheckedBoxChecked(_13accept1, chk_13accept1);
                    //SetCheckedBoxChecked(_13filed1, chk_13filed1);

                    ////SetCheckedBoxChecked(_13commts, chk_13commts);
                    //SetCheckedBoxChecked(_13actby, chk_13actby);
                    //SetCheckedBoxChecked(_13actdt, chk_13actdt);
                    ////SetCheckedBoxChecked(_13noof, chk_13noof);
                }
                else if (lblsch.Text == "11" || (lblprj.Text == "11784" && lblsch.Text == "34"))
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
                else if (lblsch.Text == "12" || (lblprj.Text == "11784" && lblsch.Text == "35"))
                {
                    _12ct.Text = row[24].ToString();
                    _12accept1.Text = row["accept1"].ToString();
                    _12filed1.Text = row["filed1"].ToString();
                    _12commts.Text = row[18].ToString();
                    _12actby.Text = row[19].ToString();
                    _12actdt.Text = row[20].ToString();
                    _12nop.Text = row[21].ToString();

                    SetCheckedBoxChecked(_12ct, chk_12ct);
                    SetCheckedBoxChecked(_12accept1, chk_12accept1);
                    SetCheckedBoxChecked(_12filed1, chk_12filed1);

                    //SetCheckedBoxChecked(_12commts, chk_12commts);
                    SetCheckedBoxChecked(_12actby, chk_12actby);
                    SetCheckedBoxChecked(_12actdt, chk_12actdt);
                    // SetCheckedBoxChecked(_12nop, chk_12nop);
                }
                else if (lblsch.Text == "15")
                {
                    if (lblprj.Text == "OPH")
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


                    }
                    else
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
                    }

                }
                else if (lblsch.Text == "14" || (lblprj.Text == "11784" && lblsch.Text == "37"))
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
                else if (lblsch.Text == "23" || (lblprj.Text == "11784" && lblsch.Text == "44") || (lblprj.Text == "MOE" && lblsch.Text == "31"))
                {
                    _23tc.Text = row[24].ToString();
                    _23tpi.Text = row[25].ToString();
                    _23eml.Text = row[26].ToString();
                    _23pfm.Text = row[27].ToString();
                    _23lms.Text = row[28].ToString();
                    _23int.Text = row[29].ToString();
                    _23bfa.Text = row[30].ToString();
                    _23accept1.Text = row["accept1"].ToString();
                    _23filed1.Text = row["filed1"].ToString();
                    _23commts.Text = row[18].ToString();
                    _23actby.Text = row[19].ToString();
                    _23actdt.Text = row[20].ToString();
                }
                else if (lblsch.Text == "27" && lblprj.Text == "12761")
                {
                    _23tc.Text = row[24].ToString();
                    _23tpi.Text = row[25].ToString();
                    _23eml.Text = row[26].ToString();
                    _23pfm.Text = row[27].ToString();
                    _23lms.Text = row[28].ToString();
                    _23int.Text = row[29].ToString();
                    _23bfa.Text = row[30].ToString();
                    _23accept1.Text = row["accept1"].ToString();
                    _23filed1.Text = row["filed1"].ToString();
                    _23commts.Text = row[18].ToString();
                    _23actby.Text = row[19].ToString();
                    _23actdt.Text = row[20].ToString();
                }
                else if (lblsch.Text == "16")
                {

                    _16ir.Text = row[24].ToString();
                    _16ppt.Text = row[25].ToString();
                    _16cft.Text = row[26].ToString();
                    _16sop.Text = row[27].ToString();
                    _16ght.Text = row[28].ToString();
                    _16accept1.Text = row["accept1"].ToString();
                    _16filed1.Text = row["filed1"].ToString();
                    _16accept2.Text = row["accept2"].ToString();
                    _16filed2.Text = row["filed2"].ToString();
                    _16commts.Text = row[18].ToString();
                    _16actby.Text = row[19].ToString();
                    _16actdt.Text = row[20].ToString();

                    SetCheckedBoxChecked(_16ir, chk_16ir);
                    SetCheckedBoxChecked(_16ppt, chk_16ppt);
                    SetCheckedBoxChecked(_16cft, chk_16cft);
                    SetCheckedBoxChecked(_16sop, chk_16sop);
                    SetCheckedBoxChecked(_16ght, chk_16ght);
                    SetCheckedBoxChecked(_16accept1, chk_16accept1);
                    SetCheckedBoxChecked(_16filed1, chk_16filed1);
                    SetCheckedBoxChecked(_16accept2, chk_16accept2);
                    SetCheckedBoxChecked(_16filed2, chk_16filed2);

                    //SetCheckedBoxChecked(_16commts, chk_16commts);
                    SetCheckedBoxChecked(_16actby, chk_16actby);
                    SetCheckedBoxChecked(_16actdt, chk_16actdt);

                }
                else if (lblsch.Text == "24" || (lblsch.Text == "41" && lblprj.Text == "123") || (lblprj.Text == "11784" && lblsch.Text == "45")|| (lblprj.Text == "MOE" && lblsch.Text == "32"))
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
                  
                }
                else if (lblsch.Text == "30")
                {
                    _30pwron.Text = row[14].ToString();
                    _30pc1.Text = row[24].ToString();
                    _30co1.Text = row[25].ToString();
                    _30wd1.Text = row[26].ToString();
                    _30pc2.Text = row[27].ToString();
                    _30co2.Text = row[28].ToString();
                    _30wd2.Text = row[29].ToString();
                    _30idc.Text = row["test7"].ToString();
                    _30dlt.Text = row["test11"].ToString();
                    _30accept1.Text = row["accept1"].ToString();
                    _30filed1.Text = row["filed1"].ToString();
                    _30commts.Text = row[18].ToString();
                    _30actby.Text = row[19].ToString();
                    _30actdt.Text = row[20].ToString();
                }
                else if (lblsch.Text == "25")
                {
                    if (lblprj.Text == "SRH")
                    {
                        _25scit.Text = row[24].ToString();
                        _25sapt.Text = row[25].ToString();
                        _25sfat.Text = row[26].ToString();
                        //_25sacs.Text = row[27].ToString();
                        _25spft.Text = row[27].ToString();
                        _25sit.Text = row[28].ToString();
                        _25sphgt.Text = row[29].ToString();
                        _25saccept1.Text = row["accept1"].ToString();
                        _25sfiled1.Text = row["filed1"].ToString();
                        _25scommts.Text = row[18].ToString();
                        _25sactby.Text = row[19].ToString();
                        _25sactdt.Text = row[20].ToString();


                        _25snoof.Text = row["devices1"].ToString();

                    }
                    else
                    {
                        _25pwron.Text = row[14].ToString();
                        _25pc1.Text = row[24].ToString();
                        _25co1.Text = row[25].ToString();
                        _25wd1.Text = row[26].ToString();
                        _25pc2.Text = row[27].ToString();
                        _25co2.Text = row[28].ToString();
                        _25wd2.Text = row[29].ToString();
                        _25idc.Text = row["test7"].ToString();
                        _25accept1.Text = row["accept1"].ToString();
                        _25filed1.Text = row["filed1"].ToString();
                        _25commts.Text = row[18].ToString();
                        _25actby.Text = row[19].ToString();
                        _25actdt.Text = row[20].ToString();
                    }
                }
                else if (lblsch.Text == "26")
                {
                    _25pwron.Text = row[14].ToString();
                    _25pc1.Text = row[24].ToString();
                    _25co1.Text = row[25].ToString();
                    _25wd1.Text = row[26].ToString();
                    _25pc2.Text = row[27].ToString();
                    _25co2.Text = row[28].ToString();
                    _25wd2.Text = row[29].ToString();
                    _25idc.Text = row["test7"].ToString();
                    _25accept1.Text = row["accept1"].ToString();
                    _25filed1.Text = row["filed1"].ToString();
                    _25commts.Text = row[18].ToString();
                    _25actby.Text = row[19].ToString();
                    _25actdt.Text = row[20].ToString();
                    _26duty.Text = row["per_com4"].ToString();
                }
                else if (lblsch.Text == "27" && lblprj.Text != "12761")
                {
                    if (lblprj.Text == "OPH")
                    {

                        _27cit.Text = row["test1"].ToString();
                        _27dl.Text = row["test2"].ToString();
                        _27pm.Text = row["test3"].ToString();
                        _27ast.Text = row["test4"].ToString();
                        _27aptc.Text = row["test5"].ToString();


                        _27accept1.Text = row["accept1"].ToString();
                        _27filed1.Text = row["filed1"].ToString();


                        _27commts.Text = row[18].ToString();
                        _27actby.Text = row[19].ToString();
                        _27actdt.Text = row[20].ToString();

                    }
                    else
                    {
                        _25pwron.Text = row[14].ToString();
                        _25pc1.Text = row[24].ToString();
                        _25co1.Text = row[25].ToString();
                        _25wd1.Text = row[26].ToString();
                        _25pc2.Text = row[27].ToString();
                        _25co2.Text = row[28].ToString();
                        _25wd2.Text = row[29].ToString();
                        _25idc.Text = row["test7"].ToString();
                        _25accept1.Text = row["accept1"].ToString();
                        _25filed1.Text = row["filed1"].ToString();
                        _25commts.Text = row[18].ToString();
                        _25actby.Text = row[19].ToString();
                        _25actdt.Text = row[20].ToString();
                        _26duty.Text = row["per_com4"].ToString();
                    }
                }
                else if (lblsch.Text == "28")
                {
                    if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
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
                    else
                    {
                        _28idc.Text = row[24].ToString();
                        _28prc.Text = row[25].ToString();
                        _28sac.Text = row[26].ToString();
                        _28fit.Text = row[27].ToString();
                        _28wts.Text = row[28].ToString();
                        _28accept1.Text = row["accept1"].ToString();
                        _28filed1.Text = row["filed1"].ToString();
                        _28commts.Text = row[18].ToString();
                        _28actby.Text = row[19].ToString();
                        _28actdt.Text = row[20].ToString();
                    }
                }
                else if (lblsch.Text == "34" && lblprj.Text != "11784")
                {
                    _34mec.Text = row[24].ToString();
                    _34ele.Text = row[25].ToString();
                    _34fbs.Text = row[26].ToString();
                    _34bia.Text = row[27].ToString();
                    _34pft.Text = row[28].ToString();
                    _34epp.Text = row[29].ToString();
                    _34fct.Text = row[30].ToString();
                    _34prt.Text = row["test11"].ToString();
                    _34accept1.Text = row["accept1"].ToString();
                    _34filed1.Text = row["filed1"].ToString();
                    _34commts.Text = row[18].ToString();
                    _34actby.Text = row[19].ToString();
                    _34actdt.Text = row[20].ToString();
                }
                else if (lblsch.Text == "35" && lblprj.Text != "11784")
                {
                    _35mec.Text = row[24].ToString();
                    _35ele.Text = row[25].ToString();
                    _35fbs.Text = row[26].ToString();
                    _35bia.Text = row[27].ToString();
                    _35nlt.Text = row[28].ToString();
                    _35vit.Text = row[29].ToString();
                    _35aca.Text = row[30].ToString();
                    _35accept1.Text = row["accept1"].ToString();
                    _35filed1.Text = row["filed1"].ToString();
                    _35commts.Text = row[18].ToString();
                    _35actby.Text = row[19].ToString();
                    _35actdt.Text = row[20].ToString();
                }
                else if (lblsch.Text == "36")
                {
                    _36cpc.Text = row[24].ToString();
                    _36lpc.Text = row[25].ToString();
                    _36cbr.Text = row[26].ToString();
                    _36lbr.Text = row[27].ToString();
                    _36wcl.Text = row[28].ToString();
                    _36coa.Text = row[29].ToString();
                    _36lot.Text = row[30].ToString();
                    _36sls.Text = row["test11"].ToString();
                    _36fle.Text = row["test10"].ToString();
                    _36tsc.Text = row["test12"].ToString();
                    _36tpi.Text = row["test13"].ToString();
                    _36accept1.Text = row["accept1"].ToString();
                    _36filed1.Text = row["filed1"].ToString();
                    _36commts.Text = row[18].ToString();
                    _36actby.Text = row[19].ToString();
                    _36actdt.Text = row[20].ToString();
                }
                else if (lblsch.Text == "37" && lblprj.Text != "11784")
                {
                    _37iso.Text = row[14].ToString();
                    _37bc.Text = row[24].ToString();
                    _37bd.Text = row[25].ToString();
                    _37br.Text = row[26].ToString();
                    _37fn.Text = row[27].ToString();
                    _37accept.Text = row["accept1"].ToString();
                    _37filed.Text = row["filed1"].ToString();
                    _37commts.Text = row[18].ToString();
                    _37actby.Text = row[19].ToString();
                    _37actdt.Text = row[20].ToString();
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
        protected void _2btnupdate_Click(object sender, EventArgs e)
        {
            Update(_2pwron.Text, _2tor.Text, _2ir.Text, _2hi.Text, _2vt.Text, _2ct.Text, _2pi.Text, _2si.Text, _2cr.Text, "", _2fn.Text, _2pr.Text, _2cable.Text, "", "", "", "", "", _2accept1.Text, _2accept2.Text, _2filed1.Text, _2filed2.Text, _2commts.Text, _2actby.Text, _2actdt.Text);
            //if (_2accept1.Text.Length > 0 && _2accept2.Text.Length > 0)
            //{
            //    Update_AMSCheckDate();
            //}
            btnDummy_ModalPopupExtender1.Hide();
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
        protected void _2btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender1.Hide();
        }

        protected void _3btnupdate_Click(object sender, EventArgs e)
        {
            Update(_3pwron.Text, _3ir.Text, _3rt.Text, _3wr.Text, _3vg.Text, _3trf.Text, _3cable.Text, "", "", "", "", "", "", "", "", "", "", "", _3accept1.Text, _3accept2.Text, _3filed1.Text, _3filed2.Text, _3commts.Text, _3actby.Text, _3actdt.Text);
            //_3pwron.Text = ""; _3ir.Text = ""; _3rt.Text = ""; _3wr.Text = ""; _3vg.Text = ""; _3trf.Text = ""; _3cable.Text = ""; _3accept1.Text = ""; _3filed1.Text = ""; _3accept2.Text = ""; _3filed2.Text = ""; _3commts.Text = ""; _3actby.Text = ""; _3actdt.Text = "";
            btnDummy_ModalPopupExtender2.Hide();
        }

        protected void _3btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender2.Hide();
        }

        protected void _6btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _6ep.Text, _6accept1.Text, _6filed1.Text, "", "", _6be.Text, "", "", _6br.Text, "", "", "", _6accept3.Text, "", _6filed3.Text, _6lp.Text, "", _6accept2.Text, _6accept4.Text, _6filed2.Text, _6filed4.Text, _6commts.Text, _6actby.Text, _6actdt.Text);
            btnDummy_ModalPopupExtender3.Hide();
        }
        protected void _6btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender3.Hide();
        }
        protected void _5btnupdate_Click(object sender, EventArgs e)
        {
            Update(_5pwron.Text, _5tor.Text, _5ir.Text, _5pr.Text, _5si.Text, _5cr.Text, _5fn.Text, "", "", "", "", "", "", _5tc.Text, _5tl.Text, _5cc.Text, _5lc.Text, _5total.Text, _5accept1.Text, _5accept2.Text, _5filed1.Text, _5filed2.Text, _5commts.Text, _5actby.Text, _5actdt.Text);
            btnDummy_ModalPopupExtender4.Hide();
        }
        protected void _5btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender4.Hide();
        }

        protected void _4btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _4pc.Text, _4as.Text, _4lb.Text, _4accept1.Text, _4filed1.Text, _4cable.Text, _4sol.Text, "", "", "", "", "", "", "", "", "", "", _4accept2.Text, _4accept3.Text, _4filed2.Text, _4filed3.Text, _4commts.Text, _4actby.Text, _4actdt.Text);
            btnDummy_ModalPopupExtender5.Hide();
        }

        protected void _4btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender5.Hide();
        }

        protected void _7btnupdate_Click(object sender, EventArgs e)
        {
            //if (IsNumeric(_7cir.Text) == false && _7cir.Text != "N/A")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Continuity/IR Test Complete');", true);
            //    return;
            //}
            //else if (IsNumeric(_7add.Text) == false && _7add.Text != "N/A")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Adressing');", true);
            //    return;
            //}
            //else if (IsNumeric(_7ft.Text) == false && _7ft.Text != "N/A")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Fault Testing');", true);
            //    return;
            //}
            //else if (IsNumeric(_7co.Text) == false && _7co.Text != "N/A")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Change Over Test');", true);
            //    return;
            //}
            //else if (IsNumeric(_7ll.Text) == false && _7ll.Text != "N/A")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Lux Level Test');", true);
            //    return;
            //}
            //else if (IsNumeric(_7du.Text) == false && _7du.Text != "N/A")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Duration Test');", true);
            //    return;
            //}
            //else if (IsNumeric(_7pch.Text) == false && _7pch.Text != "N/A")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid PC Head End Test');", true);
            //    return;
            //}
            Update("", _7cir.Text, _7add.Text, _7ft.Text, _7co.Text, _7ll.Text, _7du.Text, _7pch.Text, "", "", "", "", "", "", "", "", "", _7noof.Text, _7accept1.Text, "", _7filed1.Text, "", _7commts.Text, _7actby.Text, _7actdt.Text);
            btnDummy_ModalPopupExtender6.Hide();
        }

        protected void _7btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender6.Hide();
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

        protected void _8btnupdate_Click(object sender, EventArgs e)
        {
            if (lblprj.Text == "CCAD")
                Update(_8pwron.Text, _8pc1.Text, _8co1.Text, _8wd1.Text, _8pc2.Text, _8co2.Text, _8wd2.Text, _8fpt.Text, _8arm.Text, _8pft.Text, "", "", "", _8ov.Text, "", "", "", "", _8accept1.Text, "", _8filed1.Text, "", _8commts.Text, _8actby.Text, _8actdt.Text);
            else
                Update(_8pwron.Text, _8pc1.Text, _8co1.Text, _8wd1.Text, _8pc2.Text, _8co2.Text, _8wd2.Text, "", "", "", "", "", "", "", "", "", "", "", _8accept1.Text, "", _8filed1.Text, "", _8commts.Text, _8actby.Text, _8actdt.Text);
            btnDummy_ModalPopupExtender7.Hide();
        }

        protected void _8btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender7.Hide();
        }

        protected void _21btnupdate_Click(object sender, EventArgs e)
        {
            Update(_21pwron.Text, _21pf.Text, _21fvr.Text, _21cc.Text, _21facc.Text, _21bfc.Text, _21fct.Text, "", "", "", "", "", "", "", "", "", "", "", _21accept1.Text, "", _21filed1.Text, "", _21commts.Text, _21actby.Text, _21actdt.Text);
            btnDummy_ModalPopupExtender8.Hide();
        }

        protected void _21btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender8.Hide();
        }
        protected void _9btnupdate_Click(object sender, EventArgs e)
        {
            Update(_9icom.Text, _9aa.Text, _9dtp.Text, _9rp.Text, _9moo.Text, _9sro.Text, _9est.Text, _9psrt.Text, "", "", "", "", "", "", "", "", "", "", _9accept1.Text, "", _9filed1.Text, "", _9commts.Text, _9actby.Text, _9actdt.Text);
            btnDummy_ModalPopupExtender9.Hide();
        }
        protected void _9btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender9.Hide();
        }

        protected void _17btnupdate_Click(object sender, EventArgs e)
        {
            Update(_17pwron.Text, _17pc1.Text, _17co1.Text, _17wd1.Text, _17pc2.Text, _17co2.Text, _17wd2.Text, "", "", "", "", "", "", "", "", "", "", "", _17accept1.Text, "", _17filed1.Text, "", _17commts.Text, _17actby.Text, _17actdt.Text);
            btnDummy_ModalPopupExtender10.Hide();
        }

        protected void _17btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender10.Hide();
        }

        protected void _18btnupdate_Click(object sender, EventArgs e)
        {
            if ((string)Session["cat"] == "FHR")
                Update(_18icom.Text, _18qt.Text, "N/A", "N/A", "N/A", "N/A", "N/A", _18wt.Text, "N/A", "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text);
            else if ((string)Session["cat"] == "ZCV")
                Update(_18icom.Text, "N/A", _18qt.Text, "N/A", "N/A", "N/A", "N/A", _18wt.Text, "N/A", "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text);
            else if ((string)Session["cat"] == "MOV")
                Update(_18icom.Text, "N/A", "N/A", _18qt.Text, "N/A", "N/A", "N/A", _18wt.Text, "N/A", "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text);
            else if ((string)Session["cat"] == "PRS")
                Update(_18icom.Text, "N/A", "N/A", "N/A", _18qt.Text, "N/A", "N/A", _18wt.Text, "N/A", "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text);
            else if ((string)Session["cat"] == "LGV")
                Update(_18icom.Text, "N/A", "N/A", "N/A", "N/A", _18qt.Text, "N/A", _18wt.Text, "N/A", "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text);
            else if ((string)Session["cat"] == "CSC")
                Update(_18icom.Text, "N/A", "N/A", "N/A", "N/A", "N/A", _18qt.Text, _18wt.Text, "N/A", "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text);
            else if ((string)Session["cat"] == "FHY")
                Update(_18icom.Text, "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", _18wt.Text, _18qt.Text, "", "", "", "", "", "", "", "", _18noof.Text, _18accept1.Text, "", _18filed1.Text, "", _18commts.Text, _18actby.Text, _18actdt.Text);
            btnDummy_ModalPopupExtender11.Hide();
        }

        protected void _18btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender11.Hide();
        }
        protected void drloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["loc"] = drloc.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text);
        }

        protected void _19btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _19rsit.Text, _19sac.Text, _19fbit.Text, _19wt.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", _19accept1.Text, "", _19filed1.Text, "", _19commts.Text, _19actby.Text, _19actdt.Text);
            btnDummy_ModalPopupExtender12.Hide();
        }

        protected void _19btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender12.Hide();
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
        protected void _20btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _20cit.Text, _20ppt.Text, _20cft.Text, _20sot.Text, _20ght.Text, _20lt.Text, _20accept1.Text, _20filed1.Text, "", "", "", "", "", "", "", "", "", _20accept2.Text, _20accept3.Text, _20filed2.Text, _20filed3.Text, _20commts.Text, _20actby.Text, _20actdt.Text);
            btnDummy_ModalPopupExtender14.Hide();
        }
        protected void _20btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender14.Hide();
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
        protected void _11btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _11cit.Text, _11lct.Text, _11apt.Text, _11phgt.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", _11accept1.Text, "", _11filed1.Text, "", _11commts.Text, _11actby.Text, _11actdt.Text);
            btnDummy_ModalPopupExtender17.Hide();
        }
        protected void _11btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender17.Hide();
        }

        protected void _12btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _12ct.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", _12nop.Text, _12accept1.Text, "", _12filed1.Text, "", _12commts.Text, _12actby.Text, _12actdt.Text);
            btnDummy_ModalPopupExtender18.Hide();
        }

        protected void _12btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender18.Hide();
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
        protected void _14btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _14cit.Text, _14diab.Text, _14avt.Text, _14drt.Text, "", "", "", "", "", "", "", "", "", "", "", "", _14noof.Text, _14accept1.Text, "", _14filed1.Text, "", _14commts.Text, _14actby.Text, _14actdt.Text);
            btnDummy_ModalPopupExtender20.Hide();
        }
        protected void _14btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender20.Hide();
        }

        protected void _23btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _23tc.Text, _23tpi.Text, _23eml.Text, _23pfm.Text, _23lms.Text, _23int.Text, _23bfa.Text, "", "", "", "", "", "", "", "", "", "", _23accept1.Text, "", _23filed1.Text, "", _23commts.Text, _23actby.Text, _23actdt.Text);
            btnDummy_ModalPopupExtender21.Hide();
        }

        protected void _23btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender21.Hide();
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

        protected void _16btnupdate_Click(object sender, EventArgs e)
        {
            if (IsNumeric(_16ir.Text) == false)
            {
                _16ir.Text = "0";
            }
            else if (IsNumeric(_16ppt.Text) == false)
            {
                _16ppt.Text = "0";
            }
            else if (IsNumeric(_16cft.Text) == false)
            {
                _16cft.Text = "0";
            }
            else if (IsNumeric(_16sop.Text) == false)
            {
                _16sop.Text = "0";
            }
            else if (IsNumeric(_16ght.Text) == false)
            {
                _16ght.Text = "0";
            }
            Update("", _16ir.Text, _16ppt.Text, _16cft.Text, _16sop.Text, _16ght.Text, "", "", "", "", "", "", "", "", "", "", "", "", _16accept1.Text, _16accept2.Text, _16filed1.Text, _16filed1.Text, _16commts.Text, _16actby.Text, _16actdt.Text);
            btnDummy_ModalPopupExtender22.Hide();
        }

        protected void _16btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender22.Hide();
        }

        protected void _24btnupdate_Click(object sender, EventArgs e)
        {
            Update(_24pwron.Text, _24ir.Text, _24ft.Text, _24it.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", _24accept1.Text, "", _24filed1.Text, "", _24commts.Text, _24actby.Text, _24actdt.Text);
            btnDummy_ModalPopupExtender23.Hide();
        }

        protected void _24btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender23.Hide();
        }

        protected void _30btnupdate_Click(object sender, EventArgs e)
        {
            Update(_30pwron.Text, _30pc1.Text, _30co1.Text, _30wd1.Text, _30pc2.Text, _30co2.Text, _30wd2.Text, _30idc.Text, _30dlt.Text, "", "", "", "", "", "", "", "", "", _30accept1.Text, "", _30filed1.Text, "", _30commts.Text, _30actby.Text, _30actdt.Text);
            btnDummy_ModalPopupExtender24.Hide();
        }

        protected void _30btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender24.Hide();
        }

        protected void _25btnupdate_Click(object sender, EventArgs e)
        {
            Update(_25pwron.Text, _25pc1.Text, _25co1.Text, _25wd1.Text, _25pc2.Text, _25co2.Text, _25wd2.Text, _25idc.Text, "", "", "", "", "", "", "", "", "", "", _25accept1.Text, "", _25filed1.Text, "", _25commts.Text, _25actby.Text, _25actdt.Text);
            btnDummy_ModalPopupExtender25.Hide();
        }

        protected void _25btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender25.Hide();
        }

        protected void _28btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _28idc.Text, _28prc.Text, _28sac.Text, _28fit.Text, _28wts.Text, "", "", "", "", "", "", "", "", "", "", "", "", _28accept1.Text, "", _28filed1.Text, "", _28commts.Text, _28actby.Text, _28actdt.Text);
            btnDummy_ModalPopupExtender26.Hide();
        }

        protected void _28btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender26.Hide();
        }

        protected void _34btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _34mec.Text, _34ele.Text, _34fbs.Text, _34bia.Text, _34pft.Text, _34epp.Text, _34fct.Text, _34prt.Text, "", "", "", "", "", "", "", "", "", _34accept1.Text, "", _34filed1.Text, "", _34commts.Text, _34actby.Text, _34actdt.Text);
            btnDummy_ModalPopupExtender27.Hide();
        }

        protected void _34btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender27.Hide();
        }

        protected void _35btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _35mec.Text, _35ele.Text, _35fbs.Text, _35bia.Text, _35nlt.Text, _35vit.Text, _35aca.Text, "", "", "", "", "", "", "", "", "", "", _35accept1.Text, "", _35filed1.Text, "", _35commts.Text, _35actby.Text, _35actdt.Text);
            btnDummy_ModalPopupExtender28.Hide();
        }

        protected void _35btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender28.Hide();
        }

        protected void _36btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _36cpc.Text, _36lpc.Text, _36cbr.Text, _36lbr.Text, _36wcl.Text, _36coa.Text, _36lot.Text, _36sls.Text, _36fle.Text, _36tsc.Text, _36tpi.Text, "", "", "", "", "", "", _36accept1.Text, "", _36filed1.Text, "", _36commts.Text, _36actby.Text, _36actdt.Text);
            btnDummy_ModalPopupExtender29.Hide();
        }

        protected void _36btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender29.Hide();
        }

        protected void _37btnupdate_Click(object sender, EventArgs e)
        {
            Update(_37iso.Text, _37bc.Text, _37bd.Text, _37br.Text, _37fn.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", _37accept.Text, "", _37filed.Text, "", _37commts.Text, _37actby.Text, _37actdt.Text);
            btnDummy_ModalPopupExtender30.Hide();
        }

        protected void _37btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender30.Hide();
        }

        protected void _3btnupdate_1_Click(object sender, EventArgs e)
        {
            Update(_3pwron_1.Text, _3ir_1.Text, _3rt_1.Text, _3mcbt.Text, _3vg_1.Text, _3trf_1.Text, _3cable_1.Text, _3mct.Text, "", "", "", "", "", "", "", "", "", "", _3accept1_1.Text, _3accept2_1.Text, _3filed1_1.Text, _3filed2_1.Text, _3commts_1.Text, _3actby_1.Text, _3actdt.Text);
            btnDummy_ModalPopupExtender2_1.Hide();
        }

        protected void _3btncancel_1_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender2_1.Hide();
        }
        protected void _25abtnupdate_Click(object sender, EventArgs e)
        {
            Update("", _25apfec.Text, _25amp.Text, _25aebt.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", _25afiled1.Text, "", _25acommts.Text, _25aactby.Text, _25aactdt.Text);
            btnDummy_ModalPopupExtender25a.Hide();
        }

        protected void _25abtncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender25a.Hide();
        }
        protected void _11cit_TextChanged(object sender, EventArgs e)
        {

        }
        protected void _26btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _26ct.Text, _26pct.Text, _26comm.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", _26accept1.Text, "", _26filed1.Text, "", _26commts.Text, _26actby.Text, _26actdt.Text);
            btnDummy_ModalPopupExtender26a.Hide();

        }

        protected void _26btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender26a.Hide();

        }
        protected void _15abtnupdate_Click(object sender, EventArgs e)
        {
            Update("", _15acit.Text, _15atht.Text, _15athtc.Text, _15afit.Text, _15afitc.Text, _15abat.Text, _15acet.Text, "", "", "", "", "", "", "", "", "", "", _15aaccept1.Text, _15aaccept2.Text, _15afiled1.Text, _15afiled2.Text, _15acommts.Text, _15aactby.Text, _15aactdt.Text);
            btnDummy_ModalPopupExtender15a.Hide();

        }

        protected void _15abtncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender15a.Hide();

        }
        protected void _27btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _27cit.Text, _27dl.Text, _27pm.Text, _27ast.Text, _27aptc.Text, "", "", "", "", "", "", "", "", "", "", "", "", _27accept1.Text, "", _27filed1.Text, "", _27commts.Text, _27actby.Text, _27actdt.Text);
            btnDummy_ModalPopupExtender27a.Hide();

        }

        protected void _27btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender27a.Hide();

        }

        protected void btnMVTestDataUpdate_Click(object sender, EventArgs e)
        {
            Update(txtPowerOnDate.Text, txtTorqueTest.Text, txtIRTest.Text, txtHiPotTest.Text, txtVTTest.Text, txtCTTest.Text, txtPrimInjTest.Text, txtSecInjTest.Text, txtDuctorTest.Text, "", txtFuncTest.Text, txtProtRelayTest.Text, txtCableIR.Text, txtTerTorTest.Text, txtCableTestComplete.Text, txtConsAccepted3.Text, txtTestSheetFiled3.Text, "", txtConsAccepted1.Text, txtConsAccepted2.Text, txtTestSheetFiled1.Text, txtTestSheetFiled2.Text, txtComments.Text, txtActionBy.Text, txtActionDate.Text);
            ModalPopupExtender_MVTestDataInput.Hide();
        }

        protected void btnMVTestDataCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtender_MVTestDataInput.Hide();
        }
        protected void _25sbtnupdate_Click(object sender, EventArgs e)
        {
            Update("", _25scit.Text, _25sapt.Text, _25sfat.Text, _25spft.Text, _25sit.Text, _25sphgt.Text,"", "", "", "", "", "", "", "", "", "", _25snoof.Text, _25saccept1.Text, "", _25sfiled1.Text, "", _25scommts.Text, _25sactby.Text, _25sactdt.Text);
            ModalPopupExtender_25SRH.Hide();

        }
        protected void _25sbtncancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtender_25SRH.Hide();    

        }

        
    }
}
