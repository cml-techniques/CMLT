<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridSample.aspx.cs" Inherits="CmlTechniques.CMS.GridSample" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        
        .GridViewStyle
        {    
            font-family:Verdana;
            font-size:11px;
            background-color: White; 
            border:0;
        }
        
        .GridViewHeaderStyle
        {
            font-family:Verdana;
            font-size:11px;
	        color:White;
	        background: black url(Image/header3.jpg) repeat-x;
	        
        }
    </style>
    <script language="javascript" type="text/javascript">
        function CreateGridHeader(DataDiv, GridView1, HeaderDiv) {
            var DataDivObj = document.getElementById(DataDiv);
            var DataGridObj = document.getElementById(GridView1);
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
            HeaderDivObj.style.height = '90px';
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
           // var pnl1 = document.getElementById('Panel1');
            div2.scrollLeft = div.scrollLeft;
            var ele = $find("Pop1");
            var x = div.scrollLeft;
            if (ele) {
                ele.set_OffsetX(parseInt(x));
            }
           // $find('popup1').set_OffsetX(div.scrollLeft);
           // pnl1.scrollLeft = div.scrollLeft;
            //div3.scrollLeft = div.scrollLeft;
            return false;
        }

        function ResizeWidth() {
            var width = $(window).width() + 12;
            var width1 = $(window).width() - 6;
            var height = $(window).height() - 130;
            $("#DataDiv").width(width);
            $("#HeaderDiv").width(width1);
            $("#DataDiv").height(height);
        }
        function Filter() {
            var btn = document.getElementById("btnapply");
           btn.click();
            //alert('something wrong');
       }
       function Filter1() {
           var btn = document.getElementById("btnapply1");
           btn.click();
           //alert('something wrong');
       }
       function Filter2() {
           var btn = document.getElementById("btnapply2");
           btn.click();
           //alert('something wrong');
       }
       function Filter3() {
           var btn = document.getElementById("btnapply3");
           btn.click();
           //alert('something wrong');
       }
       function Filter4() {
           var btn = document.getElementById("btnapply4");
           btn.click();
           //alert('something wrong');
       }
       function cancel() {
           var btn = document.getElementById("btncancel");
           btn.click();
           //alert('something wrong');
       }
    </script>
    <script type="text/javascript" language="javascript">
        function Reposition() {
            var topobj = document.getElementById("Button1");
            var rect = topobj.getBoundingClientRect();
            $find('Button1_ModalPopupExtender').position = "relative";
            $find('Button1_ModalPopupExtender').set_Y(rect.top + 20);
            $find('Button1_ModalPopupExtender').set_X(rect.left);
        }
    </script>
</head>
<body onload="javascript:ResizeWidth();" style="background-color:#E9E9E9">
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div style="background-color:#000033;width:100%;height:32px;">
        <div style="float:left;padding:5px">
            <asp:Label ID="Label1" runat="server" Text="CX Issues Log" Font-Bold="true" ForeColor="#FFFFFF" Font-Size="Large"></asp:Label>
        </div>
        <table style="float:right">
        <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:Button ID="btn_add" runat="server" Text="Add New" onclick="btn_add_Click" Width="100px" />
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnedit" runat="server" Text="Edit" Width="100px" 
                        onclick="btnedit_Click" />
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        <td>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnprint" runat="server" Text="Print" onclick="btnprint_Click" Width="100px" />
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td >
            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
            <ContentTemplate>
             <asp:Label ID="lblfilter_query" runat="server" Text="" CssClass="hidden" ></asp:Label>
                <asp:Button ID="btncancel" runat="server" Text="" CssClass="hidden" OnClick="btncancel_Click"/>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
        </table>
        </div>
        <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label>
        <div id="HeaderDiv"  >
        <table style="text-align:center;font-size:x-small;vertical-align:middle;font-weight:bold;background-color:#000" border="0" cellspacing="1" cellpadding="0" width="2580px" >
        <tr style="background-color:#ff0000">
        <td colspan="15" style="height:20px">1. Basic Risk Information </td>
        <td colspan="5" style="background-color:#e46d0a">2. Risk Assessment Information</td>
        <td colspan="3" style="background-color:#00b050">3. Risk Mitigation</td>
        </tr>
        <tr style="background-color:#ff0000">
        <td style="width:30px"></td>
        <td style="width:50px">Risk Number</td>
        <td style="width:100px">Source Document</td>
        <td style="width:100px">Source Document Ref.</td>
        <td style="width:100px">Zutex CX Issue #</td>
        <td style="width:100px">Base Discipline</td>
        <td style="width:100px">System</td>
        <td style="width:100px">Issue Type</td>
        <td style="width:100px">Location</td>
        <td style="width:200px">Risk Description/ Risk Event Statement</td>
        <td style="width:100px">Responsible</td>
        <td style="width:100px">Date Reported (DR) dd/mm/yy</td>
        <td style="width:100px">Target Closure Date (DR+30d)</td>
        <td style="width:100px">Last Update (dd/mm/yy)</td>
        <td style="width:100px">Date Closed (dd/mm/yy)</td>
        <td style="width:100px;background-color:#e46d0a;">Impact H/M/L</td>
        <td style="width:200px;background-color:#e46d0a;">Impact Description</td>
        <td style="width:100px;background-color:#e46d0a;">Probability H/M/L</td>
        <td style="width:100px;background-color:#e46d0a;">Timeline N/M/F</td>
        <td style="width:100px;background-color:#e46d0a;">Status of Response N/P/PE/EE</td>
        <td style="width:200px;background-color:#00b050;">Current Action</td>
        <td style="width:200px;background-color:#00b050;">Planned Future Actions</td>
        <td style="width:100px;background-color:#00b050;">Risk Status Open/ Closed/ Pending/ Move to Issue</td>
        </tr>
        <tr style="background-color:#ff0000">
        <td></td>
        <td style="width:50px">&nbsp;</td>
        <td style="width:100px">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <%--<asp:DropDownList ID="drsdoc" runat="server" Width="99%" 
                    onselectedindexchanged="drsdoc_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>--%>
                <asp:Button ID="Button1" runat="server" Text="" CssClass="filter_button" Width="100px" UseSubmitBehavior="false" />
                <asp:PopupControlExtender ID="drsdoc_PopupControlExtender" runat="server" 
                    DynamicServicePath="" Enabled="True" ExtenderControlID="" PopupControlID="Panel1" 
                    TargetControlID="Button1">
                </asp:PopupControlExtender>
                <asp:Button ID="btnapply" Name="btnapply" runat="server" Text="Apply"  OnClick="btnapply_Click"  style="display:none"  />
                <asp:Panel ID="Panel1" runat="server" CssClass="pop_panel"  style="display:none"  >
            <div class="pop_block">
            <asp:CheckBoxList ID="chksdoc" runat="server">
       
        </asp:CheckBoxList>
        </div>
        <div class="pop_button">
        <input type="button" name="Rater1$btnRate" value="Submit" onclick="javascript:Filter();" id="Rater1_btnRate"  />
         <input type="button" name="btncancel1" value="Cancel"  onclick="javascript:cancel();" />
        </div>
            </asp:Panel>
            </ContentTemplate>
            </asp:UpdatePanel>
                        </td>
        <td style="width:100px">
        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
            <ContentTemplate>      
        
                
            
            </ContentTemplate>
            <%--<Triggers>
     <asp:AsyncPostBackTrigger ControlID="btnapply" EventName="Click" />
   </Triggers>--%>
            </asp:UpdatePanel>
                        </td>
        <td style="width:100px">
            &nbsp;</td>
        <td style="width:100px">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <asp:Button ID="Button2" runat="server" Text="" CssClass="filter_button"
                    Width="100px" UseSubmitBehavior="false"  />
            <asp:Button ID="btnapply1" Name="btnapply1" runat="server" Text="Apply"  OnClick="btnapply1_Click"  style="display:none"  />
            <asp:PopupControlExtender ID="Button2_PopupControlExtender" runat="server" 
                DynamicServicePath="" Enabled="True" ExtenderControlID="" PopupControlID="Panel2"
                TargetControlID="Button2">
            </asp:PopupControlExtender>
            <asp:Panel ID="Panel2" runat="server" CssClass="pop_panel" style="display:none"  >
            <div class="pop_block">
            <asp:CheckBoxList ID="chkbase" runat="server">
       
        </asp:CheckBoxList>
        </div>
        <div class="pop_button">
        <input type="button" name="Rater1$btnRate" value="Submit" onclick="javascript:Filter1();" id="Button3"  />
            <input type="button" name="btncancel1" value="Cancel"  onclick="javascript:cancel();" />
        </div>
            </asp:Panel>
            </ContentTemplate>
            </asp:UpdatePanel>
                        </td>
        <td style="width:100px">
            <asp:UpdatePanel ID="UpdatePanel16" runat="server">
            <ContentTemplate>
            
            </ContentTemplate>
            </asp:UpdatePanel>
            
                        </td>
        <td style="width:100px">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <asp:Button ID="Button6" runat="server" Text="" CssClass="filter_button"
                    Width="100px" UseSubmitBehavior="false"  />
            <asp:Button ID="btnapply2" Name="btnapply2" runat="server" Text="Apply"  OnClick="btnapply2_Click"  style="display:none"  />
                <asp:PopupControlExtender ID="Button6_PopupControlExtender" runat="server" 
                    DynamicServicePath="" Enabled="True" ExtenderControlID="" PopupControlID="Panel3"
                    TargetControlID="Button6">
                </asp:PopupControlExtender>
                <asp:Panel ID="Panel3" runat="server" CssClass="pop_panel" style="display:none"  >
                <div class="pop_block">
            <asp:CheckBoxList ID="chk_type" runat="server">
       
        </asp:CheckBoxList>
        </div>
        <div  class="pop_button">
        <input type="button" name="Rater1$btnRate" value="Submit" onclick="javascript:Filter2();" id="Button4"  />
        <input type="button" name="btncancel1" value="Cancel"  onclick="javascript:cancel();" />
        </div>
            </asp:Panel>
            </ContentTemplate>
            </asp:UpdatePanel>
                        </td>
        <td style="width:100px">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
                <asp:Button ID="Button5" runat="server" Text="" CssClass="filter_button"
                    Width="100px" UseSubmitBehavior="false"  />
            <asp:Button ID="btnapply3" Name="btnapply3" runat="server" Text="Apply"  OnClick="btnapply3_Click"  style="display:none"  />
                <asp:PopupControlExtender ID="PopupControlExtender1" runat="server" 
                    DynamicServicePath="" Enabled="True" ExtenderControlID="" PopupControlID="Panel4"
                    TargetControlID="Button5">
                </asp:PopupControlExtender>
                <asp:Panel ID="Panel4" runat="server" CssClass="pop_panel" style="display:none"  >
                <div class="pop_block">
            <asp:CheckBoxList ID="chkloc" runat="server">
       
        </asp:CheckBoxList>
        </div>
        <div  class="pop_button">
        <input type="button" name="Rater1$btnRate" value="Submit" onclick="javascript:Filter3();" id="Button8"  />
        <input type="button" name="btncancel1" value="Cancel"  onclick="javascript:cancel();" />
        </div>
            </asp:Panel>
            </ContentTemplate>
            </asp:UpdatePanel>
                        </td>
        <td style="width:200px">&nbsp;</td>
        <td style="width:100px">&nbsp;</td>
        <td style="width:100px">
            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
            <ContentTemplate>
                
            </ContentTemplate>
            </asp:UpdatePanel>
                        </td>
        <td style="width:100px">&nbsp;</td>
        <td style="width:100px">&nbsp;</td>
        <td style="width:100px">&nbsp;</td>
        <td style="width:100px;background-color:#e46d0a;">
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
            </asp:UpdatePanel>
                        </td>
        <td style="width:200px;background-color:#e46d0a;">&nbsp;</td>
        <td style="width:100px;background-color:#e46d0a;">
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            </asp:UpdatePanel>
                        </td>
        <td style="width:100px;background-color:#e46d0a;">
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
            </asp:UpdatePanel>
                        </td>
        <td style="width:100px;background-color:#e46d0a;">
            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
            </asp:UpdatePanel>
                        </td>
        <td style="width:200px;background-color:#00b050;">&nbsp;</td>
        <td style="width:200px;background-color:#00b050;">&nbsp;</td>
        <td style="width:100px;background-color:#00b050;">
            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
            <ContentTemplate>
                <asp:Button ID="Button7" runat="server" Text="" CssClass="filter_button"
                    Width="100px" UseSubmitBehavior="false"  />
            <asp:Button ID="btnapply4" Name="btnapply4" runat="server" Text="Apply"  OnClick="btnapply4_Click"  style="display:none"  />
                <asp:PopupControlExtender ID="PopupControlExtender2" runat="server" 
                    DynamicServicePath="" Enabled="True" ExtenderControlID="" PopupControlID="Panel5"
                    TargetControlID="Button7">
                </asp:PopupControlExtender>
                <asp:Panel ID="Panel5" runat="server" CssClass="pop_panel" style="display:none"  >
                <div class="pop_block">
            <asp:CheckBoxList ID="chkstatus" runat="server">
       
        </asp:CheckBoxList>
        </div>
        <div  class="pop_button">
        <input type="button" name="Rater1$btnRate" value="Submit" onclick="javascript:Filter4();" id="Button10"  />
        <input type="button" name="btncancel1" value="Cancel"  onclick="javascript:cancel();" />
        </div>
            </asp:Panel>
            </ContentTemplate>
            </asp:UpdatePanel>
                        </td>
        </tr>
        </table>
        </div>
        <div id="DataDiv" style="overflow: scroll;border:1px solid #E9E9E9" onscroll="Onscrollfnction();" >
            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  
                DataKeyNames="cx_log_id" ShowHeader="False" Width="2580px" CellPadding="0" DataSourceID="ObjectDataSource1"
                Font-Size="X-Small" BackColor="White" onrowdatabound="GridView1_RowDataBound"   >
                        <RowStyle BackColor="#FFFFFF" ForeColor="Black" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate  >
                                    <asp:CheckBox ID="chk" runat="server" Width="30px" />
                                </ItemTemplate>
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Risk Number" >
                                <ItemStyle Width="50px" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#ff0000" Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Source Document" DataField="source_doc" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Source Document Ref #" DataField="source_doc_ref" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Zutec CX Issue #" DataField="zutec_cx_issue" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Base Discipline" DataField="Discipline" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="System" DataField="system" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Issue Type" DataField="issue_type" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Location" DataField="location" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Risk  Description / Risk Event Statement" 
                        DataField="description" >
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Responsible" DataField="responsible" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Date Reported (DR) dd/mm/yy" DataField="date_rep" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Target closure date (DR + 30d)" 
                                DataField="date_tc" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Last Update dd/mm/yy" DataField="last_update" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Date Closed dd/mm/yy" DataField="date_clsd" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Impact H/M/L" DataField="impact" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#e46d0a" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Impact Description" DataField="description" >
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                <HeaderStyle BackColor="#e46d0a" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Probability H/M/L" DataField="probability" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#e46d0a" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Timeline N/M/F" DataField="timeline" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#e46d0a" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Status of Response N/P/PE/EE" 
                                DataField="resp_status" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#e46d0a" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Current Actions" DataField="c_action" >
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                <HeaderStyle BackColor="#00b050" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Planned Future Actions" DataField="f_action" >
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                <HeaderStyle BackColor="#00b050" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Risk Status open/ closed/ pending/ moved to issue" DataField="r_status" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#00b050" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cx_log_id" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle CssClass="GridViewHeaderStyle"  />
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div> 
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetData"                 
                TypeName="CmlTechniques.CMS.DataSet2TableAdapters.Load_Cx_Issues_LogTableAdapter" ></asp:ObjectDataSource>
       <div id="myprogress" runat="server" style="position:absolute; z-index:40;top:40%;left: 48%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading45.gif" Height="100px" Width="100px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div>
    </div>
  </form>
</body>
</html>
