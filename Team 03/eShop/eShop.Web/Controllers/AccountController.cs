using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using eShop.Common;
using eShop.Model.Models;
using eShop.Service.Services;
using eShop.Service.ViewModel;
using Microsoft.Owin.Security;

namespace eShop.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginModel)
        {
            IAuthenticationManager authentication = HttpContext.GetOwinContext().Authentication;

            bool isPersistent = loginModel.RememberMe;
            User user = _userService.Login(loginModel);
            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Email)
                };
                var identity = new ClaimsIdentity(claims, "Application");
                authentication.SignIn(
                    new AuthenticationProperties {IsPersistent = loginModel.RememberMe}, identity);

                return Json("Success", JsonRequestBehavior.DenyGet);
            }

            return Json("Something Wrong : Username or Password invalid ^_^ ", JsonRequestBehavior.DenyGet);
        }

        [HttpGet]
        public ActionResult Register()
        {
            IAuthenticationManager authentication = HttpContext.GetOwinContext().Authentication;
            authentication.SignOut("Application");
            //authentication.Challenge("Application");
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel registrationModel)
        {
            var statusRegistration = false;
            string messageRegistration = string.Empty;

            if (ModelState.IsValid)
            {
                RegisterResult result = _userService.Register(registrationModel);
                switch (result)
                {
                    case RegisterResult.MailExisted:
                        ModelState.AddModelError("Warning Email", "Sorry: Email already Exists");
                        return View(registrationModel);
                    case RegisterResult.UsernameExisted:
                        ModelState.AddModelError("Warning User Name", "Sorry: User name already Exists");
                        return View(registrationModel);
                    case RegisterResult.Success:
                        messageRegistration = "Your account has been created successfully. ^_^";
                        statusRegistration = true;
                        var loginModel = new LoginViewModel
                        {
                            UserName = registrationModel.Username,
                            Password = registrationModel.Password,
                            RememberMe = false
                        };
                        User user = _userService.Login(loginModel);
                        IAuthenticationManager authentication = HttpContext.GetOwinContext().Authentication;
                        if (user != null)
                        {
                            var claims = new[]
                            {
                                new Claim(ClaimTypes.Name, user.Email)
                            };
                            var identity = new ClaimsIdentity(claims, "Application");
                            authentication.SignIn(
                                new AuthenticationProperties {IsPersistent = loginModel.RememberMe}, identity);
                        }

                        break;
                }
            }
            else
            {
                messageRegistration = "Something Wrong!";
            }

            ViewBag.Message = messageRegistration;
            ViewBag.Status = statusRegistration;

            return View(registrationModel);
        }

        public ActionResult Logout()
        {
            IAuthenticationManager authentication = HttpContext.GetOwinContext().Authentication;
            authentication.SignOut("Application");
            authentication.Challenge("Application");
            return Redirect(Request.UrlReferrer.AbsolutePath);
        }

        public ActionResult External()
        {
            IAuthenticationManager authentication = HttpContext.GetOwinContext().Authentication;
            if (Request.HttpMethod == "POST")
            {
                authentication.Challenge("Facebook");
                return new HttpUnauthorizedResult();
            }

            AuthenticateResult result = authentication.AuthenticateAsync("External").Result;
            if (result != null && result.Identity != null)
            {
                ClaimsIdentity resultIdentity = result.Identity;
                authentication.SignOut("External");
                var registrationModel = new RegistrationViewModel
                {
                    Username = resultIdentity.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value,
                    Email = resultIdentity.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email)).Value,
                    FirstName = resultIdentity.Claims.FirstOrDefault(x => x.Type.Equals("FirstName")).Value,
                    LastName = resultIdentity.Claims.FirstOrDefault(x => x.Type.Equals("LastName")).Value,
                    Password = "abcde12345",
                    ConfirmPassword = "abcde12345"
                };
                _userService.Register(registrationModel);
                User user = _userService.GetByEmail(registrationModel.Email);
                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, user.Email)
                    };
                    var identity = new ClaimsIdentity(claims, "Application");
                    authentication.SignIn(
                        new AuthenticationProperties {IsPersistent = false}, identity);
                }

                return Redirect(Request.QueryString["ReturnUrl"]);
            }

            return View();
        }

        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}