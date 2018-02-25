<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigMinutes.aspx.cs" Inherits="CmlTechniques.CMS.ConfigMinutes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <h1>Minutes User Configuration</h1>
        <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:GridView ID="mygrid" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
                BorderWidth="1px" onrowcommand="mygrid_RowCommand">
                <RowStyle BackColor="White" ForeColor="#003399" />
            <Columns>
            <asp:BoundField DataField="userid" HeaderText="USER ID" >
                            <ItemStyle Width="400px"  />
                            </asp:BoundField>
                        <asp:BoundField DataField="username" HeaderText="USER NAME" >
                            <ItemStyle Width="400px"  />
                            </asp:BoundField>
                        <asp:BoundField DataField="minutes" HeaderText="ACCESS LEVEL" >
                            <ItemStyle Width="150px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:ButtonField CommandName="access" ButtonType="Link" Text="Permission" />
            </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
            
        </div>
         <asp:Panel ID="pnlPopup1" runat="server" Width="300px" Height="90px" BackColor="#003399" ForeColor="White" style="padding:15px;"   >
            <div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                <table style="width:100%">
                <tr>
                <td style="width:100px">Access Level</td>
                <td>
                    <asp:DropDownList ID="draccess" runat="server" Width="100%">
                    <asp:ListItem Text="Review Only" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Review/Comments" Value="2"></asp:ListItem>
                    <asp:ListItem Text="No Access" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                    </td>
                </tr>
               
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
               
                <tr>
                <td align="center">
                   
                    
                </td>
                <td>
                <table>
                <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <asp:Button ID="btnupdate" runat="server" Text="Save" 
                        onclick="btnupdate_Click" Width="75px"  />
                    </ContentTemplate>
                    </asp:UpdatePanel>
                        </td>
                <td><asp:Button ID="btncancel" runat="server" Text="Cancel" 
                        onclick="btncancel_Click" Width="75px"  /></td>
                </tr>
                </table>
                
                </td>
                </tr>
                </table>
             
             
             </ContentTemplate>
                </asp:UpdatePanel>
            </div>
                        
                  </asp:Panel>
                  
                    <asp:Button ID="btnDummy1" runat="server" Text="Button" style="display:none;"  />
                  <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender1" runat="server" 
                  TargetControlID="btnDummy1"  PopupControlID="pnlPopup1"
                  BackgroundCssClass="modal"
                  DropShadow="true">
                  </asp:ModalPopupExtender> 
    </div>
    </form>
</body>
</html>
