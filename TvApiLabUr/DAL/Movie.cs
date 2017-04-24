using System.Collections.Generic;

namespace TvApiLabUr.DAL
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
    }
}