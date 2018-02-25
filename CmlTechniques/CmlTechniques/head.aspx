<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="head.aspx.cs" Inherits="CmlTechniques.head" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function ShowTime() {
            var dt = new Date();
//            document.getElementById('time').innerHTML = dt.toLocaleDateString() + ' , ' + dt.toLocaleTimeString();
//            document.getElementById('lbllogintime').innerHTML = dt.toLocaleDateString() + ' , ' + dt.toLocaleTimeString();
            window.setTimeout("ShowTime()", 1000);
        }
    </script>
    <script type="text/javascript">
      function pageLoad() {
      }
    </script>
     <link href="page.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
     header {
  padding-left: 15px;
  overflow: hidden;
  width: auto;
  height: 115px;
  background-image: url('https://s3-us-west-2.amazonaws.com/s.cdpn.io/464211/apple-mouse-mac-computer.jpg');
  background-size: cover;
  background-position: center;
}

header div {
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
}

header h1 {
  margin-bottom: 5px;
}

header h1, h2 {
  font-family: 'Merriweather Sans', sans-serif;
  color: #fff;
  text-shadow: 1px 1px 2px rgba(0, 0, 0, 1);
}
     </style>
</head>
<body onload="javascript:ShowTime();">
    <form id="form1" runat="server">
    <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
    <div style="height:151px;width:100%">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" id="headtbl" runat="server">
                        <tr>
                            <td height="100%" bgcolor="Black" colspan="3">
                            <img id="prjhead" alt="" runat="server"  style="height:115px;width:100%" border="0" src="" />
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
                                valign="middle">&nbsp;</td>
                        </tr>
    </table>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table1" runat="server">
                        <tr>
                            <td style="background-image: url('images/tophead.png'); background-repeat: repeat-x" 
                                valign="middle" align="left" height="30px">
                                &nbsp;         
                                <asp:Label ID="lblprj1" runat="server" Font-Names="verdana" Font-Size="Medium" 
                                    ForeColor="White" Font-Bold="True" Text="CMS | CML Techniques"></asp:Label>
                            </td>
                            <td align="right" height="30px" 
                                style="background-image: url('images/tophead.png'); background-repeat: repeat-x" 
                                valign="middle">
                                <asp:Label ID="lbluserin" runat="server" Font-Names="verdana" Font-Size="Small" 
                                    ForeColor="White"></asp:Label>
                                <asp:Label ID="lbllogintime" runat="server" Font-Names="verdana" Font-Size="Small" 
                                    ForeColor="White"></asp:Label>                                    
                            </td>
                            <td align="right" height="30px" 
                                style="background-image: url('images/tophead.png'); background-repeat: repeat-x" 
                                valign="middle">&nbsp;</td>
                        </tr>
    </table>
    </div>
    </form>
</body>
</html>
