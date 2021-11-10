using System.Collections.Generic;
using Ionic.Zip;

namespace Backups.ZipStrategies
{
    public class SingleStorage : IAlgorithm
    {
        public List<Storage> Backup(List<JobObject> jobObjects, int id)
        {
            var storages = new List<Storage>();
            var storage = new Storage();
            foreach (JobObject jobObject in jobObjects)
            {
                storage.JobObjects.Add(jobObject);
            }

            storages.Add(storage);
            return storages;
        }
    }
}