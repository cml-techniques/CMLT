<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="managetreeSub.aspx.cs" Inherits="CmlTechniques.managetreeSub" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    
    </head>
<body bgcolor="#ffffff" style="padding:0px;margin:0px;">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        
        <table style="width: 100%; height: 100%;font-family: Verdana; font-size: small;">
            <tr>
                <td valign="top">
                <div style="width: 100%; height: 100%;">
                    <asp:Label ID="lblpath" runat="server" style="display:none"></asp:Label>
                    <asp:Label ID="lbltype" runat="server" style="display:none"></asp:Label>
                <br />
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            Select Action
                            <asp:DropDownList ID="draction" runat="server">
                                <asp:ListItem Value="0">--Select Action--</asp:ListItem>
                                <asp:ListItem Value="1">Create Folder</asp:ListItem>
                                <asp:ListItem Value="2">Create Sub Folder</asp:ListItem>
                                <asp:ListItem Value="3">Edit/Delete Folder</asp:ListItem>
                                <asp:ListItem Value="4">Edit Document</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="btngo" runat="server" Text="Go" onclick="btngo_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                     <div id="myprogress" runat="server" style="position: absolute; z-index: 40; top: 50%; left: 50%">
                                            <asp:Image ID="myimage" runat="server" ImageUrl="~/images/loading8.gif" />
                                            </div>
                                            </ProgressTemplate>
                                    </asp:UpdateProgress>
                    
                    &nbsp;&nbsp;&nbsp;--%>
                    <asp:Label ID="Label1" runat="server" Font-Names="Arial,Helvetica,sans-serif" 
                        Font-Size="Small" ForeColor="Red"></asp:Label>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>             
                    <asp:Panel ID="Panel1" runat="server" Height="271px">
                    
                        <table style="font-family: verdana; font-size: small">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td width="100px">
                                    Folder Name</td>
                                <td>
                                    <asp:TextBox ID="txtfolder" runat="server" Width="291px" Height="22px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkdoc" runat="server" Checked="false" 
                                        Text="Create Default Document Folders" />
                                </td>
                            </tr>
                            <tr>
                                <td height="100px">
                                    &nbsp;</td>
                                <td>
                                    <asp:Panel ID="pnledit" runat="server" Height="100px">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                        
                                        <table border="0" cellpadding="0" cellspacing="1" >
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="draction0" runat="server" AutoPostBack="True" 
                                                        onselectedindexchanged="draction0_SelectedIndexChanged">
                                                        <asp:ListItem Value="0">--Select Action--</asp:ListItem>
                                                        <asp:ListItem Value="1">Rename</asp:ListItem>
                                                        <asp:ListItem Value="2">Move to</asp:ListItem>
                                                        <asp:ListItem Value="3">Delete</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txtrename" runat="server" Height="22px" Width="291px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                        </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </asp:Panel>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="continue" runat="server" onclick="continue_Click" 
                                        Text="Continue" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    
                        </asp:Panel>
                   <asp:GridView ID="mygrid" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" 
                        Width="100%" Font-Names="Arial,Helvetica,sans-serif" Font-Size="X-Small" 
                        onrowdatabound="mygrid_RowDataBound" 
                        onselectedindexchanged="mygrid_SelectedIndexChanged" 
                        onrowcommand="mygrid_RowCommand" onrowdeleting="mygrid_RowDeleting">
                       <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign=Left  />
                       <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                   <Columns>
                   <asp:BoundField DataField="doc_title" HeaderText="MANUAFCTURE" >
                       <HeaderStyle HorizontalAlign="Left" />
                       </asp:BoundField>
                   <asp:BoundField DataField="doc_name" HeaderText="DOCUMENT NAME" >
                       <HeaderStyle HorizontalAlign="Left" />
                       </asp:BoundField>
                   <asp:BoundField DataField="doc_id" />
                   <asp:BoundField DataField="possition" />
                   
                       <%--<asp:CommandField ButtonType="Button" ShowSelectButton="True">
                           <ItemStyle HorizontalAlign="Right" />
                       </asp:CommandField>--%>
                   <asp:ButtonField Text="up" ButtonType="Image" CommandName="up" 
                           ImageUrl="~/images/up_.jpg" ItemStyle-Width ="20px" >
                       </asp:ButtonField>
                   <asp:ButtonField Text ="down" ButtonType="Image" CommandName="down" 
                           ImageUrl= "~/images/down_.jpg"  ItemStyle-Width="20px" >
                       </asp:ButtonField>
                       <asp:ButtonField Text ="delete" ButtonType="Image" CommandName="delete" 
                           ImageUrl= "~/images/delete_.jpg"  ItemStyle-Width="20px"  >
                       </asp:ButtonField>
                   </Columns>
                   
                   <PagerTemplate>
                   <asp:Button ID="Button1" runat="server" Text="Move Down" />
                   </PagerTemplate>
                       <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                       <SelectedRowStyle BackColor="#E2DED6" Font-Bold="False" ForeColor="#333333" />
                       <HeaderStyle BackColor="#5D7B9D" Font-Bold="false" ForeColor="White" />
                       <EditRowStyle BackColor="#999999" />
                       <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    </ContentTemplate>
                    </asp:UpdatePanel>                   
                    </div>
                    &nbsp;</td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
