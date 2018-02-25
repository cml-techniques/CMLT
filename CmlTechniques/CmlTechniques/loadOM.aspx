<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loadOM.aspx.cs" Inherits="CmlTechniques.loadOM" %>

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
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label>
         <table style="width: 100%; height: 100%; " border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td  style="width: 100%; height: 100%" valign="top">
                
                <div style="width: 100%; height: 100%">    
                 <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Red" 
                        Font-Names="Verdana"></asp:Label>
                 <div id="mydiv" runat="server" name="mydiv" style="vertical-align:top;"  >   
                <table style="font-family: Arial, Helvetica, sans-serif; font-size: medium; " 
                            width="100%" border="0" cellpadding="0" cellspacing="0" >
                            <tr>
                                <td   valign="middle" align="center" 
                                    style="font-family: Verdana; font-size: small; color: #FFFFFF; " 
                                    height="30px" bgcolor="#092443" >Latest version of O & M Manual                                
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>

                            <tr>
                                <td  valign="top" align="left" >     
                                <br />                           
                                    <asp:GridView ID="mydocgridom" runat="server" 
                                        AutoGenerateColumns="False" CellPadding="4" 
                                        Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" 
                                        Width="100%" onrowcommand="mydocgridom_RowCommand" GridLines="None" 
                                        onrowdatabound="mydocgridom_RowDataBound" >
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#999999" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <%--<asp:HyperLinkField DataNavigateUrlFields="doc_name" 
                                                DataTextField="doc_name" 
                                                HeaderStyle-HorizontalAlign="Left" HeaderText="DOCUMENT NAME" 
                                                NavigateUrl="parent.call();">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:HyperLinkField>--%>
                                            <asp:BoundField DataField="doc_name" />
                                            <asp:TemplateField>
                                            <ItemTemplate >
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/pdf_logo_15x15.gif" />
                                            </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" Width="5px" />
                                            </asp:TemplateField>
                                            <asp:ButtonField DataTextField="doc_name"  HeaderText="FILE NAME"  >
                                            <HeaderStyle Font-Bold="False" HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            </asp:ButtonField>
                                            <asp:BoundField DataField="uploaded_date" HeaderText="UPLOADED DATE" 
                                                DataFormatString="{0:dd/MM/yyyy}" >
                                                <HeaderStyle Font-Bold="False" HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="file_size" HeaderText="FILE SIZE" >
                                                <HeaderStyle Font-Bold="False" HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="version" HeaderText="VERSION" >
                                                <HeaderStyle Font-Bold="False" HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="STATUS" DataField="status" >
                                                <HeaderStyle Font-Bold="False" HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="doc_id" />
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>

                            <tr>
                                <td  valign="middle" align="center" 
                                    style="font-family: Verdana; font-size: small; color: #FFFFFF; " 
                                    height="30px" bgcolor="#092443">Previous versions of O & M Manual                                
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>

                            <tr>
                                <td  valign="top" align="left">
                                <br />
                                    <asp:GridView ID="gridprv" runat="server" 
                                        AutoGenerateColumns="False" CellPadding="4" 
                                        Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" 
                                        Width="100%" GridLines="None" >
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#999999" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:BoundField DataField="doc_name" HeaderText="DOCUMENT NAME" >
                                            <HeaderStyle Font-Bold="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="version" HeaderText="VERSION" 
                                                SortExpression="VERSION" >
                                                <HeaderStyle Font-Bold="False" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="comments" HeaderText="NO.OF COMMENTS" >
                                                <HeaderStyle Font-Bold="False" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="UPLOADED DATE" DataField="uploaded_date" 
                                                DataFormatString="{0:dd/MM/yyyy}" >
                                                <HeaderStyle Font-Bold="False" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="status" HeaderText="STATUS">
                                            <HeaderStyle Font-Bold="False" Font-Italic="False" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>                                     
                                </td>
                                <td>
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                     <div id="myprogress" runat="server" style="position: absolute; z-index: 40; top: 50%; left: 50%">
                                            <asp:Image ID="myimage" runat="server" ImageUrl="~/images/loading30.gif" />
                                            </div>
                                            </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    &nbsp;</td>
                            </tr>
                        </table>
                  
                 </div>
                 
                 <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
                
                </div>
                    </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
