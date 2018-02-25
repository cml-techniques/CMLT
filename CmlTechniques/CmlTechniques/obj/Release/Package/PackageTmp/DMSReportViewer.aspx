<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DMSReportViewer.aspx.cs" Inherits="CmlTechniques.DMSReportViewer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">

    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
     <link href="page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
        <table cellpadding="5">
        <tr>
        <td>Select Service</td>
        <td><asp:DropDownList ID="ddlFolderlist" runat="server" Width="250px"></asp:DropDownList></td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnShow" runat="server" Text="Generate"  Width="100px" OnClick="btnShow_Click"/>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
        </table>
        </div>
        <div>
        <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" unat="server" AutoDataBind="true" HasCrystalLogo="False"
            HasToggleGroupTreeButton="False"  ToolPanelView="None" />
            </ContentTemplate>
            <Triggers>
            <asp:PostBackTrigger ControlID="CrystalReportViewer1" />
            </Triggers>
            </asp:UpdatePanel>
        <div id="myprogress" runat="server" style="position:absolute; z-index:40;top:30%;left: 45%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="images/loading45.gif" Height="100px" Width="100px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
    </div>
        </div>
    </div>
    </form>
</body>
</html>
