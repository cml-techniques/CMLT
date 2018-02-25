<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CXIR_Schedule.aspx.cs" Inherits="CmlTechniques.CMS.CXIR_Schedule" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
        .style1
        {
            height: 20px;
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
            HeaderDivObj.style.height = '83px';
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
            // $find('popup1').set_OffsetX(div.scrollLeft);
            // pnl1.scrollLeft = div.scrollLeft;
            //div3.scrollLeft = div.scrollLeft;
            return false;
        }

        function ResizeWidth() {
            var width = $(window).width() - 2;
            var width1 = $(window).width() - 20;
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
            <asp:Label ID="Label1" runat="server" Text="CX IR Record Schedule" Font-Bold="true" ForeColor="#FFFFFF" Font-Size="Large"></asp:Label>
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
        <td ></td>
        </tr>
        </table>
        </div>
        <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label>
        <div id="HeaderDiv" >
        <table style="text-align:center;font-size:x-small;vertical-align:middle;font-weight:bold;background-color:#000" border="0" cellspacing="1" cellpadding="0" width="2556px"  >
        <tr style="background-color:#ccc">
        <td colspan="25" class="style1">CONTRACTOR PROGRAMMED WITNESSING SCHEDULE</td>
        </tr>
        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
        <td style="width:30px" rowspan="2"></td>
        <td style="width:200px" rowspan="2">IR Reference</td>
        <td style="width:50px" rowspan="2">Rev.</td>
        <td style="width:100px" rowspan="2">Date Received</td>
        <td style="width:100px" rowspan="2">Proposed Date</td>
        <td style="width:50px" rowspan="2">AM/PM</td>
        <td style="width:100px" rowspan="2">Test Type</td>
        <td style="width:100px" rowspan="2">Discipline</td>
        <td style="width:100px" rowspan="2">System/ Equipment</td>
        <td style="width:150px" rowspan="2">Test Details</td>
        <td style="width:100px" rowspan="2">Buildings</td>
        <td style="width:50px" rowspan="2">Level</td>
        <td style="width:100px" rowspan="2">Location</td>
        <td style="width:100px" rowspan="2">IR &amp; Documentation Checked</td>
        <td style="width:100px" rowspan="2">All Parties Advised</td>
        <td style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;" colspan="7">CML Witness</td>
        <td style="width:100px;" rowspan="2">Document Status</td>
        <td style="width:100px;" rowspan="2">SVR No.</td>
        <td style="width:200px;" rowspan="2">Notes</td>
        </tr>
        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
        <td style="width:100px;">Proposed Start</td>
        <td style="width:100px;">Actual Start</td>
        <td style="width:100px;">Delay</td>
        <td style="width:100px;">Completion Date</td>
        <td style="width:100px;">No. of Visits</td>
        <td style="width:100px;">Witness By</td>
        <td style="width:100px;">Status</td>
        </tr>
        <tr style="background-color:#000033">
        <td style="height:25px"></td>
        <td style="width:200px">
        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
            <ContentTemplate>      
        <asp:Button ID="Button1" runat="server" Text="Filter" 
                    Width="100px" UseSubmitBehavior="false" style="display:none" />
            <asp:Button ID="btnapply" Name="btnapply" runat="server" Text="Apply"  style="display:none"  />
            
                   <%--<asp:ModalPopupExtender ID="Pop1" runat="server" 
                    DynamicServicePath="" Enabled="True" TargetControlID="Button1" PopupControlID="Panel1" x="100">
                </asp:ModalPopupExtender>--%>
                    <asp:PopupControlExtender ID="popup1" runat="server" 
                    DynamicServicePath="" Enabled="True" ExtenderControlID="" 
                    TargetControlID="Button1" PopupControlID="Panel1"   >
                </asp:PopupControlExtender>
              
                
            <asp:Panel ID="Panel1" runat="server" style="display:none;width:150px;height:200px;overflow:auto;background-color:#79B9DE;text-align:left;margin-top:20px;border:solid 1px #000"  >
            <asp:CheckBoxList ID="chksdoc" runat="server">
       
        </asp:CheckBoxList>
        <div>
        <input type="button" name="Rater1$btnRate" value="Submit" onclick="javascript:Filter();" id="Rater1_btnRate"  />
            <asp:Button ID="btncancel"
                runat="server" Text="Cancel"  />
        </div>
            </asp:Panel>
            </ContentTemplate>
            <%--<Triggers>
     <asp:AsyncPostBackTrigger ControlID="btnapply" EventName="Click" />
   </Triggers>--%>
            </asp:UpdatePanel>
                        </td>
        <td style="width:50px">
            &nbsp;</td>
        <td style="width:100px">
            &nbsp;</td>
        <td style="width:100px">
            &nbsp;</td>
        <td style="width:50px">&nbsp;</td>
        <td style="width:100px">
            &nbsp;</td>
        <td style="width:100px">
            &nbsp;</td>
        <td style="width:100px">&nbsp;</td>
        <td style="width:150px">&nbsp;</td>
        <td style="width:100px">
            &nbsp;</td>
        <td style="width:50px">&nbsp;</td>
        <td style="width:100px">&nbsp;</td>
        <td style="width:100px">&nbsp;</td>
        <td style="width:100px">&nbsp;</td>
        <td style="width:100px;">
            &nbsp;</td>
        <td style="width:100px;">&nbsp;</td>
        <td style="width:100px;">
            &nbsp;</td>
        <td style="width:100px;">
            &nbsp;</td>
        <td style="width:100px;">
            &nbsp;</td>
        <td style="width:100px;">&nbsp;</td>
        <td style="width:100px;">&nbsp;</td>
        <td style="width:100px;">
            &nbsp;</td>
        <td style="width:100px;">
            &nbsp;</td>
        <td style="width:200px;">
            &nbsp;</td>
        </tr>
        </table>
        </div>
        <div id="DataDiv" style="overflow: scroll;border:1px solid #E9E9E9" onscroll="Onscrollfnction();" >
            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" 
                DataKeyNames="cx_ir_id" ShowHeader="False" Width="2556px" CellPadding="0" 
                Font-Size="X-Small" BackColor="White" onrowdatabound="GridView1_RowDataBound"   >
                        <RowStyle BackColor="#FFFFFF" ForeColor="Black" />
                         <Columns>
                            <asp:TemplateField>
                                <ItemTemplate  >
                                    <asp:CheckBox ID="chk" runat="server" Width="30px" />
                                </ItemTemplate>
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="IR Ref" DataField="ir_ref" >
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                <HeaderStyle BackColor="#ff0000" Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="REV" DataField="ir_rev" >
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                <HeaderStyle BackColor="#ff0000" Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Date Received" DataField="dt_recv" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Date Proposed" DataField="dt_prop" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="AmPm" DataField="am_pm" >
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Test Type" DataField="test_type" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Discipline" DataField="discipline" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="System" 
                        DataField="system" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Details" DataField="details" >
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Buildings" DataField="building" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Level" 
                                DataField="flevel" >
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="location" 
                                DataField="location" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Doc Checked" DataField="ir_checked" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Advised" DataField="advise" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#ff0000" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Proposed Start" DataField="prop_start" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#e46d0a" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Actual Start" DataField="actual_start" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#e46d0a" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Delay" DataField="dtdelay"  >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#e46d0a" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Completion" DataField="dt_compl" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#e46d0a" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="NOofVisits" DataField="visit" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#e46d0a" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Witnessed By" 
                                DataField="witness" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#e46d0a" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="IR Status" DataField="ir_status" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#00b050" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Doc Status" DataField="doc_status" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#00b050" />
                            </asp:BoundField>
                             <asp:BoundField HeaderText="SVR" DataField="svr_no" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle BackColor="#00b050" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="NOtes" DataField="notes" >
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                <HeaderStyle BackColor="#00b050" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cx_ir_id" />
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
            TypeName="CmlTechniques.CMS.CXIR_DataTableAdapters.Load_CXIR_ScheduleTableAdapter" ></asp:ObjectDataSource>
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
