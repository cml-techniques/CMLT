<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteObservation.aspx.cs" Inherits="CmlTechniques.CMS.SiteObservation" %>

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
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%;font-family: verdana; font-size: x-small;">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label>
        <div class="title_class1 blue_dark">
        <div class="boxtitle">
        <h2>Commissioning Snags/ Work Outstanding Summary</h2>
        </div>
        <div class="boxbutton">
            <table>
            <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnadd" runat="server" Text="Add New" onclick="btnadd_Click1" />
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <%--<asp:ImageButton ID="btnprint" runat="server" 
                    ImageUrl="~/images/print_icon.png" onclick="btnprint_Click" />--%>
                    <asp:Button ID="btn_print" runat="server" Text="" 
                        style="background-image:url('../images/print_icon.png')" Width="30px" 
                        Height="30px" onclick="btn_print_Click" />
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            </tr>
            </table>
        </div>
        <div style="clear:both"></div>
        </div>
        <div style="height:100%">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            <table  border="1" 
                                    style="border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;" width="100%">
            <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat;">
            <td style="width:5%; height:30px" align="center">ITEM</td>
            <td style="width:10%" align="center">DISCIPLINE</td>
            <td style="width:7%" align="center">BUILDING</td>
            <td style="width:7%" align="center">SNAG LIST REF.</td>
                <td align="center" style="width:5%">
                    NO. OF SNAGS</td>
            <td style="width:28%" align="center">DETAILS</td>
            <td style="width:6%" align="center">DATE SUBMITTED</td>
            <td style="width:15%" align="center">ACTION BY</td>
            <td style="width:6%" align="center">SNAG LIST ITEM NO(S) CLEARED</td>
                <td align="center" style="width:6%">
                    DATE COMPLETED</td>
                <td align="center" style="width:5%">
                    &nbsp;</td>
            </tr>
       
                <tr style="background-color:#092443">
                    <td align="center" style="width:5%;">
                        &nbsp;</td>
                    <td align="center" style="width:10%">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="dr_service" runat="server" Width="100%" 
                                AutoPostBack="true" onselectedindexchanged="dr_service_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="center" style="width:7%">
                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="dr_building" runat="server" AutoPostBack="true" 
                                    Width="100%" onselectedindexchanged="dr_building_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="center" style="width:7%">
                        &nbsp;</td>
                    <td align="center" style="width:5%">
                        &nbsp;</td>
                    <td align="center" style="width:28%">
                        &nbsp;</td>
                    <td align="center" style="width:6%">
                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="dr_dtsub" runat="server" AutoPostBack="true" 
                                    Width="100%" onselectedindexchanged="dr_dtsub_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="center" style="width:15%">
                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="dr_action" runat="server" AutoPostBack="true" 
                                    Width="100%" onselectedindexchanged="dr_action_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="center" style="width:6%">
                        &nbsp;</td>
                    <td align="center" style="width:6%">
                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="dr_dtcom" runat="server" AutoPostBack="true" 
                                    onselectedindexchanged="dr_dtcom_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="center" style="width:5%">
                        &nbsp;</td>
                </tr>
       
            </table>
            </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
            <asp:GridView ID="mygrid_dr" runat="server" AutoGenerateColumns="False" 
                        onrowdatabound="mygrid_dr_RowDataBound" Width="100%" ShowHeader="False" 
                        onrowcommand="mygrid_dr_RowCommand">
                    <Columns>
                    <%--<asp:ButtonField ButtonType="Button" DataTextField="so_no" CommandName="get" >
                        <ItemStyle Width="6%" HorizontalAlign="Center" />
                        </asp:ButtonField>--%>
                    <asp:BoundField >
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundField>  
                    <asp:BoundField DataField="srv_name" >
                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                        </asp:BoundField>
                    <asp:BoundField DataField="subject" >
                        <ItemStyle Width="7%" HorizontalAlign="Center" />
                        </asp:BoundField>
                    <%--<asp:BoundField DataField="so_no" >
                        <ItemStyle Width="7%" HorizontalAlign="Center" />
                        </asp:BoundField>--%>
                    <asp:ButtonField ButtonType="Link" DataTextField="so_no" CommandName="get" >
                        <ItemStyle Width="7%" HorizontalAlign="Center" />
                        </asp:ButtonField>    
                    <asp:BoundField DataField="comments" >
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="details" >
                        <ItemStyle Width="28%" HorizontalAlign="Center" />
                        </asp:BoundField>
                    <asp:BoundField DataField="issue_date" >
                        <ItemStyle Width="6%" HorizontalAlign="Center" />
                        </asp:BoundField>
                    <asp:BoundField DataField="issued_to" >
                        <ItemStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="response" >
                        <ItemStyle Width="6%" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="compl_date" >
                        <ItemStyle Width="6%" HorizontalAlign="Center" />
                        </asp:BoundField>
                    
                    <asp:ButtonField ButtonType="Button" Text="Edit" CommandName="status" >
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:ButtonField>
                    <asp:BoundField DataField="so_no" />
                    <asp:BoundField DataField="so_id" />
                    <asp:BoundField DataField="doc_name" />
                    <asp:BoundField DataField="uid" />
                    </Columns>
                    </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
            
            
           
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:dbCMLConnectionString %>" 
                SelectCommand="load_so_dir" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="Project_code" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div> 
        <asp:Panel ID="pnlPopup" runat="server" Width="300px" style="display:none;" >
                    <asp:Label ID="Label1" runat="server" Font-Names="verdana" Font-Size="Medium" ForeColor="White"></asp:Label>
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;background-color:White" id="tblPopup">
                            <tr>
                                <td class="heading"  style="background-image: url('images/headingbg_13.gif'); background-repeat: repeat-x;" >Select users to send notification!
     </td>
                            </tr>
                            
                            <tr>
                                <td align="left" height="75px" valign="middle"   bgcolor="White">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:CheckBoxList ID="chkuser" runat="server" BackColor="White" Width="100%" Height="75px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" >
                        </asp:CheckBoxList>
                                    </ContentTemplate>
                    </asp:UpdatePanel>
                                    </td>
                            </tr>
                            <tr>
                                <td class="footer" height="30px" >
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                    <asp:Button ID="btnCont" runat="server" Text="Continue" OnClick="btnCont_Click"   /><asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click"    />
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                     <div id="myprogress" runat="server" style="position: absolute; z-index: 40; top: 50%; left: 50%">
                                            <asp:Image ID="myimage" runat="server" ImageUrl="~/images/loading30.gif" />
                                            </div>
                                            </ProgressTemplate>
                                    </asp:UpdateProgress>--%>
                                </td>
                            </tr>
                       </table>
                  </asp:Panel>
                  
                    <asp:Button ID="btnDummy" runat="server" Text="Button" style="display:none;" />
                  <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" 
                  TargetControlID="btnDummy"  PopupControlID="pnlPopup"
                  BackgroundCssClass="modal"
                  DropShadow="true">
                  </asp:ModalPopupExtender> 
                  
                  <asp:Panel ID="pnlPopup1" runat="server" Width="250px" Height="94px" style="padding:10px;background-color:White;display:none" >
                        <table border="0" cellpadding="0" cellspacing="0" style="background-color:White" id="Table1">
                            <tr>
                                <td align="left" bgcolor="White" valign="middle" width="100PX">
                                    &nbsp;</td>
                                <td align="left" bgcolor="White" valign="middle">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" bgcolor="White" valign="middle" width="100PX">
                                    STATUS</td>
                                <td align="left" bgcolor="White" valign="middle">
                                    <asp:DropDownList ID="sostatus1" runat="server" Width="150px">
                                        <asp:ListItem Text="OPEN" Value="OPEN"></asp:ListItem>
                                        <asp:ListItem Text="CLOSED" Value="CLOSED"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="footer" height="30px" colspan="2" align="center" >
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" class="footer" colspan="2" height="30px">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnupdate" runat="server" Height="26px" 
                                                onclick="btnupdate_Click" Text="Update" />
                                                <asp:Button ID="btndelete" runat="server" onclick="btndelete_Click" 
                                                Text="Delete" />
                                            <asp:Button ID="btncancel1" runat="server" onclick="btncancel1_Click" 
                                                Text="Cancel" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                     <div id="myprogress" runat="server" style="position: absolute; z-index: 40; top: 50%; left: 50%">
                                            <asp:Image ID="myimage" runat="server" ImageUrl="~/images/loading30.gif" />
                                            </div>
                                            </ProgressTemplate>
                                    </asp:UpdateProgress>--%>
                                </td>
                            </tr>
                       </table>
                  </asp:Panel>
                  
                    <asp:Button ID="btnDummy1" runat="server" Text="Button" style="display:none;" />
                  <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender1" runat="server" 
                  TargetControlID="btnDummy1"  PopupControlID="pnlPopup1"
                  BackgroundCssClass="modal"
                  DropShadow="true">
                  </asp:ModalPopupExtender>
    </div>
    </form>
</body>
</html>
