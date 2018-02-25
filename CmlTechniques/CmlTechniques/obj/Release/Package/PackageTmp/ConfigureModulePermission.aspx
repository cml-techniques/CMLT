<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigureModulePermission.aspx.cs" Inherits="CmlTechniques.CMS.ConfigureModulePermission" %>

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
    <style type="text/css">
        .dvcenter
        {
            width:1000px;
            margin:auto;
        }
    </style>
</head>
<body  bgcolor="#D1DEF1">
    <form id="form1" runat="server">
    <div class="dvcenter">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <h1>Module level permission</h1>
        <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
        <div>
            <div>
                <table>
                    <tr>
                        <td> User Id</td>
                        <td>
<asp:DropDownList ID="ddlusers" runat="server" Width="100%" OnSelectedIndexChanged="ddlusers_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            <table>
                <tr>
                    <td>Modules :</td>
                    <td>  <asp:DropDownList ID="ddlmodules" runat="server" Width="100%">
                      <%--<asp:ListItem Text="Admin" Value="1"></asp:ListItem>--%>
                    <%--<asp:ListItem Text="Review Only" Value="0"></asp:ListItem>--%>
                    </asp:DropDownList>

                    </td>
                    <td> Permision</td>
                    <td>
                          <asp:DropDownList ID="ddlPerms" runat="server" Width="100%">
                      <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Review Only" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    </td>
                    <td>
 <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                    <asp:Button ID="btnadd" runat="server" Text="Add" 
                        onclick="btnadd_Click" Width="75px"  />
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
                CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
                BorderWidth="1px" onrowcommand="mygrid_RowCommand">
                <RowStyle BackColor="White" ForeColor="#003399" />
            <Columns>
                        <asp:BoundField DataField="Permission_Id" HeaderText="Module Id" >

                            <ItemStyle Width="150px" HorizontalAlign="Center" />
                            </asp:BoundField>
                                        <asp:BoundField DataField="Module" HeaderText="Module" >

                            <ItemStyle Width="150px" HorizontalAlign="Center" />
                            </asp:BoundField>
                 <asp:BoundField DataField="Permission" HeaderText="Permission" >

                            <ItemStyle Width="150px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:ButtonField CommandName="access" ButtonType="Link" Text="Modify" />
            </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
            
        </div>
         <asp:Panel ID="pnlshow" runat="server" Width="300px" Height="90px" BackColor="#003399" ForeColor="White" style="padding:15px;"   >
            <div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                <table style="width:100%">
                <tr>
                <td style="width:100px">Access Level</td>
                <td>
                    <asp:DropDownList ID="draccess" runat="server" Width="100%">
                      <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Review Only" Value="0"></asp:ListItem>
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

            <asp:Button ID="btnDummy7" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender7" runat="server" TargetControlID="btnDummy7"
        PopupControlID="pnlshow" BackgroundCssClass="modal">
    </asp:ModalPopupExtender>
                  
                    
    </div>
    </form>
</body>
</html>
