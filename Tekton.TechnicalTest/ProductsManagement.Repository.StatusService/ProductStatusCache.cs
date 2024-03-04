using Microsoft.Extensions.Caching.Memory;

namespace ProductsManagement.Repository.StatusService
{
    public class ProductStatusCache
    {
        private readonly MemoryCache _cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(5);

        public ProductStatusCache()
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
            InitializeCache();
        }

        private void InitializeCache()
        {
            var statusDictionary = new Dictionary<int, string>
        {
            { 1, "Active" },
            { 0, "Inactive" }
        };

            _cache.Set("ProductStatus", statusDictionary, _cacheExpiration);
        }

        public string GetStatusName(int statusKey)
        {
            if (_cache.TryGetValue("ProductStatus", out Dictionary<int, string> statusDictionary))
            {
                if (statusDictionary.TryGetValue(statusKey, out string statusName))
                {
                    return statusName;
                }
            }

            return string.Empty;
        }
    }
}