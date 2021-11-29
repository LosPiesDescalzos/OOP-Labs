using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Banks.Accounts
{
    public class DepositAccount : Account
    {
        public DepositAccount(string name, double money, Bank bank, int years)
            : base(money, name)
        {
           Percents = bank.DepositPercents;
           End = Create.AddYears(years);
        }

        public List<DepositPercent> Percents { get; } = new List<DepositPercent>();
        public DateTime End { get; }

        public override void UpdateMoney(int days)
        {
            foreach (var per in Percents)
            {
                if ((Money < per.EndMoney) && (Money >= per.StartMoney))
                {
                    double percent = per.Percent;
                    Money += percent * days;
                }
            }
        }

        public override void GetMoney(double money)
        {
            CentralBank centralBank = new CentralBank();
            if (centralBank.CurrentDate <= End)
            {
                Money -= money;
                Console.WriteLine("Деньги успешно сняты! Остаток на счете: {0}", Money);
            }
            else
            {
                Console.WriteLine("Вы можете снимать деньги только при истечении срока давности вашего счета");
            }
        }
    }
}