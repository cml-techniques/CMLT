<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logout.aspx.cs" Inherits="CmlTechniques.logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">

        function pageLoad() {
      
      }
    
    </script>
    <script type="text/javascript">
        function gettime() {
            var dt = new Date();
            document.getElementById('_logout').value = dt.format("dd/MM/yyyy hh:mm:ss tt");
        }
</script>
    </head>
<body bgcolor="Black" onload="javascript:gettime();">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <table style="position: fixed; width: 100%; height: 100%; font-family: verdana; font-size: small; color: #FFFFFF;">
            <tr>
                <td align="center" height="20px" valign="top">
                    <input id="_logout" type="hidden" runat="server" />
                    <asp:ImageButton ID="_btnlogout" runat="server" ImageUrl="~/images/logout.png" 
                        onclick="_btnlogout_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" valign="top">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/loading6.gif" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
