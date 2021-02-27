using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using toplearn.Core.DTOs;
using toplearn.Core.Services.Interfaces;

namespace toplearn.web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class HomeController : Controller
    {
        private IUserServiec _userServiec;
        public HomeController(IUserServiec userServiec)
        {
            _userServiec = userServiec;
        }

     
        public IActionResult Index()
        {
            return View(_userServiec.GetUserInformation(User.Identity.Name));
        }
     
        [Route("UserPanel/EditProfile")]
        public IActionResult EditProfile()
        {
            return View(_userServiec.GEtEditUserPanelDate(User.Identity.Name));
        }

        [Route("UserPanel/EditProfile")]
        [HttpPost]
        public IActionResult EditProfile(EditProfilUserPanelViewModel profile )
        {
            //ناتمام بخاطر ذخیره کردن عکس که از استاد درم بخت بپرسم
            return View(profile);

        }
        [Route("UserPanel/ChangePassword")]
        public IActionResult ChangePassword()
        {
            return View();

        }
        [Route("UserPanel/ChangePassword")]
        [HttpPost]
    
        public IActionResult ChangePassword(ChangePasswordViewModel change)
        {
            string CourentUserName = User.Identity.Name;
            if (!ModelState.IsValid)
                return View(change);
           
            if(!_userServiec.CompareOldpassword(CourentUserName,change.OldPassWord))
            {
                ModelState.AddModelError("OldPassword", "کلمه عبور فعلی صحیح نمی باشد.");
                return View(change);
            }

            _userServiec.ChangePassword(CourentUserName, change.PassWord);
             ViewBag.isSuccess = true;
            return View();

        }
    }
}