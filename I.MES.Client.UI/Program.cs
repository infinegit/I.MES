using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using I.MES.Models;


namespace I.MES.Client.UI
{
    static class Program
    {
        public static SYS_User currentUser = null;
        public static SYS_Factory currentFactory = null;
        public static List<SYS_ProgPriv> currentPrivilegeList = new List<SYS_ProgPriv>();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitializeAsposeCells();
            InitialBasicInfo();

            ListenServer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());


        }

        static string GetLocalIp()
        {

            //获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }

            return AddressIP;
        }

        static void InitialBasicInfo()
        {
            BasicProperty.ClientInfo = new ClientInformation()
            {
                CurrentSysUser = Environment.UserName,
                System = Environment.OSVersion.ToString(),
                Machine = Environment.MachineName,
                LogID = BasicProperty.Log.LogID,
                IP = GetLocalIp(),
                TransferMethod = TransferType.Json
            };

        }

        static void ListenServer()
        {
            Thread td = new Thread(GetServer);
            td.IsBackground = true;
            td.Start();
        }

        static void GetServer()
        {
            var server = new I.MES.Library.ServerInfo();
            while (true)
            {
                DateTime dtNow = DateTime.Now;
                try
                {
                    DateTime dtServer = server.GetCurrent();
                    string m = server.GetMachine();
                    BasicProperty.ServerInfo.CurrentTime = dtServer;
                    BasicProperty.ServerInfo.Machine = m;
                    BasicProperty.ServerInfo.Delay = (int)((DateTime.Now - dtNow).TotalMilliseconds);
                }
                catch (Exception ex)
                {
                    Logger.CurrentLog.Error(ex);
                    BasicProperty.ServerInfo.Delay = 10000;
                }
                finally
                {
                    Thread.Sleep(1000);
                }
            }
        }

        public delegate void Action<FieldInfo, Type, String, Object, Integer>(FieldInfo field, Type chkType, string chkName, object obj, object value);
        /// <summary>
        /// 注册Aspose控件
        /// </summary>
        internal static void InitializeAsposeCells()
        {
            const BindingFlags BINDING_FLAGS_ALL = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;

            const string CLASS_LICENSER = "\u0092\u0092\u0008.\u001C";
            const string CLASS_LICENSERHELPER = "\u0011\u0001\u0006.\u001A";
            const string ENUM_ISTRIAL = "\u0092\u0092\u0008.\u001B";

            const string FIELD_LICENSER_CREATED_LICENSE = "\u0001";     // static
            const string FIELD_LICENSER_EXPIRY_DATE = "\u0002";         // instance
            const string FIELD_LICENSER_ISTRIAL = "\u0001";             // instance

            const string FIELD_LICENSERHELPER_INT128 = "\u0001";        // static
            const string FIELD_LICENSERHELPER_BOOLFALSE = "\u0001";     // static

            const int CONST_LICENSER_ISTRIAL = 1;
            const int CONST_LICENSERHELPER_INT128 = 128;
            const bool CONST_LICENSERHELPER_BOOLFALSE = false;

            //- Field setter for convinient
            Action<FieldInfo, Type, string, object, object> setValue =
                delegate (FieldInfo field, Type chkType, string chkName, object obj, object value)
                {
                    if ((field.FieldType == chkType) && (field.Name == chkName))
                    {
                        field.SetValue(obj, value);
                    }
                };


            //- Get types
            Assembly assembly = Assembly.GetAssembly(typeof(Aspose.Cells.License));
            Type typeLic = null, typeIsTrial = null, typeHelper = null;
            foreach (Type type in assembly.GetTypes())
            {
                if ((typeLic == null) && (type.FullName == CLASS_LICENSER))
                {
                    typeLic = type;
                }
                else if ((typeIsTrial == null) && (type.FullName == ENUM_ISTRIAL))
                {
                    typeIsTrial = type;
                }
                else if ((typeHelper == null) && (type.FullName == CLASS_LICENSERHELPER))
                {
                    typeHelper = type;
                }
            }
            if (typeLic == null || typeIsTrial == null || typeHelper == null)
            {
                throw new Exception();
            }

            //- In class_Licenser
            object license = Activator.CreateInstance(typeLic);
            foreach (FieldInfo field in typeLic.GetFields(BINDING_FLAGS_ALL))
            {
                setValue(field, typeLic, FIELD_LICENSER_CREATED_LICENSE, null, license);
                setValue(field, typeof(DateTime), FIELD_LICENSER_EXPIRY_DATE, license, DateTime.MaxValue);
                setValue(field, typeIsTrial, FIELD_LICENSER_ISTRIAL, license, CONST_LICENSER_ISTRIAL);
            }

            //- In class_LicenserHelper
            foreach (FieldInfo field in typeHelper.GetFields(BINDING_FLAGS_ALL))
            {
                setValue(field, typeof(int), FIELD_LICENSERHELPER_INT128, null, CONST_LICENSERHELPER_INT128);
                setValue(field, typeof(bool), FIELD_LICENSERHELPER_BOOLFALSE, null, CONST_LICENSERHELPER_BOOLFALSE);

            }
        }

    }
}
