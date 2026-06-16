using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTracking.Controllers
{
    public class _LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
