<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CX_Issue_Log_Summary.aspx.cs" Inherits="CmlTechniques.CMS.CX_Issue_Log_Summary" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CX Issues Log</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: verdana; font-size: xx-small">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
            <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label><asp:Label ID="lblsch" runat="server" Text="" style="display:none"></asp:Label>
        <table style="width:100%">
        <tr>
        <td style="background-color:#092443;color:White;height:0px">
            &nbsp;</td>
        </tr>
        <tr>
        <td style="height:100%">
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" HasCrystalLogo="False"
            HasToggleGroupTreeButton="False"  ToolPanelView="None" />
            </ContentTemplate>
            <Triggers>
            <asp:PostBackTrigger ControlID="CrystalReportViewer1" />
            </Triggers>
            </asp:UpdatePanel>
          
        </td>
        </tr>
        </table>
        </div>
        <div id="myprogress" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div>
        
    </div>
    </form>
</body>
</html>
