using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _UserLayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
