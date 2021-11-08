using System.Collections.Generic;
using Ionic.Zip;

namespace Backups.ZipStrategies
{
    public class SingleStorage : IAlgorithm
    {
        public List<Storage> LocalBackup(List<JobObject> jobObjects, int id, string pathRepository)
        {
            var storages = new List<Storage>();
            var storage = new Storage();
            var zip = new ZipFile();
            string i = id.ToString();
            foreach (JobObject jobObject in jobObjects)
            {
                string newPath = $"{jobObject.Path}_{i}";
                zip.AddFile(jobObject.Path, "/");
                var newJobObject = new JobObject(newPath);
                storage.JobObjects.Add(newJobObject);
            }

            zip.Save($"{pathRepository}/archive_{i}.zip");
            storages.Add(storage);
            return storages;
        }

        public List<Storage> VirtualBackup(List<JobObject> jobObjects, int id)
        {
            var storages = new List<Storage>();
            var storage = new Storage();
            string i = id.ToString();
            foreach (JobObject jobObject in jobObjects)
            {
                storage.JobObjects.Add(jobObject);
            }

            storages.Add(storage);
            return storages;
        }
    }
}