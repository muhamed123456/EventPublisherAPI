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
    [RoutePrefix("api/v1/event")]
    public class EventsController : ApiController
    {
    private readonly EventsBLL _evService = new EventsBLL(
        new EventPublisherEF.DataRepository.EventRepository(new EventPublisherEF.DataAccess.DbAccess()));

    public EventsController()
    {

    }

    [HttpGet]
    [Route("get")]

    public IHttpActionResult GetEventInfo()
    {
        try
        {
            var result = _evService.GetEvents();
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
        public IHttpActionResult GetEventInfoById(int id)
        {
            try
            {
                var result = _evService.GetEventsById(id);
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
        [Route("event/{name}")]
        public IHttpActionResult GetEventInfoByName(string name)
        {
            try
            {
                var result = _evService.GetEventsByName(name);
                return Ok(result);
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.InnerException.InnerException.Message)));
            }
        }

        [HttpPut]
        [Route("put/{id}")]
        public IHttpActionResult EditEvent(int id, string name, string description, string cityName, string placeName, string typeName, System.DateTime startDate, System.DateTime endDate, bool approved)
        {
            try
            {
                _evService.UpdateEvent( id,  name,  description,  cityName,  placeName,  typeName,  startDate,  endDate,  approved);
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
        public IHttpActionResult DeleteEvent(int id)
        {
            try
            {
                _evService.DeleteEvent(id);
                return Ok();
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
        public IHttpActionResult PostNewEvent(string name, string description, int idCity, int idPlace, int idType, System.DateTime startDate, System.DateTime endDate, bool approved)
        {
            try
            {
                _evService.CreateEvent(name, description, idCity, idPlace, idType, startDate, endDate, approved);
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
