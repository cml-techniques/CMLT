<!-- AspUpload .NET Code samples: UploadScript1.aspx -->
<!-- Invoked by Form1.aspx -->
<!-- Copyright (c) 2002 Persits Software, Inc. -->
<!-- http://www.persits.com -->

<%@ Page aspCompat="True" %>

<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Import Namespace="ASPUPLOADLib" %>



<script runat="server" LANGUAGE="C#">

void Page_Load(Object Source, EventArgs E)
{
	ASPUPLOADLib.IUploadManager objUpload;
	objUpload = new ASPUPLOADLib.UploadManager();

	int Count = objUpload.Save("c:\\upload", Missing.Value, Missing.Value);

	txtResult.InnerHtml = "Success. " + Count + " file(s) uploaded to c:\\upload.";
}

</script>

<html>
<body>

<div id="txtResult" runat="server"/>

</body>
</html>
