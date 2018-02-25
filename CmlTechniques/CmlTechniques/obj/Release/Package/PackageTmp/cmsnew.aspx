<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cmsnew.aspx.cs" Inherits="CmlTechniques.cmsnew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<%--<META HTTP-EQUIV="REFRESH" CONTENT="10;URL=userlogin.aspx" />
--%>
    <title>CML Techniques</title>
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
        
        function Col() {
            document.getElementById("mytree").Nodes.CollapseAll();
        }
                
    </script>
    <script language="javascript" type="text/javascript">
        function callcms(_id, type) {
            if (type == "0") {
                document.getElementById("myframe").src = "CMS/cassheet_master.aspx?id=" + _id;
            }
            else if (type == "1") {
                document.getElementById("myframe").src = "CMS/cmsdoclist.aspx?id=" + _id;
            }
            else if (type == "sub") {
                document.getElementById("myframe").src = "CMS/cmsdocreview_details.aspx";
            }
            else if (type == "3") {
                document.getElementById("myframe").src = "CMS/cmsdocreview.aspx";

            }
            else if (type == "4") {
                document.getElementById("myframe").src = "CMS/methodstatements.aspx?id=" + _id;

            }
            else if (type == "5") {
                location.replace("docview.aspx");

            }
            else if (type == "6") {
                document.getElementById("myframe").src = "cmsminutes.aspx?id=" + _id;

            }
            else if (type == "7") {
                document.getElementById("myframe").src = "cmsprogrammes.aspx?id=" + _id;

            }
            else if (type == "8") {
                document.getElementById("myframe").src = "CMS/so.aspx";

            }
            else if (type == "9") {
                location.replace("programview.aspx");

            }
            else if (type == "10") {
                document.getElementById("myframe").src = _id;

            }
            else if (type == "11") {
                document.getElementById("myframe").src = "CMS/ms_schedule.aspx";

            }
            else if (type == "12") {
            document.getElementById("myframe").src = "CMS/caslvreport.aspx";
        }
        else if (type == "13") {
        document.getElementById("myframe").src = "tcdocumentation.aspx?id=" + _id;
    }
    else if (type == "14") {
        document.getElementById("myframe").src = "CMS/mech_ahu.aspx?id=" + _id;
    }
    else if (type == "15") {
    document.getElementById("myframe").src = "CMS/cmstraining.aspx?id=" + _id;
    }
        }
        function calldataentry(srv) {
            document.getElementById("myframe").src = "cas_electrical_dataentry.aspx";
        }
    
    </script>
    
 <link href="Stylesheet3.css" rel="stylesheet" type="text/css" />    
</head>
<script type="text/javascript">
    var myclose = false;

    function ConfirmClose() {
        if (event.clientY < 0) {
            //            window.open("logout.aspx", "mywindow1", "height=500px;width=500px;status=1");
           // window.open("Default.aspx");
            //event.returnValue = "You have attempted to leave this page. If you want to continue, " + "Please Log Off from the Application." + "\n\n" + " Are you sure you want to exit this page?";

//            setTimeout('myclose=false', 100);
            //            myclose = true;
           // window.open("userlogin.aspx");
            //location.replace("userlogin.aspx");
        }
    }
    function HandleOnClose() {
    
        if (myclose == true) alert("Window is closed");
    }
    </script>
<script type="text/javascript">
    function call() {
        location.replace("viewmanual.aspx");
    }
    
    </script>



<script language="javascript" type="text/javascript">
    function openFrame(_id, type) {
        //myframe.location.clear();
        if (type == 0) {
            //myframe.location = "load.aspx?id=" + _id;
            document.getElementById("myframe").src = "load.aspx?id=" + _id;
        }
        else {
           // myframe.location = "loadOM.aspx?id=" + _id;
            document.getElementById("myframe").src = "loadOM.aspx?id=" + _id;      
        }
    }
    function _view() {
//        myframe.location = "viewdocument.aspx";
        document.getElementById("myframe").src = "viewdocument.aspx";
    }
    function Exp() {
        var _tree = document.getElementById("mytree");
        _tree.ExpandAll();

    }
 </script>   
<body onload="javascript:ShowTime();" onbeforeunload="javascript:ConfirmClose();" onunload="javascript:HandleOnClose();" bgcolor="#D1DEF1" >
    <form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
        <table  border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;position:fixed ; ">
            <tr>
                <td bgcolor="Black" width="210px" valign="top" rowspan="3" align="center" 
                    height="100%" 
                    style="border-right-style: outset; border-right-width: 2px; border-right-color: #092443" >
                    <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="25%" valign="top">            
                    <table border="0" cellpadding="0" cellspacing="0" width="205px" >
                        <tr>
                        <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo.JPG" 
                        Width="205px" Height="120px" BorderStyle="None" /> 
                        </td>
                        </tr>
                        <tr>
                        <td style="background-position: center top; background-image: url('images/bx_top.png'); background-repeat: no-repeat" height="33px" align="center" valign="middle" >                                       
                            &nbsp;</td>
                        </tr>
                        <tr>
                        <td style="background-position: center top; background-image: url('images/bx_body.png'); background-repeat:repeat-y  " 
                                 align="center" valign="top" bgcolor="Black">
                                <table width="195px" cellspacing="0">
                                    <tr>
                                        <td height="28px" 
                                            style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family:Verdana; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onclick="javascript:window.location.href='cmlhome.aspx';" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" align="center">
                                        <%--<a href="cmlhome.aspx" style="text-decoration:none;font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; color: #FFFFFF; height: 30px; width: 200px;" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF'; "  >HOME</a>
                                            &nbsp;--%>HOME</td>
                                    </tr>
                                    <tr>
                                        <td  height="28px" 
                                            style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family:Verdana; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onclick="javascript:window.location.href='logout.aspx';" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" align="center">
                                        <%--<a href="Default.aspx"   style="text-decoration:none;font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; color: #FFFFFF" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" >LOG OFF</a>
                                            &nbsp;--%>LOG OFF</td>
                                    </tr>
                                    <tr>
                                        <td  height="28px" 
                                            style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family:Verdana; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" onclick="javascript:window.open('http://www.cmlinternational.net/contactus.php','','left=210,top=100,width=1024,height=600,menubar=1,toolbar=0,scrollbars=1,status=0');" align="center">
                                        <%--<a href="#"  style="text-decoration:none;font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; color: #FFFFFF" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';">CONTACT US</a>
                                            &nbsp;--%>CONTACT US</td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="Black" height="28px" onmouseout="this.style.color='#FFFFFF';" onmouseover="this.style.color='blue'" style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family: Verdana; font-size: x-small; color: #FFFFFF; cursor: pointer;" onclick="javascript:myframe.location='CMS/cmsreports.aspx';" align="center">
                                            REPORTS</td>
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
                            </td>
                        </tr>
                        <tr>
                            <td height="50%" align="left" valign="top">
                            
                            <div style="width: 100%; height: 100%; overflow: auto" class="coolscrollbar">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>                    
                            <asp:TreeView ID="mytree" name="mytree" runat="server" ExpandDepth="5"            
                                            ForeColor="#FFFFFF" LineImagesFolder="~/TreeLineImages" 
                                            NodeWrap="True"  Width="190px"  EnableTheming="false" 
                                             EnableClientScript="true" ShowExpandCollapse="true" 
                                    Font-Names="Verdana" Font-Size="7.5pt" NodeStyle-NodeSpacing="2px"
                                     >
                                            <ParentNodeStyle ImageUrl="~/images/folder.gif" />
                                            <HoverNodeStyle ForeColor="#FF6600" />
                                            <RootNodeStyle ImageUrl="~/images/folder.gif" />
                                            <NodeStyle NodeSpacing="2px" />
                                            <LeafNodeStyle ImageUrl="~/images/folder.gif" />                        
                                        </asp:TreeView>
                             </ContentTemplate>
                            </asp:UpdatePanel>
                                        </div>
                            </td>
                        </tr>
                    </table>            
                    </td>
                <td valign="top" style="height: 20%;width:100%;">
                <%--<div style="width: 100%; height: 100%; overflow: auto">--%>
                <%--<asp:Image ID="Image3" runat="server" ImageUrl="images/Website_Heading.jpg" />--%>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                        <tr>
                            <td height="121px" colspan="3" >
                            <%--<asp:Image ID="Image2" runat="server" ImageUrl="~/images/masdarcity.jpg" />
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/masdarcitybanner.jpg" 
                        Width="620px" Height="48px" />--%>
                        <%--<div style="float:left;width:30%;height:115px"><img id="prjlogo" alt="" runat="server" src="" style="height:115px;width:100%" /></div>--%>
                        <div style="float:left;width:100%;height:115px"><img id="prjhead" alt="" runat="server" src="" style="height:115px;width:100%" border="0" /></div>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-image: url('images/tophead.png'); background-repeat: repeat-x" 
                                valign="middle" align="left" height="30px">
                                &nbsp;         
                                <asp:Label ID="prj" runat="server" Font-Names="verdana" Font-Size="Medium" 
                                    ForeColor="White" Font-Bold="True"></asp:Label>
                            </td>
                            <td align="right" height="30px" 
                                style="background-image: url('images/tophead.png'); background-repeat: repeat-x" 
                                valign="middle">
                                <asp:Label ID="userinfo" runat="server" Font-Names="verdana" Font-Size="Small" 
                                    ForeColor="White"></asp:Label>
                                <asp:Label ID="time" runat="server" Font-Names="verdana" Font-Size="Small" 
                                    ForeColor="White"></asp:Label>                                    
                            </td>
                            <td align="right" height="30px" 
                                style="background-image: url('images/tophead.png'); background-repeat: repeat-x" 
                                valign="middle">
                                &nbsp;</td>
                        </tr>
                     </table>
                <%--</div>--%> 
                </td>
            </tr>
            
            <tr>
                <td   valign="top" height="70%" width="100%" runat="server" id="main" 
                    style="background-repeat: no-repeat; background-position: center center">
                <%--<div>
                    <asp:Label ID="lbhead" runat="server" Text=""></asp:Label>&nbsp;
                <a href="#" >ADD</a> | <a href="#" >EDIT</a> | <a href="#" >REPORTS</a> | <a href="#" >SUMMARY</a> | 
                </div>--%>
                <iframe id="myframe"  frameborder="0" width="100%" height="100%"  runat="server" name="myframe"></iframe>
                 
                 <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>           
                
                </td>
            </tr>
        </table>  
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
