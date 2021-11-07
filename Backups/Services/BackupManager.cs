using System.Collections.Generic;
using System.IO;
using System.Linq;
using Backups.ZipStrategies;

namespace Backups
{
    public class BackupManager
    {
        public Repository Repository { get; set; }
        public BackupJob BackupJob { get; set; }

        public Repository AddRepository(string path)
        {
            var repository = new Repository(path);
            Repository = repository;
            DirectoryInfo rep = Directory.CreateDirectory(path);
            return Repository;
        }

        public BackupJob AddBackupJob()
        {
            var backupJob = new BackupJob();
            BackupJob = backupJob;
            return BackupJob;
        }

        public void AddFileBackupJob(string path)
        {
            var jobObject = new JobObject(path);
            BackupJob.JobObjects.Add(jobObject);
        }

        public void DeleteFileBackupJob(string path)
        {
            foreach (var job in BackupJob.JobObjects.ToList())
            {
                if (job.Path == path)
                {
                    BackupJob.JobObjects.Remove(job);
                }
            }
        }

        public void GoBackup(IAlgorithm algorithm)
        {
            var restorePoint = new RestorePoint();
            List<JobObject> jobObjects = BackupJob.JobObjects;
            List<Storage> storages = Repository.CreateBackup(algorithm, jobObjects, restorePoint.Id);
            restorePoint.Storages.AddRange(storages);
            BackupJob.RestorePoints.Add(restorePoint);
        }
    }
}