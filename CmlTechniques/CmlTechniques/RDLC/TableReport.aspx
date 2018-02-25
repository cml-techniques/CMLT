<%@ Page Language="C#" MasterPageFile="~/Demo.master" AutoEventWireup="true" CodeFile="TableReport.aspx.cs" Inherits="ReportTypes_TableReport" %>
<%@ Register Src="TableReportViewerControl.ascx" TagName="TableReportViewerControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" Runat="Server">
    <uc1:TableReportViewerControl id="TableReportViewerControl1" runat="server"></uc1:TableReportViewerControl>
</asp:Content>
