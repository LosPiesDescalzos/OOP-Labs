using System.Collections.Generic;

namespace Backups.ZipStrategies
{
    public interface IAlgorithm
    {
        public List<Storage> LocalBackup(List<JobObject> jobObjects, int id, string pathRepository);
    }
}