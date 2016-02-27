using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EPAM.Wunderlist.WebUI.IdentityCore;
using EPAM.Wunderlist.WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace EPAM.Wunderlist.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<UserIdentity, int> _userManager;
        
        private IAuthenticationManager SignInManager => 
            HttpContext.GetOwinContext().Authentication;

        private async Task SignInAsync(UserIdentity user, bool isPersistent)
        {
            SignInManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            ClaimsIdentity identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            SignInManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, identity);
        }

        public AccountController(UserManager<UserIdentity, int> userManager)
        {
            if (userManager == null)
                throw new ArgumentNullException(nameof(userManager));
        
            _userManager = userManager;
        }
        
        [AllowAnonymous]
        public ActionResult Register(string redirectUrl)
        {
            ViewBag.RedirectUrl = redirectUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, string redirectUrl)
        {
            if (ModelState.IsValid)
            {
                var user = new UserIdentity {UserName = model.Name, Email = model.Email};
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result == IdentityResult.Success)
                {
                    await SignInAsync(user, true);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
        {
                    ModelState.AddModelError("", error);
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Login(string redirectUrl)
        {
            ViewBag.RedirectUrl = redirectUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
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

                    if (string.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Home");

                    return Redirect(returnUrl);
                }
            }

            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        public ActionResult LogOff()
        {
            SignInManager.SignOut();
            return RedirectToAction("Login");
        }
    }
}