using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Collections;
using Aspose.Cells;
using System.Reflection;
using System.Linq;

namespace I.MES.Tools
{
    /// <summary>
    /// Excel工具类
    /// </summary>
    public class AsposeExcelTools
    {

        /// <summary>
        /// 将Datatable转化为Excel，带标题
        /// </summary>
        ///<param name="dtSource">需要导出的数据</param>
        ///<param name="FilePath">数据存放路径及文件名</param>
        /// <returns></returns>
        public static void DataTableToExcel2(DataTable dtSource, string FilePath)
        {
            Workbook wk = DataTableToExcel2(dtSource);

            if (wk != null)
            {
                wk.Save(FilePath);
            }
        }


        /// <summary>
        /// 将Datatable转化为Excel，不带标题
        /// </summary>
        /// <param name="datatable"></param>
        /// <returns></returns>
        public static Workbook DataTableToExcel(DataTable datatable)
        {
            if (datatable == null && datatable.Rows.Count < 0)
            {
                return null;
            }
            try
            {
                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
                Aspose.Cells.Worksheet sheet = workbook.Worksheets[0];
                Aspose.Cells.Cells cells = sheet.Cells;

                int nRow = 0;
                foreach (DataRow row in datatable.Rows)
                {
                    nRow++;
                    try
                    {
                        for (int i = 0; i < datatable.Columns.Count; i++)
                        {
                            if (row[i].GetType().ToString() == "System.Drawing.Bitmap")
                            {
                                //------插入图片数据-------
                                System.Drawing.Image image = (System.Drawing.Image)row[i];
                                MemoryStream mstream = new MemoryStream();
                                image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                                sheet.Pictures.Add(nRow, i, mstream);
                            }
                            else
                            {
                                cells[nRow, i].PutValue(row[i]);
                            }
                        }
                    }
                    catch
                    {
                        return null;
                    }
                }
                return workbook;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 将Datatable转化为Excel，带标题
        /// </summary>
        /// <param name="datatable"></param>
        /// <returns></returns>
        public static Workbook DataTableToExcel2(DataSet ds)
        {
            Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();


            try
            {
                int rowIndex = 0;
                for (int m = 0; m < ds.Tables.Count; m++)
                {
                    DataTable datatable = ds.Tables[m];
                    if (datatable == null && datatable.Rows.Count < 0)
                    {
                        return null;
                    }
                    //为单元格添加样式    
                    //Aspose.Cells.Style style = wb.Styles[wb.Styles.Add()];
                    Aspose.Cells.Style style = wb.CreateStyle();
                    //设置居中
                    style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center;
                    //设置背景颜色
                    style.ForegroundColor = System.Drawing.Color.FromArgb(153, 204, 0);
                    style.Pattern = BackgroundType.Solid;
                    style.Font.IsBold = true;

                    for (int i = 0; i < datatable.Columns.Count; i++)
                    {
                        DataColumn col = datatable.Columns[i];
                        string columnName = col.Caption ?? col.ColumnName;
                        wb.Worksheets[0].Cells[rowIndex, i].PutValue(columnName);
                        wb.Worksheets[0].Cells[rowIndex, i].SetStyle(style);
                    }
                    rowIndex++;

                    foreach (DataRow row in datatable.Rows)
                    {
                        for (int i = 0; i < datatable.Columns.Count; i++)
                        {
                            if (datatable.Columns[i].DataType == Type.GetType("System.Decimal"))
                            {
                                if (row[i] != null && row[i].ToString() != "")
                                    wb.Worksheets[0].Cells[rowIndex, i].PutValue(Convert.ToDouble(row[i].ToString()).ToString("0.########"));
                            }
                            else
                            {
                                wb.Worksheets[0].Cells[rowIndex, i].PutValue(row[i].ToString());
                            }
                        }
                        rowIndex++;
                    }

                    for (int k = 0; k < datatable.Columns.Count; k++)
                    {
                        wb.Worksheets[0].AutoFitColumn(k, 0, 150);
                    }
                    wb.Worksheets[0].FreezePanes(1, 0, 1, datatable.Columns.Count);
                }
                return wb;
            }
            catch
            {
                return null;
            }

        }
        /// <summary>
        /// 将Datatable转化为Excel，带标题
        /// </summary>
        /// <param name="datatable"></param>
        /// <returns></returns>
        public static Workbook DataTableToExcel2(DataTable datatable)
        {
            if (datatable == null && datatable.Rows.Count < 0)
            {
                return null;
            }
            Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
            try
            {
                //为单元格添加样式    
                //Aspose.Cells.Style style = wb.Styles[wb.Styles.Add()];
                Aspose.Cells.Style style = wb.CreateStyle();
                //设置居中
                style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center;
                //设置背景颜色
                style.ForegroundColor = System.Drawing.Color.FromArgb(153, 204, 0);
                style.Pattern = BackgroundType.Solid;
                style.Font.IsBold = true;
                int rowIndex = 0;
                for (int i = 0; i < datatable.Columns.Count; i++)
                {
                    DataColumn col = datatable.Columns[i];
                    string columnName = col.Caption ?? col.ColumnName;
                    wb.Worksheets[0].Cells[rowIndex, i].PutValue(columnName);
                    wb.Worksheets[0].Cells[rowIndex, i].SetStyle(style);
                }
                rowIndex++;

                foreach (DataRow row in datatable.Rows)
                {
                    for (int i = 0; i < datatable.Columns.Count; i++)
                    {
                        if (datatable.Columns[i].DataType == Type.GetType("System.Decimal"))
                        {
                            if (row[i] != null && row[i].ToString() != "")
                                wb.Worksheets[0].Cells[rowIndex, i].PutValue(Convert.ToDouble(row[i].ToString()).ToString("0.########"));
                        }
                        else
                        {
                            wb.Worksheets[0].Cells[rowIndex, i].PutValue(row[i].ToString());
                        }
                    }
                    rowIndex++;
                }

                for (int k = 0; k < datatable.Columns.Count; k++)
                {
                    wb.Worksheets[0].AutoFitColumn(k, 0, 150);
                }
                wb.Worksheets[0].FreezePanes(1, 0, 1, datatable.Columns.Count);
                return wb;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        public static Workbook ListToExcel(IList list)
        {
            return ListToExcel(list, null, null);
        }

        public static Workbook ListToExcel(IList list, List<string> titles, List<string> fields)
        {
            return ListToExcel(list, titles, fields, int.MaxValue);
        }

        public static Workbook ListToExcel(IList list, List<string> titles, List<string> fields, int editabelBegin)
        {
            if (list == null && list.Count == 0)
            {
                return null;
            }
            Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
            try
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                //为单元格添加样式    
                //Aspose.Cells.Style style = wb.Styles[wb.Styles.Add()];
                Aspose.Cells.Style style = wb.CreateStyle();
                //设置居中
                style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center;
                //设置背景颜色
                style.ForegroundColor = System.Drawing.Color.FromArgb(153, 204, 0);
                style.Pattern = BackgroundType.Solid;
                style.Font.IsBold = true;
                int rowIndex = 0;
                if (titles != null && titles.Count > 0)
                {
                    for (int i = 0; i < titles.Count; i++)
                    {
                        if (i > editabelBegin)
                        {
                            style.ForegroundColor = System.Drawing.Color.FromArgb(255, 255, 0);
                        }
                        wb.Worksheets[0].Cells[rowIndex, i].PutValue(titles[i]);
                        wb.Worksheets[0].Cells[rowIndex, i].SetStyle(style);
                    }
                    rowIndex++;

                    foreach (var t in list)
                    {
                        for (int i = 0; i < fields.Count; i++)
                        {
                            var pi = propertys.FirstOrDefault(p => p.Name == fields[i]);
                            if (pi.PropertyType.Name.Equals("Decimal"))
                            {
                                wb.Worksheets[0].Cells[rowIndex, i].PutValue(pi.GetValue(t, null));
                            }
                            else
                            {
                                wb.Worksheets[0].Cells[rowIndex, i].PutValue(pi.GetValue(t, null) == null ? "" : pi.GetValue(t, null).ToString());
                            }

                        }
                        rowIndex++;
                    }
                }
                else
                {
                    for (int i = 0; i < propertys.Length; i++)
                    {
                        if (propertys[i].Name != "__InheritFrom")
                        {
                            if (i > editabelBegin)
                            {
                                style.ForegroundColor = System.Drawing.Color.FromArgb(255, 255, 0);
                            }
                            wb.Worksheets[0].Cells[rowIndex, i].PutValue(propertys[i].Name);
                            wb.Worksheets[0].Cells[rowIndex, i].SetStyle(style);
                        }
                    }
                    rowIndex++;

                    foreach (var t in list)
                    {
                        for (int i = 0; i < propertys.Length; i++)
                        {
                            if (propertys[i].Name != "__InheritFrom")
                            {
                                wb.Worksheets[0].Cells[rowIndex, i].PutValue(propertys[i].GetValue(t, null));
                            }
                        }
                        rowIndex++;
                    }
                }
                for (int k = 0; k < propertys.Length; k++)
                {
                    wb.Worksheets[0].AutoFitColumn(k, 0, 150);
                }
                wb.Worksheets[0].FreezePanes(1, 0, 1, list.Count);
                return wb;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Excel文件转换为DataTable.只转化第一个Sheet
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static DataTable ExcelFileToDataTable(Stream stream)
        {
            DataTable dt = null;
            try
            {
                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(stream);
                Aspose.Cells.Worksheet worksheet = workbook.Worksheets[0];
                dt = worksheet.Cells.ExportDataTable(0, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1);
                dt = RemoveEmpty(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Excel文件转换为DataTable.只转化第一个Sheet
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static DataTable ExcelFileDataTable(Stream stream)
        {
            //DataTable dt = null;
            try
            {
                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(stream);
                Aspose.Cells.Worksheet worksheet = workbook.Worksheets[0];
                DataTable dt = new DataTable(worksheet.Name); 
                int rows = worksheet.Cells.MaxRow + 1;
                for (int columnIndex = 0; columnIndex < worksheet.Cells.MaxColumn + 1; columnIndex++)
                {
                    string text = string.Empty;
                    if (worksheet.Cells[0, columnIndex].Value != null)
                    {
                        text = worksheet.Cells[0, columnIndex].Value.ToString();
                    } 
                    if (!string.IsNullOrEmpty(text.Trim()))
                    {
                        dt.Columns.Add(text);
                    }
                    else
                    {
                        break;
                    }
                }
                for (int row = 1; row < rows; row++)
                {
                    DataRow dr = dt.NewRow();
                    int emptyCount = 0;
                    for (int columnIndex = 0; columnIndex < worksheet.Cells.MaxColumn + 1; columnIndex++)
                    {
                        string value=string.Empty;
                         
                        if (worksheet.Cells[row, columnIndex].Value!= null)
                        {
                            value = worksheet.Cells[row, columnIndex].Value.ToString();
                        } 
                        if (!string.IsNullOrEmpty(value.Trim()))
                        {
                            dr[columnIndex] = value;
                        }
                        else
                        {
                            emptyCount++;
                        }
                    } 
                    // 如果整行都是空行则退出
                    if (emptyCount == rows - 1)
                        break;
                    dt.Rows.Add(dr);
                }
                dt = RemoveEmpty(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Excel文件转换为DataTable.只转化第一个Sheet,将表格第一列作为列名
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static DataTable ExcelFileToDataTable(Stream stream, bool exportColumnName)
        {
            DataTable dt = null;
            try
            {
                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(stream);
                Aspose.Cells.Worksheet worksheet = workbook.Worksheets[0];
                dt = worksheet.Cells.ExportDataTable(0, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, exportColumnName);
                dt = RemoveEmpty(dt);
                return dt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Excel文件转换为DataTable.
        /// </summary>
        /// <param name="filepath">Excel文件的全路径</param>        
        /// <param name="error">错误信息:返回错误信息，没有错误返回""</param>
        /// <returns></returns>
        public static DataTable ExcelFileToDataTable(string filepath, out string error, bool exportColumnName = false)
        {
            error = "";
            DataTable datatable = null;
            try
            {
                if (File.Exists(filepath) == false)
                {
                    error = "文件不存在";
                    datatable = null;
                    return null;
                }
                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(filepath);
                Aspose.Cells.Worksheet worksheet = workbook.Worksheets[0];
                datatable = worksheet.Cells.ExportDataTable(0, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, exportColumnName);
                return datatable;
            }
            catch (System.Exception e)
            {
                error = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 将Excel转化为DataSet
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static DataSet ExcelFileToDataSet(Stream stream)
        {
            DataSet ds = new DataSet();
            try
            {
                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(stream);
                for (int index = 0; index < workbook.Worksheets.Count; index++)
                {
                    DataTable dt = ExcelFileToDataTable(workbook.Worksheets[index]);
                    dt = RemoveEmpty(dt);
                    ds.Tables.Add(dt);
                }

                return ds;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 将Excel转化为DataSet
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="exportColumnName">把第一列作为列名</param>
        /// <returns></returns>
        public static DataSet ExcelFileToDataSet(Stream stream, bool exportColumnName)
        {
            DataSet ds = new DataSet();
            try
            {
                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(stream);
                for (int index = 0; index < workbook.Worksheets.Count; index++)
                {
                    DataTable dt = workbook.Worksheets[index].Cells.ExportDataTable(0, 0, workbook.Worksheets[index].Cells.MaxRow + 1, workbook.Worksheets[index].Cells.MaxColumn + 1, exportColumnName);
                    dt = RemoveEmpty(dt);
                    ds.Tables.Add(dt);
                }

                return ds;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 将Excel中的sheet转化为Datatable
        /// </summary>
        /// <param name="worksheet"></param>
        /// <returns></returns>
        public static DataTable ExcelFileToDataTable(Worksheet worksheet)
        {
            DataTable dt = null;
            try
            {
                dt = worksheet.Cells.ExportDataTable(0, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1);
                dt = RemoveEmpty(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 清除表中的空行
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static DataTable RemoveEmpty(DataTable dt)
        {
            int colums = dt.Columns.Count;
            int rows = dt.Rows.Count;
            for (int j = 0; j < rows; j++)
            {
                bool isremove = true;
                for (int i = 0; i < colums; i++)
                {
                    if (dt.Rows[j][i] != null && dt.Rows[j][i].ToString().Trim() != "")
                    {
                        isremove = false;
                        break;
                    }

                }
                if (isremove)
                {
                    dt.Rows.RemoveAt(j);
                    rows--;
                    j--;
                }
            }
            return dt;
        }


        /// <summary>
        /// 将Datatable转化为Excel，带标题
        /// </summary>
        /// <param name="datatable"></param>
        /// <returns></returns>
        public static Workbook DataTableToExcelDet2(DataSet ds)
        {
            Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
            try
            {
                int rowIndex = 0;
                if (ds.Tables.Count == 0) return null;
                DataTable datatable = ds.Tables[0];
                if (datatable == null && datatable.Rows.Count < 0)
                {
                    return null;
                }
                //为单元格添加样式    
                //Aspose.Cells.Style style = wb.Styles[wb.Styles.Add()];
                Aspose.Cells.Style style = wb.CreateStyle();
                //设置居中
                style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center;
                //设置背景颜色
                style.ForegroundColor = System.Drawing.Color.FromArgb(153, 204, 0);
                style.Pattern = BackgroundType.Solid;
                style.Font.IsBold = true;
                style.Font.Color = System.Drawing.Color.SeaGreen;
                Aspose.Cells.Style style2 = wb.CreateStyle();
                //设置居中
                style2.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center;
                //设置背景颜色
                style2.ForegroundColor = System.Drawing.Color.RoyalBlue;
                style2.Pattern = BackgroundType.Solid;
                style2.Font.IsBold = true;
                style2.Font.Color = System.Drawing.Color.Salmon;
                for (int i = 0; i < datatable.Columns.Count; i++)
                {
                    DataColumn col = datatable.Columns[i];
                    string columnName = col.Caption ?? col.ColumnName;
                    wb.Worksheets[0].Cells[rowIndex, i].PutValue(columnName);
                    wb.Worksheets[0].Cells[rowIndex, i].SetStyle(style2);
                }
                rowIndex++;
                DataTable datatable2 = ds.Tables[1];
                int index = 0;

                foreach (DataRow row in datatable.Rows)
                {
                    for (int i = 0; i < datatable.Columns.Count; i++)
                    {
                        wb.Worksheets[0].Cells[rowIndex, i].PutValue(row[i].ToString());//赋值

                    }

                    if (datatable2 != null)
                    {
                        index = rowIndex + 1;//子表行数需加一
                        string fid = datatable2.Select(@"fid <>'' ")[0]["fid"].ToString();//查询出主表关联字段
                        string id = row[fid].ToString();
                        var data = datatable2.Select("" + fid + "='" + id + "'");
                        if (data.Count() != 0)
                            for (int i = 1; i < datatable2.Columns.Count; i++)
                            {
                                DataColumn col = datatable2.Columns[i - 1];
                                string columnName = col.Caption ?? col.ColumnName;
                                wb.Worksheets[0].Cells[index, i].PutValue(columnName);
                                wb.Worksheets[0].Cells[index, i].SetStyle(style);
                            }
                        foreach (var item in data)
                        {
                            index++;
                            for (int i = 1; i < datatable2.Columns.Count; i++)
                            {
                                wb.Worksheets[0].Cells[index, i].PutValue(item[i - 1].ToString());//赋值
                            }
                        }
                    }
                    rowIndex = index + 2;
                }

                for (int k = 0; k < datatable.Columns.Count; k++)
                {
                    wb.Worksheets[0].AutoFitColumn(k, 0, 150);
                }
                wb.Worksheets[0].FreezePanes(1, 0, 1, datatable.Columns.Count);

                return wb;
            }
            catch
            {
                return null;
            }

        }
        /// <summary>
        /// Excel文件转换为DataTable.只转化第一个Sheet,将表格第一列作为列名
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static DataTable ExcelFileToDataTables(Stream stream, bool exportColumnName, ref string strExcel)
        {
            DataTable dt = null;
            try
            {
                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(stream);
                Aspose.Cells.Worksheet worksheet = workbook.Worksheets[0];
                strExcel = worksheet.Name;
                dt = worksheet.Cells.ExportDataTable(0, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, exportColumnName);
                dt = RemoveEmpty(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
