using System;
using System.Data;
using System.IO;
using OfficeOpenXml;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace TimeProcessor
{
    public static class ExcelHelper
    {
        // 读取Excel（自动识别xls/xlsx）
        public static DataTable ReadExcel(string filePath, int startRow, int endRow, int startCol, int endCol)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            if (ext == ".xlsx")
            {
                
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var ws = package.Workbook.Worksheets[0];
                    return ReadFromWorksheet(ws, startRow, endRow, startCol, endCol);
                }
            }
            else if (ext == ".xls")
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook = new HSSFWorkbook(fs);
                    var sheet = workbook.GetSheetAt(0);
                    return ReadFromNpoiSheet(sheet, startRow, endRow, startCol, endCol);
                }
            }
            else
            {
                throw new Exception("仅支持xls/xlsx文件");
            }
        }

        // 保存Excel（自动识别xls/xlsx）
        public static void SaveExcel(DataTable table, string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            if (ext == ".xlsx")
            {
                
                using (var package = new ExcelPackage())
                {
                    var ws = package.Workbook.Worksheets.Add("结果");
                    for (int r = 0; r < table.Rows.Count; r++)
                        for (int c = 0; c < table.Columns.Count; c++)
                            ws.Cells[r + 1, c + 1].Value = table.Rows[r][c];
                    package.SaveAs(new FileInfo(filePath));
                }
            }
            else if (ext == ".xls")
            {
                IWorkbook workbook = new HSSFWorkbook();
                var sheet = workbook.CreateSheet("结果");
                for (int r = 0; r < table.Rows.Count; r++)
                {
                    var row = sheet.CreateRow(r);
                    for (int c = 0; c < table.Columns.Count; c++)
                        row.CreateCell(c).SetCellValue(table.Rows[r][c]?.ToString());
                }
                using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }
            }
            else
            {
                throw new Exception("仅支持xls/xlsx文件");
            }
        }

        // EPPlus读取
        private static DataTable ReadFromWorksheet(ExcelWorksheet ws, int startRow, int endRow, int startCol, int endCol)
        {
            DataTable dt = new DataTable();
            int colCount = endCol - startCol + 1;
            for (int c = 0; c < colCount; c++)
                dt.Columns.Add();
            for (int r = startRow; r <= endRow; r++)
            {
                var row = dt.NewRow();
                for (int c = startCol; c <= endCol; c++)
                    row[c - startCol] = ws.Cells[r, c].Text;
                dt.Rows.Add(row);
            }
            return dt;
        }

        // NPOI读取
        private static DataTable ReadFromNpoiSheet(ISheet sheet, int startRow, int endRow, int startCol, int endCol)
        {
            DataTable dt = new DataTable();
            int colCount = endCol - startCol + 1;
            for (int c = 0; c < colCount; c++)
                dt.Columns.Add();
            for (int r = startRow - 1; r < endRow; r++)
            {
                var row = dt.NewRow();
                var sheetRow = sheet.GetRow(r);
                for (int c = startCol - 1; c < endCol; c++)
                    row[c - (startCol - 1)] = sheetRow?.GetCell(c)?.ToString() ?? "";
                dt.Rows.Add(row);
            }
            return dt;
        }

        // Excel列字母转数字（A=1, B=2...AA=27...）
        public static int ColumnLetterToIndex(string col)
        {
            int index = 0;
            foreach (char c in col.ToUpper())
            {
                if (c < 'A' || c > 'Z') continue;
                index = index * 26 + (c - 'A' + 1);
            }
            return index;
        }
    }
} 