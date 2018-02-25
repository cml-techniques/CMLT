<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Doc_Summary.aspx.cs" Inherits="CmlTechniques.CMS.Doc_Summary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
      function goback()
      {
          
     var index=document.getElementById('<%=lblindex.ClientID%>').innerHTML;
    
      parent.document.getElementById("content").src = "cmsreports.aspx?idx="+index;
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblindex" runat="server" Text="" style="display:none"></asp:Label>
        <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
         <asp:Label ID="lbltotal" runat="server" Text="0" style="display:none"></asp:Label>
          <asp:Label ID="lbltype" runat="server" Text="0" style="display:none"></asp:Label>
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div>
        <table style="width:100%">
        <tr>
        <td style="background-color:#092443;color:White;">
        <table style="float:left;display:inline-table">
        <tr>
        <td style="width:80px" rowspan="2"  visible="false" runat="server" id="lbltdservice">Service </td>
        <td style="width:150px" rowspan="2" id="ddtdservice" visible="false" runat="server"><asp:DropDownList ID="drservices" runat="server" Width="100%" >
            </asp:DropDownList></td>
        <td style="width:150px" rowspan="2" id="btntdview" visible="false" runat="server" >
      <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                            <asp:Button ID="btnmsdview" runat="server" Text="View" Width="70px" Height="30px"
                                CssClass="comment-btn" ToolTip="View Ms" onclick="btnmsdview_Click" />
                            <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                            </td>
        <td style="width:150px">&nbsp;</td>
        <td style="width:150px">&nbsp;</td>
        <td style="width:150px">&nbsp;</td>
        <td rowspan="2" width="70px" align="center" >
            &nbsp;</td>
        <td rowspan="2" width="70px" align="right" id="tdback" runat="server" >
        
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
        <div style="float:right;display:inline;padding:6px 0px;" >
        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                            <asp:Button ID="btnback" runat="server" Text="Back" Width="70px" Height="30px"
                                CssClass="comment-btn" ToolTip="Back to Previous" onclick="btnback_Click" />
                            </ContentTemplate>
                            </asp:UpdatePanel>
        </div>
        </td>
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
    </div>
    </form>
</body>
</html>
