using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Trailer
    {
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(2048)")]
        public string TrailerUrl { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(2048)")]
        public string Name { get; set; }
    }
}
