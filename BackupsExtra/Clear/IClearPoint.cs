using System;
using System.Collections.Generic;
using Backups;

namespace BackupsExtra
{
    public interface IClearPoint
    {
        void Clear(Predicate predicate, List<RestorePoint> restorePoints);
    }
}