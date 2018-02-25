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
using System.IO;

namespace CmlTechniques.CMS
{
    public partial class ViewComments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                lblprj.Text = (string)Session["project"];
                string _prm = Request.QueryString[0].ToString();
                string _id = _prm.Substring(0, _prm.IndexOf("_M"));
                string _module = _prm.Substring(_prm.IndexOf("_M") + 2, _prm.IndexOf("_T") - (_prm.IndexOf("_M") + 2));
                string _type = _prm.Substring(_prm.IndexOf("_T") + 2);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _module + "');", true);
                Session["_id"] = _id;
                Session["_mod"] = _module.Replace("^", "&");
                Session["_type"] = _type;
                Load_Comments(_id, _module, _type);
                Get_DocInfo(_id);
                string _doctype = "";
                if (_type == "1")
                    _doctype = " Total Comments Report";
                else if(_type=="2")
                    _doctype = " Outstanding Comments Report";
                lbltitle.Text = (string)Session["_mod"] + _doctype;
                //if (lblprj.Text != "12761")
                chkclose.Visible = false;

                if (lblprj.Text != "12761" || _type == "1" ||((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP"))
                {
                    tdupdate.Visible = false;
                }

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
                if (Request.Cookies["project"] != null)
                {
                    Session["project"] = Server.HtmlEncode(Request.Cookies["project"].Value);
                }
                if (Request.Cookies["group"] != null)
                {
                    Session["group"] = Server.HtmlEncode(Request.Cookies["group"].Value);
                }

            }
        }
        private void Load_Comments(string _id,string _module,string _type)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsdocument _objcls = new _clsdocument();
            _objcls.doc_name = _module;
            _objcls.doc_id = Convert.ToInt32(_id);
            _objcls.folder_id = Convert.ToInt32(_type);
            mygrid.DataSource = _objbll.Load_CMS_CommentsAll(_objcls, _objdb);
            mygrid.DataBind();
            if (mygrid.Rows.Count == 0)
                lblinfo.Text = "No Comments Found";
            else
                lblinfo.Visible = false;
        }
        private void Get_DocInfo(string _id)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsdocument _objcls = new _clsdocument();
            _objcls.doc_id = Convert.ToInt32(_id);
            DataTable _dtable = _objbll.Load_CMS_DocInfo(_objcls, _objdb);
            var _info = from _data in _dtable.AsEnumerable()
                        select _data;
            foreach (var row in _info)
            {
                lb_module.Text = row[0].ToString();
                lb_docname.Text = row[1].ToString();
                lb_update.Text =Convert.ToDateTime(row[3].ToString()).ToString("dd/MM/yyyy");
                lb_upby.Text = row[4].ToString();
                lb_ltversion.Text = row[6].ToString();
                lb_status.Text = row[5].ToString();
            }
            if (lb_ltversion.Text.Length == 1)
                lb_ltversion.Text = "0" + lb_ltversion.Text;
        }

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            if ((string)Session["_type"] == "1")
            {
                e.Row.Cells[7].Visible = false;
            }
           
            if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
            {
                e.Row.Cells[7].Visible = false;

            }
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string _ver = e.Row.Cells[0].Text;
                if (_ver.Length == 1)
                    e.Row.Cells[0].Text = "0" + _ver;
                DropDownList _chk = (DropDownList)e.Row.FindControl("drclose");
                if (lblprj.Text == "12761" && e.Row.Cells[7].Visible == true)
                {
                    _chk.ClearSelection();
                    if (e.Row.Cells[9].Text == "True")
                        _chk.SelectedValue = "0";
                    else if (e.Row.Cells[9].Text == "False")
                        _chk.SelectedValue = "1";
                    else
                        _chk.SelectedValue = "2";
                    _chk.Enabled = true;
                }
                else
                    _chk.Enabled = false;
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtresp.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Enter Comment');", true);
                return;
            }
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsdocument _objcls = new _clsdocument();
            _objcls.doc_id = Convert.ToInt32((string)Session["com_id"]);
            _objcls.status = txtresp.Text;
            if (lblprj.Text == "12761")
            {
                if (chkclose.Checked == true)
                    _objcls.enabled = true;
                else
                    _objcls.enabled = false;
                _objbll.Update_CML_DocReponse1(_objcls, _objdb);
            }
            else
                _objbll.Update_CML_DocReponse(_objcls, _objdb);
            Load_Comments((string)Session["_id"], (string)Session["_mod"], (string)Session["_type"]);
            txtresp.Text = String.Empty;
            chkresp.Checked = false;
            btnDummy_ModalPopupExtender1.Hide();
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender1.Hide();
        }
        protected void chkclosed_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        protected void drclose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblprj.Text == "12761") return;

            DropDownList checkbox = (DropDownList)sender;
            GridViewRow row = (GridViewRow)checkbox.NamingContainer;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsdocument _objcls = new _clsdocument();
            _objcls.doc_id = Convert.ToInt32(row.Cells[8].Text);
            if (checkbox.SelectedValue == "1")
                _objcls.enabled = false;
            else
                _objcls.enabled = true;
            _objbll.Update_CML_DocCmtStatus(_objcls, _objdb);
        }
        protected void mygrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _idx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mygrid.Rows[_idx];
            TableCell _com_id = _srow.Cells[8];
            Session["com_id"] = _com_id.Text;
            Load_Details(Convert.ToInt32(_com_id.Text));
            btnDummy_ModalPopupExtender1.Show();
        }
        private void Load_Details(int id)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsdocument _objcls = new _clsdocument();
            _objcls.doc_id = id;
            DataTable _dt = _objbll.Load_Comment_Details(_objcls, _objdb);
            txtresp.Text = _dt.Rows[0][0].ToString();
            if (_dt.Rows[0][1].ToString() == "True")
                chkclose.Checked = true;
        }
        private void Gen_PrintReport()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsdocument _objcls = new _clsdocument();
            _objcls.doc_name = (string)Session["_mod"];
            _objcls.doc_id = Convert.ToInt32((string)Session["_id"]);
            _objcls.folder_id = Convert.ToInt32((string)Session["_type"]);
            _objbll.GEN_CMSDOCCOMM_RPT(_objcls, _objdb);
            _objbll.GEN_CMSDOCINFO_RPT(_objcls, _objdb);
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            Gen_PrintReport();
            string _prm = "Reports.aspx?id=doc_comm&idx=0&prj=" + lblprj.Text;
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _prm + "' ,'','left=210,top=100,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
        }

        protected void chkresp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkresp.Checked == true)
                txtresp.Text = "Noted";
            else
                txtresp.Text = String.Empty;
        }

        protected void btnsavechnages_Click(object sender, EventArgs e)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsdocument _objcls = new _clsdocument();

            for (int ins = 0; ins <= mygrid.Rows.Count-1;ins+=1)
            {
                DropDownList checkbox = (DropDownList)mygrid.Rows[ins].FindControl("drclose");
                if (checkbox == null) continue;
                _objcls.doc_id = Convert.ToInt32(mygrid.Rows[ins].Cells[8].Text);
                if (checkbox.SelectedValue == "1")
                    _objcls.enabled = false;
                else
                    _objcls.enabled = true;

                _objbll.Update_CML_DocCmtStatus(_objcls, _objdb);

            }

            ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('Document successfully Updated');", true);
            //ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "window.close();", true);


        }
    }
}
