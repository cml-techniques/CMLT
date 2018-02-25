<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewcmscomments.aspx.cs" Inherits="CmlTechniques.viewcmscomments" %>

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
<body bgcolor="#cccccc">
    <form id="form1" runat="server">
    <div style="font-family: verdana; font-size: x-small;height:100%;width:100%">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <p style="text-align:center;font-size:large">View Comments</p>
        <div style="height:100%;width:98%;margin-left:1%;margin-right:1%">
            <asp:GridView ID="mygrid" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="100%">
                <RowStyle BackColor="#F7F7DE" />
                <FooterStyle BackColor="#CCCC99" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                <asp:BoundField DataField="comment" HeaderText="COMMENTS" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="50%" />
                    </asp:BoundField>
                <asp:BoundField DataField="uid" HeaderText="USER ID" >
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                <asp:BoundField DataField ="comment_date" HeaderText="DATE" DataFormatString="{0:dd/MM/yyyy}" >
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                <asp:BoundField DataField="cml_responds" HeaderText="CML RESPONDS" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="50%" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
        <div></div>
    </div>
    </form>
</body>
</html>
