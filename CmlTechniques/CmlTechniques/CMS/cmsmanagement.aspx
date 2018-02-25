<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cmsmanagement.aspx.cs" Inherits="CmlTechniques.CMS.cmsmanagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
    </head>
    <script type="text/javascript" language="javascript">
        function load(prm) {
            document.getElementById("myframe1").src = "../cmsuploads.aspx?id=" + prm;
        }
        function Load1(prm) {
            document.getElementById("myframe1").src = "ManageTrainingFolder.aspx?id=" + prm;
        }
        function Load2(prm) {
            document.getElementById("myframe1").src = "Manage_MSFolder.aspx?id=" + prm;
        }
    
    </script>
<body style="background-color:#092443" >
    <form id="form1" runat="server">
    <div style="font-family: verdana; font-size: x-small;height:90%;width:100%;position:fixed">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        
        <div style="width:100%;height:70px;background-color:#092443;color:White" >
            <table >
                <tr>
                    <td>
                                                    &nbsp;</td>
                    <td>
                                                    &nbsp;</td>
                    <td>
                                                    &nbsp;</td>
                    <td>
                                                    &nbsp;</td>
                    <td>
                                                    &nbsp;</td>
                </tr>
                <tr>
                    <td style="width:150px">
                                                    SELECT PROJECT</td>
                    <td style="width:275px">
                                                    <asp:DropDownList ID="drproject" runat="server" 
    Width="250" Height="25px">
                                </asp:DropDownList>
                            
                        </td>
                    <td style="width:150px">
                                                    SELECT ACTION</td>
                    <td style="width:275px">
                                <asp:DropDownList ID="draction" runat="server" Height="25px" Width="250px" 
                                    onselectedindexchanged="draction_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Uploads</asp:ListItem>
                                    <asp:ListItem Value="1">User Permission</asp:ListItem>
                                    <asp:ListItem Value="3">Create Packages</asp:ListItem> 
                                    <asp:ListItem Value="8">Create Panels</asp:ListItem> 
                                    <asp:ListItem Value="4">Configure Training Folder</asp:ListItem>
                                    <asp:ListItem Value="7">Configure MS Folder</asp:ListItem>
                                    <asp:ListItem Value="5">Configure Method Statements</asp:ListItem>     
                                    <asp:ListItem Value="6">Configure Minutes</asp:ListItem>                                                                 
                                </asp:DropDownList>
                            
                        </td>
                    <td>
                                                    <asp:Button ID="btngo" runat="server" Text="Go.." 
                                    onclick="btngo_Click" />
                            
                        </td>
                </tr>
                <tr>
                    <td>
                                &nbsp;</td>
                    
                    <td>
                                &nbsp;</td>
                    
                    <td>
                                &nbsp;</td>
                    
                    <td>
                                &nbsp;</td>
                    
                    <td>
                                &nbsp;</td>
                    
                </tr>
            </table>
        </div>
        <div style="width:100%;height:95%;background-color:#B8DBFF">
        <div id="mydiv" style="width:25%; height:100%; overflow: auto;float:left;background-color:#0B6F87;">
        <asp:TreeView ID="mytree" name="mytree" runat="server" ExpandDepth="5"            
                                            ForeColor="White" LineImagesFolder="~/TreeLineImages" 
                                            NodeWrap="True"  Width="190px"  EnableTheming="false" 
                                             EnableClientScript="true" ShowExpandCollapse="true" 
                                    Font-Names="Verdana" Font-Size="7.5pt" NodeStyle-NodeSpacing="2px"
                                     >
                                            <ParentNodeStyle ImageUrl="~/images/folder.gif" />
                                            <HoverNodeStyle ForeColor="#FF6600" />
                                            <RootNodeStyle ImageUrl="~/images/folder.gif" />
                                            <NodeStyle NodeSpacing="2px" />
                                            <LeafNodeStyle ImageUrl="~/images/folder.gif" />                        
                                        </asp:TreeView>
        </div>
        <div style="width:75%;height:100%;float:right">
        <iframe id="myframe1" runat="server" width="75%" height="100%" style="position:absolute" frameborder="0" ></iframe>
        </div>
        </div>
        
        
    </div>
    </form>
</body>
</html>
