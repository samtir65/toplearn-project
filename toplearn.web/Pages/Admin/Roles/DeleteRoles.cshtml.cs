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
    public class DeleteRolesModel : PageModel
    {
      private  IPermisionServiec _permisionServiec;
        public DeleteRolesModel(IPermisionServiec permisionServiec)
        {
            _permisionServiec = permisionServiec;
        }
        [BindProperty]
        public Role Role { get; set; }
        public void OnGet(int id)
        {
            Role = _permisionServiec.GetRoleByRoleId(id);

        }
        public IActionResult OnPost()
        {
            _permisionServiec.DeleteRole(Role);
            return RedirectToPage("index");

        }
    }
}