<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="projecthome1.aspx.cs" Inherits="CmlTechniques.projecthome" EnableEventValidation="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
    <script type="text/javascript">

        function pageLoad() {
      
      }
      function TreeviewExpandCollapseAll(treeViewId, expandAll)
 {
 var displayState = (expandAll == true ? "none" : "block");
 var treeView = document.getElementById(treeViewId);
 if(treeView)
 {
 var treeLinks = treeView.getElementsByTagName("a");
 var nodeCount = treeLinks.length;
 var flag = true;for(i=0;i<nodeCount;i++)
 {
 if(treeLinks[i].firstChild.tagName)
 {
 if(treeLinks[i].firstChild.tagName.toLowerCase() == "img")
 {
 var node = treeLinks[i];
 var level = parseInt(treeLinks[i].id.substr(treeLinks[i].id.length-1),10);
 var childContainer = GetParentByTagName("table", node).nextSibling;if(flag)
 {
 if(childContainer.style.display == displayState)
 {
 TreeView_ToggleNode(eval(treeViewId +"_Data"),level,node,'r',childContainer);
 }
 flag = false;
 }
 else
 {
 if(childContainer.Style.Display == displayState)
 TreeView_ToggleNode(eval(treeViewId +"_Data"),level,node,'l',childContainer);
 }
 }
 }
 }//for loop ends
 }
 }//utility function to get the container of an element by tagname
 function GetParentByTagName(parentTagName, childElementObj)
 {
 var parent = childElementObj.parentNode;
 while(parent.tagName.toLowerCase() != parentTagName.toLowerCase())
 {
 parent = parent.parentNode;
 }
 return parent;
 }

    </script>
 <link href="Stylesheet3.css" rel="stylesheet" type="text/css" />  
 
</head>
<script type="text/javascript">
    var myclose = false;

    function ConfirmClose() {
        if (event.clientY < 0) {
            window.open("logout.aspx", "mywindow1", "height=500px;width=500px;status=1");
            event.returnValue = "You have attempted to leave this page. If you want to continue, " + "Please Log Off from the Application." + "\n\n" + " Are you sure you want to exit this page?";

            setTimeout('myclose=false', 100);
            myclose = true;
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
    function prjhead_onclick() {

    }

</script>   
<body onload="javascript:ShowTime();"     >
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
                            <td  valign="top" height="300px">            
                    <table border="0" cellpadding="0" cellspacing="0" width="205px" >
                        <tr>
                        <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo.JPG" 
                        Width="205px" Height="120px" BorderStyle="None" /> 
                        </td>
                        </tr>
                        <tr>
                        <td style="background-position: center top; background-image: url('images/bx_top.png'); background-repeat: no-repeat" height="33px" align="center" valign="middle" >                                       
                            <input name="zoom_query" type="text" size="6" style="width: 130px;  font-family: verdana; font-size: x-small;" />&nbsp;<input onclick="document.getElementById('myframe').src='Scripts/search.html?zoom_query='+this.form.zoom_query.value" style="border-style: none; border-color: inherit; border-width: medium; height: 22px; width:25px; background-image:url('images/magnifying_glass_hover.gif'); background-repeat:no-repeat; background-color:Transparent;cursor:pointer" type="button" value=""  /></td>
                        </tr>
                        <tr>
                        <td style="background-position: center top; background-image: url('images/bx_body.png'); background-repeat:repeat-y  " 
                                 align="center" valign="top" bgcolor="Black">
                                <table width="195px" cellspacing="0">
                                    <tr>
                                        <td height="28px" 
                                            style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family:Verdana; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onclick="javascript:window.location.href='cmlhome.aspx';" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';">
                                        <%--<a href="cmlhome.aspx" style="text-decoration:none;font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; color: #FFFFFF; height: 30px; width: 200px;" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF'; "  >HOME</a>
                                            &nbsp;--%>HOME</td>
                                    </tr>
                                    <tr>
                                        <td  height="28px" 
                                            style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family:Verdana; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onclick="javascript:window.location.href='logout.aspx';" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';">
                                        <%--<a href="Default.aspx"   style="text-decoration:none;font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; color: #FFFFFF" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" >LOG OFF</a>
                                            &nbsp;--%>LOG OFF</td>
                                    </tr>
                                    <tr>
                                        <td  height="28px" 
                                            style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family:Verdana; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" >
                                        <%--<a href="#"  style="text-decoration:none;font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; color: #FFFFFF" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';">CONTACT US</a>
                                            &nbsp;--%><a href="mailto:admin@cmlinternational.net" style="text-decoration:none;color: #FFFFFF">CONTACT US</a> </td>
                                    </tr>
                                    <tr>
                                        <td  height="28px" 
                                            style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family:Verdana; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onclick="javascript:myframe.location='reportpage.aspx';" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" >
                                        <%--<a href="reportpage.aspx"  style="text-decoration:none;font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; color: #FFFFFF" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';"  >REPORTS</a>
                                            &nbsp;--%>REPORTS</td>
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
                            <td height="100%"  align="left" valign="top" style="top:200px">
                            
                            <div style="width: 100%; height: 45%; overflow: auto" class="coolscrollbar">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>                    
                            <asp:TreeView ID="mytree" name="mytree" runat="server" ExpandDepth="5"            
                                            ForeColor="#FFFFFF" LineImagesFolder="~/TreeLineImages" 
                                            NodeWrap="True" onselectednodechanged="mytree_SelectedNodeChanged" 
                                            Width="190px"  EnableTheming="false" 
                                             EnableClientScript="true" ShowExpandCollapse="true" 
                                    Font-Names="Verdana" Font-Size="7.5pt" NodeStyle-NodeSpacing="2px" Height="100%"
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
                            <td height="121px" colspan="3" valign="middle" >
                            <%--<asp:Image ID="Image2" runat="server" ImageUrl="~/images/masdarcity.jpg" />
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/masdarcitybanner.jpg" 
                        Width="620px" Height="48px" />--%>
                        <div style="float:left;width:30%;height:115px"><img id="prjlogo" alt="" runat="server" src="" style="height:115px;width:100%" /></div>
                        <div style="float:left;width:70%;height:115px"><img id="prjhead" alt="" runat="server" src="" style="height:115px;width:100%" /></div>                        
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
                <td   valign="top" height="70%" width="100%" 
                    >
                <iframe id="myframe"  frameborder="0" width="100%"   runat="server" name="myframe"  ></iframe>
                 
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
