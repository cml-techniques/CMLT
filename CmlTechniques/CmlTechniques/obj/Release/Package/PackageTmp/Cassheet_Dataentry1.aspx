<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cassheet_Dataentry1.aspx.cs" Inherits="CmlTechniques.Cassheet_Dataentry1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="page.css" rel="stylesheet" type="text/css" />
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: verdana; font-size: x-small;height:100%;position:fixed;width:100%">
    <asp:Label ID="lblref" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <table style="width:100%;color:White" bgcolor="#092443">
        <tr>
        <td  colspan="6" style="background-color: #D2F1FC" >
            <asp:Label ID="lblhead" runat="server" Font-Bold="True" Font-Size="Small" 
                ForeColor="Black" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
        <td width="100px" >
            &nbsp;</td>
            <td><table>
        <tr>
        <td style="width:100px" align="center"> &nbsp;</td>
        <td style="width:200px">
            <asp:UpdatePanel ID="UpdatePanel21" runat="server">
            <ContentTemplate>
             <asp:TextBox ID="txtsearch" runat="server" Width="200px"></asp:TextBox>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td>
        <asp:UpdatePanel ID="UpdatePanel20" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnsearch" runat="server" Text="Search" Width="75px" 
                    onclick="btnsearch_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel18" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnedit" runat="server" Text="Edit" onclick="btnedit_Click" Width="75px" />
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
            <ContentTemplate>
            <asp:Button ID="btndelete1" runat="server" Text="Delete" Width="75px" 
                    onclick="btndelete1_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
        </table></td>
        <td width="250px" >
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drpackage" runat="server" 
                Width="250px" AutoPostBack="True" 
                onselectedindexchanged="drpackage_SelectedIndexChanged" style="display:none">
                                </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
                                
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnimport" runat="server" Text="Import From Excel" 
                                            onclick="btnimport_Click" style="display:none" />
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                    <ContentTemplate>
                                        <asp:ImageButton ID="btnrefresh" runat="server" 
                                            ImageUrl="~/images/refresh1.png" onclick="btnrefresh_Click" style="display:none" />
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
        <td width="100%" align="right" >
        
            <asp:Label ID="lblsch" runat="server" Text="" CssClass="hidden"></asp:Label>
            <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label>
        </td>
        </tr>
        </table>
        <div style="width:1031px;float:left;position:relative;">
        <table style="font-family: Verdana;font-size:x-small;background-color:#9EB6CE;" cellspacing="1" border="0"  id="tbl" runat="server" >
                        <tr style="background-image: url('images/head_bg.png'); background-repeat: repeat-x;height:30px" >
       
                            <td align="center" valign="middle"   width="100px">
                                &nbsp;</td>       
                            <td align="center" valign="middle"   width="100px">
                                ITEM NO</td>
       
                            <td align="center" valign="middle"   width="100px">
                                <asp:Label ID="lbl1" runat="server" Text=""></asp:Label>
                            </td>
                            <td align="center" valign="middle" width="100px" id="op1" runat="server"  >
                                <asp:Label ID="lbl2" runat="server" Text=""></asp:Label>
                            </td>
                            <td align="center" valign="middle" width="100px" id="op2" runat="server"  >
                                <asp:Label ID="lbl3" runat="server" Text=""></asp:Label>
                            </td>
                            <td align="center" valign="middle" width="100px"  >
                                <asp:Label ID="lbl4" runat="server" Text=""></asp:Label>
                            </td>
                            <td align="center" valign="middle" width="100px" id="op3" runat="server" >
                                NO. OF INTERFACES COMPLETED</td>
                            <td align="center" valign="middle" width="100px"  >
                                COMPLETE DATE</td>
                            <td align="center" valign="middle" width="100px" id="op4" runat="server"  >
                                INTERFACES/ TESTS SIGNED OFF</td>
                            <td align="center" valign="middle" width="100px"  >
                                SIGNED OFF</td>
                        </tr>
                        <tr bgcolor="#092443">
            <td align="center">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                <asp:Button ID="btnadd" runat="server" Text="add" onclick="btnadd_Click" 
                                                    Width="100px" />
                </ContentTemplate>
                </asp:UpdatePanel>
                                                
                                                </td>
            <td>
                &nbsp;</td>
            <td style="background-color:#FFF" align="center">
                                <asp:TextBox ID="txtengref" runat="server" Width="95%" style="border:none"></asp:TextBox>
                                            </td>
            <td id="op1_1" runat="server" style="background-color:#FFF" align="center">
                                <asp:TextBox ID="txt1" runat="server" Width="95%" style="border:none"></asp:TextBox>
                                            </td>
            <td id="op2_1" runat="server" style="background-color:#FFF" align="center">
                                <asp:TextBox ID="txt2" runat="server" Width="95%" style="border:none"></asp:TextBox>
                                            </td>
            <td style="background-color:#FFF" align="center">
                                <asp:TextBox ID="txt_no" runat="server" Width="95%" style="border:none"></asp:TextBox>
                                            </td>
            <td id="op3_1" runat="server">
                                &nbsp;</td>
            <td>
                                &nbsp;</td>
            <td id="op4_1" runat="server">
                                &nbsp;</td>
            <td>
                                &nbsp;</td>
        </tr>
        <tr bgcolor="#092443" >
            <td>
             
                 <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                 <ContentTemplate>
                 <asp:Button ID="btnexpand" runat="server" Text="Exp.All" Width="100px"
                         onclick="btnexpand_Click" ForeColor="Red" Font-Size="X-Small" style="cursor:pointer" />
                 </ContentTemplate>
                 </asp:UpdatePanel>
                
             </td>
            <td>
              <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                 <ContentTemplate>
                 <asp:Button ID="btncollapse" runat="server" Text="Coll.All" Width="100px" 
                         ForeColor="Red" Font-Size="X-Small" style="cursor:pointer" 
                         onclick="btncollapse_Click" />
                 </ContentTemplate>
                 </asp:UpdatePanel></td>
            <td>
                &nbsp;</td>
            <td id="op1_3" runat="server">
                &nbsp;</td>
            <td id="op2_3" runat="server">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td id="op3_3" runat="server">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td id="op4_3" runat="server">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
                        </table>
        </div>
        <%--<div style="position:relative; height:67%;width:1000px;overflow-y:scroll;float:left" id="_div" runat="server">--%>
        <div style="position:relative; height:100%;width:1031px;float:left" id="_div" runat="server">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            
                <asp:GridView ID="mydetails" runat="server" ShowHeader="false" AutoGenerateColumns="false"  OnRowCommand="mydetails_RowCommand" OnRowDataBound="mydetails_RowDataBound" Font-Names="Verdana" 
                    Font-Size="X-Small" Width="1031px" >
                <Columns>
                
                <%--<asp:ButtonField ButtonType="Button" Text="Update" CommandName="Get"
                        ItemStyle-Width="100px" >
                    <ItemStyle Width="100px"  />
                    </asp:ButtonField>--%>
                <asp:TemplateField >
                <ItemTemplate>
                    <asp:CheckBox ID="chkrow" runat="server" OnCheckedChanged="chkrow_CheckedChanged" AutoPostBack="true" />
                </ItemTemplate>
                <ItemStyle Width="100px" HorizontalAlign="Center"  />
                </asp:TemplateField>    
                
                <asp:BoundField HeaderText="Itm.No" ItemStyle-Width="100px" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField ="E_b_ref" HeaderText="Engg.Reff" ItemStyle-Width="100px" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                 <asp:BoundField DataField="B_Z" HeaderText="Building/Zone" ItemStyle-Width="100px" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>  
                <asp:BoundField DataField="cat" HeaderText="Category" ItemStyle-Width="100px" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="devices1" ItemStyle-Width="100px" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test3" ItemStyle-Width="100px" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test1" ItemStyle-Width="100px" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test4" ItemStyle-Width="100px" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test2" ItemStyle-Width="100px" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="C_id" />
                </Columns>
                </asp:GridView>
           
            </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        <%--<div id="myprogress" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <%--<asp:Image ID="imgload" runat="server" ImageUrl="images/loading.gif" Height="200px" Width="250px" />--%>
            <%--</ProgressTemplate>
       </asp:UpdateProgress>
        </div>--%>
        <asp:Panel ID="pnlPopup1" runat="server" Width="400px" style="padding:15px;background-color:#83C8EE;" >
            <div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                
                <div>
                <table style="width:400px;background-color:White;">
                    <tr id="tr3" runat="server">
                        <td width="150px">
                            <asp:Label ID="lb1" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="up_reff" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr4" runat="server">
                        <td width="150px">
                            <asp:Label ID="lb2" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="uplb2" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr5" runat="server">
                        <td width="150px">
                            <asp:Label ID="lb3" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="uplb3" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            <asp:Label ID="lb4" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="uplb4" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr6" runat="server">
                        <td width="150px">
                            NO. OF INTERFACES COMPLETED</td>
                        <td>
                            <asp:TextBox ID="txt_icomp" runat="server" Width="75px"></asp:TextBox>
</td>
                    </tr>
                    <tr>
                        <td width="150px">
                            COMPLETE DATE</td>
                        <td>
                            <asp:TextBox ID="txt_dtc" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender116" runat="server" 
                        TargetControlID="txt_dtc" PopupButtonID="txt_dtc" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender></td>
                    </tr>
                    <tr id="tr7" runat="server">
                        <td width="150px">
                            INTERFACES/ TESTS SIGNED OFF</td>
                        <td>
                            <asp:TextBox ID="txt_isoff" runat="server" Width="75px"></asp:TextBox>
</td>
                    </tr>
                    <tr>
                        <td width="150px">
                            SIGNED OFF</td>
                        <td>
                            <asp:TextBox ID="txt_sof" runat="server" Width="75px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="txt_sof" PopupButtonID="txt_sof" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender></td>
                    </tr>
                    <tr>
                        <td width="150px">
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="txt_not" runat="server" CssClass="hidden"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                        <table>
                        <tr>
                        <td> <asp:Button ID="btnupdate" runat="server" Text="Update" 
                                onclick="btnupdate_Click" /></td>
                        <td><asp:Button ID="btndelete" runat="server" Text="Delete" onclick="btndelete_Click" style="display:none"
                                 /></td>
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
            </div>
                        
                  </asp:Panel>
                  
                    <asp:Button ID="btnDummy" runat="server" Text="Button" style="display:none;" />
                  <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" 
                  TargetControlID="btnDummy"  PopupControlID="pnlPopup1"
                  BackgroundCssClass="modal" >
                  </asp:ModalPopupExtender> 
           
    </div>
    </form>
</body>
</html>
