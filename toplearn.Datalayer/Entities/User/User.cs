using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace toplearn.Datalayer.Entities.User
{
    public class User
    {
        public User()
        {

        }
        [Key]
        public int UserID { get; set; }
        [Display(Name = "نام کاریری")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1}کاراکتر باشد")]

        public string UserName { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1}کاراکتر باشد")]

        public string Email { get; set; }
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1}کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "ایمبل وارد شده معتبر نمیباشد")]

        public string PassWord { get; set; }
        [Display(Name = "کدفعالسازی")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string ActiveCode { get; set; }
        [Display(Name = "وضعیت")]

        public bool IsActive { get; set; }
        [Display(Name = "آواتار")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string Avatar { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }
        public bool IsDelete { get; set; }

        #region relations

        public virtual List<UserRole> UserRoles { get; set; }
        public virtual List<Wallet.Wallet> Wallets { get; set; }
        #endregion

    }

}
