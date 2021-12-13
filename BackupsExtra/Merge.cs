using System;
using System.Collections.Generic;
using System.Linq;
using Backups;
using Backups.ZipStrategies;

namespace BackupsExtra
{
    public class Merge
    {
        public void DoMerge(List<RestorePoint> restorePoints)
        {
            List<JobObject> newJobObjects = new List<JobObject>();
            int count = restorePoints.Count;

            restorePoints.OrderBy(x => x.DateCreate).ToList();
            if (restorePoints[count - 1].Algorithm is SplitStorage)
            {
                restorePoints.RemoveRange(0, count - 2);
            }
            else
            {
                foreach (var restorePoint in restorePoints)
                {
                    foreach (var storages in restorePoint.GetStorages())
                    {
                        newJobObjects.AddRange(storages.JobObjects);
                    }
                }
            }

            for (int i = 0; i < newJobObjects.Count; i++)
            {
                for (int d = i + 1; d < newJobObjects.Count; d++)
                {
                    if (newJobObjects[i].Path == newJobObjects[d].Path)
                    {
                        newJobObjects.Remove(newJobObjects[d]);
                        d--;
                    }
                }
            }

            restorePoints.Clear();
            RestorePoint point = new RestorePoint(DateTime.Now);

            foreach (var job in newJobObjects)
            {
                 Storage storage = new Storage();
                 storage.JobObjects.Add(job);
                 point.GetStorages().Add(storage);
            }

            restorePoints.Add(point);
        }
    }
}