using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventPublisherBLL;

namespace EventPublisherAPI.Controllers
{
    [RoutePrefix("api/v1/type")]
    public class TypesController : ApiController
    {
        private readonly TypesBLL _evService = new TypesBLL(
            new EventPublisherEF.DataRepository.EventRepository(new EventPublisherEF.DataAccess.DbAccess()));

        public TypesController()
        {

        }

        [HttpGet]
        [Route("get")]

        public IHttpActionResult GetTypeInfo()
        {
            try
            {
                var result = _evService.GetTypeInfo();
                return Ok(result);
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.InnerException.InnerException.Message)));
            }
        }

        [HttpGet]
        [Route("get/{id:int}")]

        public IHttpActionResult GetTypeInfoById(int id)
        {
            try
            {
                var result = _evService.GetTypeInfoById(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.InnerException.InnerException.Message)));
            }
        }


        [HttpPost]
        [Route("post")]
        public IHttpActionResult PostNewType(string type)
        {
            try
            {
                _evService.AddType(type);
                return Ok();
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.InnerException.InnerException.Message)));
            }
        }
    }
}
