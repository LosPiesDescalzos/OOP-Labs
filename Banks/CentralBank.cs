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

        public List<CancelTransaction> Transactions { get; set; } = new List<CancelTransaction>();
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

        public Bank AddBank(string name, double commision, double debitPercent, List<DepositPercent> depositPerecent, double maxMoney)
        {
            var builder = new BankBuilder();
            builder.SetName(name).SetCommision(commision).SetDebitPercent(debitPercent).SetDepositPercent(depositPerecent).SetDebitMaxMoney(maxMoney);
            Bank bank = builder.GetBank();
            Banks.Add(bank);
            return bank;
        }

        public Client AddClient(Bank bank, string name, string password, string surname, string passport)
        {
            var builder = new ClientBuilder();

            builder.SetNameSurname(name, surname).SetPassword(password).SetPasport(passport);
            Client client = builder.GetClient();
            bank.Clients.Add(client);
            return client;
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

        public void ChangeCommision(Bank thisBank, double commision)
        {
            foreach (Bank bank in Banks)
            {
                if (bank.Name == thisBank.Name)
                {
                    bank.CreditCommision = commision;
                    foreach (Client client in bank.Clients)
                    {
                        client.AddMessage("Your commision is changed");
                    }
                }
            }
        }

        public void ChangeDebitPercent(Bank thisBank, double percent)
        {
            foreach (Bank bank in Banks)
            {
                if (bank.Name == thisBank.Name)
                {
                    bank.DebitPercent = percent;
                    foreach (Client client in bank.Clients)
                    {
                        client.AddMessage("Your percent is changed");
                    }
                }
            }
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
            CancelTransaction cansel = new CancelTransaction(money, accFrom, banks, clientFrom);
            int id = Transactions.Count;
            cansel.Id = id++;
            Transactions.Add(cansel);
        }

        public void CancelTransaction(Account account, int ident)
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