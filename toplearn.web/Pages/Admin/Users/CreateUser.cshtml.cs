using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using toplearn.Core.DTOs;
using toplearn.Core.Services.Interfaces;
using toplearn.Datalayer.Entities.User;

namespace toplearn.web.Pages.Admin.Users
{
    public class CreateUserModel : PageModel
    {
        private IPermisionServiec _permisionServiec;
        private IUserServiec _userServiec;
        public CreateUserModel(IPermisionServiec permisionServiec,IUserServiec userServiec)
        {
            _permisionServiec = permisionServiec;
            _userServiec = userServiec;

        }
        [BindProperty]
       
        public CreateUserViewModel CreateUserViewModel { get; set; }
        public void OnGet()
        {
            ViewData["Roles"] = _permisionServiec.GetRols();
            

        }

        public IActionResult OnPost(List<int> SelectedRol)
        {
          

            if(!ModelState.IsValid)
            return Page();
            int userid = _userServiec.AddfromAdmin(CreateUserViewModel);

            _permisionServiec.AddRolstoUser(SelectedRol, userid);
            return Redirect("/Admin/Users");


        }
    }
}