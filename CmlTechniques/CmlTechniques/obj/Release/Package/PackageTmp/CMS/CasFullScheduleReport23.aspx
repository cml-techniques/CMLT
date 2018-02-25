<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CasFullScheduleReport23.aspx.cs" Inherits="CmlTechniques.CMS.CasFullScheduleReport23" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
            var width1 = $(window).width() - 18;
            var height = $(window).height() - 120;
            $("#DataDiv").width(width);
            $("#HeaderDiv").width(width1);
            $("#DataDiv").height(height);
        }
    </script>
</head>
<script language="javascript" type="text/javascript">
    function CallPrint(strid) {

        var headstr = "<html><head><title>CML Techniques Reports</title></head><body>";

        var footstr = "</body></html>"

        var WinPrint = window.open('', '', 'left=150,top=150,width=1024,height=600,menubar=1,toolbar=0,scrollbars=1,status=0');

        WinPrint.document.write(headstr + strid.innerHTML + footstr);

        WinPrint.document.close();

        WinPrint.focus();

        WinPrint.print();
    }
    function getInnerHtml() {
        var element = document.getElementById("forPrint");
        var store = document.getElementById("hdnInnerHtml");
        //add the css styles you have used inside the nested GridView
        //var css = "<style type=\"text/css\" id=\"style1\">.textbold {font-family: Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;font-weight: bold;text-decoration: none;}.row1 {background-color: #FFFFFF; font-family: Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;height: 18px;padding-left: 5px;}.";
        store.value = element.innerHTML;
    }



    
    </script>

<body onload="javascript:ResizeWidth();" style="background-color:#E9E9E9">
    <form id="form1" runat="server">
    <div style="font-family: verdana; font-size: xx-small">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div style="background-color:#092443;color:White;font-weight:bold;font-size:small;height:26px">
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
                            <asp:Label ID="lblhead" runat="server" Text="CAS ELV Services. Security Management System Commissioning Activity Schedule"></asp:Label></td>
                    </tr>
                </table>
                <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
                <asp:Label ID="lbldiv" runat="server" Text="" CssClass="hidden"></asp:Label>
        </div>
        <div id="HeaderDiv">
        <table style="font-family: Verdana;font-size:x-small;background-color:#9EB6CE;width:1520px;" cellspacing="1" border="0" id="headTbl">
         <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;height:32px" >
        <td align="center"  style="width:120px;">ITEM NO.</td>
        <td align="center" style="width:300px;">REPORT TITLE</td>
        <td align="center" style="width:200px;">REPORT REF NO</td>
        <td align="center" style="width:150px;">REPORT SUBMITTED</td>
        <td align="center" style="width:150px;">WIR REFERENCE </td>
        <td align="center" style="width:150px;">STATUS</td>
        <td align="center" style="width:150px;">ACCEPTED BY BHC</td>
        <td align="center" style="width:300px;">COMMENTS</td>
        </tr>
      <tr bgcolor="#092443" >
              <td style="width:120px;">
              <table>
              <tr>
              <td>
               <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                 <ContentTemplate>
                 <asp:Button ID="btnexpand" runat="server" Text="Exp.All" Font-Size="X-Small"
                         onclick="btnexpand_Click" ForeColor="Red"  style="cursor:pointer" />
                 <asp:Button ID="btncollapse" runat="server" Text="Coll.All" Font-Size="X-Small"
                         ForeColor="Red" style="cursor:pointer" 
                         onclick="btncollapse_Click" />
                 </ContentTemplate>
                 </asp:UpdatePanel>
              </td>
              </tr>
              </table>
            </td>
        <td style="width:300px;margin-left:10px" align="left">

        </td>
        <td style="width:200px" align="center">
        </td>
        <td style="width:150px" align="center">
        </td>
        <td style="width:150px" align="center">        
        </td>
        <td style="width:150px" align="center">
        </td>
        <td style="width:150px" align="center">
         </td>
          <td style="width:300px;margin-left:10px" align="left">
          </td>
           </tr>
        </table>
        </div>
        <div id="DataDiv" style="overflow:scroll;background-color:#FFF;" onscroll="Onscrollfnction();">
        <div style="position:relative;float:left;width:1510px">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
            <asp:GridView ID="mymaster" runat="server" AutoGenerateColumns="False" 
                Width="1410px" onrowdatabound="mymaster_RowDataBound" 
                Font-Names="Verdana" 
                    Font-Size="X-Small" ShowHeader="False" GridLines="None" >
            <Columns>
            <asp:TemplateField>
            <ItemTemplate>
            <table id="inner_table" width="1520px">
            <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
            <td style="width:50px">
            
                <asp:Button ID="Button1" runat="server" Text="-" CommandArgument = "Button1"  OnClick = "Button1_Click" Width="30px" style="cursor:pointer" />
                </td>
            <td style="font-weight: bold;width:1450px" align="left">
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
                    <ItemStyle Width="120px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Des" >
                    <ItemStyle Width="300px" HorizontalAlign="Center" />
                    </asp:BoundField> 
                <asp:BoundField DataField ="E_b_ref" >
                    <ItemStyle Width="200px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test1" >
                    <ItemStyle Width="150px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test2" >
                    <ItemStyle Width="150px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test3" >
                    <ItemStyle Width="150px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Act_by" >
                    <ItemStyle Width="150px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Comm" >
                    <ItemStyle Width="300px" HorizontalAlign="Center" />
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
        <div >
        
            <br />
            <h2 style="margin:0">Summary of Security Management System Commissioning and Testing</h2>
            <div>
            <div >
             <asp:UpdatePanel ID="UpdatePanel7" runat="server">
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
                <asp:BoundField DataField="CATE_NAME" HeaderText="Package" HeaderStyle-Font-Bold="false" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                    </asp:BoundField>
                <asp:BoundField DataField ="QTY" HeaderText="No. Of Items" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="No. Completed" HeaderStyle-Font-Bold="false" DataField ="PER_COMPLETED">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundField>    
                 <asp:BoundField HeaderText="Percentage Complete(%)" HeaderStyle-Font-Bold="false" DataField ="TOTAL">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundField>
              </Columns>
            </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
            
            </div>
            </div>
           
        </div>
        </div>
    </div>
    <input type="hidden" id="hdnInnerHtml" value="" runat="server" />
    </form>
</body>
</html>

