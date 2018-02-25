<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frameseteg.aspx.cs" Inherits="CmlTechniques.frameseteg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <a href="#" onclick="parent.click();">Click Me</a>
    </div>
    </form>
</body>
</html>
