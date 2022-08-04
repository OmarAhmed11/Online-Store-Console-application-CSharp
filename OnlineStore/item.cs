using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore
{
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public seller ItemSeller { get; set; }

        public Item(string name, decimal price, string category, seller s)
        {
            Name = name;
            Price = price;
            Category = category;
            ItemSeller = s;
        }
        public override string ToString()
        {
            return $"Name: {this.Name}, Price: {this.Price}, Category: {this.Category}";
        }
    }
}

