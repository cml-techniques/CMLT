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
using MultiFieldGroupingRepeater;

namespace CmlTechniques
{
    public partial class Repeater : System.Web.UI.Page
    {
        protected GroupedRepeater.Controls.GroupingRepeater countries;
        private DataTable dataSource;
        protected GroupingRepeater groupingRepeater;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            //Load_data();
            {
                Load_data();
                //DataSet ds = new DataSet();
                //ds.ReadXml(Server.MapPath("countries.xml"));
                //if (ds.Tables[0].Rows.Count > 6)
                //    sampleList.Attributes["Style"] = "OVERFLOW-Y:auto;HEIGHT:137px;";
                //else
                //    sampleList.Attributes["Style"] = "OVERFLOW-Y:auto;";

                //Myrptr.DataSource = ds;
                //Myrptr.DataBind();  
                //countries.DataSource = ds.Tables["country"];
                //countries.Comparer = new CountryComparer();
                //countries.DataBind();
            }
        }
        private void Load_data()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DB_BCC1";
            //_clscassheet _objcas = new _clscassheet();
            //_objcas.sch = 1;
            //_objcas.prj_code = "BCC1";
            //groupingRepeater.DataSource = _objbll.Load_casMain_Edit(_objcas, _objdb);
            //groupingRepeater.DataBind();
            // Create Data Source (mimic the result of a JOIN statement from a database)
            dataSource = new DataTable();

            // Add columns
            dataSource.Columns.AddRange(new DataColumn[]
			{ 
				new DataColumn("CustomerID", typeof(string)),
				new DataColumn("CustomerName", typeof(string)),
				new DataColumn("EmployeeName", typeof(string)),
				new DataColumn("OrderID", typeof(int)),
				new DataColumn("OrderDate", typeof(DateTime)),
				new DataColumn("OrderAmount", typeof(double)),
				new DataColumn("CommentID", typeof(int)),
				new DataColumn("Comment", typeof(string)),
				new DataColumn("CommentPostedDate", typeof(DateTime)),				
			});

            // Create and add rows of data
            dataSource.Rows.Add(new object[]
			{
				1,								// CustomerID
				"James Hendrix",				// CustomerName
				"Mike Jagger",					// EmployeeName
				1,								// OrderID
				new DateTime(2006, 1, 14),		// OrderDate
				17564.21,						// OrderAmount
				null,							// CommentID
				null,							// Comment
				null							// CommentPostedDate
			});
            dataSource.Rows.Add(new object[]
			{
				1,								// CustomerID
				"James Hendrix",				// CustomerName
				"Brian Springsteen",			// EmployeeName
				2,								// OrderID
				new DateTime(2005, 11, 3),		// OrderDate
				8145.89,						// OrderAmount
				1,								// CommentID
				"Customer will need further materials. Will return for followup.", // Comment
				new DateTime(2005, 11, 3)		// CommentPostedDate
			});

            dataSource.Rows.Add(new object[]
			{
				2,								// CustomerID
				"Donald Bowie",					// CustomerName
				"Bruce Marley",					// EmployeeName
				3,								// OrderID
				new DateTime(2005, 12, 31),		// OrderDate
				1264.11,						// OrderAmount
				2,								// CommentID
				"I was disgusted by this customer's pants.", // Comment
				new DateTime(2005, 12, 31)		// CommentPostedDate
			});
            dataSource.Rows.Add(new object[]
			{
				2,								// CustomerID
				"Donald Bowie",					// CustomerName
				"Mike Jagger",					// EmployeeName
				3,								// OrderID
				new DateTime(2005, 12, 31),		// OrderDate
				1264.11,						// OrderAmount
				3,								// CommentID
				"Hey, they aren't THAT bad!",	// Comment
				new DateTime(2005, 12, 31)		// CommentPostedDate
			});
            dataSource.Rows.Add(new object[]
			{
				2,								// CustomerID
				"Donald Bowie",					// CustomerName
				"Bruce Marley",					// EmployeeName
				4,								// OrderID
				new DateTime(2005, 9, 21),		// OrderDate
				499.99,						// OrderAmount
				null,							// CommentID
				null,							// Comment
				null							// CommentPostedDate
			});

            // Assign the datasource
            groupingRepeater.DataSource = dataSource;

            this.DataBind();
            
        }
        private class CountryComparer : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                if (x == null || y == null)
                    return -1;

                DataRowView v1 = x as DataRowView;
                DataRowView v2 = y as DataRowView;

                string country1 = (string)v1.Row[0];
                string country2 = (string)v2.Row[0];

                // both null's are equal.
                if (country1 == null && country2 == null)
                {
                    return 0;
                }

                return country1.Substring(0, 1).CompareTo(country2.Substring(0, 1));
            }
        }
    }
}
