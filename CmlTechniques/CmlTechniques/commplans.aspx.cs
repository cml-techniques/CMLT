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
    public partial class commplans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Load_Documents();
        }
        private void Load_Documents()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.project_code = (string)Session["project"];
            _objcls.module_name = "COMMISSIONING PLANS";
            mygrid.DataSource = _objbll.Load_CMS_Document(_objcls,_objdb);
            mygrid.DataBind();
            if (mygrid.Rows.Count > 0)
            {
                string _path = "/CmsDocs/" + mygrid.Rows[0].Cells[1].Text; 
                myframe.Attributes.Add("src", _path);
            }
        }

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[4].Visible = false;
        }

        protected void mygrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mygrid.Rows[_rowidx];
            TableCell _item = _srow.Cells[1];
            string _file = _item.Text;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ _file +"');", true);
            string _path = "/CmsDocs/" + _file;
            //Session["file"] = _item.Text;
            //Session["mode"] = "cms";
            myframe.Attributes.Add("src", _path);
        }

        

        protected void mybasket_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Cells[2].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            if (txtcomments.Text.Length <= 0) return;           
            cmscomments _obj = new cmscomments();
            _obj.Insert(txtcomments.Text);
            mybasket.DataBind();
            txtcomments.Text = "";
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            cmscomments _obj = new cmscomments();
            _obj.clear();
            mybasket.DataBind();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (mybasket.Rows.Count<=0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Please Add Comments');", true);
                return;
            }
            Save_Comments();
            cmscomments _obj = new cmscomments();
            _obj.clear();
            mybasket.DataBind();
        }

        void Save_Comments()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clscmscomment _objcls = new _clscmscomment();
            for (int i = 0; i <= mybasket.Rows.Count - 1; i++)
            {
                _objcls.com_date = DateTime.Now;
                _objcls.comment = mybasket.Rows[i].Cells[2].Text;
                _objcls.project = (string)Session["project"];
                _objcls.module = "COMMISSIONING PLANS";
                _objcls.uid = (string)Session["uid"];
                _objcls.doc_id = Convert.ToInt32(mygrid.Rows[0].Cells[4].Text);
                _objbll.Add_CMS_Comments(_objcls,_objdb);
               
            }
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Comment(s) Saved');", true);
        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            myframe.Attributes.Add("src","viewcmscomments.aspx");
        }
    }
}
