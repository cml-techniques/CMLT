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
using System.Data.OleDb;

namespace CmlTechniques
{
    public partial class ReadExl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = exceldata(Server.MapPath("TestExl.xls"));
                GridView1.DataBind();
            }
        }
        public static DataSet exceldata(string filelocation)
        {

            DataSet ds = new DataSet();

            OleDbCommand excelCommand = new OleDbCommand(); OleDbDataAdapter excelDataAdapter = new OleDbDataAdapter();

            string excelConnStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + filelocation + "; Extended Properties ='Excel 8.0;HDR=Yes;IMEX=1'";

            OleDbConnection excelConn = new OleDbConnection(excelConnStr);

            excelConn.Open();

            DataTable dtPatterns = new DataTable(); excelCommand = new OleDbCommand("SELECT `NAME` as NAME,`AGE` as AGE,`SEX` AS SEX FROM [DATA$]", excelConn);

            excelDataAdapter.SelectCommand = excelCommand;

            excelDataAdapter.Fill(dtPatterns);

            dtPatterns.TableName = "DATA";

            ds.Tables.Add(dtPatterns);

            return ds;

        }

    }
}
