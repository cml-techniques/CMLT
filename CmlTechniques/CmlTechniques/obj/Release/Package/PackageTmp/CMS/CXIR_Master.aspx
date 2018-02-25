<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CXIR_Master.aspx.cs" Inherits="CmlTechniques.CMS.CXIR_Master" %>

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
</head>
<body>
    <form id="form1" runat="server">
   <div >
       <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
       </asp:ToolkitScriptManager>
        <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
        <asp:Label ID="lblmode" runat="server" Text="" style="display:none"></asp:Label>
        <asp:Label ID="lblid" runat="server" Text="" style="display:none"></asp:Label>
        <div class="box1 silver">
        <div class="boxtitle">
        <h1>
            <asp:Label ID="lbltitle" runat="server" Text=""></asp:Label></h1>
        </div>
        <div class="uplevel">
        <a href="#" onclick="javascript:history.go(-1);"><b>Back</b></a>
        </div>
        <%--        <asp:Label ID="lblsono" runat="server" ForeColor="Red"></asp:Label>--%>
                <div style="clear:both"></div>
        </div>
        <div style="width:1000px;margin:20px auto;">
            <div class="box1 blue_dark">
            <table>
            <tr>
            <td style="width:150px">IR Ref.</td>
            <td  style="width:150px">
                <asp:TextBox ID="txt_ref" runat="server" Width="150px"></asp:TextBox>
                            </td>
            <td style="width:20px"></td>
            <td style="width:150px">REV</td>
            <td style="width:150px">
                <asp:TextBox ID="txt_rev" runat="server" Width="150px"></asp:TextBox>
                            </td>
            <td style="width:20px"></td>
            <td style="width:150px"></td>
            <td style="width:150px"></td>
            </tr>
            <tr>
            <td >Date Received</td>
            <td ><asp:TextBox ID="txt_dtrecv" runat="server" Width="100px"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender3" runat="server" 
                        TargetControlID="txt_dtrecv" PopupButtonID="txt_dtrecv" ClearTime="True" 
                        Format="dd/MM/yyyy" Enabled="True" ></asp:CalendarExtender></td>
            <td ></td>
            <td >Proposed Date</td>
            <td ><asp:TextBox ID="txt_dtprop" runat="server" Width="100px"></asp:TextBox>
            <asp:CalendarExtender ID="txt_dtprop_CalendarExtender" runat="server" 
                        TargetControlID="txt_dtprop" PopupButtonID="txt_dtprop" ClearTime="True" 
                        Format="dd/MM/yyyy" Enabled="True" ></asp:CalendarExtender></td>
            <td></td>
            <td >AM/PM</td>
            <td >
                <asp:DropDownList ID="drampm" runat="server">
                <asp:ListItem Text="AM" Value="1" Selected="True"></asp:ListItem>
                <asp:ListItem Text="PM" Value="2"></asp:ListItem>
                </asp:DropDownList>
                            </td>
            </tr>
            <tr>
            <td >Test Type</td>
            <td >
                <asp:TextBox ID="txt_type" runat="server" Width="150px"></asp:TextBox>
                            </td>
            <td >&nbsp;</td>
            <td >Discipline</td>
            <td >
            <asp:DropDownList ID="drservice" runat="server" Width="150px">
                        <asp:ListItem Text="Select Discipline" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="ELEC" Value="1" ></asp:ListItem>
                        <asp:ListItem Text="ELV" Value="2" ></asp:ListItem>
                        <asp:ListItem Text="MECH" Value="3" ></asp:ListItem>
                        <asp:ListItem Text="P & PH" Value="4" ></asp:ListItem>
                        <asp:ListItem Text="MISC" Value="5" ></asp:ListItem>
                        </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td >System/ Equipment</td>
            <td >
                <asp:TextBox ID="txt_sys" runat="server" Width="150px"></asp:TextBox>
                            </td>
            </tr>
            <tr>
            <td >Test Details</td>
            <td >
                <asp:TextBox ID="txt_details" runat="server" Width="150px"></asp:TextBox>
                            </td>
            <td >&nbsp;</td>
            <td >Building</td>
            <td >
                <asp:TextBox ID="txt_bldg" runat="server" Width="150px"></asp:TextBox>
                            </td>
            <td>&nbsp;</td>
            <td >Level</td>
            <td >
                <asp:TextBox ID="txt_lvl" runat="server" Width="150px"></asp:TextBox>
                            </td>
            </tr>
            <tr>
            <td >Location</td>
            <td >
                <asp:DropDownList ID="drloc" runat="server" Width="150px">
                        <asp:ListItem Text="Select Location" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="CUP" Value="1" ></asp:ListItem>
                        <asp:ListItem Text="D & T" Value="2" ></asp:ListItem>
                        <asp:ListItem Text="Clinic" Value="3" ></asp:ListItem>
                        <asp:ListItem Text="Gallery" Value="4" ></asp:ListItem>
                        <asp:ListItem Text="ICU" Value="5" ></asp:ListItem>
                        <asp:ListItem Text="Swing Wing" Value="6" ></asp:ListItem>
                        <asp:ListItem Text="Patient Tower" Value="7" ></asp:ListItem>
                        <asp:ListItem Text="Car Park" Value="8" ></asp:ListItem>
                        <asp:ListItem Text="External" Value="9" ></asp:ListItem>
                        </asp:DropDownList>
                            </td>
            <td >&nbsp;</td>
            <td >IR &amp; Documentation Checked</td>
            <td >
                <asp:TextBox ID="txt_irchk" runat="server" Width="150px"></asp:TextBox>
                            </td>
            <td>&nbsp;</td>
            <td >All Parties Advised</td>
            <td >
                <asp:TextBox ID="txt_adv" runat="server" Width="150px"></asp:TextBox>
                            </td>
            </tr>
            <tr>
            <td colspan="8" style="background-color:Silver;color:#000033" align="center" >CML Witness</td>
            </tr>
            <tr>
            <td >Proposed Start</td>
            <td ><asp:TextBox ID="txt_dtpstart" runat="server" Width="100px"></asp:TextBox>
            <asp:CalendarExtender ID="txt_dtpstart_CalendarExtender" runat="server" 
                        TargetControlID="txt_dtpstart" PopupButtonID="txt_dtpstart" ClearTime="True" 
                        Format="dd/MM/yyyy" Enabled="True" ></asp:CalendarExtender></td>
            <td >&nbsp;</td>
            <td >Actual Start</td>
            <td ><asp:TextBox ID="txt_dtastart" runat="server" Width="100px"></asp:TextBox>
            <asp:CalendarExtender ID="txt_dtastart_CalendarExtender" runat="server" 
                        TargetControlID="txt_dtastart" PopupButtonID="txt_dtastart" ClearTime="True" 
                        Format="dd/MM/yyyy" Enabled="True" ></asp:CalendarExtender></td>
            <td>&nbsp;</td>
            <td >Delay</td>
            <td >
                <asp:TextBox ID="txt_delay" runat="server" Width="100px" ReadOnly="True"></asp:TextBox>
                            </td>
            </tr>
            <tr>
            <td >Completion Date</td>
            <td ><asp:TextBox ID="txt_dtcomp" runat="server" Width="100px"></asp:TextBox>
            <asp:CalendarExtender ID="txt_dtcomp_CalendarExtender" runat="server" 
                        TargetControlID="txt_dtcomp" PopupButtonID="txt_dtcomp" ClearTime="True" 
                        Format="dd/MM/yyyy" Enabled="True" ></asp:CalendarExtender></td>
            <td >&nbsp;</td>
            <td >No. of Visits</td>
            <td >
                <asp:TextBox ID="txt_vist" runat="server" Width="150px"></asp:TextBox>
                            </td>
            <td>&nbsp;</td>
            <td >Witness By</td>
            <td >
                <asp:TextBox ID="txt_witness" runat="server" Width="150px"></asp:TextBox>
                            </td>
            </tr>
            <tr>
            <td >Status</td>
            <td >
                <asp:TextBox ID="txt_status" runat="server" Width="150px"></asp:TextBox>
                            </td>
            <td >&nbsp;</td>
            <td >&nbsp;</td>
            <td >&nbsp;</td>
            <td>&nbsp;</td>
            <td >&nbsp;</td>
            <td >&nbsp;</td>
            </tr>
            <tr>
            <td >Document Status</td>
            <td >
                <asp:TextBox ID="txt_docstatus" runat="server" Width="150px"></asp:TextBox>
                            </td>
            <td >&nbsp;</td>
            <td >SVR No.</td>
            <td >
                <asp:TextBox ID="txt_svrno" runat="server" Width="150px"></asp:TextBox>
                            </td>
            <td>&nbsp;</td>
            <td >&nbsp;</td>
            <td >&nbsp;</td>
            </tr>
            <tr>
            <td >Notes</td>
            <td colspan="4" >
                <asp:TextBox ID="txt_notes" runat="server" Width="100%" Height="50px" TextMode="MultiLine"></asp:TextBox>
                            </td>
            <td>&nbsp;</td>
            <td >&nbsp;</td>
            <td >&nbsp;</td>
            </tr>
            <tr>
            <td >&nbsp;</td>
            <td colspan="4" >
                &nbsp;</td>
            <td>&nbsp;</td>
            <td >&nbsp;</td>
            <td >&nbsp;</td>
            </tr>
            <tr>
            <td >&nbsp;</td>
            <td colspan="4" >
            <table>
            <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                 <asp:Button ID="btnsave" runat="server" Text="Save" Width="75px" 
                        onclick="btnsave_Click" />
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" Width="75px" 
                        onclick="btncancel_Click" />
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btndelete" runat="server" Text="Delete" Width="75px" 
                        onclick="btndelete_Click" />
                    <asp:ConfirmButtonExtender ID="btndelete_ConfirmButtonExtender" runat="server" 
                        ConfirmText="Are you sure want to delete this entry?" Enabled="True" TargetControlID="btndelete">
                    </asp:ConfirmButtonExtender>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            </tr>
            </table>
            </td>
            <td>&nbsp;</td>
            <td >&nbsp;</td>
            <td >&nbsp;</td>
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
