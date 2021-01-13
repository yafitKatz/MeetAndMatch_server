using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Bl;
using Dto;

namespace finalProject.Controllers
{
    [RoutePrefix("api/Meeting")]
    public class MeetingController : ApiController
    {
        //GetAllMeetings
        [HttpGet]
        [Route("Meetingslist")]
        public IHttpActionResult GetMeetingsByMMID(int mmId)
        {
            return Ok(MeetingBL.GetMeetingsByMMID(mmId));
        }


        //GetMeetingById
        [HttpGet]
        [Route("GetMeetingById/{mId}")]
        public IHttpActionResult GetById(int mId)
        {
            try
            {
                return Ok(MeetingBL.GetMeetingById(mId));
            }
            catch
            {
                return NotFound();
            }
        }

        //post
        [HttpPost]
        [Route("addMeeting")]
        public IHttpActionResult Post([FromBody] Meeting1 m)
        {
            try
            {
                MeetingBL.AddMeeting(m);
                return Ok();
            }
            catch
            {
                return Conflict();
            }
        }


        //UPDATE
        [HttpPut]
        [Route("updateMeeting")]
        public IHttpActionResult Put([FromBody] Meeting1 m)
        {
            try
            {
                MeetingBL.UpdateMeeting(m);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        // DELETE: api/Users/5
        [HttpPut]
        [Route("deleteMeeting/{id}")]
        public IHttpActionResult Delete(int id, [FromBody] Meeting1 m)
        {
            try
            {
                MeetingBL.DeleteMeeting(m);
                return Ok();
            }
            catch
            {
                return Conflict();
            }
        }
    }
}
