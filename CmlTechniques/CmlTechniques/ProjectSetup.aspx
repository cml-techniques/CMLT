<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectSetup.aspx.cs" Inherits="CmlTechniques.ProjectSetup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="page.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="Scripts/jquery.MultiFile.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <table>
            <tr>
                <td width="250px">
                    Select Project</td>
                <td>
                    <asp:DropDownList ID="drproject" runat="server" Width="250px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    Select Document</td>
                <td height="40px" valign="top">
                    <input type="file" id="myupload" class="multi" runat="server" /></td>
            </tr>
            
            <tr>
                <td >
                    &nbsp;</td>
                <td >
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    </td>
                <td >
                    <asp:Button ID="btnupload" runat="server" Text="Upload" 
                        onclick="btnupload_Click" />
                </td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td >
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
