<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="commplans.aspx.cs" Inherits="CmlTechniques.commplans" %>

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
    <div style="width:100%;height:100%; font-family: verdana; font-size: x-small;">
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div style="float:left;width:34%;margin-left:.5%;margin-right:.5%">
            <h1 style="margin-top:0">COMMISSIONING PLANS</h1>
            
            <asp:GridView ID="mygrid" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" GridLines="Vertical" BackColor="White" 
                BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                onrowcommand="mygrid_RowCommand" onrowdatabound="mygrid_RowDataBound" 
                Width="100%" ForeColor="Black">
                <RowStyle BackColor="#F7F7DE" />
                <FooterStyle BackColor="#CCCC99" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                <asp:BoundField DataField="doc_name" HeaderText="DOCUMENT NAME" >
                    <HeaderStyle Font-Bold="False" HorizontalAlign="Left" />
                    </asp:BoundField>
                <asp:BoundField DataField="file_name" HeaderText="FILE_NAME" >
                    <HeaderStyle Font-Bold="False" HorizontalAlign="Left" />
                    </asp:BoundField>
                <asp:ButtonField DataTextField="file_name" ButtonType="Link" 
                        HeaderText="FILE NAME" >
                    <HeaderStyle Font-Bold="False" HorizontalAlign="Left" />
                    </asp:ButtonField>
                <asp:BoundField DataField="upload_date" HeaderText="UPLOADED DATE" DataFormatString="{0:dd/MM/yyyy}" >
                    <HeaderStyle Font-Bold="False" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="doc_id" />
                </Columns>
            </asp:GridView>
            <div>
            <h4 style="margin-bottom:0" >ADD YOUR COMMENTS HERE:-</h4>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txtcomments" runat="server" Height="75px" Width="90%" 
                    TextMode="MultiLine"></asp:TextBox>
                <asp:Button ID="btnadd" runat="server" Text="Add" ForeColor="Red" 
                    Font-Size="X-Small" onclick="btnadd_Click" />
                    </ContentTemplate>
            </asp:UpdatePanel>
            </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            
            <asp:GridView ID="mybasket" runat="server" AllowPaging="True" 
                                            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id"
                                            DataSourceID="dataSource" Font-Names="Arial,Helvetica,sans-serif" 
                                            Font-Size="X-Small" ForeColor="Black"  
                                            Width="100%" 
                onrowdatabound="mybasket_RowDataBound" PageSize="4" BackColor="White" 
                    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" GridLines="Vertical">
                                            <FooterStyle BackColor="#CCCC99" />
                                            <RowStyle BackColor="#F7F7DE" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:CommandField ButtonType="Image" 
                                                    DeleteImageUrl="~/TreeLineImages/minus.gif" ShowDeleteButton="true">
                                                    <ItemStyle Width="10px" />
                                                </asp:CommandField>
                                                <asp:BoundField DataField="id" HeaderText="No.">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Width="40px" />
                                                </asp:BoundField>                                                
                                                <asp:BoundField DataField="comment" HeaderText="Comment">
                                                    <HeaderStyle HorizontalAlign="Left" />                                  
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:ObjectDataSource ID="dataSource" runat="server" DeleteMethod="Delete" 
                                            InsertMethod="Insert" SelectMethod="GetData" 
                                            TypeName="CmlTechniques.cmscomments" UpdateMethod="Update">
                                            <DeleteParameters>
                                                <asp:Parameter Name="id" Type="Int32" />
                                            </DeleteParameters>
                                            <InsertParameters>
                                                <asp:Parameter Name="comment" Type="String" />
                                            </InsertParameters>
                                        </asp:ObjectDataSource>
                                        </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            
            <asp:Button ID="btnsave" runat="server" Text="Save Comments" ForeColor="Red" 
                    Font-Size="X-Small" onclick="btnsave_Click" Width="100px" />
            <asp:Button ID="btncancel"
                runat="server" Text="Cancel Comments" ForeColor="Red" 
                    Font-Size="X-Small" onclick="btncancel_Click" Width="100px" />
                </ContentTemplate>
            </asp:UpdatePanel>    
                <asp:Button ID="btnview" runat="server" 
                Text="View Previous Comments" ForeColor="Red" 
                    Font-Size="X-Small" Height="19px" Width="135px" onclick="btnview_Click" style="background-color:Transparent" />
        
        </div>
        <div style="float:right; width:65%;height:100%;" >
            <%--<asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>--%>    
        <iframe id="myframe" runat="server" frameborder="0" height="100%" width="65%" style="position:absolute"></iframe>
        <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </div>
    </form>
</body>
</html>
