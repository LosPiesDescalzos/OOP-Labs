using System;

namespace BackupsExtra
{
    public class Predicate
    {
        public Predicate(DateTime date, int number)
        {
            Number = number;
            Date = date;
        }

        public Predicate(DateTime date)
            : this(date, 0)
        {
        }

        public Predicate(int number)
            : this(default, number)
        {
        }

        public int Number { get; }
        public DateTime Date { get; }
    }
}