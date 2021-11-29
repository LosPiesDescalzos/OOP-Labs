using System;
using System.Collections.Generic;

namespace Banks
{
    public class Bank
    {
        private static int _id;
        public Bank()
        {
            Id = ++_id;
            Name = null;
            DebitPercent = 0;
            DebitMaxMoney = 0;
            CreditCommision = 0;
        }

        public string Name { get; set; }
        public int Id { get; }
        public double DebitPercent { get; set; }
        public double DebitMaxMoney { get; set; }
        public List<DepositPercent> DepositPercents { get; set; }
        public double CreditCommision { get; set; }
        public List<CanselTransaction> CanselTransactions { get; set; } = new List<CanselTransaction>();
        public List<Client> Clients { get; } = new List<Client>();
    }
}