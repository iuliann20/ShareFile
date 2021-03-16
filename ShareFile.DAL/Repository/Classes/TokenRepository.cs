using ShareFile.DAL.Entities;
using ShareFile.DAL.Repository.Interfaces;
using ShareFile.TL.DTO;
using System.Collections.Generic;
using System.Linq;

namespace ShareFile.DAL.Repository.Classes
{
    public class TokenRepository : ITokenRepository
    {
        private readonly ShareFileDbContext _shareFileDbContext;

        public TokenRepository(ShareFileDbContext shareFileDbContext)
        {
            _shareFileDbContext = shareFileDbContext;
        }
        public void AddToken(TokenDTO tokenDTO)
        {
            _shareFileDbContext.AccessTokens.Add(new Token
            {
                AccessToken = tokenDTO.AccessToken,
                ExpirationDate = tokenDTO.ExpirationDate,
                TokenId = tokenDTO.TokenId,
                UserId = tokenDTO.UserId
            });
            _shareFileDbContext.SaveChanges();
        }

        public TokenDTO GetTokenByValue(string tokenValue)
        {
            Token tokenFromDb = _shareFileDbContext.AccessTokens.FirstOrDefault(x => x.AccessToken == tokenValue);
            if (tokenFromDb == null)
            {
                return null;
            }
            return new TokenDTO
            {
                TokenId = tokenFromDb.TokenId,
                AccessToken = tokenFromDb.AccessToken,
                ExpirationDate = tokenFromDb.ExpirationDate,
                UserId = tokenFromDb.UserId
            };
        }

        public void RemoveTokenById(int id)
        {
            Token tokenFromDb = _shareFileDbContext.AccessTokens.FirstOrDefault(x => x.TokenId == id);
            if (tokenFromDb != null)
            {
                _shareFileDbContext.AccessTokens.Remove(tokenFromDb);
                _shareFileDbContext.SaveChanges();
            }
        }
        public void RemoveAllTokensByUserId(int userId)
        {
            List<Token> tokensUser = _shareFileDbContext.AccessTokens.Where(x => x.UserId == userId).ToList();
            foreach (Token tokenUser in tokensUser)
            {
                if (tokenUser != null)
                {
                    RemoveTokenById(tokenUser.TokenId);
                }
            }
        }
    }
}
