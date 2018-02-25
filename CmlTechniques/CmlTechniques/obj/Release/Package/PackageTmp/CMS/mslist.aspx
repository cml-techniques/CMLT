<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mslist.aspx.cs" Inherits="CmlTechniques.CMS.mslist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
        <link href="../page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .gvHeaderRow
    {
        background-image:url('../images/head_bg.png');
         background-repeat: repeat;
        font-family:Verdana;
        font-size:x-small;
        font-weight:normal;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
         <div style="float:left;width:100%;height:100%">
        <div style="width:98%;padding:0 1% 0 1%">
        <p style="margin-top:0">
            <asp:Label ID="phead" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></p>
            <asp:GridView ID="mygrid" runat="server" Width="100%" AutoGenerateColumns="False" 
                onrowcommand="mygrid_RowCommand" onrowdatabound="mygrid_RowDataBound" Font-Names="Verdana" 
                Font-Size="X-Small" CellPadding="5">
                 <HeaderStyle CssClass="gvHeaderRow" Height="25px" />
                <RowStyle Height="25px" />
                <Columns>
                <asp:BoundField DataField="doc_id" />
                <asp:BoundField DataField="file_name" />
                <asp:BoundField DataField="doc_name" HeaderText="DOCUMENT NAME" >
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                <asp:ButtonField DataTextField="file_name" HeaderText="FILE NAME" >
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:ButtonField>
                <asp:BoundField DataField="upload_date" HeaderText="DATE" 
                        DataFormatString="{0:dd/MM/yyyy}" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="version" HeaderText="REVISION" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="doc_status" HeaderText="STATUS" >
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
         <h5 style="color:Gray">HISTORY</h5>
            <asp:GridView ID="mygrid1" runat="server" Width="100%" AutoGenerateColumns="False" 
                onrowdatabound="mygrid1_RowDataBound" Font-Names="Verdana" 
                Font-Size="X-Small" CellPadding="5">
                 <HeaderStyle CssClass="gvHeaderRow" Height="25px" />
                <RowStyle Height="25px" />
                <Columns>
                <asp:BoundField HeaderText="Sl.No" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="50px" />
                    </asp:BoundField>
                <asp:BoundField DataField="doc_name" HeaderText="DOCUMENT NAME" >
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="file_name" HeaderText="FILE NAME" >
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                <asp:BoundField DataField="upload_date" HeaderText="DATE" 
                        DataFormatString="{0:dd/MM/yyyy}" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="version" HeaderText="REVISION" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="doc_status" HeaderText="STATUS" >
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>   
            
        </div>
        </div>
    </div>
    </form>
</body>
</html>
