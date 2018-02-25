<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doclist_all.aspx.cs" Inherits="CmlTechniques.doclist_all" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="page.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function openFrame(_id, type) {

            document.getElementById("myframe").src = "doclist_all1.aspx?id=" + _id;
        }
       

</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div style="width:100%;height:100%;position:fixed">
        <div style="float:left;width:20%;height:100%;overflow:auto">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>                    
                            <asp:TreeView ID="mytree" name="mytree" runat="server" ExpandDepth="5"            
                                            ForeColor="Black" LineImagesFolder="~/TreeLineImages" 
                                            NodeWrap="True"  Width="190px"  EnableTheming="false" 
                                             EnableClientScript="true" ShowExpandCollapse="true" 
                                    Font-Names="Verdana" Font-Size="7.5pt" NodeStyle-NodeSpacing="2px"         >
                                            <ParentNodeStyle ImageUrl="~/images/folder.gif" />
                                            <HoverNodeStyle ForeColor="#FF6600" />
                                            <RootNodeStyle ImageUrl="~/images/folder.gif" />
                                            <NodeStyle NodeSpacing="2px" />
                                            <LeafNodeStyle ImageUrl="~/images/folder.gif" />                        
                                        </asp:TreeView>
                             </ContentTemplate>
                            </asp:UpdatePanel>
        </div>
        
        <div style="float:right;width:80%;height:100%">
        <div style="width: 100%; height: 100%;">
                <iframe id="myframe" runat="server" name="myframe" frameborder="0" height="100%" width="100%" ></iframe>
                
                    </div>
        </div>    
        </div>
    </div>
    </form>
</body>
</html>
