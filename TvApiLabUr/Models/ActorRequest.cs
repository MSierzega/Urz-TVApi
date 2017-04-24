using System.ComponentModel.DataAnnotations;

namespace TvApiLabUr.Models
{
    public class ActorRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
    }
}