using System.Collections.Generic;

namespace GodelTech.Microservices.SharedServices.Services
{
    public interface IDirectoryService
    {
        bool Exists(string path);
        void CreateDirectory(string path);
        void DeleteAll(string path);
        IEnumerable<string> EnumerateDirectories(string path);
    }
}