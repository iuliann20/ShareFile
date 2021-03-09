using ShareFile.BL.Logic.Interfaces;
using ShareFile.DAL.Repository.Interfaces;
using ShareFile.TL.DTO;
using System.Collections.Generic;

namespace ShareFile.BL.Logic.Classes
{
    public class FileLogic : IFileLogic
    {
        private readonly IFileRepository _fileRepository;
        public FileLogic(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        public void AddFile(SharedFileDTO sharedFileDTO)
        {
            _fileRepository.AddFile(sharedFileDTO);

        }
        public void RemoveFile(int id)
        {
            if (id <= 0)
            {
                return;
            }
            _fileRepository.RemoveFile(id);
        }
        public void UpdateFile(SharedFileDTO sharedFileDTO)
        {
            if (sharedFileDTO.Id <= 0)
            {
                return;
            }
            _fileRepository.UpdateFile(sharedFileDTO);
        }
        public List<SharedFileDTO> GetAllFiles()
        {
            return _fileRepository.GetAllFiles();
        }
        public SharedFileDTO GetFileById(int id)
        {
            if (id > 0)
            {
                return _fileRepository.GetFileById(id);
            }
            return null;

        }


    }
}
