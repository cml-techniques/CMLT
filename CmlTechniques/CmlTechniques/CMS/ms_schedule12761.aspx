<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ms_schedule12761.aspx.cs"
    Inherits="CmlTechniques.CMS.ms_schedule12761" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
   <style type="text/css">
    .gridLines
    {
        border:none;
    }  
    .gridLines tr
    {
        border-left:none;
        border-right:none;
        height:30px;
    }

    .gridLines td:last-child
    {
        border-right:none;
    }
    .gridLines tr:last-child
    {
        border-bottom: none;
    }
   </style>

    <script type="text/javascript">

        function pageLoad() {
        }
    
    </script>

    <script type="text/javascript">
        function goback() {

            var index = document.getElementById('<%=lblindex.ClientID%>').innerHTML;

            parent.document.getElementById("content").src = "cmsreports.aspx?idx=" + index;
        }
      function  goclick(id,count)
        {
         if (parseInt(count)<=1)
         {
         alert('Previous Version Not Available');
         return;
         }
        var e=document.getElementById('dv'+id);
                 if (e) {
                     if (e.style.display == 'none') {
                     
                    
                     
                     
                         e.style.display = 'table-cell';
                         e.style.visibility = 'visible';
                         
                         document.getElementById('btnexpand'+id).value="-";
                       
                     }
                     else {
                         e.style.display = 'none';
                         e.style.visibility = 'hidden';
                          document.getElementById('btnexpand'+id).value="+";
   
                     }
                 }
       
        }
    
    </script>

    <link href="../page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 34px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="lblindex" runat="server" Text="" Style="display: none"></asp:Label>
    <div style="font-family: verdana; font-size: x-small; height: 100%; position: fixed;
        width: 100%">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div style="background-color: #092443; color: White; height: 50px" id="mydiv" runat="server">
            <table style="width:100%">
                <tr>
                    <td style="width: 900px">
                        <table id="filter_tbl" runat="server">
                            <tr>
                                <td style="width: 200px">
                                    SERVICE
                                </td>
                                <td style="width: 200px">
                                    SYSTEM
                                </td>
                                <td style="width: 200px">
                                    STATUS
                                </td>
                                <td style="width: 200px" rowspan="2" valign="bottom">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btngenerate" runat="server" Text="View" Width="70px" Height="30px" OnClick="btngenerate_Click"
                                    CssClass="comment-btn"
                                    ToolTip="View Summary" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="drservices" runat="server" Width="100%" AutoPostBack="true"
                                                OnSelectedIndexChanged="drservices_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="drpackages" runat="server" Width="100%">
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
                                                <asp:ListItem Text="A" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="B" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="C" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="REVIEW" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="NONE" Value="5"></asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="70px" align="center">
                        &nbsp;</td>
                    <td width="70px" align="center" id="tdback" runat="server">
                        
                    </td>
                    <td width="70px" align="center" valign="bottom">
                    <table>
                    <tr>
                    <td valign="bottom" class="style1"><asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="Button1" runat="server" Text="Print" Width="70px" Height="30px" 
                                    CssClass="comment-btn" onclick="Button1_Click"  />
                            </ContentTemplate>
                        </asp:UpdatePanel></td>
                    <td valign="bottom" class="style1">
                        <asp:Button ID="Button2" runat="server" Text="Back" CssClass="comment-btn" Width="70px" Height="30px" OnClientClick="goback();" />
                        </td>
                    </tr>
                    </table>
                        
                    </td>
                </tr>
            </table>
        </div>
        <div style="float: left; width: 98.5%">
            <table style="font-family: Verdana; font-size: x-small; background-color: #9EB6CE;
                width: 100%;" cellspacing="1" border="0">
                <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                    <td align="center" valign="middle" width="9%" height="30px">
                        &nbsp;
                    </td>
                    <td align="center" valign="middle" width="5%">
                        Item No.
                    </td>
                    <td align="center" valign="middle" width="5%">
                        Revision
                    </td>
                    <td align="center" valign="middle" width="15%" id="td_lbl0" runat="server">
                        Issued By
                    </td>
                    <td align="center" valign="middle" width="10%" id="td2" runat="server">
                        Planned Submission Date
                    </td>
                    <td align="center" valign="middle" width="10%" id="td1" runat="server">
                        CML Received Date
                    </td>
                    <td align="center" valign="middle" width="7%">
                        Date Overdue
                    </td>
                    <td align="center" valign="middle" width="10%" id="td_lbldes" runat="server">
                        CML Received Date
                    </td>
                    <td align="center" valign="middle" width="10%" id="td_lbl3" runat="server">
                        No. of Comments
                    </td>
                    <td align="center" valign="middle" width="9%" id="td3" runat="server">
                        Issued with BHC
                    </td>
                    <td align="center" valign="middle" width="10%" id="td_lbl1" runat="server">
                        Status
                    </td>
                </tr>
            </table>
        </div>
        <div style="position: relative; height: 75%; width: 100%; overflow-y: scroll; float: left;">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            <asp:GridView ID="mymaster" runat="server" 
        AutoGenerateColumns="False" Width="100%"
                        OnRowDataBound="mymaster_RowDataBound" 
        Font-Names="Verdana" Font-Size="X-Small"
                        ShowHeader="False" GridLines="None">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table id="inner_table" width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr style="height: 30px; background-color: #00bfff">
                                            <%--<td style="width:50px">
            
                <asp:Button ID="Button1" runat="server" Text="-" CommandArgument = "Button1"  OnClick = "Button1_Click" Width="30px" style="cursor:pointer" />
                </td>--%>
                                            <td style="font-weight: bold; color: White; padding-left: 10px; width: 100%" 
                                                align="left">
                                                <asp:Label ID="lbSer_Name" runat="server" Text='<%# Eval("SERVICE") %>' 
                                                    Width="100%"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                             <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>--%>
                                                <asp:GridView ID="mysystem" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    OnRowDataBound="mysystem_RowDataBound" Font-Names="Verdana" Font-Size="X-Small"
                                                    ShowHeader="False" GridLines="None">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr style="height: 30px; background-color: #87cefa">
                                                                        <td style="font-weight: bold; padding-left: 10px; width: 100%" align="left">
                                                                            <asp:Label ID="lbSys_Name" runat="server" Text='<%# Eval("SYSTEM") %>' 
                                                                                Width="300px"></asp:Label>
                                                                            <asp:Label ID="lbSer_Name" runat="server" Text='<%# Eval("SERVICE") %>' Width="300px"
                                                                                Style="display: none"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%;border:none" >
                                                                          <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>--%>
                                                                            <asp:GridView ID="mydetails" runat="server" ShowHeader="false" AutoGenerateColumns="false"
                                                                                Width="100%" Font-Names="Verdana" Font-Size="X-Small" OnRowDataBound="mydetails_RowDataBound"
                                                                                OnRowCommand="mydetails_RowCommand" >
                                                                                <Columns>
                                                                                <asp:TemplateField>
                                                                               <ItemTemplate>
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr style="height: 30px;">
                                                                     <td  style="width:9%;text-align:left;border-right:1px solid;"> 
                                                                     <asp:Button runat= "server"  id="btnview"  Text="View" CommandName="View" CommandArgument='<%# Container.DataItemIndex %>' />
                                                                     <input type="button" id='btnexpand<%# Eval("ITMNO") %>'  value="+" onclick="goclick('<%# Eval("ITMNO") %>','<%# Eval("REVISION") %>');"  style="width:30px"   />
                                                                        <asp:Label ID="lbSys_Name" runat="server" Text='<%# Eval("SYSTEM") %>' 
                                                                                Width="300px" style="display:none"></asp:Label>
                                                                     </td>
                                                                    <td  style="width:5%;text-align:center;border-right:1px solid;"> <asp:Label ID="lblitemno" runat="server" Text='<%# Eval("ITMNO") %>' >
                                                                                </asp:Label></td>
                                                                                <td style="width:5%;text-align:center;border-right:1px solid;"> <asp:Label ID="lblrevision" runat="server" Text='<%# Eval("REVISION") %>' /></td>
                                                                                 <td style="width:15%;text-align:left;border-right:1px solid;margin-left:5px"><asp:Label ID="lblissued" runat="server" Text='<%# Eval("ISSUED") %>' /></td>
                                                                                  <td style="width:10%;text-align:center;border-right:1px solid;"><asp:Label ID="lblpsubdate" runat="server" Text='<%# Eval("PSUB_DATE") %>' /></td>
                                                                                   <td style="width:10%;text-align:center;border-right:1px solid;"><asp:Label ID="lblcmlrecdate" runat="server" Text='<%# Eval("CMLREC_DATE") %>' /></td>
                                                                                    <td style="width:7%;text-align:center;border-right:1px solid;"><asp:Label ID="lbldateover" runat="server" Text='<%# Eval("DAYS_OVR") %>' /></td>
                                                                                    <td style="width:10%;text-align:center;border-right:1px solid;"><asp:Label ID="lblcmlrevdate" runat="server" Text='<%# Eval("CMLREV_DATE") %>' /></td>
                                                                                    <td style="width:10%;text-align:center;border-right:1px solid;"><asp:Label ID="lblcomments" runat="server" Text='<%# Eval("COMMENTS") %>' /></td>
                                                                                    <td style="width:9%;text-align:center;border-right:1px solid;"><asp:Label ID="lblbhc" runat="server" Text='<%# Eval("BHC") %>' /></td>
                                                                                    <td style="width:10%;text-align:center;"><asp:Label ID="lblstatus" runat="server" Text='<%# Eval("STATUS") %>' /></td>
                                                                                  <td style="display:none;width:0px">
                                                                                    <asp:Label ID="lblfname" runat="server" Text='<%# Eval("FILENAME") %>' />
                                                                                    </td> 
                                                                                 
 </tr>

 
 <tr>
 <td style="width:100%;display:none" colspan="12" id='dv<%# Eval("ITMNO") %>'>
 <div style="height:15px;background-color:#00bfff;padding:7px;font-weight:bold" >
  <asp:Label Text="Previous Versons" runat="server" ID="lbl1" ></asp:Label>
 </div>
                                                                      
                                                                   <%--  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>          --%>
                                                                                     <asp:GridView ID="mydetails1" runat="server" ShowHeader="false" AutoGenerateColumns="false"
                                                                                Width="100%" Font-Names="Verdana" Font-Size="X-Small"  OnRowDataBound="mydetails1_RowDataBound"  OnRowCommand="mydetails1_RowCommand" CssClass="gridLines">
                                                                                <Columns>
                                                                                    <asp:ButtonField ButtonType="Button" Text="View" CommandName="Get" ControlStyle-Width="80px"  >
                                                                                        <ItemStyle Width="9%" HorizontalAlign="Center" />
                                                                                    </asp:ButtonField>
                                                                                    <asp:BoundField DataField="ITMNO" >
                                                                                        <ItemStyle Width="5%" HorizontalAlign="Center"  />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="REVISION" >
                                                                                        <ItemStyle Width="5%" HorizontalAlign="Center"  />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="ISSUED" >
                                                                                        <ItemStyle Width="15%" HorizontalAlign="Left"  />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="PSUB_DATE" DataFormatString="{0:dd/MM/yyyy}">
                                                                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="CMLREC_DATE"  DataFormatString="{0:dd/MM/yyyy}" >
                                                                                        <ItemStyle Width="10%" HorizontalAlign="Center"   />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="DAYS_OVR"  >
                                                                                        <ItemStyle Width="7%" HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="CMLREV_DATE" >
                                                                                        <ItemStyle Width="10%" HorizontalAlign="Center"   />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="COMMENTS" >
                                                                                        <ItemStyle Width="10%" HorizontalAlign="Center"  />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="BHC" >
                                                                                        <ItemStyle Width="9%" HorizontalAlign="Center"  />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="STATUS" >
                                                                                        <ItemStyle Width="10%" HorizontalAlign="Center"  />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="FILENAME" />
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                                    
                                                                               <%-- </ContentTemplate>
                                                                                </asp:UpdatePanel>--%>
                                                                                   
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
                                               <%-- </ContentTemplate>
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
        <div id="myprogress" runat="server" style="position: absolute; z-index: 40; top: 30%;
            left: 35%">
            <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                <ProgressTemplate>
                    <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                        Width="250px" />
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </div>
                    
    </form>
    
</body>
</html>
