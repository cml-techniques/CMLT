<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReviewSetting.aspx.cs" Inherits="CmlTechniques.CMS.ReviewSetting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding:10px">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <table>
        <tr>
        <td style="width:150px">Document</td>
        <td style="width:200px">
            <asp:DropDownList ID="drdocument" runat="server" Width="200px">
            <asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>
            <asp:ListItem Text="Document Review" Value="1"></asp:ListItem>
            <asp:ListItem Text="Method Statement" Value="2"></asp:ListItem>
            <asp:ListItem Text="Minutes" Value="3"></asp:ListItem>
            <asp:ListItem Text="Programms" Value="4"></asp:ListItem>
            <asp:ListItem Text="Site Observation" Value="5"></asp:ListItem>
            </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td style="width:150px">Review Period(Days)</td>
        <td style="width:200px">
            <asp:TextBox ID="txtdays" runat="server"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td style="width:150px">&nbsp;</td>
        <td style="width:200px">
            &nbsp;</td>
        </tr>
        <tr>
        <td style="width:150px">&nbsp;</td>
        <td style="width:200px">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
            
        </td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
