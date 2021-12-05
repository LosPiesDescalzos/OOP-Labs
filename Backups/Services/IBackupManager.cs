using System;
using System.Collections.Generic;
using Backups.ZipStrategies;

namespace Backups
{
    public interface IBackupManager
    {
        Repository Repository { get; set; }
        BackupJob BackupJob { get; set; }

        Repository AddRepository(string path);

        BackupJob AddBackupJob();

        void AddFileBackupJob(string path);

        void DeleteFileBackupJob(string path);

        void GoLocalBackup(IAlgorithm algorithm, DateTime dateTime);
        void GoVirtualBackup(IAlgorithm algorithm, DateTime dateTime);
    }
}