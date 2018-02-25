<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MultiUpload.aspx.cs" Inherits="CmlTechniques.MultiUpload" %>

<%@ Register Assembly="com.flajaxian.FileUploader" Namespace="com.flajaxian" TagPrefix="cc2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
   <%-- <script>
        function FileStateChanged(uploader, file, httpStatus, isLast) {
            Flajaxian.fileStateChanged(uploader, file, httpStatus, isLast);
            var t = Flajaxian.$("MyDiv");
            if (file.state > Flajaxian.File_Uploading) {
                t.innerHTML += "bytes:" + file.bytes + " name:" + file.name + " state:" + file.state + " httpStatus:" + httpStatus + " isLast:" + isLast + "</br>";
            }
        }
</script>--%>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div id="MyDiv" >
            <asp:Label ID="lblpos" runat="server" Text="" style="display:none"></asp:Label>
        </div>
        <cc2:FileUploader ID="FileUploader1" runat="server" RequestAsPostBack="true" IsDebug="true" 
           OnFileReceived="FileUploader1_FileReceived" >
          <Adapters>
<cc2:FileSaverAdapter FolderName="UploadFolder" OnFileNameDetermining="FileNameDetermining" />
          </Adapters>
        </cc2:FileUploader>
    </div>
    </form>
</body>
</html>
