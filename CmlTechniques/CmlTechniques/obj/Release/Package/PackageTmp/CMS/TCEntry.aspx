<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TCEntry.aspx.cs" Inherits="CmlTechniques.CMS.TCEntry" %>


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
        .dvCenter
        {
        	width:250px;
        	margin-left:auto;
        	margin-right:auto;  
        	background-color:Olive;
        }
    </style>
    <script type="text/javascript">
        function loadtc(_id)
        {
        parent.document.getElementById("content").src = "../tcdocumentation.aspx?id=" + _id;
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
      <asp:Label ID="lbldiv" runat="server" Text="Label" Style="display: none"></asp:Label>
       <asp:Label ID="lblpermission" runat="server" Text="Label" Style="display: none"></asp:Label>
      
    
       <div class="fixedhead">
                <div id="infobar">
                    <div class="prjinfo">
                        <div class="pullleft font-big">
                             CMS : T & C Documentation
                            <asp:Label ID="prj" runat="server" Style="color: #e6422c"></asp:Label></div>
                        <div class="pullright font-big">
                            <asp:Label ID="package" runat="server" Style="color: #e6422c"></asp:Label>
                        </div>
                    </div>
                </div>
    </div>
    

    <telerik:RadWindow ID="RadWindow1" runat="server" Modal="true" BorderStyle="None"
        Title="CMS | Holy Mosque in Makkah Expansion" EnableShadow="true" Behaviors="Close, Move"
        VisibleStatusbar="false" Skin="Metro" Width="380px" Height="200px">
        <ContentTemplate>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table cellpadding="5">
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                       <asp:RadioButtonList ID="rdbuilding" runat="server" >
                                        <asp:ListItem Value="1" Text="CENTRAL UTILITY CENTRE" Selected="True"></asp:ListItem>
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
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
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
        Title="CMS | Makkah Expansion Hospital & Security Buildings" EnableShadow="true" Behaviors="Close, Move"
        VisibleStatusbar="false" Skin="Metro" Width="380px" Height="175px">
        <ContentTemplate>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <table cellpadding="5">
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                       <asp:RadioButtonList ID="rdbuilding2" runat="server" >   
                                        <asp:ListItem Value="1" Text="HOSPITAL BUILDING" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="P1 SECURITY BUILDING"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="RING ROAD"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" LoadingPanelID="RadAjaxLoadingPanel1"
                                            Width="100px">
                                            <asp:Button ID="btnenter2" runat="server" CssClass="submitbtn" Text="ENTER" OnClick="btnenter2_Click" />
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
    
     <telerik:RadWindow ID="RadWindow3" runat="server" Modal="true" BorderStyle="None"
        Title="CMS | King Abdulaziz International Airport" EnableShadow="true" Behaviors="Close, Move"
        VisibleStatusbar="false" Skin="Metro" Width="500px" Height="270px">
        <ContentTemplate>
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                    <table cellpadding="5">
                        <tr>
                            <td style="width:150px">
                                Select Package
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
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
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
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
                            <td style="width:150px">
                                Select Service
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                    <ContentTemplate>
                                        <telerik:RadDropDownList ID="rd_service" runat="server" OnSelectedIndexChanged="rd_service_SelectedIndexChanged"
                                            Skin="Metro" RenderMode="Lightweight" DefaultMessage="Select Service" Width="350px"
                                            AutoPostBack="true">
                                        </telerik:RadDropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Select CAS Sheet
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                    <ContentTemplate>
                                        <telerik:RadDropDownList ID="rd_Casheet" runat="server" Skin="Metro" RenderMode="Lightweight"
                                            DefaultMessage="Select CAS Sheet" Width="350px" AutoPostBack="true" DropDownHeight="200px"
                                            OnSelectedIndexChanged="rd_Casheet_SelectedIndexChanged">
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
                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                    <ContentTemplate>
                                        <telerik:RadAjaxPanel ID="RadAjaxPanel3" runat="server" LoadingPanelID="RadAjaxLoadingPanel1"
                                            Width="100px">
                                            <asp:Button ID="btnenter3" runat="server" CssClass="submitbtn" Text="ENTER" OnClick="btnenter3_Click" />
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

