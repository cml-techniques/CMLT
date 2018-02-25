<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TSReport.aspx.cs" Inherits="CmlTechniques.CMS.TSReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="lblindex" runat="server" Text="" style="display:none"></asp:Label>
    
    <div>
     
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="box1 blue_dark">
    <table>
        <tr>
        <td style="width:900px">
        <table id="filter_tbl" runat="server">
        <tr>
        <td style="width:200px">Select Service</td>
        <td style="width:200px">Period Start From</td>
        <td style="width:200px">&nbsp;</td>
        <td style="width:300px">
            <asp:Label ID="lblid" runat="server" style="display:none"></asp:Label>
                                </td>
        </tr>
        <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drservices" runat="server" Width="100%" >
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
            
            </td>
        <td>
         <asp:TextBox ID="txt_from" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date15_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_from" 
                                TargetControlID="txt_from">
                            </asp:CalendarExtender></td>
        <td>
            &nbsp;</td>
        <td>
            <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label><asp:Label ID="lblsrv" runat="server" Text="" CssClass="hidden"></asp:Label></td>
        </tr>
        </table>
        </td>
        <td width="70px" align="center" >
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
            <asp:Button ID="btngenerate" runat="server" Text="" Width="60px" Height="60px"
                    onclick="btngenerate_Click" style="cursor:pointer;background:url('../images/graph.png') top left;border:0" ToolTip="View Summary" />
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td width="70px" align="center" id="tdback" runat="server" >
        <a onclick="goback();">
        <img src="../images/back1.png" alt="Back" title="Back To Report" border="0" />
           </a>
        </td>
        </tr>
        </table>
    </div>
    <div style="padding:0 0 0 10px">
    <div style="width:100%">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
        <ContentTemplate>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" HasCrystalLogo="False"
            HasToggleGroupTreeButton="False"  ToolPanelView="None"/>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="CrystalReportViewer1" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div id="myprogress" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div>
    </div>
    </div>
    </form>
      <script type="text/javascript">
          function goback()
      { 
      
      var index=document.getElementById('<%=lblindex.ClientID%>').innerHTML;
     // var index=1;
      parent.document.getElementById("content").src = "cmsreports.aspx?idx="+index;
      }
      
    </script>
</body>
</html>
