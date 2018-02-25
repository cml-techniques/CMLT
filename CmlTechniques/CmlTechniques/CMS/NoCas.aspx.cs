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

namespace CmlTechniques.CMS
{
    public partial class NoCas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                if (_prm == "45")
                {
                    lblcas.Text = "6.2.3 - CO Monitoring and Car Park Ventilation Controls";
                }
                else if (_prm == "47")
                {
                    lblcas.Text = "6.2.16 - Fuel Leak Monitoring and Water Leak Detection Systems";
                }
                else if (_prm == "48")
                {
                    lblcas.Text = "6.2.17 - Drug/ Blood Refrigerator Alarm Systems";
                }
                else if (_prm == "49")
                {
                    lblcas.Text = "6.2.18 - Mortuary Refrigeration and Alarm Systems";
                }
                else if (_prm == "50")
                {
                    lblcas.Text = "6.2.19 - Medical Gas Alarm Systems - O2, N2O, Gas Evacuation, Medical Air, Medical Vacuum";
                }
                else if (_prm == "60")
                {
                    lblcas.Text = "6.3.11 - Clean Room Systems";
                }
                else if (_prm == "92")
                {
                    lblcas.Text = "6.4.8 - Acid Neutralisation System";
                }
                else if (_prm == "93")
                {
                    lblcas.Text = "6.4.9 - Radioactive Waste Disposal";
                }
                else if (_prm == "95")
                {
                    lblcas.Text = "6.4.11 - Fire Fighting - Clean Agent Extinguishing System";
                }
                else if (_prm == "96")
                {
                    lblcas.Text = "6.4.12 - Fire Fighting - Kitchen Hood Suppression System";
                }
                else if (_prm == "98")
                {
                    lblcas.Text = "6.4.14 - Processed Water Syste";
                }
                else if (_prm == "110")
                {
                    lblcas.Text = "6.5.8 - Waste Management Equipment";
                }
                else if (_prm == "113")
                {
                    lblcas.Text = "6.6.2 - Waste Anaesthetic Gas Disposal";
                }
                else if (_prm == "114")
                {
                    lblcas.Text = "6.6.3 - Compressed Air";
                }
                else if (_prm == "115")
                {
                    lblcas.Text = "6.6.4 - Vacuum";
                }
            }
        }
    }
}
