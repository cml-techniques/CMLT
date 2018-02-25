<!-- AspUpload .NET Code samples: UploadScript2.aspx -->
<!-- Invoked by Form2.aspx -->
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

	// iterate through Files collection
	foreach( ASPUPLOADLib.IUploadedFile objFile in objUpload.Files )
	{
		txtFiles.InnerHtml += objFile.Name + "= " + objFile.Path + " (" + objFile.Size + " bytes)<BR>";
	}

	// iterate through Form collection
	foreach( ASPUPLOADLib.IFormItem objItem in objUpload.Form )
	{
		txtFormItems.InnerHtml += objItem.Name + "= " + objItem.Value + "<BR>";
	}
}

</script>

<html>
<body>

Files:<BR>
<div id="txtFiles" runat="server"/>

<P>

Form Items:<BR>
<div id="txtFormItems" runat="server"/>

<P>

</body>
</html>