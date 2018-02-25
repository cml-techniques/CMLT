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
using System.Collections.Generic;

namespace CmlTechniques.CMS
{
    public partial class Cas_SummaryAll : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtfilter;
        public static DataTable _dtresult;
        public static DataTable _dtsummary;
        protected void Page_Load(object sender, EventArgs e)
        {
            //_ReadCookies();
            //if (!IsPostBack)
            //{
            //    string _prm = Request.QueryString[0].ToString();
            //    lblsrv.Text = _prm.Substring(0, _prm.IndexOf("_P"));
            //    lblprj.Text = _prm.Substring(_prm.IndexOf("_P") + 2);
            //    Generate_Summary();
            //    //Generate_Summary();
            //    //Generate_Summary_Graph();
            //}
            //if (!IsPostBack)
            //{
            //   // string _prm = Request.QueryString[0].ToString();
                
            //}
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
        private void Load_Master(int _sch)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = _sch;
            _objcas.prj_code = lblprj.Text;
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
            _dtresult = _dtMaster;

            //var _dv = (DataView)ObjectDataSource1.Select();
            //DataTable _dtemp = _dv.ToTable();
            //IEnumerable<DataRow> _result = from _data in _dtemp.AsEnumerable()
            //                               where _data.Field<int>("Cas_Schedule") == _sch
            //                               select _data;
            //if (_result.Any())
            //{
            //    _dtMaster = _result.CopyToDataTable<DataRow>();
            //    _dtresult = _dtMaster;
            //}
            //else
            //{
            //    _dtMaster = null;
            //    _dtresult = null;
            //}
        }
        
        private void Generate_Summary()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _objbll.Clear_Srv_Sum(_objdb);
            if (lblsrv.Text == "2")
            {
                Load_Master(30);
                Summary30(30);
                Generate_Summary_Graph(30, 1);
                Load_Master(25);
                Summary25(25);
                Generate_Summary_Graph(25, 2);
                Load_Master(9);
                Summary9(9);
                Generate_Summary_Graph(9, 3);
                Load_Master(26);
                Summary25(26);
                Generate_Summary_Graph(26, 4);
                Load_Master(27);
                Summary25(27);
                Generate_Summary_Graph(27, 5);
                Load_Master(28);
                Summary21();
                Generate_Summary_Graph(28, 6);
                Load_Master(29);
                Summary29(29);
                Generate_Summary_Graph(29, 7);
                Load_Master(8);
                Summary8(8);
                Generate_Summary_Graph(8, 8);
            }
            else if (lblsrv.Text == "1")
            {
                Load_Master(2);
                Summary3(2);
                Generate_Summary_Graph(2, 1);
                Load_Master(3);
                Summary3(3);
                Generate_Summary_Graph(3, 2);
                Load_Master(6);
                Summary6(6);
                Generate_Summary_Graph(6, 3);
                Load_Master(5);
                Summary5(5);
                Generate_Summary_Graph(5, 4);
                Load_Master(4);
                Summary4(4);
                Generate_Summary_Graph(4, 5);
                Load_Master(7);
                Summary7(7);
                Generate_Summary_Graph(7, 6);
                Load_Master(37);
                Summary37(37);
                Generate_Summary_Graph(37, 7);
            }
            else if (lblsrv.Text == "3")
            {
                Load_Master(10);
                Summary10(10);
                Generate_Summary_Graph(10,1);
                Load_Master(31);
                Summary10(31);
                Generate_Summary_Graph(31, 2);
                Load_Master(20);
                Summary20(20);
                Generate_Summary_Graph(20, 3);
                Load_Master(32);
                Summary20(32);
                Generate_Summary_Graph(32, 4);
                Load_Master(11);
                Summary11(11);
                Load_Master(12);
                Summary12(12);
            }
            else if (lblsrv.Text == "8")
            {
                Load_Master(23);
                Summary23(23);
                Generate_Summary_Graph(23, 1);
                Load_Master(36);
                Summary36(36);
                Generate_Summary_Graph(36, 2);
            }

        }
        private void Generate_Service_Summary_split(int srv)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsproject _objcls1 = new _clsproject();
            _objdb.DBName = "DBCML";
            _objbll.Clear_Srv_Sum(_objdb);
            _objcls1.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls1, _objdb);
            if (srv == 2)
            {
                Load_Master(30);
                Summary30(30);
                Load_Master(25);
                Summary25(25);
                Load_Master(9);
                Summary9(9);
                Load_Master(26);
                Summary25(26);
                Load_Master(27);
                Summary25(27);
                Load_Master(28);
                Summary28(28);
                Load_Master(29);
                Summary29(29);
                Load_Master(8);
                Summary30(8);
            }
            else if (srv == 1)
            {
                Load_Master(2);
                Summary3(2);
                Load_Master(3);
                Summary3(3);
                Load_Master(6);
                Summary6(6);
                Load_Master(5);
                Summary5(5);
                Load_Master(4);
                Summary4(4);
                Load_Master(7);
                Summary7(7);
                Load_Master(37);
                Summary37(37);
            }
            else if (srv == 3)
            {
                Load_Master(10);
                Summary10(10);
                Load_Master(31);
                Summary31(31);
                Load_Master(20);
                Summary20(20);
                Load_Master(32);
                Summary20(32);
                Load_Master(11);
                Summary11(11);
                Load_Master(12);
                Summary12(12);
            }
            else if (srv == 4)
            {
                Load_Master(17);
                Summary17(17);
            }
            else if (srv == 8)
            {
                Load_Master(23);
                Summary23(23);
                Load_Master(36);
                Summary36(36);
            }
            else if (srv == 9)
            {
                Load_Master(33);
                Summary34(33);
                Load_Master(34);
                Summary34(34);
                Load_Master(35);
                Summary34(35);
            }
        }
        private void Summary34(int sch)
        {
            try
            {
                int _count = 0;
                decimal _iface = 0;
                decimal _dcomp = 0;
                decimal _snoff = 0;
                decimal _total = 0;
                var _result = from _data in _dtMaster.AsEnumerable()
                              select _data;
                foreach (var row in _result)
                {
                    _count += 1;
                    if (IsNumeric(row["devices1"].ToString()) == true)
                        _iface += Convert.ToDecimal(row["devices1"].ToString());
                    if (DateValidation(row["test1"].ToString()) == true)
                    {
                        if (IsNumeric(row["devices1"].ToString()) == true)
                            _dcomp += Convert.ToDecimal(row["devices1"].ToString());
                    }
                    if (DateValidation(row["test2"].ToString()) == true)
                    {
                        _snoff += Convert.ToDecimal(row["devices1"].ToString());
                    }

                }
                if (_iface != 0)
                    _total = (_dcomp / _iface) * 100;
                Generate_Service_Summary1(sch, 6, _count, _total, Convert.ToInt32(_iface), Convert.ToInt32(_dcomp), Convert.ToInt32(_snoff), 0,0,9);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
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
        private void Generate_Service_Summary()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsproject _objcls1 = new _clsproject();
            _objdb.DBName = "DBCML";
            _objbll.Clear_Srv_Sum(_objdb);
            _objcls1.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls1, _objdb);
            Load_Master(30);
            Summary30(30);
            Load_Master(25);
            Summary25(25);
            Load_Master(9);
            Summary9(9);
            Load_Master(26);
            Summary25(26);
            Load_Master(27);
            Summary25(27);
            Load_Master(28);
            Summary28(28);
            Load_Master(29);
            Summary29(29);
            Load_Master(8);
            Summary30(8);

            Load_Master(2);
            Summary3(2);
            Load_Master(3);
            Summary3(3);
            Load_Master(6);
            Summary6(6);
            Load_Master(5);
            Summary5(5);
            Load_Master(4);
            Summary4(4);
            Load_Master(7);
            Summary7(7);
            Load_Master(37);
            Summary37(37);

            Load_Master(10);
            Summary10(10);
            Load_Master(31);
            Summary31(31);
            Load_Master(20);
            Summary20(20);
            Load_Master(32);
            Summary20(32);
            Load_Master(11);
            Summary11(11);
            Load_Master(12);
            Summary12(12);
            Load_Master(17);
            Summary17(17);

            Load_Master(23);
            Summary23(23);
            Load_Master(36);
            Summary36(36);
        }
        private void Insert_Summary()
        {

        }
       /* private void Summary1_5()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
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
                    decimal _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count));
                    decimal _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count));
                    decimal _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count));
                    if ((string)Session["sch"] == "5")
                    {
                        _total = 0;
                        if (row.col3.ToString() == "MDB") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                        else if (row.col3.ToString() == "PFC") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                        else if (row.col3.ToString() == "HCP") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                        else if (row.col3.ToString() == "DB")
                        {
                            if (lblprj.Text == "12710")
                                _total = Decimal.Round((_per2 * 0.5m) + (_per3 * 0.5m));
                            else
                                _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m));
                        }
                        else if (row.col3.ToString() == "LCP")
                        {
                            if (lblprj.Text == "12710")
                                _total = Decimal.Round((_per2 * 0.5m) + (_per3 * 0.5m));
                            else
                                _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m));
                        }
                        else if (row.col3.ToString() == "UPS")
                        {
                            if (lblprj.Text == "12710")
                                _total = Decimal.Round((_per2 * 0.5m) + (_per3 * 0.5m));
                            else
                                _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m));
                        }
                        else if (row.col3.ToString() == "EFP")
                        {
                            if (lblprj.Text == "12710")
                                _total = Decimal.Round((_per2 * 0.5m) + (_per3 * 0.5m));
                            else
                                _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m));
                        }
                        else if (row.col3.ToString() == "SMDB") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                        else if (row.col3.ToString() == "MCC") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                        else if (row.col3.ToString() == "ATS") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                        else if (row.col3.ToString() == "BDT") _total = Decimal.Round((_per1 * 0.6m) + (_per2 * 0.4m));
                        else _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                    }
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = _per1.ToString();
                    _drow[3] = _per2.ToString();
                    _drow[4] = _per3.ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary2()
        {

            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
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
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count));
                    decimal _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count));
                    _total = Decimal.Round((_per1 * 0.9m) + (_per2 * 0.1m));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = _per1.ToString();
                    _drow[3] = _per2.ToString();
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary8()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                _dtsummary.Columns.Add("IDC", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
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
                    decimal _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
                    decimal _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
                    decimal _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count), 2);
                    _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)), 2) * 100;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = Decimal.Round(_p2).ToString();
                    _drow[4] = Decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _drow[7] = "0";
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary3()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
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
                        count += 1;
                    }
                    decimal _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count));
                    decimal _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count));
                    _total = Decimal.Round((_per1 * 0.9m) + (_per2 * 0.1m));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = _per1.ToString();
                    _drow[3] = _per2.ToString();
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary6()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
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
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count));
                    decimal _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count));
                    decimal _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count));
                    decimal _per4 = Decimal.Round(_p4 / Convert.ToDecimal(count));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    if (row.col3.ToString() == "LP")
                    {
                        _drow[2] = _per3.ToString();
                        _drow[3] = _per4.ToString();
                        _total = Decimal.Round((_per3 * 0.9m) + (_per4 * 0.1m));
                    }
                    else
                    {
                        _drow[2] = _per1.ToString();
                        _drow[3] = _per2.ToString();
                        _total = Decimal.Round((_per1 * 0.9m) + (_per2 * 0.1m));
                    }
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary4()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
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
                    decimal _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count));
                    decimal _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count));
                    decimal _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count));
                    _total = Decimal.Round((_per1 * 0.6m) + (_per2 * 0.1m) + (_per3 * 0.3m));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = _per1.ToString();
                    _drow[3] = _per2.ToString();
                    _drow[4] = _per3.ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary7()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
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
                _objdb.DBName = "DB_" + (string)Session["project"];
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32((string)Session["sch"]);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);

                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _drow[1] = count.ToString();
                    if (row[0].ToString() == "Continuity/IR Test Complete") _drow[2] = decimal.Round(_p1).ToString();
                    else if (row[0].ToString() == "Addressing") _drow[2] = decimal.Round(_p2).ToString();
                    else if (row[0].ToString() == "Fault Testing") _drow[2] = decimal.Round(_p3).ToString();
                    else if (row[0].ToString() == "Change Over Test") _drow[2] = decimal.Round(_p4).ToString();
                    else if (row[0].ToString() == "Lux Level Test") _drow[2] = decimal.Round(_p5).ToString();
                    else if (row[0].ToString() == "Duration Test") _drow[2] = decimal.Round(_p6).ToString();
                    else if (row[0].ToString() == "Pc Head End Test") _drow[2] = decimal.Round(_p7).ToString();
                    if (_drow[2].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary20()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
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
                    _points += Convert.ToInt32(_row["devices3"].ToString());
                    _devices += Convert.ToInt32(_row["devices2"].ToString());
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
                _objdb.DBName = "DB_" + (string)Session["project"];
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 20;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    if (row[0].ToString() == "Cable Continuity/IR Test") { _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = Decimal.Round(_points); }
                    else if (row[0].ToString() == "Points to Points Test") { _drow[2] = Decimal.Round(_p2).ToString(); _drow[1] = Decimal.Round(_points); }
                    else if (row[0].ToString() == "Calibration/Functional Test") { _drow[2] = Decimal.Round(_p3).ToString(); _drow[1] = Decimal.Round(_devices); }
                    else if (row[0].ToString() == "Sequence of Operation") { _drow[2] = Decimal.Round(_p4).ToString(); _drow[1] = Decimal.Round(_systems); }
                    else if (row[0].ToString() == "Graphic/Head End Test") { _drow[2] = Decimal.Round(_p5).ToString(); _drow[1] = Decimal.Round(_systems); }
                    else if (row[0].ToString() == "Loop Tuning") { _drow[2] = Decimal.Round(_p6).ToString(); _drow[1] = Decimal.Round(_systems); }
                    //else if (row[0].ToString() == "Pc Head End Test") _drow[2] = decimal.Round(_p7).ToString();
                    if (_drow[2].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary13()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
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
                _objdb.DBName = "DB_" + (string)Session["project"];
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32((string)Session["sch"]);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _drow[1] = _devices.ToString();
                    if (row[0].ToString() == "Continuity/IR Test") { _drow[2] = Decimal.Round(_p1).ToString(); }
                    else if (row[0].ToString() == "CCTV View Locally") { _drow[2] = Decimal.Round(_p2).ToString(); }
                    else if (row[0].ToString() == "CCTV View From Head End") { _drow[2] = Decimal.Round(_p3).ToString(); }
                    else if (row[0].ToString() == "CCTV Addressing/Software Test") { _drow[2] = Decimal.Round(_p4).ToString(); }
                    else if (row[0].ToString() == "CCTV Recording/Back-up Restore Test") { _drow[2] = Decimal.Round(_p5).ToString(); }
                    //else if (row[0].ToString() == "Pc Head End Test") _drow[2] = decimal.Round(_p7).ToString();
                    if (_drow[2].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary22()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;
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
                    _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + (string)Session["project"];
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32((string)Session["sch"]);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _drow[1] = _devices.ToString();
                    if (row[0].ToString() == "Continuity/IR Test") { _drow[2] = Decimal.Round(_p1).ToString(); }
                    else if (row[0].ToString() == "Addressing/Programming Test") { _drow[2] = Decimal.Round(_p2).ToString(); }
                    else if (row[0].ToString() == "Fault & Alarm Test") { _drow[2] = Decimal.Round(_p3).ToString(); }
                    else if (row[0].ToString() == "Access Card Swipe") { _drow[2] = Decimal.Round(_p4).ToString(); }
                    else if (row[0].ToString() == "Power Failure Test") { _drow[2] = Decimal.Round(_p5).ToString(); }
                    else if (row[0].ToString() == "Interface Test") _drow[2] = decimal.Round(_p6).ToString();
                    else if (row[0].ToString() == "PC Headend/Graphics Test") _drow[2] = decimal.Round(_p7).ToString();
                    if (_drow[2].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary11()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
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
                    _scenes += Convert.ToInt32(_row["devices1"].ToString());
                    _circuits += Convert.ToInt32(_row["devices2"].ToString());
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + (string)Session["project"];
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32((string)Session["sch"]);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();

                    if (row[0].ToString() == "Continuity/IR Test") { _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = _circuits.ToString(); }
                    else if (row[0].ToString() == "No.Of Lighting Circuits Tested") { _drow[2] = Decimal.Round(_p2).ToString(); _drow[1] = _circuits.ToString(); }
                    else if (row[0].ToString() == "Addressing/Programming Test") { _drow[2] = Decimal.Round(_p3).ToString(); _drow[1] = _scenes.ToString(); }
                    else if (row[0].ToString() == "PC Headend/Interface Test") { _drow[2] = Decimal.Round(_p4).ToString(); _drow[1] = _circuits.ToString(); }
                    if (_drow[2].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary12()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    if (row.col3.ToString() == "CU" || row.col3.ToString() == "FO")
                    {
                        decimal _p1 = 0;
                        decimal _total = 0;
                        decimal _points = 0;
                        string _test = "";
                        var _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                      select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            _points += Convert.ToDecimal(_row["devices1"].ToString());
                        }

                        if (row.col3.ToString() == "CU") _test = "CAT 6 Cable Tests";
                        else if (row.col3.ToString() == "FO") _test = "Fibre Optic Cable Tests";
                        if (_p1 != 0)
                            _total = Decimal.Round((_p1 / _points) * 100);
                        DataRow _drow = _dtsummary.NewRow();
                        _drow[0] = _test;
                        _drow[1] = _points.ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        _drow[3] = "0";
                        _drow[4] = "0";
                        _drow[5] = _total.ToString();
                        _drow[6] = _test;
                        _dtsummary.Rows.Add(_drow);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary15()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
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
                    _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                    _p8 += Convert.ToDecimal(_row["per_com8"].ToString());
                    _p9 += Convert.ToDecimal(_row["per_com9"].ToString());
                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + (string)Session["project"];
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32((string)Session["sch"]);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _drow[1] = _devices.ToString();
                    if (row[0].ToString() == "Continuity/IR Test") { _drow[2] = Decimal.Round(_p1).ToString(); }
                    else if (row[0].ToString() == "Key Card Activated") { _drow[2] = Decimal.Round(_p2).ToString(); }
                    else if (row[0].ToString() == "Do Not Disturb(DND)/Doorbell") { _drow[2] = Decimal.Round(_p3).ToString(); }
                    else if (row[0].ToString() == "Make Up Room(MUR)") { _drow[2] = Decimal.Round(_p4).ToString(); }
                    else if (row[0].ToString() == "FCU/Temp Control") { _drow[2] = Decimal.Round(_p5).ToString(); }
                    else if (row[0].ToString() == "Energy Management System") _drow[2] = decimal.Round(_p6).ToString();
                    else if (row[0].ToString() == "Lighting Scene Control") { _drow[2] = Decimal.Round(_p7).ToString(); }
                    else if (row[0].ToString() == "Blinds Control Interface") { _drow[2] = Decimal.Round(_p8).ToString(); }
                    else if (row[0].ToString() == "Monitoring Interface(Future)") _drow[2] = decimal.Round(_p9).ToString();
                    if (_drow[2].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary14()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
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
                _objdb.DBName = "DB_" + (string)Session["project"];
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32((string)Session["sch"]);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _drow[1] = _devices.ToString();
                    if (row[0].ToString() == "Continuity/IR Test") { _drow[2] = Decimal.Round(_p1).ToString(); }
                    else if (row[0].ToString() == "Door Intercom Alert/Bell") { _drow[2] = Decimal.Round(_p2).ToString(); }
                    else if (row[0].ToString() == "Audio/Visual Test") { _drow[2] = Decimal.Round(_p3).ToString(); }
                    else if (row[0].ToString() == "Door Release Test") { _drow[2] = Decimal.Round(_p4).ToString(); }
                    if (_drow[2].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary23()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;
                decimal _total = 0;
                decimal _count1 = 0;
                decimal _count2 = 0;
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
                    if (_row["Cat"].ToString() == "LIFT")
                        _count2 += 1;
                    _count1 += 1;
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + (string)Session["project"];
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32((string)Session["sch"]);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    if (row[0].ToString() == "Tested & Comm.") { _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = Decimal.Round(_count1); }
                    else if (row[0].ToString() == "3rd Party Inspected") { _drow[2] = Decimal.Round(_p2).ToString(); _drow[1] = Decimal.Round(_count1); }
                    else if (row[0].ToString() == "Emergency Lighting") { _drow[2] = Decimal.Round(_p3).ToString(); _drow[1] = Decimal.Round(_count2); }
                    else if (row[0].ToString() == "Power Failure Mode") { _drow[2] = Decimal.Round(_p4).ToString(); _drow[1] = Decimal.Round(_count1); }
                    else if (row[0].ToString() == "Lift Monitoring System") { _drow[2] = Decimal.Round(_p5).ToString(); _drow[1] = Decimal.Round(_count2); }
                    else if (row[0].ToString() == "Intercom") { _drow[2] = Decimal.Round(_p6).ToString(); _drow[1] = Decimal.Round(_count2); }
                    else if (row[0].ToString() == "BMS/ Fire Alarm Interface") { _drow[2] = Decimal.Round(_p7).ToString(); _drow[1] = Decimal.Round(_count1); }
                    if (_drow[1].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary21()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
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
                    if (_p1 != 0)
                        _total = Decimal.Round(_p1 / Convert.ToDecimal(count));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = Decimal.Round(_p2).ToString();
                    _drow[4] = Decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary9()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
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
                        count += 1;
                    }
                    //decimal _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count));
                    //decimal _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count));
                    if (_p1 != 0)
                        _total = Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = Decimal.Round(_p2).ToString();
                    _drow[4] = Decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary17()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
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
                    if (_p1 != 0)
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
                    if (_p3 != 0)
                        _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count), 2);
                    _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = Decimal.Round(_p2).ToString();
                    _drow[4] = Decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary18()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _total = 0;
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
                    if (_p1 != 0)
                        _total = Decimal.Round(_p1 / Convert.ToDecimal(count), 2) * 100;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary19()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    if (_p1 != 0)
                        _total = _p1 / Convert.ToDecimal(count);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary10()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                decimal _count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + (string)Session["project"];
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 10;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _devices = 0;
                    _p1 = 0;
                    if ((string)Session["project"] != "12710")
                    {
                        if (row[0].ToString() == "Circuit IR Test")
                        {
                            foreach (var _row in _result)
                            {
                                //if (_row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA")
                                if (_row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "PAVA")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                        }
                        else if (row[0].ToString() == "Device/Address Test")
                        {
                            foreach (var _row in _result)
                            {
                                //if (_row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA")
                                if (_row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "PAVA")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();


                        }
                        else if (row[0].ToString() == "Sound Level Test")
                        {
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "PAVA")
                                {

                                    _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                                //else if (_row["cat"].ToString() == "FTU")
                                //{
                                //    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                //    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                //}
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                        }
                        else if (row[0].ToString() == "Interface Test")
                        {
                            foreach (var _row in _result)
                            {
                                //if (_row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA")
                                if (_row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Fire Telephone Test")
                        {
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "FTP")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Battery Autonomy Test")
                        {
                            _count = 0;
                            foreach (var _row in _result)
                            {
                                //if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA")
                                if (_row["cat"].ToString() == "FACP")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                    //_count += 1;
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Graphic Test")
                        {
                            _count = 0;
                            foreach (var _row in _result)
                            {
                                //if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FSCP")
                                if (_row["cat"].ToString() == "FACP")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Cause Effect Test")
                        {
                            _count = 0;
                            foreach (var _row in _result)
                            {
                                //if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FSCP")
                                if (_row["cat"].ToString() == "FACP")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else
                        {
                            _drow[1] = "0";
                            _drow[2] = "0";
                        }
                    }
                    else
                    {
                        if (row[0].ToString() == "Circuit IR Test")
                        {
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "CAES" || _row["cat"].ToString() == "AS")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                        }
                        else if (row[0].ToString() == "Device/Address Test")
                        {
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA" || _row["cat"].ToString() == "CAES" || _row["cat"].ToString() == "AS")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();


                        }
                        else if (row[0].ToString() == "Sound Level Test")
                        {
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "CAES" || _row["cat"].ToString() == "AS")
                                {

                                    _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                                //else if (_row["cat"].ToString() == "FTU")
                                //{
                                //    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                //    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                //}
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                        }
                        else if (row[0].ToString() == "Interface Test")
                        {
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA" || _row["cat"].ToString() == "CAES" || _row["cat"].ToString() == "AS")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Fire Telephone Test")
                        {
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "FTP")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Battery Autonomy Test")
                        {
                            _count = 0;
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA" || _row["cat"].ToString() == "CAES" || _row["cat"].ToString() == "AS")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                    //_count += 1;
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Graphic Test")
                        {
                            _count = 0;
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA" || _row["cat"].ToString() == "CAES" || _row["cat"].ToString() == "AS")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Cause Effect Test")
                        {
                            _count = 0;
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA" || _row["cat"].ToString() == "CAES" || _row["cat"].ToString() == "AS")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else
                        {
                            _drow[1] = "0";
                            _drow[2] = "0";
                        }
                    }
                    if (_drow[2].ToString() != "0")
                    {
                        _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                    }
                    else
                        _total = 0;
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }*/
        //---------------- Mechanical------------------------
       private void Summary30(int sch)
        {
            try
            {
                decimal _total = 0;
                decimal _per1 = 0;
                decimal _per2 = 0;
                int _com = 0;
                int _pcom = 0;
                int _wit = 0;
                int _icom = 0;
                int _rows = 0;
                int qty = 0;
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
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
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _wit += Convert.ToInt32(_row["per_com3"].ToString());
                        _pcom += Convert.ToInt32(_row["per_com1"].ToString());
                        _com += Convert.ToInt32(_row["per_com2"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    if (_p1 != 0)
                        _per1 += Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
                    if (_p2 != 0)
                        _per2 += Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
                    qty += count;
                    _rows += 1;
                }
                _total = Decimal.Round((((_per1 * 0.2m) + (_per2 * 0.8m))/_rows) * 100);
                decimal _weighting = _total * 0.35m;
                Generate_Service_Summary1(sch, 1, qty, _total, _pcom, _com, _wit, _icom,_weighting,2);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary25(int sch)
        {
            try
            {
                decimal _total = 0;
                decimal _per1 = 0;
                decimal _per2 = 0;
                int _com = 0;
                int _pcom = 0;
                int _wit = 0;
                int _rows = 0;
                int qty = 0;
              var distinctRows = (from DataRow dRow in _dtMaster.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    int count = 0;
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _pcom += Convert.ToInt32(_row["per_com1"].ToString());
                        _com += Convert.ToInt32(_row["per_com2"].ToString());
                        _wit += Convert.ToInt32(_row["per_com3"].ToString());
                        count += 1;
                    }
                    if (_p1 != 0)
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
                    qty += count;
                    _rows += 1;
                   
                }
                _total = Decimal.Round((((_per1 * 0.2m) + (_per2 * 0.8m)) / _rows) * 100);
                decimal _weighting=0;
                if(sch==25)
                    _weighting = _total * 0.05m;
                else if(sch==26)
                    _weighting = _total * 0.2m;
                else if (sch == 27)
                    _weighting = _total * 0.1m;

                Generate_Service_Summary1(sch, 1, qty, _total, _pcom, _com, _wit, 0,_weighting,2);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary9(int sch)
        {
            try
            {
                decimal _total = 0;
                decimal _per1 = 0;
                decimal _per2 = 0;
                int _pcom=0;
                int _com = 0;
                int _icom = 0;
                int _rows = 0;
                int _wit = 0;
                int qty = 0;
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    int count = 0;
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        count += 1;
                        _com += Convert.ToInt32(_row["per_com1"].ToString());
                        _wit += Convert.ToInt32(_row["per_com2"].ToString());
                    }
                    if (_p1 != 0)
                        _per1+= Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                    qty += count;
                    _rows += 1;
                    
                }
                _total = _per1 / _rows;
                decimal _weighting = _total * 0.05m;
                Generate_Service_Summary1(sch, 1, qty, _total, -1, _com, _wit, _icom,_weighting,2);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary28(int sch)
        {
            try
            {
                decimal _total = 0;
                decimal _per1 = 0;
                decimal _per2 = 0;
                int _pcom = 0;
                int _com = 0;
                int _icom = 0;
                int _rows = 0;
                int _wit = 0;
                int qty = 0;
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    int count = 0;
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        count += 1;
                        _pcom += Convert.ToInt32(_row["per_com1"].ToString());
                        _com += Convert.ToInt32(_row["per_com2"].ToString());
                        _wit += Convert.ToInt32(_row["per_com3"].ToString());
                    }
                    if (_p1 != 0)
                        _per1 += Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                    if (_p2 != 0)
                        _per2 += Decimal.Round((_p2 / Convert.ToDecimal(count)) * 100);
                    qty += count;
                    _rows += 1;

                }
                _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100);
                decimal _weighting = _total * 0.1m;
                Generate_Service_Summary1(sch, 1, qty, _total, _pcom, _com, _wit, _icom,_weighting,2);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary21()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                _dtsummary.Columns.Add("IDC", typeof(string));
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _total = 0;
                    int count = 0;
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        count += 1;
                    }
                    if (_p1 != 0)
                        _total = Decimal.Round(_p1 / Convert.ToDecimal(count));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "-1";
                    _drow[3] = "-1";
                    _drow[4] = "-1";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _drow[7] = "-1";
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary29(int sch)
        {
            try
            {
                decimal _total = 0;
                decimal _per1 = 0;
                int qty = 0;
                int _rows = 0;
                int _pcom = 0;
                int _com = 0;
                int _icom = 0;
                int _wit = 0;
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    int count = 0;
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _com += Convert.ToInt32(_row["per_com1"].ToString());
                        _wit += Convert.ToInt32(_row["per_com2"].ToString());
                        count += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    
                    _per1 += Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                    qty += count;
                    _rows += 1;
                }
                    _total = Decimal.Round(_per1/_rows);
                    decimal _weighting = _total * 0.1m;
                    Generate_Service_Summary1(sch, 1, qty, _total,-1, _com, _wit, _icom,_weighting,2);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary8(int sch)
        {
            try
            {
                decimal _per1 = 0;
                decimal _per2 = 0;
                decimal _per3 = 0;
                decimal _total = 0;
                int _pcom = 0;
                int _com = 0;
                int _wit = 0;
                int qty = 0;
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    
                    int count = 0;
                    
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _pcom += Convert.ToInt32(_row["per_com1"].ToString());
                        _com += Convert.ToInt32(_row["per_com2"].ToString());
                        _wit += Convert.ToInt32(_row["per_com3"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }

                    if (_p1 != 0)
                        _per1 += _p1 / Convert.ToDecimal(count);
                    if (_p2 != 0)
                        _per2 += _p2 / Convert.ToDecimal(count);
                    qty += count;

                }
                _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100);
                decimal _weighting = _total * 0.05m;
                Generate_Service_Summary1(sch, 1, qty, _total, _pcom, _com, _wit, 0,_weighting,2);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        //------------------ Electrical --------------------------------------
        private void Summary2(int sch)
        {
            try
            {
                decimal _total = 0;
                decimal _per1 = 0;
                decimal _per2 = 0;
                int _rows = 0;
                int qty = 0;
                int _icom = 0;
                int _com = 0;
                int _pcom = 0;
                int _wit = 0;
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100)
                        {
                            _p1 += 1;
                            _pcom += 1;
                        }
                        _wit += Convert.ToInt32(_row["per_com3"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    if (count != 0)
                        _per1 += _p1 / Convert.ToDecimal(count);
                    qty += count;
                    _rows += 1;
                    //DataRow _drow = _dtsummary.NewRow();
                    //_drow[0] = row.col2.ToString();
                    //_drow[1] = count.ToString();
                    //_drow[2] = _per1.ToString();
                    //_drow[3] = _per2.ToString();
                    //_drow[4] = "-1";
                    //_drow[5] = _total.ToString();
                    //_drow[6] = row.col3.ToString();
                    //_drow[7] = "-1";
                    //_dtsummary.Rows.Add(_drow);
                }
               // _total = Decimal.Round((_per1 / _rows) * 100);

                //Generate_Service_Summary1(sch, 2, qty, _total,_pcom,-1, _wit,_icom);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary3(int sch)
        {
            try
            {
                decimal _total = 0;
                decimal _per1 = 0;
                decimal _per2 = 0;
                int _rows = 0;
                int qty = 0;
                int _icom = 0;
                int _com = 0;
                int _pcom = 0;
                int _wit = 0;
                decimal _cal = 0;
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100)
                        {
                            _p1 += 1;
                            _pcom += 1;
                        }
                        _wit += Convert.ToInt32(_row["per_com3"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    if (count != 0)
                        _per1 = _p3 / Convert.ToDecimal(count);
                    qty += count;
                    _rows += 1;
                    _cal += _per1 * count;
                    //DataRow _drow = _dtsummary.NewRow();
                    //_drow[0] = row.col2.ToString();
                    //_drow[1] = count.ToString();
                    //_drow[2] = _per1.ToString();
                    //_drow[3] = _per2.ToString();
                    //_drow[4] = "-1";
                    //_drow[5] = _total.ToString();
                    //_drow[6] = row.col3.ToString();
                    //_drow[7] = "-1";
                    //_dtsummary.Rows.Add(_drow);
                }
                _total = Decimal.Round(_cal / qty);
                decimal _weighting = 0;
                if (sch == 2)
                    _weighting = _total * 0.2m;
                else if (sch == 3)
                    _weighting = _total * 0.15m;
                Generate_Service_Summary1(sch, 2, qty, _total, _pcom, -1, _wit, _icom,_weighting,1);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary6(int sch)
        {
            try
            {
                decimal _total = 0;
                decimal _per1 = 0;
                decimal _per2 = 0;
                int _rows = 0;
                int qty = 0;
                int _pcom = 0;
                int _com = 0;
                int _icom = 0;
                int _wit = 0;
                decimal _calc = 0;
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100 && Convert.ToDecimal(_row["per_com2"].ToString()) == 100)
                        {
                            _p1 += 1;
                            _pcom += 1;
                        }
                        if (Convert.ToDecimal(_row["per_com3"].ToString()) == 100 && Convert.ToDecimal(_row["per_com4"].ToString()) == 100)
                        {
                            _p2 += 1;
                            _pcom += 1;
                        }
                        _wit += Convert.ToInt32(_row["per_com5"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    
                    
                    if (row.col3.ToString() == "LP")
                    {
                        if (count != 0)
                            _per1 = (_p2 / Convert.ToDecimal(count));
                    }
                    else
                    {
                        if (count != 0)
                            _per1 = (_p1 / Convert.ToDecimal(count));
                    }
                    qty += count;
                    _rows += 1;
                    _calc += _per1 * count;
                }
                _total = decimal.Round(_calc / qty);
                decimal _weighting = _total * 0.05m;
                Generate_Service_Summary1(sch, 2, qty, _total, _pcom, -1, _wit, _icom, _weighting,1);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary5(int sch)
        {
            try
            {
                decimal _overall = 0;
                decimal _per1 = 0;
                decimal _per2 = 0;
                int _rows = 0;
                int qty = 0;
                int _pcom = 0;
                int _com = 0;
                int _icom = 0;
                int _wit = 0;
                int _circuits = 0;
                decimal _calc = 0;
                decimal _tper1 = 0;
                decimal _tper2 = 0;
                decimal _tper3 = 0;
                decimal _ovr = 0;
                decimal _tcold = 0;
                decimal _tlive = 0;
                int _twit = 0;
                //decimal _calc = 0;
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
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
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100)
                        {
                            _p1 += 1;
                           // _pcom += 1;
                        }
                        if (Convert.ToDecimal(_row["per_com2"].ToString()) == 100)
                        {
                            _p2 += 1;
                            _pcom += 1;
                        }
                        //_p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        if (Convert.ToDecimal(_row["per_com3"].ToString()) == 100)
                        {
                            _com += 1;

                        }
                        //_p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _wit += Convert.ToInt32(_row["per_com4"].ToString());
                        if (row.col3.ToString() == "DB")
                        {
                            _circuits += Convert.ToInt32(_row["devices1"].ToString());
                            if (IsNumeric(_row["tested1"].ToString()) == true)
                                _tcold += Convert.ToInt32(_row["tested1"].ToString());
                            if (IsNumeric(_row["tested2"].ToString()) == true)
                                _tlive += Convert.ToInt32(_row["tested2"].ToString());
                            _twit += Convert.ToInt32(_row["per_com4"].ToString());
                        }
                        _p5 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p6 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p7 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per3 = 0;
                    if (count != 0)
                        _per1 = (_p5 / Convert.ToDecimal(count));
                    if (count != 0)
                        _per2 = (_p6 / Convert.ToDecimal(count));
                    if (count != 0)
                        _per3 = (_p7 / Convert.ToDecimal(count));

                    if (row.col3.ToString() == "MDB") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                    else if (row.col3.ToString() == "PFC") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                    else if (row.col3.ToString() == "HCP") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                    else if (row.col3.ToString() == "DB")
                    {
                        _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m));
                        _per1 = -1;
                    }
                    else if (row.col3.ToString() == "LCP")
                    {
                        _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m));
                        _per1 = -1;
                    }
                    else if (row.col3.ToString() == "UPS")
                    {
                        _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m));
                        _per1 = -1;
                    }
                    else if (row.col3.ToString() == "EFP")
                    {
                        _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m));
                        _per1 = -1;
                    }
                    else if (row.col3.ToString() == "SMDB") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                    else if (row.col3.ToString() == "MCC") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                    else if (row.col3.ToString() == "ATS") _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                    else if (row.col3.ToString() == "BDT")
                    {
                        _per3 = -1;
                        _total = Decimal.Round((_per1 * 0.6m) + (_per2 * 0.4m));
                    }
                    else _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m));
                    //_calc += (count * _total) / 100;
                    _ovr += _total;
                    qty += count;
                    _rows += 1;
                    _calc += _total * count;
                }
                _overall = Decimal.Round(_calc / qty);
                decimal _ocircuit = Decimal.Round((((_tlive * 0.6m) + (_tcold * 0.4m)) / _circuits) * 100);
                _overall = decimal.Round((_overall + _ocircuit) / 2);
                qty += _circuits;
                _pcom += Convert.ToInt32(_tcold);
                _com += Convert.ToInt32(_tlive);
                _wit += _twit;
                decimal _weighting = _overall * 0.3m;
                Generate_Service_Summary1(sch, 2, qty, _overall, _pcom, _com, _wit, _icom,_weighting,1);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary4(int sch)
        {
            try
            {
                decimal _per1 = 0;
                decimal _per2 = 0;
                decimal _per3 = 0;
                decimal _total = 0;
                int qty = 0;
                int _rows = 0;
                int _pcom = 0;
                int _com = 0;
                int _icom = 0;
                int _wit = 0;
                decimal _calc = 0;
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100)
                        {
                            _p1 += 1;
                            _pcom += 1;
                        }
                        if (Convert.ToDecimal(_row["per_com2"].ToString()) == 100)
                        {
                            _p2 += 1;
                        }
                        if (Convert.ToDecimal(_row["per_com3"].ToString()) == 100)
                        {
                            _p3 += 1;
                            _com += 1;
                        }
                        _wit += Convert.ToInt32(_row["per_com4"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    
                    if (_p1 != 0)
                        _per1 += (_p1 / Convert.ToDecimal(count));
                    if (_p2 != 0)
                        _per2 += (_p2 / Convert.ToDecimal(count));
                    if (_p3 != 0)
                        _per3 += (_p3 / Convert.ToDecimal(count));
                    qty += count;
                    _rows += 1;
                }
                _total = Decimal.Round((((_per1 * 0.6m) + (_per2 * 0.1m) + (_per3 * 0.3m)) / _rows) * 100);
                decimal _weighting = _total * 0.15m;
                Generate_Service_Summary1(sch, 2, qty, _total, _pcom, _com, _wit, _icom, _weighting,1);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary7(int sch)
        {
            try
            {
                decimal _per1 = 0;
                decimal _per2 = 0;
                decimal _per3 = 0;
                decimal _total = 0;
                int qty = 0;
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;
                int count = 0;
                int _qty = 0;
                 int _pcom = 0;
                int _com = 0;
                int _icom = 0;
                int _wit = 0;
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
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
                        count += Convert.ToInt32(_row["devices1"].ToString());
                        _qty += 1;
                            
                    }
                    _per1 = _p1 / _qty;
                    _per2 = (_p2 + _p3 + _p4 + _p5 + _p6 + _p7) / 6;
                    _per3 = _per2 / _qty;
                }

                _total = decimal.Round((_per1 * 0.2m + _per3 * 0.8m) * 100);
                decimal _weighting = _total * 0.1m;
                Generate_Service_Summary1(sch, 2, _qty, _total, _pcom, _com, _wit, _icom, _weighting,1);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary37(int sch)
        {
            try
            {
                decimal _per1 = 0;
                decimal _per2 = 0;
                decimal _per3 = 0;
                decimal _per4 = 0;
                decimal _per5 = 0;
                decimal _total = 0;
                int qty = 0;
                int _rows = 0;
                int _pcom = 0;
                int _com = 0;
                int _icom = 0;
                int _wit = 0;
                decimal _calc = 0;
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
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
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100)
                        {
                            _p1 += 1;
                            _com += 1;
                        }
                        _wit += Convert.ToInt32(_row["per_com7"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                       
                    }
                    if (count != 0)
                        _per1 = ((_p2 / Convert.ToDecimal(count)));
                    qty += count;
                    _rows += 1;
                    _calc += _per1 * count;
                }
                _total = Decimal.Round(_calc / qty);
                decimal _weighting = _total * 0.05m;
                Generate_Service_Summary1(sch, 2, qty, _total, -1, _com, _wit, 0, _weighting,1);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        //----- ELV-------------------
        private void Summary10_()
        {
            try
            {
                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                decimal _count = 0;
                var _result = from _data in _dtMaster.AsEnumerable()
                              select _data;
                //var _result = "";
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
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _devices = 0;
                    _p1 = 0;
                    int idx = 0;

                    if (row[0].ToString() == "Circuit IR Test")
                    {

                        _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Device/Address Test")
                    {
                        _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Sound Level Test")
                    {
                        _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                            _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Interface Test")
                    {
                        _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                            _devices += Convert.ToInt32(_row["devices1"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Fire Telephone Test")
                    {
                        _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "FTP"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Battery Autonomy Test")
                    {
                        _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                            _devices += Convert.ToInt32(_row["devices2"].ToString());
                            //_count += 1;
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Graphic Test")
                    {
                        _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                            _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Cause Effect Test")
                    {
                        _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                            _devices += Convert.ToInt32(_row["devices2"].ToString());

                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        //_drow[1] = "0";
                        //_drow[2] = "0";

                    }
                    else
                    {
                        _drow[1] = "0";
                        _drow[2] = "0";
                    }
                    if (_drow[1].ToString() != "0")
                    {
                        _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                    }
                    else
                        _total = 0;

                    _drow[3] = "-1";
                    _drow[4] = "-1";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _drow[7] = "-1";
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary10(int sch)
        {
            try
            {
                decimal _per1 = 0;
                decimal _per2 = 0;
                int _qty = 0;
                decimal _total = 0;
                int _pcom = 0;
                int _com = 0;
                int _wit = 0;
                int _icom = 0;
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
                    int count = 0;
                    
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _pcom += Convert.ToInt32(_row["per_com1"].ToString());
                        _com += Convert.ToInt32(_row["per_com2"].ToString());
                        _wit += Convert.ToInt32(_row["per_com3"].ToString());
                        if(row.col3.ToString() == "FAL")
                            count += Convert.ToInt32(_row["devices2"].ToString());
                        else
                            _qty += 1;
                    }
                    
                    if (_p1 != 0)
                    {
                        if (row.col3.ToString() == "FAL")
                            _per1 += Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
                        else
                            _per1 += Decimal.Round(_p1 / Convert.ToDecimal(_qty), 2);
                    }
                    if (_p2 != 0)
                    {
                        if (row.col3.ToString() == "FAL")
                            _per2 += Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
                        else
                            _per2 += Decimal.Round(_p2 / Convert.ToDecimal(_qty), 2);
                    }
                    _qty += count;
                }
                
                _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100);
                Generate_Service_Summary1(sch, 3, _qty, _total, _pcom, _com, _wit, _icom,0,3);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary31(int sch)
        {
            try
            {
                decimal _per1 = 0;
                decimal _per2 = 0;
                int _qty = 0;
                decimal _total = 0;
                int _pcom = 0;
                int _com = 0;
                int _wit = 0;
                int _icom = 0;
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
                    int count = 0;

                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _pcom += Convert.ToInt32(_row["per_com1"].ToString());
                        _com += Convert.ToInt32(_row["per_com2"].ToString());
                        _wit += Convert.ToInt32(_row["per_com3"].ToString());
                        count += Convert.ToInt32(_row["devices2"].ToString());
                        _qty += 1;
                    }

                    if (_p1 != 0)
                    {
                        if (row.col3.ToString() == "VAC")
                            _per1 += Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
                        else
                            _per1 += Decimal.Round(_p1 / Convert.ToDecimal(_qty), 2);
                    }
                    if (_p2 != 0)
                    {
                        if (row.col3.ToString() == "VAC")
                            _per2 += Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
                        else
                            _per2 += Decimal.Round(_p2 / Convert.ToDecimal(_qty), 2);
                    }
                    _qty += count;
                }

                _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100);
                Generate_Service_Summary1(sch, 3, _qty, _total, _pcom, _com, _wit, _icom,0,3);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary20_()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                _dtsummary.Columns.Add("IDC", typeof(string));
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
                var _result = from _data in _dtMaster.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    _points += Convert.ToInt32(_row["devices3"].ToString());
                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                    _systems += Convert.ToInt32(_row["devices1"].ToString());
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
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    if (row[0].ToString() == "Cable Continuity/IR Test") { _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = Decimal.Round(_points); }
                    else if (row[0].ToString() == "Points to Points Test") { _drow[2] = Decimal.Round(_p2).ToString(); _drow[1] = Decimal.Round(_points); }
                    else if (row[0].ToString() == "Calibration/Functional Test") { _drow[2] = Decimal.Round(_p3).ToString(); _drow[1] = Decimal.Round(_devices); }
                    else if (row[0].ToString() == "Sequence of Operation") { _drow[2] = Decimal.Round(_p4).ToString(); _drow[1] = Decimal.Round(_systems); }
                    else if (row[0].ToString() == "Graphic/Head End Test") { _drow[2] = Decimal.Round(_p5).ToString(); _drow[1] = Decimal.Round(_systems); }
                    else if (row[0].ToString() == "Loop Tuning") { _drow[2] = Decimal.Round(_p6).ToString(); _drow[1] = Decimal.Round(_systems); }
                    //else if (row[0].ToString() == "Pc Head End Test") _drow[2] = decimal.Round(_p7).ToString();
                    if (_drow[2].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "-1";
                    _drow[4] = "-1";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _drow[7] = "-1";
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary20(int sch)
        {
            try
            {
                decimal _per1 = 0;
                decimal _per2 = 0;
                int _qty = 0;
                int qty = 0;
                decimal _total = 0;
                int _pcom = 0;
                int _com = 0;
                int _wit = 0;
                int _icom = 0;
                decimal _pre = 0;
                decimal _cm = 0;
                
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

                    int count = 0;
                    int count1 = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _pcom += Convert.ToInt32(_row["per_com1"].ToString());
                        _com += Convert.ToInt32(_row["per_com2"].ToString());
                        _wit += Convert.ToInt32(_row["per_com3"].ToString());
                        count += Convert.ToInt32(_row["devices3"].ToString());
                        _qty += 1;
                       
                    }
                    if (_p1 != 0)
                    {
                        _per1 += Decimal.Round(_p1 / Convert.ToDecimal(_qty), 2);
                    }
                    if (_p2 != 0)
                    {
                        _per2 += Decimal.Round(_p2 / Convert.ToDecimal(_qty), 2);
                    }
                    qty += count;
                    //_rows += 1;
                    _pre += _p1;
                    _cm += _p2;
                }
                _per1 += Decimal.Round(_pre / Convert.ToDecimal(qty), 2);
                _per2 += Decimal.Round(_cm / Convert.ToDecimal(qty), 2);
                _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100);
                _qty += qty;
                _pcom += _pcom;
                _com += _com;
                _wit += _wit;
                Generate_Service_Summary1(sch, 3, _qty, _total, _pcom, _com, _wit, _icom,0,3);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }

        private void Summary11(int sch)
        {
            try
            {
                decimal _per1 = 0;
                decimal _per2 = 0;
                int _qty = 0;
                decimal _total = 0;
                int _pcom = 0;
                int _com = 0;
                int _wit = 0;
                int _icom = 0;
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

                    int count = 0;
                    int count1 = 0;
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
                        count += Convert.ToInt32(_row["devices2"].ToString());
                        _com += Convert.ToInt32(_row["per_com4"].ToString());
                        _wit += Convert.ToInt32(_row["per_com5"].ToString());
                        _qty += 1;

                    }
                    decimal _per3 = (_p1 + _p2 + _p3) / 3;
                    _pcom += Convert.ToInt32(decimal.Round(_per3));
                    if (_p1 != 0)
                    {
                        _per1 = Decimal.Round(_per3 / Convert.ToDecimal(_qty), 2);
                    }
                    if (_p2 != 0)
                    {
                        _per2 = Decimal.Round(_p4 / Convert.ToDecimal(_qty), 2);
                    }
                }
                _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100);
                Generate_Service_Summary1(sch, 3, _qty, _total, _pcom, _com, _wit, _icom,0,3);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary14()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                var _result = from _data in _dtMaster.AsEnumerable()
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
                _objcas.sch = Convert.ToInt32(lblsch.Text);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _drow[1] = _devices.ToString();
                    if (row[0].ToString() == "Continuity/IR Test") { _drow[2] = Decimal.Round(_p1).ToString(); }
                    else if (row[0].ToString() == "Door Intercom Alert/Bell") { _drow[2] = Decimal.Round(_p2).ToString(); }
                    else if (row[0].ToString() == "Audio/Visual Test") { _drow[2] = Decimal.Round(_p3).ToString(); }
                    else if (row[0].ToString() == "Door Release Test") { _drow[2] = Decimal.Round(_p4).ToString(); }
                    if (_drow[2].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary12_()
        {
            try
            {
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    if (row.col3.ToString() == "CU" || row.col3.ToString() == "FO")
                    {
                        decimal _p1 = 0;
                        decimal _total = 0;
                        decimal _points = 0;
                        string _test = "";
                        var _result = from _data in _dtMaster.AsEnumerable()
                                      where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                      select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            _points += Convert.ToDecimal(_row["devices1"].ToString());
                        }

                        if (row.col3.ToString() == "CU") _test = "CAT 6 Cable Tests";
                        else if (row.col3.ToString() == "FO") _test = "Fibre Optic Cable Tests";
                        if (_p1 != 0)
                            _total = Decimal.Round((_p1 / _points) * 100);
                        DataRow _drow = _dtsummary.NewRow();
                        _drow[0] = _test;
                        _drow[1] = _points.ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        _drow[3] = "-1";
                        _drow[4] = "-1";
                        _drow[5] = _total.ToString();
                        _drow[6] = row.col3.ToString();
                        _drow[7] = "-1";
                        _dtsummary.Rows.Add(_drow);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary12(int sch)
        {
            try
            {
                decimal _per1 = 0;
                int _qty = 0;
                decimal _total = 0;
                int _pcom = 0;
                int _com = 0;
                int _wit = 0;
                int _icom = 0;
                decimal _points = 0;
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();

                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    
                    string _test = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if(IsNumeric(_row["test1"].ToString())==true)
                            _p1 += Convert.ToDecimal(_row["test1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _points += Convert.ToDecimal(_row["devices1"].ToString());
                        _com += Convert.ToInt32(_row["per_com1"].ToString());
                        _wit += Convert.ToInt32(_row["per_com2"].ToString());
                        _qty += 1;
                    }
                    _per1 += _p1;
                }
                _total = decimal.Round((_per1 / _qty));
                Generate_Service_Summary1(sch, 3, Convert.ToInt32(_points), _total, -1, _com, _wit, _icom,0,3);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary16()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                decimal _count = 0;
                var _result = from _data in _dtMaster.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32(lblsch.Text);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
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
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
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
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
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
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Sequence of Operation Tests")
                    {
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                            _devices += 1;
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Graphics/ Head End Tests")
                    {
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                            _devices += 1;
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else
                    {
                        _drow[1] = "0";
                        _drow[2] = "0";
                    }
                    if (_drow[2].ToString() != "0")
                    {
                        _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                    }
                    else
                        _total = 0;
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        //----------- Public Health--------------
        private void Summary17(int sch)
        {
            try
            {
                decimal _total = 0;
                decimal _per1 = 0;
                decimal _per2 = 0;
                int _com = 0;
                int _pcom = 0;
                int _wit = 0;
                int _icom = 0;
                int _rows = 0;
                int qty = 0;
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
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
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _wit += Convert.ToInt32(_row["per_com3"].ToString());
                        _pcom += Convert.ToInt32(_row["per_com1"].ToString());
                        _com += Convert.ToInt32(_row["per_com2"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    if (_p1 != 0)
                        _per1 += Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
                    if (_p2 != 0)
                        _per2 += Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
                    qty += count;
                    _rows += 1;
                }
                _total = Decimal.Round((((_per1 * 0.2m) + (_per2 * 0.8m)) / _rows) * 100);
                Generate_Service_Summary1(sch, 4, qty, _total, _pcom, _com, _wit, _icom,0,4);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        //-------- Miscelleneous----------
        private void Summary23_()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                _dtsummary.Columns.Add("IDC", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;
                decimal _total = 0;
                decimal _count1 = 0;
                decimal _count2 = 0;
                var _result = from _data in _dtMaster.AsEnumerable()
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
                    if (_row["Cat"].ToString() == "LIFT")
                        _count2 += 1;
                    _count1 += 1;
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 23;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    if (row[0].ToString() == "Tested & Comm.") { _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = Decimal.Round(_count1); }
                    else if (row[0].ToString() == "3rd Party Inspected") { _drow[2] = Decimal.Round(_p2).ToString(); _drow[1] = Decimal.Round(_count1); }
                    else if (row[0].ToString() == "Emergency Lighting") { _drow[2] = Decimal.Round(_p3).ToString(); _drow[1] = Decimal.Round(_count2); }
                    else if (row[0].ToString() == "Power Failure Mode") { _drow[2] = Decimal.Round(_p4).ToString(); _drow[1] = Decimal.Round(_count1); }
                    else if (row[0].ToString() == "Lift Monitoring System") { _drow[2] = Decimal.Round(_p5).ToString(); _drow[1] = Decimal.Round(_count2); }
                    else if (row[0].ToString() == "Intercom") { _drow[2] = Decimal.Round(_p6).ToString(); _drow[1] = Decimal.Round(_count2); }
                    else if (row[0].ToString() == "BMS/ Fire Alarm Interface") { _drow[2] = Decimal.Round(_p7).ToString(); _drow[1] = Decimal.Round(_count1); }
                    if (_drow[2].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "-1";
                    _drow[4] = "-1";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _drow[7] = "-1";
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary23(int sch)
        {
            try
            {
                int count = 0;

                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;
                decimal _total = 0;
                decimal _qty = 0;
                int _qty1 = 0;
                int _qty2 = 0;
                int _qty3 = 0;
                int _qty4 = 0;
                int _qty5 = 0;
                int _qty6 = 0;
                int _qty7 = 0;
                var _result = from _data in _dtMaster.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com8"].ToString());
                    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                    if (_row["test1"].ToString().ToUpper() != "N/A") _qty1 += 1;
                    if (_row["Cat"].ToString() == "LIFT" || _row["Cat"].ToString() == "ESC")
                    {
                        if (_row["test3"].ToString().ToUpper() != "N/A") _qty3 += 1;
                        if (_row["test5"].ToString().ToUpper() != "N/A") _qty5 += 1;
                        if (_row["test6"].ToString().ToUpper() != "N/A") _qty6 += 1;
                        if (_row["test7"].ToString().ToUpper() != "N/A") _qty7 += 1;
                    }
                    else if (_row["Cat"].ToString() == "BMU")
                    {
                        if (_row["test2"].ToString().ToUpper() != "N/A") _qty2 += 1;
                        if (_row["test4"].ToString().ToUpper() != "N/A") _qty4 += 1;
                    }
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + (string)Session["project"];
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32((string)Session["sch"]);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                decimal _sumry = 0;
                decimal _tested = 0;
                decimal _totalqty = 0;
                decimal _totaltested = 0;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    if (row[0].ToString() == "Tested & Comm.") { _tested = _p1; _qty = Decimal.Round(_qty1); }
                    else if (row[0].ToString() == "3rd Party Inspected") { _tested = _p2; _qty = Decimal.Round(_qty2); }
                    else if (row[0].ToString() == "Emergency Lighting") { _tested = _p3; _qty = Decimal.Round(_qty3); }
                    else if (row[0].ToString() == "Power Failure Mode") { _tested = _p4; _qty = Decimal.Round(_qty4); }
                    else if (row[0].ToString() == "Lift Monitoring System") { _tested = _p5; _qty = Decimal.Round(_qty5); }
                    else if (row[0].ToString() == "Intercom") { _tested = _p6; _qty = Decimal.Round(_qty6); }
                    else if (row[0].ToString() == "BMS/ Fire Alarm Interface") { _tested = _p7; _qty = Decimal.Round(_qty7); }
                    if (_qty > 0)
                        _total = decimal.Round((_tested / _qty) * 100);
                    _sumry += _total * _qty;
                    _totalqty += _qty;
                    _totaltested += _tested;
                }
                _total = decimal.Round((_sumry / _totalqty));
                decimal _weighting = _total * 0.91m;
                Generate_Service_Summary1(sch, 5, Convert.ToInt32(_totalqty), _total, -1, Convert.ToInt32(_totaltested), 0, 0, _weighting, 8);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary24()
        {
            try
            {
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _total = 0;
                int _count = 0;
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    _total = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _s = _row[0].ToString();
                        _count += 1;
                    }
                    decimal _per1 = 0;
                    if (_count != 0)
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(_count), 2);
                    _total = Decimal.Round((_per1) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = _count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary34()
        {
            try
            {
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
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
                        _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                        count += 1;
                    }
                    if (count != 0)
                        _total = Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary35()
        {
            try
            {
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
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
                        _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                        count += 1;
                    }
                    if (count != 0)
                        _total = Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary36(int sch)
        {
            try
            {
                
                decimal _total = 0;
                decimal _per1 = 0;
                decimal _p1 = 0;
                int _pcom = 0;
                int _com = 0;
                int _wit = 0;
                int _icom = 0;
                int count = 0;
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    
                   
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _com += Convert.ToInt32(_row["per_com2"].ToString());
                        _wit += Convert.ToInt32(_row["per_com3"].ToString());
                        count += 1;
                    }

                }
                    _total = Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                    decimal _weighting = _total * 0.09m;
                    Generate_Service_Summary1(sch, 5, count, _total, -1, _com, _wit, _icom, _weighting,8);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary33()
        {
            try
            {
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));

                //_row[0] = row.col1.ToString();
                //_row[1] = row.col2.ToString();
                decimal _p1 = 0;
                decimal _total = 0;
                int count = 0;
                string _s = "";
                var _result = from _data in _dtMaster.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    count += 1;
                }
                if (count != 0)
                    _total = Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                DataRow _drow = _dtsummary.NewRow();
                _drow[0] = "SYSTEM INTEGRATION TEST";
                _drow[1] = count.ToString();
                _drow[2] = Decimal.Round(_p1).ToString();
                _drow[3] = "0";
                _drow[4] = "0";
                _drow[5] = _total.ToString();
                _drow[6] = "";
                _dtsummary.Rows.Add(_drow);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Generate_Summary_Graph(int _sch,int pos)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _clsproject _objcls1 = new _clsproject();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.sch = _sch;
            string _sch_name = _objbll.Get_CasName(_objcls, _objdb);
            _objdb.DBName = "DBCML";
            _objcls1.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls1, _objdb);
            
            var _result = from _data in _dtsummary.AsEnumerable()
                          select _data;
            //int count = 0;
            foreach (var row in _result)
            {
                _objcls.sch_name = _sch_name;
                _objcls.sys_name = row["SYS_NAME"].ToString();
                _objcls.quantity = Convert.ToInt32(row["QTY"].ToString());
                _objcls.total = Convert.ToDecimal(row["TOTAL"].ToString());
                _objcls.pre_com = Convert.ToInt32(row["PER_COMPLETED"].ToString());
                _objcls.com = Convert.ToInt32(row["PER_COMPLETED1"].ToString());
                _objcls.witne = Convert.ToInt32(row["PER_COMPLETED2"].ToString());
                _objcls.insta = Convert.ToInt32(row["IDC"].ToString());
                _objcls.Position = pos;
                _objbll.Generate_Cas_SrvSum_All(_objcls, _objdb);
            }
        }
        private void Update_Logo()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsproject _objcls1 = new _clsproject();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objdb.DBName = "DBCML";
            _objcls1.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls1, _objdb);
        }
        private void Generate_Service_Summary(int _sch, int pos)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _clsproject _objcls1 = new _clsproject();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.sch = _sch;
            string _sch_name = _objbll.Get_CasName(_objcls, _objdb);
            string _srv_name = _objbll.Get_SrvName(_objcls, _objdb);
            _objdb.DBName = "DBCML";
            _objcls1.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls1, _objdb);

            var _result = from _data in _dtsummary.AsEnumerable()
                          select _data;
            //int count = 0;
            int _qty = 0;
            decimal _progress = 0;
            decimal _count = 0;
            foreach (var row in _result)
            {
                _qty += Convert.ToInt32(row["QTY"].ToString());
                _progress += Convert.ToDecimal(row["TOTAL"].ToString());
            }
            _objcls.sch_name = _srv_name;
            _objcls.sys_name = _sch_name;
            _objcls.quantity = _qty;
            _objcls.total = _progress;
            _objcls.pre_com = 0;
            _objcls.com = 0;
            _objcls.witne = 0;
            _objcls.insta = 0;
            _objcls.Position = pos;
            _objbll.Generate_Cas_SrvSum_All(_objcls, _objdb);
        }
        private void Generate_srvovr_Summary()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objbll.GENERATE_SRVOVR_SUMMARY(_objdb);
        }
        private void Generate_srvovr_Summary_split()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();
            _objcls.srv = Convert.ToInt32(lblsrv.Text);
            _objbll.GENERATE_SRVOVR_SUMMARY_SPLIT(_objcls,_objdb);
        }
        private void Generate_Service_Summary1(int _sch, int pos, int qty, decimal progress,int pre_com,int comm,int witness,int icom,decimal weighting,int srv)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _clsproject _objcls1 = new _clsproject();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.sch = _sch;
            string _sch_name = _objbll.Get_CasName(_objcls, _objdb);
            string _srv_name = _objbll.Get_SrvName(_objcls, _objdb);
            _objdb.DBName = "DBCML";
            //_objcls1.prjcode = lblprj.Text;
            //_objbll.Update_RPTLogo(_objcls1, _objdb);

            //var _result = from _data in _dtsummary.AsEnumerable()
            //              select _data;
            ////int count = 0;
            //int _qty = 0;
            //decimal _progress = 0;
            //decimal _count = 0;
            //foreach (var row in _result)
            //{
            //    _qty += Convert.ToInt32(row["QTY"].ToString());
            //    _progress += Convert.ToDecimal(row["TOTAL"].ToString());
            //}
            _objcls.sch_name = _srv_name;
            _objcls.sys_name = _sch_name;
            _objcls.quantity = qty;
            _objcls.total = progress;
            _objcls.pre_com = pre_com;
            _objcls.com = comm;
            _objcls.witne = witness;
            _objcls.insta = icom;
            _objcls.Position = pos;
            _objcls.per_com1 = weighting;
            _objcls.srv = srv;
            _objbll.Generate_Cas_SrvSum_All(_objcls, _objdb);
        }
        ReportDocument cryRpt = new ReportDocument();
        protected void Page_Unload(object sender, EventArgs e)
        {
                //cryRpt.Dispose();
                //cryRpt.Close();
        }
        private void Generate_Reports()
        {            
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            if (lblmode.Text == "0")
            {
                cryRpt.Load(Server.MapPath("cas_srv_sum.rpt"));
                cryRpt.SetParameterValue("srv", lblsrv.Text);
            }
            else if (lblmode.Text=="1")
            {
                cryRpt.Load(Server.MapPath("cas_srv_sum2.rpt"));
            }
            else if (lblmode.Text == "2")
            {
                cryRpt.Load(Server.MapPath("cas_srv_sum_all.rpt"));
            }
            else if (lblmode.Text == "3")
            {
                if (lblsrv.Text == "9" && lblprj.Text == "CCAD")
                    cryRpt.Load(Server.MapPath("cas_srv_sum3.rpt"));
                else
                    cryRpt.Load(Server.MapPath("cas_srv_sum2.rpt"));
            }
            //crConnectionInfo.ServerName = "213.171.197.149,49296";
            //crConnectionInfo.DatabaseName = "DBCML";
            //crConnectionInfo.UserID = "CT_user";
            //crConnectionInfo.Password = "CTplus#2016";
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
            
            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.DataBind();
            Session["Report"] = cryRpt;
        }
        protected void TimerTick(object sender, EventArgs e)
        {
            //if (lblmode.Text == "3")
            //{
            //    Generate_srvovr_Summary_split();
            //}
            //else if (lblmode.Text == "1")
            //{
            //    //Generate_Service_Summary();
            //    Generate_srvovr_Summary();
            //}
            //else if (lblmode.Text == "2")
            //{
            //    //Generate_Service_Summary();
            //    Generate_srvovr_Summary();
            //}
            //Update_Logo();
            //Generate_Reports();
            //Timer1.Enabled = false;
            //imgLoader.Visible = false;
        }
        private void Page_Init(object sender, EventArgs e)
        {
           // _ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                lblsrv.Text = _prm.Substring(0, _prm.IndexOf("_P"));
                lblprj.Text = _prm.Substring(_prm.IndexOf("_P") + 2, _prm.IndexOf("_T") - (_prm.IndexOf("_P") + 2));
                lblmode.Text = _prm.Substring(_prm.IndexOf("_T") + 2);
                Session["Report"] = null;
                if (lblmode.Text == "3")
                {
                    Generate_srvovr_Summary_split();
                }
                else if (lblmode.Text == "1")
                {
                    //Generate_Service_Summary();
                    Generate_srvovr_Summary();
                }
                else if (lblmode.Text == "2")
                {
                    //Generate_Service_Summary();
                    Generate_srvovr_Summary();
                }
                Update_Logo();
                Generate_Reports();
                imgLoader.Visible = false;
            }
            else
            {
                if (Session["Report"] != null)
                {
                    CrystalReportViewer1.ReportSource = (ReportDocument)Session["Report"];
                    CrystalReportViewer1.DataBind();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Add Fake Delay to simulate long running process.
            System.Threading.Thread.Sleep(5000);
            string _prm = Request.QueryString[0].ToString();
            lblsrv.Text = _prm.Substring(0, _prm.IndexOf("_P"));
            lblprj.Text = _prm.Substring(_prm.IndexOf("_P") + 2, _prm.IndexOf("_T") - (_prm.IndexOf("_P") + 2));
            lblmode.Text = _prm.Substring(_prm.IndexOf("_T") + 2);
            if (lblmode.Text == "3")
            {
                Generate_Service_Summary_split(Convert.ToInt32(lblsrv.Text));
            }
            else if (lblmode.Text == "1")
            {
                Generate_Service_Summary();
            }
            else if (lblmode.Text == "2")
            {
                Generate_Service_Summary();
            }
            Generate_Reports();
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
        //private void Summary16()
        //{
        //    try
        //    {
        //        _dtsummary = new DataTable();
        //        _dtsummary.Columns.Add("SYS_NAME", typeof(string));
        //        _dtsummary.Columns.Add("QTY", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
        //        _dtsummary.Columns.Add("TOTAL", typeof(string));
        //        _dtsummary.Columns.Add("CODE", typeof(string));
        //        decimal _p1 = 0;
        //        decimal _devices = 0;
        //        decimal _total = 0;
        //        decimal _count = 0;
        //        var _result = from _data in _dtresult.AsEnumerable()
        //                      select _data;
        //        BLL_Dml _objbll = new BLL_Dml();
        //        _database _objdb = new _database();
        //        _objdb.DBName = "DB_" + (string)Session["project"];
        //        _clscassheet _objcas = new _clscassheet();
        //        _objcas.sch = Convert.ToInt32((string)Session["sch"]);
        //        DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
        //        var TestNames = from _data in _dtnames.AsEnumerable()
        //                        select _data;
        //        foreach (var row in TestNames)
        //        {
        //            _total = 0;
        //            DataRow _drow = _dtsummary.NewRow();
        //            _drow[0] = row[0].ToString();
        //            _devices = 0;
        //            _p1 = 0;
        //            if (row[0].ToString() == "Continuity/ IR Tests")
        //            {
        //                foreach (var _row in _result)
        //                {
        //                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
        //                    if (IsNumeric(_row["devices2"].ToString()) == true)
        //                        _devices += Convert.ToInt32(_row["devices2"].ToString());
        //                    else
        //                        _devices += 0;
        //                }
        //                _drow[1] = Decimal.Round(_devices).ToString();
        //                _drow[2] = Decimal.Round(_p1).ToString();
        //            }
        //            else if (row[0].ToString() == "Point to Point Tests")
        //            {
        //                foreach (var _row in _result)
        //                {
        //                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
        //                    if (IsNumeric(_row["devices2"].ToString()) == true)
        //                        _devices += Convert.ToInt32(_row["devices2"].ToString());
        //                    else
        //                        _devices += 0;
        //                }
        //                _drow[1] = Decimal.Round(_devices).ToString();
        //                _drow[2] = Decimal.Round(_p1).ToString();
        //            }
        //            else if (row[0].ToString() == "Calibration/ Functional Tests")
        //            {
        //                foreach (var _row in _result)
        //                {

        //                    _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
        //                    if (IsNumeric(_row["devices1"].ToString()) == true)
        //                        _devices += Convert.ToInt32(_row["devices1"].ToString());
        //                    else
        //                        _devices += 0;
        //                }
        //                _drow[1] = Decimal.Round(_devices).ToString();
        //                _drow[2] = Decimal.Round(_p1).ToString();
        //            }
        //            else if (row[0].ToString() == "Sequence of Operation Tests")
        //            {
        //                foreach (var _row in _result)
        //                {
        //                    _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
        //                    _devices += 1;
        //                }
        //                _drow[1] = Decimal.Round(_devices).ToString();
        //                _drow[2] = Decimal.Round(_p1).ToString();

        //            }
        //            else if (row[0].ToString() == "Graphics/ Head End Tests")
        //            {
        //                foreach (var _row in _result)
        //                {
        //                    _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
        //                    _devices += 1;
        //                }
        //                _drow[1] = Decimal.Round(_devices).ToString();
        //                _drow[2] = Decimal.Round(_p1).ToString();

        //            }
        //            else
        //            {
        //                _drow[1] = "0";
        //                _drow[2] = "0";
        //            }
        //            if (_drow[2].ToString() != "0")
        //            {
        //                _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
        //            }
        //            else
        //                _total = 0;
        //            _drow[3] = "0";
        //            _drow[4] = "0";
        //            _drow[5] = _total.ToString();
        //            _drow[6] = row[0].ToString();
        //            _dtsummary.Rows.Add(_drow);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
        //    }
        //}
        //private void Summary24()
        //{
        //    try
        //    {
        //        _dtsummary = new DataTable();
        //        _dtsummary.Columns.Add("SYS_NAME", typeof(string));
        //        _dtsummary.Columns.Add("QTY", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
        //        _dtsummary.Columns.Add("TOTAL", typeof(string));
        //        _dtsummary.Columns.Add("CODE", typeof(string));
        //        decimal _p1 = 0;
        //        decimal _total = 0;
        //        decimal _count = 0;
        //        var distinctRows = (from DataRow dRow in _dtresult.Rows
        //                            select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
        //        foreach (var row in distinctRows)
        //        {
        //            _total = 0;
        //            string _s = "";
        //            var _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
        //                          select _data;
        //            foreach (var _row in _result)
        //            {
        //                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
        //                _s = _row[0].ToString();
        //                _count += 1;
        //            }
        //            decimal _per1 = 0;
        //            if (_count != 0)
        //                _per1 = Decimal.Round(_p1 / Convert.ToDecimal(_count), 2);
        //            _total = Decimal.Round((_per1) * 100);
        //            DataRow _drow = _dtsummary.NewRow();
        //            _drow[0] = row.col2.ToString();
        //            _drow[1] = _count.ToString();
        //            _drow[2] = Decimal.Round(_p1).ToString();
        //            _drow[3] = "0";
        //            _drow[4] = "0";
        //            _drow[5] = _total.ToString();
        //            _drow[6] = row.col3.ToString();
        //            _dtsummary.Rows.Add(_drow);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
        //    }
        //}
        //private void Summary34()
        //{
        //    try
        //    {
        //        _dtsummary = new DataTable();
        //        _dtsummary.Columns.Add("SYS_NAME", typeof(string));
        //        _dtsummary.Columns.Add("QTY", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
        //        _dtsummary.Columns.Add("TOTAL", typeof(string));
        //        _dtsummary.Columns.Add("CODE", typeof(string));
        //        var distinctRows = (from DataRow dRow in _dtresult.Rows
        //                            select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
        //        foreach (var row in distinctRows)
        //        {
        //            //_row[0] = row.col1.ToString();
        //            //_row[1] = row.col2.ToString();
        //            decimal _p1 = 0;
        //            decimal _total = 0;
        //            int count = 0;
        //            string _s = "";
        //            var _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
        //                          select _data;
        //            foreach (var _row in _result)
        //            {
        //                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
        //                count += 1;
        //            }
        //            if (count != 0)
        //                _total = Decimal.Round(_p1 / Convert.ToDecimal(count), 2) * 100;
        //            DataRow _drow = _dtsummary.NewRow();
        //            _drow[0] = row.col2.ToString();
        //            _drow[1] = count.ToString();
        //            _drow[2] = Decimal.Round(_p1).ToString();
        //            _drow[3] = 0;
        //            _drow[4] = 0;
        //            _drow[5] = _total.ToString();
        //            _drow[6] = row.col3.ToString();
        //            _dtsummary.Rows.Add(_drow);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
        //    }
        //}
        //private void Summary8_1()
        //{
        //    try
        //    {
        //        _dtsummary = new DataTable();
        //        _dtsummary.Columns.Add("SYS_NAME", typeof(string));
        //        _dtsummary.Columns.Add("QTY", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
        //        _dtsummary.Columns.Add("TOTAL", typeof(string));
        //        _dtsummary.Columns.Add("CODE", typeof(string));
        //        var distinctRows = (from DataRow dRow in _dtresult.Rows
        //                            select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
        //        foreach (var row in distinctRows)
        //        {
        //            //_row[0] = row.col1.ToString();
        //            //_row[1] = row.col2.ToString();
        //            decimal _p1 = 0;
        //            decimal _p2 = 0;
        //            decimal _p3 = 0;
        //            decimal _p4 = 0;
        //            decimal _p5 = 0;
        //            decimal _p6 = 0;
        //            decimal _p7 = 0;
        //            decimal _total = 0;
        //            decimal _total1 = 0;
        //            decimal _overall = 0;
        //            int count = 0;
        //            string _s = "";
        //            var _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
        //                          select _data;
        //            foreach (var _row in _result)
        //            {
        //                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
        //                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
        //                _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
        //                _p4 += Convert.ToDecimal(_row["per_com5"].ToString());//pft
        //                _p5 += Convert.ToDecimal(_row["per_com6"].ToString());//pwron
        //                _p6 += Convert.ToDecimal(_row["per_com7"].ToString());//fpt
        //                _p7 += Convert.ToDecimal(_row["per_com8"].ToString());//arm
        //                _s = _row[0].ToString();
        //                count += 1;
        //            }
        //            decimal _per1 = 0;
        //            decimal _per2 = 0;
        //            decimal _per3 = 0;
        //            decimal _per4 = 0;
        //            decimal _per5 = 0;
        //            decimal _com1 = 0;
        //            decimal _com2 = 0;
        //            if (_p1 != 0)
        //            {
        //                _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
        //                _com1 = _per1 * 100;
        //            }
        //            if (_p2 != 0)
        //            {
        //                _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
        //                _com2 = _per2 * 100;
        //            }
        //            if (_p3 != 0)
        //                _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count), 2);
        //            _total = Decimal.Round(((_com1 * 0.1m) + (_com2 * 0.9m)));
        //            if (_p6 != 0)
        //                _per4 = Decimal.Round(_p6 / Convert.ToDecimal(count), 2);
        //            if (_p7 != 0)
        //                _per5 = Decimal.Round(_p7 / Convert.ToDecimal(count), 2);
        //            _total1 = Decimal.Round(((_per4 * 0.5m) + (_per5 * 0.5m)) * 100);
        //            _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
        //            DataRow _drow = _dtsummary.NewRow();
        //            _drow[0] = row.col2.ToString();
        //            _drow[1] = count.ToString();
        //            _drow[2] = Decimal.Round(_p1).ToString();
        //            _drow[3] = Decimal.Round(_p2).ToString();
        //            _drow[4] = Decimal.Round(_p3).ToString();
        //            _drow[5] = _overall.ToString();
        //            _drow[6] = row.col3.ToString();
        //            _dtsummary.Rows.Add(_drow);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
        //    }
        //}
        //private void Summary9_1()
        //{
        //    try
        //    {
        //        _dtsummary = new DataTable();
        //        _dtsummary.Columns.Add("SYS_NAME", typeof(string));
        //        _dtsummary.Columns.Add("QTY", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
        //        _dtsummary.Columns.Add("TOTAL", typeof(string));
        //        _dtsummary.Columns.Add("CODE", typeof(string));
        //        var distinctRows = (from DataRow dRow in _dtresult.Rows
        //                            select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
        //        foreach (var row in distinctRows)
        //        {
        //            decimal _p1 = 0;
        //            decimal _p2 = 0;
        //            decimal _p3 = 0;
        //            decimal _p4 = 0;
        //            decimal _p5 = 0;
        //            decimal _p6 = 0;
        //            decimal _p7 = 0;
        //            decimal _p8 = 0;
        //            decimal _total = 0;
        //            decimal _total1 = 0;
        //            decimal _overall = 0;
        //            int count = 0;
        //            string _s = "";
        //            var _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
        //                          select _data;
        //            foreach (var _row in _result)
        //            {
        //                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
        //                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
        //                _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
        //                _p4 += Convert.ToDecimal(_row["per_com5"].ToString());//pft
        //                _p5 += Convert.ToDecimal(_row["per_com6"].ToString());//pwron
        //                _p6 += Convert.ToDecimal(_row["per_com7"].ToString());//fpt
        //                _p7 += Convert.ToDecimal(_row["per_com8"].ToString());//arm
        //                _p8 += Convert.ToDecimal(_row["per_com4"].ToString());//ins
        //                _s = _row[0].ToString();
        //                count += 1;
        //            }
        //            decimal _per1 = 0;
        //            decimal _per2 = 0;
        //            decimal _per3 = 0;
        //            decimal _per4 = 0;
        //            decimal _per5 = 0;
        //            decimal _per6 = 0;
        //            decimal _per7 = 0;
        //            decimal _com1 = 0;
        //            decimal _com2 = 0;
        //            if (_p1 != 0)
        //            {
        //                _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
        //                _com1 = _per1 * 100;
        //            }
        //            if (_p2 != 0)
        //            {
        //                _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
        //                _com2 = _per2 * 100;
        //            }
        //            if (_p4 != 0)
        //                _per3 = Decimal.Round(_p4 / Convert.ToDecimal(count), 2);
        //            _total = Decimal.Round(((_com1 * 0.1m) + (_com2 * 0.9m)));
        //            if (_p5 != 0)
        //                _per4 = Decimal.Round(_p5 / Convert.ToDecimal(count), 2);
        //            if (_p6 != 0)
        //                _per5 = Decimal.Round(_p6 / Convert.ToDecimal(count), 2);
        //            if (_p8 != 0)
        //                _per6 = Decimal.Round(_p8 / Convert.ToDecimal(count), 2);
        //            if (_p7 != 0)
        //                _per7 = Decimal.Round(_p7 / Convert.ToDecimal(count), 2);
        //            _total1 = Decimal.Round(((_per4 * 0.2m) + (_per5 * 0.2m) + (_per6 * 0.2m) + (_per3 * 0.2m) + (_per7 * 0.2m)) * 100);
        //            _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
        //            DataRow _drow = _dtsummary.NewRow();
        //            _drow[0] = row.col2.ToString();
        //            _drow[1] = count.ToString();
        //            _drow[2] = Decimal.Round(_p1).ToString();
        //            _drow[3] = Decimal.Round(_p2).ToString();
        //            _drow[4] = Decimal.Round(_p3).ToString();
        //            _drow[5] = _overall.ToString();
        //            _drow[6] = row.col3.ToString();
        //            _dtsummary.Rows.Add(_drow);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
        //    }
        //}
        //private void Summary2_1()
        //{

        //    try
        //    {
        //        _dtsummary = new DataTable();
        //        _dtsummary.Columns.Add("SYS_NAME", typeof(string));
        //        _dtsummary.Columns.Add("QTY", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
        //        _dtsummary.Columns.Add("TOTAL", typeof(string));
        //        _dtsummary.Columns.Add("CODE", typeof(string));
        //        var distinctRows = (from DataRow dRow in _dtresult.Rows
        //                            select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
        //        foreach (var row in distinctRows)
        //        {
        //            decimal _p1 = 0;
        //            decimal _p2 = 0;
        //            decimal _p3 = 0;
        //            decimal _p4 = 0;
        //            decimal _p5 = 0;
        //            decimal _p6 = 0;
        //            decimal _total = 0;
        //            decimal _total1 = 0;
        //            int count = 0;
        //            string _s = "";
        //            var _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
        //                          select _data;
        //            foreach (var _row in _result)
        //            {
        //                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
        //                _p2 += Convert.ToDecimal(_row["per_com6"].ToString());
        //                _p3 += Convert.ToDecimal(_row["per_com2"].ToString());//pft
        //                _p4 += Convert.ToDecimal(_row["per_com3"].ToString());//pwron
        //                _p5 += Convert.ToDecimal(_row["per_com4"].ToString());//fpt
        //                _p6 += Convert.ToDecimal(_row["per_com5"].ToString());//arm
        //                _s = _row[0].ToString();
        //                count += 1;
        //            }
        //            decimal _per1 = 0;
        //            decimal _per2 = 0;
        //            decimal _per3 = 0;
        //            decimal _per4 = 0;
        //            decimal _per5 = 0;
        //            decimal _per6 = 0;
        //            if (_p1 != 0)
        //                _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
        //            if (_p2 != 0)
        //                _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
        //            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), 2);
        //            if (_p3 != 0)
        //                _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
        //            if (_p4 != 0)
        //                _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
        //            if (_p5 != 0)
        //                _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
        //            if (_p6 != 0)
        //                _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
        //            _total1 = Decimal.Round((((_per3 * 0.25m) + (_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m)) * 100), 2);
        //            decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
        //            DataRow _drow = _dtsummary.NewRow();
        //            _drow[0] = row.col2.ToString();
        //            _drow[1] = count.ToString();
        //            _drow[2] = "0";
        //            _drow[3] = "0";
        //            _drow[4] = "0";
        //            _drow[5] = _overall.ToString();
        //            _drow[6] = row.col3.ToString();
        //            _dtsummary.Rows.Add(_drow);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
        //    }
        //}
        //private void Summary5_1()
        //{

        //    try
        //    {
        //        _dtsummary = new DataTable();
        //        _dtsummary.Columns.Add("SYS_NAME", typeof(string));
        //        _dtsummary.Columns.Add("QTY", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
        //        _dtsummary.Columns.Add("TOTAL", typeof(string));
        //        _dtsummary.Columns.Add("CODE", typeof(string));
        //        var distinctRows = (from DataRow dRow in _dtresult.Rows
        //                            select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
        //        foreach (var row in distinctRows)
        //        {
        //            //_row[0] = row.col1.ToString();
        //            //_row[1] = row.col2.ToString();
        //            decimal _p1 = 0;
        //            decimal _p2 = 0;
        //            decimal _p3 = 0;
        //            decimal _p4 = 0;
        //            decimal _p5 = 0;
        //            decimal _p6 = 0;
        //            decimal _p7 = 0;
        //            decimal _total = 0;
        //            decimal _total1 = 0;
        //            int count = 0;
        //            string _s = "";
        //            var _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
        //                          select _data;
        //            foreach (var _row in _result)
        //            {
        //                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
        //                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
        //                _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
        //                _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pft
        //                _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//pwron
        //                _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//fpt
        //                _p7 += Convert.ToDecimal(_row["per_com7"].ToString());//arm
        //                _s = _row[0].ToString();
        //                count += 1;
        //            }
        //            decimal _per1 = 0;
        //            decimal _per2 = 0;
        //            decimal _per3 = 0;
        //            decimal _per4 = 0;
        //            decimal _per5 = 0;
        //            decimal _per6 = 0;
        //            decimal _per7 = 0;
        //            if (_p1 != 0)
        //                _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
        //            if (_p2 != 0)
        //                _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
        //            if (_p3 != 0)
        //                _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
        //            if (row.col3.ToString() == "PFC")
        //                _total = Decimal.Round(_per1, 2);
        //            else if (row.col3.ToString() == "MDB" || row.col3.ToString() == "VFD" || row.col3.ToString() == "MCC")
        //                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m)), 2);
        //            else if (row.col3.ToString() == "ATS" || row.col3.ToString() == "UPS" || row.col3.ToString() == "LCP" || row.col3.ToString() == "BAT")
        //                _total = Decimal.Round(((_per1 * 0.8m) + (_per2 * 0.2m)), 2);
        //            else if (row.col3.ToString() == "IPS")
        //                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), 2);
        //            else if (row.col3.ToString() == "DB")
        //                _total = Decimal.Round(((_per2 * 0.7m) + (_per3 * 0.3m)), 2);
        //            else
        //                _total = Decimal.Round(((_per1 * 0.3m) + (_per2 * 0.5m) + (_per3 * 0.2m)), 2);
        //            if (_p4 != 0)
        //                _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
        //            if (_p5 != 0)
        //                _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
        //            if (_p6 != 0)
        //                _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
        //            if (_p7 != 0)
        //                _per7 = Decimal.Round((_p7 / Convert.ToDecimal(count)), 2);
        //            _total1 = Decimal.Round((((_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per7 * 0.25m)) * 100), 2);
        //            decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
        //            DataRow _drow = _dtsummary.NewRow();
        //            _drow[0] = row.col2.ToString();
        //            _drow[1] = count.ToString();
        //            _drow[2] = "0";
        //            _drow[3] = "0";
        //            _drow[4] = "0";
        //            _drow[5] = _overall.ToString();
        //            _drow[6] = row.col3.ToString();
        //            _dtsummary.Rows.Add(_drow);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
        //    }
        //}
        //private void Summary4_1()
        //{

        //    try
        //    {
        //        _dtsummary = new DataTable();
        //        _dtsummary.Columns.Add("SYS_NAME", typeof(string));
        //        _dtsummary.Columns.Add("QTY", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
        //        _dtsummary.Columns.Add("TOTAL", typeof(string));
        //        _dtsummary.Columns.Add("CODE", typeof(string));
        //        var distinctRows = (from DataRow dRow in _dtresult.Rows
        //                            select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
        //        foreach (var row in distinctRows)
        //        {
        //            decimal _p1 = 0;
        //            decimal _p2 = 0;
        //            decimal _p3 = 0;
        //            decimal _p4 = 0;
        //            decimal _p5 = 0;
        //            decimal _p6 = 0;
        //            decimal _total = 0;
        //            decimal _total1 = 0;
        //            int count = 0;
        //            string _s = "";
        //            var _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
        //                          select _data;
        //            foreach (var _row in _result)
        //            {
        //                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
        //                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
        //                _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//pft
        //                _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pwron
        //                _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//fpt
        //                _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//arm
        //                _s = _row[0].ToString();
        //                count += 1;
        //            }
        //            decimal _per1 = 0;
        //            decimal _per2 = 0;
        //            decimal _per3 = 0;
        //            decimal _per4 = 0;
        //            decimal _per5 = 0;
        //            decimal _per6 = 0;
        //            if (_p1 != 0)
        //                _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
        //            if (_p2 != 0)
        //                _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
        //            _total = Decimal.Round(((_per1 * 0.6m) + (_per2 * 0.4m)), 2);
        //            if (_p3 != 0)
        //                _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
        //            if (_p4 != 0)
        //                _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
        //            if (_p5 != 0)
        //                _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
        //            if (_p6 != 0)
        //                _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
        //            _total1 = Decimal.Round((((_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per3 * 0.25m)) * 100), 2);
        //            decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
        //            DataRow _drow = _dtsummary.NewRow();
        //            _drow[0] = row.col2.ToString();
        //            _drow[1] = count.ToString();
        //            _drow[2] = "0";
        //            _drow[3] = "0";
        //            _drow[4] = "0";
        //            _drow[5] = _overall.ToString();
        //            _drow[6] = row.col3.ToString();
        //            _dtsummary.Rows.Add(_drow);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
        //    }
        //}
        //private void Summary6_1()
        //{

        //    try
        //    {
        //        _dtsummary = new DataTable();
        //        _dtsummary.Columns.Add("SYS_NAME", typeof(string));
        //        _dtsummary.Columns.Add("QTY", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
        //        _dtsummary.Columns.Add("TOTAL", typeof(string));
        //        _dtsummary.Columns.Add("CODE", typeof(string));
        //        var distinctRows = (from DataRow dRow in _dtresult.Rows
        //                            select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
        //        foreach (var row in distinctRows)
        //        {
        //            decimal _p1 = 0;
        //            decimal _p2 = 0;
        //            decimal _p3 = 0;
        //            decimal _p4 = 0;
        //            decimal _p5 = 0;
        //            decimal _p6 = 0;
        //            decimal _p7 = 0;
        //            decimal _total = 0;
        //            decimal _total1 = 0;
        //            int count = 0;
        //            string _s = "";
        //            var _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
        //                          select _data;
        //            foreach (var _row in _result)
        //            {
        //                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
        //                _p2 += Convert.ToDecimal(_row["per_com3"].ToString());
        //                _p3 += Convert.ToDecimal(_row["per_com4"].ToString());
        //                _p4 += Convert.ToDecimal(_row["per_com5"].ToString());//pft
        //                _p5 += Convert.ToDecimal(_row["per_com6"].ToString());//pwron
        //                _p6 += Convert.ToDecimal(_row["per_com7"].ToString());//fpt
        //                _p7 += Convert.ToDecimal(_row["per_com8"].ToString());//arm
        //                _s = _row[0].ToString();
        //                count += 1;
        //            }
        //            decimal _per1 = 0;
        //            decimal _per2 = 0;
        //            decimal _per3 = 0;
        //            decimal _per4 = 0;
        //            decimal _per5 = 0;
        //            decimal _per6 = 0;
        //            decimal _per7 = 0;
        //            if (_p1 != 0)
        //                _per1 = Decimal.Round(((_p1 / Convert.ToDecimal(count)) * 100), 2);
        //            if (_p2 != 0)
        //                _per2 = Decimal.Round(((_p2 / Convert.ToDecimal(count)) * 100), 2);
        //            if (_p3 != 0)
        //                _per3 = Decimal.Round(((_p3 / Convert.ToDecimal(count)) * 100), 2);
        //            _total = Decimal.Round(((_per1 * 0.6m) + (_per2 * 0.3m) + (_per3 * 0.1m)), 2);
        //            if (_p4 != 0)
        //                _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
        //            if (_p5 != 0)
        //                _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
        //            if (_p6 != 0)
        //                _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
        //            if (_p7 != 0)
        //                _per7 = Decimal.Round((_p7 / Convert.ToDecimal(count)), 2);
        //            _total1 = Decimal.Round((((_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per7 * 0.25m)) * 100), 2);
        //            decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
        //            DataRow _drow = _dtsummary.NewRow();
        //            _drow[0] = row.col2.ToString();
        //            _drow[1] = count.ToString();
        //            _drow[2] = "0";
        //            _drow[3] = "0";
        //            _drow[4] = "0";
        //            _drow[5] = _overall.ToString();
        //            _drow[6] = row.col3.ToString();
        //            _dtsummary.Rows.Add(_drow);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
        //    }
        //}
        //private void Summary3_1()
        //{

        //    try
        //    {
        //        _dtsummary = new DataTable();
        //        _dtsummary.Columns.Add("SYS_NAME", typeof(string));
        //        _dtsummary.Columns.Add("QTY", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
        //        _dtsummary.Columns.Add("TOTAL", typeof(string));
        //        _dtsummary.Columns.Add("CODE", typeof(string));
        //        var distinctRows = (from DataRow dRow in _dtresult.Rows
        //                            select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
        //        foreach (var row in distinctRows)
        //        {
        //            decimal _p1 = 0;
        //            decimal _p2 = 0;
        //            decimal _p3 = 0;
        //            decimal _p4 = 0;
        //            decimal _p5 = 0;
        //            decimal _p6 = 0;
        //            decimal _total = 0;
        //            decimal _total1 = 0;
        //            int count = 0;
        //            string _s = "";
        //            var _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
        //                          select _data;
        //            foreach (var _row in _result)
        //            {
        //                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
        //                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
        //                _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//pft
        //                _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pwron
        //                _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//fpt
        //                _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//arm
        //                _s = _row[0].ToString();
        //                count += 1;
        //            }
        //            decimal _per1 = 0;
        //            decimal _per2 = 0;
        //            decimal _per3 = 0;
        //            decimal _per4 = 0;
        //            decimal _per5 = 0;
        //            decimal _per6 = 0;
        //            if (_p1 != 0)
        //                _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
        //            if (_p2 != 0)
        //                _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
        //            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), 2);
        //            if (_p3 != 0)
        //                _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
        //            if (_p4 != 0)
        //                _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
        //            if (_p5 != 0)
        //                _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
        //            if (_p6 != 0)
        //                _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
        //            _total1 = Decimal.Round((((_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per3 * 0.25m)) * 100), 2);
        //            decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
        //            DataRow _drow = _dtsummary.NewRow();
        //            _drow[0] = row.col2.ToString();
        //            _drow[1] = count.ToString();
        //            _drow[2] = "0";
        //            _drow[3] = "0";
        //            _drow[4] = "0";
        //            _drow[5] = _overall.ToString();
        //            _drow[6] = row.col3.ToString();
        //            _dtsummary.Rows.Add(_drow);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
        //    }
        //}
        //private void Summary7_1()
        //{

        //    try
        //    {
        //        _dtsummary = new DataTable();
        //        _dtsummary.Columns.Add("SYS_NAME", typeof(string));
        //        _dtsummary.Columns.Add("QTY", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
        //        _dtsummary.Columns.Add("TOTAL", typeof(string));
        //        _dtsummary.Columns.Add("CODE", typeof(string));
        //        var distinctRows = (from DataRow dRow in _dtresult.Rows
        //                            select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
        //        foreach (var row in distinctRows)
        //        {
        //            decimal _p1 = 0;
        //            decimal _p2 = 0;
        //            decimal _p3 = 0;
        //            decimal _p4 = 0;
        //            decimal _p5 = 0;
        //            decimal _p6 = 0;
        //            decimal _total = 0;
        //            decimal _total1 = 0;
        //            int count = 0;
        //            int qty = 0;
        //            int _cold = 0;
        //            string _s = "";
        //            var _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
        //                          select _data;
        //            foreach (var _row in _result)
        //            {
        //                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
        //                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
        //                _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//pft
        //                _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pwron
        //                _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//fpt
        //                _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//arm
        //                if (IsNumeric(_row["devices2"].ToString()) == true)
        //                    qty += Convert.ToInt32(_row["devices2"].ToString());
        //                if (IsNumeric(_row["test1"].ToString()) == true)
        //                    _cold += Convert.ToInt32(_row["test1"].ToString());
        //                _s = _row[0].ToString();
        //                count += 1;
        //            }
        //            decimal _per1 = 0;
        //            decimal _per2 = 0;
        //            decimal _per3 = 0;
        //            decimal _per4 = 0;
        //            decimal _per5 = 0;
        //            decimal _per6 = 0;
        //            if (_p1 != 0)
        //                _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
        //            if (_p2 != 0)
        //                _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
        //            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), 2);
        //            if (_p3 != 0)
        //                _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
        //            if (_p4 != 0)
        //                _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
        //            if (_p5 != 0)
        //                _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
        //            if (_p6 != 0)
        //                _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
        //            _total1 = Decimal.Round((((_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per3 * 0.25m)) * 100), 2);
        //            decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
        //            DataRow _drow = _dtsummary.NewRow();
        //            _drow[0] = row.col2.ToString();
        //            _drow[1] = count.ToString();
        //            _drow[2] = "0";
        //            _drow[3] = "0";
        //            _drow[4] = "0";
        //            _drow[5] = _overall.ToString();
        //            _drow[6] = row.col3.ToString();
        //            _dtsummary.Rows.Add(_drow);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
        //    }
        //}
        //private void Summary20_1()
        //{

        //    try
        //    {
        //        _dtsummary = new DataTable();
        //        _dtsummary.Columns.Add("SYS_NAME", typeof(string));
        //        _dtsummary.Columns.Add("QTY", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
        //        _dtsummary.Columns.Add("TOTAL", typeof(string));
        //        _dtsummary.Columns.Add("CODE", typeof(string));
        //        var distinctRows = (from DataRow dRow in _dtresult.Rows
        //                            select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
        //        foreach (var row in distinctRows)
        //        {
        //            decimal _p1 = 0;
        //            decimal _p2 = 0;
        //            decimal _p3 = 0;
        //            decimal _p4 = 0;
        //            decimal _p5 = 0;
        //            decimal _p6 = 0;
        //            decimal _p7 = 0;
        //            decimal _total = 0;
        //            decimal _total1 = 0;
        //            int count = 0;
        //            int qty = 0;
        //            int _cold = 0;
        //            string _s = "";
        //            var _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
        //                          select _data;
        //            foreach (var _row in _result)
        //            {
        //                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
        //                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
        //                _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//inst
        //                _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pft
        //                _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//pwron
        //                _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//fpt
        //                _p7 += Convert.ToDecimal(_row["per_com7"].ToString());//arm
        //                _s = _row[0].ToString();
        //                count += 1;
        //            }
        //            decimal _per1 = 0;
        //            decimal _per2 = 0;
        //            decimal _per3 = 0;
        //            decimal _per4 = 0;
        //            decimal _per5 = 0;
        //            decimal _per6 = 0;
        //            decimal _per7 = 0;
        //            if (_p1 != 0)
        //                _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
        //            if (_p2 != 0)
        //                _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
        //            _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)), 2);
        //            if (_p3 != 0)
        //                _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
        //            if (_p4 != 0)
        //                _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
        //            if (_p5 != 0)
        //                _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
        //            if (_p6 != 0)
        //                _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
        //            if (_p7 != 0)
        //                _per7 = Decimal.Round((_p7 / Convert.ToDecimal(count)), 2);
        //            _total1 = Decimal.Round((((_per4 * 0.2m) + (_per5 * 0.2m) + (_per6 * 0.2m) + (_per7 * 0.2m) + (_per3 * 0.2m)) * 100), 2);
        //            decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
        //            DataRow _drow = _dtsummary.NewRow();
        //            _drow[0] = row.col2.ToString();
        //            _drow[1] = count.ToString();
        //            _drow[2] = "0";
        //            _drow[3] = "0";
        //            _drow[4] = "0";
        //            _drow[5] = _overall.ToString();
        //            _drow[6] = row.col3.ToString();
        //            _dtsummary.Rows.Add(_drow);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
        //    }
        //}
        //private void Summary12_1()
        //{

        //    try
        //    {
        //        _dtsummary = new DataTable();
        //        _dtsummary.Columns.Add("SYS_NAME", typeof(string));
        //        _dtsummary.Columns.Add("QTY", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
        //        _dtsummary.Columns.Add("TOTAL", typeof(string));
        //        _dtsummary.Columns.Add("CODE", typeof(string));
        //        var distinctRows = (from DataRow dRow in _dtresult.Rows
        //                            select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
        //        foreach (var row in distinctRows)
        //        {
        //            decimal _p1 = 0;
        //            decimal _p2 = 0;
        //            decimal _p3 = 0;
        //            decimal _p4 = 0;
        //            decimal _p5 = 0;
        //            decimal _p6 = 0;
        //            decimal _total = 0;
        //            decimal _total1 = 0;
        //            int count = 0;
        //            int qty = 0;
        //            int _cold = 0;
        //            string _s = "";
        //            var _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
        //                          select _data;
        //            foreach (var _row in _result)
        //            {
        //                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
        //                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());//inst
        //                _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//pft
        //                _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pwron
        //                _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//fpt
        //                _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//arm
        //                _s = _row[0].ToString();
        //                count += 1;
        //            }
        //            decimal _per1 = 0;
        //            decimal _per2 = 0;
        //            decimal _per3 = 0;
        //            decimal _per4 = 0;
        //            decimal _per5 = 0;
        //            decimal _per6 = 0;
        //            if (_p1 != 0)
        //                _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
        //            _total = Decimal.Round((_per1), 2);
        //            if (_p2 != 0)
        //                _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
        //            if (_p3 != 0)
        //                _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
        //            if (_p4 != 0)
        //                _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
        //            if (_p5 != 0)
        //                _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
        //            if (_p6 != 0)
        //                _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
        //            _total1 = Decimal.Round((((_per4 * 0.2m) + (_per5 * 0.2m) + (_per6 * 0.2m) + (_per2 * 0.2m) + (_per3 * 0.2m)) * 100), 2);
        //            decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
        //            DataRow _drow = _dtsummary.NewRow();
        //            _drow[0] = row.col2.ToString();
        //            _drow[1] = count.ToString();
        //            _drow[2] = "0";
        //            _drow[3] = "0";
        //            _drow[4] = "0";
        //            _drow[5] = _overall.ToString();
        //            _drow[6] = row.col3.ToString();
        //            _dtsummary.Rows.Add(_drow);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
        //    }
        //}
        //private void Summary10_1()
        //{
        //    try
        //    {
        //        _dtsummary = new DataTable();
        //        _dtsummary.Columns.Add("SYS_NAME", typeof(string));
        //        _dtsummary.Columns.Add("QTY", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
        //        _dtsummary.Columns.Add("TOTAL", typeof(string));
        //        _dtsummary.Columns.Add("CODE", typeof(string));
        //        decimal _p1 = 0;
        //        decimal _devices = 0;
        //        decimal _total = 0;
        //        decimal _count = 0;
        //        var _result = from _data in _dtresult.AsEnumerable()
        //                      select _data;
        //        BLL_Dml _objbll = new BLL_Dml();
        //        _database _objdb = new _database();
        //        _objdb.DBName = "DB_" + (string)Session["project"];
        //        _clscassheet _objcas = new _clscassheet();
        //        _objcas.sch = 10;
        //        DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
        //        var TestNames = from _data in _dtnames.AsEnumerable()
        //                        select _data;
        //        foreach (var row in TestNames)
        //        {
        //            _total = 0;
        //            DataRow _drow = _dtsummary.NewRow();
        //            _drow[0] = row[0].ToString();
        //            _devices = 0;
        //            _p1 = 0;
        //            if (row[0].ToString() == "Circuit IR / Continuity Test")
        //            {

        //                _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN"
        //                          select _data;
        //                foreach (var _row in _result)
        //                {
        //                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
        //                    if (IsNumeric(_row["devices2"].ToString()) == true)
        //                        _devices += Convert.ToInt32(_row["devices2"].ToString());
        //                }
        //                _drow[1] = Decimal.Round(_devices).ToString();
        //                _drow[2] = Decimal.Round(_p1).ToString();
        //            }
        //            else if (row[0].ToString() == "FA Device Test")
        //            {
        //                _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN"
        //                          select _data;
        //                foreach (var _row in _result)
        //                {
        //                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
        //                    if (IsNumeric(_row["devices2"].ToString()) == true)
        //                        _devices += Convert.ToInt32(_row["devices2"].ToString());
        //                }
        //                _drow[1] = Decimal.Round(_devices).ToString();
        //                _drow[2] = Decimal.Round(_p1).ToString();
        //            }
        //            else if (row[0].ToString() == "FA Interface Test")
        //            {
        //                _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<string>("Cat") == "FAL"
        //                          select _data;
        //                foreach (var _row in _result)
        //                {
        //                    _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
        //                    if (IsNumeric(_row["devices1"].ToString()) == true)
        //                        _devices += Convert.ToInt32(_row["devices1"].ToString());
        //                    else
        //                        _devices += 0;
        //                }
        //                _drow[1] = Decimal.Round(_devices).ToString();
        //                _drow[2] = Decimal.Round(_p1).ToString();
        //            }
        //            else if (row[0].ToString() == "Voice Evac Speaker Test")
        //            {
        //                _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "ANN"
        //                          select _data;
        //                foreach (var _row in _result)
        //                {
        //                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
        //                    if (IsNumeric(_row["devices2"].ToString()) == true)
        //                        _devices += Convert.ToInt32(_row["devices2"].ToString());
        //                }
        //                _drow[1] = Decimal.Round(_devices).ToString();
        //                _drow[2] = Decimal.Round(_p1).ToString();

        //            }
        //            else if (row[0].ToString() == "Fire Telephone Device Test")
        //            {
        //                _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<string>("Cat") == "FTL"
        //                          select _data;
        //                foreach (var _row in _result)
        //                {
        //                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
        //                    if (IsNumeric(_row["devices2"].ToString()) == true)
        //                        _devices += Convert.ToInt32(_row["devices2"].ToString());
        //                }
        //                _drow[1] = Decimal.Round(_devices).ToString();
        //                _drow[2] = Decimal.Round(_p1).ToString();

        //            }
        //            else if (row[0].ToString() == "Battery Autonomy Test")
        //            {
        //                _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN"
        //                          select _data;
        //                foreach (var _row in _result)
        //                {
        //                    _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
        //                    if (IsNumeric(_row["devices2"].ToString()) == true)
        //                        _devices += Convert.ToInt32(_row["devices2"].ToString());
        //                    //_count += 1;
        //                }
        //                _drow[1] = Decimal.Round(_devices).ToString();
        //                _drow[2] = Decimal.Round(_p1).ToString();

        //            }
        //            else if (row[0].ToString() == "Graphic/ Head End Test")
        //            {
        //                _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN"
        //                          select _data;
        //                foreach (var _row in _result)
        //                {
        //                    _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
        //                    if (IsNumeric(_row["devices2"].ToString()) == true)
        //                        _devices += Convert.ToInt32(_row["devices2"].ToString());
        //                }
        //                _drow[1] = Decimal.Round(_devices).ToString();
        //                _drow[2] = Decimal.Round(_p1).ToString();

        //            }
        //            else
        //            {
        //                _drow[1] = "0";
        //                _drow[2] = "0";
        //            }
        //            if (_drow[1].ToString() != "0")
        //            {
        //                _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
        //            }
        //            else
        //                _total = 0;
        //            _drow[3] = "0";
        //            _drow[4] = "0";
        //            _drow[5] = _total.ToString();
        //            _drow[6] = row[0].ToString();
        //            _dtsummary.Rows.Add(_drow);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
        //    }
        //}
        //private void Summary17_1()
        //{

        //    try
        //    {
        //        _dtsummary = new DataTable();
        //        _dtsummary.Columns.Add("SYS_NAME", typeof(string));
        //        _dtsummary.Columns.Add("QTY", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
        //        _dtsummary.Columns.Add("TOTAL", typeof(string));
        //        _dtsummary.Columns.Add("CODE", typeof(string));
        //        var distinctRows = (from DataRow dRow in _dtresult.Rows
        //                            select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
        //        foreach (var row in distinctRows)
        //        {
        //            decimal _p1 = 0;
        //            decimal _p2 = 0;
        //            decimal _p3 = 0;
        //            decimal _p4 = 0;
        //            decimal _p5 = 0;
        //            decimal _p6 = 0;
        //            decimal _p7 = 0;
        //            decimal _p8 = 0;
        //            decimal _total = 0;
        //            decimal _total1 = 0;
        //            int count = 0;
        //            int qty = 0;
        //            int _cold = 0;
        //            string _s = "";
        //            var _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
        //                          select _data;
        //            foreach (var _row in _result)
        //            {
        //                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
        //                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
        //                _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
        //                _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//inst
        //                _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//pft
        //                _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//pwron
        //                _p7 += Convert.ToDecimal(_row["per_com7"].ToString());//fpt
        //                _p8 += Convert.ToDecimal(_row["per_com8"].ToString());//arm
        //                _s = _row[0].ToString();
        //                count += 1;
        //            }
        //            decimal _per1 = 0;
        //            decimal _per2 = 0;
        //            decimal _per3 = 0;
        //            decimal _per4 = 0;
        //            decimal _per5 = 0;
        //            decimal _per6 = 0;
        //            decimal _per7 = 0;
        //            decimal _per8 = 0;
        //            if (_p1 != 0)
        //                _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
        //            if (_p2 != 0)
        //                _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
        //            _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100, 2);
        //            if (_p3 != 0)
        //                _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
        //            if (_p4 != 0)
        //                _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
        //            if (_p5 != 0)
        //                _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
        //            if (_p6 != 0)
        //                _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
        //            if (_p7 != 0)
        //                _per7 = Decimal.Round((_p7 / Convert.ToDecimal(count)), 2);
        //            if (_p8 != 0)
        //                _per8 = Decimal.Round((_p8 / Convert.ToDecimal(count)), 2);
        //            _total1 = Decimal.Round((((_per4 * 0.2m) + (_per5 * 0.2m) + (_per6 * 0.2m) + (_per7 * 0.2m) + (_per8 * 0.2m)) * 100), 2);
        //            decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
        //            DataRow _drow = _dtsummary.NewRow();
        //            _drow[0] = row.col2.ToString();
        //            _drow[1] = count.ToString();
        //            _drow[2] = "0";
        //            _drow[3] = "0";
        //            _drow[4] = "0";
        //            _drow[5] = _overall.ToString();
        //            _drow[6] = row.col3.ToString();
        //            _dtsummary.Rows.Add(_drow);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
        //    }
        //}
        //private void Summary19_1()
        //{

        //    try
        //    {
        //        _dtsummary = new DataTable();
        //        _dtsummary.Columns.Add("SYS_NAME", typeof(string));
        //        _dtsummary.Columns.Add("QTY", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
        //        _dtsummary.Columns.Add("TOTAL", typeof(string));
        //        _dtsummary.Columns.Add("CODE", typeof(string));
        //        var distinctRows = (from DataRow dRow in _dtresult.Rows
        //                            select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
        //        foreach (var row in distinctRows)
        //        {
        //            decimal _p1 = 0;
        //            decimal _p2 = 0;
        //            decimal _p3 = 0;
        //            decimal _p4 = 0;
        //            decimal _p5 = 0;
        //            decimal _p6 = 0;
        //            decimal _p7 = 0;
        //            int count = 0;
        //            string _s = "";
        //            var _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
        //                          select _data;
        //            foreach (var _row in _result)
        //            {
        //                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
        //                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
        //                _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
        //                _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
        //                _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
        //                _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
        //                _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
        //                _s = _row[0].ToString();
        //                count += 1;
        //            }
        //            decimal _per1 = 0;
        //            decimal _per2 = 0;
        //            if (_p1 != 0)
        //                _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
        //            if (_p2 != 0)
        //                _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);

        //            decimal _overall = Decimal.Round(((_per1 * 0.8m) + (_per2 * 0.2m)));
        //            DataRow _drow = _dtsummary.NewRow();
        //            _drow[0] = row.col2.ToString();
        //            _drow[1] = count.ToString();
        //            _drow[2] = "0";
        //            _drow[3] = "0";
        //            _drow[4] = "0";
        //            _drow[5] = _overall.ToString();
        //            _drow[6] = row.col3.ToString();
        //            _dtsummary.Rows.Add(_drow);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
        //    }
        //}
    }
}
