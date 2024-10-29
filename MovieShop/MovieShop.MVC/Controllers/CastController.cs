using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService _castService;

        public CastController(ICastService castService)
        {
            _castService = castService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var castDetails = await _castService.GetCastDetails(id);
            if (castDetails == null)
            {
                return NotFound();
            }
            return View(castDetails);
        }
    }
}