<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cassheetmenu.aspx.cs" Inherits="CmlTechniques.cassheetmenu" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <script type="text/javascript">
// Firefox worked fine. Internet Explorer shows scrollbar because of frameborder
function resizeFrame() {
    //document.getElementById("mydata").style.height = "250px";
    mydata.height = "450px";
}
</script>
    <link href="page.css" rel="stylesheet" type="text/css" />
    
</head>

<body onload="javascript:resizeFrame();">
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        
        <table style="font-family: verdana; font-size: x-small; width: 100%; height: 100%;position:fixed;">
            <tr>
                <td   height="100%" valign="top">
                    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="440px"  >
                    <asp:TabPanel ID="intdata" runat="server" HeaderText="Initial Data" >                                         <ContentTemplate >
                    <iframe id="mydata" runat="server" frameborder="0" name="mydata" width="100%"   ></iframe>
                    </ContentTemplate>
                    </asp:TabPanel>
                    
                    
                    </asp:TabContainer>
                    
                </td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
