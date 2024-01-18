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
using Microsoft.AspNetCore.Identity;
using SpbLeague.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using SpbLeague.Domain.Enums;
using Microsoft.Extensions.Configuration;
using SpbLeague.Domain.Response;
using Microsoft.Win32;
using System.Data;
using Microsoft.AspNetCore.DataProtection;

namespace SpbLeague.Controllers
{
	public class AccountController : Controller
	{
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(IConfiguration config, UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _config = config;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        [HttpGet]
		public IActionResult Register() => View();

        [HttpGet]
        public IActionResult Login() => View();

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(login.Email);
            if(user == null)
            { 
                ModelState.AddModelError("", $"Пользователя {login.Email} не существует.");
                return View();
            }

            var signIn = await _signInManager.PasswordSignInAsync(user, login.Password,
                isPersistent: false, lockoutOnFailure: false) ;

            if (signIn.Succeeded)
            {
                var accessToken = CreateToken(user);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Неверный пароль");
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid) return View(ModelState);

            var user = new User
            {
                Email = register.Email,
                UserName = register.Email,
                Name = register.Name,
                Surname = register.Surname,
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if(result.Succeeded)
            {
                await CreateRole();
                await _userManager.AddToRoleAsync(user, Role.User.ToString());
                var accessToken = CreateToken(user);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View();
        }

        private string CreateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(JwtRegisteredClaimNames.Iss, _config["Jwt:Issuer"]),
                new Claim(JwtRegisteredClaimNames.Aud, _config["Jwt:Audience"]),
            };

            var token = new JwtSecurityToken(
              issuer: _config["Jwt:Issuer"],
              audience: _config["Jwt:Audience"],
              claims: claims,
              expires: DateTime.Now.AddHours(24),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task CreateRole()
        {
            bool IsExistAdmin = await _roleManager.RoleExistsAsync(Role.Admin.ToString());
            bool isExistUser = await _roleManager.RoleExistsAsync(Role.User.ToString());
            bool isExistModerator = await _roleManager.RoleExistsAsync(Role.Moderator.ToString());
            if (!IsExistAdmin)
            {
                var role = new IdentityRole();
                // first we create Admin rool    
                role.Name = Role.Admin.ToString();
                await _roleManager.CreateAsync(role);
            }
            if (!isExistUser)
            {
                var role = new IdentityRole();
                role.Name = Role.User.ToString();
                await _roleManager.CreateAsync(role);
            }
            if (!isExistModerator)
            {
                var role = new IdentityRole();
                role.Name = Role.Moderator.ToString();
                await _roleManager.CreateAsync(role);
            }
        }
    }
}
