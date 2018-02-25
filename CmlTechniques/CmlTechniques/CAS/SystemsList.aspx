<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemsList.aspx.cs" Inherits="CmlTechniques.CAS.SystemsList" %>

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
         <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" AsyncPostBackTimeout="1000">
         </asp:ToolkitScriptManager>
        <asp:Label ID="lblsch" runat="server" Text="" CssClass="hidden"></asp:Label>
        <table style="width:100%;color:White" bgcolor="#092443">
        <tr>
        <td width="100%" style="background-color: #D2F1FC" >
            <asp:Label ID="lblhead" runat="server" Font-Bold="True" Font-Size="Small" 
                ForeColor="Black" Text="Systems List"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:Button ID="btnupdate" runat="server" Text="Update" Width="75px" 
                        onclick="btnupdate_Click" />
                </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <asp:Button ID="btnprint" runat="server" Text="Print" Width="75px" 
                        onclick="btnprint_Click" />
                </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
        </tr>
        </table>
        <div style="float:left;width:98.6%">
        <table style="font-family: Verdana;font-size:x-small;background-color:#9EB6CE;width:100%;" cellspacing="1" border="0" >
       <tr  style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
       
                            <td align="center" rowspan="2" valign="middle"   width="5%">
                                &nbsp;</td>       
                            <td align="center" rowspan="2" valign="middle"   width="18%">
                                System</td>
       
                            <td align="center" rowspan="2" valign="middle"   width="4%">
                                Critical System</td>
                            <td align="center" colspan="2" valign="middle"  >
                                Responsible Person</td>
                            <td align="center" colspan="8" valign="middle"  >
                                SSJV Progress to Date (%)</td>
                            <td align="center" colspan="8" valign="middle"  >
                                CML Progress to Date (%)</td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td align="center" valign="middle"  width="4%"  >
                                SSJV</td>
                            <td align="center" valign="middle" width="4%"  >
                                CML</td>
                            <td align="center" valign="middle" width="4%"  >
                                D&amp;T</td>
                            <td align="center" valign="middle" width="4%"  >
                                Clinic</td>
                            <td align="center" valign="middle" width="4%"  >
                                Gallery</td>
                            <td align="center" valign="middle" width="4%"  >
                                Patient Tower</td>
                            <td align="center" valign="middle" width="4%"  >
                                Swing</td>
                            <td align="center" valign="middle" width="4%"  >
                                ICU</td>
                            <td align="center" valign="middle" width="4%"  >
                                CUP</td>
                            <td align="center" valign="middle" width="4%"  >
                                Car Park</td>
                            <td align="center" valign="middle" width="4%"  >
                                D&amp;T</td>
                            <td align="center" valign="middle" width="4%"  >
                                Clinic</td>
                            <td align="center" valign="middle" width="4%"  >
                                Gallery</td>
                            <td align="center" valign="middle" width="4%"  >
                                Patient Tower</td>
                            <td align="center" valign="middle" width="4%"  >
                                Swing</td>
                            <td align="center" valign="middle" width="4%"  >
                                ICU</td>
                            <td align="center" valign="middle" width="4%"  >
                                CUP</td>
                            <td align="center" valign="middle" width="4%"  >
                                Car Park</td>
                        </tr>
                        </table>
        </div>
        <div style="position:relative; height:85%;width:100%;overflow-y:scroll;float:left;left:0">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            <asp:GridView ID="mymaster" runat="server" AutoGenerateColumns="False" 
                Width="100%" onrowdatabound="mymaster_RowDataBound" 
                Font-Names="Verdana" CellPadding="0"
                    Font-Size="X-Small" ShowHeader="False" GridLines="None">
            <Columns>
            <asp:TemplateField>
            <ItemTemplate>
            <table  width="100%" border="0" >
            <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
            <td style="width:50px">
            
                <asp:Button ID="Button1" runat="server" Text="-" CommandArgument = "Button1"  OnClick = "Button1_Click" Width="30px" style="cursor:pointer" />
                </td>
            <td style="font-weight: bold;width:100%" align="left">
            <table cellpadding="0" cellspacing="0" border="0">
            <td><%--<asp:CheckBox ID="chkrow1" runat="server" OnCheckedChanged="chkrow1_CheckedChanged" AutoPostBack="true" />--%></td>
            <td >
            <asp:Label ID="lbSys_Name" runat="server" Text='<%# Eval("PRJ_SER_NAME") %>' Width="500px"></asp:Label>
                <asp:Label ID="lbSys_Id" runat="server" Text='<%# Eval("PRJ_SER_ID") %>' style="display:none"></asp:Label>
            </td>
            </table>
                
            </td>
            </tr>
            <tr>
            <td colspan="2">
               <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>--%>
                <asp:GridView ID="mydetails" runat="server" ShowHeader="false" AutoGenerateColumns="false" Width="100%" OnRowCommand="mydetails_RowCommand" OnRowDataBound="mydetails_RowDataBound" Font-Names="Verdana" 
                    Font-Size="X-Small" GridLines="None" CellPadding="0" >
                <Columns>
                <%--<asp:ButtonField ButtonType="Button" Text="Update" CommandName="Get"
                        ItemStyle-Width="6%" >
                    <ItemStyle Width="6%"  />
                    </asp:ButtonField>--%>
                <asp:TemplateField >
                <ItemTemplate>
                    <table style="width:100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="height:25px;background-color:#63d8fe">
                    <td><%--<asp:CheckBox ID="chkrow" runat="server" OnCheckedChanged="chkrow_CheckedChanged" AutoPostBack="true" />--%></td>
                    <td style="width:100%"; align="left">
                    <asp:Label ID="lbcas_Name" runat="server" Text='<%# Eval("PRJ_CAS_NAME") %>' Width="500px"></asp:Label>
                    <asp:Label ID="lbcas_Id" runat="server" Text='<%# Eval("PRJ_CAS_ID") %>' style="display:none"></asp:Label>
                    </td>
                    </tr>
                    <tr >
                    <td colspan="2">
                    <asp:GridView ID="mydetails1" runat="server" ShowHeader="false" AutoGenerateColumns="false" Width="100%" Font-Names="Verdana" 
                    Font-Size="X-Small" OnRowDataBound="mydetails1_RowDataBound" BorderColor="#CCCCC" >
                    <RowStyle BorderColor="#CCC" />
                    <Columns>
                    <asp:TemplateField>
                    <ItemTemplate >
                    <asp:CheckBox ID="chkselect" runat="server"  />
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="3%" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="sys_name" ItemStyle-Width="18%"  />
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="Critical" />
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="Responsible"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="Responsible"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="P1"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="P2"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="P3"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="P4"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="P5"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="P6"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="P13"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="P14"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="sys_id" />
                    <asp:BoundField DataField="sch_id" />
                    <asp:BoundField DataField="Sys_List_Id" />
                    </Columns>
                    </asp:GridView>
                    </td>
                    </tr>
                    <tr>
                    <td colspan="2">
                    <asp:GridView ID="mydetails2" runat="server" ShowHeader="false" AutoGenerateColumns="false" Width="100%"  Font-Names="Verdana" 
                    Font-Size="X-Small" GridLines="None" CellPadding="0" OnRowDataBound="mydetails2_RowDataBound"  >
                    <Columns>
                    <asp:TemplateField>
                    <ItemTemplate>
                    <table style="width:100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="height:25px;background-color:#c6f9fd">
                    <td></td>
                    <td>
                    <asp:Label ID="lblcas_sub" runat="server" Text='<%# Eval("PRJ_CAS_NAME") %>' Width="500px"></asp:Label>
                    <asp:Label ID="lblcas_subid" runat="server" Text='<%# Eval("PRJ_CAS_ID") %>' style="display:none"></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td colspan="2">
                    <asp:GridView ID="mydetails3" runat="server" ShowHeader="false" AutoGenerateColumns="false" Width="100%" Font-Names="Verdana" 
                    Font-Size="X-Small" OnRowDataBound="mydetails3_RowDataBound" >
                    <Columns>
                    <asp:TemplateField>
                    <ItemTemplate >
                    <asp:CheckBox ID="chkselect" runat="server"  />
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="3%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="sys_name" ItemStyle-Width="18%"  />
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="Critical" />
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="Responsible"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="Responsible"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="P1"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="P2"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="P3"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="P4"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="P5"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="P6"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="P13"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" DataField="P14"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="sys_id" />
                    <asp:BoundField DataField="sch_id" />
                    <asp:BoundField DataField="Sys_List_Id" />
                    </Columns>
                    </asp:GridView>
                    </td>
                    </tr>
                    </table>
                    </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                    </asp:GridView>
                    </td>
                    </tr>
                    </table>
                </ItemTemplate>
                </asp:TemplateField>    
                
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
        <%--<div id="myprogress" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div>--%>
         <div id="Div1" runat="server" style="position:absolute; z-index:40;top:40%;left: 45%">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload1" runat="server" ImageUrl="../images/loading45.gif" Height="100px" Width="100px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div>
        <asp:Panel ID="pnlPopup" runat="server" Width="400px" style="padding:15px;background-color:#83C8EE;display:none" >
            <div>
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                <ContentTemplate>
                <div>
                <table style="width:400px;background-color:White;">
                <tr>
                <td width="250px">Critical System</td>
                    <td width="150px">
                        <asp:RadioButtonList ID="rd_critical" runat="server" 
                            RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">YES</asp:ListItem>
                            <asp:ListItem Value="0">NO</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                    <tr>
                        <td width="150px">
                            Responsible Person</td>
                        <td>
                            <asp:RadioButtonList ID="rd_resp" runat="server" 
                                RepeatDirection="Horizontal">
                                <asp:ListItem Value="0">SISJV</asp:ListItem>
                                <asp:ListItem Value="1">CML</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            D&amp;T</td>
                        <td>
                            <asp:TextBox ID="txt_p1" runat="server" Width="100px" AutoPostBack="true"
                                ontextchanged="txt_p1_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            CLINIC</td>
                        <td>
                            <asp:TextBox ID="txt_p2" runat="server" Width="100px" AutoPostBack="true" 
                                ontextchanged="txt_p2_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            GALLERY</td>
                        <td>
                            <asp:TextBox ID="txt_p3" runat="server" Width="100px" AutoPostBack="true" 
                                ontextchanged="txt_p3_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr0" runat="server">
                        <td width="150px">
                            PATIENT TOWER</td>
                        <td>
                            <asp:TextBox ID="txt_p4" runat="server" Width="100px" AutoPostBack="true" 
                                ontextchanged="txt_p4_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr1" runat="server">
                        <td width="150px">
                            SWING</td>
                        <td>
                            <asp:TextBox ID="txt_p5" runat="server" Width="100px" AutoPostBack="true" 
                                ontextchanged="txt_p5_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr2" runat="server">
                        <td width="150px">
                            ICU</td>
                        <td>
                            <asp:TextBox ID="txt_p6" runat="server" Width="100px" AutoPostBack="true" 
                                ontextchanged="txt_p6_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                     <tr id="tr3" runat="server">
                        <td width="150px">
                            CUP</td>
                        <td>
                            <asp:TextBox ID="txt_p7" runat="server" Width="100px" AutoPostBack="true" 
                                ontextchanged="txt_p7_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                     <tr id="tr4" runat="server">
                        <td width="150px">
                            CAR PARK</td>
                        <td>
                            <asp:TextBox ID="txt_p8" runat="server" Width="100px" AutoPostBack="true" 
                                ontextchanged="txt_p8_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                        <table>
                        <tr>
                        <td> 
                            <asp:Button ID="btnupdate1" runat="server" Text="Update" onclick="btnupdate1_Click" 
                                 /></td>
                        <td></td>
                        <td><asp:Button ID="btncancel" runat="server" Text="Cancel" 
                                onclick="btncancel_Click" /></td>
                        </tr>
                        </table>
                        
                        
                       </td>
                    </tr>
                </table>
               
                </div>
             </ContentTemplate>
                </asp:UpdatePanel>
                <div id="myprogress" runat="server" style="position:absolute; z-index:40;top:40%;left: 45%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading45.gif" Height="100px" Width="100px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div>
            </div>
                        
                  </asp:Panel>
                  
                    <asp:Button ID="btnDummy" runat="server" Text="Button" style="display:none;" />
                  <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" 
                  TargetControlID="btnDummy"  PopupControlID="pnlPopup"
                  BackgroundCssClass="modal">
                  </asp:ModalPopupExtender> 
        <asp:Panel ID="pnlPopup1" runat="server" Width="250px" style="padding:15px;background-color:#83C8EE;display:none" >
            <div>
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                <ContentTemplate>
                
                <div>
                <table style="width:250px; background-color:White;">
                <tr>
                <td style="width:150px">ENTER FLOOR LEVEL</td>
                <td style="width:100px">
                    <asp:TextBox ID="txtflvl" runat="server"></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                        <td colspan="2" align="center">
                        <table>
                        <tr>
                        <td> <asp:Button ID="btnsave" runat="server" Text="Save"  /></td>
                        <td><asp:Button ID="btncancel1" runat="server" Text="Cancel" 
                                 /></td>
                        </tr>
                        </table>
                        
                        
                       </td>
                    </tr>
                </table>
               
                </div>
             </ContentTemplate>
                </asp:UpdatePanel>
            </div>
                        
                  </asp:Panel>
                  
                    <asp:Button ID="btnDummy1" runat="server" Text="Button" style="display:none;" />
                  <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender1" runat="server" 
                  TargetControlID="btnDummy1"  PopupControlID="pnlPopup1"
                  BackgroundCssClass="modal">
                  </asp:ModalPopupExtender>           
    </div>
    </form>
</body>
</html>
