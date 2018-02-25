<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Commissioning.aspx.cs" Inherits="CmlTechniques.CAS.Commissioning" %>

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
        <td width="100px" style="background-color: #D2F1FC" >
            <asp:Label ID="lblhead" runat="server" Font-Bold="True" Font-Size="Small" 
                ForeColor="Black"></asp:Label><asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label><asp:Label ID="lblsch" runat="server" Text="" style="display:none"></asp:Label>
            </td>
        </tr>
        </table>
        <div style="float:left;width:98.5%">
        <table style="font-family: Verdana;font-size:x-small;background-color:#9EB6CE;width:100%;" cellspacing="1" border="0">
       <tr  style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
       
                            <td align="center" rowspan="2" valign="middle"   width="5%">
                                &nbsp;</td>       
                            <td align="center" rowspan="2" valign="middle"   width="5%">
                                ITEM NO</td>
       
                            <td align="center" rowspan="2" valign="middle"   width="10%">
                                ENG.REF</td>
                            <td align="center" colspan="4" valign="middle"  >
                                ASSET CODE</td>
                            <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbldes" runat="server" >
                                <asp:Label ID="lbdes" runat="server" Text="DESCRIPTION"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbl0" runat="server" >
                                <asp:Label ID="lbloc" runat="server" Text="LOCATION"></asp:Label>
                            </td>
                            <td align="center" rowspan="2" valign="middle" width="9%" id="td_lbl3" runat="server" >
                                <asp:Label ID="lbl3" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="9%" id="td_lbl1" runat="server" >
                                <asp:Label ID="lbl1" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="9%" id="td_lbl2" runat="server" >
                                <asp:Label ID="lbl2" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="9%" id="td_lbnum" runat="server" >
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
             
                 <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                 <ContentTemplate>
                 <asp:Button ID="btnexpand" runat="server" Text="Exp.All" Width="94%"
                  ForeColor="Red" Font-Size="X-Small" style="cursor:pointer" onclick="btnexpand_Click" />
                 </ContentTemplate>
                 </asp:UpdatePanel>
                
             </td>
            <td>
              <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                 <ContentTemplate>
                 <asp:Button ID="btncollapse" runat="server" Text="Coll.All" Width="94%" 
                         ForeColor="Red" Font-Size="X-Small" style="cursor:pointer" onclick="btncollapse_Click" />
                 </ContentTemplate>
                 </asp:UpdatePanel></td>
            <td>
                &nbsp;</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drbuilding" runat="server" Width="100%" >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                 
            </td>
            <td>
           <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drcategory" runat="server" Width="100%"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
               </td>
            <td>
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drflevel" runat="server" Width="100%"   >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td>
                &nbsp;</td>
            <td id="tddes" runat="server">
            <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drdes" runat="server" Width="100%"   >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
            <td id="td0" runat="server">
            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drloc" runat="server" Width="100%"   >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
            <td id="td_1" runat="server">
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drfed" runat="server" Width="100%"   >
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
        <div style="position:relative; height:75%;width:100%;overflow-y:scroll;float:left;">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Repeater ID="reptr_main" runat="server" 
                    onitemdatabound="reptr_main_ItemDataBound" 
                    ondatabinding="reptr_main_DataBinding"  >
                <ItemTemplate>
                <table style="width:100%" border="0" cellpadding="0" cellspacing="0">
                <tr style="background-color:#DFF6FC;height:30px;font-size:small;font-weight:bold;background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                <td style="width:30px">
                    <asp:Button ID="btnexpd" runat="server" Text="+" Width="30px" style="border:none;cursor:pointer" OnClick="btnexpd_Click" /></td>
                <td style="padding-left:10px;width:100%">
                    <asp:Label ID="lbl_panelP" runat="server" Text='<%# Eval("Panel_Ref") %>'></asp:Label><asp:Label ID="lbl_panelPid" runat="server" Text='<%# Eval("Panel_Id") %>' style="display:none"></asp:Label></td>
                </tr>
                <tr>
                <td colspan="2" style="width:100%;margin:0;padding:0">
                
                    <asp:GridView ID="details" runat="server" Width="100%" ShowHeader="false" AutoGenerateColumns="false" Font-Names="Verdana" 
                    Font-Size="X-Small" OnRowDataBound="details_RowDataBound" BorderStyle="None" CellPadding="0" CellSpacing="0">
                    <Columns>
                    <asp:TemplateField>
                    <ItemTemplate>
                    <asp:Label ID="lblpanel" runat="server" Text='<%# Eval("Panel_id") %>' style="display:none"></asp:Label>
                    <asp:GridView ID="inner1" runat="server" Width="100%" ShowHeader="false" AutoGenerateColumns="false" Font-Names="Verdana" 
                    Font-Size="X-Small" CellPadding="0" CellSpacing="0" OnRowDataBound="mydetails_RowDataBound" OnRowCommand="inner1_RowCommand" >
                    <Columns>
                
                <%--<asp:ButtonField ButtonType="Button" Text="Update" CommandName="Get"
                        ItemStyle-Width="6%" >
                    <ItemStyle Width="6%"  />
                    </asp:ButtonField>--%>
                <asp:ButtonField ButtonType="Button" Text="Update" CommandName="Get"
                        ItemStyle-Width="5%" >
                    <ItemStyle Width="5%"   />
                    <ControlStyle Width="100%"  />
                    </asp:ButtonField>    
                
                <asp:BoundField HeaderText="Itm.No" ItemStyle-Width="5%" >
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
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
                <asp:BoundField DataField="F_from" HeaderText="Fed From" ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>    
                <asp:BoundField DataField="P_P_to" HeaderText="Provides Power To" 
                        ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Substation" HeaderText="Substation" 
                        ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="devices1" ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="C_id" />
                <asp:BoundField DataField="Sys_Id" />
                <asp:BoundField DataField="Sys_Name" />
                </Columns>
                    </asp:GridView>
                    <asp:GridView ID="inner_sub" runat="server" Width="100%" ShowHeader="false" AutoGenerateColumns="false" Font-Names="Verdana" 
                    Font-Size="X-Small" OnRowDataBound="inner_sub_RowDataBound" CellPadding="0" CellSpacing="0" BorderStyle="None">
                    <Columns>
                    <asp:TemplateField>
                    <ItemTemplate>
                    <table style="width:100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="background-color:#CCCCCC;height:20px;font-size:small;font-weight:bold;" >
                    <td style="padding-left:10px"><asp:Label ID="lbl_panelC" runat="server" Text='<%# Eval("Panel_Ref") %>'></asp:Label><asp:Label ID="lbl_panelCid" runat="server" Text='<%# Eval("Panel_Id") %>' style="display:none"></asp:Label></td>
                    </tr>
                    <tr>
                    <td style="width:100%">
                    <asp:GridView ID="inner2" runat="server" Width="100%" ShowHeader="false" AutoGenerateColumns="false" Font-Names="Verdana" 
                    Font-Size="X-Small" CellPadding="0" CellSpacing="0" OnRowDataBound="mydetails_RowDataBound" OnRowCommand="inner2_RowCommand">
                    <Columns>
                
                <%--<asp:ButtonField ButtonType="Button" Text="Update" CommandName="Get"
                        ItemStyle-Width="6%" >
                    <ItemStyle Width="6%"  />
                    </asp:ButtonField>--%>
                <asp:ButtonField ButtonType="Button" Text="Update" CommandName="Get"
                        ItemStyle-Width="5%"  >
                    <ItemStyle Width="5%"   />
                    <ControlStyle Width="100%" />
                    </asp:ButtonField>   
                
                <asp:BoundField HeaderText="Itm.No" ItemStyle-Width="5%" >
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
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
                <asp:BoundField DataField="F_from" HeaderText="Fed From" ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>    
                <asp:BoundField DataField="P_P_to" HeaderText="Provides Power To" 
                        ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Substation" HeaderText="Substation" 
                        ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="devices1" ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="C_id" />
                <asp:BoundField DataField="Sys_Id" />
                <asp:BoundField DataField="Sys_Name" />
                </Columns>
                    </asp:GridView>
                    </td>
                    </tr>
                    </table>
                    </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                    </asp:GridView>
                    
                    </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                    </asp:GridView>
                    
                 
                </td>
                </tr>
                </table>
                </ItemTemplate>
                </asp:Repeater>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="myprogress" runat="server" style="position:absolute; z-index:40;top:40%;left: 45%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading45.gif" Height="100px" Width="100px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                OldValuesParameterFormatString="original_{0}" 
                onselecting="ObjectDataSource1_Selecting" SelectMethod="GetData" 
                
                TypeName="CmlTechniques.CAS.ccad_casTableAdapters.Load_Cassheet_dataTableAdapter">
            <SelectParameters>
                <asp:Parameter Name="sch_id" Type="Int32" />
                <asp:Parameter Name="prj_code" Type="String" />
            </SelectParameters>
            </asp:ObjectDataSource> 
       <asp:Panel ID="pnlPopup13" runat="server" Width="825px" Height="325px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_10lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            NO.OF DEVICES</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_10dvc" runat="server" Width="75px" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            NO.OF CABLE TESTED</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_10nct" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            DATE TESTED</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_10ctd" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender110" runat="server" 
                        TargetControlID="_10ctd" PopupButtonID="_10ctd" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            NO.OF DEVICES TESTED</td>
                        <td width="75PX">
                            <asp:TextBox ID="_10ndt" runat="server" Width="75px"></asp:TextBox>
                       </td>
                        <td width="200PX">
                            DEVICE TEST COMPLETE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_10ddt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender115" runat="server" 
                        TargetControlID="_10ddt" PopupButtonID="_10ddt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            <asp:TextBox ID="_10devices" runat="server" Width="75px" style="display:none"></asp:TextBox>
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_10interface" runat="server" Width="75px" style="display:none"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            NO.OF INTERFACES</td>
                        <td width="75PX">
                            <asp:TextBox ID="_10itf" runat="server" Width="75px" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            FA INTERFACE TESTED</td>
                        <td width="75PX">
                            <asp:TextBox ID="_10fat" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            BATTERY AUTONOMY TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_10bat" runat="server" Width="75px"></asp:TextBox>
                            
                        </td>
                        <td width="200PX">
                            GRAPHICS/HEAD END TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_10ghet" runat="server" Width="75px"></asp:TextBox>
                            
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
                           
                            <asp:TextBox ID="_10accept1" runat="server" Width="75px"></asp:TextBox>
                          <asp:CalendarExtender ID="CalendarExtender112" runat="server" 
                        TargetControlID="_10accept1" PopupButtonID="_10accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_10filed1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender113" runat="server" 
                        TargetControlID="_10filed1" PopupButtonID="_10filed1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            INSTALLATION COMPLETION SIGN OFF [KEO]</td>
                        <td>
                            <asp:TextBox ID="_10icom" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_10icom_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_10icom" 
                                TargetControlID="_10icom">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            PFT COMPLETION SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_10pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_10pft_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_10pft" 
                                TargetControlID="_10pft">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ENERGISATION/PROGRAMMING</td>
                        <td>
                            <asp:TextBox ID="_10eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_10eng_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_10eng" 
                                TargetControlID="_10eng">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            FPT SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_10fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_10fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_10fpt" 
                                TargetControlID="_10fpt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ACCEPTANCE RECOMMENDATION MADE</td>
                        <td>
                            <asp:TextBox ID="_10arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_10arm_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_10arm" 
                                TargetControlID="_10arm">
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
                            
                            <asp:TextBox ID="_10actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_10commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_10actdt" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender114" runat="server" 
                        TargetControlID="_10actdt" PopupButtonID="_10actdt" ClearTime="true" 
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
                           <asp:Button ID="_10btnupdate" runat="server" Text="Update" 
                                onclick="_10btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_10btncancel" runat="server" Text="Cancel" 
                                onclick="_10btncancel_Click" />
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
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender13" runat="server" TargetControlID="btnDummy13"  PopupControlID="pnlPopup13" BackgroundCssClass="modal"></asp:ModalPopupExtender>
        <asp:Panel ID="pnlPopup17" runat="server" Width="825px" Height="320px" 
                style="padding:15px;" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_11lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            NO.OF DEVICES PER CIRCUIT</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_11dvc" runat="server" Width="75px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            CIRCUIT IR TESTED</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_11cit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            NO.OF DEVICES TESTED</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_11ndt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            ZONES TESTS FOR BGM</td>
                        <td width="75PX">
                            <asp:TextBox ID="_11ztb" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender28" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_11ztb" 
                                TargetControlID="_11ztb">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            ZONES TESTS FOR TELEPHONE PAGING</td>
                        <td width="75PX">
                            <asp:TextBox ID="_11ztp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_11ztp_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_11ztp" 
                                TargetControlID="_11ztp">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            ZONES TESTS FOR SPL/STI LEVELS</td>
                        <td width="75PX">
                            <asp:TextBox ID="_11zsl" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_11zsl_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_11zsl" 
                                TargetControlID="_11zsl">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            ZONES TESTS FOR EMERGENCY OVERIDE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_11zeo" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_11zeo_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_11zeo" 
                                TargetControlID="_11zeo">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            ZONES TESTS FOR AUDIO INPUTS</td>
                        <td width="75PX">
                            <asp:TextBox ID="_11zai" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_11zai_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_11zai" 
                                TargetControlID="_11zai">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            BATTERY AUTONOMY TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_11bat" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_11bat_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_11bat" 
                                TargetControlID="_11bat">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            GRAPHICS TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_11grt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_11grt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_11grt" 
                                TargetControlID="_11grt">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            INTEGRATION/ INTERFACE TESTS</td>
                        <td width="75PX">
                            <asp:TextBox ID="_11iit" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_11iit_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_11iit" 
                                TargetControlID="_11iit">
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
                           
                            <asp:TextBox ID="_11accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender125" runat="server" 
                        TargetControlID="_11accept1" PopupButtonID="_11accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_11filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender132" runat="server" 
                        TargetControlID="_11filed1" PopupButtonID="_11filed1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            INSTALLATION COMPLETION SIGN OFF [KEO]</td>
                        <td>
                            <asp:TextBox ID="_11icom" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_11icom_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_11icom" 
                                TargetControlID="_11icom">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            PFT COMPLETION SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_11pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_11pft_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_11pft" 
                                TargetControlID="_11pft">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ENERGISATION/ PROGRAMMING DATE</td>
                        <td>
                            <asp:TextBox ID="_11eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_11eng_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_11eng" 
                                TargetControlID="_11eng">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            FPT SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_11fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_11fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_11fpt" 
                                TargetControlID="_11fpt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ACCEPTANCE RECOMMENDATIONS MADE</td>
                        <td>
                            <asp:TextBox ID="_11arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_11arm_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_11arm" 
                                TargetControlID="_11arm">
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
                            
                            <asp:TextBox ID="_11actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_11commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_11actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender133" runat="server" 
                        TargetControlID="_11actdt" PopupButtonID="_11actdt" ClearTime="true" 
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
                           <asp:Button ID="_11btnupdate" runat="server" Text="Update" 
                                onclick="_11btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_11btncancel" runat="server" Text="Cancel" 
                                onclick="_11btncancel_Click"  />
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
    </div>
    </form>
</body>
</html>
