using System;
using Shops.Tools;

namespace Shops
{
    public class Person
    {
        private static int _id = 0;

        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            Id = ++_id;
        }

        public string Name { get; set; }
        public int Money { get; set; }
        public int Id { get; }
    }
}