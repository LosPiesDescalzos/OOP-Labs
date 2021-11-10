using System.Collections.Generic;
using System.IO;
using Backups.ZipStrategies;
using Ionic.Zip;

namespace Backups
{
    public class Repository : IRepository
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

        public List<Storage> CreateVirtualBackup(IAlgorithm algorithm, List<JobObject> jobObjects, int id)
        {
            List<Storage> storages = algorithm.Backup(jobObjects, id);
            foreach (Storage storage in storages)
            {
                foreach (JobObject jobObject in storage.JobObjects)
                {
                    JobObject newJobObject = new JobObject(jobObject.Path);
                    string newPath = $"{jobObject.Path}_{id}";
                    newJobObject.Path = newPath;
                }
            }

            return storages;
        }

        public List<Storage> CreateLocalBackup(IAlgorithm algorithm, List<JobObject> jobObjects, int id)
        {
            var zip = new ZipFile();
            List<Storage> storages = algorithm.Backup(jobObjects, id);
            foreach (Storage storage in storages)
            {
                foreach (JobObject jobObject in storage.JobObjects)
                {
                    JobObject newJobObject = new JobObject(jobObject.Path);
                    string newPath = $"{jobObject.Path}_{id}";
                    newJobObject.Path = newPath;
                    zip.AddFile(newPath);
                }

                zip.Save($"{Path}/archive_{id}.zip");
            }

            return storages;
        }
    }
}