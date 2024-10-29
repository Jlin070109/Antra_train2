
using System.Collections.Generic;

namespace ApplicationCore.entity
{
    public class Crew
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePath { get; set; }

        // Navigation Property
        public ICollection<MovieCrew> MovieCrews { get; set; }
    }
}