using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using YFPO.MES.Models;
using System.Configuration;
namespace YFPO.MES.Library
{
   [Shareable]
    public class ManualprintOP : BaseOP
    {

       public static string connectionString;
       // public static string ConnectionString;

        private int timeOut = 120;
        private CookieContainer cookieContainer = new CookieContainer();
          /// <summary>
        /// 构造函数
        /// </summary>
        public ManualprintOP(ClientInformation clientInfo)
            : base(clientInfo)
        {
            
        }

       [Shareable]
        public YFPO.MES.Models.OriginalData GetLoginInfor()
        {
            YFPO.MES.Models.OriginalData data = new YFPO.MES.Models.OriginalData();
            try
            {
               // DBEntities _db = new DBEntities("DBEntities");
               // string sql = @"SELECT * FROM dbo.SYS_GlobalConfig WHERE ConfigName='LoginUrl'";
               // SYS_GlobalConfig glocfg = _db.GetEntity<SYS_GlobalConfig>(sql);
                SYS_GlobalConfig glocfg = GetData<SYS_GlobalConfig>(p => p.ConfigName == "LoginUrl");
                if (glocfg != null)
                {
                    data.LoginUrl = glocfg.ParamValue.ToString();
                }

                //string sql_1 = @"SELECT * FROM dbo.SYS_GlobalConfig WHERE ConfigName='LoginUser' ";
                SYS_GlobalConfig cfg = GetData<SYS_GlobalConfig>(p => p.ConfigName == "LoginUser");

                if (cfg != null)
                {

                    data.UserName = cfg.ParamCode.ToString();
                    data.Password = cfg.ParamValue.ToString();

                }
                //初始化值
               // string sql_2 = @"SELECT * FROM dbo.SYS_GlobalConfig WHERE ConfigName='NIOEDIService' ";
                //SYS_GlobalConfig cfg_ = _db.GetEntity<SYS_GlobalConfig>(sql_2);
                SYS_GlobalConfig cfg_ = GetData<SYS_GlobalConfig>(p => p.ConfigName == "NIOEDIService");

                if (cfg_ != null)
                {

                    data.readTime = cfg_.ParamCode.ToString();
                    data.orderNo = cfg_.ParamValue.ToString();

                }
                //初始化值
              //  string sql_3 = @"SELECT * FROM dbo.SYS_GlobalConfig WHERE ConfigName='NIOEDIServicePrinter' ";
                SYS_GlobalConfig cfg_1 = GetData<SYS_GlobalConfig>(p => p.ConfigName == "NIOEDIServicePrinter");
                if (cfg_1 != null)
                {

                    data.PrinterName = cfg_1.ParamCode.ToString();
                    data.pathUr = cfg_1.ParamValue.ToString();
                }

                return data;
            }
            catch (Exception ex)
            {
                //WriteLog.Info(ex.Message);
                throw ex;
            }
        }
       [Shareable]
       public LGS_JISOrder GetJISInfor(string orderNo, List<SYS_ExternalDeviceParam> ed)
       {
           try
           {
              // string sql = @"SELECT * FROM dbo.LGS_JISOrder WHERE SeqOrderNo='" + orderNo + "' ";
               LGS_JISOrder jis = GetData<LGS_JISOrder>(p=>p.SeqOrderNo==orderNo);
               if (jis == null)
               {
                   string connectionString = ed.FirstOrDefault(p => p.ParamName == "ConnString").ParamValue;
                   string providerName = ed.FirstOrDefault(p => p.ParamName == "ProviderName").ParamValue;
                   EquipService.EquipServiceClient client = new EquipService.EquipServiceClient();
                   string sql = @"SELECT * FROM dbo.LGS_JISOrder WHERE SeqOrderNo='" + orderNo + "' ";
                   var data = client.ExecuteDataSet(connectionString, providerName, sql);
                   DataTable table = new DataTable();
                   table = data.Tables[0];
                   for (int i = 0; i < table.Rows.Count; i++)
                   {
                       //LGS_JISOrder jisorder = new LGS_JISOrder();
                       jis.Guid = table.Rows[i]["Guid"].ToString();
                       jis.OrderSerialNo = table.Rows[i]["OrderSerialNo"].ToString();
                       jis.CustCode = table.Rows[i]["CustCode"].ToString();
                       jis.CustPlant = table.Rows[i]["CustPlant"].ToString();
                       jis.CustAssemblyLine = table.Rows[i]["CustAssemblyLine"].ToString();
                       jis.CustDock = table.Rows[i]["CustDock"].ToString();
                       jis.SeqOrderNo = table.Rows[i]["SeqOrderNo"].ToString();
                       jis.CustOrderNo = table.Rows[i]["CustOrderNo"].ToString();
                       jis.ExpectedArrivalTime = DateTime.Parse(table.Rows[i]["ExpectedArrivalTime"].ToString());
                       jis.PublishTime = DateTime.Parse(table.Rows[i]["PublishTime"].ToString());
                       jis.SupplierCode = table.Rows[i]["SupplierCode"].ToString();
                       jis.CreateTime = DateTime.Parse(table.Rows[i]["CreateTime"].ToString());
                   }
               }
               return jis;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       [Shareable]
       public List<LGS_JISOrder> GetJISInfor(DateTime time, DateTime time1,List<SYS_ExternalDeviceParam> ed)
       {
           
           try
           {
             string connectionString = ed.FirstOrDefault(p => p.ParamName == "ConnString").ParamValue;
             string providerName = ed.FirstOrDefault(p => p.ParamName == "ProviderName").ParamValue;
             EquipService.EquipServiceClient client = new EquipService.EquipServiceClient();

            List<LGS_JISOrder> jisList = new List<LGS_JISOrder>();
            List<LGS_JISOrder> jis = GetList<LGS_JISOrder>(p => p.PublishTime >= time && p.PublishTime <= time1 && p.CustCode == "NEXTEV").ToList();
              jisList.AddRange(jis);
         string sql_ = @"SELECT * FROM dbo.LGS_JISOrder WHERE CustCode='NEXTEV' AND PublishTime>='" + time + "'AND PublishTime<='" + time1 + "' ";
            var  data = client.ExecuteDataSet(connectionString, providerName, sql_);
            DataTable table = new DataTable();
            table = data.Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            { 
                LGS_JISOrder jisorder=new LGS_JISOrder();
                jisorder.Guid = table.Rows[i]["Guid"].ToString();
                jisorder.OrderSerialNo = table.Rows[i]["OrderSerialNo"].ToString();
                jisorder.CustCode = table.Rows[i]["CustCode"].ToString();
                jisorder.CustPlant = table.Rows[i]["CustPlant"].ToString();
                jisorder.CustAssemblyLine = table.Rows[i]["CustAssemblyLine"].ToString();
                jisorder.CustDock = table.Rows[i]["CustDock"].ToString();
                jisorder.SeqOrderNo = table.Rows[i]["SeqOrderNo"].ToString();
                jisorder.CustOrderNo = table.Rows[i]["CustOrderNo"].ToString();
                jisorder.ExpectedArrivalTime = DateTime.Parse(table.Rows[i]["ExpectedArrivalTime"].ToString());
                jisorder.PublishTime =  DateTime.Parse(table.Rows[i]["PublishTime"].ToString());
                jisorder.SupplierCode = table.Rows[i]["SupplierCode"].ToString();
                jisorder.CreateTime = DateTime.Parse(table.Rows[i]["CreateTime"].ToString());
                jisList.Add(jisorder);
            }
                //jisList.AddRange(list);
                //jisList.AddRange((LGS_JISOrder)list);
              return jisList;


           }
           catch (Exception ex)
           {
               throw ex;
           }
           return null;
       }

     
       [Shareable]
       public List<SYS_ExternalDeviceParam> GetExternalDeviceParam(string deviceID, string inOutMode)
       {
           try
           {
               return GetList<SYS_ExternalDeviceParam>(p => p.DeviceID == deviceID && p.InOutMode == inOutMode).ToList();
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
       public static int count = 0;
       public static string mes = "";
       [Shareable]
       public string printPDFFile(string fileNameWithPath)
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
                   //Arguments = @"/p /h \" + "10.226.19.108" + "\" \"" + "hefei" + " \"",//pd.PrinterSettings.PrinterName;  
                   //Arguments =NIOEDIService.PrinterName,
                   //doc.PrinterSettings.PrinterName = @"\\10.226.19.108\hefei";
                   FileName = fileNameWithPath
               };
               bool bo = p.Start();
               if (bo)
               {
                   return mes = "打印成功！！";
               }
               else
               {

                   count++;
                   if (count <= 3)
                   {
                       printPDFFile(fileNameWithPath);
                   }
                   else
                   {
                       return mes = "打印失败！！";
                   }
               }
           }
           catch (Exception ex)
           {
               mes =("启动打印失败" + ex.Message);
               throw ex;
           }
           return mes;
       }
       #region 登陆验证相关方法
       [Shareable]
       public bool Login(string userName, string password, string LoginUrl)
       {
           string htmlPage = Logined(userName, password, LoginUrl);
           //TODO:Resolve htmlPage;
           return LoginResolve(htmlPage);
       }

       public string Logined(string userName, string password,string LoginUrl, params object[] args)
       {
           if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
           {
               return string.Empty;
           }

           int resultCode = 0;
           string htmlPage = string.Empty;
           string url_1 = LoginUrl;
           string referer = url_1;
           //Uri uri = new Uri(url_1 + "/login-query.action");
           Uri uri = new Uri(url_1);
           NameValueCollection collction = new NameValueCollection();
           collction.Add("userName", userName);
           collction.Add("password", password);


           resultCode = HtmlRequest(uri, YFPO.MES.Models.MethodType.POST, referer, collction, timeOut, cookieContainer, Encoding.UTF8, out htmlPage);
           return htmlPage;
       }

       public bool LoginResolve(string htmlPage)
       {
           if (string.IsNullOrEmpty(htmlPage))
           {
               return false;
           }

           // Regex regex = new Regex(REG_LOGIN_EXPRESS, RegexOptions.IgnoreCase | RegexOptions.Compiled);
           Regex regex = new Regex("", RegexOptions.IgnoreCase | RegexOptions.Compiled);
           return regex.IsMatch(htmlPage);
       }


       public int HtmlRequest(Uri uri, YFPO.MES.Models.MethodType methodType, string referer, NameValueCollection parameter, int timeOut, CookieContainer cookieContainer, Encoding encoding, out string htmlPage)
       {
           byte[] array = null;
           string text = string.Empty;
           HttpWebRequest httpWebRequest = null;
           UriBuilder uriBuilder = new UriBuilder(uri);
           StringBuilder stringBuilder = new StringBuilder();
           if (parameter != null)
           {
               string text2 = string.Empty;
               if (string.IsNullOrEmpty(uriBuilder.Query))
               {
                   text2 = "{0}={1}&";
               }
               else
               {
                   text2 = "&{0}={1}";
               }
               string[] allKeys = parameter.AllKeys;
               for (int i = 0; i < allKeys.Length; i++)
               {
                   string text3 = allKeys[i];
                   stringBuilder.AppendFormat(text2,HttpUtility.UrlEncode(text3, encoding), HttpUtility.UrlEncode(parameter[text3], encoding));
               }
               if (text2 == "{0}={1}&" && stringBuilder.Length > 0)
               {
                   UriBuilder expr_CD = uriBuilder;
                   expr_CD.Query += stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString();
               }
               stringBuilder.Clear();
               if (methodType == YFPO.MES.Models.MethodType.GET)
               {
                   uri = uriBuilder.Uri;
               }
               else if (methodType == YFPO.MES.Models.MethodType.POST)
               {
                   allKeys = parameter.AllKeys;
                   for (int i = 0; i < allKeys.Length; i++)
                   {
                       string text3 = allKeys[i];
                       stringBuilder.AppendFormat("{0}={1}&", HttpUtility.UrlEncode(text3, encoding), HttpUtility.UrlEncode(parameter[text3], encoding));
                   }
                   array = encoding.GetBytes(stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString());
                   stringBuilder.Clear();
               }
           }
           try
           {


               httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
               httpWebRequest.Headers[HttpRequestHeader.AcceptLanguage] = "zh-CN,zh;q=0.8";
               httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36";
               if (timeOut > 0)
               {
                   httpWebRequest.Timeout = timeOut * 1000;
               }
               if (!string.IsNullOrWhiteSpace(referer))
               {
                   httpWebRequest.Referer = referer.Trim();
               }
               if (cookieContainer != null)
               {
                   httpWebRequest.CookieContainer = cookieContainer;
               }
               httpWebRequest.Method = methodType.ToString();
               httpWebRequest.KeepAlive = true;
               if (methodType == YFPO.MES.Models.MethodType.POST)
               {
                   httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                   httpWebRequest.ContentLength = (long)array.Length;
                   using (Stream stream = httpWebRequest.GetRequestStream())
                   {
                       stream.Write(array, 0, array.Length);
                   }
               }
               HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
               byte[] bytes = null;
               byte[] array2 = new byte[1024];
               using (MemoryStream memoryStream = new MemoryStream())
               {
                   using (Stream stream = httpWebResponse.GetResponseStream())
                   {
                       int num;
                       do
                       {
                           num = stream.Read(array2, 0, array2.Length);
                           if (num > 0)
                           {
                               memoryStream.Write(array2, 0, num);
                           }
                       }
                       while (num > 0);
                   }
                   memoryStream.Position = 0L;
                   bytes = memoryStream.ToArray();
               }
               string name = string.Empty;
               if (!string.IsNullOrEmpty(httpWebResponse.CharacterSet))
               {
                   name = httpWebResponse.CharacterSet;
               }
               else if (!string.IsNullOrEmpty(httpWebResponse.ContentType))
               {
                   string[] array3 = httpWebResponse.ContentType.Split(new char[]
					{
						';'
					});
                   if (array3.Length == 2)
                   {
                       string[] array4 = array3[1].Split(new char[]
						{
							'='
						});
                       if (array4.Length == 2)
                       {
                           name = array4[1].Trim();
                       }
                   }
               }
               try
               {
                   encoding = Encoding.GetEncoding(name);
               }
               catch
               {
               }
               text = encoding.GetString(bytes);
               if (cookieContainer != null)
               {
                   try
                   {
                       cookieContainer.SetCookies(httpWebResponse.ResponseUri, httpWebResponse.Headers[HttpResponseHeader.SetCookie]);
                   }
                   catch
                   {
                   }
               }
           }
           catch (WebException ex)
           {
               throw ex;
           }
           catch (Exception ex2)
           {
               throw ex2;
           }
           htmlPage = text;
           return 0;
       }
       #endregion

       #region 获取排序单
       ///// <summary>
       ///// 按照页数和行数下载排序单信息
       ///// </summary>
       ///// <param name="pageNum">页号</param>
       ///// <param name="pageSize">每页的行数</param>
       ///// <returns></returns>
       // [Shareable]
       //public string GetJISCodeByPage(string delivery)
       //{
       //    int resultCode = 0;
       //    string htmlPage = string.Empty;

       //    string referer = "https://nevsp-prd.portal.ap1.covapp.io/nio-supplyonline?p_p_id=sonextev_WAR_sonextevportlet_INSTANCE_aMlHp3wu9iEC&p_p_lifecycle=0&p_p_state=normal&mainAction=nextEvSupplyonlineJISQuery&divId=menu10Child&isVisiable=true";
       //    Uri uri = new Uri("https://nevsp-prd.portal.ap1.covapp.io/so-nextev-portlet/nextEvSOLJISQuery.ajax?siteLanguage=zh&action=list&userSsoId=NEV25524-1&sessionBuyerCompanyCode=NEXTEV&userGroup=NEXTEV_SP");

       //    NameValueCollection collection = new NameValueCollection();
       //    collection.Add("page", "");
       //    collection.Add("pageSize", "50");
       //    collection.Add("needDateFromStr", "");
       //    collection.Add("needDateToStr", "");
       //    collection.Add("deliveryNo", delivery);
       //    collection.Add("status", "");//Shipped 已经发货
       //    resultCode = HtmlRequest(uri, MethodType.POST, referer, collection, timeOut, cookieContainer, Encoding.UTF8, out htmlPage);
       //    return htmlPage;
       //}
       // [Shareable]
       //public string GetJISCodeByPageDet(string deliveryNo)
       //{
       //    int resultCode = 0;
       //    string htmlPage = string.Empty;

       //    string referer = "https://nevsp-prd.portal.ap1.covapp.io/nio-supplyonline?p_p_id=sonextev_WAR_sonextevportlet_INSTANCE_aMlHp3wu9iEC&p_p_lifecycle=0&p_p_state=normal&mainAction=nextEvSupplyonlineJISQuery&divId=menu10Child&isVisiable=true";
       //    Uri uri = new Uri("https://nevsp-prd.portal.ap1.covapp.io/so-nextev-portlet/nextEvSOLJISQuery.ajax?siteLanguage=zh&action=detailList&userSsoId=NEV25524-1&sessionBuyerCompanyCode=NEXTEV&userGroup=NEXTEV_SP");

       //    NameValueCollection collection = new NameValueCollection();
       //    collection.Add("page", "1");
       //    collection.Add("pageSize", "50");
       //    collection.Add("PartnerCode", "");
       //    collection.Add("deliveryNo", deliveryNo);
       //    collection.Add("status", "");
       //    resultCode = HtmlRequest(uri, MethodType.POST, referer, collection, timeOut, cookieContainer, Encoding.UTF8, out htmlPage);
       //    //return htmlPageHelper.DownloadHtml(referer, Encoding.UTF8);
       //    return htmlPage;
       //}

       /// <summary>
       /// 下载排序单
       /// </summary>
       /// <returns></returns>
       [Shareable]
       public string DownFileByPage(string deliveryNo, string partnerCode,string pathUr)
       {
           int resultCode = 0;
           string htmlPage = string.Empty;
           string referer = "https://nevsp-prd.portal.ap1.covapp.io/nio-supplyonline?p_p_id=sonextev_WAR_sonextevportlet_INSTANCE_aMlHp3wu9iEC&p_p_lifecycle=0&p_p_state=normal&mainAction=nextEvSupplyonlineJISQuery&divId=menu10Child&isVisiable=true";
           Uri uri = new Uri("https://nevsp-prd.portal.ap1.covapp.io/so-nextev-portlet/nextEvSOLJISDeliveryNotePdfDownload.ajax?&siteLanguage=zh&partnerCode=V25524&deliveryNo=" + deliveryNo + "");
           //  string URL = @"https://nevsp-prd.portal.ap1.covapp.io/so-nextev-portlet/nextEvSOLJISDeliveryNotePdfDownload.ajax?&siteLanguage=zh&partnerCode=V25524&deliveryNo=" + deliveryNo + "";

           NameValueCollection collection = new NameValueCollection();
           collection.Add("deliveryNo", deliveryNo);
           collection.Add("partnerCode", partnerCode);
           //D:\IMES3\YFPO.MES.MCS\NIOEDILog
           //string locationUrl  = @"C:\Users\陈梦\Desktop\蔚来汽车\Log\";
           string locationUrl = pathUr;

           //else if(flag==2)
           //{
           //    locationUrl = @"C:\Users\陈梦\Desktop\蔚来汽车\NIOEDILog\";
           //}
           //else if(flag==3)
           //{
           //    locationUrl = @"C:\Users\陈梦\Desktop\蔚来汽车\ANIOEDILog\";
           //}
           resultCode = HtmlDownFile(uri, MethodType.POST, referer, collection, timeOut, cookieContainer, Encoding.UTF8, "pdf", "application/x-www-form-urlencoded", deliveryNo, locationUrl);
           return htmlPage;

       }

       public int HtmlDownFile(Uri uri, MethodType methodType, string referer, NameValueCollection parameter, int timeOut, CookieContainer cookieContainer, Encoding encoding, string fileType, string contentType, string deliveryNo, string locationUrl)
       {
           byte[] array = null;
           string text = string.Empty;
           HttpWebRequest httpWebRequest = null;
           UriBuilder uriBuilder = new UriBuilder(uri);
           StringBuilder stringBuilder = new StringBuilder();
           if (parameter != null)
           {
               string text2 = string.Empty;
               if (string.IsNullOrEmpty(uriBuilder.Query))
               {
                   text2 = "{0}={1}&";
               }
               else
               {
                   text2 = "&{0}={1}";
               }
               string[] allKeys = parameter.AllKeys;
               for (int i = 0; i < allKeys.Length; i++)
               {
                   string text3 = allKeys[i];
                   stringBuilder.AppendFormat(text2, HttpUtility.UrlEncode(text3, encoding), HttpUtility.UrlEncode(parameter[text3], encoding));
               }
               if (text2 == "{0}={1}&" && stringBuilder.Length > 0)
               {
                   UriBuilder expr_CD = uriBuilder;
                   expr_CD.Query += stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString();
               }
               stringBuilder.Clear();
               if (methodType == MethodType.GET)
               {
                   uri = uriBuilder.Uri;
               }
               else if (methodType == MethodType.POST)
               {
                   allKeys = parameter.AllKeys;
                   for (int i = 0; i < allKeys.Length; i++)
                   {
                       string text3 = allKeys[i];
                       stringBuilder.AppendFormat("{0}={1}&", HttpUtility.UrlEncode(text3, encoding), HttpUtility.UrlEncode(parameter[text3], encoding));
                   }
                   array = encoding.GetBytes(stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString());
                   stringBuilder.Clear();
               }
           }
           try
           {
               httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
               httpWebRequest.Headers[HttpRequestHeader.AcceptLanguage] = "zh-CN,zh;q=0.8";
               httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36";
               if (timeOut > 0)
               {
                   httpWebRequest.Timeout = timeOut * 1000;
               }
               if (!string.IsNullOrWhiteSpace(referer))
               {
                   httpWebRequest.Referer = referer.Trim();
               }
               if (cookieContainer != null)
               {
                   httpWebRequest.CookieContainer = cookieContainer;
               }
               httpWebRequest.Method = methodType.ToString();
               httpWebRequest.KeepAlive = true;
               if (methodType == MethodType.POST)
               {
                   httpWebRequest.ContentType = contentType;// "application/x-www-form-urlencoded";  //Content-Type: application/pdftext/x-download;
                   httpWebRequest.ContentLength = (long)array.Length;
                   using (Stream stream = httpWebRequest.GetRequestStream())
                   {
                       stream.Write(array, 0, array.Length);
                   }
               }
               HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

               using (Stream stream = httpWebResponse.GetResponseStream())
               {
                   using (FileStream fileStream = new FileStream(string.Format("{0}{1}.{2}", locationUrl, deliveryNo, fileType), FileMode.Create, FileAccess.Write))
                   {
                       int size = 2048;
                       byte[] data = new byte[2048];
                       while (true)
                       {
                           size = stream.Read(data, 0, data.Length);
                           if (size > 0)
                           {
                               fileStream.Write(data, 0, size);
                           }
                           else
                           {
                               break;
                           }
                       }
                   }
               }

               return 0;

               byte[] bytes = null;
               byte[] array2 = new byte[1024];
               using (MemoryStream memoryStream = new MemoryStream())
               {
                   using (Stream stream = httpWebResponse.GetResponseStream())
                   {
                       int num;
                       do
                       {
                           num = stream.Read(array2, 0, array2.Length);
                           if (num > 0)
                           {
                               memoryStream.Write(array2, 0, num);
                           }
                       }
                       while (num > 0);
                   }
                   memoryStream.Position = 0L;
                   bytes = memoryStream.ToArray();
               }
               string name = string.Empty;
               if (!string.IsNullOrEmpty(httpWebResponse.CharacterSet))
               {
                   name = httpWebResponse.CharacterSet;
               }
               else if (!string.IsNullOrEmpty(httpWebResponse.ContentType))
               {
                   string[] array3 = httpWebResponse.ContentType.Split(new char[]
					{
						';'
					});
                   if (array3.Length == 2)
                   {
                       string[] array4 = array3[1].Split(new char[]
						{
							'='
						});
                       if (array4.Length == 2)
                       {
                           name = array4[1].Trim();
                       }
                   }
               }
               try
               {
                   encoding = Encoding.GetEncoding(name);
               }
               catch
               {
               }
               text = encoding.GetString(bytes);
               if (cookieContainer != null)
               {
                   try
                   {
                       cookieContainer.SetCookies(httpWebResponse.ResponseUri, httpWebResponse.Headers[HttpResponseHeader.SetCookie]);
                   }
                   catch
                   {
                   }
               }
           }
           catch (WebException ex)
           {
               throw ex;
           }
           catch (Exception ex2)
           {
               throw ex2;
           }
           return 0;
       }
      [Shareable]
       public List<NIOJitOutIns> ParsingHtml(string html)
       {
           try
           {

               HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
               List<NIOJitOutIns> jisIns = new List<NIOJitOutIns>();
               doc.LoadHtml(html);
               string liPath = "//*[@class='covisint-supplyonline-table nextev-table']/td";
               HtmlNodeCollection nodeList = doc.DocumentNode.SelectNodes(liPath);
               int i = 0;
               int count = 1;
               if (nodeList != null)
               {
                   NIOJitOutIns JitOutIn = new NIOJitOutIns();
                   foreach (HtmlNode node in nodeList)
                   {
                       string secondHtml = node.InnerHtml;
                       //if (string.IsNullOrWhiteSpace(secondHtml)) continue;
                       HtmlAgilityPack.HtmlDocument secondDoc = new HtmlAgilityPack.HtmlDocument();
                       secondDoc.LoadHtml(secondHtml);
                       if (node != null)
                       {
                           i++;
                           if (i % 9 == 1)
                           {
                               JitOutIn.PartnerCode = node.InnerText.Replace("&nbsp;", "");
                           }
                           else if (i % 9 == 2)
                           {
                               JitOutIn.PartnerName = node.InnerText.Replace("&nbsp;", "");
                           }
                           else if (i % 9 == 3)
                           {
                               HtmlNode secondNode = secondDoc.DocumentNode.SelectSingleNode("/a");
                               JitOutIn.deliveryNo = secondNode.InnerText.Replace("&nbsp;", "");
                           }
                           else if (i % 9 == 5)
                           {
                               JitOutIn.needDateToStr = node.InnerText.Replace("&nbsp;", "");
                           }
                           else if (i % 9 == 6)
                           {
                               JitOutIn.RecFactoryName = node.InnerText.Replace("&nbsp;", "");
                           }
                           else if (i % 9 == 7)
                           {
                               JitOutIn.RecFactoryCode = node.InnerText.Replace("&nbsp;", "");
                           }
                           else if (i % 9 == 0)
                           {
                               JitOutIn.ID = count;
                               count++;
                               jisIns.Add(JitOutIn);
                               JitOutIn = new NIOJitOutIns();
                               //if (jisIns.Count == 50)
                               //{
                               //    return jisIns;
                               //}
                           }

                       }

                   }
               }
               return jisIns;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
      [Shareable]
       public NIOJitOutIns ParsingDetHtml(string html, NIOJitOutIns outIns)
       {
           try
           {
               HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
               doc.LoadHtml(html);
               string liPath = "//*[@class='covisint-supplyonline-table nextev-table']/tr";
               HtmlNodeCollection nodeList = doc.DocumentNode.SelectNodes(liPath);
               if (nodeList != null)
               {
                   NIOJitOutInsDet det = new NIOJitOutInsDet();
                   foreach (HtmlNode node in nodeList)
                   {
                       string secondHtml = node.InnerHtml;
                       // if (string.IsNullOrWhiteSpace(secondHtml)) continue;
                       HtmlAgilityPack.HtmlDocument secondDoc = new HtmlAgilityPack.HtmlDocument();
                       secondDoc.LoadHtml(secondHtml);
                       HtmlNodeCollection nodeSlist = secondDoc.DocumentNode.SelectNodes("/td");
                       int i = 0;
                       if (nodeSlist != null)
                       {
                           foreach (HtmlNode nod in nodeSlist)
                           {
                               i++;
                               if (i % 14 == 1)
                               {
                                   det.SeriNo = nod.InnerText.Replace("&nbsp;", "");
                               }
                               else if (i % 14 == 2)
                               {
                                   det.CarSeriNo = nod.InnerText.Replace("&nbsp;", "");
                               }
                               else if (i % 14 == 3)
                               {
                                   det.PartNo = nod.InnerText.Replace("&nbsp;", "");
                               }
                               else if (i % 14 == 4)
                               {
                                   det.PartDec = nod.InnerText.Replace("&nbsp;", "");
                               }
                               else if (i % 14 == 5)
                               {
                                   det.Vehicle = nod.InnerText.Replace("&nbsp;", "");
                               }
                               else if (i % 14 == 6)
                               {
                                   det.VinCode = nod.InnerText.Replace("&nbsp;", "");
                               }
                               else if (i % 14 == 7)
                               {
                                   det.VehicleCode = nod.InnerText.Replace("&nbsp;", "");
                               }
                               else if (i % 14 == 8)
                               {
                                   det.VehicleDec = nod.InnerText.Replace("&nbsp;", "");
                               }
                               else if (i % 14 == 9)
                               {
                                   det.NeedRctTime = nod.InnerText.Replace("&nbsp;", "");
                               }
                               else if (i % 14 == 10)
                               {
                                   det.NA = nod.InnerText.Replace("&nbsp;", "");
                               }
                               else if (i % 14 == 11)
                               {
                                   det.NeedQty = nod.InnerText.Replace("&nbsp;", "");
                               }
                               else if (i % 14 == 12)
                               {
                                   det.PackQty = nod.InnerText.Replace("&nbsp;", "");
                               }
                               else if (i % 14 == 13)
                               {
                                   det.ContainerCode = nod.InnerText.Replace("&nbsp;", "");
                               }
                               else if (i % 14 == 0)
                               {
                                   det.Note = nod.InnerText.Replace("&nbsp;", "");
                                   outIns.listArray.Add(det);
                                   det = new NIOJitOutInsDet();
                               }
                           }
                       }
                   }
               }
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return outIns;
       }
       /// <summary>
       /// 生成Guid
       /// </summary>
       /// <returns></returns>
       [Shareable]
       public string GetGUID()
       {
           try
           {
               return System.Guid.NewGuid().ToString().ToUpper();
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       /// <summary>
       /// 写入主表
       /// </summary>
       /// <param name="order"></param>
       /// <returns></returns>
       [Shareable]
       public string InsertJisOrder(LGS_JISOrder order)
       {
           try
           {
               string sql = @"INSERT INTO dbo.LGS_JISOrder
                                        ( Guid ,
                                          OrderSerialNo ,
                                          CustCode ,
                                          CustPlant ,
                                          CustAssemblyLine ,
                                          CustDock ,
                                          SeqOrderNo ,
                                          CustOrderNo ,
                                          ProduceYear ,
                                          ProduceDate ,
                                          PublishTime ,
                                          ExpectedArrivalTime ,
                                          SupplierCode ,
                                          CreateTime ,
                                          IsLeave
                                        )
                                VALUES  ( N'" + order.Guid + @"' , -- Guid - nvarchar(50)
                                          N'" + order.OrderSerialNo + @"' , -- OrderSerialNo - nvarchar(20)
                                          N'" + order.CustCode + @"' , -- CustCode - nvarchar(20)
                                          N'" + order.CustPlant + @"' , -- CustPlant - nvarchar(20)
                                          N'" + order.CustAssemblyLine + @"' , -- CustAssemblyLine - nvarchar(20)
                                          N'" + order.CustDock + @"' , -- CustDock - nvarchar(20)
                                          N'" + order.SeqOrderNo + @"' , -- SeqOrderNo - nvarchar(50)
                                          N'" + order.CustOrderNo + @"' , -- CustOrderNo - nvarchar(50)
                                          N'" + order.ProduceYear + @"' , -- ProduceYear - nvarchar(20)
                                          '" + order.ProduceDate + @"' , -- ProduceDate - datetime
                                          '" + order.PublishTime + @"' , -- PublishTime - datetime
                                          '" + order.ExpectedArrivalTime + @"' , -- ExpectedArrivalTime - datetime
                                          N'" + order.SupplierCode + @"' , -- SupplierCode - nvarchar(20)
                                          GETDATE(),  -- CreateTime - datetimes
                                          0  -- IsLeave - int
                                        )";
               return sql;

           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       /// <summary>
       /// 写入明细表
       /// </summary>
       /// <param name="det"></param>
       /// <returns></returns>
       [Shareable]
       public string InsertJisOrderDet(LGS_JISOrderDet det)
       {
           try
           {
               string sql = @"INSERT INTO dbo.LGS_JISOrderDet
                                            ( SeqGuid ,
                                              VinCode ,
                                              CarNo ,
                                              CustPartNo ,
                                              PartNo ,
                                              PartDesc,
                                              FlexTime,
                                              VehicleCode ,
                                              Category2 ,
                                              Category3 ,
                                              BoxSerialNo ,
                                              TotalSerialNo ,
                                              RackNo ,
                                              IsAssemblied ,
                                              IsShipped ,
                                              IsJump ,
                                              IsSetsDist ,
                                              ProductBarcode ,
                                              BriefCustPartNo
                                            )
                                    VALUES  ( N'" + det.SeqGuid + @"' , -- SeqGuid - nvarchar(50)
                                              N'" + det.VinCode + @"' , -- VinCode - nvarchar(50)
                                              N'" + det.CarNo + @"' , -- CarNo - nvarchar(50)
                                              N'" + det.CustPartNo + @"' , -- CustPartNo - nvarchar(50)
                                              N'" + det.PartNo + @"' , -- PartNo - nvarchar(20)
                                              N'" + det.PartDesc + @"' ,  -- PartDesc - nvarchar(50)
                                              N'" + det.FlexTime + @"' ,  -- PartDesc - nvarchar(50)
                                              N'" + det.VinCode + @"' , -- VehicleCode - nvarchar(20)
                                              N'" + det.Category2 + @"' , -- Category2 - nvarchar(20)
                                              N'" + det.Category3 + @"' , -- Category3 - nvarchar(20)
                                              '" + det.BoxSerialNo + @"' , -- BoxSerialNo - int
                                              '" + det.TotalSerialNo + @"' , -- TotalSerialNo - int
                                              N'" + det.RackNo + @"',  -- RackNo - nvarchar(20)
                                              0 , -- IsAssemblied - bit
                                              0 , -- IsShipped - bit
                                              0 , -- IsJump - bit
                                              0 , -- IsSetsDist - bit
                                              N'',
                                              '" + det.BriefCustPartNo + @"' )";

               return sql;

           }
           catch (Exception ex)
           {
               throw ex;
           }

       }

       /// <summary>
       /// 获取对应MESPartNo
       /// </summary>
       /// <param name="custPartNo"></param>
       /// <returns></returns>
       [Shareable]
       public MmToMesData GetOtherData(string custPartNo, bool falg, List<SYS_ExternalDeviceParam> ed)
       {

           try
           {
               YFPO.MES.Library.EF.MESEntities sqlDB = new YFPO.MES.Library.EF.MESEntities();
               MmToMesData data = new MmToMesData();
               StringBuilder SqlStringBuilder = new StringBuilder(1024);
               SqlStringBuilder.Append("SELECT  b.PartNo , ");
               SqlStringBuilder.Append("        b.Category2 , ");
               SqlStringBuilder.Append("        b.Description , ");
               SqlStringBuilder.Append("        b.Category3 ");
               SqlStringBuilder.Append("FROM    LGS_CustomerPart a ");
               SqlStringBuilder.Append("        LEFT JOIN dbo.MFG_Part b ON a.MESPartNo = b.PartNo ");
               SqlStringBuilder.Append("WHERE   a.CustomerPartNo = @custPartNo; ");
               IDbDataParameter[] Parameters = new IDbDataParameter[1];
               Parameters[0] = new System.Data.SqlClient.SqlParameter("@custPartNo", custPartNo);
               if (falg)
               {
                   data = sqlDB.Database.SqlQuery<MmToMesData>(SqlStringBuilder.ToString(), Parameters).FirstOrDefault();
               }
               else
               {
                   string connectionString = ed.FirstOrDefault(p => p.ParamName == "ConnString").ParamValue;
                   string providerName = ed.FirstOrDefault(p => p.ParamName == "ProviderName").ParamValue;
                   EquipService.EquipServiceClient client = new EquipService.EquipServiceClient();
                   string sql_ = @"SELECT  b.PartNo ,
        b.Category2 ,
        b.Description ,
        b.Category3
FROM    LGS_CustomerPart a
        LEFT JOIN dbo.MFG_Part b ON a.MESPartNo = b.PartNo
WHERE   a.CustomerPartNo ='" + custPartNo + "' ";
                   var da = client.ExecuteDataSet(connectionString, providerName, sql_);
                   DataTable table = new DataTable();
                   table = da.Tables[0];
                   for (int i = 0; i < table.Rows.Count; i++)
                   {

                       data.Description = table.Rows[i]["Description"].ToString();
                       data.Category2 = table.Rows[i]["Category2"].ToString();
                       data.Category3 = table.Rows[i]["Category3"].ToString();
                       data.PartNo = table.Rows[i]["PartNo"].ToString();
                   }
               }
               return data;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       /// <summary>
       /// 文件的转移
       /// </summary>
       /// <param name="sourcePath"></param>
       /// <param name="destPath"></param>
       /// <param name="deliveryNo"></param>
       [Shareable]
       public void MoveFolder(string sourcePath, string destPath, string deliveryNo)
       {
           if (Directory.Exists(sourcePath))
           {
               if (!Directory.Exists(destPath))
               {
                   //目标目录不存在则创建
                   try
                   {
                       Directory.CreateDirectory(destPath);
                   }
                   catch (Exception ex)
                   {
                       throw new Exception("创建目标目录失败：" + ex.Message);
                   }
               }
               //获得源文件下所有文件]
               string sourceFile = sourcePath + "\\" + deliveryNo + ".pdf";
               //List<string> files = new List<string>(Directory.GetFiles(sourcePath));
               //files.ForEach(c =>
               //{
               string destFile = Path.Combine(new string[] { destPath, Path.GetFileName(sourceFile) });
               //覆盖模式
               if (File.Exists(destFile))
               {
                   File.Delete(destFile);
               }
               File.Move(sourceFile, destFile);
               //});
               //获得源文件下所有目录文件
               //List<string> folders = new List<string>(Directory.GetDirectories(sourcePath));

               //folders.ForEach(c =>
               //{
               //    string destDir = Path.Combine(new string[] { destPath, Path.GetFileName(c) });
               //    //Directory.Move必须要在同一个根目录下移动才有效，不能在不同卷中移动。
               //    //Directory.Move(c, destDir);

               //    //采用递归的方法实现
               //   // MoveFolder(c, destDir,"");
               //});
           }
           else
           {
               throw new DirectoryNotFoundException("源目录不存在！");
           }
       }


       /// <summary>
       /// 执行多条SQL语句，实现数据库事务。
       /// </summary>
       /// <param name="SQLStringList">多条SQL语句</param>	
       [Shareable]
       public  void ExecuteSqlTran(ArrayList SQLStringList)
       {

            connectionString = this.DB.Database.Connection.ConnectionString;
           using (SqlConnection conn = new SqlConnection(connectionString))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand();
               cmd.Connection = conn;
               SqlTransaction tx = conn.BeginTransaction();
               cmd.Transaction = tx;
               try
               {
                   for (int n = 0; n < SQLStringList.Count; n++)
                   {
                       string strsql = SQLStringList[n].ToString();
                       if (strsql.Trim().Length > 1)
                       {
                           cmd.CommandText = strsql;
                           cmd.ExecuteNonQuery();
                       }
                   }
                   tx.Commit();
               }
               catch (System.Data.SqlClient.SqlException E)
               {
                   tx.Rollback();
                   throw new Exception(E.Message);
               }
               finally
               {
                   conn.Close();
               }
           }
       }

       /// <summary>
       ///安亭 执行多条SQL语句，实现数据库事务。
       /// </summary>
       /// <param name="SQLStringList">多条SQL语句</param>	
       [Shareable]
       public static void ExecuteSqlTran1(ArrayList SQLStringList, List<SYS_ExternalDeviceParam> ed)
       {
           //using (SqlConnection conn = new SqlConnection(ConnectionString))
           //{
           //    conn.Open();
           //    SqlCommand cmd = new SqlCommand();
           //    cmd.Connection = conn;
           //    SqlTransaction tx = conn.BeginTransaction();
           //    cmd.Transaction = tx;
           //    try
           //    {
           //        for (int n = 0; n < SQLStringList.Count; n++)
           //        {
           //            string strsql = SQLStringList[n].ToString();
           //            if (strsql.Trim().Length > 1)
           //            {
           //                cmd.CommandText = strsql;
           //                cmd.ExecuteNonQuery();
           //            }
           //        }
           //        tx.Commit();
           //    }
           //    catch (System.Data.SqlClient.SqlException E)
           //    {
           //        tx.Rollback();
           //        throw new Exception(E.Message);
           //    }
           //    finally
           //    {
           //        conn.Close();
           //    }
           //}
           try
           {
               
               //string result = "";
               string connectionString = ed.FirstOrDefault(p => p.ParamName == "ConnString").ParamValue;
               string providerName = ed.FirstOrDefault(p => p.ParamName == "ProviderName").ParamValue;
               EquipService.EquipServiceClient client = new EquipService.EquipServiceClient();

               bool rtn = client.ExecuteNonQueryTrans(connectionString, providerName, SQLStringList.ToStringArray());
               client.Close();
             
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       //public static SqlConnection getConnection()
       //{
       //    return new SqlConnection(connectionString);
       //}
       #endregion
      
    }
}
