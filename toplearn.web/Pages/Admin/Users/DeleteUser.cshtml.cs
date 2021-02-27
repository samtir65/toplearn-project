using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using toplearn.Core.DTOs;
using toplearn.Core.Services.Interfaces;

namespace toplearn.web.Pages.Admin.Users
{
    public class DeleteUserModel : PageModel
    {
        private IUserServiec _userServiec;
        public DeleteUserModel(IUserServiec userServiec)
        {
            _userServiec = userServiec;
        }
        public InformatinUserViewModel InformatinUserViewModel { get; set; }
        public void OnGet(int id)
        {
            ViewData["UserId"] = id;
            InformatinUserViewModel = _userServiec.GetUserInformation(id);
        }       
        public IActionResult OnPost(int userid)
        {
            _userServiec.DeleteUser(userid);
            return RedirectToPage("index");

        }
    }
}