using MyOrderCart.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace MyOrderCart.Services
{
	public interface IFakeApiService
	{
		Task<List<Product>> GetProductsAsync();
	}
}
