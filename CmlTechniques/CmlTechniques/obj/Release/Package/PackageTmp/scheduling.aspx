﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="scheduling.aspx.cs" Inherits="CmlTechniques.scheduling" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CML Interactive</title>
   
    <style type="text/css">
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
       
    </style> 
 <script language="javascript" type="text/javascript">
     function openFrame(_id) {
         myframe.location = "schedulingsub.aspx?id=" + _id;
     }
                
    </script>
</head>
<body bgcolor="#414141">
    <form id="form1" runat="server">
    <div >
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
       <table style="position:fixed; width: 100%; height: 98%; " border="0" cellpadding="0" cellspacing="0"">
            <tr>
                <td valign="top" width="30%" align="left" 
                    style="border-style: none solid none none; border-right-width: 0.1px; border-right-color: #B5C7DE;" height="100%" > 
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                     <asp:Button ID="btnrefresh" runat="server" Text="" 
                          style="background-image:url('images/refresh.png');background-repeat:no-repeat;background-color:Transparent; " 
                          BorderStyle="None" Height="20px" Width="20px" 
                          ToolTip="Refresh Folder Tree" onclick="btnrefresh_Click" /> 
                       </ContentTemplate>
                    </asp:UpdatePanel>   
                                <div style="height: 90%; width: 100%; overflow: auto">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>                       
                    <asp:TreeView ID="mytree" runat="server" Width="300px" 
                            Font-Names="Verdana" Font-Size="Small" ShowLines="True" NodeWrap="True" 
                            AutoGenerateDataBindings="False" EnableClientScript="true" ForeColor="White">
                        <SelectedNodeStyle BackColor="#FF9900" />
                    </asp:TreeView>
                        
                    </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td valign="top" width="70%" height="100%"  >
                <div style="width: 100%; height: 100%;">
                <iframe id="myframe" runat="server" name="myframe" frameborder="0" height="100%" width="100%"></iframe>
                
                    </div>
                </td>
            </tr>
        </table> 
    </div>
    </form>
</body>
</html>
