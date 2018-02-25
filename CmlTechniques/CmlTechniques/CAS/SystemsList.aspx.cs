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
using DataLinkLibrary;

namespace CmlTechniques.CAS
{
    public partial class SystemsList : System.Web.UI.Page
    {
        public static DataTable _dtCas;
        public static DataTable _dtresult;
        public static DataTable _dtMaster;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_CasData();
                Load_Services();
            }
        }
        private void Load_CasData()
        {
            var _dv = (DataView)Class1._OBJ_DATA_CAS.Select();
            DataTable _dtemp = _dv.ToTable();
            IEnumerable<DataRow> _result = from _data in _dtemp.AsEnumerable()
                                           select _data;
            if (_result.Any())
            {
                _dtresult = _result.CopyToDataTable<DataRow>();
            }
            else
                _dtresult = null;
        }
        private void Load_Services()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();
            _clscassheet _objcls1 = new _clscassheet();
            _objdb.DBName = "dbCML";
           // _objcls.uid = (string)Session["uid"];
            _objcls.project_code = "CCAD";
           // string _permission = _objbll.Get_User_Permission(_objcls, _objdb);
            _objdb.DBName = "DB_CCAD";
            DataTable _dtser = _objbll.Load_Prj_Service(_objdb);
            _dtCas = _objbll.Load_Prj_Cassheet(_objdb);
            mymaster.DataSource = _dtser;
            mymaster.DataBind();
        }

        protected void mymaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _sys_id = (Label)e.Row.FindControl("lbSys_Id");
                IEnumerable<DataRow> _result = from _data in _dtCas.AsEnumerable()
                                               where _data.Field<int>("SYS_SER_ID") == Convert.ToInt32(_sys_id.Text)
                                               select _data;
                DataTable _dt = _result.CopyToDataTable<DataRow>();
                GridView _mydetails = (GridView)e.Row.FindControl("mydetails");
                _mydetails.DataSource = _dt;
                _mydetails.DataBind();
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
                _btn.Text = "-";
            }
            else if (_btn.Text == "-")
            {
                _mydetails.Visible = false;
                _btn.Text = "+";
            }
            //_exp = true;
        }
        protected void mydetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView _mydetails = (GridView)gvRow.FindControl("mydetails");
            int _idx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = _mydetails.Rows[_idx];
            // _mydetails.Rows[_idx].Style.Add("background-color", "yellow");
            //int index = gvRow.RowIndex;
            TableCell _item1 = _srow.Cells[17];
            TableCell _item2 = _srow.Cells[18];
            // TableCell _item3 = _srow.Cells[2];
            //string _file = _item.Text;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _file + "');", true);
            Session["casid"] = _item1.Text;
            Session["Sys"] = _item2.Text;
            Session["idx"] = _idx.ToString();
            btnDummy_ModalPopupExtender.Show();
            //arrange_edit();

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
        protected void chkrow_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            GridViewRow row = (GridViewRow)checkbox.NamingContainer;
            if (checkbox.Checked == true)
                row.BackColor = System.Drawing.Color.Gainsboro;
            else
                row.BackColor = System.Drawing.Color.White;
        }
       
        protected void mydetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _sch_id = (Label)e.Row.FindControl("lbcas_Id");
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_CCAD";
                _clscassheet _objcls = new _clscassheet();
                _objcls.sch = Convert.ToInt32(_sch_id.Text);
                DataTable _dt0 = _objbll.Load_System_List(_objcls, _objdb);
                GridView _mydetails1 = (GridView)e.Row.FindControl("mydetails1");
                _mydetails1.DataSource = _dt0;
                _mydetails1.DataBind();
                DataTable _dtsub1 = _objbll.Load_Cassheet_Sub_System_List(_objcls, _objdb);
                GridView _mydetails2 = (GridView)e.Row.FindControl("mydetails2");
                _mydetails2.DataSource = _dtsub1;
                _mydetails2.DataBind();
            }
        }
        protected void mydetails1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[24].Visible = false;
            e.Row.Cells[22].Visible = false;
            e.Row.Cells[23].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = (e.Row.RowIndex + 1).ToString();
                if (e.Row.Cells[3].Text == "1")
                    e.Row.Cells[3].Text = "Yes";
                else if (e.Row.Cells[3].Text == "0")
                    e.Row.Cells[3].Text = "No";
                if (e.Row.Cells[4].Text == "1")
                {
                    e.Row.Cells[4].Text = "Yes";
                    e.Row.Cells[5].Text = "";
                }
                else if (e.Row.Cells[4].Text == "0")
                {
                    e.Row.Cells[4].Text = "";
                    e.Row.Cells[5].Text = "Yes";
                }
                if (e.Row.Cells[23].Text != "10")
                {
                    e.Row.Cells[14].Text = Summary(Convert.ToInt32(e.Row.Cells[22].Text), "D&T", Convert.ToInt32(e.Row.Cells[23].Text));
                    e.Row.Cells[15].Text = Summary(Convert.ToInt32(e.Row.Cells[22].Text), "CLINIC", Convert.ToInt32(e.Row.Cells[23].Text));
                    e.Row.Cells[16].Text = Summary(Convert.ToInt32(e.Row.Cells[22].Text), "GALLERY", Convert.ToInt32(e.Row.Cells[23].Text));
                    e.Row.Cells[17].Text = Summary(Convert.ToInt32(e.Row.Cells[22].Text), "PATIENT TOWER", Convert.ToInt32(e.Row.Cells[23].Text));
                    e.Row.Cells[18].Text = Summary(Convert.ToInt32(e.Row.Cells[22].Text), "SWING", Convert.ToInt32(e.Row.Cells[23].Text));
                    e.Row.Cells[19].Text = Summary(Convert.ToInt32(e.Row.Cells[22].Text), "ICU", Convert.ToInt32(e.Row.Cells[23].Text));
                    e.Row.Cells[20].Text = Summary(Convert.ToInt32(e.Row.Cells[22].Text), "CUP", Convert.ToInt32(e.Row.Cells[23].Text));
                    e.Row.Cells[21].Text = Summary(Convert.ToInt32(e.Row.Cells[22].Text), "CAR PARK", Convert.ToInt32(e.Row.Cells[23].Text));
                }
                else if (e.Row.Cells[23].Text == "10")
                {
                    e.Row.Cells[14].Text = Summary10_1(e.Row.Cells[2].Text, "D&T");
                    e.Row.Cells[15].Text = Summary10_1(e.Row.Cells[2].Text, "CLINIC");
                    e.Row.Cells[16].Text = Summary10_1(e.Row.Cells[2].Text, "GALLERY");
                    e.Row.Cells[17].Text = Summary10_1(e.Row.Cells[2].Text, "PATIENT TOWER");
                    e.Row.Cells[18].Text = Summary10_1(e.Row.Cells[2].Text, "SWING");
                    e.Row.Cells[19].Text = Summary10_1(e.Row.Cells[2].Text, "ICU");
                    e.Row.Cells[20].Text = Summary10_1(e.Row.Cells[2].Text, "CUP");
                    e.Row.Cells[21].Text = Summary10_1(e.Row.Cells[2].Text, "CAR PARK");
                }

            }
        }
        protected void mydetails2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _sch_id = (Label)e.Row.FindControl("lblcas_subid");
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_CCAD";
                _clscassheet _objcls = new _clscassheet();
                _objcls.sch = Convert.ToInt32(_sch_id.Text);
                DataTable _dt0 = _objbll.Load_System_List(_objcls, _objdb);
                GridView _mydetails3 = (GridView)e.Row.FindControl("mydetails3");
                _mydetails3.DataSource = _dt0;
                _mydetails3.DataBind();
            }
        }
        protected void mydetails3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[22].Visible = false;
            e.Row.Cells[23].Visible = false;
            e.Row.Cells[24].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = (e.Row.RowIndex + 1).ToString();
                if (e.Row.Cells[4].Text == "1")
                {
                    e.Row.Cells[4].Text = "Yes";
                    e.Row.Cells[5].Text = "";
                }
                else if (e.Row.Cells[4].Text == "0")
                {
                    e.Row.Cells[4].Text = "";
                    e.Row.Cells[5].Text = "Yes";
                }
                e.Row.Cells[14].Text = Summary(Convert.ToInt32(e.Row.Cells[22].Text), "D&T", Convert.ToInt32(e.Row.Cells[23].Text));
                e.Row.Cells[15].Text = Summary(Convert.ToInt32(e.Row.Cells[22].Text), "CLINIC", Convert.ToInt32(e.Row.Cells[23].Text));
                e.Row.Cells[16].Text = Summary(Convert.ToInt32(e.Row.Cells[22].Text), "GALLERY", Convert.ToInt32(e.Row.Cells[23].Text));
                e.Row.Cells[17].Text = Summary(Convert.ToInt32(e.Row.Cells[22].Text), "PATIENT TOWER", Convert.ToInt32(e.Row.Cells[23].Text));
                e.Row.Cells[18].Text = Summary(Convert.ToInt32(e.Row.Cells[22].Text), "SWING", Convert.ToInt32(e.Row.Cells[23].Text));
                e.Row.Cells[19].Text = Summary(Convert.ToInt32(e.Row.Cells[22].Text), "ICU", Convert.ToInt32(e.Row.Cells[23].Text));
                e.Row.Cells[20].Text = Summary(Convert.ToInt32(e.Row.Cells[22].Text), "CUP", Convert.ToInt32(e.Row.Cells[23].Text));
                e.Row.Cells[21].Text = Summary(Convert.ToInt32(e.Row.Cells[22].Text), "CAR PARK", Convert.ToInt32(e.Row.Cells[23].Text));
            }
        }
        private void Load_Master(int sch)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_CCAD";
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = sch;
            _objcas.prj_code = "CCAD";
            _dtresult = _objbll.Load_casMain_Edit(_objcas, _objdb);
        }
        private string Summary(int sys_id, string _b_z, int sch_id)
        {

            if (sch_id == 6)
            {
                return Summary6_1(sys_id, _b_z);
            }
            else if (sch_id == 5 || sch_id == 44)
            {
                return Summary5_1(sys_id, _b_z);
            }
            else if (sch_id == 7)
                return Summary7_1(sys_id, _b_z);
            else if (sch_id == 121 || sch_id == 119 || sch_id == 118)
                return Summary2_1(sys_id, _b_z);
            else if (sch_id == 4)
                return Summary4_1(sys_id, _b_z);
            else if (sch_id == 3 || sch_id == 120)
                return Summary3_1(sys_id, _b_z);
            else if (sch_id == 20 || sch_id == 23 || sch_id == 22 || sch_id == 13 || sch_id == 16 || sch_id == 24 || sch_id == 25 || sch_id == 14 || sch_id == 15 || sch_id == 11)
                return Summary20_1(sys_id, _b_z);
            else if (sch_id == 29)
                return Summary29_1(sys_id, _b_z);
            else if (sch_id == 12)
                return Summary12_1(sys_id, _b_z);
            else if (sch_id == 46 || sch_id == 103 || sch_id == 104 || sch_id == 105 || sch_id == 106 || sch_id == 109 || sch_id == 111 || sch_id == 112 || sch_id == 116)
                return Summary27_1(sys_id, _b_z);
            else if (sch_id == 8 || sch_id == 51 || sch_id == 52 || sch_id == 53 || sch_id == 54 || sch_id == 55 || sch_id == 56 || sch_id == 57 || sch_id == 58 || sch_id == 59)
                return Summary8_1(sys_id, _b_z);
            else if (sch_id == 85 || sch_id == 86 || sch_id == 87 || sch_id == 88 || sch_id == 89 || sch_id == 90 || sch_id == 91 || sch_id == 99 || sch_id == 95 || sch_id == 97 || sch_id == 101 || sch_id == 107 || sch_id == 108 || sch_id == 117)
                return Summary17_1(sys_id, _b_z);
            else if (sch_id == 102)
                return Summary19_1(sys_id, _b_z);
            else if (sch_id == 100)
                return Summary100_1(sys_id, _b_z);
            return "0";
        }

        private string Summary6_1(int sys_id, string _b_z)
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
                int count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<int>("Sys_id") == sys_id && _data.Field<string>("B_Z").Contains(_b_z)
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
                decimal _total = Decimal.Round(((Decimal.Round(_per1) * 0.6m) + (Decimal.Round(_per2) * 0.3m) + (Decimal.Round(_per3) * 0.1m)), 0, MidpointRounding.AwayFromZero);
                if (_p4 != 0)
                    _per4 = (_p4 / Convert.ToDecimal(count));
                if (_p5 != 0)
                    _per5 = (_p5 / Convert.ToDecimal(count));
                if (_p6 != 0)
                    _per6 = (_p6 / Convert.ToDecimal(count));
                if (_p7 != 0)
                    _per7 = (_p7 / Convert.ToDecimal(count));
                //_total1 = Decimal.Round((((_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per7 * 0.25m)) * 100), 2);
                decimal _total1 = Decimal.Round((((_per4 * 0.5m) + (_per7 * 0.5m)) * 100), 0, MidpointRounding.AwayFromZero);
                decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)), 0, MidpointRounding.AwayFromZero);
                if (count > 0)
                    return _overall.ToString() + "%";
                else
                    return "N/A";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return "0";

        }
        private string Summary2_1(int sys_id, string _b_z)
        {

            try
            {
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _total = 0;
                decimal _total1 = 0;
                int count = 0;
                string _s = "";
                var _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<int>("Sys_id") == sys_id && _data.Field<string>("B_Z").Contains(_b_z)
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
                    _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                if (_p2 != 0)
                    _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), 2);
                if (_p3 != 0)
                    _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                if (_p4 != 0)
                    _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                if (_p5 != 0)
                    _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                if (_p6 != 0)
                    _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                _total1 = Decimal.Round((((_per3 * 0.25m) + (_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m)) * 100), 2);
                decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                if (count > 0)
                    return _overall.ToString() + "%";
                else
                    return "N/A";

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return "0";
        }
        private string Summary5_1(int sys_id, string _b_z)
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
                decimal _total = 0;
                decimal _total1 = 0;
                int count = 0;
                string _s = "";
                string _cat = "";
                var _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<int>("Sys_id") == sys_id && _data.Field<string>("B_Z").Contains(_b_z)
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
                    _cat = _row["Cat"].ToString();
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
                    _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                if (_p2 != 0)
                    _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                if (_p3 != 0)
                    _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                if (_cat == "PFC")
                    _total = Decimal.Round(_per1, 2);
                else if (_cat == "MDB" || _cat == "VFD" || _cat == "MCC")
                    _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m)), 2);
                else if (_cat == "ATS" || _cat == "UPS" || _cat == "LCP" || _cat == "BAT")
                    _total = Decimal.Round(((_per1 * 0.8m) + (_per2 * 0.2m)), 2);
                else if (_cat == "IPS")
                    _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), 2);
                else if (_cat == "DB")
                    _total = Decimal.Round(((_per2 * 0.7m) + (_per3 * 0.3m)), 2);
                else
                    _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m)), 2);
                if (_p4 != 0)
                    _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                if (_p5 != 0)
                    _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                if (_p6 != 0)
                    _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                if (_p7 != 0)
                    _per7 = Decimal.Round((_p7 / Convert.ToDecimal(count)), 2);
                _total1 = Decimal.Round((((_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per7 * 0.25m)) * 100), 2);
                decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                if (count > 0)
                    return _overall.ToString() + "%";
                else
                   return  "N/A";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return "0";
        }
        private string Summary4_1(int sys_id, string _b_z)
        {

            try
            {
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _total = 0;
                decimal _total1 = 0;
                int count = 0;
                string _s = "";
                var _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<int>("Sys_id") == sys_id && _data.Field<string>("B_Z").Contains(_b_z)
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
                _total = Decimal.Round(((_per1 * 0.6m) + (_per2 * 0.4m)), 2);
                if (_p3 != 0)
                    _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                if (_p4 != 0)
                    _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                if (_p5 != 0)
                    _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                if (_p6 != 0)
                    _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                _total1 = Decimal.Round((((_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per3 * 0.25m)) * 100), 2);
                decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                if (count > 0)
                    return _overall.ToString() + "%";
                else
                    return "N/A";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return "0";
        }
        private string Summary3_1(int sys_id, string _b_z)
        {

            try
            {

                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _total = 0;
                decimal _total1 = 0;
                int count = 0;
                string _s = "";
                var _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<int>("Sys_id") == sys_id && _data.Field<string>("B_Z").Contains(_b_z)
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
                decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                if (count > 0)
                    return _overall.ToString() + "%";
                else
                    return "N/A";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return "0";

        }
        private string  Summary7_1(int sys_id, string _b_z)
        {

            try
            {

                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _total = 0;
                decimal _total1 = 0;
                int count = 0;
                int qty = 0;
                int _cold = 0;
                string _s = "";
                var _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<int>("Sys_id") == sys_id && _data.Field<string>("B_Z").Contains(_b_z)
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//pft
                    _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pwron
                    _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//fpt
                    _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//arm
                    //if (IsNumeric(_row["devices2"].ToString()) == true)
                    //    qty += Convert.ToInt32(_row["devices2"].ToString());
                    //if (IsNumeric(_row["test1"].ToString()) == true)
                    //    _cold += Convert.ToInt32(_row["test1"].ToString());
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
                decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                if (count > 0)
                    return _overall.ToString() + "%";
                else
                    return "N/A";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return "0";
        }
        private string Summary20_1(int sys_id, string _b_z)
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
                decimal _total = 0;
                decimal _total1 = 0;
                int count = 0;
                int qty = 0;
                int _cold = 0;
                string _s = "";
                var _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<int>("Sys_id") == sys_id && _data.Field<string>("B_Z").Contains(_b_z)
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
                decimal _per1 = 0;
                decimal _per2 = 0;
                decimal _per3 = 0;
                decimal _per4 = 0;
                decimal _per5 = 0;
                decimal _per6 = 0;
                decimal _per7 = 0;
                if (_p1 != 0)
                    _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                if (_p2 != 0)
                    _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)), 2);
                if (_p3 != 0)
                    _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                if (_p4 != 0)
                    _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                if (_p5 != 0)
                    _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                if (_p6 != 0)
                    _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                if (_p7 != 0)
                    _per7 = Decimal.Round((_p7 / Convert.ToDecimal(count)), 2);
                _total1 = Decimal.Round((((_per4 * 0.2m) + (_per5 * 0.2m) + (_per6 * 0.2m) + (_per7 * 0.2m) + (_per3 * 0.2m)) * 100), 2);
                decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                if (count > 0)
                    return _overall.ToString() + "%";
                else
                    return "N/A";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return "0";
        }
        private string Summary29_1(int sys_id, string _b_z)
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
                    decimal _total = 0;
                    decimal _total1 = 0;
                    int count = 0;
                    int qty = 0;
                    int _cold = 0;
                    string _s = "";
                   var _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<int>("Sys_id") == sys_id && _data.Field<string>("B_Z").Contains(_b_z)
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
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    decimal _per7 = 0;
                    decimal _per8 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 0, MidpointRounding.AwayFromZero);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 0, MidpointRounding.AwayFromZero);
                    _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)), 0, MidpointRounding.AwayFromZero);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    if (_p7 != 0)
                        _per7 = Decimal.Round((_p7 / Convert.ToDecimal(count)), 2);

                    _total1 = Decimal.Round((((_per4 * 0.2m) + (_per5 * 0.2m) + (_per6 * 0.2m) + (_per7 * 0.2m) + (_per3 * 0.2m)) * 100), 0, MidpointRounding.AwayFromZero);

                    decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                    if(count>0)
                        return _overall.ToString()+"%";
                    else 
                        return "N/A";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return "0";
        }
        private string Summary12_1(int sys_id, string _b_z)
        {

            try
            {
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _total = 0;
                decimal _total1 = 0;
                int count = 0;
                int qty = 0;
                int _cold = 0;
                string _s = "";
                var _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<int>("Sys_id") == sys_id && _data.Field<string>("B_Z").Contains(_b_z)
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
                decimal _per1 = 0;
                decimal _per2 = 0;
                decimal _per3 = 0;
                decimal _per4 = 0;
                decimal _per5 = 0;
                decimal _per6 = 0;
                if (_p1 != 0)
                    _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                _total = Decimal.Round((_per1), 2);
                if (_p2 != 0)
                    _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                if (_p3 != 0)
                    _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                if (_p4 != 0)
                    _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                if (_p5 != 0)
                    _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                if (_p6 != 0)
                    _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                _total1 = Decimal.Round((((_per4 * 0.2m) + (_per5 * 0.2m) + (_per6 * 0.2m) + (_per2 * 0.2m) + (_per3 * 0.2m)) * 100), 2);
                decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                if (count > 0)
                    return _overall.ToString() + "%";
                else
                    return "N/A";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return "0";
        }
        private string Summary27_1(int sys_id, string _b_z)
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
                    decimal _total = 0;
                    decimal _total1 = 0;
                    int count = 0;
                    int qty = 0;
                    int _cold = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<int>("Sys_id") == sys_id && _data.Field<string>("B_Z").Contains(_b_z)
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
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    decimal _per7 = 0;
                    decimal _per8 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    _total = Decimal.Round(_per2, 2);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    if (_p7 != 0)
                        _per7 = Decimal.Round((_p7 / Convert.ToDecimal(count)), 2);
                    _total1 = Decimal.Round((((_per5 * 0.25m) + (_per6 * 0.25m) + (_per7 * 0.25m) + (_per3 * 0.25m)) * 100), 2);
                    decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                    if (count > 0)
                        return _overall.ToString() + "%";
                    else
                        return "N/A";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return "0";
        }
        private string Summary8_1(int sys_id, string _b_z)
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
                decimal _total = 0;
                decimal _total1 = 0;
                decimal _overall = 0;
                int count = 0;
                string _s = "";
                var _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<int>("Sys_id") == sys_id && _data.Field<string>("B_Z").Contains(_b_z)
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
                if (count > 0)
                    return _overall.ToString() + "%";
                else
                    return "N/A";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return "0";
        }
        private string Summary17_1(int sys_id, string _b_z)
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
                decimal _total = 0;
                decimal _total1 = 0;
                int count = 0;
                int qty = 0;
                int _cold = 0;
                string _s = "";
                var _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<int>("Sys_id") == sys_id && _data.Field<string>("B_Z").Contains(_b_z)
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
                decimal _per1 = 0;
                decimal _per2 = 0;
                decimal _per3 = 0;
                decimal _per4 = 0;
                decimal _per5 = 0;
                decimal _per6 = 0;
                decimal _per7 = 0;
                decimal _per8 = 0;
                if (_p1 != 0)
                    _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                if (_p2 != 0)
                    _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100, 2);
                if (_p3 != 0)
                    _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                if (_p4 != 0)
                    _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                if (_p5 != 0)
                    _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                if (_p6 != 0)
                    _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                if (_p7 != 0)
                    _per7 = Decimal.Round((_p7 / Convert.ToDecimal(count)), 2);
                if (_p8 != 0)
                    _per8 = Decimal.Round((_p8 / Convert.ToDecimal(count)), 2);
                _total1 = Decimal.Round((((_per4 * 0.2m) + (_per5 * 0.2m) + (_per6 * 0.2m) + (_per7 * 0.2m) + (_per8 * 0.2m)) * 100), 2);
                decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                if (count > 0)
                    return _overall.ToString() + "%";
                else
                    return "N/A";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return "0";
        }
        private string Summary19_1(int sys_id, string _b_z)
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
                int count = 0;
                string _s = "";
                var _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<int>("Sys_id") == sys_id && _data.Field<string>("B_Z").Contains(_b_z)
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
                decimal _per1 = 0;
                decimal _per2 = 0;
                if (_p1 != 0)
                    _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                if (_p2 != 0)
                    _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);

                decimal _overall = Decimal.Round(((_per1 * 0.8m) + (_per2 * 0.2m)));
                if (count > 0)
                    return _overall.ToString() + "%";
                else
                    return "N/A";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return "0";
        }
        private string Summary100_1(int sys_id, string _b_z)
        {
            try
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
                decimal _p8 = 0;
                decimal _total = 0;
                decimal _total1 = 0;
                int count = 0;
                string _s = "";
                var _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<int>("Sys_id") == sys_id && _data.Field<string>("B_Z").Contains(_b_z)
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
                decimal _per1 = 0;
                decimal _per2 = 0;
                decimal _per3 = 0;
                decimal _per4 = 0;
                decimal _per5 = 0;
                decimal _per6 = 0;
                decimal _per7 = 0;
                if (_p1 != 0)
                    _per1 = _p1 / Convert.ToDecimal(count);
                if (_p2 != 0)
                    _per2 = _p2 / Convert.ToDecimal(count);
                _total = Decimal.Round(_per1 * 0.2m + _per2 * 0.8m, 0, MidpointRounding.AwayFromZero);
                if (_p4 != 0)
                    _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                if (_p5 != 0)
                    _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                if (_p6 != 0)
                    _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                if (_p7 != 0)
                    _per7 = Decimal.Round((_p7 / Convert.ToDecimal(count)), 2);
                if (_p3 != 0)
                    _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                _total1 = Decimal.Round((((_per5 * 0.2m) + (_per6 * 0.2m) + (_per7 * 0.2m) + (_per3 * 0.2m) + (_per4 * 0.2m)) * 100), 0, MidpointRounding.AwayFromZero);
                decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)), 0, MidpointRounding.AwayFromZero);
                if (count > 0)
                    return _overall.ToString() + "%";
                else
                    return "N/A";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return "0";
        }
        private string Summary10_1(string _sys_nam, string _b_z)
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
                var _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<string>("B_Z").Contains(_b_z)
                              select _data;
                //var _result = "";
                //BLL_Dml _objbll = new BLL_Dml();
                //_database _objdb = new _database();
                //_objdb.DBName = "DB_" + (string)Session["project"];
                //_clscassheet _objcas = new _clscassheet();
                //_objcas.sch = 10;
                //DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                //var TestNames = from _data in _dtnames.AsEnumerable()
                //                select _data;
                //foreach (var row in TestNames)
                //{
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

                if (_sys_nam == "Circuit IR / Continuity Test")
                {

                    _result = from _data in _dtresult.AsEnumerable()
                              where (_data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAD" || _data.Field<string>("Cat") == "FAM" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN") && _data.Field<string>("B_Z").Contains(_b_z)
                              select _data;
                    foreach (var _row in _result)
                    {
                        if (_b_z == "CUP")
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        else if (_b_z == "SOUTH GALLERY")
                        {
                            _p2 += Convert.ToDecimal(_row["per_com1"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        else if (_b_z == "CLINIC")
                        {
                            _p3 += Convert.ToDecimal(_row["per_com1"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        else if (_b_z == "D&T" || _b_z == "ICU" || _b_z == "SWING" || _b_z == "PATIENT")
                        {
                            _p4 += Convert.ToDecimal(_row["per_com1"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                        }
                    }
                    _qty = _devices + _devices1 + _devices2 + _devices3;
                    _tested = _p1 + _p2 + _p3 + _p4;
                }
                else if (_sys_nam == "FA Device Test")
                {
                    _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<string>("Cat") == "FAD" && _data.Field<string>("B_Z").Contains(_b_z)
                              select _data;
                    foreach (var _row in _result)
                    {
                        if (_b_z == "CUP")
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        else if (_b_z == "SOUTH GALLERY")
                        {
                            _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        else if (_b_z == "CLINIC")
                        {
                            _p3 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        else if (_b_z == "D&T" || _b_z == "ICU" || _b_z == "SWING" || _b_z == "PATIENT")
                        {
                            _p4 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                        }
                    }
                    _qty = _devices + _devices1 + _devices2 + _devices3;
                    _tested = _p1 + _p2 + _p3 + _p4;
                }
                else if (_sys_nam == "FA Interface Test")
                {
                    _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<string>("Cat") == "FAM" && _data.Field<string>("B_Z").Contains(_b_z)
                              select _data;
                    foreach (var _row in _result)
                    {
                        if (_b_z == "CUP")
                        {
                            _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                            if (IsNumeric(_row["devices1"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices1"].ToString());
                        }
                        else if (_b_z == "SOUTH GALLERY")
                        {
                            _p2 += Convert.ToDecimal(_row["per_com3"].ToString());
                            if (IsNumeric(_row["devices1"].ToString()) == true)
                                _devices1 += Convert.ToInt32(_row["devices1"].ToString());
                        }
                        else if (_b_z == "CLINIC")
                        {
                            _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                            if (IsNumeric(_row["devices1"].ToString()) == true)
                                _devices2 += Convert.ToInt32(_row["devices1"].ToString());
                        }
                        else if (_b_z == "D&T" || _b_z == "ICU" || _b_z == "SWING" || _b_z == "PATIENT")
                        {
                            _p4 += Convert.ToDecimal(_row["per_com3"].ToString());
                            if (IsNumeric(_row["devices1"].ToString()) == true)
                                _devices3 += Convert.ToInt32(_row["devices1"].ToString());
                        }
                    }
                    _qty = _devices + _devices1 + _devices2 + _devices3;
                    _tested = _p1 + _p2 + _p3 + _p4;
                }
                else if (_sys_nam == "Voice Evac Speaker Test")
                {
                    _result = from _data in _dtresult.AsEnumerable()
                              where (_data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "ANN" || _data.Field<string>("Cat") == "FSC") && _data.Field<string>("B_Z").Contains(_b_z)
                              select _data;
                    foreach (var _row in _result)
                    {
                        if (_b_z == "CUP")
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        else if (_b_z == "SOUTH GALLERY")
                        {
                            _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        else if (_b_z == "CLINIC")
                        {
                            _p3 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        else if (_b_z == "D&T" || _b_z == "ICU" || _b_z == "SWING" || _b_z == "PATIENT")
                        {
                            _p4 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                        }
                    }
                    _qty = _devices + _devices1 + _devices2 + _devices3;
                    _tested = _p1 + _p2 + _p3 + _p4;
                }
                else if (_sys_nam == "Fire Telephone Device Test")
                {
                    _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<string>("Cat") == "FTL" && _data.Field<string>("B_Z").Contains(_b_z)
                              select _data;
                    foreach (var _row in _result)
                    {
                        if (_b_z == "CUP")
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        else if (_b_z == "SOUTH GALLERY")
                        {
                            _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        else if (_b_z == "CLINIC")
                        {
                            _p3 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        else if (_b_z == "D&T" || _b_z == "ICU" || _b_z == "SWING" || _b_z == "PATIENT")
                        {
                            _p4 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                        }
                    }
                    _qty = _devices + _devices1 + _devices2 + _devices3;
                    _tested = _p1 + _p2 + _p3 + _p4;

                }
                else if (_sys_nam == "Battery Autonomy Test")
                {
                    _result = from _data in _dtresult.AsEnumerable()
                              where (_data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAD" || _data.Field<string>("Cat") == "FAM" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN") && _data.Field<string>("B_Z").Contains(_b_z)
                              select _data;
                    foreach (var _row in _result)
                    {
                        if (_b_z == "CUP")
                        {
                            _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        else if (_b_z == "SOUTH GALLERY")
                        {
                            _p2 += Convert.ToDecimal(_row["per_com4"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        else if (_b_z == "CLINIC")
                        {
                            _p3 += Convert.ToDecimal(_row["per_com4"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        else if (_b_z == "D&T" || _b_z == "ICU" || _b_z == "SWING" || _b_z == "PATIENT")
                        {
                            _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                        }
                    }
                    _qty = _devices + _devices1 + _devices2 + _devices3;
                    _tested = _p1 + _p2 + _p3 + _p4;

                }
                else if (_sys_nam == "Graphic/ Head End Test")
                {
                    _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<string>("Cat") == "FAD" && _data.Field<string>("B_Z").Contains(_b_z)
                              select _data;
                    foreach (var _row in _result)
                    {
                        if (_b_z == "CUP")
                        {
                            _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        else if (_b_z == "SOUTH GALLERY")
                        {
                            _p2 += Convert.ToDecimal(_row["per_com5"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        else if (_b_z == "CLINIC")
                        {
                            _p3 += Convert.ToDecimal(_row["per_com5"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        else if (_b_z == "D&T" || _b_z == "ICU" || _b_z == "SWING" || _b_z == "PATIENT")
                        {
                            _p4 += Convert.ToDecimal(_row["per_com5"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                        }
                    }
                    _qty = _devices + _devices1 + _devices2 + _devices3;
                    _tested = _p1 + _p2 + _p3 + _p4;
                }
                if (_qty != 0)
                {
                    _total = Decimal.Round((_tested / _qty) * 100);
                }
                else
                    _total = 0;
                return _total.ToString() + "%";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
            return "0";
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            {

                GridView _details = (GridView)mymaster.Rows[i].FindControl("mydetails");
                foreach (GridViewRow _drow in _details.Rows)
                {
                    GridView _inner_main = (GridView)_drow.FindControl("mydetails1");
                    foreach (GridViewRow _drow1 in _inner_main.Rows)
                    {
                        CheckBox checkbox = (CheckBox)_drow1.FindControl("chkselect");
                        if (checkbox.Checked == true)
                        {
                            count += 1;
                            Session["Sys"] = _drow1.Cells[24].Text;
                        }
                    }
                    GridView _inner_sub = (GridView)_drow.FindControl("mydetails2");
                    foreach (GridViewRow _drow2 in _inner_sub.Rows)
                    {
                        GridView _inner_sub1 = (GridView)_drow2.FindControl("mydetails3");
                        foreach (GridViewRow _drow3 in _inner_sub1.Rows)
                        {
                            CheckBox checkbox = (CheckBox)_drow3.FindControl("chkselect");
                            if (checkbox.Checked == true)
                            {
                                count += 1;
                                Session["Sys"] = _drow3.Cells[24].Text;
                            }
                        }
                    }
                }



            }
            if (count == 0) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');", true);
            else if (count > 1) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('You can select only one Row at a time to Edit');", true);
            else if (count == 1)
            {
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["MemberId"] + "',7);", true);
                Load_System_List();
                btnDummy_ModalPopupExtender.Show();
            }
        }

        protected void btnupdate1_Click(object sender, EventArgs e)
        {
            Update_System_List();
            btnDummy_ModalPopupExtender.Hide();
            //Load_Services();
            Reset();
        }
        private void Reset()
        {
            rd_critical.ClearSelection();
            rd_resp.ClearSelection();
            txt_p1.Text = "0";
            txt_p2.Text = "0";
            txt_p3.Text = "0";
            txt_p4.Text = "0";
            txt_p5.Text = "0";
            txt_p6.Text = "0";
            txt_p7.Text = "0";
            txt_p8.Text = "0";
        }

        private void Update_System_List()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_CCAD";
            _clscassheet _objcas = new _clscassheet();
            _objcas.sys = Convert.ToInt32((string)Session["Sys"]);
            if (rd_critical.SelectedItem.Value == "1")
                _objcas.Critical = true;
            else
                _objcas.Critical = false;
            if (rd_resp.SelectedItem.Value == "1" || rd_resp.SelectedItem.Value == "0")
                _objcas.resp1 = Convert.ToInt32(rd_resp.SelectedItem.Value);
            _objcas.per_com1 = Convert.ToDecimal(txt_p1.Text);
            _objcas.per_com2 = Convert.ToDecimal(txt_p2.Text);
            _objcas.per_com3 = Convert.ToDecimal(txt_p3.Text);
            _objcas.per_com4 = Convert.ToDecimal(txt_p4.Text);
            _objcas.per_com5 = Convert.ToDecimal(txt_p5.Text);
            _objcas.per_com6 = Convert.ToDecimal(txt_p6.Text);
            _objcas.per_com7 = Convert.ToDecimal(txt_p7.Text);
            _objcas.per_com8 = Convert.ToDecimal(txt_p8.Text);
            _objcas.action = 1;
            _objbll.DML_System_List(_objcas, _objdb);

        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender.Hide();
        }
        private void Load_System_List()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_CCAD";
            _clscassheet _objcas = new _clscassheet();
            _objcas.sys = Convert.ToInt32((string)Session["Sys"]);
            DataTable _dt = _objbll.Load_System_List_Edit(_objcas, _objdb);
            foreach (DataRow _drow in _dt.Rows)
            {
                if (_drow["Critical_System"].ToString() == "True")
                    rd_critical.Items[0].Selected = true;
                else if (_drow["Critical_System"].ToString() == "False")
                    rd_critical.Items[1].Selected = true;
                if(_drow["Responsible"].ToString()=="1")
                    rd_resp.Items[0].Selected = true;
                else if(_drow["Responsible"].ToString()=="0")
                    rd_resp.Items[1].Selected = true;
                txt_p1.Text = _drow["P1"].ToString();
                txt_p2.Text = _drow["P2"].ToString();
                txt_p3.Text = _drow["P3"].ToString();
                txt_p4.Text = _drow["P4"].ToString();
                txt_p5.Text = _drow["P5"].ToString();
                txt_p6.Text = _drow["P6"].ToString();
                txt_p7.Text = _drow["P13"].ToString();
                txt_p8.Text = _drow["P14"].ToString();
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
        //private bool Validation()
        //{
        //    if (IsNumeric(txt_p1.Text) == false)
        //    {

        //    }
        //}

        protected void txt_p1_TextChanged(object sender, EventArgs e)
        {
            if (IsNumeric(txt_p1.Text) == false)
                txt_p1.Text = "0";
        }

        protected void txt_p2_TextChanged(object sender, EventArgs e)
        {
            if (IsNumeric(txt_p2.Text) == false)
                txt_p2.Text = "0";
        }

        protected void txt_p3_TextChanged(object sender, EventArgs e)
        {
            if (IsNumeric(txt_p3.Text) == false)
                txt_p3.Text = "0";
        }

        protected void txt_p4_TextChanged(object sender, EventArgs e)
        {
            if (IsNumeric(txt_p4.Text) == false)
                txt_p4.Text = "0";
        }

        protected void txt_p5_TextChanged(object sender, EventArgs e)
        {
            if (IsNumeric(txt_p5.Text) == false)
                txt_p5.Text = "0";
        }

        protected void txt_p6_TextChanged(object sender, EventArgs e)
        {
            if (IsNumeric(txt_p6.Text) == false)
                txt_p6.Text = "0";
        }
        protected void txt_p7_TextChanged(object sender, EventArgs e)
        {
            if (IsNumeric(txt_p7.Text) == false)
                txt_p7.Text = "0";
        }
        protected void txt_p8_TextChanged(object sender, EventArgs e)
        {
            if (IsNumeric(txt_p8.Text) == false)
                txt_p8.Text = "0";
        }
        private void Update_System_List_Rpt()
        {
            BLL_Dml _objbll = new BLL_Dml();
            DLL_Dml _objdll = new DLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_CCAD";
            _clscassheet _objcas = new _clscassheet();
            for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            {

                GridView _details = (GridView)mymaster.Rows[i].FindControl("mydetails");
                foreach (GridViewRow _drow in _details.Rows)
                {
                    GridView _inner_main = (GridView)_drow.FindControl("mydetails1");
                    foreach (GridViewRow _drow1 in _inner_main.Rows)
                    {
                        _objcas.sys = Convert.ToInt32(_drow1.Cells[24].Text);
                        _objcas.p7 = _drow1.Cells[14].Text;
                        _objcas.p8 = _drow1.Cells[15].Text;
                        _objcas.p9 = _drow1.Cells[16].Text;
                        _objcas.p10 = _drow1.Cells[17].Text;
                        _objcas.p11 = _drow1.Cells[18].Text;
                        _objcas.p12 = _drow1.Cells[19].Text;
                        _objcas.p13 = _drow1.Cells[20].Text;
                        _objcas.p14 = _drow1.Cells[21].Text;
                        _objbll.Update_System_List(_objcas, _objdb);
                    }
                    GridView _inner_sub = (GridView)_drow.FindControl("mydetails2");
                    foreach (GridViewRow _drow2 in _inner_sub.Rows)
                    {
                        GridView _inner_sub1 = (GridView)_drow2.FindControl("mydetails3");
                        foreach (GridViewRow _drow3 in _inner_sub1.Rows)
                        {
                            _objcas.sys = Convert.ToInt32(_drow3.Cells[24].Text);
                            _objcas.p7 = _drow3.Cells[14].Text;
                            _objcas.p8 = _drow3.Cells[15].Text;
                            _objcas.p9 = _drow3.Cells[16].Text;
                            _objcas.p10 = _drow3.Cells[17].Text;
                            _objcas.p11 = _drow3.Cells[18].Text;
                            _objcas.p12 = _drow3.Cells[19].Text;
                            _objcas.p13 = _drow3.Cells[20].Text;
                            _objcas.p14 = _drow3.Cells[21].Text;
                            _objbll.Update_System_List(_objcas, _objdb);
                        }
                    }
                }



            }
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            Update_System_List_Rpt();
            Response.Redirect("ReportView.aspx");
        }
    }
}
