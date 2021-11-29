using System;
using System.Collections.Generic;
using Banks.Accounts;

namespace Banks
{
    public class CentralBank : IObservable
    {
        public CentralBank()
        {
            CurrentDate = DateTime.Now;
            Banks = new List<Bank>();
            Observers = new List<IObserver>();
        }

        public List<Bank> Banks { get; }

        public List<CanselTransaction> Transactions { get; set; } = new List<CanselTransaction>();
        public DateTime CurrentDate { get; set; }
        public List<IObserver> Observers { get; }

        public void ChangeDay(int day)
        {
            CurrentDate = CurrentDate.AddDays(day);
            Console.WriteLine("Сейчас: {0}", CurrentDate);
            NotifyObserverCurrentDate();
        }

        public int Days(Account account)
        {
            int days = (CurrentDate - account.Create).Days;
            return days;
        }

        public void ChangeMonth(int month)
        {
            CurrentDate = CurrentDate.AddMonths(month);
            Console.WriteLine("Сейчас: {0}", CurrentDate);
            NotifyObserverCurrentDate();
        }

        public void ChangeYear(int year)
        {
            CurrentDate = CurrentDate.AddYears(year);
            Console.WriteLine("Сейчас: {0}", CurrentDate);
            NotifyObserverCurrentDate();
        }

        public void AddObserverCurrentDate(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void NotifyObserverCurrentDate()
        {
            foreach (IObserver observer in Observers)
            {
                observer.Update(CurrentDate);
            }
        }

        public Bank AddBank(string name, double commision, double debitPercent, List<DepositPercent> depositPrecent, double maxMoney)
        {
            var builder = new BankBuilder();
            var newBank = new Bank();
            builder.BuildBank(name);
            builder.CreditCommision(commision);
            builder.DebitPercent(debitPercent);
            builder.DebitMaxValue(maxMoney);
            builder.DepositPercent(depositPrecent);
            newBank = builder.GetBank();
            Banks.Add(newBank);
            return newBank;
        }

        public Client AddClient(Bank bank, string name, string password, string surname, string passport)
        {
            var builder = new ClientBuilder();
            var newClient = new Client();
            builder.BuildClient(name, password, surname);
            builder.BuildPasport(passport);
            newClient = builder.GetClient();
            bank.Clients.Add(newClient);
            return newClient;
        }

        public void AddDebitAccount(string name, Bank thisBank, double money, Client thisClient, double maxMoney)
        {
            var account = new DebitAccount(money, name, thisBank, maxMoney);
            foreach (Bank bank in Banks)
            {
                if (bank.Name == thisBank.Name)
                {
                    foreach (Client client in thisBank.Clients)
                    {
                        if (client.Id == thisClient.Id)
                        {
                            if (client.Status == "good")
                            {
                                account.MaxMoney = double.MaxValue;
                            }

                            client.Accounts.Add(account);
                        }
                    }
                }
            }
        }

        public void AddDepositAccount(string name, Bank thisBank, double money, Client thisClient, int years)
        {
            var account = new DepositAccount(name, money, thisBank, years);
            foreach (Bank bank in Banks)
            {
                if (bank.Name == thisBank.Name)
                {
                    foreach (Client client in thisBank.Clients)
                    {
                        if (client.Id == thisClient.Id)
                        {
                            client.Accounts.Add(account);
                        }
                    }
                }
            }
        }

        public void AddCreditAccount(string name, Bank thisBank, double money, Client thisClient)
       {
           var account = new CreditAccount(money, name, thisBank);
           foreach (Bank bank in Banks)
           {
               if (bank.Name == thisBank.Name)
               {
                   foreach (Client client in thisBank.Clients)
                   {
                       if (client.Id == thisClient.Id)
                       {
                           client.Accounts.Add(account);
                       }
                   }
               }
           }
       }

        public double ChangeCommision(Bank thisBank, double commision)
        {
            Bank neededBank = new Bank();
            foreach (Bank bank in Banks)
            {
                if (bank.Name == thisBank.Name)
                {
                    neededBank = bank;
                    neededBank.CreditCommision = commision;
                    foreach (Client client in bank.Clients)
                    {
                        client.AddMessage("Your commision is changed");
                    }
                }
            }

            return neededBank.CreditCommision;
        }

        public double ChangeDebitPercent(Bank thisBank, double percent)
        {
            Bank neededBank = new Bank();
            foreach (Bank bank in Banks)
            {
                if (bank.Name == thisBank.Name)
                {
                    neededBank = bank;
                    neededBank.DebitPercent = percent;
                    foreach (Client client in bank.Clients)
                    {
                        client.AddMessage("Your percent is changed");
                    }
                }
            }

            return neededBank.DebitPercent;
        }

        public void TransferMoney(Account accountFrom, Account accountTo, double money)
        {
            if (accountFrom.Money >= money)
            {
                accountFrom.Money -= money;
                accountTo.Money += money;
            }
        }

        public void AddTransaction(double money, Account accFrom, Bank banks, Client clientFrom)
        {
            CanselTransaction cansel = new CanselTransaction(money, accFrom, banks, clientFrom);
            int id = Transactions.Count;
            cansel.Id = id++;
            Transactions.Add(cansel);
        }

        public void CanselTransaction(Account account, int ident)
        {
            foreach (var transaction in Transactions)
            {
                if ((transaction.Account == account) && (transaction.Id == ident))
                    {
                        account.Money += transaction.Money;
                        Console.WriteLine("Деньги возвращены! Баланс: {0}", account.Money);
                    }
            }
        }

        public void ListTransactions(string clientName, string bank)
        {
            foreach (var transaction in Transactions)
                {
                    if ((transaction.Client.Name == clientName) && (transaction.Bank.Name == bank))
                    {
                        Console.WriteLine("{0}: {1}", transaction.Id, transaction.Money);
                    }
                }
        }
    }
}