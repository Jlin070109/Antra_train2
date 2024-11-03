using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastServiceAsync _castService;

        public CastController(ICastServiceAsync castService)
        {
            _castService = castService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            ViewData["Page"] = page;
            var casts = await _castService.GetAllCast(page, 66);
            return View(casts);
        }

        public async Task<IActionResult> Detail(int Id)
        {
            var cast = await _castService.GetCastById(Id);
            return View(cast);
        }
    }
}
