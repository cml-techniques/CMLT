<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="castransreport_pcd.aspx.cs"
    Inherits="CmlTechniques.CMS.castransreport_pcd" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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
            background-image: url('../images/head_bg.png');
            background-repeat: repeat;
            font-family: Verdana;
            font-size: x-small;
            font-weight: normal;
        }
        .gvFooetRow
        {
            font-family: Verdana;
            font-size: x-small;
            font-weight: normal;
            height: 30px;
            background-color: #C8ECFB;
        }
        #DataDiv
        {
            outline: none;
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
            var width1 = $(window).width() - 10;
            var height = $(window).height() - 105;
            $("#DataDiv").width(width);
            $("#HeaderDiv").width(width1);
            $("#DataDiv").height(height);
        }
        $(document).ready(function() {
            setfocus();
        });
        function setfocus() {
            $("#DataDiv").attr("tabindex", -1).focus();
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

<body onload="javascript:ResizeWidth();" style="background-color: #FFFFFF; overflow: hidden;">
    <form id="form1" runat="server" style="overflow: hidden;">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div style="font-family: verdana; font-size: xx-small; overflow: hidden;">
        <div style="background-color: #092443; color: White; font-weight: bold; font-size: small;
            width: 100%; height: 26px">
            <table>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="print" runat="server" Text="Print Report" Font-Names="Verdana" Font-Size="XX-Small"
                                    ForeColor="Red" OnClick="print_Click" /></ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="font-weight: bold">
                        <asp:Label ID="lblhead" runat="server" Text="CAS E2 Electrical Services. HV & MV Transformers Commissioning Activity Schedule"></asp:Label>
                    </td>
                    <td style="width: 5px">
                        //
                    </td>
                    <td>
                        Planned reference date
                    </td>
                    <td>
                        <asp:TextBox ID="txtpcddate" runat="server" Text="" Width="90px" ReadOnly="true">
                        </asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender391" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                            PopupButtonID="txtpcddate" TargetControlID="txtpcddate">
                        </asp:CalendarExtender>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="genPcd" runat="server" Text="Generate" Font-Names="Verdana" Font-Size="XX-Small"
                                    ForeColor="Red" OnClick="genPcd_Click" OnClientClick="setGen()" />
                                <input id="hdnpcd" type="hidden" name="hdnpcd" runat="server">
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblprj" runat="server" Text="" Style="display: none"></asp:Label><asp:Label
                ID="lbldiv" runat="server" Text="" CssClass="hidden"></asp:Label>
        </div>
        <div id="HeaderDiv">
            <table style="font-family: Verdana; font-size: x-small; background-color: #9EB6CE;
                width: 3076px; height: 80px" cellspacing="1" border="0" id="headTbl">
                <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                    <td style="width: 100px" align="center" rowspan="2">
                        ITEM NO.
                    </td>
                    <td style="width: 100px" align="center" rowspan="2">
                        ENG.REF
                    </td>
                    <td align="center" colspan="4">
                        ASSET CODE
                    </td>
                    <td style="width: 100px" align="center" rowspan="2">
                        FED FROM
                    </td>
                    <td style="width: 100px" align="center" rowspan="2">
                        PROVIDES POWER TO
                    </td>
                    <td style="width: 100px" align="center" rowspan="2">
                        AREA
                    </td>
                    <td style="width: 200px" align="center" rowspan="2">
                        LOCATION
                    </td>
                    <td style="width: 100px" align="center" rowspan="2">
                        PLANNED&nbsp;&nbsp; POWER ON
                    </td>
                    <td align="center" colspan="9">
                        TRANSFORMER TESTING
                    </td>
                    <td align="center" colspan="4">
                        22/11KV HV TEST
                    </td>
                    <td style="width: 300px" align="center" rowspan="2">
                        COMMENTS
                    </td>
                    <td style="width: 100px" align="center" rowspan="2">
                        ACTION BY
                    </td>
                    <td style="width: 100px" align="center" rowspan="2">
                        ACTION DATE
                    </td>
                </tr>
                <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                    <td style="width: 100px" align="center">
                        BUILDING/ ZONE
                    </td>
                    <td style="width: 100px" align="center">
                        CATEGORY
                    </td>
                    <td style="width: 100px" align="center">
                        FLOOR LEVEL
                    </td>
                    <td style="width: 100px" align="center">
                        SEQ. NO
                    </td>
                    <td style="width: 100px" align="center">
                        PLANNED COMPLETION
                    </td>
                    <td style="width: 100px" align="center">
                        IR TEST
                    </td>
                    <td style="width: 100px" align="center">
                        RATIO TEST
                    </td>
                    <td style="width: 100px" align="center">
                        WINDING RES. TEST
                    </td>
                    <td style="width: 100px" align="center">
                        VECTOR GROUP TEST
                    </td>
                    <td style="width: 100px" align="center">
                        TEMP.RELAY FUNC. TEST
                    </td>
                    <td style="width: 100px" align="center">
                        TRANSFORMER TEST PROGRESS
                    </td>
                    <td style="width: 100px" align="center">
                        CONSULTANT ACCEPTED
                    </td>
                    <td style="width: 100px" align="center">
                        TEST SHEETS FILED
                    </td>
                    <td style="width: 100px" align="center">
                        PLANNED COMPLETION
                    </td>
                    <td style="width: 100px" align="center">
                        CABLE TEST
                    </td>
                    <td style="width: 100px" align="center">
                        CONSULTANT ACCEPTED
                    </td>
                    <td style="width: 100px" align="center">
                        TEST SHEET FILED
                    </td>
                </tr>
                <tr bgcolor="#092443">
                    <td style="width: 100px" align="center">
                        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnexpand" runat="server" Text="Expand All" Width="100%" OnClick="btnexpand_Click"
                                    ForeColor="Red" Font-Size="X-Small" Style="cursor: pointer" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 100px" align="center">
                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btncollapse" runat="server" Text="Collapse All" Width="100%" ForeColor="Red"
                                    Font-Size="X-Small" Style="cursor: pointer" OnClick="btncollapse_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 100px" align="center">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="drbuilding" runat="server" Width="100%" OnSelectedIndexChanged="drbuilding_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 100px" align="center">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="drcategory" runat="server" Width="100%" OnSelectedIndexChanged="drcategory_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 100px" align="center">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="drflevel" runat="server" Width="100%" OnSelectedIndexChanged="drflevel_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 100px" align="center">
                        &nbsp;
                    </td>
                    <td style="width: 100px" align="center">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="drfed" runat="server" Width="100%" OnSelectedIndexChanged="drfed_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 100px" align="center">
                        &nbsp;
                    </td>
                    <td style="width: 100px" align="center">
                        &nbsp;
                    </td>
                    <td style="width: 200px" align="center">
                        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="drloc" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="drloc_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 100px" align="center">
                        &nbsp;
                    </td>
                    <td style="width: 100px" align="center">
                        &nbsp;
                    </td>
                    <td style="width: 100px" align="center">
                        &nbsp;
                    </td>
                    <td style="width: 100px" align="center">
                        &nbsp;
                    </td>
                    <td style="width: 100px" align="center">
                        &nbsp;
                    </td>
                    <td style="width: 100px" align="center">
                        &nbsp;
                    </td>
                    <td style="width: 100px" align="center">
                        &nbsp;
                    </td>
                    <td style="width: 100px" align="center">
                        &nbsp;
                    </td>
                    <td style="width: 100px" align="center">
                        &nbsp;
                    </td>
                    <td style="width: 100px" align="center">
                        &nbsp;
                    </td>
                    <td style="width: 100px" align="center">
                        &nbsp;
                    </td>
                    <td style="width: 100px" align="center">
                        &nbsp;
                    </td>
                    <td style="width: 100px" align="center">
                        &nbsp;
                    </td>
                    <td style="width: 100px" align="center">
                        &nbsp;
                    </td>
                    <td style="width: 300px" align="center">
                        &nbsp;
                    </td>
                    <td style="width: 100px" align="center">
                        &nbsp;
                    </td>
                    <td style="width: 100px" align="center">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div id="DataDiv" style="overflow: scroll; margin: 0;" onscroll="Onscrollfnction();">
            <div style="position: relative; float: left; width: 3076px">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="mymaster" runat="server" AutoGenerateColumns="False" Width="3076px"
                            OnRowDataBound="mymaster_RowDataBound" Font-Names="Verdana" Font-Size="X-Small"
                            ShowHeader="False" GridLines="None">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table id="inner_table" width="3076px">
                                            <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                                                <td style="width: 50px">
                                                    <asp:Button ID="Button1" runat="server" Text="-" CommandArgument="Button1" OnClientClick="setfocus();"
                                                        OnClick="Button1_Click" Width="30px" Style="cursor: pointer" />
                                                </td>
                                                <td style="font-weight: bold; width: 3343px" align="left">
                                                    <asp:Label ID="lbSys_Name" runat="server" Text='<%# Eval("Sys_Name") %>' Width="300px"></asp:Label>
                                                    <asp:Label ID="lbSys_Id" runat="server" Text='<%# Eval("Sys_Id") %>' Style="display: none"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="mydetails" runat="server" AutoGenerateColumns="False" OnRowCommand="mydetails_RowCommand"
                                                        OnRowDataBound="mydetails_RowDataBound" Font-Names="Verdana" Font-Size="X-Small"
                                                        ShowHeader="false">
                                                        <Columns>
                                                            <asp:BoundField>
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="E_b_ref">
                                                                <ItemStyle Width="100px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="B_Z">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="cat">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="F_lvl">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Seq_No">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="F_from">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="P_P_to">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Des">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Loc">
                                                                <ItemStyle Width="200px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Pwr_on">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                             <asp:TemplateField>
                                                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Convert.ToInt32(Eval("per_com3"))== -1? "N/A" : Eval("PCdate")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="test1">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="test2">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="test3">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="test4">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="test5">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField>
                                                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("per_com1")+ "%"  %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="accept1">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="filed1">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                             <asp:TemplateField>
                                                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label3" runat="server" Text='<%# Convert.ToInt32(Eval("per_com4"))== -1? "N/A" : Eval("PCdate1")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="test6">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="accept2">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="filed2">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Comm">
                                                                <ItemStyle Width="300px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Act_by">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Act_Date">
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
                <h2 style="margin: 0">
                    Summary of Transformers Commissioning and Testing</h2>
                <div style="width: 1500px">
                    <div style="float: left">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="mygridsumm" runat="server" AutoGenerateColumns="False" OnRowCreated="mygridsumm_RowCreated"
                                    OnRowDataBound="mygridsumm_RowDataBound" ShowFooter="true">
                                    <HeaderStyle CssClass="gvHeaderRow" />
                                    <RowStyle Height="25px" />
                                    <FooterStyle CssClass="gvFooetRow" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField HeaderText="ITEM NO" HeaderStyle-Font-Bold="false">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SYS_NAME" HeaderText="EQUIPMENT" HeaderStyle-Font-Bold="false">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="QTY" HeaderText="QUANTITY" HeaderStyle-Font-Bold="false">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="QTY_PER_COMPLETED" HeaderText="Qty Planned" HeaderStyle-Font-Bold="false">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="P_PER_COMPLETED" HeaderText="% Planned" HeaderStyle-Font-Bold="false">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PER_COMPLETED" HeaderText="% Actual Progress" HeaderStyle-Font-Bold="false">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="QTY_PER_COMPLETED1" HeaderText="Qty Planned" HeaderStyle-Font-Bold="false">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="P_PER_COMPLETED1" HeaderText="% Planned" HeaderStyle-Font-Bold="false">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PER_COMPLETED1" HeaderText="% Actual Progress" HeaderStyle-Font-Bold="false">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PLANNED_TOTAL" HeaderText="Planned Overall Progress" HeaderStyle-Font-Bold="false">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TOTAL" HeaderText="Overall Progress" HeaderStyle-Font-Bold="false">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="P_NA1" />
                                        <asp:BoundField DataField="P_NA2" />
                                        <%--<asp:TemplateField HeaderText="TRANSFORMER" HeaderStyle-Font-Bold="false">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <ItemTemplate >
                        <asp:Label ID="lblpercom" runat="server" Text='<%# Eval("PER_COMPLETED")+ "%"  %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>--%>
                                        <%--<asp:TemplateField HeaderText="CABLE" HeaderStyle-Font-Bold="false">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <ItemTemplate >
                        <asp:Label ID="lblpercom1" runat="server" Text='<%# Eval("PER_COMPLETED2")+ "%"  %>' ></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>--%>
                                        <%--<asp:BoundField DataField ="PER_COMPLETED" HeaderText="COLD TEST" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundField>--%>
                                        <%--<asp:BoundField DataField ="PER_COMPLETED1" HeaderText="LIVE TEST" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundField>--%>
                                        <%--<asp:BoundField DataField ="PER_COMPLETED2" HeaderText="ENGINEER ACCEPTED" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundField>--%>
                                        <%--<asp:TemplateField HeaderText="OVERALL PROGRESS" HeaderStyle-Font-Bold="false">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <ItemTemplate >
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("TOTAL")+ "%"  %>' ></asp:Label>
                    </ItemTemplate>
                   <%-- </asp:TemplateField>--%>
                                        <%--<asp:BoundField DataField="CODE" />
                     <asp:BoundField DataField="PER_COMPLETED" />
                    <asp:BoundField DataField="PER_COMPLETED2" />
                    <asp:BoundField DataField="TOTAL" />--%>
                                    </Columns>
                                </asp:GridView>
                                <input type="hidden" runat="server" id="hdnTxQty" value="" />
                                <input type="hidden" runat="server" id="hdnTxP" value="" />
                                <input type="hidden" runat="server" id="hdnTXA" value="" />
                                <input type="hidden" runat="server" id="hdnCaQty" value="" />
                                <input type="hidden" runat="server" id="hdnCaP" value="" />
                                <input type="hidden" runat="server" id="hdnCaA" value="" />
                                <input type="hidden" runat="server" id="hdnPLOverall" value="" />
                                <input type="hidden" runat="server" id="hdnACOverall" value="" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div style="float: left" id="weighting" runat="server">
                        <table>
                            <tr>
                                <td style="font-weight: bold">
                                    Weighting:
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    90% Transformer
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    10% Cable
                                </td>
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
        $(document).ready(function() {
            SetCurrentDate();
        });
        function SetCurrentDate() {
            var tdate = new Date();
            var dd = tdate.getDate(); //yields day
            var MM = tdate.getMonth(); //yields month
            var yyyy = tdate.getFullYear(); //yields year
            var xxx = dd + "/" + (MM + 1) + "/" + yyyy;
            document.getElementById("txtpcddate").value = xxx;
        }
        function setGen() {
            var mvalue = document.getElementById("txtpcddate").value;
            document.getElementById("hdnpcd").value = mvalue;
        }
    </script>

</body>
</html>
