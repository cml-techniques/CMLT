<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FATestUploadsList1.aspx.cs" Inherits="CmlTechniques.CMS.FATestUploadsList1" %>
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
        .btnstyle
        {
            font-size: xx-small;
            cursor: pointer;
            color: Red;
        }
     
    </style>

    <script type="text/javascript">
//        function calldoc(id) {
//            var _prj = document.getElementById("lblprj");
//             var _prm = "prj=" + _prj.textContent + "&doc=" +id + "&mod=FAT";
//            
//            parent.callcms(_prm,'36');
//        }
//    
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:Label ID="lblprj" runat="server" Text="" Style="display: none"></asp:Label>
            <asp:Label ID="lblid" runat="server" Text="" style="display:none"></asp:Label>
    <asp:Label ID="lblmod" runat="server" Text="" style="display:none"></asp:Label>
    <div id="doc_list" >
        
        <div id="thead">
        <div class="titles">
         <asp:Label ID="lblhead" runat="server" Text="Commissioning Report" ></asp:Label>
        </div>
        <div class="btns">
         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                        <asp:Button ID="btnuploadnew" runat="server" Text="Upload New" onclick="btnuploadnew_Click" />
             </ContentTemplate>
             </asp:UpdatePanel>
        </div>

            
        </div>
        
     <div class="dvline"></div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Repeater ID="rpt_latest" runat="server" 
                    OnItemCommand="rpt_latest_ItemCommand" 
                    onitemdatabound="rpt_latest_ItemDataBound">
                    <HeaderTemplate>
                        <table class="tablestyle" width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr class="head">
                                <td style="width: 45%;" align="left">
                                    Document Name
                                </td>
                                <td style="width: 40%" align="left">
                                    File Name
                                </td>
                                <td style="width: 10%" align="center">
                                    Upload Date
                                </td>
                                <td style="width: 5%" align="center" id="tdHistory" runat="server">
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="row">
                             <td style="width: 45%" align="left">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("doc_name")%>'></asp:Label>
                            </td>
                            <td style="width: 40%;" align="left">
                            <asp:LinkButton ID="btnview" runat="server"  Text ='<%# DataBinder.Eval(Container.DataItem, "file_name")%>' CommandName="view"  CommandArgument='<%# Container.ItemIndex %>'  /> 
                             <asp:Label ID="lbldocname" runat="server" Text='<%# Eval("file_name")%>' style="display:none"></asp:Label>
                            </td>
                            <td style="width: 10%" align="center">
                                <%# Eval("upload_date","{0:dd-MM-yyyy}") %>
                            </td>
                            <td style="width: 5%" align="center" id="tdHistory" runat="server">
                                <asp:ImageButton ID="btnbutton" runat="server" ImageUrl="~/images/delete_.png" CommandName="delete1"
                                    CommandArgument='<%# Container.ItemIndex %>' />
                                    <asp:Label ID="lbldocid" runat="server" Text='<%# Eval("doc_id")%>' style="display:none"></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </ContentTemplate>
        </asp:UpdatePanel>
       </div>
    <asp:UpdatePanel ID="UpdatePane5" runat="server">
        <ContentTemplate>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1"
                TargetControlID="lblqns">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel1" runat="server" Style="display: none; width: 200px; background-color: White;
                border-width: 2px; border-color: Black; border-style: solid; padding: 20px;">
                <asp:Label ID="lblqns" Text="" runat="server"></asp:Label>
                <asp:Label ID="lblitmid" Text="0" runat="server" style="display:none"></asp:Label>
                <br />
                <br />
                <asp:Button ID="Button3" runat="server" Text="OK" OnClick="Delete_Click" />
                <asp:Button ID="Button4" runat="server" Text="Cancel" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
