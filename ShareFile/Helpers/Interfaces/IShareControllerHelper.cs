using ShareFile.Models;
using ShareFile.TL.DTO;
using System.Collections.Generic;

namespace ShareFile.Helpers.Interfaces
{
    public interface IShareControllerHelper
    {
        List<SharedFileViewModel> BuildViewModel(List<SharedFileDTO> sharedFileDTOs);
        SharedFileViewModel BuildViewModel(SharedFileDTO sharedFileDTO);
        SharedFileDTO BuildDTO(SharedFileViewModel sharedFileViewModel);

        string FormatSize(long bytes);
    }


}