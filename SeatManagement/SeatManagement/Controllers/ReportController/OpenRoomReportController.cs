using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
