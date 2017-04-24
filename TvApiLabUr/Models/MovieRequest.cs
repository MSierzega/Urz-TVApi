using System.ComponentModel.DataAnnotations;

namespace TvApiLabUr.Models
{
    public class MovieRequest
    {
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
    }
}