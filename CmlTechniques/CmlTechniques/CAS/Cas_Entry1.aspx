<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cas_Entry1.aspx.cs" Inherits="CmlTechniques.CAS.Cas_Entry1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: verdana; font-size: x-small;height:100%;position:fixed;width:100%">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <table style="width:100%;color:White" bgcolor="#092443">
        <tr>
        <td width="100px" colspan="5" style="background-color: #D2F1FC" >
            <asp:Label ID="lblhead" runat="server" Font-Bold="True" Font-Size="Small" 
                ForeColor="Black"></asp:Label>
            </td>
        </tr>
        <tr>
        <td width="100px">
            <asp:Label ID="Label1" runat="server" Text="Select Panel" Width="100px"></asp:Label>
            </td>
        <td width="250px" >
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drpanel" runat="server" 
                Width="250px" ></asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
                                </td>
                                <td width="100px">
                                 <asp:Label ID="Label2" runat="server" Text="Select Package" Width="100px"></asp:Label></td>
                                <td >
            <asp:UpdatePanel ID="UpdatePanel25" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drpackage" runat="server" 
                Width="250px" onselectedindexchanged="drpackage_SelectedIndexChanged" AutoPostBack="true" >
                                </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
                                </td>
        <td width="100%" align="right"  >
        <table>
        <tr>
        <td>
                                    <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnimport" runat="server" Text="Import From Excel" 
                                            onclick="btnimport_Click"  />
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
            <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label><asp:Label ID="lblsch" runat="server" Text="" style="display:none"></asp:Label>
                                </td>
        <td>
                                    <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                    <ContentTemplate>
                                        <asp:ImageButton ID="btnrefresh" runat="server" 
                                            ImageUrl="~/images/refresh1.png" />
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel18" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnedit" runat="server" Text="Edit" Width="75px" />
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
            <ContentTemplate>
            <asp:Button ID="btndelete1" runat="server" Text="Delete" Width="75px" 
                    onclick="btndelete_Click"  />
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
        </table>
        
        </td>
        </tr>
        </table>
        <div style="float:left;width:98.5%">
        <table style="font-family: Verdana;font-size:x-small;background-color:#9EB6CE;width:100%;" cellspacing="1" border="0">
       <tr  style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
       
                            <td align="center" rowspan="2" valign="middle"   width="5%">
                                &nbsp;</td>       
                            <td align="center" rowspan="2" valign="middle"   width="5%">
                                ITEM NO</td>
       
                            <td align="center" rowspan="2" valign="middle"   width="10%">
                                ENG.REF</td>
                            <td align="center" colspan="4" valign="middle"  >
                                ASSET CODE</td>
                            <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbldes" runat="server" >
                                <asp:Label ID="lbdes" runat="server" Text="DESCRIPTION"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="10%" id="td_lbl0" runat="server" >
                                <asp:Label ID="lbloc" runat="server" Text="LOCATION"></asp:Label>
                            </td>
                            <td align="center" rowspan="2" valign="middle" width="9%" id="td_lbl3" runat="server" >
                                <asp:Label ID="lbl3" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="9%" id="td_lbl1" runat="server" >
                                <asp:Label ID="lbl1" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="9%" id="td_lbl2" runat="server" >
                                <asp:Label ID="lbl2" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="9%" id="td_lbnum" runat="server" >
                                <asp:Label ID="lbnum" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                            <td align="center" valign="middle"  width="7%"  >
                                BUILDING/ ZONE</td>
                            <td align="center" valign="middle" width="7%"  >
                                CATEGORY</td>
                            <td align="center" valign="middle" width="7%"  >
                                FLOOR LEVEL</td>
                            <td align="center" valign="middle" width="7%"  >
              SEQ.NO</td>
                        </tr>
                        <tr bgcolor="#092443">
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                <asp:Button ID="btnadd" runat="server" Text="add" 
                                                    Width="94%" onclick="btnadd_Click" />
                </ContentTemplate>
                </asp:UpdatePanel>
                                                
                                                </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                <asp:TextBox ID="txtitmno" runat="server" Width="90%" style="text-align:center"></asp:TextBox>
                </ContentTemplate>
                </asp:UpdatePanel>
                                
                                            </td>
            <td>
                                <asp:TextBox ID="txtengref" runat="server" Width="94%"></asp:TextBox>
                                            </td>
            <td>
            
                <asp:TextBox ID="txtzone" runat="server" Width="92%"></asp:TextBox>                
                                            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <asp:TextBox ID="txtcate" runat="server" Width="92%"></asp:TextBox>
                </ContentTemplate>
                </asp:UpdatePanel>
                                
                                </td>
            <td>
                                <%--<asp:TextBox ID="txtlevel" runat="server" Width="92%"></asp:TextBox>--%>
                                <table style="width:100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                <td style="width:70%">
                                    <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="drflevel_" runat="server" Width="100%" 
                                            AutoPostBack="true" 
                                            onselectedindexchanged="drflevel__SelectedIndexChanged1" >
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="width:30%">
                                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnnewflevel" runat="server" Text=".." Width="100%"  />
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                </tr>
                                </table>
                                            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate>
                <asp:TextBox ID="txtseq" runat="server" Width="92%"></asp:TextBox>
                </ContentTemplate>
                </asp:UpdatePanel>
                                
                                            </td>
            <td id="td_txtdescr" runat="server">
                                <asp:TextBox ID="txtdes" runat="server" Width="94%" ></asp:TextBox>
                                            </td>
            <td id="td_txtloc" runat="server">
                                <asp:TextBox ID="txtloca" runat="server" Width="94%" ></asp:TextBox>
                                            </td>
            <td id="td_txtfed" runat="server">
                                <asp:TextBox ID="txtfedfr" runat="server" Width="94%" 
                                    ></asp:TextBox>
                                            </td>
            <td id="td_txtppt" runat="server">
                                <asp:TextBox ID="txtpprovideto" runat="server" Width="94%" 
                                    ></asp:TextBox>
                                            </td>
            <td id="td_txtdes" runat="server">
                                <asp:TextBox ID="txtdesc" runat="server" Width="94%"></asp:TextBox>
                                            </td>
            <td id="td_txtnum" runat="server">
                                <asp:TextBox ID="txtnoof" runat="server" Width="94%"></asp:TextBox>
                                            </td>
        </tr>
        <tr bgcolor="#092443" >
            <td>
             
                 <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                 <ContentTemplate>
                 <asp:Button ID="btnexpand" runat="server" Text="Exp.All" Width="94%"
                  ForeColor="Red" Font-Size="X-Small" style="cursor:pointer" onclick="btnexpand_Click" />
                 </ContentTemplate>
                 </asp:UpdatePanel>
                
             </td>
            <td>
              <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                 <ContentTemplate>
                 <asp:Button ID="btncollapse" runat="server" Text="Coll.All" Width="94%" 
                         ForeColor="Red" Font-Size="X-Small" style="cursor:pointer" onclick="btncollapse_Click" />
                 </ContentTemplate>
                 </asp:UpdatePanel></td>
            <td>
                &nbsp;</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drbuilding" runat="server" Width="100%" >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                 
            </td>
            <td>
           <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drcategory" runat="server" Width="100%"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
               </td>
            <td>
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drflevel" runat="server" Width="100%"   >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td>
                &nbsp;</td>
            <td id="tddes" runat="server">
            <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drdes" runat="server" Width="100%"   >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
            <td id="td0" runat="server">
            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drloc" runat="server" Width="100%"   >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
            <td id="td_1" runat="server">
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drfed" runat="server" Width="100%"   >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td id="td_0" runat="server">
                &nbsp;</td>
            <td id="td_2" runat="server">
                &nbsp;</td>
            <td id="td_3" runat="server">
                &nbsp;</td>
        </tr>
                        </table>
        </div>
        <div style="position:relative; height:67%;width:100%;overflow-y:scroll;float:left;">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Repeater ID="reptr_main" runat="server" 
                    onitemdatabound="reptr_main_ItemDataBound" 
                    ondatabinding="reptr_main_DataBinding"  >
                <ItemTemplate>
                <table style="width:100%" border="0" cellpadding="0" cellspacing="0">
                <tr style="background-color:#DFF6FC;height:30px;font-size:small;font-weight:bold;background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
                <td style="width:30px">
                    <asp:Button ID="btnexpd" runat="server" Text="+" Width="30px" style="border:none;cursor:pointer" OnClick="btnexpd_Click" /></td>
                <td style="padding-left:10px;width:100%">
                    <asp:Label ID="lbl_panelP" runat="server" Text='<%# Eval("Panel_Ref") %>'></asp:Label><asp:Label ID="lbl_panelPid" runat="server" Text='<%# Eval("Panel_Id") %>' style="display:none"></asp:Label></td>
                </tr>
                <tr>
                <td colspan="2" style="width:100%;margin:0;padding:0">
                
                    <asp:GridView ID="details" runat="server" Width="100%" ShowHeader="false" AutoGenerateColumns="false" Font-Names="Verdana" 
                    Font-Size="X-Small" OnRowDataBound="details_RowDataBound" BorderStyle="None" CellPadding="0" CellSpacing="0">
                    <Columns>
                    <asp:TemplateField>
                    <ItemTemplate>
                    <asp:Label ID="lblpanel" runat="server" Text='<%# Eval("Panel_id") %>' style="display:none"></asp:Label>
                    <asp:GridView ID="inner1" runat="server" Width="100%" ShowHeader="false" AutoGenerateColumns="false" Font-Names="Verdana" 
                    Font-Size="X-Small" CellPadding="0" CellSpacing="0" OnRowDataBound="mydetails_RowDataBound" >
                    <Columns>
                
                <%--<asp:ButtonField ButtonType="Button" Text="Update" CommandName="Get"
                        ItemStyle-Width="6%" >
                    <ItemStyle Width="6%"  />
                    </asp:ButtonField>--%>
                <asp:TemplateField >
                <ItemTemplate>
                    <asp:CheckBox ID="chkrow" runat="server" OnCheckedChanged="chkrow_CheckedChanged" AutoPostBack="true" />
                </ItemTemplate>
                <ItemStyle Width="5%" HorizontalAlign="Center"  />
                </asp:TemplateField>    
                
                <asp:BoundField HeaderText="Itm.No" ItemStyle-Width="5%" >
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField ="E_b_ref" HeaderText="Engg.Reff" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                 <asp:BoundField DataField="B_Z" HeaderText="Building/Zone" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>  
                <asp:BoundField DataField="cat" HeaderText="Category" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                 
                <asp:BoundField DataField="F_lvl" HeaderText="Floor Level" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Seq_No" HeaderText="Seq.No" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Des" HeaderText="Substation" 
                        ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Loc" HeaderText="Location" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="F_from" HeaderText="Fed From" ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>    
                <asp:BoundField DataField="P_P_to" HeaderText="Provides Power To" 
                        ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Substation" HeaderText="Substation" 
                        ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="devices1" ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="C_id" />
                <asp:BoundField DataField="Sys_Id" />
                </Columns>
                    </asp:GridView>
                    <asp:GridView ID="inner_sub" runat="server" Width="100%" ShowHeader="false" AutoGenerateColumns="false" Font-Names="Verdana" 
                    Font-Size="X-Small" OnRowDataBound="inner_sub_RowDataBound" CellPadding="0" CellSpacing="0" BorderStyle="None">
                    <Columns>
                    <asp:TemplateField>
                    <ItemTemplate>
                    <table style="width:100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="background-color:#CCCCCC;height:20px;font-size:small;font-weight:bold;" >
                    <td style="padding-left:10px"><asp:Label ID="lbl_panelC" runat="server" Text='<%# Eval("Panel_Ref") %>'></asp:Label><asp:Label ID="lbl_panelCid" runat="server" Text='<%# Eval("Panel_Id") %>' style="display:none"></asp:Label></td>
                    </tr>
                    <tr>
                    <td style="width:100%">
                    <asp:GridView ID="inner2" runat="server" Width="100%" ShowHeader="false" AutoGenerateColumns="false" Font-Names="Verdana" 
                    Font-Size="X-Small" CellPadding="0" CellSpacing="0" OnRowDataBound="mydetails_RowDataBound">
                    <Columns>
                
                <%--<asp:ButtonField ButtonType="Button" Text="Update" CommandName="Get"
                        ItemStyle-Width="6%" >
                    <ItemStyle Width="6%"  />
                    </asp:ButtonField>--%>
                <asp:TemplateField >
                <ItemTemplate>
                    <asp:CheckBox ID="chkrow" runat="server" OnCheckedChanged="chkrow_CheckedChanged" AutoPostBack="true" />
                </ItemTemplate>
                <ItemStyle Width="5%" HorizontalAlign="Center"  />
                </asp:TemplateField>    
                
                <asp:BoundField HeaderText="Itm.No" ItemStyle-Width="5%" >
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField ="E_b_ref" HeaderText="Engg.Reff" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                 <asp:BoundField DataField="B_Z" HeaderText="Building/Zone" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>  
                <asp:BoundField DataField="cat" HeaderText="Category" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                 
                <asp:BoundField DataField="F_lvl" HeaderText="Floor Level" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Seq_No" HeaderText="Seq.No" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Des" HeaderText="Substation" 
                        ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Loc" HeaderText="Location" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="F_from" HeaderText="Fed From" ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>    
                <asp:BoundField DataField="P_P_to" HeaderText="Provides Power To" 
                        ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Substation" HeaderText="Substation" 
                        ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="devices1" ItemStyle-Width="9%" >
                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="C_id" />
                <asp:BoundField DataField="Sys_Id" />
                </Columns>
                    </asp:GridView>
                    </td>
                    </tr>
                    </table>
                    </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                    </asp:GridView>
                    
                    </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                    </asp:GridView>
                    
                 
                </td>
                </tr>
                </table>
                </ItemTemplate>
                </asp:Repeater>
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
       <%-- <asp:Panel ID="pnlPopup" runat="server" Width="400px" style="padding:15px;background-color:#83C8EE;display:none" >
            <div>
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                <ContentTemplate>
                
                <div>
                <table style="width:400px;background-color:White;">
                <tr>
                <td width="250px">ENG.REF</td>
                    <td width="150px">
                        <asp:TextBox ID="upreff" runat="server" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                        <td width="150px">
                            BUILDING/ZONE</td>
                        <td>
                            <asp:TextBox ID="upzone" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            CATEGORY</td>
                        <td>
                            <asp:TextBox ID="upcate" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            FLOOR LEVEL</td>
                        <td>
                            <asp:TextBox ID="upfloor" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            SEQ.NO</td>
                        <td>
                            <asp:TextBox ID="upseq" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr0" runat="server">
                        <td width="150px">
                            <asp:Label ID="lbldes" runat="server" Text="DESCRIPTION"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="updescr" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr1" runat="server">
                        <td width="150px">
                            <asp:Label ID="lblloc" runat="server" Text="LOCATION"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="uploc" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr2" runat="server">
                        <td width="150px">
                            <asp:Label ID="lb3" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="uplb3" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr3" runat="server">
                        <td width="150px">
                            <asp:Label ID="lb1" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="uplb1" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr4" runat="server">
                        <td width="150px">
                            <asp:Label ID="lb2" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="uplb2" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr5" runat="server">
                        <td width="150px">
                            <asp:Label ID="lb4" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="uplb4" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                        <table>
                        <tr>
                        <td> <asp:Button ID="btnupdate" runat="server" Text="Update" 
                                onclick="btnupdate_Click" /></td>
                        <td><asp:Button ID="btndelete" runat="server" Text="Delete" onclick="btndelete_Click" style="display:none"
                                 /></td>
                        <td><asp:Button ID="btncancel" runat="server" Text="Cancel" 
                                onclick="btncancel_Click" /></td>
                        </tr>
                        </table>
                        
                        
                       </td>
                    </tr>
                </table>
               
                </div>
             </ContentTemplate>
                </asp:UpdatePanel>
            </div>
                        
                  </asp:Panel>
                  
                    <asp:Button ID="btnDummy" runat="server" Text="Button" style="display:none;" />
                  <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" 
                  TargetControlID="btnDummy"  PopupControlID="pnlPopup"
                  BackgroundCssClass="modal"
                  DropShadow="true">
                  </asp:ModalPopupExtender> 
        <asp:Panel ID="pnlPopup1" runat="server" Width="250px" style="padding:15px;background-color:#83C8EE;display:none" >
            <div>
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                <ContentTemplate>
                
                <div>
                <table style="width:250px; background-color:White;">
                <tr>
                <td style="width:150px">ENTER FLOOR LEVEL</td>
                <td style="width:100px">
                    <asp:TextBox ID="txtflvl" runat="server"></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                        <td colspan="2" align="center">
                        <table>
                        <tr>
                        <td> <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click"  /></td>
                        <td><asp:Button ID="btncancel1" runat="server" Text="Cancel" 
                                onclick="btncancel1_Click"  /></td>
                        </tr>
                        </table>
                        
                        
                       </td>
                    </tr>
                </table>
               
                </div>
             </ContentTemplate>
                </asp:UpdatePanel>
            </div>
                        
                  </asp:Panel>
                  
                    <asp:Button ID="btnDummy1" runat="server" Text="Button" style="display:none;" />
                  <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender1" runat="server" 
                  TargetControlID="btnDummy1"  PopupControlID="pnlPopup1"
                  BackgroundCssClass="modal"
                  DropShadow="true">
                  </asp:ModalPopupExtender>     --%> 
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                OldValuesParameterFormatString="original_{0}" 
                onselecting="ObjectDataSource1_Selecting" SelectMethod="GetData" 
                
            TypeName="CmlTechniques.CAS.ccad_casTableAdapters.Load_Cassheet_dataTableAdapter">
            <SelectParameters>
                <asp:Parameter Name="sch_id" Type="Int32" />
                <asp:Parameter Name="prj_code" Type="String" />
            </SelectParameters>
            </asp:ObjectDataSource>     
    </div>
    </form>
</body>
</html>
