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
    [RoutePrefix("api/v1/place")]
    public class PlacesController : ApiController
    {
        private readonly PlacesBLL _evService = new PlacesBLL(new EventPublisherEF.DataRepository.EventRepository(new EventPublisherEF.DataAccess.DbAccess()));

        public PlacesController()
        {

        }


        //Get all places
        [HttpGet]
        [Route("get")]
        public IHttpActionResult GetPlaceInfo()
        {
            try
            {
                var result = _evService.GetAllPlaces();
                return Ok(result);
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.InnerException.InnerException.Message)));
            }
        }
        

        //Get a place by ID
        [HttpGet]
        [Route("get/{id:int}")]
        public IHttpActionResult GetPlacesByID(int id)
        {
            try
            {
                var result = _evService.GetPlaceByID(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.InnerException.InnerException.Message)));
            }
        }


        //Add new place
        [HttpPost]
        [Route("post")]
        public IHttpActionResult PostNewPlace(Place place1)
        {
            try
            {
                _evService.AddPlace(place1);
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
