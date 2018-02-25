<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cmstree.aspx.cs" Inherits="CmlTechniques.CMS.cmstree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script type="text/javascript">

        function pageLoad() {
        }
    
    </script>

    <link href="../page.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Menu/styles.css" />

    <script type="text/javascript">
        function callcms(_id, type) {      
            if (type == "0") {
                parent.document.getElementById("content").src = "cassheet_master.aspx?id=" + _id;
            }
            else if (type == "1") {
                parent.document.getElementById("content").src = "cmsdoclist.aspx?id=" + _id;
            }
            else if (type == "sub") {
                parent.document.getElementById("content").src = "cmsdocreview_details.aspx";
            }
            else if (type == "3") {
             if (_id == "NBO") {
             parent.document.getElementById("content").src = "cmsdocreview1.aspx?PRJ=" + _id;
           }
           else
           {
                var uid = document.getElementById("lblid");
                parent.document.getElementById("content").src = "cmsdocreview.aspx?PRJ=" + _id + "&ID=" + uid.textContent+"&ACN=0";
            }
            }
            else if (type == "4") {
                parent.document.getElementById("content").src = "methodstatements.aspx?id=" + _id;

            }
            else if (type == "5") {
                location.replace("docview.aspx?" + _id);

            }
            else if (type == "6") {
                parent.document.getElementById("content").src = "../cmsminutes.aspx?id=" + _id;

            }
            else if (type == "7") {
                parent.document.getElementById("content").src = "../cmsprogrammes.aspx?id=" + _id;

            }
            else if (type == "28") {
                parent.document.getElementById("content").src = "Dashboard1.aspx?id=" + _id;

            }
            else if (type == "8") {
                if (_id == "Trial" || _id == "ASAO") {
                    parent.document.getElementById("content").src = "siteObservation.aspx?PRJ=" + _id;
                }
                else {
                    parent.document.getElementById("content").src = "so.aspx?PRJ=" + _id+"&ACN=0";
                }

            }
            else if (type == "9") {
                location.replace("../programview.aspx");

            }
            else if (type == "10") {
                parent.document.getElementById("content").src = _id;

            }
            else if (type == "11") {
                parent.document.getElementById("content").src = "ms_schedule.aspx";

            }
            else if (type == "12") {
                parent.document.getElementById("content").src = "caslvreport.aspx";
            }
            else if (type == "13") {
                parent.document.getElementById("content").src = "../tcdocumentation.aspx?id=" + _id;
            }
            else if (type == "14") {
                parent.document.getElementById("content").src = "mech_ahu.aspx?id=" + _id;
            }
            else if (type == "15") {
                parent.document.getElementById("content").src = "cmstraining.aspx?id=" + _id;
            }
            else if (type == "16") {
                parent.document.getElementById("content").src = "Reports.aspx?id=" + _id;
            }
            else if (type == "17") {
                //parent.document.getElementById("content").src = "graph.aspx?id=" + _id;
                parent.document.getElementById("content").src = "Summary.aspx?id=1" + _id;
            }
            else if (type == "18") {
                //parent.document.getElementById("content").src = "graph.aspx?id=" + _id;
                parent.document.getElementById("content").src = "Service_Summary.aspx?id=" + _id;
            }
            else if (type == "19") {
                //parent.document.getElementById("content").src = "graph.aspx?id=" + _id;
                parent.document.getElementById("content").src = "Doc_Summary.aspx?id=" + _id;
            }
            else if (type == "20") {
                //parent.document.getElementById("content").src = "graph.aspx?id=" + _id;
                parent.document.getElementById("content").src = "ms_schedule.aspx";
            }
            else if (type == "21") {
                parent.document.getElementById("content").src = "../cmsdocreviewadd.aspx?PRJ=" + _id;
            }
            else if (type == "22") {
                //parent.document.getElementById("content").src = "cmsmemo.aspx?id=" + _id;
                 parent.document.getElementById("content").src = "methodstatements1.aspx?id=" + _id;
            }
            else if (type == "23") {
                parent.document.getElementById("content").src = "cmsletters.aspx?id=" + _id;
            }
            else if (type == "24") {
                parent.document.getElementById("content").src = "cmswircmlcmnts.aspx?id=" + _id;
            }
            else if (type == "25") {
                //parent.document.getElementById("content").src = "graph.aspx?id=" + _id;
                parent.document.getElementById("content").src = "Cas_SummaryAll.aspx?id=" + _id;
            }
            else if (type == "26") {
                //parent.document.getElementById("content").src = "graph.aspx?id=" + _id;
                parent.document.getElementById("content").src = "../CAS/Cassheet_Summary.aspx?id=" + _id;
            }
            else if (type == "27") {
                //parent.document.getElementById("content").src = "graph.aspx?id=" + _id;
                parent.document.getElementById("content").src = "cxissue_master.aspx?id=" + _id;
            }
            else if (type == "28") {
                parent.document.getElementById("content").src = "MechReview.aspx?id=" + _id;
            }
            else if (type == "29") {
                parent.document.getElementById("content").src = "CXIR_Schedule.aspx?id=" + _id;
            }
            else if (type == "30") {
                parent.document.getElementById("content").src = "TestpackHome.aspx?id=" + _id;
            }
            else if (type == "31") {
                parent.document.getElementById("content").src = "../CAS/SystemsList.aspx?PRJ=" + _id;
            }
            else if (type == "32") {
                parent.document.getElementById("content").src = _id;
            }
            else if (type == "33") {
                parent.document.getElementById("content").src = "MonthlyReports.aspx?id=" + _id;
            }
            else if (type == "34") {
                parent.document.getElementById("content").src = "cmsdocreview1.aspx?PRJ=" + _id;
            }
        }
     
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="lblid" runat="server" Text="" Style="display: none"></asp:Label>
    <asp:Label ID="lbluser" runat="server" Text="" Style="display: none"></asp:Label>
    <div id="navigation-block">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:TreeView ID="mytree" name="mytree" runat="server" ExpandDepth="5" ForeColor="#FFFFFF"
                    NodeWrap="True" Width="190px" EnableTheming="false" EnableClientScript="true"
                    ShowExpandCollapse="true" Font-Names="Verdana" Font-Size="7.5pt" NodeStyle-NodeSpacing="2px">
                    <ParentNodeStyle ImageUrl="~/images/folder.gif" />
                    <HoverNodeStyle ForeColor="#FF6600" />
                    <RootNodeStyle ImageUrl="~/images/folder.gif" />
                    <NodeStyle NodeSpacing="2px" />
                    <LeafNodeStyle ImageUrl="~/images/folder.gif" />
                </asp:TreeView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
