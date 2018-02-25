﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CasDataEntry_New.aspx.cs" Inherits="CmlTechniques.CasDataEntry_New" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="page.css" rel="stylesheet" type="text/css" />
     <%--<link rel="stylesheet" id="shortcodescss" href="CMLT/Styles/accordin.css" type="text/css" media="all" />--%>
     <link rel="stylesheet" href="Accordion/fonts/font-awesome.css" type="text/css" />
     <link rel="stylesheet" href="Accordion/jquery.accordion.css" type="text/css" />
      <link rel="stylesheet" href="Acordion1/demo.css" type="text/css" />
     <script type="text/javascript">
function validate(id){
    var remember = document.getElementById(id);
    if (remember.checked){
        alert("checked") ;
    }else{
        alert("You didn't check it! Let me check it for you.")
    }
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: verdana; font-size: x-small;height:100%;position:fixed;width:100%">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:Label ID="lblsch" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lbluid" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label>
        <table style="width:100%;color:White" bgcolor="#092443">
        <tr>
        <td width="100px" colspan="5" style="background-color: #D2F1FC" >
            <asp:Label ID="lblhead" runat="server" Font-Bold="True" Font-Size="Small" 
                ForeColor="Black"></asp:Label>
            </td>
        </tr>
        <tr>
        <td width="100px" >
            <asp:Label ID="Label1" runat="server" Text="Select Package" Width="100px"></asp:Label>
            </td>
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
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnimport" runat="server" Text="Import From Excel" 
                                            onclick="btnimport_Click" CssClass="hidden"   />
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                    <ContentTemplate>
                                        <asp:ImageButton ID="btnrefresh" runat="server" 
                                            ImageUrl="~/images/refresh1.png" onclick="btnrefresh_Click"  CssClass="hidden" />
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
        <td width="100%" align="right" >
        <table>
        <tr>
        <td style="width:100px" align="center"> &nbsp;</td>
        <td style="width:200px">
            <asp:UpdatePanel ID="UpdatePanel21" runat="server">
            <ContentTemplate>
             <asp:TextBox ID="txtsearch" runat="server" Width="200px"></asp:TextBox>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td>
        <asp:UpdatePanel ID="UpdatePanel20" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnsearch" runat="server" Text="Search" Width="75px" 
                    onclick="btnsearch_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel25" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnaddm" runat="server" Text="Add-M" Width="75px" 
                    onclick="btnaddm_Click"/>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel18" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnedit" runat="server" Text="Edit" onclick="btnedit_Click" Width="75px" />
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
            <ContentTemplate>
            <asp:Button ID="btndelete1" runat="server" Text="Delete" Width="75px" 
                    onclick="btndelete1_Click" />
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
       <tr  style="background-image: url('images/head_bg.png'); background-repeat: repeat-x;">
       
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
                        <tr style="background-image: url('images/head_bg.png'); background-repeat: repeat-x;">
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
                <asp:Button ID="btnadd" runat="server" Text="add" onclick="btnadd_Click" 
                                                    Width="94%" />
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
                                            AutoPostBack="true" onselectedindexchanged="drflevel__SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="width:30%">
                                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnnewflevel" runat="server" Text=".." Width="100%" 
                                            onclick="btnnewflevel_Click" />
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
             
                 <%--<asp:UpdatePanel ID="UpdatePanel16" runat="server">
                 <ContentTemplate>
                 <asp:Button ID="btnexpand" runat="server" Text="Exp.All" Width="94%"
                         onclick="btnexpand_Click" ForeColor="Red" Font-Size="X-Small" style="cursor:pointer" />
                 </ContentTemplate>
                 </asp:UpdatePanel>--%>
                <a title="Open All" id="openAll" href="#">Expand All</a>
             </td>
            <td>
              <%--<asp:UpdatePanel ID="UpdatePanel17" runat="server">
                 <ContentTemplate>
                 <asp:Button ID="btncollapse" runat="server" Text="Coll.All" Width="94%" 
                         ForeColor="Red" Font-Size="X-Small" style="cursor:pointer" 
                         onclick="btncollapse_Click" />
                 </ContentTemplate>
                 </asp:UpdatePanel></td>--%>
                 <a title="Close all" id="closeAll" href="#">Collapse All</a>
            <td>
                &nbsp;</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drbuilding" runat="server" Width="100%" OnSelectedIndexChanged="drbuilding_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                 
            </td>
            <td>
           <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drcategory" runat="server" Width="100%" OnSelectedIndexChanged="drcategory_SelectedIndexChanged" AutoPostBack="true" >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
               </td>
            <td>
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drflevel" runat="server" Width="100%" OnSelectedIndexChanged="drflevel_SelectedIndexChanged" AutoPostBack="true"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td>
                &nbsp;</td>
            <td id="tddes" runat="server">
            <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drdes" runat="server" Width="100%" AutoPostBack="true" 
                        onselectedindexchanged="drdes_SelectedIndexChanged"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
            <td id="td0" runat="server">
            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drloc" runat="server" Width="100%" AutoPostBack="true" 
                        onselectedindexchanged="drloc_SelectedIndexChanged"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
            <td id="td_1" runat="server">
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drfed" runat="server" Width="100%" OnSelectedIndexChanged="drfed_SelectedIndexChanged" AutoPostBack="true"  >
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
            <%--<div id="accordion1" style="width:100%">--%>
                <asp:PlaceHolder ID="ph_cas" runat="server"></asp:PlaceHolder>
           <%-- </div>--%>
            </ContentTemplate>
            </asp:UpdatePanel>
            
             
        </div>
        <%--<div id="myprogress" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="images/loading.gif" Height="200px" Width="250px" />
            </ProgressTemplate>
       </asp:UpdateProgress>
        </div>--%>
        <asp:Panel ID="pnlPopup" runat="server" Width="400px" style="padding:15px;background-color:#83C8EE;display:none" >
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
                  BackgroundCssClass="modal">
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
                  BackgroundCssClass="modal">
                  </asp:ModalPopupExtender>           
    </div>
    
    <SCRIPT src="Acordion1/jquery.min.js" type="text/javascript"></SCRIPT>
 
<SCRIPT src="Acordion1/highlight.pack.js" type="text/javascript"></SCRIPT>
 
<SCRIPT src="Acordion1/jquery.cookie.js" type="text/javascript"></SCRIPT>
 
<%--<SCRIPT src="Acordion1/jquery.accordion.js" type="text/javascript"></SCRIPT>--%>
 <script type="text/javascript" src="Acordion1/jquery.collapsible.js"></script>
<script type="text/javascript">

    $(document).ready(function() {

        //syntax highlighter
        hljs.tabReplace = '    ';
        hljs.initHighlightingOnLoad();

        $.fn.slideFadeToggle = function(speed, easing, callback) {
            return this.animate({ opacity: 'toggle', height: 'toggle' }, speed, easing, callback);
        };

        //collapsible management
        $('.collapsible').collapsible({
            defaultOpen: 'section1',
            cookieName: 'nav',
            speed: 'slow',
            animateOpen: function(elem, opts) { //replace the standard slideUp with custom function
                elem.next().slideFadeToggle(opts.speed);
            },
            animateClose: function(elem, opts) { //replace the standard slideDown with custom function
                elem.next().slideFadeToggle(opts.speed);
            },
            loadOpen: function(elem) { //replace the standard open state with custom function
                elem.next().show();
            },
            loadClose: function(elem, opts) { //replace the close state with custom function
                elem.next().hide();
            }
        });
        $('.page_collapsible').collapsible({
            defaultOpen: 'body_section1',
            cookieName: 'body2',
            speed: 'slow',
            animateOpen: function(elem, opts) { //replace the standard slideUp with custom function
                elem.next().slideFadeToggle(opts.speed);
            },
            animateClose: function(elem, opts) { //replace the standard slideDown with custom function
                elem.next().slideFadeToggle(opts.speed);
            },
            loadOpen: function(elem) { //replace the standard open state with custom function
                elem.next().show();
            },
            loadClose: function(elem, opts) { //replace the close state with custom function
                elem.next().hide();
            }

        });

        //assign open/close all to functions
        function openAll() {
            $('.collapsible').collapsible('openAll');
        }
        function closeAll() {
            $('.collapsible').collapsible('closeAll');
        }

        //listen for close/open all
        $('#closeAll').click(function(event) {
            event.preventDefault();
            closeAll();

        });
        $('#openAll').click(function(event) {
            event.preventDefault();
            openAll();
        });

    });
</SCRIPT>
    </form>
</body>
</html>
