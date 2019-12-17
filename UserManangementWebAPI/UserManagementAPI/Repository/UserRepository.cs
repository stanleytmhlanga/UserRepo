using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Api.Domain;
using UserManagement.Api.Domain.Models;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Repository;

namespace UserManagement.API.Repositories
{
    public class UserRepository : RepositoryClient, IUser
    {
        private UserManagementContext context;

        public UserRepository(UserManagementContext context,ICacheService cache, IDeserializer serializer, IErrorLogger errorLogger)
            : base(cache, serializer, errorLogger, "https://localhost:44327/api/") 
        {
            this.context = context;
        }
        //public UserRepository(UserManagementContext context)
        //{
        //    this.context = context;
        //}
        public void Delete(int userid)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetById(int userid)
        {
            //var client = User(userid);
            //RestRequest request = new RestRequest(Method.GET);
            //request = context.Users.Find(userid);
            //var d = GetFromCache<User>(request, "User" + userid.ToString());
            return  context.Users.Find(userid); 
        }


        //public async Task<IRestResponse> GetByIddd(int userid)
        //{
        //    var client = new RestClient("https://localhost:44327/api/");
        //    RestRequest request = new RestRequest("values/{id}", Method.GET);
        //    request.AddUrlSegment("id", userid.ToString());
        //    //var d = GetFromCache<User>(request, "User" + userid.ToString());
        //    //return context.Users.Find(userid);
        //    // var client = new RestClient().Execute()

        //    var responses = Execute<User>(request);

        //    IRestResponse response = client.Execute(request);

        //    return response;
        //}
        public async Task<User> User(int userid)
        {
            return context.Users.Find(userid); 
        }

        public Task<IEnumerable<User>> GetUsersMovies()
        {
            throw new NotImplementedException();
        }

        public void Insert(User user)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public Task<User> SearchMovieById(string parm)
        {
            throw new NotImplementedException();
        }

        public Task<User> SearchMovies(string parm)
        {
            throw new NotImplementedException();
        }

        public Task<User> SearchMoviesByTitle(string parm)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
