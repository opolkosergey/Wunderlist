using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EPAM.Wunderlist.Services.UserService;
using EPAM.Wunderlist.WebUI.IdentityCore;
using EPAM.Wunderlist.WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace EPAM.Wunderlist.WebUI.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly UserManager<UserIdentity, int> _userManager;
        private readonly IUserService _userService;

        private IAuthenticationManager SignInManager => 
            HttpContext.GetOwinContext().Authentication;

        private async Task SignInAsync(UserIdentity user, bool isPersistent)
        {
            SignInManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            ClaimsIdentity identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            SignInManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, identity);
        }

        public AccountController(UserManager<UserIdentity, int> userManager, IUserService service)
        {
            if (userManager == null)
                throw new ArgumentNullException(nameof(userManager));

            if(service == null)
                throw new ArgumentNullException(nameof(service));

            _userManager = userManager;
            _userService = service;
        }
        
        public ActionResult Register()
        {
            ViewBag.RedirectUrl = "/webapp";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, string redirectUrl)
        {
            if (ModelState.IsValid)
            { 
                if (_userService.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "This Email is already occupied. Please enter another Email!");
                }
                else
                {
                    var user = new UserIdentity {UserName = model.Name, Email = model.Email};
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result == IdentityResult.Success)
                    {
                        user = await _userManager.FindByNameAsync(model.Email);
                        await SignInAsync(user, true);
                        return RedirectToAction("Inbox", "Lists");
                    }
                }
            }

            return View(model);
        }
        
        public ActionResult Login()
        {
            ViewBag.RedirectUrl = "/webapp";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LogOnViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UserIdentity user = await _userManager.FindAsync(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Incorrect login or password.");
                }
                else
                {
                    await SignInAsync(user, true);
                    return RedirectToAction("Inbox", "Lists");
                }
            }

            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        [Authorize]
        public ActionResult LogOff()
        {
            SignInManager.SignOut();
            return RedirectToAction("Login");
        }
    }
}