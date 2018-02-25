<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Commissioning_Testing3.aspx.cs" Inherits="CmlTechniques.CMS.Commissioning_Testing3" %>

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
                             <asp:Label ID="lblprj" runat="server" Text="text" ForeColor="White" style="display:none"></asp:Label><asp:Label ID="lblsch" runat="server" Text="text" ForeColor="White" style="display:none"></asp:Label></td>       
                            <td align="center" rowspan="2" valign="middle"   width="5%">
                                ITEM NO</td>
       
                            <td align="center" rowspan="2" valign="middle"   width="9%">
                                ENG.REF</td>
                            <td align="center" colspan="4" valign="middle"  >
                                ASSET CODE</td>
                            <td align="center" rowspan="2" valign="middle" width="8%" id="td_lbldes" runat="server" >
                                <asp:Label ID="lbdes" runat="server" Text="LOCATION"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="8%" id="td_lbl0" runat="server" >
                                <asp:Label ID="lbloc" runat="server" Text="AREA"></asp:Label>
                            </td>
                            <td align="center" rowspan="2" valign="middle" width="8%" id="td_lbl3" runat="server" >
                                <asp:Label ID="lbl3" runat="server" Text="FED TO"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="7%" id="td_lbl1" runat="server" >
                                <asp:Label ID="lbl1" runat="server" Text="NO.OF TEL/DATA/ VIDEO POINTS"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="7%" id="td_lbl2" runat="server" >
                                <asp:Label ID="lbl2" runat="server" Text="NO.OF FO BACKBONE CABLE"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="7%" id="td_lbl4" runat="server" >
                             <asp:Label ID="Label2" runat="server" Text="NO.OF FO CAT6a BACKBONE CABLE"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="7%" id="td_lbnum" runat="server" >
                                <asp:Label ID="lbnum" runat="server" Text="NO.OF CAT3 HORIZONTAL CABLE"></asp:Label></td>
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
                &nbsp;</td>
            <td id="tddes" runat="server">
            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drloc" runat="server" Width="100%" AutoPostBack="true" 
                        onselectedindexchanged="drloc_SelectedIndexChanged"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
            <td id="td0" runat="server">
            <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drdes" runat="server" Width="100%" AutoPostBack="true" 
                        onselectedindexchanged="drdes_SelectedIndexChanged"  >
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
            <td id="td_4" runat="server">
                &nbsp;</td>
            <td id="td_3" runat="server">
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
                <asp:BoundField DataField="Loc" HeaderText="Location" ItemStyle-Width="8%" >
                    <ItemStyle Width="8%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="P_P_to" HeaderText="Provides Power To" 
                        ItemStyle-Width="8%" >
                    <ItemStyle Width="8%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="F_from" HeaderText="Fed From" ItemStyle-Width="8%" >
                    <ItemStyle Width="8%" HorizontalAlign="Center" />
                    </asp:BoundField>    
                
                <asp:BoundField DataField="Des" HeaderText="" 
                        ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>    
                <asp:BoundField DataField="Substation" HeaderText="" 
                        ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="devices2" ItemStyle-Width="7%" >
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
        
         <asp:Panel ID="pnlPopup1" runat="server" Width="825px" Height="265px" style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_12lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                
                    <tr id="tr1" runat="server">
                        <td >
                            NO.OF FO BACKBONE CABLE</td>
                        <td >
                            <asp:TextBox ID="_12nfo" runat="server" Width="75px" ReadOnly="True" 
                                ></asp:TextBox>
                        </td>
                        <td >
                            NO.OF CAT6a BACKBONE CABLE</td>
                        <td >
                            <asp:TextBox ID="_12ncc" runat="server" Width="75px" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td >
                            NO.OF CAT3 HORIZONTAL CABLE</td>
                        <td >
                            <asp:TextBox ID="_12nhc" runat="server" Width="75px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr3" runat="server">
                        <td >
                            TESTED</td>
                        <td >
                            <asp:TextBox ID="_12fot" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td >
                            TESTED</td>
                        <td >
                            <asp:TextBox ID="_12cct" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td >
                            TESTED</td>
                        <td >
                            <asp:TextBox ID="_12hct" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CML ACCEPTED</td>
                        <td >
                            <asp:TextBox ID="_12accept1" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                            <asp:TextBox ID="_12filed1" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            INSTALLATION COMPLETION
                            SIGN OFF [KEO]</td>
                        <td>
                            <asp:TextBox ID="_12icom" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="test13_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_2pft" 
                                TargetControlID="_12icom">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            PFT COMPLETION SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_12pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="actdate0_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_2eng" 
                                TargetControlID="_12pft">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            MDF/ IDF ENERGISATION DATE</td>
                        <td>
                            <asp:TextBox ID="_12eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_12eng_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_2fpt" 
                                TargetControlID="_12eng">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            IR-FPT SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_12fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_12fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_2accept" 
                                TargetControlID="_12fpt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ACCENPANCE RECOMMENDATION
                            MADE</td>
                        <td>
                            <asp:TextBox ID="_12arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="test13_CalendarExtender0" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_2pft" 
                                TargetControlID="_12arm">
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
                            <asp:TextBox ID="_12actby" runat="server" Width="250px"></asp:TextBox>
                        </td>
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
                        <td>
                            <asp:TextBox ID="_12actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="date22_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yy" PopupButtonID="_2actdt" 
                                TargetControlID="_12actdt">
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
                            <asp:Button ID="_12btnupdate" runat="server" 
                               Text="Update" onclick="_12btnupdate_Click"  />
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            
                            
                        </td>
                        <td align="left">
                            <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                            <ContentTemplate>
                            <asp:Button ID="_12btncancel" runat="server"
                                Text="Cancel" onclick="_12btncancel_Click"  />
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
