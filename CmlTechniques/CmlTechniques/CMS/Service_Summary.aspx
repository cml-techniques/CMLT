<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Service_Summary.aspx.cs"
    Inherits="CmlTechniques.CMS.Service_Summary" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script type="text/javascript">
        function pageLoad() {
        }
        function goback() {
            parent.document.getElementById("content").src = "cmsreports.aspx?idx=1";
        }
    
    </script>
     <%-- <script type="text/javascript" language="javascript">
          Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
          function EndRequestHandler(sender, args) {
              if (args.get_error() != undefined) {
                  args.set_errorHandled(true);
              }
          }
    </script>--%>

    <script src="../Scripts/jquery.js" type="text/javascript"></script>

    <link href="../page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" AsyncPostBackTimeout="1000">
    </asp:ToolkitScriptManager>
    <asp:Label ID="lbldiv" runat="server" Text="" Style="display: none"></asp:Label>
    <asp:Label ID="lblprj" runat="server" Text="" Style="display: none"></asp:Label>
    <asp:Label ID="lbltxt" runat="server" Text="" Style="display: none"></asp:Label>
    <input id="hdnpcd" type="hidden" name="hdnpcd" runat="server">
    <div class="rpthead">
        <div class="rptfilter">
            <table style="width: 100%">
                <tr>
                    <td style="width: 150px">
                        Building/ Zone
                    </td>
                    <td style="width: 200px">
                        Floor Level
                    </td>
                    <td id="tdPcd_01" runat="server" style="width: 150px">
                        Planned reference date
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
                        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
                        <asp:DropDownList ID="drbzone" runat="server" Width="100%" OnSelectedIndexChanged="drbzone_SelectedIndexChanged">
                        </asp:DropDownList>
                        <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
                    </td>
                    <td>
                        <%--<asp:UpdatePanel ID="UpdatePanel9" runat="server">
            <ContentTemplate>--%>
                        <asp:DropDownList ID="drflevel" runat="server" Width="100%" OnSelectedIndexChanged="drflevel_SelectedIndexChanged">
                        </asp:DropDownList>
                        <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
                    </td>
                    <td id="tdPcd_02" runat="server">
                        <asp:TextBox ID="txtpcddate" runat="server" Text="" Width="150px" ReadOnly="true">
                        </asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender391" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                            PopupButtonID="txtpcddate" TargetControlID="txtpcddate">
                        </asp:CalendarExtender>
                    </td>
                    <td>
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
                    HasCrystalLogo="False" HasToggleGroupTreeButton="False" ToolPanelView="None" />
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
        $(document).ready(function() {       
            var mode = document.getElementById('<%= lblmode.ClientID %>').innerText;
            var prj = document.getElementById('<%= lblprj.ClientID %>').innerText;
            if (mode == '9' && prj == 'PCD')  SetCurrentDate();

        });
        function SetCurrentDate() {
            var tdate = new Date();
            var dd = tdate.getDate(); //yields day
            var MM = tdate.getMonth(); //yields month
            var yyyy = tdate.getFullYear(); //yields year
            var xxx = dd + "/" + (MM + 1) + "/" + yyyy;
            document.getElementById("txtpcddate").value = xxx;
        }
        function setGen() {

            var mvalue = document.getElementById("txtpcddate").value;
            document.getElementById("hdnpcd").value = mvalue;

        }
    </script>

</body>
</html>
