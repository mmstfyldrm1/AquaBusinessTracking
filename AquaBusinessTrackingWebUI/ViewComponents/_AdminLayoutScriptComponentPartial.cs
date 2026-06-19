using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _AdminLayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
