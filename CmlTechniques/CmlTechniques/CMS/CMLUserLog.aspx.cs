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
using System.Net;
using System.Net.Sockets;
using System.Web.Script.Serialization;
using System.Xml;
using System.Collections.Generic;
//using System.Drawing;
using System.IO;


namespace CmlTechniques.CMS
{
    public partial class CMLUserLog : System.Web.UI.Page
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
            {
                GetUserLog(DateTime.Now);
                rdpLoginDate.SelectedDate = DateTime.Now;
            }
        }

        private void GetUserLog(DateTime loginDate)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clslog _objUser = new _clslog();
            _objUser.login = DateTime.Parse(loginDate.ToString()).ToString("dd/MM/yyyy"); 
            grdUserLog.DataSource = _objbll.Get_User_Log(_objUser, _objdb);
            grdUserLog.DataBind();
        }

        protected void grdUserLog_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[6].Visible = false;
                String ipAddress = e.Row.Cells[6].Text;
                if (e.Row.Cells[6].Text != string.Empty)
                {
                    Location ipLocation = GetLocation(ipAddress);
                    e.Row.Cells[4].Text = ipLocation.CountryName;
                    e.Row.Cells[5].Text = ipLocation.RegionName;
                }
            }
        }

        protected void btnGetReport_Click(object sender, EventArgs e)
        {
            if(rdpLoginDate.SelectedDate.ToString() == string.Empty)
                GetUserLog(DateTime.Now);
            else
                GetUserLog(Convert.ToDateTime(rdpLoginDate.SelectedDate));
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();    // Setup the response header.    
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=UserLog.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";    // Turn off view state.    
            this.EnableViewState = false;    // Create a string writer.    
            var stringWriter = new StringWriter();    // Create an HTML text writer and give it a string writer to use.    
            var htmlTextWriter = new HtmlTextWriter(stringWriter);    // Disable paging so we get all rows. 
            grdUserLog.RenderControl(htmlTextWriter);
            //listViewTrucks.RenderControl(htmlTextWriter);    // Grab the final HTML out of the string writer.    
            string output = stringWriter.ToString();    // Write the HTML output to the response, which in this case, is an Excel file.    
            Response.Write(output);
            Response.End();
        }

        private Location GetLocation(string ipaddress)
        {
            string APIKey = "8eb2665eed4aa81e3c5ff5be5e80c243e4fb5a8e41362a9cbc112454891a8a6b";
            string url = string.Format("http://api.ipinfodb.com/v3/ip-city/?key={0}&ip={1}&format=json", APIKey, ipaddress);
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                Location location = new JavaScriptSerializer().Deserialize<Location>(json);
                return location;
            }           
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}
