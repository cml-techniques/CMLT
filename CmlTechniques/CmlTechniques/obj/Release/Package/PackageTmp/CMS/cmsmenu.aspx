<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cmsmenu.aspx.cs" Inherits="CmlTechniques.CMS.cmsmenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Menu/styles.css" /> 
     <script type="text/javascript" src="../Menu/jquery.js"></script>
     <script type="text/javascript" src="../Menu/sliding_effect.js"></script>
    <script language="javascript" type="text/javascript">
        function gettime() {
            var dt = new Date();
            document.getElementById('_logout').value = dt.format("dd/MM/yyyy hh:mm:ss tt");
        }
        function cal() {
            gettime();
            var btn = document.getElementById("Button1");
            btn.click();
        }
        function callreport() {
//            parent.document.getElementById("content").src = "cmsreports.aspx";
            var btn = document.getElementById("Button2");
            btn.click();
        }
    </script>
</head>
<body bgcolor="Black"  >
    <form id="form1" runat="server">
    <div style="height:281px">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
       <%-- <table border="0" cellpadding="0" cellspacing="0" width="205px" >
                        <tr>
                        <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl="../images/logo.JPG" 
                        Width="205px" Height="120px" BorderStyle="None" /> 
                        </td>
                        </tr>
                        <tr>
                        <td style="background-position: center top; background-image: url('../images/bx_top.png'); background-repeat: no-repeat" height="33px" align="center" valign="middle" >  
                            </td>
                        </tr>
                        <tr>
                        <td style="background-position: center top; background-image: url('../images/bx_body.png'); background-repeat:repeat-y  " 
                                 align="center" valign="top" bgcolor="Black">
                                <table width="195px" cellspacing="0">
                                    <tr>
                                        <td height="28px" 
                                            style="background-position: center; background-image: url('../images/tit.png'); background-repeat: no-repeat; font-family:Verdana; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onclick="parent.MenuClick('1');" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" align="center">
                                            HOME</td>
                                    </tr>
                                    <tr>
                                        <td  height="28px" 
                                            style="background-position: center; background-image: url('../images/tit.png'); background-repeat: no-repeat; font-family:Verdana; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onclick="cal();" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" align="center">
                                            LOG OFF</td>
                                    </tr>
                                    <tr>
                                        <td  height="28px" 
                                            style="background-position: center; background-image: url('../images/tit.png'); background-repeat: no-repeat; font-family:Verdana; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" onclick="javascript:window.open('http://cmlinternational.co.uk/#/contact-us/4556971903','','left=210,top=100,width=1024,height=600,menubar=1,toolbar=0,scrollbars=1,status=0');" align="center">
                                            CONTACT US</td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="Black" height="28px" onmouseout="this.style.color='#FFFFFF';" onmouseover="this.style.color='blue'" style="background-position: center; background-image: url('../images/tit.png'); background-repeat: no-repeat; font-family: Verdana; font-size: x-small; color: #FFFFFF; cursor: pointer;" onclick="parent.MenuClick('3');" align="center">
                                            REPORTS</td>
                                    </tr>
                                </table>
                                <input id="_logout" type="hidden" runat="server" />
        <asp:Button ID="Button1" name="Button1" runat="server" Text="Button" onclick="Button1_Click" style="display:none" />
                        </td>
                        </tr>
                        <tr>
                        <td style="background-position: center top; background-image: url('../images/bx_bottom.png'); background-repeat: no-repeat" 
                                height="14px" align="center" valign="top" >
                        
                        </td>
                        </tr>
                        </table>--%>
        <div>
        <input id="_logout" type="hidden" runat="server" />
        <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Button ID="Button1" name="Button1" runat="server" Text="Button" onclick="Button1_Click" style="display:none" />
        <asp:Button ID="Button2" name="Button2" runat="server" Text="Button" onclick="Button2_Click" style="display:none" />
        </ContentTemplate>
        </asp:UpdatePanel>
        
        <div id="navigation-block">
        <div><asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo.JPG" 
                        Width="205px" Height="120px" BorderStyle="None" /></div>
        <ul id="sliding-navigation">
        <li class="sliding-element"><a href="#" onclick="javascript:parent.MenuClick('1');">HOME</a></li> 
        <li class="sliding-element"><a href="#" onclick="cal();">LOG OFF</a></li> 
        <li class="sliding-element"><a href="#" onclick="javascript:window.open('http://cmlinternational.co.uk');">CONTACT US</a></li> 
        <li class="sliding-element" id="rptmenu" runat="server"><a href="#" onclick="callreport();">REPORTS</a></li>
        <%--<li class="sliding-element" id="dbmenu" runat="server"><a href="#" onclick="javascript:parent.MenuClick('4');">DASHBOARD</a></li>--%>
        </ul>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
