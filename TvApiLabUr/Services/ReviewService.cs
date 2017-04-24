using System;
using System.Collections.Generic;
using System.Linq;
using TvApiLabUr.DAL;
using TvApiLabUr.Models;

namespace TvApiLabUr.Services
{
    public class ReviewService
    {
        public void AddReviewToMovie(int movieId, ReviewRequest request)
        {
            using (var ctx = new MoviesContext())
            {
                var movie = ctx.Movies.Find(movieId);
                movie.Reviews.Add(new Review()
                {
                    Comment = request.Comment,
                    Rate = request.Rate
                });

                ctx.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (var ctx = new MoviesContext())
            {
                var review = ctx.Reviews.Find(id);
                if (review == null)
                {
                    return;
                }
                ctx.Reviews.Remove(review);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<ReviewResponse> GetReviewsForMovie(int movieId)
        {
            using (var ctx = new MoviesContext())
            {
                var movie = ctx.Movies.Find(movieId);
                return movie.Reviews.Select(x => new ReviewResponse()
                {
                    Id = x.Id,
                    Comment = x.Comment,
                    Rate = x.Rate
                }).ToList();
            }
        }
        // to działa ale zwraca srednią ocenę jako pojedyńcza recenzja z pustymi polami oprócz pola Rate
        //public object GetScoreForMovie(int movieId)
        //{
        //    //throw new NotImplementedException();
        //    using (var ctx = new MoviesContext())
        //    {
        //        var movie = ctx.Movies.Find(movieId);
        //        //var score = movie.Reviews.Average(x => x.Rate);
        //        return movie.Reviews.Select(y => new ReviewResponse()
        //        {
        //            Rate = (short)movie.Reviews.Average(x => x.Rate)
        //        }).ToList().FirstOrDefault();//zwróci null jeśli nie ma recenzji//firstordefault musi być bo bez tego zwracało kilka komentarzy może lepiej by było użyć dekoratora do moviesServices .... 
        //    }
        //}
    }
}