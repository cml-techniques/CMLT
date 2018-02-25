<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cplans.aspx.cs" Inherits="CmlTechniques.CMS.cplans" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        .RadWindow .rwDialogPopup
        {
        	box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.5); 
        }
    </style>

    <script type="text/javascript">
        function calldoc(type, id, file) {
            var _prj = document.getElementById("lblprj");
            if (type == 1) {

                var path = "viewdoc.aspx?prj=" + _prj.textContent + "&doc=" + id;
                parent.callcms(path, '10');
            }
            else if (type == 0) {
                var mode = document.getElementById("phead");
                if (mode.textContent == "Commissioning Plan") {
                    var prm = "prj=" + _prj.textContent + "&mode=CP&doc=" + id;
                    parent.callcms(prm, '5');
                }
                else if (mode.textContent == "Commissioning Report") {
                    var prm = "prj=" + _prj.textContent + "&mode=CR&doc=" + id;
                    parent.callcms(prm, '5');
                }
            }
            else if (type == 2) {
                var mode = document.getElementById("phead");
                var prm = id + "_M" + mode.textContent + "_T1";
                var _url = "ViewComments.aspx?id=" + prm;
                window.open(_url, '', 'left=50,top=100,width=1200,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');
            }
            else if (type == 3) {
                var mode = document.getElementById("phead");
                var prm = id + "_M" + mode.textContent + "_T2";
                var _url = "ViewComments.aspx?id=" + prm;
                window.open(_url, '', 'left=50,top=100,width=1200,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');
            }
        }
    
    
    </script>

    <script type="text/javascript">
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

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
    </asp:ScriptManager>
    <asp:Label ID="lblprj" runat="server" Text="Label" Style="display: none"></asp:Label>
    <asp:Label ID="facid" runat="server" Text="Label" Style="display: none"></asp:Label>
    <asp:Label ID="lbluser" runat="server" Text="Label" Style="display: none"></asp:Label>
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
                    <asp:Label ID="phead" runat="server"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="fixedcontent">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="doc_list" runat="server">
                    <div class="info">
                        <asp:Label ID="lbltitle" runat="server" Text="Label"></asp:Label>
                    </div>
                    <asp:Repeater ID="rpt_latest" runat="server" OnItemCommand="rpt_latest_ItemCommand"
                        OnItemDataBound="rpt_latest_ItemDataBound">
                        <HeaderTemplate>
                            <table class="tablestyle" width="100%" cellpadding="0" cellspacing="0" border="0">
                                <tr class="head">
                                    <td style="width: 40%;" align="left">
                                        Document Name
                                    </td>
                                    <td style="width: 10%" align="center">
                                        Upload Date
                                    </td>
                                    <td style="width: 10%" align="center">
                                        Revision
                                    </td>
                                    <td style="width: 12%" align="center">
                                        Total Comments
                                    </td>
                                    <td style="width: 12%" align="center">
                                        Outstanding Comments
                                    </td>
                                    <td style="width: 12%" align="center">
                                        Status
                                    </td>
                                    <td style="width: 4%" align="center" id="tdHistory" runat="server">
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="row">
                                <td style="width: 40%;" align="left">
                                    <a href="#" onclick="calldoc(0,'<%#Eval("doc_id") %>','<%#Eval("file_name") %>');">
                                        <%# DataBinder.Eval(Container.DataItem, "doc_name")%></a>
                                </td>
                                <td style="width: 10%" align="center">
                                    <%# Eval("upload_date","{0:dd-MM-yyyy}") %>
                                </td>
                                <td style="width: 10%" align="center">
                                    <asp:Label ID="lblversion" runat="server" Text='<%# Eval("Version")%>'></asp:Label>
                                </td>
                                <td style="width: 12%" align="center">
                                    <table class="tablestyle_inner">
                                        <tr>
                                            <td style="width: 50%; text-align: right;">
                                                <asp:Label ID="lblcmnt" runat="server" Text='<%# Eval("Comments")%>'></asp:Label>
                                            </td>
                                            <td style="width: 50%; text-align: center;">
                                                <a href="#" class="lnkbtn" onclick="calldoc(2,'<%#Eval("doc_id") %>','<%#Eval("file_name") %>');">
                                                    View</a>
                                                <%-- <asp:Button ID="Button5" runat="server" CssClass="lnkbtn" Text="View" OnClientClick="calldoc(2,'<%#Eval("doc_id") %>','<%#Eval("file_name") %>');" />--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 12%" align="center">
                                    <table class="tablestyle_inner">
                                        <tr>
                                            <td style="width: 50%; text-align: right;">
                                                <%# Eval("outstanding")%>
                                            </td>
                                            <td style="width: 50%; text-align: center;">
                                                <a href="#" class="lnkbtn" onclick="calldoc(3,'<%#Eval("doc_id") %>','<%#Eval("file_name") %>');">
                                                    View</a>
                                                <%--<asp:Button ID="Button6" runat="server" CssClass="lnkbtn" Text="View" OnClientClick="calldoc(3,'<%#Eval("doc_id") %>','<%#Eval("file_name") %>');" />--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 12%" align="center">
                                    <%# Eval("doc_status")%>
                                </td>
                                <td style="width: 4%" align="center" id="tdHistory" runat="server">
                                    <asp:ImageButton ID="btnbutton" runat="server" ImageUrl="~/images/delete_.png" CommandName="delete1"
                                        CommandArgument='<%# Container.ItemIndex %>' />
                                    <asp:Label ID="lbldocid" runat="server" Text='<%# Eval("doc_id")%>' Style="display: none"></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <div class="seperator">
                    </div>
                    <div class="info">
                        History - Previous Versions</div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Repeater ID="rpt_history" runat="server" OnItemCommand="rpt_history_ItemCommand"
                                OnItemDataBound="rpt_history_ItemDataBound">
                                <HeaderTemplate>
                                    <table class="tablestyle" width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr class="head">
                                            <td style="width: 40%;" align="left">
                                                Document Name
                                            </td>
                                            <td style="width: 10%" align="center">
                                                Upload Date
                                            </td>
                                            <td style="width: 10%" align="center">
                                                Revision
                                            </td>
                                            <td style="width: 12%" align="center">
                                                Total Comments
                                            </td>
                                            <td style="width: 12%" align="center">
                                                Outstanding Comments
                                            </td>
                                            <td style="width: 12%" align="center">
                                                Status
                                            </td>
                                            <td style="width: 4%" align="center" id="tdHistory" runat="server">
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr class="row">
                                        <td style="width: 40%;" align="left">
                                            <a href="#" onclick="calldoc(1,'<%#Eval("doc_id") %>','<%#Eval("file_name") %>');">
                                                <%# DataBinder.Eval(Container.DataItem, "doc_name")%></a>
                                        </td>
                                        <td style="width: 10%" align="center">
                                            <%# Eval("upload_date","{0:dd-MM-yyyy}") %>
                                        </td>
                                        <td style="width: 10%" align="center">
                                            <asp:Label ID="lblversion" runat="server" Text='<%# Eval("Version")%>'></asp:Label>
                                        </td>
                                        <td style="width: 12%" align="center">
                                            <table class="tablestyle_inner">
                                                <tr>
                                                    <td style="width: 50%; text-align: right;">
                                                        <asp:Label ID="lblcmnt" runat="server" Text='<%# Eval("Comments")%>'></asp:Label>
                                                    </td>
                                                    <td style="width: 50%; text-align: center;">
                                                        <a href="#" class="lnkbtn" onclick="calldoc(2,'<%#Eval("doc_id") %>','<%#Eval("file_name") %>');">
                                                            View</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 12%" align="center">
                                            <table class="tablestyle_inner">
                                                <tr>
                                                    <td style="width: 50%; text-align: right;">
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("outstanding")%>'></asp:Label>
                                                    </td>
                                                    <td style="width: 50%; text-align: center;">
                                                        <a href="#" class="lnkbtn" onclick="calldoc(3,'<%#Eval("doc_id") %>','<%#Eval("file_name") %>');">
                                                            View</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 12%" align="center">
                                            <%# Eval("doc_status")%>
                                        </td>
                                        <td style="width: 4%" align="center" id="tdHistory" runat="server">
                                            <asp:ImageButton ID="btnbutton" runat="server" ImageUrl="~/images/delete_.png" CommandName="delete1"
                                                CommandArgument='<%# Container.ItemIndex %>' />
                                            <asp:Label ID="lbldocid" runat="server" Text='<%# Eval("doc_id")%>' Style="display: none"></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <telerik:RadWindow ID="RadWindow1" runat="server" Modal="true" BorderStyle="None"
        Title="CMS | King Abdulaziz International Airport" EnableShadow="true" Behaviors="Close, Move"
        VisibleStatusbar="false" Skin="Metro" Width="500px" Height="185px">
        <ContentTemplate>
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <table cellpadding="5">
                        <tr>
                            <td style="width:150px">
                                Select Package
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <telerik:RadDropDownList ID="rd_package" runat="server" OnSelectedIndexChanged="rd_package_SelectedIndexChanged"
                                            Skin="Metro" RenderMode="Lightweight" DefaultMessage="Select Package" Width="350px"
                                            AutoPostBack="true">
                                        </telerik:RadDropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Select Facility
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <telerik:RadDropDownList ID="rd_facility" runat="server" Skin="Metro" RenderMode="Lightweight"
                                            DefaultMessage="Select Facility" Width="350px" DropDownHeight="200px" AutoPostBack="true"
                                            OnSelectedIndexChanged="rd_facility_SelectedIndexChanged">
                                        </telerik:RadDropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>
                                        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1"
                                            Width="100px">
                                            <asp:Button ID="btnenter" runat="server" CssClass="submitbtn" Text="ENTER" OnClick="btnenter_Click" />
                                        </telerik:RadAjaxPanel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </telerik:RadWindow>
    <telerik:RadWindow ID="RadWindow2" runat="server" Modal="true" BorderStyle="None"
        Title="CMS | Holy Mosque in Makkah Expansion" EnableShadow="true" Behaviors="Close, Move"
        VisibleStatusbar="false" Skin="Metro" Width="370px" Height="210px" >
        <ContentTemplate>
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <table cellpadding="5">
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButtonList ID="rdbuilding" runat="server" OnSelectedIndexChanged="rdbuilding_SelectedIndexChanged"
                                            AutoPostBack="true">
                                            <asp:ListItem Value="1" Text="CENTRAL UTILITY CENTRE"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="PIAZZA"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="SERVICE BUILDING"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="HARAM"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                    <ContentTemplate>
                                        <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" LoadingPanelID="RadAjaxLoadingPanel1"
                                            Width="100px">
                                            <asp:Button ID="btnenter1" runat="server" CssClass="submitbtn" Text="ENTER" OnClick="btnenter1_Click" />
                                        </telerik:RadAjaxPanel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </telerik:RadWindow>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Silk">
    </telerik:RadAjaxLoadingPanel>
    </form>

    <script src="../Assets/js/jquery.min.js" type="text/javascript"></script>

</body>
</html>
