using System;
using System.Collections.Generic;
using Shops.Tools;

namespace Shops
{
  public class ShopProduct
  {
    public ShopProduct(Product product, ProductFeature productFeature)
    {
      Product = product;
      ProductFeature = productFeature;
    }

    public Product Product { get; set; }
    public ProductFeature ProductFeature { get; set; }
  }
}