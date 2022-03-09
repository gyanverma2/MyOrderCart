using MyOrderCart.Data;
using System.Threading.Tasks;

namespace MyOrderCart.Services
{
	public interface IDummyRequestAPI
	{
		Task<bool> ConfirmOrderInExternalSystemAsync(ExternalConfirmationData request);
	}
}
