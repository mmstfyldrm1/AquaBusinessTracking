using AquaBusinessTrackingWebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _UserLayoutAsideComponentPartial : ViewComponent
    {
        private readonly CurrentUserService _currentUserService;

        public _UserLayoutAsideComponentPartial(CurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
