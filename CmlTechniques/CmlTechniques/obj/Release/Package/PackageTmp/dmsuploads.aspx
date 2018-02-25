<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dmsuploads.aspx.cs" Inherits="CmlTechniques.dmsuploads" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .gvHeaderRow
    {
        background-image:url('images/head_bg.png');
         background-repeat: repeat;
        font-family:Verdana;
        font-size:x-small;
        font-weight:normal;
    }
    .gvCell
    {
        padding-left:5px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div style="width:100%;height:100%;">
        <div style="width:98%;padding:0 1% 0 1%">
        <p style="margin-top:0">
            <asp:Label ID="phead" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></p>
            <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
            <table style="width:100%" border="0">
            <tr>
            <td   valign="middle" align="center" 
                                    style="font-family: Verdana; font-size: small; color: #FFFFFF; " 
                                    height="30px" bgcolor="#092443" >
                <asp:Label ID="lbl_latest" runat="server" Text=""></asp:Label></td>
            </tr>
            </table>
            <asp:GridView ID="mygrid" runat="server" AutoGenerateColumns="False" Width="100%" 
                onrowdatabound="mygrid_RowDataBound" onrowcommand="mygrid_RowCommand" Font-Names="Verdana" 
                Font-Size="X-Small" >
                <HeaderStyle CssClass="gvHeaderRow" Height="25px" />
                <RowStyle Height="25px"  />
                <Columns>
                <asp:BoundField DataField="doc_id" />
                <asp:BoundField DataField="file_name" >
                    <ItemStyle HorizontalAlign="Left"  />
                    </asp:BoundField>
                <asp:ButtonField ButtonType="Link" DataTextField="doc_name" CommandName="view" HeaderText="DOCUMENT NAME" >
                    <HeaderStyle HorizontalAlign="Left" CssClass="gvCell" />
                    <ItemStyle HorizontalAlign="Left" CssClass="gvCell" />
                    </asp:ButtonField>
                <asp:BoundField DataField="upload_date" HeaderText="UPLOAD DATE" 
                        DataFormatString="{0:dd/MM/yyyy}" >
                    <HeaderStyle HorizontalAlign="Left" CssClass="gvCell" />
                    <ItemStyle HorizontalAlign="Left" CssClass="gvCell"  Width="150px" />
                    </asp:BoundField>
                <%--<asp:ButtonField ButtonType="Button" Text="Download" CommandName="download" >
                    <ItemStyle HorizontalAlign="Right" />
                    </asp:ButtonField>--%>
                </Columns>
            </asp:GridView>
            <br />
            <table style="width:100%" border="0">
            <tr>
            <td   valign="middle" align="center" 
                                    style="font-family: Verdana; font-size: small; color: #FFFFFF; " 
                                    height="30px" bgcolor="#092443" ><asp:Label ID="lbl_previous" runat="server" Text=""></asp:Label></td>
            </tr>
            </table>
            
            <asp:GridView ID="myhistory" runat="server" AutoGenerateColumns="False" Width="100%"
                Font-Names="Verdana" 
                Font-Size="X-Small" onrowcommand="myhistory_RowCommand" 
                onrowdatabound="myhistory_RowDataBound"  >
                <HeaderStyle CssClass="gvHeaderRow" Height="25px" />
                <RowStyle Height="25px" />
                <Columns>
                <asp:BoundField DataField="doc_id" />
                <asp:BoundField DataField="file_name" >
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                <asp:ButtonField ButtonType="Link" DataTextField="doc_name" CommandName="view" HeaderText="DOCUMENT NAME" >
                    <HeaderStyle HorizontalAlign="Left" CssClass="gvCell" />
                    <ItemStyle HorizontalAlign="Left" CssClass="gvCell" />
                    </asp:ButtonField>
                <asp:BoundField DataField="upload_date" HeaderText="UPLOAD DATE" 
                        DataFormatString="{0:dd/MM/yyyy}" >
                    <HeaderStyle HorizontalAlign="Left" CssClass="gvCell" />
                    <ItemStyle HorizontalAlign="Left" CssClass="gvCell" Width="150px" />
                    </asp:BoundField>
                </Columns>
                </asp:GridView>
         </div>    
        </div>
    </div>
    </form>
</body>
</html>
