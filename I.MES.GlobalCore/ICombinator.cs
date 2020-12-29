
namespace I.MES.GlobalCore
{
    /// <summary>
    /// 合成客户端信息
    /// </summary>
    public interface ICombinator
    {
        /// <summary>
        /// 合成客户端信息
        /// </summary>
        /// <param name="data">需要合成的数据</param>
        /// <returns>合成客户端信息后的数据</returns>
        object Combination(object data);
    }
}
