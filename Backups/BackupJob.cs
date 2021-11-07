using System.Collections.Generic;

namespace Backups
{
    public class BackupJob
    {
        public List<RestorePoint> RestorePoints { get; } = new List<RestorePoint>();
        public List<JobObject> JobObjects { get; } = new List<JobObject>();
    }
}