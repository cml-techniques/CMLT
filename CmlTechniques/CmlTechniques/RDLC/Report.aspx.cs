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
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using BusinessLogic;
using App_Properties;


namespace CmlTechniques.RDLC
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                load();
            }
        }
        private void load()
        {
            ReportViewer1.Visible = true;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_QAIA" ;
            DataSet _dt = _objbll.load_dataset(_objdb);
            ReportDataSource _dtsourece = new ReportDataSource();
            ReportViewer1.LocalReport.ReportPath = "RDLC/test.rdlc";
            _dtsourece.Name = "ds1";
            _dtsourece.Value = _dt.Tables[0];
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(_dtsourece);
            ReportViewer1.LocalReport.Refresh();
        }
    }
}
