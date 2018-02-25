<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cxissue_master.aspx.cs" Inherits="CmlTechniques.CMS.cxissue_master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
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
            if (id == 1) {
                _id1.className = "current"; _id2.className = ""; _id3.className = "";
            }
            else if (id == 2) {
                _id1.className = ""; _id2.className = "current"; _id3.className = "";
            }
            else if (id == 3) {
                _id1.className = ""; _id2.className = ""; _id3.className = "current";
            }
        }
</script>
</head>
<body style="background-color:#DCDCDC">
    <form id="form1" runat="server">
    <div style="height:100%;width:100%;position:absolute">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager> 
        <div style="background-color:#F7F6F3;height:8%">
            <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
      <div id="menucontainer">
      <div id="menubar">
      <div id="mainmenu">
      <div id="menunav">
        <ul>
          <li><a href="#" id="1" onclick="ChangeCls(1);" class="current"><span>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
              <asp:Button ID="btnnew" runat="server" Text="OVERALL" CssClass="mnubtn" onclick="btnnew_Click"   />
              </ContentTemplate>
              </asp:UpdatePanel>
              </span></a></li>
          <li><a href="#" id="2" onclick="ChangeCls(2);"><span>
              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
              <ContentTemplate>
              <asp:Button ID="btnedit" runat="server" Text="SUMMARY" CssClass="mnubtn" onclick="btnedit_Click"   />
              </ContentTemplate>
              </asp:UpdatePanel>
          </span></a></li>
          <li><a href="#" id="3" onclick="ChangeCls(3);"><span>
              <asp:UpdatePanel ID="UpdatePanel3" runat="server">
              <ContentTemplate>
              <asp:Button ID="btnsum" runat="server" Text="Remaining Open - SUMMARY" CssClass="mnubtn" onclick="btnsum_Click"   />
              </ContentTemplate>
              </asp:UpdatePanel>
          </span></a></li>
        </ul>
      </div>
      </div>
      </div>
        </div>
        </div>
        <div style="height:92%">
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
