using ShareFile.TL.DTO;
using ShareFile.TL.Helpers;

namespace ShareFile.BL.Logic.Interfaces
{
    public interface IUserLogic
    {
        Response AddUser(ShareFileUserDTO registerDTO, string rePassword);
    }
}
