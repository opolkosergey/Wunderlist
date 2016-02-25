using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EPAM.Wunderlist.WebUI.IdentityCore;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace EPAM.Wunderlist.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ManagerIdentityUser _userManager;
        private readonly IAuthenticationManager _authentication;
        
        public AccountController(ManagerIdentityUser userManager)
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

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}