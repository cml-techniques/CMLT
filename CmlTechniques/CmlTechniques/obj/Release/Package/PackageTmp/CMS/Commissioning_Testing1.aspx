<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Commissioning_Testing1.aspx.cs" Inherits="CmlTechniques.CMS.Commissioning_Testing1" %>

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
        <td style="background-color: #D2F1FC" >
            <asp:Label ID="lblhead" runat="server" Font-Bold="True" Font-Size="Small" 
                ForeColor="Black" Text="CAS MISC1 System Integration Tests Commissioning Activity Schedule"></asp:Label>
            </td>
        </tr>
        </table>
        <div style="float:left;width:98.5%">
        <table style="font-family: Verdana;font-size:x-small;background-color:#9EB6CE;" cellspacing="1" border="0" width="100%">
       <tr  style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
       
                            <td align="center" rowspan="2" valign="middle"   width="5%">
                                &nbsp;</td>       
                            <td align="center" rowspan="2" valign="middle"   width="5%">
                                ITEM NO</td>
       
                            <td align="center" rowspan="2" valign="middle"   width="10%">
                                ENG.REF</td>
                            <td align="center" colspan="3" valign="middle"  >
                                SYSTEM1</td>
                            <td align="center" colspan="3" valign="middle"  >
                                SYSTEM2</td>
                            <td align="center" colspan="3" valign="middle"  >
                                SYSTEM3</td>
                            <td align="center" valign="middle" rowspan="2" width="7%"  >
                                NUMBER OF INTERFACE POINTS</td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td align="center" valign="middle"  width="7%"  >
                                SERVER/ PLC LOCATION</td>
                            <td align="center" valign="middle" width="7%"  >
                                OPERATION VIEWING LOCATION</td>
                            <td align="center" valign="middle" width="7%"  >
                                SYSTEM NAME</td>
                            <td align="center" valign="middle" width="7%"  >
                                SERVER/PLC LOCATION</td>
                            <td align="center" valign="middle" width="7%"  >
                                OPERATION VIEWING LOCATION</td>
                            <td align="center" valign="middle" width="7%"  >
                                SYSTEM NAME</td>
                            <td align="center" valign="middle" width="7%"  >
                                SERVER/ PLC LOCATION</td>
                            <td align="center" valign="middle" width="7%"  >
                                OPERATION VIEWING LOCATION</td>
                            <td align="center" valign="middle" width="7%"  >
                                SYSTEM NAME</td>
                        </tr>
        <tr bgcolor="#092443" >
            <td>
             
                 &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
                        </table>
        </div>
        <div style="position:relative; height:67%;width:100%;overflow-y:scroll;float:left;">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            
                <asp:GridView ID="mydetails" runat="server" ShowHeader="false" AutoGenerateColumns="false" Width="100%" OnRowCommand="mydetails_RowCommand" OnRowDataBound="mydetails_RowDataBound" Font-Names="Verdana" 
                    Font-Size="X-Small" >
                <Columns>
                
                <asp:ButtonField ButtonType="Button" Text="Update" CommandName="Get"
                        ItemStyle-Width="5%" >
                    <ItemStyle Width="5%"  />
                    </asp:ButtonField>
               <%-- <asp:TemplateField >
                <ItemTemplate>
                    <asp:CheckBox ID="chkrow" runat="server" OnCheckedChanged="chkrow_CheckedChanged" AutoPostBack="true" />
                </ItemTemplate>
                <ItemStyle Width="5%" HorizontalAlign="Center"  />
                </asp:TemplateField>--%>    
                
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
                    <asp:BoundField DataField="Des" HeaderText="Substation" 
                        ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Loc" HeaderText="Location" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="P_P_to" HeaderText="Provides Power To" 
                        ItemStyle-Width="7" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                  <asp:BoundField DataField="F_from" HeaderText="Fed From" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>     
                <asp:BoundField DataField="Substation" HeaderText="Substation" 
                        ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="S_c_m" HeaderText="Substation" 
                        ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="devices1" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="C_id" />
                </Columns>
                </asp:GridView>
           
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="myprogress" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div>
        <asp:Panel ID="pnlPopup" runat="server" Width="825px" Height="260px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel39" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_33lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            INTERFACE PLANNED READY DATE</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_33ipr" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender201" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_33ipr" 
                                TargetControlID="_33ipr">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            INTERFACE TYPE</td>
                        <td colspan="2" style="width: 275px" >
                            <asp:TextBox ID="_33itype" runat="server" Width="275px"></asp:TextBox>
                        </td>
                        <td width="75PX" >
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#092443;color:White">
                        <td colspan="6" align="center">
                            Interface Ready Dates</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            SYSTEM 1</td>
                        <td width="75PX">
                            <asp:TextBox ID="_33s1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender209" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_33s1" 
                                TargetControlID="_33s1">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">SYSTEM 2</td>
                        <td width="75PX">
                            <asp:TextBox ID="_33s2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_33s2_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_33s2" 
                                TargetControlID="_33s2">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">SYSTEM 3</td>
                        <td width="75PX">
                            <asp:TextBox ID="_33s3" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_33s3_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_33s3" 
                                TargetControlID="_33s3">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">READY TO TEST</td> 
                        <td width="75PX">
                            <asp:DropDownList ID="dr_ready" runat="server" Width="100%">
                            <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                            <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="200PX">
                            INTERFACE TEST COMPLETE (SYSTEM 1)</td>
                        <td width="75PX">
                            <asp:TextBox ID="_33itc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_33itc_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_33itc" 
                                TargetControlID="_33itc">
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
                           
                            <asp:TextBox ID="_33accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender210" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_33accept1" 
                                TargetControlID="_33accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_33filed1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender211" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_33filed1" 
                                TargetControlID="_33filed1">
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
                            
                            <asp:TextBox ID="_33actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_33commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_33actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender212" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_33actdt" 
                                TargetControlID="_33actdt">
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
                           <asp:Button ID="_33btnupdate" runat="server" Text="Update" 
                                onclick="_33btnupdate_Click"  />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_33btncancel" runat="server" Text="Cancel" 
                                onclick="_33btncancel_Click"   />
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
        <asp:Button ID="btnDummy" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" TargetControlID="btnDummy"  PopupControlID="pnlPopup" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
           
    </div>
    </form>
</body>
</html>
