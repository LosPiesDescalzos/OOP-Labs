using System.Collections.Generic;

namespace Backups
{
    public class BackupJob
    {
        public List<JobObject> JobObjects { get; } = new List<JobObject>();
        private List<RestorePoint> RestorePoints { get; } = new List<RestorePoint>();

        public List<RestorePoint> GetRestorePoints()
        {
            return RestorePoints;
        }
    }
}