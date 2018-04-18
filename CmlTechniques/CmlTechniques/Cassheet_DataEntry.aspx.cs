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
using System.Data.SqlClient;
using System.Collections.Generic;
using AjaxControlToolkit;

namespace CmlTechniques
{
    public partial class Cassheet_DataEntry : System.Web.UI.Page
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
                lbluid.Text = (string)Session["uid"];
                string _prm = Request.QueryString[0].ToString();
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _prm + "');", true);
                lblprj.Text = _prm.Substring(0, _prm.IndexOf("_S"));
                if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s" || lblprj.Text == "AFV")
                {
                    Session["sch"] = _prm.Substring(_prm.IndexOf("_S") + 2, _prm.IndexOf("_D") - (_prm.IndexOf("_S") + 2));
                    lbldiv.Text = _prm.Substring(_prm.IndexOf("_D") + 2);
                }
                else if (lblprj.Text == "HMIM" || lblprj.Text == "14211" || lblprj.Text == "HMHS")
                {
                    Session["sch"] = _prm.Substring(_prm.IndexOf("_S") + 2, _prm.IndexOf("_F") - (_prm.IndexOf("_S") + 2));
                    lbldiv.Text = _prm.Substring(_prm.IndexOf("_F") + 2);
                }
                else
                    Session["sch"] = _prm.Substring(_prm.IndexOf("_S") + 2);
                lblsch.Text = (string)Session["sch"];
                if (lblprj.Text == "CCAD")
                {
                    if (lblsch.Text == "30" || lblsch.Text == "31" || lblsch.Text == "32" || lblsch.Text == "33" || lblsch.Text == "34" || lblsch.Text == "35" || lblsch.Text == "36" || lblsch.Text == "37" || lblsch.Text == "38" || lblsch.Text == "39" || lblsch.Text == "40")
                        Session["sch"] = "9";
                    else if (lblsch.Text == "85" || lblsch.Text == "86" || lblsch.Text == "87" || lblsch.Text == "88" || lblsch.Text == "89" || lblsch.Text == "90" || lblsch.Text == "91" || lblsch.Text == "99" || lblsch.Text == "108" || lblsch.Text == "107" || lblsch.Text == "117")
                        Session["sch"] = "17";
                    else if (lblsch.Text == "102")
                        Session["sch"] = "19";
                    else if (lblsch.Text == "100")
                        Session["sch"] = "28";
                    else if (lblsch.Text == "103" || lblsch.Text == "104" || lblsch.Text == "105" || lblsch.Text == "106" || lblsch.Text == "109" || lblsch.Text == "110" || lblsch.Text == "111")
                        Session["sch"] = "27";
                    else if (lblsch.Text == "112" || lblsch.Text == "113" || lblsch.Text == "114" || lblsch.Text == "115" || lblsch.Text == "116")
                        Session["sch"] = "112";
                }
                settings();
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
                if (lblprj.Text != "123")
                    btnaddm.Visible = false;
                _exp = false;

                if (lblprj.Text == "AFV") Set_Title();
            }
        }
        protected void load_cas_sys()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();
            if ((string)Session["sch"] == "112")
                _objcls.sch = Convert.ToInt32(lblsch.Text);
            else
                _objcls.sch = Convert.ToInt32((string)Session["sch"]);
            if (lblprj.Text == "CCAD")
            {
                if ((string)Session["sch"] == "17" || (lblprj.Text == "11784" && (string)Session["sch"] == "38"))
                    _objcls.sch = Convert.ToInt32(lblsch.Text);
            }
            DataTable _dt0 = _objbll.Load_cas_sys(_objcls, _objdb);
            DataTable _dt1 = new DataTable();
            _dt1.Columns.Add("_id");
            _dt1.Columns.Add("_name");
            var _List = from o in _dt0.AsEnumerable()
                        where o.Field<string>(3) == lblprj.Text
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
        private void Set_Title()
        {
            string _buildingName = "";
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.sch = Convert.ToInt32(lbldiv.Text);
            _buildingName = _objbll.Get_Building_Name(_objcls, _objdb);

            lblhead.Text = _buildingName + " - " + lblhead.Text;

        }
        protected void settings()
        {
            if ((string)Session["sch"] == "5" || (string)Session["sch"] == "1" || ((string)Session["sch"] == "44" && lblprj.Text != "11784") || (lblprj.Text == "11784" && (string)Session["sch"] == "28"))
            {
                lbnum.Text = "NO.OF CIRCUITS";
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                if (lblprj.Text == "CCAD")
                {
                    if ((string)Session["sch"] == "5")
                        lblhead.Text = "6.1.5 - LV Electrical Distribution (415V) Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "44")
                        lblhead.Text = "6.1.7 - Un-Interruptible Power Supplies/ Battery System Commissioning Activity Schedule";
                    lbl2.Text = "SUBSTATION NUMBER";
                    td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                }
                else
                {
                    if (lblprj.Text == "11784" && (string)Session["sch"] == "28")
                    {
                        lblhead.Text = "CAS E4 Electrical Services. LV Commissioning Activity Schedule - Marketing Suite";
                    }
                    else
                        lblhead.Text = "CAS E4 Electrical Services. LV Commissioning Activity Schedule";
                    td_2.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                }

            }
            else if ((string)Session["sch"] == "2" || (lblprj.Text == "11784" && (string)Session["sch"] == "25"))
            {
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "SUBSTATION";
                lbl3.Text = "FED FROM";
                txtnoof.Visible = false;
                if (lblprj.Text == "CCAD")
                {
                    if ((string)Session["sch"] == "121")
                        lblhead.Text = "6.1.2.1 - Switchgear Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "119")
                        lblhead.Text = "6.1.3.1 - Switchgear Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "118")
                        lblhead.Text = "6.1.4.1 - Switchgear Commissioning Activity Schedule";
                    td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                    txtnoof.Visible = true;
                    lbl2.Text = "SUBSTATION NUMBER";
                    lbnum.Text = "TOTAL NO.OF CIRCUITS";
                }
                else if (lblprj.Text == "HMIM")
                {
                    lbnum.Text = "NO. OF CABLES";
                    txtnoof.Visible = true;
                    lblhead.Text = "CAS E1 Electrical Services. HV-MV Switchgear & RMU Commissioning Activity Schedule";
                    td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                }
                else
                {
                    if (lblprj.Text == "11784" && (string)Session["sch"] == "25")
                    {
                        lblhead.Text = "CAS E1 Electrical Services. HV-MV Switchgear & RMU Commissioning Activity Schedule - Marketing Suite";
                    }
                    else
                        lblhead.Text = "CAS E1 Electrical Services. HV-MV Switchgear & RMU Commissioning Activity Schedule";
                    td_3.Visible = false; td_lbnum.Visible = false; td_txtnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                }
            }
            else if ((string)Session["sch"] == "121" || (string)Session["sch"] == "119" || (string)Session["sch"] == "118")
            {
                //lbnum.Text = "";
                //lbnum.Enabled = false;
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "SUBSTATION";
                lbl3.Text = "FED FROM";
                txtnoof.Visible = false;
                if (lblprj.Text == "CCAD")
                {
                    if ((string)Session["sch"] == "121")
                        lblhead.Text = "6.1.2.1 - Switchgear Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "119")
                        lblhead.Text = "6.1.3.1 - Switchgear Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "118")
                        lblhead.Text = "6.1.4.1 - Switchgear Commissioning Activity Schedule";
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
            else if ((string)Session["sch"] == "3" || (string)Session["sch"] == "120" || (lblprj.Text == "11784" && (string)Session["sch"] == "26"))
            {
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "AREA";
                lbl3.Text = "FED FROM";

                if (lblprj.Text == "CCAD")
                {
                    lbl2.Text = "SUB STATION NUMBER";
                    if ((string)Session["sch"] == "3")
                        lblhead.Text = "6.1.3.2 - Transformer Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "120")
                        lblhead.Text = "6.1.2.2 - Transformer Commissioning Activity Schedule";
                    lbnum.Text = "QUANTITY";
                }
                else
                {
                    if (lblprj.Text == "11784" && (string)Session["sch"] == "26")
                    {
                        lblhead.Text = "CAS E2 Electrical Services. HV & MV Transformers Commissioning Activity Schedule - Marketing Suite";
                    }
                    else
                        lblhead.Text = "CAS E2 Electrical Services. HV & MV Transformers Commissioning Activity Schedule";
                    txtnoof.Visible = false;
                    td_3.Visible = false; td_lbnum.Visible = false; td_txtnum.Visible = false;
                }
                td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
            }
            else if ((string)Session["sch"] == "4" || (lblprj.Text == "11784" && (string)Session["sch"] == "27"))
            {
                lbnum.Text = "";
                lbl1.Text = "PROVIDES POWER TO";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                td_2.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_lbnum.Visible = false; td_txtdes.Visible = false; td_txtnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                if (lblprj.Text == "CCAD")
                    lblhead.Text = "6.1.4.2 - Generator Commissioning Activity Schedule";
                else if (lblprj.Text == "11784" && (string)Session["sch"] == "27")
                {
                    lblhead.Text = "CAS E5 Electrical Services. Generator Commissioning Activity Schedule - Marketing Suite";
                }
                else
                    lblhead.Text = "CAS E5 Electrical Services. Generator Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "6" || (lblprj.Text == "11784" && (string)Session["sch"] == "29"))
            {
                lbnum.Text = "";
                lbl1.Text = "PROVIDES EARTHING/LIGHTNING PROTECTION TO";
                lbl2.Text = "";
                lbl3.Text = "";
                txtfedfr.Visible = false;
                txtdesc.Visible = false;
                txtnoof.Visible = false;
                drfed.Style.Add("display", "none");
                if (lblprj.Text == "CCAD")
                {
                    lblhead.Text = "6.1.1 - Earthing and Lightning Protection Commissioning Activity Schedule";
                    lbl1.Text = "PROVIDES EARTHING TO";
                }
                else if (lblprj.Text == "11784" && (string)Session["sch"] == "29")
                {
                    lblhead.Text = "CAS E3 Electrical Services. Earthing & Lightning Protection Commissioning Activity Schedule - Marketing Suite";
                }
                else
                    lblhead.Text = "CAS E3 Electrical Services. Earthing & Lightning Protection Commissioning Activity Schedule";
                td_2.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_lbnum.Visible = false; td_txtdes.Visible = false; td_txtnum.Visible = false; td_1.Visible = false; td_txtfed.Visible = false; td_lbl3.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
            }
            else if ((string)Session["sch"] == "7" || (lblprj.Text == "11784" && (string)Session["sch"] == "30"))
            {
                lbnum.Text = "NO.OF EMERGENCY LIGHTS";
                lbl1.Text = "";
                lbl3.Text = "";
                lbl2.Text = "NO.OF CIRCUITS";

                if (lblprj.Text == "CCAD")
                {
                    lbl1.Text = "PROVIDES POWER TO";
                    lbl3.Text = "FED FROM";
                    lbnum.Text = "NO.OF LAMPS";
                    lbl2.Text = "TOTAL NO.OF CIRCUITS";
                    lblhead.Text = "6.1.6 - Central Battery Emergency Lighting Commissioning Activity Schedule";
                    td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                }
                else if (lblprj.Text == "ASAO")
                {
                    drfed.Style.Add("display", "none");
                    lblhead.Text = "CAS E6 Electrical Services. Emergency Lighting Commissioning Activity Schedule";
                    td_1.Visible = false; td_txtfed.Visible = false; td_lbl3.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                }
                else
                {
                    drfed.Style.Add("display", "none");
                    if (lblprj.Text == "11784" && (string)Session["sch"] == "30")
                    {
                        lblhead.Text = "CAS E6 Electrical Services. Emergency Lighting Commissioning Activity Schedule - Marketing Suite";
                    }
                    else
                        lblhead.Text = "CAS E6 Electrical Services. Emergency Lighting Commissioning Activity Schedule";
                    td_2.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_1.Visible = false; td_txtfed.Visible = false; td_lbl3.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                }
            }
            else if ((string)Session["sch"] == "8" || (string)Session["sch"] == "51" || (string)Session["sch"] == "52" || (string)Session["sch"] == "53" || (string)Session["sch"] == "54" || (string)Session["sch"] == "55" || (string)Session["sch"] == "56" || (string)Session["sch"] == "57" || (string)Session["sch"] == "58" || (string)Session["sch"] == "59" || (string)Session["sch"] == "60" || (string)Session["sch"] == "62" || (string)Session["sch"] == "61" || (string)Session["sch"] == "63" || (string)Session["sch"] == "64" || (string)Session["sch"] == "65" || (string)Session["sch"] == "66" || (string)Session["sch"] == "67" || (string)Session["sch"] == "68" || (string)Session["sch"] == "69" || (string)Session["sch"] == "70" || (string)Session["sch"] == "71" || (string)Session["sch"] == "72" || (string)Session["sch"] == "73" || (string)Session["sch"] == "74" || (string)Session["sch"] == "75" || (string)Session["sch"] == "76" || (string)Session["sch"] == "77" || (string)Session["sch"] == "78" || (string)Session["sch"] == "79" || (string)Session["sch"] == "80" || (string)Session["sch"] == "81" || (string)Session["sch"] == "82" || (string)Session["sch"] == "83" || (string)Session["sch"] == "84" || (lblprj.Text == "11784" && (string)Session["sch"] == "31"))
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                txtpprovideto.Visible = false;
                txtnoof.Visible = false;
                if (lblprj.Text == "ASAO")
                {
                    lblhead.Text = "CAS M9 Fuel Systems Commissioning Activity Schedule";
                    td_0.Visible = false; td_txtnum.Visible = false; td_lbnum.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                }
                else if (lblprj.Text == "CCAD")
                {
                    if ((string)Session["sch"] == "8")
                        lblhead.Text = "6.3.1 - Chilled Water System Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "51")
                        lblhead.Text = "6.3.2 - Hot Water System (MTHW) Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "52")
                        lblhead.Text = "6.3.3 - Heat Recovery and Terminal Reheat Systems Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "53")
                        lblhead.Text = "6.3.4 - Generator Cooling Radiator System Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "54")
                        lblhead.Text = "6.3.5 - Steam System Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "55")
                        lblhead.Text = "6.3.6 - Air Handling Systems Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "56")
                        lblhead.Text = "6.3.7 - Ventilation Systems Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "57")
                        lblhead.Text = "6.3.8 - Fan Coil Units Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "58")
                        lblhead.Text = "6.3.9 - Close Control Air Condition Units Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "59")
                        lblhead.Text = "6.3.10 - Life Safety Ventilation Systems Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "60")
                        lblhead.Text = "6.3.11 - Clean Room Systems Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "61")
                        lblhead.Text = "6.3.6.1 - VAV Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "63")
                        lblhead.Text = "6.3.6.1.1 - CUP - HVAC Systems 1-14 Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "64")
                        lblhead.Text = "6.3.6.1.2 - CLINIC - HVAC Systems 15 Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "65")
                        lblhead.Text = "6.3.6.1.3 - D&T - HVAC Systems 16&17 Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "66")
                        lblhead.Text = "6.3.6.1.4 - D&T - HVAC Systems 17&18 Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "67")
                        lblhead.Text = "6.3.6.1.5 - ICU - HVAC Systems 20 Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "68")
                        lblhead.Text = "6.3.6.1.6 - SWING WING - HVAC Systems 21 Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "69")
                        lblhead.Text = "6.3.6.1.7 - PATIENT TOWER - HVAC Systems 22 Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "70")
                        lblhead.Text = "6.3.6.1.8 - PATIENT TOWER - HVAC Systems 23 Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "71")
                        lblhead.Text = "6.3.6.1.9 - PATIENT TOWER - HVAC Systems 26&27 Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "72")
                        lblhead.Text = "6.3.6.1.10 - CAR PARK Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "73")
                        lblhead.Text = "6.3.6.1.11 - MISC Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "74")
                        lblhead.Text = "6.3.6.2.1 - CUP - HVAC Systems 1-14 Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "75")
                        lblhead.Text = "6.3.6.2.2 - CLINIC - HVAC Systems 15 Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "76")
                        lblhead.Text = "6.3.6.2.3 - D&T - HVAC Systems 16&17 Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "77")
                        lblhead.Text = "6.3.6.2.4 - D&T - HVAC Systems 17&18 Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "78")
                        lblhead.Text = "6.3.6.2.5 - ICU - HVAC Systems 20 Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "79")
                        lblhead.Text = "6.3.6.2.6 - SWING WING - HVAC Systems 21 Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "80")
                        lblhead.Text = "6.3.6.2.7 - PATIENT TOWER - HVAC Systems 22 Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "81")
                        lblhead.Text = "6.3.6.2.8 - PATIENT TOWER - HVAC Systems 23 Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "82")
                        lblhead.Text = "6.3.6.2.9 - PATIENT TOWER - HVAC Systems 26&27 Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "83")
                        lblhead.Text = "6.3.6.2.10 - CAR PARK Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "84")
                        lblhead.Text = "6.3.6.2.11 - MISC Commissioning Activity Schedule";

                    td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                    lbnum.Text = "Design Volume (l/s)";
                    txtnoof.Visible = true;
                }
                else
                {
                    if (lblprj.Text == "11784" && (string)Session["sch"] == "31")
                    {
                        lblhead.Text = "CAS M1 Mechanical Services Commissioning Activity Schedule - Marketing Suite";
                    }
                    else
                        lblhead.Text = "CAS M1 Mechanical Services Commissioning Activity Schedule";
                    td_0.Visible = false; td_txtnum.Visible = false; td_lbnum.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                }


            }

            else if ((string)Session["sch"] == "24" || ((string)Session["sch"] == "41" && lblprj.Text == "123") || (lblprj.Text == "11784" && (string)Session["sch"] == "45") || (lblprj.Text == "MOE" && (string)Session["sch"] == "32"))
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";

                if (lblprj.Text == "ASAO")
                {
                    lblhead.Text = "CAS MISC3 - Kitchen Equipments Commissioning Activity Schedule";
                    td_0.Visible = false; td_txtnum.Visible = false; td_lbnum.Visible = false; txtnoof.Visible = false;
                    td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                }
                else if (lblprj.Text == "CCAD")
                {
                    lbl3.Text = "AREA COVERED";
                    lbnum.Text = "NO.OF PANEL";
                    lblhead.Text = "6.2.11 - Nurse Call and Blue Code System  Commissioning Activity Schedule";
                    td_txtdescr.Visible = false; td_lbldes.Visible = false; tddes.Visible = false;
                    td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                }
                else if (lblprj.Text == "11736")
                {
                    lblhead.Text = "CAS - Sump Pits Commissioning Activity Schedule";
                    td_0.Visible = false; td_txtnum.Visible = false; td_lbnum.Visible = false; txtnoof.Visible = false;
                    td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                }
                else if (lblprj.Text == "NCP")
                {
                    lbl1.Text = "";
                    lbl2.Text = "";
                    lbl3.Text = "CONNECTED FROM";
                    lbnum.Text = "NO.OF POINTS";
                    lblhead.Text = "CAS ELV10 Directory Network Enabled Commissioning Activity Schedule";

                    td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                    td_txtdes.Visible = false;
                    td_lbl2.Visible = false; td_2.Visible = false;
                    //td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false;
                }
                else
                {
                    if ((lblprj.Text == "11784" && (string)Session["sch"] == "45"))
                    {
                        lblhead.Text = "CAS MISC2 - Kitchen & Laundry Equipments Commissioning Activity Schedule - Marketing Suite";
                    }
                    else
                        lblhead.Text = "CAS MISC2 - Kitchen & Laundry Equipments Commissioning Activity Schedule";
                    td_0.Visible = false; td_txtnum.Visible = false; td_lbnum.Visible = false; txtnoof.Visible = false;
                    td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false; td_3.Visible = false;
                }
                td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false;
            }
            else if ((string)Session["sch"] == "25")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                txtpprovideto.Visible = false;
                if (lblprj.Text == "CCAD")
                {
                    lblhead.Text = "6.2.13 - Master Clock Systems Commissioning Activity Schedule";
                    lbnum.Text = "NO.OF CODE BLUE/ ELAPSED TIMERS";
                    td_txtdescr.Visible = false; td_lbldes.Visible = false; tddes.Visible = false; td_lbl3.Visible = false; td_txtfed.Visible = false; td_1.Visible = false;
                }
                else if (lblprj.Text == "OPH" || lblprj.Text == "PCD")
                {
                    lblhead.Text = "CAS E7 Integrated System Testing Commissioning Activity Schedule";
                    td_0.Visible = false; td_txtnum.Visible = false; td_lbnum.Visible = false; txtnoof.Visible = false; td_txtdescr.Visible = false; td_lbldes.Visible = false; tddes.Visible = false; td_lbl3.Visible = false; td_txtfed.Visible = false; td_1.Visible = false;

                }
                else
                {
                    lblhead.Text = "CAS M2 Air Conditioned System Commissioning Activity Schedule";
                    td_0.Visible = false; td_txtnum.Visible = false; td_lbnum.Visible = false; txtnoof.Visible = false;

                }
                td_lbl1.Visible = false; td_txtppt.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "17" || (lblprj.Text == "11784" && (string)Session["sch"] == "38"))
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                txtpprovideto.Visible = false;
                if (lblprj.Text == "CCAD")
                {
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
                    else if (lblsch.Text == "108")
                        lblhead.Text = "6.5.6 - Irrigation System Commissioning Activity Schedule";
                    else if (lblsch.Text == "117")
                        lblhead.Text = "6.7.1 - Solar Hot Water System Commissioning Activity Schedule";
                    lbnum.Text = "DESIGN VOLUME l/s";
                }
                else
                {
                    if (lblprj.Text == "11784" && (string)Session["sch"] == "38")
                    {
                        lblhead.Text = "CAS PH1 Public Health Services Commissioning Activity Schedule - Marketing Suite";
                    }
                    else
                        lblhead.Text = "CAS PH1 Public Health Services Commissioning Activity Schedule";
                    td_txtnum.Visible = false; td_lbnum.Visible = false; td_3.Visible = false;
                }

                td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "27" && lblprj.Text != "12761")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                txtpprovideto.Visible = false;
                if (lblprj.Text == "CCAD")
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
                    lbnum.Text = "NO.OF POINTS";
                    td_lbl3.Visible = false; td_txtfed.Visible = false; td_1.Visible = false;
                }
                else if (lblprj.Text == "12761")
                {
                    lblhead.Text = "Lifts & Escalators Commissioning Activity Schedule";
                    lbnum.Text = "NO.OF POINTS";
                    td_lbl3.Visible = false; td_txtfed.Visible = false; td_1.Visible = false;
                }
                else if (lblprj.Text == "OPH" || lblprj.Text == "PCD")
                {
                    lblhead.Text = "CAS ELV8 PAVA System Commissioning Activity Schedule";
                    td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false;
                    td_txtppt.Visible = false;
                    td_0.Visible = false;
                    td_txtdescr.Visible = false; td_lbldes.Visible = false; tddes.Visible = false;
                    lbloc.Text = "AREA COVERED";
                    td_lbnum.Visible = false; td_txtnum.Visible = false; td_3.Visible = false;
                }
                else if (lblprj.Text == "HMIM" || lblprj.Text == "OCEC")
                {

                    lblhead.Text = "CAS MISC1 - Horizontal & Vertical Transportation Systems Commissioning Activity Schedule";
                    td_3.Visible = false; td_lbnum.Visible = false; td_txtnum.Visible = false;
                    td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false;
                    td_txtdescr.Visible = false; td_lbldes.Visible = false; tddes.Visible = false;

                    lbl2.Text = ""; lbl1.Text = ""; lbl2.Text = ""; lbnum.Text = "";

                }
                else
                {
                    lblhead.Text = "CAS M6 Fire Fighting Pumps Commissioning Activity Schedule";
                    td_0.Visible = false; td_txtnum.Visible = false; td_lbnum.Visible = false;
                }

                td_lbl1.Visible = false; td_txtppt.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "27" && lblprj.Text == "12761")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                lbnum.Text = "";
                lblhead.Text = "CAS MISC2 Conveying Systems Commissioning Activity Schedule";
                td_3.Visible = false; td_lbnum.Visible = false; td_txtnum.Visible = false;
                td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false;

                td_lbl2.Visible = false; td_2.Visible = false; td_txtdes.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
            }
            else if ((string)Session["sch"] == "112")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                txtpprovideto.Visible = false;
                if (lblprj.Text == "CCAD")
                {
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
                }

                td_lbl3.Visible = true; td_1.Visible = false;

                td_lbl3.Visible = true; txtfedfr.Visible = true; td_txtfed.Visible = true;

                txtpprovideto.Visible = false; td_txtppt.Visible = false;
                td_txtppt.Visible = false; td_lbl1.Visible = false; td_lbl2.Visible = false;

                td_0.Visible = false; td_2.Visible = false;
                td_1.Visible = false; td_lbnum.Visible = false;

                txtdesc.Visible = false; td_txtdes.Visible = false;
                txtnoof.Visible = false; td_txtnum.Visible = false;


            }
            else if ((string)Session["sch"] == "46")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                txtpprovideto.Visible = false;
                if (lblprj.Text == "CCAD")
                {
                    lblhead.Text = "6.2.12 - Car Park Management and Vehicle Intrusion Defence Commissioning Activity Schedule";
                    lbnum.Text = "NO.OF POINTS";
                    td_lbl3.Visible = false; td_txtfed.Visible = false; td_1.Visible = false;
                }
                td_lbl1.Visible = false; td_txtppt.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "9" || (lblprj.Text == "11784" && (string)Session["sch"] == "32"))
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "";

                if (lblprj.Text == "CCAD")
                {
                    if (lblsch.Text == "30")
                        lblhead.Text = "CAS 2B MFSD > CUP - HVAC Systems 1-14 Testing Commissioning Activity Schedule";
                    else if (lblsch.Text == "31")
                        lblhead.Text = "CAS 2B MFSD > CLINIC - HVAC Systems 15 Testing Commissioning Activity Schedule";
                    else if (lblsch.Text == "32")
                        lblhead.Text = "CAS 2B MFSD > CLINIC - HVAC Systems 16&17 Testing Commissioning Activity Schedule";
                    else if (lblsch.Text == "33")
                        lblhead.Text = "CAS 2B MFSD > CLINIC - HVAC Systems 17&18 Testing Commissioning Activity Schedule";
                    else if (lblsch.Text == "34")
                        lblhead.Text = "CAS 2B MFSD > ICU - HVAC Systems 20 Testing Commissioning Activity Schedule";
                    else if (lblsch.Text == "35")
                        lblhead.Text = "CAS 2B MFSD > SWING WING - HVAC Systems 21 Testing Commissioning Activity Schedule";
                    else if (lblsch.Text == "36")
                        lblhead.Text = "CAS 2B MFSD > PATIENT TOWER -  HVAC Systems 22 Testing Commissioning Activity Schedule";
                    else if (lblsch.Text == "37")
                        lblhead.Text = "CAS 2B MFSD > PATIENT TOWER - HVAC Systems 23 Testing Commissioning Activity Schedule";
                    else if (lblsch.Text == "38")
                        lblhead.Text = "CAS 2B MFSD > PATIENT TOWER - HVAC Systems 26&27 Testing Commissioning Activity Schedule";
                    else if (lblsch.Text == "39")
                        lblhead.Text = "CAS 2B MFSD > CAR PARK Testing Commissioning Activity Schedule";
                    else if (lblsch.Text == "40")
                        lblhead.Text = "CAS 2B MFSD > MISC Testing Commissioning Activity Schedule";
                    td_txtnum.Visible = false; td_lbnum.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                    lbdes.Text = "DESCRIPTION/ SIZE";
                    lbloc.Text = "LOCATION AREA";
                    lbl3.Text = "ROOM REFERENCE";
                    lbl1.Text = "PLANT/ SYSTEM DESCRIPTION";

                }
                else if (lblprj.Text == "HMIM")
                {

                    lbl3.Text = "FED FROM";
                    lblhead.Text = "CAS M3 Fusible Link Fire Dampers & MSFD Commissioning Activity Schedule";
                    td_0.Visible = false; td_txtnum.Visible = false; td_lbnum.Visible = false; td_lbl1.Visible = false;
                    td_txtppt.Visible = false; td_3.Visible = false;
                    td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                }
                else
                {

                    if (lblprj.Text == "11784" && (string)Session["sch"] == "32")
                    {
                        lblhead.Text = "CAS M3 Fusible Link Fire Dampers & MSFD Commissioning Activity Schedule - Marketing Suite";
                    }
                    else
                        lblhead.Text = "CAS M3 Fusible Link Fire Dampers & MSFD Commissioning Activity Schedule";
                    td_0.Visible = false; td_txtnum.Visible = false; td_lbnum.Visible = false;
                    td_lbl1.Visible = false; td_txtppt.Visible = false;
                    td_1.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;

                    if (lblprj.Text != "NBO")
                    {
                        drfed.Style.Add("display", "none");
                        td_3.Visible = false; td_txtfed.Visible = false; td_lbl3.Visible = false;
                    }
                    else
                    {
                        lbl3.Text = "FED FROM";
                    }
                }
            }
            else if ((string)Session["sch"] == "10" || (lblprj.Text == "11784" && (string)Session["sch"] == "33"))
            {
                lbl1.Text = "";
                lbl2.Text = "NO.OF DEVICES";
                lbl3.Text = "";
                lbnum.Text = "NO.OF INTERFACES";
                drfed.Style.Add("display", "none");
                if (lblprj.Text == "CCAD")
                {
                    lblhead.Text = "6.2.1 - Fire Alarm and Fire Telephone Communication System Commissioning Activity Schedule";
                    lbl1.Text = "LOOP CIRCUIT NO.";
                    td_lbl3.Visible = false; td_txtfed.Visible = false; td_1.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false; td_lbldes.Visible = false;
                }
                else if (lblprj.Text == "HMIM" || lblprj.Text == "14211" || lblprj.Text == "HMHS")
                {
                    lbl3.Text = "FED FROM";
                    if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                        lblhead.Text = "6.2.1 -Fire Alarm and Fire Telephone Communication System Commissioning Activity Schedule";
                    else
                        lblhead.Text = "CAS ELV1 - Fire Alarm & Voice Evacuation Commissioning Activity Schedule";
                    lbl1.Text = "LOOP CIRCUIT NO.";
                    drfed.Style.Add("display", "block");
                    td_txtdescr.Visible = false; tddes.Visible = false; td_lbldes.Visible = false;
                    td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false;

                }
                else
                {
                    if (lblprj.Text == "11784" && (string)Session["sch"] == "33")
                    {
                        lblhead.Text = "CAS ELV1 Fire Alarm & Voice Evacuation Commissioning Activity Schedule - Marketing Suite";
                    }
                    else
                        lblhead.Text = "CAS ELV1 Fire Alarm & Voice Evacuation Commissioning Activity Schedule";
                    td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false;
                    td_lbl3.Visible = false; td_txtfed.Visible = false; td_1.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false; td_lbldes.Visible = false;
                }

            }
            else if ((string)Session["sch"] == "31" && lblprj.Text != "MOE")
            {
                if (lblprj.Text == "CCAD")
                {
                    lbl1.Text = "";
                    lbl2.Text = "DESCRIPTION";
                    lbl3.Text = "";
                    lblhead.Text = "CAS 2B MFSD > CLINIC - HVAC Systems 15 Testing Commissioning Activity Schedule";
                    td_txtnum.Visible = false; td_lbnum.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                    lbdes.Text = "DESCRIPTION/ SIZE";
                    lbloc.Text = "LOCATION AREA";
                    lbl3.Text = "ROOM REFERENCE";
                    lbl1.Text = "PLANT/ SYSTEM DESCRIPTION";
                }
                else if (lblprj.Text == "14211")
                {
                    lbl1.Text = "";
                    lbl2.Text = "";
                    lbl3.Text = "";
                    lblhead.Text = "CAS ELV 12 - Computing & Data Storage Systems Commissioning Activity Schedule";
                    td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                    td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false;
                    lbdes.Text = "ROON NO.";
                    lbloc.Text = "LOCATION";
                    lbl3.Text = "CONNECTED FROM";
                    lbnum.Text = "NO.OF EQUIPMENTS";
                }
                else
                {
                    lbl1.Text = "";
                    lbl2.Text = "NO.OF DEVICES";
                    lbl3.Text = "";
                    lbnum.Text = "NO.OF INTERFACES";
                    drfed.Style.Add("display", "none");
                    lblhead.Text = "CAS ELV1 PABGM Commissioning Activity Schedule";
                    td_lbl3.Visible = false; td_txtfed.Visible = false; td_1.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                }
            }
            else if ((string)Session["sch"] == "11" || (lblprj.Text == "11784" && (string)Session["sch"] == "34"))
            {
                lbloc.Text = "AREA SERVED";
                lbl2.Text = "NO.OF CIRCUITS";
                lbnum.Text = "NO.OF LIGHTING SCENES";
                drfed.Style.Add("display", "none");

                td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false;
                td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;

                if (lblprj.Text == "CCAD")
                {
                    lblhead.Text = "6.2.10 - Public Address and Mass Notification System Commissioning Activity Schedule";
                    lbloc.Text = "LOCATION";
                    lbnum.Text = "NO.OF DEVICES PER CIRCUIT";
                    td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                    td_lbl3.Visible = false; td_txtfed.Visible = false; td_1.Visible = false;
                }
                else if (lblprj.Text == "14211" || lblprj.Text == "HMIM")
                {
                    lbl3.Text = "FED FROM";
                    lblhead.Text = "CAS ELV5 - Lighting Control System Commissioning Activity Schedule";
                    drfed.Style.Add("display", "block");
                    //td_txtdescr.Visible = false; tddes.Visible = false; td_lbldes.Visible = false;

                }
                else
                {
                    if (lblprj.Text == "11784" && (string)Session["sch"] == "34")
                    {
                        lblhead.Text = "CAS ELV5 Lighting Control System Commissioning Activity Schedule - Marketing Suite";
                    }
                    else
                        lblhead.Text = "CAS ELV5 Lighting Control System Commissioning Activity Schedule";

                    td_lbl3.Visible = false;
                    td_txtfed.Visible = false;
                    td_1.Visible = false;
                }

            }
            else if ((string)Session["sch"] == "12" || (lblprj.Text == "11784" && (string)Session["sch"] == "35"))
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "CONNECTED FROM";
                lbnum.Text = "NO.OF POINTS";
                if (lblprj.Text == "ASAO")
                    lblhead.Text = "CAS ELV6 Passive Data Network Commissioning Activity Schedule";
                else if (lblprj.Text == "CCAD")
                    lblhead.Text = "6.2.9 - Voice/ Data Commissioning Activity Schedule";
                else if (lblprj.Text == "11784" && (string)Session["sch"] == "35")
                    lblhead.Text = "CAS ELV6 Structured Cabling Network Commissioning Activity Schedule - Marketing Suite";
                else
                    lblhead.Text = "CAS ELV6 Structured Cabling Network Commissioning Activity Schedule";

                td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                td_txtdes.Visible = false;
                td_lbl2.Visible = false; td_2.Visible = false;

                if (lblprj.Text == "14211")
                {

                    lbl1.Text = "FED FROM";
                    lbl3.Text = "CONNECTED TO";
                    lblhead.Text = "CAS ELV8 - Information & Communication Technology (ICT) Commissioning Activity Schedule";
                }
                else if (lblprj.Text == "HMIM")
                {

                    lbl1.Text = "FED FROM";
                    //lbl3.Text = "CONNECTED FROM";
                    lblhead.Text = "CAS ELV 6 - Structured Cabling Network Commissioning Activity Schedule";
                }
                else
                {
                    td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false;

                }
            }
            else if ((string)Session["sch"] == "13" || (lblprj.Text == "11784" && (string)Session["sch"] == "36"))
            {


                drfed.Style.Add("display", "none");
                if (lblprj.Text == "CCAD")
                {
                    lblhead.Text = "6.2.6 - Closed Circuit Television(CCTV) Commissioning Activity Schedule";
                    lbl3.Text = "AREA MONITORED";
                    lbnum.Text = "NO.OF POINTS/ CAMERAS";
                }
                else if (lblprj.Text == "14211" || lblprj.Text == "HMIM" || lblprj.Text == "NCP")
                {
                    if (lblprj.Text == "14211")
                        lblhead.Text = "CAS ELV3 - Visual Security Systems Commissioning Activity Schedule";
                    else
                        lblhead.Text = "CAS ELV 3 - CCTV Commissioning Activity Schedule";

                    drfed.Style.Add("display", "block");
                    lbl3.Text = "FED FROM";
                    lbloc.Text = "SYSTEMS MONITORED";
                    lbnum.Text = "NO.OF CAMERAS";
                }
                else
                {
                    if (lblprj.Text == "11784" && (string)Session["sch"] == "36")
                    {
                        lblhead.Text = "CAS ELV3 Closed Circuit Television Commissioning Activity Schedule - Marketing Suite ";
                    }
                    else
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


                //td_lbl3.Visible = false;
                //td_txtfed.Visible = false;
                //td_1.Visible = false;



            }
            else if ((string)Session["sch"] == "14" || (lblprj.Text == "11784" && (string)Session["sch"] == "37"))
            {

                drfed.Style.Add("display", "none");

                if (lblprj.Text == "CCAD")
                {
                    lblhead.Text = "6.2.15 - Audio Visual System (AV) Commissioning Activity Schedule";
                    lbnum.Text = "NO.OF CIRCUITS";
                }
                else if (lblprj.Text == "HMIM")
                {
                    lblhead.Text = "CAS ELV8 - Audio-Visual Intercom Commissioning Activity Schedule";
                    lbl3.Text = "FED FROM";
                    lbnum.Text = "NO.OF PANELS";
                    td_lbl1.Visible = false;
                    td_txtppt.Visible = false;
                    td_0.Visible = false;
                    td_lbl0.Visible = false;
                    td_txtloc.Visible = false;
                    td0.Visible = false;
                    td_lbl2.Visible = false;
                    td_2.Visible = false;
                    td_txtdes.Visible = false;
                    td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                }
                else
                {
                    if (lblprj.Text == "11784" && (string)Session["sch"] == "37")
                    {
                        lblhead.Text = "CAS ELV8 Audio-Visual Intercom Commissioning Activity Schedule - Marketing Suite";
                    }
                    else
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

                if (lblprj.Text == "CCAD")
                {
                    lblhead.Text = "6.2.14 - Master Antenna Television System (MATV) Commissioning Activity Schedule";
                    lbnum.Text = "NO.OF POINTS PER OUTLET";
                    lbl1.Text = "AREA COVERED";
                    lbl3.Text = "FED FROM";
                    td_lbl2.Visible = false;
                    td_2.Visible = false;
                    td_txtdes.Visible = false;
                    drloc.Style.Add("display", "none");
                }
                else if (lblprj.Text == "OPH" || lblprj.Text == "PCD")
                {
                    lblhead.Text = "CAS ELV1a VESDA System Commissioning Activity Schedule";
                    td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false;
                    lbl2.Text = "NO.OF DEVICES";
                    lbnum.Text = "NO.OF INTERFACES";
                    td_lbl1.Visible = false;
                    td_txtppt.Visible = false;
                    td_0.Visible = false;
                    td_lbl3.Visible = false;
                    td_txtfed.Visible = false;
                    td_1.Visible = false;
                }
                else if (lblprj.Text == "HMIM")
                {
                    lblhead.Text = " CAS ELV 7 - Guest Room Management System Commissioning Activity Schedule";
                    lbl3.Text = "FED FROM";
                    td_lbl1.Visible = false;
                    td_txtppt.Visible = false;
                    td_0.Visible = false;
                    td_lbl0.Visible = false;
                    td_txtloc.Visible = false;
                    td0.Visible = false;
                    td_lbl2.Visible = false;
                    td_2.Visible = false;
                    td_txtdes.Visible = false;
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
                    td_lbl2.Visible = false;
                    td_2.Visible = false;
                    td_txtdes.Visible = false;
                    drloc.Style.Add("display", "none");
                }
                td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;




            }
            else if ((string)Session["sch"] == "16")
            {
                lbl3.Text = "FED FROM";
                if (lblprj.Text == "CCAD")
                {
                    lblhead.Text = "6.2.8 - Intercom Systems ( Audio, Video, and Healthcare) Commissioning Activity Schedule";
                    lbl1.Text = "AREA COVERED";
                    lbnum.Text = "NO.OF VIDEO STATION";
                    td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                }
                else
                {
                    if (lblprj.Text == "NCP")
                    {
                        lblhead.Text = "CAS ELV9 - Car Park Management System Commissioning Activity Schedule";
                    }
                    else
                        lblhead.Text = "CAS ELV9 - ELV System Commissioning Activity Schedule";

                    lbnum.Text = "NO.OF DEVICES REQ'D CALIBRATION";
                    lbl1.Text = "SYSTEM CONTROLLED/ MONITORED";
                    lbl2.Text = "NO.OF POINTS";

                    if (lblprj.Text == "AFV")
                    {
                        lbnum.Text = "";
                        lbl1.Text = "Connected Devices / Equipment";
                        lbl2.Text = "NO.OF  Equipment / Devices";
                        td_lbnum.Visible = false; td_txtnum.Visible = false;td_3.Visible = false;
                    }
                }
                td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
            }
            else if ((string)Session["sch"] == "18" || (lblprj.Text == "11784" && (string)Session["sch"] == "39"))
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "";
                lbnum.Text = "QUANTITY";
                drfed.Style.Add("display", "none");
                if (lblprj.Text == "11784" && (string)Session["sch"] == "39")
                {
                    lblhead.Text = "CAS PH2 Fire Protection Services  Commissioning Activity Schedule - Marketing Suite";
                }
                else
                    lblhead.Text = "CAS PH2 Fire Protection Services  Commissioning Activity Schedule";
                td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_txtfed.Visible = false; td_lbl3.Visible = false; td_1.Visible = false; td0.Visible = false; td_txtloc.Visible = false; td_lbl0.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "29")
            {
                if (lblprj.Text == "CCAD")
                {
                    lblhead.Text = "6.2.7 - Lighting Control Systems Commissioning Activity Schedule";
                    lbnum.Text = "NO. OF CHANNELS/ MODULES";
                    lbl3.Text = "AREA COVERED";
                    td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                }
                else if (lblprj.Text == "14211")
                {

                    lbnum.Text = "NO.OF EQUIPMENTS";
                    lblloc.Text = "LOCATION";
                    lbl1.Text = "";
                    lbl3.Text = "";
                    lbl2.Text = "";
                    drfed.Style.Add("display", "none");

                    lblhead.Text = "CAS ELV9- IPTV System Commissioning Activity Schedule";
                    td_2.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_1.Visible = false;
                    td_txtfed.Visible = false; td_lbl3.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false;
                    td_0.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;

                }
                else
                {
                    lbl1.Text = "";
                    lbl2.Text = "DESCRIPTION";
                    lbl3.Text = "";
                    lbnum.Text = "QUANTITY";
                    lblhead.Text = "CAS M8 Fire Protection Services  Commissioning Activity Schedule";
                    td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_txtfed.Visible = false; td_lbl3.Visible = false; td_1.Visible = false; td0.Visible = false; td_txtloc.Visible = false; td_lbl0.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                }
            }
            else if ((string)Session["sch"] == "19" || (lblprj.Text == "11784" && (string)Session["sch"] == "40"))
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";

                if (lblprj.Text == "CCAD")
                {
                    lblhead.Text = "6.4.10.2 - Fire Protection Distribution Systems Commissioning Activity Schedule";
                    td_lbl0.Visible = false; td0.Visible = false; td_txtloc.Visible = false; drloc.Visible = false; td_lbl3.Visible = false; td_1.Visible = false; td_txtfed.Visible = false;
                    lbnum.Text = "QUANTITY";
                }
                else
                {
                    if (lblprj.Text == "11784" && (string)Session["sch"] == "40")
                    {
                        lblhead.Text = "CAS PH3 Fire Extinguishing Systems Commissioning Activity Schedule  - Marketing Suite";
                    }
                    else
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
                if (lblprj.Text == "CCAD")
                {
                    lblhead.Text = "6.4.16 - Pneumatic Tube System Commissioning Activity Schedule";
                    td_txtnum.Visible = false; td_lbnum.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                    lbdes.Text = "DESCRIPTION";
                    lbloc.Text = "LOCATION";
                    lbl3.Text = "FED FROM (System Component)";
                    lbl1.Text = "FED FROM (Electrical)";
                }
                else if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                {
                    lbl2.Text = "NO.OF DEVICES";
                    //lbl3.Text = "";
                    lbnum.Text = "NO.OF INTERFACES";
                    //drfed.Style.Add("display", "none");
                    lblhead.Text = "CAS ELV10 Public Address System Commissioning Activity Schedule";
                    td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false;
                    td_txtnum.Visible = true;
                    td_3.Visible = true;

                    td_txtdescr.Visible = false;
                    tddes.Visible = false;
                    td_lbldes.Visible = false;
                }
                else if (lblprj.Text == "14211")
                {

                    lbnum.Text = "NO.OF EQUIPMENTS";
                    lbl3.Text = "";
                    drfed.Style.Add("display", "none");

                    lblhead.Text = "CAS ELV6 Audio Visual System Commissioning Activity Schedule";
                    td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_lbl2.Visible = false;
                    td_2.Visible = false; td_3.Visible = false;
                    //td_lbnum.Visible = false; td_txtnum.Visible = false;
                    td_txtdes.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;

                    td_lbl3.Visible = false; td_txtfed.Visible = false; td_1.Visible = false;



                }
                else
                {
                    //if (lblprj.Text == "OPH" || lblprj.Text == "PCD" || lblprj.Text == "ARSD")
                    //{
                    //    lblhead.Text = "CAS MISC1 - Horizontal & Vertical Transportation Systems Commissioning Activity Schedule";
                    //}
                    //else
                    //{
                    //    lblhead.Text = "CAS M7 Fire Extinguishing Systems Commissioning Activity Schedule";
                    //}

                    lblhead.Text = "CAS MISC1 - Horizontal & Vertical Transportation Systems Commissioning Activity Schedule";

                    td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_lbl2.Visible = false; td_2.Visible = false; td_3.Visible = false; td_lbnum.Visible = false; td_txtnum.Visible = false; td_txtdes.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                }

            }
            else if ((string)Session["sch"] == "20" || (lblprj.Text == "11784" && (string)Session["sch"] == "41"))
            {
                lbl1.Text = "NO.OF POINTS";
                lbl2.Text = "NO.OF DEVICES REQUIRED CALIBRATION";
                lbl3.Text = "SYSTEM CONTROLLED/ MONITORED BY DDC";
                lbnum.Text = "NO.OF SYSTEM REQUIRED LOOP TUNING";
                drfed.Style.Add("display", "none");
                if (lblprj.Text == "CCAD")
                {
                    lblhead.Text = "6.2.2 - Energy Management and Control Systems (EMCS) Commissioning Activity Schedule";
                    lbnum.Text = "NO.OF POINTS";
                    lbl3.Text = "SYSTEM CONTROLLED/ MONITORED";
                    td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                }
                else
                {
                    if (lblprj.Text == "11784" && (string)Session["sch"] == "41")
                    {
                        lblhead.Text = "CAS ELV2 Building Management System Commissioning Activity Schedule - Marketing Suite ";
                    }
                    else
                        lblhead.Text = "CAS ELV2 Building Management System Commissioning Activity Schedule";
                }
                td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
            }
            else if ((string)Session["sch"] == "32")
            {
                if (lblprj.Text == "CCAD")
                {
                    lbl1.Text = "";
                    lbl2.Text = "DESCRIPTION";
                    lbl3.Text = "";
                    lblhead.Text = "CAS 2B MFSD > CLINIC - HVAC Systems 16&17 Testing Commissioning Activity Schedule";
                    td_txtnum.Visible = false; td_lbnum.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                    lbdes.Text = "DESCRIPTION/ SIZE";
                    lbloc.Text = "LOCATION AREA";
                    lbl3.Text = "ROOM REFERENCE";
                    lbl1.Text = "PLANT/ SYSTEM DESCRIPTION";
                }
                else if (lblprj.Text == "14211")
                {
                    lbnum.Text = "NO.OF POINTS";
                    lbl1.Text = "";
                    lbl3.Text = "";
                    lbl2.Text = "";
                    drfed.Style.Add("display", "none");

                    lblhead.Text = "CAS ELV 10 - GSM & TETRA Commissioning Activity Schedule";
                    td_2.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_1.Visible = false;
                    td_txtfed.Visible = false; td_lbl3.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false;
                    td_0.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;

                }
                else
                {
                    lbl1.Text = "NO.OF POINTS";
                    lbl2.Text = "NO.OF DEVICES REQUIRED CALIBRATION";
                    lbl3.Text = "SYSTEM CONTROLLED/ MONITORED BY DDC";
                    lbnum.Text = "NO.OF SYSTEM REQUIRED LOOP TUNING";
                    drfed.Style.Add("display", "none");
                    lblhead.Text = "CAS ELV2 SCADA Commissioning Activity Schedule";
                    td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                }
            }
            else if ((string)Session["sch"] == "21" || (lblprj.Text == "11784" && (string)Session["sch"] == "42"))
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "";
                lbnum.Text = "FLUSHING STAGE";
                txtpprovideto.Visible = false;
                if (lblprj.Text == "ASAO")
                    lblhead.Text = "CAS M4 Flushing Commissioning Activity Schedule";
                else if (lblprj.Text == "11784" || lblsch.Text == "42")
                    lblhead.Text = "CAS M4 Flushing Commissioning Activity Schedule  - Marketing Suite";
                else
                    lblhead.Text = "CAS M2 Flushing Commissioning Activity Schedule";
                td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false; td_lbl3.Visible = false; td_txtfed.Visible = false; td_1.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
            }
            else if ((string)Session["sch"] == "22" || (lblprj.Text == "11784" && (string)Session["sch"] == "43"))
            {
                if (lblprj.Text == "CCAD")
                {
                    lblhead.Text = "6.2.5 - Access Control Systems(ACS) Incorporating Intruder Detection System (IDS) Commissioning Activity Schedule";
                    lbnum.Text = "NO.OF POINTS";
                    lbl3.Text = "AREA COVERED";
                }
                else if (lblprj.Text == "14211")
                {
                    lbl3.Text = "FED FROM";
                    lblhead.Text = "CAS ELV4 - Security & Access Control Systems Commissioning Activity Schedule";
                    lbloc.Text = "DOORS MONITORED / CONTROLLED";
                    lbnum.Text = "NO.OF ACCESS CONTROLLED DOORS";

                }
                else if (lblprj.Text == "OPH" || lblprj.Text == "PCD")
                {

                    lbl2.Text = "FED FROM";
                    lblhead.Text = "CAS ELV 4 - Access Control System Commissioning Activity Schedule";
                    lbloc.Text = "SYSTEMS MONITORED";
                    lbnum.Text = "NO.OF ACCESS CONTROLLED DOORS";

                    td_lbl3.Visible = false;
                    td_txtfed.Visible = false;
                    td_1.Visible = false;

                }
                else
                {
                    if (lblprj.Text == "11784" && (string)Session["sch"] == "43")
                    {
                        lblhead.Text = "CAS ELV4 Access Control System Commissioning Activity Schedule - Marketing Suite";
                    }
                    else
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

                if (lblprj.Text != "OPH" && lblprj.Text != "PCD")
                {
                    td_lbl2.Visible = false;
                    td_txtdes.Visible = false;
                    td_2.Visible = false;
                }
            }
            else if ((string)Session["sch"] == "23" || (lblprj.Text == "11784" && (string)Session["sch"] == "44") || (lblprj.Text == "MOE" && (string)Session["sch"] == "31"))
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                lbnum.Text = "";
                if (lblprj.Text == "ASAO")
                {
                    lblhead.Text = "CAS MISC2 Conveying Systems Commissioning Activity Schedule";
                    td_3.Visible = false; td_lbnum.Visible = false; td_txtnum.Visible = false;
                    td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false;
                }
                else if (lblprj.Text == "11784" || lblprj.Text == "MOE")
                {
                    if ((string)Session["sch"] == "44")
                    {
                        lblhead.Text = "CAS MISC1  Lift & Conveying Systems Commissioning Activity Schedule - Marketing Suite";
                    }
                    else if ((string)Session["sch"] == "31")
                    {
                        lblhead.Text = "CAS MISC1 - Horizontal & Vertical Transportation Systems Commissioning Activity Schedule";
                    }
                    else
                        lblhead.Text = "CAS MISC1  Lift & Conveying Systems Commissioning Activity Schedule";
                    td_3.Visible = false; td_lbnum.Visible = false; td_txtnum.Visible = false;
                    td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false;
                }
                else if (lblprj.Text == "CCAD")
                {
                    lbl3.Text = "GATEWAY/ LOOP";
                    lbl1.Text = "SYSTEM MONITORED";
                    lbnum.Text = "NO.OF IED DEVICE";
                    lblhead.Text = "6.2.4 - Power Management and Control Systems (PMCS) Commissioning Activity Schedule";
                }
                else
                {
                    lblhead.Text = "CAS MISC1 Lifts & Escalators Commissioning Activity Schedule";
                    td_3.Visible = false; td_lbnum.Visible = false; td_txtnum.Visible = false;
                    td_0.Visible = false; td_lbl1.Visible = false; td_txtppt.Visible = false;
                }

                td_lbl2.Visible = false; td_2.Visible = false; td_txtdes.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
            }
            else if ((string)Session["sch"] == "34" || (string)Session["sch"] == "35" || (string)Session["sch"] == "36")
            {
                if (lblprj.Text == "CCAD")
                {
                    lbl1.Text = "";
                    lbl2.Text = "DESCRIPTION";
                    lbl3.Text = "";
                    if ((string)Session["sch"] == "34")
                        lblhead.Text = "CAS 2B MFSD > ICU - HVAC Systems 20 Testing Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "35")
                        lblhead.Text = "CAS 2B MFSD > SWING WING - HVAC Systems 21 Testing Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "36")
                        lblhead.Text = "CAS 2B MFSD > PATIENT TOWER - HVAC Systems 22 Testing Commissioning Activity Schedule";
                    td_txtnum.Visible = false; td_lbnum.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                    lbdes.Text = "DESCRIPTION/ SIZE";
                    lbloc.Text = "LOCATION AREA";
                    lbl3.Text = "ROOM REFERENCE";
                    lbl1.Text = "PLANT/ SYSTEM DESCRIPTION";
                }
                else if (lblprj.Text == "14211" && (string)Session["sch"] == "34")
                {
                    lbloc.Text = "LOCATION";
                    lbl3.Text = "FED FROM";
                    lbl1.Text = "PROVIDES POWER TO";
                    lblhead.Text = "CAS E7 Electrical Services.  UPS & CHARGER Commissioning Activity Schedule";

                    td_lbl2.Visible = false; td_2.Visible = false; td_3.Visible = false;
                    td_lbnum.Visible = false; td_txtnum.Visible = false; td_txtdes.Visible = false;
                    td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                }
                else if (lblprj.Text == "14211" && (string)Session["sch"] == "35")
                {
                    lbl1.Text = "";
                    lbl2.Text = "DESCRIPTION";
                    lbl3.Text = "FED FROM";
                    txtpprovideto.Visible = false;
                    txtnoof.Visible = false;

                    lblhead.Text = "CAS Fuel System Services Commissioning Activity Schedule";
                    td_0.Visible = false; td_txtnum.Visible = false; td_lbnum.Visible = false; td_lbl1.Visible = false;
                    td_txtppt.Visible = false; td_3.Visible = false; td_lbl2.Visible = false;
                    td_txtdes.Visible = false; td_2.Visible = false;
                }
                else
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
            }
            else if ((string)Session["sch"] == "30")
            {
                if (lblprj.Text == "CCAD")
                {
                    lbl1.Text = "";
                    lbl2.Text = "DESCRIPTION";
                    lbl3.Text = "";
                    lblhead.Text = "CAS 2B MFSD > CUP - HVAC Systems 1-14 Testing Commissioning Activity Schedule";
                    td_txtnum.Visible = false; td_lbnum.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                    lbdes.Text = "DESCRIPTION/ SIZE";
                    lbloc.Text = "LOCATION AREA";
                    lbl3.Text = "ROOM REFERENCE";
                    lbl1.Text = "PLANT/ SYSTEM DESCRIPTION";
                }
                else if (lblprj.Text == "14211")
                {
                    lbl1.Text = "";
                    lbl2.Text = "";
                    lbl3.Text = "";
                    lblhead.Text = "CAS ELV7 - Voice Communication System Commissioning Activity Schedule";
                    td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                    td_lbl1.Visible = false; td_txtppt.Visible = false; td_0.Visible = false;
                    lbdes.Text = "ROON NO.";
                    lbloc.Text = "LOCATION";
                    lbl3.Text = "CONNECTED FROM";
                    lbnum.Text = "NO.OF EQUIPMENTS";
                }
                else
                {
                    lbl1.Text = "NO.GRILLES";
                    lbl2.Text = "NO.VAV";
                    lbl3.Text = "FED FROM";
                    lbnum.Text = "NO.CAV'S";
                    lblhead.Text = "CAS M1 Ducted Fan Systems Commissioning Activity Schedule";
                }


            }
            else if ((string)Session["sch"] == "26")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                lbnum.Text = "NO.OF VALVE SETS";
                if (lblprj.Text == "CCAD")
                {
                    lblhead.Text = "CAS 3M - ELV - Intercom & Healthcare Communications and Monitoring(IHCM) System Commissioning Activity Schedule";
                    td_lbnum.Visible = false; td_txtnum.Visible = false; td_3.Visible = false; td_lbl3.Visible = false; td_txtfed.Visible = false; td_1.Visible = false; td_txtdescr.Visible = false; td_lbldes.Visible = false; tddes.Visible = false;
                }
                else if (lblprj.Text == "OPH" || lblprj.Text == "PCD")
                {
                    lblhead.Text = "CAS ELV7 - Leak Detection System Commissioning Activity Schedule";
                    lbnum.Text = "NO OF POINTS/ DETECTION";
                    lbl3.Text = "CONNECTED FROM";
                    td_txtdescr.Visible = false; td_lbldes.Visible = false; tddes.Visible = false;
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
            else if ((string)Session["sch"] == "37" && lblprj.Text != "11784")
            {
                if (lblprj.Text == "CCAD")
                {
                    lbl1.Text = "";
                    lbl2.Text = "DESCRIPTION";
                    lbl3.Text = "";
                    lblhead.Text = "CAS 2B MFSD > PATIENT TOWER - HVAC Systems 23 Testing Commissioning Activity Schedule";
                    td_txtnum.Visible = false; td_lbnum.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                    lbdes.Text = "DESCRIPTION/ SIZE";
                    lbloc.Text = "LOCATION AREA";
                    lbl3.Text = "ROOM REFERENCE";
                    lbl1.Text = "PLANT/ SYSTEM DESCRIPTION";
                }
                else if (lblprj.Text == "14211")
                {
                    lbnum.Text = "NO. DEVICES TESTED";
                    lbloc.Text = "LOCATION";
                    lbl1.Text = "DEVICE TYPE";
                    lbl3.Text = "ROOM NO";
                    lbl2.Text = "FED FROM";

                    lblhead.Text = "CAS SAS 1 - Special Airport System Commissioning Activity Schedule";

                    td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;

                }
                else
                {
                    lbnum.Text = "";
                    lbl1.Text = "PROVIDES POWER TO";
                    lbl2.Text = "";
                    lbl3.Text = "FED FROM";
                    td_2.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_lbnum.Visible = false; td_txtdes.Visible = false; td_txtnum.Visible = false; td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                    lblhead.Text = "CAS Electrical Services Commissioning Activity Schedule (Battery Charger)";
                }
            }
            else if ((string)Session["sch"] == "33" || (string)Session["sch"] == "38" || (string)Session["sch"] == "39" || (string)Session["sch"] == "40")
            {
                if (lblprj.Text == "CCAD")
                {
                    lbl1.Text = "";
                    lbl2.Text = "DESCRIPTION";
                    lbl3.Text = "";
                    if ((string)Session["sch"] == "33")
                        lblhead.Text = "CAS 2B MFSD > CLINIC - HVAC Systems 17&18 Testing Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "38")
                        lblhead.Text = "CAS 2B MFSD > PATIENT TOWER - HVAC Systems 26&27 Testing Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "39")
                        lblhead.Text = "CAS 2B MFSD > CAR PARK Testing Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "40")
                        lblhead.Text = "CAS 2B MFSD > MISC Testing Commissioning Activity Schedule";
                    td_txtnum.Visible = false; td_lbnum.Visible = false; td_3.Visible = false; td_lbl2.Visible = false; td_txtdes.Visible = false; td_2.Visible = false;
                    lbdes.Text = "DESCRIPTION/ SIZE";
                    lbloc.Text = "LOCATION AREA";
                    lbl3.Text = "ROOM REFERENCE";
                    lbl1.Text = "PLANT/ SYSTEM DESCRIPTION";
                }
                else if (lblprj.Text == "14211" && (string)Session["sch"] == "33")
                {
                    lbnum.Text = "NO.OF POINTS";
                    lbloc.Text = "LOCATION";
                    lbl1.Text = "CONNECTED TO";
                    lbl3.Text = "FED FROM";
                    lbl2.Text = "";

                    lblhead.Text = "CAS ELV 11- Master Clock System Commissioning Activity Schedule";
                    td_2.Visible = false; td_lbl2.Visible = false;
                    td_txtdes.Visible = false;

                    td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;

                }
                else if (lblprj.Text == "14211" && (string)Session["sch"] == "39")
                {
                    lbnum.Text = "NO. DEVICES";
                    lbloc.Text = "LOCATION";
                    lbl1.Text = "DEVICE TYPE";
                    lbl3.Text = "ROOM NO";
                    lbl2.Text = "FED FROM";

                    lblhead.Text = "CAS ELV 13- Car Park Management System Commissioning Activity Schedule";

                    td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;

                }
            }
            else if ((string)Session["sch"] == "45" || (string)Session["sch"] == "47" || (string)Session["sch"] == "48" || (string)Session["sch"] == "49" || (string)Session["sch"] == "50")
            {
                if (lblprj.Text == "CCAD")
                {
                    if ((string)Session["sch"] == "45")
                        lblhead.Text = "6.2.3 - CO Monitoring and Car Park Ventilation Controls Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "47")
                        lblhead.Text = "6.2.16 - Fuel Leak Monitoring and Water Leak Detection Systems Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "48")
                        lblhead.Text = "6.2.17 - Drug/ Blood Refrigerator Alarm Systems Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "49")
                        lblhead.Text = "6.2.18 - Mortuary Refrigeration and Alarm Systems Commissioning Activity Schedule";
                    else if ((string)Session["sch"] == "50")
                        lblhead.Text = "6.2.19 - Medical Alarm Systems- O2, N2O, Gas Evacuation, Medical Air, Medical Vacuum  Commissioning Activity Schedule";
                    lbnum.Text = "NO.OF POINTS";
                    lbl3.Text = "AREA COVERED";
                }
                td_lbldes.Visible = false; td_txtdescr.Visible = false; tddes.Visible = false;
                td_lbl1.Visible = false;
                td_txtppt.Visible = false;
                td_0.Visible = false;
                td_lbl2.Visible = false;
                td_txtdes.Visible = false;
                td_2.Visible = false;
            }

            //Added to get the CAS header for Fountain View Project
            if (lblprj.Text == "AFV")
            {
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcls = new _clscassheet();
                _objcls.sch = Convert.ToInt32((string)Session["sch"]);
                lblhead.Text = _objbll.LoadCASHeader(_objcls, _objdb);

                //if (lblhead.Text.Contains("MISC2") || lblhead.Text.Contains("MISC3") || lblhead.Text.Contains("MISC4") || lblhead.Text.Contains("MISC5") || lblhead.Text.Contains("MISC6"))
                //{

                //    td_0.Visible = false; td_lbl0.Visible = true;
                //    td_txtnum.Visible = false; td_lbnum.Visible = false; txtnoof.Visible = false;
                //    td_lbl2.Visible = false; td_txtdes.Visible = false; td_txtppt.Visible = false;
                //    td_3.Visible = false; td_2.Visible = false;
                //    td_lbl1.Visible = false;
                //    td_txtloc.Visible = true;
                //    td_lbldes.Visible = true; td_txtdescr.Visible = true; tddes.Visible = true;

                //    lbl1.Text = "";

                //    if (lblhead.Text.Contains("MISC2") || lblhead.Text.Contains("MISC3") || lblhead.Text.Contains("MISC5"))
                //    {
                //        td_1.Visible = true;
                //        td_txtfed.Visible = true; td_lbl3.Visible = true;
                //        lbl3.Text = "FED FROM";
                //    }
                //    else
                //    {
                //        td_1.Visible = false;
                //        td_txtfed.Visible = false; td_lbl3.Visible = false;
                //        lbl3.Text = "";
                //        lbdes.Text = "ROOM NO.";
                //    }
                //}
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
            if (lblprj.Text == "HMIM" || lblprj.Text == "14211" || lblprj.Text == "HMHS" || lblprj.Text == "AFV")
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
            //}


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
                //_mydetails.Style.Add("display", "none");
                _btn.Text = "+";
            }
        }
        private void Open_Details(int mode)
        {
            string sys = "";
            if (mode == 1)
                sys = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));
            else
                sys = (string)Session["Sys"];
            for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            {
                Label _sys_id = (Label)mymaster.Rows[i].FindControl("lbSys_Id");
                if (_sys_id.Text == sys)
                {
                    GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
                    Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
                    _mydetails.Visible = true;
                    //_mydetails.Style.Add("display", "block");
                    _btn.Text = "-";
                }
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
                //_mydetails.Style.Add("display", "block");
                _btn.Text = "-";
            }
            else if (_btn.Text == "-")
            {
                _mydetails.Visible = false;
                //_mydetails.Style.Add("display", "none");
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
            btnDummy_ModalPopupExtender.Show();
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
                lblref.Text = row[4].ToString();
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

            if ((string)Session["sch"] == "1" || (string)Session["sch"] == "5" || (string)Session["sch"] == "44" || (lblprj.Text == "11784" && (string)Session["sch"] == "28"))
            {
                if (lblprj.Text == "CCAD")
                {
                    lb2.Text = lbl2.Text;
                }
                else
                {
                    lb2.Visible = false;
                    uplb2.Visible = false;
                }
                lb1.Text = lbl1.Text;
                lb3.Text = lbl3.Text;
                lb4.Text = lbnum.Text;
                tr0.Visible = false;
            }
            else if ((string)Session["sch"] == "2" || (string)Session["sch"] == "121" || (string)Session["sch"] == "119" || (string)Session["sch"] == "118" || (lblprj.Text == "11784" && (string)Session["sch"] == "25"))
            {
                //lb1.Text = lbl1.Text;
                //lb3.Text = lbl3.Text;
                //uplb4.Visible = false;
                //uplb2.Visible = false;
                if (lblprj.Text == "CCAD" || lblprj.Text == "HMIM")
                {
                    lb1.Text = lbl1.Text;
                    lb2.Text = lbl2.Text;
                    lb3.Text = lbl3.Text;
                    lb4.Text = lbnum.Text;
                    tr0.Visible = false;
                }
                else
                {
                    lb1.Text = lbl1.Text;
                    lb2.Text = lbl2.Text;
                    lb3.Text = lbl3.Text;
                    lb4.Visible = false; uplb4.Visible = false; tr0.Visible = false;
                }
            }
            else if ((string)Session["sch"] == "3" || (string)Session["sch"] == "120" || (lblprj.Text == "11784" && (string)Session["sch"] == "26"))
            {
                if (lblprj.Text == "CCAD")
                {
                    lb4.Text = lbnum.Text;
                }
                else
                {
                    lb4.Visible = false; uplb4.Visible = false;
                }
                lb1.Text = lbl1.Text;
                lb2.Text = lbl2.Text;
                lb3.Text = lbl3.Text;
                tr0.Visible = false;

            }
            else if ((string)Session["sch"] == "4" || (string)Session["sch"] == "37" || (lblprj.Text == "11784" && (string)Session["sch"] == "27"))
            {
                if (lblprj.Text == "14211" && (string)Session["sch"] == "37")
                {
                    lb4.Text = lbnum.Text;

                    lb2.Text = "FED FROM";
                    lb1.Text = "DEVICE TYPE";
                    lb3.Text = "ROOM NO";

                    tr0.Visible = false;

                }
                else
                {
                    lb1.Text = lbl1.Text;
                    lb3.Text = lbl3.Text;
                    lb4.Visible = false;
                    uplb4.Visible = false;
                    lb2.Visible = false;
                    uplb2.Visible = false; tr0.Visible = false;
                }

            }
            else if ((string)Session["sch"] == "6" || (lblprj.Text == "11784" && (string)Session["sch"] == "29"))
            {
                lb1.Text = lbl1.Text;
                uplb2.Visible = false; uplb3.Visible = false;
                uplb4.Visible = false; tr0.Visible = false;

            }
            else if ((string)Session["sch"] == "7" || (lblprj.Text == "11784" && (string)Session["sch"] == "30"))
            {
                lb4.Text = lbnum.Text;
                lb1.Visible = false; uplb1.Visible = false; lb3.Visible = false; uplb3.Visible = false;
                tr0.Visible = false;
                if (lblprj.Text == "ASAO")
                {
                    lb2.Text = lbl2.Text;
                }
                else
                {
                    lb2.Visible = false; uplb2.Visible = false;

                }
            }
            else if ((string)Session["sch"] == "8" || (string)Session["sch"] == "51" || (string)Session["sch"] == "52" || (string)Session["sch"] == "53" || (string)Session["sch"] == "54" || (string)Session["sch"] == "55" || (string)Session["sch"] == "56" || (string)Session["sch"] == "57" || (string)Session["sch"] == "58" || (string)Session["sch"] == "59" || (string)Session["sch"] == "60" || (string)Session["sch"] == "62" || (string)Session["sch"] == "61" || (string)Session["sch"] == "63" || (string)Session["sch"] == "64" || (string)Session["sch"] == "65" || (string)Session["sch"] == "66" || (string)Session["sch"] == "67" || (string)Session["sch"] == "68" || (string)Session["sch"] == "69" || (string)Session["sch"] == "70" || (string)Session["sch"] == "71" || (string)Session["sch"] == "72" || (string)Session["sch"] == "73" || (string)Session["sch"] == "74" || (string)Session["sch"] == "75" || (string)Session["sch"] == "76" || (string)Session["sch"] == "77" || (string)Session["sch"] == "78" || (string)Session["sch"] == "79" || (string)Session["sch"] == "80" || (string)Session["sch"] == "81" || (string)Session["sch"] == "82" || (string)Session["sch"] == "83" || (string)Session["sch"] == "84" || (lblprj.Text == "11784" && (string)Session["sch"] == "31"))
            {
                if (lblprj.Text == "CCAD")
                {
                    lb4.Text = lbnum.Text; tr3.Visible = false; tr4.Visible = false; lb3.Text = lbl3.Text;
                }
                else
                {
                    lb3.Text = lbl3.Text; tr3.Visible = false; tr4.Visible = false; tr5.Visible = false;
                }
            }
            else if ((string)Session["sch"] == "41" && lblprj.Text == "123")
            {
                tr5.Visible = false;
                lb3.Text = lbl3.Text;
                tr3.Visible = false; tr4.Visible = false;
            }
            else if ((string)Session["sch"] == "24" || (lblprj.Text == "11784" && (string)Session["sch"] == "45"))
            {
                if (lblprj.Text == "CCAD")
                {
                    lb4.Text = lbnum.Text; tr0.Visible = false;
                }
                else
                {
                    tr5.Visible = false;
                }
                lb3.Text = lbl3.Text;
                tr3.Visible = false; tr4.Visible = false;
            }
            else if ((string)Session["sch"] == "25")
            {
                if (lblprj.Text == "CCAD")
                {
                    lb4.Text = lbnum.Text; tr0.Visible = false; tr2.Visible = false;
                }
                else if (lblprj.Text == "OPH" || lblprj.Text == "PCD")
                {
                    tr0.Visible = false; tr2.Visible = false; tr5.Visible = false;
                }
                else
                {
                    tr5.Visible = false;
                }
                lb3.Text = lbl3.Text;
                tr3.Visible = false; tr4.Visible = false;
            }
            else if ((string)Session["sch"] == "17" || (lblprj.Text == "11784" && (string)Session["sch"] == "38"))
            {
                if (lblprj.Text == "CCAD")
                {
                    lb4.Text = lbnum.Text;
                }
                else
                {
                    tr5.Visible = false;
                }
                lb3.Text = lbl3.Text;
                tr3.Visible = false; tr4.Visible = false;
            }
            else if ((string)Session["sch"] == "27" || (string)Session["sch"] == "46")
            {
                if (lblprj.Text == "CCAD")
                {
                    lb4.Text = lbnum.Text;
                    tr2.Visible = false;
                }
                else if (lblprj.Text == "12761")
                {
                    tr5.Visible = false;
                    tr0.Visible = false;
                }
                else if (lblprj.Text == "OPH" || lblprj.Text == "HMIM" || lblprj.Text == "OCEC" || lblprj.Text == "PCD")
                {
                    lblloc.Text = lbloc.Text;
                    tr5.Visible = false;
                    tr0.Visible = false;
                }
                else
                {
                    tr5.Visible = false;
                }
                lb3.Text = lbl3.Text;
                tr3.Visible = false; tr4.Visible = false;
            }
            else if ((string)Session["sch"] == "9" || (lblprj.Text == "11784" && (string)Session["sch"] == "32"))
            {
                if (lblprj.Text == "CCAD")
                {
                    lbldes.Text = lbdes.Text; lblloc.Text = lbloc.Text;
                    lb3.Text = lbl3.Text; lb1.Text = lbl1.Text; tr4.Visible = false; tr5.Visible = false;
                }
                else
                {
                    lb3.Text = lbl3.Text;
                    if (lblprj.Text != "HMIM") tr2.Visible = false;
                    tr3.Visible = false; tr4.Visible = false; tr5.Visible = false;
                }
            }
            else if ((string)Session["sch"] == "10" || (lblprj.Text == "11784" && (string)Session["sch"] == "33"))
            {
                lb4.Text = lbnum.Text;
                lb2.Text = "NO.OF DEVICES";
                tr0.Visible = false;

                if (lblprj.Text == "CCAD")
                {
                    lb1.Text = lbl1.Text;
                    tr2.Visible = false;
                }
                else if (lblprj.Text == "HMIM" || lblprj.Text == "14211" || lblprj.Text == "HMHS")
                {
                    lb3.Text = "FED FROM";
                    tr3.Visible = false;
                }
                else
                {
                    tr3.Visible = false;
                    tr2.Visible = false;

                }

            }

            else if ((string)Session["sch"] == "15")
            {
                if (lblprj.Text == "CCAD")
                {
                    lb1.Text = lbl1.Text;
                    lb3.Text = lbl3.Text;
                }
                else
                {
                    tr1.Visible = false; tr3.Visible = false;
                    lb3.Text = lbl3.Text;
                    if (lblprj.Text != "HMIM") tr2.Visible = false;
                }
                tr4.Visible = false;
                lb4.Text = lbnum.Text;
                tr0.Visible = false;

            }
            else if ((string)Session["sch"] == "14" || (lblprj.Text == "11784" && (string)Session["sch"] == "37"))
            {
                lb4.Text = lbnum.Text;
                tr2.Visible = false; tr3.Visible = false; tr0.Visible = false; tr4.Visible = false;
                if (lblprj.Text != "CCAD")
                {
                    tr1.Visible = false;
                }
            }

            else if ((string)Session["sch"] == "16")
            {
                lb4.Text = lbnum.Text;
                lb2.Text = lbl2.Text;
                lb3.Text = lbl3.Text;
                lb1.Text = lbl1.Text;
                tr0.Visible = false;
                if (lblprj.Text == "CCAD")
                {
                    tr4.Visible = false;
                }
                //lb1.Visible = false; uplb1.Visible = false;
            }
            else if ((string)Session["sch"] == "18" || (lblprj.Text == "11784" && (string)Session["sch"] == "39"))
            {
                lb4.Text = lbnum.Text;

                tr1.Visible = false; tr2.Visible = false; tr3.Visible = false; tr4.Visible = false;
            }
            else if ((string)Session["sch"] == "29")
            {
                if (lblprj.Text == "CCAD")
                {
                    tr3.Visible = false;
                    tr4.Visible = false;
                }
                else if (lblprj.Text == "14211")
                {
                    lb1.Text = lbl1.Text;
                    lb2.Text = lbl2.Text;
                    tr2.Visible = false; tr3.Visible = false; tr4.Visible = false;
                }
                else
                {
                    lb1.Text = lbl1.Text;
                    lb2.Text = lbl2.Text;
                    tr1.Visible = false; tr2.Visible = false; tr3.Visible = false; tr4.Visible = false;
                }
                lb3.Text = lbl3.Text;
                lb4.Text = lbnum.Text;
                if (lblprj.Text != "ASAO")
                    tr0.Visible = false;
            }
            else if ((string)Session["sch"] == "23" || (lblprj.Text == "11784" && (string)Session["sch"] == "44"))
            {
                if (lblprj.Text == "CCAD")
                {
                    lb4.Text = lbnum.Text;
                    lb1.Text = lbl1.Text;
                }
                else
                {
                    tr5.Visible = false;
                    tr3.Visible = false;
                }
                lb3.Text = lbl3.Text;
                tr4.Visible = false; tr0.Visible = false;
            }
            else if ((string)Session["sch"] == "19" || (lblprj.Text == "11784" && (string)Session["sch"] == "40"))
            {
                if (lblprj.Text == "CCAD")
                {
                    lb4.Text = lbnum.Text;
                    tr1.Visible = false; tr2.Visible = false;
                }
                else
                {
                    tr5.Visible = false; tr0.Visible = false; lb3.Text = lbl3.Text;
                }

                tr3.Visible = false; tr4.Visible = false;
            }
            else if ((string)Session["sch"] == "28" || (string)Session["sch"] == "34" || (string)Session["sch"] == "35" || (string)Session["sch"] == "36")
            {
                if (lblprj.Text == "CCAD")
                {
                    lbldes.Text = lbdes.Text; lblloc.Text = lbloc.Text;
                    lb3.Text = lbl3.Text; lb1.Text = lbl1.Text; tr4.Visible = false; tr5.Visible = false;
                }
                else if ((string)Session["sch"] == "28" && (lblprj.Text == "HMIM" || lblprj.Text == "HMHS"))
                {
                    lb4.Text = lbnum.Text; lblloc.Text = lbloc.Text;
                    lb2.Text = "NO.OF DEVICES";
                    lb3.Text = "FED FROM";
                    tr3.Visible = false; tr0.Visible = false;

                }
                else if ((string)Session["sch"] == "28" && lblprj.Text == "14211")
                {
                    lb4.Text = lbnum.Text; lblloc.Text = lbloc.Text;
                    lb3.Text = lbl3.Text;
                    lbl3.Text = uplb4.Text;
                    lb4.Text = "NO OF EUIPMENTS";
                    tr3.Visible = false; tr4.Visible = false; tr0.Visible = false; tr2.Visible = false;


                }
                else if ((string)Session["sch"] == "34" && lblprj.Text == "14211")
                {
                    lb3.Text = "FED FROM";
                    lb1.Text = "PROVIDES POWER TO";
                    lb3.Text = lbl3.Text;
                    //tr3.Visible = false; 
                    tr4.Visible = false; tr5.Visible = false; tr0.Visible = false;
                }
                else if ((string)Session["sch"] == "35" && lblprj.Text == "14211")
                {
                    lb3.Text = "FED FROM";
                    lb1.Text = "PROVIDES POWER TO";
                    lb3.Text = lbl3.Text;
                    //tr3.Visible = false; 
                    //tr4.Visible = false; tr5.Visible = false; tr0.Visible = false;

                    lb3.Text = lbl3.Text; tr3.Visible = false; tr4.Visible = false; tr5.Visible = false;


                }
                else
                {
                    lb3.Text = lbl3.Text;
                    tr3.Visible = false; tr4.Visible = false; tr5.Visible = false; tr0.Visible = false;
                }
            }
            else if ((string)Session["sch"] == "21" || (lblprj.Text == "11784" && (string)Session["sch"] == "42"))
            {
                lb4.Text = lbnum.Text;
                tr2.Visible = false; tr3.Visible = false; tr4.Visible = false;

            }
            else if ((string)Session["sch"] == "13" || (lblprj.Text == "11784" && (string)Session["sch"] == "36"))
            {
                if (lblprj.Text == "CCAD" || lblprj.Text == "HMIM" || lblprj.Text == "14211")
                {
                    lb3.Text = lbl3.Text;
                }
                else
                {
                    tr2.Visible = false;
                }
                lblloc.Text = lbloc.Text;
                lb4.Text = lbnum.Text;
                tr3.Visible = false; tr4.Visible = false; tr0.Visible = false;

            }
            else if ((string)Session["sch"] == "22" || (lblprj.Text == "11784" && (string)Session["sch"] == "43"))
            {
                if (lblprj.Text == "CCAD")
                {
                    lb3.Text = lbl3.Text;
                }
                else if (lblprj.Text == "OPH" || lblprj.Text == "PCD")
                {
                    lb3.Text = lbl2.Text;
                }
                else
                {
                    tr2.Visible = false;
                }
                lblloc.Text = lbloc.Text;
                lb4.Text = lbnum.Text;
                tr3.Visible = false; tr4.Visible = false; tr0.Visible = false;

            }
            else if ((string)Session["sch"] == "11" || (lblprj.Text == "11784" && (string)Session["sch"] == "34"))
            {
                lblloc.Text = lbloc.Text;
                lb4.Text = lbnum.Text;
                lb2.Text = lbl2.Text;
                tr2.Visible = false; tr3.Visible = false; tr0.Visible = false;
                if (lblprj.Text == "CCAD")
                {
                    tr4.Visible = false;
                }
                else if (lblprj.Text == "14211" || lblprj.Text == "HMIM")
                {
                    lb3.Text = "FED FROM";
                    tr3.Visible = false;
                }

            }
            else if ((string)Session["sch"] == "20" || (lblprj.Text == "11784" && (string)Session["sch"] == "41"))
            {
                if (lblprj.Text == "CCAD")
                {
                    tr3.Visible = false;
                    tr4.Visible = false;
                }
                else
                {
                    lb1.Text = lbl1.Text;
                    lb2.Text = lbl2.Text;

                }
                lb3.Text = lbl3.Text;
                lb4.Text = lbnum.Text;
                tr0.Visible = false;

            }
            else if ((string)Session["sch"] == "32")
            {
                if (lblprj.Text == "14211")
                {
                    lb4.Text = lbnum.Text;
                    lb1.Visible = false; uplb1.Visible = false; lb3.Visible = false; uplb3.Visible = false;
                    tr0.Visible = false;
                    lb2.Visible = false; uplb2.Visible = false;
                }
                else
                {
                    lb1.Text = lbl1.Text;
                    lb3.Text = lbl3.Text;
                    lb2.Text = lbl2.Text;
                    lb4.Text = lbnum.Text;
                    tr0.Visible = false;
                }
            }
            else if ((string)Session["sch"] == "12" || (lblprj.Text == "11784" && (string)Session["sch"] == "35"))
            {
                lb4.Text = lbnum.Text;
                lb3.Text = lbl3.Text;
                tr4.Visible = false; tr3.Visible = false; tr0.Visible = false;

            }
            else if ((string)Session["sch"] == "30")
            {
                if (lblprj.Text == "CCAD")
                {
                    lbldes.Text = lbdes.Text; lblloc.Text = lbloc.Text;
                    lb3.Text = lbl3.Text; lb1.Text = lbl1.Text; tr4.Visible = false; tr5.Visible = false;
                }
                else if (lblprj.Text == "14211")
                {
                    tr4.Visible = false; tr3.Visible = false;
                    lb1.Text = lbl1.Text;
                    lb3.Text = lbl3.Text;
                    lb4.Text = lbnum.Text;
                }
                else
                {
                    lb1.Text = lbl1.Text;
                    lb3.Text = lbl3.Text;
                    lb2.Text = lbl2.Text;
                    lb4.Text = lbnum.Text;
                }
            }
            else if ((string)Session["sch"] == "26")
            {
                if (lblprj.Text == "CCAD")
                {
                    tr0.Visible = false;
                    tr2.Visible = false;
                    tr5.Visible = false;
                }
                else if (lblprj.Text == "OPH" || lblprj.Text == "PCD")
                    tr0.Visible = false;
                lb3.Text = lbl3.Text;
                lb4.Text = lbnum.Text;
                tr3.Visible = false; tr4.Visible = false;
            }
            else if ((string)Session["sch"] == "39")
            {
                //if (lblprj.Text == "14211")
                //{
                //lb4.Text = lbnum.Text;
                //lb1.Visible = false; uplb1.Visible = false; lb3.Visible = false; uplb3.Visible = false;
                //tr0.Visible = false;

                //    lb2.Visible = false; uplb2.Visible = false;

                //}
                if (lblprj.Text == "14211")
                {
                    lb4.Text = lbnum.Text;

                    lb2.Text = "FED FROM";
                    lb1.Text = "DEVICE TYPE";
                    lb3.Text = "ROOM NO";

                    tr0.Visible = false;

                }
            }
            else if ((string)Session["sch"] == "31")
            {
                if (lblprj.Text == "14211")
                {
                    tr4.Visible = false; tr3.Visible = false;
                    lb1.Text = lbl1.Text;
                    lb3.Text = lbl3.Text;
                    lb4.Text = lbnum.Text;
                }
            }
            else if ((string)Session["sch"] == "33")
            {
                if (lblprj.Text == "14211")
                {
                    lb4.Text = lbnum.Text;
                    lb1.Visible = false; uplb1.Visible = false;
                    tr0.Visible = false;

                    lb2.Text = "CONNECTED TO";
                    lb3.Text = "FED FROM";

                }
            }

        }
        protected void mydetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;

            //e.Row.Cells[0].Enabled = false;
            //if (e.Row.Cells[1].Text != "") return;
            //if (e.Row.Cells[0].Text != "")
            //    e.Row.Cells[0].Text = "hai" + e.Row.Cells[0].Text;
            e.Row.Cells[1].Text = (e.Row.DataItemIndex + 1).ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //e.Row.Cells[7].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                //e.Row.Cells[8].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                //e.Row.Cells[9].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                //e.Row.Cells[10].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");

                e.Row.Cells[7].Attributes.Add("style", "word-wrap:break-word");
                e.Row.Cells[8].Attributes.Add("style", "word-wrap:break-word");
                e.Row.Cells[9].Attributes.Add("style", "word-wrap:break-word");
                e.Row.Cells[10].Attributes.Add("style", "word-wrap:break-word");
            }
            //if (txtnoof.Visible == false)
            //    e.Row.Cells[11].Text = "";
            if ((string)Session["sch"] == "1" || (string)Session["sch"] == "5" || ((string)Session["sch"] == "44" && lblprj.Text != "11784") || (lblprj.Text == "11784" && (string)Session["sch"] == "28"))
            {
                if (lblprj.Text == "CCAD")
                    e.Row.Cells[7].Visible = false;
                else
                {
                    e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
                }
            }
            else if ((string)Session["sch"] == "4" || ((string)Session["sch"] == "37" && lblprj.Text != "11784") || (lblprj.Text == "11784" && (string)Session["sch"] == "27"))
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
            else if ((string)Session["sch"] == "2" || (lblprj.Text == "11784" && (string)Session["sch"] == "25"))
            {
                if (lblprj.Text == "CCAD" || lblprj.Text == "HMIM")
                    e.Row.Cells[7].Visible = false;
                else
                {
                    e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
                }
            }
            else if ((string)Session["sch"] == "121" || (string)Session["sch"] == "119" || (string)Session["sch"] == "118")
            {
                if (lblprj.Text == "CCAD")
                    e.Row.Cells[7].Visible = false;
                else
                {
                    e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
                }
            }
            else if ((string)Session["sch"] == "3" || (string)Session["sch"] == "120" || (lblprj.Text == "11784" && (string)Session["sch"] == "26"))
            {
                if (lblprj.Text != "CCAD")
                    e.Row.Cells[12].Visible = false;
                e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "6" || (lblprj.Text == "11784" && (string)Session["sch"] == "29"))
            {
                e.Row.Cells[9].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "7" || (lblprj.Text == "11784" && (string)Session["sch"] == "30"))
            {
                if (lblprj.Text != "CCAD")
                {
                    if (lblprj.Text != "ASAO")
                        e.Row.Cells[11].Visible = false;
                    e.Row.Cells[10].Visible = false; e.Row.Cells[9].Visible = false;
                }
                e.Row.Cells[7].Visible = false;
            }

            else if ((string)Session["sch"] == "8" || (string)Session["sch"] == "51" || (string)Session["sch"] == "52" || (string)Session["sch"] == "53" || (string)Session["sch"] == "54" || (string)Session["sch"] == "55" || (string)Session["sch"] == "56" || (string)Session["sch"] == "57" || (string)Session["sch"] == "58" || (string)Session["sch"] == "59" || (string)Session["sch"] == "60" || (string)Session["sch"] == "62" || (string)Session["sch"] == "61" || (string)Session["sch"] == "63" || (string)Session["sch"] == "64" || (string)Session["sch"] == "65" || (string)Session["sch"] == "66" || (string)Session["sch"] == "67" || (string)Session["sch"] == "68" || (string)Session["sch"] == "69" || (string)Session["sch"] == "70" || (string)Session["sch"] == "71" || (string)Session["sch"] == "72" || (string)Session["sch"] == "73" || (string)Session["sch"] == "74" || (string)Session["sch"] == "75" || (string)Session["sch"] == "76" || (string)Session["sch"] == "77" || (string)Session["sch"] == "78" || (string)Session["sch"] == "79" || (string)Session["sch"] == "80" || (string)Session["sch"] == "81" || (string)Session["sch"] == "82" || (string)Session["sch"] == "83" || (string)Session["sch"] == "84" || (lblprj.Text == "11784" && (string)Session["sch"] == "31"))
            {
                if (lblprj.Text == "CCAD")
                { e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false; }
                else
                {
                    e.Row.Cells[10].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[11].Visible = false;
                }
            }
            else if ((string)Session["sch"] == "41" && lblprj.Text == "123")
            {
                e.Row.Cells[12].Visible = false;
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "24" || (lblprj.Text == "11784" && (string)Session["sch"] == "45") || (lblprj.Text == "MOE" && (string)Session["sch"] == "32"))
            {
                if (lblprj.Text == "CCAD" || lblprj.Text == "NCP")
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
                if (lblprj.Text == "CCAD")
                {
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[9].Visible = false;
                }
                else if (lblprj.Text == "OPH" || lblprj.Text == "PCD")
                {
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[12].Visible = false;
                    e.Row.Cells[9].Visible = false;
                }
                else
                {
                    e.Row.Cells[12].Visible = false;
                }
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "17" || (lblprj.Text == "11784" && (string)Session["sch"] == "38"))
            {
                if (lblprj.Text != "CCAD")
                    e.Row.Cells[12].Visible = false;
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "27" || (string)Session["sch"] == "46")
            {
                if (lblprj.Text == "CCAD")
                    e.Row.Cells[9].Visible = false;
                else if (lblprj.Text == "12761")
                { e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false; }
                else if (lblprj.Text == "OPH" || lblprj.Text == "HMIM" || lblprj.Text == "OCEC" || lblprj.Text == "PCD")
                { e.Row.Cells[7].Visible = false; e.Row.Cells[12].Visible = false; }
                else
                    e.Row.Cells[12].Visible = false;
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "112")
            {
                //if (lblprj.Text == "CCAD" )
                //    e.Row.Cells[9].Visible = false;
                //else
                //    e.Row.Cells[12].Visible = false;
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
                e.Row.Cells[12].Visible = false;
            }
            else if ((string)Session["sch"] == "9" || (lblprj.Text == "11784" && (string)Session["sch"] == "32"))
            {
                if (lblprj.Text == "CCAD")
                { e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; }
                else
                {
                    if (lblprj.Text != "HMIM" && lblprj.Text != "NBO") e.Row.Cells[9].Visible = false;
                    e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false;
                }
            }
            else if ((string)Session["sch"] == "18" || (lblprj.Text == "11784" && (string)Session["sch"] == "39"))
            {
                e.Row.Cells[8].Visible = false; e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "29")
            {
                if (lblprj.Text == "CCAD")
                {
                    e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
                }
                else if (lblprj.Text == "14211")
                {
                    e.Row.Cells[10].Visible = false; e.Row.Cells[9].Visible = false;
                    e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
                }
                else
                {
                    e.Row.Cells[8].Visible = false; e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
                }
            }
            else if ((string)Session["sch"] == "23" || (lblprj.Text == "11784" && (string)Session["sch"] == "44") || (lblprj.Text == "MOE" && (string)Session["sch"] == "31"))
            {
                if (lblprj.Text != "CCAD")
                {
                    e.Row.Cells[12].Visible = false; e.Row.Cells[10].Visible = false;
                }
                e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "19" || (lblprj.Text == "11784" && (string)Session["sch"] == "40"))
            {
                if (lblprj.Text == "CCAD")
                {
                    e.Row.Cells[8].Visible = false; e.Row.Cells[9].Visible = false;
                }
                else
                {
                    e.Row.Cells[7].Visible = false; e.Row.Cells[12].Visible = false;
                }
                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if (((string)Session["sch"] == "28" || (string)Session["sch"] == "34" || (string)Session["sch"] == "35" || (string)Session["sch"] == "36") && lblprj.Text != "11784")
            {
                if (lblprj.Text == "CCAD")
                { e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; }
                else if ((string)Session["sch"] == "28" && (lblprj.Text == "HMIM" || lblprj.Text == "HMHS"))
                {
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[10].Visible = false;
                }
                else if ((string)Session["sch"] == "28" && lblprj.Text == "14211")
                {
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[10].Visible = false;
                    e.Row.Cells[11].Visible = false;
                    e.Row.Cells[9].Visible = false;
                    //e.Row.Cells[8].Visible = false;
                }
                else if ((string)Session["sch"] == "34" && lblprj.Text == "14211")
                {
                    e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
                }
                else if ((string)Session["sch"] == "35" && lblprj.Text == "14211")
                {
                    e.Row.Cells[10].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[11].Visible = false;
                }
                else
                {
                    e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[7].Visible = false;
                }
            }
            else if ((string)Session["sch"] == "21" || (lblprj.Text == "11784" && (string)Session["sch"] == "42"))
            {
                e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "10" || (lblprj.Text == "11784" && (string)Session["sch"] == "33"))
            {
                if (lblprj.Text == "CCAD")
                {
                    e.Row.Cells[9].Visible = false; e.Row.Cells[7].Visible = false;
                }
                else if (lblprj.Text == "HMIM" || lblprj.Text == "14211" || lblprj.Text == "HMHS")
                {
                    //e.Row.Cells[9].Visible = false; e.Row.Cells[7].Visible = false;

                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[10].Visible = false;
                }
                else
                {
                    e.Row.Cells[10].Visible = false; e.Row.Cells[9].Visible = false; e.Row.Cells[7].Visible = false;
                }
            }
            else if ((string)Session["sch"] == "31")
            {
                if (lblprj.Text == "14211")
                {
                    e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
                }
                else
                {

                    e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false;
                }
            }

            else if ((string)Session["sch"] == "20" || (lblprj.Text == "11784" && (string)Session["sch"] == "41"))
            {
                e.Row.Cells[7].Visible = false;
                if (lblprj.Text == "CCAD")
                {
                    e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
                }
            }
            else if ((string)Session["sch"] == "32")
            {
                if (lblprj.Text == "14211")
                {
                    e.Row.Cells[10].Visible = false; e.Row.Cells[9].Visible = false;
                    e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
                }
                else
                    e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "13" || (lblprj.Text == "11784" && (string)Session["sch"] == "36"))
            {

                if (lblprj.Text != "CCAD" && lblprj.Text != "14211" && lblprj.Text != "HMIM" && lblprj.Text != "NCP")
                {
                    e.Row.Cells[9].Visible = false;

                }
                e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "22" || (lblprj.Text == "11784" && (string)Session["sch"] == "43"))
            {
                if (lblprj.Text != "CCAD" && lblprj.Text != "14211" && lblprj.Text != "OPH" && lblprj.Text != "PCD")
                {
                    e.Row.Cells[9].Visible = false;
                }
                e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "11" || (lblprj.Text == "11784" && (string)Session["sch"] == "34"))
            {
                e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false;
                if (lblprj.Text == "CCAD")
                {
                    e.Row.Cells[11].Visible = false;
                    e.Row.Cells[9].Visible = false;
                }
                else if (lblprj.Text != "14211" && lblprj.Text != "HMIM")
                {
                    e.Row.Cells[9].Visible = false;
                }

            }
            else if ((string)Session["sch"] == "12" || (lblprj.Text == "11784" && (string)Session["sch"] == "35"))
            {
                e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;

                if (lblprj.Text != "14211" && lblprj.Text != "HMIM") e.Row.Cells[10].Visible = false;



            }
            else if ((string)Session["sch"] == "15")
            {
                if (lblprj.Text == "OPH" || lblprj.Text == "PCD")
                {
                    e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false;
                }
                else
                {

                    if (lblprj.Text != "CCAD")
                    {

                        e.Row.Cells[8].Visible = false; e.Row.Cells[10].Visible = false;
                        if (lblprj.Text != "HMIM") e.Row.Cells[9].Visible = false;
                    }

                    e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
                }
            }
            else if ((string)Session["sch"] == "14" || (lblprj.Text == "11784" && (string)Session["sch"] == "37"))
            {
                if (lblprj.Text != "CCAD")
                {
                    e.Row.Cells[8].Visible = false;
                }
                else if (lblprj.Text != "HMIM") e.Row.Cells[9].Visible = false;
                e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "16")
            {
                if (lblprj.Text == "CCAD")
                    e.Row.Cells[11].Visible = false;
                else if (lblprj.Text == "AFV")
                {
                    e.Row.Cells[12].Visible = false;
                }
                e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "26")
            {
                if (lblprj.Text == "CCAD")
                {
                    e.Row.Cells[7].Visible = false; e.Row.Cells[9].Visible = false; e.Row.Cells[12].Visible = false;
                }
                else if (lblprj.Text == "OPH" || lblprj.Text == "PCD")
                {
                    e.Row.Cells[7].Visible = false;
                }

                e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
            }
            else if ((string)Session["sch"] == "30")
            {
                if (lblprj.Text == "14211")
                {
                    e.Row.Cells[10].Visible = false; e.Row.Cells[11].Visible = false;
                }
            }
            else if ((string)Session["sch"] == "39")
            {
                //if (lblprj.Text == "14211")
                //{
                //    e.Row.Cells[10].Visible = false; e.Row.Cells[9].Visible = false;
                //    e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
                //}
                if (lblprj.Text == "14211")
                {
                    e.Row.Cells[7].Visible = false;
                    //e.Row.Cells[10].Visible = false; 
                    //e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
                }

            }
            else if ((string)Session["sch"] == "33")
            {
                if (lblprj.Text == "14211")
                {
                    e.Row.Cells[11].Visible = false; e.Row.Cells[7].Visible = false;
                }


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
            DataTable _dtfilter = _dtresult;
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
                          where (_el1 == "All" || o.Field<string>("B_Z") == _el1) && (_el2 == "All" || o.Field<string>("Cat") == _el2) && (_el3 == "All" || o.Field<string>("F_lvl") == _el3) && (_el4 == "All" || o.Field<string>("F_from") == _el4) && (_el5 == "All" || o.Field<string>("Loc") == _el5) && (_el6 == "All" || o.Field<string>("Des") == _el6)
                          select o;

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
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.sys = Convert.ToInt32(Sys_Id);
            if (lblprj.Text == "14211" || lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
            {
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                txtitmno.Text = _objbll.Get_Position_Div(_objcls, _objdb).ToString();
            }
            else
                txtitmno.Text = _objbll.Get_Position(_objcls, _objdb).ToString();

        }
        private void Get_SeqNo()
        {
            string Sys_Id = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_" + lblprj.Text;
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
            if ((string)Session["sch"] == "1" || (string)Session["sch"] == "5" || (string)Session["sch"] == "7" || ((string)Session["sch"] == "39" && lblprj.Text == "14211") || (string)Session["sch"] == "21" || (string)Session["sch"] == "13" || (string)Session["sch"] == "22" || (string)Session["sch"] == "12" || (string)Session["sch"] == "15" || (string)Session["sch"] == "14" || (lblprj.Text == "11784" && ((string)Session["sch"] == "28") || (string)Session["sch"] == "30" || (string)Session["sch"] == "36") || (string)Session["sch"] == "43" || (string)Session["sch"] == "35" || (string)Session["sch"] == "37" || (lblprj.Text == "11784" && ((string)Session["sch"] == "42" || (string)Session["sch"] == "39")))
            {
                if (IsNumeric(txtnoof.Text) == false)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lbnum.Text + "');", true);
                    return;
                }
            }
            else if (lblsch.Text == "18")
            {
                if (IsNumeric(txtnoof.Text) == true)
                {
                    if (IsGreaterThanZero(txtnoof.Text) == false)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Value must be greater than zero.');", true);
                        return;
                    }
                }
                if (IsNumeric(txtnoof.Text) == false)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lbnum.Text + "');", true);
                    return;
                }
            }
            else if ((string)Session["sch"] == "11" || (lblprj.Text == "11784" && (string)Session["sch"] == "34"))
            {
                if (IsNumeric(txtnoof.Text) == false)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lbnum.Text + "');", true);
                    return;
                }
                else if (IsNumeric(txtdesc.Text) == false)
                {
                    if (lblprj.Text != "CCAD")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lbl2.Text + "');", true);
                        return;
                    }
                }
            }
            else if ((string)Session["sch"] == "20" || (lblprj.Text == "11784" && (string)Session["sch"] == "41"))
            {
                if (lblprj.Text != "CCAD")
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
            if (IfExistRef(txtengref.Text) == true) return;
            string _sys = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));
            //if (txtnoof.Text.Length <= 0) txtnoof.Text = "0";
            //int no = 0;
            //string dev_vol = "";
            //if ((string)Session["sch"] == "1" || (string)Session["sch"] == "2" || (string)Session["sch"] == "3")
            //    dev_vol = txtnoof.Text;
            //else
            //    no = Convert.ToInt32(txtnoof.Text);
            add_initial_data();
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drdes.SelectedItem.Text);
            //Load_Master();
            //Load_InitialData();
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
            if (CheckContain(drbuilding, (string)Session["zone"]) == true) drbuilding.SelectedValue = (string)Session["zone"]; else drbuilding.Items.Insert(0, (string)Session["zone"]);
            if (CheckContain(drcategory, (string)Session["cat"]) == true) drcategory.SelectedValue = (string)Session["cat"]; else drcategory.Items.Insert(0, (string)Session["cat"]);
            if (CheckContain(drflevel, (string)Session["flvl"]) == true) drflevel.SelectedValue = (string)Session["flvl"]; else drflevel.Items.Insert(0, (string)Session["flvl"]);
            if (CheckContain(drfed, (string)Session["fed"]) == true) drfed.SelectedValue = (string)Session["fed"]; else drfed.Items.Insert(0, (string)Session["fed"]);
            if (CheckContain(drloc, (string)Session["loc"]) == true) drloc.SelectedValue = (string)Session["loc"]; else drloc.Items.Insert(0, (string)Session["loc"]);
            if (CheckContain(drdes, (string)Session["des"]) == true) drdes.SelectedValue = (string)Session["des"]; else drdes.Items.Insert(0, (string)Session["des"]);
        }
        private bool CheckContain(DropDownList _dlist, string _value)
        {
            foreach (ListItem _lst in _dlist.Items)
            {
                if (string.Compare(_lst.Value, _value) == 0) return true;
            }
            return false;
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if ((string)Session["sch"] == "1" || (string)Session["sch"] == "5" || (string)Session["sch"] == "7" || (string)Session["sch"] == "18" || (string)Session["sch"] == "21" || (string)Session["sch"] == "20" || (string)Session["sch"] == "13" || (string)Session["sch"] == "22" || (string)Session["sch"] == "11" || (string)Session["sch"] == "12" || (string)Session["sch"] == "15" || (string)Session["sch"] == "14" || (lblprj.Text == "11784" && (string)Session["sch"] == "28" || (string)Session["sch"] == "30") || (string)Session["sch"] == "41" || (string)Session["sch"] == "36" || (string)Session["sch"] == "43" || (string)Session["sch"] == "34" || (string)Session["sch"] == "35" || (string)Session["sch"] == "37" || (lblprj.Text == "11784" && ((string)Session["sch"] == "42" || (string)Session["sch"] == "39")))
            {
                if (IsNumeric(uplb4.Text) == false)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lbnum.Text + "');", true);
                    return;
                }
            }
            if ((string)Session["sch"] == "20" || (lblprj.Text == "11784" && (string)Session["sch"] == "41"))
            {
                if (lblprj.Text != "CCAD")
                {
                    if (IsNumeric(uplb1.Text) == false)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lb1.Text + "');", true);
                        return;
                    }

                    else if (IsNumeric(uplb2.Text) == false)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lb2.Text + "');", true);
                        return;
                    }
                }
                if (IsNumeric(uplb4.Text) == false)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lb4.Text + "');", true);
                    return;
                }
            }
            else if ((string)Session["sch"] == "11" || (lblprj.Text == "11784" && (string)Session["sch"] == "34"))
            {
                if (IsNumeric(uplb2.Text) == false)
                {
                    if (lblprj.Text != "CCAD")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lb2.Text + "');", true);
                        return;
                    }
                }
                else if (IsNumeric(uplb4.Text) == false)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid ' + '" + lb4.Text + "');", true);
                    return;
                }
            }
            if (string.Compare(upreff.Text, lblref.Text) != 0)
            {
                if (IfExistRef(upreff.Text) == true) return;
            }
            Edit_Inidata();
            //Load_Master();
            //Load_InitialData();
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drdes.SelectedItem.Text);
            Open_Details(0);
            btnDummy_ModalPopupExtender.Hide();
        }
        private void Edit_Inidata()
        {
            if ((string)Session["sch"] == "21" || (string)Session["sch"] == "9" || (string)Session["sch"] == "17" || (string)Session["sch"] == "18" || (string)Session["sch"] == "24" || ((string)Session["sch"] == "41" && lblprj.Text == "123") || (lblprj.Text == "11784" && ((string)Session["sch"] == "32" || (string)Session["sch"] == "42" || (string)Session["sch"] == "38" || (string)Session["sch"] == "39") || (string)Session["sch"] == "45"))
            {
                uplb2.Text = updescr.Text;
            }
            if ((string)Session["sch"] == "8")
                if (lblprj.Text != "CCAD")
                    uplb2.Text = updescr.Text;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.c_s_id = 0;
            _objcas.prj_code = lblprj.Text;
            _objcas.uid = lbluid.Text;
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
            if ((string)Session["sch"] == "20" || (lblprj.Text == "11784" && (string)Session["sch"] == "41"))
            {
                _objcas.dev2 = uplb2.Text;
                _objcas.dev3 = uplb1.Text;
            }
            if ((string)Session["sch"] == "11" || (string)Session["sch"] == "10" || (lblprj.Text == "11784" && (string)Session["sch"] == "33" || (string)Session["sch"] == "34"))
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
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.c_s_id = 0;
            _objcas.prj_code = lblprj.Text;
            _objcas.uid = lbluid.Text;
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
            Delete_Inidata();
            Load_Master();
            Load_InitialData();
            Open_Details(0);
            btnDummy_ModalPopupExtender.Hide();
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender.Hide();
        }
        protected void add_initial_data()
        {
            //if (IsNullvalidation() == true) return;
            if ((string)Session["sch"] == "21" || (string)Session["sch"] == "9" || (string)Session["sch"] == "17" || (string)Session["sch"] == "18" || (string)Session["sch"] == "24" || ((string)Session["sch"] == "41" && lblprj.Text == "123") || (lblprj.Text == "11784" && ((string)Session["sch"] == "32") || (string)Session["sch"] == "42" || (string)Session["sch"] == "38" || (string)Session["sch"] == "39") || (string)Session["sch"] == "45")
            {
                txtdesc.Text = txtdes.Text;
            }
            if ((string)Session["sch"] == "8" || (lblprj.Text == "11784" && (string)Session["sch"] == "31"))
                if (lblprj.Text != "CCAD")
                    txtdesc.Text = txtdes.Text;
            string _sys = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.c_s_id = Convert.ToInt32(lblsch.Text);
            _objcas.prj_code = lblprj.Text;
            _objcas.uid = lbluid.Text;
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
            if ((string)Session["sch"] == "20" || (lblprj.Text == "11784" && (string)Session["sch"] == "41"))
            {
                _objcas.dev2 = txtdesc.Text;
                _objcas.dev3 = txtpprovideto.Text;
            }
            if ((string)Session["sch"] == "11" || (string)Session["sch"] == "10" || (lblprj.Text == "11784" && (string)Session["sch"] == "33" || (string)Session["sch"] == "34"))
                _objcas.dev2 = txtdesc.Text;
            _objcas.mode = 1;
            _objcas.cas_id = 0;
            _objcas.Position = Convert.ToInt32(txtitmno.Text);


            if (lblprj.Text == "14211" || lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                _objcas.panel_id = Convert.ToInt32(lbldiv.Text);

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
            _objdb.DBName = "DB_" + lblprj.Text;
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
        protected void drloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["loc"] = drloc.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drdes.SelectedItem.Text);
        }
        protected void btnnewflevel_Click(object sender, EventArgs e)
        {
            txtflvl.Text = String.Empty;
            btnDummy_ModalPopupExtender1.Show();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (txtflvl.Text.Length <= 0) return;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.f_level = txtflvl.Text;
            _objbll.Create_FLevel(_objcas, _objdb);
            Load_Flvl();
            btnDummy_ModalPopupExtender1.Hide();
        }
        private void Load_Flvl()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            drflevel_.DataSource = _objbll.Load_Flvl(_objdb);
            drflevel_.DataTextField = "F_Level";
            drflevel_.DataValueField = "F_Level";
            drflevel_.DataBind();
            drflevel_.Items.Insert(0, "- - -");
        }
        protected void btncancel1_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender1.Hide();
        }
        protected void drflevel__SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpackage.SelectedItem.Text == "--Package--") return;
            Get_SeqNo();
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
            for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            {
                GridView _details = (GridView)mymaster.Rows[i].FindControl("mydetails");
                for (int j = 0; j <= _details.Rows.Count - 1; j++)
                {
                    CheckBox checkbox = (CheckBox)_details.Rows[j].FindControl("chkrow");
                    if (checkbox.Checked == true)
                    {
                        count += 1;
                        Session["casid"] = _details.Rows[j].Cells[13].Text;
                        Session["Sys"] = _details.Rows[j].Cells[14].Text;
                        Session["idx"] = j.ToString();
                    }
                }

            }
            if (count == 0) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');", true);
            else if (count > 1)
            {
                Add_MultiEdit_temp();
                Response.Redirect("CasSheet/Edit_M_2.aspx");
            }
            else if (count == 1)
            {
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["MemberId"] + "',7);", true);
                btnDummy_ModalPopupExtender.Show();
                arrange_edit();
            }
        }
        private void Add_MultiEdit_temp()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();
            for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            {
                GridView _details = (GridView)mymaster.Rows[i].FindControl("mydetails");
                for (int j = 0; j <= _details.Rows.Count - 1; j++)
                {
                    CheckBox checkbox = (CheckBox)_details.Rows[j].FindControl("chkrow");
                    if (checkbox.Checked == true)
                    {
                        _objcls.sch = Convert.ToInt32(_details.Rows[j].Cells[13].Text);
                        _objcls.sys = Convert.ToInt32(_details.Rows[j].Cells[14].Text);
                        _objcls.uid = lbluid.Text;
                        _objcls.action = 1;
                        _objbll.Add_Cas_MultiEdit_Temp(_objcls, _objdb);
                    }
                }

            }
        }
        protected void btndelete1_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            {
                GridView _details = (GridView)mymaster.Rows[i].FindControl("mydetails");
                for (int j = 0; j <= _details.Rows.Count - 1; j++)
                {
                    CheckBox checkbox = (CheckBox)_details.Rows[j].FindControl("chkrow");
                    if (checkbox.Checked == true)
                    {
                        count += 1;
                        Session["casid"] = _details.Rows[j].Cells[13].Text;
                        Session["Sys"] = _details.Rows[j].Cells[14].Text;
                        Delete_Inidata();
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
            if (btnsearch.Text == "Search")
            {
                FnSearch();
                for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
                {
                    GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
                    Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
                    _mydetails.Visible = true;
                    _btn.Text = "-";
                }
                btnsearch.Text = "Reset";
            }
            else
            {
                txtsearch.Text = String.Empty;
                FnSearch();
                for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
                {
                    GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
                    Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
                    _mydetails.Visible = false;
                    _btn.Text = "+";
                }
                btnsearch.Text = "Search";
            }
        }

        protected void btnimport_Click(object sender, EventArgs e)
        {

            string _url = "";
            if (lblprj.Text == "HMIM" || lblprj.Text == "14211" || lblprj.Text == "HMHS")
            {
                _url = "CMS/Import.aspx?id=" + (string)Session["sch"] + "&prj=" + lblprj.Text + "&sec=" + lbldiv.Text;
            }
            else
            {
                if ((string)Session["sch"] == "112")
                    _url = "CMS/Import.aspx?id=" + lblsch.Text + "&prj=" + lblprj.Text + "&sec=0";
                else
                    _url = "CMS/Import.aspx?id=" + (string)Session["sch"] + "&prj=" + lblprj.Text + "&sec=0";
            }

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

        protected void btnaddm_Click(object sender, EventArgs e)
        {
            Response.Redirect("CasSheet/Add_M_2.aspx");
        }
        static bool IsGreaterThanZero(object Expression)
        {

            return (Convert.ToInt32(Expression) >= 0);

        }

    }
}
