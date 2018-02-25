<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="projectmngmentCMS.aspx.cs" Inherits="CmlTechniques.projectmngmentCMS" %>

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
<body bgcolor="#414141">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>      
            <table border="0" cellpadding="0" cellspacing="0" 
                style="width: 100%; height: 95%;font-family: Verdana; font-size: small; color: #FFFFFF; position:fixed;">
                <tr>
                <td  style="font-family: Verdana; font-size: small;" height="10%">
                
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
                            <td width="150px" align="center" valign="middle">
                                Module</td>
                            <td>
                                <asp:DropDownList ID="drmodules" runat="server" Width="388px" Height="25px">
                                    <asp:ListItem>CAS SHEET</asp:ListItem>
                                    <asp:ListItem>COMMISSIONING PLANS</asp:ListItem>
                                    <asp:ListItem>DOCUMENT REVIEWS</asp:ListItem>
                                    <asp:ListItem>METHOD STATEMENTS</asp:ListItem>
                                    <asp:ListItem>MINUTES</asp:ListItem>
                                    <asp:ListItem>PROGRAMMES</asp:ListItem>
                                    <asp:ListItem>SITE OBSERVATIONS</asp:ListItem>
                                    <asp:ListItem>TECHNICAL SUBMISSIONS</asp:ListItem>
                                    <asp:ListItem>TESTING & COMMISSIONING DOCUMENTATION</asp:ListItem>
                                    <asp:ListItem>TRAINING</asp:ListItem>  
                                </asp:DropDownList>
                            </td>
                            <td >
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" valign="middle" width="150px">
                                Action</td>
                            <td>
                                <asp:DropDownList ID="draction" runat="server" Height="25px" Width="388px">
                                    <asp:ListItem>Uploads</asp:ListItem>
                                    <asp:ListItem>CML Responds</asp:ListItem>                                    
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="cmdgo" runat="server" ForeColor="Red" Height="25px" 
                                            onclick="cmdgo_Click" Text="Continue.." />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                
                </td>
                </tr>                
                <tr>
                    <td valign="middle"style="font-family: Verdana; font-size:small;" bgcolor="#092443" 
                        align="left" height="4%">
                        <asp:Label ID="title" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="86%" valign="top" width="100%" 
                        style="font-family: Verdana; font-size: small;">
                    <div style="width: 100%; height: 100%; overflow:auto;" >
                    <iframe id="myframe" runat="server" frameborder="0" height="100%" width="100%" name="myframe" ></iframe></div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
