using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebUI.Controllers
{
    public class _UserLayout : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
