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
    public partial class viewcomments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
                load_comments();
        }
        void load_comments()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsdocument _objcls = new _clsdocument();
            _objcls.doc_id=Convert.ToInt32((string)Session["docid"]);
            mygrid.DataSource = _objbll.load_comments(_objcls,_objdb);
            mygrid.DataBind();
            //Label1.Text = (string)Session["pkg"];
            load_docdetails();
            //Label2.Text = (string)Session["Dname"];
            //Label3.Text = (string)Session["ver"];
        }
        void _ReadCookies()
        {
            if (Request.Browser.Cookies)
            {
                if (Request.Cookies["pkg"] != null)
                {
                    Session["pkg"] = Server.HtmlEncode(Request.Cookies["pkg"].Value);
                }
                if (Request.Cookies["Dname"] != null)
                {
                    Session["Dname"] = Server.HtmlEncode(Request.Cookies["Dname"].Value);
                }
                if (Request.Cookies["ver"] != null)
                {
                    Session["ver"] = Server.HtmlEncode(Request.Cookies["ver"].Value);
                }
                if (Request.Cookies["docid"] != null)
                {
                    Session["docid"] = Server.HtmlEncode(Request.Cookies["docid"].Value);
                }
            }
        }

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[6].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            }

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
                contr.Text = row[5].ToString();
                module.Text = row[7].ToString();
                package.Text = row[8].ToString();
                Label1.Text = package.Text;
                fname.Text = row[0].ToString();
                version.Text = row[3].ToString();
                DateTime _date = Convert.ToDateTime(row[6].ToString());
                date.Text = string.Format("{0:dd/MM/yyyy}", _date); 
                uploadby.Text = row[10].ToString();
                status.Text = row[4].ToString();
            }

        }
    }
}
