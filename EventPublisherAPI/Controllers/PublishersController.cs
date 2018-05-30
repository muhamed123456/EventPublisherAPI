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
    [RoutePrefix("api/v1/publisher")]
    public class PublishersController : ApiController
    {
        private readonly PublishersBLL _evService = new PublishersBLL(
            new EventPublisherEF.DataRepository.EventRepository(new EventPublisherEF.DataAccess.DbAccess()));

        public PublishersController()
        {

        }

        //Get all publishers
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

        //Get a publisher by ID
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


        //Get a publisher by name
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

        //Get a publisher by company name 
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


        //Add new publisher
        [HttpPost]
        [Route("post")]
        public IHttpActionResult PostNewPublisher(Publisher publisher1)
        {
            try
            {
                _evService.CreatePublisher(publisher1);
                return Ok();
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.InnerException.InnerException.Message)));
            }
        }


        //Edit publisher info
        [HttpPut]
        [Route("update/{id:int}")]
        public IHttpActionResult UpdatePublisher(int id, Publisher publisher1)
        {
            try
            {
                _evService.UpdatePublisher(id, publisher1);
                return Ok();
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.InnerException.InnerException.Message)));
            }
        }


        //Delele a publisher
        [HttpDelete]
        [Route("delete/{id:int}")]
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