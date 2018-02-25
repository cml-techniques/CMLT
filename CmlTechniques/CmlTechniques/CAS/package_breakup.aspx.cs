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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using BusinessLogic;
using App_Properties;
using System.Collections.Generic;

namespace CmlTechniques.CAS
{
    public partial class package_breakup : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtService;
        public static DataTable _dtresult;
        public static DataTable _dtsummary;
        public static DataTable _dtfilter;
        public static DataTable _dtdetails;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string _prm = Request.QueryString[0].ToString();
                lblprj.Text = "CCAD";
                Load_Master(8);
                Summary8_1();
                Generate_Summary_Graph();
            }
        }
       
        private void Load_Master(int sch)
        {
            if (lblprj.Text == "CCAD" || lblprj.Text == "ASAO" || lblprj.Text == "Trial")
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
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + (string)Session["project"];
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = sch;
                _objcas.prj_code = (string)Session["project"];
                _dtdetails = _objbll.Load_casMain_Edit(_objcas, _objdb);
                _dtresult = _dtdetails;
            }
            //_dtresult = _dtdetails;
            //_dtfilter = _dtresult;
            //Filtering(drbzone.SelectedItem.Text, drflevel.SelectedItem.Text);

        }
        private void Generate_Summary(int sch)
        {
            switch (sch)
            {
                case 8: { Summary8_1(); break; }
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
                _objcls.quantity = Convert.ToInt32(row["QTY"].ToString());
                _objbll.Generate_CASSummary_PKG_RPT(_objcls, _objdb);
                //count += 1;
            }
        }
        private void Summary8_1()
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
                    _drow[3] = Decimal.Round(_p2).ToString();
                    _drow[4] = Decimal.Round(_p3).ToString();
                    _drow[5] = _overall.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
    }
}
