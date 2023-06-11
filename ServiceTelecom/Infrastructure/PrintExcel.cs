﻿using ServiceTelecom.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace ServiceTelecom.Infrastructure
{
    internal class PrintExcel
    {
        internal void PrintExcelNumberActTechnicalWork(
            List<RadiostationForDocumentsDataBaseModel>
            radiostantionsCollection)
        {
            Excel.Application exApp = new Excel.Application();

            try
            {
                Type officeType = Type.GetTypeFromProgID("Excel.Application");

                if (officeType == null)
                    MessageBox.Show($"Ошибка у Вас не установлен Excel",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    exApp.SheetsInNewWorkbook = 3;
                    exApp.Workbooks.Add();
                    exApp.DisplayAlerts = false;

                    Excel.Worksheet workSheet = (Excel.Worksheet)exApp.Worksheets.get_Item(1);
                    Excel.Worksheet workSheet2 = (Excel.Worksheet)exApp.Worksheets.get_Item(2);
                    Excel.Worksheet workSheet3 = (Excel.Worksheet)exApp.Worksheets.get_Item(3);

                    string numberAct = radiostantionsCollection[0].NumberAct;
                    string dateMaintenance = radiostantionsCollection[0].DateMaintenance;
                    string company = radiostantionsCollection[0].Company;
                    string city = radiostantionsCollection[0].City;
                    string location = "ст. " + city;
                    
                    string sectionForeman = string.Empty;
                    string attorney = string.Empty;
                    string engineer = string.Empty;
                    foreach (var item in UserModelStatic.
                        StaffRegistrationsDataBaseModelCollection)
                    {
                        if (radiostantionsCollection[0].Road == item.RoadBase)
                        {
                            sectionForeman = item.SectionForemanBase;
                            attorney = item.AttorneyBase;
                            engineer = item.EngineerBase;
                        }
                    }
                       
                    
                    string post = radiostantionsCollection[0].Post;
                    string representative = radiostantionsCollection[0].Representative;
                    string numberIdentification = radiostantionsCollection[0].NumberIdentification;

                    string poligon = radiostantionsCollection[0].Poligon;
                    string road = radiostantionsCollection[0].Road;
                    string dateOfIssuanceOfTheCertificate = radiostantionsCollection[0].DateOfIssuanceOfTheCertificate;

                    workSheet.Name = $"Накладная №{numberAct.Replace('/', '.')}";
                    workSheet2.Name = $"Ведомость №{numberAct.Replace('/', '.')}";
                    workSheet3.Name = $"Акт №{numberAct.Replace('/', '.')}";

                    #region Накладная

                    workSheet.PageSetup.Zoom = false;
                    workSheet.PageSetup.FitToPagesWide = 1;
                    workSheet.PageSetup.FitToPagesTall = 1;

                    workSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;

                    workSheet.Rows.Font.Size = 9.5;
                    workSheet.Rows.Font.Name = "Times New Roman";

                    Excel.Range _excelCells2 = (Excel.Range)workSheet.get_Range("E1", "G1").Cells;
                    Excel.Range _excelCells1 = (Excel.Range)workSheet.get_Range("M1", "O1").Cells;
                    Excel.Range _excelCells3 = (Excel.Range)workSheet.get_Range("C3", "D3").Cells;
                    Excel.Range _excelCells4 = (Excel.Range)workSheet.get_Range("K3", "L3").Cells;
                    Excel.Range _excelCells5 = (Excel.Range)workSheet.get_Range("A5", "B5").Cells;
                    Excel.Range _excelCells6 = (Excel.Range)workSheet.get_Range("C5", "D5").Cells;
                    Excel.Range _excelCells7 = (Excel.Range)workSheet.get_Range("E5", "G5").Cells;
                    Excel.Range _excelCells8 = (Excel.Range)workSheet.get_Range("I5", "J5").Cells;
                    Excel.Range _excelCells9 = (Excel.Range)workSheet.get_Range("E3").Cells;
                    Excel.Range _excelCells10 = (Excel.Range)workSheet.get_Range("M3").Cells;
                    Excel.Range _excelCells11 = (Excel.Range)workSheet.get_Range("K5", "L5").Cells;
                    Excel.Range _excelCells12 = (Excel.Range)workSheet.get_Range("M5", "O5").Cells;
                    Excel.Range _excelCells13 = (Excel.Range)workSheet.get_Range("A6", "B6").Cells;
                    Excel.Range _excelCells14 = (Excel.Range)workSheet.get_Range("C6", "D6").Cells;
                    Excel.Range _excelCells15 = (Excel.Range)workSheet.get_Range("I6", "J6").Cells;
                    Excel.Range _excelCells16 = (Excel.Range)workSheet.get_Range("K6", "L6").Cells;
                    Excel.Range _excelCells17 = (Excel.Range)workSheet.get_Range("A7", "A27").Cells;
                    Excel.Range _excelCells18 = (Excel.Range)workSheet.get_Range("B7", "C7").Cells;
                    Excel.Range _excelCells19 = (Excel.Range)workSheet.get_Range("A7", "O7").Cells;
                    Excel.Range _excelCells20 = (Excel.Range)workSheet.get_Range("I7", "I27").Cells;
                    Excel.Range _excelCells21 = (Excel.Range)workSheet.get_Range("J7", "K7").Cells;
                    Excel.Range _excelCells32 = (Excel.Range)workSheet.get_Range("A8", "O27").Cells;
                    Excel.Range _excelCells33 = (Excel.Range)workSheet.get_Range("A7", "G27").Cells;
                    Excel.Range _excelCells34 = (Excel.Range)workSheet.get_Range("I7", "O27").Cells;
                    Excel.Range _excelCells35 = (Excel.Range)workSheet.get_Range("A28", "G28").Cells;
                    Excel.Range _excelCells36 = (Excel.Range)workSheet.get_Range("I28", "O28").Cells;
                    Excel.Range _excelCells37 = (Excel.Range)workSheet.get_Range("A29", "C30").Cells;
                    Excel.Range _excelCells38 = (Excel.Range)workSheet.get_Range("A31", "C31").Cells;
                    Excel.Range _excelCells39 = (Excel.Range)workSheet.get_Range("A33", "C33").Cells;
                    Excel.Range _excelCells40 = (Excel.Range)workSheet.get_Range("B33", "C33").Cells;
                    Excel.Range _excelCells41 = (Excel.Range)workSheet.get_Range("B34", "C34").Cells;
                    Excel.Range _excelCells42 = (Excel.Range)workSheet.get_Range("A36", "C37").Cells;
                    Excel.Range _excelCells43 = (Excel.Range)workSheet.get_Range("A38", "C38").Cells;
                    Excel.Range _excelCells44 = (Excel.Range)workSheet.get_Range("A40", "C40").Cells;
                    Excel.Range _excelCells45 = (Excel.Range)workSheet.get_Range("B40", "C40").Cells;
                    Excel.Range _excelCells46 = (Excel.Range)workSheet.get_Range("B41", "C41").Cells;
                    Excel.Range _excelCells47 = (Excel.Range)workSheet.get_Range("E29", "G30").Cells;
                    Excel.Range _excelCells48 = (Excel.Range)workSheet.get_Range("E31", "G31").Cells;
                    Excel.Range _excelCells49 = (Excel.Range)workSheet.get_Range("E33", "G33").Cells;
                    Excel.Range _excelCells50 = (Excel.Range)workSheet.get_Range("F33", "G33").Cells;
                    Excel.Range _excelCells51 = (Excel.Range)workSheet.get_Range("F34", "G34").Cells;
                    Excel.Range _excelCells52 = (Excel.Range)workSheet.get_Range("E36", "G37").Cells;
                    Excel.Range _excelCells53 = (Excel.Range)workSheet.get_Range("E38", "G38").Cells;
                    Excel.Range _excelCells54 = (Excel.Range)workSheet.get_Range("E40", "G40").Cells;
                    Excel.Range _excelCells55 = (Excel.Range)workSheet.get_Range("F40", "G40").Cells;
                    Excel.Range _excelCells56 = (Excel.Range)workSheet.get_Range("F41", "G41").Cells;
                    Excel.Range _excelCells57 = (Excel.Range)workSheet.get_Range("D42", "G42").Cells;
                    Excel.Range _excelCells58 = (Excel.Range)workSheet.get_Range("D43", "G43").Cells;
                    Excel.Range _excelCells59 = (Excel.Range)workSheet.get_Range("I29", "K30").Cells;
                    Excel.Range _excelCells60 = (Excel.Range)workSheet.get_Range("I31", "K31").Cells;
                    Excel.Range _excelCells61 = (Excel.Range)workSheet.get_Range("I33", "K33").Cells;
                    Excel.Range _excelCells62 = (Excel.Range)workSheet.get_Range("J33", "K33").Cells;
                    Excel.Range _excelCells63 = (Excel.Range)workSheet.get_Range("J34", "K34").Cells;
                    Excel.Range _excelCells64 = (Excel.Range)workSheet.get_Range("I36", "K37").Cells;
                    Excel.Range _excelCells65 = (Excel.Range)workSheet.get_Range("I38", "K38").Cells;
                    Excel.Range _excelCells66 = (Excel.Range)workSheet.get_Range("I40", "K40").Cells;
                    Excel.Range _excelCells67 = (Excel.Range)workSheet.get_Range("J40", "K40").Cells;
                    Excel.Range _excelCells68 = (Excel.Range)workSheet.get_Range("J41", "K41").Cells;
                    Excel.Range _excelCells69 = (Excel.Range)workSheet.get_Range("M29", "O30").Cells;
                    Excel.Range _excelCells70 = (Excel.Range)workSheet.get_Range("M31", "O31").Cells;
                    Excel.Range _excelCells71 = (Excel.Range)workSheet.get_Range("M33", "O33").Cells;
                    Excel.Range _excelCells72 = (Excel.Range)workSheet.get_Range("N33", "O33").Cells;
                    Excel.Range _excelCells73 = (Excel.Range)workSheet.get_Range("M36", "O37").Cells;
                    Excel.Range _excelCells74 = (Excel.Range)workSheet.get_Range("M38", "O38").Cells;
                    Excel.Range _excelCells75 = (Excel.Range)workSheet.get_Range("M40", "O40").Cells;
                    Excel.Range _excelCells76 = (Excel.Range)workSheet.get_Range("N40", "O40").Cells;
                    Excel.Range _excelCells77 = (Excel.Range)workSheet.get_Range("N41", "O41").Cells;
                    Excel.Range _excelCells78 = (Excel.Range)workSheet.get_Range("L42", "O42").Cells;
                    Excel.Range _excelCells79 = (Excel.Range)workSheet.get_Range("L43", "O43").Cells;

                    _excelCells1.Merge(Type.Missing);
                    _excelCells2.Merge(Type.Missing);
                    _excelCells3.Merge(Type.Missing);
                    _excelCells4.Merge(Type.Missing);
                    _excelCells5.Merge(Type.Missing);
                    _excelCells6.Merge(Type.Missing);
                    _excelCells7.Merge(Type.Missing);
                    _excelCells8.Merge(Type.Missing);
                    _excelCells11.Merge(Type.Missing);
                    _excelCells12.Merge(Type.Missing);
                    _excelCells13.Merge(Type.Missing);
                    _excelCells14.Merge(Type.Missing);
                    _excelCells15.Merge(Type.Missing);
                    _excelCells16.Merge(Type.Missing);
                    _excelCells18.Merge(Type.Missing);
                    _excelCells21.Merge(Type.Missing);
                    _excelCells35.Merge(Type.Missing);
                    _excelCells36.Merge(Type.Missing);
                    _excelCells37.Merge(Type.Missing);
                    _excelCells38.Merge(Type.Missing);
                    _excelCells40.Merge(Type.Missing);
                    _excelCells41.Merge(Type.Missing);
                    _excelCells42.Merge(Type.Missing);
                    _excelCells43.Merge(Type.Missing);
                    _excelCells45.Merge(Type.Missing);
                    _excelCells46.Merge(Type.Missing);
                    _excelCells47.Merge(Type.Missing);
                    _excelCells48.Merge(Type.Missing);
                    _excelCells50.Merge(Type.Missing);
                    _excelCells51.Merge(Type.Missing);
                    _excelCells52.Merge(Type.Missing);
                    _excelCells53.Merge(Type.Missing);
                    _excelCells55.Merge(Type.Missing);
                    _excelCells56.Merge(Type.Missing);
                    _excelCells57.Merge(Type.Missing);
                    _excelCells58.Merge(Type.Missing);
                    _excelCells59.Merge(Type.Missing);
                    _excelCells60.Merge(Type.Missing);
                    _excelCells62.Merge(Type.Missing);
                    _excelCells63.Merge(Type.Missing);
                    _excelCells64.Merge(Type.Missing);
                    _excelCells65.Merge(Type.Missing);
                    _excelCells67.Merge(Type.Missing);
                    _excelCells68.Merge(Type.Missing);
                    _excelCells69.Merge(Type.Missing);
                    _excelCells70.Merge(Type.Missing);
                    _excelCells72.Merge(Type.Missing);
                    _excelCells73.Merge(Type.Missing);
                    _excelCells74.Merge(Type.Missing);
                    _excelCells76.Merge(Type.Missing);
                    _excelCells77.Merge(Type.Missing);
                    _excelCells78.Merge(Type.Missing);
                    _excelCells79.Merge(Type.Missing);

                    _excelCells1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells3.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells4.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells5.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells6.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells7.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells8.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells11.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells12.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells13.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells14.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells15.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells16.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells17.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells18.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells19.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells19.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells20.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells21.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells32.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells35.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells36.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells38.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells40.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells41.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells43.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells45.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells46.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells47.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells48.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells50.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells51.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells52.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells53.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells55.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells56.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells57.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells58.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells59.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    _excelCells60.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells62.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells63.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells64.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    _excelCells65.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells67.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells68.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells69.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells70.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells72.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells73.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells74.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells76.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells77.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells78.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells79.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    _excelCells1.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells2.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells9.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells10.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells14.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells16.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells37.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells39.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells42.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells44.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells47.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells49.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells52.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells54.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells59.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells61.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells64.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells66.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells69.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells71.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells73.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells75.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;

                    _excelCells33.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells33.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells33.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells33.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells33.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells33.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

                    _excelCells34.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells34.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells34.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells34.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells34.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells34.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

                    Excel.Range rowColum = workSheet.get_Range("A7", "A27");
                    rowColum.EntireColumn.ColumnWidth = 5; //

                    Excel.Range rowHeight = workSheet.get_Range("A7", "O7");
                    rowHeight.EntireRow.RowHeight = 25; //   

                    Excel.Range rowColum2 = workSheet.get_Range("I7", "I27");
                    rowColum2.EntireColumn.ColumnWidth = 5; //

                    Excel.Range rowColum3 = workSheet.get_Range("D7", "D27");
                    rowColum3.EntireColumn.ColumnWidth = 15; //

                    Excel.Range rowColum4 = workSheet.get_Range("L7", "L27");
                    rowColum4.EntireColumn.ColumnWidth = 15; //

                    Excel.Range rowColum5 = workSheet.get_Range("B7", "C7");
                    rowColum5.EntireColumn.ColumnWidth = 10; //

                    Excel.Range rowColum6 = workSheet.get_Range("J7", "K7");
                    rowColum6.EntireColumn.ColumnWidth = 10; //

                    Excel.Range rowHeight2 = workSheet.get_Range("A31", "O31");
                    rowHeight2.EntireRow.RowHeight = 10; //

                    Excel.Range rowHeight3 = workSheet.get_Range("A34", "O34");
                    rowHeight3.EntireRow.RowHeight = 10; //

                    Excel.Range rowHeight4 = workSheet.get_Range("A38", "O38");
                    rowHeight4.EntireRow.RowHeight = 10; //

                    Excel.Range rowHeight5 = workSheet.get_Range("A41", "O41");
                    rowHeight5.EntireRow.RowHeight = 10; //

                    Excel.Range rowHeight6 = workSheet.get_Range("A29", "A30");
                    rowHeight6.EntireRow.RowHeight = 25; //

                    Excel.Range rowHeight7 = workSheet.get_Range("A36", "A37");
                    rowHeight7.EntireRow.RowHeight = 25; //

                    Excel.Range range_Consolidated = workSheet.Rows.get_Range("E1", "O1");
                    Excel.Range range_Consolidated2 = workSheet.Rows.get_Range("C3", "M3");
                    Excel.Range range_Consolidated3 = workSheet.Rows.get_Range("A7", "O7");
                    Excel.Range range_Consolidated4 = workSheet.Rows.get_Range("A8", "O27");
                    Excel.Range range_Consolidated5 = workSheet.Rows.get_Range("A28", "O28");
                    Excel.Range range_Consolidated6 = workSheet.Rows.get_Range("A31", "O31");
                    Excel.Range range_Consolidated7 = workSheet.Rows.get_Range("A34", "O34");
                    Excel.Range range_Consolidated8 = workSheet.Rows.get_Range("A38", "O38");
                    Excel.Range range_Consolidated9 = workSheet.Rows.get_Range("A41", "O41");
                    Excel.Range range_Consolidated10 = workSheet.Rows.get_Range("A42", "O43");
                    Excel.Range range_Consolidated11 = workSheet.Rows.get_Range("B8", "C27");
                    Excel.Range range_Consolidated12 = workSheet.Rows.get_Range("J8", "K27");
                    Excel.Range range_Consolidated13 = workSheet.Rows.get_Range("E29", "G30");
                    Excel.Range range_Consolidated14 = workSheet.Rows.get_Range("E36", "G37");
                    Excel.Range range_Consolidated15 = workSheet.Rows.get_Range("M29", "O30");
                    Excel.Range range_Consolidated16 = workSheet.Rows.get_Range("M36", "O37");
                    Excel.Range range_Consolidated17 = workSheet.Rows.get_Range("D8", "D27");
                    Excel.Range range_Consolidated18 = workSheet.Rows.get_Range("L8", "L27");
                    Excel.Range range_Consolidated19 = workSheet.Rows.get_Range("A1", "O1");

                    range_Consolidated.Font.Bold = true;
                    range_Consolidated.Font.Size = 10;
                    range_Consolidated2.Font.Bold = true;
                    range_Consolidated2.Font.Size = 12;
                    range_Consolidated3.Font.Bold = true;
                    range_Consolidated4.Font.Size = 8;
                    range_Consolidated5.Font.Size = 7;
                    range_Consolidated6.Font.Size = 7;
                    range_Consolidated7.Font.Size = 7;
                    range_Consolidated8.Font.Size = 7;
                    range_Consolidated9.Font.Size = 7;
                    range_Consolidated10.Font.Size = 8;
                    range_Consolidated10.Font.Bold = true;
                    range_Consolidated11.NumberFormat = "@";
                    range_Consolidated12.NumberFormat = "@";
                    range_Consolidated13.Font.Size = 7.5;
                    range_Consolidated14.Font.Size = 7.5;
                    range_Consolidated15.Font.Size = 7.5;
                    range_Consolidated16.Font.Size = 7.5;
                    range_Consolidated17.NumberFormat = "@";
                    range_Consolidated19.NumberFormat = "@"; 

                    workSheet.Cells[1, 5] = $"{dateMaintenance}";
                    workSheet.Cells[1, 13] = $"{dateMaintenance}";
                    workSheet.Cells[3, 3] = $"НАКЛАДНАЯ №";
                    workSheet.Cells[3, 5] = $"{numberAct}";
                    workSheet.Cells[3, 11] = $"НАКЛАДНАЯ №";
                    workSheet.Cells[3, 13] = $"{numberAct}";
                    workSheet.Cells[5, 1] = $"От кого";
                    workSheet.Cells[5, 3] = $"{company}";
                    workSheet.Cells[5, 5] = $"{location}";
                    workSheet.Cells[5, 9] = $"От кого";
                    workSheet.Cells[5, 11] = $"{company}";
                    workSheet.Cells[5, 13] = $"{location}";
                    workSheet.Cells[6, 1] = $"Кому";
                    workSheet.Cells[6, 3] = $" ООО \"СервисТелеком\"";
                    workSheet.Cells[6, 9] = $"Кому";
                    workSheet.Cells[6, 11] = $" ООО \"СервисТелеком\"";
                    workSheet.Cells[7, 1] = $"№";
                    workSheet.Cells[7, 2] = $"Заводской номер";
                    workSheet.Cells[7, 4] = $"№ АКБ";
                    workSheet.Cells[7, 5] = $"ЗУ\n(шт.)";
                    workSheet.Cells[7, 6] = $"АНТ\n(шт.)";
                    workSheet.Cells[7, 7] = $"МАН\n(шт.)";
                    workSheet.Cells[7, 9] = $"№";
                    workSheet.Cells[7, 10] = $"Заводской номер";
                    workSheet.Cells[7, 12] = $"№ АКБ";
                    workSheet.Cells[7, 13] = $"ЗУ\n(шт.)";
                    workSheet.Cells[7, 14] = $"АНТ\n(шт.)";
                    workSheet.Cells[7, 15] = $"МАН\n(шт.)";
                    workSheet.Cells[28, 1] = $"Комплектность и работоспособность проверены в присутствии Заказчика. Знаки соответствия нанесены.";
                    workSheet.Cells[28, 9] = $"Комплектность и работоспособность проверены в присутствии Заказчика. Знаки соответствия нанесены.";
                    workSheet.Cells[29, 1] = $"\nПринял: Начальник участка по ТО\nи ремонту СРС\n";
                    workSheet.Cells[31, 1] = $"должность";
                    workSheet.Cells[33, 2] = $"{sectionForeman}";
                    workSheet.Cells[34, 1] = $"подпись";
                    workSheet.Cells[34, 2] = $"расшифровка подписи";
                    workSheet.Cells[36, 1] = $"\nСдал: Начальник участка по ТО\nи ремонту СРС\n";
                    workSheet.Cells[38, 1] = $"должность";
                    workSheet.Cells[40, 2] = $"{sectionForeman}";
                    workSheet.Cells[41, 1] = $"подпись";
                    workSheet.Cells[41, 2] = $"расшифровка подписи";
                    workSheet.Cells[29, 5] = $"\nСдал: {post}\n";
                    workSheet.Cells[31, 5] = $"должность";
                    workSheet.Cells[33, 6] = $"{representative}";
                    workSheet.Cells[34, 5] = $"подпись";
                    workSheet.Cells[34, 6] = $"расшифровка подписи";
                    workSheet.Cells[36, 5] = $"\nПринял: {post}\n";
                    workSheet.Cells[38, 5] = $"должность";
                    workSheet.Cells[40, 6] = $"{representative}";
                    workSheet.Cells[41, 5] = $"подпись";
                    workSheet.Cells[41, 6] = $"расшифровка подписи";
                    workSheet.Cells[42, 4] = $"Ведомость измерения параметров получил";
                    workSheet.Cells[43, 4] = $"Удостоверение \"№\":{numberIdentification}";
                    workSheet.Cells[29, 9] = $"\nПринял: Начальник участка по ТО\nи ремонту СРС\n";
                    workSheet.Cells[31, 9] = $"должность";
                    workSheet.Cells[33, 10] = $"{sectionForeman}";
                    workSheet.Cells[34, 9] = $"подпись";
                    workSheet.Cells[34, 10] = $"расшифровка подписи";
                    workSheet.Cells[36, 9] = $"\nСдал: Начальник участка по ТО\nи ремонту СРС\n";
                    workSheet.Cells[38, 9] = $"подпись";
                    workSheet.Cells[40, 10] = $"{sectionForeman}";
                    workSheet.Cells[41, 9] = $"подпись";
                    workSheet.Cells[41, 10] = $"расшифровка подписи";
                    workSheet.Cells[29, 13] = $"\nСдал: {post}\n";
                    workSheet.Cells[31, 13] = $"должность";
                    workSheet.Cells[33, 14] = $"{representative}";
                    workSheet.Cells[34, 13] = $"подпись";
                    workSheet.Cells[34, 14] = $"расшифровка подписи";
                    workSheet.Cells[36, 13] = $"\nПринял: {post}\n";
                    workSheet.Cells[38, 13] = $"должность";
                    workSheet.Cells[40, 14] = $"{representative}";
                    workSheet.Cells[41, 13] = $"подпись";
                    workSheet.Cells[41, 14] = $"расшифровка подписи";
                    workSheet.Cells[42, 12] = $"Ведомость измерения параметров получил";
                    workSheet.Cells[43, 12] = $"Удостоверение \"№\":{numberIdentification}";

                    int s = 1;
                    int j = 8;

                    for (int i = 0; i < radiostantionsCollection.Count; i++)
                    {
                        workSheet.Cells[7 + s, 1] = s;
                        workSheet.Cells[7 + s, 9] = s;

                        Excel.Range _excelCells22 = (Excel.Range)workSheet.get_Range($"B{j}", $"C{j}").Cells;
                        _excelCells22.Merge(Type.Missing);
                        _excelCells22.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        workSheet.Cells[7 + s, 2] = radiostantionsCollection[i].SerialNumber;

                        Excel.Range _excelCells23 = (Excel.Range)workSheet.get_Range($"J{j}", $"K{j}").Cells;
                        _excelCells23.Merge(Type.Missing);
                        _excelCells23.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        workSheet.Cells[7 + s, 10] = radiostantionsCollection[i].SerialNumber;

                        Excel.Range _excelCells24 = (Excel.Range)workSheet.get_Range($"D{j}").Cells;
                        _excelCells24.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        workSheet.Cells[7 + s, 4] = radiostantionsCollection[i].Battery;

                        Excel.Range _excelCells25 = (Excel.Range)workSheet.get_Range($"K{j}").Cells;
                        _excelCells25.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        workSheet.Cells[7 + s, 12] = radiostantionsCollection[i].Battery;

                        Excel.Range _excelCells26 = (Excel.Range)workSheet.get_Range($"E{j}").Cells;
                        _excelCells26.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        workSheet.Cells[7 + s, 5] = radiostantionsCollection[i].Charger;

                        Excel.Range _excelCells27 = (Excel.Range)workSheet.get_Range($"L{j}").Cells;
                        _excelCells27.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        workSheet.Cells[7 + s, 13] = radiostantionsCollection[i].Charger;

                        Excel.Range _excelCells28 = (Excel.Range)workSheet.get_Range($"F{j}").Cells;
                        _excelCells28.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        workSheet.Cells[7 + s, 6] = radiostantionsCollection[i].Antenna;

                        Excel.Range _excelCells29 = (Excel.Range)workSheet.get_Range($"M{j}").Cells;
                        _excelCells29.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        workSheet.Cells[7 + s, 14] = radiostantionsCollection[i].Antenna;

                        Excel.Range _excelCells30 = (Excel.Range)workSheet.get_Range($"G{j}").Cells;
                        _excelCells30.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        workSheet.Cells[7 + s, 7] = "-"; 

                        Excel.Range _excelCells31 = (Excel.Range)workSheet.get_Range($"N{j}").Cells;
                        _excelCells31.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        workSheet.Cells[7 + s, 15] = "-"; 

                        s++;
                        j++;
                    }

                    while (s <= 20)
                    {
                        workSheet.Cells[7 + s, 1] = s;
                        workSheet.Cells[7 + s, 9] = s;

                        Excel.Range _excelCells22 = (Excel.Range)workSheet.get_Range($"B{j}", $"C{j}").Cells;
                        _excelCells22.Merge(Type.Missing);
                        _excelCells22.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        Excel.Range _excelCells23 = (Excel.Range)workSheet.get_Range($"J{j}", $"K{j}").Cells;
                        _excelCells23.Merge(Type.Missing);
                        _excelCells23.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        Excel.Range _excelCells24 = (Excel.Range)workSheet.get_Range($"D{j}").Cells;
                        _excelCells24.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        Excel.Range _excelCells25 = (Excel.Range)workSheet.get_Range($"K{j}").Cells;
                        _excelCells25.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        Excel.Range _excelCells26 = (Excel.Range)workSheet.get_Range($"E{j}").Cells;
                        _excelCells26.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        Excel.Range _excelCells27 = (Excel.Range)workSheet.get_Range($"L{j}").Cells;
                        _excelCells27.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        Excel.Range _excelCells28 = (Excel.Range)workSheet.get_Range($"F{j}").Cells;
                        _excelCells28.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        Excel.Range _excelCells29 = (Excel.Range)workSheet.get_Range($"M{j}").Cells;
                        _excelCells29.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        Excel.Range _excelCells30 = (Excel.Range)workSheet.get_Range($"G{j}").Cells;
                        _excelCells30.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        Excel.Range _excelCells31 = (Excel.Range)workSheet.get_Range($"N{j}").Cells;
                        _excelCells31.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        s++;
                        j++;
                    }

                    #endregion

                    #region Ведомость


                    workSheet2.PageSetup.Zoom = false;
                    workSheet2.PageSetup.FitToPagesWide = 1;
                    workSheet2.PageSetup.FitToPagesTall = 1;

                    workSheet2.Rows.Font.Size = 15;
                    workSheet2.Rows.Font.Name = "Times New Roman";

                    workSheet2.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                    workSheet2.PageSetup.CenterHorizontally = true;
                    workSheet2.PageSetup.CenterVertically = true;
                    workSheet2.PageSetup.TopMargin = 0;
                    workSheet2.PageSetup.BottomMargin = 0;
                    workSheet2.PageSetup.LeftMargin = 0;
                    workSheet2.PageSetup.RightMargin = 0;

                    Excel.Range _excelCells200 = (Excel.Range)workSheet2.get_Range("A1", "G1").Cells;
                    Excel.Range _excelCells201 = (Excel.Range)workSheet2.get_Range("H1", "I1").Cells;
                    Excel.Range _excelCells202 = (Excel.Range)workSheet2.get_Range("J1", "K1").Cells;
                    Excel.Range _excelCells203 = (Excel.Range)workSheet2.get_Range("L1", "M1").Cells;
                    Excel.Range _excelCells204 = (Excel.Range)workSheet2.get_Range("T1", "Y1").Cells;
                    Excel.Range _excelCells205 = (Excel.Range)workSheet2.get_Range("A2", "A19").Cells;
                    Excel.Range _excelCells206 = (Excel.Range)workSheet2.get_Range("B2", "C2").Cells;
                    Excel.Range _excelCells207 = (Excel.Range)workSheet2.get_Range("B3", "B19").Cells;
                    Excel.Range _excelCells208 = (Excel.Range)workSheet2.get_Range("C3", "C19").Cells;
                    Excel.Range _excelCells209 = (Excel.Range)workSheet2.get_Range("D2", "I2").Cells;
                    Excel.Range _excelCells210 = (Excel.Range)workSheet2.get_Range("D3", "E6").Cells;
                    Excel.Range _excelCells211 = (Excel.Range)workSheet2.get_Range("D7", "D19").Cells;
                    Excel.Range _excelCells212 = (Excel.Range)workSheet2.get_Range("E7", "E19").Cells;
                    Excel.Range _excelCells213 = (Excel.Range)workSheet2.get_Range("F3", "F19").Cells;
                    Excel.Range _excelCells214 = (Excel.Range)workSheet2.get_Range("G3", "G19").Cells;
                    Excel.Range _excelCells215 = (Excel.Range)workSheet2.get_Range("H3", "H19").Cells;
                    Excel.Range _excelCells216 = (Excel.Range)workSheet2.get_Range("I3", "I19").Cells;
                    Excel.Range _excelCells217 = (Excel.Range)workSheet2.get_Range("J2", "O2").Cells;
                    Excel.Range _excelCells218 = (Excel.Range)workSheet2.get_Range("J3", "J19").Cells;
                    Excel.Range _excelCells219 = (Excel.Range)workSheet2.get_Range("K3", "L18").Cells;
                    Excel.Range _excelCells220 = (Excel.Range)workSheet2.get_Range("K19").Cells;
                    Excel.Range _excelCells221 = (Excel.Range)workSheet2.get_Range("L19").Cells;
                    Excel.Range _excelCells222 = (Excel.Range)workSheet2.get_Range("M3", "M19").Cells;
                    Excel.Range _excelCells223 = (Excel.Range)workSheet2.get_Range("N3", "N19").Cells;
                    Excel.Range _excelCells224 = (Excel.Range)workSheet2.get_Range("O3", "O19").Cells;
                    Excel.Range _excelCells225 = (Excel.Range)workSheet2.get_Range("P2", "R5").Cells;
                    Excel.Range _excelCells226 = (Excel.Range)workSheet2.get_Range("P6", "P19").Cells;
                    Excel.Range _excelCells227 = (Excel.Range)workSheet2.get_Range("Q6", "Q19").Cells;
                    Excel.Range _excelCells228 = (Excel.Range)workSheet2.get_Range("R6", "R19").Cells;
                    Excel.Range _excelCells229 = (Excel.Range)workSheet2.get_Range("S2", "S19").Cells;
                    Excel.Range _excelCells230 = (Excel.Range)workSheet2.get_Range("T2", "U4").Cells;
                    Excel.Range _excelCells231 = (Excel.Range)workSheet2.get_Range("T5", "T19").Cells;
                    Excel.Range _excelCells232 = (Excel.Range)workSheet2.get_Range("U5", "U19").Cells;
                    Excel.Range _excelCells233 = (Excel.Range)workSheet2.get_Range("V2", "Y2").Cells;
                    Excel.Range _excelCells234 = (Excel.Range)workSheet2.get_Range("V3", "W3").Cells;
                    Excel.Range _excelCells235 = (Excel.Range)workSheet2.get_Range("X3", "Y3").Cells;
                    Excel.Range _excelCells238 = (Excel.Range)workSheet2.get_Range("A2", "U39").Cells;
                    Excel.Range _excelCells240 = (Excel.Range)workSheet2.get_Range("V4", "Y39").Cells;
                    Excel.Range _excelCells241 = (Excel.Range)workSheet2.get_Range("V3", "Y3").Cells;
                    Excel.Range _excelCells243 = (Excel.Range)workSheet2.get_Range("A41").Cells;
                    Excel.Range _excelCells244 = (Excel.Range)workSheet2.get_Range("B41", "G41").Cells;
                    Excel.Range _excelCells245 = (Excel.Range)workSheet2.get_Range("H41", "J41").Cells;
                    Excel.Range _excelCells246 = (Excel.Range)workSheet2.get_Range("K41", "P41").Cells;
                    Excel.Range _excelCells247 = (Excel.Range)workSheet2.get_Range("T41", "Y41").Cells;
                    Excel.Range _excelCells248 = (Excel.Range)workSheet2.get_Range("B42", "G42").Cells;
                    Excel.Range _excelCells249 = (Excel.Range)workSheet2.get_Range("H42", "J42").Cells;
                    Excel.Range _excelCells250 = (Excel.Range)workSheet2.get_Range("K42", "P42").Cells;
                    Excel.Range _excelCells251 = (Excel.Range)workSheet2.get_Range("B44", "G44").Cells;
                    Excel.Range _excelCells252 = (Excel.Range)workSheet2.get_Range("H44", "J44").Cells;
                    Excel.Range _excelCells253 = (Excel.Range)workSheet2.get_Range("K44", "P44").Cells;
                    Excel.Range _excelCells254 = (Excel.Range)workSheet2.get_Range("B45", "G45").Cells;
                    Excel.Range _excelCells255 = (Excel.Range)workSheet2.get_Range("H45", "J45").Cells;
                    Excel.Range _excelCells256 = (Excel.Range)workSheet2.get_Range("K45", "P45").Cells;
                    Excel.Range _excelCells257 = (Excel.Range)workSheet2.get_Range("T42", "Y42").Cells;
                    Excel.Range _excelCells258 = (Excel.Range)workSheet2.get_Range("S44", "U44").Cells;
                    Excel.Range _excelCells259 = (Excel.Range)workSheet2.get_Range("V44", "X44").Cells;
                    Excel.Range _excelCells260 = (Excel.Range)workSheet2.get_Range("B47", "F47").Cells;
                    Excel.Range _excelCells261 = (Excel.Range)workSheet2.get_Range("H47", "L47").Cells;
                    Excel.Range _excelCells262 = (Excel.Range)workSheet2.get_Range("D2", "I39").Cells;
                    Excel.Range _excelCells263 = (Excel.Range)workSheet2.get_Range("J2", "O39").Cells;
                    Excel.Range _excelCells264 = (Excel.Range)workSheet2.get_Range("B2", "C39").Cells;
                    Excel.Range _excelCells265 = (Excel.Range)workSheet2.get_Range("P2", "S39").Cells;
                    Excel.Range _excelCells266 = (Excel.Range)workSheet2.get_Range("A2", "A39").Cells;
                    Excel.Range _excelCells267 = (Excel.Range)workSheet2.get_Range("T2", "U39").Cells;
                    Excel.Range _excelCells268 = (Excel.Range)workSheet2.get_Range("V2", "Y39").Cells;
                    Excel.Range _excelCells269 = (Excel.Range)workSheet2.get_Range("A20", "U39").Cells;

                    _excelCells200.Merge(Type.Missing);
                    _excelCells201.Merge(Type.Missing);
                    _excelCells202.Merge(Type.Missing);
                    _excelCells203.Merge(Type.Missing);
                    _excelCells204.Merge(Type.Missing);
                    _excelCells205.Merge(Type.Missing);
                    _excelCells206.Merge(Type.Missing);
                    _excelCells207.Merge(Type.Missing);
                    _excelCells208.Merge(Type.Missing);
                    _excelCells209.Merge(Type.Missing);
                    _excelCells210.Merge(Type.Missing);
                    _excelCells211.Merge(Type.Missing);
                    _excelCells212.Merge(Type.Missing);
                    _excelCells213.Merge(Type.Missing);
                    _excelCells214.Merge(Type.Missing);
                    _excelCells215.Merge(Type.Missing);
                    _excelCells216.Merge(Type.Missing);
                    _excelCells217.Merge(Type.Missing);
                    _excelCells218.Merge(Type.Missing);
                    _excelCells219.Merge(Type.Missing);
                    _excelCells222.Merge(Type.Missing);
                    _excelCells223.Merge(Type.Missing);
                    _excelCells224.Merge(Type.Missing);
                    _excelCells225.Merge(Type.Missing);
                    _excelCells226.Merge(Type.Missing);
                    _excelCells227.Merge(Type.Missing);
                    _excelCells228.Merge(Type.Missing);
                    _excelCells229.Merge(Type.Missing);
                    _excelCells230.Merge(Type.Missing);
                    _excelCells231.Merge(Type.Missing);
                    _excelCells232.Merge(Type.Missing);
                    _excelCells233.Merge(Type.Missing);
                    _excelCells234.Merge(Type.Missing);
                    _excelCells235.Merge(Type.Missing);
                    _excelCells244.Merge(Type.Missing);
                    _excelCells245.Merge(Type.Missing);
                    _excelCells246.Merge(Type.Missing);
                    _excelCells247.Merge(Type.Missing);
                    _excelCells248.Merge(Type.Missing);
                    _excelCells249.Merge(Type.Missing);
                    _excelCells250.Merge(Type.Missing);
                    _excelCells251.Merge(Type.Missing);
                    _excelCells252.Merge(Type.Missing);
                    _excelCells253.Merge(Type.Missing);
                    _excelCells254.Merge(Type.Missing);
                    _excelCells255.Merge(Type.Missing);
                    _excelCells256.Merge(Type.Missing);
                    _excelCells257.Merge(Type.Missing);
                    _excelCells258.Merge(Type.Missing);
                    _excelCells259.Merge(Type.Missing);
                    _excelCells260.Merge(Type.Missing);
                    _excelCells261.Merge(Type.Missing);

                    _excelCells238.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells238.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells238.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells238.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells238.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells238.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

                    _excelCells233.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells233.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells233.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells233.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;

                    _excelCells241.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells241.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells241.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells241.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;

                    _excelCells240.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells240.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells240.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells240.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells240.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells240.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

                    _excelCells244.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells245.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells246.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells247.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells251.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells252.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells253.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells259.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;

                    _excelCells262.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells262.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells262.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells262.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;

                    _excelCells263.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells263.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells263.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells263.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;

                    _excelCells264.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells264.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells264.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells264.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;

                    _excelCells265.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells265.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells265.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells265.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;

                    _excelCells266.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells266.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells266.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells266.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;

                    _excelCells267.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells267.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells267.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells267.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;

                    _excelCells268.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells268.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells268.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble;
                    _excelCells268.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;

                    _excelCells269.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDash;

                    _excelCells200.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    _excelCells201.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    _excelCells202.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    _excelCells203.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    _excelCells204.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells205.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells205.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells206.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    _excelCells207.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells207.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells207.Orientation = 90;

                    _excelCells208.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells208.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells208.Orientation = 90;

                    _excelCells209.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    _excelCells210.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells210.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    _excelCells211.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells211.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells211.Orientation = 90;

                    _excelCells212.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells212.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells212.Orientation = 90;

                    _excelCells213.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells213.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells213.Orientation = 90;

                    _excelCells214.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells214.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells214.Orientation = 90;

                    _excelCells215.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells215.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells215.Orientation = 90;

                    _excelCells216.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells216.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells216.Orientation = 90;

                    _excelCells217.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    _excelCells218.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells218.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells218.Orientation = 90;

                    _excelCells219.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells219.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells219.Orientation = 90;

                    _excelCells220.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    _excelCells221.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    _excelCells222.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells222.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells222.Orientation = 90;

                    _excelCells223.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells223.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells223.Orientation = 90;

                    _excelCells224.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells224.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells224.Orientation = 90;

                    _excelCells225.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells225.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    _excelCells226.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells226.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells226.Orientation = 90;

                    _excelCells227.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells227.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells227.Orientation = 90;

                    _excelCells228.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells228.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells228.Orientation = 90;

                    _excelCells229.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells229.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells229.Orientation = 90;

                    _excelCells230.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells230.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    _excelCells231.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells231.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells231.Orientation = 90;

                    _excelCells232.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells232.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells232.Orientation = 90;

                    _excelCells233.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells234.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    _excelCells235.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells243.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    _excelCells244.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells246.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells247.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells248.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells249.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells250.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells251.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells252.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells253.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells254.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells255.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells256.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells257.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells258.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells259.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells260.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells261.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    Excel.Range rowHeight200 = workSheet2.get_Range("A1", "G1");
                    rowHeight200.EntireRow.RowHeight = 15; //

                    Excel.Range rowColum200 = workSheet2.get_Range("A1", "G1");
                    rowColum200.EntireColumn.ColumnWidth = 5; //

                    Excel.Range rowHeight201 = workSheet2.get_Range("A2", "A19");
                    rowHeight201.EntireRow.RowHeight = 15; //

                    Excel.Range rowColum201 = workSheet2.get_Range("A2", "A19");
                    rowColum201.EntireColumn.ColumnWidth = 25; //

                    Excel.Range rowColum202 = workSheet2.get_Range("B2", "C2");
                    rowColum202.EntireColumn.ColumnWidth = 8;

                    Excel.Range rowColum203 = workSheet2.get_Range("D7", "E7");
                    rowColum203.EntireColumn.ColumnWidth = 8;

                    Excel.Range rowColum204 = workSheet2.get_Range("F3", "F14");
                    rowColum204.EntireColumn.ColumnWidth = 8;

                    Excel.Range rowColum205 = workSheet2.get_Range("G3", "G14");
                    rowColum205.EntireColumn.ColumnWidth = 8;

                    Excel.Range rowColum206 = workSheet2.get_Range("H3", "H14");
                    rowColum206.EntireColumn.ColumnWidth = 8;

                    Excel.Range rowColum207 = workSheet2.get_Range("I3", "I14");
                    rowColum207.EntireColumn.ColumnWidth = 8;

                    Excel.Range rowColum208 = workSheet2.get_Range("V4", "V19");
                    rowColum208.EntireColumn.ColumnWidth = 8;

                    Excel.Range rowColum209 = workSheet2.get_Range("X3", "Y3");
                    rowColum209.EntireColumn.ColumnWidth = 15;

                    Excel.Range rowHeight210 = workSheet2.get_Range("A20", "A39");
                    rowHeight210.EntireRow.RowHeight = 25; //

                    Excel.Range rowHeight211 = workSheet2.get_Range("A42", "Y42");
                    rowHeight211.EntireRow.RowHeight = 12; //

                    Excel.Range rowHeight212 = workSheet2.get_Range("A45", "P45");
                    rowHeight212.EntireRow.RowHeight = 12; //

                    Excel.Range rowHeight213 = workSheet2.get_Range("B47", "L47");
                    rowHeight213.EntireRow.RowHeight = 12; //

                    Excel.Range rowColum214 = workSheet2.get_Range("V3", "W3");
                    rowColum214.EntireColumn.ColumnWidth = 2;

                    Excel.Range rowHeight215 = workSheet2.get_Range("V4", "V19");
                    rowHeight215.EntireRow.RowHeight = 20;

                    Excel.Range rowColum216 = workSheet2.get_Range("B3", "B19");
                    rowColum216.EntireColumn.ColumnWidth = 15;

                    Excel.Range rowHeight217 = workSheet2.get_Range("A1", "Y1");
                    rowHeight217.EntireRow.RowHeight = 25;

                    Excel.Range rowHeight218 = workSheet2.get_Range("A2", "Y2");
                    rowHeight218.EntireRow.RowHeight = 20;

                    Excel.Range rowHeight219 = workSheet2.get_Range("A20", "A39");
                    rowHeight219.EntireRow.RowHeight = 25;

                    Excel.Range range_Consolidated200 = workSheet2.Rows.get_Range("H1", "I1");
                    Excel.Range range_Consolidated201 = workSheet2.Rows.get_Range("L1", "M1");
                    Excel.Range range_Consolidated202 = workSheet2.Rows.get_Range("T1", "V1");
                    Excel.Range range_Consolidated203 = workSheet2.Rows.get_Range("V4", "V19");
                    Excel.Range range_Consolidated204 = workSheet2.Rows.get_Range("A42", "Y42");
                    Excel.Range range_Consolidated205 = workSheet2.Rows.get_Range("A45", "P45");
                    Excel.Range range_Consolidated206 = workSheet2.Rows.get_Range("V44", "X44");
                    Excel.Range range_Consolidated207 = workSheet2.Rows.get_Range("B47", "L47");
                    Excel.Range range_Consolidated208 = workSheet2.Rows.get_Range("A2", "U19");
                    Excel.Range range_Consolidated209 = workSheet2.Rows.get_Range("A1", "G1");
                    Excel.Range range_Consolidated210 = workSheet2.Rows.get_Range("A20", "A39");
                    Excel.Range range_Consolidated211 = workSheet2.Rows.get_Range("K41", "P41");
                    Excel.Range range_Consolidated212 = workSheet2.Rows.get_Range("T41", "Y41");
                    Excel.Range range_Consolidated213 = workSheet2.Rows.get_Range("A20", "A39");
                    Excel.Range range_Consolidated243 = workSheet2.Rows.get_Range("B20", "B39");

                    range_Consolidated200.Font.Size = 18;
                    range_Consolidated200.Font.Bold = true;
                    range_Consolidated201.Font.Size = 18;
                    range_Consolidated201.Font.Bold = true;
                    range_Consolidated202.Font.Size = 18;
                    range_Consolidated202.Font.Bold = true;
                    range_Consolidated203.Font.Size = 10;
                    range_Consolidated203.Font.Bold = true;
                    range_Consolidated204.Font.Size = 10;
                    range_Consolidated205.Font.Size = 10;
                    range_Consolidated206.Font.Bold = true;
                    range_Consolidated207.Font.Size = 10;
                    range_Consolidated208.Font.Bold = true;
                    range_Consolidated209.Font.Size = 16;
                    range_Consolidated210.Font.Size = 18;
                    range_Consolidated210.Font.Bold = true;
                    range_Consolidated211.Font.Bold = true;
                    range_Consolidated212.Font.Bold = true;
                    range_Consolidated213.NumberFormat = "@";
                    range_Consolidated243.Font.Size = 10;
                    range_Consolidated243.NumberFormat = "@";

                    workSheet2.Cells[1, 1] = $"Ведомость проверки параметров радиостанций №:";
                    workSheet2.Cells[1, 8] = $"{numberAct}";
                    workSheet2.Cells[1, 10] = $"Предприятие:";
                    workSheet2.Cells[1, 12] = $"{company}";
                    workSheet2.Cells[1, 20] = $"{location}";
                    workSheet2.Cells[2, 1] = $"№ р/с";
                    workSheet2.Cells[2, 2] = $"АКБ";
                    workSheet2.Cells[3, 2] = $"серия, № АКБ";
                    workSheet2.Cells[3, 3] = $"Остаточная ёмкость АКБ, %";
                    workSheet2.Cells[2, 4] = $"Параметры передатчика";
                    workSheet2.Cells[3, 4] = $"Выходная\n мощность передатчика, Вт";
                    workSheet2.Cells[7, 4] = $"Низкий уровень";
                    workSheet2.Cells[7, 5] = $"Высокий уровень";
                    workSheet2.Cells[3, 6] = $"Отклонение частоты\n от номинала, Гц";
                    workSheet2.Cells[3, 7] = $"КНИ, %";
                    workSheet2.Cells[3, 8] = $"Чувствительность\n модуляционного входа, мВ";
                    workSheet2.Cells[3, 9] = $"Максимальная девиация\n частоты, кГц";
                    workSheet2.Cells[2, 10] = $"Параметры приёмника";
                    workSheet2.Cells[3, 10] = $"Чувствительность\n приемника, мкВ";
                    workSheet2.Cells[3, 11] = $"Выходная мощность приёмника, В";
                    workSheet2.Cells[19, 11] = $"В";
                    workSheet2.Cells[19, 12] = $"Вт";
                    workSheet2.Cells[3, 13] = $"Избирательность\n по соседнему каналу, дБ";
                    workSheet2.Cells[3, 14] = $"КНИ, %";
                    workSheet2.Cells[3, 15] = $"Порог срабатывания\n шумоподавителя, мкВ";
                    workSheet2.Cells[2, 16] = $"Потребляемый ток";
                    workSheet2.Cells[6, 16] = $"\"Дежурный режим\", мА";
                    workSheet2.Cells[6, 17] = $"\"Режим приём, мА\", мА";
                    workSheet2.Cells[6, 18] = $"\"Режим передачи\n (высокая мощность)\", А";
                    workSheet2.Cells[2, 19] = $"Сигнализация разряда АКБ, В";
                    workSheet2.Cells[2, 20] = $"Аксессуары \n(при наличии)";
                    workSheet2.Cells[5, 20] = $"ЗУ испр / неиспр";
                    workSheet2.Cells[5, 21] = $"Манипулятор: \n испр / неиспр";
                    workSheet2.Cells[2, 22] = $"Частоты (МГц)";
                    workSheet2.Cells[3, 22] = $"";
                    workSheet2.Cells[3, 24] = $"передача / приём    ";
                    workSheet2.Cells[41, 1] = $"Исполнитель работ:";
                    workSheet2.Cells[41, 2] = $"Инженер по ТО и ремонту СРС";
                    workSheet2.Cells[41, 8] = $"/                                     /";
                    workSheet2.Cells[41, 11] = $"{engineer}";
                    workSheet2.Cells[41, 20] = $"{dateMaintenance} г.";
                    workSheet2.Cells[42, 2] = $"должность";
                    workSheet2.Cells[42, 8] = $"подпись";
                    workSheet2.Cells[42, 11] = $"расшифровка подписи";
                    workSheet2.Cells[42, 20] = $"дата проведения технического обслуживания";
                    workSheet2.Cells[44, 1] = $"Представитель РЦС:";
                    workSheet2.Cells[44, 2] = $"";
                    workSheet2.Cells[44, 8] = $"/                                     /";
                    workSheet2.Cells[44, 11] = $"";
                    workSheet2.Cells[45, 2] = $"должность";
                    workSheet2.Cells[45, 8] = $"подпись";
                    workSheet2.Cells[45, 11] = $"расшифровка подписи";
                    workSheet2.Cells[44, 19] = $"Частота проверки:";
                    workSheet2.Cells[44, 22] = $"151.825";
                    workSheet2.Cells[47, 2] = $"Примечание: 1. \" - \" - не предоставлено для ТО";
                    workSheet2.Cells[47, 8] = $"2. \" б/н \" - без номера (номер отсутсвует)";


                    int s3 = 1;
                    int j3 = 4;

                    for (int i = 0; i < 16; i++)
                    {
                        workSheet2.Cells[3 + s3, 22] = s3;
                        Excel.Range _excelCells236 = (Excel.Range)workSheet2.get_Range($"V{j3}").Cells;
                        _excelCells236.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                        Excel.Range _excelCells237 = (Excel.Range)workSheet2.get_Range($"W{j3}", $"Y{j3}").Cells;
                        _excelCells237.Merge(Type.Missing);

                        s3++;
                        j3++;
                    }
                    int j4 = 20;
                    int s4 = 1;
                    for (int i = 0; i < radiostantionsCollection.Count; i++)
                    {
                        Excel.Range _excelCells242 = (Excel.Range)workSheet2.get_Range($"A{j4}").Cells;
                        _excelCells242.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        _excelCells242.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        Excel.Range _excelCells270 = (Excel.Range)workSheet2.get_Range($"B{j4}").Cells;
                        _excelCells270.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        _excelCells270.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        workSheet2.Cells[19 + s4, 1] = radiostantionsCollection[i].SerialNumber;
                        workSheet2.Cells[19 + s4, 2] = radiostantionsCollection[i].Battery;

                        Excel.Range _excelCells239 = (Excel.Range)workSheet2.get_Range($"V{j4}", $"Y{j4}").Cells;
                        _excelCells239.Merge(Type.Missing);

                        s4++;
                        j4++;

                    }
                    while (s4 <= 20)
                    {
                        Excel.Range _excelCells242 = (Excel.Range)workSheet2.get_Range($"A{j4}").Cells;
                        _excelCells242.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        Excel.Range _excelCells239 = (Excel.Range)workSheet2.get_Range($"V{j4}", $"Y{j4}").Cells;
                        _excelCells239.Merge(Type.Missing);

                        s4++;
                        j4++;
                    }


                    #endregion

                    #region АКТ

                    workSheet3.PageSetup.Zoom = false;
                    workSheet3.PageSetup.FitToPagesWide = 1;
                    workSheet3.PageSetup.FitToPagesTall = 1;

                    workSheet3.Rows.Font.Size = 11;
                    workSheet3.Rows.Font.Name = "Times New Roman";

                    workSheet2.PageSetup.CenterHorizontally = true;
                    workSheet2.PageSetup.CenterVertically = true;
                    workSheet3.PageSetup.TopMargin = 50;
                    workSheet3.PageSetup.BottomMargin = 0;
                    workSheet3.PageSetup.LeftMargin = 90;
                    workSheet3.PageSetup.RightMargin = 0;

                    workSheet3.PageSetup.Zoom = 97;

                    Excel.Range _excelCells101 = (Excel.Range)workSheet3.get_Range("A1", "I1").Cells;
                    Excel.Range _excelCells102 = (Excel.Range)workSheet3.get_Range("A2", "I2").Cells;
                    Excel.Range _excelCells103 = (Excel.Range)workSheet3.get_Range("A4", "C4").Cells;
                    Excel.Range _excelCells104 = (Excel.Range)workSheet3.get_Range("H4", "I4").Cells;
                    Excel.Range _excelCells105 = (Excel.Range)workSheet3.get_Range("A5", "C5").Cells;
                    Excel.Range _excelCells106 = (Excel.Range)workSheet3.get_Range("H5", "I5").Cells;
                    Excel.Range _excelCells107 = (Excel.Range)workSheet3.get_Range("A6", "G6").Cells;
                    Excel.Range _excelCells108 = (Excel.Range)workSheet3.get_Range("A7", "I7").Cells;
                    Excel.Range _excelCells109 = (Excel.Range)workSheet3.get_Range("A8", "G8").Cells;
                    Excel.Range _excelCells110 = (Excel.Range)workSheet3.get_Range("H8", "I8").Cells;
                    Excel.Range _excelCells111 = (Excel.Range)workSheet3.get_Range("A9", "I9").Cells;
                    Excel.Range _excelCells112 = (Excel.Range)workSheet3.get_Range("A10", "I10").Cells;
                    Excel.Range _excelCells113 = (Excel.Range)workSheet3.get_Range("A11", "E11").Cells;
                    Excel.Range _excelCells114 = (Excel.Range)workSheet3.get_Range("A12", "E12").Cells;
                    Excel.Range _excelCells115 = (Excel.Range)workSheet3.get_Range("G12", "I12").Cells;
                    Excel.Range _excelCells116 = (Excel.Range)workSheet3.get_Range("A13", "C13").Cells;
                    Excel.Range _excelCells117 = (Excel.Range)workSheet3.get_Range("D13", "E13").Cells;
                    Excel.Range _excelCells118 = (Excel.Range)workSheet3.get_Range("F13", "G13").Cells;
                    Excel.Range _excelCells119 = (Excel.Range)workSheet3.get_Range("A14", "I14").Cells;
                    Excel.Range _excelCells120 = (Excel.Range)workSheet3.get_Range("A15", "I15").Cells;
                    Excel.Range _excelCells121 = (Excel.Range)workSheet3.get_Range("A16", "I16").Cells;
                    Excel.Range _excelCells122 = (Excel.Range)workSheet3.get_Range("A18", "A37").Cells;
                    Excel.Range _excelCells123 = (Excel.Range)workSheet3.get_Range("A17").Cells;
                    Excel.Range _excelCells124 = (Excel.Range)workSheet3.get_Range("B17", "C17").Cells;
                    Excel.Range _excelCells125 = (Excel.Range)workSheet3.get_Range("D17", "F17").Cells;
                    Excel.Range _excelCells126 = (Excel.Range)workSheet3.get_Range("G17", "I17").Cells;
                    Excel.Range _excelCells127 = (Excel.Range)workSheet3.get_Range("A17", "I37").Cells;
                    Excel.Range _excelCells131 = (Excel.Range)workSheet3.get_Range("A38", "I38").Cells;
                    Excel.Range _excelCells132 = (Excel.Range)workSheet3.get_Range("A39", "I39").Cells;
                    Excel.Range _excelCells133 = (Excel.Range)workSheet3.get_Range("A40", "I40").Cells;
                    Excel.Range _excelCells134 = (Excel.Range)workSheet3.get_Range("A41", "I41").Cells;
                    Excel.Range _excelCells135 = (Excel.Range)workSheet3.get_Range("A42", "C42").Cells;
                    Excel.Range _excelCells136 = (Excel.Range)workSheet3.get_Range("F42", "H42").Cells;
                    Excel.Range _excelCells137 = (Excel.Range)workSheet3.get_Range("A43", "C43").Cells;
                    Excel.Range _excelCells138 = (Excel.Range)workSheet3.get_Range("C45", "D45").Cells;
                    Excel.Range _excelCells139 = (Excel.Range)workSheet3.get_Range("F44", "G44").Cells;
                    Excel.Range _excelCells140 = (Excel.Range)workSheet3.get_Range("H44", "I44").Cells;
                    Excel.Range _excelCells141 = (Excel.Range)workSheet3.get_Range("A46", "B46").Cells;
                    Excel.Range _excelCells142 = (Excel.Range)workSheet3.get_Range("C46", "D46").Cells;
                    Excel.Range _excelCells143 = (Excel.Range)workSheet3.get_Range("F45", "G45").Cells;
                    Excel.Range _excelCells144 = (Excel.Range)workSheet3.get_Range("A47", "B47").Cells;
                    Excel.Range _excelCells145 = (Excel.Range)workSheet3.get_Range("A49", "D49").Cells;
                    Excel.Range _excelCells146 = (Excel.Range)workSheet3.get_Range("A50", "B50").Cells;
                    Excel.Range _excelCells147 = (Excel.Range)workSheet3.get_Range("C50", "D50").Cells;
                    Excel.Range _excelCells148 = (Excel.Range)workSheet3.get_Range("G11", "I11").Cells;
                    Excel.Range _excelCells150 = (Excel.Range)workSheet3.get_Range("D47");
                    Excel.Range _excelCells151 = (Excel.Range)workSheet3.get_Range("G47");
                    Excel.Range _excelCells152 = (Excel.Range)workSheet3.get_Range("A45", "B45").Cells;
                    Excel.Range _excelCells153 = (Excel.Range)workSheet3.get_Range("H45", "I45").Cells;
                    Excel.Range _excelCells154 = (Excel.Range)workSheet3.get_Range("H13", "I13").Cells;
                    Excel.Range _excelCells155 = (Excel.Range)workSheet3.get_Range("A17", "I17").Cells;

                    _excelCells101.Merge(Type.Missing);
                    _excelCells102.Merge(Type.Missing);
                    _excelCells103.Merge(Type.Missing);
                    _excelCells104.Merge(Type.Missing);
                    _excelCells105.Merge(Type.Missing);
                    _excelCells106.Merge(Type.Missing);
                    _excelCells107.Merge(Type.Missing);
                    _excelCells108.Merge(Type.Missing);
                    _excelCells109.Merge(Type.Missing);
                    _excelCells110.Merge(Type.Missing);
                    _excelCells111.Merge(Type.Missing);
                    _excelCells112.Merge(Type.Missing);
                    _excelCells113.Merge(Type.Missing);
                    _excelCells114.Merge(Type.Missing);
                    _excelCells115.Merge(Type.Missing);
                    _excelCells116.Merge(Type.Missing);
                    _excelCells117.Merge(Type.Missing);
                    _excelCells118.Merge(Type.Missing);
                    _excelCells119.Merge(Type.Missing);
                    _excelCells120.Merge(Type.Missing);
                    _excelCells121.Merge(Type.Missing);
                    _excelCells124.Merge(Type.Missing);
                    _excelCells125.Merge(Type.Missing);
                    _excelCells126.Merge(Type.Missing);
                    _excelCells131.Merge(Type.Missing);
                    _excelCells132.Merge(Type.Missing);
                    _excelCells133.Merge(Type.Missing);
                    _excelCells134.Merge(Type.Missing);
                    _excelCells135.Merge(Type.Missing);
                    _excelCells136.Merge(Type.Missing);
                    _excelCells137.Merge(Type.Missing);
                    _excelCells138.Merge(Type.Missing);
                    _excelCells139.Merge(Type.Missing);
                    _excelCells140.Merge(Type.Missing);
                    _excelCells141.Merge(Type.Missing);
                    _excelCells142.Merge(Type.Missing);
                    _excelCells143.Merge(Type.Missing);
                    _excelCells144.Merge(Type.Missing);
                    _excelCells145.Merge(Type.Missing);
                    _excelCells146.Merge(Type.Missing);
                    _excelCells147.Merge(Type.Missing);
                    _excelCells148.Merge(Type.Missing);
                    _excelCells152.Merge(Type.Missing);
                    _excelCells153.Merge(Type.Missing);
                    _excelCells154.Merge(Type.Missing);

                    _excelCells101.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells102.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells103.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells104.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells105.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells106.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells107.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    _excelCells108.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    _excelCells109.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells110.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells111.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells112.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells113.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells113.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells114.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells115.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells116.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    _excelCells117.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells118.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    _excelCells119.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    _excelCells120.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    _excelCells121.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    _excelCells122.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells123.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells124.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells125.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells126.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells131.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    _excelCells132.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    _excelCells133.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    _excelCells134.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    _excelCells135.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    _excelCells136.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    _excelCells137.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    _excelCells138.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells140.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells141.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells142.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells143.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells144.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    _excelCells145.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells146.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells147.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells148.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells150.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells151.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells153.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells154.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells155.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _excelCells155.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;


                    _excelCells103.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells104.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells108.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    _excelCells111.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    _excelCells112.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    _excelCells113.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    _excelCells117.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    _excelCells127.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    _excelCells127.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDot;
                    _excelCells127.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDot;
                    _excelCells127.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDot;
                    _excelCells127.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;
                    _excelCells127.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;
                    _excelCells138.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells139.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells140.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells145.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells148.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    _excelCells152.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _excelCells154.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;

                    Excel.Range range_Consolidated102 = workSheet3.Rows.get_Range("A1", "H2");
                    Excel.Range range_Consolidated103 = workSheet3.Rows.get_Range("A4", "B4");
                    Excel.Range range_Consolidated104 = workSheet3.Rows.get_Range("A5", "I5");
                    Excel.Range range_Consolidated105 = workSheet3.Rows.get_Range("A6", "G6");
                    Excel.Range range_Consolidated106 = workSheet3.Rows.get_Range("A7", "I7");
                    Excel.Range range_Consolidated107 = workSheet3.Rows.get_Range("B8", "C8");
                    Excel.Range range_Consolidated108 = workSheet3.Rows.get_Range("H8", "I8");
                    Excel.Range range_Consolidated109 = workSheet3.Rows.get_Range("A9", "I9");
                    Excel.Range range_Consolidated110 = workSheet3.Rows.get_Range("A10", "I10");
                    Excel.Range range_Consolidated111 = workSheet3.Rows.get_Range("A11", "I11");
                    Excel.Range range_Consolidated112 = workSheet3.Rows.get_Range("B12", "C12");
                    Excel.Range range_Consolidated113 = workSheet3.Rows.get_Range("A12", "H12");
                    Excel.Range range_Consolidated114 = workSheet3.Rows.get_Range("A13", "C13");
                    Excel.Range range_Consolidated115 = workSheet3.Rows.get_Range("D13", "E13");
                    Excel.Range range_Consolidated116 = workSheet3.Rows.get_Range("F13", "I13");
                    Excel.Range range_Consolidated117 = workSheet3.Rows.get_Range("A14", "I14");
                    Excel.Range range_Consolidated118 = workSheet3.Rows.get_Range("A15", "I15");
                    Excel.Range range_Consolidated119 = workSheet3.Rows.get_Range("A16", "I16");
                    Excel.Range range_Consolidated120 = workSheet3.Rows.get_Range("B18", "I37");
                    Excel.Range range_Consolidated121 = workSheet3.Rows.get_Range("A17", "I17");
                    Excel.Range range_Consolidated122 = workSheet3.Rows.get_Range("A38", "I41");
                    Excel.Range range_Consolidated123 = workSheet3.Rows.get_Range("A42", "I43");
                    Excel.Range range_Consolidated124 = workSheet3.Rows.get_Range("A44", "I44");
                    Excel.Range range_Consolidated125 = workSheet3.Rows.get_Range("A46", "I46");
                    Excel.Range range_Consolidated126 = workSheet3.Rows.get_Range("A47", "B47");
                    Excel.Range range_Consolidated127 = workSheet3.Rows.get_Range("A50", "D50");
                    Excel.Range range_Consolidated128 = workSheet3.Rows.get_Range("D51");
                    Excel.Range range_Consolidated129 = workSheet3.Rows.get_Range("C45", "D45");
                    Excel.Range range_Consolidated130 = workSheet3.Rows.get_Range("F45", "I45");
                    Excel.Range range_Consolidated131 = workSheet3.Rows.get_Range("A18", "I37");
                    Excel.Range range_Consolidated132 = workSheet3.Rows.get_Range("D18", "F37");
                    Excel.Range range_Consolidated133 = workSheet3.Rows.get_Range("A11", "E11");


                    Excel.Range rowHeight100 = workSheet3.get_Range("A38", "I41");
                    rowHeight100.EntireRow.RowHeight = 10; //

                    Excel.Range rowColum100 = workSheet3.get_Range("A17", "A37");
                    rowColum100.EntireColumn.ColumnWidth = 3; //

                    Excel.Range rowColum102 = workSheet3.get_Range("B17", "C37");
                    rowColum102.EntireColumn.ColumnWidth = 10; //

                    Excel.Range rowColum103 = workSheet3.get_Range("D17", "F37");
                    rowColum103.EntireColumn.ColumnWidth = 8; //

                    Excel.Range rowHeight101 = workSheet3.get_Range("A14", "I15");
                    rowHeight101.EntireRow.RowHeight = 12;

                    Excel.Range rowHeight102 = workSheet3.get_Range("A5", "I5");
                    rowHeight102.EntireRow.RowHeight = 11;

                    Excel.Range rowHeight103 = workSheet3.get_Range("A8", "I8");
                    rowHeight103.EntireRow.RowHeight = 11;

                    Excel.Range rowHeight104 = workSheet3.get_Range("A12", "I12");
                    rowHeight104.EntireRow.RowHeight = 11;

                    Excel.Range rowHeight105 = workSheet3.get_Range("A42", "I42");
                    rowHeight105.EntireRow.RowHeight = 18; //

                    Excel.Range rowHeight106 = workSheet3.get_Range("A14", "I14");
                    rowHeight106.EntireRow.RowHeight = 16;

                    Excel.Range rowHeight107 = workSheet3.get_Range("A38", "I38");
                    rowHeight107.EntireRow.RowHeight = 12;

                    Excel.Range rowHeight108 = workSheet3.get_Range("A17", "I17");
                    rowHeight108.EntireRow.RowHeight = 30;

                    Excel.Range rowHeight109 = workSheet3.get_Range("A11", "I11");
                    rowHeight109.EntireRow.RowHeight = 35;

                    range_Consolidated102.Font.Bold = true;
                    range_Consolidated102.Font.Size = 10;
                    range_Consolidated103.Font.Bold = true;
                    range_Consolidated103.Font.Size = 10;
                    range_Consolidated104.Font.Size = 8;
                    range_Consolidated105.Font.Size = 9;
                    range_Consolidated106.Font.Size = 9;
                    range_Consolidated107.Font.Size = 8;
                    range_Consolidated108.Font.Size = 8;
                    range_Consolidated109.Font.Size = 9;
                    range_Consolidated110.Font.Size = 9;
                    range_Consolidated111.Font.Size = 9;
                    range_Consolidated112.Font.Size = 8;
                    range_Consolidated113.Font.Size = 8;
                    range_Consolidated114.Font.Size = 9;
                    range_Consolidated115.Font.Size = 9;
                    range_Consolidated116.Font.Size = 9;
                    range_Consolidated117.Font.Size = 9;
                    range_Consolidated118.Font.Size = 9;
                    range_Consolidated119.Font.Size = 7;
                    range_Consolidated120.Font.Size = 8.5;
                    range_Consolidated121.Font.Size = 9;
                    range_Consolidated121.Font.Bold = true;
                    range_Consolidated122.Font.Size = 7;
                    range_Consolidated123.Font.Bold = true;
                    range_Consolidated123.Font.Size = 8;
                    range_Consolidated124.Font.Bold = true;
                    range_Consolidated124.Font.Size = 8;
                    range_Consolidated125.Font.Size = 6;
                    range_Consolidated126.Font.Size = 8;
                    range_Consolidated126.Font.Bold = true;
                    range_Consolidated127.Font.Size = 6;
                    range_Consolidated128.Font.Size = 6;
                    range_Consolidated130.Font.Size = 6;
                    range_Consolidated129.Font.Bold = true;
                    range_Consolidated129.Font.Size = 8;
                    range_Consolidated131.Font.Size = 7;
                    range_Consolidated132.NumberFormat = "@";
                    range_Consolidated133.Font.Size = 9;


                    workSheet3.Cells[1, 1] = $"ПЕРВИЧНЫЙ ТЕХНИЧЕСКИЙ АКТ № {numberAct}";
                    workSheet3.Cells[2, 1] = $"ОКАЗАННЫХ УСЛУГ ПО ТЕХНИЧЕСКОМУ ОБСЛУЖИВАНИЮ СИСТЕМ РАДИОСВЯЗИ";
                    workSheet3.Cells[4, 1] = $"{city}";
                    workSheet3.Cells[5, 1] = $"город";
                    workSheet3.Cells[5, 8] = $"дата";
                    workSheet3.Cells[6, 1] = $"Мы, нижеподписавшиеся, представитель Исполнителя:";
                    workSheet3.Cells[7, 1] = $"Начальник участка по техническому обслуживанию и ремонту систем радиосвязи:            {sectionForeman}";
                    workSheet3.Cells[8, 2] = $"должность";
                    workSheet3.Cells[8, 8] = $"фамилия, инициалы";
                    workSheet3.Cells[9, 1] = $"действующий по доверенности № {attorney} с одной стороны и представитель Заказчика";
                    workSheet3.Cells[10, 1] = $"(эксплуатирующей организации):             {company}             {road} (полигон {poligon})";
                    if (post.Length > 80)
                    {
                        var result = post.Split(new[] { ' ', });
                        string postPrint = String.Empty;
                        for (int i = 0; i < result.Length; i++)
                        {
                            if (i == result.Length / 2 + 2)
                                postPrint += result[i] + "\n" + " ";
                            else postPrint += result[i] + " ";

                        }
                        workSheet3.Cells[11, 1] = $"{postPrint}";
                    }
                    else workSheet3.Cells[11, 1] = $"\n{post}\n";
                    workSheet3.Cells[11, 7] = $"{representative}";
                    workSheet3.Cells[12, 1] = $"должность";
                    workSheet3.Cells[12, 7] = $"фамилия, инициалы";
                    workSheet3.Cells[13, 1] = $"служебное удостоверение №";
                    workSheet3.Cells[13, 4] = $"{numberIdentification}";
                    workSheet3.Cells[13, 6] = $"дата выдачи:";
                    workSheet3.Cells[13, 8] = $"{dateOfIssuanceOfTheCertificate} г.";
                    workSheet3.Cells[14, 1] = $"с другой стороны составили настоящий акт в том, что во исполнение договора № 4176190 от 07 декабря 2020 г.,";
                    workSheet3.Cells[15, 1] = $"были  оказаны  услуги по техническому обслуживанию систем радиосвязи:";
                    workSheet3.Cells[16, 1] = $"Заводские номера  и марки портативных (носимых)  систем радиосвязи:";
                    workSheet3.Cells[17, 1] = $"№";
                    workSheet3.Cells[17, 2] = $"Тип РЭС";
                    workSheet3.Cells[17, 4] = $"Заводской № РЭС";
                    workSheet3.Cells[17, 7] = $"Место нахождения РЭС";
                    workSheet3.Cells[38, 1] = $"Вышеперечисленные носимые радиостанции участвуют в технологических процессах, требующих режима немедленной связи, и включены";
                    workSheet3.Cells[39, 1] = $"в перечень носимых радиостанций по данному структурному подразделению подлежащих периодической проверке. Системы радиосвязи исправны,";
                    workSheet3.Cells[40, 1] = $"технические характеристики вышеперечисленных систем радиосвязи после проведенного технического обслуживания соответствуют нормам.";
                    workSheet3.Cells[41, 1] = $"Представитель эксплуатирующей организации по качеству оказанных услуг претензий к Исполнителю не имеет.";
                    workSheet3.Cells[42, 1] = $"Представитель Заказчика";
                    workSheet3.Cells[42, 6] = $"Представитель Исполнителя: ";
                    workSheet3.Cells[43, 1] = $"(эксплуатирующей организации):";
                    workSheet3.Cells[44, 8] = $"{sectionForeman}";
                    workSheet3.Cells[45, 3] = $"{representative}";
                    workSheet3.Cells[45, 6] = $"подпись";
                    workSheet3.Cells[45, 8] = $"расшифровка  подписи";
                    workSheet3.Cells[46, 1] = $"подпись";
                    workSheet3.Cells[46, 3] = $"расшифровка  подписи";
                    workSheet3.Cells[46, 7] = $"МП";
                    workSheet3.Cells[47, 1] = $"Представитель РЦС:";
                    workSheet3.Cells[50, 1] = $"подпись";
                    workSheet3.Cells[50, 3] = $"расшифровка  подписи";
                    workSheet3.Cells[51, 4] = $"МП";

                    int s2 = 1;
                    int j2 = 18;

                    for (int i = 0; i < radiostantionsCollection.Count; i++)
                    {
                        workSheet3.Cells[17 + s2, 1] = s2;

                        Excel.Range _excelCells128 = (Excel.Range)workSheet3.get_Range($"B{j2}", $"C{j2}").Cells;
                        _excelCells128.Merge(Type.Missing);
                        _excelCells128.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        workSheet3.Cells[17 + s2, 2] = radiostantionsCollection[i].Model;

                        Excel.Range _excelCells129 = (Excel.Range)workSheet3.get_Range($"D{j2}", $"F{j2}").Cells;
                        _excelCells129.Merge(Type.Missing);
                        _excelCells129.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        workSheet3.Cells[17 + s2, 4] = radiostantionsCollection[i].SerialNumber;

                        Excel.Range _excelCells130 = (Excel.Range)workSheet3.get_Range($"G{j2}", $"I{j2}").Cells;
                        _excelCells130.Merge(Type.Missing);
                        _excelCells130.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        workSheet3.Cells[17 + s2, 7] = radiostantionsCollection[i].Location;

                        s2++;
                        j2++;
                    }

                    while (s2 <= 20)
                    {
                        workSheet3.Cells[17 + s2, 1] = s2;

                        Excel.Range _excelCells128 = (Excel.Range)workSheet3.get_Range($"B{j2}", $"C{j2}").Cells;
                        _excelCells128.Merge(Type.Missing);
                        _excelCells128.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        Excel.Range _excelCells129 = (Excel.Range)workSheet3.get_Range($"D{j2}", $"F{j2}").Cells;
                        _excelCells129.Merge(Type.Missing);
                        _excelCells129.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        Excel.Range _excelCells130 = (Excel.Range)workSheet3.get_Range($"G{j2}", $"I{j2}").Cells;
                        _excelCells130.Merge(Type.Missing);
                        _excelCells130.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        s2++;
                        j2++;
                    }
                    #endregion

                    string file = $"{numberAct.Replace('/', '.')}-{company}_Акт.xlsx";

                    if (!File.Exists($@"С:\ServiceTelekom\Акты ТО\{city}\"))
                    {
                        try
                        {
                            Directory.CreateDirectory($@"C:\ServiceTelekom\Акты ТО\{city}\");
                            workSheet3.SaveAs($@"C:\ServiceTelekom\Акты ТО\{city}\" + file);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MessageBox.Show("Не удаётся сохранить файл.");
                        }
                    }
                    else
                    {
                        try
                        {
                            workSheet3.SaveAs($@"C:\ServiceTelekom\Акты ТО\{city}\" + file);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MessageBox.Show("Не удаётся сохранить файл.");
                        }
                    }
                    exApp.Visible = true;
                }
            }
            catch (Exception ex)
            {
                if (exApp != null)
                    exApp = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
                Environment.Exit(0);
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
