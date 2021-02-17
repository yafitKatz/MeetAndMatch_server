﻿using System;
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
                return Ok(ParticipantBL.GetParticipantById(pId));
            }
            catch
            {
                return NotFound();
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
                return Ok();
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
                return Ok();
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
                ParticipantBL.DeleteParticipant(p);
                return Ok();
            }
            catch
            {
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
