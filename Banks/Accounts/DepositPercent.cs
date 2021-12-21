using System;
namespace Banks
{
    public class DepositPercent
    {
        public DepositPercent(int startMoney, int endMoney, double percent)
        {
            StartMoney = startMoney;
            EndMoney = endMoney;
            Percent = percent;
        }

        public int StartMoney { get; }
        public int EndMoney { get; }
        public double Percent { get; }
    }
}