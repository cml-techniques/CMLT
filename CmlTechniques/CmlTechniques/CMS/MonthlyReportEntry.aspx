<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonthlyReportEntry.aspx.cs"
    Inherits="CmlTechniques.CMS.MonthlyReportEntry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <script type="text/javascript">

        function pageLoad() {
        }
    
    </script>

    <link href="../page.css" rel="stylesheet" type="text/css" />
    <link href="../Assets/css/Style.css" rel="stylesheet" type="text/css" />
    <link href="../Assets/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .gvHeaderRow
        {
            background-image: url('../images/head_bg.png');
            background-repeat: repeat;
            font-family: Verdana;
            font-size: x-small;
            font-weight: normal;
        }
        .btnstyle
        {
            font-size: xx-small;
            cursor: pointer;
            color: Red;
        }
    </style>

    <script src="../Scripts/jquery-1.3.2.js" type="text/javascript"></script>

    <script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>

</head>
<body >
    <form id="form1" runat="server">
    <div style="width: 100%;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:Label ID="lblprj" runat="server" Text="" Style="display: none"></asp:Label>
        <asp:Label ID="lblid" runat="server" Text="" Style="display: none"></asp:Label>
        <asp:Label ID="lblmod" runat="server" Text="" Style="display: none"></asp:Label>
        <div class="fixedhead">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <div id="infobar">
                        <div class="prjinfo">
                            <div class="pullleft font-big">
                                <a href="#" onclick="Fullscreen();"><i class="fa fa-align-justify"></i></a> CMS :
                                <asp:Label ID="prj" runat="server" Style="color: #e6422c"></asp:Label></div>
                            <div class="pullright font-big">
                                <asp:Label ID="package" runat="server" Style="color: #e6422c"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div id="pagetitle" runat="server">
                        <div class="title pull-left">
                            <asp:Label ID="phead" runat="server" Text="Upload - Monthly Reports"></asp:Label>
                        </div>
                        <div class="btns pull-right">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnback" runat="server" Text="Back" OnClientClick="javascript:history.go(-1);" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="fixedcontent">
            <div id="doc_list">
                <table>
                    <tr>
                        <td width="250px">
                            Document Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtdoc_name" runat="server" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            Select Document
                        </td>
                        <td height="60px" valign="top">
                            <input type="file" id="myupload" class="multi" runat="server" />
                        </td>
                    </tr>
                    <tr id="tr_status" runat="server">
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Document Status"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dr_status" runat="server" Width="100%">
                                <asp:ListItem Text="REVIEW" Value="1"></asp:ListItem>
                                <asp:ListItem Text="REJECTED" Value="2"></asp:ListItem>
                                <asp:ListItem Text="ACCEPTED" Value="3"></asp:ListItem>
                                <asp:ListItem Text="ACCEPTED WITH COMMENTS" Value="4"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <%--<asp:CheckBox ID="chk" runat="server" Text="Do Not Send Email Notification Upon Uploading" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnupload" runat="server" Text="Upload" OnClick="btnupload_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
