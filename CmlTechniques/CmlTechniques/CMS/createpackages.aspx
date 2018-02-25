<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createpackages.aspx.cs" Inherits="CmlTechniques.CMS.createpackages" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

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
<body bgcolor="d1def1">
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div>
            <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
        <table>
        <tr>
        <td>Select Service</td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drservice" runat="server" Width="250px" 
                AutoPostBack="True" onselectedindexchanged="drservice_SelectedIndexChanged">
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
            
        </td>
        <td>
                        Select Cas sheet</td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drsub" runat="server" Width="250px" AutoPostBack="true" 
                    onselectedindexchanged="drsub_SelectedIndexChanged">
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
            
        </td>
        </tr>
        <tr>
        <td colspan="4">
            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                Width="636px">
                <asp:TabPanel runat="server" HeaderText="Create" ID="TabPanel1">
                <ContentTemplate>
                <table style="width:500px;background-color:Transparent">
                <tr>
        <td width="150px">Package name</td>
        <td>
            <asp:TextBox ID="txtpackage" runat="server" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
        <td>Category Code</td>
        <td><asp:TextBox ID="txtcode" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
        <td>&nbsp;</td>
        <td>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
            <%--<asp:DropDownList ID="drrdsheet" runat="server" Width="250px">
            </asp:DropDownList>--%>
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
        <td>
            </td>
            <td><asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" /></td>
        </tr>
                </table>
                
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="Edit" ID="TabPanel2">
                <ContentTemplate>
                <table style="width:500px;background-color:Transparent">
                <tr>
        <td width="150px">Package name</td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drpkg" runat="server" Width="250px" AutoPostBack="true" onselectedindexchanged="drpkg_SelectedIndexChanged">
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
            
            </td>
        </tr>
        <tr>
        <td>Category Code</td>
        <td>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
        <asp:TextBox ID="txtcode1" runat="server"></asp:TextBox>
        </ContentTemplate>
       </asp:UpdatePanel>
        </td>
        </tr>
        <tr>
        <td>&nbsp;</td>
        <td>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            <%--<asp:DropDownList ID="drrdsheet1" runat="server" Width="250px">
            </asp:DropDownList>--%>
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
        <td>
            
            </td>
            <td>
            <table>
            <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                <asp:Button ID="btnupdate" runat="server" OnClick="btnupdate_Click" 
                Text="Update" />
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btndelete" runat="server" Text="Delete" 
                        onclick="btndelete_Click" />
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            </tr>
            </table>
            
            </td>
        </tr>
                </table>
                
                </ContentTemplate>
                </asp:TabPanel>
              
            </asp:TabContainer>
            </td>
        </tr>
        
        </table>
        </div>
    </div>
    </form>
</body>
</html>
