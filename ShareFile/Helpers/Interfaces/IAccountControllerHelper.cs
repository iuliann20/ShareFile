using ShareFile.Models;
using ShareFile.TL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareFile.Helpers.Interfaces
{
    public interface IAccountControllerHelper
    {
        ShareFileUserDTO BuildDTO(RegisterViewModel registerViewModel);
    }
}
