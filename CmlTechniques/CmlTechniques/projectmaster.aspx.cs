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
    public partial class projectmaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_projects();
                load_Company();
            }
        }

        protected void cmdcreate_Click(object sender, EventArgs e)
        {

            update_project();
        }
        protected void update_project()
        {
            if (IsnullValidation() == true) return;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsproject _clsobj = new _clsproject();
            _clsobj.prjcode = prjcode.Text;
            _clsobj.prjname = prjname.Text;
            _clsobj.company = dr_maincom.SelectedItem.Text;
            _clsobj.description = description.Text;
            _clsobj.user = (string)Session["uid"];
            if (chkdms.Checked == true)
                _clsobj.dms = true;
            else
                _clsobj.dms = false;
            if (chkcms.Checked == true)
                _clsobj.cms = true;
            else
                _clsobj.cms = false;
            if (chktms.Checked == true)
                _clsobj.tms = true;
            else
                _clsobj.tms = false;
            if (chksns.Checked == true)
                _clsobj.sns = true;
            else
                _clsobj.sns = false;
            if (chktis.Checked == true)
                _clsobj.tis = true;
            else
                _clsobj.tis = false;
            _clsobj.loc = txt_loc.Text;
            _clsobj.mode = Convert.ToInt32((string)Session["mode"]);
            _objbll._projectmaster(_clsobj,_objdb);
            Insert_Prj_Company();
            DB();
            load_projects();
            clear();
        }
        private void Insert_Prj_Company()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsproject _clsobj = new _clsproject();
            _clsobj.prjcode = prjcode.Text;
            foreach (ListItem _itm in chkcom.Items)
            {
                if (_itm.Selected == true)
                {
                    _clsobj.com_id = Convert.ToInt32(_itm.Value);
                    _objbll.Create_Prj_Company(_clsobj, _objdb);
                }
            }

        }
        private void Load_Project_Company()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _clsuser _objcls = new _clsuser();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _objcls.project_code = (string)Session["project"];
            DataTable _dtable = _objbll.Load_PrjCompany(_objcls, _objdb);
            var _comapny = from _data in _dtable.AsEnumerable()
                           select _data;
            chkcom.ClearSelection();
            foreach (var row in _comapny)
            {
                for (int i = 0; i <= chkcom.Items.Count - 1; i++)
                {
                    if (chkcom.Items[i].Text == row["Company"].ToString())
                        chkcom.Items[i].Selected = true;
                }
            }
        }
        protected void DB()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _obj = new _database();
            //_obj.dbname = prjcode.Text;
            //_objbll.CREATE_DB(_obj);
        }
        void clear()
        {
            prjcode.Text = "";
            prjname.Text = "";
            dr_maincom.ClearSelection();
            dr_maincom.Items.FindByText("-- Select --").Selected = true;
            description.Text = "";
        }
        void load_projects()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            prjgrid.DataSource = _objbll.load_project(_objdb);
            prjgrid.DataBind();
        }
        void load_Company()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            chkcom.DataSource = _objbll.Load_Company_Master(_objdb);
            chkcom.DataTextField = "Com_name";
            chkcom.DataValueField = "Com_id";
            chkcom.DataBind();
            dr_maincom.DataSource = _objbll.Load_Company_Master(_objdb);
            dr_maincom.DataTextField = "Com_name";
            dr_maincom.DataValueField = "Com_id";
            dr_maincom.DataBind();
            dr_maincom.Items.Insert(0, "-- Select --");
            comgrid.DataSource = _objbll.Load_Company_Master(_objdb);
            comgrid.DataBind();
        }
        private bool IsnullValidation()
        {
            if (prjcode.Text.Trim().Length <= 0) {ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Project Code Required!');", true);return true;}
            else if (prjname.Text.Trim().Length <= 0){ ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Project Name Required!');", true);return true;}
            else if (dr_maincom.SelectedItem.Text == "-- Select --") { ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Main Contractor');", true); return true; }
            return false;
        }

        protected void prjgrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[1].Visible = false;
        }

        protected void btnnew_Click(object sender, EventArgs e)
        {
            Session["mode"] = "1";
            btnDummy_ModalPopupExtender.Show();
        }

        protected void cmdcancel_Click(object sender, EventArgs e)
        {
            prjcode.ReadOnly = false;
            prjcode.Text = "";
            prjname.Text = "";
            description.Text = "";
            chkcms.Checked = false;
            chkdms.Checked = false;
            cmdcreate.Text = "Save";
            chktms.Checked = false;
            btnDummy_ModalPopupExtender.Hide();
        }

        protected void prjgrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = prjgrid.Rows[_rowidx];
            TableCell _item = _srow.Cells[1];
            Session["project"] = _item.Text;
            Load_details(_rowidx);
            btnDummy_ModalPopupExtender.Show();
        }
        protected void Load_details(int _index)
        {
            prjcode.Text = (string)Session["project"];
            prjname.Text = prjgrid.Rows[_index].Cells[2].Text;
            description.Text = prjgrid.Rows[_index].Cells[7].Text;
            //company.Text = prjgrid.Rows[_index].Cells[3].Text;
            ListItem li = dr_maincom.Items.FindByText(prjgrid.Rows[_index].Cells[3].Text);
            dr_maincom.ClearSelection();
            if (li != null)
            {
                dr_maincom.Items.FindByText(prjgrid.Rows[_index].Cells[3].Text).Selected = true;
            }
            if (prjgrid.Rows[_index].Cells[4].Text == "YES")
                chkdms.Checked = true;
            else
                chkdms.Checked = false;
            if (prjgrid.Rows[_index].Cells[5].Text == "YES")
                chkcms.Checked = true;
            else
                chkcms.Checked = false;
            if (prjgrid.Rows[_index].Cells[6].Text == "YES")
                chktms.Checked = true;
            else
                chktms.Checked = false;
            prjcode.ReadOnly = true;
            Load_Project_Company();
            Session["mode"] = "0";
            cmdcreate.Text = "Update";
        }

        protected void btnsave1_Click(object sender, EventArgs e)
        {
                BLL_Dml _objbll = new BLL_Dml();
                _clsproject _objcls = new _clsproject();
                _database _objdb = new _database();
                _objdb.DBName = "DBCML";
                if (btnsave1.Text == "Save")
                {
                    _objcls.com_id = 0;
                    _objcls.action = 1;
                }
                else
                {
                    _objcls.com_id = Convert.ToInt32((string)Session["com_id"]);
                    _objcls.action = 2;
                }
                
                _objcls.comcd = txt_comcd.Text;
                _objcls.company = txt_comname.Text;
                if (chkactive.Checked == true)
                    _objcls.status = true;
                else
                    _objcls.status = false;
               
                _objbll.Create_Company(_objcls, _objdb);
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Completed');", true);
                txt_comname.Text = String.Empty;
                txt_comcd.Text = String.Empty;
                load_Company();
                ModalPopupExtender1.Hide();
        }

        protected void btncancel1_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }

        protected void btn_newcom_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
        }

        protected void comgrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
        }

        protected void comgrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = comgrid.Rows[_rowidx];
            TableCell _item = _srow.Cells[3];
            Session["com_id"] = _item.Text;
            Load_ComDetails(_rowidx);
            ModalPopupExtender1.Show();
        }
        private void Load_ComDetails(int idx)
        {
            txt_comcd.Text = comgrid.Rows[idx].Cells[1].Text;
            txt_comname.Text = comgrid.Rows[idx].Cells[2].Text;
            if (comgrid.Rows[idx].Cells[4].Text == "True")
                chkactive.Checked = true;
            else
                chkactive.Checked = false;
            btnsave1.Text = "Update";
        }
    }
}
