<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FATestUploadsList.aspx.cs"
    Inherits="CmlTechniques.CMS.FATestUploadsList" %>

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
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:Label ID="lblprj" runat="server" Text="" Style="display: none"></asp:Label>
    <asp:Label ID="lblid" runat="server" Text="" Style="display: none"></asp:Label>
    <asp:Label ID="lblmod" runat="server" Text="" Style="display: none"></asp:Label>
    <div style="font-family: verdana; font-size: x-small;">
        <div style="float: left; width: 100%; height: 100%">
            <div style="width: 98%; padding: 0 1% 0 1%">
                <table style="width: 100%" border="0">
                    <tr style="height: 30px; background-color: #092443; font-family: Verdana; font-size: 14px;">
                        <td style="text-align: left; width: 100%; color: #ffffff; padding: 5px; font-weight: bold">
                            <div class="pull-left" style="padding-top: 5px;">
                                <asp:Label ID="lbltitle" runat="server" Text=""></asp:Label></div>
                            <div class="pull-right">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnuploadnew" runat="server" Text="Upload New" OnClick="btnuploadnew_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="center" style="font-family: Verdana; font-size: small;
                            color: #FFFFFF;" height="30px" bgcolor="#092443">
                            Latest Version
                        </td>
                    </tr>
                </table>
                <table border="1" style="border-collapse: collapse; border-color: #999999; border-style: none;
                    border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" width="100%">
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat;
                        height: 30px">
                        <td style="width: 30%" align="center">
                            DOCUMENT NAME
                        </td>
                        <td style="width: 30%" align="center">
                            FILE NAME
                        </td>
                        <td style="width: 12%" align="center">
                            UPLOAD DATE
                        </td>
                        <td style="width: 10%" align="center">
                            VERSION
                        </td>
                        <td style="width: 10%" align="center">
                            STATUS
                        </td>
                        <td style="width: 4%" align="center" id="tdDelete" runat="server">
                        </td>
                    </tr>
                </table>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="mygrid" runat="server" Width="100%" AutoGenerateColumns="False"
                            OnRowCommand="mygrid_RowCommand" OnRowDataBound="mygrid_RowDataBound" Font-Names="Verdana"
                            Font-Size="X-Small" CellPadding="5" ShowHeader="false">
                            <HeaderStyle CssClass="gvHeaderRow" Height="25px" />
                            <RowStyle Height="25px" />
                            <Columns>
                                <asp:BoundField DataField="doc_id" />
                                <asp:BoundField DataField="file_name" />
                                <asp:BoundField DataField="doc_name" HeaderText="DOCUMENT NAME">
                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                </asp:BoundField>
                                <asp:ButtonField DataTextField="file_name" HeaderText="FILE NAME" CommandName="view">
                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                </asp:ButtonField>
                                <asp:BoundField DataField="upload_date" HeaderText="DATE" DataFormatString="{0:dd/MM/yyyy}">
                                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Version" HeaderText="VERSION">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="doc_status" HeaderText="STATUS">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="delete">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnbutton" runat="server" ImageUrl="~/images/edit-8-16.png"
                                            CommandName="delete1" CommandArgument='<%# Container.DataItemIndex %>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="4%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <table style="width: 100%" border="0">
                    <tr>
                        <td valign="middle" align="center" style="font-family: Verdana; font-size: small;
                            color: #FFFFFF;" height="30px" bgcolor="#092443">
                            History - Previous Versions
                        </td>
                    </tr>
                </table>
                <table border="1" style="border-collapse: collapse; border-color: #999999; border-style: none;
                    border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" width="100%">
                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat;
                        height: 30px">
                        <td style="width: 30%" align="center">
                            DOCUMENT NAME
                        </td>
                        <td style="width: 30%" align="center">
                            FILE NAME
                        </td>
                        <td style="width: 12%" align="center">
                            UPLOAD DATE
                        </td>
                        <td style="width: 10%" align="center">
                            VERSION
                        </td>
                        <td style="width: 10%" align="center">
                            STATUS
                        </td>
                        <td style="width: 4%" align="center" id="tdgrid1" runat="server">
                        </td>
                    </tr>
                </table>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                <asp:GridView ID="mygrid1" runat="server" Width="100%" AutoGenerateColumns="False"
                    OnRowDataBound="mygrid1_RowDataBound" Font-Names="Verdana" Font-Size="X-Small"
                    CellPadding="5" ShowHeader="false" OnRowCommand="mygrid1_RowCommand">
                    <HeaderStyle CssClass="gvHeaderRow" Height="25px" />
                    <RowStyle Height="25px" />
                    <Columns>
                        <asp:BoundField DataField="doc_id" />
                        <asp:BoundField DataField="file_name" />
                        <asp:BoundField DataField="doc_name" HeaderText="DOCUMENT NAME">
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                        </asp:BoundField>
                        <asp:ButtonField DataTextField="file_name" HeaderText="FILE NAME" CommandName="view">
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                        </asp:ButtonField>
                        <asp:BoundField DataField="upload_date" HeaderText="DATE" DataFormatString="{0:dd/MM/yyyy}">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="12%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Version" HeaderText="VERSION">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="doc_status" HeaderText="STATUS">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="delete">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnbutton" runat="server" ImageUrl="~/images/edit-8-16.png"
                                    CommandName="delete1" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                            <ItemStyle Width="4%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </ContentTemplate>
                </asp:UpdatePanel>
                
            </div>
        </div>
    </div>
    
            <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1"
                TargetControlID="Button1" BackgroundCssClass="model-background" >
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel1" runat="server" Style="display: none; width: 350px; background-color: White;
                border-width: 1px; border-color: Black; border-style: solid; padding: 10px;">
                <p>
                    <b>Edit Document</b></p>
                <table style="width: 100%">
                    <tr>
                        <td style="width:150px">
                            Select Status
                        </td>
                        <td style="width:200px">
                            <asp:DropDownList ID="drstatus" runat="server">
                                <asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>
                                <asp:ListItem Text="ACCEPTED" Value="1"></asp:ListItem>
                                <asp:ListItem Text="ACCEPTED WITH COMMENTS" Value="2"></asp:ListItem>
                                <asp:ListItem Text="REJECTED" Value="3"></asp:ListItem>
                                <asp:ListItem Text="REVIEW" Value="4"></asp:ListItem>
                                <asp:ListItem Text="REVISED" Value="5"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        <br />
                        <br />
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="Button3" runat="server" Text="Delete" OnClick="Delete_Click" />
                                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are You Sure Want To Delete?" TargetControlID="Button3" >
                                                </asp:ConfirmButtonExtender>
                                            </td>
                                            <td>
                                                <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
    
    </form>
</body>
</html>
