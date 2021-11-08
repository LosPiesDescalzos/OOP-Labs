using System.IO;

namespace Backups
{
    public class JobObject
    {
        public JobObject(string path)
        {
            Path = path;
            Data = File.ReadAllText(path);
        }

        public string Path { get; }
        public string Data { get; }
    }
}