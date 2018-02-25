<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="administration.aspx.cs" Inherits="CmlTechniques.administration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="page.css" rel="stylesheet" type="text/css" />
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" /> 
   </head>
<body bgcolor="#0B6F87"  >
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <table style="font-family: verdana; position: fixed; width: 100%; height: 100%;">
            <tr>
                <td height="100%" width="100%" valign="middle">
                <center>
                <div style="float:none;" >
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <table style="font-family: Verdana; font-size: small; height: 100%;" 
                                      width="600px" border="0" cellpadding="0" cellspacing="0" >
                                      <tr>
                                          <td align="left" valign="top" width="150px">
                                              <%--<asp:ImageButton ID="ImageButton1" runat="server" 
                                                  ImageUrl="~/images/pr_m.png" onclick="ImageButton1_Click" />--%>
                                              <asp:Button ID="Button1" runat="server" Text="" 
                                                  style="background:url('/images/pr_m.png');border:none"  Width="172px" 
                                                  Height="150px" onclick="Button1_Click"/>
                                          </td>
                                          <td align="left" valign="top" width="150px">
                                              &nbsp;</td>
                                          <td align="left" valign="middle" width="150px">
                                              <%--<asp:ImageButton ID="ImageButton2" runat="server" 
                                                  ImageUrl="~/images/con_prj.png" onclick="ImageButton2_Click" />--%>
                                                  <asp:Button ID="Button2" runat="server" Text="" 
                                                  style="background:url('/images/con_prj.png');border:none"  Width="172px" 
                                                  Height="150px" onclick="Button2_Click"/>
                                          </td>
                                          <td align="left" valign="middle" width="150px">
                                              &nbsp;</td>
                                          <td align="left" valign="middle" width="150px">
                                              <%--<asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/on_user.png" 
                                                  onclick="ImageButton3_Click" />--%>
                                                  <asp:Button ID="Button3" runat="server" Text="" 
                                                  style="background:url('/images/on_user.png');border:none"  Width="172px" 
                                                  Height="150px" onclick="Button3_Click"/>
                                          </td>
                                          <td align="left" valign="middle" width="150px">
                                              &nbsp;</td>
                                          <td align="left" valign="top">
                                              <%--<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/ctrl_pnl.png" onclick="ImageButton4_Click" 
                                                  />--%>
                                                  <asp:Button ID="Button4" runat="server" Text="" 
                                                  style="background:url('/images/ctrl_pnl.png');border:none"  Width="172px" 
                                                  Height="150px" onclick="Button4_Click"/>
                                          </td>
                                      </tr>
                                      </table>
                 </ContentTemplate>
                    </asp:UpdatePanel>
                                      <asp:Panel ID="pnlPopup" runat="server" Width="350px" style="display:none;" >
                    <asp:Label ID="Label1" runat="server" Font-Names="verdana" Font-Size="Medium" ForeColor="White"></asp:Label>
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" id="tblPopup">
                            <tr>
                                <td class="heading"  style="background-image: url('images/headingbg_13.gif'); background-repeat: repeat-x;" ><asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                 &nbsp;<asp:Label ID="mhead" runat="server" Font-Names="verdana" Font-Size="Medium" ForeColor="White" Text="Select Module"></asp:Label>                                </ContentTemplate>
                                    </asp:UpdatePanel>
     </td>
                            </tr>
                            
                            <tr>
                                <td align="center" height="75px" valign="middle"  >
                                   <asp:DropDownList ID="drmodules" runat="server" Width="90%" Font-Bold="True" 
                                     Font-Names="Verdana" Font-Size="Small" ForeColor="Blue" Height="20px">
                                     <asp:ListItem>--select module--</asp:ListItem>
                                     <asp:ListItem Value="0">DOCUMENT MANAGEMENT SYSTEM - DMS</asp:ListItem>
                                     <asp:ListItem Value="1">COMMISSIONING MANAGEMENT SYSTEM - CMS</asp:ListItem>
                                     <asp:ListItem Value="2">ASSET MANAGEMENT SYSTEM - AMS</asp:ListItem>                                                                 </asp:DropDownList>
                                
                                    </td>
                            </tr>
                            <tr>
                                <td class="footer" height="30px" >
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                    <asp:Button ID="btnCont" runat="server" Text="Continue" OnClick="btnCont_Click"  /><asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click"   />
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                     <div id="myprogress" runat="server" style="position: absolute; z-index: 40; top: 50%; left: 50%">
                                            <asp:Image ID="myimage" runat="server" ImageUrl="~/images/loading30.gif" />
                                            </div>
                                            </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                       </table>
                  </asp:Panel>
                  
                    <asp:Button ID="btnDummy" runat="server" Text="Button" style="display:none;" />
                  <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" 
                  TargetControlID="btnDummy"  PopupControlID="pnlPopup"
                  BackgroundCssClass="modal" >
                  </asp:ModalPopupExtender>
                </div>
                </center>
                </td>
            </tr>
            </table>
    </div>
    </form>
</body>
</html>
