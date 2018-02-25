<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="cmsreports.aspx.cs" Inherits="CmlTechniques.CMS.cmsreports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">

        function pageLoad() {
        }
    
    </script>

    <style type="text/css">
        .chkstyle td
        {
            width: 150px;
            margin-right: 50px;
        }
    </style>
    <link href="../page.css" rel="stylesheet" type="text/css" />
</head>
<body bgcolor="#D1DEF1">
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" AsyncPostBackTimeout="36000">
        </asp:ToolkitScriptManager>
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
        <div style="height: 100%; padding-left: 50px; padding-right: 50px">
            <center>
                <asp:Label ID="lblhead" runat="server" Text="Commissioning Management Reports" Font-Size="X-Large"
                    ForeColor="White"></asp:Label></center>
            <asp:Label ID="lblprj" runat="server" Text="" Style="display: none"></asp:Label>
            <%--<table>
        <tr>
        <td><asp:Button ID="btncassheet" runat="server" Text="CAS Sheet" onclick="btnmsshcdule_Click" Width="300px"
                 /></td>
        </tr>
        <tr>
        <td><asp:Button ID="Button1" runat="server" Text="Commissioning Plans" onclick="btnmsshcdule_Click" Width="300px"
                 /></td>
        </tr>
        <tr>
        <td><asp:Button ID="Button2" runat="server" Text="Document Review" onclick="btnmsshcdule_Click" Width="300px"
                 /></td>
        </tr>
        <tr>
        <td><asp:Button ID="Button3" runat="server" Text="Method Statements" onclick="btnmsshcdule_Click" Width="300px"
                 /></td>
        </tr>
        <tr>
        <td><asp:Button ID="Button4" runat="server" Text="Site Observation" onclick="btnmsshcdule_Click" Width="300px"
                 /></td>
        </tr>
        <tr>
        <td><asp:Button ID="Button5" runat="server" Text="Programmes" onclick="btnmsshcdule_Click" Width="300px"
                 /></td>
        </tr>
        </table>  --%>
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>
                    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="400px"
                        Width="100%">
                        <asp:TabPanel runat="server" HeaderText="CAS Sheet" ID="TabPanel1">
                            <ContentTemplate>
                                <div style="padding: 20px">
                                    <div style="float: left; width: 500px">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btncasrpt" runat="server" Text="CAS Sheet Report" Width="400px" OnClick="btncasrpt_Click"
                                                                Visible="False" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnpackagebu" runat="server" Text="Package Break Up" Width="400px"
                                                                OnClick="btnpackagebu_Click" Style="display: none" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnprjsum" runat="server" Text="Project Summary - Per Service Basis"
                                                                System="" Width="400px" OnClick="btnprjsum_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr  id="_Pcd_tr1" runat="server">
                                            <td>
                                            <asp:UpdatePanel ID="UpdatePanel50" runat="server">
                                                        <ContentTemplate>
                                                         <asp:Button ID="btnprjsum_planned" runat="server" Text="Project Summary With Planned -  Per Service Basis"
                                                                System="" Width="400px" OnClick="btnprjsum_planned_Click" />
                                                          </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                       
                                            </td>
                                            </tr>
                                             <tr  id="_Pcd_tr2" runat="server"> 
                                            <td>
                                            <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                                        <ContentTemplate>
                                                          <asp:Button ID="btnexecutivesum" runat="server" Text="Executive summary"
                                                                System="" Width="400px" OnClick="btnexecutivesum_Click" />
                                                          </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                       
                                            </td>
                                            </tr>
                                            <tr id="_11736_tr1" runat="server">
                                                <td id="Td1" align="center" runat="server">
                                                    <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnprjsum_" runat="server" OnClick="btnprjsum__Click" System="" Text="Project Summary - Per Building Basis"
                                                                Width="400px" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td id="Td2" runat="server">
                                                    &nbsp;
                                                </td>
                                                <td id="Td3" runat="server">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btncassum" runat="server" System="" Text="Service Summary - Per Service Basis"
                                                                Width="400px" OnClick="btncassum_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr id="_11736_tr2" runat="server">
                                                <td id="Td4" align="center" runat="server">
                                                    <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnsersum_" runat="server" OnClick="btnsersum__Click" System="" Text="Service Summary - Per Building Basis"
                                                                Width="400px" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td id="Td5" runat="server">
                                                    &nbsp;
                                                </td>
                                                <td id="Td6" runat="server">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="btnpkgsum" runat="server" System="" Text="Package Summary - Per Package Basis"
                                                        Width="400px" OnClick="btnpkgsum_Click" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr id="asao_tr1" runat="server">
                                                <td align="center" runat="server">
                                                    <asp:Button ID="btnsrvsum" runat="server" System="" Text="CAS Sheet Service by Service Summary"
                                                        Width="400px" OnClick="btnsrvsum_Click" />
                                                </td>
                                                <td runat="server">
                                                    &nbsp;
                                                </td>
                                                <td runat="server">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr id="asao_tr2" runat="server">
                                                <td align="center" runat="server">
                                                    <asp:Button ID="btnallsrvsum" runat="server" System="" Text="All Service Summary"
                                                        Width="400px" OnClick="btnallsrvsum_Click" />
                                                </td>
                                                <td runat="server">
                                                    &nbsp;
                                                </td>
                                                <td runat="server">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <table id="mytable" runat="server">
                                                        <tr runat="server">
                                                            <td runat="server">
                                                                Select Service
                                                            </td>
                                                            <td runat="server">
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="drservice" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drservice_SelectedIndexChanged"
                                                                            Width="200px">
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server">
                                                            <td runat="server">
                                                                Select CAS Sheet
                                                            </td>
                                                            <td runat="server">
                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="drcassheet" runat="server" Width="200px">
                                                                        </asp:DropDownList>
                                                                        </td>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server">
                                                            <td runat="server">
                                                                <asp:CheckBox ID="chk" runat="server" Text="All Packages" Visible="False" />
                                                            </td>
                                                            <td runat="server">
                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Button ID="btnview" runat="server" OnClick="btnview_Click" Text="View" />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table id="mytable1" runat="server">
                                                        <tr runat="server">
                                                            <td runat="server">
                                                                Select Building Area
                                                            </td>
                                                            <td style="width: 200px" runat="server">
                                                                <asp:DropDownList ID="drbarea" runat="server">
                                                                    <asp:ListItem Text="Wings" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Main" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="Technical" Value="3"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server">
                                                            <td runat="server">
                                                            </td>
                                                            <td runat="server">
                                                                <asp:Button ID="btnview1" runat="server" Text="View" OnClick="btnview1_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="float: left; padding: 20px; background-color: #D1DEF1; border: solid 1px #d1d1d1"
                                        id="progress_div" runat="server">
                                        <p>
                                            <strong>CAS Sheet Progress Report</strong></p>
                                        <table>
                                            <tr>
                                                <td>
                                                    Select Service
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drsrv" runat="server" Width="200px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Select Division
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drdiv" runat="server" Width="200px">
                                                        <asp:ListItem Text="Wings" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Main" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Technical" Value="3"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnview2" runat="server" Text="Continue" OnClick="btnview2_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel runat="server" HeaderText="Building Basic Report" ID="TabPanel9">
                            <ContentTemplate>
                                <div style="padding: 20px">
                                    <div style="float: left; width: 800px">
                                        <table>
                                            <tr id="Tr1" runat="server">
                                                <td id="Td7" align="center" runat="server">
                                                    <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnbs_main" runat="server" System="" Text="Building Summary - Main"
                                                                Width="400px" OnClick="btnbs_main_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr id="Tr2" runat="server">
                                                <td id="Td10" align="center" runat="server">
                                                    <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btndss" runat="server" System="" Text="Building Summary - Selection"
                                                                Width="400px" OnClick="btndss_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                        <div id="bdiv" runat="server">
                                            <div style="height: 200px; overflow: auto; width: 750px; padding: 0px 10px 20px 10px;
                                                background-color: #D1DEF1; border: solid 2px #d1d1d1">
                                                <p>
                                                    <strong>Select Building</strong></p>
                                                <asp:CheckBoxList ID="blist" runat="server" Height="150px" Width="730px" RepeatColumns="12"
                                                    CssClass="chkstyle">
                                                </asp:CheckBoxList>
                                            </div>
                                            <div style="margin-top: 10px">
                                                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="cmdbview" runat="server" Text="View" OnClick="cmdbview_Click" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel runat="server" HeaderText="Commissioning Plans" ID="TabPanel2">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <div style="padding: 20px">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Button ID="btncp" runat="server" Text="Commissioning Plans Report" Width="400px"
                                                                    OnClick="btncp_Click" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel runat="server" HeaderText="Document Review" ID="TabPanel3">
                            <HeaderTemplate>
                                Document Review
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <div style="padding: 20px">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Button ID="btndrl" runat="server" Text="Document Review Log Report" Width="400px"
                                                                    OnClick="btndrl_Click" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btndrd" runat="server" Text="Document Review Details Report" Width="400px"
                                                            OnClick="btndrd_Click" />
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                            <td>
                                                <asp:Button ID="btndrcommentlog" runat="server" Text="Document Review Comments Log" Width="400px"
                                                    OnClick="btndrcommentlog_Click" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                                <tr>
                                                    <td align="center">
                                                        <table id="dr" runat="server">
                                                            <tr runat="server">
                                                                <td runat="server">
                                                                    Select DR No.
                                                                </td>
                                                                <td runat="server">
                                                                    <asp:DropDownList ID="drdrno" runat="server" Width="150px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server">
                                                                <td runat="server">
                                                                </td>
                                                                <td align="left" runat="server">
                                                                    <asp:Button ID="btndrview" runat="server" Text="View" OnClick="btndrview_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel runat="server" HeaderText="Method Statements" ID="TabPanel4">
                            <ContentTemplate>
                                <div style="padding: 20px">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnmss" runat="server" Text="Method Statement Schedule Report" Width="400px"
                                                    OnClick="btnmss_Click" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr id="trcomment" runat="server">
                                            <td>
                                                <asp:Button ID="btnms" runat="server" Text="Method Statement Comments Report" Width="400px"
                                                    OnClick="btnms_Click" />
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnmsall" runat="server" Text="Summary Of MS Documentation" Width="400px"
                                                    OnClick="btnmsall_Click" />
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnmsd" runat="server" OnClick="btnmsd_Click" Text="Status Of MS Documentation"
                                                    Width="400px" />
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <table id="tbl_msd" runat="server">
                                                    <tr runat="server">
                                                        <td style="width: 100px" runat="server">
                                                            Service
                                                        </td>
                                                        <td style="width: 150px" align="left" runat="server">
                                                            <asp:DropDownList ID="dr_msservice" runat="server" Width="200px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server">
                                                        <td runat="server">
                                                        </td>
                                                        <td align="left" runat="server">
                                                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Button ID="btnmsdview" runat="server" Text="View" OnClick="btnmsdview_Click" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel runat="server" HeaderText="Site Observation" ID="TabPanel5">
                            <ContentTemplate>
                                <div style="padding: 20px">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnsol" runat="server" Text="Site Observation Log Report" Width="400px"
                                                    OnClick="btnsol_Click" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnsod" runat="server" Text="Site Observation Details Report" Width="400px"
                                                    OnClick="btnsod_Click" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <asp:Button ID="btnsocommentlog" runat="server" Text="Site Observation Comments Log" Width="400px"
                                                    OnClick="btnsocommentlog_Click" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <table id="so" runat="server">
                                                    <tr runat="server">
                                                        <td runat="server">
                                                            Select SO No.
                                                        </td>
                                                        <td runat="server">
                                                            <asp:DropDownList ID="drsono" runat="server" Width="150px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server">
                                                        <td runat="server">
                                                        </td>
                                                        <td runat="server" align="left">
                                                            <asp:Button ID="btnsoview" runat="server" Text="View" OnClick="btnsoview_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel runat="server" HeaderText="Programmes" ID="TabPanel6">
                            <ContentTemplate>
                                <div style="padding: 20px">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnpr" runat="server" Text="Programmes Report" Width="400px" OnClick="btnpr_Click" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel runat="server" HeaderText="Training" ID="TabPanel7">
                            <ContentTemplate>
                                <div style="padding: 20px">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btntrsumall" runat="server" Text="Summary Of Training Documentation"
                                                            Width="400px" OnClick="btntrsumall_Click" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btntrsummary" runat="server" OnClick="btntrsummary_Click" Text="Status Of Training Documentation"
                                                            Width="400px" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <table id="tbl_tr" runat="server">
                                                    <tr runat="server">
                                                        <td style="width: 100px" runat="server">
                                                            Service
                                                        </td>
                                                        <td style="width: 150px" align="left" runat="server">
                                                            <asp:DropDownList ID="dr_trservice" runat="server" Width="150px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server">
                                                        <td runat="server">
                                                        </td>
                                                        <td align="left" runat="server">
                                                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Button ID="btntrview" runat="server" Text="View" OnClick="btntrview_Click" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel runat="server" HeaderText="Test Sheets" ID="TabPanel8">
                            <ContentTemplate>
                                <div style="padding: 20px">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btn_tsview" runat="server" Text="Test Sheet Upload Report" Width="400px"
                                                            OnClick="btn_tsview_Click" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                    </asp:TabContainer>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <div id="myprogress" runat="server" style="position: absolute; z-index: 40; top: 50%;
                        left: 50%">
                        <asp:Image ID="myimage" runat="server" ImageUrl="../images/loading30.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </div>
    <div style="width: 400px; height: 200px;background-color:#fff;display:none;" id="popdiv">
        <div style="background-color: #353535; color: #fff; padding: 5px;">
            Select Building</div>
        <div style="padding: 5px;">
            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                <ContentTemplate>
                    <table cellpadding="5">
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButtonList ID="rdbuilding" runat="server">
                                            <asp:ListItem Value="1" Text="CENTRAL UTILITY CENTRE" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="PIAZZA"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="SERVICE BUILDING"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="HARAM"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnenter1" runat="server" CssClass="submitbtn" Text="ENTER" OnClick="btnenter1_Click" />&nbsp;<asp:Button ID="btncancel" runat="server" CssClass="submitbtn" Text="CANCEL" OnClick="btncancel_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
             <asp:UpdateProgress ID="UpdateProgress3" runat="server">
                <ProgressTemplate>
                    <div id="myprogress2" runat="server" style="position: absolute; z-index: 40; top: 50%;
                        left: 50%">
                        <asp:Image ID="myimage2" runat="server" ImageUrl="../images/loading30.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </div>
    <asp:Button ID="btndummy" runat="server" Text="Button" Style="display: none" />
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btndummy"
        PopupControlID="popdiv" BackgroundCssClass="model-background">
    </asp:ModalPopupExtender>
    
    <div style="width: 400px; height: 250px;background-color:#fff;display:none;" id="popdiv1">
        <div style="background-color: #353535; color: #fff; padding: 5px;">
            Select Building</div>
        <div style="padding: 5px;">
            <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                <ContentTemplate>
                    <table cellpadding="5">
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButtonList ID="rdbuilding_" runat="server">
                                            <asp:ListItem Value="1" Text="CENTRAL UTILITY CENTRE" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="PIAZZA"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="SERVICE BUILDING"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="HARAM"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                        <td>
                        Select Service
                        </td>
                        </tr>
                        <tr>
                            <td>
                            <asp:DropDownList ID="drservice_" runat="server" 
                                                                            Width="300px">
                                                                        </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                <ContentTemplate>
                                <asp:Button ID="btnenter2" runat="server" CssClass="submitbtn" Text="ENTER" OnClick="btnenter2_Click" />&nbsp;
                                <asp:Button ID="btncancel1" runat="server" CssClass="submitbtn" Text="CANCEL" OnClick="btncancel1_Click" />
                                </ContentTemplate>
                                </asp:UpdatePanel>
                                
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
             <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                <ProgressTemplate>
                    <div id="myprogress1" runat="server" style="position: absolute; z-index: 40; top: 50%;
                        left: 50%">
                        <asp:Image ID="myimage1" runat="server" ImageUrl="../images/loading30.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </div>
    
    <asp:Button ID="btndummy1" runat="server" Text="Button" Style="display: none" />
    <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btndummy1"
        PopupControlID="popdiv1" BackgroundCssClass="model-background">
    </asp:ModalPopupExtender>
    
    <asp:Button ID="btnDummysummary" runat="server" Text="Button" style="display:none;"  />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtendersummary" runat="server" TargetControlID="btnDummysummary"  PopupControlID="pnlPopupsummary" BackgroundCssClass="model-background"></asp:ModalPopupExtender> 
       <div id="pnlPopupsummary" style="width: 400px; height: 350px;background-color:#fff;display:none;" >
       <div style="background-color: #353535; color: #fff; padding: 5px;">
            Select Building</div>
            <div style="padding: 5px;">
                <asp:UpdatePanel ID="UpdatePanel44" runat="server">
                <ContentTemplate>
                 <table cellpadding="5" >
                <tr>
                     <td>
                         <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                             <ContentTemplate>
                                 <asp:RadioButtonList ID="rdbuilding_1" runat="server">
                                     <asp:ListItem Selected="True" Text="CENTRAL UTILITY CENTRE" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="PIAZZA" Value="2"></asp:ListItem>
                                     <asp:ListItem Text="SERVICE BUILDING" Value="3"></asp:ListItem>
                                     <asp:ListItem Text="HARAM" Value="4"></asp:ListItem>
                                 </asp:RadioButtonList>
                             </ContentTemplate>
                         </asp:UpdatePanel>
                     </td>
                    </tr>
                      <tr>
                
               
                <td> 
                
                    Select Service
                
                </td>
                          <tr>
                              <td>
                                  <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                                      <ContentTemplate>
                                          <asp:DropDownList ID="dr_services" runat="server" AutoPostBack="true" 
                                              OnSelectedIndexChanged="dr_services_SelectedIndexChanged" Width="200px">
                                          </asp:DropDownList>
                                      </ContentTemplate>
                                  </asp:UpdatePanel>
                              </td>
                          </tr>
                          <tr>
                              <td>
                                  Select CAS Sheet</td>
                          </tr>
                          <tr>
                              <td>
                                  <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                      <ContentTemplate>
                                          <asp:DropDownList ID="drcst" runat="server" Width="200px">
                                          </asp:DropDownList>
                                      </ContentTemplate>
                                  </asp:UpdatePanel>
                              </td>
                          </tr>
                          <tr>
                              <td>
                                  <asp:Button ID="btnupdate" runat="server" onclick="btnupdate_Click" 
                                      CssClass="submitbtn" Text="ENTER" Width="100px" />
                                  <asp:Button ID="btncancel3" runat="server" onclick="btncancel3_Click" 
                                      style="background-color:Black;color:White" Text="CANCEL" Width="100px" />
                              </td>
                          </tr>
                </tr>
                
                </table>
                
                
      
                </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UpdateProgress4" runat="server">
                <ProgressTemplate>
                    <div id="myprogress3" runat="server" style="position: absolute; z-index: 40; top: 50%;
                        left: 50%">
                        <asp:Image ID="myimage3" runat="server" ImageUrl="../images/loading30.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div> 
               
        </div>
        
      <asp:Button ID="btnpackagesum" runat="server" Text="Button" Style="display: none" />
    <asp:ModalPopupExtender ID="ModalPopupExtender3" runat="server" TargetControlID="btnpackagesum"
        PopupControlID="pop_package" BackgroundCssClass="model-background">
    </asp:ModalPopupExtender>
    
    <div style="width:440px; height: 150px;background-color:#fff;display:none;" id="pop_package">
        <div style="background-color: #353535; color: #fff; padding: 5px;">
            Select details</div>
        <div style="padding: 5px;">
            <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                <ContentTemplate>
                    <table cellpadding="5">
                    
                        <tr>
                        <td> Select Package</td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                                    <ContentTemplate>
                                        <%--<telerik:RadDropDownList ID="rd_package" runat="server" OnSelectedIndexChanged="rd_package_SelectedIndexChanged"
                                            Skin="Metro" RenderMode="Lightweight" DefaultMessage="Select Package" Width="350px"
                                            AutoPostBack="true">
                                        </telerik:RadDropDownList>--%>
                                        
                                         <asp:DropDownList ID="rd_package" runat="server" AutoPostBack="true" 
                                              OnSelectedIndexChanged="rd_package_SelectedIndexChanged" Width="300px">
                                          </asp:DropDownList>
                                        
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                                                <tr>
                                                   <td> Select Facility </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                                    <ContentTemplate>
                                        
                                         <asp:DropDownList ID="rd_facility" runat="server" AutoPostBack="true" 
                                              OnSelectedIndexChanged="rd_facility_SelectedIndexChanged" Width="300px">
                                          </asp:DropDownList>
                                        
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>

                        <tr>
                        <td></td>
                            <td>
                            
                                <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                                <ContentTemplate>
                                <asp:Button ID="btnenter3" runat="server" CssClass="submitbtn" Text="ENTER" OnClick="btnenter3_Click" />&nbsp;
                                <asp:Button ID="btncancelc3" runat="server" CssClass="submitbtn" Text="CANCEL" OnClick="btncancelc3_Click" />
                                </ContentTemplate>
                                </asp:UpdatePanel>
                                
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
             <asp:UpdateProgress ID="UpdateProgress5" runat="server">
                <ProgressTemplate>
                    <div id="myprogress4" runat="server" style="position: absolute; z-index: 40; top: 50%;
                        left: 50%">
                        <asp:Image ID="myimage4" runat="server" ImageUrl="../images/loading30.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </div>     
    
    
       
      <asp:Button ID="btnfacilitysum" runat="server" Text="Button" Style="display: none" />
    <asp:ModalPopupExtender ID="ModalPopupExtender4" runat="server" TargetControlID="btnfacilitysum"
        PopupControlID="pop_facility" BackgroundCssClass="model-background">
    </asp:ModalPopupExtender>
    
    <div style="width:440px; height: 180px;background-color:#fff;display:none;" id="pop_facility">
        <div style="background-color: #353535; color: #fff; padding: 5px;">
            Select details</div>
        <div style="padding: 5px;">
            <asp:UpdatePanel ID="UpdatePanel38" runat="server">
                <ContentTemplate>
                    <table cellpadding="5">
                    
                        <tr>
                        <td> Select Package</td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel39" runat="server">
                                    <ContentTemplate>
                                         <asp:DropDownList ID="rd_package1" runat="server" AutoPostBack="true" 
                                              OnSelectedIndexChanged="rd_package1_SelectedIndexChanged" Width="300px">
                                          </asp:DropDownList>
                                        
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                                                <tr>
                                                   <td> Select Facility </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                                    <ContentTemplate>
                                        
                                         <asp:DropDownList ID="rd_facility1" runat="server" AutoPostBack="true" 
                                              OnSelectedIndexChanged="rd_facility1_SelectedIndexChanged" Width="300px">
                                          </asp:DropDownList>
                                        
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                          <tr>
                                                   <td> Select Service </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                                    <ContentTemplate>
                                        
                                         <asp:DropDownList ID="rd_service" runat="server" AutoPostBack="true" 
                                              Width="300px">
                                          </asp:DropDownList>
                                        
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>

                        <tr>
                        <td></td>
                            <td>
                            
                                <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                <ContentTemplate>
                                <asp:Button ID="btnenter4" runat="server" CssClass="submitbtn" Text="ENTER" OnClick="btnenter4_Click" />&nbsp
                                <asp:Button ID="btncancel4" runat="server" CssClass="submitbtn" Text="CANCEL" OnClick="btncancel4_Click" />
                                </ContentTemplate>
                                </asp:UpdatePanel>
                                
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
             <asp:UpdateProgress ID="UpdateProgress6" runat="server">
                <ProgressTemplate>
                    <div id="myprogress5" runat="server" style="position: absolute; z-index: 40; top: 50%;
                        left: 50%">
                        <asp:Image ID="myimage5" runat="server" ImageUrl="../images/loading30.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </div>       
    
    
           
      <asp:Button ID="btndummycassum" runat="server" Text="Button" Style="display: none" />
    <asp:ModalPopupExtender ID="ModalPopupExtender5" runat="server" TargetControlID="btndummycassum"
        PopupControlID="pop_cas" BackgroundCssClass="model-background">
    </asp:ModalPopupExtender>
    
    <div style="width:460px; height: 215px;background-color:#fff;display:none;" id="pop_cas">
        <div style="background-color: #353535; color: #fff; padding: 5px;">
            Select details</div>
        <div style="padding: 5px;">
            <asp:UpdatePanel ID="UpdatePanel43" runat="server">
                <ContentTemplate>
                    <table cellpadding="5">
                    
                        <tr>
                        <td> Select Package</td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel45" runat="server">
                                    <ContentTemplate>
                                         <asp:DropDownList ID="rd_package2" runat="server" AutoPostBack="true" 
                                              OnSelectedIndexChanged="rd_package2_SelectedIndexChanged" Width="300px">
                                          </asp:DropDownList>
                                        
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                                                <tr>
                                                   <td> Select Facility </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel46" runat="server">
                                    <ContentTemplate>
                                        
                                         <asp:DropDownList ID="rd_facility2" runat="server" AutoPostBack="true" 
                                              OnSelectedIndexChanged="rd_facility2_SelectedIndexChanged" Width="300px">
                                          </asp:DropDownList>
                                        
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                          <tr>
                                                   <td> Select Service </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel47" runat="server">
                                    <ContentTemplate>
                                        
                                         <asp:DropDownList ID="rd_service1" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="rd_service1_SelectedIndexChanged"
                                              Width="300px">
                                          </asp:DropDownList>
                                        
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                                                  <tr>
                              <td>
                                  Select CAS Sheet</td>

                              <td>
                                  <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                      <ContentTemplate>
                                          <asp:DropDownList ID="rd_cassheet" runat="server" Width="300px">
                                          </asp:DropDownList>
                                      </ContentTemplate>
                                  </asp:UpdatePanel>
                              </td>
                          </tr>

                        <tr>
                        <td></td>
                            <td>
                            
                                <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                                <ContentTemplate>
                                <asp:Button ID="btnenter5" runat="server" CssClass="submitbtn" Text="ENTER" OnClick="btnenter5_Click" />
                                &nbsp;<asp:Button ID="btncancel5" runat="server" CssClass="submitbtn" Text="CANCEL" OnClick="btncancel5_Click" />
                                </ContentTemplate>
                                </asp:UpdatePanel>
                                
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
             <asp:UpdateProgress ID="UpdateProgress7" runat="server">
                <ProgressTemplate>
                    <div id="myprogress6" runat="server" style="position: absolute; z-index: 40; top: 50%;
                        left: 50%">
                        <asp:Image ID="myimage6" runat="server" ImageUrl="../images/loading30.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </div>       
        
        
        
        
        
    </form>
</body>
</html>
