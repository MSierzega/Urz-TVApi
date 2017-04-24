using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TvApiLabUr.Models;
using TvApiLabUr.Services;

namespace TvApiLabUr.Controllers
{
    public class ActorController : ApiController
    {
        private ActorService _actorService;

        public ActorController()
        {
            _actorService = new ActorService();
        }

        [HttpPost, Route("actors")]
        public IHttpActionResult Post([FromBody]ActorRequest actor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _actorService.AddActor(actor);

            return Ok();
        }

        [HttpPost, Route("actors/{actorId}/{movieId}")]
        public IHttpActionResult Post(int actorId, int movieId)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            _actorService.AddActorToMovie(actorId, movieId);

            return Ok();
        }

        [HttpDelete, Route("actors/{actorId}")]
        public IHttpActionResult Delete(int actorId)
        {
            _actorService.Remove(actorId);
            return Ok();
        }
    }
}
