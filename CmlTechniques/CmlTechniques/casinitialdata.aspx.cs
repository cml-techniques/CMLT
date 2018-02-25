using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Data;

namespace CmlTechniques
{
    public partial class casinitialdata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Load_Ini_Data();
        }
        protected void Load_Ini_Data()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_clscassheet _objcas = new _clscassheet();
            //Session["sch"] = Request.QueryString[0].ToString();
            //_objcas.sch = Convert.ToInt32(Request.QueryString[0].ToString());
            //_objcas.prj_code = (string)Session["project"];
            //my_in_view.DataSource = _objbll.Load_casMain(_objcas);
            //my_in_view.DataBind();
            //load_cas_sys();
        }
        protected void add_initial_data( int _sys,string reff,string loca,string power,string fed,string desc,int dvc)
        {
            //if (IsNullvalidation() == true) return;
           // BLL_Dml _objbll = new BLL_Dml();
           // _clscassheet _objcas = new _clscassheet();
           // _objcas.srv = 1;
           // _objcas.sch = 4;
           //// DropDownList _drlist = (DropDownList)my_in_view.InsertItem.FindControl("drsrv");
           // _objcas.sys = _sys;
           // _objcas.reff = reff;
           // _objcas.loca = loca;
           // _objcas.p_power_to = power;
           // _objcas.fed_from = fed;
           // _objcas.uid = "";
           // _objcas.prj_code = "1";
           // _objcas.date = DateTime.Now;
           // _objcas.desc = desc;
           // _objcas.power_on = "";
           // _objcas.comm = "";
           // _objcas.act_by = "";
           // _objcas.act_date = "";
           // _objcas.con_acce = "";
           // _objcas.filed = false;
           // _objcas.des_vol = "";
           // _objcas.des_flow_rate = "";
           // _objcas.dev = dvc;
           // _objcas.sys_mon = "";
           // _objcas.fa_int = 0;
           // _objcas.cas_id = 0;
           // _objcas.mode = 1;
           // _objbll.add_cas_main(_objcas);

        }
        void dupl()
        {
            TextBox reff = (TextBox)my_in_view.InsertItem.FindControl("reff_TextBox");
            TextBox reff1 = (TextBox)my_in_view.Items[0].FindControl("reff_TextBox");
            reff.Text = reff1.Text;
        }
        protected void add_asset_code( string cate,string zone,string level,string seq)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsassetcode _objast = new _clsassetcode();
            _objast.cate = cate;
            _objast.b_zone = zone;
            _objast.f_level = level;
            _objast.seq_no = seq;
            _objbll.add_asset_code(_objast,_objdb);
        }
        protected void load_cas_sys()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clscassheet _objcls = new _clscassheet();
            _objcls.sch = Convert.ToInt32((string)Session["sch"]);
            //ScriptManager.RegisterStartupScript(this, typeof(string), "FileNotFoundWarning", "alert('" + (string)Session["sch"] + "');", true);
            //.DataSource = _objbll.Load_cas_sys(_objcls);
            //drsys.DataTextField = "sys_name";
            //drsys.DataValueField = "sys_id";
            //drsys.DataBind();
            DropDownList _drlist=(DropDownList)my_in_view.InsertItem.FindControl("drsrv");
            _drlist.DataSource=_objbll.Load_cas_sys(_objcls,_objdb);
            //_drlist.DataTextField = "sys_name";
            //_drlist.DataValueField = "sys_id";
            _drlist.DataBind();
        }
        protected void my_in_view_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                DropDownList _drsys = (DropDownList)e.Item.FindControl("drsrv");
                TextBox reff = (TextBox)e.Item.FindControl("reff_TextBox");
                TextBox cate = (TextBox)e.Item.FindControl("cate_TextBox");
                TextBox zone = (TextBox)e.Item.FindControl("b_zoneTextBox");
                TextBox level = (TextBox)e.Item.FindControl("f_levelTextBox");
                TextBox seq = (TextBox)e.Item.FindControl("seq_noTextBox");
                TextBox desc = (TextBox)e.Item.FindControl("desc_TextBox");
                TextBox loca = (TextBox)e.Item.FindControl("loca_TextBox");
                TextBox power = (TextBox)e.Item.FindControl("p_power_toTextBox");
                TextBox fed = (TextBox)e.Item.FindControl("fed_fromTextBox");
                TextBox dvc = (TextBox)e.Item.FindControl("devicesTextBox");
                //ScriptManager.RegisterStartupScript(this, typeof(string), "FileNotFoundWarning", "alert('_drlist.SelectedItem.Value');", true);
                if (dvc.Text.Length <= 0)
                    dvc.Text = "0";
                add_initial_data(Convert.ToInt32(_drsys.SelectedItem.Value),reff.Text,loca.Text,power.Text,fed.Text,desc.Text,Convert.ToInt32(dvc.Text));
                add_asset_code(cate.Text, zone.Text, level.Text, seq.Text);
                ScriptManager.RegisterStartupScript(this, typeof(string), "FileNotFoundWarning", "alert('Row Updated');", true);
                Load_Ini_Data();
            }
        }

        protected void my_in_view_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            
        }

        protected void my_in_view_ItemInserting1(object sender, ListViewInsertEventArgs e)
        {

        }

        protected void my_in_view_DataBound(object sender, EventArgs e)
        {
            default_values();
        }
        protected void default_values()
        {
            if (my_in_view.Items.Count <= 0) return;
            int _count = my_in_view.Items.Count - 1;
            Label pr_sys = (Label)my_in_view.Items[_count].FindControl("sys_idLabel");
            Label pr_reff = (Label)my_in_view.Items[_count].FindControl("reff_Label");
            Label pr_cate = (Label)my_in_view.Items[_count].FindControl("cate_Label");
            Label pr_zone = (Label)my_in_view.Items[_count].FindControl("b_zoneLabel");
            Label pr_level = (Label)my_in_view.Items[_count].FindControl("f_levelLabel");
            Label pr_seq = (Label)my_in_view.Items[_count].FindControl("seq_noLabel");
            Label pr_desc = (Label)my_in_view.Items[_count].FindControl("desc_Label");
            Label pr_loca = (Label)my_in_view.Items[_count].FindControl("loca_Label");
            Label pr_power = (Label)my_in_view.Items[_count].FindControl("p_power_toLabel");
            Label pr_fed = (Label)my_in_view.Items[_count].FindControl("fed_fromLabel");
            Label pr_dvc = (Label)my_in_view.Items[_count].FindControl("devicesLabel");

            DropDownList _drsys = (DropDownList)my_in_view.InsertItem.FindControl("drsrv");
            TextBox reff = (TextBox)my_in_view.InsertItem.FindControl("reff_TextBox");
            TextBox cate = (TextBox)my_in_view.InsertItem.FindControl("cate_TextBox");
            TextBox zone = (TextBox)my_in_view.InsertItem.FindControl("b_zoneTextBox");
            TextBox level = (TextBox)my_in_view.InsertItem.FindControl("f_levelTextBox");
            TextBox seq = (TextBox)my_in_view.InsertItem.FindControl("seq_noTextBox");
            TextBox desc = (TextBox)my_in_view.InsertItem.FindControl("desc_TextBox");
            TextBox loca = (TextBox)my_in_view.InsertItem.FindControl("loca_TextBox");
            TextBox power = (TextBox)my_in_view.InsertItem.FindControl("p_power_toTextBox");
            TextBox fed = (TextBox)my_in_view.InsertItem.FindControl("fed_fromTextBox");
            TextBox dvc = (TextBox)my_in_view.InsertItem.FindControl("devicesTextBox");

           // _drsys.Text = pr_sys.Text;
            //_drsys.SelectedItem.Selected = false;
            int _idx = _drsys.Items.IndexOf(_drsys.Items.FindByText(pr_sys.Text));
            _drsys.SelectedIndex = _drsys.Items.IndexOf(_drsys.Items.FindByText(pr_sys.Text)); 
            reff.Text = pr_reff.Text;
            cate.Text = pr_cate.Text;
            zone.Text = pr_zone.Text;
            level.Text = pr_level.Text;
            seq.Text = pr_seq.Text;
            desc.Text = pr_desc.Text;
            loca.Text = pr_loca.Text;
            power.Text = pr_power.Text;
            fed.Text = pr_fed.Text;
            dvc.Text = pr_dvc.Text;

        }
       
    }
}
