using System.Text.Json;

namespace ProductsManagement.Repository.DiscountService
{
    public class DiscountApiClient
    {
        private readonly HttpClient _httpClient;

        public DiscountApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<int> GetDiscountValue(int productId)
        {
            try
            {
                string url = $"https://65e4fced3070132b3b257783.mockapi.io/api/v1/values/{productId}";
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                using (JsonDocument doc = JsonDocument.Parse(responseBody))
                {
                    if (doc.RootElement.TryGetProperty("discount", out JsonElement discountElement))
                    {
                        if (discountElement.TryGetInt32(out int discountValue))
                        {
                            return discountValue;
                        }
                    }
                }
                return 0;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Excepcion :{0} ", e.Message);
                return 0;
            }
        }
    }
}
