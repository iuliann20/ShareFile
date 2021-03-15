using ShareFile.TL.DTO;
using System.Collections.Generic;

namespace ShareFile.DAL.Repository.Interfaces
{
    public interface IFileRepository
    {
        void AddFile(SharedFileDTO sharedFileDTO);
        void RemoveFile(int id);
        void UpdateFile(SharedFileDTO sharedFileDTO);
        List<SharedFileDTO> GetAllFiles();
        SharedFileDTO GetFileById(int id);
        bool CheckIfFileExistInDbByName(string name);
        
    }
}
