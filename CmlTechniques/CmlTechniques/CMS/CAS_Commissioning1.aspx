<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CAS_Commissioning1.aspx.cs"
    Inherits="CmlTechniques.CMS.CAS_Commissioning1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">

        function pageLoad() {
        }
    
    </script>
    <script src="../Assets/js/jquery.min.js" type="text/javascript"></script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .tdstyle1
        {
            width: 90px;
            font-size: x-small;
            color: #FF0000;
        }
        .tdstyle2
        {
            width: 90px;
            font-size: x-small;
            color: #FF0000;
        }
        .tdstyle3
        {
            width: 90px;
            font-size: x-small;
            color: #FF0000;
        }
        .tdstyle4
        {
            width: 110px;
            font-size: x-small;
            color: #FF0000;
        }
        .tdstyle5
        {
            width: 110px;
            font-size: x-small;
            color: #FF0000;
        }
        .tdstyle6
        {
            width: 110px;
            font-size: x-small;
            color: #FF0000;
        }
        .tdstyle7
        {
            width: 193px;
            font-size: x-small;
            color: #FF0000;
        }
        .tdstyle8
        {
            width: 189px;
            font-size: x-small;
            color: #FF0000;
        }
        .tdstyle9
        {
            width: 162px;
            font-size: x-small;
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: verdana; font-size: x-small; height: 100%; position: fixed;
        width: 100%">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:Label ID="Label1" runat="server" Text="Label" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblprj" runat="server" Text="Label" CssClass="hidden"></asp:Label>
        <asp:Label ID="lbluid" runat="server" Text="Label" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblsch" runat="server" Text="Label" CssClass="hidden"></asp:Label>
        <asp:Label ID="lbldiv" runat="server" Text="Label" CssClass="hidden"></asp:Label>
        <table style="width: 100%; color: White" bgcolor="#092443">
            <tr>
                <td width="100px">
                    &nbsp;
                </td>
                <td width="100%">
                    <asp:Label ID="lblhead" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
        </table>
        <div style="float: left; width: 98.5%">
            <table style="font-family: Verdana; font-size: x-small; background-color: #9EB6CE;
                width: 100%;" cellspacing="1" border="0">
                <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                    <td align="center" rowspan="2" valign="middle" width="6%">
                        &nbsp;
                    </td>
                    <td align="center" rowspan="2" valign="middle" width="6%">
                        ITEM NO
                    </td>
                    <td align="center" rowspan="2" valign="middle" width="10%">
                        ENG.REF
                    </td>
                    <td align="center" colspan="4" valign="middle">
                        ASSET CODE
                    </td>
                    <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbldes" runat="server">
                        <asp:Label ID="lbldes" runat="server" Text="DESCRIPTION"></asp:Label>
                    </td>
                    <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbl0" runat="server">
                        <asp:Label ID="lbloc" runat="server" Text="LOCATION"></asp:Label>
                    </td>
                    <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbl3" runat="server">
                        <asp:Label ID="lbl3" runat="server"></asp:Label>
                    </td>
                    <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbl1" runat="server">
                        <asp:Label ID="lbl1" runat="server"></asp:Label>
                    </td>
                    <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbl2" runat="server">
                        <asp:Label ID="lbl2" runat="server"></asp:Label>
                    </td>
                    <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbnum" runat="server">
                        <asp:Label ID="lbnum" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                    <td align="center" valign="middle" width="7%">
                        BUILDING/ ZONE
                    </td>
                    <td align="center" valign="middle" width="7%">
                        CATEGORY
                    </td>
                    <td align="center" valign="middle" width="7%">
                        FLOOR LEVEL
                    </td>
                    <td align="center" valign="middle" width="7%">
                        SEQ.NO
                    </td>
                </tr>
                <tr bgcolor="#092443">
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnexpand" runat="server" Text="Exp.All" Width="100%" OnClick="btnexpand_Click"
                                    ForeColor="Red" Font-Size="X-Small" Style="cursor: pointer" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btncollapse" runat="server" Text="Coll.All" Width="100%" ForeColor="Red"
                                    Font-Size="X-Small" Style="cursor: pointer" OnClick="btncollapse_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="drbuilding" runat="server" Width="100%" OnSelectedIndexChanged="drbuilding_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="drcategory" runat="server" Width="100%" OnSelectedIndexChanged="drcategory_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="drflevel" runat="server" Width="100%" OnSelectedIndexChanged="drflevel_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td id="td_txtdescr" runat="server">
                        &nbsp;
                    </td>
                    <td id="td0" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="drloc" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="drloc_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td id="td_1" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="drfed" runat="server" Width="100%" OnSelectedIndexChanged="drfed_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td id="td_0" runat="server">
                        &nbsp;
                    </td>
                    <td id="td_2" runat="server">
                        &nbsp;
                    </td>
                    <td id="td_3" runat="server">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div style="position: relative; height: 75%; overflow-y: scroll; float: left; width: 100%;">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="mymaster" runat="server" AutoGenerateColumns="False" Width="100%"
                        OnRowDataBound="mymaster_RowDataBound" Font-Names="Verdana" Font-Size="X-Small"
                        ShowHeader="False" GridLines="None">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table id="inner_table" width="100%">
                                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                                            <td style="width: 50px">
                                                <asp:Button ID="Button1" runat="server" Text="-" CommandArgument="Button1" OnClick="Button1_Click"
                                                    Width="30px" Style="cursor: pointer" />
                                            </td>
                                            <td style="font-weight: bold; width: 100%" align="left">
                                                <asp:Label ID="lbSys_Name" runat="server" Text='<%# Eval("Sys_Name") %>' Width="300px"></asp:Label>
                                                <asp:Label ID="lbSys_Id" runat="server" Text='<%# Eval("Sys_Id") %>' Style="display: none"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>--%>
                                                <asp:GridView ID="mydetails" runat="server" ShowHeader="false" AutoGenerateColumns="false"
                                                    Width="100%" OnRowCommand="mydetails_RowCommand" OnRowDataBound="mydetails_RowDataBound"
                                                    Font-Names="Verdana" Font-Size="X-Small">
                                                    <Columns>
                                                        <asp:ButtonField ButtonType="Button" Text="Update" CommandName="Get" ItemStyle-Width="6%">
                                                            <ItemStyle Width="6%" />
                                                        </asp:ButtonField>
                                                        <asp:BoundField HeaderText="Itm.No" ItemStyle-Width="6%">
                                                            <ItemStyle Width="6%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="E_b_ref" HeaderText="Engg.Reff" ItemStyle-Width="10%">
                                                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="B_Z" HeaderText="Building/Zone" ItemStyle-Width="7%">
                                                            <ItemStyle Width="7%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="cat" HeaderText="Category" ItemStyle-Width="7%">
                                                            <ItemStyle Width="7%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="F_lvl" HeaderText="Floor Level" ItemStyle-Width="7%">
                                                            <ItemStyle Width="7%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Seq_No" HeaderText="Seq.No" ItemStyle-Width="7%">
                                                            <ItemStyle Width="7%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Des" HeaderText="Substation" ItemStyle-Width="10%">
                                                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Loc" HeaderText="Location" ItemStyle-Width="10%">
                                                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="F_from" HeaderText="Fed From" ItemStyle-Width="10%">
                                                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="P_P_to" HeaderText="Provides Power To" ItemStyle-Width="10%">
                                                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Substation" HeaderText="Substation" ItemStyle-Width="10%">
                                                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="devices1" ItemStyle-Width="10%">
                                                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="C_id" />
                                                        <asp:BoundField DataField="Sys_Id" />
                                                        <asp:BoundField DataField="Sys_Name" />
                                                        <asp:BoundField DataField="type" />
                                                    </Columns>
                                                </asp:GridView>
                                                <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
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
    </div>
    <asp:CheckBox ID="CheckBox1" runat="server" />
    <asp:CheckBox ID="CheckBox2" runat="server" />
    <asp:Panel ID="pnlPopup3_trans" runat="server" Width="825px" Height="350px" Style="padding: 15px;"
        BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 825px" border="0" cellpadding="3" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_3lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td width="200px">
                                PLANNED POWER ON
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_3pwron" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_3pwron','_3pwron')"
                                    runat="server" />
                            </td>
                            <td width="75px">
                                <asp:TextBox ID="_3pwron" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender118" runat="server" TargetControlID="_3pwron"
                                    PopupButtonID="_3pwron" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200px">
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td width="75px">
                                &nbsp;
                            </td>
                            <td width="200px">
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td width="75px">
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="9" align="center">
                                TRANSFORMER TESTING
                            </td>
                        </tr>
                        <tr>
                            <td>
                                PLANNED COMPLETION
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_3txp" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_3txp','_3transformerplanned')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_3transformerplanned" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender147" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_3transformerplanned" TargetControlID="_3transformerplanned">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                IR TEST
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_3ir" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_3ir','_3ir');Trans_PlannedNA();"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_3ir" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender119" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_3ir" TargetControlID="_3ir">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                RATIO TEST
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_3rt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_3rt','_3rt');Trans_PlannedNA();"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_3rt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender136" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_3rt" TargetControlID="_3rt">
                                </asp:CalendarExtender>
                            </td>
                            <tr>
                                <td>
                                    WINDING RESISTANCE TEST
                                </td>
                                <td class="tdstyle1">
                                    N/A
                                    <input id="chk_3wr" runat="server" onclick="_checked('chk_3wr','_3wr');Trans_PlannedNA();"
                                        style="vertical-align: middle" type="checkbox" />
                                </td>
                                <td>
                                    <asp:TextBox ID="_3wr" runat="server" Width="75px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender137" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                        PopupButtonID="_3wr" TargetControlID="_3wr">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    VECTOR GROUP TEST
                                </td>
                                <td class="tdstyle1">
                                    N/A
                                    <input id="chk_3vg" runat="server" onclick="_checked('chk_3vg','_3vg');Trans_PlannedNA();"
                                        style="vertical-align: middle" type="checkbox" />
                                </td>
                                <td>
                                    <asp:TextBox ID="_3vg" runat="server" Width="75px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender138" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                        PopupButtonID="_3vg" TargetControlID="_3vg">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    TEMP. RELAY FUNCTIONAL TEST
                                </td>
                                <td class="tdstyle1">
                                    N/A
                                    <input id="chk_3trf" runat="server" onclick="_checked('chk_3trf','_3trf');Trans_PlannedNA();"
                                        style="vertical-align: middle" type="checkbox" />
                                </td>
                                <td>
                                    <asp:TextBox ID="_3trf" runat="server" Width="75px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender139" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                        PopupButtonID="_3trf" TargetControlID="_3trf">
                                    </asp:CalendarExtender>
                                </td>
                                <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                                    <td>
                                        CONSULTANT ACCEPTED
                                    </td>
                                    <td class="tdstyle1">
                                        N/A
                                        <input id="chk_3accept1" runat="server" onclick="_checked('chk_3accept1','_3accept1')"
                                            style="vertical-align: middle" type="checkbox" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="_3accept1" runat="server" Width="75px"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender140" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                            PopupButtonID="_3accept1" TargetControlID="_3accept1">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td>
                                        TEST SHEETS FILED
                                    </td>
                                    <td class="tdstyle1" valign="middle">
                                        N/A
                                        <input id="chk_3filed1" runat="server" onclick="_checked('chk_3filed1','_3filed1')"
                                            style="vertical-align: middle" type="checkbox" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="_3filed1" runat="server" Width="75px"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender141" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                            PopupButtonID="_3filed1" TargetControlID="_3filed1">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td class="tdstyle1">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr style="background-color: #092443; color: White">
                                    <td align="center" colspan="9">
                                        CABLE TEST
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        PLANNED COMPLETION
                                    </td>
                                    <td class="tdstyle1">
                                        N/A
                                        <input id="chk_3cableplanned" runat="server" onclick="_checked('chk_3cableplanned','_3cableplanned')"
                                            style="vertical-align: middle" type="checkbox" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="_3cableplanned" runat="server" Width="75px"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender160" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                            PopupButtonID="_3cableplanned" TargetControlID="_3cableplanned">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td>
                                        CABLE IR AND HI POT
                                    </td>
                                    <td class="tdstyle1">
                                        N/A
                                        <input id="chk_3cable" runat="server" onclick="_checked('chk_3cable','_3cable');Trans_PlannedNA()"
                                            style="vertical-align: middle" type="checkbox" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="_3cable" runat="server" Width="75px"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender143" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                            PopupButtonID="_3cable" TargetControlID="_3cable">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <caption>
                                    &nbsp;</caption>
                                <tr>
                                    <td class="tdstyle1">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                                    <td>
                                        CONSULTANT ACCEPTED
                                    </td>
                                    <td class="tdstyle1">
                                        N/A
                                        <input id="chk_3accept2" runat="server" onclick="_checked('chk_3accept2','_3accept2')"
                                            style="vertical-align: middle" type="checkbox" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="_3accept2" runat="server" Width="75px"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender144" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                            PopupButtonID="_3accept2" TargetControlID="_3accept2">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td>
                                        TEST SHEETS FILED
                                    </td>
                                    <td class="tdstyle1">
                                        N/A
                                        <input id="chk_3filed2" runat="server" onclick="_checked('chk_3filed2','_3filed2')"
                                            style="vertical-align: middle" type="checkbox" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="_3filed2" runat="server" Width="75px"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender145" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                            PopupButtonID="_3filed2" TargetControlID="_3filed2">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td class="tdstyle1">
                                        &nbsp;&nbsp;
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr style="background-color: #83C8EE">
                                    <td>
                                        ACTION BY&nbsp;
                                    </td>
                                    <td class="tdstyle1">
                                        N/A
                                        <input id="chk_3actby" runat="server" onclick="_checked('chk_3actby','_3actby')"
                                            style="vertical-align: middle" type="checkbox" />
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="_3actby" runat="server" Width="250px"></asp:TextBox>
                                    </td>
                                    <td class="tdstyle1">
                                    </td>
                                    <td>
                                        COMMENTS
                                    </td>
                                    <td colspan="3" rowspan="2">
                                        <asp:TextBox ID="_3commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="background-color: #83C8EE">
                                    <td>
                                        ACTION DATE
                                    </td>
                                    <td class="tdstyle1">
                                        N/A
                                        <input id="chk_3actdt" runat="server" onclick="_checked('chk_3actdt','_3actdt')"
                                            style="vertical-align: middle" type="checkbox" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="_3actdt" runat="server" Width="75px"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender146" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                            PopupButtonID="_3actdt" TargetControlID="_3actdt">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td class="tdstyle1">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td class="tdstyle1">
                                        &nbsp;
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="_3btnupdate" runat="server" OnClick="_3btnupdate_Click" Text="Update" />
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="_3btncancel" runat="server" OnClick="_3btncancel_Click" Text="Cancel" />
                                    </td>
                                    <td align="left" class="tdstyle1">
                                        &nbsp;
                                    </td>
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                    <td>
                                    </td>
                                    <td class="tdstyle1">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div8" runat="server" style="position: absolute; z-index: 40; top: 30%; left: 35%">
                <asp:UpdateProgress ID="UpdateProgress3" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload2" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy_trans" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender3_trans" runat="server" TargetControlID="btnDummy_trans"
        PopupControlID="pnlPopup3_trans" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>


            <asp:Panel ID="pnlPopup2_hvmv" runat="server" Width="835px" Height="415px" Style="padding: 15px;"
        BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 825px" border="0" cellpadding="3" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_2lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td width="200px">
                                PLANNED POWER ON
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_2pwron" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_2pwron', '_2pwron')"
                                    runat="server" />
                            </td>
                            <td width="75px">
                                <asp:TextBox ID="_2pwron" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender_2pwron" runat="server" TargetControlID="_2pwron"
                                    PopupButtonID="_2pwron" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200px">
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td width="75px">
                                &nbsp;
                            </td>
                            <td width="200px">
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td width="75px">
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="9" align="center">
                                PANEL / EQUIPMENT TESTING
                            </td>
                        </tr>
                        <tr id="tr1" runat="server">
                            <td>
                                PLANNED COMPLETION
                            </td>
                            <td class="tdstyle1">
                                N/A&nbsp;
                                <input id="chk_2pt" runat="server" onclick="_checked('chk_2pt', 'txtpanelplanned');"
                                    style="vertical-align: middle" type="checkbox" value="N/A" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtpanelplanned" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender117" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="txtpanelplanned" TargetControlID="txtpanelplanned">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TORQUE TEST
                            </td>
                            <td class="tdstyle1">
                                N/A&nbsp;
                                <input id="chk_2tor" runat="server" onclick="_checked('chk_2tor', '_2tor'); HVMV_PlannedNA();"
                                    style="vertical-align: middle" type="checkbox" value="N/A" />
                            </td>
                            <td>
                                <asp:TextBox ID="_2tor" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="date2_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_2tor" TargetControlID="_2tor">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                IR TEST
                            </td>
                            <td class="tdstyle1">
                                N/A&nbsp;
                                <input id="chk_2ir" runat="server" onclick="_checked('chk_2ir', '_2ir'); HVMV_PlannedNA();"
                                    style="vertical-align: middle" type="checkbox" value="n/a" />
                            </td>
                            <td>
                                <asp:TextBox ID="_2ir" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_2ir_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_2ir" TargetControlID="_2ir">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr id="tr2" runat="server">
                            <td>
                                HI POT TEST
                            </td>
                            <td class="tdstyle1">
                                N/A&nbsp;
                                <input id="chk_2hi" runat="server" onclick="_checked('chk_2hi', '_2hi'); HVMV_PlannedNA();"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td>
                                <asp:TextBox ID="_2hi" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="date4_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_2hi" TargetControlID="_2hi">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                VT TEST
                            </td>
                            <td class="tdstyle1">
                                N/A&nbsp;
                                <input id="chk_2vt" runat="server" onclick="_checked('chk_2vt', '_2vt'); HVMV_PlannedNA();"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td>
                                <asp:TextBox ID="_2vt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="date5_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_2vt" TargetControlID="_2vt">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                CT TEST
                            </td>
                            <td class="tdstyle1">
                                N/A&nbsp;
                                <input id="chk_2ct" runat="server" onclick="_checked('chk_2ct', '_2ct'); HVMV_PlannedNA();"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td>
                                <asp:TextBox ID="_2ct" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="date6_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_2ct" TargetControlID="_2ct">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr id="tr3" runat="server">
                            <td>
                                PRIMARY INJECTION TEST
                            </td>
                            <td class="tdstyle1">
                                N/A&nbsp;
                                <input id="chk_2pi" runat="server" onclick="_checked('chk_2pi', '_2pi'); HVMV_PlannedNA();"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td>
                                <asp:TextBox ID="_2pi" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="date7_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_2pi" TargetControlID="_2pi">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                SECONDARY INJECTION
                            </td>
                            <td class="tdstyle1">
                                N/A&nbsp;
                                <input id="chk_2si" runat="server" onclick="_checked('chk_2si', '_2si'); HVMV_PlannedNA();"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td>
                                <asp:TextBox ID="_2si" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="date15_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_2si" TargetControlID="_2si">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                DUCTOR TEST
                            </td>
                            <td class="tdstyle1">
                                N/A&nbsp;
                                <input id="chk_2cr" runat="server" onclick="_checked('chk_2cr', '_2cr'); HVMV_PlannedNA();"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td>
                                <asp:TextBox ID="_2cr" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="date16_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_2cr" TargetControlID="_2cr">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr id="tr4" runat="server">
                            <td>
                                FUNCTIONAL TEST
                            </td>
                            <td class="tdstyle1">
                                N/A&nbsp;
                                <input id="chk_2fn" runat="server" onclick="_checked('chk_2fn', '_2fn'); HVMV_PlannedNA();"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td>
                                <asp:TextBox ID="_2fn" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="date14_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_2fn" TargetControlID="_2fn">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                PROTECTIVE RELAY FINAL TEST
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_2pr" runat="server" onclick="_checked('chk_2pr', '_2pr'); HVMV_PlannedNA();"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td>
                                <asp:TextBox ID="_2pr" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="date18_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_2pr" TargetControlID="_2pr">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_2accept1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_2accept1', '_2accept1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_2accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="test12_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_2accept1" TargetControlID="_2accept1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_2filed1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_2filed1', '_2filed1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_2filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtendertxt" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_2filed1" TargetControlID="_2filed1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="9" align="center">
                              22 / 11 KV HV CABLE TEST
                            </td>
                        </tr>
                        <tr id="tr7" runat="server">
                            <td>
                                PLANNED COMPLETION
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_2cp" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_2cp', 'txtcableplanned');"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtcableplanned" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender_txtcableplanned" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="txtcableplanned" TargetControlID="txtcableplanned">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                              NO. OF CABLES
                            </td>
                            <td class="tdstyle1">
                               N/A
                                <input id="chk_2noc" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_2noc', '_2noc')"
                                    runat="server" /> 
                            </td>
                            <td>
                                 <asp:TextBox ID="_2noc" runat="server" Width="75px"></asp:TextBox> 
                            </td>
                            <td>
                                CABLE IR AND HI POT
                            </td>
                            <td class="tdstyle1">
                               N/A
                                <input id="chk_2cable" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_2cable', '_2cable'); _checked('chk_2cable', 'txtcableplanned'); HVMV_PlannedNACable();"
                                    runat="server" />
                            </td>
                            <td>
                               <asp:TextBox ID="_2cable" runat="server" Width="75px"></asp:TextBox> 
                            </td>
                        </tr>
                              <tr id="tr_2ttt" runat="server">
                            <td>
                               TERMINATION TORQUE TEST
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_2ttt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_2ttt', '_2ttt'); HVMV_PlannedNACable();"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_2ttt" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                CABLE TEST COMPLETE
                            </Td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_2cte" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_2cte', '_2cte'); _checked('chk_2cable', 'txtcableplanned')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_2cte" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender176" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_2cte" TargetControlID="_2cte">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_2accept2" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_2accept2', '_2accept2')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_2accept2" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="test13_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_2accept2" TargetControlID="_2accept2">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_2filed2" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_2filed2', '_2filed2')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_2filed2" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="actdate0_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_2filed2" TargetControlID="_2filed2">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_2actby" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_2actby', '_2actby')"
                                    runat="server" />
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_2actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_2commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_2actdt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_2actdt', '_2actdt')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_2actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="date22_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_2actdt" TargetControlID="_2actdt">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="_2btnupdate" runat="server" Text="Update" OnClick="_2btnupdate_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="_2btncancel" runat="server" Text="Cancel" OnClick="_2btncancel_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" class="tdstyle1">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="myprogress1" runat="server" style="position: absolute; z-index: 40; top: 30%;
                left: 35%">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload1" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnModalPopupExtender_hvmv" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender2_hvmv" runat="server" TargetControlID="btnModalPopupExtender_hvmv"
        PopupControlID="pnlPopup2_hvmv" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>


    <asp:Panel ID="pnlPopup4" runat="server" Width="825px" Height="400px" Style="padding: 15px;
        display: none" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 825px" border="0" cellpadding="3" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_5lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td width="200px">
                                Planned Power On
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_5pwron" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_5pwron','_5pwron')"
                                    runat="server" />
                            </td>
                            <td width="75px">
                                <asp:TextBox ID="_5pwron" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender30" runat="server" TargetControlID="_5pwron"
                                    PopupButtonID="_5pwron" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200px">
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td width="75px">
                                &nbsp;
                            </td>
                            <td width="200px">
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td width="75px">
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="9" align="center">
                                PANEL / EQUIPMENT TESTING
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                Panel Test Planned
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_5ptp" runat="server" onclick="_checked('chk_5ptp','_5ptp')" style="vertical-align: middle"
                                    type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_5ptp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_5tor0_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_5ptp" TargetControlID="_5ptp">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                Torque Test
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_5tor" runat="server" onclick="_checked('chk_5tor','_5tor');LV_PlannedNA1();"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_5tor" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender9" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_5tor" TargetControlID="_5tor">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                IR Test
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_5ir" runat="server" onclick="_checked('chk_5ir','_5ir');LV_PlannedNA1();"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:CalendarExtender ID="CalendarExtender18" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_5ir" TargetControlID="_5ir">
                                </asp:CalendarExtender>
                                <asp:TextBox ID="_5ir" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                HI Pot Test
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_5pr" runat="server" onclick="_checked('chk_5pr','_5pr');LV_PlannedNA1();"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:CalendarExtender ID="CalendarExtender19" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_5pr" TargetControlID="_5pr">
                                </asp:CalendarExtender>
                                <asp:TextBox ID="_5pr" runat="server" Width="75px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Secondary Injuction Test
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_5si" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_5si','_5si');LV_PlannedNA1();" />
                            </td>
                            <td>
                                <asp:TextBox ID="_5si" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender35" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_5si" TargetControlID="_5si">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                Contact Resistance
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_5cr" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_5cr','_5cr');LV_PlannedNA1();" />
                            </td>
                            <td>
                                <asp:TextBox ID="_5cr" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender36" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_5cr" TargetControlID="_5cr">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                Functional Test
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_5fn" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_5fn','_5fn');LV_PlannedNA1();" />
                            </td>
                            <td>
                                <asp:TextBox ID="_5fn" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender37" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_5fn" TargetControlID="_5fn">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                Consultant Accepted
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_5accept1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_5accept1','_5accept1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_5accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender20" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_5accept1" TargetControlID="_5accept1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                Test Sheets Filed
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_5filed1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_5filed1','_5filed1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_5filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender26" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_5filed1" TargetControlID="_5filed1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="9" align="center">
                                OUTGOING CIRCUIT TESTING
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Cold Test Planned
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_5ctp" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_5ctp','_5ctp')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_5ctp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_5tor1_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_5ctp" TargetControlID="_5ctp">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                Live Test Planned
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_5ltp" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_5ltp','_5ltp')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_5ltp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_5tor2_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_5ltp" TargetControlID="_5ltp">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Total No. Of Circuits
                            </td>
                            <td class="tdstyle1">
                                <td>
                                    <asp:TextBox ID="_5total" runat="server" ReadOnly="True" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    Total Cold Tested
                                </td>
                                <td class="tdstyle2">
                                    N/A
                                    <input id="chk_5tc" runat="server" onclick="_checked('chk_5tc','_5tc');LV_PlannedNA2();"
                                        style="vertical-align: middle" type="checkbox" />
                                </td>
                                <td>
                                    <asp:TextBox ID="_5tc" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    Cold Test Completed
                                </td>
                                <td class="tdstyle1">
                                    N/A
                                    <input id="chk_5cc" runat="server" onclick="_checked('chk_5cc','_5cc');_checked('chk_5cc','_5ctp');LV_PlannedNA2();;"
                                        style="vertical-align: middle" type="checkbox" />
                                </td>
                                <td>
                                    <asp:TextBox ID="_5cc" runat="server" Width="75px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender38" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                        PopupButtonID="_5cc" TargetControlID="_5cc">
                                    </asp:CalendarExtender>
                                </td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Total Live Tested
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_5tl" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_5tl','_5tl');LV_PlannedNA3();"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_5tl" runat="server" Width="75px" Text="0"></asp:TextBox>
                            </td>
                            <td>
                                Live Test Completed
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_5lc" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_5lc','_5lc');LV_PlannedNA3();"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_5lc" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender39" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_5lc" TargetControlID="_5lc">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                Consultant Accepted
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_5accept2" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_5accept2','_5accept2')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_5accept2" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender40" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_5accept2" TargetControlID="_5accept2">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                Test Sheets Files
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_5filed2" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_5filed2','_5filed2')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_5filed2" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender41" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_5filed2" TargetControlID="_5filed2">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                Action By
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_5actby" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_5actby','_5actby')"
                                    runat="server" />
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_5actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                Comment
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_5commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                Action Date
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_5actdt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_5actdt','_5actdt')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_5actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender29" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_5actdt" TargetControlID="_5actdt">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td class="tdstyle1">
                            </td>
                            <td align="right">
                                <asp:Button ID="_5btnupdate" runat="server" Text="Update" OnClick="_5btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_5btncancel" runat="server" Text="Cancel" OnClick="_5btncancel_Click" />
                            </td>
                            <td align="left" class="tdstyle2">
                            </td>
                            <td align="right">
                            </td>
                            <td>
                            </td>
                            <td class="tdstyle1">
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div3" runat="server" style="position: absolute; z-index: 40; top: 30%; left: 35%">
                <asp:UpdateProgress ID="UpdateProgress5" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload4" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy4" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender4" runat="server" TargetControlID="btnDummy4"
        PopupControlID="pnlPopup4" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup7" runat="server" Width="900px" Height="380px" Style="padding: 15px;
        display: none" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 900px" border="0" cellpadding="3" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_8lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td width="200px">
                                <asp:Label ID="lblppon" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="tdstyle8">
                            </td>
                            <td width="75px">
                                <asp:TextBox ID="_8pwron" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender66" runat="server" TargetControlID="_8pwron"
                                    PopupButtonID="_8pwron" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200px">
                                &nbsp;
                            </td>
                            <td class="tdstyle5">
                                <td width="75px">
                                    &nbsp;
                                </td>
                                <td width="200px">
                                </td>
                                <td class="tdstyle6">
                                    &nbsp;
                                </td>
                                <td width="75px">
                                </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="9" align="center">
                                MECHANICAL SYSTEMS
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PRE-COMM PLANNED
                            </td>
                            <td class="tdstyle8">
                                N/A
                                <input id="chk_8pcp" runat="server" onclick="_checked('chk_8pcp','_8pcp')" style="vertical-align: middle"
                                    type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_8pcp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_8pcp_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_8pcp" TargetControlID="_8pcp">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                COMM PLANNED
                            </td>
                            <td class="tdstyle5">
                                N/A
                                <input id="chk_8cp" runat="server" onclick="_checked('chk_8cp','_8cp')" style="vertical-align: middle"
                                    type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_8cp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_8cp_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_8cp" TargetControlID="_8cp">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle6">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr id="tradd1" runat="server">
                            <td width="200PX">
                                PRE-COMM
                            </td>
                            <td class="tdstyle8">
                                N/A
                                <input id="chk_8pc1" runat="server" onclick="_checked('chk_8pc1','_8pc1');mechPlannedPreCommNA()"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_8pc1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender54" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_8pc1" TargetControlID="_8pc1">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                COMM
                            </td>
                            <td class="tdstyle5">
                                N/A
                                <input id="chk_8co1" runat="server" onclick="_checked('chk_8co1','_8co1');mechPlannedCommNA()"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_8co1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender55" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_8co1" TargetControlID="_8co1">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle6">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                % DUTY
                            </td>
                            <td class="tdstyle8">
                                N/A
                                <input id="chk_8duty" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_8duty','_8duty')"
                                    runat="server" />
                            </td>
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_8duty" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                WITNESSED DATE
                            </td>
                            <td class="tdstyle5">
                                N/A
                                <input id="chk_8wd1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_8wd1','_8wd1')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_8wd1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender65" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_8wd1" TargetControlID="_8wd1">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle6">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle8">
                                N/A
                                <input id="chk_8accept1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_8accept1','_8accept1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_8accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender57" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_8accept1" TargetControlID="_8accept1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle5">
                                N/A
                                <input id="chk_8filed1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_8filed1','_8filed1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_8filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender58" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_8filed1" TargetControlID="_8filed1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle6">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="9" align="center">
                                CONTROLS
                            </td>
                        </tr>
                        <tr>
                            <td>
                                PRE-COMM&nbsp;
                            </td>
                            <td class="tdstyle8">
                                N/A
                                <input id="chk_8pc2" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_8pc2','_8pc2')" />
                            </td>
                            <td>
                                <asp:CalendarExtender ID="CalendarExtender60" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_8pc2" TargetControlID="_8pc2">
                                </asp:CalendarExtender>
                                <asp:TextBox ID="_8pc2" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                COMM
                            </td>
                            <td class="tdstyle5">
                                N/A
                                <input id="chk_8co2" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_8co2','_8co2')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_8co2" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender59" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_8co2" TargetControlID="_8co2">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                WITNESSED DATE
                            </td>
                            <td class="tdstyle8">
                                N/A
                                <input id="chk_8wd2" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_8wd2','_8wd2')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_8wd2" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender64" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_8wd2" TargetControlID="_8wd2">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td class="tdstyle8">
                                N/A
                                <input id="chk_8actby" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_8actby','_8actby')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_8actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_8commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td class="tdstyle8">
                                N/A
                                <input id="chk_8actdt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_8actdt','_8actdt')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_8actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender56" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_8actdt" TargetControlID="_8actdt">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle5">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle8">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_8btnupdate" runat="server" Text="Update" OnClick="_8btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_8btncancel" runat="server" Text="Cancel" OnClick="_8btncancel_Click" />
                            </td>
                            <td align="left" class="tdstyle5">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td class="tdstyle6">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div6" runat="server" style="position: absolute; z-index: 40; top: 30%; left: 35%">
                <asp:UpdateProgress ID="UpdateProgress8" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload7" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy7" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender7" runat="server" TargetControlID="btnDummy7"
        PopupControlID="pnlPopup7" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup10" runat="server" Width="825px" Height="310px" Style="padding: 15px;
        display: none;" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 825px;" cellpadding="3" border="0" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_17lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td width="200px">
                                PLANNED POWER ON
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_17pwron" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_17pwron','_17pwron')"
                                    runat="server" />
                            </td>
                            <td width="75px">
                                <asp:TextBox ID="_17pwron" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender82" runat="server" TargetControlID="_17pwron"
                                    PopupButtonID="_17pwron" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200px">
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td width="75px">
                                &nbsp;
                            </td>
                            <td width="200px">
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td width="75px">
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="9" align="center">
                                COMMISSIONING &amp; ACCEPTANCE
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PRE-COMMM PLANNED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_17pcp" runat="server" onclick="_checked('chk_17pcp','_17pcp')" style="vertical-align: middle"
                                    type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_17pcp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_17pcp_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_17pcp" TargetControlID="_17pcp">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                COMM PLANNED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_17cp" runat="server" onclick="_checked('chk_17cp','_17cp')" style="vertical-align: middle"
                                    type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_17cp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_17cp_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_17cp" TargetControlID="_17cp">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PRE-COMM
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_17pc1" runat="server" onclick="_checked('chk_17pc1','_17pc1');ph1PlannedPreCommNA()"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_17pc1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender83" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_17pc1" TargetControlID="_17pc1">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                COMM
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_17co1" runat="server" onclick="_checked('chk_17co1','_17co1');ph1PlannedCommNA()"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_17co1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender89" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_17co1" TargetControlID="_17co1">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                WITNESSED DATE
                            </td>
                            <td class="tdstyle3">
                                N/A
                                <input id="chk_17wd1" runat="server" onclick="_checked('chk_17wd1','_17wd1')" style="vertical-align: middle"
                                    type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_17wd1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender90" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_17wd1" TargetControlID="_17wd1">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_17accept1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_17accept1','_17accept1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_17accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender91" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_17accept1" TargetControlID="_17accept1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_17filed1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_17filed1','_17filed1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_17filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender92" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_17filed1" TargetControlID="_17filed1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="9" align="center">
                                CONTROLS
                            </td>
                        </tr>
                        <tr>
                            <td>
                                PRE-COMM&nbsp;
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_17pc2" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_17pc2','_17pc2')" />
                            </td>
                            <td>
                                <asp:CalendarExtender ID="CalendarExtender93" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_17pc2" TargetControlID="_17pc2">
                                </asp:CalendarExtender>
                                <asp:TextBox ID="_17pc2" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                COMM
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_17co2" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_17co2','_17co2')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_17co2" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender94" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_17co2" TargetControlID="_17co2">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                WITNESSED DATE
                            </td>
                            <td class="tdstyle3">
                                N/A
                                <input id="chk_17wd2" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_17wd2','_17wd2')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_17wd2" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender95" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_17wd2" TargetControlID="_17wd2">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_17actby" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_17actby','_17actby')"
                                    runat="server" />
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_17actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_17commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_17actdt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_17actdt','_17actdt')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_17actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender96" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_17actdt" TargetControlID="_17actdt">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_17btnupdate" runat="server" Text="Update" OnClick="_17btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_17btncancel" runat="server" Text="Cancel" OnClick="_17btncancel_Click" />
                            </td>
                            <td align="left" class="tdstyle2">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div9" runat="server" style="position: absolute; z-index: 40; top: 30%; left: 35%">
                <asp:UpdateProgress ID="UpdateProgress11" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload10" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy10" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender10" runat="server" TargetControlID="btnDummy10"
        PopupControlID="pnlPopup10" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup13" runat="server" Width="875px" Height="375px" Style="padding: 15px;"
        BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 875px;" cellpadding="3" border="0" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_10lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PLANNED CONTINUITY / IR TESTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_10ccitp" runat="server" onclick="_checked('chk_10ccitp','_10ccitp')"
                                    style="vertical-align: middle; margin-top: 7px;" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_10ccitp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_10ccitp_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" TargetControlID="_10ccitp">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                CONTINUITY / IR TESTED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_10ccit" runat="server" onclick="_checked('chk_10ccit','_10ccit');_checked('chk_10ccit','_10ccitp')"
                                    style="vertical-align: middle; margin-top: 7px;" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_10ccit" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender236" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    TargetControlID="_10ccit">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                DEVICE TEST PLANNED COMPLETION
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_10dtp" runat="server" onclick="_checked('chk_10dtp','_10dtp')" style="vertical-align: middle"
                                    type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_10dtp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_10dtp_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" TargetControlID="_10dtp">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                NO. OF DEVICES TESTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_10ndt" runat="server" onclick="_checked('chk_10ndt','_10ndt');_checked('chk_10ndt','_10dtp');_checked('chk_10ndt','_10dtc')"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_10ndt" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                DEVICE TEST COMPLETED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_10dtc" runat="server" onclick="_checked('chk_10dtc','_10dtc')" style="vertical-align: middle"
                                    type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_10dtc" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender110" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_10dtc" TargetControlID="_10dtc">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                PLANNED FA INTERFACES COMPLETION
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_10itp" runat="server" onclick="_checked('chk_10itp','_10itp')" style="vertical-align: middle"
                                    type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_10itp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_10itp_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" TargetControlID="_10itp">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                FA INTERFACES TESTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_10fait" runat="server" onclick="_checked('chk_10fait','_10fait');_checked('chk_10fait','_10itp')"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_10fait" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender17_10fait" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_10fait" TargetControlID="_10fait">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                LOOP TEST COMPLETED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_10ltc" runat="server" onclick="_checked('chk_10ltc','_10ltc')" style="vertical-align: middle"
                                    type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_10ltc" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender115" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_10ltc" TargetControlID="_10ltc">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                <asp:TextBox ID="_10interface" runat="server" Width="75px" Style="display: none"></asp:TextBox>
                                <asp:TextBox ID="_10devices" runat="server" Width="75px" Style="display: none"></asp:TextBox>
                            </td>
                            <td class="tdstyle1">
                            </td>
                            <td width="75PX">
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td width="200PX">
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_10accept1" runat="server" onclick="_checked('chk_10accept1','_10accept1')"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_10accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_10accept1_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_10accept1" TargetControlID="_10accept1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEET FILLED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_10filed1" runat="server" onclick="_checked('chk_10filed1','_10filed1')"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_10filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_10filed1_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_10filed1" TargetControlID="_10filed1">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                SOUND LEVEL PLANNED COMPLETION
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_10sltp" runat="server" onclick="_checked('chk_10sltp','_10sltp')"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_10sltp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_10sltp_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" TargetControlID="_10sltp">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                SOUND LEVEL TESTS
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_10slt" runat="server" onclick="_checked('chk_10slt','_10slt');_checked('chk_10slt','_10sltp')"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_10slt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender67_10slt" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_10slt" TargetControlID="_10slt">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                CAUSE & EFFECT PLANNED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_10cetp" runat="server" onclick="_checked('chk_10cetp','_10cetp')"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_10cetp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_10cetp_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" TargetControlID="_10cetp">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX" class="style2">
                                CAUSE & EFFECT TESTS
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_10cet" runat="server" onclick="_checked('chk_10cet','_10cet');_checked('chk_10cet','_10cetp')"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX" class="style2">
                                <asp:TextBox ID="_10cet" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="cal_cet" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_10cet" TargetControlID="_10cet">
                                </asp:CalendarExtender>
                            </td>
                            <td class="style2">
                                BATTERY AUTONOMY PLANNED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_10batp" runat="server" onclick="_checked('chk_10batp','_10batp')"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX" class="style2">
                                <asp:TextBox ID="_10batp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender17" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_10batp" TargetControlID="_10batp">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX" class="style2">
                                BATTERY AUTONOMY TEST
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_10bat" runat="server" onclick="_checked('chk_10bat','_10bat');_checked('chk_10bat','_10batp')"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX" class="style2">
                                <asp:TextBox ID="_10bat" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="cal_bat" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_10bat" TargetControlID="_10bat">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                GRAPHICS / HEAD END PLANNED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_10ghetp" runat="server" onclick="_checked('chk_10ghetp','_10ghetp')"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_10ghetp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender67" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_10ghetp" TargetControlID="_10ghetp">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                GRAPHICS / HEAD END TESTS
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_10ghet" runat="server" onclick="_checked('chk_10ghet','_10ghet');_checked('chk_10ghet','_10ghetp')"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_10ghet" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="cal_ghet" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_10ghet" TargetControlID="_10ghet">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_10accept2" runat="server" onclick="_checked('chk_10accept2','_10accept2')"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td>
                                <asp:TextBox ID="_10accept2" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender112" runat="server" TargetControlID="_10accept2"
                                    PopupButtonID="_10accept2" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEET FILLED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_10filed2" runat="server" onclick="_checked('chk_10filed2','_10filed2')"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td>
                                <asp:TextBox ID="_10filed2" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender113" runat="server" TargetControlID="_10filed2"
                                    PopupButtonID="_10filed2" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_10actby" runat="server" onclick="_checked('chk_10actby','_10actby')"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_10actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_10commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_10actdt" runat="server" onclick="_checked('chk_10actdt','_10actdt')"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td>
                                <asp:TextBox ID="_10actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender114" runat="server" TargetControlID="_10actdt"
                                    PopupButtonID="_10actdt" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_10btnupdate" runat="server" Text="Update" OnClick="_10btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_10btncancel" runat="server" Text="Cancel" OnClick="_10btncancel_Click" />
                            </td>
                            <td align="left" class="tdstyle2">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div12" runat="server" style="position: absolute; z-index: 40; top: 30%;
                left: 35%;">
                <asp:UpdateProgress ID="UpdateProgress14" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload13" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy13" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender13" runat="server" TargetControlID="btnDummy13"
        PopupControlID="pnlPopup13" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup3" runat="server" Width="825px" Height="400px" Style="padding: 15px;
        display: none" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 825px" border="0" cellpadding="3" cellspacing="0">
                        <tr>
                            <td colspan="8" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_6lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="8" align="center">
                                EARTHING &amp; BONDING
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                EARTH PIT TEST PLANNED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_6epp" runat="server" onclick="_checked('chk_6epp','_6epp')" style="vertical-align: middle"
                                    type="checkbox" value="N/A" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_6epp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_6epp_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_6epp" TargetControlID="_6epp">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                EARTH PIT TEST
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_6ep" runat="server" onclick="_checked('chk_6ep', '_6ep'); _checked('chk_6ep', '_6epp'); CheckUncheckNA('chk_6epp','_6epp');"
                                    style="vertical-align: middle" type="checkbox" value="N/A" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_6ep" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender10" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_6ep" TargetControlID="_6ep">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td width="75PX">
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_6accept1" type="checkbox" style="vertical-align: middle" runat="server"
                                    value="n/a" onclick="_checked('chk_6accept1','_6accept1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_6accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender12" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_6accept1" TargetControlID="_6accept1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_6filed1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_6filed1','_6filed1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_6filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender27" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_6filed1" TargetControlID="_6filed1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                (EARTHING)BONDING OF ALL EQUIPMENT COMPETE PLANNED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_6ebp" runat="server" onclick="_checked('chk_6ebp','_6ebp')" style="vertical-align: middle"
                                    type="checkbox" />
                            </td>
                            </td>
                            <td>
                                <asp:TextBox ID="_6ebp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_6ebp_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_6ebp" TargetControlID="_6ebp">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                (EARTHING)BONDING OF ALL EQUIPMENT COMPETE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_6be" runat="server" onclick="_checked('chk_6be', '_6be'); _checked('chk_6be', '_6ebp'); CheckUncheckNA('chk_6ebp', '_6ebp');"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td>
                                <asp:TextBox ID="_6be" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender28" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_6be" TargetControlID="_6be">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_6accept2" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_6accept2','_6accept2')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_6accept2" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender21" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_6accept2" TargetControlID="_6accept2">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_6filed2" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_6filed2','_6filed2')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_6filed2" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender22" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_6filed2" TargetControlID="_6filed2">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="8" align="center">
                                LIGHTNING PROTECTION
                            </td>
                        </tr>
                        <tr>
                            <td>
                                LIGHTNING PROTECTION PIT TEST PLANNED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_6lpp" runat="server" onclick="_checked('chk_6lpp','_6lpp')" style="vertical-align: middle"
                                    type="checkbox" />
                            </td>
                            <td>
                                <asp:TextBox ID="_6lpp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_6lpp_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_6lpp" TargetControlID="_6lpp">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                LIGHTNING PROTECTION PIT TEST
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_6lp" runat="server" onclick="_checked('chk_6lp', '_6lp'); _checked('chk_6lp', '_6lpp'); CheckUncheckNA('chk_6lpp', '_6lpp');"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td>
                                <asp:TextBox ID="_6lp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender31" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_6lp" TargetControlID="_6lp">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_6accept3" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_6accept3','_6accept3')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_6accept3" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender23" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_6accept3" TargetControlID="_6accept3">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_6filed3" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_6filed3','_6filed3')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_6filed3" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender24" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_6filed3" TargetControlID="_6filed3">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                BONDING OF ROOF EQUIP. AND DOWN CONDU. TEST COMPLETE PLANNED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_6brp" runat="server" onclick="_checked('chk_6brp','_6brp')" style="vertical-align: middle"
                                    type="checkbox" />
                            </td>
                            <td>
                                <asp:TextBox ID="_6brp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_6brp_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_6brp" TargetControlID="_6brp">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                BONDING OF ROOF EQUIP. AND DOWN CONNDU. TEST COMPLETE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_6br" runat="server" onclick="_checked('chk_6br', '_6br'); _checked('chk_6br', '_6brp'); CheckUncheckNA('chk_6brp', '_6brp');"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td>
                                <asp:TextBox ID="_6br" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender32" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_6br" TargetControlID="_6br">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_6accept4" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_6accept4','_6accept4')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_6accept4" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender33" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_6accept4" TargetControlID="_6accept4">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_6filed4" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_6filed4','_6filed4')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_6filed4" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender34" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_6filed4" TargetControlID="_6filed4">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_6actby" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_6actby','_6actby')"
                                    runat="server" />
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_6actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="2" rowspan="2">
                                <asp:TextBox ID="_6commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_6actdt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_6actdt','_6actdt')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_6actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender25" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_6actdt" TargetControlID="_6actdt">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_6btnupdate" runat="server" Text="Update" OnClick="_6btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_6btncancel" runat="server" Text="Cancel" OnClick="_6btncancel_Click" />
                            </td>
                            <td align="left" class="tdstyle1">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div2" runat="server" style="position: absolute; z-index: 40; top: 30%; left: 35%">
                <asp:UpdateProgress ID="UpdateProgress4" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload3" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy3" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender3" runat="server" TargetControlID="btnDummy3"
        PopupControlID="pnlPopup3" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnDummy4"
        PopupControlID="pnlPopup4" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup5" runat="server" Width="825px" Height="380px" Style="padding: 15px;
        display: none" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 825px" border="0" cellpadding="3" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_4lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="9" align="center">
                                GENERATOR SET STAND ALONE TESTING
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PLANNED COMPLETION DATE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_4pcd" runat="server" onclick="_checked('chk_4pcd','_4pcd')" style="vertical-align: middle"
                                    type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_4pcd" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_4pcd" TargetControlID="_4pcd">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PRE-COM
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_4pc" runat="server" onclick="_checked('chk_4pc','_4pc');GenPlannedNA()"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_4pc" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender42" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_4pc" TargetControlID="_4pc">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                ALARM &amp; SHUTDOWN TEST
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_4as" runat="server" onclick="_checked('chk_4as','_4as');GenPlannedNA()"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_4as" runat="server" Style="margin-left: 0px" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender43" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_4as" TargetControlID="_4as">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                LOAD BANK TEST
                            </td>
                            <td class="tdstyle3">
                                N/A
                                <input id="chk_4lb" runat="server" onclick="_checked('chk_4lb','_4lb');GenPlannedNA()"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_4lb" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender44" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_4lb" TargetControlID="_4lb">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_4accept1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_4accept1','_4accept1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_4accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender45" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_4accept1" TargetControlID="_4accept1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_4filed1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_4filed1','_4filed1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_4filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender46" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_4filed1" TargetControlID="_4filed1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="9" align="center">
                                OUTGOING CIRCUIT TESTING
                            </td>
                        </tr>
                        <tr id="tr12" runat="server">
                            <td>
                                CABLE COLD TEST PLANNED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_4cablep" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_4cablep','_4cablep')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_4cablep" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_4cablep" TargetControlID="_4cablep">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                CABLE COLD TEST
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_4cable" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_4cable','_4cable');_cleared('chk_4cable','_4cablep');" />
                            </td>
                            <td>
                                <asp:TextBox ID="_4cable" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender47" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_4cable" TargetControlID="_4cable">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_4accept2" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_4accept2','_4accept2')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_4accept2" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender48" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_4accept2" TargetControlID="_4accept2">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_4filed2" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_4filed2','_4filed2')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_4filed2" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender49" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_4filed2" TargetControlID="_4filed2">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="9" align="center">
                                SITE OPERATION &amp; LOAD TEST
                            </td>
                        </tr>
                        <tr>
                            <td>
                                SITE OPERATION LOAD TEST PLANNED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_4solp" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_4solp','_4solp')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_4solp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_4solp" TargetControlID="_4solp">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                SITE OPERATION LOAD TEST
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_4sol" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_4sol','_4sol');SetAcceptNA('chk_4sol','chk_4accept3','chk_4filed3');" />
                            </td>
                            <td>
                                <asp:TextBox ID="_4sol" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender50" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_4sol" TargetControlID="_4sol">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_4accept3" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_4accept3','_4accept3')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_4accept3" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender51" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_4accept3" TargetControlID="_4accept3">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_4filed3" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_4filed3','_4filed3')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_4filed3" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender52" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_4filed3" TargetControlID="_4filed3">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_4actby" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_4actby','_4actby')"
                                    runat="server" />
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_4actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_4commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_4actdt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_4actdt','_4actdt')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_4actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender53" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_4actdt" TargetControlID="_4actdt">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_4btnupdate" runat="server" Text="Update" OnClick="_4btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_4btncancel" runat="server" Text="Cancel" OnClick="_4btncancel_Click" />
                            </td>
                            <td align="left" class="tdstyle2">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div4" runat="server" style="position: absolute; z-index: 40; top: 30%; left: 35%">
                <asp:UpdateProgress ID="UpdateProgress6" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload5" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy5" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender5" runat="server" TargetControlID="btnDummy5"
        PopupControlID="pnlPopup5" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup6" runat="server" Width="825px" Height="263px" Style="padding: 15px;
        display: none" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 825px" border="0" cellpadding="3" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_7lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="9" align="center">
                                EMERGENCY LIGHTING / CENTRAL BATTERY SYSTEM
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PLANNED COMPLETION DATE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_7pc" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_7pc','_7pc')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_7pc" runat="server" Width="75px" Text=""></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender122" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_7pc" TargetControlID="_7pc">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                CONTINUITY/IR TEST COMPLETE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_7cir" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_7cir','_7cir');ECBSPlannaedNA();" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_7cir" runat="server" Width="75px" Text="0"></asp:TextBox>
                                <%--<asp:CalendarExtender ID="CalendarExtender54" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7cir" 
                                TargetControlID="_7cir">
                            </asp:CalendarExtender>--%>
                            </td>
                            <td width="200PX">
                                ADDRESSING
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_7add" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_7add','_7add');ECBSPlannaedNA();" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_7add" runat="server" Width="75px" Text="0"></asp:TextBox>
                                <%-- <asp:CalendarExtender ID="CalendarExtender55" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7add" 
                                TargetControlID="_7add">
                            </asp:CalendarExtender>--%>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                FAULT TEST
                            </td>
                            <td class="tdstyle3">
                                N/A
                                <input id="chk_7ft" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_7ft','_7ft');ECBSPlannaedNA();" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_7ft" runat="server" Width="75px" Text="0"></asp:TextBox>
                                <%--<asp:CalendarExtender ID="CalendarExtender56" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7ft" 
                                TargetControlID="_7ft">
                            </asp:CalendarExtender>--%>
                            </td>
                            <td>
                                CHANGE OVER TEST
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_7co" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_7co','_7co');ECBSPlannaedNA();" />
                            </td>
                            <td>
                                <asp:TextBox ID="_7co" runat="server" Width="75px" Text="0"></asp:TextBox>
                                <%--<asp:CalendarExtender ID="CalendarExtender57" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7co" 
                                TargetControlID="_7co">
                            </asp:CalendarExtender>--%>
                            </td>
                            <td>
                                LUX LEVEL TEST
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_7ll" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_7ll','_7ll');ECBSPlannaedNA();" />
                            </td>
                            <td>
                                <asp:TextBox ID="_7ll" runat="server" Width="75px" Text="0"></asp:TextBox>
                                <%--<asp:CalendarExtender ID="CalendarExtender58" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7ll" 
                                TargetControlID="_7ll">
                            </asp:CalendarExtender>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                DURATION TEST
                            </td>
                            <td class="tdstyle3">
                                N/A
                                <input id="chk_7du" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_7du','_7du');ECBSPlannaedNA();" />
                            </td>
                            <td>
                                <asp:TextBox ID="_7du" runat="server" Width="75px" Text="0"></asp:TextBox>
                                <%--<asp:CalendarExtender ID="CalendarExtender59" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7du" 
                                TargetControlID="_7du">
                            </asp:CalendarExtender>--%>
                            </td>
                            <td>
                                PC HEAD END TEST
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_7pch" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_7pch','_7pch');ECBSPlannaedNA();" />
                            </td>
                            <td>
                                <asp:TextBox ID="_7pch" runat="server" Width="75px" Text="0"></asp:TextBox>
                                <%-- <asp:CalendarExtender ID="CalendarExtender60" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7pch" 
                                TargetControlID="_7pch">
                            </asp:CalendarExtender>--%>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="_7noof" runat="server" Width="75px" Style="display: none"></asp:TextBox>
                                <asp:TextBox ID="_7nocir" runat="server" Width="75px" Style="display: none"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_7accept1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_7accept1','_7accept1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_7accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender61" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_7accept1" TargetControlID="_7accept1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_7filed1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_7filed1','_7filed1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_7filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender62" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_7filed1" TargetControlID="_7filed1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_7actby" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_7actby','_7actby')"
                                    runat="server" />
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_7actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_7commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_7actdt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_7actdt','_7actdt')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_7actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender63" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_7actdt" TargetControlID="_7actdt">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_7btnupdate" runat="server" Text="Update" OnClick="_7btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_7btncancel" runat="server" Text="Cancel" OnClick="_7btncancel_Click" />
                            </td>
                            <td align="left" class="tdstyle2">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div5" runat="server" style="position: absolute; z-index: 40; top: 30%; left: 35%">
                <asp:UpdateProgress ID="UpdateProgress7" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload6" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy6" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender6" runat="server" TargetControlID="btnDummy6"
        PopupControlID="pnlPopup6" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup11" runat="server" Width="825px" Height="200px" Style="padding: 15px;
        display: none" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 825px;" cellpadding="3" border="0" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_18lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PLANNED COMP DATE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_18pcd" runat="server" onclick="_checked('chk_18pcd','_18pcd');" style="vertical-align: middle"
                                    type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_18pcd" runat="server" Width="75px">
                                </asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender11" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_18pcd" TargetControlID="_18pcd">
                                </asp:CalendarExtender>
                            </td>
                            <tr>
                                <td width="200PX">
                                    QUANTITY TESTED
                                </td>
                                <td class="tdstyle1">
                                    N/A
                                    <input id="chk_18qt" runat="server" onclick="_checked('chk_18qt','_18qt');_cleared('chk_18qt','_18pcd');"
                                        style="vertical-align: middle" type="checkbox" />
                                </td>
                                <td width="75PX">
                                    <asp:TextBox ID="_18qt" runat="server" Width="75px">
                                    </asp:TextBox>
                                </td>
                                <td width="200PX">
                                    WITNESSED
                                </td>
                                <td class="tdstyle2">
                                    N/A
                                    <input id="chk_18wt" runat="server" onclick="_checked('chk_18wt','_18wt')" style="vertical-align: middle"
                                        type="checkbox" />
                                </td>
                                <td width="75PX">
                                    <asp:TextBox ID="_18wt" runat="server" Width="75px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender98" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                        PopupButtonID="_18wt" TargetControlID="_18wt">
                                    </asp:CalendarExtender>
                                </td>
                                <td width="200PX">
                                    <asp:Label ID="_18lblicom" runat="server" Text="INSTALLATION SIGN OFF"></asp:Label>
                                </td>
                                <td class="tdstyle1">
                                    N/A
                                    <input id="chk_18icom" runat="server" onclick="_checked('chk_18icom','_18icom')"
                                        style="vertical-align: middle" type="checkbox" />
                                </td>
                                <td width="75PX">
                                    <asp:TextBox ID="_18noof" runat="server" Style="display: none" Width="75px"></asp:TextBox>
                                    <asp:TextBox ID="_18icom" runat="server" Width="75px"></asp:TextBox>
                                    <asp:CalendarExtender ID="_18wt0_CalendarExtender" runat="server" ClearTime="true"
                                        Format="dd/MM/yyyy" PopupButtonID="_18icom" TargetControlID="_18icom">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                                <td>
                                    CONSULTANT ACCEPTED
                                </td>
                                <td class="tdstyle1">
                                    N/A
                                    <input id="chk_18accept1" runat="server" onclick="_checked('chk_18accept1','_18accept1')"
                                        style="vertical-align: middle" type="checkbox" />
                                </td>
                                <td>
                                    <asp:TextBox ID="_18accept1" runat="server" Width="75px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender101" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                        PopupButtonID="_18accept1" TargetControlID="_18accept1">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    TEST SHEETS FILED
                                </td>
                                <td class="tdstyle2">
                                    N/A
                                    <input id="chk_18filed1" runat="server" onclick="_checked('chk_18filed1','_18filed1')"
                                        style="vertical-align: middle" type="checkbox" />
                                </td>
                                <td>
                                    <asp:TextBox ID="_18filed1" runat="server" Width="75px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender102" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                        PopupButtonID="_18filed1" TargetControlID="_18filed1">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr style="background-color: #83C8EE">
                                <td>
                                    ACTION BY&nbsp;
                                </td>
                                <td class="tdstyle1">
                                    N/A
                                    <input id="chk_18actby" runat="server" onclick="_checked('chk_18actby','_18actby')"
                                        style="vertical-align: middle" type="checkbox" />
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="_18actby" runat="server" Width="250px"></asp:TextBox>
                                </td>
                                <td class="tdstyle2">
                                    &nbsp;
                                </td>
                                <td>
                                    COMMENTS
                                </td>
                                <td colspan="3" rowspan="2">
                                    <asp:TextBox ID="_18commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="background-color: #83C8EE">
                                <td>
                                    ACTION DATE
                                </td>
                                <td class="tdstyle1">
                                    N/A
                                    <input id="chk_18actdt" runat="server" onclick="_checked('chk_18actdt','_18actdt')"
                                        style="vertical-align: middle" type="checkbox" />
                                </td>
                                <td>
                                    <asp:TextBox ID="_18actdt" runat="server" Width="75px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender103" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                        PopupButtonID="_18actdt" TargetControlID="_18actdt">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="tdstyle2">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="tdstyle1">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:Button ID="_18btnupdate" runat="server" OnClick="_18btnupdate_Click" Text="Update" />
                                </td>
                                <td align="left">
                                    <asp:Button ID="_18btncancel" runat="server" OnClick="_18btncancel_Click" Text="Cancel" />
                                </td>
                                <td align="left" class="tdstyle2">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    &nbsp;
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div10" runat="server" style="position: absolute; z-index: 40; top: 30%;
                left: 35%">
                <asp:UpdateProgress ID="UpdateProgress12" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload11" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="Button3" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnDummy11"
        PopupControlID="pnlPopup11" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Button ID="btnDummy11" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender11" runat="server" TargetControlID="btnDummy11"
        PopupControlID="pnlPopup11" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup12" runat="server" Width="825px" Height="235px" Style="padding: 15px;
        display: none;" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 825px;" cellpadding="3" border="0" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_19lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PLANNED COMP DATE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_19pcd" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_19pcd','_19pcd');" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_19pcd" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="_19pcd"
                                    PopupButtonID="_19pcd" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                ROOM/SYSTEM INTEGRITY TEST&nbsp;
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_19rsit" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_19rsit','_19rsit');ph3PlannedNA();" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_19rsit" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender105" runat="server" TargetControlID="_19rsit"
                                    PopupButtonID="_19rsit" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                STAND ALONE COMMISSION
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_19sac" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_19sac','_19sac');ph3PlannedNA();" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_19sac" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender97" runat="server" TargetControlID="_19sac"
                                    PopupButtonID="_19sac" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                FIRE &amp; BMS INTERFACE TEST
                            </td>
                            <td class="tdstyle3">
                                N/A
                                <input id="chk_19fbit" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_19fbit','_19fbit');ph3PlannedNA();" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_19fbit" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender106" runat="server" TargetControlID="_19fbit"
                                    PopupButtonID="_19fbit" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                WITNESSED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_19wt" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_19wt','_19wt')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_19wt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender107" runat="server" TargetControlID="_19wt"
                                    PopupButtonID="_19wt" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_19accept1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_19accept1','_19accept1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_19accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender99" runat="server" TargetControlID="_19accept1"
                                    PopupButtonID="_19accept1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_19filed1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_19filed1','_19filed1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_19filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender100" runat="server" TargetControlID="_19filed1"
                                    PopupButtonID="_19filed1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_19actby" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_19actby','_19actby')"
                                    runat="server" />
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_19actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_19commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_19actdt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_19actdt','_19actdt')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_19actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender104" runat="server" TargetControlID="_19actdt"
                                    PopupButtonID="_19actdt" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_19btnupdate" runat="server" Text="Update" OnClick="_19btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_19btncancel" runat="server" Text="Cancel" OnClick="_19btncancel_Click" />
                            </td>
                            <td align="left" class="tdstyle2">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div11" runat="server" style="position: absolute; z-index: 40; top: 30%;
                left: 35%">
                <asp:UpdateProgress ID="UpdateProgress13" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload12" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy12" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender12" runat="server" TargetControlID="btnDummy12"
        PopupControlID="pnlPopup12" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup14" runat="server" Width="900" Height="355px" Style="padding: 15px;"
        BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="_20points" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="_20devices" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="_20system" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="TextBox2" runat="server" Style="display: none"></asp:TextBox>
                    <table style="font-size: x-small; width: 900px;" cellpadding="3" border="0" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_20lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PLANNED CONTINUITY/IR TESTED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_20citp" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_20citp','_20citp')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_20citp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender_20citp" runat="server" TargetControlID="_20citp"
                                    PopupButtonID="_20citp" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                CONTINUITY/IR TESTED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_20cit" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_20cit','_20cit');_checked('chk_20cit','_20citp')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_20cit" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                POINT TO POINT TEST PLANNED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_20pptp" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_20pptp','_20pptp')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_20pptp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="_20pptp"
                                    PopupButtonID="_20pptp" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                POINT TO POINT TEST
                            </td>
                            <td class="tdstyle3">
                                N/A
                                <input id="chk_20ppt" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_20ppt','_20ppt');_checked('chk_20ppt','_20pptp')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_20ppt" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                CALIBRATION/FUNCTIONAL TEST PLANNED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_20cftp" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_20cftp','_20cftp')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_20cftp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="_20cftp"
                                    PopupButtonID="_20cftp" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                CALIBRATION/FUNCTIONAL TEST
                            </td>
                            <td class="tdstyle3">
                                N/A
                                <input id="chk_20cft" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_20cft','_20cft');_checked('chk_20cft','_20cftp')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_20cft" runat="server" Width="75px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td width="200PX">
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_20accept1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_20accept1','_20accept1')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_20accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender121" runat="server" TargetControlID="_20accept1"
                                    PopupButtonID="_20accept1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_20filed1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_20filed1','_20filed1')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_20filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="_20filed1"
                                    PopupButtonID="_20filed1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PLANNED SEQ. OF OPERATION TEST
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_20sotp" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_20sotp','_20sotp')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_20sotp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender174" runat="server" TargetControlID="_20sotp"
                                    PopupButtonID="_20sotp" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                SEQ. OF OPERATION TEST
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_20sot" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_20sot','_20sot');_checked('chk_20sot','_20sotp')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_20sot" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                GRAPHICS/HEAD END TEST PLANNED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_20ghtp" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_20ghtp','_20ghtp')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_20ghtp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="_20ghtp"
                                    PopupButtonID="_20ghtp" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                GRAPHICS/HEAD END TEST
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_20ght" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_20ght','_20ght');_checked('chk_20ght','_20ghtp')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_20ght" runat="server" Width="75px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td width="200PX">
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_20accept2" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_20accept2','_20accept2')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_20accept2" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender109" runat="server" TargetControlID="_20accept2"
                                    PopupButtonID="_20accept2" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_20filed2" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_20filed2','_20filed2')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_20filed2" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender111" runat="server" TargetControlID="_20filed2"
                                    PopupButtonID="_20filed2" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PLANNED LOOP TUNING
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_20ltp" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_20lt','_20lt')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_20ltp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender_20ltp" runat="server" TargetControlID="_20ltp"
                                    PopupButtonID="_20ltp" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                LOOP TUNING
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_20lt" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_20lt','_20lt');_checked('chk_20lt','_20ltp')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_20lt" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_20accept3" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_20accept3','_20accept3')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_20accept3" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender127" runat="server" TargetControlID="_20accept3"
                                    PopupButtonID="_20accept3" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_20filed3" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_20filed3','_20filed3')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_20filed3" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender128" runat="server" TargetControlID="_20filed3"
                                    PopupButtonID="_20filed3" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_20actby" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_20actby','_20actby')"
                                    runat="server" />
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_20actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_20commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_20actdt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_20actdt','_20actdt')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_20actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender129" runat="server" TargetControlID="_20actdt"
                                    PopupButtonID="_20actdt" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                            </td>
                            <td class="tdstyle1">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_20btnupdate" runat="server" Text="Update" OnClick="_20btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_20btncancel" runat="server" Text="Cancel" OnClick="_20btncancel_Click" />
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div13" runat="server" style="position: absolute; z-index: 40; top: 30%;
                left: 35%">
                <asp:UpdateProgress ID="UpdateProgress15" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload14" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy14" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender14" runat="server" TargetControlID="btnDummy14"
        PopupControlID="pnlPopup14" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>

        
           <asp:Panel ID="pnlPopup19" runat="server" Width="900px" Height="255px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:900px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_15lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                      <tr>
                            <td width="200PX">
                                PLANNED COMP DATE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_15pcd" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_15pcd', '_15pcd');" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_15pcd" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender16" runat="server" TargetControlID="_15pcd"
                                    PopupButtonID="_15pcd" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                    <tr >
                        <td width="200PX" >
                            CONTINUITY/IR TEST&nbsp;</td>
                        <td class="tdstyle1" width="200PX">
                            N/A
                             <input id="chk_15cit" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15cit', '_15cit')" runat="server"/></td></td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15cit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            KEY CARD ACTIVATED</td>
                        <td class="tdstyle2" width="200PX">
                            N/A
                             <input id="chk_15kca" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15kca', '_15kca')" runat="server"/></td></td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15kca" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            DO NOT DISTURB(DND)/ DOORBELL</td>
                        <td class="tdstyle3" width="200PX">
                            N/A
                             <input id="chk_15dnd" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15dnd', '_15dnd')" runat="server"/></td></td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15dnd" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            MAKE UP ROOM</td>
                        <td class="tdstyle1" width="200PX">
                            N/A
                             <input id="chk_15mur" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15mur', '_15mur')" runat="server"/></td></td>
                        <td width="75PX">
                            <asp:TextBox ID="_15mur" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            FCU/ TEMP CONTROL</td>
                        <td class="tdstyle2" width="200PX">
                            N/A
                             <input id="chk_15ftc" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15ftc', '_15ftc')" runat="server"/></td></td>
                        <td width="75PX">
                            <asp:TextBox ID="_15ftc" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            ENERGY MANAGEMENT SYSTEM</td>
                        <td class="tdstyle3" width="200PX">
                            N/A
                             <input id="chk_15ems" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15ems', '_15ems')" runat="server"/></td></td>
                        <td width="75PX">
                            <asp:TextBox ID="_15ems" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            LIGHTING SCENE CONTROL</td>
                        <td class="tdstyle1" width="200PX">
                            N/A
                             <input id="chk_15lsc" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15lsc', '_15lsc')" runat="server"/></td></td>
                        <td width="75PX">
                            <asp:TextBox ID="_15lsc" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            BLINDS CONTROL INTERFACE</td>
                        <td class="tdstyle3" width="200PX">
                            N/A
                             <input id="chk_15bci" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15bci', '_15bci')" runat="server"/></td></td>
                        <td width="75PX">
                            <asp:TextBox ID="_15bci" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            MONITORING INTERFACE (FUTURE)</td>
                        <td class="tdstyle3" width="200PX">
                            N/A
                             <input id="chk_15mif" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15mif', '_15mif')" runat="server"/></td></td>
                        <td width="75PX">
                            <asp:TextBox ID="_15mif" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td >
                           
                            <asp:TextBox ID="_15accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender13" runat="server" 
                        TargetControlID="_15accept1" PopupButtonID="_15accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td >
                           
                            <asp:TextBox ID="_15filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender14" runat="server" 
                        TargetControlID="_15filed1" PopupButtonID="_15filed1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            <asp:TextBox ID="_15noof" runat="server" Width="75px" style="display:none"></asp:TextBox>
                        </td>
                        <td class="tdstyle3">
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_15actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_15commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            
                            <asp:TextBox ID="_15actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender15" runat="server" 
                        TargetControlID="_15actdt" PopupButtonID="_15actdt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_15btnupdate" runat="server" Text="Update" 
                                onclick="_15btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_15btncancel" runat="server" Text="Cancel" 
                                onclick="_15btncancel_Click"  />
                        </td>
                        <td align="left">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                           
                        </td>
                        <td class="tdstyle3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
                 <div id="Div20" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress20" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload19" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy19" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender19" runat="server" TargetControlID="btnDummy19"  PopupControlID="pnlPopup19" BackgroundCssClass="modal"></asp:ModalPopupExtender> 


    <asp:Panel ID="pnlPopup8" runat="server" Width="825px" Height="280px" Style="padding: 15px;
        display: none;" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 825px" border="0" cellpadding="3" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_21lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td width="200px">
                                PLANNED POWER ON
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_21pwron" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_21pwron','_21pwron')"
                                    runat="server" />
                            </td>
                            <td width="75px">
                                <asp:TextBox ID="_21pwron" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender681" runat="server" TargetControlID="_21pwron"
                                    PopupButtonID="_21pwron" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200px">
                                PLANNED COMPLETION DATE
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_21pcd" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_21pcd','_21pcd')"
                                    runat="server" />
                            </td>
                            <td width="75px">
                                <asp:TextBox ID="_21pcd" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_21pcd_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_21pcd" TargetControlID="_21pcd">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200px">
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td width="75px">
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="9" align="center">
                                MECHANICAL SYSTEMS
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PLAIN FLUSHING
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_21pf" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_21pf','_21pf');_21PlannedNA()" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_21pf" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender69" runat="server" TargetControlID="_21pf"
                                    PopupButtonID="_21pf" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                FLUSHING VELOCITIES RECORDED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_21fvr" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_21fvr','_21fvr');_21PlannedNA()" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_21fvr" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender85" runat="server" TargetControlID="_21fvr"
                                    PopupButtonID="_21fvr" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                CHEMICAL CLEANING
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_21cc" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_21cc','_21cc');_21PlannedNA()" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_21cc" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender86" runat="server" TargetControlID="_21cc"
                                    PopupButtonID="_21cc" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                FLUSHING AFTER CHEMICAL CLEANING
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_21facc" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_21facc','_21facc');_21PlannedNA()" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_21facc" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender77" runat="server" TargetControlID="_21facc"
                                    PopupButtonID="_21facc" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                BACK FLUSHING COMPLETE
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_21bfc" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_21bfc','_21bfc');_21PlannedNA()" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_21bfc" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender116" runat="server" TargetControlID="_21bfc"
                                    PopupButtonID="_21bfc" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                FINAL CHEMICAL TREATMENT
                            </td>
                            <td class="tdstyle3">
                                N/A
                                <input id="chk_21fct" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_21fct','_21fct');_21PlannedNA()" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_21fct" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender87" runat="server" TargetControlID="_21fct"
                                    PopupButtonID="_21fct" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_21accept1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_21accept1','_21accept1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_21accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender88" runat="server" TargetControlID="_21accept1"
                                    PopupButtonID="_21accept1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td>
                                N/A
                                <input id="chk_21filed1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_21filed1','_21filed1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_21filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender108" runat="server" TargetControlID="_21filed1"
                                    PopupButtonID="_21filed1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_21actby" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_21actby','_21actby')"
                                    runat="server" />
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_21actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_21commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_21actdt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_21actdt','_21actdt')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_21actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender76" runat="server" TargetControlID="_21actdt"
                                    PopupButtonID="_21actdt" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_21btnupdate" runat="server" Text="Update" OnClick="_21btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_21btncancel" runat="server" Text="Cancel" OnClick="_21btncancel_Click" />
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div7" runat="server" style="position: absolute; z-index: 40; top: 30%; left: 35%">
                <asp:UpdateProgress ID="UpdateProgress9" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload8" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy8" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender8" runat="server" TargetControlID="btnDummy8"
        PopupControlID="pnlPopup8" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup15" runat="server" Width="825px" Height="250px" Style="padding: 15px;
        display: none" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 825px;" cellpadding="3" border="0" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_13lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PLANNED COMPLETION DATE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_13pcd" runat="server" onclick="_checked('chk_13pcd','_13pcd')" style="vertical-align: middle"
                                    type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_13pcd" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender78" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_13pcd" TargetControlID="_13pcd">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                CONTINUITY/ IR TEST
                            </td>
                            <td class="tdstyle1">
                                N/A<input id="chk_13cit" runat="server" onclick="_checked('chk_13cit','_13cit');_13PlannedNA();"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_13cit" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                CCTV VIEW LOCALLY
                            </td>
                            <td class="tdstyle2">
                                N/A<input id="chk_13cvl" runat="server" onclick="_checked('chk_13cvl','_13cvl');_13PlannedNA();"
                                    style="vertical-align: middle;" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_13cvl" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                CCTV VIEW FROM HEAD END
                            </td>
                            <td class="tdstyle3">
                                N/A<input id="chk_13cvh" runat="server" onclick="_checked('chk_13cvh','_13cvh');_13PlannedNA();"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_13cvh" runat="server" Width="75px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                ADDRESSING/SOFTWARE TEST
                            </td>
                            <td class="tdstyle1">
                                N/A<input id="chk_13ast" runat="server" onclick="_checked('chk_13ast','_13ast');_13PlannedNA();"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_13ast" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                RECORDING/BACK-UP STORAGE TEST
                            </td>
                            <td class="tdstyle2">
                                N/A<input id="chk_13rbst" runat="server" onclick="_checked('chk_13rbst','_13rbst');_13PlannedNA();"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_13rbst" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                <asp:TextBox ID="_13noof" runat="server" Style="display: none" Width="75px"></asp:TextBox>
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td width="75PX">
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                N/A<input id="chk_13accept1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_13accept1','_13accept1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_13accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender126" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_13accept1" TargetControlID="_13accept1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle2">
                                N/A<input id="chk_13filed1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_13filed1','_13filed1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_13filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender130" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_13filed1" TargetControlID="_13filed1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td class="tdstyle1">
                                N/A<input id="chk_13actby" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_13actby','_13actby')"
                                    runat="server" />
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_13actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_13commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td class="tdstyle1">
                                N/A<input id="chk_13actdt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_13actdt','_13actdt')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_13actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender131" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_13actdt" TargetControlID="_13actdt">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_13btnupdate" runat="server" OnClick="_13btnupdate_Click" Text="Update" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_13btncancel" runat="server" OnClick="_13btncancel_Click" Text="Cancel" />
                            </td>
                            <td align="left" class="tdstyle2">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div14" runat="server" style="position: absolute; z-index: 40; top: 30%;
                left: 35%">
                <asp:UpdateProgress ID="UpdateProgress16" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload15" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy15" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender15" runat="server" TargetControlID="btnDummy15"
        PopupControlID="pnlPopup15" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup17" runat="server" Width="900px" Height="240px" Style="padding: 15px;
        display: none;" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 900px" cellpadding="3" border="0" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_11lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PLANNED COMPLETION DATE
                            </td>
                            <td class="tdstyle4">
                                N/A
                                <input id="chk_11pcd" runat="server" onclick="_checked('chk_11pcd','_11pcd')" style="vertical-align: middle"
                                    type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_11pcd" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender79" runat="server" TargetControlID="_11pcd"
                                    PopupButtonID="_11pcd" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle5">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle6">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                CONTINUITY/IR TEST
                            </td>
                            <td class="tdstyle4">
                                N/A
                                <input id="chk_11cit" runat="server" onclick="_checked('chk_11cit','_11cit');_11PlannedNA();"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_11cit" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                NO.OF LIGHTING CIRCUITS TESTED&nbsp;
                            </td>
                            <td class="tdstyle5">
                                N/A
                                <input id="chk_11lct" runat="server" onclick="_checked('chk_11lct','_11lct');_11PlannedNA();"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_11lct" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                ADDRESSING/PROGRAMMING TEST
                            </td>
                            <td class="tdstyle6">
                                N/A
                                <input id="chk_11apt" runat="server" onclick="_checked('chk_11apt','_11apt');_11PlannedNA();"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_11apt" runat="server" Width="75px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PC HEADEND/INTERFACE TEST
                            </td>
                            <td class="tdstyle4">
                                N/A
                                <input id="chk_11phgt" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_11phgt','_11phgt');_11PlannedNA();" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_11phgt" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle5">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle6">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle4">
                                N/A
                                <input id="chk_11accept1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_11accept1','_11accept1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_11accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender125" runat="server" TargetControlID="_11accept1"
                                    PopupButtonID="_11accept1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle5">
                                N/A
                                <input id="chk_11filed1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_11filed1','_11filed1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_11filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender132" runat="server" TargetControlID="_11filed1"
                                    PopupButtonID="_11filed1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle6">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td class="tdstyle4">
                                N/A
                                <input id="chk_11actby" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_11actby','_11actby')"
                                    runat="server" />
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_11actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle5">
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_11commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td class="tdstyle4">
                                N/A
                                <input id="chk_11actdt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_11actdt','_11actdt')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_11actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender133" runat="server" TargetControlID="_11actdt"
                                    PopupButtonID="_11actdt" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle5">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle4">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_11btnupdate" runat="server" Text="Update" OnClick="_11btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_11btncancel" runat="server" Text="Cancel" OnClick="_11btncancel_Click" />
                            </td>
                            <td align="left" class="tdstyle5">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td class="tdstyle6">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div16" runat="server" style="position: absolute; z-index: 40; top: 30%;
                left: 35%">
                <asp:UpdateProgress ID="UpdateProgress18" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload17" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy17" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender17" runat="server" TargetControlID="btnDummy17"
        PopupControlID="pnlPopup17" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup18" runat="server" Width="850px" Height="200px" Style="padding: 15px;
        display: none" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 850px;" cellpadding="3" border="0" cellspacing="0">
                        <tr>
                            <td colspan="8" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_12lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PLANNED COMPLETION DATE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_12pcd" runat="server" onclick="_checked('chk_12pcd','_12pcd')" style="vertical-align: middle"
                                    type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_12pcd" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender80" runat="server" TargetControlID="_12pcd"
                                    PopupButtonID="_12pcd" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                NO.OF POINTS
                            </td>
                            <td class="tdstyle1">
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_12nop" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                CABLE TESTED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_12ct" runat="server" onclick="_checked('chk_12ct','_12ct');_12PlannedNA();"
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_12ct" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_12accept1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_12accept1','_12accept1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_12accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender142" runat="server" TargetControlID="_12accept1"
                                    PopupButtonID="_12accept1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_12filed1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_12filed1','_12filed1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_12filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender134" runat="server" TargetControlID="_12filed1"
                                    PopupButtonID="_12filed1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_12actby" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_12actby','_12actby')"
                                    runat="server" />
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_12actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="2" rowspan="2">
                                <asp:TextBox ID="_12commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_12actdt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_12actdt','_12actdt')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_12actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender135" runat="server" TargetControlID="_12actdt"
                                    PopupButtonID="_12actdt" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_12btnupdate" runat="server" Text="Update" OnClick="_12btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_12btncancel" runat="server" Text="Cancel" OnClick="_12btncancel_Click" />
                            </td>
                            <td align="left" class="tdstyle2">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div17" runat="server" style="position: absolute; z-index: 40; top: 30%;
                left: 35%">
                <asp:UpdateProgress ID="UpdateProgress19" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload18" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy18" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender18" runat="server" TargetControlID="btnDummy18"
        PopupControlID="pnlPopup18" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Button ID="btnDummy26a" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender26a" runat="server" TargetControlID="btnDummy26a"
        PopupControlID="pnlPopup26a" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup26a" runat="server" Width="850px" Height="235px" Style="padding: 15px;
        display: none" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel43" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 850px" border="0" cellpadding="3" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 26px">
                                <asp:Label ID="_26lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PLANNED COMPLETION DATE
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_26pcd" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender81" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_26pcd" TargetControlID="_26pcd">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                CONTINUITY TEST
                            </td>
                            <td class="tdstyle1" style="vertical-align: middle">
                                N/A
                                <input id="chk_26ct" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_26ct','_26ct');_26PlannedNA();"
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_26ct" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                PROGRAMMING &amp; COMMUNICATION TEST
                            </td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_26pct" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_26pct','_26pct');_26PlannedNA();"
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_26pct" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                COMMISSIONING
                            </td>
                            <td class="tdstyle3">
                                N/A<input id="chk_26comm" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_26comm','_26comm');_26PlannedNA();"
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_26comm" runat="server" Width="75px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="9" align="center">
                                FINAL TEST SHEETS
                            </td>
                        </tr>
                        <tr>
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:CalendarExtender ID="CalendarExtender227" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_26accept1" TargetControlID="_26accept1">
                                </asp:CalendarExtender>
                                <asp:TextBox ID="_26accept1" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="_26filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender228" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_26filed1" TargetControlID="_26filed1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_26actby" runat="server" Width="260px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_26commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="_26actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender229" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_26actdt" TargetControlID="_26actdt">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_26btnupdate" runat="server" Text="Update" OnClick="_26btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_26btncancel" runat="server" Text="Cancel" OnClick="_26btncancel_Click" />
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div24" runat="server" style="position: absolute; z-index: 40; top: 30%;
                left: 35%">
                <asp:UpdateProgress ID="UpdateProgress33" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image26" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="260px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlPopup16" runat="server" Width="900px" Style="padding: 15px;
        display: none" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 900px;" cellpadding="3" border="0" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_22lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PLANNED COMPLETION DATE
                            </td>
                            <td class="tdstyle1" width="200PX">
                                N/A
                                <input id="chk_22pcd" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_22pcd','_22pcd')"
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_22pcd" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender68" runat="server" TargetControlID="_22pcd"
                                    PopupButtonID="_22pcd" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                CONTINUITY/IR TEST
                            </td>
                            <td class="tdstyle1" width="200PX">
                                N/A
                                <input id="chk_22cit" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_22cit','_22cit');ACSPlannedNA();"
                                    runat="server" />
                            </td>
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_22cit" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                ADDRESSING/PROGRAMMING TEST
                            </td>
                            <td class="tdstyle2" width="200PX">
                                N/A
                                <input id="chk_22apt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_22apt','_22apt');ACSPlannedNA();"
                                    runat="server" />
                            </td>
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_22apt" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                FAULT &amp; ALARM TEST
                            </td>
                            <td class="tdstyle3" width="200PX">
                                N/A
                                <input id="chk_22fat" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_22fat','_22fat');ACSPlannedNA();"
                                    runat="server" />
                            </td>
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_22fat" runat="server" Width="75px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                ACCESS CARD SWIPE
                            </td>
                            <td class="tdstyle3" width="200PX">
                                N/A
                                <input id="chk_22acs" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_22acs','_22acs');ACSPlannedNA();"
                                    runat="server" />
                            </td>
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_22acs" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                POWER FAILURE TEST
                            </td>
                            <td class="tdstyle2" width="200PX">
                                N/A
                                <input id="chk_22pft" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_22pft','_22pft');ACSPlannedNA();"
                                    runat="server" />
                            </td>
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_22pft" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                <asp:TextBox ID="_22noof" runat="server" Width="75px" Style="display: none"></asp:TextBox>
                                INTERFACE TEST
                            </td>
                            <td class="tdstyle3" width="200PX">
                                N/A
                                <input id="chk_22it" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_22it','_22it');ACSPlannedNA();"
                                    runat="server" />
                            </td>
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_22it" runat="server" Width="75px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PC HEADEND/GRAPHIC TEST
                            </td>
                            <td class="tdstyle1" width="200PX">
                                N/A
                                <input id="chk_22phgt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_22phgt','_22phgt');ACSPlannedNA();"
                                    runat="server" />
                            </td>
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_22phgt" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle2" width="200PX">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle3" width="200PX">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="_22accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender120" runat="server" TargetControlID="_22accept1"
                                    PopupButtonID="_22accept1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="_22filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender123" runat="server" TargetControlID="_22filed1"
                                    PopupButtonID="_22filed1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_22actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_22commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE;">
                            <td>
                                ACTION DATE
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="_22actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender124" runat="server" TargetControlID="_22actdt"
                                    PopupButtonID="_22actdt" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_22btnupdate" runat="server" Text="Update" OnClick="_22btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_22btncancel" runat="server" Text="Cancel" OnClick="_22btncancel_Click" />
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div15" runat="server" style="position: absolute; z-index: 40; top: 30%;
                left: 35%">
                <asp:UpdateProgress ID="UpdateProgress17" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload16" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy16" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender16" runat="server" TargetControlID="btnDummy16"
        PopupControlID="pnlPopup16" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup27" runat="server" Width="825px" Height="235px" Style="padding: 27px;
        display: none;" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel45" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 825px;" cellpadding="3" border="0" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_27lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PLANNED COMPLETION DATE
                            </td>
                            <td class="tdstyle1" width="200PX">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_27pcd" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <asp:CalendarExtender ID="CalendarExtender84" runat="server" TargetControlID="_27pcd"
                                PopupButtonID="_27pcd" ClearTime="true" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle2" width="200PX">
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle3" width="200PX">
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                CONTINUITY/IR TEST&nbsp;
                            </td>
                            <td class="tdstyle1" width="200PX">
                                N/A
                                <input id="chk_27cit" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_27cit','_27cit');PAVAPlannedNA();"
                                    runat="server" />
                            </td>
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_27cit" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                &nbsp;DB LEVELS
                            </td>
                            <td class="tdstyle2" width="200PX">
                                N/A
                                <input id="chk_27dl" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_27dl','_27dl');PAVAPlannedNA();"
                                    runat="server" />
                            </td>
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_27dl" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle3" width="200PX">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PAGING MISC
                            </td>
                            <td class="tdstyle1" width="200PX">
                                N/A
                                <input id="chk_27pm" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_27pm','_27pm');PAVAPlannedNA();"
                                    runat="server" />
                            </td>
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_27pm" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                ADDRESSING/SOFTWARE TEST
                            </td>
                            <td class="tdstyle2" width="200PX">
                                N/A
                                <input id="chk_27ast" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_27ast','_27ast');PAVAPlannedNA();"
                                    runat="server" />
                            </td>
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_27ast" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                            </td>
                            <td class="tdstyle3" width="200PX">
                            </td>
                            <td width="75PX">
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="9" align="center">
                                FINAL TEST SHEETS
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="_27accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender233" runat="server" TargetControlID="_27accept1"
                                    PopupButtonID="_27accept1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="_27filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender234" runat="server" TargetControlID="_27filed1"
                                    PopupButtonID="_27filed1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:TextBox ID="_27noof" runat="server" Width="75px" Style="display: none"></asp:TextBox>
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_27actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_27commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="_27actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender235" runat="server" TargetControlID="_27actdt"
                                    PopupButtonID="_27actdt" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_27btnupdate" runat="server" Text="Update" OnClick="_27btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_27btncancel" runat="server" Text="Cancel" OnClick="_27btncancel_Click" />
                            </td>
                            <td align="left" class="tdstyle2">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div26" runat="server" style="position: absolute; z-index: 40; top: 30%;
                left: 35%">
                <asp:UpdateProgress ID="UpdateProgress35" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload27a" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy27" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender27" runat="server" TargetControlID="btnDummy27"
        PopupControlID="pnlPopup27" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup25a" runat="server" Width="850px" Height="235px" Style="padding: 15px;
        display: none;" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 850px" border="0" cellpadding="3" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_25albl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PLANNED COMPLETION DATE
                            </td>
                            <td class="tdstyle1">
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_25pcd" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_25apfec0_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_25pcd" TargetControlID="_25pcd">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                POWER FAIL/EMERGENCY CONDITION
                            </td>
                            <td class="tdstyle1">
                                N/A<input id="chk_25apfec" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_25apfec','_25apfec');_25PlannedNA();"
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_25apfec" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender217" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_25apfec" TargetControlID="_25apfec">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                MEASURED PUE
                            </td>
                            <td class="tdstyle2">
                                N/A<input id="chk_25amp" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_25amp','_25amp');_25PlannedNA();"
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_25amp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender219" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_25amp" TargetControlID="_25amp">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                ENVIORNMENTAL BULDING TEST
                            </td>
                            <td class="tdstyle3">
                                N/A
                                <input id="chk_25aebt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_25aebt','_25aebt')"
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_25aebt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender220" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_25aebt" TargetControlID="_25aebt">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="_25afiled1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender225" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_25afiled1" TargetControlID="_25afiled1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="9" align="center">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_25aactby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_25acommts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="_25aactdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender226" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_25aactdt" TargetControlID="_25aactdt">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_25abtnupdate" runat="server" Text="Update" OnClick="_25abtnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_25abtncancel" runat="server" Text="Cancel" OnClick="_25abtncancel_Click" />
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div21" runat="server" style="position: absolute; z-index: 40; top: 30%;
                left: 35%">
                <asp:UpdateProgress ID="UpdateProgress32" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy25a" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender25a" runat="server" TargetControlID="btnDummy25a"
        PopupControlID="pnlPopup25a" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>

 <asp:Panel ID="pnlPopup16a" runat="server" Width="835px" Style="padding: 15px;
        display: table" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 835px;" cellpadding="3" border="0" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_16lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="225PX">
                                PLANNED COMPLETION DATE
                            </td>
                            <td  class="tdstyle1">
                                N/A
                                <input id="chk_16pcd" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_16pcd', '_16pcd');" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_16pcd" runat="server" Width="75px" Text="0"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender70" runat="server" TargetControlID="_16pcd"
                                    PopupButtonID="_16pcd" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td >
                            </td>
                            <td >
                            </td>
                            <td >
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                CONTINUITY/IR TEST
                            </td>
                            <td  class="tdstyle1">
                                N/A
                                <input id="chk_16ir" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_16ir', '_16ir'); ELVPlannedNA();" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_16ir" runat="server" Width="75px" Text="0"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                DOOR INTERCOM ALERT/BELL
                            </td>
                            <td  class="tdstyle1">
                                N/A
                                <input id="chk_16ppt" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_16ppt', '_16ppt'); ELVPlannedNA();" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_16ppt" runat="server" Width="75px" Text="0"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                AUDIO/VISUAL TEST
                            </td>
                            <td  class="tdstyle1"> N/A
                                <input id="chk_16cft" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_16cft', '_16cft'); ELVPlannedNA();" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_16cft" runat="server" Width="75px" Text="0"></asp:TextBox>
                            </td>
                        </tr>
                          <tr>
                            <td width="200PX">
                                DOOR RELEASE TEST
                            </td>
                            <td  class="tdstyle1">
                                N/A
                                <input id="chk_16sop" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_16sop', '_16sop'); ELVPlannedNA();" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_16sop" runat="server" Width="75px" Text="0"></asp:TextBox>
                            </td>
                            <td >
                              
                            </td>
                            <td>
                               
                            </td>
                            <td>
                              
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td >
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td width="200PX">
                                CONSULTANT ACCEPTED
                            </td>
                            <td  class="tdstyle1">
                                N/A
                                <input id="chk_16accept1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_16accept1', '_16accept1')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_16accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender151" runat="server" TargetControlID="_16accept1"
                                    PopupButtonID="_16accept1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                TEST SHEETS FILED
                            </td>
                            <td  class="tdstyle1">
                                N/A
                                <input id="chk_16filed1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_16filed1', '_16filed1')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_16filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender152" runat="server" TargetControlID="_16filed1"
                                    PopupButtonID="_16filed1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td >
                            </td>
                            <td >
                                &nbsp;
                            </td>
                            <td >
                                &nbsp;
                            </td>
                        </tr>
                      

                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td  class="tdstyle1">
                                N/A
                                <input id="chk_16actby" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_16actby', '_16actby')"
                                    runat="server" />
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_16actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_16commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td  class="tdstyle1">
                                N/A
                                <input id="chk_16actdt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_16actdt', '_16actdt')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_16actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender157" runat="server" TargetControlID="_16actdt"
                                    PopupButtonID="_16actdt" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_16btnupdate" runat="server" Text="Update" OnClick="_16btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_16btncancel" runat="server" Text="Cancel" OnClick="_16btncancel_Click" />
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td >
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div22" runat="server" style="position: absolute; z-index: 40; top: 30%;
                left: 35%">
                <asp:UpdateProgress ID="UpdateProgress23" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload16a" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>

    <asp:Button ID="btnDummy16a" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender16a" runat="server" TargetControlID="btnDummy16a"
        PopupControlID="pnlPopup16a" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup23" runat="server" Width="825px" Height="200px" Style="padding: 15px;
        display: none;" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 825px;" cellpadding="3" border="0" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_24lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td width="200px">
                                PLANNED COMPLETION DATE
                            </td>
                            <td class="tdstyle1" width="200px">
                                N/A
                                <input id="Checkbox3" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_24ir','_24ir');KichenPlannedNA();"
                                    runat="server" />
                            </td>
                            <td width="75px">
                                <asp:TextBox ID="_24pcd" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender71" runat="server" TargetControlID="_24pcd"
                                    PopupButtonID="_24pcd" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200px">
                                PLANNED POWER ON
                            </td>
                            <td class="tdstyle2" width="200px">
                                &nbsp;
                            </td>
                            <td width="75px">
                                <asp:TextBox ID="_24pwron" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender153" runat="server" TargetControlID="_24pwron"
                                    PopupButtonID="_24pwron" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="75px">
                            </td>
                            <td class="tdstyle3" width="75px">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                CONTINUITY/IR TEST
                            </td>
                            <td class="tdstyle1" width="200PX">
                                N/A
                                <input id="chk_24ir" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_24ir','_24ir');KichenPlannedNA();"
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_24ir" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender154" runat="server" TargetControlID="_24ir"
                                    PopupButtonID="_24ir" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                FUNCTIONAL TEST (@max Amps)
                            </td>
                            <td class="tdstyle2" width="200PX">
                                N/A
                                <input id="chk_24ft" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_24ft','_24ft');KichenPlannedNA();"
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_24ft" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender158" runat="server" TargetControlID="_24ft"
                                    PopupButtonID="_24ft" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                INTERFACE TEST
                            </td>
                            <td class="tdstyle3" width="200PX">
                                N/A
                                <input id="chk_24it" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_24it','_24it');KichenPlannedNA();"
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_24it" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender159" runat="server" TargetControlID="_24it"
                                    PopupButtonID="_24it" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td width="200PX">
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1" width="200PX">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_24accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender148" runat="server" TargetControlID="_24accept1"
                                    PopupButtonID="_24accept1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle2" width="200PX">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_24filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender149" runat="server" TargetControlID="_24filed1"
                                    PopupButtonID="_24filed1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                            </td>
                            <td class="tdstyle3" width="200PX">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_24actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_24commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="_24actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender150" runat="server" TargetControlID="_24actdt"
                                    PopupButtonID="_24actdt" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_24btnupdate" runat="server" Text="Update" OnClick="_24btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_24btncancel" runat="server" Text="Cancel" OnClick="_24btncancel_Click" />
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div23" runat="server" style="position: absolute; z-index: 40; top: 30%;
                left: 35%">
                <asp:UpdateProgress ID="UpdateProgress24" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload23" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy23" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender23" runat="server" TargetControlID="btnDummy23"
        PopupControlID="pnlPopup23" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup26" runat="server" Width="850px" Height="300px" Style="padding: 15px;
        display: none" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 850px" border="0" cellpadding="3" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_28lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PLANNED COMPLETION DATE
                            </td>
                            <td class="tdstyle1" width="200PX">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_28pcd" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender75" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_28pcd" TargetControlID="_28pcd">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle2" width="200PX">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle3" width="200PX">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                TESTED &AMP; COMM.
                            </td>
                            <td class="tdstyle1" width="200PX">
                                N/A
                                <input id="chk_28tcom" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_28tcom','_28tcom');HVTPlannedNA();"
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_28tcom" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender72" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_28tcom" TargetControlID="_28tcom">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                3RD PARTY INSPECTED
                            </td>
                            <td class="tdstyle2" width="200PX">
                                N/A
                                <input id="chk_28tpi" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_28tpi','_28tpi');HVTPlannedNA();"
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_28tpi" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender73" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_28tpi" TargetControlID="_28tpi">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle3" width="200PX">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="9" align="center">
                                LIFE AND SAFETY FUNCTIONAL TESTS
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                EMERGENCY LIGHTING
                            </td>
                            <td class="tdstyle1" width="200PX">
                                N/A
                                <input id="chk_28el" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_28el','_28el');HVTPlannedNA();"
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_28el" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender182" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_28el" TargetControlID="_28el">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                POWER FAILURE MODE
                            </td>
                            <td class="tdstyle2" width="200PX">
                                N/A
                                <input id="chk_28pfm" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_28pfm','_28pfm');HVTPlannedNA();"
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_28pfm" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender183" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_28pfm" TargetControlID="_28pfm">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                MONITORING SYSTEM
                            </td>
                            <td class="tdstyle3" width="200PX">
                                N/A
                                <input id="chk_28ms" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_28ms','_28ms');HVTPlannedNA();"
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_28ms" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender74" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_28icom" TargetControlID="_28icom">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                INTERCOM
                            </td>
                            <td class="tdstyle3" width="200PX">
                                N/A
                                <input id="chk_28icom" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_28icom','_28icom');HVTPlannedNA();"
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_28icom" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender184" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_28icom" TargetControlID="_28icom">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                BMS / FIRE ALARM INTERFACE
                            </td>
                            <td class="tdstyle2" width="200PX">
                                N/A
                                <input id="chk_28fai" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_28fai','_28fai');HVTPlannedNA();"
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_28fai" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_28pc3_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_28fai" TargetControlID="_28fai">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle3" width="200PX">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td colspan="9" align="center">
                                FINAL TEST SHEETS
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="_28accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender185" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_28accept1" TargetControlID="_28accept1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="_28filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender186" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_28filed1" TargetControlID="_28filed1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_28actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_28commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="_28actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender190" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_28actdt" TargetControlID="_28actdt">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_28btnupdate" runat="server" Text="Update" OnClick="_28btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_28btncancel" runat="server" Text="Cancel" OnClick="_28btncancel_Click" />
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td class="tdstyle3">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div1" runat="server" style="position: absolute; z-index: 40; top: 30%; left: 35%">
                <asp:UpdateProgress ID="UpdateProgress27" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image01" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy26" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender26" runat="server" TargetControlID="btnDummy26"
        PopupControlID="pnlPopup26" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup9" runat="server" Width="825px" Height="330px" Style="padding: 15px;
        display: none;" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 825px" border="0" cellpadding="3" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_9lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200px">
                                PLANNED COMPLETION DATE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_9pcd" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_9pcd','_9pcd')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_9pcd" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_9pcd_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_9pcd" TargetControlID="_9pcd">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:HiddenField ID="typehdn" runat="server" />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td align="center" colspan="9">
                                FUSIBLE LINK FIRE DAMPER
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                ACCESSIBILITY ACCEPTABLE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_9aa" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_9aa','_9aa');FDPlannedNA()" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_9aa" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender161" runat="server" TargetControlID="_9aa"
                                    PopupButtonID="_9aa" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                DROP TEST PASSED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_9dtp" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_9dtp','_9dtp');FDPlannedNA()" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_9dtp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender162" runat="server" TargetControlID="_9dtp"
                                    PopupButtonID="_9dtp" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                RESET PASSED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_9rp" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_9rp','_9rp');FDPlannedNA()" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_9rp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender163" runat="server" TargetControlID="_9rp"
                                    PopupButtonID="_9rp" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr style="background-color: #092443; color: White">
                            <td align="center" colspan="9">
                                MOTORISED SMOKE FIRE DAMPER
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                MANUEL OPEN OPERATION
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_9moo" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_9moo','_9moo');FDPlannedNA()" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_9moo" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender164" runat="server" TargetControlID="_9moo"
                                    PopupButtonID="_9moo" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                SPRING RETURN OPERATION
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_9sro" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_9sro','_9sro');FDPlannedNA()" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_9sro" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender165" runat="server" TargetControlID="_9sro"
                                    PopupButtonID="_9sro" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                END SWITCH TEST
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_9est" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_9est','_9est');FDPlannedNA()" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_9est" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender166" runat="server" TargetControlID="_9est"
                                    PopupButtonID="_9est" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                POWER OPEN/ SPRING RETURN TEST
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_9psrt" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_9psrt','_9psrt');FDPlannedNA()" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_9psrt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender167" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_9psrt" TargetControlID="_9psrt">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                <asp:Label ID="lblicom" runat="server" Text="INSTALLATION COMPLETION SIGN OFF"></asp:Label>
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_9icom" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_9icom','_9icom')"
                                    runat="server" />
                            </td>
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_9icom" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_9sro0_CalendarExtender" runat="server" ClearTime="true"
                                    Format="dd/MM/yyyy" PopupButtonID="_9icom" TargetControlID="_9icom">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td width="75PX">
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_9accept1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_9accept1','_9accept1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_9accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender168" runat="server" TargetControlID="_9accept1"
                                    PopupButtonID="_9accept1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_9filed1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_9filed1','_9filed1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_9filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender169" runat="server" TargetControlID="_9filed1"
                                    PopupButtonID="_9filed1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_9actby" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_9actby','_9actby')"
                                    runat="server" />
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_9actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_9commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td class="tdstyle1">
                                N/A
                                <input id="chk_9actdt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_9actdt','_9actdt')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_9actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender170" runat="server" TargetControlID="_9actdt"
                                    PopupButtonID="_9actdt" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_9btnupdate" runat="server" Text="Update" OnClick="_9btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_9btncancel" runat="server" Text="Cancel" OnClick="_9btncancel_Click" />
                            </td>
                            <td align="left" class="tdstyle1">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td class="tdstyle1">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div18" runat="server" style="position: absolute; z-index: 40; top: 30%;
                left: 35%">
                <asp:UpdateProgress ID="UpdateProgress10" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload9" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy9" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender9" runat="server" TargetControlID="btnDummy9"
        PopupControlID="pnlPopup9" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup20" runat="server" Width="850px" Height="225px" Style="padding: 15px;
        display: none" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 850px;" cellpadding="3" border="0" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_14lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                PLANNED COMPLETION DATE
                            </td>
                            <td class="tdstyle4">
                                N/A
                                <input id="chk_14pcd" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_14pcd','_14pcd')" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_14pcd" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender14_pcd" runat="server" TargetControlID="_14pcd"
                                    PopupButtonID="_14pcd" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                CONTINUITY/IR TEST
                            </td>
                            <td class="tdstyle4">
                                N/A
                                <input id="chk_14cit" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_14cit','_14cit');AVI_PlannedNA();" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_14cit" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                DOOR INTERCOM ALERT/BELL
                            </td>
                            <td class="tdstyle5">
                                N/A
                                <input id="chk_14diab" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_14diab','_14diab');AVI_PlannedNA();" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_14diab" runat="server" Width="75px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                AUDIO/VISUAL TEST
                            </td>
                            <td class="tdstyle6">
                                N/A
                                <input id="chk_14avt" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_14avt','_14avt');AVI_PlannedNA();" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_14avt" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                DOOR RELEASE TEST
                            </td>
                            <td class="tdstyle4">
                                N/A
                                <input id="chk_14drt" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_14drt','_14drt');AVI_PlannedNA();" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_14drt" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                &nbsp;
                            </td>
                            <td class="tdstyle6">
                                &nbsp;
                            </td>
                            <td width="75PX">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED
                            </td>
                            <td class="tdstyle4">
                                N/A
                                <input id="chk_14accept1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_14accept1','_14accept1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_14accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender171" runat="server" TargetControlID="_14accept1"
                                    PopupButtonID="_14accept1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED
                            </td>
                            <td class="tdstyle5">
                                N/A
                                <input id="chk_14filed1" type="checkbox" style="vertical-align: middle" runat="server"
                                    onclick="_checked('chk_14filed1','_14filed1')" />
                            </td>
                            <td>
                                <asp:TextBox ID="_14filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender172" runat="server" TargetControlID="_14filed1"
                                    PopupButtonID="_14filed1" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:TextBox ID="_14noof" runat="server" Width="75px" Style="display: none"></asp:TextBox>
                            </td>
                            <td class="tdstyle6">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION BY&nbsp;
                            </td>
                            <td class="tdstyle4">
                                N/A
                                <input id="chk_14actby" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_14actby','_14actby')"
                                    runat="server" />
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_14actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle5">
                                &nbsp;
                            </td>
                            <td>
                                COMMENTS
                            </td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_14commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                ACTION DATE
                            </td>
                            <td class="tdstyle4">
                                N/A
                                <input id="chk_14actdt" type="checkbox" style="vertical-align: middle" onclick="_checked('chk_14actdt','_14actdt')"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="_14actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender173" runat="server" TargetControlID="_14actdt"
                                    PopupButtonID="_14actdt" ClearTime="true" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle5">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="tdstyle4">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="_14btnupdate" runat="server" Text="Update" OnClick="_14btnupdate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_14btncancel" runat="server" Text="Cancel" OnClick="_14btncancel_Click" />
                            </td>
                            <td align="left" class="tdstyle5">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td class="tdstyle6">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div19" runat="server" style="position: absolute; z-index: 40; top: 30%;
                left: 35%">
                <asp:UpdateProgress ID="UpdateProgress21" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload20" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy20" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender20" runat="server" TargetControlID="btnDummy20"
        PopupControlID="pnlPopup20" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    </form>

    <script type="text/javascript">

        function pageLoad() {
        }


        function _checked(sender, target) {
            var _chk = document.getElementById(sender).checked;
            var _txt = document.getElementById(target);
            if (_chk == true) {
                _txt.value = "N/A";
                _txt.disabled = true;
            }
            else {
                _txt.value = "";
                _txt.disabled = false;
            }
        }

        function _cleared(sender, target) {
            var _chk = document.getElementById(sender).checked;
            var _txt = document.getElementById(target);
            _txt.value = "";
            if (_chk == true) {
                _txt.disabled = true;
                _txt.value = "N/A";
            }
            else {
                _txt.disabled = false;
                _txt.value = "";
            }
        }

        function GenPlannedNA() {
            var pdate = document.getElementById("_4pcd");

            var chk1 = document.getElementById("chk_4pc").checked;
            var chk2 = document.getElementById("chk_4as").checked;
            var chk3 = document.getElementById("chk_4lb").checked;
            var chk4 = $("#chk_4cable").checked;
            var chk5 = $("#chk_4sol").checked;

            if (chk1 == true && chk2 == true && chk3 == true) {
                pdate.disabled = true;

                pdate.value = "N/A";

                $("#chk_4accept1").trigger('click');
                $("#chk_4filed1").trigger('click');

            }
            else {
                pdate.disabled = false;
                if (pdate.value == "N/A") pdate.value = "";

                if (document.getElementById("chk_4accept1").checked == true) $("#chk_4accept1").trigger('click');
                if (document.getElementById("chk_4filed1").checked == true) $("#chk_4filed1").trigger('click');

            }        
        }
        function ECBSPlannaedNA() {

            var pdate = document.getElementById("_7pc");

            var chk1 = document.getElementById("chk_7cir").checked;
            var chk2 = document.getElementById("chk_7ft").checked;
            var chk3 = document.getElementById("chk_7co").checked;
            var chk4 = document.getElementById("chk_7ll").checked;
            var chk5 = document.getElementById("chk_7du").checked;
            var chk6 = document.getElementById("chk_7pch").checked;
            var chk7 = document.getElementById("chk_7add").checked;

            if (chk1 == true && chk2 == true && chk3 == true && chk4 == true && chk5 == true && chk6 == true && chk7 == true) {
                pdate.value = "N/A";
                pdate.disabled = true;
            }
            else {
                pdate.disabled = false;
                if (pdate.value = "N/A") pdate.value = "";
            }
        }


        function ph3PlannedNA() {
            var pdate = document.getElementById("_19pcd");

            var chk1 = document.getElementById("chk_19rsit").checked;
            var chk2 = document.getElementById("chk_19sac").checked;
            var chk3 = document.getElementById("chk_19fbit").checked;

            if (chk1 == true && chk2 == true && chk3 == true) {
                pdate.value = "N/A";
                pdate.disabled = true;
            }
            else {
                pdate.disabled = false;
                document.getElementById("chk_19pcd").checked = false;
                if (pdate.value = "N/A") pdate.value = "";
            }
        }
        function _13PlannedNA() {
            var pdate = document.getElementById("_13pcd");

            var chk1 = document.getElementById("chk_13cvl").checked;
            var chk2 = document.getElementById("chk_13cvh").checked;
            var chk3 = document.getElementById("chk_13ast").checked;
            var chk4 = document.getElementById("chk_13rbst").checked;
            var chk5 = document.getElementById("chk_13cit").checked;

            if (chk1 == true && chk2 == true && chk3 == true && chk4 == true && chk5 == true) {
                pdate.value = "N/A";
                pdate.disabled = true;
            }
            else {
                pdate.disabled = false;
                document.getElementById("chk_13pcd").checked = false;
                if (pdate.value == "N/A") pdate.value = "";
            }

        }
        function _11PlannedNA() {
            var pdate = document.getElementById("_11pcd");

            var chk1 = document.getElementById("chk_11cit").checked;
            var chk2 = document.getElementById("chk_11lct").checked;
            var chk3 = document.getElementById("chk_11apt").checked;
            var chk4 = document.getElementById("chk_11phgt").checked;


            if (chk1 == true && chk2 == true && chk3 == true && chk4 == true) {
                pdate.value = "N/A";
                pdate.disabled = true;
            }
            else {
                pdate.disabled = false;
                if (pdate.value == "N/A") pdate.value = "";
            }
        }
        function _12PlannedNA() {
            var pdate = document.getElementById("_12pcd");

            var chk1 = document.getElementById("chk_12ct").checked;
            if (chk1 == true) {
                pdate.value = "N/A";
                pdate.disabled = true;
            }
            else {
                pdate.disabled = false;
                if (pdate.value == "N/A") pdate.value = "";
            }
        }
        function _26PlannedNA() {
            var pdate = document.getElementById("_26pcd");

            var chk1 = document.getElementById("chk_26ct").checked;
            var chk2 = document.getElementById("chk_26pct").checked;
            var chk3 = document.getElementById("chk_26comm").checked;
            if (chk1 == true && chk2 == true && chk3 == true) {
                pdate.disabled = true;
            }
            else
                pdate.disabled = false;

        }
        function _25PlannedNA() {
            var pdate = document.getElementById("_25pcd");

            var chk1 = document.getElementById("chk_25apfec").checked;
            var chk2 = document.getElementById("chk_25amp").checked;
            var chk3 = document.getElementById("chk_25aebt").checked;
            if (chk1 == true && chk2 == true && chk3 == true) {
                pdate.disabled = true;
            }
            else
                pdate.disabled = false;

        }
        function ACSPlannedNA() {
            var pdate = document.getElementById("_22pcd");

            var chk1 = document.getElementById("chk_22cit").checked;
            var chk2 = document.getElementById("chk_22apt").checked;
            var chk3 = document.getElementById("chk_22fat").checked;
            var chk4 = document.getElementById("chk_22acs").checked;
            var chk5 = document.getElementById("chk_22pft").checked;
            var chk6 = document.getElementById("chk_22it").checked;
            var chk7 = document.getElementById("chk_22phgt").checked;


            if (chk1 == true && chk2 == true && chk3 == true && chk4 == true && chk5 == true && chk6 == true && chk7 == true) {
                pdate.value = "N/A";
                pdate.disabled = true;
            }
            else {
                pdate.disabled = false;
                if (pdate.value == "N/A") pdate.value = "";
            }
        }
        function PAVAPlannedNA() {
            var pdate = document.getElementById("_27pcd");

            var chk1 = document.getElementById("chk_27cit").checked;
            var chk2 = document.getElementById("chk_27dl").checked;
            var chk3 = document.getElementById("chk_27pm").checked;
            var chk4 = document.getElementById("chk_27ast").checked;



            if (chk1 == true && chk2 == true && chk3 == true && chk4 == true) {
                pdate.value = "";
                pdate.disabled = true;
            }
            else
                pdate.disabled = false;



        }
        function ELVPlannedNA() {
            var pdate = document.getElementById("_16pcd");

            var chk1 = document.getElementById("chk_16ir").checked;
            var chk2 = document.getElementById("chk_16ppt").checked;
            var chk3 = document.getElementById("chk_16cft").checked;
            var chk4 = document.getElementById("chk_16sop").checked;
            var chk5 = document.getElementById("chk_16ght").checked;



            if (chk1 == true && chk2 == true && chk3 == true && chk4 == true && chk5 == true) {
                pdate.value = "N/A";
                pdate.disabled = true;
            }
            else {
                pdate.disabled = false;
                if (pdate.value == "N/A") pdate.value = "";
            }
        }

        function HVTPlannedNA() {
            var pdate = document.getElementById("_28pcd");

            var chk1 = document.getElementById("chk_28tcom").checked;
            var chk2 = document.getElementById("chk_28tpi").checked;
            var chk3 = document.getElementById("chk_28el").checked;
            var chk4 = document.getElementById("chk_28pfm").checked;
            var chk5 = document.getElementById("chk_28ms").checked;
            var chk6 = document.getElementById("chk_28icom").checked;
            var chk7 = document.getElementById("chk_28fai").checked;



            if (chk1 == true && chk2 == true && chk3 == true && chk4 == true && chk5 == true && chk6 == true && chk7 == true) {
                pdate.value = "";
                pdate.disabled = true;
            }
            else
                pdate.disabled = false;
        }
        function KichenPlannedNA() {
            var pdate = document.getElementById("_24pcd");

            var chk1 = document.getElementById("chk_24ir").checked;
            var chk2 = document.getElementById("chk_24ft").checked;
            var chk3 = document.getElementById("chk_24it").checked;




            if (chk1 == true && chk2 == true && chk3 == true) {
                pdate.value = "";
                pdate.disabled = true;
            }
            else
                pdate.disabled = false;



        }
        function LV_PlannedNA1() {
            var pdate = document.getElementById("_5ptp");

            var chk1 = document.getElementById("chk_5tor").checked;
            var chk2 = document.getElementById("chk_5ir").checked;
            var chk3 = document.getElementById("chk_5pr").checked;
            var chk4 = document.getElementById("chk_5si").checked;
            var chk5 = document.getElementById("chk_5cr").checked;
            var chk6 = document.getElementById("chk_5fn").checked;



            if (chk1 == true && chk2 == true && chk3 == true && chk4 == true && chk5 == true && chk6 == true) {
                pdate.value = "N/A";
                pdate.disabled = true;
            }
            else {
                pdate.disabled = false;

                if (pdate.value == "N/A") pdate.value = "";
            }



        }
        function LV_PlannedNA2() {
            var pdate = document.getElementById("_5ctp");

            var chk1 = document.getElementById("chk_5tc").checked;
            var chk2 = document.getElementById("chk_5cc").checked;




            if (chk1 == true && chk2 == true) {
                pdate.value = "N/A";
                pdate.disabled = true;
            }
            else {
                pdate.disabled = false;
                if (pdate.value == "N/A") pdate.value = "";
            }



        }
        function LV_PlannedNA3() {
            var pdate = document.getElementById("_5ltp");

            var chk1 = document.getElementById("chk_5tl").checked;
            var chk2 = document.getElementById("chk_5lc").checked;



            if (chk1 == true && chk2 == true) {
                pdate.value = "N/A";
                pdate.disabled = true;
            }
            else {
                pdate.disabled = false;
                if (pdate.value == "N/A") pdate.value = "";
            }



        }
        function HVMV_PlannedNA() {
            var pdate = document.getElementById("txtpanelplanned");

            //var chk0 = document.getElementById("chk_2pt").checked;
            var chk1 = document.getElementById("chk_2tor").checked;
            var chk2 = document.getElementById("chk_2ir").checked;
            var chk3 = document.getElementById("chk_2hi").checked;
            var chk4 = document.getElementById("chk_2vt").checked;
            var chk5 = document.getElementById("chk_2ct").checked;
            var chk6 = document.getElementById("chk_2pi").checked;
            var chk7 = document.getElementById("chk_2si").checked;
            var chk8 = document.getElementById("chk_2cr").checked;
            var chk9 = document.getElementById("chk_2fn").checked;
            var chk10 = document.getElementById("chk_2pr").checked;

            if (chk1 == true && chk2 == true && chk3 == true && chk4 == true && chk5 == true && chk6 == true && chk7 == true && chk8 == true && chk9 == true && chk10 == true) {
                pdate.value = "N/A";
                pdate.disabled = true;
                document.getElementById("chk_2pt").checked = true;
            }
            else {
                pdate.disabled = false;
                document.getElementById("chk_2pt").checked = false;
                if (pdate.value == "N/A") pdate.value = "";
            }

        }
        function HVMV_PlannedNACable() {
            var pdate = document.getElementById("txtcableplanned");
            var pcomplete = document.getElementById("_2cte");

            var chk0 = document.getElementById("chk_2cp");
            var chk1 = document.getElementById("chk_2cable").checked;
            var chk2 = document.getElementById("chk_2ttt").checked;
            var chk3 = document.getElementById("chk_2cte");

            if (chk1 == true && chk2 == true) {
                chk0.checked = true; chk3.checked = true;

                pdate.value = "N/A"; pdate.disabled = true;
                pcomplete.value = "N/A"; pcomplete.disabled = true;
            }
            else {
                pdate.disabled = false; pcomplete.disabled = false;
                chk0.checked = false; chk3.checked = false;
                if (pdate.value == "N/A") pdate.value = "";
                if (pcomplete.value == "N/A") pcomplete.value = "";
            }
        }
        function mechPlannedPreCommNA() {
            var pcdate = document.getElementById("_8pcp");
            var chk = document.getElementById("chk_8pc1").checked;
            if (chk == true) {
                pcdate.value = "N/A";
                pcdate.disabled = true;
            }
            else {
                pcdate.value = "";
                pcdate.disabled = false;
            }
        }

        function mechPlannedCommNA() {

            var pcdate1 = document.getElementById("_8cp");
            var chk1 = document.getElementById("chk_8co1").checked;
            if (chk1 == true) {
                pcdate1.value = "N/A";
                pcdate1.disabled = true;
            }
            else {
                pcdate1.value = "";
                pcdate1.disabled = false;
            }
        }
        function ph1PlannedPreCommNA() {
            var pcdate = document.getElementById("_17pcp");
            var chk = document.getElementById("chk_17pc1").checked;
            if (chk == true) {
                pcdate.value = "N/A";
                pcdate.disabled = true;
            }
            else {
                pcdate.value = "";
                pcdate.disabled = false;
            }
        }
        function _21PlannedNA() {
            var pcdate = document.getElementById("_21pcd");
            var chk1 = document.getElementById("chk_21pf").checked;
            var chk2 = document.getElementById("chk_21fvr").checked;
            var chk3 = document.getElementById("chk_21cc").checked;
            var chk4 = document.getElementById("chk_21facc").checked;
            var chk5 = document.getElementById("chk_21bfc").checked;
            var chk6 = document.getElementById("chk_21fct").checked;
            if (chk1 == true && chk2 == true && chk3 == true && chk4 == true && chk5 == true && chk6 == true) {
                pcdate.value = "N/A";
                pcdate.disabled = true;
            }
            else {
                pcdate.disabled = false;
                pcdate.value = "";
            }
        }
        function ph1PlannedCommNA() {

            var pcdate1 = document.getElementById("_17cp");
            var chk1 = document.getElementById("chk_17co1").checked;
            if (chk1 == true) {
                pcdate1.value = "N/A";
                pcdate1.disabled = true;
            }
            else {
                pcdate1.value = "";
                pcdate1.disabled = false;
            }
        }
        function Trans_PlannedNA() {
            debugger;
            var pdate = document.getElementById("_3transformerplanned");
            var pdate1 = document.getElementById("_3cableplanned");            
            var chk1 = document.getElementById("chk_3ir").checked;
            var chk2 = document.getElementById("chk_3rt").checked;
            var chk3 = document.getElementById("chk_3wr").checked;
            var chk4 = document.getElementById("chk_3vg").checked;
            var chk5 = document.getElementById("chk_3trf").checked;
            var chk6 = document.getElementById("chk_3cable").checked;

            if (chk1 == true && chk2 == true && chk3 == true && chk4 == true && chk5 == true) {
                pdate.value = "N/A";
                pdate.disabled = true;
            }
            else {
                pdate.disabled = false;
                if (pdate.value == "N/A") pdate.value = "";
            }         
            if (chk6 == true) {
                pdate1.value = "N/A";
                pdate1.disabled = true;
            }
            else {             
                pdate1.disabled = false;
                if (pdate1.value == "N/A") pdate1.value = "";
            }
                      
        }
        function AVI_PlannedNA() {
            var pdate = document.getElementById("_14pcd");

            var chk1 = document.getElementById("chk_14cit").checked;
            var chk2 = document.getElementById("chk_14diab").checked;
            var chk3 = document.getElementById("chk_14avt").checked;
            var chk4 = document.getElementById("chk_14avt").checked;

            if (chk1 == true && chk2 == true && chk3 == true && chk4 == true) {
                pdate.value = "N/A";
                pdate.disabled = true;
            }
            else {
                pdate.disabled = false;

                if (pdate.value == "N/A") pdate.value = "";
            }



        }
        function SetAcceptNA(arg1, arg2, arg3) {
        debugger
            if (document.getElementById(arg1).checked) {
                $("#" + arg2).trigger('click');
                $("#" + arg3).trigger('click');
            }
            else {
                      if ($("#" + arg2).checked == true)  
                             $("#" + arg2).trigger('click');
                      if ($("#" + arg3).checked == true)  
                             $("#" + arg3).trigger('click');

              }
        }

        function FDPlannedNA() {
            var type = document.getElementById("typehdn");
            var pdate = document.getElementById("_9pcd");
            var chkpcd = document.getElementById("chk_9pcd");
            if (type.value == "FD") {
                var chk1 = document.getElementById("chk_9aa").checked;
                var chk2 = document.getElementById("chk_9dtp").checked;
                var chk3 = document.getElementById("chk_9rp").checked;
                if (chk1 == true && chk2 == true && chk3 == true) {
                    pdate.value = "N/A";
                    pdate.disabled = true;
                }
                else {
                    pdate.disabled = false;
                    if (pdate.value == "N/A") pdate.value = "";

                }
            }
            else if (type.value == "MSFD" || type.value == "MD") {
                var chk1 = document.getElementById("chk_9moo").checked;
                var chk2 = document.getElementById("chk_9sro").checked;
                var chk3 = document.getElementById("chk_9est").checked;
                var chk4 = document.getElementById("chk_9psrt").checked;
                if (chk1 == true && chk2 == true && chk3 == true && chk4 == true) {
                    pdate.value = "N/A";
                    pdate.disabled = true;
                }
                else {
                    pdate.disabled = false;
                    if (pdate.value == "N/A") pdate.value = "";
                }
            }
        }     

        function CheckUncheckNA(sender, target) {
            var _chk = document.getElementById(sender);
            var _txt = document.getElementById(target);
            if (_txt.value == "N/A") {
                _chk.checked = true;
            }
            else
                _chk.checked = false;
        }
    </script>

</body>
</html>
