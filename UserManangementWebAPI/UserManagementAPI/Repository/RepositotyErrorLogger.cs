using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementAPI.Interfaces;

namespace UserManagementAPI.Repository
{
    public class RepositotyErrorLogger : IErrorLogger
    {
        public void LogError(Exception ex, string infoMessage)
        {
            //Log the error to your error database
            throw new NotImplementedException();
        }
    }
}
