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
using System.Text;

namespace CmlTechniques
{
    public partial class reportpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            
            if (!IsPostBack)
            {
                forPrint.Visible = false;
                load_package();
                heading.Text = "Reports";
                cmdprint.Visible = false;
                cmdreturn.Visible = false;
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
                if (Request.Cookies["access"] != null)
                {
                    Session["access"] = Server.HtmlEncode(Request.Cookies["access"].Value);
                }
            }
        }

        protected void mydocgrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void cancel()
        {
            heading.Text  = "cancel";
        }
        protected void view1_Click(object sender, EventArgs e)
        {
            View_Reports(1);
            //heading.Text = ConfirmButtonExtender1.ClientState.ToString();
            
        }
        void View_Reports( int _id)
        {
            forPrint.Visible = true;
            pnlmenu.Visible = false;
            cmdprint.Visible = true ;
            cmdreturn.Visible = true;
            //Session["package"] = drpackage.SelectedItem.Value;
            if (_id == 1)
            {
                //if (drpackage.SelectedItem.Text == "-- Select Package --") return;
                heading.Text = "Summary of O and M Manuals Uploaded";
                load_reports(1);
            }
            else if (_id == 2)
            {
                heading.Text = "Summary of all documents uploaded by package";
                load_reports(2);
            }
            else if (_id == 3)
                heading.Text = "Record drawings uploaded vs supplied schedule";
            else if (_id == 4)
                heading.Text = "Manufacturer information documents uploaded vs supplied schedule";
            else if (_id == 5)
                heading.Text = "Test documents uploaded vs supplied schedule";

            //rpthead.Text = drpackage.SelectedValue;
            
        }
        void load_reports(int _id)
        {
            BLL_Dml _objbal = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            //_objdb.DBName = "db_BCC1";
            _clsuser  _objcls = new _clsuser();
           
            if (_id == 1)
            {

                _objcls.project_code = (string)Session["project"];
                mygridom.Visible = true;
                mygridsummary.Visible = false;
                mygridom.DataSource = _objbal.load_RptOMmanual(_objcls,_objdb);
                mygridom.DataBind();
            }
            else if (_id == 2)
            {
                //mydocgrid.Visible = true;
                //mydocgrid.DataSource = _objbal.load_SummaryOfOMmanual(_objcls );
                //mydocgrid.DataBind();
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["project"] + "');", true);
                _objcls.project_code = (string)Session["project"];
                if (_objbal.Check_CMS(_objcls, _objdb) == true)
                    _objdb.DBName = "db_" + (string)Session["project"];
                else
                    _objdb.DBName = "dbCML";
                mygridsummary.Visible = true;
                mygridom.Visible = false;
                BLL_Dml _objbll = new BLL_Dml();
                _clsuser _objcls1 = new _clsuser();
                _objcls1.project_code = (string)Session["project"];
                mygridsummary.DataSource = _objbll.Doc_Summary_Rpt(_objcls1,_objdb);
                mygridsummary.DataBind();

            }
        }
        void load_package()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //DataTable _dtable = _objbll.load_package();
            //DataTable _dtable1 = new DataTable();
            //_dtable1.Columns.Add("id");
            //_dtable1.Columns.Add("package");
            //var result = from o in _dtable.AsEnumerable()
            //             where o.Field<string>(6) == (string)Session["project"]
            //             select o;
            //foreach (var row in result)
            //{
            //    DataRow _myrow = _dtable1.NewRow();
            //    _myrow[0] = row[0].ToString();
            //    _myrow[1] = row[2].ToString();
            //    _dtable1.Rows.Add(_myrow);
            //}
            //drpackage.DataSource = _dtable1;
            //drpackage.DataTextField = "package";
            //drpackage.DataValueField = "id";
            //drpackage.DataBind();
            //drpackage.Items.Insert(0, "-- Select Package --");

        }

        protected void cmdreturn_Click(object sender, EventArgs e)
        {
            forPrint.Visible = false;
            pnlmenu.Visible = true ;
            heading.Text = "Reports";
            cmdprint.Visible = false ;
            cmdreturn.Visible = false ;
            mygridom.Visible = false;
            //mydocgrid.Visible = false;
            mygridsummary.Visible = false;
        }

        protected void view2_Click(object sender, EventArgs e)
        {
            View_Reports(2);
        }

        
        protected void view4_Click(object sender, EventArgs e)
        {
            View_Reports(4);
        }

        protected void view5_Click(object sender, EventArgs e)
        {
            View_Reports(5);
        }

        protected void mydocgrid_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void ConfirmButtonExtender1_DataBinding(object sender, EventArgs e)
        {

        }

        protected void mydocgrid_SelectedIndexChanged2(object sender, EventArgs e)
        {

        }

        protected void mygridom_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mygridom.Rows[_rowidx];
            TableCell _item = _srow.Cells[9];            
            Session["docid"] = _item.Text;
            _item = _srow.Cells[0];
            Session["pkg"] = _item.Text;
            _item = _srow.Cells[1];
            Session["Dname"] = _item.Text;
            _item = _srow.Cells[3];
            Session["ver"] = _item.Text;
            _Create_Cookies();
            //Response.Redirect("viewcomments.aspx", true); 
            //string script = ""; 
            //script += "<script >"; 
            //script += "alert('Hello')"; 
            //script += "</script>";
            ////Response.Write("<script language=javascript type=text/javascript>window.open('viewcomments.aspx','','left=150,top=150,width=1024,height=600,menubar=1,toolbar=0,scrollbars=1,status=0');</script>");
            //System.Web.HttpContext.Current.Response.Write(script);
            

            //if (!this.IsClientScriptBlockRegistered("clientScript"))
            //{
                // Form the script that is to be registered at client side.
            //    String scriptString = "<script language=JavaScript> function DoClick() {";
            //    scriptString += "alert('hello');}<";
            //    scriptString += "/";
            //    scriptString += "script>";
            //    //this.RegisterClientScriptBlock("clientScript", scriptString);
            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "clientScript", scriptString);
            ////}
            //    Response.Write(scriptString);
            //string str = "viewcomments.aspx";
            //Response.Write("<script language=javascript> window.open('" + str  + "', width=500,height=400);</script>");
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('viewcomments.aspx','','left=210,top=100,width=1024,height=600,menubar=1,toolbar=0,scrollbars=1,status=0');", true);
            //Response.Redirect("viewcomments.aspx", false);
        }
        void _Create_Cookies()
        {
            if (Request.Browser.Cookies)
            {
                HttpCookie _CookiePkg = new HttpCookie("pkg");
                _CookiePkg.Value = (string)Session["pkg"];
                _CookiePkg.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_CookiePkg);
                HttpCookie _CookieDname = new HttpCookie("Dname");
                _CookieDname.Value = (string)Session["Dname"];
                _CookieDname.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_CookieDname);
                HttpCookie _CookieVer = new HttpCookie("ver");
                _CookieVer.Value = (string)Session["ver"];
                _CookieVer.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_CookieVer);
                HttpCookie _Cookiedocid = new HttpCookie("docid");
                _Cookiedocid.Value = (string)Session["docid"];
                _Cookiedocid.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_Cookiedocid);

            }
            else
                return;
        }
        private int get_cms_sch(int _id)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsdocument _objcls = new _clsdocument();
            _objcls.folder_id = _id;
            return _objbll.Get_CMS_TC_Scheduled(_objcls, _objdb);
        }
        private int get_cms_upl(int _id)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsdocument _objcls = new _clsdocument();
            _objcls.folder_id = _id;
            return _objbll.Get_CMS_TC_Upladed(_objcls, _objdb);
        }
        protected void mygridom_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[9].Visible = false;
        }

        protected void mygridsummary_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[8].Visible = false;
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    int _folder = Convert.ToInt32(e.Row.Cells[8].Text);
            //    if (_folder != 0)
            //    {
            //        int _sch = Convert.ToInt32(e.Row.Cells[5].Text);
            //        int _upl = Convert.ToInt32(e.Row.Cells[6].Text);
            //        int _cms_sch = get_cms_sch(_folder);
            //        int _cms_upl = get_cms_upl(_folder);
            //        //_sch = _sch + _cms_sch;
            //        //_upl = _upl + _cms_upl;
            //        //decimal _per = 0;
            //        //if (_upl > 0)
            //        //    _per = (_sch / _upl) * 100;
            //        //e.Row.Cells[5].Text = _sch.ToString();
            //        //e.Row.Cells[6].Text = _upl.ToString();
            //        //e.Row.Cells[7].Text = decimal.Round(_per, 2).ToString();
            //    }
            //}
        }

        protected void cmdprint_Click(object sender, EventArgs e)
        {

        }

        //protected void view3_Click(object sender, EventArgs e)
        //{
        //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.doc_list();", true);
        //}


       
    }
}
