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


        //Get all cities
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


        //Get a city by ID
        [HttpGet]
        [Route("get/{id:int}")]
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


        //Add new city
        [HttpPost]
        [Route("post")]
        public IHttpActionResult PostNewCity(City city1)
        {
            try
            {
                _evService.AddCity(city1);
                return Ok();
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.InnerException.InnerException.Message)));
            }
        }


        //Delete a city
        [HttpDelete]
        [Route("delete/{id:int}")]
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
