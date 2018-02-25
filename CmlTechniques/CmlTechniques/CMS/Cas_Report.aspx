<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cas_Report.aspx.cs" Inherits="CmlTechniques.CMS.Cas_Report" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CML Techniques | CAS Reports</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblzone" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblcat" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblfl" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblfd" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblzero" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblsch" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lbldiv" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" HasCrystalLogo="False"
            HasToggleGroupTreeButton="False"  ToolPanelView="None" />
    </div>
    
    </form>
</body>
</html>
