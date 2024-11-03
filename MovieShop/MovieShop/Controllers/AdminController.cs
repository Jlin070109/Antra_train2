using Microsoft.AspNetCore.Mvc;
using Utilities.CustomFilters;

namespace MovieShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [LogRequestFilter]
        public IActionResult CreateMovie() 
        {
            return View();
        }
    }
}
