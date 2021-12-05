
using System.Collections.Generic;
using Banks.Accounts;
using NUnit.Framework;

namespace Banks.Tests
{
    public class BanksTests
    {
        public class Tests
        {
            public CentralBank CentralBank = new CentralBank();
            Bank bank;
            Client client;
            Client client2;


            [Test]
            public void AddBank()
            {
                List<DepositPercent> depositPercents = new List<DepositPercent>();
                DepositPercent depositPercent1 = new DepositPercent(10,100,10);
                DepositPercent depositPercent2 = new DepositPercent(101,200,20);
                depositPercents.Add(depositPercent1);
                depositPercents.Add(depositPercent2);
                string name = "Sber";
                double commision = 10;
                double debitPercent = 20;
                double maxMoney = 40;
                bank = CentralBank.AddBank(name, commision, debitPercent, depositPercents, maxMoney);
                Assert.AreEqual("Sber", bank.Name);
                Assert.AreEqual(20, bank.DebitPercent);
            }
            
            [Test]
            public void AddClient()
            {
                AddBank();
                string name = "Kate";
                string password = "123";
                string surname = "Zharkova";
                string pasport = "123456";
                
                string name2 = "Max";
                string password2 = "456";
                string surname2 = "Shat";
                string pasport2 = null;
                
                client = CentralBank.AddClient(bank, name, password, surname, pasport);
                client.SetStatus();
                client2 = CentralBank.AddClient(bank, name2, password2, surname2, pasport2);
                client2.SetStatus();
                
                Assert.IsTrue(client.Status);
                Assert.IsFalse(client2.Status);
                Assert.Contains(client, bank.Clients);
                Assert.Contains(client2, bank.Clients);
            }
            
            [Test]
            public void AddChange()
            {
                AddBank();
                double newCommision = 23;
                CentralBank.ChangeCommision(bank, newCommision);
                Assert.AreEqual(23, bank.CreditCommision);
                
                double newPercent = 14;
                CentralBank.ChangeDebitPercent(bank, newPercent);
                Assert.AreEqual(14, bank.DebitPercent);
            }
            
        
        }
    }
}