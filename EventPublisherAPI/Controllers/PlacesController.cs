using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventPublisherBLL;

namespace EventPublisherAPI.Controllers
{
    [RoutePrefix("api/v1/places")]
    public class PlacesController : ApiController
    {
        private readonly PlacesBLL _evService = new PlacesBLL(new EventPublisherEF.DataRepository.EventRepository(new EventPublisherEF.DataAccess.DbAccess()));

        public PlacesController()
        {

        }

        [HttpGet]
        [Route("place")]
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

        [HttpGet]
        [Route("place/{id}")]
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

        [HttpPost]
        [Route("place/post")]
        public IHttpActionResult PostNewPlace(string placeName, int idCity)
        {
            try
            {
                _evService.AddPlace(placeName, idCity);
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
