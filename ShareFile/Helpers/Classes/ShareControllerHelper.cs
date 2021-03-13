using ShareFile.Helpers.Interfaces;
using ShareFile.Models;
using ShareFile.TL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShareFile.Helpers.Classes
{

    public class ShareControllerHelper : IShareControllerHelper
    {
        private static readonly string[] SUFFIXES = { "Bytes", "KB", "MB", "GB", "TB", "PB" };

        public List<SharedFileViewModel> BuildViewModel(List<SharedFileDTO> sharedFileDTOs)
        {
            return sharedFileDTOs.Select(sharedFileDTO => new SharedFileViewModel
            {
                Id = sharedFileDTO.Id,
                FileName = sharedFileDTO.FileName,
                FileSize = sharedFileDTO.FileSize,
                UploadDate = sharedFileDTO.UploadDate
            }).ToList();
        }

        public SharedFileViewModel BuildViewModel(SharedFileDTO sharedFileDTO)
        {
            return new SharedFileViewModel
            {
                Id = sharedFileDTO.Id,
                FileName = sharedFileDTO.FileName,
                FileSize = sharedFileDTO.FileSize,
                UploadDate = sharedFileDTO.UploadDate
            };
        }

        public SharedFileDTO BuildDTO(SharedFileViewModel sharedFileViewModel)
        {
            return new SharedFileDTO
            {
                Id = sharedFileViewModel.Id,
                FileName = sharedFileViewModel.FileName,
                FileSize = sharedFileViewModel.FileSize,
                UploadDate = sharedFileViewModel.UploadDate
            };
        }
        public string FormatSize(long bytes)
        {
            int counter = 0;
            decimal number = bytes;
            while (Math.Round(number / 1024) >= 1)
            {
                number /= 1024;
                counter++;
            }

            return $"{number:n1} {SUFFIXES[counter]}";
        }


    }
}
