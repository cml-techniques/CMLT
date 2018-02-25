<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Commissiong_Testing23.aspx.cs" Inherits="CmlTechniques.CMS.Commissiong_Testing23" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
     <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            height: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: verdana; font-size: x-small;height:100%;position:fixed;width:100%">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <table style="width: 100%; color: White" bgcolor="#092443">
            <tr>
                <td colspan="5" style="background-color: #D2F1FC">
                    <asp:Label ID="lblhead" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="CAS Security Management System Commissioning Activity Schedule"></asp:Label>
                </td>
            </tr>
        </table>
        <div style="float: left; width: 98.5%">
          <table style="font-family: Verdana; font-size: x-small; background-color: #9EB6CE;
                width: 100%;" cellspacing="1" border="0">
                <tr  style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;height:32px">
                    <td align="center"  valign="middle" width="6%">
                        &nbsp;
                    </td>
                    <td align="center"  valign="middle" width="6%">
                        ITEM NO
                    </td>
                    <td align="center"  valign="middle" width="48%">
                        REPORT TITLE</td>

                    <td align="center"  valign="middle" width="40%" id="td_lbldes" runat="server">
                       
                      REPORT REF NO</td>
                </tr>
           
                <tr bgcolor="#092443">
                    <td style="width:6%">
                        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnexpand" runat="server" Text="Exp.All" Width="100%" OnClick="btnexpand_Click"
                                    ForeColor="Red" Font-Size="X-Small" Style="cursor: pointer" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width:6%">
                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btncollapse" runat="server" Text="Coll.All" Width="100%" ForeColor="Red"
                                    Font-Size="X-Small" Style="cursor: pointer" OnClick="btncollapse_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width:48%">
                                   <asp:Label ID="lblprj" runat="server" Text="text" ForeColor="White" style="display:none"></asp:Label>
                                   <asp:Label ID="lblsch" runat="server" Text="text" ForeColor="White" style="display:none"></asp:Label>
                                    <asp:Label ID="lbluid" runat="server" Text="" CssClass="hidden"></asp:Label>
                        &nbsp;
                    </td>
                    <td style="width:40%">
                    </td>
                </tr>
            </table>
        </div>
        <div style="position:relative; height:75%;overflow-y:scroll;float:left;width:100%;">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            <asp:GridView ID="mymaster" runat="server" AutoGenerateColumns="False" 
                Width="100%" onrowdatabound="mymaster_RowDataBound" 
                Font-Names="Verdana" 
                    Font-Size="X-Small" ShowHeader="False" GridLines="None" 
                    onselectedindexchanged="mymaster_SelectedIndexChanged" >
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
                                                                    <asp:BoundField HeaderText="Itm.No" ItemStyle-Width="6%">
                                                                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                 <asp:BoundField DataField="Des" HeaderText="Report Title" ItemStyle-Width="7%">
                                                                    <ItemStyle Width="48%" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="E_b_ref" HeaderText="Report reff no" ItemStyle-Width="10%">
                                                                    <ItemStyle Width="40%" HorizontalAlign="Center" />
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
        <div id="myprogress" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
       
       
        <asp:Button ID="btnDummy" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender1" runat="server" TargetControlID="btnDummy"  PopupControlID="pnlPopup" BackgroundCssClass="modal"></asp:ModalPopupExtender> 
         <asp:Panel ID="pnlPopup" runat="server" Width="826px" Height="196px" 
            style="padding:15px;" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:825px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="6" style="background-color: #092443;height:25px;text-align:center" >
                            <asp:Label ID="_lbl" runat="server" ForeColor="White" Font-Size="Medium" Text="Secutity Management System"></asp:Label>
                       </td>
                    </tr>                
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                        <td>
                            Report Submitted1</td>
                        <td >N/A
                            <input id="chk_rsubmit" type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_rsubmit','_rsubmit')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_rsubmit" runat="server" Width="200px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender51" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_rsubmit" 
                                TargetControlID="_rsubmit">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            WIR Reference </td>
                        <td >N/A
                             <input id="chk_wReference"  type="checkbox" style="vertical-align:middle" runat="server"  onclick="_checked('chk_wReference','_wReference')"/>
                            </td>
                        <td>
                            <asp:TextBox ID="_wReference" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-color:#83C8EE" >
                        <td class="style2">
                            Status</td>
                        <td class="style2" >N/A
                           <input id="chk_Status" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_Status','_Status')" runat="server"/></td>
                        <td class="style2">
                            
                            <asp:TextBox ID="_Status" runat="server" Width="200px"></asp:TextBox>
                            
                        </td>

                        <td class="style2">
                            Accepted by BHC </td>
                        <td class="style2" >N/A
                          <input id="chk_acctby" type="checkbox" style="vertical-align:middle"   onclick="_checked('chk_acctby','_acctby')" runat="server"/></td>
                        <td class="style2">
                            
                            <asp:TextBox ID="_acctby" runat="server" Width="147px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender53" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="_acctby" 
                                TargetControlID="_acctby">
                            </asp:CalendarExtender>
                            
                        </td>
                        </tr>
                          <tr style="background-color:#83C8EE" >
                        <td >
                            Comments</td>
                              <td>
                              </td>
                        <td colspan="3">
                            
                            <asp:TextBox ID="_commts" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="97%"></asp:TextBox>
                            
                        </td>
                              <td>
                              </td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td align="right">
                           <asp:Button ID="_btnupdate" runat="server" Text="Update" 
                                onclick="_btnupdate_Click" />
                           
                        </td>
                        <td align="left">
                            <asp:Button ID="_btncancel" runat="server" Text="Cancel" 
                                onclick="_btncancel_Click" />
                        </td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td align="left">
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

    </div>
    <asp:CheckBox ID="CheckBox1" runat="server" />
    <asp:CheckBox ID="CheckBox2" runat="server" />
    </form>
</body>
</html>
