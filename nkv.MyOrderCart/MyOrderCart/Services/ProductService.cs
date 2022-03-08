using MyOrderCart.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyOrderCart.Services
{
    public class ProductService
    {
        FakeApiService FakeAPISerive;
        public ProductService(FakeApiService fakeApiService)
        {
            FakeAPISerive = fakeApiService;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await FakeAPISerive.HttpClient.GetAsync("/products");
            if(!response.IsSuccessStatusCode) throw new Exception("Failed to get products from API");

            var responseContent = await response.Content.ReadAsStringAsync();
            if (responseContent == null) return new List<Product>();
            return JsonConvert.DeserializeObject<List<Product>>(responseContent);
        }
    }
}
