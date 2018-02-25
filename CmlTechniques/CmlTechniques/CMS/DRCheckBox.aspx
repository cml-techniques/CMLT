<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DRCheckBox.aspx.cs" Inherits="CmlTechniques.CMS.DRCheckBox" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function Reposition() {
            var topobj = document.getElementById("Button1");
            var rect = topobj.getBoundingClientRect();
            $find('Button1_ModalPopupExtender').set_Y(rect.top + 20);
            $find('Button1_ModalPopupExtender').set_X(rect.left);
        }
    </script>
</head>
<body >
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div style="widows:200px">
        
        <asp:Button ID="Button1" runat="server" Text="Button" />
            <asp:PopupControlExtender ID="Button1_PopupControlExtender" runat="server" 
                DynamicServicePath="" Enabled="True" ExtenderControlID="" 
                TargetControlID="Button1" PopupControlID="Panel1">
            </asp:PopupControlExtender>
            <asp:Panel ID="Panel1" runat="server" style="display:none;margin-top:20px">
            <asp:CheckBoxList ID="CheckBoxList1" runat="server">
        <asp:ListItem Text="Item 1" Value="1"></asp:ListItem>
        <asp:ListItem Text="Item 2" Value="2"></asp:ListItem>
        <asp:ListItem Text="Item 3" Value="3"></asp:ListItem>
        <asp:ListItem Text="Item 4" Value="4"></asp:ListItem>
        </asp:CheckBoxList>
            </asp:Panel>
        
        </div>
    </div>
    </form>
</body>
</html>
