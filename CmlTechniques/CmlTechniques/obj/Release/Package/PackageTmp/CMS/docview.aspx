<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="docview.aspx.cs" Inherits="CmlTechniques.CMS.docview" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Document</title>

    <script type="text/javascript">

        function pageLoad() {
        }
    
    </script>

    <link href="../page.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Menu/styles.css" /> 
     <script type="text/javascript" src="../Menu/jquery.js"></script>
     <script type="text/javascript" src="../Menu/sliding_effect.js"></script>
    <style type="text/css">
        .style1
        {
            width: 8px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:Label ID="lblprjid" runat="server" Text="" Style="display: none"></asp:Label>
        <asp:Label ID="lblvmode" runat="server" Text="Label" Style="display: none"></asp:Label>
        <asp:Label ID="lblid" runat="server" Text="Label" Style="display: none"></asp:Label>
        <div id="comment_menu">
            <div class="menu">
                <input id="_logout" type="hidden" runat="server" />
                <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label>
                <%--<asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="Button1" name="Button1" runat="server" Text="Button" OnClick="Button1_Click"
                            Style="display: none" />
                    </ContentTemplate>
                </asp:UpdatePanel>--%>
                <div id="navigation-block">
                    <div>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/logo.JPG" Width="205px"
                            Height="120px" BorderStyle="None" /></div>
                    <ul id="sliding-navigation">
                        <li class="sliding-element"><a href="#" onclick="javascript:window.location.href='../home.aspx?id=0';">
                            HOME</a></li>
                        <li class="sliding-element"><a href="#" onclick="goback();">BACK</a></li>
                        <li class="sliding-element"><a href="#" onclick="javascript:window.open('http://cmlinternational.co.uk');">
                            CONTACT US</a></li>
                    </ul>
                </div>
            </div>
            <div class="comment_add" id="mydiv" runat="server">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;"
                            border="0" cellpadding="0" cellspacing="0">
                            <tr align="left">
                                <td width="90px" align="left">
                                    <asp:TextBox ID="txtpno" runat="server" Width="89px" Height="24px" CssClass="comment-text"
                                        placeholder="Page No."></asp:TextBox>
                                </td>
                                <td width="90px" align="right">
                                    <asp:TextBox ID="txtsno" runat="server" Width="89px" Height="24px" CssClass="comment-text"
                                        placeholder="Section No."></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px">
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:TextBox ID="txtcmnt" runat="server" Height="152px" Width="190px" TextMode="MultiLine"
                                        CssClass="comment-text" placeholder="Comment" Wrap="True" Style="text-align: left"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px">
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td width="90px" align="left">
                                    <asp:Button ID="cmdadd" runat="server" Height="30px" Width="95px" CssClass="comment-btn"
                                        Text="Save" OnClick="cmdadd_Click"  />
                                </td>
                                <td width="90px" align="right">
                                    <asp:Button ID="cmdexit" runat="server" Height="30px" Width="95px" CssClass="comment-btn"
                                        Text="Cancel"  />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <div id="mydiv1" runat="server">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="190px" style="font-family: Arial, Helvetica, sans-serif; font-size: small;
                                        color: #FFFFFF" align="left" valign="top">
                                        Change Doc.Status
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                        <asp:DropDownList ID="drstatus" runat="server" Height="25px" Width="190px" 
                                                CssClass="comment-text" AutoPostBack="true" 
                                                onselectedindexchanged="drstatus_SelectedIndexChanged">
                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="ACCEPTED" Value="A"></asp:ListItem>
                                            <asp:ListItem Text="ACCEPTED WITH COMMENTS" Value="B"></asp:ListItem>
                                            <asp:ListItem Text="REVIEW" Value="REVIEW"></asp:ListItem>
                                            <asp:ListItem Text="REJECTED" Value="C"></asp:ListItem>
                                        </asp:DropDownList>
                                        </ContentTemplate>
                                        </asp:UpdatePanel>
                                        
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div id="comment_doc">
            <iframe id="myframe" frameborder="0" height="100%" width="100%" runat="server"></iframe>
        </div>
        <div id="comment_basket">
            <div class="head">
                <asp:Label ID="lblhead" runat="server" Text="" ForeColor="White" Font-Size="Large"></asp:Label>
            </div>
            <div class="title">
                <asp:Label ID="lbstatus" runat="server" ForeColor="White"></asp:Label>
            </div>
            <div class="basket">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="mybasket" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None" Width="100%" Font-Names="verdana" Font-Size="10px"
                            OnRowDataBound="mybasket_RowDataBound" OnRowCommand="mybasket_RowCommand">
                            <RowStyle BackColor="#ECE1C3" ForeColor="#063940" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#3E838C" Font-Bold="True" ForeColor="White" Height="30px" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="#d8bfbf" ForeColor="#063940" />
                            <Columns>
                                <asp:BoundField DataField="page" HeaderText="Page">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sec" HeaderText="Section">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="comment" HeaderText="Comment">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Width="200px" />
                                </asp:BoundField>
                                <asp:ButtonField ButtonType="Image" ImageUrl="../images/delete_small.png" />
                                <asp:BoundField DataField="ID">
                                    <ItemStyle Width="5px" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="action">
                <table>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="cmdsave" runat="server" Height="30px" Text="Save & Exit" Width="140px"
                                        OnClick="cmdsave_Click" CssClass="comment-btn" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="cmdadd1" runat="server" Height="30px" Text="Exit without Saving"
                                        Width="140px" CssClass="comment-btn" OnClick="cmdadd1_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="comment_link">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnlink" runat="server" Text="VIEW ANOTHER DOCUMENT" OnClientClick="javascript:window.open('view_document.aspx','','left=210,top=0,bottom=0,width=1024, menubar=1,toolbar=0,scrollbars=1,status=1');"
                        CssClass="comment-text" Height="30px" Width="290px" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
     <script type="text/javascript">
    function goback()
    {
    var mode=document.getElementById('<%=lblvmode.ClientID%>').innerHTML;
    var lblprjid=document.getElementById('<%=lblprjid.ClientID%>').innerHTML;
    var url = "";
    
    if (mode!='CP' && mode!='MS')
    {
    mode='000'
    }
    else   if (lblprjid == "HMIM")
    {
         if (mode == "MS")
         {
             url = "CMS2.aspx?mod=MS&PRJ=" + lblprjid +"&id="+getQueryStringValue("id")+ "&Div="+ getQueryStringValue("Div");
         }
         else
         {
             url = "CMS2.aspx?mod=" + mode + "&PRJ=" + lblprjid;
         }
         window.location.href = url;  
     return;
     }
    else if (lblprjid == "ABS") {
        var url = "";
        if (mode == "MS") {
            url = "CMS.aspx?mod=MS&PRJ=" + lblprjid + "&id=" + getQueryStringValue("id") + "&Div=" + getQueryStringValue("Div");
        }
        else {
            url = "CMS.aspx?mod=" + mode + "&PRJ=" + lblprjid;
        }
        //window.location.href = "CMS.aspx?mod=MS&PRJ=HMIM&id=" + getQueryStringValue("id") + "&Div=" + getQueryStringValue("Div");
         window.location.href = url;
        return;
    }
     window.location.href='CMS.aspx?PRJ='+mode;    
     } 
           function getQueryStringValue (key) {  
  return unescape(window.location.search.replace(new RegExp("^(?:.*[&\\?]" + escape(key).replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));  
} 
    </script>
</body>
</html>
