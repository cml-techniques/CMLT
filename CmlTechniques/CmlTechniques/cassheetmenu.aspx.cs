using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CmlTechniques
{
    public partial class cassheetmenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                Session["sch"]=Request.QueryString[0].ToString();
                mydata.Attributes.Add("src", "casintdata.aspx" );
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "resizeFrame();", true);
            }
        }
    }
}
