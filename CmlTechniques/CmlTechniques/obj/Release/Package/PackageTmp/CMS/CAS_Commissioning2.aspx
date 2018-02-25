<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CAS_Commissioning2.aspx.cs" Inherits="CmlTechniques.CMS.CAS_Commissioning2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
           function _cleared(sender, target) {
            var _chk = document.getElementById(sender).checked;
            var _txt = document.getElementById(target);
                _txt.value = "";
            if (_chk == true) {
                _txt.disabled = true;
            }
            else {
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
                    <td align="center" rowspan="2" valign="middle" width="5%">
                        &nbsp;
                    </td>
                    <td align="center" rowspan="2" valign="middle" width="5%">
                        ITEM NO
                    </td>
                    <td align="center" rowspan="2" valign="middle" width="10%">
                        ENG.REF
                    </td>
                    <td align="center" colspan="4" valign="middle">
                        ASSET CODE
                    </td>

                    <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbl0" runat="server">
                        <asp:Label ID="lbloc" runat="server" Text="LOCATION"></asp:Label>
                    </td>
                       <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbldes" runat="server">
                        <asp:Label ID="lbldes" runat="server" Text="SYSTEMS CONTROLLED / MONITORED BY DDC"></asp:Label>
                           </td>
                    <td align="center" rowspan="2" valign="middle" width="9%" id="td_lbl3" runat="server">
                        <asp:Label ID="lbl3" runat="server"></asp:Label>
                    </td>
                    <td align="center" rowspan="2" valign="middle" width="7%" id="td_lbl1" runat="server">
                        <asp:Label ID="lbl1" runat="server"></asp:Label>
                    </td>
                    <td align="center" rowspan="2" valign="middle" width="8%" id="td_lbl2" runat="server">
                        <asp:Label ID="lbl2" runat="server"></asp:Label>
                    </td>
                    <td align="center" rowspan="2" valign="middle" width="8%" id="td_lbnum" runat="server">
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
                    
                    <td id="td0" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="drloc" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="drloc_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td id="td_txtdescr" runat="server">
                        &nbsp;
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
                                                            <ItemStyle Width="5%" />
                                                        </asp:ButtonField>
                                                        <asp:BoundField HeaderText="Itm.No" ItemStyle-Width="6%">
                                                            <ItemStyle Width="5%" HorizontalAlign="Center" />
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
                                                      
                                                        <asp:BoundField DataField="Loc" HeaderText="Location" ItemStyle-Width="10%">
                                                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                          <asp:BoundField DataField="Des" HeaderText="Substation" ItemStyle-Width="10%">
                                                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="F_from" HeaderText="Fed From" ItemStyle-Width="10%">
                                                            <ItemStyle Width="9%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="P_P_to" HeaderText="Provides Power To" ItemStyle-Width="10%">
                                                            <ItemStyle Width="7%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Substation" HeaderText="Substation" ItemStyle-Width="10%">
                                                            <ItemStyle Width="8%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="devices1" ItemStyle-Width="10%">
                                                            <ItemStyle Width="8%" HorizontalAlign="Center" />
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
        
       <asp:Panel ID="pnlPopup14" runat="server" Width="900" Height="335px" 
                style="padding:15px;" BackColor="White"  >
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
                            <input id="chk_20ppt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20ppt','_20ppt');_cleared('chk_20ppt','_20pptp');"/>
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
                            <input id="chk_20cft" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20cft','_20cft');_cleared('chk_20cft','_20cftp');"/>
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
                            <input id="chk_20ght" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20ght','_20ght');_cleared('chk_20ght','_20ghtp');"/>
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
        

        
        
    </form>
</body>
</html>
