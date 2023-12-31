using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;
using SpbLeague.Domain.ViewModels;
using System.Text;
using SpbLeague.Service.Interfeces;
using System.Net;

namespace SpbLeague.Controllers
{
	public class AccountController : Controller
	{
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
		public IActionResult Register() => View();

        [HttpGet]
        public IActionResult Login() => View();

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if(ModelState.IsValid)
            {
                var response = await _accountService.Login(login);
                if(response.StatusCode == Domain.Enum.StatusCode.Ok)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", response.Description);
            }
            return View(login);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.Register(register);
                if(response.StatusCode == Domain.Enum.StatusCode.Ok)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", response.Description);
            }

            return View(register);
        }
    }
}
