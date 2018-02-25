<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FATestUploadsEntry.aspx.cs" Inherits="CmlTechniques.CMS.FATestUploadsEntry" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .gvHeaderRow
    {
        background-image:url('../images/head_bg.png');
         background-repeat: repeat;
        font-family:Verdana;
        font-size:x-small;
        font-weight:normal;
    }
    .btnstyle
    {
    	font-size:xx-small;
    	cursor:pointer;
    	color:Red;
    }
    </style>
<script src="../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>
    </head>
<body style="background-color:#B8DBFF">
    <form id="form1" runat="server">
    <div style="width:100%;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
      <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
    <asp:Label ID="lblid" runat="server" Text="" style="display:none"></asp:Label>
    <asp:Label ID="lblmod" runat="server" Text="" style="display:none"></asp:Label>   
        <table style="background-color:#092443;width:100%;height:32px;font-family:Verdana;font-size:14px;font-weight:bold;">
        <tr >
         <td style="width:90%;padding:5px;color:#ffffff">
             <asp:Label ID="lbltitle" runat="server" Text=""></asp:Label> 
      
        </td>
             
       <td style="text-align:right;padding:5px">
        <a href="#" onclick="history.back(-1);" style="color:White;text-decoration:none;"> Back</a>
       </td>
        </tr>
        
        </table>
        <div style="padding:2px">
        <table>
            <tr>
                <td width="250px">
                    Document Name</td>
                <td>
                    <asp:TextBox ID="txtdoc_name" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    Select Document</td>
                <td height="60px" valign="top">
                    <input type="file" id="myupload" class="multi" runat="server" /></td>
            </tr>
            
            <tr id="tr_status" runat="server">
                <td >
                    <asp:Label ID="Label2" runat="server" Text="Document Status"></asp:Label>
                </td>
                <td >
                <asp:DropDownList ID="dr_status" runat="server" Width="100%">
                   <asp:ListItem Text="REVIEW" Value="1"></asp:ListItem>
                   <asp:ListItem Text="REJECTED" Value="2"></asp:ListItem>
                   <asp:ListItem Text="ACCEPTED" Value="3"></asp:ListItem>
                   <asp:ListItem Text="ACCEPTED WITH COMMENTS" Value="4"></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td >
                    <%--<asp:CheckBox ID="chk" runat="server" Text="Do Not Send Email Notification Upon Uploading" />--%>
                        </td>
            </tr>
            <tr>
                <td >
                    </td>
                <td >
                    <asp:Button ID="btnupload" runat="server" Text="Upload" 
                        onclick="btnupload_Click" />
                </td>
            </tr>
            </table>
        </div>
        <hr />
        
        <%--<div >
        <h4>Current Version Uploaded</h4>
            <asp:GridView ID="mygrid" runat="server" AutoGenerateColumns="False" Width="100%">
                <HeaderStyle CssClass="gvHeaderRow" Height="25px" />
                <RowStyle Height="25px" />
                <Columns>
                <asp:BoundField DataField="doc_name" HeaderText="DOCUMENT NAME">
                    <ItemStyle HorizontalAlign="Left" Width="64%" />
                    </asp:BoundField>
                <asp:BoundField DataField="upload_date" HeaderText="UPLOAD DATE" 
                        DataFormatString="{0:dd/MM/yyyy}" >
                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Version" HeaderText="VERSION" >
                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="doc_status" HeaderText="STATUS" >
                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>--%>
    </div>
    </form>
</body>
</html>
