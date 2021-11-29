using System.Collections.Generic;
using Banks;
using Banks.Accounts;

namespace Banks
{
    public class BankBuilder
    {
        private Bank _bank = new Bank();

        public BankBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._bank = new Bank();
        }

        public void BuildBank(string name)
        {
            _bank.Name = name;
        }

        public void DebitPercent(double percent)
        {
                _bank.DebitPercent = percent;
        }

        public void DepositPercent(List<DepositPercent> depositPrecent)
        {
            _bank.DepositPercents = depositPrecent;
        }

        public void DebitMaxValue(double maxvalue)
        {
            _bank.DebitMaxMoney = maxvalue;
        }

        public void CreditCommision(double percent)
        {
            _bank.CreditCommision = percent;
        }

        public Bank GetBank()
        {
            Bank result = this._bank;
            this.Reset();
            return result;
        }
    }
}