using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace toplearn.Core.DTOs
{
   public class InformatinUserViewModel
    {
        public string Udername { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public int Wallet { get; set; }


    }

    public class SidBarUserPanelViewModwl
    {
        public string Username { get; set; }

        public DateTime RegisterDate { get; set; }

        public string ImaageName { get; set; }
    }

    public class EditProfilUserPanelViewModel
    {
   
        [Display(Name = "نام کاریری")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1}کاراکتر باشد")]

        public string UserName { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1}کاراکتر باشد")]

        public string Email { get; set; }

        public IFormFile UserAtar { get; set; }

        public string AvatrName { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Display(Name = "کلمه عبورفعلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1}کاراکتر باشد")]

        public string OldPassWord { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1}کاراکتر باشد")]

        public string PassWord { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1}کاراکتر باشد")]

        [Compare("PassWord", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string RePassWord { get; set; }
    }
}
