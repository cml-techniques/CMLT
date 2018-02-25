<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="programview.aspx.cs" Inherits="CmlTechniques.programview" %>

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
    <asp:Label ID="lblprj" runat="server" Text="" Style="display: none"></asp:Label>
         <asp:Label ID="lblid" runat="server" Text="" Style="display: none"></asp:Label>
    <div style="height:100%;width:100%;position:absolute"  >
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div style="height:95%;width:85%;overflow:auto;float:left">
        <iframe id="myframe" runat="server" frameborder="0" style="height:95%;width:85%;position:absolute" ></iframe>
        </div>
        <div style="height:95%;width:15%;float:right;background-color:Black">
        
        <div style="height:90%;width:100%;overflow:auto"   >
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            
            <asp:GridView ID="mygridcomm_" runat="server" CellPadding="4" 
                ForeColor="#333333" GridLines="None" onrowcommand="mygridcomm__RowCommand" 
                AutoGenerateColumns="False" onrowdatabound="mygridcomm__RowDataBound" 
                    Font-Size="X-Small">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Width="100%" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                <asp:ButtonField ButtonType="Image" ImageUrl="~/TreeLineImages/minus.gif" >
                                                <ItemStyle Width="5px" />
                    </asp:ButtonField>
                    <asp:BoundField DataField="sec" HeaderText="Act.No">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="comment" HeaderText="Comment">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Width="100%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ID" >
                                            <ItemStyle Width="0px" />
                                            </asp:BoundField>
                                        </Columns>
            </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div style="height:5%;width:100%">
        <table>
        <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnsave" runat="server" Text="Commit comment & Exit" 
                    onclick="btnsave_Click" Font-Size="X-Small" ForeColor="Red" Width="170px"  />
               
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
        <tr>
        <td>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                 <asp:Button ID="btnexit" runat="server" Text="Exit without saving" onclick="btnexit_Click" Font-Size="X-Small" ForeColor="Red" Width="170px" />
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
        </table>
        </div>
        </div>
        <div style="height:5%;width:100%;overflow:auto;background-color:Black">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
            <%--<asp:GridView ID="mygrid" runat="server" CellPadding="4" 
                ForeColor="#333333" GridLines="Vertical"  
                AutoGenerateColumns="False" Width="100%" onrowdatabound="mygrid_RowDataBound" >
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                <asp:BoundField HeaderText="Sl.No" >
                    <ItemStyle Width="10px" />
                    </asp:BoundField>
                <asp:BoundField DataField="comment" HeaderText="Comment" >
                    <ItemStyle Width="80%" />
                    </asp:BoundField>
                <asp:BoundField DataField="uid" HeaderText="User Id" >
                    <ItemStyle Width="20%" />
                    </asp:BoundField>
                <asp:BoundField DataField="comment_date" HeaderText="Date" 
                        DataFormatString="{0:dd/MM/yy}" >            
                    <ItemStyle Width="75px" />
                    </asp:BoundField>
                </Columns>     
                                       
            </asp:GridView>--%>
            <table style="width:100%;font-family:Verdana;font-size:small;color:White">
            <tr>
            <td width="100px" align="center">Activity No</td>
            <td width="75px">
                <asp:TextBox ID="txtno" runat="server" Width="75px"></asp:TextBox>
            </td>
            <td width="100px" align="center">Comment</td>
            <td >
            <asp:TextBox ID="txtcomments" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td width="100px" align="center">
            
                <asp:Button ID="btnadd" runat="server" onclick="btnadd_Click" Text="Add" Width="75px" />
            
            </td>
            </tr>
            </table>
            </ContentTemplate>
            </asp:UpdatePanel>
            </div>
    </div>
    </form>
</body>
</html>
