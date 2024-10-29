using System;
using System.Collections.Generic;

namespace ApplicationCore.Models;

public class MovieDetailsModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal? Revenue { get; set; }
    public decimal? Budget { get; set; }
    public string Overview { get; set; }
    public string PosterUrl { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public List<GenreModel> Genres { get; set; }
    public List<CastModel> Casts { get; set; }
    public List<TrailerModel> Trailers { get; set; }
    // Add other properties as needed
}

public class GenreModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class CastModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Character { get; set; }
    public string ProfilePath { get; set; }
}

public class TrailerModel
{
    public int Id { get; set; }
    public string TrailerUrl { get; set; }
    public string Name { get; set; }
}
