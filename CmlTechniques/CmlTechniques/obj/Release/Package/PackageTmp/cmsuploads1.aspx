<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cmsuploads1.aspx.cs" Inherits="CmlTechniques.CMS.cmsuploads1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
<body>
    <form id="form1" runat="server">
    <div style="width: 100%;">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:Label ID="lblprj" runat="server" Text="" Style="display: none"></asp:Label>
        <asp:Label ID="lblid" runat="server" Text="" Style="display: none"></asp:Label>
        <asp:Label ID="lblmod" runat="server" Text="" Style="display: none"></asp:Label>
        <%--   <asp:Label ID="lblTreepath" runat="server" Text="" Style="display: none"></asp:Label>--%>
        <asp:Label ID="lblFold_cms" runat="server" Text="" Style="display: none"></asp:Label>
        <asp:Label ID="lblM_id_cms" runat="server" Text="" Style="display: none"></asp:Label>
        <asp:Label ID="lblM_na_cms" runat="server" Text="" Style="display: none"></asp:Label>
        <%-- <asp:Label ID="Label3" runat="server" Text="" Style="display: none"></asp:Label>--%>
        <asp:Label ID="lblreff_no" runat="server" Text="" Style="display: none"></asp:Label>
        <%--  <asp:Label ID="lblfpath" runat="server" Text="" Style="display: none"></asp:Label>--%>
        <asp:Label ID="lbldiv" runat="server" Text="" Style="display: none"></asp:Label>
        <div class="fixedhead">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <div id="infobar">
                        <div class="prjinfo">
                            <div class="pullleft font-big">
                                CMS :
                                <asp:Label ID="prj" runat="server" Style="color: #e6422c"></asp:Label></div>
                            <div class="pullright font-big">
                                <asp:Label ID="package" runat="server" Style="color: #e6422c"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div id="pagetitle" runat="server">
                        <div class="title pull-left">
                            <asp:Label ID="phead" runat="server"></asp:Label>
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
                    <tr id="tr_type" runat="server">
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                    <asp:CheckBox ID="chk_private" runat="server" AutoPostBack="true" OnCheckedChanged="chk_private_CheckedChanged"
                                        Text="Private" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>                    
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="Label1" runat="server" Text="Comments By"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
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
                    <tr id="tr_status" runat="server" style="display: none">
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Document Status"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dr_status" runat="server" Width="100%">
                                <asp:ListItem Text="REVIEW" Value="1" Selected="True"></asp:ListItem>
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
                </table>
            </div>
        </div>
    </div>
    <asp:Panel ID="pnlPopup2" runat="server" Width="500px" Height="350px" BackColor="#83C8EE"
        Style="padding: 5px; display: none;">
        <div style="background-color: #fff; padding: 5px;">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <table style="width: 100%">
                        <tr>
                            <td colspan="2">
                                Select Users
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding-left: 5px">
                                <asp:CheckBox ID="chkall" runat="server" Text="All" AutoPostBack="true" OnCheckedChanged="chkall_CheckedChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div style="overflow: auto; height: 225px">
                                    <asp:CheckBoxList ID="chkprjusers" runat="server" Width="100%" RepeatDirection="Vertical"
                                        BackColor="Gainsboro">
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
                                                    <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click" Text="Send Notification" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>
                                            <asp:Button ID="btncancel" runat="server" OnClick="btncancel_Click" Text="Cancel" />
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
    </form>
</body>
</html>
