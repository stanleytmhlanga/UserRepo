using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Api.Domain;
using UserManagement.Api.Domain.Models;

namespace UserManagementAPI.Repository
{
    public class GenericUserManagementRepositoty<T> where T : class
    {
        internal UserManagementContext context;
        internal readonly DbSet<T> dbSet;
      
        public GenericUserManagementRepositoty(UserManagementContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public async virtual Task<T> GetById(object id)
        {
            return  dbSet.Find(id);
        }

        public  virtual LoggedInUser Get(Expression<Func<T, bool>> predicate)
        {
            //var context.Set<T>().Where(predicate);
            var user =dbSet.Where(predicate).FirstOrDefault();

            return user as LoggedInUser;
        }

        public virtual TokenEntity GetToken(Expression<Func<T, bool>> predicate)
        {
            //var context.Set<T>().Where(predicate);
            var token = dbSet.Where(predicate).FirstOrDefault();

            return token as TokenEntity;
        }

        public virtual TokenEntity Delete(Expression<Func<TokenEntity, bool>> entityToDelete)
        {
            var db = dbSet.Find(entityToDelete);

            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(db);
            }

            dbSet.Remove(db);
            return new TokenEntity();

        }

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delet(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }

            dbSet.Remove(entityToDelete);
        }


        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
