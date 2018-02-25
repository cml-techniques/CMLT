<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_M_2.aspx.cs" Inherits="CmlTechniques.CasSheet.Add_M_2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
     <link href="Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div id="container">
        <div class="box">
        <table style="width:100%;background-color:#e4e4e4;">
        <tr>
        <td colspan="9" style="background-color: #26405E;color:#fff;padding:5px;font-size:14px;font-weight:bold;">CAS E1 Electrical Services. HV-MV Switchgear & RMU Commissioning Activity Schedule </td>
        </tr>
        <tr style="text-align:center">
        <td  style="width:150px">Select Package</td>
        <td style="width:200px">
            <asp:DropDownList ID="drpackage" runat="server" Width="200px">
            </asp:DropDownList>
        </td>
        <td style="width:150px">No. Of Rows</td>
        <td style="width:50px">
            <asp:TextBox ID="txt_rows" runat="server"></asp:TextBox></td>
        <td style="width:75px">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:Button ID="btn_genrows" runat="server" Text="Generate Rows" 
                    onclick="btn_genrows_Click"  />
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
            <td style="width:75px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnadd" runat="server" Text="Save" Width="75px" 
                        onclick="btnadd_Click" />
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width:75px"><asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" Width="75px" />
                </ContentTemplate>
                </asp:UpdatePanel></td>
            <td style="width:75px"><asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnback" runat="server" Text="Back" Width="75px" 
                        onclick="btnback_Click" />
                </ContentTemplate>
                </asp:UpdatePanel></td>
        <td>
            <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label><asp:Label ID="lblsch" runat="server" Text="" CssClass="hidden"></asp:Label></td>
        </tr>
        </table>
        </div>
        <div class="box">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <table style="width:100%;background-color:#e4e4e4;" id="row" runat="server" cellspacing="1" border="0" >
        <tr style="text-align:center;background-color:#82BAED;">
        <td style="width:5%" rowspan="2">Item No.</td>
        <td style="width:15%" rowspan="2">Engineer Ref.</td>
        <td colspan="4">Asset Code</td>
        <td style="width:10%" rowspan="2">Location<br /><br />
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <ContentTemplate>
            <asp:CheckBox ID="chk_locall" runat="server" Text="Apply All" Font-Size="XX-Small" 
                    ForeColor="#ccc" AutoPostBack="true" 
                    oncheckedchanged="chk_locall_CheckedChanged" />
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td style="width:10%" rowspan="2">Fed From<br /><br />
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
            <asp:CheckBox ID="chk_fedall" runat="server" Text="Apply All" Font-Size="XX-Small" 
                    ForeColor="#ccc" AutoPostBack="true" 
                    oncheckedchanged="chk_fedall_CheckedChanged" />
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td style="width:10%" rowspan="2">Provides Power To<br />
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
            <ContentTemplate>
            <asp:CheckBox ID="chk_pptoall" runat="server" Text="Apply All" Font-Size="XX-Small" 
                    ForeColor="#ccc" AutoPostBack="true" 
                    oncheckedchanged="chk_pptoall_CheckedChanged" />
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td style="width:10%" rowspan="2">Substation<br /><br />
            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
            <ContentTemplate>
            <asp:CheckBox ID="chk_suball" runat="server" Text="Apply All" Font-Size="XX-Small" 
                    ForeColor="#ccc" AutoPostBack="true" 
                    oncheckedchanged="chk_suball_CheckedChanged" />
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
        <tr style="text-align:center;background-color:#82BAED;">
        <td style="width:10%">Building Zone<br />
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
            <asp:CheckBox ID="bz_all" runat="server" Text="Apply All" Font-Size="XX-Small" 
                ForeColor="#ccc" oncheckedchanged="bz_all_CheckedChanged" AutoPostBack="true" />
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        <td style="width:10%">Category<br />
            </td>
        <td style="width:10%">Floor Level<br />
            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
            <ContentTemplate>
            <asp:CheckBox ID="chk_flvlall" runat="server" Text="Apply All" Font-Size="XX-Small" 
                    ForeColor="#ccc" AutoPostBack="true" 
                    oncheckedchanged="chk_flvlall_CheckedChanged" />
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td style="width:10%">Seq.No</td>
        </tr>
        <tr id="row1" runat="server" style="text-align:center">
        <td>
            <asp:Label ID="Label1" runat="server" Text="1"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="txt_eref1" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_bz1" runat="server" Width="100%"  CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_cat1" runat="server" Width="100%"  CssClass="text"></asp:TextBox>
            </td>
        <td align="center">
            <asp:DropDownList ID="dr_fvl1" runat="server" Width="100%" CssClass="text" 
                onselectedindexchanged="dr_fvl1_SelectedIndexChanged" AutoPostBack="true" >
            </asp:DropDownList>
            </td>
        <td>
            <asp:TextBox ID="txt_seq1" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_loc1" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_fed1" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_ppto1" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_sub1" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr id="row2" runat="server" style="text-align:center">
        <td>
            <asp:Label ID="Label2" runat="server" Text="2"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="txt_eref2" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_bz2" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_cat2" runat="server" Width="100%"  CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:DropDownList ID="dr_fvl2" runat="server" Width="100%" CssClass="text" 
                onselectedindexchanged="dr_fvl2_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            </td>
        <td>
            <asp:TextBox ID="txt_seq2" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_loc2" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_fed2" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_ppto2" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_sub2" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr id="row3" runat="server" style="text-align:center">
        <td>
            <asp:Label ID="Label3" runat="server" Text="3"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="txt_eref3" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_bz3" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_cat3" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:DropDownList ID="dr_fvl3" runat="server" Width="100%" CssClass="text" 
                onselectedindexchanged="dr_fvl3_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            </td>
        <td>
            <asp:TextBox ID="txt_seq3" runat="server" Width="100%"  CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_loc3" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_fed3" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_ppto3" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_sub3" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr id="row4" runat="server" style="text-align:center">
        <td>
            <asp:Label ID="Label4" runat="server" Text="4"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="txt_eref4" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_bz4" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_cat4" runat="server" Width="100%"  CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:DropDownList ID="dr_fvl4" runat="server" Width="100%" CssClass="text" 
                onselectedindexchanged="dr_fvl4_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            </td>
        <td>
            <asp:TextBox ID="txt_seq4" runat="server" Width="100%"  CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_loc4" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_fed4" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_ppto4" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_sub4" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr id="row5" runat="server"  style="text-align:center">
        <td>
            <asp:Label ID="Label5" runat="server" Text="5"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="txt_eref5" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_bz5" runat="server" Width="100%"  CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_cat5" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:DropDownList ID="dr_fvl5" runat="server" Width="100%" CssClass="text" 
                onselectedindexchanged="dr_fvl5_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            </td>
        <td>
            <asp:TextBox ID="txt_seq5" runat="server" Width="100%"  CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_loc5" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_fed5" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_ppto5" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_sub5" runat="server" Width="100%"  CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr id="row6" runat="server" style="text-align:center">
        <td>
            <asp:Label ID="Label6" runat="server" Text="6"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="txt_eref6" runat="server" Width="100%"  CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_bz6" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_cat6" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:DropDownList ID="dr_fvl6" runat="server" Width="100%"  CssClass="text" 
                onselectedindexchanged="dr_fvl6_SelectedIndexChanged"  AutoPostBack="true">
            </asp:DropDownList>
            </td>
        <td>
            <asp:TextBox ID="txt_seq6" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_loc6" runat="server" Width="100%"  CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_fed6" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_ppto6" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_sub6" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr id="row7" runat="server" style="text-align:center">
        <td>
            <asp:Label ID="Label7" runat="server" Text="7"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="txt_eref7" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_bz7" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_cat7" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:DropDownList ID="dr_fvl7" runat="server" Width="100%" CssClass="text" 
                onselectedindexchanged="dr_fvl7_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            </td>
        <td>
            <asp:TextBox ID="txt_seq7" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_loc7" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_fed7" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_ppto7" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_sub7" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr id="row8" runat="server" style="text-align:center">
        <td>
            <asp:Label ID="Label8" runat="server" Text="8"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="txt_eref8" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_bz8" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_cat8" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:DropDownList ID="dr_fvl8" runat="server" Width="100%" CssClass="text" 
                onselectedindexchanged="dr_fvl8_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            </td>
        <td>
            <asp:TextBox ID="txt_seq8" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_loc8" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_fed8" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_ppto8" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_sub8" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr id="row9" runat="server"  style="text-align:center">
        <td>
            <asp:Label ID="Label9" runat="server" Text="9"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="txt_eref9" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_bz9" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_cat9" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:DropDownList ID="dr_fvl9" runat="server" Width="100%" CssClass="text" 
                onselectedindexchanged="dr_fvl9_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            </td>
        <td>
            <asp:TextBox ID="txt_seq9" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_loc9" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_fed9" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_ppto9" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_sub9" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr id="row10" runat="server" style="text-align:center">
        <td>
            <asp:Label ID="Label10" runat="server" Text="10"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="txt_eref10" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_bz10" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_cat10" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:DropDownList ID="dr_fvl10" runat="server" Width="100%" CssClass="text" 
                onselectedindexchanged="dr_fvl10_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            </td>
        <td>
            <asp:TextBox ID="txt_seq10" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_loc10" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_fed10" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_ppto10" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        <td>
            <asp:TextBox ID="txt_sub10" runat="server" Width="100%" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        </table>
            </ContentTemplate>
            </asp:UpdatePanel>
        
        </div>
        <div id="myprogress" runat="server" style="position:absolute; z-index:40;top:40%;left: 45%">
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
