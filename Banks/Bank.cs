using System;
using System.Collections.Generic;

namespace Banks
{
    public class Bank
    {
        private static int _id;
        public Bank(string name, double creditCommision, double debitPercent, List<DepositPercent> depositPercent, double debitMaxMoney)
        {
            Id = ++_id;
            Name = name;
            DebitPercent = debitPercent;
            DebitMaxMoney = debitMaxMoney;
            CreditCommision = creditCommision;
            DepositPercents = depositPercent;
        }

        public string Name { get; }
        public int Id { get; }
        public double DebitPercent { get; set; }
        public double DebitMaxMoney { get; }
        public List<DepositPercent> DepositPercents { get; set; }
        public double CreditCommision { get; set; }
        public List<CancelTransaction> CancelTransactions { get; set; } = new List<CancelTransaction>();
        public List<Client> Clients { get; } = new List<Client>();
    }
}