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
    [RoutePrefix("api/v1/city")]
    public class CitiesController : ApiController
    {
        private readonly CitiesBLL _evService = new CitiesBLL(
       new EventPublisherEF.DataRepository.EventRepository(new EventPublisherEF.DataAccess.DbAccess()));

        public CitiesController()
        {

        }

        [HttpGet]
        [Route("get")]
        public IHttpActionResult GetCityInfo()
        {
            try
            {
                var result = _evService.GetCityInfo();
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
        [Route("get/{id}")]
        public IHttpActionResult GetCityInfoByID(int id)
        {
            try
            {
                var result = _evService.GetCityByID(id);
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
        public IHttpActionResult PostNewCity(string Name)
        {
            try
            {
                _evService.AddCity(Name);
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
        public IHttpActionResult DeleteCity(int id)
        {
            try
            {
                _evService.DeleteCity(id);
                return Ok();
            }
            catch(Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.InnerException.InnerException.Message)));
            }
        }


        

    }
}
