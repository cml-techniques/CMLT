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
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace CmlTechniques.CMS
{
    public partial class Service_Summary : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtService;
        public static DataTable _dtresult;
        public static DataTable _dtsummary;
        public static DataTable _dtfilter;
        public static DataTable _dtdetails;
        public bool isNewProject;
        protected void Page_Load(object sender, EventArgs e)
        {
            //_ReadCookies();
            //if (!IsPostBack)
            //{
            //    string _prm = Request.QueryString[0].ToString();
            //    lblsrv.Text = _prm.Substring(0, _prm.IndexOf("_P"));
            //    lblprj.Text = _prm.Substring(_prm.IndexOf("_P") + 2);
            //    Session["srv"] = lblsrv.Text;
            //    string _mode = _prm.Substring(0, 1);
            //    lblmode.Text = _mode;
            //    Load_Cassheets();
            //    Load_Service();
            //    Load_FilteringElements();
            //    //Generate_Summary();
            //    //Generate_Summary_Graph();
            //    if (_mode == "0")
            //    {
            //        if (lblprj.Text == "CCAD")
            //            Generate_Project_Summary_ccad();
            //        else
            //            Generate_Project_Summary();
            //    }
            //    else
            //    {
            //        Generate_Service_Summary();
            //    }
            //    //if (Request.QueryString[0].ToString() == "0")
            //    //    tdback.Visible = false;

            //}

        }
        private void Load_Cassheets()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            if (lblprj.Text == "12761")
                _dtMaster = _objbll.Load_Prj_Cassheet_12761(_objdb);
            else if (lblprj.Text == "HMIM")
            {
                _clstis _objcls = new _clstis();
                _objcls.bldg_id = Convert.ToInt32(lbldiv.Text);
                _dtMaster = _objbll.Load_Prj_Cassheet_Bldng(_objcls, _objdb);
            }
            else
                _dtMaster = _objbll.Load_Prj_Cassheet(_objdb);
        }
        private void Load_Service()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _dtService = _objbll.Load_Prj_Service(_objdb);
        }
        private void Load_Master(int sch)
        {
            if (lblprj.Text == "CCAD" || lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
            {
                var _dv = (DataView)Class1._OBJ_DATA_CAS.Select();
                DataTable _dtemp = _dv.ToTable();
                IEnumerable<DataRow> _result = from _data in _dtemp.AsEnumerable()
                                               where _data.Field<int>("Cas_Schedule") == sch
                                               select _data;
                if (_result.Any())
                {
                    _dtdetails = _result.CopyToDataTable<DataRow>();
                    _dtresult = _dtdetails;
                }
                else
                {
                    _dtdetails = null;
                    _dtresult = null;
                }
            }
            else
            {
                //BLL_Dml _objbll = new BLL_Dml();
                //_database _objdb = new _database();
                //_objdb.DBName = "DB_" + lblprj.Text;
                //_clscassheet _objcas = new _clscassheet();
                //_objcas.sch = sch;
                //_objcas.prj_code = lblprj.Text;
                //_dtdetails = _objbll.Load_casMain_Edit(_objcas, _objdb);
                //_dtresult = _dtdetails;

                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = sch;
                _objcas.prj_code = lblprj.Text;
                if (lblprj.Text == "HMIM" || lblprj.Text == "14211")
                    _objcas.sys = Convert.ToInt32(lbldiv.Text);
                else
                    _objcas.sys = 0;
                _dtdetails = _objbll.Load_casMain_Edit(_objcas, _objdb);

                _dtresult = _dtdetails;
            }
            //_dtresult = _dtdetails;
            //_dtfilter = _dtresult;
            Filtering(drbzone.SelectedItem.Text, drflevel.SelectedItem.Text);

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
                if (Request.Cookies["projectname"] != null)
                {
                    Session["projectname"] = Server.HtmlEncode(Request.Cookies["projectname"].Value);
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
        private void Generate_Summary_Graph()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clscassheet _objcls = new _clscassheet();
            _clsproject _objcls1 = new _clsproject();
            _objcls1.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls1, _objdb);
            _objbll.Clear_CassummaryRpt(_objdb);
            var _result = from _data in _dtsummary.AsEnumerable()
                          select _data;
            //int count = 0;
            foreach (var row in _result)
            {
                _objcls.sys_mon = row["SYS_NAME"].ToString();
                _objcls.qty = row["QTY"].ToString();
                _objcls.per_com1 = Convert.ToDecimal(row["PER_COMPLETED"].ToString());
                _objcls.per_com2 = Convert.ToDecimal(row["PER_COMPLETED1"].ToString());
                _objcls.per_com3 = Convert.ToDecimal(row["PER_COMPLETED2"].ToString());
                _objcls.total = Convert.ToDecimal(row["TOTAL"].ToString());
                _objcls.cate = row["CODE"].ToString();
                _objbll.Generate_CASSummary_PKG_RPT(_objcls, _objdb);
                //count += 1;
            }
        }
        private void Set_Cassheet_Data()
        {
            //var DataRows = (from DataRow dRow in _dtMaster.Rows
            //                where dRow.Field<int>("Sch") == 5
            //                select dRow);
            _dtresult = new DataTable();
            _dtresult.Columns.Add("devices1", typeof(string));
            _dtresult.Columns.Add("per_com1", typeof(decimal));
            _dtresult.Columns.Add("per_com2", typeof(decimal));
            _dtresult.Columns.Add("per_com3", typeof(decimal));
            _dtresult.Columns.Add("per_com4", typeof(decimal));
            _dtresult.Columns.Add("per_com5", typeof(decimal));
            _dtresult.Columns.Add("per_com6", typeof(decimal));
            _dtresult.Columns.Add("per_com7", typeof(decimal));
            _dtresult.Columns.Add("per_com8", typeof(decimal));
            _dtresult.Columns.Add("per_com9", typeof(decimal));
            _dtresult.Columns.Add("per_com10", typeof(decimal));
            _dtresult.Columns.Add("cat", typeof(string));
            _dtresult.Columns.Add("sch", typeof(int));
            _dtresult.Columns.Add("sys_id", typeof(int));
            var DataRows = from _master in _dtMaster.AsEnumerable()
                           where _master.Field<int>("sch") == 5
                           select _master;
            foreach (var row in DataRows)
            {
                DataRow _drow = _dtresult.NewRow();
                _drow[0] = row[0].ToString();
                _drow[1] = Convert.ToDecimal(row[1].ToString());
                _drow[2] = Convert.ToDecimal(row[2].ToString());
                _drow[3] = Convert.ToDecimal(row[3].ToString());
                _drow[4] = Convert.ToDecimal(row[4].ToString());
                _drow[5] = Convert.ToDecimal(row[5].ToString());
                _drow[6] = Convert.ToDecimal(row[6].ToString());
                _drow[7] = Convert.ToDecimal(row[7].ToString());
                _drow[8] = Convert.ToDecimal(row[8].ToString());
                _drow[9] = Convert.ToDecimal(row[9].ToString());
                _drow[10] = Convert.ToDecimal(row[10].ToString());
                _drow[11] = row[11].ToString();
                _drow[12] = Convert.ToInt32(row[12].ToString());
                _drow[13] = Convert.ToInt32(row[13].ToString());
                _dtresult.Rows.Add(_drow);
            }
            //IEnumerable<DataRow> query = from _Master in _dtMaster.AsEnumerable()
            //                             where _Master.Field<int>("Sch") == 5
            //                             select _Master;  // Would this be ok? 
            ////_dtresult.Rows.Add(query.First().ItemArray);  // ...or if not, how about this? o
            //object[] sourceData = query.First().ItemArray; 
            //object[] targetData = new object[sourceData.Length];
            //sourceData.CopyTo(targetData, 0); 
            //_dtresult.Rows.Add(targetData); 
        }
        private decimal Summary5_New()
        {
            decimal _overall = 0;
            int _count = 0;
            decimal _calcount = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    int circuitCount = 0;
                    int coldTestCount = 0;
                    int liveTestCount = 0;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        //_p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        //_p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        if (_row["tested1"] != null && _row["tested1"].ToString() != "" && IsNumeric(_row["tested1"].ToString()))
                        {
                            coldTestCount += Convert.ToInt32(_row["tested1"]);
                        }
                        if (_row["tested2"] != null && _row["tested2"].ToString() != "" && IsNumeric(_row["tested2"].ToString()))
                        {
                            liveTestCount += Convert.ToInt32(_row["tested2"]);
                        }
                        if (_row["devices1"] != null && _row["devices1"].ToString() != "")
                        {
                            circuitCount += Convert.ToInt32(_row["devices1"]);
                        }
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    if (count != 0)
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count));
                    if (coldTestCount != 0 && circuitCount != 0)
                    {
                        _per2 = ((coldTestCount * 100) / Convert.ToDecimal(circuitCount));
                    }
                    if (liveTestCount != 0 && circuitCount != 0)
                    {
                        _per3 = ((liveTestCount * 100) / Convert.ToDecimal(circuitCount));
                    }
                    //if (count != 0)
                    //    _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count));
                    //if (count != 0)
                    //    _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count));

                    if (row.col2.ToString() == "MDB") _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m)), MidpointRounding.AwayFromZero);
                    else if (row.col2.ToString() == "PFC") _total = Decimal.Round(((_per1 * 0.6m) + (_per2 * 0.4m)), MidpointRounding.AwayFromZero);
                    else if (row.col2.ToString() == "HCP") _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m)), MidpointRounding.AwayFromZero);
                    else if (row.col2.ToString() == "DB") _total = Decimal.Round(((_per2 * 0.6m) + (_per3 * 0.4m)), MidpointRounding.AwayFromZero);
                    else if (row.col2.ToString() == "LCP") _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m));
                    else if (row.col2.ToString() == "UPS") _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m));
                    else if (row.col2.ToString() == "EFP") _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                    else if (row.col2.ToString() == "SMDB") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    else if (row.col2.ToString() == "MCC") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    else if (row.col2.ToString() == "ATS") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    else if (row.col2.ToString() == "BDT") _total = Decimal.Round((_per1 * 0.6m) + (_per2 * 0.4m), MidpointRounding.AwayFromZero);
                    else _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                    _overall += _total;
                    _calcount += Decimal.Round(((_total * count) / 100), 2, MidpointRounding.AwayFromZero);
                    //_count += 1;
                    _count += count;
                }
                if (_count != 0)
                    //return (_overall / _count);
                    return Decimal.Round(((_calcount / _count) * 100), MidpointRounding.AwayFromZero);
                else return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary1_5()
        {
            decimal _overall = 0;
            int _count = 0;
            decimal _calcount = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    if (count != 0)
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count));
                    if (count != 0)
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count));
                    if (count != 0)
                        _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count));

                    if (row.col2.ToString() == "MDB") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                    else if (row.col2.ToString() == "PFC") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                    else if (row.col2.ToString() == "HCP") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                    else if (row.col2.ToString() == "DB")
                    {
                        if (lblprj.Text == "12710")
                            _total = Decimal.Round((_per2 * 0.5m) + (_per3 * 0.5m));
                        else
                            _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m));
                    }
                    else if (row.col2.ToString() == "LCP")
                    {
                        if (lblprj.Text == "12710")
                            _total = Decimal.Round((_per2 * 0.5m) + (_per3 * 0.5m));
                        else
                            _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m));
                    }
                    else if (row.col2.ToString() == "UPS")
                    {
                        if (lblprj.Text == "12710")
                            _total = Decimal.Round((_per2 * 0.5m) + (_per3 * 0.5m));
                        else
                            _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m));
                    }
                    else if (row.col2.ToString() == "EFP")
                    {
                        if (lblprj.Text == "12710")
                            _total = Decimal.Round((_per2 * 0.5m) + (_per3 * 0.5m));
                        else
                            _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m));
                    }
                    else if (row.col2.ToString() == "SMDB") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                    else if (row.col2.ToString() == "MCC") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                    else if (row.col2.ToString() == "ATS") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                    else if (row.col2.ToString() == "BDT") _total = Decimal.Round((_per1 * 0.6m) + (_per2 * 0.4m));
                    else _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                    _overall += _total;
                    _calcount += (_total * count) / 100;
                    //_count += 1;
                    _count += count;
                }
                if (_count != 0)
                    //return (_overall / _count);
                    return (_calcount / _count) * 100;
                else return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary2()
        {
            int _count = 0;
            try
            {
                decimal _total = 0;
                decimal _pcom1 = 0, _pcom2 = 0, _pcom3 = 0;
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;

                    int count1 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    int _count2 = 0;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) >= 0)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            count1 += 1;
                        }
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());

                        if (_row["Pwr_on"].ToString().ToUpper() != "N/A")
                        {
                            _p3 += Convert.ToDecimal(_row["per_com4"].ToString());
                            _count2 += 1;
                        }
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count1), 0, MidpointRounding.AwayFromZero);
                    decimal _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 0, MidpointRounding.AwayFromZero);
                    decimal _per3 = (_p3 * 100) / Convert.ToDecimal(_count2);
                    _pcom1 += _per1;
                    _pcom2 += _per2;
                    _pcom3 += _per3;
                    _count += 1;

                }
                if (_count <= 0) return 0;
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    _total = Decimal.Round((_pcom1 / _count) * 0.6m + (_pcom3 / _count) * 0.4m, 0, MidpointRounding.AwayFromZero);
                }
                else
                    _total = Decimal.Round(((_pcom1 / _count) * 0.9m) + ((_pcom2 / _count) * 0.1m), 0, MidpointRounding.AwayFromZero);
                return _total;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary3()
        {
            decimal _overall = 0;
            int _count = 0;
            decimal _total = 0;
            decimal _pcom1 = 0, _pcom2 = 0, _pcom3 = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    int count = 0;
                    int count1 = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) >= 0)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            count1 += 1;
                        }
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com4"].ToString());
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    if (count1 > 0)
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count1), 0, MidpointRounding.AwayFromZero);

                    if (count > 0)
                    {
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 0, MidpointRounding.AwayFromZero);
                        _per3 = (_p3 * 100) / Convert.ToDecimal(count);
                    }
                    _pcom1 += _per1;
                    _pcom2 += _per2;
                    _pcom3 += _per3;

                    _count += 1;
                }
                if (_count <= 0) return 0;
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                    _total = Decimal.Round((_pcom1 / _count) * 0.6m + (_pcom3 / _count) * 0.4m);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini")
                    _total = Decimal.Round(_pcom2 / _count, 0, MidpointRounding.AwayFromZero);
                else
                {
                    if (_pcom1 < 0)
                        _total = Decimal.Round((_pcom2 / _count), 0, MidpointRounding.AwayFromZero);
                    else
                        _total = Decimal.Round(((_pcom1 / _count) * 0.9m) + ((_pcom2 / _count) * 0.1m), 0, MidpointRounding.AwayFromZero);
                }
                return _total;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary6()
        {
            decimal _test1 = 0;
            decimal _test2 = 0;
            int _count = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    int count = 0;
                    int count1 = 0;
                    int count2 = 0;
                    int count3 = 0;
                    int _cnt = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) >= 0)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            count += 1;
                        }
                        if (Convert.ToDecimal(_row["per_com2"].ToString()) >= 0)
                        {
                            _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                            count1 += 1;
                        }
                        if (Convert.ToDecimal(_row["per_com3"].ToString()) >= 0)
                        {
                            _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                            count2 += 1;
                        }
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) >= 0)
                        {
                            _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                            count3 += 1;
                        }
                        _s = _row[0].ToString();
                        _cnt += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    if (count > 0)
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 0, MidpointRounding.AwayFromZero);
                    if (count1 > 0)
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count1), 0, MidpointRounding.AwayFromZero);
                    if (count2 > 0)
                        _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count2), 0, MidpointRounding.AwayFromZero);
                    if (count3 > 0)
                        _per4 = Decimal.Round(_p4 / Convert.ToDecimal(count3), 0, MidpointRounding.AwayFromZero);

                    if (row.col2.ToString() == "LP")
                    {
                        _test1 += _per3;
                        _test2 += _per4;
                    }
                    else
                    {
                        _test1 += _per1;
                        _test2 += _per2;
                    }
                    _count += 1;
                }
                decimal _overall = 0;
                if (_count != 0)
                    _overall = decimal.Round((_test1 * 0.9m + _test2 * 0.1m) / _count, 0, MidpointRounding.AwayFromZero);
                return _overall;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary4()
        {
            decimal _overall = 0;
            int _count = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    if (count != 0)
                    {
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count));
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count));
                        _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count));
                    }
                    _total = Decimal.Round((_per1 * 0.6m) + (_per2 * 0.1m) + (_per3 * 0.3m));
                    _overall += _total;
                    _count += 1;
                }
                if (_count != 0)
                    return (_overall / _count);
                else
                    return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary7()
        {
            decimal _overall = 0;
            int _count = 0;
            try
            {
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;
                decimal _total = 0;
                int count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                    count += Convert.ToInt32(_row["devices1"].ToString());
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 7;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);

                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    decimal _test = 0;
                    if (row[0].ToString() == "Continuity/IR Test Complete") _test = decimal.Round(_p1);
                    else if (row[0].ToString() == "Addressing") _test = decimal.Round(_p2);
                    else if (row[0].ToString() == "Fault Testing") _test = decimal.Round(_p3);
                    else if (row[0].ToString() == "Change Over Test") _test = decimal.Round(_p4);
                    else if (row[0].ToString() == "Lux Level Test") _test = decimal.Round(_p5);
                    else if (row[0].ToString() == "Duration Test") _test = decimal.Round(_p6);
                    else if (row[0].ToString() == "Pc Head End Test") _test = decimal.Round(_p7);
                    if (count != 0)
                        _total = decimal.Round((_test / count) * 100);
                    _overall += _total;
                    _count += 1;
                }
                if (_count != 0)
                    return (_overall / _count);
                else
                    return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary8()
        {
            decimal _test1 = 0;
            decimal _test2 = 0;
            int _count = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    _test1 += _p1;
                    _test2 += _p2;
                    _count += count;
                }
                decimal _overall = 0;
                if (_count > 0)
                    _overall = Decimal.Round((((_test1 * 0.2m) + (_test2 * 0.8m)) / _count) * 100);
                return _overall;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary21()
        {
            decimal _overall = 0;
            int _count = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        count += 1;
                    }
                    if (count != 0)
                        _total = Decimal.Round(_p1 / Convert.ToDecimal(count));
                    _overall += _total;
                    _count += 1;
                }
                if (_count > 0)
                    return (_overall / _count);
                else return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary9()
        {
            decimal _test = 0;
            int _count = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    int count = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        count += 1;
                    }
                    _test += _p1;
                    _count += count;
                }
                if (_count > 0)
                    return ((_test / _count) * 100);
                else return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary17()
        {
            decimal _test1 = 0;
            decimal _test2 = 0;
            int _count = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    _test1 += _p1;
                    _test2 += _p2;
                    _count += count;
                }
                decimal _overall = 0;
                if (_count > 0)
                    _overall = Decimal.Round((((_test1 * 0.2m) + (_test2 * 0.8m)) / _count) * 100);
                return _overall;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary18()
        {
            decimal _test = 0;
            int _count = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        count += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    _test += _p1;
                    _count += count;
                }
                if (_count > 0)
                    return ((_test / _count) * 100);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary19()
        {
            decimal _overall = 0;
            int _count = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _total = 0;
                    int count = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        count += 1;
                    }
                    if (count != 0)
                        _total = _p1 / Convert.ToDecimal(count);
                    _overall += _total;
                    _count += 1;
                }
                if (_count > 0)
                    return (_overall / _count);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary22()
        {
            try
            {
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                decimal _overall = 0;
                int _count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 22;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    decimal _test = 0;
                    if (row[0].ToString() == "Continuity/IR Test") { _test = Decimal.Round(_p1); }
                    else if (row[0].ToString() == "Addressing/Programming Test") { _test = Decimal.Round(_p2); }
                    else if (row[0].ToString() == "Fault & Alarm Test") { _test = Decimal.Round(_p3); }
                    else if (row[0].ToString() == "Access Card Swipe") { _test = Decimal.Round(_p4); }
                    else if (row[0].ToString() == "Power Failure Test") { _test = Decimal.Round(_p5); }
                    else if (row[0].ToString() == "Interface Test") _test = decimal.Round(_p6);
                    else if (row[0].ToString() == "PC Headend/Graphics Test") _test = decimal.Round(_p7);
                    if (_test != 0)
                        _total = decimal.Round((_test / _devices) * 100);
                    _overall += _total;
                    _count += 1;
                }
                if (_count != 0)
                    return (_overall / _count);
                else
                    return 0;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary11()
        {
            try
            {
                decimal _overall = 0;
                int _count = 0;
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _circuits = 0;
                decimal _scenes = 0;
                decimal _total = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    if (IsNumeric(_row["devices1"]) == true)
                        _scenes += Convert.ToDecimal(_row["devices1"]);
                    else
                        _scenes += 0;
                    if (IsNumeric(_row["devices2"]) == true)
                        _circuits += Convert.ToDecimal(_row["devices2"]);
                    else
                        _circuits += 0;
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 11;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                decimal _total_qty = 0;
                decimal _total_tested = 0;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    decimal _test = 0;
                    decimal _device = 0;
                    if (row[0].ToString() == "Continuity/IR Test") { _test = Decimal.Round(_p1); _device = _circuits; }
                    else if (row[0].ToString() == "No.Of Lighting Circuits Tested") { _test = Decimal.Round(_p2); _device = _circuits; }
                    else if (row[0].ToString() == "Addressing/Programming Test") { _test = Decimal.Round(_p3); _device = _scenes; }
                    else if (row[0].ToString() == "PC Headend/Interface Test") { _test = Decimal.Round(_p4); _device = _circuits; }
                    //if (_test != 0)
                    //    _total = decimal.Round((_test / _device) * 100);

                    //_overall += _total;
                    //_count += 1;
                    _total_qty += _device;
                    _total_tested += _test;
                }
                if (_total_qty != 0)
                {
                    _overall = decimal.Round((_total_tested / _total_qty) * 100);
                    return _overall;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary12()
        {
            try
            {
                //decimal _overall = 0;
                //int _count = 0;
                decimal _p1 = 0;
                decimal _total = 0;
                decimal _points = 0;
                //string _test = "";
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    if (row.col3.ToString() == "CU" || row.col3.ToString() == "FO")
                    {

                        var _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                      select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            _points += Convert.ToDecimal(_row["devices1"].ToString());
                        }

                        //_overall += _total;
                        //_count += 1;
                    }
                }
                if (_p1 != 0)
                    _total = Decimal.Round((_p1 / _points) * 100);
                //if (_count != 0)
                //return (_overall / _count);
                return _total;
                //else
                //    return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary10()
        {
            decimal _overall = 0;
            int _count = 0;
            decimal _total_qty = 0;
            decimal _total_tested = 0;
            try
            {
                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 10;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                decimal _test = 0;
                decimal _device = 0;

                foreach (var row in TestNames)
                {
                    _total = 0;
                    _devices = 0;
                    _p1 = 0;
                    decimal _qty = 0;
                    if (lblprj.Text != "12710")
                    {
                        if (row[0].ToString() == "Circuit IR Test")
                        {
                            foreach (var _row in _result)
                            {
                                //if (_row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA")
                                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                    if (IsNumeric(_row["devices2"].ToString()) == true)
                                        _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _device = Decimal.Round(_devices);
                            _test = Decimal.Round(_p1);
                        }
                        else if (row[0].ToString() == "Device/Address Test")
                        {
                            foreach (var _row in _result)
                            {
                                //if (_row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA")
                                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                    if (IsNumeric(_row["devices2"].ToString()) == true)
                                        _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _device = Decimal.Round(_devices);
                            _test = Decimal.Round(_p1);


                        }
                        else if (row[0].ToString() == "Sound Level Test")
                        {
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "PAVA")
                                {

                                    _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                    if (IsNumeric(_row["devices2"].ToString()) == true)
                                        _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                                //else if (_row["cat"].ToString() == "FTU")
                                //{
                                //    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                //    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                //}
                            }
                            _device = Decimal.Round(_devices);
                            _test = Decimal.Round(_p1);
                        }
                        else if (row[0].ToString() == "Interface Test")
                        {
                            foreach (var _row in _result)
                            {
                                //if (_row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA")     
                                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                    if (IsNumeric(_row["devices1"].ToString()) == true)
                                        _devices += Convert.ToInt32(_row["devices1"].ToString());
                                }
                            }
                            _device = Decimal.Round(_devices);
                            _test = Decimal.Round(_p1);
                        }
                        else if (row[0].ToString() == "Fire Telephone Test")
                        {
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "FTP")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                    if (IsNumeric(_row["devices2"].ToString()) == true)
                                        _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _device = Decimal.Round(_devices);
                            _test = Decimal.Round(_p1);

                        }
                        else if (row[0].ToString() == "Battery Autonomy Test")
                        {
                            if (lblprj.Text == "BCC1")
                            {
                                _result = from _data in _dtresult.AsEnumerable()
                                          where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP"
                                          select _data;
                            }
                            else if (lblprj.Text == "11736")
                            {
                                _result = from _data in _dtresult.AsEnumerable()
                                          where _data.Field<string>("Cat") == "FACP"
                                          select _data;
                            }
                            else
                            {
                                _result = from _data in _dtresult.AsEnumerable()
                                          where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA"
                                          select _data;
                            }
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                _qty += 1;
                            }
                            if (lblprj.Text == "BCC1" || lblprj.Text == "11736")
                                _device = Decimal.Round(_qty);
                            else
                                _device = Decimal.Round(_devices);
                            _test = Decimal.Round(_p1);

                        }
                        else if (row[0].ToString() == "Graphic Test")
                        {
                            if (lblprj.Text == "BCC1")
                            {
                                _result = from _data in _dtresult.AsEnumerable()
                                          where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "PAVA"
                                          select _data;
                            }
                            else
                            {
                                _result = from _data in _dtresult.AsEnumerable()
                                          where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA"
                                          select _data;
                            }
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                _qty += 1;
                            }
                            if (lblprj.Text == "BCC1")
                                _device = Decimal.Round(_qty);
                            else
                                _device = Decimal.Round(_devices);
                            _test = Decimal.Round(_p1);

                        }
                        else if (row[0].ToString() == "Cause Effect Test")
                        {
                            if (lblprj.Text == "BCC1")
                            {
                                _result = from _data in _dtresult.AsEnumerable()
                                          where _data.Field<string>("Cat") == "CE"
                                          select _data;
                            }
                            else
                            {
                                _result = from _data in _dtresult.AsEnumerable()
                                          where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA"
                                          select _data;
                            }
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                _qty += 1;

                            }
                            if (lblprj.Text == "BCC1")
                                _device = Decimal.Round(_qty);
                            else
                                _device = Decimal.Round(_devices);
                            _test = Decimal.Round(_p1);

                        }
                    }
                    else
                    {
                        if (row[0].ToString() == "Circuit IR Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            _device = Decimal.Round(_devices);
                            _test = Decimal.Round(_p1);
                        }
                        else if (row[0].ToString() == "Device/Address Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            _device = Decimal.Round(_devices);
                            _test = Decimal.Round(_p1);


                        }
                        else if (row[0].ToString() == "Sound Level Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            _device = Decimal.Round(_devices);
                            _test = Decimal.Round(_p1);
                        }
                        else if (row[0].ToString() == "Interface Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                            }
                            _device = Decimal.Round(_devices);
                            _test = Decimal.Round(_p1);

                        }
                        else if (row[0].ToString() == "Fire Telephone Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "FTP"
                                      select _data;
                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            _device = Decimal.Round(_devices);
                            _test = Decimal.Round(_p1);
                        }
                        else if (row[0].ToString() == "Battery Autonomy Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                      select _data;

                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                //_count += 1;
                            }
                            _device = Decimal.Round(_devices);
                            _test = Decimal.Round(_p1);

                        }
                        else if (row[0].ToString() == "Graphic Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                      select _data;

                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            _device = Decimal.Round(_devices);
                            _test = Decimal.Round(_p1);

                        }
                        else if (row[0].ToString() == "Cause Effect Test")
                        {
                            _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                      select _data;

                            foreach (var _row in _result)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());

                            }
                            _device = Decimal.Round(_devices);
                            _test = Decimal.Round(_p1);

                        }
                    }
                    //if (_test != 0)
                    //    _total = decimal.Round((_test / _device) * 100);

                    //_overall += _total;
                    //_count += 1;
                    _total_qty += _device;
                    _total_tested += _test;
                    //return _device;
                }
                if (_total_qty != 0)
                {
                    _overall = decimal.Round((_total_tested / _total_qty) * 100);
                    return _overall;
                    // return _count;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary13()
        {
            decimal _overall = 0;
            int _count = 0;
            try
            {
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 13;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    decimal _test = 0;
                    if (row[0].ToString() == "Continuity/IR Test") { _test = Decimal.Round(_p1); }
                    else if (row[0].ToString() == "CCTV View Locally") { _test = Decimal.Round(_p2); }
                    else if (row[0].ToString() == "CCTV View From Head End") { _test = Decimal.Round(_p3); }
                    else if (row[0].ToString() == "CCTV Addressing/Software Test") { _test = Decimal.Round(_p4); }
                    else if (row[0].ToString() == "CCTV Recording/Back-up Restore Test") { _test = Decimal.Round(_p5); }
                    //else if (row[0].ToString() == "Pc Head End Test") _drow[2] = decimal.Round(_p7).ToString();
                    if (_test != 0)
                        _total = decimal.Round((_test / _devices) * 100);
                    _overall += _total;
                    _count += 1;

                }
                if (_count != 0)
                    return (_overall / _count);
                else
                    return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary14()
        {
            decimal _overall = 0;
            int _count = 0;
            try
            {
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    if (_row["cat"].ToString() == "AVP")
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _devices += Convert.ToInt32(_row["devices1"].ToString());
                    }
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 14;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    decimal _test = 0;
                    if (row[0].ToString() == "Continuity/IR Test") { _test = Decimal.Round(_p1); }
                    else if (row[0].ToString() == "Door Intercom Alert/Bell") { _test = Decimal.Round(_p2); }
                    else if (row[0].ToString() == "Audio/Visual Test") { _test = Decimal.Round(_p3); }
                    else if (row[0].ToString() == "Door Release Test") { _test = Decimal.Round(_p4); }
                    if (_test != 0)
                        _total = decimal.Round((_test / _devices) * 100);
                    _overall += _total;
                    _count += 1;

                }
                if (_count != 0)
                    return (_overall / _count);
                else
                    return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary16()
        {
            decimal _overall = 0;
            int _count = 0;
            try
            {
                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                decimal _test = 0;
                decimal _device = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 16;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    _devices = 0;

                    _p1 = 0;
                    if (row[0].ToString() == "Continuity/ IR Tests")
                    {
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                            else
                                _devices += 0;
                        }
                        _device += Decimal.Round(_devices);
                        _test += Decimal.Round(_p1);
                    }
                    else if (row[0].ToString() == "Point to Point Tests")
                    {
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                            else
                                _devices += 0;
                        }
                        _device += Decimal.Round(_devices);
                        _test += Decimal.Round(_p1);
                    }
                    else if (row[0].ToString() == "Calibration/ Functional Tests")
                    {
                        foreach (var _row in _result)
                        {

                            _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                            if (IsNumeric(_row["devices1"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices1"].ToString());
                            else
                                _devices += 0;
                        }
                        _device += Decimal.Round(_devices);
                        _test += Decimal.Round(_p1);
                    }
                    else if (row[0].ToString() == "Sequence of Operation Tests")
                    {
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                            _devices += 1;
                        }
                        _device += Decimal.Round(_devices);
                        _test += Decimal.Round(_p1);

                    }
                    else if (row[0].ToString() == "Graphics/ Head End Tests")
                    {
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                            _devices += 1;
                        }
                        _device += Decimal.Round(_devices);
                        _test += Decimal.Round(_p1);

                    }

                    //if (_test != 0)
                    //    _total = Decimal.Round((_test / _device) * 100);

                    //_overall += _total;
                    //_count += 1;
                    //return _device;
                }
                if (_test != 0)
                {
                    _total = Decimal.Round((_test / _device) * 100);
                    return _total;
                    // return _count;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary20()
        {
            decimal _overall = 0;
            int _count = 0;
            try
            {
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _points = 0;
                decimal _devices = 0;
                decimal _systems = 0;
                decimal _total = 0;
                decimal _test = 0;
                decimal _device = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    if (IsNumeric(_row["devices3"].ToString()) == true)
                        _points += Convert.ToInt32(_row["devices3"].ToString());
                    if (IsNumeric(_row["devices2"].ToString()) == true)
                        _devices += Convert.ToInt32(_row["devices2"].ToString());
                    if (IsNumeric(_row["devices1"].ToString()) == true)
                        _systems += Convert.ToInt32(_row["devices1"].ToString());

                    //_p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    //_p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    //_p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    //_p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    //_p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    //_p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    //_points += Convert.ToInt32(_row["devices3"].ToString());
                    //_devices += Convert.ToInt32(_row["devices2"].ToString());
                    //_systems += Convert.ToInt32(_row["devices1"].ToString());
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 20;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {

                    if (row[0].ToString() == "Cable Continuity/IR Test") { _test += Decimal.Round(_p1); _device += Decimal.Round(_points); }
                    else if (row[0].ToString() == "Points to Points Test") { _test += Decimal.Round(_p2); _device += Decimal.Round(_points); }
                    else if (row[0].ToString() == "Calibration/Functional Test") { _test += Decimal.Round(_p3); _device += Decimal.Round(_devices); }
                    else if (row[0].ToString() == "Sequence of Operation") { _test += Decimal.Round(_p4); _device += Decimal.Round(_systems); }
                    else if (row[0].ToString() == "Graphic/Head End Test") { _test += Decimal.Round(_p5); _device += Decimal.Round(_systems); }
                    else if (row[0].ToString() == "Loop Tuning") { _test += Decimal.Round(_p6); _device += Decimal.Round(_systems); }
                    //else if (row[0].ToString() == "Pc Head End Test") _drow[2] = decimal.Round(_p7).ToString();
                    //if (_test!=0)
                    //    _total = decimal.Round((_test / _device) * 100);

                    //_overall += _total;
                    //_count += 1;
                }
                if (_test != 0)
                {
                    _total = decimal.Round((_test / _device) * 100);
                    return _total;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary29()
        {
            decimal _test1 = 0;
            decimal _test2 = 0;
            int _count = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        count += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (_p1 != 0)
                        _total = Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                    _test1 += _p1;
                    _count += count;
                }
                decimal _overall = 0;
                if (_count > 0)
                    _overall = Decimal.Round((_test1 / Convert.ToDecimal(_count)) * 100);
                return _overall;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary15()
        {
            try
            {
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;
                decimal _p8 = 0;
                decimal _p9 = 0;
                decimal _devices = 0;
                decimal _test = 0;
                decimal _total = 0;
                decimal _count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                    _p8 += Convert.ToDecimal(_row["per_com8"].ToString());
                    _p9 += Convert.ToDecimal(_row["per_com9"].ToString());
                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 15;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    if (row[0].ToString() == "Continuity/IR Test") { _test += Decimal.Round(_p1); }
                    else if (row[0].ToString() == "Key Card Activated") { _test += Decimal.Round(_p2); }
                    else if (row[0].ToString() == "Do Not Disturb(DND)/Doorbell") { _test += Decimal.Round(_p3); }
                    else if (row[0].ToString() == "Make Up Room(MUR)") { _test += Decimal.Round(_p4); }
                    else if (row[0].ToString() == "FCU/Temp Control") { _test += Decimal.Round(_p5); }
                    else if (row[0].ToString() == "Energy Management System") _test += decimal.Round(_p6);
                    else if (row[0].ToString() == "Lighting Scene Control") { _test += Decimal.Round(_p7); }
                    else if (row[0].ToString() == "Blinds Control Interface") { _test += Decimal.Round(_p8); }
                    else if (row[0].ToString() == "Monitoring Interface(Future)") _test += decimal.Round(_p9);

                    _count += _devices;
                }

                if (_count != 0)
                {
                    _total = decimal.Round((_test / _count) * 100);
                    return _total;
                }
                else
                    return 0;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
                return 0;
            }
        }
        private decimal Summary31()
        {
            decimal _count = 0;
            decimal _total = 0;
            try
            {
                decimal _p1 = 0;
                decimal _p2 = 0;
                //decimal _p3 = 0;
                //decimal _p4 = 0;
                //decimal _p5 = 0;
                //decimal _p6 = 0;
                //decimal _p7 = 0;

                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    if (_row["per_com1"].ToString() == "100")
                        _p2 += 1;
                    //_p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    //_p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    //_p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    //_p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    //_p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    //_p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                    //count += Convert.ToInt32(_row["devices1"].ToString());
                    //_qty += 1;


                    _count += 1;
                }

                if (_count != 0)
                {
                    _total = decimal.Round((_p2 / _count) * 100);
                    return _total;
                }
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        private decimal Summary32()
        {
            decimal _count = 0;
            decimal _total = 0;
            try
            {
                decimal _p1 = 0;
                decimal _p2 = 0;

                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                    _count += 1;
                }

                if (_count != 0)
                {
                    _total = decimal.Round((_p1 / _count) * 100);
                    return _total;
                }
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void Generate_Service_Summary()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsproject _objcls1 = new _clsproject();
            _objcls1.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls1, _objdb);
            _objbll.Clear_CasServiceSummary(_objdb);
            if (isNewProject)
            {
                _clscassheet _objcls = new _clscassheet();
                _objdb.DBName = "DB_" + lblprj.Text;
                //_objcls.srv = Convert.ToInt32(lblsrv.Text);
                _objcls.b_zone = drbzone.SelectedItem.Text;
                _objcls.cate = "ALL";
                _objcls.f_level = drflevel.SelectedItem.Text;
                _objcls.fed_from = "ALL";
                _objcls.loca = "ALL";


                 DataTable _dt;
                if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                {
                    _objcls.sch = Convert.ToInt32(lblsrv.Text);
                    _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                    _dt = _objbll.Generate_CASPkg_Rpt_Bldng(_objcls, _objdb);
                }
                else
                {
                    _objcls.srv = Convert.ToInt32(lblsrv.Text);
                    _dt = _objbll.Generate_CASPkg_Rpt(_objcls, _objdb);
                }

                _objdb.DBName = "DBCML";
                foreach (DataRow _drow in _dt.Rows)
                {
                    _objcls.cate = _drow["CAS_NAME"].ToString();
                    _objcls.per_com1 = Convert.ToDecimal(_drow["Overall"].ToString());
                    _objbll.Insert_CasServiceSummary(_objcls, _objdb);
                }
                return;
            }
            else
            {
                decimal _result = 0;
                int count = 0;
                var Cassheets = (from DataRow dRow in _dtMaster.Rows
                                 where dRow.Field<int>("SYS_SER_ID") == Convert.ToInt32(lblsrv.Text)
                                 select new { col1 = dRow["PRJ_CAS_ID"], col2 = dRow["PRJ_CAS_NAME"] });
                foreach (var _row in Cassheets)
                {
                    if (_row.col1.ToString() == "5" || _row.col1.ToString() == "1")
                    {
                        Load_Master(5);
                        if (lblprj.Text == "CCAD")
                            _result = Summary5_1();
                        else if (lblprj.Text == "demo")
                            _result += Summary5_New();
                        else
                            _result = Summary1_5();
                    }
                    else if (_row.col1.ToString() == "44")
                    {
                        Load_Master(44);
                        if (lblprj.Text == "CCAD")
                            _result = Summary5_1();
                    }
                    else if (_row.col1.ToString() == "2")
                    {

                        if (lblprj.Text == "CCAD")
                        {
                            Load_Master(121);
                            _result = Summary2_1();
                            Load_Master(120);
                            _result += Summary3_1();
                            _result = _result / 2;
                        }
                        else
                        {
                            Load_Master(2);
                            _result = Summary2();
                        }
                    }
                    else if (_row.col1.ToString() == "41")
                    {
                        if (lblprj.Text == "CCAD")
                        {
                            Load_Master(119);
                            _result = Summary2_1();
                            Load_Master(3);
                            _result += Summary3_1();
                            _result = _result / 2;
                        }
                    }
                    else if (_row.col1.ToString() == "42")
                    {

                        if (lblprj.Text == "CCAD")
                        {
                            Load_Master(118);
                            _result = Summary2_1();
                            Load_Master(4);
                            _result += Summary4_1();
                            _result = _result / 2;
                        }

                    }
                    else if (_row.col1.ToString() == "3")
                    {
                        Load_Master(3);
                        if (lblprj.Text == "CCAD")
                            _result = Summary3_1();
                        else
                            _result = Summary3();
                    }
                    else if (_row.col1.ToString() == "4")
                    {
                        Load_Master(4);
                        if (lblprj.Text == "CCAD")
                            _result = Summary4_1();
                        else
                            _result = Summary4();
                    }
                    else if (_row.col1.ToString() == "6")
                    {
                        Load_Master(6);
                        if (lblprj.Text == "CCAD")
                            _result = Summary6_1();
                        else
                            _result = Summary6();
                    }
                    else if (_row.col1.ToString() == "7")
                    {
                        Load_Master(7);
                        if (lblprj.Text == "CCAD")
                            _result = Summary7_1();
                        else
                            _result = Summary7();
                    }
                    else if (_row.col1.ToString() == "8")
                    {
                        Load_Master(8);
                        if (lblprj.Text == "CCAD")
                            _result = Summary8_1();
                        else
                            _result = Summary8();
                    }
                    else if (_row.col1.ToString() == "51")
                    {
                        if (lblprj.Text == "CCAD")
                        {
                            Load_Master(51);
                            _result = Summary8_1();
                        }
                    }
                    else if (_row.col1.ToString() == "52")
                    {
                        if (lblprj.Text == "CCAD")
                        {
                            Load_Master(52);
                            _result = Summary8_1();
                        }
                    }
                    else if (_row.col1.ToString() == "53")
                    {
                        if (lblprj.Text == "CCAD")
                        {
                            Load_Master(53);
                            _result = Summary8_1();
                        }
                    }
                    else if (_row.col1.ToString() == "54")
                    {
                        if (lblprj.Text == "CCAD")
                        {
                            Load_Master(54);
                            _result = Summary8_1();
                        }
                    }
                    else if (_row.col1.ToString() == "55")
                    {
                        if (lblprj.Text == "CCAD")
                        {
                            _result = Summary55();
                        }
                    }
                    else if (_row.col1.ToString() == "56")
                    {
                        if (lblprj.Text == "CCAD")
                        {
                            Load_Master(56);
                            _result = Summary8_1();
                        }
                    }
                    else if (_row.col1.ToString() == "57")
                    {
                        if (lblprj.Text == "CCAD")
                        {
                            Load_Master(57);
                            _result = Summary8_1();
                        }
                    }
                    else if (_row.col1.ToString() == "58")
                    {
                        if (lblprj.Text == "CCAD")
                        {
                            Load_Master(58);
                            _result = Summary8_1();
                        }
                    }
                    else if (_row.col1.ToString() == "59")
                    {
                        if (lblprj.Text == "CCAD")
                        {
                            Load_Master(59);
                            _result = Summary8_1();
                        }
                    }
                    else if (_row.col1.ToString() == "60")
                    {
                        if (lblprj.Text == "CCAD")
                        {
                            Load_Master(60);
                            _result = Summary8_1();
                        }
                    }
                    else if (_row.col1.ToString() == "21")
                    {
                        Load_Master(21);
                        _result = Summary21();
                    }
                    else if (_row.col1.ToString() == "9")
                    {
                        Load_Master(9);
                        if (lblprj.Text == "CCAD")
                            _result = Summary9_1();
                        else
                            _result = Summary9();
                    }
                    else if (_row.col1.ToString() == "17")
                    {
                        Load_Master(17);
                        if (lblprj.Text == "CCAD")
                            _result = Summary17_1();
                        else
                            _result = Summary17();
                    }
                    else if (_row.col1.ToString() == "18")
                    {
                        Load_Master(18);
                        if (lblprj.Text == "CCAD")
                            _result = Summary17_1();
                        else
                            _result = Summary18();
                    }
                    else if (_row.col1.ToString() == "19")
                    {
                        Load_Master(19);
                        if (lblprj.Text == "CCAD")
                            _result = Summary19_1();
                        else
                            _result = Summary19();
                    }
                    else if (_row.col1.ToString() == "22")
                    {
                        Load_Master(22);
                        if (lblprj.Text == "CCAD")
                            _result = Summary20_1();
                        else
                            _result = Summary22();
                    }
                    else if (_row.col1.ToString() == "11")
                    {
                        Load_Master(11);
                        if (lblprj.Text == "CCAD")
                            _result = Summary20_1();
                        else
                            _result = Summary11();
                    }
                    else if (_row.col1.ToString() == "12")
                    {
                        Load_Master(12);
                        if (lblprj.Text == "CCAD")
                            _result = Summary12_1();
                        else
                            _result = Summary12();
                    }
                    else if (_row.col1.ToString() == "10")
                    {
                        Load_Master(10);
                        if (lblprj.Text == "CCAD")
                            _result = Summary10_1();
                        else if (lblprj.Text == "14211")
                            _result += Summary10_14211();
                        else if (lblprj.Text == "HMIM")
                            _result += Summary10_HMIM();
                        else
                            _result = Summary10();
                    }
                    else if (_row.col1.ToString() == "13")
                    {
                        Load_Master(13);
                        if (lblprj.Text == "CCAD")
                            _result = Summary20_1();
                        else
                            _result = Summary13();
                    }
                    else if (_row.col1.ToString() == "14")
                    {
                        Load_Master(14);
                        if (lblprj.Text == "CCAD")
                            _result = Summary20_1();
                        else
                            _result = Summary14();
                    }
                    else if (_row.col1.ToString() == "16")
                    {
                        Load_Master(16);
                        if (lblprj.Text == "CCAD")
                            _result = Summary20_1();
                        else
                            _result = Summary16();
                    }
                    else if (_row.col1.ToString() == "20")
                    {
                        Load_Master(20);
                        if (lblprj.Text == "CCAD")
                            _result = Summary20_1();
                        else
                            _result = Summary20();
                    }
                    else if (_row.col1.ToString() == "23")
                    {
                        Load_Master(23);
                        if (lblprj.Text == "CCAD")
                            _result = Summary20_1();
                        else
                            _result = Summary20();
                    }
                    else if (_row.col1.ToString() == "24")
                    {
                        Load_Master(24);
                        if (lblprj.Text == "CCAD")
                            _result = Summary20_1();
                        else if (lblprj.Text == "12761")
                            _result = Summary24_2();
                        else
                            _result = Summary20();
                    }
                    else if (_row.col1.ToString() == "25")
                    {
                        Load_Master(25);
                        if (lblprj.Text == "CCAD")
                            _result = Summary20_1();
                        else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                            _result = Summary8();
                        else if (lblprj.Text == "12761")
                            _result = 0;
                        else
                            _result = Summary20();
                    }
                    else if (_row.col1.ToString() == "26")
                    {
                        Load_Master(26);
                        if (lblprj.Text == "CCAD")
                            _result = Summary20_1();
                        else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                            _result = Summary8();
                        else
                            _result = Summary20();
                    }
                    else if (_row.col1.ToString() == "15")
                    {
                        Load_Master(15);
                        if (lblprj.Text == "CCAD")
                            _result = Summary20_1();
                        else if (lblprj.Text == "HMIM")
                            _result = Summary15();
                        else
                            _result = Summary20();
                    }
                    else if (_row.col1.ToString() == "30")
                    {
                        Load_Master(30);
                        _result = Summary8();
                    }
                    else if (_row.col1.ToString() == "27")
                    {
                        if (lblprj.Text == "12761")
                        {
                            Load_Master(27);
                            _result = Summary20();
                        }
                        else
                        {
                            Load_Master(27);
                            _result = Summary8();
                        }
                    }
                    else if (_row.col1.ToString() == "46")
                    {
                        Load_Master(46);
                        _result = Summary8();
                    }
                    else if (_row.col1.ToString() == "28")
                    {
                        Load_Master(28);
                        _result = Summary21();
                    }
                    else if (_row.col1.ToString() == "29")
                    {
                        Load_Master(29);
                        if (lblprj.Text == "CCAD")
                            _result = Summary20_1();
                        else
                            _result = Summary29();
                    }
                    else if (_row.col1.ToString() == "37")
                    {
                        Load_Master(37);
                        _result = Summary37();
                    }
                    else
                        _result = 0;

                    _clscassheet _objcls = new _clscassheet();
                    _objcls.cate = _row.col2.ToString();
                    _objcls.per_com1 = decimal.Round(_result, 0, MidpointRounding.AwayFromZero);
                    _objbll.Insert_CasServiceSummary(_objcls, _objdb);

                }
            }
        }
        private string Get_Facility_Name()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_14211";
            _objcls.sch = Convert.ToInt32(lbldiv.Text);
            return _objbll.Get_Facility_Name(_objcls, _objdb);
        }
        ReportDocument cryRpt = new ReportDocument();
        protected void Page_Unload(object sender, EventArgs e)
        {
            //cryRpt.Dispose();
            //cryRpt.Close();
        }
        private void Generate_Reports(string _bz, string _fl, string mode)
        {
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            if (lblprj.Text == "14211")
            {
                cryRpt.Load(Server.MapPath("ServiceSummary_KAIA.rpt"));
                string _bldg = Get_Facility_Name();
                cryRpt.SetParameterValue("bldg", _bldg);
            }
            else if (lblprj.Text == "HMIM")
            {
                cryRpt.Load(Server.MapPath("ServiceSummary_HMIM.rpt"));
                string _bldg = "";
                if (lbldiv.Text == "1") _bldg = "CENTRAL UTILITY CENTRE";
                else if (lbldiv.Text == "2") _bldg = "PIAZZA";
                else if (lbldiv.Text == "3") _bldg = "SERVICE BUILDING";
                else if (lbldiv.Text == "4") _bldg = "HARAM";
                cryRpt.SetParameterValue("bldg", _bldg);
            }
            else if ((lblprj.Text == "PCD" || lblprj.Text == "ARSD" )&& mode == "9")
            {

                var todaysDate = DateTime.Today;
                if (!string.IsNullOrEmpty(hdnpcd.Value))
                {
                    todaysDate = DateTime.ParseExact(hdnpcd.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }

                cryRpt.Load(Server.MapPath("ProjectSummary_Pcd.rpt"));
                cryRpt.SetParameterValue("DateValue", todaysDate);
            }
            else
                cryRpt.Load(Server.MapPath("ServiceSummary.rpt"));

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
            //SelectionFormula(cryRpt, (string)Session["zone"], (string)Session["cat"], (string)Session["flvl"], (string)Session["fed"]);
            //if((string)Session["srv"]=="0")
            //    cryRpt.SetParameterValue("srv","P");
            //else
            //cryRpt.Refresh();
            //if ((string)Session["bz"] == null) Session["bz"] = "All";
            //if ((string)Session["fl"] == null) Session["fl"] = "All";
            CrystalReportViewer2.ReportSource = null;
            cryRpt.SetParameterValue("srv", lblsrv.Text);
            cryRpt.SetParameterValue("project", (string)Session["projectname"]);
            cryRpt.SetParameterValue("BZ", (string)Session["bz"]);
            cryRpt.SetParameterValue("FL", (string)Session["fl"]);
            CrystalReportViewer2.ReportSource = cryRpt;
            CrystalReportViewer2.DataBind();
            Session["Report"] = cryRpt;
        }
        private void Page_Init(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                lblsrv.Text = _prm.Substring(0, _prm.IndexOf("_P"));
                lblprj.Text = _prm.Substring(_prm.IndexOf("_P") + 2);

                isNewProject = (Array.IndexOf(Constants.CMLTConstants.recentProjects, lblprj.Text) > -1) ? true : false;

                Session["srv"] = lblsrv.Text;
                if (lblprj.Text == "HMIM" || lblprj.Text == "14211")
                    //if (lblprj.Text == "HMIM")
                    lbldiv.Text = Request.QueryString["div"].ToString();
                else
                    lbldiv.Text = "0";
                string _mode = _prm.Substring(0, 1);
                lblmode.Text = _mode;
                Load_Cassheets();
                Load_Service();
                Load_FilteringElements();
                //Generate_Summary();
                //Generate_Summary_Graph();
                Session["bz"] = "All";
                Session["fl"] = "All";

                if (_mode != "9") { tdPcd_01.Visible = false; tdPcd_02.Visible = false; }

                if (_mode == "0")
                {
                    if (lblprj.Text == "CCAD")
                        Generate_Project_Summary_ccad();
                    //else if (lblprj.Text == "MOE" || lblprj.Text == "PCD" || lblprj.Text == "11784")
                    else if (isNewProject)
                        Generate_Project_Summary_New();
                    else
                        Generate_Project_Summary();
                }
                else if (_mode == "9")
                {
                    if (lblprj.Text == "PCD" || lblprj.Text == "ARSD") Generate_Project_Summary_Overall_Pcd();

                }
                else
                {
                    Generate_Service_Summary();
                }
                lblsrv.Text = (string)Session["srv"];

                Generate_Reports((string)Session["bz"], (string)Session["fl"], _mode);
            }

            else
            {
                if (Session["Report"] != null)
                {
                    CrystalReportViewer2.ReportSource = (ReportDocument)Session["Report"];
                    CrystalReportViewer2.DataBind();
                }
            }

        }
        private void Generate_Project_Summary_New()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;

            _clscassheet _objcls = new _clscassheet();
            _objcls.b_zone = Session["bz"].ToString();
            _objcls.f_level = Session["fl"].ToString();

            if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
            {

                _objcls.srv = Convert.ToInt32(lbldiv.Text);
                _objbll.Generate_Prj_summary_Overall_Bldng(_objcls, _objdb);

            }
            else _objbll.Generate_Prj_summary_Overall(_objcls, _objdb);

            //_objbll.Generate_Prj_summary_Overall(_objcls, _objdb);

        }
        private void Generate_Project_Summary_Overall_Pcd()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;

            _clscassheet _objcls = new _clscassheet();
            _objcls.b_zone = Session["bz"].ToString();
            _objcls.f_level = Session["fl"].ToString();


            var todaysDate = DateTime.Today;
            if (!string.IsNullOrEmpty(hdnpcd.Value))
            {
                todaysDate = DateTime.ParseExact(hdnpcd.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            }

            Session["pcd_date"] = todaysDate;
            _objcls.date = todaysDate;


            _objbll.Generate_Prj_summary_Overall_Pcd(_objcls, _objdb);

        }
        private void Generate_Project_Summary()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsproject _objcls1 = new _clsproject();
            _objcls1.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls1, _objdb);
            _objbll.Clear_CasServiceSummary(_objdb);
            var Service = from _data in _dtService.AsEnumerable()
                          select _data;

            decimal _overall = 0;

            _clscassheet _objcls;

            foreach (var _srow in Service)
            {
                decimal _result = 0;
                decimal _weightage = 0;
                string _srv = _srow[2].ToString();

                if (lblprj.Text == "demo") _weightage = Convert.ToDecimal(_srow["weightage"].ToString());

                var Cassheets = (from DataRow dRow in _dtMaster.Rows
                                 where dRow.Field<int>("SYS_SER_ID") == Convert.ToInt32(_srv)
                                 select new { col1 = dRow["PRJ_CAS_ID"], col2 = dRow["PRJ_CAS_NAME"] });
                foreach (var _row in Cassheets)
                {
                    if (_srow[2].ToString() == "1")
                    {
                        if (_row.col1.ToString() == "5" || _row.col1.ToString() == "1")
                        {
                            Load_Master(5);
                            if (lblprj.Text == "demo")
                                _result += Summary5_New();
                            else _result += Summary1_5();
                        }
                        else if (_row.col1.ToString() == "2")
                        {
                            Load_Master(2);
                            _result += Summary2();
                        }
                        else if (_row.col1.ToString() == "3")
                        {
                            Load_Master(3);
                            _result += Summary3();
                        }
                        else if (_row.col1.ToString() == "4")
                        {
                            Load_Master(4);
                            _result += Summary4();
                        }
                        else if (_row.col1.ToString() == "6")
                        {
                            Load_Master(6);
                            _result += Summary6();
                        }
                        else if (_row.col1.ToString() == "7")
                        {
                            Load_Master(7);
                            _result += Summary7();
                        }
                        else if (_row.col1.ToString() == "37")
                        {
                            Load_Master(37);
                            _result += Summary37();
                        }
                        else if (_row.col1.ToString() == "24")
                        {
                            if (lblprj.Text == "12761")
                            {
                                Load_Master(24);
                                _result += Summary24_2();
                            }
                        }
                    }
                    else if (_srow[2].ToString() == "2")
                    {
                        if (_row.col1.ToString() == "8")
                        {
                            Load_Master(8);
                            _result += Summary8();
                        }
                        else if (_row.col1.ToString() == "21")
                        {
                            Load_Master(21);
                            _result += Summary21();
                        }
                        else if (_row.col1.ToString() == "9")
                        {
                            Load_Master(9);
                            _result += Summary9();
                        }
                    }
                    else if (_srow[2].ToString() == "4")
                    {
                        if (_row.col1.ToString() == "17")
                        {
                            Load_Master(17);
                            _result += Summary17();
                        }
                        else if (_row.col1.ToString() == "18")
                        {
                            Load_Master(18);
                            _result += Summary18();
                        }
                        else if (_row.col1.ToString() == "19")
                        {
                            Load_Master(19);
                            _result += Summary19();
                        }

                    }
                    else if (_srow[2].ToString() == "3")
                    {
                        if (_row.col1.ToString() == "22")
                        {
                            Load_Master(22);
                            _result += Summary22();
                        }
                        else if (_row.col1.ToString() == "11")
                        {
                            Load_Master(11);
                            _result += Summary11();
                        }
                        else if (_row.col1.ToString() == "12")
                        {
                            Load_Master(12);
                            _result += Summary12();
                        }
                        else if (_row.col1.ToString() == "10")
                        {
                            Load_Master(10);

                            if (lblprj.Text == "HMIM")
                                _result += Summary10_HMIM();
                            else if (lblprj.Text == "14211")
                                _result += Summary10_14211();
                            else
                                _result += Summary10();
                        }
                        else if (_row.col1.ToString() == "13")
                        {
                            Load_Master(13);
                            _result += Summary13();
                        }
                        else if (_row.col1.ToString() == "14")
                        {
                            Load_Master(14);
                            _result += Summary14();
                        }
                        else if (_row.col1.ToString() == "16")
                        {
                            Load_Master(16);
                            _result += Summary16();
                        }
                        else if (_row.col1.ToString() == "20")
                        {
                            Load_Master(20);
                            _result += Summary20();
                        }
                        else if (_row.col1.ToString() == "23")
                        {
                            Load_Master(23);
                            _result += Summary20();
                        }
                        else if (_row.col1.ToString() == "24")
                        {
                            Load_Master(24);
                            _result += Summary20();
                        }
                        else if (_row.col1.ToString() == "25")
                        {
                            Load_Master(25);
                            _result += Summary20();
                        }
                        else if (_row.col1.ToString() == "26")
                        {
                            Load_Master(26);
                            _result += Summary20();
                        }
                        else if (_row.col1.ToString() == "15")
                        {
                            Load_Master(15);
                            if (lblprj.Text == "HMIM")
                                _result += Summary15();
                            else
                                _result += Summary20();
                        }

                        else if (_row.col1.ToString() == "28")
                        {
                            Load_Master(28);
                            if (lblprj.Text == "HMIM")
                                _result += Summary28_HMIM();
                            else
                                _result += Summary20();
                        }
                    }
                    else if (_srow[2].ToString() == "9")
                    {
                        if (_row.col1.ToString() == "31")
                        {
                            Load_Master(31);
                            _result += Summary31();
                        }

                        else if (_row.col1.ToString() == "32")
                        {
                            Load_Master(32);
                            _result += Summary32();
                        }

                    }


                }
                //if (_srow[2].ToString() == "1") _result = _result / 6; 
                //else if (_srow[2].ToString() == "2") _result = _result / 3;
                //else if (_srow[2].ToString() == "4") _result = _result / 3;
                //else if (_srow[2].ToString() == "3") _result = _result / 8;

                _objcls = new _clscassheet();

                _objdb.DBName = "DB_" + lblprj.Text;
                _objcls.srv = Convert.ToInt32(_srow[2].ToString());
                int count = _objbll.Get_NoofCas(_objcls, _objdb);
                if (lblprj.Text == "12761")
                    count = count - 1;
                _result = _result / count;
                _objdb.DBName = "DBCML";
                _objcls.cate = _srow[1].ToString();
                _objcls.per_com1 = decimal.Round(_result, 0, MidpointRounding.AwayFromZero);
                _objbll.Insert_CasServiceSummary(_objcls, _objdb);


                _overall += (_result * _weightage);


            }

            if (lblprj.Text == "demo")
            {
                _objcls = new _clscassheet();

                _objcls.srv = 0;
                _objdb.DBName = "DBCML";
                _objcls.cate = "Overall";
                _objcls.per_com1 = decimal.Round(_overall, MidpointRounding.AwayFromZero);
                _objbll.Insert_CasServiceSummary(_objcls, _objdb);

            }


            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _result.ToString() + "');", true);
        }
        private void Generate_Project_Summary_ccad()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsproject _objcls1 = new _clsproject();
            _objcls1.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls1, _objdb);
            _objbll.Clear_CasServiceSummary(_objdb);
            _objdb.DBName = "DB_" + lblprj.Text;
            DataTable _dthead = _objbll.LOAD_PRJSUMMARY_HEADS(_objdb);
            _objdb.DBName = "DBCML";
            var Service = from _data in _dthead.AsEnumerable()
                          select _data;
            decimal _srv1 = 0;
            decimal _srv2 = 0;
            decimal _srv3 = 0;
            decimal _srv4 = 0;
            decimal _srv8 = 0;
            decimal _srv13 = 0;
            decimal _srv14 = 0;
            foreach (var _srow in Service)
            {
                decimal _result = 0;
                string _srv = "";
                if (_srow[0].ToString() != "11")
                {
                    ////if (_srow[0].ToString() == "9" || _srow[0].ToString() == "10")
                    ////    _srv = "4";
                    ////else
                    _srv = _srow[0].ToString();
                    var Cassheets = (from DataRow dRow in _dtMaster.Rows
                                     where dRow.Field<int>("SYS_SER_ID") == Convert.ToInt32(_srv)
                                     select new { col1 = dRow["PRJ_CAS_ID"], col2 = dRow["PRJ_CAS_NAME"] });
                    foreach (var _row in Cassheets)
                    {
                        if (_srow[0].ToString() == "1")
                        {
                            if (_row.col1.ToString() == "5")
                            {
                                Load_Master(5);
                                _result += Summary5_1();
                            }
                            else if (_row.col1.ToString() == "44")
                            {
                                Load_Master(44);
                                _result += Summary5_1();
                            }
                            else if (_row.col1.ToString() == "2")
                            {
                                Load_Master(121);
                                _result += Summary2_1();
                                Load_Master(120);
                                _result += Summary3_1();
                            }
                            else if (_row.col1.ToString() == "41")
                            {
                                Load_Master(119);
                                _result += Summary2_1();
                                Load_Master(3);
                                _result += Summary3_1();
                            }
                            else if (_row.col1.ToString() == "42")
                            {
                                Load_Master(118);
                                _result += Summary2_1();
                                Load_Master(4);
                                _result += Summary4_1();
                            }
                            else if (_row.col1.ToString() == "6")
                            {
                                Load_Master(6);
                                _result += Summary6_1();
                            }
                            else if (_row.col1.ToString() == "7")
                            {
                                Load_Master(7);
                                _result += Summary7_1();
                            }
                            else
                            {
                                _result += 0;
                            }
                            _srv1 = _result / 7;
                        }
                        else if (_srow[0].ToString() == "2")
                        {
                            if (_row.col1.ToString() == "8")
                            {
                                Load_Master(8);
                                _result += Summary8_1();
                            }
                            else if (_row.col1.ToString() == "51")
                            {
                                if (lblprj.Text == "CCAD")
                                {
                                    Load_Master(51);
                                    _result += Summary8_1();
                                }
                            }
                            else if (_row.col1.ToString() == "52")
                            {
                                if (lblprj.Text == "CCAD")
                                {
                                    Load_Master(52);
                                    _result += Summary8_1();
                                }
                            }
                            else if (_row.col1.ToString() == "53")
                            {
                                if (lblprj.Text == "CCAD")
                                {
                                    Load_Master(53);
                                    _result += Summary8_1();
                                }
                            }
                            else if (_row.col1.ToString() == "54")
                            {
                                if (lblprj.Text == "CCAD")
                                {
                                    Load_Master(54);
                                    _result += Summary8_1();
                                }
                            }
                            else if (_row.col1.ToString() == "55")
                            {
                                if (lblprj.Text == "CCAD")
                                {
                                    _result += Summary55();
                                }
                            }
                            else if (_row.col1.ToString() == "56")
                            {
                                if (lblprj.Text == "CCAD")
                                {
                                    Load_Master(56);
                                    _result += Summary8_1();
                                }
                            }
                            else if (_row.col1.ToString() == "57")
                            {
                                if (lblprj.Text == "CCAD")
                                {
                                    Load_Master(57);
                                    _result += Summary8_1();
                                }
                            }
                            else if (_row.col1.ToString() == "58")
                            {
                                if (lblprj.Text == "CCAD")
                                {
                                    Load_Master(58);
                                    _result += Summary8_1();
                                }
                            }
                            else if (_row.col1.ToString() == "59")
                            {
                                if (lblprj.Text == "CCAD")
                                {
                                    Load_Master(59);
                                    _result += Summary8_1();
                                }
                            }
                            else if (_row.col1.ToString() == "60")
                            {
                                if (lblprj.Text == "CCAD")
                                {
                                    Load_Master(60);
                                    _result += Summary8_1();
                                }
                            }
                            else
                            {
                                _result += 0;
                            }
                            _srv2 = _result / 11;
                        }
                        else if (_srow[0].ToString() == "4")
                        {

                            if (_row.col1.ToString() == "85")
                            {
                                Load_Master(85);
                                _result += Summary17_1();
                            }
                            else if (_row.col1.ToString() == "86")
                            {
                                Load_Master(86);
                                _result += Summary17_1();
                            }
                            else if (_row.col1.ToString() == "87")
                            {
                                Load_Master(87);
                                _result += Summary17_1();
                            }
                            else if (_row.col1.ToString() == "88")
                            {
                                Load_Master(88);
                                _result += Summary17_1();
                            }
                            else if (_row.col1.ToString() == "89")
                            {
                                Load_Master(89);
                                _result += Summary17_1();
                            }
                            else if (_row.col1.ToString() == "90")
                            {
                                Load_Master(90);
                                _result += Summary17_1();
                            }
                            else if (_row.col1.ToString() == "91")
                            {
                                Load_Master(91);
                                _result += Summary17_1();
                            }
                            else if (_row.col1.ToString() == "99")
                            {
                                Load_Master(99);
                                _result += Summary17_1();
                            }
                            else if (_row.col1.ToString() == "95")
                            {
                                Load_Master(95);
                                _result += Summary17_1();
                            }
                            else if (_row.col1.ToString() == "97")
                            {
                                Load_Master(97);
                                _result += Summary17_1();
                            }
                            else if (_row.col1.ToString() == "100")
                            {
                                Load_Master(100);
                                _result += Summary28_1();
                            }
                            else if (_row.col1.ToString() == "94")
                            {
                                Load_Master(101);
                                _result += Summary17_1();
                                Load_Master(102);
                                _result += Summary19_1();
                            }
                            else
                            {
                                _result += 0;
                            }
                            _srv4 = _result / 19;
                        }
                        else if (_srow[0].ToString() == "8")
                        {

                            if (_row.col1.ToString() == "103")
                            {
                                Load_Master(103);
                                _result += Summary27_1();
                            }
                            else if (_row.col1.ToString() == "104")
                            {
                                Load_Master(104);
                                _result += Summary27_1();
                            }
                            else if (_row.col1.ToString() == "105")
                            {
                                Load_Master(105);
                                _result += Summary27_1();
                            }
                            else if (_row.col1.ToString() == "106")
                            {
                                Load_Master(106);
                                _result += Summary27_1();
                            }
                            else if (_row.col1.ToString() == "109")
                            {
                                Load_Master(109);
                                _result += Summary27_1();
                            }
                            else if (_row.col1.ToString() == "110")
                            {
                                Load_Master(110);
                                _result += Summary27_1();
                            }
                            else if (_row.col1.ToString() == "111")
                            {
                                Load_Master(111);
                                _result += Summary27_1();
                            }
                            else if (_row.col1.ToString() == "107")
                            {
                                Load_Master(107);
                                _result += Summary17_1();
                            }
                            else if (_row.col1.ToString() == "108")
                            {
                                Load_Master(108);
                                _result += Summary17_1();
                            }
                            else
                            {
                                _result += 0;
                            }
                            _srv8 = _result / 9;
                        }
                        else if (_srow[0].ToString() == "3")
                        {
                            if (_row.col1.ToString() == "22")
                            {
                                Load_Master(22);
                                _result += Summary20_1();
                            }
                            else if (_row.col1.ToString() == "11")
                            {
                                Load_Master(11);
                                _result += Summary20_1();
                            }
                            else if (_row.col1.ToString() == "12")
                            {
                                Load_Master(12);
                                _result += Summary12_1();
                            }
                            else if (_row.col1.ToString() == "10")
                            {
                                Load_Master(10);
                                _result += Summary10_1();
                            }
                            else if (_row.col1.ToString() == "13")
                            {
                                Load_Master(13);
                                _result += Summary20_1();
                            }
                            else if (_row.col1.ToString() == "14")
                            {
                                Load_Master(14);
                                _result += Summary20_1();
                            }
                            else if (_row.col1.ToString() == "16")
                            {
                                Load_Master(16);
                                _result += Summary20_1();
                            }
                            else if (_row.col1.ToString() == "20")
                            {
                                Load_Master(20);
                                _result += Summary20_1();
                            }
                            else if (_row.col1.ToString() == "23")
                            {
                                Load_Master(23);
                                _result += Summary20_1();
                            }
                            else if (_row.col1.ToString() == "24")
                            {
                                Load_Master(24);
                                _result += Summary20_1();
                            }
                            else if (_row.col1.ToString() == "25")
                            {
                                Load_Master(25);
                                _result += Summary20_1();
                            }
                            else if (_row.col1.ToString() == "26")
                            {
                                Load_Master(26);
                                _result += Summary20_1();
                            }
                            else if (_row.col1.ToString() == "15")
                            {
                                Load_Master(15);
                                _result += Summary20_1();
                            }
                            else if (_row.col1.ToString() == "29")
                            {
                                Load_Master(29);
                                _result += Summary20_1();
                            }
                            else
                            {
                                _result += 0;
                            }
                            _srv3 = _result / 19;
                        }
                        else if (_srow[0].ToString() == "13")
                        {
                            if (_row.col1.ToString() == "112")
                            {
                                Load_Master(112);
                                _result += Summary27_1();
                            }
                            else if (_row.col1.ToString() == "116")
                            {
                                Load_Master(116);
                                _result += Summary27_1();
                            }
                            else
                                _result += 0;
                            _srv13 = _result / 5;
                        }
                        else if (_srow[0].ToString() == "14")
                        {
                            if (_row.col1.ToString() == "117")
                            {
                                Load_Master(117);
                                _result += Summary17_1();
                            }
                            _srv14 = _result / 1;
                        }
                    }

                    //if (_srow[2].ToString() == "1") _result = _result / 6; 
                    //else if (_srow[2].ToString() == "2") _result = _result / 3;
                    //else if (_srow[2].ToString() == "4") _result = _result / 3;
                    //else if (_srow[2].ToString() == "3") _result = _result / 8;
                    _clscassheet _objcls = new _clscassheet();
                    _objdb.DBName = "DB_" + lblprj.Text;
                    _objcls.srv = Convert.ToInt32(_srow[0].ToString());
                    int count = _objbll.Get_NoofCas(_objcls, _objdb);

                    _result = _result / count;
                    _objdb.DBName = "DBCML";
                    _objcls.cate = _srow[1].ToString();
                    _objcls.per_com1 = decimal.Round(_result);
                    _objbll.Insert_CasServiceSummary(_objcls, _objdb);
                }
                else
                {
                    _clscassheet _objcls = new _clscassheet();
                    _objdb.DBName = "DB_" + lblprj.Text;
                    _objcls.srv = Convert.ToInt32(_srow[0].ToString());
                    //int count = _objbll.Get_NoofCas(_objcls, _objdb);
                    //if (_srow[0].ToString() == "9")
                    //    _result = _result / 1;
                    //else if (_srow[0].ToString() == "10")
                    //    _result = _result / 2;
                    //else
                    //    _result = _result / count;
                    _result = ((_srv1 * 0.20m) + (_srv2 * 0.25m) + (_srv3 * 0.25m) + (_srv4 * 0.15m) + (_srv8 * 0.05m) + (_srv13 * 0.05m) + (_srv14 * 0.05m));
                    _objdb.DBName = "DBCML";
                    _objcls.cate = _srow[1].ToString();
                    _objcls.per_com1 = decimal.Round(_result);
                    _objbll.Insert_CasServiceSummary(_objcls, _objdb);
                }
            }
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _result.ToString() + "');", true);
        }
        private bool IsNumeric(object Expression)
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
        private decimal Summary8_1()
        {
            decimal _pre_qty = 0;
            decimal _comm_qty = 0;
            decimal _fpt = 0;
            decimal _arm = 0;
            decimal _overall = 0;
            decimal _count = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com5"].ToString());//pft
                        _p5 += Convert.ToDecimal(_row["per_com6"].ToString());//pwron
                        _p6 += Convert.ToDecimal(_row["per_com7"].ToString());//fpt
                        _p7 += Convert.ToDecimal(_row["per_com8"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    _pre_qty += _p1;
                    _comm_qty += _p2;
                    _fpt += _p6;
                    _arm += _p7;
                    _count += count;
                    //decimal _per1 = 0;
                    //decimal _per2 = 0;
                    //decimal _per3 = 0;
                    //decimal _per4 = 0;
                    //decimal _per5 = 0;
                    //decimal _com1 = 0;
                    //decimal _com2 = 0;
                    //if (_p1 != 0)
                    //{
                    //    _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
                    //    _com1 = _per1 * 100;
                    //}
                    //if (_p2 != 0)
                    //{
                    //    _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
                    //    _com2 = _per2 * 100;
                    //}
                    //if (_p3 != 0)
                    //    _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count), 2);
                    //_total = Decimal.Round(((_com1 * 0.1m) + (_com2 * 0.9m)));
                    //if (_p6 != 0)
                    //    _per4 = Decimal.Round(_p6 / Convert.ToDecimal(count), 2);
                    //if (_p7 != 0)
                    //    _per5 = Decimal.Round(_p7 / Convert.ToDecimal(count), 2);
                    //_total1 = Decimal.Round(((_per4 * 0.5m) + (_per5 * 0.5m)) * 100);
                    //_overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));

                }
                if (_count > 0)
                {
                    decimal _compl1 = 0;
                    decimal _compl2 = 0;
                    _compl1 = Decimal.Round((((_pre_qty * 0.1m) + (_comm_qty * 0.9m)) / _count) * 100);
                    _compl2 = Decimal.Round((((_fpt * 0.5m) + (_arm * 0.5m)) / _count) * 100);
                    _overall = Decimal.Round(((_compl1 * 0.8m) + (_compl2 * 0.2m)));
                }
                return _overall;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private void Load_FilteringElements()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clstis _objcas = new _clstis();

            _objdb.DBName = "DB_" + lblprj.Text;
            if (lblprj.Text == "HMIM" || lblprj.Text == "14211")
            {
                _objcas.bldg_id = Convert.ToInt32(lbldiv.Text);
                drflevel.DataSource = _objbll.Load_Project_FloorLevel(_objcas, _objdb);
            }
            else
                drflevel.DataSource = _objbll.Load_Project_FloorLevel(_objdb);
            drflevel.DataTextField = "F_lvl";
            drflevel.DataValueField = "F_lvl";
            drflevel.DataBind();
            drflevel.Items.Insert(0, "All");
            if (lblprj.Text == "HMIM" || lblprj.Text == "14211")
            {
                _objcas.bldg_id = Convert.ToInt32(lbldiv.Text);
                drbzone.DataSource = _objbll.Load_Project_BZone(_objcas, _objdb);
            }
            else
                drbzone.DataSource = _objbll.Load_Project_BZone(_objdb);
            drbzone.DataTextField = "B_Z";
            drbzone.DataValueField = "B_Z";
            drbzone.DataBind();
            drbzone.Items.Insert(0, "All");
        }
        private void Filtering(string _el1, string _el2)
        {
            if (_el1 == "") _el1 = "All";
            if (_el2 == "") _el2 = "All";
            var _result = from _data in _dtdetails.AsEnumerable()
                          select _data;
            if (_el1 == "All" && _el2 == "All")
            {
                _result = from _data in _dtdetails.AsEnumerable()
                          select _data;
            }
            else if (_el1 != "All" && _el2 == "All")
            {
                _result = from _data in _dtdetails.AsEnumerable()
                          where _data.Field<string>("B_Z") == _el1
                          select _data;
            }
            else if (_el1 != "All" && _el2 != "All")
            {
                _result = from _data in _dtdetails.AsEnumerable()
                          where _data.Field<string>("F_lvl") == _el2 && _data.Field<string>("B_Z") == _el1
                          select _data;
            }
            else if (_el1 == "All" && _el2 != "All")
            {
                _result = from _data in _dtdetails.AsEnumerable()
                          where _data.Field<string>("F_lvl") == _el2
                          select _data;
            }
            //var dt = _result.CopyToDataTable<DataRow>();
            _dtresult = _result.Any() ? _result.CopyToDataTable<DataRow>() : _dtdetails.Clone();
            //Label1.Text = _dtresult.Rows.Count.ToString();
        }

        protected void drbzone_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////Filtering(drbzone.SelectedItem.Text, drflevel.SelectedItem.Text);
            //Session["bz"] = drbzone.SelectedItem.Text;
            //if (lblmode.Text == "0")
            //    Generate_Project_Summary();
            //else
            //    Generate_Service_Summary();
            //Generate_Reports((string)Session["bz"], (string)Session["fl"]);
        }

        protected void drflevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Filtering(drbzone.SelectedItem.Text, drflevel.SelectedItem.Text);
            //Session["fl"] = drflevel.SelectedItem.Text;
            //if (lblmode.Text == "0")
            //    Generate_Project_Summary();
            //else
            //    Generate_Service_Summary();
            //Generate_Reports((string)Session["bz"], (string)Session["fl"]);
        }

        private decimal Summary9_1()
        {
            try
            {
                decimal _pre_qty = 0;
                decimal _comm_qty = 0;
                decimal _fpt = 0;
                decimal _arm = 0;
                decimal _pwron = 0;
                decimal _ins = 0;
                decimal _pft = 0;
                decimal _overall = 0;
                decimal _count = 0;
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _p8 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com5"].ToString());//pft
                        _p5 += Convert.ToDecimal(_row["per_com6"].ToString());//pwron
                        _p6 += Convert.ToDecimal(_row["per_com7"].ToString());//fpt
                        _p7 += Convert.ToDecimal(_row["per_com8"].ToString());//arm
                        _p8 += Convert.ToDecimal(_row["per_com4"].ToString());//ins
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    _pre_qty += _p1;
                    _comm_qty += _p2;
                    _fpt += _p6;
                    _arm += _p7;
                    _ins += _p8;
                    _pft += _p4;
                    _pwron += _p5;
                    _count += count;
                    //decimal _per1 = 0;
                    //decimal _per2 = 0;
                    //decimal _per3 = 0;
                    //decimal _per4 = 0;
                    //decimal _per5 = 0;
                    //decimal _per6 = 0;
                    //decimal _per7 = 0;
                    //decimal _com1 = 0;
                    //decimal _com2 = 0;
                    //if (_p1 != 0)
                    //{
                    //    _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
                    //    _com1 = _per1 * 100;
                    //}
                    //if (_p2 != 0)
                    //{
                    //    _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
                    //    _com2 = _per2 * 100;
                    //}
                    //if (_p4 != 0)
                    //    _per3 = Decimal.Round(_p4 / Convert.ToDecimal(count), 2);
                    //_total = Decimal.Round(((_com1 * 0.1m) + (_com2 * 0.9m)));
                    //if (_p5 != 0)
                    //    _per4 = Decimal.Round(_p5 / Convert.ToDecimal(count), 2);
                    //if (_p6 != 0)
                    //    _per5 = Decimal.Round(_p6 / Convert.ToDecimal(count), 2);
                    //if (_p8 != 0)
                    //    _per6 = Decimal.Round(_p8 / Convert.ToDecimal(count), 2);
                    //if (_p7 != 0)
                    //    _per7 = Decimal.Round(_p7 / Convert.ToDecimal(count), 2);
                    //_total1 = Decimal.Round(((_per4 * 0.2m) + (_per5 * 0.2m) + (_per6 * 0.2m) + (_per3 * 0.2m) + (_per7 * 0.2m)) * 100);
                    //_overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                    //DataRow _drow = _dtsummary.NewRow();
                    //_drow[0] = row.col2.ToString();
                    //_drow[1] = count.ToString();
                    //_drow[2] = Decimal.Round(_p1).ToString();
                    //_drow[3] = Decimal.Round(_p2).ToString();
                    //_drow[4] = Decimal.Round(_p3).ToString();
                    //_drow[5] = _overall.ToString();
                    //_drow[6] = row.col3.ToString();
                    //_dtsummary.Rows.Add(_drow);
                }
                if (_count > 0)
                {
                    decimal _compl1 = 0;
                    decimal _compl2 = 0;
                    _compl1 = Decimal.Round((((_pre_qty * 0.1m) + (_comm_qty * 0.9m)) / _count) * 100);
                    _compl2 = Decimal.Round((((_fpt * 0.25m) + (_arm * 0.25m) + (_pft * 0.25m) + (_ins * 0.25m)) / _count) * 100);
                    _overall = Decimal.Round(((_compl1 * 0.8m) + (_compl2 * 0.2m)));
                }
                return _overall;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary2_1()
        {
            decimal _overall = 0;
            decimal _total = 0;
            decimal _total1 = 0;

            decimal _per3 = 0;
            decimal _per4 = 0;
            decimal _per5 = 0;
            decimal _per6 = 0;
            int _count = 0;
            int _qty = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com6"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com2"].ToString());//pft
                        _p4 += Convert.ToDecimal(_row["per_com3"].ToString());//pwron
                        _p5 += Convert.ToDecimal(_row["per_com4"].ToString());//fpt
                        _p6 += Convert.ToDecimal(_row["per_com5"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }

                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    _total += Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), 2);
                    if (_p3 != 0)
                        _per3 += Decimal.Round((_p3), 2);
                    if (_p4 != 0)
                        _per4 += Decimal.Round((_p4), 2);
                    if (_p5 != 0)
                        _per5 += Decimal.Round((_p5), 2);
                    if (_p6 != 0)
                        _per6 += Decimal.Round((_p6), 2);

                    //decimal _overall1 = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)),2);
                    //_overall += _overall1;
                    _count += 1;
                    _qty += count;
                }
                if (_count != 0)
                {
                    _total1 = Decimal.Round((((_per3 * 0.25m) + (_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m)) * 100), 2);
                    _overall = Decimal.Round(((_total / _count) * 0.8m) + (_total1 / _qty * 0.2m), 0, MidpointRounding.AwayFromZero);
                    return (_overall);
                }
                else return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary5_1()
        {
            decimal _overall = 0;
            decimal _total = 0;
            decimal _total1 = 0;
            decimal _per1 = 0;
            decimal _per2 = 0;
            decimal _per3 = 0;
            decimal _per7 = 0;
            decimal _per4 = 0;
            decimal _per5 = 0;
            decimal _per6 = 0;
            int _count = 0;
            int _qty = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;

                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pft
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//pwron
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//fpt
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }

                    if (_p1 != 0)
                        _per1 += Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 += Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    if (_p3 != 0)
                        _per3 += Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    if (row.col3.ToString() == "PFC")
                        _total += Decimal.Round(_per1, 2);
                    else if (row.col3.ToString() == "MDB" || row.col3.ToString() == "VFD" || row.col3.ToString() == "MCC")
                        _total += Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m)), 2);
                    else if (row.col3.ToString() == "ATS" || row.col3.ToString() == "UPS" || row.col3.ToString() == "LCP" || row.col3.ToString() == "BAT")
                        _total += Decimal.Round(((_per1 * 0.8m) + (_per2 * 0.2m)), 2);
                    else if (row.col3.ToString() == "IPS")
                        _total += Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), 2);
                    else if (row.col3.ToString() == "DB")
                        _total += Decimal.Round(((_per2 * 0.7m) + (_per3 * 0.3m)), 2);
                    else
                        _total += Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m)), 2);
                    if (_p4 != 0)
                        _per4 += Decimal.Round((_p4), 2);
                    if (_p5 != 0)
                        _per5 += Decimal.Round((_p5), 2);
                    if (_p6 != 0)
                        _per6 += Decimal.Round((_p6), 2);
                    if (_p7 != 0)
                        _per7 += Decimal.Round((_p7), 2);

                    //decimal _overall1 = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)),2);
                    //_overall += _overall1;
                    _count += 1;
                    _qty += count;
                }
                if (_count != 0)
                {
                    _total = (((_per1 / (_count - 1)) * 0.5m) + ((_per2 / (_count - 1)) * 0.3m) + ((_per3 / (_count - 6)) * 0.2m));
                    _total1 = Decimal.Round((((_per7 * 0.25m) + (_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m)) * 100), 2);
                    _overall = Decimal.Round((_total * 0.8m) + (_total1 / _qty * 0.2m));
                    return (_overall);
                }
                else return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary4_1()
        {
            decimal _overall = 0;
            decimal _total = 0;
            decimal _total1 = 0;

            decimal _per4 = 0;
            decimal _per5 = 0;
            decimal _per6 = 0;
            decimal _per3 = 0;
            int _count = 0;
            int _qty = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _per1 = 0;
                    decimal _per2 = 0;

                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//pft
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pwron
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//fpt
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }

                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    _total += Decimal.Round(((_per1 * 0.6m) + (_per2 * 0.4m)), 2);
                    if (_p3 != 0)
                        _per3 += Decimal.Round((_p3), 2);
                    if (_p4 != 0)
                        _per4 += Decimal.Round((_p4), 2);
                    if (_p5 != 0)
                        _per5 += Decimal.Round((_p5), 2);
                    if (_p6 != 0)
                        _per6 += Decimal.Round((_p6), 2);

                    //decimal _overall1 = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)),2);
                    //_overall += _overall1;
                    _count += 1;
                    _qty += count;
                }
                if (_count != 0)
                {
                    _total1 = Decimal.Round((((_per3 * 0.25m) + (_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m)) * 100), 2);
                    _overall = Decimal.Round(((_total / _count) * 0.8m) + (_total1 / _qty * 0.2m));
                    return (_overall);
                }
                else return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary6_1()
        {
            decimal _overall = 0;
            decimal _total = 0;
            decimal _total1 = 0;
            decimal _per1 = 0;
            decimal _per2 = 0;
            decimal _per3 = 0;
            decimal _per4 = 0;
            decimal _per5 = 0;
            decimal _per6 = 0;
            decimal _per7 = 0;
            int _count = 0;
            int _qty = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;

                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com5"].ToString());//pft
                        _p5 += Convert.ToDecimal(_row["per_com6"].ToString());//pwron
                        _p6 += Convert.ToDecimal(_row["per_com7"].ToString());//fpt
                        _p7 += Convert.ToDecimal(_row["per_com8"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }

                    //if (_p1 != 0)
                    //    _per1 = ((_p1 / Convert.ToDecimal(count)) * 100);
                    //if (_p2 != 0)
                    //    _per2 = ((_p2 / Convert.ToDecimal(count)) * 100);
                    //if (_p3 != 0)
                    //    _per3 = ((_p3 / Convert.ToDecimal(count)) * 100);
                    //_total += Decimal.Round(((Decimal.Round(_per1) * 0.6m) + (Decimal.Round(_per2) * 0.3m) + (Decimal.Round(_per3) * 0.1m)), 0, MidpointRounding.AwayFromZero);
                    _per1 += _p1;
                    _per2 += _p2;
                    _per3 += _p3;
                    //_total += Decimal.Round(((_per1 * 0.6m) + (_per2 * 0.3m) + (_per3 * 0.1m)), 2);
                    //if (_p7 != 0)
                    //    _per7 += Decimal.Round((_p7), 2);
                    //if (_p4 != 0)
                    //    _per4 += Decimal.Round((_p4), 2);
                    //if (_p5 != 0)
                    //    _per5 += Decimal.Round((_p5), 2);
                    //if (_p6 != 0)
                    //    _per6 += Decimal.Round((_p6), 2);
                    if (_p4 != 0)
                        _per4 += _p4;
                    if (_p5 != 0)
                        _per5 += (_p5 / Convert.ToDecimal(count));
                    if (_p6 != 0)
                        _per6 += (_p6 / Convert.ToDecimal(count));
                    if (_p7 != 0)
                        _per7 += _p7;

                    //decimal _overall1 = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)),2);
                    //_overall += _overall1;
                    _count += 1;
                    _qty += count;
                }
                if (_count != 0)
                {
                    decimal _pits = Decimal.Round((_per1 / _qty) * 100, 0, MidpointRounding.AwayFromZero);
                    decimal _con = Decimal.Round((_per2 / _qty) * 100, 0, MidpointRounding.AwayFromZero);
                    decimal _bon = Decimal.Round((_per3 / _qty) * 100, 0, MidpointRounding.AwayFromZero);
                    decimal _pft = Decimal.Round((_per4 / _qty) * 100, 0, MidpointRounding.AwayFromZero);
                    decimal _acc = Decimal.Round((_per7 / _qty) * 100, 0, MidpointRounding.AwayFromZero);
                    _total = Decimal.Round((_pits * 0.6m + _con * 0.3m + _bon * 0.1m), 0, MidpointRounding.AwayFromZero);
                    _total1 = Decimal.Round(_pft * 0.5m + _acc * 0.5m, 0, MidpointRounding.AwayFromZero);
                    //decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)), 0, MidpointRounding.AwayFromZero);
                    //_total1 = Decimal.Round((((_per7 * 0.25m) + (_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m)) * 100), 2);
                    _overall = Decimal.Round((_total * 0.8m) + (_total1 * 0.2m), 0, MidpointRounding.AwayFromZero);
                    return (_overall);
                }
                else return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary3_1()
        {
            decimal _overall = 0;
            decimal _total = 0;
            decimal _total1 = 0;

            decimal _per4 = 0;
            decimal _per5 = 0;
            decimal _per6 = 0;
            decimal _per3 = 0;
            int _count = 0;
            int _qty = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//pft
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pwron
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//fpt
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }

                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    _total += Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), 2);
                    if (_p3 != 0)
                        _per3 += Decimal.Round((_p3), 2);
                    //if (_p7 != 0)
                    //    _per7 += Decimal.Round((_p7), 2);
                    if (_p4 != 0)
                        _per4 += Decimal.Round((_p4), 2);
                    if (_p5 != 0)
                        _per5 += Decimal.Round((_p5), 2);
                    if (_p6 != 0)
                        _per6 += Decimal.Round((_p6), 2);

                    //decimal _overall1 = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)),2);
                    //_overall += _overall1;
                    _count += 1;
                    _qty += count;
                }
                if (_count != 0)
                {
                    _total1 = Decimal.Round((((_per3 * 0.25m) + (_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m)) * 100), 2);
                    _overall = Decimal.Round(((_total / _count) * 0.8m) + (_total1 / _qty * 0.2m));
                    return (_overall);
                }
                else return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary7_1()
        {
            decimal _overall = 0;
            decimal _total = 0;
            decimal _total1 = 0;

            decimal _per4 = 0;
            decimal _per5 = 0;
            decimal _per6 = 0;
            decimal _per3 = 0;
            int _count = 0;
            int _qty = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//pft
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pwron
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//fpt
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }

                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    _total += Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), 2);
                    if (_p3 != 0)
                        _per3 += Decimal.Round((_p3), 2);
                    //if (_p7 != 0)
                    //    _per7 += Decimal.Round((_p7), 2);
                    if (_p4 != 0)
                        _per4 += Decimal.Round((_p4), 2);
                    if (_p5 != 0)
                        _per5 += Decimal.Round((_p5), 2);
                    if (_p6 != 0)
                        _per6 += Decimal.Round((_p6), 2);

                    //decimal _overall1 = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)),2);
                    //_overall += _overall1;
                    _count += 1;
                    _qty += count;
                }
                if (_count != 0)
                {
                    _total1 = Decimal.Round((((_per3 * 0.25m) + (_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m)) * 100), 2);
                    _overall = Decimal.Round(((_total / _count) * 0.8m) + (_total1 / _qty * 0.2m));
                    return (_overall);
                }
                else return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary20_1()
        {
            decimal _overall = 0;
            decimal _total = 0;
            decimal _total1 = 0;

            decimal _per4 = 0;
            decimal _per5 = 0;
            decimal _per6 = 0;
            decimal _per3 = 0;
            decimal _per7 = 0;
            int _count = 0;
            int _qty = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//inst
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pft
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//pwron
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//fpt
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }

                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    _total += Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)), 2);
                    if (_p3 != 0)
                        _per3 += Decimal.Round((_p3), 2);
                    if (_p7 != 0)
                        _per7 += Decimal.Round((_p7), 2);
                    if (_p4 != 0)
                        _per4 += Decimal.Round((_p4), 2);
                    if (_p5 != 0)
                        _per5 += Decimal.Round((_p5), 2);
                    if (_p6 != 0)
                        _per6 += Decimal.Round((_p6), 2);

                    //decimal _overall1 = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)),2);
                    //_overall += _overall1;
                    _count += 1;
                    _qty += count;
                }
                if (_count != 0)
                {
                    _total1 = Decimal.Round((((_per3 * 0.2m) + (_per4 * 0.2m) + (_per5 * 0.2m) + (_per6 * 0.2m) + (_per7 * 0.2m)) * 100), 2);
                    _overall = Decimal.Round(((_total / _count) * 0.8m) + (_total1 / _qty * 0.2m));
                    return (_overall);
                }
                else return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary12_1()
        {
            decimal _overall = 0;
            decimal _total = 0;
            decimal _total1 = 0;
            decimal _per2 = 0;
            decimal _per4 = 0;
            decimal _per5 = 0;
            decimal _per6 = 0;
            decimal _per3 = 0;
            int _count = 0;
            int _qty = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _per1 = 0;

                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());//inst
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//pft
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pwron
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//fpt
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }

                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    _total += Decimal.Round((_per1), 2);
                    if (_p2 != 0)
                        _per2 += Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    if (_p3 != 0)
                        _per3 += Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    if (_p4 != 0)
                        _per4 += Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 += Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 += Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);

                    //decimal _overall1 = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)),2);
                    //_overall += _overall1;
                    _count += 1;
                    _qty += count;
                }
                if (_count != 0)
                {
                    _total1 = Decimal.Round((((_per3 * 0.2m) + (_per4 * 0.2m) + (_per5 * 0.2m) + (_per6 * 0.2m) + (_per2 * 0.2m)) * 100), 2);
                    _overall = Decimal.Round(((_total) * 0.8m) + (_total1 * 0.2m));
                    return (_overall);
                }
                else return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary10_1_1()
        {
            decimal _overall = 0;
            int _count = 0;
            decimal _total_qty = 0;
            decimal _total_tested = 0;
            try
            {
                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 10;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                decimal _test = 0;
                decimal _device = 0;

                foreach (var row in TestNames)
                {
                    _total = 0;
                    _devices = 0;
                    _p1 = 0;

                    if (row[0].ToString() == "Circuit IR / Continuity Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _device = Decimal.Round(_devices);
                        _test = Decimal.Round(_p1);
                    }
                    else if (row[0].ToString() == "FA Device Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _device = Decimal.Round(_devices);
                        _test = Decimal.Round(_p1);
                    }
                    else if (row[0].ToString() == "FA Interface Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAL"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                            if (IsNumeric(_row["devices1"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices1"].ToString());
                            else
                                _devices += 0;
                        }
                        _device = Decimal.Round(_devices);
                        _test = Decimal.Round(_p1);
                    }
                    else if (row[0].ToString() == "Voice Evac Speaker Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "ANN"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _device = Decimal.Round(_devices);
                        _test = Decimal.Round(_p1);

                    }
                    else if (row[0].ToString() == "Fire Telephone Device Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FTL"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _device = Decimal.Round(_devices);
                        _test = Decimal.Round(_p1);

                    }
                    else if (row[0].ToString() == "Battery Autonomy Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                            //_count += 1;
                        }
                        _device = Decimal.Round(_devices);
                        _test = Decimal.Round(_p1);

                    }
                    else if (row[0].ToString() == "Graphic/ Head End Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _device = Decimal.Round(_devices);
                        _test = Decimal.Round(_p1);

                    }

                    //if (_test != 0)
                    //    _total = decimal.Round((_test / _device) * 100);

                    //_overall += _total;
                    //_count += 1;
                    _total_qty += _device;
                    _total_tested += _test;
                    //return _device;
                }
                if (_total_qty != 0)
                {
                    _overall = decimal.Round((_total_tested / _total_qty) * 100);
                    return _overall;
                    // return _count;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary17_1()
        {
            decimal _overall = 0;
            decimal _total = 0;
            decimal _total1 = 0;

            decimal _per4 = 0;
            decimal _per5 = 0;
            decimal _per6 = 0;

            decimal _per7 = 0;
            decimal _per8 = 0;
            int _count = 0;
            int _qty = 0;
            decimal _per1 = 0;
            decimal _per2 = 0;
            decimal _per3 = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _p8 = 0;

                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//inst
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//pft
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//pwron
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());//fpt
                        _p8 += Convert.ToDecimal(_row["per_com8"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }

                    if (_p1 != 0)
                    {
                        _per1 += Decimal.Round((_p1), 2);
                        //_per1 += Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    }
                    if (_p2 != 0)
                    {
                        _per2 += Decimal.Round((_p2), 2);
                        //_per2 += Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    }
                    if (_p3 != 0)
                        _per3 += Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    //_total += Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100, 2);
                    if (_p8 != 0)
                        _per8 += Decimal.Round((_p8), 2);
                    if (_p7 != 0)
                        _per7 += Decimal.Round((_p7), 2);
                    if (_p4 != 0)
                        _per4 += Decimal.Round((_p4), 2);
                    if (_p5 != 0)
                        _per5 += Decimal.Round((_p5), 2);
                    if (_p6 != 0)
                        _per6 += Decimal.Round((_p6), 2);

                    //decimal _overall1 = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)),2);
                    //_overall += _overall1;
                    _count += 1;
                    _qty += count;
                }
                if (_count != 0)
                {
                    _total1 = Decimal.Round((((_per8 * 0.2m) + (_per4 * 0.2m) + (_per5 * 0.2m) + (_per6 * 0.2m) + (_per7 * 0.2m)) * 100), 2);
                    _total = Decimal.Round((((_per1 * 0.2m) + (_per2 * 0.8m)) / _qty) * 100, 2);
                    _overall = Decimal.Round((_total * 0.8m) + ((_total1 / _qty) * 0.2m));
                    //_overall = Decimal.Round(_total);
                    return (_overall);
                }
                else return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary19_1()
        {
            decimal _overall = 0;
            decimal _total = 0;
            decimal _total1 = 0;

            decimal _per4 = 0;
            decimal _per5 = 0;
            decimal _per6 = 0;

            decimal _per7 = 0;
            decimal _per8 = 0;
            int _count = 0;
            int _qty = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _p8 = 0;
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }

                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);

                    _total += _per1;
                    _total1 += _per2;
                    //decimal _overall1 = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)),2);
                    //_overall += _overall1;
                    _count += 1;
                    _qty += count;
                }
                if (_count != 0)
                {
                    _overall = Decimal.Round(((_total / _count) * 0.8m) + (_total1 / _count * 0.2m));
                    return (_overall);
                }
                else return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary37()
        {
            decimal _overall = 0;
            int _count = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    if (count != 0)
                    {
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)) * 100);
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)) * 100);
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)) * 100);
                    }
                    _total = Decimal.Round((_per1 + _per2 + _per3 + _per4) / 4);
                    _overall += _total;
                    _count += 1;
                }
                if (_count != 0)
                    return (_overall / _count);
                else
                    return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary10_1()
        {
            try
            {
                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _p2 = 0;
                decimal _devices1 = 0;
                decimal _p3 = 0;
                decimal _devices2 = 0;
                decimal _p4 = 0;
                decimal _devices3 = 0;
                decimal _qty = 0;
                decimal _tested = 0;
                decimal _total = 0;
                decimal _count = 0;
                decimal _total1 = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 10;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    _devices = 0;
                    _p1 = 0;
                    _devices1 = 0;
                    _p2 = 0;
                    _devices2 = 0;
                    _p3 = 0;
                    _devices3 = 0;
                    _p4 = 0;
                    _qty = 0;
                    _tested = 0;
                    int idx = 0;

                    if (row[0].ToString() == "Circuit IR / Continuity Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAD" || _data.Field<string>("Cat") == "FAM" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;
                    }
                    else if (row[0].ToString() == "FA Device Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAD"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;
                    }
                    else if (row[0].ToString() == "FA Interface Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAM"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices1"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices1"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices1"].ToString());
                            }
                        }
                        _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;
                    }
                    else if (row[0].ToString() == "Voice Evac Speaker Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "ANN" || _data.Field<string>("Cat") == "FSC"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }

                        _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;
                    }
                    else if (row[0].ToString() == "Fire Telephone Device Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FTL"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;

                    }
                    else if (row[0].ToString() == "Battery Autonomy Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAD" || _data.Field<string>("Cat") == "FAM" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;

                    }
                    else if (row[0].ToString() == "Graphic/ Head End Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAD"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com5"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com5"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com5"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;
                    }
                    _count += _qty;
                    _total1 += _tested;
                }
                decimal _overall = 0;
                _overall = (_total1 / _count) * 100;
                return _overall;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary10_HMIM()
        {
            decimal _total = 0;
            decimal _overall = 0;
            int _count = 0;
            try
            {

                decimal _p1 = 0;
                decimal _devices = 0;

                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 10;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);

                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    //DataRow _drow = _dtsummary.NewRow();
                    //_drow[0] = row[0].ToString();
                    _devices = 0;
                    _p1 = 0;
                    int idx = 0;
                    //decimal _qty = 0;

                    if (row[0].ToString() == "Circuit IR Test")
                    {


                        _result = from _data in _dtresult.AsEnumerable()
                                  //where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "FIM" || _data.Field<string>("Cat") == "SOUNDER/STROBE"
                                  where _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FIM" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "SOUNDER/STROBE"
                                  select _data;
                        foreach (var _row in _result)
                        {

                            if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }



                    }
                    else if (row[0].ToString() == "Device/Address Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  //where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "FIM" || _data.Field<string>("Cat") == "SOUNDER/STROBE"
                                  where _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FIM" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "SOUNDER/STROBE"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }

                    }
                    else if (row[0].ToString() == "Sound Level Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  //where _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "CKT" || _data.Field<string>("Cat") == "SOUNDER/STROBE"
                                  where _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "CKT" || _data.Field<string>("Cat") == "SOUNDER/STROBE"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com4"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }

                    }
                    else if (row[0].ToString() == "Interface Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  //where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "FIM" || _data.Field<string>("Cat") == "SOUNDER/STROBE"
                                  where _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FIM" || _data.Field<string>("Cat") == "SOUNDER/STROBE"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                            }
                        }


                    }
                    else if (row[0].ToString() == "Fire Telephone Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FTU"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }


                    }
                    else if (row[0].ToString() == "Battery Autonomy Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()

                                  where _data.Field<string>("Cat") == "SFACP" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "FTP"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com5"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                _devices += 1;
                                //_qty += 1;
                            }
                        }


                    }
                    else if (row[0].ToString() == "Graphic Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "FTP"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com6"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                                _devices += 1;
                                //_qty += 1;
                            }
                        }


                    }
                    else if (row[0].ToString() == "Cause Effect Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "PAVA"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com7"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                                _devices += 1;
                                // _qty += 1;
                            }

                        }

                    }

                    if (_devices != 0)
                    {
                        _total = Decimal.Round((_p1 / Convert.ToDecimal(_devices)) * 100);
                        _count += 1;
                    }
                    _overall += _total;


                }
                if (_count != 0)
                {
                    _overall = Decimal.Round((_overall / Convert.ToDecimal(_count)));
                }
                else
                    _overall = 0;
                return _overall;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
                return 0;
            }
        }
        private decimal Summary10_14211()
        {
            decimal _total = 0;
            decimal _overall = 0;
            int _count = 0;
            try
            {

                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _devices1 = 0;

                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 10;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);

                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    //DataRow _drow = _dtsummary.NewRow();
                    //_drow[0] = row[0].ToString();
                    _devices = 0;
                    _p1 = 0;
                    int idx = 0;
                    //decimal _qty = 0;

                    if (row[0].ToString() == "Circuit IR Test")
                    {


                        _result = from _data in _dtresult.AsEnumerable()

                                  where _data.Field<string>("Cat") == "SLC" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "NAC" || _data.Field<string>("Cat") == "INT" || _data.Field<string>("Cat") == "J" || _data.Field<string>("Cat") == "FT" || _data.Field<string>("Cat") == "ANS"
                                  select _data;
                        foreach (var _row in _result)
                        {

                            if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                _devices += 1;
                            }



                        }

                    }
                    else if (row[0].ToString() == "Device / Address Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()

                                  where _data.Field<string>("Cat") == "SLC" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "NAC" || _data.Field<string>("Cat") == "INT" || _data.Field<string>("Cat") == "J" || _data.Field<string>("Cat") == "FT" || _data.Field<string>("Cat") == "ANS"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }

                            if (_row["Cat"].ToString() == "SLC")
                            {
                                if (IsNumeric(_row["devices1"].ToString()) == true) _devices1 += Convert.ToInt32(_row["devices1"].ToString());

                            }
                        }
                        _p1 += _devices1;
                        _devices += _devices1;


                    }
                    else if (row[0].ToString() == "Sound Level Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()

                                  where _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "NAC"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com4"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }

                    }
                    else if (row[0].ToString() == "Interface Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()

                                  where _data.Field<string>("Cat") == "SLC"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                            }
                        }


                    }
                    else if (row[0].ToString() == "Fire Telephone Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FT"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }


                    }
                    else if (row[0].ToString() == "Battery Autonomy Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()

                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "PAS" || _data.Field<string>("Cat") == "ACPS" || _data.Field<string>("Cat") == "FTP"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com5"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                _devices += 1;
                                //_qty += 1;
                            }
                        }


                    }
                    else if (row[0].ToString() == "Graphic Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "PAS" || _data.Field<string>("Cat") == "ACPS" || _data.Field<string>("Cat") == "FTP"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com6"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                                _devices += 1;
                                //_qty += 1;
                            }
                        }


                    }
                    else if (row[0].ToString() == "Cause Effect Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "PAS"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com7"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                                _devices += 1;
                                // _qty += 1;
                            }

                        }

                    }

                    if (_devices != 0)
                    {
                        _total = Decimal.Round((_p1 / Convert.ToDecimal(_devices)) * 100);
                        _count += 1;
                    }
                    _overall += _total;

                }
                if (_count != 0)
                {
                    _overall = Decimal.Round((_overall / Convert.ToDecimal(_count)));
                }
                else
                    _overall = 0;
                return _overall;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
                return 0;
            }
        }
        private decimal Summary28_HMIM()
        {
            decimal _total = 0;
            decimal _overall = 0;
            int _count = 0;
            try
            {

                decimal _p1 = 0;
                decimal _devices = 0;

                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                //var _result = "";
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 28;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _devices = 0;
                    _p1 = 0;
                    decimal _weighting = 0;
                    if (row[0].ToString() == "Circuit IR Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "CSC" || _data.Field<string>("Cat") == "LASC" || _data.Field<string>("Cat") == "LSC" || _data.Field<string>("Cat") == "SM" || _data.Field<string>("Cat") == "MM" || _data.Field<string>("Cat") == "SC"
                                  select _data;

                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }

                    }
                    else if (row[0].ToString() == "Device / Address Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "CSC" || _data.Field<string>("Cat") == "LASC" || _data.Field<string>("Cat") == "LSC" || _data.Field<string>("Cat") == "SM" || _data.Field<string>("Cat") == "MM" || _data.Field<string>("Cat") == "SC"
                                  select _data;

                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                            {

                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());

                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                    }
                    else if (row[0].ToString() == "Sound Level Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "CSC" || _data.Field<string>("Cat") == "LASC" || _data.Field<string>("Cat") == "LSC" || _data.Field<string>("Cat") == "SC"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com4"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                    }
                    else if (row[0].ToString() == "Interface Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FIM" || _data.Field<string>("Cat") == "SOUNDER/STROBE"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                            }
                        }
                    }
                    else if (row[0].ToString() == "Fire Telephone Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FTU"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                    }

                    else if (row[0].ToString() == "Battery Autonomy Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "SSR" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "FTP"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com5"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                _devices += 1;
                            }
                        }

                    }
                    else if (row[0].ToString() == "Graphic Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "FTP"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com6"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                                _devices += 1;
                            }

                        }
                    }
                    else if (row[0].ToString() == "C&E Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "PAVA"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com7"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                                _devices += 1;
                            }
                        }


                    }

                    if (_devices != 0)
                    {
                        _total = Decimal.Round((_p1 / Convert.ToDecimal(_devices)) * 100);
                        _count += 1;
                    }
                    _overall += _total;

                }
                if (_count != 0)
                {
                    _overall = Decimal.Round((_overall / Convert.ToDecimal(_count)) * 100);
                }
                else
                    _overall = 0;

                return _overall;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
                return 0;
            }
        }
        private decimal Summary55()
        {
            decimal _result = 0;
            decimal _ahu = 0;
            decimal _vav = 0;
            decimal _ecv = 0;
            decimal _msfd = 0;
            Load_Master(55);
            _ahu = Summary8_1();
            for (int i = 63; i <= 73; i++)
            {
                Load_Master(i);
                _vav += Summary8_1();
            }
            for (int i = 74; i <= 84; i++)
            {
                Load_Master(i);
                _ecv += Summary8_1();
            }
            for (int i = 30; i <= 40; i++)
            {
                Load_Master(i);
                _ecv += Summary9_1();
            }
            _vav = _vav / 10;
            _ecv = _ecv / 10;
            _msfd = _msfd / 10;
            _result = (_ahu + _vav + _ecv + _msfd) / 4;
            return _result;
        }
        private decimal Summary27_1()
        {

            try
            {
                decimal _overall = 0;
                decimal _total = 0;
                decimal _total1 = 0;
                decimal _per1 = 0;
                decimal _per2 = 0;
                decimal _per3 = 0;
                decimal _per4 = 0;
                decimal _per5 = 0;
                decimal _per6 = 0;
                decimal _per7 = 0;
                decimal _per8 = 0;
                int _count = 0;
                int _qty = 0;
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _p8 = 0;
                    int count = 0;
                    int qty = 0;
                    int _cold = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//inst
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pft
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//pwron
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//fpt
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }

                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    _total += Decimal.Round(_per2, 2);
                    if (_p3 != 0)
                        _per3 += Decimal.Round((_p3), 2);
                    if (_p7 != 0)
                        _per7 += Decimal.Round((_p7), 2);
                    if (_p4 != 0)
                        _per4 += Decimal.Round((_p4), 2);
                    if (_p5 != 0)
                        _per5 += Decimal.Round((_p5), 2);
                    if (_p6 != 0)
                        _per6 += Decimal.Round((_p6), 2);

                    //decimal _overall1 = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)),2);
                    //_overall += _overall1;
                    _count += 1;
                    _qty += count;
                }
                if (_count != 0)
                {
                    _total1 = Decimal.Round((((_per3 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per7 * 0.25m)) * 100), 2);
                    _overall = Decimal.Round(((_total / _count) * 0.8m) + (_total1 / _qty * 0.2m));
                    return (_overall);
                }
                else return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        private decimal Summary28_1()
        {
            decimal _overall = 0;
            decimal _total = 0;
            decimal _total1 = 0;

            decimal _per4 = 0;
            decimal _per5 = 0;
            decimal _per6 = 0;

            decimal _per7 = 0;
            decimal _per8 = 0;
            int _count = 0;
            int _qty = 0;
            decimal _per1 = 0;
            decimal _per2 = 0;
            decimal _per3 = 0;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _p8 = 0;

                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//inst
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pft
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//pwron
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//fpt
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }

                    if (_p1 != 0)
                    {
                        _per1 += Decimal.Round((_p1), 2);
                        //_per1 += Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    }
                    if (_p2 != 0)
                    {
                        _per2 += Decimal.Round((_p2), 2);
                        //_per2 += Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    }
                    if (_p3 != 0)
                        _per3 += Decimal.Round((_p3), 2);
                    //_total += Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100, 2);
                    if (_p8 != 0)
                        _per8 += Decimal.Round((_p8), 2);
                    if (_p7 != 0)
                        _per7 += Decimal.Round((_p7), 2);
                    if (_p4 != 0)
                        _per4 += Decimal.Round((_p4), 2);
                    if (_p5 != 0)
                        _per5 += Decimal.Round((_p5), 2);
                    if (_p6 != 0)
                        _per6 += Decimal.Round((_p6), 2);

                    //decimal _overall1 = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)),2);
                    //_overall += _overall1;
                    _count += 1;
                    _qty += count;
                }
                if (_count != 0)
                {
                    _total1 = Decimal.Round((((_per3 * 0.2m) + (_per4 * 0.2m) + (_per5 * 0.2m) + (_per6 * 0.2m) + (_per7 * 0.2m)) * 100), 2);
                    _total = Decimal.Round((((_per1 * 0.2m) + (_per2 * 0.8m)) / _qty) * 100, 2);
                    _overall = Decimal.Round((_total * 0.8m) + ((_total1 / _qty) * 0.2m));
                    //_overall = Decimal.Round(_total);
                    return (_overall);
                }
                else return 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }
        //private void Generate()
        //{
        //    Load_Cassheets();
        //    Load_Service();
        //    Load_FilteringElements();

        //}

        //protected void btngen_Click(object sender, EventArgs e)
        //{
        //    if (lblmode.Text == "0")
        //    {
        //        if (lblprj.Text == "CCAD")
        //            Generate_Project_Summary_ccad();
        //        else
        //            Generate_Project_Summary();
        //    }
        //    else
        //    {
        //        Generate_Service_Summary();
        //    }
        //    Generate_Reports((string)Session["bz"], (string)Session["fl"]);
        //}
        //protected void TimerTick(object sender, EventArgs e)
        //{
        //    Generate();
        //    Timer1.Enabled = false;
        //    imgLoader.Visible = false;
        //}
        private decimal Summary24_2()
        {
            try
            {
                decimal _total = 0;
                decimal _per1 = 0;
                decimal _per2 = 0;
                decimal _per3 = 0;
                decimal _per4 = 0;
                int _qty = 0;
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    int count1 = 0;
                    int _count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _s = _row[0].ToString();
                        _count += 1;

                    }

                    if (_count != 0)
                    {
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(_count), 2);
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(_count), 2);
                        _per3 = Decimal.Round(_p3 / Convert.ToDecimal(_count), 2);
                        _per4 = Decimal.Round(_p4 / Convert.ToDecimal(_count), 2);
                    }
                    _qty += _count;
                    _total = _total + Decimal.Round(((_per1 * 0.1m) + (_per2 * 0.2m) + (_per3 * 0.35m) + (_per4 * 0.35m)) * 100, 0, MidpointRounding.AwayFromZero);


                }
                if (_qty <= 0) return 0;
                _total = Decimal.Round(_total / _qty, MidpointRounding.AwayFromZero);
                return _total;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return 0;
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            string _url = "cmsreports.aspx?idx=1&prj=" + lblprj.Text;
            Response.Redirect(_url);
        }
        protected void btngenerate_Click(object sender, EventArgs e)
        {

            //Filtering(drbzone.SelectedItem.Text, drflevel.SelectedItem.Text);
            Session["bz"] = drbzone.SelectedItem.Text;
            Session["fl"] = drflevel.SelectedItem.Text;
            if (lblmode.Text == "0")
            {
                if (lblprj.Text == "MOE" || lblprj.Text == "PCD" || lblprj.Text == "11784" || lblprj.Text == "ARSD") Generate_Project_Summary_New();
                else
                    Generate_Project_Summary();
            }
            else if (lblmode.Text == "9")
            {
                if (lblprj.Text == "PCD" || lblprj.Text == "ARSD") Generate_Project_Summary_Overall_Pcd();
            }
            else
                Generate_Service_Summary();

            Generate_Reports((string)Session["bz"], (string)Session["fl"], lblmode.Text);

        }
    }
}
