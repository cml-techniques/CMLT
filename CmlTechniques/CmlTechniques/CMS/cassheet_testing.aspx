<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cassheet_testing.aspx.cs" Inherits="CmlTechniques.CMS.cassheet_testing" ValidateRequest="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" /> 

    

   
    

    </head>
<body>
    <form id="form1" runat="server">
    <div style="height:100%;position:absolute;width:100%">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div style="float:left;width:98.5%">
        <table style="font-family:Verdana;font-size:x-small;background-color:#9EB6CE;width:100%;" cellspacing="1" border="0">
       <tr  style="background-image: url('../images/head_bg.png'); background-repeat: repeat;">
       
                            <td align="center" rowspan="2" valign="middle"   width="6%">
                                &nbsp;</td>
       
                            <td align="center" rowspan="2" valign="middle"   width="6%">
                                ITM.NO</td>
       
                            <td align="center" rowspan="2" valign="middle"   width="10%">
                                ENG.REF</td>
                            <td align="center" colspan="4" valign="middle"  >
                                ASSET CODE</td>
                            <td align="center" rowspan="2" valign="middle" width="10%" >
                                <asp:Label ID="lblloc" runat="server" Text="LOCATION"></asp:Label>
                            </td>
                            <td align="center" rowspan="2" valign="middle" width="10%" >
                                <asp:Label ID="lbl1" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="10%" >
                                <asp:Label ID="lbl3" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="10%" >
                                <asp:Label ID="lbl2" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="10%" >
                                <asp:Label ID="lbnum" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat;">
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
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drfed" runat="server" Width="100%" OnSelectedIndexChanged="drfed_SelectedIndexChanged" AutoPostBack="true"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
                        </table>
        </div>
        <div style="position:relative; height:80%;overflow:scroll;float:left;width:100%;">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:GridView ID="mygrid"  runat="server" AutoGenerateColumns="False" 
                onpageindexchanging="mygrid_PageIndexChanging" onsorting="mygrid_Sorting" 
                onrowcommand="mygrid_RowCommand" onrowediting="mygrid_RowEditing" 
                    onselectedindexchanged="mygrid_SelectedIndexChanged" 
                    onselectedindexchanging="mygrid_SelectedIndexChanging" 
                    onrowupdated="mygrid_RowUpdated" onrowupdating="mygrid_RowUpdating" 
                    onrowdatabound="mygrid_RowDataBound" Width="100%" 
                    onrowcreated="mygrid_RowCreated" ShowHeader="False" Font-Names="Verdana" 
                    Font-Size="X-Small">
                <Columns>
                
                <asp:ButtonField ButtonType="Button" Text="Update" CommandName="Update" 
                        ItemStyle-Width="6%" >
                
                    <ItemStyle Width="6%"  />
                    </asp:ButtonField>
                
                <asp:BoundField HeaderText="Itm.No" ItemStyle-Width="6%" >
                    <ItemStyle Width="6%" />
                    </asp:BoundField>
                <asp:BoundField DataField ="E_b_ref" HeaderText="Engg.Reff" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" />
                    </asp:BoundField>
                <asp:BoundField DataField="B_Z" HeaderText="Building/Zone" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" />
                    </asp:BoundField>
                <asp:BoundField DataField="cat" HeaderText="Category" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" />
                    </asp:BoundField>    
                <asp:BoundField DataField="F_lvl" HeaderText="Floor Level" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" />
                    </asp:BoundField>
                <asp:BoundField DataField="Sq_No" HeaderText="Seq.No" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" />
                    </asp:BoundField>
                <asp:BoundField DataField="Loc" HeaderText="Location" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" />
                    </asp:BoundField>
                <asp:BoundField DataField="P_P_to" HeaderText="Provides Power To" 
                        ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" />
                    </asp:BoundField>
                <asp:BoundField DataField="F_from" HeaderText="Fed From" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" />
                    </asp:BoundField>
                <asp:BoundField DataField="Substation" HeaderText="Substation" 
                        ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" />
                    </asp:BoundField>
                <asp:BoundField DataField="devices1" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" />
                    </asp:BoundField>
                <asp:BoundField DataField="C_id" />
                </Columns>
            </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
            
        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
        <div id="myprogress" runat="server" style="position: absolute; z-index: 40; top: 0; left: 50%">
                <img src="~/images/loading30.gif" alt="" /> 
                Please Wait...
            </div>
        </ProgressTemplate>
        </asp:UpdateProgress>
       
         <asp:Panel ID="pnlPopup" runat="server" Width="950px" Height="375px" style="padding:5px" BackColor="White"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                
                <%--<div>
                <table>
                <tr>
                <td width="250px">
                            Planned Power on</td>
                        <td>
                            <asp:TextBox ID="date8" runat="server" Width="100px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                </tr>
                </table>
                </div>
                <div>
                    <asp:Panel ID="pnlele" runat="server" Visible="false">
                    <table >
                    <tr>
                        <td colspan="2" bgcolor="#CCCCCC">
                            PANEL/EQUIPMENT TESTING</td>
                        <td colspan="2" bgcolor="#CCCCCC">
                            OUTGOING CIRCUIT TESTING</td>
                    </tr>
                    <tr>
                        <td width="250px">
                            <asp:Label ID="test1" runat="server" Text=""></asp:Label>
                        </td>
                        <td width="110px">
                            <asp:TextBox ID="date1" runat="server" Width="100px" 
                                ontextchanged="date1_TextChanged"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="date1" PopupButtonID="date1" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="250px">
                            Total Number of Circuits</td>
                        <td width="110px">
                            <asp:TextBox ID="dev1" runat="server" Width="100px"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            <asp:Label ID="test2" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="date2" runat="server" Width="100px" 
                                ontextchanged="date2_TextChanged"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="date2" PopupButtonID="date2" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="250px">
                            <asp:Label ID="test8" runat="server" Text=""></asp:Label>
                        </td>
                        <td width="110px">
                            <asp:TextBox ID="tested1" runat="server" Width="100px"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            <asp:Label ID="test3" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="date3" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="date3" PopupButtonID="date3" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="250px">
                            <asp:Label ID="test9" runat="server" Text=""></asp:Label>
                            
                        </td>
                        <td width="110px">
                            <asp:TextBox ID="date11" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="date11" PopupButtonID="date11" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            <asp:Label ID="test4" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="date4" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="date4" PopupButtonID="date4" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="250px">
                            <asp:Label ID="test10" runat="server" Text=""></asp:Label>
                        </td>
                        <td width="110px">
                            <asp:TextBox ID="tested2" runat="server" Width="100px"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            <asp:Label ID="test5" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="date5" runat="server" Width="100px" 
                                ontextchanged="date5_TextChanged"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="date5" PopupButtonID="date5" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="250px">
                            <asp:Label ID="test11" runat="server" Text=""></asp:Label>
                        </td>
                        <td width="110px">
                            <asp:TextBox ID="date13" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="date13" PopupButtonID="date13" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="250px" class="style1">
                            <asp:Label ID="test6" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="date6" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender11" runat="server" TargetControlID="date6" PopupButtonID="date6" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td class="style1">
                            </td>
                        <td width="110px" class="style1">
                            </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            <asp:Label ID="test7" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="date7" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender12" runat="server" TargetControlID="date7" PopupButtonID="date7" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td width="110px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="250px" bgcolor="#CCCCCC" colspan="4" style="width: 360px">
                            &nbsp;</td>
                    </tr>
                    
                </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlmech" runat="server" Visible="false">
                    <table >
                    <tr>
                        <td colspan="2" bgcolor="#CCCCCC">
                            MECHANICAL SYSTEM</td>
                        <td colspan="2" bgcolor="#CCCCCC">
                            CONTROLS</td>
                    </tr>
                    <tr>
                        <td width="250px">
                            PRE-COM</td>
                        <td width="110px">
                            <asp:TextBox ID="precom1" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="precom1" PopupButtonID="precom1" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="250px">
                            PRE-COM</td>
                        <td width="110px">
                            <asp:TextBox ID="precom2" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="precom2" PopupButtonID="precom2" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            COMM</td>
                        <td>
                            <asp:TextBox ID="comm1" runat="server" Width="100px" 
                                ></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="comm1" PopupButtonID="comm1" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="250px">
                            COMM</td>
                        <td width="110px">
                            <asp:TextBox ID="comm2" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender16" runat="server" TargetControlID="comm2" PopupButtonID="comm2" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            % OF DUTY</td>
                        <td>
                            <asp:TextBox ID="duty" runat="server" Width="100px" 
                                ></asp:TextBox>
                            
                        </td>
                        <td width="250px">
                            WITNESSED</td>
                        <td width="110px">
                            <asp:TextBox ID="witnessed2" runat="server" Width="100px" 
                                ></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender17" runat="server" TargetControlID="witnessed2" PopupButtonID="witnessed2" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            WITNESSED DATE</td>
                        <td>
                            <asp:TextBox ID="witnessed1" runat="server" Width="100px" 
                                ></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender18" runat="server" TargetControlID="witnessed1" PopupButtonID="witnessed1" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="250px">
                            &nbsp;</td>
                        <td width="110px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="250px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td width="250px">
                            &nbsp;</td>
                        <td width="110px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="250px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td width="110px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="250px" bgcolor="#CCCCCC" colspan="4" style="width: 360px">
                            &nbsp;</td>
                    </tr>
                    
                </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlph" runat="server" Visible="false">
                    <table >
                    <tr>
                        <td colspan="2" bgcolor="#CCCCCC">
                            COMMISSIONING AND ACCEPTANCE</td>
                        <td colspan="2" bgcolor="#CCCCCC">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="250px">
                            ROOM/SYSTEM INTEGRITY TEST</td>
                        <td width="110px">
                            <asp:TextBox ID="phtest1" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender19" runat="server" TargetControlID="phtest1" PopupButtonID="phtest1" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="250px">
                            &nbsp;</td>
                        <td width="110px">
                            <asp:CalendarExtender ID="CalendarExtender20" runat="server" TargetControlID="precom2" PopupButtonID="precom2" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            STAND ALONE COMMISSION</td>
                        <td>
                            <asp:TextBox ID="phtest2" runat="server" Width="100px" 
                                ></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender21" runat="server" TargetControlID="phtest2" PopupButtonID="phtest2" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="250px">
                            &nbsp;</td>
                        <td width="110px">
                            <asp:CalendarExtender ID="CalendarExtender22" runat="server" TargetControlID="comm2" PopupButtonID="comm2" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            FIRE &amp; BMS INTERFACE TEST</td>
                        <td>
                            <asp:TextBox ID="phtest3" runat="server" Width="100px" 
                                ></asp:TextBox>
                            
                        </td>
                        <td width="250px">
                            &nbsp;</td>
                        <td width="110px">
                            <asp:CalendarExtender ID="CalendarExtender23" runat="server" TargetControlID="phtest3" PopupButtonID="phtest3" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            WITNESSED</td>
                        <td>
                            <asp:TextBox ID="phtest4" runat="server" Width="100px" 
                                ></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender24" runat="server" TargetControlID="phtest4" PopupButtonID="phtest4" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="250px">
                            &nbsp;</td>
                        <td width="110px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="250px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td width="250px">
                            &nbsp;</td>
                        <td width="110px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="250px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td width="110px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="250px" bgcolor="#CCCCCC" colspan="4" style="width: 360px">
                            &nbsp;</td>
                    </tr>
                    
                </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlfire" runat="server" Visible="false">
                    <table >
                    <tr>
                        <td colspan="2" bgcolor="#CCCCCC">
                            &nbsp;</td>
                        <td colspan="2" bgcolor="#CCCCCC">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="250px">
                            CIRCUIT IR TESTED</td>
                        <td width="110px">
                            <asp:TextBox ID="fairtested" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender25" runat="server" TargetControlID="fairtested" PopupButtonID="fairtested" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="250px">
                            LOOP TEST COMPLETED</td>
                        <td width="110px">
                            <asp:CalendarExtender ID="CalendarExtender26" runat="server" TargetControlID="precom2" PopupButtonID="precom2" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                            <asp:TextBox ID="looptestcomplete" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender27" runat="server" TargetControlID="looptestcomplete" PopupButtonID="looptestcomplete" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            NO.OF DEVICES</td>
                        <td>
                            <asp:TextBox ID="no_dvs" runat="server" Width="100px" 
                                ></asp:TextBox>
                        </td>
                        <td width="250px">
                            SOUND LEVEL TEST</td>
                        <td width="110px">
                            <asp:CalendarExtender ID="CalendarExtender28" runat="server" TargetControlID="soundlvltest" PopupButtonID="soundlvltest" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                            <asp:TextBox ID="soundlvltest" runat="server" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            NO.OF DEVICES TESTED</td>
                        <td>
                            <asp:TextBox ID="dvstested" runat="server" Width="100px" 
                                ></asp:TextBox>
                            
                        </td>
                        <td width="250px">
                            BATTERY AUTONOMY TEST</td>
                        <td width="110px">
                            <asp:CalendarExtender ID="CalendarExtender29" runat="server" TargetControlID="batest" PopupButtonID="batest" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                            <asp:TextBox ID="batest" runat="server" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            DEVICE TEST COMPLETE</td>
                        <td>
                            <asp:TextBox ID="dvscomplete" runat="server" Width="100px" 
                                ></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender30" runat="server" TargetControlID="dvscomplete" PopupButtonID="dvscomplete" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="250px">
                            GRAPHICS/HEAD END TESTS</td>
                        <td width="110px">
                            <asp:TextBox ID="ghetest" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender37" runat="server" TargetControlID="ghetest" PopupButtonID="ghetest" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            NO.OF INTERFACE</td>
                        <td>
                            <asp:TextBox ID="inface" runat="server" Width="100px"></asp:TextBox>
                        </td>
                        <td width="250px">
                            &nbsp;</td>
                        <td width="110px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="250px">
                            FA INTERFACE TESTED</td>
                        <td>
                            <asp:TextBox ID="infacetested" runat="server" Width="100px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td width="110px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="250px" bgcolor="#CCCCCC" colspan="4" style="width: 360px">
                            &nbsp;</td>
                    </tr>
                    
                </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlbms" runat="server" Visible="false">
                    <table >
                    <tr>
                        <td colspan="2" bgcolor="#CCCCCC">
                            COMMISSIONING AND TESTING&nbsp;</td>
                        <td colspan="2" bgcolor="#CCCCCC">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="250px">
                            NO.OF POINTS</td>
                        <td width="110px">
                            <asp:TextBox ID="bmspoints" runat="server" Width="100px"></asp:TextBox>
                            
                        </td>
                        <td width="250px">
                            SEQ. OF OP TEST</td>
                        <td width="110px">
                            
                            <asp:TextBox ID="sqoptest" runat="server" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            CONTINUITY/IR TEST</td>
                        <td>
                            <asp:TextBox ID="bmsirtest" runat="server" Width="100px" 
                                ></asp:TextBox>
                             
                        </td>
                        <td width="250px">
                            GRAPHICS/HEAD END TESTS</td>
                        <td width="110px">
                            <asp:TextBox ID="bmsghetest" runat="server" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            POINT TO POINT TEST</td>
                        <td>
                            <asp:TextBox ID="bmspptest" runat="server" Width="100px" 
                                ></asp:TextBox>
                            
                        </td>
                        <td width="250px">
                            &nbsp;</td>
                        <td width="110px">
                            <asp:CalendarExtender ID="CalendarExtender35" runat="server" TargetControlID="witnessed2" PopupButtonID="witnessed2" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            POINT TEST COMPLETE</td>
                        <td>
                            <asp:TextBox ID="pointcomplete" runat="server" Width="100px" 
                                ></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender36" runat="server" TargetControlID="pointcomplete" PopupButtonID="pointcomplete" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td width="250px">
                            &nbsp;</td>
                        <td width="110px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="250px" bgcolor="#CCCCCC" colspan="4" style="width: 360px">
                            &nbsp;</td>
                    </tr>
                    
                </table>
                    </asp:Panel>
                </div>
                <div>
                <table>
                <tr>
                        <td width="250px">
                            Consultant Accepted</td>
                        <td>
                            <asp:TextBox ID="date14" runat="server" Width="100px" 
                                ontextchanged="date14_TextChanged"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender13" runat="server" TargetControlID="date14" PopupButtonID="date14" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                        <td>
                            Test Sheets Filed</td>
                        <td width="110px">
                            <asp:TextBox ID="date15" runat="server" Width="100px" 
                                ontextchanged="date15_TextChanged"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender14" runat="server" TargetControlID="date15" PopupButtonID="date15" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            Comments</td>
                        <td colspan="2">
                            <asp:TextBox ID="comm" runat="server" Width="351px" Height="60px" 
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td width="110px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="250px">
                            Action By</td>
                        <td style="width: 0">
                            <asp:TextBox ID="actby" runat="server" Width="100px"></asp:TextBox>
                        </td>
                        <td width="250px" style="width: 125px">
                            Action Date</td>
                        <td width="110px">
                            <asp:TextBox ID="date18" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender15" runat="server" TargetControlID="date18" PopupButtonID="date18" ClearTime="true" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="250px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td style="width: 125px" width="250px">
                            &nbsp;</td>
                        <td width="110px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="250px">
                            &nbsp;</td>
                        <td colspan="2">
                            <asp:Button ID="btnupdate" runat="server" Text="Update" 
                                onclick="btnupdate_Click" />
                            <asp:Button ID="btncancel" runat="server" Text="Cancel" 
                                onclick="btncancel_Click" />
                        </td>
                        <td width="110px">
                            &nbsp;</td>
                    </tr>
                </table>
                </div>--%>
                <table style="width:100%" border="0" cellpadding="3" cellspacing="1" >
                <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
                <td>
                <asp:TextBox ID="txtppon" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="txtppon" PopupButtonID="txtppon" ClearTime="true" 
                        Format="dd/MM/yyyy" ></asp:CalendarExtender>
                </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                <td>
                </td>
                <td></td>
                </tr>
                
                    <tr style="background-color:#5D7B9D;color:White">
                        <td colspan="4"  align="center">
                            <asp:Label ID="testhead1" runat="server" Text=""></asp:Label></td>
                        <td colspan="2"  align="center" >
                            <asp:Label ID="testhead2" runat="server" Text=""></asp:Label></td>
                    </tr>
                
                    <tr>
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="test1" runat="server" Width="100px" 
                                ></asp:TextBox>
                            <asp:CalendarExtender ID="date2_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="test1" 
                                TargetControlID="test1">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="test7" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date15_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="test7" 
                                TargetControlID="test7">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #90B3CF">
                            <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #90B3CF">
                            <asp:TextBox ID="txtdevices1" runat="server" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #BCDCFD" >
                            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD" >
                            <asp:TextBox ID="test2" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="test2_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="test2" 
                                TargetControlID="test2">
                            </asp:CalendarExtender>
                            </td>
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label16" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="test8" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date16_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="test8" 
                                TargetControlID="test8">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #90B3CF" >
                            <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                            </td>
                        <td style="background-color: #90B3CF" >
                            <asp:TextBox ID="notested1" runat="server" Width="100px"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="test3" runat="server" Width="100px" 
                                ></asp:TextBox>
                            <asp:CalendarExtender ID="date4_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="test3" 
                                TargetControlID="test3">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label22" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="test10" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date14_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="test10" 
                                TargetControlID="test10">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #90B3CF">
                            <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #90B3CF">
                            <asp:TextBox ID="testcomp1" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date10_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="testcomp1" 
                                TargetControlID="testcomp1">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #BCDCFD" >
                            <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD" >
                            <asp:TextBox ID="test4" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date5_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="test4" 
                                TargetControlID="test4">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label23" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="test11" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date18_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="test11" 
                                TargetControlID="test11">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #90B3CF" >
                            <asp:Label ID="Label12" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #90B3CF" >
                            <asp:TextBox ID="notested2" runat="server" Width="100px"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #BCDCFD" >
                           <asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
                        <td  style="background-color: #BCDCFD">
                            <asp:TextBox ID="test5" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date6_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="test5" 
                                TargetControlID="test5">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label24" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="test12" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="test12_CalendarExtender0" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="test12" 
                                TargetControlID="test12">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #90B3CF" >
                            <asp:Label ID="Label13" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #90B3CF" >
                            <asp:TextBox ID="testcomp2" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date12_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="testcomp2" 
                                TargetControlID="testcomp2">
                            </asp:CalendarExtender>
                            </td>
                    </tr>
                    <tr>
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label7" runat="server" Text=""></asp:Label></td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="test6" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date7_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="test6" 
                                TargetControlID="test6">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #BCDCFD">
                            &nbsp;</td>
                        <td style="background-color: #BCDCFD">
                            &nbsp;</td>
                        <td style="background-color: #90B3CF">
                            <asp:Label ID="Label14" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="background-color: #90B3CF">
                            <asp:TextBox ID="test9" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date13_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="test9" 
                                TargetControlID="test9">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label18" runat="server" Text="Consultant Accepted"></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="conaccept1" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="test12_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="conaccept1" 
                                TargetControlID="conaccept1">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #BCDCFD">
                            &nbsp;</td>
                        <td style="background-color: #BCDCFD">
                            &nbsp;</td>
                        <td style="background-color: #90B3CF">
                            <asp:Label ID="Label19" runat="server" Text="Consultant Accepted"></asp:Label>
                        </td>
                        <td style="background-color: #90B3CF">
                            <asp:TextBox ID="conaccept2" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="test13_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="conaccept2" 
                                TargetControlID="conaccept2">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                
                    <tr>
                        <td style="background-color: #BCDCFD">
                            <asp:Label ID="Label20" runat="server" Text="Test Sheet Filed"></asp:Label>
                        </td>
                        <td style="background-color: #BCDCFD">
                            <asp:TextBox ID="txtfiled1" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtendertxt" runat="server" ClearTime="true" 
                                Format="dd/MM/yyyy" PopupButtonID="txtfiled1" TargetControlID="txtfiled1">
                            </asp:CalendarExtender>
                        </td>
                        <td style="background-color: #BCDCFD">
                            &nbsp;</td>
                        <td style="background-color: #BCDCFD">
                            &nbsp;</td>
                        <td style="background-color: #90B3CF">
                            <asp:Label ID="Label21" runat="server" Text="Test Sheet Filed"></asp:Label>
                        </td>
                        <td style="background-color: #90B3CF">
                            <asp:TextBox ID="txtfiled" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="actdate0_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txtfiled" 
                                TargetControlID="txtfiled">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Action By</td>
                        <td align="left" >
                            <asp:TextBox ID="actby" runat="server" Width="100px"></asp:TextBox>
                            
                        </td>
                        <td align="left" >
                            Comments</td>
                        <td align="left" colspan="3" rowspan="2" >
                            <%--<asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>--%><asp:TextBox ID="txtcomment" runat="server" Height="50px" 
                                TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                
                    <tr>
                        <td>
                            Action Date</td>
                        <td align="left">
                            <asp:TextBox ID="actdate" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="date22_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="actdate" 
                                TargetControlID="actdate">
                            </asp:CalendarExtender>
                        </td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                            <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>--%><asp:Button ID="btnupdate" runat="server" 
                                onclick="btnupdate_Click" Text="Update" />
                            <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </td>
                        <td align="right">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                            <%--<asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>--%>
                            <asp:Button ID="btncancel" runat="server" onclick="btncancel_Click" 
                                Text="Cancel" />
                            <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                </table>
             </ContentTemplate>
                </asp:UpdatePanel>
            </div>
                        
                  </asp:Panel>
                  
                    <asp:Button ID="btnDummy" runat="server" Text="Button" style="display:none;"  />
                  <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" 
                  TargetControlID="btnDummy"  PopupControlID="pnlPopup"
                  BackgroundCssClass="modal"
                  DropShadow="true">
                  </asp:ModalPopupExtender> 
    </div>
    </form>
</body>
</html>
