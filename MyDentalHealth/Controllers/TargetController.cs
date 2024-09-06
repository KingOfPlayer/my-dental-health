using Microsoft.AspNetCore.Mvc;
using MyDentalHealth.Extentions;

namespace MyDentalHealth.Controllers
{
    [Auth]
    public class TargetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
