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
        public class UserRoleOP
        {
            private string Name = "I.MES.Library.UserRoleOP, I.MES.ServerLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            public System.Collections.Generic.List<I.MES.Models.SYS_UserRole> GetUserRole( System.String UserAccount)
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    __ps.Add(new Parameters(){Name = "UserAccount", Value = __compiler.Compile(UserAccount),TypeName = "System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",IsRef=false });
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "GetUserRole",
                        Parameters = __ps
                    };
    
                    ICombinator __combinator = new I.MES.GlobalCore.Combinator.CSCombinator();
    
                    var __rtn = __channel.Send(__compiler.Compile(__combinator.Combination(__info)));
    
                    BaseInfomation_O __outInfo = new Resolver<BaseInfomation_O>().Resolve(__rtn);
    
                    if (__outInfo.Error == null)
                    {
                        
                        if (__outInfo.result == null)
                        {
                            return default(System.Collections.Generic.List<I.MES.Models.SYS_UserRole>);
                        }
                        return (System.Collections.Generic.List<I.MES.Models.SYS_UserRole>)(new Resolver(typeof(System.Collections.Generic.List<I.MES.Models.SYS_UserRole>)).Resolve(__outInfo.result)); 
                    }
                    else
                    {
                        throw new MESException(__outInfo.ErrorCode, new Exception(__outInfo.Error));
                    }
                }
            }
            public System.Collections.Generic.List<I.MES.Models.SelectListItem> GetUserRoleToList( System.String UserAccount)
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    __ps.Add(new Parameters(){Name = "UserAccount", Value = __compiler.Compile(UserAccount),TypeName = "System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",IsRef=false });
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "GetUserRoleToList",
                        Parameters = __ps
                    };
    
                    ICombinator __combinator = new I.MES.GlobalCore.Combinator.CSCombinator();
    
                    var __rtn = __channel.Send(__compiler.Compile(__combinator.Combination(__info)));
    
                    BaseInfomation_O __outInfo = new Resolver<BaseInfomation_O>().Resolve(__rtn);
    
                    if (__outInfo.Error == null)
                    {
                        
                        if (__outInfo.result == null)
                        {
                            return default(System.Collections.Generic.List<I.MES.Models.SelectListItem>);
                        }
                        return (System.Collections.Generic.List<I.MES.Models.SelectListItem>)(new Resolver(typeof(System.Collections.Generic.List<I.MES.Models.SelectListItem>)).Resolve(__outInfo.result)); 
                    }
                    else
                    {
                        throw new MESException(__outInfo.ErrorCode, new Exception(__outInfo.Error));
                    }
                }
            }
            public System.Collections.Generic.List<I.MES.Models.SYS_Role> GetRoleList( System.String Account)
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    __ps.Add(new Parameters(){Name = "Account", Value = __compiler.Compile(Account),TypeName = "System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",IsRef=false });
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "GetRoleList",
                        Parameters = __ps
                    };
    
                    ICombinator __combinator = new I.MES.GlobalCore.Combinator.CSCombinator();
    
                    var __rtn = __channel.Send(__compiler.Compile(__combinator.Combination(__info)));
    
                    BaseInfomation_O __outInfo = new Resolver<BaseInfomation_O>().Resolve(__rtn);
    
                    if (__outInfo.Error == null)
                    {
                        
                        if (__outInfo.result == null)
                        {
                            return default(System.Collections.Generic.List<I.MES.Models.SYS_Role>);
                        }
                        return (System.Collections.Generic.List<I.MES.Models.SYS_Role>)(new Resolver(typeof(System.Collections.Generic.List<I.MES.Models.SYS_Role>)).Resolve(__outInfo.result)); 
                    }
                    else
                    {
                        throw new MESException(__outInfo.ErrorCode, new Exception(__outInfo.Error));
                    }
                }
            }
            public System.Collections.Generic.List<I.MES.Models.SYS_User> GetUserList()
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "GetUserList",
                        Parameters = __ps
                    };
    
                    ICombinator __combinator = new I.MES.GlobalCore.Combinator.CSCombinator();
    
                    var __rtn = __channel.Send(__compiler.Compile(__combinator.Combination(__info)));
    
                    BaseInfomation_O __outInfo = new Resolver<BaseInfomation_O>().Resolve(__rtn);
    
                    if (__outInfo.Error == null)
                    {
                        
                        if (__outInfo.result == null)
                        {
                            return default(System.Collections.Generic.List<I.MES.Models.SYS_User>);
                        }
                        return (System.Collections.Generic.List<I.MES.Models.SYS_User>)(new Resolver(typeof(System.Collections.Generic.List<I.MES.Models.SYS_User>)).Resolve(__outInfo.result)); 
                    }
                    else
                    {
                        throw new MESException(__outInfo.ErrorCode, new Exception(__outInfo.Error));
                    }
                }
            }
            public System.Int32 UpdateUserRole( System.String UserAccount, System.String RoleList)
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    __ps.Add(new Parameters(){Name = "UserAccount", Value = __compiler.Compile(UserAccount),TypeName = "System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",IsRef=false });
                    __ps.Add(new Parameters(){Name = "RoleList", Value = __compiler.Compile(RoleList),TypeName = "System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",IsRef=false });
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "UpdateUserRole",
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
