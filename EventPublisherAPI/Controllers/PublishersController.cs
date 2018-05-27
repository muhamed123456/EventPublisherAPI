using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventPublisherBLL;

namespace EventPublisherAPI.Controllers
{
    [RoutePrefix("api/v1/publisher")]
    public class PublishersController : ApiController
    {
        private readonly PublishersBLL _evService = new PublishersBLL(
            new EventPublisherEF.DataRepository.EventRepository(new EventPublisherEF.DataAccess.DbAccess()));

        public PublishersController()
        {

        }
        [HttpGet]
        [Route("get")]

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
        [Route("get/{id:int}")]
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
        [Route("get/name/{name}")]
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
        [Route("get/companyname/{companyName}")]
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
        [Route("post")]
        public IHttpActionResult PostNewPublisher(string name, string companyName, string email, int idCity, string phoneNumber, int idUser)
        {
            try
            {
                _evService.CreatePublisher(name, companyName, email, idCity, phoneNumber, idUser);
                return Ok();
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.InnerException.InnerException.Message)));
            }
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult UpdatePublisher(int id, string name, string companyName, string email, int idCity, string phoneNumber, int idUser)
        {
            try
            {
                _evService.UpdatePublisher(id, name, companyName, email, idCity, phoneNumber, idUser);
                return Ok();
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.InnerException.InnerException.Message)));
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IHttpActionResult DeletePublisher(int id)
        {
            try
            {
                _evService.DeletePublisher(id);
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
