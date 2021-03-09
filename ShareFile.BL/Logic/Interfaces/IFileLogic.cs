using ShareFile.TL.DTO;
using System.Collections.Generic;

namespace ShareFile.BL.Logic.Interfaces
{
    public interface IFileLogic
    {
        void AddFile(SharedFileDTO sharedFileDTO);
        void RemoveFile(int id);
        void UpdateFile(SharedFileDTO sharedFileDTO);
        List<SharedFileDTO> GetAllFiles();
        SharedFileDTO GetFileById(int id);
    }
}
