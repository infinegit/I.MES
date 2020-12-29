using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Data;
using System.Collections;
using LumenWorks.Framework.IO.Csv;
using NPOI.HPSF;

namespace I.MES.Tools
{
    public  class ExcelHelper
    {

        public ExcelHelper()
        {
                
        }

        private static NPOI.SS.UserModel.IWorkbook workbook = null;

        public static DataTable ExcelOrCsvToDataTable(string file)
        {
            DataTable dt = new DataTable();

            string strSuff = Path.GetExtension(file);

            if (strSuff.Equals(".xlsx"))
                dt = XlsxExcelToDataTable(file);

            if (strSuff.Equals(".xls"))
                dt = XlsExcelToDataTable(file);

            if (strSuff.Equals(".csv"))
                dt = CsvToDataTable(file);

            return dt;
        }



        /// <summary>
        /// 读取Excel 2007以上版本
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static DataTable XlsxExcelToDataTable(string file)
        {
            using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
            {

                // 2007版本
                workbook = new XSSFWorkbook(stream);

                stream.Close();
            }

            XSSFSheet sheetAt = (XSSFSheet)workbook.GetSheetAt(0);

            IEnumerator rowEnumerator = sheetAt.GetRowEnumerator();
            DataTable table = new DataTable(sheetAt.SheetName);
            rowEnumerator.MoveNext();
            XSSFRow current = (XSSFRow)rowEnumerator.Current;

            for (int j = 0; j < current.LastCellNum; j++)
            {
                table.Columns.Add(current.GetCell(j).ToString());
            }

            while (rowEnumerator.MoveNext())
            {
                current = (XSSFRow)rowEnumerator.Current;

                DataRow row = table.NewRow();
                for (int k = 0; k < current.LastCellNum; k++)
                {
                    XSSFCell cell = (XSSFCell)current.GetCell(k);

                    if (cell == null)
                    {
                        row[k] = null;
                    }
                    else
                    {
                        row[k] = cell.ToString();
                    }
                }
                table.Rows.Add(row);
            }

            return table;
        }


        /// <summary>
        /// 读取Excel 2003版本
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static DataTable XlsExcelToDataTable(string file)
        {
            using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
            {

                // 2003版本
                workbook = new HSSFWorkbook(stream);

                stream.Close();
            }

            HSSFSheet sheetAt = (HSSFSheet)workbook.GetSheetAt(0);
            IEnumerator rowEnumerator = sheetAt.GetRowEnumerator();
            DataTable table = new DataTable(sheetAt.SheetName);
            rowEnumerator.MoveNext();

            HSSFRow current = (HSSFRow)rowEnumerator.Current;
            for (int j = 0; j < current.LastCellNum; j++)
            {
                table.Columns.Add(current.GetCell(j).ToString());
            }

            while (rowEnumerator.MoveNext())
            {

                current = (HSSFRow)rowEnumerator.Current;
                DataRow row = table.NewRow();
                for (int k = 0; k < current.LastCellNum; k++)
                {

                    HSSFCell cell = (HSSFCell)current.GetCell(k);
                    if (cell == null)
                    {
                        row[k] = null;
                    }
                    else
                    {
                        row[k] = cell.ToString();
                    }
                }
                table.Rows.Add(row);
            }

            return table;
        }

        /// <summary>
        /// 读取CSV文件到DataTable
        /// </summary>
        /// <param name="File"></param>
        /// <returns></returns>
        public static DataTable CsvToDataTable(string File)
        {
            FileStream stream = new FileStream(File, FileMode.Open, FileAccess.Read);

            Encoding _encode = Encoding.GetEncoding("GB2312");

            using (stream)
            {
                using (StreamReader input = new StreamReader(stream, _encode))
                {
                    using (CsvReader csv = new CsvReader(input, false))
                    {
                        DataTable dt = new DataTable();
                        int columnCount = csv.FieldCount;

                        csv.ReadNextRecord();

                        for (int i = 0; i < columnCount; i++)
                        {

                            dt.Columns.Add(csv[i].ToString());
                        }

                        while (csv.ReadNextRecord())
                        {
                            DataRow dr = dt.NewRow();
                            for (int i = 0; i < columnCount; i++)
                            {
                                if (!string.IsNullOrEmpty(csv[i]))
                                {
                                    dr[i] = csv[i];
                                }
                            }
                            dt.Rows.Add(dr);
                        }
                        return dt;
                    }

                }
            }
        }

        /// <summary>
        /// 保存DataTable到Excel文件
        /// </summary>
        /// <param name="data">需要保存的数据</param>
        /// <param name="file">文件名</param>
        public static void SaveDataTableToExcel(DataTable data, string file)
        {
            XSSFWorkbook workbook = new XSSFWorkbook();

            ISheet sheet = workbook.CreateSheet("ReportView");
            IRow row = sheet.CreateRow(0);
            int num = 0;
            foreach (DataColumn column in data.Columns)
            {
                row.CreateCell(num++).SetCellValue(column.ColumnName);
            }
            num = 1;
            foreach (DataRow row2 in data.Rows)
            {
                row = sheet.CreateRow(num++);
                int num2 = 0;
                foreach (DataColumn column in data.Columns)
                {
                    object obj2 = row2[num2];
                    if (obj2 == null)
                    {
                        obj2 = string.Empty;
                    }
                    row.CreateCell(num2++).SetCellValue(obj2.ToString());
                }
            }
            num = 0;
            foreach (DataColumn column in data.Columns)
            {
                sheet.AutoSizeColumn(num++);
            }
            using (FileStream stream = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(stream);

                stream.Close();
            }
        }
    }
}
