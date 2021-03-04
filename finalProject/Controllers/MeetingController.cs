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
        //Get All Meetings
        [HttpGet]
        [Route("Meetingslist")]
        public IHttpActionResult GetAllMeetings()
        {
            List<Meeting1> allMeetings = MeetingBL.GetAllMeetings();
            return Ok(allMeetings);
        }


        //Get Meeting By MMId
        [HttpGet]
        [Route("GetMeetingByMM/{mmId}")]
        public IHttpActionResult GetMeetingsByMMID(int mmId)
        {
            return Ok(MeetingBL.GetMeetingsByMMID(mmId));
        }

        //Get Meeting By Id
        [HttpGet]
        [Route("GetMeeting/{mId}")]
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
                // return Ok(MeetingBL.GetMeetingsByMMID(mmId))
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
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
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
                return NotFound();
            }
        }

        // DELETE: api/Users/5
        [HttpPut]
        [Route("deleteMeeting/{mid}")]
        public IHttpActionResult Delete(int mid, [FromBody] Meeting1 m)
        {
            try
            {
                MeetingBL.DeleteMeeting(m);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return Conflict();
            }
        }
    }
}
