using System.Collections.Generic;

namespace MyOrderCart.Data
{
	public class ExternalConfirmationData
	{
		public string orderStatus { get; set; }
		public double totalPrice { get; set; }
		public List<ProductExternal> products { get; set; }
	}

}
