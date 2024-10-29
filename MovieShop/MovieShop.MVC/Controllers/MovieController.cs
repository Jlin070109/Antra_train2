

using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Service;

namespace MovieShop.MVC.Controllers;

public class MoviesController : Controller
{
    private readonly IMovieService _movieService;
    
    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }
    
    public async Task<IActionResult> Details(int id)
    {
        var movieDetails = await _movieService.GetMovieDetails(id);
        if (movieDetails == null)
        {
            return NotFound();
        }
        return View(movieDetails);
    }
}
