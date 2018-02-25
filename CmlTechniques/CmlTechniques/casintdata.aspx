<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="casintdata.aspx.cs" Inherits="CmlTechniques.casintdata" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <style type="text/css">
  .header
  {
    font-weight:bold;
    position:absolute;
    background-color:White;
  }
  </style>

    <link href="page.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" />
    </head>
<body >
    <form id="form1" runat="server">
    <div style="font-family: verdana; font-size: x-small;height:100%;position:fixed;width:100%">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div style="height:100%;width:100%">
        <table style="width:100%;color:White" bgcolor="#092443">
        <tr>
        <td width="150px" >Select Package</td>
        <td width="250px" >
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drpackage" runat="server" 
                Width="250px" AutoPostBack="True" 
                onselectedindexchanged="drpackage_SelectedIndexChanged">
                                </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
                                
                                </td>
        <td ></td>
        <td align="center" >Filter By</td>
        <td width="150px" >
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drfilterby" runat="server" 
                Width="150px" AutoPostBack="True" onselectedindexchanged="drfilterby_SelectedIndexChanged" >
                                    <asp:ListItem Value="2">&lt;&lt;--&gt;&gt;</asp:ListItem>
                                    <asp:ListItem Value="0">Package</asp:ListItem>
                                    <asp:ListItem Value="1">Floor Level</asp:ListItem>
                                </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
                                
                                </td>
        <td width="150px" >
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                                <asp:DropDownList ID="drfilter" runat="server" 
                Width="150px" AutoPostBack="True" 
                                        
                onselectedindexchanged="drpackage_SelectedIndexChanged">
                                </asp:DropDownList>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                                </td>
                                <td >
                                    <asp:Button ID="btnfilter" runat="server" Text="Filter" 
                                        onclick="btnfilter_Click" />
                                    <asp:Button ID="btnfcancel" runat="server" Text="Cancel" 
                                        onclick="btnfcancel_Click"  /></td>
        </tr>
        <tr>
        <td colspan="7">
        <table runat="server" border="1" style="border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana;font-size:x-small;width:100%" >
                                            <%--<tr runat="server" style="background-color: #E0FFFF;color: #333333;">--%>
                                                <%--<th runat="server">
                                                    cas_id</th>
                                                <th runat="server">
                                                    itm_no</th>--%>
                                                <%--<th runat="server">
                                                    sys_id</th>
                                                <th runat="server">
                                                    reff_</th>
                                                <th runat="server">
                                                    desc_</th>
                                                <th runat="server">
                                                    loca_</th>
                                                <th runat="server">
                                                    p_power_to</th>
                                                <th runat="server">
                                                    fed_from</th>--%>
                                                <%--<th runat="server">
                                                    power_on</th>--%>
                                                <%--<th runat="server">
                                                    devices</th>
                                            </tr>
                                            <tr ID="itemPlaceholder" runat="server">
                                            </tr>--%>
                                            <tr runat="server">
                                           
                            <td align="center" rowspan="2" valign="middle" >
                                &nbsp;</td>
                            <td align="center" rowspan="2" valign="middle"  >
                                ENGG.REFF</td>
                            <td align="center" colspan="4" valign="middle" >
                                ASSET CODE</td>
                            <td align="center" rowspan="2" valign="middle" >
                                LOCATION</td>
                            <td align="center" rowspan="2" valign="middle" >
                                <asp:Label ID="lbl1" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" >
                                <asp:Label ID="lbl3" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" >
                                <asp:Label ID="lbl2" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" >
                                <asp:Label ID="lbnum" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="center" valign="middle" height="25px" width="75px"  >
                                BUILDING/ ZONE</td>
                            <td align="center" valign="middle"  >
                                CATEGORY</td>
                            <td align="center" valign="middle"  >
                                FLOOR LEVEL</td>
                            <td align="center" valign="middle"  >
                                SEQ.NO</td>
                        </tr>
                        <tr>
                                            <td align="center" valign="middle" >
                                                <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>--%>
                                                <asp:Button ID="btnadd" runat="server" Text="add" onclick="btnadd_Click" 
                                                    Width="50px" />
                                                <%--</ContentTemplate>
                                                </asp:UpdatePanel>--%>
                                            </td>
                            <td align="center" valign="middle">
                                <asp:TextBox ID="txtengref" runat="server" Width="75px"></asp:TextBox>
                                            </td>
                            <td align="center" valign="middle" style="width:50px">
                                <asp:TextBox ID="txtzone" runat="server" Width="75px"></asp:TextBox>
                                            </td>
                            <td align="center" valign="middle" >
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                <asp:TextBox ID="txtcate" runat="server" Width="75px"></asp:TextBox>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                                            </td>
                            <td align="center" valign="middle" >
                                <asp:TextBox ID="txtlevel" runat="server" Width="75px"></asp:TextBox>
                                            </td>
                            <td align="center" valign="middle" >
                                <asp:TextBox ID="txtseq" runat="server" Width="50px"></asp:TextBox>
                                            </td>
                            <td align="center" valign="middle" >
                                <asp:TextBox ID="txtloca" runat="server" Width="100px" ></asp:TextBox>
                                            </td>
                            <td align="center" valign="middle">
                                <asp:TextBox ID="txtpprovideto" runat="server" Width="75px" 
                                    ></asp:TextBox>
                                            </td>
                            <td align="center" valign="middle">
                                <asp:TextBox ID="txtfedfr" runat="server" Width="75px" 
                                    ></asp:TextBox>
                                            </td>
                            <td align="center" valign="middle">
                                <asp:TextBox ID="txtdesc" runat="server" Width="100px"></asp:TextBox>
                                            </td>
                            <td align="center" valign="middle">
                                <asp:TextBox ID="txtnoof" runat="server" Width="50px"></asp:TextBox>
                                            </td>
                        </tr>
                                        </table>
        </td>
        </tr>
        </table>
        
        </div>
        <div style="margin-top:5px" >
            <%--<asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>--%>
            
            <asp:GridView ID="mygrid" runat="server" AutoGenerateColumns="False" 
                Font-Bold="True" onpageindexchanging="mygrid_PageIndexChanging" 
                onsorting="mygrid_Sorting" CellPadding="4" 
                ForeColor="#333333" GridLines="Both"
                onrowdatabound="mygrid_RowDataBound" 
                onrowcommand="mygrid_RowCommand" onrowupdating="mygrid_RowUpdating" 
                onrowcreated="mygrid_RowCreated" Width="100%"  >
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                <asp:BoundField HeaderText="Itm.No" >
                    <ItemStyle Width="50px" />
                    </asp:BoundField>
                <%--<asp:BoundField DataField ="E_b_ref" HeaderText="Engg.Reff" >
                    <ItemStyle Width="225px" />
                    </asp:BoundField>--%>
                    <asp:ButtonField ButtonType="Link" DataTextField="E_b_ref" 
                        HeaderText="Engg.Reff" CommandName="Update" >
                    <ItemStyle Width="225px" />
                    </asp:ButtonField>
                <asp:BoundField DataField="B_Z" HeaderText="Building/Zone" >
                    <ItemStyle Width="75px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="cat" HeaderText="Category" >
                    <ItemStyle Width="75px" />
                    </asp:BoundField>
                <asp:BoundField DataField="F_lvl" HeaderText="Floor Level" >
                    <ItemStyle Width="75px" />
                    </asp:BoundField>
                <asp:BoundField DataField="Sq_No" HeaderText="Seq.No" >
                    <ItemStyle Width="50px" />
                    </asp:BoundField>
                <%--<asp:BoundField DataField="Des" HeaderText="Description" />--%>
                <asp:BoundField DataField="Loc" HeaderText="Location" >
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                <asp:BoundField DataField="P_P_to" HeaderText="Provides Power To" >
                    <ItemStyle Width="75px" />
                    </asp:BoundField>
                <asp:BoundField DataField="F_from" HeaderText="Fed From" >
                    <ItemStyle Width="75px" />
                    </asp:BoundField>
                <asp:BoundField DataField="Substation" HeaderText="Substation" >
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                <asp:BoundField DataField="devices1" >
                    <ItemStyle Width="50px" />
                    </asp:BoundField>
                <asp:BoundField DataField="C_id" />
                <asp:BoundField DataField="E_b_ref" />
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <%--<asp:BoundField DataField ="E_b_ref" HeaderText="Engg.Reff" >
                    <ItemStyle Width="225px" />
                    </asp:BoundField>--%>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:dbCMLConnectionString %>" 
                SelectCommand="load_casMain" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter DefaultValue="4" Name="sch_id" Type="Int32" />
                    <asp:Parameter DefaultValue="1" Name="prj_code" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:Panel ID="pnlPopup" runat="server" Width="720px" Height="350px" style="padding:50px" BackColor="#d1def1"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate>
                
                <div>
                <table style="width:720px">
                <tr>
                <td width="250px">Engg.Reff</td>
                    <td>
                        <asp:TextBox ID="upreff" runat="server" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                        <td width="150px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="150px">
                            Building/Zone</td>
                        <td>
                            <asp:TextBox ID="upzone" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            Category</td>
                        <td>
                            <asp:TextBox ID="upcate" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            Floor Level</td>
                        <td>
                            <asp:TextBox ID="upfloor" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            Seq.No</td>
                        <td>
                            <asp:TextBox ID="upseq" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="150px">
                            Location</td>
                        <td>
                            <asp:TextBox ID="uploc" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            <asp:Label ID="lb1" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="uplb1" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            <asp:Label ID="lb2" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="uplb2" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            <asp:Label ID="lb3" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="uplb3" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
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
                        <td width="150px">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnupdate" runat="server" Text="Update" 
                                onclick="btnupdate_Click" />
                                <asp:Button ID="btndelete" runat="server" Text="Delete" onclick="btndelete_Click" 
                                 />
                            <asp:Button ID="btncancel" runat="server" Text="Cancel" 
                                onclick="btncancel_Click" />
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
            
            
            
        </div>
    </div>
    </form>
</body>
</html>
