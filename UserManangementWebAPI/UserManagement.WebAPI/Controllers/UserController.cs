using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UserManagement.WebAPI.Filters;
using UserManagement.WebAPI.Helpers;
using UserManagementAPI.UnitOfWork;

namespace UserManagement.WebAPI.Controllers
{
    [AuthorizationRequired]
    public class UserController : ApiController
    {
        private UnitOfWork unitOfWork;
        public UserController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // [ApiAuthenticationFilter(true)]
        //[LoggingFilter]
        //[CacheFilter.CacheFilter(Duration=300)]
        [AuthorizationRequired]
        [Route("api/user/GetUserById")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            if (id > 0)
            {
                var responseFromSwevice = await unitOfWork.UserRepository.GetById(id);
                if (responseFromSwevice != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, responseFromSwevice);
                }

               throw new ApiDataException(1001, "No User found for this id.", HttpStatusCode.NotFound);
            }
            //var responseFromSwevicee = await unitOfWork.UserRepository.GetById(id);
            //return Request.CreateResponse(HttpStatusCode.OK, responseFromSwevicee);
            throw new ApiException() { ErrorCode = (int)HttpStatusCode.BadRequest, ErrorDescription = "Bad Request..." };
        }
        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }
        public void Delete(int id)
        {
        }
    }
}
