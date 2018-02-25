<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="soadd.aspx.cs" Inherits="CmlTechniques.CMS.soadd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
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
    <script src="../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script> 
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" /> 
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
         
        <div style="font-family: verdana; font-size: x-small">
        
        <table cellpadding="2" cellspacing="1" style="width:100%;background-color:#E7F9FF;color:#000;">
        <tr style="background-color:#B1E0F7;color:#000" >
        <td style="width:100px;">PACKAGE :</td>
        <td style="width:300px;">
            <asp:Label ID="lblpackage" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td>
        <td style="width:100px">SUBJECT :</td>
        <td ><asp:Label ID="lblsubject" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td>
        </tr>
        <tr style="background-color:#B1E0F7;color:#000">         
        <td >RECORDED BY :</td>
        <td><asp:Label ID="lblrecordby" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td>  
        <td>SUBMITTED TO :</td>
        <td><asp:Label ID="lblsubmitted" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td>      
        </tr>
        <tr style="background-color:#B1E0F7;color:#000" id="trBuilding" runat="server">        
        <td style="width:100px">BUILDING :</td>
        <td ><asp:Label ID="lblbuilding" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td>
        <td></td><td></td>
        </tr>
        </table>
        
         <table style="background-color:#092443;color:White;width:100%">
        <tr>
        <td style="width:110px" valign="top" >Details</td>
        <td style="width:300px"><asp:TextBox ID="txtdetails" runat="server" Width="300px" TextMode="MultiLine" Height="75px"></asp:TextBox></td>
        <td valign="top" width="110px">
                        Select Photo</td>
        <td valign="top">
                        <input ID="myupload" runat="server" class="multi" type="file" /></td>
        <td valign="top" align="left">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate><asp:Button ID="btnaddtr" runat="server" Text="add" onclick="btnaddtr_Click" Width="100px" />
            </ContentTemplate>
            <Triggers>
            <asp:PostBackTrigger ControlID="btnaddtr" />
            </Triggers>
            </asp:UpdatePanel><br />
            <asp:Label ID="lblid" runat="server" Text="" style="display:none"></asp:Label>
            <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
        </td>
        <td style="font-size: large; font-weight: bold;" align="left" valign="top">
            <asp:Label ID="lblsono" runat="server" ForeColor="Red"></asp:Label>
            <br />
            Site Observation Details</td>
        </tr>
        </table>
        <div id="myprogress" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div>
        </div>
            <div style="overflow:auto;font-size:x-small">
                <asp:ListView ID="mydetails" runat="server" DataKeyNames="so_itm_id" 
                    onitemdatabound="mydetails_ItemDataBound" 
                    onitemcommand="mydetails_ItemCommand" onitemdeleting="mydetails_ItemDeleting" 
                      >
                    <ItemTemplate>
                        <tr style="background-color:#F7F6F3;color: #000000;">
                        <td >
                        
                            <asp:ImageButton ID="delete" runat="server" CommandName="Delete" ImageUrl="~/TreeLineImages/minus.gif" />
                                </td>
                                <td>
                        <asp:Label ID="slno" runat="server" Width="50px" />
                        </td>
                            <td valign="top">
                                <%--<asp:Label ID="detailsLabel" runat="server" Text='<%# Eval("details") %>' Width="100%"  />--%>
                                <asp:TextBox ID="detailsLabel" runat="server" Text='<%# Eval("details") %>' Width="95%" TextMode="MultiLine" style="overflow:hidden" ReadOnly="true"></asp:TextBox>
                                <asp:Label ID="so_itm_idLabel" runat="server" Text='<%# Eval("so_itm_id") %>' style="display:none" />
                            </td>
                            <td>
                                <asp:GridView ID="myphoto" runat="server" AutoGenerateColumns="false" ShowHeader="false" BorderStyle="None" Width="250px">
                                <Columns>
                                <asp:TemplateField>
                                <ItemTemplate  >
                                <a href='<%# Eval("photo") %>' target="_blank">
                                <img id="myimg" runat="server" src='<%# Eval("photo") %>' height="100" width="250"  alt="" border="0" /></a>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                </asp:GridView>
                                <%--<asp:ListView ID="myphoto" runat="server">
                                <ItemTemplate>
                                <table>
                                <tr>
                                <td><img id="myimg" runat="server" src='<%# Eval("photo") %>' height="100"  alt="" /></td>
                                </tr>
                                </table>
                                </ItemTemplate>
                                </asp:ListView>--%>
                            </td>
                           <%-- <td valign="top">
                                <asp:Label ID="responseLabel" runat="server" Text='<%# Eval("response") %>' Width="350px" />
                            </td>--%>
                            <%--<td valign="top">
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                        Text="Response" style="cursor:pointer" Width="100px" />
                        </td>--%>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style="background-color:White;">
                        <td>
                        
                            <asp:ImageButton ID="delete" runat="server" CommandName="Delete" ImageUrl="~/TreeLineImages/minus.gif" />
                                </td>
                        <td valign="top">
                        <asp:Label ID="slno" runat="server" Width="50px" />
                        </td>
                            <td valign="top">
                                <%--<asp:Label ID="detailsLabel" runat="server" Text='<%# Eval("details") %>' 
                                  Width="100%"  />--%>
                                  <asp:TextBox ID="detailsLabel" runat="server" Text='<%# Eval("details") %>' Width="95%" TextMode="MultiLine" style="overflow:hidden" ReadOnly="true"></asp:TextBox>
                                <asp:Label ID="so_itm_idLabel" runat="server" Text='<%# Eval("so_itm_id") %>' 
                                    style="display:none" />
                            </td>
                            <td>
                                <asp:GridView ID="myphoto" runat="server" AutoGenerateColumns="false" 
                                    ShowHeader="false" BorderStyle="None" Width="250px">
                                <Columns>
                                <asp:TemplateField>
                                <ItemTemplate  >
                                <a href='<%# Eval("photo") %>' target="_blank">
                                <img id="myimg0" runat="server" src='<%# Eval("photo") %>' height="100" 
                                        width="250"  alt="" border="0" /></a>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                </asp:GridView>
                            </td>
                           <%-- <td valign="top">
                                <asp:Label ID="responseLabel" runat="server" Text='<%# Eval("response") %>' 
                                    Width="350px" />
                            </td>--%>
                            <%--<td valign="top">
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                        Text="Response" style="cursor:pointer" Width="100px" />
                        </td>--%>
                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        <table id="Table1" runat="server" 
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
                        <table runat="server" style="width:100%">
                            <tr runat="server">
                                <td runat="server">
                                    <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                        style="background-color: #5D7B9D;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;" width="100%" >
                                        <tr id="Tr2" runat="server" style="background-color:#5D7B9D;color: #000000;height:30px">
      <th style="width:20px"></th>
                                        <th id="Th1" runat="server" style="width:50px">
                                                ITM.NO</th>
                                            <th id="Th2" runat="server" >
                                                DETAILS</th>
                                                <th id="Th3" runat="server" style="width:250px">
                                                PHOTO</th>
                                            <%--<th id="Th4" runat="server" style="width:350px">
                                                RESPONSE</th>--%>
                                        </tr>
                                        <tr ID="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr3" runat="server">
                                <td id="Td2" runat="server" 
                                    style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <EditItemTemplate>
                        <tr style="background-color:#008A8C;color: #FFFFFF;">
                        <td valign="top">
                        <asp:Label ID="slno" runat="server" Width="100px" />
                        </td>
                            <td>
                                <%--<asp:TextBox ID="detailsTextBox" runat="server" Text='<%# Bind("details") %>' />--%>
                                <asp:Label ID="detailsLabel1" runat="server" Text='<%# Eval("details") %>' 
                                    Width="250px" />
                                <asp:Label ID="so_itm_idLabel1" runat="server" Text='<%# Eval("so_itm_id") %>' 
                                    style="display:none" />
                            </td>
                            <td>
                            <asp:GridView ID="myphoto" runat="server" AutoGenerateColumns="false" 
                                    ShowHeader="false" BorderStyle="None">
                                <Columns>
                                <asp:TemplateField>
                                <ItemTemplate  >
                                <a href='<%# Eval("photo") %>' target="_blank">
                                <img id="myimg1" runat="server" src='<%# Eval("photo") %>' height="100" 
                                        width="250"  alt="" border="0" /></a>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                </asp:GridView>
                            </td>
                            <td>
                                <asp:TextBox ID="responseTextBox" runat="server" 
                                    Text='<%# Bind("response") %>' Width="250px" Height="100px" 
                                    TextMode="MultiLine" />
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
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:dbCMLConnectionString %>" 
                    SelectCommand="load_so_details" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="so_id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>   
            <div>
            <center>
               <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
                <asp:Button ID="btnsave" runat="server" Text="Submit"  
                Width="100px" onclick="btnsave_Click" />
                   <asp:Button ID="btnBack" runat="server" Text="Back"  
                Width="100px" onclick="btnBack_Click" />
                <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
            </center>
            </div>    
        <asp:Panel ID="pnlPopup" runat="server" Width="300px" Height="300px"   >
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;background-color:White;height:300px" id="tblPopup">
                            <tr>
                                <td class="heading"  style="background-image: url('../images/headingbg_13.gif'); background-repeat: repeat-x;" >Select users to send notification!
     </td>
                            </tr>
                            
                            <tr>
                                <td align="left" height="200px" valign="middle"   bgcolor="White" >
                                <div style="overflow:auto;height:300px">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:CheckBoxList ID="chkuser" runat="server" BackColor="White" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"  >
                        </asp:CheckBoxList>
                                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>
                                    </td>
                            </tr>
                            <tr>
                                <td class="footer" height="30px" >
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                    <asp:Button ID="btnCont" runat="server" Text="Continue" OnClick="btnCont_Click"   /><asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" Visible="false"    />
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
                  
                    <asp:Button ID="btnDummy" runat="server" Text="Button" style="display:none;" />
                  <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" 
                  TargetControlID="btnDummy"  PopupControlID="pnlPopup"
                  BackgroundCssClass="modal">
                  </asp:ModalPopupExtender> 
    </div>
    </div>
    </form>
</body>
</html>
