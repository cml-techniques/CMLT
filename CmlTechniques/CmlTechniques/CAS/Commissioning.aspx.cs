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

namespace CmlTechniques.CAS
{
    public partial class Commissioning : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        //public static DataTable _dtfilter;
        public static DataTable _dtresult;
        public static bool _exp;
        protected void Page_Load(object sender, EventArgs e)
        {
            //_ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                lblprj.Text = _prm.Substring(0, _prm.IndexOf("_S"));
                lblsch.Text = _prm.Substring(_prm.IndexOf("_S") + 2);
                settings();
                Load_Master();
                Session["filter"] = "no";
                Session["zone"] = "All";
                Session["flvl"] = "All";
                Session["cat"] = "All";
                Session["fed"] = "All";
                Session["loc"] = "All";
                Session["des"] = "All";
                Load_InitialData();
                //Load_Filtering_Elements();
                Hide_Details();

                _exp = false;
            }
        }
        protected void settings()
        {

            if ((string)Session["sch"] == "10")
            {
                lbl1.Text = "";
                lbl2.Text = "NO.OF DEVICES";
                lbl3.Text = "";
                lbnum.Text = "NO.OF INTERFACES";
                drfed.Style.Add("display", "none");
                    lblhead.Text = "6.2.1 - Fire Alarm and Fire Telephone Communication System Commissioning Activity Schedule";
                    lbl1.Text = "LOOP CIRCUIT NO.";
                td_lbl3.Visible = false;td_1.Visible = false;tddes.Visible = false; td_lbldes.Visible = false;
            }
            else if ((string)Session["sch"] == "11")
            {
                drfed.Style.Add("display", "none");
                lblhead.Text = "6.2.10 - Public Address and Mass Notification System Commissioning Activity Schedule";
                lbloc.Text = "LOCATION";
                lbnum.Text = "NO.OF DEVICES PER CIRCUIT";
                td_lbl2.Visible = false; td_2.Visible = false;
                td_lbldes.Visible = false; tddes.Visible = false;
                td_lbl3.Visible = false;
                td_1.Visible = false;
                td_lbl1.Visible = false;
                td_0.Visible = false;
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
            _objcas.prj_code = lblprj.Text;
            _dtMaster = _objbll.Load_cassheet_data(_objcas, _objdb);
            _dtresult = _dtMaster;
        }
        private void Load_InitialData()
        {
            DataTable _dtable = new DataTable();
            _dtable.Columns.Add("Panel_Id", typeof(string));
            _dtable.Columns.Add("Panel_Ref", typeof(string));
            var distinctRows = (from DataRow dRow in _dtresult.Rows
                                where dRow["Panel_Parent"].ToString() == "0"
                                select new { col1 = dRow["Panel_Id"], col2 = dRow["Panel_Ref"] }).Distinct();
            foreach (var row in distinctRows)
            {
                DataRow _row = _dtable.NewRow();
                _row[0] = row.col1.ToString();
                _row[1] = row.col2.ToString();
                _dtable.Rows.Add(_row);
            }
            reptr_main.DataSource = _dtable;
            reptr_main.DataBind();
            //mymaster.DataSource = _dtable;
            //mymaster.DataBind();
            // Load_Filtering_Elements();

        }
        protected void mymaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _sys_id = (Label)e.Row.FindControl("lbSys_Id");
                DataTable _dtdetails = new DataTable();
                _dtdetails.Columns.Add("e_b_ref", typeof(string));
                _dtdetails.Columns.Add("B_Z", typeof(string));
                _dtdetails.Columns.Add("Cat", typeof(string));
                _dtdetails.Columns.Add("F_lvl", typeof(string));
                _dtdetails.Columns.Add("Seq_No", typeof(string));
                _dtdetails.Columns.Add("Loc", typeof(string));
                _dtdetails.Columns.Add("P_P_to", typeof(string));
                _dtdetails.Columns.Add("F_from", typeof(string));
                _dtdetails.Columns.Add("Substation", typeof(string));
                _dtdetails.Columns.Add("devices1", typeof(string));
                _dtdetails.Columns.Add("C_id", typeof(int));
                _dtdetails.Columns.Add("Sys_name", typeof(string));
                _dtdetails.Columns.Add("Sys_id", typeof(int));
                _dtdetails.Columns.Add("Des", typeof(string));
                var _details = from _data in _dtresult.AsEnumerable()
                               where _data.Field<int>("Sys_Id") == Convert.ToInt32(_sys_id.Text)
                               select _data;
                foreach (var row in _details)
                {
                    DataRow _row = _dtdetails.NewRow();
                    _row[0] = row["e_b_ref"].ToString();
                    _row[1] = row["B_Z"].ToString();
                    _row[2] = row["Cat"].ToString();
                    _row[3] = row["F_lvl"].ToString();
                    _row[4] = SeqNo(row["Seq_No"].ToString());
                    _row[5] = row["Loc"].ToString();
                    _row[6] = row["p_p_to"].ToString();
                    _row[7] = row["F_from"].ToString();
                    _row[8] = row["Substation"].ToString();
                    _row[9] = row["devices1"].ToString();
                    _row[10] = row["C_id"].ToString();
                    _row[11] = row["Sys_name"].ToString();
                    _row[12] = row["Sys_id"].ToString();
                    _row[13] = row["Des"].ToString();
                    _dtdetails.Rows.Add(_row);
                }
                GridView _mydetails = (GridView)e.Row.FindControl("mydetails");
                _mydetails.DataSource = _dtdetails;
                _mydetails.DataBind();
                Button _btn = (Button)e.Row.FindControl("Button1");
                _btn.Text = "+";
                _mydetails.Visible = false;
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
        private void Hide_Details()
        {
            //for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            //{
            //    GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
            //    Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
            //    _mydetails.Visible = false;
            //    _btn.Text = "+";
            //}
        }
        private void Open_Details(int mode)
        {
            //string sys = "";
            //if (mode == 1)
            //    sys = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));
            //else
            //    sys = (string)Session["Sys"];
            //for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            //{
            //    Label _sys_id = (Label)mymaster.Rows[i].FindControl("lbSys_Id");
            //    if (_sys_id.Text == sys)
            //    {
            //        GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
            //        Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
            //        _mydetails.Visible = true;
            //        _btn.Text = "-";
            //    }
            //}
        }
        protected void btnexpd_Click(object sender, EventArgs e)
        {
            Button _expnd = sender as Button;
            int repeaterItemIndex = ((RepeaterItem)_expnd.NamingContainer).ItemIndex;
            RepeaterItem _Pcontainer = (RepeaterItem)_expnd.NamingContainer;
            //int index = gvRow.;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + index.ToString() + "');", true);
            GridView _mydetails = (GridView)_Pcontainer.FindControl("details");
            Button _btn = (Button)_Pcontainer.FindControl("btnexpd");
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
            //btnDummy_ModalPopupExtender.Show();
            arrange_edit();

        }
        protected void arrange_edit()
        {
            //int _idx = Convert.ToInt32((string)Session["idx"]);
            //GridViewRow _myrow = mymaster.SelectedRow;
            //GridView _mydetails = (GridView)_myrow.FindControl("mydetails");
            //if (_mydetails.Rows[_idx].Cells[2].Text.Trim() != "&nbsp;") upreff.Text = _mydetails.Rows[_idx].Cells[2].Text;
            //if (_mydetails.Rows[_idx].Cells[3].Text.Trim() != "&nbsp;") upzone.Text = _mydetails.Rows[_idx].Cells[3].Text;
            //if (_mydetails.Rows[_idx].Cells[4].Text.Trim() != "&nbsp;") upcate.Text = _mydetails.Rows[_idx].Cells[4].Text;
            //if (_mydetails.Rows[_idx].Cells[5].Text.Trim() != "&nbsp;") upfloor.Text = _mydetails.Rows[_idx].Cells[5].Text;
            //if (_mydetails.Rows[_idx].Cells[6].Text.Trim() != "&nbsp;") upseq.Text = _mydetails.Rows[_idx].Cells[6].Text;
            //if (_mydetails.Rows[_idx].Cells[7].Text.Trim() != "&nbsp;") uploc.Text = _mydetails.Rows[_idx].Cells[7].Text;
            //if (_mydetails.Rows[_idx].Cells[8].Text.Trim() != "&nbsp;") uplb1.Text = _mydetails.Rows[_idx].Cells[8].Text;
            //if (_mydetails.Rows[_idx].Cells[10].Text.Trim() != "&nbsp;") uplb2.Text = _mydetails.Rows[_idx].Cells[10].Text;
            //if (_mydetails.Rows[_idx].Cells[9].Text.Trim() != "&nbsp;") uplb3.Text = _mydetails.Rows[_idx].Cells[9].Text;
            //if (_mydetails.Rows[_idx].Cells[11].Text.Trim() != "&nbsp;") uplb4.Text = _mydetails.Rows[_idx].Cells[11].Text;
            //upreff.Text = upreff.Text.Replace("&amp;", "&"); upzone.Text = upzone.Text.Replace("&amp;", "&"); upfloor.Text = upfloor.Text.Replace("&amp;", "&"); uploc.Text = uploc.Text.Replace("&amp;", "&"); uplb1.Text = uplb1.Text.Replace("&amp;", "&"); uplb2.Text = uplb2.Text.Replace("&amp;", "&"); uplb3.Text = uplb3.Text.Replace("&amp;", "&"); uplb4.Text = uplb4.Text.Replace("&amp;", "&");
            Load_Master();
            var _result = from _data in _dtMaster.AsEnumerable()
                          where _data.Field<int>(0) == Convert.ToInt32((string)Session["casid"])
                          select _data;
            foreach (var row in _result)
            {
                //upreff.Text = row[4].ToString();
                //upzone.Text = row[5].ToString();
                //upcate.Text = row[6].ToString();
                //upfloor.Text = row[7].ToString();
                //upseq.Text = row[48].ToString();
                //uploc.Text = row[10].ToString();
                //uplb1.Text = row[11].ToString();
                //uplb2.Text = row[13].ToString();
                //uplb3.Text = row[12].ToString();
                //updescr.Text = row["Des"].ToString();
                //uplb4.Text = row[21].ToString();
            }

            //if ((string)Session["sch"] == "1" || (string)Session["sch"] == "5")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb2.Text = lbl2.Text;
            //    }
            //    else
            //    {
            //        lb2.Visible = false;
            //        uplb2.Visible = false;
            //    }
            //    lb1.Text = lbl1.Text;
            //    lb3.Text = lbl3.Text;
            //    lb4.Text = lbnum.Text;
            //    tr0.Visible = false;
            //}
            //else if ((string)Session["sch"] == "2")
            //{
            //    //lb1.Text = lbl1.Text;
            //    //lb3.Text = lbl3.Text;
            //    //uplb4.Visible = false;
            //    //uplb2.Visible = false;
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb1.Text = lbl1.Text;
            //        lb2.Text = lbl2.Text;
            //        lb3.Text = lbl3.Text;
            //        lb4.Text = lbnum.Text;
            //        tr0.Visible = false;
            //    }
            //    else
            //    {
            //        lb1.Text = lbl1.Text;
            //        lb2.Text = lbl2.Text;
            //        lb3.Text = lbl3.Text;
            //        lb4.Visible = false; uplb4.Visible = false; tr0.Visible = false;
            //    }
            //}
            //else if ((string)Session["sch"] == "3")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb4.Text = lbnum.Text;
            //    }
            //    else
            //    {
            //        lb4.Visible = false; uplb4.Visible = false;
            //    }
            //    lb1.Text = lbl1.Text;
            //    lb2.Text = lbl2.Text;
            //    lb3.Text = lbl3.Text;
            //    tr0.Visible = false;

            //}
            //else if ((string)Session["sch"] == "4")
            //{
            //    lb1.Text = lbl1.Text;
            //    lb3.Text = lbl3.Text;
            //    lb4.Visible = false;
            //    uplb4.Visible = false;
            //    lb2.Visible = false;
            //    uplb2.Visible = false; tr0.Visible = false;

            //}
            //else if ((string)Session["sch"] == "6")
            //{
            //    lb1.Text = lbl1.Text;
            //    uplb2.Visible = false; uplb3.Visible = false;
            //    uplb4.Visible = false; tr0.Visible = false;

            //}
            //else if ((string)Session["sch"] == "7")
            //{
            //    lb4.Text = lbnum.Text;
            //    lb1.Visible = false; uplb1.Visible = false; lb2.Visible = false; uplb2.Visible = false; lb3.Visible = false; uplb3.Visible = false;
            //    tr0.Visible = false;
            //}
            //else if ((string)Session["sch"] == "8")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb4.Text = lbnum.Text; tr3.Visible = false; tr4.Visible = false; lb3.Text = lbl3.Text;
            //    }
            //    else
            //    {
            //        lb3.Text = lbl3.Text; tr3.Visible = false; tr4.Visible = false; tr5.Visible = false;
            //    }
            //}
            //else if ((string)Session["sch"] == "24")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb4.Text = lbnum.Text; tr0.Visible = false;
            //    }
            //    else
            //    {
            //        tr5.Visible = false;
            //    }
            //    lb3.Text = lbl3.Text;
            //    tr3.Visible = false; tr4.Visible = false;
            //}
            //else if ((string)Session["sch"] == "25")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb4.Text = lbnum.Text; tr0.Visible = false; tr2.Visible = false;
            //    }
            //    else
            //    {
            //        tr5.Visible = false;
            //    }
            //    lb3.Text = lbl3.Text;
            //    tr3.Visible = false; tr4.Visible = false;
            //}
            //else if ((string)Session["sch"] == "17")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb4.Text = lbnum.Text;
            //    }
            //    else
            //    {
            //        tr5.Visible = false;
            //    }
            //    lb3.Text = lbl3.Text;
            //    tr3.Visible = false; tr4.Visible = false;
            //}
            //else if ((string)Session["sch"] == "27")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb4.Text = lbnum.Text;
            //        tr2.Visible = false;
            //    }
            //    else
            //    {
            //        tr5.Visible = false;
            //    }
            //    lb3.Text = lbl3.Text;
            //    tr3.Visible = false; tr4.Visible = false;
            //}
            //else if ((string)Session["sch"] == "9")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lbldes.Text = lbdes.Text; lblloc.Text = lbloc.Text;
            //        lb3.Text = lbl3.Text; lb1.Text = lbl1.Text; tr4.Visible = false; tr5.Visible = false;
            //    }
            //    else
            //    {
            //        tr2.Visible = false; tr3.Visible = false; tr4.Visible = false; tr5.Visible = false;
            //    }
            //}
            //else if ((string)Session["sch"] == "10")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb1.Text = lbl1.Text;
            //    }
            //    else
            //        tr3.Visible = false;
            //    lb4.Text = lbnum.Text;
            //    lb2.Text = "NO.OF DEVICES";
            //    tr2.Visible = false; tr0.Visible = false;

            //}
            //else if ((string)Session["sch"] == "31")
            //{
            //    lb4.Text = lbnum.Text;
            //    lb2.Text = "NO.OF DEVICES";
            //    tr2.Visible = false; tr3.Visible = false; tr0.Visible = false;

            //}
            //else if ((string)Session["sch"] == "15")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb1.Text = lbl1.Text;
            //        lb3.Text = lbl3.Text;
            //    }
            //    else
            //    {
            //        tr3.Visible = false; tr1.Visible = false; tr2.Visible = false;
            //    }
            //    tr4.Visible = false;
            //    lb4.Text = lbnum.Text;
            //    tr0.Visible = false;

            //}
            //else if ((string)Session["sch"] == "14")
            //{
            //    lb4.Text = lbnum.Text;
            //    tr2.Visible = false; tr3.Visible = false; tr0.Visible = false; tr4.Visible = false;
            //    if ((string)Session["project"] != "CCAD")
            //    {
            //        tr1.Visible = false;
            //    }
            //}

            //else if ((string)Session["sch"] == "16")
            //{
            //    lb4.Text = lbnum.Text;
            //    lb2.Text = lbl2.Text;
            //    lb3.Text = lbl3.Text;
            //    lb1.Text = lbl1.Text;
            //    tr0.Visible = false;
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        tr4.Visible = false;
            //    }
            //    //lb1.Visible = false; uplb1.Visible = false;
            //}
            //else if ((string)Session["sch"] == "18" || (string)Session["sch"] == "29")
            //{
            //    lb4.Text = lbnum.Text;
            //    tr1.Visible = false; tr2.Visible = false; tr3.Visible = false; tr4.Visible = false;
            //}
            //else if ((string)Session["sch"] == "23")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb4.Text = lbnum.Text;
            //        lb1.Text = lbl1.Text;
            //    }
            //    else
            //    {
            //        tr5.Visible = false;
            //        tr3.Visible = false;
            //    }
            //    lb3.Text = lbl3.Text;
            //    tr4.Visible = false; tr0.Visible = false;
            //}
            //else if ((string)Session["sch"] == "19")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb4.Text = lbnum.Text;
            //        tr1.Visible = false; tr2.Visible = false;
            //    }
            //    else
            //    {
            //        tr5.Visible = false; tr0.Visible = false; lb3.Text = lbl3.Text;
            //    }

            //    tr3.Visible = false; tr4.Visible = false;
            //}
            //else if ((string)Session["sch"] == "28" || (string)Session["sch"] == "34" || (string)Session["sch"] == "35" || (string)Session["sch"] == "36")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lbldes.Text = lbdes.Text; lblloc.Text = lbloc.Text;
            //        lb3.Text = lbl3.Text; lb1.Text = lbl1.Text; tr4.Visible = false; tr5.Visible = false;
            //    }
            //    else
            //    {
            //        lb3.Text = lbl3.Text;
            //        tr3.Visible = false; tr4.Visible = false; tr5.Visible = false; tr0.Visible = false;
            //    }
            //}
            //else if ((string)Session["sch"] == "21")
            //{
            //    lb4.Text = lbnum.Text;
            //    tr2.Visible = false; tr3.Visible = false; tr4.Visible = false;

            //}
            //else if ((string)Session["sch"] == "13")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb3.Text = lbl3.Text;
            //    }
            //    else
            //    {
            //        tr2.Visible = false;
            //    }
            //    lblloc.Text = lbloc.Text;
            //    lb4.Text = lbnum.Text;
            //    tr3.Visible = false; tr4.Visible = false; tr0.Visible = false;

            //}
            //else if ((string)Session["sch"] == "22")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        lb3.Text = lbl3.Text;
            //    }
            //    else
            //    {
            //        tr2.Visible = false;
            //    }
            //    lblloc.Text = lbloc.Text;
            //    lb4.Text = lbnum.Text;
            //    tr3.Visible = false; tr4.Visible = false; tr0.Visible = false;

            //}
            //else if ((string)Session["sch"] == "11")
            //{
            //    lblloc.Text = lbloc.Text;
            //    lb4.Text = lbnum.Text;
            //    lb2.Text = lbl2.Text;
            //    tr2.Visible = false; tr3.Visible = false; tr0.Visible = false;
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        tr4.Visible = false;
            //    }

            //}
            //else if ((string)Session["sch"] == "20")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        tr3.Visible = false;
            //        tr4.Visible = false;
            //    }
            //    else
            //    {
            //        lb1.Text = lbl1.Text;
            //        lb2.Text = lbl2.Text;

            //    }
            //    lb3.Text = lbl3.Text;
            //    lb4.Text = lbnum.Text;
            //    tr0.Visible = false;

            //}
            //else if ((string)Session["sch"] == "32")
            //{
            //    lb1.Text = lbl1.Text;
            //    lb3.Text = lbl3.Text;
            //    lb2.Text = lbl2.Text;
            //    lb4.Text = lbnum.Text;
            //    tr0.Visible = false;
            //}
            //else if ((string)Session["sch"] == "12")
            //{
            //    lb4.Text = lbnum.Text;
            //    lb3.Text = lbl3.Text;
            //    tr4.Visible = false; tr3.Visible = false; tr0.Visible = false;

            //}
            //else if ((string)Session["sch"] == "30")
            //{
            //    lb1.Text = lbl1.Text;
            //    lb3.Text = lbl3.Text;
            //    lb2.Text = lbl2.Text;
            //    lb4.Text = lbnum.Text;
            //}
            //else if ((string)Session["sch"] == "26")
            //{
            //    if ((string)Session["project"] == "CCAD")
            //    {
            //        tr0.Visible = false;
            //        tr2.Visible = false;
            //        tr5.Visible = false;
            //    }
            //    lb3.Text = lbl3.Text;
            //    lb4.Text = lbnum.Text;
            //    tr3.Visible = false; tr4.Visible = false;
            //}

        }
        protected void mydetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[1].Text = (e.Row.DataItemIndex + 1).ToString();
            if ((string)Session["sch"] == "10")
            {
                e.Row.Cells[10].Visible = false;
                e.Row.Cells[9].Visible = false; e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "11")
            {
                e.Row.Cells[11].Visible = false;
                e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false; e.Row.Cells[7].Visible = false;
            }
            

        }
        private void Filtering(string _el1, string _el2, string _el3, string _el4, string _el5, string _el6)
        {
            if (_el1 == "") _el1 = "All";
            if (_el2 == "") _el2 = "All";
            if (_el3 == "") _el3 = "All";
            if (_el4 == "") _el4 = "All";
            if (_el5 == "") _el5 = "All";
            if (_el6 == "") _el6 = "All";
            Load_Master();
            DataTable _dtfilter = _dtMaster;
            _dtresult = new DataTable();
            _dtresult.Columns.Add("e_b_ref", typeof(string));
            _dtresult.Columns.Add("B_Z", typeof(string));
            _dtresult.Columns.Add("Cat", typeof(string));
            _dtresult.Columns.Add("F_lvl", typeof(string));
            _dtresult.Columns.Add("Seq_No", typeof(string));
            _dtresult.Columns.Add("Loc", typeof(string));
            _dtresult.Columns.Add("P_P_to", typeof(string));
            _dtresult.Columns.Add("F_from", typeof(string));
            _dtresult.Columns.Add("Substation", typeof(string));
            _dtresult.Columns.Add("devices1", typeof(string));
            _dtresult.Columns.Add("C_id", typeof(int));
            _dtresult.Columns.Add("Sys_name", typeof(string));
            _dtresult.Columns.Add("Sys_id", typeof(int));
            _dtresult.Columns.Add("Des", typeof(string));
            var _filter = from o in _dtfilter.AsEnumerable()
                          select o;
            if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 == "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("Loc") == _el5 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 == "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 == "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 != "All" && _el6 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("Loc") == _el5 && o.Field<string>("Des") == _el6
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 != "All" && _el6 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("Loc") == _el5
                          select o;
            }
            foreach (var row in _filter)
            {
                DataRow _row = _dtresult.NewRow();
                _row[0] = row["e_b_ref"].ToString();
                _row[1] = row["B_Z"].ToString();
                _row[2] = row["Cat"].ToString();
                _row[3] = row["F_lvl"].ToString();
                _row[4] = row["Seq_No"].ToString();
                _row[5] = row["Loc"].ToString();
                _row[6] = row["p_p_to"].ToString();
                _row[7] = row["F_from"].ToString();
                _row[8] = row["Substation"].ToString();
                _row[9] = row["devices1"].ToString();
                _row[10] = row["C_id"].ToString();
                _row[11] = row["Sys_name"].ToString();
                _row[12] = row["Sys_id"].ToString();
                _row[13] = row["Des"].ToString();
                _dtresult.Rows.Add(_row);
            }
            //m.DataSource = _dtresult;
            //mygrid.DataBind();
            Load_InitialData();

        }
        protected void drbuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["zone"] = drbuilding.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drdes.SelectedItem.Text);
        }
        protected void drcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["cat"] = drcategory.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drdes.SelectedItem.Text);
        }
        protected void drflevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["flvl"] = drflevel.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drdes.SelectedItem.Text);
        }
        protected void drfed_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["fed"] = drfed.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drdes.SelectedItem.Text);
        }
       
        private void Load_Filtering_Elements()
        {
            drbuilding.Items.Clear();
            drcategory.Items.Clear();
            drflevel.Items.Clear();
            drfed.Items.Clear();
            drloc.Items.Clear();
            drdes.Items.Clear();
            var _bzone = (from DataRow dRow in _dtresult.Rows
                          orderby dRow["B_Z"]
                          select new { col1 = dRow["B_Z"] }).Distinct();
            foreach (var row in _bzone)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drbuilding.Items.Add(_itm);
            }
            drbuilding.DataBind();
            var _fedf = (from DataRow dRow in _dtresult.Rows
                         orderby dRow["F_from"]
                         select new { col1 = dRow["F_from"] }).Distinct();
            foreach (var row in _fedf)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drfed.Items.Add(_itm);
            }
            drfed.DataBind();
            var _cate = (from DataRow dRow in _dtresult.Rows
                         orderby dRow["Cat"]
                         select new { col1 = dRow["Cat"] }).Distinct();
            foreach (var row in _cate)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drcategory.Items.Add(_itm);
            }
            drcategory.DataBind();
            var _flvl = (from DataRow dRow in _dtresult.Rows
                         orderby dRow["F_lvl"]
                         select new { col1 = dRow["F_lvl"] }).Distinct();
            foreach (var row in _flvl)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drflevel.Items.Add(_itm);
            }
            drflevel.DataBind();
            var _loc = (from DataRow dRow in _dtresult.Rows
                        orderby dRow["Loc"]
                        select new { col1 = dRow["Loc"] }).Distinct();
            foreach (var row in _loc)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drloc.Items.Add(_itm);
            }
            drloc.DataBind();
            var _des = (from DataRow dRow in _dtresult.Rows
                        orderby dRow["Des"]
                        select new { col1 = dRow["Des"] }).Distinct();
            foreach (var row in _des)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drdes.Items.Add(_itm);
            }
            drdes.DataBind();
            drbuilding.Items.Insert(0, "All");
            drcategory.Items.Insert(0, "All");
            drflevel.Items.Insert(0, "All");
            drfed.Items.Insert(0, "All");
            drloc.Items.Insert(0, "All");
            drdes.Items.Insert(0, "All");
            drbuilding.SelectedValue = (string)Session["zone"];
            drcategory.SelectedValue = (string)Session["cat"];
            drflevel.SelectedValue = (string)Session["flvl"];
            drfed.SelectedValue = (string)Session["fed"];
            drloc.SelectedValue = (string)Session["loc"];
            drdes.SelectedValue = (string)Session["des"];
        }
        
        protected void btncancel_Click(object sender, EventArgs e)
        {
            // btnDummy_ModalPopupExtender.Hide();
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
        protected void drloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["loc"] = drloc.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drdes.SelectedItem.Text);
        }
        protected void btnnewflevel_Click(object sender, EventArgs e)
        {
            //txtflvl.Text = String.Empty;
            //btnDummy_ModalPopupExtender1.Show();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            //if (txtflvl.Text.Length <= 0) return;
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DB_" + (string)Session["project"];
            //_clscassheet _objcas = new _clscassheet();
            //_objcas.f_level = txtflvl.Text;
            //_objbll.Create_FLevel(_objcas, _objdb);
            //Load_Flvl();
            //btnDummy_ModalPopupExtender1.Hide();
        }
        protected void btncancel1_Click(object sender, EventArgs e)
        {
            //btnDummy_ModalPopupExtender1.Hide();
        }

        protected void btnexpand_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= reptr_main.Items.Count - 1; i++)
            {
                GridView _mydetails = (GridView)reptr_main.Items[i].FindControl("details");
                Button _btn = (Button)reptr_main.Items[i].FindControl("btnexpd");
                _mydetails.Visible = true;
                _btn.Text = "-";
            }
        }

        protected void btncollapse_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= reptr_main.Items.Count - 1; i++)
            {
                GridView _mydetails = (GridView)reptr_main.Items[i].FindControl("details");
                Button _btn = (Button)reptr_main.Items[i].FindControl("btnexpd");
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
            //int count = 0;
            //for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            //{
            //    GridView _details = (GridView)mymaster.Rows[i].FindControl("mydetails");
            //    for (int j = 0; j <= _details.Rows.Count - 1; j++)
            //    {
            //        CheckBox checkbox = (CheckBox)_details.Rows[j].FindControl("chkrow");
            //        if (checkbox.Checked == true)
            //        {
            //            count += 1;
            //            Session["casid"] = _details.Rows[j].Cells[13].Text;
            //            Session["Sys"] = _details.Rows[j].Cells[14].Text;
            //            Session["idx"] = j.ToString();
            //        }
            //    }

            //}
            //if (count == 0) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');", true);
            //else if (count > 1) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('You can select only one Row at a time to Edit');", true);
            //else if (count == 1)
            //{
            //    //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["MemberId"] + "',7);", true);

            //    btnDummy_ModalPopupExtender.Show();
            //    arrange_edit();
            //}
        }

        protected void btndelete1_Click(object sender, EventArgs e)
        {
            //int count = 0;
            //for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            //{
            //    GridView _details = (GridView)mymaster.Rows[i].FindControl("mydetails");
            //    for (int j = 0; j <= _details.Rows.Count - 1; j++)
            //    {
            //        CheckBox checkbox = (CheckBox)_details.Rows[j].FindControl("chkrow");
            //        if (checkbox.Checked == true)
            //        {
            //            count += 1;
            //            Session["casid"] = _details.Rows[j].Cells[13].Text;
            //            Session["Sys"] = _details.Rows[j].Cells[14].Text;
            //            Delete_Inidata();
            //        }
            //    }

            //}
            //if (count == 0) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');", true);
            //else
            //{
            //    string _msg = count.ToString() + " Row(s) Deleted";
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _msg + "');", true);
            //    Load_Master();
            //    Load_InitialData();
            //    Open_Details(0);
            //}
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
            _dtresult.Columns.Add("B_Z", typeof(string));
            _dtresult.Columns.Add("Cat", typeof(string));
            _dtresult.Columns.Add("F_lvl", typeof(string));
            _dtresult.Columns.Add("Seq_No", typeof(string));
            _dtresult.Columns.Add("Loc", typeof(string));
            _dtresult.Columns.Add("P_P_to", typeof(string));
            _dtresult.Columns.Add("F_from", typeof(string));
            _dtresult.Columns.Add("Substation", typeof(string));
            _dtresult.Columns.Add("devices1", typeof(string));
            _dtresult.Columns.Add("C_id", typeof(int));
            _dtresult.Columns.Add("Sys_name", typeof(string));
            _dtresult.Columns.Add("Sys_id", typeof(int));
            _dtresult.Columns.Add("Des", typeof(string));
            var _result = from _data in _dtMaster.AsEnumerable()
                          where _data.Field<string>("E_b_ref").ToUpper().IndexOf("string") >= 0
                          select _data;

            foreach (var row in _result)
            {
                DataRow _row = _dtresult.NewRow();
                _row[0] = row["e_b_ref"].ToString();
                _row[1] = row["B_Z"].ToString();
                _row[2] = row["Cat"].ToString();
                _row[3] = row["F_lvl"].ToString();
                _row[4] = row["Seq_No"].ToString();
                _row[5] = row["Loc"].ToString();
                _row[6] = row["p_p_to"].ToString();
                _row[7] = row["F_from"].ToString();
                _row[8] = row["Substation"].ToString();
                _row[9] = row["devices1"].ToString();
                _row[10] = row["C_id"].ToString();
                _row[11] = row["Sys_name"].ToString();
                _row[12] = row["Sys_id"].ToString();
                _row[13] = row["Des"].ToString();
                _dtresult.Rows.Add(_row);
            }
            Load_InitialData();

        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            //if (btnsearch.Text == "Search")
            //{
            //    FnSearch();
            //    for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            //    {
            //        GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
            //        Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
            //        _mydetails.Visible = true;
            //        _btn.Text = "-";
            //    }
            //    btnsearch.Text = "Reset";
            //}
            //else
            //{
            //    txtsearch.Text = String.Empty;
            //    FnSearch();
            //    for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            //    {
            //        GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
            //        Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
            //        _mydetails.Visible = false;
            //        _btn.Text = "+";
            //    }
            //    btnsearch.Text = "Search";
            //}
        }

        protected void btnimport_Click(object sender, EventArgs e)
        {
            string _url = "CMS/Import.aspx?id=" + (string)Session["sch"] + "_" + (string)Session["project"];
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _url + "','','left=300,top=200,width=500,height=400,menubar=0,toolbar=0,scrollbars=1,status=0,resizable=0');", true);
        }
        protected void btnrefresh_Click(object sender, ImageClickEventArgs e)
        {
            Load_Master();
            Load_InitialData();
        }

        protected void drdes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["des"] = drdes.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text, drdes.SelectedItem.Text);
        }


        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["sch_id"] = Convert.ToInt32(lblsch.Text);
            e.InputParameters["prj_code"] = lblprj.Text;
        }

        protected void reptr_main_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Label _panel_id = (Label)e.Item.FindControl("lbl_panelPid");
                DataTable _dtable = new DataTable();
                _dtable.Columns.Add("Panel_Id", typeof(string));
                _dtable.Columns.Add("Panel_Ref", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    where dRow["Panel_Id"].ToString() == _panel_id.Text
                                    select new { col1 = dRow["Panel_Id"], col2 = dRow["Panel_Ref"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    DataRow _row = _dtable.NewRow();
                    _row[0] = row.col1.ToString();
                    _row[1] = row.col2.ToString();
                    _dtable.Rows.Add(_row);
                }
                GridView _mydetails = (GridView)e.Item.FindControl("details");
                _mydetails.DataSource = _dtable;
                _mydetails.DataBind();
                //Button _btn = (Button)e.Row.FindControl("Button1");
                //_btn.Text = "+";
                _mydetails.Visible = false;
            }

        }

        protected DataTable Getinner1(int panel_id)
        {
            //Label _lb = (Label)reptr_main.FindControl("lbl_panelPid");
            DataTable _dtdetails = new DataTable();
            _dtdetails.Columns.Add("e_b_ref", typeof(string));
            _dtdetails.Columns.Add("B_Z", typeof(string));
            _dtdetails.Columns.Add("Cat", typeof(string));
            _dtdetails.Columns.Add("F_lvl", typeof(string));
            _dtdetails.Columns.Add("Seq_No", typeof(string));
            _dtdetails.Columns.Add("Loc", typeof(string));
            _dtdetails.Columns.Add("P_P_to", typeof(string));
            _dtdetails.Columns.Add("F_from", typeof(string));
            _dtdetails.Columns.Add("Substation", typeof(string));
            _dtdetails.Columns.Add("devices1", typeof(string));
            _dtdetails.Columns.Add("C_id", typeof(int));
            _dtdetails.Columns.Add("Sys_name", typeof(string));
            _dtdetails.Columns.Add("Sys_id", typeof(int));
            _dtdetails.Columns.Add("Des", typeof(string));
            var _details = from _data in _dtresult.AsEnumerable()
                           where _data.Field<int>("Panel_Id") == panel_id
                           select _data;
            foreach (var row in _details)
            {
                DataRow _row = _dtdetails.NewRow();
                _row[0] = row["e_b_ref"].ToString();
                _row[1] = row["B_Z"].ToString();
                _row[2] = row["Cat"].ToString();
                _row[3] = row["F_lvl"].ToString();
                _row[4] = SeqNo(row["Seq_No"].ToString());
                _row[5] = row["Loc"].ToString();
                _row[6] = row["p_p_to"].ToString();
                _row[7] = row["F_from"].ToString();
                _row[8] = row["Substation"].ToString();
                _row[9] = row["devices1"].ToString();
                _row[10] = row["C_id"].ToString();
                _row[11] = row["Sys_name"].ToString();
                _row[12] = row["Sys_id"].ToString();
                _row[13] = row["Des"].ToString();
                _dtdetails.Rows.Add(_row);
            }
            return _dtdetails;
        }

        protected void reptr_main_DataBinding(object sender, EventArgs e)
        {

        }
        protected void details_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _panel_id = (Label)e.Row.FindControl("lblpanel");
                DataTable _dtdetails = new DataTable();
                //_dtdetails.Columns.Add("e_b_ref", typeof(string));
                //_dtdetails.Columns.Add("B_Z", typeof(string));
                //_dtdetails.Columns.Add("Cat", typeof(string));
                //_dtdetails.Columns.Add("F_lvl", typeof(string));
                //_dtdetails.Columns.Add("Seq_No", typeof(string));
                //_dtdetails.Columns.Add("Loc", typeof(string));
                //_dtdetails.Columns.Add("P_P_to", typeof(string));
                //_dtdetails.Columns.Add("F_from", typeof(string));
                //_dtdetails.Columns.Add("Substation", typeof(string));
                //_dtdetails.Columns.Add("devices1", typeof(string));
                //_dtdetails.Columns.Add("C_id", typeof(int));
                //_dtdetails.Columns.Add("Sys_name", typeof(string));
                //_dtdetails.Columns.Add("Sys_id", typeof(int));
                //_dtdetails.Columns.Add("Des", typeof(string));
                //_dtdetails.Columns.Add("Panel_Ref", typeof(string));
                //var _details = from _data in _dtresult.AsEnumerable()
                //               where _data.Field<int>("Panel_Parent") == Convert.ToInt32(_panel_id.Text)
                //               select _data;
                //foreach (var row in _details)
                //{
                //    DataRow _row = _dtdetails.NewRow();
                //    _row[0] = row["e_b_ref"].ToString();
                //    _row[1] = row["B_Z"].ToString();
                //    _row[2] = row["Cat"].ToString();
                //    _row[3] = row["F_lvl"].ToString();
                //    _row[4] = SeqNo(row["Seq_No"].ToString());
                //    _row[5] = row["Loc"].ToString();
                //    _row[6] = row["p_p_to"].ToString();
                //    _row[7] = row["F_from"].ToString();
                //    _row[8] = row["Substation"].ToString();
                //    _row[9] = row["devices1"].ToString();
                //    _row[10] = row["C_id"].ToString();
                //    _row[11] = row["Sys_name"].ToString();
                //    _row[12] = row["Sys_id"].ToString();
                //    _row[13] = row["Des"].ToString();
                //    _row[14] = row["Panel_Ref"].ToString();
                //    _dtdetails.Rows.Add(_row);
                //}
                //GridView _mydetails = (GridView)e.Row.FindControl("inner2");
                //_mydetails.DataSource = _dtdetails;
                //_mydetails.DataBind();
                _dtdetails.Columns.Add("e_b_ref", typeof(string));
                _dtdetails.Columns.Add("B_Z", typeof(string));
                _dtdetails.Columns.Add("Cat", typeof(string));
                _dtdetails.Columns.Add("F_lvl", typeof(string));
                _dtdetails.Columns.Add("Seq_No", typeof(string));
                _dtdetails.Columns.Add("Loc", typeof(string));
                _dtdetails.Columns.Add("P_P_to", typeof(string));
                _dtdetails.Columns.Add("F_from", typeof(string));
                _dtdetails.Columns.Add("Substation", typeof(string));
                _dtdetails.Columns.Add("devices1", typeof(string));
                _dtdetails.Columns.Add("C_id", typeof(int));
                _dtdetails.Columns.Add("Sys_name", typeof(string));
                _dtdetails.Columns.Add("Sys_id", typeof(int));
                _dtdetails.Columns.Add("Des", typeof(string));
                var _details1 = from _data in _dtresult.AsEnumerable()
                                where _data.Field<int>("Panel_Id") == Convert.ToInt32(_panel_id.Text)
                                select _data;
                foreach (var row in _details1)
                {
                    DataRow _row = _dtdetails.NewRow();
                    _row[0] = row["e_b_ref"].ToString();
                    _row[1] = row["B_Z"].ToString();
                    _row[2] = row["Cat"].ToString();
                    _row[3] = row["F_lvl"].ToString();
                    _row[4] = SeqNo(row["Seq_No"].ToString());
                    _row[5] = row["Loc"].ToString();
                    _row[6] = row["p_p_to"].ToString();
                    _row[7] = row["F_from"].ToString();
                    _row[8] = row["Substation"].ToString();
                    _row[9] = row["devices1"].ToString();
                    _row[10] = row["C_id"].ToString();
                    _row[11] = row["Sys_name"].ToString();
                    _row[12] = row["Sys_id"].ToString();
                    _row[13] = row["Des"].ToString();
                    _dtdetails.Rows.Add(_row);
                }
                GridView _mydetails1 = (GridView)e.Row.FindControl("inner1");
                _mydetails1.DataSource = _dtdetails;
                _mydetails1.DataBind();
                //Button _btn = (Button)e.Row.FindControl("Button1");
                //_btn.Text = "+";
                //_mydetails.Visible = false;
                DataTable _dtable = new DataTable();
                _dtable.Columns.Add("Panel_Id", typeof(string));
                _dtable.Columns.Add("Panel_Ref", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    where dRow["Panel_Parent"].ToString() == _panel_id.Text
                                    select new { col1 = dRow["Panel_Id"], col2 = dRow["Panel_Ref"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    DataRow _row = _dtable.NewRow();
                    _row[0] = row.col1.ToString();
                    _row[1] = row.col2.ToString();
                    _dtable.Rows.Add(_row);
                }
                GridView _mydetails2 = (GridView)e.Row.FindControl("inner_sub");
                _mydetails2.DataSource = _dtable;
                _mydetails2.DataBind();
            }
        }
        protected void inner_sub_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _panel_id = (Label)e.Row.FindControl("lbl_panelCid");
                DataTable _dtdetails = new DataTable();
                _dtdetails.Columns.Add("e_b_ref", typeof(string));
                _dtdetails.Columns.Add("B_Z", typeof(string));
                _dtdetails.Columns.Add("Cat", typeof(string));
                _dtdetails.Columns.Add("F_lvl", typeof(string));
                _dtdetails.Columns.Add("Seq_No", typeof(string));
                _dtdetails.Columns.Add("Loc", typeof(string));
                _dtdetails.Columns.Add("P_P_to", typeof(string));
                _dtdetails.Columns.Add("F_from", typeof(string));
                _dtdetails.Columns.Add("Substation", typeof(string));
                _dtdetails.Columns.Add("devices1", typeof(string));
                _dtdetails.Columns.Add("C_id", typeof(int));
                _dtdetails.Columns.Add("Sys_name", typeof(string));
                _dtdetails.Columns.Add("Sys_id", typeof(int));
                _dtdetails.Columns.Add("Des", typeof(string));
                var _details1 = from _data in _dtresult.AsEnumerable()
                                where _data.Field<int>("Panel_Id") == Convert.ToInt32(_panel_id.Text)
                                select _data;
                foreach (var row in _details1)
                {
                    DataRow _row = _dtdetails.NewRow();
                    _row[0] = row["e_b_ref"].ToString();
                    _row[1] = row["B_Z"].ToString();
                    _row[2] = row["Cat"].ToString();
                    _row[3] = row["F_lvl"].ToString();
                    _row[4] = SeqNo(row["Seq_No"].ToString());
                    _row[5] = row["Loc"].ToString();
                    _row[6] = row["p_p_to"].ToString();
                    _row[7] = row["F_from"].ToString();
                    _row[8] = row["Substation"].ToString();
                    _row[9] = row["devices1"].ToString();
                    _row[10] = row["C_id"].ToString();
                    _row[11] = row["Sys_name"].ToString();
                    _row[12] = row["Sys_id"].ToString();
                    _row[13] = row["Des"].ToString();
                    _dtdetails.Rows.Add(_row);
                }
                GridView _mydetails1 = (GridView)e.Row.FindControl("inner2");
                _mydetails1.DataSource = _dtdetails;
                _mydetails1.DataBind();

            }
        }

        protected void _10btnupdate_Click(object sender, EventArgs e)
        {
            Update(_10eng.Text, _10nct.Text, _10ctd.Text, _10ndt.Text, _10ddt.Text, _10fat.Text, _10bat.Text, _10ghet.Text, _10icom.Text, _10pft.Text, "", "", "", "", "", "", "", "", _10accept1.Text, _10fpt.Text, _10filed1.Text, _10arm.Text, _10commts.Text, _10actby.Text, _10actdt.Text);
            btnDummy_ModalPopupExtender13.Hide();
        }

        protected void _10btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender13.Hide();
        }
        private void Update(string pwron, string test1, string test2, string test3, string test4, string test5, string test6, string test7, string test8, string test9, string test10, string test11, string test12, string tested1, string tested2, string compld1, string compld2, string dvce, string accept1, string accept2, string filed1, string filed2, string comts, string actby, string actdt)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
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
            _objcls.per_com2 = per_com2();
            _objcls.per_com3 = per_com3();
            _objcls.per_com4 = per_com4();
            _objcls.power_on = pwron;
            _objcls.dev1 = dvce;
            _objcls.accept1 = accept1;
            _objcls.accept2 = accept2;
            _objcls.filed1 = filed1;
            _objcls.filed2 = filed2;
            _objcls.per_com5 = per_com5();
            _objcls.per_com6 = per_com6();
            _objcls.per_com7 = per_com7();
            _objcls.per_com8 = per_com8();
            _objcls.per_com9 = per_com9();
            _objcls.per_com10 = per_com10();
            _objbll.Cassheet_update(_objcls, _objdb);
            Load_Master();
        }
        protected decimal per_com1()
        {

            decimal _percentage = 0;

            int count = 0;
           if (lblsch.Text == "10")
            {
                if ((string)Session["cat"] != "FCC")
                {
                    if (IsNumeric(_10nct.Text) == true)
                    {
                        _percentage = Convert.ToDecimal(_10nct.Text);
                    }
                }
            }
           else if (lblsch.Text == "11")
           {
               if (IsNumeric(_11dvc.Text) == true && IsNumeric(_11cit.Text) == true)
               {
                   decimal _d1 = Convert.ToDecimal(_11cit.Text);
                   decimal _d2 = Convert.ToDecimal(_11dvc.Text);
                   decimal _per = (_d1 / _d2) * 100;
                   _percentage = _per;
               }
           }
            return _percentage;
        }
        protected decimal per_com2()
        {

            decimal _percentage = 0;
            int count = 0;
            if (lblsch.Text == "10")
            {
                if ((string)Session["cat"] == "FAP" || (string)Session["cat"] == "FCC") return 0;
                if (IsNumeric(_10ndt.Text) == true)
                {
                    _percentage = Convert.ToDecimal(_10ndt.Text);
                }
            }
            else if (lblsch.Text == "11")
            {
                decimal _ptested1 = 0;
                decimal _ptested2 = 0;
                if (IsNumeric(_11dvc.Text) == true && IsNumeric(_11ndt.Text) == true)
                {
                    decimal _d1 = Convert.ToDecimal(_11ndt.Text);
                    decimal _d2 = Convert.ToDecimal(_11dvc.Text);
                    _ptested1 = (_d1 / _d2) * 100;
                }
                if (_11ztb.Text != "")
                    count += 1;
                if (_11ztp.Text != "")
                    count += 1;
                if (_11zsl.Text != "")
                    count += 1;
                if (_11zeo.Text != "")
                    count += 1;
                if (_11zai.Text != "")
                    count += 1;
                if (_11bat.Text != "")
                    count += 1;
                if (_11grt.Text != "")
                    count += 1;
                if (_11iit.Text != "")
                    count += 1;
                _ptested2 = (Convert.ToDecimal(count) / 8) * 100;
                decimal _per = (_ptested1 * 0.5m + _ptested2 * 0.5m);
                _percentage = _per;
            }
            return _percentage;
        }
        protected decimal per_com3()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "10")
            {
                if ((string)Session["cat"] == "ANN" || (string)Session["cat"] == "FCC" || (string)Session["cat"] == "FSC" || (string)Session["cat"] == "FTL" || (string)Session["cat"] == "SPC") return 0;
                if (IsNumeric(_10fat.Text) == true)
                {
                    _percentage = Convert.ToDecimal(_10fat.Text);
                }
            }
            else if (lblsch.Text == "11")
            {
                if (_11icom.Text != "")
                    _percentage = 1;
            }
            return _percentage;
        }
        protected decimal per_com4()
        {
            decimal _percentage = 0;
            int count = 0;
            if (lblsch.Text == "10")
            {
                if ((string)Session["cat"] == "FAP")
                {
                    if (IsNumeric(_10bat.Text) == true)
                    {
                        _percentage = Convert.ToDecimal(_10bat.Text);
                    }
                }
            }
            else if (lblsch.Text == "11")
            {
                if (_11pft.Text != "")
                    _percentage = 1;
            }
            return _percentage;
        }
        protected decimal per_com5()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "10")
            {
                if ((string)Session["cat"] == "FAP" || (string)Session["cat"] == "FCC")
                {
                    if (IsNumeric(_10ghet.Text) == true)
                    {
                        _percentage = Convert.ToDecimal(_10ghet.Text);
                    }
                }
            }
            else if (lblsch.Text == "11")
            {
                if (_11eng.Text != "")
                    _percentage = 1;
            }
            return _percentage;
        }
        protected decimal per_com6()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "11")
            {
                if (_11fpt.Text != "")
                    _percentage = 1;
            }
            return _percentage;
        }
        protected decimal per_com7()
        {
            decimal _percentage = 0;
            if (lblsch.Text == "11")
            {
                if (_11arm.Text != "")
                    _percentage = 1;
            }
            return _percentage;
        }
        protected decimal per_com8()
        {
            return 0;
        }
        protected decimal per_com9()
        {
            return 0;
        }
        protected decimal per_com10()
        {
            return 0;
        }
        protected void inner1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView _mydetails = (GridView)gvRow.FindControl("inner1");
            int _idx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = _mydetails.Rows[_idx];
            //int index = gvRow.RowIndex;
            TableCell _item1 = _srow.Cells[13];
            TableCell _cat = _srow.Cells[4];
            TableCell _sys_name = _srow.Cells[15];
            TableCell _eref = _srow.Cells[2];
            Session["casid"] = _item1.Text;
            string _title = "PACKAGE NAME : " + _sys_name.Text + ", ENG.REF : " + _eref.Text;
            Load_cassheet_details(Convert.ToInt32(_item1.Text));
            if (lblsch.Text == "10")
            {
                btnDummy_ModalPopupExtender13.Show();
                _10lbl.Text = _title;
            }
            else if (lblsch.Text == "11")
            {
                btnDummy_ModalPopupExtender17.Show();
                _11lbl.Text = _title;
            }
        }
        protected void inner2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView _mydetails = (GridView)gvRow.FindControl("inner2");
            int _idx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = _mydetails.Rows[_idx];
            //int index = gvRow.RowIndex;
            TableCell _item1 = _srow.Cells[13];
            TableCell _cat = _srow.Cells[4];
            TableCell _sys_name = _srow.Cells[15];
            TableCell _eref = _srow.Cells[2];
            Session["casid"] = _item1.Text;
            string _title = "PACKAGE NAME : " + _sys_name.Text + ", ENG.REF : " + _eref.Text;
            Load_cassheet_details(Convert.ToInt32(_item1.Text));
            if (lblsch.Text == "10")
            {
                btnDummy_ModalPopupExtender13.Show();
                _10lbl.Text = _title;
            }
        }
        private void Load_cassheet_details(int _cas_id)
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DB_" + lblprj.Text;
            //_clscassheet _objcas = new _clscassheet();
            //_objcas.sch = Convert.ToInt32(lblsch.Text);
            //_objcas.prj_code = lblprj.Text;
            //DataTable _dt = _objbll.Load_casMain_Edit(_objcas, _objdb);
            DataTable _dt = _dtMaster;
            var result = from o in _dt.AsEnumerable()
                         where o.Field<int>(0) == _cas_id
                         select o;
            foreach (var row in result)
            {
                if (lblsch.Text == "10")
                {
                    _10eng.Text = row[14].ToString();
                    _10nct.Text = row[24].ToString();
                    _10ctd.Text = row[25].ToString();
                    _10ndt.Text = row[26].ToString();
                    _10ddt.Text = row[27].ToString();
                    _10fat.Text = row[28].ToString();
                    _10bat.Text = row[29].ToString();
                    _10ghet.Text = row[30].ToString();
                    _10icom.Text = row["test11"].ToString();
                    _10pft.Text = row["test10"].ToString();
                    _10accept1.Text = row["accept1"].ToString();
                    _10filed1.Text = row["filed1"].ToString();
                    _10fpt.Text = row["accept2"].ToString();
                    _10arm.Text = row["filed2"].ToString();
                    _10commts.Text = row[18].ToString();
                    _10actby.Text = row[19].ToString();
                    _10actdt.Text = row[20].ToString();
                    _10dvc.Text = row["substation"].ToString();
                    _10itf.Text = row[21].ToString();
                }
                else if (lblsch.Text == "11")
                {
                    _11eng.Text = row[14].ToString();
                    _11cit.Text = row[24].ToString();
                    _11ndt.Text = row[25].ToString();
                    _11ztb.Text = row[26].ToString();
                    _11ztp.Text = row[27].ToString();
                    _11zsl.Text = row[28].ToString();
                    _11zeo.Text = row[29].ToString();
                    _11zai.Text = row[30].ToString();
                    _11bat.Text = row["test11"].ToString();
                    _11grt.Text = row["test10"].ToString();
                    _11iit.Text = row["test12"].ToString();
                    if (row["tested1"].ToString() != "0")
                        _11icom.Text = row["tested1"].ToString();
                    if (row["tested2"].ToString() != "0")
                        _11pft.Text = row["tested2"].ToString();
                    _11fpt.Text = row["accept2"].ToString();
                    _11accept1.Text = row["accept1"].ToString();
                    _11arm.Text = row["filed2"].ToString();
                    _11filed1.Text = row["filed1"].ToString();
                    _11commts.Text = row[18].ToString();
                    _11actby.Text = row[19].ToString();
                    _11actdt.Text = row[20].ToString();
                    _11dvc.Text = row[21].ToString();
                }

            }
        }

        protected void _11btnupdate_Click(object sender, EventArgs e)
        {
            Update(_11eng.Text, _11cit.Text, _11ndt.Text, _11ztb.Text, _11ztp.Text, _11zsl.Text, _11zeo.Text, _11zai.Text, _11bat.Text, _11grt.Text, _11iit.Text, "", "", _11icom.Text, _11pft.Text, "", "", "", _11accept1.Text, _11fpt.Text, _11filed1.Text, _11arm.Text, _11commts.Text, _11actby.Text, _11actdt.Text);
            btnDummy_ModalPopupExtender17.Hide();
        }

        protected void _11btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender17.Hide();
        }
    }
}
