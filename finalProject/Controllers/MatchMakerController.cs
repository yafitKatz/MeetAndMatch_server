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
    [RoutePrefix("api/MatchMaker")]
    public class MatchMakerController : ApiController
    {
        //login
        [HttpGet]
        [Route("Login/{mmId}/{pass}")]
        public IHttpActionResult Login(int mmId, string pass)
        {
            var mm = Bl.MatchMakerBL.Login(mmId, pass);
            if (mm != null)
                return Ok(mm);
            else
                return NotFound();
        }


        //GetMatchMakerById
        [HttpGet]
        [Route("GetMatchMakerById/{mmId}")]
        public IHttpActionResult GetById(int mmId)
        {
            try
            {
                return Ok(MatchMakerBL.GetMatchMakerById(mmId));
            }
            catch
            {
                return NotFound();
            }
        }

        //post
        [HttpPost]
        [Route("addMatchMaker")]
        public IHttpActionResult Post([FromBody] MatchMaker1 mm)
        {
            try
            {
                MatchMakerBL.AddMatchMaker(mm);
                return Ok();
            }
            catch
            {
                return Conflict();
            }
        }


        //UPDATE
        [HttpPut]
        [Route("updateMatchMaker")]
        public IHttpActionResult Put([FromBody] MatchMaker1 mm)
        {
            try
            {
                MatchMakerBL.UpdateMatchMaker(mm);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        // DELETE: api/Users/5
        [HttpPut]
        [Route("deleteMatchMaker/{id}")]
        public IHttpActionResult Delete(int id, [FromBody] MatchMaker1 mm)
        {
            try
            {
                MatchMakerBL.DeleteMatchMaker(mm);
                return Ok();
            }
            catch
            {
                return Conflict();
            }
        }
    }
}
