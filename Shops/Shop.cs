using System;
using System.Collections.Generic;
using Shops.Tools;

namespace Shops
{
    public class Shop
    {
        private static int _id = 0;

        public Shop(string name)
        {
            Name = name;
            Id = _id++;
        }

        public List<ShopProduct> ShopProducts { get; set; } = new List<ShopProduct>();
        public string Name { get; set; }
        public int Id { get; }
    }
}