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
    [RoutePrefix("api/v1/attendance")]
    public class AttendancesController : ApiController
    {
        private readonly AttendancesBLL _evService = new AttendancesBLL(
            new EventPublisherEF.DataRepository.EventRepository(new EventPublisherEF.DataAccess.DbAccess()));


        public AttendancesController()
        {

        }


        //Get Attendances info
        [HttpGet]
        [Route("get")]
        public IHttpActionResult GetAttendanceInfo()
        {
            try
            {
                var result = _evService.GetAttendanceInfo();
                return Ok(result);
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                            Request.CreateErrorResponse((HttpStatusCode)500,
                                new HttpError(e.InnerException.InnerException.Message)));
            }
        }


        //Get Attendance info by ID
        [HttpGet]
        [Route("get/{id:int}")]
        public IHttpActionResult GetAttendanceInfoById(int id)
        {
            try
            {
                var result = _evService.GetAttendanceInfoById(id);
                return Ok(result);
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
