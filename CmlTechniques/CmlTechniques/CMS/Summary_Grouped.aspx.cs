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
    public partial class Summary_Grouped : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtfilter;
        public static DataTable _dtresult;
        public static DataTable _dtsummary;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        private void Load_Master()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = 8;
            _objcas.prj_code = lblprj.Text;
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
            _dtresult = _dtMaster;
            //var _dv = (DataView)Class1._OBJ_DATA_CAS.Select();
            //DataTable _dtemp = _dv.ToTable();
            //IEnumerable<DataRow> _result = from _data in _dtemp.AsEnumerable()
            //                               where _data.Field<int>("Cas_Schedule") == 8
            //                               select _data;
            //_dtMaster = _result.CopyToDataTable<DataRow>();
            //_dtresult = _dtMaster;
        }
        private void Generate_Summary()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PRE_COMM_QTY", typeof(string));
                _dtsummary.Columns.Add("PRE_COMM_PER", typeof(string));
                _dtsummary.Columns.Add("COMM_QTY", typeof(string));
                _dtsummary.Columns.Add("COMM_PER", typeof(string));
                _dtsummary.Columns.Add("COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PFT_TOTAL", typeof(string));
                _dtsummary.Columns.Add("PWRON_TOTAL", typeof(string));
                _dtsummary.Columns.Add("FPT_TOTAL", typeof(string));
                _dtsummary.Columns.Add("ARM_TOTAL", typeof(string));
                _dtsummary.Columns.Add("COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("SYS_ID", typeof(string));
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
                    decimal _total = 0;
                    decimal _total1 = 0;
                    decimal _overall = 0;
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
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _com1 = 0;
                    decimal _com2 = 0;
                    if (_p1 != 0)
                    {
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
                        _com1 = _per1 * 100;
                    }
                    if (_p2 != 0)
                    {
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
                        _com2 = _per2 * 100;
                    }
                    if (_p3 != 0)
                        _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count), 2);
                    _total = Decimal.Round(((_com1 * 0.1m) + (_com2 * 0.9m)));
                    if (_p6 != 0)
                        _per4 = Decimal.Round(_p6 / Convert.ToDecimal(count), 2);
                    if (_p7 != 0)
                        _per5 = Decimal.Round(_p7 / Convert.ToDecimal(count), 2);
                    _total1 = Decimal.Round(((_per4 * 0.5m) + (_per5 * 0.5m)) * 100);
                    _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = Decimal.Round(_com1).ToString();
                    _drow[4] = Decimal.Round(_p2).ToString();
                    _drow[5] = Decimal.Round(_com2).ToString();
                    _drow[6] = _total.ToString();
                    _drow[7] = Decimal.Round(_p4).ToString();
                    _drow[8] = Decimal.Round(_p5).ToString();
                    _drow[9] = Decimal.Round(_p6).ToString();
                    _drow[10] = Decimal.Round(_p7).ToString();
                    _drow[11] = _total1.ToString();
                    _drow[12] = _overall.ToString();
                    _drow[13] = row.col1.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Insert_Summary()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clscassheet _objcls = new _clscassheet();
            _clsproject _objcls1 = new _clsproject();
            _objcls1.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls1, _objdb);
            _objbll.Clear_PkgGroup_Summ(_objdb);
            var _result = from _data in _dtsummary.AsEnumerable()
                          select _data;
            //int count = 0;
            foreach (var row in _result)
            {
                _objcls.sys = Convert.ToInt32(row["SYS_ID"].ToString());
                _objdb.DBName = "DB_" + lblprj.Text;
                _objcls.sys_mon = _objbll.get_main_cat(_objcls, _objdb);
                _objcls.sys_name = _objbll.get_main_sys(_objcls, _objdb);
                _objcls.sch_name = row["SYS_NAME"].ToString();
                _objcls.quantity = Convert.ToInt32(row["QTY"].ToString());
                _objcls.per_com1 = Convert.ToDecimal(row["PRE_COMM_QTY"].ToString());
                _objcls.per_com2 = Convert.ToDecimal(row["COMM_QTY"].ToString());
                _objcls.per_com3 = Convert.ToDecimal(row["PFT_TOTAL"].ToString());
                _objcls.per_com4 = Convert.ToDecimal(row["PWRON_TOTAL"].ToString());
                _objcls.per_com5 = Convert.ToDecimal(row["FPT_TOTAL"].ToString());
                _objcls.per_com6 = Convert.ToDecimal(row["ARM_TOTAL"].ToString());
                _objdb.DBName = "DBCML";
                _objbll.Generate_CASSummary_PKGGRP_CCAD_MEC(_objcls, _objdb);
            }
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + count.ToString() + "');", true);
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
            cryRpt.Load(Server.MapPath("Cas_Mec_Sum.rpt"));
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
            if (!IsPostBack)
            {
                lblprj.Text = "CCAD";
                Load_Master();
                Generate_Summary();
                Insert_Summary();
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
    }
}
