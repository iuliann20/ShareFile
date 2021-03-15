using ShareFile.TL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareFile.DAL.Repository.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(ShareFileUserDTO registerDTO);
        ShareFileUserDTO GetUserByEmail(string email);
        ShareFileUserDTO GetUserById(int id);
    }
}
