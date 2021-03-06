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
        public class RoleManageOP
        {
            private string Name = "I.MES.Library.RoleManageOP, I.MES.ServerLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            public System.Collections.Generic.List<I.MES.Models.SelectListItem> GetAllMenu()
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "GetAllMenu",
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
            public System.Collections.Generic.List<I.MES.Models.SelectListItem> GetMenuByRoleCode( System.String RoleCode)
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    __ps.Add(new Parameters(){Name = "RoleCode", Value = __compiler.Compile(RoleCode),TypeName = "System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",IsRef=false });
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "GetMenuByRoleCode",
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
            public I.MES.Models.SYS_Role GetRoleByRoleCode( System.String RoleCode)
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    __ps.Add(new Parameters(){Name = "RoleCode", Value = __compiler.Compile(RoleCode),TypeName = "System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",IsRef=false });
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "GetRoleByRoleCode",
                        Parameters = __ps
                    };
    
                    ICombinator __combinator = new I.MES.GlobalCore.Combinator.CSCombinator();
    
                    var __rtn = __channel.Send(__compiler.Compile(__combinator.Combination(__info)));
    
                    BaseInfomation_O __outInfo = new Resolver<BaseInfomation_O>().Resolve(__rtn);
    
                    if (__outInfo.Error == null)
                    {
                        
                        if (__outInfo.result == null)
                        {
                            return default(I.MES.Models.SYS_Role);
                        }
                        return (I.MES.Models.SYS_Role)(new Resolver(typeof(I.MES.Models.SYS_Role)).Resolve(__outInfo.result)); 
                    }
                    else
                    {
                        throw new MESException(__outInfo.ErrorCode, new Exception(__outInfo.Error));
                    }
                }
            }
            public I.MES.Models.SYS_ProgPriv GetProgPrivByProgCode( System.String PrivCode)
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    __ps.Add(new Parameters(){Name = "PrivCode", Value = __compiler.Compile(PrivCode),TypeName = "System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",IsRef=false });
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "GetProgPrivByProgCode",
                        Parameters = __ps
                    };
    
                    ICombinator __combinator = new I.MES.GlobalCore.Combinator.CSCombinator();
    
                    var __rtn = __channel.Send(__compiler.Compile(__combinator.Combination(__info)));
    
                    BaseInfomation_O __outInfo = new Resolver<BaseInfomation_O>().Resolve(__rtn);
    
                    if (__outInfo.Error == null)
                    {
                        
                        if (__outInfo.result == null)
                        {
                            return default(I.MES.Models.SYS_ProgPriv);
                        }
                        return (I.MES.Models.SYS_ProgPriv)(new Resolver(typeof(I.MES.Models.SYS_ProgPriv)).Resolve(__outInfo.result)); 
                    }
                    else
                    {
                        throw new MESException(__outInfo.ErrorCode, new Exception(__outInfo.Error));
                    }
                }
            }
            public void InsertRole( I.MES.Models.SYS_Role role)
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    __ps.Add(new Parameters(){Name = "role", Value = __compiler.Compile(role),TypeName = "I.MES.Library.EF.SYS_Role, I.MES.ServerEF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",IsRef=false });
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "InsertRole",
                        Parameters = __ps
                    };
    
                    ICombinator __combinator = new I.MES.GlobalCore.Combinator.CSCombinator();
    
                    var __rtn = __channel.Send(__compiler.Compile(__combinator.Combination(__info)));
    
                    BaseInfomation_O __outInfo = new Resolver<BaseInfomation_O>().Resolve(__rtn);
    
                    if (__outInfo.Error == null)
                    {
                        
                        //if (__outInfo.result == null)
                        //{
                        //    return default(void);
                        //}
                        //return (void)(new Resolver(typeof(void)).Resolve(__outInfo.result)); 
                    }
                    else
                    {
                        throw new MESException(__outInfo.ErrorCode, new Exception(__outInfo.Error));
                    }
                }
            }
            public void UpdateRole( I.MES.Models.SYS_Role role)
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    __ps.Add(new Parameters(){Name = "role", Value = __compiler.Compile(role),TypeName = "I.MES.Library.EF.SYS_Role, I.MES.ServerEF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",IsRef=false });
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "UpdateRole",
                        Parameters = __ps
                    };
    
                    ICombinator __combinator = new I.MES.GlobalCore.Combinator.CSCombinator();
    
                    var __rtn = __channel.Send(__compiler.Compile(__combinator.Combination(__info)));
    
                    BaseInfomation_O __outInfo = new Resolver<BaseInfomation_O>().Resolve(__rtn);
    
                    if (__outInfo.Error == null)
                    {
                        
                        //if (__outInfo.result == null)
                        //{
                        //    return default(void);
                        //}
                        //return (void)(new Resolver(typeof(void)).Resolve(__outInfo.result)); 
                    }
                    else
                    {
                        throw new MESException(__outInfo.ErrorCode, new Exception(__outInfo.Error));
                    }
                }
            }
            public void InsertRoleProgPriv( I.MES.Models.SYS_RoleProgPriv RoleProgPriv)
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    __ps.Add(new Parameters(){Name = "RoleProgPriv", Value = __compiler.Compile(RoleProgPriv),TypeName = "I.MES.Library.EF.SYS_RoleProgPriv, I.MES.ServerEF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",IsRef=false });
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "InsertRoleProgPriv",
                        Parameters = __ps
                    };
    
                    ICombinator __combinator = new I.MES.GlobalCore.Combinator.CSCombinator();
    
                    var __rtn = __channel.Send(__compiler.Compile(__combinator.Combination(__info)));
    
                    BaseInfomation_O __outInfo = new Resolver<BaseInfomation_O>().Resolve(__rtn);
    
                    if (__outInfo.Error == null)
                    {
                        
                        //if (__outInfo.result == null)
                        //{
                        //    return default(void);
                        //}
                        //return (void)(new Resolver(typeof(void)).Resolve(__outInfo.result)); 
                    }
                    else
                    {
                        throw new MESException(__outInfo.ErrorCode, new Exception(__outInfo.Error));
                    }
                }
            }
            public void UpdateRoleProgPriv( I.MES.Models.SYS_RoleProgPriv RoleProgPriv)
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    __ps.Add(new Parameters(){Name = "RoleProgPriv", Value = __compiler.Compile(RoleProgPriv),TypeName = "I.MES.Library.EF.SYS_RoleProgPriv, I.MES.ServerEF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",IsRef=false });
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "UpdateRoleProgPriv",
                        Parameters = __ps
                    };
    
                    ICombinator __combinator = new I.MES.GlobalCore.Combinator.CSCombinator();
    
                    var __rtn = __channel.Send(__compiler.Compile(__combinator.Combination(__info)));
    
                    BaseInfomation_O __outInfo = new Resolver<BaseInfomation_O>().Resolve(__rtn);
    
                    if (__outInfo.Error == null)
                    {
                        
                        //if (__outInfo.result == null)
                        //{
                        //    return default(void);
                        //}
                        //return (void)(new Resolver(typeof(void)).Resolve(__outInfo.result)); 
                    }
                    else
                    {
                        throw new MESException(__outInfo.ErrorCode, new Exception(__outInfo.Error));
                    }
                }
            }
            public I.MES.Models.SYS_Role GetCfgByID( System.Int32 ID)
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    __ps.Add(new Parameters(){Name = "ID", Value = __compiler.Compile(ID),TypeName = "System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",IsRef=false });
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "GetCfgByID",
                        Parameters = __ps
                    };
    
                    ICombinator __combinator = new I.MES.GlobalCore.Combinator.CSCombinator();
    
                    var __rtn = __channel.Send(__compiler.Compile(__combinator.Combination(__info)));
    
                    BaseInfomation_O __outInfo = new Resolver<BaseInfomation_O>().Resolve(__rtn);
    
                    if (__outInfo.Error == null)
                    {
                        
                        if (__outInfo.result == null)
                        {
                            return default(I.MES.Models.SYS_Role);
                        }
                        return (I.MES.Models.SYS_Role)(new Resolver(typeof(I.MES.Models.SYS_Role)).Resolve(__outInfo.result)); 
                    }
                    else
                    {
                        throw new MESException(__outInfo.ErrorCode, new Exception(__outInfo.Error));
                    }
                }
            }
            public System.String DeleteCfg( System.Int32 ID)
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    __ps.Add(new Parameters(){Name = "ID", Value = __compiler.Compile(ID),TypeName = "System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",IsRef=false });
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "DeleteCfg",
                        Parameters = __ps
                    };
    
                    ICombinator __combinator = new I.MES.GlobalCore.Combinator.CSCombinator();
    
                    var __rtn = __channel.Send(__compiler.Compile(__combinator.Combination(__info)));
    
                    BaseInfomation_O __outInfo = new Resolver<BaseInfomation_O>().Resolve(__rtn);
    
                    if (__outInfo.Error == null)
                    {
                        
                        if (__outInfo.result == null)
                        {
                            return default(System.String);
                        }
                        return (System.String)(new Resolver(typeof(System.String)).Resolve(__outInfo.result)); 
                    }
                    else
                    {
                        throw new MESException(__outInfo.ErrorCode, new Exception(__outInfo.Error));
                    }
                }
            }
            public void DeleteRoleProgPrivByRoleCode( System.String RoleCode)
            {
                using (IChannel __channel = ChannelFactory.GetChannel())
                {
                    __channel.Open();
    
                    Compiler __compiler = new Compiler();
                    List<Parameters> __ps = new List<Parameters>();
                    
                    __ps.Add(new Parameters(){Name = "RoleCode", Value = __compiler.Compile(RoleCode),TypeName = "System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",IsRef=false });
                    BaseInformation_I __info = new BaseInformation_I()
                    {
                        ClassName = this.Name,
                        FunctionName = "DeleteRoleProgPrivByRoleCode",
                        Parameters = __ps
                    };
    
                    ICombinator __combinator = new I.MES.GlobalCore.Combinator.CSCombinator();
    
                    var __rtn = __channel.Send(__compiler.Compile(__combinator.Combination(__info)));
    
                    BaseInfomation_O __outInfo = new Resolver<BaseInfomation_O>().Resolve(__rtn);
    
                    if (__outInfo.Error == null)
                    {
                        
                        //if (__outInfo.result == null)
                        //{
                        //    return default(void);
                        //}
                        //return (void)(new Resolver(typeof(void)).Resolve(__outInfo.result)); 
                    }
                    else
                    {
                        throw new MESException(__outInfo.ErrorCode, new Exception(__outInfo.Error));
                    }
                }
            }
        }
}
