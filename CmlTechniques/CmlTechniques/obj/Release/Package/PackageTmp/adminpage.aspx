<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminpage.aspx.cs" Inherits="CmlTechniques.adminpage" %>

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
       <script type="text/javascript">
           function ShowTime() {
               var dt = new Date();
               document.getElementById('time').innerHTML = dt.toLocaleDateString() + ' , ' + dt.toLocaleTimeString();
               window.setTimeout("ShowTime()", 1000);
           }
                
    </script>
    <script language="javascript" type="text/javascript">
        function callpage(page) {
            if (page == "1")
                document.getElementById("myframe").src = "projectmanagement.aspx";
            else if (page == "2")
                document.getElementById("myframe").src = "projectmaster.aspx";
            else if (page == "3")
                document.getElementById("myframe").src = "usercreation.aspx";
            else if (page == "4")
                document.getElementById("myframe").src = "CMS/cmsmanagement.aspx";
            else if (page == "5")
                document.getElementById("myframe").src = "SystemConfig.aspx";
            else if (page == "6")
                document.getElementById("myframe").src = "AMS/Admin.aspx";    
            else
                alert("Invalid Selection");
        } 
    
    </script>
   
    </head>
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
        function logoff() {
           location.replace('https://cmltechniques.com');
        }
    </script>
    <script type="text/javascript">
        var myclose = false;

        function ConfirmClose() {
//            if (event.clientY < 0) {
//                window.open("logout.aspx", "mywindow1", "height=500px;width=500px;status=1");
//                event.returnValue = "You have attempted to leave this page. If you want to continue, " + "Please Log Off from the Application." + "\n\n" + " Are you sure you want to exit this page?";
//                setTimeout('myclose=false', 100);
//                myclose = true;
            //            }
            cal();s
        }
        function HandleOnClose() {
            if (myclose == true) alert("Window is closed");
        }
    </script>
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
    </script>
<body bgcolor="#0B6F87" >
<%--onbeforeunload="javascript:ConfirmClose();" onunload="javascript:HandleOnClose();"  --%>
    <form id="form1" runat="server">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div  >
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;position:fixed; ">
            <tr>
                <td bgcolor="Black" width="210px" valign="top" rowspan="2" align="center" 
                    height="100%" 
                    style="border-right-style: outset; border-right-width: 2px; border-right-color: #092443" >                
                    <table border="0" cellpadding="0" cellspacing="0" width="205px">
                        <tr>
                        <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo.JPG" 
                        Width="205px" Height="120px" BorderStyle="None" /> 
                        </td>
                        </tr>
                        <tr>
                        <td style="background-position: center top; background-image: url('images/bx_top.png'); background-repeat: no-repeat" 
                                height="33px" align="center" valign="top" >
                        </td>
                        </tr>
                        <tr>
                        <td style="background-position: center top; background-image: url('images/bx_body.png'); background-repeat:repeat-y  " 
                                 align="center" valign="top" bgcolor="Black">
                                
                                <table width="195px" cellspacing="0">
                                    <tr>
                                        <td height="28px" 
                                            style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onclick="javascript:window.location.href='home.aspx';" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" align="center" >
                                        <%--<a href="cmlhome.aspx"  style="text-decoration:none;font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; color: #FFFFFF" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" >HOME</a>
                                            &nbsp;--%>HOME</td>
                                    </tr>
                                    <tr>
                                        <td  height="28px" 
                                            style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onclick="cal();" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" align="center" >
                                        <%--<a href="default.aspx"   style="text-decoration:none;font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; color: #FFFFFF" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" >LOG OFF</a>
                                            &nbsp;--%>LOG OFF</td>
                                    </tr>
                                    <tr>
                                        <td height="28px" 
                                            style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onclick="javascript:window.location.href='adminpage.aspx';" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" align="center" ><%--<a href="adminpage.aspx"  style="text-decoration:none;font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; color: #FFFFFF" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" >ADMINISTRATION</a>
                                            &nbsp;--%>MANAGEMENT</td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="Black" height="28px" 
                                            onclick="javascript:window.open('CMS/CMLUserLog.aspx');" 
                                            onmouseout="this.style.color='#FFFFFF';" onmouseover="this.style.color='blue'" 
                                            style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; cursor: pointer;" align="center">
                                            ONLINE USERS</td>
                                    </tr>
                                </table>
                              <input id="_logout" type="hidden" runat="server" />
        <asp:Button ID="Button1" name="Button1" runat="server" Text="Button" onclick="Button1_Click" style="display:none" />  
                        </td>
                        </tr>
                        <tr>
                        <td style="background-position: center top; background-image: url('images/bx_bottom.png'); background-repeat: no-repeat" 
                                height="14px" align="center" valign="top" >
                        
                        </td>
                        </tr>
                        </table>
                </td>
                <td valign="middle" height="30px" align="right"                         
                    style="background-image: url('images/tophead.png'); background-repeat: repeat-x;"  width="100%">
                   
                    </td>
            </tr>
            <tr>
                <td style="top:35px;bottom:5px;vertical-align:top;left:212px;right:5px;position:absolute;";>
                <div style="width: 100%; height: 100%">
                    <iframe id="myframe" runat="server" frameborder="0" height="100%" width="100%" name="myframe"></iframe>                 
                   
         </div>  
        
                </td>
            </tr>
           
        </table>
        </div>
        
        
        </ContentTemplate>
        </asp:UpdatePanel>
    
    </form>
</body>
</html>
