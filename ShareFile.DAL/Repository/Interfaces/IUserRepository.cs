using ShareFile.TL.DTO;

namespace ShareFile.DAL.Repository.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(ShareFileUserDTO registerDTO);
        ShareFileUserDTO GetUserByEmail(string email);
        ShareFileUserDTO GetUserById(int id);
    }
}
