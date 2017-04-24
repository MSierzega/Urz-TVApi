using System;
using System.Collections.Generic;
using System.Linq;
using TvApiLabUr.DAL;
using TvApiLabUr.Models;

namespace TvApiLabUr.Services
{
    public class MoviesService
    {
        public List<MovieResponse> GetAll()
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.Movies.Select(m => new MovieResponse()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year
                }).ToList();
            }
        }

        public MovieResponse GetById(int id)
        {
            using (var ctx = new MoviesContext())
            {
                var movie = ctx.Movies.Find(id);
                if (movie == null)
                {
                    return null;
                }

                return new MovieResponse()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Year = movie.Year
                };
            }
        }

        public void AddNewMovie(MovieRequest movie)
        {
            using (var ctx = new MoviesContext())
            {
                ctx.Movies.Add(new Movie()
                {
                    Title = movie.Title,
                    Year = movie.Year
                });
                ctx.SaveChanges();
            }
        }
        
        public void Remove(int id)
        {
            using (var ctx = new MoviesContext())
            {
                var movie = ctx.Movies.Find(id);
                if (movie == null)
                {
                    return;
                }

                ctx.Movies.Remove(movie);
                ctx.SaveChanges();
            }
        }

        public List<MovieResponse> GetMoviesInYear(int movieYear)
        {
            //throw new NotImplementedException();
            using (var ctx = new MoviesContext())
            {
                return ctx.Movies.Select(m => new MovieResponse()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year
                }).Where(m => m.Year == movieYear).OrderByDescending(m => m.Title).ToList();

            }
        }

        public MovieResponseDetailed GetScoreForMovie(int movieId)
        {
            //throw new NotImplementedException();
            using (var ctx = new MoviesContext())
            {
                var movie = ctx.Movies.Find(movieId);
                //var score = movie.Reviews.Average(x => x.Rate);
                return movie.Reviews.Select(y => new MovieResponseDetailed()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Year = movie.Year,
                    Score = (float)movie.Reviews.Average(x => x.Rate)
                }).ToList().FirstOrDefault();//zwróci null jeśli nie ma recenzji//firstordefault musi być bo bez tego zwracało kilka komentarzy może lepiej by było użyć dekoratora do moviesServices .... 
            }
        }

        internal List<MovieResponse> GetMoviesWithTitle(string movieTitle)
        {
            //throw new NotImplementedException();
            using (var ctx = new MoviesContext())
            {
                return ctx.Movies.Select(m => new MovieResponse()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year
                }).Where(m => m.Title.Contains(movieTitle)).OrderByDescending(m => m.Title).ToList();

            }
        }
    }
}