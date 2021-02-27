using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using toplearn.Core.DTOs;
using toplearn.Core.Services.Interfaces;
using toplearn.Core.Convertor;
using toplearn.Datalayer.Entities.User;
using toplearn.Core.Generator;
using TopLearn.Core.Security;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using TopLearn.Core.Convertors;
using TopLearn.Core.Senders;

namespace toplearn.web.Controllers
{

    public class AccountController : Controller
    {
        private IUserServiec _userServiec;
        private IViewRenderService _viewRenderService;
        public AccountController(IUserServiec userServiec, IViewRenderService viewRenderService)
        {
            _userServiec = userServiec;
            _viewRenderService = viewRenderService;
        }

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);

            }
            if (_userServiec.IsExistUserName(register.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری معتبر نمی باشد");
                return View(register);

            }
            if (_userServiec.IsExistEmail(FixedText.FixedEmail(register.Email)))
            {
                ModelState.AddModelError("Email", "ایمیل معتبر نمی باشد");
                return View(register);
            }

            User user = new User()
            {
                ActiveCode = NameGenerator.GenerateUniqCode(),
                IsActive = false,
                Email = FixedText.FixedEmail(register.Email),
                PassWord = PasswordHelper.EncodePasswordMd5(register.PassWord),
                RegisterDate = DateTime.Now,
                Avatar = "Defult.jpg",
                UserName = register.UserName,
            }
              ;
            _userServiec.AddUser(user);

            #region SedndActivationEmail

            string Body = _viewRenderService.RenderToStringAsync("ActiveEmail", User);
            SendEmail.Send(user.Email, "فعالسازی ایمیل", Body);
            #endregion

            return View("SuccsessRegister", user);
        }

        #region Login

        [Route("login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public ActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);

            }
            var user = _userServiec.loginuser(login);
            if (user != null)
            {
                if (user.IsActive)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserID.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.Remember
                    };
                    HttpContext.SignInAsync(principal, properties);


                    ViewBag.isSuccess = true;
                    return View();

                }
                else
                {
                    ModelState.AddModelError("Email", "حساب کاربری شما فعال نشده است");

                }


            }
            ModelState.AddModelError("Email", " کاربری با مشخصات وارد شده یافت نشد ");
            return View(login);
        }
        #endregion
        #region Activecode
        public IActionResult ActiveAccount(string id)
        {
            ViewBag.isactive = _userServiec.ActiveAccount(id);
            return View();
        }

        #endregion

        #region Logout
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }
        #endregion
        #region ForgotPassword
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [Route("ForgotPassword")]
        [HttpPost]
        public IActionResult ForgotPassword(forgotpasswordviewModel forgot)
        {
            if (!ModelState.IsValid)

                return View(forgot);

            string FixedEmail = FixedText.FixedEmail(forgot.Email);
            toplearn.Datalayer.Entities.User.User user = _userServiec.GetByEmail(FixedEmail);
            if (user == null)
            {
                ModelState.AddModelError("Email", "کاربری یافت نشد");
                return View(forgot);

            }

            string BodeyEmail = _viewRenderService.RenderToStringAsync("_forgotPassword", user);
            SendEmail.Send(user.Email, "بازیابی رمز عبور", BodeyEmail);
            ViewBag.issuccess = true;

            return View();
        }
        #endregion

        #region ResetPassword

        public IActionResult ResetPassword(string id)
        {
            return View(new resetpasswordviewmodel()
            {
                ActiveCode = id

            });
        }

        [HttpPost]
        public IActionResult ResetPassword(resetpasswordviewmodel reset)
        {
            if (!ModelState.IsValid)
            
                return View(reset);
            Datalayer.Entities.User.User user = _userServiec.GetuserByActiveCode(reset.ActiveCode);
            if (user == null)
                return NotFound();
            string hashpassword = PasswordHelper.EncodePasswordMd5(reset.PassWord);
            user.PassWord = hashpassword;
            _userServiec.UpdateUser(user);
            return Redirect("/Login");
        }

        #endregion
    }

}