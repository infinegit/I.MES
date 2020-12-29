using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I.MES.Tools
{
    public interface IDBHelper
    {
        /// <summary>
        /// 执行 Transact-SQL 语句并返回受影响的行数。
        /// </summary>
        int ExecuteNonQuery(string connectionString, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] cmdParms);

        /// <summary>
        /// 在事务中执行 Transact-SQL 语句并返回受影响的行数。
        /// </summary>
        int ExecuteNonQuery(System.Data.Common.DbTransaction trans, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] cmdParms);

        /// <summary>
        /// 在事务中执行查询，返回DataSet
        /// </summary>
        DataSet ExecuteQuery(System.Data.Common.DbTransaction trans, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] cmdParms);

        /// <summary>
        /// 执行查询，返回DataSet
        /// </summary>
        DataSet ExecuteQuery(string connectionString, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] cmdParms);

        /// <summary>
        /// 在事务中执行查询，返回DataReader
        /// </summary>
        DbDataReader ExecuteReader(System.Data.Common.DbTransaction trans, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] cmdParms);

        /// <summary>
        /// 执行查询，返回DataReader
        /// </summary>
        DbDataReader ExecuteReader(string connectionString, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] cmdParms);

        /// <summary>
        /// 在事务中执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        object ExecuteScalar(System.Data.Common.DbTransaction trans, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] cmdParms);

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        object ExecuteScalar(string connectionString, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] cmdParms);

        /// <summary>
        /// 得到数据条数
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="condition">条件(不需要where)</param>
        /// <returns>数据条数</returns>
        int GetCount(string connectionString, string tblName, string condition);
    }

}
