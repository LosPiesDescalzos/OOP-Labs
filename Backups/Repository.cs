using System.Collections.Generic;
using System.IO;
using Backups.ZipStrategies;

namespace Backups
{
    public class Repository
    {
        public Repository(string path)
        {
            Path = path;
        }

        public string Path { get; }

        public void CreateDirectory()
        {
            if (!Directory.Exists(Path))
            {
                DirectoryInfo rep = Directory.CreateDirectory(Path);
            }
        }

        public List<Storage> CreateLocalBackup(IAlgorithm algorithm, List<JobObject> jobObjects, int id)
        {
            return algorithm.LocalBackup(jobObjects, id, Path);
        }

        public List<Storage> CreateVirtualBackup(IAlgorithm algorithm, List<JobObject> jobObjects, int id)
        {
            return algorithm.VirtualBackup(jobObjects, id);
        }
    }
}