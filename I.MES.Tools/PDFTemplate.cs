//责任人：吴林锋
//主要用途：模板模块，用于处理PDF模板。

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Diagnostics;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;    
using iTextSharp.text.io;


namespace I.MES.Tools
{
    /// <summary>
    /// PDF模板处理类
    /// </summary>
    public class PDFTemplate
    {
        BaseFont baseFont = null; //用于字体显示，该字体仅用于中文字体显示，英文字体仍旧用PDF模板中定义的字体来实现。
        /// <summary>
        /// 建构方法，使用CID字体
        /// </summary>
        public PDFTemplate()
        {
            try
            {
                StreamUtil.AddToResourceSearch("iTextAsian.dll");
                StreamUtil.AddToResourceSearch("iTextAsianCmaps.dll");
                baseFont = BaseFont.CreateFont("STSong-Light", "UniGB-UCS2-H", BaseFont.EMBEDDED);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 建构方法，使用内嵌字体
        /// </summary>
        /// <param name="fontPath">字体目录</param>
        /// <param name="fontName">字体文件名</param>
        public PDFTemplate(string fontFilePath, string fontFileName)
        {
            try
            {
                baseFont = BaseFont.CreateFont(fontFilePath + "\\" + fontFileName + ",1", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);  //这是嵌入字体的操作，如果不用CID字库，就可以用这个。
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 填充PDF表单
        /// </summary>
        /// <param name="templatePath">模板目录</param>
        /// <param name="templateFileName">模板文件名</param>
        /// <param name="dicFormData">表单数据</param>
        /// <returns>返回生成的新PDF文件名</returns>
        public string FillPDFForm(string templateFilePath, string templateFileName, Dictionary<string, string> dicFormData)
        {
            try
            {
                string newPDFFile = string.Empty;

                //string pdfTemplate = Environment.CurrentDirectory + @"\CJLR_IPOS_Template.pdf";
                string pdfTemplate = Environment.CurrentDirectory + templateFilePath + "\\" + templateFileName; //模板文件
                string templateFileName_ = templateFileName.Split('.')[0];
                string newFile = Environment.CurrentDirectory + @"\" + templateFileName_ + "." + Tools.StringTools.GenRandChar(8) + ".pdf"; //生成的新文件

                PdfReader pdfReader = new PdfReader(pdfTemplate); //读取模板
                PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create)); //根据模板生成新文件

                AcroFields pdfFormFields = pdfStamper.AcroFields; //取所有有效的表单元素 
                //遍历表单元素，并往里面填充数据
                foreach (KeyValuePair<string, AcroFields.Item> de in pdfFormFields.Fields)
                {
                    if (!dicFormData.ContainsKey(de.Key))
                    {
                        continue;
                    }
                    if (Tools.StringTools.HasChinese(dicFormData[de.Key].ToString())) //如果数据包含中文字符，使用中文字体
                    {
                        pdfFormFields.SetFieldProperty(de.Key, "textfont", baseFont, null);
                    }
                    pdfFormFields.SetField(de.Key, dicFormData[de.Key].ToString(), dicFormData[de.Key].ToString()); //设置表单元素的值
                }
                pdfStamper.FormFlattening = true; //平面化PDF文件
                pdfStamper.Close();
                pdfReader.Close();

                return newFile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 打印PDF文件
        /// </summary>
        /// <param name="fileNameWithPath">模板文件名(目录+文件名)</param>
        public void printPDFFile1(string fileNameWithPath)
        {
            try
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo()
                {
                    CreateNoWindow = true,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Verb = "print",
                    FileName = fileNameWithPath //put the correct path here
                };
                p.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 打印PDF文件
        /// </summary>
        /// <param name="fileNameWithPath">模板文件名(目录+文件名)</param>
        public void printPDFFile(string fileNameWithPath)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.FileName = fileNameWithPath; //put the correct path here
                p.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}