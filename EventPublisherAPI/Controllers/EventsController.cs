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

    //Get all events
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

        //Get event by ID
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


        //Search Events by City
        [HttpGet]
        [Route("event/city/{city}")]
        public IHttpActionResult GetEventInfoByCity(string city)
        {
            try
            {
                var result = _evService.GetEventsByCity(city);
                return Ok(result);
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.InnerException.InnerException.Message)));
            }
        }


        //Search Events by Type
        [HttpGet]
        [Route("event/type/{type}")]
        public IHttpActionResult GetEventInfoByType(string type)
        {
            try
            {
                var result = _evService.GetEventsByType(type);
                return Ok(result);
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.InnerException.InnerException.Message)));
            }
        }

        //Add new Event
        [HttpPost]
        [Route("post")]
        public IHttpActionResult PostNewEvent(Event event1)
        {
            try
            {
                _evService.CreateEvent(event1);
                return Ok();
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.InnerException.InnerException.Message)));
            }
        }


        //Edit an Event
        [HttpPut]
        [Route("put/{id:int}")]
        public IHttpActionResult EditEvent(int id, Event event1)
        {
            try
            {
                _evService.UpdateEvent( id, event1);
                return Ok();
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.InnerException.InnerException.Message)));
            }
        }


        //Delete an Event
        [HttpDelete]
        [Route("delete/{id:int}")]
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
    }
}
