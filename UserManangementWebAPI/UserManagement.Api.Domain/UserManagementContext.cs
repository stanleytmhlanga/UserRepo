using System.Data.Entity;
using UserManagement.Api.Domain.Models;

namespace UserManagement.Api.Domain
{
    public class UserManagementContext : DbContext
    {
        public UserManagementContext() : base("name=EDNAContext")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<LoggedInUser> LoggedInUsers { get; set; }

        public DbSet<Entity> Entities { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<TokenEntity> Tokens { get; set; }

    }
}
