using ShareFile.TL.DTO;
using ShareFile.TL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareFile.BL.Logic.Interfaces
{
    public interface IUserLogic
    {
        Response AddUser(ShareFileUserDTO registerDTO, string rePassword);
    }
}
