<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="emailmypassword.aspx.cs" Inherits="CmlTechniques.emailmypassword" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="False" 
                                                ForeColor="#3366CC" NavigateUrl="~/Default.aspx"  >Back to Login</asp:HyperLink>
                                            &nbsp;
                                            </ContentTemplate>
                                            </asp:UpdatePanel>
                                            </td>
                                    </tr>
                                </table>
</asp:Content>
