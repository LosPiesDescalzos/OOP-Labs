using System.Collections.Generic;
using Ionic.Zip;

namespace Backups.ZipStrategies
{
    public class SplitStorage : IAlgorithm
    {
        public List<Storage> LocalBackup(List<JobObject> jobObjects, int id, string pathRepository)
        {
            var storages = new List<Storage>();
            foreach (var job in jobObjects)
            {
                var zip = new ZipFile();
                string name = job.Path.Substring(job.Path.LastIndexOf('/') + 1);
                zip.AddFile(job.Path, "/");
                string zipPath = $"{pathRepository}/{name}_{id}.zip";
                zip.Save(zipPath);
                var storage = new Storage();
                storages.Add(storage);
            }

            return storages;
        }

        public List<Storage> VirtualBackup(List<JobObject> jobObjects, int id)
        {
            var storages = new List<Storage>();
            foreach (var job in jobObjects)
            {
                var storage = new Storage();
                storages.Add(storage);
            }

            return storages;
        }
    }
}