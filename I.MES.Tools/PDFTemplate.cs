//�����ˣ����ַ�
//��Ҫ��;��ģ��ģ�飬���ڴ���PDFģ�塣

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
    /// PDFģ�崦����
    /// </summary>
    public class PDFTemplate
    {
        BaseFont baseFont = null; //����������ʾ�����������������������ʾ��Ӣ�������Ծ���PDFģ���ж����������ʵ�֡�
        /// <summary>
        /// ����������ʹ��CID����
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
        /// ����������ʹ����Ƕ����
        /// </summary>
        /// <param name="fontPath">����Ŀ¼</param>
        /// <param name="fontName">�����ļ���</param>
        public PDFTemplate(string fontFilePath, string fontFileName)
        {
            try
            {
                baseFont = BaseFont.CreateFont(fontFilePath + "\\" + fontFileName + ",1", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);  //����Ƕ������Ĳ������������CID�ֿ⣬�Ϳ����������
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// ���PDF��
        /// </summary>
        /// <param name="templatePath">ģ��Ŀ¼</param>
        /// <param name="templateFileName">ģ���ļ���</param>
        /// <param name="dicFormData">������</param>
        /// <returns>�������ɵ���PDF�ļ���</returns>
        public string FillPDFForm(string templateFilePath, string templateFileName, Dictionary<string, string> dicFormData)
        {
            try
            {
                string newPDFFile = string.Empty;

                //string pdfTemplate = Environment.CurrentDirectory + @"\CJLR_IPOS_Template.pdf";
                string pdfTemplate = Environment.CurrentDirectory + templateFilePath + "\\" + templateFileName; //ģ���ļ�
                string templateFileName_ = templateFileName.Split('.')[0];
                string newFile = Environment.CurrentDirectory + @"\" + templateFileName_ + "." + Tools.StringTools.GenRandChar(8) + ".pdf"; //���ɵ����ļ�

                PdfReader pdfReader = new PdfReader(pdfTemplate); //��ȡģ��
                PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create)); //����ģ���������ļ�

                AcroFields pdfFormFields = pdfStamper.AcroFields; //ȡ������Ч�ı�Ԫ�� 
                //������Ԫ�أ����������������
                foreach (KeyValuePair<string, AcroFields.Item> de in pdfFormFields.Fields)
                {
                    if (!dicFormData.ContainsKey(de.Key))
                    {
                        continue;
                    }
                    if (Tools.StringTools.HasChinese(dicFormData[de.Key].ToString())) //������ݰ��������ַ���ʹ����������
                    {
                        pdfFormFields.SetFieldProperty(de.Key, "textfont", baseFont, null);
                    }
                    pdfFormFields.SetField(de.Key, dicFormData[de.Key].ToString(), dicFormData[de.Key].ToString()); //���ñ�Ԫ�ص�ֵ
                }
                pdfStamper.FormFlattening = true; //ƽ�滯PDF�ļ�
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
        /// ��ӡPDF�ļ�
        /// </summary>
        /// <param name="fileNameWithPath">ģ���ļ���(Ŀ¼+�ļ���)</param>
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
        /// ��ӡPDF�ļ�
        /// </summary>
        /// <param name="fileNameWithPath">ģ���ļ���(Ŀ¼+�ļ���)</param>
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