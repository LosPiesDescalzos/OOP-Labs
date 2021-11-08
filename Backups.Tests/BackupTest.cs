using Backups.ZipStrategies;
using NUnit.Framework;

namespace Backups.Tests
{
    public class Tests
    {
        private BackupManager _backupManager;

        [SetUp]
        public void Setup()
        {
            _backupManager = new BackupManager();
        }

        [Test]
        public void SplitLocalBackup()
        {
            Repository repository = _backupManager.AddRepository("../../../BackupsDir");
            BackupJob job = _backupManager.AddBackupJob();
            _backupManager.AddFileBackupJob("../../../Files/FileA");
            _backupManager.AddFileBackupJob("../../../Files/FileB");
            var splitStorage = new SplitStorage();
            _backupManager.GoLocalBackup(splitStorage);
            _backupManager.DeleteFileBackupJob("../../../Files/FileB");
            _backupManager.GoLocalBackup(splitStorage);
            Assert.AreEqual(_backupManager.BackupJob.GetRestorePoints().Count, 2);
            int count = 0;
            foreach (RestorePoint restorePoint in _backupManager.BackupJob.GetRestorePoints())
            {
                count += restorePoint.GetStorages().Count;
            }

            Assert.AreEqual(count, 3);
        }
        
        [Test]
        public void SingleVirtualBackup()
        {
            Repository repository = _backupManager.AddRepository("../../../BackupsDir");
            BackupJob job = _backupManager.AddBackupJob();
            
            _backupManager.AddFileBackupJob("../../../Files/FileA");
            _backupManager.AddFileBackupJob("../../../Files/FileB");
            _backupManager.GoVirtualBackup(new SplitStorage());
            
            _backupManager.DeleteFileBackupJob("../../../Files/FileB");
            _backupManager.GoVirtualBackup(new SplitStorage());
            
            Assert.AreEqual(_backupManager.BackupJob.GetRestorePoints().Count, 2);
            Assert.AreEqual(_backupManager.BackupJob.GetRestorePoints()[0].GetStorages().Count, 2);
            Assert.AreEqual(_backupManager.BackupJob.GetRestorePoints()[1].GetStorages().Count, 1);
        }
    }
}