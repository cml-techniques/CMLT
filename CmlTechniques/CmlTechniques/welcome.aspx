<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="CmlTechniques.welcome" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Assets/css/Style.css" rel="stylesheet" type="text/css" />
    <link href="Assets/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="Assets/select2/select2.css" type="text/css" />
    <link rel="stylesheet" href="Assets/select2/theme.css" type="text/css" />
    
    <script language="javascript" type="text/javascript">
    
    
        function downpdf() {
            var _btn = document.getElementById("dwnpdf");
            _btn.click();
        }
        function getInternetExplorerVersion()
        // Returns the version of Internet Explorer or a -1
        // (indicating the use of another browser).
        {
            var rv = -1; // Return value assumes failure.
            if (navigator.appName == 'Microsoft Internet Explorer') {
                var ua = navigator.userAgent;
                var re = new RegExp("MSIE ([0-9]{1,}[\.0-9]{0,})");
                if (re.exec(ua) != null)
                    rv = parseFloat(RegExp.$1);
            }
            return rv;
        }

        function checkVersion() {
            var msg = "You're not using Internet Explorer.";
            var ver = getInternetExplorerVersion();

            if (ver != -1) {
                if (ver >= 9.0 && ver != 10.0)
                    document.getElementById("brmsg").style.display = 'none';
            }
            else
                document.getElementById("brmsg").style.display = 'none';
            //alert(ver);
        }
        function hide() {
            document.getElementById("brmsg").style.display = 'none';
        }
        function Gotodms()
        {
        window.open("https://dms.cmltechniques.com/");
        }
    </script>

    <script type="text/javascript">

        function pageLoad() {
        }
    
    </script>

    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
    <style type="text/css" >
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
    .control-button-greens  {
    background-color: #33ce75 ;
    /* box-shadow: 0 2px 0 rgba(255,153,102,1); */
    color: #F9FAFA;
    border: 0;
    font-weight: 700;
    padding: 0!important;
    height: 30px!important;
}
     .control-button-yellow {
    background-color: #FC0;
    /* box-shadow: 0 2px 0 rgba(255,153,102,1); */
    color: #F9FAFA;
    border: 0;
    font-weight: 700;
    padding: 0!important;
    height: 30px!important;
}
.control-general 
{
	cursor:pointer;
	width:90px;
    display: inline-block;
    border-radius: 4px;
} 
   
    </style>
</head>
<body onload="javascript:checkVersion();">
    <%--<form id="form1" runat="server">
    <div>--%><%--<div style="overflow:auto;height: 100%; margin-top:151px;margin-left:210px; right: 0px;" >--%>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" ScriptMode="Release">
    </asp:ToolkitScriptManager>
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
    </asp:ScriptManager>--%>
    <div id="maincontainer" style="height: 100%">
        <table style="width: 100%">
            <tr>
                <td>
                    <div>
                        <%--<iframe id="fr2" name="fr2" frameborder="0" height="100%" width="100%" 
                        ></iframe>--%>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="200px" style="background-position: right top; background-repeat: repeat;
                                    font-family: Verdana; font-size: medium; color: #FFFFFF;" valign="middle">
                                    <asp:Label ID="Label3" runat="server" Text="" Width="10px"></asp:Label>
                                </td>
                                <td height="200px" style="background-position: left top; background-image: url('images/left.png');
                                    background-repeat: no-repeat; font-family: Verdana; font-size: medium; color: #FFFFFF;"
                                    valign="middle" bgcolor="White" width="30px">
                                    &nbsp;
                                </td>
                                <td height="175px" style="background-position: right top; background-image: url('images/mid.png');
                                    background-repeat: repeat-x;" valign="middle" bgcolor="White">
                                    <%--<asp:Label ID="Label1" runat="server" Text="
                                Welcome to CML Interactive. You are currently logged in and have access to the 
                                        projects listed below. All Operating and Maintenance Manuals for each project 
                                        have been electronically formatted and organised so that you view them on this 
                                        website using the menu structure on the left hand side.&lt;br /&gt;
                                        &lt;br /&gt;
                                        You will need Adobe Acrobat Reader and Autodesk DWF Viewer software in order to 
                                        view the manuals and drawings. These can be downloaded free of charge from the 
                                        links at the bottom of this page and from the help page (accessed by the menu on 
                                        the left). Please take a moment to check your settings for Adobe Acrobat Reader. 
                                        More information on these settings can be found in the help menu option on the 
                                        left.&lt;br /&gt;
                                        If you require any assistance please contact
                                
                                
                                " ForeColor="Black" ></asp:Label>--%>
                                    <h1 style="text-align: justify; margin-top: 10px">
                                        Welcome to the CML Techniques.
                                    </h1>
                                    <p style="text-align: justify;">
                                        CML Techniques is a secure web based data management system that has been developed
                                        by CML to contain all your commissioning and handover documents, which are available
                                        at the touch of a button</p>
                                    <p style="text-align: justify;">
                                        Each project has a bespoke set up designed with the project requirements and the
                                        end user in mind. To navigate the system, please enter the required project and
                                        utilise the file tree on the left of the screen
                                    </p>
                                    <p style="text-align: justify;">
                                        To ensure the best operation of the system, we recommend you have installed Internet
                                        Explorer 8 or above. To view the documents you will also require Adobe Acrobat Reader
                                        and Auto Desk DWF Viewer, which can be downloaded free of charge from the following
                                        links:-</p>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <table style="width: 100%; font-size: small; color: #0000FF;">
                                            <tr>
                                                <td valign="middle" width="50px">
                                                    <asp:ImageButton ID="dwnpdf" runat="server" ImageUrl="~/images/pdf1.png" OnClick="dwnpdf_Click" />
                                                </td>
                                                <td valign="middle">
                                                    <%-- <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />--%>
                                                    <a href="http://get.adobe.com/reader/" style="text-decoration: none;" target="_blank">
                                                        Download latest version of Adobe Acrobat Reader</a><%--onclick="javascript:downpdf();" --%>
                                                </td>
                                                <td valign="middle" width="50px">
                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/images/member-icon-autodesk.gif" />
                                                </td>
                                                <td>
                                                    <a href="#" onclick="javascript:window.open('http://usa.autodesk.com/adsk/servlet/pc/index?siteID=123112&id=12423405','','left=210,top=100,width=1024,height=600,menubar=1,toolbar=0,scrollbars=1,status=0');"
                                                        style="text-decoration: none;">Download latest version of Autodesk DWF Viewer</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <p style="text-align: justify;">
                                        If you require any assistance please <a href="mailto:admin@cmlinternational.net"
                                            style="text-decoration: none">contact us</a></p>
                                    <br />
                                    <div style="margin: 0px auto 10px; width: 700px; background-color: #d1d1d1; padding: 10px;
                                        text-align: center; font-size: small" id="brmsg">
                                        <p style="color: Red; margin: 3px">
                                            The Browser we detected is unsupported and may result in unexpected behaviour.</p>
                                        <p style="margin: 3px; color: Black;">
                                            Please upgrade with <a href="http://windows.microsoft.com/en-us/internet-explorer/download-ie"
                                                style="color: #3366CC; text-decoration: none" target="_blank">latest version</a>
                                            | <a href="#" style="color: #3366CC; text-decoration: none" onclick="hide();">Dismiss</a></p>
                                    </div>
                                </td>
                                <td height="200px" style="background-position: right top; background-image: url('images/right.png');
                                    background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: medium;
                                    color: #FFFFFF;" valign="middle" width="30px">
                                    &nbsp;
                                </td>
                                <td height="200px" style="background-position: right top; background-repeat: repeat;
                                    font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FFFFFF;"
                                    valign="middle">
                                    <asp:Label ID="Label2" runat="server" Text="" Width="10px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="background-position: right top; background-repeat: repeat; font-family: Arial, Helvetica, sans-serif;
                                    font-size: medium; color: #FFFFFF;" valign="middle">
                                    &nbsp;
                                </td>
                                <td style="background-position: left top; background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif;
                                    font-size: medium; color: #FFFFFF; background-image: url('images/left.png');"
                                    valign="middle" bgcolor="White" width="30px" rowspan="2">
                                    &nbsp;
                                </td>
                                <td height="10px" style="background-position: center top; background-image: url('images/mid.png');
                                    background-repeat: repeat-x; font-family: Arial, Helvetica, sans-serif; font-size: medium;
                                    color: #FFFFFF;" valign="middle" bgcolor="White">
                                    &nbsp;
                                </td>
                                <td style="background-position: right top; background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif;
                                    font-size: medium; color: #FFFFFF; background-image: url('images/right.png');"
                                    valign="middle" width="30px" rowspan="2">
                                    &nbsp;
                                </td>
                                <td style="background-position: right top; background-repeat: repeat; font-family: Arial, Helvetica, sans-serif;
                                    font-size: medium; color: #FFFFFF;" valign="middle">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="background-position: right top; background-repeat: repeat; font-family: Arial, Helvetica, sans-serif;
                                    font-size: medium; color: #FFFFFF;" valign="middle">
                                    &nbsp;
                                </td>
                                <td height="10px" style="background-position: center top; background-repeat: no-repeat;
                                    font-size: medium; color: #FFFFFF;" valign="middle" bgcolor="White">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="myprojectgrid" runat="server" CellPadding="4" Font-Size="13px"
                                                GridLines="None" Width="100%" AutoGenerateColumns="False" EnableSortingAndPagingCallbacks="True"
                                                ForeColor="#333333" PageSize="2" ShowFooter="True" Height="100px" HeaderStyle-Font-Bold="false"
                                                OnRowCommand="myprojectgrid_RowCommand" OnRowDataBound="myprojectgrid_RowDataBound">
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <Columns>
                                                    <asp:ButtonField DataTextField="prj_name" HeaderText="AUTHORISED PROJECT" HeaderStyle-HorizontalAlign="Left"
                                                        ButtonType="Button">
                                                        <ControlStyle Width="400px" Height="30px" />
                                                        <HeaderStyle HorizontalAlign="Left" Font-Bold="False"></HeaderStyle>
                                                        <ItemStyle />
                                                    </asp:ButtonField>
                                                    <asp:BoundField DataField="company" HeaderText="COMPANY" SortExpression="company">
                                                        <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ControlStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="ACCESS LEVEL" DataField="access_level">
                                                        <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="prj_code" />
                                                    <asp:BoundField DataField="prj_name" />
                                                    <asp:BoundField DataField="dms" />
                                                    <asp:BoundField DataField="cms" />
                                                    <asp:BoundField DataField="tms" />
                                                    <asp:BoundField DataField="sns" />
                                                    <asp:BoundField DataField="tis" />
                                                </Columns>
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#999999" />
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="background-position: right top; background-repeat: repeat; font-family: Arial, Helvetica, sans-serif;
                                    font-size: medium; color: #FFFFFF;" valign="middle">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlPopup" runat="server" Width="550px" Height="350px" Style="display: none">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 510px; height: 250px"
                id="tblPopup">
                <tr>
                    <td class="heading" style="background-image: url('images/headingbg_13.gif'); background-repeat: repeat-x;
                        width: 520px">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                &nbsp;<asp:Label ID="mhead" runat="server" Font-Names="verdana" Font-Size="Medium"
                                    ForeColor="White"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 30px">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btncancel" runat="server" Text="" Style="background: url('images/cancel.png');
                                    cursor: pointer" BorderStyle="None" Height="30px" Width="30px" OnClick="btncancel_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="middle" colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btncms" runat="server" Text="" OnClick="btncms_Click" Style="background: url('images/cms_icon.png');
                                                cursor: pointer" BorderStyle="None" Height="136px" Width="150px" />
                                        </td>
                                        <td align="center">
                                            <asp:Button ID="btndms" runat="server" Text="" Style="background: url('images/dms_icon.png');
                                                cursor: pointer" BorderStyle="None" Height="136px" Width="150px" OnClick="btndms_Click" />
                                        </td>
                                        <td align="center">
                                            <asp:Button ID="btnams" runat="server" Text="" Style="background: url('images/ams_icon.png');
                                                cursor: pointer; display: none;" BorderStyle="None" Height="136px" Width="150px" OnClick="btnams_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btnsns" runat="server" Text="" Style="background: url('images/sns_icon.png');
                                                cursor: pointer; display: none;" BorderStyle="None" Height="136px" Width="150px" OnClick="btnsns_Click" />
                                        </td>
                                        <td align="center">
                                            <asp:Button ID="btn_tis" runat="server" Text="" Style="background: url('images/tis_icon.png');
                                                cursor: pointer; display: none;" BorderStyle="None" Height="136px" Width="150px"
                                                OnClick="btn_tis_Click" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Button ID="btnDummy" runat="server" Text="Button" Style="display: none;" />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" TargetControlID="btnDummy"
            PopupControlID="pnlPopup" BackgroundCssClass="modal">
        </asp:ModalPopupExtender>
        <telerik:RadWindow ID="RadWindow1" runat="server" Modal="true" BorderStyle="None"
            Title="CMS | King Abdulaziz International Airport" EnableShadow="true" Behaviors="Close, Move"
            VisibleStatusbar="false" Skin="Metro" Width="500px" Height="200px">
            <ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <table cellpadding="5">
                            <tr>
                                <td>
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
                                            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1" Width="100px" >
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
        
      
         <asp:Button ID="btnDummy2" runat="server" Text="Button" Style="display: none;" />
             <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender2" runat="server" TargetControlID="btnDummy2"
            PopupControlID="pnlPopup2" BackgroundCssClass="modal" ></asp:ModalPopupExtender>
        
        
         <asp:Panel ID="pnlPopup2" runat="server" Width="450px" style="display:none" >
              <div style="width:100%;background-color:#FFFFFF">
              
                <table border="0" cellpadding="0" cellspacing="0" style="font-weight:normal;background-color:#00BFFF;width:100%" > 
                            <tr>
                                <td style="padding:5px;color:#FFFFFF;font-size:15px" >
                               DMS - Information
                                </td>
                                </tr>
                                </table>
              
              <div style="padding:10px;">
                       
                        <table border="0" cellpadding="0" cellspacing="0" style="font-weight:normal;background-color:"#FFFFFF";width:100%">
                          
                            <tr>
                                <td >
                                     You are loging into the old DM System, the latest DM System is located at <a href= "#" onclick="Gotodms();"  title="Clik here for New DMS(https://dms.cmltechniques.com)"> dms.cmltechniques.com </a>
                                    </td>
                                <td></td>
                            </tr>
                            <tr>
                            <td style="height:10px"></td>
                            </tr>
                            <tr>
                            
                            <td align="center" class="footer" colspan="2" height="30px">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                        <table>
                                        <tr>
                                        <td>
                                        <asp:Button ID="btnNewDMS" runat="server" Height="26px" CssClass="control-general control-button-greens"  OnClick= "btnNewDMS_Click" Text="New DMS" />
                                        </td>
                                        <td>
                                          <asp:Button ID="btnok" runat="server" Height="26px" CssClass="control-general control-button-yellow"  OnClick= "btnok_Click" Text="Close" />
                                        </td>
                                        </tr>
                                        </table>
                                        
                                          
                                                 
                           </ContentTemplate>
                           </asp:UpdatePanel>
                            </td>
                            </tr>
                            </table>
             </div>  
             </div>     
             </asp:Panel>
                            
        
 
        
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Silk">
        </telerik:RadAjaxLoadingPanel>
    </div>
    </form>
    <%-- </div>
    </form>--%>
    <%--<script src="Assets/js/jquery.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="Assets/select2/select2.min.js"></script>

    <script type="text/javascript">
        !function($) {
            $("#select2-option").select2();
            $(function() {
                if ($.fn.select2) {
                    $("#select2-option").select2();
                    $("#select2-option1").select2();
                }
            });
        } (window.jQuery);
    </script>--%>
    <%--<script src="http://jqueryjs.googlecode.com/files/jquery-1.2.6.min.js" type="text/javascript"></script>

    <script type="text/javascript">

        $(document).ready(function() {
            // When site loaded, load the Popupbox First
            //loadPopupBox();

            $('#popupBoxClose').click(function() {
                unloadPopupBox();
            });

            //            $('#container').click(function() {
            //                unloadPopupBox();
            //            });

            function unloadPopupBox() {    // TO Unload the Popupbox
                $('#popup_box').fadeOut("slow");
                //                $("#maincontainer").css({ // this is just for style        
                //                    "opacity": "1","background-color" : "#ffffff"
                //                });
                $("body").css({ // this is just for style
                    "background-color": "#ffffff", "opacity": "1"
                });
            }

            function loadPopupBox() {    // To Load the Popupbox
                $('#popup_box').fadeIn("slow");
                $("#maincontainer").css({ // this is just for style
                    "opacity": "0.3"
                });
            }
        });
        function loadPopupBox() {    // To Load the Popupbox
            $('#popup_box').fadeIn("slow");
            //            $("#maincontainer").css({ // this is just for style
            //                "background-color" : "#000000","opacity": "0.3"
            //            });
            $("body").css({ // this is just for style
                "background-color": "#000000", "opacity": "0.3"
            });
        }
        function unloadPopupBox() {    // TO Unload the Popupbox
            $('#popup_box').fadeOut("slow");
            $("#maincontainer").css({ // this is just for style        
                "opacity": "1"
            });
        }
        function OnSelect() {
            var e = document.getElementById("select2-option");
            var strUser = e.options[e.selectedIndex].value;
            $("#hiddenpkg").val(strUser);
            $("#btnload").click();
        }
    </script>--%>
</body>
</html>
