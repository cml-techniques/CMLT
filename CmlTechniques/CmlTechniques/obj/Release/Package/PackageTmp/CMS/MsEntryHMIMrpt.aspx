<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MsEntryHMIMrpt.aspx.cs" Inherits="CmlTechniques.CMS.MsEntryHMIMrpt" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Assets/css/Style.css" rel="stylesheet" type="text/css" />
    <link href="../Assets/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .RadDropDownList_Metro .rddlInner
        {
            /*border-color: #D4D4D4 !important;*/
            border-radius: 4px !important;
            background-image: none !important;
            border: none !important;
            font-size: 14px;
            font-weight: bold;
            padding: 5px !important;
            height: 30px !important;
          background-color:transparent!important;
        }
        .RadDropDownList_Metro .rddlInner
        {
            font-weight: 600 !important;
            color: black !important;
        }
        .RadDropDownList_Metro .rddlIcon
        {
            margin-top: 3px !important;
            margin-right: 3px !important;
            height: 20px !important;
            width: 20px !important;
        }
    </style>
    <script type="text/javascript">
        function loadms(_id)
        {
        parent.document.getElementById("content").src = "methodstatements1.aspx?id=" + _id;
        } 
    </script>
</head>
<body style="overflow:hidden">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
    </asp:ScriptManager>
    <asp:Label ID="lblprj" runat="server" Text="Label" Style="display: none"></asp:Label>
    <asp:Label ID="lbluser" runat="server" Text="Label" Style="display: none"></asp:Label>
    <asp:Label ID="lblsch" runat="server" Text="Label" Style="display: none"></asp:Label>
      <asp:Label ID="lblid" runat="server" Text="Label" Style="display: none"></asp:Label>
    
       <div class="fixedhead">
                <div id="infobar">
                    <div class="prjinfo">
                        <div class="pullleft font-big">
                             CMS : Method Statement
                            <asp:Label ID="prj" runat="server" Style="color: #e6422c"></asp:Label></div>
                        <div class="pullright font-big">
                            <asp:Label ID="package" runat="server" Style="color: #e6422c"></asp:Label>
                        </div>
                    </div>
                </div>
    </div>
    

    <telerik:RadWindow ID="RadWindow1" runat="server" Modal="true" BorderStyle="None"
        Title="CMS | METHOD STATEMENTS" EnableShadow="true" Behaviors="Close, Move"
        VisibleStatusbar="false" Skin="Metro" Width="500px" Height="180px">
        <ContentTemplate>
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <table cellpadding="5">
                        <tr>
                            <td style="width:150px">
                                Select Building
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <telerik:RadDropDownList ID="rd_Building" runat="server" 
                                            Skin="Metro" RenderMode="Lightweight" DefaultMessage="Select Building" Width="350px"
                                            AutoPostBack="true">
                                            <%--<Items>
                                            <telerik:DropDownListItem Text="Haram/Piazza" Value="1" />
                                             <telerik:DropDownListItem Text="Service Building" Value="2" />
                                              <telerik:DropDownListItem Text="CUC/T4" Value="3" />
                                            </Items>--%>
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
 
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Silk">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadNotification ID="RadNotification1" runat="server" Text="YOU HAVE NO PERMISSION TO ACCESS THIS BUILDING" Title="Message" Position="Center" Animation="Fade" AutoCloseDelay="800" >
    </telerik:RadNotification>
    </form>

    <script src="../Assets/js/jquery.min.js" type="text/javascript"></script>
 
</body>
</html>

