<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="company.aspx.cs" Inherits="CmlTechniques.company" %>

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
        <table>
        <tr>
        <td width="150px">Company Name</td>
        <td><asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txtname" runat="server" Width="300px"></asp:TextBox>
            </ContentTemplate>
            </asp:UpdatePanel></td>
            
        </tr>
        <tr>
        <td>Project</td>
        <td><asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="drproject" runat="server" Width="300px">
                </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel></td>
        </tr>
        <tr>
        <td></td><td></td>
        </tr>
        <tr>
        <td>&nbsp;</td><td><asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnadd" runat="server" Text="Create" onclick="btnadd_Click" />
            </ContentTemplate>
            </asp:UpdatePanel></td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
