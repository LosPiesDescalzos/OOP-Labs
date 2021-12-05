using System;
using System.Collections.Generic;
using System.Linq;
using Backups;

namespace BackupsExtra
{
    public class DateClear : IClearPoint
    {
        public void Clear(Predicate predicate, List<RestorePoint> restorePoints)
        {
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