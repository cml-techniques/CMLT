<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cmswircmlcmnts.aspx.cs" Inherits="CmlTechniques.CMS.cmswircmlcmnts" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
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
    .gvCell
    {
        padding-left:5px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <div style="width:100%;height:100%;">
        <div style="width:98%;padding:0 1% 0 1%">
        <p style="margin-top:0">
            <asp:Label ID="phead" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></p>
            <table style="width:100%" border="0">
            <tr>
            <td   valign="middle" align="center" 
                                    style="font-family: Verdana; font-size: small; color: #FFFFFF; " 
                                    height="30px" bgcolor="#092443" >Latest Version of the CML 
                Comments</td>
            </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
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
                    <asp:TemplateField>
                       <ItemTemplate >
                       <asp:ImageButton ID="btnbutton" runat="server" ImageUrl="~/images/delete_.jpg" CommandName="delete1" CommandArgument='<%# Container.DataItemIndex %>'/>
                        <%--<asp:ConfirmButtonExtender id="cs" TargetControlID="btnbutton" runat="server" ConfirmText="Do you want to delete this record?"></asp:ConfirmButtonExtender>--%>
                       </ItemTemplate>
                       <ItemStyle Width="40px" HorizontalAlign="Center" />
                       </asp:TemplateField>
                <%--<asp:ButtonField ButtonType="Button" Text="Download" CommandName="download" >
                    <ItemStyle HorizontalAlign="Right" />
                    </asp:ButtonField>--%>
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
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
              <ContentTemplate>
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
                    <asp:TemplateField>
                       <ItemTemplate >
                       <asp:ImageButton ID="btnbutton" runat="server" ImageUrl="~/images/delete_.jpg" CommandName="delete1" CommandArgument='<%# Container.DataItemIndex %>'/>
                        <%--<asp:ConfirmButtonExtender id="cs" TargetControlID="btnbutton" runat="server" ConfirmText="Do you want to delete this record?"></asp:ConfirmButtonExtender>--%>
                       </ItemTemplate>
                       <ItemStyle Width="40px" HorizontalAlign="Center" />
                       </asp:TemplateField>
                </Columns>
                </asp:GridView>
                </ContentTemplate>
                </asp:UpdatePanel>
         </div>    
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePane5" runat="server">
  <ContentTemplate>
  <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1"  TargetControlID="lblqns"  >
</asp:ModalPopupExtender>
<asp:Panel ID="Panel1" runat="server" style="display:none; width:200px; background-color:White; border-width:2px; border-color:Black; border-style:solid; padding:20px;">
    <asp:Label ID="lblqns" Text="Do you want to delete this record?" runat="server"></asp:Label>
    <br /><br />
        <asp:Button ID="Button3" runat="server" Text="OK" OnClick="Delete_Click"  />
        <asp:Button ID="Button4" runat="server" Text="Cancel" />
</asp:Panel>
</ContentTemplate>
  </asp:UpdatePanel>        
    </form>
</body>
</html>
