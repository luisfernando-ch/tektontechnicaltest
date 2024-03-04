namespace ProductsManagement.Api.ExternalServicesAdapters
{
    internal sealed class DiscountAdapter
    {
        public byte GetDiscountValue(int productId)
        {
            var discountApiClient = new Repository.DiscountService.DiscountApiClient();
            return (byte)discountApiClient.GetDiscountValue(productId).Result;
        }
    }
}
