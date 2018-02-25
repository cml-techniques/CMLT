using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Data;
using System.Xml.Linq;
using System.Net;
using System.Web.Script.Serialization;
using System.Xml;
namespace CmlTechniques
{
    public partial class usermonitor : System.Web.UI.Page
    {
        public class Location
        {

            public string IPAddress { get; set; }
            public string CountryName { get; set; }
            public string CountryCode { get; set; }
            public string CityName { get; set; }
            public string RegionName { get; set; }
            public string ZipCode { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
            public string TimeZone { get; set; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LOG();
        }

        
        void LOG()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            GridView1.DataSource = _objbll.Load_User_Log(_objdb);
            GridView1.DataBind();
        }

        protected void cmdrefresh_Click(object sender, EventArgs e)
        {
            LOG();
        }
        publicCls.publicCls _obj = new publicCls.publicCls();
        
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string _result = LoadIPLocation(e.Row.Cells[1].Text);
                //e.Row.Cells[2].Text = _result.Substring(0, _result.IndexOf("_R"));
                //e.Row.Cells[3].Text = _result.Substring(_result.IndexOf("_R") + 2, (_result.IndexOf("_C") - _result.IndexOf("_R") - 2));
                //e.Row.Cells[4].Text = _result.Substring(_result.IndexOf("_C") + 2);
               
            }
        }
       
        
    }
}
