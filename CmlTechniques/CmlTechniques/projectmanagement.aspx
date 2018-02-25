<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="projectmanagement.aspx.cs" Inherits="CmlTechniques.projectmanagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CML Interactive</title>
      
    <script type="text/javascript">
    
      function pageLoad() {
      }

      
    </script>
    
    
    
   
    
</head>
<body bgcolor="#414141" style="padding:0px;margin:0px;" >
    <form id="form1" runat="server">
    <%--<div  style="position: absolute; width: 100%; height: 100%; overflow: auto">--%>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div style="height:85px;left:0px;right:0px;top:0px;position:absolute;color:#ffffff;overflow:hidden">
         <table border="0" cellpadding="0" cellspacing="2" >
                        
                        <tr>
                            <td width="150px" align="center" valign="middle" >
                                Project</td>
                            <td style="font-family: Verdana; font-size: small">
                                <asp:DropDownList ID="drproject" runat="server" Width="388px" Height="25px">
                                </asp:DropDownList>
                            </td>
                            <td  >
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="150px" align="center" valign="middle" >
                                Action</td>
                            <td>
                                <asp:DropDownList ID="draction" runat="server" Width="388px" Height="25px">
                                    <asp:ListItem>--Select Action--</asp:ListItem>
                                    <asp:ListItem>Document Uploading</asp:ListItem>
                                    <asp:ListItem>Scheduling</asp:ListItem>
                                    <asp:ListItem>Manage Tree Folder</asp:ListItem>
                                    <asp:ListItem>User Permission</asp:ListItem>
                                    <asp:ListItem>Comments</asp:ListItem>
                                    <asp:ListItem>T&amp;C Documentation</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td >
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                
                                <asp:Button ID="cmdgo" runat="server" ForeColor="Red" onclick="cmdgo_Click" 
                                    Text="Continue.." Height="25px" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
          <div style="background-color:#092443;height:30px;width:100%;padding:5px;font-family:Verdana;">
          <asp:Label ID="title" runat="server" Text=""></asp:Label>
          </div>
        </div>  
        <div style="left:0px;right:0px;top:85px;bottom:0px;position:absolute;overflow:hidden;">
            <iframe id="myframe" runat="server" frameborder="0" name="myframe" style="width:100%;height:100%;" scrolling="auto" ></iframe>
        </div>    
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
