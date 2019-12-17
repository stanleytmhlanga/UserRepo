using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using UserManagementAPI.Interfaces;

namespace UserManagementAPI.Repository
{
    public class RepositoryMemoryCache : ICacheService
    {
        public T Get<T>(string cacheKey) where T : class
        {
            return MemoryCache.Default.Get(cacheKey) as T;
        }

        public void Set(string cacheKey, object item, int minutes)
        {
            if(item != null)
            {
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(30));
            }
        }
    }
}
