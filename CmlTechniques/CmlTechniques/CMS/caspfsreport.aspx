<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="caspfsreport.aspx.cs" Inherits="CmlTechniques.CMS.caspfsreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
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
        <link href="../page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div style="font-family: verdana; font-size: xx-small">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
         <div style="background-color:#092443;color:White;font-weight:bold;font-size:small;width:2667px">
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
                            <asp:Label ID="lblhead" runat="server" Text="CAS MISC4 Power Failure Scenarios Commissioning Activity Schedule"></asp:Label></td>
                    </tr>
                </table>
                <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
        </div>
        <div style="position:relative;float:left;width:2667px">
        <table style="font-family: Verdana;font-size:x-small;background-color:#9EB6CE;" cellspacing="1" border="0">
        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
        <td style="width:100px" align="center" rowspan="2">ITEM NO.</td>
        <td style="width:100px" align="center" rowspan="2">ENG.REF</td>
        <td align="center" colspan="4">ASSET CODE</td>
        <td style="width:200px" align="center" rowspan="2">LOCATION</td>
        <td style="width:200px" align="center" rowspan="2">FED FROM</td>
        <td align="center" colspan="4">COMMISSIONING COMPLETION PRE-REQUISITES</td>
        <td align="center" colspan="4">TESTS</td>
        <td align="center" rowspan="2">% TEST COMPLETE</td>
        <td align="center" colspan="2">FINAL TEST SHEETS</td>
        <td style="width:300px" align="center" rowspan="2">COMMENTS</td>
        <td style="width:100px" align="center" rowspan="2">ACTION BY</td>
        <td style="width:100px" align="center" rowspan="2">ACTION DATE</td>
        </tr>
        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
        <td style="width:100px" align="center">BUILDING/ ZONE</td>
        <td style="width:100px" align="center">CATEGORY</td>
        <td style="width:100px" align="center">FLOOR LEVEL</td>
        <td style="width:100px" align="center">SEQ. NO</td>
        <td align="center">MECHANICAL</td>
        <td align="center">ELECTRICAL</td>
        <td align="center">FIRE/ BMS/ SCADA</td>
        <td align="center">BUILDING IN AUTO</td>
        <td align="center">POWER FAILURE TESTING</td>
        <td align="center">EMERGENCY POWER -PICK UP TESTS</td>
        <td align="center">FA C&amp;E TESTS WITH POWER FAILURE</td>
        <td align="center">THE POWER REINSTATEMENT TEST</td>
        <td align="center">CONSULTANT ACCEPTED</td>
        <td align="center">TEST SHEETS FILED</td>
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
            <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drloc" runat="server" Width="100%" AutoPostBack="true" 
                        onselectedindexchanged="drloc_SelectedIndexChanged"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
        <td style="width:200px" align="center">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drfed" runat="server" Width="100%" 
                    OnSelectedIndexChanged="drfed_SelectedIndexChanged" AutoPostBack="true"  >
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
        <div style="position:relative;float:left;width:2667px">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
            <asp:GridView ID="mymaster" runat="server" AutoGenerateColumns="False" 
                Width="2667px" onrowdatabound="mymaster_RowDataBound" 
                Font-Names="Verdana" 
                    Font-Size="X-Small" ShowHeader="False" GridLines="None" >
            <Columns>
            <asp:TemplateField>
            <ItemTemplate>
            <table id="inner_table" width="2667px">
            <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
            <td style="width:50px">
            
                <asp:Button ID="Button1" runat="server" Text="-" CommandArgument = "Button1"  OnClick = "Button1_Click" Width="30px" style="cursor:pointer" />
                </td>
            <td style="font-weight: bold;width:2667px" align="left">
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
                <asp:BoundField DataField ="E_b_ref">
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
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
                <asp:BoundField DataField="Loc">
                    <ItemStyle Width="200px" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="F_from">
                    <ItemStyle Width="200px" HorizontalAlign="Center" />
                    </asp:BoundField>
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
                    <asp:BoundField DataField="test6">
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test7">
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test11">
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField >
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <ItemTemplate >
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("per_com1")+ "%"  %>' ></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Accept1">
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="filed1">
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
            <h2 style="margin:0">Summary of Commissioning &amp; Testing</h2>
            <%--<asp:GridView ID="mygridsumm1" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" ForeColor="#333333" onrowcreated="mygridsumm_RowCreated" 
                onrowdatabound="mygridsumm_RowDataBound">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                <asp:BoundField DataField="Euip" HeaderText="" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                <asp:BoundField DataField ="qty" HeaderText="Quantity" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="per_com" HeaderText="No.of Points Tested" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                    </asp:BoundField>
                <asp:BoundField DataField="total" HeaderText="% of Completed" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>--%>
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <ContentTemplate>
             <asp:GridView ID="mygridsumm" runat="server" AutoGenerateColumns="False" 
                onrowdatabound="mygridsumm_RowDataBound" ShowFooter="true">
                <HeaderStyle CssClass="gvHeaderRow" />
                 <RowStyle Height="25px" />
                  <FooterStyle CssClass="gvFooetRow" HorizontalAlign="Center" />
                <Columns>
                <asp:BoundField HeaderText="ITEM NO" HeaderStyle-Font-Bold="false" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:BoundField>
                <asp:BoundField DataField="SYS_NAME" HeaderText="TESTS" HeaderStyle-Font-Bold="false" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" Width="250px" />
                    </asp:BoundField>
                <asp:BoundField DataField ="QTY" HeaderText="NO.OF EQUIPMENTS" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundField>
                <asp:BoundField DataField ="PER_COMPLETED" HeaderText="NO.OF EQUIPMENTS TESTED" HeaderStyle-Font-Bold="false" > 
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundField>    
                 <asp:TemplateField HeaderText="% COMPLETE" HeaderStyle-Font-Bold="false">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <ItemTemplate >
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("TOTAL")+ "%"  %>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
              </Columns>
            </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>
