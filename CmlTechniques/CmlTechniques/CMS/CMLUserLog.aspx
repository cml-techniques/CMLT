<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CMLUserLog.aspx.cs" Inherits="CmlTechniques.CMS.CMLUserLog" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .contentFont
        {
        	font-size:x-small;
        	font-family:Verdana;
        }
         .headerFont
        {
        	font-size:x-small;
        	font-family:Verdana;
        	font-weight:bold;
        	background-color:#13264F;
        	color: #FFFFFF;
        	text-align:center;
        	vertical-align:middle;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="contentFont">
     <telerik:RadScriptManager runat="server" ID="RadScriptManagerUserLog" />
    <div style="margin:0;padding:0;position: absolute;top: 0;bottom: 0;left: 0;right: 0;" >
    
    <table width="100%" cellspacing="5">
    <tr>
    <td colspan="4" style="font-family: Verdana; font-size: medium; font-weight: bold; line-height:50px;" valign="top" align="left">User Log Details</td>
    </tr>
    <tr>
    <td style="font-family: Verdana; font-size: x-small; font-weight: bold;width:15%;" align="left">Select Login Date : </td>
    <td style="width:15%;" align="left">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>                                    
        <telerik:RadDatePicker ID="rdpLoginDate" runat="server"  >
        <DateInput ID="diLoginDate" runat="server" DateInput-DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"> </DateInput> </telerik:RadDatePicker>
        </ContentTemplate>
        </asp:UpdatePanel> 
    </td>       
    <td style="width:15%;" align="right">
    <asp:Button ID="btnGetReport" Text="Get User Log" runat="server" OnClick="btnGetReport_Click" /> 
    </td>
    <td align="right" style="padding-right:10px;"><asp:ImageButton ID="btnExportExcel" runat="server" OnClick="btnExportExcel_Click" ImageUrl="~/images/icon_excel.jpg" ToolTip="Export to Excel" Height="25px" Width="25px" BorderStyle="None"/></td>
    </tr>
    </table>
    <br />
    <asp:GridView ID="grdUserLog" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-BackColor="#F3F3F4" onrowdatabound="grdUserLog_RowDataBound" Width="100%" 
     CellPadding="5" ShowHeader="true" EmptyDataText="No records to display" CssClass="contentFont"  >
     <HeaderStyle CssClass="headerFont" />
    <Columns>
        <asp:BoundField DataField="UserID" HeaderText="User ID"/>
        <asp:BoundField DataField="UserName" HeaderText="User Name"/>
        <asp:BoundField DataField="Company" HeaderText="Company"/>
        <asp:BoundField DataField="LoginTime" HeaderText="LoginTime"><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
        <asp:BoundField DataField="Location" HeaderText="Location"/>
        <asp:BoundField DataField="Region" HeaderText="Region"/>
        <asp:BoundField DataField="IPAddress" />
    </Columns>    
    </asp:GridView>
    </div>
    </form>
</body>
</html>
