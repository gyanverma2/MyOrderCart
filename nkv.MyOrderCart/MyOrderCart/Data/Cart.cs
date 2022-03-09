using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MyOrderCart.Data
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public string ItemsJSON
        {
            get
            {
                return JsonConvert.SerializeObject(Items);
            }
            set
            {
                Items= JsonConvert.DeserializeObject<List<CartData>>(value);
            }
        }
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
