using AquaBusinessTrackingWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System.Security.Claims;

public class InjectAuthViewDataFilter : IActionFilter
{
    private readonly ApiSettings _apiSettings;

    public InjectAuthViewDataFilter(IOptions<ApiSettings> apiSettings)
    {
        _apiSettings = apiSettings.Value;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.Controller is Controller controller)
        {
            var token = controller.Request.Cookies["AuthToken"];
            controller.ViewBag.JwtToken = token;
            controller.ViewBag.ApiBaseUrl = _apiSettings.BaseUrl;
            controller.ViewBag.CurrentUserId = controller.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}