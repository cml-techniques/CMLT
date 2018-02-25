<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="head1.aspx.cs" Inherits="CmlTechniques.head1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
        function ShowTime() {
            var dt = new Date();
            document.getElementById('time').innerHTML = dt.toLocaleDateString() + ' , ' + dt.toLocaleTimeString();
            window.setTimeout("ShowTime()", 1000);
        }
    </script>

    <link href="Assets/css/Style.css" rel="stylesheet" type="text/css" />
    <link href="Assets/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function Fullscreen() {
            var myFrameset = parent.document.getElementById("main");
            var value = myFrameset.getAttribute("cols");
            if (value == "210px,100%") {
                parent.document.getElementById("main").cols = "0px,100%";
                //parent.document.getElementById("container").rows = "30px,100%";
            }
            else {
                parent.document.getElementById("main").cols = "210px,100%";
                //parent.document.getElementById("container").rows = "146px,100%";
            }
        }
    </script>
</head>
<body onload="javascript:ShowTime();">
    <form id="form1" runat="server">
    <asp:Label ID="lblprj" runat="server" Text="" Style="display: none"></asp:Label>
    <asp:Label ID="lbluser" runat="server" Text="" Style="display: none"></asp:Label>
    <div id="header">
    <img id="prjhead" class="prjimg" alt="" runat="server" src="" /> 
                        
                        <div class="prjinfo">
                        <div class="pullleft font-big"><a href="#" onclick="Fullscreen();" ><i class="fa fa-align-justify"></i></a> CMS : <asp:Label ID="prj" runat="server" style="color:#e6422c" ></asp:Label></div>
                        <div class="pullright font-big">FACILITY : <asp:Label ID="package" runat="server" style="color:#e6422c" ></asp:Label></div>
                        <div class="overlap"><i class="fa fa-user"></i> <asp:Label ID="userinfo" runat="server" ></asp:Label><br /><i class="fa fa-clock-o"></i> <asp:Label ID="time" runat="server"></asp:Label></div>
                        
                        </div>
    </div>
    <%--<div style="height: 151px; width: 100%">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td height="100%" bgcolor="Black" colspan="3">
                    <img id="prjhead" alt="" runat="server" style="height: 115px; width: 100%" border="0"
                        src="" />
                </td>
            </tr>
            <tr>
                <td style="background-image: url('images/tophead.png'); background-repeat: repeat-x"
                    valign="middle" align="left" height="30px">
                    &nbsp;
                    
                </td>
                <td align="right" height="30px" style="background-image: url('images/tophead.png');
                    background-repeat: repeat-x" valign="middle">
                    
                    
                </td>
                <td align="right" height="30px" style="background-image: url('images/tophead.png');
                    background-repeat: repeat-x" valign="middle">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>--%>
    </form>
</body>
</html>
