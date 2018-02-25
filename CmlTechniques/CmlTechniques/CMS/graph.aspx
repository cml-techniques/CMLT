<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="graph.aspx.cs" Inherits="CmlTechniques.CMS.graph" ValidateRequest="false"  %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
        <link media="all" href="../samples.css" type="text/css" rel="stylesheet" />

</head>
<script language="javascript" type="text/javascript">
    function CallPrint(strid) {

        var headstr = "<html><head><title>CML Techniques Reports</title></head><body>";

        var footstr = "</body></html>"

        var WinPrint = window.open('', '', 'left=150,top=150,width=1024,height=600,menubar=1,toolbar=0,scrollbars=1,status=0');

        WinPrint.document.write(headstr + strid.innerHTML + footstr);

        WinPrint.document.close();

        WinPrint.focus();

        WinPrint.print();
    }
    function getInnerHtml() {
        var element = document.getElementById("forPrint");
        var store = document.getElementById("hdnInnerHtml");
        //add the css styles you have used inside the nested GridView
        //var css = "<style type=\"text/css\" id=\"style1\">.textbold {font-family: Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;font-weight: bold;text-decoration: none;}.row1 {background-color: #FFFFFF; font-family: Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;height: 18px;padding-left: 5px;}.";
        store.value = element.innerHTML;
    }



    
    </script>

<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
         <asp:Button ID="print" runat="server" Text="Print" 
                    OnClientClick="CallPrint(forPrint);" Font-Names="Verdana" Font-Size="XX-Small" 
                    ForeColor="Red" /></ContentTemplate></asp:UpdatePanel>
    </div>
    <div id="forPrint">
        
						
<asp:chart id="Chart4" runat="server" BorderColor="26, 59, 105" BorderWidth="2" BackGradientStyle="TopBottom" BackSecondaryColor="White" palette="Pastel" BorderDashStyle="Solid" BackColor="WhiteSmoke" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="900px" Height="400px">
							<titles>
							<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="" Alignment="TopLeft" ForeColor="26, 59, 105" Name="t1" ></asp:title>
							</titles>
							<legends>
								<asp:legend LegendStyle="Row" Enabled="False" Name="Default" BackColor="Transparent">
									<position y="85" height="5" width="40" x="5"></position>
								</asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series >
								<asp:series ChartArea="ChartArea1" XValueType="Double" Name="Series2" CustomProperties="DrawingStyle=Cylinder" ShadowColor="Transparent" BorderColor="180, 26, 59, 105" Color="65, 140, 240" Legend="Legend2" YValueType="Double"   >
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="Transparent" ShadowColor="Transparent" >
									<area3dstyle pointgapdepth="0" Rotation="5" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"  ></area3dstyle>
									<position y="13" height="75" width="90" x="2"></position>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="false" Interval="20" Maximum="100"  >
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold"  />
										<majorgrid linecolor="64, 64, 64, 64"  />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="true" interval="1" >
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold"  />
										<majorgrid linecolor="64, 64, 64, 64"  />
									</axisx>
								</asp:chartarea>
								
							</chartareas>
						</asp:chart>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:dbCMLConnectionString %>" 
            SelectCommand="Ele_Cas_Summary" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="Project_code" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
