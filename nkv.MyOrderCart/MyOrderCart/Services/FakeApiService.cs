using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;

namespace MyOrderCart.Services
{
    public class FakeApiService
    {
        public readonly HttpClient HttpClient;
        public FakeApiService(HttpClient httpClient, IConfiguration iConfig)
        {
            HttpClient = httpClient;
            HttpClient.BaseAddress = new Uri(iConfig.GetValue<string>("APIUrl:FakeAPI"));
        }
    }
}
