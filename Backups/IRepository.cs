using System.Collections.Generic;
using System.IO;
using Backups.ZipStrategies;

namespace Backups
{
    public interface IRepository
    {
        string Path { get; }
        void CreateDirectory();
        List<Storage> CreateLocalBackup(IAlgorithm algorithm, List<JobObject> jobObjects, int id);
        List<Storage> CreateVirtualBackup(IAlgorithm algorithm, List<JobObject> jobObjects, int id);
    }
}