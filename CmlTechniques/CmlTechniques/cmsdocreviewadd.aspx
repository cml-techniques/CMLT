<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cmsdocreviewadd.aspx.cs" Inherits="CmlTechniques.CMS.cmsdocreviewadd" %>

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
    </script>
    <link href="page.css" rel="stylesheet" type="text/css" />
     <link href="StyleSheet1.css" rel="stylesheet" type="text/css" /> 
    <style type="text/css">
        .grid_head
        {
        	background:url('images/head_bg.png'); 
        	background-repeat: repeat;
        	height:25px;
        	Font-Bold:True;
        	ForeColor:#000;
        }
        
    </style>
     <link href="Assets/css/Style.css" rel="stylesheet" type="text/css" />
         <link href="Assets/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
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
    <div style="font-family: verdana; font-size: x-small">
        
        <asp:Label ID="lblissuedto" runat="server" Text="" style="display:none" ></asp:Label>
        <div >
         <div>
         <table style="width:100%">
        <tr style="background-color:#092443;">
        <td valign="middle" colspan="4" style="height:35px" align="center">
            <asp:Label ID="lbltitle" runat="server" 
                Font-Bold="True" Font-Size="Large" ForeColor="White"></asp:Label>
            </td>
        </tr>
        <tr>
        <td valign="top" colspan="4" >
        <table cellpadding="2" cellspacing="1" style="width:100%;background-color:#E7F9FF;color:#000;">
        <tr style="background-color:#B1E0F7;color:#000" >
        <td style="width:100px;">PACKAGE :</td>
        <td style="width:300px;">
            <asp:Label ID="lblpackage" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label><asp:Label ID="lblsrvid" runat="server" style="display:none"></asp:Label>
                                        </td>
        <td style="width:100px">SUBJECT :</td>
        <td >
            <asp:Label ID="lblsubject" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                        </td>
        </tr>
        <tr style="background-color:#B1E0F7;color:#000">
        <td >RECORDED BY :</td>
        <td>
            <asp:Label ID="lblrecordby" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                        </td>
        <td>SUBMITTED TO :</td>
        <td>
            <asp:Label ID="lblsubmitted" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                        </td>
        </tr>
         <tr style="background-color:#B1E0F7;color:#000" id="trBuilding" runat="server">
        <td >BUILDING :</td>
        <td><asp:Label ID="lblBuilding" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td>
        <td></td>
        <td></td>
        </tr>
        </table>
         </td>
        </tr>
        <tr style="background-color: #E7F9FF">
        <td style="width:150px" align="center">
            DESCRIPTION</td>
        <td valign="top" style="width:300px">
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <ContentTemplate>
            <asp:TextBox ID="txtdesc" runat="server" Width="300px" TextMode="MultiLine" Height="75px"></asp:TextBox>
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        <td  style="width:150px" align="center">DETAILS</td>
        <td  valign="top" style="width:300px">
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
            <asp:TextBox ID="txtdetails" runat="server" Width="300px" TextMode="MultiLine" Height="75px"></asp:TextBox>
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="background-color: #E7F9FF">
        <td style="width:150px" align="center">
            &nbsp;</td>
        <td valign="top" style="width:300px">
            <asp:Label ID="lbldrno" runat="server" ForeColor="Red" style="display:none"></asp:Label>
        <asp:Label ID="lblprj" runat="server" ForeColor="Red" style="display:none"></asp:Label><asp:Label ID="lblid" runat="server" ForeColor="Red" style="display:none"></asp:Label>
                            </td>
        <td  style="width:150px" align="center">&nbsp;</td>
        <td  valign="top" style="width:300px" align="right">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnaddtr" runat="server" Text="Add Comment" onclick="btnaddtr_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
                            </td>
        </tr>
        <tr style="background-color:#fff">
        <td align="center" colspan="4" >
         <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
            <asp:GridView ID="myschedule_basket" runat="server" AutoGenerateColumns="False" Width="100%" Font-Names="Arial,Helvetica,sans-serif" Font-Size="X-Small" 
                        Font-Strikeout="False" onrowdatabound="myschedule_basket_RowDataBound" onrowcommand="myschedule_basket_RowCommand" >
                <Columns>
                    <%--<asp:CommandField ButtonType="Image" 
                        DeleteImageUrl="~/TreeLineImages/minus.gif" ShowDeleteButton="true">
                        <ItemStyle Width="10px" />
                    </asp:CommandField>--%>
                    <asp:ButtonField ButtonType="Image" ImageUrl="~/TreeLineImages/minus.gif" 
                        CommandName="remove" >
                        <ItemStyle Width="10px" />
                    </asp:ButtonField>
                    <asp:BoundField HeaderText="Sl.No">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="50px" />
                    </asp:BoundField>
                    <%--<asp:BoundField DataField="desc" HeaderText="DESCRIPTION">
                        <HeaderStyle HorizontalAlign="Center" Width="400px" />
                        <ItemStyle Width="400px" />
                    </asp:BoundField>--%>
                    <asp:TemplateField HeaderText="DESCRIPTION">
                    <ItemTemplate>                        
                        <asp:TextBox ID="txtdesc" runat="server" TextMode="MultiLine" Text='<%# Eval("Dr_Descr") %>' BorderStyle="None" ReadOnly="true" style="overflow:hidden"></asp:TextBox>
                     </ItemTemplate>
                        <ControlStyle Width="90%" />
                        <ItemStyle Width="40%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DETAILS">
                    <ItemTemplate >
                        <asp:TextBox ID="txtdetails" runat="server" TextMode="MultiLine" Text='<%# Eval("Dr_Details") %>' BorderStyle="None" ReadOnly="true" style="overflow:hidden"></asp:TextBox>
                     </ItemTemplate>
                        <ControlStyle Width="90%" />
                        <ItemStyle Width="40%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Temp_Id" />
                </Columns>
                <HeaderStyle CssClass="grid_head" />
            </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>   
                     
        </td>
        </tr>
        <tr style="background-color:#fff">
        <td align="left" colspan="4">
         NOTES:</td>
        </tr>
        <tr style="background-color:#fff">
        <td align="center" colspan="4">
        <asp:TextBox ID="txtnote" runat="server" 
                Width="100%" TextMode="MultiLine" Height="50px"></asp:TextBox>
                      </td>
        </tr>
        <tr style="background-color:#fff">
        <td align="center" colspan="4">
        <table>
        <tr>
        <td>
             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
             <ContentTemplate>
                 <asp:Button ID="btnsubmit" runat="server" Text="Submit DR" 
                     onclick="btnsubmit_Click" />
             </ContentTemplate>
             </asp:UpdatePanel>
            </td>
        <td>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
                 <asp:Button ID="btnexit" runat="server" Text="Cancel" 
                     onclick="btnexit_Click"  />
             </ContentTemplate>
             </asp:UpdatePanel>
            </td>
        </tr>        
        </table>
        </td>
        </tr>
        </table>
        <div>
        
        </div>
        </div>
        <div style="height:375px; overflow:auto;width:100%">
            <%--<asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>--%>
                    
                      <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
                                <asp:ObjectDataSource ID="dataSource" runat="server" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="GetData" TypeName="CmlTechniques.comment_basket" UpdateMethod="Update"  >
                                    <DeleteParameters>
                                    <asp:Parameter Name="id" Type="Int32" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                    <asp:Parameter Name="comment" Type="String" />
                                    </InsertParameters>
                                    </asp:ObjectDataSource>
            
            
            
            </div>
         <center>
         <div>
         <asp:Panel ID="pnlPopup" runat="server" Width="300px" Height="300px" style="display:none"  >
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;background-color:White;height:300px" id="tblPopup">
                            <tr>
                                <td class="heading"  style="background-image: url('images/headingbg_13.gif'); background-repeat: repeat-x;" >Select users to send notification!
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
                                    <asp:Button ID="btnCont" runat="server" Text="Continue" OnClick="btnCont_Click"   /><asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click"    />
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
                  BackgroundCssClass="modal" >
                  </asp:ModalPopupExtender>
         </div>
         </center>
         </div>
        
    </div>
    </div>
    </form>
</body>
</html>
