<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CAS_Commissioning11.aspx.cs" Inherits="CmlTechniques.CMS.CAS_Commissioning11" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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
  <asp:Panel ID="pnlPopup4" runat="server" Width="825px" Height="420px" style="padding:15px;display:none;" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate>
                 <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                 <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_5lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                 <tr style="background-color:#83C8EE">
                <td width="200px">
                    Planned Power On</td>
                     <td class="tdstyle1">N/A
                         <input id="chk_5pwron" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_5pwron','_5pwron')" runat="server"/></td>
                <td width="75px">
                <asp:TextBox ID="_5pwron" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender30" runat="server" 
                        TargetControlID="_5pwron" PopupButtonID="_5pwron" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                </td>
                    <td width="200px">
                        &nbsp;</td>
                     <td class="tdstyle2">
                         &nbsp;</td>
                    <td width="75px">
                        &nbsp;</td>
                <td width="200px">
                </td>
                     <td class="tdstyle1">
                         &nbsp;</td>
                <td width="75px"></td>
                </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="9"  align="center">
                            PANEL / EQUIPMENT TESTING</td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            Panel Test Planned</td>
                        <td class="tdstyle1">&nbsp;</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_5ptp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_5tor0_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_5ptp" 
                                TargetControlID="_5ptp">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            &nbsp;</td>
                        <td class="tdstyle2">&nbsp;</td>
                        <td width="75PX" >
                            &nbsp;</td>
                        <td width="200PX" >
                            &nbsp;</td>
                        <td class="tdstyle1">&nbsp;</td>
                        <td width="75PX" >
                            &nbsp;</td>
                    </tr>
                     <tr>
                         <td width="200PX">
                             Torque Test</td>
                         <td class="tdstyle1">
                             N/A
                             <input ID="chk_5tor" runat="server" onclick="_checked('chk_5tor','_5tor')" 
                                 style="vertical-align:middle" type="checkbox" />
                         </td>
                         <td width="75PX">
                             <asp:TextBox ID="_5tor" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender9" runat="server" ClearTime="true" 
                                 Format="dd/MM/yyyy" PopupButtonID="_5tor" TargetControlID="_5tor">
                             </asp:CalendarExtender>
                         </td>
                         <td width="200PX">
                             IR Test</td>
                         <td class="tdstyle2">
                             N/A
                             <input ID="chk_5ir" runat="server" onclick="_checked('chk_5ir','_5ir')" 
                                 style="vertical-align:middle" type="checkbox" />
                         </td>
                         <td width="75PX">
                             <asp:CalendarExtender ID="CalendarExtender18" runat="server" ClearTime="true" 
                                 Format="dd/MM/yyyy" PopupButtonID="_5ir" TargetControlID="_5ir">
                             </asp:CalendarExtender>
                             <asp:TextBox ID="_5ir" runat="server" Width="75px"></asp:TextBox>
                         </td>
                         <td width="200PX">
                             HI Pot Test</td>
                         <td class="tdstyle1">
                             N/A
                             <input ID="chk_5pr" runat="server" onclick="_checked('chk_5pr','_5pr')" 
                                 style="vertical-align:middle" type="checkbox" />
                         </td>
                         <td width="75PX">
                             <asp:CalendarExtender ID="CalendarExtender19" runat="server" ClearTime="true" 
                                 Format="dd/MM/yyyy" PopupButtonID="_5pr" TargetControlID="_5pr">
                             </asp:CalendarExtender>
                             <asp:TextBox ID="_5pr" runat="server" Width="75px"></asp:TextBox>
                         </td>
                     </tr>
                    <tr >
                        <td>
                            Secondary Injuction Test</td>
                        <td class="tdstyle1">N/A
                        <input id="chk_5si" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_5si','_5si')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_5si" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender35" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_5si" 
                                TargetControlID="_5si">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            Contact Resistance</td>
                        <td class="tdstyle2">N/A
                           <input id="chk_5cr" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_5cr','_5cr')"/>
                           </td>
                        <td>
                            <asp:TextBox ID="_5cr" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender36" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_5cr" 
                                TargetControlID="_5cr">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            Functional Test</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_5fn" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_5fn','_5fn')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_5fn" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender37" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_5fn" 
                                TargetControlID="_5fn">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            Consultant Accepted</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_5accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_5accept1','_5accept1')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_5accept1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender20" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_5accept1" TargetControlID="_5accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            Test Sheets Filed</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_5filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_5filed1','_5filed1')"/></td>
                        <td>
                            <asp:TextBox ID="_5filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender26" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_5filed1" TargetControlID="_5filed1">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="9" align="center">
                            OUTGOING CIRCUIT TESTING</td>
                    </tr>
                    <tr >
                        <td >
                            Cold Test Planned</td>
                        <td class="tdstyle1">
                          
                            &nbsp;<td>
                                <asp:TextBox ID="_5ctp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_5tor1_CalendarExtender" runat="server" 
                                    ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_5ctp" 
                                    TargetControlID="_5ctp">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                Live Test Planned</td>
                            <td class="tdstyle2">
                                &nbsp;</td>
                            <td>
                                <asp:TextBox ID="_5ltp" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="_5tor2_CalendarExtender" runat="server" 
                                    ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_5ltp" 
                                    TargetControlID="_5ltp">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td class="tdstyle1">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                    </tr>
                     <tr>
                         <td>
                             Total No. Of Circuits</td>
                         <td class="tdstyle1">
                             <td>
                                 <asp:TextBox ID="_5total" runat="server" ReadOnly="True" Width="75px"></asp:TextBox>
                             </td>
                             <td>
                                 Total Cold Tested</td>
                             <td class="tdstyle2">
                                 N/A
                                 <input ID="chk_5tc" runat="server" onclick="_checked('chk_5tc','_5tc')" 
                                     style="vertical-align:middle" type="checkbox" /></td>
                             <td>
                                 <asp:TextBox ID="_5tc" runat="server" Text="0" Width="75px"></asp:TextBox>
                             </td>
                             <td>
                                 Cold Test Completed</td>
                             <td class="tdstyle1">
                                 N/A
                                 <input ID="chk_5cc" runat="server" onclick="_checked('chk_5cc','_5cc')" 
                                     style="vertical-align:middle" type="checkbox" /></td>
                             <td>
                                 <asp:TextBox ID="_5cc" runat="server" Width="75px"></asp:TextBox>
                                 <asp:CalendarExtender ID="CalendarExtender38" runat="server" ClearTime="true" 
                                     Format="dd/MM/yyyy" PopupButtonID="_5cc" TargetControlID="_5cc">
                                 </asp:CalendarExtender>
                             </td>
                         </td>
                     </tr>
                    <tr >
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            Total Live Tested</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_5tl" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_5tl','_5tl')" runat="server"/></td>
                        <td>
                            <asp:TextBox ID="_5tl" runat="server" Width="75px" Text="0"></asp:TextBox>
                        </td>
                        <td>
                            Live Test Completed</td>
                        <td class="tdstyle1">N/A
                           
                            <input id="chk_5lc" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_5lc','_5lc')" runat="server"/></td>
                            <td>
                            <asp:TextBox ID="_5lc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender39" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_5lc" TargetControlID="_5lc">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            Consultant Accepted</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_5accept2" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_5accept2','_5accept2')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_5accept2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender40" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_5accept2" TargetControlID="_5accept2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            Test Sheets Files</td>
                        <td class="tdstyle2">N/A
                           <input id="chk_5filed2"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_5filed2','_5filed2')"/>
                           </td>
                        <td>
                            <asp:TextBox ID="_5filed2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender41" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_5filed2" TargetControlID="_5filed2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            Action By</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_5actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_5actby','_5actby')" runat="server"/></td>
                        <td colspan="2">
                            <asp:TextBox ID="_5actby" runat="server" Width="250px"></asp:TextBox>
                        </td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td>
                            Comment</td>
                        <td colspan="3" rowspan="2">
                            <asp:TextBox ID="_5commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            Action Date</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_5actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_5actdt','_5actdt')" runat="server"/></td>
                        <td>
                            <asp:TextBox ID="_5actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender29" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_5actdt" 
                                TargetControlID="_5actdt">
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
                            </td>
                        <td class="tdstyle1">
                        </td>
                        <td align="right">
                           <asp:Button ID="_5btnupdate" runat="server" Text="Update" 
                                onclick="_5btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_5btncancel" runat="server" Text="Cancel" 
                                onclick="_5btncancel_Click" />
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
                <div id="Div3" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress5" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload4" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
           
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy4" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender4" runat="server" TargetControlID="btnDummy4"  PopupControlID="pnlPopup4" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
        <asp:Panel ID="pnlPopup7" runat="server" Width="900px" Height="380px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:900px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_8lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                 <tr style="background-color:#83C8EE">
                <td width="200px">
                    <asp:Label ID="lblppon" runat="server" Text=""></asp:Label>
                     </td>
                     <td class="tdstyle8">
                        </td>
                <td width="75px">
                <asp:TextBox ID="_8pwron" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender66" runat="server" 
                        TargetControlID="_8pwron" PopupButtonID="_8pwron" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                </td>
                    <td width="200px">
                        &nbsp;</td>
                     <td class="tdstyle5">
                    <td width="75px">
                        &nbsp;</td>
                <td width="200px">
                </td>
                     <td class="tdstyle6">
                         &nbsp;</td>
                <td width="75px"></td>
                </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="9"  align="center" >
                            MECHANICAL SYSTEMS</td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            PRE-COMM PLANNED</td>
                        <td class="tdstyle8">&nbsp;</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_8pcp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_8pcp_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8pcp" 
                                TargetControlID="_8pcp">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            COMM PLANNED</td>
                        <td class="tdstyle5">&nbsp;
                            </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_8cp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_8cp_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8cp" 
                                TargetControlID="_8cp">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            &nbsp;</td>
                        <td class="tdstyle6">
                            &nbsp;</td>
                        <td width="75PX" >
                            &nbsp;</td>
                    </tr>
                    <tr id="tradd1" runat="server">
                        <td width="200PX">
                            PRE-COMM</td>
                        <td class="tdstyle8">N/A&nbsp;
                            <input ID="chk_8pc1" runat="server" onclick="_checked('chk_8pc1','_8pc1')" 
                                style="vertical-align:middle" type="checkbox" /></td>
                        <td width="75PX">
                            <asp:TextBox ID="_8pc1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender54" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_8pc1" TargetControlID="_8pc1">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            COMM</td>
                        <td class="tdstyle5">N/A&nbsp;
                            <input ID="chk_8co1" runat="server" onclick="_checked('chk_8co1','_8co1')" 
                                style="vertical-align:middle" type="checkbox" /></td>
                        <td width="75PX">
                            <asp:TextBox ID="_8co1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender55" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_8co1" TargetControlID="_8co1">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle6">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            % DUTY</td>
                        <td class="tdstyle8">N/A
                            <input id="chk_8duty" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_8duty','_8duty')" runat="server"/></td>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_8duty" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                         WITNESSED DATE</td>
                        <td class="tdstyle5">N/A
                            <input id="chk_8wd1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_8wd1','_8wd1')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_8wd1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender65" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_8wd1" TargetControlID="_8wd1">
                            </asp:CalendarExtender>
                        </td>
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
                        <td class="tdstyle8">N/A
                            <input id="chk_8accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_8accept1','_8accept1')"/></td>
                        <td >
                           
                            <asp:TextBox ID="_8accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender57" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8accept1" 
                                TargetControlID="_8accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle5">N/A
                            <input id="chk_8filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_8filed1','_8filed1')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_8filed1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender58" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8filed1" 
                                TargetControlID="_8filed1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle6">
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
                        <td class="tdstyle8">N/A
                            <input id="chk_8pc2" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_8pc2','_8pc2')"/>
                            </td>
                        <td>
                             <asp:CalendarExtender ID="CalendarExtender60" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8pc2" 
                                TargetControlID="_8pc2">
                            </asp:CalendarExtender>
                             <asp:TextBox ID="_8pc2" runat="server" 
                                Width="75px"></asp:TextBox></td>
                        <td>
                            COMM</td>
                        <td class="tdstyle5">N/A
                            <input id="chk_8co2" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_8co2','_8co2')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_8co2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender59" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8co2" 
                                TargetControlID="_8co2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            WITNESSED DATE</td>
                        <td class="tdstyle8">N/A
                            <input id="chk_8wd2" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_8wd2','_8wd2')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_8wd2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender64" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8wd2" 
                                TargetControlID="_8wd2">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle8">N/A
                          <input id="chk_8actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_8actby','_8actby')" runat="server"/>
                          </td>     
                            <td>
                            <asp:TextBox ID="_8actby" runat="server" Width="250px"></asp:TextBox>
                        </td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_8commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle8">N/A
                         <input id="chk_8actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_8actdt','_8actdt')" runat="server"/></td>  
                        <td>
                            
                            <asp:TextBox ID="_8actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender56" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8actdt" 
                                TargetControlID="_8actdt">
                            </asp:CalendarExtender>
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
                        <td class="tdstyle8">
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_8btnupdate" runat="server" Text="Update" 
                                onclick="_8btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_8btncancel" runat="server" Text="Cancel" 
                                onclick="_8btncancel_Click" />
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
                 <div id="Div6" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress8" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload7" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy7" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender7" runat="server" TargetControlID="btnDummy7"  PopupControlID="pnlPopup7" BackgroundCssClass="modal"></asp:ModalPopupExtender>   
        
        <asp:Panel ID="pnlPopup10" runat="server" Width="825px" Height="310px" 
                style="padding:15px;display:none;" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_17lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                 <tr style="background-color:#83C8EE">
                <td width="200px" >
                    PLANNED POWER ON</td>
                     <td class="tdstyle1">N/A
                         <input id="chk_17pwron" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_17pwron','_17pwron')" runat="server"/></td>
                <td width="75px">
                <asp:TextBox ID="_17pwron" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender82" runat="server" 
                        TargetControlID="_17pwron" PopupButtonID="_17pwron" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                </td>
                    <td width="200px">
                        &nbsp;</td>
                     <td class="tdstyle2">
                         &nbsp;</td>
                    <td width="75px">
                        &nbsp;</td>
                <td width="200px">
                </td>
                     <td class="tdstyle3">
                         &nbsp;</td>
                <td width="75px"></td>
                </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="9"  align="center">
                            COMMISSIONING &amp; ACCEPTANCE</td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            PRE-COMMM PLANNED</td>
                        <td class="tdstyle1">&nbsp;</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_17pcp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_17pcp_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17pcp" 
                                TargetControlID="_17pcp">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            COMM PLANNED</td>
                        <td class="tdstyle2">&nbsp;</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_17cp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_17cp_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17cp" 
                                TargetControlID="_17cp">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            &nbsp;</td>
                        <td class="tdstyle3">&nbsp;</td>
                        <td width="75PX" >
                           
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            PRE-COMM</td>
                        <td class="tdstyle1">
                            N/A
                            <input ID="chk_17pc1" runat="server" onclick="_checked('chk_17pc1','_17pc1')" 
                                style="vertical-align:middle" type="checkbox" />
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_17pc1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender83" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_17pc1" TargetControlID="_17pc1">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            COMM</td>
                        <td class="tdstyle2">
                            N/A
                            <input ID="chk_17co1" runat="server" onclick="_checked('chk_17co1','_17co1')" 
                                style="vertical-align:middle" type="checkbox" />
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_17co1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender89" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_17co1" TargetControlID="_17co1">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            WITNESSED DATE</td>
                        <td class="tdstyle3">
                            N/A
                            <input ID="chk_17wd1" runat="server" onclick="_checked('chk_17wd1','_17wd1')" 
                                style="vertical-align:middle" type="checkbox" />
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_17wd1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender90" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_17wd1" TargetControlID="_17wd1">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_17accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_17accept1','_17accept1')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_17accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender91" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17accept1" 
                                TargetControlID="_17accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_17filed1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_17filed1','_17filed1')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_17filed1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender92" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17filed1" 
                                TargetControlID="_17filed1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle3">
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
                            <input id="chk_17pc2" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_17pc2','_17pc2')"/>
                            </td>
                        <td>
                             <asp:CalendarExtender ID="CalendarExtender93" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17pc2" 
                                TargetControlID="_17pc2">
                            </asp:CalendarExtender>
                             <asp:TextBox ID="_17pc2" runat="server" 
                                Width="75px"></asp:TextBox></td>
                        <td>
                            COMM</td>
                        <td class="tdstyle2">N/A
                         <input id="chk_17co2" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_17co2','_17co2')"/>
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="_17co2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender94" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17co2" 
                                TargetControlID="_17co2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            WITNESSED DATE</td>
                        <td class="tdstyle3">N/A
                            <input id="chk_17wd2" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_17wd2','_17wd2')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_17wd2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender95" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17wd2" 
                                TargetControlID="_17wd2">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_17actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_17actby','_17actby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_17actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_17commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_17actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_17actdt','_17actdt')" runat="server"/></td>
                        <td>
                            
                            <asp:TextBox ID="_17actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender96" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17actdt" 
                                TargetControlID="_17actdt">
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
                           <asp:Button ID="_17btnupdate" runat="server" Text="Update" 
                                onclick="_17btnupdate_Click"/>
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_17btncancel" runat="server" Text="Cancel" 
                                onclick="_17btncancel_Click"  />
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
                 <div id="Div9" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress11" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload10" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy10" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender10" runat="server" TargetControlID="btnDummy10"  PopupControlID="pnlPopup10" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
        
        <asp:Panel ID="pnlPopup13" runat="server" Width="900px" Height="345px" 
                style="padding:15px;display:none;" BackColor="White"  >
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
                             CONTINUITY/ IR TEST PLANNED</td>
                        <td class="tdstyle1">&nbsp;</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_10ccitp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_10ccitp_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" TargetControlID="_10ccitp" >
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            DEVICE TEST PLANNED</td>
                        <td class="tdstyle2">&nbsp;</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_10dtp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_10dtp_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" TargetControlID="_10dtp">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            INTERFACE TEST PLANNED</td>
                        <td class="tdstyle3">&nbsp;</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_10itp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_10itp_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" TargetControlID="_10itp">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                             CONTINUITY/IR TESTED</td>
                        <td class="tdstyle1">
                            N/A
                            <input ID="chk_10ccit" runat="server" 
                                onclick="_checked('chk_10ccit','_10ccit')" style="vertical-align:middle" 
                                type="checkbox" />
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_10ccit" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender236" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" TargetControlID="_10ccit">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            NO.OF DEVICES TESTED</td>
                        <td class="tdstyle2">
                            N/A
                            <input ID="chk_10ndt" runat="server" onclick="_checked('chk_10ndt','_10ndt')" 
                                style="vertical-align:middle" type="checkbox" />
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_10ndt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            DEVICE TEST COMPLETE</td>
                        <td class="tdstyle3">
                            N/A
                            <input ID="chk_10dtc" runat="server" onclick="_checked('chk_10dtc','_10dtc')" 
                                style="vertical-align:middle" type="checkbox" />
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_10dtc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender110" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_10dtc" TargetControlID="_10dtc">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            FA INTERFACES TESTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_10fait" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_10fait','_10fait')"/></td>
                        <td width="75PX">
                            <asp:TextBox ID="_10fait" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender77" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_10fait" TargetControlID="_10fait">
                            </asp:CalendarExtender>
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
                         <td width="200PX">
                       <%-- <div id="tdiv" runat="server">
                          INTERFACE/ EQUIPMENT TEST</div>--%>
                          </td>
                        <td class="tdstyle2">
                       <%-- <div id="odiv" runat="server">
                            N/A
                        <input id="chk_10iet" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_10iet','_10iet')"/>
                        </div>--%>
                            </td>
                        <td width="75PX">
                       <%-- <div id="ddiv" runat="server">
                            <asp:textbox id="_10iet" runat="server" width="75px"></asp:textbox>
                            <asp:calendarextender id="calendarextender216" runat="server" 
                        targetcontrolid="_10iet" popupbuttonid="_10iet" cleartime="true" 
                        format="dd/mm/yyyy" ></asp:calendarextender>
                        </div>--%>
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
                            SOUND LEVEL TEST PLANNED</td>
                        <td class="tdstyle1">&nbsp;</td>
                        <td width="75PX">
                            <asp:TextBox ID="_10sltp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_10sltp_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" TargetControlID="_10sltp">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            CAUSE &amp; EFFECT TEST PLANNED</td>
                        <td class="tdstyle2">&nbsp;</td>
                        <td width="75PX">
                            <asp:TextBox ID="_10cetp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_10cetp_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" TargetControlID="_10cetp">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle3">&nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            SOUND LEVEL TEST</td>
                        <td class="tdstyle1">
                            N/A
                            <input ID="chk_10slt" runat="server" onclick="_checked('chk_10slt','_10slt')" 
                                style="vertical-align:middle" type="checkbox" />
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_10slt" runat="server" Width="75px"></asp:TextBox>
                              <asp:CalendarExtender ID="CalendarExtender17" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_10slt" TargetControlID="_10slt">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            BATTERY AUTONOMY TEST</td>
                        <td class="tdstyle2">
                            N/A
                            <input ID="chk_10bat" runat="server" onclick="_checked('chk_10bat','_10bat')" 
                                style="vertical-align:middle" type="checkbox" />
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_10bat" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="cal_bat" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_10bat" TargetControlID="_10bat">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            GRAPHICS/HEAD&nbsp; END TEST</td>
                        <td class="tdstyle3">
                            N/A
                            <input ID="chk_10ghet" runat="server" 
                                onclick="_checked('chk_10ghet','_10ghet')" style="vertical-align:middle" 
                                type="checkbox" />
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_10ghet" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="cal_ghet" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_10ghet" TargetControlID="_10ghet">
                            </asp:CalendarExtender>
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
        <asp:Panel ID="pnlPopup3" runat="server" Width="825px" Height="425px" style="padding:15px;display:none;" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="8" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_6lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="8"  align="center">
                            EARTHING &amp; BONDING</td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            EARTH PIT TEST PLANNED</td>
                        <td class="tdstyle1">&nbsp;</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_6epp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_6epp_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6epp" 
                                TargetControlID="_6epp">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            EARTH PIT TEST</td>
                        <td class="tdstyle1">
                            N/A
                            <input ID="chk_6ep" runat="server" onclick="_checked('chk_6ep','_6ep')" 
                                style="vertical-align:middle" type="checkbox" value="N/A" /></td>
                        <td width="75PX" >
                           
                            <asp:TextBox ID="_6ep" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender10" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_6ep" TargetControlID="_6ep">
                            </asp:CalendarExtender>
                           
                        </td>
                        <td width="200PX" >
                            &nbsp;</td>
                        <td width="75PX" >
                            
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_6accept1" type="checkbox" style="vertical-align:middle" runat="server" value="n/a" onclick="_checked('chk_6accept1','_6accept1')"/>
                            </td>
                        <td >
                            <asp:TextBox ID="_6accept1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender12" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6accept1" 
                                TargetControlID="_6accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_6filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_6filed1','_6filed1')"/>
                            </td>
                        <td >
                            <asp:TextBox ID="_6filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender27" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6filed1" 
                                TargetControlID="_6filed1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    <tr >
                        <td>
                            (EARTHING)BONDING OF ALL EQUIPMENT COMPETE PLANNED</td>
                        <td class="tdstyle1">&nbsp;</td>
                        <td>
                            <asp:TextBox ID="_6ebp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_6ebp_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6ebp" 
                                TargetControlID="_6ebp">
                            </asp:CalendarExtender>
                            
                        </td>
                        <td>
                            (EARTHING)BONDING OF ALL EQUIPMENT COMPETE</td>
                        <td class="tdstyle1">
                            N/A
                            <input ID="chk_6be" runat="server" onclick="_checked('chk_6be','_6be')" 
                                style="vertical-align:middle" type="checkbox" /></td>
                        <td>
                            <asp:TextBox ID="_6be" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender28" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_6be" TargetControlID="_6be">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_6accept2" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_6accept2','_6accept2')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_6accept2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender21" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_6accept2" TargetControlID="_6accept2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            TEST SHEETS FILED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_6filed2"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_6filed2','_6filed2')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_6filed2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender22" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_6filed2" TargetControlID="_6filed2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="8" align="center">
                            LIGHTNING PROTECTION</td>
                    </tr>
                    <tr >
                        <td >
                            LIGHTNING PROTECTION PIT TEST PLANNED</td>
                        <td class="tdstyle1">&nbsp;</td>
                        <td >
                            <asp:TextBox ID="_6lpp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_6lpp_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6lpp" 
                                TargetControlID="_6lpp">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            LIGHTNING PROTECTION PIT TEST</td>
                        <td class="tdstyle1">
                            N/A
                            <input ID="chk_6lp" runat="server" onclick="_checked('chk_6lp','_6lp')" 
                                style="vertical-align:middle" type="checkbox" /></td>
                        <td >
                            <asp:TextBox ID="_6lp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender31" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_6lp" TargetControlID="_6lp">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                             <input id="chk_6accept3" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_6accept3','_6accept3')"/>
                            </td>
                        <td >
                            <asp:TextBox ID="_6accept3" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender23" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6accept3" 
                                TargetControlID="_6accept3">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_6filed3"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_6filed3','_6filed3')"/>
                            </td>
                        <td >
                            <asp:TextBox ID="_6filed3" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender24" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6filed3" 
                                TargetControlID="_6filed3">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    <tr >
                        <td>
                            BONDING OF ROOF EQUIP. AND DOWN CONDU. TEST COMPLETE PLANNED</td>
                        <td class="tdstyle1">&nbsp;</td>
                        <td>
                            <asp:TextBox ID="_6brp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_6brp_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6brp" 
                                TargetControlID="_6brp">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            BONDING OF ROOF EQUIP. AND DOWN CONNDU. TEST COMPLETE</td>
                        <td class="tdstyle1">
                            N/A
                            <input ID="chk_6br" runat="server" onclick="_checked('chk_6br','_6br')" 
                                style="vertical-align:middle" type="checkbox" /></td>
                        <td>
                            <asp:TextBox ID="_6br" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender32" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_6br" TargetControlID="_6br">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_6accept4" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_6accept4','_6accept4')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_6accept4" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender33" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6accept4" 
                                TargetControlID="_6accept4">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            TEST SHEETS FILED</td>
                        <td class="tdstyle1">N/A
                             <input id="chk_6filed4"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_6filed4','_6filed4')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_6filed4" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender34" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6filed4" 
                                TargetControlID="_6filed4">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_6actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_6actby','_6actby')" runat="server"/></td>
                        <td colspan="2">
                            <asp:TextBox ID="_6actby" runat="server" Width="250px"></asp:TextBox>
                        </td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            <asp:TextBox ID="_6commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_6actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_6actdt','_6actdt')" runat="server"/></td>
                        <td>
                            <asp:TextBox ID="_6actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender25" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6actdt" 
                                TargetControlID="_6actdt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle1">
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
                            <asp:Button ID="_6btnupdate" runat="server" 
                                Text="Update" onclick="_6btnupdate_Click" />
                        </td>
                        <td align="left">
                            <asp:Button ID="_6btncancel" runat="server"
                                Text="Cancel" onclick="_6btncancel_Click" />
                        </td>
                        <td align="left" class="tdstyle1">
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
                 <div id="Div2" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress4" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload3" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
            
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy3" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender3" runat="server" TargetControlID="btnDummy3"  PopupControlID="pnlPopup3" BackgroundCssClass="modal"></asp:ModalPopupExtender>
        <asp:Panel ID="pnlPopup8" runat="server" Width="825px" Height="280px" 
                style="padding:15px;display:none;" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_21lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                 <tr style="background-color:#83C8EE">
                <td width="200px">
                    PLANNED POWER ON</td>
                     <td class="tdstyle1">N/A
                        <input id="chk_21pwron" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_21pwron','_21pwron')" runat="server"/></td>
                <td width="75px">
                <asp:TextBox ID="_21pwron" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender67" runat="server" 
                        TargetControlID="_21pwron" PopupButtonID="_21pwron" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                </td>
                    <td width="200px">
                        PLANNED COMPLETION DATE</td>
                     <td>
                         &nbsp;</td>
                    <td width="75px">
                        <asp:TextBox ID="_21pcd" runat="server" Width="75px"></asp:TextBox>
                        <asp:CalendarExtender ID="_21pcd_CalendarExtender" runat="server" 
                            ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_21pcd" 
                            TargetControlID="_21pcd">
                        </asp:CalendarExtender>
                     </td>
                <td width="200px">
                </td>
                     <td>
                         &nbsp;</td>
                <td width="75px"></td>
                </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="9"  align="center">
                            MECHANICAL SYSTEMS</td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            PLAIN FLUSHING</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_21pf" type="checkbox" style="vertical-align:middle" runat="server" runat="server"  onclick="_checked('chk_21pf','_21pf')"/>
                            </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_21pf" runat="server" Width="75px"></asp:TextBox>
                              <asp:CalendarExtender ID="CalendarExtender68" runat="server" 
                        TargetControlID="_21pf" PopupButtonID="_21pf" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            FLUSHING VELOCITIES RECORDED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_21fvr" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_21fvr','_21fvr')"/>
                            </td>
                        <td width="75PX" >
                             
                            <asp:TextBox ID="_21fvr" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender69" runat="server" 
                        TargetControlID="_21fvr" PopupButtonID="_21fvr" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            CHEMICAL CLEANING</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_21cc" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_21cc','_21cc')"/>
                            </td>
                        <td width="75PX" >
                           
                            <asp:TextBox ID="_21cc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender70" runat="server" 
                        TargetControlID="_21cc" PopupButtonID="_21cc" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            FLUSHING AFTER CHEMICAL CLEANING</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_21facc" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_21facc','_21facc')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_21facc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender73" runat="server" 
                        TargetControlID="_21facc" PopupButtonID="_21facc" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            BACK FLUSHING COMPLETE</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_21bfc" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_21bfc','_21bfc')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_21bfc" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender74" runat="server" 
                        TargetControlID="_21bfc" PopupButtonID="_21bfc" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            FINAL CHEMICAL TREATMENT</td>
                        <td class="tdstyle3">N/A
                            <input id="chk_21fct" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_21fct','_21fct')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_21fct" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender75" runat="server" 
                        TargetControlID="_21fct" PopupButtonID="_21fct" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_21accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_21accept1','_21accept1')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_21accept1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender71" runat="server" 
                        TargetControlID="_21accept1" PopupButtonID="_21accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td>N/A
                            <input id="chk_21filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_21filed1','_21filed1')"/>
                            </td>
                            
                        <td >
                           
                            <asp:TextBox ID="_21filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender72" runat="server" 
                        TargetControlID="_21filed1" PopupButtonID="_21filed1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_21actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_21actby','_21actby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_21actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_21commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_21actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_21actdt','_21actdt')" runat="server"/></td>
                        <td>
                            
                            <asp:TextBox ID="_21actdt" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender76" runat="server" 
                        TargetControlID="_21actdt" PopupButtonID="_21actdt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
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
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_21btnupdate" runat="server" Text="Update" 
                                onclick="_21btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_21btncancel" runat="server" Text="Cancel" 
                                onclick="_21btncancel_Click"  />
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
                 <div id="Div7" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress9" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload8" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy8" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender8" runat="server" TargetControlID="btnDummy8"  PopupControlID="pnlPopup8" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
        
        <asp:Panel ID="pnlPopup5" runat="server" Width="825px" Height="380px" style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_4lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="9"  align="center">
                            GENERATOR SET STAND ALONE TESTING</td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            PLANNED COMPLETION DATE</td>
                        <td class="tdstyle1">&nbsp;</td>
                        <td width="75PX" >
                                 <asp:TextBox ID="_4pcd" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_4pcd" TargetControlID="_4pcd">
                            </asp:CalendarExtender></td>
                        <td width="200PX" >
                            &nbsp;</td>
                        <td class="tdstyle2">&nbsp;</td>
                        <td width="75PX" >
                            
                            &nbsp;</td>
                        <td width="200PX" >
                            &nbsp;</td>
                        <td class="tdstyle3">&nbsp;</td>
                        <td width="75PX" >
                           
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            PRE-COM
                        </td>
                        <td class="tdstyle1">
                            N/A
                            <input ID="chk_4pc" runat="server" onclick="_checked('chk_4pc','_4pc')" 
                                style="vertical-align:middle" type="checkbox" />
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_4pc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender42" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_4pc" TargetControlID="_4pc">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            ALARM &amp; SHUTDOWN TEST</td>
                        <td class="tdstyle2">
                            N/A
                            <input ID="chk_4as" runat="server" onclick="_checked('chk_4as','_4as')" 
                                style="vertical-align:middle" type="checkbox" />
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_4as" runat="server" style="margin-left: 0px" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender43" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_4as" TargetControlID="_4as">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            LOAD BANK TEST</td>
                        <td class="tdstyle3">
                            N/A
                            <input ID="chk_4lb" runat="server" onclick="_checked('chk_4lb','_4lb')" 
                                style="vertical-align:middle" type="checkbox" />
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_4lb" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender44" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_4lb" TargetControlID="_4lb">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_4accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_4accept1','_4accept1')"/></td>
                        <td>
                           
                            <asp:TextBox ID="_4accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender45" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4accept1" 
                                TargetControlID="_4accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_4filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_4filed1','_4filed1')"/>
                            </td>
                        <td>
                           
                            <asp:TextBox ID="_4filed1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender46" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4filed1" 
                                TargetControlID="_4filed1">
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
                    <tr id="tr12" runat="server">
                     <td >
                          Cable Cold Test Planned</td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td >
                        <asp:TextBox ID="_4cablep" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4cablep" 
                                TargetControlID="_4cablep">
                            </asp:CalendarExtender>
                           
                        </td>
                        <td >
                            CABLE COLD TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_4cable" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_4cable','_4cable')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_4cable" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender47" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4cable" 
                                TargetControlID="_4cable">
                            </asp:CalendarExtender>
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
                            <input id="chk_4accept2" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_4accept2','_4accept2')"/>
                            </td>
                        <td>
                           
                            <asp:TextBox ID="_4accept2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender48" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4accept2" 
                                TargetControlID="_4accept2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">N/A
                             <input id="chk_4filed2"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_4filed2','_4filed2')"/>
                            </td>
                        <td>
                           
                            <asp:TextBox ID="_4filed2" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender49" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4filed2" 
                                TargetControlID="_4filed2">
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
                            SITE OPERATION &amp; LOAD TEST</td>
                    </tr>
                    <tr >
                    <td>
                            SITE OPERATION LOAD TEST PLANNED</td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td>
                             <asp:TextBox ID="_4solp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4solp" 
                                TargetControlID="_4solp">
                            </asp:CalendarExtender></td>
                        <td>
                            SITE OPERATION LOAD TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_4sol" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_4sol','_4sol')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_4sol" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender50" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4sol" 
                                TargetControlID="_4sol">
                            </asp:CalendarExtender>
                        </td>
                        
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
                            <input id="chk_4accept3" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_4accept3','_4accept3')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_4accept3" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender51" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4accept3" 
                                TargetControlID="_4accept3">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">N/A
                             <input id="chk_4filed3"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_4filed3','_4filed3')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_4filed3" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender52" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4filed3" 
                                TargetControlID="_4filed3">
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
                           <input id="chk_4actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_4actby','_4actby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_4actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_4commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle1">N/A
                          <input id="chk_4actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_4actdt','_4actdt')" runat="server"/></td>
                        <td>
                            
                            <asp:TextBox ID="_4actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender53" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4actdt" 
                                TargetControlID="_4actdt">
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
                           <asp:Button ID="_4btnupdate" runat="server" Text="Update" 
                                onclick="_4btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_4btncancel" runat="server" Text="Cancel" 
                                onclick="_4btncancel_Click" />
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
        <asp:UpdateProgress ID="UpdateProgress6" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload5" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
               
           
            </div>
        </asp:Panel>
        
         <asp:Button ID="btnDummy5" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender5" runat="server" TargetControlID="btnDummy5"  PopupControlID="pnlPopup5" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
       
               <asp:Panel ID="pnlPopup6" runat="server" Width="825px" Height="263px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_7lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="9"  align="center">
                            EMERGENCY LIGHTING / CENTRAL BATTERY SYSTEM</td>
                    </tr>
                
                    <tr >
                     <td width="200PX" >
                            PLANNED COMPLETION </td>
                        <td class="tdstyle1">
                            
                            </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_7pc" runat="server" Width="75px" Text=""></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender122" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7pc" 
                                TargetControlID="_7pc">
                            </asp:CalendarExtender>
                        </td>
                    
                        <td width="200PX" >
                            CONTINUITY/IR TEST COMPLETE</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_7cir" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_7cir','_7cir')"/>
                            </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_7cir" runat="server" Width="75px" Text="0"></asp:TextBox>
                             <%--<asp:CalendarExtender ID="CalendarExtender54" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7cir" 
                                TargetControlID="_7cir">
                            </asp:CalendarExtender>--%>
                        </td>
                        <td width="200PX" >
                            ADDRESSING</td>
                        <td class="tdstyle2">N/A
                           <input id="chk_7add" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_7add','_7add')"/>
                           </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_7add" runat="server" Width="75px" Text="0"></asp:TextBox>
                           <%-- <asp:CalendarExtender ID="CalendarExtender55" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7add" 
                                TargetControlID="_7add">
                            </asp:CalendarExtender>--%>
                        </td>
                        </tr>
                        <tr>
                        <td width="200PX" >
                            FAULT TEST</td>
                        <td class="tdstyle3">N/A
                            <input id="chk_7ft" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_7ft','_7ft')"/>
                            </td>
                        <td width="75PX" >
                           
                            <asp:TextBox ID="_7ft" runat="server" Width="75px" Text="0"></asp:TextBox>
                            <%--<asp:CalendarExtender ID="CalendarExtender56" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7ft" 
                                TargetControlID="_7ft">
                            </asp:CalendarExtender>--%>
                        </td>

                        <td >
                            CHANGE OVER TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_7co" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_7co','_7co')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_7co" runat="server" Width="75px" Text="0"></asp:TextBox>
                           <%--<asp:CalendarExtender ID="CalendarExtender57" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7co" 
                                TargetControlID="_7co">
                            </asp:CalendarExtender>--%>
                        </td>
                        <td >
                            LUX LEVEL TEST</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_7ll" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_7ll','_7ll')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_7ll" runat="server" Width="75px" Text="0"></asp:TextBox>
                           <%--<asp:CalendarExtender ID="CalendarExtender58" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7ll" 
                                TargetControlID="_7ll">
                            </asp:CalendarExtender>--%>
                        </td>
                      </tr>
                    <tr>
                        <td >
                            DURATION TEST</td>
                        <td class="tdstyle3">N/A
                            <input id="chk_7du" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_7du','_7du')"/>
                            </td>
                        <td >
                            
                            <asp:TextBox ID="_7du" runat="server" Width="75px" Text="0"></asp:TextBox>
                            <%--<asp:CalendarExtender ID="CalendarExtender59" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7du" 
                                TargetControlID="_7du">
                            </asp:CalendarExtender>--%>
                        </td>

                        <td>
                            PC HEAD END TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_7pch" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_7pch','_7pch')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_7pch" runat="server" Width="75px" Text="0"></asp:TextBox>
                            <%-- <asp:CalendarExtender ID="CalendarExtender60" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7pch" 
                                TargetControlID="_7pch">
                            </asp:CalendarExtender>--%>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="_7noof" runat="server" Width="75px" style="display:none"></asp:TextBox>
                            <asp:TextBox ID="_7nocir" runat="server" Width="75px" style="display:none"></asp:TextBox>
                           
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_7accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_7accept1','_7accept1')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_7accept1" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender61" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7accept1" 
                                TargetControlID="_7accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_7filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_7filed1','_7filed1')"/></td>
                        <td>
                            <asp:TextBox ID="_7filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender62" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7filed1" 
                                TargetControlID="_7filed1">
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
                            <input id="chk_7actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_7actby','_7actby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_7actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_7commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle1">N/A
                       <input id="chk_7actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_7actdt','_7actdt')" runat="server"/></td>
                        <td>
                            
                            <asp:TextBox ID="_7actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender63" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7actdt" 
                                TargetControlID="_7actdt">
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
                           <asp:Button ID="_7btnupdate" runat="server" Text="Update" 
                                onclick="_7btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_7btncancel" runat="server" Text="Cancel" 
                                onclick="_7btncancel_Click" />
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
                 <div id="Div5" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress7" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload6" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy6" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender6" runat="server" TargetControlID="btnDummy6"  PopupControlID="pnlPopup6" BackgroundCssClass="modal"></asp:ModalPopupExtender>  
        
        
                 <asp:Panel ID="pnlPopup11" runat="server" Width="825px" Height="200px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:835px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_18lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>

                    <tr >
                        <td width="200PX" >
                            PLANNED COMP DATE</td>
                        <td class="tdstyle1">&nbsp;</td>
                        <td width="75PX" >
                             <asp:TextBox ID="_18pcd" runat="server" Width="75px" >
                               </asp:TextBox>
                               <asp:CalendarExtender ID="CalendarExtender4" runat="server" 
                        TargetControlID="_18pcd" PopupButtonID="_18pcd" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender></td>
                        <td width="200PX" >
                            &nbsp;</td>
                        <td class="tdstyle2">&nbsp;</td>
                        <td width="75PX" >
                            
                            &nbsp;</td>
                        <td width="200PX" >
                            &nbsp;</td>
                        <td class="tdstyle1">&nbsp;</td>
                        <td width="75PX" >
                           
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            QUANTITY TESTED</td>
                        <td class="tdstyle1">
                            N/A
                            <input ID="chk_18qt" runat="server" onclick="_checked('chk_18qt','_18qt')" 
                                style="vertical-align:middle" type="checkbox" />
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_18qt" runat="server" Width="75px">
                            </asp:TextBox>
                        </td>
                        <td width="200PX">
                            WITNESSED</td>
                        <td class="tdstyle2">
                            N/A
                            <input ID="chk_18wt" runat="server" onclick="_checked('chk_18wt','_18wt')" 
                                style="vertical-align:middle" type="checkbox" />
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_18wt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender98" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_18wt" TargetControlID="_18wt">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            <asp:Label ID="_18lblicom" runat="server" Text="INSTALLATION SIGN OFF"></asp:Label>
                        </td>
                        <td class="tdstyle1">
                            N/A
                            <input ID="chk_18icom" runat="server" 
                                onclick="_checked('chk_18icom','_18icom')" style="vertical-align:middle" 
                                type="checkbox" />
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_18noof" runat="server" style="display:none" Width="75px"></asp:TextBox>
                            <asp:TextBox ID="_18icom" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_18wt0_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_18icom" 
                                TargetControlID="_18icom">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_18accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_18accept1','_18accept1')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_18accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender101" runat="server" 
                        TargetControlID="_18accept1" PopupButtonID="_18accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_18filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_18filed1','_18filed1')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_18filed1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender102" runat="server" 
                        TargetControlID="_18filed1" PopupButtonID="_18filed1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_18actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_18actby','_18actby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_18actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_18commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_18actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_18actdt','_18actdt')" runat="server"/></td>
                        <td>
                            
                            <asp:TextBox ID="_18actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender103" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_18actdt" 
                                TargetControlID="_18actdt">
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
                           <asp:Button ID="_18btnupdate" runat="server" Text="Update" 
                                onclick="_18btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_18btncancel" runat="server" Text="Cancel" 
                                onclick="_18btncancel_Click" />
                        </td>
                        <td align="left" class="tdstyle2">
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
                 <div id="Div10" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress12" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload11" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy11" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender11" runat="server" TargetControlID="btnDummy11"  PopupControlID="pnlPopup11" BackgroundCssClass="modal"></asp:ModalPopupExtender>
        
        <asp:Panel ID="pnlPopup12" runat="server" Width="825px" Height="235px" 
                style="padding:15px;display:none;" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_19lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr>
                        <td width="200PX" >
                           PLANNED COMP DATE</td>
                        <td class="tdstyle1">
                        
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_19pcd" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender11" runat="server" 
                        TargetControlID="_19pcd" PopupButtonID="_19pcd" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            ROOM/SYSTEM INTEGRITY TEST&nbsp;</td>
                        <td class="tdstyle1">N/A
                        <input id="chk_19rsit" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_19rsit','_19rsit')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_19rsit" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender105" runat="server" 
                        TargetControlID="_19rsit" PopupButtonID="_19rsit" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            STAND ALONE COMMISSION</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_19sac" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_19sac','_19sac')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_19sac" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender97" runat="server" 
                        TargetControlID="_19sac" PopupButtonID="_19sac" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            FIRE &amp; BMS INTERFACE TEST</td>
                        <td class="tdstyle3">N/A
                            <input id="chk_19fbit" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_19fbit','_19fbit')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_19fbit" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender106" runat="server" 
                        TargetControlID="_19fbit" PopupButtonID="_19fbit" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            WITNESSED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_19wt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_19wt','_19wt')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_19wt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender107" runat="server" 
                        TargetControlID="_19wt" PopupButtonID="_19wt" ClearTime="true" 
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
                            <input id="chk_19accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_19accept1','_19accept1')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_19accept1" runat="server" Width="75px"></asp:TextBox>
                          <asp:CalendarExtender ID="CalendarExtender99" runat="server" 
                        TargetControlID="_19accept1" PopupButtonID="_19accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_19filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_19filed1','_19filed1')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_19filed1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender100" runat="server" 
                        TargetControlID="_19filed1" PopupButtonID="_19filed1" ClearTime="true" 
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
                          <input id="chk_19actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_19actby','_19actby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_19actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_19commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle1">N/A
                         <input id="chk_19actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_19actdt','_19actdt')" runat="server"/></td>
                        <td>
                            
                            <asp:TextBox ID="_19actdt" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender104" runat="server" 
                        TargetControlID="_19actdt" PopupButtonID="_19actdt" ClearTime="true" 
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
                           <asp:Button ID="_19btnupdate" runat="server" Text="Update" 
                                onclick="_19btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_19btncancel" runat="server" Text="Cancel" 
                                onclick="_19btncancel_Click" />
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
                 <div id="Div11" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress13" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload12" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy12" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender12" runat="server" TargetControlID="btnDummy12"  PopupControlID="pnlPopup12" BackgroundCssClass="modal"></asp:ModalPopupExtender>
        
        
                 <asp:Panel ID="pnlPopup14" runat="server" Width="900" Height="355px" 
                style="padding:15px;display:none;" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="_20points" runat="server" style="display:none"></asp:TextBox>
                    <asp:TextBox ID="_20devices" runat="server" style="display:none"></asp:TextBox>
                    <asp:TextBox ID="_20system" runat="server" style="display:none"></asp:TextBox>
                    <asp:TextBox ID="TextBox2" runat="server" style="display:none"></asp:TextBox>
                <table style="font-size:x-small;width:900px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_20lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            CONTINUITY/IR TESTED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_20cit" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20cit','_20cit')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_20cit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        
                         <td width="200PX">
                            POINT TO POINT TEST PLANNED</td>
                        <td class="tdstyle1" >
                            
                            </td>
                        <td width="75PX" >
                           <asp:TextBox ID="_20pptp" runat="server" Width="75px"></asp:TextBox> 
                           <asp:CalendarExtender ID="CalendarExtender7" runat="server" 
                        TargetControlID="_20pptp" PopupButtonID="_20pptp" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        
                        <td width="200PX">
                            POINT TO POINT TEST</td>
                        <td class="tdstyle3" >N/A
                            <input id="chk_20ppt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20ppt','_20ppt')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_20ppt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        
                           <td width="200PX">
                           CALIBRATION/FUNCTIONAL TEST PLANNED
                            </td>
                             <td class="tdstyle1" >
                             </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_20cftp" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender6" runat="server" 
                        TargetControlID="_20cftp" PopupButtonID="_20cftp" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        
                        <td width="200PX" >
                            CALIBRATION/FUNCTIONAL TEST</td>
                        <td class="tdstyle3">N/A
                            <input id="chk_20cft" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20cft','_20cft')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_20cft" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td width="200PX">
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_20accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20accept1','_20accept1')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_20accept1" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender121" runat="server" 
                        TargetControlID="_20accept1" PopupButtonID="_20accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            TEST SHEETS FILED</td>
                        <td class="tdstyle1" >N/A
                           <input id="chk_20filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20filed1','_20filed1')"/>
                           </td>
                        <td width="75PX">
                            <asp:TextBox ID="_20filed1" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender5" runat="server" 
                        TargetControlID="_20filed1" PopupButtonID="_20filed1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle3" >
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            SEQ. OF OPERATION TEST</td>
                        <td class="tdstyle2" >N/A
                            <input id="chk_20sot" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20sot','_20sot')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_20sot" runat="server" Width="75px"></asp:TextBox>
                        </td>
                         <td width="200PX">
                            GRAPHICS/HEAD END TEST PLANNED</td>
                        <td class="tdstyle1" >
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_20ghtp" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender8" runat="server" 
                        TargetControlID="_20ghtp" PopupButtonID="_20ghtp" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            GRAPHICS/HEAD END TEST</td>
                        <td class="tdstyle1" >N/A
                            <input id="chk_20ght" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20ght','_20ght')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_20ght" runat="server" Width="75px"></asp:TextBox>
                        </td>
                       
                    </tr>
                    <tr  style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td width="200PX">
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle2" >N/A
                            <input id="chk_20accept2" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20accept2','_20accept2')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_20accept2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender109" runat="server" 
                        TargetControlID="_20accept2" PopupButtonID="_20accept2" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            TEST SHEETS FILED</td>
                        <td class="tdstyle1" >N/A
                            <input id="chk_20filed2"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20filed2','_20filed2')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_20filed2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender111" runat="server" 
                        TargetControlID="_20filed2" PopupButtonID="_20filed2" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle3" >
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            LOOP TUNING</td>
                        <td class="tdstyle2" >N/A
                        <input id="chk_20lt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20lt','_20lt')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_20lt" runat="server" Width="75px"></asp:TextBox>
                       </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle1" >
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle3" >
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle2" >N/A
                             <input id="chk_20accept3" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20accept3','_20accept3')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_20accept3" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender127" runat="server" 
                        TargetControlID="_20accept3" PopupButtonID="_20accept3" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle1" >N/A
                           
                            <input id="chk_20filed3"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20filed3','_20filed3')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_20filed3" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender128" runat="server" 
                        TargetControlID="_20filed3" PopupButtonID="_20filed3" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle3" >
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle2" >N/A
                            <input id="chk_20actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_20actby','_20actby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_20actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle1" >
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_20commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle2" >N/A
                           <input id="chk_20actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_20actdt','_20actdt')" runat="server"/></td>
                        <td>
                            
                            <asp:TextBox ID="_20actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender129" runat="server" 
                        TargetControlID="_20actdt" PopupButtonID="_20actdt" ClearTime="true" 
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
                           <asp:Button ID="_20btnupdate" runat="server" Text="Update" 
                                onclick="_20btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_20btncancel" runat="server" Text="Cancel" 
                                onclick="_20btncancel_Click" />
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
                <asp:Image ID="imgload14" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy14" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender14" runat="server" TargetControlID="btnDummy14"  PopupControlID="pnlPopup14" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
        
        <asp:Button ID="btnDummy15a" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender15a" runat="server" TargetControlID="btnDummy15a"  PopupControlID="pnlPopup15a" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
        <asp:Panel ID="pnlPopup15a" runat="server" Width="830px" Height="330px" 
                style="padding:15px;" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel44" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_15albl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                     <td width="200PX" >
                            CONTINUITY/IR TEST PLANNED</td>
                        <td >
                            &nbsp;</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15acitp" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender13" runat="server" 
                        TargetControlID="_15acitp" PopupButtonID="_15acitp" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            CONTINUITY/IR TEST&nbsp;</td>
                        <td class="tdstyle1">
                            N/A
                             <input id="chk_15acit" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15acit','_15acit')" runat="server"/></td>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15acit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            &nbsp;NO OF TEST HOLES TESTED </td>
                        <td class="tdstyle3">
                            N/A
                             <input id="chk_15atht" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15atht','_15atht')" runat="server"/></td>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15atht" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                     <td width="200PX" >
                            TEST HOLE TEST COMPLETE PLANNED</td>
                        <td class="tdstyle1">
                            
                            
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15athtcp" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender14" runat="server" 
                        TargetControlID="_15athtcp" PopupButtonID="_15athtcp" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            TEST HOLE TEST COMPLETE</td>
                        <td class="tdstyle2">
                            N/A
                            <input id="chk_15athtc" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15athtc','_15athtc')" runat="server"/></td>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_15athtc" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            FA INTERFACES TESTED</td>
                        <td class="tdstyle3">
                            N/A
                            <input id="chk_15afit" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15afit','_15afit')" runat="server"/></td>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_15afit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        </TR>
                        <tr>
                        <td width="200PX" >
                            FA INTERFACE TEST COMPLETE PLANNED</td>
                            <td class="tdstyle1">
                                </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15afitcp" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender15" runat="server" 
                        TargetControlID="_15afitcp" PopupButtonID="_15afitcp" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            FA INTERFACE TEST COMPLETE</td>
                            <td class="tdstyle2">
                                N/A
                                <input id="chk_15afitc" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15afitc','_15afitc')" runat="server"/></td>
                                </td>
                        <td width="75PX">
                            <asp:TextBox ID="_15afitc" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td></td>
                            <td>
                                &nbsp;</td>
                        <td></td>
                    </tr>
                         <tr style="background-color:#092443;color:White">
                        <td colspan="9" align="center">
                            TEST SHEETS</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">
                            N/A
                            <input id="chk_15aaccept1" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15aaccept1','_15aaccept1')" runat="server"/></td>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_15aaccept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender230" runat="server" 
                        TargetControlID="_15aaccept1" PopupButtonID="_15aaccept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">
                           <input id="chk_15afiled1" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15afiled1','_15afiled1')" runat="server"/></td>
                            
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_15afiled1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender231" runat="server" 
                        TargetControlID="_15afiled1" PopupButtonID="_15afiled1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            <asp:TextBox ID="_15anoof" runat="server" Width="75px" style="display:none"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr>
                        <td>
                            BATTERY AUTONOMY TEST</td>
                        <td class="tdstyle1">
                            N/A
                            <input id="chk_15abat" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15abat','_15abat')" runat="server"/></td>
                            </td>
                        <td>
                            <asp:TextBox ID="_15abat" runat="server" Width="75px"></asp:TextBox>
                        </td>
                         <td width="200PX" >
                            CAUSE EFFECT TESTS PLANNED</td>
                        <td >
                           
                             
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15acetp" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender16" runat="server" 
                        TargetControlID="_15acetp" PopupButtonID="_15acetp" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            CAUSE EFFECT TESTS</td>
                        <td class="tdstyle2"> N/A
                        <input id="chk_15acet" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15acet','_15acet')" runat="server"/></td>
                        </td>
                        <td>
                            <asp:TextBox ID="_15acet" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr style="background-color:#092443;color:White">
                        <td colspan="9" align="center">
                           FINAL TEST SHEETS</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">
                            N/A
                            <input id="chk_15aaccept2" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15aaccept2','_15aaccept2')" runat="server"/></td>
                            </td>
                        <td>
                            <asp:TextBox ID="_15aaccept2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_15afiled5_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_15aaccept2" 
                                TargetControlID="_15aaccept2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            TEST SHEETS FILED</td>
                        <td class="tdstyle2">
                            N/A
                            <input id="chk_15afiled2" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_15afiled2','_15afiled2')" runat="server"/></td>
                            </td>
                        <td>
                            <asp:TextBox ID="_15afiled2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_15afiled3_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_15afiled2" 
                                TargetControlID="_15afiled2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_15aactby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_15acommts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            
                            <asp:TextBox ID="_15aactdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender232" runat="server" 
                        TargetControlID="_15aactdt" PopupButtonID="_15aactdt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
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
                        <td>
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_15abtnupdate" runat="server" Text="Update" 
                                onclick="_15abtnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_15abtncancel" runat="server" Text="Cancel" 
                                onclick="_15abtncancel_Click"  />
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
                 <div id="Div25" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress34" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload15a" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px"  />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        

    </form>
</body>
</html>
