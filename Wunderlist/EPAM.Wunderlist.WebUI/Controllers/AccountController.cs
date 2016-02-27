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
        private readonly IAuthenticationManager _authentication;
        
        public AccountController(UserManager<UserIdentity, int> userManager)
        {
            if (userManager == null)
                throw new ArgumentNullException(nameof(userManager));
        
            _userManager = userManager;
            _authentication = HttpContext.GetOwinContext().Authentication;
        }
        
        private async Task SignInAsync(UserIdentity user, bool isPersistent)
        {
            _authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            ClaimsIdentity identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            _authentication.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        [AllowAnonymous]
        public ActionResult Register(string redirectUrl)
        {
            ViewBag.RedirectUrl = redirectUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel model, string redirectUrl)
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string redirectUrl)
        {
            ViewBag.RedirectUrl = redirectUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LogOnViewModel model, string redirectUrl)
        {
            return View();
        }

        public ActionResult LogOff()
        {
            _authentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}