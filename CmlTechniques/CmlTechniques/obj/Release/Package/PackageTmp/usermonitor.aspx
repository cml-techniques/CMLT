<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usermonitor.aspx.cs" Inherits="CmlTechniques.usermonitor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="page.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .style1
        {
            width: 75px;
        }
    </style>

    </head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <table style="width: 800px; font-family: verdana; font-size: x-small; color: #FF0000;text-align:center">
            <tr>
                <td class="style1" >
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="cmdrefresh" runat="server" Text="Refresh" onclick="cmdrefresh_Click" Width="75px"
                                 />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                   
                </td>
                <td style="font-family: Verdana; font-size: large; font-weight: bold;width:100%">
                    ONLINE USERS</td>
            </tr>
            <tr>
                <td height="100%" valign="top" colspan="2" align="center">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                    
                    
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" 
                        CellPadding="4" Width="800px" 
                            onrowdatabound="GridView1_RowDataBound">
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="White" ForeColor="#333333" />
                        <Columns>
                        <asp:BoundField DataField="_uid" HeaderText="USER ID" />
                        <asp:BoundField DataField="_ipaddress" HeaderText="IP ADDRESS" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        <asp:BoundField  HeaderText="COUNTRY" DataField="country_name">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                         <asp:BoundField  HeaderText="REGION" DataField="region_name">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                          <asp:BoundField  HeaderText="CITY" DataField="_location" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>     
                        <asp:BoundField DataField="_login" HeaderText="LOGIN TIME" >                        
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <%--<a href="MultiUpload.aspx" target="_blank">rpt</a>--%>
    </div>
    </form>
</body>
</html>
