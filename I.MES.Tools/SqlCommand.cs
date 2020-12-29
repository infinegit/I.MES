using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*本文档用于生成SQL命令，非架构人员不允许修改本文档*/

public class DBCommand
{
    public DBCommand()
    {
        this.Paramters = new List<DBParamter>();
    }

    public DBCommand(string sql, params System.Data.IDataParameter[] parameters)
    {
        this.Sql = sql;
        this.Paramters = new List<DBParamter>();
        foreach (var p in parameters)
        {
            var dbPara = new DBParamter();
            dbPara.Name = p.ParameterName;
            if (p.Value == DBNull.Value)
            {
                dbPara.IsNull = true;
            }
            else
            {
                dbPara.Value = p.Value.ToString();
                dbPara.ValueType = p.Value.GetType().AssemblyQualifiedName;
            }

            this.Paramters.Add(dbPara);
        }
    }

    public DBCommand(string sql, params DBParamter[] parameters)
    {
        this.Sql = sql;
        this.Paramters = new List<DBParamter>();
        this.Paramters.AddRange(parameters);
    }

    public string Sql { get; set; }
    public List<DBParamter> Paramters { get; set; }
}

public class DBParamter
{
    public string Name { get; set; }
    public string Value { get; set; }
    public byte[] ByteValue { get; set; }
    public bool IsNull { get; set; }
    public string ValueType { get; set; }
}


