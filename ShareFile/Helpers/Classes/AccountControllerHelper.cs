﻿using ShareFile.Helpers.Interfaces;
using ShareFile.Models;
using ShareFile.TL.DTO;

namespace ShareFile.Helpers.Classes
{
    public class AccountControllerHelper : IAccountControllerHelper
    {
        public ShareFileUserDTO BuildDTO(RegisterViewModel registerViewModel)
        {
            return new ShareFileUserDTO
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                BirthDay = registerViewModel.BirthDay,
                PhoneNumber = registerViewModel.PhoneNumber,
                UserId = registerViewModel.UserId,
                Password = registerViewModel.Password,
                Email = registerViewModel.Email

            };
        }

    }
}
