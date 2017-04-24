using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TvApiLabUr.DAL
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}