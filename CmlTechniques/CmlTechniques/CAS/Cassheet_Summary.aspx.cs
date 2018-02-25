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

namespace CmlTechniques.CAS
{
    public partial class Cassheet_Summary : System.Web.UI.Page
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
        private void Load_Master()
        {
            //var _dv = (DataView)ObjectDataSource1.Select();
            var _dv = (DataView)Class1._OBJ_DATA_CAS.Select();
            _dtMaster = _dv.ToTable();
            _dtresult = _dtMaster;
        }
        private void Load_InitialData(int sch_id)
        {
            IEnumerable<DataRow> _result = from _data in _dtMaster.AsEnumerable()
                                           where _data.Field<int>("Cas_Schedule") == sch_id
                                          select _data;
            _dtresult = _result.CopyToDataTable<DataRow>();
        }
        private void Clear_Report()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _objbll.Clear_Cassheet_Summary(_objdb);
        }
        private void Generate_ServieBased_Summary(int ser_id)
        {
            Clear_Report();
            if (ser_id == 1)
            {
                Summary6(6);
                Summary2(2);
                Summary3(3);
                Summary4(4);
                Summary5(5);
                Summary7(7);
            }

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
                        _wit += Convert.ToInt32(_row["per_com2"].ToString());
                        _pcom += Convert.ToInt32(_row["per_com1"].ToString());
                        _com += Convert.ToInt32(_row["per_com2"].ToString());
                        if (_row["Pwr_on"].ToString().Length > 0)
                            _icom += 1;
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
                Generate_Service_Summary1(sch, 1, qty, _total, _pcom, _com, _wit, _icom);
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
                Generate_Service_Summary1(sch, 1, qty, _total, 0, 0, 0, 0);
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
                        count += 1;

                        if (sch == 28)
                        {
                            if (_row["test3"].ToString().Length > 0 && _row["test4"].ToString().Length > 0)
                                _com += 1;
                            if (_row["test2"].ToString().Length > 0)
                                _pcom += 1;
                            if (_row["test1"].ToString().Length > 0)
                                _icom += 1;
                            if (_row["test5"].ToString().Length > 0)
                                _wit += 1;
                        }
                        else if (sch == 9)
                        {
                            _com += Convert.ToInt32(_row["per_com1"].ToString());
                            if (_row["Pwr_on"].ToString().Length > 0)
                                _icom += 1;
                            if (_row["filed1"].ToString().Length > 0)
                                _wit += 1;
                        }
                    }
                    if (_p1 != 0)
                        _per1 += Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                    qty += count;
                    _rows += 1;

                }
                _total = _per1 / _rows;
                if (sch == 9)
                {
                    Generate_Service_Summary1(sch, 1, qty, _total, -1, _com, _wit, _icom);
                }
                else if (sch == 28)
                {
                    Generate_Service_Summary1(sch, 1, qty, _total, _pcom, _com, _wit, _icom);
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
                    int count = 0;
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        count += Convert.ToInt32(_row["devices1"].ToString());
                        _com += Convert.ToInt32(_row["per_com1"].ToString());
                        if (_row["Pwr_on"].ToString().Length > 0)
                            _icom += 1;
                        if (_row["test7"].ToString().Length > 0)
                            _wit += 1;
                    }

                    _per1 += Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                    qty += count;
                    _rows += 1;
                }
                _total = Decimal.Round(_per1 / _rows);
                Generate_Service_Summary1(sch, 1, qty, _total, -1, _com, _wit, _icom);
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
                decimal _per1 = 0;
                decimal _per2 = 0;
                decimal _per3 = 0;
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
                    int _pcom = 0;
                    int _com = 0;
                    int _icom = 0;
                    string _s = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        if (_row["Pwr_on"].ToString().Length > 0)
                            _icom += 1;
                        _s = _row[0].ToString();
                        count += 1;
                    }

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
                    _drow[7] = "-1";
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        //------------------ Electrical --------------------------------------
        private void Summary6(int sch)
        {
            Load_InitialData(sch);
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"], col4 = dRow["PRJ_CAS_NAME"], col5 = dRow["PRJ_SER_NAME"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
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
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    decimal _per7 = 0;
                    if (_p1 != 0)
                        _per1 = ((_p1 / Convert.ToDecimal(count)) * 100);
                    if (_p2 != 0)
                        _per2 = ((_p2 / Convert.ToDecimal(count)) * 100);
                    if (_p3 != 0)
                        _per3 = ((_p3 / Convert.ToDecimal(count)) * 100);
                    _total = Decimal.Round(((Decimal.Round(_per1) * 0.6m) + (Decimal.Round(_per2) * 0.3m) + (Decimal.Round(_per3) * 0.1m)), 0, MidpointRounding.AwayFromZero);
                    if (_p4 != 0)
                        _per4 = (_p4 / Convert.ToDecimal(count));
                    if (_p5 != 0)
                        _per5 = (_p5 / Convert.ToDecimal(count));
                    if (_p6 != 0)
                        _per6 = (_p6 / Convert.ToDecimal(count));
                    if (_p7 != 0)
                        _per7 = (_p7 / Convert.ToDecimal(count));
                    _total1 = Decimal.Round((((_per4 * 0.5m) + (_per7 * 0.5m)) * 100), 0, MidpointRounding.AwayFromZero);
                    Insert_Cassheet_Service_Summary(row.col5.ToString(), row.col4.ToString(), row.col2.ToString(), count, _per1, _per2, -1, _p4, -1, -1, _p7, _total, _total1, 6, _p1, _p2, _p3);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary2(int sch)
        {
            Load_InitialData(sch);
            int _pos = 0;
            if (sch == 2)
                _pos = 2;
            else if (sch == 3)
                _pos = 3;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"], col4 = dRow["PRJ_CAS_NAME"], col5 = dRow["PRJ_SER_NAME"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
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
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)));
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)));
                    _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), 0, MidpointRounding.AwayFromZero);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    _total1 = Decimal.Round((((_per3 * 0.25m) + (_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m)) * 100), 0, MidpointRounding.AwayFromZero);
                    Insert_Cassheet_Service_Summary(row.col5.ToString(), row.col4.ToString(), row.col2.ToString(), count, _per1, _per2, -1, _p3, _p4, _p5, _p6, _total, _total1, 2, _p1, _p2, 0);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary3(int sch)
        {
            Load_InitialData(sch);
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"], col4 = dRow["PRJ_CAS_NAME"], col5 = dRow["PRJ_SER_NAME"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
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
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)));
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)));
                    _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), 0, MidpointRounding.AwayFromZero);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    _total1 = Decimal.Round((((_per3 * 0.25m) + (_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m)) * 100), 0, MidpointRounding.AwayFromZero);
                    Insert_Cassheet_Service_Summary(row.col5.ToString(), row.col4.ToString(), row.col2.ToString(), count, _per1, _per2, -1, _p3, _p4, _p5, _p6, _total, _total1, 3, _p1, _p2, 0);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary5(int sch)
        {
            Load_InitialData(sch);
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"], col4 = dRow["PRJ_CAS_NAME"], col5 = dRow["PRJ_SER_NAME"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (IsNumeric(_row["per_com1"].ToString()) == true)
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
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    decimal _per7 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)));
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)));
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)));
                    if (row.col3.ToString() == "PFC")
                    {
                        _total = Decimal.Round(_per1, 0, MidpointRounding.AwayFromZero);
                        _per2 = -1;
                        _per3 = -1;
                    }
                    else if (row.col3.ToString() == "MDB" || row.col3.ToString() == "VFD" || row.col3.ToString() == "MCC" || row.col3.ToString() == "BDT")
                        _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m)), 0, MidpointRounding.AwayFromZero);
                    else if (row.col3.ToString() == "ATS" || row.col3.ToString() == "UPS" || row.col3.ToString() == "LCP" || row.col3.ToString() == "BAT")
                    {
                        _total = Decimal.Round(((_per1 * 0.8m) + (_per2 * 0.2m)), 0, MidpointRounding.AwayFromZero);
                        _per3 = -1;
                    }
                    else if (row.col3.ToString() == "IPS")
                    {
                        _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), 0, MidpointRounding.AwayFromZero);
                        _per3 = -1;
                    }
                    else if (row.col3.ToString() == "DB")
                    {
                        _total = Decimal.Round(((_per2 * 0.7m) + (_per3 * 0.3m)), 0, MidpointRounding.AwayFromZero);
                        _per1 = -1;
                    }
                    else
                        _total = Decimal.Round(((_per1 * 0.3m) + (_per2 * 0.5m) + (_per3 * 0.2m)), 0, MidpointRounding.AwayFromZero);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    if (_p7 != 0)
                        _per7 = Decimal.Round((_p7 / Convert.ToDecimal(count)), 2);
                    _total1 = Decimal.Round((((_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per7 * 0.25m)) * 100), 0, MidpointRounding.AwayFromZero);
                    Insert_Cassheet_Service_Summary(row.col5.ToString(), row.col4.ToString(), row.col2.ToString(), count, _per1, _per2, _per3, _p4, _p5, _p6, _p7, _total, _total1, 5, _p1, _p2, _p3);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary4(int sch)
        {
            Load_InitialData(sch);
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"], col4 = dRow["PRJ_CAS_NAME"], col5 = dRow["PRJ_SER_NAME"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
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
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    if (_p1 != 0)
                        _per1 = (_p1 / Convert.ToDecimal(count));
                    if (_p2 != 0)
                        _per2 = (_p2 / Convert.ToDecimal(count));
                    _total = Decimal.Round(((_per1 * 0.6m) + (_per2 * 0.4m)), 0, MidpointRounding.AwayFromZero);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    _total1 = Decimal.Round((((_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per3 * 0.25m)) * 100), 0,MidpointRounding.AwayFromZero);
                    Insert_Cassheet_Service_Summary(row.col5.ToString(), row.col4.ToString(), row.col2.ToString(), count, _per1, _per2, -1, _p3, _p4, _p5, _p6, _total, _total1, 4, _p1, _p2, _p3);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary7(int sch)
        {
            Load_InitialData(sch);
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"], col4 = dRow["PRJ_CAS_NAME"], col5 = dRow["PRJ_SER_NAME"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
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
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    if (row.col3.ToString() == "Graphics")
                    {
                        _per1 = -1;
                        _total = Decimal.Round(_per2, 2);
                    }
                    else if (row.col3.ToString() == "ELDB")
                    {
                        _per2 = -1;
                        _total = Decimal.Round(_per1, 2);
                    }
                    else
                        _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), 2);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    _total1 = Decimal.Round((((_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per3 * 0.25m)) * 100), 2);
                    Insert_Cassheet_Service_Summary(row.col5.ToString(), row.col4.ToString(), row.col2.ToString(), count, _per1, _per2, -1, _p3, _p4, _p5, _p6, _total, _total1, 7, _p1, _p2, _p3);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary37(int sch)
        {
            Load_InitialData(sch);
            int _pos = 0;
            if (sch == 2)
                _pos = 2;
            else if (sch == 3)
                _pos = 3;
            try
            {
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"], col4 = dRow["PRJ_CAS_NAME"], col5 = dRow["PRJ_SER_NAME"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
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
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)));
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)));
                    _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), 0, MidpointRounding.AwayFromZero);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    _total1 = Decimal.Round((((_per3 * 0.25m) + (_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m)) * 100), 0, MidpointRounding.AwayFromZero);
                    Insert_Cassheet_Service_Summary(row.col5.ToString(), row.col4.ToString(), row.col2.ToString(), count, _per1, _per2, -1, _p3, _p4, _p5, _p6, _total, _total1, _pos,0,0,0);
                }
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
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                        count += Convert.ToInt32(_row["devices2"].ToString());
                        _qty += 1;
                        if (_row["test1"].ToString().Length > 0)
                            _pcom += 1;
                        if (_row["test5"].ToString().Length > 0)
                            _com += 1;
                        if (_row["filed1"].ToString().Length > 0 && _row["filed2"].ToString().Length > 0)
                            _wit += 1;
                        if (_row["Pwr_on"].ToString().Length > 0)
                            _icom += 1;
                    }
                    _per1 += (_p1 + _p2 + _p3 + _p4 + _p5 + _p6 + _p7) / 7;
                }
                _total = decimal.Round((_per1 / _qty) * 100);
                Generate_Service_Summary1(sch, 3, _qty, _total, _pcom, _com, _wit, _icom);

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
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        count += Convert.ToInt32(_row["devices3"].ToString());
                        _qty += 1;
                        if (_row["test1"].ToString().Length > 0 && _row["test2"].ToString().Length > 0 && _row["test3"].ToString().Length > 0)
                            _pcom += 1;
                        if (_row["test5"].ToString().Length > 0 && _row["test4"].ToString().Length > 0)
                            _com += 1;
                        if (_row["filed1"].ToString().Length > 0 && _row["filed2"].ToString().Length > 0 && _row["test11"].ToString().Length > 0)
                            _wit += 1;
                        if (_row["Pwr_on"].ToString().Length > 0)
                            _icom += 1;
                    }
                    _per1 += (_p1 + _p2 + _p3 + _p4 + _p5 + _p6) / 6;
                }
                _total = decimal.Round((_per1 / _qty) * 100);
                Generate_Service_Summary1(sch, 3, _qty, _total, _pcom, _com, _wit, _icom);

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
                _dtsummary.Columns.Add("IDC", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _circuits = 0;
                decimal _scenes = 0;
                decimal _total = 0;
                var _result = from _data in _dtMaster.AsEnumerable()
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
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 11;
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
                decimal _p1 = 0;
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();


                    decimal _points = 0;
                    string _test = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _qty += 1;
                        _com += Convert.ToInt32(_row["per_com1"].ToString());
                        if (_row["filed1"].ToString().Length > 0)
                            _wit += 1;
                        if (_row["Pwr_on"].ToString().Length > 0)
                            _icom += 1;
                    }
                }
                _total = decimal.Round((_p1 / _qty) * 100);
                Generate_Service_Summary1(sch, 3, _qty, _total, -1, _com, _wit, _icom);
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
                decimal _per1 = 0;
                int _pcom = 0;
                int _com = 0;
                int _wit = 0;
                int _icom = 0;
                int count = 0;
                decimal _total = 0;
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
                        //count += Convert.ToInt32(_row["devices1"].ToString());
                        _qty += 1;
                        if (Convert.ToDecimal(_row["per_com8"].ToString()) == 100)
                            _com += 1;
                        if (_row["Accept1"].ToString().Length > 0)
                            _wit += 1;
                        if (_row["Pwr_on"].ToString().Length > 0)
                            _icom += 1;

                    }
                    _per1 += (_p1 + _p2 + _p3 + _p4 + _p5 + _p6 + _p7) / 7;
                }
                _total = decimal.Round((_per1 / _qty) * 100);
                Generate_Service_Summary1(sch, 4, _qty, _total, -1, _com, _wit, _icom);
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
                        count += 1;
                        if (_row["test1"].ToString() != "N/A" && _row["test1"].ToString() != "NA" && _row["test1"].ToString() != "")
                            _pcom += 1;
                        if (_row["test12"].ToString().Length > 0)
                            _com += 1;
                        if (_row["Pwr_on"].ToString().Length > 0)
                            _icom += 1;
                        if (_row["filed1"].ToString().Length > 0)
                            _wit += 1;
                    }

                }
                _total = Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                Generate_Service_Summary1(sch, 4, count, _total, -1, _com, _wit, _icom);
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
        private void Generate_Summary_Graph(int _sch, int pos)
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
        private void Generate_Service_Summary1(int _sch, int pos, int qty, decimal progress, int pre_com, int comm, int witness, int icom)
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
            else if (lblmode.Text == "1")
            {
                cryRpt.Load(Server.MapPath("cas_srv_sum2.rpt"));
            }
            else if (lblmode.Text == "2")
            {
                cryRpt.Load(Server.MapPath("cas_srv_sum_all.rpt"));
            }
            crConnectionInfo.ServerName = "37.61.235.103";
            crConnectionInfo.DatabaseName = "DBCML";
            crConnectionInfo.UserID = "sa";
            crConnectionInfo.Password = "vCr6wgu3";
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
        private void Page_Init(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                //string _prm = Request.QueryString[0].ToString();
                //lblsrv.Text = _prm.Substring(0, _prm.IndexOf("_P"));
                //lblprj.Text = _prm.Substring(_prm.IndexOf("_P") + 2, _prm.IndexOf("_T") - (_prm.IndexOf("_P") + 2));
                //lblmode.Text = _prm.Substring(_prm.IndexOf("_T") + 2);
                Load_Master();
                Generate_ServieBased_Summary(1);
                //Generate_Reports();

                //Generate_Summary();
                //Generate_Summary_Graph();
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

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["prj_code"] = "CCAD";
        }
        
        private void Insert_Cassheet_Service_Summary(string _service,string _schedule, string _system,int _qty,decimal _test1,decimal _test2,decimal _test3,decimal _test4,decimal _test5,decimal _test6, decimal _test7,decimal _completed1,decimal _completed2,int _possition,decimal _test1_qty,decimal _test2_qty,decimal _test3_qty)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DBCML";
            _objcls.sys_mon = _service;
            _objcls.sch_name = _schedule;
            _objcls.sys_name = _system;
            _objcls.quantity = _qty;
            _objcls.per_com1 = _test1;
            _objcls.per_com2 = _test2;
            _objcls.per_com3 = _test3;
            _objcls.per_com4 = _test4;
            _objcls.per_com5 = _test5;
            _objcls.per_com6 = _test6;
            _objcls.per_com7 = _test7;
            _objcls.per_com8 = _completed1;
            _objcls.per_com9 = _completed2;
            _objcls.Position = _possition;
            _objcls.per_com10 = _test1_qty;
            _objcls.per_com11 = _test2_qty;
            _objcls.per_com12 = _test3_qty;
            _objbll.Generate_Cassheet_Summary(_objcls, _objdb);

        }
    }
}
