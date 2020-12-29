using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Library
{
    public class Transaction
    {
        private List<DBCommand> cmds;
        public List<DBCommand> Cmds
        {
            get { return cmds; }
        }
        public Transaction()
        {
            cmds = new List<DBCommand>();
        }

        public void Add(string sql, params System.Data.IDataParameter[] parameters)
        {
            DBCommand cmd = new DBCommand(sql, parameters);
            cmds.Add(cmd);
        }

        public void Add(DBCommand command)
        {
            cmds.Add(command);
        }
        public void AddRange(List<DBCommand> command)
        {
            cmds.AddRange(command);
        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity">数据</param>
        public void Insert(object entity)
        {
            Type type = entity.GetType();

            string tableName = type.Name;
            ServerTransaction st = new ServerTransaction();
            List<Models.V_SYS_TABLE_STRUCT> cols = st.GetTableStruct(tableName);

            if (cols.Count == 0)
            {
                throw new Exception("数据库没有相应的表[" + tableName + "]");
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
                        }
                        else
                        {

                            colNames += ",[" + col.ColName + "]";
                            colPrams += ",@" + col.ColName;

                            var vl = prop.GetValue(entity, null);

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

                cmds.Add(cmd);
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity">数据</param>
        public void Update(object entity)
        {
            Type type = entity.GetType();

            string tableName = type.Name;

            ServerTransaction st = new ServerTransaction();
            List<Models.V_SYS_TABLE_STRUCT> cols = st.GetTableStruct(tableName);

            if (cols.Count == 0)
            {
                throw new Exception("数据库没有相应的表[" + tableName + "]");
            }
            else
            {


                var pks = cols.Where(p => p.IsPrimary);

                if (pks.Count() == 0)
                {
                    throw new Exception("数据库表[" + tableName + "]不存在主键！");
                }

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
                        var p = new DBParamter();
                        p.Name = "@" + col.ColName;
                        var vl = prop.GetValue(entity, null);

                        if (!col.IsPrimary)
                        {
                            if (col.IsIdentity == 0)
                            {
                                colNames += ",[" + col.ColName + "]=@" + col.ColName;
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
                    return;
                }

                cmd.Sql = rtn;

                cmds.Add(cmd);
            }
        }

        /// <summary>
        /// 更新数据（主键有变化）
        /// </summary>
        /// <param name="entityOld">原数据</param>
        /// <param name="entityNew">新数据</param>
        public void Update(object entityOld, object entityNew)
        {
            Type type = entityNew.GetType();

            string tableName = type.Name;

            ServerTransaction st = new ServerTransaction();
            List<Models.V_SYS_TABLE_STRUCT> cols = st.GetTableStruct(tableName);

            if (cols.Count == 0)
            {
                throw new Exception("数据库没有相应的表[" + tableName + "]");
            }
            else
            {

                var pks = cols.Where(p => p.IsPrimary);

                if (pks.Count() == 0)
                {
                    throw new Exception("数据库表[" + tableName + "]不存在主键！");
                }

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
                        var vl = prop.GetValue(entityNew, null);
                        var vo = prop.GetValue(entityOld, null);

                        var p = new DBParamter();
                        p.Name = "@" + col.ColName;

                        if (col.IsIdentity == 0)
                        {
                            colNames += ",[" + col.ColName + "]=@" + col.ColName;
                        }
                        if (col.IsPrimary)
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
                    return;
                }

                cmd.Sql = rtn;

                cmds.Add(cmd);
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity">数据实体</param>
        public void Delete(object entity)
        {
            Type type = entity.GetType();

            string tableName = type.Name;

            ServerTransaction st = new ServerTransaction();
            List<Models.V_SYS_TABLE_STRUCT> cols = st.GetTableStruct(tableName);

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


                var pks = cols.Where(p => p.IsPrimary);

                if (pks.Count() == 0)
                {
                    throw new Exception("数据库表[" + tableName + "]不存在主键！");
                }

                foreach (var pk in pks)
                {

                    var prop = type.GetProperty(pk.ColName);

                    if (prop != null)
                    {
                        var p = new DBParamter();
                        p.Name = "@" + pk.ColName;
                        var vl = prop.GetValue(entity, null);

                        colWhere += " AND [" + pk.ColName + "]=@" + pk.ColName;

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
                        throw new Exception("给定数据的结构有问题，不存在主键【" + pk.ColName + "】的属性！");
                    }

                }

                rtn += colWhere;

                cmd.Sql = rtn;

                cmds.Add(cmd);

            }
        }

        /// <summary>
        /// 提交数据
        /// </summary>
        /// <returns>影响的行数</returns>
        public int Commit()
        {
            ServerTransaction st = new ServerTransaction();
            return st.Commit(cmds);
        }

    }
}
