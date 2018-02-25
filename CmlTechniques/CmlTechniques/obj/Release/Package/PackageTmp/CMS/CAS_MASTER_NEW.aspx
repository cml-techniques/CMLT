<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CAS_MASTER_NEW.aspx.cs"
    Inherits="CmlTechniques.CMS.CAS_MASTER_NEW" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    </style>
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
<body style="overflow:hidden">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
    </asp:ScriptManager>
    <asp:Label ID="lblprj" runat="server" Text="Label" Style="display: none"></asp:Label>
    <asp:Label ID="facid" runat="server" Text="Label" Style="display: none"></asp:Label>
    <asp:Label ID="lbluser" runat="server" Text="Label" Style="display: none"></asp:Label>
    <asp:Label ID="lblsch" runat="server" Text="Label" Style="display: none"></asp:Label>
    <asp:Label ID="lblpermission" runat="server" Text="Label" Style="display: none"></asp:Label>
    <div class="fixedhead">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
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
                <div id="menu" runat="server">
                    <ul class="menu">
                        <li id="m1" runat="server"><a href="#" onclick="MenuAction(1);">CAS SHEET ENTRY</a></li>
                        <li id="m2" runat="server"><a href="#" onclick="MenuAction(2);">COMMISSIONING &amp; TESTING</a></li>
                        <li id="m3" runat="server"><a href="#" onclick="MenuAction(3);">FULL SCHEDULE</a></li>
                        <li id="m4" runat="server"><a href="#" onclick="MenuAction(4);">GRAPH</a></li>
                    </ul>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <input id="hiddenmode" type="hidden" runat="server" />
            <asp:Button ID="btnaction" runat="server" Text="Button" style="display:none" OnClick="btnaction_Click" />
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <div style="display:block;top:63px;left:0px;right:0px;bottom:0px;position:absolute;">        
                <iframe id="myframe1" name="myframe1" runat="server" frameborder="0" style="border:0;margin:0;height:99.5%;width:100%;padding: 0;position: absolute;top: 0;bottom: 0;left: 0;right: 0;"></iframe>
            
    </div>
    </ContentTemplate>
        </asp:UpdatePanel>
    <telerik:RadWindow ID="RadWindow1" runat="server" Modal="true" BorderStyle="None"
        Title="CMS | King Abdulaziz International Airport" EnableShadow="true" Behaviors="Close, Move"
        VisibleStatusbar="false" Skin="Metro" Width="500px" Height="270px">
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
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
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
                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
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
        VisibleStatusbar="false" Skin="Metro" Width="370px" Height="210px">
        <ContentTemplate>
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <table cellpadding="5">
                        <tr>
                            
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButtonList ID="rdbuilding" runat="server"  >
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
    <telerik:RadWindow ID="RadWindow3" runat="server" Modal="true" BorderStyle="None"
        Title="CMS | Makkah Expansion Hospital & Security Buildings" EnableShadow="true" Behaviors="Close, Move"
        VisibleStatusbar="false" Skin="Metro" Width="370px" Height="200px">
        <ContentTemplate>
            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                <ContentTemplate>
                    <table cellpadding="5">
                        <tr>
                            
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButtonList ID="rdbuilding1" runat="server"  >
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
                            </td>
                        </tr>
                        <tr>
                           
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                    <ContentTemplate>
                                        <telerik:RadAjaxPanel ID="RadAjaxPanel3" runat="server" LoadingPanelID="RadAjaxLoadingPanel1"
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
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Silk">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadNotification ID="RadNotification1" runat="server" Text="YOU HAVE NO PERMISSION TO ACCESS THIS BUILDING" Title="Message" Position="Center" Animation="Fade" AutoCloseDelay="800" >
    </telerik:RadNotification>
    </form>

    <script src="../Assets/js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function MenuAction(mode) {
            var _mode = document.getElementById("hiddenmode");
            _mode.value = mode;
            //_changeActive();
            $("#btnaction").click();
//            var frame = document.getElementById("myframe1");
//            var _prj = document.getElementById("lblprj");
//            var _sch = document.getElementById("lblsch");
//            if (mode == 1)
//                frame.src = "../Cassheet_DataEntry.aspx?id=" + _prj.textContent + "_S" + _sch.textContent;
//            else if (mode == 2)
//                frame.src = "Commissiong_Testing.aspx?id=" + _prj.textContent + "_S" + _sch.textContent;

//            $('.menu > li > a').click(function() {
//                $('.menu > li > a').removeClass('selected');
//                $(this).addClass('selected');
            //            });

        }
        function Changemenu(id) {
            $("#menu1").hide();
            $("#menu2").hide();

            $('.menu > li > a').removeClass('selected');
            $('#menu' + id).addClass('selected');


        }
        $(document).ready(function() {
            $('menu li > a').click(function() {
                $('.menu > li a').removeClass('selected');
                $(this).addClass('selected');
                //$(this).addClass('selected').siblings().removeClass('selected');

            });
        });
//        function _changeActive() {
//            $(function() {
//                $('.menu > li').click(function() {
//                $('.menu > li').removeClass('selected');
//                $(this).addClass('selected');
//                //$(this).addClass('selected').siblings().removeClass('selected');

//                });
//            });


//        }
    </script>
</body>
</html>
