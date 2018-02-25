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
    public partial class MsEntryHMIMrpt : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                lblprj.Text = Request.QueryString["prj"].ToString();
                //lbluser.Text = Request.QueryString["auh"].ToString();
                lbluser.Text = (string)Session["uid"];

                lblid.Text = Request.QueryString["Id"].ToString();

                Session["building_id"] = "";
                Session["building_id"] = "0";

                loadBuilding();

                string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);


            }

        }
        private void loadBuilding()
        {
            Telerik.Web.UI.DropDownListItem item;
            if (lblprj.Text == "HMIM")
            {

                item = new Telerik.Web.UI.DropDownListItem();
                item.Text = "Haram/Piazza";
                item.Value = "1";
                rd_Building.Items.Add(item);


                item = new Telerik.Web.UI.DropDownListItem();
                item.Text = "Service Building";
                item.Value = "2";
                rd_Building.Items.Add(item);

                item = new Telerik.Web.UI.DropDownListItem();
                item.Text = "CUC/T4";
                item.Value = "3";
                rd_Building.Items.Add(item);


            }
            else if (lblprj.Text == "ABS")
            {
                item = new Telerik.Web.UI.DropDownListItem();
                item.Text = "PK2";
                item.Value = "1";
                rd_Building.Items.Add(item);

                item = new Telerik.Web.UI.DropDownListItem();
                item.Text = "PK4";
                item.Value = "2";
                rd_Building.Items.Add(item);

            }


        }
        private string Get_ProjectName()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            return _objbll.Get_ProjectName(_objcls, _objdb);
        }
        private string Get_BuildingPermission()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsuser _objcls = new _clsuser();
            _objcls.uid = lbluser.Text;
            _objcls.mode = 2;
            return _objbll.Get_Buiding_Permission(_objcls, _objdb);
        }
        protected void btnenter_Click(object sender, EventArgs e)
        {
            
            if (rd_Building.SelectedValue == "") return;

            if (lblprj.Text == "HMIM")
            {

                string _permission = Get_BuildingPermission();
                if (_permission.Substring(Convert.ToInt32(rd_Building.SelectedValue) - 1, 1) != "1")
                {
                    RadNotification1.Show();
                    return;
                }
            }



            Session["building_id"] = rd_Building.SelectedItem.Value;
            Session["building"] = rd_Building.SelectedItem.Text;

            if (lblid.Text == "0")
            {
                string _prm = "Reports.aspx?id=msc&idx=4&prj=" + lblprj.Text;
                Response.Redirect(_prm);
            }
            else
                summary();

        }
        void summary()
        {
            Session["srv"] = "ALL";

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsdocument _objcls = new _clsdocument();
            _objdb.DBName = "DBCML";
            _clsproject _objcls1 = new _clsproject();
            _objcls1.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls1, _objdb);
                _objbll.Clear_MSSummary(_objdb);
                _objdb.DBName = "DB_" + lblprj.Text;
                DataTable _dtable = _objbll.Load_MSStatus(_objdb);
                var _status = from _data in _dtable.AsEnumerable()
                              select _data;
                foreach (var row in _status)
                {
                    _objcls.status = row[0].ToString();
                    _objcls.schid = Convert.ToInt32(rd_Building.SelectedItem.Value);
                    _objbll.Generate_MS_Summary_ALL_Div(_objcls, _objdb);
                }

                _objcls.status = "1";
                _objcls.schid = Convert.ToInt32(rd_Building.SelectedItem.Value);
                _objbll.Generate_MS_Summary_ALL_Div(_objcls, _objdb);


                string _parm = "id=ms_" + GetDocNo_All() + "&idx=" + lblid.Text + "&Div=" + rd_Building.SelectedItem.Value.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callcms('" + _parm + "','19');", true);
        }
        private string GetDocNo_All()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _clscassheet _objcls = new _clscassheet();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.srv = 0;
            _objcls.build_id = Convert.ToInt32(rd_Building.SelectedItem.Value);
            return _objbll.Get_Get_MsDoc_No_ALL_Div(_objcls, _objdb).ToString();
        }

    }
}
