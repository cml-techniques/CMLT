<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cmsuserpermission.aspx.cs" Inherits="CmlTechniques.CMS.cmsuserpermission" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
</head>
<body bgcolor="#D1DEF1">
    <form id="form1" runat="server">
    <div style="height:100%;padding-left:5px;position:fixed">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div style="height:10%">
        <table>
        <tr>
        <td>Select User</td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drprjuser" runat="server" Width="250px" AutoPostBack="true" 
                    onselectedindexchanged="drprjuser_SelectedIndexChanged">
            </asp:DropDownList></ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
        <tr>
        <td>Access Level</td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="draccess" runat="server" Width="250px" >
            <asp:ListItem Value="3">&lt;&lt;Select Access&gt;&gt;</asp:ListItem>
            <asp:ListItem Value="0">Admin</asp:ListItem>
            <asp:ListItem Value="1">Review/Comments</asp:ListItem>
            <asp:ListItem Value="2">Review</asp:ListItem>
            <asp:ListItem Value="4">Read Only</asp:ListItem>
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
        
            
            </td>
        </tr>
        <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="Label1" runat="server" Text="" style="display:none"></asp:Label>
        
            
            </td>
        </tr>
        </table>
        </div>
        <div style="height:80%;overflow:auto;width:100%">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:TreeView ID="mytree" runat="server" ShowCheckBoxes="All" >
            </asp:TreeView></ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <div>
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
        <ContentTemplate>
            <asp:CheckBox ID="chknoti" runat="server" 
                Text="Send Email Notification for Document Uploads" Font-Bold="True" 
                Font-Italic="True" ForeColor="Red" />
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>
        </div>
        
        <div style="height:10%">
        <table>
        <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" 
                    onclick="btnsubmit_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
        </table>
        </div>
    </div>
    </form>
</body>
</html>
