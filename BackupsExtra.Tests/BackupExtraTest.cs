using System;
using System.Collections.Generic;
using Backups;
using Backups.ZipStrategies;
using NUnit.Framework;
using BackupsExtra;

namespace BackupsExtra.Tests
{
    public class BackupExtraTest
    {
        private BackupManager _backupManager = new BackupManager();

        static DateTime date = new DateTime(2002, 10, 6);
         Predicate _predicate = new Predicate(date, 2);
         Predicate _predicateNumber = new Predicate(4);
         Predicate _predicateDate = new Predicate(date);

         static DateTime datePoint1 = new DateTime(2001, 9,6);
         RestorePoint point1 = new RestorePoint(datePoint1);

         static DateTime datePoint2 = new DateTime(2002, 9,6);
         RestorePoint point2 = new RestorePoint(datePoint2);

         static DateTime datePoint3 = new DateTime(2003, 9,6);
         RestorePoint point3 = new RestorePoint(datePoint3);

         static DateTime datePoint4 = new DateTime(2004, 9,6);
         RestorePoint point4 = new RestorePoint(datePoint4);

         static DateTime datePoint5 = new DateTime(2005, 9,6);
         RestorePoint point5 = new RestorePoint(datePoint5);


         [Test]
         public void ClearDate()
         {
             _backupManager.AddBackupJob();

             _backupManager.BackupJob.GetRestorePoints().Add(point1);
             _backupManager.BackupJob.GetRestorePoints().Add(point2);
             _backupManager.BackupJob.GetRestorePoints().Add(point3);
             _backupManager.BackupJob.GetRestorePoints().Add(point4);
             _backupManager.BackupJob.GetRestorePoints().Add(point5);

             List<RestorePoint> restorePoints = _backupManager.BackupJob.GetRestorePoints();

             DateClear dateClear = new DateClear();
             dateClear.Clear(_predicateDate, restorePoints);
             Assert.AreEqual(3, _backupManager.BackupJob.GetRestorePoints().Count);
         }
         
         
         [Test]
         public void ClearNumber()
         {
             _backupManager.AddBackupJob();

             _backupManager.BackupJob.GetRestorePoints().Add(point1);
             _backupManager.BackupJob.GetRestorePoints().Add(point2);
             _backupManager.BackupJob.GetRestorePoints().Add(point3);
             _backupManager.BackupJob.GetRestorePoints().Add(point4);
             _backupManager.BackupJob.GetRestorePoints().Add(point5);

             List<RestorePoint> restorePoints = _backupManager.BackupJob.GetRestorePoints();

             NumberClear numberClear = new NumberClear();
             numberClear.Clear(_predicateNumber, restorePoints);
             Assert.AreEqual(4, _backupManager.BackupJob.GetRestorePoints().Count);
         }
         
         [Test]
         public void ClearOnePredicate()
         {
             _backupManager.AddBackupJob();

             
             _backupManager.BackupJob.GetRestorePoints().Add(point1);
             _backupManager.BackupJob.GetRestorePoints().Add(point2);
             _backupManager.BackupJob.GetRestorePoints().Add(point3);
             _backupManager.BackupJob.GetRestorePoints().Add(point4);
             _backupManager.BackupJob.GetRestorePoints().Add(point5);

             List<RestorePoint> restorePoints = _backupManager.BackupJob.GetRestorePoints();

             OnePredicateClear onePredicateClear = new OnePredicateClear();
             onePredicateClear.Clear(_predicate, restorePoints);
             Assert.AreEqual(2, _backupManager.BackupJob.GetRestorePoints().Count);
         }
         
         [Test]
         public void ClearTwoPredicate()
         { 
             _backupManager.AddBackupJob();

             _backupManager.BackupJob.GetRestorePoints().Add(point1);
             _backupManager.BackupJob.GetRestorePoints().Add(point2);
             _backupManager.BackupJob.GetRestorePoints().Add(point3);
             _backupManager.BackupJob.GetRestorePoints().Add(point4);
             _backupManager.BackupJob.GetRestorePoints().Add(point5);

             List<RestorePoint> restorePoints = _backupManager.BackupJob.GetRestorePoints();

             TwoPredicateClear twoPredicateClear = new TwoPredicateClear();
             twoPredicateClear.Clear(_predicate, restorePoints);
             Assert.AreEqual(3, _backupManager.BackupJob.GetRestorePoints().Count);
         }
         
         
        [Test]
        public void Merge()
        {
            Repository repository = _backupManager.AddRepository("../../../BackupsDir");
            _backupManager.AddBackupJob();
            _backupManager.AddFileBackupJob("../../../Files/FileA");
            _backupManager.AddFileBackupJob("../../../Files/FileB");
            var singleStorage = new SingleStorage();
            
            DateTime date1 = new DateTime(2000, 10, 6);
            _backupManager.GoVirtualBackup(singleStorage, date1);
            
            DateTime date2 = new DateTime(2001, 10, 6);
            _backupManager.GoVirtualBackup(singleStorage, date2);
            
            DateTime date3 = new DateTime(2002, 10, 6);
            _backupManager.GoVirtualBackup(singleStorage, date3);

            Merge merge = new Merge();
            merge.DoMerge(_backupManager.BackupJob.GetRestorePoints());
            
            Assert.AreEqual(1, _backupManager.BackupJob.GetRestorePoints().Count);

            int countStorages = 0;
            int countFiles = 0;
            foreach (var point in _backupManager.BackupJob.GetRestorePoints())
            {
                countStorages = point.GetStorages().Count;
                foreach (var storage in point.GetStorages())
                {
                    countFiles += storage.JobObjects.Count;
                }
            }
            Assert.AreEqual(2,countStorages);
            Assert.AreEqual(2,countFiles); 
        }
        
    }
}