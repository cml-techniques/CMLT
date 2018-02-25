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
    public partial class Commissioning_Testing1 : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtresult;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _prm + "');", true);
                Session["project"] = _prm.Substring(0, _prm.IndexOf("_S"));
                Session["sch"] = _prm.Substring(_prm.IndexOf("_S") + 2);
                //load_cas_sys();
                Load_Master();
                Session["filter"] = "no";
                Session["zone"] = "All";
                Session["flvl"] = "All";
                Session["cat"] = "All";
                Session["fed"] = "All";
                Session["loc"] = "All";
                //Load_InitialData();
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
                //if (Request.Cookies["project"] != null)
                //{
                //    Session["project"] = Server.HtmlEncode(Request.Cookies["project"].Value);
                //}
                //if (Request.Cookies["sch"] != null)
                //{
                //    Session["sch"] = Server.HtmlEncode(Request.Cookies["sch"].Value);
                //}
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
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32((string)Session["sch"]);
            _objcas.prj_code = (string)Session["project"];
            _dtMaster = _objbll.Load_casMain_SP(_objcas, _objdb);
            _dtresult = _dtMaster;
            mydetails.DataSource = _dtMaster;
            mydetails.DataBind();
        }
        protected void mydetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            //GridView _mydetails = (GridView)gvRow.FindControl("mydetails");
            int _idx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mydetails.Rows[_idx];
            TableCell _item1 = _srow.Cells[13];
            //TableCell _item2 = _srow.Cells[14];
            TableCell _eref = _srow.Cells[2];
            Session["casid"] = _item1.Text;
            string _title = "ENG.REF : " + _eref.Text;
            _33lbl.Text = _title;
            Load_cassheet_details();
            btnDummy_ModalPopupExtender.Show();

        }
        private void Load_cassheet_details()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32((string)Session["sch"]);
            _objcas.prj_code = (string)Session["project"];
            DataTable _dt = _objbll.Load_casMain_SP(_objcas, _objdb);
            var result = from o in _dt.AsEnumerable()
                         where o.Field<int>(0) == Convert.ToInt32((string)Session["casid"])
                         select o;
            foreach (var row in result)
            {
                if ((string)Session["sch"] == "33")
                {
                    _33ipr.Text = row[20].ToString();
                    _33itype.Text = row[21].ToString();
                    _33s1.Text = row[22].ToString();
                    _33s2.Text = row[23].ToString();
                    _33s3.Text = row[24].ToString();
                    if (row[25].ToString() != "")
                        dr_ready.Items.FindByText(row[25].ToString()).Selected = true;
                    _33itc.Text = row[26].ToString();
                    _33accept1.Text = row["accept1"].ToString();
                    _33filed1.Text = row["filed1"].ToString();
                    _33commts.Text = row[16].ToString();
                    _33actby.Text = row[17].ToString();
                    _33actdt.Text = row[18].ToString();
                }
            }
        }
        protected void mydetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[13].Visible = false;
            //e.Row.Cells[14].Visible = false;

            //e.Row.Cells[0].Enabled = false;
            //if (e.Row.Cells[1].Text != "") return;
            //if (e.Row.Cells[0].Text != "")
            //    e.Row.Cells[0].Text = "hai" + e.Row.Cells[0].Text;
            e.Row.Cells[1].Text = (e.Row.DataItemIndex + 1).ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[2].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                //e.Row.Cells[3].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                //e.Row.Cells[4].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[7].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[8].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[9].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[10].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                //e.Row.Cells[2].Attributes.Add("style", "word-wrap:break-word");
                //e.Row.Cells[3].Attributes.Add("style", "word-wrap:break-word");
                //e.Row.Cells[4].Attributes.Add("style", "word-wrap:break-word");
                //e.Row.Cells[7].Attributes.Add("style", "word-wrap:break-word");
                //e.Row.Cells[8].Attributes.Add("style", "word-wrap:break-word");
                //e.Row.Cells[9].Attributes.Add("style", "word-wrap:break-word");
            }


        }
        protected void _33btnupdate_Click(object sender, EventArgs e)
        {
            Update("", _33ipr.Text, _33itype.Text, _33s1.Text, _33s2.Text, _33s3.Text, dr_ready.SelectedItem.Text, _33itc.Text, "", "", "", "", "", "", "", "", "", "", _33accept1.Text, "", _33filed1.Text, "", _33commts.Text, _33actby.Text, _33actdt.Text);
            btnDummy_ModalPopupExtender.Hide();
        }

        protected void _33btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender.Hide();
        }
        private void Update(string pwron, string test1, string test2, string test3, string test4, string test5, string test6, string test7, string test8, string test9, string test10, string test11, string test12, string tested1, string tested2, string compld1, string compld2, string dvce, string accept1, string accept2, string filed1, string filed2, string comts, string actby, string actdt)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcls = new _clscassheet();
            _objcls.cas_id = Convert.ToInt32((string)Session["casid"]);
            _objcls.test1 = test1;
            _objcls.test2 = test2;
            _objcls.test3 = test3;
            _objcls.test4 = test4;
            _objcls.test5 = test5;
            _objcls.test6 = test6;
            _objcls.test7 = test7;
            _objcls.test11 = test8;
            _objcls.test12 = test10;
            _objcls.test13 = test11;
            _objcls.test14 = test12;
            _objcls.test15 = "";
            _objcls.tested1 = tested1;
            _objcls.test8 = compld1;
            _objcls.tested2 = tested2;
            _objcls.test9 = compld2;
            _objcls.comm = comts;
            _objcls.act_by = actby;
            _objcls.act_date = actdt;
            _objcls.compl = "";
            _objcls.test10 = test9;
            _objcls.per_com1 = per_com1();
            _objcls.per_com2 = 0;
            _objcls.per_com3 = 0;
            _objcls.per_com4 = 0;
            _objcls.power_on = pwron;
            _objcls.dev1 = dvce;
            _objcls.accept1 = accept1;
            _objcls.accept2 = accept2;
            _objcls.filed1 = filed1;
            _objcls.filed2 = filed2;
            _objcls.per_com5 = 0;
            _objcls.per_com6 = 0;
            _objcls.per_com7 = 0;
            _objcls.per_com8 = 0;
            _objcls.per_com9 = 0;
            _objcls.per_com10 = 0;
            _objbll.Cassheet_update(_objcls, _objdb);
        }
        protected decimal per_com1()
        {

            decimal _percentage = 0;
            if ((string)Session["sch"] == "33")
            {
                if (_33itc.Text != "")
                    _percentage = 1;
            }
           
            return _percentage;
        }
    }
}
