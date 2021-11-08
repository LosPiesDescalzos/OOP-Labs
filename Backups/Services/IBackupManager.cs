using Backups.ZipStrategies;

namespace Backups
{
    public interface IBackupManager
    {
        public Repository Repository { get; set; }
        public BackupJob BackupJob { get; set; }

        public Repository AddRepository(string path);

        public BackupJob AddBackupJob();

        public void AddFileBackupJob(string path);

        public void DeleteFileBackupJob(string path);

        public void GoLocalBackup(IAlgorithm algorithm);
        public void GoVirtualBackup(IAlgorithm algorithm);
    }
}