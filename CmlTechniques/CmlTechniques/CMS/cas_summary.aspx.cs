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
    public partial class cas_summary : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _summary;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                
            //}
        }
        private void Load_Master()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32(lblsch.Text);
            _objcas.prj_code = lblprj.Text;
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
            //var _dv = (DataView)ObjectDataSource1.Select();
            //_dtMaster = _dv.ToTable();
            //var _dv = (DataView)Class1._OBJ_DATA_CAS1.Select();
            //DataTable _dtemp = _dv.ToTable();
            //IEnumerable<DataRow> _result = from _data in _dtemp.AsEnumerable()
            //                               where _data.Field<int>("Cas_Schedule") == Convert.ToInt32(lblsch.Text)
            //                               select _data;
            //if (_result.Any())
            //{
            //    _dtMaster = _result.CopyToDataTable<DataRow>();
            //}
            //else
            //    _dtMaster = null;
        }
        private void Generate_Summary()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsproject _objcls = new _clsproject();
            _objcls.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls, _objdb);
            _objbll.Clear_CassummaryRpt(_objdb);
            if (_dtMaster == null) return;
            if (lblsch.Text == "30")
            {
                Summary30();
                Insert_Summary();
            }
            else if (lblsch.Text == "25" || lblsch.Text == "26" || lblsch.Text == "27")
            {
                Summary25();
                Insert_Summary();
            }
            else if (lblsch.Text == "9")
            {
                Summary9();
                Insert_Summary1();
            }
            else if (lblsch.Text == "21")
            {
                Summary21();
                Insert_Summary1();
            }
            else if (lblsch.Text == "28")
            {
                Summary28();
                Insert_Summary1();
            }
            else if (lblsch.Text == "29")
            {
                Summary29();
                Insert_Summary1();
            }
            else if (lblsch.Text == "8")
            {
                Summary8();
                Insert_Summary1();
            }
            else if (lblsch.Text == "2")
            {
                Summary2();
                Insert_Summary1();
            }
            else if (lblsch.Text == "3")
            {
                Summary2();
                Insert_Summary1();
            }
            else if (lblsch.Text == "6")
            {
                Summary6();
                Insert_Summary1();
            }
            else if (lblsch.Text == "5")
            {
                Summary5();
                Insert_Summary_5();
            }
            else if (lblsch.Text == "4")
            {
                Summary4();
                Insert_Summary1();
            }
            else if (lblsch.Text == "7")
            {
                Summary7();
                Insert_Summary1();
            }
            else if (lblsch.Text == "10")
            {
                Summary10();
                Insert_Summary();
            }
            else if (lblsch.Text == "31")
            {
                Summary31();
                Insert_Summary1();
            }
            else if (lblsch.Text == "20")
            {
                Summary20();
                Insert_Summary1();
            }
            else if (lblsch.Text == "32")
            {
                Summary32();
                Insert_Summary1();
            }
            else if (lblsch.Text == "11")
            {
                Summary11();
                Insert_Summary1();
            }
            else if (lblsch.Text == "14")
            {
                Summary14();
                Insert_Summary1();
            }
            else if (lblsch.Text == "12")
            {
                Summary12();
                Insert_Summary1();
            }
            else if (lblsch.Text == "16")
            {
                Summary16();
                Insert_Summary1();
            }
            else if (lblsch.Text == "17")
            {
                Summary17();
                Insert_Summary1();
            }
            else if (lblsch.Text == "23")
            {
                Summary23();
                Insert_Summary1();
            }
            //else if (lblsch.Text == "24")
            //{
            //    Summary24();
            //    Insert_Summary1();
            //}
            else if (lblsch.Text == "34")
            {
                Summary34();
                Insert_Summary1();
            }
            else if (lblsch.Text == "35")
            {
                Summary34();
                Insert_Summary1();
            }
            else if (lblsch.Text == "36")
            {
                Summary36();
                Insert_Summary1();
            }
            else if (lblsch.Text == "33")
            {
                Summary34();
                Insert_Summary1();
            }
            else if (lblsch.Text == "37")
            {
                Summary37();
                Insert_Summary1();
            }
        }
        //---- Mechanical--------
        private void Summary30()
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
                _dtsummary.Columns.Add("IDC", typeof(string));
                _dtsummary.Columns.Add("DLT", typeof(string));

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
                    decimal _total = 0;
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
                        _p4 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _p5 += Convert.ToDecimal(_row["per_com6"].ToString());
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
                    _drow[7] = Decimal.Round(_p4).ToString();
                    _drow[8] = Decimal.Round(_p5).ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                _summary = _dtsummary;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary25()
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
                _dtsummary.Columns.Add("IDC", typeof(string));
                _dtsummary.Columns.Add("DLT", typeof(string));
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
                    decimal _total = 0;
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
                    _drow[7] = Decimal.Round(_p4).ToString();
                    _drow[8] = "0";
                    _dtsummary.Rows.Add(_drow);
                }
                _summary = _dtsummary;
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
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        count += 1;
                    }
                    if (_p1 != 0)
                        _total = Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "-1";
                    _drow[3] = Decimal.Round(_p1).ToString();
                    _drow[4] = Decimal.Round(_p2).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                _summary = _dtsummary;
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
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                _summary = _dtsummary;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary28()
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
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _total = 0;
                    int count = 0;
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100)
                            _p4 += 1;
                        if (Convert.ToDecimal(_row["per_com2"].ToString()) == 100)
                            _p5 += 1;
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    if (_p1 != 0)
                        _per1 = _p1 / Convert.ToDecimal(count);
                    if (_p2 != 0)
                        _per2 = _p2 / Convert.ToDecimal(count);
                    //if (_p3 != 0)
                    //    _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count), 2);
                    _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p4).ToString();
                    _drow[3] = Decimal.Round(_p5).ToString();
                    _drow[4] = Decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                _summary = _dtsummary;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary29()
        {
            try
            {
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                //_dtsummary.Columns.Add("TESTED", typeof(string));
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
                    decimal _p2 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        if (IsNumeric(_row["devices1"].ToString()) == true)
                            count += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (count > 0)
                        _total = Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "-1";
                    _drow[3] = Decimal.Round(_p1).ToString();
                    _drow[4] = Decimal.Round(_p2).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                _summary = _dtsummary;
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
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com5"].ToString());
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
                _summary = _dtsummary;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        //------ Elactrical --------
        private void Summary2()
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
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _total = 0;
                    int count = 0;
                    int _count1 = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100)
                            _p1 += 1;
                        //_p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com3"].ToString());
                        //_p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        if (_row["test14"].ToString().ToUpper() != "N/A")
                        {
                            _p4 += Convert.ToDecimal(_row["per_com2"].ToString());
                            _count1 += 1;
                        }
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    if (count != 0)
                        _per1 = (_p3 / Convert.ToDecimal(count));
                    _per2 = (_p4) / Convert.ToDecimal(_count1);
                    _total = Decimal.Round(_per1 * 0.6m + _per2 * 0.4m);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = decimal.Round(_p1);
                    _drow[3] = decimal.Round(_p4/100);
                    _drow[4] = decimal.Round(_p2);
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                _summary = _dtsummary;
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
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100)
                            _p1 += 1;
                        //_p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    if (count != 0)
                        _per1 = (_p3 / Convert.ToDecimal(count));
                    _per2=(_p4*100)/Convert.ToDecimal(count);
                    _total = Decimal.Round(_per1 * 0.6m + _per2 * 0.4m);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = decimal.Round(_p1);
                    _drow[3] = decimal.Round(_p4);
                    _drow[4] = decimal.Round(_p2);
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                _summary = _dtsummary;
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
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100 && Convert.ToDecimal(_row["per_com2"].ToString()) == 100)
                            _p1 += 1;
                        if (Convert.ToDecimal(_row["per_com3"].ToString()) == 100 && Convert.ToDecimal(_row["per_com4"].ToString()) == 100)
                            _p2 += 1;
                        _p3 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    if (_p1 != 0)
                        _per1 = (_p1 / Convert.ToDecimal(count));
                    if (_p2 != 0)
                        _per2 = (_p2 / Convert.ToDecimal(count));

                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    if (row.col3.ToString() == "LP")
                    {
                        _drow[2] = decimal.Round(_p2);
                        _total = Decimal.Round((_per2 * 100));
                    }
                    else
                    {
                        _drow[2] = decimal.Round(_p1);
                        _total = Decimal.Round((_per1 * 100));
                    }

                    _drow[3] = "-1";
                    _drow[4] = decimal.Round(_p3);
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                _summary = _dtsummary;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary5()
        {
            try
            {
                decimal _circuits = 0;
                decimal _tlive = 0;
                decimal _tcold = 0;
                decimal _twit = 0;
                decimal _panel = 0;
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                _dtsummary.Columns.Add("PANEL", typeof(string));
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
                    decimal _circuit = 0;
                    int count = 0;
                    string _s = "";
                    decimal _na1 = 0;
                    decimal _na2 = 0;
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100)
                            _p1 += 1;
                        //if (Convert.ToDecimal(_row["per_com2"].ToString()) == 100)
                        //    _p2 += 1;
                        //_p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        //if (Convert.ToDecimal(_row["per_com3"].ToString()) == 100)
                        //    _p3 += 1;
                        //_p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        if (row.col3.ToString() == "DB")
                        {
                            _circuits += Convert.ToDecimal(_row["devices1"].ToString());
                            if (IsNumeric(_row["tested1"].ToString()) == true)
                                _tcold += Convert.ToInt32(_row["tested1"].ToString());
                            if (IsNumeric(_row["tested2"].ToString()) == true)
                                _tlive += Convert.ToInt32(_row["tested2"].ToString());
                            _twit += Convert.ToInt32(_row["per_com4"].ToString());
                        }
                        _circuit += Convert.ToDecimal(_row["devices1"].ToString());
                        decimal _device = 0;
                        _device = Convert.ToDecimal(_row["devices1"].ToString());
                        if (_row["tested1"].ToString().Length > 0 && IsNumeric(_row["tested1"].ToString()) == false) _na1 += _device;
                        if (_row["tested2"].ToString().Length > 0 && IsNumeric(_row["tested2"].ToString()) == false) _na2 += _device;
                        _p5 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;

                    if (count != 0)
                        _per1 = (_p5 / Convert.ToDecimal(count));
                    //if (_circuits != 0)
                    //{
                    if (_na1 >= _circuit)
                        _per2 = -1;
                    else
                    {
                        if (_circuit > 0)
                            _per2 = (_p2 / Convert.ToDecimal(_circuit - _na1)) * 100;
                    }
                    //}
                    //if (_circuits != 0)
                    //{
                    if (_na2 >= _circuit)
                        _per3 = -1;
                    else
                    {
                        if (_circuit > 0)
                            _per3 = (_p3 / Convert.ToDecimal(_circuit - _na2)) * 100;
                    }
                    //}
                    //_tlive += _p2;
                    //_tcold += _p3;
                    //_twit += _p4;
                    _panel += _p1;
                    if (row.col3.ToString() == "MDB")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m)), MidpointRounding.AwayFromZero);
                    }
                    else if (row.col3.ToString() == "PFC")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    else if (row.col3.ToString() == "HCP")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    else if (row.col3.ToString() == "DB")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                        {
                            _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                            _p1 = -1;
                        }
                    }
                    else if (row.col3.ToString() == "LCP")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                        {
                            _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                            _p1 = -1;
                        }
                    }
                    else if (row.col3.ToString() == "UPS")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                        {
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                        }
                    }
                    else if (row.col3.ToString() == "EFP")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                        {
                            _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                            _p1 = -1;
                        }
                    }
                    else if (row.col3.ToString() == "SMDB")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    else if (row.col3.ToString() == "MCC")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    else if (row.col3.ToString() == "ATS")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }

                    else if (row.col3.ToString() == "BDT")
                    {
                        //_p3 = -1;
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    else if (row.col3.ToString() == "GPU")
                    {
                        //_p3 = -1;
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.8m) + (_per3 * 0.2m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.8m) + (_per2 * 0.2m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.6m) + (_per2 * 0.4m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    if (_total < 0) _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = decimal.Round(_p2).ToString();
                    _drow[3] = decimal.Round(_p3).ToString();
                    _drow[4] = decimal.Round(_p4).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _drow[7] = decimal.Round(_p1).ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                if (_circuits > 0)
                {
                    decimal _totalcold = _tcold / _circuits * 100;
                    decimal _totallive = _tlive / _circuits * 100;
                    decimal _ocircuit = Decimal.Round((_totalcold * 0.6m) + (_totallive * 0.4m), MidpointRounding.AwayFromZero);
                    DataRow _drow1 = _dtsummary.NewRow();
                    _drow1[0] = "Distribution Board Circuits";
                    _drow1[1] = _circuits.ToString();
                    _drow1[2] = decimal.Round(_tcold).ToString();
                    _drow1[3] = decimal.Round(_tlive).ToString();
                    _drow1[4] = decimal.Round(_twit).ToString();
                    _drow1[5] = _ocircuit.ToString();
                    _drow1[6] = "Circuits";
                    _drow1[7] = "-1";
                    //_drow1[7] = decimal.Round(_acce).ToString();
                    _dtsummary.Rows.Add(_drow1);
                }
                _summary = _dtsummary;
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
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100)
                            _p1 += 1;
                        if (Convert.ToDecimal(_row["per_com3"].ToString()) == 100)
                            _p2 += 1;
                        //_p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                        //_p2 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4+= Convert.ToDecimal(_row["per_com4"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    if (_p1 != 0)
                        _per1 = (_p1 / Convert.ToDecimal(count)) * 100;
                    if (_p2 != 0)
                        _per2 = (_p2 / Convert.ToDecimal(count)) * 100;
                    if (_p3 != 0)
                        _per3 = (_p3 / Convert.ToDecimal(count));
                    _total = Decimal.Round((_per1 * 0.7m) + (_per2 * 0.3m));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = decimal.Round(_p1).ToString();
                    _drow[3] = decimal.Round(_p2).ToString();
                    _drow[4] = decimal.Round(_p4).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                _summary = _dtsummary;
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
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                
                decimal _total = 0;
                decimal _tested = 0;
                
                decimal _emg = 0;
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _qty = 0;
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _p8 = 0;
                    decimal _test = 0;
                    decimal _circuit = 0;
                    int count = 0;
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        if (row.col3.ToString() == "CIR")
                        {
                            if (IsNumeric(_row["test1"].ToString()) == true)
                            {
                                _test += Convert.ToDecimal(_row["test1"].ToString());
                            }
                            count += Convert.ToInt32(_row["devices1"].ToString());
                            _circuit += Convert.ToInt32(_row["devices2"].ToString());
                            _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                            _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                            _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                            _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                            _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                        }

                        _p8 += Convert.ToDecimal(_row["per_com8"].ToString());

                        _qty += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    if (row.col3.ToString() == "CIR")
                    {
                        if (_circuit > 0)
                            _per1 = _test / _circuit;
                        if (count > 0)
                        {
                            _per3 = ((_p2 + _p3 + _p4 + _p5 + _p6 + _p7) / 6);
                            _per2 = (((_p2 + _p3 + _p4 + _p5 + _p6 + _p7) / count) / 6) * 100;
                        }
                    }
                    else
                    {
                        if (_qty > 0)
                        {
                            _per1 = _p1 / _qty;
                            _per2 = _p2 / _qty;
                        }
                    }
                    _tested += _per1;
                    _total = decimal.Round((_per1 * 0.2m + _per2 * 0.8m));
                    _emg += count;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = _qty.ToString();
                    if (row.col3.ToString() == "CIR")
                    {
                        _drow[2] = decimal.Round(_test).ToString();
                        _drow[3] = decimal.Round(_per3).ToString();
                    }
                    else
                    {
                        _drow[2] = decimal.Round(_p1 / 100).ToString();
                        _drow[3] = decimal.Round(_p2 / 100).ToString();
                    }
                    //_drow[2] = decimal.Round(_p1).ToString();
                    //_drow[3] = decimal.Round(_per2).ToString();
                    _drow[4] = decimal.Round(_p8).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                //if (_emg != 0)
                //    _total = decimal.Round((_tested / _emg) * 100);
                //DataRow _drow1 = _dtsummary.NewRow();
                //_drow1[0] = "Total No. of Emergency Lights";
                //_drow1[1] = decimal.Round(_emg).ToString();
                //_drow1[2] = decimal.Round(_tested).ToString();
                //_drow1[3] = "0";
                //_drow1[4] = "0";
                //_drow1[5] = _total.ToString(); 
                //_drow1[6] = "1";
                //_dtsummary.Rows.Add(_drow1);
                _summary = _dtsummary;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary37()
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
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100)
                            _p1 += 1;
                        _p2 += Convert.ToDecimal(_row["per_com7"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    if (count != 0)
                        _per1 = (_p3 / Convert.ToDecimal(count));
                    _total = Decimal.Round(_per1);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "-1";
                    _drow[3] = decimal.Round(_p1).ToString();
                    _drow[4] = decimal.Round(_p2).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                _summary = _dtsummary;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        //----- ELV-------------------
        
        private void Summary10()
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
                _dtsummary.Columns.Add("IDC", typeof(string));
                _dtsummary.Columns.Add("DLT", typeof(string));


                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                decimal _count = 0;
                var _result = from _data in _dtMaster.AsEnumerable()
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
                    int idx = 0;
                    decimal _qty = 0;
                    decimal _weighting = 0;
                    if (row[0].ToString() == "Circuit IR Test")
                    {

                        _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTC"
                                  select _data;
                        decimal _intrface = 0;
                        decimal _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[3] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[3].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.15m;
                    }
                    else if (row[0].ToString() == "Device/Address Test")
                    {
                        _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTC"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[3] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[3].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.6m;
                    }
                    else if (row[0].ToString() == "Sound Level Test")
                    {
                        _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<string>("Cat") == "NAC"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[3] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[3].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.02m;
                    }
                    else if (row[0].ToString() == "Interface Test")
                    {
                        _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAL"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                            if (IsNumeric(_row["devices1"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices1"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[3] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[3].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.13m;
                    }

                    else if (row[0].ToString() == "Battery Autonomy Test")
                    {

                        _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                            _panel += 1;
                        }
                        _drow[1] = Decimal.Round(_panel).ToString();
                        _drow[3] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[3].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.03m;

                    }
                    else if (row[0].ToString() == "Graphic Test")
                    {

                        _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                            _panel += 1;

                        }
                        _drow[1] = Decimal.Round(_panel).ToString();
                        _drow[3] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[3].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.02m;
                    }
                    else if (row[0].ToString() == "Cause Effect Test")
                    {

                        _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                            _panel += 1;
                        }
                        _drow[1] = Decimal.Round(_panel).ToString();
                        _drow[3] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[3].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.05m;

                    }
                    else
                    {
                        _drow[1] = "0";
                        _drow[3] = "0";
                    }

                    _drow[2] = "-1";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = "0";
                    _drow[7] = decimal.Round(_weighting,0).ToString();
                    _drow[8] = "0";
                    if (Convert.ToDecimal(_drow[1].ToString()) > 0)
                        _dtsummary.Rows.Add(_drow);
                }
                
                _summary = _dtsummary;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary31()
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


                decimal _total = 0;
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
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
                    decimal _qty = 0;
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        //_p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        //_p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        //_p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        //_p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                        count += Convert.ToInt32(_row["devices2"].ToString());
                        //_interface += Convert.ToInt32(_row["devices1"].ToString());
                        //if (IsNumeric(_row["test2"].ToString()) == true)
                        //    _device_tested += Convert.ToDecimal(_row["test2"].ToString());
                        //if (IsNumeric(_row["test4"].ToString()) == true)
                        //    _interface_tested += Convert.ToDecimal(_row["test4"].ToString());
                        _qty += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    if (_p1 != 0)
                    {
                        if (row.col3.ToString() == "VAC")
                            _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
                        else
                            _per1 = Decimal.Round(_p1 / Convert.ToDecimal(_qty), 2);
                    }
                    if (_p2 != 0)
                    {
                        if (row.col3.ToString() == "VAC")
                            _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
                        else
                            _per2 = Decimal.Round(_p2 / Convert.ToDecimal(_qty), 2);
                    }
                    _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    if (row.col3.ToString() == "VAC")
                        _drow[1] = count.ToString();
                    else
                        _drow[1] = _qty.ToString();
                    _drow[2] = decimal.Round(_p1).ToString();
                    _drow[3] = decimal.Round(_p2).ToString();
                    _drow[4] = decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }

                _summary = _dtsummary;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary20_1()
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
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                _summary = _dtsummary;
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
                DataTable _dtsummary = new DataTable();
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
                decimal _total = 0;
                decimal _points = 0;
                decimal _tested1 = 0;
                decimal _tested2 = 0;
                decimal _tested3 = 0;

                decimal _qty1 = 0;
                decimal _qty2 = 0;
                decimal _qty3 = 0;
                decimal _qty4 = 0;
                decimal _qty5 = 0;
                decimal _qty6 = 0;
                var _result = from _data in _dtMaster.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    if (_row["test1"].ToString() != "N/A")
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _qty1 += Convert.ToDecimal(_row["devices3"].ToString());
                    }
                    if (_row["test2"].ToString() != "N/A")
                    {
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _qty2 += Convert.ToDecimal(_row["devices3"].ToString());
                    }
                    if (_row["test3"].ToString() != "N/A")
                    {
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _qty3 += Convert.ToDecimal(_row["devices2"].ToString());
                    }
                    if (_row["test4"].ToString() != "N/A")
                    {
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        if (IsNumeric(_row["des"].ToString()) == true)
                            _qty4 += Convert.ToDecimal(_row["des"].ToString());
                    }
                    if (_row["test5"].ToString() != "N/A")
                    {
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _qty5 += Convert.ToDecimal(_row["devices3"].ToString());
                    }
                    if (_row["test6"].ToString() != "N/A")
                    {
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        _qty6 += Convert.ToDecimal(_row["devices1"].ToString());
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
                    decimal _weighting = 0;
                    if (row[0].ToString() == "Cable Continuity/IR Test")
                    {
                        _drow[3] = Decimal.Round(_p1).ToString(); _drow[1] = Decimal.Round(_qty1);
                        if (_qty1 > 0)
                            _total = (_p1 / _qty1) * 100;
                        _weighting = _total * 0.2m;
                    }
                    else if (row[0].ToString() == "Points to Points Test")
                    {
                        _drow[3] = Decimal.Round(_p2).ToString();
                        _drow[1] = Decimal.Round(_qty2);
                        if (_qty2 > 0)
                            _total = (_p2 / _qty2) * 100;
                        _weighting = _total * 0.33m;
                    }

                    else if (row[0].ToString() == "Calibration/Functional Test")
                    {
                        _drow[3] = Decimal.Round(_p3).ToString(); _drow[1] = Decimal.Round(_qty3);
                        if (_qty3 > 0)
                            _total = (_p3 / _qty3) * 100;
                        _weighting = _total * 0.33m;
                    }
                    else if (row[0].ToString() == "Sequence of Operation")
                    {
                        _drow[3] = Decimal.Round(_p4).ToString(); _drow[1] = Decimal.Round(_qty4);
                        if (_qty4 > 0)
                            _total = (_p4 / _qty4) * 100;
                        _weighting = _total * 0.1m;
                    }
                    else if (row[0].ToString() == "Graphic/Head End Test")
                    {
                        _drow[3] = Decimal.Round(_p5).ToString(); _drow[1] = Decimal.Round(_qty5);
                        if (_qty5 > 0)
                            _total = (_p5 / _qty5) * 100;
                        _weighting = _total * 0.02m;
                    }
                    else if (row[0].ToString() == "Loop Tuning")
                    {
                        _drow[3] = Decimal.Round(_p6).ToString(); _drow[1] = Decimal.Round(_qty6);
                        if (_qty6 > 0)
                            _total = (_p6 / _qty6) * 100;
                        _weighting = _total * 0.02m;
                    }
                    //else if (row[0].ToString() == "Pc Head End Test") _drow[2] = decimal.Round(_p7).ToString();
                    //if (_drow[2].ToString() != "0")
                    //    _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[2] = "-1";
                    _drow[4] = "0";
                    _drow[5] = decimal.Round(_weighting).ToString();
                    _drow[6] = "";
                    _dtsummary.Rows.Add(_drow);
                }

                _summary = _dtsummary;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
  private void Summary32()
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
                decimal _total = 0;
                decimal _points = 0;
               
                decimal _tested1 = 0;
                decimal _tested2 = 0;
                decimal _tested3 = 0;




                var distinctRows = (from DataRow dRow in _dtMaster.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;

                    int count = 0;
                    decimal _qty = 0;
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100)
                            _p4 += 1;
                        if (Convert.ToDecimal(_row["per_com2"].ToString()) == 100)
                            _p5 += 1;
                        //_p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        //_p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        //_p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        count += Convert.ToInt32(_row["devices3"].ToString());
                        _qty += 1;


                        if (IsNumeric(_row["test1"].ToString()) && IsNumeric(_row["test2"].ToString()))
                        {
                            _tested1 += ((Convert.ToDecimal(_row["test1"].ToString()) + Convert.ToDecimal(_row["test2"].ToString())) / 2 );

                        }


                       
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    if (_p1 > 0)
                    {
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(_qty), 2);
                    }
                    else
                        _per1 = -1;

                    if (_p2 >= 0)
                    {
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(_qty), 2);
                    }
                    else
                        _per2 = -1;


                    if (_per1 != -1 && _per2 != -1)
                    {
                        _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)), MidpointRounding.AwayFromZero);
                    }
                    else if (_per1 != -1 && _per2 == -1)
                    {
                        _total = Decimal.Round(_per1, MidpointRounding.AwayFromZero);
                    }
                    else if (_per1 == -1 && _per2 != -1)
                    {
                        _total = Decimal.Round(_per2, MidpointRounding.AwayFromZero);

                    }


                    _points += count;


                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = _qty.ToString();
                    _drow[2] = decimal.Round(_p4).ToString();
                    _drow[3] = decimal.Round(_p5).ToString();
                    _drow[4] = decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }

                if (_points != 0)

                    if (_tested1 >0 && _tested2 >0)
                    {
                        _total = Decimal.Round((((_tested1 * 0.2m) + (_tested2 * 0.8m) / _points) * 100), MidpointRounding.AwayFromZero);
                    }
                    else if (_tested1 >0 && _tested2 <= 0)
                    {
                        _total = Decimal.Round(((_tested1 / _points) * 100), MidpointRounding.AwayFromZero);
                    }
                    else if (_tested1 <= 0 && _tested2 >0)
                    {
                        _total = Decimal.Round(((_tested2 / _points) * 100), MidpointRounding.AwayFromZero);
                    }


                DataRow _drow1 = _dtsummary.NewRow();
                if (lblsch.Text == "20")
                    _drow1[0] = "BMS Points";
                else
                    _drow1[0] = "Points";
                _drow1[1] = decimal.Round(_points).ToString();
                _drow1[2] = decimal.Round(_tested1).ToString();
                _drow1[3] = decimal.Round(_tested2).ToString();
                _drow1[4] = decimal.Round(_tested3).ToString();
                _drow1[5] = _total.ToString();
                _drow1[6] = "Points";
                _dtsummary.Rows.Add(_drow1);

                _summary = _dtsummary;

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
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));


                decimal _total = 0;
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
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
                    decimal _circuit = 0;
                    decimal _qty = 0;
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        //_p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        //_p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                        count += Convert.ToInt32(_row["devices1"].ToString());
                        _circuit += Convert.ToInt32(_row["devices2"].ToString());
                        //_interface += Convert.ToInt32(_row["devices1"].ToString());
                        //if (IsNumeric(_row["test2"].ToString()) == true)
                        //    _device_tested += Convert.ToDecimal(_row["test2"].ToString());
                        //if (IsNumeric(_row["test4"].ToString()) == true)
                        //    _interface_tested += Convert.ToDecimal(_row["test4"].ToString());
                        _qty += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = (_p4 + _p2 + _p3) / 3;
                    if (_circuit > 0)
                    {
                        _per1 = _p1 / _circuit;
                    }
                    if (count > 0)
                    {
                        _per2 = _per3 / Convert.ToDecimal(count);
                    }
                    _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = _qty.ToString();
                    _drow[2] = decimal.Round(_p1).ToString();
                    _drow[3] = decimal.Round(_per3).ToString();
                    _drow[4] = decimal.Round(_p5).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }

                _summary = _dtsummary;
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
                DataTable _dtsummary = new DataTable();
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
                _summary = _dtsummary;
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
                decimal _total = 0;
                decimal _idf = 0;
                decimal _mdf = 0;
                decimal _idft = 0;
                decimal _mdft = 0;
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
                    decimal _p2 = 0;
                    decimal _qty = 0;
                    decimal _points = 0;
                    string _test = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if(IsNumeric(_row["test1"].ToString())==true)
                            _p1 += Convert.ToDecimal(_row["test1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _points += Convert.ToDecimal(_row["devices1"].ToString());
                        _qty += 1;
                    }

                    if (_points != 0)
                        _total = Decimal.Round((_p1 / _points) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = _points.ToString();
                    _drow[2] = "-1";
                    _drow[3] = Decimal.Round(_p1).ToString();
                    _drow[4] = Decimal.Round(_p2).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                //if (_idf != 0)
                //    _total = Decimal.Round((_idft / _idf) * 100);
                //DataRow _drow1 = _dtsummary.NewRow();
                //_drow1[0] = "Outlets";
                //_drow1[1] = Decimal.Round(_idf).ToString();
                //_drow1[2] = Decimal.Round(_idft).ToString();
                //_drow1[3] = "0";
                //_drow1[4] = "0";
                //_drow1[5] = _total.ToString();
                //_drow1[6] = "1";
                //_dtsummary.Rows.Add(_drow1);
                //if (_mdf != 0)
                //    _total = Decimal.Round((_mdft / _mdf) * 100);
                //DataRow _drow2 = _dtsummary.NewRow();
                //_drow2[0] = "Fibre Pairs";
                //_drow2[1] = Decimal.Round(_mdf).ToString();
                //_drow2[2] = Decimal.Round(_mdft).ToString();
                //_drow2[3] = "0";
                //_drow2[4] = "0";
                //_drow2[5] = _total.ToString();
                //_drow2[6] = "1";
                //_dtsummary.Rows.Add(_drow2);
                _summary = _dtsummary;
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
                DataTable _dtsummary = new DataTable();
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
                _summary = _dtsummary;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        //----------- Public Health--------------
        private void Summary17()
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
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com5"].ToString());
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
                _summary = _dtsummary;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        //-------- Miscelleneous----------
        private void Summary23()
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

                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());

                    _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                    if (_row["test1"].ToString().ToUpper() != "N/A") _qty1 += 1;
                    if (_row["Cat"].ToString() == "LIFT")
                    {
                        if (_row["test3"].ToString().ToUpper() != "N/A") _qty3 += 1;
                        if (_row["test5"].ToString().ToUpper() != "N/A") _qty5 += 1;
                        if (_row["test6"].ToString().ToUpper() != "N/A") _qty6 += 1;
                        if (_row["test7"].ToString().ToUpper() != "N/A") _qty7 += 1;
                        if (_row["test4"].ToString().ToUpper() != "N/A") _qty4 += 1;
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    }
                    else if (_row["Cat"].ToString() == "ESC")
                    {
                        if (_row["test3"].ToString().ToUpper() != "N/A") _qty3 += 1;
                        if (_row["test5"].ToString().ToUpper() != "N/A") _qty5 += 1;
                        if (_row["test6"].ToString().ToUpper() != "N/A") _qty6 += 1;
                        if (_row["test7"].ToString().ToUpper() != "N/A") _qty7 += 1;
                    }
                    else if (_row["Cat"].ToString() == "BMU")
                    {
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
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
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    if (row[0].ToString() == "Tested & Comm.") { _drow[3] = Decimal.Round(_p1).ToString(); _drow[1] = Decimal.Round(_qty1); }
                    else if (row[0].ToString() == "3rd Party Inspected") { _drow[3] = Decimal.Round(_p2).ToString(); _drow[1] = Decimal.Round(_qty2); }
                    else if (row[0].ToString() == "Emergency Lighting") { _drow[3] = Decimal.Round(_p3).ToString(); _drow[1] = Decimal.Round(_qty3); }
                    else if (row[0].ToString() == "Power Failure Mode") { _drow[3] = Decimal.Round(_p4).ToString(); _drow[1] = Decimal.Round(_qty4); }
                    else if (row[0].ToString() == "Lift Monitoring System") { _drow[3] = Decimal.Round(_p5).ToString(); _drow[1] = Decimal.Round(_qty5); }
                    else if (row[0].ToString() == "Intercom") { _drow[3] = Decimal.Round(_p6).ToString(); _drow[1] = Decimal.Round(_qty6); }
                    else if (row[0].ToString() == "BMS/ Fire Alarm Interface") { _drow[3] = Decimal.Round(_p7).ToString(); _drow[1] = Decimal.Round(_qty7); }
                    if (_drow[1].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[3].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[2] = "-1";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                _summary = _dtsummary;
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
                _summary = _dtsummary;
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
                int _count = 0;
                decimal _iface = 0;
                decimal _dcomp = 0;
                decimal _snoff = 0;
                decimal _total = 0;
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
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
                DataRow _drow = _dtsummary.NewRow();
                _drow[0] = "";
                _drow[1] = _count.ToString();
                _drow[2] = _iface.ToString();
                _drow[3] = _dcomp.ToString();
                _drow[4] = _snoff.ToString();
                _drow[5] = _total.ToString();
                _drow[6] = "";
                _dtsummary.Rows.Add(_drow);
                _summary = _dtsummary;
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
                _summary = _dtsummary;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary36()
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
                    decimal _p2 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com3"].ToString());
                        count += 1;
                    }
                    if (count != 0)
                        _total = Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "-1";
                    _drow[3] = decimal.Round(_p1).ToString();
                    _drow[4] = decimal.Round(_p2).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                _summary = _dtsummary;
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

                _summary = _dtsummary;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
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
        private void Insert_Summary()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clscassheet _objcls = new _clscassheet();
            _objbll.Clear_CassummaryRpt(_objdb);
            if (_summary!=null)
            {
                var _result = from _data in _summary.AsEnumerable()
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
                    _objcls.quantity = Convert.ToInt32(row["QTY"].ToString());
                    _objcls.compl1 = Convert.ToInt32(row["IDC"].ToString());
                    _objcls.compl2 = Convert.ToInt32(row["DLT"].ToString());
                    _objbll.Generate_CASSummary_PKG_RPT_ASAO(_objcls, _objdb);
                    //count += 1;
                }
            }
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + count.ToString() + "');", true);
        }
        private void Insert_Summary1()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clscassheet _objcls = new _clscassheet();
            _objbll.Clear_CassummaryRpt(_objdb);
            if (_summary!=null)
            {
                var _result = from _data in _summary.AsEnumerable()
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
                    _objcls.quantity = Convert.ToInt32(row["QTY"].ToString());
                    _objbll.Generate_CASSummary_PKG_RPT(_objcls, _objdb);
                    //count += 1;
                }
            }
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + count.ToString() + "');", true);
        }
        private void Insert_Summary_5()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clscassheet _objcls = new _clscassheet();
            _objbll.Clear_CassummaryRpt(_objdb);
            if (_summary != null)
            {
                var _result = from _data in _summary.AsEnumerable()
                              select _data;
                //int count = 0;
                foreach (var row in _result)
                {
                    _objcls.sys_mon = row["SYS_NAME"].ToString();
                    _objcls.qty = row["PANEL"].ToString();
                    _objcls.per_com1 = Convert.ToDecimal(row["PER_COMPLETED"].ToString());
                    _objcls.per_com2 = Convert.ToDecimal(row["PER_COMPLETED1"].ToString());
                    _objcls.per_com3 = Convert.ToDecimal(row["PER_COMPLETED2"].ToString());
                    _objcls.total = Convert.ToDecimal(row["TOTAL"].ToString());
                    _objcls.cate = row["CODE"].ToString();
                    _objcls.quantity = Convert.ToInt32(row["QTY"].ToString());
                    _objbll.Generate_CASSummary_PKG_RPT(_objcls, _objdb);
                    //count += 1;
                }
            }
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + count.ToString() + "');", true);
        }
        private void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["filter"] = "no";
                //Session["zone"] = "All";
                //Session["flvl"] = "All";
                //Session["cat"] = "All";
                //Session["fed"] = "All";
                //Session["loc"] = "All";
               string _prm = Request.QueryString[0].ToString();
                //string _prm = "30_PASAO";
                lblsch.Text = _prm.Substring(0, _prm.IndexOf("_P"));
                lblprj.Text = _prm.Substring(_prm.IndexOf("_P") + 2);
                Load_Master();
                Generate_Summary();
                Generate_Reports();
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
            if (lblsch.Text == "30" || lblsch.Text == "25" || lblsch.Text == "26" || lblsch.Text == "27" || lblsch.Text == "9" || lblsch.Text == "28" || lblsch.Text == "29" || lblsch.Text == "10" || lblsch.Text == "31" || lblsch.Text == "20" || lblsch.Text == "32" || lblsch.Text == "11" || lblsch.Text == "12" || lblsch.Text == "17" || lblsch.Text == "23" || lblsch.Text == "36" || lblsch.Text == "8")
                cryRpt.Load(Server.MapPath("cas_sum.rpt"));
            //else if (lblsch.Text == "25" || lblsch.Text == "26" || lblsch.Text == "27")
            //    cryRpt.Load(Server.MapPath("cas_sum_1.rpt"));
            //else if (lblsch.Text == "9")
            //    cryRpt.Load(Server.MapPath("cas_sum_2.rpt"));
            //else if (lblsch.Text == "21")
            //    cryRpt.Load(Server.MapPath("cas_sum_3.rpt"));
            //else if (lblsch.Text == "11" || lblsch.Text == "14" || lblsch.Text == "16" || lblsch.Text == "24" || lblsch.Text == "34" || lblsch.Text == "35" || lblsch.Text == "36" || lblsch.Text == "33")
            //    cryRpt.Load(Server.MapPath("cas_sum_4.rpt"));
            else if (lblsch.Text == "5")
                cryRpt.Load(Server.MapPath("cas_sum_el5.rpt"));
            else if (lblsch.Text == "4")
                cryRpt.Load(Server.MapPath("cas_sum_el.rpt"));
            else if (lblsch.Text == "2" || lblsch.Text == "3" || lblsch.Text == "6" || lblsch.Text == "5" || lblsch.Text == "7" || lblsch.Text == "37")
                cryRpt.Load(Server.MapPath("cas_sum_el.rpt"));
            else if (lblsch.Text == "33" || lblsch.Text == "34" || lblsch.Text == "35")
                cryRpt.Load(Server.MapPath("cas_sum_ad.rpt"));
            //else if (lblsch.Text == "7"  || lblsch.Text == "31" || lblsch.Text == "20" || lblsch.Text == "32" || lblsch.Text == "12" || lblsch.Text == "23")
            //    cryRpt.Load(Server.MapPath("cas_sum_7.rpt"));
            //else if (lblsch.Text == "37")
            //    cryRpt.Load(Server.MapPath("cas_sum_e37.rpt"));
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
            //SelectionFormula(cryRpt, (string)Session["zone"], (string)Session["cat"], (string)Session["flvl"], (string)Session["fed"]);
            //string _graph = "Summary - " + drtype.SelectedItem.Text;
            //if ((string)Session["zone"] == null) Session["zone"] = "All";
            //if ((string)Session["flvl"] == null) Session["flvl"] = "All";
            //if ((string)Session["cat"] == null) Session["cat"] = "All";
            //if ((string)Session["fed"] == null) Session["fed"] = "All";
            //if ((string)Session["loc"] == null) Session["loc"] = "All";
            //string _name = (string)Session["sch"];
            //if ((string)Session["project"] == "ASAO")
            //{
            //    if (_name == "21")
            //        _name = "21A";
            //    else if (_name == "8")
            //        _name = "8A";
            //    else if (_name == "23")
            //        _name = "23A";
            //}
            //else if ((string)Session["project"] == "CCAD")
            //{
            //    _name = _name + "_1";
            //}
            //cryRpt.SetParameterValue("name", _name);
            //cryRpt.SetParameterValue("project", (string)Session["projectname"]);
            //cryRpt.SetParameterValue("data_title", Get_Title());
            //cryRpt.SetParameterValue("graph", _graph);
            //cryRpt.SetParameterValue("bz", (string)Session["zone"]);
            //cryRpt.SetParameterValue("cat", (string)Session["cat"]);
            //cryRpt.SetParameterValue("fl", (string)Session["flvl"]);
            //cryRpt.SetParameterValue("ff", (string)Session["fed"]);
            cryRpt.SetParameterValue("sch", lblsch.Text);
            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.DataBind();
            Session["Report"] = cryRpt;
        }
    }
}
