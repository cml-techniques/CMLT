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
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace CmlTechniques.CMS
{
    public partial class Project_Summary : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtService;
        public static DataTable _dtresult;
        public static DataTable _dtsummary;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
