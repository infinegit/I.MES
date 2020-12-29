//------------------------------------------------------------------------------
// <auto-generated>
//    MES团队制作，不得以任何原因手动变更当前文档
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using I.MES.ClientCore;
using I.MES.GlobalCore;
using I.MES.Tools;
namespace I.MES.Library
{
        public class ServerTransaction
        {
            private string Name = "I.MES.Library.ServerTransaction, I.MES.ServerLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            public System.Collections.Generic.List<I.MES.Models.V_SYS_TABLE_STRUCT> GetTableStruct( System.String tableName)
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    __ps.Add(new Parameters(){Name = "tableName", Value = __compiler.Compile(tableName),TypeName = "System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",IsRef=false });
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "GetTableStruct",
                        Parameters = __ps
                    };
    
                    ICombinator __combinator = new I.MES.GlobalCore.Combinator.CSCombinator();
    
                    var __rtn = __channel.Send(__compiler.Compile(__combinator.Combination(__info)));
    
                    BaseInfomation_O __outInfo = new Resolver<BaseInfomation_O>().Resolve(__rtn);
    
                    if (__outInfo.Error == null)
                    {
                        
                        if (__outInfo.result == null)
                        {
                            return default(System.Collections.Generic.List<I.MES.Models.V_SYS_TABLE_STRUCT>);
                        }
                        return (System.Collections.Generic.List<I.MES.Models.V_SYS_TABLE_STRUCT>)(new Resolver(typeof(System.Collections.Generic.List<I.MES.Models.V_SYS_TABLE_STRUCT>)).Resolve(__outInfo.result)); 
                    }
                    else
                    {
                        throw new MESException(__outInfo.ErrorCode, new Exception(__outInfo.Error));
                    }
                }
            }
            public DBCommand Insert( System.Object entity)
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    __ps.Add(new Parameters(){Name = "entity", Value = __compiler.Compile(entity),TypeName = "System.Object, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",IsRef=false });
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "Insert",
                        Parameters = __ps
                    };
    
                    ICombinator __combinator = new I.MES.GlobalCore.Combinator.CSCombinator();
    
                    var __rtn = __channel.Send(__compiler.Compile(__combinator.Combination(__info)));
    
                    BaseInfomation_O __outInfo = new Resolver<BaseInfomation_O>().Resolve(__rtn);
    
                    if (__outInfo.Error == null)
                    {
                        
                        if (__outInfo.result == null)
                        {
                            return default(DBCommand);
                        }
                        return (DBCommand)(new Resolver(typeof(DBCommand)).Resolve(__outInfo.result)); 
                    }
                    else
                    {
                        throw new MESException(__outInfo.ErrorCode, new Exception(__outInfo.Error));
                    }
                }
            }
            public DBCommand Update( System.Object entity)
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    __ps.Add(new Parameters(){Name = "entity", Value = __compiler.Compile(entity),TypeName = "System.Object, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",IsRef=false });
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "Update",
                        Parameters = __ps
                    };
    
                    ICombinator __combinator = new I.MES.GlobalCore.Combinator.CSCombinator();
    
                    var __rtn = __channel.Send(__compiler.Compile(__combinator.Combination(__info)));
    
                    BaseInfomation_O __outInfo = new Resolver<BaseInfomation_O>().Resolve(__rtn);
    
                    if (__outInfo.Error == null)
                    {
                        
                        if (__outInfo.result == null)
                        {
                            return default(DBCommand);
                        }
                        return (DBCommand)(new Resolver(typeof(DBCommand)).Resolve(__outInfo.result)); 
                    }
                    else
                    {
                        throw new MESException(__outInfo.ErrorCode, new Exception(__outInfo.Error));
                    }
                }
            }
            public System.Int32 Commit( System.Collections.Generic.List<DBCommand> cmds)
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    __ps.Add(new Parameters(){Name = "cmds", Value = __compiler.Compile(cmds),TypeName = "System.Collections.Generic.List`1[[DBCommand, I.MES.Tools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",IsRef=false });
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "Commit",
                        Parameters = __ps
                    };
    
                    ICombinator __combinator = new I.MES.GlobalCore.Combinator.CSCombinator();
    
                    var __rtn = __channel.Send(__compiler.Compile(__combinator.Combination(__info)));
    
                    BaseInfomation_O __outInfo = new Resolver<BaseInfomation_O>().Resolve(__rtn);
    
                    if (__outInfo.Error == null)
                    {
                        
                        if (__outInfo.result == null)
                        {
                            return default(System.Int32);
                        }
                        return (System.Int32)(new Resolver(typeof(System.Int32)).Resolve(__outInfo.result)); 
                    }
                    else
                    {
                        throw new MESException(__outInfo.ErrorCode, new Exception(__outInfo.Error));
                    }
                }
            }
        }
}
