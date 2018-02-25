<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocPdfView.aspx.cs" Inherits="CmlTechniques.CMS.DocPdfView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>View Document</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>    
        <asp:Label ID="lblprjid" runat="server" Text="" style="display:none"></asp:Label>
        <asp:Label ID="lblmod" runat="server" Text="" style="display:none"></asp:Label>
        <asp:Label ID="lblid" runat="server" Text="Label" style="display:none"></asp:Label>
        <div style="position:absolute;width:100%;top:0px;" >
                <div id="thead">
        <div class="titles">
         <asp:Label runat="server" ID="lbltitle" Text="File name" ForeColor="White"  style="font-family: Verdana; font-size: small;" ></asp:Label>
        </div>
        <div class="btns">
         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                          <asp:Button ID="btnback" runat="server"  Text="BACK" Width="100px"  OnClick="btnback_Click" />
             </ContentTemplate>
             </asp:UpdatePanel>
        </div>
               
        
</div>
</div>
        <div style="position:absolute;top:32px;bottom:5px ;width:100%;" >
         <iframe id="myframe"  frameborder="0" height="100%" width="100%" runat="server" ></iframe>
        
        </div>    
    </form>
</body>
</html>
