using System.Collections.Generic;

namespace Backups.ZipStrategies
{
    public interface IAlgorithm
    {
        List<Storage> LocalBackup(List<JobObject> jobObjects, int id, string pathRepository);
        List<Storage> VirtualBackup(List<JobObject> jobObjects, int id);
    }
}