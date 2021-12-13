using System;
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
            DateTime date = new DateTime(2004, 9, 6);
            backupManager.GoVirtualBackup(singleStorage, date);
        }
    }
}