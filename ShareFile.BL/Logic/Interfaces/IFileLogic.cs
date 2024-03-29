﻿using Microsoft.AspNetCore.Http;
using ShareFile.TL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShareFile.BL.Logic.Interfaces
{
    public interface IFileLogic
    {
        string AddFile(SharedFileDTO sharedFileDTO);
        void RemoveFile(int id);
        string UpdateFile(SharedFileDTO sharedFileDTO, bool hasNameChanged);
        List<SharedFileDTO> GetAllFiles();
        SharedFileDTO GetFileById(int id);
        Task UploadFileOnDiskAsync(string uploads, IFormFile file, string fileName);
        void DeleteFileOnDisk(int id, string uploads);
        string DownloadFileAsync(int id, string uploads);
        void ReplaceFileOnDisk(IFormFile file, string uploads, bool hasNameChanged, string oldFileName);
        List<SharedFileDTO> GetAllFilesByUserId(int id);

    }
}
