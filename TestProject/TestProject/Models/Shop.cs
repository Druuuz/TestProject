using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Schedule Schedule { get; set; }
        public string Address { get; set; }
        public List<ShopProduct> Products { get; set; }

        public Shop()
        {
            Products = new List<ShopProduct>();
        }
    }
}
