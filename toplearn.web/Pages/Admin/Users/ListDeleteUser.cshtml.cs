﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using toplearn.Core.DTOs;
using toplearn.Core.Services.Interfaces;

namespace toplearn.web.Pages.Admin.Users
{
    public class ListDeleteUserModel : PageModel
    {
        private IUserServiec _userServiec;
        public ListDeleteUserModel(IUserServiec userServiec)
        {
            _userServiec = userServiec;
        }
        public UserForAdminViewModel UserForAdminViewModel { get; set; }
        public void OnGet(int pageID = 1, string FilterUserName = "", string FilterEmail = "")
        {
            UserForAdminViewModel = _userServiec.GetDeleteUsers(pageID, FilterEmail, FilterUserName);


        }
    }
}