<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage_Nav.aspx.cs" Inherits="CmlTechniques.Manage_Nav" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Project Management</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="page.css" rel="stylesheet" type="text/css" />
     <link rel="stylesheet" type="text/css" href="Menu/styles.css" /> 
     <script type="text/javascript" src="Menu/jquery.js"></script>
     <script type="text/javascript" src="Menu/sliding_effect.js"></script> 
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
         <div>
        <input id="_logout" type="hidden" runat="server" />
        <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Button ID="Button1" name="Button1" runat="server" Text="Button" onclick="Button1_Click" style="display:none" />
        </ContentTemplate>
        </asp:UpdatePanel>
        
        <div id="navigation-block">
        <div><asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo.JPG" 
                        Width="205px" Height="120px" BorderStyle="None" /></div>
        <ul id="sliding-navigation">
        <li class="sliding-element"><a href="#">HOME</a></li> 
        <li class="sliding-element"><a href="#" onclick="cal();">LOG OFF</a></li> 
        <li class="sliding-element"><h3>Modules</h3></li>
        <li class="sliding-element" id="cms_li" runat="server"><a href="#" onclick="javascript:parent.callmodule('CMS',0);">CMS</a></li>
        <li class="sliding-element" runat="server" id="dms_li"><a href="#" onclick="javascript:parent.callmodule('DMS',0);">DMS</a></li>
        <li class="sliding-element" runat="server" id="ams_li"><a href="#">AMS</a></li>
        </ul>
        </div>
    </div>
    </form>
</body>
</html>
