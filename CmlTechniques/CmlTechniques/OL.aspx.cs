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
using Microsoft.Office.Interop.Outlook;
namespace CmlTechniques
{
    public partial class OL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_create_Click(object sender, EventArgs e)
        {
            try
            {
                _Application olApp = (_Application)new Application();
                NameSpace mapiNS = olApp.GetNamespace("MAPI");

                string profile = "";
                mapiNS.Logon(profile, null, null, null);
                _AppointmentItem apt = (_AppointmentItem)
                        olApp.CreateItem(OlItemType.olAppointmentItem);
                // set some properties
                apt.Subject = txt_subject.Text;
                apt.Body = txt_content.Text;
                apt.Start = Convert.ToDateTime(txt_start.Text);
                apt.End = Convert.ToDateTime(txt_end.Text);
                apt.ReminderMinutesBeforeStart = 15;		// One week
                apt.BusyStatus = OlBusyStatus.olTentative;	// Makes it appear bold in the calendar - which I like!
                if (chk_eventtype.Checked == true)
                    apt.AllDayEvent = true;
                else
                    apt.AllDayEvent = false;
                apt.Location = txt_location.Text;
                //apt.Save();
                apt.Display(olApp);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Appointment Created');", true);
            }
            catch
            {
                throw;
            }
        }
    }
}
