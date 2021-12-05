using System;
using System.IO;
using System.Text.Json;
using Backups;

namespace BackupsExtra
{
    public class SaveFile
    {
        public void SaveRestorePoint(RestorePoint point)
        {
            using (StreamWriter file = new StreamWriter("../../../point.json"))
            {
                string json = JsonSerializer.Serialize<RestorePoint>(point);
                file.WriteLine(json);
                Console.WriteLine("Restore point's data has been saved to file");
            }
        }

        public void SaveJobObject(JobObject jobObject)
        {
            using (StreamWriter file = new StreamWriter("../../../jobObject.json"))
            {
                string json = JsonSerializer.Serialize<JobObject>(jobObject);
                file.WriteLine(json);
                Console.WriteLine("Job object's data has been saved to file");
            }
        }
    }
}