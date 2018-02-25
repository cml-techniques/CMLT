<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageTrainingFolder.aspx.cs" Inherits="CmlTechniques.CMS.ManageTrainingFolder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: verdana; font-size: x-small;padding:10px">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <table style="width:100%">
        <tr>
        <td style="width:150px">FOLDER NAME</td>
        <td >
            <asp:Label ID="lbfolder" runat="server" Text="" Font-Size="Small"></asp:Label>
        </td>
        </tr>
        <tr>
        <td style="width:150px">SELECT ACTION</td>
        <td >
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="draction" runat="server" Width="200px" AutoPostBack="true" 
                    onselectedindexchanged="draction_SelectedIndexChanged">
            <asp:ListItem Text="-- Select Action --" Value="0"></asp:ListItem>
            <asp:ListItem Text="Create Folder" Value="1"></asp:ListItem>
            <asp:ListItem Text="Create Sub Folder" Value="3"></asp:ListItem>
            <asp:ListItem Text="Edit Folder" Value="2"></asp:ListItem>
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
        <tr>
        <td style="width:150px">FOLDER NAME</td>
        <td >
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
            <asp:TextBox ID="txtfolder" runat="server" Width="300px"></asp:TextBox>
            </ContentTemplate>
            </asp:UpdatePanel>
            
        </td>
        </tr>
        <tr>
        <td style="width:150px">&nbsp;</td>
        <td >
            &nbsp;</td>
        </tr>
        <tr>
        <td style="width:150px">&nbsp;</td>
        <td >
        <table>
        <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:Button ID="btncreate" runat="server" Text="Save" onclick="btncreate_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            <asp:Button ID="btndelete" runat="server" Text="Delete" onclick="btndelete_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
        </table>
        </td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
