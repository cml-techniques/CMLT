<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TC_Doc.aspx.cs" Inherits="CmlTechniques.TC_Doc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
            <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label><asp:Label ID="lblfolder"
                runat="server" Text="" style="display:none"></asp:Label>
        <table>
        <tr>
        <td style="width:150px">Select Service</td>
        <td style="width:300px">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drservice" runat="server" Width="300px" AutoPostBack="true" 
                    onselectedindexchanged="drservice_SelectedIndexChanged">
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
            
        </td>
        </tr>
        </table>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:GridView ID="mygrid" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" Font-Names="Verdana" 
                    Font-Size="Small" onrowdatabound="mygrid_RowDataBound" >
                    <RowStyle BackColor="#EFF3FB" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                    <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkbox" runat="server" />
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="cate_name" HeaderText="CATEGORY" >
                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundField>
                    <asp:BoundField DataField="Sys_Name" HeaderText="DESCRIPTION" >
                        <ItemStyle HorizontalAlign="Left" Width="450px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Sys_id" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div style="margin-top:10px">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnsave" runat="server" Text="Save" Width="100px" 
                    onclick="btnsave_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
            
        </div>
        <div id="myprogress" runat="server" style="position:fixed; z-index:40;top:30%;left: 25%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div>
    </div>
    </form>
</body>
</html>
