using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebUI.Controllers
{

    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
