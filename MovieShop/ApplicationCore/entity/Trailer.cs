namespace ApplicationCore.entity;

using System.ComponentModel.DataAnnotations;

public class Trailer {
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }

        [MaxLength(2084)]
        public string TrailerUrl { get; set; }

        [MaxLength(2084)]
        public string Name { get; set; }

        // Navigation Property
        public Movie Movie { get; set; }
}
