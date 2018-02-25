<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uploadtest.aspx.cs" Inherits="CmlTechniques.uploadtest" AspCompat="true" %>
<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Import Namespace="ASPUPLOADLib" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <META content="text/html; charset=windows-1252" http-equiv=Content-Type>
<STYLE type=text/css>.submitLink {
	BORDER-BOTTOM: medium none; BORDER-LEFT: medium none; BACKGROUND-COLOR: transparent; WIDTH: 200px; COLOR: #00f; BORDER-TOP: medium none; CURSOR: hand; BORDER-RIGHT: medium none; TEXT-DECORATION: underline
}
</STYLE>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <SCRIPT language="VBScript">
Function CheckDB(xFilename,xIndex)
If xFilename = "Grundfos – CHW Pumps Warranties.pdf" then 
CheckDB = 1
ElseIf xFilename = "Grundfos CHV4-100 – Pres Pumps Warranty.pdf" then 
CheckDB = 1
ElseIf xFilename = "Hattersley Valves.pdf" then 
CheckDB = 1
ElseIf xFilename = "Honeywell Valve.pdf" then 
CheckDB = 1
ElseIf xFilename = "Homersham Float Switch.pdf" then 
CheckDB = 1
ElseIf xFilename = "Pegler Gate Valves.pdf" then 
CheckDB = 1
ElseIf xFilename = "Telemecanique Pressure Switches.pdf" then 
CheckDB = 1
ElseIf xFilename = "Wika Tube Pressure Gauge.pdf" then 
CheckDB = 1
ElseIf xFilename = "York Valves.pdf" then 
CheckDB = 1
ElseIf xFilename = "Checkpoint - Electric Metering Pumps.pdf" then 
CheckDB = 1
ElseIf xFilename = "Cimberio Pressure Reducing Valve.pdf" then 
CheckDB = 1
ElseIf xFilename = "CHW Chemical Injection-Dosing Pump Controller.pdf" then 
CheckDB = 1
ElseIf xFilename = "FlowconSM-Pressure Independent Control Valves.pdf" then 
CheckDB = 1
ElseIf xFilename = "Funke Plate Heat Exchangers.pdf" then 
CheckDB = 1
ElseIf xFilename = "Global Water Solutions Pressure Vessel.pdf" then 
CheckDB = 1
ElseIf xFilename = "Grundfos – HS – CHW Pumps.pdf" then 
CheckDB = 1
ElseIf xFilename = "Grundfos – NB40-125-139 – CHW Pumps.pdf" then 
CheckDB = 1
ElseIf xFilename = "Grundfos – TPED(0.37-7.5 kW) – CHW Pumps.pdf" then 
CheckDB = 1
ElseIf xFilename = "Grundfos – TPED(11-22 kW) – CHW Pumps.pdf" then 
CheckDB = 1
ElseIf xFilename = "Grundfos CHV4-100 – Pressurisation Pumps.pdf" then 
CheckDB = 1
ElseIf xFilename = "Grundfos CH4 20 and 40-Pressurisation Pumps.pdf" then 
CheckDB = 1
Exit Function 
Else MsgBox xFilename & " is not listed in the current Manufacturer Information schedule for this package.  Document cannot be uploaded."
CheckDB = 0
Exit Function 
End if 
End Function 
Sub Select_OnClick
dim strLength1  
dim strLength2  
dim strFilename  
dim strIndex  
dim strResult  
dim strDelCounter  
dim strRealIndex  
UploadCtl.Select  

strDelCounter=-1 
For Each File in UploadCtl.SelectedFiles  
strLength = Len(File.Path)- InStrRev(File.Path,"\")  
strFilename = Right(File.Path,strLength)  
strIndex = (File.Index)  
strResult = CheckDB(strFilename,strIndex)
If strResult=0 then 
strDelCounter=strDelCounter+1 
strRealIndex=(strIndex-strDelCounter) 
UploadCtl.Remove strRealIndex
End If
Next 
End Sub 
</SCRIPT>

            <SCRIPT language=VBScript>

Sub Remove_OnClick
  UploadCtl.RemoveHighlighted
End Sub

Sub RemoveAll_OnClick
  UploadCtl.RemoveAll
End Sub

Sub Upload_OnClick
  UploadCtl.Upload
End Sub
</SCRIPT>
   </head> 

<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        
        <OBJECT id="UploadCtl" codeBase="Activex/XUpload.ocx" 
            classid="CLSID:E87F6C8E-16C0-11D3-BEF7-009027438003" width=600 
            height=200><PARAM NAME="SSL" VALUE="True"><PARAM NAME="server" VALUE="www.cmlinteractive.co.uk"><PARAM NAME="script" VALUE="ADMINinteractive/ASPUpload/XUpload/ManLitprogress_upload.asp"><PARAM NAME="EnablePopupMenu" VALUE="False"><PARAM NAME="ViewServerReply" VALUE="False"><PARAM NAME="Redirect" VALUE="True"><PARAM NAME="RedirectURL" VALUE="showreply.asp">
            <!--Do not view reply from server--><!--Redirect browser to a server 
            script upon completion of an upload--></OBJECT>
            <P><INPUT name=SELECT value="Browse Files" type=button> <INPUT name=REMOVE value=Remove type=button> <INPUT name=REMOVEALL value="Remove All" type=button> <INPUT name=UPLOAD value=Upload type=button> <!-- Microsoft workaround for the Click-to-Activate problem -->
            <SCRIPT type=text/javascript 
            src="ie_workaround.js"></SCRIPT>
    </div>
    </form>
</body>
</html>
