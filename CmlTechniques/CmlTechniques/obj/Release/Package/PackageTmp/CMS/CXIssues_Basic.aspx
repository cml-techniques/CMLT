<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CXIssues_Basic.aspx.cs" Inherits="CmlTechniques.CMS.CXIssues_Basic" %>

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
        
        <div style="width:800px;margin:20px auto;">
        <div style="text-align:right">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                    <asp:Button ID="btncancel" runat="server" onclick="btncancel_Click" Text="Cancel" 
                                                Width="75px" />
                                    </ContentTemplate>
                                    </asp:UpdatePanel></div>
            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                Width="800px">
                <asp:TabPanel runat="server" HeaderText="Basic Risk Information" ID="TabPanel1">
                <ContentTemplate>
                <div class="box1 blue_dark">
         <table  >
        <tr >
        <td width="150px">
                        Source Document</td>
        <td style="width:250px">
                        <asp:DropDownList ID="drsdoc" runat="server" Width="200px">
                        <asp:ListItem Text="Select Source Document" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="CML SO" Value="1" ></asp:ListItem>
                        <asp:ListItem Text="COMM MEETING" Value="2" ></asp:ListItem>
                        <asp:ListItem Text="CX-IR" Value="3" ></asp:ListItem>
                        <asp:ListItem Text="N/A" Value="4" ></asp:ListItem>
                        <asp:ListItem Text="SISJV SCHEDULE" Value="5" ></asp:ListItem>
                        <asp:ListItem Text="Stage 1 CxA Review" Value="6" ></asp:ListItem>
                        </asp:DropDownList>
         </td>
        <td style="width:150px">
                        Source Document Ref.</td>
        <td style="width:250px">
                        <asp:TextBox ID="txt_sdocref" runat="server" Width="225px"></asp:TextBox>
        </td>
        </tr>
        <tr >
        <td width="150px">
                        Zutec CX Issue</td>
        <td style="width:250px">
                        <asp:TextBox ID="txt_cx_issue" runat="server" Width="225px"></asp:TextBox>
                    </td>
        <td style="width:150px">
                        Base Discipline</td>
        <td style="width:250px">
                        <asp:DropDownList ID="drservice" runat="server" Width="200px">
                        <asp:ListItem Text="Select Base Discipline" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="All" Value="1" ></asp:ListItem>
                        <asp:ListItem Text="ELEC" Value="2" ></asp:ListItem>
                        <asp:ListItem Text="ELEC / ELV" Value="3" ></asp:ListItem>
                        <asp:ListItem Text="ELV" Value="4" ></asp:ListItem>
                        <asp:ListItem Text="ELV / MECH" Value="5" ></asp:ListItem>
                        <asp:ListItem Text="MECH" Value="6" ></asp:ListItem>
                        <asp:ListItem Text="MECH / ELEC" Value="7" ></asp:ListItem>
                        <asp:ListItem Text="MECH / ELV" Value="8" ></asp:ListItem>
                        <asp:ListItem Text="MISC" Value="9" ></asp:ListItem>
                         <asp:ListItem Text="P/PH" Value="10" ></asp:ListItem>
                        </asp:DropDownList>
                            </td>
        </tr>
        <tr >
        <td width="150px">
            System</td>
        <td style="width:250px">
                        <asp:TextBox ID="txt_system" runat="server" Width="225px"></asp:TextBox>
        </td>
        <td style="width:150px">
                        Issue Type</td>
        <td style="width:250px">
                        <asp:DropDownList ID="drtype" runat="server" Width="200px">
                        <asp:ListItem Text="Select Issue Type" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Arising" Value="1"></asp:ListItem>
                        <asp:ListItem Text="CxA Issue" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Deffered Testing" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Design Integration and Close Out" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Incomplete Works" Value="5"></asp:ListItem>
                         <asp:ListItem Text="Issue Arising" Value="6"></asp:ListItem>
                          <asp:ListItem Text="Non Compliance with Spec" Value="7"></asp:ListItem>
                           <asp:ListItem Text="Observation" Value="8"></asp:ListItem>
                            <asp:ListItem Text="SO" Value="9"></asp:ListItem>
                             <asp:ListItem Text="Witness Issue" Value="10"></asp:ListItem>
                             <asp:ListItem Text="Zutec CX Issue" Value="11"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
        </tr>
        <tr >
        <td width="150px">
                        Location</td>
        <td style="width:250px">
                        <asp:DropDownList ID="drloc" runat="server" Width="200px">
                        <asp:ListItem Text="Select Location" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="CUP" Value="1" ></asp:ListItem>
                        <asp:ListItem Text="D & T" Value="2" ></asp:ListItem>
                        <asp:ListItem Text="Clinic" Value="3" ></asp:ListItem>
                        <asp:ListItem Text="Gallery" Value="4" ></asp:ListItem>
                        <asp:ListItem Text="ICU" Value="5" ></asp:ListItem>
                        <asp:ListItem Text="Swing Bld." Value="6" ></asp:ListItem>
                        <asp:ListItem Text="Patient Tower" Value="7" ></asp:ListItem>
                        <asp:ListItem Text="Car Park" Value="8" ></asp:ListItem>
                        <asp:ListItem Text="External" Value="9" ></asp:ListItem>
                        <asp:ListItem Text="N/A" Value="10" ></asp:ListItem>
                        </asp:DropDownList>
                            </td>
        <td style="width:150px">
                        &nbsp;</td>
        <td style="width:250px">
                        &nbsp;</td>
        </tr>
        <tr >
        <td width="150px">
                        Risk Description/ Risk Event Statement</td>
        <td colspan="3">
                        <asp:TextBox ID="txt_desc" runat="server" Width="500px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                            </td>
        </tr>
        <tr >
        <td width="150px">
                        Responsible</td>
        <td style="width:250px">
                        <asp:TextBox ID="txt_resp" runat="server" Width="225px"></asp:TextBox>
                            </td>
        <td style="width:150px">
                        &nbsp;</td>
        <td style="width:250px">
                        &nbsp;</td>
        </tr>
        <tr >
        <td width="150px">
                        Date Reported</td>
        <td style="width:250px">
        <table border="0" cellpadding="0" cellspacing="0">
        <tr>
        <td>
            <asp:TextBox ID="txt_dtrep" runat="server" Width="100px"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender3" runat="server" 
                        TargetControlID="txt_dtrep" PopupButtonID="txt_dtrep" ClearTime="True" 
                        Format="dd/MM/yyyy" Enabled="True" ></asp:CalendarExtender>
        </td>
        <td>
            <asp:Button ID="btn_dtrep" runat="server" Text="--" />
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="txt_dtrep" PopupButtonID="btn_dtrep" ClearTime="True" 
                        Format="dd/MM/yyyy" Enabled="True" ></asp:CalendarExtender>
        </td>
        </tr>
        </table>
                    </td>
        <td style="width:150px">
                        Target Closure Date</td>
        <td style="width:250px">
         <table border="0" cellpadding="0" cellspacing="0">
        <tr>
        <td>
            <asp:TextBox ID="txt_dttclosure" runat="server" Width="100px"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="txt_dttclosure" PopupButtonID="txt_dttclosure" ClearTime="True" 
                        Format="dd/MM/yyyy" Enabled="True" ></asp:CalendarExtender>
        </td>
        <td>
            <asp:Button ID="btn_dttclosure" runat="server" Text="--" />
            <asp:CalendarExtender ID="CalendarExtender4" runat="server" 
                        TargetControlID="txt_dttclosure" PopupButtonID="btn_dttclosure" ClearTime="True" 
                        Format="dd/MM/yyyy" Enabled="True" ></asp:CalendarExtender>
        </td>
        </tr>
        </table>
                            </td>
        </tr>
        <tr >
        <td width="150px">
                        Last Update</td>
        <td style="width:250px">
        <table border="0" cellpadding="0" cellspacing="0">
        <tr>
        <td>
            <asp:TextBox ID="txt_dtlu" runat="server" Width="100px"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender5" runat="server" 
                        TargetControlID="txt_dtlu" PopupButtonID="txt_dtlu" ClearTime="True" 
                        Format="dd/MM/yyyy" Enabled="True" ></asp:CalendarExtender>
        </td>
        <td>
            <asp:Button ID="btn_dtlu" runat="server" Text="--" />
            <asp:CalendarExtender ID="CalendarExtender6" runat="server" 
                        TargetControlID="txt_dtlu" PopupButtonID="btn_dtlu" ClearTime="True" 
                        Format="dd/MM/yyyy" Enabled="True" ></asp:CalendarExtender>
        </td>
        </tr>
        </table>
                    </td>
        <td style="width:150px">
                        Date Closed</td>
        <td style="width:250px">
        <table border="0" cellpadding="0" cellspacing="0">
        <tr>
        <td>
            <asp:TextBox ID="txt_dtclsd" runat="server" Width="100px"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender9" runat="server" 
                        TargetControlID="txt_dtclsd" PopupButtonID="txt_dtclsd" ClearTime="True" 
                        Format="dd/MM/yyyy" Enabled="True" ></asp:CalendarExtender>
        </td>
        <td>
            <asp:Button ID="btn_dtclsd" runat="server" Text="--" />
            <asp:CalendarExtender ID="CalendarExtender10" runat="server" 
                        TargetControlID="txt_dtclsd" PopupButtonID="btn_dtclsd" ClearTime="True" 
                        Format="dd/MM/yyyy" Enabled="True" ></asp:CalendarExtender>
        </td>
        </tr>
        </table>
                            </td>
        </tr>
        <tr >
        <td width="150px">
                        &nbsp;</td>
        <td style="width:250px">
            &nbsp;</td>
        <td style="width:150px">
                        &nbsp;</td>
        <td style="width:250px">
                        &nbsp;</td>
        </tr>
        <tr >
        <td width="150px">
                        <asp:Label ID="lbl_prj" runat="server" CssClass="hidden"></asp:Label>
                        &nbsp;</td>
        <td style="width:250px">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnsave" runat="server" onclick="btnsave_Click" Text="Save" 
                                                Width="75px" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    
                                </td>
                            </tr>
                        </table>
            </td>
        <td style="width:150px">
                        &nbsp;</td>
        <td style="width:250px">
                        &nbsp;</td>
        </tr>
        </table>
        </div>
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="Risk Assessment Information" ID="TabPanel2">
                    <HeaderTemplate>
                        Risk Assessment Information
                    </HeaderTemplate>
                <ContentTemplate>
                <div class="box1 blue_dark">
         <table  >
        <tr >
        <td width="150px">
                        Impact</td>
        <td style="width:250px">
                        <asp:DropDownList ID="drimpact" runat="server" Width="130px">
                        <asp:ListItem Text="Select Impact" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="H" Value="1" ></asp:ListItem>
                        <asp:ListItem Text="M" Value="2" ></asp:ListItem>
                        <asp:ListItem Text="L" Value="3" ></asp:ListItem>
                        <asp:ListItem Text="N/A" Value="4" ></asp:ListItem>
                        <asp:ListItem Text="M/H" Value="5" ></asp:ListItem>
                        </asp:DropDownList>
                            </td>
        <td style="width:150px">
                        &nbsp;</td>
        <td style="width:250px">
                        &nbsp;</td>
        </tr>
        <tr >
        <td width="150px">
                        Impact Description</td>
        <td colspan="3">
                        <asp:TextBox ID="txt_ides" runat="server" Width="500px" Height="50px" 
                            TextMode="MultiLine"></asp:TextBox>
                            </td>
        </tr>
        <tr >
        <td width="150px">
                        Probability</td>
        <td style="width:250px">
                        <asp:DropDownList ID="drprob" runat="server" Width="130px">
                            <asp:ListItem Selected="True" Text="Select Probability" Value="0"></asp:ListItem>
                            <asp:ListItem Text="H" Value="1"></asp:ListItem>
                            <asp:ListItem Text="M" Value="2"></asp:ListItem>
                            <asp:ListItem Text="L" Value="3"></asp:ListItem>
                            <asp:ListItem Text="N/A" Value="4"></asp:ListItem>
                            <asp:ListItem Text="H/M" Value="5"></asp:ListItem>
                        </asp:DropDownList>
            </td>
        <td style="width:150px">
                        Timeline</td>
        <td style="width:250px">
                        <asp:DropDownList ID="drtimeline" runat="server" Width="130px">
                            <asp:ListItem Selected="True" Text="Select Timeline" Value="0"></asp:ListItem>
                            <asp:ListItem Text="N" Value="1"></asp:ListItem>
                            <asp:ListItem Text="M" Value="2"></asp:ListItem>
                            <asp:ListItem Text="F" Value="3"></asp:ListItem>
                            <asp:ListItem Text="M/F" Value="4"></asp:ListItem>
                            <asp:ListItem Text="N/A" Value="5"></asp:ListItem>
                        </asp:DropDownList>
            </td>
        </tr>
             <tr>
                 <td width="150px">
                     Status of Response</td>
                 <td style="width:250px">
                     <asp:DropDownList ID="drsres" runat="server" Width="130px">
                         <asp:ListItem Selected="True" Text="Select Status" Value="0"></asp:ListItem>
                         <asp:ListItem Text="N" Value="1"></asp:ListItem>
                         <asp:ListItem Text="P" Value="2"></asp:ListItem>
                         <asp:ListItem Text="PE" Value="3"></asp:ListItem>
                         <asp:ListItem Text="EE" Value="4"></asp:ListItem>
                         <asp:ListItem Text="N/A" Value="5"></asp:ListItem>
                     </asp:DropDownList>
                 </td>
                 <td style="width:150px">
                     &nbsp;</td>
                 <td style="width:250px">
                     &nbsp;</td>
             </tr>
        <tr >
        <td width="150px">
                        &nbsp;</td>
        <td style="width:250px">
                        &nbsp;</td>
        <td style="width:150px">
                        &nbsp;</td>
        <td style="width:250px">
                        &nbsp;</td>
        </tr>
        <tr >
        <td width="150px">
            <asp:Label ID="Label1" runat="server" CssClass="hidden"></asp:Label>&nbsp;</td>
        <td style="width:250px">
        <table border="0" cellpadding="0" cellspacing="0">
        <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnsave1" runat="server" Text="Update" Width="75px" 
                    onclick="btnsave1_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
            
        </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            </asp:UpdatePanel>
        
        </td>
        </tr>
        </table>
            </td>
        <td style="width:150px">
                        &nbsp;</td>
        <td style="width:250px">
                        &nbsp;</td>
        </tr>
        </table>
        </div>
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="Risk Mitigation" ID="TabPanel3">
                <ContentTemplate>
                <div class="box1 blue_dark">
         <table  >
        <tr >
        <td width="150px">
                        Current Action</td>
        <td colspan="3">
                        <asp:TextBox ID="txt_caction" runat="server" Height="50px" TextMode="MultiLine" 
                            Width="500px"></asp:TextBox>
                            </td>
        </tr>
             <tr>
                 <td width="150px">
                     Planned Future Action</td>
                 <td colspan="3">
                     <asp:TextBox ID="txt_faction" runat="server" Height="50px" TextMode="MultiLine" 
                         Width="500px"></asp:TextBox>
                 </td>
             </tr>
        <tr >
        <td width="150px">
                        Risk Status</td>
        <td style="width:250px">
                        <asp:DropDownList ID="drrstatus" runat="server" Width="130px">
                            <asp:ListItem Selected="True" Text="Select Status" Value="0"></asp:ListItem>
                            <asp:ListItem Text="OPEN" Value="1"></asp:ListItem>
                            <asp:ListItem Text="CLOSED" Value="2"></asp:ListItem>
                            <asp:ListItem Text="MONITORING" Value="3"></asp:ListItem>
                            <asp:ListItem Text="PENDING" Value="4"></asp:ListItem>
                        </asp:DropDownList>
            </td>
        <td style="width:150px">
                        &nbsp;</td>
        <td style="width:250px">
                        &nbsp;</td>
        </tr>
             <tr>
                 <td width="150px">
                     &nbsp;</td>
                 <td style="width:250px">
                     &nbsp;</td>
                 <td style="width:150px">
                     &nbsp;</td>
                 <td style="width:250px">
                     &nbsp;</td>
             </tr>
        <tr >
        <td width="150px">
                        <asp:Label ID="Label2" runat="server" CssClass="hidden"></asp:Label>
                        &nbsp;</td>
        <td style="width:250px">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnsave2" runat="server" onclick="btnsave2_Click" Text="Update" 
                                                Width="75px" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
            </td>
        <td style="width:150px">
                        &nbsp;</td>
        <td style="width:250px">
                        &nbsp;</td>
        </tr>
        </table>
        </div>
                </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        
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
