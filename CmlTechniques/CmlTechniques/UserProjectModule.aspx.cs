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
using Telerik.Web;
using Telerik.Web.UI;

namespace CmlTechniques
{
    public partial class UserProjectModule : System.Web.UI.Page
    {
        static DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                btnadd.Visible = false;
                Load_user();
                load_Allproject();
                load_projecthome();
                LoadProject_Information();
               

            }

        }
        private void load_Allproject()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            ddlproject.DataSource = _objbll.load_project(_objdb);
            ddlproject.DataTextField = "prj_name";
            ddlproject.DataValueField = "prj_id";
            ddlproject.DataBind();
        }
        void LoadProject_Information()
        {
           
             BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsproject _objcls = new _clsproject();
            _objcls.prj_id = Convert.ToInt32(ddlproject.SelectedItem.Value);
            DataTable dt = _objbll.Get_ProjectInformation(_objcls, _objdb);

            CheckBoxList1.Items.Clear();

            foreach (DataRow dr in dt.Rows)
            {

                CheckBoxList1.Items.Add(new ListItem("CMS", dr["cms"].ToString(), (dr["cms"].ToString() == "True" ? true : false)));
                CheckBoxList1.Items.Add(new ListItem("DMS", dr["Dms"].ToString(), (dr["Dms"].ToString()=="True"?true:false)));
                CheckBoxList1.Items.Add(new ListItem("TMS",dr["tms"].ToString(), (dr["tms"].ToString() == "True" ? true : false)));


            }


        }

        private void ListItem(string p, string p_2)
        {
            throw new NotImplementedException();
        }
        void load_projecthome()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = druserid.SelectedItem.Text;

            dt = _objbll.User_Prj_AllModules(_objcls, _objdb);
            myprojectgrid.DataSource = dt;

            myprojectgrid.DataBind();
            myprojectgrid.Enabled = true;

            btnadd.Visible = true;

          

        }
        protected void myprojectgrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int ins = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName == "deletes")
            {
                DataRow[] rowscode = dt.Select("prj_id = '" + myprojectgrid.Rows[ins].Cells[0].Text + "'");

                dt.Rows.Remove(rowscode[0]);
                //dt.AcceptChanges();

                myprojectgrid.DataSource = dt;
                myprojectgrid.DataBind();


            }
            else  if (e.CommandName == "edits")
            {



                CheckBox cms = (CheckBox)myprojectgrid.Rows[ins].Cells[2].Controls[0];
                CheckBox dms = (CheckBox)myprojectgrid.Rows[ins].Cells[3].Controls[0];
                CheckBox ams = (CheckBox)myprojectgrid.Rows[ins].Cells[4].Controls[0];

                ddlproject.SelectedIndex = ddlproject.FindItemByValue(myprojectgrid.Rows[ins].Cells[0].Text).Index;

                //ddlproject.SelectedIndex = ddlproject.Items.IndexOf(ddlproject.Items.FindByValue(myprojectgrid.Rows[ins].Cells[0].Text));


                DataRow[] rowscode = dt.Select("prj_id = '" + myprojectgrid.Rows[ins].Cells[0].Text +"'");

                dt.Rows.Remove(rowscode[0]);
                dt.AcceptChanges();

                myprojectgrid.DataSource = dt;
                myprojectgrid.DataBind();

                LoadProject_Information();

                foreach (ListItem lst in CheckBoxList1.Items)
                {
                    if (lst.Text == "CMS") lst.Selected = cms.Checked;
                    if (lst.Text == "DMS") lst.Selected = dms.Checked;
                  
                    if (lst.Text == "AMS") lst.Selected = ams.Checked;

                }

                myprojectgrid.Enabled = false;


            }

        }
        protected void myprojectgrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HyperLink hcms = (HyperLink)e.Row.FindControl("hcms");
                    HyperLink hdms = (HyperLink)e.Row.FindControl("hdms");
                    HyperLink hams = (HyperLink)e.Row.FindControl("hams");

                    CheckBox cms = (CheckBox)e.Row.Cells[2].Controls[0];
                    CheckBox dms = (CheckBox)e.Row.Cells[3].Controls[0];
                    CheckBox ams = (CheckBox)e.Row.Cells[4].Controls[0];

                    if (cms.Checked) { hcms.Visible = true; }
                    else
                        hcms.Visible = false;

                    if (dms.Checked) { hdms.Visible = true; }
                    else
                        hdms.Visible = false;
                    if (ams.Checked) { hams.Visible = true; }
                    else
                        hams.Visible = false;



                }
               

           
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {

            //int selectedCount = CheckBoxList1.Items.Cast<ListItem>().Count(li => li.Selected);

            if (CheckBoxList1.Items.Cast<ListItem>().Count(li => li.Selected) <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert(Select the Modules');", true);

                lblmessage.Text = "Select the Project Module";
                string script = "function f(){$find(\"" + RadWindow2.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);


                return;
            }


            
            foreach (DataRow drow in dt.Rows)
            {
                if (drow["prj_id"].ToString() == ddlproject.SelectedItem.Value.ToString())
                {
                    lblmessage.Text = "Project already Exists";
                    string script = "function f(){$find(\"" + RadWindow2.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);

                    return;
                }

            }

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = (string)Session["uid"];

            DataRow  dr= dt.NewRow();
           
            dr["prj_id"] = ddlproject.SelectedItem.Value;
            dr["prj_name"] = ddlproject.SelectedItem.Text;

            foreach (ListItem lst in CheckBoxList1.Items)
            {
                if (lst.Text == "CMS") dr["CMS"] = lst.Selected;
                if (lst.Text == "DMS") dr["DMS"] = lst.Selected;
                
                if (lst.Text == "AMS") dr["AMS"] = lst.Selected;


            }


            dt.Rows.Add(dr);

            myprojectgrid.DataSource = dt;
            myprojectgrid.DataBind();


            myprojectgrid.Enabled = true;

            

        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            load_projecthome();

        }

        void Delete_existing()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsSnag _objcls = new _clsSnag();
            _objcls.userid = druserid.SelectedItem.Text;

            _objcls.pkg_id=0;

            _objbll.Delete_User_Prj_Modules_Tbl(_objcls, _objdb);

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            Delete_existing();
            for (int ins = 0; ins <= myprojectgrid.Rows.Count - 1; ins++)
            {

                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "dbCML";
                _clsuser _objcls = new _clsuser();
                _objcls.uid = druserid.SelectedItem.Text;



                CheckBox cms = (CheckBox)myprojectgrid.Rows[ins].Cells[2].Controls[0];
                CheckBox dms = (CheckBox)myprojectgrid.Rows[ins].Cells[3].Controls[0];
                CheckBox ams = (CheckBox)myprojectgrid.Rows[ins].Cells[4].Controls[0];

                _objcls.mode = Convert.ToInt32(myprojectgrid.Rows[ins].Cells[0].Text);
                _objcls.CMS = cms.Checked;
                _objcls.DMS = dms.Checked;
                _objcls.TMS = ams.Checked;
                _objbll.Insert_User_Prj_Modules(_objcls, _objdb);
            }
            lblmessage.Text = "Module Successfully Saved";
            string script = "function f(){$find(\"" + RadWindow2.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
            clear();

        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            load_projecthome();
            clear();
        }

        protected void ddlproject_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            LoadProject_Information();
        }

        protected void druserid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (druserid.SelectedItem.Text == "<<Select User>>") return;
            load_projecthome();
            LoadProject_Information();
        }
        protected void Load_user()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            druserid.DataSource = _objbll.Load_ALLUsers(_objdb);
            druserid.DataTextField = "userid";
            druserid.DataValueField = "userid";
            druserid.DataBind();
            //druserid.Items.Insert(0, "<<Select User>>");
            //druserid.Items[0].Value = "0";
        }
        protected void btnno_Click(object sender, EventArgs e)
        {
            string script = "function f(){$find(\"" + RadWindow2.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
        }
        void clear()
        {
            foreach (ListItem lst in CheckBoxList1.Items)
            {
                lst.Selected = false;
            }
        }
    }
}
