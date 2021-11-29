using System;
using System.Collections.Generic;

namespace Banks.Accounts
{
    public class CreditAccount : Account
    {
        public CreditAccount(double money, string name, Bank bank)
            : base(money, name)
        {
            Commision = bank.CreditCommision;
        }

        public double Commision { get; }

        public override void UpdateMoney(int days)
        {
            if (Money < 0)
            {
                Money -= Commision * days;
            }
        }
    }
}