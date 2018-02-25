﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cmsdocumentreview_details1.aspx.cs" Inherits="CmlTechniques.CMS.cmsdocumentreview_details1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <style type="text/css">
    .gvHeaderRow
    {
        background-image:url('../images/head_bg.png');
        background-repeat: repeat;
        font-family:Verdana;
        font-size:x-small;
        font-weight:normal;
        height:30px;
    }
    </style>
        <link href="../page.css" rel="stylesheet" type="text/css" />
         <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" /> 
</head>
<body>
    <form id="form1" runat="server">
    <div >
         <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
         </asp:ToolkitScriptManager>
        <div style="font-family: verdana; font-size: x-small;height:100%;width:100%">
         <div   >
         <table style="background-color:#092443;color:White;width:100%">
        <tr>
        <td style="width:110px"><%--<a href="#" onclick="window.open('../cmsdocreviewadd.aspx','','left=210,top=100,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');">Add Details</a>--%>
            <asp:Label ID="lblid" runat="server" Text="" style="display:none"></asp:Label>
            <asp:Button ID="btn" runat="server" Text="Add Details" onclick="btn_Click" /></td>
        <%--<td style="width:300px"><asp:TextBox ID="txtdetails" runat="server" Width="300px"></asp:TextBox></td>
        <td><asp:Button ID="btnaddtr" runat="server" Text="add" onclick="btnaddtr_Click" Width="100px" /></td>--%>
        <td style="font-size: x-large; font-weight: bold;" align="center">
            <asp:Label ID="lbldrno" runat="server" ForeColor="Red"></asp:Label>Document Review Details</td>
            <td align="right" style="width:320px">
            <table border="0" cellpadding="0" cellspacing="0">
            <tr>
             <td style="width:80px">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                 <asp:Button ID="btnedit" runat="server" Text="Edit Item" Width="75px" 
                        onclick="btnedit_Click" />
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width:80px">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btndelete" runat="server" Text="Delete DR" Width="80px" 
                        onclick="btndelete_Click"/>
                    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"  TargetControlID="btndelete" ConfirmText="Are you sure want to Delete the DR?">
                    </asp:ConfirmButtonExtender>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td width="80px">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnreissue" runat="server" Text="Reissue" 
                    onclick="btnreissue_Click" Width="80px" />
            </ContentTemplate>
            </asp:UpdatePanel>
         </td>
            <td width="75px">
            <asp:Button ID="btnprint" runat="server" Text="Print" OnClick="btnprint_Click" Width="75px" />
            </td>
            </tr>
            </table>
            </td>
           
        </tr>
        </table>
        </div>
            <asp:Label ID="lblprjcode" runat="server" Text="" CssClass="hidden"></asp:Label><asp:Label ID="lblsrvid" runat="server" Text="" CssClass="hidden"></asp:Label>
        <div id="forPrint" runat="server" name="mydiv1" style="height:100%;width:100% ">
        <table style="width:100%" border="0" cellpadding="0" cellspacing="0">
        <tr >
        <td>
        <table style="width:100%; font-weight: bold; text-align:center;background-color:#092443" cellspacing="1" >
        <tr style="background-color:#c1c1c1">
        <td height="30px" style="width: 100px">PACKAGE :</td>
        <td style="width:250px">
            <asp:Label ID="lbpkg" runat="server" Text=""></asp:Label>
            </td>
        <td align="center" colspan="6" style="font-size: large">DOCUMENT REVIEW</td>
        </tr>
        <tr style="background-color:#c1c1c1">
        <td height="30px">Document(s) :</td>
        <td>
            <asp:Label ID="lbdoc" runat="server" Text=""></asp:Label>
            </td>
        <td style="width: 100px">Sheet No.</td>
        <td style="width:150px">
            <asp:Label ID="lbno" runat="server" Text=""></asp:Label>
            <asp:Label ID="lbluid" runat="server" Text="" style="display:none"></asp:Label>
            </td>
        <td style="width: 100px">Recorded By :</td>
        <td style="width:250px">
            <asp:Label ID="lbcreated" runat="server" Text=""></asp:Label>
            </td>
        <td style="width: 100px">Submitted to:</td>
        <td style="width: 250px">
            <asp:Label ID="lbissued" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblissued" runat="server" Text="" style="display:none"></asp:Label>
            </td>
        </tr>
        </table>
        </td>
        </tr>
        </table>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
             <%--<asp:ListView ID="mydetailsview" runat="server" 
                DataKeyNames="dr_itm_id" style="width:100%" 
                onitemcanceling="mydetailsview_ItemCanceling" 
                onitemediting="mydetailsview_ItemEditing" 
                onitemcommand="mydetailsview_ItemCommand" 
                onitemupdating="mydetailsview_ItemUpdating" 
                onitemdatabound="mydetailsview_ItemDataBound" 
                onitemcreated="mydetailsview_ItemCreated" 
                onselectedindexchanging="mydetailsview_SelectedIndexChanging">
                <ItemTemplate>
                    <tr style="background-color: #F7F6F3;color: #333333;">
                    <td valign="top" align="center">
                    <asp:Label ID="lbitm" runat="server" Width="40px"   />
                    </td>
                        <td valign="top" >
                    <asp:Label ID="lbdes" runat="server" Text='<%# Eval("description") %>' Width="250px"   />
                    </td>
                        <td valign="top" >
                            <asp:Label ID="lbdet" runat="server" Text='<%# Eval("details") %>' Width="308px"    />
                            <asp:Label ID="lbid" runat="server" Text='<%# Eval("dr_itm_id") %>' style="display:none" />
                        </td>
                        <td valign="top" >
                            <asp:Label ID="lbres" runat="server" Text='<%# Eval("response") %>' Width="300px"  />
                        </td>
                        <td valign="top" ><asp:Label ID="lbcom" runat="server" Text='<%# Eval("comment") %>' Width="250px"></asp:Label></td>
                        <td valign="top">
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                        Text="Response" style="cursor:pointer" Width="95px"  />
                                         <asp:Button ID="btncomt" runat="server" CommandName="Select" 
                                        Text="Comment" style="cursor:pointer" Width="95px" />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr style="background-color: White;color: #284775;">
                     <td valign="top" align="center">
                    <asp:Label ID="lbitm" runat="server" Width="40px"   />
                    </td>
                    <td valign="top">
                    <asp:Label ID="lbdes" runat="server" Text='<%# Eval("description") %>' Width="250px"    />
                    </td>
                        <td valign="top">
                            <asp:Label ID="lbdet" runat="server" Text='<%# Eval("details") %>' Width="308px" />
                            <asp:Label ID="lbid" runat="server" Text='<%# Eval("dr_itm_id") %>' style="display:none" />
                        </td>
                        <td valign="top">
                            <asp:Label ID="lbres" runat="server" Text='<%# Eval("response") %>' Width="300px" />
                        </td>
                        <td valign="top"><asp:Label ID="lbcom" runat="server" Text='<%# Eval("comment") %>' Width="250px"></asp:Label></td>
                        <td valign="top">
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                        Text="Response" style="cursor:pointer" Width="95px" />
                                        <asp:Button ID="btncomt" runat="server" CommandName="Select" 
                                        Text="Comment" style="cursor:pointer" Width="95px" />
                        </td>
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
                        <td>
                            <asp:TextBox ID="_dateTextBox" runat="server" Text='<%# Bind("_date") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="uidTextBox" runat="server" Text='<%# Bind("uid") %>' />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <LayoutTemplate>
                    <table id="Table2" runat="server">
                        <tr id="Tr1" runat="server">
                            <td id="Td1" runat="server">
                                <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                    style="background-color: #5D7B9D;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif; width:100%">
                                    <tr id="Tr2" runat="server" style="background-color: #5D7B9D;color: #333333;height:30px">
                                    <th>ITEM.NO</th>
                                    <th id="Th3" runat="server" height="30px">
                                            DESCRIPTION</th>
                                        <th id="Th1" runat="server" height="30px">
                                            DETAILS</th>
                                        <th id="Th2" runat="server">
                                            RESPONSE</th>
                                            <th>CML COMMENTS</th>
                                    </tr>
                                    <tr ID="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="Tr3" runat="server">
                            <td id="Td2" runat="server" 
                                style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <EditItemTemplate>
                    <tr style="background-color: #999999;">
                     <td valign="top" align="center">
                    <asp:Label ID="lbitm" runat="server" Width="40px"   />
                    </td>
                     <td valign="top">
                    <asp:Label ID="lbdes" runat="server" Text='<%# Eval("description") %>' Width="250px"  />
                    </td>
                        <td valign="top">
                            <asp:Label ID="lbdet" runat="server" 
                                Text='<%# Eval("details") %>' Width="308px" />
                                <asp:Label ID="lbid" runat="server" Text='<%# Eval("dr_itm_id") %>' style="display:none" />
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="responseTextBox" runat="server" 
                                 Width="300px" />
                        </td>
                        <td valign="top">
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                                Text="Commit Comments & Exit" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                Text="Exit without saving" />
                        </td>
                    </tr>
                </EditItemTemplate>
                <SelectedItemTemplate>
                    <tr style="background-color: #E2DED6;font-weight: bold;color: #333333;">
                        <td>
                            <asp:Label ID="dr_itm_idLabel" runat="server" Text='<%# Eval("dr_itm_id") %>' />
                        </td>
                        <td>
                            <asp:Label ID="detailsLabel" runat="server" Text='<%# Eval("details") %>' />
                        </td>
                        <td>
                            <asp:Label ID="responseLabel" runat="server" Text='<%# Eval("response") %>' />
                        </td>
                        <td>
                            <asp:Label ID="_dateLabel" runat="server" Text='<%# Eval("_date") %>' />
                        </td>
                        <td>
                            <asp:Label ID="uidLabel" runat="server" Text='<%# Eval("uid") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>--%>
                <asp:GridView ID="mygrid_details" runat="server" AutoGenerateColumns="False" 
                    Width="100%" onrowdatabound="mygrid_details_RowDataBound" 
                    onrowcommand="mygrid_details_RowCommand">
                <HeaderStyle CssClass="gvHeaderRow" />
                <Columns>
                <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chkselect" runat="server" />
                    
                </ItemTemplate>
                <ItemStyle Width="25px" HorizontalAlign="Center" />
                <ControlStyle Width="25px" />
                </asp:TemplateField>
                <asp:BoundField HeaderText="ITEM NO." >
                    <HeaderStyle HorizontalAlign="Center" Width="40px" />
                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="DESCRIPTION">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtdesc" runat="server" TextMode="MultiLine" Text='<%# Eval("description") %>'  BorderStyle="None" ReadOnly="true" style="overflow:hidden" ></asp:TextBox>
                                            <%--<asp:Label ID="lbldesc" runat="server" Text='<%# Eval("description") %>'></asp:Label>--%>
                                            <%--<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>--%>
                                         </ItemTemplate>
                                            <ControlStyle Width="95%" />
                                            <ItemStyle Width="25%" />
                                        </asp:TemplateField>
                <%--<asp:BoundField DataField="description" HeaderText="DESCRIPTION" >
                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                    </asp:BoundField>--%>
                    <asp:TemplateField HeaderText="DETAILS">
                                        <ItemTemplate >
                                            <asp:TextBox ID="txtdetails" runat="server" TextMode="MultiLine" Text='<%# Eval("details") %>'  BorderStyle="None" ReadOnly="true" style="overflow:hidden"></asp:TextBox>
                                            <%--<asp:Label ID="lbldesc" runat="server" Text='<%# Eval("details") %>'></asp:Label>--%>
                                         </ItemTemplate>
                                            <ControlStyle Width="95%" />
                                            <ItemStyle Width="25%" />
                                        </asp:TemplateField>
                <%--<asp:BoundField DataField="details" HeaderText="DETAILS" >
                    <ItemStyle Width="20%" />
                    </asp:BoundField>--%>
                    <asp:TemplateField HeaderText="PHOTO">
                    <ItemTemplate>
                        <asp:Label ID="lblid" runat="server" style="display:none" Text='<%# Eval("dr_itm_id") %>'></asp:Label>
                        <asp:GridView ID="myphoto" runat="server" AutoGenerateColumns="false" ShowHeader="false" BorderStyle="None" Width="100%">
                                <Columns>
                                <asp:TemplateField>
                                <ItemTemplate  >
                                <a href='<%# Eval("dr_image") %>' target="_blank">
                                <img id="myimg" runat="server" src='<%# Eval("dr_image") %>' height="100" width="120"  alt="" border="0" /></a>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                </asp:GridView>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                    </asp:TemplateField>
                <asp:BoundField DataField="response" HeaderText="RESPONSE" >
                    <ItemStyle Width="18%" />
                    </asp:BoundField>
                <asp:BoundField DataField="comment" HeaderText="CML COMMENTS" >
                    <ItemStyle Width="18%" />
                    </asp:BoundField>
                <asp:TemplateField>
                <ItemTemplate>
                <table id="itbl">
                <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnresp" runat="server" Text="Response" Width="75px" CommandName="resp" CommandArgument='<%#DataBinder.Eval(Container, "DataItemIndex")%>' Font-Size="10px"   />
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                </tr>
                <tr>
                <td>
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btncml" runat="server" Text="Comments" Width="75px" CommandName="comm" CommandArgument='<%#DataBinder.Eval(Container, "DataItemIndex")%>' Font-Size="10px"   />
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                </tr>
                </table>
                </ItemTemplate>
                <ItemStyle Width="75px" />
                </asp:TemplateField>    
                    <asp:BoundField DataField="dr_itm_id" />
                    <asp:BoundField DataField="description" />
                </Columns>
                </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
           <br />
           <div>
               <table style="width:100%">
               <tr>
               <td ><b>NOTES:</b></td>
               </tr>
               <tr>
               <td style="height:auto">
                   <asp:Label ID="lblnote" runat="server" Text=""></asp:Label>
               </td>
               </tr>
               </table>
           </div>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:dbCMLConnectionString %>" 
                SelectCommand="Load_doc_review_details" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="dr_id" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
            
            </div>
         <asp:Panel ID="pnlPopup" runat="server" Width="300px" Height="200px" BackColor="White" style="padding:5px;display:none;"   >
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <table style="width:100%">
                <tr>
                <td>CML Comments</td>
                </tr>
                <tr>
                <td>
                
                    <asp:TextBox ID="txtcomments" runat="server" Width="100%" TextMode="MultiLine" Height="150px"></asp:TextBox>
                
                </td>
                </tr>
                <tr>
                <td align="center">
                    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" />
                    <asp:Button ID="btnexit" runat="server" Text="Cancel" onclick="btnexit_Click" />
                </td>
                </tr>
                </table>
             
             
             </ContentTemplate>
                </asp:UpdatePanel>
            </div>
                        
                  </asp:Panel>
                  
                    <asp:Button ID="btnDummy" runat="server" Text="Button" style="display:none;"  />
                  <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" 
                  TargetControlID="btnDummy"  PopupControlID="pnlPopup"
                  BackgroundCssClass="model-background">
                  </asp:ModalPopupExtender> 
          <asp:Panel ID="pnlPopup1" runat="server" Width="300px" Height="200px" BackColor="White" style="padding:5px;display:none"   >
            <div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                <table style="width:100%">
                <tr>
                <td>Response</td>
                </tr>
                <tr>
                <td>
                    <asp:TextBox ID="txtresp" runat="server" Width="100%" TextMode="MultiLine" Height="150px"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td align="center">
                    <asp:Button ID="btnupdate" runat="server" Text="Save" 
                        onclick="btnupdate_Click"  />
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" 
                        onclick="btncancel_Click"  />
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
                  BackgroundCssClass="model-background">
                  </asp:ModalPopupExtender>  
          <asp:Panel ID="pnlPopup2" runat="server" Width="400px" Height="140px" BackColor="#83C8EE" style="padding:5px;display:none"   >
            <div style="background-color:#fff;padding:5px;">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                <h4 style="margin:3px">DR - Reissue</h4>
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
              <asp:Panel ID="pnlPopup3" runat="server" Width="600px" Height="340px" BackColor="#56BDEF" style="padding:10px;display:none"   >
            <div>
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lbldrdid" runat="server" Text="" CssClass="hidden"></asp:Label>
                <table style="width:100%">
                <tr>
                <td style="width:150px">DOCUMENT</td>
                <td>
                    <asp:TextBox ID="txt_doc" runat="server" Width="100%"></asp:TextBox></td>
                </tr>
                <tr>
                <td>DESCRIPTION</td>
                <td>
                    <asp:TextBox ID="txt_descr" runat="server" Width="100%" Height="100px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                <td>DETAILS</td>
                <td>
                    <asp:TextBox ID="txt_details" runat="server" Width="100%" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                <td></td>
                <td></td>
                </tr>
                <tr>
                <td></td>
                <td>
                <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnupdatedr" runat="server" Text="Update" Width="80px" 
                            onclick="btnupdatedr_Click" />
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                    <asp:Button ID="btndelete_itm" runat="server" Text="Delete" Width="80px" 
                            onclick="btndelete_itm_Click" />
                            <asp:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="btndelete_itm" ConfirmText="Are you sure want to delete the DR Item?">
                    </asp:ConfirmButtonExtender>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    
                </td>
                <td>
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
                        
                  </asp:Panel>
                  
                    <asp:Button ID="btnDummy3" runat="server" Text="Button" style="display:none;"  />
                  <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender3" runat="server" 
                  TargetControlID="btnDummy3"  PopupControlID="pnlPopup3"
                  BackgroundCssClass="model-background">
                  </asp:ModalPopupExtender>                    
         </div>
        
    </div>
    </form>
</body>
</html>
