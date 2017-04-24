using System.Web.Http;
using TvApiLabUr.Models;
using TvApiLabUr.Services;

namespace TvApiLabUr.Controllers
{
    public class ReviewController : ApiController
    {
        private ReviewService _reviewService;

        public ReviewController()
        {
            _reviewService = new ReviewService();
        }

        [HttpPost, Route("movies/{movieId:int}/reviews")]
        public IHttpActionResult AddReviewToMovie(int movieId, ReviewRequest request)
        {
            _reviewService.AddReviewToMovie(movieId, request);
            return Ok();
        }

        [HttpDelete, Route("movies/{movieId:int}/reviews/{revievId}")]
        public IHttpActionResult Delete(int revievId)
        {
            _reviewService.Remove(revievId);
            return Ok();
        }

        [HttpGet, Route("movies/{movieId:int}/reviews")]
        public IHttpActionResult GetReviewsForMovie(int movieId)
        {
            return Ok(_reviewService.GetReviewsForMovie(movieId));
        }

        // to działa ale zwraca srednią ocenę jako pojedyńcza recenzja z pustymi polami oprócz pola Rate
        //[HttpGet, Route("movies/{movieId:int}/score")]
        //public IHttpActionResult GetScoreForMovie(int movieId)
        //{
        //    return Ok(_reviewService.GetScoreForMovie(movieId));
        //}
    }
}
