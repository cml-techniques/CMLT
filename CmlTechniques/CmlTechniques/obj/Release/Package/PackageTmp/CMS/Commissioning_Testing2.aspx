<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Commissioning_Testing2.aspx.cs" Inherits="CmlTechniques.CMS.Commissioning_Testing2" %>

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
    <style type="text/css">
        .style1
        {
            width: 74px;
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
        <td width="100px">
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
                                <asp:Label ID="lbdes" runat="server" Text="DESCRIPTION"></asp:Label></td>
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
                <asp:Label ID="lblprj" runat="server" Text="text" ForeColor="White" style="display:none"></asp:Label><asp:Label ID="lblsch" runat="server" Text="text" ForeColor="White" style="display:none"></asp:Label><asp:Label ID="lblsch1" runat="server" Text="text" ForeColor="White" style="display:none"></asp:Label>
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
        <asp:Panel ID="pnlPopup7" runat="server" Width="825px" Height="350px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_8lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                 <tr style="background-color:#83C8EE">
                <td width="200px">
                    <asp:Label ID="lblppon" runat="server" Text=""></asp:Label>
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
                    <td width="75px">
                        <asp:TextBox ID="_8pft" runat="server" Width="75px"></asp:TextBox>
                        <asp:CalendarExtender ID="_8pft_CalendarExtender" runat="server" 
                            ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8pft" 
                            TargetControlID="_8pft">
                        </asp:CalendarExtender>
                     </td>
                <td width="200px">
                </td>
                <td width="75px"></td>
                </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="6"  align="center">
                            MECHANICAL SYSTEMS</td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            <asp:Label ID="lbltest8" runat="server" Text=""></asp:Label>
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
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_8co1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender55" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8co1" 
                                TargetControlID="_8co1">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            &nbsp;</td>
                        <td width="75PX" >
                            &nbsp;</td>
                    </tr>
                    <tr id="tradd1" runat="server">
                        <td width="200PX">
                         DESIGN VOLUME (l/s)</td>
                        <td width="75PX">
                            <asp:TextBox ID="_8dv" runat="server" Width="75px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td width="200PX">
                         OBTAINED VOLUME (l/s)</td>
                        <td width="75PX">
                            <asp:TextBox ID="_8ov" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            <asp:Label ID="lblduty8" runat="server" Text=""></asp:Label>
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_8duty" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                         WITNESSED DATE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_8wd1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender65" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_8wd1" TargetControlID="_8wd1">
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
                           
                            <asp:TextBox ID="_8accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender57" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8accept1" 
                                TargetControlID="_8accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            DOCUMENT FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_8filed1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender58" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8filed1" 
                                TargetControlID="_8filed1">
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
                             <asp:CalendarExtender ID="CalendarExtender60" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8pc2" 
                                TargetControlID="_8pc2">
                            </asp:CalendarExtender>
                             <asp:TextBox ID="_8pc2" runat="server" 
                                Width="75px"></asp:TextBox></td>
                        <td>
                            COMM</td>
                        <td>
                            <asp:TextBox ID="_8co2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender59" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8co2" 
                                TargetControlID="_8co2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            WITNESSED DATE</td>
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
                        <td>
                            <asp:TextBox ID="_8fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_8fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8fpt" 
                                TargetControlID="_8fpt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                         ACCEPTANCE RECOMMENDATION MADE</td>
                        <td>
                            <asp:TextBox ID="_8arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_8arm_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8arm" 
                                TargetControlID="_8arm">
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
                            
                            <asp:TextBox ID="_8actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_8commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_8actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender56" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_8actdt" 
                                TargetControlID="_8actdt">
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
                           <asp:Button ID="_8btnupdate" runat="server" Text="Update" 
                                onclick="_8btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_8btncancel" runat="server" Text="Cancel" 
                                onclick="_8btncancel_Click" />
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
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender7" runat="server" TargetControlID="btnDummy7"  PopupControlID="pnlPopup7" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
        <asp:Panel ID="pnlPopup9" runat="server" Width="825px" Height="330px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0">
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_9lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            PFT INSTALL COMPLETION SIGN OFF [KEO]</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_9ics" runat="server" Width="75px"></asp:TextBox>
                              <asp:CalendarExtender ID="CalendarExtender78" runat="server" 
                        TargetControlID="_9ics" PopupButtonID="_9ics" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            DAMPER CONTROL PANEL REFERENCE</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_9dcr" runat="server" Width="75px"></asp:TextBox>
                       </td>
                        <td width="200PX" >
                            POWER ON</td>
                        <td width="75PX" >
                           
                            <asp:TextBox ID="_9pwr" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender80" runat="server" 
                        TargetControlID="_9pwr" PopupButtonID="_9pwr" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            CONTRACTORS PRE-COM DATE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_9pic" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_9pic_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_9pic" TargetControlID="_9pic">
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
                        <td align="center" colspan="6">
                            ACCESS</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                          ACCESS DOOR PROVIDED</td>
                        <td width="75PX">
                            <asp:DropDownList ID="draccess" runat="server" Width="75px">
                            <asp:ListItem Text="Yes" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="No" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="200PX">
                         ACCESSABILITY (L/M/H)</td>
                        <td width="75PX">
                        <asp:DropDownList ID="draccessability" runat="server" Width="75px">
                            <asp:ListItem Text="Low" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Medium" Value="2"></asp:ListItem>
                            <asp:ListItem Text="High" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#092443;color:White">
                        <td align="center" colspan="6">
                            COMMISSIONED</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            MECHANICAL/FUNCTIONAL CHECK</td>
                        <td width="75PX">
                            <asp:TextBox ID="_9mc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender77" runat="server" 
                        TargetControlID="_9mc" PopupButtonID="_9mc" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            FIRESTAT CHECK</td>
                        <td width="75PX">
                            <asp:TextBox ID="_9fc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender87" runat="server" 
                        TargetControlID="_9fc" PopupButtonID="_9fc" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            FA INTERFACE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_9fai" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender88" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_9fai" TargetControlID="_9fai">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            EMCS INTERFACE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_9emcs" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender81" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_9emcs" TargetControlID="_9emcs">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            PFT COMPLETION SIGN OFF [CML]</td>
                        <td width="75PX">
                            <asp:TextBox ID="_9pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender79" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_9pft" TargetControlID="_9pft">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="75PX">
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            DOCUMENT FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_9dfiled" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender84" runat="server" 
                        TargetControlID="_9dfiled" PopupButtonID="_9dfiled" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            FPT COMPLETION SIGN OFF [CML]</td>
                        <td >
                           
                            <asp:TextBox ID="_9fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender85" runat="server" 
                        TargetControlID="_9fpt" PopupButtonID="_9fpt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            ACCEPTANCE RECOMMENDATION MADE</td>
                        <td >
                            <asp:TextBox ID="_9accept" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_9accept_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_9accept" 
                                TargetControlID="_9accept">
                            </asp:CalendarExtender>
                      </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_9actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_9commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_9actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender86" runat="server" 
                        TargetControlID="_9actdt" PopupButtonID="_9actdt" ClearTime="true" 
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
                           <asp:Button ID="_9btnupdate" runat="server" Text="Update" 
                                onclick="_9btnupdate_Click"  />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_9btncancel" runat="server" Text="Cancel" 
                                onclick="_9btncancel_Click" />
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
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender9" runat="server" TargetControlID="btnDummy9"  PopupControlID="pnlPopup9" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
         <asp:Panel ID="pnlPopup1" runat="server" Width="825px" Height="320px" style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_2lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="6"  align="center">
                            PANEL / EQUIPMENT TESTING</td>
                    </tr>
                
                    <tr id="tr1" runat="server">
                        <td >
                            TORQUE TEST</td>
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
                        <td >
                            <asp:TextBox ID="_2ir" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_2ir_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2ir" 
                                TargetControlID="_2ir">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            HV TEST</td>
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
                            PRIMARY INJECTION TEST</td>
                        <td>
                            <asp:TextBox ID="_2pi" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="date7_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2pi" TargetControlID="_2pi">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            CONTACT RESISTANCE</td>
                        <td >
                            <asp:TextBox ID="_2cr" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="date6_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2cr" 
                                TargetControlID="_2cr">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            PT TEST</td>
                        <td >
                            <asp:TextBox ID="_2pt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="date5_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2pt" TargetControlID="_2pt">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr id="tr3" runat="server">
                        <td >
                            CT TEST</td>
                        <td >
                            <asp:TextBox ID="_2ct" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="date15_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2ct" 
                                TargetControlID="_2ct">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            RELAY TEST</td>
                        <td >
                            <asp:TextBox ID="_2rt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="date16_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2rt" 
                                TargetControlID="_2rt">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            FUNCTIONAL TEST</td>
                        <td >
                            <asp:TextBox ID="_2fn" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="date14_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2fn" 
                                TargetControlID="_2fn">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="6" align="center">
                            MV CABLE TEST</td>
                    </tr>
                    <tr id="tr7" runat="server">
                        <td >
                            CONTINUITY/ IR/ HI POT TEST</td>
                        <td >
                            <asp:TextBox ID="_2cih" runat="server" Width="75px"></asp:TextBox><asp:TextBox ID="_2dvc" runat="server" Width="75px" style="display:none"></asp:TextBox>
                        </td>
                        <td >
                            DATE TESTED&nbsp;</td>
                        <td >
                            <asp:TextBox ID="_2dt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_2dt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2dt" TargetControlID="_2dt">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            WITNESSED BY</td>
                        <td >
                            <asp:TextBox ID="_2witness" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            PFT SIGN OFF [KEO]</td>
                        <td >
                            <asp:TextBox ID="_2pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="test13_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2pft" 
                                TargetControlID="_2pft">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            ENERGISATION DATE</td>
                        <td >
                            <asp:TextBox ID="_2eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="actdate0_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2eng" 
                                TargetControlID="_2eng">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            FPT SIGN OFF [CML]</td>
                        <td >
                            <asp:TextBox ID="_2fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_2fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2fpt" TargetControlID="_2fpt">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            ACCEPTANCE RECOM. MADE</td>
                        <td>
                            <asp:TextBox ID="_2accept" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_2accept_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2accept" 
                                TargetControlID="_2accept">
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
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td colspan="2">
                            <asp:TextBox ID="_2actby" runat="server" Width="250px"></asp:TextBox>
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            <asp:TextBox ID="_2commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            <asp:TextBox ID="_2actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="date22_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_2actdt" 
                                TargetControlID="_2actdt">
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
        <asp:Panel ID="pnlPopup4" runat="server" Width="825px" Height="375px" style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate>
                 <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                 <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_5lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="6"  align="center">
                            PANEL / EQUIPMENT TESTING</td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            TORQUE TEST</td>
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
                        <td width="75PX" >
                            <asp:CalendarExtender ID="CalendarExtender18" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_5ir" 
                                TargetControlID="_5ir">
                            </asp:CalendarExtender>
                            <asp:TextBox ID="_5ir" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            PRESSURE TEST</td>
                        <td width="75PX" >
                            <asp:CalendarExtender ID="CalendarExtender19" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_5pr" 
                                TargetControlID="_5pr">
                            </asp:CalendarExtender>
                            <asp:TextBox ID="_5pr" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                         <td>
                             PRIMARY CURRENT INJECTION TEST</td>
                         <td>
                             <asp:TextBox ID="_5pi" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="_5pi_CalendarExtender" runat="server" 
                                 ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_5pi" 
                                 TargetControlID="_5pi">
                             </asp:CalendarExtender>
                         </td>
                         <td>
                             SECONDARY INJECTION TEST</td>
                         <td>
                             <asp:TextBox ID="_5si" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender35" runat="server" ClearTime="true" 
                                 Format="dd/MM/yyyy" PopupButtonID="_5si" TargetControlID="_5si">
                             </asp:CalendarExtender>
                         </td>
                         <td>
                             CONTACT RESISTANCE</td>
                         <td>
                             <asp:TextBox ID="_5cr" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender36" runat="server" ClearTime="true" 
                                 Format="dd/MM/yyyy" PopupButtonID="_5cr" TargetControlID="_5cr">
                             </asp:CalendarExtender>
                         </td>
                     </tr>
                     <tr>
                         <td>
                             FUNCTIONAL TEST</td>
                         <td>
                             <asp:TextBox ID="_5fn" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender37" runat="server" ClearTime="true" 
                                 Format="dd/MM/yyyy" PopupButtonID="_5fn" TargetControlID="_5fn">
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
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="6" align="center">
                            OUTGOING CIRCUIT COLD TESTING</td>
                    </tr>
                    <tr >
                        <td >
                            TOTAL NO.OF CIRCUITS</td>
                        <td >
                            <asp:TextBox ID="_5total" runat="server" Width="75px" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td >
                            TOTAL COLD TESTED</td>
                        <td >
                            <asp:TextBox ID="_5tc" runat="server" Width="75px" Text="0"></asp:TextBox>
                            
                        </td>
                        <td >
                            COLD TEST COMPLETED</td>
                        <td >
                            <asp:TextBox ID="_5cc" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender38" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_5cc" TargetControlID="_5cc">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                     <tr style="background-color:#092443;color:White" >
                        <td colspan="6" align="center">
                            OUTGOING CIRCUIT LIVE TESTING</td>
                    </tr>
                    <tr >
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            TOTAL LIVE TESTED</td>
                        <td>
                            <asp:TextBox ID="_5tl" runat="server" Width="75px" Text="0"></asp:TextBox>
                        </td>
                        <td>
                            LIVE TEST COMPLETED</td>
                        <td>
                            <asp:TextBox ID="_5lc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender39" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_5lc" TargetControlID="_5lc">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            PFT(install)Authority to commence commi. signoff</td>
                        <td>
                            <asp:TextBox ID="_5pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender40" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_5pft" TargetControlID="_5pft">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ENERGISATION DATE</td>
                        <td>
                            <asp:TextBox ID="_5ed" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender41" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_5ed" TargetControlID="_5ed">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            MECHANICAL PLANT FPT COMPLETED [CML]</td>
                        <td>
                            <asp:TextBox ID="_5fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_5fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_5fpt" 
                                TargetControlID="_5fpt">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                     <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                         <td>
                             ACCEPTANCE RECOMMENDATION MADE</td>
                         <td>
                             <asp:TextBox ID="_5arm" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="_5arm_CalendarExtender" runat="server" 
                                 ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_5arm" 
                                 TargetControlID="_5arm">
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
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td colspan="2">
                            <asp:TextBox ID="_5actby" runat="server" Width="250px"></asp:TextBox>
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            <asp:TextBox ID="_5commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            <asp:TextBox ID="_5actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender29" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_5actdt" 
                                TargetControlID="_5actdt">
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
                           <asp:Button ID="_5btnupdate" runat="server" Text="Update" 
                                onclick="_5btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_5btncancel" runat="server" Text="Cancel" 
                                onclick="_5btncancel_Click" />
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
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender4" runat="server" TargetControlID="btnDummy4"  PopupControlID="pnlPopup4" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
         <asp:Panel ID="pnlPopup5" runat="server" Width="825px" Height="355px" style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_4lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="6"  align="center">
                            GENERATOR TESTING</td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            PRE-COM </td>
                        <td width="75PX" >
                            <asp:TextBox ID="_4pc" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender42" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4pc" 
                                TargetControlID="_4pc">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            CONTROL/FUEL SYSTEM TEST</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_4cft" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender43" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4cft" 
                                TargetControlID="_4cft">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            INITIAL RUN TEST</td>
                        <td width="75PX" >
                           
                            <asp:TextBox ID="_4irt" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender44" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4irt" 
                                TargetControlID="_4irt">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            LOAD TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_4lt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender50" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_4lt" TargetControlID="_4lt">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            FUNCTIONAL TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_4ft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_4sol0_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4ft" 
                                TargetControlID="_4ft">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            FULL RUN TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_4frt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_4sol1_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4frt" 
                                TargetControlID="_4frt">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="6" align="center">
                            OUTGOING CIRCUIT TESTING</td>
                    </tr>
                    <tr id="tr12" runat="server">
                        <td >
                            CONTINUITY TEST</td>
                        <td >
                           
                            <asp:TextBox ID="_4ct" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender47" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4ct" 
                                TargetControlID="_4ct">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            IR (before &amp; after HP)</td>
                        <td >
                           
                            <asp:TextBox ID="_4ir" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_4ct0_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4ir" TargetControlID="_4ir">
                            </asp:CalendarExtender>
                           
                        </td>
                        <td >
                            HP TEST</td>
                        <td >
                            
                            <asp:TextBox ID="_4hp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_4ir0_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4hp" TargetControlID="_4hp">
                            </asp:CalendarExtender>
                            
                        </td>
                    </tr>
                    <tr >
                        <td>
                            COLD TEST COMPLETED DATE</td>
                        <td>
                           
                            <asp:TextBox ID="_4ctc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender48" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4ctc" 
                                TargetControlID="_4ctc">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            CONSULTANT ACCEPTED</td>
                        <td>
                           
                            <asp:TextBox ID="_4accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender49" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4accept1" 
                                TargetControlID="_4accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            PFT SIGN OFF [KEO]</td>
                        <td>
                            <asp:TextBox ID="_4pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_4pft_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4pft" 
                                TargetControlID="_4pft">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ENERGISATION DATE</td>
                        <td>
                            <asp:TextBox ID="_4eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_4eng_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4eng" 
                                TargetControlID="_4eng">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            FPT SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_4fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_4fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4fpt" 
                                TargetControlID="_4fpt">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            ACCEPTANCE RECOMMENDATION MADE</td>
                        <td>
                            <asp:TextBox ID="_4arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_4arm_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4arm" 
                                TargetControlID="_4arm">
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
                            <asp:TextBox ID="_4accept2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_4accept2_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4accept2" 
                                TargetControlID="_4accept2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            TEST SHEETS FILED</td>
                        <td>
                            <asp:TextBox ID="_4filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_4filed1_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4filed1" 
                                TargetControlID="_4filed1">
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
                            
                            <asp:TextBox ID="_4actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_4commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_4actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender53" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_4actdt" 
                                TargetControlID="_4actdt">
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
                           <asp:Button ID="_4btnupdate" runat="server" Text="Update" 
                                onclick="_4btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_4btncancel" runat="server" Text="Cancel" 
                                onclick="_4btncancel_Click" />
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
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender5" runat="server" TargetControlID="btnDummy5"  PopupControlID="pnlPopup5" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
        <asp:Panel ID="pnlPopup3" runat="server" Width="825px" Height="235px" style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_6lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            EARTH PIT TEST</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_6ep" runat="server" Width="75px" 
                                ></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender10" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6ep" 
                                TargetControlID="_6ep">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            CONTINUITY TEST OF REBARS/ CONDUCTORS</td>
                        <td width="75PX" >
                           
                            <asp:TextBox ID="_6ct" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender24" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_6ct" TargetControlID="_6ct">
                            </asp:CalendarExtender>
                           
                        </td>
                        <td width="200PX" >
                            BONDING OF ALL EQUIPMENT COMPLETED</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_6bc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_6bc_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6bc" 
                                TargetControlID="_6bc">
                            </asp:CalendarExtender>
                            
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            PFT SIGN OFF</td>
                        <td>
                            <asp:TextBox ID="_6pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender21" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_6pft" TargetControlID="_6pft">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ENERGISATION DATE</td>
                        <td>
                            <asp:TextBox ID="_6eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender22" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_6eng" TargetControlID="_6eng">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            FPT SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_6fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_6fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6fpt" 
                                TargetControlID="_6fpt">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            ACCEPTANCE RECOMMENDATION MADE</td>
                        <td >
                            <asp:TextBox ID="_6arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender23" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6arm" 
                                TargetControlID="_6arm">
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
                            CONSULTANT ACCEPTED</td>
                        <td>
                            <asp:TextBox ID="_6accept1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender33" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6accept1" 
                                TargetControlID="_6accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            TEST SHEETS FILED</td>
                        <td>
                            <asp:TextBox ID="_6filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender34" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6filed1" 
                                TargetControlID="_6filed1">
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
                            <asp:TextBox ID="_6actby" runat="server" Width="250px"></asp:TextBox>
                        </td>
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
                        <td>
                            <asp:TextBox ID="_6actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender25" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_6actdt" 
                                TargetControlID="_6actdt">
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
                            <asp:Button ID="_6btnupdate" runat="server" 
                                Text="Update" onclick="_6btnupdate_Click" />
                        </td>
                        <td align="left">
                            <asp:Button ID="_6btncancel" runat="server"
                                Text="Cancel" onclick="_6btncancel_Click" />
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
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender3" runat="server" TargetControlID="btnDummy3"  PopupControlID="pnlPopup3" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
        <asp:Panel ID="pnlPopup2" runat="server" Width="825px" Height="380px" style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_3lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="6"  align="center">
                            PANEL/EQUIPMENT TESTING</td>
                    </tr>
                
                    <tr >
                        <td >
                            WINDING IR TEST</td>
                        <td >
                            <asp:TextBox ID="_3ir" runat="server" Width="75px" 
                                ></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3ir" 
                                TargetControlID="_3ir">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TAP CHANGER CHECK&nbsp;</td>
                        <td >
                            <asp:TextBox ID="_3tcc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3tcc" 
                                TargetControlID="_3tcc">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            RATIO TEST, VECTOR GROUP AND&nbsp;
                            <br />
                            MAGNETIC CURRENT MEASUREMENT TEST</td>
                        <td >
                            <asp:TextBox ID="_3rvm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3rvm" 
                                TargetControlID="_3rvm">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr >
                        <td >
                            MAGNETIC BALANCE TEST</td>
                        <td>
                            <asp:TextBox ID="_3mbt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender6" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3mbt" 
                                TargetControlID="_3mbt">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            WINDING RESTANCE TEST</td>
                        <td >
                            <asp:TextBox ID="_3wrt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender7" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3wrt" 
                                TargetControlID="_3wrt">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            SHORT CIRCUIT TEST</td>
                        <td >
                        
                            <asp:TextBox ID="_3sct" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3sct_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3sct" TargetControlID="_3sct">
                            </asp:CalendarExtender>
                        
                        </td>
                    </tr>
                    <tr>
                        <td>
                            CALIBRATION OF TEMP.
                            <br />
                            INDICATOR AND RELAY TEST</td>
                        <td>
                            <asp:TextBox ID="_3ctr" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3ctr_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3ctr" TargetControlID="_3ctr">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            BUCHOLZ RELAY TEST</td>
                        <td>
                            <asp:TextBox ID="_3brt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3brt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3brt" TargetControlID="_3brt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            TAN DELTA &amp; CAPACITANCE OF WINDING</td>
                        <td>
                            <asp:TextBox ID="_3tcw" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3tcw_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3tcw" TargetControlID="_3tcw">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            TRANSFORMER OIL ANALYSIS</td>
                        <td>
                            <asp:TextBox ID="_3toa" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3toa_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3toa" TargetControlID="_3toa">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            BUSHING CT TEST</td>
                        <td>
                            <asp:TextBox ID="_3bct" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3bct_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3bct" TargetControlID="_3bct">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="6" align="center">
                            SECONDARY CABLE/BUSDUCT TEST</td>
                    </tr>
                    <tr >
                        <td >
                            QUANTITY</td>
                        <td >
                            <asp:TextBox ID="_3qty" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender11" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_3qty" TargetControlID="_3qty">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            CABLE TESTED</td>
                        <td >
                            <asp:TextBox ID="_3ct" runat="server" Width="75px"></asp:TextBox>
                           
                        </td>
                        <td >
                            DATE TESTED</td>
                        <td >
                            <asp:TextBox ID="_3ctd" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3ctd_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3ctd" 
                                TargetControlID="_3ctd">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            PFT SIGN OFF</td>
                        <td >
                            <asp:TextBox ID="_3pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender15" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3pft" 
                                TargetControlID="_3pft">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            ENERGISATION DATE</td>
                        <td >
                            <asp:TextBox ID="_3eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender16" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3eng" 
                                TargetControlID="_3eng">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            FPT SIGN OFF</td>
                        <td >
                            <asp:TextBox ID="_3fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3fpt" 
                                TargetControlID="_3fpt">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            ACCEPTANCE
                            <br />
                            RECOMMENDATION MADDE</td>
                        <td>
                            <asp:TextBox ID="_3arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_3arm_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3arm" 
                                TargetControlID="_3arm">
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
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td colspan="2">
                            <asp:TextBox ID="_3actby" runat="server" Width="250px"></asp:TextBox>
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            <asp:TextBox ID="_3commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            <asp:TextBox ID="_3actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender17" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_3actdt" 
                                TargetControlID="_3actdt">
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
                            <asp:Button ID="_3btnupdate" runat="server" 
                                Text="Update" onclick="_3btnupdate_Click" />
                        </td>
                        <td align="left">
                            <asp:Button ID="_3btncancel" runat="server" 
                                Text="Cancel" onclick="_3btncancel_Click" />
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
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender2" runat="server" TargetControlID="btnDummy2"  PopupControlID="pnlPopup2" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
        <asp:Panel ID="pnlPopup6" runat="server" Width="825px" Height="300px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_7lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="6"  align="center">
                            CIRCUIT IR TESTING</td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            TOTAL NO.OF CIRCUITS</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_7total" runat="server" Width="75px" Text=""></asp:TextBox>
                             <%--<asp:CalendarExtender ID="CalendarExtender54" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7cir" 
                                TargetControlID="_7cir">
                            </asp:CalendarExtender>--%>
                        </td>
                        <td width="200PX" >
                            TOTAL IR TESTED</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_7ir" runat="server" Width="75px" Text=""></asp:TextBox>
                           <%-- <asp:CalendarExtender ID="CalendarExtender55" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7add" 
                                TargetControlID="_7add">
                            </asp:CalendarExtender>--%>
                        </td>
                        <td width="200PX" >
                            &nbsp;</td>
                        <td width="75PX" >
                           
                            <%--<asp:CalendarExtender ID="CalendarExtender56" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7ft" 
                                TargetControlID="_7ft">
                            </asp:CalendarExtender>--%>
                        </td>
                    </tr>
                    <tr style="background-color:#092443;color:White; text-align: center;">
                        <td colspan="6">
                            CBS TESTING</td>
                    </tr>
                    <tr >
                        <td >
                            DEVICE ADDRESSING TEST</td>
                        <td >
                           
                            <asp:TextBox ID="_7dat" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_7dat_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7dat" 
                                TargetControlID="_7dat">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            SOFTWARE PROGRAMMING</td>
                        <td >
                           
                            <asp:TextBox ID="_7sp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_7sp" TargetControlID="_7sp">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            PANEL FUNCTIONAL TEST</td>
                        <td >
                            
                            <asp:TextBox ID="_7pt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender8" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_7pt" TargetControlID="_7pt">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr >
                        <td>
                            LIGHTING LUX LEVEL TEST&nbsp;</td>
                        <td>
                            <asp:TextBox ID="_7lllt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender12" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_7lllt" TargetControlID="_7lllt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            BATTERY DISCHARGE TEST</td>
                        <td>
                            <asp:TextBox ID="_7bdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_7bdt" TargetControlID="_7bdt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            GRAPHICS TEST</td>
                        <td>
                            <asp:TextBox ID="_7gt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender13" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_7gt" TargetControlID="_7gt">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            PFT SIGN OFF</td>
                        <td>
                            <asp:TextBox ID="_7pft" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender61" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7pft" 
                                TargetControlID="_7pft">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ENERGISATION DATE</td>
                        <td>
                            <asp:TextBox ID="_7eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender62" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7eng" 
                                TargetControlID="_7eng">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            FPT SIGN OFF</td>
                        <td>
                            <asp:TextBox ID="_7fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_7fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7fpt" 
                                TargetControlID="_7fpt">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            ACCEPTANCE
                            <br />
                            RECOMMENDATION MADE</td>
                        <td>
                            <asp:TextBox ID="_7arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_7arm_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7arm" 
                                TargetControlID="_7arm">
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
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_7actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_7commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_7actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender63" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_7actdt" 
                                TargetControlID="_7actdt">
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
                           <asp:Button ID="_7btnupdate" runat="server" Text="Update" 
                                onclick="_7btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_7btncancel" runat="server" Text="Cancel" 
                                onclick="_7btncancel_Click" />
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
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender6" runat="server" TargetControlID="btnDummy6"  PopupControlID="pnlPopup6" BackgroundCssClass="modal" ></asp:ModalPopupExtender> 
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
        <asp:Panel ID="pnlPopup14" runat="server" Width="825px" Height="295px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_20lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            NO.OF POINTS</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_20npnt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            CONTINUITY/CABLE TEST</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_20cct" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender14" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_20cct" 
                                TargetControlID="_20cct">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            PROGRAMMING</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_20prg" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender20" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_20prg" 
                                TargetControlID="_20prg">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            NO.OF POINTS TESTED</td>
                        <td width="75PX">
                            <asp:TextBox ID="_20npt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            POINT TEST COMPLETED</td>
                        <td width="75PX">
                            <asp:TextBox ID="_20ptc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender26" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_20ptc" 
                                TargetControlID="_20ptc">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            SEQ. OF OP TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_20sot" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_20sot_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_20sot" 
                                TargetControlID="_20sot">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            GRAPHICS TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_20grt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender27" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_20grt" 
                                TargetControlID="_20grt">
                            </asp:CalendarExtender>
                       </td>
                        <td width="200PX">
                            SYSTEM INTERFACE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_20sin" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_20sin_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_20sin" 
                                TargetControlID="_20sin">
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
                           
                            <asp:TextBox ID="_20accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender127" runat="server" 
                        TargetControlID="_20accept1" PopupButtonID="_20accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_20filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender128" runat="server" 
                        TargetControlID="_20filed1" PopupButtonID="_20filed1" ClearTime="true" 
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
                            <asp:TextBox ID="_20icom" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_20icom_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_20icom" 
                                TargetControlID="_20icom">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            PFT COMPLETION SIGN OFF[CML]</td>
                        <td>
                            <asp:TextBox ID="_20pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_20pft_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_20pft" 
                                TargetControlID="_20pft">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ENERGISATION DATE</td>
                        <td>
                            <asp:TextBox ID="_20eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_20eng_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_20eng" 
                                TargetControlID="_20eng">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            FPT SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_20fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_20fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_20fpt" 
                                TargetControlID="_20fpt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ACCEPTANCE RECOMMENDATION MADE</td>
                        <td>
                            <asp:TextBox ID="_20arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_20arm_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_20arm" 
                                TargetControlID="_20arm">
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
                            
                            <asp:TextBox ID="_20actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_20commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_20actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender129" runat="server" 
                        TargetControlID="_20actdt" PopupButtonID="_20actdt" ClearTime="true" 
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
                           <asp:Button ID="_20btnupdate" runat="server" Text="Update" 
                                onclick="_20btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_20btncancel" runat="server" Text="Cancel" 
                                onclick="_20btncancel_Click" />
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
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender14" runat="server" TargetControlID="btnDummy14"  PopupControlID="pnlPopup14" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
        <asp:Panel ID="pnlPopup21" runat="server" Width="825px" Height="290px" 
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
                            NO.OF IED DEVICE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_23dvc" runat="server" Width="75px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            CONTINUITY/ CABLE TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_23cct" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            PROGRAMMING</td>
                        <td width="75PX">
                            <asp:TextBox ID="_23prg" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            NO.OF POINTS TESTED</td>
                        <td width="75PX">
                            <asp:TextBox ID="_23npt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            POINT TEST COMPLETE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_23ptc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender145" runat="server" 
                        TargetControlID="_23ptc" PopupButtonID="_23ptc" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            SEQ.OF OP TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_23sot" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            GRAPHICS TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_23grt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            INTEGRATION/INTERFACE TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_23iit" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_23iit_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_23iit" 
                                TargetControlID="_23iit">
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
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            INSTALLATION COMPLETION SIGN OFF [KEO]</td>
                        <td>
                            <asp:TextBox ID="_23icomp" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_23icomp_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_23icomp" 
                                TargetControlID="_23icomp">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            PFT COMPLETION SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_23pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_23pft_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_23pft" 
                                TargetControlID="_23pft">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ENERGISATION DATE</td>
                        <td>
                            <asp:TextBox ID="_23eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_23eng_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_23eng" 
                                TargetControlID="_23eng">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            FPT SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_23fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_23fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_23fpt" 
                                TargetControlID="_23fpt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ACCEPTANCE
                            <br />
                            RECOMMENDATION MADE</td>
                        <td>
                            <asp:TextBox ID="_23arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_23arm_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_23arm" 
                                TargetControlID="_23arm">
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
        <asp:Panel ID="pnlPopup17" runat="server" Width="825px" Height="320px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
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
                                TargetControlID="_11ztp">
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
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender17" runat="server" TargetControlID="btnDummy17"  PopupControlID="pnlPopup17" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
        <asp:Panel ID="pnlPopup16" runat="server" Width="825px" Height="290px" 
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
                            NO.OF POINTS</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_22nop" runat="server" Width="75px" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            CONTINUITY/ CABLE TEST</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_22cit" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            PROGRAMMING</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_22prg" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            NO.OF POINTS TESTED</td>
                        <td width="75PX">
                            <asp:TextBox ID="_22npt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            POINT TEST COMPLETE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_22ptc" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            SEQ. OF OP TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_22sot" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            UPS/ BATTERY SUPPLY TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_22ust" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            GRAPHICS TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_22grt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            INTEGRATION/ INTERFACE TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_22iit" runat="server" Width="75px"></asp:TextBox>
                        </td>
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
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            INSTALLATION COMPLETION SIGN OFF [KEO]</td>
                        <td>
                            <asp:TextBox ID="_22icom" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender30" runat="server" 
                        TargetControlID="_22icom" PopupButtonID="_22icom" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            PFT COMPLETION SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_22pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender31" runat="server" 
                        TargetControlID="_22pft" PopupButtonID="_22pft" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            ENERGISATION DATE</td>
                        <td>
                            <asp:TextBox ID="_22eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender32" runat="server" 
                        TargetControlID="_22eng" PopupButtonID="_22eng" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            FPT SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_22fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender45" runat="server" 
                        TargetControlID="_22fpt" PopupButtonID="_22fpt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            ACCEPTANCE RECOMMENDATION MADE</td>
                        <td>
                            <asp:TextBox ID="_22arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender46" runat="server" 
                        TargetControlID="_22arm" PopupButtonID="_22arm" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
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
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender16" runat="server" TargetControlID="btnDummy16"  PopupControlID="pnlPopup16" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
        <asp:Panel ID="pnlPopup19" runat="server" Width="825px" Height="265px" 
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
                            NO.OF POINTS PER OUTLET</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15nop" runat="server" Width="75px" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            CONTINUITY/ CABLE TEST</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15cct" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            SYSTEM FUNCTION TESTS AT TR</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_15sft_tr" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            SYSTEM FUNCTION TESTS AT OUTLETS</td>
                        <td width="75PX">
                            <asp:TextBox ID="_15sft_out" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            SYSTEM FUNCTION TESTS AT HEADEND</td>
                        <td width="75PX">
                            <asp:TextBox ID="_15sft_he" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            INTEGRATION/ INTERFACE TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_15iit" runat="server" Width="75px"></asp:TextBox>
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
                        </td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            INSTALLATION COMPLETION SIGN OFF [KEO]</td>
                        <td>
                            <asp:TextBox ID="_15icom" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_15icom_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_15icom" 
                                TargetControlID="_15icom">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            PFT COMPLETION SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_15pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_15pft_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_15pft" 
                                TargetControlID="_15pft">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ENERGISATION DATE</td>
                        <td>
                            <asp:TextBox ID="_15eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_15eng_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_15eng" 
                                TargetControlID="_15eng">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            FPT SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_15fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_15fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_15fpt" 
                                TargetControlID="_15fpt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ACCEPTANCE RECOMMENDATION MADE</td>
                        <td>
                            <asp:TextBox ID="_15arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_15arm_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_15arm" 
                                TargetControlID="_15arm">
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
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender19" runat="server" TargetControlID="btnDummy19"  PopupControlID="pnlPopup19" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
        <asp:Panel ID="pnlPopup15" runat="server" Width="825px" Height="295px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_13lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            NO.OF POINTS/ CAMERAS</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_13nop" runat="server" Width="75px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            CONTINUITY/ CABLE TEST</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_13cct" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            PROGRAMMING</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_13prg" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            CCTV VIEW LOCALLY</td>
                        <td width="75PX">
                            <asp:TextBox ID="_13cvl" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            HEAD END TEST/ VIDEO</td>
                        <td width="75PX">
                            <asp:TextBox ID="_13htv" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            HEAD END TEST/ CAMERAS &amp; PTZ CONTROLS</td>
                        <td width="75PX">
                            <asp:TextBox ID="_13htc" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            UPS/ BATTERY SUPPLY TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_13ubt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender51" runat="server" 
                        TargetControlID="_13ubt" PopupButtonID="_13ubt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            NO.OF INTEGRATION/ INTERFACE TESTED</td>
                        <td width="75PX">
                            <asp:TextBox ID="_13iit" runat="server" Width="75px"></asp:TextBox>
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
                           
                            <asp:TextBox ID="_13accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender126" runat="server" 
                        TargetControlID="_13accept1" PopupButtonID="_13accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_13filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender130" runat="server" 
                        TargetControlID="_13filed1" PopupButtonID="_13filed1" ClearTime="true" 
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
                            <asp:TextBox ID="_13icom" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_13icom_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_13icom" 
                                TargetControlID="_13icom">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            PFT COMPLETION SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_13pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_13pft_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_13pft" 
                                TargetControlID="_13pft">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ENERGISATION DATE</td>
                        <td>
                            <asp:TextBox ID="_13eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_13eng_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_13eng" 
                                TargetControlID="_13eng">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            FPT SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_13fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_13fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_13fpt" 
                                TargetControlID="_13fpt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ACCEPTANCE RECOMMENDATION MADE</td>
                        <td>
                            <asp:TextBox ID="_13arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_13arm_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_13arm" 
                                TargetControlID="_13arm">
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
                            
                            <asp:TextBox ID="_13actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_13commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_13actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender131" runat="server" 
                        TargetControlID="_13actdt" PopupButtonID="_13actdt" ClearTime="true" 
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
                           <asp:Button ID="_13btnupdate" runat="server" Text="Update" 
                                onclick="_13btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_13btncancel" runat="server" Text="Cancel" 
                                onclick="_13btncancel_Click"  />
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
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender15" runat="server" TargetControlID="btnDummy15"  PopupControlID="pnlPopup15" BackgroundCssClass="modal" ></asp:ModalPopupExtender> 
        <asp:Panel ID="pnlPopup22" runat="server" Width="825px" Height="265px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                
                    <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_16lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            NO.OF VIDEO STATION</td>
                        <td width="75PX">
                            <asp:TextBox ID="_16nos" runat="server" Width="75px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            CONTINUITY/ CABLE TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_16cct" runat="server" Width="75px" ></asp:TextBox>
                        </td>
                        <td width="200PX">SYSTEM FUNCTION TESTS AT MASTER STATION</td>
                        <td width="75PX">
                            <asp:TextBox ID="_16sft" runat="server" Width="75px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            INTEGRATION/ INTERFACE TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_16iit" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_16iit_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_16iit" 
                                TargetControlID="_16iit">
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
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            CONSULTANT ACCEPTED</td>
                        <td >
                           
                            <asp:TextBox ID="_16accept1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender155" runat="server" 
                        TargetControlID="_16accept1" PopupButtonID="_16accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_16filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender156" runat="server" 
                        TargetControlID="_16filed1" PopupButtonID="_16filed1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                        </td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            INSTALLATION COMPLETION SIGN OFF [KEO]</td>
                        <td>
                            <asp:TextBox ID="_16icom" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_16icom_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_16accept2" 
                                TargetControlID="_16icom">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            PFT COMPLETION SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_16pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_16pft_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_16pft" 
                                TargetControlID="_16pft">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ENERGISATION DATE</td>
                        <td>
                            <asp:TextBox ID="_16eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_16eng_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_16eng" 
                                TargetControlID="_16eng">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            FPT SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_16fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_16fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_16fpt" 
                                TargetControlID="_16fpt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ACCEPTANCE REOMMENDATION MADE</td>
                        <td>
                            <asp:TextBox ID="_16arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_16arm_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_16arm" 
                                TargetControlID="_16arm">
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
                            
                            <asp:TextBox ID="_16actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_16commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_16actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender157" runat="server" 
                        TargetControlID="_16actdt" PopupButtonID="_16actdt" ClearTime="true" 
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
                           <asp:Button ID="_16btnupdate" runat="server" Text="Update" 
                                onclick="_16btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_16btncancel" runat="server" Text="Cancel" 
                                onclick="_16btncancel_Click" />
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
        <asp:Panel ID="pnlPopup20" runat="server" Width="825px" Height="295px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_14lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            NO.OF CIRCUITS&nbsp;</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_14noc" runat="server" Width="75px" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            NO.OF CIRCUITS TESTED</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_14nct" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            PRE-COMMISSIONING COMPLETE</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_14pcc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender52" runat="server" 
                        TargetControlID="_14pcc" PopupButtonID="_14pcc" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            AUDIO COMMISSIONING COMPLETE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_14acc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender67" runat="server" 
                        TargetControlID="_14acc" PopupButtonID="_14acc" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            VIDEO COMMISSIONING COMPLETE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_14vcc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender68" runat="server" 
                        TargetControlID="_14vcc" PopupButtonID="_14vcc" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            REMOTE CONTROL SYSTEM TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_14rst" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender69" runat="server" 
                        TargetControlID="_14rst" PopupButtonID="_14rst" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            FINAL ADJUSTMENT/ ACCEPTANCE DEMO</td>
                        <td width="75PX">
                            <asp:TextBox ID="_14faa" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender70" runat="server" 
                        TargetControlID="_14faa" PopupButtonID="_14faa" ClearTime="true" 
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
                           
                            <asp:TextBox ID="_14accept1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender140" runat="server" 
                        TargetControlID="_14accept1" PopupButtonID="_14accept1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_14filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender138" runat="server" 
                        TargetControlID="_14filed1" PopupButtonID="_14filed1" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td >
                        </td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            INSTALLATION COMPLETION SIGN OFF [KEO]</td>
                        <td>
                            <asp:TextBox ID="_14icom" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender71" runat="server" 
                        TargetControlID="_14icom" PopupButtonID="_14icom" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            PFT COMPLETION SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_14pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender72" runat="server" 
                        TargetControlID="_14pft" PopupButtonID="_14pft" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            ENERGISATION DATE</td>
                        <td>
                            <asp:TextBox ID="_14eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender73" runat="server" 
                        TargetControlID="_14eng" PopupButtonID="_14eng" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            FPT SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_14fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender74" runat="server" 
                        TargetControlID="_14fpt" PopupButtonID="_14fpt" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            ACCEPTANCE RECOMMENDATION MADE</td>
                        <td>
                            <asp:TextBox ID="_14arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender75" runat="server" 
                        TargetControlID="_14arm" PopupButtonID="_14arm" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
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
                            
                            <asp:TextBox ID="_14actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_14commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_14actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender139" runat="server" 
                        TargetControlID="_14actdt" PopupButtonID="_14actdt" ClearTime="true" 
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
                           <asp:Button ID="_14btnupdate" runat="server" Text="Update" 
                                onclick="_14btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_14btncancel" runat="server" Text="Cancel" 
                                onclick="_14btncancel_Click" />
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
        <asp:Panel ID="pnlPopup23" runat="server" Width="825px" Height="325px" 
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
                    <tr>
                        <td width="200PX">
                            NO.OF PANEL</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24nop" runat="server" Width="75px" ReadOnly="True" ></asp:TextBox>
                        </td>
                        <td width="200PX">
                            CONTINUITY/CABLE TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24cct" runat="server" Width="75px" ></asp:TextBox>
                        </td>
                        <td width="200PX">PROGRAMMING</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24prg" runat="server" Width="75px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            POWER SUPPLY/ BATTERY BACKUP TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24pbt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            NURSE CALL ETHERNET SWITCH TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24net" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            NURSE CALL CORRIDOR LIGHT TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24nct" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            NURSE CALL AUDIO STATION TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24nat" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            NURSE CALL SINGLE BUTTON STATION TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24nst" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            NURSE CALL STAFF TERMINAL STATION TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24ntt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            NURSE CALL MASTER STATION TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24nmt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            INTERFACE TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24it" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
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
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td width="200PX">
                            INSTALLATION COMPLETION SIGN OFF [KEO]</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24icom" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_24icom_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_24icom" 
                                TargetControlID="_24icom">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            PFT COMPLETION SIGN OFF [CML]</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_24pft_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_24pft" 
                                TargetControlID="_24pft">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            ENERGISATION DATE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_24eng_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_24eng" 
                                TargetControlID="_24eng">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td width="200PX">
                            FPT SIGN OFF [CML]</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_24fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_24fpt" 
                                TargetControlID="_24fpt">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            ACCEPTANCE RECOMMENDATION MADE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_24arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_24arm_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_24arm" 
                                TargetControlID="_24arm">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            &nbsp;</td>
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
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender23" runat="server" TargetControlID="btnDummy23"  PopupControlID="pnlPopup23" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
        <asp:Panel ID="pnlPopup25" runat="server" Width="825px" Height="265px" 
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
                
                    <tr >
                        <td width="200PX" >
                            NO.OF CODE BLUE/ ELAPSED TIMERS</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_25not" runat="server" Width="75px" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            CONTINUITY/ CABLE TEST COMPLETE</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_25cct" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender173" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25cct" 
                                TargetControlID="_25cct">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            NO.OF CODE BLUE/ ELAPSED TIMERS TESTED</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_25ntt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            PRE- COMMISSIONING COMPLETE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_25pcom" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_25pcom_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25pcom" 
                                TargetControlID="_25pcom">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            COMMISSIONING COMPLETE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_25com" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_25com_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25com" 
                                TargetControlID="_25com">
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
                            &nbsp;</td>
                        <td >
                      </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            INSTALLATION COMPLETION SIGN OFF [KEO]</td>
                        <td>
                            <asp:TextBox ID="_25icom" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_25icom_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25icom" 
                                TargetControlID="_25icom">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            PFT COMPLETION SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_25pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_25pft_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25pft" 
                                TargetControlID="_25pft">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ENERGISATION DATE</td>
                        <td>
                            <asp:TextBox ID="_25eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_25eng_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25eng" 
                                TargetControlID="_25eng">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            FPT SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_25fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_25fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25fpt" 
                                TargetControlID="_25fpt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ACCEPTANCE&nbsp; RECOMMENDATION MADE</td>
                        <td>
                            <asp:TextBox ID="_25arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_25arm_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_25arm" 
                                TargetControlID="_25arm">
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
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender25" runat="server" TargetControlID="btnDummy25"  PopupControlID="pnlPopup25" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
        <asp:Panel ID="pnlPopup29" runat="server" Width="825px" Height="295px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel39" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_26lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr style="background-color:#092443;color:White">
                        <td colspan="6" align="center">
                            PRE - COMMISSIONING</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            CABLE TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_26cbt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender209" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_26cbt" 
                                TargetControlID="_26cbt">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">INSTALLATION CHECK</td>
                        <td width="75PX">
                            <asp:TextBox ID="_26inc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_26inc_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_26inc" 
                                TargetControlID="_26inc">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">&nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#092443;color:White">
                        <td colspan="6" align="center">COMMISSIONING
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">FUNCTIONAL TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_26fnt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_26fnt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_26fnt" 
                                TargetControlID="_26fnt">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">INTEGRATION/INTERFACE TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_26iit" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_26iit_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_26iit" 
                                TargetControlID="_26iit">
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
                           
                            <asp:TextBox ID="_26accept1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender210" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_36accept1" 
                                TargetControlID="_26accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            TEST SHEETS FILED</td>
                        <td >
                           
                            <asp:TextBox ID="_26filed1" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender211" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_36filed1" 
                                TargetControlID="_26filed1">
                            </asp:CalendarExtender>
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
                            <asp:TextBox ID="_26icom" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_26icom_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_26icom" 
                                TargetControlID="_26icom">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            PFT COMPLETION SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_26pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_26pft_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_26pft" 
                                TargetControlID="_26pft">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            SERVER/PANEL ENERGISATION DATE</td>
                        <td>
                            <asp:TextBox ID="_26eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_26eng_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_26eng" 
                                TargetControlID="_26eng">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            FPT SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_26fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_26fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_26fpt" 
                                TargetControlID="_26fpt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ACCEPTANCE RECOMMENDATION MADE</td>
                        <td>
                            <asp:TextBox ID="_26arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_26arm_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_26arm" 
                                TargetControlID="_26arm">
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
                            
                            <asp:TextBox ID="_26actby" runat="server" Width="250px"></asp:TextBox>
                            
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
                            <asp:CalendarExtender ID="CalendarExtender212" runat="server" 
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
                                onclick="_26btnupdate_Click"  />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_26btncancel" runat="server" Text="Cancel" 
                                onclick="_26btncancel_Click"  />
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
   <asp:Panel ID="pnlPopup10" runat="server" Width="825px" Height="300px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_17lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr style="background-color:#092443;color:White" >
                        <td colspan="6"  align="center">
                            MECHANICAL SYSTEM</td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            PRE-COMM</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_17pc1" runat="server" Width="75px"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender83" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17pc1" 
                                TargetControlID="_17pc1">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            COMM</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_17co1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender89" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17co1" 
                                TargetControlID="_17co1">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX" >
                            WITNESSED DATE</td>
                        <td width="75PX" >
                           
                            <asp:TextBox ID="_17wd1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender90" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17wd1" 
                                TargetControlID="_17wd1">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            OBTAINED VOLUME l/s</td>
                        <td width="75PX">
                            <asp:TextBox ID="_17ov" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            OBTAINED %</td>
                        <td width="75PX">
                            <asp:TextBox ID="_17ovp" runat="server" Width="75px"></asp:TextBox>
                    </td>
                        <td width="200PX">
                            WITNESSED %</td>
                        <td width="75PX">
                            <asp:TextBox ID="_17wp" runat="server" Width="75px"></asp:TextBox>
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
                             <asp:CalendarExtender ID="CalendarExtender93" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17pc2" 
                                TargetControlID="_17pc2">
                            </asp:CalendarExtender>
                             <asp:TextBox ID="_17pc2" runat="server" 
                                Width="75px"></asp:TextBox></td>
                        <td>
                            COMM</td>
                        <td>
                            <asp:TextBox ID="_17co2" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender94" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17co2" 
                                TargetControlID="_17co2">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            INSTALLATION COMPLETION SIGN OFF [KEO]</td>
                        <td>
                            <asp:TextBox ID="_17icom" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_17icom_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17icom" 
                                TargetControlID="_17icom">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            PFT COMPLETION SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_17pft" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_17pft_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17pft" 
                                TargetControlID="_17pft">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            PLANT START UP COMPLETE CONTRACTOR</td>
                        <td>
                            <asp:TextBox ID="_17eng" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_17eng_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17eng" 
                                TargetControlID="_17eng">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            FPT SIGN OFF [CML]</td>
                        <td>
                            <asp:TextBox ID="_17fpt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_17fpt_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17fpt" 
                                TargetControlID="_17fpt">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            ACCEPTANCE RECOMMENDATION MADE</td>
                        <td>
                            <asp:TextBox ID="_17arm" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_17arm_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17arm" 
                                TargetControlID="_17arm">
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
                            
                            <asp:TextBox ID="_17actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_17commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_17actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender96" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_17actdt" 
                                TargetControlID="_17actdt">
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
                           <asp:Button ID="_17btnupdate" runat="server" Text="Update" 
                                onclick="_17btnupdate_Click"/>
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_17btncancel" runat="server" Text="Cancel" 
                                onclick="_17btncancel_Click"  />
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
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender10" runat="server" TargetControlID="btnDummy10"  PopupControlID="pnlPopup10" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
         <asp:Panel ID="pnlPopup12" runat="server" Width="825px" Height="215px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px;" cellpadding="3" border="0" cellspacing="0" >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_19lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr >
                        <td width="200PX" >
                            QUANTITY&nbsp;</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_19qty" runat="server" Width="75px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            QUANTITY TESTED</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_19qt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                            WITNESSED DATE</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_19wd" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender106" runat="server" 
                        TargetControlID="_19wd" PopupButtonID="_19wd" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            TOTAL NO.OF INSTALLATION SIGNEED OFF</td>
                        <td >
                           
                            <asp:TextBox ID="_19icom" runat="server" Width="75px"></asp:TextBox>
                       </td>
                        <td >
                            TOTAL NO.OF PFT SIGNED OFF</td>
                        <td >
                           
                            <asp:TextBox ID="_19pft" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td >
                            TOTAL NO.OF FPT COMPLETED</td>
                        <td >
                            <asp:TextBox ID="_19fpt" runat="server" Width="75px"></asp:TextBox>
                      </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            TOTAL NO.OF ACCEPTANCE RECOMMENDATION MADE</td>
                        <td>
                            <asp:TextBox ID="_19arm" runat="server" Width="75px"></asp:TextBox>
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
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY&nbsp;</td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_19actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_19commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_19actdt" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender104" runat="server" 
                        TargetControlID="_19actdt" PopupButtonID="_19actdt" ClearTime="true" 
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
                           <asp:Button ID="_19btnupdate" runat="server" Text="Update" 
                                onclick="_19btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_19btncancel" runat="server" Text="Cancel" 
                                onclick="_19btncancel_Click" />
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
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender12" runat="server" TargetControlID="btnDummy12"  PopupControlID="pnlPopup12" BackgroundCssClass="modal" ></asp:ModalPopupExtender> 
        <asp:Panel ID="pnlPopup30" runat="server" Width="825px" Height="255px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_27lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                
                    <tr >
                        <td width="200PX" >
                            PRE-COMM</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_27pc1" runat="server" Width="75px" Text="N/A"></asp:TextBox>
                       </td>
                        <td width="200PX" >
                         COMMISSIONED</td>
                        <td width="75PX" >
                            
                            <asp:TextBox ID="_27comm" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX" >
                         WITNESSED DATE</td>
                        <td width="75PX" >
                            <asp:TextBox ID="_27wit" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender205" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_27wit" TargetControlID="_27wit">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-color:#092443;color:White">
                        <td colspan="6" align="center">
                         Control System</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            PRE-COMM</td>
                        <td width="75PX">
                            <asp:TextBox ID="_27pc2" runat="server" Width="75px" Text="N/A"></asp:TextBox>
                            <%--<asp:CalendarExtender ID="CalendarExtender76" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_27pc2" 
                                TargetControlID="_27pc2">
                            </asp:CalendarExtender>--%>
                        </td>
                        <td width="200PX">COMMISSIONED
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_27comm1" runat="server" Width="75px" Text="N/A"></asp:TextBox>
                            <%--<asp:CalendarExtender ID="_36lot_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_27comm" 
                                TargetControlID="_27comm">
                            </asp:CalendarExtender>--%>
                        </td>
                        <td width="200PX"></td>
                        <td width="75PX">
                            <asp:TextBox ID="_27nop" runat="server" Width="75px" style="display:none"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            INSTALLATION COMPLETION SIGN OFF[KEO]</td>
                        <td >
                           
                            <asp:TextBox ID="_27icom" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="_36CalendarExtender210" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_27icom" 
                                TargetControlID="_27icom">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            PFT COMPLETION SIGN OFF[CML]</td>
                        <td >
                           
                            <asp:TextBox ID="_27pft" runat="server" Width="75px" Text="N/A"></asp:TextBox>
                           <%--<asp:CalendarExtender ID="_36CalendarExtender211" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_27pft" 
                                TargetControlID="_27pft">
                            </asp:CalendarExtender>--%>
                        </td>
                        <td >
                            ENERGISATION DATE</td>
                        <td >
                        <asp:TextBox ID="_27eng" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender82" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_27eng" 
                                TargetControlID="_27eng">
                            </asp:CalendarExtender>
                      </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            FPT SIGN OFF[CML]</td>
                        <td>
                        <asp:TextBox ID="_27fpt" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender91" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_27fpt" 
                                TargetControlID="_27fpt">
                            </asp:CalendarExtender></td>
                        <td>
                            ACCEPTANCE RECOMMENDATION MADE</td>
                        <td>
                         <asp:TextBox ID="_27arm" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender92" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_27arm" 
                                TargetControlID="_27arm">
                            </asp:CalendarExtender></td></td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY1&nbsp;</td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_27actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS1</td>
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
                            <asp:CalendarExtender ID="_36CalendarExtender212" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_27actdt" 
                                TargetControlID="_27actdt">
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
                           <asp:Button ID="_27btnupdate" runat="server" Text="Update" 
                                onclick="_27btnupdate_Click"  />
                           
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
                 <div  runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress9" runat="server" >
            <ProgressTemplate>
                <asp:Image runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        
        <!--  -->
        
                       
                <asp:Panel ID="pnlPopup112" runat="server" Width="825px" Height="220px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_112lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            INSTALLATION COMPLETION SIGN OFF[KEO]</td>
                        <td >
                           
                            <asp:TextBox ID="_112icom" runat="server" Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender135" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_112icom" 
                                TargetControlID="_112icom" />
                        </td>
                        <td >
                            PFT COMPLETION SIGN OFF[CML]</td>
                        <td >
                           
                            <asp:TextBox ID="_112pft" runat="server" Width="75px" Text="N/A"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender134" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_112pft" 
                                TargetControlID="_112pft" />
                        </td>
                        <td >
                            PLANT START UP COMPLETE CONTRACTOR</td>
                        <td >
                         <asp:TextBox ID="_112txtpscc" runat="server" Width="75px" Text="N/A"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender122" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_112txtpscc" 
                                TargetControlID="_112txtpscc" />
                      </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                           SYSTEM CONTRACTOR CHECKS COMPLETED</td>
                        <td>
                             <asp:TextBox ID="_112sycc" runat="server" Width="75px" Text="N/A"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender119" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_112sycc" 
                                TargetControlID="_112sycc" />
                            </td>
                        <td>
                            PFT COMPLETION</td>
                        <td>
                             <asp:TextBox ID="_112pftc" runat="server" Width="75px" Text="N/A"></asp:TextBox>
                              <asp:CalendarExtender ID="CalendarExtender118" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_112pftc" 
                                TargetControlID="_112pftc" />
                            </td>
                        <td>
                            3RD PARTY VORIFICATION
                            </td>
                        <td>
                             <asp:TextBox ID="_1123rd" runat="server" Width="75px" Text="N/A"></asp:TextBox>
                               <asp:CalendarExtender ID="CalendarExtender109" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_1123rd" 
                                TargetControlID="_1123rd" />
                            </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            FPT SIGN OFF[CML]</td>
                        <td>
                        <asp:TextBox ID="_112fpt" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender103" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_112fpt" 
                                TargetControlID="_112fpt">
                            </asp:CalendarExtender></td>
                        <td>
                            ACCEPTANCE RECOMMENDATION MADE</td>
                        <td>
                         <asp:TextBox ID="_112arm" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender105" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_112arm" 
                                TargetControlID="_112arm">
                            </asp:CalendarExtender></td></td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td>
                            ACTION BY</td>
                        <td colspan="2">
                            
                            <asp:TextBox ID="_112actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_112commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td>
                            
                            <asp:TextBox ID="_112actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender107" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_112actdt" 
                                TargetControlID="_112actdt">
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
                           <asp:Button ID="_112btnupdate" runat="server" Text="Update" 
                                onclick="_112btnupdate_Click"  />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_112btncancel" runat="server" Text="Cancel" 
                                onclick="_112btncancel_Click"  />
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
                 <div id="Div7"  runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress25" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy112" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender112" runat="server" TargetControlID="btnDummy112"  PopupControlID="pnlPopup112" BackgroundCssClass="modal" ></asp:ModalPopupExtender>    
        <!-- -->
        
        <asp:Button ID="btnDummy30" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender30" runat="server" TargetControlID="btnDummy30"  PopupControlID="pnlPopup30" BackgroundCssClass="modal" ></asp:ModalPopupExtender>    
        <asp:Panel ID="pnlPopup26" runat="server" Width="825px" Height="310px" 
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
                        <td colspan="6" style="background-color: #092443;color:#fff" 
                            align="center"  >
                            Mechanical System</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            PRE-COMM
                        </td>
                        <td width="75PX">
                            <asp:TextBox ID="_28pcom" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender182" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_28pcom" TargetControlID="_28pcom">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            COMM</td>
                        <td width="75PX">
                            <asp:TextBox ID="_28com" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender183" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_28com" TargetControlID="_28com">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            WITNESSED DATE</td>
                        <td width="75PX">
                            <asp:TextBox ID="_28wtd" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender184" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="_28wtd" TargetControlID="_28wtd">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            OPERATIONAL TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_28opt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_28pc3_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_28opt" 
                                TargetControlID="_28opt">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            ACCEPTANCE TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_28act" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_28pc4_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_28act" 
                                TargetControlID="_28act">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                         RELIABILITY TEST</td>
                        <td width="75PX">
                        <asp:TextBox ID="_28rlt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender76" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_28rlt" 
                                TargetControlID="_28rlt">
                            </asp:CalendarExtender></td>
                    </tr>
                    <tr>
                        <td width="200PX">
                         COMPLETION OF ACCEPTANCE TESTING</td>
                        <td width="75PX">
                         <asp:TextBox ID="_28cat" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender95" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_28cat" 
                                TargetControlID="_28cat">
                            </asp:CalendarExtender></td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            GRAPHICS/ HEADEND TEST</td>
                        <td width="75PX">
                           <asp:TextBox ID="_28ght" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender97" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_28ght" 
                                TargetControlID="_28ght">
                            </asp:CalendarExtender></td>
                        <td width="200PX">
                            3 MONTH EVALUATION</td>
                        <td width="75PX">
                            <asp:TextBox ID="_283me" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender98" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_283me" 
                                TargetControlID="_283me">
                            </asp:CalendarExtender></td>
                        <td width="200PX">
                            6 MONTH EVALUATION</td>
                        <td width="75PX">
                          <asp:TextBox ID="_286me" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender99" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_286me" 
                                TargetControlID="_286me">
                            </asp:CalendarExtender></td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            INSTALLATION COMPLETION SIGN OFF</td>
                        <td >
                           
                            <asp:TextBox ID="_28icom" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender185" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_28icom" 
                                TargetControlID="_28icom">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            PFT COMPLETION SIGN OFF</td>
                        <td >
                           
                            <asp:TextBox ID="_28pft" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender186" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_28pft" 
                                TargetControlID="_28pft">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            PLANT START UP COMPLETE</td>
                        <td >
                        <asp:TextBox ID="_28psc" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender100" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_28psc" 
                                TargetControlID="_28psc">
                            </asp:CalendarExtender>
                      </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            FPT SIGN OFF</td>
                        <td>
                         <asp:TextBox ID="_28fpt" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender101" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_28fpt" 
                                TargetControlID="_28fpt">
                            </asp:CalendarExtender></td>
                        <td>
                            ACCEPTANCE RECOMMENDATION MADE</td>
                        <td>
                           <asp:TextBox ID="_28arm" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender102" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_28arm" 
                                TargetControlID="_28arm">
                            </asp:CalendarExtender></td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
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
        <asp:Panel ID="pnlPopup27" runat="server" Width="825px" Height="290px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px" >
                            <asp:Label ID="_29lbl" runat="server" ForeColor="White"></asp:Label>
                       </td>
                    </tr>
                
                    <tr>
                        <td width="200PX">
                         CONTINUITY/ CABLE TEST
                        </td>
                        <td >
                            <asp:TextBox ID="_29cct" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            PROGRAMMING</td>
                        <td width="75PX">
                            <asp:TextBox ID="_29prg" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                            NO. OF CHANNELS/ MODULES TESTED</td>
                        <td width="75PX">
                            <asp:TextBox ID="_29nmt" runat="server" Width="75px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            POINT TEST COMPLETE</td>
                        <td >
                            <asp:TextBox ID="_29ptc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender111" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_29ptc" 
                                TargetControlID="_29ptc">
                            </asp:CalendarExtender>
                        </td>
                        <td width="200PX">
                            SEQ OF OP TEST</td>
                        <td width="75PX">
                            <asp:TextBox ID="_29sop" runat="server" Width="75px"></asp:TextBox>
                        </td>
                        <td width="200PX">
                         GRAPHICS TEST</td>
                        <td width="75PX">
                        <asp:TextBox ID="_29grt" runat="server" Width="75px"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td width="200PX">
                            INTEGRATION/ INTERFACE TEST</td>
                        <td >
                         <asp:TextBox ID="_29iit" runat="server" Width="75px"></asp:TextBox>
                         <asp:CalendarExtender ID="CalendarExtender121" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_29iit" 
                                TargetControlID="_29iit">
                            </asp:CalendarExtender>
                            </td>
                        <td width="200PX">
                         <asp:TextBox ID="_29noc" runat="server" Width="75px" style="display:none"></asp:TextBox></td>
                        <td width="75PX">
                            &nbsp;</td>
                        <td width="200PX">
                            &nbsp;</td>
                        <td width="75PX">
                            &nbsp;</td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td >
                            INSTALLATION COMPLETION SIGN OFF</td>
                        <td >
                           
                            <asp:TextBox ID="_29icom" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender142" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_29icom" 
                                TargetControlID="_29icom">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            PFT COMPLETION SIGN OFF</td>
                        <td >
                           
                            <asp:TextBox ID="_29pft" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender143" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_29pft" 
                                TargetControlID="_29pft">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            ENERGISATION DATE</td>
                        <td >
                        <asp:TextBox ID="_29eng" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender144" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_29eng" 
                                TargetControlID="_29eng">
                            </asp:CalendarExtender>
                      </td>
                    </tr>
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            FPT SIGN OFF</td>
                        <td >
                         <asp:TextBox ID="_29fpt" runat="server" Width="75px"></asp:TextBox>
                          <asp:CalendarExtender ID="CalendarExtender146" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_29fpt" 
                                TargetControlID="_29fpt">
                            </asp:CalendarExtender>
                          </td>
                        <td>
                            ACCEPTANCE RECOMMENDATION MADE</td>
                        <td>
                           <asp:TextBox ID="_29arm" runat="server" Width="75px"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender147" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_29arm" 
                                TargetControlID="_29arm">
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
                        <td >
                            <asp:TextBox ID="_29accept1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_29fpt0_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_29accept1" 
                                TargetControlID="_29accept1">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                         TEST SHEETS FILED</td>
                        <td>
                            <asp:TextBox ID="_29filed1" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="_29fpt1_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_29filed1" 
                                TargetControlID="_29filed1">
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
                            
                            <asp:TextBox ID="_29actby" runat="server" Width="250px"></asp:TextBox>
                            
                        </td>
                        <td>
                            COMMENTS</td>
                        <td colspan="2" rowspan="2">
                            
                            <asp:TextBox ID="_29commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE">
                        <td>
                            ACTION DATE</td>
                        <td class="style1">
                            
                            <asp:TextBox ID="_29actdt" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender151" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_29actdt" 
                                TargetControlID="_29actdt">
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
                        <td align="right" class="style1">
                           <asp:Button ID="_29btnupdate" runat="server" Text="Update" 
                                onclick="_29btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_29btncancel" runat="server" Text="Cancel" 
                                onclick="_29btncancel_Click" />
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
        <asp:UpdateProgress ID="UpdateProgress12" runat="server" >
            <ProgressTemplate>
                <asp:Image runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy27" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender27" runat="server" TargetControlID="btnDummy27"  PopupControlID="pnlPopup27" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
        
        
         <asp:Panel ID="pnlPopup_" runat="server" Width="300px" Height="100px" 
                style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                <ContentTemplate>
                <p><b>UPDATE NUMBER OF CIRCUITS</b></p>
                <table style="font-size:x-small;width:300px" border="0" cellpadding="3" cellspacing="0"  >
                <tr>
                <td style="width:200px">Enter number of Circuits</td>
                <td style="width:100px">
                    <asp:TextBox ID="txt_noofcircuit" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                <td colspan="2">
                    <asp:Button ID="btnsave" runat="server" Text="Update" onclick="btnsave_Click" />
                    <asp:Button ID="btncan" runat="server" Text="Cancel" onclick="btncan_Click" /></td>
                </tr>
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
                 <div  runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress19" runat="server" >
            <ProgressTemplate>
                <asp:Image runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
               
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy_" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender_" runat="server" TargetControlID="btnDummy_"  PopupControlID="pnlPopup_" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
    </div>
    </form>
</body>
</html>
