using Backups;

namespace BackupsExtra
{
    public interface IChangeLocation
    {
        void Restore(RestorePoint point, string path);
    }
}