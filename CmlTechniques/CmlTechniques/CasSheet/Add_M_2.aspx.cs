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

namespace CmlTechniques.CasSheet
{
    public partial class Add_M_2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string _prm = Request.QueryString[0].ToString();
                //lblprj.Text = "123"
                //lblsch.Text = _prm.Substring(_prm.IndexOf("_S") + 2);
                default_setting();
                load_cas_sys();
                Load_Flvl();
            }
        }
        private void default_setting()
        {
            row.Visible = false;
            row1.Visible = false;
            row2.Visible = false;
            row3.Visible = false;
            row4.Visible = false;
            row5.Visible = false;
            row6.Visible = false;
            row7.Visible = false;
            row8.Visible = false;
            row9.Visible = false;
            row10.Visible = false;
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
        protected void load_cas_sys()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_123";
            _clscassheet _objcls = new _clscassheet();
            _objcls.sch = 2;
            DataTable _dt0 = _objbll.Load_cas_sys(_objcls, _objdb);
            DataTable _dt1 = new DataTable();
            _dt1.Columns.Add("_id");
            _dt1.Columns.Add("_name");
            var _List = from o in _dt0.AsEnumerable()
                        where o.Field<string>(3) == "123"
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
        protected void btn_genrows_Click(object sender, EventArgs e)
        {
            default_setting();
            if (IsNumeric(txt_rows.Text) == false)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Number of rows');", true);
                return;
            }
            else if (drpackage.SelectedItem.Text == "--Package--")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Package');", true);
                return;
            }
            else
                row.Visible = true;
            if (txt_rows.Text == "1") row1.Visible = true;
            else if (txt_rows.Text == "2") { row1.Visible = true; row2.Visible = true; }
            else if (txt_rows.Text == "3") { row1.Visible = true; row2.Visible = true;row3.Visible=true; }
            else if (txt_rows.Text == "4") { row1.Visible = true; row2.Visible = true; row3.Visible = true; row4.Visible = true; }
            else if (txt_rows.Text == "5") { row1.Visible = true; row2.Visible = true; row3.Visible = true; row4.Visible = true; row5.Visible = true; }
            else if (txt_rows.Text == "6") { row1.Visible = true; row2.Visible = true; row3.Visible = true; row4.Visible = true; row5.Visible = true; row6.Visible = true; }
            else if (txt_rows.Text == "7") { row1.Visible = true; row2.Visible = true; row3.Visible = true; row4.Visible = true; row5.Visible = true; row6.Visible = true; row7.Visible = true; }
            else if (txt_rows.Text == "8") { row1.Visible = true; row2.Visible = true; row3.Visible = true; row4.Visible = true; row5.Visible = true; row6.Visible = true; row7.Visible = true; row8.Visible = true; }
            else if (txt_rows.Text == "9") { row1.Visible = true; row2.Visible = true; row3.Visible = true; row4.Visible = true; row5.Visible = true; row6.Visible = true; row7.Visible = true; row8.Visible = true; row9.Visible = true; }
            else if (txt_rows.Text == "10") { row1.Visible = true; row2.Visible = true; row3.Visible = true; row4.Visible = true; row5.Visible = true; row6.Visible = true; row7.Visible = true; row8.Visible = true; row9.Visible = true; row10.Visible = true; }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Number of rows');", true);
                return;
            }
            Populate_Cat();
        }
        private void Load_Flvl()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_123";
            for (int i = 1; i <= 10; i++)
            {
                DropDownList _drlist = (DropDownList)this.FindControl("dr_fvl" + i.ToString());
                _drlist.DataSource = _objbll.Load_Flvl(_objdb);
                _drlist.DataTextField = "F_Level";
                _drlist.DataValueField = "F_Level";
                _drlist.DataBind();
                _drlist.Items.Insert(0, "--select--");
            }
        }
        private void Populate_Cat()
        {
            if (drpackage.SelectedItem.Text != "--Package--")
            {
                int _rows = Convert.ToInt32(txt_rows.Text);
                for (int i = 1; i <= _rows; i++)
                {
                    TextBox _txt = (TextBox)this.FindControl("txt_cat" + i.ToString());
                    _txt.Text = drpackage.SelectedItem.Value.Substring(drpackage.SelectedItem.Value.IndexOf("_C") + 2);
                }
            }
        }
        protected void bz_all_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_bz1.Text.Length > 0)
            {
                int _rows = Convert.ToInt32(txt_rows.Text);
                for (int i = 2; i <= _rows; i++)
                {
                    TextBox _txt = (TextBox)this.FindControl("txt_bz" + i.ToString());
                    _txt.Text = txt_bz1.Text;
                }
            }

        }
        private string  Get_SeqNo(string flvl,string bz,int pos)
        {
            string Sys_Id = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_123";
            _objcls.sys = Convert.ToInt32(Sys_Id);
            _objcls.f_level = flvl;
            _objcls.b_zone = bz;
            _objcls.Position = pos;
            return (_objbll.Get_Seq(_objcls, _objdb) + (pos) - 1).ToString();
        }

        protected void chk_locall_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_loc1.Text.Length > 0)
            {
                int _rows = Convert.ToInt32(txt_rows.Text);
                for (int i = 2; i <= _rows; i++)
                {
                    TextBox _txt = (TextBox)this.FindControl("txt_loc" + i.ToString());
                    _txt.Text = txt_loc1.Text;
                }
            }
        }

        protected void chk_fedall_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_fed1.Text.Length > 0)
            {
                int _rows = Convert.ToInt32(txt_rows.Text);
                for (int i = 2; i <= _rows; i++)
                {
                    TextBox _txt = (TextBox)this.FindControl("txt_fed" + i.ToString());
                    _txt.Text = txt_fed1.Text;
                }
            }
        }

        protected void chk_pptoall_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_ppto1.Text.Length > 0)
            {
                int _rows = Convert.ToInt32(txt_rows.Text);
                for (int i = 2; i <= _rows; i++)
                {
                    TextBox _txt = (TextBox)this.FindControl("txt_ppto" + i.ToString());
                    _txt.Text = txt_ppto1.Text;
                }
            }
        }

        protected void chk_suball_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_sub1.Text.Length > 0)
            {
                int _rows = Convert.ToInt32(txt_rows.Text);
                for (int i = 2; i <= _rows; i++)
                {
                    TextBox _txt = (TextBox)this.FindControl("txt_sub" + i.ToString());
                    _txt.Text = txt_sub1.Text;
                }
            }
        }

        protected void chk_flvlall_CheckedChanged(object sender, EventArgs e)
        {
            if (dr_fvl1.SelectedItem.Text!="--select--")
            {
                int _rows = Convert.ToInt32(txt_rows.Text);
                for (int i = 2; i <= _rows; i++)
                {
                    DropDownList _drlist = (DropDownList)this.FindControl("dr_fvl" + i.ToString());
                    _drlist.ClearSelection();
                    _drlist.Items.FindByText(dr_fvl1.SelectedItem.Text).Selected = true;
                    TextBox _txt = (TextBox)this.FindControl("txt_seq" + i.ToString());
                    TextBox _tbz=(TextBox)this.FindControl("txt_bz" + i.ToString());
                    _txt.Text = Get_SeqNo(dr_fvl1.SelectedItem.Text, _tbz.Text, i);
                }
            }
        }

        protected void dr_fvl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_seq1.Text = Get_SeqNo(dr_fvl1.SelectedItem.Text, txt_bz1.Text, 1);
        }

        protected void dr_fvl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_seq2.Text = Get_SeqNo(dr_fvl2.SelectedItem.Text, txt_bz2.Text, 2);
        }

        protected void dr_fvl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_seq3.Text = Get_SeqNo(dr_fvl3.SelectedItem.Text, txt_bz3.Text, 3);
        }

        protected void dr_fvl4_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_seq4.Text = Get_SeqNo(dr_fvl4.SelectedItem.Text, txt_bz4.Text, 4);
        }

        protected void dr_fvl5_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_seq5.Text = Get_SeqNo(dr_fvl5.SelectedItem.Text, txt_bz5.Text, 5);
        }

        protected void dr_fvl6_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_seq6.Text = Get_SeqNo(dr_fvl6.SelectedItem.Text, txt_bz6.Text, 6);
        }

        protected void dr_fvl7_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_seq7.Text = Get_SeqNo(dr_fvl7.SelectedItem.Text, txt_bz7.Text, 7);
        }

        protected void dr_fvl8_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_seq8.Text = Get_SeqNo(dr_fvl8.SelectedItem.Text, txt_bz8.Text, 8);
        }

        protected void dr_fvl9_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_seq9.Text = Get_SeqNo(dr_fvl9.SelectedItem.Text, txt_bz9.Text, 9);
        }

        protected void dr_fvl10_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_seq10.Text = Get_SeqNo(dr_fvl10.SelectedItem.Text, txt_bz10.Text, 10);
        }
        protected void add_initial_data(string _reff,string _zone,string _cate, string _flvl,int _seqno,string _loc,string _ffrom,string _ppto,string _sub,int pos)
        {
            string _sys = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.c_s_id = 2;
            _objcas.prj_code = "123";
            _objcas.uid = "admin@cmlinternational.net";
            _objcas.sys = Convert.ToInt32(_sys);
            _objcas.reff = _reff;
            _objcas.b_zone = _zone;
            _objcas.cate = _cate;
            _objcas.f_level = _flvl;
            _objcas.seq_no = _seqno;
            _objcas.desc = _sub;
            _objcas.loca = _loc;
            _objcas.p_power_to = _ppto;
            _objcas.fed_from = _ffrom;
            _objcas.sub_st = _sub;
            _objcas.s_c_m = _sub;
            _objcas.dev1 ="0";
            //if ((string)Session["sch"] == "10" || (string)Session["sch"] == "16" || (string)Session["sch"] == "20")
            //    _objcas.dev2 = txtdesc.Text;
            //else
            //    _objcas.dev2 = "0";
            //if ((string)Session["sch"] == "20")
            //    _objcas.dev3 = txtpprovideto.Text;
            //else
            //    _objcas.dev3 = "0";
            _objcas.dev2 = _sub;
            _objcas.dev3 = _ppto;
            _objcas.mode = 1;
            _objcas.cas_id = 0;
            _objcas.Position = pos;
            _objbll.Cassheet_Master(_objcas, _objdb);
            //Get_Position();
            //Get_SeqNo();

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            if (IsNumeric(txt_rows.Text) == true)
            {
                int _rows=Convert.ToInt32(txt_rows.Text);
                for (int i = 1; i <= _rows; i++)
                {
                    TextBox _reff = (TextBox)this.FindControl("txt_eref" + i.ToString());
                    TextBox _bz = (TextBox)this.FindControl("txt_bz" + i.ToString());
                    TextBox _cat = (TextBox)this.FindControl("txt_cat" + i.ToString());
                    DropDownList _flvl = (DropDownList)this.FindControl("dr_fvl" + i.ToString());
                    TextBox _seq = (TextBox)this.FindControl("txt_seq" + i.ToString());
                    TextBox _loc = (TextBox)this.FindControl("txt_loc" + i.ToString());
                    TextBox _fed = (TextBox)this.FindControl("txt_fed" + i.ToString());
                    TextBox _ppto = (TextBox)this.FindControl("txt_ppto" + i.ToString());
                    TextBox _sub = (TextBox)this.FindControl("txt_sub" + i.ToString());
                    add_initial_data(_reff.Text, _bz.Text, _cat.Text, _flvl.SelectedItem.Text, Convert.ToInt32(_seq.Text), _loc.Text, _fed.Text, _ppto.Text, _sub.Text, i);                               }
            }
            string _prm = "123_S2";
            Response.Redirect("../Cassheet_DataEntry.aspx?id=" + _prm);
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            string _prm = "123_S2";
            Response.Redirect("../Cassheet_DataEntry.aspx?id=" + _prm);
        }
     
    }
}
