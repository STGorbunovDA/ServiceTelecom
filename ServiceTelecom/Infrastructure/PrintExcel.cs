using ServiceTelecom.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace ServiceTelecom.Infrastructure
{
    internal class PrintExcel
    {
        internal void PrintExcelNumberActTechnicalWork(
            List<RadiostationForDocumentsDataBaseModel>
            radiostantionsCollection, string city)
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
                    string location = "ст. " + city;
                    
                    string sectionForeman = string.Empty;
                    foreach (var item in UserModelStatic.
                        StaffRegistrationsDataBaseModelCollection)
                        sectionForeman = item.SectionForemanBase;
                    
                    string post = radiostantionsCollection[0].Post;
                    string representative = radiostantionsCollection[0].Representative;
                    string numberIdentification = radiostantionsCollection[0].NumberIdentification;

                    workSheet.Name = $"Накладная №{numberAct.Replace('/', '.')}";
                    workSheet2.Name = $"Ведомость №{numberAct.Replace('/', '.')}";
                    workSheet3.Name = $"Акт №{numberAct.Replace('/', '.')}";

                    #region Накладная ТО 1 Item

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
