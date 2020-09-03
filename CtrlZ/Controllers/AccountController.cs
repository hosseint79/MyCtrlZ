using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core;
using DataLayer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace CtrlZ.Controllers
{
    public class AccountController : Controller
    {
        IAccount _account;
        public AccountController(IAccount account)
        {
            _account = account;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                if (_account.ExistEmail(viewmodel.Email))
                {
                    // error exist email 
                    
                }
                else
                {
                    User user = new User()
                    {
                        Email = viewmodel.Email,
                        Name = "",
                        LastName = "",
                        PassWord = Hash.MD5hash(viewmodel.PassWord),
                        Pic = "",
                        DateCreate = "",
                        RoleId = 2
                    };
                    _account.Register(user);
                }
            }
            else
            {
                //error 
            }


            return View(viewmodel);
        }

        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(LoginViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                string pass = Hash.MD5hash(viewmodel.PassWord);
                User user = _account.Login(viewmodel.Email, pass);

                if (user != null)
                {
                    var claim = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                            new Claim(ClaimTypes.Email,viewmodel.Email),                          
                            new Claim(ClaimTypes.Name,viewmodel.Email)                          
                        };

                    var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                    var Principal = new ClaimsPrincipal(identity);
                    var Peroperty = new AuthenticationProperties()
                    {
                        IsPersistent = true
                    };

                    HttpContext.SignInAsync(Principal, Peroperty);
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("ModelOnly","کاربری با این اطلاعات پیدا نشد ....");
                }
            }

            return View(viewmodel);
        }


        public IActionResult LoginOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
        
    }
}