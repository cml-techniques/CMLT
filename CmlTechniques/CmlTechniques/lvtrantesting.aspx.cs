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
    public partial class lvtrantesting : System.Web.UI.Page
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
            Session["sch"] = "7";
            _objcas.sch = Convert.ToInt32((string)Session["sch"]);
            _objcas.prj_code = "1";
            _objcas.sys = 2;
            myview.DataSource = _objbll.Load_casMain_Edit(_objcas,_objdb);
            myview.DataBind();
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
                    TextBox wir = (TextBox)e.Item.FindControl("wir_test");
                    TextBox ratio = (TextBox)e.Item.FindControl("ratio_test");
                    TextBox wr = (TextBox)e.Item.FindControl("wr_test");
                    TextBox vg = (TextBox)e.Item.FindControl("vg_test");
                    TextBox fun_ = (TextBox)e.Item.FindControl("functional_");
                    //TextBox dvc = (TextBox)e.Item.FindControl("devicesTextBox");
                    //TextBox c_t = (TextBox)e.Item.FindControl("ttl_cold_testedTextBox");
                    TextBox ir = (TextBox)e.Item.FindControl("ir_");
                    TextBox hv = (TextBox)e.Item.FindControl("hv_test");
                    TextBox lv_ir = (TextBox)e.Item.FindControl("lv_ir_test_gen");
                    TextBox con_acce = (TextBox)e.Item.FindControl("con_acce");
                    TextBox comm = (TextBox)e.Item.FindControl("comm_TextBox");
                    TextBox act_by = (TextBox)e.Item.FindControl("act_byTextBox");
                    TextBox act_date = (TextBox)e.Item.FindControl("act_date");
                    Edit_Cas_Main(Convert.ToInt32(cas_id.Text), 9, reff.Text, loca.Text, power.Text, fed.Text, desc.Text, 0, power_on.Text, comm.Text, con_acce.Text, act_by.Text, act_date.Text);
                    edit_asset_code(Convert.ToInt32(cas_id.Text), cate.Text, zone.Text, level.Text, seq.Text);
                    Update_Test1(Convert.ToInt32(cas_id.Text),wir.Text,ratio.Text,wr.Text,vg.Text,fun_.Text,ir.Text,hv.Text,lv_ir.Text);
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
        protected void Update_Test1(int cas_id, string wir, string ratio, string wr, string vg, string _fun, string _ir, string hv, string lv_ir)
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
            _objcls.ttl_cold_tested = 0;
            _objcls.cold_complete = "";
            _objcls.ttl_live_tested = 0;
            _objcls.live_complete = "";
            _objcls.pre_com = "";
            _objcls.c_f = "";
            _objcls.load = "";
            _objcls.full_run = "";
            _objcls.wir_test = wir;
            _objcls.ratio_test = ratio;
            _objcls.wr_test = wr;
            _objcls.vg_test = vg;
            _objcls.hv_test = hv;
            _objcls.lv_ir_test_gen = lv_ir;
            _objbll.Insert_Cas_Testing(_objcls,_objdb);
        }

        protected void myview_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            myview.EditIndex = e.NewEditIndex;
            Populate_view();
        }

        protected void myview_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            myview.EditIndex = -1;
            Populate_view();
        }
    }
}
