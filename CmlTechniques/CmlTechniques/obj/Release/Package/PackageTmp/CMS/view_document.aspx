<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view_document.aspx.cs" Inherits="CmlTechniques.CMS.view_document" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
     <link href="../page.css" rel="stylesheet" type="text/css" />
</head>
<script type="text/javascript">
    function callcms(_id, type) {
        if (type == '0') {
            document.getElementById("myframe").src = "mslist.aspx?id=" + _id;
        }
        else if (type == '1') {
            document.getElementById("myframe").src = _id;
        }
    }
</script>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
         <table  border="0" cellpadding="0" cellspacing="0" 
            style="width: 100%; height: 100%;position:fixed; ">
                        
            <tr>
                <td bgcolor="Black" width="210px" valign="top" align="center" 
                    height="100%" 
                    
                    style="border-right-style: outset; border-right-width: 2px; border-right-color: #092443" >
                    <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="100%" align="left" valign="top">
                            
                            <div style="width: 100%; height: 100%; overflow: auto">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>                    
                            <asp:TreeView ID="mytree" runat="server" ExpandDepth="5"            
                                            ForeColor="#FFFFFF" LineImagesFolder="~/TreeLineImages" 
                                            NodeWrap="True" 
                                            Width="190px"  EnableTheming="false" 
                                             EnableClientScript="true" ShowExpandCollapse="true" 
                                    Font-Names="Verdana" Font-Size="7.5pt" NodeStyle-NodeSpacing="2px"
                                     >
                                            <ParentNodeStyle ImageUrl="~/images/folder.gif" />
                                            <HoverNodeStyle ForeColor="#FF6600" />
                                            <RootNodeStyle ImageUrl="~/images/folder.gif" />
                                            <NodeStyle NodeSpacing="2px" />
                                            <LeafNodeStyle ImageUrl="~/images/folder.gif" />
                                        </asp:TreeView>
                             </ContentTemplate>
                            </asp:UpdatePanel>
                                        </div>
                            </td>
                        </tr>
                    </table>            
                    </td>
                <td   valign="top" style="height:100%;width:100%;" >
                <div style="width: 100%; height: 100%; " >
                 <iframe id="myframe" runat="server" frameborder="0" width="100%" name="myframe" height="100%" ></iframe> 
                 </div>
                 <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>           
                
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
