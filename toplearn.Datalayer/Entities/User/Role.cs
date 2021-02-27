using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace toplearn.Datalayer.Entities.User
{
    public class Role
    {
        public Role()
        {

        }
        [Key]
    
        public int RolID { get; set; }
        [Display(Name ="عنوان نقش")]
        [Required(ErrorMessage ="لطفا {0} را وارد نمایید")]
        [MaxLength(200,ErrorMessage ="{0} نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string RolTitle { get; set; }
        public bool IsDelete { get; set; }


        #region ralations
        public virtual List<UserRole> UserRoles { get; set; }
        #endregion


    }
}
