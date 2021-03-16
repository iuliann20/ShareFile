﻿using ShareFile.BL.Logic.Interfaces;
using ShareFile.DAL.Repository.Interfaces;
using ShareFile.TL.DTO;
using ShareFile.TL.Helpers;

namespace ShareFile.BL.Logic.Classes
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;
        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Response AddUser(ShareFileUserDTO registerDTO, string rePassword)
        {
            if (_userRepository.GetUserByEmail(registerDTO.Email) != null)
            {
                return new Response
                {
                    IsCompletedSuccesfuly = false,
                    ResponseMessage = "A user with the same email already exists!"
                };
            }
            if (!registerDTO.Password.Equals(rePassword))
            {
                return new Response
                {
                    IsCompletedSuccesfuly = false,
                    ResponseMessage = "Passwords doesn't match!"
                };
            }
            _userRepository.AddUser(registerDTO);
            return new Response
            {
                IsCompletedSuccesfuly = true,
                ResponseMessage = "User added succesfuly!"
            };
        }
        public ShareFileUserDTO GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }
        public string GetFullName(int id)
        {
            ShareFileUserDTO userDTO = _userRepository.GetUserById(id);
            return $"{userDTO.FirstName} {userDTO.LastName}";
        }

    }
}
