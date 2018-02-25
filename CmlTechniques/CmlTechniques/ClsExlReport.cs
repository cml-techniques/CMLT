using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
//using Microsoft.Office.Interop.Excel;

namespace CmlTechniques
{
    class ClsExlReport
    {
        //public string CreateExcelReport(string SavePath)     // The path that the final report will be saved to.
        //{
        //    try
        //    {
        //        //
        //        // Declare the application, workbook, and worksheet variables.
        //        //
        //        //Excel.Application oXL = new Excel.Application(); // The excel application.
        //        Microsoft.Office.Interop.Excel.Application oXL = new Excel.Application();
        //        Excel.Workbook theWorkbook;	// The workbook in the excel application.
        //        Excel.Worksheet worksheet; // The worksheet in the workbook.
        //        //
        //        // Set the Excel application to visible.  This is not necessary
        //        // but makes it easier during debugging.
        //        //
        //        //oXL.Visible = true;
        //        //
        //        // Open the Excel template and get the workbook in the Excel file.
        //        //
        //        theWorkbook = oXL.Workbooks.Add(Type.Missing);
        //        //
        //        if (theWorkbook.Worksheets.Count > 0)
        //        {
        //            //
        //            // Select the sheet that the report data will be placed on.
        //            //
        //            worksheet = (Excel.Worksheet)theWorkbook.Sheets[1];
        //            //
        //            // Activate the worksheet so that the data will show up 
        //            // on this sheet.
        //            //
        //            worksheet.Activate();
        //            //
        //            // Apply the formatting necessary for the report.
        //            //

                    
        //            StringBuilder Header=new StringBuilder();
        //            Header.Append(@"&""Times of New Roman Unicode MS,Bold""Testing");
        //            worksheet.PageSetup.CenterHeader = Header.ToString();
        //            //worksheet.PageSetup.LeftHeaderPicture.Filename =System.Windows.Forms.Application.StartupPath +  "\\AAA logo.jpg";
        //            worksheet.PageSetup.LeftHeaderPicture.Height = 35;
        //            worksheet.PageSetup.LeftHeaderPicture.Width = 100;
        //            worksheet.PageSetup.LeftHeader = "&G";
        //            worksheet.PageSetup.RightHeader = DateTime.Now.ToShortDateString() + "\n" + DateTime.Now.ToShortTimeString(); ;
                    

        //            Range rg = worksheet.get_Range("A2", "AF3");
        //            rg.Select();
        //            rg.Font.Bold = true;
        //            rg.Font.Name = "Times New Roman";
        //            rg.Font.Size = 8;
        //            rg.WrapText = true;
        //            rg.HorizontalAlignment = Excel.Constants.xlCenter;
        //            rg.Interior.ColorIndex = 15;
        //            rg.Borders.Weight = 1;
        //            rg.Borders.LineStyle = Excel.Constants.xlSolid;
        //            //rg.Borders.LineStyle = Excel.Constants.xlSolid;
        //            rg.Cells.RowHeight = 22.5;

                    
        //            rg = worksheet.get_Range("A2", Type.Missing);
        //            rg.Cells.ColumnWidth = 7;
        //            rg.Value2 = "SLNO.";
                    

        //            rg = worksheet.get_Range("B2", Type.Missing);
        //            rg.Cells.ColumnWidth = 10;
        //            rg.Value2 = "FILE NO.";
        //            rg = worksheet.get_Range("B3", Type.Missing);
        //            rg.Cells.RowHeight = 21;
        //            rg.Value2 = "A";

        //            rg = worksheet.get_Range("C2", Type.Missing);
        //            rg.Cells.ColumnWidth = 10;
        //            rg.Value2 = "PROJECT";
        //            rg = worksheet.get_Range("C3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "B";

        //            rg = worksheet.get_Range("D2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "BANK NAME";
        //            rg = worksheet.get_Range("D3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "C";

        //            rg = worksheet.get_Range("E2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "LC ISSUE DATE";
        //            rg = worksheet.get_Range("E3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "D";

        //            rg = worksheet.get_Range("F2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "LC NO.";
        //            rg = worksheet.get_Range("F3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "E";

        //            rg = worksheet.get_Range("G2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "LATEST DELIVERY";
        //            rg = worksheet.get_Range("G3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "F";

        //            rg = worksheet.get_Range("H2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "LC EXP. DATE";
        //            rg = worksheet.get_Range("H3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "G";

        //            rg = worksheet.get_Range("I2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "BENEFICIARY";
        //            rg = worksheet.get_Range("I3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "H";

        //            rg = worksheet.get_Range("J2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "DESC. OF GOODS";
        //            rg = worksheet.get_Range("J3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "I";

        //            rg = worksheet.get_Range("K2", Type.Missing);
        //            rg.Cells.ColumnWidth = 25;
        //            rg.Value2 = "PAYMENT TERM";
        //            rg = worksheet.get_Range("K3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "J";

        //            rg = worksheet.get_Range("L2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "LPO/LOL/LOA";
        //            rg = worksheet.get_Range("L3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "K";

        //            rg = worksheet.get_Range("M2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "INCO TERMS";
        //            rg = worksheet.get_Range("M3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "L";

        //            rg = worksheet.get_Range("N2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "COUNTRY OF ORG.";
        //            rg = worksheet.get_Range("N3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "M";

        //            rg = worksheet.get_Range("O2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "VALUE IN FORG. CUR.";
        //            rg = worksheet.get_Range("O3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "N";

        //            rg = worksheet.get_Range("P2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "INICIAL VALUE IN AED";
        //            rg = worksheet.get_Range("P3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "O";

        //            rg = worksheet.get_Range("Q2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "AMENDMENT VALUE IN AED";
        //            rg = worksheet.get_Range("Q3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "P";

        //            rg = worksheet.get_Range("R2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "LC TOTAL VALUE IN AED";
        //            rg = worksheet.get_Range("R3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "Q";

        //            rg = worksheet.get_Range("S2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "PAID";
        //            rg = worksheet.get_Range("S3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "R";

        //            rg = worksheet.get_Range("T2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "BALANCE";
        //            rg = worksheet.get_Range("T3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "S=Q-R";

        //            rg = worksheet.get_Range("U2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "DELIVERY VARIATION";
        //            rg = worksheet.get_Range("U3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "T";

        //            rg = worksheet.get_Range("V2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "DESCREPENCY";
        //            rg = worksheet.get_Range("V3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "U";

        //            rg = worksheet.get_Range("W2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "LC EXPIRED";
        //            rg = worksheet.get_Range("W3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "V";

        //            rg = worksheet.get_Range("X2", Type.Missing);
        //            rg.Cells.ColumnWidth = 11;
        //            rg.Value2 = "EXCHANGE DIFFERENCE";
        //            rg = worksheet.get_Range("X3", Type.Missing);
        //            //rg.Cells.RowHeight = 12;
        //            rg.Value2 = "W";


        //            //rg = worksheet.get_Range("Y2:AD2", Type.Missing);
        //            //rg.Cells.ColumnWidth = 11;
        //            //rg.MergeCells = true;
        //            //rg.Value2 = "ACCEPTANCE";
        //            //load_prdheading();
        //            //rg = worksheet.get_Range("Y3", Type.Missing);
        //            ////rg.Cells.RowHeight = 21;
        //            //rg.Value2 = prdh[0].ToString() + "\n" + "X1";
        //            //rg = worksheet.get_Range("Z3", Type.Missing);
        //            ////rg.Cells.RowHeight = 12;
        //            //rg.Value2 = prdh[1].ToString() + "\n" + "X2";
        //            //rg = worksheet.get_Range("AA3", Type.Missing);
        //            ////rg.Cells.RowHeight = 12;
        //            //rg.Value2 = prdh[2].ToString() + "\n" + "X3";
        //            //rg = worksheet.get_Range("AB3", Type.Missing);
        //            ////rg.Cells.RowHeight = 12;
        //            //rg.Value2 = prdh[3].ToString() + "\n" + "X4";
        //            //rg = worksheet.get_Range("AC3", Type.Missing);
        //            ////rg.Cells.RowHeight = 12;
        //            //rg.Value2 = prdh[4].ToString() + "\n" + "X5";
        //            //rg = worksheet.get_Range("AD3", Type.Missing);
        //            ////rg.Cells.RowHeight = 12;
        //            //rg.Value2 = prdh[5].ToString() + "\n" + "X6";

        //            //rg = worksheet.get_Range("AE2", Type.Missing);
        //            //rg.Cells.ColumnWidth = 11;
        //            //rg.Value2 = "BALANCE";
        //            //rg = worksheet.get_Range("AE3", Type.Missing);
        //            ////rg.Cells.RowHeight = 12;
        //            //rg.Value2 = "Y=S-(T...X6)";


        //            //rg = worksheet.get_Range("AF2", Type.Missing);
        //            //rg.Cells.ColumnWidth = 11;
        //            //rg.Value2 = "TOTAL EXPS.";
        //            //rg = worksheet.get_Range("AF3", Type.Missing);
        //            ////rg.Cells.RowHeight = 12;
        //            //rg.Value2 = "Z";



        //            //
        //            // The header is now set up so now the only
        //            // thing left to do is put the data on the
        //            // form.
        //            //
        //            int RowCounter = 4;
        //            double TotalValue = 0;
        //            //
        //            // Get the data from the dataset created above 
        //            // and populate the spreadsheet.
        //            //
                   
        //            //dtr = BLOBJ.LoadLCSummary(bnk1, prj1, sup1, bnk2, prj2, sup2);
                   
        //            //int idx = 1;
        //            //while (dtr.Read())
        //            //{
        //            //    //
        //            //    // Format each row of data for the report.
        //            //    //
        //            //    rg = (Excel.Range)worksheet.Rows[RowCounter, Type.Missing];
        //            //    rg.HorizontalAlignment = Excel.Constants.xlLeft ;
        //            //    rg.VerticalAlignment = Excel.Constants.xlCenter;
        //            //    rg.Cells.RowHeight = 12.75;
        //            //    rg.Borders.Weight = 1;
        //            //    rg.Font.Name = "Times New Roman";
        //            //    rg.Font.Size = 8;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 5];
        //            //    rg.NumberFormat = "DD/MM/YYYY";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlCenter;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter,7];
        //            //    rg.NumberFormat = "DD/MM/YYYY";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlCenter;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 8];
        //            //    rg.NumberFormat = "dd/mm/YYYY";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlCenter;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 15];
        //            //    rg.NumberFormat = "0.00";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlRight ;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 16];
        //            //    rg.NumberFormat = "0.00";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlRight;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 17];
        //            //    rg.NumberFormat = "0.00";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlRight;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 18];
        //            //    rg.NumberFormat = "0.00";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlRight;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 19];
        //            //    rg.NumberFormat = "0.00";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlRight;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 20];
        //            //    rg.NumberFormat = "0.00";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlRight;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 21];
        //            //    rg.NumberFormat = "0.00";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlRight;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 22];
        //            //    rg.NumberFormat = "0.00";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlRight;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 23];
        //            //    rg.NumberFormat = "0.00";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlRight;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 24];
        //            //    rg.NumberFormat = "0.00";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlRight;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 25];
        //            //    rg.NumberFormat = "0.00";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlRight;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 26];
        //            //    rg.NumberFormat = "0.00";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlRight;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 27];
        //            //    rg.NumberFormat = "0.00";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlRight;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 28];
        //            //    rg.NumberFormat = "0.00";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlRight;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 29];
        //            //    rg.NumberFormat = "0.00";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlRight;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 30];
        //            //    rg.NumberFormat = "0.00";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlRight;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 31];
        //            //    rg.NumberFormat = "0.00";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlRight;

        //            //    rg = (Excel.Range)worksheet.Cells[RowCounter, 32];
        //            //    rg.NumberFormat = "0.00";
        //            //    rg.HorizontalAlignment = Excel.Constants.xlRight;

                     
        //            //    //
        //            //    // Drop the data into the spreadsheet.
        //            //    //
        //            //    worksheet.Cells[RowCounter, 1] = idx.ToString();
        //            //    worksheet.Cells[RowCounter, 2] = dtr["File_no"].ToString();
        //            //    worksheet.Cells[RowCounter, 3] = dtr["prj_code"].ToString();
        //            //    worksheet.Cells[RowCounter, 4] = dtr["BankName"].ToString();
        //            //    worksheet.Cells[RowCounter, 5] = dtr["FAC_DATE"].ToString();
        //            //    worksheet.Cells[RowCounter, 6] = dtr["FACDOC_NO"].ToString();
        //            //    worksheet.Cells[RowCounter, 7] = dtr["dt_lst_dvry"].ToString();
        //            //    worksheet.Cells[RowCounter, 8] = dtr["dt_exp"].ToString();
        //            //    worksheet.Cells[RowCounter, 9] = dtr["Supplier_Name"].ToString();
        //            //    worksheet.Cells[RowCounter, 10] = dtr["material_Desc"].ToString();
        //            //    worksheet.Cells[RowCounter, 11] = getPayterm(dtr["File_no"].ToString(), dtr["FACDOC_NO"].ToString());
        //            //    worksheet.Cells[RowCounter, 12] = getLpo(dtr["File_no"].ToString(), dtr["FACDOC_NO"].ToString());
        //            //    worksheet.Cells[RowCounter, 13] = dtr["inc_code"].ToString();
        //            //    worksheet.Cells[RowCounter, 14] = dtr["country"].ToString();
        //            //    worksheet.Cells[RowCounter, 15] = dtr["facility"].ToString();
        //            //    worksheet.Cells[RowCounter, 16] = dtr["facilityamount"].ToString();
        //            //    worksheet.Cells[RowCounter, 17] = dtr["amendment"].ToString();
        //            //    worksheet.Cells[RowCounter, 18] = dtr["TOTALVALUE"].ToString();
        //            //    worksheet.Cells[RowCounter, 19] = dtr["PAYMNET"].ToString();
        //            //    worksheet.Cells[RowCounter, 20] = dtr["BALANCE"].ToString();
        //            //    worksheet.Cells[RowCounter, 21] = dtr["DELIVERY"].ToString();
        //            //    worksheet.Cells[RowCounter, 22] = dtr["DESCREPENCY"].ToString();
        //            //    worksheet.Cells[RowCounter, 23] = dtr["EXPIRED"].ToString();
        //            //    worksheet.Cells[RowCounter, 24] = dtr["EXCHANGE"].ToString();
        //            //    worksheet.Cells[RowCounter, 25] = dtr["PRD1"].ToString();
        //            //    worksheet.Cells[RowCounter, 26] = dtr["PRD2"].ToString();
        //            //    worksheet.Cells[RowCounter, 27] = dtr["PRD3"].ToString();
        //            //    worksheet.Cells[RowCounter, 28] = dtr["PRD4"].ToString();
        //            //    worksheet.Cells[RowCounter, 29] = dtr["PRD5"].ToString();
        //            //    worksheet.Cells[RowCounter, 30] = dtr["SUM6"].ToString();
        //            //    worksheet.Cells[RowCounter, 31] = dtr["BALANCE1"].ToString();
        //            //    worksheet.Cells[RowCounter, 32] = dtr["COST"].ToString();
        //            //    idx += 1;
        //            //    //
        //            //    // This is just to show that the formatting can be 
        //            //    // done with .NET instead of using the NumberFormat.
        //            //    //
        //            //    //TotalValue = Convert.ToDouble(dr["Total"].ToString());
        //            //    //worksheet.Cells[RowCounter, 5] = TotalValue.ToString("C");
        //            //    RowCounter++;
        //            //}
        //            //dtr.Close();
                    
        //            rg = worksheet.get_Range("A" + RowCounter , "AF" + RowCounter );
        //            rg.HorizontalAlignment = Excel.Constants.xlRight;
        //            rg.VerticalAlignment = Excel.Constants.xlCenter;
        //            rg.Cells.RowHeight = 12.75;
        //            rg.Font.Name = "Times New Roman";
        //            rg.Font.Bold = true;
        //            rg.Font.Size = 8;
        //            rg.Borders.Weight = 1;
        //            rg.Borders.LineStyle = Excel.Constants.xlSolid;
        //            RowCounter = RowCounter - 1;
        //            worksheet.Cells[RowCounter + 1, 15] = "=SUM(O4:O" + RowCounter;
        //            worksheet.Cells[RowCounter + 1, 16] = "=SUM(P4:P" + RowCounter;
        //            worksheet.Cells[RowCounter + 1, 17] = "=SUM(Q4:Q" + RowCounter;
        //            worksheet.Cells[RowCounter + 1, 18] = "=SUM(R4:R" + RowCounter;
        //            worksheet.Cells[RowCounter + 1, 19] = "=SUM(S4:S" + RowCounter;
        //            worksheet.Cells[RowCounter + 1, 20] = "=SUM(T4:T" + RowCounter;
        //            worksheet.Cells[RowCounter + 1, 21] = "=SUM(U4:U" + RowCounter;
        //            worksheet.Cells[RowCounter + 1, 22] = "=SUM(V4:V" + RowCounter;
        //            worksheet.Cells[RowCounter + 1, 23] = "=SUM(W4:W" + RowCounter;
        //            worksheet.Cells[RowCounter + 1, 24] = "=SUM(X4:X" + RowCounter;
        //            worksheet.Cells[RowCounter + 1, 25] = "=SUM(Y4:Y" + RowCounter;
        //            worksheet.Cells[RowCounter + 1, 26] = "=SUM(Z4:Z" + RowCounter;
        //            worksheet.Cells[RowCounter + 1, 27] = "=SUM(AA4:AA" + RowCounter;
        //            worksheet.Cells[RowCounter + 1, 28] = "=SUM(AB4:AB" + RowCounter;
        //            worksheet.Cells[RowCounter + 1, 29] = "=SUM(AC4:AC" + RowCounter;
        //            worksheet.Cells[RowCounter + 1, 30] = "=SUM(AD4:AD" + RowCounter;
        //            worksheet.Cells[RowCounter + 1, 31] = "=SUM(AE4:AE" + RowCounter;
        //            worksheet.Cells[RowCounter + 1, 32] = "=SUM(AF4:AF" + RowCounter;
                    
        //            worksheet.PageSetup.LeftFooter = "Administator";
        //            worksheet.PageSetup.RightFooter = "Treasury Department";
                   
                                
        //            //
        //            // Save the workbook.
        //            //
        //            FileInfo f = new FileInfo(SavePath + "\\test.xls");
        //            if (f.Exists)
        //                f.Delete(); // delete the file if it already exist.

        //            oXL.ActiveWorkbook.SaveAs(SavePath + "\\test.xls",
        //                Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing,
        //                Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
        //                Type.Missing, Type.Missing, Type.Missing, Type.Missing, 0);
        //            //oXL.Visible = true;
        //            //
        //            // Close the Excel workbook and Excel application down.  You
        //            // need to perform the following steps to eliminate the 
        //            // Excel object from memory otherwise you will keep adding
        //            // instances of Excel in memory and you will need to 
        //            // use the Windows Task Manager to eliminate the 
        //            // Excel instances.
        //            //
        //            theWorkbook.Close(null, null, null);
        //            oXL.Workbooks.Close();
        //            oXL.Application.Quit();
        //            oXL.Quit();
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(theWorkbook);
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(oXL);
        //            worksheet = null;
        //            theWorkbook = null;
        //            oXL = null;
        //             return "yes";
        //        }
        //        return "no";
        //    }
        //    catch (Exception ex)
        //    {
        //        //System.Windows.Forms.MessageBox.Show(ex.ToString());
                
        //        return ex.ToString();
        //    }

        }
       
    
    }

