<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="CmlTechniques.CMS.Reports" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CML Techniques | Reports</title>

    <script type="text/javascript">

        function pageLoad() {
        }
        function goback() {

            var index = document.getElementById('<%=lblindex.ClientID%>').innerHTML;

            parent.document.getElementById("content").src = "cmsreports.aspx?idx=" + index;
        }
    
    </script>

    <link href="../page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="lblindex" runat="server" Text="" Style="display: none"></asp:Label>
    <asp:Label ID="lblprj" runat="server" Text="" Style="display: none"></asp:Label>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="rpthead" id="mydiv" runat="server">
        <div class="rptfilter">
            <table style="width: 100%">
                <tr>
                    <td style="width: 900px">
                        <table id="filter_tbl" runat="server">
                            <tr>
                                <td style="width: 200px">
                                    SERVICE
                                </td>
                                <td style="width: 200px">
                                    PACKAGE
                                </td>
                                <td style="width: 200px">
                                    DOC.TYPE
                                </td>
                                <td style="width: 70px" rowspan="2" valign="middle">
                                    <asp:Label ID="lblid" runat="server" Style="display: none"></asp:Label>
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btngenerate" runat="server" Text="View" Width="70px" Height="30px" CssClass="comment-btn"
                                                OnClick="btngenerate_Click" ToolTip="View Summary" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="drservices" runat="server" Width="100%" AutoPostBack="true"
                                                OnSelectedIndexChanged="drservices_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="drpackages" runat="server" Width="100%">
                                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="drtype" runat="server" Width="100%">
                                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                            
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="70px" align="center">
                        &nbsp;
                    </td>
                    <td width="70px" align="right" id="tdback" runat="server" valign="middle" >
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnback" runat="server" Text="Back" Width="70px" Height="30px" 
                                    CssClass="comment-btn" ToolTip="Back to Previous" 
                                    onclick="btnback_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div>
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                    HasCrystalLogo="False" HasToggleGroupTreeButton="False" ToolPanelView="None" />
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
