using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventPublisherBLL;
using EventPublisherEF.Contracts;
using EventPublisherEF;

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


        //Get all types
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


        //Get a type by ID
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


        //Add new type
        [HttpPost]
        [Route("post")]
        public IHttpActionResult PostNewType(EventPublisherEF.Type type1)
        {
            try
            {
                _evService.AddType(type1);
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
