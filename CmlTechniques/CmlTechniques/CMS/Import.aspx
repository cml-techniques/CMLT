<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Import.aspx.cs" Inherits="CmlTechniques.CMS.Import" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
           <link href="../page.css" rel="stylesheet" type="text/css" />
<script src="../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
         <div style="padding:10px">
        <table>
            <tr>
                <td valign="top" style="width:200px">
                    &nbsp;</td>
                <td >
                    <asp:Label ID="lbsvr" runat="server" Text="" style="display:none"></asp:Label>
                    <asp:Label ID="lbsch" runat="server" Text="" ></asp:Label>
                    <asp:Label ID="lbprj" runat="server" Text="" ></asp:Label>
                    <asp:Label ID="lblsec" runat="server" Text="" style="display:none" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top" style="width:200px">
                    Select Excel Document</td>
                <td height="100px" valign="top">
                    <input type="file" id="myupload" class="multi" runat="server" /></td>
            </tr>
            <tr>
                <td >
                    </td>
                <td >
                    <asp:Button ID="btnupload" runat="server" Text="Upload" 
                        onclick="btnupload_Click" />
                </td>
            </tr>
        </table>
        </div>
    </div>
    </form>
</body>
</html>
