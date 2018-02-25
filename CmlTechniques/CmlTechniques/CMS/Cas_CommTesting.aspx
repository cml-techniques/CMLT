<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cas_CommTesting.aspx.cs" Inherits="CmlTechniques.CMS.Cas_CommTesting" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
     <link href="../page.css" rel="stylesheet" type="text/css" />
     <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" />
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
                            <td align="center" rowspan="2" valign="middle" width="10%" >
                                <asp:Label ID="lbloc" runat="server" Text="LOCATION"></asp:Label>
                            </td>
                            <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbl1" runat="server" >
                                <asp:Label ID="lbl1" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbl3" runat="server" >
                                <asp:Label ID="lbl3" runat="server"></asp:Label></td>
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
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
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
            <td>
                &nbsp;</td>
            <td id="td_0" runat="server">
                &nbsp;</td>
            <td id="td_1" runat="server">
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drfed" runat="server" Width="100%" OnSelectedIndexChanged="drfed_SelectedIndexChanged" AutoPostBack="true"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td id="td_2" runat="server">
                &nbsp;</td>
            <td id="td_3" runat="server">
                &nbsp;</td>
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
                <asp:BoundField DataField="Loc" HeaderText="Location" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="P_P_to" HeaderText="Provides Power To" 
                        ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="F_from" HeaderText="Fed From" ItemStyle-Width="10%" >
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
        <asp:Panel ID="pnlPopup" runat="server" Width="950px" Height="375px" style="padding:5px;" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                
                <table style="width:100%" border="0" cellpadding="3" cellspacing="1" >
                <tr>
                <td width="150">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
                <td width="150">
                <asp:TextBox ID="txtppon" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="txtppon" PopupButtonID="txtppon" ClearTime="true" 
                        Format="dd/MM/yy" ></asp:CalendarExtender>
                </td>
                    <td width="150">
                        &nbsp;</td>
                    <td width="150">
                        &nbsp;</td>
                <td width="150">
                </td>
                <td width="150"></td>
                </tr>
                
                    <tr style="background-color:#5D7B9D;color:White">
                        <td colspan="2"  align="center">
                            <asp:Label ID="testhead1" runat="server" Text=""></asp:Label></td>
                        <td align="center" colspan="2">
                            <asp:Label ID="testhead3" runat="server" Text=""></asp:Label>
                        </td>
                        <td colspan="2"  align="center" >
                            <asp:Label ID="testhead2" runat="server" Text=""></asp:Label></td>
                    </tr>
                
                    <tr id="tr1" runat="server">
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="test1" runat="server" Width="100px" 
                                ></asp:TextBox>
                            <asp:CalendarExtender ID="date2_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="test1" 
                                TargetControlID="test1">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="test7" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date15_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="test7" 
                                TargetControlID="test7">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #90B3CF">
                            <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #90B3CF">
                            <asp:TextBox ID="txtdevices1" runat="server" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr2" runat="server">
                        <td style="background-color: #BCDCFD" >
                            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD" >
                            <asp:TextBox ID="test2" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="test2_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="test2" 
                                TargetControlID="test2">
                            </asp:CalendarExtender>
                            </td>
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label16" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="test8" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date16_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="test8" 
                                TargetControlID="test8">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #90B3CF" >
                            <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                            </td>
                        <td style="background-color: #90B3CF" >
                            <asp:TextBox ID="notested1" runat="server" Width="100px"></asp:TextBox>
                            </td>
                    </tr>
                    <tr id="tr3" runat="server">
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="test3" runat="server" Width="100px" 
                                ></asp:TextBox>
                            <asp:CalendarExtender ID="date4_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="test3" 
                                TargetControlID="test3">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label22" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="test10" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date14_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="test10" 
                                TargetControlID="test10">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #90B3CF">
                            <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #90B3CF">
                            <asp:TextBox ID="testcomp1" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date10_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="testcomp1" 
                                TargetControlID="testcomp1">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr id="tr4" runat="server">
                        <td style="background-color: #BCDCFD" >
                            <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD" >
                            <asp:TextBox ID="test4" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date5_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="test4" 
                                TargetControlID="test4">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label23" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="test11" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date18_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="test11" 
                                TargetControlID="test11">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #90B3CF" >
                            <asp:Label ID="Label12" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #90B3CF" >
                            <asp:TextBox ID="notested2" runat="server" Width="100px"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr id="tr5" runat="server">
                        <td style="background-color: #BCDCFD" >
                           <asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
                        <td  style="background-color: #BCDCFD">
                            <asp:TextBox ID="test5" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date6_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="test5" 
                                TargetControlID="test5">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label24" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="test12" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="test12_CalendarExtender0" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="test12" 
                                TargetControlID="test12">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #90B3CF" >
                            <asp:Label ID="Label13" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #90B3CF" >
                            <asp:TextBox ID="testcomp2" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date12_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="testcomp2" 
                                TargetControlID="testcomp2">
                            </asp:CalendarExtender>
                            </td>
                    </tr>
                    <tr id="tr6" runat="server">
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label7" runat="server" Text=""></asp:Label></td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="test6" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date7_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="test6" 
                                TargetControlID="test6">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #BCDCFD">
                            &nbsp;</td>
                        <td style="background-color: #BCDCFD">
                            &nbsp;</td>
                        <td style="background-color: #90B3CF">
                            <asp:Label ID="Label14" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #90B3CF">
                            <asp:TextBox ID="test9" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date13_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="test9" 
                                TargetControlID="test9">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr id="tr7" runat="server">
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label25" runat="server" Text="Consultant Accepted"></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="conaccept3" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="conaccept3_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="conaccept1" 
                                TargetControlID="conaccept3">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label27" runat="server" Text="Consultant Accepted"></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="conaccept1" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="test12_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="conaccept1" 
                                TargetControlID="conaccept1">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #90B3CF">
                            <asp:Label ID="Label19" runat="server" Text="Consultant Accepted"></asp:Label>
                        </td>
                        <td style="background-color: #90B3CF">
                            <asp:TextBox ID="conaccept2" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="test13_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="conaccept2" 
                                TargetControlID="conaccept2">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr id="tr8" runat="server">
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label26" runat="server" Text="Test Sheets Filed"></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="txtfiled2" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="txtfiled2_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="txtfiled1" 
                                TargetControlID="txtfiled2">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label28" runat="server" Text="Test Sheet Filed"></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="txtfiled1" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtendertxt" runat="server" ClearTime="true" 
                                Format="dd/MM/yy" PopupButtonID="txtfiled1" TargetControlID="txtfiled1">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #90B3CF">
                            <asp:Label ID="Label21" runat="server" Text="Test Sheet Filed"></asp:Label>
                        </td>
                        <td style="background-color: #90B3CF">
                            <asp:TextBox ID="txtfiled" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="actdate0_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="txtfiled" 
                                TargetControlID="txtfiled">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr id="tr9" runat="server">
                        <td >
                            Action By</td>
                        <td align="left" >
                            <asp:TextBox ID="actby" runat="server" Width="100px"></asp:TextBox>
                            
                        </td>
                        <td align="left" >
                            Comments</td>
                        <td align="left" colspan="3" rowspan="2" >
                            <%--<asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>--%><asp:TextBox ID="txtcomment" runat="server" Height="40px" 
                                TextMode="MultiLine" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            Action Date</td>
                        <td align="left">
                            <asp:TextBox ID="actdate" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date22_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="actdate" 
                                TargetControlID="actdate">
                            </asp:CalendarExtender>
                        </td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                            <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>--%><asp:Button ID="btnupdate" runat="server" 
                                onclick="btnupdate_Click" Text="Update" />
                            <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </td>
                        <td align="right">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                            <%--<asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>--%>
                            <asp:Button ID="btncancel" runat="server" onclick="btncancel_Click" 
                                Text="Cancel" />
                            <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                </table>
             </ContentTemplate>
                </asp:UpdatePanel>
            </div>
                        
                  </asp:Panel>
                  
                    <asp:Button ID="btnDummy" runat="server" Text="Button" style="display:none;"  />
                  <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" 
                  TargetControlID="btnDummy"  PopupControlID="pnlPopup"
                  BackgroundCssClass="modal"
                  DropShadow="true">
                  </asp:ModalPopupExtender> 
    </div>
    </form>
</body>
</html>
