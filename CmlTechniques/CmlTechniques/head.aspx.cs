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
    public partial class head : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _qry = Request.QueryString["Id"].ToString();
                string _prj = Request.QueryString["prj"].ToString();
                if (_prj == "demo")
                {
                    headtbl.Visible = false;
                    string _head = "<header><div><h1>CML Techniques</h1><h2>Presentation Project</h2></div></header>";
                    LiteralControl _lt = new LiteralControl();
                    _lt.Text = _head;
                    PlaceHolder1.Controls.Add(_lt);
                    if (_qry == "0")
                    {
                        lblprj1.Text = "CML Techniques | Online Document Management System";
                    }
                    else
                    {
                        lblprj.Text = _prj;
                        lblprj1.Text = Get_ProjectName() + " - " + _qry;
                    }
                    lbluserin.Text = "Login as : " + (string)Session["uid"] + " ";
                }
                else
                {
                    Table1.Visible = false;
                    PlaceHolder1.Visible = false;
                    if (_qry == "0")
                    {
                        prjhead.Src = "../images/Website_Heading.jpg";
                        prj.Text = "CML Techniques | Online Document Management System";
                    }
                    else if (_qry == "AMS")
                    {
                        lblprj.Text = "demo";
                        prjhead.Src = "../images/" + lblprj.Text + "top.jpg";
                        prj.Text = Get_ProjectName() + " - " + _qry;
                    }
                    else
                    {
                        lblprj.Text = _prj;
                        prjhead.Src = "../images/" + lblprj.Text + "top.jpg";
                        prj.Text = Get_ProjectName() + " - " + _qry;
                    }
                }
                userinfo.Text = "Login as : " + (string)Session["uid"] + " , ";
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
                if (Request.Cookies["projectname"] != null)
                {
                    Session["projectname"] = Server.HtmlEncode(Request.Cookies["projectname"].Value);
                }

            }
        }
    }
}
