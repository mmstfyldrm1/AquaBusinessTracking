using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _AdminLayoutEnergyComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
