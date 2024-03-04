namespace ProductsManagement.Api.ExternalServicesAdapters
{
    internal sealed class StatusAdapter
    {
        public string GetStatusProduct(int status)
        {
            var statusCacheService = new Repository.StatusService.ProductStatusCache();
            return statusCacheService.GetStatusName(status);
        }
    }
}
