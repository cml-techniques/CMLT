using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;

namespace CmlTechniques
{
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string paramStr = "";
            int parampos = Request.RawUrl.IndexOf("?");
            if (parampos >= 0)
                paramStr = Request.RawUrl.Substring(parampos + 1);

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = Server.MapPath("search.cgi");
            psi.EnvironmentVariables["REQUEST_METHOD"] = "GET";
            psi.EnvironmentVariables["QUERY_STRING"] = paramStr;
            psi.EnvironmentVariables["REMOTE_ADDR"] = Request.ServerVariables["REMOTE_ADDR"];
            psi.RedirectStandardInput = false;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            Process proc = Process.Start(psi);
            proc.StandardOutput.ReadLine(); // skip the HTTP header line
            string zoom_results = proc.StandardOutput.ReadToEnd(); // read from stdout 
            proc.WaitForExit();
            // Print the output
            Response.Write(zoom_results);

        }
    }
}
