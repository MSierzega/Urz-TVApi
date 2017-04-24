using System.Collections.Generic;
using System.Web.Http;
using TvApiLabUr.Models;
using TvApiLabUr.Services;

namespace TvApiLabUr.Controllers
{
    public class MovieController : ApiController
    {
        private MoviesService _moviesService;

        public MovieController()
        {
            _moviesService = new MoviesService();
        }

        [HttpGet, Route("movies")]
        public IHttpActionResult GetAllMovies()
        {
            List<MovieResponse> movies = _moviesService.GetAll();
            return Ok(movies);
        }

        [HttpGet, Route("movies/{movieId:int}")]
        public IHttpActionResult Get(int movieId)
        {
            MovieResponse movie = _moviesService.GetById(movieId);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost, Route("movies")]
        public IHttpActionResult Post([FromBody]MovieRequest movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _moviesService.AddNewMovie(movie);

            return Ok();
        }

        [HttpDelete, Route("movies/{movieId}")]
        public IHttpActionResult Delete(int movieId)
        {
            _moviesService.Remove(movieId);
            return Ok();
        }

        [HttpGet, Route("movies/{movieYear:int}/year")]
        public IHttpActionResult GetMoviesInYear(int movieYear)
        {
            List<MovieResponse> movies = _moviesService.GetMoviesInYear(movieYear);
            return Ok(movies);
        }

        [HttpGet, Route("movies/{movieTitle}/title")]
        public IHttpActionResult GetMoviesWithTitle(string movieTitle)
        {
            List<MovieResponse> movies = _moviesService.GetMoviesWithTitle(movieTitle);
            return Ok(movies);
        }

        [HttpGet, Route("movies/{movieId:int}/score")]
        public IHttpActionResult GetScoreForMovie(int movieId)
        {
            return Ok(_moviesService.GetScoreForMovie(movieId));
        }
    }
}
