<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage_Head.aspx.cs" Inherits="CmlTechniques.Manage_Head" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
     <link href="page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
        <div style="background-color:#1d1d1d;color:#ffffff;width:100%;height:30px">
        <div style="float:left;width:350px;font-size:14px;font-weight:bold;padding:5px"><asp:Label ID="lblhead" runat="server" Text="Management"></asp:Label></div>
        <div style="float:left;width:500px"></div>
            
        </div>
        <div style="clear:both"></div>
            <asp:Label ID="lblmode" runat="server" Text="" CssClass="hidden"></asp:Label>
        <div style="padding:5px;background-color:#999;border-bottom:solid 1px #1d1d1d">
        <table cellpadding="5">
        <tr>
        <td>PROJECT</td>
        <td>
         
            <asp:DropDownList ID="drproject" runat="server" Width="300px" 
                onselectedindexchanged="drproject_SelectedIndexChanged">
            </asp:DropDownList>
 
            
        </td>
        <td>ACTION</td>
        <td>
            <asp:DropDownList ID="draction" runat="server" Width="200px" AutoPostBack="true">
            </asp:DropDownList>
        </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:Button ID="btngo" runat="server" Text="GO" Width="75px" 
                    onclick="btngo_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
        </table>
        </div>
        </div>
    </div>
    </form>
</body>
</html>
