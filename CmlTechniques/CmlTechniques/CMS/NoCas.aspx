<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoCas.aspx.cs" Inherits="CmlTechniques.CMS.NoCas" %>

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
        <div style="margin-top:30px; text-align:center">
        <div>
            <asp:Label ID="lblcas" runat="server" Text="" Font-Bold="true"></asp:Label></div>
        <div><h4><span style="color:Red">No CAS Sheet Created Yet!</span></h4></div>
        </div>
    </div>
    </form>
</body>
</html>
