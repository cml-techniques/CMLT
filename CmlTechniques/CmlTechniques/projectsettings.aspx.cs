using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Data;
//using System.Web.Extensions;

namespace CmlTechniques
{
    public partial class projectsettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { load_package(); Panel1.Visible = false; }
        }
        void load_package()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            DataTable _dtable = _objbll.load_package(_objdb);
            DataTable _dtable1 = new DataTable();
            _dtable1.Columns.Add("id");
            _dtable1.Columns.Add("package");
            var result = from o in _dtable.AsEnumerable()
                         where o.Field<string>(6) == (string)Session["project"]
                         select o;
            foreach (var row in result)
            {
                DataRow _myrow = _dtable1.NewRow();
                _myrow[0] = row[0].ToString();
                _myrow[1] = row[2].ToString();
                _dtable1.Rows.Add(_myrow);
            }
            drpackage.DataSource = _dtable1;
            drpackage.DataTextField = "package";
            drpackage.DataValueField = "id";
            drpackage.DataBind();
            drpackage.Items.Insert(0, "-- Select Package --");

        }
       
        public void load_manualDetails()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsmanufacture _objcls = new _clsmanufacture();
            _objcls.project_code = (string)Session["project"];
            DataTable _Doctype = _objbll.load_doctype(_objdb);
            DataTable _dtable1 = new DataTable();
            _dtable1.Columns.Add("id");
            _dtable1.Columns.Add("type");
            var _List = from o in _Doctype.AsEnumerable()
                        where o.Field<int>(5) == Convert.ToInt32(drpackage.SelectedItem.Value)
                        select o;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["project"] + "');", true);
            foreach (var row in _List)
            {
                if (row[7].ToString() == "1")
                    Session["om"] = row[0].ToString();                
            }
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["docid"] + "');", true);
            _clsdocument _objcls1 = new _clsdocument();
            _objcls1.folder_id = Convert.ToInt32((string)Session["om"]);
            //int _docid = _objbll.Get_ManualID(_objcls1);
            Session["docid"] = _objbll.Get_ManualID(_objcls1,_objdb).ToString();
            load_comments();
            
        }
        void load_comments()
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["docid"] + "');", true);
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsdocument _objcls = new _clsdocument();
            _objcls.doc_id = Convert.ToInt32((string)Session["docid"]);
            mygrid.DataSource = _objbll.load_comments(_objcls,_objdb);
            mygrid.DataBind();
            lbldoc.Text = (string)Session["docid"];
            _objcls.package_code = Convert.ToInt32((string)Session["docid"]);
            lblsrv.Text = _objbll.Get_Package_Service(_objcls, _objdb).ToString();
            load_docdetails();
            
        }
        protected void cmdview_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["project"] + "');", true);
            load_manualDetails();
        }

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[6].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            }
            e.Row.Cells[7].Visible = false;
        }
        void load_docdetails()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsdocument _objcls = new _clsdocument();
            _objcls.doc_id = Convert.ToInt32((string)Session["docid"]);
            DataTable _dtable = _objbll.Load_DocDatails(_objcls,_objdb);
            var _result = from o in _dtable.AsEnumerable()
                          select o;
            foreach (var row in _result)
            {
                fname.Text = row[0].ToString();
                version.Text = row[3].ToString();
                DateTime _date = Convert.ToDateTime(row[6].ToString());
                date.Text = string.Format("{0:dd/MM/yyyy}", _date); 
                status.Text = row[4].ToString();
            }

        }

        protected void mygrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Panel1.Visible = true;
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mygrid.Rows[_rowidx];
            TableCell _item = _srow.Cells[5];
            TableCell _id = _srow.Cells[7];
            txtcomment.Text = _item.Text;
            Session["comid"] = _id.Text;
            mygrid.Rows[_rowidx].BackColor = System.Drawing.Color.LightBlue;
        }
        bool IsnullValidation()
        {
            if (txtrespond.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Add your responds');", true);
                return true;
            }
            else if (txtcomment.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Comment');", true);
                return true;
            }
            else
                return false;
        }
        protected void cmdadd_Click(object sender, EventArgs e)
        {
            if (IsnullValidation() == true) return;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clscomment _objcls = new _clscomment();
            _objcls.comm_id = Convert.ToInt32((string)Session["comid"]);
            _objcls.resp = txtrespond.Text;
            _objbll.add_resp(_objcls,_objdb);
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('CML Response added!');", true);
            Send_Notification();
            txtrespond.Text = "";
            txtcomment.Text = "";
            Panel1.Visible = false;
        }

        private void Send_Notification()
        {
            
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objusr = new _clsuser();
            _objusr.project_code = (string)Session["project"];
            string project = _objbll.Get_ProjectName(_objusr, _objdb);
            publicCls.publicCls _obj = new publicCls.publicCls();
            _clsdocument _objcls1 = new _clsdocument();
            _objcls1.project_code = (string)Session["project"];
            _objcls1.schid = Convert.ToInt32(lblsrv.Text);
            DataTable _dt = _objbll.load_dms_user_email(_objcls1, _objdb);
            string Body = "To: CML Techniques Project Managers," + "\n\n" + "Ref. " + project + "/" + drpackage.SelectedItem.Text + "/" + fname.Text + "\n\n" + "This is a notification to inform you that " +  (string)Session["uid"] + " has responded to comments previously made on the above O and M Manual." + "\n" + "\n\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
            string _sub = "Ref. " + project + " / " + drpackage.SelectedItem.Text + "/" + fname.Text;
            var list = from o in _dt.AsEnumerable()
                       where o.Field<string>(1) == "Review/Comment" || o.Field<string>(1) == "Review/Comment/Status"
                       select o;
            foreach (var row in list)
            {
                _obj.Send_Email(row[0].ToString(), _sub, Body);
            }
        }

    }
}
