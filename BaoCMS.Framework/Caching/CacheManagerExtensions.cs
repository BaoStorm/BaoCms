using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaoCMS.Framework.Caching
{
    public static class CacheManagerExtensions
    {
        public static T Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire)
        {
            return Get(cacheManager, key, 60, acquire);
        }

        public static T Get<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<T> acquire)
        {
            if (cacheTime <= 0)
                return acquire();

            var data = cacheManager.Get<T>(key);

            if (data != null)
                return data;

            var result = acquire();

            cacheManager.Set(key, result, cacheTime);

            return result;
        }

        public static async Task<T> GetAsync<T>(this ICacheManager cacheManager, string key, Func<Task<T>> acquire)
        {
            return await GetAsync(cacheManager, key, 60, acquire);
        }

        public static async Task<T> GetAsync<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<Task<T>> acquire)
        {
            if (cacheTime <= 0)
                return await acquire();

            var data = await cacheManager.GetAsync<T>(key);

            if (data != null)
                return data;

            var result = await acquire();

            cacheManager.Set(key, result, cacheTime);

            return result;
        }
    }
}
