using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Api.Domain;
using UserManagement.Api.Domain.Models;
using UserManagementAPI.Repository;

namespace UserManagementAPI.UnitOfWork
{
 
    public class UnitOfWork : IDisposable
    {
        private UserManagementContext context = new UserManagementContext();
        private GenericUserManagementRepositoty<User> userRepository;
        private GenericUserManagementRepositoty<LoggedInUser> loggedInUserRepository;
        private GenericUserManagementRepositoty<TokenEntity> tokenRepository;
       


        public GenericUserManagementRepositoty<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericUserManagementRepositoty<User>(context);
                }

                return userRepository;
            }
        }

        public GenericUserManagementRepositoty<LoggedInUser> LoggedInUserRepository
        {
            get
            {
                if (this.loggedInUserRepository == null)
                {
                    this.loggedInUserRepository = new GenericUserManagementRepositoty<LoggedInUser>(context);
                }

                return loggedInUserRepository;
            }
        }

        public GenericUserManagementRepositoty<TokenEntity> TokenRepository
        {
            get
            {
                if (this.tokenRepository == null)
                {
                    this.tokenRepository = new GenericUserManagementRepositoty<TokenEntity>(context);
                }

                return tokenRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
