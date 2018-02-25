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
using System.Data.SqlClient;
using System.Collections.Generic;
using AjaxControlToolkit;

namespace CmlTechniques
{
    public partial class Cassheet_DataEntry23 : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        //public static DataTable _dtfilter;
        public static DataTable _dtresult;
        public static bool _exp;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                lblhead.Text = "CAS ELV Security Management System Commissioning Activity Schedule";

                Session["uid"] = "jose.joseph@cmlgroup.ae";
                Session["sch"] = "23";

                lbluid.Text = (string)Session["uid"];
                //string _prm = Request.QueryString[0].ToString();
                string _prm = "12761_S23";
                lblprj.Text = _prm.Substring(0, _prm.IndexOf("_S"));
                    Session["sch"] = _prm.Substring(_prm.IndexOf("_S") + 2);
                lblsch.Text = (string)Session["sch"];

               load_cas_sys();
                Load_Master();
                Load_InitialData();
                _exp = false;
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
                _CookieSch.Value = (string)Session["sch"];
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
           _dtMaster = new DataTable();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32(lblsch.Text);
            _objcas.prj_code = lblprj.Text;
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
            _dtresult = _dtMaster;

        }
        private void Load_InitialData()
        {
            if (_dtresult == null) return;
            DataTable _dtable = new DataTable();
            _dtable.Columns.Add("sys_id", typeof(string));
            _dtable.Columns.Add("sys_name", typeof(string));
            var distinctRows = (from DataRow dRow in _dtresult.Rows
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
        protected void mymaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _sys_id = (Label)e.Row.FindControl("lbSys_Id");
                DataTable _dtdetails = new DataTable();
                _dtdetails.Columns.Add("e_b_ref", typeof(string));
                _dtdetails.Columns.Add("Des", typeof(string));
                _dtdetails.Columns.Add("C_id", typeof(int));
                _dtdetails.Columns.Add("Sys_id", typeof(int));
                _dtdetails.Columns.Add("Sys_name", typeof(string));

                var _details = from _data in _dtresult.AsEnumerable()
                               where _data.Field<int>("Sys_Id") == Convert.ToInt32(_sys_id.Text)
                               select _data;
                foreach (var row in _details)
                {
                    DataRow _row = _dtdetails.NewRow();
                    _row[0] = row["e_b_ref"].ToString();
                    _row[1] = row["Des"].ToString();
                    _row[2] = row["C_id"].ToString();
                    _row[3] = row["Sys_id"].ToString();
                    _row[4] = row["Sys_name"].ToString();
                    _dtdetails.Rows.Add(_row);
                }
                //Accordion _acrd = (Accordion)e.Row.FindControl("Accordion1");
                GridView _mydetails = (GridView)e.Row.FindControl("mydetails");
                _mydetails.DataSource = _dtdetails;
                _mydetails.DataBind();
                //Button _btn = (Button)e.Row.FindControl("Button1");
                //_btn.Text = "+";
                // _mydetails.Visible = false;
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
                //_mydetails.Style.Add("display", "block");
                _btn.Text = "-";
            }
            else if (_btn.Text == "-")
            {
                _mydetails.Visible = false;
                //_mydetails.Style.Add("display", "none");
                _btn.Text = "+";
            }
            _exp = true;
        }
        protected void mydetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView _mydetails = (GridView)gvRow.FindControl("mydetails");
            int _idx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = _mydetails.Rows[_idx];
            // _mydetails.Rows[_idx].Style.Add("background-color", "yellow");
            //int index = gvRow.RowIndex;
            TableCell _item1 = _srow.Cells[13];
            TableCell _item2 = _srow.Cells[14];
            // TableCell _item3 = _srow.Cells[2];
            //string _file = _item.Text;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _file + "');", true);
            Session["casid"] = _item1.Text;
            Session["Sys"] = _item2.Text;
            Session["idx"] = _idx.ToString();
            btnDummy_ModalPopupExtender.Show();
            //arrange_edit();

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
        protected void btnadd_Click(object sender, EventArgs e)
        {
            if (drpackage.SelectedItem.Text == "--Package--")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Package');", true);
                return;
            }
            else if (txtengref.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Enter Report.Ref');", true);
                return;
            }
            else if (txt_title.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Report');", true);
                return;
            }

           
            
            add_initial_data();
            Load_Master();
            Load_InitialData();
 
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
             if (upreff.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Enter Report.Ref');", true);
                return;
            }
            else if (uptitle.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Report');", true);
                return;
            }
            
            Edit_Inidata();
            Load_Master();
            Load_InitialData();

            btnDummy_ModalPopupExtender.Hide();
        }
        protected void btndelete_Click(object sender, EventArgs e)
        {
            Delete_Inidata();
            Load_Master();
            Load_InitialData();
            //Open_Details(0);
            btnDummy_ModalPopupExtender.Hide();
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender.Hide();
        }
        protected void btnnewflevel_Click(object sender, EventArgs e)
        {
            txtflvl.Text = String.Empty;
            btnDummy_ModalPopupExtender1.Show();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (txtflvl.Text.Length <= 0) return;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.f_level = txtflvl.Text;
            _objbll.Create_FLevel(_objcas, _objdb);
           //// Load_Flvl();
            btnDummy_ModalPopupExtender1.Hide();
        }
        protected void btncancel1_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender1.Hide();
        }
        protected void drflevel__SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpackage.SelectedItem.Text == "--Package--") return;
           // Get_SeqNo();
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

        protected void chkrow_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            GridViewRow row = (GridViewRow)checkbox.NamingContainer;
            if (checkbox.Checked == true)
                row.BackColor = System.Drawing.Color.Gainsboro;
            else
                row.BackColor = System.Drawing.Color.White;
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            {
                GridView _details = (GridView)mymaster.Rows[i].FindControl("mydetails");
                for (int j = 0; j <= _details.Rows.Count - 1; j++)
                {
                    CheckBox checkbox = (CheckBox)_details.Rows[j].FindControl("chkrow");
                    if (checkbox.Checked == true)
                    {
                        count += 1;
                        Session["casid"] = _details.Rows[j].Cells[4].Text;
                        Session["Sys"] = _details.Rows[j].Cells[5].Text;
                        Session["idx"] = j.ToString();

                        uptitle.Text = _details.Rows[j].Cells[2].Text;
                        upreff.Text = _details.Rows[j].Cells[3].Text;

                      
                    }
                }

            }
            if (count == 0) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');", true);
            else if (count > 1)
            {
                //Add_MultiEdit_temp();
                //Response.Redirect("CasSheet/Edit_M_2.aspx");
            }
            else if (count == 1)
            {
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["MemberId"] + "',7);", true);
                btnDummy_ModalPopupExtender.Show();
                //arrange_edit();
            }
        }
        private void Add_MultiEdit_temp()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();
            for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            {
                GridView _details = (GridView)mymaster.Rows[i].FindControl("mydetails");
                for (int j = 0; j <= _details.Rows.Count - 1; j++)
                {
                    CheckBox checkbox = (CheckBox)_details.Rows[j].FindControl("chkrow");
                    if (checkbox.Checked == true)
                    {
                        _objcls.sch = Convert.ToInt32(_details.Rows[j].Cells[4].Text);
                        _objcls.sys = Convert.ToInt32(_details.Rows[j].Cells[5].Text);
                        _objcls.uid = lbluid.Text;
                        _objcls.action = 1;
                        _objbll.Add_Cas_MultiEdit_Temp(_objcls, _objdb);
                    }
                }

            }
        }
        protected void btndelete1_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            {
                GridView _details = (GridView)mymaster.Rows[i].FindControl("mydetails");
                for (int j = 0; j <= _details.Rows.Count - 1; j++)
                {
                    CheckBox checkbox = (CheckBox)_details.Rows[j].FindControl("chkrow");
                    if (checkbox.Checked == true)
                    {
                        count += 1;
                        Session["casid"] = _details.Rows[j].Cells[4].Text;
                        Session["Sys"] = _details.Rows[j].Cells[5].Text;
                        Delete_Inidata();
                    }
                }

            }
            if (count == 0) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');", true);
            else
            {
                string _msg = count.ToString() + " Row(s) Deleted";
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _msg + "');", true);
                Load_Master();
                Load_InitialData();
                //Open_Details(0);
            }
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

        private void FnSearch()
        {
            _dtresult = new DataTable();
            _dtresult.Columns.Add("e_b_ref", typeof(string));
            _dtresult.Columns.Add("Des", typeof(string));
            _dtresult.Columns.Add("C_id", typeof(int));
            _dtresult.Columns.Add("Sys_id", typeof(int));
            _dtresult.Columns.Add("Sys_name", typeof(string));

            var _result = from _data in _dtMaster.AsEnumerable()
                          where _data.Field<string>("E_b_ref").ToUpper().IndexOf(txtsearch.Text.ToUpper()) >= 0
                          select _data;

            foreach (var row in _result)
            {
                DataRow _row = _dtresult.NewRow();
                _row[0] = row["e_b_ref"].ToString();
                _row[1] = row["Des"].ToString();
                _row[2] = row["C_id"].ToString();
                _row[3] = row["Sys_id"].ToString();
                _row[4] = row["Sys_name"].ToString();
                _dtresult.Rows.Add(_row);
            }
            Load_InitialData();
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            if (btnsearch.Text == "Search")
            {
                //FnSearch();
                for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
                {
                    GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
                    Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
                    _mydetails.Visible = true;
                    _btn.Text = "-";
                }
                btnsearch.Text = "Reset";
            }
            else
            {
                txtsearch.Text = String.Empty;
                FnSearch();
                for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
                {
                    GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
                    Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
                    _mydetails.Visible = false;
                    _btn.Text = "+";
                }
                btnsearch.Text = "Search";
            }
        }

        protected void btnimport_Click(object sender, EventArgs e)
        {

            // string _url="";
            //if((string)Session["sch"]=="112")
            //    _url = "CMS/Import.aspx?id=" + lblsch.Text + "_" +  lblprj.Text;
            //else
            //    _url = "CMS/Import.aspx?id=" + (string)Session["sch"] + "_" +  lblprj.Text;
            
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('"+ _url +"','','left=300,top=200,width=500,height=400,menubar=0,toolbar=0,scrollbars=1,status=0,resizable=0');", true);
        }
        protected void btnrefresh_Click(object sender, ImageClickEventArgs e)
        {
            Load_Master();
            Load_InitialData();
        }
        
        protected void btnaddm_Click(object sender, EventArgs e)
        {
           // Response.Redirect("CasSheet/Add_M_2.aspx");
        }

        protected void txtengref_TextChanged(object sender, EventArgs e)
        {


        }
        protected void add_initial_data()
        {

            string _sys = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.c_s_id = Convert.ToInt32(lblsch.Text);
            _objcas.prj_code = lblprj.Text;
            _objcas.uid = lbluid.Text;
            _objcas.sys = Convert.ToInt32(_sys);
            _objcas.reff = txtengref.Text;
            _objcas.b_zone = "";
            _objcas.cate = "";
            _objcas.f_level = "";
            _objcas.seq_no = 0;
            _objcas.desc = txt_title.Text;
            _objcas.loca = "";
            _objcas.p_power_to = "";
            _objcas.fed_from = "";
            _objcas.sub_st = "";
            _objcas.s_c_m = "";
            _objcas.dev1 = "";

            _objcas.dev2 = "";
            _objcas.dev3 = "";
            _objcas.mode = 1;
            _objcas.cas_id = 0;
            _objcas.Position = Convert.ToInt32(txtitmno.Text);
            _objbll.Cassheet_Master(_objcas, _objdb);



        }
        protected void drpackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpackage.SelectedItem.Text != "--Package--")
            {
                //txtcate.Text = drpackage.SelectedItem.Value.Substring(drpackage.SelectedItem.Value.IndexOf("_C") + 2);
                //Get_Position();
                //Load_Flvl();
            }

        }
        protected void load_cas_sys()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();
            _objcls.sch = Convert.ToInt32((string)Session["sch"]);
            DataTable _dt0 = _objbll.Load_cas_sys(_objcls, _objdb);
            DataTable _dt1 = new DataTable();
            _dt1.Columns.Add("_id");
            _dt1.Columns.Add("_name");
            var _List = from o in _dt0.AsEnumerable()
                        where o.Field<string>(3) == lblprj.Text
                        select o;

            foreach (var row in _List)
            {
                DataRow _myrow = _dt1.NewRow();
                _myrow[0] = row[0].ToString() + "_C" + row[2].ToString();
                _myrow[1] = row[1].ToString();
                _dt1.Rows.Add(_myrow);
            }
            drpackage.DataSource = _dt1;
            drpackage.DataTextField = "_name";
            drpackage.DataValueField = "_id";
            drpackage.DataBind();
            drpackage.Items.Insert(0, "--Package--");
        }
        private void Edit_Inidata()
        {


            //uplb2.Text = updescr.Text;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.c_s_id = 0;
            _objcas.prj_code = lblprj.Text;
            _objcas.uid = lbluid.Text;
            _objcas.sys = Convert.ToInt32((string)Session["Sys"]);
            _objcas.reff = upreff.Text;
            _objcas.b_zone = "";
            _objcas.cate = "";
            _objcas.f_level = "";
            _objcas.seq_no = 0;
            _objcas.desc = uptitle.Text;
            _objcas.loca = ""; ;
            _objcas.p_power_to = "";
            _objcas.fed_from = "";
            _objcas.sub_st = "";
            _objcas.s_c_m = "";
            _objcas.dev1 = "";
            _objcas.dev2 = "";
            _objcas.dev3 = "0";
            _objcas.mode = 0;
            _objcas.cas_id = Convert.ToInt32((string)Session["casid"]);
            _objbll.Cassheet_Master(_objcas, _objdb);
        }
        private void Delete_Inidata()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.c_s_id = 0;
            _objcas.prj_code = lblprj.Text;
            _objcas.uid = lbluid.Text;
            _objcas.sys = Convert.ToInt32((string)Session["Sys"]);
            _objcas.reff = "";
            _objcas.b_zone = "";
            _objcas.cate = "";
            _objcas.f_level = "";
            _objcas.seq_no = 0;
            _objcas.desc = "";
            _objcas.loca = "";
            _objcas.p_power_to = "";
            _objcas.fed_from = "";
            _objcas.sub_st = "";
            _objcas.s_c_m = "";
            _objcas.dev1 = "";
            _objcas.dev2 = "0";
            _objcas.dev3 = "0";
            _objcas.mode = 2;
            _objcas.cas_id = Convert.ToInt32((string)Session["casid"]);
            _objbll.Cassheet_Master(_objcas, _objdb);
        }
    }
    }
