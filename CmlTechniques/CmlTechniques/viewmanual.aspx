<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewmanual.aspx.cs" Inherits="CmlTechniques.viewmanual" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CML Techniques</title>
    <style type="text/css">
    body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;  
    }
        </style>
        <script type="text/javascript">
            function ShowTime() {
                var dt = new Date();
                document.getElementById('time').innerHTML = dt.toLocaleDateString() + ' , ' + dt.toLocaleTimeString();
                window.setTimeout("ShowTime()", 1000);
            }
            function cal() {
                var btn = document.getElementById("cmdadd1");
                btn.click();
            }
                
    </script>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
<link href="page.css" rel="stylesheet" type="text/css" />
</head>
<script type="text/javascript">
    var myclose = false;

    function ConfirmClose() {
        if (event.clientY < 0) {
            window.open("logout.aspx", "mywindow1", "height=500px;width=500px;status=1");
            event.returnValue = "You have attempted to leave this page. If you have made any changes " + "to the fields without clicking the Save button, your changes will be " + "lost. If you want to continue,please Log Off from the application." + "\n\n" + "Are you sure you want to exit this page?";

            setTimeout('myclose=false', 100);
            myclose = true;
        }
    }
    function HandleOnClose() {
        if (myclose == true) alert("Window is closed");
    }
    </script>
<body >
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>       
        <asp:Label ID="Label2" runat="server" Text="" style="display:none"></asp:Label>
        <asp:Label ID="lblsrv" runat="server" Text="" style="display:none"></asp:Label> 
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;position:fixed ; ">
            <tr>
                <td bgcolor="Black" width="210px" valign="top" align="center" 
                    height="45%" style="border-right-style: outset; border-right-width: 2px; border-right-color: #092443">
                    <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="45%" valign="top">            
                    <table border="0" cellpadding="0" cellspacing="0" width="205px" >
                        <tr>
                        <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo.JPG" 
                        Width="205px" Height="120px" BorderStyle="None" /> 
                        </td>
                        </tr>
                        <tr>
                        <td style="background-position: center top; background-image: url('images/bx_top.png'); background-repeat: no-repeat" height="33px" align="center" valign="top" >
                                       
                        </td>
                        </tr>
                        <tr>
                        <td style="background-position: center top; background-image: url('images/bx_body.png'); background-repeat:repeat-y  " 
                                 align="center" valign="top" bgcolor="Black">
                                <table width="195px" cellspacing="0">
                                    <tr>
                                        <td height="28px" 
                                            style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onclick="cal();" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" align="center" >BACK</td>
                                    </tr>
                                    <tr>
                                        <%--<td  height="28px" 
                                            style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onclick="javascript:window.location.href='logout.aspx';" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" >
                                        LOG OFF</td>--%>
                                    </tr>
                                    <tr>
                                        <td  height="28px" 
                                            style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" align="center">
                                        <%--<a href="#"  style="text-decoration:none;font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; color: #FFFFFF" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';">CONTACT US</a>
                                            &nbsp;--%><a href="mailto:admin@cmlinternational.net" style="text-decoration:none;color: #FFFFFF">CONTACT US</a> </td>
                                    </tr>
                                    </table>
                                
                        </td>
                        </tr>
                        <tr>
                        <td style="background-position: center top; background-image: url('images/bx_bottom.png'); background-repeat: no-repeat" 
                                height="14px" align="center" valign="top" >
                        
                        </td>
                        </tr>
                        </table>
                            </td>
                        </tr>                        
                    </table>
                    
                </td>
                <td rowspan="2" valign="top" style="width: 100%; height: 100%">
                <iframe id="myframe"  frameborder="0" height="100%" width="100%" runat="server" ></iframe>
                </td>
                <td height="100%" valign="top" width="210px" bgcolor="Black" align="center" 
                    rowspan="2">
                <div style="width: 100%; height: 359px; overflow: auto" >
                
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="background-position: center top; background-image: url('images/bx_top.png'); background-repeat: no-repeat" 
                                height="33px" align="center" valign="top">
                                
                                </td>
                                </tr>
                                <tr>
                                <td align="center"  
                                style="background-position: center top; background-image: url('images/bx_body.png'); background-repeat: repeat-y " 
                                valign="top">                               
                                
                                <table width="195px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" style="color: #FF0000" valign="middle" height="15px">
                                            DOC.STATUS :
                                            <asp:Label ID="lbstatus" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" height="15px" valign="middle">
                                            <asp:Label ID="lbduration" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                            <asp:Button ID="cmdsave" runat="server" Height="23px" 
                                                    Text="Commit & Save Comments" 
                                                    Font-Names="Arial,Helvetica,sans-serif" Font-Size="X-Small" 
                                                ForeColor="Red" Width="195px" onclick="cmdsave_Click"  />
                                            </ContentTemplate>
                                            </asp:UpdatePanel>
                                                
                                                </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                                <asp:Button ID="cmdadd1" runat="server" Height="23px" 
                                                    Text="Exit without Saving" 
                                                    Font-Names="Arial,Helvetica,sans-serif" Font-Size="X-Small" 
                                                ForeColor="Red" Width="195px" onclick="cmdadd1_Click" />
                                                </td>
                                    </tr>
                                </table>
                                </td>
                                </tr>
                                <tr>
                        <td style="background-position: center top; background-image: url('images/bx_bottom.png'); background-repeat: no-repeat" 
                                height="20px" align="center" valign="top" >
                        
                        </td>
                        </tr>  
                                
                        <tr>
                            <td style="background-repeat: no-repeat; background-position: center top" 
                                align="center" valign="top">
                                <asp:Label ID="Label1" runat="server" Width="210px" Height="2px"></asp:Label>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                
     <%--<asp:GridView ID="mybasket" runat="server" AllowPaging="True" 
                                            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" 
                                            DataSourceID="dataSource" Font-Names="Arial,Helvetica,sans-serif" 
                                            Font-Size="X-Small" ForeColor="#333333"  
                                            Width="202px" onrowdatabound="mybasket_RowDataBound" PageSize="4">
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#EFF3FB" />
                                            <Columns>
                                                <asp:CommandField ButtonType="Image" 
                                                    DeleteImageUrl="~/TreeLineImages/minus.gif" ShowDeleteButton="true">
                                                    <ItemStyle Width="10px" />
                                                </asp:CommandField>
                                                <asp:BoundField DataField="page" HeaderText="Page No.">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Width="40px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="sec" HeaderText="Sec.No.">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Width="40px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="comment" HeaderText="Comment">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Width="155px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="uid" />
                                            </Columns>
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                        <asp:ObjectDataSource ID="dataSource" runat="server" DeleteMethod="Delete" 
                                            InsertMethod="Insert" SelectMethod="GetData" 
                                            TypeName="CmlTechniques.comment_basket" UpdateMethod="Update">
                                            <DeleteParameters>
                                                <asp:Parameter Name="id" Type="Int32" />
                                            </DeleteParameters>
                                            <InsertParameters>
                                                <asp:Parameter Name="page" Type="String" />
                                                <asp:Parameter Name="sec" Type="String" />
                                                <asp:Parameter Name="comment" Type="String" />
                                            </InsertParameters>
                                        </asp:ObjectDataSource>--%>
                                    <asp:GridView ID="mybasket" runat="server" AutoGenerateColumns="False" 
                                        CellPadding="4" ForeColor="#333333" GridLines="None" Width="202px" Font-Names="verdana" 
                                            Font-Size="X-Small" onrowdatabound="mybasket_RowDataBound" 
                                        onrowcommand="mybasket_RowCommand">
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#999999" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                        <asp:ButtonField ButtonType="Image" ImageUrl="~/TreeLineImages/minus.gif" />
                                        <asp:BoundField DataField="page" HeaderText="Page No.">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Width="30px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="sec" HeaderText="Sec.No.">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Width="30px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="comment" HeaderText="Comment">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Width="155px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ID" >
                                            <ItemStyle Width="5px" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                        </ContentTemplate>
                                </asp:UpdatePanel>
                                </td>
                        </tr>
                    </table>
                    <asp:Panel ID="pnlPopup" runat="server" Width="202px" style="display:none;" >
                        <table border="0" cellpadding="0" cellspacing="0" 
                            style="width: 202px; top: 102px; right: 7px; position: fixed;" id="tblPopup" >
                            <tr>
                                <td class="heading" style="background-image: url('images/headingbg_13.gif'); background-repeat: repeat-x;">&nbsp;&nbsp;Confirmation</td>
                            </tr>                            
                            <tr>
                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: small; color: #FFFFFF"  ><p>Do you want to change the status of the current document?</p>                                
                                
                                    </td>
                            </tr>
                            <tr>
                                <td class="footer"  >
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>                                    
                                <asp:Button ID="btnYes" runat="server" Text="Yes" OnClick="btnYes_Click"  /><asp:Button ID="btnNo" runat="server" Text="No" OnClick="btnNo_Click"  />
                                </ContentTemplate>
                                    </asp:UpdatePanel>
                                
                                </td>
                            </tr>
                       </table>
                  </asp:Panel> 
                    <asp:Button ID="btnDummy" runat="server" Text="" style="display:none;" />
                  <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" 
                  TargetControlID="btnDummy"  PopupControlID="pnlPopup"
                  BackgroundCssClass="modal"
                  OkControlID="btnYes"
                  DropShadow="true"  >
                  </asp:ModalPopupExtender>
                
                    <table  style="bottom: 0px; right:0px; position: fixed;">
                        <tr>
                            <td style="background-position: center; background-image: url('images/tit.png'); background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; cursor:pointer;" bgcolor="Black" onclick="javascript:window.open('additionalview.aspx','','left=210,top=0,bottom=0,width=1024, menubar=1,toolbar=0,scrollbars=1,status=1');" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" width="210px" height="30px" align="center" valign="middle">VIEW ANOTHER DOCUMENT
                                <%--<a href="newprojecthome.aspx" target="_blank"   style="text-decoration:none;font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; color: #FFFFFF" onmouseover="this.style.color='blue'" onmouseout="this.style.color='#FFFFFF';" >View Another Document</a>--%>
                                </td>
                        </tr>
                    </table>
                    
                
                </div>
                </td>
            </tr>
            <tr>
                <td bgcolor="Black" width="210px" valign="top" align="center" 
                    height="55%" style="border-right-style: outset; border-right-width: 2px; border-right-color: #092443">
                    <div  style="width:100%; height: 100%; overflow: auto;" id="mydiv" runat="server">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                <div class="comment_add">
                                                
                               <table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; " 
                                        border="0" cellpadding="0" cellspacing="0">
                                        <%--<tr align="left" >
                                            <td rowspan="5" width="5px">
                                                &nbsp;</td>
                                            <td width="50px" >
                                                PAGE NO.</td>
                                            <td width="105px"  >
                                                SEC.NO</td>
                                            <td rowspan="5" width="5px">
                                                &nbsp;</td>
                                        </tr>--%>
                                        <tr align="left">
                                            <td width="90px" align="left">
                                                <asp:TextBox ID="txtpno" runat="server"  Width="89px" CssClass="comment-text" placeholder="Page No."></asp:TextBox>
                                            </td>
                                            <td width="90px" align="right" >
                                                <asp:TextBox ID="txtsno" runat="server" Width="89px" CssClass="comment-text" placeholder="Sec. No."></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr >
                                            <td style="height:5px">
                                                </td>
                                            <td>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" >
                                                <asp:TextBox ID="txtcmnt" runat="server" Height="152px" Width="190px" 
                                                    TextMode="MultiLine" CssClass="comment-text" placeholder="Comment.."
                                                    Wrap="True" style="text-align:left" ></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td style="height:5px"></td>
                                        <td></td>
                                        </tr>
                                        <tr>
                                        <td width="90px" align="left">
                                                <asp:Button ID="cmdadd" runat="server" Height="25px" Width="95px" CssClass="comment-text"
                                                     Text="Save" onclick="cmdadd_Click" style="cursor:pointer" />
                                            </td>
                                            <td width="90px" align="right" >
                                                <asp:Button ID="cmdexit" runat="server" Height="25px" Width="95px" CssClass="comment-text"
                                                     Text="Cancel" style="cursor:pointer" />
                                            </td>
                                            
                                        </tr>
                                    </table>
                                    <br />
                                    <div id="mydiv1" runat="server">                       
                                <table border="0" cellpadding="0" cellspacing="0" >
                                    <tr>
                                        <td width="190px" 
                                            
                                            style="font-family: Arial, Helvetica, sans-serif; font-size: small; color: #FFFFFF" 
                                            align="left" valign="top">
                                            Change Doc.Status</td>
                                     
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:DropDownList ID="drstatus" runat="server" Height="25px" Width="190px" CssClass="comment-text" >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    
                                </table>
                            </div>
                                </div>
                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                    <br />
                                    
                            </div>
                             
                </td>
            </tr>
        </table>
        
        
    </div>
    </form>
</body>
</html>
