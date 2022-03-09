using System;
using System.Collections.Generic;
using System.Linq;

namespace MyOrderCart.Data
{
    public class Cart
    {
        public List<CartData> Items = new List<CartData>();

        public double Total
        {
            get
            {
                return Math.Round(Items.Sum(x => x.Total),2);
            }
        }
        public DateTime LastAccessed { get; set; }
        public int TimeToLiveInSeconds { get; set; } = 30; // default
    }
}
