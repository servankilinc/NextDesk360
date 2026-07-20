using ExpressDesk360.Core.Utils.HttpContextManager;
using Microsoft.AspNetCore.Mvc;

namespace ExpressDesk360.WebUI.Controllers.Base;

public class UIController : BaseController
{
    private readonly IHttpContextManager _httpContextManager;
    public UIController(ILogger<UIController> logger, IHttpContextManager httpContextManager): base(logger) => _httpContextManager = httpContextManager;

    public IActionResult SetCulture(string culture, string? returnUrl)
    {
        _httpContextManager.SetCurrentCulture(culture);

        // returnUrl comes from the query string. Without the IsLocalUrl check this is an open
        // redirect: /UI/SetCulture?returnUrl=https://phishing.example sends the user off-site
        // from a trusted domain. There is no UI/Index action, so fall back to the home page.
        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);

        return RedirectToAction("Index", "Home");
    }
}