using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class Cast
    {
        public int Id { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string Name { get; set; }
        [Required]
        public string TmdbUrl { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(2048)")]
        public string ProfilePath { get; set; }
        public ICollection<MovieCast> MovieCasts { get; set; }
    }
}
