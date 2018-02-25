<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tree.aspx.cs" Inherits="CmlTechniques.tree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
     <link href="page.css" rel="stylesheet" type="text/css" />
</head>
<body bgcolor="Black">
    <form id="form1" runat="server">
    <div style="width:210px;height:100%;background-color:Black">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:TreeView ID="mytree" name="mytree" runat="server" ExpandDepth="5"            
                                            ForeColor="#FFFFFF" LineImagesFolder="~/TreeLineImages" 
                                            NodeWrap="True"  Width="190px"  EnableTheming="false" 
                                             EnableClientScript="true" ShowExpandCollapse="true" 
                                    Font-Names="Verdana" Font-Size="7.5pt" NodeStyle-NodeSpacing="2px"         >
                                            <ParentNodeStyle ImageUrl="~/images/folder.gif" />
                                            <HoverNodeStyle ForeColor="#FF6600" />
                                            <RootNodeStyle ImageUrl="~/images/folder.gif" />
                                            <NodeStyle NodeSpacing="2px" />
                                            <LeafNodeStyle ImageUrl="~/images/folder.gif" />                        
                                        </asp:TreeView>
    </div>
    </form>
</body>
</html>
