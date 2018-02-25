<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ms12761.aspx.cs" Inherits="CmlTechniques.CMS.ms12761" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
        <link href="../page.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript">
            function calldoc(type, id, file) {
                var _prj = document.getElementById("lblprj");
                if (type == 1) {

                    var path = "viewdoc.aspx?prj=" + _prj.textContent + "&doc=" + id;
                    parent.callcms(path, '10');
                }
                else if (type == 0) {
                    var prm = "prj=" + _prj.textContent + "&mode=MS&doc=" + id;
                    //Session["viewmode"] = "CP";
                    parent.callcms(prm, '5');
                }
                else if (type == 2) {
                    var mode = document.getElementById("phead");
                    var rep_mode = mode.textContent.replace("&", "^");
                    var prm = id + "_M" + rep_mode + "_T1";
                    var _url = "ViewComments.aspx?id=" + prm;
                    window.open(_url, '', 'left=50,top=100,width=1200,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');
                }
                else if (type == 3) {
                    var mode = document.getElementById("phead");
                    var rep_mode = mode.textContent.replace("&", "^");
                    var prm = id + "_M" + rep_mode + "_T2";
                    var _url = "ViewComments.aspx?id=" + prm;
                    window.open(_url, '', 'left=50,top=100,width=1200,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');
                }
                else if (type == 4) {
                    var mode = document.getElementById("phead");
                    var rep_mode = mode.textContent.replace("&", "^");
                    var prm = id + "_M" + rep_mode + "_T3";
                    var _url = "ViewComments.aspx?id=" + prm;
                    window.open(_url, '', 'left=50,top=100,width=1200,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');
                }
                else if (type == 5) {
                    var mode = document.getElementById("phead");
                    var rep_mode = mode.textContent.replace("&", "^");
                    var prm = id + "_M" + rep_mode + "_T4";
                    var _url = "ViewComments.aspx?id=" + prm;
                    window.open(_url, '', 'left=50,top=100,width=1200,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');
                }
            }
            function showpopup() {
                var _pop = document.getElementById("Button5");
                _pop.click();
            }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:Label ID="lblprj" runat="server" Text="" Style="display: none"></asp:Label>
    <asp:Label ID="lblmsid" runat="server" Text="" Style="display: none"></asp:Label>
     <div id="doc_list">
        <div class="title">
            <asp:Label ID="phead" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
            <div class="back"><a href="#" class="lnkbtn" onclick="showpopup();">Info</a></div>
        </div>
        <div class="info">
            <asp:Label ID="lbltitle" runat="server" Text="Latest Version of the Method Statement"></asp:Label>
            <div class="right">
            <asp:Label ID="lblinfo" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Repeater ID="rpt_latest" runat="server" 
                    OnItemCommand="rpt_latest_ItemCommand" 
                    onitemdatabound="rpt_latest_ItemDataBound">
                    <HeaderTemplate>
                        <table class="tablestyle" width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr class="head">
                                <td style="width: 40%;" align="left">
                                    Document Name
                                </td>
                                <td style="width: 10%" align="center">
                                    Submission Date
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
                                    <asp:Label ID="lbldocid" runat="server" Text='<%# Eval("doc_id")%>' style="display:none"></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="seperator">
        </div>
        <div class="info">
            History - Previous Versions</div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
         <asp:Repeater ID="rpt_history" runat="server" 
                OnItemCommand="rpt_history_ItemCommand" 
                onitemdatabound="rpt_history_ItemDataBound">
            <HeaderTemplate>
                <table class="tablestyle" width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr class="head">
                        <td style="width: 40%;" align="left">
                            Document Name
                        </td>
                        <td style="width: 10%" align="center">
                            Submission Date
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
                                    <a href="#" class="lnkbtn" onclick="calldoc(4,'<%#Eval("doc_id") %>','<%#Eval("file_name") %>');">
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
                                    <a href="#" class="lnkbtn" onclick="calldoc(5,'<%#Eval("doc_id") %>','<%#Eval("file_name") %>');">
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
                            <asp:Label ID="lbldocid" runat="server" Text='<%# Eval("doc_id")%>' style="display:none"></asp:Label>
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
    
    <%--<asp:UpdatePanel ID="ddddd" runat="server">
        <ContentTemplate>--%>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1"
                TargetControlID="lblqns" BackgroundCssClass="pop_back">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel1" runat="server" Style="display: none; width: 200px; background-color: White;
                border-width: 2px; border-color: Black; border-style: solid; padding: 20px;">
                <asp:Label ID="lblitmid" Text="0" runat="server" style="display:none"></asp:Label>
                <asp:Label ID="lblqns" Text="" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Button ID="Button3" runat="server" Text="OK" OnClick="Delete_Click" />
                <asp:Button ID="Button4" runat="server" Text="Cancel" />
            </asp:Panel>
            <asp:Button ID="Button5" runat="server" Text="Button" style="display:none" />
            <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel2"
                TargetControlID="Button5" BackgroundCssClass="pop_back" >
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel2" runat="server" Style="width:330px;height:290px;display:none;color:#ffffff;">
                <div class="pop-box">
                <div class="pop-head">
                <asp:Label ID="lblhead" runat="server" Text="Update Information" ForeColor="White" Font-Size="Large"></asp:Label>
            </div>
            <div style="padding:10px">
             <table style="width:100%">
                <tr>
                <td>Planned Submission Date</td>
                <td>
                    <asp:TextBox ID="txt_sdate" runat="server" Width="95px" CssClass="comment-text"></asp:TextBox>
                    <asp:CalendarExtender ID="date6_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_sdate" 
                                TargetControlID="txt_sdate">
                            </asp:CalendarExtender>
                    </td>
                </tr>
                <tr>
                
                <td>Reviewed by CML</td>
                <td>
                    <asp:DropDownList ID="drrevcml" runat="server" CssClass="comment-text" Width="100px">
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                    <asp:ListItem Text="No" Value="2" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td>Reviewed Date</td>
                <td>
                    <asp:TextBox ID="txt_rdate" runat="server" Width="95px" CssClass="comment-text"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_rdate" 
                                TargetControlID="txt_rdate">
                            </asp:CalendarExtender>
                    </td>
                </tr>
                <tr>
                <tr>
                <td>Issued with BHC</td>
                <td>
                    <asp:DropDownList ID="drissuedbhc" runat="server" CssClass="comment-text" Width="100px">
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                    <asp:ListItem Text="No" Value="2" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td>
                <table>
                <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnupdate" runat="server" Text="Save" CssClass="comment-btn" Width="75px" OnClick="btnupdate_Click" />
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="comment-btn" Width="75px" OnClick="btncancel_Click" />
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                </tr>
                </table>
                </td>
                <td>
                
                </td>
                </tr>
                </table>
            </div>
               
                </div>
            </asp:Panel>
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    
    </form>
</body>
</html>
