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
    public partial class viewcmscomments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Load_Comments();

        }
        void Load_Comments()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_clsuser _objcls = new _clsuser();
            //_objcls.project_code=(string)Session["project"];
            //DataTable _dtable = _objbll.Load_CMS_Comments(_objcls);
            //mygrid.DataSource = _dtable;
            //mygrid.DataBind();
        }
    }
}
