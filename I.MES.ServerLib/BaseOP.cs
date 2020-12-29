using System;
//using System.Collections;
using System.Collections.Generic;
using System.Data;
//using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
//using System.Reflection;
//using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using I.MES.Library.EF;

namespace I.MES.Library
{
    /// <summary>
    /// 基础操作
    /// </summary>
    public class BaseOP : IDisposable
    {

        private bool isDisposed = false;

        private string userAccount = string.Empty;
        /// <summary>
        /// 登录账户
        /// </summary>
        public string UserAccount
        {
            get
            {
                if (string.IsNullOrEmpty(userAccount))
                {
                    return ClientInfo.LoginUser;
                }
                else
                {
                    return userAccount;
                }

            }
            set
            {
                userAccount = value;
            }
        }

        private string companyCode = string.Empty;
        /// <summary>
        /// 登录账户所在公司
        /// </summary>
        public string CompanyCode
        {
            get
            {
                if (string.IsNullOrEmpty(companyCode))
                {
                    return ClientInfo.CompanyCode;
                }
                else
                {
                    return companyCode;
                }
            }
            set
            {
                companyCode = value;
            }
        }

        private string factoryCode = string.Empty;
        /// <summary>
        /// 登录账户所在工厂
        /// </summary>
        public string FactoryCode
        {
            get
            {
                if (string.IsNullOrEmpty(factoryCode))
                {
                    return ClientInfo.FactoryCode;
                }
                else
                {
                    return factoryCode;
                }
            }
            set
            {
                factoryCode = value;
            }
        }

        private string machineName = string.Empty;
        /// <summary>
        /// 登录账户的机器名
        /// </summary>
        public string MachineName
        {
            get
            {
                if (string.IsNullOrEmpty(machineName))
                {
                    return ClientInfo.Machine;
                }
                else
                {
                    return machineName;
                }
            }
            set
            {
                machineName = value;
            }
        }
        private DataEntities db;
        /// <summary>
        /// 数据库上下文
        /// </summary>
        public DataEntities DB
        {
            get
            {
                if (this.isDisposed)
                {
                    db = new DataEntities();
                    this.isDisposed = false;
                }
                return db;
            }
            protected set
            {
                this.db = value;
            }
        }

        public ClientInformation ClientInfo { get; set; }
        public BaseOP()
        { }
        /// <summary>
        /// 基础操作
        /// </summary>
        public BaseOP(ClientInformation clientInfo)
        {
            this.ClientInfo = clientInfo;
            this.DB = new DataEntities();
        }

        /// <summary>
        /// 基础操作（共用DBEntities）
        /// </summary>
        /// <param name="db"></param>
        public BaseOP(ClientInformation clientInfo, DataEntities db)
        {
            this.DB = db;
            this.ClientInfo = clientInfo;
        }
        /// <summary>
        /// 提交更改至数据库
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return this.DB.SaveChanges();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            this.isDisposed = true;
            this.DB.Dispose();
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <typeparam name="TModel">Entity类型</typeparam>
        /// <param name="model">Entity</param>
        public virtual void Insert<TModel>(TModel model) where TModel : class
        {
            DB.Set<TModel>().Add(model);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <typeparam name="TModel">Entity类型</typeparam>
        /// <param name="model">Entity</param>
        public virtual void Update<TModel>(TModel model) where TModel : class
        {
            if (DB.Entry<TModel>(model).State == EntityState.Detached)
            {
                DB.Set<TModel>().Attach(model);
                DB.Entry<TModel>(model).State = EntityState.Modified;
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <typeparam name="TModel">Entity类型</typeparam>
        /// <param name="model">Entity</param>
        public virtual void Delete<TModel>(TModel model) where TModel : class
        {
            DB.Set<TModel>().Remove(model);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="TModel">Entity类型</typeparam>
        /// <param name="filterExpression">条件语句</param>
        public void Delete<TModel>(Expression<Func<TModel, bool>> filterExpression) where TModel : class
        {
            var entities = DB.Set<TModel>();
            var items = entities.Where(filterExpression);
            foreach (var item in items)
            {
                entities.Remove(item);
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <typeparam name="TModel">Entity类型</typeparam>
        /// <param name="filterExpression">条件语句</param>
        /// <returns>符合条件的数据集合</returns>
        public virtual IEnumerable<TModel> GetList<TModel>(Expression<Func<TModel, bool>> filterExpression) where TModel : class
        {
            return DB.Set<TModel>().Where(filterExpression).ToList();
        }

        /// <summary>
        /// 获取单一数据（首行）
        /// </summary>
        /// <typeparam name="TModel">Entity类型</typeparam>
        /// <param name="filterExpression">条件语句</param>
        /// <returns>符合条件的数据</returns>
        public virtual TModel GetData<TModel>(Expression<Func<TModel, bool>> filterExpression) where TModel : class
        {
            return DB.Set<TModel>().Where(filterExpression).FirstOrDefault();

        }
    }

    /// <summary>
    /// 基础操作
    /// </summary>
    public class BaseOP<TModel> : BaseOP where TModel : class
    {
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="model">Entity</param>
        public virtual void Insert(TModel model)
        {
            DB.Set<TModel>().Add(model);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model">Entity</param>
        public virtual void Update(TModel model)
        {
            if (DB.Entry<TModel>(model).State == EntityState.Detached)
            {
                DB.Set<TModel>().Attach(model);
                DB.Entry<TModel>(model).State = EntityState.Modified;
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="model">Entity</param>
        public virtual void Delete(TModel model)
        {
            DB.Set<TModel>().Remove(model);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="filterExpression">条件语句</param>
        public void Delete(Expression<Func<TModel, bool>> filterExpression)
        {
            var entities = DB.Set<TModel>();
            var items = entities.Where(filterExpression);
            foreach (var item in items)
            {
                entities.Remove(item);
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="filterExpression">条件语句</param>
        /// <returns>符合条件的数据集合</returns>
        public virtual IEnumerable<TModel> GetList(Expression<Func<TModel, bool>> filterExpression)
        {
            return DB.Set<TModel>().Where(filterExpression).ToList();
        }

        /// <summary>
        /// 获取单一数据（首行）
        /// </summary>
        /// <param name="filterExpression">条件语句</param>
        /// <returns>符合条件的数据</returns>
        public virtual TModel GetData(Expression<Func<TModel, bool>> filterExpression)
        {
            return DB.Set<TModel>().Where(filterExpression).FirstOrDefault();
        }
    }
    /// <summary>
    /// 数据库操作扩展-需要测试
    /// </summary>
    //public static class DatabaseExtensions
    //{
    //   /// <summary>
    //   /// 自定义Sql生成Dynamic
    //   /// </summary>
    //   /// <param name="db"></param>
    //   /// <param name="sql"></param>
    //   /// <param name="parameters"></param>
    //   /// <returns></returns>
    //    public static IEnumerable SqlQueryForDynamic(this Database db, string sql, params object[] parameters)
    //    {
    //        IDbConnection defaultConn = new System.Data.SqlClient.SqlConnection();

    //        return SqlQueryForDynamicOtherDB(db, sql, defaultConn, parameters);
    //    }
    //    public static IEnumerable SqlQueryForDynamicOtherDB(this Database db, string sql, IDbConnection conn, params object[] parameters)
    //    {
    //        conn.ConnectionString = db.Connection.ConnectionString;

    //        if (conn.State != ConnectionState.Open)
    //        {
    //            conn.Open();
    //        }
    //        IDbCommand cmd = conn.CreateCommand();
    //        cmd.CommandText = sql;

    //        IDataReader dataReader = cmd.ExecuteReader();

    //        if (!dataReader.Read())
    //        {
    //            return null; //无结果返回Null
    //        }

    //        #region 构建动态字段

    //        TypeBuilder builder = DatabaseExtensions.CreateTypeBuilder(
    //                      "EF_DynamicModelAssembly",
    //                      "DynamicModule",
    //                      "DynamicType");

    //        int fieldCount = dataReader.FieldCount;
    //        for (int i = 0; i < fieldCount; i++)
    //        {
    //            //dic.Add(i, dataReader.GetName(i));

    //            //Type type = dataReader.GetFieldType(i);

    //            DatabaseExtensions.CreateAutoImplementedProperty(
    //              builder,
    //              dataReader.GetName(i),
    //              dataReader.GetFieldType(i));
    //        }

    //        #endregion

    //        dataReader.Close();
    //        dataReader.Dispose();
    //        cmd.Dispose();
    //        conn.Close();
    //        conn.Dispose();

    //        Type returnType = builder.CreateType();

    //        if (parameters != null)
    //        {
    //            return db.SqlQuery(returnType, sql, parameters);
    //        }
    //        else
    //        {
    //            return db.SqlQuery(returnType, sql);
    //        }
    //    }
    //    public static TypeBuilder CreateTypeBuilder(string assemblyName,
    //                         string moduleName,
    //                         string typeName)
    //    {
    //        TypeBuilder typeBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
    //          new AssemblyName(assemblyName),
    //          AssemblyBuilderAccess.Run).DefineDynamicModule(moduleName).DefineType(typeName,
    //          TypeAttributes.Public);
    //        typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);
    //        return typeBuilder;
    //    }

    //    public static void CreateAutoImplementedProperty(
    //                        TypeBuilder builder,
    //                        string propertyName,
    //                        Type propertyType)
    //    {
    //        const string PrivateFieldPrefix = "m_";
    //        const string GetterPrefix = "get_";
    //        const string SetterPrefix = "set_";

    //        // Generate the field.
    //        FieldBuilder fieldBuilder = builder.DefineField(
    //          string.Concat(
    //            PrivateFieldPrefix, propertyName),
    //          propertyType,
    //          FieldAttributes.Private);

    //        // Generate the property
    //        PropertyBuilder propertyBuilder = builder.DefineProperty(
    //          propertyName,
    //          System.Reflection.PropertyAttributes.HasDefault,
    //          propertyType, null);

    //        // Property getter and setter attributes.
    //        MethodAttributes propertyMethodAttributes = MethodAttributes.Public
    //          | MethodAttributes.SpecialName
    //          | MethodAttributes.HideBySig;

    //        // Define the getter method.
    //        MethodBuilder getterMethod = builder.DefineMethod(
    //            string.Concat(
    //              GetterPrefix, propertyName),
    //            propertyMethodAttributes,
    //            propertyType,
    //            Type.EmptyTypes);

    //        // Emit the IL code.
    //        // ldarg.0
    //        // ldfld,_field
    //        // ret
    //        ILGenerator getterILCode = getterMethod.GetILGenerator();
    //        getterILCode.Emit(OpCodes.Ldarg_0);
    //        getterILCode.Emit(OpCodes.Ldfld, fieldBuilder);
    //        getterILCode.Emit(OpCodes.Ret);

    //        // Define the setter method.
    //        MethodBuilder setterMethod = builder.DefineMethod(
    //          string.Concat(SetterPrefix, propertyName),
    //          propertyMethodAttributes,
    //          null,
    //          new Type[] { propertyType });

    //        // Emit the IL code.
    //        // ldarg.0
    //        // ldarg.1
    //        // stfld,_field
    //        // ret
    //        ILGenerator setterILCode = setterMethod.GetILGenerator();
    //        setterILCode.Emit(OpCodes.Ldarg_0);
    //        setterILCode.Emit(OpCodes.Ldarg_1);
    //        setterILCode.Emit(OpCodes.Stfld, fieldBuilder);
    //        setterILCode.Emit(OpCodes.Ret);

    //        propertyBuilder.SetGetMethod(getterMethod);
    //        propertyBuilder.SetSetMethod(setterMethod);
    //    }
    //}



}
