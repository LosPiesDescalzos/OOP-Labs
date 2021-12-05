using System;
using System.Collections.Generic;
using System.Linq;
using Backups;

namespace BackupsExtra
{
    public class OnePredicateClear : IClearPoint
    {
        public void Clear(Predicate predicate, List<RestorePoint> restorePoints)
        {
            if (restorePoints.Count > predicate.Number)
            {
                int value = restorePoints.Count - predicate.Number;
                restorePoints.RemoveRange(0, value);
            }

            foreach (var point in restorePoints.ToList())
                {
                    if (point.DateCreate < predicate.Date)
                    {
                        restorePoints.Remove(point);
                    }
                }
        }
    }
}