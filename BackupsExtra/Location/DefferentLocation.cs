using System.IO;
using System.Linq;
using Backups;

namespace BackupsExtra
{
    public class DefferentLocation : IChangeLocation
    {
        public void Restore(RestorePoint point, string path)
        {
            foreach (var storage in point.GetStorages().ToList())
            {
                foreach (var jobObject in storage.JobObjects)
                {
                    FileInfo file = new FileInfo(path);
                    using (StreamWriter sw = file.CreateText())
                    {
                        sw.WriteLine(jobObject.Data);
                    }
                }
            }
        }
    }
}