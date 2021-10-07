using System;
using System.Collections.Generic;
using Shops.Tools;

namespace Shops
{
    public class Product
    {
        private static int _id = 0;
        public Product(string name)
        {
            Id = _id++;
            Name = name;
         }

        public string Name { get; set; }
        public int Id { get; }
    }
}