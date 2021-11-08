using Backups.ZipStrategies;

namespace Backups
{
    public class Program
    {
        public static void Main()
        {
            var backupManager = new BackupManager();

            Repository repository = backupManager.AddRepository("../../../BackupsDir");
            BackupJob job = backupManager.AddBackupJob();
            backupManager.AddFileBackupJob("../../../Files/FileA");
            backupManager.AddFileBackupJob("../../../Files/FileB");
            var singleStorage = new SingleStorage();
            backupManager.GoLocalBackup(singleStorage);
        }
    }
}