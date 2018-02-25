<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridScroll.aspx.cs" Inherits="CmlTechniques.GridScroll" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <style type="text/css">
        .style2
        {
            height: 25px;
        }
    </style>
    <link href="page.css" rel="stylesheet" type="text/css" />
</head>
<body >
    <form id="form1" runat="server">
    <div style="height:100%;position:absolute;width:100%">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div style="float:left;width:90%">
<%--<table align="left" border="1" cellspacing="0" style="border-collapse:collapse;position:relative;Width:700px" cellpadding="0">
<tr style="height:30px">
  <td bgcolor="Navy" width="200px"  align="center">
    <font color="White" size="4" face="Verdana"><b>FAQ ID</b></font>
  </td>
  <td bgcolor="Navy" width="400" align="center">
    <font color="White" size="4" face="Verdana"><b>Question</b></font>
  </td>
  <td bgcolor="Navy" width="100" align="center">
    <font color="White" size="4" face="Verdana"><b>Views</b></font>
  </td>
</tr>
</table>--%>
<table style="font-family: Verdana;font-size:x-small;background-color:#003399;width:100%" cellspacing="1" border="0">
       <tr runat="server" style="background-image: url('images/head_bg.png'); background-repeat: repeat;">
                            <td align="center" rowspan="2" valign="middle"   width="9%">
                                ENGG.REFF</td>
                            <td align="center" colspan="4" valign="middle"  >
                                ASSET CODE</td>
                            <td align="center" rowspan="2" valign="middle" width="9%" >
                                LOCATION</td>
                            <td align="center" rowspan="2" valign="middle" width="9%" >
                                <asp:Label ID="lbl1" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="9%" >
                                <asp:Label ID="lbl3" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="9%" >
                                <asp:Label ID="lbl2" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="9%" >
                                <asp:Label ID="lbnum" runat="server" Text=""></asp:Label></td>
                                <td width="9%"></td>
                        </tr>
                        <tr style="background-image: url('images/head_bg.png'); background-repeat: repeat;">
                            <td align="center" valign="middle"  width="9%"  >
                                BUILDING/ ZONE</td>
                            <td align="center" valign="middle" width="9%"  >
                                CATEGORY</td>
                            <td align="center" valign="middle" width="9%"  >
                                FLOOR LEVEL</td>
                            <td align="center" valign="middle" width="9%"  >
              SEQ.NO</td>
                        </tr>
                        </table>

</div>
<div style="position:relative; height:80%;overflow:auto;float:left;width:91.2%">
    <%--<asp:DataGrid runat="server" id="dgPopularFAQs"
         AutoGenerateColumns="False"
         ShowHeader="False"
         Font-Name="Verdana"
         Font-Size="X-Small" HorizontalAlign="Left" Font-Names="Verdana" >
         
        <AlternatingItemStyle BackColor="White" />
        <ItemStyle BackColor="#CCFFCC" />
         
    <Columns>
      <asp:BoundColumn DataField="E_b_ref" 
                ItemStyle-HorizontalAlign="Center"
                ItemStyle-Width="100px" >
<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
        </asp:BoundColumn>
      <asp:BoundColumn DataField="cat" 
              ItemStyle-Width="100px" >
<ItemStyle Width="100px"></ItemStyle>
        </asp:BoundColumn>
      <asp:BoundColumn DataField="B_Z" HeaderText="Views"
                ItemStyle-HorizontalAlign="Right"
                ItemStyle-Width="100px" >
<ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
        </asp:BoundColumn>
                <asp:BoundColumn DataField="F_lvl" HeaderText="FAQ ID" 
                ItemStyle-HorizontalAlign="Center"
                ItemStyle-Width="100px" >
<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
        </asp:BoundColumn>
      <asp:BoundColumn DataField="Sq_No" HeaderText="Question"
              ItemStyle-Width="100px" >
<ItemStyle Width="100px"></ItemStyle>
        </asp:BoundColumn>
      <asp:BoundColumn DataField="Loc" HeaderText="Views"
                ItemStyle-HorizontalAlign="Right"
                ItemStyle-Width="100px" >
<ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
        </asp:BoundColumn>
                <asp:BoundColumn DataField="P_P_to" HeaderText="FAQ ID" 
                ItemStyle-HorizontalAlign="Center"
                ItemStyle-Width="100px" >
<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
        </asp:BoundColumn>
      <asp:BoundColumn DataField="F_from" HeaderText="Question"
              ItemStyle-Width="100px" >
<ItemStyle Width="100px"></ItemStyle>
        </asp:BoundColumn>
      <asp:BoundColumn DataField="Substation" HeaderText="Views"
                ItemStyle-HorizontalAlign="Right"
                ItemStyle-Width="100px" >
<ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
        </asp:BoundColumn>
                <asp:BoundColumn DataField="devices1" HeaderText="Views"
                ItemStyle-HorizontalAlign="Right"
                ItemStyle-Width="100px" >
<ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
        </asp:BoundColumn>
                 <asp:BoundColumn DataField="C_id" HeaderText="Views"
                ItemStyle-HorizontalAlign="Right"
                ItemStyle-Width="100px" >
<ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
        </asp:BoundColumn>
    </Columns>
  </asp:DataGrid>--%>
  <asp:GridView ID="mygrid"  runat="server" AutoGenerateColumns="False" style="width:100%"
        ShowHeader="False" Font-Names="Verdana" Font-Size="X-Small" 
        onsorting="mygrid_Sorting" BackColor="White" BorderColor="#3366CC" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                >
                <RowStyle BorderColor="#9EB6CE" BackColor="#E0F7FD" ForeColor="#003399" />
                <Columns>
                <asp:BoundField DataField ="E_b_ref" HeaderText="Engg.Reff" >
                    <ItemStyle Width="9%" />
                    </asp:BoundField>
                <asp:BoundField DataField="cat" HeaderText="Category" >
                    <ItemStyle Width="9%" />
                    </asp:BoundField>
                <asp:BoundField DataField="B_Z" HeaderText="Building/Zone" >
                    <ItemStyle Width="9%" />
                    </asp:BoundField>
                <asp:BoundField DataField="F_lvl" HeaderText="Floor Level" >
                    <ItemStyle Width="9%" />
                    </asp:BoundField>
                <asp:BoundField DataField="Sq_No" HeaderText="Seq.No" >
                    <ItemStyle Width="9%" />
                    </asp:BoundField>
                <asp:BoundField DataField="Loc" HeaderText="Location" >
                    <ItemStyle Width="9%" />
                    </asp:BoundField>
                <asp:BoundField DataField="P_P_to" HeaderText="Provides Power To" >
                    <ItemStyle Width="9%" />
                    </asp:BoundField>
                <asp:BoundField DataField="F_from" HeaderText="Fed From" >
                    <ItemStyle Width="9%" />
                    </asp:BoundField>
                <asp:BoundField DataField="Substation" HeaderText="Substation" >
                    <ItemStyle Width="9%" />
                    </asp:BoundField>
                <asp:BoundField DataField="devices1" >
                    <ItemStyle Width="9%" />
                    </asp:BoundField>
                <asp:BoundField DataField="C_id" >
                    <ItemStyle Width="9%" />
                    </asp:BoundField>
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
</div>


    </div>
    </form>
    
</body>
</html>
