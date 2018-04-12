<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="CmlTechniques.userlogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 <meta http-equiv="X-UA-Compatible" content="IE=9" />
<meta content="cmldubai,cmlinternational,trust computer; charset=iso-8859-1" http-equiv="keywords" />
<meta name="description" content="CML Techniques is a secure web based data management system that has been developed by CML to contain all your commissioning and handover documents at the touch of a button. " />
<meta name="keywords" content="cmldubai,cmlinternational,trust computer" />
<meta name="robots" content="index,follow" />
<meta name="google-site-verification" content="l2vIf74IXoagqayrbpeqpI1To0cNklzWDKhikdGtLPI" />
<meta name="YahooSeeker" content="index, follow" />
<meta name="msnbot" content="index, follow" />
<meta name="googlebot" content="index, follow" />
<meta name="OriginalPublicationDate" content="2010/03/23 15:00:00" />
 
<%--<META name="REVISIT-AFTER" content="1 days"><LINK rel="shortcut icon" href="images/Favicon.ico" type="image/x-icon" />
<LINK rel="icon" type="image/gif" href="animated_favicon.gif" />--%>
    <title>CML Techniques | Online Project Management System</title>
    <link rel="shortcut icon" href="Images/favicon.ico"/> 
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <script type="text/javascript">
        function getIP() {
            var ip = '<%=Request.ServerVariables["REMOTE_ADDR"]%>';
            document.getElementById('_ip').value = ip;
            var dt = new Date();
            document.getElementById('_login').value = dt.format("dd/MM/yyyy hh:mm:ss tt");
        }
        function getInternetExplorerVersion()
        // Returns the version of Internet Explorer or a -1
        // (indicating the use of another browser).
        {
            var rv = -1; // Return value assumes failure.
            if (navigator.appName == 'Microsoft Internet Explorer') {
                var ua = navigator.userAgent;
                var re = new RegExp("MSIE ([0-9]{1,}[\.0-9]{0,})");
                if (re.exec(ua) != null)
                    rv = parseFloat(RegExp.$1);
            }
            return rv;
        }

        function checkVersion() {
            var msg = "You're not using Internet Explorer.";
            var ver = getInternetExplorerVersion();

            if (ver != -1) {
                if (ver >= 9.0 && ver != 10.0)
                    document.getElementById("brmsg").style.display = 'none';
                else
                    document.getElementById("brmsg").style.display = 'block';
            }
            else
                document.getElementById("brmsg").style.display = 'none';
            //alert(ver);
        }
        function hide() {
            document.getElementById("brmsg").style.display = 'none';
        }
</script>
    <style type="text/css">
    body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	}
	.style1        {            width: 307px;            color: #FFFFFF;            font-family: "Century Gothic";            /*font-family:Verdana;*/            font-size:small;            text-align: justify;            /*height: 150px;*/            padding:0 0 0 10px;            vertical-align:top;        }
        .style2        {            width: 307px;            color: #999999;            font-family: "Century Gothic";            font-size:small;            /*font-family:Verdana;            font-size:11px;*/            padding:0 0 0 10px;            vertical-align:top;            text-align:left;        }
        .style3        {            width: 307px;            color: #FFFFFF;            font-family: "Century Gothic";            font-size: small;            /*font-family:Verdana;            font-size:11px;*/            text-align: justify;            padding:0 0 0 10px;            vertical-align:baseline;            }
    </style>
    <script type="text/javascript">
        function call() {
             //window.open("cmlhome.aspx");
           //location.replace("cmlhome.aspx");
            location.replace("home.aspx");
        
        }
    </script>
    <script type = "text/javascript" >
        function disableBackButton() {
            window.history.forward();
        }
        setTimeout("disableBackButton()", 0);
</script>


</head>
<body style="background-image:url('images/login_bg.jpg'); background-color:Black;" onload="javascript:disableBackButton();javascript:getIP();javascript:checkVersion();">
    <form id="form1" runat="server">
                                            <input id="_login" type="hidden" 
        runat="server" />
                                            <input id="_ip" type="hidden" 
        runat="server" />
    <input id="Hidden2" type="hidden" runat="server" /><input id="Hidden1" type="hidden" runat="server" />
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <table 
            style="position: absolute ; width: 100%; height: 100%; ">
            <tr>
                <td   align="center"  valign="middle" 
                    style="background-repeat: no-repeat" height="150px" >
                    &nbsp;&nbsp;
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                    <asp:Image ID="Image1" runat="server" Height="120px" 
                        ImageUrl="~/images/logo.JPG" Width="198px" />
                            &nbsp;</td>
                            <td>
                                        
                    <%--<asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="45pt"  
                        ForeColor="White" Text="MANAGEMENT SYSTEMS"></asp:Label>--%>
                        
                        <span id="Label1" style="color:White;font-family:Arial;font-size:45pt;">MANAGEMENT</span>&nbsp; <span 
                                    id="Label2" style="font-family:Arial;font-size:45pt;color:#999999" >SYSTEMS</span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" height="100%">
                <br />
                <br />
                
                    <table border="0" cellpadding="0" cellspacing="0" align="center" >
                        <tr>
                            <td align="center" height="350px" 
                                style="background-image: url('images/loginbox.png'); background-repeat: no-repeat ;" 
                                valign="top" width="600px" rowspan="3">
                                <br />
                                <br />
                                <br />
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" style="font-family: Arial, Helvetica, sans-serif; font-size: small; color: #FFFFFF; background-color:Transparent; height: 175px;" 
                                    >
                                    <tr>
                                        <td align="left" width="150px" height="25px">
                                            <asp:Label ID="lbluid" runat="server" Text="User Id"></asp:Label>
                                        </td>
                                        <td align="left" colspan="2">
                                            <asp:TextBox ID="_uid" runat="server" style="margin-left: 0px" Width="395px"
                                                ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" height="25px">
                                            <asp:Label ID="lblpwd" runat="server" Text="Password"></asp:Label></td>
                                        <td align="left" colspan="2">
                                            <asp:TextBox ID="_pwd" runat="server" style="margin-left: 0px" 
                                                TextMode="Password" Width="213px" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" height="25px">
                                            <asp:Label ID="lblnpwd" runat="server" Text="New Password"></asp:Label></td>
                                        <td colspan="2" align="left">
                                            <asp:TextBox ID="_pwdn" runat="server" style="margin-left: 0px" 
                                                TextMode="Password" Width="213px" ></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td align="left" height="25px">
                                            <asp:Label ID="lblcpwd" runat="server" Text="Confirm New Password"></asp:Label></td>
                                        <td colspan="2" align="left">
                                            <asp:TextBox ID="_pwdc" runat="server" style="margin-left: 0px" 
                                                TextMode="Password" Width="213px" ></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td height="25px">
                                            &nbsp;</td>
                                        <td align="left" >
                                            <asp:CheckBox ID="chkremind" runat="server" 
                                                Text="Save my user id and password" Checked="true" Width="300px" />
                                                                                       
                                        </td>
                                        <td align="left">
                                                 &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td height="25px">
                                            <asp:Label ID="lblprm" runat="server" Text=""></asp:Label>
                                            &nbsp;</td>
                                        <td align="left" width="300px">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="cmdlogin" runat="server" Height="25px" onclick="cmdlogin_Click" 
                                                        Text="Login" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" height="60px">
                                        <%--<div id="myprogress" runat="server" style="position: absolute; z-index: 40; top: 0; left: 50%">
                                         </div>--%>   
                                            <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                                <ProgressTemplate>
                                                    <asp:Image ID="imgload" runat="server" ImageUrl="~/images/loading30.gif" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    </table>
                                    <br />
                                <asp:Button ID="btnchg" runat="server" Text="Change Password" 
                                                style="background-color:Transparent;cursor:pointer;border:none" 
                                                ForeColor="#3366CC" onclick="btnchg_Click" />  
                                            <asp:Button ID="btnemail" runat="server" 
                                                Text="Email Password" 
                                                style="background-color:Transparent;cursor:pointer;border:none" 
                                                ForeColor="#3366CC" onclick="btnemail_Click" />
                                                </ContentTemplate>
                                </asp:UpdatePanel>
                                <div style="margin:50px auto;width:90%;background-color:#d1d1d1;padding:10px;display:none" id="brmsg" >
            <p style="color:Red;margin:3px">The Browser we detected is unsupported and may result in unexpected behaviour.</p>
            <p style="margin:3px">Please upgrade with <a href="http://windows.microsoft.com/en-us/internet-explorer/download-ie" style="color:#3366CC;text-decoration:none;" target="_blank">latest version</a> | <a href="#" style="color:#3366CC;text-decoration:none;" onclick="hide();">Dismiss</a></p>
            </div>
                              </td>  
                            <td class="style1">
                            WELCOME TO <strong>CML TECHNIQUES</strong> WEB BASED DOCUMENTATION MANAGEMENT                            <p style="margin:5px 0 0 0">CML Techniques is a bespoke web based system developed using our expertise and                                 many years of experience, working with major clients to progressively collate,                                 review and integrate the complete suite of project record documentation as the                                 project develops. Typically the following documentation would be included</p>                                
                                
                                </td>
                           
                        </tr>
                        <tr>
                            <td class="style2" align="left">
                                <ul style="padding:0 0 0 15px;margin:5px 0 5px 0">
                                <li>Operating &amp; Maintenance Manuals including suppliers Literature</li>
                                <li>Commissioning &amp; Testing Documentation</li>
                                <li>As-Built Drawings</li>
                                <li>Asset Registers l Health &amp; Safety/ CDM Files</li>
                                <li>Completion Files l Building Energy Log-Books...</li>
                                </ul>
                            </td>
                           
                        </tr>
                        <tr>
                            <td align="left" class="style3"  >
                            CML Techniques also includes a unique commercial snagging, workflow & reporting solution using the latest technologies to improve communication and efficiency in snagging and defects management. The system is based on a robust platform - but is made bespoke for each client and project. 
                                <p style="margin:5px 0 0 0"><a href="http://cmlinternational.co.uk/#/contact-us/4556971903" target="_blank">CLICK here to Contact Us for more information</a> </p>
                                <p style="margin:0px">or visit <a href="http://www.cmlinternational.net" target="_blank">www.cmlinternational.net</a></p>
                                
                            </td>
                           
                        </tr>
                        </table>
                </td>
            </tr>
            <tr>
            <td  >
            
            </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
