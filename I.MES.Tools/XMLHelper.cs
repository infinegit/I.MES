using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Xml;
using System.Dynamic;
using System.Xml.Linq;
using System.Linq;

namespace I.MES.Tools
{

    public class XMLHelper
    {
        #region 对象转换
        /// <summary>
        /// DataTable
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public static DataTable XMLToDataTable(string xmlData)
        {
            if (!String.IsNullOrEmpty(xmlData))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(new System.IO.StringReader(xmlData));
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
            }
            return null;
        }
        /// <summary>
        /// DataSet
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public static DataSet XMLToDataSet(string xmlData)
        {
            if (!String.IsNullOrEmpty(xmlData))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(new System.IO.StringReader(xmlData));
                return ds;
            }
            return null;
        }
        #endregion

        #region 增、删、改操作
        /// <summary>
        /// 追加节点
        /// </summary>
        /// <param name="filePath">XML文档绝对路径</param>
        /// <param name="xPath">范例: @"Skill/First/SkillItem"</param>
        /// <returns></returns>
        public static bool SaveXmlNode(string filePath, string xPath, string key, string value)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);

                XmlNode xn = doc.SelectSingleNode(xPath);
                XmlNode nodeRoot = xn;

                if (xn == null)
                {
                    string[] arrPath = xPath.Split('/');
                    string strPath = "";
                    foreach (var path in arrPath)
                    {
                        strPath += "/" + path;
                        XmlNode node = doc.SelectSingleNode(strPath);
                        if (node == null)
                        {
                            //创建根节点  
                            XmlElement xeRoot = doc.CreateElement(path);
                            nodeRoot.AppendChild(xeRoot);
                            nodeRoot = xeRoot;
                        }
                        else
                        {
                            nodeRoot = node;
                        }
                    }
                }
                // 用 'add'元件 格式化是否包含键名   
                // select the 'add' element that contains the key  
                XmlElement elem = (XmlElement)doc.SelectSingleNode(string.Format("//{0}/add[@key='{1}']", xPath, key));

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
                    nodeRoot.AppendChild(elem);
                }
                doc.Save(filePath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 追加节点
        /// </summary>
        /// <param name="filePath">XML文档绝对路径</param>
        /// <param name="xPath">范例: @"Skill/First/SkillItem"</param>
        /// <returns></returns>
        public static bool AppendChild(string filePath, string xPath)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);

                XmlNode xn = doc.SelectSingleNode(xPath);
                XmlNode nodeRoot = xn;
                if (xn == null)
                {
                    string[] arrPath = xPath.Split('/');
                    string strPath = "";
                    foreach (var path in arrPath)
                    {
                        strPath += "/" + path;
                        XmlNode node = doc.SelectSingleNode(strPath);
                        if (node == null)
                        {
                            //创建根节点  
                            XmlElement xeRoot = doc.CreateElement(path);
                            nodeRoot.AppendChild(xeRoot);
                            nodeRoot = xeRoot;
                        }
                        else
                        {
                            nodeRoot = node;
                        }
                    }
                }


                //XmlNode n = doc.ImportNode(xmlNode, true);
                //nodeRoot.AppendChild(n);
                //doc.Save(filePath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 从XML文档中读取节点追加到另一个XML文档中
        /// </summary>
        /// <param name="filePath">需要读取的XML文档绝对路径</param>
        /// <param name="xPath">范例: @"Skill/First/SkillItem"</param>
        /// <param name="toFilePath">被追加节点的XML文档绝对路径</param>
        /// <param name="toXPath">范例: @"Skill/First/SkillItem"</param>
        /// <returns></returns>
        public static bool AppendChild(string filePath, string xPath, string toFilePath, string toXPath)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(toFilePath);
                XmlNode xn = doc.SelectSingleNode(toXPath);

                XmlNodeList xnList = ReadNodes(filePath, xPath);
                if (xnList != null)
                {
                    foreach (XmlElement xe in xnList)
                    {
                        XmlNode n = doc.ImportNode(xe, true);
                        xn.AppendChild(n);
                    }
                    doc.Save(toFilePath);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 修改节点的InnerText的值
        /// </summary>
        /// <param name="filePath">XML文件绝对路径</param>
        /// <param name="xPath">范例: @"Skill/First/SkillItem"</param>
        /// <param name="value">节点的值</param>
        /// <returns></returns>
        public static bool UpdateNodeInnerText(string filePath, string xPath, string value)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                XmlNode xn = doc.SelectSingleNode(xPath);
                XmlElement xe = (XmlElement)xn;
                xe.InnerText = value;
                doc.Save(filePath);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 读取XML文档
        /// </summary>
        /// <param name="filePath">XML文件绝对路径</param>
        /// <returns></returns>
        public static XmlDocument LoadXmlDoc(string filePath)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                return doc;
            }
            catch
            {
                return null;
            }
        }
        #endregion 增、删、改操作

        #region 扩展方法
        /// <summary>
        /// 读取XML的所有子节点
        /// </summary>
        /// <param name="filePath">XML文件绝对路径</param>
        /// <param name="xPath">范例: @"Skill/First/SkillItem"</param>
        /// <returns></returns>
        public static XmlNodeList ReadNodes(string filePath, string xPath)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                XmlNode xn = doc.SelectSingleNode(xPath);
                XmlNodeList xnList = xn.ChildNodes;  //得到该节点的子节点
                return xnList;
            }
            catch
            {
                return null;
            }
        }

        public static string GetNodeValue(XmlNode node, string AttributeName)
        {
            try
            {
                XmlElement xe = (XmlElement)node;
                string strValue = xe.GetAttribute(AttributeName).ToString();
                return strValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion 扩展方法
    }


    public class DynamicXml : DynamicObject, IEnumerable
    {
        private readonly List<XElement> _elements;

        public DynamicXml(string text)
        {
            var doc = XDocument.Parse(text);
            _elements = new List<XElement> { doc.Root };
        }
        public static DynamicXml Parse(string xmlString)
        {
            return new DynamicXml(XDocument.Parse(xmlString).Root);
        }
        protected DynamicXml(XElement element)
        {
            _elements = new List<XElement> { element };
        }

        protected DynamicXml(IEnumerable<XElement> elements)
        {
            _elements = new List<XElement>(elements);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            if (binder.Name == "Value")
                result = _elements[0].Value;
            else if (binder.Name == "Count")
                result = _elements.Count;
            else
            {
                var attr = _elements[0].Attribute(XName.Get(binder.Name));
                if (attr != null)
                    result = attr;
                else
                {
                    var items = _elements.Descendants(XName.Get(binder.Name));
                    if (items == null || items.Count() == 0)
                        return false;
                    result = new DynamicXml(items);
                }
            }
            return true;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            int ndx = (int)indexes[0];
            result = new DynamicXml(_elements[ndx]);
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var element in _elements)
                yield return new DynamicXml(element);
        }

        public override string ToString()
        {
            if (_elements.Count == 1 && !_elements[0].HasElements)
            {
                return _elements[0].Value;
            }

            return string.Join("\n", _elements);
        }
    }

}
