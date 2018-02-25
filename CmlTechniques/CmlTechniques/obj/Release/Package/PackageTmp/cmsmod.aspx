<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cmsmod.aspx.cs" Inherits="CmlTechniques.cmsmod" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%;height:100%;position:fixed">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div style="float:left;height:100%;width:20%;background-color:Black;position:absolute">
        <img src="images/logo.JPG" alt="logo" width="205" height="120" /></div>
        <div style="float:right;height:100%;width:80%">
        <div style="height:20%;width:100%" >
            <div style="float:left;width:30%;height:100%">
            <img id="prjlogo" alt="" runat="server" src="~/images/11601logo.jpg" style="height:90px;width:100%" />
            </div>
            <div style="float:left;width:65%;height:100%">
            <img id="prjhead" alt="" runat="server" src="~/images/11601head.jpg" style="height:90px;width:100%" />
            </div>
        </div>
        <div style="height:80%;width:100%;background-color:Black;overflow:auto"></div>
        </div>
    </div>
    </form>
</body>
</html>
