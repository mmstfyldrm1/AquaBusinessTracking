using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebUI.Controllers
{
    public class UserDashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
