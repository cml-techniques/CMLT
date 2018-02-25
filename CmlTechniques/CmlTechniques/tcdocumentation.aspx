<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tcdocumentation.aspx.cs" Inherits="CmlTechniques.CMS.tcdocumentation" %>

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
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="Scripts/jquery.MultiFile.js" type="text/javascript"></script>
     <link href="Assets/css/Style.css" rel="stylesheet" type="text/css" />
    <link href="Assets/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .gvHeaderRow
    {
        background-image:url('images/head_bg.png');
        background-repeat: repeat;
        font-family:Verdana;
        font-size:x-small;
        font-weight:normal;
        height:20px;
    }
        </style>
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
                            <a href="#" onclick="Fullscreen();"><i class="fa fa-align-justify"></i></a>&nbsp;CMS :
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
    <div style="font-family: verdana; font-size: x-small;height:100%;position:fixed;width:100%">
       
            <table style="width:100%;color:White" bgcolor="#092443">
        <tr>
        <td width="100px" >
            &nbsp;</td>
        <td width="100%" >
            <asp:Label ID="lblhead" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label><asp:Label
                ID="lblprj" runat="server" Text="" CssClass="hidden" ></asp:Label><asp:Label
                ID="lbldiv" runat="server" Text="" CssClass="hidden" ></asp:Label>
            </td>
        </tr>
        </table>
            <div style="float:left;width:98.5%">
        <table style="font-family: Verdana;font-size:x-small;background-color:#9EB6CE;width:100%;" cellspacing="1" border="0">
       <tr  style="background-image: url('images/head_bg.png'); background-repeat: repeat-x;">
       
                            <td align="center" rowspan="2" valign="middle"   width="6%">
                                &nbsp;</td>
       
                            <td align="center" rowspan="2" valign="middle"   width="6%">
                                ITEM NO</td>
       
                            <td align="center" rowspan="2" valign="middle"   width="10%">
                                ENG.REF</td>
                            <td align="center" colspan="4" valign="middle"  >
                                ASSET CODE</td>
                            <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbl0" runat="server" >
                                <asp:Label ID="lbloc" runat="server" Text="LOCATION"></asp:Label>
                            </td>
                            <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbl3" runat="server" >
                                TEST SHEETS</td>
                        </tr>
                        <tr style="background-image: url('images/head_bg.png'); background-repeat: repeat-x;">
                            <td align="center" valign="middle"  width="7%"  >
                                BUILDING/ ZONE</td>
                            <td align="center" valign="middle" width="7%"  >
                                CATEGORY</td>
                            <td align="center" valign="middle" width="7%"  >
                                FLOOR LEVEL</td>
                            <td align="center" valign="middle" width="7%"  >
              SEQ.NO</td>
                        </tr>
        <tr bgcolor="#092443" >
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drbuilding" runat="server" Width="100%" OnSelectedIndexChanged="drbuilding_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                 
            </td>
            <td>
           <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drcategory" runat="server" Width="100%" OnSelectedIndexChanged="drcategory_SelectedIndexChanged" AutoPostBack="true" >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
               </td>
            <td>
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drflevel" runat="server" Width="100%" OnSelectedIndexChanged="drflevel_SelectedIndexChanged" AutoPostBack="true"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td>
                &nbsp;</td>
            <td id="td0" runat="server">
            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drloc" runat="server" Width="100%" AutoPostBack="true" 
                        onselectedindexchanged="drloc_SelectedIndexChanged"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
            <td id="td_1" runat="server">
                &nbsp;</td>
        </tr>
                        </table>
        </div>
        <div style="position:relative; height:80%;width:100%;overflow-y:scroll;float:left;">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            <asp:GridView ID="mymaster" runat="server" AutoGenerateColumns="False" 
                Width="100%" onrowdatabound="mymaster_RowDataBound" 
                Font-Names="Verdana" 
                    Font-Size="X-Small" ShowHeader="False" GridLines="None" 
                    onrowcommand="mymaster_RowCommand">
            <Columns>
            <asp:TemplateField>
            <ItemTemplate>
            <table id="inner_table" width="100%">
            <tr style="background-image: url('images/head_bg.png'); background-repeat: repeat-x;">
            <td style="width:50px">
            
                <asp:Button ID="Button1" runat="server" Text="-" CommandArgument = "Button1"  OnClick = "Button1_Click" Width="30px" style="cursor:pointer" />
               
                </td>
<%--                <td style="width:100px">
                
                </td>--%>
            <td style="font-weight: bold;width:100%" align="left">
            <asp:Button ID="btnupload" runat="server" Text="MultiUpload" width="100px" CommandName="Multiupload" CommandArgument = '<%# Eval("Sys_Id") %>' style="cursor:pointer" />
                <asp:Label ID="lbSys_Name" runat="server" Text='<%# Eval("Sys_Name") %>' Width="300px"></asp:Label>
                <asp:Label ID="lbSys_Id" runat="server" Text='<%# Eval("Sys_Id") %>' style="display:none"></asp:Label>
            </td>
            </tr>
            <tr>
            <td colspan="2">
               <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>--%>
                <asp:GridView ID="mydetails" runat="server" ShowHeader="false" AutoGenerateColumns="false" Width="100%" OnRowCommand="mydetails_RowCommand" OnRowDataBound="mydetails_RowDataBound" Font-Names="Verdana" 
                    Font-Size="X-Small">
                <Columns>
                
                <asp:ButtonField ButtonType="Button" Text="Upload" CommandName="Upload"
                        ItemStyle-Width="6%" >
                    <ItemStyle Width="6%"  />
                    </asp:ButtonField>
                
                <asp:BoundField HeaderText="Itm.No" ItemStyle-Width="6%" >
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField ="E_b_ref" HeaderText="Engg.Reff" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                 <asp:BoundField DataField="B_Z" HeaderText="Building/Zone" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>  
                <asp:BoundField DataField="cat" HeaderText="Category" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                 
                <asp:BoundField DataField="F_lvl" HeaderText="Floor Level" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Seq_No" HeaderText="Seq.No" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Loc" HeaderText="Location" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
               <%-- <asp:BoundField DataField="testsheet" HeaderText="Test Sheet" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>--%>
                  <%--<asp:ButtonField ButtonType="Link" DataTextField="testsheet" HeaderText="Test Sheet" ItemStyle-Width="8%" CommandName="testsheet" >
                    <ItemStyle Width="8%" HorizontalAlign="Center" />
                    </asp:ButtonField>--%>
                    <asp:TemplateField HeaderText="delete">
                       <ItemTemplate >
                       <table style="width:100%" border="0">
                       <tr>
                       <td align="center">
                           <asp:LinkButton ID="lbllink" runat="server" Text='<%# Eval("testsheet")  %>' CommandName="testsheet" CommandArgument='<%# Container.DataItemIndex %>' style="background-color:Transparent;cursor:pointer;border:none;"></asp:LinkButton>
                           </td>
                       <td style="width:20px" align="center"><asp:ImageButton ID="btnbutton"  runat="server" ImageUrl="~/images/delete_.jpg"  CommandName="delete1"  CommandArgument='<%# Container.DataItemIndex %>'/></td>
                       </tr>
                       </table>
                       
                       </ItemTemplate>
                       
                           <ItemStyle Width="10%" HorizontalAlign="Center" />
                       
                       </asp:TemplateField>
                <asp:BoundField DataField="C_id" />
                <asp:BoundField DataField="Sys_Id" />
                <asp:BoundField DataField="testsheet" />
                </Columns>
                </asp:GridView>
                <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
                
            </td>
            </tr>
            </table>
            </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="myprogress" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div>
            <asp:Panel ID="pnlPopup" runat="server" Width="350px" Height="160px" style="padding:10px;display:none" BackColor="#d1def1"  >
            <div>
                
                <div>
                <table style="width:350px">
                <tr>
                <td width="100px" height="50px" valign="top">TEST SHEET</td>
                    <td valign="top">
                    <input type="file" id="myupload" class="multi" runat="server" />
                       <%-- <asp:FileUpload ID="FileUpload1" runat="server" />--%>
                    </td>
                </tr>
                <tr>
                <td valign="top" >&nbsp;</td>
                <td valign="top" >
                    </td>
                </tr>
                    <tr>
                        <td height="100px" id="tdsize" runat="server">
                            &nbsp;</td>
                        <td >
                        <table>
                        <tr>
                        <td><asp:Button ID="btnupload" runat="server" Text="Upload" onclick="btnupload_Click" /></td>
                        <td> <asp:Button ID="btncancel" runat="server" Text="Cancel" onclick="btncancel_Click" /></td>

                        </tr>
                        </table>
                            
                           
                           
                        </td>
                    </tr>
                </table>
               
                </div>
             
            </div>
                        
                  </asp:Panel>
                  
                    <asp:Button ID="btnDummy" runat="server" Text="Button" style="display:none;" />
                  <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" 
                  TargetControlID="btnDummy"  PopupControlID="pnlPopup"
                  BackgroundCssClass="modal">
                  </asp:ModalPopupExtender> 
                  
    </div>
    </div>
    <asp:UpdatePanel ID="UpdatePane5" runat="server">
  <ContentTemplate>
  <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1"  TargetControlID="lblqns" BackgroundCssClass="modal" >
</asp:ModalPopupExtender>
<asp:Panel ID="Panel1" runat="server" style="display:none; width:200px; background-color:White; border-width:2px; border-color:Black; border-style:solid; padding:20px;">
    <asp:Label ID="lblqns" Text="Do you want to delete the Test Sheet?" runat="server"></asp:Label>
    <br /><br />
        <asp:Button ID="Button3" runat="server" Text="Yes" OnClick="Delete_Click"  />
        <asp:Button ID="Button4" runat="server" Text="No" />
    <asp:Label ID="lblid" runat="server" Text="" style="display:none" ></asp:Label>
</asp:Panel>
</ContentTemplate>
  </asp:UpdatePanel>
    </form>
</body>
</html>
