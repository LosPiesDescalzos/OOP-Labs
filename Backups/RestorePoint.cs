using System;
using System.Collections.Generic;
using System.IO;
using Backups.ZipStrategies;

namespace Backups
{
    public class RestorePoint
    {
        private static int _id = 1;
        public RestorePoint(DateTime date)
        {
            Id = _id++;
            DateCreate = date;
        }

        public DateTime DateCreate { get; set; }
        public IAlgorithm Algorithm { get; set; }
        public int Id { get; }
        private List<Storage> Storages { get; } = new List<Storage>();

        public List<Storage> GetStorages()
        {
            return Storages;
        }
    }
}