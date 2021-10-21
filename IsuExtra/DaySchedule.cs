using System;
using System.Collections.Generic;

namespace IsuExtra
{
    public class DaySchedule
    {
        public DaySchedule(Pair pair, DayOfWeek dayOfWeek)
        {
            DayOfWeek = dayOfWeek;
            Pairs.Add(pair);
        }

        public List<Pair> Pairs { get; } = new List<Pair>();
        public Pair Pair { get; }
        public DayOfWeek DayOfWeek { get; }

        public int GetNumPair(Pair pair)
        {
            int number = 0;
            foreach (var pr in Pairs)
            {
                if (pr.Id == pair.Id)
                {
                    number = pair.NumberPair;
                }
            }

            return number;
        }
    }
}