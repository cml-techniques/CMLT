<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ms_schedule.aspx.cs" Inherits="CmlTechniques.CMS.ms_schedule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
      function goback() {

          var index = document.getElementById('<%=lblindex.ClientID%>').innerHTML;

          parent.document.getElementById("content").src = "cmsreports.aspx?idx=" + index;
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <asp:Label ID="lblindex" runat="server" Text="" style="display:none"></asp:Label>
     <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
    <div style="font-family: verdana; font-size: x-small;height:100%;position:fixed;width:100%">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div style="background-color:#092443;color:White;height:45px" id="mydiv" runat="server">
        <table style="width:100%">
        <tr>
        <td style="width:1000px">
        <table id="filter_tbl" runat="server">
        <tr>
        <td style="width:300px">SERVICE</td>
        <td style="width:200px">SYSTEM</td>
        <td style="width:200px">DOC.TYPE</td>
        <td style="width:200px">STATUS</td>
        <td style="width:200px" rowspan="2">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
            <asp:Button ID="btngenerate" runat="server" Text="Generate" Width="100px" Height="30px"
                    onclick="btngenerate_Click" CssClass="comment-btn" ToolTip="View Summary" />
            </ContentTemplate>
            </asp:UpdatePanel>
                                     </td>
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
        <td width="70px" align="center" >
            &nbsp;</td>
        <td width="70px" align="center" id="tdback" runat="server" >
        
        </td>
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
     <div style="float:left;width:98.5%">
        <table style="font-family: Verdana;font-size:x-small;background-color:#9EB6CE;width:100%;" cellspacing="1" border="0">
       <tr  style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
       
                            <td align="center" valign="middle"   width="6%" height="30px">
                                &nbsp;</td>
       
                            <td align="center" valign="middle"   width="6%">
                                ITEM NO</td>
       
                            <td align="center" valign="middle"   width="15%">
                                DOCUMENT TYPE</td>
                            <td align="center" valign="middle"  width="15%">
                                SUBMISSION DATE</td>
                            <td align="center" valign="middle" width="18%" id="td_lbldes" runat="server" >
                                SUBMITTED BY</td>
                            <td align="center" valign="middle" width="10%" id="td_lbl0" runat="server" >
                                REVISION</td>
                            <td align="center" valign="middle" width="10%" id="td_lbl3" runat="server" >
                                DAYS LEFT TO REPLY</td>
                            <td align="center" valign="middle" width="20%" id="td_lbl1" runat="server" >
                                STATUS</td>
                        </tr>
                        </table>
        </div>
        <div style="position:relative; height:80%;width:100%;overflow-y:scroll;float:left;">
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
                <asp:BoundField DataField ="TYPE" ItemStyle-Width="15%" >
                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                    </asp:BoundField>
                 <asp:BoundField DataField="SDATE" ItemStyle-Width="15%" DataFormatString="{0:dd/MM/yyyy}" >
                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                    </asp:BoundField>  
                <asp:BoundField DataField="SBY" ItemStyle-Width="18%" >
                    <ItemStyle Width="18%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="VERSION" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="DAYS_LR" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="STATUS" ItemStyle-Width="20%" >
                    <ItemStyle Width="20%" HorizontalAlign="Center" />
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
    </form>
</body>
</html>
