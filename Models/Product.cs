using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Condition { get; set; }
        public decimal Price { get; set; }
        public decimal MarketPrice { get; set; }
        public int Quantity { get; set; }
        public string OwnerName { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Info { get; set; }
        public DateTime DateTimeAdded { get; set; }
        public List<Like> Like { get; set; }
    }
}
