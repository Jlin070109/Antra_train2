namespace ApplicationCore.entity;


public class MovieCast {
        public int MovieId { get; set; }
        public int CastId { get; set; }
        public string Character { get; set; }

        // Navigation Properties
        public Movie Movie { get; set; }
        public Cast Cast { get; set; }
}
