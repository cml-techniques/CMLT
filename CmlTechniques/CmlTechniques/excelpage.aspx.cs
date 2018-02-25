using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CmlTechniques
{
    public partial class excelpage : System.Web.UI.Page
    {
        /// <summary>
        /// Excel Application Class
        /// </summary>
        private Excel.ApplicationClass appOP = null;
        /// <summary>
        /// Static Selected File Name
        /// </summary>
        protected static string m_strFileName = "";



        protected void Page_Load(object sender, EventArgs e)
        {

            if (appOP == null)
            {
                appOP = new Excel.ApplicationClass();
            }
            txtfileValue.EnableViewState = true;
            

        }

        protected override void OnUnload(EventArgs e)
        {
            try
            {
                if (appOP != null)
                {
                    appOP.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(appOP);
                    appOP = null;
                }
            }
            catch (Exception eqq)
            {
                Response.Write(eqq.ToString());
            }
            base.OnUnload(e);
        }

        protected void btnAvailableShtAndChrt_Click(object sender, EventArgs e)
        {

            m_strFileName = txtfileValue.PostedFile.FileName;
            if (m_strFileName == "")
            {
                lblErrText.Text = "File is not Available";
            }
            else
            {
                string strTemp = m_strFileName.Substring(m_strFileName.Length - 3);
                strTemp = strTemp.ToUpper();
                if (strTemp == "XLS")
                {
                    drpShtAndChrt.Items.Clear();
                    GetListofSheetsAndCharts(m_strFileName, true, drpShtAndChrt);
                }
                else
                {
                    lblErrText.Text = "Selected File is not Required Format";
                }
            }

        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {

            if (drpShtAndChrt.SelectedIndex != -1)
            {
                string strSheetorChartName = drpShtAndChrt.SelectedItem.Text;
                // Because "*" cannot be accepted by Sheet Name in Excel
                char[] delimiterChars = { '*' };
                string[] strTemp = strSheetorChartName.Split(delimiterChars);

                if (strTemp[1] == "WorkSheet")
                {
                    DisplayExcelSheet(m_strFileName, strTemp[0], true, lblErrText);
                }
                else if (strTemp[1] == "Chart")
                {
                    DisplayExcelSheet(m_strFileName, strTemp[0], true, lblErrText, true);
                }
            }

        }

        /// <summary>
        /// Fetch all the List of Sheets and Charts
        /// </summary>
        /// <param name="strFileName">Select the xls File Name</param>
        /// <param name="bReadOnly">Specifies how to open it</param>
        public void GetListofSheetsAndCharts(string strFileName, bool bReadOnly, DropDownList drpList)
        {

            Excel.Workbook workbook = null;
            try
            {

                if (!bReadOnly)
                {
                    // Write Mode Open
                    //workbook = appOP.Workbooks.Open(strFileName, 2, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, true, 0, true, 1, 0);
                    // For Optimal Opening 
                    workbook = appOP.Workbooks.Open(strFileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                else
                {
                    // Read Mode Open
                    //workbook = appOP.Workbooks.Open(strFileName, 2, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, true, 0, true, 1, 0);
                    // For Optimal Opening 
                    workbook = appOP.Workbooks.Open(strFileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }

                // Reading of Excel File

                object SheetRChart = null;
                int nTotalWorkSheets = workbook.Sheets.Count;
                int nIndex = 0;
                for (int nWorkSheet = 1; nWorkSheet <= nTotalWorkSheets; nWorkSheet++)
                {
                    SheetRChart = workbook.Sheets[(object)nWorkSheet];
                    if (SheetRChart is Excel.Worksheet)
                    {
                        ListItem lstItemAdd = new ListItem(((Excel.Worksheet)SheetRChart).Name + "*WorkSheet", nIndex.ToString(), true);
                        drpList.Items.Add(lstItemAdd);
                        lstItemAdd = null;
                        nIndex++;
                    }
                    else if (SheetRChart is Excel.Chart)
                    {
                        ListItem lstItemAdd = new ListItem(((Excel.Chart)SheetRChart).Name + "*Chart", nIndex.ToString(), true);
                        drpList.Items.Add(lstItemAdd);
                        lstItemAdd = null;
                        nIndex++;
                    }
                }

                if (workbook != null)
                {
                    if (!bReadOnly)
                    {
                        // Write Mode Close
                        workbook.Save();
                        workbook = null;
                    }
                    else
                    {
                        // Read Mode Close
                        workbook.Close(false, false, Type.Missing);
                        workbook = null;
                    }
                }

            }
            catch (Exception expFile)
            {
                Response.Write(expFile.ToString());
            }
            finally
            {
                if (workbook != null)
                {
                    if (!bReadOnly)
                    {
                        // Write Mode Close
                        workbook.Save();
                        workbook = null;
                    }
                    else
                    {
                        // Read Mode Close
                        workbook.Close(false, false, Type.Missing);
                        workbook = null;
                    }
                }
            }
        }

        /// <summary>
        /// Displaying a given Excel WorkSheet
        /// </summary>
        /// <param name="strFileName">The Filename to be selected</param>
        /// <param name="strSheetRChartName">The Sheet or Chart Name to be Displayed</param>
        /// <param name="bReadOnly">Specifies the File should be open in Read only mode,
        /// If it is true then the File will be open ReadOnly</param>
        /// <param name="lblErrorText">If any Error Occurs should be Displayed</param>
        /// <returns>Returns Boolean Value the Method Succeded</returns>
        public bool DisplayExcelSheet(string strFileName, string strSheetRChartName, bool bReadOnly, Label lblErrorText)
        {
            return DisplayExcelSheet(strFileName, strSheetRChartName, bReadOnly, lblErrText, false);
        }
        /// <summary>
        /// Displaying a given Excel WorkSheet
        /// </summary>
        /// <param name="strFileName">The Filename to be selected</param>
        /// <param name="strSheetRChartName">The Sheet or Chart Name to be Displayed</param>
        /// <param name="bReadOnly">Specifies the File should be open in Read only mode,
        /// If it is true then the File will be open ReadOnly</param>
        /// <param name="lblErrorText">If any Error Occurs should be Displayed</param>
        /// <param name="bIsChart">Specifies whether it is a Chart</param>
        /// <returns>Returns Boolean Value the Method Succeded</returns>
        public bool DisplayExcelSheet(string strFileName, string strSheetRChartName, bool bReadOnly, Label lblErrorText, bool bIsChart)
        {

            appOP.DisplayAlerts = false;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            Excel.Chart chart = null;

            try
            {

                if (!bReadOnly)
                {
                    // Write Mode Open
                    //workbook = appOP.Workbooks.Open(strFileName, 2, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, true, 0, true, 1, 0);
                    // For Optimal Opening 
                    workbook = appOP.Workbooks.Open(strFileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                else
                {
                    // Read Mode Open
                    //workbook = appOP.Workbooks.Open(strFileName, 2, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, true, 0, true, 1, 0);
                    // For Optimal Opening 
                    workbook = appOP.Workbooks.Open(strFileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }



                // Reading of Excel File

                if (bIsChart)
                {
                    chart = (Excel.Chart)workbook.Charts[strSheetRChartName];
                }
                else
                {
                    worksheet = (Excel.Worksheet)workbook.Sheets[strSheetRChartName];
                }

                // Reading the File Information Codes goes Here
                if (bIsChart)
                {
                    if (chart == null)
                    {
                        lblErrorText.Text = strSheetRChartName + " Chart is Not Available";
                    }
                    else
                    {
                        ExcelChartRead(chart, this.pnlBottPane);
                    }
                }
                else
                {
                    if (worksheet == null)
                    {
                        lblErrorText.Text = strSheetRChartName + " Sheet is Available";
                    }
                    else
                    {
                        this.pnlBottPane.Controls.Add(ExcelSheetRead(worksheet, lblErrText));
                    }
                }

                if (!bReadOnly)
                {
                    // Write Mode Close
                    workbook.Save();
                    workbook = null;
                }
                else
                {
                    // Read Mode Close
                    workbook.Close(false, false, Type.Missing);
                    workbook = null;
                }
            }
            catch (Exception expInterop)
            {
                lblErrText.Text = expInterop.ToString();
                return false;
            }
            finally
            {
                if (workbook != null)
                {
                    if (!bReadOnly)
                    {
                        // Write Mode Close
                        workbook.Save();
                        workbook = null;
                    }
                    else
                    {
                        // Read Mode Close
                        workbook.Close(false, false, Type.Missing);
                        workbook = null;
                    }
                }
                appOP.DisplayAlerts = true;
            }
            return true;
        }

        /// <summary>
        /// To Display a Chart in the Panel Object
        /// </summary>
        /// <param name="objExcelChart">Chart to be Opened</param>
        /// <param name="ctrlCollPane">Panel Object to be Displayed</param>
        /// <returns>Returns Boolean Value the Method Succeded</returns>
        public bool ExcelChartRead(Excel.Chart objExcelChart, Panel ctrlCollPane)
        {

            Image imgChart = null;
            try
            {
                objExcelChart.Export(@"C:\TempGif.gif", "GIF", true);
                imgChart = new Image();
                imgChart.ImageUrl = @"C:\TempGif.gif";
                ctrlCollPane.Controls.Add(imgChart);
                imgChart.Dispose();
            }
            catch (Exception expFileError)
            {
                Response.Write(expFileError.ToString());
                return false;
            }
            finally
            {
                if (imgChart != null)
                {
                    imgChart.Dispose();
                }
            }
            return true;
        }


        /// <summary>
        /// Read an Excel Sheet and Displays as it is Same
        /// </summary>
        /// <param name="objExcelSheet">Worksheet to be displayed</param>
        /// <param name="lblErrText">If any Error Occurs that will be displayed</param>
        /// <returns>Returns a Table Control that contains Worksheet Information</returns>
        public Control ExcelSheetRead(Excel.Worksheet objExcelSheet, Label lblErrText)
        {

            int nMaxCol = ((Excel.Range)objExcelSheet.UsedRange).EntireColumn.Count;
            int nMaxRow = ((Excel.Range)objExcelSheet.UsedRange).EntireRow.Count;


            Table tblOutput = new Table();

            TableRow TRow = null;
            TableCell TCell = null;

            string strSize = "";
            int nSizeVal = 0;
            bool bMergeCells = false;
            int nMergeCellCount = 0;
            int nWidth = 0;


            if (objExcelSheet == null)
            {
                return (Control)tblOutput;
            }

            tblOutput.CellPadding = 0;
            tblOutput.CellSpacing = 0;
            tblOutput.GridLines = GridLines.Both;


            try
            {

                for (int nRowIndex = 1; nRowIndex <= nMaxRow; nRowIndex++)
                {
                    TRow = null;
                    TRow = new TableRow();


                    for (int nColIndex = 1; nColIndex <= nMaxCol; nColIndex++)
                    {

                        TCell = null;
                        TCell = new TableCell();
                        if (((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Value2 != null)
                        {

                            TCell.Text = ((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Text.ToString();
                            if (((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Comment != null)
                            {
                                TCell.ForeColor = System.Drawing.Color.Blue;
                                TCell.ToolTip = ((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Comment.Shape.AlternativeText;
                            }
                            else
                            {
                                TCell.ForeColor = ConvertExcelColor2DotNetColor(((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Font.Color);
                            }

                            TCell.BorderWidth = 2;
                            TCell.Width = 140; //TCell.Width = 40;

                            //*
                            TCell.Font.Bold = (bool)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Font.Bold;
                            TCell.Font.Italic = (bool)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Font.Italic;
                            strSize = ((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Font.Size.ToString();
                            nSizeVal = Convert.ToInt32(strSize);
                            TCell.Font.Size = FontUnit.Point(nSizeVal);
                            TCell.BackColor = ConvertExcelColor2DotNetColor(((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Interior.Color);

                            if ((bool)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).MergeCells != false)
                            {
                                if (bMergeCells == false)
                                {
                                    TCell.ColumnSpan = (int)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).MergeArea.Columns.Count;
                                    nMergeCellCount = (int)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).MergeArea.Columns.Count;
                                    nMergeCellCount--;
                                    bMergeCells = true;
                                }
                                else if (nMergeCellCount == 0)
                                {
                                    TCell.ColumnSpan = (int)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).MergeArea.Columns.Count;
                                    nMergeCellCount = (int)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).MergeArea.Columns.Count;
                                    nMergeCellCount--;
                                }
                            }
                            else
                            {
                                bMergeCells = false;
                            }

                            TCell.HorizontalAlign = ExcelHAlign2DotNetHAlign(((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]));
                            TCell.VerticalAlign = ExcelVAlign2DotNetVAlign(((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]));
                            TCell.Height = Unit.Point(Decimal.ToInt32(Decimal.Parse((((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).RowHeight.ToString()))));
                            nWidth = Decimal.ToInt32(Decimal.Parse((((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).ColumnWidth.ToString())));
                            TCell.Width = Unit.Point(nWidth * nWidth);
                            //*/

                        }
                        else
                        {
                            if ((bool)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).MergeCells == false)
                            {
                                bMergeCells = false;
                            }
                            if (bMergeCells == true)
                            {
                                nMergeCellCount--;
                                continue;
                            }
                            TCell.Text = "&nbsp;";
                            if (((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Comment != null)
                            {
                                TCell.ForeColor = System.Drawing.Color.Blue;
                                TCell.ToolTip = ((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Comment.Shape.AlternativeText;
                            }
                            else
                            {
                                TCell.ForeColor = ConvertExcelColor2DotNetColor(((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Font.Color);
                            }
                            TCell.Font.Bold = (bool)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Font.Bold;
                            TCell.Font.Italic = (bool)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Font.Italic;
                            strSize = ((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Font.Size.ToString();
                            nSizeVal = Convert.ToInt32(strSize);
                            TCell.Font.Size = FontUnit.Point(nSizeVal);
                            TCell.BackColor = ConvertExcelColor2DotNetColor(((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Interior.Color);

                            TCell.Height = Unit.Point(Decimal.ToInt32(Decimal.Parse((((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).RowHeight.ToString()))));
                            nWidth = Decimal.ToInt32(Decimal.Parse((((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).ColumnWidth.ToString())));
                            TCell.Width = Unit.Point(nWidth * nWidth);
                        }

                        //TCell.BorderStyle = BorderStyle.Solid;
                        //TCell.BorderWidth = Unit.Point(1);
                        //TCell.BorderColor = System.Drawing.Color.Gray;

                        TRow.Cells.Add(TCell);


                    }

                    tblOutput.Rows.Add(TRow);

                }
            }
            catch (Exception ex)
            {
                lblErrText.Text = ex.ToString();
            }
            return (Control)tblOutput;
        }

        /// <summary>
        /// Converts Excel Color to Dot Net Color
        /// </summary>
        /// <param name="objExcelColor">Excel Object Color</param>
        /// <returns>Returns System.Drawing.Color</returns>
        private System.Drawing.Color ConvertExcelColor2DotNetColor(object objExcelColor)
        {

            string strColor = "";
            uint uColor = 0;
            int nRed = 0;
            int nGreen = 0;
            int nBlue = 0;

            strColor = objExcelColor.ToString();
            uColor = checked((uint)Convert.ToUInt32(strColor));
            strColor = String.Format("{0:x2}", uColor);
            strColor = "000000" + strColor;
            strColor = strColor.Substring((strColor.Length - 6), 6);

            uColor = 0;
            uColor = Convert.ToUInt32(strColor.Substring(4, 2), 16);
            nRed = (int)uColor;

            uColor = 0;
            uColor = Convert.ToUInt32(strColor.Substring(2, 2), 16);
            nGreen = (int)uColor;

            uColor = 0;
            uColor = Convert.ToUInt32(strColor.Substring(0, 2), 16);
            nBlue = (int)uColor;

            return System.Drawing.Color.FromArgb(nRed, nGreen, nBlue);
        }


        /// <summary>
        /// Converts Excel Horizontal Alignment to DotNet Horizontal Alignment
        /// </summary>
        /// <param name="objExcelAlign">Excel Horizontal Alignment</param>
        /// <returns>HorizontalAlign</returns>
        private HorizontalAlign ExcelHAlign2DotNetHAlign(object objExcelAlign)
        {
            switch (((Excel.Range)objExcelAlign).HorizontalAlignment.ToString())
            {
                case "-4131":
                    return HorizontalAlign.Left;
                case "-4108":
                    return HorizontalAlign.Center;
                case "-4152":
                    return HorizontalAlign.Right;
                default:
                    return HorizontalAlign.Left;
            }
        }

        /// <summary>
        /// Converts Excel Vertical Alignment to DotNet Vertical Alignment
        /// </summary>
        /// <param name="objExcelAlign">Excel Vertical Alignment</param>
        /// <returns>VerticalAlign</returns>
        private VerticalAlign ExcelVAlign2DotNetVAlign(object objExcelAlign)
        {
            switch (((Excel.Range)objExcelAlign).VerticalAlignment.ToString())
            {
                case "-4160":
                    return VerticalAlign.Top;
                case "-4108":
                    return VerticalAlign.Middle;
                case "-4107":
                    return VerticalAlign.Bottom;
                default:
                    return VerticalAlign.Bottom;
            }

        }
    }
}
