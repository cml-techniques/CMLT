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
    public partial class head1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _qry = Request.QueryString["mod"].ToString();
                lblprj.Text = Request.QueryString["prj"].ToString();
                lbluser.Text = Request.QueryString["auh"].ToString();
                //string _pkg = Request.QueryString["pkg"].ToString();
                //string _fac = Request.QueryString["fac"].ToString();
                prjhead.Src = "../images/" + lblprj.Text + "top.jpg";
                prj.Text = Get_ProjectName();
                userinfo.Text = lbluser.Text;
                //package.Text =_pkg + " - " + _fac;
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
    }
}
