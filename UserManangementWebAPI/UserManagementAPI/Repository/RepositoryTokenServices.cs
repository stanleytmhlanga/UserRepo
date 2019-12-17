using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Api.Domain.Models;
using UserManagementAPI.Interfaces;

namespace UserManagementAPI.Repository
{
    public class RepositoryTokenServices : ITokenServices
    {
        private UnitOfWork.UnitOfWork unitOfWork;

        public RepositoryTokenServices(UnitOfWork.UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public bool DeleteByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public TokenEntity GenerateToken(int userId)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddSeconds(
                                              Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
            var tokendomain = new TokenEntity
            {
                UserID = userId,
                Token = Guid.Parse(token),
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn
            };

            unitOfWork.TokenRepository.Insert(tokendomain);
            unitOfWork.Save();
            var tokenModel = new TokenEntity()
            {
                UserID = userId,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn,
                Token = Guid.Parse(token)
            };

            return tokenModel;
        }

        public bool Kill(string tokenId)
        {
            //unitOfWork.TokenRepository.Delete(x => x.AuthToken == tokenId);
            //unitOfWork.Save();
            //var isNotDeleted = unitOfWork.TokenRepository.GetMany(x => x.AuthToken == tokenId).Any();
            //if (isNotDeleted) { return false; }
            return true;
        }

        public bool ValidateToken(string tokenId)
        {
            var token = unitOfWork.TokenRepository.GetToken(t => t.Token == Guid.Parse(tokenId) && t.ExpiresOn > DateTime.Now);
            if (token != null && !(DateTime.Now > token.ExpiresOn))
            {
                token.ExpiresOn = token.ExpiresOn.AddSeconds(
                                              Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
                unitOfWork.TokenRepository.Update(token);
                unitOfWork.Save();
                return true;
            }
            return false;
        }
    }
}
