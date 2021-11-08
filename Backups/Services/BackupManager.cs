using System.Collections.Generic;
using System.IO;
using System.Linq;
using Backups.ZipStrategies;

namespace Backups
{
    public class BackupManager : IBackupManager
    {
        public Repository Repository { get; set; }
        public BackupJob BackupJob { get; set; }

        public Repository AddRepository(string path)
        {
            var repository = new Repository(path);
            Repository = repository;
            Repository.CreateDirectory();
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

        public void GoLocalBackup(IAlgorithm algorithm)
        {
            var restorePoint = new RestorePoint();
            List<JobObject> jobObjects = BackupJob.JobObjects;
            List<Storage> storages = Repository.CreateLocalBackup(algorithm, jobObjects, restorePoint.Id);
            restorePoint.GetStorages().AddRange(storages);
            BackupJob.GetRestorePoints().Add(restorePoint);
        }

        public void GoVirtualBackup(IAlgorithm algorithm)
        {
            var restorePoint = new RestorePoint();
            List<JobObject> jobObjects = BackupJob.JobObjects;
            List<Storage> storages = Repository.CreateVirtualBackup(algorithm, jobObjects, restorePoint.Id);
            restorePoint.GetStorages().AddRange(storages);
            BackupJob.GetRestorePoints().Add(restorePoint);
        }
    }
}