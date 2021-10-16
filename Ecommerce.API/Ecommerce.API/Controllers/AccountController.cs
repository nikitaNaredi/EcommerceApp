using Ecommerce.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<AccountController> logger;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            
            var user = new ApplicationUser();
            user.UserName = model.Name;
            user.Email = model.Email;

            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                logger.LogDebug("Inside succeeded"); 
                await signInManager.SignInAsync(user, isPersistent: false);
                return Ok();
            }
            return StatusCode((int)HttpStatusCode.NotFound);
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel model, string redirectUrl)
        {
            logger.LogInformation("User Data {0} {1} {2} ", model.UserName, model.Password, model.RememberMe);
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                logger.LogInformation("Inside succeeded");
                if (!string.IsNullOrWhiteSpace(redirectUrl) && Url.IsLocalUrl(redirectUrl))
                {
                    return Redirect(redirectUrl);
                }

                return Ok();
            }
            logger.LogInformation("Login failed");
            return StatusCode((int)HttpStatusCode.NotFound);
        }
    }
}
