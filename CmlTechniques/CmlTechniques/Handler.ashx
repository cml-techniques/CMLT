<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;

public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.Clear();
        //context.Response.Charset = "";
        context.Response.ContentType = "text/calendar";
        context.Response.AddHeader("Content-Disposition", "inline; filename=\\Calender.ics");
        context.Response.BinaryWrite(new System.Text.ASCIIEncoding().GetBytes(@"BEGIN:VCALENDAR
PRODID:-//Microsoft Corporation//Outlook 12.0 MIMEDIR//EN
VERSION:1.0
BEGIN:VEVENT
DTSTART:20120515T110000Z
DTEND:20120515T113000Z
LOCATION:office
UID:040000008200E00074C5B7101A82E00800000000E09778CC8A2FCD01000000000000000
	010000000A616AC829938554DA102762D344287C7
DESCRIPTION;ENCODING=QUOTED-PRINTABLE:=
=0D=0A
SUMMARY:calander
PRIORITY:3
END:VEVENT
END:VCALENDAR"));
        //Response.Write(); 
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}