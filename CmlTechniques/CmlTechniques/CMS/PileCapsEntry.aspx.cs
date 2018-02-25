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
    public partial class PileCapsEntry : System.Web.UI.Page
    {
        public static DataTable _dtmaster;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                lblprj.Text = "12761";
                lbluid.Text = (string)Session["uid"];
                Load_Master();
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
            }
        }
        protected void add_initial_data()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.c_s_id = 25;
            _objcas.prj_code = lblprj.Text;
            _objcas.uid = lbluid.Text;
            _objcas.sys = 1134;
            _objcas.reff = txt_pno.Text;
            _objcas.b_zone = txt_zone.Text;
            _objcas.cate = "PC";
            _objcas.f_level = "";
            _objcas.seq_no = 0;
            _objcas.desc = txt_ohms.Text;
            _objcas.loca = txt_wir.Text;
            _objcas.p_power_to = txt_date.Text;
            _objcas.fed_from = txt_status.Text;
            _objcas.sub_st = txt_accepted.Text;
            _objcas.s_c_m = txt_comments.Text;
            _objcas.dev1 = "0";
            _objcas.dev2 = "0";
            _objcas.dev3 = "0";
            _objcas.mode = 1;
            _objcas.cas_id = 0;
            _objcas.Position = Convert.ToInt32(Get_Position());
            _objbll.Cassheet_Master(_objcas, _objdb);

        }
        private string Get_Position()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.sys = 1134;
            return _objbll.Get_Position(_objcls, _objdb).ToString();
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            if (IsnullValidation() == true) return;
            add_initial_data();
            Load_Master();
            Clear();
        }
        private bool IsnullValidation()
        {
            if (txt_pno.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Enter Pile Number');", true);
                return true;
            }
            return false;
        }
        private void Load_Master()
        {
            //_dtMaster = new DataTable();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = 25;
            _objcas.prj_code = lblprj.Text;
            _dtmaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
            rptdetails.DataSource = _dtmaster;
            rptdetails.DataBind();
        }
        protected void rptdetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label _slno = (Label)e.Item.FindControl("lblsl");
                _slno.Text = (e.Item.ItemIndex + 1).ToString();
            }
        }
        protected void btnimport_Click(object sender, EventArgs e)
        {
            string _url = "Import.aspx?id=25_" + lblprj.Text;
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _url + "','','left=300,top=200,width=500,height=400,menubar=0,toolbar=0,scrollbars=1,status=0,resizable=0');", true);
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
           string _prm = "ReportsNew.aspx?prj=" + lblprj.Text + "&div=0&type=pc&sch=0";
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _prm + "','','left=200,top=50,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
        }

        protected void btndelete1_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (RepeaterItem _itm in rptdetails.Items)
            {
                CheckBox checkbox = (CheckBox)_itm.FindControl("chkrow1");
                    if (checkbox.Checked == true)
                    {
                        count += 1;
                        Label _id = (Label)_itm.FindControl("lblcasid");
                        Delete_Inidata(Convert.ToInt32(_id.Text));
                    }
            }
            if (count == 0) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');", true);
            else
            {
                string _msg = count.ToString() + " Row(s) Deleted";
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _msg + "');", true);
                Load_Master();
                
            }
        }
        private void Delete_Inidata(int _id)
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
            _objcas.cas_id = _id;
            _objbll.Cassheet_Master(_objcas, _objdb);
        }
        private void Edit_Inidata(int _id)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.c_s_id = 25;
            _objcas.prj_code = lblprj.Text;
            _objcas.uid = lbluid.Text;
            _objcas.sys = 1134;
            _objcas.reff = upreff.Text;
            _objcas.b_zone = upzone.Text;
            _objcas.cate = "PC";
            _objcas.f_level = "";
            _objcas.seq_no = 0;
            _objcas.desc = upohms.Text;
            _objcas.loca = upwir.Text;
            _objcas.p_power_to = update.Text;
            _objcas.fed_from = upstatus.Text;
            _objcas.sub_st = upaccepted.Text;
            _objcas.s_c_m = upcomment.Text;
            _objcas.dev1 = "0";
            _objcas.dev2 = "0";
            _objcas.dev3 = "0";
            _objcas.mode = 0;
            _objcas.cas_id = _id;
            _objcas.Position = Convert.ToInt32(Get_Position());
            _objbll.Cassheet_Master(_objcas, _objdb);
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            int count = 0;
            int _casid = 0;
            foreach (RepeaterItem _itm in rptdetails.Items)
            {
                CheckBox checkbox = (CheckBox)_itm.FindControl("chkrow1");
                if (checkbox.Checked == true)
                {
                    count += 1;
                    Label _id = (Label)_itm.FindControl("lblcasid");
                    _casid = Convert.ToInt32(_id.Text);
                }
            }
            if (count == 0) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');", true);
            else
            {
                btnDummy_ModalPopupExtender.Show();
                arrange_edit(_casid);

            }
           
        }
        protected void arrange_edit(int _id)
        {
            lblupcid.Text = _id.ToString();
            var _result = from _data in _dtmaster.AsEnumerable()
                          where _data.Field<int>(0) == _id
                          select _data;
            foreach (var row in _result)
            {
                upreff.Text = row["E_b_ref"].ToString();
                upzone.Text = row["B_Z"].ToString();
                upohms.Text = row["Des"].ToString();
                upwir.Text = row["Loc"].ToString();
                update.Text = row["P_P_to"].ToString();
                upstatus.Text = row["F_from"].ToString();
                upaccepted.Text = row["Substation"].ToString();
                upcomment.Text = row["S_c_m"].ToString();
            }
        }
        private void Clear()
        {
            txt_accepted.Text = "";
            txt_comments.Text = "";
            txt_date.Text = "";
            txt_pno.Text = "";
            txt_status.Text = "";
            txt_wir.Text = "";
            txt_zone.Text = "";
            txt_ohms.Text = "";
            
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            Edit_Inidata(Convert.ToInt32(lblupcid.Text));
            btnDummy_ModalPopupExtender.Hide();
            Load_Master();
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender.Hide();
        }
    }
}
