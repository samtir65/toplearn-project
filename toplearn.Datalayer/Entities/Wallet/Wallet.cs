using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace toplearn.Datalayer.Entities.Wallet
{
    public class Wallet
    {

        public Wallet()
        {

        }
        [Key]
        public int WalletId { get; set; }
        [Display(Name = "نوع تراکنش")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int TypId { get; set; }
        [Display(Name = "کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int UserID { get; set; }
        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int Amount { get; set; }
        [Display(Name = "شرح")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(500, ErrorMessage = "{0} نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string Description { get; set; }
        [Display(Name = "تایید شده")]
        public bool IsPay { get; set; }
        [Display(Name = "تاریخ و ساعت")]
        public DateTime CreateDate { get; set; }
        public virtual User.User user  { get; set; }
        #region relation
        public virtual WalletType WalletType { get; set; }
        #endregion


    }
}
