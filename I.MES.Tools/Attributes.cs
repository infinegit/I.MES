using System;


/*本文档用于生成相关的属性，非架构人员不允许修改本文档*/

/// <summary>
/// 指示生成客户端元素
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public sealed class ShareableAttribute : Attribute
{

    public ShareableAttribute()
    {

    }
}

/// <summary>
/// 与当前类相关的Model
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
public sealed class MapWithAttribute : Attribute
{
    public MapWithAttribute(Type type)
    {
        try
        {
            MapType = type;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public MapWithAttribute(string typename)
    {
        MapType = Type.GetType(typename);
    }

    public Type MapType
    {
        get;
        private set;
    }
}

/// <summary>
/// 用于生成Script客户端的名称
/// 防止重载
/// </summary>
[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public sealed class ScriptNameAttribute : Attribute
{
    public ScriptNameAttribute(string scriptName)
    {
        this.ScriptName = scriptName;
    }

    public string ScriptName
    {
        get;
        private set;
    }
}

