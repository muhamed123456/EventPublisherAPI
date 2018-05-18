using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventPublisherBLL;

namespace EventPublisherAPI.Controllers
{
    [RoutePrefix("api/v1/publishers")]
    public class PublishersController : ApiController
    {
        private readonly PublishersBLL _evService = new PublishersBLL(
            new EventPublisherEF.DataRepository.EventRepository(new EventPublisherEF.DataAccess.DbAccess()));

        public PublishersController()
        {

        }
        [HttpGet]
        [Route("publisher")]

        public IHttpActionResult GetPublishersInfo()
        {
            try
            {
                var result = _evService.GetPublishersInfo();
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
        [Route("publisher/id/{id=int}")]
        public IHttpActionResult GetPublisherInfoByID(int id)
        {
            try
            {
                var result = _evService.GetPublisherInfoByID(id);
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
        [Route("publisher/name/{name}")]
        public IHttpActionResult GetPublisherInfoByName(string name)
        {
            try
            {
                var result = _evService.GetPublisherInfoByName(name);
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
        [Route("publisher/companyname/{companyName}")]
        public IHttpActionResult GetPublisherInfoByCompanyName(string companyName)
        {
            try
            {
                var result = _evService.GetPublisherInfoByCompanyName(companyName);
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
        [Route("publisher/post")]
        public IHttpActionResult PostNewPublisher(int id, string name, string companyName, string email, int idCity, string phoneNumber, string idUser)
        {
            try
            {
                _evService.CreatePublisher(id, name, companyName, email, idCity, phoneNumber, idUser);
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
