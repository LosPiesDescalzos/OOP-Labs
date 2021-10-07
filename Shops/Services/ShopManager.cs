using System;
using System.Collections.Generic;
using System.Linq;
using Shops.Tools;

namespace Shops
{
    public class ShopManager
    {
        public List<Person> Person { get; } = new List<Person>();
        public List<Product> AllProducts { get; set; } = new List<Product>();
        public List<Shop> AllShops { get; } = new List<Shop>();

        public Shop AddShop(string name)
        {
            var shop = new Shop(name);
            AllShops.Add(shop);
            return shop;
        }

        public Product AddProduct(string name)
        {
            var product = new Product(name);
            AllProducts.Add(product);
            return product;
        }

        public Person AddPerson(string name, int money)
        {
            if (money < 0) throw new ShopException("Error. Money < 0");
            var per = new Person(name, money);
            Person.Add(per);
            return per;
        }

        public void AddShopProduct(Shop shop, Product product, int amount, int price)
        {
            if (amount <= 0) throw new ShopException("Error. Amount of product <= 0");
            if (price < 0) throw new ShopException("Error. Price of product < 0");
            bool addProduct = true;
            foreach (Shop sh in AllShops.ToList())
            {
                if (sh.Id == shop.Id)
                {
                    foreach (ShopProduct shopProduct in shop.ShopProducts.ToList())
                    {
                        if (shopProduct.Product.Id == product.Id)
                        {
                            shopProduct.ProductItem.Amount += amount;
                            addProduct = false;
                        }
                    }

                    if (addProduct)
                    {
                        foreach (Product pr in AllProducts.ToList())
                        {
                            if (pr.Id == product.Id)
                            {
                                var productFeature = new ProductItem(amount, price);
                                var shopProduct = new ShopProduct(pr, productFeature);
                                sh.ShopProducts.Add(shopProduct);
                            }
                        }
                    }
                }
            }
        }

        public void ChangeProductPrice(Shop shop, Product product, int newPrice)
        {
            if (newPrice < 0) throw new ShopException("Error. New price of product < 0");
            foreach (Shop sh in AllShops)
            {
                foreach (ShopProduct pr in sh.ShopProducts)
                {
                    if ((sh.Id == shop.Id) && (pr.Product.Id == product.Id))
                    {
                        pr.ProductItem.Price = newPrice;
                    }
                }
            }
        }

        public Shop FindMinShopPrice(Product product, int countProducts)
        {
            if (countProducts <= 0) throw new ShopException("Error. Count of product <= 0");
            int minPrice = int.MaxValue;
            Shop nedeedShop = null;
            foreach (Shop sh in AllShops)
            {
                foreach (ShopProduct pr in sh.ShopProducts)
                {
                    if ((countProducts >= pr.ProductItem.Amount) && (pr.Product.Id == product.Id))
                    {
                        if (pr.ProductItem.Price < minPrice)
                        {
                            minPrice = pr.ProductItem.Price;
                            nedeedShop = sh;
                        }
                    }
                }
            }

            return nedeedShop;
        }

        public bool CanBuy(Person person, Product product, Shop shop, int productCount)
        {
            if (productCount <= 0) throw new ShopException("Error. Count of product <= 0");
            bool enough = false;
            int balance = 0;
            int neddedBuy = 0;
            foreach (Person pr in Person)
            {
                if (pr.Id == person.Id)
                {
                   balance = pr.Money;
                }
            }

            foreach (Shop sh in AllShops)
            {
                foreach (ShopProduct pr in sh.ShopProducts)
                {
                    if ((sh.Id == shop.Id) && (pr.Product.Id == product.Id) && (pr.ProductItem.Amount >= productCount))
                    {
                        neddedBuy = pr.ProductItem.Price * productCount;
                        if (balance < neddedBuy)
                        {
                            enough = false;
                        }
                        else
                        {
                            enough = true;
                        }
                    }
                }
            }

            return enough;
        }

        public void Buying(Person person, Product product, Shop shop, int productCount)
        {
            if (productCount <= 0) throw new ShopException("Error. Count of product <= 0");
            foreach (Shop sh in AllShops)
            {
                if (sh.Id == shop.Id)
                {
                    foreach (ShopProduct pr in sh.ShopProducts)
                    {
                        if (pr.Product.Id == product.Id)
                        {
                            foreach (Person per in Person)
                            {
                                if (per.Id == person.Id)
                                {
                                    if (CanBuy(person, product, shop, productCount))
                                    {
                                        pr.ProductItem.Amount -= productCount;
                                        int moneyBuy = productCount * pr.ProductItem.Price;
                                        per.Money -= moneyBuy;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
