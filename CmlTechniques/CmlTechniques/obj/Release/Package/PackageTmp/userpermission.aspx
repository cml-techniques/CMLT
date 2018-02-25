<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userpermission.aspx.cs" Inherits="CmlTechniques.userpermission" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CML Interactive</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <style type="text/css">
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
         
       </style> 
    </head>
<body>
    <form id="form1" runat="server">
    <div style="width: 100%; height: 90%; overflow: auto">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
        <table style="font-family: verdana; font-size: x-small; width: 100%; height: 100%;">
            <tr>
                <td valign="top" width="100%"> 
                    <asp:GridView ID="mygriduser" runat="server" CellPadding="4" 
                        ForeColor="#333333" GridLines="Horizontal" Width="100%" 
                        AutoGenerateColumns="False" HorizontalAlign="Left" 
                        onrowediting="mygriduser_RowEditing" 
                        >
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="false" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="false" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="false" ForeColor="White" 
                            HorizontalAlign="Left" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                        <asp:BoundField DataField="userid" HeaderText="USER ID" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="400px" />
                            </asp:BoundField>
                        <asp:BoundField DataField="username" HeaderText="USER NAME" >
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                        <asp:BoundField DataField="access_level" HeaderText="ACCESS LEVEL" >
                        
                            <HeaderStyle HorizontalAlign="Left" />
                            
                            </asp:BoundField>
                            <asp:BoundField DataFormatString="ACTIVE" DataField=""  HeaderText="STATUS" />
                            <asp:CommandField ButtonType="Button" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:CommandField>
                            
                        
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="Panel1" runat="server">
                        <table >
                            <tr>
                                <td width="100px">
                                    User Access Level</td>
                                <td>
                                    <asp:DropDownList ID="draccess" runat="server" Height="25px" Width="271px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Services</td>
                                <td>
                                    <asp:CheckBoxList ID="chkservice" runat="server" BackColor="#FFFF99" 
                                        Height="17px" Width="271px">
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                        </table>
                        <br />
                    <br />
                    <asp:Button ID="cmdsubmit" runat="server" Text="Submit" onclick="cmdsubmit_Click" 
                             />
                        
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        </asp:UpdatePanel>
                        
                    </asp:Panel>
                        
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
