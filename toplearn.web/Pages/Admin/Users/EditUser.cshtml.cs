using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using toplearn.Core.DTOs;
using toplearn.Core.Services;
using toplearn.Core.Services.Interfaces;

namespace toplearn.web.Pages.Admin.Users
{
    public class EditUserModel : PageModel
    {
      
        private IUserServiec _userServiec;
        private IPermisionServiec _permissionservice;
        public EditUserModel(IUserServiec userServiec, IPermisionServiec permissionservice)
        {
            _userServiec = userServiec;
            _permissionservice = permissionservice;

        }

     
        [BindProperty]
        public EditUserViewModel EditUserViewModel { get; set; }
        public void OnGet(int userid)
        {

            EditUserViewModel = _userServiec.GetUserforShowinEditMode(userid);
            ViewData["Roles"] = _permissionservice.GetRols();


        }
        public IActionResult OnPost(List<int> SelectedRol)
        {
           //if (!ModelState.IsValid)
            
           //   return Page();

            
            _userServiec.EditfromAdmin(EditUserViewModel);
            //Edit Roles
            _permissionservice.EditRolsUser(EditUserViewModel.Userid, SelectedRol);
            return RedirectToPage("index");

        }

    }
}