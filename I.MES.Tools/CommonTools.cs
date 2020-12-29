using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using iTextSharp.text;
using ZXing;

namespace I.MES.Tools
{
    /// <summary>
    /// 字符串处理类
    /// </summary>
    public class StringTools
    {
        /// <summary>
        /// 取一个GUID
        /// 可带前后缀
        /// </summary>
        /// <param name="prefixCode">前缀</param>
        /// <param name="subfixCode">后缀</param>
        /// <returns>GUID</returns>
        public static string GetGUID(string prefixCode, string subfixCode)
        {
            try
            {
                if (prefixCode == null)
                {
                    prefixCode = string.Empty;
                }
                if (subfixCode == null)
                {
                    subfixCode = string.Empty;
                }
                return prefixCode + System.Guid.NewGuid().ToString() + subfixCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 生成一个新的GUID
        /// </summary>
        /// <returns>GUID</returns>
        public static string GetGUID()
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
        /// 生成随机数
        /// </summary>
        /// <param name="charLength">字串长度</param>
        /// <returns>随机字串</returns>
        public static string GenRandChar(int charLength)
        {
            string all = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,W,X,Y,Z";
            string[] allChar = all.Split(',');
            string result = "";
            Random rand = new Random();
            for (int i = 0; i < charLength; i++)
            {
                result += allChar[rand.Next(35)];
            }
            return result;
        }
        /// <summary>
        /// 判断字符串中是否包含中文
        /// </summary>
        /// <param name="str">需要判断的字符串</param>
        /// <returns>是否包含中文字符</returns>
        public static bool HasChinese(string str)
        {
            return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
        }
        /// <summary>
        /// 检查字串是否为空或NULL
        /// </summary>
        /// <param name="strObject">字符串对象</param>
        /// <returns>True:空或NULL; False:不为空</returns>
        public static bool isEmptyOrNull(string strObject)
        {
            try
            {
                if (strObject == null || strObject == string.Empty)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>

        /// 在指定的字符串列表CnStr中检索符合拼音索引字符串

        /// </summary>

        /// <param name="CnStr">汉字字符串</param>

        /// <returns>相对应的汉语拼音首字母串</returns>

        public static string GetSpellCode(string CnStr)
        {

            string strTemp = "";

            int iLen = CnStr.Length;

            int i = 0;

            for (i = 0; i <= iLen - 1; i++)
            {

                strTemp += GetCharSpellCode(CnStr.Substring(i, 1));
                break;
            }

            return strTemp;

        }
        /// <summary>

        /// 得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母

        /// </summary>

        /// <param name="CnChar">单个汉字</param>

        /// <returns>单个大写字母</returns>

        private static string GetCharSpellCode(string CnChar)
        {

            long iCnChar;

            byte[] ZW = System.Text.Encoding.Default.GetBytes(CnChar);

            //如果是字母，则直接返回首字母

            if (ZW.Length == 1)
            {

                return CutString(CnChar.ToUpper(), 1);

            }
            else
            {

                // get the array of byte from the single char

                int i1 = (short)(ZW[0]);

                int i2 = (short)(ZW[1]);

                iCnChar = i1 * 256 + i2;

            }

            // iCnChar match the constant

            if ((iCnChar >= 45217) && (iCnChar <= 45252))
            {

                return "A";

            }

            else if ((iCnChar >= 45253) && (iCnChar <= 45760))
            {

                return "B";

            }
            else if ((iCnChar >= 45761) && (iCnChar <= 46317))
            {

                return "C";

            }
            else if ((iCnChar >= 46318) && (iCnChar <= 46825))
            {

                return "D";

            }
            else if ((iCnChar >= 46826) && (iCnChar <= 47009))
            {

                return "E";

            }
            else if ((iCnChar >= 47010) && (iCnChar <= 47296))
            {

                return "F";

            }
            else if ((iCnChar >= 47297) && (iCnChar <= 47613))
            {

                return "G";

            }
            else if ((iCnChar >= 47614) && (iCnChar <= 48118))
            {

                return "H";

            }
            else if ((iCnChar >= 48119) && (iCnChar <= 49061))
            {

                return "J";

            }
            else if ((iCnChar >= 49062) && (iCnChar <= 49323))
            {

                return "K";

            }
            else if ((iCnChar >= 49324) && (iCnChar <= 49895))
            {

                return "L";

            }
            else if ((iCnChar >= 49896) && (iCnChar <= 50370))
            {

                return "M";

            }
            else if ((iCnChar >= 50371) && (iCnChar <= 50613))
            {

                return "N";

            }
            else if ((iCnChar >= 50614) && (iCnChar <= 50621))
            {

                return "O";

            }
            else if ((iCnChar >= 50622) && (iCnChar <= 50905))
            {

                return "P";

            }
            else if ((iCnChar >= 50906) && (iCnChar <= 51386))
            {

                return "Q";

            }
            else if ((iCnChar >= 51387) && (iCnChar <= 51445))
            {

                return "R";

            }
            else if ((iCnChar >= 51446) && (iCnChar <= 52217))
            {

                return "S";

            }
            else if ((iCnChar >= 52218) && (iCnChar <= 52697))
            {

                return "T";

            }
            else if ((iCnChar >= 52698) && (iCnChar <= 52979))
            {

                return "W";

            }
            else if ((iCnChar >= 52980) && (iCnChar <= 53640))
            {

                return "X";

            }
            else if ((iCnChar >= 53689) && (iCnChar <= 54480))
            {

                return "Y";

            }
            else if ((iCnChar >= 54481) && (iCnChar <= 55289))
            {

                return "Z";

            }
            else

                return ("?");

        }
        /// <summary>
        /// 截取字符长度
        /// </summary>
        /// <param name="str">被截取的字符串</param>
        /// <param name="len">所截取的长度</param>
        /// <returns>子字符串</returns>
        public static string CutString(string str, int len)
        {
            if (str == null || str.Length == 0 || len <= 0)
            {
                return string.Empty;
            }

            int l = str.Length;


            #region 计算长度
            int clen = 0;
            while (clen < len && clen < l)
            {
                //每遇到一个中文，则将目标长度减一。
                if ((int)str[clen] > 128) { len--; }
                clen++;
            }
            #endregion

            if (clen < l)
            {
                return str.Substring(0, clen) + "...";
            }
            else
            {
                return str;
            }
        }
    }
    /// <summary>
    /// 时间处理类
    /// </summary>
    public class TimeTools
    {
        /// <summary>
        /// 解析各类时间格式
        /// </summary>
        /// <param name="dt">时间字符串</param>
        /// <returns>返回所有格式的时间字符串</returns>
        public static DateTime ParseExact(string dt)
        {
            string[] DateTimeList = { "yyyyMMdd HH:mm:ss", "yyyy-MM-dd HH:mm:ss", "yyyy/M/d tt hh:mm:ss", "yyyy/MM/dd tt hh:mm:ss", "yyyy/MM/dd HH:mm:ss", "yyyy/M/d HH:mm:ss", "yyyy/M/d", "yyyy/MM/dd" };
            return DateTime.ParseExact(dt, DateTimeList, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
        }
    }
    /// <summary>
    /// 数字处理类
    /// </summary>
    public class NumberTools
    {
        /// <summary>
        /// 检查数字的连续性。
        /// 检查一串序号是否是连续的，用于排序单的跳单检查
        /// </summary>
        /// <param name="alSeqNums">需要检查的连续数据列表</param>
        /// <param name="step">数字之间的步进</param>
        /// <returns>连接返回true，不连续返回false</returns>
        public static bool CheckNumberContinuity(ArrayList alSeqNums, decimal step, out string errmsg)
        {
            try
            {
                errmsg = string.Empty;
                bool checkOk = true;
                for (int i = 0; i < alSeqNums.Count - 1; i++)
                {
                    decimal actualStep = Math.Abs(Convert.ToDecimal(alSeqNums[i]) - Convert.ToDecimal(alSeqNums[i + 1]));
                    if (actualStep != step)
                    {
                        errmsg += alSeqNums[i] + "与" + alSeqNums[i + 1] + "序号跳号";
                        checkOk = false;
                        continue;
                    }
                }
                return checkOk;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    /// <summary>
    /// 压缩档处理类
    /// </summary>
    public class ZipTools
    {
        /// <summary>
        /// 解压缩一个 zip 文件。
        /// </summary>
        /// <param name="zipFileName">要解压的 zip 文件</param>
        /// <param name="extractLocation">zip 文件的解压目录(当前目录extractLocatio"")</param>
        /// <param name="password">zip 文件的密码（没有密码password=""）</param>
        /// <param name="overWrite">是否覆盖已存在的文件。</param>
        public static void UnZip(string zipFileName, string extractLocation, string password, bool overWrite)
        {

            string myExtractLocation = extractLocation;
            if (myExtractLocation == "")
                myExtractLocation = Directory.GetCurrentDirectory();
            if (!myExtractLocation.EndsWith(@"/"))
                myExtractLocation = myExtractLocation + @"/";
            ZipInputStream s = new ZipInputStream(File.OpenRead(zipFileName));
            s.Password = password;
            ZipEntry theEntry;

            while ((theEntry = s.GetNextEntry()) != null)//判断下一个zip 接口是否未空
            {
                string directoryName = "";
                string pathToZip = "";
                pathToZip = theEntry.Name;

                if (pathToZip != "")
                    directoryName = Path.GetDirectoryName(pathToZip) + @"/";
                string fileName = Path.GetFileName(pathToZip);
                Directory.CreateDirectory(myExtractLocation + directoryName);
                if (fileName != "")
                {
                    try
                    {
                        if ((File.Exists(myExtractLocation + directoryName + fileName) && overWrite) || (!File.Exists(myExtractLocation + directoryName + fileName)))
                        {
                            FileStream streamWriter = File.Create(myExtractLocation + directoryName + fileName);
                            int size = 2048;
                            byte[] data = new byte[2048];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                    streamWriter.Write(data, 0, size);
                                else
                                    break;
                            }
                            streamWriter.Close();
                        }
                    }
                    catch (ZipException ex)
                    {
                        FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "log.txt", FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs);
                        sw.WriteLine(ex.Message);
                    }
                }
            }
            s.Close();
        }
    }
    /// <summary>
    /// 打印机处理类
    /// </summary>
    public class PrinterTools
    {
        /// <summary>
        /// 获取打印机
        /// </summary>
        /// <returns>已安装的打印机列表</returns>
        public static List<string> GetInstalledPrinters()
        {
            List<string> Prints = new List<string>();
            foreach (string print in PrinterSettings.InstalledPrinters)
            {
                Prints.Add(print);
            }
            return Prints;
        }
    }
    /// <summary>
    /// INI配置文件处理类
    /// </summary>
    public class IniFileTools
    {
        private string fileName;
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileInt(
           string lpAppName,
           string lpKeyName,
           int nDefault,
           string lpFileName
           );
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(
           string lpAppName,
           string lpKeyName,
           string lpDefault,
           StringBuilder lpReturnedString,
           int nSize,
           string lpFileName
           );
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(
           string lpAppName,
           string lpKeyName,
           string lpString,
           string lpFileName
           );

        /// <summary>
        /// 初始化文件名
        /// </summary>
        /// <param name="filename">文件名</param>
        public IniFileTools(string filename)
        {
            fileName = filename;
        }
        /// <summary>
        /// 获取数值
        /// </summary>
        public int GetInt(string section, string key, int def)
        {
            return GetPrivateProfileInt(section, key, def, fileName);
        }
        /// <summary>
        /// 获取字符串
        /// </summary>
        public string GetString(string section, string key, string def)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, temp, 1024, fileName);
            return temp.ToString();
        }
        /// <summary>
        /// 填写数值
        /// </summary>
        public void WriteInt(string section, string key, int iVal)
        {
            WritePrivateProfileString(section, key, iVal.ToString(), fileName);
        }
        /// <summary>
        /// 填写字符串
        /// </summary>
        public void WriteString(string section, string key, string strVal)
        {
            WritePrivateProfileString(section, key, strVal, fileName);
        }
        /// <summary>
        /// 删除键
        /// </summary>
        public void DelKey(string section, string key)
        {
            WritePrivateProfileString(section, key, null, fileName);
        }
        /// <summary>
        /// 删除选项
        /// </summary>
        public void DelSection(string section)
        {
            WritePrivateProfileString(section, null, null, fileName);
        }
    }
    /// <summary>
    /// 条形码处理类
    /// </summary>
    public class BarcodeTools
    {
        /// <summary>
        /// 生成条形码(CODE128码)
        /// </summary>
        /// <param name="code">条码码编码</param>
        /// <returns>图像</returns>
        public static System.Drawing.Image CreateBarcodeImage(string code)
        {
            try
            {
                MultiFormatWriter mutiWriter = new MultiFormatWriter();
                ZXing.Common.BitMatrix bm = mutiWriter.encode(code, BarcodeFormat.CODE_128, 150, 60);
                Bitmap bitmapImage = new BarcodeWriter().Write(bm);
                return bitmapImage;

                //System.Drawing.Image image = bitmapImage;

                //BarcodeWriter barcodeWriter = new BarcodeWriter();
                //barcodeWriter.Format = BarcodeFormat.CODE_128;
                //barcodeWriter.Options.Width = width;
                //barcodeWriter.Options.Height = height;
                //Bitmap bitmap = barcodeWriter.Write(code);
                //MultiFormatWriter writer = new MultiFormatWriter();
                //ZXing.Common.BitMatrix bitMatrix = writer.encode(code, BarcodeFormat.CODE_128, 150, 60);
                //ZXing.Rendering.BitmapRenderer render = new BitmapRenderer();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //private iTextSharp.text.Image CreateImage(string code, string partname, string textonbar)
        //{
        //    int fontleft = 15;
        //    string fontname = "Arial";
        //    float fontsize = 8;
        //    //string barindet_textonbar = "I";
        //    int upper = 10;
        //    int barcodeheight = 50;

        //    System.Drawing.Font barTextFont = new System.Drawing.Font(fontname, fontsize);

        //    System.Drawing.Image barImage = BarcodeLib.Barcode.DoEncode(BarcodeLib.TYPE.CODE128, code, false, 198, 50);
        //    Bitmap image = new Bitmap(198, 99);

        //    Graphics g = Graphics.FromImage(image);
        //    g.DrawImageUnscaled(barImage, 0, upper);


        //    g.DrawString(code + " 合格证", barTextFont, Brushes.Black, fontleft, upper + barcodeheight);
        //    g.DrawString(partname + " " + DateTime.Now.ToString("MM-dd HH:mm"), barTextFont, Brushes.Black, fontleft, upper + barcodeheight + (fontsize + 3));
        //    g.DrawString(textonbar, barTextFont, Brushes.Black, fontleft, upper + barcodeheight + (fontsize + 3) * 2);
        //    //iTextSharp.text.Image.GetInstance(barImage,BaseColor.WHITE).ScaleToFit(148,71);
        //    var rtn = iTextSharp.text.Image.GetInstance(image, BaseColor.WHITE);
        //    rtn.ScaleToFit(142, 71);
        //    return rtn;

        //}
        /// <summary>
        /// Converts an input string to the equivilant string, that need to be produced using the 'Code 128' font.
        /// </summary>
        /// <param name="value">String to be encoded</param>
        /// <returns>Encoded string start/stop and checksum characters included</returns>
        public static string StringTo128Barcode(string value)
        {
            // Parameters : a string
            // Return     : a string which give the bar code when it is dispayed with CODE128.TTF font
            // 			 : an empty string if the supplied parameter is no good
            int charPos, minCharPos;
            int currentChar, checksum;
            bool isTableB = true, isValid = true;
            string returnValue = string.Empty;

            if (value.Length > 0)
            {

                // Check for valid characters
                for (int charCount = 0; charCount < value.Length; charCount++)
                {
                    //currentChar = char.GetNumericValue(value, charPos);
                    currentChar = (int)char.Parse(value.Substring(charCount, 1));
                    if (!(currentChar >= 32 && currentChar <= 126))
                    {
                        isValid = false;
                        break;
                    }
                }

                // Barcode is full of ascii characters, we can now process it
                if (isValid)
                {
                    charPos = 0;
                    while (charPos < value.Length)
                    {
                        if (isTableB)
                        {
                            // See if interesting to switch to table C
                            // yes for 4 digits at start or end, else if 6 digits
                            if (charPos == 0 || charPos + 4 == value.Length)
                                minCharPos = 4;
                            else
                                minCharPos = 6;


                            minCharPos = BarcodeTools.IsNumber(value, charPos, minCharPos);

                            if (minCharPos < 0)
                            {
                                // Choice table C
                                if (charPos == 0)
                                {
                                    // Starting with table C
                                    returnValue = ((char)205).ToString(); // char.ConvertFromUtf32(205);
                                }
                                else
                                {
                                    // Switch to table C
                                    returnValue = returnValue + ((char)199).ToString();
                                }
                                isTableB = false;
                            }
                            else
                            {
                                if (charPos == 0)
                                {
                                    // Starting with table B
                                    returnValue = ((char)204).ToString(); // char.ConvertFromUtf32(204);
                                }

                            }
                        }

                        if (!isTableB)
                        {
                            // We are on table C, try to process 2 digits
                            minCharPos = 2;
                            minCharPos = BarcodeTools.IsNumber(value, charPos, minCharPos);
                            if (minCharPos < 0) // OK for 2 digits, process it
                            {
                                currentChar = int.Parse(value.Substring(charPos, 2));
                                currentChar = currentChar < 95 ? currentChar + 32 : currentChar + 100;
                                returnValue = returnValue + ((char)currentChar).ToString();
                                charPos += 2;
                            }
                            else
                            {
                                // We haven't 2 digits, switch to table B
                                returnValue = returnValue + ((char)200).ToString();
                                isTableB = true;
                            }
                        }
                        if (isTableB)
                        {
                            // Process 1 digit with table B
                            returnValue = returnValue + value.Substring(charPos, 1);
                            charPos++;
                        }
                    }

                    // Calculation of the checksum
                    checksum = 0;
                    for (int loop = 0; loop < returnValue.Length; loop++)
                    {
                        currentChar = (int)char.Parse(returnValue.Substring(loop, 1));
                        currentChar = currentChar < 127 ? currentChar - 32 : currentChar - 100;
                        if (loop == 0)
                            checksum = currentChar;
                        else
                            checksum = (checksum + (loop * currentChar)) % 103;
                    }

                    // Calculation of the checksum ASCII code
                    checksum = checksum < 95 ? checksum + 32 : checksum + 100;
                    // Add the checksum and the STOP
                    returnValue = returnValue +
                        ((char)checksum).ToString() +
                        ((char)206).ToString();
                }
            }

            return returnValue;
        }
        private static int IsNumber(string InputValue, int CharPos, int MinCharPos)
        {
            // if the MinCharPos characters from CharPos are numeric, then MinCharPos = -1
            MinCharPos--;
            if (CharPos + MinCharPos < InputValue.Length)
            {
                while (MinCharPos >= 0)
                {
                    if ((int)char.Parse(InputValue.Substring(CharPos + MinCharPos, 1)) < 48
                        || (int)char.Parse(InputValue.Substring(CharPos + MinCharPos, 1)) > 57)
                    {
                        break;
                    }
                    MinCharPos--;
                }
            }
            return MinCharPos;
        }
    }
    /// <summary>
    /// 图像处理类
    /// </summary>
    public class ImageTools
    {
        /// <summary> 
        /// 生成缩略图 静态方法 等比例缩放
        /// </summary>
        /// <param name="pathImageFrom"> 源图的路径(含文件名及扩展名) </param> 
        /// <param name="width"> 欲生成的缩略图 "画布" 的宽度(像素值) </param>
        /// <returns>图像</returns>
        public static System.Drawing.Image GenThumbnail(System.Drawing.Image origImage, int width)
        {
            if (origImage == null)
            {
                return null;
            }

            if (origImage.Width < width)
            {
                return origImage;
            }
            // 源图宽度及高度 
            int imageFromWidth = (int)origImage.Width;
            int imageFromHeight = (int)origImage.Height;
            // 生成的缩略图实际宽度及高度 
            int bitmapWidth = width;
            int bitmapHeight = 0;
            // 生成的缩略图在上述"画布"上的位置 
            int X = 0;
            int Y = 0;
            // 根据源图及欲生成的缩略图尺寸,计算缩略图的实际高度 
            bitmapHeight = imageFromHeight * width / imageFromWidth;
            // 创建画布 
            Bitmap newBitmap = new Bitmap(bitmapWidth, bitmapHeight);
            Graphics g = Graphics.FromImage(newBitmap);
            // 用白色清空 
            g.Clear(Color.White);
            // 指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。 
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // 指定高质量、低速度呈现。 
            g.SmoothingMode = SmoothingMode.HighQuality;
            // 在指定位置并且按指定大小绘制指定的 Image 的指定部分。 
            g.DrawImage(origImage, new System.Drawing.Rectangle(X, Y, bitmapWidth, bitmapHeight), new System.Drawing.Rectangle(0, 0, imageFromWidth, imageFromHeight), GraphicsUnit.Pixel);
            return newBitmap;
            //try
            //{

            //    //经测试 .jpg 格式缩略图大小与质量等最优 
            //    //bmp.Save(pathImageTo, ImageFormat.Jpeg);
            //}
            //catch
            //{
            //    return null;
            //}
            //显示释放资源 
            //origImage.Dispose();

            //g.Dispose();
        }
    }
    /// <summary>
    /// 数据库处理类
    /// </summary>
    public class DBTools
    {
        /// <summary>
        /// 使用with(nolock)调用数据库查询
        /// </summary>
        /// <param name="action">Action</param>
        public static void NoLockInvokeDB(Action action)
        {
            var transactionOptions = new System.Transactions.TransactionOptions();
            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
            using (var transactionScope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, transactionOptions))
            {
                try
                {
                    action();
                }
                finally
                {
                    transactionScope.Complete();
                }
            }
        }
        /// <summary>
        /// 使用with(readpast)调用数据库查询
        /// </summary>
        /// <param name="action">Action</param>
        public static void ReadPastInvokeDB(Action action)
        {
            var transactionOptions = new System.Transactions.TransactionOptions();
            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            using (var transactionScope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, transactionOptions))
            {
                try
                {
                    action();
                }
                finally
                {
                    transactionScope.Complete();
                }
            }
        }
        
    }
}
