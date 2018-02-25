<!-- AspUpload .NET Code samples: UploadScript3.aspx -->
<!-- Invoked by Form4.aspx -->
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

	// Text item
	txtFormText.InnerHtml = objUpload.Form.Item("Form_Text").Value;

	// Check box
	txtFormCheck.InnerHtml = objUpload.Form.Item("Form_Check").Value == "on" ? "checked" : "unchecked";

	// Select box
	// This is very important as Upload.Form is not entirely 
	// identical to Request.Form in handling multi-select items.
	// Upload.Form creates a separate item for every selection.
	// To obtain all selected items we have to scroll through
	// the entire Upload.Form collection and filter out selected items.
	foreach( ASPUPLOADLib.IFormItem objItem in objUpload.Form )
	{
		if( objItem.Name == "FORM_SELECT" )
		{
			txtFormSelect.InnerHtml += objItem.Value + "<BR>";
		}
	}

	// Radio button
	txtFormRadio.InnerHtml = objUpload.Form.Item("Form_Radio").Value;

	// File item
	if( objUpload.Files.Item("Form_file") == null )
		txtFormFile.InnerHtml = "File not selected.";
	else
		txtFormFile.InnerHtml = objUpload.Files.Item("Form_file").Path;

}

</script>


<HTML>
<BODY BGCOLOR="#FFFFFF">

<h3>Upload Results</H3>
<TABLE CELLSPACING=0 CELLPADDING=2 BORDER=1>
<TR><TH>Form Item</TH><TH>Value(s)</TH></TR>
	<TR>
		<TD>Form_text</TD>
		<TD><div id="txtFormText" runat="server"/>&nbsp;</TD>
	</TR>
	<TR>
		<TD>Form_check</TD>
		<TD><div id="txtFormCheck" runat="server"/></TD>
	</TR>
	<TR>
		<TD>Form_select</TD>
		<TD><div id="txtFormSelect" runat="server"/>&nbsp;</TD>
	</TR>
	<TR>
		<TD>Form_radio</TD>
		<TD><div id="txtFormRadio" runat="server"/>&nbsp;</TD>
	</TR>
	<TR>
		<TD>Form_file</TD>
		<TD><div id="txtFormFile" runat="server"/></TD>
	</TR>
</TABLE>

</BODY>
</HTML>
