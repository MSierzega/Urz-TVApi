using System.Data.Entity;

namespace TvApiLabUr.DAL
{
    public class MoviesContext : DbContext
    {
        public MoviesContext()
            : base("tvApiDb")
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }

}