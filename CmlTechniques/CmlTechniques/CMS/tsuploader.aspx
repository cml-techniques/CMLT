<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tsuploader.aspx.cs" Inherits="CmlTechniques.CMS.tsuploader" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <%--<script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>--%>
    <script type="text/javascript" language="javascript">

        function uploadError(sender, args) {
            document.getElementById('lblStatus').innerText = args.get_fileName(),
	"<span style='color:red;'>" + args.get_errorMessage() + "</span>";
        }

        function StartUpload(sender, args) {
            document.getElementById('lblStatus').innerText = 'Uploading Started.';
        }

        function UploadComplete(sender, args) {
            var filename = args.get_fileName();
            var contentType = args.get_contentType();
            var text = "Size of " + filename + " is " + args.get_length() + " bytes";
            if (contentType.length > 0) {
                text += " and content type is '" + contentType + "'.";
            }
            document.getElementById('lblStatus').innerText = text;
        }

</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
        
            
        
        <table>
        <tr>
        <td><%--<input type="file" id="myupload" class="multi" runat="server" />--%>
            <asp:AsyncFileUpload ID="AsyncFileUpload1" runat="server" 
                onuploadedcomplete="AsyncFileUpload1_UploadedComplete" OnClientUploadError="uploadError" />
        </ContentTemplate>
        </asp:UpdatePanel>
        
        </td>
        <td><asp:Button ID="btnupload" runat="server" Text="Upload" 
                onclick="btnupload_Click" /></td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
