<%@ Page Language="C#" MasterPageFile="~/Demo.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_DefaultPage" %>
<%@ Register Assembly="DevExpress.Web.v7.2" Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dxdv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phOnceContent" Runat="Server">
    <div class="RootPage">
        <div class="Slogan">Build Your Best<br /><span class="MiniSlogan">Without Limits or Compromise</span></div>
        <asp:Image ID="Image1" CssClass="MainBanner" ImageAlign="Right" runat="server" EnableViewState="False" Width="453px" Height="235px" ImageUrl="~/Images/Design/Main.png" GenerateEmptyAlternateText="True" OnLoad="Image1_Load" />
        <br class="Clear" />
        <asp:Literal ID="lGeneralTerms" EnableViewState="False" runat="server" />
        <br /><br /><br />
        <dxdv:ASPxDataView EnableDefaultAppearance="False" ID="ASPxDataView1" runat="server" DataSourceID="XmlDataSource1" Width="100%" CssClass="Features" ColumnCount="2" ItemSpacing="43px" SkinID="None" RowPerPage="100">
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="0" width="100%"><tr>
                    <td valign="top" runat="server" id="td1" EnableViewState="False" Visible='<%# IsImageVisible(Eval("Visible")) %>'><asp:Image ID="Image2" runat="server" EnableViewState="False" Width="73px" Height="82px" ImageUrl='<%# Eval("ImageUrl") %>' OnLoad="Image2_Load" GenerateEmptyAlternateText="True" /></td>
                    <td runat="server" id="td2" EnableViewState="False" Visible='<%# IsImageVisible(Eval("Visible")) %>'><div class="Spacer" style="width: 8px;"></div></td>
                    <td valign="top" style="width: 100%;"><b><asp:Label EnableViewState="False" ID="Label1" runat="server" Text='<%# Eval("Title") %>' /></b><asp:Label EnableViewState="False" ID="Label2" runat="server" Text='<%# Eval("Text") %>' /></td>
                </tr></table>
            </ItemTemplate>
            <PagerSettings Visible="False">
            </PagerSettings>
            <ItemStyle Width="50%" />
        </dxdv:ASPxDataView>       
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/MainFeatures.xml" XPath="//Item" />
        <br /><br />
        <asp:Panel ID="pDescription" EnableViewState="False" runat="server" />
    </div>
</asp:Content>
