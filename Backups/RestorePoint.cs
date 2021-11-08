using System;
using System.Collections.Generic;

namespace Backups
{
    public class RestorePoint
    {
        private static int _id = 1;
        public RestorePoint()
        {
            Id = _id++;
            DateCreate = DateTime.Now;
        }

        public DateTime DateCreate { get; }
        public int Id { get; }
        private List<Storage> Storages { get; } = new List<Storage>();

        public List<Storage> GetStorages()
        {
            return Storages;
        }
    }
}