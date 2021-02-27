using System;
using System.Collections.Generic;
using System.Text;
using toplearn.Datalayer.Entities.User;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace toplearn.Core.DTOs
{
    public class UserForAdminViewModel
    {
        public List<User> Users { get; set; }
        public int CurentPage { get; set; }
        public int PageCount { get; set; }


    }

    public class CreateUserViewModel
    {

        [Display(Name = "نام کاریری")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1}کاراکتر باشد")]

        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1}کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [Display(Name = "کلمه عبور")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1}کاراکتر باشد")]

        public string PassWord { get; set; }

        public IFormFile UserAtar { get; set; }

        //public List<int> SelectedRol { get; set; }

    }

      public class EditUserViewModel
    {
        public int Userid { get; set; }
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1}کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1}کاراکتر باشد")]

        public string PassWord { get; set; }
     
        public IFormFile UserAtar { get; set; }

       
        public List<int> UserRols { get; set; }
   
        public string Avatarname { get; set; }
    }
}