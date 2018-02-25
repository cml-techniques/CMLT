<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dmsmenu.aspx.cs" Inherits="CmlTechniques.dmsmenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
     <link href="page.css" rel="stylesheet" type="text/css" />
     <link rel="stylesheet" type="text/css" href="Menu/styles.css" /> 
     <script type="text/javascript" src="Menu/jquery.js"></script>
     <script type="text/javascript" src="Menu/sliding_effect.js"></script> 
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
        function index_click() {
            var btn = document.getElementById("btnindex");
            btn.click();
        }
        function index_click1() {
            var btn = document.getElementById("btnindex1");
            btn.click();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <input id="_logout" type="hidden" runat="server" />
        <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Button ID="Button1" name="Button1" runat="server" Text="Button" onclick="Button1_Click" style="display:none" />
        <asp:Button ID="btnindex" runat="server" Text="" style="display:none" onclick="btnindex_Click"  />
        <asp:Button ID="btnindex1" runat="server" Text="" style="display:none" onclick="btnindex1_Click"  />
        </ContentTemplate>
        </asp:UpdatePanel>
        <div id="navigation-block">
        <div><asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo.JPG" 
                        Width="205px" Height="120px" BorderStyle="None" /></div>
        <ul id="sliding-navigation">
        <li class="sliding-element"><a href="#" onclick="javascript:parent.MenuClick('1',0);">HOME</a></li> 
        <li class="sliding-element"><a href="#" onclick="cal();">LOG OFF</a></li> 
        <li class="sliding-element"><a href="#" onclick="javascript:window.open('http://cmlinternational.co.uk/contact-us/4556971903','','left=210,top=100,width=1024,height=600,menubar=1,toolbar=0,scrollbars=1,status=0');">CONTACT US</a></li> 
        <li class="sliding-element"><a href="#" onclick="javascript:parent.MenuClick('3',0);" >REPORTS</a></li>
        <%--<li class="sliding-element"><a href="#" onclick="index_click();">O&amp;M MANUAL INDEX</a></li> --%>
        <li class="sliding-element"><a href="#" onclick="index_click1();">DOCUMENT STATUS</a></li> 
        </ul>
        <div id="search">
        <input name="zoom_query" type="text" class="textbox" /><input onclick="javascript:parent.MenuClick(5,this.form.zoom_query.value);" class="search_button" type="button" value=""  />
        </div>
        </div>
    </div>
    </form>
</body>
</html>
