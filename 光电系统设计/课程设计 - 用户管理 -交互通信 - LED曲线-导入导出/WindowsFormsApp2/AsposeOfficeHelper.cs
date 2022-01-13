using Aspose.Cells;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace WindowsFormsApp2
{
    /// <summary>
    /// 使用Aspose组件的Office文件操作帮助类
    /// </summary>
    public class AsposeOfficeHelper
    {


        /// <summary>
        /// 数据集转sheet
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="dt"></param>
        public static void DataTableToWorksheet(ref Worksheet sheet, DataTable dt)
        {
            //Workbook book = new Workbook();
            //Worksheet sheet = book.Worksheets[0];

            Cells cells = sheet.Cells;
            int Colnum = dt.Columns.Count;//表格列数 
            int Rownum = dt.Rows.Count;//表格行数
            //生成行 列名行 
            for (int i = 0; i < Colnum; i++)
            {
                cells[0, i].PutValue(dt.Columns[i].ColumnName);
            }
            //生成数据行 
            for (int i = 0; i < Rownum; i++)
            {
                for (int k = 0; k < Colnum; k++)
                {
                    cells[1 + i, k].PutValue(dt.Rows[i][k].ToString());
                }
            }
            //自动行高，列宽
            sheet.AutoFitColumns();
            sheet.AutoFitRows();
        }

        /// <summary>
        /// 填加下拉
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="area"></param>
        /// <param name="mulal"></param>
        public static void WorksheetAddmulal(ref Worksheet sheet, CellArea area, string mulal)
        {
            //CellArea area = CellArea.CreateCellArea(0, 0, 10, 10);
            var valids = sheet.Validations;
            var val = valids[valids.Add(area)];

            val.Type = ValidationType.List;
            val.Operator = OperatorType.Equal;
            val.InCellDropDown = true;
            val.Formula1 = mulal;
            val.ShowError = true;
            val.ErrorTitle = "选择错误";
        }

        /// <summary>
        /// 转为流
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public static byte[] WorkbookToByte(Workbook book)
        {
            var ms = new MemoryStream();
            book.Save(ms, SaveFormat.Excel97To2003);
            return ms.ToArray();
        }

        /// <summary>
        /// 将DataTable输出为字节数组
        /// </summary>
        /// <param name="dt">表格数据</param>
        /// <returns>Byte数组</returns>
        public static byte[] DataTableToExcelBytes(DataTable dt)
        {
            Workbook book = new Workbook();
            Worksheet sheet = book.Worksheets[0];

            Cells cells = sheet.Cells;
            int Colnum = dt.Columns.Count;//表格列数 
            int Rownum = dt.Rows.Count;//表格行数
            //生成行 列名行 
            for (int i = 0; i < Colnum; i++)
            {
                cells[0, i].PutValue(dt.Columns[i].ColumnName);
            }
            //生成数据行 
            for (int i = 0; i < Rownum; i++)
            {
                for (int k = 0; k < Colnum; k++)
                {
                    cells[1 + i, k].PutValue(dt.Rows[i][k].ToString());
                }
            }

            //自动行高，列宽
            sheet.AutoFitColumns();
            sheet.AutoFitRows();

            //将DataTable写入内存流
            var ms = new MemoryStream();
            book.Save(ms, SaveFormat.Excel97To2003);
            return ms.ToArray();
        }

        /// <summary>
        /// 从excel文件导入数据
        /// 注：默认将第一行当作标题行，即不当作数据
        /// </summary>
        /// <param name="fileNmae">文件名</param>
        /// <returns></returns>
        public static DataTable ReadExcel(string fileNmae)
        {
            Workbook book = new Workbook(fileNmae);
            Worksheet sheet = book.Worksheets[0];
            Cells cells = sheet.Cells;

            return cells.ExportDataTableAsString(0, 0, cells.MaxDataRow + 1, cells.MaxDataColumn + 1, true);
        }

        /// <summary>
        /// 从excel文件导入数据
        /// </summary>
        /// <param name="fileNmae">文件名</param>
        /// <param name="exportColumnName">是否将第一行当作标题行</param>
        /// <returns></returns>
        public static DataTable ReadExcel(string fileNmae, bool exportColumnName)
        {
            Workbook book = new Workbook(fileNmae);
            Worksheet sheet = book.Worksheets[0];
            Cells cells = sheet.Cells;

            return cells.ExportDataTableAsString(0, 0, cells.MaxDataRow + 1, cells.MaxDataColumn + 1, exportColumnName);
        }

        /// <summary>
        /// 从excel文件字节源导入
        /// 注：默认将第一行当作标题行，即不当作数据
        /// </summary>
        /// <param name="fileBytes">文件字节源</param>
        /// <returns></returns>
        public static DataTable ReadExcel(byte[] fileBytes)
        {
            return ReadExcel(fileBytes, true);
        }

        /// <summary>
        /// 从excel文件字节源导入
        /// </summary>
        /// <param name="fileBytes">文件字节源</param>
        /// <param name="exportColumnName">是否将第一行当作标题行</param>
        /// <returns></returns>
        public static DataTable ReadExcel(byte[] fileBytes, bool exportColumnName)
        {
            using (MemoryStream ms = new MemoryStream(fileBytes))
            {
                Workbook book = new Workbook(ms);
                Worksheet sheet = book.Worksheets[0];
                Cells cells = sheet.Cells;

                return cells.ExportDataTableAsString(0, 0, cells.MaxDataRow + 1, cells.MaxDataColumn + 1, exportColumnName);
            }
        }
    }
}
