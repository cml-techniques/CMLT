<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="soadd1.aspx.cs" Inherits="CmlTechniques.CMS.soadd1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <script src="../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script> 
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" /> 
</head>
<body class="blue_light">
    <form id="form1" runat="server">
    <div >
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
        <asp:Label ID="lblmode" runat="server" Text="" style="display:none"></asp:Label>
        <div class="box1 silver">
        <div class="boxtitle">
        <h1>
            <asp:Label ID="lbltitle" runat="server" Text=""></asp:Label></h1>
        </div>
        <div class="uplevel">
        <a href="#" onclick="javascript:history.go(-1);return false;"><b>Back</b></a>
        </div>
        <%--        <asp:Label ID="lblsono" runat="server" ForeColor="Red"></asp:Label>--%>
                <div style="clear:both"></div>
        </div>
        <div style="width:474px;margin:20px auto;">
        <div class="box1 blue_dark">
         <table  >
        <tr >
        <td width="150px">
                        Discipline</td>
        <td style="width:350px">
                        <asp:DropDownList ID="drpackage" runat="server" Width="200px">
                        </asp:DropDownList>
                    </td>
        </tr>
        <tr >
        <td width="110px">
                        Building</td>
        <td style="width:350px">
                        <asp:TextBox ID="txt_subj" runat="server" Width="100px"></asp:TextBox>
                    </td>
        </tr>
        <tr >
        <td width="110px">
                        Date Submitted</td>
        <td style="width:350px">
        <table border="0" cellpadding="0" cellspacing="0">
        <tr>
        <td><asp:TextBox ID="txt_date" runat="server" Width="100px"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender72" runat="server" 
                        TargetControlID="txt_date" PopupButtonID="txt_date" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender></td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Button ID="btndate" runat="server" Text=".." />
                
            </ContentTemplate>
            </asp:UpdatePanel>
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="txt_date" PopupButtonID="btndate" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
        </td>
        </tr>
        </table>
                        
                    </td>
        </tr>
        <tr >
        <td width="110px">
                        Recorded By</td>
        <td style="width:350px">
                        <asp:TextBox ID="txt_created" runat="server" Width="100%"></asp:TextBox>
                    </td>
        </tr>
        <tr >
        <td width="110px">
                        Action By</td>
        <td style="width:350px">
                        <asp:TextBox ID="txt_issuedto" runat="server" Width="100%"></asp:TextBox>
                    </td>
        </tr>
        <tr >
        <td width="110px">
                        No. of Snags</td>
        <td style="width:350px">
                        <asp:TextBox ID="txt_cmts" runat="server" Width="100px"></asp:TextBox>
                    </td>
        </tr>
        <tr >
        <td width="110px">
                        Status</td>
        <td style="width:350px">
                        <asp:DropDownList ID="drstatus" runat="server">
                        <asp:ListItem Text="OPEN" Value="1"></asp:ListItem>
                        <asp:ListItem Text="CLOSED" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                            </td>
        </tr>
        <tr  >
        <td width="110px">
                        Details</td>
        <td style="width:350px">
                        <asp:TextBox ID="txt_details" runat="server" Width="100%" Height="75px" TextMode="MultiLine"></asp:TextBox>
                    </td>
        </tr>
        <tr >
        <td width="110px">
                        Snag List Item(s) Cleared</td>
        <td style="width:350px">
                        <asp:TextBox ID="txt_clear" runat="server" Width="100px"></asp:TextBox>
         </td>
        </tr>
        <tr >
        <td width="110px">
                        Date Completed</td>
        <td style="width:350px">
         <table border="0" cellpadding="0" cellspacing="0">
        <tr>
        <td><asp:TextBox ID="txt_cdate" runat="server" Width="100px"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="txt_cdate" PopupButtonID="txt_cdate" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender></td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Button ID="btncdate" runat="server" Text=".." />
                
            </ContentTemplate>
            </asp:UpdatePanel>
            <asp:CalendarExtender ID="CalendarExtender3" runat="server" 
                        TargetControlID="txt_cdate" PopupButtonID="btncdate" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
        </td>
        </tr>
        </table>
         </td>
        </tr>
        <tr id="trdoc" runat="server" >
        <td width="110px">
                        Document</td>
        <td style="width:350px">
                        <asp:TextBox ID="txt_docname" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr id="trnew" runat="server" >
        <td width="110px">
                        &nbsp;</td>
        <td style="width:350px">
                        <asp:CheckBox ID="chknew" runat="server" Text="Upload Revised Commissioning Snag" />
            </td>
        </tr>
        <tr >
        <td width="110px">
                        Select Document</td>
        <td style="width:350px" rowspan="3" valign="top">
                        <input ID="myupload" runat="server" class="multi" type="file" /></td>
        </tr>
        <tr >
        <td width="110px">
                        &nbsp;</td>
        </tr>
        <tr >
        <td width="110px">
                        &nbsp;</td>
        </tr>
        <tr >
        <td width="110px">
                        &nbsp;</td>
        <td align="left">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate><asp:Button ID="btnaddtr" runat="server" Text="Save Changes" 
                    onclick="btnaddtr_Click" Width="120px" />
            </ContentTemplate>
            <Triggers>
            <asp:PostBackTrigger ControlID="btnaddtr" />
            </Triggers>
            </asp:UpdatePanel>
            </td>
        </tr>
        </table>
        </div>
        <div id="myprogress" runat="server" style="position:absolute; z-index:40;top:40%;left: 48%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading45.gif" Height="100px" Width="100px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div>
        </div>
           
            
       
    </div>
    </form>
</body>
</html>
