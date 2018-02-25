<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createuser.aspx.cs" Inherits="CmlTechniques.createuser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CML Interactive</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    
    </head>
<body bgcolor="#414141">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <table width="100%" style="font-family: verdana; font-size: small; color: #FFFFFF">
            <tr>
                <td valign="top">
                    
                        <table width="800px">
                            <tr>
                                <td width="150px" >
                                    User ID</td>
                                <td>
                                    <asp:TextBox ID="userid" runat="server" BorderColor="Silver" 
                                        BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="300px"></asp:TextBox>
                                </td>
                                <td >
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>                                    
                                    <asp:Button ID="cmdedit" runat="server" Font-Names="Verdana" 
                                        Font-Size="X-Small" ForeColor="Red" Text="Edit" onclick="cmdedit_Click" />
                                    </ContentTemplate>
                                    </asp:UpdatePanel>    
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    User Name</td>
                                <td colspan="2">
                                    <asp:TextBox ID="username" runat="server" BorderColor="Silver" 
                                        BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    Projects</td>
                                <td colspan="2">
                                    <asp:CheckBoxList ID="chkprj" runat="server" BackColor="White" 
                                        BorderColor="#CCCCCC" Height="16px" Width="304px" ForeColor="Black" >
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="2">
                                    <asp:Label ID="msg" runat="server" Font-Names="Arial,Helvetica,sans-serif" 
                                        Font-Size="Small" ForeColor="Red" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    </td>
                                <td colspan="2">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                        ControlToValidate="userid" ErrorMessage="Invalid User ID" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="cmdcreate" runat="server" 
                                        Font-Names="Verdana" Font-Size="X-Small" ForeColor="Red" 
                                        onclick="cmdcreate_Click" Text="Create User" />
                                </td>
                                <td width="350">
                                    &nbsp;</td>
                            </tr>
                        </table>
                   
                </td>
            </tr>
            <tr>
                <td>
                    
                        &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
