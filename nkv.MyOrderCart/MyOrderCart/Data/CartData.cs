using System;

namespace MyOrderCart.Data
{
    public class CartData
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public double Total
        {
            get
            {
                return Math.Round(Product.price * Quantity,2);
            }
        }
    }
}
