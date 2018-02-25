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
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Common;

namespace CmlTechniques.CMS
{
    public partial class Import : System.Web.UI.Page
    {
        public static DataTable _dtable;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Load_Service();
                //Load_Cassheet_Master();
                string _prm = Request.QueryString[0].ToString();
                lbsch.Text = Request.QueryString["id"].ToString();
                lbprj.Text = Request.QueryString["prj"].ToString();
                lblsec.Text = Request.QueryString["sec"].ToString();


            }
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            uploadFiles();
            Insert_to_DB();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Documents Uploaded!');", true);
        }

        protected void drservice_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (drservice.SelectedItem.Text == "-- Select Service --") return;
            //Load_Cassheet();
        }

        private void uploadFiles()
        {
            HttpFileCollection hfc = Request.Files;
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                if (hpf.ContentLength > 0)
                {
                    FileInfo _info = new FileInfo(Server.MapPath("Cassheet") + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                    if (_info.Exists == true) _info.Delete();
                    hpf.SaveAs(Server.MapPath("Cassheet") + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                    Session["xls"] = System.IO.Path.GetFileName(hpf.FileName);
                }
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Documents Uploaded!');", true);
            }
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
        private void Insert_to_DB()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lbprj.Text;
            _clscassheet _objcas = new _clscassheet();
            DataSet _dset = Read_File();
            //UploadError _obj = new UploadError();
            //_obj.clear();
            int _Idx = 0;
            int _Insert = 0;
            foreach (DataRow row in _dset.Tables[0].Rows)
            {
                if (row[0].ToString().Trim().Length != 0)
                {
                    _Idx += 1;
                    string _sch = lbsch.Text;
                    _objcas.c_s_id = Convert.ToInt32(_sch);
                    _objcas.prj_code = lbprj.Text;
                    _objcas.uid = "admin@cmlinternational.net";
                    _objcas.reff = row[0].ToString();
                    _objcas.b_zone = row[1].ToString();
                    _objcas.sch = Convert.ToInt32(_sch);
                    if (lbsch.Text == "25" && lbprj.Text == "12761")
                    {
                        _objcas.sys = 1134;
                        _objcas.cate = "PC";
                        _objcas.f_level = "";
                        _objcas.seq_no = 0;
                        _objcas.desc = row[2].ToString();
                        _objcas.loca = row[3].ToString();
                        if (DateValidation(row[4].ToString()) == true)
                            _objcas.p_power_to = row[4].ToString().Substring(0, 10);
                        else
                            _objcas.p_power_to = row[4].ToString();
                        _objcas.fed_from = row[5].ToString();
                        if (DateValidation(row[6].ToString()) == true)
                            _objcas.sub_st = row[6].ToString().Substring(0, 10);
                        else
                            _objcas.sub_st = row[6].ToString();
                        _objcas.s_c_m = row[7].ToString();
                        _objcas.dev1 = "0";
                        _objcas.dev2 = "0";
                        _objcas.dev3 = "0";
                    }
                    else
                    {
                        _objcas.cate = row[2].ToString();
                        _objcas.sys = _objbll.Get_SysId(_objcas, _objdb);
                        _objcas.f_level = row[3].ToString();
                        int _sqno = 0;
                        if (IsNumeric(row[4].ToString()) == true)
                            _sqno = Convert.ToInt32(row[4].ToString());
                        _objcas.seq_no = _sqno;
                        _objcas.loca = "";
                        _objcas.p_power_to = "";
                        _objcas.fed_from = "";
                        _objcas.sub_st = "";
                        _objcas.desc = "";
                        _objcas.dev1 = "";
                        _objcas.dev2 = "0";
                        _objcas.dev3 = "0";
                        if (_sch == "2" || _sch == "3")
                        {
                            _objcas.loca = row[5].ToString();
                            _objcas.p_power_to = row[7].ToString();
                            _objcas.fed_from = row[6].ToString();
                            _objcas.sub_st = row[8].ToString();
                            if (lbprj.Text == "CCAD")
                                _objcas.dev1 = row[9].ToString();
                            else if (lbprj.Text == "HMIM")
                                _objcas.panel_id = Convert.ToInt32(lblsec.Text);
                        }
                        else if (_sch == "4")
                        {
                            _objcas.loca = row[5].ToString();
                            _objcas.p_power_to = row[7].ToString();
                            _objcas.fed_from = row[6].ToString();
                        }
                        else if (_sch == "5")
                        {
                            _objcas.loca = row[5].ToString();
                            _objcas.p_power_to = row[7].ToString();
                            _objcas.fed_from = row[6].ToString();
                            _objcas.dev1 = row[8].ToString();
                            if (lbprj.Text == "CCAD")
                                _objcas.sub_st = row[9].ToString();
                            if (lbprj.Text == "HMIM")
                                _objcas.panel_id = Convert.ToInt32(lblsec.Text);
                        }
                        else if (_sch == "6")
                        {
                            _objcas.loca = row[5].ToString();
                            _objcas.p_power_to = row[6].ToString();
                            if (lbprj.Text == "HMIM")
                                _objcas.panel_id = Convert.ToInt32(lblsec.Text);
                        }
                        else if (_sch == "7")
                        {
                            _objcas.loca = row[5].ToString();
                            if (lbprj.Text == "CCAD")
                            {
                                _objcas.p_power_to = row[7].ToString();
                                _objcas.fed_from = row[6].ToString();
                                _objcas.dev1 = row[8].ToString();
                                _objcas.sub_st = row[9].ToString();
                            }
                            else
                            {
                                _objcas.dev1 = row[6].ToString();
                            }
                        }
                        else if (_sch == "8")
                        {
                            _objcas.sub_st = row[5].ToString();
                            _objcas.desc = row[5].ToString();
                            _objcas.loca = row[6].ToString();
                            _objcas.fed_from = row[7].ToString();
                            if (lbprj.Text == "CCAD")
                                _objcas.dev1 = row[8].ToString();
                        }
                        else if (_sch == "21")
                        {
                            _objcas.sub_st = row[5].ToString();
                            _objcas.desc = row[5].ToString();
                            _objcas.loca = row[6].ToString();
                            _objcas.dev1 = row[7].ToString();
                        }
                        else if (_sch == "9")
                        {
                            _objcas.sub_st = row[5].ToString();
                            _objcas.desc = row[5].ToString();
                            _objcas.loca = row[6].ToString();
                            if (lbprj.Text == "CCAD")
                            {
                                _objcas.fed_from = row[7].ToString();
                                _objcas.p_power_to = row[8].ToString();
                            }
                            else if (lbprj.Text == "NBO")
                            {
                                _objcas.fed_from = row[7].ToString();
                            }
                        }
                        else if (_sch == "17")
                        {
                            _objcas.sub_st = row[5].ToString();
                            _objcas.desc = row[5].ToString();
                            _objcas.loca = row[6].ToString();
                            _objcas.fed_from = row[7].ToString();
                            if (lbprj.Text == "CCAD")
                            {
                                _objcas.dev1 = row[8].ToString();
                            }
                        }
                        else if (_sch == "18")
                        {

                            if (lbprj.Text == "CCAD")
                            {
                                _objcas.sub_st = row[9].ToString();
                                _objcas.desc = row[5].ToString();
                                _objcas.loca = row[6].ToString();
                                _objcas.fed_from = row[7].ToString();
                                _objcas.p_power_to = row[8].ToString();
                                _objcas.s_c_m = row[10].ToString();
                                _objcas.dev1 = row[11].ToString();
                                _objcas.dev2 = row[12].ToString();
                            }
                            else
                            {
                                _objcas.sub_st = row[5].ToString();
                                _objcas.desc = row[5].ToString();
                                _objcas.dev2 = row[5].ToString();
                                _objcas.dev1 = row[6].ToString();
                            }
                        }
                        else if (_sch == "19")
                        {
                            if (lbprj.Text == "CCAD")
                            {
                                _objcas.sub_st = row[5].ToString();
                                _objcas.desc = row[5].ToString();
                                _objcas.dev1 = row[6].ToString();
                            }
                            else
                            {
                                _objcas.loca = row[5].ToString();
                                _objcas.fed_from = row[6].ToString();
                            }
                        }
                        else if (_sch == "10")
                        {
                            _objcas.loca = row[5].ToString();
                            _objcas.dev2 = row[6].ToString();
                            _objcas.dev1 = row[7].ToString();
                            _objcas.sub_st = row[6].ToString();
                            if (lbprj.Text == "CCAD")
                            {
                                _objcas.p_power_to = row[8].ToString();
                                _objcas.panel_ref = row[9].ToString();
                                _objcas.panel_id = _objbll.get_panel_id(_objcas, _objdb);
                            }
                        }
                        else if (_sch == "20")
                        {
                            _objcas.loca = row[5].ToString();
                            _objcas.fed_from = row[6].ToString();
                            if (lbprj.Text == "CCAD")
                            {
                                _objcas.dev1 = row[7].ToString();
                            }
                            else
                            {
                                _objcas.dev2 = row[8].ToString();
                                _objcas.dev3 = row[7].ToString();
                                _objcas.dev1 = row[9].ToString();
                                _objcas.sub_st = row[8].ToString();
                                _objcas.p_power_to = row[7].ToString();
                            }
                        }
                        else if (_sch == "13")
                        {

                            _objcas.loca = row[5].ToString();
                            if (lbprj.Text == "CCAD")
                            {
                                _objcas.dev1 = row[7].ToString();
                                _objcas.fed_from = row[6].ToString();
                            }
                            else if (lbprj.Text == "NCP")
                            {
                                _objcas.dev1 = row[7].ToString();
                                _objcas.fed_from = row[6].ToString();
                            }
                            else
                            {
                                _objcas.dev1 = row[6].ToString();
                            }
                        }
                        else if (_sch == "22")
                        {
                            _objcas.loca = row[5].ToString();
                            if (lbprj.Text == "CCAD")
                            {
                                _objcas.dev1 = row[7].ToString();
                                _objcas.fed_from = row[6].ToString();
                            }
                            else
                            {
                                _objcas.dev1 = row[6].ToString();
                            }
                        }
                        else if (_sch == "11")
                        {
                            _objcas.loca = row[5].ToString();
                            if (lbprj.Text == "CCAD")
                            {
                                _objcas.panel_ref = row[7].ToString();
                                _objcas.panel_id = _objbll.get_panel_id(_objcas, _objdb);
                                _objcas.dev1 = row[6].ToString();
                            }
                            else
                            {
                                _objcas.dev1 = row[7].ToString();
                                _objcas.dev2 = row[6].ToString();
                                _objcas.sub_st = row[6].ToString();
                            }
                        }
                        else if (_sch == "12")
                        {
                            _objcas.loca = row[5].ToString();
                            if (lbprj.Text == "CCAD")
                            {
                                _objcas.p_power_to = row[6].ToString();
                                _objcas.fed_from = row[7].ToString();
                                _objcas.desc = row[8].ToString();
                                _objcas.sub_st = row[9].ToString();
                                _objcas.dev2 = row[10].ToString();
                                _objcas.dev1 = row[11].ToString();
                            }
                            else
                            {

                                _objcas.dev1 = row[7].ToString();
                                _objcas.fed_from = row[6].ToString();
                            }
                        }
                        else if (_sch == "15")
                        {
                            if (lbprj.Text == "CCAD")
                            {
                                _objcas.p_power_to = row[6].ToString();
                                _objcas.fed_from = row[7].ToString();
                                _objcas.loca = row[5].ToString();
                                _objcas.dev1 = row[8].ToString();
                            }
                            else
                            {
                                _objcas.dev1 = row[5].ToString();
                            }
                        }
                        else if (_sch == "16")
                        {
                            if (lbprj.Text == "CCAD")
                            {
                                _objcas.p_power_to = row[6].ToString();
                                _objcas.fed_from = row[7].ToString();
                                _objcas.loca = row[5].ToString();
                                _objcas.dev1 = row[8].ToString();
                            }
                            else if (lbprj.Text == "NCP")
                            {
                                _objcas.p_power_to = row[6].ToString();
                                _objcas.fed_from = row[7].ToString();
                                _objcas.loca = row[5].ToString();
                                _objcas.dev2 = row[8].ToString();
                                _objcas.dev1 = row[9].ToString();
                                _objcas.sub_st = row[8].ToString();
                            }
                        }
                        else if (_sch == "14")
                        {
                            if (lbprj.Text == "CCAD")
                            {
                                _objcas.loca = row[5].ToString();
                                _objcas.dev1 = row[6].ToString();
                            }
                            else
                            {
                                _objcas.dev1 = row[5].ToString();
                            }
                        }
                        else if (_sch == "23")
                        {
                            _objcas.loca = row[5].ToString();
                            _objcas.fed_from = row[6].ToString();
                            if (lbprj.Text == "CCAD")
                            {
                                _objcas.dev1 = row[7].ToString();
                                _objcas.p_power_to = row[8].ToString();
                            }
                        }
                        else if (_sch == "24" || _sch == "29")
                        {
                            if (lbprj.Text == "CCAD" || lbprj.Text == "NCP")
                            {
                                _objcas.loca = row[5].ToString();
                                _objcas.dev1 = row[7].ToString();
                                _objcas.fed_from = row[6].ToString();
                            }
                        }
                        else if (_sch == "25")
                        {
                            if (lbprj.Text == "CCAD")
                            {
                                _objcas.loca = row[5].ToString();
                                _objcas.dev1 = row[6].ToString();
                            }
                        }
                        else if (_sch == "26")
                        {
                            if (lbprj.Text == "CCAD")
                            {
                                _objcas.loca = row[5].ToString();
                            }
                        }
                        else if (_sch == "27")
                        {
                            _objcas.sub_st = row[5].ToString();
                            _objcas.desc = row[5].ToString();
                            _objcas.loca = row[6].ToString();
                            _objcas.dev1 = row[7].ToString();
                        }
                        else if (_sch == "28")
                        {
                            _objcas.sub_st = row[5].ToString();
                            _objcas.desc = row[5].ToString();
                            _objcas.loca = row[6].ToString();
                            _objcas.fed_from = row[7].ToString();
                            _objcas.p_power_to = row[8].ToString();
                        }
                        else if (_sch == "30")
                        {
                            if (lbprj.Text == "ASAO")
                            {
                                _objcas.desc = row[5].ToString();
                                _objcas.loca = row[6].ToString();
                                _objcas.fed_from = row[7].ToString();
                                _objcas.dev2 = row[9].ToString();
                                _objcas.dev3 = row[8].ToString();
                                _objcas.dev1 = row[10].ToString();
                                _objcas.sub_st = row[9].ToString();
                                _objcas.p_power_to = row[8].ToString();
                            }
                        }
                        else if (_sch == "112" || _sch == "113" || _sch == "114" || _sch == "115" || _sch == "116")
                        {
                            _objcas.desc = row[5].ToString();
                            _objcas.loca = row[6].ToString();
                            _objcas.fed_from = row[7].ToString();
                        }
                        _objcas.s_c_m = "";
                    }


                    //if ((string)Session["sch"] == "10" || (string)Session["sch"] == "16" || (string)Session["sch"] == "20")
                    //    _objcas.dev2 = txtdesc.Text;
                    //else
                    //    _objcas.dev2 = "0";
                    //if ((string)Session["sch"] == "20")
                    //    _objcas.dev3 = txtpprovideto.Text;
                    //else
                    //    _objcas.dev3 = "0";


                    _objcas.mode = 1;
                    _objcas.cas_id = 0;
                    _objcas.Position = _Idx;
                    _objbll.Cassheet_Master(_objcas, _objdb);
                    _Insert += 1;

                }
            }
            string _Msg = _Insert.ToString() + " Rows Uploaded";
            ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('" + _Msg + "');", true);
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
        private DataSet Read_File()
        {
            DataSet ds = new DataSet();
            //FileInfo _info = new FileInfo("http://63.134.201.180/ControlPanel/MEMBER_UPLOADS/" + (string)Session["xls"]);
            FileInfo _info = new FileInfo(Server.MapPath("Cassheet") + "\\" + (string)Session["xls"]);
            if (_info.Exists == false) return ds;
            string filelocation = _info.FullName;
            //string filelocation = "http://63.134.201.180/ControlPanel/MEMBER_UPLOADS/" + (string)Session["xls"];
            OleDbCommand excelCommand = new OleDbCommand(); OleDbDataAdapter excelDataAdapter = new OleDbDataAdapter();
            //string excelConnStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + filelocation + "; Extended Properties ='Excel 8.0;HDR=Yes;IMEX=1'";
            string excelConnStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filelocation + ";Extended Properties=Excel 12.0;Persist Security Info=False";
            OleDbConnection excelConn = new OleDbConnection(excelConnStr);  
            excelConn.Open();
            DataTable dtPatterns = new DataTable();
            string _sch_id = lbsch.Text;
            string _Table = "";
            if (_sch_id == "2")
            {
                if (lbprj.Text == "CCAD")
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`FED_FROM` as FED_FROM,`PROVIDES_POWER_TO` as PROVIDES_POWER_TO,`SUBSTATION_NUMBER` AS SUBSTATION_NUMBER,`NO_OF_CIRCUITS` AS NO_OF_CIRCUITS FROM [E1$]", excelConn);
                else
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`FED_FROM` as FED_FROM,`PROVIDES_POWER_TO` as PROVIDES_POWER_TO,`SUBSTATION` AS SUBSTATION FROM [E1$]", excelConn);
                _Table = "E1";
            }
            else if (_sch_id == "3")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`FED_FROM` as FED_FROM,`PROVIDES_POWER_TO` as PROVIDES_POWER_TO,`SUBSTATION_NUMBER` AS SUBSTATION_NUMBER,`QUANTITY` AS QUANTITY FROM [E2$]", excelConn);
                }
                else
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`FED_FROM` as FED_FROM,`PROVIDES_POWER_TO` as PROVIDES_POWER_TO,`AREA` AS AREA FROM [E2$]", excelConn);
                }
                _Table = "E2";
            }
            else if (_sch_id == "4")
            {
                excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`FED_FROM` as FED_FROM,`PROVIDES_POWER_TO` as PROVIDES_POWER_TO FROM [E5$]", excelConn);
                _Table = "E5";
            }
            else if (_sch_id == "5")
            {
                if (lbprj.Text == "CCAD")
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`FED_FROM` as FED_FROM,`PROVIDES_POWER_TO` as PROVIDES_POWER_TO ,`NO_OF_CIRCUITS` AS NO_OF_CIRCUITS ,`SUBSTATION_NO` AS SUBSTATION_NO FROM [E4$]", excelConn);
                else
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`FED_FROM` as FED_FROM,`PROVIDES_POWER_TO` as PROVIDES_POWER_TO,`NO_OF_CIRCUITS` AS NO_OF_CIRCUITS FROM [E4$]", excelConn);
                _Table = "E4";
            }
            else if (_sch_id == "6")
            {
                excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`PROVIDES_E_L_TO` as PROVIDES_E_L_TO FROM [E3$]", excelConn);
                _Table = "E3";
            }
            else if (_sch_id == "7")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`FED_FROM` as FED_FROM,`PROVIDES_POWER_TO` as PROVIDES_POWER_TO ,`NO_OF_LAMPS` AS NO_OF_LAMPS ,`NO_OF_CIRCUITS` AS NO_OF_CIRCUITS FROM [E6$]", excelConn);
                }
                else
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`NO_OF_EMG_LIGHT` as NO_OF_EMG_LIGHT FROM [E6$]", excelConn);
                }
                _Table = "E6";
            }
            else if (_sch_id == "8")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`DESCRIPTION` as DESCRIPTION,`LOCATION` as LOCATION,`FED_FROM` as FED_FROM,`DESIGN_VOLUME`  as DESIGN_VOLUME FROM [M1$]", excelConn);
                }
                else
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`DESCRIPTION` as DESCRIPTION,`LOCATION` as LOCATION,`FED_FROM` as FED_FROM FROM [M1$]", excelConn);
                }
                _Table = "M1";
            }
            else if (_sch_id == "21")
            {
                excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`DESCRIPTION` as DESCRIPTION,`LOCATION` as LOCATION,`FLUSHING_STAGE` as FLUSHING_STAGE FROM [M2$]", excelConn);
                _Table = "M2";
            }
            else if (_sch_id == "9")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`DESCRIPTION` as DESCRIPTION,`LOCATION` as LOCATION,`PLANT_REF` AS PLANT_REF,`PLANT_DESCR` AS PLANT_DESCR FROM [M3$]", excelConn);
                }
                else if (lbprj.Text == "NBO")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`DESCRIPTION` as DESCRIPTION,`LOCATION` as LOCATION,`FED_FROM` as FED_FROM FROM [M3$]", excelConn);
                }
                else
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`DESCRIPTION` as DESCRIPTION,`LOCATION` as LOCATION FROM [M3$]", excelConn);
                }
                _Table = "M3";
            }
            else if (_sch_id == "17")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`DESCRIPTION` as DESCRIPTION,`LOCATION` as LOCATION,`FED_FROM` AS FED_FROM,`DESIGN_VOLUME` AS DESIGN_VOLUME FROM [PH1$]", excelConn);
                }
                else
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`DESCRIPTION` as DESCRIPTION,`LOCATION` as LOCATION,`FED_FROM` as FED_FROM FROM [PH1$]", excelConn);
                }
                _Table = "PH1";
            }
            else if (_sch_id == "18")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`DESCRIPTION` as DESCRIPTION,`LOCATION` as LOCATION,`FED_FROM` AS FED_FROM,`AREA` AS AREA,`LOAD` AS LOAD,`STARTER_TYPE` AS STARTER_TYPE,`DUTY_V` AS DUTY_V,`DUTY_P` AS DUTY_P FROM [PH2$]", excelConn);
                }
                else 
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`DESCRIPTION` as DESCRIPTION,`QUANTITY` as QUANTITY FROM [PH2$]", excelConn);
                }
                _Table = "PH2";
            }
            else if (_sch_id == "19")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`DESCRIPTION` as DESCRIPTION,`QUANTITY` as QUANTITY FROM [PH3$]", excelConn);
                }
                else
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`FED_FROM` as FED_FROM FROM [PH3$]", excelConn);
                }
                _Table = "PH3";
            }
            else if (_sch_id == "10")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`NOOF_DEVICES` as NOOF_DEVICES,`NOOF_INTERFACES` as NOOF_INTERFACES,`LOOP_CIRCUIT` as LOOP_CIRCUIT,`PANEL_REF` as PANEL_REF FROM [ELV1$]", excelConn);
                }
                else
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`NOOF_DEVICES` as NOOF_DEVICES,`NOOF_INTERFACES` as NOOF_INTERFACES FROM [ELV1$]", excelConn);
                }
                _Table = "ELV1";
            }
            else if (_sch_id == "20")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`SYS_CONTROLLED_MONITORED` as SYS_CONTROLLED_MONITORED,`NOOF_POINTS` as NOOF_POINTS FROM [ELV2$]", excelConn);
                }
                else
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`SYS_CONTROLLED_MONITORED` as SYS_CONTROLLED_MONITORED,`NOOF_POINTS` as NOOF_POINTS,`NOOF_DEVICES` as NOOF_DEVICES,`NOOF_SYSTEM` as NOOF_SYSTEM FROM [ELV2$]", excelConn);
                }
                _Table = "ELV2";
            }
            else if (_sch_id == "13")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`AREA_MONITORED` as AREA_MONITORED,`NOOF_POINTS` as NOOF_POINTS FROM [ELV3$]", excelConn);
                }
                else if (lbprj.Text == "NCP")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`SYS_MONITORED` as SYS_MONITORED,`FED_FROM` as FED_FROM,`NOOF_CAMERAS` as NOOF_CAMERAS FROM [ELV3$]", excelConn);
                }
                else
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`SYS_MONITORED` as SYS_MONITORED,`NOOF_CAMERAS` as NOOF_CAMERAS FROM [ELV3$]", excelConn);
                }
                _Table = "ELV3";
            }
            else if (_sch_id == "22")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`AREA_COVERED` as AREA_COVERED,`NOOF_POINTS` as NOOF_POINTS FROM [ELV4$]", excelConn);
                }
                else
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`SYS_MONITORED` as SYS_MONITORED,`NOOF_DOORS` as NOOF_DOORS FROM [ELV4$]", excelConn);
                }
                _Table = "ELV4";
            }
            else if (_sch_id == "11")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`NO_OF_DEVICES` as NO_OF_DEVICES,`PANEL_REF` as PANEL_REF FROM [ELV5$]", excelConn);
                }
                else
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`AREA_SERVED` as AREA_SERVED,`NOOF_CIRCUITS` as NOOF_CIRCUITS,`NOOF_LIGHTNINGSCENES` as NOOF_LIGHTNINGSCENES FROM [ELV5$]", excelConn);
                }
                _Table = "ELV5";
            }
            else if (_sch_id == "12")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`AREA` as AREA,`FED_TO` as FED_TO,`NO_OF_TEL` as NO_OF_TEL ,`NO_FO` as NO_FO ,`NO_CAT6` as NO_CAT6 ,`NO_CAT3` as NO_CAT3 FROM [ELV6$]", excelConn);
                }
                else
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`CONNECTED_FROM` as CONNECTED_FROM,`NOOF_POINTS` as NOOF_POINTS FROM [ELV6$]", excelConn);
                }
                _Table = "ELV6";
            }
            else if (_sch_id == "15")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`AREA` as AREA,`FED_FROM` as FED_FROM,`NO_OF_POINTS` as NO_OF_POINTS  FROM [ELV7$]", excelConn);
                }
                else
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`NOOF_PANELS` as NOOF_PANELS FROM [ELV7$]", excelConn);
                }
                _Table = "ELV7";
            }
            else if (_sch_id == "16")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`AREA` as AREA,`FED_FROM` as FED_FROM,`NO_OF_VIDEO` as NO_OF_VIDEO  FROM [ELV10$]", excelConn);
                    _Table = "ELV10";
                }
                else if (lbprj.Text == "NCP")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`SYS_CONTROLLED_MONITORED` as SYS_CONTROLLED_MONITORED,`FED_FROM` AS FED_FROM,`NOOF_POINTS` as NOOF_POINTS, `NOOF_DEVICES` as NOOF_DEVICES FROM [ELV9$]", excelConn);
                    _Table = "ELV9";
                }
               
            }
            else if (_sch_id == "14")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`NO_OF_CIRCUITS` as NO_OF_CIRCUITS  FROM [ELV8$]", excelConn);
                }
                else
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`NOOF_PANELS` as NOOF_PANELS FROM [ELV8$]", excelConn);
                }
                _Table = "ELV8";
            }
            else if (_sch_id == "23")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`GATEWAY_LOOP` as GATEWAY_LOOP,`NO_OF_DEVICES` as NO_OF_DEVICES,`SYS_CONTROLLED_MONITORED` as SYS_CONTROLLED_MONITORED FROM [ELV9$]", excelConn);
                }
                else if (lbprj.Text == "NBO")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`FED_FROM` AS FED_FROM FROM [MIS1$]", excelConn);
                }
                else
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`FED_FROM` as FED_FROM FROM [ELV9$]", excelConn);
                }
                _Table = "ELV9";
            }
            else if (_sch_id == "24")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`AREA_COVERED` as AREA_COVERED,`NO_OF_PANEL` as NO_OF_PANEL FROM [ELV11$]", excelConn);
                    _Table = "ELV11";
                }               
                else{
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`CONNECTED_FROM` as CONNECTED_FROM,`NOOF_POINTS` as NOOF_POINTS FROM [ELV10$]", excelConn);
                    _Table = "ELV10";
                }
            }
            else if (_sch_id == "25")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`NO_OF_CODE` as NO_OF_CODE  FROM [ELV12$]", excelConn);
                    _Table = "ELV12";
                }
                else if (lbprj.Text == "12761")
                {
                    excelCommand = new OleDbCommand("SELECT `Pile_No` as Pile_No,`Zone_` as Zone_,`OHMS` as OHMS,`WIR_` as WIR_,`Date_` as Date_,`Status_` as Status_,`Accepted_` as Accepted_,`Comments_` as Comments_  FROM [EPC$]", excelConn);
                    _Table = "EPC";
                }


            }
            else if (_sch_id == "26")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION  FROM [ELV13$]", excelConn);
                }

                _Table = "ELV13";
            }
            else if (_sch_id == "27")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`DESCRIPTION` as DESCRIPTION,`LOCATION` as LOCATION,`NO_OF_POINTS` AS NO_OF_POINTS FROM [MIS1$]", excelConn);
                }
                else
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`DESCRIPTION` as DESCRIPTION,`LOCATION` as LOCATION,`NO_OF_POINTS` AS NO_OF_POINTS FROM [MIS1$]", excelConn);
                }
                _Table = "MIS1";
            }
            else if (_sch_id == "28")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`DESCRIPTION` as DESCRIPTION,`LOCATION` as LOCATION,`FED_FROM_SC` AS FED_FROM_SC,`FED_FROM_ELE` AS FED_FROM_ELE FROM [MIS2$]", excelConn);
                }
                else if (lbprj.Text == "NBO")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`DESCRIPTION` as DESCRIPTION,`LOCATION` as LOCATION,`FED_FROM_SC` AS FED_FROM_SC,`FED_FROM_ELE` AS FED_FROM_ELE FROM [ELV11$]", excelConn);
                }
                else
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`DESCRIPTION` as DESCRIPTION,`LOCATION` as LOCATION,`FED_FROM_SC` AS FED_FROM_SC,`FED_FROM_ELE` AS FED_FROM_ELE FROM [MIS2$]", excelConn);
                }
                _Table = "MIS2";
            }
            else if (_sch_id == "29")
            {
                if (lbprj.Text == "CCAD")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`LOCATION` as LOCATION,`AREA_COVERED` as AREA_COVERED,`NO_OF_CHANNEL` as NO_OF_CHANNEL FROM [E7$]", excelConn);
                }

                _Table = "E7";
            }
            else if (_sch_id == "30")
            {
                if (lbprj.Text == "ASAO")
                {
                    excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`DESCRIPTION` as DESCRIPTION,`LOCATION` as LOCATION,`FED_FROM` as FED_FROM,`NO_GRILLES` as NO_GRILLES,`NO_VAV` as NO_VAV,`NO_CAV` as NO_CAV FROM [M30$]", excelConn);
                }
                _Table = "M30";
            }
            else if (_sch_id == "112" || _sch_id == "113" || _sch_id == "114" || _sch_id == "115" || _sch_id == "116")
            {
                excelCommand = new OleDbCommand("SELECT `ENG_REF` as ENG_REF,`BUILDING_ZONE` as BUILDING_ZONE,`CATEGORY` as CATEGORY,`FLOOR_LEVEL` as FLOOR_LEVEL,`SEQ_NO` as SEQ_NO,`DESCRIPTION` as DESCRIPTION,`LOCATION` as LOCATION,`FED_FROM` as FED_FROM FROM [M112$]", excelConn);
                _Table = "M112";
            }
            excelDataAdapter.SelectCommand = excelCommand;
            excelDataAdapter.Fill(dtPatterns);
            dtPatterns.TableName = _Table;
            ds.Tables.Add(dtPatterns);
            return ds;


        }
    }
}
