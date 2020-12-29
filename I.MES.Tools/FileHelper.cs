using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace I.MES.Tools
{
    public class FileHelper
    {
        /// <summary>
        /// 移动文件到共享盘符
        /// </summary>
        /// <param name="fileName">拷贝到文件名称</param>
        /// <param name="sourcesourceFilePathName">拷贝的原文件目录</param>
        /// <param name="SharePath">需要共享的目录</param>
        /// <param name="NetUserName">反问共享的用户名</param>
        /// <param name="NetPassWord">反问共享的用户名密码</param>
        /// <param name="isMappingDisk">是否映射盘符</param>
        /// <returns></returns>
        public static bool MoveShareFiles(string fileName, string sourceFilePathName, string SharePath, string NetUserName, string NetPassWord, bool isMappingDisk)
        {
            try
            {
                string sourceFilePath = "";
                int status;
                if (isMappingDisk)
                {
                    sourceFilePath = "X:";
                    status = NetworkConnection.ConnectMapping(SharePath, sourceFilePath, NetUserName, NetPassWord);
                    if (status == (int)ERROR_ID.ERROR_SUCCESS)
                    {
                        File.Copy(sourceFilePathName, sourceFilePath + @"\" + fileName, true);
                        return true;
                    }
                }
                else
                {
                    status = NetworkConnection.Connect(SharePath, sourceFilePath, NetUserName, NetPassWord);
                    if (status == (int)ERROR_ID.ERROR_SUCCESS)
                    {
                        File.Copy(sourceFilePathName, SharePath + @"\" + fileName, true);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
