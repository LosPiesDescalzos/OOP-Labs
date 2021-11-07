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

        public List<Storage> CreateBackup(IAlgorithm algorithm, List<JobObject> jobObjects, int id)
        {
            return algorithm.LocalBackup(jobObjects, id, Path);
        }
    }
}