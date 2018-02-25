<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cmsuploads.aspx.cs" Inherits="CmlTechniques.cmsuploads" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">

        function pageLoad() {
        }
    
    </script>

    <link href="page.css" rel="stylesheet" type="text/css" />
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

    <script src="Scripts/jquery-1.3.2.js" type="text/javascript"></script>

    <script src="Scripts/jquery.MultiFile.js" type="text/javascript"></script>

</head>
<body style="background-color: #B8DBFF">
    <form id="form1" runat="server">
    <div>
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server" />--%>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div style="padding: 5px">
            <h3>
                <asp:Label ID="lbl_title" runat="server" Text=""></asp:Label></h3>
            <%--<table style="width:100%" border="0">
        <tr>
        <td style="background-position: left center; width:30px; background-image: url('images/hleft.png'); background-repeat: no-repeat; height:30px"></td>
        <td style="background-position: left center; width:100%; background-image: url('images/hmid.png'); background-repeat: repeat-x; height:30px">
            </td>
        <td style="background-position: right center; width:30px; background-image: url('images/hright.png'); background-repeat: no-repeat; height:30px"></td>
        </tr>
        </table>--%>
            <asp:Label ID="lblpr" runat="server" Text=""></asp:Label>
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
                    <td height="40px" valign="top">
                        <input type="file" id="myupload" class="multi" runat="server" />
                    </td>
                </tr>
                <tr id="tr_issued" runat="server">
                    <td>
                        Issued By
                    </td>
                    <td>
                        <asp:DropDownList ID="dr_issuedby" runat="server" Width="100%">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="tr_type" runat="server">
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:CheckBox ID="chk_private" runat="server" AutoPostBack="true" OnCheckedChanged="chk_private_CheckedChanged"
                                    Text="Private" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="Label1" runat="server" Text="Comments By"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:CheckBoxList ID="chk_company" runat="server" Height="100px" Width="245px" RepeatLayout="Flow"
                                    BackColor="White">
                                </asp:CheckBoxList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr id="tr_response" runat="server">
                    <td>
                        Response By
                    </td>
                    <td>
                        <asp:DropDownList ID="dr_responseBy" runat="server" Width="100%">
                        </asp:DropDownList>
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
                        <asp:CheckBox ID="chk" runat="server" Text="Do Not Send Email Notification Upon Uploading" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnupload" runat="server" Text="Upload" OnClick="btnupload_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblmspath" runat="server" Text="" Style="display: none"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <hr />
        <div style="padding: 5px">
            <h4>
                Current Version Uploaded</h4>
            <asp:GridView ID="mygrid" runat="server" AutoGenerateColumns="False" Width="100%">
                <HeaderStyle CssClass="gvHeaderRow" Height="25px" />
                <RowStyle Height="25px" />
                <Columns>
                    <asp:BoundField DataField="doc_name" HeaderText="DOCUMENT NAME">
                        <ItemStyle HorizontalAlign="Left" Width="64%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="upload_date" HeaderText="UPLOAD DATE" DataFormatString="{0:dd/MM/yyyy}">
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Version" HeaderText="VERSION">
                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="doc_status" HeaderText="STATUS">
                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Panel ID="pnlPopup2" runat="server" Width="500px" Height="350px" BackColor="#83C8EE"
            Style="padding: 5px;display:none;">
            <div style="background-color: #fff; padding: 5px;">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    Select Users</td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding-left:5px">
                                    <asp:CheckBox ID="chkall" runat="server" Text="All" AutoPostBack="true" 
                                        oncheckedchanged="chkall_CheckedChanged" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                <div style="overflow:auto;height:225px">
                                    <asp:CheckBoxList ID="chkprjusers" runat="server" Width="100%" RepeatDirection="Vertical" BackColor="Gainsboro"  >
                                    </asp:CheckBoxList>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click" 
                                                            Text="Send Notification" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td>
                                                <asp:Button ID="btncancel1" runat="server" OnClick="btncancel1_Click" 
                                                    Text="Cancel" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <div id="myprogress" runat="server" style="position: absolute; z-index: 40; top: 30%;
                            left: 35%">
                            <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                <ProgressTemplate>
                                    <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                                        Width="250px" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy2" runat="server" Text="Button" Style="display: none;" />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender2" runat="server" TargetControlID="btnDummy2"
            PopupControlID="pnlPopup2" BackgroundCssClass="model-background">
        </asp:ModalPopupExtender>
    </div>
    </form>
</body>
</html>
