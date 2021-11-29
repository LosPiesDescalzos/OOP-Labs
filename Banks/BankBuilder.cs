using System.Collections.Generic;
using Banks;
using Banks.Accounts;

namespace Banks
{
    public class BankBuilder
    {
        private string _name;
        private double _creditCommision;
        private double _debitPercent;
        private double _debitMaxMoney;
        private List<DepositPercent> _depositPercent;

        public BankBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public BankBuilder SetDebitPercent(double percent)
        {
                _debitPercent = percent;
                return this;
        }

        public BankBuilder SetDepositPercent(List<DepositPercent> percent)
        {
            _depositPercent = percent;
            return this;
        }

        public BankBuilder SetDebitMaxMoney(double maxMoney)
        {
            _debitMaxMoney = maxMoney;
            return this;
        }

        public BankBuilder SetCommision(double commision)
        {
            _creditCommision = commision;
            return this;
        }

        public Bank GetBank()
        {
            return new Bank(_name, _creditCommision, _debitPercent, _depositPercent, _debitMaxMoney);
        }
    }
}