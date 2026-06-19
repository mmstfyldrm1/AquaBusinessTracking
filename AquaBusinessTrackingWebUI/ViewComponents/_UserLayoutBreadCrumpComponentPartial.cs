using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _UserLayoutBreadCrumpComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
