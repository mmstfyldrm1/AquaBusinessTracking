using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _AdminLayoutStanceComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
