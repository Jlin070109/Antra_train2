using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Service;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Purchase(int movieId)
        {
            // Implement purchase logic
            // ...

            return RedirectToAction("Details", "Movies", new { id = movieId });
        }

        [HttpPost]
        public async Task<IActionResult> SubmitReview(int movieId, int rating, string reviewText)
        {
            // Implement review submission logic
            // ...

            return RedirectToAction("Details", "Movies", new { id = movieId });
        }
    }
}