<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="casdfsreport.aspx.cs" Inherits="CmlTechniques.CMS.casdfsreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
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
            var width = $(window).width()+12;
            var width1 = $(window).width() - 6;
            var height = $(window).height() - 120;
            $("#DataDiv").width(width);
            $("#HeaderDiv").width(width1);
            $("#DataDiv").height(height);
        }
    </script>
</head>
<body onload="javascript:ResizeWidth();" style="background-color:#E9E9E9">
    <form id="form1" runat="server">
    <div style="font-family: verdana; font-size: xx-small;width:100%">
        <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
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
                        <td style="font-weight: bold">CAS M1 Ducted Fan Systems Commissioning Activity Schedule</td>
                    </tr>
                </table>
                <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
        </div>
        <div id="HeaderDiv">
        <table style="font-family: Verdana;font-size:x-small;background-color:#9EB6CE;width:3079px;height:80px" cellspacing="1" border="0" id="headTbl">
        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
        <td style="width:100px" align="center" rowspan="2">ITEM NO.</td>
        <td style="width:100px" align="center" rowspan="2">ENG.REF</td>
        <td align="center" colspan="4">ASSET CODE</td>
        <td style="width:200px" align="center" rowspan="2">DESCRIPTION</td>
        <td style="width:200px" align="center" rowspan="2">LOCATION</td>
        <td style="width:100px" align="center" rowspan="2">FED FROM</td>
        <td align="center" colspan="3">SYSTEM INFO</td>
        <td style="width:100px" align="center" rowspan="2">PLANNED&nbsp;&nbsp; POWER ON</td>
        <td style="width:100px" align="center" rowspan="2">INSTALLATION &amp; DOCUMENTATION 
            COMPLETED</td>
        <td align="center" colspan="6">MECHANICAL SYSTEMS</td>
        <td align="center" colspan="3">CONTROLS</td>
        <td style="width:300px" align="center" rowspan="2">COMMENTS</td>
        <td style="width:100px" align="center" rowspan="2">ACTION BY</td>
        <td style="width:100px" align="center" rowspan="2">ACTION DATE</td>
        </tr>
        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
        <td style="width:100px" align="center">BUILDING/ ZONE</td>
        <td style="width:100px" align="center">CATEGORY</td>
        <td style="width:100px" align="center">FLOOR LEVEL</td>
        <td style="width:100px" align="center">SEQ. NO</td>
        <td style="width:100px" align="center">NO.GRILLES</td>
        <td style="width:100px" align="center">NO.VAV</td>
        <td style="width:100px" align="center">NO.CAV&#39;S</td>
        <td style="width:100px" align="center">PRE-COMM</td>
        <td style="width:100px" align="center">COMM</td>
        <td style="width:100px" align="center">% OF DUTY</td>
        <td style="width:100px" align="center">WITNESSED&nbsp; DATE</td>
        <td style="width:100px" align="center">CONSULTANT ACCEPTED</td>
        <td style="width:100px" align="center">TEST SHEETS FILED</td>
        <td style="width:100px" align="center">PRE-COMM</td>
        <td style="width:100px" align="center">COMM</td>
        <td style="width:100px" align="center">WITNESSED</td>
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
        <td style="width:200px" align="center">
            <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drdes" runat="server" Width="100%" AutoPostBack="true" 
                        onselectedindexchanged="drdes_SelectedIndexChanged"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
        <td style="width:200px" align="center">
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
        <div style="position:relative;float:left;width:3079px">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
            <asp:GridView ID="mymaster" runat="server" AutoGenerateColumns="False" 
                Width="3079px" onrowdatabound="mymaster_RowDataBound" 
                Font-Names="Verdana" 
                    Font-Size="X-Small" ShowHeader="False" GridLines="None" >
            <Columns>
            <asp:TemplateField>
            <ItemTemplate>
            <table id="inner_table" width="3079px">
            <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
            <td style="width:50px">
            
                <asp:Button ID="Button1" runat="server" Text="-" CommandArgument = "Button1"  OnClick = "Button1_Click" Width="30px" style="cursor:pointer" />
                </td>
            <td style="font-weight: bold;width:3079px" align="left">
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
                <asp:BoundField DataField="Des" >
                    <ItemStyle Width="200px" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Loc" >
                    <ItemStyle Width="200px" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="F_from" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="P_P_to" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Substation" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="devices1" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Pwr_on" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test7" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test1" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test2" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField >
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <ItemTemplate >
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("per_com4")+ "%"  %>' ></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="test3" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="accept1" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="filed1" >
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
                    <asp:BoundField DataField="Comm" >
                    <ItemStyle Width="300px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Act_by" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Act_Date" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>                    
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
            <h2 style="margin:0">Summary of Commissioning and Testing</h2>
            <div style="width:1400px">
             <div style="width:1100px;float:left">
              <asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <ContentTemplate>
             <asp:GridView ID="mygridsumm" runat="server" AutoGenerateColumns="False" onrowcreated="mygridsumm_RowCreated" 
                onrowdatabound="mygridsumm_RowDataBound" ShowFooter="true">
                <HeaderStyle CssClass="gvHeaderRow" />
                 <RowStyle Height="25px" />
                 <FooterStyle CssClass="gvFooetRow" HorizontalAlign="Center" />
                <Columns>
                <asp:BoundField HeaderText="ITEM NO" HeaderStyle-Font-Bold="false" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:BoundField>
                <asp:BoundField DataField="SYS_NAME" HeaderText="SYSTEMS" HeaderStyle-Font-Bold="false" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" Width="250px" />
                    </asp:BoundField>
                <asp:BoundField DataField ="QTY" HeaderText="QUANTITY" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField ="IDC" HeaderText="TOTAL NO.INSTALL & DOCUMENTATION COMPLETED" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundField>
                    <%--<asp:BoundField DataField ="DLT" HeaderText="TOTAL NO.DUCTWORK LEAKAGE TESTED" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundField>--%>
                <asp:TemplateField HeaderText="TOTAL PRE-COMMISSIONED" HeaderStyle-Font-Bold="false">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <ItemTemplate >
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("PER_COMPLETED")%>' ></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>    
                 <asp:TemplateField HeaderText="TOTAL COMMISSIONED" HeaderStyle-Font-Bold="false">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <ItemTemplate >
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("PER_COMPLETED1")%>' ></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TOTAL WITNESSED" HeaderStyle-Font-Bold="false">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <ItemTemplate >
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("PER_COMPLETED2")%>' ></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                 <asp:TemplateField HeaderText="% COMPLETE" HeaderStyle-Font-Bold="false">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <ItemTemplate >
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("TOTAL")+ "%"  %>' ></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CODE" />
                    <asp:BoundField DataField="PER_COMPLETED" />
                    <asp:BoundField DataField="PER_COMPLETED1" />
                    <asp:BoundField DataField="PER_COMPLETED2" />
                    <asp:BoundField DataField="TOTAL" />
              </Columns>
            </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
             </div>
             <div style="width:250px;float:left;display:none">
            <table>
            <tr>
            <td style="font-weight: bold">WEIGHTING:</td>
            </tr>
            <tr>
            <td>20% PRE-COMM&nbsp;</td>
            </tr>
            <tr>
            <td>80% COMM</td>
            </tr>
            </table>
            </div>
             </div>
        </div>
        </div>
    </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetData" 
            TypeName="CmlTechniques.CMS.casschedule_listTableAdapters.CAS_RPTTableAdapter">
            <InsertParameters>
                <asp:Parameter Name="PKG" Type="String" />
                <asp:Parameter Name="REF" Type="String" />
                <asp:Parameter Name="CATE" Type="String" />
                <asp:Parameter Name="BZONE" Type="String" />
                <asp:Parameter Name="FLEVEL" Type="String" />
                <asp:Parameter Name="SQNO" Type="String" />
                <asp:Parameter Name="LOC" Type="String" />
                <asp:Parameter Name="PPTO" Type="String" />
                <asp:Parameter Name="FFROM" Type="String" />
                <asp:Parameter Name="SSTATION" Type="String" />
                <asp:Parameter Name="DESCR" Type="String" />
                <asp:Parameter Name="PPON" Type="String" />
                <asp:Parameter Name="T1" Type="String" />
                <asp:Parameter Name="T2" Type="String" />
                <asp:Parameter Name="T3" Type="String" />
                <asp:Parameter Name="T4" Type="String" />
                <asp:Parameter Name="T5" Type="String" />
                <asp:Parameter Name="T6" Type="String" />
                <asp:Parameter Name="T7" Type="String" />
                <asp:Parameter Name="T8" Type="String" />
                <asp:Parameter Name="T9" Type="String" />
                <asp:Parameter Name="T10" Type="String" />
                <asp:Parameter Name="T11" Type="String" />
                <asp:Parameter Name="T12" Type="String" />
                <asp:Parameter Name="T13" Type="String" />
                <asp:Parameter Name="T14" Type="String" />
                <asp:Parameter Name="T15" Type="String" />
                <asp:Parameter Name="N1" Type="String" />
                <asp:Parameter Name="N2" Type="String" />
                <asp:Parameter Name="N3" Type="String" />
                <asp:Parameter Name="N4" Type="String" />
                <asp:Parameter Name="N5" Type="String" />
                <asp:Parameter Name="COMP1" Type="String" />
                <asp:Parameter Name="COMP2" Type="String" />
                <asp:Parameter Name="ACCEPT1" Type="String" />
                <asp:Parameter Name="ACCEPT2" Type="String" />
                <asp:Parameter Name="FILED1" Type="String" />
                <asp:Parameter Name="FILED2" Type="String" />
                <asp:Parameter Name="COMMENTS" Type="String" />
                <asp:Parameter Name="ACTBY" Type="String" />
                <asp:Parameter Name="ACTDATE" Type="String" />
                <asp:Parameter Name="PROJECT" Type="String" />
                <asp:Parameter Name="COMP3" Type="String" />
                <asp:Parameter Name="COMP4" Type="String" />
                <asp:Parameter Name="COMP5" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
