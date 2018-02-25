<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="sodetails_new.aspx.cs" Inherits="CmlTechniques.CMS.sodetails_new" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css"/>
    <link href="../CasSheet/Style.css" rel="stylesheet" type="text/css" /> 
    <link href="../CasSheet/css.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <%--<script src="../Scripts/highslide-full.packed.js" type="text/javascript"></script>
    <script src="../Scripts/highslide-full.packed.using.js" type="text/javascript"></script>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js" type="text/javascript"></script>--%>
    <script src="../Scripts/jquery.autosize.min.js" type="text/javascript"></script>
    <link href="../page.css" rel="stylesheet" type="text/css" />    
    <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" />  
    <link href="../Assets/css/Style.css" rel="stylesheet" type="text/css" />  
    <link href="../CasSheet/Grid.CML.css" rel="stylesheet" type="text/css" />    
    <meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=11" />
    <title></title>
    <style type="text/css">
        
        body
        {
            margin: 0;
            padding: 0;
            height: 100%;
        }
       
          
        .RadWindow_Sunset .rwCorner .rwTopLeft, 
        .RadWindow_Sunset .rwTitlebar, 
        .RadWindow_Sunset .rwCorner .rwTopRight, 
        .RadWindow_Sunset .rwIcon,
        .RadWindow_Sunset table .rwTopLeft, 
        .RadWindow_Sunset table .rwTopRight, 
        .RadWindow_Sunset table .rwFooterLeft, 
        .RadWindow_Sunset table .rwFooterRight, 
        .RadWindow_Sunset table .rwFooterCenter, 
        .RadWindow_Sunset table .rwBodyLeft, 
        .RadWindow_Sunset table .rwBodyRight, 
        .RadWindow_Sunset table .rwTitlebar, 
        .RadWindow_Sunset table .rwTopResize,
        .RadWindow_Sunset table .rwStatusbar,
        .RadWindow_Sunset table .rwStatusbar .rwLoading
       {   
           display: none !important;  
       }
       .TelerikModalOverlay
          {
           background: black !important;
           opacity: .5 !important;
           -moz-opacity: .5 !important;
          }
        .rwEdit .rwWindowContent
        {
            background-color: #C0C0C0 !important;
        }
          .style1
        {
            width: 100px;
            height: 30px;
        }
        .style2
        {
            width: 250px;
            height: 30px;
        }
        .style3
        {
            height: 30px;
        }
       .modal
        {
            display: none;
            position: absolute;
            top: 0px;
            left: 0px;
            background-color: black;
            z-index: 100;
            opacity: 0.8;
            filter: alpha(opacity=60);
            -moz-opacity: 0.8;
            min-height: 100%;
        }
        #divImage
        {
            display: none;
            z-index: 1000;
            position: fixed;
            top: 20;
            left: 0;
            background-color: White;
            height: 450px;
            width: 500px;
            padding: 3px;
            border: solid 1px black;
        }
          .aTableCol 
    {
        border: thin solid #000066;
    }
    
     .aDisabledView 
    {
        border: thin solid #999999;
        color: #999999;
        display: block;
        padding: 5px;
        word-wrap:break-word;
    }
        
        </style>
    <script type="text/javascript">
    function LoadDiv(url) {
    var img = new Image();
    var bcgDiv = document.getElementById("divBackground");
    var imgDiv = document.getElementById("divImage");
    var imgFull = document.getElementById("imgFull");
    var imgLoader = document.getElementById("imgLoader");
    imgLoader.style.display = "block";
    img.onload = function () {
        imgFull.src = img.src;
        imgFull.style.display = "block";
        imgLoader.style.display = "none";
   };
    img.src = url;
    var width = document.body.clientWidth;
    if (document.body.clientHeight > document.body.scrollHeight) {
        bcgDiv.style.height = document.body.clientHeight + "px";
    }
    else {
        bcgDiv.style.height = document.body.scrollHeight + "px";
    }
    imgDiv.style.left = (width - 650) / 2 + "px";
    imgDiv.style.top = "20px";
    bcgDiv.style.width = "100%";
 
    bcgDiv.style.display = "block";
    imgDiv.style.display = "block";
    return false;
}
function HideDiv() {
    var bcgDiv = document.getElementById("divBackground");
    var imgDiv = document.getElementById("divImage");
    var imgFull = document.getElementById("imgFull");
    if (bcgDiv != null) {
        bcgDiv.style.display = "none";
        imgDiv.style.display = "none";
        imgFull.style.display = "none";
    }
}

</script>
   
    
</head>
<body style="overflow:hidden;">
    <form id="form1" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock_Service" runat="server">
    <script type="text/javascript">
     
      function OnSelectionChanged(sender, eventArgs) 
        {  
            var item = eventArgs.get_item();       
            if(item.get_value() == "2")
            {
                var confirm_value = document.getElementById("confirm");               
               
                if (confirm("Deleted SO cannot be recovered. Are you sure you want to Delete the SO?")) {
                    confirm_value.value = "yes";
                } else {
                    confirm_value.value = "no";
                }
                //document.forms[0].appendChild(confirm_value);
            }
            
        }
    </script>
    </telerik:RadScriptBlock>
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />    
    <div class="fixedhead" runat="server" id="dvfixedhead" style="height:30px;">
        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
            <ContentTemplate>
                <div id="infobar">
                    <div class="prjinfo">
                        <div class="pullleft font-big">
                            <a href="#" onclick="Fullscreen();"><i class="fa fa-align-justify"></i></a> CMS :
                            <asp:Label ID="prj" runat="server" Style="color: #e6422c" ></asp:Label></div>
                        <div class="pullright font-big">
                            <asp:Label ID="package" runat="server" Style="color: #e6422c" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    
    <div  style="position:absolute;left:0px;right:0px; top:30px; width:100%;display:block;" runat="server" id="dvfixedcontent">
       <div style="background-color:White; padding-left:1px;width:100%;">
        <table style="background-color:#092443; color:White; width:100%;" cellspacing="1" >
            <tr>
                <td style="font-size: x-large;"><asp:Label ID="lblsono" runat="server" ForeColor="Red"></asp:Label>&nbsp; Details</td>       
                <td style="width:200px;">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                    <telerik:RadComboBox ID="rcbAction" runat="server" EmptyMessage="Select Action" Skin="WebBlue" markfirstmatch="True" allowcustomtext="false" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="rcbAction_OnSelectedIndexChanged" OnClientSelectedIndexChanged="OnSelectionChanged" >              
                    </telerik:RadComboBox>
                    </ContentTemplate>
                    </asp:UpdatePanel>        
                    </td>
                <td align="right" style="width:110px; padding-right:10px;">
                  <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnback" runat="server" Text="Back" onclick="btnback_Click" Width="100px" />
                    </ContentTemplate>
                    </asp:UpdatePanel> 
                </td>
            </tr>
            </table>
        </div> 
        <div id="myprogress" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
                </ProgressTemplate>
                </asp:UpdateProgress>
            </div> 
        <div id="dvHiddenFields">
    <asp:Label ID="lblid" runat="server" Text="" style="display:none"></asp:Label>
    <asp:Label ID="lblprjcode" runat="server" Text="" CssClass="hidden"></asp:Label>
    <asp:Label ID="lblsoid" runat="server" Text="" CssClass="hidden"></asp:Label>
    <asp:Label ID="lblsoitmid" runat="server" Text="" CssClass="hidden"></asp:Label>
    <asp:Label ID="lbluid" runat="server" Text="" style="display:none"></asp:Label>
    <asp:Label ID="lbldrdid" runat="server" Text="" CssClass="hidden"></asp:Label>
    <asp:Label ID="lblPermission" runat="server" Text="0" style="display:none"></asp:Label>
    <asp:Label ID="lblNewProject" runat="server" Text="0" style="display:none"></asp:Label>
    <input type="hidden" id="confirm" name="confirm" value="no" runat="server"/>
    </div>    
        <div id="dvSOListing" style="font-family:Verdana;font-size:x-small;width:100%;padding-left:1px;">         
            <table style="width:100%; font-weight: bold; font-size:12px;" cellspacing="1" cellpadding="3px">
                <tr style="background-color:#c1c1c1">
                <td class="aTableCol" style="width:15%;" >Package :&nbsp;<asp:Label ID="lbpkg" runat="server" Text="" Font-Size="11px" Font-Bold="false"></asp:Label></td>       
                <td align="center" colspan="6" style="font-size: 24px;width:85%;" class="aTableCol">Site Observation</td>
                </tr>        
                <tr style="background-color:#c1c1c1">        
                <td height="30px" style="width:23%;" class="aTableCol" colspan="2"  >
                    <table style="border-style:none; border:0; table-layout: fixed;" width="100%" cellpadding="0px" cellspacing="0"  ><tr>
                    <td valign="top" align="left" style="width:85px">Subject(s) :&nbsp;</td>
                    <td align="left" style="text-align: left; width:100%; word-wrap:break-word;font-weight:normal;font-size:11px;">
                    <asp:Label ID="lbdoc" runat="server" Text="" Width="100%" ></asp:Label></td>
                    </tr></table>            
                </td>   
                <td style="width:16%;" class="aTableCol" id="tdBuilding" runat="server">
                    <table style="border-style:none; border:0; table-layout: fixed;" width="100%" cellpadding="0px" cellspacing="0">
                        <tr>
                        <td valign="top" align="left">Building :&nbsp;</td>
                        <td style="text-align: left; width:60%; word-wrap:break-word;">
                        <asp:Label ID="lblBuilding" runat="server"  Font-Bold="false" Font-Size="11px"></asp:Label></td>
                        </tr>
                    </table>            
                </td>     
                <td style="width:12%;" class="aTableCol">Sheet No. :&nbsp;
                    <asp:Label ID="lbno" runat="server" Text=""  Font-Bold="false" Font-Size="11px"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text="" style="display:none"></asp:Label><asp:Label ID="Label5" runat="server" Text="" style="display:none"></asp:Label>
                </td>     
                <td style="width:25%;" class="aTableCol">Recorded By :&nbsp;<asp:Label ID="lbcreated" runat="server" Text=""  Font-Bold="false" Font-Size="11px"></asp:Label></td>
                <td style="width:24%;" class="aTableCol" >Issued to :&nbsp;
                    <asp:Label ID="lbissued" runat="server" Text=""  Font-Bold="false" Font-Size="11px"></asp:Label>
                    <asp:Label ID="lblissued" runat="server" Text="" style="display:none" ></asp:Label>
                </td>
                </tr>
            </table> 
            <div style="overflow:scroll;overflow-x:hidden;padding-right:2px;">
            <table runat="server" border="0" cellspacing="1" cellpadding="0" style="font-family: Verdana; font-weight:bold; width:100%; height:42px;"   >
                <tr id="Tr2" runat="server" style="background-color:#045FB4;color: #000000; vertical-align:middle;">
                <td style="width:3%;"></td>
                <th style="width:4%; color:White; font-size:12px;">Item No.</th>
                <th style="width:20%; color:White;font-size:12px;text-align:left;padding-left:5px;">Details & Location</th>
                <th style="width:20%; color:White;font-size:12px;text-align:left;padding-left:5px;">Photos <span style="font-size:11px;font-weight:normal;">(Click image for larger view)</span></th>
                <th style="width:20%; color:White;font-size:12px;text-align:left;padding-left:5px;">Issued To Response</th>
                <th id="Th11" runat="server" style="width:20%;color:White;font-size:12px;text-align:left;padding-left:5px;" >CML Comment</th>
                <th id="Th22" runat="server" style="width:5%;color:White;font-size:12px;text-align:center;" >Closed?</th>
                <th id="Th33" runat="server" style="width:8%;color:White;font-size:12px;text-align:left;"></th> 
                </tr>
             </table>
        </div>
            <div id="dvSODetailListing" style="overflow:scroll;position:fixed; bottom:0px; top: 190px; right: 0px; left: 0px;overflow-x:hidden;" runat="server">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
         <ContentTemplate>
         <asp:ListView ID="mydetails" runat="server" DataKeyNames="so_itm_id" OnItemDataBound="mydetails_ItemDataBound"  OnItemCommand="mydetails_ItemCommand">        
            <ItemTemplate>       
            <tr style="background-color:White; width:100%;font-size:9px;">
                <td style="border: thin solid #333333;text-align:center;"> <asp:CheckBox ID="chkselect" runat="server" /> </td>
                <td valign="middle" align="center" style="border: thin solid #333333"> 
                    <asp:Label ID="slno" runat="server" Width="100%" Font-Bold="false" Font-Names="Verdana" Font-Size="9px" /> </td>
                <td valign="middle" align="left" style="border: thin solid #333333; padding:5px; font-weight:normal; word-wrap:break-word;" >   
                    <asp:Label ID="lblDetails" Text='<%# Eval("details") %>' runat="server" Width="100%" style="word-wrap:break-word;"></asp:Label>
                    <asp:Label ID="so_itm_idLabel" runat="server" Text='<%# Eval("so_itm_id") %>' style="display:none"/>
                </td>            
                <td valign="middle" align="center" style="border: thin solid #333333;padding:0;" id="tdPhoto" runat="server">              
                    <div style="width:100%;height:100%;">                
                    <asp:ListView ID="lvPhoto" runat="server" ItemPlaceholderID="PlaceHolder1" >              
                    <LayoutTemplate>             
                    <table cellspacing="1" cellpadding="0"  style="float:left; display: inline-table;" width="100%"><tr><td>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"  />
                    </td></tr></table>                
                    </LayoutTemplate>
                    <ItemTemplate>
                    <table id="tblPhoto" runat="server" cellspacing="1"  style="float:left; display: inline-table;height:100px;" width="50%"><tr><td>
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl='<%# Eval("photo")%>' Width="100%" Height="100px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" BorderStyle="Solid" BorderWidth="1" BorderColor="#E2E2E2" />                       
                        <asp:Label ID="lblPhotID" runat="server" style="display:none;" Text='<%# Eval("PhotoID")%>'></asp:Label>
                    </td></tr></table>
                    </ItemTemplate>
                    </asp:ListView>
                    </div>
                </td>
                <td valign="middle" align="left" style="border: thin solid #333333; padding:5px;word-wrap:break-word;" >  
                  <asp:Label ID="lblSOResponse" runat="server" Text='<%# Eval("response") %>'  Width="100%" Font-Bold="false"></asp:Label>
                </td>
                <td style="border: thin solid #333333;padding:5px;word-wrap:break-word;" valign="middle" align="left" id="td1" runat="server">                    
                <asp:Label ID="lblCMLComment" runat="server" Text='<%# Eval("cmlresp") %>'  Width="100%" Font-Bold="false"></asp:Label>
                </td>
                <td style="border: thin solid #333333; font-weight:normal;" align="center"  id="tdStatus" runat="server">
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("itm_status") %>' />
                </td>                    
                <td valign="middle" style="border: thin solid #333333; padding-top:10px; padding-bottom:10px;" align="center" id="tdButton" runat="server">
                <table >
                    <tr><td><asp:Button ID="EditButton" runat="server" CommandName="Edit1" Text="Respond" style="cursor:pointer" Width="98%" Font-Size="12px"  /></td></tr>
                    <tr><td>&nbsp;</td></tr>
                    <tr><td><asp:Button ID="CommetButton" runat="server" CommandName="Comment" Text="Comment" style="cursor:pointer" Width="98%" Font-Size="12px" Font-Names="Verdana"  /></td></tr>
                </table>
                </td>
            </tr>          
            </ItemTemplate>   
            <EmptyDataTemplate>
                <table id="Table1" runat="server" 
                    style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td> No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>   
            <LayoutTemplate>           
            <table border="0" cellspacing="1" cellpadding="0" style="padding: 0px; table-layout:fixed; margin: 0px; border-width: thin; border-color: #666666; font-family: Verdana; font-weight:bold; width:100%;" frame="box" >
                <tr id="Tr2" runat="server">
                    <td style="width:3%;"></td>
                    <th style="width:4%;"></th>
                    <th style="width:20%;"></th>
                    <th style="width:20%;"></th>
                    <th style="width:20%;"></th>
                    <th id="Th1" runat="server" style="width:20%;" ></th>
                    <th id="Th2" runat="server" style="width:5%;" ></th>
                    <th id="Th3" runat="server" style="width:8%;" ></th>   
                </tr>                 
                <tr ID="itemPlaceholder" runat="server" />                 
            </table>           
        </LayoutTemplate>
    </asp:ListView>
    </ContentTemplate>
    </asp:UpdatePanel>
            </div>           
    </div>  
     <div id="divBackground" class="modal"></div>
        <div id="div1" class="modal"></div>
        <div id="divImage">
        <table style="height: 100%; width: 100%">
            <tr>
                <td valign="middle" align="center">
                    <img id="imgLoader" alt="" src="images/loader.gif" />
                    <img id="imgFull" alt="" src="" style="display: none; height: 400px; width: 450px" />
                </td>
            </tr>
            <tr>
                <td align="center" valign="bottom">
                    <input id="btnClose" type="button" value="close" onclick="HideDiv()" />
                </td>
            </tr>
        </table>
    </div> 
    </div>
    
    <div id="SO - Reissue">
        <telerik:RadWindow runat="server" ID="RadWindow_SOReissue" Modal="false" ReloadOnShow="false" VisibleTitlebar="false" VisibleStatusbar="false"
         Behaviors="None" KeepInScreenBounds="true" Width="350px" Height="200px" BorderStyle="None" InitialBehaviors="None" AutoSizeBehaviors="HeightProportional">
         <ContentTemplate>
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
        <ContentTemplate>
        
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <h4 style="margin:3px; font-family:Verdana; font-size:12px;">SO - Reissue</h4>
                <table style="width:100%;">
                
                <tr>
                <td style="width:100px;font-family:Verdana; font-size:12px;">&nbsp;</td>
                <td>
                    &nbsp;</td>
                
                </tr>
                    <tr>
                        <td style="width:100px">
                            Issued To</td>
                        <td>
                            <asp:DropDownList ID="drissuedto" runat="server" Width="100%" >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                <tr>
                <td></td>
                <td >
                <table>
                <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                    <asp:Button ID="btnsubmit" runat="server" Text="Save" 
                        onclick="btnsubmit_Click"  />
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td><asp:Button ID="btncancel1" runat="server" Text="Cancel" 
                        onclick="btncancel1_Click"  /></td>
                </tr>
                </table>
                </td>
                </tr>
                </table>
             </ContentTemplate>
                </asp:UpdatePanel>
       
        </ContentTemplate>
        </asp:UpdatePanel>        
        </ContentTemplate> 
        </telerik:RadWindow>
    </div>
    
    <div id="ResponseSection">
     <telerik:RadWindow runat="server" ID="RadWindow_Response" Modal="true" ReloadOnShow="true" VisibleTitlebar="false" VisibleStatusbar="false"
          KeepInScreenBounds="true" Width="500px" Height="380px" BorderStyle="None" InitialBehaviors="None" CssClass="rwEdit"  Skin="Sunset" >
         <ContentTemplate>
         <div style="background-color: #808080; height:20px; top:0px; position: absolute; right: 0px; left: 0px; padding:10px;">
         <asp:UpdatePanel runat="server" ID="UpdatePanel7">
         <ContentTemplate>
            <asp:Label id="lblResponseTitle" runat="server" ForeColor="White" Font-Bold="true" Font-Size="14px" Font-Names="Verdana"></asp:Label>
         </ContentTemplate>
         </asp:UpdatePanel>
         </div>
         <div style="padding-top: 50px; padding-right: 10px; padding-left: 10px;" >
                <table style="table-layout:fixed;">
                <tr id="trViewCMLCommentLabel" runat="server">
                <td style="font-weight:bold;font-family: Verdana;">CML Comment</td>
                </tr>
                <tr id="trViewCMLComment" runat="server">
                <td style="word-wrap:break-word;">
                <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                <ContentTemplate>
                    <asp:Label ID="lblComment" runat="server" Width="450px" Height="100px"  ForeColor="Gray" BackColor="White" CssClass="label_padding" ></asp:Label>
                    </ContentTemplate>
                 </asp:UpdatePanel>
                </td>
                </tr>
                <tr>
                <tr>
                <td style="font-weight:bold;font-family: Verdana;">Your Response</td>
                </tr>
                <tr>
                <td style="word-wrap:break-word;">
                <asp:UpdatePanel runat="server" ID="pnlResponse">
                <ContentTemplate>
                    <asp:TextBox ID="txtresp" runat="server" Width="450px" TextMode="MultiLine" Height="100px" CssClass="label_padding" ></asp:TextBox>
                    </ContentTemplate>
                 </asp:UpdatePanel>
                </td>
                </tr>               
                </table>
                <table style="float: right; text-align: right; bottom: 5px; right: 5px; position: absolute;" cellpadding="5"><tr>
                <td><asp:Button ID="btnupdate" runat="server" Text="Issue Response" onclick="btnupdate_Click" Width="150px"  /></td>
                <td><asp:Button ID="btnCancelEdit" runat="server" Text="Cancel" onclick="btnCancelEdit_Click" Width="150px" /></td>
                </tr></table>
                </div>
             </ContentTemplate>
       </telerik:RadWindow>  
    </div>
    
    <div id="AddSO">
     <telerik:RadWindow runat="server" ID="RadWindow_AddSO" Modal="false" ReloadOnShow="false" VisibleTitlebar="false" VisibleStatusbar="false"
         Behaviors="None" KeepInScreenBounds="true" Width="600px" Height="400px" BorderStyle="None" InitialBehaviors="None" AutoSizeBehaviors="HeightProportional">
        <ContentTemplate>
        <asp:CheckBoxList ID="chkuser" runat="server" BackColor="White" Width="100%" Height="75px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" >
        </asp:CheckBoxList>
        <asp:Button ID="btnCont" runat="server" Text="Continue" OnClick="btnCont_Click"   /><asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click"    />
        </ContentTemplate>
       </telerik:RadWindow>  
       
    </div>
    
    <div id="AddEditComment">
     <telerik:RadWindow runat="server" ID="RadWindow_Comment" Modal="true" ReloadOnShow="true" VisibleTitlebar="false" VisibleStatusbar="false"
          KeepInScreenBounds="true" Width="500px" Height="380px" BorderStyle="None" InitialBehaviors="None" CssClass="rwEdit"  Skin="Sunset" >
           <ContentTemplate>
         <div style="background-color: #808080; height:20px; top:0px; position: absolute; right: 0px; left: 0px; padding:10px;">
         <asp:UpdatePanel runat="server" ID="UpdatePanel10">
         <ContentTemplate>
            <asp:Label id="lblCommentTitle" runat="server" ForeColor="White" Font-Bold="true" Font-Size="14px" Font-Names="Verdana"></asp:Label>
         </ContentTemplate>
         </asp:UpdatePanel>
         </div>
         <div style=" padding-top: 50px; padding-right: 10px; padding-left: 10px;" >
                <table style="table-layout:fixed;">
                <tr>
                <td style="font-weight:bold;font-family: Verdana;">Issued to Response</td>
                </tr>
                <tr>
                <td style="word-wrap:break-word;">
                <asp:UpdatePanel runat="server" ID="UpdatePanel11">
                <ContentTemplate>
                    <asp:Label ID="lblResponse" runat="server" Width="450px" Height="100px" ForeColor="Gray" CssClass="label_padding" BackColor="White"></asp:Label>
                    </ContentTemplate>
                 </asp:UpdatePanel>
                </td>
                </tr>
                <tr>
                <tr>
                <td style="font-weight:bold;font-family: Verdana;">Your Response</td>
                </tr>
                <tr>
                <td style="word-wrap:break-word;">
                <asp:UpdatePanel runat="server" ID="UpdatePanel12">
                <ContentTemplate>
                    <asp:TextBox ID="txt_cmlresp" runat="server" Width="450px" TextMode="MultiLine" Height="100px" CssClass="label_padding"></asp:TextBox>
                    </ContentTemplate>
                 </asp:UpdatePanel>
                </td>
                </tr>               
                </table>
                <table style="float: right; text-align: right; bottom: 5px; right: 5px; position: absolute;" cellpadding="5"><tr>
                    <td><asp:Button ID="btnupdate_cmt" runat="server" Text="Issue Response" onclick="btnupdate_cmt_Click" Width="150px" /></td>
                    <td><asp:Button ID="btncancel_cmt" runat="server" Text="Cancel" onclick="btncancel_cmt_Click" Width="150px" /></td></td>
                </tr></table>
                </div>
             </ContentTemplate>
        
       </telerik:RadWindow>  
    </div> 
       
    <div id="dvEditSORadWindow" runat="server" style="position:absolute; top:0px;" >        
            <telerik:RadWindow runat="server" ID="RadWindow_SOEdit" ReloadOnShow="false" Modal="true" VisibleStatusbar="false" AutoSize="true"  
             Behaviors="Move" BorderStyle="None" MaxHeight="800px" MaxWidth="800px" MinHeight="380px"  Skin="Metro"  MinWidth="640px"  >
             <ContentTemplate>
            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
            <ContentTemplate>
            <div style="padding: 10px; font-family: Verdana; font-size: 11px;">
            <table style="width:100%;" cellspacing="0" cellpadding="5px">        
            <tr>
            <td valign="top">Subject</td>
            <td style="padding-left:8px;">
                <asp:Label ID="lblSubjectText" runat="server" BorderStyle="Solid" BorderColor="#999999" BorderWidth="1" CssClass="aDisabledView" Width="448px"></asp:Label>                
            </tr>
            <tr>
            <td style="vertical-align:top;">Description</td>
            <td style="padding-left:8px;vertical-align:top;">
                <asp:TextBox ID="txt_descr" runat="server" Width="450px" Height="90px" TextMode="MultiLine" Style="padding-left:5px;" Font-Names="Verdana" Font-Size="11px"></asp:TextBox></td>
            </tr>       
            <tr id="trstatus" runat="server">
            <td>Status</td>
            <td style="padding-left:8px;">
            <asp:DropDownList ID="drstatus" runat="server" Font-Size="11px">
            <asp:ListItem Text="OPEN" Value="1" Selected="True"></asp:ListItem>
            <asp:ListItem Text="CLOSED" Value="2"></asp:ListItem>
            </asp:DropDownList>
            </td>
            </tr>
            <tr>
            <td></td>
            <td>              
            <asp:CheckBox ID="chkReplacePhoto" runat="server"/>  
            <div style="width:50px; height:20px; vertical-align:top; overflow:hidden; display:inline;"> 
            <label style="vertical-align:middle;" >Replace Existing Photo(s)</label></div>
            </td>        
            </tr>
            <tr>
            <td><asp:label id="lblSelectPhoto" runat="server" Text="Select Photo" Width="80px" ></asp:label> </td>
            <td>
            <div style="padding-left:4px;">
                <telerik:RadAsyncUpload runat="server" ID="asyncSOImageUpload" MultipleFileSelection="Automatic" Width="400px" 
                OnClientFileUploadRemoving="onFileUploadRemoving" Localization-Select="Browse" Font-Names="Verdana" Font-Size="11px" MaxFileSize="100000000" />
               <%-- <telerik:RadProgressArea runat="server" ID="RadProgressArea2" />--%>
            </div>        
            </td>  
             </tr>        
            <tr>
            <td></td>
            <td>
            <div>        
           <div style="width:100%;height:100%;">                
                    <asp:ListView ID="lvPhotoList" runat="server" ItemPlaceholderID="PlaceHolder1" OnItemDeleting="lvPhotoList_DeleteCommand">              
                    <LayoutTemplate>             
                    <table cellspacing="1" cellpadding="0"  style="float:left; display: inline-table;" width="100%"><tr><td>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"  />
                    </td>
		
		</tr></table>                
                    </LayoutTemplate>
                    <ItemTemplate>
                    <table id="tblPhoto" runat="server" cellspacing="3"  style="float:left; display: inline-table;height:100px;" width="30%"><tr><td style="width:85%;">
                        <asp:ImageButton ID="imgEdit" runat="server" ImageUrl='<%# Eval("photo")%>' Width="100%" Height="100px" Style="cursor: pointer" BorderStyle="Solid" BorderWidth="1" BorderColor="#E2E2E2" />                       
                        <asp:Label ID="lblPhotoID" runat="server" style="display:none;" Text='<%# Eval("PhotoID")%>'></asp:Label>
                    </td>
                    <td align="left">
                     <asp:LinkButton ID="lnkDeleteImage" Width="10px" Height="10px" runat="server" Text="" CommandName="Delete"><i class="fa fa-times" style="font-size: x-large; color: #CC0000;"></i></asp:LinkButton>    
                    </td>
</tr></table>
                    </ItemTemplate>
                    </asp:ListView>
      
           </div>
            </td>
            </tr> 
            <tr>
            <td colspan="2">
           
            <table cellpadding="5px">
            <tr>
            <td align="left"><asp:Button ID="btnupdateso" runat="server" Text="Update" Width="80px" onclick="btnupdateso_Click" Font-Names="Verdana" Font-Size="11px" /></td>
            <td align="left" style="padding-left:10px;"><asp:Button ID="btndelete_itm" runat="server" Text="Delete" Width="80px" onclick="btndelete_itm_Click" Font-Names="Verdana" Font-Size="11px"/></td>
            <td align="left" style="padding-left:10px;"><asp:Button ID="btncancel_edit" runat="server" Text="Cancel"  Width="80px" onclick="btncancel_edit_Click" Font-Names="Verdana" Font-Size="11px"/></td>
            </tr>
            </table>
            </div>
            </td>
            </tr>
            </table>
           
            
            </ContentTemplate>
            </asp:UpdatePanel>
            
            </ContentTemplate>
            
          
            </telerik:RadWindow>
        <div id="Div2" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
        <asp:Image ID="imgload1" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
        </ProgressTemplate>
        </asp:UpdateProgress>
        </div> 
        </div>         

    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">

    function DeleteFile(filePath) {
        $.ajax({
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            url: '/sodetails.aspx/DeleteFile',
            data: "{'filePath': \"" + filePath + "\"}",
            success: function(data) {
                if (data.d) {
                    alert('Delete file successfully');
                } else {
                    alert('Cannot delete file');
                }
            }
        });
    }


    function onFileUploadRemoving(sender, args) {

        DeleteFile("/SOIMG/" + args.get_fileName());
    }
    </script>
</telerik:RadCodeBlock>
   
    </form>
    <script type="text/javascript">
        $(function() {
            $('.normal').autosize();
            //            $('.animated').autosize({ append: "\n" });
        });
        function CallAutoSize() {
            $('.normal').autosize();
        }
    </script>

</body>
</html>
