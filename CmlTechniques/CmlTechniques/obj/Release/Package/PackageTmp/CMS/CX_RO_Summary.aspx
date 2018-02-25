<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CX_RO_Summary.aspx.cs" Inherits="CmlTechniques.CMS.CX_RO_Summary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
    .gvHeaderRow
    {
       /* background-image:url('../images/head_bg.png');*/
        background-color:#82C5EF;
        /*background-repeat: repeat;*/
        font-family:Verdana;
        font-size:x-small;
        font-weight:bold;
        height:30px;
        text-align:center;
    }
    .gvFooetRow
    {
        font-family:Verdana;
        font-size:x-small;
        font-weight:bold;
        height:30px;
        background-color:#82C5EF;
    }
    .verticalHead
    {
    /*	height:150px;
    	width:75px;
    	vertical-align:bottom;
 -webkit-transform: rotate(-90deg); 
 -moz-transform: rotate(-90deg); 
 -o-transform: rotate(-90deg); 
 filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);*/
 height:60px;
 width:50px;
 text-align:center;
 writing-mode: tb-cl; 
filter: flipV(); 
    }
    
         </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: verdana; font-size: xx-small">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <table style="width:100%;background-color:#092443" >
        <tr style="background-color:#092443;color:White;height:30px;">
        <td style="padding:5px;font-weight:bold;font-size:18px" >Commissioning Issues Log Matters Remaining Open</td>
        <td style="width:550px">
        <table border="0" cellpadding="0" cellspacing="0">
        <tr>
        <td style="padding:5px">
        <table  style="background-color:#CCC">
        <tr>
        <td style="font-weight:normal;color:#000">Issues Raised From</td>
        <td> <asp:TextBox ID="txt_date" runat="server" Width="100px"></asp:TextBox>
         <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="txt_date" PopupButtonID="txt_date" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="txt_date" PopupButtonID="btnpick" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
        </td>
        <td><asp:Button ID="btnpick" runat="server" Width="25px" Height="25px" style="background-image:url('../images/cal.png');border:none;cursor:pointer;" /></td>
        <td><asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
             <asp:Button ID="btnview" runat="server" Text="View" onclick="btnview_Click" />
            </ContentTemplate>
            </asp:UpdatePanel></td>
        </tr>
        </table>
            
            </td>
        <td >
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnedit" runat="server" Text="Edit" onclick="btnedit_Click" Width="100px" />
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        <td align="right">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnprint" runat="server" Text="Print" onclick="btnprint_Click" Width="100px" />
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
        </table>
        </td>
        </tr>
        </table>
       <%-- <div>
        <table style="width:100%;background-color:#092443;text-align:center" border="0" cellpadding="0" cellspacing="1" >
        <tr style="background-color:#82C5EF;height:55px">
        <td style="width:50px"></td>
        <td style="width:200px">Building</td>
        <td style="width:75px">Issues Raised Period</td>
        <td style="width:75px">Issues Total</td>
        <td  style="width:75px">Open</td>
        <td  style="width:100px">High Impact Probability Closed this Period</td>
        <td  style="width:100px" >High Impact Probability Open</td>
        <td style="width:50px" class="verticalHead" align="center" valign="middle"><center>Jacobs</center></td>
        <td style="width:50px">AECOM</td>
        <td style="width:50px">KEO/CML</td>
        <td style="width:50px">SISJV</td>
        <td style="width:50px" >CCAD</td>
        <td style="width:200px">Comments</td>
        </tr>
        </table>
        </div--%>
        <div>
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
             <asp:GridView ID="mygrid" runat="server" AutoGenerateColumns="False" 
                ShowFooter="True" Width="100%" onrowdatabound="mygrid_RowDataBound" 
                onrowcreated="mygrid_RowCreated" CellPadding="5"  >
            <HeaderStyle CssClass="gvHeaderRow" HorizontalAlign="Center" VerticalAlign="Middle" />
                 <RowStyle Height="25px" BackColor="#E3EAEB" />
                 <FooterStyle CssClass="gvFooetRow" HorizontalAlign="Center" />
                 <AlternatingRowStyle BackColor="White" />
                 <Columns>
                 <%--<asp:BoundField >
                     <ItemStyle HorizontalAlign="Center" Width="50px" />
                     </asp:BoundField>--%>
                     <asp:TemplateField>
                     <ItemTemplate>
                         <asp:CheckBox ID="chkselect" runat="server" />
                     </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" Width="50px" />
                     </asp:TemplateField>
                 <asp:BoundField DataField="building" HeaderText="Building" >
                     <ItemStyle Width="200px" />
                     </asp:BoundField>
                 <asp:BoundField HeaderText="Issues Raised Period" >
                     <ItemStyle HorizontalAlign="Center" Width="75px" />
                     </asp:BoundField>
                 <asp:BoundField DataField="tissued" HeaderText="Issues Total" >
                     <ItemStyle HorizontalAlign="Center" Width="75px" />
                     </asp:BoundField>
                 <asp:BoundField DataField="topen" HeaderText="Open" >
                     <ItemStyle HorizontalAlign="Center" Width="75px" />
                     </asp:BoundField>
                 <asp:BoundField HeaderText="High Impact/ Probability Closed this Period" DataField="close" >
                     <ItemStyle HorizontalAlign="Center" Width="100px" />
                     </asp:BoundField>
                 <asp:BoundField HeaderText="High Impact/ Probability Open" DataField="open" >
                     <ItemStyle HorizontalAlign="Center" Width="100px" />
                     </asp:BoundField>
                     <asp:BoundField HeaderText="Jacobs" DataField="res1" >
                     <ItemStyle HorizontalAlign="Center" Width="50px" />
                     </asp:BoundField>
                     <asp:BoundField HeaderText="AECOM" DataField="res2" >
                     <ItemStyle HorizontalAlign="Center" Width="50px" />
                     </asp:BoundField>
                     <asp:BoundField HeaderText="KEO/CML"  DataField="res3" >
                     <ItemStyle HorizontalAlign="Center" Width="50px" />
                     </asp:BoundField>
                     <asp:BoundField HeaderText="SISJV" DataField="res4">
                     <ItemStyle HorizontalAlign="Center" Width="50px" />
                     </asp:BoundField>
                     <asp:BoundField HeaderText="CCAD"  DataField="res5" >
                     <ItemStyle HorizontalAlign="Center" Width="50px" />
                     </asp:BoundField>
                 <asp:BoundField HeaderText="Comments" DataField="comment" >
                     <ItemStyle HorizontalAlign="Center" Width="200px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="id" />
                 </Columns>
            </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
           
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="CmlTechniques.CMS.DataSet2TableAdapters.Load_Cx_Issues_LogTableAdapter">
    </asp:ObjectDataSource>
    <asp:Panel ID="pnlPopup1" runat="server" Width="400px" Height="200px" style="padding:15px;display:none" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <table style="font-size:x-small;width:400px" border="0" cellpadding="3" cellspacing="0"  >
                <tr >
                        <td colspan="2" style="background-color: #092443;height:25px" >
                            <asp:Label ID="lbl" runat="server" ForeColor="White" Text="CX Summary - Update"></asp:Label>
                       </td>
                    </tr>
                
                    <tr id="tr1" runat="server">
                        <td style="width:100px" >
                            HIGH IMPACT/ PROBABILITY CLOSED</td>
                        <td style="width:300px" >
                            <asp:TextBox ID="txt_closed" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr2" runat="server">
                        <td >
                            HIGH IMPACT/ PROBABILITY OPEN</td>
                        <td>
                            <asp:TextBox ID="txt_open" runat="server" Width="150px"></asp:TextBox>
                       </td>
                    </tr>
                    <tr id="tr3" runat="server">
                        <td >
                            COMMENTS</td>
                        <td >
                            <asp:TextBox ID="txt_comments" runat="server" Width="300px" Height="50px" TextMode="MultiLine" ></asp:TextBox>
                        </td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                        <table>
                        <tr>
                        <td> <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                            <ContentTemplate>
                            <asp:Button ID="btnupdate" runat="server" 
                               Text="Update" onclick="btnupdate_Click" />
                            </ContentTemplate>
                            </asp:UpdatePanel></td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btncancel" runat="server" Text="Cancel" 
                                    onclick="btncancel_Click" />
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
                <div id="myprogress1" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" >
            <ProgressTemplate>
                <asp:Image ID="imgload1" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div> 
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy1" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender1" runat="server" TargetControlID="btnDummy1"  PopupControlID="pnlPopup1" BackgroundCssClass="modal"></asp:ModalPopupExtender>
        <div id="myprogress" runat="server" style="position:absolute; z-index:40;top:40%;left: 48%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading45.gif" Height="100px" Width="100px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div>
    </form>
</body>
</html>
