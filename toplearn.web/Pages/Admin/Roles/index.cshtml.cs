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
    public class indexModel : PageModel
    {
        private IPermisionServiec _permisionServiec;
        public indexModel(IPermisionServiec permisionServiec)
        {
            _permisionServiec = permisionServiec;

        }
        [BindProperty]

        public List<Role> Roleslist { get; set; }
        public void OnGet()
        {

            Roleslist=_permisionServiec.GetRols();
        }
    }
}