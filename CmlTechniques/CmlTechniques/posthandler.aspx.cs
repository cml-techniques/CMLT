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
using System.Net;
using System.IO;

namespace CmlTechniques
{
    public partial class posthandler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Form["iptocheck"] != "")
            {
                string result = string.Empty;
                string MYIPTOCHECK = HttpContext.Current.Request.Form["iptocheck"];
                string myuri =
                string.Format("http://www.ecubicle.net/iptocountry.asmx/FindCountryAsString?V4IPAddress={0}", MYIPTOCHECK);
                HttpWebRequest myrequest = WebRequest.Create(myuri) as HttpWebRequest;
                HttpWebResponse myresponse = (HttpWebResponse)myrequest.GetResponse();
                StreamReader mystreamreader = new StreamReader(myresponse.GetResponseStream());
                while (!mystreamreader.EndOfStream)
                {
                    result = result + mystreamreader.ReadLine() + "<br>";
                }
                mystreamreader.Close();
                //newid.Mode = LiteralMode.PassThrough;
                //newid.Text = Server.HtmlDecode(result);

            }
        }
    }
}
