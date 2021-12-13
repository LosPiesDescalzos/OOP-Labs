using System;
using System.Collections.Generic;
using System.Linq;
using Backups;

namespace BackupsExtra
{
    public class NumberClear : IClearPoint
    {
        public void Clear(Predicate predicate, List<RestorePoint> restorePoints)
        {
            int count = restorePoints.Count;
            if (count > predicate.Number)
            {
                int value = count - predicate.Number;
                restorePoints.RemoveRange(0, value);
            }
        }
    }
}