using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Model.Auth.Login;
using ExpressDesk360.Model.Auth.Refresh;
using ExpressDesk360.Model.Auth.SignUp;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebAPI.Controllers.Base;

namespace ExpressDesk360.WebAPI.Controllers;

[ApiController]
public class AccountController : BaseController
{
    private readonly IAuthService _authService;
    public AccountController(IAuthService authService, ILogger<AccountController> logger) : base(logger) => _authService = authService;


    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await _authService.LoginAsync(request);

        return ToAction(result);
    }

    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUp(SignUpRequest request)
    {
        var result = await _authService.SignUpAsync(request);

        return ToAction(result);
    }

    [HttpPost("RefreshAuth")]
    public async Task<IActionResult> RefreshAuth(RefreshAuthRequest request)
    {
        var result = await _authService.RefreshAsync(request);

        return ToAction(result);
    }
}