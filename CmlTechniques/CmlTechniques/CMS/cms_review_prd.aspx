<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cms_review_prd.aspx.cs" Inherits="CmlTechniques.CMS.cms_review_prd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
        <table>
        <tr>
        <td>Review Period (in days)</td>
        <td>
            <asp:TextBox ID="txtperiod" runat="server"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>First Reminder after</td>
        <td>
        
            <asp:TextBox ID="txtfrem" runat="server"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>Second Reminder after</td>
        <td>
            <asp:TextBox ID="txtsrem" runat="server"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>Third Reminder after</td>
        <td>
            <asp:TextBox ID="txttrem" runat="server"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td></td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnsave" runat="server" Text="Save" />
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
