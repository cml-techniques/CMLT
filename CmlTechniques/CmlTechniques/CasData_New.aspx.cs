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

namespace CmlTechniques
{
    public partial class CasData_New : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtresult;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Master();
                Load_Main();
            }
        }
        private void Load_Master()
        {
           // _dtMaster = new DataTable();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_11736";
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = 8;
            _objcas.prj_code = "11736";
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
            _dtresult = _dtMaster;
        }
        private void Load_Main()
        {
            DataTable _dt = new DataTable();
            _dt.Columns.Add("sys_id", typeof(string));
            _dt.Columns.Add("sys_name", typeof(string));
            var distinctRows = (from DataRow dRow in _dtresult.Rows
                                select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"] }).Distinct();
            foreach (var _drow in distinctRows)
            {
                DataRow _row = _dt.NewRow();
                _row[0] = _drow.col1.ToString();
                _row[1] = _drow.col2.ToString();
                _dt.Rows.Add(_row);
            }
            main_.DataSource = _dt;
            main_.DataBind();
        }
        protected void main__ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label _sys_id = (Label)e.Item.FindControl("lblsys_id");
            ListView _sublist = (ListView)e.Item.FindControl("sub_");
            IEnumerable<DataRow> _result = from _data in _dtresult.AsEnumerable()
                                           where _data.Field<int>("Sys_Id") == Convert.ToInt32(_sys_id.Text)
                                           select _data;

            _sublist.DataSource = _result.CopyToDataTable<DataRow>();
        }
    }
}
