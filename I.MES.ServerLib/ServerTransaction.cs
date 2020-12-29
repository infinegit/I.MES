/*************************************************************************************
 * 当前方法为特殊方法，非架构人员不得变更
 * ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using I.MES.Library.EF;

namespace I.MES.Library
{
    /// <summary>
    /// 服务器事务处理
    /// </summary>
    [Shareable]
    public class ServerTransaction : BaseOP
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="clientInfo"></param>
        public ServerTransaction(ClientInformation clientInfo) : base(clientInfo)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <param name="DBSource"></param>
        public ServerTransaction(ClientInformation clientInfo, DataEntities DBSource)
            : base(clientInfo, DBSource)
        {
        }
        /// <summary>
        /// 获取数据结构
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>数据表结构</returns>
        [Shareable]
        public List<V_SYS_TABLE_STRUCT> GetTableStruct(string tableName)
        {
            //using (IMESEntities db = new IMESEntities())
            //{
            //    return db.V_SYS_TABLE_STRUCT.Where(p => p.TableName == tableName).ToList();
            //}
            string sqlTable = string.Format("select * from V_SYS_TABLE_STRUCT where TableName='{0}'", tableName);
            return DB.Database.SqlQuery<V_SYS_TABLE_STRUCT>(sqlTable).ToList();
            //return DB.V_SYS_TABLE_STRUCT.Where(p => p.TableName == tableName).ToList();
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity">数据</param>
        /// <returns>数据库执行命令</returns>
        [Shareable]
        public DBCommand Insert(object entity)
        {
            Type type = entity.GetType();

            string tableName = type.Name;

            ServerTransaction st = new ServerTransaction(ClientInfo);
            List<V_SYS_TABLE_STRUCT> cols = GetTableStruct(tableName);

            if (cols.Count == 0)
            {
                throw new Exception("数据库没有相应的表");
            }
            else
            {
                string schema = cols.First().SchemaName;
                string rtn = "Insert Into [" + schema + "].[" + tableName + "]";
                string colNames = "";
                string colPrams = "";
                DBCommand cmd = new DBCommand();
                List<string> tbcols = new List<string>();
                foreach (var col in cols)
                {
                    if (tbcols.Contains(col.ColName))
                    {
                        continue;
                    }
                    tbcols.Add(col.ColName);
                    if (col.IsIdentity == 0)
                    {
                        var prop = type.GetProperty(col.ColName);

                        var p = new DBParamter();
                        p.Name = "@" + col.ColName;
                        if (prop == null)
                        {
                            if (string.IsNullOrEmpty(col.defaultVaule))
                            {

                                colNames += ",[" + col.ColName + "]";
                                colPrams += ",@" + col.ColName;
                                p.IsNull = true;
                            }
                            else if (col.defaultVaule == "('')")
                            {
                                colNames += ",[" + col.ColName + "]";
                                colPrams += ",@" + col.ColName;
                                p.Value = string.Empty;
                            }
                            else if (col.defaultVaule == "((0))")
                            {
                                colNames += ",[" + col.ColName + "]";
                                colPrams += ",@" + col.ColName;
                                p.Value = "0";
                            }
                            else
                            {
                                colNames += ",[" + col.ColName + "]";
                                colPrams += ",@" + col.ColName;
                                p.IsNull = true;
                            }

                        }
                        else
                        {

                            colNames += ",[" + col.ColName + "]";
                            colPrams += ",@" + col.ColName;

                            var vl = prop.GetValue(entity);

                            //p.Name = "@" + col.ColName;

                            if (vl == null)
                            {
                                p.IsNull = true;
                            }
                            else
                            {
                                p.Value = vl.ToString();
                                if (vl is DateTime)
                                {
                                    p.Value = ((DateTime)vl).ToString("yyyy-MM-dd HH:mm:ss.fff");
                                }
                                if (vl is byte[])
                                {
                                    p.ByteValue = (byte[])vl;
                                }
                                p.ValueType = vl.GetType().AssemblyQualifiedName;
                            }
                        }

                        cmd.Paramters.Add(p);

                    }
                }

                if (colNames != "")
                {
                    rtn += "(" + colNames.Substring(1) + ") values(" + colPrams.Substring(1) + ")";
                }
                else
                {
                    rtn += " values()";
                }

                cmd.Sql = rtn;
                return cmd;
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity">数据</param>
        /// <returns>数据库执行命令</returns>
        [Shareable]
        public DBCommand Update(object entity)
        {
            Type type = entity.GetType();

            string tableName = type.Name;

            ServerTransaction st = new ServerTransaction(ClientInfo);
            List<V_SYS_TABLE_STRUCT> cols = GetTableStruct(tableName);

            if (cols.Count == 0)
            {
                throw new Exception("数据库没有相应的表");
            }
            else
            {
                string schema = cols.First().SchemaName;
                string rtn = "UPDATE [" + schema + "].[" + tableName + "] SET ";
                string colNames = "";
                string colWhere = "1=1 ";
                DBCommand cmd = new DBCommand();

                foreach (var col in cols)
                {

                    var prop = type.GetProperty(col.ColName);


                    if (prop != null)
                    {
                        if (col.ColName == "RowVersion")
                        {
                            continue;
                        }
                        var p = new DBParamter();
                        p.Name = "@" + col.ColName;

                        var vl = prop.GetValue(entity);

                        if (!col.IsPrimary)
                        {
                            if (col.IsIdentity == 0)
                            {
                                colNames += ",[" + col.ColName + "]=@" + col.ColName;
                            }
                            else
                            {
                                colWhere += " AND [" + col.ColName + "]=@" + col.ColName;
                            }
                        }
                        else
                        {
                            colWhere += " AND [" + col.ColName + "]=@" + col.ColName;
                        }

                        if (vl == null)
                        {
                            p.IsNull = true;
                        }
                        else
                        {
                            p.Value = vl.ToString();
                            if (vl is DateTime)
                            {
                                p.Value = ((DateTime)vl).ToString("yyyy-MM-dd HH:mm:ss.fff");
                            }
                            if (vl is byte[])
                            {
                                p.ByteValue = (byte[])vl;
                            }
                            p.ValueType = vl.GetType().AssemblyQualifiedName;
                        }

                        cmd.Paramters.Add(p);
                    }
                    else
                    {
                        if (col.IsPrimary)
                        {
                            throw new Exception("给定数据的结构有问题，不存在主键【" + col.ColName + "】的属性！");
                        }
                    }
                }

                if (colNames != "")
                {
                    rtn += colNames.Substring(1) + " where " + colWhere;
                }
                else
                {
                    throw new Exception("没有需要更新的列");
                }
                if (colWhere.Trim() == "1=1") //如果更新操作没有Where条件，直接报错
                {
                    throw new Exception(tableName + "没有定义主键或自增列，无法进行更新");
                }
                cmd.Sql = rtn;

                return cmd;
            }
        }

        /// <summary>
        /// 更新数据（主键有变化）
        /// </summary>
        /// <param name="entityOld">原有数据</param>
        /// <param name="entityNew">新数据</param>
        /// <returns>数据库执行命令</returns>
        public DBCommand Update(object entityOld, object entityNew)
        {
            Type type = entityNew.GetType();

            string tableName = type.Name;

            ServerTransaction st = new ServerTransaction(ClientInfo);
            List<V_SYS_TABLE_STRUCT> cols = GetTableStruct(tableName);

            if (cols.Count == 0)
            {
                throw new Exception("数据库没有相应的表");
            }
            else
            {
                string schema = cols.First().SchemaName;
                string rtn = "UPDATE [" + schema + "].[" + tableName + "] SET ";
                string colNames = "";
                string colWhere = "1=1 ";
                DBCommand cmd = new DBCommand();

                foreach (var col in cols)
                {

                    var prop = type.GetProperty(col.ColName);

                    var p = new DBParamter();
                    if (prop != null)
                    {
                        var vl = prop.GetValue(entityNew);
                        var vo = prop.GetValue(entityOld);


                        if (col.IsIdentity == 0)
                        {
                            colNames += ",[" + col.ColName + "]=@" + col.ColName;
                        }
                        if (col.IsPrimary || col.IsIdentity == 1)
                        {
                            colWhere += " AND [" + col.ColName + "]=@OLD_" + col.ColName;
                            var po = new DBParamter();
                            if (vo == null)
                            {
                                po.IsNull = true;
                            }
                            else
                            {
                                po.Name = "@OLD_" + col.ColName;
                                po.Value = vo.ToString();
                                if (vo is DateTime)
                                {
                                    po.Value = ((DateTime)vo).ToString("yyyy-MM-dd HH:mm:ss.fff");
                                }
                                if (vo is byte[])
                                {
                                    po.ByteValue = (byte[])vo;
                                }
                                po.ValueType = vo.GetType().AssemblyQualifiedName;
                            }

                            cmd.Paramters.Add(po);
                        }

                        if (vl == null)
                        {
                            p.IsNull = true;
                        }
                        else
                        {
                            p.Name = "@" + col.ColName;
                            p.Value = vl.ToString();
                            if (vl is DateTime)
                            {
                                p.Value = ((DateTime)vl).ToString("yyyy-MM-dd HH:mm:ss.fff");
                            }

                            if (vl is byte[])
                            {
                                p.ByteValue = (byte[])vl;
                            }
                            p.ValueType = vl.GetType().AssemblyQualifiedName;
                        }
                    }
                    else
                    {
                        if (col.IsPrimary)
                        {
                            throw new Exception("给定数据的结构有问题，不存在主键【" + col.ColName + "】的属性！");
                        }
                    }

                    cmd.Paramters.Add(p);


                }

                if (colNames != "")
                {
                    rtn += colNames.Substring(1) + " where " + colWhere;
                }
                else
                {
                    throw new Exception("没有需要更新的列");
                }
                if (colWhere.Trim() == "1=1") //如果更新操作没有Where条件，直接报错
                {
                    throw new Exception(tableName + "没有定义主键或自增列，无法进行更新");
                }
                cmd.Sql = rtn;
                return cmd;
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity">数据（可以只给主键赋值）</param>
        /// <returns>数据库执行命令</returns>
        public DBCommand Delete(object entity)
        {
            Type type = entity.GetType();

            string tableName = type.Name;

            ServerTransaction st = new ServerTransaction(ClientInfo);
            List<V_SYS_TABLE_STRUCT> cols = GetTableStruct(tableName);

            if (cols.Count == 0)
            {
                throw new Exception("数据库没有相应的表[" + tableName + "]");
            }
            else
            {

                string schema = cols.First().SchemaName;
                string rtn = "DELETE [" + schema + "].[" + tableName + "] Where ";
                string colWhere = "1=1 ";
                DBCommand cmd = new DBCommand();


                var pks = cols.Where(p => p.IsPrimary || p.IsIdentity == 1);

                if (pks.Count() == 0)
                {
                    throw new Exception("数据库表[" + tableName + "]不存在主键！");
                }

                foreach (var pk in pks)
                {

                    var prop = type.GetProperty(pk.ColName);

                    var p = new DBParamter();
                    if (prop != null)
                    {
                        var vl = prop.GetValue(entity);

                        colWhere += " AND [" + pk.ColName + "]=@" + pk.ColName;

                        if (vl == null)
                        {
                            p.IsNull = true;
                        }
                        else
                        {
                            p.Name = "@" + pk.ColName;
                            p.Value = vl.ToString();
                            if (vl is DateTime)
                            {
                                p.Value = ((DateTime)vl).ToString("yyyy-MM-dd HH:mm:ss.fff");
                            }
                            if (vl is byte[])
                            {
                                p.ByteValue = (byte[])vl;
                            }
                            p.ValueType = vl.GetType().AssemblyQualifiedName;
                        }
                    }
                    else
                    {
                        throw new Exception("给定数据的结构有问题，不存在主键【" + pk.ColName + "】的属性！");
                    }

                    cmd.Paramters.Add(p);
                }

                rtn += colWhere;
                if (colWhere.Trim() == "1=1") //如果更新操作没有Where条件，直接报错
                {
                    throw new Exception(tableName + "没有定义主键或自增列，无法进行删除");
                }
                cmd.Sql = rtn;
                return cmd;

            }
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="cmds">命令人集合</param>
        /// <returns>影响的行数</returns>
        [Shareable]
        public int Commit(List<DBCommand> cmds)
        {
            using (DataEntities db = new DataEntities())
            {
                var rtn = 0;

                var conn = db.Database.Connection;

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                var trans = conn.BeginTransaction();
                try
                {
                    foreach (var cmd in cmds)
                    {
                        var sqlcmd = conn.CreateCommand();
                        sqlcmd.Transaction = trans;
                        sqlcmd.CommandText = cmd.Sql;
                        List<System.Data.Common.DbParameter> para = new List<System.Data.Common.DbParameter>();
                        foreach (var p in cmd.Paramters)
                        {
                            var newPara = sqlcmd.CreateParameter();
                            if (!p.IsNull)
                            {
                                if (p.ValueType == typeof(byte[]).AssemblyQualifiedName)
                                {
                                    newPara.Value = p.ByteValue;
                                }
                                else
                                {
                                    newPara.Value = Convert.ChangeType(p.Value, Type.GetType(p.ValueType));
                                }
                            }
                            else
                            {
                                newPara.Value = DBNull.Value;
                            }

                            newPara.ParameterName = p.Name;
                            sqlcmd.Parameters.Add(newPara);
                        }
                        rtn += sqlcmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    db.SaveChanges();
                    conn.Close();
                    return rtn;
                }
                catch (Exception ex)
                {
                    //trans.Rollback();
                    conn.Close();
                    throw new Exception(ex.Message, ex);
                }
            }
        }
    }
}
