<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewComments.aspx.cs" Inherits="CmlTechniques.CMS.ViewComments" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Comments</title>

    <script type="text/javascript">

        function pageLoad() {
        }
    
    </script>
    <style>
  textarea {
background-color:#ffffff;
color:#000000;

}
        </style>

    <link href="../page.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .gvHeaderRow
        {
            background-image: url('../images/head_bg.png');
            background-repeat: repeat;
            font-family: Verdana;
            font-size: x-small;
            font-weight: normal;
            height: 30px;
        }
        .btnstyle
        {
            font-size: xx-small;
            cursor: pointer;
            color: Red;
        }
        textarea
        {
            width: 98%;
            border: none;
            text-align: justify;
            font-family: Verdana;
            font-size: 12px;

}

    </style>

    <script src="../Scripts/jquery.js" type="text/javascript"></script>

    <script src="../Scripts/jquery.autosize.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 98%; padding: 1%; font-family: verdana; font-size: 12px;">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div>
            <table style="width: 100%">
                <tr>
                    <td style="width: 100%; font-size: small; font-weight: bold" align="center">
                        <asp:Label ID="lbltitle" runat="server" Text=""></asp:Label>
                    </td>
                    <td id="tdupdate" runat="server">
                     <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnsavechnages" runat="server" Text="Update Changes" 
                                    Width="120px" onclick="btnsavechnages_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="right">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnprint" runat="server" Text="Print" Width="75px" OnClick="btnprint_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div style="padding: 5px; margin-bottom: 5px; border: solid 3px #C8ECFB">
            <table style="width:100%">
                <tr>
                    <td style="width: 100px">
                        MODULE NAME :
                    </td>
                    <td style="width: 200px">
                        <asp:Label ID="lb_module" runat="server" Font-Bold="True" Width="98%"></asp:Label>
                    </td>
                    <td style="width: 100px">
                        DOCUMENT NAME :
                    </td>
                    <td style="width: 500px">
                        <asp:Label ID="lb_docname" runat="server" Font-Bold="True" Width="98%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        UPLOAD DATE&nbsp;:
                    </td>
                    <td style="width: 200px">
                        <asp:Label ID="lb_update" runat="server" Font-Bold="True" Width="98%"></asp:Label>
                    </td>
                    <td style="width: 100px">
                        UPLOAD BY :
                    </td>
                    <td style="width: 500px">
                        <asp:Label ID="lb_upby" runat="server" Font-Bold="True" Width="98%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        REVISION :
                    </td>
                    <td style="width: 200px">
                        <asp:Label ID="lb_ltversion" runat="server" Font-Bold="True" Width="98%"></asp:Label>
                    </td>
                    <td style="width: 100px">
                        STATUS :
                    </td>
                    <td style="width: 500px">
                        <asp:Label ID="lb_status" runat="server" Font-Bold="True" Width="98%"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:Label ID="lblinfo" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblprj" runat="server" Text="" style="display:none" ></asp:Label>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="mygrid" runat="server" Width="100%" AutoGenerateColumns="False"
                        OnRowDataBound="mygrid_RowDataBound" OnRowCommand="mygrid_RowCommand" CellPadding="3">
                        <HeaderStyle CssClass="gvHeaderRow" />
                        <Columns>
                            <asp:BoundField DataField="doc_version" HeaderText="VERSION">
                                <ItemStyle HorizontalAlign="Center" Width="7%" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sec" HeaderText="SECTION">
                                <ItemStyle HorizontalAlign="Center" Width="7%" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="page" HeaderText="PAGE">
                                <ItemStyle HorizontalAlign="Center" Width="7%" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="comment_date" HeaderText="DATE" DataFormatString="{0:dd/MM/yyyy}">
                                <ItemStyle HorizontalAlign="Center" Width="7%" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="uid" HeaderText="NAME">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="12%" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="COMMENT">
                                <ItemTemplate>
                                    <textarea disabled="disabled" readonly="readonly"><%# Eval("comment")%></textarea>
                                </ItemTemplate>
                                <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="comment" HeaderText="COMMENT" >
                <ItemStyle Width="23%" HorizontalAlign="Left" />
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="CML RESPONSE">
                                <ItemTemplate>
                                    <textarea disabled="disabled" readonly="readonly"><%# Eval("cml_responds")%></textarea>
                                </ItemTemplate>
                                <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="cml_responds" HeaderText="CML RESPONSE">
                                <ItemStyle Width="23%" HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                            <%--<asp:ButtonField ButtonType="Button" Text="CML Response" CommandName="response">
                                <ControlStyle CssClass="btnstyle" Width="80px" />
                                <ItemStyle Width="80px" VerticalAlign="Top" />
                            </asp:ButtonField>--%>
                            <asp:TemplateField>
                            <ItemTemplate>
                                
                                    <asp:Button ID="btnresponse" runat="server" Text="CML Response" CommandName="response" CommandArgument='<%# Container.DataItemIndex %>' Font-Size="Smaller" ForeColor="Red" Width="100px" />
                                                                      <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="drclose" runat="server" Width="100px" style="margin-top:2px" AutoPostBack="true" OnSelectedIndexChanged="drclose_SelectedIndexChanged">
                                    <asp:ListItem Text="-- Status --" Value="2" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Open" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Closed" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
  
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="com_id" />
                            <asp:BoundField DataField="closed" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:Panel ID="pnlPopup1" runat="server" Width="300px" Height="275px" BackColor="White"
            Style="padding: 10px; display: none">
            <div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <b>CML RESPONSE</b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:CheckBox ID="chkresp" runat="server" Text="Typical CML Response" AutoPostBack="true"
                                                OnCheckedChanged="chkresp_CheckedChanged" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtresp" runat="server" Width="98%" TextMode="MultiLine" Height="150px" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                            <td>
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <asp:CheckBox ID="chkclose" runat="server" Text="Close Comment" 
                                                 />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                            </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnupdate" runat="server" Text="Save" OnClick="btnupdate_Click" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td>
                                                <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy1" runat="server" Text="Button" Style="display: none;" />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender1" runat="server" TargetControlID="btnDummy1"
            PopupControlID="pnlPopup1" BackgroundCssClass="modal">
        </asp:ModalPopupExtender>
    </div>
    </form>

    <script type="text/javascript">
        $(document).ready(function() {
            $('textarea').autosize();
        });
    </script>

</body>
</html>
