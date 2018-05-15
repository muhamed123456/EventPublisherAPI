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
    [RoutePrefix("api/v1/events")]
    public class EventsController : ApiController
    {
    private readonly EventsBLL _evService = new EventsBLL(
        new EventPublisherEF.DataRepository.EventRepository(new EventPublisherEF.DataAccess.DbAccess()));

    public EventsController()
    {

    }

    [HttpGet]
    [Route("event")]

    public IHttpActionResult GetEventInfo()
    {
        try
        {
            var result = _evService.GetEvents();
                return Ok(result);
        }
        catch(Exception e)
        {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.Message)));
            }
    }

        [HttpGet]
        [Route("event/{id:int}")]
        public IHttpActionResult GetEventInfoById(int id)
        {
            try
            {
                var result = _evService.GetEventsById(id);
                return Ok(result);
            }
            catch(Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.Message)));
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
                                new HttpError(e.Message)));
            }
        }

        [HttpPut]
        [Route("event/put/{id}")]
        public IHttpActionResult EditEvent(int id, [FromBody]SearchedEvents event1)
        {
            try
            {
                _evService.UpdateEvent(id, event1);
                return Ok();
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.Message)));
            }
        }

        [HttpDelete]
        [Route("event/delete/{id}")]
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
                                new HttpError(e.Message)));
            }
        }

        [HttpPost]
        [Route("event/post")]
        public IHttpActionResult PostNewEvent(int id, string name, string description, string cityName, string placeName, string typeName, System.DateTime startDate, System.DateTime endDate, bool approved)
        {
            try
            {
                _evService.CreateEvent(id, name, description, cityName, placeName, typeName, startDate, endDate, approved);
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
