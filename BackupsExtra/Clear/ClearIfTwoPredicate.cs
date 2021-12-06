using System;
using System.Collections.Generic;
using System.Linq;
using Backups;

namespace BackupsExtra
{
    public class ClearIfTwoPredicate : IClearPoint
    {
        public void Clear(Predicate predicate, List<RestorePoint> restorePoints)
        {
            int countNumber = 0;
            if (restorePoints.Count > predicate.Number)
            {
                countNumber = restorePoints.Count - predicate.Number;
            }

            int countDate = 0;
            foreach (var point in restorePoints.ToList())
            {
                if (point.DateCreate < predicate.Date)
                {
                    countDate++;
                }
            }

            int min = Math.Min(countDate, countNumber);
            restorePoints.RemoveRange(0, min);
        }
    }
}