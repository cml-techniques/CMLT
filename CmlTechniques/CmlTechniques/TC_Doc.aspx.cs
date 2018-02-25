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

namespace CmlTechniques
{
    public partial class TC_Doc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                lblfolder.Text = _prm.Substring(0, _prm.IndexOf("_P"));
                lblprj.Text = _prm.Substring(_prm.IndexOf("_P") + 2);
                LOAD_CAS_SERVICE();
                btnsave.Visible = false;
            }
        }
        protected void LOAD_CAS_SERVICE()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            drservice.DataSource = _objbll.Load_Prj_Service(_objdb);
            drservice.DataTextField = "PRJ_SER_NAME";
            drservice.DataValueField = "PRJ_SER_ID";
            drservice.DataBind();
            drservice.Items.Insert(0, "-- Select Service --");

        }
        private void Load_Packages()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();
            _objcls.srv = Convert.ToInt32(drservice.SelectedItem.Value);
            mygrid.DataSource = _objbll.Load_serv_package(_objcls, _objdb);
            mygrid.DataBind();
        }
        protected void drservice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drservice.SelectedItem.Text == "-- Select Service --") return;
            Load_Packages();
            Load_DmsTc();
            btnsave.Visible = true;
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            Inser_DmsTc();
        }
        private void Inser_DmsTc()
        {
            Delete_DmsTc();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clscassheet _objcls = new _clscassheet();
            _objcls.prj_code = lblprj.Text;
            _objcls.srv = Convert.ToInt32(lblfolder.Text);
            bool _chkd = false;
            foreach (GridViewRow _drow in mygrid.Rows)
            {
                CheckBox _chk = (CheckBox)_drow.FindControl("chkbox");
                if (_chk.Checked == true)
                {
                    _objcls.sys = Convert.ToInt32(_drow.Cells[3].Text);
                    _objbll.Insert_DMS_TCDOC(_objcls, _objdb);
                    _chkd = true;
                }
            }
            if(_chkd==true)
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Packages Updated');", true);
        }
        private void Delete_DmsTc()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clscassheet _objcls = new _clscassheet();
            _objcls.prj_code = lblprj.Text;
            _objcls.srv = Convert.ToInt32(lblfolder.Text);
            _objbll.Delete_DMS_TCDOC(_objcls, _objdb);
        }
        private void Load_DmsTc()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clscassheet _objcls = new _clscassheet();
            _objcls.prj_code = lblprj.Text;
            _objcls.srv = Convert.ToInt32(lblfolder.Text);
            DataTable _dt = _objbll.Load_DMS_TCDOC_SYS(_objcls, _objdb);
            foreach (GridViewRow _drow in mygrid.Rows)
            {
                CheckBox _chk = (CheckBox)_drow.FindControl("chkbox");
                foreach (DataRow _drow1 in _dt.Rows)
                {
                    if (_drow1[0].ToString() == _drow.Cells[3].Text)
                    {
                        _chk.Checked = true;
                    }
                }
                
            }
        }

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[3].Visible = false;
        }
    }
}
