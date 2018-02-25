<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExecutiveSummaryReport_PCD.aspx.cs"
    Inherits="CmlTechniques.ExecutiveSummaryReport_PCD" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>

    <script type="text/javascript">
      function pageLoad() {
      }
      function goback()
      {
        parent.document.getElementById("content").src = "cmsreports.aspx?idx=1";
      }
    
    </script>

    <script src="../Scripts/jquery.js" type="text/javascript"></script>

    <link href="../page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
         html, body
        {
            width: 100%;
        }
        table
        {
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" AsyncPostBackTimeout="1000">
    </asp:ToolkitScriptManager>
    <asp:Label ID="lbldiv" runat="server" Text="" Style="display: none"></asp:Label>
    <asp:Label ID="lblprj" runat="server" Text="" Style="display: none"></asp:Label>
    <asp:Label ID="lbltxt" runat="server" Text="" Style="display: none"></asp:Label>
    <input id="hdnpcdfrom" type="hidden" name="hdnpcdfrom" runat="server">
    <input id="hdnpcdto" type="hidden" name="hdnpcdto" runat="server">
    <div class="rpthead">
        <div class="rptfilter">
            <table style="width: 100%">
                <tr>
                    <td style="width: 100px">
                        Date From
                    </td>
                    <td style="width: 100px">
                        Date To
                    </td>
                    <td style="width: 125px">
                        Type
                    </td>
                    <td style="width: 150px">
                        Service
                    </td>
                    <td style="width: 150px" rowspan="2" valign="bottom">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblmode" runat="server" Text="" Style="display: none"></asp:Label>
                                <asp:Label ID="lblsrv" runat="server" Text="" Style="display: none"></asp:Label>
                                <asp:Label ID="lblfl" runat="server" Text="" Style="display: none"></asp:Label>
                                <asp:Button ID="btngenerate" runat="server" Text="Generate" Width="70px" Height="30px"
                                    CssClass="comment-btn" ToolTip="Generate" OnClick="btngenerate_Click" OnClientClick="setGen()" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>                  
                    <td style="width: 150px">
                        &nbsp;
                    </td>
                    <td style="width: 150px">
                    </td>
                    <td rowspan="2" width="70px" align="center">
                        &nbsp;
                    </td>
                    <td rowspan="2" width="70px" align="center" id="tdback" runat="server" valign="bottom">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnback" runat="server" Text="Back" Width="70px" Height="30px" CssClass="comment-btn"
                                    ToolTip="Back to Previous" OnClick="btnback_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtdatefrom" runat="server" Text="" Width="100px" ReadOnly="true">
                        </asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                            PopupButtonID="txtdatefrom" TargetControlID="txtdatefrom">
                        </asp:CalendarExtender>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdateto" runat="server" Text="" Width="100px" ReadOnly="true">
                        </asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                            PopupButtonID="txtdateto" TargetControlID="txtdateto">
                        </asp:CalendarExtender>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddltype" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddltype_SelectedIndexChanged">
                            <asp:ListItem Text="Weekly" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Monthly" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Yearly" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlService" runat="server" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div>
        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
                <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="true"
                    HasCrystalLogo="False" HasToggleGroupTreeButton="False" 
                    ToolPanelView="None" ReuseParameterValuesOnRefresh="True" />
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="CrystalReportViewer2" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div id="Div11" runat="server" style="position: absolute; z-index: 40; top: 30%;
        left: 35%">
        <asp:UpdateProgress ID="UpdateProgress13" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload12" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                    Width="250px" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    </form>

    <script type="text/javascript">
    $( document ).ready(function() {
  //SetCurrentDate();
});
//   function SetCurrentDate()
//      {
//    var tdate = new Date();
//   var dd = tdate.getDate(); //yields day
//   var MM = tdate.getMonth(); //yields month
//   var yyyy = tdate.getFullYear(); //yields year
//   var xxx = dd + "/" +( MM+1) + "/" + yyyy;
//   
//      var defaultStart = '01/01/'+new Date().getFullYear()
//      
//      document.getElementById("txtdatefrom").value=defaultStart;
//       document.getElementById("txtdateto").value=xxx;
//       
//      document.getElementById("hdnpcdfrom").value=defaultStart;
//        document.getElementById("hdnpcdto").value=xxx;
//    
//       
//      }
      function setGen()
      {
      
      var mdatefrom= document.getElementById("txtdatefrom").value;
       var mdateto= document.getElementById("txtdateto").value;
       document.getElementById("hdnpcdfrom").value=mdatefrom;
        document.getElementById("hdnpcdto").value=mdateto;
       
      }
    </script>

</body>
</html>
