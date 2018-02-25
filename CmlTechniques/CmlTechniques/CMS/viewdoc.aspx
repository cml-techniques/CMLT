<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewdoc.aspx.cs" Inherits="CmlTechniques.CMS.viewdoc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script type="text/javascript">

        function pageLoad() {
        }
    
    </script>
<link href="../page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
    <asp:Label ID="lblid" runat="server" Text="" style="display:none"></asp:Label>
    <div id="doc_list" style="overflow:hidden">
    <div class="title">
        <asp:Label ID="lblinfo" runat="server" Text=""></asp:Label>
        <div class="back"><a href="#" onclick="javascript:history.go(-1);">Back</a></div>
    </div>
    <div class="viewer">
    <iframe id="myframe" frameborder="0" height="100%" width="100%" runat="server"></iframe>
    </div>
    </div>
    </form>
</body>
</html>
