using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementAPI.Interfaces;

namespace UserManagementAPI.Repository
{
    public class RepositoryUserServices : IUserServices
    {
        private readonly  UnitOfWork.UnitOfWork unitOfWork;

        public RepositoryUserServices(UnitOfWork.UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public int Authenticate(string userName, string password)
        {
            var user = unitOfWork.LoggedInUserRepository.Get(u => u.UserName == userName && u.Password == password);
            if (user != null && user.UserId > 0)
            {
                return user.UserId;
            }
            return 0;
        }
    }
}
