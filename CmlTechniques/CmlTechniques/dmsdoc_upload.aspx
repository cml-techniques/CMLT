<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dmsdoc_upload.aspx.cs" Inherits="CmlTechniques.dmsdoc_upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .gvHeaderRow
    {
        background-image:url('images/head_bg.png');
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
<script src="Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="Scripts/jquery.MultiFile.js" type="text/javascript"></script>
</head>
<body style="background-color:#fff">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div style="padding:5px">
        <h3><asp:Label ID="lbl_title" runat="server" Text=""></asp:Label></h3>
        <%--<table style="width:100%" border="0">
        <tr>
        <td style="background-position: left center; width:30px; background-image: url('images/hleft.png'); background-repeat: no-repeat; height:30px"></td>
        <td style="background-position: left center; width:100%; background-image: url('images/hmid.png'); background-repeat: repeat-x; height:30px">
            </td>
        <td style="background-position: right center; width:30px; background-image: url('images/hright.png'); background-repeat: no-repeat; height:30px"></td>
        </tr>
        </table>--%>  
            <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
            <asp:Label ID="lbltype" runat="server" Text="" style="display:none"></asp:Label>
            <asp:Label ID="lblfolder" runat="server" Text="" style="display:none"></asp:Label>     
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
                <td height="40px" valign="top">
                    <input type="file" id="myupload" class="multi" runat="server" /></td>
            </tr>
            
            <tr>
                <td >
                    &nbsp;</td>
                <td >
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td >
                    <asp:CheckBox ID="chk" runat="server" Text="Do Not Send Email Notification Upon Uploading" />
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
            <tr>
                <td >
                    <asp:Label ID="lblmspath" runat="server" Text="" style="display:none" ></asp:Label>
                </td>
                <td >
                    &nbsp;</td>
            </tr>
        </table>
        </div>
        <hr />
        
        <div style="padding:5px">
        <h4></h4>
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
        </div>
    </div>
    </form>
</body>
</html>
