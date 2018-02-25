<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cmstree2.aspx.cs" Inherits="CmlTechniques.CMS.cmstree2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
     <link rel="stylesheet" type="text/css" href="../Menu/styles.css" />
</head>
<body>
    <form id="form1" runat="server">
     <div id="navigation-block">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:TreeView ID="mytree" name="mytree" runat="server" ExpandDepth="5"            
                                            ForeColor="#FFFFFF" 
                                            NodeWrap="True"  Width="190px"  EnableTheming="false" 
                                             EnableClientScript="true" ShowExpandCollapse="true" 
                                    Font-Names="Verdana" Font-Size="7.5pt" NodeStyle-NodeSpacing="2px" >
                                            <ParentNodeStyle ImageUrl="~/images/folder.gif" />
                                            <HoverNodeStyle ForeColor="#FF6600" />
                                            <RootNodeStyle ImageUrl="~/images/folder.gif" />
                                            <NodeStyle NodeSpacing="2px" />
                                            <LeafNodeStyle ImageUrl="~/images/folder.gif" />                        
                                        </asp:TreeView>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
