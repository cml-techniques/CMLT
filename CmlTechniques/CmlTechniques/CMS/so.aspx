<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="so.aspx.cs" Inherits="CmlTechniques.CMS.so" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">

        function pageLoad() {
        }
        function Fullscreen() {
            var myFrameset = parent.document.getElementById("main");
            var value = myFrameset.getAttribute("cols");
            if (value == "210px,100%") {
                parent.document.getElementById("main").cols = "0px,100%";
                parent.document.getElementById("container").rows = "0px,100%";
            }
            else {
                parent.document.getElementById("main").cols = "210px,100%";
                parent.document.getElementById("container").rows = "115px,100%";
            }
        }
    </script>

    <link href="../page.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-1.3.2.js" type="text/javascript"></script>

    <script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>

    <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" />
    <link href="../Assets/css/Style.css" rel="stylesheet" type="text/css" />
    <link href="../Assets/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
</head>
<body >
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="fixedhead" runat="server" id="dvfixedhead">
        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
            <ContentTemplate>
                <div id="infobar">
                    <div class="prjinfo">
                        <div class="pullleft font-big">
                            <a href="#" onclick="Fullscreen();"><i class="fa fa-align-justify"></i></a> CMS :
                            <asp:Label ID="prj" runat="server" Style="color: #e6422c"></asp:Label></div>
                        <div class="pullright font-big">
                            <asp:Label ID="package" runat="server" Style="color: #e6422c" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <%--<div id="pagetitle" runat="server">
                    <asp:Label ID="phead" runat="server" test="hi"></asp:Label>
                </div>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="fixedcontent" style="top: 31px; overflow: auto" runat="server" id="dvfixedcontent">
        <div style="width: 100%; font-family: verdana; font-size: x-small;">
            
                <asp:Label ID="lblid" runat="server" Text="" Style="display: none"></asp:Label>
                <asp:Label ID="lblprj" runat="server" Text="" Style="display: none"></asp:Label>
                <asp:Label ID="lblaccess" runat="server" Text="" Style="display: none"></asp:Label>
                <table style="background-color: #092443; color: White; width: 100%">
                    <tr>
                        <td width="110px">
                            Service
                        </td>
                        <td width="200px">
                            <asp:DropDownList ID="drpackage" runat="server" Width="200px">
                            </asp:DropDownList>
                        </td>
                        <td width="110px">
                            Subject
                        </td>
                        <td width="300px">
                            <asp:TextBox ID="txtdoc" runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td width="110px">
                            &nbsp;
                        </td>
                        <td width="250px">
                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="drissued" runat="server" Width="250px">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnadd" runat="server" Text="Add" OnClick="btnadd_Click" Width="100px" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td style="font-size: xx-large; font-weight: bold;">
                            SO
                        </td>
                        <td style="width: 70px" align="center">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnprint" runat="server" Text="Print" CssClass="btnclass" Style="cursor: pointer"
                                        BorderStyle="None" Height="30px" Width="70px" OnClick="btnprint_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
                <div style="height: 100%">
                    <%--<asp:GridView ID="mygrid" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" ForeColor="#333333" GridLines="Horizontal" 
                onrowdatabound="mygrid_RowDataBound" Width="100%" 
                onrowcommand="mygrid_RowCommand">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                <asp:BoundField DataField="so_id" />
                    <asp:ButtonField DataTextField="so_no" HeaderText="SO.NO" ButtonType="Link" />
                    <asp:BoundField DataField="so_date" HeaderText="DATE" 
                        DataFormatString="{0:dd/MM/yyyy}" >
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                <asp:BoundField DataField="package" HeaderText="PACKAGE" >
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                <asp:BoundField DataField="doc_name" HeaderText="DOCUMENT REVIEWED" > 
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                <asp:BoundField DataField="issued_to" HeaderText="ISSUED TO" >
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                <asp:BoundField DataField="issued_date" HeaderText="ISSUED DATE" >
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="RESPONSE RECEIVED" >
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="COMMENTS" >
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="RESPONSE" >
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="OVER DUE (days)" >
                    <HeaderStyle HorizontalAlign="Left" Width="70px" />
                    </asp:BoundField>
                <asp:BoundField DataField="remarks" HeaderText="REMARKS" >               
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>--%>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <%--<asp:ListView ID="mydirview" runat="server" DataKeyNames="so_id" 
                onitemcommand="mydirview_ItemCommand" 
                onselectedindexchanging="mydirview_SelectedIndexChanging" 
                onitemcanceling="mydirview_ItemCanceling" 
                onitemediting="mydirview_ItemEditing" 
                onitemdatabound="mydirview_ItemDataBound" 
                onitemupdating="mydirview_ItemUpdating" style="width:100%">
                <ItemTemplate>
                    <tr id="itm_tr" runat="server">
                        <td>
                            <asp:Button ID="btndr_no" runat="server" Text='<%# Eval("so_no") %>' CommandName="select" />
                            <asp:Label ID="so_idLabel" runat="server" Text='<%# Eval("so_id") %>' style="display:none" />
                        </td>
                        <td>
                            <asp:Label ID="packageLabel" runat="server" Text='<%# Eval("package") %>' Width="100px" />
                        </td>
                        <td>
                            <asp:Label ID="doc_nameLabel" runat="server" Text='<%# Eval("doc_name") %>' Width="250px" />
                        </td>
                        <td align="center">
                            <asp:Label ID="issued_dateLabel" runat="server" 
                                Text='<%# Eval("issued_date","{0:dd-MM-yy}") %>' Width="60px" />
                                <asp:Label ID="lbdate" runat="server" Text='<%# Eval("issued_date") %>' style="display:none"  />
                        </td>
                        <td align="center">
                        <asp:Label ID="uidLabel" runat="server" Text='<%# Eval("uid") %>' Width="180px"/>
                        </td>
                        <td align="center">
                            <asp:Label ID="issued_toLabel" runat="server" Text='<%# Eval("issued_to") %>' Width="180px" />
                        </td>
                        <td align="center">
                            <asp:Label ID="commentLabel" runat="server" Text='<%# Eval("comment") %>' Width="70px" />
                        </td>
                        <td align="center">
                            <asp:Label ID="responseLabel" runat="server" Text='<%# Eval("response") %>' Width="70px"  />
                        </td>
                        <td align="center">
                            <asp:Label ID="statusLabel" runat="server" Text='<%# Eval("status") %>' Width="50px" />
                        </td>
                        <td align="center">
                         <asp:Label ID="lbdue" runat="server"   />
                        </td>
                        <td>
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                        Text="Edit" style="cursor:pointer"  />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr id="itm_tr" runat="server">
                        <td>
                            <asp:Button ID="btndr_no" runat="server" Text='<%# Eval("so_no") %>' CommandName="select" />
                            <asp:Label ID="so_idLabel" runat="server" Text='<%# Eval("so_id") %>' style="display:none" />
                        </td>
                        <td>
                            <asp:Label ID="packageLabel" runat="server" Text='<%# Eval("package") %>' Width="100px" />
                        </td>
                        <td>
                            <asp:Label ID="doc_nameLabel" runat="server" Text='<%# Eval("doc_name") %>' Width="250px" />
                        </td>
                        <td align="center">
                            <asp:Label ID="issued_dateLabel" runat="server" 
                                Text='<%# Eval("issued_date","{0:dd-MM-yy}") %>' Width="60px" />
                                <asp:Label ID="lbdate" runat="server" Text='<%# Eval("issued_date") %>' style="display:none"  />
                        </td>
                         <td align="center">
                        <asp:Label ID="uidLabel" runat="server" Text='<%# Eval("uid") %>' Width="180px"/>
                        </td>
                        <td align="center">
                            <asp:Label ID="issued_toLabel" runat="server" Text='<%# Eval("issued_to") %>' Width="180px" />
                        </td>
                        <td align="center">
                            <asp:Label ID="commentLabel" runat="server" Text='<%# Eval("comment") %>' Width="70px" />
                        </td>
                        <td align="center">
                            <asp:Label ID="responseLabel" runat="server" Text='<%# Eval("response") %>' Width="70px"  />
                        </td>
                        <td align="center">
                            <asp:Label ID="statusLabel" runat="server" Text='<%# Eval("status") %>' Width="50px" />
                        </td>
                        <td align="center">
                         <asp:Label ID="lbdue" runat="server"   />
                        </td>
                        <td>
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                        Text="Edit" style="cursor:pointer"  />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" 
                        style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                        <tr>
                            <td>
                                No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                                Text="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                Text="Clear" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="so_noTextBox" runat="server" Text='<%# Bind("so_no") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="so_dateTextBox" runat="server" Text='<%# Bind("so_date") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="packageTextBox" runat="server" Text='<%# Bind("package") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="doc_nameTextBox" runat="server" 
                                Text='<%# Bind("doc_name") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="issued_dateTextBox" runat="server" 
                                Text='<%# Bind("issued_date") %>' />
                        </td>
                         <td>
                        <asp:Label ID="uidLabel" runat="server" Text='<%# Eval("uid") %>' Width="170px"/>
                        </td>
                        <td>
                            <asp:TextBox ID="issued_toTextBox" runat="server" 
                                Text='<%# Bind("issued_to") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="remarksTextBox" runat="server" Text='<%# Bind("remarks") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="commentTextBox" runat="server" Text='<%# Bind("comment") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="responseTextBox" runat="server" 
                                Text='<%# Bind("response") %>' />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                    style="border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat;">
                                        <th runat="server" height="30px">
                                            SO.NO</th>
                                        <th runat="server">
                                            SERVICE</th>
                                        <th runat="server">
                                            SUBJECT</th>
                                        <th runat="server">
                                            ISSUED DATE</th>
                                            <th runat="server">
                                            REVIEWED BY</th>
                                        <th runat="server">
                                            ISSUED TO</th>
                                        <th runat="server">
                                            COMMENTS</th>
                                        <th runat="server">
                                            RESPONSE</th>
                                            <th runat="server">
                                            STATUS</th>
                                        <th runat="server" width="70px">
                                            OVER DUE (days)</th>
                                            <th runat="server">
                                            </th>
                                    </tr>
                                    <tr ID="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" 
                                style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <EditItemTemplate>
                    <tr style="background-color: #DEF6FE;" id="itm_tr" runat="server">
                        <td>
                            <asp:Label ID="so_noLabel" runat="server" Text='<%# Eval("so_no") %>' />
                            <asp:Label ID="so_idLabel" runat="server" Text='<%# Eval("so_id") %>' style="display:none" />
                        </td>
                        <td>
                            <asp:Label ID="packageLabel" runat="server" Text='<%# Eval("package") %>' Width="100px" />
                        </td>
                        <td>
                            <asp:Label ID="doc_nameLabel" runat="server" Text='<%# Eval("doc_name") %>' Width="250px" />
                        </td>
                        <td>
                            <asp:Label ID="issued_dateLabel" runat="server" 
                                Text='<%# Eval("issued_date","{0:dd-MM-yy}") %>' Width="60px" />
                                <asp:Label ID="lbdate" runat="server" Text='<%# Eval("issued_date") %>' style="display:none"  />
                        </td>
                        <td>
                        <asp:Label ID="uidLabel" runat="server" Text='<%# Eval("uid") %>' Width="180px"/>
                        </td>
                        <td>
                            <asp:Label ID="issued_toLabel" runat="server" Text='<%# Eval("issued_to") %>' Width="180px" />
                            
                        </td>
                        <td>
                            <asp:Label ID="commentLabel" runat="server" Text='<%# Eval("comment") %>' Width="70px" />
                        </td>
                        <td>
                            <asp:Label ID="responseLabel" runat="server" Text='<%# Eval("response") %>' Width="70px"  />
                        </td>
                        <td>
                            <asp:Label ID="statusLabel" runat="server" Text='<%# Eval("status") %>' style="display:none" />
                            <asp:DropDownList ID="drstatus" runat="server" Width="50px" >
                            </asp:DropDownList>
                        </td>
                        <td>
                         <asp:Label ID="lbdue" runat="server"   />
                        </td>
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                                Text="Update" Width="75px" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                Text="Cancel" Width="75px" />
                        </td>
                    </tr>
                </EditItemTemplate>
                <SelectedItemTemplate>
                    <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                        <td>
                            <asp:Label ID="so_idLabel" runat="server" Text='<%# Eval("so_id") %>' />
                        </td>
                        <td>
                            <asp:Label ID="so_noLabel" runat="server" Text='<%# Eval("so_no") %>' />
                        </td>
                        <td>
                            <asp:Label ID="so_dateLabel" runat="server" Text='<%# Eval("so_date") %>' />
                        </td>
                        <td>
                            <asp:Label ID="packageLabel" runat="server" Text='<%# Eval("package") %>' />
                        </td>
                        <td>
                            <asp:Label ID="doc_nameLabel" runat="server" Text='<%# Eval("doc_name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="issued_dateLabel" runat="server" 
                                Text='<%# Eval("issued_date") %>' />
                        </td>
                        <td>
                            <asp:Label ID="issued_toLabel" runat="server" Text='<%# Eval("issued_to") %>' />
                        </td>
                        <td>
                            <asp:Label ID="remarksLabel" runat="server" Text='<%# Eval("remarks") %>' />
                        </td>
                        <td>
                            <asp:Label ID="commentLabel" runat="server" Text='<%# Eval("comment") %>' />
                        </td>
                        <td>
                            <asp:Label ID="responseLabel" runat="server" Text='<%# Eval("response") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>--%>
                            <%-- <asp:GridView ID="mygrid_dr" runat="server" AutoGenerateColumns="False" 
                        onrowdatabound="mygrid_dr_RowDataBound" Width="100%" ShowHeader="False" 
                        onrowcommand="mygrid_dr_RowCommand" 
                    onselectedindexchanged="mygrid_dr_SelectedIndexChanged">
                    <Columns>
                    <asp:ButtonField ButtonType="Button" DataTextField="so_no" CommandName="get" >
                        <ItemStyle Width="6%" HorizontalAlign="Center" />
                        </asp:ButtonField>
                    <asp:BoundField DataField="package" >
                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                        </asp:BoundField>
                    <asp:BoundField DataField="doc_name" >
                        <ItemStyle Width="15%" />
                        </asp:BoundField>
                    <asp:BoundField DataField="issued_date" DataFormatString="{0:dd/MM/yyyy}" >
                        <ItemStyle Width="7%" HorizontalAlign="Center" />
                        </asp:BoundField>
                    <asp:BoundField DataField="userid" >
                        <ItemStyle Width="16%" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="issued" >
                        <ItemStyle Width="16%" HorizontalAlign="Center" />
                        </asp:BoundField>
                    <asp:BoundField DataField="comment" >
                        <ItemStyle Width="6%" HorizontalAlign="Center" />
                        </asp:BoundField>
                    <asp:BoundField DataField="response" >
                        <ItemStyle Width="6%" HorizontalAlign="Center" />
                        </asp:BoundField>
                    <asp:BoundField DataField="drstatus" >
                        <ItemStyle Width="6%" HorizontalAlign="Center" />
                        </asp:BoundField>
                     <asp:BoundField  DataField="due">
                        <ItemStyle Width="6%" HorizontalAlign="Center" />
                        </asp:BoundField>    
                    <asp:ButtonField ButtonType="Button" Text="Edit" CommandName="status" >
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:ButtonField>
                    <asp:BoundField DataField="so_no" />
                    <asp:BoundField DataField="so_id" />
                    <asp:BoundField DataField="issued_to" />
                    <asp:BoundField DataField="uid" />
                    </Columns>
                    </asp:GridView>--%>
                            <asp:Repeater ID="Rptlist" runat="server" OnItemCommand="Rptlist_ItemCommand" OnItemDataBound="Rptlist_ItemDataBound">
                                <HeaderTemplate>
                                    <thead>
                                        <table border="1" style="border-collapse: collapse; border-color: #999999; border-style: none;
                                            border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" width="100%">
                                            <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat;">
                                                <td style="width: 6%; height: 30px" align="center">
                                                    SO.NO
                                                </td>
                                                <td style="width: 9%" align="center">
                                                    SERVICE
                                                </td>
                                                <td style="width: 15%" align="center">
                                                    SUBJECT
                                                </td>
                                                <td style="width: 7%" align="center">
                                                    ISSUED DATE
                                                </td>
                                                <td style="width: 11%" align="center">
                                                    REVIEWED BY
                                                </td>
                                                <td style="width: 11%" align="center">
                                                    ISSUED TO
                                                </td>
                                                <td style="width: 6%" align="center">
                                                    COMMENTS
                                                </td>
                                                <td style="width: 6%" align="center">
                                                    RESPONSE
                                                </td>
                                                <td style="width: 6%" align="center" id="td1" runat="server">
                                                    CLOSED
                                                </td>
                                                <td style="width: 6%" align="center">
                                                    STATUS
                                                </td>
                                                <td style="width: 7%" align="center" id="td_1" runat="server">
                                                    CLOSE-OUT DATE
                                                </td>
                                                <td style="width: 6%" align="center">
                                                    OVER DUE (days)
                                                </td>
                                                <td style="width: 5%" align="center">
                                                </td>
                                            </tr>
                                            <tr style="background-color: #092443">
                                                <td align="center" style="width: 6%;">
                                                    &nbsp;
                                                </td>
                                                <td align="center" style="width: 9%">
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="dr_service" runat="server" Width="100%" AutoPostBack="true"
                                                                OnSelectedIndexChanged="dr_service_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="center" style="width: 15%">
                                                    &nbsp;
                                                </td>
                                                <td align="center" style="width: 7%">
                                                    &nbsp;
                                                </td>
                                                <td align="center" style="width: 11%">
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="drreview" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="drreview_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="center" style="width: 11%">
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="drissue" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="drissue_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="center" style="width: 6%">
                                                    &nbsp;
                                                </td>
                                                <td align="center" style="width: 6%">
                                                    &nbsp;
                                                </td>
                                                <td align="center" style="width: 6%" id="td2" runat="server">
                                                    &nbsp;
                                                </td>
                                                <td align="center" style="width: 6%">
                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="drstatus" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="drstatus_SelectedIndexChanged">
                                                                <%--<asp:ListItem Text="All" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="OPEN" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="CLOSED" Value="2"></asp:ListItem>--%>
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="center" style="width: 7%" id="td_2" runat="server">
                                                    &nbsp;
                                                </td>
                                                <td align="center" style="width: 6%">
                                                    &nbsp;
                                                </td>
                                                <td align="center" style="width: 5%">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                    </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr id="trow" runat="server">
                                        <td style="width: 6%; height: 30px" align="center">
                                            <asp:Button ID="btnso" runat="server" Text='<%#Eval("so_no") %>' CommandName="get" />
                                            <asp:Label ID="lblsono" runat="server" Text='<%#Eval("so_no") %>' Style="display: none"></asp:Label>
                                            <asp:Label ID="lblsoid" runat="server" Text='<%#Eval("so_id") %>' Style="display: none"></asp:Label>
                                            <asp:Label ID="lblcreated" runat="server" Text='<%#Eval("uid") %>' Style="display: none"></asp:Label>
                                            <asp:Label ID="lblissued" runat="server" Text='<%#Eval("issued_to") %>' Style="display: none"></asp:Label>
                                        </td>
                                        <td style="width: 9%" align="center">
                                            <asp:Label ID="lblpkg" runat="server" Text='<%#Eval("package") %>'></asp:Label>
                                        </td>
                                        <td style="width: 15%" align="center">
                                            <asp:Label ID="lbldoc" runat="server" Text='<%#Eval("doc_name") %>'></asp:Label>
                                        </td>
                                        <td style="width: 7%" align="center">
                                            <%#Eval("issued_date")%>
                                        </td>
                                        <td style="width: 11%" align="center">
                                            <%#Eval("userid")%>
                                        </td>
                                        <td style="width: 11%" align="center">
                                            <%#Eval("issued")%>
                                        </td>
                                        <td style="width: 6%" align="center">
                                            <%#Eval("comment")%>
                                        </td>
                                        <td style="width: 6%" align="center">
                                            <%#Eval("response")%>
                                        </td>
                                        <td style="width: 6%" align="center" id="td3" runat="server">
                                            <%#Eval("closed")%>
                                        </td>
                                        <td style="width: 6%" align="center">
                                            <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("drstatus") %>'></asp:Label>
                                        </td>
                                        <td style="width: 7%" align="center" id="td_3" runat="server">
                                            <asp:Label ID="lblcloseoutdate" runat="server" Text='<%#Eval("Closeout_Date") %>'></asp:Label>
                                        </td>
                                        <td style="width: 6%" align="center">
                                            <asp:Label ID="lbldue" runat="server" Text='<%#Eval("due") %>'></asp:Label>
                                        </td>
                                        <td style="width: 5%" align="center" id="td4" runat="server">
                                            <asp:Button ID="Button1" runat="server" Text="Edit" CommandName="status" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dbCMLConnectionString %>"
                        SelectCommand="load_so_dir" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="Project_code" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <asp:Panel ID="pnlPopup" runat="server" Width="300px" Style="display: none;">
                    <asp:Label ID="Label1" runat="server" Font-Names="verdana" Font-Size="Medium" ForeColor="White"></asp:Label>
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; background-color: White"
                        id="tblPopup">
                        <tr>
                            <td class="heading" style="background-image: url('images/headingbg_13.gif'); background-repeat: repeat-x;">
                                Select users to send notification!
                            </td>
                        </tr>
                        <tr>
                            <td align="left" height="75px" valign="middle" bgcolor="White">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBoxList ID="chkuser" runat="server" BackColor="White" Width="100%" Height="75px"
                                            BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px">
                                        </asp:CheckBoxList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="footer" height="30px">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnCont" runat="server" Text="Continue" OnClick="btnCont_Click" /><asp:Button
                                            ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                     <div id="myprogress" runat="server" style="position: absolute; z-index: 40; top: 50%; left: 50%">
                                            <asp:Image ID="myimage" runat="server" ImageUrl="~/images/loading30.gif" />
                                            </div>
                                            </ProgressTemplate>
                                    </asp:UpdateProgress>--%>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Button ID="btnDummy" runat="server" Text="Button" Style="display: none;" />
                <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" TargetControlID="btnDummy"
                    PopupControlID="pnlPopup" BackgroundCssClass="modal">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlPopup1" runat="server" Style="width: 430px; height:auto;min-height:250px;background-color: #ECE1C3;
                    border: solid 2px #063940;">
                    <div style="height: 20px; padding: 5px 10px; font-size: 17px; font-weight: bold;
                        background-color: #063940; color: #ECE1C3; text-align: left">
                        
                        <div style="float:left">
                            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                            <ContentTemplate>
                            <asp:Label ID="lblheadtitle" runat="server" Text=""></asp:Label>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <%--<div style="float:right;display:inline;">
                        X
                        </div>--%>
                    </div>
                    <div style="padding: 10px">
                        <table border="0" cellpadding="0" cellspacing="5" style="font-size:13px;">
                            <tr>
                                <td style="width: 100px">
                                    Service 
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="sopackage_edit" runat="server" Width="150px">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    Subject
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txt_subject" runat="server" Width="300px" TextMode="MultiLine" Height="75px"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="middle" width="100PX">
                                    Status
                                </td>
                                <td align="left" valign="middle">
                                    <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="sostatus1" runat="server" Width="150px" 
                                                AutoPostBack="true" onselectedindexchanged="sostatus1_SelectedIndexChanged" >
                                                <asp:ListItem Text="OPEN" Value="OPEN"></asp:ListItem>
                                                <asp:ListItem Text="CLOSED" Value="CLOSED"></asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr id="trcdate" runat="server">
                                <td align="left" valign="middle" width="100PX">
                                    Close-Out Date
                                </td>
                                <td >
                                    <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                    <ContentTemplate>
                                    <asp:TextBox ID="txt_closeout" runat="server" Width="125px"></asp:TextBox>&nbsp;<a id="calendar_popup" runat="server" href="#" style="color:#353535;font-size:18px;" ><i class="fa fa-calendar"></i>
</a>
                                    <asp:CalendarExtender ID="CalendarExtender13" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                        PopupButtonID="calendar_popup" TargetControlID="txt_closeout">
                                    </asp:CalendarExtender>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td height="20px" colspan="2" align="center">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="Label2" runat="server" Text="" Style="display: none"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                           
                        </table>
                    </div>
                    <div style="padding:5px 0px; font-size: 17px; font-weight: bold; background-color: #063940; color: #ECE1C3; text-align: right;bottom:0;position:relative;" >
                    
                        <table width="100%">
                        <tr>
                        <td align="right" colspan="2" style="padding-right:10px">
                        <div style="float:right">
                        <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnupdate" runat="server" Height="25px" OnClick="btnupdate_Click"
                                                Text="Update" />&nbsp;
                                            <asp:Button ID="btncancel1" Height="25px" runat="server" OnClick="btncancel1_Click"
                                                Text="Cancel" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    </div>
                                </td>
                        </tr>
                        </table>
                        
                    </div>
                </asp:Panel>
                <%--  <asp:Panel ID="pnlPopup1" runat="server" Width="250px" Height="94px" style="padding:10px;background-color:White;display:none" >
                        <table border="0" cellpadding="0" cellspacing="0" style="background-color:White" id="Table1">
                            <tr>
                                <td align="left" bgcolor="White" valign="middle" width="100PX">
                                    &nbsp;</td>
                                <td align="left" bgcolor="White" valign="middle">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" bgcolor="White" valign="middle" width="100PX">
                                    STATUS</td>
                                <td align="left" bgcolor="White" valign="middle">
                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                    <ContentTemplate>
                                    <asp:DropDownList ID="sostatus1" runat="server" Width="150px">
                                        <asp:ListItem Text="OPEN" Value="OPEN"></asp:ListItem>
                                        <asp:ListItem Text="CLOSED" Value="CLOSED"></asp:ListItem>
                                    </asp:DropDownList>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td class="footer" height="30px" colspan="2" align="center" >
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" class="footer" colspan="2" height="30px">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnupdate" runat="server" Height="26px" 
                                                onclick="btnupdate_Click" Text="Update" />
                                            <asp:Button ID="btncancel1" runat="server" onclick="btncancel1_Click" 
                                                Text="Cancel" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                       </table>
                  </asp:Panel>--%>
                <asp:Button ID="btnDummy1" runat="server" Text="Button" Style="display: none;" />
                <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender1" runat="server" TargetControlID="btnDummy1"
                    PopupControlID="pnlPopup1" BackgroundCssClass="modal">
                </asp:ModalPopupExtender>
            
        </div>
    </div>
    </form>
</body>
</html>
