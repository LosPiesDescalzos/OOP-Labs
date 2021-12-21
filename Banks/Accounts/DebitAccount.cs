using System;
using Banks.Tools;

namespace Banks.Accounts
{
    public class DebitAccount : Account
    {
        public DebitAccount(double money, string name, Bank bank, double maxMoney)
            : base(money, name)
        {
            Percent = bank.DebitPercent;
            MaxMoney = maxMoney;
        }

        public double Percent { get; }
        public double MaxMoney { get; set; }

        public override void UpdateMoney(int days)
        {
            Money += (Percent / 365) * days;
        }

        public override void GetMoney(double money)
        {
            if (Money >= money)
            {
                Money -= money;
            }

            if (Money < money)
            {
                throw new BankException("У вас недостаточно средств");
            }

            Console.WriteLine("Ваш баланс: {0}", Money);
        }
    }
}