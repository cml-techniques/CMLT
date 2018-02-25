<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="sodetails.aspx.cs" Inherits="CmlTechniques.CMS.sodetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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
      function getFiles() {

          myFileList = document.getElementById("myupload");

          for (var i = 0; i < myFileList.files.length; i++) {

              //document.getElementById("display").innerHTML += myFileList.files[i].name + "  ";
              document.getElementById("display").innerHTML += "  ";
              var element = document.createElement("input");

              element.type = "button";
              element.value = "Remove " + myFileList.files[i].name;
              element.id = i;
              element.style.font = "arial,serif"
              element.style.background = "#D0D0D0";
              element.style.border = "none";
              // element.name = myFileList.files[i].name + "Name1";              
              element.setAttribute("onclick", "Javascript:DeselectPhoto('" + i + "');");
              var fileListContainer = document.getElementById("display");
              //element.innerHTML =      "<i class='fa fa-times'></i>";                 

              fileListContainer.appendChild(element);
              //&#xf00d;       //
          }

      }
      function DeselectPhoto(fileSequence) {

          var btnToRemove = document.getElementById(fileSequence);
          btnToRemove.parentElement.removeChild(btnToRemove);

      }
    </script>
    <script src="../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script> 
<script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.autosize.min.js" type="text/javascript"></script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" /> 
    <style type="text/css">
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
    </style>
    <style type="text/css">
       textarea
       {
       	padding-bottom:10px;
           vertical-align: top;
           resize: none;
           margin-bottom:10px;
       }
        
       .animated
       {
           -webkit-transition: height 0.2s;
           -moz-transition: height 0.2s;
           transition: height 0.2s;
       }
   </style>

    <script type="text/javascript">
        function textAreaAdjust(o) {
            o.style.height = "1px";
            o.style.height = (25 + o.scrollHeight) + "px";
        }
</script>
    <link href="../Assets/css/Style.css" rel="stylesheet" type="text/css" />
         <link href="../Assets/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
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
                            <asp:Label ID="prj" runat="server" Style="color: #e6422c" ></asp:Label></div>
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
    <div class="fixedcontent" style="top:31px;overflow:auto" runat="server" id="dvfixedcontent">
    <div>
        <div >
       
        <table style="background-color:#092443;color:White;width:100%">
        <tr>
        <td style="width:110px"><%--<a href="#" onclick="window.open('../cmsdocreviewadd.aspx','','left=210,top=100,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');">Add Details</a>--%>
        <table>
        <tr>
        <td><asp:Button ID="btn" runat="server" Text="Add Details" onclick="btn_Click" /></td>
        <td><asp:Button ID="btnback" runat="server" Text="Back" onclick="btnback_Click" /></td>
        </tr>
        </table>
        
        
            </td>
        <%--<td style="width:300px"><asp:TextBox ID="txtdetails" runat="server" Width="300px"></asp:TextBox></td>
        <td><asp:Button ID="btnaddtr" runat="server" Text="add" onclick="btnaddtr_Click" Width="100px" /></td>--%>
        <td style="font-size: x-large; font-weight: bold;">
            <asp:Label ID="lblsono" runat="server" ForeColor="Red"></asp:Label>Site 
            Observation Details</td>
 
        <%--<td width="41px">
            <asp:Button ID="btnprint" runat="server" Text="Print" 
                OnClientClick="window.open('Reports.aspx?id=so','','left=210,top=100,width=1110,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=0');" />
            </td>--%>
            <asp:Label ID="lblPermission" runat="server" Text="0" style="display:none"></asp:Label>
        <td align="right" style="width:328px">
         <table border="0" cellpadding="0" cellspacing="0">
            <tr>
             <td style="width:82px">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                 <asp:Button ID="btnedit" runat="server" Text="Edit Item" Width="80px" 
                        onclick="btnedit_Click" />
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width:82px">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btndelete" runat="server" Text="Delete SO" Width="80px" 
                        onclick="btndelete_Click"/>
                    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"  TargetControlID="btndelete" ConfirmText="Are you sure want to Delete the SO?">
                    </asp:ConfirmButtonExtender>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td width="82px">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnreissue" runat="server" Text="Reissue" 
                    onclick="btnreissue_Click" Width="80px" />
            </ContentTemplate>
            </asp:UpdatePanel>
         </td>
            <td width="82px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                <asp:Button ID="btnprint" runat="server" Text="Print" CssClass="btnclass" OnClick="btnprint_Click" Width="80px" />
                </ContentTemplate>
                </asp:UpdatePanel>
            
            </td>
            </tr>
            </table>
         </td>
        </tr>
        </table>
        </div>
        <asp:Label ID="lblprjcode" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblsoid" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblsoitmid" runat="server" Text="" CssClass="hidden"></asp:Label>
        <div style="font-family:Verdana;font-size:x-small">
            <table style="width:100%">
        <tr>
        <td>
        <table style="width:100%; font-weight: bold; text-align:center;background-color:#092443" cellspacing="1" cellpadding="3">
        <tr style="background-color:#c1c1c1">
        <td class="style1">PACKAGE :</td>
        <td><asp:Label ID="lbpkg" runat="server" Text=""></asp:Label></td>        
        <td align="center" colspan="8" style="font-size: large" class="style3">SITE OBSERVATION</td>
        </tr>
        <tr style="background-color:#c1c1c1">
        <td class="style1" runat="server" id="tdBuildingLabel">Building :</td>
        <td runat="server" id="tdBuildingText"><asp:Label ID="lbBuilding" runat="server" Text=""></asp:Label></td>
        <td class="style1">Document(s) :</td>
        <td class="style2">
            <asp:Label ID="lbdoc" runat="server" Text=""></asp:Label>
            </td>
        <td style="width: 100px">Sheet No.</td>
        <td style="width:120px">
            <asp:Label ID="lbno" runat="server" Text=""></asp:Label>
            <asp:Label ID="lbluid" runat="server" Text="" style="display:none"></asp:Label><asp:Label ID="lblid" runat="server" Text="" style="display:none"></asp:Label>
            </td>
        <td style="width: 110px">Recorded By :</td>
        <td style="width:250px">
            <asp:Label ID="lbcreated" runat="server" Text=""></asp:Label>
            </td>
        <td style="width: 110px">Submitted to:</td>
        <td style="width: 240px">
            <asp:Label ID="lbissued" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblissued" runat="server" Text="" style="display:none" ></asp:Label>
            </td>
        </tr>
        </table>
        </td>
        </tr>
        </table>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                 <asp:ListView ID="mydetails" runat="server" DataKeyNames="so_itm_id" 
                    onitemdatabound="mydetails_ItemDataBound" 
                    onitemcanceling="mydetails_ItemCanceling" 
                    onitemediting="mydetails_ItemEditing" 
                    onitemcommand="mydetails_ItemCommand" onitemupdating="mydetails_ItemUpdating"  style="width:100%"  >
                    <ItemTemplate>
                        <tr style="background-color:White;">
                        <td>
                        <asp:CheckBox ID="chkselect" runat="server" />
                        </td>
                        <td valign="top" align="center">
                        <asp:Label ID="slno" runat="server" Width="50px" />
                        </td>
                            <td valign="top">
                               <%-- <asp:Label ID="detailsLabel" runat="server" Text='<%# Eval("details") %>' 
                                    Width="280px" />--%>
                                    <asp:TextBox ID="detailsLabel" runat="server" Text='<%# Eval("details") %>' Width="95%" TextMode="MultiLine" style="overflow:hidden" ReadOnly="true" BorderStyle="None" CssClass="normal"></asp:TextBox>
                                <asp:Label ID="so_itm_idLabel" runat="server" Text='<%# Eval("so_itm_id") %>' 
                                    style="display:none" />
                            </td>
                            <td valign="top">
                                <asp:GridView ID="myphoto" runat="server" AutoGenerateColumns="false" 
                                    ShowHeader="false" BorderStyle="None" Width="250px">
                                <Columns>
                                <asp:TemplateField>
                                <ItemTemplate  >
                                <a href='<%# Eval("photo") %>' target="_blank">
                                <img id="myimg0" runat="server" src='<%# Eval("photo") %>' height="100" 
                                        width="250"  alt="" /></a>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                </asp:GridView>
                            </td>
                            <td valign="top">
                            <asp:TextBox ID="txtResponse" runat="server" Text='<%# Eval("response") %>' Width="95%" TextMode="MultiLine" style="overflow:hidden" ReadOnly="true" BorderStyle="None" CssClass="normal"></asp:TextBox>
                                <%--<asp:Label ID="responseLabel" runat="server" Text='<%# Eval("response") %>' 
                                    Width="280px" />--%>
                            </td>
                            <td style="width:200px;" valign="top" id="td1" runat="server">
                            <asp:TextBox ID="txt_cmlcomment" runat="server" Text='<%# Eval("cmlresp") %>' Width="95%" TextMode="MultiLine"  ReadOnly="true" BorderStyle="None" CssClass="normal"></asp:TextBox>
                            <%--<asp:Label ID="Label2" runat="server" Text='<%# Eval("cmlresp") %>' Width="280px" />--%>
                            </td>
                            <td style="width:100px;" align="center"  id="td2" runat="server">
                           <asp:Label ID="Label3" runat="server" Text='<%# Eval("itm_status") %>' Width="100px" />
                            </td>
                            <td valign="top">
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                        Text="Response" style="cursor:pointer" Width="100px" Font-Size="12px"  />
                                        <asp:Button ID="CommetButton" runat="server" CommandName="Comment" 
                                        Text="CML Comment" style="cursor:pointer" Width="100px" Font-Size="12px"  />
                        </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style="background-color:White;">
                        <td>
                        <asp:CheckBox ID="chkselect" runat="server" />
                        </td>
                        <td valign="top" align="center">
                        <asp:Label ID="slno" runat="server" Width="50px" />
                        </td>
                            <td valign="top">
                               <%-- <asp:Label ID="detailsLabel" runat="server" Text='<%# Eval("details") %>' 
                                    Width="280px" />--%>
                                    <asp:TextBox ID="detailsLabel" runat="server" Text='<%# Eval("details") %>' Width="95%" TextMode="MultiLine" style="overflow:hidden" ReadOnly="true" BorderStyle="None" CssClass="normal"></asp:TextBox>
                                <asp:Label ID="so_itm_idLabel" runat="server" Text='<%# Eval("so_itm_id") %>' 
                                    style="display:none" />
                            </td>
                            <td valign="top">
                                <asp:GridView ID="myphoto" runat="server" AutoGenerateColumns="false" 
                                    ShowHeader="false" BorderStyle="None" Width="250px">
                                <Columns>
                                <asp:TemplateField>
                                <ItemTemplate  >
                                <a href='<%# Eval("photo") %>' target="_blank">
                                <img id="myimg0" runat="server" src='<%# Eval("photo") %>' height="100" 
                                        width="250"  alt="" /></a>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                </asp:GridView>
                            </td>
                            <td valign="top">
                            <asp:TextBox ID="txtResponse" runat="server" Text='<%# Eval("response") %>' Width="95%" TextMode="MultiLine" style="overflow:hidden" ReadOnly="true" BorderStyle="None" CssClass="normal"></asp:TextBox>
                                <%--<asp:Label ID="responseLabel" runat="server" Text='<%# Eval("response") %>' 
                                    Width="280px" />--%>
                            </td>
                            <td style="width:200px;" id="td1" runat="server">
                            
                            <asp:TextBox ID="txt_cmlcomment" runat="server" Text='<%# Eval("cmlresp") %>' Width="95%" TextMode="MultiLine" style="height:auto;" ReadOnly="true" BorderStyle="None" CssClass="normal"   ></asp:TextBox>
                            
                            <%--<asp:Label ID="" runat="server" Text='<%# Eval("cmlresp") %>' Width="280px" />--%>
                            </td>
                            <td style="width:100px;" align="center" id="td2" runat="server">
                           <asp:Label ID="Label3" runat="server" Text='<%# Eval("itm_status") %>' Width="100px" />
                            </td>
                            <td valign="top">
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                        Text="Response" style="cursor:pointer" Width="100px" Font-Size="12px" />
                                        <asp:Button ID="CommetButton" runat="server" CommandName="Comment" 
                                        Text="CML Comment" style="cursor:pointer" Width="100px" Font-Size="12px"  />
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
                                <asp:TextBox ID="detailsTextBox" runat="server" Text='<%# Bind("details") %>' />
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
                                        style="background-color: #5D7B9D;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;width:100%" >
                                        <tr runat="server" style="background-color:#5D7B9D;color: #000000;height:30px">
                                        <td></td>
                                        <th runat="server" style="width:100px">
                                                ITM.NO</th>
                                            <th runat="server" style="width:350px">
                                                DETAILS</th>
                                                <th runat="server" style="width:250px">
                                                    PHOTO</th>
                                            <th runat="server" style="width:350px">
                                                RESPONSE</th>
                                                <th id="Th1" runat="server" style="width:200px" >
                                                    CML COMMENT</th>
                                                <th id="Th2" runat="server" style="width:100px">
                                                    CLOSED?</th>
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
                        <tr style="background-color:#008A8C;color: #FFFFFF;">
                        <td></td>
                        <td valign="top" align="center">
                        <asp:Label ID="slno" runat="server" Width="50px" />
                        </td>
                            <td>
                                <%--<asp:TextBox ID="detailsTextBox" runat="server" Text='<%# Bind("details") %>' />--%>
                                <asp:TextBox ID="detailsLabel" runat="server" Text='<%# Eval("details") %>' Width="95%" TextMode="MultiLine" style="overflow:hidden" ReadOnly="true" BorderStyle="None"></asp:TextBox>
                                <asp:Label ID="so_itm_idLabel" runat="server" Text='<%# Eval("so_itm_id") %>' 
                                    style="display:none" />
                            </td>
                            <td valign="top">
                            <asp:GridView ID="myphoto" runat="server" AutoGenerateColumns="false" 
                                    ShowHeader="false" BorderStyle="None">
                                <Columns>
                                <asp:TemplateField>
                                <ItemTemplate  >
                                <a href='<%# Eval("photo") %>' target="_blank">
                                <img id="myimg1" runat="server" src='<%# Eval("photo") %>' height="100" 
                                        width="250"  alt="" /></a>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                </asp:GridView>
                            </td>
                            <td valign="top">
                                <asp:TextBox ID="responseTextBox" runat="server" 
                                    Text='<%# Bind("response") %>' Width="280px" Height="100px" 
                                    TextMode="MultiLine" />
                            </td>
                            <td style="width:200px;">
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("cmlresp") %>' Width="280px" />
                            </td>
                            <td style="width:100px;" align="center">
                           <asp:Label ID="Label3" runat="server" Text='<%# Eval("itm_status") %>' Width="100px" />
                            </td>
                            <td valign="top">
                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                                    Text="Commit Comment & Exit"  />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                    Text="Exit without Saving"  />
                            </td>
                        </tr>
                    </EditItemTemplate>
                    <SelectedItemTemplate>
                        <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                            <td>
                                <asp:Label ID="so_itm_idLabel2" runat="server" 
                                    Text='<%# Eval("so_itm_id") %>' />
                            </td>
                            <td>
                                <asp:Label ID="detailsLabel2" runat="server" Text='<%# Eval("details") %>' />
                            </td>
                            <td>
                                <asp:Label ID="responseLabel1" runat="server" Text='<%# Eval("response") %>' />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>
                </ContentTemplate>
                </asp:UpdatePanel>
               
                
            </div>      
             
        <asp:Panel ID="pnlPopup" runat="server" Width="300px" style="display:none;" >
                    <asp:Label ID="Label1" runat="server" Font-Names="verdana" Font-Size="Medium" ForeColor="White"></asp:Label>
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;background-color:White" id="tblPopup">
                            <tr>
                                <td class="heading"  style="background-image: url('images/headingbg_13.gif'); background-repeat: repeat-x;" >Select users to send notification!
     </td>
                            </tr>
                            
                            <tr>
                                <td align="left" height="75px" valign="middle"   bgcolor="White">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:CheckBoxList ID="chkuser" runat="server" BackColor="White" Width="100%" Height="75px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" >
                        </asp:CheckBoxList>
                                    </ContentTemplate>
                    </asp:UpdatePanel>
                                    </td>
                            </tr>
                            <tr>
                                <td class="footer" height="30px" >
                                    <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>--%>
                                    <asp:Button ID="btnCont" runat="server" Text="Continue" OnClick="btnCont_Click"   /><asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click"    />
                                    <%--</ContentTemplate>
                                    </asp:UpdatePanel>--%>
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
        <asp:Button ID="btnDummy" runat="server" Text="Button" style="display:none;" />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" 
                  TargetControlID="btnDummy"  PopupControlID="pnlPopup"
                  BackgroundCssClass="model-background">
                  </asp:ModalPopupExtender> 
                  
        <asp:Panel ID="pnlPopup2" runat="server" Width="400px" Height="140px" BackColor="#83C8EE" style="padding:5px;display:none"   >
            <div style="background-color:#fff;padding:5px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <h4 style="margin:3px">SO - Reissue</h4>
                <table style="width:100%">
                
                <tr>
                <td style="width:100px">&nbsp;</td>
                <td>
                    &nbsp;</td>
                
                </tr>
                    <tr>
                        <td style="width:100px">
                            ISSUED TO</td>
                        <td>
                            <asp:DropDownList ID="drissuedto" runat="server" Width="100%">
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
             <div id="myprogress" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
             
             </ContentTemplate>
                </asp:UpdatePanel>
            </div>
                        
                  </asp:Panel>
        <asp:Button ID="btnDummy2" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender2" runat="server" 
                  TargetControlID="btnDummy2"  PopupControlID="pnlPopup2"
                  BackgroundCssClass="model-background">
                  </asp:ModalPopupExtender>
                   
        <asp:Panel ID="pnlPopup3" runat="server" Width="700px" Height="450px" ScrollBars="Vertical" Wrap="true" BackColor="White" style="display:none" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3"   >
             <div style="padding: 20px;">
              <div style="border: medium solid #C0C0C0; padding-right:10px; padding-left:10px">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lbldrdid" runat="server" Text="" CssClass="hidden"></asp:Label>
                <table style="width:100%;" cellspacing="2">
                <tr>
                <td colspan="2">
                <div id="dvEditSOHeader" runat="server" style="width:100%; font-size:small; font-family: verdana; font-weight: bold;"></div>
                <br />
                </td>
                </tr>
                <tr>
                <td style="width:100px">Document</td>
                <td style="padding-left:5px;">
                    <asp:TextBox ID="txt_doc" runat="server" Width="100%" TabIndex="1" Font-Names="Verdana" ></asp:TextBox></td>
                </tr>
                <tr>
                <td>Description</td>
                <td style="padding-left:5px;">
                    <asp:TextBox ID="txt_descr" runat="server" Width="100%" Height="100px" TextMode="MultiLine" Font-Names="Verdana"></asp:TextBox></td>
                </tr>
               <%-- <tr id="trcml" runat="server">
                        <td>
                            CML Comment</td>
                        <td valign="top" style="padding-left:1px;">
                            <asp:TextBox ID="txt_cmlcommt" runat="server" Height="100px" TextMode="MultiLine" 
                                Width="100%" Font-Names="Verdana"></asp:TextBox>
                        </td>
                    </tr>--%>
                <tr id="trstatus" runat="server">
                <td>Status</td>
                <td>
                    <asp:DropDownList ID="drstatus" runat="server">
                    <asp:ListItem Text="OPEN" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="CLOSED" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="left">
                    <asp:CheckBox ID="chkReplacePhoto" runat="server" AutoPostBack="true"/>Replace Existing Photo(s)</td>
                </tr>
                <tr id="Tr1" runat="server">
                <td>Select Photo</td>
                <td style="padding-left:5px;">
                     <input ID="myupload" runat="server" type="file" onchange="getFiles();" multiple />                     
                </td>                              
                </tr>  
                <tr>                
                <td colspan="2">
                <div id="display"></div>
                </td> 
                </tr>            
                <tr align="left">
                <td></td>
                <td align="left" style="padding-left:5px;">
                
                 <asp:DataList ID="dtSOphotos" runat="server" RepeatColumns="3"
                    ondeletecommand="dtSOphotos_DeleteCommand" DataKeyField="PhotoID" 
                    OnItemDataBound = "dtSOphotos_ItemDataBound" CellSpacing="0"
                    BorderStyle="None" CellPadding="0">                   
                    <ItemStyle ForeColor="#003399"/>
                <ItemTemplate>
                    <table>
                    <tr>
                        <td align="left" style="padding-bottom:10px;">
                        <img src='<%#Eval("photo") %>' id="imgPhoto" runat="server" width="100" height="100" /> 
                        <asp:Label ID="lblPhoto" Text='<%#Eval("photo") %>'  runat="server"  CssClass="hidden"></asp:Label>                  
                       </td>                  
                      <td align="left"  style="width:100px;">
                      <asp:LinkButton ID="lnkDeleteImage" Width="40px" Height="40px" runat="server" Text="sssss" CommandName="Delete"><i class="fa fa-times" style="font-size: xx-large; color: #CC0000;"></i></asp:LinkButton>                     
                      </td>
                    </tr>
                    </table>
                </ItemTemplate>
                
                <EditItemTemplate>
                    <table>
                    <tr>
                        <td align="left">
                        <asp:Label ID="lblPhoto" Text='<%#Eval("photo") %>'  runat="server"  CssClass="hidden"></asp:Label>                  
                       </td> 
                       <td>
                      <asp:LinkButton ID="lnkDeleteImage" runat="server" Text="sssss" CommandName="Delete"><i class="fa fa-times"></i></asp:LinkButton>
                     
                       
                        
                
            
                       </td>
                       
                    </tr>
                    </table>
                </EditItemTemplate>
                </asp:DataList>   
               
                </td>               
                </tr>
                <tr>
                <td></td>
                <td  align="left" style="padding-left:4px;padding-top:20px; padding-bottom:20px;">
                <table border="0">
                <tr align="left">                
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnupdateso" runat="server" Text="Update" Width="80px" 
                                onclick="btnupdateso_Click" />
                        </ContentTemplate>
                         <Triggers>
                        <asp:PostBackTrigger ControlID="btnupdateso" />
                        </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td style="padding-left:10px;">
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                        <ContentTemplate>
                        <asp:Button ID="btndelete_itm" runat="server" Text="Delete" Width="80px" 
                                onclick="btndelete_itm_Click" />
                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="btndelete_itm" ConfirmText="Are you sure want to delete the SO Item?">
                        </asp:ConfirmButtonExtender>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        
                    </td>
                    <td style="padding-left:10px;">
                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                     <asp:Button ID="btncancel_edit" runat="server" Text="Cancel"  Width="80px" 
                        onclick="btncancel_edit_Click" />
                    </ContentTemplate>
                    </asp:UpdatePanel>
                   
                </td>
                </tr>
                </table>
                </td>
                </tr>
                </table>
             </ContentTemplate>
                </asp:UpdatePanel>
            </div> 
            </div>                       
          </asp:Panel>
         
        <asp:Panel runat="server" ID="PopupHeader" Width="100%" BackColor="Gray" Height="10px"></asp:Panel>
        <asp:Button ID="btnDummy3" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender3" runat="server" 
                  TargetControlID="btnDummy3"  PopupControlID="pnlPopup3"
                  BackgroundCssClass="model-background">
                  </asp:ModalPopupExtender> 
          
         <asp:Panel ID="pnlPopup1" runat="server" Width="300px" Height="250px" BackColor="White" style="display:none"   >
            <div style="padding:10px">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                <ContentTemplate>
                <table style="width:100%;">
                <tr>
                <td>Response</td>
                </tr>
                <tr>
                <td>
                    <asp:TextBox ID="txtresp" runat="server" Width="100%" TextMode="MultiLine" Height="125px"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td align="center">
                    <asp:Button ID="btnupdate" runat="server" Text="Save" 
                        onclick="btnupdate_Click"  />
                    <asp:Button ID="Button1" runat="server" Text="Cancel" 
                        onclick="btnCancelEdit_Click"  />
                </td>
                </tr>
                </table>
             </ContentTemplate>
                </asp:UpdatePanel>
            </div>
                        
                  </asp:Panel>
         <asp:Button ID="btnDummy1" runat="server" Text="Button" style="display:none;"  />
         <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender1" runat="server" 
                  TargetControlID="btnDummy1"  PopupControlID="pnlPopup1"
                  BackgroundCssClass="modal">
                  </asp:ModalPopupExtender>  
               
          <asp:Panel ID="Panelcmt" runat="server" Width="300px" Height="250px" BackColor="White" style="display:none;"   >
            <div style="padding:10px">
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                <ContentTemplate>
                <table style="width:100%;">
                <tr>
                <td>CML Comment</td>
                </tr>
                <tr>
                <td>
                    <asp:TextBox ID="txt_cmlresp" runat="server" Width="100%" TextMode="MultiLine" Height="125px"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td align="center">
                    <asp:Button ID="btnupdate_cmt" runat="server" Text="Save" onclick="btnupdate_cmt_Click"
                          />
                    <asp:Button ID="btncancel_cmt" runat="server" Text="Cancel" onclick="btncancel_cmt_Click"
                         />
                </td>
                </tr>
                </table>
             </ContentTemplate>
                </asp:UpdatePanel>
            </div>
                        
                  </asp:Panel>
         <asp:Button ID="btndummy_cmt" runat="server" Text="Button" style="display:none;"  />
         <asp:ModalPopupExtender ID="ModalPopupExtender1_cmt" runat="server" 
                  TargetControlID="btndummy_cmt"  PopupControlID="Panelcmt"
                  BackgroundCssClass="modal">
                  </asp:ModalPopupExtender>  
    </div>
    </div>
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
