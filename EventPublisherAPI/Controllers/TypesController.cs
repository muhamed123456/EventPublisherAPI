using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventPublisherBLL;

namespace EventPublisherAPI.Controllers
{
    [RoutePrefix("api/v1/types")]
    public class TypesController : ApiController
    {
        private readonly TypesBLL _evService = new TypesBLL(
            new EventPublisherEF.DataRepository.EventRepository(new EventPublisherEF.DataAccess.DbAccess()));

        public TypesController()
        {

        }

        [HttpGet]
        [Route("type")]

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
        [Route("type/{id=int}")]

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
        [Route("type/post")]
        public IHttpActionResult PostNewType(int id, string type)
        {
            try
            {
                _evService.AddType(id, type);
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
