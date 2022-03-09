using MyOrderCart.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyOrderCart.Services
{
    public class FakeApiService : IFakeApiService
    {
        public readonly HttpClient HttpClient;
        public FakeApiService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await HttpClient.GetAsync("/products");
            if (!response.IsSuccessStatusCode) throw new Exception("Failed to get products from API");

            var responseContent = await response.Content.ReadAsStringAsync();
            if (responseContent == null) return new List<Product>();
            return JsonConvert.DeserializeObject<List<Product>>(responseContent);
        }
    }
}
