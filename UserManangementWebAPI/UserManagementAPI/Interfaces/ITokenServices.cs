using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Api.Domain.Models;

namespace UserManagementAPI.Interfaces
{
    public interface  ITokenServices
    {
        TokenEntity GenerateToken(int userId);
        bool ValidateToken(string tokenId);
        bool Kill(string tokenId);
        bool DeleteByUserId(int userId);

    }
}
