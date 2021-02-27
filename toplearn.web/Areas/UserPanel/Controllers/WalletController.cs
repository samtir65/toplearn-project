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
    public class WalletController : Controller
    {
        private IUserServiec _userServiec;
        public WalletController(IUserServiec userServiec)
        {
            _userServiec = userServiec;
        }

        [Route("UserPanel/Wallet")]
        
        public IActionResult Index()
        {
            ViewBag.ListWallet = _userServiec.GetWalletUser(User.Identity.Name);
            return View();
        }
        [Route("UserPanel/Wallet")]
        [HttpPost]
        public ActionResult index(ChargWalletViewModel charg)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ListWallet = _userServiec.GetWalletUser(User.Identity.Name);
                return View(charg);
            }

            _userServiec.chargwallet(User.Identity.Name, charg.Amount, "شارژ حساب");
            //todo online
            return null;
        }
    }
}