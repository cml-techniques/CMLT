<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="CmlTechniques.upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
     <link href="page.css" rel="stylesheet" type="text/css" />
<script src="Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="Scripts/jquery.MultiFile.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <table style="width:500px">
                <tr>
                <td width="100px" height="100px" valign="top">Test Sheet</td>
                    <td valign="top">
                    <input type="file" id="myupload" class="multi" runat="server" />
                       <%-- <asp:FileUpload ID="FileUpload1" runat="server" />--%>
                    </td>
                </tr>
                    <tr>
                        <td width="150px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td width="150px">
                            &nbsp;</td>
                        <td>
                            
                            <asp:Button ID="btnupload" runat="server" Text="Upload" onclick="btnupload_Click" 
                                />
                            <asp:Button ID="btncancel" runat="server" Text="Cancel" onclick="btncancel_Click" 
                                 />
                        </td>
                    </tr>
                </table>
    </div>
    </form>
</body>
</html>
