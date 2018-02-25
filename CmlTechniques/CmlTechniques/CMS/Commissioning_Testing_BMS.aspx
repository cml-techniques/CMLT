<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Commissioning_Testing_BMS.aspx.cs" Inherits="CmlTechniques.CMS.Commissioning_Testing_BMS" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .tdstyle1
        {
            width: 90px;
             font-size:x-small; 
             color: #FF0000;
        }
        .tdstyle2
        {
            width: 90px;
           font-size:x-small; 
           color: #FF0000;
        }
        .tdstyle3
        {
            width: 90px;
            font-size:x-small; 
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
        <asp:Label ID="lblsch" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lbluid" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lbldiv" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblref" runat="server" Text="" CssClass="hidden"></asp:Label>
        <table style="width: 100%; color: White" bgcolor="#092443">
            <tr>
                <td style="background-color: #D2F1FC">
                    <asp:Label ID="lblhead" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"></asp:Label>
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
                    <td align="center" rowspan="2" valign="middle" width="11%" id="td_lbl0" runat="server">
                        <asp:Label ID="lbloc" runat="server" Text="LOCATION"></asp:Label>
                    </td>
                    <td align="center" rowspan="2" valign="middle" width="9%" id="td_lbl3" runat="server">
                        <asp:Label ID="lbl3" runat="server"></asp:Label>
                    </td>
                    <td align="center" rowspan="2" valign="middle" width="7%" id="td_lbl1" runat="server">
                        <asp:Label ID="lbl1" runat="server"></asp:Label>
                    </td>
                    <td align="center" rowspan="2" valign="middle" width="7%" id="td_lbl2" runat="server">
                        <asp:Label ID="lbl2" runat="server"></asp:Label>
                    </td>
                     <td align="center" rowspan="2" valign="middle" width="7%" id="td_lbl4" runat="server">
                        <asp:Label ID="lbl4" runat="server" Text=""></asp:Label>
                    </td>
                    <td align="center" rowspan="2" valign="middle" width="7%" id="td_lbnum" runat="server">
                        <asp:Label ID="lbnum" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                    <td align="center" valign="middle" width="5%">
                        BUILDING/ ZONE
                    </td>
                    <td align="center" valign="middle" width="5%">
                        CATEGORY
                    </td>
                    <td align="center" valign="middle" width="6%">
                        FLOOR LEVEL
                    </td>
                    <td align="center" valign="middle" width="4%">
                        SEQ.NO
                    </td>
                </tr>
                <tr bgcolor="#092443">
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnexpand" runat="server" Text="Exp.All" Width="94%" OnClick="btnexpand_Click"
                                    ForeColor="Red" Font-Size="X-Small" Style="cursor: pointer" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btncollapse" runat="server" Text="Coll.All" Width="94%" ForeColor="Red"
                                    Font-Size="X-Small" Style="cursor: pointer" OnClick="btncollapse_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        &nbsp;
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="drfed" runat="server" Width="50px" OnSelectedIndexChanged="drfed_SelectedIndexChanged"
                                    AutoPostBack="true" style="display:none">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
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
                    <td id="tddes" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="drloc" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="drloc_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td id="td0" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                            <ContentTemplate>
                                
                             <asp:DropDownList ID="drdes" runat="server" Width="100%"  style="display:none">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td id="td_1" runat="server">
                        &nbsp;</td>
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
        <div style="position:relative; height:75%;overflow-y:scroll;float:left;width:100%;">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            <asp:GridView ID="mymaster" runat="server" AutoGenerateColumns="False" 
                Width="100%" onrowdatabound="mymaster_RowDataBound" 
                Font-Names="Verdana" 
                    Font-Size="X-Small" ShowHeader="False" GridLines="None" >
            <Columns>
            <asp:TemplateField>
            <ItemTemplate>
            <table id="inner_table" width="100%">
            <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
            <td style="width:50px">
            
                <asp:Button ID="Button1" runat="server" Text="-" CommandArgument = "Button1"  OnClick = "Button1_Click" Width="30px" style="cursor:pointer" />
                </td>
            <td style="font-weight: bold;width:100%" align="left">
                <asp:Label ID="lbSys_Name" runat="server" Text='<%# Eval("Sys_Name") %>' Width="300px"></asp:Label>
                <asp:Label ID="lbSys_Id" runat="server" Text='<%# Eval("Sys_Id") %>' style="display:none"></asp:Label>
            </td>
            </tr>
            <tr>
            <td colspan="2">
                                                <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>--%>
                                                        <%--<div class="accordion" rel="1">
        <div class="accordion-title"><a href='#'>
         <table>
            <td><asp:CheckBox ID="chkrow1" runat="server" OnCheckedChanged="chkrow1_CheckedChanged" AutoPostBack="true" /></td>
            <td>
            <asp:Label ID="lbSys_Name" runat="server" Text='<%# Eval("Sys_Name") %>' Width="300px"></asp:Label>
                <asp:Label ID="lbSys_Id" runat="server" Text='<%# Eval("Sys_Id") %>' style="display:none"></asp:Label>
            </td>
            </table>
            </a>
        </div>--%>
                                                        <%--<div class="accordion-inner" style="display: none;">--%>
                                                        <asp:GridView ID="mydetails" runat="server" ShowHeader="false" AutoGenerateColumns="false" Width="100%" OnRowCommand="mydetails_RowCommand" OnRowDataBound="mydetails_RowDataBound" Font-Names="Verdana" 
                    Font-Size="X-Small">
                <Columns>
                <asp:ButtonField ButtonType="Button" Text="Update" CommandName="Get"
                        ItemStyle-Width="5%" >
                    <ItemStyle Width="5%"  />
                    </asp:ButtonField>
                
                <asp:BoundField HeaderText="Itm.No" ItemStyle-Width="5%" >
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField ="E_b_ref" HeaderText="Engg.Reff" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                 <asp:BoundField DataField="B_Z" HeaderText="Building/Zone" ItemStyle-Width="5%" >
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                    </asp:BoundField>  
                <asp:BoundField DataField="cat" HeaderText="Category" ItemStyle-Width="5%" >
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                    </asp:BoundField>
                 
                <asp:BoundField DataField="F_lvl" HeaderText="Floor Level" ItemStyle-Width="6%" >
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Seq_No" HeaderText="Seq.No" ItemStyle-Width="4%" >
                    <ItemStyle Width="4%" HorizontalAlign="Center" />
                    </asp:BoundField>
                   
                <asp:BoundField DataField="Loc" HeaderText="Location" ItemStyle-Width="11%" >
                    <ItemStyle Width="11%" HorizontalAlign="Center" />
                    </asp:BoundField>
                 <asp:BoundField DataField="F_from" HeaderText="Fed From" ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>    
                <asp:BoundField DataField="P_P_to" HeaderText="Provides Power To" 
                        ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Substation" HeaderText="Substation" 
                        ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Des" HeaderText="Substation" 
                        ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>  
                <asp:BoundField DataField="devices1" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="C_id" />
                <asp:BoundField DataField="Sys_Id" />
                <asp:BoundField DataField="Sys_Name" />
                </Columns>
                </asp:GridView>
                                                        <%-- </div>--%>
                                                    <%--</ContentTemplate>
                                                </asp:UpdatePanel>--%>
                                                <%--</div>--%>
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
        <div id="myprogress" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
        <asp:Panel ID="pnlPopup14" runat="server" Width="900" Height="360px" 
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
                            POINT TO POINT TEST</td>
                        <td class="tdstyle1" >N/A
                            <input id="chk_20ppt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20ppt','_20ppt')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_20ppt" runat="server" Width="75px"></asp:TextBox>
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
                    <tr>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle2">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                        <td width="200PX">
                            POINT TO POINT TESTED</td>
                        <td class="tdstyle1">
                            N/A
                            <input id="chk_20pptsd" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20pptsd','_20pptd')"/></td>
                        <td width="75PX">
                            <asp:TextBox ID="_20pptd" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="_20pptd" PopupButtonID="_20pptd" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            CALIBRATION/ FUNCTIONAL TESTED</td>
                        <td class="tdstyle3">N/A
                            <input id="chk_20cftsd" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20cftsd','_20cftsd')"/></td>
                        <td width="75PX">
                            <asp:TextBox ID="_20cftsd" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="_20cftsd" PopupButtonID="_20cftsd" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
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
                             <asp:CalendarExtender ID="CalendarExtender122" runat="server" 
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
                            GRAPHICS/HEAD END TEST</td>
                        <td class="tdstyle1" >N/A
                            <input id="chk_20ght" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20ght','_20ght')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_20ght" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle3" >
                            &nbsp;</td>
                        <td width="75PX">
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            SEQ. OF OPERATION TESTED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_20sotd" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20sotd','_20sotd')"/></td>
                        <td width="75PX">
                            <asp:TextBox ID="_20sotd" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_20filed6_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_20sotd" 
                                TargetControlID="_20sotd">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            GRAPHICS/ HEAD END TESTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_20ghtd" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20ghtd','_20ghtd')"/></td>
                        <td width="75PX">
                            <asp:TextBox ID="_20ghtd" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_20filed5_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_20ghtd" 
                                TargetControlID="_20ghtd">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle3">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
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
                            LOOP TUNING TESTED</td>
                        <td class="tdstyle1" >N/A
                            <input id="chk_20ltd" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20ltd','_20ltd')"/></td>
                        <td width="75PX">
                            <asp:TextBox ID="_20ltd" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_20filed4_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_20ltd" 
                                TargetControlID="_20ltd">
                            </asp:CalendarExtender>
                        </td>
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
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender14" runat="server" TargetControlID="btnDummy14"  PopupControlID="pnlPopup14" BackgroundCssClass="model-background"></asp:ModalPopupExtender> 
        
        
          <asp:Panel ID="pnlPopup20a" runat="server" Width="900" Height="350px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="_20apoints" runat="server" style="display:none"></asp:TextBox>
                    <asp:TextBox ID="_20adevices" runat="server" style="display:none"></asp:TextBox>
                    <asp:TextBox ID="_20asystem" runat="server" style="display:none"></asp:TextBox>
                    <asp:TextBox ID="TextBox1" runat="server" style="display:none"></asp:TextBox>
                <table style="font-size:x-small;width:900px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_20albl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            CONTINUITY/IR TESTED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_20acit" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20acit','_20acit')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_20acit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            POINT TO POINT TEST</td>
                        <td class="tdstyle1" >N/A
                            <input id="chk_20appt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20appt','_20appt')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_20appt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            CALIBRATION/FUNCTIONAL TEST</td>
                        <td class="tdstyle3">N/A
                            <input id="chk_20acft" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20acft','_20acft')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_20acft" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td width="200PX">
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle2">N/A
                            <input id="chk_20aaccept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20aaccept1','_20aaccept1')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_20aaccept1" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender3" runat="server" 
                        TargetControlID="_20aaccept1" PopupButtonID="_20aaccept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            TEST SHEETS FILED</td>
                        <td class="tdstyle1" >N/A
                           <input id="chk_20afiled1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20afiled1','_20afiled1')"/>
                           </td>
                        <td width="75PX">
                            <asp:TextBox ID="_20afiled1" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender4" runat="server" 
                        TargetControlID="_20afiled1" PopupButtonID="_20afiled1" ClearTime="true" 
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
                            <input id="chk_20asot" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20asot','_20asot')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_20asot" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            GRAPHICS/HEAD END TEST</td>
                        <td class="tdstyle1" >N/A
                            <input id="chk_20aght" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20aght','_20aght')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_20aght" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle3" >
                            &nbsp;</td>
                        <td width="75PX">
                        </td>
                    </tr>
                    <tr  style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td width="200PX">
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle2" >N/A
                            <input id="chk_20aaccept2" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20aaccept2','_20aaccept2')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_20aaccept2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" 
                        TargetControlID="_20aaccept2" PopupButtonID="_20aaccept2" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            TEST SHEETS FILED</td>
                        <td class="tdstyle1" >N/A
                            <input id="chk_20afiled2"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20afiled2','_20afiled2')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_20afiled2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender6" runat="server" 
                        TargetControlID="_20afiled2" PopupButtonID="_20afiled2" ClearTime="true" 
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
                        <input id="chk_20alt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20alt','_20alt')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_20alt" runat="server" Width="75px"></asp:TextBox>
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
                             <input id="chk_20aaccept3" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20aaccept3','_20aaccept3')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_20aaccept3" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender7" runat="server" 
                        TargetControlID="_20aaccept3" PopupButtonID="_20aaccept3" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle1" >N/A
                           
                            <input id="chk_20afiled3"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20afiled3','_20afiled3')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_20afiled3" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender8" runat="server" 
                        TargetControlID="_20afiled3" PopupButtonID="_20afiled3" ClearTime="true" 
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
                            <input id="chk_20aactby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_20aactby','_20aactby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_20aactby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle1" >
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_20acommts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle2" >N/A
                           <input id="chk_20aactdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_20aactdt','_20aactdt')" runat="server"/></td>
                        <td>
                            
                            <asp:TextBox ID="_20aactdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender9" runat="server" 
                        TargetControlID="_20aactdt" PopupButtonID="_20aactdt" ClearTime="true" 
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
                           <asp:Button ID="_20abtnupdate" runat="server" Text="Update" 
                                onclick="_20abtnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_20abtncancel" runat="server" Text="Cancel" 
                                onclick="_20abtncancel_Click" />
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
                
                <div id="Div20a" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload20a" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
            </div>
        </asp:Panel>
        
        <asp:Button ID="btnDummy20a" runat="server" Text="Button" style="display:none;"  />
        
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender20a" runat="server" TargetControlID="btnDummy20a"  PopupControlID="pnlPopup20a" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
        
         
        
        
    </div>
    </form>
    <script type="text/javascript">
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
</body>
</html>
