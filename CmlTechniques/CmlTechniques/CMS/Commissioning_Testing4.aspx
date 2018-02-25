<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Commissioning_Testing4.aspx.cs" Inherits="CmlTechniques.CMS.Commissioning_Testing4" %>

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
        <asp:Label ID="lblprj" runat="server" Text="text" ForeColor="White" style="display:none"></asp:Label><asp:Label ID="lblsch" runat="server" Text="text" ForeColor="White" style="display:none"></asp:Label>
        <div style="float:left;width:98.5%">
        <table style="font-family: Verdana;font-size:x-small;background-color:#9EB6CE;width:100%" cellspacing="1" border="0">
       <tr  style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
       
                            <td align="center" rowspan="2" valign="middle"   width="6%">
                                &nbsp;</td>       
                            <td align="center" rowspan="2" valign="middle"   width="5%">
                                ITEM NO</td>
       
                            <td align="center" rowspan="2" valign="middle"   width="9%">
                                ENG.REF</td>
                            <td align="center" colspan="4" valign="middle"  >
                                ASSET CODE</td>
                            <td id="Td1" align="center" rowspan="2" valign="middle" width="6%"  
                                runat="server" >
                                <asp:Label ID="lbdes" runat="server" Text="AREA"></asp:Label></td>
                            <td id="Td2" align="center" rowspan="2" valign="middle" width="6%"  
                                runat="server" >
                                LOAD</td>
                            <td id="Td3" align="center" rowspan="2" valign="middle" width="6%" runat="server" >
                                STARTER TYPE</td>
                            <td id="Td4" align="center" rowspan="2" valign="middle" width="6%" runat="server" >
                                <asp:Label ID="lbl1" runat="server" Text="DUTY (volume/ US GPM)"></asp:Label></td>
                            <td id="Td5" align="center" rowspan="2" valign="middle" width="6%"  runat="server" >
                                DUTY (pressure)</td>
                            <td id="Td6" align="center" rowspan="2" valign="middle" width="9%"  runat="server" >
                                DESCRIPTION</td>
                            <td id="Td7" align="center" rowspan="2" valign="middle" width="9%"  runat="server" >
                                LOCATION</td>
                            <td id="Td8" align="center" rowspan="2" valign="middle" width="9%"  runat="server" >
                                FED FROM</td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td align="center" valign="middle"  width="6%"  >
                                BUILDING/ ZONE</td>
                            <td align="center" valign="middle" width="6%"  >
                                CATEGORY</td>
                            <td align="center" valign="middle" width="6%"  >
                                FLOOR LEVEL</td>
                            <td align="center" valign="middle" width="6%"  >
              SEQ.NO</td>
                        </tr>
        <tr bgcolor="#092443" >
            <td>
             
                 <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                 <ContentTemplate>
                 <asp:Button ID="btnexpand" runat="server" Text="Exp.All" Width="94%"
                         onclick="btnexpand_Click" ForeColor="Red" Font-Size="X-Small" style="cursor:pointer" />
                 </ContentTemplate>
                 </asp:UpdatePanel>
                
             </td>
            <td>
              <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                 <ContentTemplate>
                 <asp:Button ID="btncollapse" runat="server" Text="Coll.All" Width="94%" 
                         ForeColor="Red" Font-Size="X-Small" style="cursor:pointer" 
                         onclick="btncollapse_Click" />
                 </ContentTemplate>
                 </asp:UpdatePanel></td>
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
            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drloc" runat="server" Width="100%" AutoPostBack="true" 
                        onselectedindexchanged="drloc_SelectedIndexChanged"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
            <td >
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drfed" runat="server" Width="100%" OnSelectedIndexChanged="drfed_SelectedIndexChanged" AutoPostBack="true"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
            <td >
                &nbsp;</td>
            <td id="td0" runat="server">
            <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drdes" runat="server" Width="100%" AutoPostBack="true" 
                        onselectedindexchanged="drdes_SelectedIndexChanged"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
        </tr>
                        </table>
        </div>
        <div style="position:relative; height:75%;overflow-y:scroll;float:left;width:100%; top: 0px; left: 0px;">
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
                    <ItemStyle Width="6%"   />
                    <ControlStyle Width="95%"  />
                    </asp:ButtonField>
                
                <asp:BoundField HeaderText="Itm.No" ItemStyle-Width="5%" >
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField ="E_b_ref" HeaderText="Engg.Reff" ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>
                 <asp:BoundField DataField="B_Z" HeaderText="Building/Zone" ItemStyle-Width="6%" >
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                    </asp:BoundField>  
                <asp:BoundField DataField="cat" HeaderText="Category" ItemStyle-Width="6%" >
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                    </asp:BoundField>
                 
                <asp:BoundField DataField="F_lvl" HeaderText="Floor Level" ItemStyle-Width="6%" >
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Seq_No" HeaderText="Seq.No" ItemStyle-Width="6%" >
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="P_p_to" HeaderText="Location" ItemStyle-Width="6%" >
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Substation" HeaderText="Provides Power To" 
                        ItemStyle-Width="6%" >
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="S_c_m" HeaderText="Fed From" ItemStyle-Width="6%" >
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                    </asp:BoundField>    
                <asp:BoundField DataField="devices1" HeaderText="Fed From" ItemStyle-Width="6%" >
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="devices2" HeaderText="Fed From" ItemStyle-Width="6%" >
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Des" HeaderText="" 
                        ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>    
                <asp:BoundField DataField="Loc" HeaderText="" 
                        ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="F_from" ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
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
        <div id="myprogress" runat="server" 
                 style="position:absolute; z-index:40;top:30%; left:35%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
        
         <asp:Panel ID="pnlPopup1" runat="server" Width="825px" Height="370px" style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_18lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                <tr>
                <td colspan="6" style="background-color: #092443;color:#fff" align="center" >
                    ROOM INTEGRITY REST</td>
                </tr>
                    <tr id="tr1" runat="server">
                        <td >
                            COMPLETED</td>
                        <td >
                            <asp:TextBox ID="_18rcom" runat="server" Width="75px" 
                                ></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_18rcom" 
                                TargetControlID="_18rcom">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            RETENTION TIME AT MINIMUM HEIGHT (minutes)</td>
                        <td >
                            <asp:TextBox ID="_18mh" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    <tr>
                <td colspan="6" style="background-color: #092443;color:#fff" align="center" >
                    FIRE PROTECTION SYSTEM</td>
                </tr>
                    <tr id="tr3" runat="server">
                        <td >
                            PRE-COMM</td>
                        <td >
                            <asp:TextBox ID="_18pcom" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_18pcom" 
                                TargetControlID="_18pcom">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            COMM</td>
                        <td >
                            <asp:TextBox ID="_18com" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_18com" 
                                TargetControlID="_18com">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            DESIGN VOLUME</td>
                        <td >
                            <asp:TextBox ID="_18dv" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr2" runat="server">
                        <td >
                            OBTAINED %</td>
                        <td >
                            <asp:TextBox ID="_18op" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td >
                            WITNESSED DATE</td>
                        <td >
                            <asp:TextBox ID="_18wd" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_18wd" 
                                TargetControlID="_18wd">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    <tr id="tr4" runat="server">
                        <td colspan="6" style="background-color: #092443;color:#fff" align="center" >
                            INTERFACING</td>
                        
                    </tr>
                    <tr id="tr5" runat="server">
                        <td >
                            COMM</td>
                        <td >
                            <asp:TextBox ID="_18comi" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_18comi" 
                                TargetControlID="_18comi">
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
                        <td>
                            PFT (install) COMPLETION SIGN OFF [KEO]</td>
                        <td>
                            <asp:TextBox ID="_18icom" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="test13_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_18icom" 
                                TargetControlID="_18icom">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            PFT (operation) COMPLETION SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_18pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="actdate0_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_18pft" 
                                TargetControlID="_18pft">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            PLANT START UP COMPLETE CONTRACTOR</td>
                        <td>
                            <asp:TextBox ID="_18eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_12eng_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_18eng" 
                                TargetControlID="_18eng">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            FPT SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_18fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_12fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_18fpt" 
                                TargetControlID="_18fpt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ACCENPANCE RECOMMENDATION MADE</td>
                        <td>
                            <asp:TextBox ID="_18arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="test13_CalendarExtender0" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_18arm" 
                                TargetControlID="_18arm">
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
                            <asp:TextBox ID="_18actby" runat="server" Width="250px"></asp:TextBox>
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            <asp:TextBox ID="_18commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            <asp:TextBox ID="_18actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="date22_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_18actdt" 
                                TargetControlID="_18actdt">
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
                            <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                            <ContentTemplate>
                            <asp:Button ID="_18btnupdate" runat="server" 
                               Text="Update" onclick="_18btnupdate_Click"  />
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            
                            
                        </td>
                        <td align="left">
                            <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                            <ContentTemplate>
                            <asp:Button ID="_18btncancel" runat="server"
                                Text="Cancel" onclick="_18btncancel_Click"  />
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            
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
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender1" runat="server" TargetControlID="btnDummy1"  PopupControlID="pnlPopup1" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
    </div>
    </form>
</body>
</html>
