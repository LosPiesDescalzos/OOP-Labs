using System;
using System.Collections.Generic;
using Shops.Tools;

namespace Shops
{
    public class ProductItem
    {
        public ProductItem(int amount, int price)
        {
            Amount = amount;
            Price = price;
        }

        public int Price { get; set; }
        public int Amount { get; set; }
    }
}