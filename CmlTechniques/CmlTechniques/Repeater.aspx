<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Repeater.aspx.cs" Inherits="CmlTechniques.Repeater" %>

<%@ Register Assembly="MultiFieldGroupingRepeater" Namespace="MultiFieldGroupingRepeater"
    TagPrefix="cc1" %>
<%--<%@ Register tagprefix="cc1" Assembly="GroupedRepeater" NameSpace="GroupedRepeater.Controls"%>
--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
      function synHeader() {
          var valtable, headtable, cols, width1;
          valtable = window.document.getElementById("tbsamplevalue");
          headtable = window.document.getElementById("tbsampleHeader");
          if (valtable != null && headtable != null) {
              cols = valtable.rows[0].cells.length - 1;
              for (index = 0; index < cols; index++) {
                  width1 = valtable.getElementsByTagName("tr").item(0).childNodes.item(index).clientWidth;
                  headtable.getElementsByTagName("tr").item(0).childNodes.item(index).style.setExpression("width", width1);
              }
          }
      }  
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <%--<asp:Repeater ID="Myrptr" runat="server" >
        <HeaderTemplate>  
<table>  
<tr id="tbsampleHeader">  
<th>  
<asp:Label ID="Label14" Text="Login" runat="server"></asp:Label>  
</th>  
<th>  
<asp:Label ID="Label1" Text="First Name" runat="server"></asp:Label>  
</th>  
<th>  
<asp:Label ID="Label2" Text="Last Name" runat="server"></asp:Label>  
</th>  
<th>  
<asp:Label ID="Label3" Text="Date Added" runat="server"></asp:Label>  
</th>  
<th>  
<asp:Label ID="Label6" Text="Delete" runat="server"></asp:Label>  
</th>  
</tr>  
</HeaderTemplate>  
<ItemTemplate>  
<tr>  
<td>  

<asp:Label ID="Label6" Text='<%# Eval("E_b_ref") %>' runat="server"></asp:Label>  

</td>  
<td>  
 
<asp:Label ID="Label4" Text='<%# Eval("cat") %>' runat="server"></asp:Label>
</td>  
<td>  

<asp:Label ID="Label5" Text='<%# Eval("B_Z") %>' runat="server"></asp:Label>
</td>  
<td>  
 
<asp:Label ID="Label7" Text='<%# Eval("F_lvl") %>' runat="server"></asp:Label>
</td>
<td>  
 
<asp:Label ID="Label8" Text='<%# Eval("Sq_No") %>' runat="server"></asp:Label>

</tr>  
</ItemTemplate>  
<FooterTemplate>  
</table>  
</FooterTemplate> 

</asp:Repeater>--%>  
<%--<cc1:GroupingRepeater id="countries" runat="server">
				<GroupTemplate>
					<H2><%# ((string)DataBinder.Eval(Container.DataItem, "name")).Substring(0,1) %></H2>
				</GroupTemplate>
				<ItemTemplate>
					- <%# DataBinder.Eval(Container.DataItem, "name") %><BR>
				</ItemTemplate>
			</cc1:GroupingRepeater>--%>
        <cc1:GroupingRepeater ID="groupingRepeater" runat="server">
        <%--<HeaderTemplate>
				<table border="1">
					<tr>
						<td>Customer Name</td>
						<td>Order History</td>
						<td>Comments</td>
						<td></td>
						<td></td>
					</tr>
			</HeaderTemplate>--%>
		     
			<%--<ItemTemplate>
			<tr>
				<td>
					<asp:Label ID="Label6" Text='<%# Eval("E_b_ref") %>' runat="server"></asp:Label>  
				</td>
				<td>  
 
<asp:Label ID="Label4" Text='<%# Eval("cat") %>' runat="server"></asp:Label>
</td>  
<td>  

<asp:Label ID="Label5" Text='<%# Eval("B_Z") %>' runat="server"></asp:Label>
</td>  
<td>  
 
<asp:Label ID="Label7" Text='<%# Eval("F_lvl") %>' runat="server"></asp:Label>
</td>
<td>  
 
<asp:Label ID="Label8" Text='<%# Eval("Sq_No") %>' runat="server"></asp:Label>
</td>
			</tr>
			</ItemTemplate>--%>
		       
			<%--<GroupTemplate>
				<div>
					<%# DataBinder.Eval(Container.DataItem, "Sys_name")%> 
				</div>
			</GroupTemplate>
			<GroupIdentifier Index="-1" Key="ItemTemplate" field="E_b_ref" />
			<GroupIdentifier Index="0" Key="OrderHistory" field="Sys_name" />--%>
			<HeaderTemplate>
				<table border="0">
					<tr>
						<td>Customer Name</td>
						<td>Order History</td>
						<td>Comments</td>
					</tr>
			</HeaderTemplate>
		     
			<ItemTemplate>
			<tr>
				<td>
					<%# DataBinder.Eval(Container.DataItem, "CustomerName") %>
				</td>
				<td>
					<%# ((GroupingRepeater)Container.Parent).GroupData("OrderHistory")%>
				</td>
				<td>
					<%# ((GroupingRepeater)Container.Parent).GroupData("Comments") %>
				</td>
			</tr>
			</ItemTemplate>
		       
			<GroupTemplate>
				<div>
					<%# DataBinder.Eval(Container.DataItem, "OrderDate") %> - 
					<%# DataBinder.Eval(Container.DataItem, "OrderID") %>: 
					$<%# DataBinder.Eval(Container.DataItem, "OrderAmount") %>
				</div>
			</GroupTemplate>
			<GroupTemplate>
				<div>Posted by
					<%# DataBinder.Eval(Container.DataItem, "EmployeeName") %> on 
					<%# DataBinder.Eval(Container.DataItem, "CommentPostedDate") %>: 
					<%# DataBinder.Eval(Container.DataItem, "Comment") %>
				</div>
			</GroupTemplate>

			<GroupIdentifier Index="-1" Key="ItemTemplate" Field="CustomerID" />
			<GroupIdentifier Index="0" Key="OrderHistory" Field="OrderID" />
			<GroupIdentifier Index="1" Key="Comments" Field="CommentID" />

			<SeparatorTemplate><tr><td colspan="3"> </td></tr></SeparatorTemplate>
			<SeparatorTemplate><hr></SeparatorTemplate>
		     
			<SeparatorIdentifier Index="0" Key="ItemTemplate" />
			<SeparatorIdentifier Index="1" Key="Comments" />
			<FooterTemplate></table></FooterTemplate>
        </cc1:GroupingRepeater>
      
        
    </div>
    </form>
</body>
</html>
