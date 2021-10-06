using System;
using System.Collections.Generic;
using Shops.Tools;

namespace Shops
{
  public class ShopProduct
  {
    public ShopProduct(Product product, ProductItem productItem)
    {
      Product = product;
      ProductItem = productItem;
    }

    public Product Product { get; set; }
    public ProductItem ProductItem { get; set; }
  }
}