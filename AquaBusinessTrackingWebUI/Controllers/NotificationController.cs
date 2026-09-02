using AquaBusinessTrackingWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AquaBusinessTrackingWebUI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly ApiSettings _apiSettings;

        public NotificationController(IOptions<ApiSettings> apiSettings)
        {
            _apiSettings = apiSettings.Value;
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}