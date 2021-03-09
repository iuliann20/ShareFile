using ShareFile.DAL.Entities;
using ShareFile.DAL.Repository.Interfaces;
using ShareFile.TL.DTO;
using System.Collections.Generic;
using System.Linq;

namespace ShareFile.DAL.Repository.Classes
{
    public class FileRepository : IFileRepository
    {
        private readonly ShareFileDbContext _shareFileDbContext;
        public FileRepository(ShareFileDbContext shareFileDbContext)
        {
            _shareFileDbContext = shareFileDbContext;
        }


        public void AddFile(SharedFileDTO sharedFileDTO)
        {
            _shareFileDbContext.Files.Add(new SharedFile
            {
                FileName = sharedFileDTO.FileName,
                FileSize = sharedFileDTO.FileSize,
                UploadDate = sharedFileDTO.UploadDate
            });
            _shareFileDbContext.SaveChanges();
        }

        public void RemoveFile(int id)
        {
            SharedFile fileFromDb = _shareFileDbContext.Files.FirstOrDefault(x => x.Id == id);
            if (fileFromDb != null)
            {
                _shareFileDbContext.Files.Remove(fileFromDb);
                _shareFileDbContext.SaveChanges();
            }
        }

        public void UpdateFile(SharedFileDTO sharedFileDTO)
        {
            SharedFile fileFromDb = _shareFileDbContext.Files.FirstOrDefault(x => x.Id == sharedFileDTO.Id);
            if (fileFromDb != null)
            {
                fileFromDb.FileName = !string.IsNullOrEmpty(sharedFileDTO.FileName) ? sharedFileDTO.FileName : fileFromDb.FileName;
                _shareFileDbContext.SaveChanges();
            }
        }
        public List<SharedFileDTO> GetAllFiles()
        {
            return _shareFileDbContext.Files
              .Select(file => new SharedFileDTO
              {
                  Id = file.Id,
                  FileName = file.FileName,
                  FileSize = file.FileSize,
                  UploadDate = file.UploadDate
              }).ToList();

        }

        public SharedFileDTO GetFileById(int id)
        {
            SharedFile fileFromDb = _shareFileDbContext.Files.FirstOrDefault(x => x.Id == id);
            if (fileFromDb != null)
            {
                return new SharedFileDTO
                {
                    FileName = fileFromDb.FileName,
                    FileSize = fileFromDb.FileSize,
                    UploadDate = fileFromDb.UploadDate
                };
            }
            return null;
        }
    }
}
