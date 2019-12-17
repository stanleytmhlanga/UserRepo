using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Api.Domain.Models;

namespace UserManagementAPI.Interfaces
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetUsersMovies();
        void Update(User user);
        void Insert(User user);
        void Delete(int userid);
        //Task<IRestResponse> GetByIddd(int userid);
        Task<User> GetById(int userid);
        //Task<IRestResponse> GetFromServiceById(string parm);
        Task<User> SearchMovieById(string parm);
        Task<User> SearchMovies(string parm);
        Task<User> SearchMoviesByTitle(string parm);
        void Save();
    }
}
