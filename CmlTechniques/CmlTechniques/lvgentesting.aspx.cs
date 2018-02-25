using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;

namespace CmlTechniques
{
    public partial class lvgentesting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Populate_view();
        }
        protected void Populate_view()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clscassheet _objcas = new _clscassheet();
            Session["sch"] = "10";
            _objcas.sch = Convert.ToInt32((string)Session["sch"]);
            _objcas.prj_code = "1";
            _objcas.sys = 9;
            myview.DataSource = _objbll.Load_casMain_Edit(_objcas,_objdb);
            myview.DataBind();

        }

        protected void myview_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            myview.EditIndex = e.NewEditIndex;
            Populate_view();
        }

        protected void myview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                try
                {
                    Label cas_id = (Label)e.Item.FindControl("cas_idLabel");
                    //DropDownList _drsys = (DropDownList)e.Item.FindControl("drsrv");
                    TextBox reff = (TextBox)e.Item.FindControl("reff_TextBox");
                    TextBox cate = (TextBox)e.Item.FindControl("cate_TextBox");
                    TextBox zone = (TextBox)e.Item.FindControl("b_zoneTextBox");
                    TextBox level = (TextBox)e.Item.FindControl("f_levelTextBox");
                    TextBox seq = (TextBox)e.Item.FindControl("seq_noTextBox");
                    TextBox desc = (TextBox)e.Item.FindControl("desc_TextBox");
                    TextBox loca = (TextBox)e.Item.FindControl("loca_TextBox");
                    TextBox power = (TextBox)e.Item.FindControl("p_power_toTextBox");
                    TextBox fed = (TextBox)e.Item.FindControl("fed_fromTextBox");

                    TextBox power_on = (TextBox)e.Item.FindControl("power_on");
                    TextBox pre_com = (TextBox)e.Item.FindControl("pre_com_test");
                    TextBox c_f = (TextBox)e.Item.FindControl("c_f_test");
                    TextBox ir_ = (TextBox)e.Item.FindControl("ir_");
                    TextBox _load = (TextBox)e.Item.FindControl("load_test");
                    TextBox fun_ = (TextBox)e.Item.FindControl("functional_");
                    TextBox full_ = (TextBox)e.Item.FindControl("full_run_test");
                    TextBox dvc = (TextBox)e.Item.FindControl("devicesTextBox");
                    TextBox c_t = (TextBox)e.Item.FindControl("ttl_cold_testedTextBox");
                    TextBox c_c = (TextBox)e.Item.FindControl("cold_complete");
                    TextBox l_t = (TextBox)e.Item.FindControl("ttl_live_testedTextBox");
                    TextBox l_c = (TextBox)e.Item.FindControl("live_complete");
                    TextBox con_acce = (TextBox)e.Item.FindControl("con_acce");
                    TextBox comm = (TextBox)e.Item.FindControl("comm_TextBox");
                    TextBox act_by = (TextBox)e.Item.FindControl("act_byTextBox");
                    TextBox act_date = (TextBox)e.Item.FindControl("act_date");

                    Edit_Cas_Main(Convert.ToInt32(cas_id.Text), 9, reff.Text, loca.Text, power.Text, fed.Text, desc.Text, Convert.ToInt32(dvc.Text), power_on.Text, comm.Text, con_acce.Text, act_by.Text, act_date.Text);
                    edit_asset_code(Convert.ToInt32(cas_id.Text), cate.Text, zone.Text, level.Text, seq.Text);
                    Update_Test1(Convert.ToInt32(cas_id.Text), pre_com.Text, c_f.Text, ir_.Text, _load.Text, fun_.Text, full_.Text, Convert.ToInt32(c_t.Text), c_c.Text, Convert.ToInt32(l_t.Text), l_c.Text);
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + torque.Text + "');", true);
                    Populate_view();

                }
                catch (Exception Ex)
                {
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ Ex.Message.ToString() +"');", true);
                    //Response.Write(Ex.Message.ToString());
                    throw Ex;
                }
            }


        }
        protected void Edit_Cas_Main(int cas_id, int _sys, string reff, string loca, string power, string fed, string desc, int dvc, string power_on, string comm, string con_acce, string act_by, string act_date)
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_clscassheet _objcas = new _clscassheet();
            //_objcas.srv = 1;
            //_objcas.sch = 4;
            //_objcas.sys = _sys;
            //_objcas.reff = reff;
            //_objcas.loca = loca;
            //_objcas.p_power_to = power;
            //_objcas.fed_from = fed;
            //_objcas.uid = "";
            //_objcas.prj_code = "1";
            //_objcas.date = DateTime.Now;
            //_objcas.desc = desc;
            //_objcas.power_on = power_on;
            //_objcas.comm = comm;
            //_objcas.act_by = act_by;
            //_objcas.act_date = act_date;
            //_objcas.con_acce = con_acce;
            //_objcas.filed = false;
            //_objcas.des_vol = "";
            //_objcas.des_flow_rate = "";
            //_objcas.dev = dvc;
            //_objcas.sys_mon = "";
            //_objcas.fa_int = 0;
            //_objcas.cas_id = cas_id;
            //_objcas.mode = 0;
            //_objbll.add_cas_main(_objcas);
        }
        protected void edit_asset_code(int cas_id, string cate, string zone, string level, string seq)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsassetcode _objast = new _clsassetcode();
            _objast.cas_id = cas_id;
            _objast.cate = cate;
            _objast.b_zone = zone;
            _objast.f_level = level;
            _objast.seq_no = seq;
            _objbll.Edit_asset_code(_objast,_objdb);
        }
        protected void Update_Test1(int cas_id, string pre_com, string c_f, string _ir, string _load, string _fun, string _full, int c_t, string c_c, int l_t, string l_c)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _cls_ele_testing _objcls = new _cls_ele_testing();
            _objcls.cas_id = cas_id;
            _objcls.torque = "";
            _objcls.ir = _ir;
            _objcls.pressure = "";
            _objcls.sec_injection = "";
            _objcls.con_resistance = "";
            _objcls.functional = _fun;
            _objcls.ttl_cold_tested = c_t;
            _objcls.cold_complete = c_c;
            _objcls.ttl_live_tested = l_t;
            _objcls.live_complete = l_c;
            _objcls.pre_com = pre_com;
            _objcls.c_f = c_f;
            _objcls.load = _load;
            _objcls.full_run = _full;
            _objcls.wir_test = "";
            _objcls.ratio_test = "";
            _objcls.wr_test = "";
            _objcls.vg_test = "";
            _objcls.hv_test = "";
            _objcls.lv_ir_test_gen = "";
            _objbll.Insert_Cas_Testing(_objcls,_objdb);
        }

        protected void myview_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            myview.EditIndex = -1;
            Populate_view();
        }
    }
}