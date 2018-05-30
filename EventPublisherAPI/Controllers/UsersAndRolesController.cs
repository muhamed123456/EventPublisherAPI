using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventPublisherBLL;
using EventPublisherEF;
using EventPublisherEF.Contracts;

namespace EventPublisherAPI.Controllers
{
    [RoutePrefix("api/v1/usersandroles")]
    public class UsersAndRolesController : ApiController
    {
        private readonly UsersBLL _evService = new UsersBLL(
           new EventPublisherEF.DataRepository.EventRepository(new EventPublisherEF.DataAccess.DbAccess()));

        private readonly PublishersBLL _evServiceRole = new PublishersBLL(
           new EventPublisherEF.DataRepository.EventRepository(new EventPublisherEF.DataAccess.DbAccess()));
        private EventPublisherDBEntities _dbContext;

        public UsersAndRolesController()
        {

        }

        [HttpPost]
        [Route("adduser")]
        public IHttpActionResult AddNewUser(User user)
        {
            try
            {
                _evService.AddUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                       Request.CreateErrorResponse((HttpStatusCode)500,
                           new HttpError(ex.InnerException.InnerException.Message)));
            }
        }

        [HttpPost]
        [Route("addrole")]
        [CustomAuthorize]
        public IHttpActionResult AddNewRole(string Role)
        {
            try
            {
                _evServiceRole.CreateRoles(Role);
                return Ok();
            }
            catch (Exception ex)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                       Request.CreateErrorResponse((HttpStatusCode)500,
                           new HttpError(ex.InnerException.InnerException.Message)));
            }
        }

        [HttpPost]
        [Route("token")]
        public IHttpActionResult Token(string userName, string password)
        {
          string passwordMd5 = Crypto.CreateMD5(password);

          var myUser =  _evService.GetUserAndRoles(userName, passwordMd5);

            var userToken = new UserToken();
            if (myUser != null)
            {
                userToken.UserID = myUser.UserID;
                userToken.Role = myUser.Role;                
                userToken.UserName = myUser.UserName;
                userToken.Token = CreateToken(myUser);
                return Ok(userToken);
            } 
            return Unauthorized();
        }

        private string CreateToken(UsersAndRoles usersAndRoles)
        {
            string tokenFirstPart = usersAndRoles.UserID + "|" + usersAndRoles.UserName + "|" + usersAndRoles.Password + "|" + usersAndRoles.Role + "|";
            string tokenWithMd5 = tokenFirstPart + "^" + Crypto.CreateMD5(tokenFirstPart);
            string finalToken = Crypto.EncodeTo64(tokenWithMd5);
            usersAndRoles.Token = finalToken;
            return finalToken;
        }
    }
}
