using System.Collections.Generic;

namespace Banks
{
    public class CanselTransaction
    {
        private int _id = 0;
        public CanselTransaction(double money, Account account, Bank bank, Client client)
        {
            Id = _id;
            Money = money;
            Account = account;
            Bank = bank;
            Client = client;
        }

        public int Id { get; set; }
        public double Money { get; }
        public Account Account { get; }
        public Bank Bank { get; }
        public Client Client { get; }
    }
}