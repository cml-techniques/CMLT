<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewcomments.aspx.cs" Inherits="CmlTechniques.viewcomments" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <style type="text/css">
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
       </style>  
    
</head>
<body >
    <form id="form1" runat="server" >
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        
        <table style="position: absolute ; width: 100%; height: 100%">
            <tr>
                <td height="30px" 
                                style="background-image: url('images/tophead.png'); background-repeat: repeat-x" 
                                valign="middle" align="right">
                    </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    <table style="font-family: Arial, Helvetica, sans-serif; font-size: medium" 
                        width="600px">
                        <tr>
                            <td align="left" width="150px">
                                Package</td>
                            <td width="5px">
                                :</td>
                            <td align="left">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Document Type</td>
                            <td>
                                :</td>
                            <td align="left">
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small">O &amp; M 
                                Manual</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Version</td>
                            <td>
                                :</td>
                            <td align="left">
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small">ALL</asp:Label>
                            </td>
                        </tr>
                        </table>
                    
                </td>
            </tr>
            <tr>
                <td align="center" valign="top">
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Double">
                        <table style="font-family: Arial, Helvetica, sans-serif; font-size: medium" 
                            width="100%">
                            <tr>
                                <td align="left" width="150px">
                                    Contractor :</td>
                                <td align="left">
                                    <asp:Label ID="contr" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left" width="175px">
                                    Latest Version :</td>
                                <td align="left">
                                    <asp:Label ID="version" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="150px">
                                    Module :</td>
                                <td align="left">
                                    <asp:Label ID="module" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left" width="150px">
                                    Date Last Uploaded :</td>
                                <td align="left">
                                    <asp:Label ID="date" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Package :</td>
                                <td align="left">
                                    <asp:Label ID="package" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left">
                                    Uploaded by :</td>
                                <td align="left">
                                    <asp:Label ID="uploadby" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Manual Filename :</td>
                                <td align="left">
                                    <asp:Label ID="fname" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left">
                                    Status :</td>
                                <td align="left">
                                    <asp:Label ID="status" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" height="100%" width="100%">
                <div style="width: 100%; height: 100%; overflow: auto">
                    <asp:GridView ID="mygrid" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="Vertical" Width="100%" AutoGenerateColumns="False" 
                        Font-Names="Verdana" Font-Size="X-Small" 
                        onrowdatabound="mygrid_RowDataBound">
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
                            <ItemStyle Width="60%"  />
                            </asp:BoundField>
                            <asp:BoundField DataField="resp" HeaderText="CML RESPONSE" >
                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                            <ItemStyle Width="40%"  />
                            </asp:BoundField>
                            
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    </div>
                    
                </td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
