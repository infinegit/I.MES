using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Cells;
using I.MES.Models;

namespace I.MES.Client.UI
{
    public class ExportExcelDemo
    {
        public void ExportSave(string FileName)
        {
            int sheetIndex = 0;
            int cellIndex = 0;
            string excelTemplate = Environment.CurrentDirectory + "\\Tpl\\标签模板.xlsx"; //模板文件
            FileInfo mode =  new FileInfo(excelTemplate);
            WorkbookDesigner designer = new WorkbookDesigner();
            Workbook workbook = new Workbook(mode.FullName);
            designer.Workbook = workbook;

            //通过占位符赋值
            designer.SetDataSource("recymd", "2015-10-21");
            designer.SetDataSource("vendorCode", "供应商11");
            designer.SetDataSource("vendorSale", "联系人11");
            designer.SetDataSource("vendorTel", "电话111");
            designer.SetDataSource("vendorFax", "传真11");
            designer.SetDataSource("warehouseDesc", "送货地点11");
            designer.SetDataSource("emp_name", "批准人111");

            //通过指定位置赋值
            designer.Workbook.Worksheets[0].Cells[4, 10].PutValue("3748324793274");

            //通过占位符生成表格数据
            DataTable dt = new DataTable("MFG_Part");
            dt.Columns.Add("PartNo",System.Type.GetType("System.String"));
            dt.Columns.Add("Description",System.Type.GetType("System.String"));
            for (int i = 0; i < 50; i++)
            {
                DataRow dr = dt.NewRow();

                dr["PartNo"] = "零件号" + i;
                dr["Description"] = "描述" + i;
                dt.Rows.Add(dr);
            }
            designer.SetDataSource(dt);

            designer.Process(0, true);


            //sheet2写入条码明细，通过指定位置赋值
            for (int i = 0; i < 20; i++)
            {
                designer.Workbook.Worksheets[1].Cells[i + 1, 0].PutValue("工厂名称"+i);
                designer.Workbook.Worksheets[1].Cells[i + 1, 1].PutValue("供应商"+i);
                designer.Workbook.Worksheets[1].Cells[i + 1, 2].PutValue("条码" + i);
                designer.Workbook.Worksheets[1].Cells[i + 1, 3].PutValue("零件号" + i);
                designer.Workbook.Worksheets[1].Cells[i + 1, 4].PutValue("描述" + i);
                designer.Workbook.Worksheets[1].Cells[i + 1, 5].PutValue("数量" + i);
                designer.Workbook.Worksheets[1].Cells[i + 1, 6].PutValue("项目" + i);
                designer.Workbook.Worksheets[1].Cells[i + 1, 7].PutValue("采购时间" + i);
                designer.Workbook.Worksheets[1].Cells[i + 1, 8].PutValue("编号" + i);
                designer.Workbook.Worksheets[1].Cells[i + 1, 9].PutValue("单号" + i);
            }
            designer.Process(1, true);
            
            int PRE_PAGE_ITEMS = 6;
            int lastSheet = 3;
            //第三个sheet，写入条码
                for (int rowIndex = 0; rowIndex < 31; rowIndex++)
                {
                    cellIndex = (rowIndex % PRE_PAGE_ITEMS) + 1;
                    sheetIndex = (rowIndex / PRE_PAGE_ITEMS) + 2;


                    if (0 == rowIndex % PRE_PAGE_ITEMS)
                    {
                        designer.Workbook.Worksheets.AddCopy(sheetIndex);
                        lastSheet = sheetIndex + 1;
                    }

                    designer.SetDataSource("barcode" + cellIndex, "*ZTXM" + rowIndex + "*");
                    designer.SetDataSource("supplier" + cellIndex, "VendorName" + rowIndex);
                    designer.SetDataSource("customer" + cellIndex, "customer" + rowIndex);
                    designer.SetDataSource("partNo" + cellIndex, "MATNR" + rowIndex);
                    designer.SetDataSource("partSpec" + cellIndex, "MAKTX" + rowIndex);
                    designer.SetDataSource("qty" + cellIndex, "ZDEV_NUM" + rowIndex);
                    designer.SetDataSource("lotNo" + cellIndex, "LotNo" + rowIndex);
                    designer.SetDataSource("model" + cellIndex, "ModelName" + rowIndex);
                    designer.SetDataSource("serialNo" + cellIndex, "SEQ" + rowIndex);
                    designer.SetDataSource("prodDate" + cellIndex, "ProdDate" + rowIndex);
                    designer.SetDataSource("poNo" + cellIndex, "subEBELN" + rowIndex);

                    designer.Process(sheetIndex, true);
                    designer.ClearDataSource();
                }

                //为最后一页不满页的数据赋空值
                if (PRE_PAGE_ITEMS - 31 % PRE_PAGE_ITEMS > 0)
                {
                    for (int rowIndex = PRE_PAGE_ITEMS - 31 % PRE_PAGE_ITEMS; rowIndex >= 31 % PRE_PAGE_ITEMS; rowIndex--)
                    {
                        cellIndex = (rowIndex % PRE_PAGE_ITEMS) + 1;

                        designer.SetDataSource("barcode" + cellIndex, "");
                        designer.SetDataSource("supplier" + cellIndex, "");
                        designer.SetDataSource("customer" + cellIndex, "");
                        designer.SetDataSource("partNo" + cellIndex, "");
                        designer.SetDataSource("partSpec" + cellIndex, "");
                        designer.SetDataSource("qty" + cellIndex, "");
                        designer.SetDataSource("lotNo" + cellIndex, "");
                        designer.SetDataSource("model" + cellIndex, "");
                        designer.SetDataSource("serialNo" + cellIndex, "");
                        designer.SetDataSource("prodDate" + cellIndex, "");
                        designer.SetDataSource("poNo" + cellIndex, "");

                        designer.Process(sheetIndex, true);
                        designer.ClearDataSource();
                    }
                    
                }
                designer.Workbook.Worksheets.RemoveAt(lastSheet);
                workbook.Save(FileName, SaveFormat.Xlsx);

        }
    }
}
