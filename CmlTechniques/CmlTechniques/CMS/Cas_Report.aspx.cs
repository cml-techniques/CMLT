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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;

namespace CmlTechniques.CMS
{
    public partial class Cas_Report : System.Web.UI.Page
    
{
        public bool isPcdProject;
        protected void Page_Load(object sender, EventArgs e)
        {
          

        }
        private void Insert_ReportData(string sch)
        {
            //DataTable _dtresult = (DataTable)Session["data"];
            //var _Rptdata = from _data in _dtresult.AsEnumerable()
            //               select _data;
            //if (sch == "81") sch = "8";
            //if (sch == "91") sch = "9";
            //if (sch == "51") sch = "5";
            //if (sch == "21") sch = "2";
            //if (sch == "61") sch = "6";
            //if (sch == "31") sch = "3";
            //if (sch == "41") sch = "4";
            //if (sch == "71") sch = "7";
            //if (sch == "201") sch = "20";
            //if (sch == "231") sch = "23";
            //if (sch == "221") sch = "22";
            //if (sch == "121") sch = "12";
            //if (sch == "151") sch = "15";
            //if (sch == "131") sch = "13";
            //if (sch == "161") sch = "16";
            //if (sch == "141") sch = "14";
            //if (sch == "241") sch = "24";
            //if (sch == "251") sch = "25";
            //if (sch == "261") sch = "26";
            //if (sch == "171") sch = "17";
            //if (sch == "101") sch = "10";
            //if (sch == "181") sch = "18";
            //if (sch == "191") sch = "19";
            //if (sch == "271") sch = "27";
            //if (sch == "291") sch = "29";
            //if (sch == "411") sch = "41";
            //if (sch == "421") sch = "42";
            //if (sch == "851") sch = "45";
            //if (sch == "861") sch = "86";
            //if (sch == "871") sch = "87";
            //if (sch == "881") sch = "88";
            //if (sch == "891") sch = "89";
            //if (sch == "901") sch = "90";
            //if (sch == "911") sch = "91";
            //if (sch == "921") sch = "92";
            //if (sch == "931") sch = "93";
            //if (sch == "951") sch = "95";
            //if (sch == "961") sch = "96";
            //if (sch == "421") sch = "42";
            if (lblprj.Text == "CCAD")
            {
                sch = sch.Substring(0, sch.Length - 1);
            }
            //string _path = "../images/" + lblprj.Text + "logo.jpg";
            //FileStream fs = new FileStream(Server.MapPath(_path), FileMode.Open, FileAccess.Read);
            //BinaryReader br = new BinaryReader(fs);
            //byte[] _image = br.ReadBytes((int)fs.Length);
            //br.Close();
            //fs.Close();

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();
            _objdb.DBName = "DBCML";
            _clsproject _objcls1 = new _clsproject();
            _objcls1.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls1, _objdb);

            //_objdb.DBName = "DBCML";
            //_objdb.Dataname = "DB_" + (string)Session["project"];
            //_objdb.photo_rpt = _image;
            //_objdb.project = (string)Session["projectname"];
            //_objdb.Datapath = (string)Session["project"];
            //_objbll.Clear_CasRpt(_objdb);
            //if (sch != "71")
            //{
            _objcls.project_code = lblprj.Text;
            _objdb.DBName = "DBCML";
            _objdb.Dataname = "DB_" + lblprj.Text;
            _objdb.photo_rpt = null;
            _objdb.project = _objbll.Get_ProjectName(_objcls, _objdb);
            _objdb.Datapath = lblprj.Text;
            _objdb.rpt = Convert.ToInt32(sch);
            _objdb.cas = sch;

            if (sch == "10" && lblprj.Text == "CCAD")
                _objbll.Generate_CAS_RPT_1(_objdb);
            else if (lblprj.Text == "HMIM"|| lblprj.Text == "14211")
            {
                if (!String.IsNullOrEmpty(Request.QueryString["Div"]))
                {
                    lbldiv.Text = Request.QueryString["Div"].ToString();
                    _objdb.Div = Convert.ToInt32(Request.QueryString["Div"].ToString());

                }
               
                _objbll.Generate_CAS_RPT_BLG(_objdb);
            }
            else
                _objbll.Generate_CAS_RPT(_objdb);
            //}

            //int count = 0;
            //foreach (var row in _Rptdata)
            //{
            //    //count += 1;
            //    _objdb.rpt = Convert.ToInt32(row["C_id"].ToString());
            //    _objbll.Generate_CASsheet_RPT(_objdb);
            //}
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + count.ToString() + "');", true);
        }
        ReportDocument cryRpt = new ReportDocument();
        //protected void Page_Unload(object sender, EventArgs e)
        //{
        //        cryRpt.Dispose();
        //        cryRpt.Close();
        //}
        private void Generate_Reports(string sch)
        {

            
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            Insert_ReportData(sch);
            //_objbll.CAS_PKG_SUM_RPT(_objdb);
            if (sch == "1" || sch == "5")
            {
                if (lblprj.Text == "ASAO")
                    cryRpt.Load(Server.MapPath("cas_lv2.rpt"));
                else if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_lv_kaia.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "OPH")
                    cryRpt.Load(Server.MapPath("cas_lv_oph.rpt"));
                else if (lblprj.Text == "HMIM")
                {
                    cryRpt.Load(Server.MapPath("cas_lv_HMIM.rpt"));
                    string _facility = Get_Building_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "demo")
                    cryRpt.Load(Server.MapPath("cas_lv_demo.rpt"));
                else if (lblprj.Text == "ARSD")
                    cryRpt.Load(Server.MapPath("cas_lv_pcd1.rpt"));
                else if (isPcdProject)
                {
                    cryRpt.Load(Server.MapPath("cas_lv_pcd.rpt"));

                    cryRpt.SetParameterValue("Sum_QtyPlanned1", Session["Sum_QtyPlanned1"].ToString());
                    cryRpt.SetParameterValue("Sum_QtyPlanned2", Session["Sum_QtyPlanned2"].ToString());
                    cryRpt.SetParameterValue("Sum_QtyPlanned3", Session["Sum_QtyPlanned3"].ToString());

                    cryRpt.SetParameterValue("Sum_PerPlanned1", Session["Sum_PerPlanned1"].ToString());
                    cryRpt.SetParameterValue("Sum_PerPlanned2", Session["Sum_PerPlanned2"].ToString());
                    cryRpt.SetParameterValue("Sum_PerPlanned3", Session["Sum_PerPlanned3"].ToString());

                    cryRpt.SetParameterValue("Sum_Percom1", Session["Sum_Percom1"].ToString());
                    cryRpt.SetParameterValue("Sum_Percom2", Session["Sum_Percom2"].ToString());
                    cryRpt.SetParameterValue("Sum_Percom3", Session["Sum_Percom3"].ToString());

                    cryRpt.SetParameterValue("Sum_Poverall", Session["Sum_Poverall"].ToString());
                    cryRpt.SetParameterValue("Sum_Overall", Session["Sum_Overall"].ToString());
                }
                else if (lblprj.Text == "MOE")
                    cryRpt.Load(Server.MapPath("cas_lv_MOE.rpt"));
                else
                    cryRpt.Load(Server.MapPath("cas_lv.rpt"));
            }
            else if (sch == "51" || sch == "441")
            {
                cryRpt.Load(Server.MapPath("cas_lv1.rpt"));
                cryRpt.SetParameterValue("sch", Convert.ToInt32(sch));
            }
            else if (sch == "2")
            {
                if (lblprj.Text == "ASAO")
                    cryRpt.Load(Server.MapPath("cas_mv2.rpt"));
                else if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_mv_kaia.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "HMIM")
                {
                    cryRpt.Load(Server.MapPath("cas_mv_HMIM.rpt"));
                    string _facility = Get_Building_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (isPcdProject)
                {
                    cryRpt.Load(Server.MapPath("cas_mv_pcd.rpt"));


                    //Session["Sum_QtyPlanned1"] = "1"; Session["Sum_QtyPlanned2"] = "2";
                    //Session["Sum_PerPlanned1"] = "3"; Session["Sum_PerPlanned2"] = "4";
                    //Session["Sum_Percom1"] = "5"; Session["Sum_Percom2"] = "6";
                    //Session["Sum_Poverall"] = "7"; Session["Sum_Overall"] = "8";

                    cryRpt.SetParameterValue("Sum_QtyPlanned1", Session["Sum_QtyPlanned1"].ToString());
                    cryRpt.SetParameterValue("Sum_QtyPlanned2", Session["Sum_QtyPlanned2"].ToString());

                    cryRpt.SetParameterValue("Sum_PerPlanned1", Session["Sum_PerPlanned1"].ToString());
                    cryRpt.SetParameterValue("Sum_PerPlanned2", Session["Sum_PerPlanned2"].ToString());

                    cryRpt.SetParameterValue("Sum_Percom1", Session["Sum_Percom1"].ToString());
                    cryRpt.SetParameterValue("Sum_Percom2", Session["Sum_Percom2"].ToString());


                    cryRpt.SetParameterValue("Sum_Poverall", Session["Sum_Poverall"].ToString());
                    cryRpt.SetParameterValue("Sum_Overall", Session["Sum_Overall"].ToString());



                }
                else
                    cryRpt.Load(Server.MapPath("cas_mv.rpt"));
            }
            else if (sch == "1211" || sch == "1191" || sch == "1181")
            {
                cryRpt.Load(Server.MapPath("cas_MV1.rpt"));
                cryRpt.SetParameterValue("sch", Convert.ToInt32(sch));
            }
            else if (sch == "3")
            {
                if (lblprj.Text == "ASAO")
                    cryRpt.Load(Server.MapPath("cas_tx1.rpt"));
                else if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_tx_kaia.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "HMIM")
                {
                    cryRpt.Load(Server.MapPath("cas_tx_HMIM.rpt"));
                    string _facility = Get_Building_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (isPcdProject)
                {
                    cryRpt.Load(Server.MapPath("cas_tx_pcd.rpt"));

                    cryRpt.SetParameterValue("TxQty", (string)Request.QueryString["hdnTxQty"]);
                    cryRpt.SetParameterValue("TxP", (string)Request.QueryString["hdnTxP"]);
                    cryRpt.SetParameterValue("TXA", (string)Request.QueryString["hdnTXA"]);
                    cryRpt.SetParameterValue("CaQty", (string)Request.QueryString["hdnCaQty"]);
                    cryRpt.SetParameterValue("CaP", (string)Request.QueryString["hdnCaP"]);
                    cryRpt.SetParameterValue("CaA", (string)Request.QueryString["hdnCaA"]);
                    cryRpt.SetParameterValue("PLOverall", (string)Request.QueryString["hdnPLOverall"]);
                    cryRpt.SetParameterValue("ACOverall", (string)Request.QueryString["hdnACOverall"]);

                }
                else
                    cryRpt.Load(Server.MapPath("cas_tx.rpt"));
            }
            else if (sch == "31" || sch == "1201")
            {
                if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_css.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else
                {
                    cryRpt.Load(Server.MapPath("cas_tr1.rpt"));
                    cryRpt.SetParameterValue("sch", Convert.ToInt32(sch));
                }
            }
            else if (sch == "4")
            {
                if (lblprj.Text == "ASAO")
                    cryRpt.Load(Server.MapPath("cas_gen2.rpt"));
                else if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_gen_kaia.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "OPH")
                    cryRpt.Load(Server.MapPath("cas_gen_oph.rpt"));
                else if (lblprj.Text == "HMIM")
                {
                    cryRpt.Load(Server.MapPath("cas_gen_HMIM.rpt"));
                    string _facility = Get_Building_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (isPcdProject)
                {
                    cryRpt.Load(Server.MapPath("cas_gen_pcd.rpt"));

                    cryRpt.SetParameterValue("Sum_QtyPlanned1", Session["Sum_QtyPlanned1"].ToString());
                    cryRpt.SetParameterValue("Sum_QtyPlanned2", Session["Sum_QtyPlanned2"].ToString());
                    cryRpt.SetParameterValue("Sum_QtyPlanned3", Session["Sum_QtyPlanned3"].ToString());

                    cryRpt.SetParameterValue("Sum_PerPlanned1", Session["Sum_PerPlanned1"].ToString());
                    cryRpt.SetParameterValue("Sum_PerPlanned2", Session["Sum_PerPlanned2"].ToString());
                    cryRpt.SetParameterValue("Sum_PerPlanned3", Session["Sum_PerPlanned3"].ToString());

                    cryRpt.SetParameterValue("Sum_Percom1", Session["Sum_Percom1"].ToString());
                    cryRpt.SetParameterValue("Sum_Percom2", Session["Sum_Percom2"].ToString());
                    cryRpt.SetParameterValue("Sum_Percom3", Session["Sum_Percom3"].ToString());

                    cryRpt.SetParameterValue("Sum_Poverall", Session["Sum_Poverall"].ToString());
                    cryRpt.SetParameterValue("Sum_Overall", Session["Sum_Overall"].ToString());
                }
                else
                    cryRpt.Load(Server.MapPath("cas_gen.rpt"));
            }
            else if (sch == "41" && lblprj.Text != "123")
                cryRpt.Load(Server.MapPath("cas_gen1.rpt"));
            else if (sch == "6")
            {
                if (lblprj.Text == "ASAO")
                    cryRpt.Load(Server.MapPath("cas_elp.rpt"));
                else if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_e_l_kaia.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "OPH")
                    cryRpt.Load(Server.MapPath("cas_elp_oph.rpt"));
                else if (isPcdProject)
                {
                    cryRpt.Load(Server.MapPath("cas_elp_pcd.rpt"));

                    cryRpt.SetParameterValue("Sum_QtyPlanned1", Session["Sum_QtyPlanned1"].ToString());
                    cryRpt.SetParameterValue("Sum_QtyPlanned2", Session["Sum_QtyPlanned2"].ToString());

                    cryRpt.SetParameterValue("Sum_PerPlanned1", Session["Sum_PerPlanned1"].ToString());
                    cryRpt.SetParameterValue("Sum_PerPlanned2", Session["Sum_PerPlanned2"].ToString());

                    cryRpt.SetParameterValue("Sum_Percom1", Session["Sum_Percom1"].ToString());
                    cryRpt.SetParameterValue("Sum_Percom2", Session["Sum_Percom2"].ToString());


                    cryRpt.SetParameterValue("Sum_Poverall", Session["Sum_Poverall"].ToString());
                    cryRpt.SetParameterValue("Sum_Overall", Session["Sum_Overall"].ToString());

                 
                }

                else if (lblprj.Text == "HMIM")
                {
                    cryRpt.Load(Server.MapPath("cas_e_l_HMIM.rpt"));
                    string _facility = Get_Building_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else
                    cryRpt.Load(Server.MapPath("cas_e_l.rpt"));
            }
            else if (sch == "61")
                cryRpt.Load(Server.MapPath("cas_elp1.rpt"));
            else if (sch == "7")
            {
                if (lblprj.Text == "ASAO")
                    cryRpt.Load(Server.MapPath("cas_emg1.rpt"));
                else if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_emg_kaia.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "OPH")
                    cryRpt.Load(Server.MapPath("cas_emg_oph.rpt"));
                else if (isPcdProject)
                {
                    cryRpt.Load(Server.MapPath("cas_emg_pcd.rpt"));

                    cryRpt.SetParameterValue("Sum_Qty", Session["Sum_Qty"].ToString());
                    cryRpt.SetParameterValue("Sum_QtyPlanned1", Session["Sum_QtyPlanned1"].ToString());
                    cryRpt.SetParameterValue("Sum_Percom1", Session["Sum_Percom1"].ToString());

                    cryRpt.SetParameterValue("Sum_Poverall", Session["Sum_Poverall"].ToString());
                    cryRpt.SetParameterValue("Sum_Overall", Session["Sum_Overall"].ToString());
                }
                else if (lblprj.Text == "HMIM")
                {
                    cryRpt.Load(Server.MapPath("cas_emg_HMIM.rpt"));
                    string _facility = Get_Building_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else
                    cryRpt.Load(Server.MapPath("cas_emg.rpt"));
            }
            else if (sch == "71")
                cryRpt.Load(Server.MapPath("cas_cbs1.rpt"));
            else if (sch == "8")
                if (lblprj.Text == "14211")
                    cryRpt.Load(Server.MapPath("cas_mec_kaia.rpt"));
                else if (lblprj.Text == "HMIM")
                {
                    cryRpt.Load(Server.MapPath("cas_mec_HMIM.rpt"));
                    string _facility = Get_Building_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "OPH")
                    cryRpt.Load(Server.MapPath("cas_me_oph.rpt"));
                else if (isPcdProject)
                {
                    cryRpt.Load(Server.MapPath("cas_me_pcd.rpt"));
                    cryRpt.SetParameterValue("head", "CAS M1 Mechanical Services Commissioning Activity Schedule");
                    cryRpt.SetParameterValue("PLpcom", (string)Request.QueryString["PLpcom"]);
                    cryRpt.SetParameterValue("PLpcomper", Request.QueryString["PLpcomper"]);
                    cryRpt.SetParameterValue("ACpcom", Request.QueryString["ACpcom"]);
                    cryRpt.SetParameterValue("ACpcomper", Request.QueryString["ACpcomper"]);
                    cryRpt.SetParameterValue("PLcom", Request.QueryString["PLcom"]);
                    cryRpt.SetParameterValue("PLcomper", Request.QueryString["PLcomper"]);
                    cryRpt.SetParameterValue("ACcom", Request.QueryString["ACcom"]);
                    cryRpt.SetParameterValue("ACcomper", Request.QueryString["ACcomper"]);
                    cryRpt.SetParameterValue("PLOverall", Request.QueryString["PLOverall"]);
                    cryRpt.SetParameterValue("ACOverall", Request.QueryString["ACOverall"]);
                }
                else
                    cryRpt.Load(Server.MapPath("cas_mec.rpt"));
            else if (sch == "81" || sch == "511" || sch == "521" || sch == "531" || sch == "541" || sch == "551" || sch == "561" || sch == "571" || sch == "581" || sch == "591" || sch == "601" || sch == "621" || sch == "611" || sch == "631" || sch == "641" || sch == "651" || sch == "661" || sch == "671" || sch == "681" || sch == "691" || sch == "701" || sch == "711" || sch == "721" || sch == "731" || sch == "741" || sch == "751" || sch == "761" || sch == "771" || sch == "781" || sch == "791" || sch == "801" || sch == "811" || sch == "821" || sch == "831" || sch == "841")
            {
                cryRpt.Load(Server.MapPath("cas_mec1.rpt"));
                cryRpt.SetParameterValue("sch", Convert.ToInt32(sch));
            }
            else if (sch == "9")
                if (lblprj.Text == "14211")
                    cryRpt.Load(Server.MapPath("cas_fd_kaia.rpt"));
                else if (lblprj.Text == "HMIM")
                {
                    string _facility = Get_Building_Name();
                    cryRpt.Load(Server.MapPath("cas_fd_HMIM.rpt"));
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "OPH")
                    cryRpt.Load(Server.MapPath("cas_fd_oph.rpt"));
                else if (isPcdProject)
                {
                    cryRpt.Load(Server.MapPath("cas_fd_pcd.rpt"));
                    cryRpt.SetParameterValue("Pl", Request.QueryString["Pl"]);
                    cryRpt.SetParameterValue("Ac", Request.QueryString["Ac"]);
                }
                else if (lblprj.Text == "ASAO")
                    cryRpt.Load(Server.MapPath("cas_fd2.rpt"));
                else
                    cryRpt.Load(Server.MapPath("cas_fd.rpt"));
            else if (sch == "401" || sch == "301" || sch == "311" || sch == "321" || sch == "331" || sch == "341" || sch == "351" || sch == "361" || sch == "371" || sch == "381" || sch == "391")
            {
                cryRpt.Load(Server.MapPath("cas_fd1.rpt"));
                cryRpt.SetParameterValue("sch", Convert.ToInt32(sch));
            }
            else if (sch == "17")
                if (lblprj.Text == "14211")
                    cryRpt.Load(Server.MapPath("cas_ph1_kaia.rpt"));
                else if (lblprj.Text == "OPH")
                    cryRpt.Load(Server.MapPath("cas_ph1_oph.rpt"));
                else if (isPcdProject)
                {
                    cryRpt.Load(Server.MapPath("cas_me_pcd.rpt"));
                    cryRpt.SetParameterValue("head", "CAS PH1 Public Health Services Commissioning Activity Schedule");
                    cryRpt.SetParameterValue("PLpcom", (string)Request.QueryString["PLpcom"]);
                    cryRpt.SetParameterValue("PLpcomper", Request.QueryString["PLpcomper"]);
                    cryRpt.SetParameterValue("ACpcom", Request.QueryString["ACpcom"]);
                    cryRpt.SetParameterValue("ACpcomper", Request.QueryString["ACpcomper"]);
                    cryRpt.SetParameterValue("PLcom", Request.QueryString["PLcom"]);
                    cryRpt.SetParameterValue("PLcomper", Request.QueryString["PLcomper"]);
                    cryRpt.SetParameterValue("ACcom", Request.QueryString["ACcom"]);
                    cryRpt.SetParameterValue("ACcomper", Request.QueryString["ACcomper"]);
                    cryRpt.SetParameterValue("PLOverall", Request.QueryString["PLOverall"]);
                    cryRpt.SetParameterValue("ACOverall", Request.QueryString["ACOverall"]);
                }
                else
                    cryRpt.Load(Server.MapPath("cas_ph1.rpt"));
            else if (sch == "171" || sch == "851" || sch == "861" || sch == "871" || sch == "881" || sch == "891" || sch == "901" || sch == "991" || sch == "1071" || sch == "1081" || sch == "1171")
            {
                cryRpt.Load(Server.MapPath("cas_4A.rpt"));
                cryRpt.SetParameterValue("sch", Convert.ToInt32(sch));
            }
            else if (sch == "18")
                if (lblprj.Text == "14211")
                    cryRpt.Load(Server.MapPath("cas_ph2_kaia.rpt"));
                else if (lblprj.Text == "OPH")
                    cryRpt.Load(Server.MapPath("cas_ph2_oph.rpt"));
                else if (isPcdProject)
                    cryRpt.Load(Server.MapPath("cas_ph2_pcd.rpt"));
                else
                    cryRpt.Load(Server.MapPath("cas_ph2.rpt"));
            else if (sch == "181" || sch == "1011" || sch == "971")
            {
                cryRpt.Load(Server.MapPath("cas_4B.rpt"));
                cryRpt.SetParameterValue("sch", Convert.ToInt32(sch));
            }
            else if (sch == "19")
                if (lblprj.Text == "14211")
                    cryRpt.Load(Server.MapPath("cas_ph3_kaia.rpt"));
                else if (lblprj.Text == "OPH")
                    cryRpt.Load(Server.MapPath("cas_ph3_oph.rpt"));
                else if (isPcdProject)
                {
                    cryRpt.Load(Server.MapPath("cas_ph3_pcd.rpt"));
                    cryRpt.SetParameterValue("Pl", Request.QueryString["Pl"]);
                    cryRpt.SetParameterValue("Ac", Request.QueryString["Ac"]);
                }
                else
                    cryRpt.Load(Server.MapPath("cas_ph3.rpt"));
            else if (sch == "191" || sch == "1021")
                cryRpt.Load(Server.MapPath("cas_4C.rpt"));
            else if (sch == "20")
                if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_bms_kaia.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "HMIM")
                {
                    cryRpt.Load(Server.MapPath("cas_bms_HMIM.rpt"));
                    string _facility = Get_Building_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "OPH")
                    cryRpt.Load(Server.MapPath("cas_bms_oph.rpt"));
                else if (isPcdProject)
                    cryRpt.Load(Server.MapPath("cas_bms_pcd.rpt"));
                else
                    cryRpt.Load(Server.MapPath("cas_bms.rpt"));
            else if (sch == "15")
            {
                if (lblprj.Text == "HMIM")
                {
                    cryRpt.Load(Server.MapPath("cas_grms_HMIM.rpt"));
                    string _facility = Get_Building_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (isPcdProject)
                    cryRpt.Load(Server.MapPath("cas_grms_pcd.rpt"));
                else
                    cryRpt.Load(Server.MapPath("cas_VESDA.rpt"));
            }
            else if (sch == "201")
                cryRpt.Load(Server.MapPath("cas_3A.rpt"));
            else if (sch == "231")
                cryRpt.Load(Server.MapPath("cas_3B.rpt"));
            else if (sch == "21")
                if (lblprj.Text == "14211")
                    cryRpt.Load(Server.MapPath("cas_flu_kaia.rpt"));
                else if (lblprj.Text == "HMIM")
                {
                    cryRpt.Load(Server.MapPath("cas_flu_HMIM.rpt"));
                    string _facility = Get_Building_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (isPcdProject)
                {
                    cryRpt.Load(Server.MapPath("cas_flu_pcd.rpt"));
                    cryRpt.SetParameterValue("pfsum", (Session["pfsum"]).ToString());
                    cryRpt.SetParameterValue("fvrsum", (Session["fvrsum"]).ToString());
                    cryRpt.SetParameterValue("ccsum", (Session["ccsum"]).ToString());
                    cryRpt.SetParameterValue("facsum", (Session["facsum"]).ToString());
                    cryRpt.SetParameterValue("bfsum", (Session["bfsum"]).ToString());
                    cryRpt.SetParameterValue("ctsum", (Session["ctsum"]).ToString());
                    cryRpt.SetParameterValue("planned", (Session["planned"]).ToString());
                    cryRpt.SetParameterValue("completed", (Session["completed"]).ToString());
                }
                else
                    cryRpt.Load(Server.MapPath("cas_flu.rpt"));
            else if (sch == "10")
                if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_fava_kaia.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "HMIM")
                {
                    cryRpt.Load(Server.MapPath("cas_fava_HMIM.rpt"));
                    string _facility = Get_Building_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "OPH")
                    cryRpt.Load(Server.MapPath("cas_fava_oph.rpt"));
                else if (isPcdProject)
                    cryRpt.Load(Server.MapPath("cas_fava_pcd.rpt"));
                else
                    cryRpt.Load(Server.MapPath("cas_fava.rpt"));
            else if (sch == "101")
                cryRpt.Load(Server.MapPath("cas_3C.rpt"));
            else if (sch == "22")
            {
                if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_acs_kaia.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "OPH")
                    cryRpt.Load(Server.MapPath("cas_acs_oph.rpt"));
                else if (isPcdProject)
                    cryRpt.Load(Server.MapPath("cas_acs_pcd.rpt"));
                else
                    cryRpt.Load(Server.MapPath("cas_acs.rpt"));
            }
            else if (sch == "221")
                cryRpt.Load(Server.MapPath("cas_3E.rpt"));
            else if (sch == "11")
                if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_lcs_kaia.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "HMIM")
                {
                    cryRpt.Load(Server.MapPath("cas_lcs_HMIM.rpt"));
                    string _facility = Get_Building_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "OPH")
                    cryRpt.Load(Server.MapPath("cas_lcs_oph.rpt"));
                else if (isPcdProject)
                    cryRpt.Load(Server.MapPath("cas_lcs_pcd.rpt")); 
                else
                    cryRpt.Load(Server.MapPath("cas_lcs.rpt"));
            else if (sch == "12")
                if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_ict_kaia.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "HMIM")
                {
                    cryRpt.Load(Server.MapPath("cas_scn_HMIM.rpt"));
                    string _facility = Get_Building_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "OPH" )
                    cryRpt.Load(Server.MapPath("cas_scn_oph.rpt"));
                else if (isPcdProject)
                    cryRpt.Load(Server.MapPath("cas_scn_pcd.rpt"));
                else
                    cryRpt.Load(Server.MapPath("cas_scn.rpt"));
            else if (sch == "121")
                cryRpt.Load(Server.MapPath("cas_3F.rpt"));
            else if (sch == "13")
                if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_vss_kaia.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "OPH")
                    cryRpt.Load(Server.MapPath("cas_cctv_oph.rpt"));
                else if (isPcdProject)
                    cryRpt.Load(Server.MapPath("cas_cctv_pcd.rpt"));
                else
                    cryRpt.Load(Server.MapPath("cas_cctv.rpt"));
            else if (sch == "131")
                cryRpt.Load(Server.MapPath("cas_3H.rpt"));
            else if (sch == "14")
                if (lblprj.Text == "14211")
                    cryRpt.Load(Server.MapPath("cas_avi_kaia.rpt"));
                else if (lblprj.Text == "HMIM")
                {
                    cryRpt.Load(Server.MapPath("cas_avi_HMIM.rpt"));
                    string _facility = Get_Building_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                  else if (isPcdProject)
                    cryRpt.Load(Server.MapPath("cas_avi_pcd.rpt"));
                else
                    cryRpt.Load(Server.MapPath("cas_avi.rpt"));
            else if (sch == "141")
                cryRpt.Load(Server.MapPath("cas_3J.rpt"));
            else if (sch == "151")
                cryRpt.Load(Server.MapPath("cas_3G.rpt"));
            else if (sch == "16")
                if (lblprj.Text == "14211")
                    cryRpt.Load(Server.MapPath("cas_elv_kaia.rpt"));
                else if (lblprj.Text == "HMIM")
                {
                    cryRpt.Load(Server.MapPath("cas_elv_HMIM.rpt"));
                    string _facility = Get_Building_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "OPH")
                    cryRpt.Load(Server.MapPath("cas_elv_oph.rpt"));
                else if (isPcdProject)
                    cryRpt.Load(Server.MapPath("cas_elv_pcd.rpt"));
                else
                    cryRpt.Load(Server.MapPath("cas_elv.rpt"));
            else if (sch == "161")
                cryRpt.Load(Server.MapPath("cas_3I.rpt"));
            else if (sch == "241")
                cryRpt.Load(Server.MapPath("cas_3K.rpt"));
            else if (sch == "251")
                cryRpt.Load(Server.MapPath("cas_3L.rpt"));
            else if (sch == "261")
                cryRpt.Load(Server.MapPath("cas_3M.rpt"));
            else if (sch == "271" || sch == "461" || sch == "1031" || sch == "1041" || sch == "1051" || sch == "1061" || sch == "1091" || sch == "1101" || sch == "1111" || sch == "1121" || sch == "1161")
            {
                cryRpt.Load(Server.MapPath("cas_5A.rpt"));
                cryRpt.SetParameterValue("sch", Convert.ToInt32(sch));
            }
            else if (sch == "291")
                cryRpt.Load(Server.MapPath("cas_1G.rpt"));
            else if (sch == "30")
                if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_vcs_kaia.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else
                    cryRpt.Load(Server.MapPath("cas_dfs.rpt"));
            else if (sch == "37")
                if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_SAS.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else
                    cryRpt.Load(Server.MapPath("cas_bc.rpt"));
            else if (sch == "24" || (sch == "41" && lblprj.Text == "123"))
            {
                if (lblprj.Text == "12761")
                    cryRpt.Load(Server.MapPath("cas_cp.rpt"));
                else if (lblprj.Text == "14211")
                    cryRpt.Load(Server.MapPath("cas_cp_kaia.rpt"));
                else if (isPcdProject)
                    cryRpt.Load(Server.MapPath("cas_kle_oph.rpt"));
                else if (lblprj.Text == "123" || lblprj.Text == "11784")
                    cryRpt.Load(Server.MapPath("cas_kle.rpt"));
            }
            else if (lblsch.Text == "25")
            {
                if (lblprj.Text == "OPH")
                    cryRpt.Load(Server.MapPath("cas_ist_oph.rpt"));
                else if (lblprj.Text == "14211")
                    cryRpt.Load(Server.MapPath("cas_IS.rpt"));
                else if (lblprj.Text == "ASAO")
                {
                    cryRpt.Load(Server.MapPath("cas_acm.rpt"));
                    cryRpt.SetParameterValue("type", 1);
                }
            }
            else if (lblsch.Text == "26")
            {
                if (lblprj.Text == "ASAO")
                {
                    cryRpt.Load(Server.MapPath("cas_ccs.rpt"));
                }
                else if (isPcdProject)
                {
                    cryRpt.Load(Server.MapPath("cas_lds_oph.rpt"));
                }
            }
            else if (lblsch.Text == "27" || (lblsch.Text == "23" && (lblprj.Text == "11784" || lblprj.Text == "14211")))
            {
                if (lblprj.Text == "ASAO")
                {
                    cryRpt.Load(Server.MapPath("cas_acm.rpt"));
                    cryRpt.SetParameterValue("type", 2);
                }
                else if (lblprj.Text == "OPH")
                {
                    cryRpt.Load(Server.MapPath("cas_PAVA.rpt"));

                }
                else if (lblprj.Text == "HMIM" || lblprj.Text == "11784" || lblprj.Text == "14211" || lblprj.Text == "OCEC")
                {
                    cryRpt.Load(Server.MapPath("cas_HVT.rpt"));
                    string _facility = (lblprj.Text == "HMIM")?Get_Building_Name():"";
                    cryRpt.SetParameterValue("facility", _facility);
                    cryRpt.SetParameterValue("ProjectCode", lblprj.Text);
                    cryRpt.SetParameterValue("ProjectCode", lblprj.Text, "cassum");
                }
            }
            else if (lblsch.Text == "28")
            {
                if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_AVS.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "HMIM")
                {
                    cryRpt.Load(Server.MapPath("cas_PA.rpt"));
                    string _facility = Get_Building_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "ASAO")
                {
                    cryRpt.Load(Server.MapPath("cas_fes_asao.rpt"));
                }
                else if (lblprj.Text == "OPH")
                {
                    cryRpt.Load(Server.MapPath("cas_MVT.rpt"));
                }
                else
                    cryRpt.Load(Server.MapPath("cas_pas.rpt"));
            }
            else if (lblsch.Text == "32")
            {
                if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_gsmtetra_kaia.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
            }
            else if (lblsch.Text == "29")
            {
                if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_iptv_kaia.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
                else if (lblprj.Text == "ASAO")
                {
                    cryRpt.Load(Server.MapPath("cas_fps_asao.rpt"));
                }
            }
            else if (lblsch.Text == "33")
            {
                if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_mcs_kaia.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
            }
            else if (lblsch.Text == "39")
            {
                if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_CPM.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
            }
            else if (lblsch.Text == "35")
            {
                if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_FUEL.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
            }
            else if (lblsch.Text == "34")
            {
                if (lblprj.Text == "14211")
                {
                    cryRpt.Load(Server.MapPath("cas_UPS.rpt"));
                    string _facility = Get_Facility_Name();
                    cryRpt.SetParameterValue("facility", _facility);
                }
            }
            else if (lblsch.Text == "23")
            {
                if (lblprj.Text == "BCC1")
                {
                    cryRpt.Load(Server.MapPath("cas_LiftEsc.rpt"));
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Not Available');", true);
                return;
            }
            //crConnectionInfo.ServerName = "213.171.197.149,49296";
            //crConnectionInfo.DatabaseName = "DBCML";
            //crConnectionInfo.UserID = "CMLT";
            //crConnectionInfo.Password = "C!m@l#S$q%l";
            crConnectionInfo.ServerName = Constants.CMLTConstants.serverName;
            crConnectionInfo.DatabaseName = Constants.CMLTConstants.dbName;
            crConnectionInfo.UserID = Constants.CMLTConstants.dbUserName;
            crConnectionInfo.Password = Constants.CMLTConstants.dbPassword;
            CrTables = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
            //string _s = "MEP";
            //string selectionformula = "{CAS_RPT.BZONE}='" + _s + "' and {CAS_RPT.CATE}=\"DB\"";
            SelectionFormula(cryRpt, lblzone.Text, lblcat.Text,lblfl.Text,lblfd.Text);
            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.DataBind();
            Session["Report"] = cryRpt;

           
            if (GetAccessLevel() == "Read Only")
            { CrystalReportViewer1.HasExportButton = false; }

        }

        private string GetAccessLevel()
        {
            BLL_Dml bl = new BLL_Dml();
            _database db = new _database();
            db.DBName = "dbCML";
            _clsuser cl = new _clsuser();
            cl.uid = (string)Session["uid"];
            cl.project_code = lblprj.Text;
            cl.mode = 2;
            return bl.Get_CMSAccess(cl, db);
           
        }
        private string Get_Facility_Name()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.sch = Convert.ToInt32(lbldiv.Text);
            string facilityName = (lblprj.Text == "14211") ? (_objbll.Get_Facility_Name(_objcls, _objdb)) : (_objbll.Get_Building_Name(_objcls, _objdb));
            return facilityName;
        }
        private string Get_Building_Name()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_HMIM";
            _objcls.sch = Convert.ToInt32(lbldiv.Text);
            return _objbll.Get_Building_Name(_objcls, _objdb);
        }
        private void SelectionFormula(ReportDocument rptDoc, string _el1, string _el2, string _el3, string _el4)
        {
            string _selectionFormula = "";
            if (_el1 == "") _el1 = "All";
            if (_el2 == "") _el2 = "All";
            if (_el3 == "") _el3 = "All";
            if (_el4 == "") _el4 = "All";
            rptDoc.SetParameterValue("bz", _el1);
            rptDoc.SetParameterValue("cat", _el2);
            rptDoc.SetParameterValue("fl", _el3);
            rptDoc.SetParameterValue("ff", _el4);
            if (lblzero.Text !="0")
            {
                if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All")
                {
                    return;
                }
                else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All")
                {
                    _selectionFormula = "{CAS_RPT.BZONE}='" + _el1 + "'";
                }
                else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All")
                {
                    _selectionFormula = "{CAS_RPT.BZONE}='" + _el1 + "' AND  {CAS_RPT.CATE}='" + _el2 + "'";
                }
                else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 == "All")
                {
                    _selectionFormula = "{CAS_RPT.BZONE}='" + _el1 + "' AND  {CAS_RPT.CATE}='" + _el2 + "' AND  {CAS_RPT.FLEVEL}='" + _el3 + "'";
                }
                else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All")
                {
                    _selectionFormula = "{CAS_RPT.BZONE}='" + _el1 + "' AND  {CAS_RPT.CATE}='" + _el2 + "' AND  {CAS_RPT.FLEVEL}='" + _el3 + "' AND  {CAS_RPT.FFROM}='" + _el4 + "'";
                }
                else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 == "All")
                {
                    _selectionFormula = "{CAS_RPT.BZONE}='" + _el1 + "' AND  {CAS_RPT.FLEVEL}='" + _el3 + "'";
                }
                else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All")
                {
                    _selectionFormula = "{CAS_RPT.BZONE}='" + _el1 + "' AND  {CAS_RPT.FLEVEL}='" + _el3 + "' AND  {CAS_RPT.FFROM}='" + _el4 + "'";
                }
                else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All")
                {
                    _selectionFormula = "{CAS_RPT.BZONE}='" + _el1 + "' AND  {CAS_RPT.FFROM}='" + _el4 + "'";
                }
                else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All")
                {
                    _selectionFormula = "{CAS_RPT.CATE}='" + _el2 + "'";
                }
                else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 == "All")
                {
                    _selectionFormula = "{CAS_RPT.CATE}='" + _el2 + "' AND  {CAS_RPT.FLEVEL}='" + _el3 + "'";
                }
                else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All")
                {
                    _selectionFormula = "{CAS_RPT.CATE}='" + _el2 + "' AND  {CAS_RPT.FFROM}='" + _el4 + "'";
                }
                else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All")
                {
                    _selectionFormula = "{CAS_RPT.CATE}='" + _el2 + "' AND  {CAS_RPT.FLEVEL}='" + _el3 + "' AND  {CAS_RPT.FFROM}='" + _el4 + "'";
                }
                else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All")
                {
                    _selectionFormula = "{CAS_RPT.FLEVEL}='" + _el3 + "'";
                }
                else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All")
                {
                    _selectionFormula = "{CAS_RPT.FLEVEL}='" + _el3 + "' AND  {CAS_RPT.FFROM}='" + _el4 + "'";
                }
                else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All")
                {
                    _selectionFormula = "{CAS_RPT.FFROM}='" + _el4 + "'";
                }
            }
            else
            {
                if (lblsch.Text == "5")
                    _selectionFormula = "{CAS_RPT.COMP1}='0.00' AND {CAS_RPT.N4}='0' AND {CAS_RPT.N5}='0'";
                else if (lblsch.Text == "6")
                    _selectionFormula = "{CAS_RPT.T1}='0' AND {CAS_RPT.T6}='0' AND {CAS_RPT.T9}='0' AND {CAS_RPT.T10}='0'";
                else if (lblsch.Text=="8")
                    _selectionFormula = "{CAS_RPT.T1}='0' AND {CAS_RPT.T2}='0' AND {CAS_RPT.T3}='0'";
                else if (lblsch.Text == "4")
                    _selectionFormula = "{CAS_RPT.T1}='0' AND {CAS_RPT.T2}='0' AND {CAS_RPT.T3}='0' AND {CAS_RPT.T6}='0' AND {CAS_RPT.T7}='0'";
                else if (lblsch.Text == "9")
                    _selectionFormula = "({CAS_RPT.T1}='0' AND {CAS_RPT.T2}='0' AND {CAS_RPT.T3}='0' AND {CAS_RPT.T4}='0' AND {CAS_RPT.T5}='0' AND {CAS_RPT.T6}='0' AND {CAS_RPT.T7}='0') OR ({CAS_RPT.T1}='' AND {CAS_RPT.T2}='' AND {CAS_RPT.T3}='' AND {CAS_RPT.T4}='' AND {CAS_RPT.T5}='' AND {CAS_RPT.T6}='' AND {CAS_RPT.T7}='') OR ({CAS_RPT.T1}='0' AND {CAS_RPT.T2}='0' AND {CAS_RPT.T3}='0' AND {CAS_RPT.T4}='N/A' AND {CAS_RPT.T5}='N/A' AND {CAS_RPT.T6}='N/A' AND {CAS_RPT.T7}='N/A') OR ({CAS_RPT.T1}='' AND {CAS_RPT.T2}='' AND {CAS_RPT.T3}='' AND {CAS_RPT.T4}='N/A' AND {CAS_RPT.T5}='N/A' AND {CAS_RPT.T6}='N/A' AND {CAS_RPT.T7}='N/A') OR ({CAS_RPT.T1}='0' AND {CAS_RPT.T2}='0' AND {CAS_RPT.T3}='0' AND {CAS_RPT.T4}='' AND {CAS_RPT.T5}='' AND {CAS_RPT.T6}='' AND {CAS_RPT.T7}='') OR ({CAS_RPT.T1}='N/A' AND {CAS_RPT.T2}='N/A' AND {CAS_RPT.T3}='N/A' AND {CAS_RPT.T4}='0' AND {CAS_RPT.T5}='0' AND {CAS_RPT.T6}='0' AND {CAS_RPT.T7}='0') OR ({CAS_RPT.T1}='N/A' AND {CAS_RPT.T2}='N/A' AND {CAS_RPT.T3}='N/A' AND {CAS_RPT.T4}='' AND {CAS_RPT.T5}='' AND {CAS_RPT.T6}='' AND {CAS_RPT.T7}='')";
                else if (lblsch.Text == "22")
                    _selectionFormula = "{CAS_RPT.COMP5}='0.00'";
                else if (lblsch.Text == "10")
                    _selectionFormula = "{CAS_RPT.T1}='0' AND {CAS_RPT.T2}='0' AND {CAS_RPT.T3}='0' AND {CAS_RPT.T4}='0' AND {CAS_RPT.T5}='0' AND {CAS_RPT.T6}='0' AND {CAS_RPT.T7}='0' AND {CAS_RPT.T8}='0' AND {CAS_RPT.T9}='0'";
                else if (lblsch.Text == "11")
                    _selectionFormula = "{CAS_RPT.T1}='0' AND {CAS_RPT.T2}='0' AND {CAS_RPT.T3}='0' AND {CAS_RPT.T4}='0'";
                else if (lblsch.Text == "12")
                    _selectionFormula = "{CAS_RPT.T1}='0'";
                else if (lblsch.Text == "7")
                    _selectionFormula = "{CAS_RPT.T1}='0' AND {CAS_RPT.T2}='0' AND {CAS_RPT.T3}='0' AND {CAS_RPT.T4}='0' AND {CAS_RPT.T5}='0' AND {CAS_RPT.T6}='0' AND {CAS_RPT.T7}='0'";
                else if (lblsch.Text == "21")
                    _selectionFormula = "{CAS_RPT.COMP1}='0.00'";
                else if (lblsch.Text == "13")
                    _selectionFormula = "{CAS_RPT.COMP4}='0.00'";
                else if (lblsch.Text == "14")
                    _selectionFormula = "{CAS_RPT.COMP3}='0.00'";
                else if (lblsch.Text == "16")
                    _selectionFormula = "{CAS_RPT.T1}='0' AND {CAS_RPT.T2}='0' AND {CAS_RPT.T3}='0' AND {CAS_RPT.T4}='0' AND {CAS_RPT.T5}='0'";
                else if (lblsch.Text == "20")
                    _selectionFormula = "{CAS_RPT.T1}='0' AND {CAS_RPT.T2}='0' AND {CAS_RPT.T3}='0' AND {CAS_RPT.T4}='0' AND {CAS_RPT.T5}='0' AND {CAS_RPT.T6}='0'";
                else if (lblsch.Text == "17")
                    _selectionFormula = "{CAS_RPT.T1}='0' AND {CAS_RPT.T2}='0' AND {CAS_RPT.T3}='0'";
                else if (lblsch.Text == "18")
                    _selectionFormula = "{CAS_RPT.T1}='0' AND {CAS_RPT.T2}='0' AND {CAS_RPT.T3}='0' AND {CAS_RPT.T4}='0' AND {CAS_RPT.T5}='0' AND {CAS_RPT.T6}='0'";
                else if (lblsch.Text == "19")
                    _selectionFormula = "{CAS_RPT.COMP1}='0.00'";
            }
            rptDoc.RecordSelectionFormula = _selectionFormula;
            //return _selectionFormula;
        }
        private void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                string _sch = _prm.Substring(0, _prm.IndexOf("_P"));
                string _prj = _prm.Substring(_prm.IndexOf("_P") + 2, _prm.IndexOf("_B") - (_prm.IndexOf("_P") + 2));
                lblzone.Text = _prm.Substring(_prm.IndexOf("_B") + 2, _prm.IndexOf("_F") - (_prm.IndexOf("_B") + 2));
                lblzone.Text = lblzone.Text.Replace("<>", "&");
                lblfl.Text = _prm.Substring(_prm.IndexOf("_F") + 2, _prm.IndexOf("_C") - (_prm.IndexOf("_F") + 2));
                lblcat.Text = _prm.Substring(_prm.IndexOf("_C") + 2, _prm.IndexOf("_D") - (_prm.IndexOf("_C") + 2));
                lblfd.Text = _prm.Substring(_prm.IndexOf("_D") + 2, _prm.IndexOf("_Z") - (_prm.IndexOf("_D") + 2));
                lblzero.Text = _prm.Substring(_prm.IndexOf("_Z") + 2);
                lblprj.Text = _prj;
                lblsch.Text = _sch;
                Generate_Reports(_sch);

                //Insert_ReportData();
            }
            else
            {
                if (Session["Report"] != null)
                {
                    CrystalReportViewer1.ReportSource = (ReportDocument)Session["Report"];
                    CrystalReportViewer1.DataBind();
                }

            }
            isPcdProject = (Array.IndexOf(Constants.CMLTConstants.PcdProjects, lblprj.Text) > -1) ? true : false;
        }
    }
}
