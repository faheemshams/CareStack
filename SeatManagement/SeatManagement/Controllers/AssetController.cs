using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class AssetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
