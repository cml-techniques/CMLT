using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.IO;

namespace CmlTechniques
{
    public partial class cassecodata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Load_Ini_Data();
        }
        protected void Load_Ini_Data()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clscassheet _objcas = new _clscassheet();
            //Session["sch"] = Request.QueryString[0].ToString();
            _objcas.sch = 4;
            _objcas.prj_code = "1";
            my_in_view.DataSource = _objbll.Load_casMain(_objcas,_objdb);
            my_in_view.DataBind();
            //load_cas_sys();
        }
        protected void load_cas_sys()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clscassheet _objcls = new _clscassheet();
            _objcls.sch = 4;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "FileNotFoundWarning", "alert('" + (string)Session["sch"] + "');", true);
            //.DataSource = _objbll.Load_cas_sys(_objcls);
            //drsys.DataTextField = "sys_name";
            //drsys.DataValueField = "sys_id";
            //drsys.DataBind();
            //DropDownList _drlist = (DropDownList)my_in_view.EditItem.FindControl("drsrv");
            DropDownList _drl = (DropDownList)my_in_view.EditItem.FindControl("drsrv");
            _drl.DataSource = _objbll.Load_cas_sys(_objcls,_objdb);
            //_drlist.DataTextField = "sys_name";
            //_drlist.DataValueField = "sys_id";
            _drl.DataBind();
        }

        protected void my_in_view_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            my_in_view.EditIndex = e.NewEditIndex;
            Load_Ini_Data();
            //my_in_view.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //foreach (ListViewItem  dgi in my_in_view.Items)
            //    foreach (TableCell tcGridCells in dgi.i
            //        tcGridCells.Attributes.Add("class", "sborder");
            ////Render the datagrid
            //dgRecord.RenderControl(htmlWrite);
            ////Add the style sheet class here
            //Response.Write(@"<style> .sborder { color : Red;border : 1px Solid Balck; } </style> ");
            ////Export
            //Response.Write(stringWrite.ToString());
            ////End
            //Response.End();
            Response.Clear();    // Setup the response header.    
            Response.Buffer = true;    
            Response.AddHeader("content-disposition", "attachment; filename=Trucks.xls");    
            Response.ContentType = "application/vnd.ms-excel";    
            Response.Charset = "";    // Turn off view state.    
            this.EnableViewState = false;    // Create a string writer.    
            var stringWriter = new StringWriter();    // Create an HTML text writer and give it a string writer to use.    
            var htmlTextWriter = new HtmlTextWriter(stringWriter);    // Disable paging so we get all rows.    
            //dsTrucks.EnablePaging = false;    // Render the list view control into the HTML text writer.    
            my_in_view.DataBind();
            my_in_view.RenderControl(htmlTextWriter);
            //listViewTrucks.RenderControl(htmlTextWriter);    // Grab the final HTML out of the string writer.    
            string output = stringWriter.ToString();    // Write the HTML output to the response, which in this case, is an Excel file.    
            Response.Write(output);    
            Response.End();
        }
        protected void Edit_Cas_Main(int cas_id, int _sys, string reff, string loca, string power, string fed, string desc, int dvc,DateTime power_on,string comm,DateTime con_acce,string act_by,DateTime act_date)
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
            //_objcas.power_on = "";
            //_objcas.comm = comm;
            //_objcas.act_by = act_by;
            //_objcas.act_date = "";
            //_objcas.con_acce = "";
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
        protected void Update_Test1(int cas_id,DateTime _torque,DateTime _ir,DateTime _press,DateTime _sec,DateTime _con,DateTime _fun,int c_t,DateTime c_c,int l_t,DateTime l_c)           
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _cls_ele_testing _objcls = new _cls_ele_testing();
            _objcls.cas_id = cas_id;
            _objcls.torque = "";
            _objcls.ir = "";
            _objcls.pressure = "";
            _objcls.sec_injection = "";
            _objcls.con_resistance = "";
            _objcls.functional = "";
            _objcls.ttl_cold_tested = c_t;
            _objcls.cold_complete = "";
            _objcls.ttl_live_tested = l_t;
            _objcls.live_complete = "";
            _objbll.add_ele_pnl_eqi_test(_objcls,_objdb);
            _objbll.add_ele_out_cir_test(_objcls,_objdb);
        }

        protected void my_in_view_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                Label cas_id=(Label)e.Item.FindControl("cas_idLabel");
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
                BasicFrame.WebControls.BasicDatePicker power_on = (BasicFrame.WebControls.BasicDatePicker)e.Item.FindControl("dt_power_on");
                BasicFrame.WebControls.BasicDatePicker torque = (BasicFrame.WebControls.BasicDatePicker)e.Item.FindControl("dt_torque");
                BasicFrame.WebControls.BasicDatePicker ir = (BasicFrame.WebControls.BasicDatePicker)e.Item.FindControl("dt_ir");
                BasicFrame.WebControls.BasicDatePicker pressure = (BasicFrame.WebControls.BasicDatePicker)e.Item.FindControl("dt_pressure");
                BasicFrame.WebControls.BasicDatePicker sec = (BasicFrame.WebControls.BasicDatePicker)e.Item.FindControl("dt_sec");
                BasicFrame.WebControls.BasicDatePicker con = (BasicFrame.WebControls.BasicDatePicker)e.Item.FindControl("dt_con");
                BasicFrame.WebControls.BasicDatePicker fun = (BasicFrame.WebControls.BasicDatePicker)e.Item.FindControl("dt_fun");
                TextBox dvc = (TextBox)e.Item.FindControl("devicesTextBox");
                TextBox c_t = (TextBox)e.Item.FindControl("ttl_cold_testedTextBox");
                BasicFrame.WebControls.BasicDatePicker c_c = (BasicFrame.WebControls.BasicDatePicker)e.Item.FindControl("dt_c_c");
                TextBox l_t = (TextBox)e.Item.FindControl("ttl_live_testedTextBox");
                BasicFrame.WebControls.BasicDatePicker l_c = (BasicFrame.WebControls.BasicDatePicker)e.Item.FindControl("dt_l_c");
                BasicFrame.WebControls.BasicDatePicker con_acce = (BasicFrame.WebControls.BasicDatePicker)e.Item.FindControl("dt_con_acc");
                TextBox comm = (TextBox)e.Item.FindControl("comm_TextBox");
                TextBox act_by = (TextBox)e.Item.FindControl("act_byTextBox");
                BasicFrame.WebControls.BasicDatePicker act_date = (BasicFrame.WebControls.BasicDatePicker)e.Item.FindControl("dt_act");
                Edit_Cas_Main(Convert.ToInt32(cas_id.Text), Convert.ToInt32(_drsys.SelectedItem.Value), reff.Text, loca.Text, power.Text, fed.Text, desc.Text, Convert.ToInt32(dvc.Text), Convert.ToDateTime(power_on.Text), comm.Text, Convert.ToDateTime(con_acce.Text), act_by.Text, Convert.ToDateTime(act_date.Text));
                Load_Ini_Data();

            }
        }

        protected void my_in_view_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            //Label cas_id = (Label)my_in_view.Items[e.ItemIndex].FindControl("cas_idLabel");
            //DropDownList _drsys = (DropDownList)my_in_view.Items[e.ItemIndex].FindControl("drsrv");
            //TextBox reff = (TextBox)my_in_view.Items[e.ItemIndex].FindControl("reff_TextBox");
            //TextBox cate = (TextBox)my_in_view.Items[e.ItemIndex].FindControl("cate_TextBox");
            //TextBox zone = (TextBox)my_in_view.Items[e.ItemIndex].FindControl("b_zoneTextBox");
            //TextBox level = (TextBox)my_in_view.Items[e.ItemIndex].FindControl("f_levelTextBox");
            //TextBox seq = (TextBox)my_in_view.Items[e.ItemIndex].FindControl("seq_noTextBox");
            //TextBox desc = (TextBox)my_in_view.Items[e.ItemIndex].FindControl("desc_TextBox");
            //TextBox loca = (TextBox)my_in_view.Items[e.ItemIndex].FindControl("loca_TextBox");
            //TextBox power = (TextBox)my_in_view.Items[e.ItemIndex].FindControl("p_power_toTextBox");
            //TextBox fed = (TextBox)my_in_view.Items[e.ItemIndex].FindControl("fed_fromTextBox");
            //BasicFrame.WebControls.BasicDatePicker power_on = (BasicFrame.WebControls.BasicDatePicker)my_in_view.Items[e.ItemIndex].FindControl("dt_power_on");
            //BasicFrame.WebControls.BasicDatePicker torque = (BasicFrame.WebControls.BasicDatePicker)my_in_view.Items[e.ItemIndex].FindControl("dt_torque");
            //BasicFrame.WebControls.BasicDatePicker ir = (BasicFrame.WebControls.BasicDatePicker)my_in_view.Items[e.ItemIndex].FindControl("dt_ir");
            //BasicFrame.WebControls.BasicDatePicker pressure = (BasicFrame.WebControls.BasicDatePicker)my_in_view.Items[e.ItemIndex].FindControl("dt_pressure");
            //BasicFrame.WebControls.BasicDatePicker sec = (BasicFrame.WebControls.BasicDatePicker)my_in_view.Items[e.ItemIndex].FindControl("dt_sec");
            //BasicFrame.WebControls.BasicDatePicker con = (BasicFrame.WebControls.BasicDatePicker)my_in_view.Items[e.ItemIndex].FindControl("dt_con");
            //BasicFrame.WebControls.BasicDatePicker fun = (BasicFrame.WebControls.BasicDatePicker)my_in_view.Items[e.ItemIndex].FindControl("dt_fun");
            //TextBox dvc = (TextBox)my_in_view.Items[e.ItemIndex].FindControl("devicesTextBox");
            //TextBox c_t = (TextBox)my_in_view.Items[e.ItemIndex].FindControl("ttl_cold_testedTextBox");
            //BasicFrame.WebControls.BasicDatePicker c_c = (BasicFrame.WebControls.BasicDatePicker)my_in_view.Items[e.ItemIndex].FindControl("dt_c_c");
            //TextBox l_t = (TextBox)my_in_view.Items[e.ItemIndex].FindControl("ttl_live_testedTextBox");
            //BasicFrame.WebControls.BasicDatePicker l_c = (BasicFrame.WebControls.BasicDatePicker)my_in_view.Items[e.ItemIndex].FindControl("dt_l_c");
            //BasicFrame.WebControls.BasicDatePicker con_acce = (BasicFrame.WebControls.BasicDatePicker)my_in_view.Items[e.ItemIndex].FindControl("dt_con_acc");
            //TextBox comm = (TextBox)my_in_view.Items[e.ItemIndex].FindControl("comm_TextBox");
            //TextBox act_by = (TextBox)my_in_view.Items[e.ItemIndex].FindControl("act_byTextBox");
            //BasicFrame.WebControls.BasicDatePicker act_date = (BasicFrame.WebControls.BasicDatePicker)my_in_view.Items[e.ItemIndex].FindControl("dt_act");
            //Edit_Cas_Main(Convert.ToInt32(cas_id.Text), Convert.ToInt32(_drsys.SelectedItem.Value), reff.Text, loca.Text, power.Text, fed.Text, desc.Text, Convert.ToInt32(dvc.Text), Convert.ToDateTime(power_on.Text), comm.Text, Convert.ToDateTime(con_acce.Text), act_by.Text, Convert.ToDateTime(act_date.Text));
            my_in_view.EditIndex = -1;
            Load_Ini_Data();
        }

        protected void export_Click(object sender, EventArgs e)
        {
            //ListView list_export = new ListView();
            //list_export.DataSource = SqlDataSource1;
            //list_export.DataBind();
            Response.Clear();    // Setup the response header.    
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=CasSheet.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";    // Turn off view state.    
            this.EnableViewState = false;    // Create a string writer.    
            var stringWriter = new StringWriter();    // Create an HTML text writer and give it a string writer to use.    
            var htmlTextWriter = new HtmlTextWriter(stringWriter);    // Disable paging so we get all rows.    
            //dsTrucks.EnablePaging = false;    // Render the list view control into the HTML text writer.    
            // my_in_view.DataBind();
            my_in_view.RenderControl(htmlTextWriter);
            //listViewTrucks.RenderControl(htmlTextWriter);    // Grab the final HTML out of the string writer.    
            string output = stringWriter.ToString();    // Write the HTML output to the response, which in this case, is an Excel file.    
            Response.Write(output);
            Response.End();
        }

        protected void print_Click(object sender, EventArgs e)
        {

        }
        
    }
}
