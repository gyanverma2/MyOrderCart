using MyOrderCart.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyOrderCart.Services
{
	public class DummyRequestAPI : IDummyRequestAPI
	{
		public readonly HttpClient HttpClient;
		public DummyRequestAPI(HttpClient httpClient)
		{
			HttpClient = httpClient;
		}

		public async Task<bool> ConfirmOrderInExternalSystemAsync(ExternalConfirmationData request)
		{
			if (request == null) return false;

			string json = JsonConvert.SerializeObject(request);
			StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

			var response = await HttpClient.PostAsync("/test", httpContent);
			if (response.IsSuccessStatusCode) return true;

			return false;
		}
	}
}
