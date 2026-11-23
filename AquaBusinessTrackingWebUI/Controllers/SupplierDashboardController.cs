using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebUI.Controllers
{
    public class SupplierDashboardController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
