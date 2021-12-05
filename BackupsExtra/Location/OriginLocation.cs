using System.IO;
using System.Linq;
using Backups;

namespace BackupsExtra
{
    public class OriginLocation : IChangeLocation
    {
        private BackupManager _backupManager = new BackupManager();
        public void Restore(RestorePoint point, string path)
        {
            foreach (var storage in point.GetStorages().ToList())
            {
                foreach (var jobObject in storage.JobObjects)
                {
                    var file = new FileInfo(jobObject.Path);
                    using (StreamWriter sw = file.CreateText())
                    {
                        sw.WriteLine(jobObject.Data);
                    }
                }
            }
        }
    }
}