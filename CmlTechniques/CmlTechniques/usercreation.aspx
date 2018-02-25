<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usercreation.aspx.cs" Inherits="CmlTechniques.usercreation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">

        function pageLoad() {
        }
    
    </script>

    <link href="page.css" rel="stylesheet" type="text/css" />
</head>
<body bgcolor="White">
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div style="padding-left: 5px; font-family: verdana; font-size: x-small;">
        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="100%">
            <asp:TabPanel runat="server" HeaderText="CREATE" ID="TabPanel1" Width="100%">
                <ContentTemplate>
                    <div>
                        <h1>
                            User Creation</h1>
                        <table border="0" cellpadding="0" cellspacing="5px" style="width: 100%">
                            <tr>
                                <td style="width: 150px">
                                    USER NAME
                                </td>
                                <td>
                                    <asp:TextBox ID="txtuname" runat="server" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    USER ID
                                </td>
                                <td>
                                    <asp:TextBox ID="txtuid" runat="server" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    COMPANY NAME
                                </td>
                                <td>
                                    <asp:DropDownList ID="drcompany" runat="server" Font-Names="Verdana" Width="250px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    USER GROUP
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="drusergroup" runat="server" Width="150px" Font-Names="Verdana"
                                                OnSelectedIndexChanged="drusergroup_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0">USER GROUP</asp:ListItem>
                                                <asp:ListItem Value="1">ADMIN GROUP</asp:ListItem>
                                                <asp:ListItem Value="2">SYS.ADMIN GROUP</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div id="access" runat="server">
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td valign="top" style="width: 155px">
                                                            SELECT ADMIN ACCESS
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBoxList ID="chkadminaccess" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid"
                                                                        BorderWidth="1px">
                                                                        <asp:ListItem Value="0">PROJECT CREATION</asp:ListItem>
                                                                        <asp:ListItem Value="1">USER CREATION</asp:ListItem>
                                                                        <asp:ListItem Value="2">PROJECT MANAGEMENT</asp:ListItem>
                                                                    </asp:CheckBoxList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    MODULE GROUP
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:CheckBoxList ID="chkmodule" runat="server" Width="150px" BorderColor="#CCCCCC"
                                                BorderStyle="Solid" BorderWidth="1px">
                                                <asp:ListItem Value="0">CMS</asp:ListItem>
                                                <asp:ListItem Value="1">DMS</asp:ListItem>
                                                <asp:ListItem Value="2">TMS</asp:ListItem>
                                            </asp:CheckBoxList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    SELECT PROJECTS
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:CheckBoxList ID="chkproject" runat="server" Width="100%" BorderColor="#CCCCCC"
                                                BorderStyle="Solid" BorderWidth="1px" RepeatColumns="3" RepeatDirection="Horizontal">
                                            </asp:CheckBoxList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="margin-left: 165px; margin-top: 50px">
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btncreate" runat="server" Text="Create" OnClick="btncreate_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="EDIT">
                <ContentTemplate>
                    <div>
                        <h1>
                            Edit User</h1>
                        <table border="0" cellpadding="0" cellspacing="5px" style="width: 100%">
                            <tr>
                                <td style="width: 150px">
                                    USER ID
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="druserid" runat="server" AutoPostBack="True" Font-Names="Verdana"
                                                Width="250px" OnSelectedIndexChanged="druserid_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    USER NAME
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtuname1" runat="server" Width="250px"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    COMPANY
                                </td>
                                <td>
                                    <asp:DropDownList ID="drcompany1" runat="server" Font-Names="Verdana" Width="250px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    USER GROUP
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="drusergroup1" runat="server" Width="150px" Font-Names="Verdana"
                                                OnSelectedIndexChanged="drusergroup_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="USER GROUP">USER GROUP</asp:ListItem>
                                                <asp:ListItem Value="ADMIN GROUP">ADMIN GROUP</asp:ListItem>
                                                <asp:ListItem Value="SYS.ADMIN GROUP">SYS.ADMIN GROUP</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                        <ContentTemplate>
                                            <div id="access1" runat="server">
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td valign="top" style="width: 155px">
                                                            SELECT ADMIN ACCESS
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBoxList ID="chkadminaccess1" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid"
                                                                        BorderWidth="1px">
                                                                        <asp:ListItem Value="0">PROJECT CREATION</asp:ListItem>
                                                                        <asp:ListItem Value="1">USER CREATION</asp:ListItem>
                                                                        <asp:ListItem Value="2">PROJECT MANAGEMENT</asp:ListItem>
                                                                    </asp:CheckBoxList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    MODULE GROUP
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                        <ContentTemplate>
                                            <asp:CheckBoxList ID="chkmodule1" runat="server" Width="150px" BorderColor="#CCCCCC"
                                                BorderStyle="Solid" BorderWidth="1px">
                                                <asp:ListItem Value="0">CMS</asp:ListItem>
                                                <asp:ListItem Value="1">DMS</asp:ListItem>
                                                <asp:ListItem Value="2">TMS</asp:ListItem>
                                            </asp:CheckBoxList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    SELECT PROJECTS
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                        <ContentTemplate>
                                            <asp:CheckBoxList ID="chkproject1" runat="server" Width="100%" BorderColor="#CCCCCC"
                                                BorderStyle="Solid" BorderWidth="1px" RepeatColumns="3" RepeatDirection="Horizontal">
                                            </asp:CheckBoxList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="margin-left: 165px; margin-top: 50px">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnedit" runat="server" Text="Update" OnClick="btnedit_Click" />
                                <asp:Button ID="btncancel1" runat="server" Text="Cancel" OnClick="btncancel1_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel runat="server" HeaderText="PROJECT AND MODULES" ID="TabPanel3" Width="100%">
                <ContentTemplate>
                    <div style="height: 100%;position:relative;">
                        <iframe src="UserProjectModule.aspx" frameborder="0" height="100%" width="100%">
                        </iframe>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
        <div>
        </div>
    </div>
    </form>
</body>
</html>
