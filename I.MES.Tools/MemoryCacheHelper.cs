using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
using System.Collections;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Runtime.Caching;

namespace I.MES.Tools
{
    /// <summary>
    /// 基于MemoryCache的缓存辅助类
    /// </summary>
    public static class MemoryCacheHelper
    {
        private static readonly Object _locker = new object();

        public static T GetCacheItem<T>(String key, Func<T> cachePopulate, TimeSpan? slidingExpiration = null, DateTime? absoluteExpiration = null)
        {
            if (String.IsNullOrEmpty(key)) throw new ArgumentException("Invalid cache key");
            if (cachePopulate == null) throw new ArgumentNullException("cachePopulate");
            if (slidingExpiration == null && absoluteExpiration == null) throw new ArgumentException("Either a sliding expiration or absolute must be provided");

            if (MemoryCache.Default[key] == null)
            {
                lock (_locker)
                {
                    if (MemoryCache.Default[key] == null)
                    {
                        var item = new CacheItem(key, cachePopulate());
                        var policy = CreatePolicy(slidingExpiration, absoluteExpiration);
                        if (item.Value != null)
                        {
                            MemoryCache.Default.Add(item, policy);
                        }
                    }
                }
            }

            return (T)MemoryCache.Default[key];
        }

        /// <summary>
        /// 清除缓存
        /// </summary>
        public static void ClearAllCache()
        {
            try
            {
                foreach (var element in MemoryCache.Default)
                {
                    MemoryCache.Default.Remove(element.Key);
                }
            }
            catch {}
        }

        private static CacheItemPolicy CreatePolicy(TimeSpan? slidingExpiration, DateTime? absoluteExpiration)
        {
            var policy = new CacheItemPolicy();

            if (absoluteExpiration.HasValue)
            {
                policy.AbsoluteExpiration = absoluteExpiration.Value;
            }
            else if (slidingExpiration.HasValue)
            {
                policy.SlidingExpiration = slidingExpiration.Value;
            }

            policy.Priority = CacheItemPriority.Default;

            return policy;
        }
    }
}
