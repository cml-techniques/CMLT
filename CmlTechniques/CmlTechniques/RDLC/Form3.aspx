<!-- AspUpload .NET Code samples: Form3.aspx -->
<!-- Accessing Various Form Items -->
<!-- Copyright (c) 2002 Persits Software, Inc. -->
<!-- http://www.persits.com -->

<HTML>
<BODY BGCOLOR="#FFFFFF">

<h3>Using Upload.Form to Access Various Form Items</h3>

	<FORM METHOD="POST" ENCTYPE="multipart/form-data" ACTION="UploadScript3.aspx">

		<TABLE BORDER=1 CELLSPACING=0 CELLPADDING=2>
		<TR>
			<TD>&lt;INPUT TYPE="TEXT" NAME="Form_text"&gt;</TD>
			<TD><INPUT TYPE="TEXT" NAME="FORM_TEXT"></TD>
		</TR>
		<TR>
			<TD>&lt;INPUT TYPE="CHECKBOX" NAME="Form_check"&gt;</TD>
			<TD><INPUT TYPE="CHECKBOX" NAME="FORM_CHECK"></TD>
		</TR>
		<TR>
			<TD>&lt;SELECT NAME="FORM_SELECT" MULTIPLE"&gt;<BR>...<BR>&lt;/SELECT&gt;</TD>
			<TD><SELECT NAME="FORM_SELECT" MULTIPLE>
				<OPTION>Select 1
				<OPTION>Select 2
				<OPTION>Select 3
				</SELECT>
			</TD>
		</TR>
		<TR>
			<TD>&lt;INPUT TYPE="RADIO" NAME="FORM_RADIO" VALUE="Radio1"&gt;<BR>
			&lt;INPUT TYPE="RADIO" NAME="FORM_RADIO" VALUE="Radio2"&gt;</TD>
			<TD><INPUT TYPE="RADIO" NAME="FORM_RADIO" VALUE="Radio1">Radio 1<BR>
				<INPUT TYPE="RADIO" NAME="FORM_RADIO" VALUE="Radio2">Radio 2
			</TD>
		</TR>
		<TR>
			<TD>&lt;INPUT TYPE="FILE" NAME="Form_file"&gt;</TD>
			<TD><INPUT TYPE="FILE" NAME="FORM_FILE"></TD>
		</TR>
		<TR>
			<TD>&lt;INPUT TYPE="SUBMIT" VALUE="Upload!"&gt;</TD>
			<TD><INPUT TYPE="SUBMIT" VALUE="Upload!"></TD>
		</TR>


		</TABLE>
	</FORM>

</BODY>
</HTML>