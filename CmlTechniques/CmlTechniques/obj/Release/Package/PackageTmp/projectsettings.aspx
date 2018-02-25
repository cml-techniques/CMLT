<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="projectsettings.aspx.cs" Inherits="CmlTechniques.projectsettings"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
    body 
   {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
    }
   </style>
   <script language="javascript" type="text/javascript">
            function btnclick() {
            
                var _btn = document.getElementById("cmdview");
                _btn.click();
                //PageMethods.load_manualDetails();
                //form1.load_manualDetails();


            }
   
        </script>
    <script type="text/javascript">
    
    
      function pageLoad() {
      }
    
    </script>
</head>
<body bgcolor="White"  >
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
        
        <table style="font-family: verdana; font-size: small; width: 100%; height: 100%;">
            <tr >
                <td width="150px" >
                    Select Package</td>
                <td >
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                 <asp:DropDownList ID="drpackage" runat="server" Width="400px"></asp:DropDownList>
                    <input id="Button1" type="button" value="View" onclick="javascript:btnclick();" />
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td >
                    <asp:Button ID="cmdview" runat="server" Font-Names="Verdana" Font-Size="X-Small" 
                        ForeColor="Red" Text="View Comments" onclick="cmdview_Click" style="display:none"  />
                    <asp:Label ID="lblsrv" runat="server" Text="" style="display:none"></asp:Label>
                    <asp:Label ID="lbldoc" runat="server" Text="" style="display:none"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="100%" width="100%" valign="top">
                <table style="font-family: Verdana; font-size: small" width="100%">
                            <tr>
                                <td align="left" width="150px" bgcolor="#5D7B9D">
                                    Manual Filename</td>
                                <td align="left" bgcolor="#5D7B9D">
                                    <asp:Label ID="fname" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left" width="175px" bgcolor="#5D7B9D">
                                    Latest Version :</td>
                                <td align="left" bgcolor="#5D7B9D">
                                    <asp:Label ID="version" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="150px" bgcolor="#5D7B9D">
                                    Status</td>
                                <td align="left" bgcolor="#5D7B9D">
                                    <asp:Label ID="status" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left" width="150px" bgcolor="#5D7B9D">
                                    Date Last Uploaded :</td>
                                <td align="left" bgcolor="#0099CC">
                                    <asp:Label ID="date" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="100%" colspan="4" height="300px">
                    <div style="width: 100%; height: 100%; overflow: auto">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                               
                    <asp:GridView ID="mygrid" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" Width="100%" AutoGenerateColumns="False" 
                        Font-Names="Verdana" Font-Size="X-Small" 
                        onrowdatabound="mygrid_RowDataBound" onrowcommand="mygrid_RowCommand" >
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <Columns>
                        <asp:BoundField DataField="version" HeaderText="VERSION" >
                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                            <ItemStyle Width="100px" />
                            </asp:BoundField>
                        <asp:BoundField DataField="sec_no" HeaderText="SECTION" >
                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                            <ItemStyle Width="100px" />
                            </asp:BoundField>
                        <asp:BoundField DataField="page_no" HeaderText="PAGE" >
                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                            <ItemStyle Width="100px" />
                            </asp:BoundField>
                        <asp:BoundField DataField="com_date" HeaderText="DATE" 
                                DataFormatString="{0:dd/MM/yyyy}"  >
                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                            <ItemStyle Width="100px" />
                            </asp:BoundField>
                        <asp:BoundField DataField="userid" HeaderText="NAME" >
                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                            <ItemStyle Width="250px" />
                            </asp:BoundField>
                        <asp:BoundField DataField="comment" HeaderText="COMMENT" >
                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                            <ItemStyle Width="100%"  />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Button" Text="CML Responds">
                            <ControlStyle Font-Names="Verdana" Font-Size="X-Small" ForeColor="Red" />
                            </asp:ButtonField>
                            <asp:BoundField DataField="comm_id" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                     </ContentTemplate>
                                </asp:UpdatePanel>
                    
                    </div>
                
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="100%" colspan="4" height="100%">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                    
                                    <asp:Panel ID="Panel1" runat="server">
                                        <table style="font-family: verdana; font-size: small">
                                            <tr>
                                                <td>
                                                    Comments</td>
                                                <td>
                                                    <asp:TextBox ID="txtcomment" runat="server" Height="50px" ReadOnly="True" 
                                                        TextMode="MultiLine" Width="850px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    CML Responds</td>
                                                <td>
                                                    <asp:TextBox ID="txtrespond" runat="server" Height="50px" 
                                                         TextMode="MultiLine" Width="850px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:Button ID="cmdadd" runat="server" Text="Add Responds" Font-Names="Verdana" 
                                                        Font-Size="X-Small" ForeColor="Red" onclick="cmdadd_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            </table>
                
                   </td>
            </tr>
        </table>
        
        
    </div>
    </form>
</body>
</html>
