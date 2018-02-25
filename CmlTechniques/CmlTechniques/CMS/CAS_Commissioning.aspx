<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CAS_Commissioning.aspx.cs"
    Inherits="CmlTechniques.CMS.CAS_Commissioning" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      

    <script type="text/javascript">

        function pageLoad() {
        }
    
    </script>

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
    
    </script>

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
        <asp:Label ID="lbluid" runat="server" Text="Label" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblprj" runat="server" Text="Label" CssClass="hidden"></asp:Label>
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
    <asp:Panel ID="pnlPopup1" runat="server" Width="900px" Height="180px" Style="padding: 15px;display:none" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 900px" border="0" cellpadding="3" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_30lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                Cable Test</td>
                            <td class="tdstyle8">
                                N/A
                                <input ID="chk_30ct" runat="server" onclick="_checked('chk_30ct','_30ct')" 
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_30ct" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                Functional Test</td>
                            <td class="tdstyle5">
                                N/A
                                <input ID="chk_30ft" runat="server" onclick="_checked('chk_30ft','_30ft')" 
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_30ft" runat="server" Width="75px"></asp:TextBox>
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
                                Consultant Accepted</td>
                            <td class="tdstyle8">
                                
                            </td>
                            <td>
                                <asp:TextBox ID="_30accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender57" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_30accept1" TargetControlID="_30accept1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                Test Sheets Filed
                            </td>
                            <td class="tdstyle5">
                               
                            </td>
                            <td>
                                <asp:TextBox ID="_30filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender58" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_30filed1" TargetControlID="_30filed1">
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
                                Action By
                            </td>
                            <td class="tdstyle8">
                               
                            </td>
                            <td>
                                <asp:TextBox ID="_30actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                Comments</td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_30commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                Action Date</td>
                            <td class="tdstyle8">
                               
                            </td>
                            <td>
                                <asp:TextBox ID="_30actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender56" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_30actdt" TargetControlID="_30actdt">
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
                                <asp:Button ID="_30btnupdate" runat="server" Text="Update" 
                                    onclick="_30btnupdate_Click"  />
                            </td>
                            <td align="left">
                                <asp:Button ID="_30btncancel" runat="server" Text="Cancel" 
                                    onclick="_30btncancel_Click"  />
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
        PopupControlID="pnlPopup1" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    
    <asp:Panel ID="pnlPopup2" runat="server" Width="900px" Height="180px" Style="padding: 15px;display:none" BackColor="White">
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="font-size: x-small; width: 900px" border="0" cellpadding="3" cellspacing="0">
                        <tr>
                            <td colspan="9" style="background-color: #092443; height: 25px">
                                <asp:Label ID="_12lbl" runat="server" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                Cable Test</td>
                            <td class="tdstyle8">
                                N/A
                                <input ID="chk_12ct" runat="server" onclick="_checked('chk_12ct','_12ct')" 
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_12ct" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                Functional Test</td>
                            <td class="tdstyle5">
                                N/A
                                <input ID="chk_12ft" runat="server" onclick="_checked('chk_12ft','_12ft')" 
                                    style="vertical-align: middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_12ft" runat="server" Width="75px"></asp:TextBox>
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
                                Consultant Accepted</td>
                            <td class="tdstyle8">
                                
                            </td>
                            <td>
                                <asp:TextBox ID="_12accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_12accept1" TargetControlID="_12accept1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                Test Sheets Filed
                            </td>
                            <td class="tdstyle5">
                               
                            </td>
                            <td>
                                <asp:TextBox ID="_12filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_12filed1" TargetControlID="_12filed1">
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
                                Action By
                            </td>
                            <td class="tdstyle8">
                               
                            </td>
                            <td>
                                <asp:TextBox ID="_12actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;
                            </td>
                            <td>
                                Comments</td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_12commts" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #83C8EE">
                            <td>
                                Action Date</td>
                            <td class="tdstyle8">
                               
                            </td>
                            <td>
                                <asp:TextBox ID="_12actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                    PopupButtonID="_12actdt" TargetControlID="_12actdt">
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
                                <asp:Button ID="_12btnupdate" runat="server" Text="Update" 
                                    onclick="_12btnupdate_Click"  />
                            </td>
                            <td align="left">
                                <asp:Button ID="_12btncancel" runat="server" Text="Cancel" 
                                    onclick="_12btncancel_Click"  />
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
            <div id="Div1" runat="server" style="position: absolute; z-index: 40; top: 30%; left: 35%">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="imgload8" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                            Width="250px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Button2"
        PopupControlID="pnlPopup2" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup15" runat="server" Width="825px" Height="210px" 
                style="padding:15px;display:none;" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_13lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                        <tr>
                            <td width="200PX">
                                Continuity/ IR Test</td>
                            <td class="tdstyle1">N/A<input ID="chk_13cit" runat="server" onclick="_checked('chk_13cit','_13cit')" 
                                    style="vertical-align:middle" type="checkbox" /></td>
                            <td width="75PX">
                                <asp:TextBox ID="_13cit" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                              
                                 <asp:Label ID="lblvl" runat="server" Text="VSS View Locally" ></asp:Label>
                                </td>
                            <td class="tdstyle2">N/A<input ID="chk_13cvl" onclick="_checked('chk_13cvl','_13cvl')" 
                                    type="checkbox" style="vertical-align:middle; width: 20px;" 
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_13cvl" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                               
                                 <asp:Label ID="lblvh" runat="server" Text="VSS View from Headend" ></asp:Label>
                                </td>
                            <td class="tdstyle3">N/A<input ID="chk_13cvh" onclick="_checked('chk_13cvh','_13cvh')" 
                                    type="checkbox" style="vertical-align:middle" runat="server" /></td>
                            <td width="75PX">
                                <asp:TextBox ID="_13cvh" runat="server" Width="75px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                Addressing/ Software Test</td>
                            <td class="tdstyle1">
                                N/A
                                <input ID="chk_13ast" runat="server" onclick="_checked('chk_13ast','_13ast')" 
                                    style="vertical-align:middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_13ast" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                Recording/ Back-up Storage Test</td>
                            <td class="tdstyle2">
                                N/A
                                <input ID="chk_13rbst" runat="server" 
                                    onclick="_checked('chk_13rbst','_13rbst')" style="vertical-align:middle" 
                                    type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_13rbst" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                <asp:TextBox ID="_13noof" runat="server" style="display:none" Width="75px"></asp:TextBox>
                            </td>
                            <td class="tdstyle3">
                                &nbsp;</td>
                            <td width="75PX">
                            </td>
                    </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                Consultant Accepted</td>
                            <td class="tdstyle1">N/A
                                <input id="chk_13accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_13accept1','_13accept1')"/>
                                </td>
                            <td>
                                <asp:TextBox ID="_13accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender126" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_13accept1" TargetControlID="_13accept1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                Test Sheets Filed</td>
                            <td class="tdstyle2">N/A
                                <input id="chk_13filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_13filed1','_13filed1')"/>
                                </td>
                            <td>
                                <asp:TextBox ID="_13filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender130" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_13filed1" TargetControlID="_13filed1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td class="tdtdstyle3">
                                &nbsp;</td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color:#83C8EE">
                            <td>
                                Action By</td>
                            <td class="tdstyle1">N/A
                               <input id="chk_13actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_13actby','_13actby')" runat="server"/></td>
                            <td colspan="2">
                                <asp:TextBox ID="_13actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;</td>
                            <td>
                                Comments</td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_13commts" runat="server" Height="50px" TextMode="MultiLine" 
                                    Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color:#83C8EE">
                            <td>
                                Action Date</td>
                            <td class="tdstyle1">N/A
                             <input id="chk_13actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_13actdt','_13actdt')" runat="server"/></td>
                            <td>
                                <asp:TextBox ID="_13actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender131" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_13actdt" TargetControlID="_13actdt">
                                </asp:CalendarExtender>
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
                            <td class="tdstyle1">
                                &nbsp;</td>
                            <td align="right">
                                <asp:Button ID="_13btnupdate" runat="server" onclick="_13btnupdate_Click" 
                                    Text="Update" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_13btncancel" runat="server" onclick="_13btncancel_Click" 
                                    Text="Cancel" />
                            </td>
                            <td align="left" class="tdstyle2">
                                &nbsp;</td>
                            <td align="right">
                                &nbsp;</td>
                            <td>
                            </td>
                            <td class="tdtdstyle3">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    
                
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
                 <div id="Div14" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress16" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload15" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
     
     
        <asp:Button ID="btnDummy15" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender15" runat="server" TargetControlID="btnDummy15"  PopupControlID="pnlPopup15" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
        <asp:Panel ID="pnlPopup16" runat="server" Width="900px" Height="250px" 
                style="padding:15px;display:none;" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:900px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_22lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            Continuity / IR Test</td>
                        <td class="tdstyle1">N/A <input ID="chk_22cit" onclick="_checked('chk_22cit','_22cit')" 
                                    type="checkbox" style="vertical-align:middle; width: 20px;" 
                                    runat="server" /></td>
                        <td width="75PX">
                            <asp:TextBox ID="_22cit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            Addressing / Programming Test</td>
                        <td class="tdstyle2">N/A <input ID="chk_22apt" onclick="_checked('chk_22apt','_22apt')" 
                                    type="checkbox" style="vertical-align:middle; width: 20px;" 
                                    runat="server" /></td>
                        <td width="75PX">
                            <asp:TextBox ID="_22apt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            Fault &amp; Alarm Tests</td>
                        <td class="tdtdstyle3">N/A <input ID="chk_22fat" onclick="_checked('chk_22fat','_22fat')" 
                                    type="checkbox" style="vertical-align:middle; width: 20px;" 
                                    runat="server" /></td>
                        <td width="75PX">
                            <asp:TextBox ID="_22fat" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            Access Card Swipe</td>
                        <td class="tdstyle1">N/A
                            <input ID="chk_22acs" runat="server" onclick="_checked('chk_22acs','_22acs')" 
                                style="vertical-align:middle; width: 20px;" type="checkbox" />
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_22acs" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            Power Failure Tests</td>
                        <td class="tdstyle2">N/A <input ID="chk_22pft" onclick="_checked('chk_22pft','_22pft')" 
                                    type="checkbox" style="vertical-align:middle; width: 20px;" 
                                    runat="server" />
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_22pft" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            <asp:TextBox ID="_22noof" runat="server" Width="75px" style="display:none"></asp:TextBox>
                            Interface Tests</td>
                        <td class="tdtdstyle3">N/A <input ID="chk_22it" onclick="_checked('chk_22it','_22it')" 
                                    type="checkbox" style="vertical-align:middle; width: 20px;" 
                                    runat="server" />
                        <td width="75PX">
                            <asp:TextBox ID="_22it" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            PC Headend / Gaphics Test</td>
                        <td class="tdstyle1">N/A <input ID="chk_22phgt" onclick="_checked('chk_22phgt','_22phgt')" 
                                    type="checkbox" style="vertical-align:middle; width: 20px;" 
                                    runat="server" />
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_22phgt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            Consultant Accepted</td>
                        <td class="tdstyle1">N/A
                            <input ID="chk_22accept1" runat="server" 
                                onclick="_checked('chk_22accept1','_22accept1')" 
                                style="vertical-align:middle; width: 20px;" type="checkbox" />
                            </td>
                        <td>
                            <asp:TextBox ID="_22accept1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender120" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_22accept1" TargetControlID="_22accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            Test Sheet Filed</td>
                        <td class="tdstyle2">N/A <input ID="chk_22filed1" onclick="_checked('chk_22filed1','_22filed1')" 
                                    type="checkbox" style="vertical-align:middle; width: 20px;" 
                                    runat="server" />
                            </td>
                        <td>
                            <asp:TextBox ID="_22filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender123" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_22filed1" TargetControlID="_22filed1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td>
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            Action By</td>
                        <td class="tdstyle1">N/A
                            <input ID="chk_22actby" runat="server" onclick="_checked('chk_22actby','_22actby')" 
                                style="vertical-align:middle; width: 20px;" type="checkbox" />
                            </td>
                        <td colspan="2">
                            <asp:TextBox ID="_22actby" runat="server" Width="250px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            Comments</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_22commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            Action Date</td>
                        <td class="tdstyle1">N/A
                            <input ID="chk_22actdt" runat="server" 
                                onclick="_checked('chk_22actdt','_22actdt')" 
                                style="vertical-align:middle; width: 20px;" type="checkbox" />
                            </td>
                        <td>
                            <asp:TextBox ID="_22actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender124" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_22actdt" TargetControlID="_22actdt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td align="right">
                            <asp:Button ID="_22btnupdate" runat="server" onclick="_22btnupdate_Click" 
                                Text="Update" />
                        </td>
                        <td align="left">
                            <asp:Button ID="_22btncancel" runat="server" Text="Cancel" 
                                onclick="_22btncancel_Click"   />
                        </td>
                        <td align="right">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                           
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
                 <div id="Div15" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress17" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload16" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy16" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender16" runat="server" TargetControlID="btnDummy16"  PopupControlID="pnlPopup16" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
        
        <asp:Button ID="btnDummy39" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender39" runat="server" TargetControlID="btnDummy39"  PopupControlID="pnlPopup39" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
         <asp:Panel ID="pnlPopup39" runat="server" Width="825px" Height="230px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel46" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_39lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                        <tr>
                            <td width="200PX">
                                CABLE TEST</td>
                            <td class="tdstyle1">N/A<input ID="chk_39ct" runat="server" onclick="_checked('chk_39ct','_39ct')" 
                                    style="vertical-align:middle" type="checkbox" /></td>
                            <td width="75PX">
                                <asp:TextBox ID="_39ct" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                REPEATER FUNCTIONAL TEST</td>
                            <td class="tdstyle2">N/A<input ID="chk_39rft" onclick="_checked('chk_39rft','_39rft')" 
                                    type="checkbox" style="vertical-align:middle; width: 20px;" 
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_39rft" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                ANTENNA FUNCTIONAL TEST</td>
                            <td class="tdtdstyle3">N/A<input ID="chk_39aft" onclick="_checked('chk_39aft','_39aft')" 
                                    type="checkbox" style="vertical-align:middle" runat="server" /></td>
                            <td width="75PX">
                                <asp:TextBox ID="_39aft" runat="server" Width="75px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                SPLITTER FUNCTIONAL TEST</td>
                            <td class="tdstyle1">
                                N/A
                                <input ID="chk_39sft" runat="server" onclick="_checked('chk_39sft','_39sft')" 
                                    style="vertical-align:middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_39sft" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                COUPLER FUNCTIONAL TEST</td>
                            <td class="tdstyle2">
                                N/A
                                <input ID="chk_39cft" runat="server" 
                                    onclick="_checked('chk_39cft','_39cft')" style="vertical-align:middle" 
                                    type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_39cft" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                <asp:TextBox ID="_39noof" runat="server" style="display:none" Width="75px"></asp:TextBox>
                            </td>
                            <td class="tdtdstyle3">
                                &nbsp;</td>
                            <td width="75PX">
                            </td>
                    </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED</td>
                            <td class="tdstyle1">N/A
                                <input id="chk_39accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_39accept1','_39accept1')"/>
                                </td>
                            <td>
                                <asp:TextBox ID="_39accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender237" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_39accept1" TargetControlID="_39accept1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED</td>
                            <td class="tdstyle2">N/A
                                <input id="chk_39filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_39filed1','_39filed1')"/>
                                </td>
                            <td>
                                <asp:TextBox ID="_39filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender390" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_39filed1" TargetControlID="_39filed1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td class="tdtdstyle3">
                                &nbsp;</td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color:#83C8EE">
                            <td>
                                ACTION BY&nbsp;</td>
                            <td class="tdstyle1">N/A
                               <input id="chk_39actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_39actby','_39actby')" runat="server"/></td>
                            <td colspan="2">
                                <asp:TextBox ID="_39actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;</td>
                            <td>
                                COMMENTS</td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_39commts" runat="server" Height="50px" TextMode="MultiLine" 
                                    Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color:#83C8EE">
                            <td>
                                ACTION DATE</td>
                            <td class="tdstyle1">N/A
                             <input id="chk_39actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_39actdt','_39actdt')" runat="server"/></td>
                            <td>
                                <asp:TextBox ID="_39actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender391" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_39actdt" TargetControlID="_39actdt">
                                </asp:CalendarExtender>
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
                            <td class="tdstyle1">
                                &nbsp;</td>
                            <td align="right">
                                <asp:Button ID="_39btnupdate" runat="server" onclick="_39btnupdate_Click" 
                                    Text="Update" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_39btncancel" runat="server" onclick="_39btncancel_Click" 
                                    Text="Cancel" />
                            </td>
                            <td align="left" class="tdstyle2">
                                &nbsp;</td>
                            <td align="right">
                                &nbsp;</td>
                            <td>
                            </td>
                            <td class="tdtdstyle3">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    
                
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
                 <div id="Div39" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress36" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload39"  runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        
                                    <asp:Button ID="btnDummy31" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender31" runat="server" TargetControlID="btnDummy31"  PopupControlID="pnlPopup31" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
         <asp:Panel ID="pnlPopup31" runat="server" Width="825px" Height="230px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_31lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                        <tr>
                            <td width="200PX">
                                CABLE TEST</td>
                            <td class="tdstyle1">N/A<input ID="chk_31ct" runat="server" onclick="_checked('chk_31ct','_31ct')" 
                                    style="vertical-align:middle" type="checkbox" /></td>
                            <td width="75PX">
                                <asp:TextBox ID="_31ct" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                FUNCTIONAL TEST</td>
                            <td class="tdstyle2">N/A<input ID="chk_31ft" onclick="_checked('chk_31ft','_31ft')" 
                                    type="checkbox" style="vertical-align:middle; width: 20px;" 
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_31ft" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                &nbsp;</td>
                            <td class="tdtdstyle3">&nbsp;</td>
                            <td width="75PX">
                                &nbsp;</td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED</td>
                            <td class="tdstyle1">N/A
                                <input id="chk_31accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_31accept1','_31accept1')"/>
                                </td>
                            <td>
                                <asp:TextBox ID="_31accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_31accept1" TargetControlID="_31accept1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED</td>
                            <td class="tdstyle2">N/A
                                <input id="chk_31filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_31filed1','_31filed1')"/>
                                </td>
                            <td>
                                <asp:TextBox ID="_31filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender310" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_31filed1" TargetControlID="_31filed1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td class="tdtdstyle3">
                              <asp:TextBox ID="_31noof" runat="server" style="display:none" Width="75px"></asp:TextBox>
                                &nbsp;</td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color:#83C8EE">
                            <td>
                                ACTION BY&nbsp;</td>
                            <td class="tdstyle1">N/A
                               <input id="chk_31actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_31actby','_31actby')" runat="server"/></td>
                            <td colspan="2">
                                <asp:TextBox ID="_31actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;</td>
                            <td>
                                COMMENTS</td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_31commts" runat="server" Height="50px" TextMode="MultiLine" 
                                    Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color:#83C8EE">
                            <td>
                                ACTION DATE</td>
                            <td class="tdstyle1">N/A
                             <input id="chk_31actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_31actdt','_31actdt')" runat="server"/></td>
                            <td>
                                <asp:TextBox ID="_31actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender311" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_31actdt" TargetControlID="_31actdt">
                                </asp:CalendarExtender>
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
                            <td class="tdstyle1">
                                &nbsp;</td>
                            <td align="right">
                                <asp:Button ID="_31btnupdate" runat="server" onclick="_31btnupdate_Click" 
                                    Text="Update" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_31btncancel" runat="server" onclick="_31btncancel_Click" 
                                    Text="Cancel" />
                            </td>
                            <td align="left" class="tdstyle2">
                                &nbsp;</td>
                            <td align="right">
                                &nbsp;</td>
                            <td>
                            </td>
                            <td class="tdtdstyle3">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    
                
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
                 <div id="Div31" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress3" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload31"  runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        
        
               
                                            <asp:Button ID="btnDummy33" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender33" runat="server" TargetControlID="btnDummy33"  PopupControlID="pnlPopup33" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
         <asp:Panel ID="pnlPopup33" runat="server" Width="825px" Height="200px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_33lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                        <tr>
                            <td width="200PX">
                                CABLE TESTED</td>
                            <td class="tdstyle1">N/A<input ID="chk_33ct" runat="server" onclick="_checked('chk_33ct','_33ct')" 
                                    style="vertical-align:middle" type="checkbox" /></td>
                            <td width="75PX">
                                <asp:TextBox ID="_33ct" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                FUNCTIONAL TESTS</td>
                            <td class="tdstyle2">N/A<input ID="chk_33ft" onclick="_checked('chk_33ft','_33ft')" 
                                    type="checkbox" style="vertical-align:middle; width: 20px;" 
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_33ft" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                &nbsp;</td>
                            <td class="tdtdstyle3">&nbsp;</td>
                            <td width="75PX">
                                &nbsp;</td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED</td>
                            <td class="tdstyle1">N/A
                                <input id="chk_33accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_33accept1','_33accept1')"/>
                                </td>
                            <td>
                                <asp:TextBox ID="_33accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_33accept1" TargetControlID="_33accept1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED</td>
                            <td class="tdstyle2">N/A
                                <input id="chk_33filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_33filed1','_33filed1')"/>
                                </td>
                            <td>
                                <asp:TextBox ID="_33filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender330" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_33filed1" TargetControlID="_33filed1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td class="tdtdstyle3">
                              <asp:TextBox ID="_33noof" runat="server" style="display:none" Width="75px"></asp:TextBox>
                                &nbsp;</td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color:#83C8EE">
                            <td>
                                ACTION BY&nbsp;</td>
                            <td class="tdstyle1">N/A
                               <input id="chk_33actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_33actby','_33actby')" runat="server"/></td>
                            <td colspan="2">
                                <asp:TextBox ID="_33actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;</td>
                            <td>
                                COMMENTS</td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_33commts" runat="server" Height="50px" TextMode="MultiLine" 
                                    Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color:#83C8EE">
                            <td>
                                ACTION DATE</td>
                            <td class="tdstyle1">N/A
                             <input id="chk_33actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_33actdt','_33actdt')" runat="server"/></td>
                            <td>
                                <asp:TextBox ID="_33actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender331" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_33actdt" TargetControlID="_33actdt">
                                </asp:CalendarExtender>
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
                            <td class="tdstyle1">
                                &nbsp;</td>
                            <td align="right">
                                <asp:Button ID="_33btnupdate" runat="server" onclick="_33btnupdate_Click" 
                                    Text="Update" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_33btncancel" runat="server" onclick="_33btncancel_Click" 
                                    Text="Cancel" />
                            </td>
                            <td align="left" class="tdstyle2">
                                &nbsp;</td>
                            <td align="right">
                                &nbsp;</td>
                            <td>
                            </td>
                            <td class="tdtdstyle3">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    
                
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
                 <div id="Div33" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress4" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload33"  runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        
              <asp:Button ID="btnDummy29" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender29" runat="server" TargetControlID="btnDummy29"  PopupControlID="pnlPopup29" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
         <asp:Panel ID="pnlPopup29" runat="server" Width="825px" Height="230px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_29lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                        <tr>
                            <td width="200PX">
                                CABLE CONTINUITY  TESTED</td>
                            <td class="tdstyle1">N/A<input ID="chk_29cct" runat="server" onclick="_checked('chk_29cct','_29cct')" 
                                    style="vertical-align:middle" type="checkbox" /></td>
                            <td width="75PX">
                                <asp:TextBox ID="_29cct" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                AUDIO FUNCTIONAL TESTS</td>
                            <td class="tdstyle2">N/A
                            <input ID="chk_29aft" onclick="_checked('chk_29aft','_29aft')" 
                                    type="checkbox" style="vertical-align:middle; width: 20px;" 
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_29aft" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                VIDEO FUNCTIONAL TEST&nbsp;</td>
                            <td class="tdtdstyle3">N/A
                             <input ID="chk_29vft" onclick="_checked('chk_29vft','_29vft')" 
                                    type="checkbox" style="vertical-align:middle; width: 20px;" 
                                    runat="server" />
                            </td>
                            <td width="75PX">
                             <asp:TextBox ID="_29vft" runat="server" Width="75px"></asp:TextBox>
                                &nbsp;</td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED</td>
                            <td class="tdstyle1">N/A
                                <input id="chk_29accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_29accept1','_29accept1')"/>
                                </td>
                            <td>
                                <asp:TextBox ID="_29accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender6" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_29accept1" TargetControlID="_29accept1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                TEST SHEETS FILED</td>
                            <td class="tdstyle2">N/A
                                <input id="chk_29filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_29filed1','_29filed1')"/>
                                </td>
                            <td>
                                <asp:TextBox ID="_29filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender290" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_29filed1" TargetControlID="_29filed1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td class="tdtdstyle3">
                              <asp:TextBox ID="_29noof" runat="server" style="display:none" Width="75px"></asp:TextBox>
                                &nbsp;</td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color:#83C8EE">
                            <td>
                                ACTION BY&nbsp;</td>
                            <td class="tdstyle1">N/A
                               <input id="chk_29actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_29actby','_29actby')" runat="server"/></td>
                            <td colspan="2">
                                <asp:TextBox ID="_29actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;</td>
                            <td>
                                COMMENTS</td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_29commts" runat="server" Height="50px" TextMode="MultiLine" 
                                    Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color:#83C8EE">
                            <td>
                                ACTION DATE</td>
                            <td class="tdstyle1">N/A
                             <input id="chk_29actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_29actdt','_29actdt')" runat="server"/></td>
                            <td>
                                <asp:TextBox ID="_29actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender291" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_29actdt" TargetControlID="_29actdt">
                                </asp:CalendarExtender>
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
                            <td class="tdstyle1">
                                &nbsp;</td>
                            <td align="right">
                                <asp:Button ID="_29btnupdate" runat="server" onclick="_29btnupdate_Click" 
                                    Text="Update" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_29btncancel" runat="server" onclick="_29btncancel_Click" 
                                    Text="Cancel" />
                            </td>
                            <td align="left" class="tdstyle2">
                                &nbsp;</td>
                            <td align="right">
                                &nbsp;</td>
                            <td>
                            </td>
                            <td class="tdtdstyle3">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    
                
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
                 <div id="Div29" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress5" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload29"  runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
    <asp:Panel ID="pnlPopup17" runat="server" Width="900px" Height="210px" 
                style="padding:15px;display:none;" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:900px" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_11lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            Continuity / IR Test</td>
                        <td class="tdstyle4">N/A
                            <input id="chk_11cit" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_11cit','_11cit')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_11cit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            No. of Lighting Circuits Tested</td>
                        <td class="tdstyle5">N/A
                            <input id="chk_11lct" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_11lct','_11lct')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_11lct" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            Addressing / Programming Test</td>
                        <td class="tdstyle6">N/A
                           <input id="chk_11apt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_11apt','_11apt')"/>
                           </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_11apt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            PC Head end / Interface Test</td>
                        <td class="tdstyle4">N/A
                            <input id="chk_11phgt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_11phgt','_11phgt')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_11phgt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle5">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle6">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            Consultant Accepted</td>
                        <td class="tdstyle4">N/A
                            <input id="chk_11accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_11accept1','_11accept1')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_11accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender125" runat="server" 
                        TargetControlID="_11accept1" PopupButtonID="_11accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            Test Sheets Filed</td>
                        <td class="tdstyle5">N/A
                            <input id="chk_11filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_11filed1','_11filed1')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_11filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender132" runat="server" 
                        TargetControlID="_11filed1" PopupButtonID="_11filed1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle6">
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            Action By</td>
                        <td class="tdstyle4">N/A
                           <input id="chk_11actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_11actby','_11actby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_11actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle5">
                            &nbsp;</td>
                        <td>
                            Comments</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_11commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            Action Date</td>
                        <td class="tdstyle4">N/A
                            <input id="chk_11actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_11actdt','_11actdt')" runat="server"/></td>
                        <td>
                            
                            <asp:TextBox ID="_11actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender133" runat="server" 
                        TargetControlID="_11actdt" PopupButtonID="_11actdt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle5">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle4">
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_11btnupdate" runat="server" Text="Update" 
                                onclick="_11btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_11btncancel" runat="server" Text="Cancel" 
                                onclick="_11btncancel_Click"  />
                        </td>
                        <td align="left" class="tdstyle5">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                           
                        </td>
                        <td class="tdstyle6">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
                 <div id="Div16" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress18" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload17" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy17" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender17" runat="server" TargetControlID="btnDummy17"  PopupControlID="pnlPopup17" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
        
        
      <asp:Button ID="btn28" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender28" runat="server" TargetControlID="btn28"
        PopupControlID="pnlPopup28" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup28" runat="server" Width="825px" Height="180px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_28lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                        <tr>
                            <td width="200PX">
                                Continuity/ IR Test</td>
                            <td class="tdstyle1">N/A<input ID="chk_28cit" runat="server" onclick="_checked('chk_28cit','_28cit')" 
                                    style="vertical-align:middle" type="checkbox" /></td>
                            <td width="75PX">
                                <asp:TextBox ID="_28cit" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender12" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_28cit" TargetControlID="_28cit">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                AVS Test (Audio Part)</td>
                            <td class="tdstyle2">N/A<input ID="chk_28ava" onclick="_checked('chk_28ava','_28ava')" 
                                    type="checkbox" style="vertical-align:middle; width: 20px;" 
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_28ava" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender7" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_28ava" TargetControlID="_28ava">
                                </asp:CalendarExtender>
                            </td>
                            <td width="200PX">
                                AVS Test (Video Part)</td>
                            <td class="tdtdstyle3">N/A<input ID="chk_28avv" onclick="_checked('chk_28avv','_28avv')" 
                                    type="checkbox" style="vertical-align:middle" runat="server" /></td>
                            <td width="75PX">
                                <asp:TextBox ID="_28avv" runat="server" Width="75px"></asp:TextBox>
                                 <asp:CalendarExtender ID="CalendarExtender8" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_28avv" TargetControlID="_28avv">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                Consultant Accepted</td>
                            <td class="tdstyle1">N/A
                                <input id="chk_28accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_28accept1','_28accept1')"/>
                                </td>
                            <td>
                                <asp:TextBox ID="_28accept1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender9" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_28accept1" TargetControlID="_28accept1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                Test Sheets Filed</td>
                            <td class="tdstyle2">N/A
                                <input id="chk_28filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_28filed1','_28filed1')"/>
                                </td>
                            <td>
                                <asp:TextBox ID="_28filed1" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender10" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_28filed1" TargetControlID="_28filed1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td class="tdtdstyle3">
                             <asp:TextBox ID="_28noof" runat="server" Width="75px" style="display:none"></asp:TextBox>
                                &nbsp;</td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color:#83C8EE">
                            <td>
                                Action By</td>
                            <td class="tdstyle1">N/A
                               <input id="chk_28actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_28actby','_28actby')" runat="server"/></td>
                            <td colspan="2">
                                <asp:TextBox ID="_28actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle2">
                                &nbsp;</td>
                            <td>
                                Comments</td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_28commts" runat="server" Height="50px" TextMode="MultiLine" 
                                    Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color:#83C8EE">
                            <td>
                                Action Date</td>
                            <td class="tdstyle1">N/A
                             <input id="chk_28actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_28actdt','_28actdt')" runat="server"/></td>
                            <td>
                                <asp:TextBox ID="_28actdt" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender11" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="_28actdt" TargetControlID="_28actdt">
                                </asp:CalendarExtender>
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
                            <td class="tdstyle1">
                                &nbsp;</td>
                            <td align="right">
                                <asp:Button ID="_28btnupdate" runat="server" onclick="_28btnupdate_Click" 
                                    Text="Update" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_28btncancel" runat="server" onclick="_28btncancel_Click" 
                                    Text="Cancel" />
                            </td>
                            <td align="left" class="tdstyle2">
                                &nbsp;</td>
                            <td align="right">
                                &nbsp;</td>
                            <td>
                            </td>
                            <td class="tdtdstyle3">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    
                
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
                 <div id="Div28" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress6" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload28" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        

 <asp:Button ID="btnDummy39a" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender39a" runat="server" TargetControlID="btnDummy39a"  PopupControlID="pnlPopup39a" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
    <asp:Panel ID="pnlPopup39a" runat="server" Width="825px" Height="275px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_39albl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            NO. OF DEVICES TESTED</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_39adt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_39adt','_39adt')"/>
                           </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_39adt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            CONTINUITY / IR</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_39aci" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_39aci','_39aci')"/>
                            </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_39aci" runat="server" Width="75px" style="margin-left: 0px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            CONTINUITY / IR TESTED</td>
                        <td class="tdstyle3">N/A
                            <input id="chk_39acit" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_39acit','_39acit')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_39acit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            FUNCTIONAL TEST</td>
                        <td class="tdstyle1">
                            N/A
                            <input id="chk_39afts" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_39afts','_39afts')"/>
                            </td>
                        <td width="75PX">
                             <asp:TextBox ID="_39afts" runat="server" Width="75px"></asp:TextBox>
                            </td>
                        <td width="200PX">
                            INTERFACE TEST</td>
                        <td class="tdstyle2">
                            N/A
                             <input id="chk_39ait" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_39ait','_39ait')"/>
                            </td>
                        <td width="75PX">
                             <asp:TextBox ID="_39ait" runat="server" Width="75px"></asp:TextBox>
                            </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle3">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_39aaccept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_39aaccept1','_39aaccept1')"/></td>
                        <td>
                           
                            <asp:TextBox ID="_39aaccept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender39a5" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_39aaccept1" 
                                TargetControlID="_39aaccept1">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_39afiled1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_39afiled1','_39afiled1')"/>
                            </td>
                        <td>
                           
                            <asp:TextBox ID="_39afiled1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender39a6" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_39afiled1" 
                                TargetControlID="_39afiled1">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr id="tr12" runat="server">
                        <td >
                            SEQ OF OP TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_39asot" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_39asot','_39asot')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_39asot" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td >
                            GRAPHICS / HEAD END TESTS</td>
                        <td class="tdstyle2">
                            N/A
                            <input id="chk_39aght" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_39aght','_39aght')"/>
                            </td>
                        <td >
                            <asp:TextBox ID="_39aght" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle3">
                            &nbsp;</td>
                        <td >
                            
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_39aaccept2" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_39aaccept2','_39aaccept2')"/>
                            </td>
                        <td>
                           
                            <asp:TextBox ID="_39aaccept2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender39a8" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_39aaccept2" 
                                TargetControlID="_39aaccept2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">N/A
                             <input id="chk_39afiled2"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_39afiled2','_39afiled2')"/>
                            </td>
                        <td>
                           
                            <asp:TextBox ID="_39afiled2" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender39a9" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_39afiled2" 
                                TargetControlID="_39afiled2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_39aactby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_39aactby','_39aactby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_39aactby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_39acommts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle1">N/A
                          <input id="chk_39aactdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_39aactdt','_39aactdt')" runat="server"/></td>
                        <td>
                            
                            <asp:TextBox ID="_39aactdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender53" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_39aactdt" 
                                TargetControlID="_39aactdt">
                            </asp:CalendarExtender>
                            
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
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_39abtnupdate" runat="server" Text="Update" 
                                onclick="_39abtnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_39abtncancel" runat="server" Text="Cancel" 
                                onclick="_39abtncancel_Click" />
                        </td>
                        <td align="left" class="tdstyle2">
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
                  <div id="Div39a" runat="server" style="position:absolute; z-index:39a0;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress7" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload39a" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
               
           
            </div>
        </asp:Panel>
        
        
      <asp:Panel ID="pnlPopup14" runat="server" Width="900px" Height="240px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="_37points" runat="server" style="display:none"></asp:TextBox>
                    <asp:TextBox ID="_37devices" runat="server" style="display:none"></asp:TextBox>
                    <asp:TextBox ID="_37system" runat="server" style="display:none"></asp:TextBox>
                    <asp:TextBox ID="TextBox2" runat="server" style="display:none"></asp:TextBox>
                <table style="font-size:x-small;width:900px;" cellpadding="3" border="0" 
                        cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_37lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="220PX" >
                            CABLE TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_37ct" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_37ct','_37ct')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_37ct" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="220PX">
                            FUNCTIONAL TEST</td>
                        <td class="tdstyle2" >N/A
                            <input id="chk_37ft" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_37ft','_37ft')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_37ft" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="220PX" >
                            INTERFACE TEST</td>
                        <td class="tdstyle3">N/A
                            <input id="chk_37it" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_37it','_37it')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_37it" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td width="220PX">
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_37accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_37accept1','_37accept1')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_37accept1" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender121" runat="server" 
                        TargetControlID="_37accept1" PopupButtonID="_37accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="220PX">
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2" >N/A
                           <input id="chk_37filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_37filed1','_37filed1')"/>
                           </td>
                        <td width="75PX">
                            <asp:TextBox ID="_37filed1" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender122" runat="server" 
                        TargetControlID="_37filed1" PopupButtonID="_37filed1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="220PX">
                            &nbsp;</td>
                        <td class="tdstyle3" >
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="220PX">
                            SEQ. OF OPERATION TEST</td>
                        <td class="tdstyle1" >N/A
                            <input id="chk_37sot" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_37sot','_37sot')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_37sot" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="220PX">
                            GRAPHICS/HEAD END TEST</td>
                        <td class="tdstyle2" >N/A
                            <input id="chk_37ght" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_37ght','_37ght')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_37ght" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="220PX">
                            &nbsp;</td>
                        <td class="tdstyle3" >
                            &nbsp;</td>
                        <td width="75PX">
                        </td>
                    </tr>
                    <tr  style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td width="220PX">
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle2" >N/A
                            <input id="chk_37accept2" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_37accept2','_37accept2')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_37accept2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender109" runat="server" 
                        TargetControlID="_37accept2" PopupButtonID="_37accept2" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="220PX">
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2" >N/A
                            <input id="chk_37filed2"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_37filed2','_37filed2')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_37filed2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender111" runat="server" 
                        TargetControlID="_37filed2" PopupButtonID="_37filed2" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="220PX">
                            &nbsp;</td>
                        <td class="tdstyle3" >
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle1" >N/A
                            <input id="chk_37actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_37actby','_37actby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_37actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle2" >
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_37commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle2" >N/A
                           <input id="chk_37actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_37actdt','_37actdt')" runat="server"/></td>
                        <td>
                            
                            <asp:TextBox ID="_37actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender129" runat="server" 
                        TargetControlID="_37actdt" PopupButtonID="_37actdt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            </td>
                        <td class="tdstyle1" >
                            </td>
                        <td>
                            </td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle2" >
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_37btnupdate" runat="server" Text="Update" 
                                onclick="_37btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_37btncancel" runat="server" Text="Cancel" 
                                onclick="_37btncancel_Click" />
                        </td>
                        <td align="left" >
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                           
                        </td>
                        <td class="tdstyle3" >
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
                
                <div id="Div13" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress15" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload14" runat="server" ImageUrl="../images/loading.gif" Height="220px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
            </div>
        </asp:Panel>
              <asp:Button ID="btnDummy14" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender14" runat="server" TargetControlID="btnDummy14"  PopupControlID="pnlPopup14" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
        
        
             <asp:Panel ID="pnlPopup35" runat="server" Width="900px" Height="280px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:900px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_35lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                 <tr style="background-color:#83C8EE">
                <td width="200px">
                   PLANT POWER ON
                     </td>
                     <td class="tdstyle1">
                        </td>
                <td width="75px">
                <asp:TextBox ID="_35pwron" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender66" runat="server" 
                        TargetControlID="_35pwron" PopupButtonID="_35pwron" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                </td>
                    <td width="200px">
                        
                     </td>
                     <td class="tdstyle2">
                         <td width="75px">
                             &nbsp;</td>
                         <td width="200px">
                         </td>
                    <td class="tdtdstyle3">
                        &nbsp;</td>
                         <td width="75px">
                         </td>
                </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="9"  align="center">
                           COMMISSIONING & ACCEPTANCE</td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            PRECOM</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_35pc1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_35pc1','_35pc1')"/>
                            </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_35pc1" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender54" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_35pc1" 
                                TargetControlID="_35pc1">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            COMM</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_35co1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_35co1','_35co1')"/>
                            </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_35co1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender55" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_35co1" 
                                TargetControlID="_35co1">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            WITNESSED DATE</td>
                        <td class="tdtdstyle3">
                            N/A
                             <input id="chk_35wd1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_35wd1','_35wd1')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_35wd1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender65" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_35wd1" TargetControlID="_35wd1">
                            </asp:CalendarExtender>
                            </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_35accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_35accept1','_35accept1')"/></td>
                        <td >
                           
                            <asp:TextBox ID="_35accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender26" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_35accept1" 
                                TargetControlID="_35accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_35filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_35filed1','_35filed1')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_35filed1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender27" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_35filed1" 
                                TargetControlID="_35filed1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td class="tdtdstyle3">
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#092443;color:White">
                        <td colspan="9" align="center">
                            CONTROLS</td>
                    </tr>
                    <tr>
                        <td>
                            PRE-COMM&nbsp;</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_35pc2" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_35pc2','_35pc2')"/>
                            </td>
                        <td>
                             <asp:CalendarExtender ID="CalendarExtender60" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_35pc2" 
                                TargetControlID="_35pc2">
                            </asp:CalendarExtender>
                             <asp:TextBox ID="_35pc2" runat="server" 
                                Width="75px"></asp:TextBox></td>
                        <td>
                            COMM</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_35co2" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_35co2','_35co2')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_35co2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender59" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_35co2" 
                                TargetControlID="_35co2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            WITNESSED DATE</td>
                        <td class="tdtdstyle3">N/A
                            <input id="chk_35wd2" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_35wd2','_35wd2')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_35wd2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender64" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_35wd2" 
                                TargetControlID="_35wd2">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td class="tdtdstyle3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                       <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle1" >N/A
                            <input id="chk_35actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_35actby','_35actby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_35actby" runat="server" Width="250px" >
                               </asp:TextBox>
                            
                        </td>
                        <td class="tdstyle2" >
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_35commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                     <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle2" >N/A
                           <input id="chk_35actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_35actdt','_35actdt')" runat="server"/></td>
                        <td>
                            
                            <asp:TextBox ID="_35actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender28" runat="server" 
                        TargetControlID="_35actdt" PopupButtonID="_35actdt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            </td>
                        <td class="tdstyle1" >
                            </td>
                        <td>
                            </td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_35btnupdate" runat="server" Text="Update" 
                                onclick="_35btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_35btncancel" runat="server" Text="Cancel" 
                                onclick="_35btncancel_Click" />
                        </td>
                        <td align="left" class="tdstyle2">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                           
                        </td>
                        <td class="tdtdstyle3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
                 <div id="Div2" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress10" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload35" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
              <asp:Button ID="btnDummy35" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender35" runat="server" TargetControlID="btnDummy35"  PopupControlID="pnlPopup35" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
        
             <asp:Panel ID="pnlPopup34" runat="server" Width="850px" Height="355px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:850px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_34lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="9"  align="center">
                            UPS / CHARGERSET STAND ALONE TESTING</td>
                    </tr>
                
                    <tr >
                        <td width="200PX"  >
                            PRE-COM/TORQUE TEST</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_34pc" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_34pc','_34pc')"/>
                           </td>
                        <td width="75PX"  >
                            <asp:TextBox ID="_34pc" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender42" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34pc" 
                                TargetControlID="_34pc">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX"  >
                            LOAD BANK TESTS</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_34lb" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_34lb','_34lb')"/>
                            </td>
                        <td width="75PX"  >
                            
                            <asp:TextBox ID="_34lb" runat="server" Width="75px" style="margin-left: 0px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender43" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34lb" 
                                TargetControlID="_34lb">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX"  >
                            UPS / CHARGER FUNCTIONAL TEST</td>
                        <td class="tdstyle3">N/A
                            <input id="chk_34ucf" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_34ucf','_34ucf')"/>
                            </td>
                        <td width="75PX"  >
                           
                            <asp:TextBox ID="_34ucf" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender44" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34ucf" 
                                TargetControlID="_34ucf">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_34accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_34accept1','_34accept1')"/></td>
                        <td>
                           
                            <asp:TextBox ID="_34accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender45" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34accept1" 
                                TargetControlID="_34accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_34filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_34filed1','_34filed1')"/>
                            </td>
                        <td>
                           
                            <asp:TextBox ID="_34filed1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender46" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34filed1" 
                                TargetControlID="_34filed1">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="9" align="center">
                            OUTGOING CIRCUIT TESTING</td>
                    </tr>
                    <tr id="tr1" runat="server">
                        <td >
                            CABLE COLD TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_34cable" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_34cable','_34cable')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_34cable" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender47" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34cable" 
                                TargetControlID="_34cable">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td >
                           
                        </td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle3">
                            &nbsp;</td>
                        <td >
                            
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_34accept2" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_34accept2','_34accept2')"/>
                            </td>
                        <td>
                           
                            <asp:TextBox ID="_34accept2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender48" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34accept2" 
                                TargetControlID="_34accept2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">N/A
                             <input id="chk_34filed2"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_34filed2','_34filed2')"/>
                            </td>
                        <td>
                           
                            <asp:TextBox ID="_34filed2" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender49" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34filed2" 
                                TargetControlID="_34filed2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#092443;color:White">
                        <td colspan="9" align="center">
                            SITE OPERATION &amp; FUNCTION</td>
                    </tr>
                    <tr >
                        <td>
                            SITE OPERATION &amp; FUNCTION</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_34sol" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_34sol','_34sol')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_34sol" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender50" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34sol" 
                                TargetControlID="_34sol">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_34accept3" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_34accept3','_34accept3')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_34accept3" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender51" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34accept3" 
                                TargetControlID="_34accept3">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">N/A
                             <input id="chk_34filed3"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_34filed3','_34filed3')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_34filed3" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender52" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34filed3" 
                                TargetControlID="_34filed3">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_34actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_34actby','_34actby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_34actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_34commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle1">N/A
                          <input id="chk_34actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_34actdt','_34actdt')" runat="server"/></td>
                        <td>
                            
                            <asp:TextBox ID="_34actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender13" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34actdt" 
                                TargetControlID="_34actdt">
                            </asp:CalendarExtender>
                            
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
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_34btnupdate" runat="server" Text="Update" 
                                onclick="_34btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_34btncancel" runat="server" Text="Cancel" 
                                onclick="_34btncancel_Click" />
                        </td>
                        <td align="left" class="tdstyle2">
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
                  <div id="Div4" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress9" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload5" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" style="display:none" />
                Pre-com/Torque Test
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
               
           
            </div>
        </asp:Panel>
        
        
        <asp:Button ID="btnDummy34" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender34" runat="server" TargetControlID="btnDummy34"  PopupControlID="pnlPopup34" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
        
                <asp:Panel ID="pnlPopup19" runat="server" Width="900px" Height="225px" 
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
                    <tr >
                        <td width="200PX" >
                            CONTINUITY/IR TEST&nbsp;</td>
                        <td class="tdstyle1" width="200PX">
                            N/A
                             <input id="chk_15cit" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15cit','_15cit')" runat="server"/></td></td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15cit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            KEY CARD ACTIVATED</td>
                        <td class="tdstyle2" width="200PX">
                            N/A
                             <input id="chk_15kca" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15kca','_15kca')" runat="server"/></td></td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15kca" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            DO NOT DISTURB(DND)/ DOORBELL</td>
                        <td class="tdstyle3" width="200PX">
                            N/A
                             <input id="chk_15dnd" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15dnd','_15dnd')" runat="server"/></td></td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15dnd" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            MAKE UP ROOM</td>
                        <td class="tdstyle1" width="200PX">
                            N/A
                             <input id="chk_15mur" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15mur','_15mur')" runat="server"/></td></td>
                        <td width="75PX">
                            <asp:TextBox ID="_15mur" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            FCU/ TEMP CONTROL</td>
                        <td class="tdstyle2" width="200PX">
                            N/A
                             <input id="chk_15ftc" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15ftc','_15ftc')" runat="server"/></td></td>
                        <td width="75PX">
                            <asp:TextBox ID="_15ftc" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            ENERGY MANAGEMENT SYSTEM</td>
                        <td class="tdstyle3" width="200PX">
                            N/A
                             <input id="chk_15ems" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15ems','_15ems')" runat="server"/></td></td>
                        <td width="75PX">
                            <asp:TextBox ID="_15ems" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            LIGHTING SCENE CONTROL</td>
                        <td class="tdstyle1" width="200PX">
                            N/A
                             <input id="chk_15lsc" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15lsc','_15lsc')" runat="server"/></td></td>
                        <td width="75PX">
                            <asp:TextBox ID="_15lsc" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            BLINDS CONTROL INTERFACE</td>
                        <td class="tdstyle3" width="200PX">
                            N/A
                             <input id="chk_15bci" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15bci','_15bci')" runat="server"/></td></td>
                        <td width="75PX">
                            <asp:TextBox ID="_15bci" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            MONITORING INTERFACE (FUTURE)</td>
                        <td class="tdstyle3" width="200PX">
                            N/A
                             <input id="chk_15mif" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15mif','_15mif')" runat="server"/></td></td>
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
                           <asp:CalendarExtender ID="CalendarExtender141" runat="server" 
                        TargetControlID="_15accept1" PopupButtonID="_15accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td >
                           
                            <asp:TextBox ID="_15filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender136" runat="server" 
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
                            <asp:CalendarExtender ID="CalendarExtender137" runat="server" 
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
                 <div id="Div18" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
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
        
            <asp:Panel ID="pnlPopup18" runat="server" Width="850px" Height="185px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:850px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="8" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_12albl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            NO.OF POINTS</td>
                        <td class="tdstyle1">
                            
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_12anop" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            CABLE TESTED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_12act" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_12act','_12act')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_12act" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            &nbsp;</td>
                        <td width="75PX" >
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_12aaccept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_12aaccept1','_12aaccept1')"/></td>
                        <td >
                           
                            <asp:TextBox ID="_12aaccept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender142" runat="server" 
                        TargetControlID="_12aaccept1" PopupButtonID="_12aaccept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_12afiled1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_12afiled1','_12afiled1')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_12afiled1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender134" runat="server" 
                        TargetControlID="_12afiled1" PopupButtonID="_12afiled1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_12aactby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_12aactby','_12aactby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_12aactby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_12acommts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_12aactdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_12aactdt','_12aactdt')" runat="server"/></td>
                        <td>
                            
                            <asp:TextBox ID="_12aactdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender135" runat="server" 
                        TargetControlID="_12aactdt" PopupButtonID="_12aactdt" ClearTime="true" 
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
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_12abtnupdate" runat="server" Text="Update" 
                                onclick="_12abtnupdate_Click"  />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_12abtncancel" runat="server" Text="Cancel" 
                                onclick="_12abtncancel_Click"  />
                        </td>
                        <td align="left" class="tdstyle2">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                           
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
                <div id="Div17" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress19" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload18" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div>  
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy18" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender18" runat="server" TargetControlID="btnDummy18"  PopupControlID="pnlPopup18" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
        
                <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnDummy19"  PopupControlID="pnlPopup19" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
         <asp:Panel ID="pnlPopup20" runat="server" Width="850px" Height="225px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:850px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_14lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            CONTINUITY/IR TEST</td>
                        <td class="tdstyle4">N/A
                            <input id="chk_14cit" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_14cit','_14cit')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_14cit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            DOOR INTERCOM ALERT/BELL</td>
                        <td class="tdstyle5">N/A
                            <input id="chk_14diab" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_14diab','_14diab')"/></td>
                        <td width="75PX" >
                            <asp:TextBox ID="_14diab" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            AUDIO/VISUAL TEST</td>
                        <td class="tdstyle6">N/A
                            <input id="chk_14avt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_14avt','_14avt')"/></td>
                        <td width="75PX" >
                            <asp:TextBox ID="_14avt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            DOOR RELEASE TEST</td>
                        <td class="tdstyle4">N/A
                            <input id="chk_14drt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_14drt','_14drt')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_14drt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle5">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle6">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle4">N/A
                            <input id="chk_14accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_14accept1','_14accept1')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_14accept1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender140" runat="server" 
                        TargetControlID="_14accept1" PopupButtonID="_14accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle5">N/A
                            <input id="chk_14filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_14filed1','_14filed1')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_14filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender138" runat="server" 
                        TargetControlID="_14filed1" PopupButtonID="_14filed1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            <asp:TextBox ID="_14noof" runat="server" Width="75px" style="display:none"></asp:TextBox>
                        </td>
                        <td class="tdstyle6">
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle4">N/A
                           <input id="chk_14actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_14actby','_14actby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_14actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle5">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_14commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle4">N/A
                          <input id="chk_14actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_14actdt','_14actdt')" runat="server"/></td>
                        <td>
                            
                            <asp:TextBox ID="_14actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender139" runat="server" 
                        TargetControlID="_14actdt" PopupButtonID="_14actdt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle5">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle4">
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_14btnupdate" runat="server" Text="Update" 
                                onclick="_14btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_14btncancel" runat="server" Text="Cancel" 
                                onclick="_14btncancel_Click" />
                        </td>
                        <td align="left" class="tdstyle5">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                           
                        </td>
                        <td class="tdstyle6">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
                 <div id="Div19" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress21" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload20" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy20" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender20" runat="server" TargetControlID="btnDummy20"  PopupControlID="pnlPopup20" BackgroundCssClass="modal" ></asp:ModalPopupExtender>   
    
             <asp:Panel ID="pnlPopup9" runat="server" Width="825px" Height="315px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0">
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_9lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                
                    <tr style="background-color:#092443;color:White">
                        <td align="center" colspan="9">
                            FUSIBLE LINK FIRE DAMPER</td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            ACCESSIBILITY ACCEPTABLE</td>
                        <td class="tdstyle1">N/A
                             <input id="chk_9aa" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_9aa','_9aa')"/>
                            </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_9aa" runat="server" Width="75px"></asp:TextBox>
                              <asp:CalendarExtender ID="CalendarExtender78" runat="server" 
                        TargetControlID="_9aa" PopupButtonID="_9aa" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            DROP TEST PASSED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_9dtp" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_9dtp','_9dtp')"/>
                            </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_9dtp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender79" runat="server" 
                        TargetControlID="_9dtp" PopupButtonID="_9dtp" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            RESET PASSED</td>
                        <td class="tdstyle3">N/A
                             <input id="chk_9rp" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_9rp','_9rp')"/>
                            </td>
                        <td width="75PX" >
                           
                            <asp:TextBox ID="_9rp" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender80" runat="server" 
                        TargetControlID="_9rp" PopupButtonID="_9rp" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-color:#092443;color:White">
                        <td align="center" colspan="9">
                            MOTORISED SMOKE FIRE DAMPER</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            MANUEL OPEN OPERATION</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_9moo" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_9moo','_9moo')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_9moo" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender77" runat="server" 
                        TargetControlID="_9moo" PopupButtonID="_9moo" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            SPRING RETURN OPERATION</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_9sro" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_9sro','_9sro')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_9sro" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender87" runat="server" 
                        TargetControlID="_9sro" PopupButtonID="_9sro" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            END SWITCH TEST</td>
                        <td class="tdstyle3">N/A
                            <input id="chk_9est" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_9est','_9est')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_9est" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender88" runat="server" 
                        TargetControlID="_9est" PopupButtonID="_9est" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            POWER OPEN/ SPRING RETURN TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_9psrt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_9psrt','_9psrt')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_9psrt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender81" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_9psrt" TargetControlID="_9psrt">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle2">&nbsp;</td>
                            </td>
                        <td width="75PX">
                            &nbsp;</td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle3">
                            &nbsp;</td>
                        <td width="75PX">
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_9accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_9accept1','_9accept1')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_9accept1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender84" runat="server" 
                        TargetControlID="_9accept1" PopupButtonID="_9accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_9filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_9filed1','_9filed1')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_9filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender85" runat="server" 
                        TargetControlID="_9filed1" PopupButtonID="_9filed1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle3">
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_9actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_9actby','_9actby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_9actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_9commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_9actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_9actdt','_9actdt')" runat="server"/></td>
                        <td>
                            
                            <asp:TextBox ID="_9actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender86" runat="server" 
                        TargetControlID="_9actdt" PopupButtonID="_9actdt" ClearTime="true" 
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
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_9btnupdate" runat="server" Text="Update" 
                                onclick="_9btnupdate_Click"  />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_9btncancel" runat="server" Text="Cancel" 
                                onclick="_9btncancel_Click" />
                        </td>
                        <td align="left" class="tdstyle2">
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
                 <div id="Div8" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress11" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload9" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy9" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender9" runat="server" TargetControlID="btnDummy9"  PopupControlID="pnlPopup9" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
    
    
           <asp:Panel ID="pnlPopup13" runat="server" Width="900px" Height="295px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:900px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_10lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            CABLE CONTINUITY/IR TESTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_10ccit" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_10ccit','_10ccit')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_10ccit" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender236" runat="server" 
                        ClearTime="true" TargetControlID="_10ccit"
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            NO.OF DEVICES TESTED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_10ndt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_10ndt','_10ndt')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_10ndt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            DEVICE TEST COMPLETE</td>
                        <td class="tdstyle3">N/A
                            <input id="chk_10dtc" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_10dtc','_10dtc')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_10dtc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender110" runat="server" 
                        TargetControlID="_10dtc" PopupButtonID="_10dtc" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            FA INTERFACES TESTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_10fait" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_10fait','_10fait')"/></td>
                        <td width="75PX">
                            <asp:TextBox ID="_10fait" runat="server" Width="75px"></asp:TextBox>
                       </td>
                        <td width="200PX">
                        <div id="tdiv" runat="server">
                          INTERFACE/ EQUIPMENT TEST</div></td>
                        <td class="tdstyle2">
                        <div id="odiv" runat="server">
                            N/A
                        <input id="chk_10iet" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_10iet','_10iet')"/>
                        </div>
                            </td>
                        <td width="75PX">
                        <div id="ddiv" runat="server">
                            <asp:TextBox ID="_10iet" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender216" runat="server" 
                        TargetControlID="_10iet" PopupButtonID="_10iet" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </div>
                        </td>
                        <td width="200PX">
                            <asp:TextBox ID="_10devices" runat="server" Width="75px" style="display:none"></asp:TextBox>
                            LOOP TEST COMPLETE
                        </td>
                        <td class="tdstyle3">N/A
                        <input id="chk_10ltc" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_10ltc','_10ltc')"/>
                            &nbsp;</td>
                        <td width="75PX">
                            <asp:TextBox ID="_10interface" runat="server" Width="75px" style="display:none"></asp:TextBox>
                            <asp:TextBox ID="_10ltc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender115" runat="server" 
                        TargetControlID="_10ltc" PopupButtonID="_10ltc" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td width="200PX">
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_10accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_10accept1','_10accept1')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_10accept1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_10accept1_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_10accept1" 
                                TargetControlID="_10accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_10filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_10filed1','_10filed1')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_10filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_10filed1_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_10filed1" 
                                TargetControlID="_10filed1">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle3">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            SOUND LEVEL TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_10slt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_10slt','_10slt')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_10slt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            BATTERY AUTONOMY TEST</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_10bat" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_10bat','_10bat')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_10bat" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="cal_bat" runat="server" 
                        TargetControlID="_10bat" PopupButtonID="_10bat" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            GRAPHICS/HEAD&nbsp; END TEST</td>
                        <td class="tdstyle3">N/A
                            <input id="chk_10ghet" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_10ghet','_10ghet')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_10ghet" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="cal_ghet" runat="server" 
                        TargetControlID="_10ghet" PopupButtonID="_10ghet" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                       </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            CAUSE &amp; EFFECT TESTS</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_10cet" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_10cet','_10cet')"/>
                           </td>
                        <td width="75PX">
                            <asp:TextBox ID="_10cet" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="cal_cet" runat="server" 
                        TargetControlID="_10cet" PopupButtonID="_10cet" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle3">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_10accept2" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_10accept2','_10accept2')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_10accept2" runat="server" Width="75px"></asp:TextBox>
                          <asp:CalendarExtender ID="CalendarExtender112" runat="server" 
                        TargetControlID="_10accept2" PopupButtonID="_10accept2" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_10filed2"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_10filed2','_10filed2')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_10filed2" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender113" runat="server" 
                        TargetControlID="_10filed2" PopupButtonID="_10filed2" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle3">
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_10actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_10actby','_10actby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_10actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_10commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle1">N/A
                         <input id="chk_10actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_10actdt','_10actdt')" runat="server"/></td>
                        <td>
                            
                            <asp:TextBox ID="_10actdt" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender114" runat="server" 
                        TargetControlID="_10actdt" PopupButtonID="_10actdt" ClearTime="true" 
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
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_10btnupdate" runat="server" Text="Update" 
                                onclick="_10btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_10btncancel" runat="server" Text="Cancel" 
                                onclick="_10btncancel_Click" />
                        </td>
                        <td align="left" class="tdstyle2">
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
                 <div id="Div12" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress14" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload13" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy13" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender13" runat="server" TargetControlID="btnDummy13"  PopupControlID="pnlPopup13" BackgroundCssClass="modal" ></asp:ModalPopupExtender>   
    
    <asp:Panel ID="pnlPopup27" runat="server" Width="860px" Height="260px" 
                style="padding:15px;" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:860px;" cellpadding="3" border="0" cellspacing="0" >
                
                    <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_27lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            TESTED &amp; COMM.</td>
                        <td width="200PX" class="tdstyle1">
                            N/A
                            <input id="chk_27tc"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_27tc','_27tc')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_27tc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender118" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_27tc" TargetControlID="_27tc">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            3<sup>rd</sup> PARTY INSPECTED</td>
                        <td width="200PX" class="tdstyle2">
                            N/A
                            <input id="chk_27tpi"  type="checkbox" style="vertical-align:middle" 
                                runat="server"  onclick="_checked('chk_27tpi','_27tpi')" />
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_27tpi" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender119" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_27tpi" TargetControlID="_27tpi">
                            </asp:CalendarExtender>
                        </td>
                          <td width="200PX">
                            &nbsp;</td>
                        <td width="200PX" class="tdstyle3">
                            </td>
                        <td width="75PX">
                            &nbsp;</td>
                        </tr>
                         <tr style="background-color:#092443;color:White">
                        <td align="center" colspan="9">
                           Life and Safety Functional Tests</td>
                    </tr>
                        <tr>
                        <td width="200PX">
                            EMERGENCY LIGHTING</td>
                        <td width="200PX" class="tdstyle1">
                            N/A
                            <input id="chk_27eml"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_27eml','_27eml')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_27eml" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender143" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_27eml" TargetControlID="_27eml">
                            </asp:CalendarExtender>
                        </td>

                        <td width="200PX">
                            POWER FAILURE MODE</td>
                        <td width="200PX" class="tdstyle2">
                            N/A
                            <input id="chk_27pfm"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_27pfm','_27pfm')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_27pfm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender144" runat="server" 
                        TargetControlID="_27pfm" PopupButtonID="_27pfm" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            LIFT MONITORING SYSTEM</td>
                        <td width="200PX" class="tdstyle3">
                            N/A
                            <input id="chk_27lms"  type="checkbox" style="vertical-align:middle" 
                                runat="server"  onclick="_checked('chk_27lms','_27lms')" />
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_27lms" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender145" runat="server" 
                        TargetControlID="_27lms" PopupButtonID="_27lms" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        </tr>
                        <tr>
                        <td width="200PX">
                            INTERCOM</td>
                        <td width="200PX" class="tdstyle1">
                            N/A
                            <input id="chk_27int"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_27int','_27int')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_27int" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender146" runat="server" 
                        TargetControlID="_27int" PopupButtonID="_27int" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            BMS/FIRE ALARM INTERFACE</td>
                        <td width="200PX" class="tdstyle2">
                            N/A
                            <input id="chk_27bfa"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_27bfa','_27bfa')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_27bfa" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender147" runat="server" 
                        TargetControlID="_27bfa" PopupButtonID="_27bfa" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="200PX" class="tdstyle3">
                            </td>
                        <td width="75PX">
                            &nbsp;</td>

                    </tr>
                        <tr style="background-color:#092443;color:White">
                        <td align="center" colspan="9">
                            Final Test Sheets</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">
                            N/A
                            <input id="chk_27accept1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_27accept1','_27accept1')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_27accept1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender108" runat="server" 
                        TargetControlID="_27accept1" PopupButtonID="_27accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">
                            N/A
                            <input id="chk_27filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_27filed1','_27filed1')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_27filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender116" runat="server" 
                        TargetControlID="_27filed1" PopupButtonID="_27filed1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
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
                            
                            <asp:TextBox ID="_27actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_27commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            
                            <asp:TextBox ID="_27actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender117" runat="server" 
                        TargetControlID="_27actdt" PopupButtonID="_27actdt" ClearTime="true" 
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
                           <asp:Button ID="_27btnupdate" runat="server" Text="Update" 
                                onclick="_27btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_27btncancel" runat="server" Text="Cancel" 
                                onclick="_27btncancel_Click" />
                        </td>
                        <td align="left">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                           
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
                 <div id="Div20" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress22" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload21" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy27" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender27" runat="server" TargetControlID="btnDummy27"  PopupControlID="pnlPopup27" BackgroundCssClass="modal" ></asp:ModalPopupExtender> 
    
    
    </form>
</body>
</html>



