<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cassheet_DataEntry23.aspx.cs" Inherits="CmlTechniques.Cassheet_DataEntry23" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>

    <script type="text/javascript">

        function pageLoad() {
        }
    
    </script>

    <link href="page.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" id="shortcodescss" href="CMLT/Styles/accordin.css" type="text/css"
        media="all" />
    <style type="text/css">
        .style1
        {
            height: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: verdana; font-size: x-small; height: 100%; position: fixed;
        width: 100%">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:Label ID="lblsch" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lbluid" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lbldiv" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblref" runat="server" Text="" CssClass="hidden"></asp:Label>
        <table style="width: 100%; color: White" bgcolor="#092443">
            <tr>
                <td colspan="5" style="background-color: #D2F1FC">
                    <asp:Label ID="lblhead" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="CAS Security Management System Commissioning Activity Schedule"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    <asp:Label ID="Label1" runat="server" Text="Select Package" Width="100px"></asp:Label>
                </td>
                <td width="250px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="drpackage" runat="server" Width="250px" AutoPostBack="True"
                                OnSelectedIndexChanged="drpackage_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
<%--                    <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                        <ContentTemplate>--%>
                            <asp:Button ID="btnimport" runat="server" Text="Import From Excel" OnClick="btnimport_Click" STYLE="display:none" />
                     <%--   </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                        <ContentTemplate>
                            <asp:ImageButton ID="btnrefresh" runat="server" ImageUrl="~/images/refresh1.png"
                                OnClick="btnrefresh_Click" CssClass="hidden" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td width="100%" align="right">
                    <table>
                        <tr>
                            <td style="width: 100px" align="center">
                                &nbsp;
                            </td>
                            <td style="width: 200px">
                                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtsearch" runat="server" Width="200px"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnsearch" runat="server" Text="Search" Width="75px" OnClick="btnsearch_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnaddm" runat="server" Text="Add-M" Width="75px" OnClick="btnaddm_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnedit" runat="server" Text="Edit" OnClick="btnedit_Click" Width="75px" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btndelete1" runat="server" Text="Delete" Width="75px" OnClick="btndelete1_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div style="float: left; width: 98.5%">
            <table style="font-family: Verdana; font-size: x-small;width: 100%;" cellspacing="1" border="0">
                <tr style="background-image: url('images/head_bg.png'); background-repeat: repeat-x;height:32px">
                    <td align="center"  valign="middle" width="5%">
                        &nbsp;
                    </td>
                    <td align="center"  valign="middle" width="5%">
                        ITEM NO
                    </td>
                    <td align="center"  valign="middle" width="50%">
                        REPORT TITLE</td>

                    <td align="center"  valign="middle" width="40%" id="td_lbldes" runat="server">
                       
                   REPORT REF NO</td>
                </tr>
                <tr bgcolor="#092443">
                    <td style="width:5%">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnadd" runat="server" Text="Add" OnClick="btnadd_Click" Width="94%" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width:5%">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtitmno" runat="server" Width="94%" Style="text-align: center"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width:50%">
                        <asp:TextBox ID="txt_title" runat="server" Width="99%"></asp:TextBox>
                    </td>
                    <td  style="width:40%">
                        <asp:TextBox ID="txtengref" runat="server" Width="99%"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#092443">
                    <td style="width:5%">
                        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnexpand" runat="server" Text="Exp.All" Width="100%" OnClick="btnexpand_Click"
                                    ForeColor="Red" Font-Size="X-Small" Style="cursor: pointer" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width:5%">
                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btncollapse" runat="server" Text="Coll.All" Width="100%" ForeColor="Red"
                                    Font-Size="X-Small" Style="cursor: pointer" OnClick="btncollapse_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width:50%">
                        &nbsp;
                    </td>
                    <td style="width:40%">
                    </td>
                </tr>
            </table>
        </div>
        <div style="position: relative; height: 67%; width: 100%; overflow-y: scroll; float: left;">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="mymaster" runat="server" AutoGenerateColumns="False" Width="100%"
                        OnRowDataBound="mymaster_RowDataBound" Font-Names="Verdana" Font-Size="X-Small"
                        ShowHeader="False" GridLines="None">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table id="inner_table" width="100%">
                                        <tr style="background-image: url('images/head_bg.png'); background-repeat: repeat-x;">
                                            <td style="width: 50px">
                                                <asp:Button ID="Button1" runat="server" Text="-" CommandArgument="Button1" OnClick="Button1_Click"
                                                    Width="30px" Style="cursor: pointer" />
                                            </td>
                                            <td style="font-weight: bold; width: 100%" align="left">
                                                <table>
                                                    <td>
                                                        <asp:CheckBox ID="chkrow1" runat="server" OnCheckedChanged="chkrow1_CheckedChanged"
                                                            AutoPostBack="true" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbSys_Name" runat="server" Text='<%# Eval("Sys_Name") %>' Width="300px"></asp:Label>
                                                        <asp:Label ID="lbSys_Id" runat="server" Text='<%# Eval("Sys_Id") %>' Style="display: none"></asp:Label>
                                                    </td>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <%--<div class="accordion" rel="1">
        <div class="accordion-title"><a href='#'>
         <table>
            <td><asp:CheckBox ID="chkrow1" runat="server" OnCheckedChanged="chkrow1_CheckedChanged" AutoPostBack="true" /></td>
            <td>
            <asp:Label ID="lbSys_Name" runat="server" Text='<%# Eval("Sys_Name") %>' Width="300px"></asp:Label>
                <asp:Label ID="lbSys_Id" runat="server" Text='<%# Eval("Sys_Id") %>' style="display:none"></asp:Label>
            </td>
            </table>
            </a>
        </div>--%>
                                                        <%--<div class="accordion-inner" style="display: none;">--%>
                                                        <asp:GridView ID="mydetails" runat="server" ShowHeader="false" AutoGenerateColumns="false"
                                                            Width="100%" OnRowCommand="mydetails_RowCommand" OnRowDataBound="mydetails_RowDataBound"
                                                            Font-Names="Verdana" GridLines="Both" Font-Size="X-Small">
                                                            <Columns>
                                                                <%--<asp:ButtonField ButtonType="Button" Text="Update" CommandName="Get"
                        ItemStyle-Width="6%" >
                    <ItemStyle Width="6%"  />
                    </asp:ButtonField>--%>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkrow" runat="server" OnCheckedChanged="chkrow_CheckedChanged"
                                                                            AutoPostBack="true" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Itm.No" ItemStyle-Width="5%">
                                                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                 <asp:BoundField DataField="Des" HeaderText="Report Title" ItemStyle-Width="7%">
                                                                    <ItemStyle Width="50%" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="E_b_ref" HeaderText="Report reff no" ItemStyle-Width="10%">
                                                                    <ItemStyle Width="40%" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="C_id" />
                                                                <asp:BoundField DataField="Sys_Id" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:Panel ID="pnlPopup" runat="server" Width="400px" Style="padding: 15px; background-color: #83C8EE;
            display: none">
            <div>
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <div>
                            <table style="width: 400px; background-color: White;">
                                <tr>
                                    <td width="250px">
                                        Report title
                                    </td>
                                    <td width="150px">
                                     <asp:TextBox ID="uptitle" runat="server" Width="150px"></asp:TextBox>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td width="150px">
                                        Report ref no
                                    </td>
                                    <td>
                                    <asp:TextBox ID="upreff" runat="server" Width="150px"></asp:TextBox>
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click"
                                                        Style="display: none" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy" runat="server" Text="Button" Style="display: none;" />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" TargetControlID="btnDummy"
            PopupControlID="pnlPopup" BackgroundCssClass="modal">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlPopup1" runat="server" Width="250px" Style="padding: 15px; background-color: #83C8EE;
            display: none">
            <div>
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <div>
                            <table style="width: 250px; background-color: White;">
                                <tr>
                                    <td style="width: 150px">
                                        ENTER FLOOR LEVEL
                                    </td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtflvl" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btncancel1" runat="server" Text="Cancel" OnClick="btncancel1_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy1" runat="server" Text="Button" Style="display: none;" />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender1" runat="server" TargetControlID="btnDummy1"
            PopupControlID="pnlPopup1" BackgroundCssClass="modal">
        </asp:ModalPopupExtender>
    </div>

    <script src="CMLT/Asset/jquery.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="CMLT/Js/shortcodes.js"></script>

    </form>
</body>
</html>
