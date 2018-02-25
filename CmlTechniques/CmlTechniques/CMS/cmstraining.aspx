<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cmstraining.aspx.cs" Inherits="CmlTechniques.CMS.cmstraining" %>

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
    .btnstyle
    {
    	font-size:xx-small;
    	cursor:pointer;
    	color:Red;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div style="font-family: verdana; font-size: x-small;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div style="float:left;width:100%;height:100%">
        <%--<p style="margin:0">
            <asp:Label ID="phead" runat="server" Text=""></asp:Label></p>
            <asp:GridView ID="mygrid" runat="server" CellPadding="4" ForeColor="#333333" 
                GridLines="None" Width="100%" AutoGenerateColumns="False" 
                onrowcommand="mygrid_RowCommand" onrowdatabound="mygrid_RowDataBound">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>--%>
          <div style="width:98%;padding:0 1% 0 1%">
        <p style="margin-top:0">
            <asp:Label ID="phead" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></p>
             <table style="width:100%">
            <tr>
            <td   valign="middle" align="center" 
                                    style="font-family: Verdana; font-size: small; color: #FFFFFF; " 
                                    height="30px" bgcolor="#092443" >Latest Version of the Training</td>
            </tr>
            </table>
            <table  border="1" 
                                    style="border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;" width="100%">
            <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat;height:30px">
            <td style="width:40%" align="center">DOCUMENT NAME</td>
            <td style="width:12%" align="center">UPLOAD DATE</td>
            <td style="width:12%" align="center">VERSION</td>
            <td style="width:12%" align="center">TOTAL COMMENTS</td>
            <td style="width:12%" align="center">OUTSTANDING COMMENTS</td>
            <td style="width:12%" align="center">STATUS</td>
            </tr>
       
                </table>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
              <asp:GridView ID="mygrid" runat="server" AutoGenerateColumns="False" Width="100%" 
                onrowdatabound="mygrid_RowDataBound" onrowcommand="mygrid_RowCommand" Font-Names="Verdana" 
                Font-Size="X-Small" CellPadding="5" ShowHeader="false">
                <HeaderStyle CssClass="gvHeaderRow" Height="25px" />
                <RowStyle Height="25px" />
                <Columns>
                <%--<asp:BoundField DataField="doc_id" />
                <asp:BoundField DataField="file_name" >
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                <asp:ButtonField ButtonType="Link" DataTextField="doc_name" CommandName="view" HeaderText="TRAINING" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:ButtonField>
                <asp:BoundField DataField="upload_date" HeaderText="UPLOAD DATE" 
                        DataFormatString="{0:dd/MM/yyyy}" >
                    <HeaderStyle HorizontalAlign="Left"  />
                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                    </asp:BoundField>--%>
                    <asp:BoundField DataField="doc_id" />
                <asp:BoundField DataField="file_name" >
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                <asp:ButtonField ButtonType="Link" DataTextField="doc_name" CommandName="view" HeaderText="DOCUMENT NAME" >
                    <ItemStyle HorizontalAlign="Left" Width="40%" />
                    </asp:ButtonField>
                <asp:BoundField DataField="upload_date" HeaderText="UPLOAD DATE" 
                        DataFormatString="{0:dd/MM/yyyy}" >
                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Version" HeaderText="VERSION" >
                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Comments" HeaderText="TOTAL COMMENTS" >
                        <ItemStyle HorizontalAlign="Right" Width="6%" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Button" Text="View" CommandName="view1" >
                        <ControlStyle CssClass="btnstyle" />
                        <ItemStyle HorizontalAlign="Left" Width="6%" />
                    </asp:ButtonField>
                    <asp:BoundField DataField="outstanding" HeaderText="OUTSTANDING COMMENTS" >
                        <ItemStyle HorizontalAlign="Right" Width="6%" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Button" Text="View" CommandName="view2" >
                        <ControlStyle CssClass="btnstyle" />
                        <ItemStyle HorizontalAlign="Left" Width="6%" />
                    </asp:ButtonField>
                    <asp:BoundField DataField="doc_status" HeaderText="STATUS" >
                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
              </ContentTemplate>
              </asp:UpdatePanel>
            
            <br />
            <table style="width:100%" border="0">
            <tr>
            <td   valign="middle" align="center" 
                                    style="font-family: Verdana; font-size: small; color: #FFFFFF; " 
                                    height="30px" bgcolor="#092443" >History - Previous Versions</td>
            </tr>
            </table>
            <table  border="1" 
                                    style="border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;" width="100%">
            <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat;height:30px">
            <td style="width:40%" align="center">DOCUMENT NAME</td>
            <td style="width:12%" align="center">UPLOAD DATE</td>
            <td style="width:12%" align="center">VERSION</td>
            <td style="width:12%" align="center">TOTAL COMMENTS</td>
            <td style="width:12%" align="center">OUTSTANDING COMMENTS</td>
            <td style="width:12%" align="center">STATUS</td>
            </tr>
       
                </table>
            <asp:GridView ID="myhistory" runat="server" AutoGenerateColumns="False" Width="100%"
                Font-Names="Verdana" 
                Font-Size="X-Small" onrowcommand="myhistory_RowCommand" 
                onrowdatabound="myhistory_RowDataBound" CellPadding="5" ShowHeader="false"  >
                <HeaderStyle CssClass="gvHeaderRow" Height="25px" />
                <RowStyle Height="25px" />
                <Columns>
                <asp:BoundField DataField="doc_id" />
                <asp:BoundField DataField="file_name" >
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                <asp:ButtonField ButtonType="Link" DataTextField="doc_name" CommandName="view" HeaderText="DOCUMENT NAME" >
                    <ItemStyle HorizontalAlign="Left" Width="40%" />
                    </asp:ButtonField>
                <asp:BoundField DataField="upload_date" HeaderText="UPLOAD DATE" 
                        DataFormatString="{0:dd/MM/yyyy}" >
                    <ItemStyle HorizontalAlign="Center"  Width="12%" />
                    </asp:BoundField>
                <asp:BoundField DataField="Version" HeaderText="VERSION" >
                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Comments" HeaderText="TOTAL COMMENTS" >
                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="outstanding" HeaderText="OUTSTANDING COMMENTS" >
                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="doc_status" HeaderText="STATUS" >
                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                    </asp:BoundField>
                </Columns>
                </asp:GridView>
        </div>
        </div>
    </div>
    </form>
</body>
</html>
