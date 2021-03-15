using ShareFile.Models;
using ShareFile.TL.DTO;

namespace ShareFile.Helpers.Interfaces
{
    public interface IAccountControllerHelper
    {
        ShareFileUserDTO BuildDTO(RegisterViewModel registerViewModel);
    }
}
