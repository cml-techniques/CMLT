<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cmlhome.aspx.cs" Inherits="CmlTechniques.cmlhome" EnableViewStateMac="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CML Techniques</title>
    <style type="text/css">
    body 
   {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;  
	
    }
        </style>
    <script type="text/javascript">
        function ShowTime()
        {
            var dt = new Date();
            document.getElementById('time').innerHTML = dt.toLocaleDateString() + ' , ' + dt.toLocaleTimeString();
            //document.getElementById('_login').innerHTML = dt.localeFormat("dd/MM/yyyy");
            window.setTimeout("ShowTime()", 1000);
        }
        function Unload() {
//            if (window.event.clientY < 0 && window.event.clientY < -80) {
               
//                PageMethods.AbandonSession();
            //location.replace("logout.aspx");
            //window.open(parent.location);
            location.replace("logout.aspx");
            //location.replace("logout.aspx");
            //alert("Application is closing!");
                //javascript:window.location.href='adminpage.aspx';"

        }
        function handleWindowClose() {
            if (window.event.clientX < 0 || window.event.clientY < 0) {
                //                                alert("yes you are");
                //                               window.open(parent.location);
                ////                               location.replace("logout.aspx");
                ////                               window.close();

                window.open("logout.aspx");
            }
            
        }
        //window.onbeforeunload = handleWindowClose;
    </script>
    <script type="text/javascript">
        function getIP() {
            var ip = '<%=Request.ServerVariables["REMOTE_ADDR"]%>';
            document.getElementById('_ip').value = ip;
            var dt = new Date();
            document.getElementById('_login').value = dt.toString();
        }
</script>
    <script type="text/javascript">
        function call(mod) {
            if (mod == "1") {
                location.replace("projecthome.aspx");
                //location.replace("project_home.aspx");
            }
            else if (mod == "2") {
                location.replace("cmsnew.aspx");
            }
            else if (mod == "3") {
            location.replace("SNS/SnaggingSystem.aspx");
            }
            
        }
        
    </script>
<link href="StyleSheet1.css" rel="stylesheet" type="text/css" /> 
   
</head>
<script type="text/javascript" language="javascript">
    var myclose = false;

    function ConfirmClose() {
        if (event.clientY < 0) {
            window.open("logout.aspx", "mywindow1", "height=500px;width=500px;status=1");
            event.returnValue = "You have attempted to leave this page. If you want to continue, " + "Please Log Off from the Application." + "\n\n" + " Are you sure you want to exit this page?";
            //myservice.HelloWorld();
            
           // alert(re);
            setTimeout('myclose=false', 100);
            myclose = true;
        }
    }
    function HandleOnClose() {
        if (myclose == true) alert("Window is closed");
    }
    </script>
<body onload="javascript:ShowTime();javascript:getIP();" onbeforeunload="javascript:ConfirmClose();" onunload="javascript:HandleOnClose();"   >
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ToolkitScriptManager>   
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
    <ContentTemplate>
    
    <div>
    
        <table  border="0" cellpadding="0" cellspacing="0" style=" position:fixed; width: 100%; height: 100%;" >
            <tr>
                <td bgcolor="Black" width="210px" valign="top" rowspan="3" align="center" 
                    height="100%" 
                    style="border-right-style: outset; border-right-width: 2px; border-right-color: #092443" >
                <div>          
                    <%--<asp:Image ID="Image4" runat="server" ImageUrl="~/images/logo.JPG" 
                        Width="205px" Height="120px" BorderStyle="None" />      
                    <br />--%>
                    <table border="0" cellpadding="0" cellspacing="0" width="205px" >
                        <%--<tr>
                        <td style="background-position: center top; background-repeat: repeat; background-image: url('images/headingbg_13.gif');" 
                                height="34" bgcolor="Black">
                                
                                &nbsp;</td>
                        </tr>--%>
                        <tr>
                        <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo.JPG" 
                        Width="205px" Height="120px" BorderStyle="None" /> 
                        </td>
                        </tr>
                        <tr>
                        <td style="background-position: center top; background-image: url('images/bx_top.png'); background-repeat: no-repeat" height="33px" align="center" valign="top" >
                                       
                        </td>
                        </tr>
                        <tr>
                        <td style="background-position: center top; background-image: url('images/bx_body.png'); background-repeat:repeat-y  " 
                                 align="center" valign="top" bgcolor="Black">
                                <table width="195px" cellspacing="0">
                                    <tr>
                                        <td height="28px" 
                                            style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family: verdana; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" align="center">HOME</td>
                                    </tr>
                                    <tr>
                                        <td height="28px" style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family: verdana; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onclick="javascript:window.location.href='logout.aspx';" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" align="center" >
                                        <%--<a href="Default.aspx"   
                                                style="text-decoration:none;font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; color: #FFFFFF; vertical-align: middle; width: 195px; height: 30px;" 
                                                onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" >LOG OUT
                                                </a>--%>
                                            LOG OFF</td>
                                    </tr>
                                    <tr>
                                        <td  height="28px" style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family: verdana; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black"  onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" align="center"  >
                                        <%--<a href="#"  style="text-decoration:none;font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; color: #FFFFFF" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';">CONTACT US</a>
                                            &nbsp;--%><a href="mailto:admin@cmlinternational.net" style="text-decoration:none;color: #FFFFFF">CONTACT US</a> </td>
                                    </tr>
                                    <tr>
                                        <td  height="28px" id="_tdadmin" runat="server" style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family: verdana; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onclick="javascript:window.location.href='adminpage.aspx';" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" align="center"  >
                                        <%--<a href="adminpage.aspx"  style="text-decoration:none;font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; color: #FFFFFF" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';"  >--%>ADMINISTRATION<%--</a>--%>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                                
                        </td>
                        </tr>
                        <tr>
                        <td style="background-position: center top; background-image: url('images/bx_bottom.png'); background-repeat: no-repeat" 
                                height="14px" align="center" valign="top" >
                        
                        </td>
                        </tr>
                        </table>                   
                    <input id="_ip" type="hidden" value="" runat="server" />  
                    <input id="_login" type="hidden" value="" runat="server" />  
                    
                </div>
                    
                    </td>
                <td valign="top" style="height:20%;width:100%; ">
                <%--<div style="width: 100%; height: 100%; overflow: auto">--%>
                <%--<asp:Image ID="Image3" runat="server" ImageUrl="images/Website_Heading.jpg" />--%>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td height="100%" bgcolor="Black" colspan="2">
                            <asp:Image ID="Image2" runat="server" ImageUrl="images/Website_Heading.jpg" Height="121px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="background-image: url('images/tophead.png'); background-repeat: repeat-x" 
                                valign="middle" align="left" height="30px">
                                <asp:Label ID="userinfo" runat="server" Font-Names="verdana" 
                        Font-Size="Small" ForeColor="White"></asp:Label><asp:Label ID="time" runat="server" Font-Names="verdana" Font-Size="Small" ForeColor="White"></asp:Label>&nbsp;         
                            </td>
                            <td align="right" height="30px" 
                                style="background-image: url('images/tophead.png'); background-repeat: repeat-x" 
                                valign="middle">
                                <%--<iframe id="fr1" runat="server" src="Scripts/search.html" frameborder="0" height="20px"></iframe>--%></td>
                        </tr>
                     </table>
                <%--</div>--%>
                </td>
            </tr>
            
            <tr>
                <td  height="70%" valign="top" width="100%">
                <%--<div >--%>
                <iframe id="fr2" name="fr2"  frameborder="0" width="100%" height="100%" src="welcome.aspx" runat="server" 
                        ></iframe>
                    <%--<table  border="0" cellpadding="0" cellspacing="0" style="table-layout:fixed;width:100%"  >
                        <tr>
                            <td                           
                                style="background-position: right top; background-repeat: repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle">
                                &nbsp;</td>
                            <td 
                                
                                style="background-position: left top; background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle" bgcolor="White" width="30px">
                                &nbsp;</td>
                            <td height="10px" 
                                
                                style="background-position: right top; background-repeat: repeat-x; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle" bgcolor="White">
                                &nbsp;</td>
                            <td 
                                
                                style="background-position: right top; background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle" width="30px">
                                &nbsp;</td>
                            <td 
                                
                                style="background-position: right top; background-repeat: repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="200px" 
                                
                                style="background-position: right top; background-repeat: repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle">
                                <asp:Label ID="Label3" runat="server" Text="" Width="10px"></asp:Label>
                            </td>
                            <td height="200px" 
                                
                                style="background-position: left top; background-image: url('images/left.png'); background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle" bgcolor="White" width="30px">
                                &nbsp;</td>
                            <td height="175px" 
                                
                                style="background-position: right top; background-image: url('images/mid.png'); background-repeat: repeat-x; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle" bgcolor="White">
                                
                                <p style="text-align: justify; font-family: Verdana; font-size: medium; color: #000000;">
                                <br />
                                    Welcome to CML Interactive. You are currently logged in and have access to the 
                                    projects listed below. All Operating and Maintenance Manuals for each project 
                                    have been electronically formatted and organised so that you view them on this 
                                    website using the menu structure on the left hand side.</p>
                                <p style="text-align: justify; font-family: Verdana; font-size: medium; color: #000000;">
                                    You will need Adobe Acrobat Reader and Autodesk DWF Viewer software in order to 
                                    view the manuals and drawings. </p>
                                <asp:Panel ID="Panel1" runat="server">
                                    <table style="width: 100%; font-family: Verdana; font-size: small; color: #0000FF;">
                                        <tr>
                                            <td valign="middle" width="50px" >
                                                <asp:Image ID="Image3" runat="server" ImageUrl="~/images/pdf1.png" />
                                            </td>
                                            <td valign="middle">
                                               
                                                <a href="#" onclick="javascript:alert('File Not Available!');" style="text-decoration:none;">Download latest version of Adobe Acrobat Reader</a>
                                            </td>
                                            <td valign="middle" width="50px" >
                                                <asp:Image ID="Image4" runat="server" 
                                                    ImageUrl="~/images/member-icon-autodesk.gif" />
                                            </td>
                                            <td>
                                                <a href="#" onclick="javascript:alert('File Not Available!');" style="text-decoration:none;">Download latest version of Autodesk DWF Viewer</a>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <p style="text-align: justify; font-family: Verdana; font-size: medium; color: #000000;">
                                    Please take a moment to check your settings for Adobe Acrobat Reader. More 
                                    information on these settings can be found in the help menu option on the left.</p>
                                <p style="text-align: justify; font-family: Verdana; font-size: medium; color: #000000;">
                                    If you require any assistance please contact</p>
                                </td>
                            <td height="200px" 
                                
                                style="background-position: right top; background-image: url('images/right.png'); background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle" width="30px">
                                &nbsp;</td>
                            <td height="200px" 
                                
                                style="background-position: right top; background-repeat: repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle">
                                <asp:Label ID="Label2" runat="server" Text="" Width="10px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td 
                                
                                style="background-position: right top; background-repeat: repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle">
                                &nbsp;</td>
                            <td 
                                
                                style="background-position: left top; background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle" bgcolor="White" width="30px">
                                &nbsp;</td>
                            <td height="30px" 
                                
                                style="background-position: center top; background-image: url('images/bot.png'); background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle" bgcolor="White">
                                &nbsp;</td>
                            <td 
                                
                                style="background-position: right top; background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle" width="30px">
                                &nbsp;</td>
                            <td 
                                
                                style="background-position: right top; background-repeat: repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td 
                                
                                style="background-position: right top; background-repeat: repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle">
                                &nbsp;</td>
                            <td 
                                
                                style="background-position: left top; background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF; background-image: url('images/left.png');" 
                                valign="middle" bgcolor="White" width="30px" rowspan="2">
                                &nbsp;</td>
                            <td height="10px" 
                                
                                style="background-position: center top; background-image: url('images/mid.png'); background-repeat: repeat-x; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle" bgcolor="White">
                                &nbsp;</td>
                            <td 
                                
                                style="background-position: right top; background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF; background-image: url('images/right.png');" 
                                valign="middle" width="30px" rowspan="2">
                                &nbsp;</td>
                            <td 
                                
                                style="background-position: right top; background-repeat: repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td 
                                
                                style="background-position: right top; background-repeat: repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle">
                                &nbsp;</td>
                            <td height="10px" 
                                
                                style="background-position: center top; background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle" bgcolor="White">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                
                                <asp:GridView ID="myprojectgrid" runat="server" CellPadding="4" 
                                        Font-Names="Arial,Helvetica,sans-serif" Font-Size="Small" 
                                        GridLines="None" Width="100%" AutoGenerateColumns="False" 
                                        EnableSortingAndPagingCallbacks="True" 
                                        ForeColor="#333333" PageSize="2" ShowFooter="True" Height="100px"  
                                        HeaderStyle-Font-Bold="false" onrowcommand="myprojectgrid_RowCommand" >
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <Columns>
                                        <asp:ButtonField DataTextField="prj_name" HeaderText="AUTHORISED PROJECT" HeaderStyle-HorizontalAlign="Left" ButtonType="Button"  ><ControlStyle Width="400px" Height="30px" />
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        </asp:ButtonField>
                                        <asp:BoundField DataField="company" HeaderText="COMPANY" SortExpression="company" ><HeaderStyle HorizontalAlign="Left" />    <ItemStyle HorizontalAlign="Left" /><ControlStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="ACCESS LEVEL"  DataField="access_level"
                                                >
                                        
                                            <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        <asp:BoundField DataField="prj_code" />
                                        <asp:BoundField DataField="prj_name" />
                                        </Columns>
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#999999" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                    
                            </td>
                            <td 
                                
                                style="background-position: right top; background-repeat: repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td 
                                
                                style="background-position: right top; background-repeat: repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle">
                                &nbsp;</td>
                            <td 
                                
                                style="background-position: left top; background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle" bgcolor="White" width="30px">
                                &nbsp;</td>
                            <td height="30px" 
                                
                                style="background-position: center bottom; background-image: url('images/bot.png'); background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle" bgcolor="White">
                                &nbsp;</td>
                            <td 
                                
                                style="background-position: right top; background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle" width="30px">
                                &nbsp;</td>
                            <td 
                                
                                style="background-position: right top; background-repeat: repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;" 
                                valign="middle">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                
                    
                    
                <asp:Panel ID="pnlPopup" runat="server" Width="500px" style="display:none;" >
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" id="tblPopup">
                            <tr>
                                <td class="heading" style="background-image: url('images/headingbg_13.gif'); background-repeat: repeat-x;">&nbsp;&nbsp;Select Module</td>
                            </tr>
                            
                            <tr>
                                <td  >
                                
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                                <table style="font-family: Arial, Helvetica, sans-serif; font-size: large; color: #FFFFFF" >
                                        <tr>
                                            <td width="75px">
                                                <asp:Image ID="dms" runat="server" ImageUrl="~/images/dms.jpg" />
                                            </td>
                                            <td bgcolor="#232323" width="100%">
                                                &nbsp;
                                                <asp:RadioButton ID="rdbtnDMS" runat="server" 
                                                    Text="Document Management System - DMS" 
                                                     AutoPostBack="true" Checked="True" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                <asp:Image ID="cms" runat="server" ImageUrl="~/images/cms.jpg" />
                                            </td>
                                            <td bgcolor="#232323">
                                                &nbsp;
                                                <asp:RadioButton ID="rdbtnCMS" runat="server" 
                                                    Text="Commissioning Management System - CMS" AutoPostBack="true" />
                                                </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Image ID="tms" runat="server" ImageUrl="~/images/tms.jpg" />
                                            </td>
                                            <td bgcolor="#232323">
                                                &nbsp;
                                                <asp:RadioButton ID="rdbtnTMS" runat="server" 
                                                    Text="Tracking Management System - TMS"  AutoPostBack="true" />
                                            </td>
                                        </tr>
                                    </table>
                                    </ContentTemplate>
                    </asp:UpdatePanel>
                                    </td>
                            </tr>
                            <tr>
                                <td class="footer" height="50px" >
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                    <asp:Button ID="btnCont" runat="server" Text="Continue.." OnClick="btnCont_Click"  />
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
                  BackgroundCssClass="modal"
                  DropShadow="true"                   
                  >
                  </asp:ModalPopupExtender>
                  
                </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>--%>
                <%--</div>--%>
                </td>
            </tr>
        </table>     
        
        
        
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
