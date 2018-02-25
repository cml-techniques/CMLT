<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="CmlTechniques.search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Diagnostics" %>
<%
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
%>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script language="JavaScript" src="Scripts/settings.js" type="text/javascript"></script>
	<script language="JavaScript" src="Scripts/search.js" type="text/javascript"></script>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <%--<input id="zoom_searchbox" type="text" class="zoom_searchbox" name="zoom_query" /><input type="submit" value="submit"  class="zoom_button" />--%>
        
        <br />
        <table >
            <tr>
                <td bgcolor="Black">
                    &nbsp;</td>
                <td bgcolor="Black">
                    &nbsp;</td>
            </tr>
            <tr>
                <td><%--<script language="JavaScript" type="text/javascript">ZoomSearch();</script>--%>

                    <%--<input id="zoom_searchbox" type="text" class="zoom_searchbox" /><input id="Submit1" type="submit" value="submit" class="zoom_button" />--%>
                    <%--<script language="JavaScript" >ZoomSearch();</script></td>--%>
                    <%--<iframe id="f1" src="Scripts/search.html" height="200px" frameborder="0" ></iframe>
                    <iframe id="f2" name="f2" height="100%" width="100%" runat="server"></iframe>--%>
                    
                    </td>
                   
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
