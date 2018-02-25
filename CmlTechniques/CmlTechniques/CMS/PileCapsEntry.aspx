<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PileCapsEntry.aspx.cs"
    Inherits="CmlTechniques.CMS.PileCapsEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="main_container">
        <asp:Label ID="lblsch" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lbluid" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label>
        <div class="page-header">
            <table style="width: 100%; background-color: #353535; color: #f9f9f9;margin-bottom:2px;">
                <tr>
                    <td width="150px" style="padding-left: 10px">
                        <asp:Label ID="lblhead" runat="server" Font-Bold="True" Font-Size="Medium" Text="Pile Caps"
                            Width="100px"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                            <ContentTemplate>
                                <asp:ImageButton ID="btnrefresh" runat="server" ImageUrl="~/images/refresh1.png"
                                    CssClass="hidden" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td width="90%" align="right">
                        <table>
                            <tr>
                                <td style="width: 100px" align="center">
                                    &nbsp;
                                </td>
                                <td style="width: 200px">
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnimport" runat="server" Text="Import" Width="75px" OnClick="btnimport_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnprint" runat="server" Text="Print" Width="75px" OnClick="btnprint_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnedit" runat="server" Text="Edit" Width="75px" OnClick="btnedit_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btndelete1" runat="server" Text="Delete" Width="75px" OnClick="btndelete1_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table class="table-style" border="0" cellpadding="0" cellspacing="0">
                <tr class="head">
                <td style="width: 25px;">
                </td>
                    <td style="width: 50px; text-align: center;">
                        S.I
                    </td>
                    <td style="width: 100px">
                        PILE NO
                    </td>
                    <td style="width: 150px">
                        Zone
                    </td>
                    <td style="width: 75px">
                        OHMS
                    </td>
                    <td style="width: 75px">
                        WIR
                    </td>
                    <td style="width: 100px; text-align: center;">
                        Date
                    </td>
                    <td style="width: 100px; text-align: center;">
                        Status
                    </td>
                    <td style="width: 100px">
                        Accepted
                    </td>
                    <td style="width: 200px">
                        Comments
                    </td>
                </tr>
                <tr class="action">
                    <%--<td >
                    </td>--%>
                    <td style="width: 75px" colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnadd" runat="server" Text="Add" Width="99%" OnClick="btnadd_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txt_pno" runat="server" CssClass="textstyle" Style="width: 99%"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txt_zone" runat="server" CssClass="textstyle" Style="width: 99%"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txt_ohms" runat="server" CssClass="textstyle" Style="width: 99%"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txt_wir" runat="server" CssClass="textstyle" Style="width: 99%"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txt_date" runat="server" CssClass="textstyle" Style="width: 99%"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender6" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="txt_date" TargetControlID="txt_date">
                                </asp:CalendarExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txt_status" runat="server" CssClass="textstyle" Style="width: 99%"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txt_accepted" runat="server" CssClass="textstyle" Style="width: 99%"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="txt_accepted" TargetControlID="txt_accepted">
                                </asp:CalendarExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txt_comments" runat="server" CssClass="textstyle" Style="width: 99%"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div class="content_box">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Repeater ID="rptdetails" runat="server" OnItemDataBound="rptdetails_ItemDataBound">
                        <HeaderTemplate>
                            <table id="repeaterTable1" class="table-style" border="0" cellpadding="0" cellspacing="0">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="row">
                                <td style="width: 25px">
                                    <asp:CheckBox ID="chkrow1" runat="server" />
                                </td>
                                <td style="width: 50px; text-align: center;">
                                    <asp:Label ID="lblsl" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblcasid" runat="server" Text='<%# Eval("C_id")%>' Style="display: none"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <%# Eval("E_b_ref")%>
                                </td>
                                <td style="width: 150px">
                                    <%# Eval("B_Z")%>
                                </td>
                                <td style="width: 75px">
                                    <%# Eval("Des")%>
                                </td>
                                <td style="width: 75px">
                                    <%# Eval("Loc")%>
                                </td>
                                <td style="width: 100px; text-align: center;">
                                    <%# Eval("P_P_to")%>
                                </td>
                                <td style="width: 100px; text-align: center;">
                                    <%# Eval("F_from")%>
                                </td>
                                <td style="width: 100px">
                                    <%# Eval("Substation")%>
                                </td>
                                <td style="width: 200px; text-align: left">
                                    <%# Eval("S_c_m")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="arow">
                                <td style="width: 25px">
                                    <asp:CheckBox ID="chkrow1" runat="server" />
                                </td>
                                <td style="width: 50px; text-align: center;">
                                    <asp:Label ID="lblsl" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblcasid" runat="server" Text='<%# Eval("C_id")%>' Style="display: none"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <%# Eval("E_b_ref")%>
                                </td>
                                <td style="width: 150px">
                                    <%# Eval("B_Z")%>
                                </td>
                                <td style="width: 75px">
                                    <%# Eval("Des")%>
                                </td>
                                <td style="width: 75px">
                                    <%# Eval("Loc")%>
                                </td>
                                <td style="width: 100px; text-align: center;">
                                    <%# Eval("P_P_to")%>
                                </td>
                                <td style="width: 100px; text-align: center;">
                                    <%# Eval("F_from")%>
                                </td>
                                <td style="width: 100px">
                                    <%# Eval("Substation")%>
                                </td>
                                <td style="width: 200px; text-align: left">
                                    <%# Eval("S_c_m")%>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <asp:Panel ID="pnlPopup" runat="server" Width="400px" Style="padding: 15px; background-color: #83C8EE;
        display: none;">
        <div>
            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                <ContentTemplate>
                    <div>
                        <table style="width: 400px; background-color: White;" cellpadding="3px">
                            <tr>
                                <td width="100px">
                                    PILE NO
                                </td>
                                <td width="400px">
                                    <asp:TextBox ID="upreff" runat="server" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    ZONE
                                </td>
                                <td>
                                    <asp:TextBox ID="upzone" runat="server" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    OHMS
                                </td>
                                <td>
                                    <asp:TextBox ID="upohms" runat="server" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    WIR
                                </td>
                                <td>
                                    <asp:TextBox ID="upwir" runat="server" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    DATE
                                </td>
                                <td>
                                    <asp:TextBox ID="update" runat="server" Width="150px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                        PopupButtonID="update" TargetControlID="update">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr id="tr0" runat="server">
                                <td >
                                    STATUS
                                </td>
                                <td>
                                    <asp:TextBox ID="upstatus" runat="server" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    ACCEPTED
                                </td>
                                <td>
                                    <asp:TextBox ID="upaccepted" runat="server" Width="150px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                        PopupButtonID="upaccepted" TargetControlID="upaccepted">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr id="tr2" runat="server">
                                <td >
                                    COMMENTS
                                </td>
                                <td>
                                    <asp:TextBox ID="upcomment" runat="server" Width="300px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblupcid" runat="server" Text="0" Style="display: none"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" TargetControlID="btnDummy"
        PopupControlID="pnlPopup" BackgroundCssClass="model-background">
    </asp:ModalPopupExtender>
    </form>
</body>
</html>
