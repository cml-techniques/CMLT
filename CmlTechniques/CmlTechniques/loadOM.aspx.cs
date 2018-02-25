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
    public partial class loadOM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                load_document();
        }
        private void load_document()
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["path"] + "');", true);
            //Label1.Text =Session["path"].ToString();
            string _value = Request.QueryString[0].ToString();
            Session["_datapath"] = _value.Substring(_value.IndexOf("_P") + 2);
            Session["_datapath"] = (string)Session["_datapath"].ToString().Replace(" & ", "<>");
            lblprj.Text = _value.Substring(0, _value.IndexOf("_R"));
            int _id = Convert.ToInt32(_value.Substring(_value.IndexOf("_R") + 2, _value.IndexOf("_P") - (_value.IndexOf("_R") + 2)));
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _id.ToString() + "');", true);
            bool _enable = true;
            publicCls.publicCls _obj = new publicCls.publicCls();
            _obj.Load_Documents();
            publicCls.publicCls._doctype = "1";
            DataTable _dtable1 = new DataTable();
            _dtable1.Columns.Add("doc_name");
            _dtable1.Columns.Add("uploaded_date");
            _dtable1.Columns.Add("file_size");
            _dtable1.Columns.Add("version");
            _dtable1.Columns.Add("STATUS");
            _dtable1.Columns.Add("doc_id");
            var Result = from o in publicCls.publicCls._dtdocuments.AsEnumerable()
                         where o.Field<int>(0) == _id && o.Field<bool>(1) == _enable
                         select o;
            foreach (var row in Result)
            {
                DataRow _myrow = _dtable1.NewRow();
                _myrow[0] = row[4].ToString();
                DateTime _date = Convert.ToDateTime(row[6].ToString());
                _myrow[1] = string.Format("{0:dd/MM/yyyy}", _date);
                _myrow[2] = row[7].ToString();
                _myrow[3] = row[9].ToString();
                _myrow[4] = row[11].ToString();
                _myrow[5] = row[2].ToString();
                _dtable1.Rows.Add(_myrow);
            }
            mydocgridom.DataSource = _dtable1;
            mydocgridom.DataBind();
            DataTable _dtable3 = new DataTable();
            _dtable3.Columns.Add("doc_name");
            _dtable3.Columns.Add("version");
            _dtable3.Columns.Add("comments");
            _dtable3.Columns.Add("uploaded_date");
            _dtable3.Columns.Add("STATUS");
            _enable = false;
            var Result3 = from o in publicCls.publicCls._dtdocuments.AsEnumerable()
                          where o.Field<int>(0) == _id && o.Field<bool>(1) == _enable
                          select o;
            foreach (var row in Result3)
            {
                DataRow _myrow = _dtable3.NewRow();
                _myrow[0] = row[4].ToString();
                _myrow[1] = row[9].ToString();
                _myrow[2] = row[10].ToString();
                DateTime _date = Convert.ToDateTime(row[6].ToString());
                _myrow[3] = string.Format("{0:dd/MM/yyyy}", _date);
                _myrow[4] = row[11].ToString();
                _dtable3.Rows.Add(_myrow);
            }
            gridprv.DataSource = _dtable3;
            gridprv.DataBind();
        }

        protected void mydocgridom_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mydocgridom.Rows[_rowidx];
            TableCell _item = _srow.Cells[0];
            TableCell _id = _srow.Cells[7];
            string _file = _item.Text;
            Session["file"] = _item.Text;
            Session["id"] = _id.Text;
            _Create_Cookies();
            //Label1.Text = (string)Session["file"];
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ (string)Session["file"] +"');", true);
           ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.call('"+ _id.Text +"');", true);
            //Response.Redirect("viewmanual.aspx");
            //myframe.Attributes.Add("src", "viewdocument.aspx");
        }
        void _Create_Cookies()
        {
            if (Request.Browser.Cookies)
            {
                HttpCookie _Cookiefile = new HttpCookie("file");
                _Cookiefile.Value = (string)Session["file"];
                _Cookiefile.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_Cookiefile);
                HttpCookie _Cookiedpath = new HttpCookie("_datapath");
                _Cookiedpath.Value = (string)Session["_datapath"];
                _Cookiedpath.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_Cookiedpath);
                HttpCookie _Cookieid = new HttpCookie("id");
                _Cookieid.Value = (string)Session["id"];
                _Cookieid.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_Cookieid);

            }
            else
                return;
        }

        protected void mydocgridom_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[7].Visible = false;
        }
    }
}

