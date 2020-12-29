using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using I.MES.Library.EF;
using I.MES.Models;
using I.MES.Tools;
using System.ServiceModel;

//命名空间最好不要改，否则I.MES.ClientLib的T4模板会生成编绎不通过。
namespace I.MES.Library
{
    /// <summary>
    /// 报表处理类
    /// </summary>
    [Shareable]
    public class ReportOP : BaseOP
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ReportOP(ClientInformation clientInfo)
            : base(clientInfo)
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="DBSource"></param>
        public ReportOP(ClientInformation clientInfo, DataEntities DBSource)
            : base(clientInfo, DBSource)
        {
        }

        #region <<无分页的报表数据 返回List<ReportData> >>
        /// <summary>
        /// 返回报表数据
        /// </summary>
        /// <param name="ViewName">视图名称</param>
        /// <param name="deParameter">查询条件</param>
        /// <returns>List<ReportData></returns>
        [Shareable]
        public List<ReportData> GetReportData(string ViewName, DictionaryEntry[] deParameter)
        {
            ViewName = DealWithSqlValue(ViewName);
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format(@"SELECT * FROM {0}  WHERE 1=1 ", ViewName));

            IDataParameter[] Parameters = new IDataParameter[deParameter.Length];

            int intIndex = 0;
            foreach (DictionaryEntry de in deParameter)
            {
                strSql.Append(string.Format(" AND {0}=@{0} ", de.Key));

                Parameters[intIndex] = new SqlParameter(de.Key.ToString(), de.Value);
                intIndex++;
            }

            var RPTData = DB.Database.SqlQuery<ReportData>(
                strSql.ToString(), Parameters).ToList();

            return RPTData;
        }
        #endregion

        #region <<返回分页报表数据>>
        /// <summary>
        /// 返回分页报表数据
        /// </summary>
        /// <param name="ParameterList"></param>
        /// <param name="PageNumber"></param>
        /// <param name="PageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        [Shareable]
        public DataSet GetReportData(
            List<WhereCondition> ParameterList,
            int PageNumber, int PageSize, out int total)
        {
            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 500;
            string strOperator = "=";
            string strViewName = null;
            string strSortColumn = null;
            string strSortDirection = null;
            try
            {
                conn = (SqlConnection)DB.Database.Connection;

                #region <<获取视图及排序列>>
                foreach (I.MES.Models.WhereCondition where in ParameterList)
                {

                    switch (where.Key)
                    {
                        case "ViewName":
                            strViewName = where.Value;
                            break;
                        case "SortColumn":
                            strSortColumn = where.Value;
                            break;
                        case "SortDirection":
                            strSortDirection = where.Value;
                            break;
                        default:

                            break;
                    }
                }
                if (string.IsNullOrWhiteSpace(strViewName))
                {
                    throw new Exception("视图为空");
                }
                if (string.IsNullOrWhiteSpace(strSortColumn))
                {
                    throw new Exception("排序列为空");
                }
                if (string.IsNullOrWhiteSpace(strSortDirection))
                {
                    strSortDirection = "Desc";
                }
                #endregion

                strViewName = DealWithSqlValue(strViewName);
                int intBeg = (PageNumber - 1) * PageSize + 1;
                int intEnd = PageNumber * PageSize;

                StringBuilder sbSql = new StringBuilder();
                StringBuilder sbSqlCount = new StringBuilder();
                //查询记录的总条数
                sbSqlCount.Append(string.Format(@"SELECT COUNT(1) AS RowTotal FROM {0}  WHERE 1=1 ", strViewName));
                //查询当前页的记录
                if (strSortColumn.Split(',').Length > 1)
                {
                    sbSql.Append(
                        string.Format(@"SELECT ROW_NUMBER() OVER(ORDER BY {1}) AS rowIndex,* FROM {0}   WHERE 1=1 ",
                        strViewName, strSortColumn));
                }
                else
                {
                    sbSql.Append(
                        string.Format(@"SELECT ROW_NUMBER() OVER(ORDER BY {1} {2}) AS rowIndex,* FROM {0}  WHERE 1=1 ",
                        strViewName, strSortColumn, strSortDirection));
                }
                //查询条件
                #region <<查询条件>>
                foreach (I.MES.Models.WhereCondition where in ParameterList)
                {
                    if (where.Key.Equals("ViewName") ||
                        where.Key.Equals("SortColumn") ||
                        where.Key.Equals("SortDirection"))
                    {
                        continue;
                    }
                    if (where.Operator.ToLower().Equals("export"))
                    {
                        continue;
                    }
                    if (where.Key.Equals("SerialNum") && where.Operator.Equals("like") && !string.IsNullOrEmpty(where.Value))
                    {
                        sbSql.Append("and '"+where.Value + "' like  '%' +" + where.ColumnName+ "+'%'");
                        continue;
                    }
                    #region <<订单状态 特殊处理>>
                    if (where.ColumnName.ToLower().Equals("itemstatus"))
                    {
                        if (string.IsNullOrWhiteSpace(where.Value))
                        {
                            //查状态为正常 
                            sbSql.Append(" AND ItemStatus='' ");
                            sbSqlCount.Append(" AND ItemStatus='' ");
                        }
                        else if (where.Value.ToLower().Equals("all"))
                        {
                            //查所有
                            continue;
                        }
                    }
                    if (where.ColumnName.ToLower().Equals("orderstatus"))
                    {
                        if (string.IsNullOrWhiteSpace(where.Value))
                        {
                            //查状态为正常 
                            sbSql.Append(" AND OrderStatus='' ");
                            sbSqlCount.Append(" AND OrderStatus='' ");
                        }
                        else if (where.Value.ToLower().Equals("all"))
                        {
                            //查所有
                            continue;
                        }
                    }

                    #endregion
                    #region <<在途查询(是否接收完成) 特殊处理>>
                    else if (where.ColumnName.ToLower().Equals("intransit_bool"))
                    {
                        if (string.IsNullOrWhiteSpace(where.Value)
                            || where.Value.Equals("0"))
                        {
                            //查所有
                            continue;
                        }
                        else
                        {
                            sbSql.Append(" AND InTransit>0 ");
                            sbSqlCount.Append(" AND InTransit>0 ");
                            continue;
                        }

                    }
                    #endregion

                    if (!string.IsNullOrWhiteSpace(where.Value))
                    {
                        if (string.IsNullOrWhiteSpace(where.Operator))
                        {
                            strOperator = "=";
                        }
                        else
                        {
                            strOperator = where.Operator;
                        }
                        if (strOperator.ToUpper().Equals("LIKE"))
                        {
                            sbSql.Append(string.Format(" AND {0} {1}  '%'+@{2}+'%' ", where.ColumnName, strOperator, where.Key));
                            sbSqlCount.Append(string.Format(" AND {0} {1} '%'+@{2}+'%' ", where.ColumnName, strOperator, where.Key));
                        }
                        else if (strOperator.ToUpper().Equals("IN"))
                        {
                            string[] ColumnValues = where.Value.Split(',');
                            string strValue = "";
                            for (int i = 0; i < ColumnValues.Length; i++)
                            {
                                strValue += "'" + ColumnValues[i] + "',";
                            }
                            strValue = strValue.Substring(0, strValue.Length - 1);
                            sbSql.Append(string.Format(" AND {0} {1}  ({2}) ", where.ColumnName, strOperator, strValue));
                            sbSqlCount.Append(string.Format(" AND {0} {1} ({2}) ", where.ColumnName, strOperator, strValue));
                            //string[] ColumnNames = where.ColumnName.Split(',');
                            //if (ColumnNames.Length >= 4)
                            //{
                            //    sbSql.Append(string.Format(" AND exists(select 1 from {0}   where {1}={2}.{3} and {4}=@{5}) ",
                            //        ColumnNames[0], ColumnNames[1], strViewName, ColumnNames[2], ColumnNames[3], where.Key));
                            //    sbSqlCount.Append(string.Format(" AND exists(select 1 from {0}   where {1}={2}.{3} and {4}=@{5}) ",
                            //        ColumnNames[0], ColumnNames[1], strViewName, ColumnNames[2], ColumnNames[3], where.Key));
                            //}
                        }
                        else
                        {
                            if (string.IsNullOrWhiteSpace(where.OrColumnName))
                            {
                                sbSql.Append(string.Format(" AND {0} {1} @{2} ", where.ColumnName, strOperator, where.Key));
                                sbSqlCount.Append(string.Format(" AND {0} {1} @{2} ", where.ColumnName, strOperator, where.Key));
                            }
                            else
                            {
                                sbSql.Append(string.Format(" AND ({0} {1} @{2}  OR {3} {1} @{2}) ", where.ColumnName, strOperator, where.Key, where.OrColumnName));
                                sbSqlCount.Append(string.Format(" AND ({0} {1} @{2} OR {3} {1} @{2}) ", where.ColumnName, strOperator, where.Key, where.OrColumnName));
                            }
                        }

                        cmd.Parameters.Add(new SqlParameter(where.Key, where.Value));
                    }
                }
                #endregion

                //查询分页
                string strSql = string.Format(";SELECT * FROM ({0}) AS T   WHERE rowIndex BETWEEN {1} AND {2};",
                    sbSql.ToString(), intBeg, intEnd);

                cmd.Connection = conn;
                cmd.CommandText = sbSqlCount.ToString() + strSql;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                total = Convert.ToInt32(ds.Tables[0].Rows[0]["RowTotal"]);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();

            }

        }
        #endregion

        #region <<返回全部报表数据>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ViewName"></param>
        /// <param name="SortColumn"></param>
        /// <param name="deParameter"></param>
        /// <returns></returns>
        [Shareable]
        public DataSet GetAllReportData(
             List<WhereCondition> ParameterList)
        {
            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 500;
            string strOperator = "=";
            string strViewName = null;
            string strSortColumn = null;
            string strSortDirection = null;
            try
            {
                conn = (SqlConnection)DB.Database.Connection;

                List<WhereCondition> columnList = new List<WhereCondition>();
                columnList = ParameterList.Where(p => p.Operator.ToLower().Equals("export") && p.ImportColumnName != null).ToList();
                if (columnList == null || columnList.Count <= 0)
                    columnList = ParameterList.Where(p => p.Operator.ToLower().Equals("export")).ToList();
                #region <<获取视图及排序列>>
                foreach (I.MES.Models.WhereCondition where in ParameterList)
                {

                    switch (where.Key)
                    {
                        case "ViewName":
                            strViewName = where.Value;
                            break;
                        case "SortColumn":
                            strSortColumn = where.Value;
                            break;
                        case "SortDirection":
                            strSortDirection = where.Value;
                            break;
                        default:

                            break;
                    }
                }
                if (string.IsNullOrWhiteSpace(strViewName))
                {
                    throw new Exception("视图为空");
                }
                //if (string.IsNullOrWhiteSpace(strSortColumn))
                //{
                //    throw new Exception("排序列为空");
                //}
                #endregion
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append(string.Format(@"SELECT *  FROM {0}   WHERE 1=1 ", strViewName));
                //查询条件
                #region <<查询条件>>
                foreach (I.MES.Models.WhereCondition where in ParameterList)
                {
                    if (where.Key.Equals("ViewName") ||
                     where.Key.Equals("SortColumn") ||
                        where.Key.Equals("SortDirection"))
                    {
                        continue;
                    }
                    if (where.Operator.ToLower().Equals("export"))
                    {
                        continue;
                    }
                    #region <<订单状态 特殊处理>>
                    if (where.ColumnName.ToLower().Equals("itemstatus"))
                    {
                        if (string.IsNullOrWhiteSpace(where.Value))
                        {
                            //查状态为正常 
                            sbSql.Append(" AND ItemStatus='' ");

                        }
                        else if (where.Value.ToLower().Equals("all"))
                        {
                            //查所有
                            continue;
                        }

                    }
                    if (where.ColumnName.ToLower().Equals("orderstatus"))
                    {
                        if (string.IsNullOrWhiteSpace(where.Value))
                        {
                            //查状态为正常 
                            sbSql.Append(" AND OrderStatus='' ");
                        }
                        else if (where.Value.ToLower().Equals("all"))
                        {
                            //查所有
                            continue;
                        }
                    }
                    #endregion
                    #region <<在途查询(是否接收完成) 特殊处理>>
                    else if (where.ColumnName.ToLower().Equals("intransit_bool"))
                    {
                        if (string.IsNullOrWhiteSpace(where.Value)
                            || where.Value.Equals("0"))
                        {
                            //查所有
                            continue;
                        }
                        else
                        {
                            sbSql.Append(" AND InTransit>0 ");
                            continue;
                        }
                    }
                    #endregion
                    if (!string.IsNullOrWhiteSpace(where.Value))
                    {

                        if (string.IsNullOrWhiteSpace(where.Operator))
                        {
                            strOperator = "=";
                        }
                        else
                        {
                            strOperator = where.Operator;
                        }
                        if (strOperator.ToUpper().Equals("LIKE"))
                        {
                            sbSql.Append(string.Format(" AND {0} {1}  '%'+@{2}+'%' ", where.ColumnName, strOperator, where.Key));
                        }
                        else if (strOperator.ToUpper().Equals("IN"))
                        {
                            string[] ColumnValues = where.Value.Split(',');
                            string strValue = "";
                            for (int i = 0; i < ColumnValues.Length; i++)
                            {
                                strValue += "'" + ColumnValues[i] + "',";
                            }
                            strValue = strValue.Substring(0, strValue.Length - 1);
                            sbSql.Append(string.Format(" AND {0} {1}  ({2}) ", where.ColumnName, strOperator, strValue));

                            //sbSqlCount.Append(string.Format(" AND {0} {1} ({2}) ", where.ColumnName, strOperator, strValue));

                            //string[] ColumnNames = where.ColumnName.Split(',');
                            //if (ColumnNames.Length >= 4)
                            //{
                            //    sbSql.Append(string.Format(" AND exists(select 1 from {0}  where {1}={2}.{3} and {4}=@{5}) ",
                            //        ColumnNames[0], ColumnNames[1], strViewName, ColumnNames[2], ColumnNames[3], where.Key));
                            //}
                        }
                        else
                        {
                            if (string.IsNullOrWhiteSpace(where.OrColumnName))
                            {
                                sbSql.Append(string.Format(" AND {0} {1} @{2} ", where.ColumnName, strOperator, where.Key));
                            }
                            else
                            {
                                sbSql.Append(string.Format(" AND ({0} {1} @{2}  OR {3} {1} @{2}) ", where.ColumnName, strOperator, where.Key, where.OrColumnName));
                            }


                        }

                        cmd.Parameters.Add(new SqlParameter(where.Key, where.Value));
                    }
                }
                #endregion
                //排序
                if (!string.IsNullOrWhiteSpace(strSortColumn))
                {
                    if (string.IsNullOrWhiteSpace(strSortDirection))
                    {
                        strSortDirection = "Desc";
                    }

                    if (strSortColumn.Split(',').Length > 1)
                    {
                        sbSql.Append(string.Format(" ORDER BY {0} ", strSortColumn, strSortDirection));
                    }
                    else
                    {
                        sbSql.Append(string.Format(" ORDER BY {0} {1} ", strSortColumn, strSortDirection));
                    }


                }
                cmd.Connection = conn;
                cmd.CommandText = sbSql.ToString();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                #region <<修改列名>>
                if (columnList != null && columnList.Count >= 1)
                {
                    DataColumn[] dcList = new DataColumn[ds.Tables[0].Columns.Count];
                    ds.Tables[0].Columns.CopyTo(dcList, 0);
                    bool bExist = false;
                    foreach (DataColumn dc in dcList)
                    {
                        bExist = false;
                        foreach (var colItem in columnList)
                        {
                            if (dc.ColumnName.ToString() == colItem.ColumnName)
                            {
                                if (!string.IsNullOrEmpty(colItem.Value))
                                    ds.Tables[0].Columns[dc.ColumnName].ColumnName = colItem.Value;
                                bExist = true;
                            }
                        }
                        if (!bExist)
                        {
                            ds.Tables[0].Columns.Remove(dc.ColumnName);
                        }
                    }
                }

                #endregion

                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }
        /// <summary>
        /// 根据查询条件查询数据集
        /// </summary>
        /// <param name="talbelName">表名</param>
        /// <param name="strWhere"></param> 
        /// <param name="Fileds">显示字段名</param>
        /// <returns></returns>
        [Shareable]
        public DataSet GetReportData(string talbelName, string strWhere, List<KeyValueModel> Fileds)
        {
            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 500;
            try
            {
                conn = (SqlConnection)DB.Database.Connection;

                StringBuilder sbSql = new StringBuilder();
                string Filed = string.Empty;
                foreach (var item in Fileds)
                {
                    Filed = Filed + item.Value + " as '" + item.Key + "',";
                }
                string showFiled = Filed.Substring(0, Filed.Length - 1);
                sbSql.Append(string.Format(@"SELECT {0} FROM {1}   WHERE 1=1 " + strWhere, showFiled, talbelName));
                cmd.Connection = conn;
                cmd.CommandText = sbSql.ToString();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }
        /// <summary>
        /// 获取发运报表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="intPage"></param>
        /// <param name="PAGE_SIZE"></param>
        /// <param name="intRowTotal"></param>
        /// <returns></returns>
        [Shareable]
        public DataSet GetShipmentList(string strWhere)
        {
            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 500;
            try
            {
                conn = (SqlConnection)DB.Database.Connection;

                StringBuilder sbSql = new StringBuilder();
                string sql = @"SELECT  MovementType as 移动类型 ,
                                    dbo.SYS_SAPTransaction.PartNo as 物料号,
                                    StockAdress as 出发库位,
                                    MAX(PartDesc) as 物料描述,
                                    SUM(Qty)  as 数量,
                                    CustomerCode as 客户代码
                            FROM    dbo.SYS_SAPTransaction WITH ( NOLOCK )
                                    LEFT JOIN dbo.MFG_PartDetail ON dbo.SYS_SAPTransaction.FactoryCode = dbo.MFG_PartDetail.FactoryCode
                                                                    AND dbo.SYS_SAPTransaction.PartNo = dbo.MFG_PartDetail.PartNo
                            WHERE   MovementType IN ( 'Z15', 'Z16', '631', '632' )
                                    " + strWhere + @"
                            GROUP BY MovementType ,
                                    dbo.SYS_SAPTransaction.PartNo ,
                                    StockAdress ,
                                    CustomerCode ";
                cmd.Connection = conn;
                cmd.CommandText = sql.ToString();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        /// <summary>
        /// 获取发运报表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="intPage"></param>
        /// <param name="PAGE_SIZE"></param>
        /// <param name="intRowTotal"></param>
        /// <returns></returns>
        [Shareable]
        public DataSet GetShipmentSumList(string strWhere)
        {

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 500;
            try
            {
                conn = (SqlConnection)DB.Database.Connection;
                string sql = @"SELECT  A.CustomerCode as 客户代码,
                                    A.PartNo as 物料号,
                                    A.PartDesc as 物料描述,
                                    ( ISNULL(B.[631Qty], 0) - ISNULL(C.[632Qty], 0) + ISNULL(D.[Z15Qty], 0)
                                      - ISNULL(E.[Z16Qty], 0) )  as 数量,
                                    ISNULL(B.[631Qty], 0) [631Qty] ,
                                    ISNULL(C.[632Qty], 0) [632Qty] ,
                                    ISNULL(D.[Z15Qty], 0) [Z15Qty] ,
                                    ISNULL(E.[Z16Qty], 0) [Z16Qty]
                            FROM    ( SELECT    CustomerCode ,
                                                dbo.SYS_SAPTransaction.PartNo ,
                                                MAX(PartDesc) AS PartDesc
                                      FROM      dbo.SYS_SAPTransaction WITH ( NOLOCK )
                                                LEFT JOIN dbo.MFG_PartDetail ON dbo.SYS_SAPTransaction.FactoryCode = dbo.MFG_PartDetail.FactoryCode
                                                                                AND dbo.SYS_SAPTransaction.PartNo = dbo.MFG_PartDetail.PartNo
                                      WHERE     MovementType IN ( 'Z15', 'Z16', '631', '632' )
                                      " + strWhere + @"
                                      GROUP BY  dbo.SYS_SAPTransaction.PartNo ,
                                                CustomerCode
                                    ) AS A
                                    LEFT JOIN ( SELECT  CustomerCode ,
                                                        dbo.SYS_SAPTransaction.PartNo ,
                                                        MAX(PartDesc) AS PartDesc ,
                                                        SUM(Qty) AS '631Qty'
                                                FROM    dbo.SYS_SAPTransaction WITH ( NOLOCK )
                                                        LEFT JOIN dbo.MFG_PartDetail ON dbo.SYS_SAPTransaction.FactoryCode = dbo.MFG_PartDetail.FactoryCode
                                                                                        AND dbo.SYS_SAPTransaction.PartNo = dbo.MFG_PartDetail.PartNo
                                                WHERE   MovementType = '631'
                                                " + strWhere + @"
                                                GROUP BY MovementType ,
                                                        dbo.SYS_SAPTransaction.PartNo ,
                                                        CustomerCode
                                              ) AS B ON A.PartNo = B.PartNo
                                                        AND B.CustomerCode = A.CustomerCode
                                    LEFT JOIN ( SELECT  CustomerCode ,
                                                        dbo.SYS_SAPTransaction.PartNo ,
                                                        MAX(PartDesc) AS PartDesc ,
                                                        SUM(Qty) AS '632Qty'
                                                FROM    dbo.SYS_SAPTransaction WITH ( NOLOCK )
                                                        LEFT JOIN dbo.MFG_PartDetail ON dbo.SYS_SAPTransaction.FactoryCode = dbo.MFG_PartDetail.FactoryCode
                                                                                        AND dbo.SYS_SAPTransaction.PartNo = dbo.MFG_PartDetail.PartNo
                                                WHERE   MovementType = '632'
                                                " + strWhere + @"
                                                GROUP BY MovementType ,
                                                        dbo.SYS_SAPTransaction.PartNo ,
                                                        CustomerCode
                                              ) AS C ON A.PartNo = C.PartNo
                                                        AND C.CustomerCode = A.CustomerCode
                                    LEFT JOIN ( SELECT  CustomerCode ,
                                                        dbo.SYS_SAPTransaction.PartNo ,
                                                        MAX(PartDesc) AS PartDesc ,
                                                        SUM(Qty) AS 'Z15Qty'
                                                FROM    dbo.SYS_SAPTransaction WITH ( NOLOCK )
                                                        LEFT JOIN dbo.MFG_PartDetail ON dbo.SYS_SAPTransaction.FactoryCode = dbo.MFG_PartDetail.FactoryCode
                                                                                        AND dbo.SYS_SAPTransaction.PartNo = dbo.MFG_PartDetail.PartNo
                                                WHERE   MovementType = 'Z15'
                                                " + strWhere + @"
                                                GROUP BY MovementType ,
                                                        dbo.SYS_SAPTransaction.PartNo ,
                                                        CustomerCode
                                              ) AS D ON A.PartNo = D.PartNo
                                                        AND D.CustomerCode = A.CustomerCode
                                    LEFT JOIN ( SELECT  CustomerCode ,
                                                        dbo.SYS_SAPTransaction.PartNo ,
                                                        MAX(PartDesc) AS PartDesc ,
                                                        SUM(Qty) AS 'Z16Qty'
                                                FROM    dbo.SYS_SAPTransaction WITH ( NOLOCK )
                                                        LEFT JOIN dbo.MFG_PartDetail ON dbo.SYS_SAPTransaction.FactoryCode = dbo.MFG_PartDetail.FactoryCode
                                                                                        AND dbo.SYS_SAPTransaction.PartNo = dbo.MFG_PartDetail.PartNo
                                                WHERE   MovementType = 'Z16'
                                                " + strWhere + @"
                                                GROUP BY MovementType ,
                                                        dbo.SYS_SAPTransaction.PartNo ,
                                                        CustomerCode
                                              ) AS E ON A.PartNo = E.PartNo
                                                        AND E.CustomerCode = A.CustomerCode";
                cmd.Connection = conn;
                cmd.CommandText = sql.ToString();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion

        #region <<通过存储过程查询数据>>
        /// <summary>
        /// 通过存储过程查询数据
        /// </summary>
        /// <param name="ParameterList"></param>
        /// <returns></returns>
        [Shareable]
        public DataSet GetAllReportDataProc(List<WhereCondition> ParameterList)
        {
            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 500;
            string strProcedureName = null;
            string strSql = null;
            foreach (I.MES.Models.WhereCondition where in ParameterList)
            {

                switch (where.Key)
                {
                    case "ViewName":
                        strProcedureName = where.Value;
                        break;
                    default:
                        break;
                }
            }
            try
            {
                conn = (SqlConnection)DB.Database.Connection;
                strSql = string.Format("EXEC {0}", strProcedureName);
                #region <<查询条件>>
                foreach (I.MES.Models.WhereCondition where in ParameterList)
                {
                    if (where.Key.Equals("ViewName") ||
                     where.Key.Equals("SortColumn"))
                    {
                        continue;
                    }
                    if (where.Operator.ToLower().Equals("export"))
                    {
                        continue;
                    }
                    cmd.Parameters.Add("@" + where.ColumnName, where.Value ?? "");

                }
                #endregion
                DataSet ds = new DataSet();
                #region <<执行存储过程>>
                if (strProcedureName != null)
                {
                    cmd.Connection = conn;
                    cmd.CommandText = strProcedureName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(ds);
                }
                #endregion

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        /// <summary>
        /// 生成库存比较数据
        /// </summary>
        /// <param name="balanceTime"></param>
        [Shareable]
        public DataSet GenerateStkCompareData(DateTime balanceTime)
        {
            try
            {
                DataSet set = new DataSet();
                using (SqlConnection conn = (SqlConnection)DB.Database.Connection)
                {
                    using (SqlDataAdapter ds = new SqlDataAdapter("P_WMS_GenerateStockBalanceData", conn))
                    {
                        ds.SelectCommand.CommandTimeout = 500;
                        ds.SelectCommand.CommandType = CommandType.StoredProcedure;
                        ds.SelectCommand.Parameters.Add("@balanceTime", balanceTime);
                        ds.Fill(set);
                    }
                }
                return set;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wherecond">主表条件</param>
        /// <param name="wherecond2">子表条件</param>

        /// <param name="type">类型Report/Proc</param>
        /// <param name="type2">子类型</param>
        /// <returns></returns>
        [Shareable]
        public DataSet GetAllReport(List<WhereCondition> wherecond, List<ExportCell> wherecond2, string type)
        {
            try
            {
                DataSet ds = new DataSet();
                //主表
                DataTable dt = new DataTable();
                DataTable dts = new DataTable();
                if (type == "Proc")
                {
                    dt = GetAllReportDataProc(wherecond).Tables[0];
                    dt.TableName = "dt";
                    ds.Tables.Add(dt.Copy());
                }
                else
                {
                    dt = GetAllReportData(wherecond).Tables[0];
                    dt.TableName = "dt";
                    ds.Tables.Add(dt.Copy());
                }
                if (wherecond2 != null)
                {
                    string sid = "";
                    string fid = wherecond2.Where(p => p.Key == "PK").FirstOrDefault().Value;

                    foreach (DataRow item in dt.Rows)
                    {
                        sid += "'" + item[fid].ToString() + "',";
                    }
                    if (sid != "")
                        sid = sid.Substring(0, sid.Length - 1);
                    dts = GetReportData(wherecond2, sid);
                    dts.TableName = "dts";
                    ds.Tables.Add(dts.Copy());
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Shareable]
        public DataSet GetAllReport1(List<WhereCondition> wherecond, List<ExportCell> wherecond2, string type)
        {
            try
            {
                DataSet ds = new DataSet();
                //主表
                DataTable dt = new DataTable();
                DataTable dts = new DataTable();
                if (type == "Proc")
                {
                    dt = GetAllReportDataProc(wherecond).Tables[0];
                    dt.TableName = "dt";
                    ds.Tables.Add(dt.Copy());
                }
                else
                {
                    dt = GetAllReportData(wherecond).Tables[0];
                    dt.TableName = "dt";
                    //ds.Tables.Add(dt.Copy());
                }
                if (wherecond2 != null)
                {
                    string sid = "";
                    string fid = wherecond2.Where(p => p.Key == "PK").FirstOrDefault().Value;

                    foreach (DataRow item in dt.Rows)
                    {
                        sid += "'" + item[fid].ToString() + "',";
                    }
                    if (sid != "")
                        sid = sid.Substring(0, sid.Length - 1);
                    dts = GetReportData(wherecond2, sid);
                    dts.TableName = "dts";
                    ds.Tables.Add(dts.Copy());
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetReportData(
          List<ExportCell> ParameterList, string value)
        {
            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 500;
            string strOperator = "=";
            string strViewName = null;
            string strSortColumn = null;
            string strPK = null;
            string strNewPK = null;
            string strSortDirection = null;
            string strType = null;
            try
            {
                if (value == "") return null;
                conn = (SqlConnection)(new DataEntities().Database.Connection);// (SqlConnection)DB.Database.Connection;

                List<WhereCondition> columnList = new List<WhereCondition>();

                #region <<获取视图及排序列>>
                foreach (I.MES.Models.ExportCell where in ParameterList)
                {

                    switch (where.Key)
                    {
                        case "ViewName":
                            strViewName = where.Value;
                            break;
                        case "SortColumn":
                            strSortColumn = where.Value;
                            break;
                        case "PK":
                            strPK = where.Value;
                            break;
                        case "NewPK":
                            strNewPK = where.Value;
                            break;
                        case "Type":
                            strType = where.Value;
                            break;
                        default:

                            break;
                    }
                }
                if (string.IsNullOrWhiteSpace(strViewName))
                {
                    throw new Exception("视图为空");
                }

                #endregion
                StringBuilder sbSql = new StringBuilder();
                string field = "";
                //查询条件
                foreach (I.MES.Models.ExportCell where in ParameterList)
                {
                    if (!string.IsNullOrWhiteSpace(where.Field))
                    {
                        field += where.Field + " AS '" + (where.Title != "" ? where.Title : where.Field) + "',";

                    }
                    if (!string.IsNullOrWhiteSpace(where.SortColumn))
                    {
                        strSortColumn = where.SortColumn;
                        if (!string.IsNullOrWhiteSpace(where.SortType))
                        {
                            strSortDirection = where.SortType;
                        }
                    }

                }
                if (field != "")
                {
                    field = field.Substring(0, field.Length - 1);
                }
                else
                {
                    field = "*";
                }
                string sql = string.Format(@"SELECT {0}  FROM {1}   WHERE 1=1 And " + (strNewPK != "" ? strNewPK : strPK) + " in ({2})", field, strViewName, value);
                sbSql.Append(sql);

                //排序
                if (!string.IsNullOrWhiteSpace(strSortColumn))
                {
                    if (string.IsNullOrWhiteSpace(strSortDirection))
                    {
                        strSortDirection = "Desc";
                    }
                    sbSql.Append(string.Format(" ORDER BY {0} {1} ", strSortColumn, strSortDirection));
                }
                cmd.Connection = conn;
                cmd.CommandText = sbSql.ToString();
                //  cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                DataTable dt = ds.Tables[0];

                dt.Columns.Add("fid");
                DataRow dr = dt.NewRow();
                dr["fid"] = strPK;
                dt.Rows.Add(dr);


                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }
        #endregion


        #region 通用的增删改查
        /// <summary>
        /// 通用的查询方法
        /// </summary>
        /// <param name="talbelName">表名</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        [Shareable]
        public DataSet GetAllForReport(string talbelName, string strWhere)
        {
            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 500;
            try
            {
                conn = (SqlConnection)DB.Database.Connection;

                StringBuilder sbSql = new StringBuilder();
                if (string.IsNullOrEmpty(strWhere))
                {
                    sbSql.Append(string.Format(@"SELECT * FROM {0}   ", talbelName));
                }
                else
                {
                    sbSql.Append(string.Format(@"SELECT * FROM {0}   WHERE 1=1 " + strWhere, talbelName));
                }
                cmd.Connection = conn;
                cmd.CommandText = sbSql.ToString();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }


        /// <summary>
        /// 通用的创建方法
        /// </summary>
        /// <param name="objectName">对象名称</param>
        /// <param name="objStr">对象Json字符串</param>
        [Shareable]
        public void CreateForReport(string objectName, string objStr)
        {
            try
            {
                Type type = AssemblyHelper.GetEntityClassType(objectName);
                var model = Helper.ToEntities(objStr, type);
                DB.Set(type).Add(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 创建返回主键
        /// </summary>
        /// <param name="objectName"></param>
        /// <param name="objStr"></param>
        [Shareable]
        public string CreateForReportWithKey(string objectName, string objStr, string keyStr)
        {
            try
            {
                string id = string.Empty;
                Type type = AssemblyHelper.GetEntityClassType(objectName);
                var model = Helper.ToEntities(objStr, type);
                DB.Set(type).Add(model);
                DB.SaveChanges();
                return model.GetPropertyValue(keyStr).ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 通用的更新方法
        /// </summary>
        /// <param name="objectName">对象名称</param>
        /// <param name="objStr">对象Json字符串</param>
        [Shareable]
        public void UpdateForReport(string objectName, string objStr)
        {
            try
            {
                Type type = AssemblyHelper.GetEntityClassType(objectName);
                var model = Helper.ToEntities(objStr, type);
                if (DB.Entry(model).State == EntityState.Detached)
                {
                    DB.Set(type).Attach(model);
                    DB.Entry(model).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 通用的删除方法
        /// </summary>
        /// <param name="objectName"></param>
        /// <param name="objStr"></param>
        [Shareable]
        public void DeleteForReport(string objectName, string objStr)
        {
            try
            {
                Type type = AssemblyHelper.GetEntityClassType(objectName);
                var model = Helper.ToEntities(objStr, type);
                DB.Set(type).Remove(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        ///  通用的删除方法，传sql和参数
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="sp"></param>
        [Shareable]
        public void DeleteForReport(string sqlStr)
        {

            try
            {
                DB.Database.ExecuteSqlCommand(sqlStr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region <<SQL特殊字符转义。>>
        /// <summary>
        /// SQL特殊字符转义。
        /// 用于在查询的输入字符的转义。
        /// </summary>
        /// <param name="sqlValue"></param>
        /// <returns></returns>
        public string DealWithSqlValue(string sqlValue)
        {
            sqlValue = sqlValue.Trim().Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("^", "[^]");
            return sqlValue;
        }
        #endregion
        [Shareable]
        public List<SelectListItem> GetMaterialCtgy()
        {
            var items = (from det in DB.MFG_PartDetail
                         select new
                         {
                             det.MaterialCtgy
                         }).Distinct();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var it in items)
            {
                SelectListItem sel = new SelectListItem();
                sel.Text = it.MaterialCtgy;
                sel.Value = it.MaterialCtgy;
                list.Add(sel);
            }
            return list;
        }




    }

    /// <summary>
    /// 生成报表图形的实体
    /// </summary>
    [Serializable]
    [Shareable]
    public class ReportData
    {
        public string XData;
        public string YData;
    }
}
