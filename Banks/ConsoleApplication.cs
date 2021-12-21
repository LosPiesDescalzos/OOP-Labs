using System;
using System.Collections.Generic;
using System.Linq;
using Banks.Tools;

namespace Banks
{
    public class ConsoleApplication
    {
        public List<DepositPercent> Percents { get; } = new List<DepositPercent>();
        public CentralBank CentralBank { get; set; } = new CentralBank();

        public Bank Bank { get; set; }

        public Client NewClient { get; set; }

        public void Start()
        {
            bool cycle = true;
            while (cycle)
            {
                Console.WriteLine("Кто вы? 1 - клиент 2 - сотрудник");
                Console.WriteLine("0 - exit");
                string person = Console.ReadLine();
                if (person == "1")
                {
                    Console.WriteLine("1 - Добавить денег на счет");
                    Console.WriteLine("2 - Снять деньги со счета");
                    Console.WriteLine("3 - Перевести деньги");
                    Console.WriteLine("4 - Узнать баланс");
                    Console.WriteLine("0 - Выход");
                    string answer = Console.ReadLine();
                    if (answer == "1")
                    {
                        AddMoney();
                    }

                    if (answer == "2")
                    {
                        GetMoney();
                    }

                    if (answer == "3")
                    {
                        TransferMoney();
                    }

                    if (answer == "4")
                    {
                        GetBalance();
                    }
                }

                if (person == "2")
                {
                    Console.WriteLine("Что желаете сделать? Выберите цифру из меню");
                    Console.WriteLine("1 - Добавить банк");
                    Console.WriteLine("2 - Добавить клиента в банк");
                    Console.WriteLine("3 - Добавить клиенту счет в банк");
                    Console.WriteLine("4 - Изменить проценты или комиссию");
                    Console.WriteLine("5 - Отменить транзакцию");
                    Console.WriteLine("6 - Узнать все транзакци пользователя транзакции");
                    Console.WriteLine("7 - Перемотать время");
                    Console.WriteLine("0 - Выход");
                    string answer = Console.ReadLine();
                    if (answer == "1")
                    {
                        AddBank();
                    }

                    if (answer == "2")
                    {
                        AddClientToBank();
                    }

                    if (answer == "3")
                    {
                        AddAccount();
                    }

                    if (answer == "4")
                    {
                        ChangeCommisionOrPercent();
                    }

                    if (answer == "5")
                    {
                        ReturnMoney();
                    }

                    if (answer == "6")
                    {
                        ListTransactions();
                    }

                    if (answer == "7")
                    {
                        ChangeTime();
                    }

                    if (answer == "0")
                    {
                        cycle = false;
                    }
                }

                if (person == "0")
                {
                    cycle = false;
                }
            }
        }

        public void AddBank()
        {
            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите комиссию для кредитнго счета");
            double commision = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите проценты для дебетового счета");
            double debitPercent = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите максимальную сумму снятия для сомниетльного клиента");
            double maxMoney = Convert.ToDouble(Console.ReadLine());
            bool cycle = true;
            while (cycle)
            {
                Console.WriteLine("Введите проценты для депозитного счета");
                Console.WriteLine("От: ");
                string startMoney = Console.ReadLine();
                Console.WriteLine("До: ");
                string endMoney = Console.ReadLine();
                Console.WriteLine("Процент: ");
                string money = Console.ReadLine();
                DepositPercent percent = new DepositPercent(Convert.ToInt32(startMoney), Convert.ToInt32(endMoney), Convert.ToDouble(money));
                Percents.Add(percent);
                Console.WriteLine("Продолжить ввод? y/n");
                string answers = Console.ReadLine();
                if (answers == "n")
                {
                    cycle = false;
                }
            }

            Bank = CentralBank.AddBank(name, commision, debitPercent, Percents, maxMoney);
            Console.WriteLine("Банк успешно создан с названием: {0}", Bank.Name);
        }

        public void AddClientToBank()
        {
            Console.WriteLine("В какой банк добавить клиента?");
            string bankName = Console.ReadLine();
            foreach (var banks in CentralBank.Banks)
            {
                if (banks.Name == bankName)
                {
                    Bank = banks;
                    Console.WriteLine("Введите имя");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите фамилию");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Желаете ввести паспортные данные? y/n");
                    string passport = null;
                    string answers = Console.ReadLine();
                    if (answers == "y")
                    {
                        Console.WriteLine("Введите свой паспорт");
                        passport = Console.ReadLine();
                    }

                    Console.WriteLine("Придумате пароль");
                    string password = Console.ReadLine();
                    NewClient = CentralBank.AddClient(Bank, name, password, surname, passport);
                    Console.WriteLine("Клиент успешно создан с именем: {0} и статусом: {1} ", NewClient.Name, NewClient.SetStatus());
                }
                else
                {
                    Console.WriteLine("Такого банка нет");
                }
            }
        }

        public void AddAccount()
        {
            Console.WriteLine("В какой банк добавить счет клиента?");
            string bankName = Console.ReadLine();
            foreach (var banks in CentralBank.Banks)
            {
                if (bankName == banks.Name)
                {
                    Bank = banks;
                    Console.WriteLine("Введите имя клиента");
                    string name = Console.ReadLine();
                    foreach (var clients in Bank.Clients)
                    {
                        if (name == clients.Name)
                        {
                            NewClient = clients;

                            Console.WriteLine("Какой счет нужно добавить? 1 - Дебетовый 2 - Кредитный 3 - Депозитный");
                            string account = Console.ReadLine();
                            Console.WriteLine("Введите имя счета");
                            string nameAccount = Console.ReadLine();
                            Console.WriteLine("Сколько денег желаете положить на счет?");
                            string money = Console.ReadLine();
                            if (account == "1")
                            {
                                CentralBank.AddDebitAccount(nameAccount, Bank, Convert.ToDouble(money), NewClient, Bank.DebitMaxMoney);
                            }

                            if (account == "2")
                            {
                                CentralBank.AddCreditAccount(nameAccount, Bank, Convert.ToDouble(money), NewClient);
                            }

                            if (account == "3")
                            {
                                Console.WriteLine("На сколько лет открыть счет?");
                                int years = Convert.ToInt32(Console.ReadLine());
                                CentralBank.AddDepositAccount(nameAccount, Bank, Convert.ToDouble(money), NewClient, years);
                            }

                            Console.WriteLine("Счет успешно добавлен!");
                        }
                        else
                        {
                            Console.WriteLine("Такого клиента нет");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Такого банка нет");
                }
            }
        }

        public void ChangeCommisionOrPercent()
        {
            double commision = 0;
            double percent = 0;
            Console.WriteLine("У какого банка изменить?");
            string bankName = Console.ReadLine();
            foreach (var banks in CentralBank.Banks)
            {
                if (bankName == banks.Name)
                {
                    Bank = banks;
                    Console.WriteLine("Что Вы хотите изменить? 1 - комиссию 2 - проценты");
                    string answer = Console.ReadLine();
                    if (answer == "1")
                    {
                        Console.WriteLine("Введите новую комиссию");
                        string newCommision = Console.ReadLine();
                        commision = Convert.ToDouble(newCommision);
                        CentralBank.ChangeCommision(Bank, commision);
                        Console.WriteLine("Комиссия изменена. Теперь комиссия: {0}", Bank.CreditCommision);
                    }

                    if (answer == "2")
                    {
                        Console.WriteLine("Введите новый процент");
                        string newPercent = Console.ReadLine();
                        percent = Convert.ToDouble(newPercent);
                        CentralBank.ChangeDebitPercent(Bank, percent);
                        Console.WriteLine("Процент изменен. Теперь процент: {0}", Bank.DebitPercent);
                    }
                }
                else
                {
                    Console.WriteLine("Такого банка нет");
                }
            }
        }

        public void ChangeTime()
        {
            Console.WriteLine("На сколько вы хотите перевести время? (ответ в формате: количество, единицы измерения)");
            string answer = Console.ReadLine();
            int count = Convert.ToInt32(answer.Split().First());
            string name = answer.Split().Last();
            if (name == "years")
            {
                CentralBank.ChangeYear(count);
            }

            if (name == "months")
            {
                CentralBank.ChangeMonth(count);
            }

            if (name == "days")
            {
                CentralBank.ChangeDay(count);
            }
        }

        public void AddMoney()
        {
            Console.WriteLine("Вы клиент какого банка? ");
            string bankName = Console.ReadLine();
            foreach (var banks in CentralBank.Banks)
            {
                if (bankName == banks.Name)
                {
                    Console.WriteLine("Введите ваш пароль: ");
                    string password = Console.ReadLine();
                    foreach (var client in banks.Clients)
                    {
                        if (password == client.Password)
                        {
                            Console.WriteLine("На какой счет добавить деньги?");
                            string account = Console.ReadLine();
                            foreach (var acc in client.Accounts)
                            {
                                if (acc.Name == account)
                                {
                                    Console.WriteLine("Сколько денег добавить?");
                                    double money = Convert.ToDouble(Console.ReadLine());
                                    acc.AddMoney(money);
                                }
                                else
                                {
                                    Console.WriteLine("Такого аккаунта нет");
                                }
                            }
                        }
                        else
                        {
                            throw new BankException("Неправильно введен пароль");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Такого банка нет");
                }
            }
        }

        public void GetMoney()
        {
            Console.WriteLine("Вы клиент какого банка? ");
            string bankName = Console.ReadLine();
            foreach (var banks in CentralBank.Banks)
            {
                if (bankName == banks.Name)
                {
                    Console.WriteLine("Введите ваш пароль: ");
                    string password = Console.ReadLine();
                    foreach (var client in banks.Clients)
                    {
                        if (password == client.Password)
                        {
                            Console.WriteLine("С какого счета снять деньги?");
                            string account = Console.ReadLine();
                            foreach (var acc in client.Accounts)
                            {
                                if (acc.Name == account)
                                {
                                    Console.WriteLine("Сколько денег снять?");
                                    double money = Convert.ToDouble(Console.ReadLine());
                                    acc.GetMoney(money);
                                    CentralBank.AddTransaction(money, acc, banks, client);
                                }
                                else
                                {
                                    Console.WriteLine("Неверно введен счет");
                                }
                            }
                        }
                        else
                        {
                            throw new BankException("Неправильно введен пароль");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Такого банка нет");
                }
            }
        }

        public void GetBalance()
        {
            Console.WriteLine("Вы клиент какого банка? ");
            string bankName = Console.ReadLine();
            foreach (var banks in CentralBank.Banks)
            {
                if (bankName == banks.Name)
                {
                    Console.WriteLine("Введите ваш пароль: ");
                    string password = Console.ReadLine();
                    foreach (var client in banks.Clients)
                    {
                        if (password == client.Password)
                        {
                            Console.WriteLine("У какого счета узнать баланс?");
                            string account = Console.ReadLine();
                            foreach (var acc in client.Accounts)
                            {
                                if (acc.Name == account)
                                {
                                    int days = CentralBank.Days(acc);
                                    acc.UpdateMoney(days);
                                    Console.WriteLine("Ваш баланс: {0}", acc.Money);
                                }
                            }
                        }
                        else
                        {
                            throw new BankException("Неправильно введен пароль");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Такого банка нет");
                }
            }
        }

        public void TransferMoney()
        {
            Console.WriteLine("Вы клиент какого банка? ");
            string bankName = Console.ReadLine();
            foreach (var banks in CentralBank.Banks)
            {
                if (bankName == banks.Name)
                {
                    Console.WriteLine("Введите ваше имя и  пароль: ");
                    string answer1 = Console.ReadLine();
                    string name = answer1.Split().First();
                    string password = answer1.Split().Last();
                    foreach (var clientFrom in banks.Clients)
                    {
                        if ((name == clientFrom.Name) && (password == clientFrom.Password))
                        {
                            Console.WriteLine("С какого счета и сколько перевести?");
                            string answer2 = Console.ReadLine();
                            string accountFrom = answer2.Split().First();
                            double money = Convert.ToDouble(answer2.Split().Last());
                            Console.WriteLine("Кому перевести деньги? На какой счет?");
                            string answer3 = Console.ReadLine();
                            string clientTo = answer3.Split().First();
                            string accountTo = answer3.Split().Last();
                            foreach (var accFrom in clientFrom.Accounts)
                            {
                                if (accFrom.Name == accountFrom)
                                {
                                    foreach (var client in banks.Clients)
                                    {
                                        if (client.Name == clientTo)
                                        {
                                            foreach (var accTo in client.Accounts)
                                            {
                                                if (accountTo == accTo.Name)
                                                {
                                                    CentralBank.TransferMoney(accFrom, accTo, money);
                                                    CentralBank.AddTransaction(money, accFrom, banks, clientFrom);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            throw new BankException("Неправильно введен пароль или имя");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Такого банка нет");
                }
            }
        }

        public void ListTransactions()
        {
            Console.WriteLine("В каком банке у какого клиента узнать транзакции?");
            string answer = Console.ReadLine();
            string bank = answer.Split().First();
            string clientName = answer.Split().Last();
            CentralBank.ListTransactions(clientName, bank);
        }

        public void ReturnMoney()
        {
            Console.WriteLine("В какой банк и кому требуется вернуть деньги?");
            string answer = Console.ReadLine();
            string bankName = answer.Split().First();
            string person = answer.Split().Last();
            foreach (var bank in CentralBank.Banks)
            {
                if (bankName == bank.Name)
                {
                    foreach (var client in bank.Clients)
                    {
                        if (client.Name == person)
                        {
                            Console.WriteLine("На каком аккаунте какую транзакцию отменить?");
                            string answer2 = Console.ReadLine();
                            string account = answer2.Split().First();
                            int id = Convert.ToInt32(answer2.Split().Last());
                            foreach (var acc in client.Accounts)
                            {
                                if (acc.Name == account)
                                {
                                    CentralBank.CancelTransaction(acc, id);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Такого клиента нет");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Такого банка нет");
                }
            }
        }
    }
}