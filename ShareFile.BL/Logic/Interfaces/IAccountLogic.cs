﻿using ShareFile.TL.DTO;

namespace ShareFile.BL.Logic.Interfaces
{
    public interface IAccountLogic
    {
        bool IsSignedIn();
        string GetCurentUserFullName();
        string EncryptPassword(string password);
        void AddToken(TokenDTO tokenDTO);
        void RemoveAllTokensByUserId(int userId);
        void Logout();
        int GetCurentUserById();
    }
}
