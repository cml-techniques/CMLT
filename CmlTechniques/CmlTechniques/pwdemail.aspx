<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pwdemail.aspx.cs" Inherits="CmlTechniques.pwdemail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <table align="center" border="0" cellpadding="0" cellspacing="2" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: small; color: #FFFFFF" 
                                    width="515">
                                    <tr>
                                        <td align="left" colspan="2">
                                            <asp:Label ID="_msg" runat="server" Font-Names="Arial,Helvetica,sans-serif" 
                                                Font-Size="Medium" ForeColor="#FF3300"></asp:Label>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="150px">
                                            User Id&nbsp;&nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="_uid" runat="server" style="margin-left: 0px" Width="395px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td align="left">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                            <asp:Button ID="cmdlogin" runat="server" Height="23px"  
                                                Text="Email My Password" Width="135px" onclick="cmdlogin_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <%--<asp:ConfirmButtonExtender ID="cmdlogin_ConfirmButtonExtender" runat="server" 
                                                ConfirmText="" Enabled="True" TargetControlID="cmdlogin">
                                            </asp:ConfirmButtonExtender>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td align="left">
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    </table>
    </div>
    </form>
</body>
</html>
