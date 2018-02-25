﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="caslvreport_pcd.aspx.cs" Inherits="CmlTechniques.CMS.caslvreport_pcd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
     <link href="../page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .gvHeaderRow
    {
        background-image:url('../images/head_bg.png');
        background-repeat: repeat;
        font-family:Verdana;
        font-size:x-small;
        font-weight:normal;
    }
    .gvFooetRow
    {
        font-family:Verdana;
        font-size:x-small;
        font-weight:normal;
        height:30px;
        background-color:#C8ECFB;
    }
    </style>
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function CreateGridHeader(DataDiv, mymaster, HeaderDiv) {
            var DataDivObj = document.getElementById(DataDiv);
            var DataGridObj = document.getElementById(mymaster);
            var HeaderDivObj = document.getElementById(HeaderDiv);
            //********* Creating new table which contains the header row ***********
            //            var HeadertableObj = HeaderDivObj.appendChild(document.createElement('table'));

            //            DataDivObj.style.paddingTop = '0px';
            //            var DataDivWidth = DataDivObj.clientWidth;
            //DataDivObj.style.width = '2550px';

            //********** Setting the style of Header Div as per the Data Div ************
            HeaderDivObj.className = DataDivObj.className;
            HeaderDivObj.style.cssText = DataDivObj.style.cssText;
            //**** Making the Header Div scrollable. *****
            HeaderDivObj.style.overflow = 'auto';
            //*** Hiding the horizontal scroll bar of Header Div ****
            HeaderDivObj.style.overflowX = 'hidden';
            //**** Hiding the vertical scroll bar of Header Div ****
            HeaderDivObj.style.overflowY = 'hidden';
            //HeaderDivObj.style.height = DataGridObj.rows[0].clientHeight + 'px';
            HeaderDivObj.style.height = document.getElementById("headTbl").style.height + 'px';
            //HeaderDivObj.style.width = DataDivObj.
            //**** Removing any border between Header Div and Data Div ****
            HeaderDivObj.style.borderBottomWidth = '0px';

            //********** Setting the style of Header Table as per the GridView ************
            //            HeadertableObj.className = DataGridObj.className;
            //            //**** Setting the Headertable css text as per the GridView css text 
            //            HeadertableObj.style.cssText = DataGridObj.style.cssText;
            //            HeadertableObj.border = '1px';
            //            HeadertableObj.rules = 'all';
            //            HeadertableObj.cellPadding = DataGridObj.cellPadding;
            //            HeadertableObj.cellSpacing = DataGridObj.cellSpacing;

            //********** Creating the new header row **********
            //            var Row = HeadertableObj.insertRow(0);
            //            Row.className = DataGridObj.rows[0].className;
            //            Row.style.cssText = DataGridObj.rows[0].style.cssText;
            //            Row.style.fontWeight = 'bold';

            //******** This loop will create each header cell *********
            //            for (var iCntr = 0; iCntr < DataGridObj.rows[0].cells.length; iCntr++) {
            //                var spanTag = Row.appendChild(document.createElement('td'));
            //                spanTag.innerHTML = DataGridObj.rows[0].cells[iCntr].innerHTML;
            //                var width = 0;
            //                //****** Setting the width of Header Cell **********
            //                if (spanTag.clientWidth > DataGridObj.rows[1].cells[iCntr].clientWidth) {
            //                    width = spanTag.clientWidth;
            //                }
            //                else {
            //                    width = DataGridObj.rows[1].cells[iCntr].clientWidth;
            //                }
            //                if (iCntr <= DataGridObj.rows[0].cells.length - 2) {
            //                    spanTag.style.width = width + 'px';
            //                }
            //                else {
            //                    spanTag.style.width = width + 20 + 'px';
            //                }
            //                DataGridObj.rows[1].cells[iCntr].style.width = width + 'px';
            //            }
            //            var tableWidth = DataGridObj.clientWidth;
            //********* Hidding the original header of GridView *******
            //            DataGridObj.rows[0].style.display = 'none';
            //********* Setting the same width of all the componets **********
            //            HeaderDivObj.style.width = DataDivWidth + 'px';
            //            DataDivObj.style.width = DataDivWidth + 'px';
            //            DataGridObj.style.width = tableWidth + 'px';
            //            HeadertableObj.style.width = tableWidth + 20 + 'px';
            return false;
        }

        function Onscrollfnction() {
                       var div = document.getElementById('DataDiv');
            var div2 = document.getElementById('HeaderDiv');
            //var div3 = document.getElementById('HeaderTable');
            //****** Scrolling HeaderDiv along with DataDiv ******
            div2.scrollLeft = div.scrollLeft;
            //div3.scrollLeft = div.scrollLeft;
            return false;
        }

        function ResizeWidth() {
            var width = $(window).width();
            var width1 = $(window).width() - 15;
            var height = $(window).height()-108;
            $("#DataDiv").width(width);
            $("#HeaderDiv").width(width1);
            $("#DataDiv").height(height);
        }
    </script>
</head>
<body onload="javascript:ResizeWidth();" style="background-color:#E9E9E9">
    <form id="form1" runat="server">
    
    
    <div style="font-family: verdana; font-size: xx-small">
         <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div style="background-color:#092443;color:White;font-weight:bold;font-size:small;width:100%;height:26px">
        <table >
                    <tr>
                        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
         <asp:Button ID="print" runat="server" Text="Print Report" 
                    Font-Names="Verdana" Font-Size="XX-Small" 
                    ForeColor="Red" onclick="print_Click" /></ContentTemplate></asp:UpdatePanel>
                
                            </td>
                        <td style="font-weight: bold">
            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
            <ContentTemplate>
         <asp:Button ID="btnzero" runat="server" Text="0% Completed" 
                    Font-Names="Verdana" Font-Size="XX-Small" 
                    ForeColor="Red" onclick="btnzero_Click" /></ContentTemplate></asp:UpdatePanel>
                
                            </td>
                        <td style="font-weight: bold">
            <asp:UpdatePanel ID="UpdatePanel20" runat="server">
            <ContentTemplate>
         <asp:Button ID="btnreset" runat="server" Text="Clear Filter" 
                    Font-Names="Verdana" Font-Size="XX-Small" 
                    ForeColor="Red" onclick="btnreset_Click" /></ContentTemplate></asp:UpdatePanel>
                
                            </td>
                        <td style="font-weight: bold">
                            <asp:Label ID="lblhead" runat="server" Text="CAS E4 Electrical Services. LV Commissioning Activity Schedule"></asp:Label></td>
                            
                            <td>
                            <td style="width:5px">
                            //
                            </td>
                            <td>
                           Planned reference date
                            </td>
                            <td>
                            <asp:TextBox ID="txtpcddate" runat="server" Text="" Width="90px" ReadOnly="true">
                            </asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender391" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="txtpcddate" TargetControlID="txtpcddate">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                             <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                 <ContentTemplate>
                             <asp:Button ID="genPcd" runat="server" Text="Generate" 
                    Font-Names="Verdana" Font-Size="XX-Small" 
                    ForeColor="Red" onclick="genPcd_Click"  OnClientClick="setGen()" />
                     <input id="hdnpcd" type="hidden" name="hdnpcd"  runat="server">
                     </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                    </tr>
                </table>
                <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label><asp:Label ID="lbldiv" runat="server" Text="" CssClass="hidden"></asp:Label>
        </div>
        <div id="HeaderDiv" >
        <table style="font-family: Verdana;font-size:x-small;background-color:#9EB6CE;width:3747px;height:80px" cellspacing="1" border="0" id="headTbl" >
        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
        <td style="width:100px" align="center" rowspan="2">Item No.</td>
        <td style="width:100px" align="center" rowspan="2">Eng. Ref</td>
        <td align="center" colspan="4">Asset Code</td>
        <td align="center" style="width:150px" rowspan="2">Location</td>
        <td style="width:100px" align="center" rowspan="2">Fed From</td>
        <td style="width:300px" align="center" rowspan="2">Provides Power To</td>
        <td style="width:100px" align="center" rowspan="2">Planned Power On</td>
        <td align="center" colspan="10">Panel Site Testing</td>
        <td align="center" colspan="9">Outgoing Circuit Testing</td>
        <td style="width:300px" align="center" rowspan="2">Comments</td>
        <td style="width:100px" align="center" rowspan="2">Action By</td>
        <td style="width:100px" align="center" rowspan="2">Action Date</td>
        </tr>
        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
        <td style="width:100px" align="center">Building/ Zone</td>
        <td style="width:100px" align="center">Category</td>
        <td style="width:100px" align="center">Floor Level</td>
        <td style="width:100px" align="center">Seq.No</td>
        <td style="width:100px" align="center">Panel Test Planned</td>
        <td style="width:100px" align="center">Torque Test</td>
        <td style="width:100px" align="center">IR Test</td>
        <td style="width:100px" align="center">HI Pot Test</td>
        <td style="width:100px" align="center">Secondary Injection Test</td>
        <td style="width:100px" align="center">Contact Resistance</td>
        <td style="width:100px" align="center">Functional Test</td>
        <td style="width:100px" align="center">Site Panel Test Progress</td>
        <td style="width:100px" align="center">Consultant Accepted</td>
        <td style="width:100px" align="center">Test Sheets Filed</td>
        <td style="width:100px" align="center">Total No. of Circuits</td>
        <td style="width:100px" align="center">Cold Test Planned</td>
        <td style="width:100px" align="center">Total&nbsp; Cold Tested</td>
        <td style="width:100px" align="center">Cold Test Complete</td>
        <td style="width:100px" align="center">Live Test Planned</td>
        <td style="width:100px" align="center">Total Live Tested</td>
        <td style="width:100px" align="center">Live Test Complete</td>
        <td style="width:100px" align="center">Concultant Accepted</td>
        <td style="width:100px" align="center">Test Sheets Filed</td>
        </tr>
        <tr bgcolor="#092443">
        <td style="width:100px" align="center"><asp:UpdatePanel ID="UpdatePanel16" runat="server">
                 <ContentTemplate>
                 <asp:Button ID="btnexpand" runat="server" Text="Expand All" Width="100%"
                         onclick="btnexpand_Click" ForeColor="Red" Font-Size="X-Small" style="cursor:pointer" />
                 </ContentTemplate>
                 </asp:UpdatePanel></td>
        <td style="width:100px" align="center"><asp:UpdatePanel ID="UpdatePanel17" runat="server">
                 <ContentTemplate>
                 <asp:Button ID="btncollapse" runat="server" Text="Collapse All" Width="100%" 
                         ForeColor="Red" Font-Size="X-Small" style="cursor:pointer" 
                         onclick="btncollapse_Click" />
                 </ContentTemplate>
                 </asp:UpdatePanel></td>
        <td style="width:100px" align="center">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drbuilding" runat="server" Width="100%" OnSelectedIndexChanged="drbuilding_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
        <asp:DropDownList ID="drcategory" runat="server" Width="100%" OnSelectedIndexChanged="drcategory_SelectedIndexChanged" AutoPostBack="true" >
                </asp:DropDownList>
        </ContentTemplate>
            </asp:UpdatePanel>
        </td>
            
        <td style="width:100px" align="center">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drflevel" runat="server" Width="100%" OnSelectedIndexChanged="drflevel_SelectedIndexChanged" AutoPostBack="true"  >
                </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
        
        </td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:150px" align="center">
            <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drloc" runat="server" Width="100%" AutoPostBack="true" 
                        onselectedindexchanged="drloc_SelectedIndexChanged"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
        <td style="width:100px" align="center">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drfed" runat="server" Width="100%" OnSelectedIndexChanged="drfed_SelectedIndexChanged" AutoPostBack="true"  >
                </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td style="width:300px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drprogress" runat="server" Width="100%" AutoPostBack="true" 
                    onselectedindexchanged="drprogress_SelectedIndexChanged"  >
                </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:300px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        <td style="width:100px" align="center">&nbsp;</td>
        </tr>
        </table>
        </div>
        <div id="DataDiv" style="overflow: scroll;background-color:#FFF" onscroll="Onscrollfnction();">
        <div style="position:relative;float:left;width:3747px">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
            <asp:GridView ID="mymaster" runat="server" AutoGenerateColumns="False" 
                Width="3747px" onrowdatabound="mymaster_RowDataBound" 
                Font-Names="Verdana" 
                    Font-Size="X-Small" ShowHeader="False" GridLines="None" >
            <Columns>
            <asp:TemplateField>
            <ItemTemplate>
            <table id="inner_table" width="3747px">
            <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
            <td style="width:50px">
            
                <asp:Button ID="Button1" runat="server" Text="-" CommandArgument = "Button1"  OnClick = "Button1_Click" Width="30px" style="cursor:pointer" />
                </td>
            <td style="font-weight: bold;width:3747px" align="left">
                <asp:Label ID="lbSys_Name" runat="server" Text='<%# Eval("Sys_Name") %>' Width="300px"></asp:Label>
                <asp:Label ID="lbSys_Id" runat="server" Text='<%# Eval("Sys_Id") %>' style="display:none"></asp:Label>
            </td>
            </tr>
            <tr>
            <td colspan="2">
             <asp:GridView ID="mydetails" runat="server" AutoGenerateColumns="False" 
                OnRowCommand="mydetails_RowCommand" OnRowDataBound="mydetails_RowDataBound"
                Font-Names="Verdana" 
                Font-Size="X-Small" ShowHeader="false" >
                <Columns>
                <asp:BoundField>
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField ="E_b_ref" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="B_Z" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>    
                <asp:BoundField DataField="cat" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="F_lvl" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Seq_No" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Loc" >
                    <ItemStyle Width="150px" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="F_from" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                 <asp:BoundField DataField="P_P_to" >
                    <ItemStyle Width="300px" HorizontalAlign="Center" />
                    </asp:BoundField>   
                    <asp:BoundField DataField="Pwr_on" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PCdate" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test1" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test2" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test3" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test4" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test5" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test6" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField >
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <ItemTemplate >
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("per_com1")+ "%"  %>' ></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="accept1" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="filed1" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="devices1" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PCdate1" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="tested1" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test8" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PCdate2" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="tested2" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test9" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="accept2" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="filed2" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Comm" >
                    <ItemStyle Width="300px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Act_by" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Act_Date" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>    
                    <asp:BoundField DataField="per_com4" >  </asp:BoundField>   
                     <asp:BoundField DataField="per_com5" >  </asp:BoundField>   
                     <asp:BoundField DataField="per_com6" >  </asp:BoundField>   
                </Columns>
            </asp:GridView>
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
        
      
        <div>  
            <br />
            <h2 style="margin:0">Summary of LV Commissioning and Testing</h2>
            <div style="width:2000px">
             <div style="width:1800px;float:left">
              <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
             <asp:GridView ID="mygridsumm" runat="server" AutoGenerateColumns="False" onrowcreated="mygridsumm_RowCreated" 
                onrowdatabound="mygridsumm_RowDataBound" ShowFooter="true">
                <HeaderStyle CssClass="gvHeaderRow" />
                 <RowStyle Height="25px" />
                 <FooterStyle CssClass="gvFooetRow" HorizontalAlign="Center" />
                <Columns>
                <asp:BoundField HeaderText="Item No" HeaderStyle-Font-Bold="false" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:BoundField>
                <asp:BoundField DataField="SYS_NAME" HeaderText="Equipment" HeaderStyle-Font-Bold="false" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                    </asp:BoundField>
                <asp:BoundField DataField ="QTY" HeaderText="Qty" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundField>
                  <asp:BoundField DataField ="QTY_PER_COMPLETED" HeaderText="Qty Planned" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundField>
                     <asp:BoundField DataField ="PPERCENTAGE_PER_COMPLETED" HeaderText="% Planned" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundField>
                     <asp:BoundField DataField ="PER_COMPLETED" HeaderText="% Actual Progress" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundField>
                   <asp:BoundField DataField ="QTY_PER_COMPLETED1" HeaderText="Qty Planned" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundField>
                       <asp:BoundField DataField ="PPERCENTAGE_PER_COMPLETED1" HeaderText="% Planned" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundField>
                     <asp:BoundField DataField ="PER_COMPLETED1" HeaderText="% Actual Progress" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundField>
                     <asp:BoundField DataField ="QTY_PER_COMPLETED2" HeaderText="Qty Planned" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundField>
                       <asp:BoundField DataField ="PPERCENTAGE_PER_COMPLETED2" HeaderText="% Planned" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundField>
                      <asp:BoundField DataField ="PER_COMPLETED2" HeaderText="% Actual Progress" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundField>
                     <asp:BoundField HeaderText="Planned Calc Count" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundField>
                     <asp:BoundField  HeaderText="Overall Calc Count" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundField>
                     <asp:BoundField DataField ="PLANNED_TOTAL" HeaderText="Planned Overall Progress" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                    </asp:BoundField>
                      <asp:BoundField DataField ="TOTAL" HeaderText="Overall Progress" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                    </asp:BoundField>

                     <asp:BoundField DataField ="TotalNos" HeaderText="TotalNos" HeaderStyle-Font-Bold="false" > 
                    </asp:BoundField>

              </Columns>
            </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
             </div>
             <div style="width:250px;float:left" id="weighting" runat="server" >
            <table id="w1" runat="server">
            <tr>
            <td style="font-weight: bold">WEIGHTING:</td>
            </tr>
            <tr>
            <td>50-30-20% MDB</td>
            </tr>
            <tr>
            <td>50-30-20% PFC</td>
            </tr>
            <tr>
            <td>50-30-20% HCP</td>
            </tr>
            <tr>
            <td>60-40% BUSBAR</td>
            </tr>
            <tr>
            <td>50-30-20% SMDB</td>
            </tr>
            <tr>
            <td>50-30-20% MCC</td>
            </tr>
            <tr>
            <td>50-30-20% ATS</td>
            </tr>
            <tr>
            <td>60-40% DB</td>
            </tr>
            <tr>
            <td>60-40% LCP</td>
            </tr>
            <tr>
            <td>60-40% EFP</td>
            </tr>
            <tr>
            <td>60-40% UPS</td>
            </tr>
            </table>
            <table id="w2" runat="server">
            <tr>
            <td style="font-weight: bold">WEIGHTING:</td>
            </tr>
            <tr>
            <td>50-30-20% MDB</td>
            </tr>
            <tr>
            <td>50-30-20% PFC</td>
            </tr>
            <tr>
            <td>50-30-20% HCP</td>
            </tr>
            <tr>
            <td>60-40% BUSBAR</td>
            </tr>
            <tr>
            <td>50-30-20% SMDB</td>
            </tr>
            <tr>
            <td>50-30-20% MCC</td>
            </tr>
            <tr>
            <td>50-30-20% ATS</td>
            </tr>
            <tr>
            <td>50-50% DB</td>
            </tr>
            <tr>
            <td>50-50% LCP</td>
            </tr>
            <tr>
            <td>50-50% EFP</td>
            </tr>
            <tr>
            <td>50-50% UPS</td>
            </tr>
            </table>
            </div>
             </div>
           
           
                                                            
                                                          
        </div>
        </div>
    </div>
    <input type="hidden" id="hdnInnerHtml" value="" runat="server" />
    </form>
    <script type="text/javascript">
    $( document ).ready(function() {
  SetCurrentDate();
});
   function SetCurrentDate()
      {
    var tdate = new Date();
   var dd = tdate.getDate(); //yields day
   var MM = tdate.getMonth(); //yields month
   var yyyy = tdate.getFullYear(); //yields year
   var xxx = dd + "/" +( MM+1) + "/" + yyyy;
      document.getElementById("txtpcddate").value=xxx;
      }
      function setGen()
      {
      var mvalue= document.getElementById("txtpcddate").value;
       document.getElementById("hdnpcd").value=mvalue;
       }
//       function checkdate()
//       {
//        var mvalue= document.getElementById("txtpcddate").value;
//         if (ValidateDate(mvalue) && $("#txtpcddate").val() != '') {
//                    alert("Invalid date!,Please enter a valid date in the format mm/dd/yyyy.");
//                    return true;
//                    
//       }
//        function ValidateDate(inputdate) {
//            var re = /^(?=\d)(?:(?!(?:(?:0?[5-9]|1[0-4])(?:\.|-|\/)10(?:\.|-|\/)(?:1582))|(?:(?:0?[3-9]|1[0-3])(?:\.|-|\/)0?9(?:\.|-|\/)(?:1752)))(31(?!(?:\.|-|\/)(?:0?[2469]|11))|30(?!(?:\.|-|\/)0?2)|(?:29(?:(?!(?:\.|-|\/)0?2(?:\.|-|\/))|(?=\D0?2\D(?:(?!000[04]|(?:(?:1[^0-6]|[2468][^048]|[3579][^26])00))(?:(?:(?:\d\d)(?:[02468][048]|[13579][26])(?!\x20BC))|(?:00(?:42|3[0369]|2[147]|1[258]|09)\x20BC))))))|2[0-8]|1\d|0?[1-9])([-.\/])(1[012]|(?:0?[1-9]))\2((?=(?:00(?:4[0-5]|[0-3]?\d)\x20BC)|(?:\d{4}(?:$|(?=\x20\d)\x20)))\d{4}(?:\x20BC)?)(?:$|(?=\x20\d)\x20))?((?:(?:0?[1-9]|1[012])(?::[0-5]\d){0,2}(?:\x20[aApP][mM]))|(?:[01]\d|2[0-3])(?::[0-5]\d){1,2})?$/;
//            return (!inputdate.match(re) && inputdate != '');
//        };
 </script>
</body>
</html>
