using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bl;
using Dto;

namespace finalProject.Controllers
{
    [RoutePrefix("api/Participant")]
    public class ParticipantController : ApiController
    {
        //GetAllParticipants
        [HttpGet]
        [Route("Participantslist")]
        public IHttpActionResult GetAllParticipants()
        {
            return Ok(ParticipantBL.GetAllParticipants());
        }


        //GetParticipantById
        [HttpGet]
        [Route("GetParticipantById/{pId}")]
        public IHttpActionResult GetById(int pId)
        {
            try
            {
                Participant1 participant = ParticipantBL.GetParticipantById(pId);
                if (participant != null)
                {
                    return Ok(ParticipantBL.GetParticipantById(pId));
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
                return Conflict();
            }
            
        }

        //post
        [HttpPost]
        [Route("addParticipant")]
        public IHttpActionResult Post([FromBody] Participant1 p)
        {
            try
            {
                ParticipantBL.AddParticipant(p);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
                return Conflict();
            }
        }


        //UPDATE
        [HttpPut]
        [Route("updateParticipant")]
        public IHttpActionResult Put([FromBody] Participant1 p)
        {
            try
            {
                ParticipantBL.UpdateParticipant(p);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch
            {
                return NotFound();
            }
        }

        // DELETE: api/Users/5
        [HttpPut]
        [Route("deleteParticipant/{id}")]
        public IHttpActionResult Delete(int id, [FromBody] Participant1 p)
        {
            try
            {
                MeetingBL.DeleteParticipantsMeetings(p);
                ParticipantBL.DeleteParticipant(p);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return Conflict();
            }
        }

        //GetAllAbandonedParticipants
        [HttpGet]
        [Route("statistics")]
        public IHttpActionResult GetAllAbandonedParticipants()
        {
            try
            {
                return Ok(ParticipantBL.GetAllAbandonedParticipants());
            }
            catch
            {
                return Conflict();
            }
        }
    }
}
