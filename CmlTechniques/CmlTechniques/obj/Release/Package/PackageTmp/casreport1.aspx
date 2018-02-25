<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="casreport1.aspx.cs" Inherits="CmlTechniques.casreport1" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
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
        <table style="font-family: verdana; font-size: x-small; width: 100%; height: 100%">
            <tr>
                <td valign="top">
                    <asp:Panel ID="Panel1" runat="server">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Button ID="export" runat="server" Text="Export to Excel" 
                        Font-Names="Verdana" Font-Size="X-Small" onclick="export_Click" />
                    <asp:Button ID="print" runat="server" Text="Print" Font-Names="Verdana" 
                        Font-Size="X-Small" OnClientClick ="javascript:CallPrint(forPrint);" 
                        onclick="print_Click"/>                           </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:GridView ID="mygrid" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" GridLines="Horizontal" BackColor="White" 
                        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px">
                        <RowStyle BackColor="White" ForeColor="#333333" />
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:dbCMLConnectionString %>" 
                        SelectCommand="load_casMain" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="4" Name="sch_id" Type="Int32" />
                            <asp:Parameter DefaultValue="1" Name="prj_code" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:dbCMLConnectionString %>" 
                        SelectCommand="load_cms_cas_sys" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="4" Name="sch" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
