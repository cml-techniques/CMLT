<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuildingSummary.aspx.cs" Inherits="CmlTechniques.CasSheet.BuildingSummary" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

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
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"  ScriptMode="Release" AsyncPostBackTimeout="1000"  ></asp:ScriptManager>
        <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label>
         <asp:Label ID="lblbz" runat="server" Text="" CssClass="hidden"></asp:Label>
         <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="TimerTick" >
            </asp:Timer>
                <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" 
                    AutoDataBind="true" HasCrystalLogo="False"
            HasToggleGroupTreeButton="False"  ToolPanelView="None" />
            <%--<asp:Image ID="imgLoader" runat="server" ImageUrl="../images/loading45.gif" Height="100px" Width="100px" style="top:40%;left: 45%" />--%>
            </ContentTemplate>
            <Triggers>
            <asp:PostBackTrigger ControlID="CrystalReportViewer2" />
            </Triggers>
            </asp:UpdatePanel>
            <div id="myprogress" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%;">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading45.gif" Height="100px" Width="100px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
    </div>
    </div>
    </form>
</body>
</html>
