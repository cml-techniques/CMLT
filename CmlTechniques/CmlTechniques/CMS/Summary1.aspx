<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Summary1.aspx.cs" Inherits="CmlTechniques.CMS.Summary1" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <meta http-equiv="X-UA-Compatible" content="IE=9" />

    <script type="text/javascript">

        function pageLoad() {
        }
        function goback() {
            parent.document.getElementById("content").src = "cmsreports.aspx?idx=1";
        }

    </script>

    <link href="../page.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ResizeWidth() {
            var width = $("#viewer").width() + "px";
            var height = $("#viewer").height() + "px";
            $("#CrystalReportViewer1").width(width);
            $("#CrystalReportViewer1").height(height);
            var width1 = $("#CrystalReportViewer1").width();
            alert(width1);
        }
    </script>
       <link href="CrystalStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
   
        <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblsch" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblsch1" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lbldiv" runat="server" Text="" CssClass="hidden"></asp:Label>
        
        <div class="rpthead">
            <div class="rptfilter">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 150px">
                            Building/ Zone
                        </td>
                        <td style="width: 150px">
                            Category
                        </td>
                        <td style="width: 150px">
                            Floor Level
                        </td>
                        <td style="width: 150px">
                            Fed From
                        </td>
                        <td style="width: 150px">
                            Location
                        </td>
                        <td style="width: 150px">
                            Summary Type
                        </td>
                        <td rowspan="2" width="70px"  align="left" valign="bottom">
                            <%-- <asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <ContentTemplate>--%>
                            <asp:Button ID="btngenerate" runat="server" Text="Generate" Width="70px" Height="30px"  OnClick="btngenerate_Click"
                                CssClass="comment-btn" ToolTip="View Summary" />
                            <%-- </ContentTemplate>--%>
                            <%-- <Triggers >
            <asp:PostBackTrigger ControlID="btngenerate" />
            </Triggers>--%>
                            <%-- </asp:UpdatePanel>--%>
                        </td>
                        <td rowspan="2" width="70px" align="right" id="tdback" runat="server" valign="bottom">
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                            <asp:Button ID="btnback" runat="server" Text="Back" Width="70px" Height="30px"
                                CssClass="comment-btn" ToolTip="Back to Previous" onclick="btnback_Click" />
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="drbuilding" runat="server" Width="100%" >
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="drcategory" runat="server" Width="100%" >
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="drflevel" runat="server" Width="100%" >
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="drfed" runat="server" Width="100%" >
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="drloc" runat="server" Width="100%"  >
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="drtype" runat="server" Width="100%" >
                                        
                                        <asp:ListItem Value="1">Package Basis</asp:ListItem>
                                        <asp:ListItem Value="2">Building Basis</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div   >
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                    <%-- <asp:Timer ID="Timer1" runat="server" Interval="10000" OnTick="TimerTick" >
                </asp:Timer>--%>
                    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                        HasCrystalLogo="False" HasToggleGroupTreeButton="False" ToolPanelView="None" />
                    <%--<asp:Image ID="imgLoader" runat="server" ImageUrl="../images/loading45.gif" Height="100px" Width="100px" style="top:40%;left: 45%;position:absolute;" />--%>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="CrystalReportViewer1" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
  
    <div id="myprogress" runat="server" style="position: absolute; z-index: 40; top: 30%;
        left: 35%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                    Width="250px" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    </form>
</body>
</html>
