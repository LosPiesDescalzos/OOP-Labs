using System.Collections.Generic;
using Ionic.Zip;

namespace Backups.ZipStrategies
{
    public class SplitStorage : IAlgorithm
    {
        public List<Storage> Backup(List<JobObject> jobObjects, int id)
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