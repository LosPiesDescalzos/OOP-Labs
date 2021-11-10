using System.Collections.Generic;

namespace Backups.ZipStrategies
{
    public interface IAlgorithm
    {
        List<Storage> Backup(List<JobObject> jobObjects, int id);
    }
}