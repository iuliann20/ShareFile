using ShareFile.Helpers.Interfaces;
using ShareFile.Models;
using ShareFile.TL.DTO;
using System.Collections.Generic;
using System.Linq;

namespace ShareFile.Helpers.Classes
{
    public class ShareControllerHelper : IShareControllerHelper
    {
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
                FileName = sharedFileDTO.FileName,
                FileSize = sharedFileDTO.FileSize,
                UploadDate = sharedFileDTO.UploadDate
            };
        }

        public SharedFileDTO BuildDTO(SharedFileViewModel sharedFileViewModel)
        {
            return new SharedFileDTO
            {
                FileName = sharedFileViewModel.FileName,
                FileSize = sharedFileViewModel.FileSize,
                UploadDate = sharedFileViewModel.UploadDate
            };
        }
    }
}
