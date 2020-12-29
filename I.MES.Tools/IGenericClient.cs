
namespace I.MES.Tools
{
    /// <summary>
    /// 生成客户端数据
    /// 注:生成的数据类型需一致或与MapWith的类型一致
    /// </summary>
    public interface IGenericClient
    {
        object GenerateClient();
    }
}
