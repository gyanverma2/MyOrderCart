
namespace MyOrderCart.Data
{
    public partial class ProductBase
	{
        public int id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
    }
    public class Product : ProductBase
    {
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public Rating rating { get; set; }
    }
    public class ProductExternal : ProductBase
    {
        public int quantity { get; set; }
    }
}
