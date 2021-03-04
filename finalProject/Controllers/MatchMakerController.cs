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
    [RoutePrefix("api/MatchMaker")]
    public class MatchMakerController : ApiController
    {
        //login
        [HttpGet]
        [Route("Login/{email}/{pass}")]
        public IHttpActionResult Login(string email, string pass)
        {
            try
            {
                var mm = Bl.MatchMakerBL.Login(email, pass);
                if (mm != null)
                    return Ok(mm);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return Conflict();
            }
        }

        //GetUnapprovedMatchmakers
        [HttpGet]
        [Route("GetUnapprovedMM")]
        public IHttpActionResult GetUnapprovedMM()
        {
            try
            {
                return Ok(MatchMakerBL.GetUnapprovedMM());
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }


        //GetMatchMakerById
        [HttpGet]
        [Route("GetMatchMakerById/{mmId}")]
        public IHttpActionResult GetById(int mmId)
        {
            try
            {
                return Ok(Bl.MatchMakerBL.GetMatchMakerById(mmId));
            }
            catch(Exception e)
            {
                return NotFound();
            }
        }

        // ApproveMatchmaker
        [HttpGet]
        [Route("ApproveMatchmaker/{mmId}")]
        public IHttpActionResult ApproveMM(int mmId)
        {
            try
            {
                MatchMakerBL.AproveMM(mmId);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
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
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
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
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        // DELETE: api/Users/5
        [HttpPut]
        [Route("deleteMatchMaker/{id}")]
        //public IHttpActionResult Delete(int id, [FromBody] MatchMaker1 mm)
        public IHttpActionResult Delete(int id)
        {
            try
            {
                MatchMaker1 mm = MatchMakerBL.GetMatchMakerById(id);
                MatchMakerBL.DeleteMatchMaker(mm);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                return Conflict();
            }
        }
    }
}
