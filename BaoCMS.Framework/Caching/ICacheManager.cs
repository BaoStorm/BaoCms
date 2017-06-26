using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaoCMS.Framework.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        Task<T> GetAsync<T>(string key);
        void Set(string key, object data, int cacheTime);
        bool IsSet(string key);
        void Remove(string key);
        Task RemoveAsync(string key);
        void RemoveByPattern(string pattern);
        void Clear();
    }
}
