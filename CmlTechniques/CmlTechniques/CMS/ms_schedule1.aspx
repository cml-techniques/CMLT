<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ms_schedule1.aspx.cs" Inherits="CmlTechniques.CMS.ms_schedule1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
     <script src="../Assets/js/jquery.min.js" type="text/javascript"></script>
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
          .style1
          {
              height: 18px;
          }
    </style>
    <link href="../page.css" rel="stylesheet" type="text/css" />
        <link href="../Assets/css/Style.css" rel="stylesheet" type="text/css" />
    <link href="../Assets/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <asp:Label ID="lblindex" runat="server" Text="" style="display:none"></asp:Label>
     <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
    <div style="font-family: verdana; font-size: x-small;height:100%;position:fixed;width:100%">
     <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
    </asp:ScriptManager>
     <div class="fixedhead">
        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
            <ContentTemplate>
                <div id="infobar">
                    <div class="prjinfo">
                        <div class="pullleft font-big">
                            <a href="#" onclick="Fullscreen();"><i class="fa fa-align-justify"></i></a> MS :
                            <asp:Label ID="prj" runat="server" Style="color: #e6422c"></asp:Label></div>
                        <div class="pullright font-big">
                            <asp:Label ID="package" runat="server" Style="color: #e6422c"></asp:Label>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
        <div style="background-color:#092443;color:White; height:70px;top:32px;position:absolute;width:100%" id="mydiv" runat="server">
        <table style="width:600px;float:left">
        <tr>
        <td style="width:900px">
        <table id="filter_tbl" runat="server">
        <tr>
        <td style="width:200px">SERVICE</td>
        <td style="width:200px">SYSTEM</td>
        <td style="width:200px">DOC.TYPE</td>
        <td style="width:200px">STATUS</td>
</tr>
        <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drservices" runat="server" Width="100%" AutoPostBack="true" 
                    onselectedindexchanged="drservices_SelectedIndexChanged">
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
            
            </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drpackages" runat="server" Width="100%" >
            <asp:ListItem Text="All" Value="0"></asp:ListItem>
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
            
            </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drtype" runat="server" Width="100%">
            <asp:ListItem Text="All" Value="0"></asp:ListItem>
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
            
            </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drstatus" runat="server" Width="100%">
            <asp:ListItem Text="All" Value="0"></asp:ListItem>
            <asp:ListItem Text="ACCEPTED" Value="1"></asp:ListItem>
            <asp:ListItem Text="ACCEPTED WITH COMMENTS" Value="2"></asp:ListItem>
            <asp:ListItem Text="REVIEW" Value="3"></asp:ListItem>
            <asp:ListItem Text="DRAFT" Value="4"></asp:ListItem>
            <asp:ListItem Text="REJECTED" Value="5"></asp:ListItem>
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
        </table>
        </td>
        </tr>
        </table>
        
         <table style="float:left;margin-top:14.5px">
         <tr>
         <td>
         <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
            <asp:Button ID="btngenerate" runat="server" Text="Generate" Width="100px" Height="30px" 
                    CssClass="comment-btn" ToolTip="Generate" onclick="btngenerate_Click"  />
                    </ContentTemplate>
                    </asp:UpdatePanel>                
         </td>
         </tr>
         
         </table>
        
        <table style="float:right">
        <tr>
        <td width="70px" align="center" >
        <table>
        <tr>
        <td><asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <ContentTemplate>
                 <asp:Button ID="btnprint_new" runat="server" Text="Print" Width="100px" Height="30px" 
                    CssClass="comment-btn" ToolTip="Print" onclick="btnprint_new_Click"  />   
            </ContentTemplate>
            </asp:UpdatePanel></td>
        <td>
        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
                 <asp:Button ID="btnback" runat="server" Text="Back" Width="100px" Height="30px"
                    CssClass="comment-btn" ToolTip="Print" onclick="btnback_Click"   />   
            </ContentTemplate>
            </asp:UpdatePanel>
           </td>
        </tr>
        </table>
            
        </td>
        </tr>
        </table>
        
        </div>
     <div style="float:left;width:98.5%;top:102px;position:absolute">
        <table style="font-family: Verdana;font-size:x-small;background-color:#9EB6CE;width:100%;" cellspacing="1" border="0">
       <tr  style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
       
                            <td align="center" valign="middle"   width="6%" height="30px">
                                &nbsp;</td>
       
                            <td align="center" valign="middle"   width="6%">
                                ITEM NO</td>
       
                            <td align="left" valign="middle"   width="20%">
                                DOCUMENT TYPE</td>
                            <td align="center" valign="middle"  width="10%">
                                UPLOAD DATE</td>
                            <td align="center" valign="middle" width="20%" id="td_lbldes" runat="server" >
                                SUBMITTED BY</td>
                            <td align="center" valign="middle" width="10%" id="td_lbl0" runat="server" >
                                REVISION</td>
                            <td align="center" valign="middle" width="10%" id="td_lbl3" runat="server" >
                                DAYS LEFT TO REPLY</td>
                            <td align="center" valign="middle" width="18%" id="td_lbl1" runat="server" >
                                STATUS</td>
                        </tr>
                        </table>
        </div>
        <div style="position:relative; height:75%;width:100%;overflow-y:scroll;float:left;position:absolute;top:134px;">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            <asp:GridView ID="mymaster" runat="server" AutoGenerateColumns="False" 
                Width="100%" onrowdatabound="mymaster_RowDataBound" 
                Font-Names="Verdana" 
                    Font-Size="X-Small" ShowHeader="False" GridLines="None">
            <Columns>
            <asp:TemplateField>
            <ItemTemplate>
            <table id="inner_table" width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr style="height:30px;background-color:#00bfff">
            <%--<td style="width:50px">
            
                <asp:Button ID="Button1" runat="server" Text="-" CommandArgument = "Button1"  OnClick = "Button1_Click" Width="30px" style="cursor:pointer" />
                </td>--%>
            <td style="font-weight: bold;color:White;padding-left:10px;width:100%" align="left">
                <asp:Label ID="lbSer_Name" runat="server" Text='<%# Eval("SERVICE") %>' Width="300px"></asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width:100%">
               <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>--%>
              <asp:GridView ID="mysystem" runat="server" AutoGenerateColumns="False" 
                Width="100%"  OnRowDataBound="mysystem_RowDataBound" Font-Names="Verdana" 
                    Font-Size="X-Small" ShowHeader="False" GridLines="None">
            <Columns>
            <asp:TemplateField>
            <ItemTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr style="height:30px;background-color:#87cefa">
            <td style="font-weight: bold;padding-left:10px;width:100%" align="left">
            <asp:Label ID="lbSys_Name" runat="server" Text='<%# Eval("SYSTEM") %>' Width="300px"></asp:Label>
            <asp:Label ID="lbSer_Name" runat="server" Text='<%# Eval("SERVICE") %>' Width="300px" style="display:none"></asp:Label>
             <asp:Label ID="lbslno" runat="server" Text='<%# Eval("SLNO") %>' Width="300px" style="display:none"></asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width:100%">
            <asp:GridView ID="mydetails" runat="server" ShowHeader="false" AutoGenerateColumns="false" Width="100%" Font-Names="Verdana" 
                    Font-Size="X-Small" OnRowDataBound="mydetails_RowDataBound" OnRowCommand="mydetails_RowCommand">
                <Columns>
                <asp:ButtonField ButtonType="Button" Text="View" CommandName="Get"
                        ItemStyle-Width="6%" >
                    <ItemStyle Width="6%"  />
                    </asp:ButtonField>
                <asp:BoundField DataField="ITM" ItemStyle-Width="6%" >
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                    </asp:BoundField>

                <asp:BoundField DataField ="TYPE" ItemStyle-Width="20%" >
                    <ItemStyle Width="20%" HorizontalAlign="left" />
                    </asp:BoundField>
                 <asp:BoundField DataField="SDATE" ItemStyle-Width="10%" DataFormatString="{0:dd/MM/yyyy}" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>  
                <asp:BoundField DataField="SBY" ItemStyle-Width="20%" >
                    <ItemStyle Width="20%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="VERSION" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="DAYS_LR" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="STATUS" ItemStyle-Width="18%" >
                    <ItemStyle Width="18%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FILE_NAME" />
                </Columns>
                </asp:GridView>
            </td>
            </tr>
            </table>
            </ItemTemplate>
             </asp:TemplateField>
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
                <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div>   
    </div>
      <telerik:RadWindow ID="RadWindow1" runat="server" Modal="true" BorderStyle="None"
        Title="CMS | METHOD STATEMENTS" EnableShadow="true" Behaviors="Move"
        VisibleStatusbar="false" Skin="Metro" Width="500px" Height="170px">
        <ContentTemplate>
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>
                    <table cellpadding="5">
                        <tr>
                            <td style="width:150px">
                                Select Building
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                    <ContentTemplate>
                                        <telerik:RadDropDownList ID="rd_Building" runat="server" OnSelectedIndexChanged="rd_Building_SelectedIndexChanged"
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
                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
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
    </form>
        <script type="text/javascript">
    
      function pageLoad() {
      }
      function goback() {

          var index = document.getElementById('<%=lblindex.ClientID%>').innerHTML;

          parent.document.getElementById("content").src = "cmsreports.aspx?idx=" + index;
      }
     </script>
</body>
</html>
