using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Telerik.Reporting;
//using Telerik.Reporting.Examples.CSharp;


namespace CmlTechniques
{
    public partial class rdrpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

               // this.ReportViewer1.Report = new Report2();
            }
        }
    }
}
