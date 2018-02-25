<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cassheet_master.aspx.cs" Inherits="CmlTechniques.CMS.cassheet_master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function ChangeCls(id) {
            var _id1 = document.getElementById("1");
            var _id2 = document.getElementById("2");
            var _id3 = document.getElementById("3");
            var _id4 = document.getElementById("4");
            var _id5 = document.getElementById("5");
            var _id6 = document.getElementById("6");
            if (id == 1) {
                _id1.className = "current"; _id2.className = ""; _id3.className = ""; _id4.className = ""; _id5.className = ""; _id6.className = "";
            }
            else if (id == 2) {
                _id1.className = ""; _id2.className = "current"; _id3.className = ""; _id4.className = ""; _id5.className = ""; _id6.className = "";
            }
            else if (id == 3) {
                _id1.className = ""; _id2.className = ""; _id3.className = "current"; _id4.className = ""; _id5.className = ""; _id6.className = "";
            }
            else if (id == 4) {
                _id1.className = ""; _id2.className = ""; _id3.className = ""; _id4.className = "current"; _id5.className = ""; _id6.className = "";
            }
            else if (id == 5) {
                _id1.className = ""; _id2.className = ""; _id3.className = ""; _id4.className = ""; _id5.className = "current"; _id6.className = "";
            }
            else if (id == 6) {
                _id1.className = ""; _id2.className = ""; _id3.className = ""; _id4.className = ""; _id5.className = ""; _id6.className = "current";
            }
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height:100%;width:100%;position:absolute">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager> 
        <div style="background-color:#F7F6F3;">
            <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label> <asp:Label ID="lblsch" runat="server" Text="" style="display:none"></asp:Label><asp:Label ID="lbluid" runat="server" Text="" style="display:none"></asp:Label><asp:Label ID="lbldiv" runat="server" Text="" style="display:none"></asp:Label>
            <%--<asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" 
                DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" 
                ForeColor="#7C6F57" Height="30px" Orientation="Horizontal" 
                StaticSubMenuIndent="10px" Width="50%" 
                onmenuitemclick="Menu1_MenuItemClick">
                <StaticSelectedStyle BackColor="#5D7B9D" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                <DynamicMenuStyle BackColor="#F7F6F3" />
                <DynamicItemTemplate>
                    <%# Eval("Text") %>
                </DynamicItemTemplate>
                <DynamicSelectedStyle BackColor="#5D7B9D" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
                <Items>
                    <asp:MenuItem Text="Add" Value="0"></asp:MenuItem>
                    <asp:MenuItem Text="Testing" Value="1"></asp:MenuItem>
                    <asp:MenuItem Text="Summary" Value="2"></asp:MenuItem>
                    <asp:MenuItem Text="Reports" Value="3"></asp:MenuItem>
                </Items>
            </asp:Menu>--%>
            <%--<p style="margin:0"><a href="../casintdata.aspx" target="myframe1" style="text-decoration:none">CAS SHEET ENTRY</a> | <a href="cassheet_testing.aspx" target="myframe1" style="text-decoration:none">COMMISSIONING & TESTING</a> | <a href="caslvreport.aspx" target="myframe1" style="text-decoration:none">REPORT</a> | <a href="graph.aspx" target="myframe1" style="text-decoration:none">SUMMARY</a></p>--%>
            <%--<p style="margin:0">
                <asp:Button ID="btnnew" runat="server" Text="CAS SHEET ENTRY" 
                    style="border:0;background-color:Transparent;cursor:pointer;background-image:url('../Images/tit.png');color:White" onclick="btnnew_Click" Width="195px" Height="30px" />
                <asp:Button ID="btnedit" runat="server" Text="COMMISSIONING & TESTING" 
                    style="border:0;background-color:Transparent;cursor:pointer;background-image:url('../Images/tit.png');color:White" onclick="btnedit_Click" Width="195px" Height="30px" />
                <asp:Button ID="btnrpt" runat="server" Text="FULL SCHEDULE" 
                    style="border:0;background-color:Transparent;cursor:pointer;background-image:url('../Images/tit.png');color:White" onclick="btnrpt_Click" Width="195px" Height="30px" />
                <asp:Button ID="btnsum" runat="server" Text="GRAPH" 
                    style="border:0;background-color:Transparent;cursor:pointer;background-image:url('../Images/tit.png');color:White" onclick="btnsum_Click" Width="195px" Height="30px" /></p>--%>
                    
      <div id="menucontainer" runat="server">
      <div id="menubar">
      <div id="mainmenu">
      <div id="menunav">
        <ul>
          <li><a href="#" id="1" onclick="ChangeCls(1);" class="current"><span>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
              <asp:Button ID="btnnew" runat="server" Text="CAS SHEET ENTRY" CssClass="mnubtn" onclick="btnnew_Click"   />
              </ContentTemplate>
              </asp:UpdatePanel>
              </span></a></li>
          <li><a href="#" id="2" onclick="ChangeCls(2);"><span>
              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
              <ContentTemplate>
              <asp:Button ID="btnedit" runat="server" Text="COMMISSIONING & TESTING" CssClass="mnubtn" onclick="btnedit_Click"   />
              </ContentTemplate>
              </asp:UpdatePanel>
          </span></a></li>
          <li><a href="#" id="6" onclick="ChangeCls(6);"><span>
              <asp:UpdatePanel ID="UpdatePanel7" runat="server">
              <ContentTemplate>
              <asp:Button ID="btninput" runat="server" Text="COMMISSIONING & TESTING - INPUT MODULE" CssClass="mnubtn" onclick="btninput_Click" style="display:none"   />
              </ContentTemplate>
              </asp:UpdatePanel>
          </span></a></li>
          <li><a href="#" id="3" onclick="ChangeCls(3);"><span>
              <asp:UpdatePanel ID="UpdatePanel3" runat="server">
              <ContentTemplate>
              <asp:Button ID="btnrpt" runat="server" Text="FULL SCHEDULE" CssClass="mnubtn" onclick="btnrpt_Click"  />
              </ContentTemplate>
              </asp:UpdatePanel>
          </span></a></li>
          <li><a href="#" id="4" onclick="ChangeCls(4);"><span>
              <asp:UpdatePanel ID="UpdatePanel4" runat="server">
              <ContentTemplate>
              <asp:Button ID="btnsum" runat="server" Text="GRAPH" CssClass="mnubtn" onclick="btnsum_Click"  />
              </ContentTemplate>
              </asp:UpdatePanel>
          </span></a></li>
          <li><a href="#" id="5" onclick="ChangeCls(5);"><span>
              <asp:UpdatePanel ID="UpdatePanel6" runat="server">
              <ContentTemplate>
              <asp:Button ID="btnsum1" runat="server" Text="SUMMARY" CssClass="mnubtn" onclick="btnsum1_Click"  />
              </ContentTemplate>
              </asp:UpdatePanel>
          </span></a></li>
        </ul>
      </div>
      </div>
      </div>
        </div>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
            <iframe id="myframe1" name="myframe1" runat="server" frameborder="0" width="100%" height="92%" style="position:absolute" ></iframe>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>
