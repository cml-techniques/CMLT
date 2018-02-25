<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemConfig.aspx.cs" Inherits="CmlTechniques.SystemConfig" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    </script>
    <link href="page.css" rel="stylesheet" type="text/css" />
</head>
<body bgcolor="#D1DEF1">
    <form id="form1" runat="server">
    <div style="height:100%;width:100%;position:fixed">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div style="height:100%;width:100%">
        <div>
        <table>
        <tr>
        <td>PROJECT</td><td>
            <asp:DropDownList ID="drproject" runat="server" Width="300px">
            </asp:DropDownList>
        </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            <asp:Button ID="btngo" runat="server" Text="Continue" onclick="btngo_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
        </table>
        </div>
            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
            <ContentTemplate>
            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="4" 
                    Width="100%" >
                <asp:TabPanel runat="server" HeaderText="Project Services" ID="TabPanel13">
                <ContentTemplate>
                <div style="height:500px;width:100%;overflow:auto;background-color:#d1def1">
                    <div style="height:450px;width:100%;overflow:auto" >
                        <asp:RadioButtonList ID="rdsrv" runat="server" 
                            RepeatDirection="Horizontal">
                        <asp:ListItem Text="Cas Sheet" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Method Statements" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <asp:CheckBoxList ID="chkcasservice" runat="server">
                    </asp:CheckBoxList>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>
                    <div style="height:50px;width:100%">
                    <center>
                    <table>
                    <tr>
                    <td><asp:Button ID="btn2save" runat="server" Text="Save" OnClick="btn2save_Click" /></td>
                    <td><asp:Button ID="Button2" runat="server" Text="Cancel" /></td>
                    </tr>
                    </table>
                    </center>
                    </div>
                </div>
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="Project Cas Sheets" ID="TabPanel2">
                <ContentTemplate>
                <div style="height:500px;width:100%;overflow:auto;background-color:#d1def1">
                    <div style="height:450px;width:100%;overflow:auto" >
                            <table>
                            <tr>
                            <td width="150px">Select Service</td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                <asp:DropDownList ID="drcasservice" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="drcasservice_SelectedIndexChanged">
                                </asp:DropDownList>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            </tr>
                            <tr>
                            <td></td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                <asp:CheckBoxList ID="chkcassheet" runat="server">
                                </asp:CheckBoxList>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            </tr>
                            </table>
                    </div> 
                    <div style="height:50px;width:100%">
                    <center>
                    <table>
                    <tr>
                    <td><asp:Button ID="btn3save" runat="server" Text="Save" OnClick="btn3save_Click" /></td>
                    <td><asp:Button ID="Button3" runat="server" Text="Cancel" /></td>
                    </tr>
                    </table>
                    </center>
                    </div>
                </div>
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="Cas Sheets Packages" ID="TabPanel1">
                <ContentTemplate>
                <div style="height:500px;width:100%;overflow:auto;background-color:#d1def1">
                    <div style="height:450px;width:100%;overflow:auto" >
                            <%--<asp:TreeView ID="mycashtree" runat="server">
                            </asp:TreeView>--%>
                            <table>
                            <tr>
                            <td width="150px">Select Service</td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                <ContentTemplate>
                                <asp:DropDownList ID="drserv" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="drcasservice_SelectedIndexChanged">
                                </asp:DropDownList>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            </tr>
                            <tr>
                            <td width="150px">Select Cas Sheet</td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                <ContentTemplate>
                                <asp:DropDownList ID="drcas" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="drcasservice_SelectedIndexChanged">
                                </asp:DropDownList>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            </tr>
                            
                            <tr>
                            <td>System List</td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                <asp:CheckBoxList ID="chksyslist" runat="server">
                                </asp:CheckBoxList>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            </tr>
                            </table>
                    </div> 
                    <div style="height:50px;width:100%">
                    <center>
                    <table>
                    <tr>
                    <td><asp:Button ID="Button1" runat="server" Text="Save"  /></td>
                    <td><asp:Button ID="Button5" runat="server" Text="Cancel" /></td>
                    </tr>
                    </table>
                    </center>
                    </div>
                </div>
                </ContentTemplate>
                </asp:TabPanel>
                
                <asp:TabPanel runat="server" HeaderText="MS Systems" ID="TabPanel3">
                <ContentTemplate>
                <div style="height:500px;width:100%;overflow:auto;background-color:#d1def1">
                <div style="height:450px;width:100%;overflow:auto" >
                <table>
                <tr>
                <td>Select Service</td><td>
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="drmsservice" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drmsservice_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                </tr>
                <tr>
                <td>Select Systems</td><td>
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <asp:CheckBoxList ID="chkmssystem" runat="server">
                            </asp:CheckBoxList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                </tr>
                </table>
                </div>
                <div style="height:50px;width:100%">
                    <center>
                    <table>
                    <tr>
                    <td><asp:Button ID="btn4save" runat="server" Text="Save" OnClick="btn4save_Click" /></td>
                    <td><asp:Button ID="Button4" runat="server" Text="Cancel" /></td>
                    </tr>
                    </table>
                    </center>
                    </div>
                </div>
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="CMS Document Review Settings" ID="TabPanel6">
                <ContentTemplate>
                <div style="padding:50px">
                <table>
        <tr>
        <td style="width:150px">Document</td>
        <td style="width:200px">
            <asp:DropDownList ID="drdocument" runat="server" Width="200px">
            <asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>
            <asp:ListItem Text="Document Review" Value="1"></asp:ListItem>
            <asp:ListItem Text="Method Statement" Value="2"></asp:ListItem>
            <asp:ListItem Text="Site Observation" Value="3"></asp:ListItem>
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
            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
        </table>
        <div>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <asp:GridView ID="mygrid" runat="server" AutoGenerateColumns="False" 
                    BackColor="#CCCCFF"  CellPadding="5" CellSpacing="1" GridLines="None" >
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <Columns>
                    <asp:BoundField DataField="Document_Name" HeaderText="DOCUMENT" >
                        <ItemStyle Width="250px" />
                        </asp:BoundField>
                    <asp:BoundField DataField="Review_Days" HeaderText="REVIEW PERIOD (DAYS)" >
                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
                </div>
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="DMS Services" ID="TabPanel7">
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="DMS Document Review Settings" ID="TabPanel10">
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="Project Settings" ID="TabPanel9">
                </asp:TabPanel>
            </asp:TabContainer>
            </ContentTemplate>
            </asp:UpdatePanel>
            
        </div>
    </div>
    </form>
</body>
</html>
