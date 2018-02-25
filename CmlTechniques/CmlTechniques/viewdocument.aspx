<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewdocument.aspx.cs" Inherits="CmlTechniques.viewdocument" Debug="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CML Interactive</title>
    <style type="text/css">
    body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;  	
    }
        </style>  
    <script type="text/javascript">

        function pageLoad() {
        }
    
    </script>
    <script type="text/javascript">
  function disableContextMenu()
  {
      window.frames["myframe"].document.oncontextmenu = function() { alert("No way!"); return false; };   
    // Or use this
    // document.getElementById("fraDisabled").contentWindow.document.oncontextmenu = function(){alert("No way!"); return false;};;    
  }  

    </script>
    <style>
    @media print
  {
     .hide
     {
     	display:none;
     }
  }
    </style>

</head>

<body  >
    <form id="form1" runat="server">
    <div >
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
        <table style="width: 100%; height: 100%; position: fixed" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="100%" width="100%" valign="top"  >
                <iframe id="myframe" height="100%" width="100%" frameborder="0" runat="server"  ></iframe>
                    &nbsp;</td>
            </tr>
        </table>
        
        
       
        </div>
    </form>
</body>

</html>
