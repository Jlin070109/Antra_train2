
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.Controllers
{

    public class MovieController : Controller
    {
        private readonly IMovieServiceAsync _movieService;
        private readonly IGenreServiceAsync _genreService;

        private Dictionary<string, Func<Movie,object>> sortMethod = new()
        {
            {"Id", new Func<Movie, object>(movie => movie.Id)},
            {"ReleaseDate", new Func<Movie, object>(movie => movie.ReleaseDate)},
            {"Title", new Func<Movie, string>(movie => movie.Title)},
            {"Revenue", new Func<Movie, object?>(movie => movie.Revenue)},
        };

        public MovieController(IMovieServiceAsync movieService, IGenreServiceAsync genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
        }

        public async Task<IActionResult> Index(string sort="Id", string order = "asc", int page=1)
        {
            ViewData["sort"] = sort;
            ViewData["page"] = page;
            ViewData["order"] = order;
            ViewBag.Genre = await _genreService.GetAllGenre();
            var result = await _movieService.GetAll();
            ViewBag.MaxPage = Convert.ToInt32(Math.Ceiling((double)(result.Count() / 64))) + 1;
            if(order == "asc") 
            { 
                return View(result.OrderBy(sortMethod[sort]).Skip((page - 1) * 64).Take(64).ToList());             
            }
            else
            {
                return View(result.OrderByDescending(sortMethod[sort]).Skip((page - 1) * 64).Take(64).ToList());
            }
            
        }

        public async Task<IActionResult> Detail(int id)
        {
            Movie movie = await _movieService.GetMovieById(id);
            return View(movie);
        }

        public async Task<IActionResult> MoviesByGenre(int id, string sort = "Id", 
            string order = "asc", int pageSize = 64, int page = 1)
        {
            ViewData["id"] = id;
            ViewData["sort"] = sort;
            ViewData["page"] = page;
            ViewData["order"] = order;
            ViewBag.Genre = await _genreService.GetAllGenre();
            IEnumerable<Movie> movies = await _movieService.GetMoviesByGenre((int)ViewData["id"]);
            ViewBag.MaxPage = Convert.ToInt32(Math.Ceiling((double)(movies.Count() / pageSize))) + 1;
            if (order == "asc")
            {
                return View(movies.OrderBy(sortMethod[sort]).
                    Skip((page - 1) * pageSize).Take(pageSize).ToList());
            }
            else
            {
                return View(movies.OrderByDescending(sortMethod[sort]).
                    Skip((page - 1) * pageSize).Take(pageSize).ToList());
            }
        }
    }
}
