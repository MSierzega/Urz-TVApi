using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TvApiLabUr.DAL;
using TvApiLabUr.Models;
using TvApiLabUr.Services;

namespace TvApiLabUr.Controllers
{
    internal class ActorService
    {
        public void AddActorToMovie(int actorId, int movieId)
        {
            //throw new NotImplementedException();
            using (var ctx = new MoviesContext())
            {
                //tak powinno być:
                //najpierw znaleźć czy aktor i film jest juz w bazie
                //jak niema null(firstordefault) to dodać aktora do bazy 
                //i dopiero wtedy ustawić propertisy (dodać elementy do list w movie i actorach)

                Actor actor = ctx.Actors.Find(actorId);
                Movie movie = ctx.Movies.Find(movieId);
                actor.Movies.Add(movie);
                movie.Actors.Add(actor);      
                ctx.SaveChanges();
            }
        }

        public void AddActor(ActorRequest actor)
        {
            //throw new NotImplementedException();
            using (var ctx = new MoviesContext())
            {
                ctx.Actors.Add(new Actor()
                {
                    Name = actor.Name,
                    Surname = actor.Surname
                });
                ctx.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (var ctx = new MoviesContext())
            {
                var actor = ctx.Actors.Find(id);
                if (actor == null)
                {
                    return;
                }

                ctx.Actors.Remove(actor);
                ctx.SaveChanges();
            }
        }
    }
}