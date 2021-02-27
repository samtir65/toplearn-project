using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using toplearn.Core.Services.Interfaces;
using toplearn.Datalayer.Entities.User;

namespace toplearn.web.Pages.Admin.Roles
{
    public class CreateRolesModel : PageModel
    {
       private IPermisionServiec _permisionServiec;
        public CreateRolesModel(IPermisionServiec permisionServiec)
        {
            _permisionServiec = permisionServiec;
        }

        [BindProperty]
        public Role Role { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            //if (!ModelState.IsValid)
            //    return Page();
            Role.IsDelete = false;
           
         int RolID=_permisionServiec.AddRole(Role);

            //add permision

            return Redirect("Index");
        }
    }
}