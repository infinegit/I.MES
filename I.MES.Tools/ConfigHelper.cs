using System;
using System.Xml;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;

namespace I.MES.Tools
{
    /// <summary>
    /// Config 文件读取设置
    /// </summary>
    public class ConfigHelper
    {

        public static string GetConfigString(string SectionPathName, string key)
        {
            var filePath = GetConfigFilePath("");
            XmlNodeList nodeList = XMLHelper.ReadNodes(filePath, SectionPathName);
            if (nodeList == null || nodeList.Count == 0)
            {
                return "";
            }
            else
            {
                foreach (XmlNode node in nodeList)
                {
                    if (XMLHelper.GetNodeValue(node, "key") == key)
                    {
                        return XMLHelper.GetNodeValue(node, "value");
                    }
                }

            }
            return "";
        }

        /// <summary>  
        /// 得到配置文件中的配置decimal信息  
        /// </summary>  
        /// <param name="key"></param>  
        /// <returns></returns>  
        public static decimal GetConfigDecimal(string SectionName, string key)
        {
            decimal result = 0;
            string cfgVal = GetConfigString(SectionName, key);
            if (null != cfgVal && string.Empty != cfgVal)
                result = decimal.Parse(cfgVal);

            return result;
        }
        /// <summary>  
        /// 得到配置文件中的配置int信息  
        /// </summary>  
        /// <param name="key"></param>  
        /// <returns></returns>  
        public static int GetConfigInt(string SectionName, string key)
        {
            int result = 0;
            string cfgVal = GetConfigString(SectionName, key);
            if (null != cfgVal && string.Empty != cfgVal)
                result = Int32.Parse(cfgVal);

            return result;
        }

        /// <summary>  
        /// 写入配置文件  
        /// </summary>  
        /// <param name="SectionName">节点名称</param>  
        /// <parma name="key">键名</param>  
        /// <parma name="value">键值</param>F:\至盈电子\PrintStock\PrintStock\PrintStock\Login.cs  
        public static void SetConfigKeyValue(string SectionPathName, string key, string value)
        {


            try
            {
                //导入配置文件  
                XmlDocument doc = LoadConfigDocument();
                //重新取得 节点名  
                XmlNode node = doc.SelectSingleNode("//" + SectionPathName);

                if (node == null)
                {
                    XMLHelper.SaveXmlNode(GetConfigFilePath(), SectionPathName, key, value);
                }
                else
                {
                    // 用 'add'元件 格式化是否包含键名   
                    // select the 'add' element that contains the key  
                    //XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", key));
                    XmlElement elem = (XmlElement)doc.SelectSingleNode(string.Format("//{0}/add[@key='{1}']", SectionPathName, key));
                    if (elem != null)
                    {
                        //修改或添加键值  
                        elem.SetAttribute("value", value);
                    }
                    else
                    {
                        //如果没有发现键名则进行添加设置键名和键值  
                        elem = doc.CreateElement("add");
                        elem.SetAttribute("key", key);
                        elem.SetAttribute("value", value);
                        node.AppendChild(elem);
                    }
                    doc.Save(GetConfigFilePath());
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>  
        /// 移除节点  
        /// </summary>  
        /// <param name="SectionName">节点名称</param>  
        /// <param name="key">键</param>  
        public static void RemoveSectionKey(string SectionName, string key)
        {
            //导入配置文件  
            XmlDocument doc = LoadConfigDocument();

            //重新取得 节点名  
            XmlNode node = doc.SelectSingleNode("//" + SectionName);

            try
            {
                if (node == null)
                    throw new InvalidOperationException(SectionName + " section not found in config file.");
                else
                {
                    // 用 'add' 方法格式 key和value  
                    node.RemoveChild(node.SelectSingleNode(string.Format("//add[@key='{0}']", key)));
                    doc.Save(GetConfigFilePath());
                }
            }
            catch (NullReferenceException e)
            {
                throw new Exception(string.Format("The key {0} does not exist.", key), e);
            }
        }

        /// <summary>  
        /// 读入配置文件  
        /// </summary>  
        private static XmlDocument LoadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(GetConfigFilePath());
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
        }

        /// <summary>  
        /// 取得置文件路径和名称  
        /// </summary>  
        private static string GetConfigFilePath(string FileName = "")
        {
            if (FileName == null || FileName == "")
            {
                string strFilePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "System.config";
                if (!File.Exists(strFilePath))
                {
                    CreateXML(strFilePath);
                }
                return strFilePath;
            }
            else
            {
                return AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            }
        }

        public static void CreateXML(string fileName)
        {
            string strXML = "<?xml version=\"1.0\" encoding=\"utf-8\"?><configuration></configuration>";

            //写入文件  
            try
            {
                //1.创建文件流    
                FileStream fileStream = new FileStream(fileName, FileMode.Create);
                //2.创建写入器    
                StreamWriter streamWriter = new StreamWriter(fileStream);
                //3.将内容写入文件    
                streamWriter.WriteLine(strXML);
                //4.关闭写入器    
                streamWriter.Close();
                //5.关闭文件流    
                fileStream.Close();
            }
            catch (Exception e)
            { }
        }

    }
}
