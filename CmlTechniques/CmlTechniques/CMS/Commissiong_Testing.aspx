 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Commissiong_Testing.aspx.cs" Inherits="CmlTechniques.CMS.Commissiong_Testing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>Untitled Page</title>  
    <script type="text/javascript">
    
      function pageLoad() {
      }
        function _checked(sender,target) {
            var _chk = document.getElementById(sender).checked;
            var _txt = document.getElementById(target);
            if (_chk == true)
            {
                _txt.value = "N/A";
                _txt.disabled=true;
              }
            else
            {
                _txt.value = "";
                _txt.disabled=false;
             }
        }
    function ValidateCableTestData(sender) 
    {
            var txtTestInput = document.getElementById(sender).checked;
            var txtTarget = document.getElementById(lblNoOfCables);
            if (txtTestInput > txtTarget)           
            alert("Cable test data should not exceed the number of cables.");
            
        }
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
     <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .tdstyle1
        {
            width: 90px;
             font-size:x-small; 
             color: #FF0000;
        }
        .tdstyle2
        {
            width: 40px;
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
    <div style="font-family: verdana; font-size: x-small;height:100%;position:fixed;width:100%">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <table style="width:100%;color:White" bgcolor="#092443">
        <tr>
        <td width="100px" >
            &nbsp;</td>
        <td width="100%" >
            <asp:Label ID="lblhead" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
            </td>
        </tr>
        </table>
        <div style="float:left;width:98.5%">
        <table style="font-family: Verdana;font-size:x-small;background-color:#9EB6CE;width:100%;" cellspacing="1" border="0">
       <tr  style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td align="center" rowspan="2" valign="middle"   width="6%">
                                &nbsp;</td>       
                            <td align="center" rowspan="2" valign="middle"   width="6%">
                                ITEM NO</td>       
                            <td align="center" rowspan="2" valign="middle"   width="10%">
                                ENG.REF</td>
                            <td align="center" colspan="4" valign="middle"  >
                                ASSET CODE</td>
                            <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbldes" runat="server" >
                                DESCRIPTION</td>
                            <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbl0" runat="server" >
                                <asp:Label ID="lbloc" runat="server" Text="LOCATION"></asp:Label>
                            </td>
                            <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbl3" runat="server" >
                                <asp:Label ID="lbl3" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbl1" runat="server" >
                                <asp:Label ID="lbl1" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbl2" runat="server" >
                                <asp:Label ID="lbl2" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbnum" runat="server" >
                                <asp:Label ID="lbnum" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td align="center" valign="middle"  width="7%"  >
                                BUILDING/ ZONE</td>
                            <td align="center" valign="middle" width="7%"  >
                                CATEGORY</td>
                            <td align="center" valign="middle" width="7%"  >
                                FLOOR LEVEL</td>
                            <td align="center" valign="middle" width="7%"  >
              SEQ.NO</td>
                        </tr>
        <tr bgcolor="#092443" >
            <td><asp:UpdatePanel ID="UpdatePanel5" runat="server">
                 <ContentTemplate>
                 <asp:Button ID="btnexpand" runat="server" Text="Exp.All" Width="100%"
                         onclick="btnexpand_Click" ForeColor="Red" Font-Size="X-Small" style="cursor:pointer" />
                 </ContentTemplate>
                 </asp:UpdatePanel></td>
            <td><asp:UpdatePanel ID="UpdatePanel31" runat="server">
                 <ContentTemplate>
                 <asp:Button ID="btncollapse" runat="server" Text="Coll.All" Width="100%" 
                         ForeColor="Red" Font-Size="X-Small" style="cursor:pointer" 
                         onclick="btncollapse_Click" />
                 </ContentTemplate>
                 </asp:UpdatePanel></td>
            <td>
                <asp:Label ID="lblprj" runat="server" Text="text" ForeColor="White" style="display:none"></asp:Label><asp:Label ID="lblsch" runat="server" Text="text" ForeColor="White" style="display:none"></asp:Label>
        <asp:Label ID="lbluid" runat="server" Text="" CssClass="hidden"></asp:Label> <asp:Label ID="lbldiv" runat="server" Text="" CssClass="hidden"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drbuilding" runat="server" Width="100%" OnSelectedIndexChanged="drbuilding_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                 
            </td>
            <td>
           <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drcategory" runat="server" Width="100%" OnSelectedIndexChanged="drcategory_SelectedIndexChanged" AutoPostBack="true" >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
               </td>
            <td>
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drflevel" runat="server" Width="100%" OnSelectedIndexChanged="drflevel_SelectedIndexChanged" AutoPostBack="true"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td>
                &nbsp;</td>
            <td id="td_txtdescr" runat="server">
                                &nbsp;</td>
            <td id="td0" runat="server">
            <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drloc" runat="server" Width="100%" AutoPostBack="true" 
                        onselectedindexchanged="drloc_SelectedIndexChanged"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
            <td id="td_1" runat="server">
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drfed" runat="server" Width="100%" OnSelectedIndexChanged="drfed_SelectedIndexChanged" AutoPostBack="true"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
            <td id="td_0" runat="server">
                &nbsp;</td>
            <td id="td_2" runat="server">
                &nbsp;</td>
            <td id="td_3" runat="server">
                &nbsp;</td>
        </tr>
                        </table>
        </div>
        <div style="overflow-y:scroll;float:left;position: absolute;top:90px;bottom: 0;left: 0;right: 0;">
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
               <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>--%>
                <asp:GridView ID="mydetails" runat="server" ShowHeader="false" AutoGenerateColumns="false" Width="100%" OnRowCommand="mydetails_RowCommand" OnRowDataBound="mydetails_RowDataBound" Font-Names="Verdana" 
                    Font-Size="X-Small">
                <Columns>
                <asp:ButtonField ButtonType="Button" Text="Update" CommandName="Get"
                        ItemStyle-Width="6%" >
                    <ItemStyle Width="6%"  />
                    </asp:ButtonField>                
                <asp:BoundField HeaderText="Itm.No" ItemStyle-Width="6%" >
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField ="E_b_ref" HeaderText="Engg.Reff" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="B_Z" HeaderText="Building/Zone" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>  
                <asp:BoundField DataField="cat" HeaderText="Category" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>                 
                <asp:BoundField DataField="F_lvl" HeaderText="Floor Level" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Seq_No" HeaderText="Seq.No" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Des" HeaderText="Substation" 
                        ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>    
                <asp:BoundField DataField="Loc" HeaderText="Location" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="F_from" HeaderText="Fed From" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>    
                <asp:BoundField DataField="P_P_to" HeaderText="Provides Power To" 
                        ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Substation" HeaderText="Substation" 
                        ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="devices1" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="C_id" />
                <asp:BoundField DataField="Sys_Id" />
                <asp:BoundField DataField="Sys_Name" />
                <asp:BoundField DataField="cat_type" />
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
        <div id="myprogress" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
       
        <asp:Panel ID="pnlPopup1" runat="server" Width="825px" Height="400px" style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_2lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                <tr style="background-color:#83C8EE">
                <td width="200px">
                    PLANNED POWER ON</td>
                    <td class="tdstyle1">N/A
                       <input id="chk_2pwron" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_2pwron','_2pwron')" runat="server"/></td>
                <td width="75px">
                <asp:TextBox ID="_2pwron" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="_2pwron" PopupButtonID="_2pwron" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                </td>
                    <td width="200px">
                        &nbsp;</td>
                    <td class="tdstyle1">
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
                
                    <tr id="tr1" runat="server">
                        <td >
                            TORQUE TEST</td>
                        <td class="tdstyle1">N/A
                        <input id="chk_2tor" type="checkbox" style="vertical-align:middle" runat="server" value="N/A" onclick="_checked('chk_2tor','_2tor')"/>
                           </td>
                        <td >
                            <asp:TextBox ID="_2tor" runat="server" Width="75px" 
                                ></asp:TextBox>
                            <asp:CalendarExtender ID="date2_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2tor" 
                                TargetControlID="_2tor">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            IR TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_2ir" type="checkbox" style="vertical-align:middle"  runat="server" value="n/a" onclick="_checked('chk_2ir','_2ir')"/>
                            </td>
                        <td >
                            <asp:TextBox ID="_2ir" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_2ir_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2ir" 
                                TargetControlID="_2ir">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            HI POT TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_2hi" type="checkbox" style="vertical-align:middle"  runat="server"  onclick="_checked('chk_2hi','_2hi')"/>
                            </td>
                        <td >
                            <asp:TextBox ID="_2hi" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="date4_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2hi" 
                                TargetControlID="_2hi">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr id="tr2" runat="server">
                        <td >
                            VT TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_2vt" type="checkbox" style="vertical-align:middle"  runat="server"  onclick="_checked('chk_2vt','_2vt')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_2vt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="date5_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2vt" 
                                TargetControlID="_2vt">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            CT TEST</td>
                        <td class="tdstyle1">N/A
                             <input id="chk_2ct" type="checkbox" style="vertical-align:middle"  runat="server"  onclick="_checked('chk_2ct','_2ct')"/>
                            </td>
                        <td >
                            <asp:TextBox ID="_2ct" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="date6_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2ct" 
                                TargetControlID="_2ct">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            PRIMARY INJECTION TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_2pi" type="checkbox" style="vertical-align:middle"  runat="server"  onclick="_checked('chk_2pi','_2pi')"/>
                            </td>
                        <td >
                            <asp:TextBox ID="_2pi" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="date7_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2pi" 
                                TargetControlID="_2pi">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr id="tr3" runat="server">
                        <td >
                            SECONDARY INJECTION TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_2si" type="checkbox" style="vertical-align:middle"  runat="server"  onclick="_checked('chk_2si','_2si')"/>
                            </td>
                        <td >
                            <asp:TextBox ID="_2si" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="date15_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2si" 
                                TargetControlID="_2si">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            DUCTOR TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_2cr" type="checkbox" style="vertical-align:middle"  runat="server"  onclick="_checked('chk_2cr','_2cr')"/>
                            </td>
                        <td >
                            <asp:TextBox ID="_2cr" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="date16_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2cr" 
                                TargetControlID="_2cr">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            FUNCTIONAL TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_2fn" type="checkbox" style="vertical-align:middle"  runat="server"  onclick="_checked('chk_2fn','_2fn')"/>
                            </td>
                        <td >
                            <asp:TextBox ID="_2fn" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="date14_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2fn" 
                                TargetControlID="_2fn">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr id="tr4" runat="server">
                        <td >
                            PROTECTIVE RELAY FINAL TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_2pr" type="checkbox" style="vertical-align:middle"  runat="server"  onclick="_checked('chk_2pr','_2pr')"/>                           </td>
                        <td >
                            <asp:TextBox ID="_2pr" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="date18_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2pr" 
                                TargetControlID="_2pr">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_2accept1" type="checkbox" style="vertical-align:middle"  runat="server"  onclick="_checked('chk_2accept1','_2accept1')"/>
                            </td>
                        <td >
                            <asp:TextBox ID="_2accept1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="test12_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2accept1" 
                                TargetControlID="_2accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_2filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_2filed1','_2filed1')"/>
                            </td>
                        <td >
                            <asp:TextBox ID="_2filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtendertxt" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_2filed1" TargetControlID="_2filed1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="9" align="center">
                            22/11KV TEST</td>
                    </tr>
                    <tr id="tr7" runat="server">
                        <td >
                            CABLE IR AND HI POT</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_2cable" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_2cable','_2cable')" runat="server"/></td>
                        <td >
                            <asp:TextBox ID="_2cable" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender8" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_2cable" TargetControlID="_2cable">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_2accept2" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_2accept2','_2accept2')" runat="server"/></td>
                        <td >
                            <asp:TextBox ID="_2accept2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="test13_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2accept2" 
                                TargetControlID="_2accept2">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_2filed2" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_2filed2','_2filed2')" runat="server"/></td>
                        <td >
                            <asp:TextBox ID="_2filed2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="actdate0_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2filed2" 
                                TargetControlID="_2filed2">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle1">N/A
                          <input id="chk_2actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_2actby','_2actby')" runat="server"/></td>
                        <td colspan="2">
                            <asp:TextBox ID="_2actby" runat="server" Width="250px"></asp:TextBox>
                        </td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            <asp:TextBox ID="_2commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle1">N/A
                          <input id="chk_2actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_2actdt','_2actdt')" runat="server"/></td>
                        <td>
                            <asp:TextBox ID="_2actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="date22_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2actdt" 
                                TargetControlID="_2actdt">
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
                            <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                            <ContentTemplate>
                            <asp:Button ID="_2btnupdate" runat="server" 
                               Text="Update" onclick="_2btnupdate_Click" />
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            
                            
                        </td>
                        <td align="left">
                            <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                            <ContentTemplate>
                            <asp:Button ID="_2btncancel" runat="server"
                                Text="Cancel" onclick="_2btncancel_Click" />
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            
                        </td>
                        <td align="left" class="tdstyle1">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                        </td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                </table>
             </ContentTemplate>
                </asp:UpdatePanel>
                <div id="myprogress1" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload1" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy1" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender1" runat="server" TargetControlID="btnDummy1"  PopupControlID="pnlPopup1" BackgroundCssClass="modal"></asp:ModalPopupExtender>
               
        <asp:Panel ID="pnlPopup2" runat="server" Width="825px" Height="340px" style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_3lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                <tr style="background-color:#83C8EE">
                <td width="200px">
                    PLANNED POWER ON</td>
                    <td class="tdstyle1">N/A
                         <input id="chk_3pwron" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_3pwron','_3pwron')" runat="server" /></td>
                <td width="75px">
                <asp:TextBox ID="_3pwron" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="_3pwron" PopupButtonID="_3pwron" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                </td>
                    <td width="200px">
                        &nbsp;</td>
                    <td class="tdstyle1">
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
                            TRANSFORMER TESTING</td>
                    </tr>
                
                    <tr >
                        <td >
                            IR TEST
                       
                        
                        </td>
                        <td class="tdstyle1">N/A
                            <input id="chk_3ir" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_3ir','_3ir')" runat="server" /></td>
                        <td>
                            <asp:TextBox ID="_3ir" runat="server" Width="75px" 
                                ></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3ir" 
                                TargetControlID="_3ir">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            RATIO TEST
                        
                             </td>
                        <td class="tdstyle1">N/A
                            <input id="chk_3rt" type="checkbox" style="vertical-align:middle"  onclick="_checked('chk_3rt','_3rt')" runat="server" /></td>
                        <td>

                            <asp:TextBox ID="_3rt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3rt" 
                                TargetControlID="_3rt">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            WINDING RESISTANCE TEST
                       
                        
                          </td>
                        <td class="tdstyle1">N/A
                            <input id="chk_3wr" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_3wr','_3wr')" runat="server"/></td>
                        <td>

                            <asp:TextBox ID="_3wr" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3wr" 
                                TargetControlID="_3wr">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr >
                        <td >
                            VECTOR GROUP TEST
                        
                       
                          </td>
                        <td class="tdstyle1">N/A
                             <input id="chk_3vg" type="checkbox" style="vertical-align:middle"  onclick="_checked('chk_3vg','_3vg')" runat="server" /></td>
                        <td>

                            <asp:TextBox ID="_3vg" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender6" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3vg" 
                                TargetControlID="_3vg">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEMP. RELAY FUNCTIONAL TEST
                        
                         
                            </td>
                        <td class="tdstyle1">N/A
                            <input id="chk_3trf" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_3trf','_3trf')" runat="server"/></td>
                        <td>

                            <asp:TextBox ID="_3trf" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender7" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3trf" 
                                TargetControlID="_3trf">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td >
                        
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED
                        
                         
                          </td>
                        <td class="tdstyle1">N/A
                            <input id="chk_3accept1" type="checkbox" style="vertical-align:middle"    onclick="_checked('chk_3accept1','_3accept1')" runat="server"/></td>
                        <td>

                            <asp:TextBox ID="_3accept1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender13" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3accept1" 
                                TargetControlID="_3accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED
                    
                       
                          </td>
                        <td class="tdstyle1"  valign="middle" >N/A
                            <input id="chk_3filed1" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_3filed1','_3filed1')" runat="server"/></td>
                        <td>

                            <asp:TextBox ID="_3filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender14" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_3filed1" TargetControlID="_3filed1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="9" align="center">
                            CABLE TEST</td>
                    </tr>
                    <tr >
                        <td >
                            CABLE IR AND HI POT</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_3cable" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_3cable','_3cable')" runat="server"/></td>
                        <td >
                            <asp:TextBox ID="_3cable" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender11" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_3cable" TargetControlID="_3cable">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_3accept2" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_3accept2','_3accept2')" runat="server"/></td>
                        <td >
                            <asp:TextBox ID="_3accept2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender15" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3accept2" 
                                TargetControlID="_3accept2">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_3filed2" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_3filed2','_3filed2')" runat="server"/></td>
                                    <td>
                                        <asp:TextBox ID="_3filed2" runat="server" Width="75px"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender16" runat="server" ClearTime="true" 
                                            Format="dd/MM/yyyy" PopupButtonID="_3filed2" TargetControlID="_3filed2">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="tdstyle1">
                                        &nbsp;&nbsp;</td>
                        <td>
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle1">N/A
                         <input id="chk_3actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_3actby','_3actby')" runat="server"/></td>

                        <td colspan="2">
                            <asp:TextBox ID="_3actby" runat="server" Width="250px"></asp:TextBox>
                        </td>
                        <td class="tdstyle1">
                          </td>

                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            <asp:TextBox ID="_3commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle1">N/A
                          <input id="chk_3actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_3actdt','_3actdt')" runat="server"/></td>

                        <td>
                            <asp:TextBox ID="_3actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender17" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3actdt" 
                                TargetControlID="_3actdt">
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
                            <asp:Button ID="_3btnupdate" runat="server" 
                                Text="Update" onclick="_3btnupdate_Click" />
                        </td>
                        <td align="left">
                            <asp:Button ID="_3btncancel" runat="server" 
                                Text="Cancel" onclick="_3btncancel_Click" />
                        </td>
                        <td align="left" class="tdstyle1">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                        </td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                </table>
             </ContentTemplate>
                </asp:UpdatePanel>
                 <div id="Div1" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress3" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload2" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy2" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender2" runat="server" TargetControlID="btnDummy2"  PopupControlID="pnlPopup2" BackgroundCssClass="modal"></asp:ModalPopupExtender>
        
         <asp:Panel ID="pnlPopup3" runat="server" Width="825px" Height="400px" style="padding:15px;display:none" BackColor="White"  >
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
                            EARTH PIT TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_6ep" type="checkbox" style="vertical-align:middle" runat="server" value="N/A" onclick="_checked('chk_6ep','_6ep')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_6ep" runat="server" Width="75px" 
                                ></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender10" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6ep" 
                                TargetControlID="_6ep">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td width="75PX" >
                           
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
                           (EARTHING)BONDING OF ALL EQUIPMENT COMPETE</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_6be" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_6be','_6be')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_6be" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender28" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6be" 
                                TargetControlID="_6be">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
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
                            LIGHTNING PROTECTION PIT TEST</td>
                        <td class="tdstyle1">N/A
                             <input id="chk_6lp" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_6lp','_6lp')"/>
                            </td>
                        <td >
                            <asp:TextBox ID="_6lp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender31" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_6lp" TargetControlID="_6lp">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
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
                            BONDING OF ROOF EQUIP. AND DOWN CONDU. TEST COMPLETE</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_6br" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_6br','_6br')"/>
                           </td>
                        <td>
                            <asp:TextBox ID="_6br" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender32" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6br" 
                                TargetControlID="_6br">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
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
        
        <asp:Panel ID="pnlPopup4" runat="server" Width="825px" Height="367px" style="padding:15px;display:none" BackColor="White"  >
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
                    PLANNED POWER ON</td>
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
                     <td class="tdstyle1">
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
                            TORQUE TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_5tor" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_5tor','_5tor')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_5tor" runat="server" Width="75px" 
                                ></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender9" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_5tor" 
                                TargetControlID="_5tor">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            IR TEST</td>
                        <td class="tdstyle1">N/A
                        <input id="chk_5ir" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_5ir','_5ir')"/>
                            </td>
                        <td width="75PX" >
                            <asp:CalendarExtender ID="CalendarExtender18" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_5ir" 
                                TargetControlID="_5ir">
                            </asp:CalendarExtender>
                            <asp:TextBox ID="_5ir" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            HI POT TEST</td>
                        <td class="tdstyle1">N/A
                        <input id="chk_5pr" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_5pr','_5pr')"/>
                            </td>
                        <td width="75PX" >
                            <asp:CalendarExtender ID="CalendarExtender19" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_5pr" 
                                TargetControlID="_5pr">
                            </asp:CalendarExtender>
                            <asp:TextBox ID="_5pr" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr >
                        <td>
                            SECONDARY INJECTION TEST</td>
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
                            CONTACT RESISTANCE</td>
                        <td class="tdstyle1">N/A
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
                            FUNCTIONAL TEST</td>
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
                            CONSULTANT ACCEPTED</td>
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
                            TEST SHEETS FILED</td>
                        <td class="tdstyle1">N/A
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
                            TOTAL NO.OF CIRCUITS</td>
                        <td class="tdstyle1">
                          
                        <td >
                            <asp:TextBox ID="_5total" runat="server" Width="75px" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td >
                            TOTAL COLD TESTED</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_5tc" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_5tc','_5tc')" runat="server"/></td>
                        <td >
                            <asp:TextBox ID="_5tc" runat="server" Width="75px" Text="0"></asp:TextBox>
                            
                        </td>
                        <td >
                            COLD TEST COMPLETED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_5cc" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_5cc','_5cc')" runat="server"/></td>
                        <td >
                            <asp:TextBox ID="_5cc" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender38" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_5cc" TargetControlID="_5cc">
                            </asp:CalendarExtender>
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
                            TOTAL LIVE TESTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_5tl" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_5tl','_5tl')" runat="server"/></td>
                        <td>
                            <asp:TextBox ID="_5tl" runat="server" Width="75px" Text="0"></asp:TextBox>
                        </td>
                        <td>
                            LIVE TEST COMPLETED</td>
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
                            CONSULTANT ACCEPTED</td>
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
                            TEST SHEETS FILED</td>
                        <td class="tdstyle1">N/A
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
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_5actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_5actby','_5actby')" runat="server"/></td>
                        <td colspan="2">
                            <asp:TextBox ID="_5actby" runat="server" Width="250px"></asp:TextBox>
                        </td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            <asp:TextBox ID="_5commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
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
                        <td class="tdstyle1">
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
                        <td align="left" class="tdstyle1">
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
         
         <asp:Panel ID="pnlPopup5" runat="server" Width="825px" Height="355px" style="padding:15px;display:none" BackColor="White"  >
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
                            PRE-COM </td>
                        <td class="tdstyle1">N/A
                           <input id="chk_4pc" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_4pc','_4pc')"/>
                           </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_4pc" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender42" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4pc" 
                                TargetControlID="_4pc">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            ALARM &amp; SHUTDOWN TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_4as" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_4as','_4as')"/>
                            </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_4as" runat="server" Width="75px" style="margin-left: 0px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender43" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4as" 
                                TargetControlID="_4as">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            LOAD BANK TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_4lb" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_4lb','_4lb')"/>
                            </td>
                        <td width="75PX" >
                           
                            <asp:TextBox ID="_4lb" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender44" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4lb" 
                                TargetControlID="_4lb">
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">
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
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td >
                           
                        </td>
                        <td >
                            &nbsp;</td>
                        <td class="tdstyle1">
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">
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
                            SITE OPERATION &amp; LOAD TEST</td>
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
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle1">
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">
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
                        <td class="tdstyle1">
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
                           <asp:Button ID="_4btnupdate" runat="server" Text="Update" 
                                onclick="_4btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_4btncancel" runat="server" Text="Cancel" 
                                onclick="_4btncancel_Click" />
                        </td>
                        <td align="left" class="tdstyle1">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                           
                        </td>
                        <td class="tdstyle1">
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
                        <td class="tdstyle1">N/A
                           <input id="chk_7add" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_7add','_7add')"/>
                           </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_7add" runat="server" Width="75px" Text="0"></asp:TextBox>
                           <%-- <asp:CalendarExtender ID="CalendarExtender55" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7add" 
                                TargetControlID="_7add">
                            </asp:CalendarExtender>--%>
                        </td>
                        <td width="200PX" >
                            FAULT TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_7ft" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_7ft','_7ft')"/>
                            </td>
                        <td width="75PX" >
                           
                            <asp:TextBox ID="_7ft" runat="server" Width="75px" Text="0"></asp:TextBox>
                            <%--<asp:CalendarExtender ID="CalendarExtender56" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7ft" 
                                TargetControlID="_7ft">
                            </asp:CalendarExtender>--%>
                        </td>
                    </tr>
                    <tr >
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
                        <td class="tdstyle1">N/A
                            <input id="chk_7ll" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_7ll','_7ll')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_7ll" runat="server" Width="75px" Text="0"></asp:TextBox>
                           <%--<asp:CalendarExtender ID="CalendarExtender58" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7ll" 
                                TargetControlID="_7ll">
                            </asp:CalendarExtender>--%>
                        </td>
                        <td >
                            DURATION TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_7du" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_7du','_7du')"/>
                            </td>
                        <td >
                            
                            <asp:TextBox ID="_7du" runat="server" Width="75px" Text="0"></asp:TextBox>
                            <%--<asp:CalendarExtender ID="CalendarExtender59" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7du" 
                                TargetControlID="_7du">
                            </asp:CalendarExtender>--%>
                        </td>
                    </tr>
                    <tr >
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
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="_7noof" runat="server" Width="75px" style="display:none"></asp:TextBox>
                            <asp:TextBox ID="_7nocir" runat="server" Width="75px" style="display:none"></asp:TextBox>
                           
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">
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
                        <td class="tdstyle1">
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
                           <asp:Button ID="_7btnupdate" runat="server" Text="Update" 
                                onclick="_7btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_7btncancel" runat="server" Text="Cancel" 
                                onclick="_7btncancel_Click" />
                        </td>
                        <td align="left" class="tdstyle1">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                           
                        </td>
                        <td class="tdstyle1">
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
         
         <asp:Panel ID="pnlPopup7" runat="server" Width="900px" Height="350px" 
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
                        <asp:Label ID="lblpft" runat="server" Text="PFT COMPLETION SIGN OFF CML"></asp:Label>
                     </td>
                     <td class="tdstyle5">
                    <td width="75px">
                        <asp:TextBox ID="_8pft" runat="server" Width="75px"></asp:TextBox>
                        <asp:CalendarExtender ID="_8pft_CalendarExtender" runat="server" 
                            ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8pft" 
                            TargetControlID="_8pft">
                        </asp:CalendarExtender>
                     </td>
                <td width="200px">
                </td>
                     <td class="tdstyle6">
                         &nbsp;</td>
                <td width="75px"></td>
                </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="9"  align="center" class="tdstyle1">
                            MECHANICAL SYSTEMS</td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            <asp:Label ID="lbltest8" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="tdstyle8">N/A
                            <input id="chk_8pc1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_8pc1','_8pc1')"/>
                            </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_8pc1" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender54" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8pc1" 
                                TargetControlID="_8pc1">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            COMM</td>
                        <td class="tdstyle5">N/A
                            <input id="chk_8co1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_8co1','_8co1')"/>
                            </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_8co1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender55" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8co1" 
                                TargetControlID="_8co1">
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
                         DESIGN VOLUME (l/s)</td>
                        <td class="tdstyle8">N/A
                            <input id="chk_8dv" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_8dv','_8dv')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_8dv" runat="server" Width="75px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td width="200PX">
                         OBTAINED VOLUME (l/s)</td>
                        <td class="tdstyle5">N/A
                            <input id="chk_8ov" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_8ov','_8ov')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_8ov" runat="server" Width="75px"></asp:TextBox>
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
                            <asp:Label ID="lblduty8" runat="server" Text=""></asp:Label>
                        </td>
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
                    <tr id="tradd2" runat="server">
                        <td>
                         FPT SIGN OFF CML</td>
                        <td class="tdstyle8">N/A
                          <input id="chk_8fpt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_8fpt','_8fpt')" runat="server"/></td>
                        <td>
                            <asp:TextBox ID="_8fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_8fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8fpt" 
                                TargetControlID="_8fpt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                         ACCEPTANCE RECOMMENDATION MADE</td>
                        <td class="tdstyle5">N/A
                          <input id="chk_8arm" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_8arm','_8arm')" runat="server"/></td>
                        <td>
                            <asp:TextBox ID="_8arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_8arm_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8arm" 
                                TargetControlID="_8arm">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle6">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
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
                        <td class="tdstyle1">
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
        
         <asp:Panel ID="pnlPopup8" runat="server" Width="825px" Height="280px" 
                style="padding:15px;display:none" BackColor="White"  >
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
                        &nbsp;</td>
                     <td>
                         &nbsp;</td>
                    <td width="75px">
                        &nbsp;</td>
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">N/A
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
                        <td>
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
         
         <asp:Panel ID="pnlPopup9" runat="server" Width="825px" Height="330px" 
                style="padding:15px;display:none;" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0">
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_9lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td colspan="2"  >PLANNED COMPLETION DATE</td>
                        <td >
                            <asp:TextBox ID="_9pcd" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_9pcd_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_9pcd" 
                                TargetControlID="_9pcd">
                            </asp:CalendarExtender>
                        </td
                        <td ></td>
                        <td></td>
                        <td></td>
                        <td ></td>
                        <td></td>
                        <td></td>
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">N/A
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
                            <asp:Label ID="lblicom" runat="server" Text="INSTALLATION COMPLETION SIGN OFF"></asp:Label>
                        </td>
                        <td class="tdstyle1">N/A
                            <input id="chk_9icom" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_9icom','_9icom')" runat="server"/></td>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_9icom" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_9sro0_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_9icom" 
                                TargetControlID="_9icom">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle1">
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">
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
                        <td class="tdstyle1">
                             <asp:HiddenField ID="hdnType" runat="server" />
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
                           <asp:Button ID="_9btnupdate" runat="server" Text="Update" 
                                onclick="_9btnupdate_Click"  />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_9btncancel" runat="server" Text="Cancel" 
                                onclick="_9btncancel_Click" />
                        </td>
                        <td align="left" class="tdstyle1">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                           
                        </td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
                 <div id="Div8" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress10" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload9" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy9" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender9" runat="server" TargetControlID="btnDummy9"  PopupControlID="pnlPopup9" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
        
        <asp:Panel ID="pnlPopup10" runat="server" Width="825px" Height="267px" 
                style="padding:15px;display:none" BackColor="White"  >
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
                     <td class="tdstyle1">
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
                            COMMISSIONING &amp; ACCEPTANCE</td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            PRE-COMM</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_17pc1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_17pc1','_17pc1')"/>
                            </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_17pc1" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender83" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17pc1" 
                                TargetControlID="_17pc1">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            COMM</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_17co1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_17co1','_17co1')"/>
                           </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_17co1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender89" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17co1" 
                                TargetControlID="_17co1">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            WITNESSED DATE</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_17wd1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_17wd1','_17wd1')"/>
                            </td>
                        <td width="75PX" >
                           
                            <asp:TextBox ID="_17wd1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender90" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17wd1" 
                                TargetControlID="_17wd1">
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">
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
                           <asp:Button ID="_17btnupdate" runat="server" Text="Update" 
                                onclick="_17btnupdate_Click"/>
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_17btncancel" runat="server" Text="Cancel" 
                                onclick="_17btncancel_Click"  />
                        </td>
                        <td align="left" class="tdstyle1">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                           
                        </td>
                        <td class="tdstyle1">
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
        
         <asp:Panel ID="pnlPopup11" runat="server" Width="825px" Height="185px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_18lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            QUANTITY TESTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_18qt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_18qt','_18qt')"/>
                            </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_18qt" runat="server" Width="75px" >
                               </asp:TextBox>
                        </td>
                        <td width="200PX" >
                            WITNESSED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_18wt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_18wt','_18wt')"/>
                            </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_18wt" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender98" runat="server" 
                        TargetControlID="_18wt" PopupButtonID="_18wt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            <asp:Label ID="_18lblicom" runat="server" Text="INSTALLATION SIGN OFF"></asp:Label>
                        </td>
                        <td class="tdstyle1">N/A
                            <input id="chk_18icom" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_18icom','_18icom')"/>
                            </td>
                        <td width="75PX" >
                           
                            <asp:TextBox ID="_18noof" runat="server" Width="75px" style="display:none"></asp:TextBox>
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">
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
                           <asp:Button ID="_18btnupdate" runat="server" Text="Update" 
                                onclick="_18btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_18btncancel" runat="server" Text="Cancel" 
                                onclick="_18btncancel_Click" />
                        </td>
                        <td align="left" class="tdstyle1">
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
         
         <asp:Panel ID="pnlPopup12" runat="server" Width="825px" Height="215px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_19lbl" runat="server" ForeColor="White"></asp:Label>
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle1">
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">
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
                        <td class="tdstyle1">
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
                           <asp:Button ID="_19btnupdate" runat="server" Text="Update" 
                                onclick="_19btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_19btncancel" runat="server" Text="Cancel" 
                                onclick="_19btncancel_Click" />
                        </td>
                        <td align="left" class="tdstyle1">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                           
                        </td>
                        <td class="tdstyle1">
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
                            CABLE CONTINUITY/IR TESTED1</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_10ccit" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_10ccit','_10ccit')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_10ccit" runat="server" Width="75px"></asp:TextBox>
                              <asp:CalendarExtender ID="CalendarExtender_10ccit" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_10ccit" 
                                TargetControlID="_10ccit">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            NO.OF DEVICES TESTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_10ndt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_10ndt','_10ndt')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_10ndt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            DEVICE TEST COMPLETE</td>
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle1">
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">
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
                        <td class="tdstyle1">
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
                           <asp:Button ID="_10btnupdate" runat="server" Text="Update" 
                                onclick="_10btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_10btncancel" runat="server" Text="Cancel" 
                                onclick="_10btncancel_Click" />
                        </td>
                        <td align="left" class="tdstyle1">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                           
                        </td>
                        <td class="tdstyle1">
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
        
         <asp:Panel ID="pnlPopup14" runat="server" Width="900" Height="350px" 
                style="padding:15px;display:none" BackColor="White"  >
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
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1">N/A
                            <input id="chk_20cft" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_20cft','_20cft')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_20cft" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td width="200PX">
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
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
                        <td class="tdstyle1" >
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            SEQ. OF OPERATION TEST</td>
                        <td class="tdstyle1" >N/A
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
                        <td class="tdstyle1" >
                            &nbsp;</td>
                        <td width="75PX">
                        </td>
                    </tr>
                    <tr  style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td width="200PX">
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1" >N/A
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
                        <td class="tdstyle1" >
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            LOOP TUNING</td>
                        <td class="tdstyle1" >N/A
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
                        <td class="tdstyle1" >
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1" >N/A
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
                        <td class="tdstyle1" >
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle1" >N/A
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
                        <td class="tdstyle1" >N/A
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
                        <td class="tdstyle1" >
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
                        <td class="tdstyle1" >
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
         
         <asp:Panel ID="pnlPopup15" runat="server" Width="825px" Height="230px" 
                style="padding:15px;display:none" BackColor="White"  >
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
                                CONTINUITY/ IR TEST</td>
                            <td class="tdstyle1">N/A<input ID="chk_13cit" runat="server" onclick="_checked('chk_13cit','_13cit')" 
                                    style="vertical-align:middle" type="checkbox" /></td>
                            <td width="75PX">
                                <asp:TextBox ID="_13cit" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                CCTV VIEW LOCALLY</td>
                            <td class="tdstyle1">N/A<input ID="chk_13cvl" onclick="_checked('chk_13cvl','_13cvl')" 
                                    type="checkbox" style="vertical-align:middle; width: 20px;" 
                                    runat="server" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_13cvl" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                CCTV VIEW FROM HEAD END</td>
                            <td class="tdstyle1">N/A<input ID="chk_13cvh" onclick="_checked('chk_13cvh','_13cvh')" 
                                    type="checkbox" style="vertical-align:middle" runat="server" /></td>
                            <td width="75PX">
                                <asp:TextBox ID="_13cvh" runat="server" Width="75px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="200PX">
                                ADDRESSING/SOFTWARE TEST</td>
                            <td class="tdstyle1">
                                N/A
                                <input ID="chk_13ast" runat="server" onclick="_checked('chk_13ast','_13ast')" 
                                    style="vertical-align:middle" type="checkbox" />
                            </td>
                            <td width="75PX">
                                <asp:TextBox ID="_13ast" runat="server" Width="75px"></asp:TextBox>
                            </td>
                            <td width="200PX">
                                RECORDING/BACK-UP STORAGE TEST</td>
                            <td class="tdstyle1">
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
                            <td class="tdstyle1">
                                &nbsp;</td>
                            <td width="75PX">
                            </td>
                    </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td>
                                CONSULTANT ACCEPTED</td>
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
                                TEST SHEETS FILED</td>
                            <td class="tdstyle1">N/A
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
                            <td class="tdstyle1">
                                &nbsp;</td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color:#83C8EE">
                            <td>
                                ACTION BY&nbsp;</td>
                            <td class="tdstyle1">N/A
                               <input id="chk_13actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_13actby','_13actby')" runat="server"/></td>
                            <td colspan="2">
                                <asp:TextBox ID="_13actby" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="tdstyle1">
                                &nbsp;</td>
                            <td>
                                COMMENTS</td>
                            <td colspan="3" rowspan="2">
                                <asp:TextBox ID="_13commts" runat="server" Height="50px" TextMode="MultiLine" 
                                    Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color:#83C8EE">
                            <td>
                                ACTION DATE</td>
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
                                <asp:Button ID="_13btnupdate" runat="server" onclick="_13btnupdate_Click" 
                                    Text="Update" />
                            </td>
                            <td align="left">
                                <asp:Button ID="_13btncancel" runat="server" onclick="_13btncancel_Click" 
                                    Text="Cancel" />
                            </td>
                            <td align="left" class="tdstyle1">
                                &nbsp;</td>
                            <td align="right">
                                &nbsp;</td>
                            <td>
                            </td>
                            <td class="tdstyle1">
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
         
         <asp:Panel ID="pnlPopup16" runat="server" Width="825px" Height="245px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_22lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            CONTINUITY/IR TEST</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_22cit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            ADDRESSING/PROGRAMMING TEST</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_22apt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            FAULT &amp; ALARM TEST</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_22fat" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            ACCESS CARD SWIPE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_22acs" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            POWER FAILURE TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_22pft" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            <asp:TextBox ID="_22noof" runat="server" Width="75px" style="display:none"></asp:TextBox>
                            INTERFACE TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_22it" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            PC HEADEND/GRAPHIC TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_22phgt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td >
                           
                            <asp:TextBox ID="_22accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender120" runat="server" 
                        TargetControlID="_22accept1" PopupButtonID="_22accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_22filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender123" runat="server" 
                        TargetControlID="_22filed1" PopupButtonID="_22filed1" ClearTime="true" 
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
                        <td colspan="2">
                            
                            <asp:TextBox ID="_22actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_22commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_22actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender124" runat="server" 
                        TargetControlID="_22actdt" PopupButtonID="_22actdt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_22btnupdate" runat="server" Text="Update" 
                                onclick="_22btnupdate_Click"  />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_22btncancel" runat="server" Text="Cancel" 
                                onclick="_22btncancel_Click"   />
                        </td>
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
        
        <asp:Panel ID="pnlPopup17" runat="server" Width="900px" Height="250px" 
                style="padding:15px;display:none" BackColor="White"  >
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
                            CONTINUITY/IR TEST</td>
                        <td class="tdstyle4">N/A
                            <input id="chk_11cit" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_11cit','_11cit')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_11cit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            NO.OF LIGHTING CIRCUITS TESTED&nbsp;</td>
                        <td class="tdstyle5">N/A
                            <input id="chk_11lct" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_11lct','_11lct')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_11lct" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            ADDRESSING/PROGRAMMING TEST</td>
                        <td class="tdstyle6">N/A
                           <input id="chk_11apt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_11apt','_11apt')"/>
                           </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_11apt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            PC HEADEND/INTERFACE TEST</td>
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
                            CONSULTANT ACCEPTED</td>
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
                            TEST SHEETS FILED</td>
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
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle4">N/A
                           <input id="chk_11actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_11actby','_11actby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_11actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle5">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_11commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
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
        
         <asp:Panel ID="pnlPopup18" runat="server" Width="850px" Height="185px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:850px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="8" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_12lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            NO.OF POINTS</td>
                        <td class="tdstyle1">
                            
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_12nop" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            CABLE TESTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_12ct" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_12ct','_12ct')"/>
                            </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_12ct" runat="server" Width="75px"></asp:TextBox>
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
                            <input id="chk_12accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_12accept1','_12accept1')"/></td>
                        <td >
                           
                            <asp:TextBox ID="_12accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender142" runat="server" 
                        TargetControlID="_12accept1" PopupButtonID="_12accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle1">N/A
                            <input id="chk_12filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_12filed1','_12filed1')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_12filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender134" runat="server" 
                        TargetControlID="_12filed1" PopupButtonID="_12filed1" ClearTime="true" 
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
                            <input id="chk_12actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_12actby','_12actby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_12actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle1">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_12commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle1">N/A
                           <input id="chk_12actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_12actdt','_12actdt')" runat="server"/></td>
                        <td>
                            
                            <asp:TextBox ID="_12actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender135" runat="server" 
                        TargetControlID="_12actdt" PopupButtonID="_12actdt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
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
                           <asp:Button ID="_12btnupdate" runat="server" Text="Update" 
                                onclick="_12btnupdate_Click"  />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_12btncancel" runat="server" Text="Cancel" 
                                onclick="_12btncancel_Click"  />
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
        
        <asp:Panel ID="pnlPopup19" runat="server" Width="825px" Height="225px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_15lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            CONTINUITY/IR TEST&nbsp;</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15cit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            KEY CARD ACTIVATED</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15kca" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            DO NOT DISTURB(DND)/ DOORBELL</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15dnd" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            MAKE UP ROOM</td>
                        <td width="75PX">
                            <asp:TextBox ID="_15mur" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            FCU/ TEMP CONTROL</td>
                        <td width="75PX">
                            <asp:TextBox ID="_15ftc" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            ENERGY MANAGEMENT SYSTEM</td>
                        <td width="75PX">
                            <asp:TextBox ID="_15ems" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            LIGHTING SCENE CONTROL</td>
                        <td width="75PX">
                            <asp:TextBox ID="_15lsc" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            BLINDS CONTROL INTERFACE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_15bci" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            MONITORING INTERFACE (FUTURE)</td>
                        <td width="75PX">
                            <asp:TextBox ID="_15mif" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td >
                           
                            <asp:TextBox ID="_15accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender141" runat="server" 
                        TargetControlID="_15accept1" PopupButtonID="_15accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_15filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender136" runat="server" 
                        TargetControlID="_15filed1" PopupButtonID="_15filed1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            <asp:TextBox ID="_15noof" runat="server" Width="75px" style="display:none"></asp:TextBox>
                        </td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_15actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_15commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_15actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender137" runat="server" 
                        TargetControlID="_15actdt" PopupButtonID="_15actdt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
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
        
        <asp:Panel ID="pnlPopup21" runat="server" Width="850px" Height="240px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                
                    <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_23lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            TESTED &amp; COMM.</td>
                        <td width="75PX">
                            <asp:TextBox ID="_23tc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender118" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_23tc" TargetControlID="_23tc">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            3<sup>rd</sup> PARTY INSPECTED</td>
                        <td width="75PX">
                            <asp:TextBox ID="_23tpi" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender119" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_23tpi" TargetControlID="_23tpi">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            EMERGENCY LIGHTING</td>
                        <td width="75PX">
                            <asp:TextBox ID="_23eml" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender143" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_23eml" TargetControlID="_23eml">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            POWER FAILURE MODE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_23pfm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender144" runat="server" 
                        TargetControlID="_23pfm" PopupButtonID="_23pfm" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            LIFT MONITORING SYSTEM</td>
                        <td width="75PX">
                            <asp:TextBox ID="_23lms" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender145" runat="server" 
                        TargetControlID="_23lms" PopupButtonID="_23lms" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            INTERCOM</td>
                        <td width="75PX">
                            <asp:TextBox ID="_23int" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender146" runat="server" 
                        TargetControlID="_23int" PopupButtonID="_23int" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            BMS/FIRE ALARM INTERFACE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_23bfa" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender147" runat="server" 
                        TargetControlID="_23bfa" PopupButtonID="_23bfa" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td >
                           
                            <asp:TextBox ID="_23accept1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender108" runat="server" 
                        TargetControlID="_23accept1" PopupButtonID="_23accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_23filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender116" runat="server" 
                        TargetControlID="_23filed1" PopupButtonID="_23filed1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                        </td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_23actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_23commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_23actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender117" runat="server" 
                        TargetControlID="_23actdt" PopupButtonID="_23actdt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_23btnupdate" runat="server" Text="Update" 
                                onclick="_23btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_23btncancel" runat="server" Text="Cancel" 
                                onclick="_23btncancel_Click" />
                        </td>
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
                 <div id="Div20" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress22" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload21" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy21" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender21" runat="server" TargetControlID="btnDummy21"  PopupControlID="pnlPopup21" BackgroundCssClass="modal" ></asp:ModalPopupExtender> 
        
        <asp:Panel ID="pnlPopup22" runat="server" Width="850" Height="240px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:900;" cellpadding="3" border="0" cellspacing="0" >
                
                    <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_16lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            CONTINUITY/IR TEST</td>
                        <td class="tdstyle7">N/A
                            <input id="chk_16ir" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_16ir','_16ir')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_16ir" runat="server" Width="75px" Text="0"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            POINT TO POINT TEST</td>
                        <td class="tdstyle8">N/A
                            <input id="chk_16ppt" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_16ppt','_16ppt')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_16ppt" runat="server" Width="75px" Text="0"></asp:TextBox>
                        </td>
                        <td width="200PX">CALIBRATION/FUNCTIONAL TEST</td>
                        <td class="tdstyle9">N/A
                            <input id="chk_16cft" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_16cft','_16cft')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_16cft" runat="server" Width="75px" Text="0"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td width="200PX">CONSULTANT ACCEPTED</td>
                        <td class="tdstyle7">N/A
                            <input id="chk_16accept1" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_16accept1','_16accept1')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_16accept1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender151" runat="server" 
                        TargetControlID="_16accept1" PopupButtonID="_16accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">TEST SHEETS FILED</td>
                        <td class="tdstyle8">N/A
                            <input id="chk_16filed1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_16filed1','_16filed1')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_16filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender152" runat="server" 
                        TargetControlID="_16filed1" PopupButtonID="_16filed1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX"></td>
                        <td class="tdstyle9">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="200PX">SEQ. OF OP TEST</td>
                        <td class="tdstyle7">N/A
                           <input id="chk_16sop" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_16sop','_16sop')"/>
                            </td>
                        <td width="75PX">
                            <asp:TextBox ID="_16sop" runat="server" Width="75px" Text="0"></asp:TextBox>
                        </td>
                        <td width="200PX">GRAPHIC/HEAD END TEST</td>
                        <td class="tdstyle8">N/A
                            <input id="chk_16ght" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_16ght','_16ght')"/>
                            </td>
                        <td width="75PX"><asp:TextBox ID="_16ght" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td class="tdstyle9">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td class="tdstyle7">N/A
                            <input id="chk_16accept2" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_16accept2','_16accept2')"/>
                            </td>
                        <td >
                           
                            <asp:TextBox ID="_16accept2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender155" runat="server" 
                        TargetControlID="_16accept2" PopupButtonID="_16accept2" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td class="tdstyle8">N/A
                            <input id="chk_16filed2"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_16filed2','_16filed2')"/>
                           </td>
                        <td >
                           
                            <asp:TextBox ID="_16filed2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender156" runat="server" 
                        TargetControlID="_16filed2" PopupButtonID="_16filed2" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                        </td>
                        <td class="tdstyle9">
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td class="tdstyle7">N/A
                           <input id="chk_16actby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_16actby','_16actby')" runat="server"/></td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_16actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td class="tdstyle8">
                            &nbsp;</td>
                        <td>
                            COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            
                            <asp:TextBox ID="_16commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="tdstyle7">N/A
                           <input id="chk_16actdt" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_16actdt','_16actdt')" runat="server"/></td>
                        <td>
                            
                            <asp:TextBox ID="_16actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender157" runat="server" 
                        TargetControlID="_16actdt" PopupButtonID="_16actdt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle8">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tdstyle7">
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_16btnupdate" runat="server" Text="Update" 
                                onclick="_16btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_16btncancel" runat="server" Text="Cancel" 
                                onclick="_16btncancel_Click" />
                        </td>
                        <td align="left" class="tdstyle8">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                           
                        </td>
                        <td class="tdstyle9">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
                 <div id="Div22" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress23" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload22" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy22" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender22" runat="server" TargetControlID="btnDummy22"  PopupControlID="pnlPopup22" BackgroundCssClass="modal" ></asp:ModalPopupExtender> 
       
       <asp:Panel ID="pnlPopup23" runat="server" Width="825px" Height="200px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                
                    <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_24lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                     <tr style="background-color:#83C8EE">
                <td width="200px">
                    PLANNED POWER ON</td>
                <td width="75px">
                <asp:TextBox ID="_24pwron" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender153" runat="server" 
                        TargetControlID="_24pwron" PopupButtonID="_24pwron" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                </td>
                    <td width="200px">
                        &nbsp;</td>
                    <td width="75px">
                        &nbsp;</td>
                <td width="200px">
                </td>
                <td width="75px"></td>
                </tr>
                    <tr>
                        <td width="200PX">
                            CONTINUITY/IR TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24ir" runat="server" Width="75px" ></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender154" runat="server" 
                        TargetControlID="_24ir" PopupButtonID="_24ir" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            FUNCTIONAL TEST (@max Amps)</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24ft" runat="server" Width="75px" ></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender158" runat="server" 
                        TargetControlID="_24ft" PopupButtonID="_24ft" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">INTERFACE TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24it" runat="server" Width="75px" ></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender159" runat="server" 
                        TargetControlID="_24it" PopupButtonID="_24it" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td width="200PX">CONSULTANT ACCEPTED</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24accept1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender148" runat="server" 
                        TargetControlID="_24accept1" PopupButtonID="_24accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">TEST SHEETS FILED</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender149" runat="server" 
                        TargetControlID="_24filed1" PopupButtonID="_24filed1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX"></td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_24actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_24commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_24actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender150" runat="server" 
                        TargetControlID="_24actdt" PopupButtonID="_24actdt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_24btnupdate" runat="server" Text="Update" 
                                onclick="_24btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_24btncancel" runat="server" Text="Cancel" 
                                onclick="_24btncancel_Click" />
                        </td>
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
                 <div id="Div23" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress24" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload23" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy23" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender23" runat="server" TargetControlID="btnDummy23"  PopupControlID="pnlPopup23" BackgroundCssClass="modal"></asp:ModalPopupExtender>
        
        
        <asp:Panel ID="pnlPopup24" runat="server" Width="825px" Height="300px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_30lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                 <tr style="background-color:#83C8EE">
                <td width="200px">
                    PLANNED POWER ON</td>
                <td width="75px">
                <asp:TextBox ID="_30pwron" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender160" runat="server" 
                        TargetControlID="_30pwron" PopupButtonID="_30pwron" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                </td>
                    <td width="200px">
                        INSLALLATION & DOCUMENTATION COMPLETE</td>
                    <td width="75px">
                        <asp:TextBox ID="_30idc" runat="server" Width="75px"></asp:TextBox>
                        <asp:CalendarExtender ID="_30idc_CalendarExtender" runat="server" 
                            ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_30idc" 
                            TargetControlID="_30idc">
                        </asp:CalendarExtender>
                     </td>
                <td width="200px">
                 </td>
                <td width="75px">
                    <asp:TextBox ID="_30dlt" runat="server" Width="75px" style="display:none"></asp:TextBox>
                    <asp:CalendarExtender ID="_30dlt_CalendarExtender" runat="server" 
                        ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_30dlt" 
                        TargetControlID="_30dlt">
                    </asp:CalendarExtender>
                     </td>
                </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="6"  align="center">
                            MECHANICAL SYSTEMS</td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            PRE-COMM</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_30pc1" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender161" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_30pc1" 
                                TargetControlID="_30pc1">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            COMM</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_30co1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender162" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_30co1" 
                                TargetControlID="_30co1">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                         WITNESSED DATE</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_30wd1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender163" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_30wd1" TargetControlID="_30wd1">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td >
                           
                            <asp:TextBox ID="_30accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender164" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_30accept1" 
                                TargetControlID="_30accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_30filed1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender165" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_30filed1" 
                                TargetControlID="_30filed1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#092443;color:White">
                        <td colspan="6" align="center">
                            CONTROLS</td>
                    </tr>
                    <tr>
                        <td>
                            PRE-COMM&nbsp;</td>
                        <td>
                             <asp:CalendarExtender ID="CalendarExtender166" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_30pc2" 
                                TargetControlID="_30pc2">
                            </asp:CalendarExtender>
                             <asp:TextBox ID="_30pc2" runat="server" 
                                Width="75px"></asp:TextBox></td>
                        <td>
                            COMM</td>
                        <td>
                            <asp:TextBox ID="_30co2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender167" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_30co2" 
                                TargetControlID="_30co2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            WITNESSED DATE</td>
                        <td>
                            <asp:TextBox ID="_30wd2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender168" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_30wd2" 
                                TargetControlID="_30wd2">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_30actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_30commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_30actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender169" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_30actdt" 
                                TargetControlID="_30actdt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_30btnupdate" runat="server" Text="Update" 
                                onclick="_30btnupdate_Click"  />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_30btncancel" runat="server" Text="Cancel" 
                                onclick="_30btncancel_Click"  />
                        </td>
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
                 <div  runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress25" runat="server" >
            <ProgressTemplate>
                <asp:Image runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy24" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender24" runat="server" TargetControlID="btnDummy24"  PopupControlID="pnlPopup24" BackgroundCssClass="modal" ></asp:ModalPopupExtender> 
        
        <asp:Panel ID="pnlPopup25" runat="server" Width="825px" Height="300px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_25lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                 <tr style="background-color:#83C8EE">
                <td width="200px">
                    PLANNED POWER ON</td>
                <td width="75px">
                <asp:TextBox ID="_25pwron" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender170" runat="server" 
                        TargetControlID="_25pwron" PopupButtonID="_25pwron" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                </td>
                    <td width="200px">
                        INSLALLATION & DOCUMENTATION COMPLETE</td>
                    <td width="75px">
                        <asp:TextBox ID="_25idc" runat="server" Width="75px"></asp:TextBox>
                        <asp:CalendarExtender ID="_25idc_CalendarExtender" runat="server" 
                            ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25idc" 
                            TargetControlID="_25idc">
                        </asp:CalendarExtender>
                     </td>
                <td width="200px">
                    </td>
                <td width="75px">
                    &nbsp;</td>
                </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="6"  align="center">
                            MECHANICAL SYSTEMS</td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            PRE-COMM</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_25pc1" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender172" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25pc1" 
                                TargetControlID="_25pc1">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            COMM</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_25co1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender173" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25co1" 
                                TargetControlID="_25co1">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                         WITNESSED DATE</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_25wd1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender174" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_25wd1" TargetControlID="_25wd1">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td >
                           
                            <asp:TextBox ID="_25accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender175" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25accept1" 
                                TargetControlID="_25accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_25filed1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender176" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25filed1" 
                                TargetControlID="_25filed1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            <asp:Label ID="lbl_25duty" runat="server" Text="% DUTY"></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="_26duty" runat="server" Width="75px"></asp:TextBox>
                            
                      </td>
                    </tr>
                    <tr style="background-color:#092443;color:White">
                        <td colspan="6" align="center">
                            CONTROLS</td>
                    </tr>
                    <tr>
                        <td>
                            PRE-COMM&nbsp;</td>
                        <td>
                             <asp:CalendarExtender ID="CalendarExtender177" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25pc2" 
                                TargetControlID="_25pc2">
                            </asp:CalendarExtender>
                             <asp:TextBox ID="_25pc2" runat="server" 
                                Width="75px"></asp:TextBox></td>
                        <td>
                            COMM</td>
                        <td>
                            <asp:TextBox ID="_25co2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender178" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25co2" 
                                TargetControlID="_25co2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            WITNESSED DATE</td>
                        <td>
                            <asp:TextBox ID="_25wd2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender179" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25wd2" 
                                TargetControlID="_25wd2">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_25actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_25commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_25actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender180" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25actdt" 
                                TargetControlID="_25actdt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_25btnupdate" runat="server" Text="Update" 
                                onclick="_25btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_25btncancel" runat="server" Text="Cancel" 
                                onclick="_25btncancel_Click" />
                        </td>
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
                 <div  runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress26" runat="server" >
            <ProgressTemplate>
                <asp:Image runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy25" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender25" runat="server" TargetControlID="btnDummy25"  PopupControlID="pnlPopup25" BackgroundCssClass="modal"></asp:ModalPopupExtender>
        
        <asp:Panel ID="pnlPopup26" runat="server" Width="825px" Height="210px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_28lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                        INSTALLATION & DOCUMENTATION COMPLETION
                        </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_28idc" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender182" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_28idc" 
                                TargetControlID="_28idc">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            PRE-COMM</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_28prc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender183" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_28prc" 
                                TargetControlID="_28prc">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                         STAND ALONE COMMISSION</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_28sac" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender184" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_28sac" TargetControlID="_28sac">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            FIRE &amp; BMS INTERFACE TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_28fit" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_28pc3_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_28fit" 
                                TargetControlID="_28fit">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            WITNESSED</td>
                        <td width="75PX">
                            <asp:TextBox ID="_28wts" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_28pc4_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_28wts" 
                                TargetControlID="_28wts">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td >
                           
                            <asp:TextBox ID="_28accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender185" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_28accept1" 
                                TargetControlID="_28accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_28filed1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender186" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_28filed1" 
                                TargetControlID="_28filed1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_28actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_28commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_28actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender190" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_28actdt" 
                                TargetControlID="_28actdt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_28btnupdate" runat="server" Text="Update" 
                                onclick="_28btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_28btncancel" runat="server" Text="Cancel" 
                                onclick="_28btncancel_Click" />
                        </td>
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
                 <div  runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress27" runat="server" >
            <ProgressTemplate>
                <asp:Image runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy26" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender26" runat="server" TargetControlID="btnDummy26"  PopupControlID="pnlPopup26" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
        
        <asp:Panel ID="pnlPopup27" runat="server" Width="825px" Height="240px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_34lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                        MECHANICAL
                        </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_34mec" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender171" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34mec" 
                                TargetControlID="_34mec">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                         ELECTRICAL</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_34ele" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender181" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34ele" 
                                TargetControlID="_34ele">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                         FIRE/BMS/SCADA</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_34fbs" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender187" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_34fbs" TargetControlID="_34fbs">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            BUILDING IN AUTO</td>
                        <td width="75PX">
                            <asp:TextBox ID="_34bia" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender188" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34bia" 
                                TargetControlID="_34bia">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            POWER FAILURE TESTING</td>
                        <td width="75PX">
                            <asp:TextBox ID="_34pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender189" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34pft" 
                                TargetControlID="_34pft">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            EMERGENCY POWER PICK UP TESTS</td>
                        <td width="75PX">
                            <asp:TextBox ID="_34epp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_34epp_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34epp" 
                                TargetControlID="_34epp">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            FA C&amp;E TESTS WITH POWER FAILURE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_34fct" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_34fct_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34fct" 
                                TargetControlID="_34fct">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            THE POWER REINSTATEMENT TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_34prt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_34prt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34prt" 
                                TargetControlID="_34prt">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            ENGINEER ACCEPTED</td>
                        <td >
                           
                            <asp:TextBox ID="_34accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender191" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34accept1" 
                                TargetControlID="_34accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_34filed1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender192" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34filed1" 
                                TargetControlID="_34filed1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_34actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_34commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_34actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender193" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_34actdt" 
                                TargetControlID="_34actdt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_34btnupdate" runat="server" Text="Update" 
                                onclick="_34btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_34btncancel" runat="server" Text="Cancel" 
                                onclick="_34btncancel_Click" />
                        </td>
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
                 <div  runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress28" runat="server" >
            <ProgressTemplate>
                <asp:Image runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy27" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender27" runat="server" TargetControlID="btnDummy27"  PopupControlID="pnlPopup27" BackgroundCssClass="modal" ></asp:ModalPopupExtender> 
        
        
        <asp:Panel ID="pnlPopup28" runat="server" Width="825px" Height="240px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel38" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_35lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                        MECHANICAL
                        </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_35mec" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender194" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_35mec" 
                                TargetControlID="_35mec">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                         ELECTRICAL</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_35ele" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender195" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_35ele" 
                                TargetControlID="_35ele">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                         FIRE/BMS/SCADA</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_35fbs" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender196" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_35fbs" TargetControlID="_35fbs">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            BUILDING IN AUTO</td>
                        <td width="75PX">
                            <asp:TextBox ID="_35bia" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender197" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_35bia" 
                                TargetControlID="_35bia">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            NOISE LEVEL TESTING&nbsp;</td>
                        <td width="75PX">
                            <asp:TextBox ID="_35nlt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender198" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_35nlt" 
                                TargetControlID="_35nlt">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            VIBRATION TESTING</td>
                        <td width="75PX">
                            <asp:TextBox ID="_35vit" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender199" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_35vit" 
                                TargetControlID="_35vit">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            ACOUSTIC CONSULTANT ACCEPTED</td>
                        <td width="75PX">
                            <asp:TextBox ID="_35aca" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender200" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_35aca" 
                                TargetControlID="_35aca">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                        </td>
                        <td width="75PX">
                            &nbsp;</td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            ENGINEER ACCEPTED</td>
                        <td >
                           
                            <asp:TextBox ID="_35accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender204" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_35accept1" 
                                TargetControlID="_35accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_35filed1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender202" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_35filed1" 
                                TargetControlID="_35filed1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_35actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_35commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_35actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender203" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_35actdt" 
                                TargetControlID="_35actdt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_35btnupdate" runat="server" Text="Update" 
                                onclick="_35btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_35btncancel" runat="server" Text="Cancel" 
                                onclick="_35btncancel_Click"  />
                        </td>
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
                 <div  runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress29" runat="server" >
            <ProgressTemplate>
                <asp:Image runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy28" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender28" runat="server" TargetControlID="btnDummy28"  PopupControlID="pnlPopup28" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
        
        <asp:Panel ID="pnlPopup29" runat="server" Width="825px" Height="350px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel39" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_36lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr style="background-color:#092443;color:White">
                        <td colspan="6" align="center">
                            Electrical Testing
                            </td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                        COLD POWER CABLE TESTING
                        </td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_36cpc" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender201" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_36cpc" 
                                TargetControlID="_36cpc">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                         LIVE POWER CABLE TESTING</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_36lpc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender213" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_36lpc" 
                                TargetControlID="_36lpc">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                         COLD BUS RAIL TESTING</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_36cbr" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender205" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_36cbr" TargetControlID="_36cbr">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            LIVE BUS RAIL TESTING</td>
                        <td width="75PX">
                            <asp:TextBox ID="_36lbr" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender206" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_36lbr" 
                                TargetControlID="_36lbr">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            WITNESS OF COLD & LIVE TESTING</td>
                        <td width="75PX">
                            <asp:TextBox ID="_36wcl" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender207" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_36wcl" 
                                TargetControlID="_36wcl">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            </td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#092443;color:White">
                        <td colspan="6" align="center">
                         Life and Safety Functional Tests</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            COMMS APPROVED</td>
                        <td width="75PX">
                            <asp:TextBox ID="_36coa" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender209" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_36coa" 
                                TargetControlID="_36coa">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">LOAD TESTS
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_36lot" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_36lot_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_36lot" 
                                TargetControlID="_36lot">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">SAFETY LINK SWITCH &amp; ANTI-COLLISION TESTS
                         </td>
                        <td width="75PX">
                            <asp:TextBox ID="_36sls" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_36sls_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_36sls" 
                                TargetControlID="_36sls">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">FLOOD LIGHT & EMERGENCY LIGHT TESTS
                            &nbsp;</td> 
                        <td width="75PX">
                            <asp:TextBox ID="_36fle" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_36fle_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_36fle" 
                                TargetControlID="_36fle">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#092443;color:White">
                        <td colspan="6" align="center">COMMISSIONING
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">TESTED &amp; COMM.
                            &nbsp;</td>
                        <td width="75PX">
                            <asp:TextBox ID="_36tsc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_36tsc_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_36tsc" 
                                TargetControlID="_36tsc">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">3RD PART INSPECTED
                            &nbsp;</td>
                        <td width="75PX">
                            <asp:TextBox ID="_36tpi" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_36tpi_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_36tpi" 
                                TargetControlID="_36tpi">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            ENGINEER ACCEPTED</td>
                        <td >
                           
                            <asp:TextBox ID="_36accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender210" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_36accept1" 
                                TargetControlID="_36accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_36filed1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender211" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_36filed1" 
                                TargetControlID="_36filed1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_36actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_36commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_36actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender212" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_36actdt" 
                                TargetControlID="_36actdt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_36btnupdate" runat="server" Text="Update" 
                                onclick="_36btnupdate_Click"  />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_36btncancel" runat="server" Text="Cancel" 
                                onclick="_36btncancel_Click"  />
                        </td>
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
                 <div  runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress30" runat="server" >
            <ProgressTemplate>
                <asp:Image runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy29" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender29" runat="server" TargetControlID="btnDummy29"  PopupControlID="pnlPopup29" BackgroundCssClass="modal" ></asp:ModalPopupExtender> 
             
        <asp:Panel ID="pnlPopup30" runat="server" Width="825px" Height="230px" style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_37lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            BATTERY CHARGING</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_37bc" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender208" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_37bc" 
                                TargetControlID="_37bc">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            BATTERY DISCHARGING</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_37bd" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender214" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_37bd" 
                                TargetControlID="_37bd">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            BATTERY RECHARGING</td>
                        <td width="75PX" >
                           
                            <asp:TextBox ID="_37br" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender215" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_37br" 
                                TargetControlID="_37br">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td >
                            FUNCTIONAL TEST</td>
                        <td >
                           
                            <asp:TextBox ID="_37fn" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender218" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_37fn" 
                                TargetControlID="_37fn">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                           
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                            
                        </td>
                    </tr>
                    <tr >
                        <td>
                            INSTALLATION SIGN OFF</td>
                        <td>
                            <asp:TextBox ID="_37iso" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender221" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_37iso" 
                                TargetControlID="_37iso">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            CONSULTANT ACCEPTED</td>
                        <td>
                            <asp:TextBox ID="_37accept" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender222" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_37accept" 
                                TargetControlID="_37accept">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            TEST SHEETS FILED</td>
                        <td>
                            <asp:TextBox ID="_37filed" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender223" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_37filed" 
                                TargetControlID="_37filed">
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
                        <td colspan="2">
                            
                            <asp:TextBox ID="_37actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_37commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_37actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender224" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_37actdt" 
                                TargetControlID="_37actdt">
                            </asp:CalendarExtender>
                            
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_37btnupdate" runat="server" Text="Update" 
                                onclick="_37btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_37btncancel" runat="server" Text="Cancel" 
                                onclick="_37btncancel_Click" />
                        </td>
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
                  <div  runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress31" runat="server" >
            <ProgressTemplate>
                <asp:Image  runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
               
           
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy30" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender30" runat="server" TargetControlID="btnDummy30"  PopupControlID="pnlPopup30" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
        
        <asp:Panel ID="pnlPopup2_1" runat="server" Width="825px" Height="340px" style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_3lbl_1" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                <tr style="background-color:#83C8EE">
                <td width="200px">
                    PLANNED POWER ON</td>
                <td width="75px">
                <asp:TextBox ID="_3pwron_1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3pwron_1_CalendarExtender2" runat="server" 
                        TargetControlID="_3pwron_1" PopupButtonID="_3pwron_1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                </td>
                    <td width="200px">
                        &nbsp;</td>
                    <td width="75px">
                        &nbsp;</td>
                <td width="200px">
                </td>
                <td width="75px"></td>
                </tr>
                
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="6"  align="center">
                            TRANSFORMER TESTING</td>
                    </tr>
                
                    <tr >
                        <td >
                            IR TEST</td>
                        <td >
                        <asp:CheckBox ID="chk_3ir_1" runat="server" Text="N/A" onclick="_checked('chk_3ir_1','_3ir_1')" />
                            <asp:TextBox ID="_3ir_1" runat="server" Width="75px" 
                                ></asp:TextBox>
                            <asp:CalendarExtender ID="_3ir_1_CalendarExtender3" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3ir_1" 
                                TargetControlID="_3ir_1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            RATIO TEST</td>
                        <td >
                        <asp:CheckBox ID="chk_3rt_1" runat="server" Text="N/A" onclick="_checked('chk_3rt_1','_3rt_1')" />
                            <asp:TextBox ID="_3rt_1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3rt_1_CalendarExtender4" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3rt_1" 
                                TargetControlID="_3rt_1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            MAGNETIC CORE BALANCE TEST</td>
                        <td >
                        <asp:CheckBox ID="chk_3mcbt" runat="server" Text="N/A" onclick="_checked('chk_3mcbt','_3mcbt')" />
                            <asp:TextBox ID="_3mcbt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3mcbt_CalendarExtender5" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3mcbt" 
                                TargetControlID="_3mcbt">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr >
                        <td >
                            MAGNETIZING CURRENT TEST</td>
                        <td>
                        <asp:CheckBox ID="chk_3mct" runat="server" Text="N/A" onclick="_checked('chk_3mct','_3mct')" />
                            <asp:TextBox ID="_3mct" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3mct_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3mct" 
                                TargetControlID="_3mct">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            VECTOR GROUP TEST</td>
                        <td >
                        <asp:CheckBox ID="chk_3vg_1" runat="server" Text="N/A" onclick="_checked('chk_3vg_1','_3vg_1')" />
                            <asp:TextBox ID="_3vg_1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3vg_1_CalendarExtender6" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3vg_1" 
                                TargetControlID="_3vg_1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEMP. RELAY FUNCTIONAL TEST</td>
                        <td >
                        <asp:CheckBox ID="chk_3trf_11" runat="server" Text="N/A" onclick="_checked('chk_3trf_11','_3trf_1')" />
                            <asp:TextBox ID="_3trf_1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3trf_1_CalendarExtender7" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3trf_1" 
                                TargetControlID="_3trf_1">
                            </asp:CalendarExtender>
                        
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td >
                            <asp:TextBox ID="_3accept1_1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3accept1_1_CalendarExtender13" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3accept1_1" 
                                TargetControlID="_3accept1_1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                            <asp:TextBox ID="_3filed1_1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3filed1_1_CalendarExtender14" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_3filed1_1" TargetControlID="_3filed1_1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="6" align="center">
                            CABLE TEST</td>
                    </tr>
                    <tr >
                        <td >
                            CABLE IR AND HI POT</td>
                        <td >
                            <asp:TextBox ID="_3cable_1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3cable_1_CalendarExtender11" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_3cable_1" TargetControlID="_3cable_1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td >
                            <asp:TextBox ID="_3accept2_1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3accept2_1_CalendarExtender15" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3accept2_1" 
                                TargetControlID="_3accept2_1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                            <asp:TextBox ID="_3filed2_1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3filed2_1_CalendarExtender16" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3filed2_1" 
                                TargetControlID="_3filed2_1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td colspan="2">
                            <asp:TextBox ID="_3actby_1" runat="server" Width="250px"></asp:TextBox>
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            <asp:TextBox ID="_3commts_1" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            <asp:TextBox ID="_3actdt_1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3actdt_1_CalendarExtender17" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3actdt_1" 
                                TargetControlID="_3actdt_1">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                            <asp:Button ID="_3btnupdate_1" runat="server" 
                                Text="Update" onclick="_3btnupdate_1_Click" />
                        </td>
                        <td align="left">
                            <asp:Button ID="_3btncancel_1" runat="server" 
                                Text="Cancel" onclick="_3btncancel_1_Click" />
                        </td>
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
                 <div id="Div1_1" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress3_1" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload2_1" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy2_1" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender2_1" runat="server" TargetControlID="btnDummy2_1"  PopupControlID="pnlPopup2_1" BackgroundCssClass="modal"></asp:ModalPopupExtender>
        
        <asp:Panel ID="pnlPopup25a" runat="server" Width="825px" Height="200px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_25albl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            POWER FAIL/EMERGENCY CONDITION</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_25apfec" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender217" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25apfec" 
                                TargetControlID="_25apfec">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            MEASURED PUE</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_25amp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender219" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25amp" 
                                TargetControlID="_25amp">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            &nbsp;</td>
                        <td width="75PX" >
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            ENVIORNMENTAL BUILDING TEST</td>
                        <td >
                           
                            <asp:TextBox ID="_25aebt" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender220" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25aebt" 
                                TargetControlID="_25aebt">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_25afiled1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender225" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25afiled1" 
                                TargetControlID="_25afiled1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#092443;color:White">
                        <td colspan="6" align="center">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_25aactby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_25acommts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_25aactdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender226" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25aactdt" 
                                TargetControlID="_25aactdt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_25abtnupdate" runat="server" Text="Update" 
                                onclick="_25abtnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_25abtncancel" runat="server" Text="Cancel" 
                                onclick="_25abtncancel_Click" />
                        </td>
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
                 <div id="Div21"  runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress32" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy25a" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender25a" runat="server" TargetControlID="btnDummy25a"  PopupControlID="pnlPopup25a" BackgroundCssClass="modal"></asp:ModalPopupExtender>
        
        <asp:Button ID="btnDummy26a" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender26a" runat="server" TargetControlID="btnDummy26a"  PopupControlID="pnlPopup26a" BackgroundCssClass="modal" ></asp:ModalPopupExtender> 
        <asp:Panel ID="pnlPopup26a" runat="server" Width="826px" Height="193px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel43" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:826px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:26px" >
                            <asp:Label ID="_26lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            CONTINUITY TEST</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_26ct" runat="server" Width="75px"></asp:TextBox>
                            
                        </td>
                        <td width="200PX" >
                            PROGRAMMING &amp; COMMUNICATION TEST</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_26pct" runat="server" Width="75px"></asp:TextBox>
                            
                        </td>
                        <td width="200PX" >
                         COMMISSIONING</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_26comm" runat="server" Width="75px"></asp:TextBox>
                          
                        </td>
                    </tr>
                    <tr style="background-color:#092443;color:White">
                        <td colspan="6" align="center">
                            FINAL TEST SHEETS</td>
                    </tr>
                    <tr>
                        <td>
                            CONSULTANT ACCEPTED</td>
                        <td>
                             <asp:CalendarExtender ID="CalendarExtender227" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_26accept1" 
                                TargetControlID="_26accept1">
                            </asp:CalendarExtender>
                             <asp:TextBox ID="_26accept1" runat="server" 
                                Width="75px"></asp:TextBox></td>
                        <td>
                            TEST SHEETS FILED</td>
                        <td>
                            <asp:TextBox ID="_26filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender228" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_26filed1" 
                                TargetControlID="_26filed1">
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
                        <td colspan="2">
                            
                            <asp:TextBox ID="_26actby" runat="server" Width="260px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_26commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_26actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender229" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_26actdt" 
                                TargetControlID="_26actdt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_26btnupdate" runat="server" Text="Update" 
                                onclick="_26btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_26btncancel" runat="server" Text="Cancel" 
                                onclick="_26btncancel_Click" />
                        </td>
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
                 <div id="Div24"  runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress33" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="Image26" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="260px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        
        <asp:Button ID="btnDummy27a" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender27a" runat="server" TargetControlID="btnDummy27a"  PopupControlID="pnlPopup27a" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
        <asp:Panel ID="pnlPopup27a" runat="server" Width="825px" Height="225px" 
                style="padding:27px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel45" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_27lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            CONTINUITY/IR TEST&nbsp;</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_27cit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            &nbsp;DB LEVELS</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_27dl" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            &nbsp;</td>
                        <td width="75PX" >
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            PAGING MISC</td>
                        <td width="75PX">
                            <asp:TextBox ID="_27pm" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            ADDRESSING/SOFTWARE TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_27ast" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            %&nbsp; TEST COMPLETE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_27aptc" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                         <tr style="background-color:#092443;color:White">
                        <td colspan="6" align="center">
                            FINAL TEST SHEETS</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td >
                           
                            <asp:TextBox ID="_27accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender233" runat="server" 
                        TargetControlID="_27accept1" PopupButtonID="_27accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_27filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender234" runat="server" 
                        TargetControlID="_27filed1" PopupButtonID="_27filed1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            <asp:TextBox ID="_27noof" runat="server" Width="75px" style="display:none"></asp:TextBox>
                        </td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_27actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_27commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_27actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender235" runat="server" 
                        TargetControlID="_27actdt" PopupButtonID="_27actdt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_27btnupdate" runat="server" Text="Update" 
                                onclick="_27btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_27btncancel" runat="server" Text="Cancel" 
                                onclick="_27btncancel_Click"  />
                        </td>
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
                 <div id="Div26" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress35" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload27a" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px"  />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        
        <asp:Button ID="btnDummy15a" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender15a" runat="server" TargetControlID="btnDummy15a"  PopupControlID="pnlPopup15a" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
        <asp:Panel ID="pnlPopup15a" runat="server" Width="825px" Height="300px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel44" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_15albl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            CONTINUITY/IR TEST&nbsp;</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15acit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            &nbsp;NO OF TEST HOLES TESTED </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15atht" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            &nbsp;</td>
                        <td width="75PX" >
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            TEST HOLE TEST COMPLETE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_15athtc" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            FA INTERFACES TESTED</td>
                        <td width="75PX">
                            <asp:TextBox ID="_15afit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            FA INTERFACE TEST COMPLETE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_15afitc" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                         <tr style="background-color:#092443;color:White">
                        <td colspan="6" align="center">
                            TEST SHEETS</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td >
                           
                            <asp:TextBox ID="_15aaccept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender230" runat="server" 
                        TargetControlID="_15aaccept1" PopupButtonID="_15aaccept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_15afiled1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender231" runat="server" 
                        TargetControlID="_15afiled1" PopupButtonID="_15afiled1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            <asp:TextBox ID="_15anoof" runat="server" Width="75px" style="display:none"></asp:TextBox>
                        </td>
                        <td >
                      </td>
                    </tr>
                    <tr>
                        <td>
                            BATTERY AUTONOMY TEST</td>
                        <td>
                            <asp:TextBox ID="_15abat" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_15a_15abat_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_15abat" 
                                TargetControlID="_15abat">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            CAUSE &amp; EFFECT TESTS</td>
                        <td>
                            <asp:TextBox ID="_15acet" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_15afiled2_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_15acet" 
                                TargetControlID="_15acet">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                     <tr style="background-color:#092443;color:White">
                        <td colspan="6" align="center">
                           FINAL TEST SHEETS</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            CONSULTANT ACCEPTED</td>
                        <td>
                            <asp:TextBox ID="_15aaccept2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_15afiled5_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_15aaccept2" 
                                TargetControlID="_15aaccept2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            TEST SHEETS FILED</td>
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
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_15aactby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_15acommts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
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
                    </tr>
                
                    <tr>
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
                 <div id="Div25" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress34" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload15a" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px"  />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        
        <asp:Panel ID="pnlMVTestDataInput" runat="server" Width="825px" Height="450px" style="padding:10px;top:0%!important;left:20%!important;" BackColor="White"   >
           <div>
            <asp:UpdatePanel ID="UpdatePaneMVTestDataInput" runat="server">
            <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                    <tr >
                        <td colspan="9" style="background-color: #092443;height:25px" >
                            <asp:Label ID="lblHeader1" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                     <tr style="background-color:#83C8EE">
                        <td width="200px">PLANNED POWER ON</td>
                        <td class="tdstyle1">N/A<input id="chkPowerOnDate" type="checkbox" style="vertical-align:middle"   onclick="_checked('chkPowerOnDate','txtPowerOnDate')" runat="server"/></td>
                        <td width="75px">
                            <asp:TextBox ID="txtPowerOnDate" runat="server" Width="75px" ></asp:TextBox>
                            <asp:CalendarExtender ID="cePowerOnDate" runat="server" TargetControlID="txtPowerOnDate" PopupButtonID="txtPowerOnDate" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200px">&nbsp;</td>
                        <td class="tdstyle1">&nbsp;</td>
                        <td width="75px">&nbsp;</td>
                        <td width="200px"></td>
                        <td class="tdstyle1">&nbsp;</td>
                        <td width="75px"></td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="9"  align="center">PANEL / EQUIPMENT TESTING</td>
                    </tr>
                    <tr id="trPanelTesting" runat="server">
                        <td >TORQUE TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chkTorqueTest" type="checkbox" style="vertical-align:middle" runat="server" value="N/A" onclick="_checked('chkTorqueTest','txtTorqueTest')"/>
                         </td>
                        <td >
                            <asp:TextBox ID="txtTorqueTest" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="ceTorqueTest" runat="server" ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txtTorqueTest" TargetControlID="txtTorqueTest"></asp:CalendarExtender>
                        </td>
                        <td >IR TEST</td>
                        <td class="tdstyle1">N/A
                           <input id="chkIRTest" type="checkbox" style="vertical-align:middle"  runat="server" value="n/a" onclick="_checked('chkIRTest','txtIRTest')"/>
                        </td>
                        <td >
                            <asp:TextBox ID="txtIRTest" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="ceIRTest" runat="server" ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txtIRTest" TargetControlID="txtIRTest"></asp:CalendarExtender>
                        </td>
                        <td >HI POT TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chkHiPotTest" type="checkbox" style="vertical-align:middle"  runat="server"  onclick="_checked('chkHiPotTest','txtHiPotTest')"/>
                         </td>
                        <td >
                            <asp:TextBox ID="txtHiPotTest" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="ceHiPotTest" runat="server" ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txtHiPotTest" TargetControlID="txtHiPotTest"></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr id="trVRTest" runat="server">
                        <td >VT TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chkVTTest" type="checkbox" style="vertical-align:middle"  runat="server"  onclick="_checked('chkVTTest','txtVTTest')"/>
                        </td>
                        <td>
                            <asp:TextBox ID="txtVTTest" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="ceVTTest" runat="server" ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txtVTTest" TargetControlID="txtVTTest"></asp:CalendarExtender>
                        </td>
                        <td >CT TEST</td>
                        <td class="tdstyle1">N/A
                             <input id="chkCTTest" type="checkbox" style="vertical-align:middle"  runat="server"  onclick="_checked('chkCTTest','txtCTTest')"/>
                        </td>
                        <td >
                            <asp:TextBox ID="txtCTTest" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="ceCTTest" runat="server" ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txtCTTest" TargetControlID="txtCTTest"></asp:CalendarExtender>
                        </td>
                        <td >PRIMARY INJECTION TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chkPrimInjTest" type="checkbox" style="vertical-align:middle"  runat="server"  onclick="_checked('chkPrimInjTest','txtPrimInjTest')"/>
                        </td>
                        <td >
                            <asp:TextBox ID="txtPrimInjTest" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="cechkPrimInjTest" runat="server" ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txtPrimInjTest" TargetControlID="txtPrimInjTest"></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr id="trSecInjTest" runat="server">
                    <td >SECONDARY INJECTION TEST</td>
                    <td class="tdstyle1">N/A
                        <input id="chkSecInjTest" type="checkbox" style="vertical-align:middle"  runat="server"  onclick="_checked('chkSecInjTest','txtSecInjTest')"/>
                    </td>
                    <td >
                    <asp:TextBox ID="txtSecInjTest" runat="server" Width="75px"></asp:TextBox>
                        <asp:CalendarExtender ID="ceSecInjTest" runat="server" ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txtSecInjTest"  TargetControlID="txtSecInjTest"></asp:CalendarExtender>
                    </td>
                    <td >DUCTOR TEST</td>
                    <td class="tdstyle1">N/A
                        <input id="chkDuctorTest" type="checkbox" style="vertical-align:middle"  runat="server"  onclick="_checked('chkDuctorTest','txtDuctorTest')"/>
                     </td>
                    <td >
                        <asp:TextBox ID="txtDuctorTest" runat="server" Width="75px"></asp:TextBox>
                        <asp:CalendarExtender ID="ceDuctorTest" runat="server" ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txtDuctorTest" TargetControlID="txtDuctorTest"></asp:CalendarExtender>
                    </td>
                    <td >FUNCTIONAL TEST</td>
                    <td class="tdstyle1">N/A
                        <input id="chkFuncTest" type="checkbox" style="vertical-align:middle"  runat="server"  onclick="_checked('chkFuncTest','txtFuncTest')"/>
                    </td>
                    <td >
                        <asp:TextBox ID="txtFuncTest" runat="server" Width="75px"></asp:TextBox>
                        <asp:CalendarExtender ID="ceFuncTest" runat="server" ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txtFuncTest"  TargetControlID="txtFuncTest"></asp:CalendarExtender>
                    </td>
                </tr>
                    <tr id="trProtRelayTest" runat="server">
                        <td >PROTECTIVE RELAY FINAL TEST</td>
                        <td class="tdstyle1">N/A
                            <input id="chkProtRelayTest" type="checkbox" style="vertical-align:middle"  runat="server"  onclick="_checked('chkProtRelayTest','txtProtRelayTest')"/>                           </td>
                        <td >
                            <asp:TextBox ID="txtProtRelayTest" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="ceProtRelayTest" runat="server" ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txtProtRelayTest" TargetControlID="txtProtRelayTest"></asp:CalendarExtender>
                        </td>
                        <td >&nbsp;</td>
                        <td class="tdstyle1">&nbsp;</td>
                        <td >&nbsp;</td>
                        <td >&nbsp;</td>
                        <td class="tdstyle1">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                            <input id="chkConsAccepted1" type="checkbox" style="vertical-align:middle"  runat="server"  onclick="_checked('chkConsAccepted1','txtConsAccepted1')"/>
                         </td>
                        <td >
                            <asp:TextBox ID="txtConsAccepted1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="ceConsAccepted1" runat="server" ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txtConsAccepted1" TargetControlID="txtConsAccepted1"></asp:CalendarExtender>
                        </td>
                        <td >TEST SHEETS FILED</td>
                        <td class="tdstyle1">N/A
                            <input id="chkTestSheetFiled1"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chkTestSheetFiled1','txtTestSheetFiled1')"/>
                        </td>
                        <td >
                            <asp:TextBox ID="txtTestSheetFiled1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="ceTestSheetFiled1" runat="server" ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txtTestSheetFiled1" TargetControlID="txtTestSheetFiled1"> </asp:CalendarExtender>
                        </td>
                        <td > &nbsp;</td>
                        <td class="tdstyle1">&nbsp;</td>
                        <td > &nbsp;</td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="9" align="center">22/11KV HV CABLE TEST</td>
                    </tr>
                    <tr id="trCableIR" runat="server">
                       <td>NO. OF CABLES</td>
                        <td></td>
                        <td><asp:Label ID="lblNoOfCables" runat="server" Width="75px"></asp:Label></td>
                        <td colspan="6"></td>
                    </tr>
                    <tr>
                        <td>CABLE IR AND HI POT</td>
                        <td class="tdstyle1">N/A
                           <input id="chkCableIR" type="checkbox" style="vertical-align:middle"   onclick="_checked('chkCableIR','txtCableIR')" runat="server"/></td>
                        <td >
                            <asp:TextBox ID="txtCableIR" runat="server" Width="75px"></asp:TextBox>
                        </td>                        
                        
                        <td>TERMINATION TORQUE TEST</td>
                        <td class="tdstyle1">N/A
                           <input id="chkTerTorTest" type="checkbox" style="vertical-align:middle"   onclick="_checked('chkTerTorTest','txtTerTorTest')" runat="server"/></td>
                        <td >
                            <asp:TextBox ID="txtTerTorTest" runat="server" Width="75px"></asp:TextBox>
                        </td> 
                    
                        <td>CABLE TEST COMPLETE</td>
                        <td class="tdstyle1">N/A
                           <input id="chkCableTestComplete" type="checkbox" style="vertical-align:middle"   onclick="_checked('chkCableTestComplete','txtCableTestComplete')" runat="server"/></td>
                        <td >
                            <asp:TextBox ID="txtCableTestComplete" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="ceCableTestComplete" runat="server" ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txtCableTestComplete"  TargetControlID="txtCableTestComplete"></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                           <input id="chkConsAccepted2" type="checkbox" style="vertical-align:middle"   onclick="_checked('chkConsAccepted2','txtConsAccepted2')" runat="server"/></td>
                        <td >
                            <asp:TextBox ID="txtConsAccepted2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="ceConsAccepted2" runat="server" ClearTime="true" PopupPosition="TopRight" Format="dd/MM/yyyy" PopupButtonID="txtConsAccepted2"  TargetControlID="txtConsAccepted2"></asp:CalendarExtender>
                        </td>
                        <td >TEST SHEETS FILED</td>
                        <td class="tdstyle1">N/A
                            <input id="chkTestSheetFiled2" type="checkbox" style="vertical-align:middle"   onclick="_checked('chkTestSheetFiled2','txtTestSheetFiled2')" runat="server"/></td>
                        <td >
                            <asp:TextBox ID="txtTestSheetFiled2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="ceTestSheetFiled2" runat="server" ClearTime="true" PopupPosition="TopRight" Format="dd/MM/yyyy" PopupButtonID="txtTestSheetFiled2" TargetControlID="txtTestSheetFiled2"></asp:CalendarExtender>
                        </td>
                        <td >&nbsp;</td>
                        <td class="tdstyle1">&nbsp;</td>
                        <td >&nbsp;</td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="9" align="center">FINAL TEST SHEETS</td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>CONSULTANT ACCEPTED</td>
                        <td class="tdstyle1">N/A
                          <input id="chkConsAccepted3" type="checkbox" style="vertical-align:middle" onclick="_checked('chkConsAccepted3','txtConsAccepted3')" runat="server"/></td>
                        <td>
                             <asp:TextBox ID="txtConsAccepted3" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="cetxtConsAccepted3" runat="server" ClearTime="true" PopupPosition="TopRight" Format="dd/MM/yyyy" PopupButtonID="txtConsAccepted3"  TargetControlID="txtConsAccepted3"></asp:CalendarExtender>
                        </td>
                        <td>TEST SHEETS FILED</td>
                         <td class="tdstyle1">N/A
                            <input id="chkTestSheetFiled3" type="checkbox" style="vertical-align:middle"   onclick="_checked('chkTestSheetFiled3','txtTestSheetFiled3')" runat="server"/></td>
                        <td >
                           <asp:TextBox ID="txtTestSheetFiled3" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="ceTestSheetFiled3" runat="server" ClearTime="true" PopupPosition="TopRight" Format="dd/MM/yyyy" PopupButtonID="txtTestSheetFiled3" TargetControlID="txtTestSheetFiled3"></asp:CalendarExtender>
                        </td> 
                        <td colspan="3"></td>
                    </tr>
                     <tr style="background-color:#83C8EE" >
                        <td>ACTION BY&nbsp;</td>
                        <td class="tdstyle1">N/A
                          <input id="chkActionBy" type="checkbox" style="vertical-align:middle"   onclick="_checked('chkActionBy','txtActionBy')" runat="server"/></td>
                        <td colspan="2">
                            <asp:TextBox ID="txtActionBy" runat="server" Width="250px"></asp:TextBox>
                        </td>
                        <td class="tdstyle1">&nbsp;</td>
                        <td>COMMENTS</td>
                        <td colspan="3" rowspan="2">
                            <asp:TextBox ID="txtComments" runat="server" Height="50px" Font-Names="Verdana" TextMode="MultiLine" Width="97%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>ACTION DATE</td>
                        <td class="tdstyle1">N/A
                          <input id="chkActionDate" type="checkbox" style="vertical-align:middle"   onclick="_checked('chkActionDate','txtActionDate')" runat="server"/></td>
                        <td>
                            <asp:TextBox ID="txtActionDate" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="ceActionDate" runat="server" ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txtActionDate" TargetControlID="txtActionDate"></asp:CalendarExtender>
                        </td>
                        <td>&nbsp;</td>
                        <td class="tdstyle1"> &nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                        <td align="center">
                        <asp:UpdatePanel ID="upMVTestDataUpdate" runat="server">
                          <ContentTemplate>
                            <asp:Button ID="btnMVTestDataUpdate" runat="server" Text="Update" onclick="btnMVTestDataUpdate_Click" />
                          </ContentTemplate>
                        </asp:UpdatePanel>    
                        </td>
                        <td align="left">
                        <asp:UpdatePanel ID="upMVTestDataCancel" runat="server">
                            <ContentTemplate>
                            <asp:Button ID="btnMVTestDataCancel" runat="server" Text="Cancel" onclick="btnMVTestDataCancel_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </td>
                        <td  colspan="5"></td>
                    </tr>
                </table>
            </ContentTemplate>
            </asp:UpdatePanel>
                <div id="dvInputDataProgress" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
            <asp:UpdateProgress ID="UpdateProgMVTestData" runat="server" >
                <ProgressTemplate><asp:Image ID="imgUpdateMVTestProgress" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" /></ProgressTemplate>
           </asp:UpdateProgress>
        </div> 
            </div>
        </asp:Panel>
        <asp:Button ID="btnMVTestDataInput" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="ModalPopupExtender_MVTestDataInput" runat="server" TargetControlID="btnMVTestDataInput"  PopupControlID="pnlMVTestDataInput" 
        X="0" Y="0" BackgroundCssClass="modal" ></asp:ModalPopupExtender>


           <asp:Panel ID="pnlPopup_25SRH" runat="server" Width="825px" Height="205px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel46" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_25slbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            CONTINUITY/IR TEST</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_25scit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            ADDRESSING/PROGRAMMING TEST</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_25sapt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            FAULT &amp; ALARM TEST</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_25sfat" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            POWER FAILURE TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_25spft" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            <asp:TextBox ID="_25snoof" runat="server" Width="75px" style="display:none"></asp:TextBox>
                            INTERFACE TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_25sit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            PC HEADEND/GRAPHIC TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_25sphgt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td >
                           
                            <asp:TextBox ID="_25saccept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender236" runat="server" 
                        TargetControlID="_25saccept1" PopupButtonID="_25saccept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_25sfiled1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender237" runat="server" 
                        TargetControlID="_25sfiled1" PopupButtonID="_25sfiled1" ClearTime="true" 
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
                        <td colspan="2">
                            
                            <asp:TextBox ID="_25sactby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_25scommts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_25sactdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender238" runat="server" 
                        TargetControlID="_25sactdt" PopupButtonID="_25sactdt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_25sbtnupdate" runat="server" Text="Update" 
                                onclick="_25sbtnupdate_Click"  />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_25sbtncancel" runat="server" Text="Cancel" 
                                onclick="_25sbtncancel_Click"   />
                        </td>
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
                 <div id="Div25srh" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress36" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload25_SRH" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>

         <asp:Button ID="btn25SRH" runat="server" Text="Button" style="display:none;"  />      
        <asp:ModalPopupExtender ID="ModalPopupExtender_25SRH" runat="server" TargetControlID="btn25SRH"  PopupControlID="pnlPopup_25SRH" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
        
        
         <asp:Panel ID="pnlPopup_26SRH" runat="server" Width="825px" Height="205px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel47" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_26slbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            CONTINUITY/IR TEST</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_26scit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            DEVICE TEST</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_26sdvt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            ADDRESSING / PROGRAMMING TEST</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_26sapt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                          FAULT & ALARM TESTS</td>
                        <td width="75PX">
                            <asp:TextBox ID="_26sfst" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            <asp:TextBox ID="_26snoof" runat="server" Width="75px" style="display:none"></asp:TextBox>
                            INTERFACE TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_26sit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            PC HEADEND/GRAPHIC TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_26sphgt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td >
                           
                            <asp:TextBox ID="_26saccept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender239" runat="server" 
                        TargetControlID="_26saccept1" PopupButtonID="_26saccept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_26sfiled1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender240" runat="server" 
                        TargetControlID="_26sfiled1" PopupButtonID="_26sfiled1" ClearTime="true" 
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
                        <td colspan="2">
                            
                            <asp:TextBox ID="_26sactby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_26scommts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_26sactdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender241" runat="server" 
                        TargetControlID="_26sactdt" PopupButtonID="_26sactdt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_26sbtnupdate" runat="server" Text="Update" 
                                onclick="_26sbtnupdate_Click"  />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_26sbtncancel" runat="server" Text="Cancel" 
                                onclick="_26sbtncancel_Click"   />
                        </td>
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
                 <div id="Div27" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress37" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload26_SRH" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>

         <asp:Button ID="btn26SRH" runat="server" Text="Button" style="display:none;"  />      
        <asp:ModalPopupExtender ID="ModalPopupExtender_26SRH" runat="server" TargetControlID="btn26SRH"  PopupControlID="pnlPopup_26SRH" BackgroundCssClass="modal"></asp:ModalPopupExtender> 

    </div>
    <asp:CheckBox ID="CheckBox1" runat="server" />
    <asp:CheckBox ID="CheckBox2" runat="server" />
    </form>
</body>
</html>
