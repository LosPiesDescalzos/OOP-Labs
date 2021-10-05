using System.Linq;
using Shops;
using NUnit.Framework;

namespace Shops.Tests
{
    public class Tests
    {
        private ShopManager _shopManager;

        [SetUp]
        public void Setup()
        {
            _shopManager = new ShopManager();
        }
        [Test]
        public void AddShop()
        {
            Shop shop1 = _shopManager.AddShop("Okay");
            Shop shop2 = _shopManager.AddShop("FixPrice");
            Assert.Contains(shop1, _shopManager.AllShops.ToList());
            Assert.Contains(shop2, _shopManager.AllShops.ToList());
        }

        [Test]
        public void AddPerson()
        {
            Person per = _shopManager.AddPerson("Masha", 1000);
            Assert.Contains(per, _shopManager.Person.ToList());
        }

        [Test]
        public void AddProductToAllProduct()
        {
            Product product = _shopManager.AddProduct("Banana");
            Assert.Contains(product, _shopManager.AllProducts.ToList());
        }

        [Test]
        public void AddShopProducts()
        {
            Shop shop = _shopManager.AddShop("Okay");
            Product product = _shopManager.AddProduct("Banana");
            _shopManager.AddShopProduct(shop, product, 10, 20);
        }
        
        [Test]
        public void ChangePrice()
        {
            Shop shop = _shopManager.AddShop("Lenta");
            Product product = _shopManager.AddProduct("Milk");
            _shopManager.AddShopProduct(shop, product, 20, 80);
            _shopManager.ChangeProductPrice(shop, product,155);
        }
        
        [Test]
        public void CheckMinProductPrice()
        {
            Shop shop1 = _shopManager.AddShop("Lenta");
            Shop shop2 = _shopManager.AddShop("Okay");
            Shop shop3 = _shopManager.AddShop("FixPrice");
            Product product = _shopManager.AddProduct("Banana");
            _shopManager.AddShopProduct(shop1, product, 20, 80);
            _shopManager.AddShopProduct(shop2, product, 15, 100);
            _shopManager.AddShopProduct(shop3, product, 30, 60);
            _shopManager.FindMinShopPrice(product, 10);
        }
        
        [Test]
        public void CheckBalance()
        {
            Person person = _shopManager.AddPerson("Misha", 5080);
            Shop shop = _shopManager.AddShop("Lenta");
            Product product = _shopManager.AddProduct("Apple");
            _shopManager.AddShopProduct(shop, product, 20, 80);
            int balance = _shopManager.Balance(person, shop, product, 5);
        }
        
        [Test]
        public void CanPersonBuy()
        {
            Person person = _shopManager.AddPerson("Misha", 170);
            Shop shop = _shopManager.AddShop("Lenta");
            Product product = _shopManager.AddProduct("Milk");
            _shopManager.AddShopProduct(shop, product, 20, 80);
            bool chek = _shopManager.CanBuy(person, product, shop, 5);
        }
        
        [Test]
        public void BuyProducts()
        {
            int money = 170;
            int price = 20;
            int productCount = 5;
            Person person = _shopManager.AddPerson("Misha", money);
            Shop shop = _shopManager.AddShop("Lenta");
            Product product = _shopManager.AddProduct("Milk");
            _shopManager.AddShopProduct(shop, product, 20, price);
            _shopManager.Buying(person, product, shop, productCount);
            int forEqual = money - (price * productCount);
            Assert.AreEqual(forEqual, person.Money);
        }
    }
}