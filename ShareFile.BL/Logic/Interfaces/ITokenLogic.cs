using ShareFile.TL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareFile.BL.Logic.Interfaces
{
    public interface ITokenLogic
    {
        TokenDTO GetTokenByValue(string tokenValue);
        void RemoveTokenById(int id);
    }
}
