using ShareFile.DAL.Entities;
using ShareFile.DAL.Repository.Interfaces;
using ShareFile.TL.DTO;
using System.Linq;

namespace ShareFile.DAL.Repository.Classes
{
    public class UserRepository : IUserRepository
    {
        private readonly ShareFileDbContext _shareFileDbContext;
        public UserRepository(ShareFileDbContext shareFileDbContext)
        {
            _shareFileDbContext = shareFileDbContext;
        }
        public void AddUser(ShareFileUserDTO registerDTO)
        {
            _shareFileDbContext.Users.Add(new SharedFileUser
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                BirthDay = registerDTO.BirthDay,
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumber,
                Password = registerDTO.Password
            });
            _shareFileDbContext.SaveChanges();
        }
        public ShareFileUserDTO GetUserByEmail(string email)
        {
            SharedFileUser userFromDb = _shareFileDbContext.Users.FirstOrDefault(x => x.Email == email);
            if (userFromDb == null)
            {
                return null;
            }
            return new ShareFileUserDTO
            {
                UserId = userFromDb.UserId,
                FirstName = userFromDb.FirstName,
                LastName = userFromDb.LastName,
                BirthDay = userFromDb.BirthDay,
                Email = userFromDb.Email,
                PhoneNumber = userFromDb.PhoneNumber,
                Password = userFromDb.Password
            };
        }
        public ShareFileUserDTO GetUserById(int id)
        {
            SharedFileUser userFromDb = _shareFileDbContext.Users.FirstOrDefault(x => x.UserId == id);
            if (userFromDb == null)
            {
                return null;
            }
            return new ShareFileUserDTO
            {
                UserId = userFromDb.UserId,
                FirstName = userFromDb.FirstName,
                LastName = userFromDb.LastName,
                BirthDay = userFromDb.BirthDay,
                Email = userFromDb.Email,
                PhoneNumber = userFromDb.PhoneNumber,
                Password = userFromDb.Password
            };
        }
    }
}
