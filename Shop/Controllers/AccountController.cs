using DBs.Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Shop.Models;
using Shop.UserServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WCFContracts.DataContracts;

namespace Shop.Controllers
{
    public class AccountController : Controller
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            await SetInitialDataAsync();

            if (ModelState.IsValid)
            {
                UserData userDto = new UserData { Email = model.Email, Password = model.Password };
                UserServiceRef.UserServiceClient client = new UserServiceClient();
                client.Authenticate(userDto);
                ClaimsIdentityData claim = client.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                    client.Close();
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim.test);
                    client.Close();
                    return RedirectToAction("Index", "Home");
                }
            }
            
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            UserServiceRef.UserServiceClient client = new UserServiceClient();
            await SetInitialDataAsync();

            if (ModelState.IsValid)
            {
                UserData userDto = new UserData
                {
                    Email = model.Email,
                    Password = model.Password,
                    Address = model.Address,
                    Name = model.Name,
                    Role = "user"
                };
                OperationDetails operationDetails = client.Create(userDto);
                if (operationDetails.Succedeed)
                {
                    client.Close();
                    return View("SuccessRegister");
                }
                else
                {
                    client.Close();
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
                }
            }
            return View(model);
        }

        private async Task SetInitialDataAsync()
        {
            UserServiceRef.UserServiceClient client = new UserServiceClient();
            client.SetInitialData(new UserData
            {
                Email = "somemail@mail.ru",
                UserName = "somemail@mail.ru",
                Password = "nyam123",
                Name = "KItty",
                Address = "ул.Где-то там",
                Role = "admin",
            }, new List<string> { "user", "admin" }.ToArray());
            client.Close();
        }
    }
}