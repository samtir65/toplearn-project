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
    public class EditRolesModel : PageModel
    {
       private IPermisionServiec _permisionServiec;
        public EditRolesModel(IPermisionServiec permisionServiec)
        {
            _permisionServiec = permisionServiec;
        }
       [BindProperty]
        public Role Editrole { get; set; }
        public void OnGet(int id)
        {
            Editrole = _permisionServiec.GetRoleByRoleId(id);

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _permisionServiec.EditRoles(Editrole);
            return RedirectToPage("index");
        }
    }
}