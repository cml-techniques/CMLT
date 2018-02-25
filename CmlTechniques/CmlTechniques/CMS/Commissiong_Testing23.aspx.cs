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

namespace CmlTechniques.CMS
{
    public partial class Commissiong_Testing23 : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtfilter;
        public static DataTable _dtresult;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                Session["project"] = _prm.Substring(0, _prm.IndexOf("_S"));
                Session["sch"] = _prm.Substring(_prm.IndexOf("_S") + 2);

                lbluid.Text = (string)Session["uid"];
                lblprj.Text = _prm.Substring(0, _prm.IndexOf("_S"));
                    lblsch.Text = _prm.Substring(_prm.IndexOf("_S") + 2);
                Load_Master();
                Load_InitialData();
                Hide_Details();


                // _exp = false;

                lblhead.Text = "CAS Security Management System Commissioning Activity Schedule ";

            }
        }
        private void Hide_Details()
        {
            for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            {
                GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
                Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
                _mydetails.Visible = false;
                _btn.Text = "+";
            }
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
        void _Create_Cookies()
        {
            if (Request.Browser.Cookies)
            {
                HttpCookie _CookieSch = new HttpCookie("sch");
                _CookieSch.Value = lblsch.Text;
                _CookieSch.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_CookieSch);
                HttpCookie _CookieSrv = new HttpCookie("srv");
                _CookieSrv.Value = (string)Session["srv"];
                _CookieSrv.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_CookieSrv);

            }
            else
                return;
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

                _dtresult = _dtMaster;
            //_dtfilter = _dtresult;
        }
        private void Load_InitialData()
        {
            if (_dtresult == null) return;
            DataTable _dtable = new DataTable();
            _dtable.Columns.Add("sys_id", typeof(string));
            _dtable.Columns.Add("sys_name", typeof(string));
            var distinctRows = (from DataRow dRow in _dtresult.Rows
                                orderby dRow["possition"]
                                select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"] }).Distinct();
            foreach (var row in distinctRows)
            {
                DataRow _row = _dtable.NewRow();
                _row[0] = row.col1.ToString();
                _row[1] = row.col2.ToString();
                _dtable.Rows.Add(_row);
            }
            mymaster.DataSource = _dtable;
            mymaster.DataBind();
            //Load_Filtering_Elements();
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
        void SetCheckedBoxChecked(TextBox txt, System.Web.UI.HtmlControls.HtmlInputCheckBox chk)
        {
            //if (txt.Text == "N/A") chk.Checked = true;
            chk.Checked = (txt.Text == "N/A" ? true : false);
            txt.Enabled = (chk.Checked ? false : true);
        }
        protected void mydetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView _mydetails = (GridView)gvRow.FindControl("mydetails");
            int _idx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = _mydetails.Rows[_idx];
            //int index = gvRow.RowIndex;
            TableCell _item1 = _srow.Cells[4];
            //TableCell _cat = _srow.Cells[4];
            TableCell _sys_name = _srow.Cells[5];
            TableCell _eref = _srow.Cells[2];
            string _title = "PACKAGE NAME : " + _sys_name.Text + ", ENG.REF : " + _eref.Text;
            // TableCell _item3 = _srow.Cells[2];
            //string _file = _item.Text;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _file + "');", true);
            Session["casid"] = _item1.Text;
            Session["idx"] = _idx.ToString();
            //Session["cat"] = _cat.Text;
            //arrange_testing();
            // ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('I'm Here!');", true);

            // Config_TestLabel();
            Load_cassheet_details();
            //if (lblsch.Text == "1" || lblsch.Text == "5") { btnDummy_ModalPopupExtender4.Show(); _5lbl.Text = _title; }
            //else if (lblsch.Text == "2")
            //{
            //    if (lblprj.Text == "ASAO" && (string)Session["cat"] == "MRMU")
            //    {
                    //_2tor.Text = "N/A";
                    //_2vt.Text = "N/A";
                    //chk_2tor.Checked = true;
                    //chk_2vt.Checked = true;
                //}
                btnDummy_ModalPopupExtender1.Show(); 
            //_2lbl.Text = _title;
            //}
            
        }
        protected void mydetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[1].Text = (e.Row.DataItemIndex + 1).ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Attributes.Add("style", "word-wrap:break-word");
                e.Row.Cells[3].Attributes.Add("style", "word-wrap:break-word");

            }
            
        }
       
        private void Update(string test1, string test2, string test3,string actby, string comts)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();
            _objcls.cas_id = Convert.ToInt32((string)Session["casid"]);
            _objcls.power_on = "";
            _objcls.test1 = test1;
            _objcls.test2 = test2;
            _objcls.test3 = test3;
            _objcls.test4 = "";
            _objcls.test5 = "";
            _objcls.test6 = "";
            _objcls.test7 = "";
            _objcls.test11 = "";
            _objcls.test12 = "";
            _objcls.test13 = "";
            _objcls.test14 = "";
            _objcls.test15 = "";
            _objcls.tested1 = "";
            _objcls.test8 = "";
            _objcls.tested2 = "";
            _objcls.test9 = "";
            _objcls.comm = comts;
            _objcls.act_by = actby;
            _objcls.act_date = "";
            _objcls.compl = "";
            _objcls.test10 = "";
            _objcls.per_com1 = per_com1();
            _objcls.per_com2 = 0;
            _objcls.per_com3 = 0;
            _objcls.per_com4 = 0;
            _objcls.power_on = "";;
            _objcls.dev1 = "";;
            _objcls.accept1 = "";
            _objcls.accept2 = "";
            _objcls.filed1 = "";
            _objcls.filed2 = "";
            _objcls.per_com5 = 0;
            _objcls.per_com6 =0;
            _objcls.per_com7 = 0;
            _objcls.per_com8 = 0;
            _objcls.per_com9 =0;
            _objcls.per_com10 = 0;
            _objbll.Cassheet_update(_objcls, _objdb);
        }
        private bool DateValidation(string dateString)
        {
            DateTime dateValue;
            string[] format = new string[] { "dd/MM/yyyy" };
            string[] format1 = new string[] { "dd/MM/yy" };
            if (DateTime.TryParseExact(dateString, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out dateValue))
                return true;
            else if (DateTime.TryParseExact(dateString, format1, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out dateValue))
                return true;
            else
                return false;

        }
        protected decimal per_com1()
        {
            decimal _percentage = 0;

            if (DateValidation(_acctby.Text) == true) _percentage = 1;
            return _percentage;

        }
          protected decimal per_com2()
        {
            decimal _percentage = 0;

              if ((!string.IsNullOrEmpty(_wReference.Text) )&& _wReference.Text != "N/A") _percentage = 100;
              return _percentage;
        }
          protected decimal per_com3()
          {
              decimal _percentage = 0;

              if ((!string.IsNullOrEmpty(_Status.Text)) && _Status.Text != "N/A") _percentage = 100;
              return _percentage;
          }
          protected decimal per_com4()
          {
              decimal _percentage = 0;

              if (DateValidation(_Status.Text) == true) _percentage = 100;
              return _percentage;

          }

        protected void btnexpand_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            {
                GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
                Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
                _mydetails.Visible = true;
                _btn.Text = "-";
            }
        }

        protected void btncollapse_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            {
                GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
                Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
                _mydetails.Visible = false;
                _btn.Text = "+";
            }
        }
        private void Load_cassheet_details()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32(lblsch.Text);
            _objcas.prj_code = lblprj.Text;
            DataTable _dt = _objbll.Load_casMain_Edit(_objcas, _objdb);
            var result = from o in _dt.AsEnumerable()
                         where o.Field<int>(0) == Convert.ToInt32((string)Session["casid"])
                         select o;
            foreach (var row in result)
            {
                if (lblsch.Text == "23")
                {

                    _rsubmit.Text = row["test1"].ToString();
                    _wReference.Text = row["test2"].ToString();
                    _Status.Text = row["test3"].ToString();
                    _acctby.Text = row["Act_by"].ToString();
                    _commts.Text = row["Comm"].ToString();


                    SetCheckedBoxChecked(_rsubmit, chk_rsubmit);
                    SetCheckedBoxChecked(_wReference, chk_wReference);
                    SetCheckedBoxChecked(_Status, chk_Status);
                    SetCheckedBoxChecked(_acctby, chk_acctby);


                }
            }
        }
        protected void mymaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _sys_id = (Label)e.Row.FindControl("lbSys_Id");
                DataTable _dtdetails = new DataTable();
                var _details = from _data in _dtresult.AsEnumerable()
                               where _data.Field<int>("Sys_Id") == Convert.ToInt32(_sys_id.Text)
                               select _data;
                _dtdetails = _details.Any() ? _details.CopyToDataTable() : _dtMaster.Clone();
                GridView _mydetails = (GridView)e.Row.FindControl("mydetails");
                _mydetails.DataSource = _dtdetails;
                _mydetails.DataBind();
            }
        }
        private string SeqNo(string No)
        {
            string _nNo = No;
            if (No.Length > 3)
                _nNo = No.Substring(0, 3);
            else
            {
                for (int i = 0; i < (3 - No.Length); i++)
                {
                    _nNo = "0" + _nNo;
                }
            }
            return _nNo;
        }
        protected void mymaster_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void _btnupdate_Click(object sender, EventArgs e)
        {
            Update(_rsubmit.Text, _wReference.Text, _Status.Text, _acctby.Text, _commts.Text);
            btnDummy_ModalPopupExtender1.Hide(); 
            

        }

        protected void _btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender1.Hide(); 
        }
    }
}
 