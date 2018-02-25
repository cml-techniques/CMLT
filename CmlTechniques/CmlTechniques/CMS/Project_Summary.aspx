<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Project_Summary.aspx.cs" Inherits="CmlTechniques.CMS.Project_Summary" %>

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
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
        <table style="width:100%">
        <tr>
        <td style="background-color:#092443;color:White;height:60px">
        <table>
        <tr>
        <td style="width:150px">&nbsp;</td>
        <td style="width:150px">&nbsp;</td>
        <td style="width:150px">&nbsp;</td>
        <td style="width:150px">&nbsp;</td>
        <td style="width:150px">&nbsp;</td>
        <td style="width:150px">&nbsp;</td>
        <td rowspan="2" width="70px" align="center" >
            &nbsp;</td>
        <td rowspan="2" width="70px" align="center" id="tdback" runat="server" >
        <a href="javascript:history.go(-1)">
        <img src="../images/back1.png" alt="Back" title="Back To Report" border="0" />
           </a>
        </td>
        </tr>
        <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td >&nbsp;</td>
        <td>&nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        </tr>
        </table>
        </td>
        </tr>
        <tr>
        <td style="height:100%">
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" HasCrystalLogo="False"
            HasToggleGroupTreeButton="False"  ToolPanelView="None" />
            <Triggers>
            <asp:PostBackTrigger ControlID="CrystalReportViewer1" />
            </Triggers>
            </asp:UpdatePanel>
          
        </td>
        </tr>
        </table>
        </div>
    </div>
    </form>
</body>
</html>
