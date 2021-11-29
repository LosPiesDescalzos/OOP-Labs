using System;
using Banks.Accounts;

namespace Banks
{
    public abstract class Account
    {
        private int _id;
        protected Account(double money, string name)
        {
            Id = ++_id;
            Create = DateTime.Now;
            Money = money;
            Name = name;
        }

        public int Id { get; }
        public DateTime Create { get; }
        public double Money { get; set; }
        public string Name { get; }

        public virtual void UpdateMoney(int days)
        {
        }

        public virtual void GetMoney(double money)
        {
            Money -= money;
            Console.WriteLine("Баланс: {0}", Money);
        }

        public void AddMoney(double money)
        {
            Money += money;
            Console.WriteLine("Баланс: {0}", Money);
        }
    }
}