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
        public void SingleBackup()
        {
            Repository repository = _backupManager.AddRepository("../../../BackupsDir");
            BackupJob job = _backupManager.AddBackupJob();
            _backupManager.AddFileBackupJob("../../../Files/FileA");
            _backupManager.AddFileBackupJob("../../../Files/FileB");
            var singleStorage = new SingleStorage();
            _backupManager.GoBackup(singleStorage);
        }
        
        [Test]
        public void SplitBackup()
        {
            Repository repository = _backupManager.AddRepository("../../../BackupsDir");
            BackupJob job = _backupManager.AddBackupJob();
            _backupManager.AddFileBackupJob("../../../Files/FileA");
            _backupManager.AddFileBackupJob("../../../Files/FileB");
            var splitStorage = new SplitStorage();
            _backupManager.GoBackup(splitStorage);
        }
        
        [Test]
        public void SingleBackupDeleteFile()
        {
            Repository repository = _backupManager.AddRepository("../../../BackupsDir");
            BackupJob job = _backupManager.AddBackupJob();
            _backupManager.AddFileBackupJob("../../../Files/FileA");
            _backupManager.AddFileBackupJob("../../../Files/FileB");
            var singleStorage = new SingleStorage();
            _backupManager.GoBackup(singleStorage);
            _backupManager.DeleteFileBackupJob("../../../Files/FileB");
            var singleStorage2 = new SingleStorage();
            _backupManager.GoBackup(singleStorage2);
        }
      
        [Test]
        public void SplitBackupDeleteFile()
        {
            Repository repository = _backupManager.AddRepository("../../../BackupsDir");
            BackupJob job = _backupManager.AddBackupJob();
            _backupManager.AddFileBackupJob("../../../Files/FileA");
            _backupManager.AddFileBackupJob("../../../Files/FileB");
            var splitStorage = new SplitStorage();
            _backupManager.GoBackup(splitStorage);
            _backupManager.DeleteFileBackupJob("../../../Files/FileB");
            var splitStorage2 = new SplitStorage();
            _backupManager.GoBackup(splitStorage2);
        }
    }
    
}